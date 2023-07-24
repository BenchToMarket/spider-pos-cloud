using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using DataSet_Builder;
using DSICLIENTXLib;
using SIM;

public partial class CloseCheck : System.Windows.Forms.UserControl
{

    private DSICLIENTXLib.DSICLientX dsi;
    // Dim dsi As New AxDSICLIENTXLib.AxDSICLientX
    // Private WithEvents PaywarePCCharge As New SIM.Charge
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

    private CheckTotal_UC _closeCheckTotals;

    private CheckTotal_UC closeCheckTotals
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _closeCheckTotals;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _closeCheckTotals = value;
        }
    }
    // Dim WithEvents closeCheckAdjustments As CheckAdjustment_UC
    internal ReadCredit readAuth222;
    internal bool releaseFlag;
    // Friend singleSplit As Boolean
    private Tab_Screen _TabEnterScreen;

    private Tab_Screen TabEnterScreen
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabEnterScreen;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabEnterScreen != null)
            {
                _TabEnterScreen.SelectedReOrder -= CloseSelectedReOrder;
                _TabEnterScreen.TabScreenDisposing -= CloseTabEnter222;
            }

            _TabEnterScreen = value;
            if (_TabEnterScreen != null)
            {
                _TabEnterScreen.SelectedReOrder += CloseSelectedReOrder;
                _TabEnterScreen.TabScreenDisposing += CloseTabEnter222;
            }
        }
    }
    private CashClose_UC ccDisplay;
    private Info2_UC paywareAuthInfo;

    private DataSet_Builder.Payment_UC[] paymentPanel = new DataSet_Builder.Payment_UC[6];
    private PaymentInfo authPayment;

    // Friend WithEvents tmrCardRead As System.Windows.Forms.Timer


    private DataView dvBSGS;
    private DataView dvCombo;
    private decimal comboPrice;
    private DataView dvCoupon;

    internal KitchenButton[] btnPromo = new KitchenButton[21];
    private KitchenButton btnKitchen;
    // Dim sql As New DataSet_Builder.SQLHelper(connectserver)
    private PrintHelper prt = new PrintHelper();

    private int closeTimeoutCounter;      // not used

    private decimal maxDollar;     // same as maxTable
    private int maxCheck;
    private int maxTable;     // have to DIm in Orderform or part of current table structure
    private int customerNumber;       // for promotions

    private bool[] PromotionApplied = new bool[21];
    // old   '  Dim promoNumber As Integer = 1
    // Dim CashPaymentTendered As Boolean
    // Dim AmountToChange As Decimal

    private decimal roundingError;
    private bool _remainingBalancesZero;
    private bool doNotAutoCreditCards;
    private bool creditAmountAdjusted;
    private decimal _checkGiftIssuingAmount;
    // above will be a positive number, when paymentAmount will be negative for issuing gift
    private decimal _lastPurchaseIssueAmount;

    private int numActivePaymentsByCheck;
    private decimal _remainingBalance;     // on both
    private decimal _totalCheckBalance;
    private bool _giftAddingAmount;

    private int paymentRowIndex;
    private int startPaymentIndex = 1;
    // Dim unappliedRowIndex As Integer

    // Event DisposeSplitScreen() '(ByVal sender As Object, ByVal e As System.EventArgs)
    public event CloseGotoSplittingEventHandler CloseGotoSplitting;

    public delegate void CloseGotoSplittingEventHandler(object sender, EventArgs e);
    public event CloseExitAndReleaseEventHandler CloseExitAndRelease;

    public delegate void CloseExitAndReleaseEventHandler();
    public event CloseExitingEventHandler CloseExiting;

    public delegate void CloseExitingEventHandler(bool going, bool RemainingBalancesZero);         // disposes splitscreen
    public event AuthPaymentsEventHandler AuthPayments;

    public delegate void AuthPaymentsEventHandler(ref PreAuthAmountClass authamount, ref PreAuthTransactionClass authtransaction, bool cardSwipedDatabaseInfo);
    public event SplitSingleCheckEventHandler SplitSingleCheck;

    public delegate void SplitSingleCheckEventHandler();
    public event SelectedReOrderEventHandler SelectedReOrder;

    public delegate void SelectedReOrderEventHandler(DataTable dt, bool tabTestNeeded);
    public event FireTabScreenEventHandler FireTabScreen;

    public delegate void FireTabScreenEventHandler(string startInSearch, string searchCriteria);
    public event MakeGiftAddingAmountTrueEventHandler MakeGiftAddingAmountTrue;

    public delegate void MakeGiftAddingAmountTrueEventHandler();
    public event MerchantAuthPaymentEventHandler MerchantAuthPayment;

    public delegate void MerchantAuthPaymentEventHandler(int paymentID, bool justActive);

    internal bool RemainingBalancesZero
    {
        get
        {
            return _remainingBalancesZero;
        }
        set
        {
            _remainingBalancesZero = value;
        }
    }

    internal decimal RemainingBalance
    {
        get
        {
            return _remainingBalance;
        }
        set
        {
            _remainingBalance = value;
        }
    }

    internal decimal TotalCheckBalance
    {
        get
        {
            return _totalCheckBalance;
        }
        set
        {
            _totalCheckBalance = value;
        }
    }

    internal bool GiftAddingAmount
    {
        get
        {
            return _giftAddingAmount;
        }
        set
        {
            _giftAddingAmount = value;
        }
    }


    private static PreAuthAmountClass _closeAuthAmount;
    private static PreAuthTransactionClass _closeAuthTransaction;
    private static AccountClass _closeAuthAccount;


    #region  Windows Form Designer generated code 

    public CloseCheck(int closingCheck) : base()
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        InitializeOther(closingCheck);
        readAuth222.CardReadSuccessful += NewCardRead;

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
    private Global.System.Windows.Forms.Button _btnCloseCash;

    internal virtual Global.System.Windows.Forms.Button btnCloseCash
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCloseCash;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCloseCash != null)
            {
                _btnCloseCash.Click -= btnCloseCash_Click;
            }

            _btnCloseCash = value;
            if (_btnCloseCash != null)
            {
                _btnCloseCash.Click += btnCloseCash_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnClose100;

    internal virtual Global.System.Windows.Forms.Button btnClose100
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnClose100;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnClose100 != null)
            {
                _btnClose100.Click -= btnClose100_Click;
            }

            _btnClose100 = value;
            if (_btnClose100 != null)
            {
                _btnClose100.Click += btnClose100_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnClose50;

    internal virtual Global.System.Windows.Forms.Button btnClose50
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnClose50;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnClose50 != null)
            {
                _btnClose50.Click -= btnClose50_Click;
            }

            _btnClose50 = value;
            if (_btnClose50 != null)
            {
                _btnClose50.Click += btnClose50_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnClose20;

    internal virtual Global.System.Windows.Forms.Button btnClose20
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnClose20;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnClose20 != null)
            {
                _btnClose20.Click -= btnClose20_Click;
            }

            _btnClose20 = value;
            if (_btnClose20 != null)
            {
                _btnClose20.Click += btnClose20_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnClose1;

    internal virtual Global.System.Windows.Forms.Button btnClose1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnClose1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnClose1 != null)
            {
                _btnClose1.Click -= btnClose1_Click;
            }

            _btnClose1 = value;
            if (_btnClose1 != null)
            {
                _btnClose1.Click += btnClose1_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnClose5;

    internal virtual Global.System.Windows.Forms.Button btnClose5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnClose5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnClose5 != null)
            {
                _btnClose5.Click -= btnClose5_Click;
            }

            _btnClose5 = value;
            if (_btnClose5 != null)
            {
                _btnClose5.Click += btnClose5_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnClose10;

    internal virtual Global.System.Windows.Forms.Button btnClose10
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnClose10;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnClose10 != null)
            {
                _btnClose10.Click -= btnClose10_Click;
            }

            _btnClose10 = value;
            if (_btnClose10 != null)
            {
                _btnClose10.Click += btnClose10_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnClosePrint;

    internal virtual Global.System.Windows.Forms.Button btnClosePrint
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnClosePrint;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnClosePrint != null)
            {
                _btnClosePrint.Click -= btnClosePrint_Click;
            }

            _btnClosePrint = value;
            if (_btnClosePrint != null)
            {
                _btnClosePrint.Click += btnClosePrint_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnClosePrintAll;

    internal virtual Global.System.Windows.Forms.Button btnClosePrintAll
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnClosePrintAll;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnClosePrintAll != null)
            {
                _btnClosePrintAll.Click -= btnClosePrintAll_Click;
            }

            _btnClosePrintAll = value;
            if (_btnClosePrintAll != null)
            {
                _btnClosePrintAll.Click += btnClosePrintAll_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnClosePayment;

    internal virtual Global.System.Windows.Forms.Button btnClosePayment
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnClosePayment;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnClosePayment != null)
            {
                _btnClosePayment.Click -= btnClosePayment_Click;
            }

            _btnClosePayment = value;
            if (_btnClosePayment != null)
            {
                _btnClosePayment.Click += btnClosePayment_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnCloseMgr;

    internal virtual Global.System.Windows.Forms.Button btnCloseMgr
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCloseMgr;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCloseMgr != null)
            {
                _btnCloseMgr.Click -= btnCloseComp_Click;
            }

            _btnCloseMgr = value;
            if (_btnCloseMgr != null)
            {
                _btnCloseMgr.Click += btnCloseComp_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnClosePromo;

    internal virtual Global.System.Windows.Forms.Button btnClosePromo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnClosePromo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnClosePromo != null)
            {
                _btnClosePromo.Click -= btnClosePromo_Click;
            }

            _btnClosePromo = value;
            if (_btnClosePromo != null)
            {
                _btnClosePromo.Click += btnClosePromo_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnCloseGift;

    internal virtual Global.System.Windows.Forms.Button btnCloseGift
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCloseGift;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCloseGift != null)
            {
                _btnCloseGift.Click -= btnCloseGift_Click;
            }

            _btnCloseGift = value;
            if (_btnCloseGift != null)
            {
                _btnCloseGift.Click += btnCloseGift_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnCloseAutoTip;

    internal virtual Global.System.Windows.Forms.Button btnCloseAutoTip
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCloseAutoTip;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCloseAutoTip != null)
            {
                _btnCloseAutoTip.Click -= btnCloseAutoTip_Click;
            }

            _btnCloseAutoTip = value;
            if (_btnCloseAutoTip != null)
            {
                _btnCloseAutoTip.Click += btnCloseAutoTip_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnCloseGiftCardAdd;

    internal virtual Global.System.Windows.Forms.Button btnCloseGiftCardAdd
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCloseGiftCardAdd;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCloseGiftCardAdd != null)
            {
                _btnCloseGiftCardAdd.Click -= btnCloseGiftCardAdd_Click;
            }

            _btnCloseGiftCardAdd = value;
            if (_btnCloseGiftCardAdd != null)
            {
                _btnCloseGiftCardAdd.Click += btnCloseGiftCardAdd_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnCloseExit;

    internal virtual Global.System.Windows.Forms.Button btnCloseExit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCloseExit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCloseExit != null)
            {
                _btnCloseExit.Click -= btnCloseExit_Click;
            }

            _btnCloseExit = value;
            if (_btnCloseExit != null)
            {
                _btnCloseExit.Click += btnCloseExit_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _pnlPaymentTypes;

    internal virtual Global.System.Windows.Forms.Panel pnlPaymentTypes
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlPaymentTypes;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pnlPaymentTypes != null)
            {
                _pnlPaymentTypes.Click -= PromoSelect;
            }

            _pnlPaymentTypes = value;
            if (_pnlPaymentTypes != null)
            {
                _pnlPaymentTypes.Click += PromoSelect;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnCloseRelease;

    internal virtual Global.System.Windows.Forms.Button btnCloseRelease
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCloseRelease;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCloseRelease != null)
            {
                _btnCloseRelease.Click -= btnCloseRelease_Click;
            }

            _btnCloseRelease = value;
            if (_btnCloseRelease != null)
            {
                _btnCloseRelease.Click += btnCloseRelease_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnCloseCheckNumber;

    internal virtual Global.System.Windows.Forms.Button btnCloseCheckNumber
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCloseCheckNumber;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCloseCheckNumber != null)
            {
                _btnCloseCheckNumber.Click -= btnCloseCheckNumber_Click;
            }

            _btnCloseCheckNumber = value;
            if (_btnCloseCheckNumber != null)
            {
                _btnCloseCheckNumber.Click += btnCloseCheckNumber_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnCloseSplit;

    internal virtual Global.System.Windows.Forms.Button btnCloseSplit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCloseSplit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCloseSplit != null)
            {
                _btnCloseSplit.Click -= btnCloseSplit_Click;
            }

            _btnCloseSplit = value;
            if (_btnCloseSplit != null)
            {
                _btnCloseSplit.Click += btnCloseSplit_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnCloseManualcc;

    internal virtual Global.System.Windows.Forms.Button btnCloseManualcc
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCloseManualcc;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCloseManualcc != null)
            {
                _btnCloseManualcc.Click -= btnCloseManualcc_Click;
            }

            _btnCloseManualcc = value;
            if (_btnCloseManualcc != null)
            {
                _btnCloseManualcc.Click += btnCloseManualcc_Click;
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
    private Global.System.Windows.Forms.Panel _pnlClosePayments;

    internal virtual Global.System.Windows.Forms.Panel pnlClosePayments
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlClosePayments;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pnlClosePayments != null)
            {
                _pnlClosePayments.DoubleClick -= PaymentUserControl_History;
                _pnlClosePayments.Click -= PaymentUserControl_Click;
            }

            _pnlClosePayments = value;
            if (_pnlClosePayments != null)
            {
                _pnlClosePayments.DoubleClick += PaymentUserControl_History;
                _pnlClosePayments.Click += PaymentUserControl_Click;
            }
        }
    }
    internal DataSet_Builder.NumberPadLarge NumberPadLargeold;
    private Global.System.Windows.Forms.Panel _pnlBalance;

    internal virtual Global.System.Windows.Forms.Panel pnlBalance
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlBalance;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlBalance = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblBalance;

    internal virtual Global.System.Windows.Forms.Label lblBalance
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblBalance;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblBalance = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnAuthAll;

    internal virtual Global.System.Windows.Forms.Button btnAuthAll
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnAuthAll;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnAuthAll != null)
            {
                _btnAuthAll.Click -= btnAuthAll_Click;
            }

            _btnAuthAll = value;
            if (_btnAuthAll != null)
            {
                _btnAuthAll.Click += btnAuthAll_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnAuthActive;

    internal virtual Global.System.Windows.Forms.Button btnAuthActive
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnAuthActive;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnAuthActive != null)
            {
                _btnAuthActive.Click -= btnAuthActive_Click;
            }

            _btnAuthActive = value;
            if (_btnAuthActive != null)
            {
                _btnAuthActive.Click += btnAuthActive_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnRemove;

    internal virtual Global.System.Windows.Forms.Button btnRemove
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnRemove;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnRemove != null)
            {
                _btnRemove.Click -= btnRemove_Click;
            }

            _btnRemove = value;
            if (_btnRemove != null)
            {
                _btnRemove.Click += btnRemove_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblBalanceDetail;

    internal virtual Global.System.Windows.Forms.Label lblBalanceDetail
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblBalanceDetail;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblBalanceDetail = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnMorePayments;

    internal virtual Global.System.Windows.Forms.Button btnMorePayments
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMorePayments;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMorePayments != null)
            {
                _btnMorePayments.Click -= btnMorePayments_Click;
            }

            _btnMorePayments = value;
            if (_btnMorePayments != null)
            {
                _btnMorePayments.Click += btnMorePayments_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnDup;

    internal virtual Global.System.Windows.Forms.Button btnDup
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDup;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnDup != null)
            {
                _btnDup.Click -= btnDup_Click;
            }

            _btnDup = value;
            if (_btnDup != null)
            {
                _btnDup.Click += btnDup_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnVoiceAuth;

    internal virtual Global.System.Windows.Forms.Button btnVoiceAuth
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnVoiceAuth;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnVoiceAuth != null)
            {
                _btnVoiceAuth.Click -= btnVoiceAuth_Click;
            }

            _btnVoiceAuth = value;
            if (_btnVoiceAuth != null)
            {
                _btnVoiceAuth.Click += btnVoiceAuth_Click;
            }
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
                _NumberPadLarge1.NumberEntered -= PaymentEnterHit;
            }

            _NumberPadLarge1 = value;
            if (_NumberPadLarge1 != null)
            {
                _NumberPadLarge1.NumberEntered += PaymentEnterHit;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _pnlExit;

    internal virtual Global.System.Windows.Forms.Panel pnlExit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlExit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlExit = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlPayOptions;

    internal virtual Global.System.Windows.Forms.Panel pnlPayOptions
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlPayOptions;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlPayOptions = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlPayRemove;

    internal virtual Global.System.Windows.Forms.Panel pnlPayRemove
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlPayRemove;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlPayRemove = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnDemoCC;

    internal virtual Global.System.Windows.Forms.Button btnDemoCC
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDemoCC;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnDemoCC != null)
            {
                _btnDemoCC.Click -= btnDemoCC_Click;
            }

            _btnDemoCC = value;
            if (_btnDemoCC != null)
            {
                _btnDemoCC.Click += btnDemoCC_Click;
            }
        }
    }

    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _pnlPaymentTypes = new System.Windows.Forms.Panel();
        _pnlPaymentTypes.Click += PromoSelect;
        _btnCloseGift = new System.Windows.Forms.Button();
        _btnCloseGift.Click += btnCloseGift_Click;
        _btnCloseManualcc = new System.Windows.Forms.Button();
        _btnCloseManualcc.Click += btnCloseManualcc_Click;
        _btnClose1 = new System.Windows.Forms.Button();
        _btnClose1.Click += btnClose1_Click;
        _btnClose5 = new System.Windows.Forms.Button();
        _btnClose5.Click += btnClose5_Click;
        _btnClose10 = new System.Windows.Forms.Button();
        _btnClose10.Click += btnClose10_Click;
        _btnClose20 = new System.Windows.Forms.Button();
        _btnClose20.Click += btnClose20_Click;
        _btnClose50 = new System.Windows.Forms.Button();
        _btnClose50.Click += btnClose50_Click;
        _btnClose100 = new System.Windows.Forms.Button();
        _btnClose100.Click += btnClose100_Click;
        _btnCloseCash = new System.Windows.Forms.Button();
        _btnCloseCash.Click += btnCloseCash_Click;
        _btnClosePrint = new System.Windows.Forms.Button();
        _btnClosePrint.Click += btnClosePrint_Click;
        _btnClosePrintAll = new System.Windows.Forms.Button();
        _btnClosePrintAll.Click += btnClosePrintAll_Click;
        _btnClosePayment = new System.Windows.Forms.Button();
        _btnClosePayment.Click += btnClosePayment_Click;
        _btnCloseMgr = new System.Windows.Forms.Button();
        _btnCloseMgr.Click += btnCloseComp_Click;
        _btnClosePromo = new System.Windows.Forms.Button();
        _btnClosePromo.Click += btnClosePromo_Click;
        _btnCloseExit = new System.Windows.Forms.Button();
        _btnCloseExit.Click += btnCloseExit_Click;
        _btnCloseAutoTip = new System.Windows.Forms.Button();
        _btnCloseAutoTip.Click += btnCloseAutoTip_Click;
        _btnCloseGiftCardAdd = new System.Windows.Forms.Button();
        _btnCloseGiftCardAdd.Click += btnCloseGiftCardAdd_Click;
        _pnlExit = new System.Windows.Forms.Panel();
        _btnCloseCheckNumber = new System.Windows.Forms.Button();
        _btnCloseCheckNumber.Click += btnCloseCheckNumber_Click;
        _btnCloseRelease = new System.Windows.Forms.Button();
        _btnCloseRelease.Click += btnCloseRelease_Click;
        _btnCloseSplit = new System.Windows.Forms.Button();
        _btnCloseSplit.Click += btnCloseSplit_Click;
        _Panel3 = new System.Windows.Forms.Panel();
        _pnlClosePayments = new System.Windows.Forms.Panel();
        _pnlClosePayments.DoubleClick += PaymentUserControl_History;
        _pnlClosePayments.Click += PaymentUserControl_Click;
        _pnlBalance = new System.Windows.Forms.Panel();
        _lblBalanceDetail = new System.Windows.Forms.Label();
        _btnAuthActive = new System.Windows.Forms.Button();
        _btnAuthActive.Click += btnAuthActive_Click;
        _btnAuthAll = new System.Windows.Forms.Button();
        _btnAuthAll.Click += btnAuthAll_Click;
        _lblBalance = new System.Windows.Forms.Label();
        _btnRemove = new System.Windows.Forms.Button();
        _btnRemove.Click += btnRemove_Click;
        _pnlPayRemove = new System.Windows.Forms.Panel();
        _btnMorePayments = new System.Windows.Forms.Button();
        _btnMorePayments.Click += btnMorePayments_Click;
        _btnDup = new System.Windows.Forms.Button();
        _btnDup.Click += btnDup_Click;
        _btnVoiceAuth = new System.Windows.Forms.Button();
        _btnVoiceAuth.Click += btnVoiceAuth_Click;
        _pnlPayOptions = new System.Windows.Forms.Panel();
        _btnDemoCC = new System.Windows.Forms.Button();
        _btnDemoCC.Click += btnDemoCC_Click;
        _NumberPadLarge1 = new DataSet_Builder.NumberPadLarge();
        _NumberPadLarge1.NumberEntered += PaymentEnterHit;
        _pnlPaymentTypes.SuspendLayout();
        _pnlExit.SuspendLayout();
        _Panel3.SuspendLayout();
        _pnlBalance.SuspendLayout();
        _pnlPayRemove.SuspendLayout();
        _pnlPayOptions.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlPaymentTypes
        // 
        _pnlPaymentTypes.BackColor = System.Drawing.Color.WhiteSmoke;
        _pnlPaymentTypes.Controls.Add(_btnCloseGift);
        _pnlPaymentTypes.Controls.Add(_btnCloseManualcc);
        _pnlPaymentTypes.Controls.Add(_btnClose1);
        _pnlPaymentTypes.Controls.Add(_btnClose5);
        _pnlPaymentTypes.Controls.Add(_btnClose10);
        _pnlPaymentTypes.Controls.Add(_btnClose20);
        _pnlPaymentTypes.Controls.Add(_btnClose50);
        _pnlPaymentTypes.Controls.Add(_btnClose100);
        _pnlPaymentTypes.Controls.Add(_btnCloseCash);
        _pnlPaymentTypes.Location = new System.Drawing.Point(104, 16);
        _pnlPaymentTypes.Name = "_pnlPaymentTypes";
        _pnlPaymentTypes.Size = new System.Drawing.Size(392, 200);
        _pnlPaymentTypes.TabIndex = 1;
        // 
        // btnCloseGift
        // 
        _btnCloseGift.BackColor = System.Drawing.Color.RoyalBlue;
        _btnCloseGift.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnCloseGift.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _btnCloseGift.Location = new System.Drawing.Point(8, 72);
        _btnCloseGift.Name = "_btnCloseGift";
        _btnCloseGift.Size = new System.Drawing.Size(120, 56);
        _btnCloseGift.TabIndex = 11;
        _btnCloseGift.Text = "Gift Cert";
        _btnCloseGift.UseVisualStyleBackColor = false;
        // 
        // btnCloseManualcc
        // 
        _btnCloseManualcc.BackColor = System.Drawing.Color.RoyalBlue;
        _btnCloseManualcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnCloseManualcc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _btnCloseManualcc.Location = new System.Drawing.Point(8, 136);
        _btnCloseManualcc.Name = "_btnCloseManualcc";
        _btnCloseManualcc.Size = new System.Drawing.Size(120, 56);
        _btnCloseManualcc.TabIndex = 7;
        _btnCloseManualcc.Text = "Manual CC";
        _btnCloseManualcc.UseVisualStyleBackColor = false;
        // 
        // btnClose1
        // 
        _btnClose1.BackColor = System.Drawing.Color.RoyalBlue;
        _btnClose1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnClose1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _btnClose1.Location = new System.Drawing.Point(264, 136);
        _btnClose1.Name = "_btnClose1";
        _btnClose1.Size = new System.Drawing.Size(120, 56);
        _btnClose1.TabIndex = 6;
        _btnClose1.Text = "$1";
        _btnClose1.UseVisualStyleBackColor = false;
        // 
        // btnClose5
        // 
        _btnClose5.BackColor = System.Drawing.Color.RoyalBlue;
        _btnClose5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnClose5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _btnClose5.Location = new System.Drawing.Point(264, 72);
        _btnClose5.Name = "_btnClose5";
        _btnClose5.Size = new System.Drawing.Size(120, 56);
        _btnClose5.TabIndex = 5;
        _btnClose5.Text = "$5";
        _btnClose5.UseVisualStyleBackColor = false;
        // 
        // btnClose10
        // 
        _btnClose10.BackColor = System.Drawing.Color.RoyalBlue;
        _btnClose10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnClose10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _btnClose10.Location = new System.Drawing.Point(264, 8);
        _btnClose10.Name = "_btnClose10";
        _btnClose10.Size = new System.Drawing.Size(120, 56);
        _btnClose10.TabIndex = 4;
        _btnClose10.Text = "$10";
        _btnClose10.UseVisualStyleBackColor = false;
        // 
        // btnClose20
        // 
        _btnClose20.BackColor = System.Drawing.Color.RoyalBlue;
        _btnClose20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnClose20.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _btnClose20.Location = new System.Drawing.Point(136, 136);
        _btnClose20.Name = "_btnClose20";
        _btnClose20.Size = new System.Drawing.Size(120, 56);
        _btnClose20.TabIndex = 3;
        _btnClose20.Text = "$20";
        _btnClose20.UseVisualStyleBackColor = false;
        // 
        // btnClose50
        // 
        _btnClose50.BackColor = System.Drawing.Color.RoyalBlue;
        _btnClose50.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnClose50.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _btnClose50.Location = new System.Drawing.Point(136, 72);
        _btnClose50.Name = "_btnClose50";
        _btnClose50.Size = new System.Drawing.Size(120, 56);
        _btnClose50.TabIndex = 2;
        _btnClose50.Text = "$50";
        _btnClose50.UseVisualStyleBackColor = false;
        // 
        // btnClose100
        // 
        _btnClose100.BackColor = System.Drawing.Color.RoyalBlue;
        _btnClose100.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnClose100.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _btnClose100.Location = new System.Drawing.Point(136, 8);
        _btnClose100.Name = "_btnClose100";
        _btnClose100.Size = new System.Drawing.Size(120, 56);
        _btnClose100.TabIndex = 1;
        _btnClose100.Text = "$100";
        _btnClose100.UseVisualStyleBackColor = false;
        // 
        // btnCloseCash
        // 
        _btnCloseCash.BackColor = System.Drawing.Color.RoyalBlue;
        _btnCloseCash.FlatAppearance.BorderColor = System.Drawing.Color.White;
        _btnCloseCash.FlatAppearance.BorderSize = 0;
        _btnCloseCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnCloseCash.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _btnCloseCash.Location = new System.Drawing.Point(8, 8);
        _btnCloseCash.Name = "_btnCloseCash";
        _btnCloseCash.Size = new System.Drawing.Size(120, 56);
        _btnCloseCash.TabIndex = 0;
        _btnCloseCash.Text = "Cash";
        _btnCloseCash.UseVisualStyleBackColor = false;
        // 
        // btnClosePrint
        // 
        _btnClosePrint.BackColor = System.Drawing.Color.LightSlateGray;
        _btnClosePrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnClosePrint.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _btnClosePrint.Location = new System.Drawing.Point(104, 0);
        _btnClosePrint.Name = "_btnClosePrint";
        _btnClosePrint.Size = new System.Drawing.Size(88, 48);
        _btnClosePrint.TabIndex = 2;
        _btnClosePrint.Text = "PRINT";
        _btnClosePrint.UseVisualStyleBackColor = false;
        // 
        // btnClosePrintAll
        // 
        _btnClosePrintAll.BackColor = System.Drawing.Color.LightSlateGray;
        _btnClosePrintAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnClosePrintAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _btnClosePrintAll.Location = new System.Drawing.Point(104, 48);
        _btnClosePrintAll.Name = "_btnClosePrintAll";
        _btnClosePrintAll.Size = new System.Drawing.Size(88, 48);
        _btnClosePrintAll.TabIndex = 3;
        _btnClosePrintAll.Text = "PRINT ALL";
        _btnClosePrintAll.UseVisualStyleBackColor = false;
        // 
        // btnClosePayment
        // 
        _btnClosePayment.BackColor = System.Drawing.Color.LightSlateGray;
        _btnClosePayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnClosePayment.Location = new System.Drawing.Point(8, 29);
        _btnClosePayment.Name = "_btnClosePayment";
        _btnClosePayment.Size = new System.Drawing.Size(88, 48);
        _btnClosePayment.TabIndex = 4;
        _btnClosePayment.Text = "PAYMENT";
        _btnClosePayment.UseVisualStyleBackColor = false;
        // 
        // btnCloseMgr
        // 
        _btnCloseMgr.BackColor = System.Drawing.Color.SlateGray;
        _btnCloseMgr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnCloseMgr.Location = new System.Drawing.Point(8, 160);
        _btnCloseMgr.Name = "_btnCloseMgr";
        _btnCloseMgr.Size = new System.Drawing.Size(88, 48);
        _btnCloseMgr.TabIndex = 5;
        _btnCloseMgr.Text = "Manager";
        _btnCloseMgr.UseVisualStyleBackColor = false;
        // 
        // btnClosePromo
        // 
        _btnClosePromo.BackColor = System.Drawing.Color.LightSlateGray;
        _btnClosePromo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnClosePromo.Location = new System.Drawing.Point(8, 92);
        _btnClosePromo.Name = "_btnClosePromo";
        _btnClosePromo.Size = new System.Drawing.Size(88, 48);
        _btnClosePromo.TabIndex = 6;
        _btnClosePromo.Text = "PROMOs";
        _btnClosePromo.UseVisualStyleBackColor = false;
        // 
        // btnCloseExit
        // 
        _btnCloseExit.BackColor = System.Drawing.Color.LightSlateGray;
        _btnCloseExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnCloseExit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _btnCloseExit.Location = new System.Drawing.Point(0, 0);
        _btnCloseExit.Name = "_btnCloseExit";
        _btnCloseExit.Size = new System.Drawing.Size(96, 48);
        _btnCloseExit.TabIndex = 7;
        _btnCloseExit.Text = "EXIT";
        _btnCloseExit.UseVisualStyleBackColor = false;
        // 
        // btnCloseAutoTip
        // 
        _btnCloseAutoTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnCloseAutoTip.Location = new System.Drawing.Point(536, 80);
        _btnCloseAutoTip.Name = "_btnCloseAutoTip";
        _btnCloseAutoTip.Size = new System.Drawing.Size(88, 48);
        _btnCloseAutoTip.TabIndex = 8;
        _btnCloseAutoTip.Text = "Auto Gratuity";
        // 
        // btnCloseGiftCardAdd
        // 
        _btnCloseGiftCardAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnCloseGiftCardAdd.Location = new System.Drawing.Point(536, 16);
        _btnCloseGiftCardAdd.Name = "_btnCloseGiftCardAdd";
        _btnCloseGiftCardAdd.Size = new System.Drawing.Size(88, 48);
        _btnCloseGiftCardAdd.TabIndex = 9;
        _btnCloseGiftCardAdd.Text = "Gift Add";
        // 
        // pnlExit
        // 
        _pnlExit.BackColor = System.Drawing.Color.Black;
        _pnlExit.Controls.Add(_btnCloseCheckNumber);
        _pnlExit.Controls.Add(_btnCloseRelease);
        _pnlExit.Controls.Add(_btnCloseExit);
        _pnlExit.Controls.Add(_btnClosePrint);
        _pnlExit.Controls.Add(_btnClosePrintAll);
        _pnlExit.Controls.Add(_btnCloseSplit);
        _pnlExit.Location = new System.Drawing.Point(16, 8);
        _pnlExit.Name = "_pnlExit";
        _pnlExit.Size = new System.Drawing.Size(288, 96);
        _pnlExit.TabIndex = 11;
        // 
        // btnCloseCheckNumber
        // 
        _btnCloseCheckNumber.BackColor = System.Drawing.Color.FromArgb(249, 200, 7);
        _btnCloseCheckNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnCloseCheckNumber.Location = new System.Drawing.Point(200, 0);
        _btnCloseCheckNumber.Name = "_btnCloseCheckNumber";
        _btnCloseCheckNumber.Size = new System.Drawing.Size(88, 48);
        _btnCloseCheckNumber.TabIndex = 9;
        _btnCloseCheckNumber.UseVisualStyleBackColor = false;
        // 
        // btnCloseRelease
        // 
        _btnCloseRelease.BackColor = System.Drawing.Color.LightSlateGray;
        _btnCloseRelease.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnCloseRelease.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _btnCloseRelease.Location = new System.Drawing.Point(0, 48);
        _btnCloseRelease.Name = "_btnCloseRelease";
        _btnCloseRelease.Size = new System.Drawing.Size(96, 48);
        _btnCloseRelease.TabIndex = 8;
        _btnCloseRelease.Text = "RELEASE";
        _btnCloseRelease.UseVisualStyleBackColor = false;
        // 
        // btnCloseSplit
        // 
        _btnCloseSplit.BackColor = System.Drawing.Color.LightSlateGray;
        _btnCloseSplit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnCloseSplit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _btnCloseSplit.Location = new System.Drawing.Point(200, 48);
        _btnCloseSplit.Name = "_btnCloseSplit";
        _btnCloseSplit.Size = new System.Drawing.Size(88, 48);
        _btnCloseSplit.TabIndex = 10;
        _btnCloseSplit.Text = "SPLIT";
        _btnCloseSplit.UseVisualStyleBackColor = false;
        // 
        // Panel3
        // 
        _Panel3.BackColor = System.Drawing.Color.Black;
        _Panel3.Controls.Add(_btnClosePayment);
        _Panel3.Controls.Add(_btnCloseMgr);
        _Panel3.Controls.Add(_btnClosePromo);
        _Panel3.Controls.Add(_pnlPaymentTypes);
        _Panel3.Location = new System.Drawing.Point(8, 16);
        _Panel3.Name = "_Panel3";
        _Panel3.Size = new System.Drawing.Size(512, 232);
        _Panel3.TabIndex = 13;
        // 
        // pnlClosePayments
        // 
        _pnlClosePayments.BackColor = System.Drawing.Color.Black;
        _pnlClosePayments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _pnlClosePayments.ForeColor = System.Drawing.Color.Black;
        _pnlClosePayments.Location = new System.Drawing.Point(318, 312);
        _pnlClosePayments.Name = "_pnlClosePayments";
        _pnlClosePayments.Size = new System.Drawing.Size(456, 384);
        _pnlClosePayments.TabIndex = 14;
        // 
        // pnlBalance
        // 
        _pnlBalance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _pnlBalance.Controls.Add(_lblBalanceDetail);
        _pnlBalance.Controls.Add(_btnAuthActive);
        _pnlBalance.Controls.Add(_btnAuthAll);
        _pnlBalance.Controls.Add(_lblBalance);
        _pnlBalance.Location = new System.Drawing.Point(318, 696);
        _pnlBalance.Name = "_pnlBalance";
        _pnlBalance.Size = new System.Drawing.Size(456, 72);
        _pnlBalance.TabIndex = 15;
        // 
        // lblBalanceDetail
        // 
        _lblBalanceDetail.BackColor = System.Drawing.Color.WhiteSmoke;
        _lblBalanceDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        _lblBalanceDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblBalanceDetail.Location = new System.Drawing.Point(336, 8);
        _lblBalanceDetail.Name = "_lblBalanceDetail";
        _lblBalanceDetail.Size = new System.Drawing.Size(112, 56);
        _lblBalanceDetail.TabIndex = 5;
        _lblBalanceDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // btnAuthActive
        // 
        _btnAuthActive.BackColor = System.Drawing.Color.LightSlateGray;
        _btnAuthActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnAuthActive.ForeColor = System.Drawing.Color.White;
        _btnAuthActive.Location = new System.Drawing.Point(160, 8);
        _btnAuthActive.Name = "_btnAuthActive";
        _btnAuthActive.Size = new System.Drawing.Size(120, 56);
        _btnAuthActive.TabIndex = 3;
        _btnAuthActive.Text = "Auth Active";
        _btnAuthActive.UseVisualStyleBackColor = false;
        // 
        // btnAuthAll
        // 
        _btnAuthAll.BackColor = System.Drawing.Color.LightSlateGray;
        _btnAuthAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnAuthAll.ForeColor = System.Drawing.Color.White;
        _btnAuthAll.Location = new System.Drawing.Point(8, 8);
        _btnAuthAll.Name = "_btnAuthAll";
        _btnAuthAll.Size = new System.Drawing.Size(120, 56);
        _btnAuthAll.TabIndex = 2;
        _btnAuthAll.Text = "Auth All";
        _btnAuthAll.UseVisualStyleBackColor = false;
        // 
        // lblBalance
        // 
        _lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblBalance.ForeColor = System.Drawing.Color.White;
        _lblBalance.Location = new System.Drawing.Point(304, 8);
        _lblBalance.Name = "_lblBalance";
        _lblBalance.Size = new System.Drawing.Size(64, 16);
        _lblBalance.TabIndex = 1;
        _lblBalance.Text = "Bal";
        _lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // btnRemove
        // 
        _btnRemove.BackColor = System.Drawing.Color.LightSlateGray;
        _btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnRemove.ForeColor = System.Drawing.Color.White;
        _btnRemove.Location = new System.Drawing.Point(128, 8);
        _btnRemove.Name = "_btnRemove";
        _btnRemove.Size = new System.Drawing.Size(104, 56);
        _btnRemove.TabIndex = 4;
        _btnRemove.Text = "Remove";
        _btnRemove.UseVisualStyleBackColor = false;
        // 
        // pnlPayRemove
        // 
        _pnlPayRemove.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _pnlPayRemove.Controls.Add(_btnMorePayments);
        _pnlPayRemove.Controls.Add(_btnRemove);
        _pnlPayRemove.Location = new System.Drawing.Point(780, 312);
        _pnlPayRemove.Name = "_pnlPayRemove";
        _pnlPayRemove.Size = new System.Drawing.Size(240, 72);
        _pnlPayRemove.TabIndex = 16;
        // 
        // btnMorePayments
        // 
        _btnMorePayments.BackColor = System.Drawing.Color.LightSlateGray;
        _btnMorePayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnMorePayments.ForeColor = System.Drawing.Color.White;
        _btnMorePayments.Location = new System.Drawing.Point(8, 8);
        _btnMorePayments.Name = "_btnMorePayments";
        _btnMorePayments.Size = new System.Drawing.Size(104, 56);
        _btnMorePayments.TabIndex = 5;
        _btnMorePayments.Text = "More Payments";
        _btnMorePayments.UseVisualStyleBackColor = false;
        _btnMorePayments.Visible = false;
        // 
        // btnDup
        // 
        _btnDup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnDup.Location = new System.Drawing.Point(536, 144);
        _btnDup.Name = "_btnDup";
        _btnDup.Size = new System.Drawing.Size(88, 48);
        _btnDup.TabIndex = 17;
        _btnDup.Text = "Duplicate Credit";
        // 
        // btnVoiceAuth
        // 
        _btnVoiceAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnVoiceAuth.Location = new System.Drawing.Point(536, 208);
        _btnVoiceAuth.Name = "_btnVoiceAuth";
        _btnVoiceAuth.Size = new System.Drawing.Size(88, 48);
        _btnVoiceAuth.TabIndex = 18;
        _btnVoiceAuth.Text = "Voice Auth";
        // 
        // pnlPayOptions
        // 
        _pnlPayOptions.BackColor = System.Drawing.Color.LightSlateGray;
        _pnlPayOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        _pnlPayOptions.Controls.Add(_btnDemoCC);
        _pnlPayOptions.Controls.Add(_btnVoiceAuth);
        _pnlPayOptions.Controls.Add(_btnDup);
        _pnlPayOptions.Controls.Add(_btnCloseAutoTip);
        _pnlPayOptions.Controls.Add(_btnCloseGiftCardAdd);
        _pnlPayOptions.Controls.Add(_Panel3);
        _pnlPayOptions.Location = new System.Drawing.Point(352, 16);
        _pnlPayOptions.Name = "_pnlPayOptions";
        _pnlPayOptions.Size = new System.Drawing.Size(640, 272);
        _pnlPayOptions.TabIndex = 19;
        // 
        // btnDemoCC
        // 
        _btnDemoCC.BackColor = System.Drawing.Color.LightSteelBlue;
        _btnDemoCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnDemoCC.Location = new System.Drawing.Point(531, 203);
        _btnDemoCC.Name = "_btnDemoCC";
        _btnDemoCC.Size = new System.Drawing.Size(104, 64);
        _btnDemoCC.TabIndex = 20;
        _btnDemoCC.Text = "Demo Card Swipe";
        _btnDemoCC.UseVisualStyleBackColor = false;
        _btnDemoCC.Visible = false;
        // 
        // NumberPadLarge1
        // 
        _NumberPadLarge1.BackColor = System.Drawing.Color.DarkGray;
        _NumberPadLarge1.DecimalUsed = false;
        _NumberPadLarge1.ForeColor = System.Drawing.Color.CornflowerBlue;
        _NumberPadLarge1.IntegerNumber = 0;
        _NumberPadLarge1.Location = new System.Drawing.Point(778, 394);
        _NumberPadLarge1.Name = "_NumberPadLarge1";
        _NumberPadLarge1.NumberString = "";
        _NumberPadLarge1.NumberTotal = new decimal(new int[] { 0, 0, 0, 0 });
        _NumberPadLarge1.Size = new System.Drawing.Size(244, 370);
        _NumberPadLarge1.TabIndex = 20;
        // 
        // CloseCheck
        // 
        this.BackColor = System.Drawing.Color.Black;
        this.Controls.Add(_NumberPadLarge1);
        this.Controls.Add(_pnlPayOptions);
        this.Controls.Add(_pnlPayRemove);
        this.Controls.Add(_pnlBalance);
        this.Controls.Add(_pnlClosePayments);
        this.Controls.Add(_pnlExit);
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        this.Name = "CloseCheck";
        this.Size = new System.Drawing.Size(1024, 768);
        _pnlPaymentTypes.ResumeLayout(false);
        _pnlExit.ResumeLayout(false);
        _Panel3.ResumeLayout(false);
        _pnlBalance.ResumeLayout(false);
        _pnlPayRemove.ResumeLayout(false);
        _pnlPayOptions.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion


    private void InitializeOther(int closingCheck)
    {

        try
        {
            // need to zero out all decimals
            _checkGiftIssuingAmount = 0m;

            if (!(typeProgram == "Online_Demo"))
            {
                if (companyInfo.processor == "Mercury")
                {
                    dsi = new DSICLIENTXLib.DSICLientX();
                }
            }

            DetermineTruncatedExperienceNumber();
            closeTimeoutCounter = 1;

            if (typeProgram == "Online_Demo")
            {
                btnDemoCC.Visible = true;
                btnDemoCC.BringToFront();
            }
            // AddHandler closeInactiveTimer.Tick, AddressOf InactiveScreenTimeout
            // closeInactiveTimer.Interval = timeoutInterval
            // closeInactiveTimer.Start()

            // paymentRowIndex = dsOrder.Tables("PaymentsAndCredits").Rows.Count()
            CreateClosingDataViews(closingCheck, true);
            paymentRowIndex = dvClosingCheckPayments.Count;

            GetNumberOfActivePayments(closingCheck);

            UpdateCheckNumberButton();

            closeCheckTotals = new CheckTotal_UC();
            closeCheckTotals.Location = new Point(4, 112);
            this.Controls.Add(closeCheckTotals);

            // 444     DisplayAnyStoredPayments()
            // this is before balance info, so we don't have to save amounts
            // and if the amounts change, which probably would if we exit closecheck

            RemainingBalance = closeCheckTotals.AttachTotalsToTotalView(currentTable.CheckNumber);
            TotalCheckBalance = closeCheckTotals.TotalCheckBalance;
            ShowRemainingBalance();

            PreAuthAmountClass authamount;
            PreAuthTransactionClass authTransaction;

            // 444      readAuth = New ReadCredit(False)
            // 444   readAuth.GiftAddingAmount = False

            GenerateOrderTables.CreatespiderPOSDirectory();
        }

        catch (Exception ex)
        {

            Interaction.MsgBox(ex.Message);
        }

    }


    private void ResetTimer()
    {

        closeTimeoutCounter = 1;

    }

    private void AddGeneratedControlsToPaymentPanel()
    {

        pnlPaymentTypes.Controls.Add(btnCloseGift);
        pnlPaymentTypes.Controls.Add(btnCloseManualcc);
        pnlPaymentTypes.Controls.Add(btnClose1);
        pnlPaymentTypes.Controls.Add(btnClose5);
        pnlPaymentTypes.Controls.Add(btnClose10);
        pnlPaymentTypes.Controls.Add(btnClose20);
        pnlPaymentTypes.Controls.Add(btnClose50);
        pnlPaymentTypes.Controls.Add(btnClose100);
        pnlPaymentTypes.Controls.Add(btnCloseCash);

    }

    private void CreateInitialPanelsForThisCheck222(int closingCheck)
    {

        if (dvClosingCheckPayments.Count > 5)              // paymentRowIndex > 5 Then
        {
            paymentPanel = new DataSet_Builder.Payment_UC[dvClosingCheckPayments.Count + 1];  // (paymentRowIndex)
            btnMorePayments.Visible = true;
        }



    }

    private object GetNumberOfActivePayments(int closingCheck)
    {

        DataRowView vRow;
        var count = default(int);
        var position = default(int);
        decimal giftBalance = 0m;

        pnlClosePayments.Controls.Clear();
        // unappliedRowIndex = 0

        if (dvClosingCheckPayments.Count + dvUnAppliedPaymentsAndCredits_MWE.Count > 5)              // paymentRowIndex > 5 Then
        {
            paymentPanel = new DataSet_Builder.Payment_UC[dvClosingCheckPayments.Count + 1];  // (paymentRowIndex)
            btnMorePayments.Visible = true;
        }

        // For Each vRow In dvUnAppliedPaymentsAndCredits  'dvClosingCheckPayments      'oRow In dsOrder.Tables("PaymentsAndCredits").Rows
        // count += 1
        // If count >= startPaymentIndex And count <= (startPaymentIndex + 5) Then
        // CreateNewPaymentPanel(vRow, count, position)
        // 'old      unappliedRowIndex += 1
        // position += 1
        // End If
        // Next

        foreach (DataRowView currentVRow in dvUnAppliedPaymentsAndCredits_MWE)
        {
            vRow = currentVRow; // dvappliedpayments
            if (vRow("PaymentFlag") == "Gift" | vRow("PaymentFlag") == "Issue") // And vRow("AuthCode") Is DBNull.Value Then
            {
                if (object.ReferenceEquals(vRow("AuthCode"), DBNull.Value))
                {
                    giftBalance = Conversions.ToDecimal(DetermineGiftBalance(ref vRow));
                }
                else
                {
                    var newPayment = new Payment();
                    // this is only to send balance
                    newPayment.RefNo = vRow("RefNum");
                    newPayment.AccountNumber = vRow("AccountNumber");
                    GenerateOrderTables.GiftCardTransaction(default, newPayment, "Balance");
                    giftBalance = newPayment.Balance;
                }

            }
            count += 1;
            if (count >= startPaymentIndex & count <= startPaymentIndex + 5)
            {
                CreateNewPaymentPanel(ref vRow, count, position, giftBalance);
                position += 1;
            }
        }

        foreach (DataRowView currentVRow1 in dvClosingCheckPayments)
        {
            vRow = currentVRow1; // dvappliedpayments
            if (vRow("PaymentFlag") == "Gift" | vRow("PaymentFlag") == "Issue") // And vRow("AuthCode") Is DBNull.Value Then
            {
                if (object.ReferenceEquals(vRow("AuthCode"), DBNull.Value))
                {
                    giftBalance = Conversions.ToDecimal(DetermineGiftBalance(ref vRow));
                }
                else
                {
                    var newPayment = new Payment();
                    // this is only to send balance
                    newPayment.RefNo = vRow("RefNum");
                    newPayment.AccountNumber = vRow("AccountNumber");
                    GenerateOrderTables.GiftCardTransaction(default, newPayment, "Balance");
                    giftBalance = newPayment.Balance;
                }

            }
            count += 1;
            if (count >= startPaymentIndex & count <= startPaymentIndex + 5)
            {
                CreateNewPaymentPanel(ref vRow, count, position, giftBalance);
                position += 1;
            }
        }

        numActivePaymentsByCheck = count;
        paymentRowIndex = dvClosingCheckPayments.Count + dvUnAppliedPaymentsAndCredits_MWE.Count;
        ActiveThisPanel(paymentRowIndex);    // tried with 1 to activate last new payment
        // too many things refer to paymentRowIndex
        // is probably better flow with 1
        ShowRemainingBalance();
        return default;

    }

    // we need to determine Gift Balance
    private object DetermineGiftBalance(ref DataRowView vRow)
    {
        decimal giftBalance = 0m;

        foreach (Payment giftPayment in tabcc)
        {
            if (giftPayment.experienceNumber == vRow("ExperienceNumber"))
            {
                if (giftPayment.AccountNumber == vRow("AccountNumber"))
                {
                    giftBalance = giftPayment.Balance;
                }
            }
        }
        return giftBalance;
    }
    private void btnMorePayments_Click(object sender, EventArgs e)
    {

        startPaymentIndex += 1;
        if (startPaymentIndex + 0 > paymentRowIndex)
        {
            startPaymentIndex = 1;
            paymentRowIndex = 1;
        }
        GetNumberOfActivePayments(currentTable.CheckNumber);

    }

    private void btnClosePromo_Click(object sender, EventArgs e)
    {
        ResetTimer();

        pnlPaymentTypes.Controls.Clear();
        var index = default(int);
        int x = 8;
        int y = 8;
        // ReDim Me.PromotionApplied(20) '(dsClosing.Tables("Promotion").Rows.Count - 1)

        foreach (DataRow oRow in ds.Tables("Promotion").Rows)
        {
            btnPromo[index] = new KitchenButton(oRow("PromoName"), 120, 56, c17, c2);
            {
                ref var withBlock = ref btnPromo[index];
                // .Size = New Size(112, 48)
                if (oRow("PromoName").Length > 15)
                {
                    withBlock.Font = new Font("Comic Sans MS", 10.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
                }

                withBlock.Location = new Point(x, y);
                // .Text = oRow("PromoName")
                withBlock.ID = oRow("PromoID");
                withBlock.ButtonIndex = index;
                // .BackColor = c6
                withBlock.ForeColor = c3;

            }

            this.btnPromo[index].Click += PromoSelect;
            pnlPaymentTypes.Controls.Add(btnPromo[index]);
            index += 1;
            if (index == 3 | index == 6)
            {
                x = x + 128;
                y = 8;
            }
            else if (index == 9)
            {
                // max amount of promos
                return;
            }
            else
            {
                y = y + 64;
            }
        }

    }

    private void PromoSelect(object sender, EventArgs e)
    {
        btnKitchen = new KitchenButton("ForTestOnly", 0, 0, c3, c2);

        if (!object.ReferenceEquals(sender.GetType(), btnKitchen.GetType))
            return;

        // If typeProgram = "Online_Demo" Then
        // DemoThisNotAvail
        // Exit Sub
        // End If

        KitchenButton objButton;
        DataRow oRow;
        objButton = (KitchenButton)sender;

        if (PromotionApplied[objButton.ButtonIndex] == false)
        {
            oRow = ds.Tables("Promotion").Rows.Find(objButton.ID);
            SavingForOpenOrderID(ref oRow, objButton.ID, objButton.ButtonIndex);
        }

        else
        {
            Interaction.MsgBox("This Promotion has already been Applied");
        }


    }

    private void SavingForOpenOrderID(ref DataRow promoRow, int promoID, int btnIndex)
    {
        bool noOpenOrderID = false;

        foreach (DataRowView vRow in dvOrder) // dvClosingCheck
        {
            if (object.ReferenceEquals(vRow("OpenOrderID"), DBNull.Value))
            {
                noOpenOrderID = true;
                break;
            }
        }

        // *****************
        // not working when we need to get OpenOrderID's
        // it is only saving some of the new promo info
        // must be something to do with the dataviews

        if (noOpenOrderID == true)
        {
            SaveOpenOrderData();
            closeCheckTotals.grdCloseCheck.DataSource = (object)null;
            DisposeDataViewsOrder();
            PopulateThisExperience(currentTable.ExperienceNumber, false);
            // 444    CreateDataViewsOrder()
            // dvOrder.RowFilter = "CheckNumber ='" & currentTable.CheckNumber & "'"
            ReinitializeCloseCheck(true);
        }

        RunPromotionRoutine(ref promoRow, promoID, btnIndex);

    }
    private void RunPromotionRoutine(ref DataRow promoRow, int promoID, int btnIndex)
    {
        DataRowView vRow;
        var compNextItem = default(int);
        int possibleBuyAmount;
        var totalBuyAmount = default(int);
        int index;
        SelectedItemDetail ni;
        int compQuantity;

        // ****************************
        // Promo BSGS
        ForceFreeInfo ffInfo;
        var iPromo = default(ItemPromoInfo);

        iPromo.PromoCode = promoID;
        iPromo.PromoName = "  **  " + promoRow("PromoName");
        iPromo.empID = currentServer.EmployeeID;

        try
        {
            // sql.cn.Open()
            // sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery()

            if (promoRow("BSGS") == true)
            {
                var buyAmount = default(int);
                var getAmount = default(int);

                dvBSGS = new DataView();
                {
                    ref var withBlock = ref dvBSGS;
                    withBlock.Table = ds.Tables("BSGS");
                    withBlock.RowFilter = "PromoID = '" + promoID + "'";
                }
                dvOrder.Sort = "Price ASC";     // ("CustomerNumber, sii, sin")

                // CheckMaxDollarAmount(promoRow)
                // CheckMaxCheckAmount(promoRow)
                // CheckMaxTableAmount(promoRow)

                foreach (DataRowView currentVRow in dvOrder)
                {
                    vRow = currentVRow;

                    if (vRow("ForceFreeID") == 0) // And vRow("ItemID") > 0 Then 
                    {

                        // *** currently promo flags like this are only "F" or "D"
                        if (this.dvBSGS(0)("BuyFD_flag") == "F")
                        {

                            if ((vRow("FunctionFlag") == "F" | vRow("FunctionFlag") == "O") & vRow("CategoryID") == this.dvBSGS(0)("BuyCategoryID"))
                            {
                                buyAmount += 1;
                                if (buyAmount >= this.dvBSGS(0)("BuyCategoryAmount"))
                                {
                                    compNextItem += 1;
                                    buyAmount = 0;
                                }
                            }
                        }
                        else if (this.dvBSGS(0)("BuyFD_flag") == "D")
                        {
                            if (vRow("FunctionFlag") == "D" & vRow("CategoryID") == this.dvBSGS(0)("BuyDrinkCategoryID"))
                            {
                                // same as above
                                buyAmount += 1;
                                if (buyAmount >= this.dvBSGS(0)("BuyCategoryAmount"))
                                {
                                    compNextItem += 1;
                                    buyAmount = 0;
                                }
                            }
                        }

                    }
                }
                // this will set the greatest amount to place as used buy item
                possibleBuyAmount = this.dvBSGS(0)("BuyCategoryAmount") * compNextItem;

                foreach (DataRowView currentVRow1 in dvOrder)
                {
                    vRow = currentVRow1;

                    if (vRow("ForceFreeID") == 0)     // And vRow("ItemID") > 0 Then
                    {

                        if (compNextItem > 0)
                        {
                            if (compNextItem < vRow("Quantity"))
                            {
                                compQuantity = compNextItem;
                            }
                            else
                            {
                                compQuantity = vRow("Quantity");
                            }

                            if (this.dvBSGS(0)("GetFD_flag") == "F")
                            {
                                if ((vRow("FunctionFlag") == "F" | vRow("FunctionFlag") == "O") & vRow("CategoryID") == this.dvBSGS(0)("GetCategoryID"))
                                {
                                    // here we are only coding the new row
                                    // leter we go back and code the old row

                                    vRow("ForceFreeID") = promoID * -1;

                                    iPromo.openOrderID = vRow("OpenOrderID");
                                    iPromo.taxID = vRow("TaxID");
                                    iPromo.sii = vRow("sii");
                                    iPromo.si2 = vRow("si2");
                                    // itemPrice is positive, .Price is negative
                                    // item price is orginal price
                                    // this price is is discount
                                    iPromo.Quantity = 0;   // compQuantity
                                    iPromo.ItemPrice = vRow("Price") * compQuantity * this.dvBSGS(0)("GetQuantityDiscount");
                                    iPromo.Price = vRow("Price") * compQuantity * this.dvBSGS(0)("GetQuantityDiscount");
                                    iPromo.TaxPrice = vRow("TaxPrice") * compQuantity * this.dvBSGS(0)("GetQuantityDiscount");

                                    iPromo.SinTax = vRow("SinTax") * compQuantity * this.dvBSGS(0)("GetQuantityDiscount");


                                    CompThisItem(iPromo);
                                    getAmount += 1;

                                }
                            }
                            else if (this.dvBSGS(0)("GetFD_flag") == "D")
                            {
                                if (vRow("FunctionFlag") == "D" & vRow("CategoryID") == this.dvBSGS(0)("GetDrinkCategoryID"))
                                {

                                    vRow("ForceFreeID") = promoID * -1;
                                    iPromo.openOrderID = vRow("OpenOrderID");
                                    iPromo.taxID = vRow("TaxID");
                                    iPromo.sii = vRow("sii");
                                    iPromo.si2 = vRow("si2");
                                    // itemPrice is positive, .Price is negative
                                    // item price is orginal price
                                    // this price is is discount
                                    iPromo.Quantity = 0;   // compQuantity
                                    iPromo.ItemPrice = vRow("Price") * compQuantity * this.dvBSGS(0)("GetQuantityDiscount");
                                    iPromo.Price = vRow("Price") * compQuantity * this.dvBSGS(0)("GetQuantityDiscount");
                                    iPromo.TaxPrice = vRow("TaxPrice") * compQuantity * this.dvBSGS(0)("GetQuantityDiscount");
                                    iPromo.SinTax = vRow("SinTax") * compQuantity * this.dvBSGS(0)("GetQuantityDiscount");

                                    CompThisItem(iPromo);
                                    getAmount += 1;

                                }
                            }

                            if (getAmount >= this.dvBSGS(0)("GetCategoryAmount"))
                            {
                                compNextItem -= 1 * compQuantity;
                                totalBuyAmount = totalBuyAmount + this.dvBSGS(0)("BuyCategoryAmount");
                                getAmount = 0;
                            }
                        }
                    }
                }

                // ***    below marks buy items used for discount

                foreach (SelectedItemDetail currentNi in newItemCollection)
                {
                    ni = currentNi;
                    GenerateOrderTables.PopulateDataRowForOpenOrder(ni);
                }
                newItemCollection.Clear();

                if (possibleBuyAmount < totalBuyAmount)
                {
                    totalBuyAmount = possibleBuyAmount;
                }

                foreach (DataRowView currentVRow2 in dvOrder)
                {
                    vRow = currentVRow2;
                    if (totalBuyAmount > 0)
                    {
                        if (vRow("ForceFreeID") == 0)     // And vRow("ItemID") > 0 Then
                        {
                            if (this.dvBSGS(0)("BuyFD_flag") == "F")
                            {
                                if ((vRow("FunctionFlag") == "F" | vRow("FunctionFlag") == "O") & vRow("CategoryID") == this.dvBSGS(0)("BuyCategoryID"))
                                {
                                    vRow("ForceFreeID") = promoID * -1;
                                    totalBuyAmount -= 1 * vRow("Quantity");
                                }
                            }
                            else if (this.dvBSGS(0)("BuyFD_flag") == "D")
                            {
                                if (vRow("FunctionFlag") == "D" & vRow("CategoryID") == this.dvBSGS(0)("BuyDrinkCategoryID"))
                                {
                                    vRow("ForceFreeID") = promoID * -1;
                                    totalBuyAmount -= 1 * vRow("Quantity");
                                }
                            }
                        }
                    }
                }

                dvOrder.Sort = "CustomerNumber, sii, si2, sin";
            }



            // *********************************
            // Combo

            else if (promoRow("Combo") == true)
            {

                // sql.cn.Close()
                Interaction.MsgBox("There are no Combo Promotions, call SpiderPOS as 404.869.4700.");
                return;

                DataRow cpRow;
                DataRowView vComboRow;
                index = 0;
                int numberOfCombosPerCategory;
                int numberOfCombosPerCheck;

                int comboCategoryIndex;

                dvCombo = new DataView();
                {
                    ref var withBlock1 = ref dvCombo;
                    withBlock1.Table = ds.Tables("Combo");
                    withBlock1.RowFilter = "PromoID = '" + promoID + "'";
                }
                cpRow = ds.Tables("ComboDetail").Rows.Find(promoID);
                comboPrice = cpRow("ComboPrice");

                // determines # of items per category
                comboCategoryIndex = dvCombo.Count - 1;
                var comboCount = new int[comboCategoryIndex + 1];
                var closingCount = new int[comboCategoryIndex + 1];

                // ccr is comboCustomerRecord
                // row 0 is empty to keep track by customer number (unless no cust number is input)
                // ccr(1,2) = 3 means customer#`1 orderer 3 of the 3rd(zero indexed) category 


                // *******************************
                // customerNumber should not be zero
                // Dim ccr(customerNumber, comboCategoryIndex) As Integer
                var ccr = new int[2, comboCategoryIndex + 1];



                foreach (DataRowView currentVComboRow in dvCombo)
                {
                    vComboRow = currentVComboRow;

                    comboCount[index] = vComboRow("ComboCategoryMax");

                    // determines # of items in check (belonging to combo category)
                    foreach (DataRowView currentVRow3 in dvOrder)
                    {
                        vRow = currentVRow3; // dvClosingCheck

                        if (vRow("ForceFreeID") == 0)         // And vRow("ItemID") > 0 Then
                        {
                            if (vComboRow("ComboFD_flag") == "F")
                            {
                                if ((vRow("FunctionFlag") == "F" | vRow("FunctionFlag") == "O") & vRow("CategoryID") == vComboRow("ComboCategoryID"))
                                {
                                    ccr[vRow("CustomerNumber"), index] += 1;
                                    closingCount[index] += 1;
                                }
                            }
                            else if (vComboRow("ComboFD_flag") == "D")
                            {
                                if (vRow("FunctionFlag") == "D" & vRow("CategoryID") == vComboRow("ComboDrinkCategoryID"))
                                {
                                    ccr[vRow("CustomerNumber"), index] += 1;
                                    closingCount[index] += 1;
                                }
                            }
                        }
                        // MsgBox(ccr(vRow("CustomerNumber"), index))
                    }
                    // MsgBox(("CustomerNumber"))
                    index += 1;
                }

                // determines the category w/ the lowest number of combo possiblities
                // end result is numberOfCombosPerCheck
                index = 0;
                foreach (DataRowView currentVComboRow1 in dvCombo)
                {
                    vComboRow = currentVComboRow1;
                    // MsgBox(closingCount(index), , "Closing")
                    // 
                    if (comboCount[index] == 0)
                        return; // means there are no items in promo
                    if (closingCount[index] < comboCount[index])
                    {
                        numberOfCombosPerCheck = 0;
                        Interaction.MsgBox("You do not have all the items to make a Combo");
                        return;
                    }
                    else
                    {
                        // this number does not work yet(it currently rounds up)
                        // it needs to be truncated for fractions(3/2 should = 1)
                        numberOfCombosPerCategory = (int)Math.Round(closingCount[index] / (double)comboCount[index]);
                        if (numberOfCombosPerCheck == 0)
                        {
                            numberOfCombosPerCheck = numberOfCombosPerCategory;
                        }
                        else if (numberOfCombosPerCategory < numberOfCombosPerCheck)
                        {
                            numberOfCombosPerCheck = numberOfCombosPerCategory;
                        }
                    }

                    index += 1;
                }


                // if customerBoolean is true then customer satifies all combo purchases
                int c;        // customer index
                int cmb;      // combo index
                var customerBoolean = new int[customerNumber + 1]; // Boolean
                var comboSatisfied = new bool[dvCombo.Count + 1];
                bool customerFilled;
                int itemsCredited;

                var loopTo = customerNumber;
                for (c = 0; c <= loopTo; c++)
                {
                    var loopTo1 = comboCategoryIndex;
                    for (cmb = 0; cmb <= loopTo1; cmb++)
                    {
                        if (comboCount[cmb] > 0) // if zero: customerBoolean(c) stays the same
                        {
                            if (closingCount[cmb] < comboCount[cmb])
                            {
                                // this means cust did not order enough of combo items
                                customerBoolean[c] = 0;
                                break;
                            }
                            else if (customerBoolean[c] == 0)  // 0 means just assigning value
                            {
                                customerBoolean[c] = closingCount[cmb];
                            }
                            else if (closingCount[cmb] < customerBoolean[c])
                            {
                                // this assigns the lowest possible value that's not zero
                                // its not zero b/c zero would have been assigned above
                                customerBoolean[c] = closingCount[cmb];
                            }
                        }

                        // if this passes one combo criteria is not met for this customer
                        // If ccr(c, cmb) < comboCount(cmb) Then
                        // Exit For
                        // End If
                        // '   if this passes we passed all the above for each combo category
                        // If cmb = comboCategoryIndex Then
                        // customerBoolean(c) += 1 'True
                        // End If
                    }
                }

                c = 0;


                // at this point we will take numberOfCombosPerCheck and reduce by 1 until 0
                foreach (DataRowView currentVRow4 in dvOrder)
                {
                    vRow = currentVRow4; // dvClosingCheck

                    if (vRow("ForceFreeID") == 0)         // And vRow("ItemID") > 0 Then
                    {

                        cmb = 0;
                        c = vRow("CustomerNumber");
                        if (customerBoolean[c] > 0) // = True Then
                        {
                            foreach (DataRowView currentVComboRow2 in dvCombo)
                            {
                                vComboRow = currentVComboRow2;
                                if (ccr[c, cmb] > 0) // comboSatisfied(cmb) = False Then
                                {
                                    if (vComboRow("ComboFD_flag") == "F")
                                    {
                                        if ((vRow("FunctionFlag") == "F" | vRow("FunctionFlag") == "O") & vRow("CategoryID") == vComboRow("ComboCategoryID"))
                                        {

                                            if (numberOfCombosPerCheck < vRow("Quantity"))
                                            {

                                            }


                                            // 222
                                            ffInfo = new ForceFreeInfo();
                                            ffInfo.DailyCode = currentTerminal.CurrentDailyCode;
                                            ffInfo.ExpNum = currentTable.ExperienceNumber;
                                            ffInfo.OpenOrderID = vRow("OpenOrderID");
                                            ffInfo.AuthID = currentServer.EmployeeID;
                                            ffInfo.Price = 0; // vRow("Price")
                                            ffInfo.TaxID = vRow("TaxID");
                                            ffInfo.TaxPrice = 0; // vRow("TaxPrice")
                                            ffInfo.AmountDiscount = vRow("Price");
                                            ffInfo.TaxDicount = vRow("TaxPrice") + vRow("SinTax");

                                            ffInfo.PromoID = vComboRow("PromoID");
                                            ffInfo.PromoPrice = vRow("Price");

                                            // 222       GenerateOrderTables.CreateNewOrderForceFree(ffInfo)
                                            // 09.10
                                            if (ffInfo.ffID > 0)
                                            {
                                                vRow("ForceFreeID") = ffInfo.ffID;
                                            }
                                            else
                                            {
                                                vRow("ForceFreeID") = -2;
                                                // vRow("ForceFreeID") = vComboRow("PromoID")
                                            }
                                            vRow("ForceFreeCode") = 0;   // vRow("Price")
                                            // vRow("ItemName") = vRow("ItemName") & " ** Combo  " & currentTable.PromoNumber 'vRow("CustomerNumber")
                                            vRow("TerminalName") = vRow("ItemName") + " ** Combo  " + currentTable.PromoNumber; // vRow("CustomerNumber")
                                            vRow("Price") = 0;
                                            vRow("TaxPrice") = 0;
                                            vRow("SinTax") = 0;

                                            ccr[c, cmb] -= 1;
                                            itemsCredited += 1;
                                            customerFilled = DetermineNumberCredited(ref itemsCredited, dvCombo.Count, comboPrice, promoRow("PromoID"), promoRow("PromoName"), vRow("CustomerNumber"), vRow("sii"));
                                            if (customerFilled == true)
                                            {
                                                customerBoolean[vRow("CustomerNumber")] -= 1;
                                            }
                                        }
                                    }

                                    else if (vComboRow("ComboFD_flag") == "D")
                                    {
                                        if (vRow("FunctionFlag") == "D" & vRow("CategoryID") == vComboRow("ComboDrinkCategoryID"))
                                        {
                                            ffInfo = new ForceFreeInfo();
                                            ffInfo.DailyCode = currentTerminal.CurrentDailyCode;
                                            ffInfo.ExpNum = currentTable.ExperienceNumber;
                                            ffInfo.OpenOrderID = vRow("OpenOrderID");
                                            ffInfo.AuthID = currentServer.EmployeeID;
                                            ffInfo.PromoID = vComboRow("PromoID");
                                            ffInfo.PromoPrice = vRow("Price");
                                            ffInfo.Price = 0; // vRow("Price")
                                            ffInfo.TaxID = vRow("TaxID");
                                            ffInfo.TaxPrice = 0; // vRow("TaxPrice")
                                            ffInfo.AmountDiscount = vRow("Price");
                                            ffInfo.TaxDicount = vRow("TaxPrice") + vRow("SinTax");

                                            // 222        GenerateOrderTables.CreateNewOrderForceFree(ffInfo)
                                            // 09.10
                                            if (ffInfo.ffID > 0)
                                            {
                                                vRow("ForceFreeID") = ffInfo.ffID;
                                            }
                                            else
                                            {
                                                vRow("ForceFreeID") = -2;
                                                // vRow("ForceFreeID") = vComboRow("PromoID")
                                            }
                                            vRow("ForceFreeCode") = 0;   // vRow("Price")
                                            // vRow("ItemName") = vRow("ItemName") & " ** Combo  " & currentTable.PromoNumber 'vRow("CustomerNumber")
                                            vRow("TerminalName") = vRow("ItemName") + " ** Combo  " + currentTable.PromoNumber; // vRow("CustomerNumber")
                                            vRow("Price") = 0;
                                            vRow("TaxPrice") = 0;
                                            vRow("SinTax") = 0;

                                            ccr[c, cmb] -= 1;
                                            itemsCredited += 1;
                                            customerFilled = DetermineNumberCredited(ref itemsCredited, dvCombo.Count, comboPrice, promoRow("PromoID"), promoRow("PromoName"), vRow("CustomerNumber"), vRow("sii"));
                                            if (customerFilled == true)
                                            {
                                                customerBoolean[vRow("CustomerNumber")] -= 1;
                                            }
                                        }
                                    }
                                }
                                else
                                {

                                }
                                // AddPromoToOrderTable(comboPrice, promoRow("PromoID"), promoRow("PromoName"), vRow("CustomerNumber"), vRow("sii"))
                                cmb += 1;
                            }

                            // must add another routine if we want to circle back and offer 
                            // combos to multiple customers (ie. cust 1 orders Item1, cust 2 ord item3)
                            // If comboSatisfied(cmb) = True Then AddPromoToOrderTable(comboPrice, promoRow("PromoID"), promoRow("PromoName"), vRow("CustomerNumber"), vRow("sii"))
                        }
                    }


                }




                // MsgBox(numberOfCombosPerCheck, , "#Combos per check")
                // ********** we need test here to make sure numberofcombospercheck is not > promotion limit

                // now we must plug this number back into each category to see how many 
                // items to subtract from check
                // Example:
                // If (category 1) needs 2 items for combo
                // (category 2) needs 1 item for combo
                // check has 6 of (category 1)       6 / 2 = 3
                // check has 4 of (category 2)       4 / 1 = 4
                // but we can only get 3 combos from this (the lowest number)
                // so we look for 3 * 2 of (category 1)
                // and            3 * 1 of (category 2)
                index = 0;
                foreach (DataRowView currentVComboRow3 in dvCombo)
                {
                    vComboRow = currentVComboRow3;
                    comboCount[index] = numberOfCombosPerCheck * vComboRow("ComboCategoryMax");
                    index += 1;
                }
            }


            // **************************************
            // Coupon

            else if (promoRow("Coupon") == true)
            {
                int AtleastCatAmount;
                var NumberOfCouponsToApply = default(int);
                int maxToDiscount;
                var maxDiscCount = default(int);

                dvCoupon = new DataView();
                {
                    ref var withBlock2 = ref dvCoupon;
                    withBlock2.Table = ds.Tables("Coupon");
                    withBlock2.RowFilter = "PromoID = '" + promoID + "'";
                }
                // dvOrder.Sort = "Price DESC"     '("CustomerNumber, sii, sin")


                // this just determines how many coupons we can apply to check
                AtleastCatAmount = this.dvCoupon(0)("AtleastCategoryAmount");
                maxToDiscount = this.dvCoupon(0)("DiscountCategoryAmount");

                foreach (DataRowView currentVRow5 in dvOrder)
                {
                    vRow = currentVRow5;
                    if (vRow("ForceFreeID") == promoID * -1)
                    {
                        maxDiscCount += 1;
                        if (maxDiscCount == maxToDiscount)
                        {
                            // sql.cn.Close()
                            Interaction.MsgBox("We have already applied this coupon to its maximum.");
                            return;
                        }
                    }
                }

                if (AtleastCatAmount > 0)
                {
                    foreach (DataRowView currentVRow6 in dvOrder)
                    {
                        vRow = currentVRow6;

                        if (vRow("ForceFreeID") == 0)     // And vRow("ItemID") > 0 Then
                        {
                            if (this.dvCoupon(0)("AtleastFD_flag") == "F")
                            {
                                if (vRow("FunctionFlag") == "F" | vRow("FunctionFlag") == "O")
                                {
                                    if (vRow("CategoryID") == this.dvCoupon(0)("AtleastCategoryID"))
                                    {
                                        AtleastCatAmount -= 1 * vRow("Quantity");
                                        if (AtleastCatAmount <= 0)   // this means we satisfied min
                                        {
                                            NumberOfCouponsToApply += this.dvCoupon(0)("DiscountCategoryAmount");
                                            break;
                                        }
                                    }
                                }
                            }
                            else if (this.dvCoupon(0)("AtleastFD_flag") == "D")
                            {
                                if (vRow("FunctionFlag") == "D")
                                {
                                    if (vRow("CategoryID") == this.dvCoupon(0)("AtleastDrinkCategoryID"))
                                    {
                                        AtleastCatAmount -= 1 * vRow("Quantity");
                                        if (AtleastCatAmount <= 0)   // this means we satisfied min
                                        {
                                            NumberOfCouponsToApply += this.dvCoupon(0)("DiscountCategoryAmount");
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    // this means there was no minumum req.
                    NumberOfCouponsToApply = this.dvCoupon(0)("DiscountCategoryAmount");
                }     // this is max allowed

                // Dim discountingSIN As Integer
                // Dim adjustingRow As Integer
                decimal newPrice;
                decimal newTax;
                decimal newSinTax;
                var amountSavedCoupon = default(decimal);
                decimal taxSavedCoupon;

                // this will deduct the most expensive first
                index = 0;
                if (NumberOfCouponsToApply > 0)
                {
                    foreach (DataRowView currentVRow7 in dvOrder)
                    {
                        vRow = currentVRow7;

                        if (vRow("ForceFreeID") == 0)     // And vRow("ItemID") > 0 Then
                        {
                            if (this.dvCoupon(0)("AtleastFD_flag") == "F")
                            {

                                if ((vRow("FunctionFlag") == "F" | vRow("FunctionFlag") == "O") & vRow("CategoryID") == this.dvCoupon(0)("DiscountCategoryID"))
                                {
                                    if (this.dvCoupon(0)("CouponDollarFlag") == true)
                                    {
                                        amountSavedCoupon = this.dvCoupon(0)("CouponDollarAmount");
                                    }
                                    else if (this.dvCoupon(0)("CouponPercentFlag") == true)
                                    {
                                        amountSavedCoupon = vRow("Price") * this.dvCoupon(0)("CouponPercentAmount");
                                    }

                                    if (vRow("ItemPrice") < amountSavedCoupon)
                                    {
                                        // we can't save more than the original amount of one item
                                        amountSavedCoupon = vRow("ItemPrice");
                                    }
                                    if (vRow("Quantity") > 1)
                                    {
                                        if (NumberOfCouponsToApply < vRow("Quantity"))
                                        {
                                            compQuantity = NumberOfCouponsToApply;
                                        }
                                        else
                                        {
                                            compQuantity = vRow("Quantity");
                                        }
                                    }
                                    else
                                    {
                                        compQuantity = vRow("Quantity");
                                    }

                                    amountSavedCoupon = amountSavedCoupon * compQuantity;

                                    vRow("ForceFreeID") = promoID * -1;
                                    iPromo.openOrderID = vRow("OpenOrderID");
                                    iPromo.taxID = vRow("TaxID");
                                    iPromo.sii = vRow("sii");
                                    iPromo.si2 = vRow("si2");
                                    iPromo.Quantity = 0;   // compQuantity
                                    iPromo.ItemPrice = vRow("Price");
                                    iPromo.Price = amountSavedCoupon;
                                    iPromo.TaxPrice = 0;
                                    iPromo.SinTax = 0;

                                    CompThisItem(iPromo);
                                    NumberOfCouponsToApply -= 1 * compQuantity;
                                    if (NumberOfCouponsToApply <= 0)
                                        break;

                                }
                            }

                            else if (this.dvCoupon(0)("AtleastFD_flag") == "D")
                            {
                                if (vRow("FunctionFlag") == "D" & vRow("CategoryID") == this.dvCoupon(0)("DiscountDrinkCategoryID"))
                                {
                                    if (this.dvCoupon(0)("CouponDollarFlag") == true)
                                    {
                                        amountSavedCoupon = this.dvCoupon(0)("CouponDollarAmount");
                                    }
                                    else if (this.dvCoupon(0)("CouponPercentFlag") == true)
                                    {
                                        amountSavedCoupon = vRow("Price") * this.dvCoupon(0)("CouponPercentAmount");
                                    }

                                    if (vRow("ItemPrice") < amountSavedCoupon)
                                    {
                                        // we can't save more than the original amount of one item
                                        amountSavedCoupon = vRow("ItemPrice");
                                    }
                                    if (vRow("Quantity") > 1)
                                    {
                                        if (NumberOfCouponsToApply < vRow("Quantity"))
                                        {
                                            compQuantity = NumberOfCouponsToApply;
                                        }
                                        else
                                        {
                                            compQuantity = vRow("Quantity");
                                        }
                                    }
                                    else
                                    {
                                        compQuantity = vRow("Quantity");
                                    }

                                    amountSavedCoupon = amountSavedCoupon * compQuantity;

                                    vRow("ForceFreeID") = promoID * -1;
                                    iPromo.openOrderID = vRow("OpenOrderID");
                                    iPromo.taxID = vRow("TaxID");
                                    iPromo.sii = vRow("sii");
                                    iPromo.si2 = vRow("si2");
                                    iPromo.Quantity = 0;   // compQuantity
                                    iPromo.ItemPrice = vRow("Price");
                                    iPromo.Price = amountSavedCoupon;
                                    iPromo.TaxPrice = 0;
                                    iPromo.SinTax = 0;

                                    CompThisItem(iPromo);
                                    NumberOfCouponsToApply -= 1 * compQuantity;
                                    if (NumberOfCouponsToApply <= 0)
                                        break;
                                }
                            }
                        }
                    }
                }
                foreach (SelectedItemDetail currentNi1 in newItemCollection)
                {
                    ni = currentNi1;
                    GenerateOrderTables.PopulateDataRowForOpenOrder(ni);
                }
                newItemCollection.Clear();
                // dvOrder.Sort = "CustomerNumber, sii, si2, sin"

            }
        }


        // sql.cn.Close()
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);
            // CloseConnection()
        }


        PromotionApplied[btnIndex] = true;

    }

    private bool DetermineNumberCredited(ref int itemsCredited, int numberOfCombosItems, decimal ComboPrice, int PromoID, string PromoName, int customerNumber, int sii)
    {
        if (itemsCredited >= numberOfCombosItems)
        {
            AddPromoToOrderTable(ComboPrice, PromoID, PromoName, customerNumber, sii);
            itemsCredited = 0;
            currentTable.PromoNumber += 1;
            return true;
        }
        return false;
    }

    private void AddPromoToOrderTable(decimal ComboPrice, int PromoID, string PromoName, int customerNumber, int sii)
    {
        DataRow nRow = dsOrder.Tables("OpenOrders").NewRow;

        nRow("TableNumber") = currentTable.TableNumber;
        nRow("EmployeeID") = currentTable.EmployeeID;
        nRow("CheckNumber") = currentTable.CheckNumber;
        nRow("CustomerNumber") = customerNumber;
        nRow("sin") = currentTable.SIN();
        nRow("sii") = sii;
        nRow("ItemID") = PromoID;
        nRow("ItemName") = PromoName + "  " + currentTable.PromoNumber;
        nRow("TerminalName") = PromoName + "  " + currentTable.PromoNumber;
        nRow("Price") = ComboPrice;
        nRow("TaxID") = 1;       // ******** this will be determined
        nRow("CategoryID") = 0;
        nRow("FunctionID") = 9;      // hardcoded for Promotions

        nRow("ItemStatus") = 4;

        dsOrder.Tables("OpenOrders").Rows.Add(nRow);
        currentTable.SIN += 1;



    }

    private void RunBSGSPromotion()
    {


    }


    private void CheckMaxDollarAmount(ref DataRow promoRow)
    {
        if (maxDollar < promoRow("MaxAmount"))
        {
            return;
        }

        else
        {

            // quit promo

        }
    }

    private void CheckMaxCheckAmount(ref DataRow promoRow)
    {
        if (maxCheck < promoRow("MaxCheck"))
        {
            return;
        }
        else
        {

        }
    }

    private void CheckMaxTableAmount(ref DataRow promoRow)
    {
        if (maxTable < promoRow("MaxTable"))
        {
            return;
        }
        else
        {

        }
    }



    private void TaxingPromoAmount()
    {

    }



    private void TaxingFoodCost()
    {

    }



    private void MakeGuestPayTax()
    {

    }


    private void CheckManagerLevel()
    {

    }


    private void CalculateAddPromoAmountInAutoTip()
    {

    }


    private void btnCloseExit_Click(object sender, EventArgs e)
    {

        ClosingAndReleaseRoutine(false);

        // RaiseEvent CloseExiting(False)

    }

    private void btnCloseSplit_Click(object sender, EventArgs e)
    {
        // should we update Payments and Credits
        ResetTimer();

        // If currentTerminal.TermMethod = "Quick" Then
        // Exit Sub
        // End If

        DataRow oRow;
        DataRowView vRow;
        var numberCheckCount = default(int);

        // ***
        // we need to move this for individual moves in split checks
        // If dsOrder.Tables("PaymentsAndCredits").Rows.Count > 0 Then
        // For Each oRow In dsOrder.Tables("PaymentsAndCredits").Rows
        // If Not oRow.RowState = DataRowState.Deleted And Not oRow.RowState = DataRowState.Detached Then
        // If oRow("Applied") = True Then
        // MsgBox("You can not split a Check after a Payment has been applied.")
        // Exit Sub
        // End If
        // End If
        // Next
        // End If

        if (currentTable.NumberOfChecks == 1)
        {
            // we are spliting every check with multiple customers by customer
            // currentTable.NumberOfChecks = currentTable.NumberOfCustomers
            foreach (DataRow currentORow in dsOrder.Tables("OpenOrders").Rows)
            {
                oRow = currentORow;
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    oRow("CheckNumber") = oRow("CustomerNumber");
                    if (oRow("ItemID") == 0 & oRow("si2") == 0)
                    {
                        // counts customer panels
                        numberCheckCount += 1;
                    }
                }

            }
            if (numberCheckCount > 0)
            {
                currentTable.NumberOfChecks = numberCheckCount;
            }
            else
            {
                // do nothing, this is when we have one customer and no customer panel
            }
            if (numberCheckCount > currentTable.NumberOfCustomers)
            {
                currentTable.NumberOfCustomers = numberCheckCount;
            }

            if (numberCheckCount <= 1)    // currentTable.NumberOfCustomers = 1 Then
            {

                CloseGotoSplitting?.Invoke(sender, e);
                return;
            }

            if (currentTerminal.TermMethod == "Quick" | currentTable.TicketNumber > 0)
            {
                foreach (DataRow currentORow1 in dsOrder.Tables("QuickTickets").Rows)
                {
                    oRow = currentORow1;
                    if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        oRow("NumberOfChecks") = numberCheckCount;   // oRow("NumberOfCustomers")
                        oRow("NumberOfCustomers") = currentTable.NumberOfCustomers;
                    }
                }
            }
            else if (currentTable.IsTabNotTable == true)
            {
                foreach (DataRowView currentVRow in dvAvailTabs)
                {
                    vRow = currentVRow;    // dsOrder.Tables("AvailTabs").Rows
                    if (vRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        vRow("NumberOfChecks") = numberCheckCount;   // oRow("NumberOfCustomers")
                        vRow("NumberOfCustomers") = currentTable.NumberOfCustomers;
                    }
                }
            }
            else
            {
                foreach (DataRowView currentVRow1 in dvAvailTables)
                {
                    vRow = currentVRow1;  // dsOrder.Tables("AvailTables").Rows
                    if (vRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        vRow("NumberOfChecks") = numberCheckCount;       // oRow("NumberOfCustomers")
                        vRow("NumberOfCustomers") = currentTable.NumberOfCustomers;
                    }
                }
            }

            // all this updates screen for Check number 1
            ReinitializeCloseCheck(true);
            // singleSplit = True
            SplitSingleCheck?.Invoke();
        }

        else
        {
            CloseGotoSplitting?.Invoke(sender, e);

        }

    }

    private void btnClosePayment_Click(object sender, EventArgs e)
    {
        ResetTimer();

        pnlPaymentTypes.Controls.Clear();

        AddGeneratedControlsToPaymentPanel();

    }


    private void btnCloseGift_Click(object sender, EventArgs e)
    {
        ResetTimer();

        DataRowView vRow;
        var newPayment = new DataSet_Builder.Payment();
        int index = 1;

        newPayment.Purchase = Strings.Format(0, "##,##0.00");
        newPayment.PaymentTypeID = -98; // DetermineCreditCardID("Cash")
        newPayment.PaymentTypeName = "Gift Certificate";

        // For Each vRow In dvUnAppliedPaymentsAndCredits  '  dvClosingCheckPayments       'dsOrder.Tables("PaymentsAndCredits").Rows
        // If vRow("PaymentFlag") = "Cash" Then       'And vRow("Applied") = 0 Then
        // vRow("PaymentAmount") += 0
        // ShowRemainingBalance()
        // GetNumberOfActivePayments(currentTable.CheckNumber)
        // paymentRowIndex = index
        // Return
        // End If
        // index += 1
        // Next

        CreateNewPaymentEntry(ref newPayment, false);
        ShowRemainingBalance();
    }

    private void AddAutoCash(decimal amount)
    {
        ResetTimer();
        var newPayment = new DataSet_Builder.Payment();
        int index = 1;

        newPayment.Purchase = Strings.Format(amount, "##,##0.00");
        newPayment.PaymentTypeID = DetermineCreditCardID("Cash");
        newPayment.PaymentTypeName = "Cash";

        foreach (DataRowView vRow in dvUnAppliedPaymentsAndCredits)  // dvClosingCheckPayments       'dsOrder.Tables("PaymentsAndCredits").Rows
        {
            if (vRow("PaymentFlag") == "Cash")       // And vRow("Applied") = 0 Then
            {
                vRow("PaymentAmount") += amount;
                ShowRemainingBalance();
                GetNumberOfActivePayments(currentTable.CheckNumber);
                paymentRowIndex = index;
                return;
            }
            index += 1;
        }

        CreateNewPaymentEntry(ref newPayment, false);
        ShowRemainingBalance();

    }

    private void CreateNewPaymentEntry(ref DataSet_Builder.Payment newPayment, bool doApply)
    {

        if (newPayment.PaymentTypeID == -97) // "MPS Gift" Then
        {
            // issuing Gift Card
            // remember this was negative, so we need to reverse to compare w/ attemptingPayment
            _checkGiftIssuingAmount -= newPayment.Purchase;
            _lastPurchaseIssueAmount = _checkGiftIssuingAmount;
        }

        GenerateOrderTables.AddPaymentToDataRow(newPayment, doApply, currentTable.ExperienceNumber, currentServer.EmployeeID, currentTable.CheckNumber, closeCheckTotals.AutoGratuity);

        // numActivePaymentsByCheck += 1
        // paymentRowIndex = dvUnAppliedPaymentsAndCredits.Count

        GetNumberOfActivePayments(currentTable.CheckNumber);

    }

    private void CreateNewPaymentPanel(ref DataRowView vRow, int PnlNo, int position, decimal giftBalance)
    {

        var truncAcctNum = default(string);

        if (!object.ReferenceEquals(vRow("AccountNumber"), DBNull.Value))
        {
            if (!object.ReferenceEquals(vRow("AuthCode"), DBNull.Value))
            {
                // already authorized
                if (!(vRow("AccountNumber").Substring(0, 4) == "xxxx") & !(vRow("AccountNumber") == "Manual"))
                {

                    truncAcctNum = TruncateAccountNumber(vRow("AccountNumber"));
                }
                else
                {
                    truncAcctNum = vRow("AccountNumber");
                }
            }
            else
            {
                truncAcctNum = vRow("AccountNumber");
            }
        }

        paymentPanel[PnlNo] = new DataSet_Builder.Payment_UC("Close", vRow, (object)null, PnlNo, (object)null, truncAcctNum, giftBalance);

        {
            ref var withBlock = ref paymentPanel[PnlNo];

            withBlock.Location = new Point(0, withBlock.Height * position);
            withBlock.BackColor = Color.DarkGray;
            this.paymentPanel[PnlNo].ActivePanel += PaymentUserControl_Click;
            this.paymentPanel[PnlNo].SeeHistoryPanel += PaymentUserControl_History;
            pnlClosePayments.Controls.Add(paymentPanel[PnlNo]);
        }

    }

    private void NewCardRead(ref DataSet_Builder.Payment newPayment)
    {
        ResetTimer();

        // 444   GenerateOrderTables.CreateTabAcctPlaceInExperience(newPayment)
        // 444    AddPaymentToCollection(newPayment)
        ProcessCreditRead(ref newPayment);

    }

    internal void ProcessCreditRead(ref DataSet_Builder.Payment newPayment)
    {

        if (newPayment.AuthCode > 0)
            return;
        string authStatus;

        DataRow oRow;

        if (!(newPayment.PaymentTypeID == -97)) // authStatus = "Account Not Issued" 
        {
            if (creditAmountAdjusted == true | doNotAutoCreditCards == true)
            {
                newPayment.Purchase = 0;
            }
            else
            {
                newPayment.Purchase = DetermineAutomaticCreditCharge();
            }
            if (newPayment.PaymentFlag == "Gift")
            {
                if (newPayment.Balance < newPayment.Purchase)
                {
                    newPayment.Purchase = newPayment.Balance;
                    Interaction.MsgBox("Balance remaining on card before purchase: " + newPayment.Balance);
                    // otherwise defaults to purchase
                }

            }
            ApplyAutomaticCreditCharge(newPayment.Purchase);

        }

        CreateNewPaymentEntry(ref newPayment, false);
        ShowRemainingBalance();

    }

    internal void ProcessCreditRead_MWE(DataRowView vRow) // ByVal _secureNewPayment_MWE As ReadCredit_MWE2.Payment_MWE)
    {

        if (!object.ReferenceEquals(vRow("AuthCode"), DBNull.Value))
        {
            if (vRow("AuthCode") > 0)
                return;
        }

        string authStatus;

        DataRow oRow;

        if (!(vRow("PaymentTypeID") == -97)) // authStatus = "Account Not Issued" 
        {
            if (creditAmountAdjusted == true | doNotAutoCreditCards == true)
            {
                vRow("Purchase") = 0;
            }
            else
            {
                vRow("Purchase") = DetermineAutomaticCreditCharge();
            }
            if (vRow("PaymentFlag") == "Gift")
            {
                if (vRow("Balance") < vRow("Purchase"))
                {
                    vRow("Purchase") = vRow("Balance"); // balance is what is on the Gift Card
                    Interaction.MsgBox("Balance remaining on card before purchase: " + vRow("Balance"));
                    // otherwise defaults to purchase
                }

            }
            ApplyAutomaticCreditCharge_MWE(vRow("Purchase"));

        }

        CreateNewPaymentEntry_MWE(vRow); // , False)
        ShowRemainingBalance();

    }

    private void CreateNewPaymentEntry_MWE(DataRowView vRow) // ByRef newPayment As DataSet_Builder.Payment, ByVal doApply As Boolean)
    {

        if (vRow("PaymentTypeID") == -97) // "MPS Gift" Then
        {
            // issuing Gift Card
            // remember this was negative, so we need to reverse to compare w/ attemptingPayment
            _checkGiftIssuingAmount -= vRow("Purchase");
            _lastPurchaseIssueAmount = _checkGiftIssuingAmount;
        }

        // ?????
        // 444   GenerateOrderTables.AddPaymentToDataRow(newPayment, doApply, currentTable.ExperienceNumber, currentServer.EmployeeID, currentTable.CheckNumber, closeCheckTotals.AutoGratuity)

        // old     numActivePaymentsByCheck += 1
        // old    paymentRowIndex = dvUnAppliedPaymentsAndCredits.Count

        GetNumberOfActivePayments(currentTable.CheckNumber);

    }

    private void DisplayAnyStoredPayments222()
    {

        foreach (Payment newPayment in tabcc)
        {
            if (newPayment.experienceNumber == currentTable.ExperienceNumber)
            {
                CreateNewPaymentEntry(ref newPayment, false);
                // ProcessCreditRead(storedPayment)
            }
        }

    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
        if (!(paymentRowIndex > 0))
            return;
        var UnAuthPanel = default(bool);
        var UnAuthIndex = default(int);

        if (paymentRowIndex > dvClosingCheckPayments.Count)
        {
            // we will use:   dvUnAppliedPaymentsAndCredits_MWE 
            UnAuthPanel = true;
            UnAuthIndex = paymentRowIndex - dvClosingCheckPayments.Count - 1;
            // PaymentEnterStep2_UnAuth(UnAuthIndex)
            // Else
            // PaymentEnterStep2_AlreadyAuth()
        }

        try
        {
            if (paymentPanel[paymentRowIndex].AuthCode != default)
                return;
        }
        // above is nothing (not dbnull) b/c it is not from dataset
        // If paymentPanel(paymentrowindex).  cash???
        catch (Exception ex)
        {
            return;
        }

        foreach (DataSet_Builder.Payment testPay in tabcc)
        {
            if (testPay.experienceNumber == currentTable.ExperienceNumber)
            {
                if (testPay.AccountNumber == paymentPanel[paymentRowIndex].AcctNumber())
                {
                    // we have the same payment assc with this account, 
                    // REMOVE, put in most current info
                    tabcc.Remove(testPay);
                    break;
                }
            }
        }

        if (UnAuthPanel == true)
        {
            dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex].Delete();
        }
        else
        {
            // 444     dvUnAppliedPaymentsAndCredits(paymentRowIndex - 1).Delete()
            dvClosingCheckPayments[paymentRowIndex - 1].Delete();
        }

        paymentPanel[paymentRowIndex].Dispose();
        paymentRowIndex = dvClosingCheckPayments.Count + dvUnAppliedPaymentsAndCredits_MWE.Count; // 444dvUnAppliedPaymentsAndCredits.Count
        // startPaymentIndex = 1
        // If paymentRowIndex > 0 Then
        // paymentRowIndex -= 1
        // End If

        if (startPaymentIndex > paymentRowIndex)
        {
            startPaymentIndex = 1;
        }
        GetNumberOfActivePayments(currentTable.CheckNumber);

    }

    private void PreAuthPaywarePC(ref DataRowView vRow)
    {

        PaywarePCCharge = new SIM.Charge();

        GenerateOrderTables.ReadyToProcessPaywarePC(PaywarePCCharge);

        {
            var withBlock = PaywarePCCharge;
            // .PaymentEngine = SIM.Charge.PaymentSoftware.RiTA_PAYware
            // .ClientID = companyInfo.ClientID '"100010001"
            // .UserID = companyInfo.UserID '"Admin"
            // .UserPW = companyInfo.UserPW '"PCBeta68$"
            // .IPAddress = companyInfo.IPAddress '"127.0.0.1"
            // .Port = "4532"
            // .CommMethod = SIM.Charge.CommType.IP

            if (authPayment.Track2 == default)
            {
                withBlock.Card = authPayment.AcctNum;
                withBlock.ExpDate = authPayment.ExpDate;
            }
            else
            {
                withBlock.Track = authPayment.Track2;
            }  // "4012000033330026=12121011000001234567"
            withBlock.Amount = authPayment.paymentAmount;  // "1.00"
            withBlock.Ticket = authPayment.TicketNumber;  // "123456"
            withBlock.Action = SIM.Charge.Command.Credit_Sale;

            paywareAuthInfo = new Info2_UC("Authorizing...");
            paywareAuthInfo.Location = new Point(300, 250);
            this.Controls.Add(paywareAuthInfo);
            paywareAuthInfo.BringToFront();
            // paywareAuthInfo.Update()
            paywareAuthInfo.Refresh();

            if (withBlock.Process)
            {
                try
                {
                    if (withBlock.GetResult == "CAPTURED" | withBlock.GetResultCode == "4")
                    {
                        paywareAuthInfo.Dispose();
                        // above is the same
                        vRow("AuthCode") = withBlock.GetAuthCode;
                        vRow("AcqRefData") = withBlock.GetReference;
                        vRow("RefNum") = withBlock.GetTroutD;
                        vRow("Description") = withBlock.GetResponseText;
                    }

                    else // If .GetResult = "DECLINED" Or .GetResultCode = "6" Then
                    {
                        paywareAuthInfo.Dispose();
                        Interaction.MsgBox("CARD '" + vRow("AccountNumber") + "' " + withBlock.GetResult + ": " + withBlock.GetResponseText);
                        // MsgBox("CARD '" & vRow("AccountNumber") & "' DECLINED: " & .GetResponseText)
                    }
                }

                catch (Exception ex)
                {
                    paywareAuthInfo.Dispose();

                }
            }

            else
            {
                paywareAuthInfo.Dispose();
                Interaction.MsgBox("" + withBlock.ErrorCode + ": " + withBlock.ErrorDescription);
            }
        }

    }

    private void btnAuthActive_Click(object sender, EventArgs e)
    {
        DataRowView vrow;
        string preAuthReady;
        decimal reducePaymentAmount;
        string paymentWentThrough;
        // Dim ccCashClose As CashClose_UC
        var numItems = default(int);
        // Dim prt As New PrintHelper
        var displayCashClose_UC = default(bool);

        if (paymentRowIndex < 1)
            return;
        var UnAuthPanel = default(bool);
        var UnAuthIndex = default(int);
        // reset
        prt.closeDetail.cashTendered = false;
        prt.closeDetail.cashAppliedPrevious = 0;

        if (paymentRowIndex > dvClosingCheckPayments.Count)
        {
            // we will use:   dvUnAppliedPaymentsAndCredits_MWE 
            UnAuthPanel = true;
            UnAuthIndex = paymentRowIndex - dvClosingCheckPayments.Count - 1;
        }

        if (UnAuthPanel == true)
        {
            vrow = dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex];
        }
        else
        {
            vrow = dvClosingCheckPayments[paymentRowIndex - 1];
        } // 444dvUnAppliedPaymentsAndCredits(paymentRowIndex - 1)

        reducePaymentAmount = vrow("PaymentAmount");
        // 444      If TestPayments(vrow("PaymentAmount")) = True Then
        // **** we can do above only with credit cards, does not make sence with cash

        if (vrow("PaymentFlag") == "Issue")
        {
            // this is for both issue and return (whixh is adding money)
            Interaction.MsgBox("You must select AUTH ALL button because you are Issuing Gift Card");
            return;
        }

        if (vrow("PaymentFlag") == "Gift")
        {

            paymentWentThrough = GenerateOrderTables.GiftCardTransaction(vrow, default, "Sale");
            if (paymentWentThrough == "MPS Gift Card")
            {
                // this means trying to use MPS Gift Card w/o being Mercury Merchant
                Interaction.MsgBox(paymentWentThrough);
            }
            else
            {

            }
        }
        // 444               GiftCardTransaction(vrow, "NoNSFSale")
        else if (companyInfo.usingOutsideCreditProcessor == false)
        {
            if (object.ReferenceEquals(vrow("AuthCode"), DBNull.Value) & vrow("PaymentFlag") == "cc")
            {
                if (companyInfo.processor == "MerchantWare")
                {

                    PreAuthMerchantWare_Active(ref vrow);
                    return;
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(TestAccountNumber(ref vrow), true, false)))
                {
                    preAuthReady = Conversions.ToString(TestPreAuthSwiped(ref vrow, true));
                    if (preAuthReady == "Swiped")
                    {
                        var argorow = default;
                        paymentWentThrough = Conversions.ToString(PreAuth(ref argorow, ref vrow, true));
                    }
                    // PreAuth(vrow)
                    else if (preAuthReady == "Keyed")
                    {
                        var argorow1 = default;
                        paymentWentThrough = Conversions.ToString(PreAuth(ref argorow1, ref vrow, true));
                        // PreAuth(vrow)
                    }
                }
                else
                {
                    return;
                }
            }
        }

        // If paymentWentThrough = False Then Exit Sub
        // this is to determine and previous cash applied on check
        foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("CheckNumber") == currentTable.CheckNumber)
                {
                    if (oRow("Applied") == true)
                    {
                        // applied = true
                        if (oRow("PaymentFlag") == "Cash")
                        {
                            prt.closeDetail.cashAppliedPrevious += oRow("PaymentAmount");
                        }
                    }
                }
            }
        }

        if (vrow("PaymentAmount") != 0)
        {
            if (vrow("Applied") == false)
            {
                // has Auth therefore is approved 
                if (vrow("PaymentFlag") == "Cash")       // 1 is cash
                {
                    // If vrow("PaymentTypeID") = -98 Then   'Gift Certificate
                    // If reducePaymentAmount > RemainingBalance Then
                    // MsgBox("Gift Certificate can not be more than Balance Due")
                    // Exit Sub
                    // End If
                    // End If
                    foreach (DataRowView cRow in dvOrder)
                    {
                        if (cRow("sin") == cRow("sii") & !(cRow("ItemID") == 0))
                        {
                            numItems += 1;
                        }
                    }
                    // PrintCreditCardReceipt(vrow)

                    if (companyInfo.autoPrint == true)
                    {
                        RunClosingPrint();
                        prt.closeDetail.isCashTendered = true;
                        prt.closeDetail.cashTendered = reducePaymentAmount;
                        prt.closeDetail.chkChangeDue = reducePaymentAmount - RemainingBalance;
                        prt.StartPrintCheckReceipt();
                    }
                    else
                    {
                        prt.PrintOpenCashDrawer();
                    }

                    ccDisplay = new CashClose_UC(numItems, currentTable.TruncatedExpNum, RemainingBalance, reducePaymentAmount);
                    ccDisplay.Location = new Point((this.Width - ccDisplay.Width) / 2, (this.Height - ccDisplay.Height) / 2);
                    if (reducePaymentAmount > RemainingBalance)
                    {
                        // means we are giving change
                        vrow("PaymentAmount") = RemainingBalance;
                        RemainingBalance = 0m;
                    }
                    else
                    {
                        RemainingBalance -= reducePaymentAmount;
                    }

                    paymentRowIndex -= 1;
                    vrow("AuthCode") = "Cash";
                    vrow("Applied") = true;
                    if (!(RemainingBalance > 0m))
                    {
                        displayCashClose_UC = true;
                    }
                }

                else if (vrow("PaymentFlag") == "cc" & !object.ReferenceEquals(vrow("AuthCode"), DBNull.Value))
                {
                    // has Auth therefore is approved 
                    vrow("Track2") = DBNull.Value;
                    var argorow2 = default;
                    PrintCreditCardReceipt(ref argorow2, ref vrow, true);
                    vrow("Applied") = true;
                    RemainingBalance -= reducePaymentAmount;
                    paymentRowIndex -= 1;
                    RemovePaymentFromCollection(vrow("AccountNumber"));
                }

                else if (vrow("PaymentFlag") == "Gift" & !object.ReferenceEquals(vrow("AuthCode"), DBNull.Value))
                {
                    // has Auth therefore is approved 
                    vrow("Track2") = DBNull.Value;
                    var argorow3 = default;
                    PrintCreditCardReceipt(ref argorow3, ref vrow, true);
                    vrow("Applied") = true;
                    RemainingBalance -= reducePaymentAmount;
                    paymentRowIndex -= 1;
                    RemovePaymentFromCollection(vrow("AccountNumber"));
                }

                else if (vrow("PaymentFlag") == "outside") // And companyInfo.usingOutsideCreditProcessor = True Then
                {
                    vrow("PaymentTypeID") = 9;
                    vrow("AuthCode") = 9;
                    vrow("Applied") = true;
                    RemainingBalance -= reducePaymentAmount;
                    paymentRowIndex -= 1;
                    RunClosingPrint();
                    prt.StartPrintCheckReceipt(); // new
                }

                else if (vrow("PaymentFlag") == "Gift Cert")
                {
                    // only approved
                    // vrow("Track2") = DBNull.Value
                    // PrintCreditCardReceipt(Nothing, vrow, True)
                    if (vrow("PaymentAmount") > RemainingBalance)
                    {
                        Interaction.MsgBox("Gift Certificate can not be more than Balance Due");
                    }
                    else
                    {
                        vrow("Applied") = true;
                        RemainingBalance -= reducePaymentAmount;
                        paymentRowIndex -= 1;

                    }

                }

            }

        }

        closeCheckTotals.AttachTotalsToTotalView(currentTable.CheckNumber);
        GetNumberOfActivePayments(currentTable.CheckNumber);
        if (displayCashClose_UC == true)
        {
            this.Controls.Add(ccDisplay);
            ccDisplay.BringToFront();
        }

    }

    private void btnAuthAll_Click(object sender, EventArgs e)
    {

        DataRow oRow;
        DataRowView vrow;
        string preAuthReady;
        var unappliedPayments = default(decimal);
        // Dim ccDisplay As CashClose_UC
        var numItems = default(int);
        // Dim prt As New PrintHelper
        var printFinalReceipt = default(bool);
        var displayCashClose_UC = default(bool);
        var attemptingPayment = default(decimal);
        var attemptingCash = default(decimal);
        var giftIssuingAmount = default(decimal);
        var giftRemainingIssue = default(decimal);
        bool issueGiftCards = false;

        bool UnAuthPanel;
        int UnAuthIndex;

        // reset
        prt.closeDetail.cashTendered = false;
        prt.closeDetail.cashAppliedPrevious = 0;

        if (paymentRowIndex > dvClosingCheckPayments.Count)
        {
            // we will use:   dvUnAppliedPaymentsAndCredits_MWE 
            UnAuthPanel = true;
            UnAuthIndex = paymentRowIndex - dvClosingCheckPayments.Count - 1;
        }
        // change     PaymentEnterStep2_UnAuth(UnAuthIndex)
        else
        {
            // change      PaymentEnterStep2_AlreadyAuth()
        }

        if (_checkGiftIssuingAmount > 0m) // we reversed this before to make positive
        {
            foreach (DataRowView currentVrow in dvUnAppliedPaymentsAndCredits)
            {
                vrow = currentVrow;
                if (vrow("PaymentTypeID") > -1)
                {
                    attemptingPayment += vrow("PaymentAmount");
                    if (vrow("PaymentTypeID") == 1)
                    {
                        attemptingCash += vrow("PaymentAmount");
                    }
                }
                else if (vrow("PaymentTypeID") == -97)
                {
                    giftIssuingAmount -= vrow("PaymentAmount");
                }
            }
            if (attemptingPayment < giftIssuingAmount)
            {
                Interaction.MsgBox("There is not enouph payments to cover Issue of Gift Card");
                return;
            }
            giftRemainingIssue = giftIssuingAmount;
        }

        if (companyInfo.usingOutsideCreditProcessor == false)
        {
            foreach (DataRowView currentVrow1 in dvClosingCheckPayments)
            {
                vrow = currentVrow1;
                if (vrow("PaymentFlag") == "Gift")
                {
                    if (object.ReferenceEquals(vrow("AuthCode"), DBNull.Value)) // vrow("Applied") = False And 
                    {
                        preAuthReady = GenerateOrderTables.GiftCardTransaction(vrow, default, "Sale");
                        if (preAuthReady == "MPS Gift Card")
                        {
                            Interaction.MsgBox(preAuthReady);
                        }
                        else
                        {

                        }
                        // 444               GiftCardTransaction(vrow, "NoNSFSale")
                    }
                }

                // 444 For Each oRow In dsOrder.Tables("PaymentsAndCredits").Rows
                // 444If Not oRow.RowState = DataRowState.Deleted And Not oRow.RowState = DataRowState.Detached Then
                else if (vrow("CheckNumber") == currentTable.CheckNumber)
                {
                    if (vrow("Applied") == false)
                    {
                        if (object.ReferenceEquals(vrow("AuthCode"), DBNull.Value) & vrow("PaymentFlag") == "cc")
                        {

                            preAuthReady = Conversions.ToString(TestPreAuthSwiped(ref vrow, true));
                            if (preAuthReady == "Swiped")
                            {
                                var argorow = default;
                                PreAuth(ref argorow, ref vrow, true);
                            }
                            else if (preAuthReady == "Keyed")
                            {
                                var argorow1 = default;
                                PreAuth(ref argorow1, ref vrow, true);
                            }

                            // 444           preAuthReady = TestPreAuthSwiped(oRow, Nothing, False)
                            // If preAuthReady = "Swiped" Then
                            // PreAuth(oRow, Nothing, False)
                            // ElseIf preAuthReady = "Keyed" Then
                            // PreAuth(oRow, Nothing, False)
                            // End If
                        }
                    }
                    // End If
                }
            }
        }
        // Next

        // or can do by dvClosingCheckPayments
        // we are doing all the credit card payments first
        foreach (DataRowView currentVrow2 in dvClosingCheckPayments)
        {
            vrow = currentVrow2;
            // 444 For Each oRow In dsOrder.Tables("PaymentsAndCredits").Rows
            // 444     If Not oRow.RowState = DataRowState.Deleted And Not oRow.RowState = DataRowState.Detached Then
            if (vrow("CheckNumber") == currentTable.CheckNumber)
            {
                if (vrow("PaymentAmount") != 0)
                {
                    if (vrow("Applied") == false)
                    {
                        if (vrow("PaymentFlag") == "cc" & !object.ReferenceEquals(vrow("AuthCode"), DBNull.Value))
                        {
                            // only approved
                            vrow("Track2") = DBNull.Value;
                            var argorow2 = default;
                            PrintCreditCardReceipt(ref argorow2, ref vrow, true);
                            paymentRowIndex -= 1;
                            unappliedPayments += vrow("PaymentAmount");
                            vrow("Applied") = true;
                            RemovePaymentFromCollection(vrow("AccountNumber"));
                        }

                        else if (vrow("PaymentFlag") == "Gift" & !object.ReferenceEquals(vrow("AuthCode"), DBNull.Value))
                        {
                            // only approved
                            vrow("Track2") = DBNull.Value;
                            var argorow3 = default;
                            PrintCreditCardReceipt(ref argorow3, ref vrow, true);
                            paymentRowIndex -= 1;
                            unappliedPayments += vrow("PaymentAmount");
                            vrow("Applied") = true;
                            RemovePaymentFromCollection(vrow("AccountNumber"));
                        }

                        else if (vrow("PaymentFlag") == "outside") // And companyInfo.usingOutsideCreditProcessor = True Then
                        {
                            paymentRowIndex -= 1;
                            unappliedPayments += vrow("PaymentAmount");
                            vrow("Applied") = true;
                            vrow("PaymentTypeID") = 9;
                            vrow("AuthCode") = 9;
                            RunClosingPrint();
                            printFinalReceipt = true;
                        }

                        else if (vrow("PaymentFlag") == "Gift Cert")
                        {
                            // only approved
                            // vrow("Track2") = DBNull.Value
                            // PrintCreditCardReceipt(Nothing, vrow, True)
                            if (vrow("PaymentAmount") > RemainingBalance)
                            {
                                Interaction.MsgBox("Gift Certificate can not be more than Balance Due");
                            }
                            else
                            {
                                paymentRowIndex -= 1;
                                unappliedPayments += vrow("PaymentAmount");
                                vrow("Applied") = true;
                            }

                            // RemovePaymentFromCollection(vrow("AccountNumber"))
                        }

                    }
                }
            }
            // 444     End If
        }
        RemainingBalance -= unappliedPayments;
        if (giftIssuingAmount > 0m)
        {
            if (RemainingBalance > attemptingCash)
            {
                Interaction.MsgBox("You must cover the entire Sale before Issue of Gift Card");
                issueGiftCards = false;
            }
            else
            {
                issueGiftCards = true;
                RemainingBalance += giftIssuingAmount;
            }
            // this reduces by the amount still not covered by payments
            giftRemainingIssue -= unappliedPayments;
        }

        // or can do by dvClosingCheckPayments
        foreach (DataRowView currentVrow3 in dvClosingCheckPayments)
        {
            vrow = currentVrow3;
            // 444  For Each oRow In dsOrder.Tables("PaymentsAndCredits").Rows
            // 444    If Not oRow.RowState = DataRowState.Deleted And Not oRow.RowState = DataRowState.Detached Then
            if (vrow("CheckNumber") == currentTable.CheckNumber)
            {
                if (vrow("PaymentAmount") != 0)
                {
                    if (vrow("Applied") == false)
                    {
                        if (vrow("PaymentFlag") == "Cash")
                        {
                            // If vrow("PaymentTypeID") = -98 Then   'Gift Certificate
                            // If vrow("PaymentAmount") > RemainingBalance Then
                            // MsgBox("Gift Certificate can not be more than Balance Due")
                            // Exit Sub
                            // End If
                            // End If
                            foreach (DataRowView cRow in dvOrder)
                            {
                                if (cRow("sin") == cRow("sii") & !(cRow("ItemID") == 0))
                                {
                                    numItems += 1;
                                }
                            }

                            if (companyInfo.autoPrint == true)
                            {
                                RunClosingPrint();
                                prt.closeDetail.isCashTendered = true;
                                prt.closeDetail.cashTendered = vrow("PaymentAmount");
                                prt.closeDetail.chkChangeDue = vrow("PaymentAmount") - RemainingBalance;
                                printFinalReceipt = true;
                            }
                            else
                            {
                                prt.PrintOpenCashDrawer();
                            }

                            ccDisplay = new CashClose_UC(numItems, currentTable.TruncatedExpNum, RemainingBalance, vrow("PaymentAmount"));
                            ccDisplay.Location = new Point((this.Width - ccDisplay.Width) / 2, (this.Height - ccDisplay.Height) / 2);
                            if (vrow("PaymentAmount") > RemainingBalance)
                            {
                                // means we are giving change
                                vrow("PaymentAmount") = RemainingBalance;
                                RemainingBalance = 0m;
                            }
                            else
                            {
                                RemainingBalance -= vrow("PaymentAmount");
                            }
                            paymentRowIndex -= 1;
                            // unappliedPayments += vRow("PaymentAmount")
                            vrow("AuthCode") = "Cash";
                            vrow("Applied") = true;

                            if (!(RemainingBalance > 0m))
                            {
                                displayCashClose_UC = true;
                            }
                        }
                    }
                    // applied = true
                    else if (vrow("PaymentFlag") == "Cash")
                    {
                        prt.closeDetail.cashAppliedPrevious += vrow("PaymentAmount");

                    }
                }
            }
            // 444       End If
        }

        if (issueGiftCards == true)
        {
            string authStatus;

            foreach (DataRowView currentVrow4 in dvClosingCheckPayments)
            {
                vrow = currentVrow4;
                if (object.ReferenceEquals(vrow("AuthCode"), DBNull.Value) & vrow("PaymentFlag") == "Issue")
                {

                    if (vrow("PaymentTypeName") == "Issue Gift")
                    {
                        // **** issue Gift Cards
                        authStatus = GenerateOrderTables.GiftCardTransaction(vrow, default, "Issue");
                    }
                    else if (vrow("PaymentTypeName") == "Increase Gift")
                    {
                        authStatus = GenerateOrderTables.GiftCardTransaction(vrow, default, "Return");
                    }

                }
            }

            var index = default(int);

            foreach (DataRowView currentVrow5 in dvClosingCheckPayments)
            {
                vrow = currentVrow5;
                // just approved gift issue, seperate b/c we change row filter (Applied)
                if (!object.ReferenceEquals(vrow("AuthCode"), DBNull.Value) & vrow("PaymentFlag") == "Issue")
                {
                    // only approved
                    vrow("Track2") = DBNull.Value;
                    // PrintCreditCardReceipt(Nothing, vrow, True)
                    _checkGiftIssuingAmount += vrow("PaymentAmount");
                    paymentPanel[index].UpdateGiftAccountBalance(vrow("paymentAmount"));
                    // paymentRowIndex -= 1
                    vrow("Applied") = true;
                    RemovePaymentFromCollection(vrow("AccountNumber"));
                }
                if (!(vrow("PaymentFlag") == "Cash"))
                {
                    index += 1;
                }
            }

        }

        if (printFinalReceipt == true)
        {
            prt.StartPrintCheckReceipt();
        }
        else
        {
            // prt.PrintOpenCashDrawer()
        }

        GetNumberOfActivePayments(currentTable.CheckNumber);
        closeCheckTotals.AttachTotalsToTotalView(currentTable.CheckNumber);

        if (displayCashClose_UC == true)
        {
            this.Controls.Add(ccDisplay);
            ccDisplay.BringToFront();
        }

    }


    // encryption logic ???
    // Dim data As String
    // Dim result As HashAlgorithm
    // Try
    // Data = vrow("AccountNumber")
    // 
    // '        Dim sha = New SHA1CryptoServiceProvider
    // ' This is one implementation of the abstract class SHA1.
    // result = sha.ComputeHash(Data)
    // MsgBox(result.ToString)
    // 
    // Catch ex As Exception
    // MsgBox(ex.Message)
    // End Try
    // 
    // Exit Function 


    private object TestPreAuthSwiped(ref DataRowView vRow, bool useVIEW)
    {

        var isReady = default(string);
        decimal authAmount;

        if (companyInfo.processor == "MerchantWare")
        {
            return default;
        }
        else if (companyInfo.processor == "PaywarePC")
        {
            // need to fill the following:
            // Ticket (ticket number)
            // Amount (payment amount)
            // Track or Account#/Exp Date

            authPayment = new PaymentInfo();

            // _closeAuthAmount.Purchase = vRow("PaymentAmount").ToString
            authAmount = Strings.Format(vRow("PaymentAmount") + vRow("Surcharge"), "#####0.00").ToString;
            // authAmount.Gratuity = Nothing
            vRow("PreAuthAmount") = authAmount;
            vRow("TransactionCode") = "PreAuth";

            if (!object.ReferenceEquals(vRow("RefNum"), DBNull.Value))
            {
                authPayment.TicketNumber = vRow("RefNum");
            }
            else
            {
                vRow("RefNum") = authPayment.TicketNumber;
            }

            if (vRow("PaymentAmount") <= 0)
            {
                Interaction.MsgBox("Auth Amount must be greater than $0.00");
                return isReady;  // returns a Nothing value
            }
            else
            {
                authPayment.paymentAmount = Strings.Format(vRow("PaymentAmount") + vRow("Surcharge"), "#####0.00");
            }

            if (object.ReferenceEquals(vRow("Track2"), DBNull.Value))
            {
                if (paymentPanel[paymentRowIndex].AcctNumber.Length > 0 & paymentPanel[paymentRowIndex].ExpDate.Length == 4)
                {
                    vRow("AccountNumber") = paymentPanel[paymentRowIndex].AcctNumber;
                    vRow("CCExpiration") = paymentPanel[paymentRowIndex].ExpDate;
                    authPayment.AcctNum = paymentPanel[paymentRowIndex].AcctNumber;
                    authPayment.ExpDate = paymentPanel[paymentRowIndex].ExpDate;

                    // for testing
                    // authPayment.AcctNum = "4012000033330026"
                    // authPayment.ExpDate = "1212"


                    isReady = "Keyed";
                    return isReady;
                }

                Interaction.MsgBox("Card Swipe Does Not Read Correctly");
                return isReady;
            }
            else
            {
                authPayment.Track2 = vRow("Track2");

                // for testing
                // authPayment.Track2 = "4012000033330026=12121011000001234567"


                isReady = "Swiped";
                return isReady;
            }
        }

        else if (companyInfo.processor == "Mercury")
        {
            // Dim authPayment As TStream
            _closeAuthAmount = new PreAuthAmountClass();
            _closeAuthTransaction = new PreAuthTransactionClass();
            _closeAuthAccount = new AccountClass();

            // Mercury Authorizes Purchase Amount (even though we send both)
            _closeAuthAmount.Purchase = Strings.Format(vRow("PaymentAmount") + vRow("Surcharge"), "#####0.00").ToString;
            _closeAuthAmount.Authorize = Strings.Format(vRow("PaymentAmount") + vRow("Surcharge"), "#####0.00").ToString;
            // authAmount.Gratuity = Nothing
            vRow("PreAuthAmount") = _closeAuthAmount.Authorize;
            vRow("TransactionCode") = "PreAuth";

            _closeAuthTransaction.MerchantID = companyInfo.merchantID;       // CompanyID & LocationID
            _closeAuthTransaction.OperatorID = companyInfo.operatorID;      // currentServer.EmployeeID.ToString
            _closeAuthTransaction.TranType = vRow("TransactionType");    // "Credit"
            _closeAuthTransaction.Memo = "spiderPOS " + companyInfo.VersionNumber;
            // If vRow("Duplicate") = True Then
            // _closeAuthTransaction.Duplicate = "Override"
            // End If
            _closeAuthTransaction.TranCode = "PreAuth";


            // in TestPreAuthSwiped
            if (!object.ReferenceEquals(vRow("RefNum"), DBNull.Value))
            {
                _closeAuthTransaction.InvoiceNo = vRow("RefNum");
                _closeAuthTransaction.RefNo = vRow("RefNum");
            }
            else
            {
                // _closeAuthTransaction.InvoiceNo = (currentTable.ExperienceNumber & "-" & currentTable.CheckNumber & "-" & paymentRowIndex).ToString
                // _closeAuthTransaction.RefNo = (currentTable.ExperienceNumber & "-" & currentTable.CheckNumber & "-" & paymentRowIndex).ToString
                _closeAuthTransaction.InvoiceNo = currentTable.TruncatedExpNum.ToString; // & "-" & (dvAppliedPayments.Count + 1)).ToString ' & "-" & currentTable.CheckNumber & "-" & paymentRowIndex).ToString
                _closeAuthTransaction.RefNo = currentTable.TruncatedExpNum.ToString; // & "-" & (dvAppliedPayments.Count + 1)).ToString ' & "-" & currentTable.CheckNumber & "-" & paymentRowIndex).ToString
                vRow("RefNum") = _closeAuthTransaction.RefNo;
            }

            if (vRow("Duplicate") == true)
            {
                _closeAuthTransaction.InvoiceNo = (currentTable.TruncatedExpNum + "-" + dvAppliedPayments.Count + 1).ToString; // & Format(currentTable.CheckNumber, "000")) ' & "-" & paymentRowIndex).ToString
                _closeAuthTransaction.RefNo = (currentTable.TruncatedExpNum + "-" + dvAppliedPayments.Count + 1).ToString; // & "-" & currentTable.CheckNumber & "-" & paymentRowIndex).ToString
                vRow("RefNum") = _closeAuthTransaction.RefNo;
            }

            if (vRow("PaymentAmount") <= 0)
            {
                Interaction.MsgBox("Auth Amount must be greater than $0.00");
                return isReady;  // returns a Nothing value
            }

            // ****************
            // for testing only
            // _closeAuthAccount.AcctNo = "5499990123456781"
            // _closeAuthAccount.ExpDate = "0809"
            // isReady = "Keyed"
            // Return isReady
            // 
            // ****************

            if (object.ReferenceEquals(vRow("Track2"), DBNull.Value))
            {
                if (paymentPanel[paymentRowIndex].AcctNumber.Length > 0 & paymentPanel[paymentRowIndex].ExpDate.Length == 4)
                {
                    vRow("AccountNumber") = paymentPanel[paymentRowIndex].AcctNumber;
                    vRow("CCExpiration") = paymentPanel[paymentRowIndex].ExpDate;
                    _closeAuthAccount.AcctNo = paymentPanel[paymentRowIndex].AcctNumber;
                    _closeAuthAccount.ExpDate = paymentPanel[paymentRowIndex].ExpDate;
                    isReady = "Keyed";
                    return isReady;
                }

                Interaction.MsgBox("Card Swipe Does Not Read Correctly");
                return isReady;
            }
            else
            {
                _closeAuthAccount.Track2 = vRow("Track2");
                isReady = "Swiped";
                return isReady;
            }
        }

        return default;

    }

    private object TestPreAuthSwiped222(ref DataRow orow, ref DataRowView vRow, bool useVIEW)
    {

        var isReady = default(string);

        // Dim authPayment As TStream
        _closeAuthAmount = new PreAuthAmountClass();
        _closeAuthTransaction = new PreAuthTransactionClass();
        _closeAuthAccount = new AccountClass();
        if (useVIEW == true)
        {
            _closeAuthAmount.Purchase = vRow("PaymentAmount").ToString;
            _closeAuthAmount.Authorize = Strings.Format(vRow("PaymentAmount") + vRow("Surcharge"), "#####0.00").ToString;
            // authAmount.Gratuity = Nothing
            vRow("PreAuthAmount") = _closeAuthAmount.Authorize;
            vRow("TransactionCode") = "PreAuth";

            _closeAuthTransaction.MerchantID = companyInfo.merchantID;       // CompanyID & LocationID
            _closeAuthTransaction.OperatorID = companyInfo.operatorID;      // currentServer.EmployeeID.ToString
            _closeAuthTransaction.TranType = vRow("TransactionType");    // "Credit"
            _closeAuthTransaction.Memo = "spiderPOS " + companyInfo.VersionNumber;
            // If vRow("Duplicate") = True Then
            // _closeAuthTransaction.Duplicate = "Override"
            // End If
            _closeAuthTransaction.TranCode = "PreAuth";
        }
        else
        {
            _closeAuthAmount.Purchase = orow("PaymentAmount").ToString;
            _closeAuthAmount.Authorize = Strings.Format(orow("PaymentAmount") + orow("Surcharge"), "#####0.00").ToString;
            // authAmount.Gratuity = Nothing
            orow("PreAuthAmount") = _closeAuthAmount.Authorize;

            orow("TransactionCode") = "PreAuth";

            _closeAuthTransaction.MerchantID = companyInfo.merchantID;       // CompanyID & LocationID
            // 999        _closeAuthTransaction.MerchantID = "888000000253"       'CompanyID & LocationID
            _closeAuthTransaction.OperatorID = companyInfo.operatorID;      // currentServer.EmployeeID.ToString
            _closeAuthTransaction.TranType = orow("TransactionType");    // "Credit"
            _closeAuthTransaction.Memo = "spiderPOS " + companyInfo.VersionNumber;
            // If orow("Duplicate") = True Then
            // _closeAuthTransaction.Duplicate = "Override"
            // End If
            _closeAuthTransaction.TranCode = "PreAuth";
        }

        // in TestPreAuthSwiped
        if (useVIEW == true)
        {
            if (!object.ReferenceEquals(vRow("RefNum"), DBNull.Value))
            {
                _closeAuthTransaction.InvoiceNo = vRow("RefNum");
                _closeAuthTransaction.RefNo = vRow("RefNum");
            }
            else
            {
                // _closeAuthTransaction.InvoiceNo = (currentTable.ExperienceNumber & "-" & currentTable.CheckNumber & "-" & paymentRowIndex).ToString
                // _closeAuthTransaction.RefNo = (currentTable.ExperienceNumber & "-" & currentTable.CheckNumber & "-" & paymentRowIndex).ToString
                _closeAuthTransaction.InvoiceNo = currentTable.TruncatedExpNum.ToString; // & "-" & (dvAppliedPayments.Count + 1)).ToString ' & "-" & currentTable.CheckNumber & "-" & paymentRowIndex).ToString
                _closeAuthTransaction.RefNo = currentTable.TruncatedExpNum.ToString; // & "-" & (dvAppliedPayments.Count + 1)).ToString ' & "-" & currentTable.CheckNumber & "-" & paymentRowIndex).ToString
                vRow("RefNum") = _closeAuthTransaction.RefNo;
            }

            if (vRow("Duplicate") == true)
            {
                _closeAuthTransaction.InvoiceNo = (currentTable.TruncatedExpNum + "-" + dvAppliedPayments.Count + 1).ToString; // & Format(currentTable.CheckNumber, "000")) ' & "-" & paymentRowIndex).ToString
                _closeAuthTransaction.RefNo = (currentTable.TruncatedExpNum + "-" + dvAppliedPayments.Count + 1).ToString; // & "-" & currentTable.CheckNumber & "-" & paymentRowIndex).ToString
                vRow("RefNum") = _closeAuthTransaction.RefNo;
            }

            if (vRow("PaymentAmount") <= 0)
            {
                Interaction.MsgBox("Auth Amount must be greater than $0.00");
                return isReady;  // returns a Nothing value
            }

            // ****************
            // for testing only
            // _closeAuthAccount.AcctNo = "5499990123456781"
            // _closeAuthAccount.ExpDate = "0809"
            // isReady = "Keyed"
            // Return isReady
            // 
            // ****************

            if (object.ReferenceEquals(vRow("Track2"), DBNull.Value))
            {
                if (paymentPanel[paymentRowIndex].AcctNumber.Length > 0 & paymentPanel[paymentRowIndex].ExpDate.Length == 4)
                {
                    vRow("AccountNumber") = paymentPanel[paymentRowIndex].AcctNumber;
                    vRow("CCExpiration") = paymentPanel[paymentRowIndex].ExpDate;
                    _closeAuthAccount.AcctNo = paymentPanel[paymentRowIndex].AcctNumber;
                    _closeAuthAccount.ExpDate = paymentPanel[paymentRowIndex].ExpDate;
                    isReady = "Keyed";
                    return isReady;
                }

                Interaction.MsgBox("Card Swipe Does Not Read Correctly");
                return isReady;
            }
            else
            {
                _closeAuthAccount.Track2 = vRow("Track2");
                isReady = "Swiped";
                return isReady;
            }
        }
        else
        {
            if (!object.ReferenceEquals(orow("RefNum"), DBNull.Value))
            {
                _closeAuthTransaction.InvoiceNo = orow("RefNum");
                _closeAuthTransaction.RefNo = orow("RefNum");
            }
            else
            {
                _closeAuthTransaction.InvoiceNo = currentTable.TruncatedExpNum.ToString; // & "-" & currentTable.CheckNumber & "-" & paymentRowIndex).ToString
                _closeAuthTransaction.RefNo = currentTable.TruncatedExpNum.ToString; // & "-" & currentTable.CheckNumber & "-" & paymentRowIndex).ToString
                orow("RefNum") = _closeAuthTransaction.RefNo;
            }
            if (orow("Duplicate") == true)
            {
                // ?????????????
                _closeAuthTransaction.InvoiceNo = (currentTable.TruncatedExpNum + "-" + currentTable.CheckNumber + "-" + paymentRowIndex).ToString;
                _closeAuthTransaction.RefNo = (currentTable.TruncatedExpNum + "-" + currentTable.CheckNumber + "-" + paymentRowIndex).ToString;
                orow("RefNum") = _closeAuthTransaction.RefNo;
            }

            if (orow("PaymentAmount") <= 0)
            {
                Interaction.MsgBox("Auth Amount must be greater than $0.00");
                return isReady;  // returns a Nothing value
            }

            // ****************
            // for testing only
            // _closeAuthAccount.AcctNo = "5499990123456781"
            // _closeAuthAccount.ExpDate = "0809"
            // isReady = "Keyed"
            // Return isReady
            // 
            // ****************

            if (object.ReferenceEquals(orow("Track2"), DBNull.Value))
            {
                // this is manual 
                if (paymentPanel[paymentRowIndex].AcctNumber is null)
                {
                    Interaction.MsgBox("You must enter an account number");
                    return default;
                }
                if (paymentPanel[paymentRowIndex].ExpDate is null)
                {
                    Interaction.MsgBox("You must enter an expiration date");
                    return default;
                }
                if (paymentPanel[paymentRowIndex].AcctNumber.Length > 0 & paymentPanel[paymentRowIndex].ExpDate.Length == 4)
                {
                    orow("AccountNumber") = paymentPanel[paymentRowIndex].AcctNumber;
                    orow("CCExpiration") = paymentPanel[paymentRowIndex].ExpDate;
                    _closeAuthAccount.AcctNo = paymentPanel[paymentRowIndex].AcctNumber;
                    _closeAuthAccount.ExpDate = paymentPanel[paymentRowIndex].ExpDate;
                    isReady = "Keyed";
                    return isReady;
                }

                Interaction.MsgBox("Card Swipe Does Not Read Correctly");
                return isReady;
            }
            else
            {
                _closeAuthAccount.Track2 = orow("Track2");
                isReady = "Swiped";
                return isReady;
            }
        }

    }

    private void DetermineInvoiseNumber222(ref DataRow orow, ref DataRowView vRow, bool useVIEW)
    {
        // this is extra
        // we should use this

        if (!object.ReferenceEquals(vRow("RefNum"), DBNull.Value))
        {
            _closeAuthTransaction.InvoiceNo = vRow("RefNum");
            _closeAuthTransaction.RefNo = vRow("RefNum");
        }
        else
        {
            _closeAuthTransaction.InvoiceNo = currentTable.TruncatedExpNum.ToString;
            _closeAuthTransaction.RefNo = currentTable.TruncatedExpNum.ToString;
        }

        if (vRow("Duplicate") == true)
        {
            _closeAuthTransaction.InvoiceNo = (currentTable.TruncatedExpNum + "-" + dvAppliedPayments.Count + 1).ToString;
            _closeAuthTransaction.RefNo = (currentTable.TruncatedExpNum + "-" + dvAppliedPayments.Count + 1).ToString;
        }

        // vRow("RefNum") = _closeAuthTransaction.RefNo

    }

    private object PreAuth(ref DataRow orow, ref DataRowView vRow, bool useVIEW)
    {

        // ******************
        // only using vRow  useVIEW = True
        // ******************
        var paymentWentThrough = default(bool);

        if (companyInfo.processor == "MerchantWare")
        {
        }
        // not doing here
        else if (companyInfo.processor == "Mercury")
        {
            PreAuthMercury(ref vRow);
        }
        else if (companyInfo.processor == "PaywarePC")
        {
            // PreAuthMercury(vRow)
            PreAuthPaywarePC(ref vRow);
            // PreAuthVeriFone(vRow)
        }

        return paymentWentThrough;

        return default;
        // 222 below

        // If newPayment.PaymentTypeName = "MPS Gift" Then
        // newPayment.Balance = DetermineGiftCard(newPayment, "Balance")
        // End If

        // 444     Dim paymentWentThrough As Boolean
        string authStatus;

        var mpsPreAuth = new TStream();
        var mpsPreAuthTransaction = new PreAuthTransactionClass();

        mpsPreAuthTransaction = _closeAuthTransaction;
        mpsPreAuthTransaction.Account = _closeAuthAccount;
        mpsPreAuthTransaction.Amount = _closeAuthAmount;

        mpsPreAuth.Transaction = mpsPreAuthTransaction;

        var output = new StringWriter(new StringBuilder());
        var s = new XmlSerializer(typeof(TStream));
        s.Serialize(output, mpsPreAuth);

        if (!(typeProgram == "Online_Demo"))
        {
            string transDetails;
            if (useVIEW == true)
            {
                if (vRow("Duplicate") == true)
                {
                    transDetails = "DuplicateAuth";
                }
                else
                {
                    transDetails = "PreAuth";
                }
            }
            else if (orow("Duplicate") == true)
            {
                transDetails = "DuplicateAuth";
            }
            else
            {
                transDetails = "PreAuth";
            }
        }
        // 444    authStatus = SendingDSI222(output.ToString, transDetails, orow, vRow, useVIEW)

        else
        {
            authStatus = "Approved";
            if (useVIEW == true)
            {
                vRow("AuthCode") = "123456";
            }
            else
            {
                orow("AuthCode") = "123456";
            }
        }

        if (authStatus == "Approved")
        {
            paymentWentThrough = true;
        }
        else
        {
            paymentWentThrough = false;
        }

        return paymentWentThrough;

    }

    private object PreAuthMerchantWare_Active(ref DataRowView vRow)
    {

        MerchantAuthPayment?.Invoke(vRow("PaymentID"), true); // true is JustActive
        return default;

    }

    private object PreAuthMerchantWare_All(ref DataRowView vRow)
    {

        MerchantAuthPayment?.Invoke(vRow("PaymentID"), false); // false is AuthAll
        return default;

    }

    private object PreAuthMercury(ref DataRowView vRow)
    {
        // If newPayment.PaymentTypeName = "MPS Gift" Then
        // newPayment.Balance = DetermineGiftCard(newPayment, "Balance")
        // End If

        bool paymentWentThrough;
        string authStatus;

        var mpsPreAuth = new TStream();
        var mpsPreAuthTransaction = new PreAuthTransactionClass();

        mpsPreAuthTransaction = _closeAuthTransaction;
        mpsPreAuthTransaction.Account = _closeAuthAccount;
        mpsPreAuthTransaction.Amount = _closeAuthAmount;

        mpsPreAuth.Transaction = mpsPreAuthTransaction;

        var output = new StringWriter(new StringBuilder());
        var s = new XmlSerializer(typeof(TStream));
        s.Serialize(output, mpsPreAuth);

        if (!(typeProgram == "Online_Demo"))
        {
            string transDetails;
            if (vRow("Duplicate") == true)
            {
                transDetails = "DuplicateAuth";
            }
            else
            {
                transDetails = "PreAuth";
            }

            authStatus = Conversions.ToString(SendingDSI(output.ToString(), transDetails, ref vRow));
        }
        // 444     authStatus = SendingDSI(output.ToString, transDetails, orow, vRow, useVIEW)
        else
        {
            authStatus = "Approved";
            vRow("AuthCode") = "123456";
        }

        if (authStatus == "Approved")
        {
            paymentWentThrough = true;
        }
        else
        {
            paymentWentThrough = false;
        }

        return paymentWentThrough;

    }

    private object SendingDSI(string XMLString, string transDetails, ref DataRowView vRow)
    {

        string resp;
        string authStatus;
        string dataFileLocation;
        // Dim sWriter1 As StreamWriter
        // Dim sWriter2 As StreamWriter

        try
        {
            dsi.ServerIPConfig("x1.mercurypay.com;x2.mercurypay.com;b1.backuppay.com;b2.backuppay.com", 0);
            // dsi.ServerIPConfig("x1.mercurydev.net", 0)
            // dsi.ServerIPConfig("127.0.0.1;x2.mercurypay.com;b1.backuppay.com;b2.backuppay.com", 0)
            resp = dsi.ProcessTransaction(XMLString, 0, "", "");
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Could not establish connection to Payment Processor.");
            return default;
        }

        if (transDetails == "DuplicateAuth")
        {
        }
        // sWriter1 = New StreamWriter("c:\Data Files\spiderPOS\sendDuplicateAuth.txt")
        // sWriter2 = New StreamWriter("c:\Data Files\spiderPOS\PreAuthResponse.txt")
        else if (transDetails == "PreAuth")
        {
        }
        // sWriter1 = New StreamWriter("c:\Data Files\spiderPOS\sendPreAuth.txt")
        // sWriter2 = New StreamWriter("c:\Data Files\spiderPOS\PreAuthResponse.txt")
        else // means something wrong
        {
            return default;
        }

        // sWriter1.Write(XMLString)
        // sWriter1.Close()

        // sWriter2.Write(resp)
        // sWriter2.Close()

        // MsgBox(resp)
        authStatus = Conversions.ToString(ParseXMLResponse(resp, ref vRow)); // orow, vRow, useVIEW)
        return authStatus;

    }

    private object ParseXMLResponse(string resp, ref DataRowView vRow)
    {

        var reader = new XmlTextReader(new StringReader(resp));
        bool someError;
        var isPreAuth = default(bool);
        var isApproved = default(bool);
        var authStatus = default(string);
        var isDeclined = default(bool);
        DataRow pRow;
        var looksLikeDup = default(bool);
        var tempAuthCode = default(string);
        string tempAcqRef;
        var isAmexDcvr = default(bool);
        string tempCardType;

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
                                            isApproved = true;
                                            authStatus = "Approved";
                                            break;
                                        }

                                    case "Declined":
                                        {
                                            isDeclined = true;
                                            break;
                                        }

                                    case "Success":
                                        {
                                            break;
                                        }

                                    case "Error":
                                        {
                                            someError = true;
                                            break;
                                        }
                                        // authStatus = "Declined"
                                }

                                break;
                            }

                        case "TextResponse":
                            {

                                switch (reader.ReadInnerXml() ?? "")
                                {
                                    case "AP":
                                        {
                                            vRow("Description") = "APPROVED";
                                            break;
                                        }

                                    case "OTHER NOT ACCEPTED.":
                                        {
                                            Interaction.MsgBox("CARD Account Number: '" + vRow("AccountNumber") + "' Not correct, please verify input.");
                                            vRow("Description") = "Card Number incorrect";
                                            return "DECLINED";
                                        }

                                    case "DECLINE":
                                        {
                                            break;
                                        }

                                }

                                // If reader.ReadInnerXml.ToString = "AP" Then
                                // ElseIf reader.ReadInnerXml.ToString = "OTHER NOT ACCEPTED." Then
                                // 'could also do an ElseIf Statement for "DELINE", but we flag above
                                // Else
                                // vRow("Description") = reader.ReadInnerXml.ToString
                                // End If

                                // If someError = True Then
                                // If reader.ReadInnerXml.ToString = "OTHER NOT ACCEPTED." Then
                                // MsgBox("CARD Account Number: '" & vRow("AccountNumber") & "' Not correct, please verify input.")
                                // Return "DECLINED"
                                // Else
                                // MsgBox("Error processing card: " & reader.ReadInnerXml.ToString)
                                // Return "Error"
                                // End If

                                // Else
                                if (isDeclined == true)
                                {
                                    Interaction.MsgBox("CARD '" + vRow("AccountNumber") + "' DECLINED: " + reader.ReadInnerXml().ToString());
                                    vRow("Description") = "Declined";
                                    return "DECLINED";
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

                        case "RefNo":
                            {
                                if (isPreAuth == true & isApproved == true)
                                {
                                    // *** ? place RefNo in database
                                    // vrow("RefNo") = reader.ReadInnerXml

                                }

                                break;
                            }

                        case "CardType":
                            {

                                tempCardType = reader.ReadInnerXml().ToString();
                                if (tempCardType == "AMEX" | tempCardType == "DCVR")
                                {
                                    isAmexDcvr = true;
                                }

                                break;
                            }
                        case "AuthCode":
                            {
                                tempAuthCode = reader.ReadInnerXml().ToString();
                                // looksLikeDup = TestForDups(tempAuthCode)
                                if (isAmexDcvr == true)
                                {
                                    // if is duplicate we are overriding 
                                    if (vRow("Duplicate") == false)
                                    {
                                        looksLikeDup = Conversions.ToBoolean(TestForDups(tempAuthCode, null));
                                    }

                                    if (looksLikeDup == true)
                                    {
                                        Interaction.MsgBox("This exact transaction has already been entered. If this is a valid duplicate transaction with the same credit card, please hit the Duplicate Credit button and resend transaction.");
                                        return "DUPLICATE";
                                    }

                                    if (isPreAuth == true & isApproved == true)
                                    {
                                        // place authcode in database
                                        vRow("AuthCode") = tempAuthCode;
                                    }

                                }

                                break;
                            }

                        case "AcqRefData":
                            {
                                // currently not getting here
                                // so we are just checking Approval Code
                                // (which is not perfect but probably ok)
                                tempAcqRef = reader.ReadInnerXml().ToString();

                                // if is duplicate we are overriding 
                                if (vRow("Duplicate") == false)
                                {
                                    looksLikeDup = Conversions.ToBoolean(TestForDups(tempAuthCode, tempAcqRef));
                                }

                                if (looksLikeDup == true)
                                {
                                    Interaction.MsgBox("This exact transaction has already been entered. Verify this is correct.");
                                    // MsgBox("This exact transaction has already been entered. If this is a valid duplicate transaction with the same credit card, please hit the Duplicate Credit button and resend transaction.")
                                    // Return "DUPLICATE"
                                }

                                if (isPreAuth == true & isApproved == true)
                                {
                                    // place authcode in database
                                    vRow("AuthCode") = tempAuthCode;
                                }

                                if (isPreAuth == true & isApproved == true)
                                {
                                    // place acqRefData in database
                                    vRow("AcqRefData") = tempAcqRef;
                                }

                                break;
                            }

                    }
                }
            }
        }
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);
        }
        finally
        {
            if (reader is not null)
            {
                reader.Close();
            }

        }

        return authStatus;

    }

    private object ParseXMLResponse222(string resp, ref DataRow orow, ref DataRowView vRow, bool useVIEW)
    {

        var reader = new XmlTextReader(new StringReader(resp));
        var someError = default(bool);
        var isPreAuth = default(bool);
        var isApproved = default(bool);
        var authStatus = default(string);
        var isDeclined = default(bool);
        DataRow pRow;
        var looksLikeDup = default(bool);
        var tempAuthCode = default(string);
        string tempAcqRef;
        var isAmexDcvr = default(bool);
        string tempCardType;

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
                                            isApproved = true;
                                            authStatus = "Approved";
                                            break;
                                        }

                                    case "Declined":
                                        {
                                            isDeclined = true;
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

                                if (useVIEW == true)
                                {
                                    vRow("Description") = reader.ReadInnerXml().ToString();
                                }
                                else
                                {
                                    orow("Description") = reader.ReadInnerXml().ToString();
                                }

                                if (someError == true)
                                {
                                    Interaction.MsgBox(reader.ReadInnerXml().ToString());
                                    return "Error";
                                }
                                // Exit Function

                                else if (isDeclined == true)
                                {
                                    if (useVIEW == true)
                                    {
                                        Interaction.MsgBox("CARD '" + vRow("AccountNumber") + "' DECLINED: " + reader.ReadInnerXml().ToString());
                                        return "DECLINED";
                                    }
                                    else
                                    {
                                        Interaction.MsgBox("CARD '" + orow("AccountNumber") + "' DECLINED: " + reader.ReadInnerXml().ToString());
                                        return "DECLINED";
                                    }

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

                        case "RefNo":
                            {
                                if (isPreAuth == true & isApproved == true)
                                {
                                    // *** ? place RefNo in database
                                    // vrow("RefNo") = reader.ReadInnerXml

                                }

                                break;
                            }

                        case "CardType":
                            {

                                tempCardType = reader.ReadInnerXml().ToString();
                                if (tempCardType == "AMEX" | tempCardType == "DCVR")
                                {
                                    isAmexDcvr = true;
                                }

                                break;
                            }
                        case "AuthCode":
                            {
                                tempAuthCode = reader.ReadInnerXml().ToString();
                                // looksLikeDup = TestForDups(tempAuthCode)
                                if (isAmexDcvr == true)
                                {
                                    if (useVIEW == true)
                                    {
                                        // if is duplicate we are overriding 
                                        if (vRow("Duplicate") == false)
                                        {
                                            looksLikeDup = Conversions.ToBoolean(TestForDups(tempAuthCode, null));
                                        }
                                    }
                                    else if (orow("Duplicate") == false)
                                    {
                                        looksLikeDup = Conversions.ToBoolean(TestForDups(tempAuthCode, null));
                                    }

                                    if (looksLikeDup == true)
                                    {
                                        Interaction.MsgBox("This exact transaction has already been entered. If this is a valid duplicate transaction with the same credit card, please hit the Duplicate Credit button and resend transaction.");
                                        return "DUPLICATE";
                                    }



                                    if (looksLikeDup == true)
                                    {
                                        // For Each pRow In dsOrder.Tables("PaymentsAndCredits").Rows
                                        // If Not pRow.RowState = DataRowState.Deleted And Not pRow.RowState = DataRowState.Detached Then
                                        // If Not pRow("AcqRefData") Is DBNull.Value Then
                                        // If String.Compare(reader.ReadInnerXml, pRow("AcqRefData"), True) = 0 Then
                                        Interaction.MsgBox("This exact transaction has already been entered. If this is a valid duplicate transaction with the same credit card, please hit the Duplicate Credit button and resend transaction.");
                                        // Exit Function
                                        return "DUPLICATE";
                                        // End If
                                        // End If
                                        // End If
                                        // Next
                                    }
                                    if (isPreAuth == true & isApproved == true)
                                    {
                                        // place authcode in database
                                        if (useVIEW == true)
                                        {
                                            vRow("AuthCode") = tempAuthCode;
                                        }
                                        else
                                        {
                                            orow("AuthCode") = tempAuthCode;
                                        }

                                    }

                                }

                                break;
                            }


                        case "AcqRefData":
                            {
                                // currently not getting here
                                // so we are just checking Approval Code
                                // (which is not perfect but probably ok)
                                tempAcqRef = reader.ReadInnerXml().ToString();

                                if (useVIEW == true)
                                {
                                    // if is duplicate we are overriding 
                                    if (vRow("Duplicate") == false)
                                    {
                                        looksLikeDup = Conversions.ToBoolean(TestForDups(tempAuthCode, tempAcqRef));
                                    }
                                }
                                else if (orow("Duplicate") == false)
                                {
                                    looksLikeDup = Conversions.ToBoolean(TestForDups(tempAuthCode, tempAcqRef));
                                }

                                if (looksLikeDup == true)
                                {
                                    Interaction.MsgBox("This exact transaction has already been entered. If this is a valid duplicate transaction with the same credit card, please hit the Duplicate Credit button and resend transaction.");
                                    return "DUPLICATE";
                                }



                                if (looksLikeDup == true)
                                {
                                    // For Each pRow In dsOrder.Tables("PaymentsAndCredits").Rows
                                    // If Not pRow.RowState = DataRowState.Deleted And Not pRow.RowState = DataRowState.Detached Then
                                    // If Not pRow("AcqRefData") Is DBNull.Value Then
                                    // If String.Compare(reader.ReadInnerXml, pRow("AcqRefData"), True) = 0 Then
                                    Interaction.MsgBox("This exact transaction has already been entered. If this is a valid duplicate transaction with the same credit card, please hit the Duplicate Credit button and resend transaction.");
                                    // Exit Function
                                    return "DUPLICATE";
                                    // End If
                                    // End If
                                    // End If
                                    // Next
                                }
                                if (isPreAuth == true & isApproved == true)
                                {
                                    // place authcode in database
                                    if (useVIEW == true)
                                    {
                                        vRow("AuthCode") = tempAuthCode;
                                    }
                                    else
                                    {
                                        orow("AuthCode") = tempAuthCode;
                                    }

                                }
                                if (isPreAuth == true & isApproved == true)
                                {
                                    // place acqRefData in database
                                    if (useVIEW == true)
                                    {
                                        vRow("AcqRefData") = tempAcqRef;
                                    }
                                    else
                                    {
                                        orow("AcqRefData") = tempAcqRef;
                                    }
                                }

                                break;
                            }

                    }
                }
            }
        }
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);
        }
        finally
        {
            if (reader is not null)
            {
                reader.Close();
            }

        }

        return authStatus;

    }


    private object TestForDups(string authString, string refString)
    {
        var isDuiplicate = default(bool);

        // *** need to add back RefNum Data (not for AMEX)

        foreach (DataRow pRow in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            if (!(pRow.RowState == DataRowState.Deleted))
            {
                // If orow("CheckNumber") = currentTable.CheckNumber Then
                // If orow("Applied") = True Then
                // If Not pRow("AcqRefData") Is DBNull.Value And Not pRow("AuthCode") Is DBNull.Value Then
                if (!object.ReferenceEquals(pRow("AuthCode"), DBNull.Value))
                {
                    // MsgBox(authString)
                    // MsgBox(pRow("AuthCode"))
                    // MsgBox(refString)
                    // MsgBox(pRow("AcqRefData"))
                    // If String.Compare(refString, pRow("AcqRefData"), True) = 0 And String.Compare(authString, pRow("AuthCode"), True) = 0 Then
                    if (string.Compare(authString, pRow("AuthCode"), true) == 0)
                    {
                        // MsgBox("This exact transaction has already been entered. If this is a valid duplicate transaction with the same credit card, please hit the Duplicate Credit button and resend transaction.")
                        // Return "DUPLICATE"
                        isDuiplicate = true;
                        // looksLikeDup = True
                    }
                    // End If
                    // End If
                }
            }
        }

        return isDuiplicate;

    }

    private void PrintCreditCardReceipt(ref DataRow orow, ref DataRowView vRow, bool useVIEW)
    {

        prt.ccDataRow = orow;
        prt.ccDataRowView = vRow;
        prt.useVIEW = useVIEW;
        prt.StartPrintCreditCardRest();
        prt.StartPrintCreditCardGuest();

        // ***
        // vRow("AccountNumber") = TruncateAccountNumber(vRow("AccountNumber"))

    }

    private object TestPayments(decimal payAmount) // (ByRef vRow As DataRowView)
    {

        if ((double)payAmount > (double)RemainingBalance + 0.02d)
        {
            // remainingBalance is what has already been applied
            if (Interaction.MsgBox("You are applying more than the balance. Are you sure?", MsgBoxStyle.YesNo) == MsgBoxResult.No)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        return true;

    }

    private object TestAccountNumber(ref DataRowView vRow)
    {

        if (object.ReferenceEquals(vRow("AccountNumber"), DBNull.Value))
        {
            Interaction.MsgBox("You must Enter a valid Account Number");
            return false;
        }

        if (object.ReferenceEquals(vRow("CCExpiration"), DBNull.Value))
        {
            Interaction.MsgBox("You must Enter a valid Expiration Date");
            return false;
        }
        else if (ValidateExpDate(vRow("CCExpiration")) == false)
        {
            // 444    MsgBox("You must Enter a valid Expiration Date")
            return false;
        }

        return true;

    }

    private void PaymentUserControl_History(object sender, EventArgs e)     // (ByVal ai As Integer) Handles paymentUserControl.ActivePanel
    {

        var newPayment = new DataSet_Builder.Payment();
        foreach (DataSet_Builder.Payment currentNewPayment in tabcc)
        {
            newPayment = currentNewPayment;
            if (Operators.ConditionalCompareObjectEqual(newPayment.AccountNumber, sender.AcctNumber, false))
            {
                break;
            }
        }

        if (newPayment.LastName is null | newPayment.AccountNumber is null)
            return;

        // **** this is going to event in Split checks
        FireTabScreen?.Invoke("Account", newPayment.SpiderAcct);
        return;
        // 222

        newPayment.SpiderAcct = CreateAccountNumber(newPayment); // .LastName, newPayment.AccountNumber)
        TabEnterScreen = new Tab_Screen(); // "Account")
        TabEnterScreen.Location = new Point((this.Width - TabEnterScreen.Width - 10) / 2, (this.Height - TabEnterScreen.Height) / 2);
        this.Controls.Add(TabEnterScreen);
        TabEnterScreen.BringToFront();

        TabEnterScreen.SearchAccount(newPayment.SpiderAcct); // , -123456789)
        TabEnterScreen.BindDataAfterSearch();
        DisableControls();

    }

    private void CloseSelectedReOrder(DataTable dt, bool tabTestNeeded)
    {

        // need to send data table
        SelectedReOrder?.Invoke(dt, true);

    }

    private void CloseTabEnter222()
    {

        if (TabEnterScreen.attemptedToEdit == true)
        {
            GenerateOrderTables.UpdateTabInfo(TabEnterScreen.StartInSearch);
        }

        // Me.TabEnterScreen.Dispose()
        TabEnterScreen.Hide();
        EnableControls();

    }

    private void DisableControls()
    {

        pnlExit.Enabled = false;
        pnlPayOptions.Enabled = false;
        pnlClosePayments.Enabled = false;
        pnlBalance.Enabled = false;
        pnlPayRemove.Enabled = false;
        NumberPadLarge1.Enabled = false;

    }

    private void EnableControls()
    {

        pnlExit.Enabled = true;
        pnlPayOptions.Enabled = true;
        pnlClosePayments.Enabled = true;
        pnlBalance.Enabled = true;
        pnlPayRemove.Enabled = true;
        NumberPadLarge1.Enabled = true;

    }

    private void PaymentUserControl_Click(object sender, EventArgs e)     // (ByVal ai As Integer) Handles paymentUserControl.ActivePanel
    {
        ResetTimer();

        DataSet_Builder.Payment_UC objButton;

        try
        {
            objButton = (DataSet_Builder.Payment_UC)sender;
        }
        catch (Exception ex)
        {
            return;
        }

        switch (objButton.CurrentState)
        {
            case var @case when @case == DataSet_Builder.Payment_UC.PanelHit.AccountPanel:
                {
                    NumberPadLarge1.DecimalUsed = false;
                    NumberPadLarge1.NumberString = objButton.AcctNumber;
                    break;
                }

            case var case1 when case1 == DataSet_Builder.Payment_UC.PanelHit.ExpDatePanel:
                {
                    NumberPadLarge1.DecimalUsed = false;
                    NumberPadLarge1.NumberString = objButton.ExpDate;
                    break;
                }

            case var case2 when case2 == DataSet_Builder.Payment_UC.PanelHit.PurchasePanel:
                {
                    NumberPadLarge1.DecimalUsed = true;
                    NumberPadLarge1.NumberTotal = objButton.PurchaseAmount;
                    // 444           NumberPadLarge1.NumberString = objButton.PurchaseAmount
                    _lastPurchaseIssueAmount = objButton.PurchaseAmount * -1; // for Gift
                    break;
                }

            case var case3 when case3 == DataSet_Builder.Payment_UC.PanelHit.TipPanel:
                {
                    NumberPadLarge1.DecimalUsed = true;
                    NumberPadLarge1.NumberTotal = objButton.TipAmount;
                    break;
                }
                // 444        NumberPadLarge1.NumberString = objButton.TipAmount

        }
        NumberPadLarge1.ShowNumberString();
        NumberPadLarge1.NumberString = "";

        if (!(paymentRowIndex == objButton.ActiveIndex))
        {
            paymentRowIndex = objButton.ActiveIndex;
            ActiveThisPanel(objButton.ActiveIndex);
        }


        // Me.NumberPadLarge1.DecimalUsed = True
        // Me.NumberPadLarge1.NumberTotal = 0
        // Me.NumberPadLarge1.IntegerNumber = 0
        // Me.NumberPadLarge1.NumberString = ""
        // Me.NumberPadLarge1.ShowNumberString()

    }

    private void ActiveThisPanel(int ai)
    {

        if (paymentRowIndex == 0)
            return;

        DataRowView vRow;
        int index = 1;

        foreach (DataRowView currentVRow in dvUnAppliedPaymentsAndCredits_MWE)
        {
            vRow = currentVRow;
            if (index >= startPaymentIndex & index <= startPaymentIndex + 5)
            {
                if (!(index == ai))
                {
                    paymentPanel[index].BackColor = Color.DarkGray;
                    paymentPanel[index].IsActive = false;
                }
                else
                {
                    paymentPanel[index].BackColor = Color.WhiteSmoke;
                    paymentPanel[paymentRowIndex].CurrentState = DataSet_Builder.Payment_UC.PanelHit.PurchasePanel;
                    // unappliedRowIndex = ai
                    PaymentPanelActivated();
                }
            }
            index += 1;
        }

        foreach (DataRowView currentVRow1 in dvClosingCheckPayments)
        {
            vRow = currentVRow1;
            if (index >= startPaymentIndex & index <= startPaymentIndex + 5)
            {
                if (!(index == ai))
                {
                    paymentPanel[index].BackColor = Color.DarkGray;
                    paymentPanel[index].IsActive = false;
                }
                else
                {
                    paymentPanel[index].BackColor = Color.WhiteSmoke;
                    paymentPanel[paymentRowIndex].CurrentState = DataSet_Builder.Payment_UC.PanelHit.PurchasePanel;
                    // unappliedRowIndex = ai
                    PaymentPanelActivated();
                }
            }
            index += 1;
        }

    }

    private void PaymentPanelActivated()
    {

        switch (paymentPanel[paymentRowIndex].CurrentState)
        {
            case var @case when @case == DataSet_Builder.Payment_UC.PanelHit.PurchasePanel:
                {
                    NumberPadLarge1.DecimalUsed = true;
                    NumberPadLarge1.NumberTotal = paymentPanel[paymentRowIndex].PurchaseAmount;
                    NumberPadLarge1.ShowNumberString();
                    NumberPadLarge1.Focus();
                    NumberPadLarge1.IntegerNumber = 0;
                    NumberPadLarge1.NumberString = "";    // Nothing
                    break;
                }

            case var case1 when case1 == DataSet_Builder.Payment_UC.PanelHit.TipPanel:
                {
                    NumberPadLarge1.DecimalUsed = true;
                    NumberPadLarge1.NumberTotal = paymentPanel[paymentRowIndex].PurchaseAmount;
                    NumberPadLarge1.ShowNumberString();
                    NumberPadLarge1.Focus();
                    NumberPadLarge1.IntegerNumber = 0;
                    NumberPadLarge1.NumberString = "";    // Nothing
                    break;
                }

        }

    }

    private void PaymentEnterHit(object sender, EventArgs e)
    {
        // 
        // dvUnAppliedPaymentsAndCredits   is zero based
        if (paymentRowIndex == 0)
            return;
        bool UnAuthPanel;
        int UnAuthIndex;

        if (paymentRowIndex > dvClosingCheckPayments.Count)
        {
            // we will use:   dvUnAppliedPaymentsAndCredits_MWE 
            UnAuthPanel = true;
            UnAuthIndex = paymentRowIndex - dvClosingCheckPayments.Count - 1;
            PaymentEnterStep2_UnAuth(UnAuthIndex);
        }
        else
        {
            PaymentEnterStep2_AlreadyAuth();
        }

    }

    private void PaymentEnterStep2_AlreadyAuth()
    {
        var noTip = default(bool);

        switch (paymentPanel[paymentRowIndex].CurrentState)
        {
            case var @case when @case == DataSet_Builder.Payment_UC.PanelHit.PurchasePanel:
                {

                    if (!object.ReferenceEquals(dvClosingCheckPayments[paymentRowIndex - 1]("AuthCode"), DBNull.Value))
                        return;

                    if (dvClosingCheckPayments[paymentRowIndex - 1]("PaymentTypeID") == -97)
                    {
                        // this is issue of gift card
                        // we need this to be a liability on Balance sheet, therefore is negative
                        _checkGiftIssuingAmount = _checkGiftIssuingAmount + NumberPadLarge1.NumberTotal - _lastPurchaseIssueAmount;
                        _lastPurchaseIssueAmount = _checkGiftIssuingAmount;
                        NumberPadLarge1.NumberTotal *= -1;
                        noTip = true;
                    }
                    if (GiftAddingAmount == true)
                    {
                        // for return - which is adding money to gift card
                        dvClosingCheckPayments[paymentRowIndex - 1]("PaymentTypeID") = -97;
                        dvClosingCheckPayments[paymentRowIndex - 1]("PaymentTypeName") = "Increase Gift";
                        dvClosingCheckPayments[paymentRowIndex - 1]("PaymentFlag") = "Issue";
                        // we can subtract below b/c we are resetting GiftCardAdd to False
                        _checkGiftIssuingAmount = _checkGiftIssuingAmount + NumberPadLarge1.NumberTotal - _lastPurchaseIssueAmount;
                        _lastPurchaseIssueAmount = _checkGiftIssuingAmount;
                        // _checkGiftIssuingAmount -= NumberPadLarge1.NumberTotal
                        NumberPadLarge1.NumberTotal *= -1;
                        noTip = true;
                        ReturnGiftCardAddToFalse();
                        paymentPanel[paymentRowIndex].UpdatePayType("Increase Gift");
                    }

                    dvClosingCheckPayments[paymentRowIndex - 1]("PaymentAmount") = NumberPadLarge1.NumberTotal;
                    paymentPanel[paymentRowIndex].UpdatePurchase(NumberPadLarge1.NumberTotal);

                    if (noTip == true)
                        break;
                    if (currentTable.AutoGratuity > 0)
                    {
                        decimal adjTip = Conversions.ToDecimal(Strings.Format(NumberPadLarge1.NumberTotal * companyInfo.autoGratuityPercent, "##,###.00"));
                        dvClosingCheckPayments[paymentRowIndex - 1]("Tip") = adjTip;
                        paymentPanel[paymentRowIndex].UpdateTip(adjTip);
                    }
                    creditAmountAdjusted = true;
                    break;
                }
            case var case1 when case1 == DataSet_Builder.Payment_UC.PanelHit.TipPanel:
                {
                    if (GiftAddingAmount == true | dvClosingCheckPayments[paymentRowIndex - 1]("PaymentTypeID") == -97)
                    {
                        break;
                    }
                    if (NumberPadLarge1.NumberTotal > dvClosingCheckPayments[paymentRowIndex - 1]("PaymentAmount"))
                    {
                        if (Interaction.MsgBox("Gratuity Amount is greater than Purchase. Please Verify", MsgBoxStyle.OkCancel) == MsgBoxResult.Cancel)
                        {
                            return;
                        }
                    }
                    dvClosingCheckPayments[paymentRowIndex - 1]("Tip") = NumberPadLarge1.NumberTotal;
                    paymentPanel[paymentRowIndex].UpdateTip(NumberPadLarge1.NumberTotal);
                    creditAmountAdjusted = true;
                    break;
                }

            case var case2 when case2 == DataSet_Builder.Payment_UC.PanelHit.AccountPanel:
                {

                    if (companyInfo.usingOutsideCreditProcessor == true)
                        return;
                    string typeName;
                    int ccID;
                    // newPayment.AccountNumber = Me.NumberPadLarge1.NumberString
                    // only holding info here
                    if (NumberPadLarge1.NumberString == "999" | NumberPadLarge1.NumberString == "9999")
                    {
                        // this is to force outside credit processor
                        if (object.ReferenceEquals(dvClosingCheckPayments[paymentRowIndex - 1]("AuthCode"), DBNull.Value))
                        {
                            dvClosingCheckPayments[paymentRowIndex - 1]("PaymentTypeID") = 9;
                            dvClosingCheckPayments[paymentRowIndex - 1]("PaymentTypeName") = "Outside Credit";
                            dvClosingCheckPayments[paymentRowIndex - 1]("PaymentFlag") = "outside";
                            paymentPanel[paymentRowIndex].UpdatePayType("Outside Credit");
                            return;
                        }

                    }

                    typeName = DetermineCreditCardName(NumberPadLarge1.NumberString);
                    if (typeName.Length > 0)
                    {
                        ccID = DetermineCreditCardID(typeName); // Me.NumberPadLarge1.NumberString)
                        dvClosingCheckPayments[paymentRowIndex - 1]("AccountNumber") = NumberPadLarge1.NumberString;
                        dvClosingCheckPayments[paymentRowIndex - 1]("PaymentTypeID") = ccID;

                        paymentPanel[paymentRowIndex].UpdateAcct(NumberPadLarge1.NumberString);
                        paymentPanel[paymentRowIndex].UpdatePayType(typeName);

                        paymentPanel[paymentRowIndex].CurrentState = DataSet_Builder.Payment_UC.PanelHit.ExpDatePanel;
                        NumberPadLarge1.NumberString = "Enter Exp Date ";
                        NumberPadLarge1.ShowNumberString();
                        NumberPadLarge1.NumberString = "";
                    }
                    else
                    {
                        Interaction.MsgBox("Can not recognize Card Number. Verify Input.");

                    }

                    break;
                }

            case var case3 when case3 == DataSet_Builder.Payment_UC.PanelHit.ExpDatePanel:
                {
                    if (companyInfo.usingOutsideCreditProcessor == true)
                        return;
                    if (NumberPadLarge1.NumberString.Length == 4)
                    {
                        dvClosingCheckPayments[paymentRowIndex - 1]("CCExpiration") = NumberPadLarge1.NumberString;
                        paymentPanel[paymentRowIndex].UpdateExpDate(NumberPadLarge1.NumberString);
                    }
                    else
                    {
                        Interaction.MsgBox("Expiration Date Must be in MMYY Format");
                        NumberPadLarge1.NumberString = "Enter Exp Date ";
                        NumberPadLarge1.ShowNumberString();
                        NumberPadLarge1.NumberString = "";
                    }

                    break;
                }

            case var case4 when case4 == DataSet_Builder.Payment_UC.PanelHit.VoiceAuth:
                {
                    if (companyInfo.usingOutsideCreditProcessor == true)
                        return;
                    if (NumberPadLarge1.NumberString.Length == 6)
                    {
                        DataRowView vRow = dvClosingCheckPayments[paymentRowIndex - 1];
                        vRow("AuthCode") = NumberPadLarge1.NumberString;
                        paymentPanel[paymentRowIndex].UpdateAuthCode(NumberPadLarge1.NumberString);
                        vRow("Track2") = DBNull.Value;
                        // vRow("AccountNumber") = TruncateAccountNumber(vRow("AccountNumber"))
                        vRow("TransactionCode") = "VoiceAuth";

                        if (object.ReferenceEquals(vRow("RefNum"), DBNull.Value))
                        {
                            vRow("RefNum") = currentTable.TruncatedExpNum.ToString;
                        }

                        if (vRow("Duplicate") == true)
                        {
                            vRow("RefNum") = (currentTable.TruncatedExpNum + "-" + dvAppliedPayments.Count + 1).ToString;
                        }

                        var argorow = default;
                        PrintCreditCardReceipt(ref argorow, ref vRow, true);

                        RemainingBalance -= vRow("PaymentAmount");
                        // paymentRowIndex -= 1
                        // unappliedRowIndex -= 1

                        vRow("Applied") = true;
                        closeCheckTotals.AttachTotalsToTotalView(currentTable.CheckNumber);
                        GetNumberOfActivePayments(currentTable.CheckNumber);
                    }

                    break;
                }
        }

        ShowRemainingBalance();
    }


    private void PaymentEnterStep2_UnAuth(int UnAuthIndex)
    {
        var noTip = default(bool);

        switch (paymentPanel[paymentRowIndex].CurrentState)
        {
            case var @case when @case == DataSet_Builder.Payment_UC.PanelHit.PurchasePanel:
                {

                    if (!object.ReferenceEquals(dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex]("AuthCode"), DBNull.Value))
                        return;

                    if (dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex]("PaymentTypeID") == -97)
                    {
                        // this is issue of gift card
                        // we need this to be a liability on Balance sheet, therefore is negative
                        _checkGiftIssuingAmount = _checkGiftIssuingAmount + NumberPadLarge1.NumberTotal - _lastPurchaseIssueAmount;
                        _lastPurchaseIssueAmount = _checkGiftIssuingAmount;
                        NumberPadLarge1.NumberTotal *= -1;
                        noTip = true;
                    }
                    if (GiftAddingAmount == true)
                    {
                        // for return - which is adding money to gift card
                        dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex]("PaymentTypeID") = -97;
                        dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex]("PaymentTypeName") = "Increase Gift";
                        dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex]("PaymentFlag") = "Issue";
                        // we can subtract below b/c we are resetting GiftCardAdd to False
                        _checkGiftIssuingAmount = _checkGiftIssuingAmount + NumberPadLarge1.NumberTotal - _lastPurchaseIssueAmount;
                        _lastPurchaseIssueAmount = _checkGiftIssuingAmount;
                        // _checkGiftIssuingAmount -= NumberPadLarge1.NumberTotal
                        NumberPadLarge1.NumberTotal *= -1;
                        noTip = true;
                        ReturnGiftCardAddToFalse();
                        paymentPanel[paymentRowIndex].UpdatePayType("Increase Gift");
                    }

                    dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex]("PaymentAmount") = NumberPadLarge1.NumberTotal;
                    paymentPanel[paymentRowIndex].UpdatePurchase(NumberPadLarge1.NumberTotal);

                    if (noTip == true)
                        break;
                    if (currentTable.AutoGratuity > 0)
                    {
                        decimal adjTip = Conversions.ToDecimal(Strings.Format(NumberPadLarge1.NumberTotal * companyInfo.autoGratuityPercent, "##,###.00"));
                        dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex]("Tip") = adjTip;
                        paymentPanel[paymentRowIndex].UpdateTip(adjTip);
                    }
                    creditAmountAdjusted = true;
                    break;
                }
            case var case1 when case1 == DataSet_Builder.Payment_UC.PanelHit.TipPanel:
                {
                    if (GiftAddingAmount == true | dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex]("PaymentTypeID") == -97)
                    {
                        break;
                    }
                    if (NumberPadLarge1.NumberTotal > dvUnAppliedPaymentsAndCredits_MWE[paymentRowIndex - 1]("PaymentAmount"))
                    {
                        if (Interaction.MsgBox("Gratuity Amount is greater than Purchase. Please Verify", MsgBoxStyle.OkCancel) == MsgBoxResult.Cancel)
                        {
                            return;
                        }
                    }
                    dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex]("Tip") = NumberPadLarge1.NumberTotal;
                    paymentPanel[paymentRowIndex].UpdateTip(NumberPadLarge1.NumberTotal);
                    creditAmountAdjusted = true;
                    break;
                }

            case var case2 when case2 == DataSet_Builder.Payment_UC.PanelHit.AccountPanel:
                {

                    if (companyInfo.usingOutsideCreditProcessor == true)
                        return;
                    string typeName;
                    int ccID;
                    // newPayment.AccountNumber = Me.NumberPadLarge1.NumberString
                    // only holding info here
                    if (NumberPadLarge1.NumberString == "999" | NumberPadLarge1.NumberString == "9999")
                    {
                        // this is to force outside credit processor
                        if (object.ReferenceEquals(dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex]("AuthCode"), DBNull.Value))
                        {
                            dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex]("PaymentTypeID") = 9;
                            dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex]("PaymentTypeName") = "Outside Credit";
                            dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex]("PaymentFlag") = "outside";
                            paymentPanel[paymentRowIndex].UpdatePayType("Outside Credit");
                            return;
                        }

                    }

                    typeName = DetermineCreditCardName(NumberPadLarge1.NumberString);
                    if (typeName.Length > 0)
                    {
                        ccID = DetermineCreditCardID(typeName); // Me.NumberPadLarge1.NumberString)
                        dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex]("AccountNumber") = NumberPadLarge1.NumberString;
                        dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex]("PaymentTypeID") = ccID;

                        paymentPanel[paymentRowIndex].UpdateAcct(NumberPadLarge1.NumberString);
                        paymentPanel[paymentRowIndex].UpdatePayType(typeName);

                        paymentPanel[paymentRowIndex].CurrentState = DataSet_Builder.Payment_UC.PanelHit.ExpDatePanel;
                        NumberPadLarge1.NumberString = "Enter Exp Date ";
                        NumberPadLarge1.ShowNumberString();
                        NumberPadLarge1.NumberString = "";
                    }
                    else
                    {
                        Interaction.MsgBox("Can not recognize Card Number. Verify Input.");

                    }

                    break;
                }

            case var case3 when case3 == DataSet_Builder.Payment_UC.PanelHit.ExpDatePanel:
                {
                    if (companyInfo.usingOutsideCreditProcessor == true)
                        return;
                    if (NumberPadLarge1.NumberString.Length == 4)
                    {
                        dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex]("CCExpiration") = NumberPadLarge1.NumberString;
                        paymentPanel[paymentRowIndex].UpdateExpDate(NumberPadLarge1.NumberString);
                    }
                    else
                    {
                        Interaction.MsgBox("Expiration Date Must be in MMYY Format");
                        NumberPadLarge1.NumberString = "Enter Exp Date ";
                        NumberPadLarge1.ShowNumberString();
                        NumberPadLarge1.NumberString = "";
                    }

                    break;
                }

            case var case4 when case4 == DataSet_Builder.Payment_UC.PanelHit.VoiceAuth:
                {
                    if (companyInfo.usingOutsideCreditProcessor == true)
                        return;
                    if (NumberPadLarge1.NumberString.Length == 6)
                    {
                        DataRowView vRow = dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex];
                        vRow("AuthCode") = NumberPadLarge1.NumberString;
                        paymentPanel[paymentRowIndex].UpdateAuthCode(NumberPadLarge1.NumberString);
                        // vRow("Track2") = DBNull.Value
                        // vRow("AccountNumber") = TruncateAccountNumber(vRow("AccountNumber"))
                        vRow("TransactionCode") = "VoiceAuth";

                        if (object.ReferenceEquals(vRow("RefNum"), DBNull.Value))
                        {
                            vRow("RefNum") = currentTable.TruncatedExpNum.ToString;
                        }

                        if (vRow("Duplicate") == true)
                        {
                            vRow("RefNum") = (currentTable.TruncatedExpNum + "-" + dvAppliedPayments.Count + 1).ToString;
                        }

                        var argorow = default;
                        PrintCreditCardReceipt(ref argorow, ref vRow, true);

                        RemainingBalance -= vRow("PaymentAmount");
                        // paymentRowIndex -= 1
                        // unappliedRowIndex -= 1

                        vRow("Applied") = true;
                        closeCheckTotals.AttachTotalsToTotalView(currentTable.CheckNumber);
                        GetNumberOfActivePayments(currentTable.CheckNumber);
                    }

                    break;
                }
        }

        ShowRemainingBalance();
    }


    private void PaymentEnterHit_Copy222(object sender, EventArgs e) // Handles NumberPadLarge1.NumberEntered
    {
        // 
        // dvUnAppliedPaymentsAndCredits   is zero based
        if (paymentRowIndex == 0)
            return;
        // Dim newPayment As New Payment  'this is only a temp holding structure
        var noTip = default(bool);
        bool UnAuthPanel;
        int UnAuthIndex;

        if (paymentRowIndex > dvClosingCheckPayments.Count)
        {
            UnAuthPanel = true;
            UnAuthIndex = paymentRowIndex - dvClosingCheckPayments.Count - 1;
        }

        switch (paymentPanel[paymentRowIndex].CurrentState)
        {
            case var @case when @case == DataSet_Builder.Payment_UC.PanelHit.PurchasePanel:
                {

                    if (!object.ReferenceEquals(dvClosingCheckPayments[paymentRowIndex - 1]("AuthCode"), DBNull.Value))
                        return;

                    if (dvClosingCheckPayments[paymentRowIndex - 1]("PaymentTypeID") == -97)
                    {
                        // this is issue of gift card
                        // we need this to be a liability on Balance sheet, therefore is negative
                        _checkGiftIssuingAmount = _checkGiftIssuingAmount + NumberPadLarge1.NumberTotal - _lastPurchaseIssueAmount;
                        _lastPurchaseIssueAmount = _checkGiftIssuingAmount;
                        NumberPadLarge1.NumberTotal *= -1;
                        noTip = true;
                    }
                    if (GiftAddingAmount == true)
                    {
                        // for return - which is adding money to gift card
                        dvClosingCheckPayments[paymentRowIndex - 1]("PaymentTypeID") = -97;
                        dvClosingCheckPayments[paymentRowIndex - 1]("PaymentTypeName") = "Increase Gift";
                        dvClosingCheckPayments[paymentRowIndex - 1]("PaymentFlag") = "Issue";
                        // we can subtract below b/c we are resetting GiftCardAdd to False
                        _checkGiftIssuingAmount = _checkGiftIssuingAmount + NumberPadLarge1.NumberTotal - _lastPurchaseIssueAmount;
                        _lastPurchaseIssueAmount = _checkGiftIssuingAmount;
                        // _checkGiftIssuingAmount -= NumberPadLarge1.NumberTotal
                        NumberPadLarge1.NumberTotal *= -1;
                        noTip = true;
                        ReturnGiftCardAddToFalse();
                        paymentPanel[paymentRowIndex].UpdatePayType("Increase Gift");

                    }

                    dvClosingCheckPayments[paymentRowIndex - 1]("PaymentAmount") = NumberPadLarge1.NumberTotal;
                    paymentPanel[paymentRowIndex].UpdatePurchase(NumberPadLarge1.NumberTotal);

                    if (noTip == true)
                        break;
                    if (currentTable.AutoGratuity > 0)
                    {
                        decimal adjTip = Conversions.ToDecimal(Strings.Format(NumberPadLarge1.NumberTotal * companyInfo.autoGratuityPercent, "##,###.00"));
                        dvClosingCheckPayments[paymentRowIndex - 1]("Tip") = adjTip;
                        paymentPanel[paymentRowIndex].UpdateTip(adjTip);
                    }
                    creditAmountAdjusted = true;
                    break;
                }
            case var case1 when case1 == DataSet_Builder.Payment_UC.PanelHit.TipPanel:
                {
                    if (GiftAddingAmount == true | dvClosingCheckPayments[paymentRowIndex - 1]("PaymentTypeID") == -97)
                    {
                        break;
                    }
                    dvClosingCheckPayments[paymentRowIndex - 1]("Tip") = NumberPadLarge1.NumberTotal;
                    paymentPanel[paymentRowIndex].UpdateTip(NumberPadLarge1.NumberTotal);
                    creditAmountAdjusted = true;
                    break;
                }

            case var case2 when case2 == DataSet_Builder.Payment_UC.PanelHit.AccountPanel:
                {

                    if (companyInfo.usingOutsideCreditProcessor == true)
                        return;
                    string typeName;
                    int ccID;
                    // newPayment.AccountNumber = Me.NumberPadLarge1.NumberString
                    // only holding info here
                    if (NumberPadLarge1.NumberString == "999" | NumberPadLarge1.NumberString == "9999")
                    {
                        // this is to force outside credit processor
                        if (object.ReferenceEquals(dvClosingCheckPayments[paymentRowIndex - 1]("AuthCode"), DBNull.Value))
                        {
                            dvClosingCheckPayments[paymentRowIndex - 1]("PaymentTypeID") = 9;
                            dvClosingCheckPayments[paymentRowIndex - 1]("PaymentTypeName") = "Outside Credit";
                            dvClosingCheckPayments[paymentRowIndex - 1]("PaymentFlag") = "outside";
                            paymentPanel[paymentRowIndex].UpdatePayType("Outside Credit");
                            return;
                        }

                    }

                    typeName = DetermineCreditCardName(NumberPadLarge1.NumberString);
                    if (typeName.Length > 0)
                    {
                        ccID = DetermineCreditCardID(typeName); // Me.NumberPadLarge1.NumberString)
                        dvClosingCheckPayments[paymentRowIndex - 1]("AccountNumber") = NumberPadLarge1.NumberString;
                        dvClosingCheckPayments[paymentRowIndex - 1]("PaymentTypeID") = ccID;

                        paymentPanel[paymentRowIndex].UpdateAcct(NumberPadLarge1.NumberString);
                        paymentPanel[paymentRowIndex].UpdatePayType(typeName);

                        paymentPanel[paymentRowIndex].CurrentState = DataSet_Builder.Payment_UC.PanelHit.ExpDatePanel;
                        NumberPadLarge1.NumberString = "Enter Exp Date ";
                        NumberPadLarge1.ShowNumberString();
                        NumberPadLarge1.NumberString = "";
                    }
                    else
                    {
                        Interaction.MsgBox("Can not recognize Card Number. Verify Input.");

                    }

                    break;
                }

            case var case3 when case3 == DataSet_Builder.Payment_UC.PanelHit.ExpDatePanel:
                {
                    if (companyInfo.usingOutsideCreditProcessor == true)
                        return;
                    if (NumberPadLarge1.NumberString.Length == 4)
                    {
                        dvClosingCheckPayments[paymentRowIndex - 1]("CCExpiration") = NumberPadLarge1.NumberString;
                        paymentPanel[paymentRowIndex].UpdateExpDate(NumberPadLarge1.NumberString);
                    }
                    else
                    {
                        Interaction.MsgBox("Expiration Date Must be in MMYY Format");
                        NumberPadLarge1.NumberString = "Enter Exp Date ";
                        NumberPadLarge1.ShowNumberString();
                        NumberPadLarge1.NumberString = "";
                    }

                    break;
                }

            case var case4 when case4 == DataSet_Builder.Payment_UC.PanelHit.VoiceAuth:
                {
                    if (companyInfo.usingOutsideCreditProcessor == true)
                        return;
                    if (NumberPadLarge1.NumberString.Length == 6)
                    {
                        DataRowView vRow = dvClosingCheckPayments[paymentRowIndex - 1];
                        vRow("AuthCode") = NumberPadLarge1.NumberString;
                        paymentPanel[paymentRowIndex].UpdateAuthCode(NumberPadLarge1.NumberString);
                        vRow("Track2") = DBNull.Value;
                        // vRow("AccountNumber") = TruncateAccountNumber(vRow("AccountNumber"))
                        vRow("TransactionCode") = "VoiceAuth";

                        if (object.ReferenceEquals(vRow("RefNum"), DBNull.Value))
                        {
                            vRow("RefNum") = currentTable.TruncatedExpNum.ToString;
                        }

                        if (vRow("Duplicate") == true)
                        {
                            vRow("RefNum") = (currentTable.TruncatedExpNum + "-" + dvAppliedPayments.Count + 1).ToString;
                        }

                        var argorow = default;
                        PrintCreditCardReceipt(ref argorow, ref vRow, true);

                        RemainingBalance -= vRow("PaymentAmount");
                        // paymentRowIndex -= 1
                        // unappliedRowIndex -= 1

                        vRow("Applied") = true;
                        closeCheckTotals.AttachTotalsToTotalView(currentTable.CheckNumber);
                        GetNumberOfActivePayments(currentTable.CheckNumber);
                    }

                    break;
                }


        }

        ShowRemainingBalance();

    }

    private void btnClose1_Click(object sender, EventArgs e)
    {

        AddAutoCash(1m);

    }

    private void btnClose5_Click(object sender, EventArgs e)
    {
        AddAutoCash(5m);

    }

    private void btnClose10_Click(object sender, EventArgs e)
    {
        AddAutoCash(10m);
    }

    private void btnClose20_Click(object sender, EventArgs e)
    {
        AddAutoCash(20m);

    }

    private void btnClose50_Click(object sender, EventArgs e)
    {
        AddAutoCash(50m);

    }

    private void btnClose100_Click(object sender, EventArgs e)
    {
        AddAutoCash(100m);

    }

    private void btnCloseCash_Click(object sender, EventArgs e)
    {

        CashButtonClicked();

    }

    internal void CashButtonClicked()
    {
        decimal amount;

        amount = Conversions.ToDecimal(DetermineCashToCredit());
        AddAutoCash(amount);

    }

    private void btnCloseManualcc_Click(object sender, EventArgs e)
    {

        var newPayment = default(DataSet_Builder.Payment);
        decimal amount;

        amount = Conversions.ToDecimal(DetermineCashToCredit());
        newPayment.Purchase = Strings.Format(amount, "##,##0.00");
        if (companyInfo.usingOutsideCreditProcessor == false)
        {
            newPayment.PaymentTypeID = 0;
        }
        else
        {
            newPayment.PaymentTypeID = 9;
            newPayment.TranCode = "Credit";

        }  // this is outside credit

        newPayment.PaymentTypeName = "cc";   // "Enter Acct #"
        newPayment.RefNo = currentTable.ExperienceNumber.ToString;
        newPayment.AccountNumber = "Manual";
        newPayment.ExpDate = "MMYY";
        // NULL says kayed   newPayment.Track2 = ""
        newPayment.Name = currentTable.TabName;

        CreateNewPaymentEntry(ref newPayment, false);
        ShowRemainingBalance();

        NumberPadLarge1.DecimalUsed = false;
        if (companyInfo.usingOutsideCreditProcessor == false)
        {
            NumberPadLarge1.NumberString = "Enter Acct Number ";
        }

        NumberPadLarge1.ShowNumberString();
        NumberPadLarge1.NumberString = "";
        paymentPanel[paymentRowIndex].CurrentState = DataSet_Builder.Payment_UC.PanelHit.AccountPanel;

    }

    private object DetermineCashToCredit()
    {
        decimal creditCashAmount;

        creditCashAmount = RemainingBalance;

        foreach (DataRowView vRow in dvUnAppliedPaymentsAndCredits)
            creditCashAmount -= vRow("PaymentAmount");

        return creditCashAmount;

    }

    private object DetermineAutomaticCreditCharge()
    {
        decimal creditChargeAmount;
        DataRowView vRow;
        var numberOfCreditCardsUsed = default(int);
        decimal DollarAmountToChargeCreditCards;

        DollarAmountToChargeCreditCards = RemainingBalance;

        foreach (DataRowView currentVRow in dvUnAppliedPaymentsAndCredits_MWE)
        {
            vRow = currentVRow;
            if (vRow("PaymentFlag") == "Cash")
            {
                DollarAmountToChargeCreditCards -= vRow("PaymentAmount");
            }
            else if (vRow("PaymentFlag") == "Issue")
            {
                DollarAmountToChargeCreditCards -= vRow("PaymentAmount");
            }
            else
            {
                numberOfCreditCardsUsed += 1;
            }
        }

        foreach (DataRowView currentVRow1 in dvUnAppliedPaymentsAndCredits)
        {
            vRow = currentVRow1;
            if (vRow("PaymentFlag") == "Cash")
            {
                DollarAmountToChargeCreditCards -= vRow("PaymentAmount");
            }
            else if (vRow("PaymentFlag") == "Issue")
            {
                DollarAmountToChargeCreditCards -= vRow("PaymentAmount");
            }
            else
            {
                numberOfCreditCardsUsed += 1;
            }
        }

        if (!(dvUnAppliedPaymentsAndCredits_MWE.Count > 0))
        {
            // this adds the new one, for MWE row already added in MWE routine
            numberOfCreditCardsUsed += 1;
        }

        creditChargeAmount = Conversions.ToDecimal(Strings.Format(DollarAmountToChargeCreditCards / numberOfCreditCardsUsed, "####0.00"));
        roundingError = Conversions.ToDecimal(Strings.Format(DollarAmountToChargeCreditCards - creditChargeAmount * numberOfCreditCardsUsed, "####0.00"));

        return creditChargeAmount;

    }

    private void ApplyAutomaticCreditCharge(decimal newChargeAmount)
    {

        foreach (DataRowView vrow in dvUnAppliedPaymentsAndCredits)
        {
            if (vrow("PaymentFlag") == "cc")
            {
                if (roundingError == 0m)
                {
                    vrow("PaymentAmount") = newChargeAmount;
                }
                else
                {
                    vrow("PaymentAmount") = newChargeAmount + roundingError;
                    roundingError = 0m;
                }
                if (currentTable.AutoGratuity > 0)
                {
                    decimal adjTip = Conversions.ToDecimal(Strings.Format(newChargeAmount * companyInfo.autoGratuityPercent, "##,###.00"));
                    vrow("Tip") = adjTip;
                }
            }
        }

    }
    private void ApplyAutomaticCreditCharge_MWE(decimal newChargeAmount)
    {

        foreach (DataRowView vrow in dvUnAppliedPaymentsAndCredits_MWE)
        {
            if (vrow("PaymentFlag") == "cc")
            {
                if (roundingError == 0m)
                {
                    vrow("PaymentAmount") = newChargeAmount;
                }
                else
                {
                    vrow("PaymentAmount") = newChargeAmount + roundingError;
                    roundingError = 0m;
                }
                if (currentTable.AutoGratuity > 0)
                {
                    decimal adjTip = Conversions.ToDecimal(Strings.Format(newChargeAmount * companyInfo.autoGratuityPercent, "##,###.00"));
                    vrow("Tip") = adjTip;
                }
            }
        }

    }

    private void RunClosingPrint()
    {

        CreateClosingDataViews(currentTable.CheckNumber, true);

        prt.closeDetail.dvClosing = dvOrder; // dvClosingCheck
        prt.closeDetail.chkSubTotal = closeCheckTotals.chkSubTotal;
        // prt.closeDetail.checkTax = closeCheckTotals.checkTax   
        prt.closeDetail.chktaxName = closeCheckTotals.taxName;
        prt.closeDetail.chktaxTotal = closeCheckTotals.taxTotal;

    }
    private void btnClosePrint_Click(object sender, EventArgs e)
    {
        ResetTimer();

        // need to update ExperienceStatusChange
        GenerateOrderTables.ChangeStatusInDataBase(7, default, 0, default, DateTime.Now, default);
        // 222     AddStatusChangeData(currentTable.ExperienceNumber, 7, Nothing, 0, Nothing)

        RunClosingPrint();

        // *** need to redo with PaymentFlag
        prt.StartPrintCheckReceipt();
        foreach (DataRowView vRow in dvUnAppliedPaymentsAndCredits)
        {
            if (!(vRow("PaymentTypeName") == "Cash"))
            {
                doNotAutoCreditCards = true;
            }
        }

        if (companyInfo.autoCloseCheck == true)
        {
            var newPayment = default(DataSet_Builder.Payment);

            newPayment.Purchase = DetermineCashToCredit();
            newPayment.Purchase = Strings.Format(newPayment.Purchase, "##,##0.00");
            newPayment.PaymentTypeID = 1;
            newPayment.PaymentTypeName = "Cash";
            CreateNewPaymentEntry(ref newPayment, true);
            DisposeObjects();
            CloseExitAndRelease?.Invoke();    // test remaining balance

            if (RemainingBalancesZero == true)
            {
                CalculateClosingTotal();
                releaseFlag = true;
                DisposeObjects();
                CloseExiting?.Invoke(false, RemainingBalancesZero);
            }
            // GenerateOrderTables.ReleaseTableOrTab()
            // CloseDisposeSelf()
            else
            {
                ShowRemainingBalance();
            }
        }

    }

    private void btnClosePrintAll_Click(object sender, EventArgs e)
    {
        ResetTimer();
        // when we print all checks
        // we change status to check down
        // this will change the color coding and now allow for hostess or server to 
        // make table avail and change table status to 1(Avail for seating)

        int i;
        var newPayment = default(DataSet_Builder.Payment);

        GenerateOrderTables.ChangeStatusInDataBase(7, default, 0, default, DateTime.Now, default);

        // the following is an attempt to print all one check
        // then do the individual's
        // but I need to make sure the subtotals are correct
        // prt.closeDetail.dvClosing = dvOrder
        // prt.closeDetail.chkSubTotal = closeCheckTotals.chkSubTotal
        // prt.closeDetail.chktaxName = closeCheckTotals.taxName
        // prt.closeDetail.chktaxTotal = closeCheckTotals.taxTotal
        // prt.StartPrintCheckReceipt()

        var loopTo = currentTable.NumberOfChecks;
        for (i = 1; i <= loopTo; i++)
        {
            currentTable.CheckNumber = i;
            CreateClosingDataViews(currentTable.CheckNumber, true);
            closeCheckTotals.CalculatePriceAndTax(currentTable.CheckNumber);
            prt.closeDetail.dvClosing = dvClosingCheck;  // dvOrder 'dvClosingCheck
            prt.closeDetail.chkSubTotal = closeCheckTotals.chkSubTotal;
            prt.closeDetail.chktaxName = closeCheckTotals.taxName;
            prt.closeDetail.chktaxTotal = closeCheckTotals.taxTotal;
            prt.StartPrintCheckReceipt();
        }

        if (companyInfo.autoCloseCheck == true)
        {

            newPayment.Purchase = DetermineCashToCredit();
            newPayment.Purchase = Strings.Format(newPayment.Purchase, "##,##0.00");
            newPayment.PaymentTypeID = 1;
            newPayment.PaymentTypeName = "Cash";
            CreateNewPaymentEntry(ref newPayment, true);

            // if we are auto closing all balances will be zero, therefore we release table
            CalculateClosingTotal();
            releaseFlag = true;
            DisposeObjects();
            CloseExiting?.Invoke(false, RemainingBalancesZero);
            // GenerateOrderTables.ReleaseTableOrTab()
            // CloseDisposeSelf()

        }


    }

    internal void PrintingFromFastCash(decimal payBalanceAmount)
    {
        CreateClosingDataViews(currentTable.CheckNumber, true);

        prt.closeDetail.dvClosing = dvOrder; // dvClosingCheck
        prt.closeDetail.chkSubTotal = closeCheckTotals.chkSubTotal;
        // prt.closeDetail.checkTax = closeCheckTotals.checkTax    
        prt.closeDetail.chktaxName = closeCheckTotals.taxName;
        prt.closeDetail.chktaxTotal = closeCheckTotals.taxTotal;

        prt.closeDetail.isCashTendered = true;
        prt.closeDetail.cashTendered = payBalanceAmount;
        prt.closeDetail.chkChangeDue = 0; // RemainingBalance

        prt.StartPrintCheckReceipt(); // (dvClosingCheck, closeCheckTotals.chkSubTotal, closeCheckTotals.checkTax)

    }

    private void UpdateCheckNumberButton()
    {
        btnCloseCheckNumber.Text = "Check   " + currentTable.CheckNumber + " of " + currentTable.NumberOfChecks; // currentTable._checkCollection.Count

    }

    private void btnCloseCheckNumber_Click(object sender, EventArgs e)
    {
        ResetTimer();

        GenerateOrderTables.GotoNextCheckNumber();
        ReinitializeCloseCheck(true);

        // need to add more to update screen
        // redo datasource
    }

    internal void ReinitializeCloseCheck(bool repopulatePayments)
    {

        pnlClosePayments.Controls.Clear();
        CreateClosingDataViews(currentTable.CheckNumber, true);
        dvOrder.RowFilter = "CheckNumber ='" + currentTable.CheckNumber + "'";
        closeCheckTotals.PopulateCloseGrid(dvOrder); // dvClosingCheck)
        // paymentRowIndex = dvClosingCheckPayments.Count
        startPaymentIndex = 1;

        // 444      repopulatePayments = True
        if (repopulatePayments == true)
        {
            GetNumberOfActivePayments(currentTable.CheckNumber);
            // DisplayAnyStoredPayments()
        }

        // could probably consolidate these two
        closeCheckTotals.CalculatePriceAndTax(currentTable.CheckNumber);
        RemainingBalance = closeCheckTotals.AttachTotalsToTotalView(currentTable.CheckNumber);
        TotalCheckBalance = closeCheckTotals.TotalCheckBalance;

        NumberPadLarge1.DecimalUsed = true;
        NumberPadLarge1.NumberTotal = 0;
        NumberPadLarge1.IntegerNumber = 0;
        NumberPadLarge1.NumberString = "";
        NumberPadLarge1.ShowNumberString();

        prt.closeDetail.isCashTendered = false;
        prt.closeDetail.cashTendered = 0;
        prt.closeDetail.chkChangeDue = 0;
        prt.closeDetail.cashAppliedPrevious = 0;



        ReturnGiftCardAddToFalse();

        UpdateCheckNumberButton();
        ShowRemainingBalance();

        doNotAutoCreditCards = false;
        creditAmountAdjusted = false;
        _remainingBalancesZero = false;
        _giftAddingAmount = false;

        // not sure about PromotionApplied and _giftAddingAmount
        // all other somewhere else

        // Dim PromotionApplied(20) As Boolean
        // Dim roundingError As Decimal
        // Dim _remainingBalancesZero As Boolean
        // Dim _checkGiftIssuingAmount As Decimal
        // above will be a positive number, when paymentAmount will be negative for issuing gift
        // Dim _lastPurchaseIssueAmount As Decimal
        // Dim numActivePaymentsByCheck As Integer
        // Dim _remainingBalance As Decimal     'on both
        // Dim _totalCheckBalance As Decimal
        // _giftAddingAmount = False

    }

    private void btnCloseRelease_Click(object sender, EventArgs e)
    {

        ClosingAndReleaseRoutine(true);

    }

    internal void ClosingAndReleaseRoutine(bool isFromRelease)
    {
        ResetTimer();

        DataRow oRow;
        var unappliedCashAmount = default(decimal);
        DataRowView vRow;
        var notAllCash = default(bool);
        var someUnApplied = default(bool);
        bool goingToSelectedCheck = false;
        // GenerateOrderTables.SaveOpenOrderData()

        // if there is only a cash payment for the whole amount
        // we apply it and therefore can release table
        // If dvUnAppliedPaymentsAndCredits.Count <= currentTable.NumberOfChecks Then  '1 Then

        if (currentTerminal.TermMethod == "Quick")
        {
            goingToSelectedCheck = true;
        }
        try
        {
            foreach (DataRow currentORow in dsOrder.Tables("PaymentsAndCredits").Rows)
            {
                oRow = currentORow;   // dvUnAppliedPaymentsAndCredits
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (oRow("Applied") == false)
                    {
                        someUnApplied = true;
                        if (oRow("PaymentFlag") == "Cash")
                        {
                            unappliedCashAmount += oRow("PaymentAmount");
                        }
                        else
                        {
                            notAllCash = true;
                            break;
                        }
                    }
                }
            }

            if (someUnApplied == true & notAllCash == false)      // means it is all cash
            {

                if ((double)(RemainingBalance - unappliedCashAmount) < 0.02d & (double)(RemainingBalance - unappliedCashAmount) > -0.02d)
                {

                    RemainingBalancesZero = true;

                    foreach (DataRow currentORow1 in dsOrder.Tables("PaymentsAndCredits").Rows)
                    {
                        oRow = currentORow1;   // dvUnAppliedPaymentsAndCredits
                        if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                        {
                            if (oRow("Applied") == false)
                            {
                                oRow("Applied") = true;
                            }
                        }
                    }

                    if (companyInfo.autoPrint == true)
                    {
                        RunClosingPrint();
                        prt.closeDetail.isCashTendered = true;
                        prt.closeDetail.cashTendered = unappliedCashAmount; // reducePaymentAmount
                        prt.closeDetail.chkChangeDue = 0; // RemainingBalance
                        prt.StartPrintCheckReceipt();
                    }
                    else
                    {
                        prt.PrintOpenCashDrawer();
                    }

                    if (currentTable.NumberOfChecks == 1)
                    {
                        releaseFlag = true;
                        currentTable.IsClosed = true;

                        DisposeObjects();
                        CloseExiting?.Invoke(goingToSelectedCheck, RemainingBalancesZero);
                        return;
                    }
                }

                else
                {
                    if (isFromRelease == false)
                    {
                        releaseFlag = false;
                        DisposeObjects();
                        CloseExiting?.Invoke(goingToSelectedCheck, RemainingBalancesZero);
                    }
                    else
                    {
                        DataSet_Builder.Information_UC info;
                        info = new DataSet_Builder.Information_UC("You must authorize your Cash Payment");
                        info.Location = new Point((this.Width - info.Width) / 2, (this.Height - info.Height) / 2);
                        this.Controls.Add(info);
                        info.BringToFront();
                    }
                    return;

                }


            }
        }

        catch (Exception ex)
        {

        }
        // End If


        if (currentTable.NumberOfChecks > 1)
        {

            int i;
            int tempCheckNumber;
            var tempRemainingBalance = default(decimal);
            int checkCount;
            int maxCN;

            if (dsOrder.Tables("OpenOrders").Rows.Count > 0)
            {
                maxCN = dsOrder.Tables("OpenOrders").Compute("Max(CheckNumber)", default);


                var loopTo = maxCN;
                for (i = 1; i <= loopTo; i++)   // currentTable.NumberOfChecks
                {
                    checkCount = DetermineCheckCount[i];
                    if (checkCount > 0)
                    {
                        closeCheckTotals.CalculatePriceAndTax(i);
                        tempRemainingBalance += closeCheckTotals.AttachTotalsToTotalView(i);
                    }
                }
                if ((double)(tempRemainingBalance - unappliedCashAmount) < 0.02d & (double)(tempRemainingBalance - unappliedCashAmount) > -0.02d)
                {
                    RemainingBalancesZero = true;
                }
            }
        }



        else if ((double)(RemainingBalance - unappliedCashAmount) < 0.02d & (double)(RemainingBalance - unappliedCashAmount) > -0.02d)
        {
            RemainingBalancesZero = true;
        }

        if (isFromRelease == false)
        {
            releaseFlag = false;
            DisposeObjects();
            CloseExiting?.Invoke(goingToSelectedCheck, RemainingBalancesZero);
            return;
        }

        // If dsOrder.Tables("PaymentsAndCredits").Rows.Count And dsOrder.Tables("OpenOrders").Rows.Count = 0 Then
        // 'this is if we have not ordered anything yet and no payments
        // can turn on later, for now letting them release table
        // releaseFlag = False
        // RaiseEvent CloseExiting(False)
        // Exit Sub
        // End If
        // RemainingBalancesZero = TestRemainingBalances()
        // below this line is only for Release

        if (RemainingBalancesZero == false)
        {

            DataSet_Builder.Information_UC info;
            info = new DataSet_Builder.Information_UC("There is still a balance remaining for at least one check or you have not authorized a card payment.");
            info.Location = new Point((this.Width - info.Width) / 2, (this.Height - info.Height) / 2);
            this.Controls.Add(info);
            info.BringToFront();
            return;

            // not using below right now
            if (Interaction.MsgBox("There is still a balance remaining. Are you sure you would like to close the table?", MsgBoxStyle.YesNo) == MsgBoxResult.No)
            {
                return;
            }
        }

        if (dvUnAppliedPaymentsAndCredits.Count > 0)
        {
            // we are removing any unused payment when releasin
            CheckForUnappliedCredit(true);
        }

        CalculateClosingTotal();
        releaseFlag = true;
        // did not work for quick ticket update   
        currentTable.IsClosed = true;
        DisposeObjects();
        CloseExiting?.Invoke(goingToSelectedCheck, RemainingBalancesZero);

    }

    // Exit Function

    internal void CheckForUnappliedCredit(bool removeCash)
    {
        var isUnappliedCredit = default(bool);
        var unappliedCashAmount = default(decimal);
        // Dim cashIndex As Integer
        // Dim cashArray As New ArrayList  'Integer  'will only have one 
        // Dim isCashPayment As Boolean
        int i = 0;
        var deleteIndex = default(int);

        // cashIndex = -1      'currently we can only flag one check for cash

        // *** still have a problem, for some reason sometimes the system removes a deleted row
        // other times it keeps it in the dataset
        // **** also don't think we use the first loop
        foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)    // dvUnAppliedPaymentsAndCredits
        {
            if (!(dsOrder.Tables("PaymentsAndCredits").Rows(deleteIndex).RowState == DataRowState.Deleted) & !(dsOrder.Tables("PaymentsAndCredits").Rows(deleteIndex).RowState == DataRowState.Detached))
            {
                // not sure why we are using above instad of below
                // If Not oRow.RowState = DataRowState.Deleted And Not oRow.RowState = DataRowState.Detached Then
                if (oRow("Applied") == false)
                {
                    if (oRow("PaymentFlag") == "Cash")
                    {
                        // cashArray.Add(i) ' = i
                        unappliedCashAmount += oRow("PaymentAmount");
                    }
                    else // If oRow("PaymentFlag") = "cc" Then 
                    {
                        isUnappliedCredit = true;
                    }
                }
                // i += 1
                deleteIndex += 1;
            }
        }

        i = 0;
        deleteIndex = 0;

        if (isUnappliedCredit == true)
        {
            // If MsgBox("FOR SECURITY - All unauthorized Credit Card information will be lost. Continue to Exit?", MsgBoxStyle.OKCancel) = MsgBoxResult.Cancel Then
            // Return True  'true means "DO NOT EXIT"
            // Else
            // this removes all unapplied credit card information 
            var loopTo = dsOrder.Tables("PaymentsAndCredits").Rows.Count - 1;
            for (i = 0; i <= loopTo; i++)
            {
                if (!(dsOrder.Tables("PaymentsAndCredits").Rows(deleteIndex).RowState == DataRowState.Deleted) & !(dsOrder.Tables("PaymentsAndCredits").Rows(deleteIndex).RowState == DataRowState.Detached))
                {
                    if (dsOrder.Tables("PaymentsAndCredits").Rows(deleteIndex)("Applied") == false)
                    {
                        if (!(dsOrder.Tables("PaymentsAndCredits").Rows(deleteIndex)("PaymentFlag") == "Cash"))
                        {
                            dsOrder.Tables("PaymentsAndCredits").Rows(deleteIndex).Delete();
                        }
                        else if (removeCash == true)                             // below is a cash row
                        {
                            dsOrder.Tables("PaymentsAndCredits").Rows(deleteIndex).Delete();
                        }
                        else
                        {
                            if (unappliedCashAmount == RemainingBalance)
                            {
                                dsOrder.Tables("PaymentsAndCredits").Rows(deleteIndex)("Applied") = true;
                            }
                            deleteIndex += 1;
                        }
                    }
                    else
                    {
                        deleteIndex += 1;
                    }
                }
            }
        }
        // End If

    }

    internal void ShowRemainingBalance()
    {
        decimal unauthorizedRemainingBalance;
        DataRowView vrow;

        unauthorizedRemainingBalance = RemainingBalance;

        foreach (DataRowView currentVrow in dvUnAppliedPaymentsAndCredits_MWE)
        {
            vrow = currentVrow;
            unauthorizedRemainingBalance -= vrow("PaymentAmount");
        }
        foreach (DataRowView currentVrow1 in dvUnAppliedPaymentsAndCredits)
        {
            vrow = currentVrow1;
            unauthorizedRemainingBalance -= vrow("PaymentAmount");
        }
        lblBalanceDetail.Text = Strings.Format(unauthorizedRemainingBalance, "####0.00");

    }

    private void btnCloseComp_Click(object sender, EventArgs e)
    {
        ResetTimer();
        Interaction.MsgBox("Service Not Available");
    }

    private void btnCloseAutoTip_Click(object sender, EventArgs e)
    {
        ResetTimer();

        if (closeCheckTotals.AutoGratuity == false)
        {
            closeCheckTotals.AutoGratuity = true;
            ChangeAutoGratInExperience(companyInfo.autoGratuityPercent);
        }
        else
        {
            closeCheckTotals.AutoGratuity = false;
            ChangeAutoGratInExperience(-1);
        }

        closeCheckTotals.CalculatePriceAndTax(currentTable.CheckNumber);
        RemainingBalance = closeCheckTotals.AttachTotalsToTotalView(currentTable.CheckNumber);
        ShowRemainingBalance();

    }

    private void ChangeAutoGratInExperience(decimal autoGrat)
    {
        DataRowView vrow;

        if (currentTerminal.TermMethod == "Quick" | currentTable.TicketNumber > 0)
        {
            foreach (DataRow oRow in dsOrder.Tables("QuickTickets").Rows)
            {
                if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                {
                    oRow("AutoGratuity") = autoGrat;
                }
            }
        }
        else if (currentTable.IsTabNotTable == true)
        {
            foreach (DataRowView currentVrow in dvAvailTabs)
            {
                vrow = currentVrow;    // dsOrder.Tables("AvailTabs").Rows
                if (vrow("ExperienceNumber") == currentTable.ExperienceNumber)
                {
                    vrow("AutoGratuity") = autoGrat;
                }
            }
        }
        else
        {
            foreach (DataRowView currentVrow1 in dvAvailTables)
            {
                vrow = currentVrow1;  // dsOrder.Tables("AvailTables").Rows
                if (vrow("ExperienceNumber") == currentTable.ExperienceNumber)
                {
                    vrow("AutoGratuity") = autoGrat;
                }
            }
        }

    }

    private void btnCloseGiftCardAdd_Click(object sender, EventArgs e)
    {
        ResetTimer();
        DataRowView vRow;
        var UnAuthPanel = default(bool);
        var UnAuthIndex = default(int);

        if (paymentRowIndex > dvClosingCheckPayments.Count)
        {
            // we will use:   dvUnAppliedPaymentsAndCredits_MWE 
            UnAuthPanel = true;
            UnAuthIndex = paymentRowIndex - dvClosingCheckPayments.Count - 1;
        }

        if (GiftAddingAmount == false)
        {
            GiftAddingAmount = true;
            btnCloseGiftCardAdd.BackColor = Color.RoyalBlue;
            MakeGiftAddingAmountTrue?.Invoke();

            if (paymentRowIndex > 0)
            {
                if (UnAuthPanel == true)
                {
                    vRow = dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex];
                }
                else
                {
                    vRow = dvClosingCheckPayments[paymentRowIndex - 1];
                } // 444dvUnAppliedPaymentsAndCredits(paymentRowIndex - 1)

                if (vRow is not null)
                {
                    if (vRow("PaymentFlag") == "Gift" & object.ReferenceEquals(vRow("AuthCode"), DBNull.Value))
                    {
                        // for return - which is adding money to gift card
                        vRow("PaymentTypeID") = -97;
                        vRow("PaymentTypeName") = "Increase Gift";
                        vRow("PaymentFlag") = "Issue";
                        // we can subtract below b/c we are resetting GiftCardAdd to False
                        _checkGiftIssuingAmount = vRow("PaymentAmount");
                        _lastPurchaseIssueAmount = _checkGiftIssuingAmount;
                        vRow("PaymentAmount") *= -1;

                        paymentPanel[paymentRowIndex].UpdatePurchase(vRow("PaymentAmount"));
                        paymentPanel[paymentRowIndex].UpdatePayType(vRow("PaymentTypeName"));
                        ReturnGiftCardAddToFalse();
                    }
                }
            }
        }

        else
        {
            ReturnGiftCardAddToFalse();
        }

    }

    internal void ReturnGiftCardAddToFalse() // Handles readAuth.RetruningGiftAddingAmountToFalse
    {
        GiftAddingAmount = false;
        btnCloseGiftCardAdd.BackColor = Color.LightSlateGray;
    }


    private void btnDup_Click(object sender, EventArgs e)
    {
        if (!(paymentRowIndex > 0))
            return;
        if (paymentPanel[paymentRowIndex].AuthCode != default)
            return;
        var UnAuthPanel = default(bool);
        var UnAuthIndex = default(int);

        if (paymentRowIndex > dvClosingCheckPayments.Count)
        {
            // we will use:   dvUnAppliedPaymentsAndCredits_MWE 
            UnAuthPanel = true;
            UnAuthIndex = paymentRowIndex - dvClosingCheckPayments.Count - 1;
        }

        if (paymentPanel[paymentRowIndex].DupAuth == false)
        {
            paymentPanel[paymentRowIndex].DupAuth = true;
            if (UnAuthPanel == true)
            {
                dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex]("Duplicate") = 1;
            }
            else
            {
                dvClosingCheckPayments[paymentRowIndex - 1]("Duplicate") = 1;
            }
        }

        else
        {
            paymentPanel[paymentRowIndex].DupAuth = false;
            if (UnAuthPanel == true)
            {
                dvUnAppliedPaymentsAndCredits_MWE[UnAuthIndex]("Duplicate") = 0;
            }
            else
            {
                dvClosingCheckPayments[paymentRowIndex - 1]("Duplicate") = 0;
            }

        }

        paymentPanel[paymentRowIndex].UpdateLabelDup();

    }

    private void btnVoiceAuth_Click(object sender, EventArgs e)
    {
        if (!(paymentRowIndex > 0))
            return;

        // AMEX change

        // *** below will allow you to change voice auths
        // we want no auth code or an auth code w/ no acqRefData 
        if (paymentPanel[paymentRowIndex].AuthCode != default)
        {
            // If Not paymentPanel(paymentRowIndex).AcqRefData = Nothing Then
            if (paymentPanel[paymentRowIndex].AuthCode.Length > 0)
            {
                return;     // we have AcqRefData
            }
        }
        else
        {
            return;
            // End If
        }    // we have AcqRefData

        if (paymentPanel[paymentRowIndex].AcctNumber == default)
        {
            Interaction.MsgBox("You must enter an Account Number.");
            return;
        }

        if (paymentPanel[paymentRowIndex].ExpDate == default)
        {
            Interaction.MsgBox("You must enter an Experation Date.");
            return;
        }

        NumberPadLarge1.DecimalUsed = false;
        NumberPadLarge1.NumberString = "Enter Voice Auth  ";
        NumberPadLarge1.ShowNumberString();
        NumberPadLarge1.NumberString = "";
        paymentPanel[paymentRowIndex].CurrentState = DataSet_Builder.Payment_UC.PanelHit.VoiceAuth;


    }

    private void DisposeObjects()
    {

        closeCheckTotals.grdCloseCheck.DataSource = (object)null;
        if (ccDisplay is not null)
        {
            ccDisplay.Dispose();
            ccDisplay = (object)null;
        }

    }

    private void btnDemoCC_Click(object sender, EventArgs e)
    {
        var newPayment = default(Payment);

        newPayment.experienceNumber = currentTable.ExperienceNumber;
        newPayment.Name = "Test Credit";
        newPayment.FirstName = "Test";
        newPayment.LastName = "Credit";
        newPayment.Track2 = "37130000000000";
        newPayment.AccountNumber = "371301234567890" + demoCcNumberAddon.ToString;
        newPayment.PaymentTypeID = 2;
        newPayment.PaymentTypeName = "AMEX";
        newPayment.ExpDate = "0809";
        newPayment.Swiped = true;
        demoCcNumberAddon += 1;

        // ********************************
        // this is ok because this is not card read, this is for DEMO
        // 444       GenerateOrderTables.CreateTabAcctPlaceInExperience(newPayment)
        // 444      AddPaymentToCollection(newPayment)
        ProcessCreditRead(ref newPayment);

    }





}