namespace mousegame
{
    partial class MainForm
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
            titleLabel = new Label();
            newGameBtn = new Button();
            joinGameBtn = new Button();
            adminToolsLabel = new Label();
            manageGamesBtn = new Button();
            manageUsersBtn = new Button();
            signOutBtn = new Button();
            deleteAccountBtn = new Button();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 28F);
            titleLabel.Location = new Point(442, 61);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(326, 62);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "MOUSE GAME";
            // 
            // newGameBtn
            // 
            newGameBtn.Location = new Point(514, 169);
            newGameBtn.Margin = new Padding(3, 4, 3, 4);
            newGameBtn.Name = "newGameBtn";
            newGameBtn.Size = new Size(152, 49);
            newGameBtn.TabIndex = 6;
            newGameBtn.Text = "New Game";
            newGameBtn.UseVisualStyleBackColor = true;
            newGameBtn.Click += newGameBtn_Click;
            // 
            // joinGameBtn
            // 
            joinGameBtn.Location = new Point(514, 267);
            joinGameBtn.Margin = new Padding(3, 4, 3, 4);
            joinGameBtn.Name = "joinGameBtn";
            joinGameBtn.Size = new Size(152, 49);
            joinGameBtn.TabIndex = 7;
            joinGameBtn.Text = "Join Game";
            joinGameBtn.UseVisualStyleBackColor = true;
            joinGameBtn.Click += joinGameBtn_Click;
            // 
            // adminToolsLabel
            // 
            adminToolsLabel.AutoSize = true;
            adminToolsLabel.Font = new Font("Segoe UI", 21F);
            adminToolsLabel.Location = new Point(494, 380);
            adminToolsLabel.Name = "adminToolsLabel";
            adminToolsLabel.Size = new Size(212, 47);
            adminToolsLabel.TabIndex = 8;
            adminToolsLabel.Text = "Admin Tools";
            // 
            // manageGamesBtn
            // 
            manageGamesBtn.Location = new Point(514, 471);
            manageGamesBtn.Margin = new Padding(3, 4, 3, 4);
            manageGamesBtn.Name = "manageGamesBtn";
            manageGamesBtn.Size = new Size(152, 49);
            manageGamesBtn.TabIndex = 9;
            manageGamesBtn.Text = "Manage Games";
            manageGamesBtn.UseVisualStyleBackColor = true;
            manageGamesBtn.Click += manageGamesBtn_Click;
            // 
            // manageUsersBtn
            // 
            manageUsersBtn.Location = new Point(514, 573);
            manageUsersBtn.Margin = new Padding(3, 4, 3, 4);
            manageUsersBtn.Name = "manageUsersBtn";
            manageUsersBtn.Size = new Size(152, 49);
            manageUsersBtn.TabIndex = 10;
            manageUsersBtn.Text = "Manage Users";
            manageUsersBtn.UseVisualStyleBackColor = true;
            manageUsersBtn.Click += manageUsersBtn_Click;
            // 
            // signOutBtn
            // 
            signOutBtn.Location = new Point(1009, 573);
            signOutBtn.Margin = new Padding(3, 4, 3, 4);
            signOutBtn.Name = "signOutBtn";
            signOutBtn.Size = new Size(152, 49);
            signOutBtn.TabIndex = 11;
            signOutBtn.Text = "Sign Out";
            signOutBtn.UseVisualStyleBackColor = true;
            signOutBtn.Click += signOutBtn_Click;
            // 
            // deleteAccountBtn
            // 
            deleteAccountBtn.Location = new Point(1009, 689);
            deleteAccountBtn.Margin = new Padding(3, 4, 3, 4);
            deleteAccountBtn.Name = "deleteAccountBtn";
            deleteAccountBtn.Size = new Size(152, 49);
            deleteAccountBtn.TabIndex = 12;
            deleteAccountBtn.Text = "Delete Account";
            deleteAccountBtn.UseVisualStyleBackColor = true;
            deleteAccountBtn.Click += deleteAccountBtn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1195, 777);
            Controls.Add(deleteAccountBtn);
            Controls.Add(signOutBtn);
            Controls.Add(manageUsersBtn);
            Controls.Add(manageGamesBtn);
            Controls.Add(adminToolsLabel);
            Controls.Add(joinGameBtn);
            Controls.Add(newGameBtn);
            Controls.Add(titleLabel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "MainForm";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Button newGameBtn;
        private Button joinGameBtn;
        private Label adminToolsLabel;
        private Button manageGamesBtn;
        private Button manageUsersBtn;
        private Button signOutBtn;
        private Button deleteAccountBtn;
    }
}