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
using static Vendeghaz.FormAdoption;
using System.Diagnostics;
using System.Data.SqlTypes;
using System.Security.Policy;

namespace Vendeghaz
{
    public partial class FormChoice : Form
    {
        private readonly HttpClient client = new HttpClient();
        public string guestsBaseURL = "http://localhost:3000/desktop/allGuests";

       /* // A lista deklarálása
        private List<Guest> allLarge = new List<Guest>();
        private List<Guest> allSmall = new List<Guest>();
        private List<Guest> allBird = new List<Guest>();
        private List<Guest> allYard = new List<Guest>();
        private List<Guest> allStroking = new List<Guest>();
       */
        private CheckBox[] checkBoxes_Choice;

        public FormChoice()
        {
            InitializeComponent();
            InitializeCheckBoxes_Choice();
        }

        private void FormChoice_Load(object sender, EventArgs e)
        {
            listView_Choice.View = View.Details;
            listView_Choice.FullRowSelect = true;
            listView_Choice.Columns.Clear();

            listView_Choice.Columns.Add("ID"); //bármit adok átírja az eredeti beállítást
            listView_Choice.Columns.Add("Név");
            listView_Choice.Columns.Add("Faj");
        }

        public class Guest
        {
            public int G_id { get; set; }
            public string G_name { get; set; }
            public string G_species { get; set; }
            public string G_gender { get; set; }
            public DateTimeOffset G_birthdate { get; set; }
            public DateTimeOffset G_inDate { get; set; }
            public string G_inPlace { get; set; }
            public string G_other { get; set; }
            public string G_image { get; set; }
        }

         private async Task LoadGuestsIntoListView(string url)
         {
             try
             {
                 HttpResponseMessage response = await client.GetAsync(url);
                 if (response.IsSuccessStatusCode)
                 {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Guest> guests = JsonConvert.DeserializeObject<List<Guest>>(json);

                    listView_Choice.Items.Clear(); // Töröljük a régi elemeket

                    foreach (var guest in guests)
                    {
                        ListViewItem item = new ListViewItem(guest.G_id.ToString());
                        item.SubItems.Add(guest.G_name); // Második oszlop: Név
                        item.SubItems.Add(guest.G_species); // Harmadik oszlop: Faj
                        item.SubItems.Add(guest.G_gender); // Nem
                        item.SubItems.Add(guest.G_inPlace); // Helyszín
                        item.SubItems.Add(guest.G_other); // Egyéb infó
                        item.SubItems.Add(guest.G_inDate.ToString("yyyy-MM-dd")); // Érkezési dátum
                        item.SubItems.Add(guest.G_birthdate.ToString("yyyy-MM-dd")); // Születési dátum
                        item.SubItems.Add(guest.G_image); // Kép elérési útvonala (nem jelenik meg a ListView-ban)

                        listView_Choice.Items.Add(item);
                    }
                }
                 else
                 {
                     MessageBox.Show("Hiba a vendégek lekérésekor!");
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Hálózati hiba: " + ex.Message);
             }
         }

        private void checkBox_CheckedChangedChoice(object sender, EventArgs e)
        {
            var clickedCheckBox = (CheckBox)sender;

            if (clickedCheckBox.Checked)
            {
                foreach (var checkBox in checkBoxes_Choice)
                {
                    if (checkBox != clickedCheckBox)
                    {
                        checkBox.Checked = false;
                    }
                }
            }
        }

        private void listView_Choice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_Choice.SelectedIndices.Count > 0)
            {
                ListViewItem listViewItem = listView_Choice.SelectedItems[0];
                
                int selectedId = int.Parse(listViewItem.SubItems[0].Text); // ID oszlop
               
                string selectedName = listViewItem.SubItems[1].Text; // Név oszlop
                string selectedSpecies = listViewItem.SubItems[2].Text; // Faj oszlop
                string selectedGender = listViewItem.SubItems[3].Text;
                string selectedInplace = listViewItem.SubItems[4].Text;
                string selectedOther = listViewItem.SubItems[5].Text;
                
                DateTimeOffset selectedIndate = DateTimeOffset.Parse(listViewItem.SubItems[6].Text);
                DateTimeOffset selectedBirthdate = DateTimeOffset.Parse(listViewItem.SubItems[7].Text);

                string selectedImage = listViewItem.SubItems[8].Text;

                // FormGuest példány létrehozása és adatok átadása
                //Módosítás, törléshez átlépés Formguestbe
                FormGuest formGuest = new FormGuest(selectedId, selectedName, selectedSpecies, selectedGender,  selectedInplace, selectedOther, selectedImage, selectedIndate, selectedBirthdate);
                formGuest.Show();

                // Jelenlegi form elrejtése (nem zárjuk be azonnal)
                this.Hide();

            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem a listában!", "Hiányzó adatok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private async void button_ChoicePick_Click(object sender, EventArgs e) // választás nagy, apró, madár, udvar és simogató, üres-e
        {
            listView_Choice.Items.Clear();
            // Ellenőrizzük, hogy van-e kiválasztott CheckBox
            bool anyChecked = false;
            CheckBox selectedCheckBox = null;

            foreach (var checkBox in checkBoxes_Choice)
            {
                if (checkBox.Checked)
                {
                    if (anyChecked)
                    {
                        MessageBox.Show("Kérlek válassz ki csak egy CheckBox-ot!");
                        return;
                    }
                    anyChecked = true;
                    selectedCheckBox = checkBox;
                }
            }

            if (!anyChecked)
            {
                MessageBox.Show("Nincs kiválasztott CheckBox!", "Hiányzó bejelölés!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            string url = "";


            switch (selectedCheckBox.Name)
            {
                case "checkBox_ChoiceLarge":
                    url = "http://localhost:3000/desktop/guests/allLarge";
                    break;
                case "checkBox_ChoiceSmall":
                    url = "http://localhost:3000/desktop/guests/allSmall";
                    break;
                case "checkBox_ChoiceBird":
                    url = "http://localhost:3000/desktop/guests/allBird";
                    break;
                case "checkBox_ChoiceYard":
                    url = "http://localhost:3000/desktop/guests/allYard";
                    break;
                case "checkBox_ChoiceStroking":
                    url = "http://localhost:3000/desktop/guests/allStoking";
                    break;
                default:
                    MessageBox.Show("Ismeretlen CheckBox!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Lista feltöltése
            await LoadGuestsIntoListView(url);
        }


        private void InitializeCheckBoxes_Choice()
        {
            checkBoxes_Choice = new CheckBox[] { checkBox_ChoiceLarge, checkBox_ChoiceSmall, checkBox_ChoiceBird, checkBox_ChoiceYard, checkBox_ChoiceStroking };

            // Előre beállítjuk a CheckBox-okat
            foreach (var checkBox in checkBoxes_Choice)
            {
                checkBox.CheckedChanged += checkBox_CheckedChangedChoice;
            }
        }


        private void emptyFieldsChoice()  
        {
            // Kiürítjük a mezőket
            checkBox_ChoiceLarge.Checked = false;
            checkBox_ChoiceSmall.Checked = false;
            checkBox_ChoiceBird.Checked = false;
            checkBox_ChoiceYard.Checked = false;
            checkBox_ChoiceStroking.Checked = false;

            listView_Choice.Items.Clear();
        }


        private void button_ChoiceInsert_Click(object sender, EventArgs e)
        {
            //Új vendég hozzáadása
            FormGuest formGuest = new FormGuest();
            formGuest.Show();
            this.Close();
            emptyFieldsChoice();
        }       
    } 
}
