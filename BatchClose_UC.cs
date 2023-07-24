using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using DataSet_Builder;


public partial class BatchClose_UC : System.Windows.Forms.UserControl
{

    private long _batchDailyCode;
    private DataSet_Builder.Payment_UC[] paymentPanel;
    private StreamWriter sWriter1;
    private bool printedDetail;

    private DSICLIENTXLib.DSICLientX dsi;
    // Dim dsi As New DSICLIENTXLib.DSICLientX
    // old   Dim dsi As New AxDSICLIENTXLib.AxDSICLientX
    private SIM.Charge _PaywarePCCharge;

    private SIM.Charge PaywarePCCharge
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _PaywarePCCharge;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _PaywarePCCharge = value;
        }
    }

    private AdminClass mpsAdmin;
    private TStream mpsTStream;
    private PreAuthTransactionClass mpsTransaction;
    private PreAuthAmountClass mpsAmount;
    private AccountClass mpsAccount;
    private TranInfoClass mpsTransInfo;

    private int paymentRowIndex;
    private int panelIndex;

    private string activePanelDisplay;
    private int naPanelIndex = 0;
    private int cpPanelIndex = 0;
    private int crPanelIndex = 0;
    private int bdPanelIndex = 0;
    private int netPanelIndex = 0;

    // Dim displayActive As String
    private bool changesMadeToTips;

    // Dim batchNumber As String
    // Dim pos As BatchInfo
    private bool notAllCash;
    private int posNonAdjCount;
    private decimal posNonAdjDollar;
    private int posCreditPurchaseCount;
    private decimal posCreditPurchaseDollar;
    private int posCreditReturnCount;
    private decimal posCreditReturnDollar;
    private int posNetCount;
    private decimal posNetDollar;
    private decimal posTempTipForPreAuthCaptureAdjustment;

    private BatchInfo batch;      // structure difined in Dinner Table
    private bool isSomethingDeclined;

    private string batchCloseNumber;
    private int batchCloseNetCount;
    private decimal batchCloseNetDollar;

    private int startPaymentIndex; // ?????

    private int startVoiceIndex;
    private int endVoiceIndex;
    private int startPreAuthIndex;
    private int endPreAuthIndex;
    private int startPreAuthCaptureIndex;
    private int endPreAuthCaptureIndex;
    private int startReturnIndex;
    private int endReturnIndex;


    public long BatchDailyCode
    {
        get
        {
            return _batchDailyCode;
        }
        set
        {
            _batchDailyCode = value;
        }
    }


    public event ExitBatchCloseEventHandler ExitBatchClose;

    public delegate void ExitBatchCloseEventHandler(long bdc);
    public event ExitWithoutCloseEventHandler ExitWithoutClose;

    public delegate void ExitWithoutCloseEventHandler();

    public BatchClose_UC()
    {
        base.@new();

    }

    #region  Windows Form Designer generated code 

    public BatchClose_UC(long closingDailyCode) : base()
    {
        _batchDailyCode = closingDailyCode;

        // This call is required by the Windows Form Designer.
        InitializeComponent();

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
    private DataSet_Builder.NumberPadLarge _NumberPadLarge1;

    internal virtual DataSet_Builder.NumberPadLarge NumberPadLarge1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _NumberPadLarge1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_NumberPadLarge1 != null)
            {
                _NumberPadLarge1.NumberEntered -= NumberPad_EnteredHit;
            }

            _NumberPadLarge1 = value;
            if (_NumberPadLarge1 != null)
            {
                _NumberPadLarge1.NumberEntered += NumberPad_EnteredHit;
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
    private Global.System.Windows.Forms.Panel _Panel5;

    internal virtual Global.System.Windows.Forms.Panel Panel5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel5 = value;
        }
    }
    private Global.System.Windows.Forms.Panel _Panel7;

    internal virtual Global.System.Windows.Forms.Panel Panel7
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel7;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel7 = value;
        }
    }
    private Global.System.Windows.Forms.Panel _Panel8;

    internal virtual Global.System.Windows.Forms.Panel Panel8
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel8;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel8 = value;
        }
    }
    private Global.System.Windows.Forms.Panel _Panel9;

    internal virtual Global.System.Windows.Forms.Panel Panel9
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel9;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel9 = value;
        }
    }
    private Global.System.Windows.Forms.Panel _Panel11;

    internal virtual Global.System.Windows.Forms.Panel Panel11
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel11;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel11 = value;
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
    private Global.System.Windows.Forms.Panel _pnlBatchPayments;

    internal virtual Global.System.Windows.Forms.Panel pnlBatchPayments
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlBatchPayments;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pnlBatchPayments != null)
            {
                _pnlBatchPayments.Click -= PaymentUserControl_Click;
            }

            _pnlBatchPayments = value;
            if (_pnlBatchPayments != null)
            {
                _pnlBatchPayments.Click += PaymentUserControl_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _Panel10;

    internal virtual Global.System.Windows.Forms.Panel Panel10
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel10;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel10 = value;
        }
    }
    private Global.System.Windows.Forms.Panel _Panel14;

    internal virtual Global.System.Windows.Forms.Panel Panel14
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel14;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel14 = value;
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
    private Global.System.Windows.Forms.Button _btnNetBatch;

    internal virtual Global.System.Windows.Forms.Button btnNetBatch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnNetBatch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnNetBatch != null)
            {
                _btnNetBatch.Click -= btnNetBatch_Click;
            }

            _btnNetBatch = value;
            if (_btnNetBatch != null)
            {
                _btnNetBatch.Click += btnNetBatch_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnCreditPurchase;

    internal virtual Global.System.Windows.Forms.Button btnCreditPurchase
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCreditPurchase;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCreditPurchase != null)
            {
                _btnCreditPurchase.Click -= btnCreditPurchase_Click;
            }

            _btnCreditPurchase = value;
            if (_btnCreditPurchase != null)
            {
                _btnCreditPurchase.Click += btnCreditPurchase_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnNonAdjusted;

    internal virtual Global.System.Windows.Forms.Button btnNonAdjusted
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnNonAdjusted;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnNonAdjusted != null)
            {
                _btnNonAdjusted.Click -= btnNonAdjusted_Click;
            }

            _btnNonAdjusted = value;
            if (_btnNonAdjusted != null)
            {
                _btnNonAdjusted.Click += btnNonAdjusted_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnCreditReturn;

    internal virtual Global.System.Windows.Forms.Button btnCreditReturn
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCreditReturn;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCreditReturn != null)
            {
                _btnCreditReturn.Click -= btnCreditReturn_Click;
            }

            _btnCreditReturn = value;
            if (_btnCreditReturn != null)
            {
                _btnCreditReturn.Click += btnCreditReturn_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblPOSNetDollar;

    internal virtual Global.System.Windows.Forms.Label lblPOSNetDollar
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPOSNetDollar;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblPOSNetDollar = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblPOSNetCount;

    internal virtual Global.System.Windows.Forms.Label lblPOSNetCount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPOSNetCount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblPOSNetCount = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblPOSCreditReturnDollar;

    internal virtual Global.System.Windows.Forms.Label lblPOSCreditReturnDollar
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPOSCreditReturnDollar;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblPOSCreditReturnDollar = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblPOSCreditReturnCount;

    internal virtual Global.System.Windows.Forms.Label lblPOSCreditReturnCount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPOSCreditReturnCount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblPOSCreditReturnCount = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblPOSNonAdjDollar;

    internal virtual Global.System.Windows.Forms.Label lblPOSNonAdjDollar
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPOSNonAdjDollar;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblPOSNonAdjDollar = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblPOSCreditPurchaseDollar;

    internal virtual Global.System.Windows.Forms.Label lblPOSCreditPurchaseDollar
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPOSCreditPurchaseDollar;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblPOSCreditPurchaseDollar = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblPOSCreditPurchaseCount;

    internal virtual Global.System.Windows.Forms.Label lblPOSCreditPurchaseCount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPOSCreditPurchaseCount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblPOSCreditPurchaseCount = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblBatchCreditPurchaseCount;

    internal virtual Global.System.Windows.Forms.Label lblBatchCreditPurchaseCount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblBatchCreditPurchaseCount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblBatchCreditPurchaseCount = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblBatchCreditPurchaseDollar;

    internal virtual Global.System.Windows.Forms.Label lblBatchCreditPurchaseDollar
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblBatchCreditPurchaseDollar;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblBatchCreditPurchaseDollar = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblBatchCreditReturnCount;

    internal virtual Global.System.Windows.Forms.Label lblBatchCreditReturnCount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblBatchCreditReturnCount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblBatchCreditReturnCount = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblBatchCreditReturnDollar;

    internal virtual Global.System.Windows.Forms.Label lblBatchCreditReturnDollar
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblBatchCreditReturnDollar;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblBatchCreditReturnDollar = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblBatchNetCount;

    internal virtual Global.System.Windows.Forms.Label lblBatchNetCount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblBatchNetCount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblBatchNetCount = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblBatchNetDollar;

    internal virtual Global.System.Windows.Forms.Label lblBatchNetDollar
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblBatchNetDollar;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblBatchNetDollar = value;
        }
    }
    private Global.System.Windows.Forms.Panel _Panel6;

    internal virtual Global.System.Windows.Forms.Panel Panel6
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel6;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel6 = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnSendAdjustments;

    internal virtual Global.System.Windows.Forms.Button btnSendAdjustments
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnSendAdjustments;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnSendAdjustments != null)
            {
                _btnSendAdjustments.Click -= btnSendAdjustments_Click;
            }

            _btnSendAdjustments = value;
            if (_btnSendAdjustments != null)
            {
                _btnSendAdjustments.Click += btnSendAdjustments_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblBatchSummary;

    internal virtual Global.System.Windows.Forms.Label lblBatchSummary
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblBatchSummary;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblBatchSummary = value;
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
    private Global.System.Windows.Forms.Label _lblPOSNonAdjCount;

    internal virtual Global.System.Windows.Forms.Label lblPOSNonAdjCount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPOSNonAdjCount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblPOSNonAdjCount = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnFinalize;

    internal virtual Global.System.Windows.Forms.Button btnFinalize
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnFinalize;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnFinalize != null)
            {
                _btnFinalize.Click -= btnFinalize_Click;
            }

            _btnFinalize = value;
            if (_btnFinalize != null)
            {
                _btnFinalize.Click += btnFinalize_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnRefresh;

    internal virtual Global.System.Windows.Forms.Button btnRefresh
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnRefresh;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnRefresh != null)
            {
                _btnRefresh.Click -= btnRefresh_Click;
            }

            _btnRefresh = value;
            if (_btnRefresh != null)
            {
                _btnRefresh.Click += btnRefresh_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _pnlDeclined;

    internal virtual Global.System.Windows.Forms.Panel pnlDeclined
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlDeclined;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlDeclined = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnDeclined;

    internal virtual Global.System.Windows.Forms.Button btnDeclined
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDeclined;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnDeclined != null)
            {
                _btnDeclined.Click -= btnDeclined_Click;
            }

            _btnDeclined = value;
            if (_btnDeclined != null)
            {
                _btnDeclined.Click += btnDeclined_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _Panel13;

    internal virtual Global.System.Windows.Forms.Panel Panel13
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel13;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel13 = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblNumberDeclined;

    internal virtual Global.System.Windows.Forms.Label lblNumberDeclined
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNumberDeclined;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblNumberDeclined = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblDollarDeclined;

    internal virtual Global.System.Windows.Forms.Label lblDollarDeclined
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblDollarDeclined;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblDollarDeclined = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnPrintAuth;

    internal virtual Global.System.Windows.Forms.Button btnPrintAuth
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnPrintAuth;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnPrintAuth != null)
            {
                _btnPrintAuth.Click -= btnPrintAuth_Click;
            }

            _btnPrintAuth = value;
            if (_btnPrintAuth != null)
            {
                _btnPrintAuth.Click += btnPrintAuth_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _Panel12;

    internal virtual Global.System.Windows.Forms.Panel Panel12
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel12;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel12 = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnDailyPreviousPage;

    internal virtual Global.System.Windows.Forms.Button btnDailyPreviousPage
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDailyPreviousPage;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnDailyPreviousPage != null)
            {
                _btnDailyPreviousPage.Click -= btnDailyPreviousPage_Click;
            }

            _btnDailyPreviousPage = value;
            if (_btnDailyPreviousPage != null)
            {
                _btnDailyPreviousPage.Click += btnDailyPreviousPage_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnDailyNextPage;

    internal virtual Global.System.Windows.Forms.Button btnDailyNextPage
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDailyNextPage;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnDailyNextPage != null)
            {
                _btnDailyNextPage.Click -= btnDailyNextPage_Click;
            }

            _btnDailyNextPage = value;
            if (_btnDailyNextPage != null)
            {
                _btnDailyNextPage.Click += btnDailyNextPage_Click;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchClose_UC));
        _Panel1 = new System.Windows.Forms.Panel();
        _Panel11 = new System.Windows.Forms.Panel();
        _Label20 = new System.Windows.Forms.Label();
        _Label21 = new System.Windows.Forms.Label();
        _Panel8 = new System.Windows.Forms.Panel();
        _lblPOSNetDollar = new System.Windows.Forms.Label();
        _lblPOSNetCount = new System.Windows.Forms.Label();
        _btnNetBatch = new System.Windows.Forms.Button();
        _btnNetBatch.Click += btnNetBatch_Click;
        _Panel7 = new System.Windows.Forms.Panel();
        _btnCreditReturn = new System.Windows.Forms.Button();
        _btnCreditReturn.Click += btnCreditReturn_Click;
        _lblPOSCreditReturnDollar = new System.Windows.Forms.Label();
        _lblPOSCreditReturnCount = new System.Windows.Forms.Label();
        _Panel4 = new System.Windows.Forms.Panel();
        _btnNonAdjusted = new System.Windows.Forms.Button();
        _btnNonAdjusted.Click += btnNonAdjusted_Click;
        _lblPOSNonAdjDollar = new System.Windows.Forms.Label();
        _lblPOSNonAdjCount = new System.Windows.Forms.Label();
        _Panel3 = new System.Windows.Forms.Panel();
        _lblPOSCreditPurchaseDollar = new System.Windows.Forms.Label();
        _lblPOSCreditPurchaseCount = new System.Windows.Forms.Label();
        _btnCreditPurchase = new System.Windows.Forms.Button();
        _btnCreditPurchase.Click += btnCreditPurchase_Click;
        _Panel5 = new System.Windows.Forms.Panel();
        _Panel2 = new System.Windows.Forms.Panel();
        _lblBatchCreditPurchaseCount = new System.Windows.Forms.Label();
        _lblBatchCreditPurchaseDollar = new System.Windows.Forms.Label();
        _Panel9 = new System.Windows.Forms.Panel();
        _lblBatchCreditReturnCount = new System.Windows.Forms.Label();
        _lblBatchCreditReturnDollar = new System.Windows.Forms.Label();
        _lblBatchSummary = new System.Windows.Forms.Label();
        _Panel10 = new System.Windows.Forms.Panel();
        _lblBatchNetCount = new System.Windows.Forms.Label();
        _lblBatchNetDollar = new System.Windows.Forms.Label();
        _Panel14 = new System.Windows.Forms.Panel();
        _Label29 = new System.Windows.Forms.Label();
        _Label30 = new System.Windows.Forms.Label();
        _pnlBatchPayments = new System.Windows.Forms.Panel();
        _pnlBatchPayments.Click += PaymentUserControl_Click;
        _NumberPadLarge1 = new DataSet_Builder.NumberPadLarge();
        _NumberPadLarge1.NumberEntered += NumberPad_EnteredHit;
        _Panel6 = new System.Windows.Forms.Panel();
        _btnPrintAuth = new System.Windows.Forms.Button();
        _btnPrintAuth.Click += btnPrintAuth_Click;
        _btnRefresh = new System.Windows.Forms.Button();
        _btnRefresh.Click += btnRefresh_Click;
        _btnExit = new System.Windows.Forms.Button();
        _btnExit.Click += btnExit_Click;
        _btnFinalize = new System.Windows.Forms.Button();
        _btnFinalize.Click += btnFinalize_Click;
        _btnSendAdjustments = new System.Windows.Forms.Button();
        _btnSendAdjustments.Click += btnSendAdjustments_Click;
        _pnlDeclined = new System.Windows.Forms.Panel();
        _Panel13 = new System.Windows.Forms.Panel();
        _lblNumberDeclined = new System.Windows.Forms.Label();
        _lblDollarDeclined = new System.Windows.Forms.Label();
        _btnDeclined = new System.Windows.Forms.Button();
        _btnDeclined.Click += btnDeclined_Click;
        _Panel12 = new System.Windows.Forms.Panel();
        _btnDailyNextPage = new System.Windows.Forms.Button();
        _btnDailyNextPage.Click += btnDailyNextPage_Click;
        _btnDailyPreviousPage = new System.Windows.Forms.Button();
        _btnDailyPreviousPage.Click += btnDailyPreviousPage_Click;
        _Panel1.SuspendLayout();
        _Panel11.SuspendLayout();
        _Panel8.SuspendLayout();
        _Panel7.SuspendLayout();
        _Panel4.SuspendLayout();
        _Panel3.SuspendLayout();
        _Panel5.SuspendLayout();
        _Panel2.SuspendLayout();
        _Panel9.SuspendLayout();
        _Panel10.SuspendLayout();
        _Panel14.SuspendLayout();
        _Panel6.SuspendLayout();
        _pnlDeclined.SuspendLayout();
        _Panel13.SuspendLayout();
        _Panel12.SuspendLayout();
        this.SuspendLayout();
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.Color.BlanchedAlmond;
        _Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        _Panel1.Controls.Add(_Panel11);
        _Panel1.Controls.Add(_Panel8);
        _Panel1.Controls.Add(_Panel7);
        _Panel1.Controls.Add(_Panel4);
        _Panel1.Controls.Add(_Panel3);
        _Panel1.Controls.Add(_Panel5);
        _Panel1.Location = new System.Drawing.Point(624, 40);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(360, 176);
        _Panel1.TabIndex = 0;
        // 
        // Panel11
        // 
        _Panel11.Controls.Add(_Label20);
        _Panel11.Controls.Add(_Label21);
        _Panel11.Location = new System.Drawing.Point(96, 8);
        _Panel11.Name = "_Panel11";
        _Panel11.Size = new System.Drawing.Size(120, 24);
        _Panel11.TabIndex = 5;
        // 
        // Label20
        // 
        _Label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label20.Location = new System.Drawing.Point(56, 0);
        _Label20.Name = "_Label20";
        _Label20.Size = new System.Drawing.Size(64, 24);
        _Label20.TabIndex = 1;
        _Label20.Text = "Dollar";
        _Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Label21
        // 
        _Label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label21.Location = new System.Drawing.Point(0, 0);
        _Label21.Name = "_Label21";
        _Label21.Size = new System.Drawing.Size(56, 24);
        _Label21.TabIndex = 0;
        _Label21.Text = "Count";
        _Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Panel8
        // 
        _Panel8.Controls.Add(_lblPOSNetDollar);
        _Panel8.Controls.Add(_lblPOSNetCount);
        _Panel8.Controls.Add(_btnNetBatch);
        _Panel8.Location = new System.Drawing.Point(8, 136);
        _Panel8.Name = "_Panel8";
        _Panel8.Size = new System.Drawing.Size(208, 32);
        _Panel8.TabIndex = 4;
        // 
        // lblPOSNetDollar
        // 
        _lblPOSNetDollar.Location = new System.Drawing.Point(136, 0);
        _lblPOSNetDollar.Name = "_lblPOSNetDollar";
        _lblPOSNetDollar.Size = new System.Drawing.Size(72, 24);
        _lblPOSNetDollar.TabIndex = 2;
        _lblPOSNetDollar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblPOSNetCount
        // 
        _lblPOSNetCount.Location = new System.Drawing.Point(96, 0);
        _lblPOSNetCount.Name = "_lblPOSNetCount";
        _lblPOSNetCount.Size = new System.Drawing.Size(32, 24);
        _lblPOSNetCount.TabIndex = 1;
        _lblPOSNetCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // btnNetBatch
        // 
        _btnNetBatch.Location = new System.Drawing.Point(0, 0);
        _btnNetBatch.Name = "_btnNetBatch";
        _btnNetBatch.Size = new System.Drawing.Size(88, 32);
        _btnNetBatch.TabIndex = 3;
        _btnNetBatch.Text = "Net Batch";
        // 
        // Panel7
        // 
        _Panel7.Controls.Add(_btnCreditReturn);
        _Panel7.Controls.Add(_lblPOSCreditReturnDollar);
        _Panel7.Controls.Add(_lblPOSCreditReturnCount);
        _Panel7.Location = new System.Drawing.Point(8, 104);
        _Panel7.Name = "_Panel7";
        _Panel7.Size = new System.Drawing.Size(208, 32);
        _Panel7.TabIndex = 3;
        // 
        // btnCreditReturn
        // 
        _btnCreditReturn.Location = new System.Drawing.Point(0, 0);
        _btnCreditReturn.Name = "_btnCreditReturn";
        _btnCreditReturn.Size = new System.Drawing.Size(88, 32);
        _btnCreditReturn.TabIndex = 3;
        _btnCreditReturn.Text = "Credit Return";
        // 
        // lblPOSCreditReturnDollar
        // 
        _lblPOSCreditReturnDollar.Location = new System.Drawing.Point(136, 0);
        _lblPOSCreditReturnDollar.Name = "_lblPOSCreditReturnDollar";
        _lblPOSCreditReturnDollar.Size = new System.Drawing.Size(72, 24);
        _lblPOSCreditReturnDollar.TabIndex = 2;
        _lblPOSCreditReturnDollar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblPOSCreditReturnCount
        // 
        _lblPOSCreditReturnCount.Location = new System.Drawing.Point(96, 0);
        _lblPOSCreditReturnCount.Name = "_lblPOSCreditReturnCount";
        _lblPOSCreditReturnCount.Size = new System.Drawing.Size(32, 24);
        _lblPOSCreditReturnCount.TabIndex = 1;
        _lblPOSCreditReturnCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Panel4
        // 
        _Panel4.Controls.Add(_btnNonAdjusted);
        _Panel4.Controls.Add(_lblPOSNonAdjDollar);
        _Panel4.Controls.Add(_lblPOSNonAdjCount);
        _Panel4.Location = new System.Drawing.Point(8, 40);
        _Panel4.Name = "_Panel4";
        _Panel4.Size = new System.Drawing.Size(208, 32);
        _Panel4.TabIndex = 1;
        // 
        // btnNonAdjusted
        // 
        _btnNonAdjusted.Location = new System.Drawing.Point(0, 0);
        _btnNonAdjusted.Name = "_btnNonAdjusted";
        _btnNonAdjusted.Size = new System.Drawing.Size(88, 32);
        _btnNonAdjusted.TabIndex = 3;
        _btnNonAdjusted.Text = "Non Adjusted";
        // 
        // lblPOSNonAdjDollar
        // 
        _lblPOSNonAdjDollar.Location = new System.Drawing.Point(136, 0);
        _lblPOSNonAdjDollar.Name = "_lblPOSNonAdjDollar";
        _lblPOSNonAdjDollar.Size = new System.Drawing.Size(72, 24);
        _lblPOSNonAdjDollar.TabIndex = 2;
        _lblPOSNonAdjDollar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblPOSNonAdjCount
        // 
        _lblPOSNonAdjCount.Location = new System.Drawing.Point(96, 0);
        _lblPOSNonAdjCount.Name = "_lblPOSNonAdjCount";
        _lblPOSNonAdjCount.Size = new System.Drawing.Size(32, 24);
        _lblPOSNonAdjCount.TabIndex = 1;
        _lblPOSNonAdjCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Panel3
        // 
        _Panel3.Controls.Add(_lblPOSCreditPurchaseDollar);
        _Panel3.Controls.Add(_lblPOSCreditPurchaseCount);
        _Panel3.Controls.Add(_btnCreditPurchase);
        _Panel3.Location = new System.Drawing.Point(8, 72);
        _Panel3.Name = "_Panel3";
        _Panel3.Size = new System.Drawing.Size(208, 32);
        _Panel3.TabIndex = 0;
        // 
        // lblPOSCreditPurchaseDollar
        // 
        _lblPOSCreditPurchaseDollar.Location = new System.Drawing.Point(136, 0);
        _lblPOSCreditPurchaseDollar.Name = "_lblPOSCreditPurchaseDollar";
        _lblPOSCreditPurchaseDollar.Size = new System.Drawing.Size(72, 24);
        _lblPOSCreditPurchaseDollar.TabIndex = 2;
        _lblPOSCreditPurchaseDollar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblPOSCreditPurchaseCount
        // 
        _lblPOSCreditPurchaseCount.Location = new System.Drawing.Point(96, 0);
        _lblPOSCreditPurchaseCount.Name = "_lblPOSCreditPurchaseCount";
        _lblPOSCreditPurchaseCount.Size = new System.Drawing.Size(32, 24);
        _lblPOSCreditPurchaseCount.TabIndex = 1;
        _lblPOSCreditPurchaseCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // btnCreditPurchase
        // 
        _btnCreditPurchase.Location = new System.Drawing.Point(0, 0);
        _btnCreditPurchase.Name = "_btnCreditPurchase";
        _btnCreditPurchase.Size = new System.Drawing.Size(88, 32);
        _btnCreditPurchase.TabIndex = 3;
        _btnCreditPurchase.Text = "Credit Purchase";
        // 
        // Panel5
        // 
        _Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        _Panel5.Controls.Add(_Panel2);
        _Panel5.Controls.Add(_Panel9);
        _Panel5.Controls.Add(_lblBatchSummary);
        _Panel5.Controls.Add(_Panel10);
        _Panel5.Controls.Add(_Panel14);
        _Panel5.Location = new System.Drawing.Point(224, 0);
        _Panel5.Name = "_Panel5";
        _Panel5.Size = new System.Drawing.Size(136, 176);
        _Panel5.TabIndex = 2;
        // 
        // Panel2
        // 
        _Panel2.Controls.Add(_lblBatchCreditPurchaseCount);
        _Panel2.Controls.Add(_lblBatchCreditPurchaseDollar);
        _Panel2.Location = new System.Drawing.Point(8, 72);
        _Panel2.Name = "_Panel2";
        _Panel2.Size = new System.Drawing.Size(120, 32);
        _Panel2.TabIndex = 5;
        // 
        // lblBatchCreditPurchaseCount
        // 
        _lblBatchCreditPurchaseCount.Location = new System.Drawing.Point(8, 0);
        _lblBatchCreditPurchaseCount.Name = "_lblBatchCreditPurchaseCount";
        _lblBatchCreditPurchaseCount.Size = new System.Drawing.Size(32, 24);
        _lblBatchCreditPurchaseCount.TabIndex = 0;
        _lblBatchCreditPurchaseCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblBatchCreditPurchaseDollar
        // 
        _lblBatchCreditPurchaseDollar.Location = new System.Drawing.Point(40, 0);
        _lblBatchCreditPurchaseDollar.Name = "_lblBatchCreditPurchaseDollar";
        _lblBatchCreditPurchaseDollar.Size = new System.Drawing.Size(80, 24);
        _lblBatchCreditPurchaseDollar.TabIndex = 1;
        _lblBatchCreditPurchaseDollar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Panel9
        // 
        _Panel9.Controls.Add(_lblBatchCreditReturnCount);
        _Panel9.Controls.Add(_lblBatchCreditReturnDollar);
        _Panel9.Location = new System.Drawing.Point(8, 104);
        _Panel9.Name = "_Panel9";
        _Panel9.Size = new System.Drawing.Size(120, 32);
        _Panel9.TabIndex = 2;
        // 
        // lblBatchCreditReturnCount
        // 
        _lblBatchCreditReturnCount.Location = new System.Drawing.Point(8, 0);
        _lblBatchCreditReturnCount.Name = "_lblBatchCreditReturnCount";
        _lblBatchCreditReturnCount.Size = new System.Drawing.Size(32, 24);
        _lblBatchCreditReturnCount.TabIndex = 0;
        _lblBatchCreditReturnCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblBatchCreditReturnDollar
        // 
        _lblBatchCreditReturnDollar.Location = new System.Drawing.Point(40, 0);
        _lblBatchCreditReturnDollar.Name = "_lblBatchCreditReturnDollar";
        _lblBatchCreditReturnDollar.Size = new System.Drawing.Size(80, 24);
        _lblBatchCreditReturnDollar.TabIndex = 1;
        _lblBatchCreditReturnDollar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblBatchSummary
        // 
        _lblBatchSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblBatchSummary.Location = new System.Drawing.Point(0, 8);
        _lblBatchSummary.Name = "_lblBatchSummary";
        _lblBatchSummary.Size = new System.Drawing.Size(136, 24);
        _lblBatchSummary.TabIndex = 0;
        _lblBatchSummary.Text = "Batch Summary";
        _lblBatchSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Panel10
        // 
        _Panel10.Controls.Add(_lblBatchNetCount);
        _Panel10.Controls.Add(_lblBatchNetDollar);
        _Panel10.Location = new System.Drawing.Point(8, 136);
        _Panel10.Name = "_Panel10";
        _Panel10.Size = new System.Drawing.Size(120, 32);
        _Panel10.TabIndex = 2;
        // 
        // lblBatchNetCount
        // 
        _lblBatchNetCount.Location = new System.Drawing.Point(8, 0);
        _lblBatchNetCount.Name = "_lblBatchNetCount";
        _lblBatchNetCount.Size = new System.Drawing.Size(32, 24);
        _lblBatchNetCount.TabIndex = 0;
        _lblBatchNetCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblBatchNetDollar
        // 
        _lblBatchNetDollar.Location = new System.Drawing.Point(40, 0);
        _lblBatchNetDollar.Name = "_lblBatchNetDollar";
        _lblBatchNetDollar.Size = new System.Drawing.Size(80, 24);
        _lblBatchNetDollar.TabIndex = 1;
        _lblBatchNetDollar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Panel14
        // 
        _Panel14.Controls.Add(_Label29);
        _Panel14.Controls.Add(_Label30);
        _Panel14.Location = new System.Drawing.Point(8, 40);
        _Panel14.Name = "_Panel14";
        _Panel14.Size = new System.Drawing.Size(120, 24);
        _Panel14.TabIndex = 4;
        // 
        // Label29
        // 
        _Label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label29.Location = new System.Drawing.Point(0, 0);
        _Label29.Name = "_Label29";
        _Label29.Size = new System.Drawing.Size(48, 24);
        _Label29.TabIndex = 0;
        _Label29.Text = "Count";
        _Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Label30
        // 
        _Label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label30.Location = new System.Drawing.Point(56, 0);
        _Label30.Name = "_Label30";
        _Label30.Size = new System.Drawing.Size(64, 24);
        _Label30.TabIndex = 1;
        _Label30.Text = "Dollar";
        _Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pnlBatchPayments
        // 
        _pnlBatchPayments.BackColor = System.Drawing.Color.Black;
        _pnlBatchPayments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        _pnlBatchPayments.Location = new System.Drawing.Point(3, 40);
        _pnlBatchPayments.Name = "_pnlBatchPayments";
        _pnlBatchPayments.Size = new System.Drawing.Size(456, 656);
        _pnlBatchPayments.TabIndex = 1;
        // 
        // NumberPadLarge1
        // 
        _NumberPadLarge1.BackColor = System.Drawing.Color.SlateGray;
        _NumberPadLarge1.DecimalUsed = true;
        _NumberPadLarge1.ForeColor = System.Drawing.Color.CornflowerBlue;
        _NumberPadLarge1.IntegerNumber = 0;
        _NumberPadLarge1.Location = new System.Drawing.Point(481, 326);
        _NumberPadLarge1.Name = "_NumberPadLarge1";
        _NumberPadLarge1.NumberString = "";
        _NumberPadLarge1.NumberTotal = new decimal(new int[] { 0, 0, 0, 0 });
        _NumberPadLarge1.Size = new System.Drawing.Size(240, 370);
        _NumberPadLarge1.TabIndex = 2;
        // 
        // Panel6
        // 
        _Panel6.BackColor = System.Drawing.Color.Black;
        _Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _Panel6.Controls.Add(_btnPrintAuth);
        _Panel6.Controls.Add(_btnRefresh);
        _Panel6.Controls.Add(_btnExit);
        _Panel6.Controls.Add(_btnFinalize);
        _Panel6.Controls.Add(_btnSendAdjustments);
        _Panel6.Location = new System.Drawing.Point(745, 456);
        _Panel6.Name = "_Panel6";
        _Panel6.Size = new System.Drawing.Size(240, 240);
        _Panel6.TabIndex = 3;
        // 
        // btnPrintAuth
        // 
        _btnPrintAuth.BackColor = System.Drawing.Color.BlanchedAlmond;
        _btnPrintAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnPrintAuth.Location = new System.Drawing.Point(8, 88);
        _btnPrintAuth.Name = "_btnPrintAuth";
        _btnPrintAuth.Size = new System.Drawing.Size(104, 56);
        _btnPrintAuth.TabIndex = 4;
        _btnPrintAuth.Text = "Print All Authorizations";
        _btnPrintAuth.UseVisualStyleBackColor = false;
        // 
        // btnRefresh
        // 
        _btnRefresh.BackColor = System.Drawing.Color.BlanchedAlmond;
        _btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnRefresh.Location = new System.Drawing.Point(24, 184);
        _btnRefresh.Name = "_btnRefresh";
        _btnRefresh.Size = new System.Drawing.Size(72, 40);
        _btnRefresh.TabIndex = 3;
        _btnRefresh.Text = "Refresh";
        _btnRefresh.UseVisualStyleBackColor = false;
        // 
        // btnExit
        // 
        _btnExit.BackColor = System.Drawing.Color.BlanchedAlmond;
        _btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnExit.Location = new System.Drawing.Point(144, 184);
        _btnExit.Name = "_btnExit";
        _btnExit.Size = new System.Drawing.Size(72, 40);
        _btnExit.TabIndex = 2;
        _btnExit.Text = "Exit";
        _btnExit.UseVisualStyleBackColor = false;
        // 
        // btnFinalize
        // 
        _btnFinalize.BackColor = System.Drawing.Color.BlanchedAlmond;
        _btnFinalize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnFinalize.Location = new System.Drawing.Point(128, 8);
        _btnFinalize.Name = "_btnFinalize";
        _btnFinalize.Size = new System.Drawing.Size(104, 64);
        _btnFinalize.TabIndex = 1;
        _btnFinalize.Text = "Finalize";
        _btnFinalize.UseVisualStyleBackColor = false;
        _btnFinalize.Visible = false;
        // 
        // btnSendAdjustments
        // 
        _btnSendAdjustments.BackColor = System.Drawing.Color.BlanchedAlmond;
        _btnSendAdjustments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnSendAdjustments.Location = new System.Drawing.Point(8, 8);
        _btnSendAdjustments.Name = "_btnSendAdjustments";
        _btnSendAdjustments.Size = new System.Drawing.Size(104, 64);
        _btnSendAdjustments.TabIndex = 0;
        _btnSendAdjustments.Text = "Close Batch";
        _btnSendAdjustments.UseVisualStyleBackColor = false;
        // 
        // pnlDeclined
        // 
        _pnlDeclined.BackColor = System.Drawing.Color.Black;
        _pnlDeclined.Controls.Add(_Panel13);
        _pnlDeclined.Controls.Add(_btnDeclined);
        _pnlDeclined.Location = new System.Drawing.Point(744, 232);
        _pnlDeclined.Name = "_pnlDeclined";
        _pnlDeclined.Size = new System.Drawing.Size(240, 48);
        _pnlDeclined.TabIndex = 4;
        _pnlDeclined.Visible = false;
        // 
        // Panel13
        // 
        _Panel13.BackColor = System.Drawing.Color.BlanchedAlmond;
        _Panel13.Controls.Add(_lblNumberDeclined);
        _Panel13.Controls.Add(_lblDollarDeclined);
        _Panel13.Location = new System.Drawing.Point(112, 8);
        _Panel13.Name = "_Panel13";
        _Panel13.Size = new System.Drawing.Size(120, 32);
        _Panel13.TabIndex = 7;
        // 
        // lblNumberDeclined
        // 
        _lblNumberDeclined.Location = new System.Drawing.Point(8, 0);
        _lblNumberDeclined.Name = "_lblNumberDeclined";
        _lblNumberDeclined.Size = new System.Drawing.Size(32, 24);
        _lblNumberDeclined.TabIndex = 0;
        _lblNumberDeclined.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblDollarDeclined
        // 
        _lblDollarDeclined.Location = new System.Drawing.Point(40, 0);
        _lblDollarDeclined.Name = "_lblDollarDeclined";
        _lblDollarDeclined.Size = new System.Drawing.Size(80, 24);
        _lblDollarDeclined.TabIndex = 1;
        _lblDollarDeclined.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // btnDeclined
        // 
        _btnDeclined.BackColor = System.Drawing.Color.BlanchedAlmond;
        _btnDeclined.Location = new System.Drawing.Point(8, 8);
        _btnDeclined.Name = "_btnDeclined";
        _btnDeclined.Size = new System.Drawing.Size(88, 32);
        _btnDeclined.TabIndex = 4;
        _btnDeclined.Text = "Declined";
        _btnDeclined.UseVisualStyleBackColor = false;
        // 
        // Panel12
        // 
        _Panel12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _Panel12.Controls.Add(_btnDailyNextPage);
        _Panel12.Controls.Add(_btnDailyPreviousPage);
        _Panel12.Location = new System.Drawing.Point(480, 40);
        _Panel12.Name = "_Panel12";
        _Panel12.Size = new System.Drawing.Size(120, 144);
        _Panel12.TabIndex = 5;
        // 
        // btnDailyNextPage
        // 
        _btnDailyNextPage.BackColor = System.Drawing.Color.BlanchedAlmond;
        _btnDailyNextPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnDailyNextPage.Location = new System.Drawing.Point(16, 80);
        _btnDailyNextPage.Name = "_btnDailyNextPage";
        _btnDailyNextPage.Size = new System.Drawing.Size(88, 48);
        _btnDailyNextPage.TabIndex = 1;
        _btnDailyNextPage.Text = "Next Page";
        _btnDailyNextPage.UseVisualStyleBackColor = false;
        // 
        // btnDailyPreviousPage
        // 
        _btnDailyPreviousPage.BackColor = System.Drawing.Color.BlanchedAlmond;
        _btnDailyPreviousPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnDailyPreviousPage.Location = new System.Drawing.Point(16, 16);
        _btnDailyPreviousPage.Name = "_btnDailyPreviousPage";
        _btnDailyPreviousPage.Size = new System.Drawing.Size(88, 48);
        _btnDailyPreviousPage.TabIndex = 0;
        _btnDailyPreviousPage.Text = "Previous Page";
        _btnDailyPreviousPage.UseVisualStyleBackColor = false;
        // 
        // BatchClose_UC
        // 
        this.BackColor = System.Drawing.Color.Black;
        this.BackgroundImage = (Global.System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
        this.Controls.Add(_Panel12);
        this.Controls.Add(_pnlDeclined);
        this.Controls.Add(_Panel6);
        this.Controls.Add(_NumberPadLarge1);
        this.Controls.Add(_pnlBatchPayments);
        this.Controls.Add(_Panel1);
        this.Name = "BatchClose_UC";
        this.Size = new System.Drawing.Size(1024, 786);
        _Panel1.ResumeLayout(false);
        _Panel11.ResumeLayout(false);
        _Panel8.ResumeLayout(false);
        _Panel7.ResumeLayout(false);
        _Panel4.ResumeLayout(false);
        _Panel3.ResumeLayout(false);
        _Panel5.ResumeLayout(false);
        _Panel2.ResumeLayout(false);
        _Panel9.ResumeLayout(false);
        _Panel10.ResumeLayout(false);
        _Panel14.ResumeLayout(false);
        _Panel6.ResumeLayout(false);
        _pnlDeclined.ResumeLayout(false);
        _Panel13.ResumeLayout(false);
        _Panel12.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion


    private void InitializeOther()
    {


        // this is testing, it auto closes if no batch to do and manual
        // ***   somehow it still does not exit program
        // If companyInfo.usingOtherCreditProcessor = True And dsOrder.Tables("PaymentsAndCredits").Rows.Count = 0 Then
        // GenerateOrderTables.StartDailyBusinessClose(actingManager.EmployeeID, BatchDailyCode)
        // dsOrder.Tables("QuickTickets").Rows.Clear()
        // RaiseEvent ExitBatchClose(BatchDailyCode)
        // Exit Sub
        // End If
        // *******
        // dsOrder.Tables("PaymentsAndCredits") is only non cash payments in BatchClose
        // paymentTypeID > 1

        if (companyInfo.processor == "Mercury")
        {
            dsi = new DSICLIENTXLib.DSICLientX();
        }

        paymentPanel = new DataSet_Builder.Payment_UC[dsOrder.Tables("PaymentsAndCredits").Rows.Count + 1];
        // FilterBatchDataview()

        CreateNewPaymentPanels();
        activePanelDisplay = "nonAdjusted";
        DisplayNonAdjustedPaymentPanels();
        GenerateOrderTables.CreatespiderPOSDirectory();
        PrintDetail();

    }



    private void ResetButonColorsPanelChoices()
    {

        btnNonAdjusted.BackColor = c12;
        btnNonAdjusted.ForeColor = c2;
        btnCreditPurchase.BackColor = c12;
        btnCreditPurchase.ForeColor = c2;
        btnCreditReturn.BackColor = c12;
        btnCreditReturn.ForeColor = c2;
        btnNetBatch.BackColor = c12;
        btnNetBatch.ForeColor = c2;

        startPaymentIndex = 0;

    }


    // below position starts at zero for formating
    // startPaymentIndex starts at zero and moves to 1 if panels adj 1 place

    private void DisplayNonAdjustedPaymentPanels()
    {
        int PnlNo = 1;
        int position = 0;
        int panelCount = 0; // naPanelIndex
        btnNonAdjusted.BackColor = c11;
        btnNonAdjusted.ForeColor = c3;

        pnlBatchPayments.Controls.Clear();
        // displayActive = "NonAdjusted"

        foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                // If not oRow("TransactionCode") Is DBNull.Value Then
                // we might need this
                // End If
                if (oRow("TransactionCode") == "VoiceAuth")
                {
                    if (panelCount >= naPanelIndex & panelCount < naPanelIndex + 10)
                    {
                        if (oRow("Tip") == 0)
                        {
                            if (position + 1 > startPaymentIndex)
                            {
                                {
                                    ref var withBlock = ref paymentPanel[PnlNo];
                                    withBlock.Location = new Point(0, withBlock.Height * position);
                                    withBlock.ReverseAlignment();
                                    pnlBatchPayments.Controls.Add(paymentPanel[PnlNo]);
                                }
                                position += 1;
                                if (position == startPaymentIndex + 8)
                                    break;
                            }
                        }
                    }
                    panelCount += 1;
                }
                else if (oRow("TransactionCode") == "PreAuth")
                {
                    if (panelCount >= naPanelIndex & panelCount < naPanelIndex + 10)
                    {
                        if (position + 1 > startPaymentIndex)
                        {
                            {
                                ref var withBlock1 = ref paymentPanel[PnlNo];
                                withBlock1.Location = new Point(0, withBlock1.Height * position);
                                withBlock1.ReverseAlignment();
                                pnlBatchPayments.Controls.Add(paymentPanel[PnlNo]);
                            }
                            position += 1;
                            if (position == startPaymentIndex + 10)
                                break;
                        }
                    }
                    panelCount += 1;
                }
                PnlNo += 1;
            }
        }

    }

    private void DisplayCreditPurchasePaymentPanels()
    {
        int PnlNo = 1;
        int position = 0; // cpPanelIndex
        var panelCount = default(int);
        btnCreditPurchase.BackColor = c11;
        btnCreditPurchase.ForeColor = c3;

        pnlBatchPayments.Controls.Clear();
        // displayActive = "CreditPurchase"

        foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("TransactionCode") == "VoiceAuth")
                {
                    if (panelCount >= cpPanelIndex & panelCount < cpPanelIndex + 10)
                    {
                        if (oRow("Tip") > 0)
                        {
                            if (position + 1 > startPaymentIndex)
                            {
                                {
                                    ref var withBlock = ref paymentPanel[PnlNo];
                                    withBlock.Location = new Point(0, withBlock.Height * position);
                                    withBlock.StandardAlignment();
                                    pnlBatchPayments.Controls.Add(paymentPanel[PnlNo]);
                                }
                                position += 1;
                                if (position == startPaymentIndex + 10)
                                    break;
                            }
                        }
                    }
                    panelCount += 1;
                }
                else if (oRow("TransactionCode") == "PreAuthCapture")
                {
                    if (panelCount >= cpPanelIndex & panelCount < cpPanelIndex + 10)
                    {
                        if (position + 1 > startPaymentIndex)
                        {
                            {
                                ref var withBlock1 = ref paymentPanel[PnlNo];
                                withBlock1.Location = new Point(0, withBlock1.Height * position);
                                pnlBatchPayments.Controls.Add(paymentPanel[PnlNo]);
                            }
                            position += 1;
                            if (position == startPaymentIndex + 10)
                                break;
                        }
                    }
                    panelCount += 1;
                }
                PnlNo += 1;
            }
        }

    }

    private void DisplayCreditReturnPaymentPanels()
    {
        int PnlNo = 1;
        int position = 0; // crPanelIndex
        int panelCount = 0;
        btnCreditReturn.BackColor = c11;
        btnCreditReturn.ForeColor = c3;

        pnlBatchPayments.Controls.Clear();
        // displayActive = "CreditRefund"

        foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {

                if (oRow("TransactionCode") == "Return")
                {
                    if (panelCount >= crPanelIndex & panelCount < crPanelIndex + 10)
                    {
                        if (position + 1 > startPaymentIndex)
                        {
                            {
                                ref var withBlock = ref paymentPanel[PnlNo];
                                withBlock.Location = new Point(0, withBlock.Height * position);
                                pnlBatchPayments.Controls.Add(paymentPanel[PnlNo]);
                            }
                            position += 1;
                            if (position == startPaymentIndex + 10)
                                break;
                        }
                    }
                    panelCount += 1;
                }
                PnlNo += 1;
            }
        }

    }

    private void DisplayNetBatchPanels()
    {
        int PnlNo = 1;
        int position = 0; // bdPanelIndex
        var panelCount = default(int);
        btnDeclined.BackColor = c11;
        btnDeclined.ForeColor = c3;

        pnlBatchPayments.Controls.Clear();
        // displayActive = "net"

        foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("BatchCleared") == false & oRow("TransactionCode") == "PreAuth")
                {
                    if (panelCount >= netPanelIndex & panelCount < netPanelIndex + 10)
                    {
                        if (position + 1 > startPaymentIndex)
                        {
                            {
                                ref var withBlock = ref paymentPanel[PnlNo];
                                withBlock.Location = new Point(0, withBlock.Height * position);
                                withBlock.MakeDeclineReasonVisible();
                                pnlBatchPayments.Controls.Add(paymentPanel[PnlNo]);
                            }
                            position += 1;
                            if (position == startPaymentIndex + 10)
                                break;
                        }
                    }
                    panelCount += 1;
                }
                PnlNo += 1;
            }
        }

    }

    private void DisplayBatchDeclines()
    {
        int PnlNo = 1;
        int position = 0; // bdPanelIndex
        var panelCount = default(int);
        btnDeclined.BackColor = c11;
        btnDeclined.ForeColor = c3;

        pnlBatchPayments.Controls.Clear();
        // displayActive = "CreditRefund"

        foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("BatchCleared") == false & oRow("TransactionCode") == "PreAuth")
                {
                    if (panelCount >= bdPanelIndex & panelCount < bdPanelIndex + 10)
                    {
                        if (position + 1 > startPaymentIndex)
                        {
                            {
                                ref var withBlock = ref paymentPanel[PnlNo];
                                withBlock.Location = new Point(0, withBlock.Height * position);
                                withBlock.MakeDeclineReasonVisible();
                                pnlBatchPayments.Controls.Add(paymentPanel[PnlNo]);
                            }
                            position += 1;
                            if (position == startPaymentIndex + 10)
                                break;
                        }
                    }
                    panelCount += 1;
                }
                PnlNo += 1;
            }
        }

    }

    private void CreateNewPaymentPanels()
    {
        int PnlNo = 1;
        int position;
        string empName;
        string truncAcctNum;

        try
        {
            foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)
            {
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {

                    empName = oRow("FirstName") + " " + oRow("LastName");
                    if (!(oRow("AccountNumber").Substring(0, 4) == "xxxx") & !(oRow("AccountNumber") == "Manual"))
                    {
                        truncAcctNum = TruncateAccountNumber(oRow("AccountNumber"));
                    }
                    else
                    {
                        truncAcctNum = oRow("AccountNumber");
                    }
                    paymentPanel[PnlNo] = new DataSet_Builder.Payment_UC("Batch", (object)null, oRow, PnlNo, empName, truncAcctNum, 0);
                    {
                        ref var withBlock = ref paymentPanel[PnlNo];
                        withBlock.BackColor = Color.DarkGray;
                        this.paymentPanel[PnlNo].ActivePanel += PaymentUserControl_Click;
                    }
                    PnlNo += 1;
                    if (oRow("TransactionCode") == "VoiceAuth")
                    {
                        notAllCash = true;
                        if (oRow("Tip") == 0)
                        {
                            posNonAdjCount += 1;
                            posNonAdjDollar += oRow("PaymentAmount");
                        }
                        else
                        {
                            posCreditPurchaseCount += 1;
                            posCreditPurchaseDollar += oRow("PaymentAmount");
                            posCreditPurchaseDollar += oRow("Tip");
                        }
                    }

                    else if (oRow("TransactionCode") == "PreAuth")
                    {
                        notAllCash = true;
                        posNonAdjCount += 1;
                        posNonAdjDollar += oRow("PaymentAmount");
                    }

                    else if (oRow("TransactionCode") == "PreAuthCapture")
                    {
                        notAllCash = true;
                        if (!object.ReferenceEquals(oRow("AuthCode"), DBNull.Value))
                        {
                            if (!(oRow("AuthCode") == "MERCXX"))
                            {
                                posCreditPurchaseCount += 1;
                                posCreditPurchaseDollar += oRow("PaymentAmount");
                                posCreditPurchaseDollar += oRow("Tip");
                            }
                        }
                    }

                    else if (oRow("TransactionCode") == "Return")
                    {
                        // ********************
                        // this is if returns are negative amounts in database
                        notAllCash = true;
                        posCreditReturnCount += 1;
                        posCreditReturnDollar += oRow("PaymentAmount");
                        // should not need for retrun .. posCreditPurchaseDollar += oRow("Tip")
                    }
                    if (!object.ReferenceEquals(oRow("AuthCode"), DBNull.Value))
                    {
                        if (!(oRow("AuthCode") == "MERCXX"))
                        {
                            posNetCount += 1;
                            posNetDollar += oRow("PaymentAmount");
                            posNetDollar += oRow("Tip");
                        }
                    }
                    else    // this is for returns and which do not have authcode yet
                    {
                        posNetCount += 1;
                        posNetDollar += oRow("PaymentAmount");
                        posNetDollar += oRow("Tip");
                    }

                }
            }
        }
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);

        }


        DisplayBatchTotalPanel();

    }



    private void PaymentUserControl_Click(object sender, EventArgs e)
    {
        DataSet_Builder.Payment_UC objButton;

        try
        {
            objButton = (DataSet_Builder.Payment_UC)sender;
        }
        catch (Exception ex)
        {
            return;
        }

        if (!(paymentRowIndex == objButton.ActiveIndex))
        {
            paymentRowIndex = objButton.ActiveIndex;
            ActiveThisPanel(objButton.ActiveIndex);
        }

    }

    private void ActiveThisPanel(int ai)
    {
        int index = 1;

        foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (index > startPaymentIndex)
                {
                    if (!(index == ai))
                    {
                        paymentPanel[index].BackColor = Color.DarkGray;
                        paymentPanel[index].IsActive = false;
                    }
                    else
                    {
                        // here index and paymentrowindex are the same
                        paymentPanel[index].BackColor = Color.WhiteSmoke;
                        paymentPanel[paymentRowIndex].CurrentState = DataSet_Builder.Payment_UC.PanelHit.TipPanel;
                        PaymentPanelActivated();
                        panelIndex = paymentPanel[paymentRowIndex].Location.Y / 72 + 1;

                        // the following is used for any adjustments to Tips 
                        if (oRow("TransactionCode") == "PreAuthCapture")
                        {
                            posTempTipForPreAuthCaptureAdjustment = oRow("Tip");
                        }
                        else
                        {
                            posTempTipForPreAuthCaptureAdjustment = 0m;
                        }

                    }
                }
                index += 1;
                // If index = (startPaymentIndex + 10) Then Exit For
            }
        }

    }

    private void PaymentPanelActivated()
    {

        // If paymentPanel(paymentRowIndex).CurrentState = DataSet_Builder.Payment_UC.PanelHit.TipPanel Then
        NumberPadLarge1.NumberTotal = paymentPanel[paymentRowIndex].TipAmount;
        NumberPadLarge1.ShowNumberString();
        NumberPadLarge1.Focus();
        NumberPadLarge1.IntegerNumber = 0;
        NumberPadLarge1.NumberString = (object)null;
        // End If


    }


    private void NumberPad_EnteredHit(object sender, EventArgs e)
    {

        if (paymentRowIndex == 0)
        {
            Interaction.MsgBox("Select a Panel to add Gratuity");
            return;
        }

        if (NumberPadLarge1.NumberTotal > dsOrder.Tables("PaymentsAndCredits").Rows(paymentRowIndex - 1)("PaymentAmount"))
        {
            if (Interaction.MsgBox("Gratuity Amount is greater than Purchase. Please Verify", MsgBoxStyle.OkCancel) == MsgBoxResult.Cancel)
            {
                return;
            }
        }

        if (dsOrder.Tables("PaymentsAndCredits").Rows(paymentRowIndex - 1)("TransactionCode") == "PreAuth")
        {
            if (dsOrder.Tables("PaymentsAndCredits").Rows(paymentRowIndex - 1)("Tip") > 0)
            {
                if (Interaction.MsgBox("Are you sure you want to adjust this Tip?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
                {
                    dsOrder.Tables("PaymentsAndCredits").Rows(paymentRowIndex - 1)("Tip") = NumberPadLarge1.NumberTotal;
                    dsOrder.Tables("PaymentsAndCredits").Rows(paymentRowIndex - 1)("TransactionCode") = "PreAuthCapture";
                    // do a count adjustment
                    posNonAdjCount -= 1;
                    posNonAdjDollar -= dsOrder.Tables("PaymentsAndCredits").Rows(paymentRowIndex - 1)("PaymentAmount");
                    if (!object.ReferenceEquals(dsOrder.Tables("PaymentsAndCredits").Rows(paymentRowIndex - 1)("AuthCode"), DBNull.Value))
                    {
                        if (!(dsOrder.Tables("PaymentsAndCredits").Rows(paymentRowIndex - 1)("AuthCode") == "MERCXX"))
                        {
                            posCreditPurchaseCount += 1;
                            posCreditPurchaseDollar += dsOrder.Tables("PaymentsAndCredits").Rows(paymentRowIndex - 1)("PaymentAmount");
                            posCreditPurchaseDollar += NumberPadLarge1.NumberTotal;
                            posNetDollar += NumberPadLarge1.NumberTotal;
                        }
                    }
                    paymentPanel[paymentRowIndex].UpdateTip(NumberPadLarge1.NumberTotal);
                    changesMadeToTips = true;
                }
            }
        }

        else if (dsOrder.Tables("PaymentsAndCredits").Rows(paymentRowIndex - 1)("TransactionCode") == "PreAuthCapture")
        {
            if (dsOrder.Tables("PaymentsAndCredits").Rows(paymentRowIndex - 1)("Tip") > 0)
            {
                if (Interaction.MsgBox("Are you sure you want to adjust this Tip?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
                {
                    dsOrder.Tables("PaymentsAndCredits").Rows(paymentRowIndex - 1)("Tip") = NumberPadLarge1.NumberTotal;
                    posCreditPurchaseDollar += NumberPadLarge1.NumberTotal - posTempTipForPreAuthCaptureAdjustment;
                    posNetDollar += NumberPadLarge1.NumberTotal - posTempTipForPreAuthCaptureAdjustment;
                    posTempTipForPreAuthCaptureAdjustment = 0m;
                    paymentPanel[paymentRowIndex].UpdateTip(NumberPadLarge1.NumberTotal);
                    changesMadeToTips = true;
                }
            }
        }

        else if (dsOrder.Tables("PaymentsAndCredits").Rows(paymentRowIndex - 1)("TransactionCode") == "VoiceAuth")
        {
            if (dsOrder.Tables("PaymentsAndCredits").Rows(paymentRowIndex - 1)("Tip") > 0)
            {
                if (Interaction.MsgBox("Are you sure you want to adjust this Tip?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
                {
                    dsOrder.Tables("PaymentsAndCredits").Rows(paymentRowIndex - 1)("Tip") = NumberPadLarge1.NumberTotal;
                    // If dsOrder.Tables("PaymentsAndCredits").Rows(paymentRowIndex - 1)("Tip") = 0 Then
                    posNonAdjCount -= 1;
                    posNonAdjDollar -= dsOrder.Tables("PaymentsAndCredits").Rows(paymentRowIndex - 1)("PaymentAmount");
                    posCreditPurchaseCount += 1;
                    posCreditPurchaseDollar += dsOrder.Tables("PaymentsAndCredits").Rows(paymentRowIndex - 1)("PaymentAmount");
                    posCreditPurchaseDollar += NumberPadLarge1.NumberTotal;
                    posNetDollar += NumberPadLarge1.NumberTotal;
                    // End If
                    paymentPanel[paymentRowIndex].UpdateTip(NumberPadLarge1.NumberTotal);
                    changesMadeToTips = true;
                }
            }
        }

        else if (dsOrder.Tables("PaymentsAndCredits").Rows(paymentRowIndex - 1)("TransactionCode") == "Return")
        {
            // we may not allow any adjustments

        }

        DisplayBatchTotalPanel();
        MoveToNextPanel();

        if (paymentRowIndex < dsOrder.Tables("PaymentsAndCredits").Rows.Count)
        {
            paymentRowIndex += 1;
            ActiveThisPanel(paymentRowIndex);
        }


    }

    private void MoveToNextPanel()
    {


        switch (activePanelDisplay ?? "")
        {
            case "nonAdjusted":
                {
                    if (panelIndex == 9)
                    {
                        // must move all panels up one space
                        // first check if there is another panel avail
                        startPaymentIndex += 1;
                        DisplayNonAdjustedPaymentPanels();
                        ActiveThisPanel(9);
                    }
                    else
                    {
                        panelIndex += 1;
                        ActiveThisPanel(panelIndex);
                    }

                    break;
                }

            case "creditPurchase":
                {
                    if (panelIndex == 9)
                    {
                        startPaymentIndex += 1;
                        DisplayCreditPurchasePaymentPanels();
                        ActiveThisPanel(9);
                    }
                    else
                    {
                        panelIndex += 1;
                        ActiveThisPanel(panelIndex);
                    }

                    break;
                }
            case "creditReturn":
                {
                    if (panelIndex == 9)
                    {
                        startPaymentIndex += 1;
                        DisplayCreditReturnPaymentPanels();
                        ActiveThisPanel(9);
                    }
                    else
                    {
                        panelIndex += 1;
                        ActiveThisPanel(panelIndex);
                    }

                    break;
                }
        }

    }

    private void DisplayBatchTotalPanel()
    {

        lblPOSNonAdjCount.Text = posNonAdjCount;
        lblPOSNonAdjDollar.Text = posNonAdjDollar;
        lblPOSCreditPurchaseCount.Text = posCreditPurchaseCount;
        lblPOSCreditPurchaseDollar.Text = posCreditPurchaseDollar;
        lblPOSCreditReturnCount.Text = posCreditReturnCount;
        lblPOSCreditReturnDollar.Text = posCreditReturnDollar;
        lblPOSNetCount.Text = posNetCount;
        lblPOSNetDollar.Text = posNetDollar;

    }


    private void btnNonAdjusted_Click(object sender, EventArgs e)
    {
        activePanelDisplay = "nonAdjusted";
        ResetButonColorsPanelChoices();
        DisplayNonAdjustedPaymentPanels();

    }

    private void btnCreditPurchase_Click(object sender, EventArgs e)
    {
        activePanelDisplay = "creditPurchase";
        ResetButonColorsPanelChoices();
        DisplayCreditPurchasePaymentPanels();

    }

    private void btnCreditReturn_Click(object sender, EventArgs e)
    {
        activePanelDisplay = "creditReturn";
        ResetButonColorsPanelChoices();
        DisplayCreditReturnPaymentPanels();

    }

    private void btnNetBatch_Click(object sender, EventArgs e)
    {
        activePanelDisplay = "net";
        ResetButonColorsPanelChoices();
        DisplayNetBatchPanels();

    }

    private void btnDeclined_Click(object sender, EventArgs e)
    {
        activePanelDisplay = "batchDecline";
        ResetButonColorsPanelChoices();
        DisplayBatchDeclines();

    }
    private void btnSendAdjustments_Click(object sender, EventArgs e)
    {

        if (notAllCash == false)
        {
            // this is all cash
            // GenerateOrderTables.UpdatePaymentsAndCreditsBatch()
            GenerateOrderTables.StartDailyBusinessClose(actingManager.EmployeeID, BatchDailyCode);
            // insert Batch is only inserting in Phoenix
            // NOT DOING NOW
            // not sure if this is neccessary
            // everything saved at Mercury or processor
            // GenerateOrderTables.InsertBatchInfo(batch, BatchDailyCode)
            // BeginningBatchClear()
            Interaction.MsgBox("Batch Closed Successfully."); // " & batch.batchNumber & "
            dsOrder.Tables("QuickTickets").Rows.Clear();
            ExitBatchClose?.Invoke(BatchDailyCode);
            return;
        }

        if (btnSendAdjustments.Text == "Resume Close")
        {

            if (companyInfo.processor == "Mercury")
            {
                SetupBatchSummary();
            }
            else if (companyInfo.processor == "PaywarePC")
            {
                StartBatchClosePayware();
            }
        }

        else if (posNonAdjCount + posCreditReturnCount > 0)
        {
            if (Interaction.MsgBox("There is still '" + posNonAdjCount + "' Non-Adjusted check(s). If you continue, all non-adjusted gratuities will be zero.", MsgBoxStyle.OkCancel) == MsgBoxResult.Cancel)
            {
                return;
            }
            else
            {
                // have to replace all PreAuth TransCode's with PreAuthCaptures
                // Dim oRow As DataRow
                // For Each oRow In dsOrder.Tables("PaymentsAndCredits").Rows
                // If Not oRow.RowState = DataRowState.Deleted And Not oRow.RowState = DataRowState.Detached Then
                // If oRow("TransactionCode") = "PreAuth" Then
                // oRow("TransactionCode") = "PreAuthCapture"
                // End If
                // End If
                // Next
            }

            SendBatchByRow();
        }
        else
        {
            SendBatchByRow();
            // SetupBatchSummary()



            // mpsTStream = New TStream
            // mpsAdmin = New AdminClass

            // mpsAdmin.MerchantID = companyInfo.merchantID
            // mpsAdmin.OperatorID = companyInfo.operatorID
            // mpsAdmin.TranCode = "BatchClear"
            // mpsAdmin.Memo = "spiderPOS " & companyInfo.VersionNumber

            // mpsTStream.Admin = mpsAdmin

            // Dim output As New StringWriter(New StringBuilder)
            // Dim s As New XmlSerializer(GetType(TStream))
            // s.Serialize(output, mpsTStream)

            // StartBatchClear(output.ToString)

        }

    }

    private void StartBatchClear(ref string XMLString)
    {

        string resp;
        string batchStatus;

        dsi.ServerIPConfig("x1.mercurypay.com;x2.mercurypay.com;b1.backuppay.com;b2.backuppay.com", 0);
        resp = dsi.ProcessTransaction(XMLString, 0, "", "");

        // *** not sure what we get as a response
        // Approved ... Success    ???

        sWriter1 = new StreamWriter(@"c:\Data Files\spiderPOS\sendBatchClear.txt");
        sWriter1.Write(XMLString);
        sWriter1.Close();

        sWriter1 = new StreamWriter(@"c:\Data Files\spiderPOS\BatchClear.txt");
        sWriter1.Write(resp);
        sWriter1.Close();

        batchStatus = Conversions.ToString(ParseBatchResponse(resp, false));


        // If batchStatus = "Success" Then
        // SendBatchByRow()
        // End If

    }


    private void SendBatchByRow()
    {

        // ******************************************
        // I don't think we are adjusting Gift Cards
        // ******************************************
        // this runs the routine to send each payment through one at a time
        // then marks for completion, and saves to db

        foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)      // dvBatchNotCaptured
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("BatchCleared") == false)
                {

                    if (oRow("TransactionCode") == "PreAuth")
                    {
                        oRow("TransactionCode") = "PreAuthCapture";
                    }
                    try
                    {
                        if (companyInfo.processor == "Mercury")
                        {
                            SetUpTransaction(ref oRow);
                        }
                        else if (companyInfo.processor == "PaywarePC")
                        {
                            if (oRow("Tip") > 0)
                            {
                                StartGratuityByRow(ref oRow);
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        Interaction.MsgBox(ex.Message);
                        Interaction.MsgBox("There was a problem Sending Invoice " + oRow("RefNum") + " Payment through to Processor.");
                        // oRow("TransactionCode") = "PreAuth"
                        isSomethingDeclined = true;
                    }
                }
            }
        }

        // GenerateOrderTables.UpdatePaymentsAndCreditsBatch()
        // perform batch summary automatically
        if (isSomethingDeclined == false)
        {
            if (companyInfo.processor == "Mercury")
            {
                SetupBatchSummary();
            }
            else if (companyInfo.processor == "PaywarePC")
            {
                // SetUpBatchSummaryPayware()
                StartBatchClosePayware();
            }
        }

        else
        {
            btnSendAdjustments.Text = "Resume Close";
            pnlDeclined.Visible = true;
            ResetButonColorsPanelChoices();
            DisplayBatchDeclines();

        }

    }

    private void SetUpBatchSummaryPayware()
    {




    }

    private void SetupBatchSummary()
    {

        mpsTStream = new TStream();
        mpsAdmin = new AdminClass();

        mpsAdmin.MerchantID = companyInfo.merchantID;
        mpsAdmin.OperatorID = companyInfo.operatorID;
        mpsAdmin.TranCode = "BatchSummary";
        mpsAdmin.Memo = "spiderPOS " + companyInfo.VersionNumber;

        mpsTStream.Admin = mpsAdmin;

        var output = new StringWriter(new StringBuilder());
        var s = new XmlSerializer(typeof(TStream));
        s.Serialize(output, mpsTStream);

        StartBatchSumary(ref output.ToString());

    }

    private void StartBatchSummaryPayware()
    {





    }

    private void StartBatchSumary(ref string XMLString)
    {

        string resp;
        string batchStatus;

        dsi.ServerIPConfig("x1.mercurypay.com;x2.mercurypay.com;b1.backuppay.com;b2.backuppay.com", 0);
        resp = dsi.ProcessTransaction(XMLString, 0, "", "");

        // *** not sure what we get as a response
        // Approved ... Success    ???

        sWriter1 = new StreamWriter(@"c:\Data Files\spiderPOS\sendBatchSummary.txt");
        sWriter1.Write(XMLString);
        sWriter1.Close();


        sWriter1 = new StreamWriter(@"c:\Data Files\spiderPOS\BatchSummary.txt");
        sWriter1.Write(resp);
        sWriter1.Close();

        batchStatus = Conversions.ToString(ParseBatchResponse(resp, false));

        if (batchStatus == "Success")
        {
            lblBatchSummary.Text = "Batch: " + batch.batchNumber;
            lblBatchNetCount.Text = batch.NetCount;
            lblBatchNetDollar.Text = batch.NetDollar;
            lblBatchCreditPurchaseCount.Text = batch.CreditPurchaseCount;
            lblBatchCreditPurchaseDollar.Text = batch.CreditPurchaseDollar;
            lblBatchCreditReturnCount.Text = batch.CreditReturnCount;
            lblBatchCreditReturnDollar.Text = batch.CreditReturnDollar;

        }

        if (posNetCount == batch.NetCount & posNetDollar == batch.NetDollar)
        {
            SetupBatchClose();
        }
        else
        {
            Interaction.MsgBox("There is a difference in Totals. Please verify.");
            btnFinalize.Visible = true;
            btnPrintAuth.Visible = true;
            // *** need to wait for user to Complete Batch Close
        }

    }

    private void btnFinalize_Click(object sender, EventArgs e)
    {
        // we have to wait until the user compares batch summary info

        SetupBatchClose();

    }

    private void btnPrintAuth_Click(object sender, EventArgs e)
    {

        PrintDetail();

    }

    private void PrintDetail()
    {
        var prt = new PrintHelper();
        prt.PrintAllAuthDuringBatch();
        printedDetail = true;



    }



    private void SetupBatchClose()
    {
        if (batch.batchNumber is null)
            return;


        mpsTStream = new TStream();
        mpsAdmin = new AdminClass();

        {
            ref var withBlock = ref mpsAdmin;
            withBlock.MerchantID = companyInfo.merchantID;
            withBlock.OperatorID = companyInfo.operatorID;
            withBlock.TranCode = "BatchClose";
            withBlock.Memo = "spiderPOS " + companyInfo.VersionNumber;
            withBlock.BatchNo = batch.batchNumber;
            withBlock.BatchItemCount = batch.NetCount.ToString;
            withBlock.NetBatchTotal = batch.NetDollar.ToString;
            withBlock.CreditPurchaseCount = batch.CreditPurchaseCount;
            withBlock.CreditPurchaseAmount = batch.CreditPurchaseDollar.ToString;
            withBlock.CreditReturnCount = batch.CreditReturnCount;
            withBlock.CreditReturnAmount = batch.CreditReturnDollar.ToString;
            withBlock.DebitPurchaseCount = batch.DebitPurchaseCount;
            withBlock.DebitPurchaseAmount = batch.DebitPurchaseDollar.ToString;
            withBlock.DebitReturnCount = batch.DebitReturnCount;
            withBlock.DebitReturnAmount = batch.DebitReturnDollar.ToString;

        }

        mpsTStream.Admin = mpsAdmin;

        var output = new StringWriter(new StringBuilder());
        var s = new XmlSerializer(typeof(TStream));
        s.Serialize(output, mpsTStream);

        StartBatchClose(ref output.ToString());

    }

    private void StartBatchClose(ref string XMLString)
    {

        DataRow oRow;
        string resp;
        string batchStatus;

        dsi.ServerIPConfig("x1.mercurypay.com;x2.mercurypay.com;b1.backuppay.com;b2.backuppay.com", 0);
        resp = dsi.ProcessTransaction(XMLString, 0, "", "");

        sWriter1 = new StreamWriter(@"c:\Data Files\spiderPOS\sendBatchClose.txt");
        sWriter1.Write(XMLString);
        sWriter1.Close();

        sWriter1 = new StreamWriter(@"c:\Data Files\spiderPOS\BatchClose.txt");
        sWriter1.Write(resp);
        sWriter1.Close();

        batchStatus = Conversions.ToString(ParseBatchResponse(resp, false));

        if (batchStatus == "Success")
        {
            CompleteBatchClose();
        }

    }

    private void CompleteBatchClose()
    {

        if (Conversions.ToInteger(batchCloseNumber) == batch.batchNumber)
        {
            if (batchCloseNetCount == batch.NetCount & batchCloseNetDollar == batch.NetDollar)
            {
                // this is a successful batch close
                // we need to save into Batch Table
                foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)
                {
                    if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                    {
                        // If oRow("PaymentFlag") Then        *** may have to add 
                        if (!(oRow("AccountNumber").Substring(0, 4) == "xxxx") & !(oRow("AccountNumber") == "Manual"))
                        {
                            oRow("AccountNumber") = TruncateAccountNumber(oRow("AccountNumber"));
                        }
                        else
                        {

                        }

                    }
                }
                GenerateOrderTables.UpdatePaymentsAndCreditsBatch();
                GenerateOrderTables.StartDailyBusinessClose(actingManager.EmployeeID, BatchDailyCode);
                // insert Batch is only inserting in Phoenix
                // NOT DOING NOW
                // not sure if this is neccessary
                // everything saved at Mercury or processor
                GenerateOrderTables.InsertBatchInfo(batch, BatchDailyCode);
                BeginningBatchClear();
                Interaction.MsgBox("Batch " + batch.batchNumber + " Closed Successfully.");
                dsOrder.Tables("QuickTickets").Rows.Clear();
                ExitBatchClose?.Invoke(BatchDailyCode);
            }

            else
            {
                Interaction.MsgBox("There is a difference in Batch Totals.");
                Interaction.MsgBox("Net Count: " + batch.NetCount + "         Net Dollar: " + batch.NetDollar);

                // ***************
                // ***************
                // ***************
                // *** don't know what to do 

            }
        }
    }
    private void StartBatchClosePayware()
    {

        string batchStatus;
        PaywarePCCharge = new SIM.Charge();

        GenerateOrderTables.ReadyToProcessPaywarePC(PaywarePCCharge);

        {
            var withBlock = PaywarePCCharge;

            withBlock.Action = SIM.Charge.Command.Batch_Credit_Settle;

            if (withBlock.Process)
            {

                // MsgBox(.GetXMLResponse)
                // MsgBox(.GetSettlementDetails)
                // MsgBox(.GetTermStatus)
                // MsgBox(.GetBatchTraceID)
                // MsgBox(.GetResultCode)
                // MsgBox(.GetTransSeqNum)

                try
                {
                    batchStatus = Conversions.ToString(ParseBatchResponsePayware(withBlock.GetXMLResponse));

                    if (batchStatus == "Success") // "SUCCESS" Then '.GetBatchResult = "SETTLED" Then
                    {
                        Interaction.MsgBox("Batch '" + batchCloseNumber + "' " + batchStatus);
                        batch.batchNumber = batchCloseNumber;
                        BatchSettledPayware();
                    }

                    else
                    {
                        Interaction.MsgBox("Batch '" + batchCloseNumber + "' " + batchStatus);
                    }
                }

                catch (Exception ex)
                {

                }
            }

            // MsgBox(.GetResult)
            // MsgBox(.GetAuthCode)
            // MsgBox(.GetReference)
            // MsgBox(.GetResultCode)
            // MsgBox(.GetTroutD)
            // MsgBox(.GetResponseText)

            else
            {
                Interaction.MsgBox("" + withBlock.ErrorCode + ": " + withBlock.ErrorDescription);
            }
        }

    }

    private void BatchSettledPayware()
    {

        // If Me.batchCloseNetCount = batch.NetCount And Me.batchCloseNetDollar = batch.NetDollar Then
        // this is a successful batch close
        // we need to save into Batch Table
        foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                // If oRow("PaymentFlag") Then        *** may have to add 
                if (!(oRow("AccountNumber").Substring(0, 4) == "xxxx") & !(oRow("AccountNumber") == "Manual"))
                {
                    oRow("AccountNumber") = TruncateAccountNumber(oRow("AccountNumber"));
                }
                else
                {
                }

            }
        }
        GenerateOrderTables.UpdatePaymentsAndCreditsBatch();
        GenerateOrderTables.StartDailyBusinessClose(actingManager.EmployeeID, BatchDailyCode);
        // insert Batch is only inserting in Phoenix
        // NOT DOING NOW
        // not sure if this is neccessary
        // everything saved at Mercury or processor
        GenerateOrderTables.InsertBatchInfo(batch, BatchDailyCode);
        if (companyInfo.processor == "Mercury")
        {
            BeginningBatchClear();
        }
        Interaction.MsgBox("Batch " + batch.batchNumber + " Closed Successfully.");
        dsOrder.Tables("QuickTickets").Rows.Clear();
        ExitBatchClose?.Invoke(BatchDailyCode);

        // Else
        // MsgBox("There is a difference in Batch Totals.")
        // MsgBox("Net Count: " & batch.NetCount & "         Net Dollar: " & batch.NetDollar)

        // ***************
        // ***************
        // ***************
        // *** don't know what to do 

        // End If

    }

    private void BeginningBatchClear()
    {

        if (companyInfo.processor == "Mercury")
        {
        }
        // maybe here is where we need to set
        // oRow("BatchCleared") = True
        else if (companyInfo.processor == "PaywarePC")
        {

        }

        mpsTStream = new TStream();
        mpsAdmin = new AdminClass();

        mpsAdmin.MerchantID = companyInfo.merchantID;
        mpsAdmin.OperatorID = companyInfo.operatorID;
        mpsAdmin.TranCode = "BatchClear";
        mpsAdmin.Memo = "spiderPOS " + companyInfo.VersionNumber;

        mpsTStream.Admin = mpsAdmin;

        var output = new StringWriter(new StringBuilder());
        var s = new XmlSerializer(typeof(TStream));
        s.Serialize(output, mpsTStream);

        StartBatchClear(ref output.ToString());



    }
    private void SetUpTransaction(ref DataRow oRow)
    {

        mpsTStream = new TStream();
        mpsTransaction = new PreAuthTransactionClass();
        mpsAmount = new PreAuthAmountClass();
        mpsAccount = new AccountClass();
        mpsTransInfo = new TranInfoClass();

        // With oRow
        mpsTransaction.MerchantID = companyInfo.merchantID;
        mpsTransaction.OperatorID = companyInfo.operatorID;
        mpsTransaction.TranType = oRow("TransactionType");
        if (oRow("Duplicate") == true)
        {
            // mpsTransaction.Duplicate = "Override"
        }
        mpsTransaction.TranCode = oRow("TransactionCode");
        mpsTransaction.InvoiceNo = oRow("RefNum");
        mpsTransaction.RefNo = oRow("RefNum");
        mpsTransaction.Memo = "spiderPOS " + companyInfo.VersionNumber;

        mpsAccount.AcctNo = oRow("AccountNumber");
        mpsAccount.ExpDate = oRow("CCExpiration");

        if (mpsTransaction.TranCode == "Return")
        {
            mpsAmount.Purchase = -1 * oRow("PaymentAmount");
        }
        else if (mpsTransaction.TranCode == "VoiceAuth")
        {
            mpsAmount.Purchase = oRow("PaymentAmount");
            mpsTransInfo.AuthCode = oRow("AuthCode");
        }
        else if (mpsTransaction.TranCode == "PreAuthCapture")
        {
            mpsAmount.Purchase = oRow("PaymentAmount");
            mpsAmount.Gratuity = Strings.Format(oRow("Tip"), "####0.00");
            mpsAmount.Authorize = oRow("PreAuthAmount");
            mpsTransInfo.AuthCode = oRow("AuthCode");
            if (!object.ReferenceEquals(oRow("AcqRefData"), DBNull.Value))
            {
                mpsTransInfo.AcqRefData = oRow("AcqRefData");
            }
        }

        // End With
        // *****************
        // for testing only
        // mpsAccount.AcctNo = "5499990123456781"
        // mpsAccount.ExpDate = "0809"
        // mpsAccount.Track2 = Nothing
        // end testing
        // *****************


        mpsTransaction.Account = mpsAccount;
        mpsTransaction.Amount = mpsAmount;
        if (mpsTransaction.TranCode == "PreAuthCapture" | mpsTransaction.TranCode == "VoiceAuth")
        {
            mpsTransaction.TranInfo = mpsTransInfo;
        }

        mpsTStream.Transaction = mpsTransaction;


        var output = new StringWriter(new StringBuilder());
        var s = new XmlSerializer(typeof(TStream));
        s.Serialize(output, mpsTStream);

        StartTransaction(ref output.ToString(), ref oRow);

    }

    private void StartTransaction(ref string XMLString, ref DataRow oRow)
    {

        string resp;
        string authStatus;

        dsi.ServerIPConfig("x1.mercurypay.com;x2.mercurypay.com;b1.backuppay.com;b2.backuppay.com", 0);
        resp = dsi.ProcessTransaction(XMLString, 0, "", "");

        // just for testing 
        if (oRow("TransactionCode") == "Return")
        {
        }
        // sWriter1 = New StreamWriter("c:\Data Files\spiderPOS\sendReturn.txt")
        // sWriter1.Write(XMLString)
        // sWriter1.Close()
        else if (oRow("TransactionCode") == "VoiceAuth")
        {
        }
        // sWriter1 = New StreamWriter("c:\Data Files\spiderPOS\sendVoiceAuth.txt")
        // sWriter1.Write(XMLString)
        // sWriter1.Close()
        else if (oRow("TransactionCode") == "PreAuthCapture")
        {
            if (oRow("Duplicate") == true)
            {
            }
            // sWriter1 = New StreamWriter("c:\Data Files\spiderPOS\sendDuplicateCapture.txt")
            // sWriter1.Write(XMLString)
            // sWriter1.Close()
            else
            {
                // sWriter1 = New StreamWriter("c:\Data Files\spiderPOS\sendPreAuthCapture.txt")
                // sWriter1.Write(XMLString)
                // sWriter1.Close()
            }

        }

        // sWriter1 = New StreamWriter("c:\Data Files\spiderPOS\BatchTransactionResponse.txt")
        // sWriter1.Write(resp)
        // sWriter1.Close()
        // MsgBox(resp)

        // *** not sure what we get as a response
        // Approved ... Success    ???
        authStatus = Conversions.ToString(ParseTransactions(resp, true, ref oRow));

        if (authStatus == "Approved")     // maybe Success
        {
            // oRow("AccountNumber") = TruncateAccountNumber(oRow("AccountNumber"))
            oRow("BatchCleared") = true;
            if (oRow("TransactionCode") == "PreAuth")
            {
                oRow("TransactionCode") = "PreAuthCapture";
            }
        }
        else
        {
            isSomethingDeclined = true;

        }

    }

    private object ParseTransactions(string resp, bool isForCapture, ref DataRow oRow)
    {

        var reader = new XmlTextReader(new StringReader(resp));
        var someError = default(bool);
        bool isSuccess;
        var batchStatus = default(string);

        try
        {
            while (reader.EOF != true)
            {
                reader.Read();
                reader.MoveToContent();
                if (reader.NodeType == XmlNodeType.Element)
                {
                    // MsgBox(reader.Name)
                    bool exitDo = false;
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

                                break;
                            }
                        // MsgBox(reader.ReadInnerXml, , "OperatorID")
                        case "CmdStatus":
                            {
                                switch (reader.ReadInnerXml() ?? "")
                                {
                                    case "Approved":
                                        {
                                            batchStatus = "Approved";
                                            break;
                                        }

                                    case "Success":
                                        {
                                            isSuccess = true;
                                            batchStatus = "Success";
                                            break;
                                        }
                                    // MsgBox(reader.ReadInnerXml)
                                    case "Declined":
                                        {
                                            batchStatus = "Declined";
                                            break;
                                        }

                                    case "Error":
                                        {
                                            // MsgBox(reader.ReadInnerXml)
                                            batchStatus = "Error";
                                            break;
                                        }

                                }
                                if (isForCapture == true)
                                {
                                    exitDo = true;
                                    break;
                                }

                                break;
                            }

                        case "TextResponse":
                            {
                                if (someError == true)
                                {
                                    oRow("Description") = reader.ReadInnerXml();
                                    if (reader.ReadInnerXml() == "AP DUPE")
                                    {
                                        oRow("Duplicate") = true;
                                    }
                                    else if (reader.ReadInnerXml() == "NO DUP FOUND")
                                    {
                                        oRow("Duplicate") = false;
                                    }
                                    return default;
                                }

                                else if (batchStatus == "Declined")
                                {

                                    oRow("Description") = reader.ReadInnerXml();
                                    return default;
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
                    }

                    if (exitDo)
                    {
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

        return batchStatus;

    }

    private void StartGratuityByRow(ref DataRow oRow)
    {

        PaywarePCCharge = new SIM.Charge();

        GenerateOrderTables.ReadyToProcessPaywarePC(PaywarePCCharge);

        {
            var withBlock = PaywarePCCharge;

            withBlock.GratuityAmount = Strings.Format(oRow("Tip"), "#####0.00").ToString;
            withBlock.TroutD = oRow("RefNum");
            withBlock.Action = SIM.Charge.Command.Credit_Add_Tip;

            if (withBlock.Process)
            {
                try
                {
                    // If .GetResult = "CAPTURED" Or .GetResultCode = "4" Then
                    if (withBlock.GetResult == "TIP MODIFIED" | withBlock.GetResultCode == "17")
                    {
                        // above is the same
                        // 444         oRow("TransactionCode") = "PreAuthCapture"
                        oRow("BatchCleared") = true; // we amy need to set to true after Batch settled??
                    }

                    else // If .GetResult = "DECLINED" Or .GetResultCode = "6" Then
                    {
                        Interaction.MsgBox("CARD '" + oRow("AccountNumber") + "' " + withBlock.GetResult + ": " + withBlock.GetResponseText);
                        // MsgBox("CARD '" & vRow("AccountNumber") & "' DECLINED: " & .GetResponseText)
                    }
                }

                catch (Exception ex)
                {

                }
            }

            // MsgBox(.GetResult)
            // MsgBox(.GetAuthCode)
            // MsgBox(.GetReference)
            // MsgBox(.GetResultCode)
            // MsgBox(.GetTroutD)
            // MsgBox(.GetResponseText)

            else
            {
                Interaction.MsgBox("" + withBlock.ErrorCode + ": " + withBlock.ErrorDescription);
            }
        }
    }

    private object ParseBatchResponsePayware(string resp) // , ByVal isForCapture As Boolean)
    {

        var reader = new XmlTextReader(new StringReader(resp));
        bool someError;
        bool isSuccess;
        var batchStatus = default(string);
        var isBatchSummary = default(bool);
        var isBatchClose = default(bool);


        try
        {
            while (reader.EOF != true)
            {
                reader.Read();
                reader.MoveToContent();
                if (reader.NodeType == XmlNodeType.Element)
                {
                    // MsgBox(reader.Name)
                    switch (reader.Name ?? "")
                    {

                        case "TERMINATION_STATUS":
                            {
                                switch (reader.ReadInnerXml() ?? "")
                                {

                                    case "SUCCESS":
                                        {
                                            isSuccess = true;
                                            batchStatus = "Success";
                                            break;
                                        }

                                    case "ERROR":
                                        {
                                            batchStatus = "Error";
                                            break;
                                        }


                                }

                                break;
                            }
                        // If isForCapture = True Then Exit Do

                        case "BATCH_SEQ_NUM":
                            {

                                if (isBatchSummary == true)
                                {
                                    batch.batchNumber = reader.ReadInnerXml();
                                }
                                else if (isBatchClose == true)
                                {
                                    batchCloseNumber = reader.ReadInnerXml();
                                }

                                break;
                            }

                        case "BATCH_COUNT":
                            {
                                if (isBatchSummary == true)
                                {
                                    batch.NetCount = reader.ReadInnerXml();
                                }
                                else if (isBatchClose == true)
                                {
                                    batchCloseNetCount = Conversions.ToInteger(reader.ReadInnerXml());
                                }

                                break;
                            }

                        case "BATCH_BALANCE":
                            {
                                if (isBatchSummary == true)
                                {
                                    batch.NetDollar = reader.ReadInnerXml();
                                }
                                else if (isBatchClose == true)
                                {
                                    batchCloseNetDollar = Conversions.ToDecimal(reader.ReadInnerXml());
                                }

                                break;
                            }

                        case "CreditPurchaseCount":
                            {
                                if (isBatchSummary == true)
                                {
                                    batch.CreditPurchaseCount = reader.ReadInnerXml();
                                    // MsgBox(batch.CreditPurchaseCount)
                                }

                                break;
                            }


                        case "CreditPurchaseAmount":
                            {
                                if (isBatchSummary == true)
                                {
                                    batch.CreditPurchaseDollar = reader.ReadInnerXml();
                                }

                                break;
                            }

                        case "CreditReturnCount":
                            {
                                if (isBatchSummary == true)
                                {
                                    batch.CreditReturnCount = reader.ReadInnerXml();
                                }

                                break;
                            }

                        case "CreditReturnAmount":
                            {
                                if (isBatchSummary == true)
                                {
                                    batch.CreditReturnDollar = reader.ReadInnerXml();
                                }

                                break;
                            }


                        case "DebitPurchaseCount":
                            {
                                if (isBatchSummary == true)
                                {
                                    batch.DebitPurchaseCount = reader.ReadInnerXml();
                                }

                                break;
                            }

                        case "DebitPurchaseAmount":
                            {
                                if (isBatchSummary == true)
                                {
                                    batch.DebitPurchaseDollar = reader.ReadInnerXml();
                                }

                                break;
                            }

                        case "DebitReturnCount":
                            {
                                if (isBatchSummary == true)
                                {
                                    batch.DebitReturnCount = reader.ReadInnerXml();
                                }

                                break;
                            }

                        case "DebitReturnAmount":
                            {
                                if (isBatchSummary == true)
                                {
                                    batch.DebitReturnDollar = reader.ReadInnerXml();
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

        return batchStatus;

    }

    private object ParseBatchResponse(string resp, bool isForCapture)
    {

        var reader = new XmlTextReader(new StringReader(resp));
        var someError = default(bool);
        var isSuccess = default(bool);
        var batchStatus = default(string);
        var isBatchSummary = default(bool);
        var isBatchClose = default(bool);


        try
        {
            while (reader.EOF != true)
            {
                reader.Read();
                reader.MoveToContent();
                if (reader.NodeType == XmlNodeType.Element)
                {
                    // MsgBox(reader.Name)
                    bool exitDo = false;
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

                                break;
                            }
                        // MsgBox(reader.ReadInnerXml, , "OperatorID")
                        case "CmdStatus":
                            {
                                switch (reader.ReadInnerXml() ?? "")
                                {
                                    case "Approved":
                                        {
                                            batchStatus = "Approved";
                                            break;
                                        }

                                    case "Success":
                                        {
                                            isSuccess = true;
                                            batchStatus = "Success";
                                            break;
                                        }
                                    // MsgBox(reader.ReadInnerXml)
                                    case "Declined":
                                        {
                                            batchStatus = "Declined";
                                            break;
                                        }

                                    case "Error":
                                        {
                                            // MsgBox(reader.ReadInnerXml)
                                            batchStatus = "Error";
                                            break;
                                        }

                                }
                                if (isForCapture == true)
                                {
                                    exitDo = true;
                                    break;
                                }

                                break;
                            }

                        case "TextResponse":
                            {
                                if (someError == true)
                                {
                                    Interaction.MsgBox(reader.ReadInnerXml());
                                    return default;
                                }
                                else if (batchStatus == "Declined")
                                {
                                    Interaction.MsgBox(reader.ReadInnerXml());
                                    return default;
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

                        case "BatchSummary":
                            {
                                if (isSuccess == true)
                                {
                                    isBatchSummary = true;
                                }

                                break;
                            }

                        case "BatchClose":
                            {
                                if (isSuccess == true)
                                {
                                    isBatchClose = true;
                                }

                                break;
                            }

                        case "BatchNo":
                            {

                                if (isBatchSummary == true)
                                {
                                    batch.batchNumber = reader.ReadInnerXml();
                                }
                                else if (isBatchClose == true)
                                {
                                    batchCloseNumber = reader.ReadInnerXml();
                                }

                                break;
                            }

                        case "BatchItemCount":
                            {
                                if (isBatchSummary == true)
                                {
                                    batch.NetCount = reader.ReadInnerXml();
                                }
                                else if (isBatchClose == true)
                                {
                                    batchCloseNetCount = Conversions.ToInteger(reader.ReadInnerXml());
                                }

                                break;
                            }

                        case "NetBatchTotal":
                            {
                                if (isBatchSummary == true)
                                {
                                    batch.NetDollar = reader.ReadInnerXml();
                                }
                                else if (isBatchClose == true)
                                {
                                    batchCloseNetDollar = Conversions.ToDecimal(reader.ReadInnerXml());
                                }

                                break;
                            }

                        case "CreditPurchaseCount":
                            {
                                if (isBatchSummary == true)
                                {
                                    batch.CreditPurchaseCount = reader.ReadInnerXml();
                                    // MsgBox(batch.CreditPurchaseCount)
                                }

                                break;
                            }


                        case "CreditPurchaseAmount":
                            {
                                if (isBatchSummary == true)
                                {
                                    batch.CreditPurchaseDollar = reader.ReadInnerXml();
                                }

                                break;
                            }

                        case "CreditReturnCount":
                            {
                                if (isBatchSummary == true)
                                {
                                    batch.CreditReturnCount = reader.ReadInnerXml();
                                }

                                break;
                            }

                        case "CreditReturnAmount":
                            {
                                if (isBatchSummary == true)
                                {
                                    batch.CreditReturnDollar = reader.ReadInnerXml();
                                }

                                break;
                            }


                        case "DebitPurchaseCount":
                            {
                                if (isBatchSummary == true)
                                {
                                    batch.DebitPurchaseCount = reader.ReadInnerXml();
                                }

                                break;
                            }

                        case "DebitPurchaseAmount":
                            {
                                if (isBatchSummary == true)
                                {
                                    batch.DebitPurchaseDollar = reader.ReadInnerXml();
                                }

                                break;
                            }

                        case "DebitReturnCount":
                            {
                                if (isBatchSummary == true)
                                {
                                    batch.DebitReturnCount = reader.ReadInnerXml();
                                }

                                break;
                            }

                        case "DebitReturnAmount":
                            {
                                if (isBatchSummary == true)
                                {
                                    batch.DebitReturnDollar = reader.ReadInnerXml();
                                }

                                break;
                            }
                    }

                    if (exitDo)
                    {
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

        return batchStatus;

    }


    private void btnExit_Click(object sender, EventArgs e)
    {
        if (changesMadeToTips == true)
        {
            GenerateOrderTables.UpdatePaymentsAndCreditsBatch();
        }

        ExitWithoutClose?.Invoke();

    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {

        foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)      // dvBatchNotCaptured
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("BatchCleared") == true)
                {
                    oRow("BatchCleared") = false;
                }
            }
        }
        btnSendAdjustments.Text = "Close Batch";
        isSomethingDeclined = false;
        changesMadeToTips = true; // this is so we save any changes upon exit
        ResetButonColorsPanelChoices();
        DisplayCreditPurchasePaymentPanels();

    }





    private void FilterBatchDataview222()
    {

        dvBatchPreAuth = new DataView();
        dvBatchPreAuthCapture = new DataView();
        dvBatchVoiceAuth = new DataView();
        dvBatchReturn = new DataView();

        {
            var withBlock = dvBatchVoiceAuth;
            withBlock.Table = dsOrder.Tables("PaymentsAndCredits");
            withBlock.RowFilter = "TransactionCode = 'VoiceAuth'";
            // .Sort = "TransactionCode, AuthCode ASC"
        }

        {
            var withBlock1 = dvBatchPreAuth;
            withBlock1.Table = dsOrder.Tables("PaymentsAndCredits");
            withBlock1.RowFilter = "TransactionCode = 'PreAuth'";
            // .Sort = "TransactionCode, AuthCode ASC"
        }

        {
            var withBlock2 = dvBatchPreAuthCapture;
            withBlock2.Table = dsOrder.Tables("PaymentsAndCredits");
            withBlock2.RowFilter = "TransactionCode = 'PreAuthCapture'";
            // .Sort = "TransactionCode, AuthCode ASC"
        }

        {
            var withBlock3 = dvBatchReturn;
            withBlock3.Table = dsOrder.Tables("PaymentsAndCredits");
            withBlock3.RowFilter = "TransactionCode = 'Return'";
            // .Sort = "TransactionCode, AuthCode ASC"
        }



    }


    private void CreateNewPaymentPanels222()
    {
        // this is only done once

        DataRowView vRow;
        int PnlNo = 1;
        int position;
        string empName;
        string truncAcctNum;
        pnlBatchPayments.Controls.Clear();



        foreach (DataRowView currentVRow in dvBatchVoiceAuth)
        {
            vRow = currentVRow;
            empName = vRow("FirstName") + " " + vRow("LastName");
            if (!(vRow("AccountNumber").Substring(0, 4) == "xxxx") & !(vRow("AccountNumber") == "Manual"))
            {
                truncAcctNum = TruncateAccountNumber(vRow("AccountNumber"));
            }
            else
            {
                truncAcctNum = vRow("AccountNumber");
            }
            paymentPanel[PnlNo] = new DataSet_Builder.Payment_UC("Batch", vRow, (object)null, PnlNo, empName, truncAcctNum, 0);
            {
                ref var withBlock = ref paymentPanel[PnlNo];
                withBlock.BackColor = Color.DarkGray;

                this.paymentPanel[PnlNo].ActivePanel += PaymentUserControl_Click;
            }
            PnlNo += 1;
        }

        if (dvBatchVoiceAuth.Count > 0)
        {
            startVoiceIndex = 1;
        }
        else
        {
            startVoiceIndex = 0;
        }
        endVoiceIndex = dvBatchVoiceAuth.Count;


        foreach (DataRowView currentVRow1 in dvBatchPreAuth)
        {
            vRow = currentVRow1;
            empName = vRow("FirstName") + " " + vRow("LastName");
            if (!(vRow("AccountNumber").Substring(0, 4) == "xxxx") & !(vRow("AccountNumber") == "Manual"))
            {
                truncAcctNum = TruncateAccountNumber(vRow("AccountNumber"));
            }
            else
            {
                truncAcctNum = vRow("AccountNumber");
            }
            paymentPanel[PnlNo] = new DataSet_Builder.Payment_UC("Batch", vRow, (object)null, PnlNo, empName, truncAcctNum, 0);
            {
                ref var withBlock1 = ref paymentPanel[PnlNo];
                withBlock1.BackColor = Color.DarkGray;

                this.paymentPanel[PnlNo].ActivePanel += PaymentUserControl_Click;
            }
            PnlNo += 1;
        }

        if (dvBatchPreAuth.Count > 0)
        {
            startPreAuthIndex = dvBatchVoiceAuth.Count + 1;
        }
        else
        {
            startPreAuthIndex = dvBatchVoiceAuth.Count;
        }
        endPreAuthIndex = endVoiceIndex + dvBatchPreAuth.Count;

        foreach (DataRowView currentVRow2 in dvBatchPreAuthCapture)
        {
            vRow = currentVRow2;
            empName = vRow("FirstName") + " " + vRow("LastName");
            if (!(vRow("AccountNumber").Substring(0, 4) == "xxxx") & !(vRow("AccountNumber") == "Manual"))
            {
                truncAcctNum = TruncateAccountNumber(vRow("AccountNumber"));
            }
            else
            {
                truncAcctNum = vRow("AccountNumber");
            }
            paymentPanel[PnlNo] = new DataSet_Builder.Payment_UC("Batch", vRow, (object)null, PnlNo, empName, truncAcctNum, 0);
            {
                ref var withBlock2 = ref paymentPanel[PnlNo];
                withBlock2.BackColor = Color.DarkGray;

                this.paymentPanel[PnlNo].ActivePanel += PaymentUserControl_Click;
            }
        }

        if (dvBatchPreAuthCapture.Count > 0)
        {
            startPreAuthCaptureIndex = endPreAuthIndex + 1;
        }
        else
        {
            startPreAuthCaptureIndex = endPreAuthIndex;
        }
        endPreAuthCaptureIndex = endPreAuthIndex + dvBatchPreAuthCapture.Count;

        foreach (DataRowView currentVRow3 in dvBatchReturn)
        {
            vRow = currentVRow3;
            empName = vRow("FirstName") + " " + vRow("LastName");
            if (!(vRow("AccountNumber").Substring(0, 4) == "xxxx") & !(vRow("AccountNumber") == "Manual"))
            {
                truncAcctNum = TruncateAccountNumber(vRow("AccountNumber"));
            }
            else
            {
                truncAcctNum = vRow("AccountNumber");
            }
            paymentPanel[PnlNo] = new DataSet_Builder.Payment_UC("Batch", vRow, (object)null, PnlNo, empName, truncAcctNum, 0);
            {
                ref var withBlock3 = ref paymentPanel[PnlNo];
                withBlock3.BackColor = Color.DarkGray;
                this.paymentPanel[PnlNo].ActivePanel += PaymentUserControl_Click;
            }
        }

        if (dvBatchReturn.Count > 0)
        {
            startReturnIndex = endPreAuthCaptureIndex + 1;
        }
        else
        {
            startReturnIndex = endPreAuthCaptureIndex;
        }
        endReturnIndex = endPreAuthCaptureIndex + dvBatchReturn.Count;


    }

    private void DisplayNonAdjustedPaymentPanels222()
    {
        // we display by index values in case of deleted payments 
        // they would not reflect in dataviews
        // we can do some kind of Mark As Deleted in paymentPanel

        int PnlNo;
        int position = 0;
        btnNonAdjusted.BackColor = c11;
        btnNonAdjusted.ForeColor = c3;

        pnlBatchPayments.Controls.Clear();


        if (dvBatchVoiceAuth.Count > 0)
        {
            var loopTo = endVoiceIndex;
            for (PnlNo = 1; PnlNo <= loopTo; PnlNo++)
            {
                if (paymentPanel[PnlNo].TipAmount == 0)
                {
                    {
                        ref var withBlock = ref paymentPanel[PnlNo];
                        withBlock.Location = new Point(0, withBlock.Height * position);
                        withBlock.ReverseAlignment();
                        pnlBatchPayments.Controls.Add(paymentPanel[PnlNo]);
                    }
                    position += 1;
                }
            }
        }

        if (dvBatchPreAuth.Count > 0)
        {
            var loopTo1 = endPreAuthIndex;
            for (PnlNo = startPreAuthIndex; PnlNo <= loopTo1; PnlNo++)
            {
                {
                    ref var withBlock1 = ref paymentPanel[PnlNo];
                    withBlock1.Location = new Point(0, withBlock1.Height * position);
                    withBlock1.ReverseAlignment();
                    pnlBatchPayments.Controls.Add(paymentPanel[PnlNo]);
                }
                position += 1;
            }
        }



    }

    private void DisplayCreditPurchasePaymentPanels222()
    {

        int PnlNo;
        int position = 0;
        btnNonAdjusted.BackColor = c11;
        btnNonAdjusted.ForeColor = c3;

        pnlBatchPayments.Controls.Clear();


        if (dvBatchVoiceAuth.Count > 0)
        {
            var loopTo = endVoiceIndex;
            for (PnlNo = 1; PnlNo <= loopTo; PnlNo++)
            {
                {
                    ref var withBlock = ref paymentPanel[PnlNo];
                    withBlock.Location = new Point(0, withBlock.Height * position);
                    if (paymentPanel[PnlNo].TipAmount == 0)
                    {
                        withBlock.ReverseAlignment();
                    }
                    else
                    {
                        withBlock.StandardAlignment();
                    }
                    pnlBatchPayments.Controls.Add(paymentPanel[PnlNo]);
                }
                position += 1;
            }
        }


        if (dvBatchPreAuthCapture.Count > 0)
        {
            var loopTo1 = endPreAuthCaptureIndex;
            for (PnlNo = startPreAuthCaptureIndex; PnlNo <= loopTo1; PnlNo++)
            {
                {
                    ref var withBlock1 = ref paymentPanel[PnlNo];
                    withBlock1.Location = new Point(0, withBlock1.Height * position);
                    // .StandardAlignment()
                    pnlBatchPayments.Controls.Add(paymentPanel[PnlNo]);
                }
                position += 1;
            }
        }


    }

    private void DisplayCreditRetrunPaymentPanels222()
    {

        int PnlNo;
        int position = 0;
        btnNonAdjusted.BackColor = c11;
        btnNonAdjusted.ForeColor = c3;

        pnlBatchPayments.Controls.Clear();


        if (dvBatchReturn.Count > 0)
        {
            var loopTo = endReturnIndex;
            for (PnlNo = startReturnIndex; PnlNo <= loopTo; PnlNo++)
            {
                {
                    ref var withBlock = ref paymentPanel[PnlNo];
                    withBlock.Location = new Point(0, withBlock.Height * position);
                    // .StandardAlignment()
                    pnlBatchPayments.Controls.Add(paymentPanel[PnlNo]);
                }
                position += 1;
            }
        }


    }

    private void btnDailyNextPage_Click(object sender, EventArgs e)
    {

        switch (activePanelDisplay ?? "")
        {

            case "nonAdjusted":
                {
                    if (naPanelIndex >= posNonAdjCount)
                        return;

                    naPanelIndex += 9;
                    DisplayNonAdjustedPaymentPanels();
                    break;
                }

            case "creditPurchase":
                {
                    if (cpPanelIndex >= posCreditPurchaseCount)
                        return;
                    cpPanelIndex += 9;
                    DisplayCreditPurchasePaymentPanels();
                    break;
                }

            case "creditReturn":
                {
                    if (naPanelIndex >= posCreditReturnCount)
                        return;
                    crPanelIndex += 9;
                    DisplayCreditReturnPaymentPanels();
                    break;
                }

            case "batchDecline":
                {
                    if (naPanelIndex >= posNetCount)
                        return;

                    bdPanelIndex += 9;
                    DisplayBatchDeclines();
                    break;
                }
            case "net":
                {
                    if (netPanelIndex >= posNetCount)
                        return;
                    netPanelIndex += 9;
                    DisplayBatchTotalPanel();
                    break;
                }

        }

    }

    private void btnDailyPreviousPage_Click(object sender, EventArgs e)
    {



        switch (activePanelDisplay ?? "")
        {

            case "nonAdjusted":
                {
                    if (naPanelIndex <= 1)
                        return;
                    naPanelIndex -= 9;
                    DisplayNonAdjustedPaymentPanels();
                    break;
                }

            case "creditPurchase":
                {
                    if (cpPanelIndex <= 1)
                        return;
                    cpPanelIndex -= 9;
                    DisplayCreditPurchasePaymentPanels();
                    break;
                }

            case "creditReturn":
                {
                    if (crPanelIndex <= 1)
                        return;
                    crPanelIndex -= 9;
                    DisplayCreditReturnPaymentPanels();
                    break;
                }

            case "batchDecline":
                {
                    if (bdPanelIndex <= 1)
                        return;
                    bdPanelIndex -= 9;
                    DisplayBatchDeclines();
                    break;
                }
            case "net":
                {
                    if (netPanelIndex <= 1)
                        return;
                    netPanelIndex -= 9;
                    DisplayBatchTotalPanel();
                    break;
                }

        }
    }
}