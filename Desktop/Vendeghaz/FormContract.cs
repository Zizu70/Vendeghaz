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

namespace Vendeghaz
{
    public partial class FormContract : Form
    {
        //private Guest selectedAnimal;
        //private User selectedUser;

        public FormContract()
        {
            InitializeComponent();
            //this.selectedAnimal = selectedAnimal;
            //this.selectedUser = selectedUser;
            uploadDataContract();
        }
       
        private void FormContract_Load(object sender, EventArgs e)
        {  // üres
        }

        public void uploadDataContract()  // adat feltöltése () üres upload
        {  // üres

        }

        public void fillData(string userName, string animalName, string species, string date, string secAnimalName, string secSpecies, string gender, string birthdate, string inDate, string inPlace)
        {
            textBox_ContractUName.Text = userName;
            textBox_ContractGName.Text = animalName;
            textBox_ContractSpecies.Text = species;
            textBox_ContractDate.Text = date;
            
            textBox_ContractSecGName.Text = secAnimalName;
            textBox_ContractSecSpecies.Text = secSpecies;
            textBox_ContractGender.Text = gender;
            textBox_ContractBirthdate.Text = birthdate;
            textBox_ContractInDate.Text = inDate;
            textBox_ContractInPlace.Text = inPlace;
        }

        private void button_ContractPDF_Click(object sender, EventArgs e)
        {
            /*string animalName = selectedAnimal.G_name.Replace(" ", "_");
            string userName = selectedUser.Name.Replace(" ", "_");
            string imageName = $"{userName}_és_{animalName}_{DateTime.Now.ToString("yyyy.MM.dd")}_szerződés.jpg";

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));
            string imagePath = Path.Combine(@"C:\Users\Zita\Desktop\VendegHaz\Vendeghaz\Desktop\Contract", imageName);
            bmp.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);

            MessageBox.Show("Az oklevél sikeresen el lett mentve: " + imagePath);*/
        }

        private void panel_Contract_Paint(object sender, PaintEventArgs e)
        {
            //IDE NEM TÖRÖLNI KELL
        }
    }
}
