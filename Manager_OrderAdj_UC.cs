using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using DataSet_Builder;

public partial class Manager_OrderAdj_UC : System.Windows.Forms.UserControl
{

    // Private sql As New DataSet_Builder.SQLHelper(connectserver)
    private PrintHelper prt = new PrintHelper();

    private CheckTotal_UC _checkTotalsMgmtAdj;

    private CheckTotal_UC checkTotalsMgmtAdj
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _checkTotalsMgmtAdj;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _checkTotalsMgmtAdj = value;
        }
    }
    private ForcePrice_UC _forcePriceMgmtAdj;

    private ForcePrice_UC forcePriceMgmtAdj
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _forcePriceMgmtAdj;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_forcePriceMgmtAdj != null)
            {
                _forcePriceMgmtAdj.UpdateAdjGrid -= ApplyForcePrice;
                _forcePriceMgmtAdj.DisposeForcePrice -= DisposingForcePrice;
            }

            _forcePriceMgmtAdj = value;
            if (_forcePriceMgmtAdj != null)
            {
                _forcePriceMgmtAdj.UpdateAdjGrid += ApplyForcePrice;
                _forcePriceMgmtAdj.DisposeForcePrice += DisposingForcePrice;
            }
        }
    }
    private CheckAdjustmentOverride_UC _checkAdjMgmtAdj;

    private CheckAdjustmentOverride_UC checkAdjMgmtAdj
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _checkAdjMgmtAdj;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_checkAdjMgmtAdj != null)
            {
                _checkAdjMgmtAdj.UpdateAdjGridPayment -= UpdatePaymentListView;
            }

            _checkAdjMgmtAdj = value;
            if (_checkAdjMgmtAdj != null)
            {
                _checkAdjMgmtAdj.UpdateAdjGridPayment += UpdatePaymentListView;
            }
        }
    }
    private Comp_Ticket_UC _compTktMgmtAdj;

    private Comp_Ticket_UC compTktMgmtAdj
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _compTktMgmtAdj;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_compTktMgmtAdj != null)
            {
                _compTktMgmtAdj.DisposeCompTicket -= DisposingCompTicket;
                _compTktMgmtAdj.AcceptCompTicket -= AcceptingCompTicket;
            }

            _compTktMgmtAdj = value;
            if (_compTktMgmtAdj != null)
            {
                _compTktMgmtAdj.DisposeCompTicket += DisposingCompTicket;
                _compTktMgmtAdj.AcceptCompTicket += AcceptingCompTicket;
            }
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
                _cashOut.CancelCashOut -= CashOutCanceled;
                _cashOut.AcceptCashOut -= CashOutAccepted;
            }

            _cashOut = value;
            if (_cashOut != null)
            {
                _cashOut.CancelCashOut += CashOutCanceled;
                _cashOut.AcceptCashOut += CashOutAccepted;
            }
        }
    }

    private Collection voidedItems;

    // Friend AdjustCurrencyMan As CurrencyManager

    private int forceRowNum;
    private bool isForReopen;
    private bool madeChanges;

    private int _transSIN;
    private string _transName;

    internal int TransSIN
    {
        get
        {
            return _transSIN;
        }
        set
        {
            _transSIN = value;
        }
    }

    internal string TransName
    {
        get
        {
            return _transName;
        }
        set
        {
            _transName = value;
        }
    }


    public event SaveReopenedCheckEventHandler SaveReopenedCheck;

    public delegate void SaveReopenedCheckEventHandler();
    public event PlacingOrderEventHandler PlacingOrder;

    public delegate void PlacingOrderEventHandler();
    public event TransferingCheckEventHandler TransferingCheck;

    public delegate void TransferingCheckEventHandler();
    public event MgrClosingCheckEventHandler MgrClosingCheck;

    public delegate void MgrClosingCheckEventHandler();
    public event AddingItemToOrderEventHandler AddingItemToOrder;

    public delegate void AddingItemToOrderEventHandler(object sender);
    public event ReinitializeMainEventHandler ReinitializeMain;

    public delegate void ReinitializeMainEventHandler(bool saveChanges, bool disposeOrdAdj);
    public event VoidedCheckTableStatusChangeEventHandler VoidedCheckTableStatusChange;

    public delegate void VoidedCheckTableStatusChangeEventHandler(int tn);

    // *** not sure if this should be here
    // it is also in CheckAdjustmentOverride_UC
    // but I was getting can't find error sopmetimes
    public event UpdateAdjGridPaymentEventHandler UpdateAdjGridPayment;

    public delegate void UpdateAdjGridPaymentEventHandler();

    #region  Windows Form Designer generated code 

    public Manager_OrderAdj_UC(bool isReopen, long expNum) : base() // ByVal cm As Integer, ByVal empID As Integer, ByVal IsTab As Boolean, ByVal expNum As Int64, ByVal numChecks As Integer, ByVal numCust As Integer)
    {

        // *** neeed to redo last staus for all management screens
        // *** just like at the beggining of Table_Screen_Bar

        // currentTable = New DinnerTable

        // currentTable.CurrentMenu = cm
        // currentTable.StartingMenu = cm
        // currentTable.EmployeeID = empID
        // If IsTab = True Then
        // currentTable.TabID = tn
        // Else
        // '        currentTable.TableNumber = tn
        // End If
        // currentTable.IsTabNotTable = IsTab
        // currentTable.ExperienceNumber = expNum
        // '   currentTable.NumberOfChecks = numChecks
        // currentTable.NumberOfCustomers = numCust

        // currentTable.CheckNumber = 1            'this to start
        isForReopen = isReopen;

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        InitializeOther(expNum);

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
    private IContainer components;

    // NOTE: The following procedure is required by the Windows Form Designer
    // It can be modified using the Windows Form Designer.  
    // Do not modify it using the code editor.
    private Global.System.Windows.Forms.Button _btnMgrCheckNumber;

    internal virtual Global.System.Windows.Forms.Button btnMgrCheckNumber
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMgrCheckNumber;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMgrCheckNumber != null)
            {
                _btnMgrCheckNumber.Click -= btnMgrCheckNumber_Click;
            }

            _btnMgrCheckNumber = value;
            if (_btnMgrCheckNumber != null)
            {
                _btnMgrCheckNumber.Click += btnMgrCheckNumber_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _pnlMgrCheckInfo;

    internal virtual Global.System.Windows.Forms.Panel pnlMgrCheckInfo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlMgrCheckInfo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlMgrCheckInfo = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlMgrByItem;

    internal virtual Global.System.Windows.Forms.Panel pnlMgrByItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlMgrByItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlMgrByItem = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlMgrByCheck;

    internal virtual Global.System.Windows.Forms.Panel pnlMgrByCheck
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlMgrByCheck;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlMgrByCheck = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblMgrByItem;

    internal virtual Global.System.Windows.Forms.Label lblMgrByItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblMgrByItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblMgrByItem != null)
            {
                _lblMgrByItem.Click -= lblMgrByItem_Click;
            }

            _lblMgrByItem = value;
            if (_lblMgrByItem != null)
            {
                _lblMgrByItem.Click += lblMgrByItem_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblMgrByCheck;

    internal virtual Global.System.Windows.Forms.Label lblMgrByCheck
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblMgrByCheck;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblMgrByCheck != null)
            {
                _lblMgrByCheck.Click -= lblMgrByCheck_Click;
            }

            _lblMgrByCheck = value;
            if (_lblMgrByCheck != null)
            {
                _lblMgrByCheck.Click += lblMgrByCheck_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _pnlMgrByPayments;

    internal virtual Global.System.Windows.Forms.Panel pnlMgrByPayments
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlMgrByPayments;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlMgrByPayments = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblMgrByPayments;

    internal virtual Global.System.Windows.Forms.Label lblMgrByPayments
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblMgrByPayments;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblMgrByPayments != null)
            {
                _lblMgrByPayments.Click -= lblMgrByPayments_Click;
            }

            _lblMgrByPayments = value;
            if (_lblMgrByPayments != null)
            {
                _lblMgrByPayments.Click += lblMgrByPayments_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnMgrVoidItem;

    internal virtual Global.System.Windows.Forms.Button btnMgrVoidItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMgrVoidItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMgrVoidItem != null)
            {
                _btnMgrVoidItem.Click -= btnMgrVoidItem_Click;
            }

            _btnMgrVoidItem = value;
            if (_btnMgrVoidItem != null)
            {
                _btnMgrVoidItem.Click += btnMgrVoidItem_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnMgrForcePrice;

    internal virtual Global.System.Windows.Forms.Button btnMgrForcePrice
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMgrForcePrice;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMgrForcePrice != null)
            {
                _btnMgrForcePrice.Click -= btnMgrForcePrice_Click;
            }

            _btnMgrForcePrice = value;
            if (_btnMgrForcePrice != null)
            {
                _btnMgrForcePrice.Click += btnMgrForcePrice_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnMgrCompItem;

    internal virtual Global.System.Windows.Forms.Button btnMgrCompItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMgrCompItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMgrCompItem != null)
            {
                _btnMgrCompItem.Click -= btnMgrCompItem_Click;
            }

            _btnMgrCompItem = value;
            if (_btnMgrCompItem != null)
            {
                _btnMgrCompItem.Click += btnMgrCompItem_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnMgrReprintCheck;

    internal virtual Global.System.Windows.Forms.Button btnMgrReprintCheck
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMgrReprintCheck;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMgrReprintCheck != null)
            {
                _btnMgrReprintCheck.Click -= btnMgrReprintCheck_Click;
            }

            _btnMgrReprintCheck = value;
            if (_btnMgrReprintCheck != null)
            {
                _btnMgrReprintCheck.Click += btnMgrReprintCheck_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnMgrReprintOrder;

    internal virtual Global.System.Windows.Forms.Button btnMgrReprintOrder
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMgrReprintOrder;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMgrReprintOrder != null)
            {
                _btnMgrReprintOrder.Click -= btnMgrReprintOrder_Click;
            }

            _btnMgrReprintOrder = value;
            if (_btnMgrReprintOrder != null)
            {
                _btnMgrReprintOrder.Click += btnMgrReprintOrder_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnMgrVoidCheck;

    internal virtual Global.System.Windows.Forms.Button btnMgrVoidCheck
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMgrVoidCheck;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMgrVoidCheck != null)
            {
                _btnMgrVoidCheck.Click -= btnMgrVoidCheck_Click;
            }

            _btnMgrVoidCheck = value;
            if (_btnMgrVoidCheck != null)
            {
                _btnMgrVoidCheck.Click += btnMgrVoidCheck_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnMgrReopenCheck;

    internal virtual Global.System.Windows.Forms.Button btnMgrReopenCheck
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMgrReopenCheck;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMgrReopenCheck != null)
            {
                _btnMgrReopenCheck.Click -= btnMgrReopenCheck_Click;
            }

            _btnMgrReopenCheck = value;
            if (_btnMgrReopenCheck != null)
            {
                _btnMgrReopenCheck.Click += btnMgrReopenCheck_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnAdjustPay;

    internal virtual Global.System.Windows.Forms.Button btnAdjustPay
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnAdjustPay;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnAdjustPay != null)
            {
                _btnAdjustPay.Click -= btnAdjustPay_Click;
            }

            _btnAdjustPay = value;
            if (_btnAdjustPay != null)
            {
                _btnAdjustPay.Click += btnAdjustPay_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnMgrAssignComps;

    internal virtual Global.System.Windows.Forms.Button btnMgrAssignComps
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMgrAssignComps;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMgrAssignComps != null)
            {
                _btnMgrAssignComps.Click -= btnMgrAssignComps_Click;
            }

            _btnMgrAssignComps = value;
            if (_btnMgrAssignComps != null)
            {
                _btnMgrAssignComps.Click += btnMgrAssignComps_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnMgrAssignGratuity;

    internal virtual Global.System.Windows.Forms.Button btnMgrAssignGratuity
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMgrAssignGratuity;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMgrAssignGratuity != null)
            {
                _btnMgrAssignGratuity.Click -= btnMgrAssignGratuity_Click;
            }

            _btnMgrAssignGratuity = value;
            if (_btnMgrAssignGratuity != null)
            {
                _btnMgrAssignGratuity.Click += btnMgrAssignGratuity_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnManagerCancel;

    internal virtual Global.System.Windows.Forms.Button btnManagerCancel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnManagerCancel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnManagerCancel != null)
            {
                _btnManagerCancel.Click -= ButtonManagerCancel_Click;
            }

            _btnManagerCancel = value;
            if (_btnManagerCancel != null)
            {
                _btnManagerCancel.Click += ButtonManagerCancel_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnAdjAccept;

    internal virtual Global.System.Windows.Forms.Button btnAdjAccept
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnAdjAccept;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnAdjAccept != null)
            {
                _btnAdjAccept.Click -= btnAdjAccept_Click;
            }

            _btnAdjAccept = value;
            if (_btnAdjAccept != null)
            {
                _btnAdjAccept.Click += btnAdjAccept_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _pnlMgrCalculationArea;

    internal virtual Global.System.Windows.Forms.Panel pnlMgrCalculationArea
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlMgrCalculationArea;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlMgrCalculationArea = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnMgrTransfer;

    internal virtual Global.System.Windows.Forms.Button btnMgrTransfer
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMgrTransfer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMgrTransfer != null)
            {
                _btnMgrTransfer.Click -= btnMgrTransfer_Click;
            }

            _btnMgrTransfer = value;
            if (_btnMgrTransfer != null)
            {
                _btnMgrTransfer.Click += btnMgrTransfer_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnMgrPlaceOrder;

    internal virtual Global.System.Windows.Forms.Button btnMgrPlaceOrder
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMgrPlaceOrder;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMgrPlaceOrder != null)
            {
                _btnMgrPlaceOrder.Click -= btnMgrPlaceOrder_Click;
            }

            _btnMgrPlaceOrder = value;
            if (_btnMgrPlaceOrder != null)
            {
                _btnMgrPlaceOrder.Click += btnMgrPlaceOrder_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnMgrReprintCredit;

    internal virtual Global.System.Windows.Forms.Button btnMgrReprintCredit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMgrReprintCredit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMgrReprintCredit != null)
            {
                _btnMgrReprintCredit.Click -= btnMgrReprintCredit_Click;
            }

            _btnMgrReprintCredit = value;
            if (_btnMgrReprintCredit != null)
            {
                _btnMgrReprintCredit.Click += btnMgrReprintCredit_Click;
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
    private Global.System.Windows.Forms.Label _lblMgrPrinting;

    internal virtual Global.System.Windows.Forms.Label lblMgrPrinting
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblMgrPrinting;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblMgrPrinting = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlCheckTotalFor_UC;

    internal virtual Global.System.Windows.Forms.Panel pnlCheckTotalFor_UC
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlCheckTotalFor_UC;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlCheckTotalFor_UC = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnMgrCashBack;

    internal virtual Global.System.Windows.Forms.Button btnMgrCashBack
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMgrCashBack;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMgrCashBack != null)
            {
                _btnMgrCashBack.Click -= btnCashBack_Click;
            }

            _btnMgrCashBack = value;
            if (_btnMgrCashBack != null)
            {
                _btnMgrCashBack.Click += btnCashBack_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnMgrTaxExempt;

    internal virtual Global.System.Windows.Forms.Button btnMgrTaxExempt
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMgrTaxExempt;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMgrTaxExempt != null)
            {
                _btnMgrTaxExempt.Click -= btnMgrTaxExempt_Click;
            }

            _btnMgrTaxExempt = value;
            if (_btnMgrTaxExempt != null)
            {
                _btnMgrTaxExempt.Click += btnMgrTaxExempt_Click;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        var resources = new ComponentResourceManager(typeof(Manager_OrderAdj_UC));
        _btnManagerCancel = new System.Windows.Forms.Button();
        _btnManagerCancel.Click += ButtonManagerCancel_Click;
        _btnMgrCheckNumber = new System.Windows.Forms.Button();
        _btnMgrCheckNumber.Click += btnMgrCheckNumber_Click;
        _pnlMgrCheckInfo = new System.Windows.Forms.Panel();
        _btnAdjAccept = new System.Windows.Forms.Button();
        _btnAdjAccept.Click += btnAdjAccept_Click;
        _pnlMgrByItem = new System.Windows.Forms.Panel();
        _btnMgrCompItem = new System.Windows.Forms.Button();
        _btnMgrCompItem.Click += btnMgrCompItem_Click;
        _btnMgrForcePrice = new System.Windows.Forms.Button();
        _btnMgrForcePrice.Click += btnMgrForcePrice_Click;
        _btnMgrVoidItem = new System.Windows.Forms.Button();
        _btnMgrVoidItem.Click += btnMgrVoidItem_Click;
        _lblMgrByItem = new System.Windows.Forms.Label();
        _lblMgrByItem.Click += lblMgrByItem_Click;
        _btnMgrPlaceOrder = new System.Windows.Forms.Button();
        _btnMgrPlaceOrder.Click += btnMgrPlaceOrder_Click;
        _pnlMgrByCheck = new System.Windows.Forms.Panel();
        _btnMgrTaxExempt = new System.Windows.Forms.Button();
        _btnMgrTaxExempt.Click += btnMgrTaxExempt_Click;
        _btnMgrReopenCheck = new System.Windows.Forms.Button();
        _btnMgrReopenCheck.Click += btnMgrReopenCheck_Click;
        _btnMgrVoidCheck = new System.Windows.Forms.Button();
        _btnMgrVoidCheck.Click += btnMgrVoidCheck_Click;
        _lblMgrByCheck = new System.Windows.Forms.Label();
        _lblMgrByCheck.Click += lblMgrByCheck_Click;
        _btnMgrTransfer = new System.Windows.Forms.Button();
        _btnMgrTransfer.Click += btnMgrTransfer_Click;
        _btnMgrReprintOrder = new System.Windows.Forms.Button();
        _btnMgrReprintOrder.Click += btnMgrReprintOrder_Click;
        _btnMgrReprintCheck = new System.Windows.Forms.Button();
        _btnMgrReprintCheck.Click += btnMgrReprintCheck_Click;
        _pnlMgrByPayments = new System.Windows.Forms.Panel();
        _btnMgrCashBack = new System.Windows.Forms.Button();
        _btnMgrCashBack.Click += btnCashBack_Click;
        _btnMgrAssignGratuity = new System.Windows.Forms.Button();
        _btnMgrAssignGratuity.Click += btnMgrAssignGratuity_Click;
        _btnMgrAssignComps = new System.Windows.Forms.Button();
        _btnMgrAssignComps.Click += btnMgrAssignComps_Click;
        _btnAdjustPay = new System.Windows.Forms.Button();
        _btnAdjustPay.Click += btnAdjustPay_Click;
        _lblMgrByPayments = new System.Windows.Forms.Label();
        _lblMgrByPayments.Click += lblMgrByPayments_Click;
        _btnMgrReprintCredit = new System.Windows.Forms.Button();
        _btnMgrReprintCredit.Click += btnMgrReprintCredit_Click;
        _pnlMgrCalculationArea = new System.Windows.Forms.Panel();
        _Panel1 = new System.Windows.Forms.Panel();
        _Panel2 = new System.Windows.Forms.Panel();
        _lblMgrPrinting = new System.Windows.Forms.Label();
        _pnlCheckTotalFor_UC = new System.Windows.Forms.Panel();
        _pnlMgrCheckInfo.SuspendLayout();
        _pnlMgrByItem.SuspendLayout();
        _pnlMgrByCheck.SuspendLayout();
        _pnlMgrByPayments.SuspendLayout();
        _Panel1.SuspendLayout();
        _Panel2.SuspendLayout();
        this.SuspendLayout();
        // 
        // btnManagerCancel
        // 
        _btnManagerCancel.BackColor = System.Drawing.Color.LightSlateGray;
        _btnManagerCancel.Font = new System.Drawing.Font("Comic Sans MS", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnManagerCancel.Location = new System.Drawing.Point(216, 8);
        _btnManagerCancel.Name = "_btnManagerCancel";
        _btnManagerCancel.Size = new System.Drawing.Size(88, 32);
        _btnManagerCancel.TabIndex = 5;
        _btnManagerCancel.Text = "Cancel";
        _btnManagerCancel.UseVisualStyleBackColor = false;
        // 
        // btnMgrCheckNumber
        // 
        _btnMgrCheckNumber.BackColor = System.Drawing.Color.FromArgb(249, 200, 7);
        _btnMgrCheckNumber.Location = new System.Drawing.Point(104, 0);
        _btnMgrCheckNumber.Name = "_btnMgrCheckNumber";
        _btnMgrCheckNumber.Size = new System.Drawing.Size(104, 48);
        _btnMgrCheckNumber.TabIndex = 6;
        _btnMgrCheckNumber.UseVisualStyleBackColor = false;
        // 
        // pnlMgrCheckInfo
        // 
        _pnlMgrCheckInfo.BackColor = System.Drawing.Color.LightSlateGray;
        _pnlMgrCheckInfo.Controls.Add(_btnAdjAccept);
        _pnlMgrCheckInfo.Controls.Add(_btnMgrCheckNumber);
        _pnlMgrCheckInfo.Controls.Add(_btnManagerCancel);
        _pnlMgrCheckInfo.Location = new System.Drawing.Point(64, 8);
        _pnlMgrCheckInfo.Name = "_pnlMgrCheckInfo";
        _pnlMgrCheckInfo.Size = new System.Drawing.Size(312, 48);
        _pnlMgrCheckInfo.TabIndex = 7;
        // 
        // btnAdjAccept
        // 
        _btnAdjAccept.BackColor = System.Drawing.Color.SlateGray;
        _btnAdjAccept.Font = new System.Drawing.Font("Comic Sans MS", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnAdjAccept.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _btnAdjAccept.Location = new System.Drawing.Point(0, 0);
        _btnAdjAccept.Name = "_btnAdjAccept";
        _btnAdjAccept.Size = new System.Drawing.Size(104, 48);
        _btnAdjAccept.TabIndex = 7;
        _btnAdjAccept.Text = "Accept";
        _btnAdjAccept.UseVisualStyleBackColor = false;
        // 
        // pnlMgrByItem
        // 
        _pnlMgrByItem.BackColor = System.Drawing.Color.FromArgb(138, 181, 232);
        _pnlMgrByItem.BackgroundImage = (Global.System.Drawing.Image)resources.GetObject("pnlMgrByItem.BackgroundImage");
        _pnlMgrByItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _pnlMgrByItem.Controls.Add(_btnMgrCompItem);
        _pnlMgrByItem.Controls.Add(_btnMgrForcePrice);
        _pnlMgrByItem.Controls.Add(_btnMgrVoidItem);
        _pnlMgrByItem.Controls.Add(_lblMgrByItem);
        _pnlMgrByItem.Controls.Add(_btnMgrPlaceOrder);
        _pnlMgrByItem.Font = new System.Drawing.Font("Comic Sans MS", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _pnlMgrByItem.Location = new System.Drawing.Point(8, 8);
        _pnlMgrByItem.Name = "_pnlMgrByItem";
        _pnlMgrByItem.Size = new System.Drawing.Size(136, 280);
        _pnlMgrByItem.TabIndex = 9;
        // 
        // btnMgrCompItem
        // 
        _btnMgrCompItem.BackColor = System.Drawing.Color.Transparent;
        _btnMgrCompItem.Font = new System.Drawing.Font("Comic Sans MS", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnMgrCompItem.Location = new System.Drawing.Point(8, 168);
        _btnMgrCompItem.Name = "_btnMgrCompItem";
        _btnMgrCompItem.Size = new System.Drawing.Size(120, 48);
        _btnMgrCompItem.TabIndex = 3;
        _btnMgrCompItem.Text = "Comp Item";
        _btnMgrCompItem.UseVisualStyleBackColor = false;
        // 
        // btnMgrForcePrice
        // 
        _btnMgrForcePrice.BackColor = System.Drawing.Color.Transparent;
        _btnMgrForcePrice.Font = new System.Drawing.Font("Comic Sans MS", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnMgrForcePrice.Location = new System.Drawing.Point(8, 112);
        _btnMgrForcePrice.Name = "_btnMgrForcePrice";
        _btnMgrForcePrice.Size = new System.Drawing.Size(120, 48);
        _btnMgrForcePrice.TabIndex = 2;
        _btnMgrForcePrice.Text = "Adjust Price";
        _btnMgrForcePrice.UseVisualStyleBackColor = false;
        // 
        // btnMgrVoidItem
        // 
        _btnMgrVoidItem.BackColor = System.Drawing.Color.Transparent;
        _btnMgrVoidItem.Font = new System.Drawing.Font("Comic Sans MS", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnMgrVoidItem.ForeColor = System.Drawing.SystemColors.ControlText;
        _btnMgrVoidItem.Location = new System.Drawing.Point(8, 56);
        _btnMgrVoidItem.Name = "_btnMgrVoidItem";
        _btnMgrVoidItem.Size = new System.Drawing.Size(120, 48);
        _btnMgrVoidItem.TabIndex = 1;
        _btnMgrVoidItem.Text = "Void Item";
        _btnMgrVoidItem.UseVisualStyleBackColor = false;
        // 
        // lblMgrByItem
        // 
        _lblMgrByItem.BackColor = System.Drawing.Color.Transparent;
        _lblMgrByItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _lblMgrByItem.Dock = System.Windows.Forms.DockStyle.Top;
        _lblMgrByItem.Font = new System.Drawing.Font("Cambria", 15.75f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblMgrByItem.Location = new System.Drawing.Point(0, 0);
        _lblMgrByItem.Name = "_lblMgrByItem";
        _lblMgrByItem.Size = new System.Drawing.Size(132, 48);
        _lblMgrByItem.TabIndex = 0;
        _lblMgrByItem.Text = "By Item";
        _lblMgrByItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btnMgrPlaceOrder
        // 
        _btnMgrPlaceOrder.BackColor = System.Drawing.Color.FromArgb(59, 96, 141);
        _btnMgrPlaceOrder.Font = new System.Drawing.Font("Comic Sans MS", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnMgrPlaceOrder.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _btnMgrPlaceOrder.Location = new System.Drawing.Point(8, 224);
        _btnMgrPlaceOrder.Name = "_btnMgrPlaceOrder";
        _btnMgrPlaceOrder.Size = new System.Drawing.Size(120, 48);
        _btnMgrPlaceOrder.TabIndex = 7;
        _btnMgrPlaceOrder.Text = "Place Order";
        _btnMgrPlaceOrder.UseVisualStyleBackColor = false;
        // 
        // pnlMgrByCheck
        // 
        _pnlMgrByCheck.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
        _pnlMgrByCheck.BackgroundImage = (Global.System.Drawing.Image)resources.GetObject("pnlMgrByCheck.BackgroundImage");
        _pnlMgrByCheck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _pnlMgrByCheck.Controls.Add(_btnMgrTaxExempt);
        _pnlMgrByCheck.Controls.Add(_btnMgrReopenCheck);
        _pnlMgrByCheck.Controls.Add(_btnMgrVoidCheck);
        _pnlMgrByCheck.Controls.Add(_lblMgrByCheck);
        _pnlMgrByCheck.Controls.Add(_btnMgrTransfer);
        _pnlMgrByCheck.Font = new System.Drawing.Font("Comic Sans MS", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _pnlMgrByCheck.Location = new System.Drawing.Point(152, 8);
        _pnlMgrByCheck.Name = "_pnlMgrByCheck";
        _pnlMgrByCheck.Size = new System.Drawing.Size(136, 280);
        _pnlMgrByCheck.TabIndex = 10;
        // 
        // btnMgrTaxExempt
        // 
        _btnMgrTaxExempt.BackColor = System.Drawing.Color.Transparent;
        _btnMgrTaxExempt.Font = new System.Drawing.Font("Comic Sans MS", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnMgrTaxExempt.ForeColor = System.Drawing.Color.Black;
        _btnMgrTaxExempt.Location = new System.Drawing.Point(8, 168);
        _btnMgrTaxExempt.Name = "_btnMgrTaxExempt";
        _btnMgrTaxExempt.Size = new System.Drawing.Size(120, 48);
        _btnMgrTaxExempt.TabIndex = 8;
        _btnMgrTaxExempt.Text = "Tax Exempt";
        _btnMgrTaxExempt.UseVisualStyleBackColor = false;
        // 
        // btnMgrReopenCheck
        // 
        _btnMgrReopenCheck.BackColor = System.Drawing.Color.Transparent;
        _btnMgrReopenCheck.Location = new System.Drawing.Point(8, 56);
        _btnMgrReopenCheck.Name = "_btnMgrReopenCheck";
        _btnMgrReopenCheck.Size = new System.Drawing.Size(120, 48);
        _btnMgrReopenCheck.TabIndex = 5;
        _btnMgrReopenCheck.Text = "Reopen Check";
        _btnMgrReopenCheck.UseVisualStyleBackColor = false;
        // 
        // btnMgrVoidCheck
        // 
        _btnMgrVoidCheck.BackColor = System.Drawing.Color.Transparent;
        _btnMgrVoidCheck.Location = new System.Drawing.Point(8, 224);
        _btnMgrVoidCheck.Name = "_btnMgrVoidCheck";
        _btnMgrVoidCheck.Size = new System.Drawing.Size(120, 48);
        _btnMgrVoidCheck.TabIndex = 4;
        _btnMgrVoidCheck.Text = "Void Check";
        _btnMgrVoidCheck.UseVisualStyleBackColor = false;
        // 
        // lblMgrByCheck
        // 
        _lblMgrByCheck.BackColor = System.Drawing.Color.Transparent;
        _lblMgrByCheck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _lblMgrByCheck.Dock = System.Windows.Forms.DockStyle.Top;
        _lblMgrByCheck.Font = new System.Drawing.Font("Cambria", 15.75f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblMgrByCheck.Location = new System.Drawing.Point(0, 0);
        _lblMgrByCheck.Name = "_lblMgrByCheck";
        _lblMgrByCheck.Size = new System.Drawing.Size(132, 48);
        _lblMgrByCheck.TabIndex = 1;
        _lblMgrByCheck.Text = "By Check";
        _lblMgrByCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btnMgrTransfer
        // 
        _btnMgrTransfer.BackColor = System.Drawing.Color.Transparent;
        _btnMgrTransfer.Location = new System.Drawing.Point(8, 112);
        _btnMgrTransfer.Name = "_btnMgrTransfer";
        _btnMgrTransfer.Size = new System.Drawing.Size(120, 48);
        _btnMgrTransfer.TabIndex = 6;
        _btnMgrTransfer.Text = "Transfer Check";
        _btnMgrTransfer.UseVisualStyleBackColor = false;
        // 
        // btnMgrReprintOrder
        // 
        _btnMgrReprintOrder.BackColor = System.Drawing.Color.Transparent;
        _btnMgrReprintOrder.Location = new System.Drawing.Point(8, 168);
        _btnMgrReprintOrder.Name = "_btnMgrReprintOrder";
        _btnMgrReprintOrder.Size = new System.Drawing.Size(112, 48);
        _btnMgrReprintOrder.TabIndex = 3;
        _btnMgrReprintOrder.Text = "Reprint Order";
        _btnMgrReprintOrder.UseVisualStyleBackColor = false;
        // 
        // btnMgrReprintCheck
        // 
        _btnMgrReprintCheck.BackColor = System.Drawing.Color.Transparent;
        _btnMgrReprintCheck.Location = new System.Drawing.Point(8, 112);
        _btnMgrReprintCheck.Name = "_btnMgrReprintCheck";
        _btnMgrReprintCheck.Size = new System.Drawing.Size(112, 48);
        _btnMgrReprintCheck.TabIndex = 2;
        _btnMgrReprintCheck.Text = "Reprint Check";
        _btnMgrReprintCheck.UseVisualStyleBackColor = false;
        // 
        // pnlMgrByPayments
        // 
        _pnlMgrByPayments.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
        _pnlMgrByPayments.BackgroundImage = (Global.System.Drawing.Image)resources.GetObject("pnlMgrByPayments.BackgroundImage");
        _pnlMgrByPayments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _pnlMgrByPayments.Controls.Add(_btnMgrCashBack);
        _pnlMgrByPayments.Controls.Add(_btnMgrAssignGratuity);
        _pnlMgrByPayments.Controls.Add(_btnMgrAssignComps);
        _pnlMgrByPayments.Controls.Add(_btnAdjustPay);
        _pnlMgrByPayments.Controls.Add(_lblMgrByPayments);
        _pnlMgrByPayments.Font = new System.Drawing.Font("Comic Sans MS", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _pnlMgrByPayments.Location = new System.Drawing.Point(296, 8);
        _pnlMgrByPayments.Name = "_pnlMgrByPayments";
        _pnlMgrByPayments.Size = new System.Drawing.Size(128, 280);
        _pnlMgrByPayments.TabIndex = 11;
        // 
        // btnMgrCashBack
        // 
        _btnMgrCashBack.BackColor = System.Drawing.Color.Transparent;
        _btnMgrCashBack.Location = new System.Drawing.Point(8, 224);
        _btnMgrCashBack.Name = "_btnMgrCashBack";
        _btnMgrCashBack.Size = new System.Drawing.Size(112, 48);
        _btnMgrCashBack.TabIndex = 6;
        _btnMgrCashBack.Text = "Cash Back";
        _btnMgrCashBack.UseVisualStyleBackColor = false;
        // 
        // btnMgrAssignGratuity
        // 
        _btnMgrAssignGratuity.BackColor = System.Drawing.Color.Transparent;
        _btnMgrAssignGratuity.Font = new System.Drawing.Font("Comic Sans MS", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnMgrAssignGratuity.Location = new System.Drawing.Point(8, 168);
        _btnMgrAssignGratuity.Name = "_btnMgrAssignGratuity";
        _btnMgrAssignGratuity.Size = new System.Drawing.Size(112, 48);
        _btnMgrAssignGratuity.TabIndex = 5;
        _btnMgrAssignGratuity.Text = "Assign Gratuity";
        _btnMgrAssignGratuity.UseVisualStyleBackColor = false;
        // 
        // btnMgrAssignComps
        // 
        _btnMgrAssignComps.BackColor = System.Drawing.Color.Transparent;
        _btnMgrAssignComps.Location = new System.Drawing.Point(8, 112);
        _btnMgrAssignComps.Name = "_btnMgrAssignComps";
        _btnMgrAssignComps.Size = new System.Drawing.Size(112, 48);
        _btnMgrAssignComps.TabIndex = 4;
        _btnMgrAssignComps.Text = "Assign Comps";
        _btnMgrAssignComps.UseVisualStyleBackColor = false;
        // 
        // btnAdjustPay
        // 
        _btnAdjustPay.BackColor = System.Drawing.Color.Transparent;
        _btnAdjustPay.Location = new System.Drawing.Point(8, 56);
        _btnAdjustPay.Name = "_btnAdjustPay";
        _btnAdjustPay.Size = new System.Drawing.Size(112, 48);
        _btnAdjustPay.TabIndex = 3;
        _btnAdjustPay.Text = "Delete Credit";
        _btnAdjustPay.UseVisualStyleBackColor = false;
        // 
        // lblMgrByPayments
        // 
        _lblMgrByPayments.BackColor = System.Drawing.Color.Transparent;
        _lblMgrByPayments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _lblMgrByPayments.Dock = System.Windows.Forms.DockStyle.Top;
        _lblMgrByPayments.Font = new System.Drawing.Font("Cambria", 14.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblMgrByPayments.Location = new System.Drawing.Point(0, 0);
        _lblMgrByPayments.Name = "_lblMgrByPayments";
        _lblMgrByPayments.Size = new System.Drawing.Size(124, 48);
        _lblMgrByPayments.TabIndex = 2;
        _lblMgrByPayments.Text = "By Payments";
        _lblMgrByPayments.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btnMgrReprintCredit
        // 
        _btnMgrReprintCredit.BackColor = System.Drawing.Color.Transparent;
        _btnMgrReprintCredit.Location = new System.Drawing.Point(8, 56);
        _btnMgrReprintCredit.Name = "_btnMgrReprintCredit";
        _btnMgrReprintCredit.Size = new System.Drawing.Size(112, 48);
        _btnMgrReprintCredit.TabIndex = 6;
        _btnMgrReprintCredit.Text = "Reprint Credit";
        _btnMgrReprintCredit.UseVisualStyleBackColor = false;
        // 
        // pnlMgrCalculationArea
        // 
        _pnlMgrCalculationArea.BackColor = System.Drawing.Color.CornflowerBlue;
        _pnlMgrCalculationArea.Location = new System.Drawing.Point(464, 400);
        _pnlMgrCalculationArea.Name = "_pnlMgrCalculationArea";
        _pnlMgrCalculationArea.Size = new System.Drawing.Size(496, 320);
        _pnlMgrCalculationArea.TabIndex = 12;
        _pnlMgrCalculationArea.Visible = false;
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.Color.Black;
        _Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _Panel1.Controls.Add(_Panel2);
        _Panel1.Controls.Add(_pnlMgrByItem);
        _Panel1.Controls.Add(_pnlMgrByCheck);
        _Panel1.Controls.Add(_pnlMgrByPayments);
        _Panel1.Location = new System.Drawing.Point(432, 8);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(572, 300);
        _Panel1.TabIndex = 13;
        // 
        // Panel2
        // 
        _Panel2.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
        _Panel2.BackgroundImage = (Global.System.Drawing.Image)resources.GetObject("Panel2.BackgroundImage");
        _Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _Panel2.Controls.Add(_lblMgrPrinting);
        _Panel2.Controls.Add(_btnMgrReprintCredit);
        _Panel2.Controls.Add(_btnMgrReprintCheck);
        _Panel2.Controls.Add(_btnMgrReprintOrder);
        _Panel2.Font = new System.Drawing.Font("Comic Sans MS", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Panel2.Location = new System.Drawing.Point(432, 8);
        _Panel2.Name = "_Panel2";
        _Panel2.Size = new System.Drawing.Size(128, 280);
        _Panel2.TabIndex = 12;
        // 
        // lblMgrPrinting
        // 
        _lblMgrPrinting.BackColor = System.Drawing.Color.Transparent;
        _lblMgrPrinting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _lblMgrPrinting.Dock = System.Windows.Forms.DockStyle.Top;
        _lblMgrPrinting.Font = new System.Drawing.Font("Cambria", 15.75f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblMgrPrinting.Location = new System.Drawing.Point(0, 0);
        _lblMgrPrinting.Name = "_lblMgrPrinting";
        _lblMgrPrinting.Size = new System.Drawing.Size(124, 48);
        _lblMgrPrinting.TabIndex = 2;
        _lblMgrPrinting.Text = "Printing";
        _lblMgrPrinting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pnlCheckTotalFor_UC
        // 
        _pnlCheckTotalFor_UC.BackColor = System.Drawing.Color.White;
        _pnlCheckTotalFor_UC.Location = new System.Drawing.Point(64, 72);
        _pnlCheckTotalFor_UC.Name = "_pnlCheckTotalFor_UC";
        _pnlCheckTotalFor_UC.Size = new System.Drawing.Size(312, 658);
        _pnlCheckTotalFor_UC.TabIndex = 14;
        // 
        // Manager_OrderAdj_UC
        // 
        this.BackColor = System.Drawing.Color.Black;
        this.Controls.Add(_pnlCheckTotalFor_UC);
        this.Controls.Add(_Panel1);
        this.Controls.Add(_pnlMgrCalculationArea);
        this.Controls.Add(_pnlMgrCheckInfo);
        this.Name = "Manager_OrderAdj_UC";
        this.Size = new System.Drawing.Size(1024, 768);
        _pnlMgrCheckInfo.ResumeLayout(false);
        _pnlMgrByItem.ResumeLayout(false);
        _pnlMgrByCheck.ResumeLayout(false);
        _pnlMgrByPayments.ResumeLayout(false);
        _Panel1.ResumeLayout(false);
        _Panel2.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private void InitializeOther(long expNum)
    {

        // MsgBox(System.Drawing.SystemColors.Control.R.ToString)
        // MsgBox(System.Drawing.SystemColors.Control.G.ToString)
        // MsgBox(System.Drawing.SystemColors.Control.B.ToString)

        // PopulateOpenOrderData(expNum)    '(currentTable.ExperienceNumber)

        // CreateDataViews()

        // GenerateOrderTables.PopulatePaymentsAndCredits(currentTable.ExperienceNumber)
        dvForcePrice = new DataView();
        dvUnAppliedPaymentsAndCredits = new DataView();
        dvPaymentsAndCredits = new DataView();
        // GeneratePaymentsAndCreditsDataviews()

        // need *** PopulateStatusData
        DisplayOrder();
        checkTotalsMgmtAdj.AttachTotalsToTotalView(currentTable.CheckNumber);

        if (isForReopen == false)
        {
            btnMgrReopenCheck.Text = "Close Check";
            var argbtn = btnMgrReopenCheck;
            ChangeButtonColor(ref argbtn);
            btnMgrReopenCheck = argbtn;
        }
        pnlMgrByItem.BringToFront();
        pnlMgrByCheck.BringToFront();
        pnlMgrByPayments.BringToFront();

        currentTable.SIN = DetermineSelectedItemNumber() + 1;


    }

    private void FillOpenOrderData222(long experienceNumber)
    {


        // If dsOrder.Tables("OpenOrders").Rows.Count > 0 Then
        dsOrder.Tables("OpenOrders").Clear();
        // End If

        sql.cn.Open();
        sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
        // sql.SqlSelectCommandOpenOrdersSP.Parameters("@CompanyID").Value = CompanyID
        sql.SqlSelectCommandOpenOrdersSP.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlSelectCommandOpenOrdersSP.Parameters("@ExperienceNumber").Value = experienceNumber;
        sql.SqlDataAdapterOpenOrdersSP.Fill(dsOrder.Tables("OpenOrders"));
        sql.cn.Close();

        SetUpPrimaryKeys();

    }

    private void DisplayOrder()
    {

        // Me.checkTotalsMgmtAdj = New CheckTotal_UC
        // Me.checkTotalsMgmtAdj.Location = New Point(88, 16 + Me.pnlMgrCheckInfo.Height)
        // Me.Controls.Add(checkTotalsMgmtAdj)

        checkTotalsMgmtAdj = new CheckTotal_UC();
        checkTotalsMgmtAdj.Location = new Point(1, 1);
        pnlCheckTotalFor_UC.Controls.Add(checkTotalsMgmtAdj);

        UpdateCheckNumberButton();
        TestButtonColors();

    }

    private void btnMgrCheckNumber_Click(object sender, EventArgs e)
    {

        if (currentTable.CheckNumber == currentTable.NumberOfChecks)
        {
            currentTable.CheckNumber = 1;
        }
        else
        {
            currentTable.CheckNumber += 1;
        }

        // CreateDataViews()
        checkTotalsMgmtAdj.PopulateCloseGrid(dvOrder);    // dvClosingCheck)

        checkTotalsMgmtAdj.CalculatePriceAndTax(currentTable.CheckNumber);
        checkTotalsMgmtAdj.AttachTotalsToTotalView(currentTable.CheckNumber);
        GeneratePaymentsAndCreditsDataviews();

        // Dim rb As Decimal
        // rb = checkTotalsMgmtAdj.AttachTotalsToTotalView

        UpdateCheckNumberButton();
        // need to add more to update screen
        // redo datasource

    }

    private void GeneratePaymentsAndCreditsDataviews()
    {

        {
            var withBlock = dvUnAppliedPaymentsAndCredits;
            withBlock.Table = dsOrder.Tables("PaymentsAndCredits");
            withBlock.RowFilter = "Applied = False AND CheckNumber = " + currentTable.CheckNumber;
            withBlock.Sort = "PaymentFlag";
        }

        {
            var withBlock1 = dvPaymentsAndCredits;
            withBlock1.Table = dsOrder.Tables("PaymentsAndCredits");
            withBlock1.RowFilter = "Applied = True AND CheckNumber = " + currentTable.CheckNumber;
        }


    }

    private object DetermineSelectedItemNumber222()
    {
        var currentSIN = default(int);

        if (dsOrder.Tables("OpenOrders").Rows.Count > 0)
        {
            currentSIN = dsOrder.Tables("OpenOrders").Compute("Max(sin)", "");
        }

        return currentSIN;

    }



    private void UpdateCheckNumberButton()
    {
        btnMgrCheckNumber.Text = "Check   " + currentTable.CheckNumber + " of " + currentTable.NumberOfChecks; // currentTable._checkCollection.Count

    }

    private void TestButtonColors()
    {

        if (employeeAuthorization.OperationLevel >= systemAuthorization.VoidItem)
        {
            var argbtn = btnMgrVoidItem;
            ChangeButtonColor(ref argbtn);
            btnMgrVoidItem = argbtn;
        }
        if (employeeAuthorization.OperationLevel >= systemAuthorization.ForcePrice)
        {
            var argbtn1 = btnMgrForcePrice;
            ChangeButtonColor(ref argbtn1);
            btnMgrForcePrice = argbtn1;
        }
        if (employeeAuthorization.OperationLevel >= systemAuthorization.CompItem)
        {
            var argbtn2 = btnMgrCompItem;
            ChangeButtonColor(ref argbtn2);
            btnMgrCompItem = argbtn2;
        }
        if (employeeAuthorization.OperationLevel >= systemAuthorization.TaxExempt)
        {
            var argbtn3 = btnMgrTaxExempt;
            ChangeButtonColor(ref argbtn3);
            btnMgrTaxExempt = argbtn3;
        }
        if (employeeAuthorization.OperationLevel >= systemAuthorization.ReprintCheck)
        {
            var argbtn4 = btnMgrReprintCheck;
            ChangeButtonColor(ref argbtn4);
            btnMgrReprintCheck = argbtn4;
        }
        if (employeeAuthorization.OperationLevel >= systemAuthorization.ReprintOrder)
        {
            var argbtn5 = btnMgrReprintOrder;
            ChangeButtonColor(ref argbtn5);
            btnMgrReprintOrder = argbtn5;
        }
        if (employeeAuthorization.OperationLevel >= systemAuthorization.ReopenCheck)
        {
            var argbtn6 = btnMgrReopenCheck;
            ChangeButtonColor(ref argbtn6);
            btnMgrReopenCheck = argbtn6;
        }
        if (employeeAuthorization.OperationLevel >= systemAuthorization.VoidCheck)
        {
            var argbtn7 = btnMgrVoidCheck;
            ChangeButtonColor(ref argbtn7);
            btnMgrVoidCheck = argbtn7;
        }
        if (employeeAuthorization.OperationLevel >= systemAuthorization.AdjustPayment)
        {
            var argbtn8 = btnAdjustPay;
            ChangeButtonColor(ref argbtn8);
            btnAdjustPay = argbtn8;
            var argbtn9 = btnMgrCashBack;
            ChangeButtonColor(ref argbtn9);
            btnMgrCashBack = argbtn9;
        }
        if (employeeAuthorization.OperationLevel >= systemAuthorization.AssignComps)
        {
            var argbtn10 = btnMgrAssignComps;
            ChangeButtonColor(ref argbtn10);
            btnMgrAssignComps = argbtn10;
        }
        if (employeeAuthorization.OperationLevel >= systemAuthorization.AssignGratuity)
        {
            var argbtn11 = btnMgrAssignGratuity;
            ChangeButtonColor(ref argbtn11);
            btnMgrAssignGratuity = argbtn11;
        }
        if (employeeAuthorization.OperationLevel >= systemAuthorization.TransferCheck | employeeAuthorization.OperationLevel >= systemAuthorization.TransferItem)
        {
            var argbtn12 = btnMgrTransfer;
            ChangeButtonColor(ref argbtn12);
            btnMgrTransfer = argbtn12;
        }
        if (employeeAuthorization.OperationLevel >= systemAuthorization.ReprintCredit)
        {
            var argbtn13 = btnMgrReprintCredit;
            ChangeButtonColor(ref argbtn13);
            btnMgrReprintCredit = argbtn13;
        }


    }

    private void ChangeButtonColor(ref Button btn)
    {
        btn.BackColor = c16; // c10
        btn.ForeColor = c3;
        btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);


    }


    private void btnMgrVoidCheck_Click(object sender, EventArgs e)
    {

        pnlMgrCalculationArea.BringToFront();

        if (employeeAuthorization.OperationLevel < systemAuthorization.VoidCheck)
        {
            Interaction.MsgBox(employeeAuthorization.FullName + " does not have Authorization");
            return;
        }
        if (isForReopen == true)
        {
            Interaction.MsgBox("Check must be open for this function.");
            return;
        }
        if (madeChanges == true)
        {
            Interaction.MsgBox("You Must ACCEPT changes before this action.");
            return;
        }
        if (Interaction.MsgBox("Are you sure you want to VOID this check?", MsgBoxStyle.OkCancel) == MsgBoxResult.Cancel)
        {
            return;
        }

        var vRow = default(DataRowView);

        if (currentTable.IsTabNotTable == false)
        {
            if (isForReopen == true)
            {
                foreach (DataRowView currentVRow in dvClosedTables)
                {
                    vRow = currentVRow; // dsOrder.Tables("ClosedTables").Rows
                    if (vRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        vRow("TabName") = "Voided " + currentTable.TableNumber.ToString;
                        vRow("LastStatusTime") = DateTime.Now;
                        vRow("ClosedSubTotal") = 0;
                        if (object.ReferenceEquals(vRow("AvailForSeating"), DBNull.Value))
                        {
                            vRow("AvailForSeating") = DateTime.Now;
                        }
                        vRow("LastStatus") = 9;
                        break;
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
                        vRow("TabName") = "Voided " + currentTable.TableNumber.ToString;
                        vRow("LastStatusTime") = DateTime.Now;
                        vRow("ClosedSubTotal") = 0;
                        if (object.ReferenceEquals(vRow("AvailForSeating"), DBNull.Value))
                        {
                            vRow("AvailForSeating") = DateTime.Now;
                        }
                        vRow("LastStatus") = 9;

                        break;
                    }
                }
            }
        }

        else
        {
            if (isForReopen == true)
            {

                if (currentTable.TicketNumber > 0)
                {
                    foreach (DataRowView currentVRow2 in dvQuickTickets)
                    {
                        vRow = currentVRow2;
                        if (vRow("ExperienceNumber") == currentTable.ExperienceNumber)
                        {
                            vRow("TabName") = "Voided " + currentTable.TabName.ToString;
                            vRow("LastStatusTime") = DateTime.Now;
                            vRow("ClosedSubTotal") = 0;
                            if (object.ReferenceEquals(vRow("AvailForSeating"), DBNull.Value))
                            {
                                vRow("AvailForSeating") = DateTime.Now;
                            }

                            vRow("LastStatus") = 9;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (DataRowView currentVRow3 in dvClosedTabs)
                    {
                        vRow = currentVRow3;   // dsOrder.Tables("ClosedTabs").Rows
                        if (vRow("ExperienceNumber") == currentTable.ExperienceNumber)
                        {
                            vRow("TabName") = "Voided " + currentTable.TabName.ToString;
                            vRow("LastStatusTime") = DateTime.Now;
                            vRow("ClosedSubTotal") = 0;
                            if (object.ReferenceEquals(vRow("AvailForSeating"), DBNull.Value))
                            {
                                vRow("AvailForSeating") = DateTime.Now;
                            }

                            vRow("LastStatus") = 9;
                            break;
                        }
                    }
                }
            }

            else if (currentTable.TicketNumber > 0)
            {
                foreach (DataRowView currentVRow4 in dvQuickTickets)
                {
                    vRow = currentVRow4;
                    if (vRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        vRow("TabName") = "Voided " + currentTable.TabName.ToString;
                        vRow("LastStatusTime") = DateTime.Now;
                        vRow("ClosedSubTotal") = 0;
                        if (object.ReferenceEquals(vRow("AvailForSeating"), DBNull.Value))
                        {
                            vRow("AvailForSeating") = DateTime.Now;
                        }
                        vRow("LastStatus") = 9;
                        break;
                    }
                }
            }
            else
            {
                foreach (DataRowView currentVRow5 in dvAvailTabs)
                {
                    vRow = currentVRow5;    // dsOrder.Tables("AvailTabs").Rows
                    if (vRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        vRow("TabName") = "Voided " + currentTable.TabName.ToString;
                        vRow("LastStatusTime") = DateTime.Now;
                        vRow("ClosedSubTotal") = 0;
                        if (object.ReferenceEquals(vRow("AvailForSeating"), DBNull.Value))
                        {
                            vRow("AvailForSeating") = DateTime.Now;
                        }
                        vRow("LastStatus") = 9;
                        break;
                    }
                }
            }

            if (vRow is not null)
            {
                if (vRow("TabName").ToString.Length > 20)
                {
                    vRow("TabName") = vRow("TabName").Substring(0, 20);
                }
            }

        }

        // sss       GenerateOrderTables.SaveAvailTabsAndTables()
        // *** we may need to save Closed TabsAndTables, but we only void open checks?
        // *** (9) tells us void, then 1 tells us avail, should do all at once
        // AddStatusChangeData(currentTable.ExperienceNumber, 9, 0, 0, 0)
        // SaveESCStatusChangeData(9, 0, 0, 0)

        // AddStatusChangeData(currentTable.ExperienceNumber, 1, 0, 0, 0)
        // SaveESCStatusChangeData(1, 0, 0, 0)


        var sinArray = new int[dsOrder.Tables("OpenOrders").Rows.Count + 1];
        var count = default(int);
        ForceFreeInfo ffInfo;
        var oRow = default(DataRow);
        var iPromo = default(ItemPromoInfo);
        iPromo.PromoName = "    ** Void Check **";
        iPromo.PromoCode = 9;
        iPromo.PromoReason = 9;
        iPromo.empID = actingManager.EmployeeID;

        bool hasRows;
        int valueSIN;

        try
        {
            // sql.cn.Open()
            // sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery()
            foreach (DataRow oldRow in dsOrder.Tables("OpenOrders").Rows)
            {
                if (!(oldRow.RowState == DataRowState.Deleted) & !(oldRow.RowState == DataRowState.Detached))
                {
                    // If oldRow("ItemID") > 0 Then
                    if (!(oldRow("ForceFreeID") == 8) & !(oldRow("ForceFreeID") == 9) & !(oldRow("ForceFreeID") == -8) & !(oldRow("ForceFreeID") == -9))     // Not oldRow("ForceFreeID") = 7 And
                    {
                        // not ALREADY comp'd / void'd or transfered
                        // If Not oRow("ItemStatus") = 9 Or Not oRow("ItemStatus") = 8 Then
                        // above was old
                        if (oldRow("ItemStatus") == 0 | oldRow("ItemStatus") == 1)
                        {
                            // this item is just deleted 
                            sinArray[count] = oldRow("sin");
                            count += 1;
                        }
                        else
                        {
                            iPromo.empID = actingManager.EmployeeID;
                            iPromo.ItemID = oldRow("ItemID");
                            iPromo.Quantity = oldRow("Quantity") * -1;
                            iPromo.InvMultiplier = oldRow("OpenDecimal1");
                            iPromo.ItemPrice = oldRow("Price");
                            iPromo.Price = oldRow("Price");
                            iPromo.TaxPrice = oldRow("TaxPrice");
                            iPromo.SinTax = oldRow("SinTax");
                            // iPromo.FunctionID = oldRow("FunctionID")
                            // iPromo.FunctionGroup = oldRow("FunctionGroupID")
                            iPromo.FunctionFlag = "P"; // = oldRow("FunctionFlag")
                            // iPromo.CategoryID = oldRow("CategoryID")
                            // iPromo.FoodID = oldRow("FoodID")
                            // iPromo.DrinkCategoryID = oldRow("DrinkCategoryID")
                            // iPromo.DrinkID = oldRow("DrinkID")
                            // iPromo.RoutingID = oldRow("RoutingID")
                            // iPromo.PrintPriorityID = oldRow("PrintPriorityID")

                            iPromo.ItemStatus = 9;
                            oldRow("ForceFreeID") = -9;
                            oldRow("ItemStatus") = 9;
                            iPromo.openOrderID = oldRow("OpenOrderID");
                            iPromo.taxID = oldRow("TaxID");
                            iPromo.si2 = oldRow("si2");

                            if (oldRow("sii") < oldRow("sin"))   // <> valueSIN Then
                            {
                                // we populate openOrder we increase sin by 1, now they equal
                                if (currentTable.ReferenceSIN == 0)
                                {
                                    currentTable.ReferenceSIN = currentTable.SIN + 1;
                                }
                            }
                            // this will send the last one
                            // valueSIN = oldRow("sin")
                            // iPromo.sii = currentTable.SIN + 1   'thisis because before
                            else
                            {
                                currentTable.ReferenceSIN = currentTable.SIN + 1;
                            }
                            iPromo.sii = currentTable.ReferenceSIN;

                            CompThisItem(iPromo);

                        }
                    }
                    // End If
                }
            }

            if (count > 0)
            {
                int i;
                var loopTo = count - 1;
                for (i = 0; i <= loopTo; i++)
                {
                    if (!(typeProgram == "Online_Demo"))
                    {
                        oRow = dsOrder.Tables("OpenOrders").Rows.Find(sinArray[i]);
                    }
                    else
                    {
                        foreach (DataRow currentORow in dsOrder.Tables("OpenOrders").Rows)
                        {
                            oRow = currentORow;
                            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                            {
                                if (oRow("sin") == sinArray[i])
                                {
                                    break;
                                }
                            }
                        }
                    }
                    GenerateOrderTables.DeleteOpenOrdersRowTerminal(oRow);
                }
                count = 0;
            }
            // sql.cn.Close()

            foreach (SelectedItemDetail ni in newItemCollection)
                GenerateOrderTables.PopulateDataRowForOpenOrder(ni);
            newItemCollection.Clear();
        }
        catch (Exception ex)
        {
            // CloseConnection()
            newItemCollection.Clear();
            Interaction.MsgBox(ex.Message);
        }

        // Me.checkTotalsMgmtAdj.CalculatePriceAndTax(currentTable.CheckNumber)
        // Me.checkTotalsMgmtAdj.AttachTotalsToTotalView()

        if (currentTable.IsTabNotTable == false)
        {
            VoidedCheckTableStatusChange?.Invoke(currentTable.TableNumber);
        }

        ReinitializeMain?.Invoke(true, true);

    }

    private void btnMgrVoidItem_Click(object sender, EventArgs e)
    {

        pnlMgrCalculationArea.BringToFront();

        if (employeeAuthorization.OperationLevel < systemAuthorization.VoidItem)
        {
            Interaction.MsgBox(employeeAuthorization.FullName + " does not have Authorization");
            return;
        }
        if (isForReopen == true)
        {
            Interaction.MsgBox("Check must be open for this function.");
            return;
        }

        int rowNum = checkTotalsMgmtAdj.grdCloseCheck.CurrentCell.RowNumber;

        int valueSIN;
        int valueSII;
        try
        {
            valueSIN = (int)checkTotalsMgmtAdj.grdCloseCheck.Item(rowNum, 1);
            valueSII = (int)checkTotalsMgmtAdj.grdCloseCheck.Item(rowNum, 2);
        }
        catch (Exception ex)
        {
            return;
        }

        var sinArray = new int[dsOrder.Tables("OpenOrders").Rows.Count + 1];
        var count = default(int);
        ForceFreeInfo ffInfo;
        var oRow = default(DataRow);
        var iPromo = default(ItemPromoInfo);
        bool hasRows;

        iPromo.PromoName = "    ** Void";
        iPromo.PromoCode = 9;
        iPromo.PromoReason = 9;
        iPromo.empID = actingManager.EmployeeID;
        madeChanges = true;

        try
        {
            if (valueSII == valueSIN)
            {
                // *** main food
                // currentTable.ReferenceSIN = currentTable.SIN

                // sql.cn.Open()
                // sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery()
                foreach (DataRow oldRow in dsOrder.Tables("OpenOrders").Rows)
                {
                    if (!(oldRow.RowState == DataRowState.Deleted) & !(oldRow.RowState == DataRowState.Detached))
                    {
                        if (!(oldRow("ItemID") == 0))
                        {
                            if (oldRow("sii") == valueSIN)
                            {
                                if (!(oldRow("ForceFreeID") == 8) & !(oldRow("ForceFreeID") == 9) & !(oldRow("ForceFreeID") == -8) & !(oldRow("ForceFreeID") == -9))
                                {
                                    // not ALREADY comp'd / void'd or transfered
                                    // If Not oRow("ItemStatus") = 9 Or Not oRow("ItemStatus") = 8 Then
                                    // above was old
                                    if (oldRow("ItemStatus") == 0 | oldRow("ItemStatus") == 1)
                                    {
                                        // this item is just deleted 
                                        sinArray[count] = oldRow("sin");
                                        count += 1;
                                    }
                                    else
                                    {
                                        iPromo.empID = actingManager.EmployeeID;
                                        iPromo.ItemID = oldRow("ItemID");
                                        iPromo.Quantity = oldRow("Quantity") * -1;
                                        iPromo.InvMultiplier = oldRow("OpenDecimal1");
                                        iPromo.ItemPrice = oldRow("Price");
                                        iPromo.Price = oldRow("Price");
                                        iPromo.TaxPrice = oldRow("TaxPrice");
                                        iPromo.SinTax = oldRow("SinTax");

                                        // iPromo.FunctionID = oldRow("FunctionID")
                                        // iPromo.FunctionGroup = oldRow("FunctionGroupID")
                                        iPromo.FunctionFlag = "P"; // = oldRow("FunctionFlag")
                                        // iPromo.CategoryID = oldRow("CategoryID")
                                        // iPromo.FoodID = oldRow("FoodID")
                                        // '               iPromo.DrinkCategoryID = oldRow("DrinkCategoryID")
                                        // iPromo.DrinkID = oldRow("DrinkID")
                                        // iPromo.RoutingID = oldRow("RoutingID")
                                        // iPromo.PrintPriorityID = oldRow("PrintPriorityID")

                                        iPromo.ItemStatus = 9;
                                        oldRow("ForceFreeID") = -9;
                                        oldRow("ItemStatus") = 9;
                                        // If oldRow("sin") = valueSIN Then
                                        // this will send only the leading info
                                        iPromo.openOrderID = oldRow("OpenOrderID");
                                        iPromo.taxID = oldRow("TaxID");
                                        iPromo.sii = oldRow("sii");
                                        iPromo.si2 = oldRow("si2");
                                        if (!object.ReferenceEquals(oldRow("OrderNumber"), DBNull.Value))
                                        {
                                            iPromo.OrderNumber = oldRow("OrderNumber");
                                        }
                                        else
                                        {
                                            iPromo.OrderNumber = (object)null;
                                        }
                                        iPromo.CheckNumber = oldRow("CheckNumber");
                                        iPromo.CustomerNumber = oldRow("CustomerNumber");
                                        iPromo.CourseNumber = oldRow("CourseNumber");
                                        // hasRows = True
                                        // End If
                                        // 444       If hasRows = True Then
                                        CompThisItem(iPromo);
                                        // 444    End If
                                    }
                                }
                            }
                        }
                    }
                }

                if (count > 0)
                {
                    int i;
                    var loopTo = count - 1;
                    for (i = 0; i <= loopTo; i++)
                    {
                        if (!(typeProgram == "Online_Demo"))
                        {
                            oRow = dsOrder.Tables("OpenOrders").Rows.Find(sinArray[i]);
                        }
                        else
                        {
                            foreach (DataRow currentORow in dsOrder.Tables("OpenOrders").Rows)
                            {
                                oRow = currentORow;
                                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                                {
                                    if (oRow("sin") == sinArray[i])
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        GenerateOrderTables.DeleteOpenOrdersRowTerminal(oRow);
                    }
                    count = 0;
                }
            }


            else if (valueSII < valueSIN)
            {
                // *** food modifier
                if (!(typeProgram == "Online_Demo"))
                {
                    oRow = dsOrder.Tables("OpenOrders").Rows.Find(valueSIN);
                }
                else
                {
                    foreach (DataRow currentORow1 in dsOrder.Tables("OpenOrders").Rows)
                    {
                        oRow = currentORow1;
                        if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                        {
                            if (oRow("sin") == valueSIN)
                            {
                                break;
                            }
                        }
                    }
                }

                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (!(oRow("ItemID") == 0) & !(oRow("Price") < 0))
                    {
                        if (!(oRow("ForceFreeID") == 7) & !(oRow("ForceFreeID") == 8) & !(oRow("ForceFreeID") == 9) & !(oRow("ForceFreeID") == -7) & !(oRow("ForceFreeID") == -8) & !(oRow("ForceFreeID") == -9))
                        {
                            // not ALREADY comp'd or transfered
                            if (oRow("ItemStatus") == 0 | oRow("ItemStatus") == 1)
                            {
                                GenerateOrderTables.DeleteOpenOrdersRowTerminal(oRow);
                            }
                            else
                            {
                                iPromo.empID = actingManager.EmployeeID;
                                iPromo.ItemID = oRow("ItemID");
                                iPromo.Quantity = oRow("Quantity") * -1;
                                iPromo.InvMultiplier = oRow("OpenDecimal1");
                                iPromo.ItemPrice = oRow("Price");
                                iPromo.Price = oRow("Price");
                                iPromo.TaxPrice = oRow("TaxPrice");
                                iPromo.SinTax = oRow("SinTax");

                                // iPromo.FunctionID = oRow("FunctionID")
                                // iPromo.FunctionGroup = oRow("FunctionGroupID")
                                iPromo.FunctionFlag = "P"; // = oRow("FunctionFlag")
                                // iPromo.CategoryID = oRow("CategoryID")
                                // iPromo.FoodID = oRow("FoodID")
                                // iPromo.DrinkCategoryID = oRow("DrinkCategoryID")
                                // iPromo.DrinkID = oRow("DrinkID")
                                // '          iPromo.RoutingID = oRow("RoutingID")
                                // iPromo.PrintPriorityID = oRow("PrintPriorityID")

                                iPromo.ItemStatus = 9;
                                iPromo.openOrderID = oRow("OpenOrderID");
                                iPromo.taxID = oRow("TaxID");
                                iPromo.sii = oRow("sii");
                                iPromo.si2 = oRow("si2");
                                if (!object.ReferenceEquals(oRow("OrderNumber"), DBNull.Value))
                                {
                                    iPromo.OrderNumber = oRow("OrderNumber");
                                }
                                else
                                {
                                    iPromo.OrderNumber = (object)null;
                                }
                                iPromo.CheckNumber = oRow("CheckNumber");
                                iPromo.CustomerNumber = oRow("CustomerNumber");
                                iPromo.CourseNumber = oRow("CourseNumber");

                                oRow("ForceFreeID") = -9;
                                oRow("ItemStatus") = 9;

                                CompThisItem(iPromo);
                            }
                        }
                    }
                }
            }

            // sql.cn.Close()

            foreach (SelectedItemDetail ni in newItemCollection)
                GenerateOrderTables.PopulateDataRowForOpenOrder(ni);
            newItemCollection.Clear();
        }
        catch (Exception ex)
        {
            // CloseConnection()
            newItemCollection.Clear();
            Interaction.MsgBox(ex.Message);
        }

        checkTotalsMgmtAdj.CalculatePriceAndTax(currentTable.CheckNumber);
        checkTotalsMgmtAdj.AttachTotalsToTotalView(currentTable.CheckNumber);

    }

    private void AdjustVoidedDataRow222(DataRow oRow)
    {

        // Dim nRow As DataRow = dsOrder.Tables("OpenOrders").NewRow
        var currentItem = new SelectedItemDetail();
        // this is the credit entry for voided item

        if (oRow("Price") > 0)
        {
            // .Table = oRow("TableNumber")
            currentItem.Check = oRow("CheckNumber");
            currentItem.Customer = oRow("CustomerNumber");
            currentItem.Course = oRow("CourseNumber");
            currentItem.SIN = currentTable.SIN;
            currentItem.SII = oRow("sin");     // currentTable.ReferenceSIN
            currentItem.ID = oRow("ItemID");    // voidingFlag will adj in AddItem Sub
            currentItem.Voiding = true;
            currentItem.Name = oRow("ItemName");    // "**  VOID  " & oRow("ItemName")
            currentItem.TerminalName = "**  VOID  " + oRow("ItemName");
            currentItem.ChitName = "**  VOID  " + oRow("ItemName");
            currentItem.Price = -1 * oRow("Price");
            // tax price is calculate w/ a neg price
            currentItem.TaxID = oRow("TaxID");
            currentItem.FunctionID = oRow("FunctionID");
            if (oRow("FunctionID") == 1 | oRow("FunctionID") == 2 | oRow("FunctionID") == 3)
            {
                currentItem.Category = oRow("CategoryID");
            }
            else if (oRow("FunctionID") >= 4 & oRow("FunctionID") <= 7)
            {
                currentItem.Category = oRow("DrinkCategoryID");
                // i don't think we need if fun = 0
            }
            currentItem.RoutingID = oRow("RoutingID");
            currentItem.PrintPriorityID = oRow("PrintPriorityID");

            voidedItems.Add(currentItem);
            // nRow = PopulateDataRowForOpenOrder(currentItem)
            // dsOrder.Tables("OpenOrders").Rows.Add(nRow)

            currentTable.SIN += 1;        // not sure about ReferenceSIN

        }

        // now for the debit entry
        // ************* below no good , need to use force free table
        oRow("ForceFreeID") = 0;       // mgr override (-1 is changed amount, 0 is voided)
        oRow("ForceFreeAuth") = actingManager.EmployeeID;
        oRow("ForceFreeCode") = 0;   // oRow("Price")
        oRow("ItemStatus") = 9;
        // oRow("ItemName") = "  ** Void" & oRow("ItemName")
        // oRow("Price") = 0
        // oRow("TaxPrice") = 0


    }

    private void AddVoidedItemCollection222()
    {
        DataRow nRow = dsOrder.Tables("OpenOrders").NewRow;

        foreach (SelectedItemDetail vItem in voidedItems)
            PopulateDataRowForOpenOrder(vItem);

    }

    private void btnMgrForcePrice_Click(object sender, EventArgs e)
    {

        pnlMgrCalculationArea.BringToFront();

        if (employeeAuthorization.OperationLevel < systemAuthorization.ForcePrice)
        {
            Interaction.MsgBox(employeeAuthorization.FullName + " does not have Authorization");
            return;
        }
        if (isForReopen == true)
        {
            Interaction.MsgBox("Check must be open for this function.");
            return;
        }

        forceRowNum = checkTotalsMgmtAdj.grdCloseCheck.CurrentCell.RowNumber;

        int valueSIN;
        int valueSII;
        var begAmount = default(decimal);

        try
        {
            valueSIN = (int)checkTotalsMgmtAdj.grdCloseCheck.Item(forceRowNum, 1);
            valueSII = (int)checkTotalsMgmtAdj.grdCloseCheck.Item(forceRowNum, 2);
        }
        catch (Exception ex)
        {
            return;
        }

        if (valueSII == valueSIN)
        {
            // *** main food

            {
                var withBlock = dvForcePrice;
                withBlock.Table = dsOrder.Tables("OpenOrders");
                withBlock.RowFilter = "sii = " + valueSIN;
                withBlock.AllowEdit = true;
                withBlock.Sort = "sin";
            }
        }

        else if (valueSII < valueSIN)
        {
            // *** food modifier
            {
                var withBlock1 = dvForcePrice;
                withBlock1.Table = dsOrder.Tables("OpenOrders");
                withBlock1.RowFilter = "sin = " + valueSIN;
                withBlock1.AllowEdit = true;
            }
        }

        foreach (DataRowView vRow in dvForcePrice)
            begAmount += vRow("Price");


        RemoveAllInCalculationArea();

        forcePriceMgmtAdj = new ForcePrice_UC(begAmount);
        // (CType(Me.checkTotalsMgmtAdj.grdCloseCheck.Item(forceRowNum, 4), Decimal))
        forcePriceMgmtAdj.Location = new Point(12, 12); // (344, 304)
        pnlMgrCalculationArea.Controls.Add(forcePriceMgmtAdj);
        pnlMgrCalculationArea.Visible = true;
        // Me.forcePriceMgmtAdj.Visible = True

    }

    private void ApplyForcePrice(decimal newAdjAmount, decimal discountedAmount)
    {
        int rowNum;
        decimal oldPrice;
        decimal oldTax;
        decimal newPrice;
        decimal newTax;
        decimal newSinTax;

        // Dim valueSIN As Integer
        DataRow vRow;
        int index;
        ForceFreeInfo ffInfo;
        // RaiseEvent UpdateAdjGrid()

        // rowNum = Me.grdForcePrice.CurrentCell.RowNumber
        // valueSIN = CType(Me.grdForcePrice.Item(rowNum, 0), Integer)
        int valueSIN;
        int valueSII;
        try
        {
            valueSIN = (int)checkTotalsMgmtAdj.grdCloseCheck.Item(forceRowNum, 1);
            valueSII = (int)checkTotalsMgmtAdj.grdCloseCheck.Item(forceRowNum, 2);
        }
        catch (Exception ex)
        {
            return;
        }

        var oRow = default(DataRow);
        var iPromo = default(ItemPromoInfo);
        // for voids
        var sinArray = new int[dsOrder.Tables("OpenOrders").Rows.Count + 1];
        int count;
        var hasRow = default(bool);

        iPromo.PromoCode = 6;
        iPromo.PromoReason = 112;
        iPromo.empID = actingManager.EmployeeID;
        madeChanges = true;

        try
        {
            // sql.cn.Open()
            // sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery()

            if (valueSII == valueSIN)
            {
                // *** main food
                // *** for comp'd we have to comp modifiers individually

                foreach (DataRow oldRow in dsOrder.Tables("OpenOrders").Rows)
                {
                    if (!(oldRow.RowState == DataRowState.Deleted) & !(oldRow.RowState == DataRowState.Detached))
                    {
                        if (!(oldRow("ItemID") == 0))
                        {
                            if (oldRow("sii") == valueSIN)
                            {
                                if (!(oldRow("ForceFreeID") == 7) & !(oldRow("ForceFreeID") == 8) & !(oldRow("ForceFreeID") == 9) & !(oldRow("ForceFreeID") == -7) & !(oldRow("ForceFreeID") == -8) & !(oldRow("ForceFreeID") == -9))
                                {
                                    // not ALREADY comp'd or transfered
                                    // If Not oRow("ItemStatus") = 9 Or Not oRow("ItemStatus") = 8 Then
                                    // above was old
                                    // iPromo is the adjustment
                                    if (oldRow("sin") == valueSIN)
                                    {
                                        // this will send only the leading info
                                        iPromo.empID = actingManager.EmployeeID;
                                        iPromo.PromoName = "   ** Ajust: " + oldRow("TerminalName");
                                        iPromo.ItemPrice += oldRow("Price");
                                        iPromo.Price += discountedAmount;
                                        iPromo.TaxPrice += 0;
                                        iPromo.SinTax += 0;
                                        iPromo.openOrderID = oldRow("OpenOrderID");
                                        iPromo.taxID = oldRow("TaxID");
                                        iPromo.sii = oldRow("sii");
                                        iPromo.si2 = oldRow("si2");
                                        oldRow("ForceFreeID") = -1 * iPromo.PromoCode;

                                        // iPromo.FunctionID = oldRow("FunctionID")
                                        // iPromo.FunctionGroup = oldRow("FunctionGroupID")
                                        iPromo.FunctionFlag = "P"; // = oldRow("FunctionFlag")
                                        // iPromo.CategoryID = oldRow("CategoryID")
                                        // iPromo.FoodID = oldRow("FoodID")
                                        // iPromo.DrinkCategoryID = oldRow("DrinkCategoryID")
                                        // iPromo.DrinkID = oldRow("DrinkID")
                                        // '             iPromo.RoutingID = oldRow("RoutingID")
                                        // iPromo.PrintPriorityID = oldRow("PrintPriorityID")
                                        if (!object.ReferenceEquals(oldRow("OrderNumber"), DBNull.Value))
                                        {
                                            iPromo.OrderNumber = oldRow("OrderNumber");
                                        }
                                        else
                                        {
                                            iPromo.OrderNumber = (object)null;
                                        }
                                        iPromo.CheckNumber = oldRow("CheckNumber");
                                        iPromo.CustomerNumber = oldRow("CustomerNumber");
                                        iPromo.CourseNumber = oldRow("CourseNumber");

                                        hasRow = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (hasRow == true)
                {
                    CompThisItem(iPromo);
                }
            }

            else if (valueSII < valueSIN)
            {
                // *** food modifier
                if (!(typeProgram == "Online_Demo"))
                {
                    oRow = dsOrder.Tables("OpenOrders").Rows.Find(valueSIN);
                }
                else
                {
                    foreach (DataRow currentORow in dsOrder.Tables("OpenOrders").Rows)
                    {
                        oRow = currentORow;
                        if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                        {
                            if (oRow("sin") == valueSIN)
                            {
                                break;
                            }
                        }
                    }
                }

                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (!(oRow("ItemID") == 0) & !(oRow("Price") < 0))
                    {
                        if (!(oRow("ForceFreeID") == 7) & !(oRow("ForceFreeID") == 8) & !(oRow("ForceFreeID") == 9) & !(oRow("ForceFreeID") == -7) & !(oRow("ForceFreeID") == -8) & !(oRow("ForceFreeID") == -9))
                        {
                            // not ALREADY comp'd or transfered
                            iPromo.empID = actingManager.EmployeeID;
                            iPromo.PromoName = "   ** Ajust: " + oRow("TerminalName");
                            iPromo.ItemPrice += oRow("Price");
                            iPromo.Price += discountedAmount;
                            iPromo.TaxPrice += 0;
                            iPromo.SinTax += 0;
                            iPromo.openOrderID = oRow("OpenOrderID");
                            iPromo.taxID = oRow("TaxID");
                            iPromo.sii = oRow("sii");
                            iPromo.si2 = oRow("si2");
                            oRow("ForceFreeID") = -1 * iPromo.PromoCode;

                            // iPromo.FunctionID = oRow("FunctionID")
                            // iPromo.FunctionGroup = oRow("FunctionGroupID")
                            iPromo.FunctionFlag = "P"; // = oRow("FunctionFlag")
                            // iPromo.CategoryID = oRow("CategoryID")
                            // iPromo.FoodID = oRow("FoodID")
                            // '          iPromo.DrinkCategoryID = oRow("DrinkCategoryID")
                            // iPromo.DrinkID = oRow("DrinkID")
                            // iPromo.RoutingID = oRow("RoutingID")
                            // iPromo.PrintPriorityID = oRow("PrintPriorityID")
                            if (!object.ReferenceEquals(oRow("OrderNumber"), DBNull.Value))
                            {
                                iPromo.OrderNumber = oRow("OrderNumber");
                            }
                            else
                            {
                                iPromo.OrderNumber = (object)null;
                            }
                            iPromo.CheckNumber = oRow("CheckNumber");
                            iPromo.CustomerNumber = oRow("CustomerNumber");
                            iPromo.CourseNumber = oRow("CourseNumber");

                            CompThisItem(iPromo);

                        }
                    }
                }
            }
            // sql.cn.Close()

            foreach (SelectedItemDetail ni in newItemCollection)
            {
                currentTable.SIN += 1;
                GenerateOrderTables.PopulateDataRowForOpenOrder(ni);
            }
            newItemCollection.Clear();
        }
        catch (Exception ex)
        {
            // CloseConnection()
            newItemCollection.Clear();
            Interaction.MsgBox(ex.Message);
        }

        checkTotalsMgmtAdj.CalculatePriceAndTax(currentTable.CheckNumber);
        checkTotalsMgmtAdj.AttachTotalsToTotalView(currentTable.CheckNumber);
        forcePriceMgmtAdj.Dispose();
        pnlMgrCalculationArea.Visible = false;



    }

    private void DisposingForcePrice()
    {

        forcePriceMgmtAdj.Dispose();
        pnlMgrCalculationArea.Visible = false;

    }

    private void btnMgrCompItem_Click(object sender, EventArgs e)
    {

        pnlMgrCalculationArea.BringToFront();

        if (employeeAuthorization.OperationLevel < systemAuthorization.CompItem)
        {
            Interaction.MsgBox(employeeAuthorization.FullName + " does not have Authorization");
            return;
        }
        if (isForReopen == true)
        {
            Interaction.MsgBox("Check must be open for this function.");
            return;
        }

        int rowNum = checkTotalsMgmtAdj.grdCloseCheck.CurrentCell.RowNumber;

        int valueSIN;
        int valueSII;
        try
        {
            valueSIN = (int)checkTotalsMgmtAdj.grdCloseCheck.Item(rowNum, 1);
            valueSII = (int)checkTotalsMgmtAdj.grdCloseCheck.Item(rowNum, 2);
        }
        catch (Exception ex)
        {
            return;
        }

        var oRow = default(DataRow);
        var iPromo = default(ItemPromoInfo);
        // for voids
        var sinArray = new int[dsOrder.Tables("OpenOrders").Rows.Count + 1];
        int count;
        var hasRow = default(bool);

        iPromo.PromoCode = 7;
        iPromo.PromoReason = 112;
        iPromo.empID = actingManager.EmployeeID;
        madeChanges = true;

        try
        {
            // sql.cn.Open()
            // sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery()

            if (valueSII == valueSIN)
            {
                // *** main food
                // *** for comp'd we have to comp modifiers individually

                foreach (DataRow oldRow in dsOrder.Tables("OpenOrders").Rows)
                {
                    if (!(oldRow.RowState == DataRowState.Deleted) & !(oldRow.RowState == DataRowState.Detached))
                    {
                        if (!(oldRow("ItemID") == 0))    // not customer panel
                        {
                            if (oldRow("sii") == valueSIN)
                            {
                                if (!(oldRow("ForceFreeID") == 7) & !(oldRow("ForceFreeID") == 8) & !(oldRow("ForceFreeID") == 9) & !(oldRow("ForceFreeID") == -7) & !(oldRow("ForceFreeID") == -8) & !(oldRow("ForceFreeID") == -9))
                                {
                                    // not ALREADY comp'd or transfered
                                    // If Not oRow("ItemStatus") = 7 And Not oRow("ItemStatus") = 8 And Not oRow("ItemStatus") = 9 Then
                                    // above was old
                                    iPromo.empID = actingManager.EmployeeID;
                                    iPromo.ItemPrice += oldRow("Price");
                                    iPromo.Price += oldRow("Price");
                                    iPromo.TaxPrice += oldRow("TaxPrice");
                                    iPromo.SinTax += oldRow("SinTax");

                                    oldRow("ForceFreeID") = -7;

                                    if (oldRow("sin") == valueSIN)
                                    {
                                        // this will send only the leading info
                                        iPromo.PromoName = "   ** Comp'd: " + oldRow("TerminalName");
                                        iPromo.openOrderID = oldRow("OpenOrderID");
                                        iPromo.taxID = oldRow("TaxID");
                                        iPromo.sii = oldRow("sii");
                                        iPromo.si2 = oldRow("si2");
                                        if (!object.ReferenceEquals(oldRow("OrderNumber"), DBNull.Value))
                                        {
                                            iPromo.OrderNumber = oldRow("OrderNumber");
                                        }
                                        else
                                        {
                                            iPromo.OrderNumber = (object)null;
                                        }
                                        iPromo.CheckNumber = oldRow("CheckNumber");
                                        iPromo.CustomerNumber = oldRow("CustomerNumber");
                                        iPromo.CourseNumber = oldRow("CourseNumber");

                                        // iPromo.FunctionID = oldRow("FunctionID")
                                        // iPromo.FunctionGroup = oldRow("FunctionGroupID")
                                        iPromo.FunctionFlag = "P"; // oldRow("FunctionFlag")
                                        // iPromo.CategoryID = oldRow("CategoryID")
                                        // iPromo.FoodID = oldRow("FoodID")
                                        // iPromo.DrinkCategoryID = oldRow("DrinkCategoryID")
                                        // iPromo.DrinkID = oldRow("DrinkID")
                                        // iPromo.RoutingID = oldRow("RoutingID")
                                        // iPromo.PrintPriorityID = oldRow("PrintPriorityID")
                                        hasRow = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (hasRow == true)
                {
                    CompThisItem(iPromo);
                }
            }

            else if (valueSII < valueSIN)
            {
                // *** food modifier
                if (!(typeProgram == "Online_Demo"))
                {
                    oRow = dsOrder.Tables("OpenOrders").Rows.Find(valueSIN);
                }
                else
                {
                    foreach (DataRow currentORow in dsOrder.Tables("OpenOrders").Rows)
                    {
                        oRow = currentORow;
                        if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                        {
                            if (oRow("sin") == valueSIN)
                            {
                                break;
                            }
                        }
                    }
                }

                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (!(oRow("ItemID") == 0) & !(oRow("Price") < 0))
                    {
                        if (!(oRow("ForceFreeID") == 7) & !(oRow("ForceFreeID") == 8) & !(oRow("ForceFreeID") == 9) & !(oRow("ForceFreeID") == -7) & !(oRow("ForceFreeID") == -8) & !(oRow("ForceFreeID") == -9))
                        {
                            // not ALREADY comp'd or transfered
                            iPromo.empID = actingManager.EmployeeID;
                            iPromo.PromoName = "   ** Comp'd: " + oRow("TerminalName");
                            iPromo.ItemPrice += oRow("Price");
                            iPromo.Price += oRow("Price");
                            iPromo.TaxPrice += oRow("TaxPrice");
                            iPromo.SinTax += oRow("SinTax");
                            iPromo.openOrderID = oRow("OpenOrderID");
                            iPromo.taxID = oRow("TaxID");
                            iPromo.sii = oRow("sii");
                            iPromo.si2 = oRow("si2");

                            // iPromo.FunctionID = oRow("FunctionID")
                            // iPromo.FunctionGroup = oRow("FunctionGroupID")
                            iPromo.FunctionFlag = "P"; // = oRow("FunctionFlag")
                            // iPromo.CategoryID = oRow("CategoryID")
                            // iPromo.FoodID = oRow("FoodID")
                            // iPromo.DrinkCategoryID = oRow("DrinkCategoryID")
                            // iPromo.DrinkID = oRow("DrinkID")
                            // iPromo.RoutingID = oRow("RoutingID")
                            // iPromo.PrintPriorityID = oRow("PrintPriorityID")
                            if (!object.ReferenceEquals(oRow("OrderNumber"), DBNull.Value))
                            {
                                iPromo.OrderNumber = oRow("OrderNumber");
                            }
                            else
                            {
                                iPromo.OrderNumber = (object)null;
                            }

                            iPromo.CheckNumber = oRow("CheckNumber");
                            iPromo.CustomerNumber = oRow("CustomerNumber");
                            iPromo.CourseNumber = oRow("CourseNumber");
                            oRow("ForceFreeID") = -7;    // iPromo.PromoCode
                            CompThisItem(iPromo);

                        }
                    }
                }
            }
            // sql.cn.Close()

            foreach (SelectedItemDetail ni in newItemCollection)
                GenerateOrderTables.PopulateDataRowForOpenOrder(ni);
            newItemCollection.Clear();
        }
        catch (Exception ex)
        {
            // CloseConnection()
            newItemCollection.Clear();
            Interaction.MsgBox(ex.Message);
        }

        checkTotalsMgmtAdj.CalculatePriceAndTax(currentTable.CheckNumber);
        checkTotalsMgmtAdj.AttachTotalsToTotalView(currentTable.CheckNumber);

    }


    // 09.10
    // If ffInfo.ffID > 0 Then
    // oRow("ForceFreeID") = ffInfo.ffID
    // Else
    // oRow("ForceFreeID") = -9
    // '      oRow("ForceFreeCode") = oRow("Price")
    // End If
    // oRow("ForceFreeAuth") = actingManager.EmployeeID
    // oRow("ItemName") = oRow("ItemName") & "  ** Comp'd"
    // oRow("Price") = 0
    // '     oRow("TaxPrice") = 0
    // oRow("SinTax") = 0



    // 
    // Private Sub UpdateAdjGrid() Handles forcePriceMgmtAdj.UpdateAdjGrid
    // 
    // If Me.checkTotalsMgmtAdj.grdCloseCheck.CurrentRowIndex > 0 Then
    // Me.checkTotalsMgmtAdj.grdCloseCheck.CurrentRowIndex -= 1
    // Me.checkTotalsMgmtAdj.grdCloseCheck.CurrentRowIndex += 1
    // Else
    // Me.checkTotalsMgmtAdj.grdCloseCheck.CurrentRowIndex += 1
    // Me.checkTotalsMgmtAdj.grdCloseCheck.CurrentRowIndex -= 1
    // 
    // End If
    // 
    // End Sub

    private void UpdatePaymentListView()
    {
        madeChanges = true;
        btnManagerCancel.Enabled = false;
        checkTotalsMgmtAdj.AttachTotalsToTotalView(currentTable.CheckNumber);

    }

    private void ButtonManagerCancel_Click(object sender, EventArgs e)
    {

        RejectChanges_Manager();
        ReinitializeMain?.Invoke(false, true);

    }

    private void btnAdjAccept_Click(object sender, EventArgs e)
    {

        ReinitializeMain?.Invoke(true, true);

    }

    private void RejectChanges_Manager()
    {

        dsOrder.RejectChanges();

    }

    private void btnAdjustPay_Click(object sender, EventArgs e)
    {

        if (employeeAuthorization.OperationLevel < systemAuthorization.AdjustPayment)
        {
            Interaction.MsgBox(employeeAuthorization.FullName + " does not have Authorization");
            return;
        }

        if (isForReopen == true)
        {
            Interaction.MsgBox("Check must be open for this function.");
            return;
        }

        pnlMgrCalculationArea.BringToFront();
        // this is temp

        RemoveAllInCalculationArea();
        // GeneratePaymentsAndCreditsDataviews()
        {
            var withBlock = dvPaymentsAndCredits;
            withBlock.Table = dsOrder.Tables("PaymentsAndCredits");
            withBlock.RowFilter = "(Applied = True AND BatchCleared = False) AND (PaymentFlag = 'cc' OR PaymentFlag = 'Gift' OR PaymentFlag = 'outside' OR PaymentTypeID = '-98')";
        }

        checkAdjMgmtAdj = new CheckAdjustmentOverride_UC();
        checkAdjMgmtAdj.Location = new Point(12, 12); // (344, 304)
        pnlMgrCalculationArea.Controls.Add(checkAdjMgmtAdj);
        pnlMgrCalculationArea.Visible = true;

    }


    private void btnCashBack_Click(object sender, EventArgs e)
    {

        if (employeeAuthorization.OperationLevel < systemAuthorization.AdjustPayment)
        {
            // same authorization as adjust payment
            Interaction.MsgBox(employeeAuthorization.FullName + " does not have Authorization");
            return;
        }

        if (isForReopen == true)
        {
            Interaction.MsgBox("Check must be open for this function.");
            return;
        }

        {
            var withBlock = dvPaymentsAndCredits;
            withBlock.Table = dsOrder.Tables("PaymentsAndCredits");
            withBlock.RowFilter = "Applied = True AND CheckNumber = " + currentTable.CheckNumber + " AND PaymentFlag = 'Cash'";
        }
        var maxCashAmount = default(decimal);

        Panel1.Enabled = false;
        RemoveAllInCalculationArea();
        pnlMgrCalculationArea.Visible = false;

        foreach (DataRowView vRow in dvPaymentsAndCredits)
            maxCashAmount += vRow("PaymentAmount");

        cashOut = new CashOut_UC(currentTable.ExperienceNumber, 1, maxCashAmount);  // expnum, payTypeID, MaxCashOut
        cashOut.Location = new Point((this.Width - cashOut.Width) / 2, (this.Height - cashOut.Height) / 2);
        cashOut.lblCashOut.Text = "Refund Cash";
        this.Controls.Add(cashOut);
        cashOut.BringToFront();


    }

    private void CashOutCanceled(object sender, EventArgs e)
    {

        Panel1.Enabled = true;

    }

    private void CashOutAccepted(object sender, EventArgs e)
    {

        Panel1.Enabled = true;
        madeChanges = true;

        var newPayment = default(DataSet_Builder.Payment);
        decimal amount;

        if (cashOut.ItemPrice > 0)
        {
            amount = -1 * cashOut.ItemPrice;
            newPayment.Purchase = Strings.Format(amount, "##,##0.00");
            newPayment.PaymentTypeID = cashOut.PaymentTypeID;
            newPayment.PaymentTypeName = "Cash";   // "Enter Acct #"
            newPayment.Description = cashOut.ItemDescription;

            GenerateOrderTables.AddPaymentToDataRow(newPayment, true, currentTable.ExperienceNumber, actingManager.EmployeeID, currentTable.CheckNumber, false);
            // GenerateOrderTables.UpdatePaymentsAndCredits()
        }

        cashOut.Dispose();
        prt.PrintOpenCashDrawer();
        checkTotalsMgmtAdj.CalculatePriceAndTax(currentTable.CheckNumber);
        checkTotalsMgmtAdj.AttachTotalsToTotalView(currentTable.CheckNumber);

    }


    private void RemoveAllInCalculationArea()
    {

        pnlMgrCalculationArea.Controls.Clear();

    }


    private void lblMgrByItem_Click(object sender, EventArgs e)
    {

        pnlMgrByItem.BringToFront();

    }

    private void lblMgrByCheck_Click(object sender, EventArgs e)
    {

        pnlMgrByCheck.BringToFront();

    }

    private void lblMgrByPayments_Click(object sender, EventArgs e)
    {
        pnlMgrByPayments.BringToFront();

    }

    private void btnMgrReprintCheck_Click(object sender, EventArgs e)
    {

        var prt = new PrintHelper();

        if (employeeAuthorization.OperationLevel < systemAuthorization.ReprintCheck)
        {
            Interaction.MsgBox(employeeAuthorization.FullName + " does not have Authorization");
            return;
        }

        CreateClosingDataViews(currentTable.CheckNumber, true);
        prt.closeDetail.dvClosing = dvOrder;   // dvClosingCheck
        prt.closeDetail.chkSubTotal = checkTotalsMgmtAdj.chkSubTotal;
        // prt.closeDetail.checkTax = checkTotalsMgmtAdj.checkTax
        prt.closeDetail.chktaxName = checkTotalsMgmtAdj.taxName;
        prt.closeDetail.chktaxTotal = checkTotalsMgmtAdj.taxTotal;

        prt.StartPrintCheckReceipt(); // (dvClosingCheck, checkTotalsMgmtAdj.chkSubTotal, checkTotalsMgmtAdj.checkTax)

        // Me.pnlMgrCalculationArea.BringToFront()

    }

    private void btnMgrReprintOrder_Click(object sender, EventArgs e)
    {

        // MsgBox("Order does NOT reprint. Inform Kitchen.")
        // Exit Sub

        DataRow rRow;
        OrderDetailInfo oDetail;
        long reprintOrderNumber;
        var prt = new PrintHelper();


        if (employeeAuthorization.OperationLevel < systemAuthorization.ReprintOrder)
        {
            Interaction.MsgBox(employeeAuthorization.FullName + " does not have Authorization");
            return;
        }


        if (dsOrder.Tables("OrderDetail").Rows.Count > 0)
        {
            rRow = dsOrder.Tables("OrderDetail").Rows(dsOrder.Tables("OrderDetail").Rows.Count - 1);
            // oDetail.trunkOrderNumber = rRow("OrderNumber")
            reprintOrderNumber = rRow("OrderNumber");
            prt.oDetail.trunkOrderNumber = reprintOrderNumber;  // = oDetail
            prt.SendingOrder(reprintOrderNumber);
        }
        // prt.oDetail.trunkOrderNumber = reprintOrderNumber  ' = oDetail
        // prt.SendingOrder(reprintOrderNumber)

        return;
        // 222
        if (dsOrder.Tables("OrderDetail").Rows.Count == 1)
        {
            rRow = dsOrder.Tables("OrderDetail").Rows(0);
            oDetail.trunkOrderNumber = rRow("OrderNumber");
            prt.oDetail = oDetail;
            prt.SendingOrder(rRow("OrderNumber"));
        }
        else
        {
            foreach (DataRow currentRRow in dsOrder.Tables("OrderDetail").Rows)
                // MsgBox(oRow("OrderNumber"))
                rRow = currentRRow;
            // currently only printing last order
            oDetail.trunkOrderNumber = rRow("OrderNumber");
            prt.oDetail = oDetail;
            prt.SendingOrder(rRow("OrderNumber"));
        }

        // *** we need to list all the order printed for this exp number
        // routing are from term_OrderForm:
        // FirstStepOrdersPending
        // SendingOrderRoutine
        // Me.pnlMgrCalculationArea.BringToFront()

    }

    private void btnMgrReopenCheck_Click(object sender, EventArgs e)
    {

        // FOR CLOSING AND REOPENGING
        DataRowView vRow;
        // Me.pnlMgrCalculationArea.BringToFront()

        if (isForReopen == true)
        {
            if (employeeAuthorization.OperationLevel < systemAuthorization.ReopenCheck)
            {
                Interaction.MsgBox(employeeAuthorization.FullName + " does not have Authorization");
                return;
            }

            if (currentTable.IsTabNotTable == false)
            {
                foreach (DataRowView currentVRow in dvClosedTables)
                {
                    vRow = currentVRow; // dsOrder.Tables("ClosedTables").Rows
                    if (vRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        vRow("TabName") = "ReOpened " + currentTable.TableNumber.ToString;
                        vRow("LastStatusTime") = DateTime.Now;
                        vRow("ClosedSubTotal") = DBNull.Value;
                        vRow("LastStatus") = 2;
                        // do not change AvailForSeating Time
                        // this check may reopen and close 2 weeks later 
                        break;
                    }
                }
                foreach (DataRowView currentVRow1 in dvAvailTables)
                {
                    vRow = currentVRow1;  // dsOrder.Tables("AvailTables").Rows
                    if (vRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        vRow("TabName") = "ReOpened " + currentTable.TableNumber.ToString;
                        vRow("LastStatusTime") = DateTime.Now;
                        vRow("ClosedSubTotal") = DBNull.Value;
                        vRow("LastStatus") = 2;
                        break;
                    }
                }
                currentTable.IsClosed = false;
                currentTable.LastStatus = 2;
            }

            // If typeProgram = "Online_Demo" Then
            // ' is table
            // dsOrder.Tables("AvailTables").Clear()
            // End If

            else
            {
                foreach (DataRowView currentVRow2 in dvClosedTabs)
                {
                    vRow = currentVRow2;   // dsOrder.Tables("ClosedTabs").Rows
                    if (vRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        vRow("LastStatusTime") = DateTime.Now;
                        vRow("ClosedSubTotal") = DBNull.Value;
                        vRow("LastStatus") = 2;
                        break;
                    }
                }
                foreach (DataRowView currentVRow3 in dvAvailTabs)
                {
                    vRow = currentVRow3;    // dsOrder.Tables("AvailTabs").Rows
                    if (vRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        vRow("LastStatusTime") = DateTime.Now;
                        vRow("ClosedSubTotal") = DBNull.Value;
                        vRow("LastStatus") = 2;
                        break;
                    }
                }
                foreach (DataRowView currentVRow4 in dvQuickTickets)
                {
                    vRow = currentVRow4;
                    if (vRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        vRow("LastStatusTime") = DateTime.Now;
                        vRow("ClosedSubTotal") = DBNull.Value;
                        vRow("LastStatus") = 2;
                        break;
                    }
                }

                // If typeProgram = "Online_Demo" Then
                // ' is Tab or ticket
                // If currentTable.TicketNumber = 0 Then
                // dsOrder.Tables("AvailTabs").Clear()
                // Else
                // dsOrder.Tables("QuickTickets").Clear()
                // '          End If
                // End If

                currentTable.IsClosed = false;
                currentTable.LastStatus = 2;
            }

            PlacingOrder?.Invoke();
        }

        // If mainServerConnected = True Then
        // GenerateOrderTables.AddStatusChangeData(currentTable.ExperienceNumber, 10, Nothing, 0, Nothing)
        // GenerateOrderTables.SaveAvailTabsAndTables()
        // RaiseEvent PlacingOrder()
        // Else
        // MsgBox("You can only reopen a check when connected to the main Server")
        // End If

        else
        {
            // we close the check
            // currentServer = actingManager
            // actingManager = Nothing

            MgrClosingCheck?.Invoke();
            // event is in Manager_Form

            // ******************************
            // when doing this we have to redo the closing events in Manager Form 
            // for close exit and release
            // **************************************
            // Me.Dispose()

        }

    }

    private void btnMgrAssignComps_Click(object sender, EventArgs e)
    {

        if (employeeAuthorization.OperationLevel < systemAuthorization.AssignComps)
        {
            Interaction.MsgBox(employeeAuthorization.FullName + " does not have Authorization");
            return;
        }
        if (isForReopen == true)
        {
            Interaction.MsgBox("Check must be open for this function.");
            return;
        }
        pnlMgrCalculationArea.BringToFront();

        RemoveAllInCalculationArea();
        checkTotalsMgmtAdj.CalculatePriceAndTax(currentTable.CheckNumber);

        compTktMgmtAdj = new Comp_Ticket_UC(checkTotalsMgmtAdj.chkFood, checkTotalsMgmtAdj.chkDrinks, checkTotalsMgmtAdj.chkSubTotal, checkTotalsMgmtAdj.checkTax, checkTotalsMgmtAdj.checkSinTax);  // checkTotalsMgmtAdj.taxName, checkTotalsMgmtAdj.taxTotal) '
        compTktMgmtAdj.Location = new Point(12, 12);
        pnlMgrCalculationArea.Controls.Add(compTktMgmtAdj);
        pnlMgrCalculationArea.Visible = true;

    }

    private void DisposingCompTicket()
    {

        compTktMgmtAdj.Dispose();
        pnlMgrCalculationArea.Visible = false;

    }

    private void AcceptingCompTicket()
    {

        var iPromo = default(ItemPromoInfo);
        DataRow oRow;

        iPromo.PromoCode = 7;
        iPromo.PromoReason = 112;
        iPromo.PromoName = "   ** Manager Comp";
        iPromo.empID = actingManager.EmployeeID;
        iPromo.ItemPrice = compTktMgmtAdj.ManualTicket;
        iPromo.Price = compTktMgmtAdj.AdjPrice;
        iPromo.TaxPrice = compTktMgmtAdj.AdjTax;
        iPromo.SinTax = compTktMgmtAdj.AdjSinTax;

        // not sure of below
        iPromo.FunctionID = 0; // oRow("FunctionID")
        iPromo.FunctionGroup = 0; // oRow("FunctionGroupID")
        iPromo.FunctionFlag = "P"; // oRow("FunctionFlag")
        iPromo.CategoryID = 0; // oRow("CategoryID")
        iPromo.FoodID = 0; // oRow("FoodID")
        iPromo.DrinkCategoryID = 0; // oRow("DrinkCategoryID")
        iPromo.DrinkID = 0; // oRow("DrinkID")
        iPromo.RoutingID = 0; // oRow("RoutingID")
        iPromo.PrintPriorityID = 0; // oRow("PrintPriorityID")

        iPromo.ItemStatus = 7;
        iPromo.openOrderID = 0;
        // **************
        // 666
        // we have to do a loop here for each tax code 
        iPromo.taxID = ds.Tables("Tax").Rows(0)("TaxID");    // 0
        iPromo.sii = currentTable.SIN + 1;
        iPromo.si2 = 0;
        madeChanges = true;

        try
        {
            // sql.cn.Open()
            // sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery()
            CompThisItem(iPromo);
            foreach (SelectedItemDetail ni in newItemCollection)
                GenerateOrderTables.PopulateDataRowForOpenOrder(ni);
            newItemCollection.Clear();
            // sql.cn.Close()
            if (compTktMgmtAdj.ManualTicket == compTktMgmtAdj.CheckTicket)
            {
                // this means we are comping the entire check
                // otherwise we are not recording comps on the items
                foreach (DataRow currentORow in dsOrder.Tables("OpenOrders").Rows)
                {
                    oRow = currentORow;
                    if (oRow("ForceFreeID") == 0)
                    {
                        oRow("ForceFreeID") = iPromo.PromoCode * -1;

                    }
                }
            }
            else if (compTktMgmtAdj.AllFood == true)
            {
                if (compTktMgmtAdj.ManualTicket == compTktMgmtAdj.CheckFood)
                {
                    // **** Manual Ticket is Adjustment Amount
                    foreach (DataRow currentORow1 in dsOrder.Tables("OpenOrders").Rows)
                    {
                        oRow = currentORow1;
                        if (oRow("FunctionFlag") == "F" | oRow("FunctionFlag") == "O" | oRow("FunctionFlag") == "M")
                        {
                            if (oRow("ForceFreeID") == 0)
                            {
                                oRow("ForceFreeID") = iPromo.PromoCode * -1;

                            }
                        }
                    }
                }
            }

            else if (compTktMgmtAdj.AllDrinks == true)
            {
                if (compTktMgmtAdj.ManualTicket == compTktMgmtAdj.CheckDrinks)
                {
                    foreach (DataRow currentORow2 in dsOrder.Tables("OpenOrders").Rows)
                    {
                        oRow = currentORow2;
                        if (oRow("FunctionFlag") == "D")
                        {
                            if (oRow("ForceFreeID") == 0)
                            {
                                oRow("ForceFreeID") = iPromo.PromoCode * -1;

                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }

        compTktMgmtAdj.Dispose();
        pnlMgrCalculationArea.Visible = false;
        checkTotalsMgmtAdj.CalculatePriceAndTax(currentTable.CheckNumber);
        checkTotalsMgmtAdj.AttachTotalsToTotalView(currentTable.CheckNumber);

    }
    private void btnMgrAssignGratuity_Click(object sender, EventArgs e)
    {

        Interaction.MsgBox("Assign Gratuity in Close Check.");
        return;
        pnlMgrCalculationArea.BringToFront();

    }

    private void btnMgrPlaceOrder_Click(object sender, EventArgs e)
    {
        // time1 = Now

        // SaveOpenOrderData()
        currentTable.SIN += 1;

        if (isForReopen == true)
        {
            Interaction.MsgBox("Check must be open for this function.");
            return;
        }

        PlacingOrder?.Invoke();

    }

    private void btnMgrTransfer_Click(object sender, EventArgs e)
    {

        if (employeeAuthorization.OperationLevel < systemAuthorization.TransferCheck) // And employeeAuthorization.OperationLevel < systemAuthorization.TransferItem Then
        {
            Interaction.MsgBox(employeeAuthorization.FullName + " does not have Authorization");
            return;
        }
        if (isForReopen == true)
        {
            Interaction.MsgBox("Check must be open for this function.");
            return;
        }
        if (madeChanges == true)
        {
            Interaction.MsgBox("You Must ACCEPT changes before this action.");
            return;
        }

        int rowNum = checkTotalsMgmtAdj.grdCloseCheck.CurrentCell.RowNumber;

        try
        {
            _transSIN = (int)checkTotalsMgmtAdj.grdCloseCheck.Item(rowNum, 1);
            _transName = (string)checkTotalsMgmtAdj.grdCloseCheck.Item(rowNum, 3);
        }
        catch (Exception ex)
        {
            _transSIN = default;
            _transName = null;
            // Exit Sub
        }

        TransferingCheck?.Invoke();
        // Me.Dispose()

    }

    private void btnMgrTaxExempt_Click(object sender, EventArgs e)
    {

        pnlMgrCalculationArea.Visible = false;

        if (employeeAuthorization.OperationLevel < systemAuthorization.TaxExempt)
        {
            Interaction.MsgBox(employeeAuthorization.FullName + " does not have Authorization");
            return;
        }

        foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
        {
            if (oRow("CheckNumber") == currentTable.CheckNumber)
            {
                if (oRow("TaxID") > 0)
                {
                    oRow("TaxID") = -1;
                    oRow("TaxPrice") = 0; // DetermineTaxPrice(taxID, newitem.Price)
                    oRow("SinTax") = 0; // DetermineSinTax(taxID, newitem.Price)
                }
            }
        }

        checkTotalsMgmtAdj.CalculatePriceAndTax(currentTable.CheckNumber);
        checkTotalsMgmtAdj.AttachTotalsToTotalView(currentTable.CheckNumber);

        Interaction.MsgBox("Check Number " + currentTable.CheckNumber + " is now Tax Exempt. Select Cancel to re-add Tax.");

    }

    private void btnMgrReprintCredit_Click(object sender, EventArgs e)
    {

        // **************************
        // I need to add chioices for which credit card and if customer or restaurant copy

        if (employeeAuthorization.OperationLevel < systemAuthorization.ReprintCredit)
        {
            Interaction.MsgBox(employeeAuthorization.FullName + " does not have Authorization");
            return;
        }
        var prt = new PrintHelper();

        // we are doing all the credit card payments first
        foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                // If oRow("CheckNumber") = currentTable.CheckNumber Then
                // If oRow("PaymentAmount") <> 0 Then
                // If oRow("Applied") = False Then
                if (oRow("PaymentFlag") == "cc")
                {
                    // PrintCreditCardReceipt(oRow, Nothing, False)
                    prt.ccDataRow = oRow;
                    prt.ccDataRowView = (object)null;
                    prt.useVIEW = false;
                    prt.StartPrintCreditCardRest();
                    prt.StartPrintCreditCardGuest();
                }
            }
            // End If
            // End If
            // End If
        }

    }


}