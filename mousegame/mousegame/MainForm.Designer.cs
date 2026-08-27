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
            label1 = new Label();
            manageGamesBtn = new Button();
            manageUsersBtn = new Button();
            signOutBtn = new Button();
            deleteAccountBtn = new Button();
            prototypeLabel = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 28F);
            titleLabel.Location = new Point(387, 46);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(264, 51);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "MOUSE GAME";
            // 
            // newGameBtn
            // 
            newGameBtn.Location = new Point(450, 127);
            newGameBtn.Name = "newGameBtn";
            newGameBtn.Size = new Size(133, 37);
            newGameBtn.TabIndex = 6;
            newGameBtn.Text = "New Game";
            newGameBtn.UseVisualStyleBackColor = true;
            // 
            // joinGameBtn
            // 
            joinGameBtn.Location = new Point(450, 200);
            joinGameBtn.Name = "joinGameBtn";
            joinGameBtn.Size = new Size(133, 37);
            joinGameBtn.TabIndex = 7;
            joinGameBtn.Text = "Join Game";
            joinGameBtn.UseVisualStyleBackColor = true;
            joinGameBtn.Click += joinGameBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21F);
            label1.Location = new Point(432, 285);
            label1.Name = "label1";
            label1.Size = new Size(169, 38);
            label1.TabIndex = 8;
            label1.Text = "Admin Tools";
            // 
            // manageGamesBtn
            // 
            manageGamesBtn.Location = new Point(450, 353);
            manageGamesBtn.Name = "manageGamesBtn";
            manageGamesBtn.Size = new Size(133, 37);
            manageGamesBtn.TabIndex = 9;
            manageGamesBtn.Text = "Manage Games";
            manageGamesBtn.UseVisualStyleBackColor = true;
            manageGamesBtn.Click += manageGamesBtn_Click;
            // 
            // manageUsersBtn
            // 
            manageUsersBtn.Location = new Point(450, 430);
            manageUsersBtn.Name = "manageUsersBtn";
            manageUsersBtn.Size = new Size(133, 37);
            manageUsersBtn.TabIndex = 10;
            manageUsersBtn.Text = "Manage Users";
            manageUsersBtn.UseVisualStyleBackColor = true;
            // 
            // signOutBtn
            // 
            signOutBtn.Location = new Point(883, 430);
            signOutBtn.Name = "signOutBtn";
            signOutBtn.Size = new Size(133, 37);
            signOutBtn.TabIndex = 11;
            signOutBtn.Text = "Sign Out";
            signOutBtn.UseVisualStyleBackColor = true;
            // 
            // deleteAccountBtn
            // 
            deleteAccountBtn.Location = new Point(883, 517);
            deleteAccountBtn.Name = "deleteAccountBtn";
            deleteAccountBtn.Size = new Size(133, 37);
            deleteAccountBtn.TabIndex = 12;
            deleteAccountBtn.Text = "Delete Account";
            deleteAccountBtn.UseVisualStyleBackColor = true;
            // 
            // prototypeLabel
            // 
            prototypeLabel.AutoSize = true;
            prototypeLabel.Location = new Point(190, 364);
            prototypeLabel.Name = "prototypeLabel";
            prototypeLabel.Size = new Size(254, 15);
            prototypeLabel.TabIndex = 13;
            prototypeLabel.Text = "Click here to test the admin DAO connection >";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(218, 211);
            label2.Name = "label2";
            label2.Size = new Size(226, 15);
            label2.TabIndex = 14;
            label2.Text = "Click here to proceed to the game form >";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1046, 583);
            Controls.Add(label2);
            Controls.Add(prototypeLabel);
            Controls.Add(deleteAccountBtn);
            Controls.Add(signOutBtn);
            Controls.Add(manageUsersBtn);
            Controls.Add(manageGamesBtn);
            Controls.Add(label1);
            Controls.Add(joinGameBtn);
            Controls.Add(newGameBtn);
            Controls.Add(titleLabel);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Button newGameBtn;
        private Button joinGameBtn;
        private Label label1;
        private Button manageGamesBtn;
        private Button manageUsersBtn;
        private Button signOutBtn;
        private Button deleteAccountBtn;
        private Label prototypeLabel;
        private Label label2;
    }
}