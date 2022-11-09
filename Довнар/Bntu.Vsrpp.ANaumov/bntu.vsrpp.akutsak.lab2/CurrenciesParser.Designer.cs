namespace Bntu.Vsrpp.Akutsak.Lab2
{
    partial class CurrenciesParser
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
            this.btnGetCurrencies = new System.Windows.Forms.Button();
            this.cbCurrencyInput = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.cbCurrencyOutput = new System.Windows.Forms.ComboBox();
            this.tbValueInput = new System.Windows.Forms.TextBox();
            this.tbValueOutput = new System.Windows.Forms.TextBox();
            this.btnResult = new System.Windows.Forms.Button();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.btnGraph = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetCurrencies
            // 
            this.btnGetCurrencies.Location = new System.Drawing.Point(306, 52);
            this.btnGetCurrencies.Name = "btnGetCurrencies";
            this.btnGetCurrencies.Size = new System.Drawing.Size(121, 23);
            this.btnGetCurrencies.TabIndex = 0;
            this.btnGetCurrencies.Text = "Get Currencies";
            this.btnGetCurrencies.UseVisualStyleBackColor = true;
            this.btnGetCurrencies.Click += new System.EventHandler(this.BtnGetCurrencies_Click);
            // 
            // cbCurrencyInput
            // 
            this.cbCurrencyInput.FormattingEnabled = true;
            this.cbCurrencyInput.Location = new System.Drawing.Point(186, 98);
            this.cbCurrencyInput.Name = "cbCurrencyInput";
            this.cbCurrencyInput.Size = new System.Drawing.Size(241, 21);
            this.cbCurrencyInput.TabIndex = 1;
            //this.cbCurrencyInput.SelectedIndexChanged += new System.EventHandler(this.CbCurrencyInput_SelectedIndexChanged);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(65, 55);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 3;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            // 
            // cbCurrencyOutput
            // 
            this.cbCurrencyOutput.FormattingEnabled = true;
            this.cbCurrencyOutput.Location = new System.Drawing.Point(186, 154);
            this.cbCurrencyOutput.Name = "cbCurrencyOutput";
            this.cbCurrencyOutput.Size = new System.Drawing.Size(241, 21);
            this.cbCurrencyOutput.TabIndex = 8;
            //this.cbCurrencyOutput.SelectedIndexChanged += new System.EventHandler(this.CbCurrencyOutput_SelectedIndexChanged);
            // 
            // tbValueInput
            // 
            this.tbValueInput.Location = new System.Drawing.Point(65, 98);
            this.tbValueInput.Name = "tbValueInput";
            this.tbValueInput.Size = new System.Drawing.Size(95, 20);
            this.tbValueInput.TabIndex = 9;
            // 
            // tbValueOutput
            // 
            this.tbValueOutput.Location = new System.Drawing.Point(65, 155);
            this.tbValueOutput.Name = "tbValueOutput";
            this.tbValueOutput.Size = new System.Drawing.Size(95, 20);
            this.tbValueOutput.TabIndex = 10;
            // 
            // btnResult
            // 
            this.btnResult.Enabled = false;
            this.btnResult.Location = new System.Drawing.Point(65, 195);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(75, 23);
            this.btnResult.TabIndex = 11;
            this.btnResult.Text = "Result";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.BtnResult_Click);
            // 
            // btnSwitch
            // 
            this.btnSwitch.Enabled = false;
            this.btnSwitch.Location = new System.Drawing.Point(263, 125);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(75, 23);
            this.btnSwitch.TabIndex = 12;
            this.btnSwitch.Text = "Switch";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.BtnSwitch_Click);
            // 
            // btnGraph
            // 
            this.btnGraph.Enabled = false;
            this.btnGraph.Location = new System.Drawing.Point(65, 281);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(75, 23);
            this.btnGraph.TabIndex = 13;
            this.btnGraph.Text = "Plot A Graph";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.BtnGraph_Click);
            // 
            // CurrenciesParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 332);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.btnSwitch);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.tbValueOutput);
            this.Controls.Add(this.tbValueInput);
            this.Controls.Add(this.cbCurrencyOutput);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.cbCurrencyInput);
            this.Controls.Add(this.btnGetCurrencies);
            this.Name = "CurrenciesParser";
            this.Text = "Currencies Parser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetCurrencies;
        private System.Windows.Forms.ComboBox cbCurrencyInput;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.ComboBox cbCurrencyOutput;
        private System.Windows.Forms.TextBox tbValueInput;
        private System.Windows.Forms.TextBox tbValueOutput;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.Button btnGraph;
    }
}

