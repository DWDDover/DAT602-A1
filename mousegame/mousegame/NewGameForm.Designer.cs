namespace mousegame
{
    partial class NewGameForm
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
            label1 = new Label();
            createBtn = new Button();
            cancelBtn = new Button();
            gameNameTextbox = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 0;
            label1.Text = "Game Name:";
            // 
            // createBtn
            // 
            createBtn.Location = new Point(81, 63);
            createBtn.Name = "createBtn";
            createBtn.Size = new Size(130, 33);
            createBtn.TabIndex = 1;
            createBtn.Text = "Create";
            createBtn.UseVisualStyleBackColor = true;
            createBtn.Click += createBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(295, 63);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(130, 33);
            cancelBtn.TabIndex = 2;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // gameNameTextbox
            // 
            gameNameTextbox.Location = new Point(94, 15);
            gameNameTextbox.Name = "gameNameTextbox";
            gameNameTextbox.Size = new Size(350, 23);
            gameNameTextbox.TabIndex = 3;
            // 
            // NewGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(491, 118);
            Controls.Add(gameNameTextbox);
            Controls.Add(cancelBtn);
            Controls.Add(createBtn);
            Controls.Add(label1);
            Name = "NewGameForm";
            Text = "NewGameForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button createBtn;
        private Button cancelBtn;
        private TextBox gameNameTextbox;
    }
}