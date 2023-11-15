namespace LaboratoryWorkNo15
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
            this.TestingRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StartWorkingButton = new System.Windows.Forms.Button();
            this.StopWorkingButton = new System.Windows.Forms.Button();
            this.LineCountLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TestingRichTextBox
            // 
            this.TestingRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestingRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TestingRichTextBox.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TestingRichTextBox.Location = new System.Drawing.Point(2, 2);
            this.TestingRichTextBox.Name = "TestingRichTextBox";
            this.TestingRichTextBox.Size = new System.Drawing.Size(362, 109);
            this.TestingRichTextBox.TabIndex = 0;
            this.TestingRichTextBox.Text = "";
            this.TestingRichTextBox.TextChanged += new System.EventHandler(this.TestingRichTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Тестируемый RichTextBox";
            // 
            // StartWorkingButton
            // 
            this.StartWorkingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartWorkingButton.Font = new System.Drawing.Font("Inter Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartWorkingButton.Location = new System.Drawing.Point(405, 43);
            this.StartWorkingButton.Name = "StartWorkingButton";
            this.StartWorkingButton.Size = new System.Drawing.Size(75, 44);
            this.StartWorkingButton.TabIndex = 2;
            this.StartWorkingButton.Text = "Старт";
            this.StartWorkingButton.UseVisualStyleBackColor = true;
            this.StartWorkingButton.Click += new System.EventHandler(this.StartWorkingButton_Click);
            // 
            // StopWorkingButton
            // 
            this.StopWorkingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StopWorkingButton.Font = new System.Drawing.Font("Inter Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StopWorkingButton.Location = new System.Drawing.Point(405, 95);
            this.StopWorkingButton.Name = "StopWorkingButton";
            this.StopWorkingButton.Size = new System.Drawing.Size(75, 44);
            this.StopWorkingButton.TabIndex = 3;
            this.StopWorkingButton.Text = "Стоп";
            this.StopWorkingButton.UseVisualStyleBackColor = true;
            this.StopWorkingButton.Click += new System.EventHandler(this.StopWorkingButton_Click);
            // 
            // LineCountLabel
            // 
            this.LineCountLabel.AutoSize = true;
            this.LineCountLabel.Font = new System.Drawing.Font("Inter Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LineCountLabel.Location = new System.Drawing.Point(314, 21);
            this.LineCountLabel.Name = "LineCountLabel";
            this.LineCountLabel.Size = new System.Drawing.Size(70, 16);
            this.LineCountLabel.TabIndex = 4;
            this.LineCountLabel.Text = "Строк: 0";
            this.LineCountLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.TestingRichTextBox);
            this.panel1.Location = new System.Drawing.Point(17, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(366, 113);
            this.panel1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 188);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LineCountLabel);
            this.Controls.Add(this.StopWorkingButton);
            this.Controls.Add(this.StartWorkingButton);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Шумилов Лев, РИС-20-1б, лабораторная работа №15";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox TestingRichTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StartWorkingButton;
        private System.Windows.Forms.Button StopWorkingButton;
        private System.Windows.Forms.Label LineCountLabel;
        private System.Windows.Forms.Panel panel1;
    }
}

