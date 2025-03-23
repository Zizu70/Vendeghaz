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

namespace Vendeghaz
{
  
    public partial class FormGuest : Form
    {

        public FormGuest()
        {
            InitializeComponent();
        }

        public FormGuest(int G_id, string G_name, string G_species, string G_gender, DateTimeOffset G_indate, DateTimeOffset G_birthdate, string G_inPlace, string G_other, string G_image)
        {
            InitializeComponent();

            // A kapott adatok betöltése a megfelelő mezőkbe
            //textBox_GuestId.Text = G_id;
            textBox_GuestName.Text = G_name;
            

            comboBox_GuestSpecies.Text = G_species;
            comboBox_GuestGender.Text = G_gender;
            dateTimePicker_GuestBirthdate.Value = G_birthdate.DateTime;
            dateTimePicker_GuestIn_date.Value = G_indate.DateTime;
            textBox_GuestIn_place.Text = G_inPlace;
            richTextBox_GuestOther.Text = G_other;


            // Kép betöltése
            if (!string.IsNullOrEmpty(G_image) && System.IO.File.Exists(G_image))
            {
                pictureBox_GuestImage.ImageLocation = G_image;
            }
            else
            {
                pictureBox_GuestImage.Image = null; // Ha nincs kép, töröljük
            }
        }

        private void FormGuest_Load(object sender, EventArgs e)
        {

        }
    }
}
