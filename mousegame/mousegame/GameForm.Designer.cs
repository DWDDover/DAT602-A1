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
            components = new System.ComponentModel.Container();
            boardControl1 = new BoardControl();
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
            label1 = new Label();
            gameNameLabel = new Label();
            gameTick = new System.Windows.Forms.Timer(components);
            moveCatBtn = new Button();
            placeCheeseBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)playersDataGrid).BeginInit();
            SuspendLayout();
            // 
            // boardControl1
            // 
            boardControl1.Location = new Point(12, 43);
            boardControl1.Name = "boardControl1";
            boardControl1.Size = new Size(733, 680);
            boardControl1.TabIndex = 0;
            // 
            // inventoryListBox
            // 
            inventoryListBox.FormattingEnabled = true;
            inventoryListBox.Location = new Point(751, 43);
            inventoryListBox.Name = "inventoryListBox";
            inventoryListBox.Size = new Size(263, 79);
            inventoryListBox.TabIndex = 2;
            // 
            // inventoryLabel
            // 
            inventoryLabel.AutoSize = true;
            inventoryLabel.Font = new Font("Segoe UI", 18F);
            inventoryLabel.Location = new Point(751, 9);
            inventoryLabel.Name = "inventoryLabel";
            inventoryLabel.Size = new Size(115, 32);
            inventoryLabel.TabIndex = 3;
            inventoryLabel.Text = "Inventory";
            inventoryLabel.Click += inventoryLabel_Click;
            // 
            // playersLabel
            // 
            playersLabel.AutoSize = true;
            playersLabel.Font = new Font("Segoe UI", 18F);
            playersLabel.Location = new Point(751, 134);
            playersLabel.Name = "playersLabel";
            playersLabel.Size = new Size(88, 32);
            playersLabel.TabIndex = 4;
            playersLabel.Text = "Players";
            // 
            // playersDataGrid
            // 
            playersDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            playersDataGrid.Location = new Point(751, 169);
            playersDataGrid.Name = "playersDataGrid";
            playersDataGrid.Size = new Size(263, 164);
            playersDataGrid.TabIndex = 5;
            // 
            // chatLabel
            // 
            chatLabel.AutoSize = true;
            chatLabel.Font = new Font("Segoe UI", 18F);
            chatLabel.Location = new Point(751, 368);
            chatLabel.Name = "chatLabel";
            chatLabel.Size = new Size(63, 32);
            chatLabel.TabIndex = 6;
            chatLabel.Text = "Chat";
            // 
            // chatListBox
            // 
            chatListBox.FormattingEnabled = true;
            chatListBox.Location = new Point(751, 403);
            chatListBox.Name = "chatListBox";
            chatListBox.Size = new Size(263, 154);
            chatListBox.TabIndex = 7;
            // 
            // chatTextBox
            // 
            chatTextBox.Location = new Point(751, 588);
            chatTextBox.Name = "chatTextBox";
            chatTextBox.Size = new Size(263, 49);
            chatTextBox.TabIndex = 8;
            chatTextBox.Text = "";
            // 
            // sendMessageButton
            // 
            sendMessageButton.Location = new Point(751, 643);
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
            scoreLabel.Location = new Point(12, 726);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(124, 32);
            scoreLabel.TabIndex = 10;
            scoreLabel.Text = "Score: 300";
            // 
            // exitBtn
            // 
            exitBtn.Location = new Point(881, 721);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(133, 37);
            exitBtn.TabIndex = 11;
            exitBtn.Text = "Exit Game";
            exitBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(81, 32);
            label1.TabIndex = 12;
            label1.Text = "Game:";
            // 
            // gameNameLabel
            // 
            gameNameLabel.AutoSize = true;
            gameNameLabel.Font = new Font("Segoe UI", 18F);
            gameNameLabel.Location = new Point(99, 9);
            gameNameLabel.Name = "gameNameLabel";
            gameNameLabel.Size = new Size(34, 32);
            gameNameLabel.TabIndex = 13;
            gameNameLabel.Text = "--";
            // 
            // gameTick
            // 
            gameTick.Interval = 5000;
            gameTick.Tick += gameTick_Tick;
            // 
            // moveCatBtn
            // 
            moveCatBtn.Location = new Point(427, 14);
            moveCatBtn.Name = "moveCatBtn";
            moveCatBtn.Size = new Size(103, 23);
            moveCatBtn.TabIndex = 14;
            moveCatBtn.Text = "Move Cat";
            moveCatBtn.UseVisualStyleBackColor = true;
            moveCatBtn.Click += moveCatBtn_Click;
            // 
            // placeCheeseBtn
            // 
            placeCheeseBtn.Location = new Point(555, 14);
            placeCheeseBtn.Name = "placeCheeseBtn";
            placeCheeseBtn.Size = new Size(104, 23);
            placeCheeseBtn.TabIndex = 15;
            placeCheeseBtn.Text = "Place Cheese";
            placeCheeseBtn.UseVisualStyleBackColor = true;
            placeCheeseBtn.Click += placeCheeseBtn_Click;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1041, 770);
            Controls.Add(placeCheeseBtn);
            Controls.Add(moveCatBtn);
            Controls.Add(gameNameLabel);
            Controls.Add(label1);
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
            Controls.Add(boardControl1);
            Name = "GameForm";
            Text = "Game Form";
            FormClosed += GameForm_FormClosed;
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
        private Label label1;
        private Label gameNameLabel;
        private System.Windows.Forms.Timer gameTick;
        private Button moveCatBtn;
        private Button placeCheeseBtn;
    }
}