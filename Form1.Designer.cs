namespace Knn_algorithm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            WynikiAlgorytmu = new ListBox();
            buttonGenerujProbki = new Button();
            SuspendLayout();
            // 
            // WynikiAlgorytmu
            // 
            WynikiAlgorytmu.FormattingEnabled = true;
            WynikiAlgorytmu.Location = new Point(40, 156);
            WynikiAlgorytmu.Name = "WynikiAlgorytmu";
            WynikiAlgorytmu.Size = new Size(721, 244);
            WynikiAlgorytmu.TabIndex = 0;
            // 
            // buttonGenerujProbki
            // 
            buttonGenerujProbki.Location = new Point(40, 101);
            buttonGenerujProbki.Name = "buttonGenerujProbki";
            buttonGenerujProbki.Size = new Size(121, 29);
            buttonGenerujProbki.TabIndex = 1;
            buttonGenerujProbki.Text = "Generuj próbki";
            buttonGenerujProbki.UseVisualStyleBackColor = true;
            buttonGenerujProbki.Click += buttonGenerujProbki_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonGenerujProbki);
            Controls.Add(WynikiAlgorytmu);
            Name = "Form1";
            Text = "Algorytm Knn";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox WynikiAlgorytmu;
        private Button buttonGenerujProbki;
    }
}
