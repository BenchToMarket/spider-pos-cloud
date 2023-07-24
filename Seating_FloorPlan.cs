using System.Diagnostics;
using System.Runtime.CompilerServices;

public partial class Seating_FloorPlan : System.Windows.Forms.UserControl
{

    internal Seating_FloorPlan previousFloorPlan;
    internal Seating_FloorPlan nextFloorPlan;



    #region  Windows Form Designer generated code 

    public Seating_FloorPlan() : base()
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call

    }

    // UserControl overrides dispose to clean up the component list.
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components is not null)
            {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }

    // Required by the Windows Form Designer
    private System.ComponentModel.IContainer components;

    // NOTE: The following procedure is required by the Windows Form Designer
    // It can be modified using the Windows Form Designer.  
    // Do not modify it using the code editor.
    private Global.System.Windows.Forms.Panel _panel1;

    internal virtual Global.System.Windows.Forms.Panel panel1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _panel1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _panel1 = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlFloorPlan;

    internal virtual Global.System.Windows.Forms.Panel pnlFloorPlan
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlFloorPlan;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlFloorPlan = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblFloorPlanName;

    internal virtual Global.System.Windows.Forms.Label lblFloorPlanName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblFloorPlanName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblFloorPlanName = value;
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        var resources = new System.Resources.ResourceManager(typeof(Seating_FloorPlan));
        _panel1 = new System.Windows.Forms.Panel();
        _pnlFloorPlan = new System.Windows.Forms.Panel();
        _lblFloorPlanName = new System.Windows.Forms.Label();
        _panel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // panel1
        // 
        _panel1.BackColor = System.Drawing.Color.DarkGray;
        _panel1.Controls.Add(_pnlFloorPlan);
        _panel1.Location = new System.Drawing.Point(88, 80);
        _panel1.Name = "_panel1";
        _panel1.Size = new System.Drawing.Size(560, 360);
        _panel1.TabIndex = 0;
        // 
        // pnlFloorPlan
        // 
        _pnlFloorPlan.BackColor = System.Drawing.Color.Black;
        _pnlFloorPlan.Location = new System.Drawing.Point(8, 8);
        _pnlFloorPlan.Name = "_pnlFloorPlan";
        _pnlFloorPlan.Size = new System.Drawing.Size(296, 272);
        _pnlFloorPlan.TabIndex = 0;
        // 
        // lblFloorPlanName
        // 
        _lblFloorPlanName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblFloorPlanName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _lblFloorPlanName.Location = new System.Drawing.Point(16, 16);
        _lblFloorPlanName.Name = "_lblFloorPlanName";
        _lblFloorPlanName.Size = new System.Drawing.Size(208, 40);
        _lblFloorPlanName.TabIndex = 3;
        _lblFloorPlanName.Text = "Floor Plan";
        _lblFloorPlanName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Seating_FloorPlan
        // 
        this.BackColor = System.Drawing.Color.Black;
        this.BackgroundImage = (Global.System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
        this.Controls.Add(_lblFloorPlanName);
        this.Controls.Add(_panel1);
        this.Name = "Seating_FloorPlan";
        this.Size = new System.Drawing.Size(900, 650);
        _panel1.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    internal void DisplayEachTable(ref DataRow oRow, int i)
    {

        btnTable[i] = new Seating_Table_UC2(i, oRow("xLoc"), oRow("yLoc"), oRow("myWidth"), oRow("myHeight"), oRow("TableNumber"), oRow("FloorPlanID"), true);

        pnlFloorPlan.Controls.Add(btnTable[i]);

    }

    internal void DisplayEachWall(ref DataRow oRow, int i)
    {

        btnWall[i] = new Panel();
        {
            var withBlock = btnWall[i];
            withBlock.Location = new Point(oRow("xLoc"), oRow("yLoc"));
            withBlock.BackColor = Color.DarkGray; // Black
            withBlock.Size = new Size(oRow("myWidth"), oRow("myHeight"));
        }
        pnlFloorPlan.Controls.Add(btnWall[i]);

    }

}