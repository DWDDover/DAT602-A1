namespace mousegame
{
    partial class JoinGameForm
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
            gameListLabel = new Label();
            joinBtn = new Button();
            cancelBtn = new Button();
            gameList = new ListBox();
            SuspendLayout();
            // 
            // gameListLabel
            // 
            gameListLabel.AutoSize = true;
            gameListLabel.Location = new Point(27, 10);
            gameListLabel.Name = "gameListLabel";
            gameListLabel.Size = new Size(82, 15);
            gameListLabel.TabIndex = 1;
            gameListLabel.Text = "Active Games:";
            // 
            // joinBtn
            // 
            joinBtn.Location = new Point(68, 297);
            joinBtn.Margin = new Padding(3, 2, 3, 2);
            joinBtn.Name = "joinBtn";
            joinBtn.Size = new Size(156, 32);
            joinBtn.TabIndex = 2;
            joinBtn.Text = "Join";
            joinBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(295, 297);
            cancelBtn.Margin = new Padding(3, 2, 3, 2);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(156, 32);
            cancelBtn.TabIndex = 3;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // gameList
            // 
            gameList.FormattingEnabled = true;
            gameList.Location = new Point(27, 44);
            gameList.Name = "gameList";
            gameList.Size = new Size(465, 229);
            gameList.TabIndex = 4;
            // 
            // JoinGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(529, 338);
            Controls.Add(gameList);
            Controls.Add(cancelBtn);
            Controls.Add(joinBtn);
            Controls.Add(gameListLabel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "JoinGameForm";
            Text = "JoinGameForm";
            Load += JoinGameForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label gameListLabel;
        private Button joinBtn;
        private Button cancelBtn;
        private ListBox gameList;
    }
}