using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using DataSet_Builder;



public partial class OpeningScreen : System.Windows.Forms.UserControl
{

    // Dim sql As New DataSet_Builder.SQLHelper(connectserver)

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
                _employeeLog.ClosedEmployeeLog -= ClosingEmployeeLog;
            }

            _employeeLog = value;
            if (_employeeLog != null)
            {
                _employeeLog.ClosedEmployeeLog += ClosingEmployeeLog;
            }
        }
    }
    private SelectionDaily_UC _selectDaily;

    private SelectionDaily_UC selectDaily
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
                _selectDaily.DailySelected -= OpenDailyBusinessSelected;
                _selectDaily.NewDaily -= NewDaily_Selected;
            }

            _selectDaily = value;
            if (_selectDaily != null)
            {
                _selectDaily.DailySelected += OpenDailyBusinessSelected;
                _selectDaily.NewDaily += NewDaily_Selected;
            }
        }
    }
    private DataSet_Builder.Information_UC newBatchQuestion;
    private DataSet_Builder.Information_UC _infoClockin;

    private DataSet_Builder.Information_UC infoClockin
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _infoClockin;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_infoClockin != null)
            {
                _infoClockin.AcceptInformation -= InfoClockinHit;
            }

            _infoClockin = value;
            if (_infoClockin != null)
            {
                _infoClockin.AcceptInformation += InfoClockinHit;
            }
        }
    }
    private NumberPad _loginPad;

    private NumberPad loginPad // DataSet_Builder.NumberPadLarge
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
    private ConnectionDown_UC connectionDown;

    private int _pMenuID;
    private int _sMenuID;
    private string _pMenuName;
    private string _sMenuName;
    private int openBusinessCount;

    private DataSet_Builder.TitleUserControl titleHeader = new DataSet_Builder.TitleUserControl();
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
    private Global.System.Windows.Forms.GroupBox _grpCashDrawers;

    internal virtual Global.System.Windows.Forms.GroupBox grpCashDrawers
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _grpCashDrawers;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _grpCashDrawers = value;
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
    private Global.System.Windows.Forms.ListView _lstOpenCashDrawers;

    internal virtual Global.System.Windows.Forms.ListView lstOpenCashDrawers
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lstOpenCashDrawers;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lstOpenCashDrawers = value;
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _clmCashDrawer;

    internal virtual Global.System.Windows.Forms.ColumnHeader clmCashDrawer
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _clmCashDrawer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _clmCashDrawer = value;
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _clmIsOpen;

    internal virtual Global.System.Windows.Forms.ColumnHeader clmIsOpen
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _clmIsOpen;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _clmIsOpen = value;
        }
    }
    private Global.System.Windows.Forms.GroupBox _grpDaily;

    internal virtual Global.System.Windows.Forms.GroupBox grpDaily
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _grpDaily;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _grpDaily = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblMenu1;

    internal virtual Global.System.Windows.Forms.Label lblMenu1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblMenu1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblMenu1 != null)
            {
                _lblMenu1.Click -= lblMenu1_Click;
            }

            _lblMenu1 = value;
            if (_lblMenu1 != null)
            {
                _lblMenu1.Click += lblMenu1_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnOpenNewDaily;

    internal virtual Global.System.Windows.Forms.Button btnOpenNewDaily
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnOpenNewDaily;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnOpenNewDaily != null)
            {
                _btnOpenNewDaily.Click -= btnOpenNewDaily_Click;
            }

            _btnOpenNewDaily = value;
            if (_btnOpenNewDaily != null)
            {
                _btnOpenNewDaily.Click += btnOpenNewDaily_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblMenu2;

    internal virtual Global.System.Windows.Forms.Label lblMenu2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblMenu2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblMenu2 != null)
            {
                _lblMenu2.Click -= lblMenu2_Click;
            }

            _lblMenu2 = value;
            if (_lblMenu2 != null)
            {
                _lblMenu2.Click += lblMenu2_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblMenuSecond;

    internal virtual Global.System.Windows.Forms.Label lblMenuSecond
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblMenuSecond;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblMenuSecond != null)
            {
                _lblMenuSecond.Click -= lblMenuSecond_Click;
            }

            _lblMenuSecond = value;
            if (_lblMenuSecond != null)
            {
                _lblMenuSecond.Click += lblMenuSecond_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblMenuMain;

    internal virtual Global.System.Windows.Forms.Label lblMenuMain
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblMenuMain;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblMenuMain != null)
            {
                _lblMenuMain.Click -= lblMenuMain_Click;
            }

            _lblMenuMain = value;
            if (_lblMenuMain != null)
            {
                _lblMenuMain.Click += lblMenuMain_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnOpenThisDaily;

    internal virtual Global.System.Windows.Forms.Button btnOpenThisDaily
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnOpenThisDaily;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnOpenThisDaily != null)
            {
                _btnOpenThisDaily.Click -= btnOpenThisDaily_Click;
            }

            _btnOpenThisDaily = value;
            if (_btnOpenThisDaily != null)
            {
                _btnOpenThisDaily.Click += btnOpenThisDaily_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _pnlDailyChooseTermMethod;

    internal virtual Global.System.Windows.Forms.Panel pnlDailyChooseTermMethod
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlDailyChooseTermMethod;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlDailyChooseTermMethod = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblDailyChoose;

    internal virtual Global.System.Windows.Forms.Label lblDailyChoose
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblDailyChoose;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblDailyChoose = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnDailyBar;

    internal virtual Global.System.Windows.Forms.Button btnDailyBar
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDailyBar;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnDailyBar != null)
            {
                _btnDailyBar.Click -= btnDailyBar_Click;
            }

            _btnDailyBar = value;
            if (_btnDailyBar != null)
            {
                _btnDailyBar.Click += btnDailyBar_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnDailyTable;

    internal virtual Global.System.Windows.Forms.Button btnDailyTable
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDailyTable;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnDailyTable != null)
            {
                _btnDailyTable.Click -= btnDailyTable_Click;
            }

            _btnDailyTable = value;
            if (_btnDailyTable != null)
            {
                _btnDailyTable.Click += btnDailyTable_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnDailyQuick;

    internal virtual Global.System.Windows.Forms.Button btnDailyQuick
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDailyQuick;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnDailyQuick != null)
            {
                _btnDailyQuick.Click -= btnDailyQuick_Click;
            }

            _btnDailyQuick = value;
            if (_btnDailyQuick != null)
            {
                _btnDailyQuick.Click += btnDailyQuick_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnSwitchDaily;

    internal virtual Global.System.Windows.Forms.Button btnSwitchDaily
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnSwitchDaily;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnSwitchDaily != null)
            {
                _btnSwitchDaily.Click -= btnSwitchDaily_Click;
            }

            _btnSwitchDaily = value;
            if (_btnSwitchDaily != null)
            {
                _btnSwitchDaily.Click += btnSwitchDaily_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _Label2;

    internal virtual Global.System.Windows.Forms.Label Label2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label2 = value;
        }
    }

    private string _empOpening;

    public event OpeningScreenClosingEventHandler OpeningScreenClosing;

    public delegate void OpeningScreenClosingEventHandler();    // (ByVal sender As Object, ByVal e As System.EventArgs)
    public event RestuarantOpenEventHandler RestuarantOpen;

    public delegate void RestuarantOpenEventHandler(OpenInfo openingInfo);
    public event RestaurantOpeningEventHandler RestaurantOpening;

    public delegate void RestaurantOpeningEventHandler();
    public event ClosePOSEventHandler ClosePOS;

    public delegate void ClosePOSEventHandler();

    #region  Windows Form Designer generated code 

    public OpeningScreen(string empName) : base()
    {

        _empOpening = empName;

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        InitializeOther();
        base.Click += DisplayLoginPad;
        newBatchQuestion.AcceptInformation += batchQuestionAccepted;

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
    private Global.System.Windows.Forms.Panel _pnlWelcome;

    internal virtual Global.System.Windows.Forms.Panel pnlWelcome
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlWelcome;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlWelcome = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblWelcome;

    internal virtual Global.System.Windows.Forms.Label lblWelcome
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblWelcome;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblWelcome = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlTitle;

    internal virtual Global.System.Windows.Forms.Panel pnlTitle
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlTitle;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlTitle = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnExit;

    internal virtual Global.System.Windows.Forms.Button btnExit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnExit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnExit != null)
            {
                _btnExit.Click -= btnExit_Click;
            }

            _btnExit = value;
            if (_btnExit != null)
            {
                _btnExit.Click += btnExit_Click;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(OpeningScreen));
        _pnlWelcome = new System.Windows.Forms.Panel();
        _lblWelcome = new System.Windows.Forms.Label();
        _pnlTitle = new System.Windows.Forms.Panel();
        _btnExit = new System.Windows.Forms.Button();
        _btnExit.Click += btnExit_Click;
        _grpEmployeeClockIn = new System.Windows.Forms.GroupBox();
        _lblNumClockedIn = new System.Windows.Forms.Label();
        _grdEmpClockIn = new System.Windows.Forms.DataGrid();
        _DataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
        _DataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
        _DataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
        _DataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
        _grpCashDrawers = new System.Windows.Forms.GroupBox();
        _lstOpenCashDrawers = new System.Windows.Forms.ListView();
        _clmCashDrawer = new System.Windows.Forms.ColumnHeader();
        _clmIsOpen = new System.Windows.Forms.ColumnHeader();
        _grpDaily = new System.Windows.Forms.GroupBox();
        _btnSwitchDaily = new System.Windows.Forms.Button();
        _btnSwitchDaily.Click += btnSwitchDaily_Click;
        _btnOpenThisDaily = new System.Windows.Forms.Button();
        _btnOpenThisDaily.Click += btnOpenThisDaily_Click;
        _lblMenuSecond = new System.Windows.Forms.Label();
        _lblMenuSecond.Click += lblMenuSecond_Click;
        _lblMenuMain = new System.Windows.Forms.Label();
        _lblMenuMain.Click += lblMenuMain_Click;
        _lblMenu2 = new System.Windows.Forms.Label();
        _lblMenu2.Click += lblMenu2_Click;
        _lblMenu1 = new System.Windows.Forms.Label();
        _lblMenu1.Click += lblMenu1_Click;
        _btnOpenNewDaily = new System.Windows.Forms.Button();
        _btnOpenNewDaily.Click += btnOpenNewDaily_Click;
        _pnlDailyChooseTermMethod = new System.Windows.Forms.Panel();
        _lblDailyChoose = new System.Windows.Forms.Label();
        _btnDailyBar = new System.Windows.Forms.Button();
        _btnDailyBar.Click += btnDailyBar_Click;
        _btnDailyTable = new System.Windows.Forms.Button();
        _btnDailyTable.Click += btnDailyTable_Click;
        _btnDailyQuick = new System.Windows.Forms.Button();
        _btnDailyQuick.Click += btnDailyQuick_Click;
        _Label2 = new System.Windows.Forms.Label();
        _pnlWelcome.SuspendLayout();
        _grpEmployeeClockIn.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_grdEmpClockIn).BeginInit();
        _grpCashDrawers.SuspendLayout();
        _grpDaily.SuspendLayout();
        _pnlDailyChooseTermMethod.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlWelcome
        // 
        _pnlWelcome.BackColor = System.Drawing.Color.Transparent;
        _pnlWelcome.Controls.Add(_lblWelcome);
        _pnlWelcome.ForeColor = System.Drawing.Color.White;
        _pnlWelcome.Location = new System.Drawing.Point(8, 72);
        _pnlWelcome.Name = "_pnlWelcome";
        _pnlWelcome.Size = new System.Drawing.Size(544, 52);
        _pnlWelcome.TabIndex = 0;
        // 
        // lblWelcome
        // 
        _lblWelcome.Font = new System.Drawing.Font("Comic Sans MS", 20.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblWelcome.ForeColor = System.Drawing.Color.Black;
        _lblWelcome.Location = new System.Drawing.Point(3, 3);
        _lblWelcome.Name = "_lblWelcome";
        _lblWelcome.Size = new System.Drawing.Size(480, 40);
        _lblWelcome.TabIndex = 0;
        _lblWelcome.Text = "Welcome";
        // 
        // pnlTitle
        // 
        _pnlTitle.BackColor = System.Drawing.Color.Transparent;
        _pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
        _pnlTitle.ForeColor = System.Drawing.Color.Blue;
        _pnlTitle.Location = new System.Drawing.Point(0, 0);
        _pnlTitle.Name = "_pnlTitle";
        _pnlTitle.Size = new System.Drawing.Size(1024, 72);
        _pnlTitle.TabIndex = 1;
        // 
        // btnExit
        // 
        _btnExit.Anchor = (Global.System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        _btnExit.BackColor = System.Drawing.Color.FromArgb(0, 0, 240);
        _btnExit.Font = new System.Drawing.Font("Comic Sans MS", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnExit.ForeColor = System.Drawing.Color.White;
        _btnExit.Location = new System.Drawing.Point(32, 683);
        _btnExit.Name = "_btnExit";
        _btnExit.Size = new System.Drawing.Size(96, 56);
        _btnExit.TabIndex = 0;
        _btnExit.Text = "Exit";
        _btnExit.UseVisualStyleBackColor = false;
        // 
        // grpEmployeeClockIn
        // 
        _grpEmployeeClockIn.BackColor = System.Drawing.Color.WhiteSmoke;
        _grpEmployeeClockIn.Controls.Add(_lblNumClockedIn);
        _grpEmployeeClockIn.Controls.Add(_grdEmpClockIn);
        _grpEmployeeClockIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _grpEmployeeClockIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _grpEmployeeClockIn.ForeColor = System.Drawing.Color.MediumBlue;
        _grpEmployeeClockIn.Location = new System.Drawing.Point(43, 259);
        _grpEmployeeClockIn.Name = "_grpEmployeeClockIn";
        _grpEmployeeClockIn.Size = new System.Drawing.Size(254, 178);
        _grpEmployeeClockIn.TabIndex = 2;
        _grpEmployeeClockIn.TabStop = false;
        _grpEmployeeClockIn.Text = "Employees Clocked-In";
        // 
        // lblNumClockedIn
        // 
        _lblNumClockedIn.Location = new System.Drawing.Point(171, 18);
        _lblNumClockedIn.Name = "_lblNumClockedIn";
        _lblNumClockedIn.Size = new System.Drawing.Size(56, 20);
        _lblNumClockedIn.TabIndex = 2;
        _lblNumClockedIn.Text = "#";
        _lblNumClockedIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // grdEmpClockIn
        // 
        _grdEmpClockIn.BackColor = System.Drawing.Color.WhiteSmoke;
        _grdEmpClockIn.BackgroundColor = System.Drawing.Color.WhiteSmoke;
        _grdEmpClockIn.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _grdEmpClockIn.CaptionText = "           Employees";
        _grdEmpClockIn.CaptionVisible = false;
        _grdEmpClockIn.ColumnHeadersVisible = false;
        _grdEmpClockIn.DataMember = "";
        _grdEmpClockIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _grdEmpClockIn.GridLineColor = System.Drawing.Color.WhiteSmoke;
        _grdEmpClockIn.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        _grdEmpClockIn.Location = new System.Drawing.Point(6, 41);
        _grdEmpClockIn.Name = "_grdEmpClockIn";
        _grdEmpClockIn.RowHeadersVisible = false;
        _grdEmpClockIn.Size = new System.Drawing.Size(242, 131);
        _grdEmpClockIn.TabIndex = 1;
        _grdEmpClockIn.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] { _DataGridTableStyle1 });
        // 
        // DataGridTableStyle1
        // 
        _DataGridTableStyle1.DataGrid = _grdEmpClockIn;
        _DataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] { _DataGridTextBoxColumn1, _DataGridTextBoxColumn2, _DataGridTextBoxColumn3 });
        _DataGridTableStyle1.GridLineColor = System.Drawing.SystemColors.Window;
        _DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        _DataGridTableStyle1.MappingName = "LoggedInEmployees";
        _DataGridTableStyle1.ReadOnly = true;
        _DataGridTableStyle1.RowHeadersVisible = false;
        // 
        // DataGridTextBoxColumn1
        // 
        _DataGridTextBoxColumn1.Format = "";
        _DataGridTextBoxColumn1.FormatInfo = (object)null;
        _DataGridTextBoxColumn1.MappingName = "FirstName";
        _DataGridTextBoxColumn1.NullText = " ";
        _DataGridTextBoxColumn1.Width = 75;
        // 
        // DataGridTextBoxColumn2
        // 
        _DataGridTextBoxColumn2.Format = "";
        _DataGridTextBoxColumn2.FormatInfo = (object)null;
        _DataGridTextBoxColumn2.MappingName = "LastName";
        _DataGridTextBoxColumn2.NullText = " ";
        _DataGridTextBoxColumn2.Width = 75;
        // 
        // DataGridTextBoxColumn3
        // 
        _DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
        _DataGridTextBoxColumn3.Format = "MM/dd";
        _DataGridTextBoxColumn3.FormatInfo = (object)null;
        _DataGridTextBoxColumn3.MappingName = "LogInTime";
        _DataGridTextBoxColumn3.NullText = " ";
        _DataGridTextBoxColumn3.Width = 50;
        // 
        // grpCashDrawers
        // 
        _grpCashDrawers.BackColor = System.Drawing.Color.WhiteSmoke;
        _grpCashDrawers.Controls.Add(_lstOpenCashDrawers);
        _grpCashDrawers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _grpCashDrawers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _grpCashDrawers.ForeColor = System.Drawing.Color.MediumBlue;
        _grpCashDrawers.Location = new System.Drawing.Point(43, 458);
        _grpCashDrawers.Name = "_grpCashDrawers";
        _grpCashDrawers.Size = new System.Drawing.Size(254, 178);
        _grpCashDrawers.TabIndex = 3;
        _grpCashDrawers.TabStop = false;
        _grpCashDrawers.Text = "Cash Drawers";
        // 
        // lstOpenCashDrawers
        // 
        _lstOpenCashDrawers.BackColor = System.Drawing.Color.WhiteSmoke;
        _lstOpenCashDrawers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { _clmCashDrawer, _clmIsOpen });
        _lstOpenCashDrawers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lstOpenCashDrawers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        _lstOpenCashDrawers.Location = new System.Drawing.Point(6, 38);
        _lstOpenCashDrawers.Name = "_lstOpenCashDrawers";
        _lstOpenCashDrawers.Size = new System.Drawing.Size(240, 97);
        _lstOpenCashDrawers.TabIndex = 0;
        _lstOpenCashDrawers.UseCompatibleStateImageBehavior = false;
        _lstOpenCashDrawers.View = System.Windows.Forms.View.Details;
        // 
        // clmCashDrawer
        // 
        _clmCashDrawer.Text = "";
        _clmCashDrawer.Width = 120;
        // 
        // clmIsOpen
        // 
        _clmIsOpen.Text = "";
        _clmIsOpen.Width = 115;
        // 
        // grpDaily
        // 
        _grpDaily.BackColor = System.Drawing.Color.WhiteSmoke;
        _grpDaily.Controls.Add(_btnSwitchDaily);
        _grpDaily.Controls.Add(_btnOpenThisDaily);
        _grpDaily.Controls.Add(_lblMenuSecond);
        _grpDaily.Controls.Add(_lblMenuMain);
        _grpDaily.Controls.Add(_lblMenu2);
        _grpDaily.Controls.Add(_lblMenu1);
        _grpDaily.Controls.Add(_btnOpenNewDaily);
        _grpDaily.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _grpDaily.ForeColor = System.Drawing.Color.MediumBlue;
        _grpDaily.Location = new System.Drawing.Point(43, 144);
        _grpDaily.Name = "_grpDaily";
        _grpDaily.Size = new System.Drawing.Size(254, 100);
        _grpDaily.TabIndex = 4;
        _grpDaily.TabStop = false;
        _grpDaily.Text = "Daily Business";
        // 
        // btnSwitchDaily
        // 
        _btnSwitchDaily.BackColor = System.Drawing.Color.IndianRed;
        _btnSwitchDaily.Location = new System.Drawing.Point(234, 47);
        _btnSwitchDaily.Name = "_btnSwitchDaily";
        _btnSwitchDaily.Size = new System.Drawing.Size(20, 47);
        _btnSwitchDaily.TabIndex = 6;
        _btnSwitchDaily.UseVisualStyleBackColor = false;
        _btnSwitchDaily.Visible = false;
        // 
        // btnOpenThisDaily
        // 
        _btnOpenThisDaily.BackColor = System.Drawing.Color.RoyalBlue;
        _btnOpenThisDaily.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnOpenThisDaily.ForeColor = System.Drawing.Color.Black;
        _btnOpenThisDaily.Location = new System.Drawing.Point(130, 47);
        _btnOpenThisDaily.Name = "_btnOpenThisDaily";
        _btnOpenThisDaily.Size = new System.Drawing.Size(107, 47);
        _btnOpenThisDaily.TabIndex = 5;
        _btnOpenThisDaily.UseVisualStyleBackColor = false;
        _btnOpenThisDaily.Visible = false;
        // 
        // lblMenuSecond
        // 
        _lblMenuSecond.AutoSize = true;
        _lblMenuSecond.Location = new System.Drawing.Point(30, 73);
        _lblMenuSecond.Name = "_lblMenuSecond";
        _lblMenuSecond.Size = new System.Drawing.Size(61, 16);
        _lblMenuSecond.TabIndex = 4;
        _lblMenuSecond.Text = "Second";
        // 
        // lblMenuMain
        // 
        _lblMenuMain.AutoSize = true;
        _lblMenuMain.Location = new System.Drawing.Point(30, 40);
        _lblMenuMain.Name = "_lblMenuMain";
        _lblMenuMain.Size = new System.Drawing.Size(41, 16);
        _lblMenuMain.TabIndex = 3;
        _lblMenuMain.Text = "Main";
        // 
        // lblMenu2
        // 
        _lblMenu2.AutoSize = true;
        _lblMenu2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblMenu2.ForeColor = System.Drawing.Color.Black;
        _lblMenu2.Location = new System.Drawing.Point(6, 60);
        _lblMenu2.Name = "_lblMenu2";
        _lblMenu2.Size = new System.Drawing.Size(88, 13);
        _lblMenu2.TabIndex = 2;
        _lblMenu2.Text = "Secondary Menu";
        // 
        // lblMenu1
        // 
        _lblMenu1.AutoSize = true;
        _lblMenu1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblMenu1.ForeColor = System.Drawing.Color.Black;
        _lblMenu1.Location = new System.Drawing.Point(6, 24);
        _lblMenu1.Name = "_lblMenu1";
        _lblMenu1.Size = new System.Drawing.Size(71, 13);
        _lblMenu1.TabIndex = 1;
        _lblMenu1.Text = "Primary Menu";
        // 
        // btnOpenNewDaily
        // 
        _btnOpenNewDaily.BackColor = System.Drawing.Color.RoyalBlue;
        _btnOpenNewDaily.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnOpenNewDaily.ForeColor = System.Drawing.Color.Black;
        _btnOpenNewDaily.Location = new System.Drawing.Point(156, 21);
        _btnOpenNewDaily.Name = "_btnOpenNewDaily";
        _btnOpenNewDaily.Size = new System.Drawing.Size(71, 47);
        _btnOpenNewDaily.TabIndex = 0;
        _btnOpenNewDaily.Text = "Open New";
        _btnOpenNewDaily.UseVisualStyleBackColor = false;
        _btnOpenNewDaily.Visible = false;
        // 
        // pnlDailyChooseTermMethod
        // 
        _pnlDailyChooseTermMethod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _pnlDailyChooseTermMethod.Controls.Add(_lblDailyChoose);
        _pnlDailyChooseTermMethod.Controls.Add(_btnDailyBar);
        _pnlDailyChooseTermMethod.Controls.Add(_btnDailyTable);
        _pnlDailyChooseTermMethod.Controls.Add(_btnDailyQuick);
        _pnlDailyChooseTermMethod.Location = new System.Drawing.Point(724, 259);
        _pnlDailyChooseTermMethod.Name = "_pnlDailyChooseTermMethod";
        _pnlDailyChooseTermMethod.Size = new System.Drawing.Size(288, 104);
        _pnlDailyChooseTermMethod.TabIndex = 7;
        _pnlDailyChooseTermMethod.Visible = false;
        // 
        // lblDailyChoose
        // 
        _lblDailyChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblDailyChoose.Location = new System.Drawing.Point(32, 8);
        _lblDailyChoose.Name = "_lblDailyChoose";
        _lblDailyChoose.Size = new System.Drawing.Size(216, 24);
        _lblDailyChoose.TabIndex = 3;
        _lblDailyChoose.Text = "Choose Terminal Method";
        _lblDailyChoose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btnDailyBar
        // 
        _btnDailyBar.BackColor = System.Drawing.Color.CornflowerBlue;
        _btnDailyBar.Location = new System.Drawing.Point(16, 40);
        _btnDailyBar.Name = "_btnDailyBar";
        _btnDailyBar.Size = new System.Drawing.Size(80, 48);
        _btnDailyBar.TabIndex = 2;
        _btnDailyBar.Text = "Bar";
        _btnDailyBar.UseVisualStyleBackColor = false;
        // 
        // btnDailyTable
        // 
        _btnDailyTable.BackColor = System.Drawing.Color.LightSlateGray;
        _btnDailyTable.Location = new System.Drawing.Point(104, 40);
        _btnDailyTable.Name = "_btnDailyTable";
        _btnDailyTable.Size = new System.Drawing.Size(80, 48);
        _btnDailyTable.TabIndex = 1;
        _btnDailyTable.Text = "Table";
        _btnDailyTable.UseVisualStyleBackColor = false;
        // 
        // btnDailyQuick
        // 
        _btnDailyQuick.BackColor = System.Drawing.Color.LightSlateGray;
        _btnDailyQuick.Location = new System.Drawing.Point(192, 40);
        _btnDailyQuick.Name = "_btnDailyQuick";
        _btnDailyQuick.Size = new System.Drawing.Size(80, 48);
        _btnDailyQuick.TabIndex = 0;
        _btnDailyQuick.Text = "Quick";
        _btnDailyQuick.UseVisualStyleBackColor = false;
        // 
        // Label2
        // 
        _Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label2.Location = new System.Drawing.Point(378, 245);
        _Label2.Name = "_Label2";
        _Label2.Size = new System.Drawing.Size(260, 280);
        _Label2.TabIndex = 10;
        _Label2.Text = resources.GetString("Label2.Text");
        _Label2.Visible = false;
        // 
        // OpeningScreen
        // 
        this.BackColor = System.Drawing.Color.Transparent;
        this.BackgroundImage = (Global.System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
        this.Controls.Add(_Label2);
        this.Controls.Add(_pnlDailyChooseTermMethod);
        this.Controls.Add(_grpDaily);
        this.Controls.Add(_grpCashDrawers);
        this.Controls.Add(_grpEmployeeClockIn);
        this.Controls.Add(_pnlTitle);
        this.Controls.Add(_pnlWelcome);
        this.Controls.Add(_btnExit);
        this.Name = "OpeningScreen";
        this.Size = new System.Drawing.Size(1024, 768);
        _pnlWelcome.ResumeLayout(false);
        _grpEmployeeClockIn.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_grdEmpClockIn).EndInit();
        _grpCashDrawers.ResumeLayout(false);
        _grpDaily.ResumeLayout(false);
        _grpDaily.PerformLayout();
        _pnlDailyChooseTermMethod.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion


    private void InitializeOther()
    {
        // Me.ClientSize = New Size(ssX, ssY)

        grdEmpClockIn.DataSource = dsEmployee.Tables("LoggedInEmployees");

        lblWelcome.Text = "Welcome " + _empOpening;

        titleHeader.Location = new Point((pnlTitle.Width - titleHeader.Width) / 2, (pnlTitle.Height - titleHeader.Height) / 2);
        titleHeader.BackColor = pnlTitle.BackColor;
        titleHeader.ForeColor = Color.Blue;
        pnlTitle.Controls.Add(titleHeader);

        loginPad = new NumberPad(); // DataSet_Builder.NumberPadLarge
        loginPad.Location = new Point((this.Width - loginPad.Width) / 2, (this.Height - loginPad.Height + 75) / 2);
        this.Controls.Add(loginPad);
        loginPad.Visible = false;
        // UpdateOpeningInfo()

    }

    public void UpdateOpeningInfo()
    {

        lblNumClockedIn.Text = dsEmployee.Tables("LoggedInEmployees").Rows.Count;
        // bbbbb()

        if (typeProgram == "Online_Demo")
        {
            // 999
            currentTerminal = new Terminal();
            // LoadingMenuRoutine()
            // Exit Sub
        }

        BegMenuRoutine();
        OpenBusinessRoutine();
        CashDrawerRoutine();

        if (typeProgram == "Demo" | typeProgram == "Online_Demo" | SystemInformation.ComputerName == "EGLOBALMAIN" | SystemInformation.ComputerName == "DILEO")
        {
            pnlDailyChooseTermMethod.Visible = true;
            currentTerminal.TermMethod = "Bar";
        }
        else
        {
            // 444     chosenTermMethod = currentTerminal.TermMethod
        }

        return;
        // 444
        if (ds.Tables("LocationOpening").Rows.Count > 0)
        {
            if (global::My.Application.Info.Version.MinorRevision < ds.Tables("LocationOpening").Rows(0)("LastAppVersion"))
            {
                Interaction.MsgBox("There is a new version of Spider POS available. You must Exit and Restart Spider POS to download new version.");
            }
        }

    }


    private void DisplayLoginPad(object sender, EventArgs e)
    {

        loginPad.btnNumberClear_Click();
        loginPad.Visible = true;

    }

    private void Login_Entered(object sender, EventArgs e)
    {
        string loginEnter;
        Employee emp;
        DataSet_Builder.Information_UC info;
        int isClockedIn;

        loginEnter = loginPad.NumberString;
        loginPad.Visible = false;
        // loginPad.Dispose()

        if (loginEnter.Length == 8)
        {
            // emp = term_Tahsc.DetermineSecondEmployeeAuthorization(loginEnter)
            emp = GenerateOrderTables.TestUsernamePassword(loginEnter, false);
            if (emp is not null)
            {
                try
                {
                    isClockedIn = ActuallyLogIn(emp);
                }

                catch (Exception ex)
                {
                    CloseConnection();
                    Interaction.MsgBox(ex.Message);
                    if (emp.SystemMgmtAll == true | emp.SystemMgmtLimited == true | emp.OperationMgmtAll == true)
                    {
                        actingManager = emp;
                        WelcomeLogon();
                    }
                    return;
                }

                if (isClockedIn == 0)
                {
                    Interaction.MsgBox(emp.FullName + " is not clocked in. Remember to clock in after opening.");
                }
                // 
                // 444           infoClockin = New DataSet_Builder.Information_UC(emp.FullName & " is not clocked in. PLEASE CLOCK IN")
                // infoClockin.Location = New Point((Me.Width - infoClockin.Width) / 2, (Me.Height - infoClockin.Height) / 2)
                // Me.Controls.Add(infoClockin)
                // infoClockin.BringToFront()
                // 444           Exit Sub
                else if (isClockedIn == 1)
                {
                }
                // this will result in opening below
                else
                {
                    Interaction.MsgBox("Employee Is Clocked in more than once. Please See Manager.");
                }

                actingManager = emp;
                WelcomeLogon();
            }

            else
            {
                infoClockin = new DataSet_Builder.Information_UC("PLEASE CLOCK IN");
                infoClockin.Location = new Point((this.Width - infoClockin.Width) / 2, (this.Height - infoClockin.Height) / 2);
                this.Controls.Add(infoClockin);
                infoClockin.BringToFront();
            }
        }
        else
        {
            info = new DataSet_Builder.Information_UC("Please Combine Your EmployeeID as Passcode then Press Enter");
            info.Location = new Point((this.Width - info.Width) / 2, (this.Height - info.Height) / 2);
            this.Controls.Add(info);
            info.BringToFront();

        }

    }

    private void InfoClockinHit(object sender, EventArgs e)
    {
        OpeningScreenClosing?.Invoke();
        // Me.Dispose()

    }

    private void WelcomeLogon()
    {

        pnlWelcome.Dispose();
        btnExit.Dispose();
        // ClosingEmployeeLogSecondStep()
        // Exit Sub

        // below has a problem with TerminalsGroupID

        employeeLog = new EmployeeLoggedInUserControl(false);
        employeeLog.Location = new Point((this.Width - employeeLog.Width) / 2, (this.Height - employeeLog.Height) / 2);
        this.Controls.Add(employeeLog);

    }

    private void ClosingEmployeeLog(object sender, EventArgs e)
    {

        ClosingEmployeeLogSecondStep();

    }

    // the reason this is here is to skip employeeLog on opening

    private void ClosingEmployeeLogSecondStep()
    {

        foreach (DataRow oRow in dsEmployee.Tables("LoggedInEmployees").Rows)
        {
            foreach (Employee emp in AllEmployees)
            {
                if (emp.EmployeeID == oRow("EmployeeID"))
                {
                    GenerateOrderTables.FillJobCodeInfo(emp, oRow("JobCode"));
                    break;
                }
            }
        }

        BatchRoutine();

        // DisplaySeatingChart()

    }


    private void BatchRoutine()
    {
        var dvOpenBusiness = new DataView();

        DetermineOpenBusiness();

        dvOpenBusiness.Table = dsOrder.Tables("OpenBusiness");
        selectDaily = new SelectionDaily_UC(dvOpenBusiness);
        selectDaily.Location = new Point((this.Width - selectDaily.Width) / 2, (this.Height - selectDaily.Height) / 2);
        this.Controls.Add(selectDaily);

        if (dsOrder.Tables("OpenBusiness").Rows.Count > 0)
        {
        }

        else
        {


        }

    }

    private void CashDrawerRoutine()
    {

        try
        {
            DetermineOpenCashDrawer(currentTerminal.CurrentDailyCode);
            bool isOpen;
            foreach (DataRow oRow in ds.Tables("TerminalsMethod").Rows)
            {
                if (oRow("hasCashDrawer") == true)
                {
                    var itemCashDrawer = new ListViewItem();
                    itemCashDrawer.Text = oRow("TerminalName");

                    isOpen = false;

                    // table below has not been populated yet
                    foreach (DataRow dRow in dsOrder.Tables("TermsOpen").Rows)
                    {
                        if (oRow("TerminalsPrimaryKey") == dRow("TerminalsPrimaryKey"))
                        {
                            isOpen = true;
                        }
                    }
                    if (isOpen == true)
                    {
                        itemCashDrawer.SubItems.Add("Open");
                    }
                    else if (oRow("autoOpenDrawer") == true)
                    {
                        itemCashDrawer.SubItems.Add("Open with " + oRow("normalOpenAmount"));
                    }
                    else
                    {
                        itemCashDrawer.SubItems.Add("Closed");
                    }
                    lstOpenCashDrawers.Items.Add(itemCashDrawer);
                }
            }

            // only for eglobalmain test             currentTerminal.TermPrimaryKey = 4
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
                    }

                    // 666 OpenCloseCashDrawer(0)  'this 0 means this terminal only
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

    private void OpenAllCashDrawers()
    {
        bool isDrawerOpen = false;
        DetermineOpenCashDrawer(currentTerminal.CurrentDailyCode);

        foreach (DataRow oRow in ds.Tables("TerminalsMethod").Rows)
        {
            if (oRow("hasCashDrawer") == true)
            {
                if (oRow("autoOpenDrawer") == true)
                {
                    foreach (DataRow tRow in dsOrder.Tables("TermsOpen").Rows)
                    {
                        if (tRow("TerminalsPrimaryKey") == oRow("TerminalsPrimaryKey"))
                        {
                            // we know drawer is open
                            isDrawerOpen = true;
                            break;
                        }
                    }
                    if (isDrawerOpen == false)
                    {
                        OpenCashDrawer(oRow("normalOpenAmount"), oRow("TerminalsPrimaryKey"));
                    }
                    isDrawerOpen = false;
                }
            }
        }

    }

    private void BegMenuRoutine()
    {
        bool hasSecondMenu = false;

        foreach (DataRow oRow in ds.Tables("MenuChoice").Rows)
        {
            if (oRow("LastOrder") == 2)
            {
                _sMenuID = oRow("MenuID");
                _sMenuName = oRow("MenuName");
                lblMenuSecond.Text = _sMenuName;
                hasSecondMenu = true;
            }
            if (oRow("LastOrder") == 1)
            {
                _pMenuID = oRow("MenuID");
                _pMenuName = oRow("MenuName");
                lblMenuMain.Text = _pMenuName;
                if (hasSecondMenu == false)
                {
                    _sMenuID = oRow("MenuID");
                    _sMenuName = oRow("MenuName");
                    lblMenuSecond.Text = _sMenuName;
                }
            }
        }

    }

    private void OpenBusinessRoutine()
    {

        int rowCount;
        var oRow = default(DataRow);
        openBusinessCount = 0;

        DetermineOpenBusiness();

        rowCount = dsOrder.Tables("OpenBusiness").Rows.Count;

        if (rowCount == 0)
        {
            btnOpenNewDaily.Visible = true;
            btnOpenThisDaily.Visible = false;
        }
        else
        {
            btnOpenNewDaily.Visible = false;
            btnOpenThisDaily.Visible = true;

            if (currentTerminal.CurrentDailyCode == 0)
            {
                // if we don't have a daily with this terminal
                // then daily was opened at other terminal
                // we will default to the first row, then swith with below button

                oRow = dsOrder.Tables("OpenBusiness").Rows(openBusinessCount);
                currentTerminal.CurrentDailyCode = oRow("DailyCode");
                if (rowCount > 1)
                {
                    btnSwitchDaily.Visible = true;
                }
            }
            // ***************************
            // now we need to test for menu and initial loading

            else if (rowCount == 1)
            {
                oRow = dsOrder.Tables("OpenBusiness").Rows(openBusinessCount);
            }
            else
            {
                btnSwitchDaily.Visible = true;
                foreach (DataRow currentORow in dsOrder.Tables("OpenBusiness").Rows)
                {
                    oRow = currentORow;
                    openBusinessCount += 1;
                    if (oRow("DailyCode") == currentTerminal.CurrentDailyCode)
                        break;
                }

            }

            PopualteDailyInfo(ref oRow);

            // PopulateQuickTicket()
            // PerformEmployeeFunctions(emp)
        }

    }

    private void PopualteDailyInfo(ref DataRow oRow)
    {

        if (typeProgram == "Online_Demo")
        {
            btnOpenThisDaily.Text = "Select Terminal Method on right";
        }
        else
        {
            btnOpenThisDaily.Text = "Open Daily " + currentTerminal.CurrentDailyCode;
        }
        currentTerminal.DailyDate = Strings.Format(oRow("StartTime"), "d");
        currentTerminal.primaryMenuID = oRow("PrimaryMenu");
        currentTerminal.secondaryMenuID = oRow("SecondaryMenu");
        currentTerminal.CurrentShift = oRow("ShiftID");
        currentTerminal.initPrimaryMenuID = oRow("PrimaryMenu");
    }

    private void OpenDailyBusinessSelected()
    {

        var openingInfo = default(OpenInfo);

        openingInfo.dailyCode = selectDaily.sDailyCode;
        openingInfo.pMenu = selectDaily.sPrimaryMenu;
        openingInfo.sMenu = selectDaily.sSecondaryMenu;
        currentTerminal.initPrimaryMenuID = selectDaily.sPrimaryMenu;
        currentTerminal.currentPrimaryMenuID = selectDaily.sPrimaryMenu;
        currentTerminal.currentSecondaryMenuID = selectDaily.sSecondaryMenu;
        openingInfo.termMethod = selectDaily.chosenTermMethod;

        if (typeProgram == "Online_Demo")
        {
            // 444   currentTerminal = New Terminal
            GenerateOrderTables.CreateTerminals();
        }

        RestuarantOpen?.Invoke(openingInfo);

    }

    private void NewDaily_Selected()
    {

        GenerateOrderTables.StartNewDaily();
        NewDailyStarted();
    }

    private void batchQuestionAccepted(object sender, EventArgs e)
    {
        GenerateOrderTables.StartNewDaily();
        NewDailyStarted();

    }

    private void NewDailyStarted()
    {
        // ********** temp
        var openingInfo = default(OpenInfo);

        openingInfo.dailyCode = currentTerminal.CurrentDailyCode;
        openingInfo.pMenu = currentTerminal.primaryMenuID;
        openingInfo.sMenu = currentTerminal.secondaryMenuID;
        currentTerminal.initPrimaryMenuID = currentTerminal.primaryMenuID;
        currentTerminal.currentPrimaryMenuID = currentTerminal.primaryMenuID;
        openingInfo.termMethod = currentTerminal.TermMethod;  // selectDaily.chosenTermMethod

        RestuarantOpen?.Invoke(openingInfo);

    }



    private void btnExit_Click(object sender, EventArgs e)
    {

        ClosePOS?.Invoke();
        // RaiseEvent OpeningScreenClosing()
        // Me.Dispose()

    }






    private void lblMenu1_Click(object sender, EventArgs e)
    {
        SwitchPrimaryMenu();
    }
    private void lblMenuMain_Click(object sender, EventArgs e)
    {
        SwitchPrimaryMenu();
    }

    private void lblMenu2_Click(object sender, EventArgs e)
    {
        SwitchSecondaryMenu();
    }

    private void lblMenuSecond_Click(object sender, EventArgs e)
    {
        SwitchSecondaryMenu();
    }

    private void SwitchPrimaryMenu()
    {

        // do not allow to change menu here if open daily business
        // should be done in management control
        if (currentTerminal.CurrentDailyCode > 0)
        {
            return;
        }
        DetermineNextMenu(_pMenuID, true);
        lblMenuMain.Text = _pMenuName;

    }
    private void SwitchSecondaryMenu()
    {

        // do not allow to change menu here if open daily business
        // should be done in management control
        if (currentTerminal.CurrentDailyCode > 0)
        {
            return;
        }
        DetermineNextMenu(_sMenuID, false);
        lblMenuSecond.Text = _sMenuName;

    }

    private void DetermineNextMenu(int menuID, bool isPrimary)
    {
        DataRow oRow;
        var i = default(int);

        foreach (DataRow currentORow in ds.Tables("MenuChoice").Rows)
        {
            oRow = currentORow;
            i += 1;
            if (oRow("MenuID") == menuID)
            {
                break;
            }
        }
        if (i >= ds.Tables("MenuChoice").Rows.Count)
        {
            // this mean we start from the beginning
            i = 0;
        }
        oRow = ds.Tables("MenuChoice").Rows(i);

        if (isPrimary == true)
        {
            _pMenuID = oRow("MenuID");
            _pMenuName = oRow("MenuName");
        }
        else
        {
            _sMenuID = oRow("MenuID");
            _sMenuName = oRow("MenuName");
        }

    }




    private void btnOpenNewDaily_Click(object sender, EventArgs e)
    {

        string menuName;

        if (actingManager is null)
        {
            // thinking of something here
            // acting Mgr is inputing into new daily and cashDrawers 
        }

        OpenBusinessRoutine(); // this will recheck for open business
        if (dsOrder.Tables("OpenBusiness").Rows.Count > 0)
        {
            btnOpenThisDaily_Click(sender, e);
            return;
        }

        currentTerminal.primaryMenuID = _pMenuID;
        currentTerminal.secondaryMenuID = _sMenuID;

        LoadingMenuRoutine();

        // revert to the beginninng of menu day
        if (!(currentTerminal.currentPrimaryMenuID == currentTerminal.primaryMenuID))
        {
            currentTerminal.currentPrimaryMenuID = currentTerminal.primaryMenuID;
            currentTerminal.currentSecondaryMenuID = currentTerminal.secondaryMenuID;
        }
        currentTerminal.initPrimaryMenuID = currentTerminal.primaryMenuID;

        // revert to first shift
        if (ds.Tables("ShiftCodes").Rows.Count > 0)
        {
            currentTerminal.CurrentShift = ds.Tables("ShiftCodes").Rows(0)("ShiftID");
        }

        // open new daily
        // input currentMenuID's into DailyBusiness
        GenerateOrderTables.StartNewDaily();

        // open cash drawers
        OpenAllCashDrawers();

        // setprimarykeys
        SetUpPrimaryKeys();

        // this may be me.dispose or not visible
        RestaurantOpening?.Invoke();
        this.Dispose();

    }

    private void LoadingMenuRoutine()
    {

        string fString;
        DateTime xmlMenuDate;
        var needToLoadMenu = default(bool);
        // Dim currentMenu As Menu
        // Dim secondaryMenu As Menu
        // Dim menuName As String


        if (typeProgram == "Online_Demo")
        {
            if (currentTerminal.TermMethod == "Quick")
            {
                ds.ReadXml("Lunch_Dinner_QuickDemo.xml", XmlReadMode.ReadSchema);
            }
            else
            {
                ds.ReadXml("Lunch_Dinner.xml", XmlReadMode.ReadSchema);
            }
            ds.AcceptChanges();
            return;
        }

        // fString = "Lunch_Dinner.xml"
        fString = _pMenuName + "_" + _sMenuName; // + ".xml"

        FileInfo menuDateObj;
        // Dim menuDateObj As New System.IO.FileInfo("c:\Data Files\spiderPOS\Menu\" & fString & ".xml")
        if (pointToServer == false)
        {
            menuDateObj = new FileInfo(@"c:\Data Files\spiderPOS\Menu\" + fString + ".xml");
        }

        else
        {
            menuDateObj = new FileInfo(@"\\" + ourServerName + @"\Data Files\spiderPOS\Menu\" + fString + ".xml");

        }
        xmlMenuDate = menuDateObj.LastWriteTime;

        if (ds.Tables("LocationOpening").Rows.Count > 0)
        {
            if (xmlMenuDate < ds.Tables("LocationOpening").Rows(0)("menuChangeDate"))
            {
                // this mean a changes to the menu have been made since last saving out xml Menu
                needToLoadMenu = true;
            }

            else if (global::My.Application.Info.Version.MinorRevision < ds.Tables("LocationOpening").Rows(0)("LastAppVersion"))
            {
                // this means we revised app, so we might have to reload table structure
                needToLoadMenu = true;
            }
            else
            {
                try
                {
                }
                // we do not want to do this if we changed table structure
                // it will delete columns in new table
                // connectionDown = New ConnectionDown_UC
                // connectionDown.MenuChoiceRoutine(fString & ".xml")
                catch (Exception ex)
                {
                    Interaction.MsgBox("May be a problem with your Backup Menu. Inform Spider POS.");
                    needToLoadMenu = true;
                }
            }
        }
        else
        {
            needToLoadMenu = true;
        }

        if (currentTerminal.TermMethod == "Quick")
        {
            if (dtQuickCategory.Rows.Count + dtQuickDrinkCategory.Rows.Count == 0)
            {
                needToLoadMenu = true;
            }
        }
        else if (dtBartenderCategory.Rows.Count + dtBartenderDrinkCategory.Rows.Count + dtMainCategory.Rows.Count + dtDrinkCategory.Rows.Count == 0)
        {
            needToLoadMenu = true;
        }

        // If currentTerminal.menuLoadedDate = Nothing Or (ds.Tables("MainCategory").Rows.Count + ds.Tables("DrinkCategory").Rows.Count = 0) Then
        // needToLoadMenu = True
        // End If

        // if menu not loaded, or want update
        if (needToLoadMenu == true)
        {
            if (PopulateMenu(false) == true)
            {
                currentTerminal.menuLoadedDate = DateTime.Now;

                // we get this info ONLY from phoenix
                // CreateMenuString(currentTerminal.primaryMenuID, menuName)
                // If currentTerminal.secondaryMenuID > 0 Then
                // menuName = menuName + "_"
                // CreateMenuString(currentTerminal.secondaryMenuID, menuName)
                // End If
                // SaveBackupDATAds(menuName)
                SaveBackupDATAds(fString);
            }
        }

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

    }

    private void SaveBackupDATAds(string menuName)
    {

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
        // and only write to either QUickDemo or Lunch_Dinner
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

    private void btnOpenThisDaily_Click(object sender, EventArgs e)
    {
        // below 2 is conditional
        if (typeProgram == "Online_Demo")
        {
            return;
        }

        currentTerminal.CurrentMenuID = currentTerminal.primaryMenuID;
        currentTerminal.currentPrimaryMenuID = currentTerminal.primaryMenuID;

        if (mainServerConnected == true)
        {
            // if FALSE, we already loaded the xml menu
            LoadingMenuRoutine();
            SetUpPrimaryKeys();
        }
        if (typeProgram == "Online_Demo")
        {
            GenerateOrderTables.CreateTerminals();
        }

        CashDrawerRoutine();

        RestaurantOpening?.Invoke();
        this.Dispose();
        // Me.Visible = False


    }









    private void btnDailyBar_Click(object sender, EventArgs e)
    {
        btnDailyTable.BackColor = Color.LightSlateGray;
        btnDailyBar.BackColor = Color.CornflowerBlue;
        btnDailyQuick.BackColor = Color.LightSlateGray;
        currentTerminal.TermMethod = "Bar";

        TestForDemo("Bar");

    }

    private void btnDailyTable_Click(object sender, EventArgs e)
    {
        btnDailyTable.BackColor = Color.CornflowerBlue;
        btnDailyBar.BackColor = Color.LightSlateGray;
        btnDailyQuick.BackColor = Color.LightSlateGray;
        currentTerminal.TermMethod = "Table";

        TestForDemo("Table");

    }

    private void btnDailyQuick_Click(object sender, EventArgs e)
    {
        btnDailyTable.BackColor = Color.LightSlateGray;
        btnDailyBar.BackColor = Color.LightSlateGray;
        btnDailyQuick.BackColor = Color.CornflowerBlue;
        currentTerminal.TermMethod = "Quick";

        TestForDemo("Quick");

    }

    private void TestForDemo(string termMethod)
    {

        if (typeProgram == "Online_Demo")
        {
            // If dsOrder.Tables("OpenBusiness").Rows.Count > 0 Then '= 1 Then '
            // If currentTerminal.TermMethod = "Quick" Then
            // ds.ReadXml("Lunch_Dinner_QuickDemo.xml", XmlReadMode.ReadSchema)
            // Else
            // ds.ReadXml("Lunch_Dinner.xml", XmlReadMode.ReadSchema)
            // End If
            // ds.AcceptChanges()
            // End If

            // currentTerminal.CurrentMenuID = currentTerminal.primaryMenuID
            // currentTerminal.currentPrimaryMenuID = currentTerminal.primaryMenuID

            LoadingMenuRoutine();
            SetUpPrimaryKeys();
            GenerateOrderTables.CreateTerminals();
            currentTerminal.TermMethod = termMethod;
            currentTerminal.currentPrimaryMenuID = currentTerminal.initPrimaryMenuID;

            CashDrawerRoutine();

            RestaurantOpening?.Invoke();
            this.Dispose();

        }

    }

    private void btnSwitchDaily_Click(object sender, EventArgs e)
    {

        DataRow oRow;

        // openbusinessCount is zero baased
        if (openBusinessCount < dsOrder.Tables("OpenBusiness").Rows.Count - 1)
        {
            openBusinessCount += 1;
        }
        else
        {
            openBusinessCount = 0;
        }

        oRow = dsOrder.Tables("OpenBusiness").Rows(openBusinessCount);
        currentTerminal.CurrentDailyCode = oRow("DailyCode");
        PopualteDailyInfo(ref oRow);

    }

}