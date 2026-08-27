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
            SuspendLayout();
            // 
            // boardControl1
            // 
            boardControl1.Location = new Point(123, 25);
            boardControl1.Name = "boardControl1";
            boardControl1.Size = new Size(646, 601);
            boardControl1.TabIndex = 0;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1214, 682);
            Controls.Add(boardControl1);
            Name = "GameForm";
            Text = "Game Form";
            Load += GameForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private BoardControl boardControl1;
    }
}