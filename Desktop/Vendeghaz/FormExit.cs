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
    public partial class FormExit : Form
    {
        private FormMain mainForm; //**//
        private Timer timer;

        public FormExit(FormMain mainForm)  
        {
            InitializeComponent();
            // a Controlbox elrejtése (ne legyen close button!)
            this.ControlBox = false;
            this.mainForm = mainForm; //**
        }

        private void FormExit_Load(object sender, EventArgs e)
        {
        }

        private void Timer(object sender, EventArgs e)
        {
            // Ha az időzítő lejárt bezáródik az alkalmazás
            Application.Exit();
        }

        private void button_ExitYes_Click(object sender, EventArgs e)
        {
            label_ExitQuestion.Text = "";
            button_ExitYes.Visible = false;
            button_ExitNo.Visible = false;

            // Megjelenítjük az üzenetet
            label_ExitBye.Visible = true;

            // Létrehozzuk és beállítjuk az időzítőt
            timer = new Timer();
            timer.Interval = 3000; // 3 másodperc 3000
            timer.Tick += Timer; //timer.Tick += Timer;
            timer.Start();
        }

        private void button_ExitNo_Click(object sender, EventArgs e)
        {
            this.Close(); // bezárjuk az Exit ablakot
            mainForm.Show(); // visszahozzuk a főformot
           


            //FormMain formMain = new FormMain();     
            //formMain.Show();
        }
    }
}
