namespace mousegame
{
    partial class GameForm
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
            boardControl1 = new BoardControl();
            prototypeLabel = new Label();
            inventoryListBox = new ListBox();
            inventoryLabel = new Label();
            playersLabel = new Label();
            playersDataGrid = new DataGridView();
            chatLabel = new Label();
            chatListBox = new ListBox();
            chatTextBox = new RichTextBox();
            sendMessageButton = new Button();
            scoreLabel = new Label();
            exitBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)playersDataGrid).BeginInit();
            SuspendLayout();
            // 
            // boardControl1
            // 
            boardControl1.Location = new Point(12, 27);
            boardControl1.Name = "boardControl1";
            boardControl1.Size = new Size(646, 585);
            boardControl1.TabIndex = 0;
            // 
            // prototypeLabel
            // 
            prototypeLabel.AutoSize = true;
            prototypeLabel.Location = new Point(12, 9);
            prototypeLabel.Name = "prototypeLabel";
            prototypeLabel.Size = new Size(627, 15);
            prototypeLabel.TabIndex = 1;
            prototypeLabel.Text = "This form uses the game DAO connection on load to retrieve the tiles in the tile table, clicking a tile will show its tile_id";
            // 
            // inventoryListBox
            // 
            inventoryListBox.FormattingEnabled = true;
            inventoryListBox.Location = new Point(709, 43);
            inventoryListBox.Name = "inventoryListBox";
            inventoryListBox.Size = new Size(305, 79);
            inventoryListBox.TabIndex = 2;
            // 
            // inventoryLabel
            // 
            inventoryLabel.AutoSize = true;
            inventoryLabel.Font = new Font("Segoe UI", 18F);
            inventoryLabel.Location = new Point(709, 9);
            inventoryLabel.Name = "inventoryLabel";
            inventoryLabel.Size = new Size(115, 32);
            inventoryLabel.TabIndex = 3;
            inventoryLabel.Text = "Inventory";
            // 
            // playersLabel
            // 
            playersLabel.AutoSize = true;
            playersLabel.Font = new Font("Segoe UI", 18F);
            playersLabel.Location = new Point(709, 134);
            playersLabel.Name = "playersLabel";
            playersLabel.Size = new Size(88, 32);
            playersLabel.TabIndex = 4;
            playersLabel.Text = "Players";
            // 
            // playersDataGrid
            // 
            playersDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            playersDataGrid.Location = new Point(709, 169);
            playersDataGrid.Name = "playersDataGrid";
            playersDataGrid.Size = new Size(305, 164);
            playersDataGrid.TabIndex = 5;
            // 
            // chatLabel
            // 
            chatLabel.AutoSize = true;
            chatLabel.Font = new Font("Segoe UI", 18F);
            chatLabel.Location = new Point(709, 348);
            chatLabel.Name = "chatLabel";
            chatLabel.Size = new Size(63, 32);
            chatLabel.TabIndex = 6;
            chatLabel.Text = "Chat";
            // 
            // chatListBox
            // 
            chatListBox.FormattingEnabled = true;
            chatListBox.Location = new Point(709, 383);
            chatListBox.Name = "chatListBox";
            chatListBox.Size = new Size(305, 154);
            chatListBox.TabIndex = 7;
            // 
            // chatTextBox
            // 
            chatTextBox.Location = new Point(709, 543);
            chatTextBox.Name = "chatTextBox";
            chatTextBox.Size = new Size(305, 49);
            chatTextBox.TabIndex = 8;
            chatTextBox.Text = "";
            // 
            // sendMessageButton
            // 
            sendMessageButton.Location = new Point(709, 598);
            sendMessageButton.Name = "sendMessageButton";
            sendMessageButton.Size = new Size(75, 23);
            sendMessageButton.TabIndex = 9;
            sendMessageButton.Text = "Send";
            sendMessageButton.UseVisualStyleBackColor = true;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new Font("Segoe UI", 18F);
            scoreLabel.Location = new Point(12, 624);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(124, 32);
            scoreLabel.TabIndex = 10;
            scoreLabel.Text = "Score: 300";
            // 
            // exitBtn
            // 
            exitBtn.Location = new Point(881, 633);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(133, 37);
            exitBtn.TabIndex = 11;
            exitBtn.Text = "Exit Game";
            exitBtn.UseVisualStyleBackColor = true;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1041, 682);
            Controls.Add(exitBtn);
            Controls.Add(scoreLabel);
            Controls.Add(sendMessageButton);
            Controls.Add(chatTextBox);
            Controls.Add(chatListBox);
            Controls.Add(chatLabel);
            Controls.Add(playersDataGrid);
            Controls.Add(playersLabel);
            Controls.Add(inventoryLabel);
            Controls.Add(inventoryListBox);
            Controls.Add(prototypeLabel);
            Controls.Add(boardControl1);
            Name = "GameForm";
            Text = "Game Form";
            Load += GameForm_Load;
            ((System.ComponentModel.ISupportInitialize)playersDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BoardControl boardControl1;
        private Label prototypeLabel;
        private ListBox inventoryListBox;
        private Label inventoryLabel;
        private Label playersLabel;
        private DataGridView playersDataGrid;
        private Label chatLabel;
        private ListBox chatListBox;
        private RichTextBox chatTextBox;
        private Button sendMessageButton;
        private Label scoreLabel;
        private Button exitBtn;
    }
}