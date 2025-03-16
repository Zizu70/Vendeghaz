using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        {   //cg
            if (!(sender is CheckBox clickedCheckBox)) return;

            if (clickedCheckBox.Checked)
            {
                foreach (var checkBox in checkBoxes_Main)
                {
                    if (checkBox != clickedCheckBox)
                    {
                        // Esemény kikapcsolása, hogy ne fusson feleslegesen
                        checkBox.CheckedChanged -= checkBox_CheckedChanged;
                        checkBox.Checked = false;
                        checkBox.CheckedChanged += checkBox_CheckedChanged;
                    }
                }
            }
            /*
            var clickedCheckBox = (CheckBox)sender;

            if (clickedCheckBox.Checked)
            {
                foreach (var checkBox in checkBoxes_Main)
                {
                    if (checkBox != clickedCheckBox)
                    {
                        checkBox.Checked = false;
                    }
                }
            }*/
        }

        private void button_Main_Click(object sender, EventArgs e)
        {
            // Ellenőrizzük, hogy van-e kiválasztott CheckBox
            bool anyChecked = false;
            CheckBox selectedCheckBox = null;

            foreach (var checkBox in checkBoxes_Main)
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
                    FormServices formServices = new FormServices();
                    formServices.Show();
                    break;
            }
        }
    }
}
