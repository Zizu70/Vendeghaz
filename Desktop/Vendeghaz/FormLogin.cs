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
        private readonly string loginURL = "http://localhost:3000/desktop/login";
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
        }

        private FormMain menu;

        //belépés gomb klikkje
        private async void button_Login_Click(object sender, EventArgs e)
        {
            string name = textBox_LoginName.Text.Trim();
            string password = textBox_LoginPass.Text.Trim();

            // Pass data but don't show the form yet

            if (!validateInputLogin()) return;  // új return

            var loginData = new { name, password };
            var json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync(loginURL, content);
                string responseString = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(responseString);

                if (response.IsSuccessStatusCode && result.success == true)
                {
                    MessageBox.Show("Sikeres bejelentkezés!", "Üdv", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Új form megnyitása
                    string role = result.user.w_role;
                    //FormMain mainForm = new FormMain();
                    //mainForm.Show();

                    menu = new FormMain(name, role);
                    MessageBox.Show($"[Form Login] Passed: {name} / {role}");
                    menu.Show();

                    //formServices.Show();



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
                MessageBox.Show("FL BL Hálózati hiba: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
                /*
                if (response.IsSuccessStatusCode)
            {
                dynamic result = JsonConvert.DeserializeObject(responseString);
                string role = result.userRole;

                MessageBox.Show("Sikeres bejelentkezés!", "Üdv", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Új form megnyitása a szerepkörrel együtt
                FormServices formServices = new FormServices(name, password, role);
                formServices.Show();

                this.Hide(); // jelenlegi form elrejtése
            }
            else
            {
                dynamic result = JsonConvert.DeserializeObject(responseString);
                MessageBox.Show(result.message.ToString(), "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hálózati hiba: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
*/


                /*
                if (response.IsSuccessStatusCode && result.success == true)
                {
                    MessageBox.Show("Sikeres bejelentkezés!", "Üdv", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Új form megnyitása
                    FormMain mainForm = new FormMain();
                    mainForm.Show();

                    //FormServices formServices = new FormServices (name, password);
                    //formServices.Show();

                    bool isAdmin = result.user.admin; // vagy is_admin helyett admin, ha így jön vissza

                    FormServices formServices = new FormServices(name, isAdmin);
                    formServices.Show();



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
    }*/


                // adatellenőrzés
                private bool validateInputLogin() 
        { 
            // -- adatellenőrzés: Név
            if (string.IsNullOrWhiteSpace(textBox_LoginName.Text))
            {
                MessageBox.Show("Kérjük, adja meg a nevét!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_LoginName.Focus();
                return false;
            }

            // -- adatellenőrzés: Jelszó: hosszellenőrzés + regex előírás
            var password = textBox_LoginPass.Text;

            if (password.Length < 3 || password.Length > 10)
            {
                MessageBox.Show("A jelszónak legalább 3 és legfeljebb 10 karakter hosszúnak kell lennie.", "Hibás jelszó", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_LoginPass.Focus();
                return false;
            }

            // Regex: kisbetű, nagybetű, szám kötelező, case-sensitive
            var regex = new Regex(@"^(?=.*[a-záéíóöőúüű])(?=.*[A-ZÁÉÍÓÖŐÚÜŰ])(?=.*\d)[\S]{3,10}$");

            if (!regex.IsMatch(password))
            {
                MessageBox.Show("A jelszónak tartalmaznia kisbetűt, nagybetűt számot!\n(Az ékezetes betűk is használhatók.)", "Érvénytelen jelszó", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_LoginPass.Focus();
                return false;
            }
            return true;
        }
    }
}
