namespace Bntu.Vsrpp.Akutsak.lab1
{
    partial class XMLParser
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
            this.btnGetElementCount = new System.Windows.Forms.Button();
            this.lblElementCount = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.cbOperationChoosing = new System.Windows.Forms.ComboBox();
            this.cbParameterChoosing = new System.Windows.Forms.ComboBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblOperation = new System.Windows.Forms.Label();
            this.lblParameter = new System.Windows.Forms.Label();
            this.btnDo = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetElementCount
            // 
            this.btnGetElementCount.Location = new System.Drawing.Point(45, 113);
            this.btnGetElementCount.Name = "btnGetElementCount";
            this.btnGetElementCount.Size = new System.Drawing.Size(132, 23);
            this.btnGetElementCount.TabIndex = 0;
            this.btnGetElementCount.Text = "Get Element Count";
            this.btnGetElementCount.UseVisualStyleBackColor = true;
            this.btnGetElementCount.Click += new System.EventHandler(this.btnGetElementCount_Click);
            // 
            // lblElementCount
            // 
            this.lblElementCount.AutoSize = true;
            this.lblElementCount.Location = new System.Drawing.Point(232, 118);
            this.lblElementCount.Name = "lblElementCount";
            this.lblElementCount.Size = new System.Drawing.Size(0, 13);
            this.lblElementCount.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(45, 59);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cbOperationChoosing
            // 
            this.cbOperationChoosing.FormattingEnabled = true;
            this.cbOperationChoosing.Location = new System.Drawing.Point(99, 163);
            this.cbOperationChoosing.Name = "cbOperationChoosing";
            this.cbOperationChoosing.Size = new System.Drawing.Size(121, 21);
            this.cbOperationChoosing.TabIndex = 3;
            this.cbOperationChoosing.SelectedIndexChanged += new System.EventHandler(this.cbOperationChoosing_SelectedIndexChanged);
            // 
            // cbParameterChoosing
            // 
            this.cbParameterChoosing.FormattingEnabled = true;
            this.cbParameterChoosing.Location = new System.Drawing.Point(348, 163);
            this.cbParameterChoosing.Name = "cbParameterChoosing";
            this.cbParameterChoosing.Size = new System.Drawing.Size(121, 21);
            this.cbParameterChoosing.TabIndex = 4;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(493, 166);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(16, 13);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "   ";
            // 
            // lblOperation
            // 
            this.lblOperation.AutoSize = true;
            this.lblOperation.Location = new System.Drawing.Point(42, 166);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(53, 13);
            this.lblOperation.TabIndex = 6;
            this.lblOperation.Text = "Operation";
            // 
            // lblParameter
            // 
            this.lblParameter.AutoSize = true;
            this.lblParameter.Location = new System.Drawing.Point(287, 166);
            this.lblParameter.Name = "lblParameter";
            this.lblParameter.Size = new System.Drawing.Size(55, 13);
            this.lblParameter.TabIndex = 7;
            this.lblParameter.Text = "Parameter";
            // 
            // btnDo
            // 
            this.btnDo.Location = new System.Drawing.Point(45, 209);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(75, 23);
            this.btnDo.TabIndex = 8;
            this.btnDo.Text = "Do";
            this.btnDo.UseVisualStyleBackColor = true;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(267, 209);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 9;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // XMLParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 274);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnDo);
            this.Controls.Add(this.lblParameter);
            this.Controls.Add(this.lblOperation);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.cbParameterChoosing);
            this.Controls.Add(this.cbOperationChoosing);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblElementCount);
            this.Controls.Add(this.btnGetElementCount);
            this.Name = "XMLParser";
            this.Text = "XML Parser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetElementCount;
        private System.Windows.Forms.Label lblElementCount;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ComboBox cbOperationChoosing;
        private System.Windows.Forms.ComboBox cbParameterChoosing;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblOperation;
        private System.Windows.Forms.Label lblParameter;
        private System.Windows.Forms.Button btnDo;
        private System.Windows.Forms.Button btnModify;
    }
}

