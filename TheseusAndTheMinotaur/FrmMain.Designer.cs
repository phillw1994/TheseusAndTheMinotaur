namespace TheseusAndTheMinotaur
{
    partial class FrmMain
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
            this.btnGame = new System.Windows.Forms.Button();
            this.btnEditor = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGame
            // 
            this.btnGame.Location = new System.Drawing.Point(57, 26);
            this.btnGame.Name = "btnGame";
            this.btnGame.Size = new System.Drawing.Size(75, 23);
            this.btnGame.TabIndex = 0;
            this.btnGame.Text = "Game";
            this.btnGame.UseVisualStyleBackColor = true;
            this.btnGame.Click += new System.EventHandler(this.btnGame_Click);
            // 
            // btnEditor
            // 
            this.btnEditor.Location = new System.Drawing.Point(30, 93);
            this.btnEditor.Name = "btnEditor";
            this.btnEditor.Size = new System.Drawing.Size(75, 23);
            this.btnEditor.TabIndex = 1;
            this.btnEditor.Text = "Editor";
            this.btnEditor.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(155, 93);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 345);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEditor);
            this.Controls.Add(this.btnGame);
            this.Name = "FrmMain";
            this.Text = "Theseus and the Minotaur";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGame;
        private System.Windows.Forms.Button btnEditor;
        private System.Windows.Forms.Button btnClose;
    }
}