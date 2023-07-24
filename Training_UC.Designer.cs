using System.Diagnostics;



internal partial class Training_UC : System.Windows.Forms.UserControl
{
    public Training_UC()
    {
        InitializeComponent();
    }

    // UserControl overrides dispose to clean up the component list.
    [DebuggerNonUserCode()]
    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing && components is not null)
            {
                components.Dispose();
            }
        }
        finally
        {
            base.Dispose(disposing);
        }
    }

    // Required by the Windows Form Designer
    private System.ComponentModel.IContainer components;

    // NOTE: The following procedure is required by the Windows Form Designer
    // It can be modified using the Windows Form Designer.  
    // Do not modify it using the code editor.
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        grdPreviousDailys = new System.Windows.Forms.DataGrid();
        Panel1 = new System.Windows.Forms.Panel();
        btnDeleteTraining = new System.Windows.Forms.Button();
        Button1 = new System.Windows.Forms.Button();
        DataGridTableStyleTraining1 = new System.Windows.Forms.DataGridTableStyle();
        DataGridTextBoxColumnTraining1 = new System.Windows.Forms.DataGridTextBoxColumn();
        Panel2 = new System.Windows.Forms.Panel();
        DataGridTextBoxColumnTraining0 = new System.Windows.Forms.DataGridTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)grdPreviousDailys).BeginInit();
        Panel1.SuspendLayout();
        Panel2.SuspendLayout();
        this.SuspendLayout();
        // 
        // grdPreviousDailys
        // 
        grdPreviousDailys.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
        grdPreviousDailys.AllowSorting = false;
        grdPreviousDailys.BackgroundColor = System.Drawing.Color.White;
        grdPreviousDailys.CaptionBackColor = System.Drawing.Color.FromArgb(59, 96, 141);
        grdPreviousDailys.CaptionText = "Training Dailys";
        grdPreviousDailys.ColumnHeadersVisible = false;
        grdPreviousDailys.DataMember = "";
        grdPreviousDailys.GridLineColor = System.Drawing.Color.White;
        grdPreviousDailys.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        grdPreviousDailys.Location = new System.Drawing.Point(19, 14);
        grdPreviousDailys.Name = "grdPreviousDailys";
        grdPreviousDailys.RowHeadersVisible = false;
        grdPreviousDailys.Size = new System.Drawing.Size(325, 139);
        grdPreviousDailys.TabIndex = 12;
        grdPreviousDailys.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] { DataGridTableStyleTraining1 });
        // 
        // Panel1
        // 
        Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        Panel1.Controls.Add(btnDeleteTraining);
        Panel1.Controls.Add(Button1);
        Panel1.Location = new System.Drawing.Point(67, 275);
        Panel1.Name = "Panel1";
        Panel1.Size = new System.Drawing.Size(234, 64);
        Panel1.TabIndex = 15;
        // 
        // btnDeleteTraining
        // 
        btnDeleteTraining.BackColor = System.Drawing.Color.FromArgb(119, 154, 198);
        btnDeleteTraining.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        btnDeleteTraining.Location = new System.Drawing.Point(16, 5);
        btnDeleteTraining.Name = "btnDeleteTraining";
        btnDeleteTraining.Size = new System.Drawing.Size(92, 48);
        btnDeleteTraining.TabIndex = 8;
        btnDeleteTraining.Text = "Delete Training";
        btnDeleteTraining.UseVisualStyleBackColor = false;
        // 
        // Button1
        // 
        Button1.BackColor = System.Drawing.Color.FromArgb(119, 154, 198);
        Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        Button1.Location = new System.Drawing.Point(124, 5);
        Button1.Name = "Button1";
        Button1.Size = new System.Drawing.Size(92, 48);
        Button1.TabIndex = 9;
        Button1.Text = "Cancel";
        Button1.UseVisualStyleBackColor = false;
        // 
        // DataGridTableStyleTraining1
        // 
        DataGridTableStyleTraining1.DataGrid = grdPreviousDailys;
        DataGridTableStyleTraining1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] { DataGridTextBoxColumnTraining0, DataGridTextBoxColumnTraining1 });
        DataGridTableStyleTraining1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        DataGridTableStyleTraining1.MappingName = "TrainingDaily";
        DataGridTableStyleTraining1.RowHeadersVisible = false;
        // 
        // DataGridTextBoxColumnTraining1
        // 
        DataGridTextBoxColumnTraining1.Format = "MM/dd/yyyy";
        DataGridTextBoxColumnTraining1.FormatInfo = (object)null;
        DataGridTextBoxColumnTraining1.MappingName = "StartTime";
        DataGridTextBoxColumnTraining1.NullText = " ";
        DataGridTextBoxColumnTraining1.ReadOnly = true;
        DataGridTextBoxColumnTraining1.Width = 150;
        // 
        // Panel2
        // 
        Panel2.BackColor = System.Drawing.Color.Black;
        Panel2.Controls.Add(grdPreviousDailys);
        Panel2.Controls.Add(Panel1);
        Panel2.Location = new System.Drawing.Point(25, 27);
        Panel2.Name = "Panel2";
        Panel2.Size = new System.Drawing.Size(360, 368);
        Panel2.TabIndex = 16;
        // 
        // DataGridTextBoxColumnTraining0
        // 
        DataGridTextBoxColumnTraining0.Format = "";
        DataGridTextBoxColumnTraining0.FormatInfo = (object)null;
        DataGridTextBoxColumnTraining0.MappingName = "ActiveDaily";
        DataGridTextBoxColumnTraining0.Width = 50;
        // Me.DataGridTextBoxColumnTraining0.
        // 
        // Training_UC
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6.0f, 13.0f);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(59, 96, 141);
        this.Controls.Add(Panel2);
        this.Name = "Training_UC";
        this.Size = new System.Drawing.Size(409, 424);
        ((System.ComponentModel.ISupportInitialize)grdPreviousDailys).EndInit();
        Panel1.ResumeLayout(false);
        Panel2.ResumeLayout(false);
        this.ResumeLayout(false);

    }
    internal Global.System.Windows.Forms.DataGrid grdPreviousDailys;
    internal Global.System.Windows.Forms.Panel Panel1;
    internal Global.System.Windows.Forms.Button btnDeleteTraining;
    internal Global.System.Windows.Forms.Button Button1;
    internal Global.System.Windows.Forms.DataGridTableStyle DataGridTableStyleTraining1;
    internal Global.System.Windows.Forms.DataGridTextBoxColumn DataGridTextBoxColumnTraining1;
    internal Global.System.Windows.Forms.Panel Panel2;
    internal Global.System.Windows.Forms.DataGridTextBoxColumn DataGridTextBoxColumnTraining0;

}