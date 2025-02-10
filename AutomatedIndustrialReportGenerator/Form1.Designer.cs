namespace AutomatedIndustrialReportGenerator
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonPDF = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.dataGridViewMachineData = new System.Windows.Forms.DataGridView();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEmail = new System.Windows.Forms.Button();
            this.comboBoxSchedule = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxEnableAutomation = new System.Windows.Forms.CheckBox();
            this.timerReport = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMachineData)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPDF
            // 
            this.buttonPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPDF.Location = new System.Drawing.Point(12, 12);
            this.buttonPDF.Name = "buttonPDF";
            this.buttonPDF.Size = new System.Drawing.Size(149, 31);
            this.buttonPDF.TabIndex = 0;
            this.buttonPDF.Text = "Generate PDF";
            this.buttonPDF.UseVisualStyleBackColor = true;
            this.buttonPDF.Click += new System.EventHandler(this.buttonPDF_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(245, 152);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(113, 28);
            this.comboBox1.TabIndex = 1;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(16, 72);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(229, 20);
            this.textBoxEmail.TabIndex = 2;
            // 
            // dataGridViewMachineData
            // 
            this.dataGridViewMachineData.AllowUserToAddRows = false;
            this.dataGridViewMachineData.AllowUserToDeleteRows = false;
            this.dataGridViewMachineData.AllowUserToResizeColumns = false;
            this.dataGridViewMachineData.AllowUserToResizeRows = false;
            this.dataGridViewMachineData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMachineData.Location = new System.Drawing.Point(12, 149);
            this.dataGridViewMachineData.Name = "dataGridViewMachineData";
            this.dataGridViewMachineData.Size = new System.Drawing.Size(454, 284);
            this.dataGridViewMachineData.TabIndex = 3;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoad.Location = new System.Drawing.Point(322, 12);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(144, 131);
            this.buttonLoad.TabIndex = 4;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonExcel
            // 
            this.buttonExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExcel.Location = new System.Drawing.Point(167, 12);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(149, 31);
            this.buttonExcel.TabIndex = 5;
            this.buttonExcel.Text = "Generate Excel";
            this.buttonExcel.UseVisualStyleBackColor = true;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Email:";
            // 
            // buttonEmail
            // 
            this.buttonEmail.Location = new System.Drawing.Point(251, 70);
            this.buttonEmail.Name = "buttonEmail";
            this.buttonEmail.Size = new System.Drawing.Size(65, 23);
            this.buttonEmail.TabIndex = 7;
            this.buttonEmail.Text = "Send";
            this.buttonEmail.UseVisualStyleBackColor = true;
            this.buttonEmail.Click += new System.EventHandler(this.buttonEmail_Click);
            // 
            // comboBoxSchedule
            // 
            this.comboBoxSchedule.FormattingEnabled = true;
            this.comboBoxSchedule.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly",
            "Minute"});
            this.comboBoxSchedule.Location = new System.Drawing.Point(98, 99);
            this.comboBoxSchedule.Name = "comboBoxSchedule";
            this.comboBoxSchedule.Size = new System.Drawing.Size(147, 21);
            this.comboBoxSchedule.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Schedule:";
            // 
            // checkBoxEnableAutomation
            // 
            this.checkBoxEnableAutomation.AutoSize = true;
            this.checkBoxEnableAutomation.Location = new System.Drawing.Point(111, 126);
            this.checkBoxEnableAutomation.Name = "checkBoxEnableAutomation";
            this.checkBoxEnableAutomation.Size = new System.Drawing.Size(124, 17);
            this.checkBoxEnableAutomation.TabIndex = 10;
            this.checkBoxEnableAutomation.Text = "Enable Auto Reports";
            this.checkBoxEnableAutomation.UseVisualStyleBackColor = true;
            this.checkBoxEnableAutomation.CheckedChanged += new System.EventHandler(this.checkBoxEnableAutomation_CheckedChanged);
            // 
            // timerReport
            // 
            this.timerReport.Interval = 60000;
            this.timerReport.Tick += new System.EventHandler(this.timerReport_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 445);
            this.Controls.Add(this.checkBoxEnableAutomation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxSchedule);
            this.Controls.Add(this.buttonEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.dataGridViewMachineData);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonPDF);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Automated Industrial Report Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMachineData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPDF;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.DataGridView dataGridViewMachineData;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEmail;
        private System.Windows.Forms.ComboBox comboBoxSchedule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxEnableAutomation;
        private System.Windows.Forms.Timer timerReport;
    }
}

