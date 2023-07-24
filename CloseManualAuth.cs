using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

// Imports VB = Microsoft.VisualBasic
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;



public partial class CloseManualAuth : System.Windows.Forms.UserControl
{

    private DSICLIENTXLib.DSICLientX dsi = new DSICLIENTXLib.DSICLientX();

    // Dim dddi As New DSICLIENTXLib.DSICLientXClass
    private TStream auth = new TStream();


    // HID device
    private const short MyVendorID = 801;
    private const short MyProductID = 2;
    internal bool myDeviceDetected;
    internal string myDevicePathName;
    // Friend myDevice As IDataReader
    internal int ReadHandle;
    private int EventObject;


    private HIDD_ATTRIBUTES deviceAttributes;
    private string devicePathName;
    private IntPtr deviceInfoSet;
    private SP_DEVICE_INTERFACE_DATA myDeviceInterfaceData;
    private SP_DEVICE_INTERFACE_DETAIL_DATA myDeviceInterfaceDetailData;
    private int HIDHandle;
    private string vbNullString = null;

    private bool lastDevice = false;
    private int result;
    private bool bResult;
    private int MemberIndex;
    private int m_lBufferSize;
    private SECURITY_ATTRIBUTES security;
    private Guid HidGuid;
    private HIDP_CAPS Capabilities;
    private OVERLAPPED HIDOverlapped;
    private IntPtr PreparsedData;

    public const short HidP_Input = 0;


    private bool activeAccountNo;
    private bool activeExpDate;
    private bool activeAmount;
    private bool activeTip;

    private bool authTest;

    private int testCounter;

    private DataSet_Builder.Information_UC info;
    private bool cardSwiped;

    private static PreAuthAmountClass _closeAuthAmount;
    private static PreAuthTransactionClass _closeAuthTransaction;
    private static AccountClass _closeAuthAccount;


    internal static PreAuthAmountClass CloseAuthAmount
    {
        get
        {
            return _closeAuthAmount;
        }
        set
        {
            _closeAuthAmount = value;
        }
    }

    internal static PreAuthTransactionClass CloseAuthTransaction
    {
        get
        {
            return _closeAuthTransaction;
        }
        set
        {
            _closeAuthTransaction = value;
        }
    }

    internal static AccountClass CloseAuthAccount
    {
        get
        {
            return _closeAuthAccount;
        }
        set
        {
            _closeAuthAccount = value;
        }
    }



    private DataSet_Builder.KeyBoard_UC _paymentKeyboard;

    internal virtual DataSet_Builder.KeyBoard_UC paymentKeyboard
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _paymentKeyboard;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_paymentKeyboard != null)
            {
                _paymentKeyboard.StringEntered -= NameEntered;
            }

            _paymentKeyboard = value;
            if (_paymentKeyboard != null)
            {
                _paymentKeyboard.StringEntered += NameEntered;
            }
        }
    }




    #region  Windows Form Designer generated code 

    public CloseManualAuth(ref PreAuthAmountClass authamount, ref PreAuthTransactionClass authTransaction, bool cardSwipedDatabaseInfo) : base()
    {

        _closeAuthAmount = new PreAuthAmountClass();
        _closeAuthTransaction = new PreAuthTransactionClass();
        _closeAuthAccount = new AccountClass();

        _closeAuthAmount = authamount;
        _closeAuthTransaction = authTransaction;
        cardSwiped = cardSwipedDatabaseInfo;

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        InitializeOther();
        base.Load += CloseManualAuth_Load;



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
    private Global.System.Windows.Forms.Label _lblCLoseManual;

    internal virtual Global.System.Windows.Forms.Label lblCLoseManual
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCLoseManual;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblCLoseManual = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblManualAcctNumberDetail;

    internal virtual Global.System.Windows.Forms.Label lblManualAcctNumberDetail
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblManualAcctNumberDetail;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblManualAcctNumberDetail != null)
            {
                _lblManualAcctNumberDetail.Click -= lblManualAcctNumberDetail_Click;
            }

            _lblManualAcctNumberDetail = value;
            if (_lblManualAcctNumberDetail != null)
            {
                _lblManualAcctNumberDetail.Click += lblManualAcctNumberDetail_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblManualExpDateDetail;

    internal virtual Global.System.Windows.Forms.Label lblManualExpDateDetail
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblManualExpDateDetail;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblManualExpDateDetail != null)
            {
                _lblManualExpDateDetail.Click -= lblManualExpDateDetail_Click;
            }

            _lblManualExpDateDetail = value;
            if (_lblManualExpDateDetail != null)
            {
                _lblManualExpDateDetail.Click += lblManualExpDateDetail_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblManualAmount;

    internal virtual Global.System.Windows.Forms.Label lblManualAmount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblManualAmount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblManualAmount = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblManualTip;

    internal virtual Global.System.Windows.Forms.Label lblManualTip
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblManualTip;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblManualTip != null)
            {
                _lblManualTip.Click -= lblManualTip_Click;
            }

            _lblManualTip = value;
            if (_lblManualTip != null)
            {
                _lblManualTip.Click += lblManualTip_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblManualAmountDetail;

    internal virtual Global.System.Windows.Forms.Label lblManualAmountDetail
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblManualAmountDetail;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblManualAmountDetail = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblManualTipDetail;

    internal virtual Global.System.Windows.Forms.Label lblManualTipDetail
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblManualTipDetail;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblManualTipDetail != null)
            {
                _lblManualTipDetail.Click -= lblManualTipDetail_Click;
            }

            _lblManualTipDetail = value;
            if (_lblManualTipDetail != null)
            {
                _lblManualTipDetail.Click += lblManualTipDetail_Click;
            }
        }
    }
    private Global.System.Windows.Forms.CheckBox _chkCloseOverrideDup;

    internal virtual Global.System.Windows.Forms.CheckBox chkCloseOverrideDup
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _chkCloseOverrideDup;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _chkCloseOverrideDup = value;
        }
    }
    private DataSet_Builder.NumberPadLarge _NumberPadCreditAuth;

    internal virtual DataSet_Builder.NumberPadLarge NumberPadCreditAuth
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _NumberPadCreditAuth;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_NumberPadCreditAuth != null)
            {
                _NumberPadCreditAuth.NumberEntered -= PaymentInfoEntered;
            }

            _NumberPadCreditAuth = value;
            if (_NumberPadCreditAuth != null)
            {
                _NumberPadCreditAuth.NumberEntered += PaymentInfoEntered;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblManualExpDate;

    internal virtual Global.System.Windows.Forms.Label lblManualExpDate
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblManualExpDate;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblManualExpDate != null)
            {
                _lblManualExpDate.Click -= lblManualExpDate_Click;
            }

            _lblManualExpDate = value;
            if (_lblManualExpDate != null)
            {
                _lblManualExpDate.Click += lblManualExpDate_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblManualAccount;

    internal virtual Global.System.Windows.Forms.Label lblManualAccount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblManualAccount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblManualAccount != null)
            {
                _lblManualAccount.Click -= lblManualAccount_Click;
            }

            _lblManualAccount = value;
            if (_lblManualAccount != null)
            {
                _lblManualAccount.Click += lblManualAccount_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblManualCheck;

    internal virtual Global.System.Windows.Forms.Label lblManualCheck
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblManualCheck;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblManualCheck = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblanualName;

    internal virtual Global.System.Windows.Forms.Label lblanualName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblanualName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblanualName != null)
            {
                _lblanualName.Click -= lblanualName_Click;
            }

            _lblanualName = value;
            if (_lblanualName != null)
            {
                _lblanualName.Click += lblanualName_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblManualNameOnCardDetail;

    internal virtual Global.System.Windows.Forms.Label lblManualNameOnCardDetail
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblManualNameOnCardDetail;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblManualNameOnCardDetail != null)
            {
                _lblManualNameOnCardDetail.Click -= lblManualNameOnCardDetail_Click;
            }

            _lblManualNameOnCardDetail = value;
            if (_lblManualNameOnCardDetail != null)
            {
                _lblManualNameOnCardDetail.Click += lblManualNameOnCardDetail_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblManualAuthCode;

    internal virtual Global.System.Windows.Forms.Label lblManualAuthCode
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblManualAuthCode;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblManualAuthCode = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblDeclineReason;

    internal virtual Global.System.Windows.Forms.Label lblDeclineReason
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblDeclineReason;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblDeclineReason = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblManualAuthCodeDetail;

    internal virtual Global.System.Windows.Forms.Label lblManualAuthCodeDetail
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblManualAuthCodeDetail;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblManualAuthCodeDetail = value;
        }
    }
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
    private Global.System.Windows.Forms.Button _btnAuth;

    internal virtual Global.System.Windows.Forms.Button btnAuth
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnAuth;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _btnAuth = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnPreAuth;

    internal virtual Global.System.Windows.Forms.Button btnPreAuth
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnPreAuth;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnPreAuth != null)
            {
                _btnPreAuth.Click -= btnPreAuth_Click;
            }

            _btnPreAuth = value;
            if (_btnPreAuth != null)
            {
                _btnPreAuth.Click += btnPreAuth_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Timer _tmrCardRead;

    internal virtual Global.System.Windows.Forms.Timer tmrCardRead
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tmrCardRead;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tmrCardRead != null)
            {
                _tmrCardRead.Tick -= tmrCardRead_Tick;
            }

            _tmrCardRead = value;
            if (_tmrCardRead != null)
            {
                _tmrCardRead.Tick += tmrCardRead_Tick;
            }
        }
    }
    private Global.System.Windows.Forms.ListView _ListView1;

    internal virtual Global.System.Windows.Forms.ListView ListView1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ListView1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _ListView1 = value;
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _ColumnHeader1;

    internal virtual Global.System.Windows.Forms.ColumnHeader ColumnHeader1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ColumnHeader1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _ColumnHeader1 = value;
        }
    }
    internal AxDSICLIENTXLib.AxDSICLientX AxDSICLientX1;
    private AxDSICLIENTXLib.AxDSICLientX _AxDSICLientX2;

    internal virtual AxDSICLIENTXLib.AxDSICLientX AxDSICLientX2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _AxDSICLientX2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _AxDSICLientX2 = value;
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        var resources = new System.Resources.ResourceManager(typeof(CloseManualAuth));
        _Panel1 = new System.Windows.Forms.Panel();
        _ListView1 = new System.Windows.Forms.ListView();
        _ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
        _lblManualAuthCodeDetail = new System.Windows.Forms.Label();
        _lblDeclineReason = new System.Windows.Forms.Label();
        _lblManualAuthCode = new System.Windows.Forms.Label();
        _lblManualNameOnCardDetail = new System.Windows.Forms.Label();
        _lblManualNameOnCardDetail.Click += lblManualNameOnCardDetail_Click;
        _lblanualName = new System.Windows.Forms.Label();
        _lblanualName.Click += lblanualName_Click;
        _lblManualCheck = new System.Windows.Forms.Label();
        _NumberPadCreditAuth = new DataSet_Builder.NumberPadLarge();
        _NumberPadCreditAuth.NumberEntered += PaymentInfoEntered;
        _chkCloseOverrideDup = new System.Windows.Forms.CheckBox();
        _lblManualTipDetail = new System.Windows.Forms.Label();
        _lblManualTipDetail.Click += lblManualTipDetail_Click;
        _lblManualAmountDetail = new System.Windows.Forms.Label();
        _lblManualTip = new System.Windows.Forms.Label();
        _lblManualTip.Click += lblManualTip_Click;
        _lblManualAmount = new System.Windows.Forms.Label();
        _lblManualExpDateDetail = new System.Windows.Forms.Label();
        _lblManualExpDateDetail.Click += lblManualExpDateDetail_Click;
        _lblManualAcctNumberDetail = new System.Windows.Forms.Label();
        _lblManualAcctNumberDetail.Click += lblManualAcctNumberDetail_Click;
        _btnCancel = new System.Windows.Forms.Button();
        _btnCancel.Click += btnCancel_Click;
        _btnAuth = new System.Windows.Forms.Button();
        _btnPreAuth = new System.Windows.Forms.Button();
        _btnPreAuth.Click += btnPreAuth_Click;
        _lblManualExpDate = new System.Windows.Forms.Label();
        _lblManualExpDate.Click += lblManualExpDate_Click;
        _lblManualAccount = new System.Windows.Forms.Label();
        _lblManualAccount.Click += lblManualAccount_Click;
        _lblCLoseManual = new System.Windows.Forms.Label();
        _AxDSICLientX2 = new AxDSICLIENTXLib.AxDSICLientX();
        _tmrCardRead = new System.Windows.Forms.Timer(components);
        _tmrCardRead.Tick += tmrCardRead_Tick;
        _Panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_AxDSICLientX2).BeginInit();
        this.SuspendLayout();
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.Color.LightSlateGray;
        _Panel1.Controls.Add(_ListView1);
        _Panel1.Controls.Add(_lblManualAuthCodeDetail);
        _Panel1.Controls.Add(_lblDeclineReason);
        _Panel1.Controls.Add(_lblManualAuthCode);
        _Panel1.Controls.Add(_lblManualNameOnCardDetail);
        _Panel1.Controls.Add(_lblanualName);
        _Panel1.Controls.Add(_lblManualCheck);
        _Panel1.Controls.Add(_NumberPadCreditAuth);
        _Panel1.Controls.Add(_chkCloseOverrideDup);
        _Panel1.Controls.Add(_lblManualTipDetail);
        _Panel1.Controls.Add(_lblManualAmountDetail);
        _Panel1.Controls.Add(_lblManualTip);
        _Panel1.Controls.Add(_lblManualAmount);
        _Panel1.Controls.Add(_lblManualExpDateDetail);
        _Panel1.Controls.Add(_lblManualAcctNumberDetail);
        _Panel1.Controls.Add(_btnCancel);
        _Panel1.Controls.Add(_btnAuth);
        _Panel1.Controls.Add(_btnPreAuth);
        _Panel1.Controls.Add(_lblManualExpDate);
        _Panel1.Controls.Add(_lblManualAccount);
        _Panel1.Controls.Add(_lblCLoseManual);
        _Panel1.Controls.Add(_AxDSICLientX2);
        _Panel1.Location = new System.Drawing.Point(40, 24);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(608, 400);
        _Panel1.TabIndex = 0;
        // 
        // ListView1
        // 
        _ListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { _ColumnHeader1 });
        _ListView1.Location = new System.Drawing.Point(256, 352);
        _ListView1.Name = "_ListView1";
        _ListView1.Size = new System.Drawing.Size(352, 40);
        _ListView1.TabIndex = 21;
        _ListView1.View = System.Windows.Forms.View.List;
        _ListView1.Visible = false;
        // 
        // ColumnHeader1
        // 
        _ColumnHeader1.Width = 25;
        // 
        // lblManualAuthCodeDetail
        // 
        _lblManualAuthCodeDetail.Location = new System.Drawing.Point(176, 216);
        _lblManualAuthCodeDetail.Name = "_lblManualAuthCodeDetail";
        _lblManualAuthCodeDetail.Size = new System.Drawing.Size(120, 16);
        _lblManualAuthCodeDetail.TabIndex = 20;
        // 
        // lblDeclineReason
        // 
        _lblDeclineReason.Location = new System.Drawing.Point(32, 240);
        _lblDeclineReason.Name = "_lblDeclineReason";
        _lblDeclineReason.Size = new System.Drawing.Size(264, 24);
        _lblDeclineReason.TabIndex = 19;
        // 
        // lblManualAuthCode
        // 
        _lblManualAuthCode.Location = new System.Drawing.Point(56, 216);
        _lblManualAuthCode.Name = "_lblManualAuthCode";
        _lblManualAuthCode.Size = new System.Drawing.Size(112, 16);
        _lblManualAuthCode.TabIndex = 18;
        _lblManualAuthCode.Text = "Authorization Code:";
        // 
        // lblManualNameOnCardDetail
        // 
        _lblManualNameOnCardDetail.Location = new System.Drawing.Point(120, 80);
        _lblManualNameOnCardDetail.Name = "_lblManualNameOnCardDetail";
        _lblManualNameOnCardDetail.Size = new System.Drawing.Size(152, 16);
        _lblManualNameOnCardDetail.TabIndex = 17;
        // 
        // lblanualName
        // 
        _lblanualName.Location = new System.Drawing.Point(24, 80);
        _lblanualName.Name = "_lblanualName";
        _lblanualName.Size = new System.Drawing.Size(88, 16);
        _lblanualName.TabIndex = 16;
        _lblanualName.Text = "Name on Card:";
        // 
        // lblManualCheck
        // 
        _lblManualCheck.Location = new System.Drawing.Point(24, 48);
        _lblManualCheck.Name = "_lblManualCheck";
        _lblManualCheck.Size = new System.Drawing.Size(192, 16);
        _lblManualCheck.TabIndex = 15;
        _lblManualCheck.Text = "Check #:      ";
        // 
        // NumberPadCreditAuth
        // 
        _NumberPadCreditAuth.BackColor = System.Drawing.Color.SlateGray;
        _NumberPadCreditAuth.DecimalUsed = false;
        _NumberPadCreditAuth.IntegerNumber = 0;
        _NumberPadCreditAuth.Location = new System.Drawing.Point(336, 16);
        _NumberPadCreditAuth.Name = "_NumberPadCreditAuth";
        _NumberPadCreditAuth.NumberString = (object)null;
        _NumberPadCreditAuth.NumberTotal = new decimal(new int[] { 0, 0, 0, 0 });
        _NumberPadCreditAuth.Size = new System.Drawing.Size(240, 368);
        _NumberPadCreditAuth.TabIndex = 14;
        // 
        // chkCloseOverrideDup
        // 
        _chkCloseOverrideDup.Location = new System.Drawing.Point(168, 352);
        _chkCloseOverrideDup.Name = "_chkCloseOverrideDup";
        _chkCloseOverrideDup.Size = new System.Drawing.Size(96, 16);
        _chkCloseOverrideDup.TabIndex = 13;
        _chkCloseOverrideDup.Text = "Override Dup";
        // 
        // lblManualTipDetail
        // 
        _lblManualTipDetail.Location = new System.Drawing.Point(120, 176);
        _lblManualTipDetail.Name = "_lblManualTipDetail";
        _lblManualTipDetail.Size = new System.Drawing.Size(112, 16);
        _lblManualTipDetail.TabIndex = 12;
        // 
        // lblManualAmountDetail
        // 
        _lblManualAmountDetail.Location = new System.Drawing.Point(120, 152);
        _lblManualAmountDetail.Name = "_lblManualAmountDetail";
        _lblManualAmountDetail.Size = new System.Drawing.Size(136, 16);
        _lblManualAmountDetail.TabIndex = 11;
        // 
        // lblManualTip
        // 
        _lblManualTip.Location = new System.Drawing.Point(24, 176);
        _lblManualTip.Name = "_lblManualTip";
        _lblManualTip.Size = new System.Drawing.Size(80, 16);
        _lblManualTip.TabIndex = 10;
        _lblManualTip.Text = "Gratuity:         $";
        // 
        // lblManualAmount
        // 
        _lblManualAmount.Location = new System.Drawing.Point(24, 152);
        _lblManualAmount.Name = "_lblManualAmount";
        _lblManualAmount.Size = new System.Drawing.Size(80, 16);
        _lblManualAmount.TabIndex = 9;
        _lblManualAmount.Text = "Amount:         $";
        // 
        // lblManualExpDateDetail
        // 
        _lblManualExpDateDetail.Location = new System.Drawing.Point(120, 128);
        _lblManualExpDateDetail.Name = "_lblManualExpDateDetail";
        _lblManualExpDateDetail.Size = new System.Drawing.Size(168, 16);
        _lblManualExpDateDetail.TabIndex = 8;
        // 
        // lblManualAcctNumberDetail
        // 
        _lblManualAcctNumberDetail.Location = new System.Drawing.Point(120, 104);
        _lblManualAcctNumberDetail.Name = "_lblManualAcctNumberDetail";
        _lblManualAcctNumberDetail.Size = new System.Drawing.Size(184, 16);
        _lblManualAcctNumberDetail.TabIndex = 7;
        // 
        // btnCancel
        // 
        _btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnCancel.Location = new System.Drawing.Point(16, 344);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.Size = new System.Drawing.Size(88, 40);
        _btnCancel.TabIndex = 6;
        _btnCancel.Text = "Cancel";
        // 
        // btnAuth
        // 
        _btnAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnAuth.Location = new System.Drawing.Point(176, 280);
        _btnAuth.Name = "_btnAuth";
        _btnAuth.Size = new System.Drawing.Size(88, 40);
        _btnAuth.TabIndex = 5;
        _btnAuth.Text = "Auth";
        // 
        // btnPreAuth
        // 
        _btnPreAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnPreAuth.Location = new System.Drawing.Point(56, 280);
        _btnPreAuth.Name = "_btnPreAuth";
        _btnPreAuth.Size = new System.Drawing.Size(88, 40);
        _btnPreAuth.TabIndex = 4;
        _btnPreAuth.Text = "Pre-Auth";
        // 
        // lblManualExpDate
        // 
        _lblManualExpDate.Location = new System.Drawing.Point(24, 128);
        _lblManualExpDate.Name = "_lblManualExpDate";
        _lblManualExpDate.Size = new System.Drawing.Size(80, 16);
        _lblManualExpDate.TabIndex = 3;
        _lblManualExpDate.Text = "Exp Date:";
        // 
        // lblManualAccount
        // 
        _lblManualAccount.Location = new System.Drawing.Point(24, 104);
        _lblManualAccount.Name = "_lblManualAccount";
        _lblManualAccount.Size = new System.Drawing.Size(80, 16);
        _lblManualAccount.TabIndex = 2;
        _lblManualAccount.Text = "Acoount #:";
        // 
        // lblCLoseManual
        // 
        _lblCLoseManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblCLoseManual.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _lblCLoseManual.Location = new System.Drawing.Point(32, 16);
        _lblCLoseManual.Name = "_lblCLoseManual";
        _lblCLoseManual.Size = new System.Drawing.Size(280, 16);
        _lblCLoseManual.TabIndex = 1;
        _lblCLoseManual.Text = "Credit Card Authorization";
        _lblCLoseManual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // AxDSICLientX2
        // 
        _AxDSICLientX2.ContainingControl = this;
        _AxDSICLientX2.Enabled = true;
        _AxDSICLientX2.Location = new System.Drawing.Point(264, 264);
        _AxDSICLientX2.Name = "_AxDSICLientX2";
        _AxDSICLientX2.OcxState = (Global.System.Windows.Forms.AxHost.State)resources.GetObject("AxDSICLientX2.OcxState");
        _AxDSICLientX2.Size = new System.Drawing.Size(100, 50);
        _AxDSICLientX2.TabIndex = 1;
        // 
        // tmrCardRead
        // 
        _tmrCardRead.Interval = 950;
        // 
        // CloseManualAuth
        // 
        this.BackColor = System.Drawing.Color.SlateBlue;
        this.Controls.Add(_Panel1);
        this.Name = "CloseManualAuth";
        this.Size = new System.Drawing.Size(688, 448);
        _Panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_AxDSICLientX2).EndInit();
        this.ResumeLayout(false);

    }

    #endregion


    private void InitializeOther()
    {

        NumberPadCreditAuth.ChangeLabelDimensions();

        if (cardSwiped == true)
        {
            lblManualAccount.Enabled = false;
            lblManualAcctNumberDetail.Enabled = false;
        }



        lblManualCheck.Text = "Check #       " + CloseAuthTransaction.InvoiceNo;
        lblManualAmountDetail.Text = CloseAuthAmount.Purchase;




        // Me.lblManualNameOnCardDetail.Text = authPayment.Name
        // Me.lblManualAcctNumberDetail.Text = authPayment.Account
        // Me.lblManualExpDateDetail.Text = authPayment.ExpDate
        // 
        // '        Me.lblManualTipDetail.Text = authPayment.Gratuity
        // Me.lblManualAuthCodeDetail.Text = authPayment.AuthCode''
        // 
        // '        If Me.lblManualAuthCodeDetail.Text.Length = 6 Then
        // authTest = True
        // End If


    }

    private void btnPreAuth_Click(object sender, EventArgs e)
    {

        string preAuthReady;

        // If cardSwiped = False Then
        // MsgBox("Please Swipe Credit Card")
        // Exit Sub
        // End If


        preAuthReady = Conversions.ToString(TestPreAuthSwiped());
        if (preAuthReady == "Swiped")
        {
            PreAuth();
        }
        else if (preAuthReady == "Keyed")
        {
            PreAuth();
        }

    }


    private void StartPreAuthCapture()
    {


    }

    private object TestPreAuthSwiped()
    {

        var isReady = default(string);

        if (CloseAuthAmount.Purchase <= 0)
        {
            // isReady = False
            // info = New DataSet_Builder.Information_UC("Auth Amount must be greater than $0.00")
            // info.Location = New Point((Me.Width - info.Width) / 2, (Me.Height - info.Height) / 2)
            // Me.Controls.Add(info)
            // info.BringToFront()
            Interaction.MsgBox("Auth Amount must be greater than $0.00");
            return isReady;
        }

        // If CloseAuthAmount.Authorize <= 0 Then
        // CloseAuthAmount.Authorize = Format(CloseAuthAmount.Purchase * 1.2, "#####.00")
        // End If

        // CloseAuthAmount.Gratuity = "0.00"

        if (CloseAuthAccount.Track2 == default)       // CloseAuthAccount.Track2.Length = 0 Then
        {
            if (lblManualAcctNumberDetail.Text.Length > 0 & lblManualExpDateDetail.Text.Length == 4)
            {
                CloseAuthAccount.AcctNo = lblManualAcctNumberDetail.Text;
                CloseAuthAccount.ExpDate = lblManualExpDateDetail.Text;
                isReady = "Keyed";
                return isReady;
            }
            // isReady = False
            Interaction.MsgBox("Card Swipe Does Not Read Correctly");
            return isReady;
        }

        isReady = "Swiped";
        return isReady;


    }

    private void PreAuth()
    {

        // Dim serializer As New XmlSerializer(GetType(TStream))
        // Dim writer As New StreamWriter("preauth.xml")


        var mpsPreAuth = new TStream();
        var mpsPreAuthTransaction = new PreAuthTransactionClass();

        mpsPreAuthTransaction = CloseAuthTransaction;
        mpsPreAuthTransaction.Account = CloseAuthAccount;
        mpsPreAuthTransaction.Amount = CloseAuthAmount;
        // mpsPreAuthTransaction.Amount.Gratuity = Nothing

        mpsPreAuth.Transaction = mpsPreAuthTransaction;


        // serializer.Serialize(writer, mpsPreAuth)
        // writer.Close()


        var output = new StringWriter(new StringBuilder());
        var s = new XmlSerializer(typeof(TStream));
        s.Serialize(output, mpsPreAuth);


        ParseXMLResponse(output.ToString());
        // TestingDSI(output.ToString)


        // Console.Write(output)
        // MsgBox(output.ToString)
        // Dim p As New StringBuilder(mpsPreAuth.ToXML)
        // p.Append(mpsPreAuth.ToXML)


    }

    public void XMLSerializeString222() // old
    {

        var serializer = new XmlSerializer(typeof(TStream));

    }

    public object WriteXMLString222(string fs)  // old
    {

        var xmlString = default(string);

        try
        {
            // Create an instance of StreamReader to read from a file.
            var sr = new StreamReader(fs);
            string line;

            // Read and display the lines from the file until the end 
            // of the file is reached.
            do
            {
                line = sr.ReadLine();

                Console.WriteLine(line);
            }
            while (!(line is null));
            sr.Close();
        }
        catch (Exception E)
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(E.Message);
        }

        return xmlString;

    }

    private void PreAuthKeyed222()      // auth
    {

        var serializer = new XmlSerializer(typeof(TStream));
        var writer = new StreamWriter("preauth.xml");

        var mpsPreAuth = new TStream();
        var mpsPreAuthTransaction = new PreAuthTransactionClass();

        mpsPreAuthTransaction = CloseAuthTransaction;
        mpsPreAuthTransaction.Account = CloseAuthAccount;
        mpsPreAuthTransaction.Amount = CloseAuthAmount;

        mpsPreAuth.Transaction = mpsPreAuthTransaction;

        serializer.Serialize(writer, mpsPreAuth);
        writer.Close();




    }

    private void CloseManualAuth_Load(object sender, EventArgs e)
    {

        HidGuid = Guid.Empty;
        lastDevice = false;

        security.lpSecurityDescriptor = 0;
        security.bInheritHandle = Conversions.ToInteger(true);
        security.nLength = Len(security);

        result = HidD_GetHidGuid(ref HidGuid);

        deviceInfoSet = SetupDiGetClassDevs(ref HidGuid, ref vbNullString, 0, DIGCF_PRESENT | DIGCF_DEVICEINTERFACE);       // 16) '2 Or 16)
        // MsgBox(deviceInfoSet.GetHashCode)

        MemberIndex = 0;

        do
        {

            myDeviceInterfaceData.cbSize = Marshal.SizeOf(myDeviceInterfaceData);

            result = SetupDiEnumDeviceInterfaces(deviceInfoSet, 0, ref HidGuid, MemberIndex, ref myDeviceInterfaceData);
            if (result == 0)
                lastDevice = true;

            if (result != 0)
            {

                bResult = SetupDiGetDeviceInterfaceDetail(deviceInfoSet, ref myDeviceInterfaceData, IntPtr.Zero, 0, ref m_lBufferSize, IntPtr.Zero);

                // store the structure data
                myDeviceInterfaceDetailData.cbSize = Marshal.SizeOf(myDeviceInterfaceDetailData);
                var detailDataBuffer = Marshal.AllocHGlobal(m_lBufferSize);

                // stores cbSize in first 4 bytes of array
                Marshal.WriteInt32(detailDataBuffer, 4 + Marshal.SystemDefaultCharSize);


                bResult = SetupDiGetDeviceInterfaceDetail(deviceInfoSet, ref myDeviceInterfaceData, detailDataBuffer, m_lBufferSize, ref m_lBufferSize, IntPtr.Zero);

                var pDevicePathName = new IntPtr(detailDataBuffer.ToInt32() + 4);

                devicePathName = Marshal.PtrToStringAuto(pDevicePathName);

                Marshal.FreeHGlobal(detailDataBuffer);   // free's memory allocated earlier

                HIDHandle = CreateFile(ref devicePathName, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, ref security, OPEN_EXISTING, 0, 0);


                deviceAttributes.Size = Marshal.SizeOf(deviceAttributes);
                result = HidD_GetAttributes(HIDHandle, ref deviceAttributes);
                if (Conversions.ToDouble(Hex(deviceAttributes.VendorID)) == (double)MyVendorID & Conversions.ToDouble(Hex(deviceAttributes.ProductID)) == (double)MyProductID)
                {
                    myDeviceDetected = true;
                }

                // MsgBox(Hex(deviceAttributes.VendorID))
            }

            MemberIndex += 1;
        }

        while (!(lastDevice == true | myDeviceDetected == true));


        result = SetupDiDestroyDeviceInfoList(deviceInfoSet);


        if (myDeviceDetected == true)
        {
            // FindtheHid = True
            // Dim result As Boolean
            // result = RegisterHidNotification(devicePathName)
            // ADD    registerHidNotification


            GetDeviceCapabilities();

            ReadHandle = CreateFile(ref devicePathName, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, ref security, OPEN_EXISTING, FILE_FLAG_OVERLAPPED, 0);
            PrepareForOverlappedTransfer();
            tmrCardRead.Enabled = true;
        }



    }

    private void PaymentInfoEntered(object sender, EventArgs e)
    {

        if (activeAccountNo == true)
        {
            lblManualAcctNumberDetail.Text = NumberPadCreditAuth.NumberString;
            InactivateLabels();
            activeExpDate = true;
            lblManualExpDate.BackColor = c9;


            NumberPadCreditAuth.NumberString = lblManualExpDateDetail.Text;
            NumberPadCreditAuth.ShowNumberString();
        }

        else if (activeExpDate == true)
        {
            if (NumberPadCreditAuth.NumberString.Length == 4)
            {
                lblManualExpDateDetail.Text = NumberPadCreditAuth.NumberString;
                InactivateLabels();
                activeAmount = true;
                lblManualAmount.BackColor = c9;

                NumberPadCreditAuth.DecimalUsed = true;
                NumberPadCreditAuth.NumberString = lblManualAmountDetail.Text;
                NumberPadCreditAuth.ShowNumberString();
            }

            else
            {
                Interaction.MsgBox("Expiration Date sould be in 4 digits: MMYY");
            }
        }


        else if (activeAmount == true)
        {
            lblManualAmountDetail.Text = NumberPadCreditAuth.NumberString;
            InactivateLabels();

        }

    }

    private void InactivateLabels()
    {

        tmrCardRead.Enabled = false;
        activeAccountNo = false;
        activeExpDate = false;
        activeAmount = false;
        activeTip = false;

        lblanualName.BackColor = c10;
        lblManualAccount.BackColor = c10;
        lblManualExpDate.BackColor = c10;
        lblManualAmount.BackColor = c10;
        lblManualTip.BackColor = c10;



    }


    private void lblManualAcctNumberDetail_Click(object sender, EventArgs e)
    {

        EnterAccountNumber();

    }

    private void lblManualAccount_Click(object sender, EventArgs e)
    {

        EnterAccountNumber();

    }

    private void EnterAccountNumber()
    {

        InactivateLabels();
        activeAccountNo = true;
        lblManualAccount.BackColor = c9;

        NumberPadCreditAuth.DecimalUsed = false;

        NumberPadCreditAuth.NumberString = lblManualAcctNumberDetail.Text;
        NumberPadCreditAuth.ShowNumberString();
        NumberPadCreditAuth.Focus();


    }



    private void lblanualName_Click(object sender, EventArgs e)
    {
        EnterNameOnCard();
    }

    private void lblManualNameOnCardDetail_Click(object sender, EventArgs e)
    {
        EnterNameOnCard();
    }


    private void EnterNameOnCard()
    {

        InactivateLabels();

        paymentKeyboard = new DataSet_Builder.KeyBoard_UC();
        paymentKeyboard.Location = new Point(10, 0);
        this.Controls.Add(paymentKeyboard);
        paymentKeyboard.BringToFront();


    }


    private void NameEntered(object sender, EventArgs e)
    {


        lblManualNameOnCardDetail.Text = paymentKeyboard.EnteredString;
        paymentKeyboard.Dispose();


    }



    private void lblManualExpDate_Click(object sender, EventArgs e)
    {
        EnterExpDate();
    }

    private void lblManualExpDateDetail_Click(object sender, EventArgs e)
    {
        EnterExpDate();
    }

    private void EnterExpDate()
    {
        InactivateLabels();
        activeExpDate = true;
        lblManualExpDate.BackColor = c9;

        NumberPadCreditAuth.DecimalUsed = false;

        NumberPadCreditAuth.NumberString = lblManualExpDateDetail.Text;
        NumberPadCreditAuth.ShowNumberString();
        NumberPadCreditAuth.Focus();

    }

    private void lblManualTip_Click(object sender, EventArgs e)
    {
        EnterGratuity();
    }

    private void lblManualTipDetail_Click(object sender, EventArgs e)
    {
        EnterGratuity();
    }

    private void EnterGratuity()
    {
        InactivateLabels();
        activeTip = true;
        lblManualTip.BackColor = c9;

        NumberPadCreditAuth.DecimalUsed = true;

        NumberPadCreditAuth.NumberString = lblManualTipDetail.Text;
        NumberPadCreditAuth.ShowNumberString();
        NumberPadCreditAuth.Focus();


    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.Dispose();

    }





    [DllImport("hid.dll")]
    public static extern int HidD_GetAttributes(int HidDeviceObject, ref HIDD_ATTRIBUTES Attributes);



    // Declared as a function for consistency,
    // but returns nothing. (Ignore the returned value.)
    [DllImport("hid.dll")]
    public static extern int HidD_GetHidGuid(ref Guid HidGuid);



    [DllImport("setupapi.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, string Enumerator, int hwndParent, int Flags);





    [DllImport("setupapi.dll")]
    public static extern int SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);



    [DllImport("setupapi.dll")]
    public static extern int SetupDiEnumDeviceInterfaces(IntPtr DeviceInfoSet, int DeviceInfoData, ref Guid InterfaceClassGuid, int MemberIndex, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);






    [DllImport("setupapi.dll", CharSet = CharSet.Auto)]
    public static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr DeviceInfoSet, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData, IntPtr DeviceInterfaceDetailData, int DeviceInterfaceDetailDataSize, ref int RequiredSize, IntPtr DeviceInfoData);







    [DllImport("kernel32")]
    public static extern int CancelIo(int hFile);


    [DllImport("kernel32", CharSet = CharSet.Auto)]
    public static extern int CreateFile(string lpFileName, int dwDesiredAccess, int dwShareMode, ref SECURITY_ATTRIBUTES lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, int hTemplateFile);








    [DllImport("kernel32")]
    public static extern int ReadFile(int hFile, ref byte lpBuffer, int nNumberOfBytesToRead, ref int lpNumberOfBytesRead, ref OVERLAPPED lpOverlapped);






    [DllImport("kernel32")]
    public static extern int WaitForSingleObject(int hHandle, int dwMilliseconds);



    [DllImport("kernel32", CharSet = CharSet.Auto)]
    public static extern int CreateEvent(int SecurityAttributes, int bManualReset, int bInitialState, string lpName);




    [DllImport("hid.dll")]
    public static extern int HidD_GetPreparsedData(int HidDeviceObject, ref IntPtr PreparsedData);




    [DllImport("hid.dll")]
    public static extern int HidP_GetCaps(IntPtr PreparsedData, ref HIDP_CAPS Capabilities);



    [DllImport("hid.dll")]
    public static extern int HidP_GetValueCaps(short ReportType, ref byte ValueCaps, ref short ValueCapsLength, IntPtr PreparsedData);





    [DllImport("hid.dll")]
    public static extern int HidD_FreePreparsedData(ref IntPtr PreparsedData);




    private void tmrCardRead_Tick(object sender, EventArgs e)
    {

        ReadAndWriteToDevice();

    }

    private void ReadAndWriteToDevice()
    {
        testCounter += 1;

        ReadReport();
    }

    private void GetDeviceCapabilities()
    {

        // ******************************************************************************
        // HidD_GetPreparsedData
        // Returns: a pointer to a buffer containing information about the device's capabilities.
        // Requires: A handle returned by CreateFile.
        // There's no need to access the buffer directly,
        // but HidP_GetCaps and other API functions require a pointer to the buffer.
        // ******************************************************************************

        var ppData = new byte[30];
        string ppDataString;

        // Preparsed Data is a pointer to a routine-allocated buffer.
        result = HidD_GetPreparsedData(HIDHandle, ref PreparsedData);

        // Copy the data at PreparsedData into a byte array.

        try
        {
            ppDataString = Convert.ToBase64String(ppData);
        }
        catch (ArgumentNullException exp)
        {
            Interaction.MsgBox("PreparsedData array is null.");
            return;
        }

        // ******************************************************************************
        // HidP_GetCaps
        // Find out the device's capabilities.
        // For standard devices such as joysticks, you can find out the specific
        // capabilities of the device.
        // For a custom device where the software knows what the device is capable of,
        // this call is unneeded.
        // Requires: The pointer to a buffer containing the information.
        // The pointer is returned by HidD_GetPreparsedData.
        // Returns: a Capabilites structure containing the information.
        // ******************************************************************************

        result = HidP_GetCaps(PreparsedData, ref Capabilities);


        // ******************************************************************************
        // HidP_GetValueCaps
        // Returns a buffer containing an array of HidP_ValueCaps structures.
        // Each structure defines the capabilities of one value.
        // This application doesn't use this data.
        // ******************************************************************************

        // This is a guess. The byte array holds the structures.
        var ValueCaps = new byte[1024];

        result = HidP_GetValueCaps(HidP_Input, ref ValueCaps[0], ref Capabilities.NumberInputValueCaps, PreparsedData);

        // Call DisplayResultOfAPICall("HidP_GetValueCaps")

        // To use this data, copy the ValueCaps byte array into an array of structures.

        // Free the buffer reserved by HidD_GetPreparsedData
        result = HidD_FreePreparsedData(ref PreparsedData);
        // Call DisplayResultOfAPICall("HidD_FreePreparsedData")


    }


    private void PrepareForOverlappedTransfer()
    {

        // ******************************************************************************
        // CreateEvent
        // Creates an event object for the overlapped structure used with ReadFile.
        // Requires a security attributes structure or null,
        // Manual Reset = False (The system automatically resets the state to nonsignaled 
        // after a waiting thread has been released.),
        // Initial state = True (signaled),
        // and event object name (optional)
        // Returns a handle to the event object.
        // ******************************************************************************

        if (EventObject == 0)
        {
            string arglpName = "";
            EventObject = CloseManualAuth.CreateEvent(0, Conversions.ToInteger(false), Conversions.ToInteger(true), ref arglpName);
        }
        // MsgBox(EventObject)


        // Set the members of the overlapped structure.
        HIDOverlapped.Offset = 0;
        HIDOverlapped.OffsetHigh = 0;
        HIDOverlapped.hEvent = EventObject;
    }

    private void ReadReport()
    {
        // Read data from the device.

        // Dim Count As Object
        int count;
        var NumberOfBytesRead = default(int);
        // Allocate a buffer for the report.
        // Byte 0 is the report ID.
        byte[] ReadBuffer;
        short UBoundReadBuffer;

        // ******************************************************************************
        // ReadFile
        // Returns: the report in ReadBuffer.
        // Requires: a device handle returned by CreateFile
        // (for overlapped I/O, CreateFile must be called with FILE_FLAG_OVERLAPPED),
        // the Input report length in bytes returned by HidP_GetCaps,
        // and an overlapped structure whose hEvent member is set to an event object.
        // ******************************************************************************

        string nonHexValue;
        string ByteValue;
        // The ReadBuffer array begins at 0, so subtract 1 from the number of bytes.
        ReadBuffer = new byte[Capabilities.InputReportByteLength];
        // Scroll to the bottom of the list box.
        // lstResults.SelectedIndex = lstResults.Items.Count - 1

        // MsgBox("2")

        // Do an overlapped ReadFile.
        // The function returns immediately, even if the data hasn't been received yet.
        result = ReadFile(ReadHandle, ref ReadBuffer[0], Capabilities.InputReportByteLength, ref NumberOfBytesRead, ref HIDOverlapped);





        // ******************************************************************************
        // WaitForSingleObject
        // Used with overlapped ReadFile.
        // Returns when ReadFile has received the requested amount of data or on timeout.
        // Requires an event object created with CreateEvent
        // and a timeout value in milliseconds.
        // ******************************************************************************
        result = WaitForSingleObject(EventObject, 1000);    // 30000 is a 30 second timeout


        int track2Length;

        track2Length = ReadBuffer[4];
        var ascii = new ASCIIEncoding();
        char ByteChar;
        var nextTrack2Count = default(int);
        // Dim firstName As String
        // Dim lastName As String
        // think about how middle name and business name are on cards


        // Find out if ReadFile completed or timeout.
        switch (result)
        {
            case var @case when @case == WAIT_OBJECT_0:
                {
                    // ReadFile has completed
                    // txtTest = ascii.GetString(ReadBuffer, 117, track2Length - 1)

                    for (count = 8; count <= 336; count++)
                    {
                        if (Conversions.ToString(Strings.Chr(ReadBuffer[count])) == "^")
                        {
                            nextTrack2Count = count + 1;
                            break;
                        }
                    }

                    _closeAuthAccount.Name = " ";     // place the space between names first

                    // lastName
                    for (count = nextTrack2Count; count <= 336; count++)
                    {
                        if (Conversions.ToString(Strings.Chr(ReadBuffer[count])) == "/")
                        {
                            nextTrack2Count = count + 1;
                            break;
                        }
                        _closeAuthAccount.Name = CloseAuthAccount.Name + Strings.Chr(ReadBuffer[count]);
                    }


                    // FirstName
                    var firstNameString = default(string);
                    for (count = nextTrack2Count; count <= 336; count++)
                    {
                        if (Conversions.ToString(Strings.Chr(ReadBuffer[count])) == "^")
                        {
                            nextTrack2Count = count + 1;
                            break;
                        }
                        firstNameString = firstNameString + Strings.Chr(ReadBuffer[count]);
                    }
                    _closeAuthAccount.Name = firstNameString + CloseAuthAccount.Name;
                    lblManualNameOnCardDetail.Text = CloseAuthAccount.Name;

                    // finds the start of Track2 info
                    for (count = nextTrack2Count; count <= 336; count++)
                    {
                        if (Conversions.ToString(Strings.Chr(ReadBuffer[count])) == ";")
                        {
                            nextTrack2Count = count + 1;
                            break;
                        }
                    }

                    // AccountNumber
                    for (count = nextTrack2Count; count <= 336; count++)
                    {
                        _closeAuthAccount.Track2 = CloseAuthAccount.Track2 + Strings.Chr(ReadBuffer[count]); // this will add the =
                        if (Conversions.ToString(Strings.Chr(ReadBuffer[count])) == "=")
                        {
                            nextTrack2Count = count + 1;
                            break;
                        }
                        lblManualAcctNumberDetail.Text = lblManualAcctNumberDetail.Text + Strings.Chr(ReadBuffer[count]);
                    }
                    // MsgBox(CloseAuthAccount.Track2)


                    // ExpYear
                    // Me.lblManualExpDateDetail.Text = " / "
                    var loopTo = nextTrack2Count + 1;
                    for (count = nextTrack2Count; count <= loopTo; count++)  // reads 2 characters
                    {
                        _closeAuthAccount.Track2 = CloseAuthAccount.Track2 + Strings.Chr(ReadBuffer[count]);
                        lblManualExpDateDetail.Text = lblManualExpDateDetail.Text + Strings.Chr(ReadBuffer[count]);
                    }
                    nextTrack2Count += 2;


                    // ExpMonth
                    var monthString = default(string);
                    var loopTo1 = nextTrack2Count + 1;
                    for (count = nextTrack2Count; count <= loopTo1; count++)  // reads 2 characters
                    {
                        _closeAuthAccount.Track2 = CloseAuthAccount.Track2 + Strings.Chr(ReadBuffer[count]);
                        monthString = monthString + Strings.Chr(ReadBuffer[count]);
                    }
                    lblManualExpDateDetail.Text = monthString + lblManualExpDateDetail.Text;
                    nextTrack2Count += 2;


                    for (count = nextTrack2Count; count <= 336; count++)
                    {
                        if (Conversions.ToString(Strings.Chr(ReadBuffer[count])) == "?")
                        {
                            if (CloseAuthAccount.Track2.Length > 0)
                            {
                                cardSwiped = true;
                                // tmrCardRead.Dispose()
                                tmrCardRead.Enabled = false;
                            }
                            // MsgBox(CloseAuthAccount.Track2)
                            else
                            {
                                Interaction.MsgBox("Card Swipe does Not Read Correctly");
                            }

                            return;
                        }
                        _closeAuthAccount.Track2 = CloseAuthAccount.Track2 + Strings.Chr(ReadBuffer[count]);
                    }

                    break;
                }
            // MsgBox("ReadFile completed successfully.")



            case var case1 when case1 == WAIT_TIMEOUT:
                {

                    GetDeviceCapabilities();
                    ReadHandle = CreateFile(ref devicePathName, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, ref security, OPEN_EXISTING, FILE_FLAG_OVERLAPPED, 0);
                    PrepareForOverlappedTransfer();
                    break;
                }

            default:
                {
                    break;
                }

        }




    }



    private void PopulateCardInformation(string track2)
    {



    }

    private void TestingDSI(string XMLString)
    {


        string resp;

        dsi.ServerIPConfig("x1.mercurypay.com;x2.mercurypay.com;b1.backuppay.com;b2.backuppay.com", 0);
        resp = dsi.ProcessTransaction(XMLString, 0, "", "");


        // Dim writer As New StreamWriter("preauthrResponse.txt")
        // writer.Write(resp)
        // writer.Close()



        // ParseXMLResponse(resp)

    }


    private void ParseXMLResponse(string resp)
    {

        var reader = new XmlTextReader(new StringReader(resp));
        var someError = default(bool);
        var isPreAuth = default(bool);


        try
        {
            while (reader.EOF != true)
            {
                reader.Read();
                reader.MoveToContent();
                if (reader.NodeType == XmlNodeType.Element)
                {
                    Interaction.MsgBox(reader.Name);
                    switch (reader.Name ?? "")
                    {

                        case "DSIXReturnCode":
                            {
                                if (string.Compare(reader.ReadInnerXml(), "000000", true) != 0)
                                {
                                    // false, do not honor case (is not case sensitive)
                                    // a zero means the same (therefore this is not the same)
                                    // there is sometype of error
                                    someError = true;


                                }
                                Interaction.MsgBox(reader.ReadInnerXml(), Title: "OperatorID");
                                break;
                            }

                        case "CmdStatus":
                            {
                                switch (reader.ReadInnerXml() ?? "")
                                {
                                    case "Approved":
                                        {
                                            break;
                                        }

                                    case "Declined":
                                        {
                                            break;
                                        }

                                    case "Success":
                                        {
                                            break;
                                        }

                                    case "Error":
                                        {
                                            break;
                                        }

                                }

                                break;
                            }

                        case "TextResponse":
                            {
                                if (someError == true)
                                {
                                    Interaction.MsgBox(reader.ReadInnerXml());
                                    return;
                                }
                                else
                                {

                                }

                                break;
                            }

                        case "UserTraceData":
                            {
                                break;
                            }

                        // **************************************
                        // Transaction Response
                        // **************************************

                        case "TranCode":
                            {
                                if (string.Compare(reader.ReadInnerXml(), "PreAuth", true) == 0)
                                {
                                    isPreAuth = true;
                                }

                                break;
                            }

                        case "AuthCode":
                            {
                                if (isPreAuth == true)
                                {
                                    // place authcode in database
                                }

                                break;
                            }

                        case "AcqRefData":
                            {
                                if (isPreAuth == true)
                                {
                                    // place acqRefData in database
                                }

                                break;
                            }

                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            if (reader is not null)
            {
                reader.Close();
            }

        }





        return;



        while (reader.EOF != true)
        {
            reader.Read();
            reader.MoveToContent();
            if (reader.NodeType == XmlNodeType.Element)
            {
                Interaction.MsgBox(reader.Name);
                switch (reader.Name ?? "")
                {

                    case "OperatorID":
                        {
                            Interaction.MsgBox(reader.ReadInnerXml(), Title: "OperatorID");
                            break;
                        }
                    case "Name":
                        {
                            Interaction.MsgBox(reader.ReadInnerXml(), Title: "Name");
                            break;
                        }
                }
            }
        }


        try
        {
            while (reader.Read())
            {


                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        {
                            Interaction.MsgBox(reader.Name, Title: "Element");
                            break;
                        }
                    case XmlNodeType.Text:
                        {
                            Interaction.MsgBox(reader.Value, Title: "Text");
                            break;
                        }
                }
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            if (reader is not null)
            {
                reader.Close();
            }

        }




        reader.WhitespaceHandling = WhitespaceHandling.None;

        reader.MoveToContent();
        reader.Read();

        reader.MoveToContent();
        reader.Read();
        Interaction.MsgBox(reader.Value, Title: "The Ref No is: ");
        // reader.MoveToContent()

        Interaction.MsgBox(reader.Name);             // MerchantID
        Interaction.MsgBox(reader.ReadInnerXml());     // 494901
        Interaction.MsgBox(reader.Value);




        // If reader.HasAttributes Then
        // Console.WriteLine("Attributes of <" & reader.Name & ">")
        int i;
        var loopTo = reader.AttributeCount - 1;
        for (i = 0; i <= loopTo; i++)
        {
            reader.MoveToAttribute(i);
            Interaction.MsgBox(" {0}={1}", (MsgBoxStyle)Conversions.ToInteger(reader.Name), reader.Value);
        }
        // End If
        // 
        // reader.MoveToAttribute("OperatorID")
        // MsgBox(reader.Value)


    }

}