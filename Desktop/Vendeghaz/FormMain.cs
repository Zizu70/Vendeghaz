using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Vendeghaz
{
    public partial class FormMain : Form
    {
        private CheckBox[] checkBoxes_Main;
        
        public FormMain()
        {
            InitializeComponent();
            InitializeCheckBoxes_Main();
        }

        public string userName { get; set; }
        public string userRole { get; set; }

        public FormMain(string name, string role)
        {
            InitializeComponent();
            InitializeCheckBoxes_Main();
            userName = name;
            userRole = role;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }

        private void InitializeCheckBoxes_Main()
        {
            checkBoxes_Main = new CheckBox[] { checkBox_MainChoice, checkBox_MainAdoption, checkBox_MainTickets, checkBox_MainServices };

            // Előre beállítjuk a CheckBox-okat
            foreach (var checkBox in checkBoxes_Main)
            {
                checkBox.CheckedChanged += checkBox_CheckedChanged;
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {  
            if (!(sender is CheckBox clickedCheckBox)) return;

            if (clickedCheckBox.Checked)
            {
                foreach (var checkBox in checkBoxes_Main)
                {
                    if (checkBox != clickedCheckBox)
                    {
                        checkBox.CheckedChanged -= checkBox_CheckedChanged;
                        checkBox.Checked = false;
                        checkBox.CheckedChanged += checkBox_CheckedChanged;
                    }
                }
            }
        }

        private void button_Main_Click(object sender, EventArgs e)
        {
            bool anyChecked = false;
            CheckBox selectedCheckBox = null;

            foreach (var checkBox in checkBoxes_Main)
            {
                if (checkBox.Checked)
                {
                    if (anyChecked)
                    {
                        MessageBox.Show("Kérem csak egy CheckBox-ot  válasszon ki!");
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

            switch (selectedCheckBox.Name)
            {
                case "checkBox_MainChoice":
                    FormChoice formChoice = new FormChoice();
                    formChoice.Show();
                    break;
                case "checkBox_MainAdoption":
                    FormAdoption formAdoption = new FormAdoption();
                    formAdoption.Show();
                    break;
                case "checkBox_MainTickets":
                    FormTickets formTickets = new FormTickets();
                    formTickets.Show();
                    break;
                case "checkBox_MainServices":
                    FormServices formServices = new FormServices(userName, userRole);
                    formServices.Show();
                    break;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ellenőrzöm, hogy az 'X' gombbal be akarták-e zárni az ablakot
            if (e.CloseReason == CloseReason.UserClosing)
            {                
                // Megakadályozzuk a bezárást
                e.Cancel = true;

                FormExit formExit = new FormExit(this);
                formExit.Show();

                this.Hide();
            }
        }
    }
}
