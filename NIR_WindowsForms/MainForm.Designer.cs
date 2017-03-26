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
        private System.Windows.Forms.ComboBox menuBox;
    }
}

