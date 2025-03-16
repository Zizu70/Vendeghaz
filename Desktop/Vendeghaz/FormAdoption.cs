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

namespace Vendeghaz
{
    public partial class FormAdoption : Form
    {

        private readonly HttpClient client = new HttpClient();
        public string adoptionBaseURL = "http://localhost:3000/desktop/adoption";
        public string guestsBaseURL = "http://localhost:3000/desktop/allGuests";
        public string usersBaseURL = "http://localhost:3000/desktop/allUsers";

       

        public FormAdoption()
        {
            InitializeComponent();
            //InitializeAsync(); 
        }
        /*
        private async void InitializeAsync()
        {
            allAnimals = await allAdoptableAnimal();
            allUsers = await allUser();
            uploadingAnimalName();
            uploadingUserName();
        }
        */
        private void FormAdoption_Load(object sender, EventArgs e)
        {
            placeholderAdoption(); //  kelll Kérem válasszon!
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

        /**jó**/
        private void comboBox_AdoptionGName_SelectedIndexChanged(object sender, EventArgs e)
        {
           
          
        }
        /**jó**/
        private void comboBox_AdoptionUName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        /**nem**/
        private void button_AdoptionInsert_Click(object sender, EventArgs e)
        {

           

        }




        /**jó**/
        private void button_AdoptionAgain_Click(object sender, EventArgs e)
        {
           
        }

    }
}
