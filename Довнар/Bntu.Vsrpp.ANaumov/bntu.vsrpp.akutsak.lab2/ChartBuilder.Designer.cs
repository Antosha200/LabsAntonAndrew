
namespace Bntu.Vsrpp.Akutsak.Lab2
{
    partial class ChartBuilder
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
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.cbCurrencies = new System.Windows.Forms.ComboBox();
            this.btnPlot = new System.Windows.Forms.Button();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblAvg = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStart.Location = new System.Drawing.Point(302, 418);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(163, 20);
            this.dateTimePickerStart.TabIndex = 0;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(474, 418);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(156, 20);
            this.dateTimePickerEnd.TabIndex = 1;
            // 
            // cbCurrencies
            // 
            this.cbCurrencies.FormattingEnabled = true;
            this.cbCurrencies.Location = new System.Drawing.Point(34, 417);
            this.cbCurrencies.Name = "cbCurrencies";
            this.cbCurrencies.Size = new System.Drawing.Size(262, 21);
            this.cbCurrencies.TabIndex = 2;
            // 
            // btnPlot
            // 
            this.btnPlot.Location = new System.Drawing.Point(636, 418);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(84, 20);
            this.btnPlot.TabIndex = 3;
            this.btnPlot.Text = "Plot";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.BtnPlot_Click);
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(31, 395);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(36, 13);
            this.lblMin.TabIndex = 4;
            this.lblMin.Text = "Min = ";
            this.lblMin.Visible = false;
            // 
            // lblAvg
            // 
            this.lblAvg.AutoSize = true;
            this.lblAvg.Location = new System.Drawing.Point(207, 395);
            this.lblAvg.Name = "lblAvg";
            this.lblAvg.Size = new System.Drawing.Size(38, 13);
            this.lblAvg.TabIndex = 5;
            this.lblAvg.Text = "Avg = ";
            this.lblAvg.Visible = false;
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(367, 395);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(39, 13);
            this.lblMax.TabIndex = 6;
            this.lblMax.Text = "Max = ";
            this.lblMax.Visible = false;
            // 
            // ChartBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblAvg);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.cbCurrencies);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Name = "ChartBuilder";
            this.Text = "Chart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.ComboBox cbCurrencies;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblAvg;
        private System.Windows.Forms.Label lblMax;
    }
}