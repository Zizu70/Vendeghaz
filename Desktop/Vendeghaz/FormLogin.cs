using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Net;
using System.Xml.Linq;

namespace Vendeghaz
{
    public partial class FormLogin : Form
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string loginUrl = "http://localhost:3000/desktop/login";

        private string workersBaseURL = "http://localhost:3000/desktop/workers";

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            comboBox_LoginRole.DataSource = Enum.GetValues(typeof(W_role));
        }
        //belépés gomb klikkje
        private async void button_Login_Click(object sender, EventArgs e)
        {
            string name = textBox_LoginName.Text.Trim();
            string password = textBox_LoginPass.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Kérlek, töltsd ki mindkét mezőt!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var loginData = new { name, password };
            var json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync(loginUrl, content);
                string responseString = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(responseString);

                if (response.IsSuccessStatusCode && result.success == true)
                {
                    MessageBox.Show("Sikeres bejelentkezés!", "Üdv", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Új form megnyitása
                FormMain mainForm = new FormMain();
                mainForm.Show();

                    // Jelenlegi form elrejtése (nem zárjuk be azonnal)
                    this.Hide();

                }
                else
                {
                    MessageBox.Show(result.message.ToString(), "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hálózati hiba: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  
        private void comboBox_LoginRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        // szerviz gomb klikje
        private async void button_LoginService_Click(object sender, EventArgs e)
        {
            string name = textBox_LoginName.Text;
            string password = textBox_LoginPass.Text;


            if (validateInputService())
            {
                // Ellenőrizzük, hogy a bejelentkezés sikeres volt-e és lekértük a role-t
                bool isLoginSuccessful = await checkPermission(name, password);

                if (isLoginSuccessful)
                {
                    // Ha admin jogosultsága van
                    MessageBox.Show("Sikeres szervíz bejelentkezés!", "Siker", MessageBoxButtons.OK,  MessageBoxIcon.Information);

                    // Admin funkciók engedélyezése
                    label_LoginId.Visible = true;
                    label_LoginPerm.Visible = true;
                    textBox_LoginId.Visible = true;
                    comboBox_LoginRole.Visible = true;
                    button_LoginInsert.Visible = true;
                    button_LoginUpdate.Visible = true;
                    button_LoginDelete.Visible = true;

                    emptyFields();
                }
                else
                {
                        // Ha nem admin jogosultságú, akkor nem engedjük be
                    MessageBox.Show("Login service Nincs megfelelő jogosultságod!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_LoginName.Select();
                    return;
                }
            }
            else
            {
                    // Ha nem sikerült a bejelentkezés
                 MessageBox.Show("Sikertelen szervíz bejelentkezés! Hibás felhasználónév, jelszó vagy jogosultság!", "Hiba", MessageBoxButtons.OK,MessageBoxIcon.Error);
                 textBox_LoginName.Select();
                 return;
            }
        }
    
            private bool validateInputService() // RR inserthez + üres konstruktor worksben!
        { //-- adatellenőrzés
            if (string.IsNullOrEmpty(textBox_LoginName.Text))
            {
                MessageBox.Show("Kérjük adja meg a nevét!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_LoginName.Focus();
                return false;
            }
            if (textBox_LoginPass.Text.Length < 3 || textBox_LoginPass.Text.Length > 10)
            {
                // Ellenőrizzük a jelszót regex-szel
                var password = textBox_LoginPass.Text;
                var regex = new Regex(@"^(?=.*[a-záéíóöőúüű])(?=.*[A-ZÁÉÍÓÖŐÚÜŰ])(?=.*\d).{3,10}$");
                if (!regex.IsMatch(password))
                {
                    MessageBox.Show("Jelszó megadása kötelező! Jelszónak tartalmaznia kell min:3 max:10 karaktert, amiben legalább egy kisbetű, egy nagybetű és egy szám szerepel!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_LoginPass.Focus();
                    return false;
                }
            }
            if (string.IsNullOrEmpty(comboBox_LoginRole.Text))
            {
                MessageBox.Show("Válasszon jogosultságot!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox_LoginRole.Focus();
                return false;
            }
            return true;
        }

         private string userRole = ""; // Osztályszintű változó a szerepkör tárolására
       

        private async Task<bool> checkPermission(string name, string password) // u 
        {
            try
            {
                var loginData = new { name = name, password = password };
                string jsonData = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(workersBaseURL + "/login", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<dynamic>(responseContent);

                    MessageBox.Show("Response: " + responseContent, "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    if (result.success == true)
                    {
                        string userRole = result.role; // // Tároljuk a szerepkört osztályszinten

                        // Debug: Ellenőrizzük a role értéket
                        MessageBox.Show("User role: " + userRole, "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        if (userRole == "admin")
                        {
                            return true; // Ha admin, visszaadjuk a sikeres bejelentkezést
                        }
                    }
                }
                else
                {
                    MessageBox.Show("CP Hiba történt: " + response.ReasonPhrase, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    /*return false;*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CP Hiba történt a bejelentkezés során: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false; // Sikertelen bejelentkezés
        }


        private void emptyFields() // RR - Mezű ürítés
        {
            // Kiürítjük a mezőket
            textBox_LoginName.Text = "";
            textBox_LoginPass.Text = "";
            comboBox_LoginRole.Text = "";
        }

        private /*async*/ void button_LoginInsert_Click(object sender, EventArgs e)
        {
        }

        private void button_LoginUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void button_LoginDelete_Click(object sender, EventArgs e) // ide még checkWorkerEx !!!!!!!!!! 
        {
            
        }
        
    }
}
