namespace WindowsFormsApp1
{
    partial class ReaderLandingPage
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
            this.label3 = new System.Windows.Forms.Label();
            this.UserPassword_Label = new System.Windows.Forms.Label();
            this.UserPassword_TextBox = new System.Windows.Forms.TextBox();
            this.UserName_Label = new System.Windows.Forms.Label();
            this.UserName_TextBox = new System.Windows.Forms.TextBox();
            this.UserLogIn_Submit_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(321, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 45);
            this.label3.TabIndex = 21;
            this.label3.Text = "Welcome.!";
            // 
            // UserPassword_Label
            // 
            this.UserPassword_Label.AutoSize = true;
            this.UserPassword_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserPassword_Label.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.UserPassword_Label.Location = new System.Drawing.Point(321, 301);
            this.UserPassword_Label.Name = "UserPassword_Label";
            this.UserPassword_Label.Size = new System.Drawing.Size(128, 29);
            this.UserPassword_Label.TabIndex = 20;
            this.UserPassword_Label.Text = "Password";
            // 
            // UserPassword_TextBox
            // 
            this.UserPassword_TextBox.BackColor = System.Drawing.Color.LightYellow;
            this.UserPassword_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserPassword_TextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.UserPassword_TextBox.Location = new System.Drawing.Point(277, 250);
            this.UserPassword_TextBox.Name = "UserPassword_TextBox";
            this.UserPassword_TextBox.Size = new System.Drawing.Size(246, 34);
            this.UserPassword_TextBox.TabIndex = 19;
            this.UserPassword_TextBox.Text = "Enter Password";
            this.UserPassword_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UserName_Label
            // 
            this.UserName_Label.AutoSize = true;
            this.UserName_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName_Label.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.UserName_Label.Location = new System.Drawing.Point(321, 196);
            this.UserName_Label.Name = "UserName_Label";
            this.UserName_Label.Size = new System.Drawing.Size(144, 29);
            this.UserName_Label.TabIndex = 18;
            this.UserName_Label.Text = "User Name";
            // 
            // UserName_TextBox
            // 
            this.UserName_TextBox.BackColor = System.Drawing.Color.LightYellow;
            this.UserName_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName_TextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.UserName_TextBox.Location = new System.Drawing.Point(277, 148);
            this.UserName_TextBox.Name = "UserName_TextBox";
            this.UserName_TextBox.Size = new System.Drawing.Size(246, 34);
            this.UserName_TextBox.TabIndex = 17;
            this.UserName_TextBox.Text = "Enter User Name";
            this.UserName_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UserLogIn_Submit_Button
            // 
            this.UserLogIn_Submit_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLogIn_Submit_Button.Location = new System.Drawing.Point(316, 370);
            this.UserLogIn_Submit_Button.Name = "UserLogIn_Submit_Button";
            this.UserLogIn_Submit_Button.Size = new System.Drawing.Size(133, 29);
            this.UserLogIn_Submit_Button.TabIndex = 22;
            this.UserLogIn_Submit_Button.Text = "Submit";
            this.UserLogIn_Submit_Button.UseVisualStyleBackColor = true;
            this.UserLogIn_Submit_Button.Click += new System.EventHandler(this.UserLogIn_Submit_Button_Click);
            // 
            // ReaderLandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UserLogIn_Submit_Button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UserPassword_Label);
            this.Controls.Add(this.UserPassword_TextBox);
            this.Controls.Add(this.UserName_Label);
            this.Controls.Add(this.UserName_TextBox);
            this.Name = "ReaderLandingPage";
            this.Text = "ReaderLandingPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label UserPassword_Label;
        private System.Windows.Forms.TextBox UserPassword_TextBox;
        private System.Windows.Forms.Label UserName_Label;
        private System.Windows.Forms.TextBox UserName_TextBox;
        private System.Windows.Forms.Button UserLogIn_Submit_Button;
    }
}