using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Vendeghaz
{
    public partial class FormAdoption : Form
    {

        private readonly HttpClient client = new HttpClient();
        public string adoptionBaseURL = "http://localhost:3000/desktop/adoption";
        public string guestsBaseURL = "http://localhost:3000/desktop/allGuests";
        public string usersBaseURL = "http://localhost:3000/desktop/allUsers";

        // A listák deklarálása
        private List<Guest> allGName = new List<Guest>();
        private List<User> allUName = new List<User>();

        public FormAdoption()
        {
            InitializeComponent();
        }
        
        private async void FormAdoption_Load(object sender, EventArgs e)
        {
            placeholderAdoption(); //  kelll Kérem válasszon!
            await LoadGuests();
            await LoadUsers();
        }

        private async Task LoadGuests()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(guestsBaseURL);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var guestNames = JsonConvert.DeserializeObject<List<Guest>>(json);

                    comboBox_AdoptionGName.DataSource = guestNames;
                    comboBox_AdoptionGName.DisplayMember = "g_name";
                }
                else
                {
                    MessageBox.Show("Hiba a vendégek lekérésekor!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hálózati hiba: " + ex.Message);
            }
        }

        private async Task LoadUsers()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(usersBaseURL);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var userNames = JsonConvert.DeserializeObject<List<User>>(json);

                    comboBox_AdoptionUName.DataSource = userNames;
                    comboBox_AdoptionUName.DisplayMember = "u_name";
                }
                else
                {
                    MessageBox.Show("Hiba a felhasználók lekérésekor!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hálózati hiba: " + ex.Message);
            }
        }

        public class Guest
        {
            public string g_name { get; set; }        
           // public string G_species { get; set; }
           // public string G_gender { get; set; }
        }

        public class User
        {
            public string u_name { get; set; }
        }











        /**jó**/
        private void placeholderAdoption()   //mező szöveg
        {
            comboBox_AdoptionGName.Text = "Kérem válasszon!";
            comboBox_AdoptionUName.Text = "Kérem válasszon!";
        }
        /**jó**/
        private void emptyFieldsAdoption()  // mezők kiürítése ok m
        {
            comboBox_AdoptionGName.Text = "";
            textBox_AdoptionSpecies.Text = "";
            textBox_AdoptionGender.Text = "";
            pictureBox_AdoptionImage.Image = null;

            comboBox_AdoptionUName.Text = "";
            textBox_AdoptionEmail.Text = "";

            dateTimePicker_AdoptionDate.Value = DateTime.Now;
        }

        /**  **/
        private async void comboBox_AdoptionGName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_AdoptionGName.SelectedIndex == -1)
                return; // Ha nincs kiválasztott elem, akkor kilép

            string selectedGuest = comboBox_AdoptionGName.SelectedItem?.ToString();
            if (/*comboBox_AdoptionGName.SelectedItem is Guest selectedGuest*/!string.IsNullOrEmpty(selectedGuest))
            {
                await LoadGuestData(selectedGuest);
            }
        }

        private async Task LoadGuestData(string guestName)
        {
            try
            {
                string url = $"http://localhost:3000/desktop/guests/{Uri.EscapeDataString(guestName)}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dynamic guest = JsonConvert.DeserializeObject(json);

                    comboBox_AdoptionGName.Text = guest.g_name;
                    textBox_AdoptionSpecies.Text = guest.g_species;
                    textBox_AdoptionGender.Text = guest.g_gender;

                  // Kép elérési útjának összeállítása
                    string basePath = @"C:\Users\Zita\Desktop\VendegHaz\Vendeghaz\Desktop\Guest_Image\";
                    string fullPath = Path.Combine(basePath, (string)guest.g_image); 

                    /* string imagePath = guest.g_image; //guest.image_path */

                    // Kép betöltése
                    if (!string.IsNullOrEmpty(fullPath) && File.Exists(fullPath))
                    {
                        pictureBox_AdoptionImage.Image = Image.FromFile(fullPath);
                    }
                    else
                    {
                        pictureBox_AdoptionImage.Image = null; // Ha nincs kép, töröljük az előzőt
                        MessageBox.Show("A kép nem található!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vendég adatai nem találhatóak!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt az adatok betöltésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /**  **/
        private async void comboBox_AdoptionUName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_AdoptionUName.SelectedItem != null)
            {
                // A kiválasztott User objektumot lekéri
                User selectedUser = comboBox_AdoptionUName.SelectedItem as User;
                if (selectedUser != null)
                {
                    // Aszinkron módon betölti a User adatait
                    await LoadUserData(selectedUser.u_name);
                }
            }
        }

        private async Task LoadUserData(string userName)
        {
            try
            {
                string url = $"http://localhost:3000/desktop/users/{Uri.EscapeDataString(userName)}";
                HttpResponseMessage response = await client.GetAsync(url); //(url)volt

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dynamic user = JsonConvert.DeserializeObject(json);

                    comboBox_AdoptionUName.Text = user.u_name;
                    textBox_AdoptionEmail.Text = user.u_email;
                }
                else 
                {
                    MessageBox.Show($"1Felhasználó adatai nem találhatóak!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt az adatok betöltésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /**nem**/
        private void button_AdoptionInsert_Click(object sender, EventArgs e)
        {

           

        }




        /**jó**/
        private void button_AdoptionAgain_Click(object sender, EventArgs e)
        {
            emptyFieldsAdoption();
            placeholderAdoption();
        }

    }
}
