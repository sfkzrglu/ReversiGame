namespace Reversi_game
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            UpdateTimer = new System.Windows.Forms.Timer(components);
            whiteCountLabel = new Label();
            blackCountLabel = new Label();
            RestartButton = new Button();
            pvpButton = new Button();
            inGamePanel = new Panel();
            gobackmenuButton = new Button();
            menuPanel = new Panel();
            pvcButton = new Button();
            endGameWinnerLabel = new Label();
            inGamePanel.SuspendLayout();
            menuPanel.SuspendLayout();
            SuspendLayout();
            // 
            // UpdateTimer
            // 
            UpdateTimer.Interval = 10;
            UpdateTimer.Tick += update_Tick;
            // 
            // whiteCountLabel
            // 
            whiteCountLabel.AutoSize = true;
            whiteCountLabel.Location = new Point(3, 0);
            whiteCountLabel.Name = "whiteCountLabel";
            whiteCountLabel.Size = new Size(50, 15);
            whiteCountLabel.TabIndex = 1;
            whiteCountLabel.Text = "White: 2";
            // 
            // blackCountLabel
            // 
            blackCountLabel.AutoSize = true;
            blackCountLabel.Location = new Point(59, 0);
            blackCountLabel.Name = "blackCountLabel";
            blackCountLabel.Size = new Size(47, 15);
            blackCountLabel.TabIndex = 1;
            blackCountLabel.Text = "Black: 2";
            // 
            // RestartButton
            // 
            RestartButton.Location = new Point(3, 18);
            RestartButton.Name = "RestartButton";
            RestartButton.Size = new Size(119, 23);
            RestartButton.TabIndex = 2;
            RestartButton.Text = "Restart";
            RestartButton.UseVisualStyleBackColor = true;
            RestartButton.Click += RestartButton_Click;
            // 
            // pvpButton
            // 
            pvpButton.Location = new Point(3, 3);
            pvpButton.Name = "pvpButton";
            pvpButton.Size = new Size(119, 29);
            pvpButton.TabIndex = 3;
            pvpButton.Text = "Player vs Player";
            pvpButton.UseVisualStyleBackColor = true;
            pvpButton.Click += pvpButton_Click;
            // 
            // inGamePanel
            // 
            inGamePanel.Controls.Add(endGameWinnerLabel);
            inGamePanel.Controls.Add(gobackmenuButton);
            inGamePanel.Controls.Add(whiteCountLabel);
            inGamePanel.Controls.Add(blackCountLabel);
            inGamePanel.Controls.Add(RestartButton);
            inGamePanel.Location = new Point(12, 12);
            inGamePanel.Name = "inGamePanel";
            inGamePanel.Size = new Size(130, 131);
            inGamePanel.TabIndex = 4;
            // 
            // gobackmenuButton
            // 
            gobackmenuButton.Location = new Point(3, 47);
            gobackmenuButton.Name = "gobackmenuButton";
            gobackmenuButton.Size = new Size(119, 29);
            gobackmenuButton.TabIndex = 5;
            gobackmenuButton.Text = "back to menu";
            gobackmenuButton.UseVisualStyleBackColor = true;
            gobackmenuButton.Click += gobackmenuButton_Click;
            // 
            // menuPanel
            // 
            menuPanel.Controls.Add(pvcButton);
            menuPanel.Controls.Add(pvpButton);
            menuPanel.Location = new Point(12, 12);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(130, 79);
            menuPanel.TabIndex = 5;
            // 
            // pvcButton
            // 
            pvcButton.Location = new Point(3, 38);
            pvcButton.Name = "pvcButton";
            pvcButton.Size = new Size(119, 29);
            pvcButton.TabIndex = 4;
            pvcButton.Text = "Player vs Computer";
            pvcButton.UseVisualStyleBackColor = true;
            pvcButton.Click += pvcButton_Click;
            // 
            // endGameWinnerLabel
            // 
            endGameWinnerLabel.AutoSize = true;
            endGameWinnerLabel.Location = new Point(3, 91);
            endGameWinnerLabel.Name = "endGameWinnerLabel";
            endGameWinnerLabel.Size = new Size(84, 15);
            endGameWinnerLabel.TabIndex = 6;
            endGameWinnerLabel.Text = "who won label";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1004, 801);
            Controls.Add(menuPanel);
            Controls.Add(inGamePanel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            StartPosition = FormStartPosition.Manual;
            Text = "Reversi";
            Load += Form1_Load;
            inGamePanel.ResumeLayout(false);
            inGamePanel.PerformLayout();
            menuPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer UpdateTimer;
        private Label whiteCountLabel;
        private Label blackCountLabel;
        private Button RestartButton;
        private Button pvpButton;
        private Panel inGamePanel;
        private Panel menuPanel;
        private Button pvcButton;
        private Button gobackmenuButton;
        private Label endGameWinnerLabel;
    }
}
