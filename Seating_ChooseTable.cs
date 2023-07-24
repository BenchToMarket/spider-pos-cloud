using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DataSet_Builder;


public partial class Seating_ChooseTable : System.Windows.Forms.UserControl
{

    private Seating_FloorPlan _floorPlan1;

    private Seating_FloorPlan floorPlan1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _floorPlan1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _floorPlan1 = value;
        }
    }
    private Seating_FloorPlan _floorPlan2;

    private Seating_FloorPlan floorPlan2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _floorPlan2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _floorPlan2 = value;
        }
    }
    private Seating_FloorPlan _floorPlan3;

    private Seating_FloorPlan floorPlan3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _floorPlan3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _floorPlan3 = value;
        }
    }
    private Seating_FloorPlan _floorPlan4;

    private Seating_FloorPlan floorPlan4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _floorPlan4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _floorPlan4 = value;
        }
    }
    private Seating_FloorPlan _floorPlan5;

    private Seating_FloorPlan floorPlan5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _floorPlan5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _floorPlan5 = value;
        }
    }

    private int FloorPlanFirst;
    private int FloorPlanSecond;
    private int FloorPlanThird;
    private int FloorPlanForth;
    private int FloorPlanFifth;

    private floorPlanEnum currentFloorPlan;
    private bool _startedFromManager;


    // Dim WithEvents seatingChartCesar As Seating_Dining_Cesar
    // Dim WithEvents seatingChart As Seating_Dining
    // Dim WithEvents seatingChart2 As Seating_Dining2
    private Seating_ColorCode _seatingCode;

    private Seating_ColorCode seatingCode
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _seatingCode;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _seatingCode = value;
        }
    }

    private DataSet_Builder.Information_UC _SeatingOverrideInfo;

    private DataSet_Builder.Information_UC SeatingOverrideInfo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SeatingOverrideInfo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SeatingOverrideInfo != null)
            {
                _SeatingOverrideInfo.AcceptInformation -= SeatingOverrideAcepted;
            }

            _SeatingOverrideInfo = value;
            if (_SeatingOverrideInfo != null)
            {
                _SeatingOverrideInfo.AcceptInformation += SeatingOverrideAcepted;
            }
        }
    }
    private DataSet_Builder.NumberOfCustomers_UC _numCustPad;

    private DataSet_Builder.NumberOfCustomers_UC numCustPad
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _numCustPad;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_numCustPad != null)
            {
                _numCustPad.canceled -= DisposeNumberCustoemrPad;
                _numCustPad.NumberCustomerEntered -= NumCustPad_Entered;
            }

            _numCustPad = value;
            if (_numCustPad != null)
            {
                _numCustPad.canceled += DisposeNumberCustoemrPad;
                _numCustPad.NumberCustomerEntered += NumCustPad_Entered;
            }
        }
    }
    private Button btnClose2;

    private int currentSeatingView;
    private bool changesMade;
    private bool changingAvail;
    private bool _overrideAvail;


    private int _tableSelected;
    private int _numberCustomers;

    // true if we started this from ManagerForm
    internal bool StartedFromManager
    {
        get
        {
            return _startedFromManager;
        }
        set
        {
            _startedFromManager = value;
        }
    }


    internal int TableSelected
    {
        get
        {
            return _tableSelected;
        }
        set
        {
            _tableSelected = value;
        }
    }

    internal int NumberCustomers
    {
        get
        {
            return _numberCustomers;
        }
        set
        {
            _numberCustomers = value;
        }
    }

    internal bool OverrideAvail
    {
        get
        {
            return _overrideAvail;
        }
        set
        {
            _overrideAvail = value;
        }
    }


    public event TableSelectedEventSecondEventHandler TableSelectedEventSecond;

    public delegate void TableSelectedEventSecondEventHandler(object sender, EventArgs e);
    public event NumberCustomerEventEventHandler NumberCustomerEvent;

    public delegate void NumberCustomerEventEventHandler();
    public event NoTableSelectedEventHandler NoTableSelected;

    public delegate void NoTableSelectedEventHandler(object sender, EventArgs e);


    #region  Windows Form Designer generated code 

    public Seating_ChooseTable() : base()
    {

        currentSeatingView = 1;

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        InitializeOther();

    }

    // Form overrides dispose to clean up the component list.
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
    private Global.System.Windows.Forms.Panel _pnlSeating;

    internal virtual Global.System.Windows.Forms.Panel pnlSeating
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlSeating;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlSeating = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnClose;

    internal virtual Global.System.Windows.Forms.Button btnClose
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnClose;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnClose != null)
            {
                _btnClose.Click -= btnClose_Clicked;
            }

            _btnClose = value;
            if (_btnClose != null)
            {
                _btnClose.Click += btnClose_Clicked;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnSeatingPrevious;

    internal virtual Global.System.Windows.Forms.Button btnSeatingPrevious
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnSeatingPrevious;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnSeatingPrevious != null)
            {
                _btnSeatingPrevious.Click -= btnSeatingPrevious_Click;
            }

            _btnSeatingPrevious = value;
            if (_btnSeatingPrevious != null)
            {
                _btnSeatingPrevious.Click += btnSeatingPrevious_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnSeatingNext;

    internal virtual Global.System.Windows.Forms.Button btnSeatingNext
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnSeatingNext;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnSeatingNext != null)
            {
                _btnSeatingNext.Click -= btnSeatingNext_Click;
            }

            _btnSeatingNext = value;
            if (_btnSeatingNext != null)
            {
                _btnSeatingNext.Click += btnSeatingNext_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnSeatingCode;

    internal virtual Global.System.Windows.Forms.Button btnSeatingCode
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnSeatingCode;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnSeatingCode != null)
            {
                _btnSeatingCode.Click -= btnSeatingCode_Click;
            }

            _btnSeatingCode = value;
            if (_btnSeatingCode != null)
            {
                _btnSeatingCode.Click += btnSeatingCode_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnChangeAvail;

    internal virtual Global.System.Windows.Forms.Button btnChangeAvail
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnChangeAvail;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnChangeAvail != null)
            {
                _btnChangeAvail.Click -= btnChangeAvail_Click;
            }

            _btnChangeAvail = value;
            if (_btnChangeAvail != null)
            {
                _btnChangeAvail.Click += btnChangeAvail_Click;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _pnlSeating = new System.Windows.Forms.Panel();
        _btnChangeAvail = new System.Windows.Forms.Button();
        _btnChangeAvail.Click += btnChangeAvail_Click;
        _btnSeatingCode = new System.Windows.Forms.Button();
        _btnSeatingCode.Click += btnSeatingCode_Click;
        _btnSeatingPrevious = new System.Windows.Forms.Button();
        _btnSeatingPrevious.Click += btnSeatingPrevious_Click;
        _btnSeatingNext = new System.Windows.Forms.Button();
        _btnSeatingNext.Click += btnSeatingNext_Click;
        _btnClose = new System.Windows.Forms.Button();
        _btnClose.Click += btnClose_Clicked;
        _pnlSeating.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlSeating
        // 
        _pnlSeating.BackColor = System.Drawing.Color.SlateGray;
        _pnlSeating.Controls.Add(_btnChangeAvail);
        _pnlSeating.Controls.Add(_btnSeatingCode);
        _pnlSeating.Controls.Add(_btnSeatingPrevious);
        _pnlSeating.Controls.Add(_btnSeatingNext);
        _pnlSeating.Controls.Add(_btnClose);
        _pnlSeating.Dock = System.Windows.Forms.DockStyle.Bottom;
        _pnlSeating.Location = new System.Drawing.Point(0, 696);
        _pnlSeating.Name = "_pnlSeating";
        _pnlSeating.Size = new System.Drawing.Size(1024, 72);
        _pnlSeating.TabIndex = 0;
        // 
        // btnChangeAvail
        // 
        _btnChangeAvail.Anchor = (Global.System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        _btnChangeAvail.BackColor = System.Drawing.Color.CornflowerBlue;
        _btnChangeAvail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnChangeAvail.Location = new System.Drawing.Point(320, 8);
        _btnChangeAvail.Name = "_btnChangeAvail";
        _btnChangeAvail.Size = new System.Drawing.Size(96, 56);
        _btnChangeAvail.TabIndex = 4;
        _btnChangeAvail.Text = "Change Avail";
        // 
        // btnSeatingCode
        // 
        _btnSeatingCode.Anchor = (Global.System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        _btnSeatingCode.BackColor = System.Drawing.Color.CornflowerBlue;
        _btnSeatingCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnSeatingCode.Location = new System.Drawing.Point(184, 8);
        _btnSeatingCode.Name = "_btnSeatingCode";
        _btnSeatingCode.Size = new System.Drawing.Size(96, 56);
        _btnSeatingCode.TabIndex = 3;
        _btnSeatingCode.Text = "Color Code";
        // 
        // btnSeatingPrevious
        // 
        _btnSeatingPrevious.Anchor = (Global.System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
        _btnSeatingPrevious.BackColor = System.Drawing.Color.CornflowerBlue;
        _btnSeatingPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnSeatingPrevious.Location = new System.Drawing.Point(712, 8);
        _btnSeatingPrevious.Name = "_btnSeatingPrevious";
        _btnSeatingPrevious.Size = new System.Drawing.Size(96, 56);
        _btnSeatingPrevious.TabIndex = 2;
        _btnSeatingPrevious.Text = "Previous";
        // 
        // btnSeatingNext
        // 
        _btnSeatingNext.Anchor = (Global.System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
        _btnSeatingNext.BackColor = System.Drawing.Color.CornflowerBlue;
        _btnSeatingNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnSeatingNext.Location = new System.Drawing.Point(848, 8);
        _btnSeatingNext.Name = "_btnSeatingNext";
        _btnSeatingNext.Size = new System.Drawing.Size(96, 56);
        _btnSeatingNext.TabIndex = 1;
        _btnSeatingNext.Text = "Next";
        // 
        // btnClose
        // 
        _btnClose.Anchor = (Global.System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        _btnClose.BackColor = System.Drawing.Color.CornflowerBlue;
        _btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnClose.Location = new System.Drawing.Point(48, 8);
        _btnClose.Name = "_btnClose";
        _btnClose.Size = new System.Drawing.Size(96, 56);
        _btnClose.TabIndex = 0;
        _btnClose.Text = "Close";
        // 
        // Seating_ChooseTable
        // 
        this.BackColor = System.Drawing.Color.LightSlateGray;
        this.Controls.Add(_pnlSeating);
        this.Name = "Seating_ChooseTable";
        this.Size = new System.Drawing.Size(1024, 768);
        _pnlSeating.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private void InitializeOther()
    {

        PopulateFloorPlanData();
        DisplayWalls();
        DisplayTables();
        InitiateNumberCustomerPad();

    }

    private void InitiateNumberCustomerPad()
    {

        numCustPad = new DataSet_Builder.NumberOfCustomers_UC();
        numCustPad.ColorButtonFromStart(0);
        numCustPad.Location = new Point((this.Width - numCustPad.Width) / 2, (this.Height - numCustPad.Height) / 2);
        numCustPad.Visible = false;
        this.Controls.Add(numCustPad);
    }

    private void DisposeNumberCustoemrPad()
    {

        // RaiseEvent NumberCustomerEvent()
        ResetFloorPlan();
        numCustPad.Visible = false;
        this.Visible = true;

    }

    private void PopulateFloorPlanData()
    {
        int fpCount = 1;

        // we need to instatiate all just in case there is a  
        // table assigned to a floor plan that was deleted 
        floorPlan1 = new Seating_FloorPlan();
        floorPlan2 = new Seating_FloorPlan();
        floorPlan3 = new Seating_FloorPlan();
        floorPlan4 = new Seating_FloorPlan();
        floorPlan5 = new Seating_FloorPlan();

        foreach (DataRow fpRow in ds.Tables("TermsFloor").Rows)
        {
            switch (fpCount)
            {
                case 1:
                    {
                        // floorPlan1.SuspendLayout()
                        floorPlan1.lblFloorPlanName.Text = fpRow("FloorPlanName") + "   ";
                        FloorPlanFirst = fpRow("FloorPlanID");


                        floorPlan1.panel1.Size = new Size(fpRow("meWidth"), fpRow("meHeight"));
                        floorPlan1.panel1.Location = new Point((floorPlan1.Width - fpRow("meWidth")) / 2, (floorPlan1.Height - fpRow("meHeight") + 60) / 2);
                        // adding 60 to height b/c of lblFloorPlanName
                        floorPlan1.pnlFloorPlan.Size = new Size(fpRow("meWidth") - 16, fpRow("meHeight") - 16);
                        floorPlan1.pnlFloorPlan.Location = new Point(8, 8);
                        floorPlan1.previousFloorPlan = floorPlan1;
                        floorPlan1.nextFloorPlan = floorPlan1;
                        currentFloorPlan = 1;

                        floorPlan1.Location = new Point(50, 40);
                        this.Controls.Add(floorPlan1);
                        break;
                    }

                case 2:
                    {


                        floorPlan2.lblFloorPlanName.Text = fpRow("FloorPlanName") + "   ";
                        FloorPlanSecond = fpRow("FloorPlanID");

                        floorPlan2.panel1.Size = new Size(fpRow("meWidth"), fpRow("meHeight"));
                        floorPlan2.panel1.Location = new Point((floorPlan2.Width - fpRow("meWidth")) / 2, (floorPlan2.Height - fpRow("meHeight") + 60) / 2);
                        floorPlan2.pnlFloorPlan.Size = new Size(fpRow("meWidth") - 16, fpRow("meHeight") - 16);
                        floorPlan2.pnlFloorPlan.Location = new Point(8, 8);
                        floorPlan2.previousFloorPlan = floorPlan1;
                        floorPlan2.nextFloorPlan = floorPlan2;
                        floorPlan1.nextFloorPlan = floorPlan2;   // we must restate the last floorplan

                        floorPlan2.Location = new Point(50, 40);
                        this.Controls.Add(floorPlan2);
                        break;
                    }
                case 3:
                    {


                        floorPlan2.lblFloorPlanName.Text = fpRow("FloorPlanName") + "   ";
                        FloorPlanThird = fpRow("FloorPlanID");

                        floorPlan3.panel1.Size = new Size(fpRow("meWidth"), fpRow("meHeight"));
                        floorPlan3.panel1.Location = new Point((floorPlan3.Width - fpRow("meWidth")) / 2, (floorPlan3.Height - fpRow("meHeight") + 60) / 2);
                        floorPlan3.pnlFloorPlan.Size = new Size(fpRow("meWidth") - 16, fpRow("meHeight") - 16);
                        floorPlan3.pnlFloorPlan.Location = new Point(8, 8);
                        floorPlan3.previousFloorPlan = floorPlan2;
                        floorPlan3.nextFloorPlan = floorPlan3;
                        floorPlan2.nextFloorPlan = floorPlan3;   // we must restate the last floorplan

                        floorPlan3.Location = new Point(50, 40);
                        this.Controls.Add(floorPlan3);
                        break;
                    }
                case 4:
                    {


                        floorPlan4.lblFloorPlanName.Text = fpRow("FloorPlanName") + "   ";
                        FloorPlanForth = fpRow("FloorPlanID");

                        floorPlan4.panel1.Size = new Size(fpRow("meWidth"), fpRow("meHeight"));
                        floorPlan4.panel1.Location = new Point((floorPlan4.Width - fpRow("meWidth")) / 2, (floorPlan4.Height - fpRow("meHeight") + 60) / 2);
                        floorPlan4.pnlFloorPlan.Size = new Size(fpRow("meWidth") - 16, fpRow("meHeight") - 16);
                        floorPlan4.pnlFloorPlan.Location = new Point(8, 8);
                        floorPlan4.previousFloorPlan = floorPlan3;
                        floorPlan4.nextFloorPlan = floorPlan4;
                        floorPlan3.nextFloorPlan = floorPlan4;   // we must restate the last floorplan

                        floorPlan4.Location = new Point(50, 40);
                        this.Controls.Add(floorPlan4);
                        break;
                    }
                case 5:
                    {


                        floorPlan5.lblFloorPlanName.Text = fpRow("FloorPlanName") + "   ";
                        FloorPlanFifth = fpRow("FloorPlanID");

                        floorPlan5.panel1.Size = new Size(fpRow("meWidth"), fpRow("meHeight"));
                        floorPlan5.panel1.Location = new Point((floorPlan5.Width - fpRow("meWidth")) / 2, (floorPlan5.Height - fpRow("meHeight") + 60) / 2);
                        floorPlan5.pnlFloorPlan.Size = new Size(fpRow("meWidth") - 16, fpRow("meHeight") - 16);
                        floorPlan5.pnlFloorPlan.Location = new Point(8, 8);
                        floorPlan5.previousFloorPlan = floorPlan4;
                        floorPlan5.nextFloorPlan = floorPlan1;
                        floorPlan4.nextFloorPlan = floorPlan5;   // we must restate the last floorplan
                        floorPlan1.previousFloorPlan = floorPlan5;

                        floorPlan5.Location = new Point(50, 40);
                        this.Controls.Add(floorPlan5);
                        break;
                    }
            }

            fpCount += 1;
        }

    }

    private void DisplayWalls()
    {
        var i = default(int);

        foreach (DataRow oRow in ds.Tables("TermsWalls").Rows)
        {
            if (oRow("Active") == true)
            {

                switch (oRow("FloorPlanID"))
                {
                    case var @case when @case == FloorPlanFirst:
                        {
                            floorPlan1.DisplayEachWall(oRow, i);
                            break;
                        }

                    case var case1 when case1 == FloorPlanSecond:
                        {
                            floorPlan2.DisplayEachWall(oRow, i);
                            break;
                        }
                    case var case2 when case2 == FloorPlanThird:
                        {
                            floorPlan3.DisplayEachWall(oRow, i);
                            break;
                        }
                    case var case3 when case3 == FloorPlanForth:
                        {
                            floorPlan4.DisplayEachWall(oRow, i);
                            break;
                        }
                    case var case4 when case4 == FloorPlanFifth:
                        {
                            floorPlan5.DisplayEachWall(oRow, i);
                            break;
                        }
                }

            }
            i += 1;
        }

    }

    private void DisplayTables()
    {
        var i = default(int);

        foreach (DataRow oRow in ds.Tables("TermsTables").Rows)
        {
            // 444     If oRow("Active") = True Then
            // we have to check for active here just in case
            // they make a table inactive in middle of shift
            // we order by TableOverviewID and adj color by this index (i)
            // TermsTables and AllTables will have the same index(i)
            // we also count inactive in this index count
            switch (oRow("FloorPlanID"))
            {
                case var @case when @case == FloorPlanFirst:
                    {
                        floorPlan1.DisplayEachTable(oRow, i);
                        break;
                    }

                case var case1 when case1 == FloorPlanSecond:
                    {
                        floorPlan2.DisplayEachTable(oRow, i);
                        break;
                    }
                case var case2 when case2 == FloorPlanThird:
                    {
                        floorPlan3.DisplayEachTable(oRow, i);
                        break;
                    }
                case var case3 when case3 == FloorPlanForth:
                    {
                        floorPlan4.DisplayEachTable(oRow, i);
                        break;
                    }
                case var case4 when case4 == FloorPlanFifth:
                    {
                        floorPlan5.DisplayEachTable(oRow, i);
                        break;
                    }
            }
            btnTable[i].TableSelectedEvent += TableReadyToOpen;

            // 444        End If
            i += 1;
        }
        // floorPlan1.ResumeLayout(False)
    }

    internal void AdjustTableColor()
    {
        Color cc;
        var i = default(int);

        foreach (DataRow oRow in dsOrder.Tables("AllTables").Rows)
        {
            // 444   If oRow("Active") = True Then
            if (!object.ReferenceEquals(oRow("EmployeeID"), DBNull.Value) & !object.ReferenceEquals(oRow("TableStatusID"), DBNull.Value))
            {

                if (oRow("EmployeeID") == currentServer.EmployeeID & oRow("TableStatusID") > 1 & oRow("TableStatusID") < 8)
                {
                    // is this employees table
                    cc = Color.LightGreen;
                }
                else
                {
                    cc = DetermineColor(oRow("TableStatusID"));
                }
            }
            else
            {
                cc = DetermineColor[1];
            } // oRow("TableStatusID"))

            btnTable[i].lblTableNum.BackColor = cc;
            if (cc.ToString == c15.ToString)
            {
                btnTable[i].IsAvail = true;
            }
            else
            {
                btnTable[i].IsAvail = false;
            }

            // 444   End If
            i += 1;
        }

    }


    private void TableReadyToOpen(int tn, bool isAvail)
    {

        _tableSelected = tn;

        if (OverrideAvail == true)
        {
            // comes in from Mgr OverrideTableStatus      ????????????
            ResetSeatingChartTableStatus(TableSelected, OverrideAvail);
            // AdjustSeatingChartTableColor()
            changesMade = true;
            return;
        }

        if (isAvail == true) // avail for seating
        {
            // numCustPad.Visible = False
            // Me.Visible = False
            SelectNumberOfCustomers();
            return;
        }

        if (allowTableOverride == true)   // currently hardcoded to true
        {
            SeatingOverrideInfo = new DataSet_Builder.Information_UC("This Table Is Unavailable:      Select To Override?");
            SeatingOverrideInfo.Location = new Point((this.Width - SeatingOverrideInfo.Width) / 2, (this.Height - SeatingOverrideInfo.Height) / 2);
            this.Controls.Add(SeatingOverrideInfo);
            SeatingOverrideInfo.BringToFront();
        }
        else
        {
            DataSet_Builder.Information_UC info;
            info = new DataSet_Builder.Information_UC("This Table Is Unavailable.");
            info.Location = new Point((this.Width - info.Width) / 2, (this.Height - info.Height) / 2);
            this.Controls.Add(info);
            info.BringToFront();
        }

    }


    private void SelectNumberOfCustomers()
    {

        try
        {
            numCustPad.ColorButtonFromStart(0);
            numCustPad.Visible = true;
            numCustPad.BringToFront();
        }
        catch (Exception ex)
        {
            InitiateNumberCustomerPad();
        }

    }

    private void NumCustPad_Entered(int custInteger)
    {

        // Me.Visible = False
        _numberCustomers = custInteger;
        // RaiseEvent NumberCustomerEvent()
        ResetFloorPlan();
        numCustPad.Visible = false;
        this.Visible = false;
        NumberCustomerEvent?.Invoke();
        // NewAddNewTable(custInteger)


        // UpdateTableStatusAfterSelection()

        // If mainServerConnected = True Then
        // If changesMade = True Then
        // UpdateAvailTablesData()
        // End If
        // End If


    }

    private void btnSeatingCode_Click(object sender, EventArgs e)
    {

        seatingCode = new Seating_ColorCode();

        seatingCode.Location = new Point(25, (this.Height - pnlSeating.Height - seatingCode.Height) / 2);

        this.Controls.Add(seatingCode);
        seatingCode.BringToFront();


    }

    private void btnChangeAvail_Click(object sender, EventArgs e)
    {

        if (typeProgram == "Online_Demo")
        {
            Interaction.MsgBox("Demo will not allow.", MsgBoxStyle.Information, "DEMO Purposes only");
            return;
        }

        if (changingAvail == false)
        {
            changingAvail = true;
            btnChangeAvail.BackColor = c9;
        }
        else
        {
            changingAvail = false;
            btnChangeAvail.BackColor = c15;
        }

    }

    private void btnClose_Clicked(object sender, EventArgs e)
    {

        if (typeProgram == "Online_Demo")
        {
            Interaction.MsgBox("Demo will not allow you to exit this screen without selecting a table.", MsgBoxStyle.Information, "DEMO Purposes only");
            return;
        }

        if (changesMade == true)
        {
            UpdateAvailTablesData();
        }


        // If Not currentTable Is Nothing Then
        NoTableSelected?.Invoke(sender, e);
        // MsgBox(currentTable.ExperienceNumber)
        // End If

        // Me.Dispose()
        ResetFloorPlan();
        numCustPad.Visible = false;
        this.Visible = false;

    }

    private void ResetFloorPlan()
    {
        int fpCount = 1;

        foreach (DataRow fpRow in ds.Tables("TermsFloor").Rows)
        {
            switch (fpCount)
            {
                case 1:
                    {
                        floorPlan1.Visible = true;
                        break;
                    }
                case 2:
                    {
                        floorPlan2.Visible = false;
                        break;
                    }
                case 3:
                    {
                        floorPlan3.Visible = false;
                        break;
                    }
                case 4:
                    {
                        floorPlan4.Visible = false;
                        break;
                    }
                case 5:
                    {
                        floorPlan5.Visible = false;
                        break;
                    }
            }
            fpCount += 1;
        }

    }

    private void SeatingOverrideAcepted(object sender, EventArgs e)
    {
        // ChangeAvailStatus()
        // Me.Visible = False
        // numCustPad.Visible = False
        // Me.Visible = False
        SeatingOverrideInfo.Dispose();
        SelectNumberOfCustomers();

    }



    private void btnSeatingNext_Click(object sender, EventArgs e)
    {

        switch (currentFloorPlan)
        {
            case 1:
                {
                    floorPlan1.Visible = false;
                    floorPlan1.nextFloorPlan.Visible = true;
                    break;
                }
            // If floorPlan1.nextFloorPlan Is floorPlan2 Then
            // currentFloorPlan = 2
            // End If
            case 2:
                {
                    floorPlan2.Visible = false;
                    floorPlan2.nextFloorPlan.Visible = true;
                    break;
                }
                // If floorPlan2.nextFloorPlan Is floorPlan3 Then
                // currentFloorPlan = 3
                // Else
                // currentFloorPlan = 1
                // End If
        }


    }

    private void btnSeatingPrevious_Click(object sender, EventArgs e)
    {

        switch (currentFloorPlan)
        {
            case 1:
                {
                    floorPlan1.Visible = false;
                    floorPlan1.previousFloorPlan.Visible = true;
                    break;
                }
            case 2:
                {
                    floorPlan2.Visible = false;
                    floorPlan2.previousFloorPlan.Visible = true;
                    break;
                }
        }
    }









    // 222
    // *********************
    // everything below is old





    private void NewTableSelected222(object sender, EventArgs e) // Handles seatingChart.TableSelectedEvent ', seatingChartCesar.TableSelectedEvent, seatingChart2.TableSelectedEvent
    {

        var objButton = new Button();
        PhysicalTable tbl;

        objButton = (Button)sender;
        _tableSelected = (int)objButton.Text;

        if (OverrideAvail == true)
        {
            // comes in from Mgr OverrideTableStatus
            ResetSeatingChartTableStatus(TableSelected, OverrideAvail);
            // AdjustSeatingChartTableColor()
            changesMade = true;
            return;
        }

        if (changingAvail == true)
        {
            ChangeAvailStatus();
            return;
        }

        if (objButton.BackColor.ToString == c1.ToString)  // check down
        {
            ChangeAvailStatus();
            return;
        }

        if (objButton.BackColor.ToString == c15.ToString)
        {

            // DisposeAllSeatingCharts()
            // SelectNumberOfCustomers()
            return;
        }

        // If objButton.BackColor.ToString = c5.ToString Then
        if (allowTableOverride == true)
        {
            SeatingOverrideInfo = new DataSet_Builder.Information_UC("This Table Is Unavailable:      Select To Override?");
            SeatingOverrideInfo.Location = new Point((this.Width - SeatingOverrideInfo.Width) / 2, (this.Height - SeatingOverrideInfo.Height) / 2);
            this.Controls.Add(SeatingOverrideInfo);
            SeatingOverrideInfo.BringToFront();
        }
        // If MsgBox("This Table Is Unavailable For Seating, Would You Like To Override?", MsgBoxStyle.YesNo, ) = MsgBoxResult.Yes Then
        // End If
        else
        {
            DataSet_Builder.Information_UC info;
            info = new DataSet_Builder.Information_UC("This Table Is Unavailable.");
            info.Location = new Point((this.Width - info.Width) / 2, (this.Height - info.Height) / 2);
            this.Controls.Add(info);
            info.BringToFront();
        }
        // End If

    }



    private void UpdateTableStatusAfterSelection()
    {

        foreach (DataRow oRow in dsOrder.Tables("AllTables").Rows)     // currentPhysicalTables
        {
            if (oRow("TableNumber") == TableSelected)
            {
                oRow("TableStatusID") = 2;
                break;
            }
        }

        // Dim tbl As PhysicalTable
        // 
        // For Each tbl In currentPhysicalTables
        // If tbl.PhysicalTableNumber = TableSelected Then
        // tbl.CurrentStatus = 2
        // Exit For
        // End If
        // Next


    }



    private void ChangeAvailStatus()
    {
        Color cc;
        PhysicalTable tbl;

        foreach (DataRow oRow in dsOrder.Tables("AllTables").Rows)  // For Each tbl In currentPhysicalTables
        {
            if (oRow("TableNumber") == TableSelected) // .PhysicalTableNumber = TableSelected Then
            {
                if (!object.ReferenceEquals(oRow("TableStatusID"), DBNull.Value))
                {
                    if (oRow("TableStatusID") == 0)            // unavail
                    {
                        oRow("TableStatusID") = 1;
                    }
                    else if (oRow("TableStatusID") == 1)        // avail for seating
                    {
                        oRow("TableStatusID") = 0;
                    }
                    else if (oRow("TableStatusID") == 7)        // check down
                    {
                        oRow("TableStatusID") = 10;
                    }
                    else
                    {
                        // bring up override question
                        // or make manager do override
                    }                                    // all other including sat

                    break;
                }
            }
        }

        changesMade = true;

    }



}