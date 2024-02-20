using System.ComponentModel;

namespace GetosDirtLocker.gui


{
    partial class LockerAdditionInterface
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
            this.Frame = new System.Windows.Forms.Panel();
            this.PictureLoading = new System.Windows.Forms.PictureBox();
            this.TextBoxAdditionalNotes = new GetosDirtLocker.controls.BetterTextBox();
            this.TextBoxAttachmentURL = new GetosDirtLocker.controls.BetterTextBox();
            this.TextBoxUserUUID = new GetosDirtLocker.controls.BetterTextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.ljihgvfyc = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Frame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // Frame
            // 
            this.Frame.Controls.Add(this.PictureLoading);
            this.Frame.Controls.Add(this.TextBoxAdditionalNotes);
            this.Frame.Controls.Add(this.TextBoxAttachmentURL);
            this.Frame.Controls.Add(this.TextBoxUserUUID);
            this.Frame.Controls.Add(this.buttonAdd);
            this.Frame.Controls.Add(this.ljihgvfyc);
            this.Frame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Frame.Location = new System.Drawing.Point(0, 24);
            this.Frame.Name = "Frame";
            this.Frame.Size = new System.Drawing.Size(734, 387);
            this.Frame.TabIndex = 0;
            // 
            // PictureLoading
            // 
            this.PictureLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureLoading.Location = new System.Drawing.Point(582, 13);
            this.PictureLoading.Name = "PictureLoading";
            this.PictureLoading.Size = new System.Drawing.Size(46, 46);
            this.PictureLoading.TabIndex = 9;
            this.PictureLoading.TabStop = false;
            // 
            // TextBoxAdditionalNotes
            // 
            this.TextBoxAdditionalNotes.Enabled = false;
            this.TextBoxAdditionalNotes.Location = new System.Drawing.Point(281, 13);
            this.TextBoxAdditionalNotes.Multiline = true;
            this.TextBoxAdditionalNotes.Name = "TextBoxAdditionalNotes";
            this.TextBoxAdditionalNotes.PlaceholderText = "Additional Notes";
            this.TextBoxAdditionalNotes.PlaceholderTextColor = System.Drawing.Color.Gray;
            this.TextBoxAdditionalNotes.Size = new System.Drawing.Size(295, 46);
            this.TextBoxAdditionalNotes.TabIndex = 7;
            // 
            // TextBoxAttachmentURL
            // 
            this.TextBoxAttachmentURL.Enabled = false;
            this.TextBoxAttachmentURL.Location = new System.Drawing.Point(9, 39);
            this.TextBoxAttachmentURL.Name = "TextBoxAttachmentURL";
            this.TextBoxAttachmentURL.PlaceholderText = "Attachment URL";
            this.TextBoxAttachmentURL.PlaceholderTextColor = System.Drawing.Color.Gray;
            this.TextBoxAttachmentURL.Size = new System.Drawing.Size(266, 20);
            this.TextBoxAttachmentURL.TabIndex = 6;
            // 
            // TextBoxUserUUID
            // 
            this.TextBoxUserUUID.Enabled = false;
            this.TextBoxUserUUID.Location = new System.Drawing.Point(9, 13);
            this.TextBoxUserUUID.Name = "TextBoxUserUUID";
            this.TextBoxUserUUID.PlaceholderText = "User UUID";
            this.TextBoxUserUUID.PlaceholderTextColor = System.Drawing.Color.Gray;
            this.TextBoxUserUUID.Size = new System.Drawing.Size(266, 20);
            this.TextBoxUserUUID.TabIndex = 5;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonAdd.Enabled = false;
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(634, 13);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(86, 46);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "+";
            this.buttonAdd.UseVisualStyleBackColor = false;
            // 
            // ljihgvfyc
            // 
            this.ljihgvfyc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ljihgvfyc.Location = new System.Drawing.Point(10, 66);
            this.ljihgvfyc.Name = "ljihgvfyc";
            this.ljihgvfyc.Size = new System.Drawing.Size(710, 1);
            this.ljihgvfyc.TabIndex = 0;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // LockerAdditionInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 411);
            this.Controls.Add(this.Frame);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LockerAdditionInterface";
            this.Frame.ResumeLayout(false);
            this.Frame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public System.Windows.Forms.PictureBox PictureLoading;

        private GetosDirtLocker.controls.BetterTextBox TextBoxAttachmentURL;
        private GetosDirtLocker.controls.BetterTextBox TextBoxAdditionalNotes;

        private GetosDirtLocker.controls.BetterTextBox TextBoxUserUUID;

        private System.Windows.Forms.Button buttonAdd;

        private System.Windows.Forms.Label ljihgvfyc;

        private System.Windows.Forms.MenuStrip menuStrip1;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

        private System.Windows.Forms.Panel Frame;

        #endregion
    }
}