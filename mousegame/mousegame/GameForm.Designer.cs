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
            inventoryLabel = new Label();
            playersLabel = new Label();
            playersDataGrid = new DataGridView();
            chatLabel = new Label();
            chatListBox = new ListBox();
            chatTextBox = new RichTextBox();
            sendMessageButton = new Button();
            exitBtn = new Button();
            label1 = new Label();
            gameNameLabel = new Label();
            gameTick = new System.Windows.Forms.Timer(components);
            moveCatBtn = new Button();
            placeCheeseBtn = new Button();
            score = new Label();
            mousetrapBtn = new Button();
            inventoryGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)playersDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inventoryGrid).BeginInit();
            SuspendLayout();
            // 
            // boardControl1
            // 
            boardControl1.Location = new Point(14, 57);
            boardControl1.Margin = new Padding(3, 5, 3, 5);
            boardControl1.Name = "boardControl1";
            boardControl1.Size = new Size(838, 842);
            boardControl1.TabIndex = 0;
            // 
            // inventoryLabel
            // 
            inventoryLabel.AutoSize = true;
            inventoryLabel.Font = new Font("Segoe UI", 18F);
            inventoryLabel.Location = new Point(858, 12);
            inventoryLabel.Name = "inventoryLabel";
            inventoryLabel.Size = new Size(143, 41);
            inventoryLabel.TabIndex = 3;
            inventoryLabel.Text = "Inventory";
            inventoryLabel.Click += inventoryLabel_Click;
            // 
            // playersLabel
            // 
            playersLabel.AutoSize = true;
            playersLabel.Font = new Font("Segoe UI", 18F);
            playersLabel.Location = new Point(858, 179);
            playersLabel.Name = "playersLabel";
            playersLabel.Size = new Size(111, 41);
            playersLabel.TabIndex = 4;
            playersLabel.Text = "Players";
            // 
            // playersDataGrid
            // 
            playersDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            playersDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            playersDataGrid.Location = new Point(858, 225);
            playersDataGrid.Margin = new Padding(3, 4, 3, 4);
            playersDataGrid.Name = "playersDataGrid";
            playersDataGrid.RowHeadersWidth = 20;
            playersDataGrid.Size = new Size(301, 219);
            playersDataGrid.TabIndex = 5;
            // 
            // chatLabel
            // 
            chatLabel.AutoSize = true;
            chatLabel.Font = new Font("Segoe UI", 18F);
            chatLabel.Location = new Point(858, 491);
            chatLabel.Name = "chatLabel";
            chatLabel.Size = new Size(79, 41);
            chatLabel.TabIndex = 6;
            chatLabel.Text = "Chat";
            // 
            // chatListBox
            // 
            chatListBox.FormattingEnabled = true;
            chatListBox.Location = new Point(858, 537);
            chatListBox.Margin = new Padding(3, 4, 3, 4);
            chatListBox.Name = "chatListBox";
            chatListBox.Size = new Size(300, 204);
            chatListBox.TabIndex = 7;
            // 
            // chatTextBox
            // 
            chatTextBox.Location = new Point(858, 784);
            chatTextBox.Margin = new Padding(3, 4, 3, 4);
            chatTextBox.Name = "chatTextBox";
            chatTextBox.Size = new Size(300, 64);
            chatTextBox.TabIndex = 8;
            chatTextBox.Text = "";
            // 
            // sendMessageButton
            // 
            sendMessageButton.Location = new Point(858, 857);
            sendMessageButton.Margin = new Padding(3, 4, 3, 4);
            sendMessageButton.Name = "sendMessageButton";
            sendMessageButton.Size = new Size(86, 31);
            sendMessageButton.TabIndex = 9;
            sendMessageButton.Text = "Send";
            sendMessageButton.UseVisualStyleBackColor = true;
            // 
            // exitBtn
            // 
            exitBtn.Location = new Point(1006, 918);
            exitBtn.Margin = new Padding(3, 4, 3, 4);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(152, 49);
            exitBtn.TabIndex = 11;
            exitBtn.Text = "Exit Game";
            exitBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(103, 41);
            label1.TabIndex = 12;
            label1.Text = "Game:";
            // 
            // gameNameLabel
            // 
            gameNameLabel.AutoSize = true;
            gameNameLabel.Font = new Font("Segoe UI", 18F);
            gameNameLabel.Location = new Point(113, 12);
            gameNameLabel.Name = "gameNameLabel";
            gameNameLabel.Size = new Size(42, 41);
            gameNameLabel.TabIndex = 13;
            gameNameLabel.Text = "--";
            // 
            // gameTick
            // 
            gameTick.Interval = 1000;
            gameTick.Tick += gameTick_Tick;
            // 
            // moveCatBtn
            // 
            moveCatBtn.Location = new Point(488, 19);
            moveCatBtn.Margin = new Padding(3, 4, 3, 4);
            moveCatBtn.Name = "moveCatBtn";
            moveCatBtn.Size = new Size(118, 31);
            moveCatBtn.TabIndex = 14;
            moveCatBtn.Text = "Move Cat";
            moveCatBtn.UseVisualStyleBackColor = true;
            moveCatBtn.Click += moveCatBtn_Click;
            // 
            // placeCheeseBtn
            // 
            placeCheeseBtn.Location = new Point(634, 19);
            placeCheeseBtn.Margin = new Padding(3, 4, 3, 4);
            placeCheeseBtn.Name = "placeCheeseBtn";
            placeCheeseBtn.Size = new Size(119, 31);
            placeCheeseBtn.TabIndex = 15;
            placeCheeseBtn.Text = "Place Cheese";
            placeCheeseBtn.UseVisualStyleBackColor = true;
            placeCheeseBtn.Click += placeCheeseBtn_Click;
            // 
            // score
            // 
            score.AutoSize = true;
            score.Font = new Font("Segoe UI", 18F);
            score.Location = new Point(14, 915);
            score.Name = "score";
            score.Size = new Size(42, 41);
            score.TabIndex = 16;
            score.Text = "--";
            // 
            // mousetrapBtn
            // 
            mousetrapBtn.Location = new Point(310, 19);
            mousetrapBtn.Margin = new Padding(3, 4, 3, 4);
            mousetrapBtn.Name = "mousetrapBtn";
            mousetrapBtn.Size = new Size(157, 31);
            mousetrapBtn.TabIndex = 17;
            mousetrapBtn.Text = "Place mousetrap";
            mousetrapBtn.UseVisualStyleBackColor = true;
            mousetrapBtn.Click += mousetrapBtn_Click;
            // 
            // inventoryGrid
            // 
            inventoryGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            inventoryGrid.Location = new Point(858, 59);
            inventoryGrid.Margin = new Padding(3, 4, 3, 4);
            inventoryGrid.Name = "inventoryGrid";
            inventoryGrid.RowHeadersWidth = 51;
            inventoryGrid.Size = new Size(301, 116);
            inventoryGrid.TabIndex = 18;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1190, 973);
            Controls.Add(inventoryGrid);
            Controls.Add(mousetrapBtn);
            Controls.Add(score);
            Controls.Add(placeCheeseBtn);
            Controls.Add(moveCatBtn);
            Controls.Add(gameNameLabel);
            Controls.Add(label1);
            Controls.Add(exitBtn);
            Controls.Add(sendMessageButton);
            Controls.Add(chatTextBox);
            Controls.Add(chatListBox);
            Controls.Add(chatLabel);
            Controls.Add(playersDataGrid);
            Controls.Add(playersLabel);
            Controls.Add(inventoryLabel);
            Controls.Add(boardControl1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "GameForm";
            Text = "Game Form";
            FormClosed += GameForm_FormClosed;
            Load += GameForm_Load;
            ((System.ComponentModel.ISupportInitialize)playersDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)inventoryGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BoardControl boardControl1;
        private Label prototypeLabel;
        private Label inventoryLabel;
        private Label playersLabel;
        private DataGridView playersDataGrid;
        private Label chatLabel;
        private ListBox chatListBox;
        private RichTextBox chatTextBox;
        private Button sendMessageButton;
        private Button exitBtn;
        private Label label1;
        private Label gameNameLabel;
        private System.Windows.Forms.Timer gameTick;
        private Button moveCatBtn;
        private Button placeCheeseBtn;
        private Label score;
        private Button mousetrapBtn;
        private DataGridView inventoryGrid;
    }
}