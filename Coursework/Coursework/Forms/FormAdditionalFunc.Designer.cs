namespace Coursework.Forms
{
    partial class FormAdditionalFunc
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.StatusOfNetwork = new System.Windows.Forms.Label();
            this.StatusOfUpdatingStandarts = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RedistributionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Работа с БД";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(126, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 37);
            this.button2.TabIndex = 1;
            this.button2.Text = "Обновить курс валют";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(277, 102);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 37);
            this.button3.TabIndex = 2;
            this.button3.Text = "Создание отчёта";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(423, 102);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 37);
            this.button4.TabIndex = 3;
            this.button4.Text = "Обновить прайсы";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // StatusOfNetwork
            // 
            this.StatusOfNetwork.AutoSize = true;
            this.StatusOfNetwork.Location = new System.Drawing.Point(12, 9);
            this.StatusOfNetwork.Name = "StatusOfNetwork";
            this.StatusOfNetwork.Size = new System.Drawing.Size(105, 13);
            this.StatusOfNetwork.TabIndex = 4;
            this.StatusOfNetwork.Text = "Состояние сети: ??";
            // 
            // StatusOfUpdatingStandarts
            // 
            this.StatusOfUpdatingStandarts.AutoSize = true;
            this.StatusOfUpdatingStandarts.Location = new System.Drawing.Point(12, 34);
            this.StatusOfUpdatingStandarts.Name = "StatusOfUpdatingStandarts";
            this.StatusOfUpdatingStandarts.Size = new System.Drawing.Size(68, 13);
            this.StatusOfUpdatingStandarts.TabIndex = 5;
            this.StatusOfUpdatingStandarts.Text = "Курс валют:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Последнее перераспределение товаров: ??";
            // 
            // RedistributionButton
            // 
            this.RedistributionButton.Location = new System.Drawing.Point(557, 102);
            this.RedistributionButton.Name = "RedistributionButton";
            this.RedistributionButton.Size = new System.Drawing.Size(121, 37);
            this.RedistributionButton.TabIndex = 7;
            this.RedistributionButton.Text = "Перераспределение";
            this.RedistributionButton.UseVisualStyleBackColor = true;
            this.RedistributionButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // FormAdditionalFunc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 149);
            this.Controls.Add(this.RedistributionButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StatusOfUpdatingStandarts);
            this.Controls.Add(this.StatusOfNetwork);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FormAdditionalFunc";
            this.Text = "FormAdditionalFunc";
            this.Load += new System.EventHandler(this.FormAdditionalFunc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label StatusOfNetwork;
        private System.Windows.Forms.Label StatusOfUpdatingStandarts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RedistributionButton;
    }
}