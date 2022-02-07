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
    public partial class Grading : Form
    {
        public Grading()
        {
            InitializeComponent();
        }

        private void Grading_Load(object sender, EventArgs e)
        {
            PlaceStart();
            PlaceBar();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(57, 110, 176);
        }

        #region Declarations
        String[] QuestionList = new String[] { "Ce oase NU aparțin viscerocraniului?", "Identificați afirmația corectă legată de coaste:", "Ce oase aparțin scheletului membrelor superioare?", "Identificați afirmația greșită legată de creșterea oaselor:", "Selectați varianta corectă despre stern:", "Care dintre următoarele oase fac parte din alcătuirea piciorului?", "Selectați informația falsă despre rolul sistemului osos:", "Selectați afirmația corectă despre coloana vertebrală:", "Care sunt cele două oase ale antebrațului?" };
        List<String> nrQuestion = new List<String>();
        static String[] Question0Answers = new String[] { "osul vomer și oasele palatine", "osul etmoid și osul frontal", "oasele nazale și lacrimale", "mandibula și oasele zigomatice" };
        static String[] Question1Answers = new String[] { "Coastele sunt în număr de 11 perechi și sunt oase late.", "Perechile de coaste 11-12 se articulează indirect cu sternul prin cartilajele proprii.", "Perechile de coaste 8-11 nu se articulează cu sternul.", "Perechile de coaste 1-7 se articulează direct cu sternul prin cartilajele proprii." };
        static String[] Question2Answers = new String[] { "radius și humerus", "femur și humerus", "sacrum și fibulă", "scapulă și tarsienele" };
        static String[] Question3Answers = new String[] { "Creșterea în grosime caracterizează toate formele de oase: lungi, late și scurte.", "Creșterea în lungime caracterizează oasele lungi și scurte.", "Asigură formarea de țesut osos nou pe diafiză prin osificarea de cartilaj.", "Creșterea oaselor depinde de factori endocrini." };
        static String[] Question4Answers = new String[] { "Este format din manubriu, corp și apendice xifoid.", "Este os pereche și se articulează cu primele 8 perechi de coaste.", "Este situat periferic.", "Este os lung." };
        static String[] Question5Answers = new String[] { "Tarsiene", "Metacarpiene", "Carpiene", "Femur" };
        static String[] Question6Answers = new String[] { "Constituie un depozit de săruri minerale.", "Reprezintă locuri de inserție pentru mușchi.", "Cutia toracică adăpostește inima și organe ale sistemului digestiv.", "Oasele reprezintă pârghii cu rol de mișcare." };
        static String[] Question7Answers = new String[] { "Coloana vertebrală cuprinde 5 regiuni, iar regiunea lombară e formată din 12 vertebre.", "Coloana vertebrală prezintă 4 curburi fiziologice: lordoză cervicală și lombară și cifoză toracală si sacrală.", "Este formată din 35 de vertebre articulate prin discurile intervertebrale.", "Regiunea sacrală este formată din 4-5 vertebre reduse." };
        static String[] Question8Answers = new String[] { "Tibia și fibula", "Ulna și cubitusul", "Peroneul și fibula", "Radius și ulna" };
        String[] rightAnswers = new String[] { "osul etmoid și osul frontal", "Perechile de coaste 1-7 se articulează direct cu sternul prin cartilajele proprii", "radius și humerus", "Creșterea în lungime caracterizează oasele lungi și scurte.", "Este format din manubriu, corp și apendice xifoid", "Tarsiene", "Cutia toracică adăpostește inima și organe ale sistemului digestiv.", "Coloana vertebrală prezintă 4 curburi fiziologice: lordoză cervicală și lombară și cifoză toracală si sacrală.", "Radius și ulna" };
        List<String[]> questionAnswers = new List<String[]>() { Question0Answers, Question1Answers, Question2Answers, Question3Answers, Question4Answers, Question5Answers, Question6Answers, Question7Answers, Question8Answers };
        static Label ExitApp = new Label();
        static Label BackApp = new Label();
        static Label Title = new Label();
        Label StartAnnouncement = new Label();
        Label Score = new Label();
        Label QuestionNumber = new Label();
        Label QuestionText = new Label();
        static Label ChoiceA = new Label();
        static Label ChoiceB = new Label();
        static Label ChoiceC = new Label();
        static Label ChoiceD = new Label();
        Label Time = new Label();
        Label[] choices = new Label[] { ChoiceA, ChoiceB, ChoiceC, ChoiceD };
        Label[] menu = new Label[] { Title, ExitApp, BackApp };
        static Button Next = new Button();
        static Button LockAnswer = new Button();
        static Button AnswerQuestion = new Button();
        Button[] commandButtons = new Button[] { AnswerQuestion, LockAnswer, Next };
        Button StartQuiz = new Button();
        Panel CloseBar = new Panel();
        int points = 1;
        int question_number = 1;
        int time_seconds = 600;
        #endregion Declarations

        void PlaceStart()
        {
            this.Controls.Add(StartAnnouncement);
            StartAnnouncement.AutoSize = true;
            StartAnnouncement.ForeColor = Color.White;
            StartAnnouncement.Text = "Durata testului: 10 minute" + Environment.NewLine + "Încercări maxime: 1" + Environment.NewLine + "Numărul întrebărilor: 9" + Environment.NewLine + "Nu vă puteți întoarce la întrebarea precedentă.";
            StartAnnouncement.TextAlign = ContentAlignment.MiddleCenter;
            StartAnnouncement.Font = new Font("Tahoma", 16);
            StartAnnouncement.Location = new Point(this.Size.Width / 2 - StartAnnouncement.Size.Width / 2, 150);

            this.Controls.Add(StartQuiz);
            StartQuiz.Size = new Size(100, 50);
            StartQuiz.FlatStyle = FlatStyle.Flat;
            StartQuiz.BackColor = Color.FromArgb(236, 179, 101);
            StartQuiz.Text = "Începeți testul";
            StartQuiz.Location = new Point(this.Size.Width / 2 - StartQuiz.Size.Width / 2, 300);
            StartQuiz.Font = new Font("Tahoma", 12);
            StartQuiz.Click += StartQuiz_Click;
        }

        private void StartQuiz_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(StartAnnouncement);
            this.Controls.Remove(StartQuiz);
            Place();
            for (int i = 0; i < QuestionList.Length; i++)
            {
                String question = QuestionList[i];
                nrQuestion.Add(question);
            }
            Randomizer();
            ceas.Enabled = true;
            BackApp.Enabled = false;
        }

        void PlaceBar()
        {
            this.Controls.Add(CloseBar);
            CloseBar.Size = new Size(this.Size.Width, 28);
            CloseBar.BackColor = Color.FromArgb(46, 76, 109);

            for (int i = 0; i < menu.Length; i++)
            {
                CloseBar.Controls.Add(menu[i]);
                menu[i].AutoSize = true;
                menu[i].Font = new Font("Tahoma", 16);
                menu[i].BackColor = Color.Transparent;
                menu[i].ForeColor = Color.White;
            }

            ExitApp.Text = "X";
            ExitApp.Location = new Point(820, 0);
            ExitApp.Click += ExitApp_Click;
            BackApp.Text = "<-";
            BackApp.Location = new Point(790, 0);
            BackApp.Click += BackApp_Click;
            Title.Text = "Modulul de testare";
            Title.Location = new Point((this.Size.Width - ExitApp.Size.Width - BackApp.Size.Width) / 2 - Title.Size.Width / 2, 0);
        }

        void Place()
        {
            this.Controls.Add(Time);
            Time.AutoSize = true;
            Time.ForeColor = Color.White;
            Time.Text = "Timp: " + (time_seconds / 60).ToString() + " minute";
            Time.Font = new Font("Tahoma", 14);
            Time.TextAlign = ContentAlignment.MiddleCenter;
            Time.Location = new Point(50, 40);

            this.Controls.Add(Score);
            Score.AutoSize = true;
            Score.Font = new Font("Tahoma", 14);
            Score.Text = "Număr de puncte: " + points.ToString();
            Score.ForeColor = Color.White;
            Score.Location = new Point(620, 40);

            this.Controls.Add(QuestionNumber);
            QuestionNumber.AutoSize = true;
            QuestionNumber.Font = new Font("Tahoma", 14);
            QuestionNumber.Text =  question_number.ToString() + ".";
            QuestionNumber.ForeColor = Color.White;
            QuestionNumber.Location = new Point(10, 100);

            this.Controls.Add(QuestionText);
            QuestionText.AutoSize = true;
            QuestionText.Font = new Font("Tahoma", 14);
            QuestionText.ForeColor = Color.White;
            QuestionText.Location = new Point(50, 100);

            for (int i = 0; i < commandButtons.Length; i++)
            {
                this.Controls.Add(commandButtons[i]);
                commandButtons[i].Size = new Size(110, 50);
                commandButtons[i].Font = new Font("Tahoma", 12);
                commandButtons[i].FlatStyle = FlatStyle.Flat;
                commandButtons[i].BackColor = Color.FromArgb(236, 179, 101);
                commandButtons[0].Location = new Point(50, 390);
                if (i > 0) commandButtons[i].Location = new Point(commandButtons[i - 1].Location.X + 315, 390);
                if (i == 0 || i == 2) commandButtons[i].Enabled = false;
            }

            AnswerQuestion.Text = "Răspunde la întrebare";
            AnswerQuestion.Click += AnswerQuestion_Click;
            LockAnswer.Text = "Blochează răspunsul";
            LockAnswer.Click += LockAnswer_Click;
            Next.Text = "Următoarea întrebare";
            Next.Click += Next_Click;

            for (int i = 0; i < choices.Length; i++)
            {
                this.Controls.Add(choices[i]);
                choices[i].Font = new Font("Tahoma", 12);
                choices[i].ForeColor = Color.White;
                choices[i].AutoSize = true;
                choices[0].Location = new Point(50, 180);
                if (i > 0) choices[i].Location = new Point(50, choices[i-1].Location.Y + 50);
            }

            ChoiceA.Click += ChoiceA_Click;
            ChoiceB.Click += ChoiceB_Click;
            ChoiceC.Click += ChoiceC_Click;
            ChoiceD.Click += ChoiceD_Click;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (nrQuestion.Count != 0)
            {
                Randomizer();
                LockAnswer.Enabled = true;
                AnswerQuestion.Enabled = false;
                Next.Enabled = false;
                for (int i = 0; i < choices.Length; i++) choices[i].ForeColor = Color.White;
                question_number++;
                QuestionNumber.Text = question_number.ToString() + "."; 
            }
            else
            {
                ceas.Enabled = false;
                if (points > 1 && points < 10) Score.Text = "Ai obținut " + points.ToString() + " puncte răspunzând corect la " + (points - 1).ToString() + " întrebări.";
                else if (points == 10) Score.Text = "Ai obținut " + points.ToString() + " puncte.";
                else if (points == 1) Score.Text = "Ai obținut " + points.ToString() + " punct din oficiu.";
                if (time_seconds == 0)
                {
                    Time.Text = "Timpul a expirat!";
                    Time.ForeColor = Color.White;
                }
                else if (600 - time_seconds < 60) Time.Text = "Ai rezolvat testul în " + ((600 - time_seconds) % 60).ToString() + " de secunde.";
                else if (600 - time_seconds == 60) Time.Text = "Ai rezolvat testul într-un minut";
                else if (600 - time_seconds > 60 && 600 - time_seconds < 120) Time.Text = "Ai rezolvat testul într-un minut si " + ((600 - time_seconds) % 60).ToString() + " secunde.";
                Score.Font = new Font("Tahoma", 16);
                Time.Font = new Font("Tahoma", 16);
                this.Controls.Remove(ChoiceA);
                this.Controls.Remove(ChoiceB);
                this.Controls.Remove(ChoiceC);
                this.Controls.Remove(ChoiceD);
                this.Controls.Remove(QuestionText);
                this.Controls.Remove(QuestionNumber);
                this.Controls.Remove(LockAnswer);
                this.Controls.Remove(AnswerQuestion);
                this.Controls.Remove(AnswerQuestion);
                this.Controls.Remove(Next);
                Time.Location = new Point((this.Size.Width / 2 - Time.Size.Width / 2) - 5, 150);
                Score.Location = new Point((this.Size.Width / 2 - Score.Size.Width / 2) - 5, 200);
                BackApp.Enabled = true;
            }
        }

        private void AnswerQuestion_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < choices.Length; i++)
            {
                for (int j = 0; j < rightAnswers.Length; j++)
                {
                    if (QuestionText.Text == QuestionList[j])
                    {
                        if ((choices[i].ForeColor == Color.FromArgb(236, 179, 101) || choices[i].ForeColor == Color.White) && !choices[i].Text.Contains(rightAnswers[j]))
                        {
                            choices[i].ForeColor = Color.IndianRed;
                            for (int k = 0; k < choices.Length; k++)
                            {
                                if (choices[k].ForeColor == Color.White && choices[k].Text.Contains(rightAnswers[j])) choices[k].ForeColor = Color.LightGreen;
                            }
                        }
                        if (choices[i].ForeColor == Color.FromArgb(236, 179, 101) && choices[i].Text.Contains(rightAnswers[j]))
                        {
                            choices[i].ForeColor = Color.LightGreen;
                            points += 1;
                            Score.Text = "Număr de puncte: " + points.ToString();
                        }
                    }
                }
            }
            Next.Enabled = true;
        }

        private void LockAnswer_Click(object sender, EventArgs e)
        {
            if (ChoiceA.ForeColor == Color.FromArgb(236, 179, 101) || ChoiceB.ForeColor == Color.FromArgb(236, 179, 101) || ChoiceC.ForeColor == Color.FromArgb(236, 179, 101) || ChoiceD.ForeColor == Color.FromArgb(236, 179, 101))
            {
                LockAnswer.Enabled = false;
                AnswerQuestion.Enabled = true;
            }
        }

        private void ChoiceD_Click(object sender, EventArgs e)
        {
            if (LockAnswer.Enabled == true)
            {
                for (int i = 0; i < choices.Length; i++)
                {
                    choices[3].ForeColor = Color.FromArgb(236, 179, 101);
                    if (i != 3) choices[i].ForeColor = Color.White;
                }
            }
        }

        private void ChoiceC_Click(object sender, EventArgs e)
        {
            if (LockAnswer.Enabled == true)
            {
                for (int i = 0; i < choices.Length; i++)
                {
                    choices[2].ForeColor = Color.FromArgb(236, 179, 101);
                    if (i != 2) choices[i].ForeColor = Color.White;
                } 
            }
        }

        private void ChoiceB_Click(object sender, EventArgs e)
        {
            if (LockAnswer.Enabled == true)
            {
                for (int i = 0; i < choices.Length; i++)
                {
                    choices[1].ForeColor = Color.FromArgb(236, 179, 101);
                    if (i != 1) choices[i].ForeColor = Color.White;
                } 
            }
        }

        private void ChoiceA_Click(object sender, EventArgs e)
        {
            if (LockAnswer.Enabled == true)
            {
                for (int i = 0; i < choices.Length; i++)
                {
                    choices[0].ForeColor = Color.FromArgb(236, 179, 101);
                    if (i != 0) choices[i].ForeColor = Color.White;
                }
            }
        }

        private void BackApp_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void ExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void Randomizer()
        {
            Random randomIntrebare = new Random();
            int nrIntrebare = randomIntrebare.Next(nrQuestion.Count);
            QuestionText.Text = nrQuestion[nrIntrebare];
            nrQuestion.Remove(nrQuestion[nrIntrebare]);
            Random randomRaspuns = new Random();
            for (int i = 0; i < choices.Length; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int start = 97;
                    if (nrIntrebare == j)
                    {
                        int nrRaspuns = randomRaspuns.Next(questionAnswers[nrIntrebare].Length);
                        choices[i].Text = ((char)(start + i)).ToString() + ") " + questionAnswers[nrIntrebare][nrRaspuns];
                        questionAnswers[nrIntrebare] = questionAnswers[nrIntrebare].Where(e => e != questionAnswers[nrIntrebare][nrRaspuns]).ToArray();
                    }
                }
            }
            questionAnswers.Remove(questionAnswers[nrIntrebare]);
        }

        private void ceas_Tick(object sender, EventArgs e)
        {
            time_seconds -= 1;
            Time.Text = "Timp: " + (time_seconds / 60).ToString() + " minute și " + (time_seconds % 60).ToString() + " secunde";
            if (time_seconds % 60 == 0) Time.Text = "Timp: " + (time_seconds / 60).ToString() + " minute";
            else if (time_seconds > 60 && time_seconds <= 120) Time.ForeColor = Color.Orange;
            else if (time_seconds > 30 && time_seconds <= 60) Time.ForeColor = Color.IndianRed;
            else if (time_seconds <= 30) Time.ForeColor = Color.Red;
            if (time_seconds == 0)
            {
                ceas.Enabled = false;
                if (points > 1) Score.Text = "Ai obtinut " + points.ToString() + " punct raspunzand corect la " + (points - 1).ToString() + " intrebari.";
                else if (points == 1) Score.Text = "Ai obtinut " + points.ToString() + " punct din oficiu.";
                Score.Font = new Font("Tahoma", 16);
                Time.Text = "Timpul a expirat!";
                Time.ForeColor = Color.White;
                Time.Font = new Font("Tahoma", 16);
                Time.Location = new Point((this.Size.Width / 2 - Time.Size.Width / 2) - 5, 150);
                Score.Location = new Point((this.Size.Width / 2 - Score.Size.Width / 2) - 5, 200);
                this.Controls.Remove(ChoiceA);
                this.Controls.Remove(ChoiceB);
                this.Controls.Remove(ChoiceC);
                this.Controls.Remove(ChoiceD);
                this.Controls.Remove(QuestionText);
                this.Controls.Remove(QuestionNumber);
                this.Controls.Remove(LockAnswer);
                this.Controls.Remove(AnswerQuestion);
                this.Controls.Remove(Next);
            }
        }
    }
}
