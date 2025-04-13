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

        public FormServices()
        {
            InitializeComponent();
        }
        public string S_name;
        public string S_password;
        public FormServices(string W_name, string W_password)
        {
            S_name = W_name;
            S_password = W_password;
        }

        private void FormServices_Load(object sender, EventArgs e)
        {
            comboBox_ServicesRole.DataSource = Enum.GetValues(typeof(W_Role)); //törlendő nem???
        }

        //szervíz belépés clickje     még nem jó
        private async void button_ServicesEntry_Click(object sender, EventArgs e)
        {
            /*
            if (!validateLoginServices())
                return;
            */
            string name = S_name;
            string password = S_password;

            var servicesData = new { name, password };
            var json = JsonConvert.SerializeObject(servicesData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            MessageBox.Show(name + "  " + password);
            try
            {
                HttpResponseMessage response = await client.PostAsync(servicesURL, content);
                string responseString = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(responseString);

                if (response.IsSuccessStatusCode && result.success == true)
                {
                    MessageBox.Show("Sikeres bejelentkezés!", "Üdv a szervíz ágban!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    emptyFieldsServices();
                }
                else
                {  /// még 
                    string errorMessage = result?.message != null ? result.message.ToString() : "Ismeretlen hiba történt!";
                    MessageBox.Show($"S-bt_S_Entry - Sikertelen bejelentkezés:\n{errorMessage}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //MessageBox.Show("S-bt_S_Entry - Nincs megfelelő jogosultságod!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DSG - Hálózati hiba: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void emptyFieldsServices() /// Kiürítjük a mezőket
        {
            textBox_ServicesName.Text = "";
            textBox_ServicesPass.Text = "";
            comboBox_ServicesRole.Text = "";
        }

        // adatellenőrzés
        public bool validateLoginServices()
        {
            // -- adatellenőrzés: Név
            if (string.IsNullOrWhiteSpace(textBox_ServicesName.Text))
            {
                MessageBox.Show("Kérjük, adja meg a nevét!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        } //kell-e kettő

        public bool validateInputServices()
        {
            // -- adatellenőrzés: Név
            if (string.IsNullOrWhiteSpace(textBox_ServicesName.Text))
            {
                MessageBox.Show("Kérjük, adja meg a nevét!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        public async Task<bool> isNameInDatabase(string name)
        {
            /*
            if (string.IsNullOrWhiteSpace(name))
                return false;

            var response = await client.GetAsync(checknameURL);
            return response.IsSuccessStatusCode && bool.Parse(await response.Content.ReadAsStringAsync());
            */
            string url = "http://localhost:3000/desktop/checkname";

            if (string.IsNullOrWhiteSpace(name))
            return false;  // vagy dobhatunk kivételt is

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


        private async Task LoadServices()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(servicesURL);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var workerNames = JsonConvert.DeserializeObject<List<Guest>>(json);

                    // Csak azokat töltjük be, amelyek nincsenek törölve
                    var filteredWorkers = workerNames.Where(w => w.Deleted_at == null).ToList();

                    // Ha ComboBoxot vagy ListBoxot használunk:
                    comboBox_ServicesRole.DataSource = filteredWorkers;
                    comboBox_ServicesRole.DisplayMember = "W_role";
                }
                else
                {
                    MessageBox.Show("LoadS -Hiba a dolgozók lekérésekor!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hálózati hiba: " + ex.Message);
            }
        }

        // új dolgozó felvitel
        private async void button_ServicesInsert_Click(object sender, EventArgs e)
        {
            
            string servicesInsert = textBox_ServicesName.Text;
            if (await isNameInDatabase(servicesInsert))
            {
                MessageBox.Show("Van már ilyen nevű dolgozó az adtbázisban!", "Ellenőrizze!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_ServicesName.Text = "";
                this.ActiveControl = textBox_ServicesName;  // fokusz ide!
            }

            if (!validateInputServices()) return;

            var workerData = new
            {
                w_name = textBox_ServicesName.Text,
                w_password = textBox_ServicesPass.Text,
                w_role = comboBox_ServicesRole.Text,

                //updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

            };

            string json = JsonConvert.SerializeObject(workerData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage result = await client.PostAsync(servicesURL, content);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sikeres feltöltés!");
                    await LoadServices();
                    emptyFieldsServices();
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
        }
        // még nem
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

                //updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            string json = JsonConvert.SerializeObject(workerData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage result = await client.PutAsync($"{workersURL}/{textBox_ServicesName.Text}", content);
                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sikeres frissítés!");
                    await LoadServices();
                    emptyFieldsServices();
                }
                else
                {
                    MessageBox.Show("SZ-U - Hiba a frissítés során!");
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
                        MessageBox.Show("SZ-D - Dolgozó sikeresen törölve!");
                        await LoadServices();  //csak az olyanokat gyűjti akinek delete_at üres!
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



  // kell
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
        } */
        
    }
}
