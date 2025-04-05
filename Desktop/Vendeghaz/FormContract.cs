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
using static Vendeghaz.FormAdoption;

namespace Vendeghaz
{
    public partial class FormContract : Form
    {
        private Guest selectedAnimal;
        private User selectedUser;
        private FormAdoption.Guest selectedAnimal1;

        public FormContract(Guest selectedAnimal, User selectedUser)
        {
            InitializeComponent();
            this.selectedAnimal = selectedAnimal;
            this.selectedUser = selectedUser;
            uploadDataContract();
        }

        public FormContract(FormAdoption.Guest selectedAnimal1, User selectedUser)
        {
            this.selectedAnimal1 = selectedAnimal1;
            this.selectedUser = selectedUser;
        }

        private void FormContract_Load(object sender, EventArgs e)
        {  // üres
        }

        public class Guest
        {
            public string G_name { get; set; }
            public string G_species { get; set; }
            public string G_gender { get; set; }
            public string G_image { get; set; }
            public string G_inplace { get; set; }
            public DateTimeOffset G_birthdate { get; set; }
            public DateTimeOffset G_indate { get; set; }

        }

        public void uploadDataContract()  // adat feltöltése () üres upload
        {  // üres

        }

        public void fillData(string userName, string animalName, string species, string date, /*string secAnimalName, string secSpecies,*/ string gender/*, string birthdate, string inDate, string inPlace*/)
        {
            textBox_ContractUName.Text = userName;
            textBox_ContractGName.Text = animalName;
            textBox_ContractSpecies.Text = species;
            textBox_ContractDate.Text = date;
            
            textBox_ContractSecGName.Text = animalName;
            textBox_ContractSecSpecies.Text = species;
            textBox_ContractGender.Text = gender;
            //textBox_ContractBirthdate.Text = guest.g_birthdate;
            //textBox_ContractInDate.Text = inDate;
            //textBox_ContractInPlace.Text = Guest.G_inplace;
        }

        private void button_ContractPDF_Click(object sender, EventArgs e)
        {
            string animalName = selectedAnimal.G_name.Replace(" ", "_");
            string userName = selectedUser.U_name.Replace(" ", "_");
            string imageName = $"{userName}_és_{animalName}_{DateTime.Now.ToString("yyyy.MM.dd")}_oklevél.jpg";

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));
            string imagePath = Path.Combine(@"C:\Users\Zita\Desktop\VendegHaz\Vendeghaz\Desktop\Contract", imageName);
            bmp.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);

            MessageBox.Show("Az oklevél sikeresen el lett mentve: " + imagePath);
        }

        private void panel_Contract_Paint(object sender, PaintEventArgs e)
        {
            //IDE NEM TÖRÖLNI KELL
        }
    }
}
