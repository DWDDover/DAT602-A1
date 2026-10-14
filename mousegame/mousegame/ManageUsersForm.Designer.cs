namespace mousegame
{
    partial class ManageUsersForm
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
            playersLabel = new Label();
            userGrid = new DataGridView();
            editBtn = new Button();
            unlockBtn = new Button();
            addBtn = new Button();
            deleteBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)userGrid).BeginInit();
            SuspendLayout();
            // 
            // playersLabel
            // 
            playersLabel.AutoSize = true;
            playersLabel.Location = new Point(12, 9);
            playersLabel.Name = "playersLabel";
            playersLabel.Size = new Size(38, 15);
            playersLabel.TabIndex = 0;
            playersLabel.Text = "Users:";
            // 
            // userGrid
            // 
            userGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            userGrid.Location = new Point(12, 39);
            userGrid.Name = "userGrid";
            userGrid.Size = new Size(398, 295);
            userGrid.TabIndex = 1;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(12, 361);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(94, 32);
            editBtn.TabIndex = 2;
            editBtn.Text = "Edit";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += editBtn_Click;
            // 
            // unlockBtn
            // 
            unlockBtn.Location = new Point(112, 361);
            unlockBtn.Name = "unlockBtn";
            unlockBtn.Size = new Size(94, 32);
            unlockBtn.TabIndex = 3;
            unlockBtn.Text = "Unlock";
            unlockBtn.UseVisualStyleBackColor = true;
            unlockBtn.Click += unlockBtn_Click;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(216, 361);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(94, 32);
            addBtn.TabIndex = 4;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(316, 361);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(94, 32);
            deleteBtn.TabIndex = 5;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // ManageUsersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 415);
            Controls.Add(deleteBtn);
            Controls.Add(addBtn);
            Controls.Add(unlockBtn);
            Controls.Add(editBtn);
            Controls.Add(userGrid);
            Controls.Add(playersLabel);
            Name = "ManageUsersForm";
            Text = "ManageUsersForm";
            Load += ManageUsersForm_Load;
            ((System.ComponentModel.ISupportInitialize)userGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label playersLabel;
        private DataGridView userGrid;
        private Button editBtn;
        private Button unlockBtn;
        private Button addBtn;
        private Button deleteBtn;
    }
}