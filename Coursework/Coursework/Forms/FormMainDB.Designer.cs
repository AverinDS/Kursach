﻿namespace Coursework
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.radioProduct = new System.Windows.Forms.RadioButton();
            this.radioProvider = new System.Windows.Forms.RadioButton();
            this.radioManager = new System.Windows.Forms.RadioButton();
            this.radioStorage = new System.Windows.Forms.RadioButton();
            this.radioSale = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(524, 36);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(193, 39);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Добавление";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(524, 81);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(193, 39);
            this.buttonEdit.TabIndex = 0;
            this.buttonEdit.Text = "Редактирование";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(524, 126);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(193, 39);
            this.buttonDelete.TabIndex = 0;
            this.buttonDelete.Text = "Удаление";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // radioProduct
            // 
            this.radioProduct.AutoSize = true;
            this.radioProduct.Location = new System.Drawing.Point(410, 68);
            this.radioProduct.Name = "radioProduct";
            this.radioProduct.Size = new System.Drawing.Size(56, 17);
            this.radioProduct.TabIndex = 1;
            this.radioProduct.Text = "Товар";
            this.radioProduct.UseVisualStyleBackColor = true;
            // 
            // radioProvider
            // 
            this.radioProvider.AutoSize = true;
            this.radioProvider.Location = new System.Drawing.Point(410, 91);
            this.radioProvider.Name = "radioProvider";
            this.radioProvider.Size = new System.Drawing.Size(83, 17);
            this.radioProvider.TabIndex = 1;
            this.radioProvider.Text = "Поставщик";
            this.radioProvider.UseVisualStyleBackColor = true;
            // 
            // radioManager
            // 
            this.radioManager.AutoSize = true;
            this.radioManager.Location = new System.Drawing.Point(410, 114);
            this.radioManager.Name = "radioManager";
            this.radioManager.Size = new System.Drawing.Size(78, 17);
            this.radioManager.TabIndex = 1;
            this.radioManager.Text = "Менеджер";
            this.radioManager.UseVisualStyleBackColor = true;
            // 
            // radioStorage
            // 
            this.radioStorage.AutoSize = true;
            this.radioStorage.Location = new System.Drawing.Point(410, 137);
            this.radioStorage.Name = "radioStorage";
            this.radioStorage.Size = new System.Drawing.Size(97, 17);
            this.radioStorage.TabIndex = 2;
            this.radioStorage.Text = "Склад-филиал";
            this.radioStorage.UseVisualStyleBackColor = true;
            // 
            // radioSale
            // 
            this.radioSale.AutoSize = true;
            this.radioSale.Checked = true;
            this.radioSale.Location = new System.Drawing.Point(410, 45);
            this.radioSale.Name = "radioSale";
            this.radioSale.Size = new System.Drawing.Size(71, 17);
            this.radioSale.TabIndex = 3;
            this.radioSale.TabStop = true;
            this.radioSale.Text = "Продажа";
            this.radioSale.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 338);
            this.Controls.Add(this.radioSale);
            this.Controls.Add(this.radioStorage);
            this.Controls.Add(this.radioProduct);
            this.Controls.Add(this.radioManager);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.radioProvider);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAdd);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.RadioButton radioProduct;
        private System.Windows.Forms.RadioButton radioProvider;
        private System.Windows.Forms.RadioButton radioManager;
        private System.Windows.Forms.RadioButton radioStorage;
        private System.Windows.Forms.RadioButton radioSale;
    }
}

