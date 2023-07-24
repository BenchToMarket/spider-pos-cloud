using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using DataSet_Builder;



public partial class Tables_Screen_Bar : System.Windows.Forms.UserControl
{

    private int testCOunt;

    // Dim sql As New DataSet_Builder.SQLHelper(connectserver)
    // Dim keepActiveTimer As New Timer
    // Dim keepActiveInteger As Integer

    // Private tablesInactiveTimer As Timer
    // Dim updateClockTimer As New Timer
    private int tablesInactiveCounter = 1;
    private DataSet_Builder.Information_UC _openInfo;

    private DataSet_Builder.Information_UC openInfo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _openInfo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_openInfo != null)
            {
                _openInfo.AcceptInformation -= OkToLeaveOpenTables;
            }

            _openInfo = value;
            if (_openInfo != null)
            {
                _openInfo.AcceptInformation += OkToLeaveOpenTables;
            }
        }
    }

    // Dim WithEvents SeatingChart As Seating_ChooseTable 'Seating_Dining
    private Seating_EnterTab SeatingTab222;
    // we use setaing tab in Login and maybe Customer Loyalty here
    private term_OrderForm _ActiveOrder;

    private term_OrderForm ActiveOrder
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ActiveOrder;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ActiveOrder != null)
            {
                _ActiveOrder.TermOrder_Disposing -= UpdatingTableData222;
            }

            _ActiveOrder = value;
            if (_ActiveOrder != null)
            {
                _ActiveOrder.TermOrder_Disposing += UpdatingTableData222;
            }
        }
    }
    // Dim WithEvents ManagementForm As Manager_Form
    private ClockInUserControl _clockInPanel;

    private ClockInUserControl clockInPanel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _clockInPanel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_clockInPanel != null)
            {
                _clockInPanel.ApplyClockInCheck -= ClockInEmployeeClicked;
                _clockInPanel.ClosingClockIn -= ClockInEnding;
            }

            _clockInPanel = value;
            if (_clockInPanel != null)
            {
                _clockInPanel.ApplyClockInCheck += ClockInEmployeeClicked;
                _clockInPanel.ClosingClockIn += ClockInEnding;
            }
        }
    }
    private ClockOut_UC _ClockingOutEmployee;

    private ClockOut_UC ClockingOutEmployee
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ClockingOutEmployee;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_ClockingOutEmployee != null)
            {
                _ClockingOutEmployee.ClockOutComplete -= btnTablesExit_Click_1;
                _ClockingOutEmployee.ClockOutCancel -= CLockOutCanceled;
            }

            _ClockingOutEmployee = value;
            if (_ClockingOutEmployee != null)
            {
                _ClockingOutEmployee.ClockOutComplete += btnTablesExit_Click_1;
                _ClockingOutEmployee.ClockOutCancel += CLockOutCanceled;
            }
        }
    }
    private NumberPad _nosaleLoginPad;

    private NumberPad nosaleLoginPad
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _nosaleLoginPad;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_nosaleLoginPad != null)
            {
                _nosaleLoginPad.NumberEntered -= NoSalePassword;
                _nosaleLoginPad.AcceptManager -= NoSalePasswordBlank;
            }

            _nosaleLoginPad = value;
            if (_nosaleLoginPad != null)
            {
                _nosaleLoginPad.NumberEntered += NoSalePassword;
                _nosaleLoginPad.AcceptManager += NoSalePasswordBlank;
            }
        }
    }
    private string isNoSaleOrClockOut;
    private CashClose_UC ccDisplay;
    private int lastTablePanel;
    private int quickEndCount = 0;

    // Dim blankPanel As New Panel

    internal bool _IsBartenderMode;
    // Dim IsOneBartender As Boolean
    private int NumBar;
    // this is because some reason the system resizes pnlAvailTabs control
    private bool needToCorrectRoundingError = true;

    public event ManagementButtonEventHandler ManagementButton;

    public delegate void ManagementButtonEventHandler(ref Employee sender);
    public event ExitingTableScreenEventHandler ExitingTableScreen;

    public delegate void ExitingTableScreenEventHandler();    // CheckDataDaseConnection()
    public event FireOrderScreenEventHandler FireOrderScreen;

    public delegate void FireOrderScreenEventHandler(ref DataSet_Builder.Payment tabAccountInfo);
    public event FireSeatingChartEventHandler FireSeatingChart;

    public delegate void FireSeatingChartEventHandler(bool fromMgmt);
    public event FireSeatingTabEventHandler FireSeatingTab;

    public delegate void FireSeatingTabEventHandler(string startedFrom, string tn); // As Boolean)
    public event QuickTicketStartEventHandler QuickTicketStart;

    public delegate void QuickTicketStartEventHandler(long experienceNumber); // ByVal tabID As Int64, ByVal tabName As String, 

    internal bool IsBartenderMode
    {
        get
        {
            return _IsBartenderMode;
        }
        set
        {
            _IsBartenderMode = value;
        }
    }

    #region  Windows Form Designer generated code 

    public Tables_Screen_Bar() : base() // ByRef emp As Employee, ByVal _IsBartenderMode As Boolean) ', ByVal barmanID As Integer)
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        // InitializeOther(emp.Bartender)  '(IsBartenderMode, barmanID)
        needToCorrectRoundingError = false;
        SeatingTab222.CustomerCardEvent += CustomerLoyalty222;
        SeatingTab222.OpenNewTabEvent += NewAddNewTab222;
        SeatingTab222.OpenNewTakeOutTab += NewAddNewTakeOutTab222;
        SeatingTab222.CancelNewTab += CancelNewTab222;

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
    private Global.System.Windows.Forms.Panel _pnlAvailTabs;

    internal virtual Global.System.Windows.Forms.Panel pnlAvailTabs
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlAvailTabs;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlAvailTabs = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlBartenderButtons;

    internal virtual Global.System.Windows.Forms.Panel pnlBartenderButtons
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlBartenderButtons;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pnlBartenderButtons != null)
            {
                _pnlBartenderButtons.Click -= Bartender_Click;
            }

            _pnlBartenderButtons = value;
            if (_pnlBartenderButtons != null)
            {
                _pnlBartenderButtons.Click += Bartender_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnAddTable;

    internal virtual Global.System.Windows.Forms.Button btnAddTable
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnAddTable;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnAddTable != null)
            {
                _btnAddTable.Click -= btnAddTable_Click;
            }

            _btnAddTable = value;
            if (_btnAddTable != null)
            {
                _btnAddTable.Click += btnAddTable_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnAddTab;

    internal virtual Global.System.Windows.Forms.Button btnAddTab
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnAddTab;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnAddTab != null)
            {
                _btnAddTab.Click -= btnAddTab_Click;
            }

            _btnAddTab = value;
            if (_btnAddTab != null)
            {
                _btnAddTab.Click += btnAddTab_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnAddTabGroup;

    internal virtual Global.System.Windows.Forms.Button btnAddTabGroup
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnAddTabGroup;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnAddTabGroup != null)
            {
                _btnAddTabGroup.Click -= btnAddTabGroup_Click;
            }

            _btnAddTabGroup = value;
            if (_btnAddTabGroup != null)
            {
                _btnAddTabGroup.Click += btnAddTabGroup_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _pnlTableCommands;

    internal virtual Global.System.Windows.Forms.Panel pnlTableCommands
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlTableCommands;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlTableCommands = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnBartenderLogin;

    internal virtual Global.System.Windows.Forms.Button btnBartenderLogin
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnBartenderLogin;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnBartenderLogin != null)
            {
                _btnBartenderLogin.Click -= btnBartenderLogin_Click;
            }

            _btnBartenderLogin = value;
            if (_btnBartenderLogin != null)
            {
                _btnBartenderLogin.Click += btnBartenderLogin_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnTablesExit;

    internal virtual Global.System.Windows.Forms.Button btnTablesExit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnTablesExit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnTablesExit != null)
            {
                _btnTablesExit.Click -= btnTablesExit_Click_1;
            }

            _btnTablesExit = value;
            if (_btnTablesExit != null)
            {
                _btnTablesExit.Click += btnTablesExit_Click_1;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnManager;

    internal virtual Global.System.Windows.Forms.Button btnManager
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnManager;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnManager != null)
            {
                _btnManager.Click -= btnManager_Click;
            }

            _btnManager = value;
            if (_btnManager != null)
            {
                _btnManager.Click += btnManager_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _Button1;

    internal virtual Global.System.Windows.Forms.Button Button1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Button1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Button1 != null)
            {
                _Button1.Click -= Button1_Click;
            }

            _Button1 = value;
            if (_Button1 != null)
            {
                _Button1.Click += Button1_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnClockOut;

    internal virtual Global.System.Windows.Forms.Button btnClockOut
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnClockOut;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnClockOut != null)
            {
                _btnClockOut.Click -= btnClockOut_Click;
            }

            _btnClockOut = value;
            if (_btnClockOut != null)
            {
                _btnClockOut.Click += btnClockOut_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblTablesName;

    internal virtual Global.System.Windows.Forms.Label lblTablesName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTablesName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblTablesName = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblTableTime;

    internal virtual Global.System.Windows.Forms.Label lblTableTime
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTableTime;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTableTime != null)
            {
                _lblTableTime.Click -= lblTableTime_Click;
            }

            _lblTableTime = value;
            if (_lblTableTime != null)
            {
                _lblTableTime.Click += lblTableTime_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnNoSale;

    internal virtual Global.System.Windows.Forms.Button btnNoSale
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnNoSale;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnNoSale != null)
            {
                _btnNoSale.Click -= btnNoSale_Click;
            }

            _btnNoSale = value;
            if (_btnNoSale != null)
            {
                _btnNoSale.Click += btnNoSale_Click;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(Tables_Screen_Bar));
        _pnlAvailTabs = new System.Windows.Forms.Panel();
        _pnlBartenderButtons = new System.Windows.Forms.Panel();
        _pnlBartenderButtons.Click += Bartender_Click;
        _lblTablesName = new System.Windows.Forms.Label();
        _Button1 = new System.Windows.Forms.Button();
        _Button1.Click += Button1_Click;
        _btnAddTable = new System.Windows.Forms.Button();
        _btnAddTable.Click += btnAddTable_Click;
        _btnAddTab = new System.Windows.Forms.Button();
        _btnAddTab.Click += btnAddTab_Click;
        _btnAddTabGroup = new System.Windows.Forms.Button();
        _btnAddTabGroup.Click += btnAddTabGroup_Click;
        _pnlTableCommands = new System.Windows.Forms.Panel();
        _btnClockOut = new System.Windows.Forms.Button();
        _btnClockOut.Click += btnClockOut_Click;
        _btnManager = new System.Windows.Forms.Button();
        _btnManager.Click += btnManager_Click;
        _btnTablesExit = new System.Windows.Forms.Button();
        _btnTablesExit.Click += btnTablesExit_Click_1;
        _btnBartenderLogin = new System.Windows.Forms.Button();
        _btnBartenderLogin.Click += btnBartenderLogin_Click;
        _btnNoSale = new System.Windows.Forms.Button();
        _btnNoSale.Click += btnNoSale_Click;
        _lblTableTime = new System.Windows.Forms.Label();
        _lblTableTime.Click += lblTableTime_Click;
        _pnlTableCommands.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlAvailTabs
        // 
        _pnlAvailTabs.Anchor = (Global.System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);

        _pnlAvailTabs.BackColor = System.Drawing.Color.Black;
        _pnlAvailTabs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        _pnlAvailTabs.Location = new System.Drawing.Point(56, 96);
        _pnlAvailTabs.Name = "_pnlAvailTabs";
        _pnlAvailTabs.Size = new System.Drawing.Size(864, 550);
        _pnlAvailTabs.TabIndex = 0;
        // 
        // pnlBartenderButtons
        // 
        _pnlBartenderButtons.BackColor = System.Drawing.Color.Transparent;
        _pnlBartenderButtons.Dock = System.Windows.Forms.DockStyle.Top;
        _pnlBartenderButtons.Location = new System.Drawing.Point(0, 0);
        _pnlBartenderButtons.Name = "_pnlBartenderButtons";
        _pnlBartenderButtons.Size = new System.Drawing.Size(1024, 80);
        _pnlBartenderButtons.TabIndex = 1;
        // 
        // lblTablesName
        // 
        _lblTablesName.BackColor = System.Drawing.Color.Transparent;
        _lblTablesName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblTablesName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _lblTablesName.Location = new System.Drawing.Point(16, 8);
        _lblTablesName.Name = "_lblTablesName";
        _lblTablesName.Size = new System.Drawing.Size(312, 32);
        _lblTablesName.TabIndex = 1;
        _lblTablesName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Button1
        // 
        _Button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _Button1.Location = new System.Drawing.Point(176, 24);
        _Button1.Name = "_Button1";
        _Button1.Size = new System.Drawing.Size(120, 48);
        _Button1.TabIndex = 0;
        _Button1.Text = "Test RealTIme";
        _Button1.Visible = false;
        // 
        // btnAddTable
        // 
        _btnAddTable.Anchor = System.Windows.Forms.AnchorStyles.Right;
        _btnAddTable.BackColor = System.Drawing.Color.SlateGray;
        _btnAddTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnAddTable.Location = new System.Drawing.Point(880, 210);
        _btnAddTable.Name = "_btnAddTable";
        _btnAddTable.Size = new System.Drawing.Size(120, 56);
        _btnAddTable.TabIndex = 2;
        _btnAddTable.Text = "Add Table";
        _btnAddTable.UseVisualStyleBackColor = false;
        // 
        // btnAddTab
        // 
        _btnAddTab.Anchor = System.Windows.Forms.AnchorStyles.Right;
        _btnAddTab.BackColor = System.Drawing.Color.LightSlateGray;
        _btnAddTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnAddTab.Location = new System.Drawing.Point(880, 290);
        _btnAddTab.Name = "_btnAddTab";
        _btnAddTab.Size = new System.Drawing.Size(120, 56);
        _btnAddTab.TabIndex = 3;
        _btnAddTab.Text = "Add Tab";
        _btnAddTab.UseVisualStyleBackColor = false;
        // 
        // btnAddTabGroup
        // 
        _btnAddTabGroup.Anchor = System.Windows.Forms.AnchorStyles.Right;
        _btnAddTabGroup.BackColor = System.Drawing.Color.LightSlateGray;
        _btnAddTabGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnAddTabGroup.ForeColor = System.Drawing.SystemColors.ControlText;
        _btnAddTabGroup.Location = new System.Drawing.Point(880, 370);
        _btnAddTabGroup.Name = "_btnAddTabGroup";
        _btnAddTabGroup.Size = new System.Drawing.Size(120, 56);
        _btnAddTabGroup.TabIndex = 4;
        _btnAddTabGroup.Text = "Add Tab Group";
        _btnAddTabGroup.UseVisualStyleBackColor = false;
        // 
        // pnlTableCommands
        // 
        _pnlTableCommands.BackColor = System.Drawing.Color.Transparent;
        _pnlTableCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        _pnlTableCommands.Controls.Add(_btnClockOut);
        _pnlTableCommands.Controls.Add(_btnManager);
        _pnlTableCommands.Controls.Add(_btnTablesExit);
        _pnlTableCommands.Controls.Add(_btnBartenderLogin);
        _pnlTableCommands.Controls.Add(_Button1);
        _pnlTableCommands.Controls.Add(_btnNoSale);
        _pnlTableCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
        _pnlTableCommands.Location = new System.Drawing.Point(0, 688);
        _pnlTableCommands.Name = "_pnlTableCommands";
        _pnlTableCommands.Size = new System.Drawing.Size(1024, 80);
        _pnlTableCommands.TabIndex = 5;
        // 
        // btnClockOut
        // 
        _btnClockOut.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        _btnClockOut.BackColor = System.Drawing.Color.LightSlateGray;
        _btnClockOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnClockOut.Location = new System.Drawing.Point(879, 6);
        _btnClockOut.Name = "_btnClockOut";
        _btnClockOut.Size = new System.Drawing.Size(112, 64);
        _btnClockOut.TabIndex = 4;
        _btnClockOut.Text = "Clock Out";
        _btnClockOut.UseVisualStyleBackColor = false;
        // 
        // btnManager
        // 
        _btnManager.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        _btnManager.BackColor = System.Drawing.Color.LightSlateGray;
        _btnManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnManager.Location = new System.Drawing.Point(315, 6);
        _btnManager.Name = "_btnManager";
        _btnManager.Size = new System.Drawing.Size(120, 64);
        _btnManager.TabIndex = 3;
        _btnManager.Text = "Manager";
        _btnManager.UseVisualStyleBackColor = false;
        // 
        // btnTablesExit
        // 
        _btnTablesExit.Anchor = System.Windows.Forms.AnchorStyles.Left;
        _btnTablesExit.BackColor = System.Drawing.Color.SlateGray;
        _btnTablesExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnTablesExit.Location = new System.Drawing.Point(32, 7);
        _btnTablesExit.Name = "_btnTablesExit";
        _btnTablesExit.Size = new System.Drawing.Size(112, 64);
        _btnTablesExit.TabIndex = 2;
        _btnTablesExit.Text = "Exit";
        _btnTablesExit.UseVisualStyleBackColor = false;
        // 
        // btnBartenderLogin
        // 
        _btnBartenderLogin.Anchor = System.Windows.Forms.AnchorStyles.Right;
        _btnBartenderLogin.BackColor = System.Drawing.Color.SlateGray;
        _btnBartenderLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnBartenderLogin.Location = new System.Drawing.Point(742, 7);
        _btnBartenderLogin.Name = "_btnBartenderLogin";
        _btnBartenderLogin.Size = new System.Drawing.Size(112, 64);
        _btnBartenderLogin.TabIndex = 0;
        _btnBartenderLogin.Text = "Clock In";
        _btnBartenderLogin.UseVisualStyleBackColor = false;
        _btnBartenderLogin.Visible = false;
        // 
        // btnNoSale
        // 
        _btnNoSale.Anchor = System.Windows.Forms.AnchorStyles.Right;
        _btnNoSale.BackColor = System.Drawing.Color.LightSlateGray;
        _btnNoSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnNoSale.ForeColor = System.Drawing.SystemColors.ControlText;
        _btnNoSale.Location = new System.Drawing.Point(606, 7);
        _btnNoSale.Name = "_btnNoSale";
        _btnNoSale.Size = new System.Drawing.Size(112, 64);
        _btnNoSale.TabIndex = 5;
        _btnNoSale.Text = "No Sale";
        _btnNoSale.UseVisualStyleBackColor = false;
        // 
        // lblTableTime
        // 
        _lblTableTime.Anchor = (Global.System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
        _lblTableTime.BackColor = System.Drawing.Color.Transparent;
        _lblTableTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblTableTime.ForeColor = System.Drawing.Color.MediumBlue;
        _lblTableTime.Location = new System.Drawing.Point(872, 624);
        _lblTableTime.Name = "_lblTableTime";
        _lblTableTime.Size = new System.Drawing.Size(120, 48);
        _lblTableTime.TabIndex = 6;
        _lblTableTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Tables_Screen_Bar
        // 
        this.BackColor = System.Drawing.SystemColors.Control;
        this.BackgroundImage = (Global.System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
        this.Controls.Add(_lblTablesName);
        this.Controls.Add(_lblTableTime);
        this.Controls.Add(_pnlTableCommands);
        this.Controls.Add(_btnAddTabGroup);
        this.Controls.Add(_btnAddTab);
        this.Controls.Add(_btnAddTable);
        this.Controls.Add(_pnlBartenderButtons);
        this.Controls.Add(_pnlAvailTabs);
        this.Name = "Tables_Screen_Bar";
        this.Size = new System.Drawing.Size(1024, 768);
        _pnlTableCommands.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    internal void InitializeOther(bool IsBar)
    {

        // If IsBar = True And usingBartenderMethod = True Then
        // IsBartenderMode = True
        // Else
        // IsBartenderMode = False
        // End If

        // blankPanel = New Panel
        // blankPanel.Location = New Point(0, 0)
        // blankPanel.Size = New Size(1024, 768)
        // Me.Controls.Add(blankPanel)
        // Me.blankPanel.Visible = False

        // NumBar = CalculateNumberOfBartenders()
        // If NumBar > 1 Then
        // IsOneBartender = False
        // End If

        // Me.ClientSize = New Size(ssX, ssY)
        // Me.pnlAvailTabs.Size = New Size(ssX * 0.85, ssY * 0.67)
        updateClockTimer = new DateAndTime.Timer();
        updateClockTimer.Interval = 60000;

        if (IsBartenderMode == false & !(currentTerminal.TermMethod == "Quick"))
        {
            tablesInactiveCounter = 1;
            tablesInactiveTimer = new DateAndTime.Timer();
            tablesInactiveTimer.Tick += TablesInactiveScreenTimeout;
            tablesInactiveTimer.Interval = timeoutInterval;
            tablesInactiveTimer.Start();
            // Else
            // currentTerminal.IsOneBartender = True
        }

        InitializeScreen();

    }

    // Private Sub KeepActive(ByVal sender As Object, ByVal e As System.EventArgs)
    // keepActiveInteger += 1
    // End Sub

    internal void InitializeScreen()
    {

        PopulateAllTablesWithStatus(false);

        if (IsBartenderMode == true)
        {
            DisplayBartenderButtons();
            TableAndTabButtons();
            pnlBartenderButtons.Visible = true;
            btnBartenderLogin.Visible = true;
            lblTablesName.Visible = false;
        }
        else
        {
            pnlBartenderButtons.Visible = false;
            lblTablesName.Visible = true;
            lblTablesName.Text = currentServer.FullName;
            // tablesInactiveCounter = 1
            if (!(currentTerminal.TermMethod == "Quick"))
            {
                tablesInactiveTimer.Tick += TablesInactiveScreenTimeout;
                // tablesInactiveTimer.Interval = timeoutInterval
                tablesInactiveTimer.Start();
            }
            else
            {
                btnBartenderLogin.Visible = true;
            }

        }
        // MsgBox(Me.pnlAvailTabs.Height)

        if (currentServer.Cashier == true | currentServer.Bartender == true | currentServer.Manager == true)
        {
            btnNoSale.Visible = true;
        }
        else
        {
            btnNoSale.Visible = false;
        }
        // 444       If currentServer.Bartender = False And currentServer.Manager = False Then
        if (IsBartenderMode == false) // And Not currentTerminal.TermMethod = "Quick" Then
        {
            // if one is true let us perform
            btnAddTabGroup.Visible = false;
        }
        if (currentTerminal.TermMethod == "Quick")
        {
            if (dsOrder.Tables("QuickTickets").Rows.Count > 0)
            {
                btnAddTab.Visible = false;
            }
            else
            {
                btnAddTab.Text = "Start Tabs";
            }
        }
        if (ds.Tables("TermsTables").Rows.Count == 0)
        {
            btnAddTable.Visible = false;
        }

        GenerateOrderTables.PopulateTabsAndTables(currentServer, currentTerminal.CurrentDailyCode, IsBartenderMode, currentTerminal.IsOneBartender, currentBartenders);
        CreateDataViews(currentServer.EmployeeID, true);
        DisplayTabsAndTables(quickEndCount);
        SetTableScreenTime();
        updateClockTimer.Tick += UpdateTableScreenTime;
        updateClockTimer.Start();


    }

    private void TablesInactiveScreenTimeout(object sender, EventArgs e)
    {

        tablesInactiveCounter += 1;

        if (tablesInactiveCounter == companyInfo.timeoutMultiplier)       // 14 Then
        {
            // updateClockTimer.Dispose()
            // tablesInactiveTimer.Dispose()
            ExitingTableScreen?.Invoke();
        }

    }

    private void StopTablesTimer()
    {

        if (IsBartenderMode == false & !(currentTerminal.TermMethod == "Quick"))
        {
            tablesInactiveTimer.Stop();
            tablesInactiveTimer.Tick -= TablesInactiveScreenTimeout;
        }

        updateClockTimer.Stop();
        updateClockTimer.Tick -= UpdateTableScreenTime;

    }

    private void UpdatingTableData222(Employee emp, ref CashClose_UC ccDisplay)  // , ManagementForm.UpdatingAfterTransfer
    {
        DataSet_Builder.Information_UC info;
        info = new DataSet_Builder.Information_UC("Attempting to Reconnect To Server");

        if (mainServerConnected == false)
        {
            info.Location = new Point((this.Width - info.Width) / 2, (this.Height - info.Height) / 2);
            this.Controls.Add(info);
            info.BringToFront();

        }

        // *******
        // having problem with thread
        // would like to stop here until info is displayed

        // ActiveOrder.Visible = False
        // Me.ActiveOrder.ReInitializeOrderView()
        // GenerateOrderTables.SaveOpenOrderData()
        // dsOrder.Tables("OpenOrders").Rows.Clear()
        // GenerateOrderTables.ReleaseCurrentlyHeld()
        // currentTable = Nothing
        // Exit Sub


        ActiveOrder.Dispose();
        ActiveOrder = default;
        // ActiveOrder.Dispose()
        GenerateOrderTables.ReleaseCurrentlyHeld();
        GenerateOrderTables.SaveOpenOrderData();
        // dsOrder.Tables("OpenOrders").Rows.Clear()
        currentTable = (object)null;
        // don't need here if we save every time we status change
        // GenerateOrderTables.SaveESCStatusChangeData()
        if (ccDisplay is not null)
        {
            ccDisplay.Location = new Point((this.Width - ccDisplay.Width) / 2, (this.Height - ccDisplay.Height) / 2);
            this.Controls.Add(ccDisplay);
            ccDisplay.BringToFront();
        }

        InitializeScreen();
        tablesInactiveCounter = 10;
        info.Dispose();

        // MsgBox("111111111")
        // GC.Collect()
        // MsgBox("2222222222")


        // ******************
        // maybe this is where we update experience table

    }

    // Private Function CalculateNumberOfBartenders222()
    // Dim NumberOfBartenders As Integer
    // NumberOfBartenders = currentBartenders.Count
    // Return NumberOfBartenders
    // End Function

    private void DisplayBartenderButtons()
    {

        int NumBar;
        int w = 112;
        int h = 64;
        int x = 2 * buttonSpace;
        int y = 2 * buttonSpace;
        int index;
        Color backColorBarButton;

        pnlBartenderButtons.Controls.Clear();

        foreach (Employee barMan in loggedInBartenders)   // currentBartenders
        {

            if (barMan.EmployeeID == currentServer.EmployeeID)
            {
                backColorBarButton = c9;
            }
            else
            {
                backColorBarButton = c7;
            }

            AddBartenderButton(x, y, w, h, barMan.NickName, barMan.EmployeeID, backColorBarButton);
            x = x + w + 2 * buttonSpace;
        }

        // ALL Button
        x = this.Width - (w + 6 * buttonSpace);

        if (currentTerminal.IsOneBartender == false)
        {
            backColorBarButton = c9;
        }
        else
        {
            backColorBarButton = c7;
        }

        AddBartenderButton(x, y, w, h, "All", -1, backColorBarButton);

    }

    private void AddBartenderButton(int x, int y, int w, int h, string barButtonText, int barButtonID, Color barBackColor)
    {
        KitchenButton btnBartenders;

        btnBartenders = new KitchenButton(barButtonText, w, h, barBackColor, c2);
        btnBartenders.Location = new Point(x, y);
        btnBartenders.ID = barButtonID;
        // btnBartenders.ForeColor = c3

        btnBartenders.Click += Bartender_Click;
        pnlBartenderButtons.Controls.Add(btnBartenders);

    }

    private void TableAndTabButtons()
    {
        btnAddTab.BackColor = System.Drawing.Color.SlateGray;
        btnAddTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

        btnAddTabGroup.BackColor = System.Drawing.Color.SlateGray;
        btnAddTabGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

    }

    private void DisplayTabsAndTables(int endCount)
    {

        pnlAvailTabs.Controls.Clear();

        DataRowView vRow;
        DataView dv;
        var index = default(int);
        int counterIndex = 1;
        int startingCount = 0;
        float w;
        float h;
        float x = buttonSpace;
        float y = buttonSpace;
        string ls;
        TimeSpan lsTime;
        TimeSpan timeAtTable;
        string altMethodUse = "";
        int numberPanelsInColumn;


        if (!(currentTerminal.TermMethod == "Quick"))
        {
            // Also it is using a smaller pnlAvailTabs.Height the first time bring up Tables_Screen
            // probvably doesn't matter
            // somewhere a rounding error???
            w = (pnlAvailTabs.Width - 5 * buttonSpace) / 4;
            h = (pnlAvailTabs.Height - 9 * buttonSpace) / 8;
            numberPanelsInColumn = 8;

            // ReDim btnTabsAndTables(dsOrder.Tables("AvailTables").Rows.Count + dsOrder.Tables("AvailTabs").Rows.Count - 1)
            if (needToCorrectRoundingError == true)
            {
                h = (float)(h - 1.5d);
            }

            if (endCount > 32)
            {
                startingCount = endCount - 32;
            }
            else
            {
                startingCount = 0;
            }


            foreach (DataRowView currentVRow in dvAvailTables)
            {
                vRow = currentVRow;
                if (index >= startingCount & index <= endCount | endCount == 0)
                {
                    // test         MsgBox(vRow("TableNumber"))
                    // test    MsgBox(vRow("ExperienceNumber"))

                    ls = Conversions.ToString(AssignCurrentStatusString(vRow("LastStatus")));
                    lsTime = (TimeSpan)DetermineTimeSpan(vRow("LastStatusTime"));
                    timeAtTable = (TimeSpan)DetermineTimeSpan(vRow("ExperienceDate"));

                    try
                    {
                        if (!(dvTerminalsUseOrder[0]("MethodUse") == vRow("MethodUse")))
                        {
                            altMethodUse = vRow("MethodUse");
                        }
                        else
                        {
                            altMethodUse = "";
                        }
                        var btnTabsAndTables = new DataSet_Builder.AvailTableUserControl(false, vRow("TableNumber"), default, vRow("TabName").ToString, vRow("TicketNumber"), vRow("LastStatus"), ls, lsTime, timeAtTable, default, vRow("ItemsOnHold"), currentTerminal.TermMethod, altMethodUse);
                        // btnTabsAndTables(index) = New DataSet_Builder.AvailTableUserControl(vRow("TableNumber"), vRow("TabName").ToString, vRow("LastStatus"), ls, lsTime, timeAtTable) 'AvailTableButton
                        btnTabsAndTables.SatTime = vRow("ExperienceDate");
                        btnTabsAndTables.Text = vRow("TabName"); // vRow("TableNumber")
                        btnTabsAndTables.NumberOfCustomers = vRow("NumberOfCustomers");
                        btnTabsAndTables.NumberOfChecks = vRow("NumberOfChecks");
                        btnTabsAndTables.ExperienceNumber = vRow("ExperienceNumber");
                        btnTabsAndTables.EmpID = vRow("EmployeeID");
                        btnTabsAndTables.CurrentMenu = vRow("MenuID");
                        btnTabsAndTables.Size = new Size(w, h);
                        btnTabsAndTables.Location = new Point(x, y);

                        // .BackColor = c7
                        // .ForeColor = c3
                        btnTabsAndTables.TableClicked += Tables_Click;
                        pnlAvailTabs.Controls.Add(btnTabsAndTables);
                    }
                    // *****         btnTabsAndTables(index).ShowTableStatistics()
                    catch (Exception ex)
                    {

                    }

                    if (counterIndex == numberPanelsInColumn)
                    {
                        y = buttonSpace;
                        x += w + buttonSpace;
                        counterIndex = 0;    // must restart at zero b/c we add 1 right away
                    }
                    else
                    {
                        y += h + buttonSpace;
                    }
                    index += 1;
                    counterIndex += 1;
                }
                else
                {
                    index += 1;
                }

            }

            foreach (DataRowView currentVRow1 in dvAvailTabs)
            {
                vRow = currentVRow1;
                if (index > startingCount & index <= endCount | endCount == 0)
                {
                    ls = Conversions.ToString(AssignCurrentStatusString(vRow("LastStatus")));
                    lsTime = (TimeSpan)DetermineTimeSpan(vRow("LastStatusTime"));

                    timeAtTable = (TimeSpan)DetermineTimeSpan(vRow("ExperienceDate"));

                    try
                    {
                        if (!(dvTerminalsUseOrder[0]("MethodUse") == vRow("MethodUse")))
                        {
                            altMethodUse = vRow("MethodUse");
                        }
                        else
                        {
                            altMethodUse = "";
                        }
                        var btnTabsAndTables = new DataSet_Builder.AvailTableUserControl(true, default, vRow("TabID"), vRow("TabName"), vRow("TicketNumber"), vRow("LastStatus"), ls, lsTime, timeAtTable, default, vRow("ItemsOnHold"), currentTerminal.TermMethod, altMethodUse);
                        // Dim btnTabsAndTables As New DataSet_Builder.AvailTableUserControl(True, Nothing, 0, vRow("TabName"), vRow("TicketNumber"), vRow("LastStatus"), ls, lsTime, timeAtTable, Nothing, vRow("ItemsOnHold"))
                        btnTabsAndTables.SatTime = vRow("ExperienceDate");
                        btnTabsAndTables.Text = vRow("TabName");
                        btnTabsAndTables.NumberOfCustomers = vRow("NumberOfCustomers");
                        btnTabsAndTables.NumberOfChecks = vRow("NumberOfChecks");
                        btnTabsAndTables.ExperienceNumber = vRow("ExperienceNumber");
                        btnTabsAndTables.EmpID = vRow("EmployeeID");
                        btnTabsAndTables.CurrentStatus = AssignCurrentStatusString(vRow("LastStatus"));
                        btnTabsAndTables.CurrentMenu = vRow("MenuID");
                        btnTabsAndTables.TabID = vRow("TabID");
                        btnTabsAndTables.Size = new Size(w, h);
                        btnTabsAndTables.Location = new Point(x, y);
                        // .BackColor = c7
                        // .ForeColor = c3
                        btnTabsAndTables.TableClicked += Tabs_Click;
                        pnlAvailTabs.Controls.Add(btnTabsAndTables);
                    }
                    catch (Exception ex)
                    {

                    }


                    if (counterIndex == numberPanelsInColumn)
                    {
                        y = buttonSpace;
                        x += w + buttonSpace;
                        counterIndex = 0;    // must restart at zero b/c we add 1 right away
                    }
                    else
                    {
                        y += h + buttonSpace;
                    }
                    index += 1;
                    counterIndex += 1;
                }
                else
                {
                    index += 1;
                }

            }

            foreach (DataRowView currentVRow2 in dvTransferTables)
            {
                vRow = currentVRow2;
                if (index > startingCount & index <= endCount | endCount == 0)
                {
                    ls = Conversions.ToString(AssignCurrentStatusString(vRow("LastStatus")));
                    lsTime = (TimeSpan)DetermineTimeSpan(vRow("LastStatusTime"));

                    timeAtTable = (TimeSpan)DetermineTimeSpan(vRow("ExperienceDate"));

                    try
                    {
                        if (!(dvTerminalsUseOrder[0]("MethodUse") == vRow("MethodUse")))
                        {
                            altMethodUse = vRow("MethodUse");
                        }
                        else
                        {
                            altMethodUse = "";
                        }
                        var btnTabsAndTables = new DataSet_Builder.AvailTableUserControl(false, 0, default, vRow("TabName").ToString, vRow("TicketNumber"), vRow("LastStatus"), ls, lsTime, timeAtTable, default, vRow("ItemsOnHold"), currentTerminal.TermMethod, altMethodUse);
                        // Dim btnTabsAndTables As New DataSet_Builder.AvailTableUserControl(False, vrow("TableNumber") , Nothing, vRow("TabName").ToString, vRow("TicketNumber"), vRow("LastStatus"), ls, lsTime, timeAtTable, Nothing, vRow("ItemsOnHold"))
                        btnTabsAndTables.SatTime = vRow("ExperienceDate");
                        btnTabsAndTables.Text = vRow("TabName"); // vRow("TableNumber")
                        btnTabsAndTables.NumberOfCustomers = vRow("NumberOfCustomers");
                        btnTabsAndTables.NumberOfChecks = vRow("NumberOfChecks");
                        btnTabsAndTables.ExperienceNumber = vRow("ExperienceNumber");
                        btnTabsAndTables.EmpID = vRow("EmployeeID");
                        btnTabsAndTables.CurrentStatus = AssignCurrentStatusString(vRow("LastStatus"));
                        btnTabsAndTables.CurrentMenu = vRow("MenuID");
                        btnTabsAndTables.Size = new Size(w, h);
                        btnTabsAndTables.Location = new Point(x, y);
                        // .BackColor = c1
                        // .ForeColor = c2
                        btnTabsAndTables.TableClicked += Tables_Click;
                        pnlAvailTabs.Controls.Add(btnTabsAndTables);
                    }
                    catch (Exception ex)
                    {

                    }

                    if (counterIndex == numberPanelsInColumn)
                    {
                        y = buttonSpace;
                        x += w + buttonSpace;
                        counterIndex = 0;    // must restart at zero b/c we add 1 right away
                    }
                    else
                    {
                        y += h + buttonSpace;
                    }
                    index += 1;
                    counterIndex += 1;
                }
                else
                {
                    index += 1;
                }

            }

            // *** should probably use tab name
            foreach (DataRowView currentVRow3 in dvTransferTabs)
            {
                vRow = currentVRow3;
                if (index > startingCount & index <= endCount | endCount == 0)
                {
                    ls = Conversions.ToString(AssignCurrentStatusString(vRow("LastStatus")));
                    lsTime = (TimeSpan)DetermineTimeSpan(vRow("LastStatusTime"));
                    timeAtTable = (TimeSpan)DetermineTimeSpan(vRow("ExperienceDate"));

                    try
                    {
                        if (!(dvTerminalsUseOrder[0]("MethodUse") == vRow("MethodUse")))
                        {
                            altMethodUse = vRow("MethodUse");
                        }
                        else
                        {
                            altMethodUse = "";
                        }
                        var btnTabsAndTables = new DataSet_Builder.AvailTableUserControl(true, default, vRow("TabID"), vRow("TabName"), vRow("TicketNumber"), vRow("LastStatus"), ls, lsTime, timeAtTable, default, vRow("ItemsOnHold"), currentTerminal.TermMethod, altMethodUse);
                        // Dim btnTabsAndTables As New DataSet_Builder.AvailTableUserControl(True, Nothing, vRow("TableNumber"), vRow("TabName"), vRow("TicketNumber"), vRow("LastStatus"), ls, lsTime, timeAtTable, Nothing, vRow("ItemsOnHold"))
                        btnTabsAndTables.SatTime = vRow("ExperienceDate");
                        btnTabsAndTables.Text = vRow("TabName"); // vRow("TableNumber")
                        btnTabsAndTables.NumberOfCustomers = vRow("NumberOfCustomers");
                        btnTabsAndTables.NumberOfChecks = vRow("NumberOfChecks");
                        btnTabsAndTables.ExperienceNumber = vRow("ExperienceNumber");
                        btnTabsAndTables.EmpID = vRow("EmployeeID");
                        btnTabsAndTables.CurrentStatus = AssignCurrentStatusString(vRow("LastStatus"));
                        btnTabsAndTables.CurrentMenu = vRow("MenuID");
                        btnTabsAndTables.Size = new Size(w, h);
                        btnTabsAndTables.Location = new Point(x, y);
                        // .BackColor = c1
                        // .ForeColor = c2
                        btnTabsAndTables.TableClicked += Tables_Click;
                        pnlAvailTabs.Controls.Add(btnTabsAndTables);
                    }
                    catch (Exception ex)
                    {

                    }

                    if (counterIndex == numberPanelsInColumn)
                    {
                        y = buttonSpace;
                        x += w + buttonSpace;
                        counterIndex = 0;    // must restart at zero b/c we add 1 right away
                    }
                    else
                    {
                        y += h + buttonSpace;
                    }
                    index += 1;
                    counterIndex += 1;
                }
                else
                {
                    index += 1;
                }

            }

            if (dsOrder.Tables("QuickTickets").Rows.Count > 0)
            {

                foreach (DataView currentDv in currentQuickTicketDataViews)
                {
                    dv = currentDv;
                    if (index > startingCount & index <= endCount | endCount == 0)
                    {
                        // this is the last row in each of the DataView Collections
                        // the dataviews are grouped by bartender

                        // If currentTerminal.TermMethod = "Quick" Then
                        // If quickEndCount < 12 Then
                        // quickEndCount = (dv.Count - 1)
                        // Else
                        // quickEndCount -= 12
                        // End If
                        // DisplayTIcketsForQuick(dv, dv.Count - 1)
                        // Exit For
                        // End If

                        // this was supposed to show alternative methods on Table pad
                        // does not work for Beth's Tabs, b/c multiple dataviews
                        // probably not needed
                        // If Not dvTerminalsUseOrder(0)("MethodUse") = vRow("MethodUse") Then
                        // altMethodUse = vRow("MethodUse")
                        // Else
                        altMethodUse = "";
                        // End If

                        if (dv.Count > 0)
                        {
                            vRow = dv(dv.Count - 1);


                            if (currentTerminal.IsOneBartender == true)
                            {
                                if (vRow("EmployeeID") == currentServer.EmployeeID)
                                {
                                    ls = Conversions.ToString(AssignCurrentStatusString(vRow("LastStatus")));
                                    lsTime = (TimeSpan)DetermineTimeSpan(vRow("LastStatusTime"));

                                    timeAtTable = (TimeSpan)DetermineTimeSpan(vRow("ExperienceDate"));

                                    try
                                    {

                                        var btnTabsAndTables = new DataSet_Builder.AvailTableUserControl(true, 0, 0, vRow("TabName"), vRow("TicketNumber"), vRow("LastStatus"), ls, lsTime, timeAtTable, default, 0, currentTerminal.TermMethod, altMethodUse);
                                        // btnTabsAndTables(index) = New DataSet_Builder.AvailTableUserControl(0, vRow("TabName"), vRow("LastStatus"), ls, lsTime, timeAtTable) 'AvailTableButton
                                        btnTabsAndTables.SatTime = vRow("ExperienceDate");
                                        btnTabsAndTables.Text = vRow("TicketNumber");    // vRow("TabName")
                                        btnTabsAndTables.NumberOfCustomers = vRow("NumberOfCustomers");
                                        btnTabsAndTables.NumberOfChecks = vRow("NumberOfChecks");
                                        btnTabsAndTables.ExperienceNumber = vRow("ExperienceNumber");
                                        btnTabsAndTables.EmpID = vRow("EmployeeID");
                                        btnTabsAndTables.CurrentStatus = AssignCurrentStatusString(vRow("LastStatus"));
                                        btnTabsAndTables.CurrentMenu = vRow("MenuID");
                                        btnTabsAndTables.TabID = vRow("TabID");
                                        btnTabsAndTables.Size = new Size(w, h);
                                        btnTabsAndTables.Location = new Point(x, y);
                                        // .BackColor = c7
                                        // .ForeColor = c3
                                        btnTabsAndTables.TableClicked += Tabs_Click;
                                        pnlAvailTabs.Controls.Add(btnTabsAndTables);
                                    }
                                    catch (Exception ex)
                                    {

                                    }

                                    if (counterIndex == numberPanelsInColumn)
                                    {
                                        y = buttonSpace;
                                        x += w + buttonSpace;
                                        counterIndex = 0;    // must restart at zero b/c we add 1 right away
                                    }
                                    else
                                    {
                                        y += h + buttonSpace;
                                    }
                                    index += 1;
                                    counterIndex += 1;
                                }
                            }
                            else
                            {
                                ls = Conversions.ToString(AssignCurrentStatusString(vRow("LastStatus")));
                                lsTime = (TimeSpan)DetermineTimeSpan(vRow("LastStatusTime"));

                                timeAtTable = (TimeSpan)DetermineTimeSpan(vRow("ExperienceDate"));

                                try
                                {

                                    var btnTabsAndTables = new DataSet_Builder.AvailTableUserControl(true, 0, 0, vRow("TabName"), vRow("TicketNumber"), vRow("LastStatus"), ls, lsTime, timeAtTable, default, 0, currentTerminal.TermMethod, altMethodUse);
                                    // btnTabsAndTables(index) = New DataSet_Builder.AvailTableUserControl(0, vRow("TabName"), vRow("LastStatus"), ls, lsTime, timeAtTable) 'AvailTableButton
                                    btnTabsAndTables.SatTime = vRow("ExperienceDate");
                                    btnTabsAndTables.Text = vRow("TicketNumber"); // vRow("TabName")
                                    btnTabsAndTables.NumberOfCustomers = vRow("NumberOfCustomers");
                                    btnTabsAndTables.NumberOfChecks = vRow("NumberOfChecks");
                                    btnTabsAndTables.ExperienceNumber = vRow("ExperienceNumber");
                                    btnTabsAndTables.EmpID = vRow("EmployeeID");
                                    btnTabsAndTables.CurrentStatus = AssignCurrentStatusString(vRow("LastStatus"));
                                    btnTabsAndTables.CurrentMenu = vRow("MenuID");
                                    btnTabsAndTables.TabID = vRow("TabID");
                                    btnTabsAndTables.Size = new Size(w, h);
                                    btnTabsAndTables.Location = new Point(x, y);
                                    // .BackColor = c7
                                    // .ForeColor = c3
                                    btnTabsAndTables.TableClicked += Tabs_Click;
                                    pnlAvailTabs.Controls.Add(btnTabsAndTables);
                                }
                                catch (Exception ex)
                                {

                                }

                                if (counterIndex == numberPanelsInColumn)
                                {
                                    y = buttonSpace;
                                    x += w + buttonSpace;
                                    counterIndex = 0;    // must restart at zero b/c we add 1 right away
                                }
                                else
                                {
                                    y += h + buttonSpace;
                                }
                                index += 1;
                                counterIndex += 1;
                            }

                        }
                    }
                    else
                    {
                        index += 1;
                    }

                }

            }
        }

        else    // this is Quick Service
        {

            foreach (DataView currentDv1 in currentQuickTicketDataViews)
            {
                dv = currentDv1;
                // If currentTerminal.TermMethod = "Quick" Then
                if (quickEndCount < 12)
                {
                    quickEndCount = dv.Count - 1;
                }
                else
                {
                    quickEndCount -= 12;
                }
                DisplayTIcketsForQuick(ref dv, dv.Count - 1);
                break;
                // End If
            }

        }


        this.BringToFront();       // ??????? to make sure in front

    }

    private void DisplayTIcketsForQuick(ref DataView dv, int endCount)
    {

        int startingCount;
        int index;
        DataRowView vRow;
        int counterIndex = 1;
        float w;
        float h;
        float x = buttonSpace;
        float y = buttonSpace;
        string ls;
        TimeSpan lsTime;
        TimeSpan timeAtTable;
        string altMethodUse = "";

        w = (pnlAvailTabs.Width - 7 * buttonSpace) / 6;
        h = (pnlAvailTabs.Height - 13 * buttonSpace) / 12;

        // w = (Me.pnlAvailTabs.Width - (5 * buttonSpace)) / 4
        // h = (Me.pnlAvailTabs.Height - (9 * buttonSpace)) / 8
        // w = (Me.pnlAvailTabs.Width - (7 * buttonSpace)) / 6
        // h = (Me.pnlAvailTabs.Height - (11 * buttonSpace)) / 10
        if (needToCorrectRoundingError == true)
        {
            h = (float)(h - 1.5d);
        }

        // startingCount = endCount - (dv.Count - 1)
        // If startingCount < 0 Then startingCount = 0
        if (endCount > 71) // dv.Count > 71 Then
        {
            startingCount = endCount - 71;
        }
        else
        {
            startingCount = 0;
        }

        var loopTo = startingCount;
        for (index = endCount; index >= loopTo; index -= 1)
        {
            vRow = dv[index];

            ls = Conversions.ToString(AssignCurrentStatusString(vRow("LastStatus")));
            lsTime = (TimeSpan)DetermineTimeSpan(vRow("LastStatusTime"));

            timeAtTable = (TimeSpan)DetermineTimeSpan(vRow("ExperienceDate"));

            try
            {
                if (!(dvTerminalsUseOrder[0]("MethodUse") == vRow("MethodUse")))
                {
                    altMethodUse = vRow("MethodUse");
                }
                else
                {
                    altMethodUse = "";
                }

                var btnTabsAndTables = new DataSet_Builder.AvailTableUserControl(true, 0, 0, vRow("TabName"), vRow("TicketNumber"), vRow("LastStatus"), ls, lsTime, timeAtTable, default, 0, currentTerminal.TermMethod, altMethodUse);
                // btnTabsAndTables(index) = New DataSet_Builder.AvailTableUserControl(0, vRow("TabName"), vRow("LastStatus"), ls, lsTime, timeAtTable) 'AvailTableButton
                btnTabsAndTables.SatTime = vRow("ExperienceDate");
                btnTabsAndTables.Text = vRow("TicketNumber"); // vRow("TabName")
                btnTabsAndTables.NumberOfCustomers = vRow("NumberOfCustomers");
                btnTabsAndTables.NumberOfChecks = vRow("NumberOfChecks");
                btnTabsAndTables.ExperienceNumber = vRow("ExperienceNumber");
                btnTabsAndTables.EmpID = vRow("EmployeeID");
                btnTabsAndTables.CurrentStatus = AssignCurrentStatusString(vRow("LastStatus"));
                btnTabsAndTables.CurrentMenu = vRow("MenuID");
                btnTabsAndTables.TabID = vRow("TabID");
                btnTabsAndTables.Size = new Size(w, h);
                btnTabsAndTables.Location = new Point(x, y);
                // .BackColor = c7
                // .ForeColor = c3
                btnTabsAndTables.TableClicked += Tabs_Click;
                pnlAvailTabs.Controls.Add(btnTabsAndTables);
            }
            catch (Exception ex)
            {

            }

            if (counterIndex == 12)
            {
                y = buttonSpace;
                x += w + buttonSpace;
                counterIndex = 0;    // must restart at zero b/c we add 1 right away
            }
            else
            {
                y += h + buttonSpace;
            }
            // index += 1
            counterIndex += 1;
        }

    }

    private object AssignCurrentStatusString(int statusID)
    {
        var currentStatus = default(string);

        foreach (DataRow oRow in ds.Tables("TableStatusDesc").Rows)
        {
            // If Not oRow("TableStatusID") Is DBNull.Value Then
            // End If
            if (oRow("TableStatusID") == statusID)
            {
                currentStatus = oRow("TableStatusDesc");
                break;
            }
        }

        return currentStatus;

    }

    private object DetermineTimeSpan(DateTime timeQuestion)
    {
        TimeSpan timeDifference;

        timeDifference = DateTime.Now.Subtract(timeQuestion);
        // timeDifference = Format(timeDifference.Minutes, "###")

        return timeDifference;

    }

    private void Bartender_Click(object sender, EventArgs e)
    {
        var objButton = new KitchenButton("ForTesting", 0, 0, c3, c2);
        if (!object.ReferenceEquals(sender.GetType(), objButton.GetType))
            return;

        int index;
        pnlAvailTabs.Controls.Clear();

        objButton = (KitchenButton)sender;
        if (objButton.ID == -1)
        {
            if (currentTerminal.IsOneBartender == false)
            {
                currentTerminal.IsOneBartender = true;
                objButton.BackColor = c7;
                GenerateOrderTables.PopulateTabsAndTables(currentServer, currentTerminal.CurrentDailyCode, IsBartenderMode, currentTerminal.IsOneBartender, currentBartenders);
            }
            else
            {
                currentTerminal.IsOneBartender = false;
                objButton.BackColor = c9;
                GenerateOrderTables.PopulateTabsAndTables(currentServer, currentTerminal.CurrentDailyCode, IsBartenderMode, currentTerminal.IsOneBartender, currentBartenders);
            }
            CreateDataViews(currentServer.EmployeeID, true);
            DisplayTabsAndTables(0);
        }
        else
        {
            foreach (Employee BarMan in currentBartenders)
            {
                if (BarMan.EmployeeID == objButton.ID)
                {
                    currentServer = BarMan;
                }
            }
            // this is used if we want to change where tables are displayed only by selected bartender button
            // IsOneBartender = True

            InitializeScreen();

        }

    }

    private void Tables_Click(object sender, EventArgs e) // Handles pnlAvailTabs.Click
    {
        StopTablesTimer();
        // time1 = Now
        // Dim prt As New PrintHelper
        // prt.PrintBarCodeStart()

        var objButton = new DataSet_Builder.AvailTableUserControl(); // AvailTableButton

        if (!object.ReferenceEquals(sender.GetType(), objButton.GetType))
            return;

        DataRow oRow;
        bool isCurrentlyHeld;
        int tableNumber;
        long experienceNumber;

        objButton = (DataSet_Builder.AvailTableUserControl)sender; // AvailTableButton)
        tableNumber = (int)objButton.TableNumber;
        experienceNumber = objButton.ExperienceNumber;

        // this instantiates currentTable
        isCurrentlyHeld = PopulateThisExperience(experienceNumber, false);

        if (typeProgram == "Online_Demo")
        {
            string filterString = "ExperienceNumber = " + experienceNumber;
            string NotfilterString = " NOT ExperienceNumber = " + experienceNumber;
            Demo_FilterDontDelete(dsOrder.Tables("AvailTables"), dsOrder.Tables("CurrentlyHeld"), filterString); // , NotfilterString) '"ExperienceNumber = '" & experienceNumber & "'")
            dsOrder.Tables("CurrentlyHeld").Rows(0)("CurrentlyHeld") = false;
            dsOrder.Tables("AvailTables").Clear();
        }
        else if (dsOrder.Tables("CurrentlyHeld").Rows.Count == 0)
        {
            // this means either table is gone or local database down
            return;
        }

        currentTable = new DinnerTable();

        if (isCurrentlyHeld == false)
        {

            if (currentTable is null)
            {
                Interaction.MsgBox("Table Does Not Exist");
                return;
            }
            currentTable.SatTime = objButton.SatTime;
            oRow = dsOrder.Tables("CurrentlyHeld").Rows(0);

            PopulateCurrentTableData(oRow);
            StartOrderProcess(currentTable.ExperienceNumber);

            // tests the status (c1 is transfer) then give it sat status
            if (objButton.CurrentStatus == "Transfering")
            {
                TransferTableToOpenOrder(currentServer.EmployeeID, experienceNumber, 2);
            }

            var argtabAccountInfo = default;
            FireOrderScreen?.Invoke(ref argtabAccountInfo);
        }

        else
        {
            Interaction.MsgBox("Table " + tableNumber + " is currently held by " + dsOrder.Tables("CurrentlyHeld").Rows(0)("CurrentlyHeld"));
            InitializeScreen();
            return;
        }

    }

    private void Tabs_Click(object sender, EventArgs e) // Handles pnlAvailTabs.Click
    {

        StopTablesTimer();

        var objButton = new DataSet_Builder.AvailTableUserControl(); // AvailTableButton

        if (!object.ReferenceEquals(sender.GetType(), objButton.GetType))
            return;

        DataRow oRow;
        bool isCurrentlyHeld;
        long tabID;
        string tabName;
        long experienceNumber;



        objButton = (DataSet_Builder.AvailTableUserControl)sender; // AvailTableButton)
        tabID = (long)objButton.TabID;
        tabName = (string)objButton.Text;
        experienceNumber = objButton.ExperienceNumber;

        // If tabID = -888 Then
        // '   -888 indicates TabGroup, true is for Dine IN
        // OpenNewTab(-888, currentServer.NickName & "'s Tabs", True)
        // Exit Sub
        // End If

        // 444
        if (currentTerminal.TermMethod == "Quick")
        {
            QuickTicketStart?.Invoke(experienceNumber); // tabID, tabName,
            return;
        }

        isCurrentlyHeld = PopulateThisExperience(experienceNumber, false);

        if (typeProgram == "Online_Demo")
        {
            string filterString = "ExperienceNumber = " + experienceNumber;
            string NotfilterString = " NOT ExperienceNumber = " + experienceNumber;
            if (tabID == -888)
            {
                // this is group tabs
                Demo_FilterDontDelete(dsOrder.Tables("QuickTickets"), dsOrder.Tables("CurrentlyHeld"), filterString); // , NotfilterString) '"ExperienceNumber = '" & experienceNumber & "'")
            }
            else
            {
                Demo_FilterDontDelete(dsOrder.Tables("AvailTabs"), dsOrder.Tables("CurrentlyHeld"), filterString);
            } // , NotfilterString) '"ExperienceNumber = '" & experienceNumber & "'")
            dsOrder.Tables("CurrentlyHeld").Rows(0)("CurrentlyHeld") = false;
            dsOrder.Tables("AvailTabs").Clear();
        }
        else if (dsOrder.Tables("CurrentlyHeld").Rows.Count == 0)
        {
            // this means either table is gone or local database down
            return;
        }

        currentTable = new DinnerTable();

        if (isCurrentlyHeld == false)
        {

            if (currentTable is null)
            {
                Interaction.MsgBox("Tab Does Not Exist");
                return;
            }

            oRow = dsOrder.Tables("CurrentlyHeld").Rows(0);
            // UpdateCurrentlyHeld(currentServer.FullName, experienceNumber)
            PopulateCurrentTableData(oRow);

            // currentTable.ExperienceNumber = experienceNumber
            // currentTable.IsTabNotTable = True
            // currentTable.TableNumber = 0
            // currentTable.TabID = tabID
            // '       currentTable.TabName = tabName
            // currentTable.TicketNumber = oRow("TicketNumber")
            // currentTable.EmployeeID = oRow("EmployeeID")
            // currentTable.CurrentMenu = oRow("MenuID")
            // '      currentTable.StartingMenu = oRow("MenuID")
            // currentTable.NumberOfChecks = oRow("NumberOfChecks")
            // currentTable.NumberOfCustomers = oRow("NumberOfCustomers")
            // currentTable.LastStatus = oRow("LastStatus")


            // this is for Tab Groups
            // we are choosing dataview that matches employee
            if (tabID == -888)
            {
                if (!(currentTable.EmployeeID == currentServer.EmployeeID))
                {
                    GenerateOrderTables.ReleaseCurrentlyHeld();
                    GenerateOrderTables.SaveOpenOrderData();
                    Interaction.MsgBox(currentServer.FullName + " does not have access");
                    return;
                }

                {
                    var withBlock = dvQuickTickets;
                    withBlock.Table = dsOrder.Tables("QuickTickets");
                    withBlock.RowFilter = "EmployeeID = " + currentTable.EmployeeID;
                    withBlock.Sort = "ExperienceDate ASC";
                    // .Sort = "LastStatus" ' DESC"
                }
                // was just testing below
                // does not work at all
                // OpenNewTab(-888, currentServer.NickName & "'s Tabs", True)
                // Exit Sub
            }

            // time1 = Now

            StartOrderProcess(currentTable.ExperienceNumber);
            // If orderScreenInitialized = False Then
            // StartOrderProcess(currentTable.ExperienceNumber)

            // StartOrderProcess(currentTable.ExperienceNumber)
            // orderScreenInitialized = True
            // End If

            // ActiveOrder = New term_OrderForm
            // Me.ActiveOrder.IsBartenderMode = Me.IsBartenderMode

            // tests the status (c1 is transfer) then give it sat status
            if (objButton.CurrentStatus == "Transfering")
            {
                TransferTableToOpenOrder(currentServer.EmployeeID, experienceNumber, 2);
            }


            // ActiveOrder.Location = New Point(0, 0)
            // Me.Controls.Add(ActiveOrder)
            // ActiveOrder.BringToFront()

            var argtabAccountInfo = default;
            FireOrderScreen?.Invoke(ref argtabAccountInfo);
        }

        // time2 = Now
        // timeDiff = time2.Subtract(time1)
        // MsgBox(timeDiff.ToString)

        // ActiveOrder = New term_OrderForm(IsBartenderMode)
        // ActiveOrder.Location = New Point(0, 0)
        // Me.Controls.Add(ActiveOrder)
        // ActiveOrder.BringToFront()
        // 'uc ActiveOrder.Show()
        // testBoolean = True
        // StartOrderProcess(currentTable.ExperienceNumber)



        else
        {
            Interaction.MsgBox("Tab " + tabName + " is currently held by " + dsOrder.Tables("CurrentlyHeld").Rows(0)("CurrentlyHeld"));
            InitializeScreen();
            return;

        }

        return;



        // Dim objButton As New DataSet_Builder.AvailTableUserControl 'AvailTableButton
        if (!object.ReferenceEquals(sender.GetType(), objButton.GetType))
            return;

        // Dim tabID As Integer
        // Dim tabName As String
        // Dim experienceNumber As Integer
        int numberOfChecks;
        int numberOfCustomers;
        int empID;
        int tktNum;
        int lStatus;

        objButton = (DataSet_Builder.AvailTableUserControl)sender; // AvailTableButton)

        // tabID = CType(objButton.TabID, Integer)
        // tabName = CType(objButton.Text, String)
        experienceNumber = (int)objButton.ExperienceNumber;
        numberOfChecks = (int)objButton.NumberOfChecks;
        currentTerminal.CurrentMenuID = (int)objButton.CurrentMenu;
        numberOfCustomers = (int)objButton.NumberOfCustomers;
        empID = (int)objButton.EmpID;
        tktNum = (int)objButton.TicketNumber;
        lStatus = (int)objButton.CurrentStatusID;

        // If IsBartenderMode = False Then
        // End If

        StopTablesTimer();

        // ActiveOrder = New term_OrderForm(currentMenuID, empID, True, tabID, tabName, experienceNumber, numberOfChecks, numberOfCustomers, IsBartenderMode, tktNum, lStatus)

        // tests the status (c1 is transfer) then give it sat status
        // ???????????
        if (objButton.CurrentStatus == "Transfering")
        {
            TransferTableToOpenOrder(currentServer.EmployeeID, experienceNumber, 2);
        }

        ActiveOrder.Show();
        // StopTablesTimer()


    }

    private void btnAddTable_Click(object sender, EventArgs e)
    {
        StopTablesTimer();
        // DisableTables_Screen()

        if (typeProgram == "Online_Demo")
        {
            dsOrder.Tables("AvailTables").Clear();
        }

        // SeatingChart._seatingUsernameEnterOnLogin = False
        FireSeatingChart?.Invoke(false);
        return;

        // SeatingChart = New Seating_ChooseTable   'Seating_Dining(currentServer.EmployeeID)
        // SeatingChart.Location = New Point(0, 0)
        // Me.Controls.Add(SeatingChart)
        // SeatingChart.BringToFront()


    }

    private void NoTableAdded222(object sender, EventArgs e) // Handles SeatingChart.NoTableSelected
    {

        // Try
        // SeatingChart.Dispose()
        // Catch ex As Exception
        // 
        // End Try

        EnableTables_Screen();
        InitializeScreen();

    }

    // ****************
    // ****************
    // ****************

    private void btnAddTab_Click(object sender, EventArgs e)
    {
        StopTablesTimer();
        if (typeProgram == "Online_Demo")
        {
            dsOrder.Tables("AvailTabs").Clear();
        }

        if (currentTerminal.TermMethod == "Quick")
        {
            long expnum;
            // 999test
            // right now just doing for first tab, because we dispose current table otherwise
            currentTable = new DinnerTable();
            currentTable.TabID = -999;
            expnum = GenerateOrderTables.CreatingNewTicket();
            QuickTicketStart?.Invoke(expnum);
        }

        else
        {
            FireSeatingTab?.Invoke("TableScreen", null);
        } // FireTabChart(False)

    }

    private void CustomerLoyalty222() // (ByRef tabAccountInfo As DataSet_Builder.Payment) Handles SeatingTab222.CustomerCardEvent
    {

        var tabAccountInfo = default(DataSet_Builder.Payment);
        string tabString;
        tabString = tabAccountInfo.LastName;
        if (tabAccountInfo.FirstName.Length > 0)
        {
            tabString = tabString + ", " + tabAccountInfo.FirstName;
        }


        // MsgBox(tabAccountInfo.LastName)
        // need to open new tab, but go right to Tab_Screen
        OpenNewTab222(-999, tabString, true, ref tabAccountInfo);
        AddPaymentToCollection(tabAccountInfo);
        SeatingTab222.Dispose();


        EnableTables_Screen();
        InitializeScreen();

    }
    private void NewAddNewTab222()
    {


        // -999 for tabID will tell it to generate New TabID (which will be experience Number)
        // later we will have a look-up for returning customers
        string newTabNameString;
        newTabNameString = SeatingTab222.NewTabName;

        var argtabAccountInfo = default;
        OpenNewTab222(-999, newTabNameString, true, ref argtabAccountInfo);
        SeatingTab222.Dispose();

        EnableTables_Screen();
        InitializeScreen();

    }
    private void NewAddNewTakeOutTab222()
    {

        this.Enabled = true;
        string newTabNameString;
        newTabNameString = SeatingTab222.NewTabName;

        // -999 for tabID will tell it to generate New TabID (which will be experience Number)
        // later we will have a look-up for returning customers
        var argtabAccountInfo = default;
        OpenNewTab222(-990, newTabNameString, false, ref argtabAccountInfo);
        SeatingTab222.Dispose();


        EnableTables_Screen();
        InitializeScreen();

    }
    private void CancelNewTab222()
    {


        SeatingTab222.Dispose();

        EnableTables_Screen();
        InitializeScreen();

    }
    private void OpenNewTab222(long tabId, string tabName, bool isDineIn, ref DataSet_Builder.Payment tabAccountInfo)
    {

    }

    private void OpenNewTab(long tabId, string tabName, bool isDineIn, ref DataSet_Builder.Payment tabAccountInfo)
    {
        // there is another OpenNewTab in Login ?????
        // Using this for Group Tab's (probably need to change)

        long expNum;
        int tktNum;
        bool isCurrentlyHeld;
        DateTime satTm;

        if (tabId == -888 | currentTerminal.TermMethod == "Quick")
        {
            tktNum = CreateNewTicketNumber();
            if (tabName == "New Tab")
            {
                tabName = "Tkt# " + tktNum.ToString();
            }
        }
        else
        {
            // 444      If tabName = "New Tab" Then
            // somehow this is making program change Method Use to TakeOut
            // tktNum = CreateNewTicketNumber()
            // tabName = "Tkt# " & tktNum.ToString
            // Else
            tktNum = 0;
            // End If
        }

        expNum = CreateNewExperience(currentServer.EmployeeID, default, tabId, tabName, 1, 2, tktNum, 0, currentServer.LoginTrackingID);
        isCurrentlyHeld = PopulateThisExperience(expNum, false);

        currentTable = new DinnerTable();
        currentTable.ExperienceNumber = expNum;
        currentTable.IsTabNotTable = true;
        currentTable.TabID = tabId;
        currentTable.TabName = tabName;
        currentTable.TableNumber = 0;
        currentTable.TicketNumber = tktNum;
        currentTable.EmployeeID = currentServer.EmployeeID;
        currentTable.CurrentMenu = currentTerminal.currentPrimaryMenuID; // 444primaryMenuID  'this is the system menu - can change during order process
        currentTable.StartingMenu = currentTerminal.currentPrimaryMenuID; // 444primaryMenuID
        currentTable.NumberOfCustomers = 1;      // is 1 when you first open
        currentTable.NumberOfChecks = 1;
        currentTable.LastStatus = 2;
        currentTable.SatTime = DateTime.Now;
        currentTable.ItemsOnHold = 0;
        if (dvTerminalsUseOrder.Count > 0)
        {
            currentTable.MethodUse = dvTerminalsUseOrder[0]("MethodUse");
            currentTable.MethodDirection = dvTerminalsUseOrder[0]("MethodDirection");
        }
        else
        {
            currentTable.MethodUse = "Dine In";
            currentTable.MethodDirection = "None";
        }


        StartOrderProcess(currentTable.ExperienceNumber);
        // sss   satTm = AddStatusChangeData(currentTable.ExperienceNumber, 2, Nothing, 0, Nothing)
        // SaveESCStatusChangeData(2, Nothing, 0, Nothing)


        FireOrderScreen?.Invoke(ref tabAccountInfo);

    }

    private void btnAddTabGroup_Click(object sender, EventArgs e)
    {

        try
        {
            {
                var withBlock = dvQuickTickets;
                withBlock.Table = dsOrder.Tables("QuickTickets");
                withBlock.RowFilter = "EmployeeID = " + currentServer.EmployeeID;
                withBlock.Sort = "ExperienceDate ASC";
                // .Sort = "ExperienceDate" ' DESC"
            }
            if (dvQuickTickets.Count > 0)
            {
                Interaction.MsgBox(currentServer.FullName + " already has a tab group open.");
                return;
            }

            StopTablesTimer();
            // -888 indicates TabGroup, true is for Dine IN
            var argtabAccountInfo = default;
            OpenNewTab(-888, currentServer.NickName + "'s Tabs", true, ref argtabAccountInfo);
        }
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);
        }

    }

    private void btnBartenderLogin_Click(object sender, EventArgs e)
    {
        StopTablesTimer();
        DisableTables_Screen();

        clockInPanel = new ClockInUserControl();
        clockInPanel.Location = new Point((ssX - clockInPanel.Width) / 2, (ssY - clockInPanel.Height) / 2);
        this.Controls.Add(clockInPanel);
        clockInPanel.BringToFront();

    }

    private void ClockInEmployeeClicked() // , clockInPanel.ClosingClockIn
    {

        Interaction.MsgBox(currentClockEmp.FullName + " has just clocked in at: " + DateTime.Now.ToString());
        ClockInEnding();

    }

    private void ClockInEnding()
    {

        if (currentTerminal.TermMethod == "Bar")
        {
            GenerateOrderTables.PopulateBartenderCollection();
            if (currentBartenders.Count > 1)
            {
                currentTerminal.IsOneBartender = false;
            }
        }

        EnableTables_Screen();
        InitializeScreen();

    }

    private void btnTablesExit_Click_1(object sender, EventArgs e) // , ClockingOutEmployee.ClockOutComplete
    {

        // 444     currentServer = New Employee
        // updateClockTimer.Dispose()
        // tablesInactiveTimer.Dispose()
        ExitingTableScreen?.Invoke();

    }

    private void btnTablesExit_Click_1()
    {

        // 444    currentServer = New Employee
        ExitingTableScreen?.Invoke();
        // currently we are exiting, we should stay here if Bar or Quick
        // but with the memory leak I figured this is good for now
        // If IsBartenderMode = False And Not currentTerminal.TermMethod = "Quick" Then
        // Else
        // ???? not sure of below, debug
        // GenerateOrderTables.PopulateBartenderCollection()
        // InitializeScreen()
        // End If

    }

    private void btnManager_Click(object sender, EventArgs e)
    {
        StopTablesTimer();
        ManagementButton?.Invoke(ref currentServer);

    }

    private void Button1_Click(object sender, EventArgs e)
    {
        GC.Collect();
        return;

        int avgTime;

        dsOrder.Tables("OrderByPrinter").Clear();

        sql.cn.Open();
        sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
        sql.SqlDataAdapterByPrinter2.Fill(dsOrder.Tables("OrderByPrinter"));
        sql.cn.Close();


        foreach (DataRow oRow in dsOrder.Tables("OrderByPrinter").Rows)
        {

            Interaction.MsgBox(oRow("RoutingID"), Title: "Routing");
            Interaction.MsgBox(oRow("Count"), Title: "Count");
            Interaction.MsgBox(oRow("Schedule"), Title: "Schedule");
            // MsgBox(oRow("Actual"), , "Actual")
            avgTime = Conversions.ToInteger(Strings.Format(oRow("Actual") / oRow("Count"), "####"));
            Interaction.MsgBox(avgTime, Title: "Avg");

        }


    }

    private void btnClockOut_Click(object sender, EventArgs e)
    {
        bool yesOpenTables;

        if (IsBartenderMode == false & !(currentTerminal.TermMethod == "Quick"))
        {
            StopTablesTimer();

            // check to see if there are any open tables           **********************
            if (currentClockEmp is null)
            {
                currentClockEmp = new Employee();
            }
            currentClockEmp = currentServer;
            yesOpenTables = GenerateOrderTables.AnyOpenTables(currentClockEmp);
            StartClockOut(currentClockEmp, yesOpenTables);
        }

        else
        {
            StopTablesTimer();
            DisableTables_Screen();
            isNoSaleOrClockOut = "clockout";

            nosaleLoginPad = new NumberPad();
            nosaleLoginPad.Location = new Point((this.Width - nosaleLoginPad.Width) / 2, (this.Height - nosaleLoginPad.Height) / 2 + 40);
            this.Controls.Add(nosaleLoginPad);
            nosaleLoginPad.BringToFront();
        }


        return;
        // 222 444


        // 444   Dim yesOpenTables As Boolean

        // check to see if there are any open tables           **********************
        yesOpenTables = AnyOpenTables(currentServer);

        if (yesOpenTables == true)
        {
            openInfo = new DataSet_Builder.Information_UC(currentServer.FullName + " still has open checks. Press here to clock out or enter Tip Adjustments.");
            openInfo.Location = new Point((this.Width - openInfo.Width) / 2, (this.Height - openInfo.Height) / 2);
            this.Controls.Add(openInfo);
            openInfo.BringToFront();
        }
        // Exit Sub
        else
        {
            StartClockOut(currentServer, false);
        }

    }

    private void OkToLeaveOpenTables(object sender, EventArgs e)
    {

        // we can use currentSever here because we changed when there were open tables
        StartClockOut(currentServer, false);

    }
    private void StartClockOut(Employee emp, bool hasOpenTables) // 
    {
        foreach (Employee salaried in SalariedEmployees)
        {
            if (salaried.EmployeeID == currentClockEmp.EmployeeID)
            {
                // this is a salaried employee
                Interaction.MsgBox(currentServer.NickName + " is Salaried. No need to Clock Out.");
                return;
            }
        }

        if (currentClockEmp.ClockInReq == true) // currentServer.ClockInReq = True Then
        {

            ClockingOutEmployee = new ClockOut_UC(currentClockEmp, hasOpenTables); // currentServer, hasOpenTables)     '      , tipableSales, chargedSales, chargedTips)
            ClockingOutEmployee.Location = new Point(0, 0); // ((Me.Width - Me.ClockingOutEmployee.Width) / 2, (Me.Height - Me.ClockingOutEmployee.Height) / 2)
            if (currentClockEmp.Server == false & currentClockEmp.Bartender == false & currentClockEmp.Cashier == false & currentClockEmp.Manager == false)
            {
                ClockingOutEmployee.EitherPrintOrClockOut(true);
                ClockingOutEmployee.Dispose();
            }
            else
            {
                this.Controls.Add(ClockingOutEmployee);
                ClockingOutEmployee.BringToFront();
                // 444       DisableTables_Screen()
            }
        }

        else
        {
            Interaction.MsgBox(currentClockEmp.FullName + " does not use time clock.");
        }

    }

    private void CLockOutCanceled()
    {

        try
        {
            ClockingOutEmployee.Dispose();
        }
        catch (Exception ex)
        {

        }
        EnableTables_Screen();
        InitializeScreen();

    }


    private object BuildSQLWHEREClauseFromOpenOrders222(string strClockOut, long expNum, bool firstTime)
    {
        string strWhereClause = strClockOut;

        if (firstTime == true)
        {
            strWhereClause = strWhereClause + " OpenOrders.ExperienceNumber = '" + expNum + "'";
        }
        else
        {
            strWhereClause = strWhereClause + " OR OpenOrders.ExperienceNumber = '" + expNum + "'";
        }

        return strWhereClause;

    }

    private object BuildSQLWHEREClauseFromPaymentsAndCredits222(string strClockOut, long expNum, bool firstTime)
    {
        string strWhereClause = strClockOut;

        if (firstTime == true)
        {
            strWhereClause = strWhereClause + " PaymentsAndCredits.ExperienceNumber = '" + expNum + "'";
        }
        else
        {
            strWhereClause = strWhereClause + " OR PaymentsAndCredits.ExperienceNumber = '" + expNum + "'";
        }

        return strWhereClause;

    }

    private object AnyOpenTables222(Employee emp)
    {

        GenerateOrderTables.PopulateTabsAndTables(emp, currentTerminal.CurrentDailyCode, false, false, default);
        CreateDataViews(emp.EmployeeID, true);
        if (dvAvailTables.Count + dvTransferTables.Count + dvAvailTabs.Count + dvTransferTabs.Count + dvQuickTickets.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }


        // 222 444
        return default;
        DataRowView oRow;

        foreach (DataRowView currentORow in dvAvailTables)
        {
            oRow = currentORow;  // dsOrder.Tables("AvailTables").Rows
            if (oRow("EmployeeID") == currentServer.EmployeeID)
            {
                return true;
            }
        }

        foreach (DataRowView currentORow1 in dvAvailTabs)
        {
            oRow = currentORow1;    // dsOrder.Tables("AvailTabs").Rows
            if (oRow("EmployeeID") == currentServer.EmployeeID)
            {
                return true;
            }
        }

        return false;

    }

    private void CreateClosingDataViews222()
    {

        dvClosedTables = new DataView();
        dvClosedTabs = new DataView();

        if (dsOrder.Tables("ClosedTables").Rows.Count > 0)
        {
            {
                var withBlock = dvClosedTables;
                withBlock.Table = dsOrder.Tables("AvailTables");
                withBlock.RowFilter = "LastStatus = 1"; // "EmployeeID = " & currentServer.EmployeeID
            }
        }

        if (dsOrder.Tables("ClosedTabs").Rows.Count > 0)
        {
            {
                var withBlock1 = dvClosedTabs;
                withBlock1.Table = dsOrder.Tables("AvailTabs");
                withBlock1.RowFilter = "LastStatus = 1";  // "EmployeeID = " & currentServer.EmployeeID
            }
        }

    }

    private void CloseCheckFailed()
    {
        DataSet_Builder.Information_UC info;
        info = new DataSet_Builder.Information_UC("You can not close out. One possible reason may be the Server Connection is down.");
        info.Location = new Point((this.Width - info.Width) / 2, (this.Height - info.Height) / 2);
        this.Controls.Add(info);
        info.BringToFront();

    }

    private void SetTableScreenTime()
    {
        lblTableTime.Text = Strings.Format(DateTime.Now, "h:mm tt");

    }

    private void UpdateTableScreenTime(object sender, EventArgs e)
    {
        // InitializeScreen()
        if (currentTerminal.CurrentDailyCode == 0)
        {
            ExitingTableScreen?.Invoke();
        }

        if (connectionDown == true)
        {
            // this is just so we don't loop
            connectionDown = false;
            ExitingTableScreen?.Invoke();
        }

        if (!(currentTerminal.TermMethod == "Quick"))
        {
            if (currentTerminal.TermMethod == "Bar")
            {
                GenerateOrderTables.PopulateBartenderCollection();
            }
            GenerateOrderTables.PopulateTabsAndTables(currentServer, currentTerminal.CurrentDailyCode, IsBartenderMode, currentTerminal.IsOneBartender, currentBartenders);
            CreateDataViews(currentServer.EmployeeID, true);
            DisplayTabsAndTables(quickEndCount);
        }

        SetTableScreenTime();

    }



    private void btnNoSale_Click(object sender, EventArgs e)
    {
        StopTablesTimer();
        isNoSaleOrClockOut = "nosale";

        // currentTerminal.HasCashDrawer = True
        if (currentTerminal.HasCashDrawer == true)
        {
            DisableTables_Screen();

            // make bartender or cashier enter their password if in bartender mode
            // If Me.IsBartenderMode Then
            nosaleLoginPad = new NumberPad();
            nosaleLoginPad.Location = new Point((this.Width - nosaleLoginPad.Width) / 2, (this.Height - nosaleLoginPad.Height) / 2 + 40);
            // lblLogin.Text = "Enter Login"
            this.Controls.Add(nosaleLoginPad);
            nosaleLoginPad.BringToFront();
        }

        // End If
        // then open drawer
        // then show NO SALE usercontrol


    }

    private void NoSalePassword(object sender, EventArgs e)
    {
        // this is the accepted NoSale

        string loginEnter;
        DataSet_Builder.Employee emp;
        bool yesOpenTables;

        EnableTables_Screen();
        loginEnter = nosaleLoginPad.NumberString;
        emp = GenerateOrderTables.TestUsernamePassword(loginEnter, true);

        if (isNoSaleOrClockOut == "nosale")
        {
            if (emp is not null)
            {
                if (emp.OperationMgmtLimited == true | emp.OperationMgmtAll == true)
                {
                    var prt = new PrintHelper();
                    prt.PrintOpenCashDrawer();
                    // need to send to database to record Cash Drawer opening

                    var newPayment = default(DataSet_Builder.Payment);

                    newPayment.Purchase = 0;
                    newPayment.PaymentTypeID = -2;
                    newPayment.PaymentTypeName = "Cash";   // "Enter Acct #"
                    newPayment.Description = "no-sale";

                    GenerateOrderTables.AddPaymentToDataRow(newPayment, true, 0, emp.EmployeeID, 1, false);
                    // we need this update here b/c we are not in any experience
                    GenerateOrderTables.UpdatePaymentsAndCredits();

                    ccDisplay = new CashClose_UC(0, 0, 0, 0);
                    ccDisplay.Location = new Point((this.Width - ccDisplay.Width) / 2, (this.Height - ccDisplay.Height) / 2);
                    this.Controls.Add(ccDisplay);
                    ccDisplay.BringToFront();
                    ccDisplay.BeginNoSale();
                }
            }
        }

        else if (isNoSaleOrClockOut == "clockout")
        {

            if (emp is not null)
            {
                // check to see if there are any open tables           **********************
                if (loginEnter.Length < 8)
                {
                    Interaction.MsgBox("Enter both EmployeeID as Passcode");
                    return;
                }
                bool doesEmpNeedToClockOut;
                doesEmpNeedToClockOut = TestClockOut(loginEnter);
                if (doesEmpNeedToClockOut == false)
                {
                    // MakeClockOutBooleanFalse()
                    nosaleLoginPad.btnNumberClear_Click();
                    Interaction.MsgBox("Employee does not need to Clock Out");
                    nosaleLoginPad.Dispose();
                    return;
                }
                if (currentClockEmp is null)
                {
                    currentClockEmp = new Employee();
                }
                currentClockEmp = emp;
                yesOpenTables = GenerateOrderTables.AnyOpenTables(emp);

                if (yesOpenTables == true)
                {
                    openInfo = new DataSet_Builder.Information_UC(emp.FullName + " still has open checks. Press here to clock out or enter Tip Adjustments.");
                    openInfo.Location = new Point((this.Width - openInfo.Width) / 2, (this.Height - openInfo.Height) / 2);
                    this.Controls.Add(openInfo);
                    openInfo.BringToFront();
                }
                // Exit Sub
                else
                {
                    StartClockOut(currentClockEmp, false);
                }
            }
        }

        nosaleLoginPad.Dispose();

    }
    private void NoSalePasswordBlank()
    {
        // this just removes the nosale panel

        EnableTables_Screen();
        nosaleLoginPad.Dispose();

    }


    internal void DisableTables_Screen()
    {

        pnlBartenderButtons.Enabled = false;
        pnlAvailTabs.Enabled = false;
        pnlTableCommands.Enabled = false;
        btnAddTab.Enabled = false;
        btnAddTabGroup.Enabled = false;
        btnAddTable.Enabled = false;
        // Me.btnNoSale.Enabled = False



    }

    internal void EnableTables_Screen()
    {

        pnlBartenderButtons.Enabled = true;
        pnlAvailTabs.Enabled = true;
        pnlTableCommands.Enabled = true;
        btnAddTab.Enabled = true;
        btnAddTabGroup.Enabled = true;
        btnAddTable.Enabled = true;
        // Me.btnNoSale.Enabled = True


    }


    private void lblTableTime_Click(object sender, EventArgs e)
    {

        if (currentTerminal.TermMethod == "Quick")
        {

            if (dsOrder.Tables("QuickTickets").Rows.Count > 0)
            {
                pnlAvailTabs.Controls.Clear();

                foreach (DataView dv in currentQuickTicketDataViews)
                {
                    // this is the last row in each of the DataView Collections
                    // the dataviews are grouped by bartender


                    if (quickEndCount < 12)
                    {
                        quickEndCount = dv.Count - 1;
                    }
                    else
                    {
                        quickEndCount -= 12;
                    }

                    DisplayTIcketsForQuick(ref dv, quickEndCount);
                    break;
                }
            }
        }
        else
        {
            // not for quick

            if (quickEndCount == 0)
            {
                quickEndCount = 40;
            }
            // quickEndCount = (dvAvailTables.Count + dvAvailTabs.Count + dvTransferTables.Count + dvTransferTabs.Count)

            else if (quickEndCount > 39)
            {
                quickEndCount += 8;

            }

            if (quickEndCount > 16 + dvAvailTables.Count + dvAvailTabs.Count + dvTransferTables.Count + dvTransferTabs.Count)
            {
                quickEndCount = 0;
            }
            DisplayTabsAndTables(quickEndCount);

        }


    }


}