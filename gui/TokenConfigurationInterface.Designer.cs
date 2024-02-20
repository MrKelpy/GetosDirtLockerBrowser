using System.ComponentModel;

namespace GetosDirtLocker.gui
{
    partial class TokenConfigurationInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TokenConfigurationInterface));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Frame = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxToken = new GetosDirtLocker.controls.BetterTextBox();
            this.Frame.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Frame
            // 
            this.Frame.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Frame.Controls.Add(this.label1);
            this.Frame.Controls.Add(this.TextBoxToken);
            this.Frame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Frame.Location = new System.Drawing.Point(0, 24);
            this.Frame.Name = "Frame";
            this.Frame.Size = new System.Drawing.Size(734, 387);
            this.Frame.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(710, 283);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextBoxToken
            // 
            this.TextBoxToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxToken.Location = new System.Drawing.Point(12, 23);
            this.TextBoxToken.Name = "TextBoxToken";
            this.TextBoxToken.PlaceholderText = " Insert your discord token here";
            this.TextBoxToken.PlaceholderTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TextBoxToken.Size = new System.Drawing.Size(710, 31);
            this.TextBoxToken.TabIndex = 0;
            // 
            // TokenConfigurationInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 411);
            this.Controls.Add(this.Frame);
            this.Controls.Add(this.menuStrip1);
            this.Name = "TokenConfigurationInterface";
            this.Frame.ResumeLayout(false);
            this.Frame.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;

        public GetosDirtLocker.controls.BetterTextBox TextBoxToken;

        private System.Windows.Forms.Panel Frame;

        private System.Windows.Forms.MenuStrip menuStrip1;

        #endregion
    }
}