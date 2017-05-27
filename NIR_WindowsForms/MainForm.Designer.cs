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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuBox = new System.Windows.Forms.ComboBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox4 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox5 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox6 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox7 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox8 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox9 = new System.Windows.Forms.MaskedTextBox();
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.blurButton = new System.Windows.Forms.Button();
            this.gradAreaUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dencityUpDown = new System.Windows.Forms.NumericUpDown();
            this.histogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.histButton = new System.Windows.Forms.Button();
            this.resultImageBox = new System.Windows.Forms.PictureBox();
            this.sourceImageBox = new System.Windows.Forms.PictureBox();
            this.skeletonButton = new System.Windows.Forms.Button();
            this.coordLabel = new System.Windows.Forms.Label();
            this.brightLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gradAreaUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dencityUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(50, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Исходное изображение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(426, 9);
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
            "Когеррентность",
            "Когеррентность (минимум)",
            "Когеррентность (максимум)",
            "Плотность линий",
            "Плотность линий (средняя)",
            "Волосы Вероники",
            "Качество 2",
            "Размытие Вероники",
            "Качество 3",
            "Эрозия + Дилатация",
            "Габор(сглаживание)",
            "Габор(дифф.)"});
            this.menuBox.Location = new System.Drawing.Point(402, 467);
            this.menuBox.Name = "menuBox";
            this.menuBox.Size = new System.Drawing.Size(256, 28);
            this.menuBox.TabIndex = 12;
            this.menuBox.SelectedIndexChanged += new System.EventHandler(this.menuBox_SelectedIndexChanged);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(18, 444);
            this.maskedTextBox1.Mask = "0";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(36, 20);
            this.maskedTextBox1.TabIndex = 13;
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(68, 444);
            this.maskedTextBox2.Mask = "0";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(36, 20);
            this.maskedTextBox2.TabIndex = 14;
            // 
            // maskedTextBox3
            // 
            this.maskedTextBox3.Location = new System.Drawing.Point(120, 444);
            this.maskedTextBox3.Mask = "0";
            this.maskedTextBox3.Name = "maskedTextBox3";
            this.maskedTextBox3.Size = new System.Drawing.Size(36, 20);
            this.maskedTextBox3.TabIndex = 15;
            // 
            // maskedTextBox4
            // 
            this.maskedTextBox4.Location = new System.Drawing.Point(18, 475);
            this.maskedTextBox4.Mask = "0";
            this.maskedTextBox4.Name = "maskedTextBox4";
            this.maskedTextBox4.Size = new System.Drawing.Size(36, 20);
            this.maskedTextBox4.TabIndex = 16;
            // 
            // maskedTextBox5
            // 
            this.maskedTextBox5.Location = new System.Drawing.Point(68, 475);
            this.maskedTextBox5.Mask = "0";
            this.maskedTextBox5.Name = "maskedTextBox5";
            this.maskedTextBox5.Size = new System.Drawing.Size(36, 20);
            this.maskedTextBox5.TabIndex = 17;
            // 
            // maskedTextBox6
            // 
            this.maskedTextBox6.Location = new System.Drawing.Point(120, 475);
            this.maskedTextBox6.Mask = "0";
            this.maskedTextBox6.Name = "maskedTextBox6";
            this.maskedTextBox6.Size = new System.Drawing.Size(36, 20);
            this.maskedTextBox6.TabIndex = 18;
            // 
            // maskedTextBox7
            // 
            this.maskedTextBox7.Location = new System.Drawing.Point(18, 507);
            this.maskedTextBox7.Mask = "0";
            this.maskedTextBox7.Name = "maskedTextBox7";
            this.maskedTextBox7.Size = new System.Drawing.Size(36, 20);
            this.maskedTextBox7.TabIndex = 19;
            // 
            // maskedTextBox8
            // 
            this.maskedTextBox8.Location = new System.Drawing.Point(68, 507);
            this.maskedTextBox8.Mask = "0";
            this.maskedTextBox8.Name = "maskedTextBox8";
            this.maskedTextBox8.Size = new System.Drawing.Size(36, 20);
            this.maskedTextBox8.TabIndex = 20;
            // 
            // maskedTextBox9
            // 
            this.maskedTextBox9.Location = new System.Drawing.Point(120, 507);
            this.maskedTextBox9.Mask = "0";
            this.maskedTextBox9.Name = "maskedTextBox9";
            this.maskedTextBox9.Size = new System.Drawing.Size(36, 20);
            this.maskedTextBox9.TabIndex = 21;
            // 
            // filterComboBox
            // 
            this.filterComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filterComboBox.FormattingEnabled = true;
            this.filterComboBox.Items.AddRange(new object[] {
            "Без размытия",
            "Равномерный",
            "Взвешенный"});
            this.filterComboBox.Location = new System.Drawing.Point(181, 443);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(111, 26);
            this.filterComboBox.TabIndex = 16;
            this.filterComboBox.SelectedIndexChanged += new System.EventHandler(this.filterComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(99, 415);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = "Размытие";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(467, 430);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 18);
            this.label4.TabIndex = 23;
            this.label4.Text = "Выбор операции";
            // 
            // blurButton
            // 
            this.blurButton.Location = new System.Drawing.Point(180, 476);
            this.blurButton.Name = "blurButton";
            this.blurButton.Size = new System.Drawing.Size(109, 23);
            this.blurButton.TabIndex = 24;
            this.blurButton.Text = "Размыть";
            this.blurButton.UseVisualStyleBackColor = true;
            this.blurButton.Click += new System.EventHandler(this.blurButton_Click);
            // 
            // gradAreaUpDown
            // 
            this.gradAreaUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.gradAreaUpDown.Location = new System.Drawing.Point(301, 97);
            this.gradAreaUpDown.Maximum = new decimal(new int[] {
            27,
            0,
            0,
            0});
            this.gradAreaUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.gradAreaUpDown.Name = "gradAreaUpDown";
            this.gradAreaUpDown.Size = new System.Drawing.Size(86, 20);
            this.gradAreaUpDown.TabIndex = 25;
            this.gradAreaUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.gradAreaUpDown.ValueChanged += new System.EventHandler(this.gradAreaUpDown_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(308, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 18);
            this.label5.TabIndex = 26;
            this.label5.Text = "Апертура";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(299, 231);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(91, 23);
            this.clearButton.TabIndex = 27;
            this.clearButton.Text = "Сбросить всё";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(304, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 18);
            this.label6.TabIndex = 28;
            this.label6.Text = "градиента";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(307, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 18);
            this.label7.TabIndex = 31;
            this.label7.Text = "плотности";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(311, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 18);
            this.label8.TabIndex = 30;
            this.label8.Text = "Апертура";
            // 
            // dencityUpDown
            // 
            this.dencityUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.dencityUpDown.Location = new System.Drawing.Point(304, 185);
            this.dencityUpDown.Maximum = new decimal(new int[] {
            34,
            0,
            0,
            0});
            this.dencityUpDown.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.dencityUpDown.Name = "dencityUpDown";
            this.dencityUpDown.Size = new System.Drawing.Size(86, 20);
            this.dencityUpDown.TabIndex = 29;
            this.dencityUpDown.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.dencityUpDown.ValueChanged += new System.EventHandler(this.dencityUpDown_ValueChanged);
            // 
            // histogram
            // 
            chartArea1.BorderWidth = 0;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 96F;
            chartArea1.Position.Width = 100F;
            chartArea1.Position.Y = 3F;
            this.histogram.ChartAreas.Add(chartArea1);
            this.histogram.Location = new System.Drawing.Point(693, 44);
            this.histogram.Name = "histogram";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.Name = "Bright";
            this.histogram.Series.Add(series1);
            this.histogram.Size = new System.Drawing.Size(399, 364);
            this.histogram.TabIndex = 32;
            this.histogram.Text = "histogram";
            title1.DockingOffset = -2;
            title1.Name = "Title1";
            title1.Text = "Гистограмма";
            title2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            title2.DockingOffset = -2;
            title2.Name = "Title2";
            title2.Text = "Number of pixels";
            title3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title3.DockingOffset = 3;
            title3.Name = "Title3";
            title3.Text = "Brightness";
            this.histogram.Titles.Add(title1);
            this.histogram.Titles.Add(title2);
            this.histogram.Titles.Add(title3);
            // 
            // histButton
            // 
            this.histButton.Location = new System.Drawing.Point(831, 442);
            this.histButton.Name = "histButton";
            this.histButton.Size = new System.Drawing.Size(144, 23);
            this.histButton.TabIndex = 33;
            this.histButton.Text = "Построить гистограмму";
            this.histButton.UseVisualStyleBackColor = true;
            this.histButton.Click += new System.EventHandler(this.histButton_Click);
            // 
            // resultImageBox
            // 
            this.resultImageBox.Location = new System.Drawing.Point(399, 44);
            this.resultImageBox.Name = "resultImageBox";
            this.resultImageBox.Size = new System.Drawing.Size(275, 364);
            this.resultImageBox.TabIndex = 1;
            this.resultImageBox.TabStop = false;
            this.resultImageBox.Click += new System.EventHandler(this.resultImageBox_Click);
            // 
            // sourceImageBox
            // 
            this.sourceImageBox.ImageLocation = "";
            this.sourceImageBox.InitialImage = null;
            this.sourceImageBox.Location = new System.Drawing.Point(16, 40);
            this.sourceImageBox.Name = "sourceImageBox";
            this.sourceImageBox.Size = new System.Drawing.Size(275, 364);
            this.sourceImageBox.TabIndex = 0;
            this.sourceImageBox.TabStop = false;
            // 
            // skeletonButton
            // 
            this.skeletonButton.Location = new System.Drawing.Point(831, 492);
            this.skeletonButton.Name = "skeletonButton";
            this.skeletonButton.Size = new System.Drawing.Size(144, 23);
            this.skeletonButton.TabIndex = 34;
            this.skeletonButton.Text = "Построить скелет";
            this.skeletonButton.UseVisualStyleBackColor = true;
            this.skeletonButton.Click += new System.EventHandler(this.skeletonButton_Click);
            // 
            // coordLabel
            // 
            this.coordLabel.AutoSize = true;
            this.coordLabel.Location = new System.Drawing.Point(399, 511);
            this.coordLabel.Name = "coordLabel";
            this.coordLabel.Size = new System.Drawing.Size(72, 13);
            this.coordLabel.TabIndex = 35;
            this.coordLabel.Text = "Координаты:";
            // 
            // brightLabel
            // 
            this.brightLabel.AutoSize = true;
            this.brightLabel.Location = new System.Drawing.Point(569, 511);
            this.brightLabel.Name = "brightLabel";
            this.brightLabel.Size = new System.Drawing.Size(53, 13);
            this.brightLabel.TabIndex = 36;
            this.brightLabel.Text = "Яркость:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 539);
            this.Controls.Add(this.brightLabel);
            this.Controls.Add(this.coordLabel);
            this.Controls.Add(this.skeletonButton);
            this.Controls.Add(this.histButton);
            this.Controls.Add(this.histogram);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dencityUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gradAreaUpDown);
            this.Controls.Add(this.blurButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.filterComboBox);
            this.Controls.Add(this.maskedTextBox9);
            this.Controls.Add(this.maskedTextBox8);
            this.Controls.Add(this.maskedTextBox7);
            this.Controls.Add(this.maskedTextBox6);
            this.Controls.Add(this.maskedTextBox5);
            this.Controls.Add(this.maskedTextBox4);
            this.Controls.Add(this.maskedTextBox3);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.menuBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultImageBox);
            this.Controls.Add(this.sourceImageBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Демонстрация этапов";
            ((System.ComponentModel.ISupportInitialize)(this.gradAreaUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dencityUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sourceImageBox;
        private System.Windows.Forms.PictureBox resultImageBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox menuBox;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox3;
        private System.Windows.Forms.MaskedTextBox maskedTextBox4;
        private System.Windows.Forms.MaskedTextBox maskedTextBox5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox6;
        private System.Windows.Forms.MaskedTextBox maskedTextBox7;
        private System.Windows.Forms.MaskedTextBox maskedTextBox8;
        private System.Windows.Forms.MaskedTextBox maskedTextBox9;
        private System.Windows.Forms.ComboBox filterComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button blurButton;
        private System.Windows.Forms.NumericUpDown gradAreaUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown dencityUpDown;
        private System.Windows.Forms.DataVisualization.Charting.Chart histogram;
        private System.Windows.Forms.Button histButton;
        private System.Windows.Forms.Button skeletonButton;
        private System.Windows.Forms.Label coordLabel;
        private System.Windows.Forms.Label brightLabel;
    }
}

