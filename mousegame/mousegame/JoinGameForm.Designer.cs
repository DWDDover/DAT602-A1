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
            gameList = new DataGridView();
            gameListLabel = new Label();
            joinBtn = new Button();
            cancelBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)gameList).BeginInit();
            SuspendLayout();
            // 
            // gameList
            // 
            gameList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gameList.Location = new Point(19, 48);
            gameList.Name = "gameList";
            gameList.RowHeadersWidth = 51;
            gameList.Size = new Size(566, 332);
            gameList.TabIndex = 0;
            // 
            // gameListLabel
            // 
            gameListLabel.AutoSize = true;
            gameListLabel.Location = new Point(31, 13);
            gameListLabel.Name = "gameListLabel";
            gameListLabel.Size = new Size(102, 20);
            gameListLabel.TabIndex = 1;
            gameListLabel.Text = "Active Games:";
            // 
            // joinBtn
            // 
            joinBtn.Location = new Point(78, 396);
            joinBtn.Name = "joinBtn";
            joinBtn.Size = new Size(178, 42);
            joinBtn.TabIndex = 2;
            joinBtn.Text = "Join";
            joinBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(337, 396);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(178, 42);
            cancelBtn.TabIndex = 3;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // JoinGameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 450);
            Controls.Add(cancelBtn);
            Controls.Add(joinBtn);
            Controls.Add(gameListLabel);
            Controls.Add(gameList);
            Name = "JoinGameForm";
            Text = "JoinGameForm";
            ((System.ComponentModel.ISupportInitialize)gameList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gameList;
        private Label gameListLabel;
        private Button joinBtn;
        private Button cancelBtn;
    }
}