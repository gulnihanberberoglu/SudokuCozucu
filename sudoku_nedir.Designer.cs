namespace YazLabSudokuCozucu
{
    partial class sudoku_nedir
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
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Harlow Solid Italic", 14.25F, System.Drawing.FontStyle.Italic);
            this.label5.Location = new System.Drawing.Point(589, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(365, 61);
            this.label5.TabIndex = 7;
            this.label5.Text = "Sudoku Kuralları";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(531, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(696, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "1. Her satırda rakamlar sadece birer defa yer almalıdır.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(531, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(712, 32);
            this.label2.TabIndex = 9;
            this.label2.Text = "2. Her sutunda rakamlar sadece birer defa yer almalıdır.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(541, 377);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(713, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "3. Her bölgede rakamlar sadece birer defa yer almalıdır.";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::YazLabSudokuCozucu.Properties.Resources.question_300x3001;
            this.pictureBox2.Location = new System.Drawing.Point(3, 36);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(522, 564);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // sudoku_nedir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 641);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox2);
            this.Name = "sudoku_nedir";
            this.Text = "sudoku_nedir";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}