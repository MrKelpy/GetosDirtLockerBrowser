using System.ComponentModel;

namespace GetosDirtLocker.gui
{
    partial class DirtLookupInterface
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.TextBoxNotesLookup = new GetosDirtLocker.controls.BetterTextBox();
            this.TextBoxUserUUIDLookup = new GetosDirtLocker.controls.BetterTextBox();
            this.TextBoxIndexLookup = new GetosDirtLocker.controls.BetterTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Frame.SuspendLayout();
            this.SuspendLayout();
            // 
            // Frame
            // 
            this.Frame.Controls.Add(this.panel1);
            this.Frame.Controls.Add(this.TextBoxNotesLookup);
            this.Frame.Controls.Add(this.TextBoxUserUUIDLookup);
            this.Frame.Controls.Add(this.TextBoxIndexLookup);
            this.Frame.Controls.Add(this.label1);
            this.Frame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Frame.Location = new System.Drawing.Point(0, 24);
            this.Frame.Name = "Frame";
            this.Frame.Size = new System.Drawing.Size(734, 387);
            this.Frame.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(11, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 331);
            this.panel1.TabIndex = 11;
            // 
            // TextBoxNotesLookup
            // 
            this.TextBoxNotesLookup.Location = new System.Drawing.Point(488, 17);
            this.TextBoxNotesLookup.Name = "TextBoxNotesLookup";
            this.TextBoxNotesLookup.PlaceholderText = "Additional Notes";
            this.TextBoxNotesLookup.PlaceholderTextColor = System.Drawing.Color.Gray;
            this.TextBoxNotesLookup.Size = new System.Drawing.Size(234, 20);
            this.TextBoxNotesLookup.TabIndex = 10;
            // 
            // TextBoxUserUUIDLookup
            // 
            this.TextBoxUserUUIDLookup.Location = new System.Drawing.Point(248, 17);
            this.TextBoxUserUUIDLookup.Name = "TextBoxUserUUIDLookup";
            this.TextBoxUserUUIDLookup.PlaceholderText = "User UUID";
            this.TextBoxUserUUIDLookup.PlaceholderTextColor = System.Drawing.Color.Gray;
            this.TextBoxUserUUIDLookup.Size = new System.Drawing.Size(234, 20);
            this.TextBoxUserUUIDLookup.TabIndex = 9;
            // 
            // TextBoxIndexLookup
            // 
            this.TextBoxIndexLookup.Location = new System.Drawing.Point(11, 17);
            this.TextBoxIndexLookup.Name = "TextBoxIndexLookup";
            this.TextBoxIndexLookup.PlaceholderText = "Indexation ID";
            this.TextBoxIndexLookup.PlaceholderTextColor = System.Drawing.Color.Gray;
            this.TextBoxIndexLookup.Size = new System.Drawing.Size(231, 20);
            this.TextBoxIndexLookup.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(710, 1);
            this.label1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // DirtLookupInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 411);
            this.Controls.Add(this.Frame);
            this.Controls.Add(this.menuStrip1);
            this.Name = "DirtLookupInterface";
            this.Text = "DirtLookup";
            this.Frame.ResumeLayout(false);
            this.Frame.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel panel1;

        private GetosDirtLocker.controls.BetterTextBox TextBoxIndexLookup;
        private GetosDirtLocker.controls.BetterTextBox TextBoxNotesLookup;

        private System.Windows.Forms.Panel Frame;
        private GetosDirtLocker.controls.BetterTextBox TextBoxUserUUIDLookup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;

        #endregion
    }
}