using System.ComponentModel;
using GetosDirtLockerBrowser.controls;

namespace GetosDirtLockerBrowser.gui


{
    partial class LockerInterface
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Frame = new System.Windows.Forms.Panel();
            this.PictureLoading = new System.Windows.Forms.PictureBox();
            this.LabelEntriesDisplay = new System.Windows.Forms.Label();
            this.TextBoxUsernameLookup = new GetosDirtLockerBrowser.controls.BetterTextBox();
            this.ButtonApplyFilters = new System.Windows.Forms.Button();
            this.ButtonViewEntry = new System.Windows.Forms.Button();
            this.okokkoko = new System.Windows.Forms.Label();
            this.TextBoxNotesLookup = new GetosDirtLockerBrowser.controls.BetterTextBox();
            this.TextBoxUserUUIDLookup = new GetosDirtLockerBrowser.controls.BetterTextBox();
            this.TextBoxIndexLookup = new GetosDirtLockerBrowser.controls.BetterTextBox();
            this.mionjnl = new System.Windows.Forms.Label();
            this.GridDirt = new System.Windows.Forms.DataGridView();
            this.indexationid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserPicture = new System.Windows.Forms.DataGridViewImageColumn();
            this.Information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirtPreview = new System.Windows.Forms.DataGridViewImageColumn();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miniToolStrip = new System.Windows.Forms.MenuStrip();
            this.GeneralErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.Frame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDirt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneralErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // Frame
            // 
            this.Frame.Controls.Add(this.PictureLoading);
            this.Frame.Controls.Add(this.LabelEntriesDisplay);
            this.Frame.Controls.Add(this.TextBoxUsernameLookup);
            this.Frame.Controls.Add(this.ButtonApplyFilters);
            this.Frame.Controls.Add(this.ButtonViewEntry);
            this.Frame.Controls.Add(this.okokkoko);
            this.Frame.Controls.Add(this.TextBoxNotesLookup);
            this.Frame.Controls.Add(this.TextBoxUserUUIDLookup);
            this.Frame.Controls.Add(this.TextBoxIndexLookup);
            this.Frame.Controls.Add(this.mionjnl);
            this.Frame.Controls.Add(this.GridDirt);
            this.Frame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Frame.Location = new System.Drawing.Point(0, 0);
            this.Frame.MaximumSize = new System.Drawing.Size(734, 607);
            this.Frame.MinimumSize = new System.Drawing.Size(734, 607);
            this.Frame.Name = "Frame";
            this.Frame.Size = new System.Drawing.Size(734, 607);
            this.Frame.TabIndex = 0;
            // 
            // PictureLoading
            // 
            this.PictureLoading.Image = global::GetosDirtLockerBrowser.Properties.Resources.loader;
            this.PictureLoading.Location = new System.Drawing.Point(346, 3);
            this.PictureLoading.Name = "PictureLoading";
            this.PictureLoading.Size = new System.Drawing.Size(45, 45);
            this.PictureLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureLoading.TabIndex = 25;
            this.PictureLoading.TabStop = false;
            this.PictureLoading.Visible = false;
            // 
            // LabelEntriesDisplay
            // 
            this.LabelEntriesDisplay.Location = new System.Drawing.Point(369, 31);
            this.LabelEntriesDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.LabelEntriesDisplay.Name = "LabelEntriesDisplay";
            this.LabelEntriesDisplay.Size = new System.Drawing.Size(353, 20);
            this.LabelEntriesDisplay.TabIndex = 24;
            this.LabelEntriesDisplay.Text = "Now displaying 0 entries.";
            this.LabelEntriesDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextBoxUsernameLookup
            // 
            this.TextBoxUsernameLookup.Location = new System.Drawing.Point(193, 51);
            this.TextBoxUsernameLookup.Name = "TextBoxUsernameLookup";
            this.TextBoxUsernameLookup.PlaceholderText = "Username";
            this.TextBoxUsernameLookup.PlaceholderTextColor = System.Drawing.Color.Gray;
            this.TextBoxUsernameLookup.Size = new System.Drawing.Size(173, 20);
            this.TextBoxUsernameLookup.TabIndex = 23;
            // 
            // ButtonApplyFilters
            // 
            this.ButtonApplyFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ButtonApplyFilters.Location = new System.Drawing.Point(14, 77);
            this.ButtonApplyFilters.Name = "ButtonApplyFilters";
            this.ButtonApplyFilters.Size = new System.Drawing.Size(352, 36);
            this.ButtonApplyFilters.TabIndex = 20;
            this.ButtonApplyFilters.Text = "Apply Filters";
            this.ButtonApplyFilters.UseVisualStyleBackColor = false;
            this.ButtonApplyFilters.Click += new System.EventHandler(this.ButtonApplyFilters_Click);
            // 
            // ButtonViewEntry
            // 
            this.ButtonViewEntry.BackColor = System.Drawing.Color.LemonChiffon;
            this.ButtonViewEntry.ForeColor = System.Drawing.Color.Black;
            this.ButtonViewEntry.Location = new System.Drawing.Point(370, 77);
            this.ButtonViewEntry.Name = "ButtonViewEntry";
            this.ButtonViewEntry.Size = new System.Drawing.Size(352, 36);
            this.ButtonViewEntry.TabIndex = 17;
            this.ButtonViewEntry.Text = "View Entry";
            this.ButtonViewEntry.UseVisualStyleBackColor = false;
            this.ButtonViewEntry.Click += new System.EventHandler(this.ButtonViewEntry_Click);
            // 
            // okokkoko
            // 
            this.okokkoko.Location = new System.Drawing.Point(14, 31);
            this.okokkoko.Margin = new System.Windows.Forms.Padding(0);
            this.okokkoko.Name = "okokkoko";
            this.okokkoko.Size = new System.Drawing.Size(352, 20);
            this.okokkoko.TabIndex = 15;
            this.okokkoko.Text = "Filter dirt entries by parameters";
            this.okokkoko.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextBoxNotesLookup
            // 
            this.TextBoxNotesLookup.Location = new System.Drawing.Point(549, 51);
            this.TextBoxNotesLookup.Name = "TextBoxNotesLookup";
            this.TextBoxNotesLookup.PlaceholderText = "Additional Information";
            this.TextBoxNotesLookup.PlaceholderTextColor = System.Drawing.Color.Gray;
            this.TextBoxNotesLookup.Size = new System.Drawing.Size(173, 20);
            this.TextBoxNotesLookup.TabIndex = 14;
            // 
            // TextBoxUserUUIDLookup
            // 
            this.TextBoxUserUUIDLookup.Location = new System.Drawing.Point(370, 51);
            this.TextBoxUserUUIDLookup.Name = "TextBoxUserUUIDLookup";
            this.TextBoxUserUUIDLookup.PlaceholderText = "User UUID";
            this.TextBoxUserUUIDLookup.PlaceholderTextColor = System.Drawing.Color.Gray;
            this.TextBoxUserUUIDLookup.Size = new System.Drawing.Size(173, 20);
            this.TextBoxUserUUIDLookup.TabIndex = 13;
            // 
            // TextBoxIndexLookup
            // 
            this.TextBoxIndexLookup.Location = new System.Drawing.Point(14, 51);
            this.TextBoxIndexLookup.Name = "TextBoxIndexLookup";
            this.TextBoxIndexLookup.PlaceholderText = "Indexation ID";
            this.TextBoxIndexLookup.PlaceholderTextColor = System.Drawing.Color.Gray;
            this.TextBoxIndexLookup.Size = new System.Drawing.Size(173, 20);
            this.TextBoxIndexLookup.TabIndex = 12;
            // 
            // mionjnl
            // 
            this.mionjnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mionjnl.Location = new System.Drawing.Point(13, 73);
            this.mionjnl.Name = "mionjnl";
            this.mionjnl.Size = new System.Drawing.Size(710, 1);
            this.mionjnl.TabIndex = 11;
            // 
            // GridDirt
            // 
            this.GridDirt.AllowUserToAddRows = false;
            this.GridDirt.AllowUserToDeleteRows = false;
            this.GridDirt.AllowUserToResizeColumns = false;
            this.GridDirt.AllowUserToResizeRows = false;
            this.GridDirt.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.GridDirt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridDirt.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridDirt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridDirt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDirt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.indexationid, this.uuid, this.UserPicture, this.Information, this.DirtPreview });
            this.GridDirt.Cursor = System.Windows.Forms.Cursors.PanNW;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridDirt.DefaultCellStyle = dataGridViewCellStyle2;
            this.GridDirt.Location = new System.Drawing.Point(14, 119);
            this.GridDirt.MultiSelect = false;
            this.GridDirt.Name = "GridDirt";
            this.GridDirt.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridDirt.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GridDirt.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GridDirt.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.GridDirt.Size = new System.Drawing.Size(708, 448);
            this.GridDirt.TabIndex = 10;
            this.GridDirt.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDirt_CellClick);
            this.GridDirt.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDirt_CellMouseEnter);
            this.GridDirt.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDirt_CellMouseLeave);
            this.GridDirt.SelectionChanged += new System.EventHandler(this.GridDirt_SelectionChanged);
            // 
            // indexationid
            // 
            this.indexationid.DividerWidth = 2;
            this.indexationid.HeaderText = "indexationid";
            this.indexationid.Name = "indexationid";
            this.indexationid.ReadOnly = true;
            this.indexationid.Visible = false;
            // 
            // uuid
            // 
            this.uuid.HeaderText = "uuid";
            this.uuid.Name = "uuid";
            this.uuid.ReadOnly = true;
            this.uuid.Visible = false;
            // 
            // UserPicture
            // 
            this.UserPicture.DividerWidth = 2;
            this.UserPicture.HeaderText = "Profile Picture";
            this.UserPicture.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.UserPicture.Name = "UserPicture";
            this.UserPicture.ReadOnly = true;
            // 
            // Information
            // 
            this.Information.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Information.DividerWidth = 2;
            this.Information.HeaderText = "Information";
            this.Information.Name = "Information";
            this.Information.ReadOnly = true;
            // 
            // DirtPreview
            // 
            this.DirtPreview.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DirtPreview.DividerWidth = 2;
            this.DirtPreview.HeaderText = "Recorded Dirt";
            this.DirtPreview.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.DirtPreview.Name = "DirtPreview";
            this.DirtPreview.ReadOnly = true;
            this.DirtPreview.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DirtPreview.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.Location = new System.Drawing.Point(0, 0);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(734, 24);
            this.miniToolStrip.TabIndex = 1;
            this.miniToolStrip.Visible = false;
            // 
            // GeneralErrorProvider
            // 
            this.GeneralErrorProvider.ContainerControl = this;
            // 
            // LockerInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(734, 606);
            this.Controls.Add(this.Frame);
            this.Controls.Add(this.miniToolStrip);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "LockerInterface";
            this.Text = "Geto\'s Locker 2: Electric Boogaloo";
            this.Frame.ResumeLayout(false);
            this.Frame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridDirt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneralErrorProvider)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox PictureLoading;

        private System.Windows.Forms.Label LabelEntriesDisplay;

        private GetosDirtLockerBrowser.controls.BetterTextBox TextBoxUsernameLookup;

        private System.Windows.Forms.Button ButtonApplyFilters;

        private System.Windows.Forms.Button ButtonViewEntry;

        private System.Windows.Forms.Label okokkoko;

        private GetosDirtLockerBrowser.controls.BetterTextBox TextBoxNotesLookup;
        private GetosDirtLockerBrowser.controls.BetterTextBox TextBoxUserUUIDLookup;
        private GetosDirtLockerBrowser.controls.BetterTextBox TextBoxIndexLookup;
        private System.Windows.Forms.Label mionjnl;

        private System.Windows.Forms.DataGridViewTextBoxColumn uuid;

        private System.Windows.Forms.DataGridViewImageColumn DirtPreview;

        private System.Windows.Forms.DataGridViewTextBoxColumn indexationid;

        private System.Windows.Forms.ErrorProvider GeneralErrorProvider;

        private System.Windows.Forms.DataGridViewImageColumn UserPicture;
        private System.Windows.Forms.DataGridViewTextBoxColumn Information;

        private System.Windows.Forms.DataGridView GridDirt;

        private System.Windows.Forms.MenuStrip miniToolStrip;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

        private System.Windows.Forms.Panel Frame;

        #endregion
    }
}