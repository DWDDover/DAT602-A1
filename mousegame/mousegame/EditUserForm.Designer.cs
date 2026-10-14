namespace mousegame
{
    partial class EditUserForm
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
            saveBtn = new Button();
            cancelBtn = new Button();
            usernameLabel = new Label();
            usernameTextbox = new TextBox();
            SuspendLayout();
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(74, 84);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(107, 35);
            saveBtn.TabIndex = 0;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(307, 84);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(107, 35);
            cancelBtn.TabIndex = 1;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(12, 37);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(63, 15);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "Username:";
            // 
            // usernameTextbox
            // 
            usernameTextbox.Location = new Point(81, 34);
            usernameTextbox.Name = "usernameTextbox";
            usernameTextbox.Size = new Size(368, 23);
            usernameTextbox.TabIndex = 3;
            // 
            // EditUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(494, 131);
            Controls.Add(usernameTextbox);
            Controls.Add(usernameLabel);
            Controls.Add(cancelBtn);
            Controls.Add(saveBtn);
            Name = "EditUserForm";
            Text = "EditUserForm";
            Load += EditUserForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button saveBtn;
        private Button cancelBtn;
        private Label usernameLabel;
        private TextBox usernameTextbox;
    }
}