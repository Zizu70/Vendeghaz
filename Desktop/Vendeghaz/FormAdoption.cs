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
using System.Xml.Linq;
using static Vendeghaz.FormAdoption;

namespace Vendeghaz
{
    public partial class FormAdoption : Form
    {
        private FormContract contractForm;


        private readonly HttpClient client = new HttpClient();
        public string adoptionURL = "http://localhost:3000/desktop/adoption";
        public string guestsURL = "http://localhost:3000/desktop/allGuests";
        public string usersURL = "http://localhost:3000/desktop/allUsers";

        public string adoptedURL = "http://localhost:3000/desktop/adopted";
        public string adoptiveURL = "http://localhost:3000/desktop/adoptive";

        // A listák deklarálása
        private List<Guest> allAnimals; 
        private List<User> allUsers;  

        public FormAdoption()
        {
            InitializeComponent();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            allAnimals = await allAnimal();
            allUsers = await allUser();
            uploadingAnimalName();
            uploadingUserName();
        }

        private void FormAdoption_Load(object sender, EventArgs e)
        {
            placeholderAdoption(); //  "Kérem válasszon!"
        }

        private void placeholderAdoption()   //mező szöveg kérem várjon!
        {
            comboBox_AdoptionGName.Text = "Kérem válasszon!";
            comboBox_AdoptionUName.Text = "Kérem válasszon!";
        }

        private void emptyFieldsAdoption()  // mezők kiürítése 
        {
            comboBox_AdoptionGName.Text = "";
            textBox_AdoptionSpecies.Text = "";
            textBox_AdoptionGender.Text = "";
            pictureBox_AdoptionImage.Image = null;

            comboBox_AdoptionUName.Text = "";
            textBox_AdoptionEmail.Text = "";

            dateTimePicker_AdoptionDate.Value = DateTime.Now;
        }

        public class Guest
        {
            public long G_id { get; set; }
            public string G_name { get; set; }
            public string G_species { get; set; }
            public string G_gender { get; set; }
            public DateTime G_birthdate { get; set; }
        }

        public class User
        {
            public long U_id { get; set; }
            public string U_name { get; set; }
            public string U_email { get; set; }
        }

        private void uploadingAnimalName()
        {
            if (comboBox_AdoptionGName.Items.Count > 0)
                comboBox_AdoptionGName.Items.Clear();

            if (allAnimals != null && allAnimals.Count > 0)
            {
                foreach (Guest animal in allAnimals)
                {
                    if (!string.IsNullOrWhiteSpace(animal.G_name))  //Name
                        comboBox_AdoptionGName.Items.Add(animal.G_name); // Változtasd meg az állatok nevének megfelelő tulajdonságra
                }
            }
            else
            {
                MessageBox.Show("Nincs elérhető adat az állatokhoz.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uploadingUserName()
        {
            if (comboBox_AdoptionUName.Items.Count > 0)
                comboBox_AdoptionUName.Items.Clear();

            if (allUsers != null && allUsers.Count > 0)
            {
                foreach (User user in allUsers)
                {
                    if (!string.IsNullOrWhiteSpace(user.U_name))
                        comboBox_AdoptionUName.Items.Add(user.U_name);
                }
            }
            else
            {
                MessageBox.Show("Nincs elérhető adat a felhasználókhoz.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private async Task<List<Guest>> allAnimal()
        {
            List<Guest> guests = new List<Guest>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $"http://localhost:3000/desktop/allGuests";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        guests = JsonConvert.DeserializeObject<List<Guest>>(responseBody);
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
            return guests;
        }

        private async Task<List<User>> allUser()
        {
            List<User> users = new List<User>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $"http://localhost:3000/desktop/allUsers";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<List<User>>(responseBody);
                    }
                    else
                    {
                        MessageBox.Show("Nem sikerült lekérni a felhasználókat.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return users;
        }

        private  async void comboBox_AdoptionGName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_AdoptionGName.SelectedItem != null)
            {
                await LoadGuestData(comboBox_AdoptionGName.SelectedItem.ToString());
            }
        }

        private async Task LoadGuestData(string guestName)
        {
            try
            {
                string url = $"http://localhost:3000/desktop/adopted/{Uri.EscapeDataString(guestName)}";
                HttpResponseMessage response = await client.GetAsync(url); 

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dynamic guest = JsonConvert.DeserializeObject(json);

                    label_AdoptionGuestId.Text = guest.g_id;
                    comboBox_AdoptionGName.Text = guest.g_name;
                    textBox_AdoptionSpecies.Text = guest.g_species;
                    textBox_AdoptionGender.Text = guest.g_gender;
                    textBox_AdoptionBirthdate.Text = guest.g_birthdate.Value.ToString("yyyy-MM-dd");


                    // Kép elérési útjának összeállítása
                    string basePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/Guest_Image";
                    string fullPath = Path.Combine(basePath, (string)guest.g_image);

                     string imagePath = guest.g_image; //guest.image_path 

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
                    MessageBox.Show($"LoadGuestData Felhasználó adatai nem találhatóak!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt az adatok betöltésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void comboBox_AdoptionUName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_AdoptionUName.SelectedItem != null)
            {
                await LoadUserData(comboBox_AdoptionUName.SelectedItem.ToString());
            }
        }

        private async Task LoadUserData(string userName)
        {
            try
            {
                string url = $"http://localhost:3000/desktop/adoptive/{Uri.EscapeDataString(userName)}";
                HttpResponseMessage response = await client.GetAsync(url); 

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dynamic user = JsonConvert.DeserializeObject(json);

                    label_AdoptionUserId.Text = user.u_id;
                    comboBox_AdoptionUName.Text = user.u_name;
                    textBox_AdoptionEmail.Text = user.u_email;
                }
                else
                {
                    MessageBox.Show($"LoadUserData Felhasználó adatai nem találhatóak!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt az adatok betöltésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task InsertAdoption(string G_id, string U_id)
        {
            try
            {
                string url = $"http://localhost:3000/desktop/adoption";
                var content = new StringContent($"{{\"g_id\":\"{G_id}\",\"u_id\":\"{U_id}\"}}", Encoding.UTF8, "application/json");
             
                HttpResponseMessage response = await client.PostAsync(url, content); 
                
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Az örökbefogadás sikeresen rögzítve!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //FormContract formContract = new FormContract(G_name,  G_species, G_gender, G_birthdate, U_name, A_date);
                    //formContract.Show();
                }
                else
                {
                    MessageBox.Show($"InsertAdoption Nem sikerült rögzíteni az örökbefogadást!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt az adatok betöltésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button_AdoptionInsert_Click(object sender, EventArgs e)
        {
            
            string G_name = comboBox_AdoptionGName.Text;
            string G_species = textBox_AdoptionSpecies.Text;
            string G_gender = textBox_AdoptionGender.Text;
            string G_birthdate = textBox_AdoptionBirthdate.Text;
            string U_name = comboBox_AdoptionUName.Text;
            string A_date = DateTime.Now.ToString("yyyy-MM-dd");

            string G_id = label_AdoptionGuestId.Text;
            string U_id = label_AdoptionUserId.Text;


            await InsertAdoption(G_id,U_id);

            var selectedAnimal = new Guest
            {
                G_id = long.Parse(G_id),
                G_name = G_name,
                G_species = G_species,
                G_gender = G_gender,
                G_birthdate = DateTime.Parse(G_birthdate)
            };

            var selectedUser = new User
            {
                U_id = long.Parse(U_id),
                U_name = U_name
            };

            //var contractForm = new FormContract(selectedAnimal, selectedUser, A_date);
            contractForm = new FormContract(G_name, G_species, G_gender, DateTime.Parse(G_birthdate), U_name, DateTime.Parse(A_date));
            /*FormContract contractForm = new FormContract(selectedAnimal, selectedUser, A_date);*/

            contractForm.Show();

        }

            




        private void button_AdoptionAgain_Click(object sender, EventArgs e)
        {
            emptyFieldsAdoption();
            placeholderAdoption();
        }
    }
}
