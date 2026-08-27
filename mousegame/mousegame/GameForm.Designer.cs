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
            SuspendLayout();
            // 
            // boardControl1
            // 
            boardControl1.Location = new Point(12, 22);
            boardControl1.Name = "boardControl1";
            boardControl1.Size = new Size(646, 585);
            boardControl1.TabIndex = 0;
            // 
            // prototypeLabel
            // 
            prototypeLabel.AutoSize = true;
            prototypeLabel.Location = new Point(12, 9);
            prototypeLabel.Name = "prototypeLabel";
            prototypeLabel.Size = new Size(621, 15);
            prototypeLabel.TabIndex = 1;
            prototypeLabel.Text = "This form uses the game DAO connection on load to retrive the tiles in the tile table, clicking a tile will show its tile_id";
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1041, 682);
            Controls.Add(prototypeLabel);
            Controls.Add(boardControl1);
            Name = "GameForm";
            Text = "Game Form";
            Load += GameForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BoardControl boardControl1;
        private Label prototypeLabel;
    }
}