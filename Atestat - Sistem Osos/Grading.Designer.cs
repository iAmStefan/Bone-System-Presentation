
namespace Atestat___Sistem_Osos
{
    partial class Grading
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ceas = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ceas
            // 
            this.ceas.Interval = 80;
            this.ceas.Tick += new System.EventHandler(this.ceas_Tick);
            // 
            // Grading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 471);
            this.Name = "Grading";
            this.Text = "Modulul de testare";
            this.Load += new System.EventHandler(this.Grading_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer ceas;
    }
}