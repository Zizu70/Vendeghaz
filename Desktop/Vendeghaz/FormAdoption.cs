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

namespace Vendeghaz
{
    public partial class FormAdoption : Form
    {

        private readonly HttpClient client = new HttpClient();
        public string adoptionBaseURL = "http://localhost:3000/desktop/adoption";
        public string guestsBaseURL = "http://localhost:3000/desktop/allGuests";
        public string usersBaseURL = "http://localhost:3000/desktop/allUsers";
        public string adoptedURL = "http://localhost:3000/desktop/adopted";
        public string adoptiveURL = "http://localhost:3000/desktop/adoptive";

        // A listák deklarálása
        private List<Guest> allAnimals; //  = new List<Guest>();
        private List<User> allUsers;  // = new List<User>();

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

        private /*async*/ void FormAdoption_Load(object sender, EventArgs e)
        {
            placeholderAdoption(); //  "Kérem válasszon!"
            //await LoadGuests();
            //await LoadUsers();
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

        public partial class Adoption
        {
            public long A_id { get; set; }

            public DateTimeOffset A_date { get; set; }

            public string G_name { get; set; }

            public string U_name { get; set; }
        }

        public class Guest
        {
            public string G_name { get; set; }
            public string G_species { get; set; }
            public string G_gender { get; set; }
            public string G_image { get; set; }
            public string G_inplace { get; set; }
        }

        public class User
        {
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
        /*
        private async Task LoadGuests()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(guestsBaseURL);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var guestNames = JsonConvert.DeserializeObject<List<Guest>>(json);

                    comboBox_AdoptionGName.SelectedIndexChanged -= comboBox_AdoptionGName_SelectedIndexChanged; // Esemény leválasztása
                    comboBox_AdoptionGName.DataSource = guestNames;
                    comboBox_AdoptionGName.DisplayMember = "g_name";

                }
                else
                {
                    MessageBox.Show("LoadGuests Hiba a vendégek lekérésekor!");
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
                    var userNames = JsonConvert.DeserializeObject<List<Users>>(json);

                    comboBox_AdoptionUName.SelectedIndexChanged -= comboBox_AdoptionUName_SelectedIndexChanged; // Esemény leválasztása
                    comboBox_AdoptionUName.DataSource = userNames;
                    comboBox_AdoptionUName.DisplayMember = "u_name";

                }
                else
                {
                    MessageBox.Show("LoadUsers Hiba a felhasználók lekérésekor!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hálózati hiba: " + ex.Message);
            }
        }
        */
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




        /**  **/
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
                //MessageBox.Show($"Uri.EscapeDataString(userName) {Uri.EscapeDataString(userName)}\nhttp://localhost:3000/desktop/users/{Uri.EscapeDataString(userName)}");
                string url = $"http://localhost:3000/desktop/adopted/{Uri.EscapeDataString(guestName)}";
                HttpResponseMessage response = await client.GetAsync(url); //(url)volt


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



                /**  **/
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
                //MessageBox.Show($"Uri.EscapeDataString(userName) {Uri.EscapeDataString(userName)}\nhttp://localhost:3000/desktop/users/{Uri.EscapeDataString(userName)}");
                string url = $"http://localhost:3000/desktop/adoptive/{Uri.EscapeDataString(userName)}";
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
                    MessageBox.Show($"LoadUserData Felhasználó adatai nem találhatóak!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt az adatok betöltésekor: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task InsertAdoption(string A_date, string G_name, string U_name)
        {
            try
            {
                string url = $"http://localhost:3000/desktop/adoption";
                var content = new StringContent($"{{\"a_date\":\"{A_date}\",\"g_name\":\"{G_name}\",\"u_name\":\"{U_name}\"}}", Encoding.UTF8, "application/json");
                /*
                var json = JsonConvert.SerializeObject(newAdoption);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                */
                HttpResponseMessage response = await client.PostAsync(url, content); //(url)volt
                
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Az örökbefogadás sikeresen rögzítve!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    /*string json = await response.Content.ReadAsStringAsync();
                    dynamic adoption = JsonConvert.DeserializeObject(json);

                    comboBox_AdoptionUName.Text = adoption.u_name;
                    textBox_AdoptionEmail.Text = adoption.u_email;*/

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

            //  új Adoption obj. az űrlap adatatokból
            /*
            Adoption newAdoption = new Adoption
            {
                A_date = dateTimePicker_AdoptionDate.Value,
                G_name = comboBox_AdoptionGName.Text,
                U_name = comboBox_AdoptionUName.Text
                //Created_at = DateTime.Now,
                //Updated_at = DateTime.Now,

            };
            */
            string A_date = DateTime.Now.ToString("yyyy-MM-dd");
            string G_name = comboBox_AdoptionGName.Text;
            string U_name = comboBox_AdoptionUName.Text;

            await InsertAdoption(A_date,G_name,U_name);



            // Üzenet a felhasználónak a sikeres beszúrási műveletről
            //MessageBox.Show("Az új elem sikeresen hozzá lett adva.", "Sikeres beszúrás", MessageBoxButtons.OK, MessageBoxIcon.Information);


            Guest selectedAnimal = allAnimals.Find(animal => animal.G_name == comboBox_AdoptionGName.Text);

            User selectedUser = allUsers.Find(user => user.U_name == comboBox_AdoptionUName.Text);

            FormContract formContract = new FormContract(selectedAnimal, selectedUser);
            //comboBox_AdoptionGName.SelectedItem.ToString()
            formContract.fillData(comboBox_AdoptionGName.SelectedItem.ToString(), textBox_AdoptionSpecies.Text, textBox_AdoptionGender.Text,
              /*textBox_AdoptionBirthdate.Text, textBox_AdoptionIndate.Text,
              textBox_AdoptionInplace.Text,*/

            comboBox_AdoptionUName.Text, /*textBox_AdoptionEmail.Text,*/  dateTimePicker_AdoptionDate.Text);
            

            formContract.ShowDialog();

            //allAnimals = database.allAdoptableAnimal();


            allAnimals = await allAnimal();
            allUsers = await allUser();

            uploadingAnimalName();
            uploadingUserName();

            emptyFieldsAdoption();
            placeholderAdoption();

        }


        /**jó**/
        private void button_AdoptionAgain_Click(object sender, EventArgs e)
        {
            emptyFieldsAdoption();
            placeholderAdoption();
        }

        //*****************************//

        private bool validateInputGuest() //inserthez + üres konstruktor guestben!
        {
            if (string.IsNullOrEmpty(comboBox_AdoptionGName.Text) ||
                string.IsNullOrEmpty(textBox_AdoptionSpecies.Text) ||
                string.IsNullOrEmpty(textBox_AdoptionGender.Text) ||
                string.IsNullOrEmpty(comboBox_AdoptionUName.Text) ||
                string.IsNullOrEmpty(textBox_AdoptionEmail.Text) ||
                string.IsNullOrEmpty(dateTimePicker_AdoptionDate.Text))
            {
                MessageBox.Show("Kérjük, töltse ki az összes kötelező mezőt!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.ActiveControl = comboBox_AdoptionGName;  // fokusz ide!

                return false;
            }
            return true;
        }

    }
}
