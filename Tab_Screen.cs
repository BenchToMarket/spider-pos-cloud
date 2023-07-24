using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using DataSet_Builder;


public partial class Tab_Screen : System.Windows.Forms.UserControl
{

    // Dim WithEvents readAuthTab As New ReadCredit(False)
    private ReadCredit _readAuthTab222;

    private ReadCredit readAuthTab222
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _readAuthTab222;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_readAuthTab222 != null)
            {
                _readAuthTab222.CardReadSuccessful -= CustomerCardRead;
            }

            _readAuthTab222 = value;
            if (_readAuthTab222 != null)
            {
                _readAuthTab222.CardReadSuccessful += CustomerCardRead;
            }
        }
    }

    // Dim tempPayment As New DataSet_Builder.Payment
    private Customer currentCustomer = new Customer();
    private TabInfo currentTabInfo;
    private Label activeLabel;
    private string activeLabelString;
    private DataRow tabRow;
    private string tempMethodUse;

    public bool isDisplaying222;
    public string StartInSearch;
    public bool attemptedToEdit;
    public bool enteringNewTab = false;

    private Timer tabDoubleClickTimer;
    private bool tabTimerActive;

    public string currentSearchBy;
    // choices are:
    // "TabID"
    // "Phone"
    // "Name"
    // "Account"
    // 
    private string currentSearchLocation;
    // choices are:
    // "Location"
    // "Company"

    private CurrencyManager CustomerCurrencyMan;

    private long _tempTabID;
    private string _tempTabName;
    private string _tempAccountPhone;
    private string _tempAccountNumber;
    private bool _hasAddress;

    private Global.System.Windows.Forms.Label _Label33;

    internal virtual Global.System.Windows.Forms.Label Label33
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label33;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label33 = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblTabEmail;

    internal virtual Global.System.Windows.Forms.Label lblTabEmail
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTabEmail;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTabEmail != null)
            {
                _lblTabEmail.Click -= TabLabels_Click;
            }

            _lblTabEmail = value;
            if (_lblTabEmail != null)
            {
                _lblTabEmail.Click += TabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _Label35;

    internal virtual Global.System.Windows.Forms.Label Label35
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label35;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label35 = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblNewTabEmail;

    internal virtual Global.System.Windows.Forms.Label lblNewTabEmail
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNewTabEmail;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblNewTabEmail != null)
            {
                _lblNewTabEmail.Click -= NewTabLabels_Click;
            }

            _lblNewTabEmail = value;
            if (_lblNewTabEmail != null)
            {
                _lblNewTabEmail.Click += NewTabLabels_Click;
            }
        }
    }

    internal long TempTabID
    {
        get
        {
            return _tempTabID;
        }
        set
        {
            _tempTabID = value;
        }
    }

    internal object TempTabName
    {
        get
        {
            return _tempTabName;
        }
        set
        {
            _tempTabName = Conversions.ToString(value);
        }
    }

    internal string TempAccountNumber
    {
        get
        {
            return _tempAccountNumber;
        }
        set
        {
            _tempAccountNumber = value;
        }
    }

    internal bool HasAddress
    {
        get
        {
            return _hasAddress;
        }
        set
        {
            _hasAddress = value;
        }
    }

    public event TabScreenDisposingEventHandler TabScreenDisposing;

    public delegate void TabScreenDisposingEventHandler();
    public event SelectedReOrderEventHandler SelectedReOrder;

    public delegate void SelectedReOrderEventHandler(DataTable dt, bool tabTestNeeded);
    public event SelectedNewOrderEventHandler SelectedNewOrder;

    public delegate void SelectedNewOrderEventHandler();
    public event ChangedMethodUseEventHandler ChangedMethodUse;

    public delegate void ChangedMethodUseEventHandler();

    #region  Windows Form Designer generated code 

    public Tab_Screen() : base() // ByVal _startInSearch As String)
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();
        StartInSearch = "Phone";
        BindData();

        // Add any initialization after the InitializeComponent() call
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

    private Global.System.Windows.Forms.Button _btnCancel;

    internal virtual Global.System.Windows.Forms.Button btnCancel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCancel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCancel != null)
            {
                _btnCancel.Click -= btnCancel_Click;
            }

            _btnCancel = value;
            if (_btnCancel != null)
            {
                _btnCancel.Click += btnCancel_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _Panel3;

    internal virtual Global.System.Windows.Forms.Panel Panel3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel3 = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblTabAddress1;

    internal virtual Global.System.Windows.Forms.Label lblTabAddress1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTabAddress1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTabAddress1 != null)
            {
                _lblTabAddress1.Click -= TabLabels_Click;
            }

            _lblTabAddress1 = value;
            if (_lblTabAddress1 != null)
            {
                _lblTabAddress1.Click += TabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblTabAddress2;

    internal virtual Global.System.Windows.Forms.Label lblTabAddress2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTabAddress2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTabAddress2 != null)
            {
                _lblTabAddress2.Click -= TabLabels_Click;
            }

            _lblTabAddress2 = value;
            if (_lblTabAddress2 != null)
            {
                _lblTabAddress2.Click += TabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblTabCity;

    internal virtual Global.System.Windows.Forms.Label lblTabCity
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTabCity;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTabCity != null)
            {
                _lblTabCity.Click -= TabLabels_Click;
            }

            _lblTabCity = value;
            if (_lblTabCity != null)
            {
                _lblTabCity.Click += TabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblTabState;

    internal virtual Global.System.Windows.Forms.Label lblTabState
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTabState;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTabState != null)
            {
                _lblTabState.Click -= TabLabels_Click;
            }

            _lblTabState = value;
            if (_lblTabState != null)
            {
                _lblTabState.Click += TabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblTabPostalCode;

    internal virtual Global.System.Windows.Forms.Label lblTabPostalCode
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTabPostalCode;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTabPostalCode != null)
            {
                _lblTabPostalCode.Click -= TabLabels_Click;
            }

            _lblTabPostalCode = value;
            if (_lblTabPostalCode != null)
            {
                _lblTabPostalCode.Click += TabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblTabPhone1;

    internal virtual Global.System.Windows.Forms.Label lblTabPhone1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTabPhone1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTabPhone1 != null)
            {
                _lblTabPhone1.Click -= TabLabels_Click;
            }

            _lblTabPhone1 = value;
            if (_lblTabPhone1 != null)
            {
                _lblTabPhone1.Click += TabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _Label8;

    internal virtual Global.System.Windows.Forms.Label Label8
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label8;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label8 = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblTabExt2;

    internal virtual Global.System.Windows.Forms.Label lblTabExt2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTabExt2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTabExt2 != null)
            {
                _lblTabExt2.Click -= TabLabels_Click;
            }

            _lblTabExt2 = value;
            if (_lblTabExt2 != null)
            {
                _lblTabExt2.Click += TabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _Label7;

    internal virtual Global.System.Windows.Forms.Label Label7
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label7;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label7 = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblTabPhone2;

    internal virtual Global.System.Windows.Forms.Label lblTabPhone2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTabPhone2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTabPhone2 != null)
            {
                _lblTabPhone2.Click -= TabLabels_Click;
            }

            _lblTabPhone2 = value;
            if (_lblTabPhone2 != null)
            {
                _lblTabPhone2.Click += TabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblTabSpecial;

    internal virtual Global.System.Windows.Forms.Label lblTabSpecial
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTabSpecial;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTabSpecial != null)
            {
                _lblTabSpecial.Click -= TabLabels_Click;
            }

            _lblTabSpecial = value;
            if (_lblTabSpecial != null)
            {
                _lblTabSpecial.Click += TabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblTabCrossRoads;

    internal virtual Global.System.Windows.Forms.Label lblTabCrossRoads
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTabCrossRoads;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTabCrossRoads != null)
            {
                _lblTabCrossRoads.Click -= TabLabels_Click;
            }

            _lblTabCrossRoads = value;
            if (_lblTabCrossRoads != null)
            {
                _lblTabCrossRoads.Click += TabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblTabDeliveryZone;

    internal virtual Global.System.Windows.Forms.Label lblTabDeliveryZone
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTabDeliveryZone;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTabDeliveryZone != null)
            {
                _lblTabDeliveryZone.Click -= TabLabels_Click;
            }

            _lblTabDeliveryZone = value;
            if (_lblTabDeliveryZone != null)
            {
                _lblTabDeliveryZone.Click += TabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.CheckBox _chkTabVIP;

    internal virtual Global.System.Windows.Forms.CheckBox chkTabVIP
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkTabVIP;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _chkTabVIP = value;
        }
    }
    private Global.System.Windows.Forms.CheckBox _chkTabDoNotDeliver;

    internal virtual Global.System.Windows.Forms.CheckBox chkTabDoNotDeliver
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkTabDoNotDeliver;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _chkTabDoNotDeliver = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlTabInfo;

    internal virtual Global.System.Windows.Forms.Panel pnlTabInfo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlTabInfo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlTabInfo = value;
        }
    }
    private Global.System.Windows.Forms.Panel _Panel4;

    internal virtual Global.System.Windows.Forms.Panel Panel4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel4 = value;
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
    private Global.System.Windows.Forms.Label _lblTabAcctNumber;

    internal virtual Global.System.Windows.Forms.Label lblTabAcctNumber
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTabAcctNumber;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblTabAcctNumber = value;
        }
    }
    private DataSet_Builder.KeyBoard_UC_Black _TabKeyboard;

    internal virtual DataSet_Builder.KeyBoard_UC_Black TabKeyboard
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabKeyboard;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabKeyboard != null)
            {
                _TabKeyboard.StringEntered -= TabKeyboard_Enter;
            }

            _TabKeyboard = value;
            if (_TabKeyboard != null)
            {
                _TabKeyboard.StringEntered += TabKeyboard_Enter;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _Panel1;

    internal virtual Global.System.Windows.Forms.Panel Panel1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel1 = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblTabSearchLocation;

    internal virtual Global.System.Windows.Forms.Label lblTabSearchLocation
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTabSearchLocation;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblTabSearchLocation = value;
        }
    }
    private Global.System.Windows.Forms.TabControl _TabControl1;

    internal virtual Global.System.Windows.Forms.TabControl TabControl1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabControl1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _TabControl1 = value;
        }
    }
    private Global.System.Windows.Forms.Panel _Panel2;

    internal virtual Global.System.Windows.Forms.Panel Panel2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel2 = value;
        }
    }
    private Global.System.Windows.Forms.TabPage _TabPageSearch;

    internal virtual Global.System.Windows.Forms.TabPage TabPageSearch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabPageSearch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _TabPageSearch = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblTabLastName;

    internal virtual Global.System.Windows.Forms.Label lblTabLastName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTabLastName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTabLastName != null)
            {
                _lblTabLastName.Click -= TabLabels_Click;
            }

            _lblTabLastName = value;
            if (_lblTabLastName != null)
            {
                _lblTabLastName.Click += TabLabels_Click;
            }
        }
    }
    private DataSet_Builder.PreviousOrder_UC _PreviousOrder_UC1;

    internal virtual DataSet_Builder.PreviousOrder_UC PreviousOrder_UC1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _PreviousOrder_UC1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_PreviousOrder_UC1 != null)
            {
                _PreviousOrder_UC1.SelectedPanel -= DifferentOrderSelected;
                _PreviousOrder_UC1.SelectedReOrder -= ReorderButtonSelected;
                _PreviousOrder_UC1.SelectedNewOrder -= NewOrderButtonSelected;
            }

            _PreviousOrder_UC1 = value;
            if (_PreviousOrder_UC1 != null)
            {
                _PreviousOrder_UC1.SelectedPanel += DifferentOrderSelected;
                _PreviousOrder_UC1.SelectedReOrder += ReorderButtonSelected;
                _PreviousOrder_UC1.SelectedNewOrder += NewOrderButtonSelected;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnTabEnterNew;

    internal virtual Global.System.Windows.Forms.Button btnTabEnterNew
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnTabEnterNew;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnTabEnterNew != null)
            {
                _btnTabEnterNew.Click -= btnTabEnterNew_Click;
            }

            _btnTabEnterNew = value;
            if (_btnTabEnterNew != null)
            {
                _btnTabEnterNew.Click += btnTabEnterNew_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _pnlNewTabInfo;

    internal virtual Global.System.Windows.Forms.Panel pnlNewTabInfo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlNewTabInfo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlNewTabInfo = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label4;

    internal virtual Global.System.Windows.Forms.Label Label4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label4 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label12;

    internal virtual Global.System.Windows.Forms.Label Label12
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label12;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label12 = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblNewTabAcctNumber;

    internal virtual Global.System.Windows.Forms.Label lblNewTabAcctNumber
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNewTabAcctNumber;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblNewTabAcctNumber = value;
        }
    }
    private Global.System.Windows.Forms.CheckBox _chkNewTabDoNotDeliver;

    internal virtual Global.System.Windows.Forms.CheckBox chkNewTabDoNotDeliver
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkNewTabDoNotDeliver;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _chkNewTabDoNotDeliver = value;
        }
    }
    private Global.System.Windows.Forms.CheckBox _chkNewTabVIP;

    internal virtual Global.System.Windows.Forms.CheckBox chkNewTabVIP
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkNewTabVIP;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _chkNewTabVIP = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblNewTabPhone2;

    internal virtual Global.System.Windows.Forms.Label lblNewTabPhone2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNewTabPhone2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblNewTabPhone2 != null)
            {
                _lblNewTabPhone2.Click -= NewTabLabels_Click;
            }

            _lblNewTabPhone2 = value;
            if (_lblNewTabPhone2 != null)
            {
                _lblNewTabPhone2.Click += NewTabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblNewTabSpecial;

    internal virtual Global.System.Windows.Forms.Label lblNewTabSpecial
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNewTabSpecial;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblNewTabSpecial != null)
            {
                _lblNewTabSpecial.Click -= NewTabLabels_Click;
            }

            _lblNewTabSpecial = value;
            if (_lblNewTabSpecial != null)
            {
                _lblNewTabSpecial.Click += NewTabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblNewTabCrossRoads;

    internal virtual Global.System.Windows.Forms.Label lblNewTabCrossRoads
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNewTabCrossRoads;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblNewTabCrossRoads != null)
            {
                _lblNewTabCrossRoads.Click -= NewTabLabels_Click;
            }

            _lblNewTabCrossRoads = value;
            if (_lblNewTabCrossRoads != null)
            {
                _lblNewTabCrossRoads.Click += NewTabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblNewTabDeliveryZone;

    internal virtual Global.System.Windows.Forms.Label lblNewTabDeliveryZone
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNewTabDeliveryZone;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblNewTabDeliveryZone != null)
            {
                _lblNewTabDeliveryZone.Click -= NewTabLabels_Click;
            }

            _lblNewTabDeliveryZone = value;
            if (_lblNewTabDeliveryZone != null)
            {
                _lblNewTabDeliveryZone.Click += NewTabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblNewTabPhone1;

    internal virtual Global.System.Windows.Forms.Label lblNewTabPhone1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNewTabPhone1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblNewTabPhone1 != null)
            {
                _lblNewTabPhone1.Click -= NewTabLabels_Click;
            }

            _lblNewTabPhone1 = value;
            if (_lblNewTabPhone1 != null)
            {
                _lblNewTabPhone1.Click += NewTabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblNewTabPostalCode;

    internal virtual Global.System.Windows.Forms.Label lblNewTabPostalCode
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNewTabPostalCode;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblNewTabPostalCode != null)
            {
                _lblNewTabPostalCode.Click -= NewTabLabels_Click;
            }

            _lblNewTabPostalCode = value;
            if (_lblNewTabPostalCode != null)
            {
                _lblNewTabPostalCode.Click += NewTabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblNewTabState;

    internal virtual Global.System.Windows.Forms.Label lblNewTabState
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNewTabState;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblNewTabState != null)
            {
                _lblNewTabState.Click -= NewTabLabels_Click;
            }

            _lblNewTabState = value;
            if (_lblNewTabState != null)
            {
                _lblNewTabState.Click += NewTabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblNewTabCity;

    internal virtual Global.System.Windows.Forms.Label lblNewTabCity
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNewTabCity;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblNewTabCity != null)
            {
                _lblNewTabCity.Click -= NewTabLabels_Click;
            }

            _lblNewTabCity = value;
            if (_lblNewTabCity != null)
            {
                _lblNewTabCity.Click += NewTabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblNewTabAddress2;

    internal virtual Global.System.Windows.Forms.Label lblNewTabAddress2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNewTabAddress2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblNewTabAddress2 != null)
            {
                _lblNewTabAddress2.Click -= NewTabLabels_Click;
            }

            _lblNewTabAddress2 = value;
            if (_lblNewTabAddress2 != null)
            {
                _lblNewTabAddress2.Click += NewTabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblNewTabAddress1;

    internal virtual Global.System.Windows.Forms.Label lblNewTabAddress1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNewTabAddress1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblNewTabAddress1 != null)
            {
                _lblNewTabAddress1.Click -= NewTabLabels_Click;
            }

            _lblNewTabAddress1 = value;
            if (_lblNewTabAddress1 != null)
            {
                _lblNewTabAddress1.Click += NewTabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblNewTabLastName;

    internal virtual Global.System.Windows.Forms.Label lblNewTabLastName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNewTabLastName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblNewTabLastName != null)
            {
                _lblNewTabLastName.Click -= NewTabLabels_Click;
            }

            _lblNewTabLastName = value;
            if (_lblNewTabLastName != null)
            {
                _lblNewTabLastName.Click += NewTabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblNewTabFirstName;

    internal virtual Global.System.Windows.Forms.Label lblNewTabFirstName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNewTabFirstName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblNewTabFirstName != null)
            {
                _lblNewTabFirstName.Click -= NewTabLabels_Click;
            }

            _lblNewTabFirstName = value;
            if (_lblNewTabFirstName != null)
            {
                _lblNewTabFirstName.Click += NewTabLabels_Click;
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
    private Global.System.Windows.Forms.Label _Label3;

    internal virtual Global.System.Windows.Forms.Label Label3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label3 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label5;

    internal virtual Global.System.Windows.Forms.Label Label5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label5 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label6;

    internal virtual Global.System.Windows.Forms.Label Label6
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label6;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label6 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label9;

    internal virtual Global.System.Windows.Forms.Label Label9
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label9;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label9 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label10;

    internal virtual Global.System.Windows.Forms.Label Label10
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label10;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label10 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label11;

    internal virtual Global.System.Windows.Forms.Label Label11
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label11;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label11 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label13;

    internal virtual Global.System.Windows.Forms.Label Label13
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label13;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label13 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label14;

    internal virtual Global.System.Windows.Forms.Label Label14
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label14;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label14 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label15;

    internal virtual Global.System.Windows.Forms.Label Label15
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label15;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label15 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label16;

    internal virtual Global.System.Windows.Forms.Label Label16
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label16;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label16 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label17;

    internal virtual Global.System.Windows.Forms.Label Label17
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label17;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label17 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label18;

    internal virtual Global.System.Windows.Forms.Label Label18
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label18;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label18 = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblNewTabExt2;

    internal virtual Global.System.Windows.Forms.Label lblNewTabExt2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNewTabExt2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblNewTabExt2 != null)
            {
                _lblNewTabExt2.Click -= NewTabLabels_Click;
            }

            _lblNewTabExt2 = value;
            if (_lblNewTabExt2 != null)
            {
                _lblNewTabExt2.Click += NewTabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblTabFirstName;

    internal virtual Global.System.Windows.Forms.Label lblTabFirstName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTabFirstName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTabFirstName != null)
            {
                _lblTabFirstName.Click -= TabLabels_Click;
            }

            _lblTabFirstName = value;
            if (_lblTabFirstName != null)
            {
                _lblTabFirstName.Click += TabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _Label19;

    internal virtual Global.System.Windows.Forms.Label Label19
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label19;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label19 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label20;

    internal virtual Global.System.Windows.Forms.Label Label20
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label20;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label20 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label21;

    internal virtual Global.System.Windows.Forms.Label Label21
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label21;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label21 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label22;

    internal virtual Global.System.Windows.Forms.Label Label22
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label22;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label22 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label23;

    internal virtual Global.System.Windows.Forms.Label Label23
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label23;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label23 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label24;

    internal virtual Global.System.Windows.Forms.Label Label24
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label24;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label24 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label25;

    internal virtual Global.System.Windows.Forms.Label Label25
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label25;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label25 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label26;

    internal virtual Global.System.Windows.Forms.Label Label26
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label26;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label26 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label27;

    internal virtual Global.System.Windows.Forms.Label Label27
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label27;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label27 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label28;

    internal virtual Global.System.Windows.Forms.Label Label28
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label28;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label28 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label29;

    internal virtual Global.System.Windows.Forms.Label Label29
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label29;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label29 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label30;

    internal virtual Global.System.Windows.Forms.Label Label30
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label30;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label30 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label31;

    internal virtual Global.System.Windows.Forms.Label Label31
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label31;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label31 = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblTabExt1;

    internal virtual Global.System.Windows.Forms.Label lblTabExt1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTabExt1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblTabExt1 != null)
            {
                _lblTabExt1.Click -= TabLabels_Click;
            }

            _lblTabExt1 = value;
            if (_lblTabExt1 != null)
            {
                _lblTabExt1.Click += TabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnSearchAcctNum;

    internal virtual Global.System.Windows.Forms.Button btnSearchAcctNum
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnSearchAcctNum;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnSearchAcctNum != null)
            {
                _btnSearchAcctNum.Click -= btnSearchAcctNum_Click;
            }

            _btnSearchAcctNum = value;
            if (_btnSearchAcctNum != null)
            {
                _btnSearchAcctNum.Click += btnSearchAcctNum_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnSearchLastName;

    internal virtual Global.System.Windows.Forms.Button btnSearchLastName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnSearchLastName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnSearchLastName != null)
            {
                _btnSearchLastName.Click -= btnSearchLastName_Click;
            }

            _btnSearchLastName = value;
            if (_btnSearchLastName != null)
            {
                _btnSearchLastName.Click += btnSearchLastName_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnSearchPhone;

    internal virtual Global.System.Windows.Forms.Button btnSearchPhone
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnSearchPhone;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnSearchPhone != null)
            {
                _btnSearchPhone.Click -= btnSearchPhone_Click;
            }

            _btnSearchPhone = value;
            if (_btnSearchPhone != null)
            {
                _btnSearchPhone.Click += btnSearchPhone_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnLocationStore;

    internal virtual Global.System.Windows.Forms.Button btnLocationStore
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnLocationStore;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnLocationStore != null)
            {
                _btnLocationStore.Click -= btnLocationStore_Click;
            }

            _btnLocationStore = value;
            if (_btnLocationStore != null)
            {
                _btnLocationStore.Click += btnLocationStore_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnEditEntry;

    internal virtual Global.System.Windows.Forms.Button btnEditEntry
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnEditEntry;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnEditEntry != null)
            {
                _btnEditEntry.Click -= btnEditEntry_Click;
            }

            _btnEditEntry = value;
            if (_btnEditEntry != null)
            {
                _btnEditEntry.Click += btnEditEntry_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _Label32;

    internal virtual Global.System.Windows.Forms.Label Label32
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label32;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label32 = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlEdit;

    internal virtual Global.System.Windows.Forms.Panel pnlEdit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlEdit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlEdit = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnLocationAll;

    internal virtual Global.System.Windows.Forms.Button btnLocationAll
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnLocationAll;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _btnLocationAll = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnCloseSave;

    internal virtual Global.System.Windows.Forms.Button btnCloseSave
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCloseSave;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCloseSave != null)
            {
                _btnCloseSave.Click -= btnCloseSave_Click;
            }

            _btnCloseSave = value;
            if (_btnCloseSave != null)
            {
                _btnCloseSave.Click += btnCloseSave_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblNewTabExt1;

    internal virtual Global.System.Windows.Forms.Label lblNewTabExt1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNewTabExt1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblNewTabExt1 != null)
            {
                _lblNewTabExt1.Click -= NewTabLabels_Click;
            }

            _lblNewTabExt1 = value;
            if (_lblNewTabExt1 != null)
            {
                _lblNewTabExt1.Click += NewTabLabels_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblMethodUse;

    internal virtual Global.System.Windows.Forms.Label lblMethodUse
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblMethodUse;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblMethodUse != null)
            {
                _lblMethodUse.Click -= lblMethodUse_Click;
            }

            _lblMethodUse = value;
            if (_lblMethodUse != null)
            {
                _lblMethodUse.Click += lblMethodUse_Click;
            }
        }
    }

    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _btnCancel = new System.Windows.Forms.Button();
        _btnCancel.Click += btnCancel_Click;
        _Panel4 = new System.Windows.Forms.Panel();
        _btnSearchAcctNum = new System.Windows.Forms.Button();
        _btnSearchAcctNum.Click += btnSearchAcctNum_Click;
        _btnSearchLastName = new System.Windows.Forms.Button();
        _btnSearchLastName.Click += btnSearchLastName_Click;
        _btnSearchPhone = new System.Windows.Forms.Button();
        _btnSearchPhone.Click += btnSearchPhone_Click;
        _Label1 = new System.Windows.Forms.Label();
        _TabKeyboard = new DataSet_Builder.KeyBoard_UC_Black();
        _TabKeyboard.StringEntered += TabKeyboard_Enter;
        _pnlTabInfo = new System.Windows.Forms.Panel();
        _Label33 = new System.Windows.Forms.Label();
        _lblTabEmail = new System.Windows.Forms.Label();
        _lblTabEmail.Click += TabLabels_Click;
        _Label19 = new System.Windows.Forms.Label();
        _Label20 = new System.Windows.Forms.Label();
        _pnlNewTabInfo = new System.Windows.Forms.Panel();
        _Label35 = new System.Windows.Forms.Label();
        _Label18 = new System.Windows.Forms.Label();
        _lblNewTabEmail = new System.Windows.Forms.Label();
        _lblNewTabEmail.Click += NewTabLabels_Click;
        _Label17 = new System.Windows.Forms.Label();
        _Label16 = new System.Windows.Forms.Label();
        _Label15 = new System.Windows.Forms.Label();
        _Label14 = new System.Windows.Forms.Label();
        _Label13 = new System.Windows.Forms.Label();
        _Label11 = new System.Windows.Forms.Label();
        _Label10 = new System.Windows.Forms.Label();
        _Label9 = new System.Windows.Forms.Label();
        _Label6 = new System.Windows.Forms.Label();
        _Label5 = new System.Windows.Forms.Label();
        _Label3 = new System.Windows.Forms.Label();
        _Label2 = new System.Windows.Forms.Label();
        _lblNewTabFirstName = new System.Windows.Forms.Label();
        _lblNewTabFirstName.Click += NewTabLabels_Click;
        _lblNewTabAcctNumber = new System.Windows.Forms.Label();
        _chkNewTabDoNotDeliver = new System.Windows.Forms.CheckBox();
        _chkNewTabVIP = new System.Windows.Forms.CheckBox();
        _lblNewTabExt2 = new System.Windows.Forms.Label();
        _lblNewTabExt2.Click += NewTabLabels_Click;
        _Label4 = new System.Windows.Forms.Label();
        _lblNewTabPhone2 = new System.Windows.Forms.Label();
        _lblNewTabPhone2.Click += NewTabLabels_Click;
        _lblNewTabSpecial = new System.Windows.Forms.Label();
        _lblNewTabSpecial.Click += NewTabLabels_Click;
        _lblNewTabCrossRoads = new System.Windows.Forms.Label();
        _lblNewTabCrossRoads.Click += NewTabLabels_Click;
        _lblNewTabDeliveryZone = new System.Windows.Forms.Label();
        _lblNewTabDeliveryZone.Click += NewTabLabels_Click;
        _lblNewTabExt1 = new System.Windows.Forms.Label();
        _lblNewTabExt1.Click += NewTabLabels_Click;
        _Label12 = new System.Windows.Forms.Label();
        _lblNewTabPhone1 = new System.Windows.Forms.Label();
        _lblNewTabPhone1.Click += NewTabLabels_Click;
        _lblNewTabPostalCode = new System.Windows.Forms.Label();
        _lblNewTabPostalCode.Click += NewTabLabels_Click;
        _lblNewTabState = new System.Windows.Forms.Label();
        _lblNewTabState.Click += NewTabLabels_Click;
        _lblNewTabCity = new System.Windows.Forms.Label();
        _lblNewTabCity.Click += NewTabLabels_Click;
        _lblNewTabAddress2 = new System.Windows.Forms.Label();
        _lblNewTabAddress2.Click += NewTabLabels_Click;
        _lblNewTabAddress1 = new System.Windows.Forms.Label();
        _lblNewTabAddress1.Click += NewTabLabels_Click;
        _lblNewTabLastName = new System.Windows.Forms.Label();
        _lblNewTabLastName.Click += NewTabLabels_Click;
        _Label21 = new System.Windows.Forms.Label();
        _Label22 = new System.Windows.Forms.Label();
        _Label23 = new System.Windows.Forms.Label();
        _Label24 = new System.Windows.Forms.Label();
        _Label25 = new System.Windows.Forms.Label();
        _Label26 = new System.Windows.Forms.Label();
        _Label27 = new System.Windows.Forms.Label();
        _Label28 = new System.Windows.Forms.Label();
        _Label29 = new System.Windows.Forms.Label();
        _Label30 = new System.Windows.Forms.Label();
        _Label31 = new System.Windows.Forms.Label();
        _lblTabFirstName = new System.Windows.Forms.Label();
        _lblTabFirstName.Click += TabLabels_Click;
        _lblTabAcctNumber = new System.Windows.Forms.Label();
        _chkTabDoNotDeliver = new System.Windows.Forms.CheckBox();
        _chkTabVIP = new System.Windows.Forms.CheckBox();
        _lblTabExt2 = new System.Windows.Forms.Label();
        _lblTabExt2.Click += TabLabels_Click;
        _Label7 = new System.Windows.Forms.Label();
        _lblTabPhone2 = new System.Windows.Forms.Label();
        _lblTabPhone2.Click += TabLabels_Click;
        _lblTabSpecial = new System.Windows.Forms.Label();
        _lblTabSpecial.Click += TabLabels_Click;
        _lblTabCrossRoads = new System.Windows.Forms.Label();
        _lblTabCrossRoads.Click += TabLabels_Click;
        _lblTabDeliveryZone = new System.Windows.Forms.Label();
        _lblTabDeliveryZone.Click += TabLabels_Click;
        _lblTabExt1 = new System.Windows.Forms.Label();
        _lblTabExt1.Click += TabLabels_Click;
        _Label8 = new System.Windows.Forms.Label();
        _lblTabPhone1 = new System.Windows.Forms.Label();
        _lblTabPhone1.Click += TabLabels_Click;
        _lblTabPostalCode = new System.Windows.Forms.Label();
        _lblTabPostalCode.Click += TabLabels_Click;
        _lblTabState = new System.Windows.Forms.Label();
        _lblTabState.Click += TabLabels_Click;
        _lblTabCity = new System.Windows.Forms.Label();
        _lblTabCity.Click += TabLabels_Click;
        _lblTabAddress2 = new System.Windows.Forms.Label();
        _lblTabAddress2.Click += TabLabels_Click;
        _lblTabAddress1 = new System.Windows.Forms.Label();
        _lblTabAddress1.Click += TabLabels_Click;
        _lblTabLastName = new System.Windows.Forms.Label();
        _lblTabLastName.Click += TabLabels_Click;
        _Panel3 = new System.Windows.Forms.Panel();
        _TabControl1 = new System.Windows.Forms.TabControl();
        _TabPageSearch = new System.Windows.Forms.TabPage();
        _btnCloseSave = new System.Windows.Forms.Button();
        _btnCloseSave.Click += btnCloseSave_Click;
        _pnlEdit = new System.Windows.Forms.Panel();
        _btnEditEntry = new System.Windows.Forms.Button();
        _btnEditEntry.Click += btnEditEntry_Click;
        _Label32 = new System.Windows.Forms.Label();
        _btnTabEnterNew = new System.Windows.Forms.Button();
        _btnTabEnterNew.Click += btnTabEnterNew_Click;
        _Panel1 = new System.Windows.Forms.Panel();
        _btnLocationAll = new System.Windows.Forms.Button();
        _btnLocationStore = new System.Windows.Forms.Button();
        _btnLocationStore.Click += btnLocationStore_Click;
        _lblTabSearchLocation = new System.Windows.Forms.Label();
        _Panel2 = new System.Windows.Forms.Panel();
        _PreviousOrder_UC1 = new DataSet_Builder.PreviousOrder_UC();
        _PreviousOrder_UC1.SelectedPanel += DifferentOrderSelected;
        _PreviousOrder_UC1.SelectedReOrder += ReorderButtonSelected;
        _PreviousOrder_UC1.SelectedNewOrder += NewOrderButtonSelected;
        _lblMethodUse = new System.Windows.Forms.Label();
        _lblMethodUse.Click += lblMethodUse_Click;
        _Panel4.SuspendLayout();
        _TabKeyboard.SuspendLayout();
        _pnlTabInfo.SuspendLayout();
        _pnlNewTabInfo.SuspendLayout();
        _Panel3.SuspendLayout();
        _TabControl1.SuspendLayout();
        _TabPageSearch.SuspendLayout();
        _pnlEdit.SuspendLayout();
        _Panel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // btnCancel
        // 
        _btnCancel.BackColor = System.Drawing.Color.FromArgb(119, 154, 198);
        _btnCancel.Location = new System.Drawing.Point(488, 4);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.Size = new System.Drawing.Size(80, 32);
        _btnCancel.TabIndex = 4;
        _btnCancel.Text = "Cancel";
        _btnCancel.UseVisualStyleBackColor = false;
        // 
        // Panel4
        // 
        _Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        _Panel4.Controls.Add(_btnSearchAcctNum);
        _Panel4.Controls.Add(_btnSearchLastName);
        _Panel4.Controls.Add(_btnSearchPhone);
        _Panel4.Controls.Add(_Label1);
        _Panel4.Location = new System.Drawing.Point(8, 8);
        _Panel4.Name = "_Panel4";
        _Panel4.Size = new System.Drawing.Size(160, 96);
        _Panel4.TabIndex = 5;
        // 
        // btnSearchAcctNum
        // 
        _btnSearchAcctNum.Location = new System.Drawing.Point(108, 4);
        _btnSearchAcctNum.Name = "_btnSearchAcctNum";
        _btnSearchAcctNum.Size = new System.Drawing.Size(48, 68);
        _btnSearchAcctNum.TabIndex = 3;
        _btnSearchAcctNum.Text = "Acct Num";
        // 
        // btnSearchLastName
        // 
        _btnSearchLastName.Location = new System.Drawing.Point(56, 4);
        _btnSearchLastName.Name = "_btnSearchLastName";
        _btnSearchLastName.Size = new System.Drawing.Size(48, 68);
        _btnSearchLastName.TabIndex = 2;
        _btnSearchLastName.Text = "Last Name";
        // 
        // btnSearchPhone
        // 
        _btnSearchPhone.BackColor = System.Drawing.Color.FromArgb(119, 154, 198);
        _btnSearchPhone.Location = new System.Drawing.Point(4, 4);
        _btnSearchPhone.Name = "_btnSearchPhone";
        _btnSearchPhone.Size = new System.Drawing.Size(48, 68);
        _btnSearchPhone.TabIndex = 1;
        _btnSearchPhone.Text = "Phone";
        _btnSearchPhone.UseVisualStyleBackColor = false;
        // 
        // Label1
        // 
        _Label1.BackColor = System.Drawing.Color.FromArgb(119, 154, 198);
        _Label1.Location = new System.Drawing.Point(0, 76);
        _Label1.Name = "_Label1";
        _Label1.Size = new System.Drawing.Size(160, 20);
        _Label1.TabIndex = 0;
        _Label1.Text = "Search By";
        _Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // TabKeyboard
        // 
        _TabKeyboard.BackColor = System.Drawing.Color.FromArgb(119, 154, 198);
        _TabKeyboard.Controls.Add(_pnlTabInfo);
        _TabKeyboard.EnteredString = "";
        _TabKeyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _TabKeyboard.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _TabKeyboard.IsCapital = true;
        _TabKeyboard.Location = new System.Drawing.Point(8, 128);
        _TabKeyboard.Name = "_TabKeyboard";
        _TabKeyboard.OnlyOneCap = true;
        _TabKeyboard.Size = new System.Drawing.Size(584, 544);
        _TabKeyboard.TabIndex = 0;
        // 
        // pnlTabInfo
        // 
        _pnlTabInfo.BackColor = System.Drawing.Color.FromArgb(119, 154, 198);
        _pnlTabInfo.Controls.Add(_Label33);
        _pnlTabInfo.Controls.Add(_lblTabEmail);
        _pnlTabInfo.Controls.Add(_Label19);
        _pnlTabInfo.Controls.Add(_Label20);
        _pnlTabInfo.Controls.Add(_pnlNewTabInfo);
        _pnlTabInfo.Controls.Add(_Label21);
        _pnlTabInfo.Controls.Add(_Label22);
        _pnlTabInfo.Controls.Add(_Label23);
        _pnlTabInfo.Controls.Add(_Label24);
        _pnlTabInfo.Controls.Add(_Label25);
        _pnlTabInfo.Controls.Add(_Label26);
        _pnlTabInfo.Controls.Add(_Label27);
        _pnlTabInfo.Controls.Add(_Label28);
        _pnlTabInfo.Controls.Add(_Label29);
        _pnlTabInfo.Controls.Add(_Label30);
        _pnlTabInfo.Controls.Add(_Label31);
        _pnlTabInfo.Controls.Add(_lblTabFirstName);
        _pnlTabInfo.Controls.Add(_lblTabAcctNumber);
        _pnlTabInfo.Controls.Add(_chkTabDoNotDeliver);
        _pnlTabInfo.Controls.Add(_chkTabVIP);
        _pnlTabInfo.Controls.Add(_lblTabExt2);
        _pnlTabInfo.Controls.Add(_Label7);
        _pnlTabInfo.Controls.Add(_lblTabPhone2);
        _pnlTabInfo.Controls.Add(_lblTabSpecial);
        _pnlTabInfo.Controls.Add(_lblTabCrossRoads);
        _pnlTabInfo.Controls.Add(_lblTabDeliveryZone);
        _pnlTabInfo.Controls.Add(_lblTabExt1);
        _pnlTabInfo.Controls.Add(_Label8);
        _pnlTabInfo.Controls.Add(_lblTabPhone1);
        _pnlTabInfo.Controls.Add(_lblTabPostalCode);
        _pnlTabInfo.Controls.Add(_lblTabState);
        _pnlTabInfo.Controls.Add(_lblTabCity);
        _pnlTabInfo.Controls.Add(_lblTabAddress2);
        _pnlTabInfo.Controls.Add(_lblTabAddress1);
        _pnlTabInfo.Controls.Add(_lblTabLastName);
        _pnlTabInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _pnlTabInfo.ForeColor = System.Drawing.Color.Black;
        _pnlTabInfo.Location = new System.Drawing.Point(4, 8);
        _pnlTabInfo.Name = "_pnlTabInfo";
        _pnlTabInfo.Size = new System.Drawing.Size(360, 292);
        _pnlTabInfo.TabIndex = 6;
        // 
        // Label33
        // 
        _Label33.Location = new System.Drawing.Point(21, 160);
        _Label33.Name = "_Label33";
        _Label33.Size = new System.Drawing.Size(40, 18);
        _Label33.TabIndex = 127;
        _Label33.Text = "email";
        _Label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblTabEmail
        // 
        _lblTabEmail.BackColor = System.Drawing.Color.FromArgb(224, 241, 254);
        _lblTabEmail.Location = new System.Drawing.Point(68, 158);
        _lblTabEmail.Name = "_lblTabEmail";
        _lblTabEmail.Size = new System.Drawing.Size(224, 20);
        _lblTabEmail.TabIndex = 11;
        _lblTabEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label19
        // 
        _Label19.Location = new System.Drawing.Point(4, 237);
        _Label19.Name = "_Label19";
        _Label19.Size = new System.Drawing.Size(72, 36);
        _Label19.TabIndex = 125;
        _Label19.Text = "Special Instructions";
        _Label19.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // Label20
        // 
        _Label20.Location = new System.Drawing.Point(4, 215);
        _Label20.Name = "_Label20";
        _Label20.Size = new System.Drawing.Size(72, 20);
        _Label20.TabIndex = 124;
        _Label20.Text = "CrossRoads: ";
        _Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // pnlNewTabInfo
        // 
        _pnlNewTabInfo.BackColor = System.Drawing.Color.FromArgb(224, 241, 254);
        _pnlNewTabInfo.Controls.Add(_Label35);
        _pnlNewTabInfo.Controls.Add(_Label18);
        _pnlNewTabInfo.Controls.Add(_lblNewTabEmail);
        _pnlNewTabInfo.Controls.Add(_Label17);
        _pnlNewTabInfo.Controls.Add(_Label16);
        _pnlNewTabInfo.Controls.Add(_Label15);
        _pnlNewTabInfo.Controls.Add(_Label14);
        _pnlNewTabInfo.Controls.Add(_Label13);
        _pnlNewTabInfo.Controls.Add(_Label11);
        _pnlNewTabInfo.Controls.Add(_Label10);
        _pnlNewTabInfo.Controls.Add(_Label9);
        _pnlNewTabInfo.Controls.Add(_Label6);
        _pnlNewTabInfo.Controls.Add(_Label5);
        _pnlNewTabInfo.Controls.Add(_Label3);
        _pnlNewTabInfo.Controls.Add(_Label2);
        _pnlNewTabInfo.Controls.Add(_lblNewTabFirstName);
        _pnlNewTabInfo.Controls.Add(_lblNewTabAcctNumber);
        _pnlNewTabInfo.Controls.Add(_chkNewTabDoNotDeliver);
        _pnlNewTabInfo.Controls.Add(_chkNewTabVIP);
        _pnlNewTabInfo.Controls.Add(_lblNewTabExt2);
        _pnlNewTabInfo.Controls.Add(_Label4);
        _pnlNewTabInfo.Controls.Add(_lblNewTabPhone2);
        _pnlNewTabInfo.Controls.Add(_lblNewTabSpecial);
        _pnlNewTabInfo.Controls.Add(_lblNewTabCrossRoads);
        _pnlNewTabInfo.Controls.Add(_lblNewTabDeliveryZone);
        _pnlNewTabInfo.Controls.Add(_lblNewTabExt1);
        _pnlNewTabInfo.Controls.Add(_Label12);
        _pnlNewTabInfo.Controls.Add(_lblNewTabPhone1);
        _pnlNewTabInfo.Controls.Add(_lblNewTabPostalCode);
        _pnlNewTabInfo.Controls.Add(_lblNewTabState);
        _pnlNewTabInfo.Controls.Add(_lblNewTabCity);
        _pnlNewTabInfo.Controls.Add(_lblNewTabAddress2);
        _pnlNewTabInfo.Controls.Add(_lblNewTabAddress1);
        _pnlNewTabInfo.Controls.Add(_lblNewTabLastName);
        _pnlNewTabInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _pnlNewTabInfo.ForeColor = System.Drawing.Color.Black;
        _pnlNewTabInfo.Location = new System.Drawing.Point(199, 252);
        _pnlNewTabInfo.Name = "_pnlNewTabInfo";
        _pnlNewTabInfo.Size = new System.Drawing.Size(360, 292);
        _pnlNewTabInfo.TabIndex = 20;
        _pnlNewTabInfo.Visible = false;
        // 
        // Label35
        // 
        _Label35.Location = new System.Drawing.Point(22, 156);
        _Label35.Name = "_Label35";
        _Label35.Size = new System.Drawing.Size(40, 18);
        _Label35.TabIndex = 129;
        _Label35.Text = "email";
        _Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label18
        // 
        _Label18.Location = new System.Drawing.Point(4, 237);
        _Label18.Name = "_Label18";
        _Label18.Size = new System.Drawing.Size(72, 36);
        _Label18.TabIndex = 112;
        _Label18.Text = "Special Instructions";
        _Label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // lblNewTabEmail
        // 
        _lblNewTabEmail.BackColor = System.Drawing.Color.White;
        _lblNewTabEmail.Location = new System.Drawing.Point(68, 158);
        _lblNewTabEmail.Name = "_lblNewTabEmail";
        _lblNewTabEmail.Size = new System.Drawing.Size(224, 20);
        _lblNewTabEmail.TabIndex = 128;
        _lblNewTabEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label17
        // 
        _Label17.Location = new System.Drawing.Point(2, 214);
        _Label17.Name = "_Label17";
        _Label17.Size = new System.Drawing.Size(72, 20);
        _Label17.TabIndex = 111;
        _Label17.Text = "CrossRoads: ";
        _Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label16
        // 
        _Label16.Location = new System.Drawing.Point(4, 195);
        _Label16.Name = "_Label16";
        _Label16.Size = new System.Drawing.Size(72, 20);
        _Label16.TabIndex = 110;
        _Label16.Text = "Deliver Zone: ";
        _Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label15
        // 
        _Label15.Location = new System.Drawing.Point(22, 136);
        _Label15.Name = "_Label15";
        _Label15.Size = new System.Drawing.Size(40, 18);
        _Label15.TabIndex = 109;
        _Label15.Text = "Acct#: ";
        _Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label14
        // 
        _Label14.Location = new System.Drawing.Point(18, 116);
        _Label14.Name = "_Label14";
        _Label14.Size = new System.Drawing.Size(44, 18);
        _Label14.TabIndex = 108;
        _Label14.Text = "Phone2";
        _Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label13
        // 
        _Label13.Location = new System.Drawing.Point(18, 94);
        _Label13.Name = "_Label13";
        _Label13.Size = new System.Drawing.Size(44, 20);
        _Label13.TabIndex = 107;
        _Label13.Text = "Phone1";
        _Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label11
        // 
        _Label11.Location = new System.Drawing.Point(210, 72);
        _Label11.Name = "_Label11";
        _Label11.Size = new System.Drawing.Size(20, 20);
        _Label11.TabIndex = 106;
        _Label11.Text = "Zip";
        _Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label10
        // 
        _Label10.Location = new System.Drawing.Point(162, 72);
        _Label10.Name = "_Label10";
        _Label10.Size = new System.Drawing.Size(20, 20);
        _Label10.TabIndex = 105;
        _Label10.Text = "St: ";
        _Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label9
        // 
        _Label9.Location = new System.Drawing.Point(26, 72);
        _Label9.Name = "_Label9";
        _Label9.Size = new System.Drawing.Size(36, 20);
        _Label9.TabIndex = 104;
        _Label9.Text = "City: ";
        _Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label6
        // 
        _Label6.Location = new System.Drawing.Point(4, 52);
        _Label6.Name = "_Label6";
        _Label6.Size = new System.Drawing.Size(60, 18);
        _Label6.TabIndex = 103;
        _Label6.Text = "Addr2: ";
        _Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label5
        // 
        _Label5.Location = new System.Drawing.Point(4, 30);
        _Label5.Name = "_Label5";
        _Label5.Size = new System.Drawing.Size(60, 20);
        _Label5.TabIndex = 102;
        _Label5.Text = "Addr1: ";
        _Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label3
        // 
        _Label3.Location = new System.Drawing.Point(198, 8);
        _Label3.Name = "_Label3";
        _Label3.Size = new System.Drawing.Size(30, 20);
        _Label3.TabIndex = 101;
        _Label3.Text = "First: ";
        _Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label2
        // 
        _Label2.Location = new System.Drawing.Point(4, 8);
        _Label2.Name = "_Label2";
        _Label2.Size = new System.Drawing.Size(60, 20);
        _Label2.TabIndex = 100;
        _Label2.Text = "LastName: ";
        _Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblNewTabFirstName
        // 
        _lblNewTabFirstName.BackColor = System.Drawing.Color.White;
        _lblNewTabFirstName.Location = new System.Drawing.Point(228, 8);
        _lblNewTabFirstName.Name = "_lblNewTabFirstName";
        _lblNewTabFirstName.Size = new System.Drawing.Size(64, 20);
        _lblNewTabFirstName.TabIndex = 1;
        _lblNewTabFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblNewTabAcctNumber
        // 
        _lblNewTabAcctNumber.BackColor = System.Drawing.Color.White;
        _lblNewTabAcctNumber.Location = new System.Drawing.Point(68, 136);
        _lblNewTabAcctNumber.Name = "_lblNewTabAcctNumber";
        _lblNewTabAcctNumber.Size = new System.Drawing.Size(224, 20);
        _lblNewTabAcctNumber.TabIndex = 99;
        _lblNewTabAcctNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // chkNewTabDoNotDeliver
        // 
        _chkNewTabDoNotDeliver.Location = new System.Drawing.Point(244, 212);
        _chkNewTabDoNotDeliver.Name = "_chkNewTabDoNotDeliver";
        _chkNewTabDoNotDeliver.Size = new System.Drawing.Size(100, 24);
        _chkNewTabDoNotDeliver.TabIndex = 18;
        _chkNewTabDoNotDeliver.Text = "Do Not Deliver";
        // 
        // chkNewTabVIP
        // 
        _chkNewTabVIP.Location = new System.Drawing.Point(244, 190);
        _chkNewTabVIP.Name = "_chkNewTabVIP";
        _chkNewTabVIP.Size = new System.Drawing.Size(48, 24);
        _chkNewTabVIP.TabIndex = 17;
        _chkNewTabVIP.Text = "VIP";
        // 
        // lblNewTabExt2
        // 
        _lblNewTabExt2.BackColor = System.Drawing.Color.White;
        _lblNewTabExt2.ForeColor = System.Drawing.Color.Black;
        _lblNewTabExt2.Location = new System.Drawing.Point(196, 116);
        _lblNewTabExt2.Name = "_lblNewTabExt2";
        _lblNewTabExt2.Size = new System.Drawing.Size(32, 18);
        _lblNewTabExt2.TabIndex = 16;
        _lblNewTabExt2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label4
        // 
        _Label4.Enabled = false;
        _Label4.Location = new System.Drawing.Point(170, 116);
        _Label4.Name = "_Label4";
        _Label4.Size = new System.Drawing.Size(24, 18);
        _Label4.TabIndex = 99;
        _Label4.Text = "ext.";
        _Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblNewTabPhone2
        // 
        _lblNewTabPhone2.BackColor = System.Drawing.Color.White;
        _lblNewTabPhone2.Location = new System.Drawing.Point(68, 116);
        _lblNewTabPhone2.Name = "_lblNewTabPhone2";
        _lblNewTabPhone2.Size = new System.Drawing.Size(92, 18);
        _lblNewTabPhone2.TabIndex = 14;
        _lblNewTabPhone2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblNewTabSpecial
        // 
        _lblNewTabSpecial.BackColor = System.Drawing.Color.White;
        _lblNewTabSpecial.Location = new System.Drawing.Point(80, 237);
        _lblNewTabSpecial.Name = "_lblNewTabSpecial";
        _lblNewTabSpecial.Size = new System.Drawing.Size(242, 54);
        _lblNewTabSpecial.TabIndex = 11;
        _lblNewTabSpecial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblNewTabCrossRoads
        // 
        _lblNewTabCrossRoads.BackColor = System.Drawing.Color.White;
        _lblNewTabCrossRoads.Location = new System.Drawing.Point(80, 215);
        _lblNewTabCrossRoads.Name = "_lblNewTabCrossRoads";
        _lblNewTabCrossRoads.Size = new System.Drawing.Size(156, 20);
        _lblNewTabCrossRoads.TabIndex = 10;
        _lblNewTabCrossRoads.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblNewTabDeliveryZone
        // 
        _lblNewTabDeliveryZone.BackColor = System.Drawing.Color.White;
        _lblNewTabDeliveryZone.Location = new System.Drawing.Point(80, 193);
        _lblNewTabDeliveryZone.Name = "_lblNewTabDeliveryZone";
        _lblNewTabDeliveryZone.Size = new System.Drawing.Size(156, 20);
        _lblNewTabDeliveryZone.TabIndex = 9;
        _lblNewTabDeliveryZone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblNewTabExt1
        // 
        _lblNewTabExt1.BackColor = System.Drawing.Color.White;
        _lblNewTabExt1.Location = new System.Drawing.Point(196, 94);
        _lblNewTabExt1.Name = "_lblNewTabExt1";
        _lblNewTabExt1.Size = new System.Drawing.Size(32, 20);
        _lblNewTabExt1.TabIndex = 8;
        _lblNewTabExt1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label12
        // 
        _Label12.Enabled = false;
        _Label12.Location = new System.Drawing.Point(170, 94);
        _Label12.Name = "_Label12";
        _Label12.Size = new System.Drawing.Size(24, 20);
        _Label12.TabIndex = 99;
        _Label12.Text = "ext.";
        _Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblNewTabPhone1
        // 
        _lblNewTabPhone1.BackColor = System.Drawing.Color.White;
        _lblNewTabPhone1.Location = new System.Drawing.Point(68, 94);
        _lblNewTabPhone1.Name = "_lblNewTabPhone1";
        _lblNewTabPhone1.Size = new System.Drawing.Size(92, 20);
        _lblNewTabPhone1.TabIndex = 7;
        _lblNewTabPhone1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblNewTabPostalCode
        // 
        _lblNewTabPostalCode.BackColor = System.Drawing.Color.White;
        _lblNewTabPostalCode.Location = new System.Drawing.Point(230, 72);
        _lblNewTabPostalCode.Name = "_lblNewTabPostalCode";
        _lblNewTabPostalCode.Size = new System.Drawing.Size(62, 20);
        _lblNewTabPostalCode.TabIndex = 6;
        _lblNewTabPostalCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblNewTabState
        // 
        _lblNewTabState.BackColor = System.Drawing.Color.White;
        _lblNewTabState.Location = new System.Drawing.Point(184, 72);
        _lblNewTabState.Name = "_lblNewTabState";
        _lblNewTabState.Size = new System.Drawing.Size(26, 20);
        _lblNewTabState.TabIndex = 5;
        _lblNewTabState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblNewTabCity
        // 
        _lblNewTabCity.BackColor = System.Drawing.Color.White;
        _lblNewTabCity.Location = new System.Drawing.Point(68, 72);
        _lblNewTabCity.Name = "_lblNewTabCity";
        _lblNewTabCity.Size = new System.Drawing.Size(92, 20);
        _lblNewTabCity.TabIndex = 4;
        _lblNewTabCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblNewTabAddress2
        // 
        _lblNewTabAddress2.BackColor = System.Drawing.Color.White;
        _lblNewTabAddress2.Location = new System.Drawing.Point(68, 52);
        _lblNewTabAddress2.Name = "_lblNewTabAddress2";
        _lblNewTabAddress2.Size = new System.Drawing.Size(224, 18);
        _lblNewTabAddress2.TabIndex = 3;
        _lblNewTabAddress2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblNewTabAddress1
        // 
        _lblNewTabAddress1.BackColor = System.Drawing.Color.White;
        _lblNewTabAddress1.Location = new System.Drawing.Point(68, 30);
        _lblNewTabAddress1.Name = "_lblNewTabAddress1";
        _lblNewTabAddress1.Size = new System.Drawing.Size(224, 20);
        _lblNewTabAddress1.TabIndex = 2;
        _lblNewTabAddress1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblNewTabLastName
        // 
        _lblNewTabLastName.BackColor = System.Drawing.Color.White;
        _lblNewTabLastName.Location = new System.Drawing.Point(68, 8);
        _lblNewTabLastName.Name = "_lblNewTabLastName";
        _lblNewTabLastName.Size = new System.Drawing.Size(126, 20);
        _lblNewTabLastName.TabIndex = 0;
        _lblNewTabLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label21
        // 
        _Label21.Location = new System.Drawing.Point(5, 195);
        _Label21.Name = "_Label21";
        _Label21.Size = new System.Drawing.Size(72, 20);
        _Label21.TabIndex = 123;
        _Label21.Text = "Deliver Zone: ";
        _Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label22
        // 
        _Label22.Location = new System.Drawing.Point(21, 138);
        _Label22.Name = "_Label22";
        _Label22.Size = new System.Drawing.Size(40, 18);
        _Label22.TabIndex = 122;
        _Label22.Text = "Acct#: ";
        _Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label23
        // 
        _Label23.Location = new System.Drawing.Point(18, 116);
        _Label23.Name = "_Label23";
        _Label23.Size = new System.Drawing.Size(44, 18);
        _Label23.TabIndex = 121;
        _Label23.Text = "Phone2";
        _Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label24
        // 
        _Label24.Location = new System.Drawing.Point(18, 94);
        _Label24.Name = "_Label24";
        _Label24.Size = new System.Drawing.Size(44, 20);
        _Label24.TabIndex = 120;
        _Label24.Text = "Phone1";
        _Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label25
        // 
        _Label25.Location = new System.Drawing.Point(210, 72);
        _Label25.Name = "_Label25";
        _Label25.Size = new System.Drawing.Size(20, 20);
        _Label25.TabIndex = 119;
        _Label25.Text = "Zip";
        _Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label26
        // 
        _Label26.Location = new System.Drawing.Point(164, 72);
        _Label26.Name = "_Label26";
        _Label26.Size = new System.Drawing.Size(20, 20);
        _Label26.TabIndex = 118;
        _Label26.Text = "St: ";
        _Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label27
        // 
        _Label27.Location = new System.Drawing.Point(26, 72);
        _Label27.Name = "_Label27";
        _Label27.Size = new System.Drawing.Size(36, 20);
        _Label27.TabIndex = 117;
        _Label27.Text = "City: ";
        _Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label28
        // 
        _Label28.Location = new System.Drawing.Point(4, 52);
        _Label28.Name = "_Label28";
        _Label28.Size = new System.Drawing.Size(60, 18);
        _Label28.TabIndex = 116;
        _Label28.Text = "Addr2: ";
        _Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label29
        // 
        _Label29.Location = new System.Drawing.Point(4, 30);
        _Label29.Name = "_Label29";
        _Label29.Size = new System.Drawing.Size(60, 20);
        _Label29.TabIndex = 115;
        _Label29.Text = "Addr1: ";
        _Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label30
        // 
        _Label30.Location = new System.Drawing.Point(198, 8);
        _Label30.Name = "_Label30";
        _Label30.Size = new System.Drawing.Size(30, 20);
        _Label30.TabIndex = 114;
        _Label30.Text = "First: ";
        _Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label31
        // 
        _Label31.Location = new System.Drawing.Point(4, 8);
        _Label31.Name = "_Label31";
        _Label31.Size = new System.Drawing.Size(60, 20);
        _Label31.TabIndex = 113;
        _Label31.Text = "LastName: ";
        _Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblTabFirstName
        // 
        _lblTabFirstName.BackColor = System.Drawing.Color.FromArgb(224, 241, 254);
        _lblTabFirstName.Location = new System.Drawing.Point(228, 8);
        _lblTabFirstName.Name = "_lblTabFirstName";
        _lblTabFirstName.Size = new System.Drawing.Size(64, 20);
        _lblTabFirstName.TabIndex = 2;
        _lblTabFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblTabAcctNumber
        // 
        _lblTabAcctNumber.BackColor = System.Drawing.Color.FromArgb(224, 241, 254);
        _lblTabAcctNumber.Location = new System.Drawing.Point(68, 136);
        _lblTabAcctNumber.Name = "_lblTabAcctNumber";
        _lblTabAcctNumber.Size = new System.Drawing.Size(224, 20);
        _lblTabAcctNumber.TabIndex = 99;
        _lblTabAcctNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // chkTabDoNotDeliver
        // 
        _chkTabDoNotDeliver.Location = new System.Drawing.Point(248, 215);
        _chkTabDoNotDeliver.Name = "_chkTabDoNotDeliver";
        _chkTabDoNotDeliver.Size = new System.Drawing.Size(70, 22);
        _chkTabDoNotDeliver.TabIndex = 18;
        _chkTabDoNotDeliver.Text = "Warning";
        // 
        // chkTabVIP
        // 
        _chkTabVIP.Location = new System.Drawing.Point(248, 197);
        _chkTabVIP.Name = "_chkTabVIP";
        _chkTabVIP.Size = new System.Drawing.Size(64, 18);
        _chkTabVIP.TabIndex = 17;
        _chkTabVIP.Text = "VIP";
        // 
        // lblTabExt2
        // 
        _lblTabExt2.BackColor = System.Drawing.Color.FromArgb(224, 241, 254);
        _lblTabExt2.Location = new System.Drawing.Point(196, 116);
        _lblTabExt2.Name = "_lblTabExt2";
        _lblTabExt2.Size = new System.Drawing.Size(32, 18);
        _lblTabExt2.TabIndex = 11;
        _lblTabExt2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label7
        // 
        _Label7.Location = new System.Drawing.Point(168, 116);
        _Label7.Name = "_Label7";
        _Label7.Size = new System.Drawing.Size(24, 20);
        _Label7.TabIndex = 15;
        _Label7.Text = "ext.";
        // 
        // lblTabPhone2
        // 
        _lblTabPhone2.BackColor = System.Drawing.Color.FromArgb(224, 241, 254);
        _lblTabPhone2.Location = new System.Drawing.Point(68, 116);
        _lblTabPhone2.Name = "_lblTabPhone2";
        _lblTabPhone2.Size = new System.Drawing.Size(92, 18);
        _lblTabPhone2.TabIndex = 10;
        _lblTabPhone2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblTabSpecial
        // 
        _lblTabSpecial.BackColor = System.Drawing.Color.FromArgb(224, 241, 254);
        _lblTabSpecial.Location = new System.Drawing.Point(80, 237);
        _lblTabSpecial.Name = "_lblTabSpecial";
        _lblTabSpecial.Size = new System.Drawing.Size(242, 54);
        _lblTabSpecial.TabIndex = 14;
        // 
        // lblTabCrossRoads
        // 
        _lblTabCrossRoads.BackColor = System.Drawing.Color.FromArgb(224, 241, 254);
        _lblTabCrossRoads.Location = new System.Drawing.Point(80, 215);
        _lblTabCrossRoads.Name = "_lblTabCrossRoads";
        _lblTabCrossRoads.Size = new System.Drawing.Size(156, 20);
        _lblTabCrossRoads.TabIndex = 13;
        _lblTabCrossRoads.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblTabDeliveryZone
        // 
        _lblTabDeliveryZone.BackColor = System.Drawing.Color.FromArgb(224, 241, 254);
        _lblTabDeliveryZone.Location = new System.Drawing.Point(80, 193);
        _lblTabDeliveryZone.Name = "_lblTabDeliveryZone";
        _lblTabDeliveryZone.Size = new System.Drawing.Size(156, 20);
        _lblTabDeliveryZone.TabIndex = 12;
        _lblTabDeliveryZone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblTabExt1
        // 
        _lblTabExt1.BackColor = System.Drawing.Color.FromArgb(224, 241, 254);
        _lblTabExt1.Location = new System.Drawing.Point(196, 94);
        _lblTabExt1.Name = "_lblTabExt1";
        _lblTabExt1.Size = new System.Drawing.Size(32, 20);
        _lblTabExt1.TabIndex = 9;
        _lblTabExt1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Label8
        // 
        _Label8.Location = new System.Drawing.Point(168, 94);
        _Label8.Name = "_Label8";
        _Label8.Size = new System.Drawing.Size(24, 20);
        _Label8.TabIndex = 7;
        _Label8.Text = "ext.";
        // 
        // lblTabPhone1
        // 
        _lblTabPhone1.BackColor = System.Drawing.Color.FromArgb(224, 241, 254);
        _lblTabPhone1.Location = new System.Drawing.Point(68, 94);
        _lblTabPhone1.Name = "_lblTabPhone1";
        _lblTabPhone1.Size = new System.Drawing.Size(92, 20);
        _lblTabPhone1.TabIndex = 8;
        _lblTabPhone1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblTabPostalCode
        // 
        _lblTabPostalCode.BackColor = System.Drawing.Color.FromArgb(224, 241, 254);
        _lblTabPostalCode.Location = new System.Drawing.Point(230, 72);
        _lblTabPostalCode.Name = "_lblTabPostalCode";
        _lblTabPostalCode.Size = new System.Drawing.Size(62, 20);
        _lblTabPostalCode.TabIndex = 7;
        _lblTabPostalCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblTabState
        // 
        _lblTabState.BackColor = System.Drawing.Color.FromArgb(224, 241, 254);
        _lblTabState.Location = new System.Drawing.Point(186, 72);
        _lblTabState.Name = "_lblTabState";
        _lblTabState.Size = new System.Drawing.Size(24, 20);
        _lblTabState.TabIndex = 6;
        _lblTabState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblTabCity
        // 
        _lblTabCity.BackColor = System.Drawing.Color.FromArgb(224, 241, 254);
        _lblTabCity.Location = new System.Drawing.Point(68, 72);
        _lblTabCity.Name = "_lblTabCity";
        _lblTabCity.Size = new System.Drawing.Size(92, 20);
        _lblTabCity.TabIndex = 5;
        _lblTabCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblTabAddress2
        // 
        _lblTabAddress2.BackColor = System.Drawing.Color.FromArgb(224, 241, 254);
        _lblTabAddress2.Location = new System.Drawing.Point(68, 52);
        _lblTabAddress2.Name = "_lblTabAddress2";
        _lblTabAddress2.Size = new System.Drawing.Size(224, 18);
        _lblTabAddress2.TabIndex = 4;
        _lblTabAddress2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblTabAddress1
        // 
        _lblTabAddress1.BackColor = System.Drawing.Color.FromArgb(224, 241, 254);
        _lblTabAddress1.Location = new System.Drawing.Point(68, 30);
        _lblTabAddress1.Name = "_lblTabAddress1";
        _lblTabAddress1.Size = new System.Drawing.Size(224, 20);
        _lblTabAddress1.TabIndex = 3;
        _lblTabAddress1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblTabLastName
        // 
        _lblTabLastName.BackColor = System.Drawing.Color.FromArgb(224, 241, 254);
        _lblTabLastName.Location = new System.Drawing.Point(68, 8);
        _lblTabLastName.Name = "_lblTabLastName";
        _lblTabLastName.Size = new System.Drawing.Size(126, 20);
        _lblTabLastName.TabIndex = 1;
        _lblTabLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Panel3
        // 
        _Panel3.BackColor = System.Drawing.Color.FromArgb(0, 0, 100);
        _Panel3.Controls.Add(_TabControl1);
        _Panel3.Controls.Add(_Panel2);
        _Panel3.Controls.Add(_TabKeyboard);
        _Panel3.Location = new System.Drawing.Point(356, 8);
        _Panel3.Name = "_Panel3";
        _Panel3.Size = new System.Drawing.Size(600, 676);
        _Panel3.TabIndex = 7;
        // 
        // TabControl1
        // 
        _TabControl1.Controls.Add(_TabPageSearch);
        _TabControl1.ItemSize = new System.Drawing.Size(90, 18);
        _TabControl1.Location = new System.Drawing.Point(8, 4);
        _TabControl1.Name = "_TabControl1";
        _TabControl1.SelectedIndex = 0;
        _TabControl1.Size = new System.Drawing.Size(584, 132);
        _TabControl1.TabIndex = 7;
        // 
        // TabPageSearch
        // 
        _TabPageSearch.BackColor = System.Drawing.Color.FromArgb(224, 241, 254);
        _TabPageSearch.Controls.Add(_btnCloseSave);
        _TabPageSearch.Controls.Add(_pnlEdit);
        _TabPageSearch.Controls.Add(_Panel4);
        _TabPageSearch.Controls.Add(_Panel1);
        _TabPageSearch.Controls.Add(_btnCancel);
        _TabPageSearch.Location = new System.Drawing.Point(4, 22);
        _TabPageSearch.Name = "_TabPageSearch";
        _TabPageSearch.Size = new System.Drawing.Size(576, 106);
        _TabPageSearch.TabIndex = 0;
        _TabPageSearch.Text = "Search";
        // 
        // btnCloseSave
        // 
        _btnCloseSave.BackColor = System.Drawing.Color.FromArgb(119, 154, 198);
        _btnCloseSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnCloseSave.Location = new System.Drawing.Point(488, 44);
        _btnCloseSave.Name = "_btnCloseSave";
        _btnCloseSave.Size = new System.Drawing.Size(80, 56);
        _btnCloseSave.TabIndex = 9;
        _btnCloseSave.Text = "Save && Close";
        _btnCloseSave.UseVisualStyleBackColor = false;
        // 
        // pnlEdit
        // 
        _pnlEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        _pnlEdit.Controls.Add(_btnEditEntry);
        _pnlEdit.Controls.Add(_Label32);
        _pnlEdit.Controls.Add(_btnTabEnterNew);
        _pnlEdit.Location = new System.Drawing.Point(292, 8);
        _pnlEdit.Name = "_pnlEdit";
        _pnlEdit.Size = new System.Drawing.Size(108, 96);
        _pnlEdit.TabIndex = 8;
        _pnlEdit.Visible = false;
        // 
        // btnEditEntry
        // 
        _btnEditEntry.Location = new System.Drawing.Point(56, 4);
        _btnEditEntry.Name = "_btnEditEntry";
        _btnEditEntry.Size = new System.Drawing.Size(48, 68);
        _btnEditEntry.TabIndex = 2;
        _btnEditEntry.Text = "Edit Entry";
        // 
        // Label32
        // 
        _Label32.BackColor = System.Drawing.Color.FromArgb(119, 154, 198);
        _Label32.Location = new System.Drawing.Point(0, 76);
        _Label32.Name = "_Label32";
        _Label32.Size = new System.Drawing.Size(112, 20);
        _Label32.TabIndex = 0;
        _Label32.Text = "Edit";
        _Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btnTabEnterNew
        // 
        _btnTabEnterNew.BackColor = System.Drawing.Color.FromArgb(224, 241, 254);
        _btnTabEnterNew.Location = new System.Drawing.Point(4, 4);
        _btnTabEnterNew.Name = "_btnTabEnterNew";
        _btnTabEnterNew.Size = new System.Drawing.Size(48, 68);
        _btnTabEnterNew.TabIndex = 7;
        _btnTabEnterNew.Text = "Enter New";
        _btnTabEnterNew.UseVisualStyleBackColor = false;
        // 
        // Panel1
        // 
        _Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        _Panel1.Controls.Add(_btnLocationAll);
        _Panel1.Controls.Add(_btnLocationStore);
        _Panel1.Controls.Add(_lblTabSearchLocation);
        _Panel1.Location = new System.Drawing.Point(176, 8);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(108, 96);
        _Panel1.TabIndex = 6;
        // 
        // btnLocationAll
        // 
        _btnLocationAll.Location = new System.Drawing.Point(56, 4);
        _btnLocationAll.Name = "_btnLocationAll";
        _btnLocationAll.Size = new System.Drawing.Size(48, 68);
        _btnLocationAll.TabIndex = 2;
        _btnLocationAll.Text = "All Stores";
        // 
        // btnLocationStore
        // 
        _btnLocationStore.BackColor = System.Drawing.Color.FromArgb(119, 154, 198);
        _btnLocationStore.Location = new System.Drawing.Point(4, 4);
        _btnLocationStore.Name = "_btnLocationStore";
        _btnLocationStore.Size = new System.Drawing.Size(48, 68);
        _btnLocationStore.TabIndex = 1;
        _btnLocationStore.Text = "This Store";
        _btnLocationStore.UseVisualStyleBackColor = false;
        // 
        // lblTabSearchLocation
        // 
        _lblTabSearchLocation.BackColor = System.Drawing.Color.FromArgb(119, 154, 198);
        _lblTabSearchLocation.Location = new System.Drawing.Point(0, 76);
        _lblTabSearchLocation.Name = "_lblTabSearchLocation";
        _lblTabSearchLocation.Size = new System.Drawing.Size(112, 20);
        _lblTabSearchLocation.TabIndex = 0;
        _lblTabSearchLocation.Text = "Location";
        _lblTabSearchLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Panel2
        // 
        _Panel2.BackColor = System.Drawing.Color.FromArgb(224, 241, 254);
        _Panel2.Location = new System.Drawing.Point(360, 4);
        _Panel2.Name = "_Panel2";
        _Panel2.Size = new System.Drawing.Size(232, 132);
        _Panel2.TabIndex = 8;
        // 
        // PreviousOrder_UC1
        // 
        _PreviousOrder_UC1.BackColor = System.Drawing.Color.FromArgb(0, 0, 100);
        _PreviousOrder_UC1.ExperienceNumber = 0;
        _PreviousOrder_UC1.Location = new System.Drawing.Point(4, 8);
        _PreviousOrder_UC1.Name = "_PreviousOrder_UC1";
        _PreviousOrder_UC1.Size = new System.Drawing.Size(356, 676);
        _PreviousOrder_UC1.TabIndex = 8;
        // 
        // lblMethodUse
        // 
        _lblMethodUse.BackColor = System.Drawing.SystemColors.Control;
        _lblMethodUse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblMethodUse.Location = new System.Drawing.Point(744, 10);
        _lblMethodUse.Name = "_lblMethodUse";
        _lblMethodUse.Size = new System.Drawing.Size(136, 26);
        _lblMethodUse.TabIndex = 9;
        _lblMethodUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Tab_Screen
        // 
        this.BackColor = System.Drawing.Color.FromArgb(119, 154, 198);
        this.Controls.Add(_lblMethodUse);
        this.Controls.Add(_PreviousOrder_UC1);
        this.Controls.Add(_Panel3);
        this.Name = "Tab_Screen";
        this.Size = new System.Drawing.Size(960, 688);
        _Panel4.ResumeLayout(false);
        _TabKeyboard.ResumeLayout(false);
        _pnlTabInfo.ResumeLayout(false);
        _pnlNewTabInfo.ResumeLayout(false);
        _Panel3.ResumeLayout(false);
        _TabControl1.ResumeLayout(false);
        _TabPageSearch.ResumeLayout(false);
        _pnlEdit.ResumeLayout(false);
        _Panel1.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion


    public void InitializeOther()
    {

        // currentSearchBy = StartInSearch '"Phone"
        // currentSearchLocation = "Location"
        // 222 isDisplaying = True

        // SearchPhone("BlankSearch", -123456789)

        // TestForCurrentTabInfo()
        // BindDataAfterSearch()

        pnlNewTabInfo.Location = new Point(4, 12);
        pnlTabInfo.Location = new Point(4, 12);
        // tempMethodUse = currentTable.MethodUse
        // ChangeLabelToCurrentMethod()

        // DetermineSearch(StartInSearch)

        // If typeProgram = "Online_Demo" Then
        // MsgBox("Actual program shows all previous order detail and save changes. Hit New Order button to save Customer detail.", MsgBoxStyle.Information, "DEMO Purposes only")
        // End If

    }

    public void DetermineSearch(string _startInSearch, string searchCriteria)
    {

        ResetButtonColors();

        // currently only doing by location
        SetLocationSearch();

        StartInSearch = _startInSearch;
        attemptedToEdit = false;
        enteringNewTab = false;

        if (StartInSearch == "Account")
        {
            SetAccountSearch();
            SearchAccount(searchCriteria);
        }
        else if (StartInSearch == "Phone")
        {
            SetPhoneSearch();
            SearchPhone(searchCriteria);
        }
        else if (StartInSearch == "TabID")
        {
            currentSearchBy = "TabID";
            SearchTabID(searchCriteria);
        }

        BindDataAfterSearch();

    }

    private void BindData()
    {

        CustomerCurrencyMan = this.BindingContext(dsCustomer.Tables("TabDirectorySearch"));

        lblTabLastName.DataBindings.Add("Text", dsCustomer.Tables("TabDirectorySearch"), "LastName");
        lblTabFirstName.DataBindings.Add("Text", dsCustomer.Tables("TabDirectorySearch"), "FirstName");
        lblTabAddress1.DataBindings.Add("Text", dsCustomer.Tables("TabDirectorySearch"), "Address1");
        lblTabAddress2.DataBindings.Add("Text", dsCustomer.Tables("TabDirectorySearch"), "Address2");
        lblTabCity.DataBindings.Add("Text", dsCustomer.Tables("TabDirectorySearch"), "City");
        lblTabState.DataBindings.Add("Text", dsCustomer.Tables("TabDirectorySearch"), "State");
        lblTabPostalCode.DataBindings.Add("Text", dsCustomer.Tables("TabDirectorySearch"), "PostalCode");

        lblTabPhone1.DataBindings.Add("Text", dsCustomer.Tables("TabDirectorySearch"), "Phone1");
        lblTabExt1.DataBindings.Add("Text", dsCustomer.Tables("TabDirectorySearch"), "Ext1");
        lblTabPhone2.DataBindings.Add("Text", dsCustomer.Tables("TabDirectorySearch"), "Phone2");
        lblTabExt2.DataBindings.Add("Text", dsCustomer.Tables("TabDirectorySearch"), "Ext2");
        lblTabEmail.DataBindings.Add("Text", dsCustomer.Tables("TabDirectorySearch"), "OpenChar1");

        lblTabAcctNumber.DataBindings.Add("Text", dsCustomer.Tables("TabDirectorySearch"), "AccountNumber");
        lblTabDeliveryZone.DataBindings.Add("Text", dsCustomer.Tables("TabDirectorySearch"), "DeliveryZone");
        lblTabCrossRoads.DataBindings.Add("Text", dsCustomer.Tables("TabDirectorySearch"), "CrossRoads");
        lblTabSpecial.DataBindings.Add("Text", dsCustomer.Tables("TabDirectorySearch"), "SpecialInstructions");

        chkTabVIP.DataBindings.Add("Checked", dsCustomer.Tables("TabDirectorySearch"), "VIP");
        chkTabDoNotDeliver.DataBindings.Add("Checked", dsCustomer.Tables("TabDirectorySearch"), "DoNotDeliver");

    }

    internal void TestForCurrentTabInfo()
    {

        if (currentTable.TabID > 0)
        {
            // this means experience already is associated with a tab
            _tempTabID = currentTable.TabID;
            SearchPhone("****----****----"); // , currentTable.TabID)
            FillPreviousOrders();
            // Me.btnTabEnterNew.Visible = True
            pnlEdit.Visible = true;
            TestForCompleteAddress();
            // need to provide a way to change tab info
            // Me.PreviousOrder_UC1.btnNewOrder.Text = "Change"
        }

    }

    private void TestForCompleteAddress()
    {

        if (dsCustomer.Tables("TabDirectorySearch").Rows.Count > 0)
        {
            if (dsCustomer.Tables("TabDirectorySearch").Rows(0)("Address1").ToString.Length > 0)
            {
                _hasAddress = true;
            }
        }
        else
        {

        }

    }

    private void TabKeyboard_Enter(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(currentSearchBy))
        {
            // this is we are entering new info
            if (enteringNewTab == true)
            {
                PlaceNewInfoIntoLabel();
            }
            else if (tabRow is not null)
            {
                PlaceEditedInfoIntoLabel();
            }
            return;
        }

        pnlEdit.Visible = true;

        switch (currentSearchLocation ?? "")
        {
            case "Location":
                {

                    switch (currentSearchBy ?? "")
                    {

                        case "Phone":
                            {
                                if (TabKeyboard.EnteredString.Length == 10)
                                {
                                    SearchPhone(TabKeyboard.EnteredString); // , -123456789)
                                }
                                else
                                {
                                    Interaction.MsgBox("Your Search Phone Number must be 10 digits.");
                                }

                                break;
                            }
                        case "Account":
                            {
                                SearchAccount(TabKeyboard.EnteredString); // , -123456789)
                                break;
                            }

                    }

                    break;
                }

        }

        BindDataAfterSearch();

    }

    internal void BindDataAfterSearch()
    {


        // BindData()
        dsCustomer.Tables("TabPreviousOrders").Rows.Clear();
        PreviousOrder_UC1.ClearPreviousOrders();

        if (dsCustomer.Tables("TabDirectorySearch").Rows.Count == 0)
        {
            // we enter new customer

            btnTabEnterNew.BackColor = Color.FromArgb(119, 154, 198);

            // Me.PreviousOrder_UC1.DisplayFirstOrder(dsCustomer.Tables("TabPreviousOrders"))
            StartEnteringNewTab();
        }

        else if (dsCustomer.Tables("TabDirectorySearch").Rows.Count == 1)
        {
            // customer info will bind automatically
            // we now need to bind any previous orders
            tabRow = dsCustomer.Tables("TabDirectorySearch").Rows(0);
            PopulateTabInfo(tabRow);
            FillPreviousOrders();
            pnlTabInfo.Visible = true;
            pnlNewTabInfo.Visible = false;
            TabKeyboard.ClearEnteredString();
        }

        else if (dsCustomer.Tables("TabDirectorySearch").Rows.Count > 1)
        {

            // ******************
            // this is WRONG
            // we need to list all accounts in the directory
            tabRow = dsCustomer.Tables("TabDirectorySearch").Rows(dsCustomer.Tables("TabDirectorySearch").Rows.Count - 1);
            PopulateTabInfo(tabRow);
            FillPreviousOrders();
            pnlTabInfo.Visible = true;
            pnlNewTabInfo.Visible = false;
            TabKeyboard.ClearEnteredString();

        }

        tempMethodUse = currentTable.MethodUse;
        ChangeLabelToCurrentMethod();
        // AddCardHandler()

    }

    private void PopulateTabInfo(DataRow drTab)
    {

        _tempTabID = drTab("TabID");

        try
        {
            _tempTabName = drTab("LastName");
        }
        catch (Exception ex)
        {
            _tempTabName = "Customer";
            return;
        }

        try
        {
            _tempTabName = _tempTabName + ", " + drTab("FirstName");
        }
        catch (Exception ex)
        {
        }

    }

    internal void SearchPhone(string searchCriteriaString) // , ByVal searchTabID As Int64)
    {

        // 444        If attemptedToEdit = True Then
        // attemptedToEdit = False
        // GenerateOrderTables.UpdateTabInfo(StartInSearch)
        // 444      Else
        // 444         RemoveFromEditMode()
        // End If

        GenerateOrderTables.PopulateSearchPhone(searchCriteriaString); // , searchTabID)

    }

    internal void SearchAccount(string searchCriteriaString) // , ByVal searchTabID As Int64)
    {

        // 444     If attemptedToEdit = True Then
        // attemptedToEdit = False
        // GenerateOrderTables.UpdateTabInfo(StartInSearch)
        // End If

        GenerateOrderTables.PopulateSearchAccount(searchCriteriaString); // , searchTabID)

    }

    internal void SearchTabID(string searchCriteriaString) // , ByVal searchTabID As Int64)
    {

        // 444       If attemptedToEdit = True Then
        // attemptedToEdit = False
        // GenerateOrderTables.UpdateTabInfo(StartInSearch)
        // End If

        GenerateOrderTables.PopulateSearchTabID(searchCriteriaString); // , searchTabID)

    }

    private void FillPreviousOrders()
    {

        dsCustomer.Tables("TabPreviousOrders").Rows.Clear();
        // dsCustomer.Tables("TabPreviousOrdersbyItem").Clear()

        if (typeProgram == "Online_Demo")
        {
            string filterString;
            filterString = "TabID = " + TempTabID;
            Demo_FilterDontDelete(dsCustomerDemo.Tables("TabPreviousOrders"), dsCustomer.Tables("TabPreviousOrders"), filterString);
            if (dsCustomer.Tables("TabPreviousOrders").Rows.Count > 0)
            {
                PreviousOrder_UC1.DisplayFirstOrder(dsCustomer.Tables("TabPreviousOrders")); // , dsCustomer.Tables("TabPreviousOrdersbyItem"))
                // If typeProgram = "Online_Demo" Then
                // MsgBox("non-DEMO would normally show all previous order detail. Hit New Order button to save Customer detail.", MsgBoxStyle.Information, "DEMO Purposes only")
                // End If

            }
            return;
        }

        sql.SqlSelectCommandTabPreviousOrdersLocation.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlSelectCommandTabPreviousOrdersLocation.Parameters("@TabID").Value = TempTabID;

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlTabPreviousOrdersLocation.Fill(dsCustomer.Tables("TabPreviousOrders"));
            // If dsCustomer.Tables("TabPreviousOrders").Rows.Count > 0 Then
            // sql.SqlSelectCommandTabPreviousOrdersByItem.Parameters("@ExperienceNumber").Value = dsCustomer.Tables("TabPreviousOrders").Rows(0)("ExperienceNumber")
            // sql.SqlTabPreviousOrdersByItem.Fill(dsCustomer.Tables("TabPreviousOrdersbyItem"))
            // End If
            // ccc       dsCustomer.WriteXml("CustomerData.xml", XmlWriteMode.WriteSchema)
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }

        if (dsCustomer.Tables("TabPreviousOrders").Rows.Count > 0)
        {
            PreviousOrder_UC1.DisplayFirstOrder(dsCustomer.Tables("TabPreviousOrders")); // , dsCustomer.Tables("TabPreviousOrdersbyItem"))
            // MsgBox(dsCustomer.Tables("TabPreviousOrders").Rows.Count)
        }

    }

    private void DifferentOrderSelected(ref DataTable dt)
    {
        // was ByRef .. dtTabPreviousOrdersByItem
        // we have to send to here through an event then resend datatable to user control
        // we do this so we can use the same sql connection but also have the previousOrder_UC avail for all projects

        // dsCustomer.Tables("TabPreviousOrdersbyItem").Clear()

        dt.Rows.Clear();

        if (typeProgram == "Online_Demo")
        {
            Interaction.MsgBox("Actual program shows all previous order detail and saves changes. Hit 'NEW ORDER' button to attach Customer detail.", MsgBoxStyle.Information, "DEMO Purposes only");
            // MsgBox("non-DEMO would normally show all previous order detail. Hit New Order button to save Customer detail.", MsgBoxStyle.Information, "DEMO Purposes only")
            // Dim filterString As String
            // filterString = "ExperienceNumber = " & PreviousOrder_UC1.ExperienceNumber
            // Demo_FilterDontDelete(dsCustomerDemo.Tables("TabPreviousOrdersByItem"), dt, filterString)
            // PreviousOrder_UC1.OrderBeingSentBackAfterPopulate(dsCustomer.Tables("TabPreviousOrders"), dt)
            return;
        }

        sql.SqlSelectCommandTabPreviousOrdersByItem.Parameters("@ExperienceNumber").Value = PreviousOrder_UC1.ExperienceNumber;

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlTabPreviousOrdersByItem.Fill(dt);
            // ccc     dsCustomer2.WriteXml("CustomerData2.xml", XmlWriteMode.WriteSchema)
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }

        PreviousOrder_UC1.OrderBeingSentBackAfterPopulate(dsCustomer.Tables("TabPreviousOrders"), dt);

    }

    private void ReorderButtonSelected(ref DataTable dtTabPreviousOrdersByItem2, bool tabTestNeeded)
    {

        if (enteringNewTab == true)
        {
            StartEnteringNewTab();
        }
        // 444    RemoveCardHandler()
        // 222 isDisplaying = False
        // dsCustomer.Tables("TabPreviousOrdersbyItem")
        // MsgBox(dtTabPreviousOrdersByItem.Rows.Count)
        // dtTabPreviousOrdersByItem = dtTabPreviousOrdersByItem2.Copy()
        // MsgBox(dtTabPreviousOrdersByItem.Rows.Count)
        SelectedReOrder?.Invoke(dtTabPreviousOrdersByItem2, true);
        this.Visible = false;
        // 444
        return;

        TabScreenDisposing?.Invoke();

    }


    private void NewOrderButtonSelected()
    {


        if (enteringNewTab == true)
        {
            StartEnteringNewTab();
        }

        // 444      RemoveCardHandler()
        // 222   isDisplaying = False
        SelectedNewOrder?.Invoke();
        TabScreenDisposing?.Invoke();
        // 444
        return;


    }

    private void btnCancel_Click(object sender, EventArgs e)
    {

        // Me.Visible = False
        // 444     RemoveCardHandler()
        TabScreenDisposing?.Invoke();

    }

    private void btnCloseSave_Click(object sender, EventArgs e)
    {

        // If Not currentTable.TabName = _tempTabName Then
        // enteringNewTab = True
        // End If

        if (attemptedToEdit == true) // or enteringNewTab = True 
        {
            VerifyTextBoxLengths();
        }
        // If enteringNewTab = True Then
        // VerifyTextBoxLengths()
        // StartEnteringNewTab()
        // End If
        if (attemptedToEdit == true & tabRow is not null) // typeProgram = "Online_Demo" Then
        {
            // if me._tempAccountPhone = 
            this.tabRow("UpdatedDate") = DateTime.Now;
            this.tabRow("UpdatedByEmployee") = currentTable.EmployeeID;
        }
        if (!(tempMethodUse == currentTable.MethodUse))
        {
            currentTable.MethodUse = tempMethodUse;
            DefineMethodDirection();
            GenerateOrderTables.UpdateMethodDataset();
            ChangedMethodUse?.Invoke();
        }

        if (attemptedToEdit == true)
        {
            GenerateOrderTables.UpdateTabInfo(StartInSearch);
            attemptedToEdit = false;
        }
        // Me.Visible = False
        // 444     RemoveCardHandler()
        TabScreenDisposing?.Invoke();
        SelectedNewOrder?.Invoke();

    }

    private void VerifyTextBoxLengths()
    {

        // 999
        // **************
        // we need to verify all text boxes
        // maybe both new and existing


        {
            ref var withBlock = ref currentTabInfo;

            if (lblNewTabState.Text.Length < 2)
            {
                withBlock.State = "";
            }
            else
            {
                withBlock.State = lblNewTabState.Text.Substring(0, 2).ToUpper;
            }  // Format(Me.lblNewTabState.Text, "##")
        }

    }
    private void StartEnteringNewTab()
    {

        if (enteringNewTab == true)
        {
            // already set up for entering, already created new datarow

            {
                ref var withBlock = ref currentTabInfo;
                // If Me.lblNewTabAcctNumber.Text.Length = 0 Then
                // .AccountNumber = Nothing
                // Else
                // End If

                withBlock.AccountNumber = lblNewTabAcctNumber.Text;    // _tempAccountNumber '
                withBlock.AccountPhone = _tempAccountPhone;
                withBlock.LastName = lblNewTabLastName.Text;
                withBlock.FirstName = lblNewTabFirstName.Text;
                withBlock.MiddleName = "";
                withBlock.NickName = "";
                withBlock.Address1 = lblNewTabAddress1.Text;
                withBlock.Address2 = lblNewTabAddress2.Text;
                withBlock.City = lblNewTabCity.Text;
                if (lblNewTabState.Text.Length < 2)
                {
                    withBlock.State = "";
                }
                else
                {
                    withBlock.State = lblNewTabState.Text.Substring(0, 2).ToUpper;
                }  // Format(Me.lblNewTabState.Text, "##")
                withBlock.PostalCode = lblNewTabPostalCode.Text;
                withBlock.Country = "USA";
                if (lblNewTabPhone1.Text == "Phone 1" | lblNewTabPhone1.Text.Length == 0)
                {
                    withBlock.Phone1 = (object)null;
                }
                else
                {
                    withBlock.Phone1 = lblNewTabPhone1.Text;
                }

                withBlock.Ext1 = lblNewTabExt1.Text;
                withBlock.Phone2 = lblNewTabPhone2.Text;
                withBlock.Ext2 = lblNewTabExt2.Text;
                withBlock.Email = lblNewTabEmail.Text;

                withBlock.DeliverZone = 0;  // ****** needs to be INT **** CInt(Me.lblNewTabDeliveryZone.Text)
                // ****** needs to be INT ****  right now entering only DBNULL.value
                // we will make delivery zone a drop down list
                // that will be in ds dataset (same as menu)
                withBlock.CrossRoads = lblNewTabCrossRoads.Text;
                withBlock.SpecialInstructions = lblNewTabSpecial.Text;
                withBlock.DoNotDeliver = chkTabDoNotDeliver.Checked;
                withBlock.VIP = chkTabVIP.Checked;
                withBlock.UpdatedDate = DateTime.Now;
                withBlock.UpdatedByEmployee = currentTable.EmployeeID;
                withBlock.Active = true;

                _tempTabID = GenerateOrderTables.CreateNewTabInfoData(currentTabInfo, StartInSearch);
                try
                {
                    _tempTabName = withBlock.LastName + ", " + withBlock.FirstName;
                }
                catch (Exception ex)
                {
                    _tempTabName = "Customer";
                    return;
                }

            }
        }


        else
        {
            currentTabInfo = new TabInfo();

            enteringNewTab = true;
            // Me.btnTabEnterNew.Text = "Accept New"
            // Me.pnlEdit.Visible = True
            // Me.btnTabEnterNew.Visible = True
            // Me.btnTabEnterNew.BackColor = Color.FromArgb(119, 154, 198)

            pnlTabInfo.Visible = false;
            pnlNewTabInfo.Visible = true;
            // Me.pnlNewTabInfo.BringToFront()

            switch (currentSearchBy ?? "")
            {
                case "Phone":
                    {
                        _tempAccountPhone = TabKeyboard.EnteredString;
                        if (TabKeyboard.EnteredString.Length == 10)
                        {
                            lblNewTabPhone1.Text = ConvertToPhoneString(TabKeyboard.EnteredString);
                        }
                        else if (TabKeyboard.EnteredString.Length > 0)
                        {
                            Interaction.MsgBox("Phone Number Must be 10 Digits.");
                            // Me.lblNewTabPhone1.Text = Me.TabKeyboard.EnteredString
                        }

                        break;
                    }
                case "Account":
                    {
                        lblNewTabPhone1.Text = _tempAccountNumber;
                        break;
                    }
            }

            PlaceInEditMode();

            activeLabelString = "lblNewTabLastName";
            activeLabel = lblNewTabLastName;
            TabKeyboard.ClearEnteredString();

        }
    }

    private object ConvertToPhoneString(string phone)
    {
        string phoneString;

        try
        {
            phoneString = "(" + phone.Substring(0, 3) + ") " + phone.Substring(3, 3) + "-" + phone.Substring(6, 4);
        }
        catch (Exception ex)
        {
            phoneString = phone;
        }

        return phoneString;

    }

    // Private Sub TabLabels_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTabAcctNumber.DoubleClick, lblTabAddress1.DoubleClick, lblTabAddress2.DoubleClick, lblTabCity.DoubleClick, lblTabCrossRoads.DoubleClick, lblTabDeliveryZone.DoubleClick, lblTabExt1.DoubleClick, lblTabExt2.DoubleClick, lblTabFirstName.DoubleClick, lblTabLastName.DoubleClick, lblTabPhone1.DoubleClick, lblTabPhone2.DoubleClick, lblTabPostalCode.DoubleClick, lblTabSpecial.DoubleClick, lblTabState.DoubleClick

    // If Not tabRow Is Nothing Then
    // PlaceEditedInfoIntoLabel()
    // End If
    // activeLabel = sender
    // GotoLabelSelected()
    // '     Me.TabKeyboard.ClearEnteredString()
    // Me.TabKeyboard.PopulateEnteredString(activeLabel.Text)
    // 
    // End Sub

    private void TabLabels_Click(object sender, EventArgs e)
    {

        if (tabTimerActive == false)
        {
            tabDoubleClickTimer = new DateAndTime.Timer();
            tabTimerActive = true;
            this.tabDoubleClickTimer.Tick += TabTimerExpired;
            tabDoubleClickTimer.Interval = 500;
            tabDoubleClickTimer.Start();

            if (tabRow is not null)
            {
                PlaceEditedInfoIntoLabel();
            }
            activeLabel = sender;
            GotoLabelSelected();
            TabKeyboard.ClearEnteredString();
            if (object.ReferenceEquals(sender, lblTabEmail))
            {
                TabKeyboard.IsCapital = false;
            }
        }

        else
        {
            // this means we just DOUBLE clicked
            tabTimerActive = false;
            tabDoubleClickTimer.Dispose();
            TabKeyboard.PopulateEnteredString(activeLabel.Text);
        }

    }

    private void TabTimerExpired(object sender, EventArgs e)
    {
        tabTimerActive = false;
        tabDoubleClickTimer.Dispose();
        // **** this means we clicked
    }


    private void GotoLabelSelected()
    {

        if (activeLabel is not null)
        {
            activeLabelString = activeLabel.Name.ToString;
            ResetLabelBackcolors(Color.FromArgb(224, 241, 254));
            activeLabel.BackColor = Color.White;
        }

    }

    private void PlaceEditedInfoIntoLabel()
    {

        attemptedToEdit = true;

        switch (activeLabelString ?? "")
        {
            case "lblTabLastName":
                {
                    this.tabRow("LastName") = TabKeyboard.EnteredString;
                    activeLabel = lblTabFirstName;
                    break;
                }

            case "lblTabFirstName":
                {
                    this.tabRow("FirstName") = TabKeyboard.EnteredString;
                    // Me.lblTabFirstName.Text = Me.TabKeyboard.EnteredString
                    activeLabel = lblTabAddress1;
                    break;
                }

            case "lblTabAddress1":
                {
                    this.tabRow("Address1") = TabKeyboard.EnteredString;
                    activeLabel = lblTabAddress2;
                    break;
                }

            case "lblTabAddress2":
                {
                    this.tabRow("Address2") = TabKeyboard.EnteredString;
                    activeLabel = lblTabCity;
                    break;
                }

            case "lblTabCity":
                {
                    this.tabRow("City") = TabKeyboard.EnteredString;
                    activeLabel = lblTabState;
                    break;
                }

            case "lblTabState":
                {
                    if (TabKeyboard.EnteredString.Length < 2)
                    {
                        this.tabRow("State") = "";
                    }
                    else
                    {
                        this.tabRow("State") = TabKeyboard.EnteredString.Substring(0, 2).ToUpper;
                    }
                    activeLabel = lblTabPostalCode;
                    break;
                }

            case "lblTabPostalCode":
                {
                    this.tabRow("PostalCode") = TabKeyboard.EnteredString;
                    activeLabel = lblTabPhone1;
                    break;
                }

            case "lblTabPhone1":
                {

                    if (TabKeyboard.EnteredString.Length == 10)
                    {
                        // _tempAccountPhone = TabKeyboard.EnteredString
                        this.tabRow("AccountPhone") = TabKeyboard.EnteredString;
                        this.tabRow("Phone1") = ConvertToPhoneString(TabKeyboard.EnteredString);
                        activeLabel = lblNewTabExt1;
                    }
                    else
                    {
                        Interaction.MsgBox("Phone Number Must be 10 Digits");
                    }

                    break;
                }

            // tabRow("Phone1") = Me.TabKeyboard.EnteredString
            // activeLabel = Me.lblTabExt1

            case "lblTabExt1":
                {
                    this.tabRow("Ext1") = TabKeyboard.EnteredString;
                    activeLabel = lblTabPhone2;
                    break;
                }

            case "lblTabPhone2":
                {
                    if (TabKeyboard.EnteredString.Length == 10)
                    {
                        this.tabRow("Phone2") = ConvertToPhoneString(TabKeyboard.EnteredString);
                        activeLabel = lblTabExt2;
                    }
                    else if (Interaction.MsgBox("Phone Number is not 10 Digits", MsgBoxStyle.OkCancel) == MsgBoxResult.Ok)
                    {
                        this.tabRow("Phone2") = TabKeyboard.EnteredString;
                        activeLabel = lblTabExt2;
                    }

                    break;
                }


            case "lblTabExt2":
                {
                    this.tabRow("Ext2") = TabKeyboard.EnteredString;
                    activeLabel = lblTabEmail;
                    break;
                }

            // Case "lblTabAcctNumber"
            // Me.lblTabAcctNumber.Text = Me.TabKeyboard.EnteredString
            // activeLabel = Me.lblTabAddress2


            case "lblTabEmail":
                {
                    this.tabRow("OpenChar1") = TabKeyboard.EnteredString;
                    activeLabel = lblTabDeliveryZone;
                    break;
                }

            case "lblTabDeliveryZone":
                {
                    this.tabRow("DeliveryZone") = 0; // Me.TabKeyboard.EnteredString
                    activeLabel = lblTabCrossRoads;
                    break;
                }

            case "lblTabCrossRoads":
                {
                    this.tabRow("CrossRoads") = TabKeyboard.EnteredString;
                    activeLabel = lblTabSpecial;
                    break;
                }

            case "lblTabSpecial":
                {
                    this.tabRow("SpecialInstructions") = TabKeyboard.EnteredString;
                    activeLabel = lblTabLastName;
                    break;
                }

        }

        if (activeLabel is not null)
        {
            GotoLabelSelected();
            TabKeyboard.PopulateEnteredString(activeLabel.Text.ToString);
            if (activeLabel.Text.Length == 0)
            {
                TabKeyboard.MakeNextCap();
            }
        }

    }

    // ****************************
    // this is when adding new tabs

    private void NewTabLabels_Click(object sender, EventArgs e)
    {

        if (enteringNewTab == true)
        {
            PlaceNewInfoIntoLabel();
        }

        activeLabel = sender;
        activeLabelString = activeLabel.Name.ToString;
        TabKeyboard.PopulateEnteredString(activeLabel.Text.ToString);
        if (object.ReferenceEquals(sender, lblNewTabEmail))
        {
            TabKeyboard.IsCapital = false;
        }
        else
        {
            TabKeyboard.MakeNextCap();
        }

    }

    private void PlaceNewInfoIntoLabel()
    {

        switch (activeLabelString ?? "")
        {
            case "lblNewTabLastName":
                {
                    lblNewTabLastName.Text = TabKeyboard.EnteredString;
                    activeLabel = lblNewTabFirstName;
                    break;
                }

            case "lblNewTabFirstName":
                {
                    lblNewTabFirstName.Text = TabKeyboard.EnteredString;
                    activeLabel = lblNewTabAddress1;
                    break;
                }

            case "lblNewTabAddress1":
                {
                    lblNewTabAddress1.Text = TabKeyboard.EnteredString;
                    activeLabel = lblNewTabAddress2;
                    break;
                }

            case "lblNewTabAddress2":
                {
                    lblNewTabAddress2.Text = TabKeyboard.EnteredString;
                    activeLabel = lblNewTabCity;
                    break;
                }

            case "lblNewTabCity":
                {
                    lblNewTabCity.Text = TabKeyboard.EnteredString;
                    activeLabel = lblNewTabState;
                    break;
                }

            case "lblNewTabState":
                {
                    if (TabKeyboard.EnteredString.Length < 2)
                    {
                        lblNewTabState.Text = "";
                    }
                    else
                    {
                        lblNewTabState.Text = TabKeyboard.EnteredString.Substring(0, 2).ToUpper;
                    }
                    activeLabel = lblNewTabPostalCode;
                    break;
                }

            case "lblNewTabPostalCode":
                {
                    lblNewTabPostalCode.Text = TabKeyboard.EnteredString;
                    activeLabel = lblNewTabPhone1;
                    break;
                }

            case "lblNewTabPhone1":
                {
                    if (TabKeyboard.EnteredString.Length == 10)
                    {
                        _tempAccountPhone = TabKeyboard.EnteredString;
                        lblNewTabPhone1.Text = ConvertToPhoneString(TabKeyboard.EnteredString);
                        activeLabel = lblNewTabExt1;
                    }
                    else
                    {
                        Interaction.MsgBox("Phone Number Must be 10 Digits");
                    }

                    break;
                }

            case "lblNewTabExt1":
                {
                    lblNewTabExt1.Text = TabKeyboard.EnteredString;
                    activeLabel = lblNewTabPhone2;
                    break;
                }

            case "lblNewTabPhone2":
                {
                    lblNewTabPhone2.Text = TabKeyboard.EnteredString;
                    activeLabel = lblNewTabExt2;
                    break;
                }

            case "lblNewTabExt2":
                {
                    lblNewTabExt2.Text = TabKeyboard.EnteredString;
                    activeLabel = lblNewTabEmail;
                    break;
                }

            // Case "lblNewTabAcctNumber"
            // Me.lblNewTabAcctNumber.Text = Me.TabKeyboard.EnteredString
            // activeLabel = Me.lblNewTabEmail

            case "lblNewTabEmail":
                {
                    lblNewTabEmail.Text = TabKeyboard.EnteredString;
                    activeLabel = lblNewTabDeliveryZone;
                    break;
                }

            case "lblNewTabDeliveryZone":
                {
                    lblNewTabDeliveryZone.Text = 0; // Me.TabKeyboard.EnteredString
                    activeLabel = lblNewTabCrossRoads;
                    break;
                }

            case "lblNewTabCrossRoads":
                {
                    lblNewTabCrossRoads.Text = TabKeyboard.EnteredString;
                    activeLabel = lblNewTabSpecial;
                    break;
                }

            case "lblNewTabSpecial":
                {
                    lblNewTabSpecial.Text = TabKeyboard.EnteredString;
                    activeLabel = lblNewTabLastName;
                    break;
                }

        }


        if (activeLabel is not null)
        {
            activeLabelString = activeLabel.Name.ToString;
            TabKeyboard.PopulateEnteredString(activeLabel.Text.ToString);
            if (activeLabel.Text.Length == 0)
            {
                TabKeyboard.MakeNextCap();
            }
        }

    }

    private void btnTabEnterNew_Click(object sender, EventArgs e)
    {

        // at some point we need to be able to add by swiping card
        // 444      RemoveCardHandler()

        if (attemptedToEdit == true)
        {
            attemptedToEdit = false;
            GenerateOrderTables.UpdateTabInfo(StartInSearch);
        }
        btnEditEntry.BackColor = Color.FromArgb(224, 241, 254);
        btnTabEnterNew.BackColor = Color.FromArgb(119, 154, 198);
        StartEnteringNewTab();
        enteringNewTab = true; // this must be after we created datarow

    }

    private void btnEditEntry_Click(object sender, EventArgs e)
    {

        PlaceInEditMode();

    }

    private void PlaceInEditMode()
    {

        // 444     RemoveCardHandler()

        switch (currentSearchBy ?? "")
        {
            case "Phone":
                {
                    btnSearchPhone.BackColor = Color.FromArgb(224, 241, 254);
                    break;
                }
            case "Account":
                {
                    btnSearchAcctNum.BackColor = Color.FromArgb(224, 241, 254);
                    break;
                }
        }

        // Select Case currentSearchLocation
        // Case "Location"
        // Me.btnLocationStore.BackColor = Color.FromArgb(224, 241, 254)
        // End Select

        btnEditEntry.BackColor = Color.FromArgb(119, 154, 198);
        btnTabEnterNew.BackColor = Color.FromArgb(224, 241, 254);

        // currentSearchLocation = Nothing
        currentSearchBy = null;
        pnlNewTabInfo.Visible = false;
        pnlTabInfo.Visible = true;
        enteringNewTab = false;
        attemptedToEdit = true;

    }

    private void RemoveFromEditMode()
    {

        if (attemptedToEdit == true)
        {
            attemptedToEdit = false;
            GenerateOrderTables.UpdateTabInfo(StartInSearch);
        }

        activeLabelString = null;
        TabKeyboard.ClearEnteredString();
        pnlNewTabInfo.Visible = false;
        pnlTabInfo.Visible = true;
        attemptedToEdit = false;
        enteringNewTab = false;
        btnEditEntry.BackColor = Color.FromArgb(224, 241, 254);
        btnTabEnterNew.BackColor = Color.FromArgb(224, 241, 254);

    }

    private void btnSearchPhone_Click(object sender, EventArgs e)
    {

        RemoveFromEditMode();
        SetPhoneSearch();

    }

    private void btnSearchLastName_Click(object sender, EventArgs e)
    {

    }

    private void btnSearchAcctNum_Click(object sender, EventArgs e)
    {

        RemoveFromEditMode();
        SetAccountSearch();

    }

    private void SetLocationSearch()
    {

        currentSearchLocation = "Location";
        btnLocationStore.BackColor = Color.FromArgb(119, 154, 198);
        btnLocationAll.BackColor = Color.FromArgb(224, 241, 254);

    }
    private void SetPhoneSearch()
    {

        // 444    RemoveCardHandler()

        currentSearchBy = "Phone";
        btnSearchPhone.BackColor = Color.FromArgb(119, 154, 198);
        btnSearchLastName.BackColor = Color.FromArgb(224, 241, 254);
        btnSearchAcctNum.BackColor = Color.FromArgb(224, 241, 254);

    }

    private void SetAccountSearch()
    {

        // 444     AddCardHandler()

        currentSearchBy = "Account";
        btnSearchPhone.BackColor = Color.FromArgb(224, 241, 254);
        btnSearchLastName.BackColor = Color.FromArgb(224, 241, 254);
        btnSearchAcctNum.BackColor = Color.FromArgb(119, 154, 198);

    }

    private void btnLocationStore_Click(object sender, EventArgs e)
    {

        SetLocationSearch();

    }

    private void ResetButtonColors()
    {

        btnSearchPhone.BackColor = Color.FromArgb(224, 241, 254);
        btnSearchLastName.BackColor = Color.FromArgb(224, 241, 254);
        btnSearchAcctNum.BackColor = Color.FromArgb(224, 241, 254);

        btnLocationStore.BackColor = Color.FromArgb(224, 241, 254);
        btnLocationAll.BackColor = Color.FromArgb(224, 241, 254);

        btnEditEntry.BackColor = Color.FromArgb(224, 241, 254);
        btnTabEnterNew.BackColor = Color.FromArgb(224, 241, 254);

    }

    private void ResetLabelBackcolors(Color bc)
    {

        lblTabAcctNumber.BackColor = bc;
        lblTabAddress1.BackColor = bc;
        lblTabAddress2.BackColor = bc;
        lblTabCity.BackColor = bc;
        lblTabCrossRoads.BackColor = bc;
        lblTabDeliveryZone.BackColor = bc;
        lblTabExt1.BackColor = bc;
        lblTabExt2.BackColor = bc;
        lblTabFirstName.BackColor = bc;
        lblTabLastName.BackColor = bc;    // Color.FromArgb(224, 241, 254)
        lblTabPhone1.BackColor = bc;
        lblTabPhone2.BackColor = bc;
        lblTabEmail.BackColor = bc;
        lblTabPostalCode.BackColor = bc;
        lblTabSpecial.BackColor = bc;
        lblTabState.BackColor = bc;



    }

    private void CustomerCardRead(ref DataSet_Builder.Payment newpayment)
    {

        // *** not sure if this is correct,not sure about
        // the AddPayment Collection in Read Credit ????
        // 444      GenerateOrderTables.CreateTabAcctPlaceInExperience(newpayment)
        _tempAccountNumber = newpayment.SpiderAcct;
        // might need to  SetAccountSearch() , currently we are doing before swipe activate

        if (attemptedToEdit == true)
        {
            attemptedToEdit = false;
            GenerateOrderTables.UpdateTabInfo(StartInSearch);
        }
        GenerateOrderTables.PopulateSearchAccount(newpayment.SpiderAcct); // , -123456789)
        BindDataAfterSearch();

        return; // 444

        newpayment.SpiderAcct = CreateAccountNumber(newpayment); // .LastName, newpayment.AccountNumber)
        _tempAccountNumber = newpayment.SpiderAcct;
        // AddPaymentToCollection(newpayment)
        // tempPayment = newpayment    'this way we can populate exp if saving 
        GenerateOrderTables.CreateTabAcctPlaceInExperience(newpayment);
        SearchAccount(newpayment.SpiderAcct); // , -123456789)
        BindDataAfterSearch();

    }

    private void AddCardHandler222()
    {
        return;
        readAuthTab222 = new ReadCredit(false);
        tmrCardRead.Start();
        tmrCardRead.Tick += readAuthTab222.tmrCardRead_Tick;

    }
    private void RemoveCardHandler222()
    {
        return;
        if (readAuthTab222 is not null)
        {
            tmrCardRead.Stop();
            tmrCardRead.Tick -= readAuthTab222.tmrCardRead_Tick;
            readAuthTab222.Shutdown();
            readAuthTab222 = default;
        }

    }

    private void lblMethodUse_Click(object sender, EventArgs e)
    {

        if (tempMethodUse == "Delivery")
        {
            tempMethodUse = "Take Out";
        }
        else
        {
            tempMethodUse = "Take Out";
            tempMethodUse = "Delivery";
        }

        ChangeLabelToCurrentMethod();
        // GenerateOrderTables.UpdateMethodDataset()

    }

    private void ChangeLabelToCurrentMethod()
    {

        lblMethodUse.Text = tempMethodUse;

    }

}