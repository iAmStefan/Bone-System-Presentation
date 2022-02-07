using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atestat___Sistem_Osos
{
    public partial class Lessons : Form
    {
        public Lessons()
        {
            InitializeComponent();
        }

        private void Lessons_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(57, 110, 176);
            Place();
        }

        #region Declarations
        Panel CloseBar = new Panel();
        static Label ExitApp = new Label();
        static Label BackApp = new Label();
        static Label Title = new Label();
        static Button BodyComposition = new Button();
        static Button BoneGrowth = new Button();
        static Button BoneRoles = new Button();
        static Button BonePathologies = new Button();
        Button[] buttons = new Button[] { BodyComposition, BoneGrowth, BoneRoles, BonePathologies };
        Label[] menu = new Label[] { Title, ExitApp, BackApp };
        AxAcroPDFLib.AxAcroPDF pdfReader = new AxAcroPDFLib.AxAcroPDF();
        #endregion

        void Place()
        {
            for (int i = 0; i < menu.Length; i++)
            {
                CloseBar.Controls.Add(menu[i]);
                menu[i].AutoSize = true;
                menu[i].Font = new Font("Tahoma", 16);
                menu[i].BackColor = Color.Transparent;
                menu[i].ForeColor = Color.White;
            }

            ExitApp.Text = "X";
            ExitApp.Location = new Point(788, 0);
            ExitApp.Click += ExitApp_Click;
            BackApp.Text = "<-";
            BackApp.Location = new Point(755, 0);
            BackApp.Click += BackApp_Click;
            Title.Text = "Modulul de învățare";
            Title.Location = new Point((this.Size.Width - ExitApp.Size.Width) / 2 - Title.Size.Width / 2, 0);

            this.Controls.Add(CloseBar);
            CloseBar.Size = new Size(this.Size.Width, 28);
            CloseBar.BackColor = Color.FromArgb(46, 76, 109);

            for (int i = 0; i < buttons.Length; i++)
            {
                this.Controls.Add(buttons[i]);
                buttons[i].Font = new Font("Tahoma", 12);
                buttons[i].FlatStyle = FlatStyle.Flat;
                buttons[i].BackColor = Color.FromArgb(236, 179, 101);
                buttons[i].Size = new Size(170, 50);
                buttons[0].Location = new Point(22, 50);
                if (i > 0) buttons[i].Location = new Point(22, buttons[i - 1].Location.Y + 159);
            }

            BodyComposition.Text = "Alcătuirea sistemului osos";
            BodyComposition.Click += BodyComposition_Click;
            BoneGrowth.Text = "Creșterea oaselor";
            BoneGrowth.Click += BoneGrowth_Click;
            BoneRoles.Text = "Rolul sistemului osos";
            BoneRoles.Click += BoneRoles_Click;
            BonePathologies.Text = "Noțiuni elementare de patologie";
            BonePathologies.Click += BonePathologies_Click;

            pdfReader.Size = new Size(490, 526);
            pdfReader.Location = new Point(300, 50);
        }

        private void BackApp_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void BodyComposition_Click(object sender, EventArgs e)
        {
            this.Controls.Add(pdfReader);
            pdfReader.LoadFile("Alcatuirea sistemului osos.pdf");
        }

        private void BonePathologies_Click(object sender, EventArgs e)
        {
            this.Controls.Add(pdfReader);
            pdfReader.LoadFile("Notiuni elementare de igiena si patologie.pdf");
        }

        private void BoneRoles_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(pdfReader);
            this.Controls.Add(pdfReader);
            pdfReader.LoadFile("Rolul sistemului osos.pdf");
        }

        private void BoneGrowth_Click(object sender, EventArgs e)
        {
            this.Controls.Add(pdfReader);
            pdfReader.LoadFile("Cresterea in lungime si latime a oaselor.pdf");
        }

        private void ExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
