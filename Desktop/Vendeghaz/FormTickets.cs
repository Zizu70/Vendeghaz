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

namespace Vendeghaz
{
    public partial class FormTickets : Form
    {
        private readonly HttpClient client = new HttpClient();
        public string ticketsURL = "http://localhost:3000/desktop/tickets";
        public string allTicketURL = "http://localhost:3000/desktop/allTickets";

        // A lista deklarálása
        private List<Ticket> allTickets;

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
                await LoadTicketData(comboBox_TicketId.SelectedItem.ToString());
            }
        }

        private async Task LoadTicketData(string ticketName)
        {
            try
            {
                string url = $"http://localhost:3000/desktop/tickets/{Uri.EscapeDataString(ticketName)}";
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

                    dateTimePicker_TicketDate.Text = ticket.t_date.ToString("yyyy-MM-dd");
                    comboBox_TicketTime.Text = ticket.t_time;

                    textBox_TicketPiece.Text = ticket.t_piece.ToString();
                    textBox_TicketAmount.Text = ticket.t_amount.ToString();
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
    }
}
