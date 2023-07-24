using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using DataSet_Builder;


public partial class Manager_Main_UC : System.Windows.Forms.UserControl
{

    // Dim sql As New DataSet_Builder.SQLHelper(connectserver)

    private Button _btnClosedTable;

    private Button btnClosedTable
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnClosedTable;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _btnClosedTable = value;
        }
    }
    private KitchenButton _floorPersonnel;

    private KitchenButton floorPersonnel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _floorPersonnel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_floorPersonnel != null)
            {
                _floorPersonnel.Click -= FloorPerson_Click;
            }

            _floorPersonnel = value;
            if (_floorPersonnel != null)
            {
                _floorPersonnel.Click += FloorPerson_Click;
            }
        }
    }
    private KitchenButton allPersonnel;
    private long closingDailyCode;
    private long expNum;

    private bool primaryMenuSelected;
    private bool justChangingMenu;

    private Button _mgrClockAdjustment;

    private Button mgrClockAdjustment
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mgrClockAdjustment;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mgrClockAdjustment != null)
            {
                _mgrClockAdjustment.Click -= ClockAdjustment_Click;
            }

            _mgrClockAdjustment = value;
            if (_mgrClockAdjustment != null)
            {
                _mgrClockAdjustment.Click += ClockAdjustment_Click;
            }
        }
    }
    private Button _mgrTipAdjustment;

    private Button mgrTipAdjustment
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mgrTipAdjustment;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mgrTipAdjustment != null)
            {
                _mgrTipAdjustment.Click -= TipAdjustment_Click;
            }

            _mgrTipAdjustment = value;
            if (_mgrTipAdjustment != null)
            {
                _mgrTipAdjustment.Click += TipAdjustment_Click;
            }
        }
    }
    private Button _mgrPayRateAdjustment;

    private Button mgrPayRateAdjustment       // not sure if using
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mgrPayRateAdjustment;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mgrPayRateAdjustment != null)
            {
                _mgrPayRateAdjustment.Click -= PayRateAdjustment_Click;
            }

            _mgrPayRateAdjustment = value;
            if (_mgrPayRateAdjustment != null)
            {
                _mgrPayRateAdjustment.Click += PayRateAdjustment_Click;
            }
        }
    }
    private NumberPad _mgrLargeNumberPad;

    internal virtual NumberPad mgrLargeNumberPad
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mgrLargeNumberPad;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mgrLargeNumberPad != null)
            {
                _mgrLargeNumberPad.NumberEntered -= MgrPasscodeEnter;
                _mgrLargeNumberPad.AcceptManager -= ActingManagerIsAccepted;
            }

            _mgrLargeNumberPad = value;
            if (_mgrLargeNumberPad != null)
            {
                _mgrLargeNumberPad.NumberEntered += MgrPasscodeEnter;
                _mgrLargeNumberPad.AcceptManager += ActingManagerIsAccepted;
            }
        }
    }
    private int countNumberOfAttemptsToLeave;
    private int mainPanelCounterIndex = 0;
    private string displayingOpenOrClose;

    // Dim WithEvents employeeLog As EmployeeLoggedInUserControl
    private DataSet_Builder.SelectionPanel_UC _selectDaily;

    private DataSet_Builder.SelectionPanel_UC selectDaily
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _selectDaily;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_selectDaily != null)
            {
                _selectDaily.ButtonSelected -= CloseDailyBusinessSelected;
            }

            _selectDaily = value;
            if (_selectDaily != null)
            {
                _selectDaily.ButtonSelected += CloseDailyBusinessSelected;
            }
        }
    }
    private DataSet_Builder.MenuSelection_UC _openDaily;

    private DataSet_Builder.MenuSelection_UC openDaily
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _openDaily;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_openDaily != null)
            {
                _openDaily.ChangeMenus -= OpenNewDaily;
                _openDaily.AcceptMenuEvent -= OpenNewDailyAndSave;
            }

            _openDaily = value;
            if (_openDaily != null)
            {
                _openDaily.ChangeMenus += OpenNewDaily;
                _openDaily.AcceptMenuEvent += OpenNewDailyAndSave;
            }
        }
    }
    private DataSet_Builder.MenuSelection_UC _changeMenu;

    private DataSet_Builder.MenuSelection_UC changeMenu
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _changeMenu;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_changeMenu != null)
            {
                _changeMenu.ChangeMenus -= ChangeMenu_Click;
                _changeMenu.AcceptMenuEvent -= ChangeMenuAndSave_Click;
            }

            _changeMenu = value;
            if (_changeMenu != null)
            {
                _changeMenu.ChangeMenus += ChangeMenu_Click;
                _changeMenu.AcceptMenuEvent += ChangeMenuAndSave_Click;
            }
        }
    }
    private DataSet_Builder.InvDelivery_UC _invDelivery;

    private DataSet_Builder.InvDelivery_UC invDelivery
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _invDelivery;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _invDelivery = value;
        }
    }
    private DataSet_Builder.InvPhysical_UC _invPhysical;

    private DataSet_Builder.InvPhysical_UC invPhysical
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _invPhysical;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _invPhysical = value;
        }
    }
    private DataSet_Builder.Manager_Reports_UC _reportManager;

    private DataSet_Builder.Manager_Reports_UC reportManager
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _reportManager;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _reportManager = value;
        }
    }
    private Training_UC _trainingDailys;

    private Training_UC trainingDailys
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _trainingDailys;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _trainingDailys = value;
        }
    }
    private Global.System.Windows.Forms.GroupBox _grpEmployeeClockIn;

    internal virtual Global.System.Windows.Forms.GroupBox grpEmployeeClockIn
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _grpEmployeeClockIn;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _grpEmployeeClockIn = value;
        }
    }
    private Global.System.Windows.Forms.DataGrid _grdEmpClockIn;

    internal virtual Global.System.Windows.Forms.DataGrid grdEmpClockIn
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _grdEmpClockIn;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _grdEmpClockIn = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblNumClockedIn;

    internal virtual Global.System.Windows.Forms.Label lblNumClockedIn
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNumClockedIn;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblNumClockedIn = value;
        }
    }
    private Global.System.Windows.Forms.DataGridTableStyle _DataGridTableStyle1;

    internal virtual Global.System.Windows.Forms.DataGridTableStyle DataGridTableStyle1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _DataGridTableStyle1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _DataGridTableStyle1 = value;
        }
    }
    private Global.System.Windows.Forms.DataGridTextBoxColumn _DataGridTextBoxColumn1;

    internal virtual Global.System.Windows.Forms.DataGridTextBoxColumn DataGridTextBoxColumn1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _DataGridTextBoxColumn1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _DataGridTextBoxColumn1 = value;
        }
    }
    private Global.System.Windows.Forms.DataGridTextBoxColumn _DataGridTextBoxColumn2;

    internal virtual Global.System.Windows.Forms.DataGridTextBoxColumn DataGridTextBoxColumn2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _DataGridTextBoxColumn2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _DataGridTextBoxColumn2 = value;
        }
    }
    private Global.System.Windows.Forms.DataGridTextBoxColumn _DataGridTextBoxColumn3;

    internal virtual Global.System.Windows.Forms.DataGridTextBoxColumn DataGridTextBoxColumn3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _DataGridTextBoxColumn3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _DataGridTextBoxColumn3 = value;
        }
    }

    // Dim info As DataSet_Builder.Info2_UC
    // Dim WithEvents closeBatch As BatchClose_UC
    private ReturnCredit_UC _returnCredit;

    private ReturnCredit_UC returnCredit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _returnCredit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _returnCredit = value;
        }
    }
    private CashOut_UC _cashOut;

    private CashOut_UC cashOut
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cashOut;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cashOut != null)
            {
                _cashOut.AcceptCashOut -= AcceptingCashOut;
            }

            _cashOut = value;
            if (_cashOut != null)
            {
                _cashOut.AcceptCashOut += AcceptingCashOut;
            }
        }
    }
    private CashDrawer_UC _cashDrawer;

    private CashDrawer_UC cashDrawer
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cashDrawer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cashDrawer != null)
            {
                _cashDrawer.ResetClosingData -= CloseSelectedDaily;
                _cashDrawer.TerminalsNowOpen -= ReinitializeOpenCashDrawers;
            }

            _cashDrawer = value;
            if (_cashDrawer != null)
            {
                _cashDrawer.ResetClosingData += CloseSelectedDaily;
                _cashDrawer.TerminalsNowOpen += ReinitializeOpenCashDrawers;
            }
        }
    }
    private EmployeeLoggedInUserControl _employeeLog;

    private EmployeeLoggedInUserControl employeeLog
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _employeeLog;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_employeeLog != null)
            {
                _employeeLog.ClosedEmployeeLog -= EndAdjustEmployeeClock;
            }

            _employeeLog = value;
            if (_employeeLog != null)
            {
                _employeeLog.ClosedEmployeeLog += EndAdjustEmployeeClock;
            }
        }
    }

    private bool allPaymentsLoaded;
    private int allTicketsOpen;
    private int allCashDrawersOpen;
    private int allEmployeesClockedIn;
    // Dim weAreClosingDaily As Boolean
    private int numberOfAttemtsClosingDaily;
    private int skipClosedIndex = 0;

    internal bool availTableChangesMade;
    private bool usernameEnterOnLogin;

    private EmployeeCollection activeCollection = new EmployeeCollection();

    private bool OperationFlag;
    private bool EmployeeFlag;
    private bool ReportsFlag;
    private bool MenuFlag;
    private bool SystemFlag;
    private bool DailysFlag;
    private bool InventoryFlag;
    private string InventoryTable;

    private int _tableSelected;
    private bool _reopenFlag;
    private Global.System.Windows.Forms.Panel _pnlMoreTickets;

    internal virtual Global.System.Windows.Forms.Panel pnlMoreTickets
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlMoreTickets;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlMoreTickets = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnLessTickets;

    internal virtual Global.System.Windows.Forms.Button btnLessTickets
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnLessTickets;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnLessTickets != null)
            {
                _btnLessTickets.Click -= btnLessTickets_Click;
            }

            _btnLessTickets = value;
            if (_btnLessTickets != null)
            {
                _btnLessTickets.Click += btnLessTickets_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnMoreTickets;

    internal virtual Global.System.Windows.Forms.Button btnMoreTickets
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMoreTickets;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMoreTickets != null)
            {
                _btnMoreTickets.Click -= btnMoreTickets_Click;
            }

            _btnMoreTickets = value;
            if (_btnMoreTickets != null)
            {
                _btnMoreTickets.Click += btnMoreTickets_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblVersion;

    internal virtual Global.System.Windows.Forms.Label lblVersion
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblVersion;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblVersion = value;
        }
    }
    private Global.System.Windows.Forms.Button _subButton5;

    internal virtual Global.System.Windows.Forms.Button subButton5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _subButton5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_subButton5 != null)
            {
                _subButton5.Click -= subButton5_Click;
            }

            _subButton5 = value;
            if (_subButton5 != null)
            {
                _subButton5.Click += subButton5_Click;
            }
        }
    }
    private long _reopenIndex;


    internal bool ReopenFlag
    {
        get
        {
            return _reopenFlag;
        }
        set
        {
            _reopenFlag = value;
        }
    }

    internal long ReopenIndex
    {
        get
        {
            return _reopenIndex;
        }
        set
        {
            _reopenIndex = value;
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

    public event OpenOrderAdjustmentEventHandler OpenOrderAdjustment;

    public delegate void OpenOrderAdjustmentEventHandler(object sender, EventArgs e, long closingDailyCode);
    public event CloseBatchManagerFormEventHandler CloseBatchManagerForm;

    public delegate void CloseBatchManagerFormEventHandler(long cb);
    public event OpenReportsEventHandler OpenReports;

    public delegate void OpenReportsEventHandler();
    public event OpenNewTableEventHandler OpenNewTable;

    public delegate void OpenNewTableEventHandler();
    public event OpenNewTabEventEventHandler OpenNewTabEvent;

    public delegate void OpenNewTabEventEventHandler();
    public event StartExitEventHandler StartExit;

    public delegate void StartExitEventHandler();
    public event AdjustEmpClockEventHandler AdjustEmpClock;

    public delegate void AdjustEmpClockEventHandler();
    public event OverrideTableStatusEventHandler OverrideTableStatus;

    public delegate void OverrideTableStatusEventHandler();
    public event ReReadCreditEventHandler ReReadCredit;

    public delegate void ReReadCreditEventHandler();
    public event DisposeManagerEventHandler DisposeManager;

    public delegate void DisposeManagerEventHandler();


    #region  Windows Form Designer generated code 

    public Manager_Main_UC(bool userEntered) : base()
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        usernameEnterOnLogin = userEntered;
        InitializeOther();

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
    private Global.System.Windows.Forms.Panel _pnlMgrMainCategories;

    internal virtual Global.System.Windows.Forms.Panel pnlMgrMainCategories
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlMgrMainCategories;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlMgrMainCategories = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnOperations;

    internal virtual Global.System.Windows.Forms.Button btnOperations
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnOperations;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnOperations != null)
            {
                _btnOperations.Click -= btnOperations_Click;
            }

            _btnOperations = value;
            if (_btnOperations != null)
            {
                _btnOperations.Click += btnOperations_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnEmployees;

    internal virtual Global.System.Windows.Forms.Button btnEmployees
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnEmployees;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnEmployees != null)
            {
                _btnEmployees.Click -= btnEmployees_Click;
            }

            _btnEmployees = value;
            if (_btnEmployees != null)
            {
                _btnEmployees.Click += btnEmployees_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnReports;

    internal virtual Global.System.Windows.Forms.Button btnReports
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnReports;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnReports != null)
            {
                _btnReports.Click -= btnReports_Click;
            }

            _btnReports = value;
            if (_btnReports != null)
            {
                _btnReports.Click += btnReports_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _pnlMainManager;

    internal virtual Global.System.Windows.Forms.Panel pnlMainManager
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlMainManager;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pnlMainManager != null)
            {
                _pnlMainManager.Click -= OpenTabsAndTables_Selected;
                _pnlMainManager.Click -= ClosedTabsAndTables_Selected;
            }

            _pnlMainManager = value;
            if (_pnlMainManager != null)
            {
                _pnlMainManager.Click += OpenTabsAndTables_Selected;
                _pnlMainManager.Click += ClosedTabsAndTables_Selected;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblMgrDirectionsNumberPad;

    internal virtual Global.System.Windows.Forms.Label lblMgrDirectionsNumberPad
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblMgrDirectionsNumberPad;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblMgrDirectionsNumberPad = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblMgrDirectionsNumberPad2;

    internal virtual Global.System.Windows.Forms.Label lblMgrDirectionsNumberPad2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblMgrDirectionsNumberPad2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblMgrDirectionsNumberPad2 = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblMgrDirectionsNumberPad3;

    internal virtual Global.System.Windows.Forms.Label lblMgrDirectionsNumberPad3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblMgrDirectionsNumberPad3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblMgrDirectionsNumberPad3 = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlManagerSelection;

    internal virtual Global.System.Windows.Forms.Panel pnlManagerSelection
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlManagerSelection;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlManagerSelection = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblActiingManager;

    internal virtual Global.System.Windows.Forms.Label lblActiingManager
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblActiingManager;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblActiingManager = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnMgrExit;

    internal virtual Global.System.Windows.Forms.Button btnMgrExit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMgrExit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMgrExit != null)
            {
                _btnMgrExit.Click -= btnMgrExit_Click;
            }

            _btnMgrExit = value;
            if (_btnMgrExit != null)
            {
                _btnMgrExit.Click += btnMgrExit_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _pnlManagerSubSelecetion;

    internal virtual Global.System.Windows.Forms.Panel pnlManagerSubSelecetion
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlManagerSubSelecetion;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlManagerSubSelecetion = value;
        }
    }
    private Global.System.Windows.Forms.Button _SubButtonBack;

    internal virtual Global.System.Windows.Forms.Button SubButtonBack
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SubButtonBack;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SubButtonBack != null)
            {
                _SubButtonBack.Click -= SubButtonBack_Click;
            }

            _SubButtonBack = value;
            if (_SubButtonBack != null)
            {
                _SubButtonBack.Click += SubButtonBack_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _SubButton1;

    internal virtual Global.System.Windows.Forms.Button SubButton1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SubButton1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SubButton1 != null)
            {
                _SubButton1.Click -= SubButton1_Click;
            }

            _SubButton1 = value;
            if (_SubButton1 != null)
            {
                _SubButton1.Click += SubButton1_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _SubButton2;

    internal virtual Global.System.Windows.Forms.Button SubButton2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SubButton2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SubButton2 != null)
            {
                _SubButton2.Click -= SubButton2_Click;
            }

            _SubButton2 = value;
            if (_SubButton2 != null)
            {
                _SubButton2.Click += SubButton2_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _SubButton3;

    internal virtual Global.System.Windows.Forms.Button SubButton3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SubButton3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SubButton3 != null)
            {
                _SubButton3.Click -= SubButton3_Click;
            }

            _SubButton3 = value;
            if (_SubButton3 != null)
            {
                _SubButton3.Click += SubButton3_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _SubButton4;

    internal virtual Global.System.Windows.Forms.Button SubButton4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SubButton4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SubButton4 != null)
            {
                _SubButton4.Click -= SubButton4_Click;
            }

            _SubButton4 = value;
            if (_SubButton4 != null)
            {
                _SubButton4.Click += SubButton4_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _Label1;

    internal virtual Global.System.Windows.Forms.Label Label1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label1 = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnDailys;

    internal virtual Global.System.Windows.Forms.Button btnDailys
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDailys;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnDailys != null)
            {
                _btnDailys.Click -= btnDailys_Click;
            }

            _btnDailys = value;
            if (_btnDailys != null)
            {
                _btnDailys.Click += btnDailys_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblCurrentServer;

    internal virtual Global.System.Windows.Forms.Label lblCurrentServer
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCurrentServer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCurrentServer != null)
            {
                _lblCurrentServer.Click -= lblCurrentServer_Click;
            }

            _lblCurrentServer = value;
            if (_lblCurrentServer != null)
            {
                _lblCurrentServer.Click += lblCurrentServer_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblMainMgrInstructions;

    internal virtual Global.System.Windows.Forms.Label lblMainMgrInstructions
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblMainMgrInstructions;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblMainMgrInstructions = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlMainManagerLarger;

    internal virtual Global.System.Windows.Forms.Panel pnlMainManagerLarger
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlMainManagerLarger;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlMainManagerLarger = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlCDInfo;

    internal virtual Global.System.Windows.Forms.Panel pnlCDInfo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlCDInfo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlCDInfo = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnCDCashDrawer;

    internal virtual Global.System.Windows.Forms.Button btnCDCashDrawer
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCDCashDrawer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCDCashDrawer != null)
            {
                _btnCDCashDrawer.Click -= btnCDCashDrawer_Click;
            }

            _btnCDCashDrawer = value;
            if (_btnCDCashDrawer != null)
            {
                _btnCDCashDrawer.Click += btnCDCashDrawer_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnCDTickets;

    internal virtual Global.System.Windows.Forms.Button btnCDTickets
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCDTickets;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCDTickets != null)
            {
                _btnCDTickets.Click -= btnCDTickets_Click;
            }

            _btnCDTickets = value;
            if (_btnCDTickets != null)
            {
                _btnCDTickets.Click += btnCDTickets_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnCDClockedIn;

    internal virtual Global.System.Windows.Forms.Button btnCDClockedIn
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCDClockedIn;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCDClockedIn != null)
            {
                _btnCDClockedIn.Click -= btnCDClockedIn_Click;
            }

            _btnCDClockedIn = value;
            if (_btnCDClockedIn != null)
            {
                _btnCDClockedIn.Click += btnCDClockedIn_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _pnlClosingDailyDirections;

    internal virtual Global.System.Windows.Forms.Panel pnlClosingDailyDirections
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlClosingDailyDirections;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlClosingDailyDirections = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblDailyCloseDesc;

    internal virtual Global.System.Windows.Forms.Label lblDailyCloseDesc
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblDailyCloseDesc;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblDailyCloseDesc = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnClosingContinue;

    internal virtual Global.System.Windows.Forms.Button btnClosingContinue
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnClosingContinue;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnClosingContinue != null)
            {
                _btnClosingContinue.Click -= btnClosingContinue_Click;
            }

            _btnClosingContinue = value;
            if (_btnClosingContinue != null)
            {
                _btnClosingContinue.Click += btnClosingContinue_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnInventory;

    internal virtual Global.System.Windows.Forms.Button btnInventory
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnInventory;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnInventory != null)
            {
                _btnInventory.Click -= btnInventory_Click;
            }

            _btnInventory = value;
            if (_btnInventory != null)
            {
                _btnInventory.Click += btnInventory_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnMenu;

    internal virtual Global.System.Windows.Forms.Button btnMenu
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMenu;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMenu != null)
            {
                _btnMenu.Click -= btnMenu_Click;
            }

            _btnMenu = value;
            if (_btnMenu != null)
            {
                _btnMenu.Click += btnMenu_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnSystem;

    internal virtual Global.System.Windows.Forms.Button btnSystem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnSystem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnSystem != null)
            {
                _btnSystem.Click -= btnSystem_Click;
            }

            _btnSystem = value;
            if (_btnSystem != null)
            {
                _btnSystem.Click += btnSystem_Click;
            }
        }
    }

    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(Manager_Main_UC));
        _pnlMgrMainCategories = new System.Windows.Forms.Panel();
        _pnlManagerSelection = new System.Windows.Forms.Panel();
        _btnSystem = new System.Windows.Forms.Button();
        _btnSystem.Click += btnSystem_Click;
        _btnInventory = new System.Windows.Forms.Button();
        _btnInventory.Click += btnInventory_Click;
        _btnDailys = new System.Windows.Forms.Button();
        _btnDailys.Click += btnDailys_Click;
        _btnMgrExit = new System.Windows.Forms.Button();
        _btnMgrExit.Click += btnMgrExit_Click;
        _btnOperations = new System.Windows.Forms.Button();
        _btnOperations.Click += btnOperations_Click;
        _btnEmployees = new System.Windows.Forms.Button();
        _btnEmployees.Click += btnEmployees_Click;
        _btnMenu = new System.Windows.Forms.Button();
        _btnMenu.Click += btnMenu_Click;
        _btnReports = new System.Windows.Forms.Button();
        _btnReports.Click += btnReports_Click;
        _pnlManagerSubSelecetion = new System.Windows.Forms.Panel();
        _subButton5 = new System.Windows.Forms.Button();
        _subButton5.Click += subButton5_Click;
        _SubButtonBack = new System.Windows.Forms.Button();
        _SubButtonBack.Click += SubButtonBack_Click;
        _SubButton1 = new System.Windows.Forms.Button();
        _SubButton1.Click += SubButton1_Click;
        _SubButton2 = new System.Windows.Forms.Button();
        _SubButton2.Click += SubButton2_Click;
        _SubButton3 = new System.Windows.Forms.Button();
        _SubButton3.Click += SubButton3_Click;
        _SubButton4 = new System.Windows.Forms.Button();
        _SubButton4.Click += SubButton4_Click;
        _pnlMainManager = new System.Windows.Forms.Panel();
        _pnlMainManager.Click += OpenTabsAndTables_Selected;
        _pnlMainManager.Click += ClosedTabsAndTables_Selected;
        _Label1 = new System.Windows.Forms.Label();
        _lblMgrDirectionsNumberPad3 = new System.Windows.Forms.Label();
        _lblMgrDirectionsNumberPad2 = new System.Windows.Forms.Label();
        _lblMgrDirectionsNumberPad = new System.Windows.Forms.Label();
        _lblActiingManager = new System.Windows.Forms.Label();
        _lblCurrentServer = new System.Windows.Forms.Label();
        _lblCurrentServer.Click += lblCurrentServer_Click;
        _lblMainMgrInstructions = new System.Windows.Forms.Label();
        _pnlMainManagerLarger = new System.Windows.Forms.Panel();
        _pnlCDInfo = new System.Windows.Forms.Panel();
        _btnCDClockedIn = new System.Windows.Forms.Button();
        _btnCDClockedIn.Click += btnCDClockedIn_Click;
        _btnCDTickets = new System.Windows.Forms.Button();
        _btnCDTickets.Click += btnCDTickets_Click;
        _btnCDCashDrawer = new System.Windows.Forms.Button();
        _btnCDCashDrawer.Click += btnCDCashDrawer_Click;
        _pnlClosingDailyDirections = new System.Windows.Forms.Panel();
        _btnClosingContinue = new System.Windows.Forms.Button();
        _btnClosingContinue.Click += btnClosingContinue_Click;
        _lblDailyCloseDesc = new System.Windows.Forms.Label();
        _pnlMoreTickets = new System.Windows.Forms.Panel();
        _btnLessTickets = new System.Windows.Forms.Button();
        _btnLessTickets.Click += btnLessTickets_Click;
        _btnMoreTickets = new System.Windows.Forms.Button();
        _btnMoreTickets.Click += btnMoreTickets_Click;
        _lblVersion = new System.Windows.Forms.Label();
        _pnlMgrMainCategories.SuspendLayout();
        _pnlManagerSelection.SuspendLayout();
        _pnlManagerSubSelecetion.SuspendLayout();
        _pnlMainManager.SuspendLayout();
        _pnlMainManagerLarger.SuspendLayout();
        _pnlCDInfo.SuspendLayout();
        _pnlClosingDailyDirections.SuspendLayout();
        _pnlMoreTickets.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlMgrMainCategories
        // 
        _pnlMgrMainCategories.BackColor = System.Drawing.Color.Transparent;
        _pnlMgrMainCategories.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _pnlMgrMainCategories.Controls.Add(_pnlManagerSelection);
        _pnlMgrMainCategories.Controls.Add(_pnlManagerSubSelecetion);
        _pnlMgrMainCategories.Location = new System.Drawing.Point(16, 112);
        _pnlMgrMainCategories.Name = "_pnlMgrMainCategories";
        _pnlMgrMainCategories.Size = new System.Drawing.Size(132, 616);
        _pnlMgrMainCategories.TabIndex = 0;
        // 
        // pnlManagerSelection
        // 
        _pnlManagerSelection.BackColor = System.Drawing.Color.Transparent;
        _pnlManagerSelection.Controls.Add(_btnSystem);
        _pnlManagerSelection.Controls.Add(_btnInventory);
        _pnlManagerSelection.Controls.Add(_btnDailys);
        _pnlManagerSelection.Controls.Add(_btnMgrExit);
        _pnlManagerSelection.Controls.Add(_btnOperations);
        _pnlManagerSelection.Controls.Add(_btnEmployees);
        _pnlManagerSelection.Controls.Add(_btnMenu);
        _pnlManagerSelection.Controls.Add(_btnReports);
        _pnlManagerSelection.Location = new System.Drawing.Point(8, 24);
        _pnlManagerSelection.Name = "_pnlManagerSelection";
        _pnlManagerSelection.Size = new System.Drawing.Size(112, 576);
        _pnlManagerSelection.TabIndex = 4;
        // 
        // btnSystem
        // 
        _btnSystem.BackColor = System.Drawing.Color.LightSlateGray;
        _btnSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnSystem.Location = new System.Drawing.Point(0, 336);
        _btnSystem.Name = "_btnSystem";
        _btnSystem.Size = new System.Drawing.Size(112, 48);
        _btnSystem.TabIndex = 7;
        _btnSystem.Text = "System";
        _btnSystem.UseVisualStyleBackColor = false;
        // 
        // btnInventory
        // 
        _btnInventory.BackColor = System.Drawing.Color.LightSlateGray;
        _btnInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnInventory.Location = new System.Drawing.Point(0, 272);
        _btnInventory.Name = "_btnInventory";
        _btnInventory.Size = new System.Drawing.Size(112, 48);
        _btnInventory.TabIndex = 6;
        _btnInventory.Text = "Inventory";
        _btnInventory.UseVisualStyleBackColor = false;
        // 
        // btnDailys
        // 
        _btnDailys.BackColor = System.Drawing.Color.LightSlateGray;
        _btnDailys.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnDailys.Location = new System.Drawing.Point(0, 448);
        _btnDailys.Name = "_btnDailys";
        _btnDailys.Size = new System.Drawing.Size(112, 48);
        _btnDailys.TabIndex = 5;
        _btnDailys.Text = "Dailys";
        _btnDailys.UseVisualStyleBackColor = false;
        // 
        // btnMgrExit
        // 
        _btnMgrExit.BackColor = System.Drawing.Color.LightSlateGray;
        _btnMgrExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnMgrExit.Location = new System.Drawing.Point(0, 520);
        _btnMgrExit.Name = "_btnMgrExit";
        _btnMgrExit.Size = new System.Drawing.Size(112, 48);
        _btnMgrExit.TabIndex = 4;
        _btnMgrExit.Text = "Close";
        _btnMgrExit.UseVisualStyleBackColor = false;
        // 
        // btnOperations
        // 
        _btnOperations.BackColor = System.Drawing.Color.LightSlateGray;
        _btnOperations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnOperations.Location = new System.Drawing.Point(0, 16);
        _btnOperations.Name = "_btnOperations";
        _btnOperations.Size = new System.Drawing.Size(112, 48);
        _btnOperations.TabIndex = 0;
        _btnOperations.Text = "Operations";
        _btnOperations.UseVisualStyleBackColor = false;
        // 
        // btnEmployees
        // 
        _btnEmployees.BackColor = System.Drawing.Color.LightSlateGray;
        _btnEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnEmployees.Location = new System.Drawing.Point(0, 80);
        _btnEmployees.Name = "_btnEmployees";
        _btnEmployees.Size = new System.Drawing.Size(112, 48);
        _btnEmployees.TabIndex = 1;
        _btnEmployees.Text = "Employees";
        _btnEmployees.UseVisualStyleBackColor = false;
        // 
        // btnMenu
        // 
        _btnMenu.BackColor = System.Drawing.Color.LightSlateGray;
        _btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnMenu.Location = new System.Drawing.Point(0, 144);
        _btnMenu.Name = "_btnMenu";
        _btnMenu.Size = new System.Drawing.Size(112, 48);
        _btnMenu.TabIndex = 2;
        _btnMenu.Text = "Menu";
        _btnMenu.UseVisualStyleBackColor = false;
        // 
        // btnReports
        // 
        _btnReports.BackColor = System.Drawing.Color.LightSlateGray;
        _btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnReports.Location = new System.Drawing.Point(0, 208);
        _btnReports.Name = "_btnReports";
        _btnReports.Size = new System.Drawing.Size(112, 48);
        _btnReports.TabIndex = 3;
        _btnReports.Text = "Reports";
        _btnReports.UseVisualStyleBackColor = false;
        // 
        // pnlManagerSubSelecetion
        // 
        _pnlManagerSubSelecetion.BackColor = System.Drawing.Color.Transparent;
        _pnlManagerSubSelecetion.Controls.Add(_subButton5);
        _pnlManagerSubSelecetion.Controls.Add(_SubButtonBack);
        _pnlManagerSubSelecetion.Controls.Add(_SubButton1);
        _pnlManagerSubSelecetion.Controls.Add(_SubButton2);
        _pnlManagerSubSelecetion.Controls.Add(_SubButton3);
        _pnlManagerSubSelecetion.Controls.Add(_SubButton4);
        _pnlManagerSubSelecetion.Location = new System.Drawing.Point(-24, 8);
        _pnlManagerSubSelecetion.Name = "_pnlManagerSubSelecetion";
        _pnlManagerSubSelecetion.Size = new System.Drawing.Size(112, 576);
        _pnlManagerSubSelecetion.TabIndex = 5;
        _pnlManagerSubSelecetion.Visible = false;
        // 
        // subButton5
        // 
        _subButton5.BackColor = System.Drawing.Color.LightSlateGray;
        _subButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _subButton5.Location = new System.Drawing.Point(0, 310);
        _subButton5.Name = "_subButton5";
        _subButton5.Size = new System.Drawing.Size(112, 48);
        _subButton5.TabIndex = 5;
        _subButton5.UseVisualStyleBackColor = false;
        // 
        // SubButtonBack
        // 
        _SubButtonBack.BackColor = System.Drawing.Color.LightSlateGray;
        _SubButtonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _SubButtonBack.Location = new System.Drawing.Point(0, 520);
        _SubButtonBack.Name = "_SubButtonBack";
        _SubButtonBack.Size = new System.Drawing.Size(112, 48);
        _SubButtonBack.TabIndex = 4;
        _SubButtonBack.Text = "Back";
        _SubButtonBack.UseVisualStyleBackColor = false;
        // 
        // SubButton1
        // 
        _SubButton1.BackColor = System.Drawing.Color.LightSlateGray;
        _SubButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _SubButton1.Location = new System.Drawing.Point(0, 24);
        _SubButton1.Name = "_SubButton1";
        _SubButton1.Size = new System.Drawing.Size(112, 48);
        _SubButton1.TabIndex = 0;
        _SubButton1.UseVisualStyleBackColor = false;
        // 
        // SubButton2
        // 
        _SubButton2.BackColor = System.Drawing.Color.LightSlateGray;
        _SubButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _SubButton2.Location = new System.Drawing.Point(0, 96);
        _SubButton2.Name = "_SubButton2";
        _SubButton2.Size = new System.Drawing.Size(112, 48);
        _SubButton2.TabIndex = 1;
        _SubButton2.UseVisualStyleBackColor = false;
        // 
        // SubButton3
        // 
        _SubButton3.BackColor = System.Drawing.Color.LightSlateGray;
        _SubButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _SubButton3.Location = new System.Drawing.Point(0, 168);
        _SubButton3.Name = "_SubButton3";
        _SubButton3.Size = new System.Drawing.Size(112, 48);
        _SubButton3.TabIndex = 2;
        _SubButton3.UseVisualStyleBackColor = false;
        // 
        // SubButton4
        // 
        _SubButton4.BackColor = System.Drawing.Color.LightSlateGray;
        _SubButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _SubButton4.Location = new System.Drawing.Point(0, 240);
        _SubButton4.Name = "_SubButton4";
        _SubButton4.Size = new System.Drawing.Size(112, 48);
        _SubButton4.TabIndex = 3;
        _SubButton4.UseVisualStyleBackColor = false;
        // 
        // pnlMainManager
        // 
        _pnlMainManager.BackColor = System.Drawing.Color.Black;
        _pnlMainManager.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _pnlMainManager.Controls.Add(_Label1);
        _pnlMainManager.Controls.Add(_lblMgrDirectionsNumberPad3);
        _pnlMainManager.Controls.Add(_lblMgrDirectionsNumberPad2);
        _pnlMainManager.Controls.Add(_lblMgrDirectionsNumberPad);
        _pnlMainManager.ForeColor = System.Drawing.Color.Black;
        _pnlMainManager.Location = new System.Drawing.Point(8, 8);
        _pnlMainManager.Name = "_pnlMainManager";
        _pnlMainManager.Size = new System.Drawing.Size(800, 632);
        _pnlMainManager.TabIndex = 1;
        // 
        // Label1
        // 
        _Label1.ForeColor = System.Drawing.Color.White;
        _Label1.Location = new System.Drawing.Point(24, 8);
        _Label1.Name = "_Label1";
        _Label1.Size = new System.Drawing.Size(88, 40);
        _Label1.TabIndex = 5;
        _Label1.Text = "There are 2 panels to the left";
        _Label1.Visible = false;
        // 
        // lblMgrDirectionsNumberPad3
        // 
        _lblMgrDirectionsNumberPad3.ForeColor = System.Drawing.Color.White;
        _lblMgrDirectionsNumberPad3.Location = new System.Drawing.Point(72, 344);
        _lblMgrDirectionsNumberPad3.Name = "_lblMgrDirectionsNumberPad3";
        _lblMgrDirectionsNumberPad3.Size = new System.Drawing.Size(176, 80);
        _lblMgrDirectionsNumberPad3.TabIndex = 4;
        // 
        // lblMgrDirectionsNumberPad2
        // 
        _lblMgrDirectionsNumberPad2.ForeColor = System.Drawing.Color.White;
        _lblMgrDirectionsNumberPad2.Location = new System.Drawing.Point(80, 224);
        _lblMgrDirectionsNumberPad2.Name = "_lblMgrDirectionsNumberPad2";
        _lblMgrDirectionsNumberPad2.Size = new System.Drawing.Size(176, 24);
        _lblMgrDirectionsNumberPad2.TabIndex = 3;
        _lblMgrDirectionsNumberPad2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblMgrDirectionsNumberPad
        // 
        _lblMgrDirectionsNumberPad.Font = new System.Drawing.Font("Comic Sans MS", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblMgrDirectionsNumberPad.ForeColor = System.Drawing.Color.White;
        _lblMgrDirectionsNumberPad.Location = new System.Drawing.Point(80, 176);
        _lblMgrDirectionsNumberPad.Name = "_lblMgrDirectionsNumberPad";
        _lblMgrDirectionsNumberPad.Size = new System.Drawing.Size(176, 32);
        _lblMgrDirectionsNumberPad.TabIndex = 1;
        _lblMgrDirectionsNumberPad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblActiingManager
        // 
        _lblActiingManager.BackColor = System.Drawing.Color.Transparent;
        _lblActiingManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblActiingManager.ForeColor = System.Drawing.Color.Black;
        _lblActiingManager.Location = new System.Drawing.Point(16, 16);
        _lblActiingManager.Name = "_lblActiingManager";
        _lblActiingManager.Size = new System.Drawing.Size(296, 32);
        _lblActiingManager.TabIndex = 0;
        _lblActiingManager.Text = "Manager:  ";
        _lblActiingManager.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
        // 
        // lblCurrentServer
        // 
        _lblCurrentServer.BackColor = System.Drawing.Color.Transparent;
        _lblCurrentServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblCurrentServer.ForeColor = System.Drawing.Color.Black;
        _lblCurrentServer.Location = new System.Drawing.Point(48, 56);
        _lblCurrentServer.Name = "_lblCurrentServer";
        _lblCurrentServer.Size = new System.Drawing.Size(264, 32);
        _lblCurrentServer.TabIndex = 3;
        _lblCurrentServer.Text = "Server:";
        _lblCurrentServer.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
        // 
        // lblMainMgrInstructions
        // 
        _lblMainMgrInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblMainMgrInstructions.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _lblMainMgrInstructions.Location = new System.Drawing.Point(152, 8);
        _lblMainMgrInstructions.Name = "_lblMainMgrInstructions";
        _lblMainMgrInstructions.Size = new System.Drawing.Size(536, 32);
        _lblMainMgrInstructions.TabIndex = 4;
        _lblMainMgrInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // pnlMainManagerLarger
        // 
        _pnlMainManagerLarger.BackColor = System.Drawing.Color.Black;
        _pnlMainManagerLarger.Controls.Add(_pnlMainManager);
        _pnlMainManagerLarger.Controls.Add(_lblMainMgrInstructions);
        _pnlMainManagerLarger.Location = new System.Drawing.Point(176, 96);
        _pnlMainManagerLarger.Name = "_pnlMainManagerLarger";
        _pnlMainManagerLarger.Size = new System.Drawing.Size(816, 648);
        _pnlMainManagerLarger.TabIndex = 5;
        // 
        // pnlCDInfo
        // 
        _pnlCDInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _pnlCDInfo.Controls.Add(_btnCDClockedIn);
        _pnlCDInfo.Controls.Add(_btnCDTickets);
        _pnlCDInfo.Controls.Add(_btnCDCashDrawer);
        _pnlCDInfo.Location = new System.Drawing.Point(336, 16);
        _pnlCDInfo.Name = "_pnlCDInfo";
        _pnlCDInfo.Size = new System.Drawing.Size(355, 49);
        _pnlCDInfo.TabIndex = 6;
        _pnlCDInfo.Visible = false;
        // 
        // btnCDClockedIn
        // 
        _btnCDClockedIn.BackColor = System.Drawing.Color.DodgerBlue;
        _btnCDClockedIn.Location = new System.Drawing.Point(232, 9);
        _btnCDClockedIn.Name = "_btnCDClockedIn";
        _btnCDClockedIn.Size = new System.Drawing.Size(112, 32);
        _btnCDClockedIn.TabIndex = 2;
        _btnCDClockedIn.Text = "Clocked In";
        _btnCDClockedIn.UseVisualStyleBackColor = false;
        // 
        // btnCDTickets
        // 
        _btnCDTickets.BackColor = System.Drawing.Color.DodgerBlue;
        _btnCDTickets.Location = new System.Drawing.Point(12, 8);
        _btnCDTickets.Name = "_btnCDTickets";
        _btnCDTickets.Size = new System.Drawing.Size(104, 32);
        _btnCDTickets.TabIndex = 1;
        _btnCDTickets.Text = "Tickets";
        _btnCDTickets.UseVisualStyleBackColor = false;
        // 
        // btnCDCashDrawer
        // 
        _btnCDCashDrawer.BackColor = System.Drawing.Color.DodgerBlue;
        _btnCDCashDrawer.Location = new System.Drawing.Point(122, 8);
        _btnCDCashDrawer.Name = "_btnCDCashDrawer";
        _btnCDCashDrawer.Size = new System.Drawing.Size(104, 32);
        _btnCDCashDrawer.TabIndex = 0;
        _btnCDCashDrawer.Text = "Cash Drawer";
        _btnCDCashDrawer.UseVisualStyleBackColor = false;
        // 
        // pnlClosingDailyDirections
        // 
        _pnlClosingDailyDirections.BackColor = System.Drawing.Color.Black;
        _pnlClosingDailyDirections.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _pnlClosingDailyDirections.Controls.Add(_btnClosingContinue);
        _pnlClosingDailyDirections.Controls.Add(_lblDailyCloseDesc);
        _pnlClosingDailyDirections.Location = new System.Drawing.Point(712, 8);
        _pnlClosingDailyDirections.Name = "_pnlClosingDailyDirections";
        _pnlClosingDailyDirections.Size = new System.Drawing.Size(296, 80);
        _pnlClosingDailyDirections.TabIndex = 6;
        _pnlClosingDailyDirections.Visible = false;
        // 
        // btnClosingContinue
        // 
        _btnClosingContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnClosingContinue.ForeColor = System.Drawing.Color.White;
        _btnClosingContinue.Location = new System.Drawing.Point(200, 16);
        _btnClosingContinue.Name = "_btnClosingContinue";
        _btnClosingContinue.Size = new System.Drawing.Size(80, 48);
        _btnClosingContinue.TabIndex = 1;
        _btnClosingContinue.Text = "Close Batch";
        // 
        // lblDailyCloseDesc
        // 
        _lblDailyCloseDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _lblDailyCloseDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblDailyCloseDesc.ForeColor = System.Drawing.Color.DodgerBlue;
        _lblDailyCloseDesc.Location = new System.Drawing.Point(8, 8);
        _lblDailyCloseDesc.Name = "_lblDailyCloseDesc";
        _lblDailyCloseDesc.Size = new System.Drawing.Size(184, 64);
        _lblDailyCloseDesc.TabIndex = 0;
        _lblDailyCloseDesc.Text = "All Tickets and Cash Drawers must be closed before Closing Batch and Daily.";
        _lblDailyCloseDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pnlMoreTickets
        // 
        _pnlMoreTickets.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _pnlMoreTickets.Controls.Add(_btnLessTickets);
        _pnlMoreTickets.Controls.Add(_btnMoreTickets);
        _pnlMoreTickets.Location = new System.Drawing.Point(697, 25);
        _pnlMoreTickets.Name = "_pnlMoreTickets";
        _pnlMoreTickets.Size = new System.Drawing.Size(239, 63);
        _pnlMoreTickets.TabIndex = 7;
        _pnlMoreTickets.Visible = false;
        // 
        // btnLessTickets
        // 
        _btnLessTickets.BackColor = System.Drawing.Color.DodgerBlue;
        _btnLessTickets.Location = new System.Drawing.Point(12, 8);
        _btnLessTickets.Name = "_btnLessTickets";
        _btnLessTickets.Size = new System.Drawing.Size(104, 45);
        _btnLessTickets.TabIndex = 1;
        _btnLessTickets.Text = "Reset";
        _btnLessTickets.UseVisualStyleBackColor = false;
        // 
        // btnMoreTickets
        // 
        _btnMoreTickets.BackColor = System.Drawing.Color.DodgerBlue;
        _btnMoreTickets.Location = new System.Drawing.Point(122, 8);
        _btnMoreTickets.Name = "_btnMoreTickets";
        _btnMoreTickets.Size = new System.Drawing.Size(104, 45);
        _btnMoreTickets.TabIndex = 0;
        _btnMoreTickets.Text = "More";
        _btnMoreTickets.UseVisualStyleBackColor = false;
        // 
        // lblVersion
        // 
        _lblVersion.AutoSize = true;
        _lblVersion.BackColor = System.Drawing.Color.Transparent;
        _lblVersion.ForeColor = System.Drawing.Color.MidnightBlue;
        _lblVersion.Location = new System.Drawing.Point(13, 762);
        _lblVersion.Name = "_lblVersion";
        _lblVersion.Size = new System.Drawing.Size(41, 13);
        _lblVersion.TabIndex = 8;
        _lblVersion.Text = "version";
        // 
        // Manager_Main_UC
        // 
        this.BackColor = System.Drawing.Color.Black;
        this.BackgroundImage = (Global.System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
        this.Controls.Add(_lblVersion);
        this.Controls.Add(_pnlMoreTickets);
        this.Controls.Add(_pnlCDInfo);
        this.Controls.Add(_lblCurrentServer);
        this.Controls.Add(_lblActiingManager);
        this.Controls.Add(_pnlMgrMainCategories);
        this.Controls.Add(_pnlMainManagerLarger);
        this.Controls.Add(_pnlClosingDailyDirections);
        this.ForeColor = System.Drawing.Color.White;
        this.Name = "Manager_Main_UC";
        this.Size = new System.Drawing.Size(1024, 786);
        _pnlMgrMainCategories.ResumeLayout(false);
        _pnlManagerSelection.ResumeLayout(false);
        _pnlManagerSubSelecetion.ResumeLayout(false);
        _pnlMainManager.ResumeLayout(false);
        _pnlMainManagerLarger.ResumeLayout(false);
        _pnlCDInfo.ResumeLayout(false);
        _pnlClosingDailyDirections.ResumeLayout(false);
        _pnlMoreTickets.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private void InitializeOther()
    {

        pnlManagerSubSelecetion.Location = new Point(8, 24);
        // 
        // mgrLargeNumberPad
        // 
        mgrLargeNumberPad = new NumberPad();
        mgrLargeNumberPad.Location = new System.Drawing.Point(360, 140);
        mgrLargeNumberPad.Name = "mgrLargeNumberPad";
        mgrLargeNumberPad.MakeBuutonsWhite();
        pnlMainManager.Controls.Add(mgrLargeNumberPad);
        lblVersion.Text = companyInfo.VersionNumber;
        // Me.lblVersion.Text = ""

        if (usernameEnterOnLogin == false)
        {
            pnlMgrMainCategories.Enabled = false;
            lblMgrDirectionsNumberPad.Text = currentServer.FullName;
            if (currentTerminal.TermMethod == "Quick" | companyInfo.usingBartenderMethod == true)
            {
                lblMgrDirectionsNumberPad2.Text = "Enter your Username and Password";
            }
            else
            {
                lblMgrDirectionsNumberPad2.Text = "Hit Enter";
                lblMgrDirectionsNumberPad3.Text = "If you are not " + currentServer.FullName + " enter your Username and Passcode, then Enter.";
            }
        }
        else
        {
            GenerateOrderTables.AssignManagementAuthorization(actingManager);
            DisplayLabelsBasedOnAuth();
        }

        // info = New DataSet_Builder.Info2_UC("")
        // info.Location = New Point((pnlMainManager.Width - info.Width) / 2, (pnlMainManager.Height - info.Height) / 2)
        // Me.pnlMainManager.Controls.Add(info)
        // info.Visible = False

    }

    private void MgrPasscodeEnter(object sender, EventArgs e)
    {
        Employee emp;

        if (mgrLargeNumberPad.NumberString.Length == 8)
        {
            emp = DetermineSecondEmployeeAuthorization(mgrLargeNumberPad.NumberString);
            if (emp is not null)
            {
                GenerateOrderTables.AssignManagementAuthorization(emp);
                DisplayLabelsBasedOnAuth();
            }
        }
        else
        {
            Interaction.MsgBox("Please Combine Your EmployeeID as Passcode then Press Enter");

        }
    }

    private void ActingManagerIsAccepted()
    {
        // this is when the same employee is overriding system

        if (currentTerminal.TermMethod == "Quick" | companyInfo.usingBartenderMethod == true)
        {
            countNumberOfAttemptsToLeave += 1;
            if (countNumberOfAttemptsToLeave > 2)
            {
                DisposeManager?.Invoke();
            }
            return;
        }

        actingManager = currentServer;
        GenerateOrderTables.AssignManagementAuthorization(actingManager);
        DisplayLabelsBasedOnAuth();

    }

    private void DisplayLabelsBasedOnAuth()
    {

        // make this according to auth
        pnlMgrMainCategories.Enabled = true;
        lblMgrDirectionsNumberPad.Visible = false;
        lblMgrDirectionsNumberPad2.Visible = false;
        lblMgrDirectionsNumberPad3.Visible = false;
        mgrLargeNumberPad.Visible = false;

        lblActiingManager.Text = "Manager:   " + actingManager.FullName;

    }
    private void AssignManagementAuthorization222(ref Employee empAuth)
    {
        // now in geneateOrderTables
        // employeeAuthorization = New ManagementAuthorization

        employeeAuthorization.FullName = empAuth.FullName;

        if (empAuth.OperationMgmtAll == true)
        {
            employeeAuthorization.OperationLevel = 2;
        }
        else if (empAuth.OperationMgmtLimited == true)
        {
            employeeAuthorization.OperationLevel = 1;
        }
        else
        {
            employeeAuthorization.OperationLevel = 0;
        }

        if (empAuth.EmployeeMgmtAll == true)
        {
            employeeAuthorization.EmployeeLevel = 2;
        }
        else if (empAuth.EmployeeMgmtLimited == true)
        {
            employeeAuthorization.EmployeeLevel = 1;
        }
        else
        {
            employeeAuthorization.EmployeeLevel = 0;
        }

        if (empAuth.ReportMgmtAll == true)
        {
            employeeAuthorization.ReportLevel = 2;
        }
        else if (empAuth.ReportMgmtLimited == true)
        {
            employeeAuthorization.ReportLevel = 1;
        }
        else
        {
            employeeAuthorization.ReportLevel = 0;
        }

        if (empAuth.SystemMgmtAll == true)
        {
            employeeAuthorization.SystemLevel = 2;
        }
        else if (empAuth.SystemMgmtLimited == true)
        {
            employeeAuthorization.SystemLevel = 1;
        }
        else
        {
            employeeAuthorization.SystemLevel = 0;
        }

        // do not need below anymore
        employeeAuthorization.OperationAll = empAuth.OperationMgmtAll;
        employeeAuthorization.OperationLimited = empAuth.OperationMgmtLimited;
        employeeAuthorization.EmployeeAll = empAuth.EmployeeMgmtAll;
        employeeAuthorization.EmployeeLimited = empAuth.EmployeeMgmtLimited;
        employeeAuthorization.ReportAll = empAuth.ReportMgmtAll;
        employeeAuthorization.ReportLimited = empAuth.ReportMgmtLimited;
        employeeAuthorization.SystemAll = empAuth.SystemMgmtAll;
        employeeAuthorization.SystemLimited = empAuth.SystemMgmtLimited;


        // make this according to auth
        pnlMgrMainCategories.Enabled = true;
        lblMgrDirectionsNumberPad.Visible = false;
        lblMgrDirectionsNumberPad2.Visible = false;
        lblMgrDirectionsNumberPad3.Visible = false;
        mgrLargeNumberPad.Visible = false;

        lblActiingManager.Text = "Manager:   " + actingManager.FullName;

    }

    private void ResetAllFlags()
    {

        closingDailyCode = 0L;
        OperationFlag = false;
        EmployeeFlag = false;
        ReopenFlag = false;
        MenuFlag = false;
        SystemFlag = false;
        DailysFlag = false;
        InventoryFlag = false;
        pnlCDInfo.Visible = false;
        pnlClosingDailyDirections.Visible = false;
        pnlMoreTickets.Visible = false;

        btnOperations.BackColor = c10;
        // Me.btnOperations.ForeColor = c2
        btnEmployees.BackColor = c10;
        // Me.btnEmployees.ForeColor = c2
        btnReports.BackColor = c10;
        // Me.btnReports.ForeColor = c2
        btnMenu.BackColor = c10;

        btnSystem.BackColor = c10;
        // Me.btnSystem.ForeColor = c2
        btnDailys.BackColor = c10;
        // Me.btnDailys.ForeColor = c2
        btnInventory.BackColor = c10;
        // Me.btnInventory.ForeColor = c2

    }



    private void btnInventory_Click(object sender, EventArgs e)
    {

        // If typeProgram = "Online_Demo" Then
        // 'Inventory
        // CreateRawCategoryTableStructure(dtRawCategory)
        // CreateRawMatTableStructure(dtRawMat)
        // CreateRawDeliveryTableStructure(dtRawDelivery)
        // CreateRawDeliveryTableStructure(dtRawCycley)
        // dsInventory.ReadXml("InventoryData.xml", XmlReadMode.ReadSchema)
        // End If

        ResetAllFlags();
        btnInventory.BackColor = Color.FromArgb(59, 96, 141);
        // Me.btnInventory.ForeColor = c3
        InventoryFlag = true;

        pnlMainManager.Controls.Clear();

        if (employeeAuthorization.OperationLevel > 0)
        {
            DisplayInventoryChoices();
        }
        else
        {
            Interaction.MsgBox(actingManager.FullName + " is not authorized for System changes.");
            return;
        }

    }

    private void DisplayInventoryChoices()
    {
        pnlManagerSelection.Visible = false;
        pnlManagerSubSelecetion.Visible = true;

        RemoveTextFromSubButtons();
        SubButton1.Text = "Delivery";
        SubButton2.Text = "Waste";
        SubButton3.Text = "";
        SubButton4.Text = "Physical Inventory";
        InventoryTable = "";
        // DisplayConnectionButton()

    }

    private void btnOperations_Click(object sender, EventArgs e)
    {

        ResetAllFlags();
        btnOperations.BackColor = Color.FromArgb(59, 96, 141);
        // Me.btnOperations.ForeColor = c3
        OperationFlag = true;

        pnlMainManager.Controls.Clear();
        pnlMoreTickets.Visible = true;

        if (employeeAuthorization.OperationLevel > 0)
        {
            if (!(typeProgram == "Online_Demo"))
            {
                PopulateServerCollection(todaysFloorPersonnel);
            }
            activeCollection = todaysFloorPersonnel;
            DisplayFloorPersonnel(); // (todaysFloorPersonnel)
        }
        else
        {
            Interaction.MsgBox(actingManager.FullName + " is not authorized for Operational changes.");
            return;
        }

        pnlManagerSelection.Visible = false;
        pnlManagerSubSelecetion.Visible = true;

        RemoveTextFromSubButtons();
        SubButton1.Text = "New Table";
        SubButton2.Text = "New Tab";
        SubButton3.Text = "Cash Out";
        SubButton4.Text = "Credit Return";

    }

    private bool DetermineIfOpenTables(long selectedDailyCode)
    {

        GenerateOrderTables.PopulateTabsAndTablesEveryone(empActive, selectedDailyCode, true, false, todaysFloorPersonnel);


        // GenerateOrderTables.CreateDataViews()
        // 
        // If dvAvailTables.Count + dvAvailTabs.Count > 0 Then
        // Return False
        // Else
        // Return True
        // End If
        // 
        return default;
        // ********************************************************************
        // ***222   we are no longer using "OpenTables" here
        // we may be using them on Opening POS

        DataRow oRow;

        if (mainServerConnected == true)
        {
            try
            {
                dsOrder.Tables("OpenTables").Rows.Clear();
                dsOrder.Tables("OpenTabs").Rows.Clear();

                sql.cn.Open();
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                // sql.SqlSelectCommandOpenTables.Parameters("@CompanyID").Value = CompanyID
                // sql222.SqlSelectCommandOpenTables.Parameters("@LocationID").Value = companyInfo.LocationID
                // sql222.SqlSelectCommandOpenTables.Parameters("@DailyCode").Value = selectedDailyCode
                // sql222.SqlDataAdapterOpenTables.Fill(dsOrder.Tables("OpenTables"))

                // sql.SqlSelectCommandOpenTabs.Parameters("@CompanyID").Value = CompanyID
                // sql222.SqlSelectCommandOpenTabs.Parameters("@LocationID").Value = companyInfo.LocationID
                // sql222.SqlSelectCommandOpenTabs.Parameters("@DailyCode").Value = selectedDailyCode
                // sql222.SqlDataAdapterOpenTabs.Fill(dsOrder.Tables("OpenTabs"))
                sql.cn.Close();

                // CreateAvailDataViews222()
                // If dsOrder.Tables("OpenTables").Rows.Count + dsOrder.Tables("OpenTabs").Rows.Count > 0 Then
                if (dvAvailTables.Count + dvAvailTabs.Count + dvQuickTickets.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception ex)
            {
                CloseConnection();
                ServerJustWentDown();
                Interaction.MsgBox("Server is Not Connected. You can not close Daily until Server is connected. You can close Daily another day.");
                return true;
            }
        }
        else
        {
            Interaction.MsgBox("You can not close Daily until Server is connected. You can close Daily another day.");
            return true;
        }

    }

    private void DisplayFloorPersonnel() // ByRef activeCollection As EmployeeCollection)
    {
        float w;
        float h;
        int x = buttonSpace;
        int y = buttonSpace;
        var index = default(int);
        int counterIndex = 1;
        mainPanelCounterIndex = 0;

        w = (pnlMainManager.Width - 6 * buttonSpace) / 5;
        h = (pnlMainManager.Height - 11 * buttonSpace) / 10;


        foreach (Employee emp in activeCollection)
        {

            if (!(emp.EmployeeID == 6986) | actingManager.EmployeeID == 6986)
            {
                floorPersonnel = new KitchenButton(emp.FullName, w, h, c10, c2);
                floorPersonnel.Location = new Point(x, y);
                floorPersonnel.ID = emp.EmployeeID;
                floorPersonnel.ButtonIndex = index;
                this.floorPersonnel.Click += FloorPerson_Click;

                pnlMainManager.Controls.Add(floorPersonnel);

                if (counterIndex == 10)
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

        floorPersonnel = default;

        if (!object.ReferenceEquals(activeCollection, allFloorPersonnel))
        {

            floorPersonnel = new KitchenButton("All Floor", w, h, c10, c2);
            floorPersonnel.Location = new Point(x, y);
            floorPersonnel.ID = -1111;
            floorPersonnel.ButtonIndex = index;
            this.floorPersonnel.Click += FloorPerson_Click;

            pnlMainManager.Controls.Add(floorPersonnel);
        }

    }


    private void FloorPerson_Click(object sender, EventArgs e)
    {
        var objButton = new KitchenButton("ForTesting", 0, 0, c3, c2);
        if (!object.ReferenceEquals(sender.GetType(), objButton.GetType))
            return;

        objButton = (KitchenButton)sender;
        // empActive = objButton.ID

        if (objButton.ID == -1111)
        {
            // displaying all personnel
            pnlMainManager.Controls.Clear();
            activeCollection = allFloorPersonnel;
            DisplayFloorPersonnel();
            return;
        }

        foreach (Employee emp in activeCollection)    // todaysFloorPersonnel
        {
            if (emp.EmployeeID == objButton.ID)   // empActive Then
            {
                // currentServer = emp
                empActive = emp;
                lblCurrentServer.Text = "Server: " + empActive.FullName;
                break;
            }
        }

        pnlMainManager.Controls.Clear();

        if (empActive is null)
        {
            empActive = actingManager;
        }
        currentServer = empActive;


        if (OperationFlag == true)
        {

            GenerateOrderTables.PopulateTabsAndTables(empActive, currentTerminal.CurrentDailyCode, false, false, default);
            CreateDataViews(empActive.EmployeeID, true);
            // PopulateOpenTabsAndTables()
            DisplayOpenTabsAndTables();
        }
        else if (EmployeeFlag == true)
        {

            if (employeeAuthorization.EmployeeLevel > 1)
            {
                ClockAdjustment_Click(sender, e);
                // we are currently go straight to emp Clock Adj
                // we may change to below if more choices become avail 
                // DisplayEmployeeAdjustmentOptions()
            }
        }

    }

    internal void DisplayOpenTabsAndTables()
    {

        DataRowView vRow;
        int index = 1;
        int counterIndex = 1;

        int x = buttonSpace;
        int y = buttonSpace;
        float w;
        float h;

        w = (pnlMainManager.Width - 6 * buttonSpace) / 5;
        h = (pnlMainManager.Height - 11 * buttonSpace) / 10;

        displayingOpenOrClose = "Open";
        // 444      Me.pnlMoreTickets.Visible = True

        foreach (DataRowView currentVRow in dvAvailTables)
        {
            vRow = currentVRow;

            if (index > mainPanelCounterIndex)
            {
                CreateOpenTabsAndTables(false, vRow, w, h, x, y, vRow("TableNumber"), false);

                if (counterIndex == 10)
                {
                    y = buttonSpace;
                    x += w + buttonSpace;
                    counterIndex = 0;    // must restart at zero b/c we add 1 right away
                }
                else
                {
                    y += h + buttonSpace;
                }
                counterIndex += 1;
            }

            index += 1;
        }


        foreach (DataRowView currentVRow1 in dvAvailTabs)
        {
            vRow = currentVRow1;
            if (index > mainPanelCounterIndex)
            {
                CreateOpenTabsAndTables(true, vRow, w, h, x, y, vRow("TabName"), false);

                if (counterIndex == 10)
                {
                    y = buttonSpace;
                    x += w + buttonSpace;
                    counterIndex = 0;    // must restart at zero b/c we add 1 right away
                }
                else
                {
                    y += h + buttonSpace;
                }
                counterIndex += 1;
            }

            index += 1;
        }

        foreach (DataRowView currentVRow2 in dvTransferTables)
        {
            vRow = currentVRow2;
            if (index > mainPanelCounterIndex)
            {
                CreateOpenTabsAndTables(false, vRow, w, h, x, y, vRow("TableNumber"), false);

                if (counterIndex == 10)
                {
                    y = buttonSpace;
                    x += w + buttonSpace;
                    counterIndex = 0;    // must restart at zero b/c we add 1 right away
                }
                else
                {
                    y += h + buttonSpace;
                }
                counterIndex += 1;
            }

            index += 1;
        }

        foreach (DataRowView currentVRow3 in dvTransferTabs)
        {
            vRow = currentVRow3;
            if (index > mainPanelCounterIndex)
            {
                CreateOpenTabsAndTables(true, vRow, w, h, x, y, vRow("TabName"), false);

                if (counterIndex == 10)
                {
                    y = buttonSpace;
                    x += w + buttonSpace;
                    counterIndex = 0;    // must restart at zero b/c we add 1 right away
                }
                else
                {
                    y += h + buttonSpace;
                }
                counterIndex += 1;
            }

            index += 1;
        }

        if (DailysFlag == true)
        {
            string tabDesc;
            // we are closeing daily
            // only using CreateClosedTabsAndTablesButton because it formats Text
            foreach (DataRowView currentVRow4 in dvQuickTickets)
            {
                vRow = currentVRow4;

                tabDesc = "Tkt# " + vRow("TicketNumber").ToString;
                CreateOpenTabsAndTables(true, vRow, w, h, x, y, tabDesc, false);
                // CreateClosedTabsAndTablesButton(True, vRow, w, h, x, y, Nothing, vRow("LastStatusTime"))

                if (counterIndex == 10)
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
        // this is for individuals
        // so we just want Beth's Tabs to show
        else if (!(currentTerminal.TermMethod == "Quick"))
        {
            if (dvQuickTickets.Count > 0)
            {
                vRow = dvQuickTickets(dvQuickTickets.Count - 1);

                // CreateOpenTabsAndTables(True, vRow, w, h, x, y, vRow("TicketNumber"))
                CreateOpenTabsAndTables(true, vRow, w, h, x, y, vRow("TabName"), true);

                if (counterIndex == 10)
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

        if (DailysFlag == false)
        {
            btnClosedTable = new Button();
            {
                var withBlock = btnClosedTable;
                withBlock.Text = "Closed Checks";
                withBlock.Size = new Size(w, h);
                withBlock.Location = new Point(x, y);
                withBlock.BackColor = c7;
                withBlock.ForeColor = c3;
                this.btnClosedTable.Click += ClosedTables_Click;
            }
            pnlMainManager.Controls.Add(btnClosedTable);
        }

    }

    private void DisplayGroupTabs()
    {
        var index = default(int);
        int counterIndex = 1;
        // Dim serverTableDesc As String
        DateTime lsTime;
        string tabDesc;

        int x = buttonSpace;
        int y = buttonSpace;
        float w;
        float h;

        w = (pnlMainManager.Width - 6 * buttonSpace) / 5;
        h = (pnlMainManager.Height - 11 * buttonSpace) / 10;

        pnlMainManager.Controls.Clear();
        displayingOpenOrClose = "Beths";

        foreach (DataRowView vRow in dvQuickTickets)
        {
            if (index > mainPanelCounterIndex)
            {
                // serverTableDesc = "" 'vRow("NickName") & " " & vRow("LastName")
                if (object.ReferenceEquals(vRow("ClosedSubTotal"), DBNull.Value))
                {
                    tabDesc = "Tkt# " + vRow("TicketNumber").ToString;

                    CreateOpenTabsAndTables(true, vRow, w, h, x, y, tabDesc, false);
                }
                else
                {
                    lsTime = vRow("LastStatusTime");
                    CreateClosedTabsAndTablesButton(true, vRow, w, h, x, y, default, lsTime);

                }

                if (counterIndex == 10)
                {
                    y = buttonSpace;
                    x += w + buttonSpace;
                    counterIndex = 0;    // must restart at zero b/c we add 1 right away
                }
                else
                {
                    y += h + buttonSpace;
                }
                counterIndex += 1;
            }

            index += 1;
        }

    }

    private void CreateOpenTabsAndTables(bool isTabNotTable, DataRowView vRowUsed, float w, float h, float x, float y, string TabTableDesc, bool isGroup)
    {
        var tn = default(int);
        var tab = default(long);
        DataSet_Builder.AvailTableUserControl btnTabsAndTables;
        string altMethodUse = "";

        if (!(dvTerminalsUseOrder[0]("MethodUse") == vRowUsed("MethodUse")))
        {
            altMethodUse = vRowUsed("MethodUse");
        }
        else
        {
            altMethodUse = "";
        }

        if (isTabNotTable == true)
        {
            tab = vRowUsed("TabID");
        }
        else
        {
            tn = vRowUsed("TableNumber");
        }

        // btnTabsAndTables = New DataSet_Builder.AvailTableUserControl(isTabNotTable, tn, tab, vRowUsed("TabName"), vRowUsed("TicketNumber"), Nothing, Nothing, Nothing, Nothing, Nothing, vRowUsed("ItemsOnHold"))
        btnTabsAndTables = new DataSet_Builder.AvailTableUserControl(isTabNotTable, tn, tab, TabTableDesc, vRowUsed("TicketNumber"), (object)null, (object)null, (object)null, (object)null, (object)null, vRowUsed("ItemsOnHold"), currentTerminal.TermMethod, altMethodUse);

        // this does not change test
        if (isTabNotTable == true)
        {
            btnTabsAndTables.Text = TabTableDesc; // vRowUsed("TabName")
            btnTabsAndTables.TabID = tab;
        }
        else
        {
            btnTabsAndTables.Text = TabTableDesc; // vRowUsed("TableNumber")
            btnTabsAndTables.TableNumber = tn;
        }
        btnTabsAndTables.SatTime = vRowUsed("ExperienceDate");
        btnTabsAndTables.ExperienceNumber = vRowUsed("ExperienceNumber");
        btnTabsAndTables.NumberOfChecks = vRowUsed("NumberOfChecks");
        btnTabsAndTables.NumberOfCustomers = vRowUsed("NumberOfCustomers");
        btnTabsAndTables.CurrentMenu = vRowUsed("MenuID");
        btnTabsAndTables.EmpID = vRowUsed("EmployeeID");
        btnTabsAndTables.Size = new Size(w, h);
        btnTabsAndTables.Location = new Point(x, y);
        btnTabsAndTables.BackColor = c7;
        btnTabsAndTables.ForeColor = c3;
        btnTabsAndTables.IsGroup = isGroup;
        btnTabsAndTables.TableClicked += OpenTabsAndTables_Selected;

        pnlMainManager.Controls.Add(btnTabsAndTables);


    }



    private void btnMoreTickets_Click(object sender, EventArgs e)
    {
        pnlMainManager.Controls.Clear();

        if (displayingOpenOrClose == "Open")
        {
            mainPanelCounterIndex += 10;
            DisplayOpenTabsAndTables();
        }
        else if (displayingOpenOrClose == "Beths")
        {
            mainPanelCounterIndex += 10;
            DisplayGroupTabs();
        }
        else if (displayingOpenOrClose == "Closed")
        {
            skipClosedIndex += 10; // 40
            DisplayClosedTabsAndTables();
        }

    }

    private void btnLessTickets_Click(object sender, EventArgs e)
    {
        skipClosedIndex = 0;
        mainPanelCounterIndex = 0;
        pnlMainManager.Controls.Clear();
        if (displayingOpenOrClose == "Open")
        {
            DisplayOpenTabsAndTables();
        }
        else if (displayingOpenOrClose == "Beths")
        {
            DisplayGroupTabs();
        }
        else if (displayingOpenOrClose == "Closed")
        {
            DisplayClosedTabsAndTables();
        }

    }
    private void DisplayClosedTabsAndTables()
    {

        DataRowView vRow;
        float w;
        float h;
        int x = buttonSpace;
        int y = buttonSpace;
        int index = 1;
        int counterIndex = 1;
        // Dim serverTableDesc As String
        DateTime lsTime;

        TimeSpan timeAtTable;

        w = (pnlMainManager.Width - 6 * buttonSpace) / 5;
        h = (pnlMainManager.Height - 11 * buttonSpace) / 10;

        foreach (DataRowView currentVRow in dvClosedTables)
        {
            vRow = currentVRow;

            if (index > skipClosedIndex) // mainPanelCounterIndex  Then
            {
                // serverTableDesc = vRow("NickName") & " " & vRow("LastName")
                lsTime = vRow("LastStatusTime");
                // timeAtTable = DetermineTimeSpan(vRow("ExperienceDate"))
                CreateClosedTabsAndTablesButton(false, vRow, w, h, x, y, default, lsTime); // serverTableDesc, lsTime)

                if (counterIndex == 10)
                {
                    y = buttonSpace;
                    x += w + buttonSpace;
                    counterIndex = 0;    // must restart at zero b/c we add 1 right away
                }
                else
                {
                    y += h + buttonSpace;
                }
                counterIndex += 1;
            }

            index += 1;
        }


        foreach (DataRowView currentVRow1 in dvClosedTabs)
        {
            vRow = currentVRow1;
            if (index > skipClosedIndex) // mainPanelCounterIndex Then 
            {
                lsTime = vRow("LastStatusTime");

                CreateClosedTabsAndTablesButton(true, vRow, w, h, x, y, default, lsTime);

                if (counterIndex == 10)
                {
                    y = buttonSpace;
                    x += w + buttonSpace;
                    counterIndex = 0;    // must restart at zero b/c we add 1 right away
                }
                else
                {
                    y += h + buttonSpace;
                }
                counterIndex += 1;
            }

            index += 1;
        }


    }

    private void CreateClosedTabsAndTablesButton(bool isTabNotTable, DataRowView vRowUsed, float w, float h, float x, float y, string serverTableDesc, DateTime lsTime)
    {
        var tn = default(int);
        var tab = default(long);
        var btnClosedTabsAndTables = default(DataSet_Builder.AvailTableUserControl);
        string priceString = "";
        string nameString;
        string altMethodUse = "";

        if (!(dvTerminalsUseOrder[0]("MethodUse") == vRowUsed("MethodUse")))
        {
            altMethodUse = vRowUsed("MethodUse");
        }
        else
        {
            altMethodUse = "";
        }

        if (isTabNotTable == true)
        {
            tab = vRowUsed("TabID");
            if (!(vRowUsed("TicketNumber") == 0))
            {
                nameString = "Clsd " + vRowUsed("TicketNumber").ToString;
            }
            else
            {
                nameString = vRowUsed("TabName").ToString;
            }
        }
        else
        {
            tn = vRowUsed("TableNumber");
            nameString = vRowUsed("TabName").ToString;
        }

        if (!object.ReferenceEquals(vRowUsed("ClosedSubTotal"), DBNull.Value))
        {
            priceString = Strings.Format(vRowUsed("ClosedSubTotal"), "$ ##,###.00");
        }

        try
        {
            btnClosedTabsAndTables = new DataSet_Builder.AvailTableUserControl(isTabNotTable, tn, tab, nameString, vRowUsed("TicketNumber"), vRowUsed("LastStatus"), priceString, (object)null, (object)null, lsTime, 0, currentTerminal.TermMethod, altMethodUse);
        }

        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);
        }


        if (isTabNotTable == true)
        {
            btnClosedTabsAndTables.Text = vRowUsed("TabName");
            btnClosedTabsAndTables.TabID = tab;
        }
        else
        {
            btnClosedTabsAndTables.Text = vRowUsed("TableNumber");
            btnClosedTabsAndTables.TableNumber = tn;
        }
        btnClosedTabsAndTables.SatTime = vRowUsed("ExperienceDate");
        btnClosedTabsAndTables.ExperienceNumber = vRowUsed("ExperienceNumber");
        btnClosedTabsAndTables.NumberOfChecks = vRowUsed("NumberOfChecks");
        btnClosedTabsAndTables.NumberOfCustomers = vRowUsed("NumberOfCustomers");
        btnClosedTabsAndTables.CurrentMenu = vRowUsed("MenuID");
        btnClosedTabsAndTables.EmpID = vRowUsed("EmployeeID");
        btnClosedTabsAndTables.Size = new Size(w, h);
        btnClosedTabsAndTables.Location = new Point(x, y);
        btnClosedTabsAndTables.BackColor = c7;
        btnClosedTabsAndTables.ForeColor = c3;
        btnClosedTabsAndTables.TableClicked += ClosedTabsAndTables_Selected;

        pnlMainManager.Controls.Add(btnClosedTabsAndTables);

    }


    private void OpenTabsAndTables_Selected(object sender, EventArgs e)
    {

        var objButton = new DataSet_Builder.AvailTableUserControl();
        if (!object.ReferenceEquals(sender.GetType(), objButton.GetType))
            return;

        objButton = (DataSet_Builder.AvailTableUserControl)sender;

        // If objButton.TabID = -888 Then
        if (objButton.IsGroup == true)
        {
            // this is for Tab Group
            DisplayGroupTabs();
            return;
        }
        else
        {

            OpenOrderAdjustment?.Invoke(sender, e, closingDailyCode);
        }

    }

    private void ClosedTables_Click(object sender, EventArgs e) // Handles btnClosedTable.Click
    {

        displayingOpenOrClose = "Closed";
        // ***
        // we will change and allow to creopen a check if down
        // we just need to make a ClosedTablesTerminal data
        pnlMainManager.Controls.Clear();
        try
        {
            // ClearClosedTabsAndTables()
            // PopulateClosedTabsAndTables(currentTerminal.currentDailyCode)
            // 444        Me.pnlMoreTickets.Visible = True
            CreateClosedDataViews();
            // CreateAvailDataViews()
            DisplayClosedTabsAndTables();
        }
        catch (Exception ex)
        {
            CloseConnection();
            if (Information.Err().Number == Conversions.ToDouble("5"))
            {
                ServerJustWentDown();
            }
            Interaction.MsgBox("You can not reopen a check. The Server may be disconnected.");
        }

    }

    private void ClosedTabsAndTables_Selected(object sender, EventArgs e)
    {

        var objButton = new DataSet_Builder.AvailTableUserControl();
        if (!object.ReferenceEquals(sender.GetType(), objButton.GetType))
            return;

        objButton = (DataSet_Builder.AvailTableUserControl)sender;

        _reopenIndex = objButton.ExperienceNumber;
        if (objButton.CurrentStatus.Length > 0)    // length > 0 means closed
        {
            _reopenFlag = true;
        }

        OpenOrderAdjustment?.Invoke(sender, e, closingDailyCode);

    }

    internal void btnEmployees_Click(object sender, EventArgs e)
    {

        if (typeProgram == "Online_Demo")
        {
            DemoThisNotAvail();
            return;
        }

        ResetAllFlags();
        btnEmployees.BackColor = Color.FromArgb(59, 96, 141);
        // Me.btnEmployees.ForeColor = c3
        EmployeeFlag = true;


        pnlMainManager.Controls.Clear();
        if (employeeAuthorization.EmployeeLevel > 0)
        {
            DisplayLoggedInEmployees();
            PopulateLoggedInEmployees(false);
            grdEmpClockIn.DataSource = dsEmployee.Tables("LoggedInEmployees");
            lblNumClockedIn.Text = dsEmployee.Tables("LoggedInEmployees").Rows.Count;

            activeCollection = AllEmployees;
            DisplayFloorPersonnel(); // (AllEmployees)
        }
        else
        {
            Interaction.MsgBox(actingManager.FullName + " is not authorized for Employee changes.");
            return;
        }


    }

    private void DisplayLoggedInEmployees()
    {

        // this is taken from Opening Screen
        // we need to just have 1 dashboard with all this

        grpEmployeeClockIn = new System.Windows.Forms.GroupBox();
        lblNumClockedIn = new System.Windows.Forms.Label();
        grdEmpClockIn = new System.Windows.Forms.DataGrid();
        DataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
        DataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
        DataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
        DataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();

        // 
        // grpEmployeeClockIn
        // 
        grpEmployeeClockIn.BackColor = System.Drawing.Color.WhiteSmoke;
        grpEmployeeClockIn.Controls.Add(lblNumClockedIn);
        grpEmployeeClockIn.Controls.Add(grdEmpClockIn);
        grpEmployeeClockIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        grpEmployeeClockIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        grpEmployeeClockIn.ForeColor = System.Drawing.Color.MediumBlue;
        grpEmployeeClockIn.Location = new System.Drawing.Point(526, 16);
        grpEmployeeClockIn.Name = "grpEmployeeClockIn";
        grpEmployeeClockIn.Size = new System.Drawing.Size(254, 178);
        grpEmployeeClockIn.TabIndex = 6;
        grpEmployeeClockIn.TabStop = false;
        grpEmployeeClockIn.Text = "Employees Clocked-In";
        // 
        // grdEmpClockIn
        // 
        grdEmpClockIn.BackColor = System.Drawing.Color.WhiteSmoke;
        grdEmpClockIn.BackgroundColor = System.Drawing.Color.WhiteSmoke;
        grdEmpClockIn.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        grdEmpClockIn.CaptionText = "           Employees";
        grdEmpClockIn.CaptionVisible = false;
        grdEmpClockIn.ColumnHeadersVisible = false;
        grdEmpClockIn.DataMember = "";
        grdEmpClockIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        grdEmpClockIn.GridLineColor = System.Drawing.Color.WhiteSmoke;
        grdEmpClockIn.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        grdEmpClockIn.Location = new System.Drawing.Point(6, 41);
        grdEmpClockIn.Name = "grdEmpClockIn";
        grdEmpClockIn.RowHeadersVisible = false;
        grdEmpClockIn.Size = new System.Drawing.Size(242, 131);
        grdEmpClockIn.TabIndex = 1;
        grdEmpClockIn.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] { DataGridTableStyle1 });
        // 
        // lblNumClockedIn
        // 
        lblNumClockedIn.Location = new System.Drawing.Point(171, 18);
        lblNumClockedIn.Name = "lblNumClockedIn";
        lblNumClockedIn.Size = new System.Drawing.Size(56, 20);
        lblNumClockedIn.TabIndex = 2;
        lblNumClockedIn.Text = "#";
        lblNumClockedIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // DataGridTableStyle1
        // 
        DataGridTableStyle1.DataGrid = grdEmpClockIn;
        DataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] { DataGridTextBoxColumn1, DataGridTextBoxColumn2, DataGridTextBoxColumn3 });
        DataGridTableStyle1.GridLineColor = System.Drawing.SystemColors.Window;
        DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        DataGridTableStyle1.MappingName = "LoggedInEmployees";
        DataGridTableStyle1.ReadOnly = true;
        DataGridTableStyle1.RowHeadersVisible = false;
        // 
        // DataGridTextBoxColumn1
        // 
        DataGridTextBoxColumn1.Format = "";
        DataGridTextBoxColumn1.FormatInfo = (object)null;
        DataGridTextBoxColumn1.MappingName = "FirstName";
        DataGridTextBoxColumn1.NullText = " ";
        DataGridTextBoxColumn1.Width = 75;
        // 
        // DataGridTextBoxColumn2
        // 
        DataGridTextBoxColumn2.Format = "";
        DataGridTextBoxColumn2.FormatInfo = (object)null;
        DataGridTextBoxColumn2.MappingName = "LastName";
        DataGridTextBoxColumn2.NullText = " ";
        DataGridTextBoxColumn2.Width = 75;
        // 
        // DataGridTextBoxColumn3
        // 
        DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
        DataGridTextBoxColumn3.Format = "MM/dd";
        DataGridTextBoxColumn3.FormatInfo = (object)null;
        DataGridTextBoxColumn3.MappingName = "LogInTime";
        DataGridTextBoxColumn3.NullText = " ";
        DataGridTextBoxColumn3.Width = 50;
        pnlMainManager.Controls.Add(grpEmployeeClockIn);

    }

    private void DisplayEmployeeAdjustmentOptions222()
    {

        // we are currently go straight to emp Clock Adj
        // we may change to below if more choices become avail
        float w;
        float h;
        int x = buttonSpace;
        int y = buttonSpace;
        int index;
        int counterIndex = 1;

        w = (pnlMainManager.Width - 6 * buttonSpace) / 5;
        h = (pnlMainManager.Height - 11 * buttonSpace) / 10;

        mgrClockAdjustment = new Button();
        mgrClockAdjustment.Location = new Point(x, y);
        mgrClockAdjustment.Size = new Size(w, h);
        mgrClockAdjustment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

        mgrClockAdjustment.BackColor = c10;
        mgrClockAdjustment.ForeColor = c3;
        mgrClockAdjustment.Text = "Adjust Clock Time";

        y += h + buttonSpace;

        mgrTipAdjustment = new Button();
        mgrTipAdjustment.Location = new Point(x, y);
        mgrTipAdjustment.Size = new Size(w, h);
        mgrTipAdjustment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        mgrTipAdjustment.BackColor = c10;
        mgrTipAdjustment.ForeColor = c3;
        mgrTipAdjustment.Text = "Adjust Declared Tips";

        y += h + buttonSpace;

        mgrPayRateAdjustment = new Button();
        mgrPayRateAdjustment.Location = new Point(x, y);
        mgrPayRateAdjustment.Size = new Size(w, h);
        mgrPayRateAdjustment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        mgrPayRateAdjustment.BackColor = c10;
        mgrPayRateAdjustment.ForeColor = c3;
        mgrPayRateAdjustment.Text = "Adjust Pay Rate";

        y += h + buttonSpace;


        pnlMainManager.Controls.Add(mgrClockAdjustment);
        pnlMainManager.Controls.Add(mgrTipAdjustment);
        pnlMainManager.Controls.Add(mgrPayRateAdjustment);


    }

    internal void ClockAdjustment_Click(object sender, EventArgs e)
    {
        // MsgBox("Service Not Available")
        // Exit Sub

        dsEmployee.Tables("LoggedInEmployees").Clear();
        pnlMainManager.Controls.Clear();

        // *** need to relook at this entire Sub

        // ReformatManagerPanels()

        DateTime yesterdaysDate;

        // ********************
        // do for the last pay period
        yesterdaysDate = Conversions.ToDate(Strings.Format(DateTime.Today.AddDays(-14), "D"));

        // we want to display employees logged out for a particular time
        // want to do by employee
        sql.SqlSelectCommandCLockedInByEmp.Parameters("@CompanyID").Value = companyInfo.CompanyID;
        sql.SqlSelectCommandCLockedInByEmp.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlSelectCommandCLockedInByEmp.Parameters("@EmployeeID").Value = empActive.EmployeeID;
        sql.SqlSelectCommandCLockedInByEmp.Parameters("@LogInTime").Value = yesterdaysDate;

        try
        {
            // AddAutoSalariedEmployeesToCollection()
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlCLockedInByEmp.Fill(dsEmployee.Tables("LoggedInEmployees"));
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);

            Interaction.MsgBox("You can not adjust Clock Times when not connected to the server.");
        }


        employeeLog = new EmployeeLoggedInUserControl(true);
        employeeLog.Location = new Point((pnlMainManager.Width - employeeLog.Width) / 2, (pnlMainManager.Height - employeeLog.Height) / 2);
        pnlMainManager.Controls.Add(employeeLog);

    }

    private void EndAdjustEmployeeClock(object sender, EventArgs e)
    {

        employeeLog.Dispose();
        // usernameEnterOnLogin = True
        // DisplayMainManager()
        // btnEmployees_Click(sender, e)

    }

    private void TipAdjustment_Click(object sender, EventArgs e)
    {
        Interaction.MsgBox("Service Not Available");
        return;

    }
    private void PayRateAdjustment_Click(object sender, EventArgs e)
    {
        Interaction.MsgBox("Service Not Available");
        return;

    }

    private void ReformatManagerPanels()
    {

        pnlManagerSelection.Dispose();
        pnlMainManager.Location = new Point(32, 56);
        pnlMainManager.Size = new Size(712, 472);
        this.Invalidate();


    }

    private void btnReports_Click(object sender, EventArgs e)
    {

        if (employeeAuthorization.ReportLevel > 0)
        {
        }
        else
        {
            Interaction.MsgBox(actingManager.FullName + " is not authorized for Reports.");
            return;
        }

        // this is wrong
        // reports should be built in Manager_Main
        // we should not dispose of Maanager_Main
        actingManager = (object)null;
        empActive = (object)null;
        OpenReports?.Invoke();
        this.Dispose();
        return;

        ResetAllFlags();
        btnSystem.BackColor = Color.FromArgb(59, 96, 141);
        // Me.btnSystem.ForeColor = c3
        SystemFlag = true;

        pnlMainManager.Controls.Clear();

        if (employeeAuthorization.SystemLevel > 0)
        {
            DisplaySystemChoices();
        }
        else
        {
            Interaction.MsgBox(actingManager.FullName + " is not authorized for System changes.");
            return;
        }





    }


    // Private Sub DisposingSelf(ByVal sender As Object, ByVal e As System.EventArgs) Handles employeeLog.ClosedEmployeeLog
    // Me.pnlMainManager.Controls.Clear()
    // 
    // End Sub


    private void btnMgrExit_Click(object sender, EventArgs e)
    {

        // ExitManager()
        DisposeManager?.Invoke();

    }

    private void btnMenu_Click(object sender, EventArgs e)
    {
        ResetAllFlags();
        btnMenu.BackColor = Color.FromArgb(59, 96, 141);
        // Me.btnSystem.ForeColor = c3
        MenuFlag = true;

        pnlMainManager.Controls.Clear();

        if (employeeAuthorization.OperationLevel > 0)
        {
            DisplayMenuChoices();
        }
        else
        {
            Interaction.MsgBox(actingManager.FullName + " is not authorized for Menu changes.");
            return;
        }

    }

    private void DisplayMenuChoices()
    {
        pnlManagerSelection.Visible = false;
        pnlManagerSubSelecetion.Visible = true;

        RemoveTextFromSubButtons();
        SubButton1.Text = "ChangeMenu";
        SubButton2.Text = "Switch Menu";
        SubButton3.Text = "Reload Menu";
        // Me.SubButton4.Text = ""

    }

    private void btnSystem_Click(object sender, EventArgs e)
    {
        ResetAllFlags();
        btnSystem.BackColor = Color.FromArgb(59, 96, 141);
        SystemFlag = true;

        pnlMainManager.Controls.Clear();

        if (employeeAuthorization.SystemLevel > 0)
        {
            DisplaySystemChoices();
        }
        else
        {
            Interaction.MsgBox(actingManager.FullName + " is not authorized for System changes.");
            return;
        }

    }
    private void DisplaySystemChoices()
    {
        pnlManagerSelection.Visible = false;
        pnlManagerSubSelecetion.Visible = true;

        RemoveTextFromSubButtons();
        SubButton1.Text = "Override Table Status";
        SubButton2.Text = "Minimize"; // "Switch Menu"
        SubButton3.Text = "Activate Credit"; // "Reload Menu"

        DisplayConnectionButton();

    }

    private void DisplayConnectionButton()
    {
        if (connectserver == @"Phoenix\Phoenix")
        {
            SubButton4.Text = "Connection: DataCenter";   // & sql.connectServer
        }
        else
        {
            SubButton4.Text = "Connection: Local";
        }     // & sql.connectServer
    }

    private void DisplayMenuChoices222()
    {
        float w;
        float h;
        int x = buttonSpace;
        int y = buttonSpace;
        var index = default(int);
        int counterIndex = 1;
        KitchenButton menuChoice;

        w = (pnlMainManager.Width - 6 * buttonSpace) / 5;
        h = (pnlMainManager.Height - 11 * buttonSpace) / 10;

        if (primaryMenuSelected == false)
        {
            lblMainMgrInstructions.Text = "Choice Primary Menu";
        }
        else
        {
            lblMainMgrInstructions.Text = "Choice Secondary Menu";
        }

        foreach (DataRow oRow in ds.Tables("MenuChoice").Rows)
        {
            if (primaryMenuSelected == false)
            {
                if (oRow("MenuID") == currentTerminal.primaryMenuID)
                {
                    menuChoice = new KitchenButton(oRow("MenuName"), w, h, c9, c2);  // makes selected primary red
                }
                else
                {
                    menuChoice = new KitchenButton(oRow("MenuName"), w, h, c10, c2);
                }
            }
            else if (oRow("MenuID") == currentTerminal.secondaryMenuID)
            {
                menuChoice = new KitchenButton(oRow("MenuName"), w, h, c9, c2);  // makes selected secondary red
            }
            else
            {
                menuChoice = new KitchenButton(oRow("MenuName"), w, h, c10, c2);

            }

            menuChoice.Location = new Point(x, y);
            menuChoice.ID = oRow("MenuID");
            menuChoice.ButtonIndex = index;
            menuChoice.Click += MenuChoice_Click222;

            pnlMainManager.Controls.Add(menuChoice);

            if (counterIndex == 10)
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

    private void MenuChoice_Click222(object sender, EventArgs e) // Handles menuChoice.Click
    {

        var objButton = new KitchenButton("ForTesting", 0, 0, c3, c2);
        if (!object.ReferenceEquals(sender.GetType(), objButton.GetType))
            return;

        int newMenuChoice;

        objButton = (KitchenButton)sender;
        newMenuChoice = objButton.ID;

        if (primaryMenuSelected == true)
        {
            if (!(newMenuChoice == currentTerminal.secondaryMenuID))
            {
                currentTerminal.secondaryMenuID = newMenuChoice;
            }
            pnlManagerSelection.Visible = true;
            pnlManagerSubSelecetion.Visible = false;
            pnlMainManager.Controls.Clear();
            lblMainMgrInstructions.Text = "";
        }

        else
        {
            primaryMenuSelected = true;
            if (!(newMenuChoice == currentTerminal.primaryMenuID))
            {
                currentTerminal.primaryMenuID = newMenuChoice;
            }
            pnlMainManager.Controls.Clear();
            if (ds.Tables("MenuChoice").Rows.Count > 1)
            {
                DisplayMenuChoices222();        // now we will select secondary menu
            }
            else
            {
                currentTerminal.secondaryMenuID = newMenuChoice;
                pnlManagerSelection.Visible = true;
                pnlManagerSubSelecetion.Visible = false;
                lblMainMgrInstructions.Text = "";
            }
        }

    }

    private void SubButtonBack_Click(object sender, EventArgs e)
    {

        pnlManagerSelection.Visible = true;
        pnlManagerSubSelecetion.Visible = false;
        if (DailysFlag == true)
        {
            pnlMainManagerLarger.Controls.Clear();
            // Me.pnlMainManagerLarger.BackColor = Color.Black
            pnlMainManagerLarger.Controls.Add(pnlMainManager);
        }
        if (InventoryFlag == true)
        {
            if (!string.IsNullOrEmpty(InventoryTable))
            {
                SaveInventoryData();
                InventoryTable = "";
            }
        }

        pnlMainManager.Controls.Clear();
        lblMainMgrInstructions.Text = "";
        ResetSubButtonColors();

        if (availTableChangesMade == true)
        {
            UpdateAvailTablesData();
            availTableChangesMade = false;
        }

    }

    private void RemoveTextFromSubButtons()
    {
        // Me.SubButton1.Text = ""
        SubButton2.Text = "";
        SubButton3.Text = "";
        SubButton4.Text = "";
        subButton5.Text = "";

    }

    private void ResetSubButtonColors()
    {

        SubButton1.BackColor = Color.LightSlateGray;
        SubButton2.BackColor = Color.LightSlateGray;
        SubButton3.BackColor = Color.LightSlateGray;
        SubButton4.BackColor = Color.LightSlateGray;
        subButton5.BackColor = Color.LightSlateGray;

    }

    private void SubButton1_Click(object sender, EventArgs e)
    {
        if (InventoryFlag == false)
        {
            pnlMainManager.Controls.Clear();
        }
        ResetSubButtonColors();
        SubButton1.BackColor = Color.FromArgb(59, 96, 141);

        if (SystemFlag == true)
        {
            if (typeProgram == "Online_Demo")
            {
                DemoThisNotAvail();
                return;
            }

            OverrideTableStatus?.Invoke();
            this.Dispose();
        }
        // ResetAllFlags()
        // DisplaySeatingChart()
        else if (MenuFlag == true)
        {

            if (typeProgram == "Online_Demo")
            {
                DemoThisNotAvail();
                return;
            }

            if (employeeAuthorization.OperationLevel > 0)
            {
                Interaction.MsgBox("After Spider POS is Minimized, launch Backoffice.");
                this.ParentForm.WindowState = FormWindowState.Minimized;
            }
            else
            {
                Interaction.MsgBox(actingManager.FullName + " is not authorized for Operations.");
            }

            return;
            // 222 below
            DataSet_Builder.Info2_UC info;

            info = new DataSet_Builder.Info2_UC("Please wait while we connect to Datacenter...");
            info.Location = new Point((pnlMainManager.Width - info.Width) / 2, (pnlMainManager.Height - info.Height) / 2);
            pnlMainManager.Controls.Add(info);
            // info.BringToFront()
            info.ThisIsForDelay();

            if (employeeAuthorization.OperationLevel > 0)
            {
                Interaction.MsgBox(actingManager.FullName + " please launch Spider Backoffice from Desktop.");
                return;
                // old  Shell("""Q:\Tahsc_server.exe""")
                // Shell("""\\phoenix\eGlobalPartners\Tahsc_server.exe""")
                Interaction.Shell(@"""\\Phoenix\eglobalpartners\Backoffice Files\Spider Backoffice.application""");
            }
            // reduce screen size
            // System.Windows()
            else
            {
                Interaction.MsgBox(actingManager.FullName + " is not authorized for Operations.");
            }
        }


        else if (OperationFlag == true)
        {

            if (!(currentServer.EmployeeID > 0))
            {
                currentServer = actingManager;
            }

            OpenNewTable?.Invoke();
            this.Dispose();
        }

        else if (DailysFlag == true)
        {
            // weAreClosingDaily = True

            if (typeProgram == "Online_Demo")
            {
                DemoThisNotAvail();
                return;
            }

            if (employeeAuthorization.OperationLevel > 0 | employeeAuthorization.SystemLevel > 0)
            {
                DisplayDailyChoices();
            }
            else
            {
                Interaction.MsgBox(actingManager.FullName + " is not authorized for Operations.");
            }
        }

        else if (InventoryFlag == true)
        {

            if (string.IsNullOrEmpty(InventoryTable) | InventoryTable == "Physical")
            {
                if (!string.IsNullOrEmpty(InventoryTable))
                {
                    SaveInventoryData();
                }
                InventoryTable = "Delivery";
                pnlMainManager.Controls.Clear();
                invDelivery = new DataSet_Builder.InvDelivery_UC(companyInfo, currentTerminal, connectserver, typeProgram, actingManager.EmployeeID, "Delivery");
                invDelivery.Location = new Point((pnlMainManager.Width - invDelivery.Width) / 2, 50);
                pnlMainManager.Controls.Add(invDelivery);
            }

            else if (InventoryTable == "Cycle")
            {
                SaveInventoryData();
                InventoryTable = "Delivery";
                invDelivery.ChangeToThisType(InventoryTable);

            }



        }

    }

    private void SubButton2_Click(object sender, EventArgs e)
    {
        if (InventoryFlag == false)
        {
            pnlMainManager.Controls.Clear();
        }
        ResetSubButtonColors();
        SubButton2.BackColor = Color.FromArgb(59, 96, 141);

        if (OperationFlag == true)
        {

            if (!(currentServer.EmployeeID > 0))
            {
                currentServer = actingManager;
            }

            OpenNewTabEvent?.Invoke();
            this.Dispose();
        }

        else if (DailysFlag == true)
        {
            Interaction.MsgBox("You must first EXIT spiderPOS and reenter to open Daily or use current.");
            return;

            openDaily = new DataSet_Builder.MenuSelection_UC(ds.Tables("MenuChoice"), (object)null, (object)null);

            openDaily.Location = new Point((pnlMainManager.Width - openDaily.Width) / 2, 50);
            pnlMainManager.Controls.Add(openDaily);
        }
        // OpenNewDaily()

        else if (MenuFlag == true)
        {

            if (typeProgram == "Online_Demo")
            {
                DemoThisNotAvail();
                return;
            }

            if (currentTerminal.currentPrimaryMenuID == currentTerminal.primaryMenuID)
            {
                changeMenu = new DataSet_Builder.MenuSelection_UC(ds.Tables("MenuChoice"), currentTerminal.primaryMenuID, currentTerminal.secondaryMenuID);
            }
            else
            {
                changeMenu = new DataSet_Builder.MenuSelection_UC(ds.Tables("MenuChoice"), currentTerminal.secondaryMenuID, currentTerminal.primaryMenuID);
            }

            changeMenu.Location = new Point((pnlMainManager.Width - changeMenu.Width) / 2, 50);
            pnlMainManager.Controls.Add(changeMenu);
        }

        else if (SystemFlag == true)
        {

            if (typeProgram == "Online_Demo")
            {
                DemoThisNotAvail();
                return;
            }

            this.ParentForm.WindowState = FormWindowState.Minimized;
        }

        else if (InventoryFlag == true)
        {

            if (string.IsNullOrEmpty(InventoryTable) | InventoryTable == "Physical")
            {
                if (!string.IsNullOrEmpty(InventoryTable))
                {
                    SaveInventoryData();
                }
                InventoryTable = "Cycle";
                pnlMainManager.Controls.Clear();
                invDelivery = new DataSet_Builder.InvDelivery_UC(companyInfo, currentTerminal, connectserver, typeProgram, actingManager.EmployeeID, "Cycle");
                invDelivery.Location = new Point((pnlMainManager.Width - invDelivery.Width) / 2, 50);
                pnlMainManager.Controls.Add(invDelivery);
            }

            else if (InventoryTable == "Delivery")
            {
                SaveInventoryData();
                InventoryTable = "Cycle";
                invDelivery.ChangeToThisType(InventoryTable);

            }


        }

    }

    private void SubButton3_Click(object sender, EventArgs e)
    {
        if (InventoryFlag == false)
        {
            pnlMainManager.Controls.Clear();
        }
        ResetSubButtonColors();
        SubButton3.BackColor = Color.FromArgb(59, 96, 141);

        if (OperationFlag == true)
        {
            // cash out

            if (typeProgram == "Online_Demo")
            {
                DemoThisNotAvail();
                return;
            }

            expNum = new long();
            expNum = CreateNewExperience(actingManager.EmployeeID, default, -888, "Cash Out", 0, 10, default, 0, actingManager.LoginTrackingID);

            cashOut = new CashOut_UC(expNum, -3, 1000); // expnum, payTypeID, MaxCashOut
            cashOut.Location = new Point((pnlMainManager.Width - cashOut.Width) / 2, (pnlMainManager.Height - cashOut.Height) / 2);
            cashOut.lblCashOut.Text = "Cash Out";
            pnlMainManager.Controls.Add(cashOut);
        }

        else if (DailysFlag == true)
        {

            if (currentTerminal.HasCashDrawer == true)
            {

                if (typeProgram == "Online_Demo")
                {
                    DemoThisNotAvail();
                    return;
                }

                try
                {
                    if (employeeAuthorization.OperationLevel > 0 | employeeAuthorization.SystemLevel > 0)
                    {
                        DetermineOpenCashDrawer(currentTerminal.CurrentDailyCode);
                        {
                            var withBlock = dvTermsOpen;
                            withBlock.Table = dtTermsOpen;
                            withBlock.RowFilter = "TerminalsPrimaryKey = " + currentTerminal.TermPrimaryKey;
                        }
                        OpenCloseCashDrawer(0);  // 0 means this terminal only
                    }
                }

                catch (Exception ex)
                {
                    CloseConnection();
                    Interaction.MsgBox(ex.Message);
                }
            }


            // currentTerminal.TermPrimaryKey()

            // we need to allow managers to close out cash drawers from NON drawer terminals
            else if (employeeAuthorization.OperationLevel > 0 | employeeAuthorization.SystemLevel > 0)
            {
                OpenCloseCashDrawer(dtTerminalsMethod.Rows.Count);
            }
            else
            {
                Interaction.MsgBox("There is no Cash Drawer associated with this Terminal. Adjust in Setup.");
                return;

            }
        }

        else if (MenuFlag == true)
        {
            DataSet_Builder.Info2_UC info;
            bool menuReloadSuccess;

            if (typeProgram == "Online_Demo")
            {
                DemoThisNotAvail();
                return;
            }

            // trying for menu testing
            // companyInfo.usingDefaults = False
            // companyInfo.CompanyID = "brothe"
            // companyInfo.LocationID = "000025"

            menuReloadSuccess = PopulateMenu(false);

            if (menuReloadSuccess == true)
            {
                info = new DataSet_Builder.Info2_UC("Menu Reloaded");
                info.Location = new Point((pnlMainManager.Width - info.Width) / 2, (pnlMainManager.Height - info.Height) / 2);
                pnlMainManager.Controls.Add(info);
                info.BringToFront();
            }
        }

        else if (SystemFlag == true)
        {
            // ReRead Creedit Swipe
            ReReadCredit?.Invoke();
        }

        else if (InventoryFlag == true)
        {



        }

    }

    private void SubButton4_Click(object sender, EventArgs e)
    {
        if (InventoryFlag == false)
        {
            pnlMainManager.Controls.Clear();
        }
        ResetSubButtonColors();
        SubButton4.BackColor = Color.FromArgb(59, 96, 141);

        if (OperationFlag == true)
        {

            if (typeProgram == "Online_Demo")
            {
                DemoThisNotAvail();
                return;
            }

            if (employeeAuthorization.OperationLevel > 1)
            {
                StartCreditCardReturn();
            }
            else
            {
                Interaction.MsgBox(actingManager.FullName + " is not authorized for Credit Card Returns.");
            }
        }


        else if (DailysFlag == true)
        {
            if (typeProgram == "Demo" | typeProgram == "Online_Demo")
            {
                StartExit?.Invoke();
            }
            else if (Interaction.MsgBox("Are you sure you want to Exit spiderPOS ?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
            {
                StartExit?.Invoke();
            }
        }

        else if (MenuFlag == true)
        {
        }


        else if (SystemFlag == true)
        {

            if (typeProgram == "Online_Demo")
            {
                DemoThisNotAvail();
                return;
            }

            GenerateOrderTables.SwitchConnection();
            DisplayConnectionButton();
            Interaction.MsgBox("Connection Changed to: " + connectserver);
        }

        else if (InventoryFlag == true)
        {
            // Physical Inventory
            if (!string.IsNullOrEmpty(InventoryTable))
            {
                SaveInventoryData();
            }

            InventoryTable = "Physical";
            pnlMainManager.Controls.Clear();
            invPhysical = new DataSet_Builder.InvPhysical_UC(companyInfo, currentTerminal, connectserver, typeProgram, actingManager.EmployeeID);
            invPhysical.Location = new Point((pnlMainManager.Width - invPhysical.Width) / 2, 50);
            pnlMainManager.Controls.Add(invPhysical);
            // warnings
            // currently not avail
            // testing inv counting
            // GenerateOrderTables.StartDailyBusinessClose(actingManager.EmployeeID, currentTerminal.CurrentDailyCode)

        }

    }

    private void subButton5_Click(object sender, EventArgs e)
    {

        if (InventoryFlag == false)
        {
            pnlMainManager.Controls.Clear();
        }
        ResetSubButtonColors();
        subButton5.BackColor = Color.FromArgb(59, 96, 141);

        if (DailysFlag == true)
        {
            if (typeProgram == "Online_Demo")
            {
                DemoThisNotAvail();
                return;
            }

            if (employeeAuthorization.OperationLevel > 1)
            {
                if (companyInfo.CompanyID == "rasoi2")
                {

                    trainingDailys = new Training_UC();
                    trainingDailys.Location = new Point((pnlMainManager.Width - trainingDailys.Width) / 2, 100);
                    pnlMainManager.Controls.Add(trainingDailys);

                }
            }

            else
            {
                Interaction.MsgBox(actingManager.FullName + " is not authorized for Training Module.");
            }
        }

    }

    private void SaveInventoryData()
    {

        if (typeProgram == "Online_Demo")
        {
            return;
        }

        if (string.IsNullOrEmpty(InventoryTable))
        {
        }


        else if (InventoryTable == "Delivery")
        {
            invDelivery.UpdateDeliveryData();
        }

        else if (InventoryTable == "Cycle")
        {
            invDelivery.UpdateCycleData();
        }

        else if (InventoryTable == "Physical")
        {
            invPhysical.UpdateCycleData();

        }


    }

    private void OpenCloseCashDrawer(int _thisCashTerminal)
    {

        cashDrawer = new CashDrawer_UC(_thisCashTerminal);
        cashDrawer.Location = new Point((pnlMainManager.Width - cashDrawer.Width) / 2, (pnlMainManager.Height - cashDrawer.Height) / 2);
        pnlMainManager.Controls.Add(cashDrawer);

    }

    private void AcceptingCashOut(object sender, EventArgs e)
    {

        var newPayment = default(DataSet_Builder.Payment);
        decimal amount;

        if (cashOut.ItemPrice > 0)
        {
            amount = -1 * cashOut.ItemPrice;
            newPayment.Purchase = Strings.Format(amount, "##,##0.00");
            newPayment.PaymentTypeID = cashOut.PaymentTypeID;
            newPayment.PaymentTypeName = "Cash";   // "Enter Acct #"
            newPayment.Description = cashOut.ItemDescription;

            GenerateOrderTables.AddPaymentToDataRow(newPayment, true, expNum, actingManager.EmployeeID, 1, false);
            // we need this update here b/c we are not in any experience
            GenerateOrderTables.UpdatePaymentsAndCredits();
        }

        cashOut.Dispose();

    }

    internal void JustVoidedCheck(int tn)
    {

        _tableSelected = tn;
        try
        {
            ResetSeatingChartTableStatus(tn, false);  // false means to just adjust color 
        }
        catch (Exception ex)
        {
            // may fail if never created seating chart, just went right to mgmt screen
        }

    }

    private void btnDailys_Click(object sender, EventArgs e)
    {
        ResetAllFlags();
        btnDailys.BackColor = Color.FromArgb(59, 96, 141);
        // Me.btnDailys.ForeColor = c3
        DailysFlag = true;

        pnlMainManager.Controls.Clear();

        if (employeeAuthorization.OperationLevel > 0 | employeeAuthorization.SystemLevel > 0)
        {
            DisplayDailyButtons();
        }
        else
        {
            Interaction.MsgBox(actingManager.FullName + " is not authorized for Operations.");

        }
    }

    private void DisplayDailyButtons()
    {
        pnlManagerSelection.Visible = false;
        pnlManagerSubSelecetion.Visible = true;

        RemoveTextFromSubButtons();
        SubButton1.Text = "Close Current Daily";
        SubButton2.Text = "Open New Daily";
        SubButton3.Text = "Cash Drawer";
        SubButton4.Text = "Exit POS";
        subButton5.Text = "Training";

    }

    private void DisplayDailyChoices()
    {
        DataRow oRow;

        pnlMainManager.Controls.Clear();

        var dvOpenBusiness = new DataView();
        // GenerateOrderTables.DetermineOpenCashDrawer()

        // 999999

        GenerateOrderTables.DetermineOpenBusiness();

        if (dsOrder.Tables("OpenBusiness").Rows.Count > 1)
        {
            dvOpenBusiness.Table = dsOrder.Tables("OpenBusiness");

            selectDaily = new DataSet_Builder.SelectionPanel_UC();
            selectDaily.dvUsing = dvOpenBusiness;
            selectDaily.Location = new Point((pnlMainManager.Width - selectDaily.Width) / 2, (pnlMainManager.Height - selectDaily.Height) / 2);
            selectDaily.DetermineButtonSizes();
            selectDaily.DetermineButtonLocations();
            pnlMainManager.Controls.Add(selectDaily);
        }

        // currently not really using
        if (dsOrder.Tables("OpenBusiness").Rows.Count == 1)
        {
            if (dsOrder.Tables("OpenBusiness").Rows(0)("DailyCode") == currentTerminal.CurrentDailyCode)
            {
                closingDailyCode = currentTerminal.CurrentDailyCode;
                CloseSelectedDaily();
            }
            else
            {
                Interaction.MsgBox("Operating Daily Code Does Not Match Database Daily Code. Contact System Administrator");
                return;
            }
        }

    }

    private void CloseDailyBusinessSelected(object sender, EventArgs e)
    {

        closingDailyCode = Conversions.ToLong(sender.dailyCode);
        CloseSelectedDaily();

    }

    private void CloseSelectedDaily()
    {


        // *******
        // 666
        // just for testing
        // PopulatePaymentsAndCreditsByDaily(closingDailyCode)
        // RaiseEvent CloseBatchManagerForm(closingDailyCode)

        // Exit Sub

        try
        {
            DetermineOpenCashDrawer[closingDailyCode];
            PopulateLoggedInEmployees(false);
            DetermineIfOpenTables(closingDailyCode);
            CreateDataViews(currentServer.EmployeeID, false);

            CloseDailyRoutine();
        }
        catch (Exception ex)
        {
            CloseConnection();
        }

    }

    private object TestAbilityToCloseDaily()
    {

        if (allTicketsOpen + allCashDrawersOpen > 0)
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    private void btnClosingContinue_Click(object sender, EventArgs e)
    {

        if (numberOfAttemtsClosingDaily >= 2)
        {
            StartManagerReports(sender, e);
            ProceedToBatchClose();
        }
        else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(TestAbilityToCloseDaily(), false, false)))
        {
            Interaction.MsgBox("There are still open Tickets or Cash Drawers");
            numberOfAttemtsClosingDaily += 1;
        }
        else
        {
            // I tried many things to display a message to wait
            // they all come up too late ???
            // Dim info As DataSet_Builder.Info2_UC
            // info = New DataSet_Builder.Info2_UC("Running Closing Totals. This may take a few seconds.")
            // info.Location = New Point((pnlMainManager.Width - info.Width) / 2, (pnlMainManager.Height - info.Height) / 2)
            // Me.pnlMainManager.Controls.Add(info)
            // info.Visible = True
            // info.ChangeTextToThis("Running Closing Totals. This may take a few seconds.")
            // Me.pnlMainManager.Controls.Clear()
            // lblMgrDirectionsNumberPad.Text = "Running Closing Totals..."
            // lblMgrDirectionsNumberPad.Visible = True
            // Comic Sans MS
            // lblDailyCloseDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            // lblDailyCloseDesc.Text = "Running Closing Totals. This may take a few seconds."

            StartManagerReports(sender, e);
            ProceedToBatchClose();
        }

    }


    private void StartManagerReports(object sender, EventArgs e)
    {

        reportManager = new DataSet_Builder.Manager_Reports_UC(connectserver, companyInfo, currentTerminal, connectserver, typeProgram); // DataSet_Builder.Reports_EmployeeHours '
        // Me.Controls.Add(reportManager)
        reportManager.IsPrintMode = true;
        reportManager.PrintEntireHouseDailyDetails(sender, e);
        reportManager.Dispose();

    }



    private void CloseDailyRoutine()
    {

        allTicketsOpen = dvAvailTables.Count + dvAvailTabs.Count + dvQuickTickets.Count; // need to add quick
        allCashDrawersOpen = dsOrder.Tables("TermsOpen").Rows.Count;
        allEmployeesClockedIn = dsEmployee.Tables("LoggedInEmployees").Rows.Count;

        pnlCDInfo.Visible = true;
        btnCDTickets.Text = "Tickets: " + allTicketsOpen;
        btnCDCashDrawer.Text = "Cash Drawer: " + allCashDrawersOpen;
        btnCDClockedIn.Text = "ClockedIn: " + allEmployeesClockedIn;
        // testing only
        // allTicketsOpen = 0
        // allCashDrawersOpen = 0

        // If TestAbilityToCloseDaily() = True Then Me.pnlClosingDailyDirections.Visible = True
        pnlClosingDailyDirections.Visible = true;

        if (allTicketsOpen > 0)
        {
            // There are open Tables
            DisplayOpenTabsAndTables();
        }
        // DisplayInfoAboutOpenTables()
        // make sure above is not displaying transfered and quick
        // no open tickets 
        // we display open drawers
        else if (allCashDrawersOpen > 0)
        {

            OpenCloseCashDrawer(dtTerminalsMethod.Rows.Count); // not necessarily this terminal
        }


        else
        {
            lblDailyCloseDesc.Text = "Select Close Batch --->     This may take a few seconds.";

            // no open cash drawers
            if (allEmployeesClockedIn > 0)
            {
                employeeLog = new EmployeeLoggedInUserControl(false);
                employeeLog.Location = new Point((pnlMainManager.Width - employeeLog.Width) / 2, (pnlMainManager.Height - employeeLog.Height) / 2);
                pnlMainManager.Controls.Add(employeeLog);
            }

            else
            {
                var sender = default(object);
                var e = default(EventArgs);
                StartManagerReports(sender, e);
                ProceedToBatchClose();
            }
        }
    }

    private void ProceedToBatchClose()
    {

        allPaymentsLoaded = PopulatePaymentsAndCreditsByDaily[closingDailyCode];

        if (allPaymentsLoaded == true)
        {
            pnlClosingDailyDirections.Visible = false;
            CloseBatchManagerForm?.Invoke(closingDailyCode);
        }

    }

    internal void ReinitializeOpenTicketsFromForm(long weAreClosingDaily)
    {

        closingDailyCode = weAreClosingDaily;
        DailysFlag = true;
        CloseSelectedDaily();

    }

    internal void ReinitializeOpenCashDrawers(int termsOpen)
    {
        DetermineOpenCashDrawer[closingDailyCode];
        allCashDrawersOpen = dsOrder.Tables("TermsOpen").Rows.Count;
        btnCDCashDrawer.Text = "Cash Drawer: " + allCashDrawersOpen;

    }

    private void btnCDTickets_Click(object sender, EventArgs e)
    {
        pnlMainManager.Controls.Clear();

        if (allTicketsOpen > 0)
        {
            // There are open Tables
            DisplayOpenTabsAndTables();
            // DisplayInfoAboutOpenTables()
        }

    }

    private void btnCDCashDrawer_Click(object sender, EventArgs e)
    {
        pnlMainManager.Controls.Clear();

        // testing   OpenCloseCashDrawer(True) 

        if (allCashDrawersOpen > 0)
        {
            OpenCloseCashDrawer(dtTerminalsMethod.Rows.Count); // not necessarily this terminal
        }

    }

    private void btnCDClockedIn_Click(object sender, EventArgs e)
    {
        pnlMainManager.Controls.Clear();

        if (allEmployeesClockedIn > 0)
        {
            employeeLog = new EmployeeLoggedInUserControl(false);
            employeeLog.Location = new Point((pnlMainManager.Width - employeeLog.Width) / 2, (pnlMainManager.Height - employeeLog.Height) / 2);
            pnlMainManager.Controls.Add(employeeLog);
        }

    }



    private void DisplayInfoAboutOpenTables()
    {
        DataSet_Builder.Information_UC info;

        info = new DataSet_Builder.Information_UC("All displayed checks listed must be closed before Daily Close.");
        info.Location = new Point((this.Width - info.Width) / 2, (this.Height - info.Height) / 2);
        this.Controls.Add(info);
        info.BringToFront();

    }

    private void OpenNewDaily()
    {

        currentTerminal.primaryMenuID = openDaily.PMenuID;
        currentTerminal.secondaryMenuID = openDaily.SMenuID;

        openDaily.Dispose();
        GenerateOrderTables.StartNewDaily();
        // ExitManager()
        DisposeManager?.Invoke();

    }

    private void ChangeMenu_Click()
    {

        SwitchToSecondaryMenu();
        changeMenu.Dispose();
        DisposeManager?.Invoke();

    }

    private void OpenNewDailyAndSave()
    {
        currentTerminal.primaryMenuID = openDaily.PMenuID;
        currentTerminal.secondaryMenuID = openDaily.SMenuID;
        currentTerminal.initPrimaryMenuID = openDaily.PMenuID;
        currentTerminal.currentPrimaryMenuID = openDaily.PMenuID;

        openDaily.Dispose();
        GenerateOrderTables.StartNewDaily();
        DisposeManager?.Invoke();

        // 222


        // Dim adt As New SqlClient.SqlDataAdapter("SELECT MenuID, MenuName, LastOrder, AutoChange FROM MenuChoice WHERE Active = 1 AND LocationID = '" & companyInfo.LocationID & "' ORDER BY AutoChange DESC", sql.cn)
        // Dim cbd As New SqlClient.SqlCommandBuilder(adt)

        return;

        foreach (DataRow oRow in ds.Tables("MenuChoice").Rows)
        {
            if (oRow("MenuID") == currentTerminal.primaryMenuID)
            {
                oRow("LastOrder") = 1;
            }
            else if (oRow("MenuID") == currentTerminal.secondaryMenuID)
            {
                oRow("LastOrder") = 2;
            }
            else
            {
                oRow("LastOrder") = DBNull.Value;
            }
        }

        if (mainServerConnected == true)
        {
            sql.SqlDailyMenuChoice.Update(ds, "MenuChoice");
            ds.Tables("MenuChoice").AcceptChanges();
        }

        openDaily.Dispose();
        GenerateOrderTables.StartNewDaily();
        DisposeManager?.Invoke();

    }

    private void ChangeMenuAndSave_Click()
    {
        currentTerminal.primaryMenuID = changeMenu.PMenuID;
        currentTerminal.secondaryMenuID = changeMenu.SMenuID;
        // currentTerminal.CurrentMenuID = primaryMenuID

        changeMenu.Dispose();
        // 222


        // Dim adt As New SqlClient.SqlDataAdapter("SELECT MenuID, MenuName, LastOrder FROM MenuChoice", sql.cn)
        // Dim cbd As New SqlClient.SqlCommandBuilder(adt)

        return;

        foreach (DataRow oRow in ds.Tables("MenuChoice").Rows)
        {
            if (oRow("MenuID") == currentTerminal.primaryMenuID)
            {
                oRow("LastOrder") = 1;
            }
            else if (oRow("MenuID") == currentTerminal.secondaryMenuID)
            {
                oRow("LastOrder") = 2;
            }
            else
            {
                oRow("LastOrder") = DBNull.Value;
            }
        }

        if (mainServerConnected == true)
        {
            sql.SqlDailyMenuChoice.Update(ds, "MenuChoice");
            ds.Tables("MenuChoice").AcceptChanges();
        }

        changeMenu.Dispose();

    }


    private void StartCreditCardReturn()
    {

        returnCredit = new ReturnCredit_UC();
        returnCredit.Location = new Point((pnlMainManager.Width - returnCredit.Width) / 2, (pnlMainManager.Height - returnCredit.Height) / 2);
        pnlMainManager.Controls.Add(returnCredit);

    }

    // Private Sub ExitManager()

    // actingManager = Nothing
    // empActive = Nothing
    // Me.Parent.Dispose()
    // End Sub

    private void PopulateOpenTabsAndTables222()
    {
        dsOrder.Tables("AvailTables").Clear();
        dsOrder.Tables("AvailTabs").Clear();

        sql.cn.Open();
        sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();

        // sql.SqlSelectCommandAvailTablesSP.Parameters("@CompanyID").Value = CompanyID
        sql.SqlSelectCommandAvailTablesSP.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlSelectCommandAvailTablesSP.Parameters("@EmployeeID").Value = empActive;
        sql.SqlSelectCommandAvailTablesSP.Parameters("@DailyCode").Value = currentTerminal.CurrentDailyCode;
        sql.SqlAvailTablesSP.Fill(dsOrder.Tables("AvailTables"));
        // sql.SqlSelectCommandAvailTabsSP.Parameters("@CompanyID").Value = CompanyID
        sql.SqlSelectCommandAvailTabsSP.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlSelectCommandAvailTabsSP.Parameters("@DailyCode").Value = currentTerminal.CurrentDailyCode;
        sql.SqlSelectCommandAvailTabsSP.Parameters("@EmployeeID").Value = empActive;
        sql.SqlAvailTabsSP.Fill(dsOrder.Tables("AvailTabs"));

        sql.cn.Close();

    }







    private void lblCurrentServer_Click(object sender, EventArgs e)
    {

        pnlMainManager.Controls.Clear();

        if (displayingOpenOrClose == "Open")
        {
            mainPanelCounterIndex += 10;
            DisplayOpenTabsAndTables();
        }
        else if (displayingOpenOrClose == "Beths")
        {
            mainPanelCounterIndex += 10;
            DisplayGroupTabs();
        }
        else if (displayingOpenOrClose == "Closed")
        {
            skipClosedIndex += 10; // 40
            DisplayClosedTabsAndTables();
        }

    }

}