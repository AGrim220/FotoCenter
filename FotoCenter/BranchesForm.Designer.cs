namespace FotoCenter
{
    partial class BranchesForm
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
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.butt2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewResults
            // 
            this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResults.Location = new System.Drawing.Point(46, 12);
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.RowHeadersWidth = 62;
            this.dataGridViewResults.RowTemplate.Height = 28;
            this.dataGridViewResults.Size = new System.Drawing.Size(712, 264);
            this.dataGridViewResults.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 109);
            this.button1.TabIndex = 1;
            this.button1.Text = "Получить список филиалов";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // butt2
            // 
            this.butt2.Location = new System.Drawing.Point(682, 387);
            this.butt2.Name = "butt2";
            this.butt2.Size = new System.Drawing.Size(106, 51);
            this.butt2.TabIndex = 7;
            this.butt2.Text = "Вернуться";
            this.butt2.UseVisualStyleBackColor = true;
            this.butt2.Click += new System.EventHandler(this.butt2_Click);
            // 
            // BranchesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.butt2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewResults);
            this.Name = "BranchesForm";
            this.Text = "BranchesForm";
            this.Load += new System.EventHandler(this.BranchesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button butt2;
    }
}