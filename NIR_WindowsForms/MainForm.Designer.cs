namespace NIR_WindowsForms
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sourceImageBox = new System.Windows.Forms.PictureBox();
            this.resultImageBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.stepOneButton = new System.Windows.Forms.Button();
            this.stepTwoButton = new System.Windows.Forms.Button();
            this.stepThreeButton = new System.Windows.Forms.Button();
            this.stepFourButton = new System.Windows.Forms.Button();
            this.menuBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // sourceImageBox
            // 
            this.sourceImageBox.ImageLocation = "";
            this.sourceImageBox.InitialImage = null;
            this.sourceImageBox.Location = new System.Drawing.Point(22, 58);
            this.sourceImageBox.Name = "sourceImageBox";
            this.sourceImageBox.Size = new System.Drawing.Size(256, 364);
            this.sourceImageBox.TabIndex = 0;
            this.sourceImageBox.TabStop = false;
            // 
            // resultImageBox
            // 
            this.resultImageBox.Location = new System.Drawing.Point(395, 58);
            this.resultImageBox.Name = "resultImageBox";
            this.resultImageBox.Size = new System.Drawing.Size(256, 364);
            this.resultImageBox.TabIndex = 1;
            this.resultImageBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(58, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Исходное изображение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(421, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Обработанное изобржение";
            // 
            // stepOneButton
            // 
            this.stepOneButton.Location = new System.Drawing.Point(32, 439);
            this.stepOneButton.Name = "stepOneButton";
            this.stepOneButton.Size = new System.Drawing.Size(101, 31);
            this.stepOneButton.TabIndex = 6;
            this.stepOneButton.Text = "Модуль(мал)";
            this.stepOneButton.UseVisualStyleBackColor = true;
            this.stepOneButton.Click += new System.EventHandler(this.stepOneButton_Click);
            // 
            // stepTwoButton
            // 
            this.stepTwoButton.Location = new System.Drawing.Point(32, 491);
            this.stepTwoButton.Name = "stepTwoButton";
            this.stepTwoButton.Size = new System.Drawing.Size(101, 31);
            this.stepTwoButton.TabIndex = 7;
            this.stepTwoButton.Text = "Напр. (мал)";
            this.stepTwoButton.UseVisualStyleBackColor = true;
            this.stepTwoButton.Click += new System.EventHandler(this.stepTwoButton_Click);
            // 
            // stepThreeButton
            // 
            this.stepThreeButton.Location = new System.Drawing.Point(164, 439);
            this.stepThreeButton.Name = "stepThreeButton";
            this.stepThreeButton.Size = new System.Drawing.Size(101, 31);
            this.stepThreeButton.TabIndex = 8;
            this.stepThreeButton.Text = "Модуль (бол)";
            this.stepThreeButton.UseVisualStyleBackColor = true;
            this.stepThreeButton.Click += new System.EventHandler(this.stepThreeButton_Click);
            // 
            // stepFourButton
            // 
            this.stepFourButton.Location = new System.Drawing.Point(164, 491);
            this.stepFourButton.Name = "stepFourButton";
            this.stepFourButton.Size = new System.Drawing.Size(101, 31);
            this.stepFourButton.TabIndex = 10;
            this.stepFourButton.Text = "Напр (бол)";
            this.stepFourButton.UseVisualStyleBackColor = true;
            this.stepFourButton.Click += new System.EventHandler(this.stepFourButton_Click);
            // 
            // menuBox
            // 
            this.menuBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuBox.FormattingEnabled = true;
            this.menuBox.Items.AddRange(new object[] {
            "Модуль (малый)",
            "Направление (малое)",
            "Модуль (большой)",
            "Направление (большое)",
            "Поле направлений",
            "Когеррентность"});
            this.menuBox.Location = new System.Drawing.Point(409, 467);
            this.menuBox.Name = "menuBox";
            this.menuBox.Size = new System.Drawing.Size(224, 28);
            this.menuBox.TabIndex = 12;
            this.menuBox.SelectedIndexChanged += new System.EventHandler(this.menuBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 539);
            this.Controls.Add(this.menuBox);
            this.Controls.Add(this.stepFourButton);
            this.Controls.Add(this.stepThreeButton);
            this.Controls.Add(this.stepTwoButton);
            this.Controls.Add(this.stepOneButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultImageBox);
            this.Controls.Add(this.sourceImageBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Градиент и его направление";
            ((System.ComponentModel.ISupportInitialize)(this.sourceImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sourceImageBox;
        private System.Windows.Forms.PictureBox resultImageBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button stepOneButton;
        private System.Windows.Forms.Button stepTwoButton;
        private System.Windows.Forms.Button stepThreeButton;
        private System.Windows.Forms.Button stepFourButton;
        private System.Windows.Forms.ComboBox menuBox;
    }
}

