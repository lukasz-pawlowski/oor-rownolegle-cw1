namespace projekt1_wielowatkowosc
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
            this.labelFib = new System.Windows.Forms.Label();
            this.labelHash = new System.Windows.Forms.Label();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelFib
            // 
            this.labelFib.AutoSize = true;
            this.labelFib.Location = new System.Drawing.Point(29, 13);
            this.labelFib.Name = "labelFib";
            this.labelFib.Size = new System.Drawing.Size(35, 13);
            this.labelFib.TabIndex = 0;
            this.labelFib.Text = "label1";
            // 
            // labelHash
            // 
            this.labelHash.AutoSize = true;
            this.labelHash.Location = new System.Drawing.Point(32, 236);
            this.labelHash.Name = "labelHash";
            this.labelHash.Size = new System.Drawing.Size(35, 13);
            this.labelHash.TabIndex = 1;
            this.labelHash.Text = "label1";
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(32, 51);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(200, 160);
            this.richTextBox.TabIndex = 2;
            this.richTextBox.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(145, 225);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.labelHash);
            this.Controls.Add(this.labelFib);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFib;
        private System.Windows.Forms.Label labelHash;
        public System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Button button1;
    }
}

