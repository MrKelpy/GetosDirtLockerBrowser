using System.ComponentModel;
using System.Drawing;

namespace GetosDirtLocker.gui
{
    partial class Mainframe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainframe));
            this.MenuBarPages = new System.Windows.Forms.MenuStrip();
            this.ToolStripNewEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripDirtLookup = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripTokenConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadEntriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainLayout = new System.Windows.Forms.Panel();
            this.MenuBarPages.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBarPages
            // 
            this.MenuBarPages.BackColor = System.Drawing.Color.Gray;
            this.MenuBarPages.ForeColor = System.Drawing.Color.White;
            this.MenuBarPages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.ToolStripNewEntry, this.ToolStripDirtLookup, this.ToolStripTokenConfig, this.reloadEntriesToolStripMenuItem });
            this.MenuBarPages.Location = new System.Drawing.Point(0, 0);
            this.MenuBarPages.Name = "MenuBarPages";
            this.MenuBarPages.Size = new System.Drawing.Size(734, 24);
            this.MenuBarPages.TabIndex = 2;
            this.MenuBarPages.Text = "menuStrip1";
            // 
            // ToolStripNewEntry
            // 
            this.ToolStripNewEntry.Name = "ToolStripNewEntry";
            this.ToolStripNewEntry.Size = new System.Drawing.Size(73, 20);
            this.ToolStripNewEntry.Text = "New Entry";
            this.ToolStripNewEntry.Click += new System.EventHandler(this.ToolStripNewEntry_Click);
            // 
            // ToolStripDirtLookup
            // 
            this.ToolStripDirtLookup.Name = "ToolStripDirtLookup";
            this.ToolStripDirtLookup.Size = new System.Drawing.Size(81, 20);
            this.ToolStripDirtLookup.Text = "Dirt Lookup";
            this.ToolStripDirtLookup.Click += new System.EventHandler(this.ToolStripDirtLookup_Click);
            // 
            // ToolStripTokenConfig
            // 
            this.ToolStripTokenConfig.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripTokenConfig.Name = "ToolStripTokenConfig";
            this.ToolStripTokenConfig.Size = new System.Drawing.Size(127, 20);
            this.ToolStripTokenConfig.Text = "Token Configuration";
            this.ToolStripTokenConfig.Click += new System.EventHandler(this.ToolStripTokenConfig_Click);
            // 
            // reloadEntriesToolStripMenuItem
            // 
            this.reloadEntriesToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.reloadEntriesToolStripMenuItem.Name = "reloadEntriesToolStripMenuItem";
            this.reloadEntriesToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.reloadEntriesToolStripMenuItem.Text = "Reload Entries";
            this.reloadEntriesToolStripMenuItem.Click += new System.EventHandler(this.reloadEntriesToolStripMenuItem_Click);
            // 
            // MainLayout
            // 
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 24);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.Size = new System.Drawing.Size(734, 387);
            this.MainLayout.TabIndex = 3;
            // 
            // Mainframe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 411);
            this.Controls.Add(this.MainLayout);
            this.Controls.Add(this.MenuBarPages);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(750, 450);
            this.MinimumSize = new System.Drawing.Size(750, 450);
            this.Name = "Mainframe";
            this.Load += new System.EventHandler(this.Mainframe_Load);
            this.MenuBarPages.ResumeLayout(false);
            this.MenuBarPages.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public System.Windows.Forms.ToolStripMenuItem reloadEntriesToolStripMenuItem;

        private System.Windows.Forms.Panel MainLayout;

        private System.Windows.Forms.Panel Frame;

        private System.Windows.Forms.ToolStripMenuItem ToolStripTokenConfig;

        private System.Windows.Forms.ToolStripMenuItem ToolStripNewEntry;
        private System.Windows.Forms.MenuStrip MenuBarPages;
        private System.Windows.Forms.ToolStripMenuItem ToolStripDirtLookup;

        #endregion
    }
}