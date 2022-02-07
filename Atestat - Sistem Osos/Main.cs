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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            Placing();
        }

        #region Declarations
        Panel CloseBar = new Panel();
        PictureBox BackGround = new PictureBox();
        static Label WindowTitle = new Label();
        static Label ExitApp = new Label();
        static Label Title = new Label();
        static Label HighSchool = new Label();
        static Label Teacher = new Label();
        static Label Student = new Label();
        Button Test = new Button();
        Button Lesson = new Button();
        Label[] details = new Label[] { HighSchool, Student, Teacher };
        Label[] optionBar = new Label[] { WindowTitle, ExitApp };
        #endregion

        void Placing()
        {
            this.Controls.Add(BackGround);
            BackGround.Location = new Point(0,28);
            BackGround.Size = new Size(this.Size.Width, 462);
            BackGround.SizeMode = PictureBoxSizeMode.StretchImage;
            BackGround.Image = new Bitmap("Main_Background.jpg");

            this.Controls.Add(CloseBar);
            CloseBar.Size = new Size(this.Size.Width, 28);
            CloseBar.BackColor = Color.FromArgb(46, 76, 109);

            BackGround.Controls.Add(Title);
            Title.AutoSize = true;
            Title.Font = new Font("Tahoma", 27);
            Title.Text = "Sistemul osos";
            Title.BackColor = Color.Transparent;
            Title.Location = new Point(this.Size.Width / 2 - Title.Size.Width / 2, 70);

            HighSchool.Text = "Colegiul Național ''Gheorghe Țițeica''";
            Student.Text = "Taiche Laurențiu Dan";
            Teacher.Text = "Profesor coordonator: Crețescu Rodica";

            for (int i = 0; i < details.Length; i++)
            {
                BackGround.Controls.Add(details[i]);
                details[i].AutoSize = true;
                details[i].Font = new Font("Tahoma", 22);
                details[i].BackColor = Color.Transparent;
                details[0].Location = new Point(this.Size.Width / 2 - details[0].Size.Width / 2, 140);
                if (i > 0) details[i].Location = new Point(this.Size.Width / 2 - details[i].Size.Width / 2, details[i-1].Location.Y + 40);
            }

            for (int i = 0; i < optionBar.Length; i++)
            {
                CloseBar.Controls.Add(optionBar[i]);
                optionBar[i].AutoSize = true;
                optionBar[i].Font = new Font("Tahoma", 16);
                optionBar[i].BackColor = Color.Transparent;
                optionBar[i].ForeColor = Color.White;
            }

            ExitApp.Text = "X";
            ExitApp.Location = new Point(780, 0);
            WindowTitle.Text = "Meniul principal";
            WindowTitle.Location = new Point((this.Size.Width - ExitApp.Size.Width) / 2 - WindowTitle.Size.Width / 2, 0);
            ExitApp.Click += ExitApp_Click;

            BackGround.Controls.Add(Test);
            Test.Text = "Testează-ți cunoștiințele";
            Test.Size = new Size(100, 45);
            Test.Font = new Font("Tahoma", 10);
            Test.FlatStyle = FlatStyle.Flat;
            Test.Location = new Point(250, 350);
            Test.Click += Test_Click;

            BackGround.Controls.Add(Lesson);
            Lesson.Text = "Află despre oase";
            Lesson.Size = new Size(100, 45);
            Lesson.Font = new Font("Tahoma", 10);
            Lesson.FlatStyle = FlatStyle.Flat;
            Lesson.Location = new Point(470, 350);
            Lesson.Click += Lesson_Click;
        }

        private void Lesson_Click(object sender, EventArgs e)
        {
            Lessons lectii = new Lessons();
            lectii.Show();
            this.Hide();
        }

        private void Test_Click(object sender, EventArgs e)
        {
            Grading testare = new Grading();
            testare.Show();
            this.Hide();
        }

        private void ExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
