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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Vendeghaz
{
    public enum W_Role
    {
        admin,
        dolgozó
    }

    public partial class FormServices : Form
    {
        private readonly HttpClient client = new HttpClient();

        private readonly string servicesURL = "http://localhost:3000/desktop/services";
        private readonly string checknameURL = "http://localhost:3000/desktop/checkname";
        private readonly string workersURL = "http://localhost:3000/desktop/workers";

        private string userName;
        private string userRole;

        public FormServices()
        {
            InitializeComponent();
        }

        public FormServices(string name, string role)
        {
            InitializeComponent();
            userName = name;
            userRole = role;

            // Cimkében jelenítjük meg a bejelentkezett személy nevét és jogosultságát:
            label_ServiceInfo.Text = $"Bejelentkezve: {userName} - {userRole}";
        }

        private void FormServices_Load(object sender, EventArgs e)
        {            
            label2.Hide();
            label3.Hide();
            label4.Hide();
            textBox_ServicesName.Hide();
            textBox_ServicesPass.Hide();
            comboBox_ServicesRole.Hide();
            button_ServicesInsert.Hide();
            button_ServicesUpdate.Hide();
            button_ServicesDelete.Hide();
        }

        private void button_ServicesEntry_Click(object sender, EventArgs e)
        {
            if (userRole == "admin")
            {
            // Engedélyezzük a CRUD gombokat
                label2.Show();
                label3.Show();
                label4.Show();
                textBox_ServicesName.Show();
                textBox_ServicesPass.Show();
                comboBox_ServicesRole.Show();
                button_ServicesInsert.Show();
                button_ServicesUpdate.Show();
                button_ServicesDelete.Show();

                comboBox_ServicesRole.DataSource = Enum.GetValues(typeof(W_Role)); 
            }
            else
            {
                // Csak olvasás engedélyezett
                textBox_ServicesName.Enabled = false;
                textBox_ServicesPass.Enabled = false;
                comboBox_ServicesRole.Enabled = false;
                button_ServicesInsert.Enabled = false;
                button_ServicesUpdate.Enabled = false;
                button_ServicesDelete.Enabled = false;

                MessageBox.Show("Nincs admin jogosultságod!", "Jogosultság", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void emptyFieldsServices() /// Kiürítjük a mezőket
        {
            textBox_ServicesName.Text = "";
            textBox_ServicesPass.Text = "";
            comboBox_ServicesRole.Text = "";
        }

        public bool validateInputServices()
        {
            // -- adatellenőrzés: Név
            if (string.IsNullOrWhiteSpace(textBox_ServicesName.Text))
            {
                MessageBox.Show("Kérjük, adja meg a nevet!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_ServicesName.Focus();
                return false;
            }

            // -- adatellenőrzés: Jelszó: hosszellenőrzés + regex előírás
            var password = textBox_ServicesPass.Text;

            if (password.Length < 3 || password.Length > 10)
            {
                MessageBox.Show("A jelszónak legalább 3 és legfeljebb 10 karakter hosszúnak kell lennie.", "Hibás jelszó", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_ServicesPass.Focus();
                return false;
            }

            // Regex: kisbetű, nagybetű, szám kötelező, case-sensitive
            var regex = new Regex(@"^(?=.*[a-záéíóöőúüű])(?=.*[A-ZÁÉÍÓÖŐÚÜŰ])(?=.*\d)[\S]{3,10}$");

            if (!regex.IsMatch(password))
            {
                MessageBox.Show("A jelszónak tartalmaznia kell legalább egy kisbetűt, egy nagybetűt és egy számot!\n(Az ékezetes betűk is támogatottak.)", "Érvénytelen jelszó", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_ServicesPass.Focus();
                return false;
            }
            return true;
        }

        public async Task<bool> chackName(string name)
        {
            string url = "http://localhost:3000/desktop/checkname";

            if (string.IsNullOrWhiteSpace(name))
            return false; 

             using (HttpClient client = new HttpClient())
             {
                var json = JsonConvert.SerializeObject(new { name });
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                 HttpResponseMessage response = await client.PostAsync(url, content);
                    string result = await response.Content.ReadAsStringAsync();
                    dynamic jsonResult = JsonConvert.DeserializeObject(result);

                    return jsonResult.exists == true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba a névellenőrzés során: " + ex.Message, "Hiba", MessageBoxButtons.OK,   MessageBoxIcon.Error);
                    return false;
                }
             } 
        }

        private async void button_ServicesInsert_Click(object sender, EventArgs e)
        {
            string servicesInsert = textBox_ServicesName.Text;
            if (await chackName(servicesInsert.ToLower()))
            {
                MessageBox.Show("Van már ilyen nevű dolgozó az adatbázisban!", "Ellenőrizze!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_ServicesName.Text = "";
                this.ActiveControl = textBox_ServicesName;  // fokusz ide!
                return;
            }

            if (!validateInputServices()) return;

            var workerData = new
            {
                w_name = textBox_ServicesName.Text,
                w_password = textBox_ServicesPass.Text,
                w_role = comboBox_ServicesRole.Text
            };
            
            string json = JsonConvert.SerializeObject(workerData);

            var content = new StringContent($"{{\"w_name\":\"{textBox_ServicesName.Text}\",\"w_password\":\"{textBox_ServicesPass.Text}\",\"w_role\":\"{comboBox_ServicesRole.Text}\"}}", Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage result = await client.PostAsync(servicesURL, content);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sikeres feltöltés!");
                    emptyFieldsServices();
                }
                else
                {
                    MessageBox.Show("Hiba dolgózó felvitele során!");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Hálózati hiba: " + ex.Message);
            }
        }

        private async void button_ServicesUpdate_Click(object sender, EventArgs e)
        {
            if (textBox_ServicesName.Text == null)
            {
                MessageBox.Show("Nincs kiválasztott dolgozó a frissítéshez!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!validateInputServices()) return;

            var workerData = new
            {
                w_name = textBox_ServicesName.Text,
                w_password = textBox_ServicesPass.Text,
                w_role = comboBox_ServicesRole.Text,
            };

            string json = JsonConvert.SerializeObject(workerData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage result = await client.PutAsync($"{servicesURL}/{textBox_ServicesName.Text}", content);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sikeres frissítés!");
                    emptyFieldsServices();
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

        private async void button_ServicesDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_ServicesName.Text))
            {
                MessageBox.Show("Nincs kiválasztott dolgozó!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Biztosan törölni szeretnéd?", "Megerősítés", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    HttpResponseMessage result = await client.DeleteAsync($"{servicesURL}/{textBox_ServicesName.Text}");
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Dolgozó sikeresen törölve!");
                        emptyFieldsServices();
                    }
                    else
                    {
                        MessageBox.Show("Hiba a törlés során!");
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show("Hálózati hiba: " + ex.Message);
                }
            }
        }
    }
}
