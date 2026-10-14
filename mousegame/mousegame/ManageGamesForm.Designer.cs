namespace mousegame
{
    partial class ManageGamesForm
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
            gamesLabel = new Label();
            killBtn = new Button();
            CancelBtn = new Button();
            gameGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gameGrid).BeginInit();
            SuspendLayout();
            // 
            // gamesLabel
            // 
            gamesLabel.AutoSize = true;
            gamesLabel.Location = new Point(12, 9);
            gamesLabel.Name = "gamesLabel";
            gamesLabel.Size = new Size(46, 15);
            gamesLabel.TabIndex = 0;
            gamesLabel.Text = "Games:";
            // 
            // killBtn
            // 
            killBtn.Location = new Point(38, 373);
            killBtn.Name = "killBtn";
            killBtn.Size = new Size(103, 34);
            killBtn.TabIndex = 2;
            killBtn.Text = "Kill Game";
            killBtn.UseVisualStyleBackColor = true;
            killBtn.Click += killBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(226, 373);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(103, 34);
            CancelBtn.TabIndex = 3;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // gameGrid
            // 
            gameGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gameGrid.Location = new Point(12, 27);
            gameGrid.Name = "gameGrid";
            gameGrid.Size = new Size(345, 331);
            gameGrid.TabIndex = 4;
            // 
            // ManageGamesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 429);
            Controls.Add(gameGrid);
            Controls.Add(CancelBtn);
            Controls.Add(killBtn);
            Controls.Add(gamesLabel);
            Name = "ManageGamesForm";
            Text = "ManageGamesForm";
            Load += ManageGamesForm_Load;
            ((System.ComponentModel.ISupportInitialize)gameGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label gamesLabel;
        private ListBox gameList;
        private Button killBtn;
        private Button CancelBtn;
        private DataGridView gameGrid;
    }
}