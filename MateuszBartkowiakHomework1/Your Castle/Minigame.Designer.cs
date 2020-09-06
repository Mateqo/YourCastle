namespace MateuszBartkowiakHomework1
{
    partial class Minigame
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
            this.components = new System.ComponentModel.Container();
            this.timerStart = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxHorse = new System.Windows.Forms.PictureBox();
            this.labelEnd = new System.Windows.Forms.Label();
            this.pictureBoxEmerald1 = new System.Windows.Forms.PictureBox();
            this.labelEmeraldsResult = new System.Windows.Forms.Label();
            this.pictureBoxTreeLeft5 = new System.Windows.Forms.PictureBox();
            this.pictureBoxTreeLeft4 = new System.Windows.Forms.PictureBox();
            this.pictureBoxTreeLeft3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxTreeLeft2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxTreeLeft1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxTreeRight1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxTreeRight2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxTreeRight3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxTreeRight4 = new System.Windows.Forms.PictureBox();
            this.pictureBoxTreeRight5 = new System.Windows.Forms.PictureBox();
            this.pictureBoxEmerald = new System.Windows.Forms.PictureBox();
            this.pictureBoxControls = new System.Windows.Forms.PictureBox();
            this.labelControls = new System.Windows.Forms.Label();
            this.lalebEmeralds = new System.Windows.Forms.Label();
            this.pictureBoxEnemy2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxEnemy1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxEnemy3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxEmerald3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxEmerald2 = new System.Windows.Forms.PictureBox();
            this.buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHorse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmerald1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeLeft5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeLeft4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeLeft3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeLeft2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeLeft1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeRight1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeRight2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeRight3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeRight4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeRight5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmerald)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxControls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnemy2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnemy1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnemy3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmerald3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmerald2)).BeginInit();
            this.SuspendLayout();
            // 
            // timerStart
            // 
            this.timerStart.Interval = 10;
            this.timerStart.Tick += new System.EventHandler(this.TimerStart_Tick);
            // 
            // pictureBoxHorse
            // 
            this.pictureBoxHorse.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxHorse.BackgroundImage = global::MateuszBartkowiakHomework1.Properties.Resources.Horse;
            this.pictureBoxHorse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxHorse.Location = new System.Drawing.Point(315, 405);
            this.pictureBoxHorse.Name = "pictureBoxHorse";
            this.pictureBoxHorse.Size = new System.Drawing.Size(64, 103);
            this.pictureBoxHorse.TabIndex = 6;
            this.pictureBoxHorse.TabStop = false;
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.BackColor = System.Drawing.Color.Transparent;
            this.labelEnd.Font = new System.Drawing.Font("Monotype Corsiva", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEnd.ForeColor = System.Drawing.Color.DarkRed;
            this.labelEnd.Location = new System.Drawing.Point(161, -4);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(364, 97);
            this.labelEnd.TabIndex = 9;
            this.labelEnd.Text = "Game Over";
            this.labelEnd.Visible = false;
            // 
            // pictureBoxEmerald1
            // 
            this.pictureBoxEmerald1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEmerald1.BackgroundImage = global::MateuszBartkowiakHomework1.Properties.Resources.Emerald;
            this.pictureBoxEmerald1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxEmerald1.Location = new System.Drawing.Point(178, 117);
            this.pictureBoxEmerald1.Name = "pictureBoxEmerald1";
            this.pictureBoxEmerald1.Size = new System.Drawing.Size(38, 36);
            this.pictureBoxEmerald1.TabIndex = 10;
            this.pictureBoxEmerald1.TabStop = false;
            // 
            // labelEmeraldsResult
            // 
            this.labelEmeraldsResult.AutoSize = true;
            this.labelEmeraldsResult.BackColor = System.Drawing.Color.Transparent;
            this.labelEmeraldsResult.Font = new System.Drawing.Font("Monotype Corsiva", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEmeraldsResult.ForeColor = System.Drawing.Color.Blue;
            this.labelEmeraldsResult.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.labelEmeraldsResult.Location = new System.Drawing.Point(484, 616);
            this.labelEmeraldsResult.Name = "labelEmeraldsResult";
            this.labelEmeraldsResult.Size = new System.Drawing.Size(41, 40);
            this.labelEmeraldsResult.TabIndex = 11;
            this.labelEmeraldsResult.Text = "0 ";
            // 
            // pictureBoxTreeLeft5
            // 
            this.pictureBoxTreeLeft5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTreeLeft5.BackgroundImage = global::MateuszBartkowiakHomework1.Properties.Resources.Tree;
            this.pictureBoxTreeLeft5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxTreeLeft5.Location = new System.Drawing.Point(-1, 415);
            this.pictureBoxTreeLeft5.Name = "pictureBoxTreeLeft5";
            this.pictureBoxTreeLeft5.Size = new System.Drawing.Size(91, 82);
            this.pictureBoxTreeLeft5.TabIndex = 12;
            this.pictureBoxTreeLeft5.TabStop = false;
            // 
            // pictureBoxTreeLeft4
            // 
            this.pictureBoxTreeLeft4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTreeLeft4.BackgroundImage = global::MateuszBartkowiakHomework1.Properties.Resources.Tree;
            this.pictureBoxTreeLeft4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxTreeLeft4.Location = new System.Drawing.Point(-1, 295);
            this.pictureBoxTreeLeft4.Name = "pictureBoxTreeLeft4";
            this.pictureBoxTreeLeft4.Size = new System.Drawing.Size(91, 82);
            this.pictureBoxTreeLeft4.TabIndex = 13;
            this.pictureBoxTreeLeft4.TabStop = false;
            // 
            // pictureBoxTreeLeft3
            // 
            this.pictureBoxTreeLeft3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTreeLeft3.BackgroundImage = global::MateuszBartkowiakHomework1.Properties.Resources.Tree;
            this.pictureBoxTreeLeft3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxTreeLeft3.Location = new System.Drawing.Point(-1, 184);
            this.pictureBoxTreeLeft3.Name = "pictureBoxTreeLeft3";
            this.pictureBoxTreeLeft3.Size = new System.Drawing.Size(91, 82);
            this.pictureBoxTreeLeft3.TabIndex = 14;
            this.pictureBoxTreeLeft3.TabStop = false;
            // 
            // pictureBoxTreeLeft2
            // 
            this.pictureBoxTreeLeft2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTreeLeft2.BackgroundImage = global::MateuszBartkowiakHomework1.Properties.Resources.Tree;
            this.pictureBoxTreeLeft2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxTreeLeft2.Location = new System.Drawing.Point(-1, 71);
            this.pictureBoxTreeLeft2.Name = "pictureBoxTreeLeft2";
            this.pictureBoxTreeLeft2.Size = new System.Drawing.Size(91, 82);
            this.pictureBoxTreeLeft2.TabIndex = 15;
            this.pictureBoxTreeLeft2.TabStop = false;
            // 
            // pictureBoxTreeLeft1
            // 
            this.pictureBoxTreeLeft1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTreeLeft1.BackgroundImage = global::MateuszBartkowiakHomework1.Properties.Resources.Tree;
            this.pictureBoxTreeLeft1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxTreeLeft1.Location = new System.Drawing.Point(-1, -46);
            this.pictureBoxTreeLeft1.Name = "pictureBoxTreeLeft1";
            this.pictureBoxTreeLeft1.Size = new System.Drawing.Size(91, 82);
            this.pictureBoxTreeLeft1.TabIndex = 16;
            this.pictureBoxTreeLeft1.TabStop = false;
            // 
            // pictureBoxTreeRight1
            // 
            this.pictureBoxTreeRight1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTreeRight1.BackgroundImage = global::MateuszBartkowiakHomework1.Properties.Resources.Tree;
            this.pictureBoxTreeRight1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxTreeRight1.Location = new System.Drawing.Point(597, -46);
            this.pictureBoxTreeRight1.Name = "pictureBoxTreeRight1";
            this.pictureBoxTreeRight1.Size = new System.Drawing.Size(91, 82);
            this.pictureBoxTreeRight1.TabIndex = 22;
            this.pictureBoxTreeRight1.TabStop = false;
            // 
            // pictureBoxTreeRight2
            // 
            this.pictureBoxTreeRight2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTreeRight2.BackgroundImage = global::MateuszBartkowiakHomework1.Properties.Resources.Tree;
            this.pictureBoxTreeRight2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxTreeRight2.Location = new System.Drawing.Point(597, 71);
            this.pictureBoxTreeRight2.Name = "pictureBoxTreeRight2";
            this.pictureBoxTreeRight2.Size = new System.Drawing.Size(91, 82);
            this.pictureBoxTreeRight2.TabIndex = 21;
            this.pictureBoxTreeRight2.TabStop = false;
            // 
            // pictureBoxTreeRight3
            // 
            this.pictureBoxTreeRight3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTreeRight3.BackgroundImage = global::MateuszBartkowiakHomework1.Properties.Resources.Tree;
            this.pictureBoxTreeRight3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxTreeRight3.Location = new System.Drawing.Point(597, 184);
            this.pictureBoxTreeRight3.Name = "pictureBoxTreeRight3";
            this.pictureBoxTreeRight3.Size = new System.Drawing.Size(91, 82);
            this.pictureBoxTreeRight3.TabIndex = 20;
            this.pictureBoxTreeRight3.TabStop = false;
            // 
            // pictureBoxTreeRight4
            // 
            this.pictureBoxTreeRight4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTreeRight4.BackgroundImage = global::MateuszBartkowiakHomework1.Properties.Resources.Tree;
            this.pictureBoxTreeRight4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxTreeRight4.Location = new System.Drawing.Point(597, 295);
            this.pictureBoxTreeRight4.Name = "pictureBoxTreeRight4";
            this.pictureBoxTreeRight4.Size = new System.Drawing.Size(91, 82);
            this.pictureBoxTreeRight4.TabIndex = 19;
            this.pictureBoxTreeRight4.TabStop = false;
            // 
            // pictureBoxTreeRight5
            // 
            this.pictureBoxTreeRight5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTreeRight5.BackgroundImage = global::MateuszBartkowiakHomework1.Properties.Resources.Tree;
            this.pictureBoxTreeRight5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxTreeRight5.Location = new System.Drawing.Point(597, 415);
            this.pictureBoxTreeRight5.Name = "pictureBoxTreeRight5";
            this.pictureBoxTreeRight5.Size = new System.Drawing.Size(91, 82);
            this.pictureBoxTreeRight5.TabIndex = 18;
            this.pictureBoxTreeRight5.TabStop = false;
            // 
            // pictureBoxEmerald
            // 
            this.pictureBoxEmerald.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEmerald.BackgroundImage = global::MateuszBartkowiakHomework1.Properties.Resources.Emerald;
            this.pictureBoxEmerald.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxEmerald.Location = new System.Drawing.Point(465, 560);
            this.pictureBoxEmerald.Name = "pictureBoxEmerald";
            this.pictureBoxEmerald.Size = new System.Drawing.Size(78, 53);
            this.pictureBoxEmerald.TabIndex = 24;
            this.pictureBoxEmerald.TabStop = false;
            // 
            // pictureBoxControls
            // 
            this.pictureBoxControls.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxControls.BackgroundImage = global::MateuszBartkowiakHomework1.Properties.Resources.Keys;
            this.pictureBoxControls.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxControls.Location = new System.Drawing.Point(124, 560);
            this.pictureBoxControls.Name = "pictureBoxControls";
            this.pictureBoxControls.Size = new System.Drawing.Size(119, 81);
            this.pictureBoxControls.TabIndex = 25;
            this.pictureBoxControls.TabStop = false;
            // 
            // labelControls
            // 
            this.labelControls.AutoSize = true;
            this.labelControls.BackColor = System.Drawing.Color.Transparent;
            this.labelControls.Font = new System.Drawing.Font("Monotype Corsiva", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelControls.ForeColor = System.Drawing.Color.Blue;
            this.labelControls.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.labelControls.Location = new System.Drawing.Point(107, 514);
            this.labelControls.Name = "labelControls";
            this.labelControls.Size = new System.Drawing.Size(157, 40);
            this.labelControls.TabIndex = 26;
            this.labelControls.Text = "Sterowanie";
            // 
            // lalebEmeralds
            // 
            this.lalebEmeralds.AutoSize = true;
            this.lalebEmeralds.BackColor = System.Drawing.Color.Transparent;
            this.lalebEmeralds.Font = new System.Drawing.Font("Monotype Corsiva", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lalebEmeralds.ForeColor = System.Drawing.Color.Blue;
            this.lalebEmeralds.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lalebEmeralds.Location = new System.Drawing.Point(426, 514);
            this.lalebEmeralds.Name = "lalebEmeralds";
            this.lalebEmeralds.Size = new System.Drawing.Size(155, 40);
            this.lalebEmeralds.TabIndex = 27;
            this.lalebEmeralds.Text = "Szmaragdy";
            // 
            // pictureBoxEnemy2
            // 
            this.pictureBoxEnemy2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEnemy2.BackgroundImage = global::MateuszBartkowiakHomework1.Properties.Resources.Enemy;
            this.pictureBoxEnemy2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxEnemy2.Location = new System.Drawing.Point(294, 241);
            this.pictureBoxEnemy2.Name = "pictureBoxEnemy2";
            this.pictureBoxEnemy2.Size = new System.Drawing.Size(64, 70);
            this.pictureBoxEnemy2.TabIndex = 29;
            this.pictureBoxEnemy2.TabStop = false;
            // 
            // pictureBoxEnemy1
            // 
            this.pictureBoxEnemy1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEnemy1.BackgroundImage = global::MateuszBartkowiakHomework1.Properties.Resources.Enemy;
            this.pictureBoxEnemy1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxEnemy1.Location = new System.Drawing.Point(167, 12);
            this.pictureBoxEnemy1.Name = "pictureBoxEnemy1";
            this.pictureBoxEnemy1.Size = new System.Drawing.Size(64, 70);
            this.pictureBoxEnemy1.TabIndex = 30;
            this.pictureBoxEnemy1.TabStop = false;
            // 
            // pictureBoxEnemy3
            // 
            this.pictureBoxEnemy3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEnemy3.BackgroundImage = global::MateuszBartkowiakHomework1.Properties.Resources.Enemy;
            this.pictureBoxEnemy3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxEnemy3.Location = new System.Drawing.Point(479, 106);
            this.pictureBoxEnemy3.Name = "pictureBoxEnemy3";
            this.pictureBoxEnemy3.Size = new System.Drawing.Size(64, 70);
            this.pictureBoxEnemy3.TabIndex = 31;
            this.pictureBoxEnemy3.TabStop = false;
            // 
            // pictureBoxEmerald3
            // 
            this.pictureBoxEmerald3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEmerald3.BackgroundImage = global::MateuszBartkowiakHomework1.Properties.Resources.Emerald;
            this.pictureBoxEmerald3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxEmerald3.Location = new System.Drawing.Point(433, 46);
            this.pictureBoxEmerald3.Name = "pictureBoxEmerald3";
            this.pictureBoxEmerald3.Size = new System.Drawing.Size(38, 36);
            this.pictureBoxEmerald3.TabIndex = 32;
            this.pictureBoxEmerald3.TabStop = false;
            // 
            // pictureBoxEmerald2
            // 
            this.pictureBoxEmerald2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEmerald2.BackgroundImage = global::MateuszBartkowiakHomework1.Properties.Resources.Emerald;
            this.pictureBoxEmerald2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxEmerald2.Location = new System.Drawing.Point(294, 12);
            this.pictureBoxEmerald2.Name = "pictureBoxEmerald2";
            this.pictureBoxEmerald2.Size = new System.Drawing.Size(38, 36);
            this.pictureBoxEmerald2.TabIndex = 33;
            this.pictureBoxEmerald2.TabStop = false;
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Moccasin;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonStart.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonStart.Location = new System.Drawing.Point(294, 573);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(117, 40);
            this.buttonStart.TabIndex = 34;
            this.buttonStart.Text = "Zagraj";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            this.buttonStart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ButtonStart_KeyDown);
            // 
            // Minigame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MateuszBartkowiakHomework1.Properties.Resources.Minigame_Bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(682, 653);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.pictureBoxEmerald2);
            this.Controls.Add(this.pictureBoxEmerald3);
            this.Controls.Add(this.pictureBoxEnemy3);
            this.Controls.Add(this.pictureBoxEnemy1);
            this.Controls.Add(this.pictureBoxEnemy2);
            this.Controls.Add(this.lalebEmeralds);
            this.Controls.Add(this.labelControls);
            this.Controls.Add(this.pictureBoxControls);
            this.Controls.Add(this.pictureBoxEmerald);
            this.Controls.Add(this.pictureBoxTreeRight1);
            this.Controls.Add(this.pictureBoxTreeRight2);
            this.Controls.Add(this.pictureBoxTreeRight3);
            this.Controls.Add(this.pictureBoxTreeRight4);
            this.Controls.Add(this.pictureBoxTreeRight5);
            this.Controls.Add(this.pictureBoxTreeLeft1);
            this.Controls.Add(this.pictureBoxTreeLeft2);
            this.Controls.Add(this.pictureBoxTreeLeft3);
            this.Controls.Add(this.pictureBoxTreeLeft4);
            this.Controls.Add(this.pictureBoxTreeLeft5);
            this.Controls.Add(this.labelEmeraldsResult);
            this.Controls.Add(this.pictureBoxEmerald1);
            this.Controls.Add(this.labelEnd);
            this.Controls.Add(this.pictureBoxHorse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Minigame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minigame";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHorse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmerald1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeLeft5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeLeft4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeLeft3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeLeft2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeLeft1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeRight1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeRight2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeRight3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeRight4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeRight5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmerald)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxControls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnemy2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnemy1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnemy3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmerald3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmerald2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerStart;
        private System.Windows.Forms.PictureBox pictureBoxHorse;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.PictureBox pictureBoxEmerald1;
        private System.Windows.Forms.Label labelEmeraldsResult;
        private System.Windows.Forms.PictureBox pictureBoxTreeLeft5;
        private System.Windows.Forms.PictureBox pictureBoxTreeLeft4;
        private System.Windows.Forms.PictureBox pictureBoxTreeLeft3;
        private System.Windows.Forms.PictureBox pictureBoxTreeLeft2;
        private System.Windows.Forms.PictureBox pictureBoxTreeLeft1;
        private System.Windows.Forms.PictureBox pictureBoxTreeRight1;
        private System.Windows.Forms.PictureBox pictureBoxTreeRight2;
        private System.Windows.Forms.PictureBox pictureBoxTreeRight3;
        private System.Windows.Forms.PictureBox pictureBoxTreeRight4;
        private System.Windows.Forms.PictureBox pictureBoxTreeRight5;
        private System.Windows.Forms.PictureBox pictureBoxEmerald;
        private System.Windows.Forms.PictureBox pictureBoxControls;
        private System.Windows.Forms.Label labelControls;
        private System.Windows.Forms.Label lalebEmeralds;
        private System.Windows.Forms.PictureBox pictureBoxEnemy2;
        private System.Windows.Forms.PictureBox pictureBoxEnemy1;
        private System.Windows.Forms.PictureBox pictureBoxEnemy3;
        private System.Windows.Forms.PictureBox pictureBoxEmerald3;
        private System.Windows.Forms.PictureBox pictureBoxEmerald2;
        private System.Windows.Forms.Button buttonStart;
    }
}