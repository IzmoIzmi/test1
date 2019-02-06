namespace test1
{
    partial class TwiPicFrame
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labFavorite = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labRetweet = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labReply = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 232);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labFavorite
            // 
            this.labFavorite.AutoSize = true;
            this.labFavorite.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFavorite.Location = new System.Drawing.Point(331, 40);
            this.labFavorite.Name = "labFavorite";
            this.labFavorite.Size = new System.Drawing.Size(15, 18);
            this.labFavorite.TabIndex = 1;
            this.labFavorite.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(270, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "fav";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(270, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "retweet";
            // 
            // labRetweet
            // 
            this.labRetweet.AutoSize = true;
            this.labRetweet.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRetweet.Location = new System.Drawing.Point(331, 72);
            this.labRetweet.Name = "labRetweet";
            this.labRetweet.Size = new System.Drawing.Size(15, 18);
            this.labRetweet.TabIndex = 3;
            this.labRetweet.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(270, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "reply";
            // 
            // labReply
            // 
            this.labReply.AutoSize = true;
            this.labReply.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labReply.Location = new System.Drawing.Point(331, 108);
            this.labReply.Name = "labReply";
            this.labReply.Size = new System.Drawing.Size(15, 18);
            this.labReply.TabIndex = 5;
            this.labReply.Text = "0";
            // 
            // TwiPicFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 252);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labReply);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labRetweet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labFavorite);
            this.Controls.Add(this.pictureBox1);
            this.Name = "TwiPicFrame";
            this.Load += new System.EventHandler(this.TwiPicFrame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labFavorite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labRetweet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labReply;
    }
}