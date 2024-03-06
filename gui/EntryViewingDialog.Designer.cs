using System.ComponentModel;

namespace GetosDirtLocker.gui;

partial class EntryViewingDialog
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryViewingDialog));
        this.PictureDirt = new System.Windows.Forms.PictureBox();
        this.klowkoqdjij = new System.Windows.Forms.Label();
        this.LabelUserInformation = new System.Windows.Forms.Label();
        this.PictureBoxAvatar = new System.Windows.Forms.PictureBox();
        this.kpqalqokso = new System.Windows.Forms.Label();
        this.LabelDirtInformation = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.PictureDirt)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.PictureBoxAvatar)).BeginInit();
        this.SuspendLayout();
        // 
        // PictureDirt
        // 
        this.PictureDirt.BackColor = System.Drawing.SystemColors.ControlLight;
        this.PictureDirt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.PictureDirt.Location = new System.Drawing.Point(280, 12);
        this.PictureDirt.Name = "PictureDirt";
        this.PictureDirt.Size = new System.Drawing.Size(412, 292);
        this.PictureDirt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.PictureDirt.TabIndex = 0;
        this.PictureDirt.TabStop = false;
        // 
        // klowkoqdjij
        // 
        this.klowkoqdjij.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.klowkoqdjij.Location = new System.Drawing.Point(270, 14);
        this.klowkoqdjij.Name = "klowkoqdjij";
        this.klowkoqdjij.Size = new System.Drawing.Size(1, 289);
        this.klowkoqdjij.TabIndex = 1;
        // 
        // LabelUserInformation
        // 
        this.LabelUserInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.LabelUserInformation.Location = new System.Drawing.Point(87, 14);
        this.LabelUserInformation.Name = "LabelUserInformation";
        this.LabelUserInformation.Size = new System.Drawing.Size(177, 64);
        this.LabelUserInformation.TabIndex = 2;
        // 
        // PictureBoxAvatar
        // 
        this.PictureBoxAvatar.Location = new System.Drawing.Point(12, 12);
        this.PictureBoxAvatar.Name = "PictureBoxAvatar";
        this.PictureBoxAvatar.Size = new System.Drawing.Size(65, 66);
        this.PictureBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.PictureBoxAvatar.TabIndex = 3;
        this.PictureBoxAvatar.TabStop = false;
        // 
        // kpqalqokso
        // 
        this.kpqalqokso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.kpqalqokso.Location = new System.Drawing.Point(12, 85);
        this.kpqalqokso.Name = "kpqalqokso";
        this.kpqalqokso.Size = new System.Drawing.Size(247, 1);
        this.kpqalqokso.TabIndex = 4;
        // 
        // LabelDirtInformation
        // 
        this.LabelDirtInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.LabelDirtInformation.Location = new System.Drawing.Point(11, 100);
        this.LabelDirtInformation.Name = "LabelDirtInformation";
        this.LabelDirtInformation.Size = new System.Drawing.Size(248, 207);
        this.LabelDirtInformation.TabIndex = 5;
        // 
        // EntryViewingDialog
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(212)))), ((int)(((byte)(237)))));
        this.ClientSize = new System.Drawing.Size(704, 316);
        this.Controls.Add(this.LabelDirtInformation);
        this.Controls.Add(this.kpqalqokso);
        this.Controls.Add(this.PictureBoxAvatar);
        this.Controls.Add(this.LabelUserInformation);
        this.Controls.Add(this.klowkoqdjij);
        this.Controls.Add(this.PictureDirt);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximumSize = new System.Drawing.Size(720, 355);
        this.MinimumSize = new System.Drawing.Size(720, 355);
        this.Name = "EntryViewingDialog";
        this.Text = "Dirt Entry - ";
        this.Load += new System.EventHandler(this.EntryViewingDialog_Load);
        ((System.ComponentModel.ISupportInitialize)(this.PictureDirt)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.PictureBoxAvatar)).EndInit();
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Label LabelDirtInformation;
    private System.Windows.Forms.Label klowkoqdjij;

    private System.Windows.Forms.Label kpqalqokso;

    private System.Windows.Forms.PictureBox PictureBoxAvatar;

    private System.Windows.Forms.Label LabelUserInformation;

    private System.Windows.Forms.PictureBox PictureDirt;

    #endregion
}