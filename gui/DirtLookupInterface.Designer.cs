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
            this.GridDirt = new System.Windows.Forms.DataGridView();
            this.UserPicture = new System.Windows.Forms.DataGridViewImageColumn();
            this.Information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dirt = new System.Windows.Forms.DataGridViewImageColumn();
            this.TextBoxNotesLookup = new GetosDirtLocker.controls.BetterTextBox();
            this.TextBoxUserUUIDLookup = new GetosDirtLocker.controls.BetterTextBox();
            this.TextBoxIndexLookup = new GetosDirtLocker.controls.BetterTextBox();
            this.mionjnl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Frame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDirt)).BeginInit();
            this.SuspendLayout();
            // 
            // Frame
            // 
            this.Frame.Controls.Add(this.GridDirt);
            this.Frame.Controls.Add(this.TextBoxNotesLookup);
            this.Frame.Controls.Add(this.TextBoxUserUUIDLookup);
            this.Frame.Controls.Add(this.TextBoxIndexLookup);
            this.Frame.Controls.Add(this.mionjnl);
            this.Frame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Frame.Location = new System.Drawing.Point(0, 24);
            this.Frame.Name = "Frame";
            this.Frame.Size = new System.Drawing.Size(734, 387);
            this.Frame.TabIndex = 2;
            // 
            // GridDirt
            // 
            this.GridDirt.AllowUserToAddRows = false;
            this.GridDirt.AllowUserToDeleteRows = false;
            this.GridDirt.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.GridDirt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridDirt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDirt.ColumnHeadersVisible = false;
            this.GridDirt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.UserPicture, this.Information, this.dirt });
            this.GridDirt.Location = new System.Drawing.Point(13, 44);
            this.GridDirt.Name = "GridDirt";
            this.GridDirt.ReadOnly = true;
            this.GridDirt.RowHeadersVisible = false;
            this.GridDirt.Size = new System.Drawing.Size(709, 331);
            this.GridDirt.TabIndex = 11;
            // 
            // UserPicture
            // 
            this.UserPicture.HeaderText = "User Profile Picture";
            this.UserPicture.Name = "UserPicture";
            this.UserPicture.ReadOnly = true;
            // 
            // Information
            // 
            this.Information.HeaderText = "Information --------------------------------------------";
            this.Information.Name = "Information";
            this.Information.ReadOnly = true;
            this.Information.Width = 199;
            // 
            // dirt
            // 
            this.dirt.HeaderText = "dirt";
            this.dirt.Name = "dirt";
            this.dirt.ReadOnly = true;
            this.dirt.Width = 409;
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
            // mionjnl
            // 
            this.mionjnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mionjnl.Location = new System.Drawing.Point(12, 40);
            this.mionjnl.Name = "mionjnl";
            this.mionjnl.Size = new System.Drawing.Size(710, 1);
            this.mionjnl.TabIndex = 0;
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
            this.Text = "Geto\'s Dirt Locker 2: Electric Boogaloo - Dirt Lookup";
            this.Frame.ResumeLayout(false);
            this.Frame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDirt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView GridDirt;
        private System.Windows.Forms.DataGridViewImageColumn UserPicture;
        private System.Windows.Forms.DataGridViewTextBoxColumn Information;
        private System.Windows.Forms.DataGridViewImageColumn dirt;

        private GetosDirtLocker.controls.BetterTextBox TextBoxIndexLookup;
        private GetosDirtLocker.controls.BetterTextBox TextBoxNotesLookup;

        private System.Windows.Forms.Panel Frame;
        private GetosDirtLocker.controls.BetterTextBox TextBoxUserUUIDLookup;
        private System.Windows.Forms.Label mionjnl;
        private System.Windows.Forms.MenuStrip menuStrip1;

        #endregion
    }
}