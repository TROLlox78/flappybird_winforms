namespace flappybeard
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
            ground = new PictureBox();
            gameTimer = new System.Windows.Forms.Timer(components);
            debugMessage = new Label();
            ((System.ComponentModel.ISupportInitialize)ground).BeginInit();
            SuspendLayout();
            // 
            // ground
            // 
            ground.Image = Properties.Resources.ground;
            ground.Location = new Point(-113, 662);
            ground.Name = "ground";
            ground.Size = new Size(776, 385);
            ground.SizeMode = PictureBoxSizeMode.StretchImage;
            ground.TabIndex = 4;
            ground.TabStop = false;
            // 
            // gameTimer
            // 
            gameTimer.Enabled = true;
            gameTimer.Interval = 20;
            gameTimer.Tick += gameTimerEvent;
            // 
            // debugMessage
            // 
            debugMessage.AutoSize = true;
            debugMessage.Location = new Point(44, 54);
            debugMessage.Name = "debugMessage";
            debugMessage.Size = new Size(42, 15);
            debugMessage.TabIndex = 5;
            debugMessage.Text = "gayble";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(658, 780);
            Controls.Add(debugMessage);
            Controls.Add(ground);
            ForeColor = Color.AliceBlue;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += gameKeyIsDown;
            KeyPress += gameKeyPress;
            KeyUp += gameKeyIsUp;
            ((System.ComponentModel.ISupportInitialize)ground).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox ground;
        private System.Windows.Forms.Timer gameTimer;
        private Label debugMessage;
    }
}
