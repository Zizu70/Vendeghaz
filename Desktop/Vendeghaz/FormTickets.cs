using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Vendeghaz
{
    public partial class FormTickets : Form
    {
        private readonly HttpClient client = new HttpClient();
        public string ticketsURL = "http://localhost:3000/desktop/tickets";
        public string allTicketURL = "http://localhost:3000/desktop/allTickets";

        // A lista deklarálása
        private List<Ticket> allTickets;

        private Ticket selectedTicket;

        public FormTickets()
        {
            InitializeComponent();
            InitializeAsync();

           
        }

        private async void InitializeAsync()
        {
            allTickets = await allTicket();
            uploadingTicketId();
        }

        public partial class Ticket
        {           
            public long T_id { get; set; }

            public string T_name { get; set; }

            public string T_email { get; set; }

            public DateTimeOffset T_date { get; set; }

            public string T_time { get; set; }

            public long T_piece { get; set; }

            public long T_amount { get; set; }

            public DateTimeOffset Created_at { get; set; }

            public DateTimeOffset? Updated_at { get; set; }

            public object Deleted_at { get; set; }

        }

        private void FormTickets_Load(object sender, EventArgs e)
        {

        }

        private void uploadingTicketId()
        {
            if (comboBox_TicketId.Items.Count > 0)
                comboBox_TicketId.Items.Clear();

            if (allTickets != null && allTickets.Count > 0)
            {
                foreach (Ticket ticket in allTickets)
                {
                    if (!string.IsNullOrWhiteSpace(ticket.T_id.ToString()))  //id
                        comboBox_TicketId.Items.Add(ticket.T_id.ToString()); // 
                }
            }
            else
            {
                MessageBox.Show("Nincs elérhető adat a jegyrendeléshez.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<List<Ticket>> allTicket()
        {
            List<Ticket> tickets = new List<Ticket>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $"http://localhost:3000/desktop/allTickets";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        MessageBox.Show(responseBody); // ← ideiglenesen!

                        tickets = JsonConvert.DeserializeObject<List<Ticket>>(responseBody);
                    }
                    else
                    {
                        MessageBox.Show("Nem sikerült meghívni a vendégeket.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return tickets;
        }

        private async void comboBox_TicketId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_TicketId.SelectedItem != null)
            {
                string selectedIdString = comboBox_TicketId.SelectedItem.ToString();

                // Beállítjuk a selectedTicket objektumot a listából
                if (long.TryParse(selectedIdString, out long selectedId))
                {
                    selectedTicket = allTickets.FirstOrDefault(t => t.T_id == selectedId);
                }

                await LoadTicketData(selectedIdString);
            }



            /*
            if (comboBox_TicketId.SelectedItem != null)
            {
                await LoadTicketData(comboBox_TicketId.SelectedItem.ToString());
            }*/
        }

        private async Task LoadTicketData(string ticketId)
        {
            try
            {
                string url = $"http://localhost:3000/desktop/tickets/{Uri.EscapeDataString(ticketId)}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dynamic ticket = JsonConvert.DeserializeObject(json);
                    /*
                    //
                    if (ticket == null ) //(ticket == null)
                    {
                        MessageBox.Show("A válaszban nem érkezett vissza jegy adat (null).", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Console.WriteLine("Kapott válasz JSON:");
                    Console.WriteLine(json);
                    //
                    */

                    //Ticket ticket = tickets[0];  // csak az első elem

                    //comboBox_TicketId.Text = ticket.T_id.ToString();
                    textBox_TicketName.Text = ticket.t_name;
                    textBox_TicketEmail.Text = ticket.t_email;

                    dateTimePicker_TicketDate.Text = ticket.t_date.Value.ToString("yyyy-MM-dd");
                    comboBox_TicketTime.Text = ticket.t_time;

                    textBox_TicketPiece.Text = Convert.ToString(ticket.t_piece);
                    textBox_TicketAmount.Text = Convert.ToString(ticket.t_amount);  //ticket.t_amount.Value.ToString();
                }
                else
                {
                    MessageBox.Show($"LoadTicketData Jegy adatai nem találhatóak!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a jegy adatok betöltésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //************//
        //i
        private async Task LoadTickets()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(ticketsURL);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var ticketName = JsonConvert.DeserializeObject<List<Ticket>>(json);

                    // Csak azokat töltjük be, amelyek nincsenek törölve
                    var filteredTickets = ticketName.Where(t => t.Deleted_at == null).ToList();

                    // Ha ComboBoxot vagy ListBoxot használunk:
                    comboBox_TicketTime.DataSource = filteredTickets;
                    comboBox_TicketTime.DisplayMember = "T_time";
                }
                else
                {
                    MessageBox.Show("Hiba a jegyek lekérésekor!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hálózati hiba: " + ex.Message);
            }
        }

        private bool validateInputTicket() //inserthez + üres konstruktor guestben!
        {
            if (string.IsNullOrEmpty(textBox_TicketName.Text) ||
                string.IsNullOrEmpty(textBox_TicketEmail.Text) ||
                string.IsNullOrEmpty(dateTimePicker_TicketDate.Text) ||
                string.IsNullOrEmpty(comboBox_TicketTime.Text) ||
                string.IsNullOrEmpty(textBox_TicketPiece.Text) ||
                string.IsNullOrEmpty(textBox_TicketAmount.Text))
            {
                MessageBox.Show("Kérjük, töltse ki az összes kötelező mezőt!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.ActiveControl = textBox_TicketName;  // fokusz ide!

                return false;
            }
            return true;
        }

        private void emptyFieldsTicket()  // mezők kiürítése kell-e??
        {
            comboBox_TicketId.Text = "";

            textBox_TicketName.Text = "";
            textBox_TicketEmail.Text = "";

            dateTimePicker_TicketDate.Value = DateTime.Now; 
            comboBox_TicketTime.Text = "";

            textBox_TicketPiece.Text = "";
            textBox_TicketAmount.Text = "";
        }

        

        private async void button_TicketInsert_Click(object sender, EventArgs e)
        {
            if (!validateInputTicket()) return;

            var ticketData = new
            {
                t_name = textBox_TicketName.Text,
                t_email = textBox_TicketEmail.Text,

                t_date = dateTimePicker_TicketDate.Value.ToString("yyyy-MM-dd"),
                t_time = comboBox_TicketTime.Text,
                t_piece = int.Parse(textBox_TicketPiece.Text),
                t_amount = int.Parse(textBox_TicketAmount.Text),
            };

            string json = JsonConvert.SerializeObject(ticketData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage result = await client.PostAsync(ticketsURL, content);

                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sikeres feltöltés!");
                    await LoadTickets();
                    //cgj await InitializeAsync();
                    emptyFieldsTicket();
                    uploadingTicketId(); //nem tolti fel a idt az ujjal
                    InitializeAsync();
                }
                else
                {
                    MessageBox.Show("Hiba a feltöltés során!");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Hálózati hiba: " + ex.Message);
            }
        }

        private async void button_TicketUpdate_Click(object sender, EventArgs e)
        {


            if (selectedTicket == null)
            {
                MessageBox.Show("Nincs kiválasztott jegy a frissítéshez!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!validateInputTicket()) return;

            var guestTicketData = new
            {
                t_name = textBox_TicketName.Text,
                t_email = textBox_TicketEmail.Text,

                t_date = dateTimePicker_TicketDate.Value.ToString("yyyy-MM-dd"),
                t_time = textBox_TicketEmail.Text,

                t_piece = int.Parse(textBox_TicketPiece.Text),
                t_amount = int.Parse(textBox_TicketAmount.Text),

                updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

           

            string json = JsonConvert.SerializeObject(guestTicketData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage result = await client.PutAsync($"{ticketsURL}/{selectedTicket.T_id}", content);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sikeres frissítés!");
                    await LoadTickets();
                    emptyFieldsTicket();
                }
                else
                {
                    MessageBox.Show("Hiba a frissítés során!");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Hálózati hiba: " + ex.Message);
            }
        }

        private async void button_TicketDelete_Click(object sender, EventArgs e)
        {
            if (selectedTicket == null)
            {
                MessageBox.Show("Nincs kiválasztott jegy a törléshez!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var content = new StringContent("", Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PutAsync($"{ticketsURL}/{selectedTicket.T_id}", content);

                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Jegyrendelés törölve (soft delete)!");
                    await LoadTickets();
                    emptyFieldsTicket();
                }
                else
                {
                    MessageBox.Show("Törlés sikertelen!");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Hálózati hiba: " + ex.Message);
            }
        }
    }
}
