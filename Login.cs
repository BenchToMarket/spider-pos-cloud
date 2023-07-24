using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using DataSet_Builder;
using ReadCredit_MWE;

public partial class Login : System.Windows.Forms.Form
{

    // Dim sql As New DataSet_Builder.SQLHelper(connectserver)
    private Timer updateClockTimerLogin = new DateAndTime.Timer();

    private string sqlStatement;
    private string tableCreating;

    private Menu currentMenu;
    private Menu secondaryMenu;
    private ReadCredit _readAuth;

    internal virtual ReadCredit readAuth
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _readAuth;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_readAuth != null)
            {
                _readAuth.CardReadFailed -= CardRead_Failed;
                _readAuth.CardReadSuccessful -= NewCardRead;
                _readAuth.ManagementCardSwiped -= ManagementCardRead;
                _readAuth.EnteringTabNameInKeyboard -= EnterTabNameFromSwipe;
                _readAuth.RetruningGiftAddingAmountToFalse -= ReturnGiftCardAddToFalseEvent;
            }

            _readAuth = value;
            if (_readAuth != null)
            {
                _readAuth.CardReadFailed += CardRead_Failed;
                _readAuth.CardReadSuccessful += NewCardRead;
                _readAuth.ManagementCardSwiped += ManagementCardRead;
                _readAuth.EnteringTabNameInKeyboard += EnterTabNameFromSwipe;
                _readAuth.RetruningGiftAddingAmountToFalse += ReturnGiftCardAddToFalseEvent;
            }
        }
    }

    // 444   Friend WithEvents readAuth_MWE As ReadCredit_MWE2.MainForm_MWE


    private OpeningScreen _openProgram;

    private OpeningScreen openProgram
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _openProgram;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_openProgram != null)
            {
                _openProgram.OpeningScreenClosing -= OpenScreenClosed;
                _openProgram.RestaurantOpening -= RemoveOpenButtonTest;
                _openProgram.RestuarantOpen -= RemoveOpenButton;
                _openProgram.ClosePOS -= ClosePOS2;
            }

            _openProgram = value;
            if (_openProgram != null)
            {
                _openProgram.OpeningScreenClosing += OpenScreenClosed;
                _openProgram.RestaurantOpening += RemoveOpenButtonTest;
                _openProgram.RestuarantOpen += RemoveOpenButton;
                _openProgram.ClosePOS += ClosePOS2;
            }
        }
    }
    private Tables_Screen_Bar _tableScreen;

    private Tables_Screen_Bar tableScreen
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tableScreen;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tableScreen != null)
            {
                _tableScreen.FireSeatingChart -= FiringSeatingChart;
                _tableScreen.FireSeatingTab -= FiringSeatingTab;
                _tableScreen.ManagementButton -= LoginManager;
                _tableScreen.FireOrderScreen -= OrderScreen;
                _tableScreen.QuickTicketStart -= GotoQuickTicket;
                _tableScreen.ExitingTableScreen -= ClosingTableScreen;
            }

            _tableScreen = value;
            if (_tableScreen != null)
            {
                _tableScreen.FireSeatingChart += FiringSeatingChart;
                _tableScreen.FireSeatingTab += FiringSeatingTab;
                _tableScreen.ManagementButton += LoginManager;
                _tableScreen.FireOrderScreen += OrderScreen;
                _tableScreen.QuickTicketStart += GotoQuickTicket;
                _tableScreen.ExitingTableScreen += ClosingTableScreen;
            }
        }
    }
    private term_OrderForm _activeOrder;

    private term_OrderForm activeOrder
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _activeOrder;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_activeOrder != null)
            {
                _activeOrder.FireTabScreen -= FiringTabScreen;
                _activeOrder.FireSeatingTab -= FiringSeatingTab;
                _activeOrder.TestForCurrentTabInfo -= TestForCurrentTabInfo;
                _activeOrder.TabScreenDisposing -= ClosedTabScreen;
                _activeOrder.TermOrder_Disposing -= UpdatingTableData;
                _activeOrder.ClosingCheck -= StartCloseScreen;
                _activeOrder.CloseFastCash -= ClosingFastCash;
            }

            _activeOrder = value;
            if (_activeOrder != null)
            {
                _activeOrder.FireTabScreen += FiringTabScreen;
                _activeOrder.FireSeatingTab += FiringSeatingTab;
                _activeOrder.TestForCurrentTabInfo += TestForCurrentTabInfo;
                _activeOrder.TabScreenDisposing += ClosedTabScreen;
                _activeOrder.TermOrder_Disposing += UpdatingTableData;
                _activeOrder.ClosingCheck += StartCloseScreen;
                _activeOrder.CloseFastCash += ClosingFastCash;
            }
        }
    }
    private SplitChecks _activeSplit;

    private SplitChecks activeSplit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _activeSplit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_activeSplit != null)
            {
                _activeSplit.FireTabScreen -= FiringTabScreen;
                _activeSplit.SendOrder -= ForceSendOrder;
                _activeSplit.ManagerClosing -= EndClosingCheck;
                _activeSplit.SplitCheckClosing -= SplitCheckClosed;
                _activeSplit.MakeGiftAddingAmountTrue -= MakingGiftAddingAmountTrue;
                _activeSplit.MerchantAuthPayment -= AuthTHisPayment;
            }

            _activeSplit = value;
            if (_activeSplit != null)
            {
                _activeSplit.FireTabScreen += FiringTabScreen;
                _activeSplit.SendOrder += ForceSendOrder;
                _activeSplit.ManagerClosing += EndClosingCheck;
                _activeSplit.SplitCheckClosing += SplitCheckClosed;
                _activeSplit.MakeGiftAddingAmountTrue += MakingGiftAddingAmountTrue;
                _activeSplit.MerchantAuthPayment += AuthTHisPayment;
            }
        }
    }
    private SplitChecks mgrActiveSplit;
    private Manager_Form _managementScreen;

    private Manager_Form managementScreen
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _managementScreen;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_managementScreen != null)
            {
                _managementScreen.FireSeatingChart -= FiringSeatingChart;
                _managementScreen.FireSeatingTab -= FiringSeatingTab;
                _managementScreen.OverrideTableStatus -= FiringOverrideSeatingChart;
                _managementScreen.FireOrderScreen -= MgrOrderScreen;
                _managementScreen.DisposingOfManager -= ExitManager;
                _managementScreen.MgrClosingCheck -= StartCloseScreenFromManager;
                _managementScreen.ReReadCredit -= ReReadCredit_Click;
                _managementScreen.ClosePOS -= ClosePOS;
            }

            _managementScreen = value;
            if (_managementScreen != null)
            {
                _managementScreen.FireSeatingChart += FiringSeatingChart;
                _managementScreen.FireSeatingTab += FiringSeatingTab;
                _managementScreen.OverrideTableStatus += FiringOverrideSeatingChart;
                _managementScreen.FireOrderScreen += MgrOrderScreen;
                _managementScreen.DisposingOfManager += ExitManager;
                _managementScreen.MgrClosingCheck += StartCloseScreenFromManager;
                _managementScreen.ReReadCredit += ReReadCredit_Click;
                _managementScreen.ClosePOS += ClosePOS;
            }
        }
    }
    private term_OrderForm _QuickOrder;

    private term_OrderForm QuickOrder
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _QuickOrder;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_QuickOrder != null)
            {
                _QuickOrder.FireTabScreen -= FiringTabScreen;
                _QuickOrder.FireSeatingTab -= FiringSeatingTab;
                _QuickOrder.TestForCurrentTabInfo -= TestForCurrentTabInfo;
                _QuickOrder.TabScreenDisposing -= ClosedTabScreen;
                _QuickOrder.ClosingCheck -= StartQuickCloseScreen;
                _QuickOrder.TermOrder_Disposing -= LeavingQuickServer;
                _QuickOrder.QuickOrder_NotDisposing -= NextQuickServer;
                _QuickOrder.CloseFastCash -= ClosingFastCash;
            }

            _QuickOrder = value;
            if (_QuickOrder != null)
            {
                _QuickOrder.FireTabScreen += FiringTabScreen;
                _QuickOrder.FireSeatingTab += FiringSeatingTab;
                _QuickOrder.TestForCurrentTabInfo += TestForCurrentTabInfo;
                _QuickOrder.TabScreenDisposing += ClosedTabScreen;
                _QuickOrder.ClosingCheck += StartQuickCloseScreen;
                _QuickOrder.TermOrder_Disposing += LeavingQuickServer;
                _QuickOrder.QuickOrder_NotDisposing += NextQuickServer;
                _QuickOrder.CloseFastCash += ClosingFastCash;
            }
        }
    }
    private Seating_ChooseTable _SeatingChart;

    private Seating_ChooseTable SeatingChart
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SeatingChart;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SeatingChart != null)
            {
                _SeatingChart.NoTableSelected -= CancelNewTable;
                _SeatingChart.NumberCustomerEvent -= NewAddNewTable;
            }

            _SeatingChart = value;
            if (_SeatingChart != null)
            {
                _SeatingChart.NoTableSelected += CancelNewTable;
                _SeatingChart.NumberCustomerEvent += NewAddNewTable;
            }
        }
    }
    private ConnectionDown_UC _connectionDown;

    private ConnectionDown_UC connectionDown
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _connectionDown;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_connectionDown != null)
            {
                _connectionDown.ConnectionHelpCanceled -= CanceledConnectionHelp;
                _connectionDown.ArchiveMenuLoaded -= OldMenuLoaded;
            }

            _connectionDown = value;
            if (_connectionDown != null)
            {
                _connectionDown.ConnectionHelpCanceled += CanceledConnectionHelp;
                _connectionDown.ArchiveMenuLoaded += OldMenuLoaded;
            }
        }
    }
    private Seating_EnterTab _SeatingTab;

    private Seating_EnterTab SeatingTab
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SeatingTab;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SeatingTab != null)
            {
                _SeatingTab.OpenNewTabEvent -= NewAddNewTab;
                _SeatingTab.OpenNewTakeOutTab -= NewAddNewTakeOutTab;
                _SeatingTab.CancelNewTab -= CancelNewTab;
            }

            _SeatingTab = value;
            if (_SeatingTab != null)
            {
                _SeatingTab.OpenNewTabEvent += NewAddNewTab;
                _SeatingTab.OpenNewTakeOutTab += NewAddNewTakeOutTab;
                _SeatingTab.CancelNewTab += CancelNewTab;
            }
        }
    }
    private Tab_Screen _DeliveryScreen;

    private Tab_Screen DeliveryScreen
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _DeliveryScreen;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_DeliveryScreen != null)
            {
                _DeliveryScreen.SelectedReOrder -= TabReorderButtonSelected;
                _DeliveryScreen.SelectedNewOrder -= TabNewOrderButtonSelected;
                _DeliveryScreen.ChangedMethodUse -= UpdateTableInfo;
                _DeliveryScreen.TabScreenDisposing -= ClosedTabScreen;
            }

            _DeliveryScreen = value;
            if (_DeliveryScreen != null)
            {
                _DeliveryScreen.SelectedReOrder += TabReorderButtonSelected;
                _DeliveryScreen.SelectedNewOrder += TabNewOrderButtonSelected;
                _DeliveryScreen.ChangedMethodUse += UpdateTableInfo;
                _DeliveryScreen.TabScreenDisposing += ClosedTabScreen;
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
                _ClockingOutEmployee.ClockOutComplete -= clockingOutComplete;
                _ClockingOutEmployee.ClockOutCancel -= clockingOutComplete;
            }

            _ClockingOutEmployee = value;
            if (_ClockingOutEmployee != null)
            {
                _ClockingOutEmployee.ClockOutComplete += clockingOutComplete;
                _ClockingOutEmployee.ClockOutCancel += clockingOutComplete;
            }
        }
    }
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
                _openInfo.AcceptInformation -= QSClockOutAccept;
                _openInfo.RejectInformation -= QSClockOutReject;
            }

            _openInfo = value;
            if (_openInfo != null)
            {
                _openInfo.AcceptInformation += QSClockOutAccept;
                _openInfo.RejectInformation += QSClockOutReject;
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
            _cashDrawer = value;
        }
    }
    private KeyBoard_UC expOverride;
    private bool expOverriding = false;

    // Dim WithEvents numCustPad As DataSet_Builder.NumberOfCustomers_UC

    // Dim titleHeader As New DataSet_Builder.TitleUserControl

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
                _clockInPanel.ClosingClockIn -= ClosedClockInUserControl;
                _clockInPanel.ApplyClockInCheck -= ClockInEmployeeClicked;
            }

            _clockInPanel = value;
            if (_clockInPanel != null)
            {
                _clockInPanel.ClosingClockIn += ClosedClockInUserControl;
                _clockInPanel.ApplyClockInCheck += ClockInEmployeeClicked;
            }
        }
    }

    private DataSet_Builder.Information_UC infoReconnect;
    private Timer infoRecoTimer;
    private ClockOut_UC nonServerClockout;
    private bool clockOutActiveQS;

    private string _loginUsername;
    private string _loginPassword;
    private DataSet_Builder.NumberPad _loginPad;

    private DataSet_Builder.NumberPad loginPad
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _loginPad;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_loginPad != null)
            {
                _loginPad.NumberEntered -= Login_Entered;
            }

            _loginPad = value;
            if (_loginPad != null)
            {
                _loginPad.NumberEntered += Login_Entered;
            }
        }
    }
    private DataSet_Builder.LoginInit_UC _initLogon;

    private DataSet_Builder.LoginInit_UC initLogon    // NumberPad
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _initLogon;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_initLogon != null)
            {
                _initLogon.SummitLogin -= TestInitLogon;
            }

            _initLogon = value;
            if (_initLogon != null)
            {
                _initLogon.SummitLogin += TestInitLogon;
            }
        }
    }



    #region  Windows Form Designer generated code 

    // / <summary>
    // / The main entry point for the application.
    // / </summary>
    [STAThread()]
    public static void Main()
    {
        Application.Run(new Login());
    }

    public Login() : base()
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        InitializeOther();
        base.Click += ReceiveFocus;
        base.Load += Swiped__Encrypted__Load_MWE;
        mgrActiveSplit.FireTabScreen += FiringTabScreen;
        expOverride.Enter += ExpOverrideResult;

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
    private Global.System.Windows.Forms.Label _lblClockInDay;

    internal virtual Global.System.Windows.Forms.Label lblClockInDay
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblClockInDay;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblClockInDay = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblClockInDate;

    internal virtual Global.System.Windows.Forms.Label lblClockInDate
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblClockInDate;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblClockInDate = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblClockInTime;

    internal virtual Global.System.Windows.Forms.Label lblClockInTime
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblClockInTime;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblClockInTime = value;
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

    private Global.System.Windows.Forms.Button _btnClockIn;

    internal virtual Global.System.Windows.Forms.Button btnClockIn
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnClockIn;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnClockIn != null)
            {
                _btnClockIn.Click -= btnClockIn_Click;
            }

            _btnClockIn = value;
            if (_btnClockIn != null)
            {
                _btnClockIn.Click += btnClockIn_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _pnlTimeInfo;

    internal virtual Global.System.Windows.Forms.Panel pnlTimeInfo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlTimeInfo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlTimeInfo = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlLogin;

    internal virtual Global.System.Windows.Forms.Panel pnlLogin
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlLogin;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pnlLogin != null)
            {
                _pnlLogin.Click -= ReceiveFocus;
            }

            _pnlLogin = value;
            if (_pnlLogin != null)
            {
                _pnlLogin.Click += ReceiveFocus;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblLogin;

    internal virtual Global.System.Windows.Forms.Label lblLogin
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblLogin;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblLogin = value;
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

    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _btnClockIn = new System.Windows.Forms.Button();
        _btnClockIn.Click += btnClockIn_Click;
        _pnlTimeInfo = new System.Windows.Forms.Panel();
        _lblClockInDay = new System.Windows.Forms.Label();
        _lblClockInDate = new System.Windows.Forms.Label();
        _lblClockInTime = new System.Windows.Forms.Label();
        _Button1 = new System.Windows.Forms.Button();
        _Button1.Click += Button1_Click;
        _pnlLogin = new System.Windows.Forms.Panel();
        _pnlLogin.Click += ReceiveFocus;
        _btnClockOut = new System.Windows.Forms.Button();
        _btnClockOut.Click += btnClockOut_Click;
        _lblLogin = new System.Windows.Forms.Label();
        _pnlTimeInfo.SuspendLayout();
        _pnlLogin.SuspendLayout();
        this.SuspendLayout();
        // 
        // btnClockIn
        // 
        _btnClockIn.Anchor = (Global.System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
        _btnClockIn.BackColor = System.Drawing.Color.LightSlateGray;
        _btnClockIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnClockIn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _btnClockIn.Location = new System.Drawing.Point(648, 488);
        _btnClockIn.Name = "_btnClockIn";
        _btnClockIn.Size = new System.Drawing.Size(128, 64);
        _btnClockIn.TabIndex = 2;
        _btnClockIn.TabStop = false;
        _btnClockIn.Text = "CLOCK IN";
        _btnClockIn.UseVisualStyleBackColor = false;
        _btnClockIn.Visible = false;
        // 
        // pnlTimeInfo
        // 
        _pnlTimeInfo.Controls.Add(_lblClockInDay);
        _pnlTimeInfo.Controls.Add(_lblClockInDate);
        _pnlTimeInfo.Controls.Add(_lblClockInTime);
        _pnlTimeInfo.ForeColor = System.Drawing.Color.CornflowerBlue;
        _pnlTimeInfo.Location = new System.Drawing.Point(16, 104);
        _pnlTimeInfo.Name = "_pnlTimeInfo";
        _pnlTimeInfo.Size = new System.Drawing.Size(256, 200);
        _pnlTimeInfo.TabIndex = 7;
        // 
        // lblClockInDay
        // 
        _lblClockInDay.Anchor = (Global.System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);

        _lblClockInDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblClockInDay.ForeColor = System.Drawing.Color.DodgerBlue;
        _lblClockInDay.Location = new System.Drawing.Point(32, 24);
        _lblClockInDay.Name = "_lblClockInDay";
        _lblClockInDay.Size = new System.Drawing.Size(208, 40);
        _lblClockInDay.TabIndex = 1;
        _lblClockInDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblClockInDate
        // 
        _lblClockInDate.Anchor = (Global.System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);

        _lblClockInDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblClockInDate.ForeColor = System.Drawing.Color.DodgerBlue;
        _lblClockInDate.Location = new System.Drawing.Point(32, 72);
        _lblClockInDate.Name = "_lblClockInDate";
        _lblClockInDate.Size = new System.Drawing.Size(208, 40);
        _lblClockInDate.TabIndex = 2;
        _lblClockInDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblClockInTime
        // 
        _lblClockInTime.Anchor = (Global.System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);

        _lblClockInTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblClockInTime.ForeColor = System.Drawing.Color.DodgerBlue;
        _lblClockInTime.Location = new System.Drawing.Point(32, 120);
        _lblClockInTime.Name = "_lblClockInTime";
        _lblClockInTime.Size = new System.Drawing.Size(208, 48);
        _lblClockInTime.TabIndex = 3;
        _lblClockInTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Button1
        // 
        _Button1.Location = new System.Drawing.Point(16, 328);
        _Button1.Name = "_Button1";
        _Button1.Size = new System.Drawing.Size(112, 40);
        _Button1.TabIndex = 6;
        _Button1.TabStop = false;
        _Button1.Text = "Bypass Login";
        _Button1.Visible = false;
        // 
        // pnlLogin
        // 
        _pnlLogin.BackColor = System.Drawing.Color.Black;
        _pnlLogin.Controls.Add(_btnClockOut);
        _pnlLogin.Controls.Add(_lblLogin);
        _pnlLogin.Controls.Add(_btnClockIn);
        _pnlLogin.Controls.Add(_pnlTimeInfo);
        _pnlLogin.Controls.Add(_Button1);
        _pnlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
        _pnlLogin.Location = new System.Drawing.Point(0, 0);
        _pnlLogin.Name = "_pnlLogin";
        _pnlLogin.Size = new System.Drawing.Size(800, 573);
        _pnlLogin.TabIndex = 9;
        // 
        // btnClockOut
        // 
        _btnClockOut.Anchor = (Global.System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
        _btnClockOut.BackColor = System.Drawing.Color.LightSlateGray;
        _btnClockOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnClockOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _btnClockOut.Location = new System.Drawing.Point(648, 400);
        _btnClockOut.Name = "_btnClockOut";
        _btnClockOut.Size = new System.Drawing.Size(128, 64);
        _btnClockOut.TabIndex = 10;
        _btnClockOut.TabStop = false;
        _btnClockOut.Text = "CLOCK OUT";
        _btnClockOut.UseVisualStyleBackColor = false;
        _btnClockOut.Visible = false;
        // 
        // lblLogin
        // 
        _lblLogin.Dock = System.Windows.Forms.DockStyle.Top;
        _lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _lblLogin.Location = new System.Drawing.Point(0, 0);
        _lblLogin.Name = "_lblLogin";
        _lblLogin.Size = new System.Drawing.Size(800, 56);
        _lblLogin.TabIndex = 9;
        _lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Login
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.Color.Black;
        this.ClientSize = new System.Drawing.Size(800, 573);
        this.Controls.Add(_pnlLogin);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "Login";
        this.Text = "Login";
        this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        _pnlTimeInfo.ResumeLayout(false);
        _pnlLogin.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion


    private void InitializeOther()
    {

        AdjustSystemColors();
        if (!(typeProgram == "Online_Demo"))
        {
            StartUsernameDiscovery();
        }
        else
        {
            _loginUsername = "eGlobal";
            _loginPassword = "1111";
        }

        // Me.ClientSize = New Size(ssX, ssY)

        // orderInactiveTimer = New Timer
        loginPad = new NumberPad();
        loginPad.Location = new Point((ssX - loginPad.Width) / 2, (ssY - loginPad.Height) / 2 + 40);
        // lblLogin.Text = "Enter Login"
        pnlLogin.Controls.Add(loginPad);

        MakeLoginPadVisibleNOT();
        // loginPad.Visible = False


        // titleHeader.Location = New Point((Me.pnlT.Width - titleHeader.Width) / 2, (Me.pnlTitle.Height - titleHeader.Height) / 2)
        // Me.titleHeader.BackColor = Me.pnlTitle.BackColor
        // Me.pnlTitle.Controls.Add(titleHeader)


        // this is where we will add all automatic clock-in employees to collection??


        this.pnlLogin.Click -= this.ReceiveFocus;
        // RemoveHandler Me.btnClockIn.Click, AddressOf btnClockIn_Click

        this.updateClockTimerLogin.Tick += UpdateClock;
        updateClockTimerLogin.Interval = 60000;
        updateClockTimerLogin.Start();

        int daysBeforeExpiration;

        daysBeforeExpiration = (int)DateDiff(DateInterval.Day, DateTime.Now, dateOfExpiration);
        if (daysBeforeExpiration < 0)
        {
            expOverriding = true;
            loginPad.Visible = true;
            return;
        }
        else if (daysBeforeExpiration < 14)
        {
            Interaction.MsgBox("Your subscription will expire in " + daysBeforeExpiration + " days.");
        }

        DisplayInitialLogon();


    }

    private void StartUsernameDiscovery()
    {

        pointToServer = DetermineIfServer();

        if (pointToServer == false)        // ourservername = Nothing Then
        {
            ReadTextLinesFromFile();
        }
        else
        {
            ReadTextLinesFromServer();
        }

    }

    private object DetermineIfServer()
    {

        int n;
        char c;
        string tempComputerName;

        tempComputerName = System.Windows.Forms.SystemInformation.ComputerName;

        var loopTo = tempComputerName.Length - 1;
        for (n = 0; n <= loopTo; n++)
        {
            c = tempComputerName[n];
            if (Conversions.ToString(c) == "_")
            {
                // If tempComputerName.Chars(n + 1) = "_" Then
                // now we know this is a client machine
                ourServerName = tempComputerName.Substring(0, n);
                return true;
                // End If
            }
        }

        // ourServerName = "kaistudiobk"
        // Return True

        ourServerName = tempComputerName.Substring(0, n);
        return false;

    }


    public void ReadTextLinesFromFile()
    {
        // "\\workstation\javatools\somefile.txt"

        string oneLine;
        int lineCount = 1;
        int i;

        try
        {
            // Dim file As New System.IO.StreamReader("\\Phoenix\NETLOGON\login.txt")
            var file = new StreamReader(@"c:\Data Files\SpiderPOS\login.txt");
            // file = New System.IO.StreamReader("c:\Data Files\SpiderPOS\login.txt")

            do
            {
                oneLine = file.ReadLine();
                if (lineCount == 1)
                {
                    _loginUsername = oneLine;
                    lineCount = 2;
                }
                else if (lineCount == 2)
                {
                    _loginPassword = oneLine;
                    lineCount = 3;
                    // oneLine = ""
                }
            }
            while (!(oneLine is null));
            file.Close();
        }

        catch (Exception ex)
        {
            // file.Close()
            // MsgBox(ex.Message)
        }


    }

    public void ReadTextLinesFromServer()
    {
        // "\\workstation\javatools\somefile.txt"

        string oneLine;
        int lineCount = 1;
        int i;

        try
        {
            // Dim file As New System.IO.StreamReader("\\" & ourServerName & "\NETLOGON\login.txt")
            var file = new StreamReader(@"\\" + ourServerName + @"\Data Files\SpiderPOS\login.txt");
            // file = New System.IO.StreamReader("c:\Data Files\SpiderPOS\login.txt")
            do
            {
                oneLine = file.ReadLine();
                if (lineCount == 1)
                {
                    _loginUsername = oneLine;
                    lineCount = 2;
                }
                else if (lineCount == 2)
                {
                    _loginPassword = oneLine;
                    lineCount = 3;
                    // oneLine = ""
                }
            }
            while (!(oneLine is null));
            file.Close();
        }

        catch (Exception ex)
        {
            // file.Close()
            // MsgBox(ex.Message)
        }

    }


    private void AdjustSystemColors()
    {

        // If SystemInformation.ComputerName = "VAIO" Then
        // c4 = Color.SlateBlue
        // c6 = Color.SlateBlue
        // ' End If

    }

    internal void DisplayInitialLogon()
    {

        if (companyInfo.locationUsername == default)
        {
            initLogon = new DataSet_Builder.LoginInit_UC();   // NumberPad
            initLogon.Location = new Point((ssX - initLogon.Width) / 2, (ssY - initLogon.Height) / 2);
            initLogon.InputUSERinfo(_loginUsername, _loginPassword);

            this.Controls.Add(initLogon);
            initLogon.BringToFront();
            initLogon.Focus();
        }
        else
        {

            InitialLogIn(companyInfo.locationUsername, companyInfo.locationPassword);

        }

    }

    private void TestInitLogon()
    {
        string loginEnterUsername;
        string loginEnterPassword;


        loginEnterUsername = initLogon.LoginUsername;
        loginEnterPassword = initLogon.LoginPassword;

        InitialLogIn(loginEnterUsername, loginEnterPassword);


        // ***************    ?????????????
        // we must have all salaried personnel add to working employees
        // we must change test below to see if first employee (now it is workingemployees.count = 0)
        // if first employee is not salaried we must auto login

    }

    private void QSClockOutAccept(object sender, EventArgs e)
    {

        StartClockOut(currentServer, false);
        MakeClockOutBooleanFalse();
        loginPad.btnNumberClear_Click();
        pnlLogin.Visible = false;
        MakeLoginPadVisibleNOT();

    }

    private void QSClockOutReject(object sender, EventArgs e)
    {

        MakeClockOutBooleanFalse();
        loginPad.btnNumberClear_Click();
        pnlLogin.Visible = true;
        MakeLoginPadVisible();

    }
    private void Login_Entered(object sender, EventArgs e)
    {

        if (expOverriding == true)
        {
            if (loginPad.NumberString == "27315")
            {
                dateOfExpiration = "01/01/2099";
                expOverriding = false;

                DisplayInitialLogon();
            }
            else
            {
                this.Dispose();
            }
        }

        else
        {
            string loginEnter;
            loginEnter = loginPad.NumberString;
            LoginRoutine(loginEnter);
        }


    }

    private void LoginRoutine(string loginEnter)
    {

        int isClockedIn;
        bool doesEmpNeedToClockOut;
        DataSet_Builder.Employee emp;

        emp = GenerateOrderTables.TestUsernamePassword(loginEnter, clockOutActiveQS); // False)

        if (emp is not null)
        {
            if (clockOutActiveQS == true)
            {
                bool yesOpenTables;
                if (loginEnter.Length < 8)
                {
                    Interaction.MsgBox("Enter both EmployeeID as Passcode");
                    return;
                }
                doesEmpNeedToClockOut = TestClockOut(loginEnter);
                if (doesEmpNeedToClockOut == false)
                {
                    MakeClockOutBooleanFalse();
                    loginPad.btnNumberClear_Click();
                    Interaction.MsgBox(emp.FullName + " does not need to Clock Out");
                    return;
                }

                // check to see if there are any open tables           **********************
                yesOpenTables = GenerateOrderTables.AnyOpenTables(emp);
                if (currentServer is null)
                {
                    currentServer = new Employee();
                }
                if (currentClockEmp is null)
                {
                    currentClockEmp = new Employee();
                }
                currentServer = emp;
                currentClockEmp = emp;

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
                    StartClockOut(emp, false);
                }

                MakeClockOutBooleanFalse();

                loginPad.btnNumberClear_Click();
                pnlLogin.Visible = false;
                MakeLoginPadVisibleNOT();
                // loginPad.Visible = False
                return;
            }

            try
            {
                isClockedIn = ActuallyLogIn(emp);
                if (isClockedIn == -999)
                {
                    // this means connection down but is a Salaried employee
                    Interaction.MsgBox("Connection Error. Only a Manager may Login");
                    LoginMgrAfterConnectFail(ref emp);
                    return;
                }
            }
            catch (Exception ex)
            {
                CloseConnection();
                Interaction.MsgBox("Connection Error. Only a Manager may Login");
                LoginMgrAfterConnectFail(ref emp);
                return;
            }

            if (isClockedIn == 0)
            {
                // 444       MsgBox(emp.FullName & " is not clocked in. Please Clock in after open Spider POS.")
                if (currentServer is null)
                {
                    currentServer = new Employee();
                }
                currentServer = emp;
                AttemptingToClockIn(loginEnter);
                return;
            }

            else if (isClockedIn == 1)
            {
                // 222   LoginEmployee(emp)
                PerformEmployeeFunctions(emp);
            }
            else
            {
                Interaction.MsgBox("Employee Is Clocked in more than once. Please See Manager.");
            }
        }

        loginPad.btnNumberClear_Click();
        pnlLogin.Visible = false;
        MakeLoginPadVisibleNOT();
        // MakeClockOutBooleanFalse()

    }

    private void LoginMgrAfterConnectFail(ref DataSet_Builder.Employee emp)
    {

        foreach (DataSet_Builder.Employee emp2 in AllEmployees)
        {
            if (emp2.EmployeeID == emp.EmployeeID)
            {
                if (emp2.SystemMgmtAll == true | emp2.SystemMgmtLimited == true | emp2.OperationMgmtAll == true)
                {
                    managementScreen = new Manager_Form(emp2, true);  // emp, usernameEntered?
                    managementScreen.Location = new Point(0, 0);
                    this.Controls.Add(managementScreen);
                    managementScreen.BringToFront();
                    readAuth.ActiveScreen = "Manager";

                    loginPad.btnNumberClear_Click();
                    pnlLogin.Visible = false;
                    MakeLoginPadVisibleNOT();
                    // loginPad.Visible = False
                    // PerformEmployeeFunctions(emp2)
                    return;
                }
            }
        }

        Interaction.MsgBox("Connection Error. Only a Manager may Login");

    }

    private void StartOfProgram(string empName)
    {

        GenerateOverrideCodes(); // for now not pulling from database

        try
        {
            FillLocalTablesStartOfProgram();
        }
        catch (Exception ex)
        {
            // this means local server down
            CloseConnection();
            // MsgBox(ex.Message)
            if (Interaction.MsgBox("Local Server Down. Attempt to Reset. Otherwise Select YES and Connect to DataCenter.", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
            {
                localConnectServer = @"Phoenix\Phoenix";
                connectserver = localConnectServer;
                RestateConnectionString(sql.cn, connectserver);
                try
                {
                    FillLocalTablesStartOfProgram();
                }
                catch (Exception ex2)
                {
                    CloseConnection();
                    Interaction.MsgBox("Local And Datacenter connection down. Call Spider POS (404) 869-4700");
                    return;
                }
            }
            else
            {
                this.Dispose();
            }
        }

        // 3 lines below is temp 999
        // CreateTerminals()
        // DisplayOpeningScreen(empName)
        // Exit Sub

        // we are kind of repeating downloading some of this
        // mostly because we need terminal data here
        if (mainServerConnected == true)
        {
            if (PopulateMenu(true) == true)
            {
                // we get this info ONLY from phoenix
                currentTerminal.menuLoadedDate = DateTime.Now;

                tablesFilled = true;
                DisplayOpeningScreen(empName);
            }
            else
            {
                Interaction.MsgBox("Connection Down, Populating Menu. Select saved menu.");
                ServerNOTConectedStartOfProgram();
                // not sure       PopulateAllEmployeeColloection()
            }
        }
        else
        {
            GenerateOrderTables.CreateTerminals();
            PopulateAllEmployeeColloection();
            tablesFilled = true;
            DisplayOpeningScreen(empName);
        }

        VerifyTerminals();

    }

    private void VerifyTerminals()
    {

        if (companyInfo.LocationID == "000002" | companyInfo.LocationID == "000022" | companyInfo.LocationID == "000023" | companyInfo.LocationID == "000024" | companyInfo.LocationID == "000026" | companyInfo.LocationID == "000027" | companyInfo.LocationID == "000029" | companyInfo.LocationID == "000081")
        {
            return;
        }
        // for placing encrypted info to db
        // Dim tempadd As String
        // Dim tempAddResult As String
        // tempadd = "000BAB19CCDF" 'wrong one:"00FF68FDCC89" 'change to address we are adding
        // tempAddResult = CryOutloud.Encrypt(tempadd, "test")
        // MsgBox(tempAddResult)

        bool terminalVerified = false;
        System.Net.NetworkInformation.NetworkInterface[] theNetworkInterfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();

        if (currentTerminal.PhyAdd.Length > 0) // And Not currentTerminal.PhyAdd Is Nothing Then
        {
            try
            {
                currentTerminal.PhyAdd = CryOutloud.Decrypt(currentTerminal.PhyAdd, "test");
                if (currentTerminal.PhyAdd.Length == 0)
                {
                    // means they tried to use another address
                    // but will fail here and Catch
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                // means they tried to use another address
                this.Dispose();
                terminalVerified = false;
            }
        }

        if (!(companyInfo.CompanyID == "rasoi2")) // And Not System.Windows.Forms.SystemInformation.ComputerName = "EGLOBALMAIN" Then 'And Not companyInfo.CompanyID = "001111" Then 'currentTerminal.PhyAdd = "0000" Then 'this was a null VALUE
        {
            terminalVerified = true;
        }
        else
        {
            try
            {
                foreach (System.Net.NetworkInformation.NetworkInterface currentInterface in theNetworkInterfaces)
                {
                    if (currentInterface.GetPhysicalAddress().ToString() == currentTerminal.PhyAdd)
                    {
                        terminalVerified = true;
                        break;
                    }
                    // MessageBox.Show(currentInterface.GetPhysicalAddress().ToString())
                }
            }
            catch (Exception ex)
            {
                terminalVerified = false;
            }

        }

        if (System.Windows.Forms.SystemInformation.ComputerName == "EGLOBALMAIN")
        {
            terminalVerified = true;
        }
        if (terminalVerified == false)
        {
            // MsgBox("Could not verify this software is licenced to this computer. Please reBoot your computer.")
            this.Dispose();
        }
        // Return terminalVerified
    }

    private void FillLocalTablesStartOfProgram()
    {

        sql.cn.Open();
        sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
        PopulateOrderTables(true); // (tableNumber)
        PopulateAllTablesWithStatus(true);       // "AllTables"
        InitializeSeatingChart();
        InitializeTabScreen();
        PopulateLoggedInEmployees(true);
        // PopulateEmployeeData() 'this is done locally and phoenix
        // this is done in PopulateMenu
        sql.cn.Close();

    }

    private void StartOfProgram222(string empName)
    {

        // currentTerminal = New Terminal

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            PopulateOrderTables(true); // (tableNumber)
            PopulateAllTablesWithStatus(true);       // "AllTables"
            PopulateLoggedInEmployees(true);
            PopulateEmployeeData();

            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }

        // **********************************
        // start of filling ds
        // we get this info ONLY from phoenix
        // **********************************

        try
        {
            if (mainServerConnected == true)
            {
                GenerateOrderTables.TempConnectToPhoenix();
                sql.cn.Open();
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                PopulateMenuSupport();
                PopulateNONOrderTables();
                PopulateTerminalData();               // FloorPlan
                sql.cn.Close();
                GenerateOrderTables.ConnectBackFromTempDatabase();
            }

            GenerateOrderTables.CreateTerminals();
            tablesFilled = true;

            PopulateAllEmployeeColloection();
        }

        catch (Exception ex)
        {
            // nned to reload all Info stored on Phoenix from XML
            CloseConnection();
            GenerateOrderTables.ConnectBackFromTempDatabase();
            // openProgram = New OpeningScreen(Nothing)
            // 222
            ServerNOTConectedStartOfProgram();
            try
            {
                // LoadStarterDataSet()
                PopulateAllEmployeeColloection();
            }
            catch (Exception ex2)
            {
                Interaction.MsgBox(ex2.Message, (MsgBoxStyle)Conversions.ToInteger("   Can't load Starter Menu. Call spiderPOS at 404.869.4700"));
            }
            return;
        }

        // SetUpPrimaryKeys()
        // Formats TabsAndTables 
        InitializeSeatingChart();
        DisplayOpeningScreen(empName);

    }

    private object CreateMenuString222(int mc, ref string menuName)
    {

        foreach (DataRow oRow in ds.Tables("MenuChoice").Rows)
        {
            if (oRow("MenuID") == mc)
            {
                menuName = menuName + oRow("MenuName");
            }
        }

        return default;

        // Return menuName

    }


    private void PopulateOpenTablesAtStartup222()
    {
        // currently not using
        // this is to create a list of open tables that should be closed

        // dsOrder.Tables("OpenTables").Clear()
        // dsOrder.Tables("OpenTabs").Clear()

        DateTime yesterdaysDate;
        DateTime todaysDate;
        DataRow oRow;
        long firstExpNum;


        yesterdaysDate = Conversions.ToDate(Strings.Format(DateTime.Today.AddDays(-888), "D"));
        // todaysDate = Format(Today.AddDays(-1), "D")


        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            // this is to check for any tables tabs left open from previous day   ???
            // we do not do this by batch because we want all previous batches
            // sql.SqlSelectCommandOpenTables.Parameters("@CompanyID").Value = CompanyID
            // sql222.SqlSelectCommandOpenTables.Parameters("@LocationID").Value = companyInfo.LocationID
            // sql222.SqlSelectCommandOpenTables.Parameters("@DailyCode").Value = currentTerminal.CurrentDailyCode
            // sql.SqlDataAdapterOpenTables.Fill(dsOrder.Tables("OpenTables"))

            // sql.SqlSelectCommandOpenTabs.Parameters("@CompanyID").Value = CompanyID
            // sql222.SqlSelectCommandOpenTabs.Parameters("@LocationID").Value = companyInfo.LocationID
            // sql222.SqlSelectCommandOpenTabs.Parameters("@DailyCode").Value = currentTerminal.CurrentDailyCode
            // sql.SqlDataAdapterOpenTabs.Fill(dsOrder.Tables("OpenTabs"))



            // Backup

            // sql.SqlSelectCommandAvailTablesTerminal.Parameters("@CompanyID").Value = CompanyID
            // sql.SqlSelectCommandAvailTablesTerminal.Parameters("@LocationID").Value = LocationID
            // sql.SqlSelectCommandAvailTablesTerminal.Parameters("@TerminalID").Value = currentTerminal.TermID
            // sql.SqlSelectCommandAvailTablesTerminal.Parameters("@DailyCode").Value = currentTerminal.currentDailyCode
            // sql.SqlDataAdapterAvailTablesTerminal.Fill(dsBackup.Tables("AvailTablesTerminal"))

            // sql.SqlSelectCommandAvailTabsTerminal.Parameters("@CompanyID").Value = CompanyID
            // sql.SqlSelectCommandAvailTabsTerminal.Parameters("@LocationID").Value = LocationID
            // sql.SqlSelectCommandAvailTabsTerminal.Parameters("@TerminalID").Value = currentTerminal.TermID
            // '        sql.SqlSelectCommandAvailTabsTerminal.Parameters("@DailyCode").Value = currentTerminal.currentDailyCode
            // sql.SqlDataAdapterAvailTabsTerminal.Fill(dsBackup.Tables("AvailTabsTerminal"))

            // ********************
            // Opne Orders and Payments


            // sql.SqlSelectCommandOOTerminal.Parameters("@DailyCode").Value = currentTerminal.currentDailyCode
            // sql.SqlSelectCommandOOTerminal.Parameters("@CompanyID").Value = CompanyID
            // sql.SqlSelectCommandOOTerminal.Parameters("@LocationID").Value = LocationID
            // sql.SqlDataAdapterOOTerminal.Fill(dsBackup.Tables("OpenOrdersTerminal"))
            // 
            // sql.SqlSelectCommandPaymentsTerminal.Parameters("@DailyCode").Value = currentTerminal.currentDailyCode
            // sql.SqlSelectCommandPaymentsTerminal.Parameters("@CompanyID").Value = CompanyID
            // sql.SqlSelectCommandPaymentsTerminal.Parameters("@LocationID").Value = LocationID
            // sql.SqlSelectCommandPaymentsTerminal.Parameters("@TerminalID").Value = currentTerminal.TermID
            // sql.SqlDataAdapterPaymentsTerminal.Fill(dsBackup.Tables("PaymentsAndCreditsTerminal"))
            // End If



            // *** I don;t think this should be by Terminal    ???
            // sql.SqlSelectCommandESCTerminal.Parameters("@CompanyID").Value = CompanyID
            // sql.SqlSelectCommandESCTerminal.Parameters("@LocationID").Value = LocationID
            // sql.SqlSelectCommandESCTerminal.Parameters("@TerminalID").Value = currentTerminal.TermID
            // sql.SqlSelectCommandESCTerminal.Parameters("@DailyCode").Value = currentTerminal.currentDailyCode
            // sql.SqlDataAdapterESCTerminal.Fill(dsBackup.Tables("ESCTerminal"))

            // Employee
            // sql.SqlSelectCommandEmployeeTerminal.Parameters("@CompanyID").Value = CompanyID
            // sql.SqlSelectCommandEmployeeTerminal.Parameters("@LocationID").Value = LocationID
            // sql.SqlDataAdapterEmployeeTerminal.Fill(dsBackup.Tables("EmployeeTerminal"))

            // ClockedId  / LoggedIn


            sql.cn.Close();
        }

        catch (Exception ex)
        {
            CloseConnection();

        }

    }

    private void DailyClosed(Employee emp)
    {

        InitializeOpeningScreen();
        DisplayOpeningScreen(emp.FullName);

    }


    private void InitializeOpeningScreen()
    {

        openProgram = new OpeningScreen(companyInfo.companyName);
        openProgram.Location = new Point(0, 0);
        this.Controls.Add(openProgram);
        openProgram.Hide();

    }

    private void DisplayOpeningScreen(string empName)
    {

        PopulateManagementSwipeCollection();
        // we must do this here because Login is where we define ReadAuth_MWE

        // *********************
        // Go to Opening Screen only if the first terminal 

        openProgram.Show();
        openProgram.BringToFront();
        openProgram.UpdateOpeningInfo();

        this.pnlLogin.Click -= this.ReceiveFocus;

    }

    private void PopulateManagementSwipeCollection()
    {

        // Dim swipeEmployee As New ReadCredit_MWE.Employee_MWE
        var tempDT = new DataTable();

        if (dsEmployee.Tables("AllEmployees").Rows.Count > 0)
        {
            tempDT = dsEmployee.Tables("AllEmployees");
        }
        else
        {
            tempDT = dsStarter.Tables("StarterAllEmployees");
        }

        if (tempDT is null)
        {
            return;
        }

        if (companyInfo.processor == "MerchantWare")
        {
            // 444      readAuth_MWE.SwipeCodeEmployees_MWE.Clear()
            foreach (DataRow oRow in tempDT.Rows)
            {
                if (!object.ReferenceEquals(oRow("SwipeCode"), DBNull.Value))
                {
                    // this means there is a swipe code for this employee
                    // swipeEmployee = New Employee_MWE
                    foreach (Employee oldEmployee in AllEmployees)
                    {
                        if (oldEmployee.EmployeeID == oRow("EmployeeID"))
                        {
                            // id is the primary Key
                            // 444       readAuth_MWE.AddEmployeeToSwipeCodeEmployeesEmployeeCollectionMWE(oRow("EmployeeNumber"), oRow("SwipeCode"), oRow("Passcode")) 'swipeEmployee)
                        }
                    }
                }
            }
        }

    }

    private void OpenScreenClosed()
    {

        SetDateTime();

        return;
        // 222

        // Me.Show()

        SetDateTime();
        openProgram.Dispose();

    }

    private void DisplayCurrentLoggedInEmployees()
    {
        // not here

    }

    private void PopulateEmployeeCollectionWithLoggedIn()
    {


    }

    private void UpdateClock(object sender, EventArgs e)
    {
        SetDateTime();
        TestForShiftAndMenuChanges();

    }


    private void TestForShiftAndMenuChanges()
    {

        // shift codes
        DataRow sRow;
        if (ds.Tables("ShiftCodes").Rows.Count > 0)
        {
            if (!(ds.Tables("ShiftCodes").Rows(0)("ShiftID") == currentTerminal.CurrentShift))
            {
                // 2 things
                // 1. we stop from changing after midnight
                // 2. we skip if its the last shift of the day
                foreach (DataRow currentSRow in ds.Tables("ShiftCodes").Rows)
                {
                    sRow = currentSRow;
                    if (DateAndTime.TimeOfDay.Hour > sRow("TimeStart").hour)
                    {
                        currentTerminal.CurrentShift = sRow("ShiftID");
                        break;
                    }
                    else if (sRow("TimeStart").hour == DateAndTime.TimeOfDay.Hour)
                    {
                        if (DateAndTime.TimeOfDay.Minute > sRow("TimeStart").minute)
                        {
                            currentTerminal.CurrentShift = sRow("ShiftID");
                            break;
                        }
                    }
                }
            }
        }

        // menu aut change
        if (ds.Tables("MenuChoice").Rows.Count > 0)
        {
            foreach (DataRow currentSRow1 in ds.Tables("MenuChoice").Rows)
            {
                sRow = currentSRow1;
                if (!object.ReferenceEquals(sRow("AutoChange"), DBNull.Value))
                {
                    if (sRow("LastOrder") == 2)
                    {
                        // we only test the latter menu, so we never change to previous automatically
                        if (sRow("MenuID") == currentTerminal.currentPrimaryMenuID)   // currentTerminal.CurrentMenuID Then
                        {
                            break;
                        }

                        else if (DateAndTime.TimeOfDay.Hour > sRow("AutoChange").hour)
                        {
                            SwitchToSecondaryMenu();
                            // secondaryMenuID = primaryMenuID
                            // primaryMenuID = sRow("MenuID")
                            // we need to change in OpenBusiness
                            break;
                        }
                        else if (sRow("AutoChange").hour == DateAndTime.TimeOfDay.Hour)
                        {
                            if (DateAndTime.TimeOfDay.Minute > sRow("AutoChange").minute)
                            {
                                SwitchToSecondaryMenu();
                                // secondaryMenuID = primaryMenuID
                                // primaryMenuID = sRow("MenuID")
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    public void AssignStatus222(int tableNumber, int ss, DateTime st)
    {
        var newTable = new PhysicalTable();

        newTable.PhysicalTableNumber = tableNumber;
        newTable.CurrentStatus = ss;
        newTable.CurrentStatusTime = st;

        currentPhysicalTables.Add(newTable);

    }

    private void ReceiveFocus(object sender, EventArgs e)
    {

        DisplayLoginScreen();
        SetDateTime();
        if (currentTerminal.CurrentDailyCode == 0)
        {
            InitializeOpeningScreen();
            DisplayOpeningScreen(companyInfo.companyName);
        }

    }

    private void DisplayLoginScreen()
    {

        MakeLoginPadVisible();
        pnlLogin.Visible = true;

        if (currentTerminal.CurrentDailyCode > 0)
        {
        }
        // update terminal

        else
        {

        }


    }

    private void MakeLoginPadVisible()
    {
        lblLogin.Visible = true;
        if (currentTerminal.TermMethod == "Quick")
        {
        }
        btnClockOut.Visible = true;
        btnClockIn.Visible = true;
        loginPad.Visible = true;
    }

    private void MakeLoginPadVisibleNOT()
    {
        lblLogin.Visible = false;
        btnClockOut.Visible = false;
        btnClockIn.Visible = false;
        loginPad.Visible = false;
        // Me.pnlLogin.Controls.Add(Me.pnlTimeInfo)
        Button1.Visible = false;

    }







    // ***************************************
    // 
    // 
    // ***************************************


    private void InitializeTabScreen()
    {

        DeliveryScreen = new Tab_Screen();
        DeliveryScreen.Location = new Point(50, 50); // ((Me.Width - DeliveryScreen.Width - 10) / 2), ((Me.Height - DeliveryScreen.Height) / 2))
        this.Controls.Add(DeliveryScreen);
        DeliveryScreen.Visible = false;

    }

    private void FiringTabScreen(string startInSearch, string searchCriteria)
    {
        try
        {
            if (DeliveryScreen is null)
            {
                InitializeTabScreen();
            }
        }
        catch (Exception ex)
        {
            InitializeTabScreen();
        }
        finally
        {
            // make visible
            // If startInSearch = "Account" Then
            // DeliveryScreen.SearchAccount(searchCriteria)
            // ElseIf startInSearch = "Phone" Then
            // DeliveryScreen.SearchPhone(searchCriteria)
            // ElseIf startInSearch = "TabID" Then
            // DeliveryScreen.SearchTabID(searchCriteria)
            // End If

            // If currentTable.TabID = -22 Then
            // DeliveryScreen.currentSearchBy = "Phone"
            // Else
            // i do not know the difference 
            // DeliveryScreen.currentSearchBy = startInSearch
            // End If

            // DeliveryScreen.BindDataAfterSearch()

            DeliveryScreen.DetermineSearch(startInSearch, searchCriteria);
            DeliveryScreen.Visible = true;
            DeliveryScreen.BringToFront();

            readAuth.ActiveScreen = "DeliveryScreen";
            readAuth.GiftAddingAmount = false;
            readAuth.IsNewTab = false;

        }

    }

    private void InitializeSeatingChart()
    {

        SeatingChart = new Seating_ChooseTable();
        SeatingChart.Location = new Point(0, 0);
        // SeatingChart.BringToFront()
        SeatingChart.Visible = false;
        this.Controls.Add(SeatingChart);

    }

    private void FiringSeatingChart(bool fromMgmt)
    {
        // do last Floor Plan By Employee
        try
        {
            if (SeatingChart is null)
            {
                InitializeSeatingChart();
            }
            RecallSeatingChart(fromMgmt, false);
        }
        catch (Exception ex)
        {
            InitializeSeatingChart();
            RecallSeatingChart(fromMgmt, false);
        }

    }

    private void FiringSeatingTab(string startedFrom, string tn)
    {

        if (startedFrom == "TableScreen")
        {
            tableScreen.DisableTables_Screen();
            // tableScreen.Visible = False
        }

        if (SeatingTab is null)
        {
            SeatingTab = new Seating_EnterTab();
            SeatingTab.Location = new Point((this.Width - SeatingTab.Width) / 2, (this.Height - SeatingTab.Height) / 2);
            this.Controls.Add(SeatingTab);
            SeatingTab.RestartSeatingTabWithName(startedFrom, tn);
        }
        else
        {
            SeatingTab.RestartSeatingTabWithName(startedFrom, tn);
            SeatingTab.Visible = true;
        }
        SeatingTab.BringToFront();

        if (startedFrom == "OrderScreen")
        {
            readAuth.IsNewTab = false;
            SeatingTab.StartedFrom = "OrderScreen";
        }
        else if (startedFrom == "Manager")
        {
            readAuth.IsNewTab = true;
            SeatingTab.StartedFrom = "Manager";
        }
        else
        {
            readAuth.IsNewTab = true;
            // SeatingTab.StartedFrom = "Manager"
        }
        readAuth.GiftAddingAmount = false;
        readAuth.ActiveScreen = "SeatingTab"; // startedFrom

    }

    private void NewAddNewTab()
    {

        // -999 for tabID will tell it to generate New TabID (which will be experience Number)
        // later we will have a look-up for returning customers
        string newTabNameString;
        newTabNameString = SeatingTab.NewTabName;

        if (SeatingTab.StartedFrom == "TableScreen")
        {
            OpenNewTab(-999, newTabNameString);
            tableScreen.EnableTables_Screen();
            // tableScreen.InitializeScreen()
            var argtabAccountInfo = default;
            OrderScreen(ref argtabAccountInfo);
        }

        else if (SeatingTab.StartedFrom == "Manager")
        {
            OpenNewTab(-999, newTabNameString);
            MgrOrderScreen();
        }

        else if (SeatingTab.StartedFrom == "OrderScreen")
        {
            currentTable.TabName = SeatingTab.NewTabName;
            currentTable.MethodUse = SeatingTab.MethedUse;
            LoadTabIDinExperinceTable();
            UpdateTableInfo();
            // OrderScreen(Nothing)
            readAuth.ActiveScreen = "OrderScreen";

            if (currentTerminal.TermMethod == "Quick")
            {
                QuickOrder.EnableControls();
            }
            else
            {
                activeOrder.EnableControls();
            }
            // LoadTabIDinExperienceNumber (we really don't have a tab ID???)
        }

        SeatingTab.Visible = false;
        readAuth.IsNewTab = false;
        readAuth.GiftAddingAmount = false;
    }

    private void NewAddNewTakeOutTab()
    {

        // -990 for tabID is TAKE OUT

        string newTabNameString;
        newTabNameString = SeatingTab.NewTabName;

        if (SeatingTab.StartedFrom == "TableScreen")
        {
            if (SeatingTab.MethedUse == "Take Out")
            {
                OpenNewTab(-990, newTabNameString); // , False, Nothing)
            }
            else     // pick up
            {
                OpenNewTab(-991, newTabNameString);
            } // , False, Nothing)
            tableScreen.EnableTables_Screen();
            // tableScreen.InitializeScreen()
            var argtabAccountInfo = default;
            OrderScreen(ref argtabAccountInfo);  // readAuth.ActiveScreen is set to OrderScreen in sub
        }

        else if (SeatingTab.StartedFrom == "Manager")
        {
            if (SeatingTab.MethedUse == "Take Out")
            {
                OpenNewTab(-990, newTabNameString); // , False, Nothing)
            }
            else     // pick up
            {
                OpenNewTab(-991, newTabNameString);
            } // , False, Nothing)
            MgrOrderScreen();
        }

        else if (SeatingTab.StartedFrom == "OrderScreen")
        {
            currentTable.TabName = SeatingTab.NewTabName;
            currentTable.MethodUse = SeatingTab.MethedUse;
            LoadTabIDinExperinceTable();
            UpdateTableInfo();
            // OrderScreen(Nothing)
            if (currentTerminal.TermMethod == "Quick")
            {
                if (SeatingTab.MethedUse == "Take Out")
                {
                    QuickOrder.wasPickupMethod = false;
                }
                else     // pick up
                {
                    QuickOrder.wasPickupMethod = true;
                }
                QuickOrder.EnableControls();
            }
            // QuickOrder.tabIdentifierDisplaying = False
            else
            {
                if (SeatingTab.MethedUse == "Take Out")
                {
                    activeOrder.wasPickupMethod = false;
                }
                else     // pick up
                {
                    activeOrder.wasPickupMethod = true;
                }
                activeOrder.EnableControls();
                // activeOrder.tabIdentifierDisplaying = False
            }
        }

        SeatingTab.Visible = false;
        readAuth.IsNewTab = false;
        readAuth.GiftAddingAmount = false;

    }

    private void OpenNewTabStep222(long tabId, string tabName, bool isDineIn, ref DataSet_Builder.Payment tabAccountInfo)
    {
        // there is another OpenNewTab in Table_Screen_Bar ?????

        // new
        // If SeatingTab.FromManager = True Then
        // MgrOrderScreen()
        // Else
        // OrderScreen(Nothing)
        // End If

        return; // 444


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
        currentTable.CurrentMenu = currentTerminal.currentPrimaryMenuID; // primaryMenuID  'this is the system menu - can change during order process
        currentTable.StartingMenu = currentTerminal.currentPrimaryMenuID; // primaryMenuID
        currentTable.NumberOfCustomers = 1;      // is 1 when you first open
        currentTable.NumberOfChecks = 1;
        currentTable.LastStatus = 2;
        currentTable.SatTime = DateTime.Now;
        currentTable.ItemsOnHold = 0;
        currentTable.MethodUse = SeatingTab.MethedUse;
        tabAccountInfo.experienceNumber = currentTable.ExperienceNumber;

        StartOrderProcess(currentTable.ExperienceNumber);

        // new
        if (SeatingTab.StartedFrom == "Manager")
        {
            MgrOrderScreen();
        }
        else
        {
            var argtabAccountInfo = default;
            OrderScreen(ref argtabAccountInfo);
        }

    }

    private void FiringOverrideSeatingChart(bool fromMgmt)
    {

        try
        {
            RecallSeatingChart(fromMgmt, true);
        }
        catch (Exception ex)
        {
            InitializeSeatingChart();
            RecallSeatingChart(fromMgmt, true);
        }

    }

    private void RecallSeatingChart(bool fromMgmt, bool overridingStatus)
    {

        SeatingChart.StartedFromManager = fromMgmt;
        SeatingChart.OverrideAvail = overridingStatus;
        SeatingChart.AdjustTableColor();
        SeatingChart.Visible = true;
        SeatingChart.BringToFront();

    }

    private void CancelNewTable(object sender, EventArgs e)
    {

        if (SeatingChart.StartedFromManager == true)
        {
            managementScreen.Visible = true;
            managementScreen.ReinitializeWithoutLogon(false, false);
            // we did not dispose management screen when bringing seating chart just in case we open order
            // b/c there we are disposing mangerment screen
        }

        // we need this b/c the "AvailTables" is cleared
        // If typeProgram = "Online_Demo" Then
        // GenerateOrderTables.PopulateTabsAndTables(currentServer, currentTerminal.CurrentDailyCode, False, False, Nothing)
        // End If

    }

    private void CancelNewTab()
    {

        if (SeatingTab.StartedFrom == "TableScreen")
        {
            tableScreen.EnableTables_Screen();
            tableScreen.InitializeScreen();
            readAuth.ActiveScreen = "TableScreen";
        }
        else if (SeatingTab.StartedFrom == "OrderScreen")
        {
            if (currentTerminal.TermMethod == "Quick")
            {
                QuickOrder.EnableControls();
            }
            else
            {
                activeOrder.EnableControls();
            }
        }
        else
        {
            PerformEmployeeFunctions(currentServer);
        }

        SeatingTab.Visible = false;

    }

    private void InitializeSplitChecks(bool _isFromManager) // , ByVal _goingToSelectedCheck As Boolean)
    {

        activeSplit = new SplitChecks(); // False, True)    'false not from manager
        activeSplit.Location = new Point(0, 0);
        activeSplit.DisplayCloseCheck(_isFromManager);
        this.Controls.Add(activeSplit);

    }

    private void ForceSendOrder(bool alsoClose)
    {
        if (currentTerminal.TermMethod == "Quick")
        {
            if (QuickOrder is null)
            {
                QuickOrder = new term_OrderForm(false, true, (object)null);
                QuickOrder.Location = new Point(0, 0);
                this.Controls.Add(QuickOrder);
            }
            QuickOrder.SendingOrderRoutine();
        }
        else
        {
            if (activeOrder is null)
            {
                activeOrder = new term_OrderForm(false, true, (object)null);
                activeOrder.Location = new Point(0, 0);
                this.Controls.Add(activeOrder);
            }
            activeOrder.SendingOrderRoutine();
        }

    }

    // ************************
    // Delivery Screen
    // ************************

    private void TabReorderButtonSelected(DataTable dt, bool tabTestNeeded) // 444activeSplit.SelectedReOrder
    {

        if (tabTestNeeded == true)
        {
            TabIDTest();
        }

        if (currentTerminal.TermMethod == "Quick")
        {
            QuickOrder.TabReorderButtonSelected(dt, false); // dsCustomer.Tables("TabPreviousOrdersbyItem"))
        }
        else
        {
            activeOrder.TabReorderButtonSelected(dt, false);
        } // dsCustomer.Tables("TabPreviousOrdersbyItem"))

        CloseScreenVisible(false);

        // 444      If Not activeSplit Is Nothing Then
        // activeSplit._closeCheck.ReinitializeCloseCheck()
        // End If

    }

    private void TabNewOrderButtonSelected()
    {

        TabIDTest();

    }

    internal void TabIDTest()
    {

        if (currentTable.TabID == DeliveryScreen.TempTabID | currentTable.TabName == DeliveryScreen.TempTabName)
        {
        }
        // already set
        else
        {
            currentTable.TabID = DeliveryScreen.TempTabID;
            currentTable.TabName = DeliveryScreen.TempTabName;
            LoadTabIDinExperinceTable();
            UpdateTableInfo();
        }

    }

    private void UpdateTableInfo()
    {
        if (currentTerminal.TermMethod == "Quick")
        {
            QuickOrder.UpdateTableInfo();
        }
        else
        {
            activeOrder.UpdateTableInfo();
        }

    }

    private void TestForCurrentTabInfo()
    {
        DeliveryScreen.TestForCurrentTabInfo();
        if (DeliveryScreen.HasAddress == false)
        {
            if (currentTerminal.TermMethod == "Quick")
            {
                QuickOrder.StartDeliveryMethod();
            }
            else
            {
                activeOrder.StartDeliveryMethod();
            }
        }
    }

    private void ClosedTabScreen()
    {

        DeliveryScreen.Visible = false;

        if (currentTerminal.TermMethod == "Quick")
        {
            QuickOrder.tabScreenDisplaying = false;
            QuickOrder.EnableControls();
        }
        else
        {
            activeOrder.tabScreenDisplaying = false;
            activeOrder.EnableControls();
        }
        readAuth.ActiveScreen = "OrderScreen";
        readAuth.GiftAddingAmount = false;   // both below probably not needed
        readAuth.IsNewTab = false;

    }









    private void InitializeOrderForm222()
    {
        // currently having problem reloading dataset the second time 
        // if we use visible
        // not using this way now

        // StartOrderProcess(0)
        activeOrder = new term_OrderForm(false, false, (object)null);

        GenerateOrderTables.CreateDataViewsOrder();
        GenerateOrderTables.PopulateOpenOrderData222(0, false);

        // activeOrder.ReInitializeOrderView()
        // GenerateOrderTables.PopulateOpenOrderData(0)
        // GenerateOrderTables.StartOrderProcess(2000000015)
        // GenerateOrderTables.CreateDataViewsOrder()

        // Me.activeOrder.ReInitializeOrderView()
        // GenerateOrderTables.StartOrderProcess(2000000015)

        activeOrder.Location = new Point(0, 0);
        this.Controls.Add(activeOrder);
        activeOrder.Visible = false;
        OpenOrdersCurrencyMan = this.BindingContext(dsOrder.Tables("OpenOrders"));
        // if use currencyMan remove dup from ordergridview
        orderScreenInitialized = false;
        // StartOrderProcess(0)
        // GenerateOrderTables.CreateDataViewsOrder()

    }

    private void LoginManager(ref DataSet_Builder.Employee currentServer)
    {

        managementScreen = new Manager_Form(currentServer, false);
        managementScreen.Location = new Point(0, 0);
        this.Controls.Add(managementScreen);
        managementScreen.BringToFront();
        MakeTable_ScreenNotVisible();
        readAuth.ActiveScreen = "Manager";
        // managementScreen.Show()

    }

    private void LoginEmployee222(ref DataSet_Builder.Employee emp)
    {

        var oRow = default(DataRow);
        int rowCount;

        // PopulateAllTablesWithStatus(False)
        DetermineOpenBusiness();

        rowCount = dsOrder.Tables("OpenBusiness").Rows.Count;

        if (rowCount > 0 == true)
        {

            if (rowCount == 1)
            {
                oRow = dsOrder.Tables("OpenBusiness").Rows(0);
            }
            else
            {
                foreach (DataRow currentORow in dsOrder.Tables("OpenBusiness").Rows)
                {
                    oRow = currentORow;
                    if (oRow("DailyCode") == currentTerminal.CurrentDailyCode)
                        break;
                }
            }
            // oRow = dsOrder.Tables("OpenBusiness").Rows(rowCount - 1)
            // currentTerminal.CurrentDailyCode = oRow("DailyCode")
            currentTerminal.DailyDate = Strings.Format(oRow("StartTime"), "d");
            currentTerminal.primaryMenuID = oRow("PrimaryMenu");
            currentTerminal.secondaryMenuID = oRow("SecondaryMenu");
            currentTerminal.CurrentShift = oRow("ShiftID");

            PopulateQuickTicket();
            PerformEmployeeFunctions(emp);
        }

        // below for Demo
        // dsOrder.WriteXml("OrderData.xml", XmlWriteMode.WriteSchema)

        else if (Interaction.MsgBox("There is no Daily Business Open. Do you wish to Clock Out?", MsgBoxStyle.YesNo) == MsgBoxResult.No)    // if false
        {
            return;
        }

    }

    private void PerformEmployeeFunctions(Employee emp)   // Public Shared Sub
    {
        var oRow = default(DataRow);
        int rowCount;
        readAuth.GiftAddingAmount = false;
        readAuth.IsNewTab = false;

        // PopulateAllTablesWithStatus(False)
        DetermineOpenBusiness();

        rowCount = dsOrder.Tables("OpenBusiness").Rows.Count;

        if (rowCount > 0 == true)
        {

            if (rowCount == 1)
            {
                oRow = dsOrder.Tables("OpenBusiness").Rows(0);
            }
            else
            {
                foreach (DataRow currentORow in dsOrder.Tables("OpenBusiness").Rows)
                {
                    oRow = currentORow;
                    if (oRow("DailyCode") == currentTerminal.CurrentDailyCode)
                        break;
                }
            }
            // oRow = dsOrder.Tables("OpenBusiness").Rows(rowCount - 1)
            // currentTerminal.CurrentDailyCode = oRow("DailyCode")
            currentTerminal.DailyDate = Strings.Format(oRow("StartTime"), "d");
            currentTerminal.primaryMenuID = oRow("PrimaryMenu");
            currentTerminal.secondaryMenuID = oRow("SecondaryMenu");
            currentTerminal.CurrentShift = oRow("ShiftID");

            PopulateQuickTicket();
        }
        // PerformEmployeeFunctions(emp)

        // below for Demo
        // dsOrder.WriteXml("OrderData.xml", XmlWriteMode.WriteSchema)

        else    // if false
        {
            DailyClosed(emp);
            return;

        }

        if (dsOrder.Tables("QuickTickets") is not null)
        {
            currentQuickTicketDataViews.Clear();
            switch (currentTerminal.TermMethod)
            {
                case "Quick":
                    {
                        {
                            var withBlock = dvQuickTickets;
                            withBlock.Table = dsOrder.Tables("QuickTickets");
                            // .RowFilter = "EmployeeID = " & emp.EmployeeID
                            withBlock.Sort = "ExperienceDate ASC";
                        }

                        break;
                    }
            }
        }

        if (emp.EmployeeID == 6986)
        {
            if (currentTerminal.TermMethod == "Quick")
            {
                emp.Bartender = false;
                emp.Cashier = true;
            }
            else
            {
                emp.Bartender = true;
                emp.Cashier = false;
            }
        }

        if (emp.Manager == true)
        {

            if (currentServer is null)
            {
                currentServer = new Employee();
            }
            currentServer = emp;

            managementScreen = new Manager_Form(emp, true);  // emp, usernameEntered?
            managementScreen.Location = new Point(0, 0);
            this.Controls.Add(managementScreen);
            managementScreen.BringToFront();
            readAuth.ActiveScreen = "Manager";
            // managementScreen.Show()
            return;
        }

        else if (emp.Bartender == true) // Or emp.EmployeeID = 4002 Or emp.EmployeeID = 4001 Then    'and if terminal group is at bar
        {

            if (currentTerminal.TermMethod == "Table")
            {

                if (currentServer is null)
                {
                    currentServer = new Employee();
                }
                currentServer = emp;

                if (tableScreen is not null)
                {
                    // If companyInfo.usingBartenderMethod = True Then
                    // Me.tableScreen.IsBartenderMode = True        'IsBartnerderMode? yes
                    // Else
                    // Me.tableScreen.IsBartenderMode = False        'IsBartnerderMode? no
                    // End If
                    tableScreen.IsBartenderMode = false;        // IsBartnerderMode? no
                    tableScreen.InitializeOther(true);
                    tableScreen.Visible = true;
                }
                else
                {
                    tableScreen = new Tables_Screen_Bar();
                    tableScreen.Location = new Point(0, 0);
                    this.Controls.Add(tableScreen);
                    // If companyInfo.usingBartenderMethod = True Then
                    // Me.tableScreen.IsBartenderMode = True        'IsBartnerderMode? yes
                    // Else
                    // Me.tableScreen.IsBartenderMode = False        'IsBartnerderMode? no
                    // End If
                    tableScreen.IsBartenderMode = false;        // IsBartnerderMode? no
                    tableScreen.InitializeOther(true);
                }
                readAuth.ActiveScreen = "TableScreen";
            }

            // Me.tableScreen.Visible = True

            else if (currentTerminal.TermMethod == "Bar") // Or emp.EmployeeID = 6986 Then
            {

                GenerateOrderTables.PopulateBartenderCollection();

                if (dsOrder.Tables("QuickTickets").Rows.Count > 0)
                {

                    foreach (Employee ee in currentBartenders)
                    {
                        var dvQuickTickets444 = new DataView();
                        // dvQuickTickets = New DataView
                        dvQuickTickets444.Table = dsOrder.Tables("QuickTickets");
                        dvQuickTickets444.RowFilter = "EmployeeID = " + ee.EmployeeID;
                        dvQuickTickets444.Sort = "ExperienceDate ASC";
                        currentQuickTicketDataViews.Add(dvQuickTickets444);
                    }
                }

                if (currentServer is null)
                {
                    currentServer = new Employee();
                }
                currentServer = emp;

                if (tableScreen is not null)
                {
                    if (companyInfo.usingBartenderMethod == true)
                    {
                        tableScreen.IsBartenderMode = true;        // IsBartnerderMode? yes
                    }
                    else
                    {
                        tableScreen.IsBartenderMode = false;
                    }        // IsBartnerderMode? no
                    tableScreen.InitializeOther(true);
                    tableScreen.Visible = true;
                }
                else
                {
                    tableScreen = new Tables_Screen_Bar();
                    tableScreen.Location = new Point(0, 0);
                    this.Controls.Add(tableScreen);
                    if (companyInfo.usingBartenderMethod == true)
                    {
                        tableScreen.IsBartenderMode = true;        // IsBartnerderMode? yes
                    }
                    else
                    {
                        tableScreen.IsBartenderMode = false;
                    }        // IsBartnerderMode? no
                    tableScreen.InitializeOther(true);
                }
                readAuth.ActiveScreen = "TableScreen";
            }
            // 444     tableScreen = New Tables_Screen_Bar

            else if (currentTerminal.TermMethod == "Quick")       // Quick Server
            {
                LoginQuickService(ref emp);
            }
            return;
        }

        else if (emp.Server == true)
        {
            if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
            {
                if (currentServer is null)
                {
                    currentServer = new Employee();
                }
                currentServer = emp;

                if (tableScreen is not null)
                {
                    tableScreen.IsBartenderMode = false;        // IsBartnerderMode? no
                    tableScreen.InitializeOther(false);   // emp is not bartender
                    tableScreen.Visible = true;
                }
                else
                {
                    tableScreen = new Tables_Screen_Bar();
                    tableScreen.Location = new Point(0, 0);
                    this.Controls.Add(tableScreen);
                    tableScreen.IsBartenderMode = false;        // IsBartnerderMode? no
                    tableScreen.InitializeOther(false);
                }   // emp is not bartender
                readAuth.ActiveScreen = "TableScreen";
            }

            // 444    tableScreen = New Tables_Screen_Bar
            // Me.tableScreen.IsBartenderMode = False        'IsBartnerderMode? no
            // Me.tableScreen.InitializeOther(False)   '  emp is not bartender

            // 444     tableScreen.Location = New Point(0, 0)
            // 444     Me.Controls.Add(tableScreen)

            else if (currentTerminal.TermMethod == "Quick")       // Quick Server
            {
                LoginQuickService(ref emp);
            }
            return;
        }

        else if (emp.Cashier == true)
        {
            if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
            {
            }

            else if (currentTerminal.TermMethod == "Quick")       // Quick Server
            {
                // LoginQuickService(emp)


                // Exit Sub
                // below is possible start for displaying tickets on table screen
                // GenerateOrderTables.PopulateBartenderCollection()

                if (dsOrder.Tables("QuickTickets").Rows.Count > 0)
                {

                    // Dim ee As Employee
                    // For Each ee In currentBartenders
                    var dvQuickTickets444 = new DataView();
                    dvQuickTickets444.Table = dsOrder.Tables("QuickTickets");
                    // .RowFilter = "EmployeeID = " & ee.EmployeeID
                    dvQuickTickets444.Sort = "ExperienceDate ASC";
                    currentQuickTicketDataViews.Add(dvQuickTickets444);
                    // Next

                }

                if (currentServer is null)
                {
                    currentServer = new Employee();
                }
                currentServer = emp;

                // 444       tableScreen = New Tables_Screen_Bar
                if (tableScreen is not null)
                {
                    if (companyInfo.usingBartenderMethod == true)
                    {
                        tableScreen.IsBartenderMode = true;        // IsBartnerderMode? yes
                    }
                    else
                    {
                        tableScreen.IsBartenderMode = false;
                    }        // IsBartnerderMode? no

                    tableScreen.InitializeOther(true);
                    tableScreen.Visible = true;
                }
                else
                {
                    tableScreen = new Tables_Screen_Bar();
                    tableScreen.Location = new Point(0, 0);
                    this.Controls.Add(tableScreen);
                    if (companyInfo.usingBartenderMethod == true)
                    {
                        tableScreen.IsBartenderMode = true;        // IsBartnerderMode? yes
                    }
                    else
                    {
                        tableScreen.IsBartenderMode = false;
                    }        // IsBartnerderMode? no

                    tableScreen.InitializeOther(true);
                }
                readAuth.ActiveScreen = "TableScreen";

                // 444     tableScreen.Location = New Point(0, 0)
                // 444  Me.Controls.Add(tableScreen)

            }
            return;
        }

        else if (emp.Hostess == true)
        {
            if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
            {
            }

            else if (currentTerminal.TermMethod == "Quick")       // Quick Server
            {
                LoginQuickService(ref emp);
            }
            return;

        }

        if (currentServer is null)
        {
            currentServer = emp;
        }
        // *** if there is no daily, we will allow for a clockout
        // a server does gets a non server screen
        if (currentClockEmp is null)
        {
            currentClockEmp = new Employee();
        }
        currentClockEmp = emp;
        if (currentClockEmp.ClockInReq == true)
        {
            nonServerClockout = new ClockOut_UC(emp, false);
            nonServerClockout.Location = new Point(0, 0); // (Me.pnlTimeInfo.Width + 20, Me.lblLogin.Height + 10)
            nonServerClockout.BringToFront();
            this.Controls.Add(nonServerClockout);
        }
        // Me.pnlLogin.Controls.Add(nonServerClockout)
        else
        {
            Interaction.MsgBox(currentClockEmp.FullName + " does not use time clock.");
        }

    }

    private void QuickOrderScreen()
    {

        GenerateOrderTables.CreateDataViewsOrder();

        if (QuickOrder is null)
        {
            QuickOrder = new term_OrderForm(false, false, (object)null);
            QuickOrder.Location = new Point(0, 0);
            this.Controls.Add(QuickOrder);
        }
        else
        {
            // when we change to visible 
            QuickOrder.IsBartenderMode = false;
            QuickOrder.IsManagerMode = false;
            QuickOrder.TabAccountInfo = (object)null;
            QuickOrder.InitializeScreenSecondStep();
            QuickOrder.Visible = true;
        }

        QuickOrder.BringToFront();
        readAuth.ActiveScreen = "OrderScreen";

    }

    private void OrderScreen(ref DataSet_Builder.Payment tabAccountInfo)
    {

        if (currentTerminal.TermMethod == "Quick")
        {
            if (QuickOrder is null)
            {
                QuickOrder = new term_OrderForm(tableScreen.IsBartenderMode, false, tabAccountInfo);
                QuickOrder.Location = new Point(0, 0);
                this.Controls.Add(QuickOrder);
            }
            else
            {
                // when we change to visible 
                QuickOrder.IsBartenderMode = tableScreen.IsBartenderMode;
                QuickOrder.IsManagerMode = false;
                QuickOrder.TabAccountInfo = tabAccountInfo;
                QuickOrder.InitializeScreenSecondStep();
                QuickOrder.Visible = true;
            }

            QuickOrder.BringToFront();

            if (dsOrder.Tables("QuickTickets").Rows.Count == 1)
            {
                // this is the first time we come here
                if (currentTable.MethodUse == "Delivery")
                {
                    // ???   TestForCurrentTabInfo()
                    QuickOrder.StartDeliveryMethod();
                }
                else if (currentTable.MethodUse == "Dine In")
                {
                    QuickOrder.StartDineInMethod(true);
                    QuickOrder.EnableControls();
                }
            }
            else if (currentTable.MethodUse == "Delivery" | currentTable.MethodUse == "Pickup")
            {
                // may be good idea to have this for DineIn and Take-Out as well
                TestForCurrentTabInfo();
            }
            else
            {
                QuickOrder.EnableControls();
            }
        }

        else
        {
            if (activeOrder is null)
            {
                activeOrder = new term_OrderForm(tableScreen.IsBartenderMode, false, tabAccountInfo);
                activeOrder.Location = new Point(0, 0);
                this.Controls.Add(activeOrder);
            }
            else
            {
                // when we change to visible 
                activeOrder.IsBartenderMode = tableScreen.IsBartenderMode;
                activeOrder.IsManagerMode = false;
                activeOrder.TabAccountInfo = tabAccountInfo;
                activeOrder.InitializeScreenSecondStep();
                activeOrder.Visible = true;
            }

            activeOrder.BringToFront();
            activeOrder.EnableControls();

            if (currentTable.MethodUse == "Delivery")
            {
                TestForCurrentTabInfo();
            }
        }

        // If Not SeatingTab Is Nothing Then
        // SeatingTab.Dispose()
        // End If

        MakeTable_ScreenNotVisible(); // this just make visible.false
        readAuth.GiftAddingAmount = false;
        readAuth.IsNewTab = false;
        readAuth.ActiveScreen = "OrderScreen";

        if (companyInfo.processor == "MerchantWare")
        {
            // 444        readAuth_MWE.currentExpNum = currentTable.ExperienceNumber
            // 444        readAuth_MWE.currentCheckNum = currentTable.CheckNumber
            // we must also change check number from close check
        }

    }

    private void MgrOrderScreen()
    {
        // I don;t think TabAccountInfo is used in Term_OrderForm (also for above)

        if (managementScreen is not null)
        {
            managementScreen.Dispose();
            managementScreen = default;
        }


        if (currentTerminal.TermMethod == "Quick")
        {
            if (QuickOrder is null)
            {
                QuickOrder = new term_OrderForm(false, true, (object)null);
                QuickOrder.Location = new Point(0, 0);
                this.Controls.Add(QuickOrder);
            }
            else
            {
                // when we change to visible 
                QuickOrder.IsBartenderMode = false;
                QuickOrder.IsManagerMode = true;
                // QuickOrder.TabAccountInfo = tabAccountInfo
                QuickOrder.InitializeScreenSecondStep();
                QuickOrder.Visible = true;
            }

            QuickOrder.BringToFront();
        }

        else
        {
            if (activeOrder is null)
            {
                activeOrder = new term_OrderForm(false, true, (object)null);
                activeOrder.Location = new Point(0, 0);
                this.Controls.Add(activeOrder);
            }
            else
            {
                // when we change to visible 
                activeOrder.IsBartenderMode = false;
                activeOrder.IsManagerMode = true;
                // activeOrder.TabAccountInfo = tabAccountInfo
                activeOrder.InitializeScreenSecondStep();
                activeOrder.Visible = true;
            }

            activeOrder.BringToFront();

        }

        readAuth.GiftAddingAmount = false;
        readAuth.IsNewTab = false;
        readAuth.ActiveScreen = "OrderScreen";

    }

    private void ExitManager()
    {

        managementScreen.Dispose();
        managementScreen = default;
        actingManager = (object)null;
        empActive = (object)null;
        pnlLogin.Visible = true;
        readAuth.ActiveScreen = "Login";

    }


    private void NewAddNewTable()
    {
        long expNum;
        int numCust;
        bool isCurrentlyHeld;
        // Dim satTm As DateTime

        // **** might have to have a check for the bartenders on which employee this is

        // EnableTables_Screen()
        // InitializeScreen()


        try
        {
            foreach (DataRow oRow in dsOrder.Tables("AllTables").Rows)     // currentPhysicalTables
            {
                if (oRow("TableNumber") == SeatingChart.TableSelected)
                {
                    if (typeProgram == "Online_Demo")
                    {
                        oRow("EmployeeID") = currentServer.EmployeeID;
                        oRow("TableStatusID") = 2;
                    }
                    numCust = SeatingChart.NumberCustomers;
                    expNum = CreateNewExperience(currentServer.EmployeeID, SeatingChart.TableSelected, default, default, numCust, 2, 0, 0, currentServer.LoginTrackingID);
                    isCurrentlyHeld = PopulateThisExperience(expNum, false);

                    currentTable = new DinnerTable();
                    currentTable.ExperienceNumber = expNum;
                    currentTable.IsTabNotTable = false;
                    currentTable.TableNumber = SeatingChart.TableSelected;
                    currentTable.TabID = 0;
                    currentTable.TabName = SeatingChart.TableSelected.ToString;
                    currentTable.TicketNumber = 0;
                    currentTable.EmployeeID = currentServer.EmployeeID;
                    currentTable.EmployeeNumber = currentServer.EmployeeNumber;
                    currentTable.CurrentMenu = currentTerminal.currentPrimaryMenuID; // primaryMenuID
                    currentTable.StartingMenu = currentTerminal.currentPrimaryMenuID; // primaryMenuID
                    currentTable.NumberOfChecks = 1;
                    currentTable.NumberOfCustomers = numCust;
                    currentTable.LastStatus = 2;
                    currentTable.OrderView = "Detail";
                    currentTable.SatTime = DateTime.Now;
                    currentTable.ItemsOnHold = 0;
                    if (numCust >= companyInfo.autoGratuityNumber)
                    {
                        currentTable.AutoGratuity = companyInfo.autoGratuityPercent;
                    }
                    else
                    {
                        currentTable.AutoGratuity = -1;
                    }
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

                    // 222        satTm = AddStatusChangeData(currentTable.ExperienceNumber, 2, Nothing, 0, Nothing)
                    // SaveESCStatusChangeData(2, Nothing, 0, Nothing)

                    // RaiseEvent FireOrderScreen()
                    if (SeatingChart.StartedFromManager == true)
                    {
                        MgrOrderScreen();
                    }
                    else
                    {
                        var argtabAccountInfo = default;
                        OrderScreen(ref argtabAccountInfo);
                    }

                    SeatingChart.Visible = false;

                    return;
                }
            }
        }
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);
            // in case of failure
            SeatingChart.Visible = false;
            // EnableTables_Screen()
            // InitializeScreen()
        }

    }

    private void MakeTable_ScreenNotVisible()
    {

        updateClockTimer.Dispose();
        tablesInactiveTimer.Dispose();
        tableScreen.Visible = false;


    }

    private void UpdatingTableData(Employee emp, ref CashClose_UC ccDisplay)   // , managementScreen.UpdatingAfterTransfer
    {

        // Me.activeOrder.DisposeOrderFormObjects()
        // Me.activeOrder.Dispose()
        // Me.activeOrder = Nothing
        activeOrder.Visible = false;
        if (SeatingTab is not null)
        {
            SeatingTab.Visible = false;
        }
        if (DeliveryScreen is not null)
        {
            DeliveryScreen.Visible = false;
        }

        GenerateOrderTables.ReleaseCurrentlyHeld();
        GenerateOrderTables.SaveOpenOrderData();

        currentTable = (object)null;
        currentServer = (object)null;
        // activeOrder.Visible = False
        // Me.activeOrder.ReInitializeOrderView()

        PerformEmployeeFunctions(emp);   // currentServer)
        if (ccDisplay is not null)
        {
            ccDisplay.Location = new Point((this.Width - ccDisplay.Width) / 2, (this.Height - ccDisplay.Height) / 2);
            this.Controls.Add(ccDisplay);
            ccDisplay.BringToFront();
        }

    }

    // **********************************
    // CLose Check through SplitScreen
    // **********************************

    private void StartCloseScreen()
    {

        activeOrder.Visible = false;
        CloseScreenVisible(false);

    }

    private void StartQuickCloseScreen()
    {

        CloseScreenVisible(false);
        QuickOrder.Visible = false;

    }

    private void CloseScreenVisible(bool _isFromManager)
    {

        if (companyInfo.processor == "MerchantWare")
        {
            // 444       With dvUnAppliedPaymentsAndCredits_MWE
            // 444      .Table = readAuth_MWE.dtPaymentsAndCreditsUnauthorized_MWE
            // 444        .RowFilter = "Applied = False AND ExperienceNumber = '" & currentTable.ExperienceNumber & "' AND CheckNumber = '" & currentTable.CheckNumber & "'"
            // 444         .Sort = "PaymentFlag"
            // 444      End With
        }

        if (activeSplit is not null)
        {
            // activeSplit._closeCheck.ReinitializeCloseCheck()
            // activeSplit._closeCheck.Visible = True
            activeSplit.Visible = true;
            activeSplit.DisplayCloseCheck(_isFromManager);
            activeSplit._closeCheck.BringToFront();
            activeSplit.BringToFront();
        }
        else
        {
            InitializeSplitChecks(_isFromManager);
        }

        readAuth.GiftAddingAmount = false;
        readAuth.IsNewTab = false;
        readAuth.ActiveScreen = "CloseCheck";

    }

    private void StartCloseScreenFromManager()
    {

        managementScreen.Dispose();
        managementScreen = default;
        CloseScreenVisible(true);

    }

    private void EndClosingCheck(bool _isFromManager, Employee emp, bool goingToSelectedCheck)
    {
        pnlLogin.Visible = true;
        // readAuth.ActiveScreen = "Login"
        SetDateTime();

        if (_isFromManager == true)
        {
            if (goingToSelectedCheck == true)
            {
                MgrOrderScreen();
            }
            else
            {
                GenerateOrderTables.ReleaseCurrentlyHeld();
                GenerateOrderTables.SaveOpenOrderData();
                DisposeDataViewsOrder(); // 999
                currentTable = (object)null;
                currentServer = (object)null;
                PerformEmployeeFunctions(emp);
            }
        }
        else if (currentTerminal.TermMethod == "Quick")
        {
            // why() 'Not release And Save?/
            PerformEmployeeFunctions(emp);   // this is different
        }
        else
        {
            activeOrder.Visible = false;
            GenerateOrderTables.ReleaseCurrentlyHeld();
            GenerateOrderTables.SaveOpenOrderData();
            DisposeDataViewsOrder(); // 999
            currentTable = (object)null;
            currentServer = (object)null;
            if (currentTerminal.TermMethod == "Bar")
            {
                PerformEmployeeFunctions(emp);   // this is different
            }
        }

        activeSplit.Visible = false;
        readAuth.GiftAddingAmount = false;
        readAuth.IsNewTab = false;
        // readAuth.ActiveScreen set in PerformEmployeeFunctions

    }

    internal void SplitCheckClosed()
    {

        if (currentTerminal.TermMethod == "Quick")
        {
            QuickOrder.SplitCheckClosed();
            QuickOrder.Visible = true;
        }

        else
        {
            activeOrder.SplitCheckClosed();
            activeOrder.Visible = true;
        }

        activeSplit.Visible = false;

        readAuth.ActiveScreen = "OrderScreen";
        readAuth.GiftAddingAmount = false;
        readAuth.IsNewTab = false;
        // 444        activeSplit.Dispose()
        // 444    activeSplit = Nothing

    }

    private void GotoQuickTicket(long experienceNumber)
    {
        // ByVal tabID As Int64, ByVal tabName As String, 

        long expNum;
        long tabID;
        string tabName;
        int tktNum;
        int lStatus;
        string lView;
        decimal autoGratuity;
        // Dim tabID As Int64
        // Dim tabName As String
        int numCust;
        int numCks;
        bool firstCheckClosed;
        DataRow oRow;
        var csName = default(string);
        string methodUse;
        // Dim menuID As Integer
        var selectedRow = default(int);
        var rc = default(int);
        currentTerminal.NumOpenTickets = 0;

        // this is what i should be doing here
        // currentTerminal.NumOpenTickets = dsOrder.Tables("QuickTickets").Compute("Count(ClosedSubTotal Is DBNull.Value)") ', "ClosedSubTotal Is DBNull.Value")

        foreach (DataRow currentORow in dsOrder.Tables("QuickTickets").Rows)
        {
            oRow = currentORow;
            if (object.ReferenceEquals(oRow("ClosedSubTotal"), DBNull.Value))
            {
                currentTerminal.NumOpenTickets += 1;
            }
            if (oRow("ExperienceNumber") == experienceNumber)
            {
                selectedRow = rc;
            }
            rc += 1;
        }

        tktNum = dsOrder.Tables("QuickTickets").Rows(selectedRow)("TicketNumber");
        expNum = dsOrder.Tables("QuickTickets").Rows(selectedRow)("ExperienceNumber");
        lStatus = dsOrder.Tables("QuickTickets").Rows(selectedRow)("LastStatus");
        lView = dsOrder.Tables("QuickTickets").Rows(selectedRow)("LastView");
        autoGratuity = dsOrder.Tables("QuickTickets").Rows(selectedRow)("AutoGratuity");
        tabID = dsOrder.Tables("QuickTickets").Rows(selectedRow)("TabID");
        tabName = dsOrder.Tables("QuickTickets").Rows(selectedRow)("TabName");
        numCust = dsOrder.Tables("QuickTickets").Rows(selectedRow)("NumberOfCustomers");
        numCks = dsOrder.Tables("QuickTickets").Rows(selectedRow)("NumberOfChecks");
        methodUse = dsOrder.Tables("QuickTickets").Rows(selectedRow)("MethodUse");

        // menuID = dsOrder.Tables("QuickTickets").Rows(selectedRow)("MenuID")
        if (!object.ReferenceEquals(dsOrder.Tables("QuickTickets").Rows(selectedRow)("ClosedSubTotal"), DBNull.Value))
        {
            firstCheckClosed = true;
        }
        else
        {
            firstCheckClosed = false;
        }

        currentTable = new DinnerTable();

        currentTable.ExperienceNumber = expNum;
        currentTable.IsTabNotTable = true;
        currentTable.TableNumber = 0;
        currentTable.TabID = tabID; // "-999"         ' expNum
        currentTable.TabName = tabName;  // "Tkt# " & tktNum.ToString
        currentTable.TicketNumber = tktNum;
        currentTable.EmployeeID = currentServer.EmployeeID;
        currentTable.EmployeeNumber = currentServer.EmployeeNumber;
        foreach (DataRow currentORow1 in dsEmployee.Tables("AllEmployees").Rows)
        {
            oRow = currentORow1;
            if (oRow("EmployeeID") == currentTable.EmployeeID)
            {
                csName = oRow("NickName");
                break;
            }
        }
        currentTable.EmployeeName = csName;
        currentTable.CurrentMenu = currentTerminal.currentPrimaryMenuID; // menuID 'currentTerminal.CurrentMenuID
        currentTable.StartingMenu = currentTerminal.currentPrimaryMenuID; // menuID 'currentTerminal.CurrentMenuID
        currentTable.NumberOfCustomers = numCust;
        currentTable.NumberOfChecks = numCks;
        currentTable.ItemsOnHold = 0;
        currentTable.IsClosed = firstCheckClosed;
        currentTable.LastStatus = lStatus;
        currentTable.OrderView = lView;
        currentTable.AutoGratuity = autoGratuity;
        currentTable.MethodUse = methodUse;
        DefineMethodDirection();
        // currentTable.NumberOfCustomers = 1
        // currentTable.CheckNumber = 1
        // currentTable.CustomerNumber = 1
        // currentTable.NextCustomerNumber = 1
        // currentTable.LastStatus = lStatus
        // currentTable.Quantity = 1

        PopulateThisExperience(expNum, false);
        StartOrderProcess[expNum];
        MakeTable_ScreenNotVisible();
        QuickOrderScreen();

    }


    private void LoginQuickService(ref Employee emp)
    {

        if (currentServer is null)
        {
            currentServer = new Employee();
        }
        currentServer = emp;

        long expNum;
        int tktNum;
        int lStatus;
        string lView;
        decimal autoGratuity;
        long tabID;
        string tabName;
        int numCust;
        int numCks;
        bool firstCheckClosed;
        DataRow oRow;
        var csName = default(string);
        string methodUse;
        // Dim menuID As Integer
        currentTerminal.NumOpenTickets = 0;

        if (dsOrder.Tables("QuickTickets").Rows.Count == 0)
        {
            tktNum = CreateNewTicketNumber();
            expNum = CreateNewExperience(currentServer.EmployeeID, default, -999, "Tkt# " + tktNum.ToString(), 1, 2, tktNum, 0, currentServer.LoginTrackingID);
            csName = emp.NickName;
            lStatus = 2;
            lView = "Detail";
            firstCheckClosed = false;
            tabID = -999;         // expNum
            tabName = "Tkt# " + tktNum.ToString();
            numCust = 1;
            numCks = 1;
            autoGratuity = -1;
            if (dvTerminalsUseOrder.Count > 0)
            {
                methodUse = dvTerminalsUseOrder[0]("MethodUse");
            }
            else
            {
                methodUse = "Dine In";
            }
        }

        else
        {

            // this is what i should be doing here
            // currentTerminal.NumOpenTickets = dsOrder.Tables("QuickTickets").Compute("Count(ClosedSubTotal Is DBNull.Value)") ', "ClosedSubTotal Is DBNull.Value")

            foreach (DataRow currentORow in dsOrder.Tables("QuickTickets").Rows)
            {
                oRow = currentORow;
                if (object.ReferenceEquals(oRow("ClosedSubTotal"), DBNull.Value))
                {
                    currentTerminal.NumOpenTickets += 1;
                }
            }
            tktNum = dsOrder.Tables("QuickTickets").Rows(dsOrder.Tables("QuickTickets").Rows.Count - 1)("TicketNumber");
            expNum = dsOrder.Tables("QuickTickets").Rows(dsOrder.Tables("QuickTickets").Rows.Count - 1)("ExperienceNumber");
            lStatus = dsOrder.Tables("QuickTickets").Rows(dsOrder.Tables("QuickTickets").Rows.Count - 1)("LastStatus");
            lView = dsOrder.Tables("QuickTickets").Rows(dsOrder.Tables("QuickTickets").Rows.Count - 1)("LastView");
            autoGratuity = dsOrder.Tables("QuickTickets").Rows(dsOrder.Tables("QuickTickets").Rows.Count - 1)("AutoGratuity");
            tabID = dsOrder.Tables("QuickTickets").Rows(dsOrder.Tables("QuickTickets").Rows.Count - 1)("TabID");
            tabName = dsOrder.Tables("QuickTickets").Rows(dsOrder.Tables("QuickTickets").Rows.Count - 1)("TabName");
            numCust = dsOrder.Tables("QuickTickets").Rows(dsOrder.Tables("QuickTickets").Rows.Count - 1)("NumberOfCustomers");
            numCks = dsOrder.Tables("QuickTickets").Rows(dsOrder.Tables("QuickTickets").Rows.Count - 1)("NumberOfChecks");
            methodUse = dsOrder.Tables("QuickTickets").Rows(dsOrder.Tables("QuickTickets").Rows.Count - 1)("MethodUse");
            // menuID = dsOrder.Tables("QuickTickets").Rows(dsOrder.Tables("QuickTickets").Rows.Count - 1)("MenuID")
            if (!object.ReferenceEquals(dsOrder.Tables("QuickTickets").Rows(dsOrder.Tables("QuickTickets").Rows.Count - 1)("ClosedSubTotal"), DBNull.Value))
            {
                firstCheckClosed = true;
            }
            else
            {
                firstCheckClosed = false;
            }
            // csName = dsOrder.Tables("QuickTickets").Rows(dsOrder.Tables("QuickTickets").Rows.Count - 1)("NickName")
        }

        currentTable = new DinnerTable();

        currentTable.ExperienceNumber = expNum;
        currentTable.IsTabNotTable = true;
        currentTable.TableNumber = 0;
        currentTable.TabID = tabID; // "-999"         ' expNum
        currentTable.TabName = tabName;  // "Tkt# " & tktNum.ToString
        currentTable.TicketNumber = tktNum;
        currentTable.EmployeeID = currentServer.EmployeeID;
        currentTable.EmployeeNumber = currentServer.EmployeeNumber;
        foreach (DataRow currentORow1 in dsEmployee.Tables("AllEmployees").Rows)
        {
            oRow = currentORow1;
            if (oRow("EmployeeID") == currentTable.EmployeeID)
            {
                csName = oRow("NickName");
                break;
            }
        }
        currentTable.EmployeeName = csName;
        currentTable.CurrentMenu = currentTerminal.currentPrimaryMenuID; // menuID 'currentTerminal.CurrentMenuID
        currentTable.StartingMenu = currentTerminal.currentPrimaryMenuID; // menuID 'currentTerminal.CurrentMenuID
        currentTable.NumberOfCustomers = numCust;
        currentTable.NumberOfChecks = numCks;
        currentTable.ItemsOnHold = 0;
        currentTable.IsClosed = firstCheckClosed;
        currentTable.LastStatus = lStatus;
        currentTable.OrderView = lView;
        currentTable.AutoGratuity = autoGratuity;
        currentTable.MethodUse = methodUse;

        // currentTable.NumberOfCustomers = 1
        // currentTable.CheckNumber = 1
        // currentTable.CustomerNumber = 1
        // currentTable.NextCustomerNumber = 1
        // currentTable.LastStatus = lStatus
        // currentTable.Quantity = 1

        PopulateThisExperience(expNum, false);
        StartOrderProcess[expNum];
        QuickOrderScreen();

    }

    private void LeavingQuickServer(Employee emp, ref CashClose_UC ccDisplay)
    {

        // Me.QuickOrder.DisposeOrderFormObjects()
        // Me.QuickOrder.Dispose()
        // Me.QuickOrder = Nothing
        QuickOrder.Visible = false;
        if (SeatingTab is not null)
        {
            SeatingTab.Visible = false;
        }
        if (DeliveryScreen is not null)
        {
            DeliveryScreen.Visible = false;
        }

        GenerateOrderTables.ReleaseCurrentlyHeld();
        GenerateOrderTables.SaveOpenOrderData();

        currentTable = (object)null;
        currentServer = (object)null;

        // PopulateQuickTicket()
        PerformEmployeeFunctions(emp);   // currentServer)
        if (ccDisplay is not null)
        {
            ccDisplay.Location = new Point((this.Width - ccDisplay.Width) / 2, (this.Height - ccDisplay.Height) / 2);
            this.Controls.Add(ccDisplay);
            ccDisplay.BringToFront();
        }

    }

    private void NextQuickServer()
    {

        // Me.QuickOrder.Dispose()
        // Me.QuickOrder = Nothing
        // sss    GenerateOrderTables.SaveAvailTabsAndTables()

        if (!(typeProgram == "Online_Demo"))
        {
            GenerateOrderTables.ReleaseCurrentlyHeld();
            GenerateOrderTables.SaveOpenOrderData();
        }
        else
        {
            GenerateOrderTables.SaveOpenOrderDataExceptQuick();
        }

        // dsOrder.Tables("QuickTickets").Rows.Clear()
        // DisposeDataViewsOrder()
        // old      currentTable = Nothing
        // old      currentServer = Nothing

    }

    private void btnClockIn_Click(object sender, EventArgs e)
    {

        AttemptingToClockIn(loginPad.NumberString);

    }

    private void AttemptingToClockIn(string loginEnter)
    {

        bool doesNotneedToClockIn;

        clockInPanel = new ClockInUserControl();
        clockInPanel.Location = new Point((ssX - clockInPanel.Width) / 2, (ssY - clockInPanel.Height) / 2);
        this.Controls.Add(clockInPanel);
        doesNotneedToClockIn = clockInPanel.StartClockIn(loginEnter);

        if (doesNotneedToClockIn == false)
        {
            // if False, this means they need to clockIn
            loginPad.btnNumberClear_Click();
            pnlLogin.Visible = false;
            MakeLoginPadVisibleNOT();
            this.pnlLogin.Click -= this.ReceiveFocus;
        }
        else
        {
            clockInPanel.Dispose();
        }

    }

    private void MakeClockOutBooleanFalse()
    {
        clockOutActiveQS = false;
        btnClockOut.BackColor = Color.LightSlateGray;
        MakeLoginPadVisibleNOT();
        // Me.loginPad.Visible = False

    }
    private void btnClockOut_Click(object sender, EventArgs e)
    {

        if (clockOutActiveQS == false & loginPad.NumberString is null)
        {
            clockOutActiveQS = true;
            btnClockOut.BackColor = Color.CornflowerBlue;
            MakeLoginPadVisible();
        }
        // Me.loginPad.Visible = True
        else
        {
            DataSet_Builder.Employee emp;
            bool yesOpenTables;
            string loginEnter;
            bool doesEmpNeedToClockOut;

            loginEnter = loginPad.NumberString;

            emp = GenerateOrderTables.TestUsernamePassword(loginPad.NumberString, clockOutActiveQS); // False)

            if (emp is not null)
            {
                // check to see if there are any open tables           **********************
                if (loginEnter.Length < 8)
                {
                    Interaction.MsgBox("Enter both EmployeeID as Passcode");
                    return;
                }
                doesEmpNeedToClockOut = TestClockOut(loginEnter);
                if (doesEmpNeedToClockOut == false)
                {
                    MakeClockOutBooleanFalse();
                    loginPad.btnNumberClear_Click();
                    Interaction.MsgBox("Employee does not need to Clock Out");
                    return;
                }

                yesOpenTables = GenerateOrderTables.AnyOpenTables(emp);
                if (currentClockEmp is null)
                {
                    currentClockEmp = new Employee();
                }
                currentClockEmp = emp;

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
                    StartClockOut(emp, false);
                }
            }
            MakeClockOutBooleanFalse();

        }

    }

    private void StartClockOut(Employee emp, bool hasOpenTables) // ByVal hasOpenTables As Boolean)
    {
        foreach (Employee salaried in SalariedEmployees)
        {
            if (salaried.EmployeeID == emp.EmployeeID)
            {
                // this is a salaried employee
                Interaction.MsgBox(emp.NickName + " is Salaried. No need to Clock Out.");
                return;
            }
        }

        if (emp.ClockInReq == true)
        {
            ClockingOutEmployee = new ClockOut_UC(emp, hasOpenTables);     // , tipableSales, chargedSales, chargedTips)
            ClockingOutEmployee.Location = new Point((this.Width - ClockingOutEmployee.Width) / 2, (this.Height - ClockingOutEmployee.Height) / 2);
            if (currentServer.Server == false & currentServer.Bartender == false & currentServer.Cashier == false & currentServer.Manager == false)
            {
                ClockingOutEmployee.EitherPrintOrClockOut(true);
                ClockingOutEmployee.Dispose();
            }
            else
            {
                this.Controls.Add(ClockingOutEmployee);
                ClockingOutEmployee.BringToFront();
            }
        }

        else
        {
            Interaction.MsgBox(emp.FullName + " does not use time clock.");
        }

    }

    private void clockingOutComplete()
    {
        loginPad.btnNumberClear_Click();
        pnlLogin.Visible = true;
        MakeLoginPadVisible();
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

        // 222 below

        return default;

        foreach (DataRow oRow in dsOrder.Tables("QuickTickets").Rows)
        {
            if (object.ReferenceEquals(oRow("ClosedSubTotal"), DBNull.Value))
            {
                currentTerminal.NumOpenTickets += 1;
            }
        }


        if (currentTerminal.NumOpenTickets > 0)
        {
            return true;
        }
        else
        {
            return false;
        }


    }




















    private void ClosedClockInUserControl(object sender, EventArgs e)
    {

        this.pnlLogin.Click += this.ReceiveFocus;

    }

    private void SetDateTime()
    {
        lblClockInDay.Text = Strings.Format(DateTime.Now, "dddd");
        lblClockInDate.Text = Strings.Format(DateTime.Now, "MMM d, yyyy");
        lblClockInTime.Text = Strings.Format(DateTime.Now, "h:mm tt");


    }


    private bool InitialLogIn(string leUsername, string lePassword)
    {

        // Dim daysBeforeExpiration As Integer

        // Dim theNetworkInterfaces() As System.Net.NetworkInformation.NetworkInterface = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
        // For Each currentInterface As System.Net.NetworkInformation.NetworkInterface In theNetworkInterfaces
        // MessageBox.Show(currentInterface.GetPhysicalAddress().ToString())
        // Next

        // 444     daysBeforeExpiration = DateDiff(DateInterval.Day, Now, dateOfExpiration)
        // If daysBeforeExpiration < 0 Then
        // Me.Dispose()
        // ElseIf daysBeforeExpiration < 14 Then
        // MsgBox("Your subscription will expire in " & daysBeforeExpiration & " days.")
        // End If

        if (typeProgram == "Demo" | typeProgram == "Online_Demo")
        {
            timeoutInterval = 10000;  // 100000
        }

        if (leUsername == "e" | leUsername == "eglobal")
        {
            leUsername = "eglobal";
            // localConnectServer = leUsername & "\" & leUsername
            localConnectServer = @"eglobalmain\eglobalmain";
        }
        else
        {
            localConnectServer = leUsername + @"\" + leUsername;
        }

        connectserver = localConnectServer;

        if (typeProgram == "Online_Demo")
        {
            CreateTableStructure();
            InitializeOpeningScreen();
            tablesFilled = true;
            OnlineDemoStartOfProgram();
            return default;
        }


        CreateTableStructure();
        PopulateCompanyInfo(ref leUsername);
        InitializeOpeningScreen();

        if (companyInfo.processor == "MerchantWare")
        {
            // 444         readAuth_MWE = New ReadCredit_MWE2.MainForm_MWE(companyInfo.CompanyID, dtCreditCardDetail)
            // 444         Me.readAuth_MWE.AxUSBHID1.PortOpen = True
        }
        dvUnAppliedPaymentsAndCredits_MWE = new DataView();

        // readAuth_MWE.btnSale_Encrpted_Swipe(1)
        // With dvUnAppliedPaymentsAndCredits_MWE
        // .Table = readAuth_MWE.dtPaymentsAndCreditsUnauthorized_MWE
        // .RowFilter = "Applied = False AND ExperienceNumber = '" & currentTable.ExperienceNumber & "' AND CheckNumber = '" & currentTable.CheckNumber & "'"
        // .Sort = "PaymentFlag"
        // End With
        // OpenPortAtStart()
        // readAuth_MWE.OpenPortAtStart()
        // End If

        if (ds.Tables("LocationOverview").Rows.Count == 0)
        {
            return default;
        }

        if (companyInfo.endOfWeek == 7)
        {
            companyInfo.begOfWeek = 1;
        }
        else
        {
            companyInfo.begOfWeek = companyInfo.endOfWeek - 6;
        }

        if (lePassword == companyInfo.locationPassword)
        {
            if (tablesFilled == false)
            {
                StartOfProgram(companyInfo.companyName);
            }
            else
            {
                DisplayOpeningScreen(companyInfo.companyName);
            }
            initLogon.Dispose();
        }
        else
        {
            // password incorrent
            IncorrectInitLogin();
        }

        return default;

    }

    private void ExpOverrideResult()
    {

        if (expOverride.EnteredString == "Pass")
        {
            dateOfExpiration = "01/01/2099";
            InitializeOther();
        }
        else
        {
            this.Dispose();
        }

    }
    private void CreateTableStructure()
    {

        DataRow sRow;
        string mTable;

        try
        {
            // we need to do this first b/c MainTable___ & ModifierTable___ rely on these
            // CreateAllFoodCategoryTableStructure(dtStarterAllFoodCategory)
            // CreateModifierCategoryTableStructure(dtStarterModifierCategory)
            CreateDrinkAddsTableStructure(dtDrinkAdds);
            CreateDrinkTableStructure(dtDrink);
            CreateDrinkSubCategoryTableStructure(dtDrinkSubCategory);
            // CreateDrinkModifiersTableStructure(dtDrinkModifiers)
            CreateDrinkPrepTableStructure(dtDrinkPrep);
            CreateLiquorTypesTableStructure(dtLiquorTypes);
            CreateCatJoinTableStructure(dtCategoryJoin);


            CreateLocationOverviewTableStructure(dtLocationOverview);
            CreateLocationOpeningTableStructure(dtLocationOpening);
            CreateModifierCategoryTableStructure(dtModifierCategory);
            CreateAllFoodCategoryTableStructure(dtAllFoodCategory);
        }


        // the following two are now loaded from local db
        // CreateAllEmployeesTableStructure(dtAllEmployees)
        // CreateJobCodeInfoTableStructure(dtJobCodeInfo)

        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message + " Creating Table Struture 1");
        }

        // Try
        // dsStarter.Clear()
        // dsStarter.ReadXml("c:\Data Files\spiderPOS\StarterMenu.xml", XmlReadMode.ReadSchema)
        // Catch ex As Exception
        // 
        // End Try

        // doing below
        // Try
        // mainCategoryIDArrayList.Clear()
        // secondaryCategoryIDArrayList.Clear()
        // For Each sRow In dsStarter.Tables("StarterModifierCategory").Rows
        // mTable = "ModifierTable" & sRow("CategoryID")
        // CreateModifierTableStructure(mTable)
        // mainCategoryIDArrayList.Add(sRow("CategoryID"))
        // '       secondaryCategoryIDArrayList.Add(sRow("CategoryID"))
        // Next
        // Catch ex As Exception
        // 
        // End Try


        try
        {
            // stage 2
            CreateTermsWallsTableStructure(dtTermsWalls);
            CreateTermsTablesTableStructure(dtTermsTables);
            CreateTermsFloorTableStructure(dtTermsFloor);
            CreateTerminalsUseOrderTableStructure(dtTerminalsUseOrder);
            CreateTerminalsMethodTableStructure(dtTerminalsMethod);
            CreateCouponTableStructure(dtCoupon);
            CreateComboDetailTableStructure(dtComboDetail);
            CreateComboTableStructure(dtCombo);
            CreateBSGSTableStructure(dtBSGS);
            CreatePromotionTableStructure(dtPromotion);

            CreateFoodTableTableStructure(dtFoods);
            CreateIngredientsTableStructure(dtIngredients);



            // Inventory
            // CreateRawCategoryTableStructure(dtRawCategory)
            // CreateRawMatTableStructure(dtRawMat)
            // CreateRawDeliveryTableStructure(dtRawDelivery)
            // CreateRawDeliveryTableStructure(dtRawCycley)

            // ***********
            // need to add
            // Friend dtRawCategory As DataTable = ds.Tables.Add("RawCategory")
            // Friend dtRawMat As DataTable = ds.Tables.Add("RawMat")

            CreateReasonsVoidTableStructure(dtReasonsVoid);
            CreateTabIdentifierTableStructure(dtTabIdentifier);
            CreateCreditCardDetailTableStructure(dtCreditCardDetail);
            CreateRoutingChoiceTableStructure(dtRoutingChoice);
            CreateShiftCodesTableStructure(dtShiftCodes);
            CreateMenuChoiceTableStructure(dtMenuChoice);
            CreateTaxTableStructure(dtTax);
            CreateTableStatusDescriptionTableStructure(dtTableStatusDesc);
        }

        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message + " Creating Table Struture 2");
        }

        try
        {
            // this is third round of data pull
            // therefore the tables are set up seperately
            // there may be the above tables structured but not these
            CreateBarDrinkCatTableStructure(dtSecondaryBartenderDrinkCategory);
            CreateBarDrinkCatTableStructure(dtBartenderDrinkCategory);
            CreateBarCatTableStructure(dtSecondaryBartenderCategory);
            CreateBarCatTableStructure(dtBartenderCategory);

            CreateIndJoinTableStructure(dtIndividualJoinSecondary);
            CreateIndJoinTableStructure(dtIndividualJoinMain);
            CreateMainDrinkCatTableStructure(dtSecondaryDrinkCategory);
            CreateMainDrinkCatTableStructure(dtDrinkCategory);
            CreateMainCatTableStructure(dtSecondaryMainCategory);
            CreateMainCatTableStructure(dtMainCategory);


            mainCategoryIDArrayList.Clear();
            secondaryCategoryIDArrayList.Clear();

            // we need to use the Starter dataset
            foreach (DataRow currentSRow in dsStarter.Tables("StarterAllFoodCategory").Rows)
            {
                sRow = currentSRow;

                mTable = "SecondaryMainTable" + sRow("CategoryID");
                CreateMainTableStructure(mTable);
                if (sRow("FunctionFlag") == "G")
                {
                    mTable = "DrinkMainTable" + sRow("CategoryID");
                    CreateDrinkMainTableStructure(mTable);
                    mTable = "MainTable" + sRow("CategoryID");
                    CreateMainTableStructure(mTable);
                }
                else
                {
                    mTable = "MainTable" + sRow("CategoryID");
                    CreateMainTableStructure(mTable);
                }
                mainCategoryIDArrayList.Add(sRow("CategoryID"));
                secondaryCategoryIDArrayList.Add(sRow("CategoryID"));
            }
            foreach (DataRow currentSRow1 in dsStarter.Tables("StarterModifierCategory").Rows)
            {
                sRow = currentSRow1;
                mTable = "ModifierTable" + sRow("CategoryID");
                CreateModifierTableStructure(mTable);

                mainCategoryIDArrayList.Add(sRow("CategoryID"));
                secondaryCategoryIDArrayList.Add(sRow("CategoryID"));
            }


            CreateQuickDrinkCatTableStructure(dtSecondaryQuickDrinkCategory);
            CreateQuickDrinkCatTableStructure(dtQuickDrinkCategory);
            CreateQuickCatTableStructure(dtSecondaryQuickCategory);
            CreateQuickCatTableStructure(dtQuickCategory);



            // dsEmployee
            CreateLoggedInEmployeeTableStructure(dtLoggedInEmploees);
            CreateAllEmployeesTableStructure(dtAllEmployees);
            CreateJobCodeInfoTableStructure(dtJobCodeInfo);


            CreateClockOutSalesTableStructure(dtClockOutSales);


            // dsOrders
            CreateOpenOrdersTableStructure(dtOpenOrders);
            CreatePaymentsAndCreditsTableStructure(dtPaymentsAndCredits);
            CreateAvailTablesAndTabsTableStructure(dtAvailTables);
            CreateAvailTablesAndTabsTableStructure(dtAvailTabs);
            CreateAllTablesTableStructure(dtAllTables);
            CreateOpenBusinessTableStructure(dtOpenBusiness);
            CreateFunctionsTableStructure(dtFunctions);
            CreatePaymentTypeTableStructure(dtPaymentType);
            CreateOrderDetailTableStructure(dtOrderDetail);
            CreateTermsOpenTableStructure(dtTermsOpen);
            CreateAvailTablesAndTabsTableStructure(dtQuickTickets);
            CreateAvailTablesAndTabsTableStructure(dtCurrentlyHeld);

            // dsCustomers

            CreateTabDirectorySearchTableStructure(dtTabDirectorySearch);
            CreateTabPreviousOrdersTableStructure(dtTabPreviousOrders);
            CreateTabPreviousOrdersByItemTableStructure(dtTabPreviousOrdersByItem);
        }

        // missing many others:



        catch (Exception ex)
        {

            Interaction.MsgBox(ex.Message + " Creating Table Struture 3");
        }
    }

    private bool InitialLogInOld222(string leUsername, string lePassword)
    {

        string username;
        string password;

        // If System.Windows.Forms.SystemInformation.ComputerName = "VAIO" Then
        // localConnectServer = "vaio\vaio"
        // If leUsername = "l" Then
        // leUsername = "labmain"
        // End If
        // ElseIf System.Windows.Forms.SystemInformation.ComputerName = "LABMAIN" Then
        // leUsername = "labmain"
        // localConnectServer = "LABMAIN\labmain"
        // '     ElseIf leUsername = "e" Then
        // localConnectServer = "LABMAIN\labmain"
        // Else
        // localConnectServer = leUsername & "\" & leUsername
        // End If

        // MsgBox(System.Windows.Forms.SystemInformation.Network)

        // localConnectServer = "vaio\vaio"

        if (leUsername == "e")
        {
            leUsername = "eglobalmain";
        }

        if (leUsername == "eglobalmain")
        {
        }
        // i keep changing during testing
        // localConnectServer = "vaio\vaio"
        // localConnectServer = "Phoenix\Phoenix"
        else
        {
            localConnectServer = leUsername + @"\" + leUsername;
        }
        if (System.Windows.Forms.SystemInformation.ComputerName == "DILEO222")
        {
            // localConnectServer = "FOLEYCOMPUTER\FoleyComputer"
            localConnectServer = @"dileo\dileo";
            // MsgBox(localConnectServer.ToString)
        }

        // tttt()
        // TempConnectToPhoenix()
        connectserver = localConnectServer;
        GenerateOrderTables.RestateConnectionString(sql.cn, connectserver);

        try
        {
            GenerateOrderTables.InitiateApplicationSecurity222();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
            if (Interaction.MsgBox("Local Database Not Connected. Please select Cancel and attempt to reset your local database, otherwise select OK to connect to DataCenter.", MsgBoxStyle.OkCancel) == MsgBoxResult.Cancel)
            {
                this.Dispose();
            }
            else
            {
                Interaction.MsgBox("Call 404.869.4700 - inform them of problem: During security initiation, " + ex.Message);
            }
            GenerateOrderTables.SwitchConnection();
            // we initaite Security in switch connection
            if (securityPhoenixEst == false & securityLocalEst == false)
            {
                // at least one must be true if we were to make a connection
                GenerateOrderTables.InitiateApplicationSecurity222();
            }

        }


        try
        {
            PopulateCompanyInfo(ref leUsername);
        }

        catch (Exception ex)
        {
            CloseConnection();
            if (Interaction.MsgBox("Local Database Not Connected. Please select Cancel and attempt to reset your local database, otherwise select OK to connect to DataCenter.", MsgBoxStyle.OkCancel) == MsgBoxResult.Cancel)
            {
                this.Dispose();
            }
            else
            {
                Interaction.MsgBox("Call 404.869.4700 - inform them of problem: During initial download, " + ex.Message);
            }
            if (connectserver == @"Phoenix\Phoenix")
            {
                Interaction.MsgBox("DataCenter Not Connected. Verify all wire connection are established and your router is working. Then call 404-869-4700: " + ex.Message);
                this.Dispose();
            }
            else
            {
                GenerateOrderTables.SwitchConnection();
                try
                {
                    PopulateCompanyInfo(ref leUsername);
                }
                catch (Exception ex2)
                {
                    CloseConnection();
                    Interaction.MsgBox("DataCenter Not Connected. Verify all wire connection are established and your router is working. Then call 404-869-4700: " + ex2.Message);
                    this.Dispose();
                }
            }
        }

        if (companyInfo.endOfWeek == 7)
        {
            companyInfo.begOfWeek = 1;
        }
        else
        {
            companyInfo.begOfWeek = companyInfo.endOfWeek - 6;
        }


        if (lePassword == companyInfo.locationPassword)
        {
            if (tablesFilled == false)
            {
                StartOfProgram(companyInfo.companyName);
            }
            else
            {
                DisplayOpeningScreen(companyInfo.companyName);
            }
            initLogon.Dispose();
        }
        else
        {
            // password incorrent
            IncorrectInitLogin();
        }

        return default;


    }

    private void PopulateCompanyInfo(ref string leUsername)
    {

        DataRow oRow;

        try
        {
            GenerateOrderTables.TempConnectToPhoenix();

            ds.Tables("LocationOverview").Rows.Clear();
            dsStarter.Tables("StarterLocationOverview").Rows.Clear();

            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlSelectCommandLocationOverview.Parameters("@Username").Value = leUsername;
            sql.SqlLocationOverview.Fill(ds.Tables("LocationOverview"));
            sql.SqlLocationOverview.Fill(dsStarter.Tables("StarterLocationOverview"));

            sql.cn.Close();
            GenerateOrderTables.ConnectBackFromTempDatabase();

            if (ds.Tables("LocationOverview").Rows.Count == 1)  // dtr.HasRows Then
            {
                oRow = ds.Tables("LocationOverview").Rows(0);
                FillLocationOverviewData(oRow);
            }
            else
            {
                IncorrectUsername(leUsername);
            }
        }
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);
            CloseConnection();
            GenerateOrderTables.ConnectBackFromTempDatabase();
            Interaction.MsgBox("Connection to DataCenter down. If this is not the first time you are receiving this message... Call Spider POS (404) 869-4700");
            // MsgBox(ex.Message & " Connection Down, Populating COmpany Info. Select saved menu.")
            ServerNOTConectedStartOfProgram();
        }
        finally
        {
        }

    }


    private void OldPopulateCompany222(ref string leUsername)
    {
        // use above sub
        SqlClient.SqlCommand cmd;
        SqlClient.SqlDataReader dtr;

        cmd = new SqlClient.SqlCommand("SELECT CompanyID, LocationID, CompanyName, LocationName, Username, Password, Address1, Address2, City, State, Zip, PhoneNumber, UsingDefaults, AutoPrint, EndOfWeek, OnlyOneLocation, MerchantID, MerchantIDPhone, OperatorID, LocalHostName, dbName, NumberTerminals, NumberFloorPlans, TimeoutSeconds, ColorAdjust, VersionNumber, LastUpdate, AutoUpdate, UsingBartenderMethod, CalculateAvgByEntrees, IsKitchenExpiditer, IsDelivery, AutoCloseCheck, DeliveryCharge, ToGoCharge, AutoGratuity, SalesTax, ReceiptMessage1, ReceiptMessage2, ReceiptMessage3, CCMessage1, CCMessage2, DigitsInTicketNumber FROM LocationOverview WHERE Username = '" + leUsername + "'", sql.cn);
        // cmd = New SqlClient.SqlCommand("SELECT CompanyName, Address1, Address2, City, State, Zip, PhoneNumber, Username, Password, UsingDefaults, AutoPrint, EndOfWeek FROM LocationOverview WHERE CompanyID = '" & CompanyID & "' AND LocationID = '" & LocationID & "'", sql.cn)
        dtr = cmd.ExecuteReader;
        dtr.Read();

        if (dtr.HasRows) // dtr.HasRows Then
        {
            companyInfo.CompanyID = dtr("CompanyID");
            companyInfo.LocationID = dtr("LocationID");
            companyInfo.companyName = dtr("CompanyName");
            if (!object.ReferenceEquals(dtr("LocationName"), DBNull.Value))
            {
                companyInfo.locationName = dtr("LocationName");
            }
            companyInfo.locationUsername = dtr("Username");
            companyInfo.locationPassword = dtr("Password");
            companyInfo.locationCity = dtr("City");
            companyInfo.locationState = dtr("State");
            companyInfo.address1 = dtr("Address1");
            companyInfo.address2 = dtr("Address2");
            companyInfo.locationPhone = dtr("PhoneNumber");
            companyInfo.usingDefaults = dtr("UsingDefaults");
            companyInfo.autoCloseCheck = dtr("AutoPrint");
            companyInfo.endOfWeek = dtr("EndOfWeek");
            companyInfo.onlyOneLocation = dtr("OnlyOneLocation");
            if (!object.ReferenceEquals(dtr("MerchantID"), DBNull.Value))
            {
                companyInfo.merchantID = dtr("MerchantID");
            }
            if (!object.ReferenceEquals(dtr("MerchantIDPhone"), DBNull.Value))
            {
                companyInfo.merchantIDPhone = dtr("MerchantIDPhone");
            }
            if (!object.ReferenceEquals(dtr("OperatorID"), DBNull.Value))
            {
                companyInfo.operatorID = dtr("OperatorID");
            }
            if (!object.ReferenceEquals(dtr("LocalHostName"), DBNull.Value))
            {
                companyInfo.localHostName = dtr("LocalHostName");
            }
            if (!object.ReferenceEquals(dtr("dbName"), DBNull.Value))
            {
                companyInfo.dbName = dtr("dbName");
            }

            companyInfo.numberOfTerminals = dtr("NumberTerminals");
            companyInfo.numberOfFloorPlans = dtr("NumberFloorPlans");
            companyInfo.timeoutMultiplier = dtr("TimeoutSeconds");
            companyInfo.colorAdjust = dtr("ColorAdjust");
            if (!object.ReferenceEquals(dtr("VersionNumber"), DBNull.Value))
            {
                companyInfo.VersionNumber = dtr("VersionNumber");
            }
            if (!object.ReferenceEquals(dtr("LastUpdate"), DBNull.Value))
            {
                companyInfo.lastUpdate = dtr("LastUpdate");
            }
            companyInfo.autoUpdate = dtr("AutoUpdate");
            companyInfo.usingBartenderMethod = dtr("UsingBartenderMethod");
            companyInfo.calculateAvgByEntrees = dtr("CalculateAvgByEntrees");
            companyInfo.isKitchenExpiditer = dtr("IsKitchenExpiditer");
            companyInfo.isDelivery = dtr("IsDelivery");
            companyInfo.autoCloseCheck = dtr("AutoCloseCheck");
            companyInfo.deliveryCharge = dtr("DeliveryCharge");
            companyInfo.togoCharge = dtr("ToGoCharge");
            companyInfo.autoGratuityPercent = dtr("AutoGratuity");
            companyInfo.salesTax = dtr("SalesTax");

            if (!object.ReferenceEquals(dtr("ReceiptMessage1"), DBNull.Value))
            {
                companyInfo.receiptMessage1 = dtr("ReceiptMessage1");
            }
            if (!object.ReferenceEquals(dtr("ReceiptMessage2"), DBNull.Value))
            {
                companyInfo.receiptMessage2 = dtr("ReceiptMessage2");
            }
            if (!object.ReferenceEquals(dtr("ReceiptMessage3"), DBNull.Value))
            {
                companyInfo.receiptMessage3 = dtr("ReceiptMessage3");
            }
            if (!object.ReferenceEquals(dtr("CCMessage1"), DBNull.Value))
            {
                companyInfo.CCMessage1 = dtr("CCMessage1");
            }
            if (!object.ReferenceEquals(dtr("CCMessage2"), DBNull.Value))
            {
                companyInfo.CCMessage2 = dtr("CCMessage2");
            }

            companyInfo.digitsInTicketNumber = dtr("DigitsInTicketNumber");
        }
        else
        {
            dtr.Close();
            sql.cn.Close();
            IncorrectUsername(leUsername);
            return;
        }

        dtr.Close();
        sql.cn.Close();
    }


    private void IncorrectUsername(string leUsername)
    {
        DataSet_Builder.Information_UC info;

        initLogon.LoginUsername = "";
        initLogon.LoginPassword = "";
        initLogon.txtLoginUsername.Text = "";
        initLogon.txtLoginPassword.Text = "";

        initLogon.RessetFocus();

        info = new DataSet_Builder.Information_UC("Username " + leUsername + " can not be found or incorrect Password.");
        info.Location = new Point((this.Width - info.Width) / 2, (this.Height - info.Height) / 2);
        this.Controls.Add(info);
        info.BringToFront();

    }

    private void IncorrectInitLogin()
    {
        DataSet_Builder.Information_UC info;

        initLogon.LoginUsername = "";
        initLogon.LoginPassword = "";
        initLogon.txtLoginUsername.Text = "";
        initLogon.txtLoginPassword.Text = "";

        initLogon.RessetFocus();

        info = new DataSet_Builder.Information_UC("Incorrect Password.");
        info.Location = new Point((this.Width - info.Width) / 2, (this.Height - info.Height) / 2);
        this.Controls.Add(info);
        info.BringToFront();

    }

    private void TestManagerAccess()
    {


    }


    private void ClockInEmployeeClicked()
    {
        // Dim clockInJunk As ClockInInfo
        // 
        // clockInJunk = sender
        // ClockInEmployee(clockInJunk, True)
        Interaction.MsgBox(currentClockEmp.FullName + " has just clocked in at: " + DateTime.Now.ToString());
        loginPad.btnNumberClear_Click();
        pnlLogin.Visible = true;
        MakeLoginPadVisible();

        this.pnlLogin.Click += this.ReceiveFocus;

    }








    private object ClockInEmployeeTerminal222(ClockInInfo222 clockInJunk)
    {
        var newEmployee = default(Employee);

        foreach (DataRow oRow in dsBackup.Tables("EmployeeTerminal").Rows)
        {
            if (oRow("EmployeeNumber") == clockInJunk.EmpID)
            {
                newEmployee.EmployeeID = oRow("EmployeeID");
                newEmployee.EmployeeNumber = clockInJunk.EmpID();
                newEmployee.FullName = oRow("FirstName") + " " + oRow("LastName");
                newEmployee.NickName = oRow("NickName");
                if (newEmployee.NickName.Length < 1)
                {
                    newEmployee.NickName = oRow("FirstName");
                }
                newEmployee.PasscodeID = oRow("Passcode");
                newEmployee.ReportMgmtAll = oRow("ReportMgmtAll");
                newEmployee.ReportMgmtLimited = oRow("ReportMgmtLimited");
                newEmployee.OperationMgmtAll = oRow("OperationMgmtAll");
                newEmployee.OperationMgmtLimited = oRow("OperationMgmtLimited");
                newEmployee.SystemMgmtAll = oRow("SystemMgmtAll");
                newEmployee.SystemMgmtLimited = oRow("SystemMgmtLimited");
                newEmployee.EmployeeMgmtAll = oRow("EmployeeMgmtAll");
                newEmployee.EmployeeMgmtLimited = oRow("EmployeeMgmtLimited");
            }
        }

        return newEmployee;

    }


    private void Button1_Click(object sender, EventArgs e)
    {

        GC.Collect();
        return;


        Employee eee;

        currentTerminal.CurrentDailyCode = 2;
        companyInfo.CompanyID = "001111";
        companyInfo.LocationID = "000001";

        try
        {
            PopulateOrderTables(true);

            GenerateOverrideCodes();

            // 222      PopulateTableStatusDesc()

            // 222      PopulateOpenTablesAtStartup()
            SetUpPrimaryKeys();

            OnlyForSkippingLogin222();
        }
        catch (Exception ex)
        {
            CloseConnection();


        }


        this.pnlLogin.Click += this.ReceiveFocus;

        // currentMenu = New Menu(primaryMenuID, True)
        // If secondaryMenuID > 0 Then
        // secondaryMenu = New Menu(secondaryMenuID, False)
        // End If


        var newEmployee = new Employee();

        newEmployee.EmployeeID = "1234";
        newEmployee.FullName = "Eric Petruzzelli";
        newEmployee.NickName = "Eric";
        newEmployee.PasscodeID = "1111";
        newEmployee.ShiftID = currentTerminal.CurrentShift;
        newEmployee.dbUP = true;

        newEmployee.JobCodeName = "Manager";
        newEmployee.Manager = true;
        newEmployee.Cashier = false;
        newEmployee.Bartender = false;
        newEmployee.Server = false;
        newEmployee.Hostess = false;
        newEmployee.PasswordReq = true;
        newEmployee.ClockInReq = false;
        newEmployee.ReportTipsReq = false;
        newEmployee.ShareTipsReq = false;
        newEmployee.ReportMgmtAll = true;
        newEmployee.ReportMgmtLimited = true;
        newEmployee.OperationMgmtAll = true;
        newEmployee.OperationMgmtLimited = true;
        newEmployee.SystemMgmtAll = true;
        newEmployee.SystemMgmtLimited = true;
        newEmployee.EmployeeMgmtAll = true;
        newEmployee.EmployeeMgmtLimited = true;

        GenerateWorkingCollections.AddEmployeeToWorkingCollection(newEmployee);
        currentManagers.Add(newEmployee);
        // todaysFloorPersonnel.Add(newEmployee)

        newEmployee = new Employee();

        newEmployee.EmployeeID = "1111";
        newEmployee.FullName = "Mark Manager";
        newEmployee.NickName = "Mark";
        newEmployee.JobCodeName = "Manager";
        newEmployee.PasscodeID = "1111";
        newEmployee.ShiftID = currentTerminal.CurrentShift;
        newEmployee.dbUP = true;

        newEmployee.Manager = true;
        newEmployee.Cashier = false;
        newEmployee.Bartender = false;
        newEmployee.Server = false;
        newEmployee.Hostess = false;
        newEmployee.PasswordReq = true;
        newEmployee.ClockInReq = false;
        newEmployee.ReportTipsReq = false;
        newEmployee.ShareTipsReq = false;
        newEmployee.ReportMgmtAll = false;
        newEmployee.ReportMgmtLimited = true;
        newEmployee.OperationMgmtAll = false;
        newEmployee.OperationMgmtLimited = true;
        newEmployee.SystemMgmtAll = false;
        newEmployee.SystemMgmtLimited = true;
        newEmployee.EmployeeMgmtAll = false;
        newEmployee.EmployeeMgmtLimited = true;

        GenerateWorkingCollections.AddEmployeeToWorkingCollection(newEmployee);
        currentManagers.Add(newEmployee);
        // todaysFloorPersonnel.Add(newEmployee)

        newEmployee = new Employee();

        newEmployee.EmployeeID = "4001";
        newEmployee.FullName = "Beth Bartender";
        newEmployee.NickName = "Beth";
        newEmployee.JobCodeName = "Bartender";
        newEmployee.PasscodeID = "1111";
        newEmployee.ShiftID = currentTerminal.CurrentShift;
        newEmployee.dbUP = true;

        newEmployee.Manager = false;
        newEmployee.Cashier = false;
        newEmployee.Bartender = true;
        newEmployee.Server = false;
        newEmployee.Hostess = false;
        newEmployee.PasswordReq = false;
        newEmployee.ClockInReq = true;
        newEmployee.ReportTipsReq = true;
        newEmployee.ShareTipsReq = false;
        newEmployee.ReportMgmtAll = false;
        newEmployee.ReportMgmtLimited = true;
        newEmployee.OperationMgmtAll = false;
        newEmployee.OperationMgmtLimited = true;
        newEmployee.SystemMgmtAll = false;
        newEmployee.SystemMgmtLimited = true;
        newEmployee.EmployeeMgmtAll = false;
        newEmployee.EmployeeMgmtLimited = false;

        GenerateWorkingCollections.AddEmployeeToWorkingCollection(newEmployee);
        // ************************************
        // next line only for bartender job
        currentBartenders.Add(newEmployee);
        // todaysFloorPersonnel.Add(newEmployee)



        newEmployee = new Employee();

        newEmployee.EmployeeID = "4002";
        newEmployee.FullName = "Benjamin Bartender";
        newEmployee.NickName = "Ben";
        newEmployee.JobCodeName = "Bartender";
        newEmployee.PasscodeID = "1111";
        newEmployee.ShiftID = currentTerminal.CurrentShift;
        newEmployee.dbUP = true;

        newEmployee.Manager = false;
        newEmployee.Cashier = false;
        newEmployee.Bartender = true;
        newEmployee.Server = false;
        newEmployee.Hostess = false;
        newEmployee.PasswordReq = false;
        newEmployee.ClockInReq = true;
        newEmployee.ReportTipsReq = true;
        newEmployee.ShareTipsReq = false;
        newEmployee.ReportMgmtAll = false;
        newEmployee.ReportMgmtLimited = false;
        newEmployee.OperationMgmtAll = false;
        newEmployee.OperationMgmtLimited = false;
        newEmployee.SystemMgmtAll = false;
        newEmployee.SystemMgmtLimited = false;
        newEmployee.EmployeeMgmtAll = false;
        newEmployee.EmployeeMgmtLimited = false;

        GenerateWorkingCollections.AddEmployeeToWorkingCollection(newEmployee);
        // ************************************
        // next line only for bartender job
        currentBartenders.Add(newEmployee);
        // todaysFloorPersonnel.Add(newEmployee)



        newEmployee = new Employee();

        newEmployee.EmployeeID = "2000";
        newEmployee.FullName = "Samuel Server";
        newEmployee.NickName = "Sam";
        newEmployee.JobCodeName = "Server";
        newEmployee.PasscodeID = "1111";
        newEmployee.ShiftID = currentTerminal.CurrentShift;
        newEmployee.dbUP = true;

        newEmployee.Manager = false;
        newEmployee.Cashier = false;
        newEmployee.Bartender = false;
        newEmployee.Server = true;
        newEmployee.Hostess = false;
        newEmployee.PasswordReq = false;
        newEmployee.ClockInReq = true;
        newEmployee.ReportTipsReq = true;
        newEmployee.ShareTipsReq = true;
        newEmployee.ReportMgmtAll = false;
        newEmployee.ReportMgmtLimited = false;
        newEmployee.OperationMgmtAll = false;
        newEmployee.OperationMgmtLimited = false;
        newEmployee.SystemMgmtAll = false;
        newEmployee.SystemMgmtLimited = false;
        newEmployee.EmployeeMgmtAll = false;
        newEmployee.EmployeeMgmtLimited = false;

        GenerateWorkingCollections.AddEmployeeToWorkingCollection(newEmployee);
        // ************************************
        currentServers.Add(newEmployee);
        // todaysFloorPersonnel.Add(newEmployee)

        if (initLogon is not null)
        {
            initLogon.Dispose();
        }

        foreach (Employee emp in AllEmployees)
        {
            if (emp.EmployeeNumber == "4001")         // this logs in Beth
            {
                // 222    LoginEmployee(emp)
                PerformEmployeeFunctions(emp);
            }
        }


    }

    private void OnlyForSkippingLogin222()
    {

        // 
        // sql.SqlSelectCommandCurrentTables.Parameters("@CompanyID").Value = CompanyID
        // sql.SqlSelectCommandCurrentTables.Parameters("@LocationID").Value = LocationID

        // Try
        // '   gets a collection of all tables in TableOverview
        // sql.cn.Open()
        // sql.SqlDataAdapterCurrentTables.Fill(dsOrder.Tables("CurrentTables"))
        // sql.cn.Close()
        // Catch ex As Exception
        // '          CloseConnection()

        // End Try

        // sql.SqlSelectCommandClockedIn.Parameters("@CompanyID").Value = CompanyID
        sql.SqlSelectCommandClockedIn.Parameters("@LocationID").Value = companyInfo.LocationID;

        try
        {
            // this is used in each time the emp pulls their tables
            // it poplutes their current job codes and authorization
            // populates logged-In employees
            // All employees in LoginTracking where LogOut datetime IS Null
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlClockedIn.Fill(dsEmployee.Tables("LoggedInEmployees"));
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
        }

        // this is a one time sub: only when starting total solution
        // once done we keep track of status by Statustbl#

        SqlClient.SqlDataReader dtr;
        int tn;

        int maxExpForTable;
        var currentStatus = default(int);
        var currentStatusTime = default(DateTime);

        sql.cn.Open();
        sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
        foreach (DataRow oRow in dsOrder.Tables("CurrentTables").Rows)
        {
            // must change above
            maxExpForTable = 0;   // reseting
            tn = oRow("TableNumber");

            var cmd = new SqlClient.SqlCommand("SELECT MAX(ExperienceNumber) _maxExp FROM ExperienceTable WHERE TableNumber = '" + tn + "'", sql.cn);
            dtr = cmd.executereader;
            dtr.Read();
            if (!object.ReferenceEquals(dtr("_maxExp"), DBNull.Value))
            {
                maxExpForTable = dtr("_maxExp");
            }
            dtr.Close();

            if (!(maxExpForTable == 0))
            {
                cmd = new SqlClient.SqlCommand("SELECT TableStatusID, StatusTime FROM ExperienceStatusChange WHERE ExperienceNumber = '" + maxExpForTable + "'", sql.cn);
                // since input to this table is cronological : the last entry is the last status
                dtr = cmd.executereader;
                while (dtr.Read())
                {
                    currentStatus = dtr("TableStatusID");
                    currentStatusTime = dtr("StatusTime");
                }
                dtr.Close();
            }

            // only when table has never had an experience (may change)
            else
            {
                foreach (DataRow nRow in dsOrder.Tables("CurrentTables").Rows)
                {
                    if (nRow("TableNumber") == tn)
                    {
                        if (nRow("Available") == true)
                        {
                            currentStatus = 1;
                        }
                        else
                        {
                            currentStatus = 0;
                        }
                        break;
                    }
                }
                currentStatusTime = DateTime.Now;
            }

            AssignStatus222(tn, currentStatus, currentStatusTime);
            // this is just for when we initialize the program
            // at the beginning of the day
        }
        sql.cn.Close();

    }

    private void StartRecoTimer222()
    {
        infoRecoTimer = new DateAndTime.Timer();
        this.infoRecoTimer.Tick += RemoveInfoReco;
        infoRecoTimer.Interval = 2000;
        infoRecoTimer.Start();

        infoReconnect = new DataSet_Builder.Information_UC("Attempting to Reconnect To Server");
        infoReconnect.Location = new Point((this.Width - infoReconnect.Width) / 2, (this.Height - infoReconnect.Height) / 2);
        this.Controls.Add(infoReconnect);
        infoReconnect.BringToFront();

    }

    private void ClosingTableScreen()
    {
        // this is our exit from table_screen

        pnlLogin.Visible = true;
        MakeTable_ScreenNotVisible();
        readAuth.ActiveScreen = "Login";
        // tableScreen.Visible = False
        SetDateTime();

        // If mainServerConnected = False Then
        // CheckingDatabaseConection()
        // MsgBox(mainServerConnected, , "Server UP?????")
        // End If

        // ********
        // 911 for tesing only
        // Dim emp As Employee
        // emp = GenerateOrderTables.TestUsernamePassword("4001", False)
        // LoginEmployee(emp)
        // loginPad.btnNumberClear_Click()
        // pnlLogin.Visible = False
        // '     MakeLoginPadVisibleNOT()
        // MakeClockOutBooleanFalse()
        // 911

    }

    // ************
    // read Auth

    private void CardRead_Failed()
    {
        // ResetTimer()

        Interaction.MsgBox("Card Read FAILED");

        switch (readAuth.ActiveScreen)
        {
            case "Login":
                {
                    break;
                }

            case "OrderScreen":
                {
                    break;
                }

            case "CloseCheck":
                {
                    break;
                }

            case "SeatingTab":
                {
                    break;
                }

            case "DeliveryScreen":
                {
                    break;
                }

            case "Manager":
                {
                    break;
                }

        }
    }

    private void NewCardRead(ref DataSet_Builder.Payment newPayment)
    {
        // ResetTimer()

        switch (readAuth.ActiveScreen)
        {
            case "Login":
                {
                    break;
                }

            case "OrderScreen":
                {

                    if (currentTerminal.TermMethod == "Quick")
                    {
                        CloseScreenVisible(QuickOrder.IsManagerMode);
                        QuickOrder.Visible = false;
                    }
                    else
                    {
                        CloseScreenVisible(activeOrder.IsManagerMode);
                        activeOrder.Visible = false;
                    }
                    activeSplit._closeCheck.ProcessCreditRead(newPayment);
                    break;
                }

            case "CloseCheck":
                {
                    // ProcessCreditRead(newPayment)
                    activeSplit._closeCheck.ProcessCreditRead(newPayment);
                    break;
                }

            case "SeatingTab":
                {

                    if (activeSplit is null)
                    {
                        InitializeSplitChecks(false); // _isFromManager)
                        activeSplit.Visible = false;
                    }
                    activeSplit._closeCheck.ProcessCreditRead(newPayment);
                    currentTable.TabID = newPayment.TabID;
                    currentTable.TabName = newPayment.Name;
                    LoadTabIDinExperinceTable();

                    // CustomerLoyalty()
                    if (SeatingTab.StartedFrom == "Manager")
                    {
                        MgrOrderScreen();
                    }
                    else // If SeatingTab.StartedFrom = "OrderScreen" Then
                    {
                        var argtabAccountInfo = default;
                        OrderScreen(ref argtabAccountInfo);
                        // ElseIf SeatingTab.StartedFrom = "TableScreen" Then
                    }

                    SeatingTab.Visible = false;
                    tableScreen.EnableTables_Screen();
                    break;
                }
            // readAuth assiged in OrderScreen & MgrOrderScreen

            case "DeliveryScreen":
                {
                    // *** not sure if this is correct,not sure about
                    // the AddPayment Collection in Read Credit ????
                    // 444      GenerateOrderTables.CreateTabAcctPlaceInExperience(newpayment)
                    DeliveryScreen.TempAccountNumber = newPayment.SpiderAcct;
                    // might need to  SetAccountSearch() , currently we are doing before swipe activate

                    if (DeliveryScreen.attemptedToEdit == true)
                    {
                        DeliveryScreen.attemptedToEdit = false;
                        GenerateOrderTables.UpdateTabInfo(DeliveryScreen.StartInSearch);
                    }
                    GenerateOrderTables.PopulateSearchAccount(newPayment.SpiderAcct); // , -123456789)
                    DeliveryScreen.BindDataAfterSearch();
                    break;
                }

            case "Manager":
                {
                    break;
                }
        }

    }

    private void ManagementCardRead(DataSet_Builder.Employee emp)
    {
        // ResetTimer()
        string loginEnter;

        switch (readAuth.ActiveScreen)
        {
            case "Login":
                {

                    loginEnter = emp.EmployeeNumber + emp.PasscodeID;
                    LoginRoutine(loginEnter);
                    break;
                }
            // If Not managementScreen Is Nothing Then
            // we are doing this in LoginRoutine if Manager = True
            // readAuth.ActiveScreen = "Manager"
            // End If

            case "OrderScreen":
                {
                    if (currentTerminal.TermMethod == "Quick")
                    {
                        QuickOrder.Visible = false;
                    }
                    else
                    {
                        activeOrder.Visible = false;
                    }
                    if (SeatingTab is not null)
                    {
                        SeatingTab.Visible = false;
                    }
                    if (DeliveryScreen is not null)
                    {
                        DeliveryScreen.Visible = false;
                    }

                    GenerateOrderTables.ReleaseCurrentlyHeld();
                    GenerateOrderTables.SaveOpenOrderData();
                    loginEnter = emp.EmployeeNumber + emp.PasscodeID;
                    LoginRoutine(loginEnter);
                    if (managementScreen is not null)
                    {
                        if (currentTable.IsClosed == true)
                        {
                            GenerateOrderTables.CreateClosedDataViews();
                        }
                        managementScreen.DisplayOrderAdjustmentStep2(currentTable.ExperienceNumber, false, currentTable.IsClosed);
                    }

                    break;
                }


            case "CloseCheck":
                {
                    activeSplit.Visible = false;
                    // readAuth.GiftAddingAmount = False
                    // readAuth.IsNewTab = False

                    GenerateOrderTables.ReleaseCurrentlyHeld();
                    GenerateOrderTables.SaveOpenOrderData();
                    loginEnter = emp.EmployeeNumber + emp.PasscodeID;
                    LoginRoutine(loginEnter);

                    if (managementScreen is not null)
                    {
                        if (currentTable.IsClosed == true)
                        {
                            GenerateOrderTables.CreateClosedDataViews();
                        }
                        managementScreen.DisplayOrderAdjustmentStep2(currentTable.ExperienceNumber, false, currentTable.IsClosed);
                    }

                    break;
                }

            case "TableScreen":
                {
                    MakeTable_ScreenNotVisible();
                    // tableScreen.Visible = False
                    loginEnter = emp.EmployeeNumber + emp.PasscodeID;
                    LoginRoutine(loginEnter);
                    break;
                }

            case "SeatingTab":
                {
                    break;
                }

            case "DeliveryScreen":
                {
                    break;
                }

            case "Manager":
                {


                    if (managementScreen is not null)
                    {
                        // should always be something here, b/c from manager
                        if (managementScreen.mainManager is not null)
                        {
                            if (managementScreen.mainManager.mgrLargeNumberPad.Visible == true)
                            {
                                // managementScreen.mainManager.Dispose()
                                // managementScreen.mainManager = Nothing
                                managementScreen.Dispose();
                                managementScreen = default;

                                // if mainManager.visible  then we still not in Management area
                                loginEnter = emp.EmployeeNumber + emp.PasscodeID;
                                LoginRoutine(loginEnter);
                                // managementScreen.mainManager.Dispose()
                            }

                        }

                    }

                    break;
                }


                // GenerateOrderTables.AssignManagementAuthorization(actingManager)
                // DisplayLabelsBasedOnAuth()

        }

    }

    private void SetReadAuthValues()
    {
        readAuth.GiftAddingAmount = false;
        readAuth.IsNewTab = false;
        // readAuth.ActiveScreen = "Login"


        // we may not put below here, but in individual subs
        switch (readAuth.ActiveScreen)
        {
            case "Login":
                {
                    break;
                }

            case "CloseCheck":
                {
                    break;
                }

            case "SeatingTab":
                {
                    break;
                }
            // If tn Is Nothing Then
            // this means this is from Login, there is no Tab Name 
            // therefeor is for New Tab Open
            // readAuth.IsNewTab = True
            // End If
            case "DeliveryScreen":
                {
                    break;
                }

            case "Manager":
                {
                    break;
                }


        }
    }

    internal void EnterTabNameFromSwipe(string tabName)
    {
        switch (readAuth.ActiveScreen)
        {
            case "Login":
                {
                    break;
                }

            case "OrderScreen":
                {
                    break;
                }

            case "CloseCheck":
                {
                    break;
                }

            case "SeatingTab":   // Seating_EnterTab
                {
                    // currently Seating Tab is instantiated from 3 different places
                    // therfore this does not work
                    if (SeatingTab is not null)
                    {
                        SeatingTab.EnterTabNameFromSwipe(tabName);
                    }
                    else if (activeOrder is not null)
                    {
                        if (activeOrder.SeatingTab is not null)
                        {
                            activeOrder.SeatingTab.Dispose();
                        }
                    }
                    else if (QuickOrder is not null)
                    {
                        if (QuickOrder.SeatingTab is not null)
                        {
                            QuickOrder.SeatingTab.Dispose();
                        }
                    }
                    else if (managementScreen is not null)
                    {
                        if (managementScreen.SeatingTab is not null)
                        {
                            managementScreen.SeatingTab.Dispose();
                        }
                    }

                    break;
                }

            case "DeliveryScreen":
                {
                    break;
                }

            case "Manager":
                {
                    break;
                }

        }
    }

    private void ReturnGiftCardAddToFalseEvent()
    {

        switch (readAuth.ActiveScreen)
        {
            case "Login":
                {
                    break;
                }

            case "OrderScreen":
                {
                    break;
                }

            case "CloseCheck":
                {
                    activeSplit._closeCheck.ReturnGiftCardAddToFalse();
                    break;
                }

            case "SeatingTab":
                {
                    break;
                }

            case "TabEnterScreen":
                {
                    break;
                }

            case "Manager":
                {
                    break;
                }

        }

    }

    private void ClosingFastCash()
    {

        if (currentTerminal.TermMethod == "Quick")
        {
            CloseScreenVisible(QuickOrder.IsManagerMode);
        }
        else
        {
            CloseScreenVisible(activeOrder.IsManagerMode);
        }

        activeSplit._closeCheck.CashButtonClicked();
        foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("Applied") == false)
                {
                    oRow("Applied") = true;
                }
            }
        }

        if (ds.Tables("RoutingChoice").Rows.Count > 0)
        {
            // Routing = 0 means no service printer
            // this forces send order, if Bal zero =, but only is service printer
            if (currentTerminal.TermMethod == "Quick")
            {
                QuickOrder.SendingOrderRoutine();
            }
            else
            {
                activeOrder.SendingOrderRoutine();
            }
        }
        GenerateOrderTables.ReleaseTableOrTab();
        GenerateOrderTables.ReleaseCurrentlyHeld();
        GenerateOrderTables.SaveOpenOrderData();
        currentTable.IsClosed = true;
        if (currentTerminal.TermMethod == "Quick")
        {
            QuickOrder.GetReadyForNewTicket();
        }
        else
        {
            activeOrder.GetReadyForNewTicket();
        }

        // activeSplit._closeCheck.ClosingAndReleaseRoutine(True)
        activeSplit.Visible = false;
        readAuth.IsNewTab = false;

    }

    private void MakingGiftAddingAmountTrue()
    {

        readAuth.GiftAddingAmount = true;

    }


    private void RemoveInfoReco(object sender, EventArgs e)
    {
        infoReconnect.Dispose();

    }
    private void RemoveOpenButtonTest()
    {

        mainServerConnected = true; // just resetting
        tablesFilled = false;       // resetting
        this.pnlLogin.Click += this.ReceiveFocus;

        DisplayLoginScreen();
        SetDateTime();
        if (currentServer is null)
        {
            currentServer = new Employee();
        }
        if (currentClockEmp is null)
        {
            currentClockEmp = new Employee();
        }

        if (!(typeProgram == "Online_Demo"))
        {
            readAuth = new ReadCredit(false);
            readAuth.GiftAddingAmount = false;
            readAuth.IsNewTab = false;
            readAuth.ActiveScreen = "Login";
        }
    }

    private void ReReadCredit_Click()
    {

        if (readAuth is not null)
        {
            readAuth = default;
        }
        readAuth = new ReadCredit(false);
        readAuth.GiftAddingAmount = false;
        readAuth.IsNewTab = false;
        readAuth.ActiveScreen = "Login";

    }

    private void RemoveOpenButton(OpenInfo openingInfo)
    {
        // 222 I think
        var menuName = default(string);

        this.pnlLogin.Click += this.ReceiveFocus;

        // currentTable = New DinnerTable
        // currentServer = New Employee
        // currentTerminal = New Terminal

        currentTerminal.CurrentDailyCode = openingInfo.dailyCode;
        currentTerminal.primaryMenuID = openingInfo.pMenu;
        currentTerminal.secondaryMenuID = openingInfo.sMenu;
        currentTerminal.CurrentMenuID = openingInfo.pMenu;
        currentTerminal.initPrimaryMenuID = openingInfo.pMenu;
        currentTerminal.currentPrimaryMenuID = openingInfo.pMenu;

        if (openingInfo.termMethod is not null)
        {
            currentTerminal.TermMethod = openingInfo.termMethod;
        }
        // If currentTerminal.TermMethod = "Quick" Then
        btnClockOut.Visible = true;
        // End If

        // ******moved open drawer from here

        // ***    InitializeOrderForm()
        // InitializeSplitChecks()
        // actingManager = Nothing

        // GenerateOverrideCodes() 'for now not pulling from database


        if (mainServerConnected == false)
        {
            SetDateTime();
            openProgram.Dispose();
            // this is just b/c we used this so much incorrectly throughout the code
            // mainServerConnected = True
            return;
        }

        if (typeProgram == "Online_Demo")
        {
            openProgram.Dispose();
            return;
        }

        if (tablesFilled == true)
        {
            // this means the first half of the Phoenix tables are filled
            // otherwise Phoenix connection is down
            // False means we already downloaded the LAST MENU SAVED

            try
            {
                GenerateOrderTables.TempConnectToPhoenix();
                // PopulateNONOrderTables()
                // PopulateMenuSupport()
                // PopulateTerminalData()               'FloorPlan
                // CreateTerminals()

                sql.cn.Open();
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                currentMenu = new Menu(currentTerminal.primaryMenuID, true);
                if (currentTerminal.secondaryMenuID > 0)
                {
                    secondaryMenu = new Menu(currentTerminal.secondaryMenuID, false);
                }
                sql.cn.Close();

                GenerateOrderTables.ConnectBackFromTempDatabase();
            }
            catch (Exception ex)
            {
                // nned to reload all Info stored on Phoenix from XML
                CloseConnection();
                GenerateOrderTables.ConnectBackFromTempDatabase();
                Interaction.MsgBox(ex.Message + " Connection Down, Removing Opening Screen. Select saved menu.");
                ServerNOTConectedStartOfProgram();
                return;
            }

            CreateMenuString222(currentTerminal.primaryMenuID, ref menuName);
            if (currentTerminal.secondaryMenuID > 0)
            {
                menuName = menuName + "_";
                CreateMenuString222(currentTerminal.secondaryMenuID, ref menuName);
            }

            SetUpPrimaryKeys();
            // GenerateOrderTables.CreateTerminals()
            SaveBackupDATAds(menuName);

            SetDateTime();
            TestForShiftAndMenuChanges();
            openProgram.Dispose();
        }

        else
        {
            Interaction.MsgBox("Connection Down, Removing Opening Screen Default. Select saved menu.");
            ServerNOTConectedStartOfProgram();
        }

        try
        {
            DetermineOpenCashDrawer(currentTerminal.CurrentDailyCode);
            {
                var withBlock = dvTermsOpen;
                withBlock.Table = dtTermsOpen;
                withBlock.RowFilter = "TerminalsPrimaryKey = " + currentTerminal.TermPrimaryKey;
            }

            if (dvTermsOpen.Count == 1)
            {
                currentTerminal.TerminalsOpenID = dvTermsOpen[0]("TerminalsOpenID");
                actingManager = (object)null;
            }
            else
            {
                if (currentTerminal.HasCashDrawer == true)
                {
                    // MsgBox("Do NOT forget to open your Cash Drawer")
                    if (actingManager.OperationMgmtAll == true | actingManager.OperationMgmtLimited == true)
                    {
                        // 666
                        OpenCloseCashDrawer(0);  // this 0 means this terminal only
                    }
                    // ***********
                    // we never get rid of actingManager = Nothing
                    // because we need it to open cash drawer
                    // maybe some wierd memory leak, don;t think so 
                    else
                    {
                        actingManager = (object)null;
                    }
                }
                else
                {
                    actingManager = (object)null;
                }
                currentTerminal.TerminalsOpenID = 0;
            }
        }
        catch (Exception ex)
        {
            currentTerminal.TerminalsOpenID = 0;
        }

    }

    private void OpenCloseCashDrawer(int _thisCashTerminal)
    {

        cashDrawer = new CashDrawer_UC(_thisCashTerminal);
        cashDrawer.Location = new Point((this.Width - cashDrawer.Width) / 2, (this.Height - cashDrawer.Height) / 2);
        this.Controls.Add(cashDrawer);
        cashDrawer.BringToFront();

    }

    private void SaveBackupDATAds(string menuName)
    {
        // 222 i think

        try
        {
            if (typeProgram == "Online_Demo")
                return;

            GenerateOrderTables.CreatespiderPOSDirectory();

            // starter menu is just a subset of ds dataset
            dsStarter.WriteXml(@"c:\Data Files\spiderPOS\StarterMenu.xml", XmlWriteMode.WriteSchema);
            ds.WriteXml(@"c:\Data Files\spiderPOS\Menu\" + menuName + ".xml", XmlWriteMode.WriteSchema);
        }

        // ***************
        // need for Demo
        // DO NOT DELETE below
        // dsStarter.WriteXml("StarterMenu.xml", XmlWriteMode.WriteSchema)
        // ds.WriteXml("Lunch_Dinner_QuickDemo.xml", XmlWriteMode.WriteSchema)
        // ds.WriteXml("Lunch_Dinner.xml", XmlWriteMode.WriteSchema)
        // dsOrder.WriteXml("OrderData.xml", XmlWriteMode.WriteSchema)
        // dsEmployee.WriteXml("EmployeeData.xml", XmlWriteMode.WriteSchema)
        // dsCustomer.WriteXml("CustomerData.xml", XmlWriteMode.WriteSchema)


        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);

        }

    }

    private void OnlineDemoStartOfProgram()
    {

        connectionDown = new ConnectionDown_UC();
        connectionDown.Location = new Point((this.Width - connectionDown.Width) / 2, (this.Height - connectionDown.Height) / 2);

        connectionDown.MenuChoiceRoutine("Lunch_Dinner");

    }

    private void ServerNOTConectedStartOfProgram()
    {


        // *** we should not bring program UP
        // inform customer down and set timer to check for connection 

        // CloseConnection()
        // GenerateOrderTables.ConnectBackFromTempDatabase()
        if (localConnectServer == @"eglobalmain\eglobalmain")
        {
            // this is temporary fix b/c of local admin for clients
            companyInfo.companyName = "eGlobalPartners";
        }
        // MsgBox("Connection Down. Select saved menu.")
        mainServerConnected = false;

        connectionDown = new ConnectionDown_UC();
        connectionDown.Location = new Point((this.Width - connectionDown.Width) / 2, (this.Height - connectionDown.Height) / 2);
        this.Controls.Add(connectionDown);
        connectionDown.BringToFront();

    }

    private void CanceledConnectionHelp()
    {

        Interaction.MsgBox("Connection to main server is down. You must load a Menu. Please call spiderPOS at 404.869.4700");
        OpenScreenClosed();
        connectionDown.Dispose();

    }

    private void OldMenuLoaded()
    {

        initLogon.Dispose();
        connectionDown.Dispose();
        // DisplayOpeningScreen(companyInfo.companyName)

        if (tablesFilled == false)
        {
            StartOfProgram(companyInfo.companyName);
        }
        else
        {
            DisplayOpeningScreen(companyInfo.companyName);
        }

    }

    private void ClosePOS2()
    {
        this.Dispose();

    }

    private void ClosePOS() // , openProgram.ClosePOS
    {

        this.Dispose();
        return;

        // testing below, it is now in PopulateLocationOpening
        bool changedVersion;
        int lastVersion;

        try
        {
            PopulateLocationOpening(false);

            if (ds.Tables("LocationOpening").Rows.Count > 0)
            {
                if (global::My.Application.Info.Version.MinorRevision > ds.Tables("LocationOpening").Rows(0)("LastAppVersion"))
                {
                    lastVersion = global::My.Application.Info.Version.MinorRevision;
                    changedVersion = true;
                }
            }
            if (changedVersion == true)
            {
                ds.Tables("LocationOpening").Rows(0)("LastAppVersion") = lastVersion;
                sql.cn.Open();
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                sql.SqlLocationOpening.Update(ds.Tables("LocationOpening"));
                sql.cn.Close();
            }
        }

        catch (Exception ex)
        {
            CloseConnection();
        }

        this.Dispose();
        return;

        // testing below
        try
        {
            PopulateLocationOpening(false);
        }
        catch (Exception ex)
        {
            CloseConnection();
            this.Dispose();
        }

        if (ds.Tables("LocationOpening").Rows.Count > 0)
        {
            if (global::My.Application.Info.Version.MinorRevision < ds.Tables("LocationOpening").Rows(0)("LastAppVersion"))
            {
                this.Dispose();
            }
            else
            {
                InitializeOpeningScreen();
                DisplayOpeningScreen(companyInfo.companyName);
            }
        }
        // Me.Dispose()

    }

    // Merchant Warehouse

    private void Swiped__Encrypted__Load_MWE(object sender, EventArgs e)
    {
        // Me.AxUSBHID_MWE.PortOpen = True
    }
    public void AxUSBHID_MWE_CardDataChanged(object sender, EventArgs e)
    {
        // this is if we are instantiating the ActiveX in Login
        // readAuth_MWE.AxUSBHID1_CardDataChanged(sender)
    }


    private void OpenPortAtStart()
    {
        // 444   Me.readAuth_MWE.AxUSBHID1.PortOpen = True

    }

    private void OpeningNewTabFrom_MWE(int paymentID, string tabNameString) // 444 Handles readAuth_MWE.OpenNewTab
    {

        if (GenerateOrderTables.OpenNewTab(-999, tabNameString) == true)
        {
        }
        // send result back to MWE
        // 444        readAuth_MWE.ResultOfOpeningNewTab(paymentID, currentTable.ExperienceNumber)

        else
        {
            // probably do not need to send back
            // old            readAuth_MWE.ResultOfOpenigNewTab(0)

        }

    }

    private void PlacingInTabAccount_MWE(int paymentID, string sa, string lName, string fname, string fullName) // 444Handles readAuth_MWE.PlaceInTabAccount
    {
        var newpayment = new Payment();

        newpayment.newPaymentID = paymentID;
        newpayment.SpiderAcct = sa;
        newpayment.LastName = lName;
        newpayment.FirstName = fname;
        newpayment.Name = fullName;

        CreateTabAcctPlaceInExperience(newpayment);

    }

    private DataRowView DetermineViewInfoForPaymets(int paymentID)
    {
        // With dvUnAppliedPaymentsAndCredits_MWE
        // .Table = readAuth_MWE.dtPaymentsAndCreditsUnauthorized_MWE
        // .RowFilter = "Applied = False AND ExperienceNumber = '" & currentTable.ExperienceNumber & "' AND CheckNumber = '" & currentTable.CheckNumber & "'"
        // .Sort = "PaymentFlag"
        // End With
        foreach (DataRowView vRow in dvUnAppliedPaymentsAndCredits_MWE)
        {
            if (vRow("PaymentID") == paymentID)
            {
                return vRow;
            }
        }

        return default;

    }

    private void NewCardRead_MWE(int paymentID) // 444Handles readAuth_MWE.CardReadSuccessful
    {
        // Private Sub NewCardRead_MWE(ByVal _secureNewPayment_MWE As ReadCredit_MWE2.Payment_MWE) Handles readAuth_MWE.CardReadSuccessful
        // ResetTimer()
        DataRowView vRow;
        vRow = DetermineViewInfoForPaymets(paymentID);
        if (vRow is null)
        {
            return;
        }
        // Dim newPayment As New Payment
        // With newPayment
        // .experienceNumber = _secureNewPayment_MWE.experienceNumber
        // .PaymentTypeID = _secureNewPayment_MWE.PaymentTypeID
        // .PaymentTypeName = _secureNewPayment_MWE.PaymentTypeName
        // .PaymentFlag = _secureNewPayment_MWE.PaymentFlag
        // .TranType = _secureNewPayment_MWE.TranType
        // '         '         .TranCode=
        // .AccountNumber=
        // .ExpDate=
        // .Swiped=
        // End With

        switch (readAuth.ActiveScreen)
        {
            case "Login":
                {
                    break;
                }

            case "OrderScreen":
                {

                    if (currentTerminal.TermMethod == "Quick")
                    {
                        CloseScreenVisible(QuickOrder.IsManagerMode);
                        QuickOrder.Visible = false;
                    }
                    else
                    {
                        CloseScreenVisible(activeOrder.IsManagerMode);
                        activeOrder.Visible = false;
                    }
                    activeSplit._closeCheck.ProcessCreditRead_MWE(vRow); // _secureNewPayment_MWE)
                    break;
                }

            case "CloseCheck":
                {
                    // ProcessCreditRead(newPayment)
                    activeSplit._closeCheck.ProcessCreditRead_MWE(vRow); // _secureNewPayment_MWE)
                    break;
                }

            case "SeatingTab":
                {

                    if (activeSplit is null)
                    {
                        InitializeSplitChecks(false); // _isFromManager)
                        activeSplit.Visible = false;
                    }
                    activeSplit._closeCheck.ProcessCreditRead_MWE(vRow); // _secureNewPayment_MWE)
                    currentTable.TabID = vRow("TabID"); // _secureNewPayment_MWE.TabID '
                    currentTable.TabName = vRow("TabName"); // _secureNewPayment_MWE.Name '
                    LoadTabIDinExperinceTable();

                    // CustomerLoyalty()
                    if (SeatingTab.StartedFrom == "Manager")
                    {
                        MgrOrderScreen();
                    }
                    else // If SeatingTab.StartedFrom = "OrderScreen" Then
                    {
                        var argtabAccountInfo = default;
                        OrderScreen(ref argtabAccountInfo);
                        // ElseIf SeatingTab.StartedFrom = "TableScreen" Then
                    }

                    SeatingTab.Visible = false;
                    tableScreen.EnableTables_Screen();
                    break;
                }
            // readAuth assiged in OrderScreen & MgrOrderScreen

            case "DeliveryScreen":
                {
                    // *** not sure if this is correct,not sure about
                    // the AddPayment Collection in Read Credit ????
                    // 444      GenerateOrderTables.CreateTabAcctPlaceInExperience(newpayment)
                    DeliveryScreen.TempAccountNumber = vRow("SpiderAcct"); // _secureNewPayment_MWE.SpiderAcct '
                                                                           // might need to  SetAccountSearch() , currently we are doing before swipe activate

                    if (DeliveryScreen.attemptedToEdit == true)
                    {
                        DeliveryScreen.attemptedToEdit = false;
                        GenerateOrderTables.UpdateTabInfo(DeliveryScreen.StartInSearch);
                    }
                    GenerateOrderTables.PopulateSearchAccount(vRow("SpiderAcct")); // _secureNewPayment_MWE.SpiderAcct) ' ', -123456789)
                    DeliveryScreen.BindDataAfterSearch();
                    break;
                }

            case "Manager":
                {
                    break;
                }
        }

    }

    private void AuthTHisPayment(int paymentID, bool justActive)
    {
        object isApproved;
        // 444    readAuth_MWE.btnSale_Encrpted_Swipe(paymentID)

        if (justActive == false)
        {
            // send another payment
        }

    }



}