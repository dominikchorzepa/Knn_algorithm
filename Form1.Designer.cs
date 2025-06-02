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
            comboBoxMetryka = new ComboBox();
            labelWartoscParametruK = new Label();
            textBoxParametrK = new TextBox();
            labelMetryka = new Label();
            SuspendLayout();
            // 
            // WynikiAlgorytmu
            // 
            WynikiAlgorytmu.FormattingEnabled = true;
            WynikiAlgorytmu.Location = new Point(12, 74);
            WynikiAlgorytmu.Name = "WynikiAlgorytmu";
            WynikiAlgorytmu.Size = new Size(1099, 244);
            WynikiAlgorytmu.TabIndex = 0;
            // 
            // buttonGenerujProbki
            // 
            buttonGenerujProbki.Location = new Point(579, 20);
            buttonGenerujProbki.Name = "buttonGenerujProbki";
            buttonGenerujProbki.Size = new Size(100, 29);
            buttonGenerujProbki.TabIndex = 1;
            buttonGenerujProbki.Text = "Walidacja";
            buttonGenerujProbki.UseVisualStyleBackColor = true;
            buttonGenerujProbki.Click += buttonGenerujProbki_Click;
            // 
            // comboBoxMetryka
            // 
            comboBoxMetryka.FormattingEnabled = true;
            comboBoxMetryka.Items.AddRange(new object[] { "Euklidesowa", "Manhattan", "Czebyszewa", "Z logarytmem" });
            comboBoxMetryka.Location = new Point(387, 21);
            comboBoxMetryka.Name = "comboBoxMetryka";
            comboBoxMetryka.Size = new Size(151, 28);
            comboBoxMetryka.TabIndex = 2;
            comboBoxMetryka.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // labelWartoscParametruK
            // 
            labelWartoscParametruK.AutoSize = true;
            labelWartoscParametruK.Location = new Point(12, 24);
            labelWartoscParametruK.Name = "labelWartoscParametruK";
            labelWartoscParametruK.Size = new Size(149, 20);
            labelWartoscParametruK.TabIndex = 3;
            labelWartoscParametruK.Text = "Wartość parametru k:";
            labelWartoscParametruK.Click += label1_Click;
            // 
            // textBoxParametrK
            // 
            textBoxParametrK.Location = new Point(176, 22);
            textBoxParametrK.Name = "textBoxParametrK";
            textBoxParametrK.Size = new Size(101, 27);
            textBoxParametrK.TabIndex = 4;
            // 
            // labelMetryka
            // 
            labelMetryka.AutoSize = true;
            labelMetryka.Location = new Point(303, 25);
            labelMetryka.Name = "labelMetryka";
            labelMetryka.Size = new Size(65, 20);
            labelMetryka.TabIndex = 5;
            labelMetryka.Text = "Metryka:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1151, 450);
            Controls.Add(labelMetryka);
            Controls.Add(textBoxParametrK);
            Controls.Add(labelWartoscParametruK);
            Controls.Add(comboBoxMetryka);
            Controls.Add(buttonGenerujProbki);
            Controls.Add(WynikiAlgorytmu);
            Name = "Form1";
            Text = "Algorytm Knn";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox WynikiAlgorytmu;
        private Button buttonGenerujProbki;
        private ComboBox comboBoxMetryka;
        private Label labelWartoscParametruK;
        private TextBox textBoxParametrK;
        private Label labelMetryka;
    }
}
