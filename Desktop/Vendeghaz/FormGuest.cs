using Newtonsoft.Json;
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
using static System.Net.Mime.MediaTypeNames.Application;

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
            button_GuestUpdate.Hide();
            button_GuestDelete.Hide();
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

        private void FormGuest_Load(object sender, EventArgs e)
        {
        }

        public FormGuest(int G_id, string G_name, string G_species, string G_gender, string G_inplace, string G_other, string G_image, DateTimeOffset G_indate, DateTimeOffset G_birthdate)
        {
            InitializeComponent();

            // A kapott adatok betöltése a megfelelő mezőkbe
            textBox_GuestId.Text = G_id.ToString();
            textBox_GuestName.Text = G_name;

            comboBox_GuestSpecies.Text = G_species;
            comboBox_GuestGender.Text = G_gender;
            dateTimePicker_GuestBirthdate.Value = G_birthdate.DateTime.AddDays(+1);
            dateTimePicker_GuestIndate.Value = G_indate.DateTime.AddDays(+1);
            textBox_GuestInplace.Text = G_inplace;
            richTextBox_GuestOther.Text = G_other;

            string imageDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Guest_Image");
            string imagePath = Path.Combine(imageDirectory, G_image);

            // Kép betöltése
            if (!string.IsNullOrEmpty(G_image) && File.Exists(imagePath))
            {
                pictureBox_GuestImage.ImageLocation = imagePath;
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
            button_GuestInsert.Hide();
        }

        //** kép kiválasztása pictureboxban **/
        private void pictureBox_GuestImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                // = @"C:\Users\Zita\Desktop\VendegHaz\Vendeghaz\Desktop\Guest_Image",
                Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox_GuestImage.Image = new Bitmap(dialog.FileName);
                selectedImage = File.ReadAllBytes(dialog.FileName);
            }
        }

        private bool validateInputGuest() 
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

        private void emptyFieldsGuest()  // mezők kiürítése
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

            string imageFileName = null;

            if (selectedImage != null)
            {
                // Mentési mappa beállítása
                string imageFolder = Path.Combine(Application.StartupPath, "Guest_Image");

                if (!Directory.Exists(imageFolder))
                {
                    Directory.CreateDirectory(imageFolder);
                }

                // Fájlnév beállítása a vendég neve alapján (pl. Mózes.jpg)
                imageFileName = $"{textBox_GuestName.Text}.jpg";
                string imagePath = Path.Combine(imageFolder, imageFileName);

                try
                {
                    File.WriteAllBytes(imagePath, selectedImage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba a kép mentésekor: " + ex.Message);
                    return;
                }
            }

            var guestData = new
            {
                g_name = textBox_GuestName.Text,
                g_species = comboBox_GuestSpecies.Text,
                g_gender = comboBox_GuestGender.Text,
                g_birthdate = dateTimePicker_GuestBirthdate.Value.ToString("yyyy-MM-dd"),
                g_indate = dateTimePicker_GuestIndate.Value.ToString("yyyy-MM-dd"),
                g_inplace = textBox_GuestInplace.Text,
                g_other = richTextBox_GuestOther.Text,
                g_image = imageFileName// Csak a fájl neve megy az adatbázisba
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
            // Vissza a FormChoicera
            FormChoice formChoice = new FormChoice();
            formChoice.Show();
            this.Close();
        }

        private async void button_GuestUpdate_Click(object sender, EventArgs e)
        {
            if (selectedGuest == null)
            {
                MessageBox.Show("Nincs kiválasztott vendég a frissítéshez!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!validateInputGuest()) return;

            // Alapból megtartjuk a régi képet
            string imageFileName = selectedGuest.G_image;

            if (selectedImage != null)
            {
                // Mentési mappa beállítása
                string imageFolder = Path.Combine(Application.StartupPath, "Guest_Image");

                if (!Directory.Exists(imageFolder))
                {
                    Directory.CreateDirectory(imageFolder);
                }

                // Fájlnév létrehozása biztonságosan a vendég nevéből
                string safeFileName = string.Concat(textBox_GuestName.Text.Split(Path.GetInvalidFileNameChars()));
                imageFileName = $"{safeFileName}.jpg";
                string imagePath = Path.Combine(imageFolder, imageFileName);

                try
                {
                    File.WriteAllBytes(imagePath, selectedImage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba a kép mentésekor: " + ex.Message);
                    return;
                }
            }

            var guestUpdateData = new
            {
                g_name = textBox_GuestName.Text,
                g_species = comboBox_GuestSpecies.Text,
                g_gender = comboBox_GuestGender.Text,
                g_birthdate = dateTimePicker_GuestBirthdate.Value.ToString("yyyy-MM-dd"),
                g_indate = dateTimePicker_GuestIndate.Value.ToString("yyyy-MM-dd"),
                g_inplace = textBox_GuestInplace.Text,
                g_other = richTextBox_GuestOther.Text,
                g_image = imageFileName, // Meglévő vagy új kép neve
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
            // Vissza a FormChoicera
            FormChoice formChoice = new FormChoice();
            formChoice.Show();
            this.Close();
        }

        private async void button_GuestDelete_Click(object sender, EventArgs e)
        {
            if (selectedGuest == null)
            {
                MessageBox.Show("Nincs kiválasztott vendég a törléshez!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Biztosan törölni szeretné a vendéget?", "Törlés", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    HttpResponseMessage result = await client.DeleteAsync($"{guestsURL}/{selectedGuest.G_id}");

                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Vendég törölve!");
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
            }
             // Vissza a FormChoicera
             FormChoice formChoice = new FormChoice();
             formChoice.Show();
             this.Close();         
        }
       
        private void FormContract_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ellenőrzöm, hogy az 'X' gombbal be akarták-e zárni az ablakot
            if (e.CloseReason == CloseReason.UserClosing)
            {
                FormChoice formChoice = new FormChoice();
                formChoice.Show();

                this.Hide();
            }
        }
    }
}
