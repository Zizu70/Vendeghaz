﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Vendeghaz
{
    

    public partial class FormGuest : Form
    {
        private readonly HttpClient client = new HttpClient();
        public string guestsURL = "http://localhost:3000/desktop/guests";
        private Guest selectedGuest;
        private byte[] selectedImage;


        public FormGuest()
        {
            InitializeComponent();
        }

        private async Task LoadGuests()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(guestsURL);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var guestNames = JsonConvert.DeserializeObject<List<Guest>>(json);

                    // Csak azokat töltjük be, amelyek nincsenek törölve
                    var filteredGuests = guestNames.Where(g => g.Deleted_at == null).ToList();

                    // Ha ComboBoxot vagy ListBoxot használunk:
                    comboBox_GuestSpecies.DataSource = filteredGuests;
                    comboBox_GuestSpecies.DisplayMember = "G_species";
                    comboBox_GuestGender.DataSource = filteredGuests;
                    comboBox_GuestGender.DisplayMember = "G_name";
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

        //cgjav
        private void FormGuest_Load(object sender, EventArgs e)
        {
            //comboBox_GuestSpecies.DataSource = Enum.GetValues(typeof(G_species));
            //comboBox_GuestSpecies.SelectedIndex = -1; // Ne legyen előre kiválasztott érték
        }


        public FormGuest(int G_id, string G_name, string G_species, string G_gender, string G_inplace, string G_other, string G_image, DateTimeOffset G_indate, DateTimeOffset G_birthdate)
        {
            InitializeComponent();

            // A kapott adatok betöltése a megfelelő mezőkbe
            textBox_GuestId.Text = G_id.ToString();
            textBox_GuestName.Text = G_name;

            comboBox_GuestSpecies.Text = G_species;
            comboBox_GuestGender.Text = G_gender;
            dateTimePicker_GuestBirthdate.Value = G_birthdate.DateTime;
            dateTimePicker_GuestIndate.Value = G_indate.DateTime;
            textBox_GuestInplace.Text = G_inplace;
            richTextBox_GuestOther.Text = G_other;

            // Kép betöltése
            if (!string.IsNullOrEmpty(G_image) && System.IO.File.Exists(G_image))
            {
                pictureBox_GuestImage.ImageLocation = G_image;
            }
            else
            {
                pictureBox_GuestImage.Image = null; // Ha nincs kép, töröljük
            }

            selectedGuest = new Guest
            {
                G_id = G_id,
                G_name = G_name,
                G_species = G_species,
                G_gender = G_gender,
                G_inplace = G_inplace,
                G_other = G_other,
                G_image = G_image,
                G_indate = G_indate,
                G_birthdate = G_birthdate
            };
            /*
            // Kép elérési útjának összeállítása
            string basePath = @"C:\Users\Zita\Desktop\VendegHaz\Vendeghaz\Desktop\Guest_Image\";  
            string fullPath = Path.Combine(basePath, (string)G_image);

            // Kép betöltése
            if (!string.IsNullOrEmpty(fullPath) && File.Exists(fullPath))
            {
                pictureBox_GuestImage.Image = Image.FromFile(fullPath);
            }
            else
            {
                pictureBox_GuestImage.Image = null; // Ha nincs kép, töröljük az előzőt
                MessageBox.Show("A GUEST kép nem található!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }

        //** kép kiválasztása pictureboxban **/
        private void pictureBox_GuestImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\Users\Zita\Desktop\VendegHaz\Vendeghaz\Desktop\Guest_Image",
                Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox_GuestImage.Image = new Bitmap(dialog.FileName);
                selectedImage = File.ReadAllBytes(dialog.FileName);
            }
        }

        private bool validateInputGuest() //inserthez + üres konstruktor guestben!
        {
            if (string.IsNullOrEmpty(textBox_GuestName.Text) ||
                string.IsNullOrEmpty(comboBox_GuestSpecies.Text) ||
                string.IsNullOrEmpty(comboBox_GuestGender.Text) ||
                string.IsNullOrEmpty(textBox_GuestInplace.Text))
            {
                MessageBox.Show("Kérjük, töltse ki az összes kötelező mezőt!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.ActiveControl = textBox_GuestName;  // fokusz ide!

                return false;
            }
            return true;
        }

        private void emptyFieldsGuest()  // mezők kiürítése kell-e??
        {
            textBox_GuestName.Text = "";
            comboBox_GuestSpecies.Text = "";
            comboBox_GuestGender.Text = "";

            dateTimePicker_GuestBirthdate.Value = DateTime.Now;
            dateTimePicker_GuestIndate.Value = DateTime.Now;

            textBox_GuestInplace.Text = "";
            richTextBox_GuestOther.Text = "";
            pictureBox_GuestImage.Image = null;
        }



        private async void button_GuestInsert_Click(object sender, EventArgs e)
        {
            if (!validateInputGuest()) return;

            var guestData = new
            {
                g_name = textBox_GuestName.Text,
                g_species = comboBox_GuestSpecies.Text,
                g_gender = comboBox_GuestGender.Text,
                g_birthdate = dateTimePicker_GuestBirthdate.Value.ToString("yyyy-MM-dd"),
                g_indate = dateTimePicker_GuestIndate.Value.ToString("yyyy-MM-dd"),
                g_inplace = textBox_GuestInplace.Text,
                g_other = richTextBox_GuestOther.Text,
                g_image = selectedImage != null ? Convert.ToBase64String(selectedImage) : null
            };

            string json = JsonConvert.SerializeObject(guestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage result = await client.PostAsync(guestsURL, content);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sikeres feltöltés!");
                    await LoadGuests();
                    emptyFieldsGuest();
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


            /*
            if (string.IsNullOrWhiteSpace(textBox_GuestName.Text) ||
                string.IsNullOrWhiteSpace(comboBox_GuestSpecies.Text) ||
                string.IsNullOrWhiteSpace(comboBox_GuestGender.Text))
            {
                MessageBox.Show("Minden mező kitöltése kötelező!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string G_name = textBox_GuestName.Text;
            string G_species = comboBox_GuestSpecies.Text;
            string G_gender = comboBox_GuestGender.Text;
            DateTimeOffset G_birthdate = dateTimePicker_GuestBirthdate.Value;
            DateTimeOffset G_indate = dateTimePicker_GuestIndate.Value;
            string G_inplace = textBox_GuestInplace.Text;
            string G_other = richTextBox_GuestOther.Text;

            string G_image = selectedImage != null ? Convert.ToBase64String(selectedImage) : null;
            /**********
            string debugPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "Guest_Images");
            if (!Directory.Exists(debugPath))
            {
                Directory.CreateDirectory(debugPath);
            }
            ///////////*//*
            var content = new StringContent($"{{\"g_name\":\"{G_name}\",\"g_species\":\"{G_species}\",\"g_gender\":\"{G_gender}\",\"g_birthdate\":\"{G_birthdate}\",\"g_indate\":\"{G_indate}\",\"g_inplace\":\"{G_inplace}\",\"g_other\":\"{G_other}\"}}", Encoding.UTF8, "application/json");
            // ,\"g_image\":\"{G_image}\"
            try
            {
                HttpResponseMessage result = await client.PostAsync(guestsBaseURL, content);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sikeres feltöltés!");
                    await LoadGuests();
                    emptyFieldsGuest();
                }
                else
                {
                    MessageBox.Show("Hiba a feltöltés során!");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            */
        }  

                //guest.Created_at = DateTime.Now;
                //guest.Updated_at = DateTime.Now;

        private async void button_GuestUpdate_Click(object sender, EventArgs e)
        {
            if (selectedGuest == null)
            {
                MessageBox.Show("Nincs kiválasztott vendég a frissítéshez!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!validateInputGuest()) return;

            var guestUpdateData = new
            {
                g_name = textBox_GuestName.Text,
                g_species = comboBox_GuestSpecies.Text,
                g_gender = comboBox_GuestGender.Text,
                g_birthdate = dateTimePicker_GuestBirthdate.Value.ToString("yyyy-MM-dd"),
                g_indate = dateTimePicker_GuestIndate.Value.ToString("yyyy-MM-dd"),
                g_inplace = textBox_GuestInplace.Text,
                g_other = richTextBox_GuestOther.Text,
                updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            string json = JsonConvert.SerializeObject(guestUpdateData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage result = await client.PutAsync($"{guestsURL}/{selectedGuest.G_id}", content);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sikeres frissítés!");
                    await LoadGuests();
                    emptyFieldsGuest();
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


            /*
            if (string.IsNullOrWhiteSpace(textBox_GuestName.Text) ||
                string.IsNullOrWhiteSpace(comboBox_GuestSpecies.Text) ||
                string.IsNullOrWhiteSpace(comboBox_GuestGender.Text))
            {
                MessageBox.Show("Minden mező kitöltése kötelező!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/
            /*if (validateInputGuest()) // Ellenőrizzük, hogy minden kötelező mező kitöltve van-e
            {
                if (selectedGuest != null)
                {
                    selectedGuest.G_name = textBox_GuestName.Text;
                    selectedGuest.G_species = comboBox_GuestSpecies.Text;
                    selectedGuest.G_gender = comboBox_GuestGender.Text;
                    selectedGuest.G_birthdate = dateTimePicker_GuestBirthdate.Value;
                    selectedGuest.G_indate = dateTimePicker_GuestIndate.Value;
                    selectedGuest.G_inplace = textBox_GuestInplace.Text;
                    selectedGuest.G_species = comboBox_GuestSpecies.Text;
                    selectedGuest.G_other = richTextBox_GuestOther.Text;
                    // A módosítás idejét frissítjük

                    selectedGuest.Updated_at = DateTime.Now; // ????


                    try
                    {
                        var content = new StringContent($"{{\"g_name\":\"{selectedGuest.G_name}\",\"g_species\":\"{selectedGuest.G_species}\",\"g_gender\":\"{selectedGuest.G_gender}\",\"g_birthdate\":\"{selectedGuest.G_birthdate}\",\"g_indatee\":\"{selectedGuest.G_indate}\",\"g_inplace\":\"{selectedGuest.G_inplace}\",\"g_other\":\"{selectedGuest.G_other}\",}}", Encoding.UTF8, "application/json"); // ,\"g_image\":\"{G_image}\"

                        //MessageBox.Show(description);  ???
                        HttpResponseMessage result = await client.PutAsync($"{guestsBaseURL}/{selectedGuest.G_id}", content);

            */
            //*** kép kezelés ***/
            /*if (result.IsSuccessStatusCode)
            {
                MessageBox.Show("Sikeres frissítés!");
                await LoadGuests();
                emptyFieldsGuest();
            }
            else
            {
                MessageBox.Show("Hiba a frissítés során!");
            }
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}
// Vissza a FormChoicera
FormChoice formChoice = new FormChoice();
formChoice.Show();
this.Close();*/

        }

        //**  **//  //soft delete
        private async void button_GuestDelete_Click(object sender, EventArgs e)
        {

            if (selectedGuest == null)
            {
                MessageBox.Show("Nincs kiválasztott vendég a törléshez!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var content = new StringContent("", Encoding.UTF8, "application/json");
                HttpResponseMessage result = await client.PutAsync($"{guestsURL}/{selectedGuest.G_id}", content);

                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Vendég törölve (soft delete)!");
                    await LoadGuests();
                    emptyFieldsGuest();
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








            /*if (string.IsNullOrWhiteSpace(textBox_GuestId.Text))
            {
                MessageBox.Show("Nincs kiválasztott vendég!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Biztosan törölni szeretnéd?", "Megerősítés", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    HttpResponseMessage result = await client.DeleteAsync($"{guestsURL}/{textBox_GuestId.Text}");
                    if (result.IsSuccessStatusCode)
                    {
                        deleted_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        MessageBox.Show("Vendég sikeresen törölve!");
                        await LoadGuests();
                        emptyFieldsGuest();
                    }
                    else
                    {
                        MessageBox.Show("Hiba a törlés során!");
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("Hálózati hiba: " + ex.Message);
                }*/

            /*
            //MessageBox.Show($"{textBox_GuestId.Text}");
            if (Convert.ToInt32(textBox_GuestId.Text) == 0)
            {
                MessageBox.Show("Nincs kiválasztott vendég!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Biztosan törölni szeretnéd?", "Megerősítés", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    HttpResponseMessage result = await client.DeleteAsync($"{guestsBaseURL}/{textBox_GuestId.Text}");

                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Vendég sikeresen törölve!");
                        await LoadGuests();
                        emptyFieldsGuest();
                    }
                    else
                    {
                        MessageBox.Show("Hiba a törlés során!");
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }*/

            /* // Vissza a FormChoicera
             FormChoice formChoice = new FormChoice();
             formChoice.Show();
             this.Close();
         }*/
        }
    }
}
