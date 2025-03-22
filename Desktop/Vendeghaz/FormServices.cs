using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vendeghaz
{
    public enum W_Role
    {
        Admin,
        User
    }
    public partial class FormServices : Form
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string serviceUrl = "http://localhost:3000/desktop/service";

        private string workersBaseURL = "http://localhost:3000/desktop/workers";
        //public string endPoint;
        public FormServices()
        {
            InitializeComponent();
        }
      
        private void FormServices_Load(object sender, EventArgs e)
        {
            comboBox_ServicesRole.DataSource = Enum.GetValues(typeof(W_Role)); //törlendő nem
        }
        //szervíz gomb clickje     
        private async void button_ServicesEntry_Click(object sender, EventArgs e)
        {
            string name = textBox_ServicesName.Text.Trim();
            string password = textBox_ServicesPass.Text.Trim();
          
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password)) 
            {
                MessageBox.Show("Kérlek, töltsd ki mindkét mezőt!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var servicesData = new { name, password };
            var json = JsonConvert.SerializeObject(servicesData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync(serviceUrl, content);
                string responseString = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(responseString);

                if (response.IsSuccessStatusCode && result.success == true)
                {
                   MessageBox.Show("Sikeres bejelentkezés!", "Üdv a szervíz ágban!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Jelenlegi form elrejtése (nem zárjuk be azonnal)
                        this.Hide(); // Az aktuális form elrejtése
                }
                else
                {
                    MessageBox.Show("Nincs megfelelő jogosultságod!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSG - Hálózati hiba: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void emptyFields() // RR - Mezű ürítés
        {
            // Kiürítjük a mezőket
            textBox_ServicesName.Text = "";
            textBox_ServicesPass.Text = "";
            comboBox_ServicesRole.Text = "";
        }
        /*
        public async Task<bool> isNameInDatabase(string name)
        {
            var response = await client.GetAsync($"{endPoint}/api/checkname?name={name}");
            return response.IsSuccessStatusCode && bool.Parse(await response.Content.ReadAsStringAsync());
        }
        */





        //***********************************************************// 



        // ezt majd torolni kell vagy valami
        public bool validateInputService()
        {
            return true;
        }


        private async void button_ServicesInsert_Click(object sender, EventArgs e)
        {
           /*
            string servicesInsert = textBox_ServicesName.Text;
            if (await isNameInDatabase(servicesInsert))
            {
                MessageBox.Show("Van már ilyen nevű dolgozó az adtbázisban!", "Ellenőrizze!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_ServicesName.Text = "";
                this.ActiveControl = textBox_ServicesName;  // fokusz ide!
            }
            else
            {
                Workers login = new Workers();
                if (validateInputService())
                {
                    login.W_name = textBox_ServicesName.Text;
                    login.W_password = textBox_ServicesPass.Text;
                    login.W_role = comboBox_ServicesRole.SelectedValue.ToString();

                    var json = JsonConvert.SerializeObject(login); //-- továbbítandó adat
                    var data = new StringContent(json, Encoding.UTF8, "application/json"); //-- fejlécet adtunk hozzá
                    var response = await client.PostAsync(endPoint, data);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("A dolgozó sikeresen felvitelre került!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("A dolgozó felvétele sikertelen!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                emptyFields();
            }*/
        }

        private void button_ServicesUpdate_Click(object sender, EventArgs e)
        {

        }

        private void button_ServicesDelete_Click(object sender, EventArgs e)
        {

        }



    /*
        private void FormServices_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ellenőrzöm, hogy az 'X' gombbal be akarták-e zárni az ablakot
            if (e.CloseReason == CloseReason.UserClosing)
            {
                FormExit formExit = new FormExit();
                formExit.Show();

                // Add meg a kívánt viselkedést az ablak bezárásához
                // Például:
                //e.Cancel = true; // Megakadályozza az ablak bezárását
                // vagy:
                //this.Hide(); // Rejtse el az ablakot
            }
        }*/
    }
}
