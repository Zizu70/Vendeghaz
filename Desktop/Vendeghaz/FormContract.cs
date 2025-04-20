using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Vendeghaz.FormAdoption;

namespace Vendeghaz
{
    public partial class FormContract : Form
    {   
        public string G_name;
        public string G_species;
        public string G_gender;
        public DateTime G_birthdate;
        public string U_name;
        public DateTime A_date;
        public FormContract(string G_name, string G_species, string G_gender, DateTime G_birthdate, string U_name, DateTime A_date)
        {

            InitializeComponent();
            this.G_name = G_name;
            this.G_species = G_species;
            this.G_gender = G_gender;
            this.G_birthdate = G_birthdate;
            this.U_name = U_name;
            this.A_date = A_date;
        }

        private void FormContract_Load(object sender, EventArgs e)
        {
            if (G_name != null && U_name != null)
            {
                // Kitöltés a kapott adatokkal
                textBox_ContractUName.Text = U_name;
                textBox_ContractGName.Text = G_name;
                textBox_ContractSpecies.Text = G_species;
                textBox_ContractGender.Text = G_gender;
                textBox_ContractBirthdate.Text = G_birthdate.ToString("yyyy-MM-dd");
                textBox_ContractDate.Text = A_date.ToString();

                // Második szekció is ugyanaz
                textBox_ContractSecGName.Text = G_name;
                textBox_ContractSecSpecies.Text = G_species;
            }
        }

        public class Guest
        {
            public long G_id { get; set; }
            public string G_name { get; set; }
            public string G_species { get; set; }
            public string G_gender { get; set; }
            public DateTime G_birthdate { get; set; }
        }

        public FormContract(string G_name, string G_species, string G_gender, string G_birthdate, string U_name, string A_date)
        {
            InitializeComponent();

            // A kapott adatok betöltése a megfelelő mezőkbe
            
            textBox_ContractUName.Text = U_name;
            textBox_ContractGName.Text = G_name;
            textBox_ContractSpecies.Text = G_species;

            textBox_ContractDate.Text = A_date;

            textBox_ContractSecGName.Text = G_name;
            textBox_ContractSecSpecies.Text = G_species;
            textBox_ContractGender.Text = G_gender;
            textBox_ContractBirthdate.Text = G_birthdate;

        }

        private void button_ContractJPG_Click(object sender, EventArgs e)
        {
            string animalName = textBox_ContractGName.Text.Replace(" ", "_");
            string userName = textBox_ContractUName.Text.Replace(" ", "_");
            string imageName = $"{userName}_és_{animalName}_{DateTime.Now.ToString("yyyy.MM.dd")}_oklevél.jpg";

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/Contract";
            string imagePath = Path.Combine(path, imageName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            bmp.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);

            MessageBox.Show("Az oklevél sikeresen el lett mentve: " + imagePath);

//Kell
            //System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/Guest_Image" //guestimages elerese
            //C:\Users\Zita\Desktop\VendégHáz\Vendeghaz\Desktop\Vendeghaz\bin\Debug\Contract
        }
    }
}
