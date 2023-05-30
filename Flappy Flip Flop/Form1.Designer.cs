namespace Flappy_Flip_Flop
{
    partial class mainWindow
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
            gameTimer = new System.Windows.Forms.Timer(components);
            lblDisplay = new Label();
            ground = new PictureBox();
            selectLeft = new PictureBox();
            selectMiddle = new PictureBox();
            selectRight = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)ground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)selectLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)selectMiddle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)selectRight).BeginInit();
            SuspendLayout();
            // 
            // gameTimer
            // 
            gameTimer.Interval = 6;
            gameTimer.Tick += gameTimerEvent;
            // 
            // lblDisplay
            // 
            lblDisplay.Anchor = AnchorStyles.None;
            lblDisplay.AutoSize = true;
            lblDisplay.BackColor = Color.Transparent;
            lblDisplay.Font = new Font("Agency FB", 30F, FontStyle.Bold, GraphicsUnit.Point);
            lblDisplay.ForeColor = SystemColors.HotTrack;
            lblDisplay.Location = new Point(329, 80);
            lblDisplay.Name = "lblDisplay";
            lblDisplay.RightToLeft = RightToLeft.No;
            lblDisplay.Size = new Size(402, 61);
            lblDisplay.TabIndex = 3;
            lblDisplay.Text = "Press ENTER to start!";
            lblDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ground
            // 
            ground.Anchor = AnchorStyles.None;
            ground.BackColor = SystemColors.ControlDarkDark;
            ground.Enabled = false;
            ground.Location = new Point(0, 718);
            ground.Name = "ground";
            ground.Size = new Size(1100, 50);
            ground.TabIndex = 4;
            ground.TabStop = false;
            // 
            // selectLeft
            // 
            selectLeft.BackColor = SystemColors.ActiveBorder;
            selectLeft.Cursor = Cursors.Hand;
            selectLeft.Location = new Point(152, 306);
            selectLeft.Name = "selectLeft";
            selectLeft.Size = new Size(100, 100);
            selectLeft.TabIndex = 5;
            selectLeft.TabStop = false;
            selectLeft.Click += selectLeft_Click;
            // 
            // selectMiddle
            // 
            selectMiddle.BackColor = SystemColors.ActiveBorder;
            selectMiddle.Cursor = Cursors.Hand;
            selectMiddle.Location = new Point(444, 306);
            selectMiddle.Name = "selectMiddle";
            selectMiddle.Size = new Size(100, 100);
            selectMiddle.TabIndex = 6;
            selectMiddle.TabStop = false;
            selectMiddle.Click += selectMiddle_Click;
            // 
            // selectRight
            // 
            selectRight.BackColor = SystemColors.ActiveBorder;
            selectRight.Cursor = Cursors.Hand;
            selectRight.Location = new Point(709, 306);
            selectRight.Name = "selectRight";
            selectRight.Size = new Size(100, 100);
            selectRight.TabIndex = 7;
            selectRight.TabStop = false;
            selectRight.Click += selectRight_Click;
            // 
            // mainWindow
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1024, 768);
            Controls.Add(selectRight);
            Controls.Add(selectMiddle);
            Controls.Add(selectLeft);
            Controls.Add(lblDisplay);
            Controls.Add(ground);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1024, 768);
            MinimumSize = new Size(1024, 768);
            Name = "mainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Flappy Flip Flop";
            Load += mainWindow_Load;
            KeyDown += keyDownEvent;
            ((System.ComponentModel.ISupportInitialize)ground).EndInit();
            ((System.ComponentModel.ISupportInitialize)selectLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)selectMiddle).EndInit();
            ((System.ComponentModel.ISupportInitialize)selectRight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer gameTimer;
        private Label lblDisplay;
        private PictureBox ground;
        private PictureBox selectLeft;
        private PictureBox selectMiddle;
        private PictureBox selectRight;
    }
}