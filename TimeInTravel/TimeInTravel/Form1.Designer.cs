namespace TimeInTravel
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
            this.cb_from_day = new System.Windows.Forms.ComboBox();
            this.cb_from_month = new System.Windows.Forms.ComboBox();
            this.cb_from_year = new System.Windows.Forms.ComboBox();
            this.cb_from_hour = new System.Windows.Forms.ComboBox();
            this.cb_from_min = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_to_min = new System.Windows.Forms.ComboBox();
            this.cb_to_hour = new System.Windows.Forms.ComboBox();
            this.cb_to_year = new System.Windows.Forms.ComboBox();
            this.cb_to_month = new System.Windows.Forms.ComboBox();
            this.cb_to_day = new System.Windows.Forms.ComboBox();
            this.Start = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_from_day
            // 
            this.cb_from_day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_from_day.FormattingEnabled = true;
            this.cb_from_day.Location = new System.Drawing.Point(62, 79);
            this.cb_from_day.Name = "cb_from_day";
            this.cb_from_day.Size = new System.Drawing.Size(45, 24);
            this.cb_from_day.TabIndex = 0;
            // 
            // cb_from_month
            // 
            this.cb_from_month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_from_month.FormattingEnabled = true;
            this.cb_from_month.Location = new System.Drawing.Point(129, 79);
            this.cb_from_month.Name = "cb_from_month";
            this.cb_from_month.Size = new System.Drawing.Size(121, 24);
            this.cb_from_month.TabIndex = 1;
            this.cb_from_month.Tag = "From";
            this.cb_from_month.SelectedIndexChanged += new System.EventHandler(this.cb_to_year_SelectedIndexChanged);
            // 
            // cb_from_year
            // 
            this.cb_from_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_from_year.FormattingEnabled = true;
            this.cb_from_year.Location = new System.Drawing.Point(273, 79);
            this.cb_from_year.Name = "cb_from_year";
            this.cb_from_year.Size = new System.Drawing.Size(71, 24);
            this.cb_from_year.TabIndex = 2;
            this.cb_from_year.Tag = "From";
            this.cb_from_year.SelectedIndexChanged += new System.EventHandler(this.cb_to_year_SelectedIndexChanged);
            // 
            // cb_from_hour
            // 
            this.cb_from_hour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_from_hour.FormattingEnabled = true;
            this.cb_from_hour.Location = new System.Drawing.Point(411, 79);
            this.cb_from_hour.Name = "cb_from_hour";
            this.cb_from_hour.Size = new System.Drawing.Size(64, 24);
            this.cb_from_hour.TabIndex = 3;
            // 
            // cb_from_min
            // 
            this.cb_from_min.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_from_min.FormattingEnabled = true;
            this.cb_from_min.Location = new System.Drawing.Point(499, 79);
            this.cb_from_min.Name = "cb_from_min";
            this.cb_from_min.Size = new System.Drawing.Size(64, 24);
            this.cb_from_min.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(481, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(481, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = ":";
            // 
            // cb_to_min
            // 
            this.cb_to_min.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_to_min.FormattingEnabled = true;
            this.cb_to_min.Location = new System.Drawing.Point(499, 177);
            this.cb_to_min.Name = "cb_to_min";
            this.cb_to_min.Size = new System.Drawing.Size(64, 24);
            this.cb_to_min.TabIndex = 10;
            // 
            // cb_to_hour
            // 
            this.cb_to_hour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_to_hour.FormattingEnabled = true;
            this.cb_to_hour.Location = new System.Drawing.Point(411, 177);
            this.cb_to_hour.Name = "cb_to_hour";
            this.cb_to_hour.Size = new System.Drawing.Size(64, 24);
            this.cb_to_hour.TabIndex = 9;
            // 
            // cb_to_year
            // 
            this.cb_to_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_to_year.FormattingEnabled = true;
            this.cb_to_year.Location = new System.Drawing.Point(273, 177);
            this.cb_to_year.Name = "cb_to_year";
            this.cb_to_year.Size = new System.Drawing.Size(71, 24);
            this.cb_to_year.TabIndex = 8;
            this.cb_to_year.Tag = "To";
            this.cb_to_year.SelectedIndexChanged += new System.EventHandler(this.cb_to_year_SelectedIndexChanged);
            // 
            // cb_to_month
            // 
            this.cb_to_month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_to_month.FormattingEnabled = true;
            this.cb_to_month.Location = new System.Drawing.Point(129, 177);
            this.cb_to_month.Name = "cb_to_month";
            this.cb_to_month.Size = new System.Drawing.Size(121, 24);
            this.cb_to_month.TabIndex = 7;
            this.cb_to_month.Tag = "To";
            this.cb_to_month.SelectedIndexChanged += new System.EventHandler(this.cb_to_year_SelectedIndexChanged);
            // 
            // cb_to_day
            // 
            this.cb_to_day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_to_day.FormattingEnabled = true;
            this.cb_to_day.Location = new System.Drawing.Point(62, 177);
            this.cb_to_day.Name = "cb_to_day";
            this.cb_to_day.Size = new System.Drawing.Size(45, 24);
            this.cb_to_day.TabIndex = 6;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(62, 256);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(112, 37);
            this.Start.TabIndex = 12;
            this.Start.Tag = "j";
            this.Start.Text = "Вычислить";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Отправление";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Прибытие";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 373);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_to_min);
            this.Controls.Add(this.cb_to_hour);
            this.Controls.Add(this.cb_to_year);
            this.Controls.Add(this.cb_to_month);
            this.Controls.Add(this.cb_to_day);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_from_min);
            this.Controls.Add(this.cb_from_hour);
            this.Controls.Add(this.cb_from_year);
            this.Controls.Add(this.cb_from_month);
            this.Controls.Add(this.cb_from_day);
            this.MaximumSize = new System.Drawing.Size(830, 420);
            this.MinimumSize = new System.Drawing.Size(820, 400);
            this.Name = "Form1";
            this.Text = "Время в пути";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_from_day;
        private System.Windows.Forms.ComboBox cb_from_month;
        private System.Windows.Forms.ComboBox cb_from_year;
        private System.Windows.Forms.ComboBox cb_from_hour;
        private System.Windows.Forms.ComboBox cb_from_min;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_to_min;
        private System.Windows.Forms.ComboBox cb_to_hour;
        private System.Windows.Forms.ComboBox cb_to_year;
        private System.Windows.Forms.ComboBox cb_to_month;
        private System.Windows.Forms.ComboBox cb_to_day;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

