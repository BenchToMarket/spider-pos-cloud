using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using DataSet_Builder;


public partial class term_OrderForm : System.Windows.Forms.UserControl
{

    // Friend currentTable As New DinnerTable

    // Private openCheck As Check

    // Private _dinnerTableCollection As New DinnerTableCollection
    // Private _checks As CheckCollection

    private SplitChecks ActiveSplit;      // form
    private SpecialFood _SpecialItem;

    private SpecialFood SpecialItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SpecialItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SpecialItem != null)
            {
                _SpecialItem.UC_Hit -= UserControlHit;
                _SpecialItem.CancelSpecial -= SpecialCancel_Click;
                _SpecialItem.AcceptSpecial -= SpecialInstructionsEntered;
            }

            _SpecialItem = value;
            if (_SpecialItem != null)
            {
                _SpecialItem.UC_Hit += UserControlHit;
                _SpecialItem.CancelSpecial += SpecialCancel_Click;
                _SpecialItem.AcceptSpecial += SpecialInstructionsEntered;
            }
        }
    }
    // 444   Dim WithEvents TabEnterScreen As Tab_Screen
    private TabSelection_UC _TabIdentifierScreen;

    private TabSelection_UC TabIdentifierScreen
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TabIdentifierScreen;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_TabIdentifierScreen != null)
            {
                _TabIdentifierScreen.TabIdentDispose -= StopTabMethod;
            }

            _TabIdentifierScreen = value;
            if (_TabIdentifierScreen != null)
            {
                _TabIdentifierScreen.TabIdentDispose += StopTabMethod;
            }
        }
    }
    private DataSet_Builder.Information_UC _cashPaymentDue;

    private DataSet_Builder.Information_UC cashPaymentDue
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cashPaymentDue;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cashPaymentDue != null)
            {
                _cashPaymentDue.AcceptInformation -= FastCashInfo_Accepted222;
                _cashPaymentDue.RejectInformation -= FastCashInfo_Rejected;
            }

            _cashPaymentDue = value;
            if (_cashPaymentDue != null)
            {
                _cashPaymentDue.AcceptInformation += FastCashInfo_Accepted222;
                _cashPaymentDue.RejectInformation += FastCashInfo_Rejected;
            }
        }
    }
    private LastOrder_UC _repeatOrderUserControl;

    private LastOrder_UC repeatOrderUserControl
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _repeatOrderUserControl;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_repeatOrderUserControl != null)
            {
                _repeatOrderUserControl.OrderDelivered -= AcceptOrderDelivered;
                _repeatOrderUserControl.AcceptRepeat -= AcceptRepeatOrder;
            }

            _repeatOrderUserControl = value;
            if (_repeatOrderUserControl != null)
            {
                _repeatOrderUserControl.OrderDelivered += AcceptOrderDelivered;
                _repeatOrderUserControl.AcceptRepeat += AcceptRepeatOrder;
            }
        }
    }
    private ModifyOrder_UC _modifyOrderUserControl;

    private ModifyOrder_UC modifyOrderUserControl
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _modifyOrderUserControl;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_modifyOrderUserControl != null)
            {
                _modifyOrderUserControl.AddingItemToOrder -= EventForAddingItem;
                _modifyOrderUserControl.AcceptModifySubTotal -= UpdateModifiedSubTotal;
                _modifyOrderUserControl.AcceptModify -= UpdateModifiedItem;
                _modifyOrderUserControl.CancelModify -= CancelModifiedItem;
            }

            _modifyOrderUserControl = value;
            if (_modifyOrderUserControl != null)
            {
                _modifyOrderUserControl.AddingItemToOrder += EventForAddingItem;
                _modifyOrderUserControl.AcceptModifySubTotal += UpdateModifiedSubTotal;
                _modifyOrderUserControl.AcceptModify += UpdateModifiedItem;
                _modifyOrderUserControl.CancelModify += CancelModifiedItem;
            }
        }
    }
    private DataSet_Builder.Information_UC _info;

    private DataSet_Builder.Information_UC info
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _info;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _info = value;
        }
    }
    private DataSet_Builder.NumberOfCustomers_UC _changeNumberOfCustomers;

    private DataSet_Builder.NumberOfCustomers_UC changeNumberOfCustomers
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _changeNumberOfCustomers;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_changeNumberOfCustomers != null)
            {
                _changeNumberOfCustomers.NumberCustomerEntered -= NumberOfCustomersSelected;
            }

            _changeNumberOfCustomers = value;
            if (_changeNumberOfCustomers != null)
            {
                _changeNumberOfCustomers.NumberCustomerEntered += NumberOfCustomersSelected;
            }
        }
    }
    private ExtraNo_UC _extraNoUserControl;

    private ExtraNo_UC extraNoUserControl
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _extraNoUserControl;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_extraNoUserControl != null)
            {
                _extraNoUserControl.AddingItemToOrder -= EventForAddingItem;
                _extraNoUserControl.SelectedClose -= ClosingExtraNo;
            }

            _extraNoUserControl = value;
            if (_extraNoUserControl != null)
            {
                _extraNoUserControl.AddingItemToOrder += EventForAddingItem;
                _extraNoUserControl.SelectedClose += ClosingExtraNo;
            }
        }
    }
    private DemoInformation_UC _demoHelp;

    private DemoInformation_UC demoHelp
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _demoHelp;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_demoHelp != null)
            {
                _demoHelp.DisableDemoHelp -= DisableDemoHelp_Selected;
            }

            _demoHelp = value;
            if (_demoHelp != null)
            {
                _demoHelp.DisableDemoHelp += DisableDemoHelp_Selected;
            }
        }
    }
    private DrinkPrep_UC drinkPrep;
    internal Seating_EnterTab SeatingTab;

    // Private sql As New DataSet_Builder.SQLHelper(connectserver)
    // Private prt As New PrintHelper

    private Timer tabDoubleClickTimer;
    private bool tabTimerActive;


    // ***********************************************************
    // Defines the names, and values which will determine location
    // and size of all panels
    // ***********************************************************


    // ************************************************************************
    // For both Main and MainModifier Panels
    // (allow user to choose initial foods and modifiers)
    // ************************************************************************

    // Define both main and mainModifer panels
    internal Panel pnlMain;
    internal Panel pnlMain2;
    internal Panel pnlMain3;
    private bool pastFirstCategory = false;
    private OrderButton firstCategory = new OrderButton("10");

    // ********************************************************************************
    // For Both Order Panel and OrderModifier Panel
    // ********************************************************************************

    internal Panel pnlOrder;
    internal Panel pnlOrderQuick;
    internal Panel pnlOrderDrink;
    internal Panel pnlOrderModifier;
    internal Panel pnlOrderModifierExt;
    internal Panel pnlDescription;

    private double panelButtonWidth;
    private double panelButtonHeight;

    // position and size of Order Panel (op)
    private double opLocationX = ssX * 0.32d;
    private double opLocationY = ssY * 0.01d;
    private double opWidth = ssX * 0.54d; // .50
    private double opHeight = ssY * 0.76d; // .80

    private double opButtonWidth;
    private double opButtonHeight;     // mathmatically should be 9
    private double drinkButtonWidth; // (opHeight - (13 * buttonSpace)) / 12
    private double drinkButtonHeight; // (opHeight - (13 * buttonSpace)) / 12

    // position and size of modifier panel (mp)
    private double mpLocationX = ssX * 0.45d;  // 0.38
    private double mpLocationY = ssY * 0.18d;   // 0.31
    private double mpWidth = ssX * 0.42d;
    private double mpHeight = ssY * 0.59d;
    private double mpButtonWidth;
    private double mpButtonHeight;

    // Buttons for the order(op) and modifier(mp) panel
    private OrderButton[] btnMain = new OrderButton[21];
    private OrderButton[] btnModifier = new OrderButton[11];
    private OrderButton _btnMainNext;

    private OrderButton btnMainNext
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMainNext;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMainNext != null)
            {
                _btnMainNext.Click -= NextButton;
            }

            _btnMainNext = value;
            if (_btnMainNext != null)
            {
                _btnMainNext.Click += NextButton;
            }
        }
    }
    private OrderButton _btnMainNextMain3;

    private OrderButton btnMainNextMain3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMainNextMain3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMainNextMain3 != null)
            {
                _btnMainNextMain3.Click -= NextButtonMain3;
            }

            _btnMainNextMain3 = value;
            if (_btnMainNextMain3 != null)
            {
                _btnMainNextMain3.Click += NextButtonMain3;
            }
        }
    }
    private OrderButton _btnMainPrevious;

    private OrderButton btnMainPrevious
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMainPrevious;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMainPrevious != null)
            {
                _btnMainPrevious.Click -= PreviousButton;
            }

            _btnMainPrevious = value;
            if (_btnMainPrevious != null)
            {
                _btnMainPrevious.Click += PreviousButton;
            }
        }
    }
    // Private btnModifier() As OrderButton        'do not use any more
    private OrderButton[] btnOrder = new OrderButton[33];
    private OrderButton[] btnOrderQuick = new OrderButton[61];
    private OrderButton[] btnOrderDrink = new OrderButton[61];
    private OrderButton[] btnOrderModifier = new OrderButton[61];         // changed from 24
    private OrderButton[] btnOrderModifierExt = new OrderButton[61];
    private OrderButton btnOrderModifierCancel;

    private string[] opButtonText;
    private int[] opButtonId;
    private Color[] opButtonBackColor;
    private Color[] opButtonForeColor;
    private int[] opButtonCategoryID;
    private bool[] opButtonHalfSplit;
    private int[] opButtonFunctionID;
    private int[] opButtonFunctionGroupID;
    private string[] opButtonFunFlag;
    private bool[] opButtonDrinkSubCat;
    internal bool tabIdentifierDisplaying;
    public bool tabScreenDisplaying;

    // *****************************************************************
    // Current Order View with totals and kitchen commands
    // *****************************************************************
    // Private WithEvents viewOrder As New ListView 'CurrentOrderView

    private OrderGridView _testgridview;

    private OrderGridView testgridview
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _testgridview;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_testgridview != null)
            {
                _testgridview.UC_Hit -= UserControlHit;
                _testgridview.NewQuickServiceOrder -= StartNewQuickService;
                _testgridview.CloseFast -= FastCashClose;
                _testgridview.UpdatingViewsByCheck -= UpdateDataViewsByCheck;
                _testgridview.ChangeCustomerEvent -= AttemptToChangeCustomer;
                _testgridview.ChangeCustColor -= ChangeCustomerButtonColor;
                _testgridview.DrinkButtonsON -= ChangeToDrinkButtons;
                _testgridview.DrinkButtonsOFF -= ChangeFromDrinkButtons;
                _testgridview.EndingItem -= EndOfItem;
                _testgridview.RunPizzaRoutine -= PizzaRoutine;
                _testgridview.DeliverStart -= StartDeliveryMethod;
                _testgridview.DineInStart -= StartDineInMethod;
                _testgridview.SendOrder -= SendOrderButton_Click;
                _testgridview.ModifyItem -= btnModifyClick;
                _testgridview.LeaveOrderView -= Leave_Click;
                _testgridview.ClearPanels -= ClearOrderPanels;
                _testgridview.ClearControls -= ClearingControls;
                _testgridview.ResetPizzaRoutine -= ResetPizzaControls;
                _testgridview.OnFullPizza -= FullPizza_Clicked;
                _testgridview.CloseCheck -= checkNumberButton_Click;
                _testgridview.DisplayInfo -= DisplayingMessage;
            }

            _testgridview = value;
            if (_testgridview != null)
            {
                _testgridview.UC_Hit += UserControlHit;
                _testgridview.NewQuickServiceOrder += StartNewQuickService;
                _testgridview.CloseFast += FastCashClose;
                _testgridview.UpdatingViewsByCheck += UpdateDataViewsByCheck;
                _testgridview.ChangeCustomerEvent += AttemptToChangeCustomer;
                _testgridview.ChangeCustColor += ChangeCustomerButtonColor;
                _testgridview.DrinkButtonsON += ChangeToDrinkButtons;
                _testgridview.DrinkButtonsOFF += ChangeFromDrinkButtons;
                _testgridview.EndingItem += EndOfItem;
                _testgridview.RunPizzaRoutine += PizzaRoutine;
                _testgridview.DeliverStart += StartDeliveryMethod;
                _testgridview.DineInStart += StartDineInMethod;
                _testgridview.SendOrder += SendOrderButton_Click;
                _testgridview.ModifyItem += btnModifyClick;
                _testgridview.LeaveOrderView += Leave_Click;
                _testgridview.ClearPanels += ClearOrderPanels;
                _testgridview.ClearControls += ClearingControls;
                _testgridview.ResetPizzaRoutine += ResetPizzaControls;
                _testgridview.OnFullPizza += FullPizza_Clicked;
                _testgridview.CloseCheck += checkNumberButton_Click;
                _testgridview.DisplayInfo += DisplayingMessage;
            }
        }
    }

    // Friend WithEvents tableStatusView As New ListView
    // Friend WithEvents byServerView As New ListView

    // descriptions of all status categories
    internal string[] statusName = new string[11];

    private Panel pnlMainModifier = new Panel();
    private KitchenButton _btnModifierNo;

    private KitchenButton btnModifierNo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnModifierNo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnModifierNo != null)
            {
                _btnModifierNo.Click -= BtnModifierNo_Click;
            }

            _btnModifierNo = value;
            if (_btnModifierNo != null)
            {
                _btnModifierNo.Click += BtnModifierNo_Click;
            }
        }
    }
    private KitchenButton _btnModifierAdd;

    private KitchenButton btnModifierAdd
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnModifierAdd;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnModifierAdd != null)
            {
                _btnModifierAdd.Click -= BtnModifierAdd_Click;
            }

            _btnModifierAdd = value;
            if (_btnModifierAdd != null)
            {
                _btnModifierAdd.Click += BtnModifierAdd_Click;
            }
        }
    }
    private KitchenButton _btnModifierExtra;

    private KitchenButton btnModifierExtra
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnModifierExtra;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnModifierExtra != null)
            {
                _btnModifierExtra.Click -= BtnModifierNo_Click;
            }

            _btnModifierExtra = value;
            if (_btnModifierExtra != null)
            {
                _btnModifierExtra.Click += BtnModifierNo_Click;
            }
        }
    }
    private KitchenButton _btnModifierOnFly;

    private KitchenButton btnModifierOnFly
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnModifierOnFly;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnModifierOnFly != null)
            {
                _btnModifierOnFly.Click -= BtnModifierOnFly_Click;
            }

            _btnModifierOnFly = value;
            if (_btnModifierOnFly != null)
            {
                _btnModifierOnFly.Click += BtnModifierOnFly_Click;
            }
        }
    }
    private KitchenButton _btnModifierNoMake;

    private KitchenButton btnModifierNoMake
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnModifierNoMake;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnModifierNoMake != null)
            {
                _btnModifierNoMake.Click -= BtnModifierNoMake_Click;
            }

            _btnModifierNoMake = value;
            if (_btnModifierNoMake != null)
            {
                _btnModifierNoMake.Click += BtnModifierNoMake_Click;
            }
        }
    }
    private KitchenButton _btnModifierOnSide;

    private KitchenButton btnModifierOnSide
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnModifierOnSide;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnModifierOnSide != null)
            {
                _btnModifierOnSide.Click -= BtnModifierOnSide_Click;
            }

            _btnModifierOnSide = value;
            if (_btnModifierOnSide != null)
            {
                _btnModifierOnSide.Click += BtnModifierOnSide_Click;
            }
        }
    }
    private KitchenButton _btnModifierNoCharge;

    private KitchenButton btnModifierNoCharge
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnModifierNoCharge;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnModifierNoCharge != null)
            {
                _btnModifierNoCharge.Click -= BtnModifierNoCharge_Click;
            }

            _btnModifierNoCharge = value;
            if (_btnModifierNoCharge != null)
            {
                _btnModifierNoCharge.Click += BtnModifierNoCharge_Click;
            }
        }
    }
    private KitchenButton _btnModifierSpecial;

    private KitchenButton btnModifierSpecial
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnModifierSpecial;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnModifierSpecial != null)
            {
                _btnModifierSpecial.Click -= BtnModifierSpecial_Click;
            }

            _btnModifierSpecial = value;
            if (_btnModifierSpecial != null)
            {
                _btnModifierSpecial.Click += BtnModifierSpecial_Click;
            }
        }
    }
    private KitchenButton _btnModifierRepeat;

    private KitchenButton btnModifierRepeat
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnModifierRepeat;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnModifierRepeat != null)
            {
                _btnModifierRepeat.Click -= BtnModifierRepeat_Click;
            }

            _btnModifierRepeat = value;
            if (_btnModifierRepeat != null)
            {
                _btnModifierRepeat.Click += BtnModifierRepeat_Click;
            }
        }
    }
    private KitchenButton btnModifierBlank;
    private DataSet_Builder.KeyBoard_UC specialKeyboard;
    private bool ADDorNOmode;

    private int panelModLocationY;


    // Table Information Panel
    private Panel pnlTableInfo = new Panel();
    private Button btnTableInfoMenu;
    private Button btnTableInfoServerNumber;
    private Button btnTableInfoTableNumber;
    private Button btnTableInfoNumberOfCustomers;
    private bool tableMethodChanged = false;
    internal bool wasPickupMethod;

    private Panel _customerPanel;

    private Panel customerPanel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _customerPanel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_customerPanel != null)
            {
                _customerPanel.Click -= CustomerButton_Click;
            }

            _customerPanel = value;
            if (_customerPanel != null)
            {
                _customerPanel.Click += CustomerButton_Click;
            }
        }
    }
    private KitchenButton[] btnCustomer = new KitchenButton[10];
    private KitchenButton _btnCustomerNext;

    private KitchenButton btnCustomerNext
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCustomerNext;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _btnCustomerNext = value;
        }
    }
    // Dim currenttable.markForNewCustomerPanel As Boolean
    // Dim currenttable.markForNextCustomer As Boolean

    // Friend WithEvents pnlDrinkModifier As New Panel
    // Friend WithEvents drinkTall As Button
    // Friend WithEvents drinkDouble As Button
    // Friend WithEvents drinkRocks As Button
    // Friend WithEvents drinkSplash As Button
    // Friend WithEvents drinkCall As Button
    // Friend WithEvents drinkUp As Button

    internal Panel pnlWineParring;
    private Label _lblWineParring;

    internal virtual Label lblWineParring
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblWineParring;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblWineParring != null)
            {
                _lblWineParring.Click -= WineParring_WineClicked;
            }

            _lblWineParring = value;
            if (_lblWineParring != null)
            {
                _lblWineParring.Click += WineParring_WineClicked;
            }
        }
    }
    private Label _lblRecipe;

    internal virtual Label lblRecipe
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblRecipe;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblRecipe != null)
            {
                _lblRecipe.Click -= WineParring_RecipeClicked;
            }

            _lblRecipe = value;
            if (_lblRecipe != null)
            {
                _lblRecipe.Click += WineParring_RecipeClicked;
            }
        }
    }

    internal Panel pnlPizzaSplit;
    internal Panel pnlOnFullPizza = new Panel();
    internal Panel pnlOnFirstHalf = new Panel();
    internal Panel pnlOnSecondHalf = new Panel();
    internal ListBox onFullPizza;
    internal ListBox onFirstHalf;
    internal ListBox onSecondHalf;


    // Friend numberFree(15) As Integer
    internal bool[] freeFood = new bool[24];
    internal bool freeFoodActive;
    internal int modifierIndex;
    internal bool[] categoryIndex;
    internal int GTCIndex = -1;
    private bool isSecondLoop;
    private bool onlyHalf;

    private bool performedIndividualJoinTest;
    private int cntModifierLoop;
    private int previousCategory;
    internal int modifierIndexSecondLoop;
    internal bool[] categoryIndexSecondLoop;

    internal bool _IsBartenderMode;
    internal bool _isManagerMode;
    internal DataSet_Builder.Payment TabAccountInfo = new DataSet_Builder.Payment();

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

    internal bool IsManagerMode
    {
        get
        {
            return _isManagerMode;
        }
        set
        {
            _isManagerMode = value;
        }
    }



    // Dim currentTableList As New ArrayList
    // Event DisposeTableScreen(ByVal sender As Object, ByVal e As System.EventArgs)
    public event TermOrder_DisposingEventHandler TermOrder_Disposing;

    public delegate void TermOrder_DisposingEventHandler(Employee emp, ref CashClose_UC ccDisplay);
    public event QuickOrder_NotDisposingEventHandler QuickOrder_NotDisposing;

    public delegate void QuickOrder_NotDisposingEventHandler();
    public event ClosingCheckEventHandler ClosingCheck;

    public delegate void ClosingCheckEventHandler();
    public event ClosingCheckExitEventHandler ClosingCheckExit;

    public delegate void ClosingCheckExitEventHandler();
    public event FireTabScreenEventHandler FireTabScreen;

    public delegate void FireTabScreenEventHandler(string startInSearch, string searchCriteria);
    public event TestForCurrentTabInfoEventHandler TestForCurrentTabInfo;

    public delegate void TestForCurrentTabInfoEventHandler();
    public event TabScreenDisposingEventHandler TabScreenDisposing;

    public delegate void TabScreenDisposingEventHandler();
    public event FireSeatingTabEventHandler FireSeatingTab;

    public delegate void FireSeatingTabEventHandler(string startedFrom, string tn); // As Boolean)
    public event CloseFastCashEventHandler CloseFastCash;

    public delegate void CloseFastCashEventHandler();

    // Friend orderInactiveTimer As System.Windows.Forms.Timer
    private int orderTimeoutCounter = 1;



    #region  Windows Form Designer generated code 

    // (ByVal cm As Integer, ByVal empID As Integer, ByVal IsTab As Boolean, ByVal tn As Integer, ByVal tabName As String, ByVal expNum As Integer, ByVal numChecks As Integer, ByVal numCust As Integer, ByVal barMode As Boolean, ByVal tktNum As Integer, ByVal ls As Integer)
    public term_OrderForm(bool barMode, bool managerMode, DataSet_Builder.Payment _tabAccountInfo) : base()
    {
        drinkPrep = new DrinkPrep_UC();
        pnlMain = new Panel();
        pnlMain2 = new Panel();
        pnlMain3 = new Panel();
        pnlOrder = new Panel();
        pnlOrderQuick = new Panel();
        pnlOrderDrink = new Panel();
        pnlOrderModifier = new Panel();
        pnlOrderModifierExt = new Panel();
        pnlDescription = new Panel();
        opButtonWidth = (opWidth - 5 * buttonSpace) / 4;
        opButtonHeight = (opHeight - 9 * buttonSpace) / 8;
        drinkButtonWidth = (opWidth - 7 * buttonSpace) / 6;
        drinkButtonHeight = (opHeight - 12 * buttonSpace) / 10;
        mpButtonWidth = (mpWidth - 5 * buttonSpace) / 4;
        mpButtonHeight = (mpHeight - 8 * buttonSpace) / 7;
        btnTableInfoMenu = new Button();
        btnTableInfoServerNumber = new Button();
        btnTableInfoTableNumber = new Button();
        btnTableInfoNumberOfCustomers = new Button();
        pnlWineParring = new Panel();
        pnlPizzaSplit = new Panel();
        onFullPizza = new ListBox();    // DataGrid
        onFirstHalf = new ListBox(); // DataGrid
        onSecondHalf = new ListBox();   // DataGrid

        // moved to 2nd step
        // If currentTerminal.CurrentDailyCode = 0 Then
        // MsgBox("No Daily Business Day Active. Please See Manager.")
        // Me.Dispose()
        // End If

        _IsBartenderMode = barMode;
        _isManagerMode = managerMode;
        TabAccountInfo = _tabAccountInfo;

        // inBarMode = barMode

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        InitializeOther();
        pnlMain.Click += Foods;
        pnlMain2.Click += Foods;
        pnlMain3.Click += ModifierClick222;
        drinkPrep.Cancel += CancelDrinkAdds;
        drinkPrep.AcceptPrep += DrinkPrepOrdered;
        btnTableInfoTableNumber.Click += ButtonTableNumber_Click;
        SeatingTab.CancelNewTab += CancelNewTab;
        btnTableInfoMenu.Click += ButtonMenu_Click;
        btnTableInfoNumberOfCustomers.Click += ButtonNumberOfCustomers_Click;
        onFullPizza.Click += FullPizza_Clicked;
        onFirstHalf.Click += FirstHalfPizza_Clicked;
        onSecondHalf.Click += SecondHalfPizza_Clicked;

        // time2 = Now
        // timeDiff = time2.Subtract(time1)
        // MsgBox(timeDiff.ToString)

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


    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        // 
        // term_OrderForm
        // 
        this.Name = "term_OrderForm";
        this.Size = new System.Drawing.Size(1024, 768);

    }

    #endregion

    private void InitializeOther()
    {

        orderTimeoutCounter = 1;
        // orderInactiveTimer = New Timer
        orderInactiveTimer.Interval = timeoutInterval;

        if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
        {
            orderInactiveTimer.Tick += OrderInactiveScreenTimeout;
            orderInactiveTimer.Start();
        }
        // ResetTimer()

        ReformatControls();
        CreateFormView();

        testgridview = new OrderGridView();
        if (currentServer.Lefty == false)
        {
            testgridview.Location = new Point(buttonSpace, buttonSpace);
        }
        else
        {
            testgridview.Location = new Point(this.Width - buttonSpace - 312, buttonSpace);
        }
        this.Controls.Add(testgridview);
        testgridview.BringToFront();

        // this UC is different, we are only making once
        extraNoUserControl = new ExtraNo_UC();
        extraNoUserControl.Location = new Point(opLocationX + 20d, opLocationY + 70d);
        this.Controls.Add(extraNoUserControl);
        extraNoUserControl.Visible = false;

        DisplayCustomerPanel();

        // CreateCourseButtonPanel()

        CreateMainModifierPanel();

        CreateTableInfoPanel();

        CreateDrinkModifierPanel();

        // *****************************************************************************
        // Populates Buttons from Database for Order Process
        // *****************************************************************************

        CreateMainButtonArray((int)Math.Round(panelButtonWidth), (int)Math.Round(panelButtonHeight));

        // If Not currentTerminal.TermMethod = "Quick" Then



        CreateOrderButtonArray();
        CreateOrderButtonQuick();
        CreateOrderDrinkButtonArray();
        CreateOrderModifierButtonArray();
        CreateOrderModifierExtendedButtonArray();


        // If currentTerminal.TermMethod = "Quick" Then
        // so we won't get error below
        // 444     TabEnterScreen = New Tab_Screen() '"Phone")
        // TabEnterScreen.Location = New Point(((Me.Width - TabEnterScreen.Width - 10) / 2), ((Me.Height - TabEnterScreen.Height) / 2))
        // Me.Controls.Add(TabEnterScreen)
        // TabEnterScreen.Visible = False
        // tabIdentifierDisplaying = False

        InitializeScreenSecondStep();


        if (typeProgram == "Online_Demo" & acitveDemo == true)
        {
            string s1 = "CLOSE CHECK - Hit the yellow button below check detail";
            string s2;
            string s3;

            if (!(currentTerminal.TermMethod == "Quick") & !(currentTerminal.TermMethod == "Bar"))
            {
                s2 = "SELECT COURSE - Hit buttons (1 to 4) below check detail";
                s3 = "SELECT CUSTOMER - Hit buttons (1 to 5) below this panel";
            }
            else
            {
                s2 = "SELECT QUANTITY - Hit buttons (1 to 4) below check detail.              couse buttons will display for non Bar terminals";
                if (currentTerminal.TermMethod == "Bar")
                {
                    s3 = "SELECT CUSTOMER - Hit buttons (1 to 5) below this panel";
                }
                else
                {
                    s3 = "";
                }
            }
            demoHelp = new DemoInformation_UC(s1, s2, s3, "", "", true);
            demoHelp.Location = new Point((this.Width - demoHelp.Width) / 2, (this.Height - demoHelp.Height) / 2);
            this.Controls.Add(demoHelp);
            demoHelp.BringToFront();
        }

    }

    internal void InitializeScreenSecondStep()
    {

        if (currentTerminal.CurrentDailyCode == 0)
        {
            Interaction.MsgBox("No Daily Business Day Active. Please See Manager.");
            // Me.Visible ???? then exit
            this.Dispose();
        }

        freeFoodActive = false;
        modifierIndex = Conversions.ToInteger(false);
        isSecondLoop = false;
        onlyHalf = false;
        tableMethodChanged = false;
        performedIndividualJoinTest = false;

        tabScreenDisplaying = false;
        tabIdentifierDisplaying = false;
        tabTimerActive = false;
        pnlMain2.Visible = false;
        pnlMain3.Visible = false;

        PutUsInNormalMode();

        // pnlMain.Visible = True
        // drinkPrep.Visible = False
        // pnlOrderModifier.Visible = False
        // pnlOrderModifierExt.Visible = False
        // pnlPizzaSplit.Visible = False
        // pnlWineParring.Visible = True
        // GTCIndex = -1
        // pnlOrderDrink.Visible = False
        // ADDorNOmode = False
        // ChangeFromDrinkButtons()

        if (currentTable.MethodUse == "Pickup")
        {
            wasPickupMethod = true;
        }
        else
        {
            wasPickupMethod = false;
        }
        // when go to visible, we need to move this to second step
        if (!(currentTable.TabID == -888) & !(currentTerminal.TermMethod == "Quick")) // And Not IsBartenderMode = True 
        {
            FirstStepOrdersPending();
        }
        else
        {
            // 444 moved RunFoodsRoutine option below
        }

        // added below for Visible
        if (!(currentTerminal.TermMethod == "Quick"))
        {
            btnModifierExtra.Visible = false;
            btnModifierBlank.Visible = false;
            btnModifierRepeat.Visible = true;
            btnModifierOnFly.Visible = true;
            btnModifierNoMake.Visible = true;
            btnModifierNoCharge.Visible = true;
        }
        else
        {
            btnModifierRepeat.Visible = false;
            btnModifierOnFly.Visible = false;
            btnModifierNoMake.Visible = false;
            btnModifierNoCharge.Visible = false;

            btnModifierExtra.Visible = true;
            btnModifierBlank.Visible = true;
        }

        // 444    UpdateTableInfo()
        PopulateMainButtons();
        ReInitializeOrderView();
        ResetCustomerAndCourseButtons();

        if (pastFirstCategory == true)
        {
            int index;
            for (index = 1; index <= 10; index++)
            {
                if (btnMain[index].CategoryID > 0)
                {
                    RunFoodsRoutine(btnMain[index]);
                    break;
                }
            }
        }
        UpdateTableInfo();
        if (currentTable.CurrentMenu == currentTerminal.currentPrimaryMenuID)
        {
            btnTableInfoMenu.BackColor = c2;
            btnTableInfoMenu.ForeColor = c3;
        }
        else
        {
            btnTableInfoMenu.BackColor = c3;
            btnTableInfoMenu.ForeColor = c2;
        }
        // currentTerminal.CurrentMenuID = tempSecondaryMenuID
        // currentTable.CurrentMenu = tempSecondaryMenuID

    }

    internal void ReinitializeOrderScreen222()
    {

        UpdateTableInfo();
        testgridview.CalculateSubTotal();

    }

    private void DisableDemoHelp_Selected()
    {
        acitveDemo = false;
    }

    private void FirstStepOrdersPending()
    {
        long lastOrderNumber;

        lastOrderNumber = Conversions.ToLong(CheckForOpenOrderDetail());

        if (lastOrderNumber > 0L)
        {
            FillRepeatOrderDataTable(lastOrderNumber);
            DisplayRepeatOrder(false);
            repeatOrderUserControl.OrderNumber = lastOrderNumber;
        }
        else
        {
            // If Not TabAccountInfo.LastName Is Nothing Then
            // If TabAccountInfo.LastName.Length > 0 Then
            // StartNewCustomerTab()
            // End If
            // End If
        }

    }

    private void UserControlHit()
    {

        ResetTimer();

    }

    private void ResetTimer()
    {

        orderTimeoutCounter = 1;

        // orderInactiveTimer.Dispose()
        // Me.orderInactiveTimer.Stop()
        // orderInactiveTimer = New Timer
        // '      AddHandler orderInactiveTimer.Tick, AddressOf OrderInactiveScreenTimeout

        // orderInactiveTimer.Interval = timeoutInterval
        // orderInactiveTimer.Start()

        // orderInactiveTimer.Start()

    }
    private void OrderInactiveScreenTimeout(object sender, EventArgs e)
    {

        return;

        orderTimeoutCounter += 1;

        // If orderTimeoutCounter = 2 Or orderTimeoutCounter > 7 Then
        // MsgBox(orderTimeoutCounter)
        // End If

        if (orderTimeoutCounter == companyInfo.timeoutMultiplier)
        {
            CashClose_UC argccDisplay = null;
            LeaveAndSave(ccDisplay: ref argccDisplay);
        }

    }

    private void ReformatControls()
    {

        // uc      Me.ClientSize = New Size(ssX, ssY)
        // uc    Me.FormBorderStyle = FormBorderStyle.None

        // defines location of main panel (and modifier relative to main)
        int panelLocationX = ssX * 0.88d;
        int panelLocationY = ssY * 0.03d;
        // DEFINES WIDTHS (percentage of screen)
        int mainPanelWidth = ssX * 0.1d;
        int mainPanelHeight = ssY * 0.72d;
        panelButtonWidth = mainPanelWidth - 2 * buttonSpace;
        panelButtonHeight = (mainPanelHeight - 12 * buttonSpace) / 11;


        // position and size of description panel
        double dpLocationX = ssX * 0.4d;
        double dpLocationY = ssY * 0.01d;
        double dpWidth = ssX * 0.3d;
        double dpHeight = ssY * 0.2d;

        // position and size of adjustment panel
        double apLocationX = ssX * 0.31d;
        double apLocationY = ssY * 0.35d;
        double apWidth = ssX * 0.44d;
        double apHeight = ssY * 0.5d;

        if (currentServer.Lefty == true)
        {
            panelLocationX = ssX * 0.02d;
            opLocationX = ssX * 0.13d;
            mpLocationX = ssX * 0.25d;
            dpLocationX = ssX * 0.2d + 2 * buttonSpace;

        }

        // ***************************************************************************
        // Assigns location and size of panels
        // ***************************************************************************

        // Main and MainModifier Panels
        // places the first button inside the panel one space right(pmslX) and down(pmslY)
        // then each one is moved down by a space and a button size(pmbsY)
        pnlMain.Location = new System.Drawing.Point(panelLocationX, panelLocationY);
        pnlMain2.Location = new System.Drawing.Point(panelLocationX, panelLocationY);
        pnlMain3.Location = new System.Drawing.Point(panelLocationX, panelLocationY);
        pnlMain.Size = new System.Drawing.Size(mainPanelWidth, mainPanelHeight);
        pnlMain2.Size = new System.Drawing.Size(mainPanelWidth, mainPanelHeight);
        pnlMain3.Size = new System.Drawing.Size(mainPanelWidth, mainPanelHeight);
        pnlMain.BorderStyle = BorderStyle.FixedSingle;
        pnlMain2.BorderStyle = BorderStyle.FixedSingle;
        pnlMain3.BorderStyle = BorderStyle.FixedSingle;
        // Me.pnlMain.BackColor = c8   'BackColor.PowderBlue
        // Me.pnlMain2.BackColor = c8  'BackColor.PowderBlue
        // Me.pnlMain3.BackColor = c8  'BackColor.PowderBlue
        panelModLocationY = panelLocationY + mainPanelHeight + 2 * buttonSpace;


        // Order and OrderModifier Panels
        pnlOrder.Location = new Point(opLocationX, opLocationY);
        pnlOrderQuick.Location = new Point(opLocationX, opLocationY);
        if (!(currentTerminal.TermMethod == "Quick"))
        {
            pnlOrder.Size = new Size(opWidth, opHeight);
            pnlOrderQuick.Size = new Size(opWidth, opHeight);
        }
        else
        {
            pnlOrder.Size = new Size(opWidth, opHeight);
            pnlOrderQuick.Size = new Size(opWidth, opHeight);
        } // + 47)

        pnlOrder.BorderStyle = BorderStyle.FixedSingle;
        pnlOrderQuick.BorderStyle = BorderStyle.FixedSingle;
        // Me.pnlOrder.BackColor = c5
        pnlOrderDrink.Location = new Point(opLocationX, opLocationY);
        pnlOrderDrink.Size = new Size(opWidth, opHeight);
        pnlOrderDrink.BorderStyle = BorderStyle.FixedSingle;
        // Me.pnlOrderDrink.BackColor = c5

        drinkPrep.Location = new Point(opLocationX, opLocationY);
        // Me.pnlOrderDrink.Size = New Size(opWidth, opHeight)
        // Me.pnlOrderDrink.BorderStyle = BorderStyle.FixedSingle

        pnlOrderModifier.Location = new Point(mpLocationX, mpLocationY);
        pnlOrderModifier.Size = new Size(mpWidth, mpHeight);
        pnlOrderModifier.BorderStyle = BorderStyle.FixedSingle;

        pnlOrderModifierExt.Location = new Point(opLocationX, opLocationY);
        pnlOrderModifierExt.Size = new Size(opWidth, opHeight);
        pnlOrderModifierExt.BorderStyle = BorderStyle.FixedSingle;

        // Description Panel
        // ****    ???????????????????
        pnlDescription.Location = new Point(dpLocationX, dpLocationY);
        pnlDescription.Size = new Size(dpWidth, dpHeight);
        pnlDescription.Visible = false;
        // Me.pnlDescription.BackColor = Color.PaleTurquoise
        // Me.pnlDescription.BorderStyle = BorderStyle.FixedSingle
        pnlDescription.Text = "Description";

    }

    private void CreateFormView()
    {

        // 
        // OrderForm
        // 
        this.Controls.Add(pnlDescription);
        this.Controls.Add(pnlOrderModifier);
        this.Controls.Add(pnlOrderModifierExt);
        this.Controls.Add(pnlOrderDrink);
        this.Controls.Add(drinkPrep);
        this.Controls.Add(pnlOrder);
        this.Controls.Add(pnlOrderQuick);
        this.Controls.Add(pnlMainModifier);
        this.Controls.Add(pnlMain);
        this.Controls.Add(pnlMain2);
        this.Controls.Add(pnlMain3);
        pnlMain2.Visible = false;
        pnlMain3.Visible = false;

        pnlOrder.Visible = false;
        pnlOrderQuick.Visible = false;
        pnlOrderDrink.Visible = false;
        drinkPrep.Visible = false;
        pnlOrderModifier.Visible = false;
        pnlOrderModifierExt.Visible = false;
        // Me.pnlDrinkModifier.Visible = False
        this.BackColor = c2; // c12
        this.Text = "Active Table: ";

        // Me.Controls.Add(Me.pnlDrinkModifier)
        this.Controls.Add(pnlWineParring);
        this.Controls.Add(pnlTableInfo);
        this.Controls.Add(pnlPizzaSplit);

    }

    internal void ReInitializeOrderView()
    {

        testgridview.InitializeViewSecondStep();
        testgridview.gridViewOrder.DataSource = dvOrder;
        currentTable.OrderView = "Detail";

    }

    private void ResetCustomerAndCourseButtons()
    {

        int index;

        for (index = 2; index <= 5; index++)
            btnCustomer[index].BackColor = c7;
        currentTable.MarkForNewCustomerPanel = false;
        currentTable.MarkForNextCustomer = false;
        currentTable.CustomerNumber = 1;
        currentTable.NextCustomerNumber = 1;
        currentTable.CourseNumber = 2;
        currentTable.Quantity = 1;

        ChangeCustomerButtonColor(c9);

        if (!(currentTerminal.TermMethod == "Quick") & !(currentTerminal.TermMethod == "Bar"))
        {
            testgridview.ChangeCourseButton(currentTable.CourseNumber);
        }
        else
        {
            testgridview.ChangeCourseButton(currentTable.Quantity);
        }

    }

    private void StartNewQuickService(long expNum)
    {

        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(EndOfItem(true), false, false)))
            return;

        StartOrderProcess[expNum];
        UpdateTableInfo();
        testgridview.CalculateSubTotal();

        // If currentTable.MethodUse = "Delivery" Then
        // If dsOrder.Tables("OpenOrders").Rows.Count = 0 And currentTable.IsClosed = False Then Exit Sub
        // StartDeliveryMethod()
        // End If

    }

    private void FastCashClose(object sender, EventArgs e) // totalOrder.Click
    {
        UserControlHit();

        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(EndOfItem(true), false, false)))
            return;

        if (!(currentTerminal.TermMethod == "Bar") & !(currentTerminal.TermMethod == "Quick"))
        {
            return;
        }

        if (companyInfo.fastCashClose == false)
            return;

        DataRow oRow;
        var hasAnyPaymentApplied = default(bool);
        DataSet_Builder.Information_UC info;

        if (currentTable.NumberOfChecks > 1)
        {
            info = new DataSet_Builder.Information_UC("You can not Fast Close a table with mulitple checks.");
            info.Location = new Point((this.Width - info.Width) / 2, (this.Height - info.Height) / 2);
            this.Controls.Add(info);
            info.BringToFront();
            return;
        }


        foreach (DataRow currentORow in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            oRow = currentORow;
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("Applied") == true)
                {
                    hasAnyPaymentApplied = true;
                }
            }
        }

        if (hasAnyPaymentApplied == true)
        {
            info = new DataSet_Builder.Information_UC("You can not Fast Close with an Applied Payment.");
            info.Location = new Point((this.Width - info.Width) / 2, (this.Height - info.Height) / 2);
            this.Controls.Add(info);
            info.BringToFront();
            return;
        }

        // *******
        // if we get here we are ok to Fast CLose
        CloseFastCash?.Invoke();


        // 222 below
        return;
        decimal checktotal;
        decimal paymentTotal;
        decimal remainingBalance;
        string txtForInfo;
        int numItems;

        // GenerateOrderTables.PopulatePaymentsAndCredits(currentTable.ExperienceNumber)
        foreach (DataRowView vRow in dvOrder)
        {
            checktotal += vRow("Price");
            checktotal += vRow("TaxPrice") + vRow("SinTax");
            if (vRow("sin") == vRow("sii") & !(vRow("ItemID") == 0))
            {
                numItems += 1;
            }
        }

        // at this point we do not have payments
        // DO WE LOOK AT APPLIED ???? ***  if we dont look at applied we get the amount not waiting for cc auth
        // its tricky b/c this really is not fast cash
        foreach (DataRow currentORow1 in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            oRow = currentORow1;
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("CheckNumber") == currentTable.CheckNumber)
                {
                    if (oRow("Applied") == false)
                    {
                        paymentTotal += oRow("PaymentAmount");
                        // oRow("Applied") = 1
                    }

                }
            }
        }

        checktotal = Conversions.ToDecimal(Strings.Format(checktotal, "####0.00"));
        paymentTotal = Conversions.ToDecimal(Strings.Format(paymentTotal, "####0.00"));
        remainingBalance = checktotal - paymentTotal;

        if (remainingBalance > 0m)
        {
            CreateNewFastCahPaymentEntry(remainingBalance);
        }
        else
        {
            // should have options here
        }

        txtForInfo = "AMOUNT DUE:  " + remainingBalance;
        cashPaymentDue = new DataSet_Builder.Information_UC(txtForInfo);
        cashPaymentDue.Location = new Point((this.Width - cashPaymentDue.Width) / 2, (this.Height - cashPaymentDue.Height) / 2);
        cashPaymentDue.NumOfItems = numItems;

        this.Controls.Add(cashPaymentDue);
        // we need to unenable order form
        cashPaymentDue.BringToFront();

    }

    private void FastCashInfo_Accepted222(object sender, EventArgs e)
    {
        UserControlHit();
        testgridview.Enabled = true; // just temp, remove when fast cash works
        return; // *** we are now closing Fast without this

        DataRow oRow;
        decimal orderBalanceAmount;
        decimal payBalanceAmount;
        int numItems;
        CashClose_UC ccDisplay;
        // Dim oDetail As OrderDetailInfo
        // prt.SendingOrder(oDetail)
        // prt.SendingOrder222()

        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(EndOfItem(false), false, false)))
            return;
        numItems = cashPaymentDue.NumOfItems;
        SendingOrderRoutine();

        // GenerateOrderTables.UpdatePaymentsAndCredits()
        var fastClosePrint = new CloseCheck(currentTable.CheckNumber);


        foreach (DataRow currentORow in dsOrder.Tables("OpenOrders").Rows)
        {
            oRow = currentORow;
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                orderBalanceAmount += oRow("Price");
                orderBalanceAmount += oRow("TaxPrice") + oRow("SinTax");
            }
        }

        foreach (DataRow currentORow1 in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            oRow = currentORow1;
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("Applied") == true)
                {
                    payBalanceAmount += oRow("PaymentAmount");
                }
                else
                {
                    oRow("Applied") = true;
                }

                oRow("DailyCode") = currentTable.DailyCode;
                oRow("PaymentDate") = DateTime.Now;
                oRow("TerminalsOpenID") = currentTerminal.TerminalsOpenID;

            }
        }

        fastClosePrint.PrintingFromFastCash(payBalanceAmount);
        // 444      tmrCardRead.Stop()
        // 444  RemoveHandler tmrCardRead.Tick, AddressOf fastClosePrint.readAuth.tmrCardRead_Tick

        if ((double)(orderBalanceAmount - payBalanceAmount) <= 0.02d)
        {
            ccDisplay = new CashClose_UC(numItems, currentTable.TruncatedExpNum, orderBalanceAmount, payBalanceAmount);

            GenerateOrderTables.ReleaseTableOrTab();
            if (!(currentTerminal.TermMethod == "Quick"))
            {
                GenerateOrderTables.PopulateAllTablesWithStatus(false);
            }
            else
            {
                currentTable.IsClosed = true;
                GetReadyForNewTicket();
            }
        }

        // 444   fastClosePrint.readAuth.Shutdown()
        // 444   fastClosePrint.readAuth = Nothing
        fastClosePrint.Dispose();
        fastClosePrint = default;
        cashPaymentDue.Dispose();

        LeaveAndSave(ref ccDisplay);

    }

    internal void GetReadyForNewTicket()
    {
        testgridview.totalOrder.BackColor = c7;
        testgridview.totalOrderTax.BackColor = c7;
        currentTerminal.NumOpenTickets -= 1;
        testgridview.UpdateCheckNumberButton();

    }
    private void FastCashInfo_Rejected(object sender, EventArgs e)
    {
        testgridview.Enabled = true; // just temp, remove when fast cash works

        dsOrder.Tables("PaymentsAndCredits").RejectChanges();

        cashPaymentDue.Dispose();

    }


    private void CreateNewFastCahPaymentEntry(decimal amount)
    {
        DataRow oRow = dsOrder.Tables("PaymentsAndCredits").NewRow;

        // oRow("PaymentsAndCreditsID") = DBNull.Value
        oRow("CompanyID") = companyInfo.CompanyID;
        oRow("LocationID") = companyInfo.LocationID;
        oRow("ExperienceNumber") = currentTable.ExperienceNumber;
        oRow("EmployeeID") = currentTable.EmployeeID;
        oRow("CheckNumber") = currentTable.CheckNumber;
        oRow("PaymentTypeID") = DetermineCreditCardID("Cash");
        oRow("PaymentFlag") = "Cash";
        oRow("PaymentAmount") = amount;
        oRow("Surcharge") = 0;
        oRow("Tip") = 0;
        // oRow("TipAdjustment") = CType(0, Decimal)
        oRow("Applied") = true;
        oRow("AuthCode") = "";

        oRow("SwipeType") = 0;
        oRow("TerminalID") = currentTerminal.TermPrimaryKey;
        if (mainServerConnected == true)
        {
            oRow("dbUP") = 1;
        }
        else
        {
            oRow("dbUP") = 0;
        }

        if (typeProgram == "Online_Demo")
        {
            oRow("PaymentsAndCreditsID") = demoPaymentID;
            demoPaymentID += 1;
        }
        dsOrder.Tables("PaymentsAndCredits").Rows.Add(oRow);


    }




    private object DetermineCurrentStatus222()
    {
        int currentStatus;
        var oRow = default(DataRow);

        currentStatus = oRow(dsOrder.Tables("StatusChange").Rows.Count - 1)("TableStatusID");

        return currentStatus;

    }

    private object DetermineCurrentStatusTime222()
    {
        // not sure if we need this function

        DateTime currentStatusTime;
        var oRow = default(DataRow);

        currentStatusTime = oRow(dsOrder.Tables("StatusChange").Rows.Count - 1)("StatusTime");

        return currentStatusTime;

    }



    private void CreateTableInfoPanel()
    {
        pnlTableInfo.SuspendLayout();

        // Table Info Panel
        if (currentServer.Lefty == false)
        {
            pnlTableInfo.Location = new Point(opLocationX - 2 * buttonSpace, viewOrderHeight * 1.2d); // opHeight + (5 * buttonSpace))
        }
        else
        {
            pnlTableInfo.Location = new Point(ssX * 0.26d + 2 * buttonSpace, viewOrderHeight * 1.2d);
        } // opHeight + (5 * buttonSpace))

        double w = opWidth * 0.27d;
        double h = ssY - viewOrderHeight * 1.148d;
        float bHeight = (float)(h / 4d - 1d); // (h / 4.4)
        float bWidth = (float)(w - 4); // (2*buttonspace)
        pnlTableInfo.Size = new Size(w, h);
        pnlTableInfo.BorderStyle = BorderStyle.FixedSingle;
        pnlTableInfo.BackColor = c3;

        btnTableInfoMenu.Location = new Point(1, 1); // (buttonSpace, 0.5 * buttonSpace)
        btnTableInfoMenu.Size = new Size(bWidth, bHeight);
        btnTableInfoMenu.BackColor = c2;
        btnTableInfoMenu.ForeColor = c3;
        btnTableInfoMenu.TextAlign = ContentAlignment.MiddleCenter;

        btnTableInfoServerNumber.Location = new Point(1, bHeight + 1f); // (buttonSpace, bHeight + buttonSpace)
        btnTableInfoServerNumber.Size = new Size(bWidth, bHeight);
        btnTableInfoServerNumber.BackColor = c2;
        btnTableInfoServerNumber.ForeColor = c3;
        btnTableInfoServerNumber.TextAlign = ContentAlignment.MiddleCenter;

        btnTableInfoTableNumber.Location = new Point(1, 2f * bHeight + 1f); // (buttonSpace, (2 * bHeight) + (1.5 * buttonSpace))
        btnTableInfoTableNumber.Size = new Size(bWidth, bHeight);
        btnTableInfoTableNumber.BackColor = c2;
        btnTableInfoTableNumber.ForeColor = c3;
        btnTableInfoTableNumber.TextAlign = ContentAlignment.MiddleCenter;

        btnTableInfoNumberOfCustomers.Location = new Point(1, 3f * bHeight + 1f); // (buttonSpace, (3 * bHeight) + (2 * buttonSpace))
        btnTableInfoNumberOfCustomers.Size = new Size(bWidth, bHeight);
        btnTableInfoNumberOfCustomers.BackColor = c2;
        btnTableInfoNumberOfCustomers.ForeColor = c3;
        btnTableInfoNumberOfCustomers.TextAlign = ContentAlignment.MiddleCenter;

        pnlTableInfo.Controls.Add(btnTableInfoMenu);
        pnlTableInfo.Controls.Add(btnTableInfoServerNumber);
        pnlTableInfo.Controls.Add(btnTableInfoTableNumber);
        pnlTableInfo.Controls.Add(btnTableInfoNumberOfCustomers);

        pnlTableInfo.ResumeLayout();

        UpdateTableInfo();

    }

    private void CreateDrinkModifierPanel()
    {

        double dmLocationX;
        double dmLocationY;
        double dmWidth;
        double dmHeight;
        double bw;
        double bh;

        if (currentServer.Lefty == false)
        {
            dmLocationX = viewOrderWidth + pnlTableInfo.Width + 4 * buttonSpace;
        }
        else
        {
            dmLocationX = ssX * 0.41d;
        }

        dmLocationY = viewOrderHeight * 1.2d;
        dmWidth = pnlOrder.Width * 0.5d;     // - (pnlTableInfo.Width + (3 * buttonSpace))
        dmHeight = pnlTableInfo.Height;

        bw = (dmWidth - 5 * buttonSpace) / 6;
        bh = (dmHeight - 3 * buttonSpace) / 6;

        pnlWineParring.Location = new Point(dmLocationX, dmLocationY);
        pnlWineParring.Size = new Size(dmWidth, dmHeight);
        pnlWineParring.BackColor = c3; // System.Drawing.SystemColors.Control
        pnlWineParring.BorderStyle = BorderStyle.FixedSingle;

        lblWineParring = new Label();
        lblRecipe = new Label();

        lblWineParring.Location = new Point(1, 1); // (buttonSpace, buttonSpace)
        lblWineParring.Size = new Size(dmWidth - 4d, dmHeight - 4d); // ((dmWidth - (2 * buttonSpace)), (dmHeight - (2 * buttonSpace)))
        lblWineParring.Text = "";
        lblWineParring.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        lblWineParring.BackColor = c2; // System.Drawing.SystemColors.Control
        lblWineParring.ForeColor = c3; // c2

        lblRecipe.Location = new Point(1, 1); // (buttonSpace, buttonSpace)
        lblRecipe.Size = new Size(dmWidth - 4d, dmHeight - 4d); // ((dmWidth - (2 * buttonSpace)), (dmHeight - (2 * buttonSpace)))
        lblRecipe.Text = "";
        lblRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        lblRecipe.BackColor = c2; // System.Drawing.SystemColors.Control
        lblRecipe.ForeColor = c3; // c2
        lblRecipe.Visible = false;

        pnlPizzaSplit.Location = new Point(dmLocationX, dmLocationY);
        pnlPizzaSplit.Size = new Size(dmWidth, dmHeight);
        pnlPizzaSplit.BackColor = c3; // System.Drawing.SystemColors.Control
        pnlPizzaSplit.BorderStyle = BorderStyle.FixedSingle;
        pnlPizzaSplit.Visible = false;

        pnlOnFullPizza.Location = new Point(0, 0);
        pnlOnFullPizza.Size = new Size(dmWidth / 2d, dmHeight);
        pnlOnFullPizza.BackColor = c18;

        pnlOnFirstHalf.Location = new Point(dmWidth / 2d, 0);
        pnlOnFirstHalf.Size = new Size(dmWidth / 2d, dmHeight / 2d);
        pnlOnFirstHalf.BackColor = c3;

        pnlOnSecondHalf.Location = new Point(dmWidth / 2d, dmHeight / 2d);
        pnlOnSecondHalf.Size = new Size(dmWidth / 2d, dmHeight / 2d);
        pnlOnSecondHalf.BackColor = c3;

        onFullPizza.Location = new Point(2, 5);
        onFullPizza.Size = new Size(dmWidth / 2d - 4d, dmHeight - 4d);
        onFullPizza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        onFullPizza.BorderStyle = BorderStyle.FixedSingle;
        onFullPizza.BackColor = c2;
        onFullPizza.ForeColor = c3;

        onFirstHalf.Location = new Point(2, 2);
        onFirstHalf.Size = new Size(dmWidth / 2d - 8d, dmHeight / 2d);
        onFirstHalf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        onFirstHalf.BorderStyle = BorderStyle.FixedSingle;
        onFirstHalf.BackColor = c2;
        onFirstHalf.ForeColor = c3;

        onSecondHalf.Location = new Point(2, 1);
        onSecondHalf.Size = new Size(dmWidth / 2d - 8d, dmHeight / 2d - 2d);
        onSecondHalf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        onSecondHalf.BorderStyle = BorderStyle.FixedSingle;
        onSecondHalf.BackColor = c2;
        onSecondHalf.ForeColor = c3;

        onFullPizza.DataSource = dvPizzaFull;
        onFirstHalf.DataSource = dvPizzaFirst;
        onSecondHalf.DataSource = dvPizzaSecond;

        onFullPizza.DisplayMember = "ItemName";
        onFirstHalf.DisplayMember = "ItemName";
        onSecondHalf.DisplayMember = "ItemName";


        pnlWineParring.Controls.Add(lblWineParring);
        pnlWineParring.Controls.Add(lblRecipe);

        pnlOnFullPizza.Controls.Add(onFullPizza);
        pnlOnFirstHalf.Controls.Add(onFirstHalf);
        pnlOnSecondHalf.Controls.Add(onSecondHalf);
        pnlPizzaSplit.Controls.Add(pnlOnFullPizza);
        pnlPizzaSplit.Controls.Add(pnlOnFirstHalf);
        pnlPizzaSplit.Controls.Add(pnlOnSecondHalf);

    }

    private void CreateMainButtonArray(int width, int height)
    {
        int index;
        int x = buttonSpace;
        int y = buttonSpace;

        for (index = 1; index <= 20; index++)
        {
            btnMain[index] = new OrderButton("10");
            {
                ref var withBlock = ref btnMain[index];
                withBlock.Size = new Size(width, height);
                withBlock.Location = new Point(x, y);
                withBlock.FoodTableIndex = index;
                withBlock.BackColor = c8;
            }

            y = y + height + buttonSpace;
            if (index == 10)
            {
                y = height + 2 * buttonSpace;
            }
        }

        btnMainNext = new OrderButton("10");
        {
            var withBlock1 = btnMainNext;
            withBlock1.Size = new Size(width, height);
            withBlock1.Location = new Point(buttonSpace, height * 10 + buttonSpace * 11);
            withBlock1.Text = "Next";
            withBlock1.BackColor = c7;
            withBlock1.ForeColor = c3;
            pnlMain.Controls.Add(btnMainNext);
        }

        btnMainPrevious = new OrderButton("10");
        {
            var withBlock2 = btnMainPrevious;
            withBlock2.Size = new Size(width, height);
            withBlock2.Location = new Point(buttonSpace, buttonSpace);
            withBlock2.Text = "Previous";
            withBlock2.BackColor = c7;
            withBlock2.ForeColor = c3;
            pnlMain2.Controls.Add(btnMainPrevious);
        }

        PopulateMainButtons();

        for (index = 20; index >= 0; index -= 1)
        {
            pnlMain2.Controls.Add(btnMain[index]);
            if (index < 11)
            {
                pnlMain.Controls.Add(btnMain[index]);
            }
        }

        y = buttonSpace;

        for (index = 1; index <= 10; index++)
        {
            btnModifier[index] = new OrderButton("10");
            {
                ref var withBlock3 = ref btnModifier[index];
                withBlock3.Size = new Size(width, height);
                withBlock3.Location = new Point(x, y);
                withBlock3.BackColor = c8;
            }
            y = y + height + buttonSpace;
        }

        return;
        // 222 below
        foreach (DataRow oRow in dtModifierCategory.Rows)
        {
            {
                ref var withBlock4 = ref btnModifier[oRow("CategoryOrder")];  // (oRow("CategoryID") - 100)
                withBlock4.Text = oRow("CategoryAbrev");
                withBlock4.CategoryID = oRow("CategoryID");
                withBlock4.CatName = oRow("CategoryName");
                withBlock4.Functions = 3;
                withBlock4.BackColor = c7;
                withBlock4.ForeColor = c3;
                this.btnModifier[oRow("CategoryOrder")].Click += ModifierClick222;
            }
        }

        for (index = 10; index >= 1; index -= 1)
            pnlMain3.Controls.Add(btnModifier[index]);
        btnMainNextMain3 = new OrderButton("10");
        {
            var withBlock5 = btnMainNextMain3;
            withBlock5.Size = new Size(width, height);
            withBlock5.Location = new Point(buttonSpace, height * 10 + buttonSpace * 11);
            withBlock5.Text = "Next";
            withBlock5.BackColor = c7;
            withBlock5.ForeColor = c3;
            pnlMain3.Controls.Add(btnMainNextMain3);
        }

    }

    private void NextButton(object sender, EventArgs e)
    {
        UserControlHit();
        // If EndOfItem(True) = False Then Exit Sub
        pnlMain.Visible = false;
        pnlMain2.Visible = true;

    }

    private void PreviousButton(object sender, EventArgs e)
    {
        UserControlHit();
        // If EndOfItem(True) = False Then Exit Sub
        pnlMain2.Visible = false;
        pnlMain.Visible = true;

    }

    private void NextButtonMain3(object sender, EventArgs e)
    {
        UserControlHit();
        // ???    If EndOfItem(True) = False Then Exit Sub
        pnlMain.Visible = true;
        pnlMain3.Visible = false;

    }

    private void PopulateMainButtons()
    {
        DataRow oRow;
        DataTable populatingTable;
        DataTable populatingDrinkTable;
        int index;
        bool IsPrimary;
        bool moreThan10Categories = false;

        // If currentTable.StartingMenu = currentPrimaryMenuID Then
        // If currentTable.CurrentMenu = initPrimaryMenuID Then
        if (currentTable.IsPrimaryMenu == true)
        {
            IsPrimary = true;
        }
        else
        {
            IsPrimary = false;
        }
        if (currentTerminal.TermMethod == "Quick")
        {
            if (IsPrimary == true)
            {
                populatingTable = dtQuickCategory;
                populatingDrinkTable = dtQuickDrinkCategory;
            }
            else
            {
                populatingTable = dtSecondaryQuickCategory;
                populatingDrinkTable = dtSecondaryQuickDrinkCategory;
            }
        }
        else if (currentServer.Bartender == true) // 444 IsBartenderMode = True Then                ' can also add a screen size restriction
        {
            if (IsPrimary == true)
            {
                populatingTable = dtBartenderCategory;
                populatingDrinkTable = dtBartenderDrinkCategory;
            }
            else
            {
                populatingTable = dtSecondaryBartenderCategory;
                populatingDrinkTable = dtSecondaryBartenderDrinkCategory;
            }
        }

        else if (IsPrimary == true)
        {
            populatingTable = dtMainCategory;
            populatingDrinkTable = dtDrinkCategory;
        }
        else
        {
            populatingTable = dtSecondaryMainCategory;
            populatingDrinkTable = dtSecondaryDrinkCategory;
        }


        for (index = 1; index <= 20; index++)
        {
            {
                ref var withBlock = ref btnMain[index];
                withBlock.Text = "";
                withBlock.CategoryID = (object)null;
                withBlock.CatName = (object)null;
                withBlock.Functions = (object)null;
                withBlock.IsPrimary = (object)null; // IsPrimary
                withBlock.MainButtonIndex = (object)null;
                withBlock.BackColor = c8;
                withBlock.ForeColor = c2;
                // Handlers
                this.btnMain[index].Click -= Foods;
            }
        }




        foreach (DataRow currentORow in populatingTable.Rows)
        {
            oRow = currentORow;


            if (oRow("OrderIndex") > 10)
            {
                moreThan10Categories = true;
            }
            {
                ref var withBlock1 = ref btnMain[oRow("OrderIndex")];
                withBlock1.Text = oRow("CategoryAbrev");
                withBlock1.CategoryID = oRow("CategoryID");
                withBlock1.CatName = oRow("CategoryName");
                withBlock1.Functions = oRow("FunctionID");
                withBlock1.FunctionGroup = oRow("FunctionGroupID");
                withBlock1.FunctionFlag = oRow("FunctionFlag");
                withBlock1.IsPrimary = IsPrimary;
                withBlock1.MainButtonIndex = 1;
                withBlock1.Extended = oRow("Extended");
                if (pastFirstCategory == false & oRow("FunctionFlag") == "G")
                {
                    firstCategory.CategoryID = withBlock1.CategoryID;
                    firstCategory.FunctionFlag = withBlock1.FunctionFlag;
                    firstCategory.IsPrimary = withBlock1.IsPrimary;
                    firstCategory.Extended = withBlock1.Extended;
                    pastFirstCategory = true;
                }
                if (!object.ReferenceEquals(oRow("ButtonColor"), DBNull.Value))
                {
                    withBlock1.BackColor = Color.FromArgb(oRow("ButtonColor"));
                    withBlock1.ForeColor = Color.FromArgb(oRow("ButtonForeColor"));
                }
                else
                {
                    withBlock1.BackColor = c6;
                    withBlock1.ForeColor = c3;
                }

                // Handlers
                this.btnMain[oRow("OrderIndex")].Click += Foods;
            }
        }

        foreach (DataRow currentORow1 in populatingDrinkTable.Rows)
        {
            oRow = currentORow1;
            if (oRow("OrderIndex") > 10)
            {
                moreThan10Categories = true;
            }
            {
                ref var withBlock2 = ref btnMain[oRow("OrderIndex")];
                withBlock2.Text = oRow("DrinkCategoryName");   // should be DrinkCategoryAbrev
                if (oRow("DrinkCategoryNumber") == -1)
                {
                    withBlock2.CategoryID = -1;
                }
                else
                {
                    withBlock2.CategoryID = oRow("DrinkCategoryID");
                }
                withBlock2.CatName = oRow("DrinkCategoryName");

                withBlock2.Functions = 4;  // oRow("DrinkFunctionID")              'need to update
                withBlock2.FunctionFlag = "D";
                withBlock2.FunctionGroup = (object)null;       // at this point we don't have group (we get w/ specific drink)
                withBlock2.MainButtonIndex = 1;
                if (!object.ReferenceEquals(oRow("ButtonColor"), DBNull.Value))
                {
                    withBlock2.BackColor = Color.FromArgb(oRow("ButtonColor"));
                    withBlock2.ForeColor = Color.FromArgb(oRow("ButtonForeColor"));
                }
                else
                {
                    withBlock2.BackColor = c16;
                    withBlock2.ForeColor = c3;
                }

                // Handlers
                this.btnMain[oRow("OrderIndex")].Click += Foods;
            }
        }

        if (moreThan10Categories == true)
        {
            btnMainNext.Visible = true;
        }
        else
        {
            btnMainNext.Visible = false;
        }
        pnlMain.Visible = true;

    }


    private void CreateOrderButtonArray()
    {

        int index;
        int x = buttonSpace;
        int y = buttonSpace;
        var count = default(int);

        for (index = 0; index <= 31; index++)
        {

            // 444  btnOrder(index) = New OrderButtonRaised
            btnOrder[index] = new OrderButton("12");

            {
                ref var withBlock = ref btnOrder[index];
                withBlock.Size() = new Size(opButtonWidth, opButtonHeight);
                withBlock.Location = new Point(x, y);
                // .BackgroundImage = Image.FromFile("testBack.png")
                this.btnOrder[index].Click += BtnOrder_Click;
            }

            count = count + 1;
            if (count < 4)
            {
                x = x + opButtonWidth + buttonSpace;
            }
            else
            {
                x = buttonSpace;
                y = y + opButtonHeight + buttonSpace;
                count = 0;
            }
        }

        for (index = 31; index >= 0; index -= 1)
            pnlOrder.Controls.Add(btnOrder[index]);

    }

    private void CreateOrderButtonQuick()
    {

        int index;
        int x = buttonSpace;
        int y = buttonSpace;
        var count = default(int);
        // opButtonWidth = (opWidth - (7 * buttonSpace)) / 6
        // opButtonHeight = (opHeight + 47 - (11 * buttonSpace)) / 10     'mathmatically should be 11
        // ReDim btnOrderQuick(60)

        for (index = 0; index <= 59; index++)
        {

            btnOrderQuick[index] = new OrderButton("10");

            {
                ref var withBlock = ref btnOrderQuick[index];
                withBlock.Size() = new Size(drinkButtonWidth, drinkButtonHeight);
                // .Size() = New Size(opButtonWidth, opButtonHeight)
                withBlock.Location = new Point(x, y);
                this.btnOrderQuick[index].Click += BtnOrder_Click;
            }

            count = count + 1;
            if (count < 6)
            {
                x = x + drinkButtonWidth + buttonSpace;
            }
            // x = x + opButtonWidth + buttonSpace
            else
            {
                x = buttonSpace;
                y = y + drinkButtonHeight + buttonSpace;
                // y = y + opButtonHeight + buttonSpace
                count = 0;
            }
        }

        for (index = 59; index >= 0; index -= 1)
            pnlOrderQuick.Controls.Add(btnOrderQuick[index]);

    }

    private void CreateOrderDrinkButtonArray()
    {

        int index;
        int x = buttonSpace;
        int y = buttonSpace;
        var count = default(int);

        for (index = 1; index <= 60; index++) // 48
        {

            btnOrderDrink[index] = new OrderButton("10");

            {
                ref var withBlock = ref btnOrderDrink[index];
                withBlock.Size() = new Size(drinkButtonWidth, drinkButtonHeight);
                withBlock.Location = new Point(x, y);
                this.btnOrderDrink[index].Click += BtnOrder_Click;   // BtnOrderDrink_Click
            }

            count = count + 1;
            if (count < 6)
            {

                x = x + drinkButtonWidth + buttonSpace;
            }
            else
            {
                x = buttonSpace;
                y = y + drinkButtonHeight + buttonSpace;
                count = 0;
            }
        }

        for (index = 60; index >= 1; index -= 1)
            pnlOrderDrink.Controls.Add(btnOrderDrink[index]);

    }

    private void CreateOrderModifierButtonArray()
    {
        int index;
        int x = buttonSpace;
        int y = buttonSpace;
        var count = default(int);

        for (index = 0; index <= 23; index++)
        {

            btnOrderModifier[index] = new OrderButton("12");

            {
                ref var withBlock = ref btnOrderModifier[index];
                withBlock.Size() = new Size(mpButtonWidth, mpButtonHeight);
                withBlock.Location = new Point(x, y);
                withBlock.BackColor = c8;
                this.btnOrderModifier[index].Click += BtnOrderModifier_Click;
            }

            count = count + 1;
            if (count < 4)
            {
                x = x + mpButtonWidth + buttonSpace;
            }

            else
            {
                x = buttonSpace;
                y = y + mpButtonHeight + buttonSpace;
                count = 0;
            }
        }

        btnOrderModifierCancel = new OrderButton("12");
        {
            ref var withBlock1 = ref btnOrderModifierCancel;
            withBlock1.Size() = new Size(mpButtonWidth, mpButtonHeight);
            withBlock1.Location = new Point(3d * mpButtonWidth + 4 * buttonSpace, 6d * mpButtonHeight + 7 * buttonSpace);
            withBlock1.Text = "None";  // "Cancel"
            withBlock1.ID = -3;
            withBlock1.BackColor = c4;
            withBlock1.ForeColor = c3;
            this.btnOrderModifierCancel.Click += BtnOrderModifier_Click;
        }

        for (index = 23; index >= 0; index -= 1)
            pnlOrderModifier.Controls.Add(btnOrderModifier[index]);
        pnlOrderModifier.Controls.Add(btnOrderModifierCancel);

    }

    private void CreateOrderModifierExtendedButtonArray()
    {
        int index;
        int x = buttonSpace;
        int y = buttonSpace;
        var count = default(int);
        double extModButtonHeight;
        extModButtonHeight = drinkButtonHeight * (8d / 9d);

        for (index = 0; index <= 59; index++)
        {

            btnOrderModifierExt[index] = new OrderButton("10");

            {
                ref var withBlock = ref btnOrderModifierExt[index];
                withBlock.Size() = new Size(drinkButtonWidth, extModButtonHeight);
                withBlock.Location = new Point(x, y);
                withBlock.BackColor = c8;
                this.btnOrderModifierExt[index].Click += BtnOrderModifier_Click;
            }

            count = count + 1;
            if (count < 6)
            {
                x = x + drinkButtonWidth + buttonSpace;
            }

            else
            {
                x = buttonSpace;
                y = y + extModButtonHeight + buttonSpace;
                count = 0;
            }
        }

        btnOrderModifierCancel = new OrderButton("10");
        {
            ref var withBlock1 = ref btnOrderModifierCancel;
            withBlock1.Size() = new Size(drinkButtonWidth, extModButtonHeight);
            withBlock1.Location = new Point(5d * drinkButtonWidth + 5 * buttonSpace, 10d * extModButtonHeight + 11 * buttonSpace);
            withBlock1.Text = "None";  // "Cancel"
            withBlock1.ID = -3;
            withBlock1.BackColor = c4;
            withBlock1.ForeColor = c3;
            this.btnOrderModifierCancel.Click += BtnOrderModifier_Click;
        }

        for (index = 59; index >= 0; index -= 1)
            pnlOrderModifierExt.Controls.Add(btnOrderModifierExt[index]);
        pnlOrderModifierExt.Controls.Add(btnOrderModifierCancel);

    }

    private void UpdateDataViewsByCheck()
    {
        // activeCheck (once created) should always be = to currenttable.checknumber - it gone

        dvOrder.RowFilter = "CheckNumber ='" + currentTable.CheckNumber + "'";
        dvOrderTopHierarcy.RowFilter = "sii = sin AND CheckNumber ='" + currentTable.CheckNumber + "'";
        dvOrderHolds.RowFilter = "ItemStatus = 1 AND CheckNumber ='" + currentTable.CheckNumber + "'";
        dvKitchen.RowFilter = "ItemStatus = 2 AND CheckNumber ='" + currentTable.CheckNumber + "'";


    }

    private void DisplayCustomerPanel()
    {

        customerPanel = new Panel();
        customerPanel.SuspendLayout();

        // customerPanel.Location = New Point(1, (Me.pnlDirection.Height + Me.gridViewOrder.Height + Me.pnlSubTotal.Height))
        // customerPanel.Size = New Size(Me.Width, (Me.Height * 0.05))
        // customerPanel.BackColor = c7
        if (currentServer.Lefty == false)
        {
            customerPanel.Location = new Point(opLocationX - buttonSpace, opLocationY + opHeight + buttonSpace);
        }
        else
        {
            customerPanel.Location = new Point(ssX * 0.26d + 2 * buttonSpace, opLocationY + opHeight + buttonSpace);
        }

        customerPanel.Size = new Size(ssX * 0.41d, ssY * 0.06d);
        customerPanel.BackColor = c7;

        int index;
        double w = customerPanel.Width / 6;      // 9 buttons and 1 (3 times size)
        double h = customerPanel.Height;
        var x = default(double);

        btnCustomerNext = new KitchenButton("Next", w, h, c9, c2);
        btnCustomerNext.Location = new Point(x, 0);
        btnCustomerNext.ForeColor = c3;
        this.btnCustomerNext.Click += CustomerButton_Click;
        customerPanel.Controls.Add(btnCustomerNext);

        x += w;

        for (index = 1; index <= 5; index++)
        {
            btnCustomer[index] = new KitchenButton(index, w, h, c7, c2);
            {
                ref var withBlock = ref btnCustomer[index];
                withBlock.Location = new Point(x, 0);
                withBlock.ForeColor = c3;
                this.btnCustomer[index].Click += CustomerButton_Click;
                customerPanel.Controls.Add(btnCustomer[index]);
            }
            x += w;
        }

        customerPanel.ResumeLayout();
        this.Controls.Add(customerPanel);
        ChangeCustomerButtonColor(c9);

    }

    private void CustomerButton_Click(object sender, EventArgs e)
    {
        UserControlHit();
        string btnText;
        // 444    If currentTerminal.TermMethod = "Quick" Then Exit Sub

        KitchenButton objButton;
        try
        {
            objButton = (KitchenButton)sender;
        }
        catch (Exception ex)
        {
            return;
        }

        if (!object.ReferenceEquals(objButton.GetType, btnCustomer[1].GetType))
            return;
        btnText = objButton.Text;

        AttemptToChangeCustomer(btnText, true);

    }

    private void AttemptToChangeCustomer(string btnText, bool doWeTestForPanel1)
    {
        int newcnTest;
        DataRow bRow;
        bool newCustLabelExist;

        ChangeCustomerButtonColor(c7);


        if (!(btnText == "Next"))
        {
            bool cust1Test;

            if (Conversions.ToInteger(btnText) == 1)
            {
                if (doWeTestForPanel1 == true)
                {
                    cust1Test = CustomerPanelOneTest();

                    if (cust1Test == false)
                    {
                        // this means we added the panel
                        // currentTable.NextCustomerNumber = 1
                        if (dvOrder.Count == 1)
                        {
                            // this is only needed if we just put Cust Panel 1 only
                            testgridview.gridViewOrder.DataSource = dvOrder;
                        }
                        ChangeCustomerButtonColor(c9);
                        return;
                    }
                    else
                    {
                        currentTable.NextCustomerNumber = 1; // not sure if this should be inside if/then
                        if (currentTable.MiddleOfOrder == true)
                        {
                            currentTable.MarkForNextCustomer = true;
                            return;
                        }
                    }
                }
                else
                {
                    ChangeCustomerButtonColor(c9);
                    return;
                }
            }
            else
            {
                // this is not btn 1 hit
                btnCustomer[1].BackColor = c7;
            }
        }

        if (currentTable.EmptyCustPanel == 0)          // same as oldcnTest > 1
        {
            // no empty panels

            if (btnText == "Next")
            {
                currentTable.NextCustomerNumber = currentTable.CustomerNumber + 1;
            }

            else
            {
                currentTable.NextCustomerNumber = Conversions.ToInteger(btnText);
            }
            // ChangeCustomerButtonColor(c9)
            newCustLabelExist = Conversions.ToBoolean(DetermineCustomerLabelExists(currentTable.NextCustomerNumber));

            if (currentTable.MiddleOfOrder == true)
            {

                if (newCustLabelExist == false)
                {
                    currentTable.MarkForNewCustomerPanel = true;
                    currentTable.MarkForNextCustomer = true;
                    testgridview.justAddedPanel = true;
                    // If doWeTestForPanel1 = False Then
                    return;
                }
                // End If
                else
                {
                    currentTable.MarkForNextCustomer = true;
                    return;
                    // currentTable.CustomerNumber = currentTable.NextCustomerNumber
                    // ChangeCustomerButtonColor(c9)
                }
            }

            else if (newCustLabelExist == false)
            {
                currentTable.CustomerNumber = currentTable.NextCustomerNumber;
                ChangeCustomerButtonColor(c9);
                AddCustomerPanel();
                if (btnText == "Next")
                {
                    return;
                }
            }

        }

        // only way we get here is for there to be an empty panel
        // if we only have 1 customer item and it does not have an itemID then it is a blank customer title
        // we are changing that title to new customer then exiting
        if (currentTable.CustomerNumber == currentTable.EmptyCustPanel)
        {
            // your old Cust Number has an empty panel
            if (!(btnText == "Next"))
            {
                if (currentTable.CustomerNumber == Conversions.ToInteger(btnText))
                {
                    ChangeCustomerButtonColor(c9);   // must change back
                    return;
                    // selected the same panel
                }
            }

            foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
            {
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (oRow("CustomerNumber") == currentTable.CustomerNumber & oRow("ItemID") == 0)
                    {
                        // find your empty panel

                        if (btnText == "Next")
                        {
                            // currentTable.NextCustomerNumber += 1
                            currentTable.CustomerNumber += 1;
                        }
                        else
                        {
                            // currentTable.NextCustomerNumber = CInt(btnText)
                            currentTable.CustomerNumber = Conversions.ToInteger(btnText);
                        }
                        // currentTable.CustomerNumber = currentTable.NextCustomerNumber

                        // ****   new test count
                        newcnTest = GenerateOrderTables.DetermineCnTest(currentTable.CustomerNumber);

                        if (newcnTest == 0)   // <= 1 Then
                        {
                            oRow("ItemName") = "              " + currentTable.CustomerNumber.ToString + "   CUSTOMER   " + currentTable.CustomerNumber.ToString; // btnText
                            oRow("TerminalName") = "              " + currentTable.CustomerNumber.ToString + "   CUSTOMER   " + currentTable.CustomerNumber.ToString; // btnText
                            oRow("ChitName") = "              " + currentTable.CustomerNumber.ToString + "   CUSTOMER   " + currentTable.CustomerNumber.ToString; // btnText
                            oRow("CustomerNumber") = currentTable.CustomerNumber;

                            if (currentTable.CustomerNumber != 1)
                            {
                                currentTable.EmptyCustPanel = currentTable.CustomerNumber;
                            }
                        }
                        else
                        {
                            // do we need to check to see if we have panel?????
                            // if not customer 1 we should have panel
                        }
                        ChangeCustomerButtonColor(c9);
                        return;
                    }
                }
            }
        }
        else
        {
            // currenttable.custometNumber < currenttable.EmptyCustomerPanel
            // this happens if we hit testOrderView to reset ct.CustomerNumber
            if (btnText == "Next")
            {
                currentTable.NextCustomerNumber = currentTable.CustomerNumber + 1;
            }
            else
            {
                currentTable.NextCustomerNumber = Conversions.ToInteger(btnText);
            }
            currentTable.CustomerNumber = currentTable.NextCustomerNumber;
            ChangeCustomerButtonColor(c9);
        }

    }

    private void AttemptToChangeCustomer222(string btnText, bool doWeTestForPanel1)
    {
        int newcnTest;
        DataRow bRow;
        bool newCustLabelExist;

        ChangeCustomerButtonColor(c7);

        if (!(btnText == "Next"))
        {
            bool cust1Test;

            if (Conversions.ToInteger(btnText) == 1)
            {
                if (doWeTestForPanel1 == true)
                {
                    cust1Test = CustomerPanelOneTest();

                    if (cust1Test == false)
                    {
                        // this means we added the panel
                        // currentTable.NextCustomerNumber = 1
                        if (dvOrder.Count == 1)
                        {
                            // this is only needed if we just put Cust Panel 1 only
                            testgridview.gridViewOrder.DataSource = dvOrder;
                        }
                        ChangeCustomerButtonColor(c9);
                        return;
                    }
                    else if (currentTable.MiddleOfOrder == true)
                    {
                        currentTable.NextCustomerNumber = 1;
                        currentTable.MarkForNextCustomer = true;
                        return;
                    }
                }
                else
                {
                    ChangeCustomerButtonColor(c9);
                    return;
                }
            }
            else
            {
                // this is not btn 1 hit
                btnCustomer[1].BackColor = c7;
            }
        }

        if (currentTable.EmptyCustPanel == 0)          // same as oldcnTest > 1
        {
            // no empty panels

            if (btnText == "Next")
            {
                currentTable.NextCustomerNumber = currentTable.CustomerNumber + 1;
            }

            else
            {
                currentTable.NextCustomerNumber = Conversions.ToInteger(btnText);
            }
            // ChangeCustomerButtonColor(c9)
            newCustLabelExist = Conversions.ToBoolean(DetermineCustomerLabelExists(currentTable.NextCustomerNumber));

            if (currentTable.MiddleOfOrder == true)
            {

                if (newCustLabelExist == false)
                {
                    currentTable.MarkForNewCustomerPanel = true;
                    currentTable.MarkForNextCustomer = true;
                    testgridview.justAddedPanel = true;
                    // If doWeTestForPanel1 = False Then
                    return;
                }
                // End If
                else
                {
                    currentTable.MarkForNextCustomer = true;
                    return;
                    // currentTable.CustomerNumber = currentTable.NextCustomerNumber
                    // ChangeCustomerButtonColor(c9)
                }
            }

            else if (newCustLabelExist == false)
            {
                currentTable.CustomerNumber = currentTable.NextCustomerNumber;
                ChangeCustomerButtonColor(c9);
                AddCustomerPanel();
                if (btnText == "Next")
                {
                    return;
                }
            }

        }

        // only way we get here is for there to be an empty panel
        // if we only have 1 customer item and it does not have an itemID then it is a blank customer title
        // we are changing that title to new customer then exiting
        if (currentTable.CustomerNumber == currentTable.EmptyCustPanel)
        {
            // your old Cust Number has an empty panel
            if (!(btnText == "Next"))
            {
                if (currentTable.CustomerNumber == Conversions.ToInteger(btnText))
                {
                    ChangeCustomerButtonColor(c9);   // must change back
                    return;
                    // selected the same panel
                }
            }

            foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
            {
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (oRow("CustomerNumber") == currentTable.CustomerNumber & oRow("ItemID") == 0)
                    {
                        // find your empty panel

                        if (btnText == "Next")
                        {
                            // currentTable.NextCustomerNumber += 1
                            currentTable.CustomerNumber += 1;
                        }
                        else
                        {
                            // currentTable.NextCustomerNumber = CInt(btnText)
                            currentTable.CustomerNumber = Conversions.ToInteger(btnText);
                        }
                        // currentTable.CustomerNumber = currentTable.NextCustomerNumber

                        // ****   new test count
                        newcnTest = GenerateOrderTables.DetermineCnTest(currentTable.CustomerNumber);

                        if (newcnTest == 0)   // <= 1 Then
                        {
                            oRow("ItemName") = "              " + currentTable.CustomerNumber.ToString + "   CUSTOMER   " + currentTable.CustomerNumber.ToString; // btnText
                            oRow("TerminalName") = "              " + currentTable.CustomerNumber.ToString + "   CUSTOMER   " + currentTable.CustomerNumber.ToString; // btnText
                            oRow("ChitName") = "              " + currentTable.CustomerNumber.ToString + "   CUSTOMER   " + currentTable.CustomerNumber.ToString; // btnText
                            oRow("CustomerNumber") = currentTable.CustomerNumber;

                            if (currentTable.CustomerNumber != 1)
                            {
                                currentTable.EmptyCustPanel = currentTable.CustomerNumber;
                            }
                        }
                        else
                        {
                            // do we need to check to see if we have panel?????
                            // if not customer 1 we should have panel
                        }
                        ChangeCustomerButtonColor(c9);
                        return;
                    }
                }
            }
        }
        else
        {
            // currenttable.custometNumber < currenttable.EmptyCustomerPanel
            // this happens if we hit testOrderView to reset ct.CustomerNumber
            if (btnText == "Next")
            {
                currentTable.NextCustomerNumber = currentTable.CustomerNumber + 1;
            }
            else
            {
                currentTable.NextCustomerNumber = Conversions.ToInteger(btnText);
            }
            currentTable.CustomerNumber = currentTable.NextCustomerNumber;
            ChangeCustomerButtonColor(c9);
        }

    }

    private void AddCustomerPanel()
    {

        var currentItem = new SelectedItemDetail();
        string custNumString = "              " + currentTable.CustomerNumber.ToString + "   CUSTOMER   " + currentTable.CustomerNumber.ToString;

        // If currentTable.IsTabNotTable = False Then
        // .Table = currentTable.TableNumber
        // Else
        // .Table = currentTable.TabID
        // End If
        currentItem.Check = currentTable.CheckNumber;
        currentItem.Customer = currentTable.CustomerNumber;
        currentItem.Course = currentTable.CourseNumber;
        currentItem.Quantity = 0;
        currentItem.InvMultiplier = 0;
        currentItem.FunctionFlag = "N";
        // If currentTable.MiddleOfOrder = True Then
        // .SIN = currentTable.ReferenceSIN - 1
        // .SII = currentTable.ReferenceSIN - 1
        // Else
        currentItem.SIN = currentTable.SIN;
        currentItem.SII = currentTable.SIN;
        currentItem.si2 = currentTable.si2;
        // End If
        currentItem.ID = 0;
        currentItem.Name = custNumString;
        currentItem.TerminalName = custNumString;
        currentItem.ChitName = custNumString;
        currentItem.Price = (object)null;
        currentItem.Category = (object)null;

        currentTable.ReferenceSIN = currentTable.SIN;
        currentTable.SIN += 1;
        AddItemToOrderTable(ref currentItem);
        // RaiseEvent AddingItemToOrder(currentItem)
        if (currentTable.CustomerNumber != 1)
        {
            currentTable.EmptyCustPanel = currentTable.CustomerNumber;
        }

        bool cust1Test;
        cust1Test = CustomerPanelOneTest();
        currentTable.ReferenceSIN = currentTable.SIN;

        if (cust1Test == false)
        {
            // this means we added the panel
            // currentTable.NextCustomerNumber = 1
            if (dvOrder.Count == 1)
            {
                // this is only needed if we just put Cust Panel 1 only
                testgridview.gridViewOrder.DataSource = dvOrder;
            }
            ChangeCustomerButtonColor(c9);
        }

        btnCustomer[1].BackColor = c7;
        // testgridview.justAddedPanel = True

    }

    private object DetermineCustomerLabelExists(int cn)
    {
        var IsCustLabel = default(bool);

        // If currentTable.CustomerNumber = 1 Then
        // CustomerPanelOneTest()
        // IsCustLabel = True
        // Else
        foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("ItemID") == 0)
                {
                    if (oRow("CustomerNumber") == cn)         // currentTable.CustomerNumber Then
                    {
                        IsCustLabel = true;
                        break;
                    }
                }
            }

        }
        // End If

        return IsCustLabel;

    }


    private void ChangeCustomerButtonColor(Color c)
    {
        // 444   If currentTerminal.TermMethod = "Quick" Then Exit Sub

        if (currentTable.CustomerNumber <= 5)
        {
            btnCustomer[currentTable.CustomerNumber].BackColor = c;
        }

        if (currentTable.NumberOfChecks > 1)
        {
            int cc;
            cc = DetermineCheckCount(currentTable.CustomerNumber);
            if (cc > 0)
            {
                currentTable.CheckNumber = currentTable.NumberOfChecks;
                testgridview.UpdateCheckNumberButton();
            }
        }

    }


    private object DetermineCnTest(int currentTable)
    {
        // this tests to see how if the new or old customer number has any information and how much
        int cnTestValue;

        if (dsOrder.Tables("OpenOrders").Rows.Count > 0)
        {
            cnTestValue = dsOrder.Tables("OpenOrders").Compute("Count(CustomerNumber)", "CustomerNumber ='" + currentTable + "'");
        }
        else
        {
            cnTestValue = 0;
        }

        return cnTestValue;

    }

    private void CreateMainModifierPanel()
    {
        pnlMainModifier.SuspendLayout();

        // Dim mainModifierPanelWidth As Integer = (ssX - (viewOrderWidth + opWidth + (4 * buttonSpace)))
        // Dim mainModifierPanelHeight As Integer = ssY * 0.27 'this seems too short but is 99% w/o spaces
        int mainModifierPanelWidth = ssX * 0.26d;
        int mainModifierPanelHeight = ssY * 0.26d;

        if (!(currentTerminal.TermMethod == "Quick"))
        {
            if (currentServer.Lefty == false)
            {
                pnlMainModifier.Location = new Point(ssX * 0.735d, opHeight + 3 * buttonSpace);
            }
            else
            {
                pnlMainModifier.Location = new Point(buttonSpace, opHeight + 3 * buttonSpace);
            }
        }
        else if (currentServer.Lefty == false)
        {
            pnlMainModifier.Location = new Point(ssX * 0.735d, opHeight + 3 * buttonSpace + 47);
        }
        else
        {
            pnlMainModifier.Location = new Point(buttonSpace, opHeight + 3 * buttonSpace + 47);
        }

        // Me.pnlMainModifier.Location = New Point((3 * buttonSpace) + viewOrderWidth + opWidth, panelModLocationY)
        pnlMainModifier.Size = new Size(mainModifierPanelWidth, mainModifierPanelHeight);
        // Me.pnlMainModifier.BackColor = c7
        pnlMainModifier.BackColor = c2;
        pnlMainModifier.BorderStyle = BorderStyle.FixedSingle;


        int btnModifierWidth = (mainModifierPanelWidth - 3 * buttonSpace) / 2;
        int btnModifierHeight = (mainModifierPanelHeight - 5 * buttonSpace) / 4;

        btnModifierAdd = new KitchenButton("Add", btnModifierWidth, btnModifierHeight, c4, c3);
        btnModifierAdd.Location = new Point(buttonSpace, buttonSpace);
        btnModifierNo = new KitchenButton("No", btnModifierWidth, btnModifierHeight, c4, c3);
        btnModifierNo.Location = new Point(buttonSpace, 2 * buttonSpace + btnModifierHeight);
        btnModifierSpecial = new KitchenButton("Special", btnModifierWidth, btnModifierHeight, c4, c3);
        btnModifierSpecial.Location = new Point(buttonSpace, 3 * buttonSpace + 2 * btnModifierHeight);
        btnModifierRepeat = new KitchenButton("Repeat", btnModifierWidth, btnModifierHeight, c4, c3);
        btnModifierRepeat.Location = new Point(buttonSpace, 4 * buttonSpace + 3 * btnModifierHeight);
        btnModifierBlank = new KitchenButton("", btnModifierWidth, btnModifierHeight, c4, c3);
        btnModifierBlank.Location = new Point(2 * buttonSpace + btnModifierWidth, 3 * buttonSpace + 2 * btnModifierHeight);

        btnModifierExtra = new KitchenButton("Extra", btnModifierWidth, btnModifierHeight, c4, c3);
        btnModifierExtra.Location = new Point(2 * buttonSpace + btnModifierWidth, buttonSpace);
        btnModifierOnFly = new KitchenButton("On Fly", btnModifierWidth, btnModifierHeight, c4, c3);
        btnModifierOnFly.Location = new Point(2 * buttonSpace + btnModifierWidth, buttonSpace);
        btnModifierNoMake = new KitchenButton("No Make", btnModifierWidth, btnModifierHeight, c4, c3);
        btnModifierNoMake.Location = new Point(2 * buttonSpace + btnModifierWidth, 3 * buttonSpace + 2 * btnModifierHeight);
        btnModifierOnSide = new KitchenButton("On Side", btnModifierWidth, btnModifierHeight, c4, c3);
        btnModifierOnSide.Location = new Point(2 * buttonSpace + btnModifierWidth, 2 * buttonSpace + btnModifierHeight);
        btnModifierNoCharge = new KitchenButton("No Charge", btnModifierWidth, btnModifierHeight, c4, c3);
        btnModifierNoCharge.Location = new Point(2 * buttonSpace + btnModifierWidth, 4 * buttonSpace + 3 * btnModifierHeight);

        pnlMainModifier.Controls.Add(btnModifierSpecial);
        pnlMainModifier.Controls.Add(btnModifierNo);
        pnlMainModifier.Controls.Add(btnModifierAdd);
        pnlMainModifier.Controls.Add(btnModifierOnSide);

        // 444    If Not currentTerminal.TermMethod = "Quick" Then
        pnlMainModifier.Controls.Add(btnModifierRepeat);
        pnlMainModifier.Controls.Add(btnModifierOnFly);
        pnlMainModifier.Controls.Add(btnModifierNoMake);
        pnlMainModifier.Controls.Add(btnModifierNoCharge);
        // Else
        pnlMainModifier.Controls.Add(btnModifierExtra);
        pnlMainModifier.Controls.Add(btnModifierBlank);
        // End If


        pnlMainModifier.ResumeLayout();

    }

    private void Foods(object sender, EventArgs e)
    {
        UserControlHit();
        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(EndOfItem(true), false, false)))
            return;
        // Me.GotoLastOrderedItem()

        // ClearOrderPanel()
        // can do this whole sub with just the food table
        // we create a view each time based on categoryID
        // no need for names and we can sort within category

        OrderButton objButton;
        try
        {
            objButton = (OrderButton)sender;
        }
        catch (Exception ex)
        {
            return;
        }

        RunFoodsRoutine(objButton);

    }

    private void RunFoodsRoutine(OrderButton objButton)
    {
        int maxMenuIndex;
        // Dim lastMaxMenuIndex As Integer
        DataRow oRow;
        int index;
        int lastButton;
        // ClearOrderPanel()
        // can do this whole sub with just the food table
        // we create a view each time based on categoryID
        // no need for names and we can sort within category

        // in case we skipped whole order we need to reset (informing we are starting new order)
        currentTable.ReferenceSIN = currentTable.SIN;
        currentTable.MiddleOfOrder = false;
        currentTable.si2 = 0;
        currentTable.Tempsi2 = 0;
        currentTable.IsPizza = false;
        // Me.pnlPizzaSplit.Visible = False
        currentTable.IsExtended = objButton.Extended;

        if (!(currentTable.Quantity == 1))
        {
            currentTable.Quantity = 1;
            testgridview.ChangeCourseButton(currentTable.Quantity);
        }
        if (currentTable.MarkForNextCustomer == true)
        {
            currentTable.CustomerNumber = currentTable.NextCustomerNumber;
            ChangeCustomerButtonColor(c9);
            if (currentTable.MarkForNewCustomerPanel == true)
            {
                AddCustomerPanel();
            }
            currentTable.MarkForNewCustomerPanel = false;
            currentTable.MarkForNextCustomer = false;
        }

        if (objButton.FunctionFlag == "F" | objButton.FunctionFlag == "O" | objButton.FunctionFlag == "G")  // objButton.Functions = 1 Or objButton.Functions = 2 Then
        {
            // Me.pnlDrinkModifier.Visible = False
            ChangeFromDrinkButtons();
            drinkPrep.Visible = false;
            pnlOrderModifier.Visible = false;
            pnlOrderModifierExt.Visible = false;
            pnlOrderDrink.Visible = false;
            pnlWineParring.Visible = true;

            if (currentTable.IsExtended == true)   // currentTerminal.TermMethod = "Quick" Then
            {
                currentTable.ActivePanel = "pnlOrderQuick";
                pnlOrder.Visible = false;
                lastButton = 59;
            }
            else
            {
                currentTable.ActivePanel = "pnlOrder";
                pnlOrderQuick.Visible = false;
                lastButton = 31;
            }

            string populatingTable;

            if (currentTable.IsPrimaryMenu == true)
            {
                populatingTable = "MainTable";
            }
            else
            {
                populatingTable = "SecondaryMainTable";
            }

            // gets the last menu index of table which is the max
            if (ds.Tables(populatingTable + objButton.CategoryID).Rows.Count > 0)
            {
                maxMenuIndex = ds.Tables(populatingTable + objButton.CategoryID).Compute("Max(MenuIndex)", ""); // Compute("Max(OrderIndex)", "")??
            }
            else
            {
                maxMenuIndex = 0;
            }
            if (currentTable.IsExtended == true)
            {
                btnOrderQuick[lastButton].MaxMenuIndex = maxMenuIndex;
                btnOrderQuick[0].MainButtonIndex = 1;
                btnOrderQuick[lastButton].MainButtonIndex = 1;
            }
            else
            {
                btnOrder[lastButton].MaxMenuIndex = maxMenuIndex;
                btnOrder[0].MainButtonIndex = 1;
                btnOrder[lastButton].MainButtonIndex = 1;
            }


            // we should change so it dims in increments of 32
            opButtonText = new string[maxMenuIndex + 64 + 1];
            opButtonId = new int[maxMenuIndex + 64 + 1];
            opButtonBackColor = new Color[maxMenuIndex + 64 + 1];
            opButtonForeColor = new Color[maxMenuIndex + 64 + 1];
            opButtonCategoryID = new int[maxMenuIndex + 64 + 1];
            opButtonHalfSplit = new bool[maxMenuIndex + 64 + 1];
            opButtonFunctionID = new int[maxMenuIndex + 64 + 1];
            opButtonFunctionGroupID = new int[maxMenuIndex + 64 + 1];
            opButtonFunFlag = new string[maxMenuIndex + 64 + 1];
            opButtonDrinkSubCat = new bool[maxMenuIndex + 64 + 1];

            foreach (DataRow currentORow in ds.Tables(populatingTable + objButton.CategoryID).Rows)
            {
                oRow = currentORow; // ("MainTable" & objButton.CategoryID).Rows
                if (oRow("menuIndex") > 0)
                {
                    index = oRow("MenuIndex");
                    opButtonText[index] = oRow("AbrevFoodName");
                    opButtonId[index] = oRow("FoodID");
                    opButtonCategoryID[index] = oRow("CategoryID");
                    opButtonHalfSplit[index] = oRow("HalfSplit");

                    opButtonFunctionID[index] = oRow("FunctionID");
                    opButtonFunctionGroupID[index] = oRow("FunctionGroupID");
                    opButtonFunFlag[index] = oRow("FunctionFlag");
                    opButtonDrinkSubCat[index] = true;
                    if (!object.ReferenceEquals(oRow("ButtonColor"), DBNull.Value))
                    {
                        opButtonBackColor[index] = Color.FromArgb(oRow("ButtonColor"));
                        opButtonForeColor[index] = Color.FromArgb(oRow("ButtonForeColor"));
                    }
                    else
                    {
                        opButtonBackColor[index] = c6;
                        opButtonForeColor[index] = c3;
                    }
                }
            }

            // ***************************************
            // ****this is within the other subroutine
            // **** this is for Drink portion of the G
            if (objButton.FunctionFlag == "G")
            {

                if (currentTable.IsPrimaryMenu == true)
                {
                    populatingTable = "DrinkMainTable";
                }
                else
                {
                    populatingTable = "DrinkMainTable";
                    // currently no Drink Secondary Table
                    // populatingTable = "DrinkSecondaryMainTable"
                }

                foreach (DataRow currentORow1 in ds.Tables(populatingTable + objButton.CategoryID).Rows)
                {
                    oRow = currentORow1; // ("MainTable" & objButton.CategoryID).Rows
                    if (oRow("menuIndex") > 0)
                    {
                        index = oRow("MenuIndex");
                        opButtonText[index] = oRow("DrinkName");
                        opButtonId[index] = oRow("DrinkID");
                        opButtonCategoryID[index] = oRow("DrinkCategoryID");
                        // opButtonHalfSplit(index) = oRow("HalfSplit")
                        opButtonFunctionID[index] = oRow("FunctionID");
                        opButtonFunctionGroupID[index] = oRow("FunctionGroupID");
                        opButtonFunFlag[index] = oRow("FunctionFlag");
                        opButtonDrinkSubCat[index] = true;
                        if (!object.ReferenceEquals(oRow("ButtonColor"), DBNull.Value))
                        {
                            opButtonBackColor[index] = Color.FromArgb(oRow("ButtonColor"));
                            opButtonForeColor[index] = Color.FromArgb(oRow("ButtonForeColor"));
                        }
                        else
                        {
                            opButtonBackColor[index] = c6;
                            opButtonForeColor[index] = c3;
                        }
                    }
                }

            }
        }

        else if (objButton.FunctionFlag == "D") // objButton.Functions >= 4 And objButton.Functions <= 7 Then
        {
            if (companyInfo.servesMixedDrinks == true)
            {
                // Me.pnlDrinkModifier.Visible = True
                // drinkPrep.Visible = True
                // Me.pnlWineParring.Visible = False
            }
            drinkPrep.Visible = false;
            pnlOrderModifier.Visible = false;
            pnlOrderModifierExt.Visible = false;
            pnlOrder.Visible = false;
            pnlOrderQuick.Visible = false;

            // pnlOrderDrink.Visible = True

            ChangeToDrinkButtons();

            if (objButton.CategoryID == -1)
            {
                opButtonText = new string[33];
                opButtonId = new int[33];
                // old?      ReDim opButtonCategoryID(maxMenuIndex + 64)
                opButtonFunctionID = new int[33];
                opButtonFunctionGroupID = new int[33];
                opButtonFunFlag = new string[33];
                opButtonBackColor = new Color[33];
                opButtonForeColor = new Color[33];
                opButtonHalfSplit = new bool[33];
                opButtonDrinkSubCat = new bool[33];

                btnOrder[31].MaxMenuIndex = 31;

                foreach (DataRow currentORow2 in dtDrinkSubCategory.Rows)
                {
                    oRow = currentORow2;
                    // index = index + 1
                    if (!object.ReferenceEquals(oRow("DrinkCategoryName"), DBNull.Value))
                    {
                        if (!(oRow("DrinkCategoryNumber") == -1))
                        {
                            opButtonText[oRow("DrinkCategoryNumber")] = oRow("DrinkCategoryName");
                            opButtonId[oRow("DrinkCategoryNumber")] = oRow("DrinkCategoryID");
                            opButtonHalfSplit[oRow("DrinkCategoryNumber")] = false;
                            opButtonDrinkSubCat[oRow("DrinkCategoryNumber")] = false;

                            opButtonFunctionID[oRow("DrinkCategoryNumber")] = objButton.Functions;      // oRow("DrinkFunctionID")
                            opButtonFunctionGroupID[oRow("DrinkCategoryNumber")] = objButton.FunctionGroup;  // oRow("FunctionGroupID")
                            opButtonFunFlag[oRow("DrinkCategoryNumber")] = objButton.FunctionFlag;       // oRow("FunctionFlag")

                            if (!object.ReferenceEquals(oRow("ButtonColor"), DBNull.Value))
                            {
                                opButtonBackColor[oRow("DrinkCategoryNumber")] = Color.FromArgb(oRow("ButtonColor"));
                                opButtonForeColor[oRow("DrinkCategoryNumber")] = Color.FromArgb(oRow("ButtonForeColor"));
                            }
                            else
                            {
                                opButtonBackColor[oRow("DrinkCategoryNumber")] = c16;
                                opButtonForeColor[oRow("DrinkCategoryNumber")] = c3;
                            }
                        }
                    }
                }
            }
            else
            {
                PopulateDrinkSubCategory(objButton);
                pnlOrder.Visible = false;
                pnlOrderQuick.Visible = false;
                pnlOrderModifier.Visible = false;
                pnlOrderModifierExt.Visible = false;
                return;
            }

        }

        GTCIndex = -1;

        // *** will not need to pass all this
        DisplayMainOrderButtons(objButton.MainButtonIndex, objButton.CategoryID, objButton.Functions, objButton.FunctionGroup, objButton.FunctionFlag, objButton.IsPrimary, objButton.FoodTableIndex);

    }

    private void ChangeToDrinkButtons()
    {

        if (companyInfo.servesMixedDrinks == true)
        {
            btnModifierAdd.Text = "Prep";
            btnModifierNo.Text = "Call";
        }
        if (drinkPrep.Visible == true & currentTable.MarkForNextCustomer == false & OpenOrdersCurrencyMan.Position > -1)
        {
            currentTable.ReferenceSIN = (int)testgridview.gridViewOrder.Item(OpenOrdersCurrencyMan.Position, 2);
        }

    }

    private void ChangeFromDrinkButtons()
    {

        if (companyInfo.servesMixedDrinks == true)
        {
            btnModifierAdd.Text = "Add";
            btnModifierNo.Text = "No";
        }
    }

    private void DisplayMainOrderButtons(int mainButtonIndex, int catID, int funID, int funGroup, string funFlag, bool isPrimary, int fti)
    {
        int index;
        // Dim mbi As Integer = mainButtonIndex
        int n = 0;
        int lastButton;


        if (currentTable.IsExtended == true) // currentTerminal.TermMethod = "Quick" Or funFlag = "G" Then
        {
            lastButton = 59;

            if (mainButtonIndex > 1)
            {
                btnOrderQuick[0].Text = "Previous";
                btnOrderQuick[0].ID = -1;
                btnOrderQuick[0].BackColor = c4;
                btnOrderQuick[0].ForeColor = c3;
                btnOrderQuick[0].Functions = funID;
                btnOrderQuick[0].FunctionGroup = funGroup;
                btnOrderQuick[0].FunctionFlag = funFlag;
                btnOrderQuick[0].CategoryID = catID;
                btnOrderQuick[0].IsPrimary = isPrimary;

                n += 1;
                // mainButtonIndex += 1
            }
            // mainButtonIndex -= 1


            var loopTo = mainButtonIndex + lastButton;
            for (index = mainButtonIndex; index <= loopTo; index++)
            {
                if (n == lastButton)
                {
                    if (btnOrderQuick[n].MaxMenuIndex > index)
                    {
                        // create MORE button
                        btnOrderQuick[n].Text = "More";
                        btnOrderQuick[n].ID = -2;
                        btnOrderQuick[n].BackColor = c4;
                        btnOrderQuick[n].ForeColor = c3;
                        btnOrderQuick[n].CategoryID = catID;
                        btnOrderQuick[n].Functions = funID;
                        btnOrderQuick[n].FunctionGroup = funGroup;
                        btnOrderQuick[n].FunctionFlag = funFlag;
                        btnOrderQuick[n].IsPrimary = isPrimary;

                        // If btnOrderQuick(31).MainButtonIndex = 0 Then
                        if (mainButtonIndex == 1)
                        {
                            btnOrderQuick[lastButton].MainButtonIndex = mainButtonIndex + lastButton + 2;
                        }
                        else
                        {
                            btnOrderQuick[lastButton].MainButtonIndex = mainButtonIndex + lastButton + 1;
                        }
                        btnOrderQuick[0].MainButtonIndex = btnOrderQuick[31].MainButtonIndex();
                        // If btnOrderQuick(0).ID = -1 Then btnOrderQuick(0).MainButtonIndex = btnOrderQuick(31).MainButtonIndex()
                        break;
                    }

                }


                if (opButtonText[index] is not null)
                {

                    btnOrderQuick[n].Text = opButtonText[index];
                    btnOrderQuick[n].ID = opButtonId[index];

                    btnOrderQuick[n].BackColor = opButtonBackColor[index]; // c4      'c2
                    btnOrderQuick[n].ForeColor = opButtonForeColor[index];    // c3      'c15
                    btnOrderQuick[n].Functions = opButtonFunctionID[index];   // funID
                    btnOrderQuick[n].FunctionGroup = opButtonFunctionGroupID[index];  // funGroup
                    btnOrderQuick[n].FunctionFlag = opButtonFunFlag[index];  // funFlag

                    if (catID == -1)
                    {
                        btnOrderQuick[n].CategoryID = opButtonId[index]; // need this duplication for drinks   
                    }
                    else
                    {
                        // have no idea if this is correct
                        btnOrderQuick[n].CategoryID = opButtonCategoryID[index];
                    }  // catID
                    btnOrderQuick[n].HalfSplit = opButtonHalfSplit[index];
                    btnOrderQuick[n].SubCategory = opButtonDrinkSubCat[index];    // False
                    btnOrderQuick[n].IsPrimary = isPrimary;
                    btnOrderQuick[n].FoodTableIndex = fti;
                    // If objButton.Name = "Drinks" Then
                    // btnOrderQuick(index).DrinkCategory = True
                    // '    Else
                    // btnOrderQuick(index).DrinkCategory = False
                    // End If
                    btnOrderQuick[n].Invalidate();
                }
                else
                {
                    // If Not btnOrderQuick(index).ID = 0 Then  'this might be opButtonID(index)=0 ???
                    // ********** I have no idea what this is for *********
                    {
                        ref var withBlock = ref btnOrderQuick[n];
                        withBlock.Text = (object)null;
                        withBlock.ID = (object)null;
                        withBlock.BackColor = c13;    // c8
                        withBlock.DrinkCategory = false;          // probably remove subst w/ functions
                        withBlock.HalfSplit = false;
                        withBlock.SubCategory = false;
                        withBlock.Functions = (object)null;         // this is a test
                        withBlock.FunctionFlag = (object)null;
                        withBlock.FunctionGroup = (object)null;
                        withBlock.IsPrimary = isPrimary;
                    }
                    btnOrderQuick[n].Invalidate();
                    // End If
                }
                n += 1;
                if (n == lastButton + 1)
                    break; // must have this for 2nd page b/c index starts at 1
            }

            pnlOrderQuick.Visible = true;
        }

        else        // this is NOT extended view(general category)
        {
            lastButton = 31;

            if (mainButtonIndex > 1)
            {
                btnOrder[0].Text = "Previous";
                btnOrder[0].ID = -1;
                btnOrder[0].BackColor = c4;
                btnOrder[0].ForeColor = c3;
                btnOrder[0].Functions = funID;
                btnOrder[0].FunctionGroup = funGroup;
                btnOrder[0].FunctionFlag = funFlag;
                btnOrder[0].CategoryID = catID;
                btnOrder[0].IsPrimary = isPrimary;

                n += 1;
                // mainButtonIndex += 1
            }
            // mainButtonIndex -= 1


            var loopTo1 = mainButtonIndex + lastButton;
            for (index = mainButtonIndex; index <= loopTo1; index++)
            {
                if (n == lastButton)
                {
                    if (btnOrder[n].MaxMenuIndex > index)
                    {
                        // create MORE button
                        btnOrder[n].Text = "More";
                        btnOrder[n].ID = -2;
                        btnOrder[n].BackColor = c4;
                        btnOrder[n].ForeColor = c3;
                        btnOrder[n].CategoryID = catID;
                        btnOrder[n].Functions = funID;
                        btnOrder[n].FunctionGroup = funGroup;
                        btnOrder[n].FunctionFlag = funFlag;
                        btnOrder[n].IsPrimary = isPrimary;

                        // If btnOrder(31).MainButtonIndex = 0 Then
                        if (mainButtonIndex == 1)
                        {
                            btnOrder[lastButton].MainButtonIndex = mainButtonIndex + lastButton + 2;
                        }
                        else
                        {
                            btnOrder[lastButton].MainButtonIndex = mainButtonIndex + lastButton + 1;
                        }
                        btnOrder[0].MainButtonIndex = btnOrder[31].MainButtonIndex();
                        // If btnOrder(0).ID = -1 Then btnOrder(0).MainButtonIndex = btnOrder(31).MainButtonIndex()
                        break;
                    }

                }


                if (opButtonText[index] is not null)
                {

                    btnOrder[n].Text = opButtonText[index];
                    btnOrder[n].ID = opButtonId[index];

                    btnOrder[n].BackColor = opButtonBackColor[index]; // c4      'c2
                    btnOrder[n].ForeColor = opButtonForeColor[index];    // c3      'c15
                    btnOrder[n].Functions = opButtonFunctionID[index];   // funID
                    btnOrder[n].FunctionGroup = opButtonFunctionGroupID[index];  // funGroup
                    btnOrder[n].FunctionFlag = opButtonFunFlag[index];  // funFlag

                    if (catID == -1)
                    {
                        btnOrder[n].CategoryID = opButtonId[index]; // need this duplication for drinks   
                    }
                    else
                    {
                        // have no idea if this is correct
                        btnOrder[n].CategoryID = opButtonCategoryID[index];
                    }  // catID
                    btnOrder[n].HalfSplit = opButtonHalfSplit[index];
                    btnOrder[n].SubCategory = opButtonDrinkSubCat[index];    // False
                    btnOrder[n].IsPrimary = isPrimary;
                    btnOrder[n].FoodTableIndex = fti;
                    // If objButton.Name = "Drinks" Then
                    // btnOrder(index).DrinkCategory = True
                    // '    Else
                    // btnOrder(index).DrinkCategory = False
                    // End If
                    btnOrder[n].Invalidate();
                }
                else
                {
                    // If Not btnOrder(index).ID = 0 Then  'this might be opButtonID(index)=0 ???
                    // ********** I have no idea what this is for *********
                    {
                        ref var withBlock1 = ref btnOrder[n];
                        withBlock1.Text = (object)null;
                        withBlock1.ID = (object)null;
                        withBlock1.BackColor = c13;    // c8
                        withBlock1.DrinkCategory = false;          // probably remove subst w/ functions
                        withBlock1.HalfSplit = false;
                        withBlock1.SubCategory = false;
                        withBlock1.Functions = (object)null;         // this is a test
                        withBlock1.FunctionFlag = (object)null;
                        withBlock1.FunctionGroup = (object)null;
                        withBlock1.IsPrimary = isPrimary;
                    }
                    btnOrder[n].Invalidate();
                    // End If
                }
                n += 1;
                if (n == lastButton + 1)
                    break; // must have this for 2nd page b/c index starts at 1
            }

            if (btnOrder[0].FunctionFlag == "D" & btnOrder[0].SubCategory == false)
            {
                pnlOrderDrink.Visible = false;
                pnlOrderQuick.Visible = false;
            }
            pnlOrder.Visible = true;


        }
        // ??????????
        // If btnOrder(0).ID = -1 Then btnOrder(0).MainButtonIndex = btnOrder(31).MainButtonIndex()

    }

    private object EndOfItem(bool resetCurrentTable)
    {

        // MsgBox("this is end of item   " & resetCurrentTable)

        // check for req modifiers
        if (currentTable.ReqModifier == true)
        {
            if (Interaction.MsgBox("Must Select Modifier", MsgBoxStyle.OkCancel) == MsgBoxResult.Ok)
            {

                return false;
            }
            else
            {
                // delete last Complete Item
                testgridview.DeleteItem(currentTable.ReferenceSIN, currentTable.ReferenceSIN);
                currentTable.ReqModifier = false;
                resetCurrentTable = true;
                // will skip any invMultiplier info on purpose
            }
        }

        // change InvMultiplier information
        else if (!(currentTable.InvMultiplier == 1))    // only change inventory if Modifier was not required
                                                        // Or Not currentTable.Quantity = 1 Then
        {
            foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
            {
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (oRow("sii") == currentTable.ReferenceSIN)
                    {
                        // ****     oRow("InvMultiplier") = currentTable.InvMultiplier
                        // oRow("Quantity") = currentTable.Quantity
                        oRow("OpenDecimal1") = currentTable.InvMultiplier;
                    }
                }
            }

        }

        // null all current table info
        // make sure to display correct panel

        if (resetCurrentTable == true)
        {
            currentTable.ReferenceSIN = currentTable.SIN;
            currentTable.MiddleOfOrder = false;
            currentTable.si2 = 0;
            currentTable.Tempsi2 = 0;
            currentTable.IsPizza = false;
            freeFoodActive = false;
            currentTable.InvMultiplier = 1;
            // GTCIndex = -1 done in PutUsInNormalMode
            PutUsInNormalMode();

            if (currentTable.IsPizza == false)
            {
                pnlPizzaSplit.Visible = false;    // ***** added???  8/29/2007
                pnlWineParring.Visible = true;
            }

            pnlOrderModifier.Visible = false;
            pnlOrderModifierExt.Visible = false;
            drinkPrep.Visible = false;

            // **********  i think, if this is end of Food only 
            // If currentTable.IsExtended = True Then
            // pnlOrderQuick.Visible = True
            // Else 
            // pnlOrder.Visible = True
            // End If
            switch (currentTable.ActivePanel)
            {
                case "pnlOrderQuick":
                    {
                        pnlOrderQuick.Visible = true;
                        break;
                    }
                case "pnlOrder":
                    {
                        pnlOrder.Visible = true;
                        break;
                    }
                case "pnlOrderDrink":
                    {
                        pnlOrderDrink.Visible = true;
                        break;
                    }

                default:
                    {
                        currentTable.ActivePanel = (object)null;
                        break;
                    }
            }

            // pnlDescription.Visible = False
            if (!(currentTable.Quantity == 1))
            {
                currentTable.Quantity = 1;
                testgridview.ChangeCourseButton(currentTable.Quantity);
            }
            // PutUsInNormalMode()
            if (currentTable.MarkForNextCustomer == true)
            {
                currentTable.CustomerNumber = currentTable.NextCustomerNumber;
                ChangeCustomerButtonColor(c9);
                if (currentTable.MarkForNewCustomerPanel == true)
                {
                    AddCustomerPanel();
                }
                currentTable.MarkForNewCustomerPanel = false;
                currentTable.MarkForNextCustomer = false;
            }

            return true; // tells that we can end Item
        }
        else
        {
            return true;
        }

    }

    private void ModifierClick222(object sender, EventArgs e)
    {
        // 4 add item/detail to current order
        // 5 add item/detail to new order
        // 6 description
        // ClearOrderPanel()
        // dvFreeFood.Dispose()
        UserControlHit();
        if (ADDorNOmode == false)
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(EndOfItem(true), false, false)))
                return;
        }

        int index;
        DataRowView vRow;
        OrderButton objButton;

        try
        {
            objButton = (OrderButton)sender;
        }
        catch (Exception ex)
        {
            return;
        }

        // we don't need a food item
        {
            var withBlock = dvCategoryModifiers;
            withBlock.Table = ds.Tables("ModifierTable" + objButton.CategoryID);
            // .RowFilter = "MenuIndex > 0"
            withBlock.Sort = "MenuIndex";
        }

        if (dvCategoryModifiers.Count > 0)
        {
            SelectModifier(0, ref dvCategoryModifiers, 0, "Food", 0, dvCategoryModifiers[0]("Extended"));
            // not sure if we should use (like PerformModifierLoop): dvCategoryJoin(i)("Extended")
        }

    }

    private void BtnOrder_Click(object sender, EventArgs e) // Handles pnlOrder.Click
    {
        UserControlHit();
        if (currentTable.IsClosed == true)
            return; // can't order on closed check

        // Me.testgridview.gridViewOrder.CurrentRowIndex = OpenOrdersCurrencyMan.Position

        OrderButton objButton;
        int index;
        try
        {
            objButton = (OrderButton)sender;
        }
        catch (Exception ex)
        {
            return;
        }

        if (objButton.HalfSplit == true)
        {
            currentTable.TempReferenceSIN = currentTable.ReferenceSIN;
            currentTable.SecondRound = false;
            onlyHalf = false;
            PizzaRoutine(1);
        }
        else
        {
            currentTable.si2 = 0;
            currentTable.Tempsi2 = 0;
            currentTable.IsPizza = false;
            pnlPizzaSplit.Visible = false;
            pnlWineParring.Visible = true;
        }

        // this should be changed: currently it go back 2 pages for 3 page views
        if (objButton.ID == -1)
        {
            if (objButton.MainButtonIndex == 34)
            {
                objButton.MainButtonIndex -= 33;
            }
            else
            {
                // objButton.MainButtonIndex -= 30
                objButton.MainButtonIndex = 1;
                // If btnOrder(31).ID = -2 Then btnOrder(31).MainButtonIndex = objButton.MainButtonIndex
            }   // -= 61
            // may have to add code for btn(31) = btn(0)
            DisplayMainOrderButtons(objButton.MainButtonIndex, objButton.CategoryID, objButton.Functions, objButton.FunctionGroup, objButton.FunctionFlag, objButton.IsPrimary, objButton.FoodTableIndex);
            // PopulateMainOrderButtons(objButton)
            return;
        }
        else if (objButton.ID == -2)
        {
            DisplayMainOrderButtons(objButton.MainButtonIndex, objButton.CategoryID, objButton.Functions, objButton.FunctionGroup, objButton.FunctionFlag, objButton.IsPrimary, objButton.FoodTableIndex);
            // PopulateMainOrderButtons(objButton)
            return;
        }


        currentTable.MiddleOfOrder = true;

        if (objButton.FunctionFlag == "D") // objButton.Functions >= 4 And objButton.Functions <= 7 Then
        {

            // *** for Drink
            if (objButton.SubCategory == true & objButton.ID > 0)
            {

                var currentItem = new SelectedItemDetail();
                bool drinkAddOnBoolean = false;

                // *** step 4 ***
                // Select Drink Adds


                if (objButton.DrinkAdds == true)    // if true we have gone through this step once
                {
                    // now we are returning to choose drink add
                    // dvDrink = New DataView(ds.Tables("DrinkAdds"), "DrinkID ='" & objButton.ID & "'", "DrinkID", DataViewRowState.CurrentRows)

                    {
                        var withBlock = dvDrink;
                        withBlock.Table = ds.Tables("DrinkAdds");
                        withBlock.RowFilter = "DrinkID ='" + objButton.ID + "'";
                        withBlock.Sort = "DrinkID";
                    }
                    // If dvDrink.Count > 0 Then

                    drinkAddOnBoolean = true; // (dvDrink(0)("DrinkAddOnChoice"))
                    currentTable.InvMultiplier *= dvDrink[0]("InvMultiplier");

                    currentItem.ID = dvDrink[0]("DrinkID");
                    if (currentTable.OrderingStatus == "NO")
                    {
                        currentItem.Name = " *** " + currentTable.OrderingStatus + " " + dvDrink[0]("DrinkName");
                        currentItem.TerminalName = " *** " + currentTable.OrderingStatus + " " + dvDrink[0]("DrinkName");
                        currentItem.ChitName = " *** " + currentTable.OrderingStatus + " " + dvDrink[0]("DrinkName");
                        currentItem.Price = 0;
                        currentItem.Quantity = -1 * currentTable.Quantity;
                        currentItem.InvMultiplier = -1 * currentTable.InvMultiplier;

                        if (!(currentTerminal.TermMethod == "Quick"))
                        {
                            PutUsInNormalMode();
                            pnlMain.Visible = true;
                            pnlMain3.Visible = false;
                        }
                    }

                    else
                    {
                        currentItem.Quantity = 1 * currentTable.Quantity;
                        currentItem.InvMultiplier = currentTable.InvMultiplier;
                        currentItem.Name = "  " + dvDrink[0]("DrinkName");
                        currentItem.TerminalName = "  " + dvDrink[0]("DrinkName");
                        currentItem.ChitName = "  " + dvDrink[0]("DrinkName");
                        if (!object.ReferenceEquals(dvDrink[0]("AddOnPrice"), DBNull.Value))
                        {
                            currentItem.Price = dvDrink[0]("AddOnPrice") * currentTable.Quantity;
                        }
                        else
                        {
                            currentItem.Price = 0;
                        }
                    }

                    // .TaxID = dvDrink(0)("TaxID")
                    currentItem.Category = dvDrink[0]("DrinkCategoryID");
                    currentItem.ItemStatus = 0;
                    currentItem.FunctionID = dvDrink[0]("DrinkFunctionID"); // objButton.Functions
                    currentItem.FunctionGroup = dvDrink[0]("FunctionGroupID");
                    currentItem.FunctionFlag = dvDrink[0]("FunctionFlag");    // objButton.FunctionFlag
                    if (!object.ReferenceEquals(dvDrink[0]("DrinkRoutingID"), DBNull.Value))    // currentTable.DrinkRouting = 0 And
                    {
                        currentItem.RoutingID = dvDrink[0]("DrinkRoutingID");
                    }
                    else
                    {
                        currentItem.RoutingID = currentTable.DrinkRouting;
                    }

                    currentItem.SIN = currentTable.SIN;
                    currentItem.SII = currentTable.ReferenceSIN;
                    currentItem.si2 = currentTable.si2;
                }

                else
                {
                    // *** step 2 ***
                    // Select a Drink Choice (when subCategory true but drinkAdds false)
                    ChangeToDrinkButtons();

                    if (!(currentTable.Quantity == 1))
                    {
                        currentTable.Quantity = 1;
                        testgridview.ChangeCourseButton(currentTable.Quantity);
                    }

                    // dvDrink = New DataView(ds.Tables("Drink"), "DrinkID ='" & objButton.ID & "'", "DrinkID", DataViewRowState.CurrentRows)
                    {
                        var withBlock1 = dvDrink;
                        withBlock1.Table = ds.Tables("Drink");
                        withBlock1.RowFilter = "DrinkID ='" + objButton.ID + "'";
                        withBlock1.Sort = "DrinkID";
                    }
                    drinkAddOnBoolean = dvDrink[0]("DrinkAddOnChoice");
                    currentTable.InvMultiplier *= dvDrink[0]("InvMultiplier");
                    lblRecipe.Text = dvDrink[0]("DrinkDesc");

                    currentItem.ID = dvDrink[0]("DrinkID");
                    if (currentTable.OrderingStatus == "NO")
                    {
                        currentItem.Quantity = currentTable.Quantity * -1;
                        currentItem.InvMultiplier = -1 * currentTable.InvMultiplier;
                        currentItem.Name = " *** " + currentTable.OrderingStatus + " " + dvDrink[0]("DrinkName");
                        currentItem.TerminalName = " *** " + currentTable.OrderingStatus + " " + dvDrink[0]("DrinkName");
                        currentItem.ChitName = " *** " + currentTable.OrderingStatus + " " + dvDrink[0]("DrinkName");
                        currentItem.Price = 0;
                        if (!(currentTerminal.TermMethod == "Quick"))
                        {
                            PutUsInNormalMode();
                            pnlMain.Visible = true;
                            pnlMain3.Visible = false;
                        }
                    }

                    else if (currentTable.OrderingStatus == "Call")
                    {
                        // ddd
                        currentItem.Quantity = currentTable.Quantity;
                        currentItem.InvMultiplier = currentTable.InvMultiplier;
                        currentItem.Name = dvDrink[0]("DrinkName");
                        currentItem.TerminalName = "   " + dvDrink[0]("DrinkName");
                        currentItem.ChitName = "   " + dvDrink[0]("DrinkName");
                        if (!object.ReferenceEquals(dvDrink[0]("CallPrice"), DBNull.Value))
                        {
                            currentItem.Price = dvDrink[0]("CallPrice") * currentTable.Quantity;
                        }
                        else
                        {
                            currentItem.Price = 0;
                        }
                        // this removes the inventory count for main item
                        // all inventory will be from call, 
                        // should build something so you can't delete the call w/o the main
                        foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
                        {
                            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                            {
                                if (oRow("sin") == currentTable.ReferenceSIN)
                                {
                                    oRow("OpenDecimal1") = 0;
                                }
                            }
                        }

                        objButton.CategoryID = previousCategory;
                        objButton.BackColor = c4;
                        objButton.ForeColor = c3;
                        PutUsInNormalMode();
                        drinkAddOnBoolean = false;

                        PopulateDrinkSubCategory(objButton);
                    }

                    else
                    {
                        currentItem.Quantity = currentTable.Quantity;
                        currentItem.InvMultiplier = currentTable.InvMultiplier;
                        currentItem.Name = dvDrink[0]("DrinkName");
                        currentItem.TerminalName = dvDrink[0]("DrinkName");
                        currentItem.ChitName = dvDrink[0]("DrinkName");
                        if (!object.ReferenceEquals(dvDrink[0]("DrinkPrice"), DBNull.Value))
                        {
                            currentItem.Price = dvDrink[0]("DrinkPrice") * currentTable.Quantity;
                        }
                        else
                        {
                            currentItem.Price = 0;
                        }

                    }

                    // .TaxID = dvDrink(0)("TaxID")
                    currentItem.Category = dvDrink[0]("DrinkCategoryID");
                    currentItem.ItemStatus = 0;
                    currentItem.FunctionID = dvDrink[0]("DrinkFunctionID"); // objButton.Functions
                    currentItem.FunctionGroup = dvDrink[0]("FunctionGroupID");
                    currentItem.FunctionFlag = dvDrink[0]("FunctionFlag");  // objButton.FunctionFlag

                    if (!object.ReferenceEquals(dvDrink[0]("DrinkRoutingID"), DBNull.Value))        // currentTable.DrinkRouting = 0 And
                    {
                        currentItem.RoutingID = dvDrink[0]("DrinkRoutingID");
                    }
                    else
                    {
                        currentItem.RoutingID = currentTable.DrinkRouting;
                    }
                    currentItem.SIN = currentTable.SIN;
                    currentItem.SII = currentTable.ReferenceSIN;
                    currentItem.si2 = currentTable.si2;
                    // End If
                    // End If

                }
                // MsgBox(dvDrink(0)("DrinkAddID"))


                // If currentTable.IsTabNotTable = False Then
                // .Table = currentTable.TableNumber
                // Else
                // .Table = currentTable.TabID
                // End If
                currentItem.Check = currentTable.CheckNumber;
                currentItem.Customer = currentTable.CustomerNumber;

                currentItem.Course = currentTable.CourseNumber;



                AddItemToOrderTable(ref currentItem);
                testgridview.CalculateSubTotal();
                currentTable.SIN += 1;
                // If objButton.DrinkAdds = False Then
                // currentTable.ReferenceSIN = currentTable.SIN
                // End If


                // *** step 3 ***
                // Populates Drink Adds if necessary
                // If objButton.DrinkAdds = False Then
                if (drinkAddOnBoolean == true)
                {

                    // 444      SelectDrinkAdds(objButton.ID, objButton.CategoryID, currentItem.RoutingID, objButton.Functions, objButton.FunctionGroup)
                    SelectDrinkAdds(currentItem.ID, currentItem.Category, currentItem.RoutingID, currentItem.FunctionID, currentItem.FunctionGroup);
                    currentTable.MiddleOfOrder = true;   // ????      ' will become false below if no adds

                    if (!(currentTable.Quantity == 1))
                    {
                        currentTable.Quantity = 1;
                        testgridview.ChangeCourseButton(currentTable.Quantity);
                    }
                    if (currentTable.MarkForNextCustomer == true)
                    {
                        currentTable.CustomerNumber = currentTable.NextCustomerNumber;
                        ChangeCustomerButtonColor(c9);
                        if (currentTable.MarkForNewCustomerPanel == true)
                        {
                            AddCustomerPanel();
                        }
                        currentTable.MarkForNewCustomerPanel = false;
                        currentTable.MarkForNextCustomer = false;
                    }
                    return;
                }
                else
                {
                    currentTable.ReferenceSIN = currentTable.SIN;
                    // currentTable.SIN += 1
                    // currentTable.MiddleOfOrder = False
                }
                // Else
                // currentTable.ReferenceSIN = currentTable.SIN
                // currentTable.SIN += 1
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(EndOfItem(true), false, false)))
                    return;
                currentTable.MiddleOfOrder = false;
                currentTable.si2 = 0;
                currentTable.Tempsi2 = 0;
                currentTable.IsPizza = false;
                // Me.pnlPizzaSplit.Visible = False

                if (!(currentTable.Quantity == 1))
                {
                    currentTable.Quantity = 1;
                    testgridview.ChangeCourseButton(currentTable.Quantity);
                }
                if (currentTable.MarkForNextCustomer == true)
                {
                    currentTable.CustomerNumber = currentTable.NextCustomerNumber;
                    ChangeCustomerButtonColor(c9);
                    if (currentTable.MarkForNewCustomerPanel == true)
                    {
                        AddCustomerPanel();
                    }
                    currentTable.MarkForNewCustomerPanel = false;
                    currentTable.MarkForNextCustomer = false;
                }
                // End If
                // MsgBox(objButton.ID)



                // ************
                // testing
                // Me.PopulateDrinkSubCategory(objButton)
                // ResetDrinkCategories()
                return;
            }
            // ClearOrderPanel()


            // *** step 1 ***
            // Populates the drink choices based on selected category
            // When: DrinkCategory is true and subCategory is false
            else
            {
                PopulateDrinkSubCategory(objButton);
            }
        }

        // *** for food items ***
        else if (objButton.ID > 0)
        {

            // 666         If objButton.FunctionFlag = "M" Then
            // With dvCategoryModifiers
            // .Table = ds.Tables("ModifierTable" & objButton.CategoryID)
            // .Sort = "MenuIndex"
            // End With

            // If dvCategoryModifiers.Count > 0 Then
            // SelectModifier(0, dvCategoryModifiers, 0, "Food", 0, dvCategoryModifiers(0)("Extended"))
            // End If
            // Exit Sub
            // End If

            lblWineParring.Text = "";
            lblRecipe.Text = "";
            if (!(currentTable.Quantity == 1))
            {
                currentTable.Quantity = 1;
                testgridview.ChangeCourseButton(currentTable.Quantity);
            }

            var currentItem = new SelectedItemDetail();
            string populatingTable;

            if (currentTable.IsPrimaryMenu == true)
            {
                populatingTable = "MainTable";
                cntModifierLoop = mainCategoryIDArrayList.Count;
            }
            else
            {
                populatingTable = "SecondaryMainTable";
                cntModifierLoop = secondaryCategoryIDArrayList.Count;
            }
            // If typeProgram = "Online_Demo" Then
            // cntModifierLoop = 30
            // End If
            // dvFood = New DataView(ds.Tables(populatingTable & objButton.CategoryID), "FoodID ='" & objButton.ID & "'", "FoodID", DataViewRowState.CurrentRows)

            {
                var withBlock2 = dvFood;
                withBlock2.Table = ds.Tables(populatingTable + objButton.CategoryID);
                withBlock2.RowFilter = "FoodID ='" + objButton.ID + "'";
                withBlock2.Sort = "FoodID";
            }

            if (dvFood.Count > 0)
            {
                // ************
                // dvFood should change to use only the datatable
                // since we know which table we use now just use that
                if (dvFood[0]("WineParringID") > 0)
                {
                    string wpiText;
                    foreach (DataRow oRow in ds.Tables("Drink").Rows)
                    {
                        if (oRow("DrinkID") == dvFood[0]("WineParringID"))
                        {
                            wpiText = oRow("DrinkName") + "  (" + oRow("DrinkDesc") + ")";
                            lblWineParring.Text = wpiText;
                        }
                    }
                }
                lblRecipe.Text = dvFood[0]("FoodDesc");
                currentTable.InvMultiplier *= dvFood[0]("InvMultiplier");

                currentItem.ID = dvFood[0]("FoodID");
                if (currentTable.OrderingStatus == "NO")
                {
                    currentItem.Quantity = currentTable.Quantity * -1;
                    currentItem.InvMultiplier = -1 * currentTable.InvMultiplier;
                    currentItem.Name = " *** " + currentTable.OrderingStatus + " " + dvFood[0]("AbrevFoodName");
                    currentItem.TerminalName = " *** " + currentTable.OrderingStatus + " " + dvFood[0]("AbrevFoodName");
                    currentItem.ChitName = " *** " + currentTable.OrderingStatus + " " + dvFood[0]("ChitFoodName");
                    currentItem.Price = 0;
                }
                // PutUsInNormalMode()
                // .FunctionID = 0
                // .FunctionGroup = 0
                else
                {
                    currentItem.Quantity = currentTable.Quantity;
                    currentItem.InvMultiplier = currentTable.InvMultiplier;
                    currentItem.Name = dvFood[0]("AbrevFoodName");
                    currentItem.TerminalName = dvFood[0]("AbrevFoodName");
                    currentItem.ChitName = dvFood[0]("ChitFoodName");
                    if (!(currentTable.CurrentMenu == currentTerminal.currentPrimaryMenuID))
                    {
                        currentItem.TerminalName = currentItem.Name + "  * " + currentTable.CurrentMenuName.ToUpper;
                        currentItem.ChitName = currentItem.ChitName + "  * " + currentTable.CurrentMenuName.ToUpper;
                    }
                    currentItem.Price = dvFood[0]("Price") * currentTable.Quantity;
                    if (dvFood[0]("TaxExempt") == true)
                    {
                        currentItem.TaxID = -1;
                    }


                }
                currentItem.FunctionID = dvFood[0]("FunctionID"); // objButton.Functions
                currentItem.FunctionGroup = dvFood[0]("FunctionGroupID"); // objButton.FunctionGroup
                currentItem.FunctionFlag = dvFood[0]("FunctionFlag");  // objButton.FunctionFlag
                currentItem.Category = dvFood[0]("CategoryID");
                if (!object.ReferenceEquals(dvFood[0]("RoutingID"), DBNull.Value))
                {
                    currentItem.RoutingID = dvFood[0]("RoutingID");
                }
                else
                {
                    currentItem.RoutingID = 0;
                }
                if (!object.ReferenceEquals(dvFood[0]("PrintPriorityID"), DBNull.Value))
                {
                    currentItem.PrintPriorityID = dvFood[0]("PrintPriorityID");
                }
                else
                {
                    currentItem.PrintPriorityID = 0;


                }
                // the above code has to change FoodCost *** it has to be dependant on menu

                // If currentTable.IsTabNotTable = False Then
                // .Table = currentTable.TableNumber
                // Else
                // .Table = currentTable.TabID
                // End If
                currentItem.Check = currentTable.CheckNumber;
                currentItem.Customer = currentTable.CustomerNumber;
                currentItem.Course = currentTable.CourseNumber;
                currentItem.SIN = currentTable.SIN;
                currentItem.SII = currentTable.SIN;

                currentItem.si2 = currentTable.si2;
                currentTable.ReferenceSIN = currentTable.SIN;
                // currentTable.MiddleOfOrder = False
                currentTable.SIN += 1;

                // 444        pnlOrder.Visible = False
                // 444        pnlOrderQuick.Visible = False
                // 444    pnlOrderDrink.Visible = False
                AddItemToOrderTable(ref currentItem);
                testgridview.CalculateSubTotal();

                // ********************
                // PerformModifierLoop()

                StartModifierLoop(currentItem.ID);

            }
        }

    }

    private void StartModifierLoop(int fID)
    {
        var i = default(int);
        modifierIndex = 0;
        performedIndividualJoinTest = false;

        // dvIndividualJoinGroup = New DataView

        if (currentTable.IsPrimaryMenu == true)
        {
            {
                var withBlock = dvIndividualJoinGroup;
                withBlock.Table = ds.Tables("IndividualJoinMain");
                withBlock.RowFilter = "FoodID = '" + fID + "'";
                withBlock.Sort = "MenuIndex";
            }
        }
        else
        {
            {
                var withBlock1 = dvIndividualJoinGroup;
                withBlock1.Table = ds.Tables("IndividualJoinSecondary");
                withBlock1.RowFilter = "FoodID = '" + fID + "'";
                withBlock1.Sort = "MenuIndex";
            }
        }

        // dvCategoryJoin = New DataView
        {
            var withBlock2 = dvCategoryJoin;
            withBlock2.Table = ds.Tables("CategoryJoin");
            withBlock2.RowFilter = "FoodID = '" + fID + "'";
            withBlock2.Sort = "Priority, FreeFlag";        // "MenuIndex" '
        }

        categoryIndex = new bool[dvCategoryJoin.Count + 1];
        foreach (DataRowView vRow in dvCategoryJoin)
        {
            categoryIndex[i] = true;
            i += 1;
        }

        if (dvIndividualJoinGroup.Count + dvCategoryJoin.Count > 0)
        {
            pnlOrder.Visible = false;
            pnlOrderQuick.Visible = false;
            pnlOrderDrink.Visible = false;
        }

        if (currentTable.OrderingStatus == "NO")
        {
            // *** not sure about
            // ADDorNOmode = False
            // btnModifierAdd.BackColor = c4
            // btnModifierNo.BackColor = c4

            // currentTable.OrderingStatus = Nothing
            if (!(currentTerminal.TermMethod == "Quick"))
            {
                PutUsInNormalMode();
            }
        }
        // 
        else
        {
            PerformModifierLoop(fID);
        }


    }

    private void PizzaRoutine(int valuesi2)
    {

        currentTable.IsPizza = true;
        CreateDataViewsPizza();
        // Me.onFullPizza.DataSource = dvPizzaFull
        // Me.onFirstHalf.DataSource = dvPizzaFirst
        // Me.onSecondHalf.DataSource = dvPizzaSecond
        pnlPizzaSplit.Visible = true;
        // Me.pnlDrinkModifier.Visible = False
        drinkPrep.Visible = false;
        pnlWineParring.Visible = false;

        if (valuesi2 == 1)
        {
            pnlOnFullPizza.BackColor = c18;
            pnlOnFirstHalf.BackColor = c3;
            pnlOnSecondHalf.BackColor = c3;
            currentTable.si2 = 1;
        }
        else if (valuesi2 == 2)
        {
            pnlOnFullPizza.BackColor = c3;
            pnlOnFirstHalf.BackColor = c18;
            pnlOnSecondHalf.BackColor = c3;
            currentTable.si2 = 2;
        }
        else if (valuesi2 == 3)
        {
            pnlOnFullPizza.BackColor = c3;
            pnlOnFirstHalf.BackColor = c3;
            pnlOnSecondHalf.BackColor = c18;
            currentTable.si2 = 3;
        }

        if (currentTable.SecondRound == true)
        {
            var fID = default(int);

            foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
            {
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (oRow("sin") == currentTable.ReferenceSIN)
                    {
                        // if we do this with drinks we will need to distinguish between food
                        fID = oRow("ItemID");
                        break;
                    }
                }
            }
            pnlOrder.Visible = false;
            pnlOrderQuick.Visible = false;
            pnlOrderDrink.Visible = false;
            drinkPrep.Visible = false;
            StartModifierLoop(fID);
            // PerformModifierLoop(fID)
            // currentTable.SecondRound = False
        }

        onFullPizza.SelectedIndex = -1;
        onFirstHalf.SelectedIndex = -1;
        onSecondHalf.SelectedIndex = -1;

    }

    // Private Sub BtnOrderDrink_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlOrderDrink.Click
    // 
    // End Sub

    private void PopulateDrinkSubCategory(OrderButton objButton)
    {
        var opButtonText = new string[61];      // changed 
        var opButtonID = new int[61];
        var opButtonBackColor = new object[61];
        var opButtonForeColor = new object[61];
        // Dim opButtonCategoryID(maxMenuIndex + 64)
        // Dim opButtonFunctionID(maxMenuIndex + 64)
        // Dim opButtonFunctionGroupID(maxMenuIndex + 64)
        // Dim opButtonFunFlag(maxMenuIndex + 64)
        // Dim opButtonDrinkSubCat(maxMenuIndex + 64))

        int index;

        if (objButton.CategoryID > 0)
        {
            // dvDrink = New DataView(ds.Tables("Drink"), "DrinkCategoryID ='" & objButton.CategoryID & "'", "DrinkID", DataViewRowState.CurrentRows)
            // PopulateDrinkTable(objButton.ID)
            {
                var withBlock = dvDrink;
                withBlock.Table = ds.Tables("Drink");
                withBlock.RowFilter = "DrinkCategoryID ='" + objButton.CategoryID + "'";
                withBlock.Sort = "DrinkID";
            }

            foreach (DataRowView vRow in dvDrink)
            {
                opButtonText[vRow("DrinkIndex")] = vRow("DrinkName");
                opButtonID[vRow("DrinkIndex")] = vRow("DrinkID");
                // not sure if this is always right
                // opButtonBackColor(vRow("DrinkIndex")) = objButton.BackColor
                // opButtonForeColor(vRow("DrinkIndex")) = objButton.ForeColor

            }
        }

        pnlOrder.Visible = false;
        pnlOrderQuick.Visible = false;

        // index = 0
        for (index = 1; index <= 60; index++) // 48
        {
            if (opButtonText[index] is null)
            {
                btnOrderDrink[index].Text = (object)null;
                btnOrderDrink[index].ID = (object)null;
                btnOrderDrink[index].CategoryID = (object)null;
                btnOrderDrink[index].SubCategory = true;      // probably false
                // btnOrderDrink(index).DrinkAdds = False
                btnOrderDrink[index].Functions = (object)null;
                btnOrderDrink[index].FunctionGroup = (object)null;
                btnOrderDrink[index].FunctionFlag = (object)null;

                btnOrderDrink[index].BackColor = c13;    // c8
            }
            else
            {
                btnOrderDrink[index].Text = opButtonText[index];
                btnOrderDrink[index].ID = opButtonID[index];
                btnOrderDrink[index].CategoryID = objButton.CategoryID;
                btnOrderDrink[index].SubCategory = true;
                // btnOrderDrink(index).DrinkAdds = objButton.DrinkAdds
                btnOrderDrink[index].Functions = objButton.Functions;
                btnOrderDrink[index].FunctionGroup = objButton.FunctionGroup;
                btnOrderDrink[index].FunctionFlag = objButton.FunctionFlag;
                btnOrderDrink[index].BackColor = objButton.BackColor;    // c4
                btnOrderDrink[index].ForeColor = objButton.ForeColor;

            }    // c3
        }
        // objButton.DrinkCategory = False
        pnlOrderDrink.Visible = true;
        currentTable.ActivePanel = "pnlOrderDrink";
        // pnlOrder.Visible = True

    }

    private void PerformModifierLoop(int foodItem)
    {
        var index = default(int);
        DataRowView vRow;
        int i;
        int c;
        string tableType;
        int currentModifierID;
        DataRow oRow;

        // currentTable.IsExtended = False
        btnOrderModifier[23].ModifierButtonIndex = 0;
        btnOrderModifier[23].ModifierMenuIndex = 0;
        btnOrderModifierExt[59].ModifierButtonIndex = 0;
        btnOrderModifierExt[59].ModifierMenuIndex = 0;

        if (dvIndividualJoinGroup.Count > 0)
        {
            while (modifierIndex <= cntModifierLoop - 1)
            {

                if (currentTable.IsPrimaryMenu == true)
                {
                    currentModifierID = mainCategoryIDArrayList[modifierIndex];
                    // dvIndividualJoinAuto = New DataView

                    {
                        var withBlock = dvIndividualJoinAuto;
                        withBlock.Table = ds.Tables("IndividualJoinMain");
                        withBlock.RowFilter = "FoodID = '" + foodItem + "' and CategoryID = '" + currentModifierID + "' and GroupFlag = 'A'";
                    }

                    // dvIndividualJoinGroup = New DataView
                    {
                        var withBlock1 = dvIndividualJoinGroup;
                        withBlock1.Table = ds.Tables("IndividualJoinMain");
                        withBlock1.RowFilter = "FoodID = '" + foodItem + "'and CategoryID = '" + currentModifierID + "' and GroupFlag = 'G'";
                    }
                }
                else
                {
                    currentModifierID = secondaryCategoryIDArrayList[modifierIndex];
                    // dvIndividualJoinAuto = New DataView
                    {
                        var withBlock2 = dvIndividualJoinAuto;
                        withBlock2.Table = ds.Tables("IndividualJoinSecondary");
                        withBlock2.RowFilter = "FoodID = '" + foodItem + "' and CategoryID = '" + currentModifierID + "' and GroupFlag = 'A'";
                    }

                    // dvIndividualJoinGroup = New DataView
                    {
                        var withBlock3 = dvIndividualJoinGroup;
                        withBlock3.Table = ds.Tables("IndividualJoinSecondary");
                        withBlock3.RowFilter = "FoodID = '" + foodItem + "'and CategoryID = '" + currentModifierID + "' and GroupFlag = 'G'";
                    }
                }

                if (dvIndividualJoinAuto.Count > 0 & currentTable.SecondRound == false)
                {
                    // Exit Do
                    foreach (DataRowView currentVRow in dvIndividualJoinAuto)
                    {
                        vRow = currentVRow;
                        var currentmodifier = new SelectedItemDetail();
                        string populatingTable;
                        int catID;
                        string funFlag;
                        funFlag = vRow("FunctionFlag");
                        catID = vRow("CategoryID");
                        currentTable.InvMultiplier *= vRow("InvMultiplier");

                        if (currentTable.IsPrimaryMenu == true)
                        {
                            populatingTable = "MainTable";
                        }
                        else
                        {
                            populatingTable = "SecondaryMainTable";
                        }

                        currentmodifier.ID = vRow("ModifierID");
                        // may get rid of .Name (duplicate?)
                        currentmodifier.Name = "   " + vRow("AbrevFoodName");
                        currentmodifier.TerminalName = "   " + vRow("AbrevFoodName");
                        currentmodifier.ChitName = "   " + vRow("ChitFoodName");
                        // added spaces here b/c it goes directly to datagrid
                        if (vRow("FreeFlag") == "F" & currentTable.SecondRound == false) // Or dvIndividualJoin(0)("Surcharge") Is DBNull.Value Then
                        {
                            currentmodifier.Price = 0;
                        }
                        else if (!object.ReferenceEquals(vRow("Surcharge"), DBNull.Value))
                        {
                            currentmodifier.Price = vRow("Surcharge") * currentTable.Quantity;
                        }
                        else
                        {
                            currentmodifier.Price = 0;
                        }
                        currentmodifier.FunctionID = vRow("FunctionID");
                        currentmodifier.FunctionGroup = vRow("FunctionGroupID");
                        currentmodifier.FunctionFlag = vRow("FunctionFlag");
                        currentmodifier.Category = vRow("CategoryID");

                        if (currentTable.IsTabNotTable == false)
                        {
                            currentmodifier.Table = currentTable.TableNumber;
                        }
                        else
                        {
                            currentmodifier.Tab = currentTable.TabID;
                        }
                        currentmodifier.Check = currentTable.CheckNumber;
                        currentmodifier.Customer = currentTable.CustomerNumber;
                        currentmodifier.Course = currentTable.CourseNumber;
                        currentmodifier.Quantity = currentTable.Quantity;
                        currentmodifier.InvMultiplier = currentTable.InvMultiplier;
                        currentmodifier.SII = currentTable.ReferenceSIN;
                        currentmodifier.SIN = currentTable.SIN;
                        currentmodifier.si2 = currentTable.si2;
                        currentTable.SIN += 1;
                        AddItemToOrderTable(ref currentmodifier);
                        // i += 1
                    }
                }

                if (dvIndividualJoinGroup.Count > 0)
                {
                    if (dvIndividualJoinGroup.Count > 23)
                        freeFood = new bool[dvIndividualJoinGroup.Count + 1];
                    // If currentTable.IsPizza = False  Then
                    // End If
                    freeFoodActive = true;
                    foreach (DataRowView currentVRow1 in dvIndividualJoinGroup)
                    {
                        vRow = currentVRow1;

                        if (vRow("FreeFlag") == "F" & currentTable.SecondRound == false)      // has NO association to function Flag
                        {
                            freeFood[index] = true;
                        }
                        else
                        {
                            freeFood[index] = false;
                        }
                        index += 1;
                        // numberFree(index) = dvIndividualJoin(0)("NumberFree")    'uses the first record only
                    }
                    break;
                }

                modifierIndex += 1;
            }

            if (dvIndividualJoinGroup.Count > 0)
            {
                SelectModifier(foodItem, ref dvIndividualJoinGroup, 0, "Modifier", 0, false);
                modifierIndex += 1;
                // ***         dvIndividualJoinGroup = New DataView   'resets dv for next modifierIndex value
                freeFoodActive = false;
                return;
            }

            if (dvIndividualJoinAuto.Count > 0)
            {
                // ***         dvIndividualJoinAuto = New DataView
                modifierIndex += 1;
                PerformModifierLoop(foodItem);
                return; // this is so it won't keep looping
            }

        }


        // ************************
        // Category Loop

        i = 0;
        foreach (DataRowView currentVRow2 in dvCategoryJoin)
        {
            vRow = currentVRow2;

            if (categoryIndex[i] == true)
            {
                // numberFree(i) = dvCategoryJoin(i)("NumberFree")
                // dvCategoryModifiers = New DataView

                if (dvCategoryJoin[i]("FunctionFlag") == "F" | dvCategoryJoin[i]("FunctionFlag") == "O" | dvCategoryJoin[i]("FunctionFlag") == "G")
                {

                    if (currentTable.IsPrimaryMenu == true)
                    {
                        // *****    there is a problem if Category is not on Menu      ********
                        if (ds.Tables("MainTable" + dvCategoryJoin[i]("CategoryID")).rows.count > 0)
                        {
                            {
                                var withBlock4 = dvCategoryModifiers;
                                withBlock4.Table = ds.Tables("MainTable" + dvCategoryJoin[i]("CategoryID"));
                                withBlock4.Sort = "MenuIndex";
                                // *** currently Foods do not have order when they are attached modifiers
                            }
                        }
                    }
                    else if (ds.Tables("SecondaryMainTable" + dvCategoryJoin[i]("CategoryID")).rows.count > 0)
                    {
                        {
                            var withBlock5 = dvCategoryModifiers;
                            withBlock5.Table = ds.Tables("SecondaryMainTable" + dvCategoryJoin[i]("CategoryID"));
                            withBlock5.Sort = "MenuIndex";
                            // *** currently Foods do not have order when they are attached modifiers
                        }
                    }
                }

                else
                {
                    try
                    {
                        {
                            var withBlock6 = dvCategoryModifiers;
                            withBlock6.Table = ds.Tables("ModifierTable" + dvCategoryJoin[i]("CategoryID"));
                            // *** do we want to filter out MenuIndex =0 ????
                            // .RowFilter = "MenuIndex > 0"
                            withBlock6.Sort = "MenuIndex";
                        }
                    }
                    catch (Exception ex)
                    {
                        Interaction.MsgBox(dvCategoryJoin[i]("CategoryID"));
                    }
                }

                // freefree 
                if (dvCategoryModifiers.Count > 23)
                    freeFood = new bool[dvCategoryModifiers.Count + 1];

                if (dvCategoryJoin[i]("FreeFlag") == "F" & currentTable.SecondRound == false)
                {

                    c = 0;
                    foreach (DataRowView cRow in dvCategoryModifiers)
                    {
                        freeFood[c] = true;
                        c += 1;
                    }
                    freeFoodActive = true;
                }
                else
                {
                    freeFoodActive = false;
                }

                if (dvCategoryModifiers.Count > 0)
                {

                    SelectModifier(foodItem, ref dvCategoryModifiers, 0, "Food", 0, dvCategoryJoin[i]("Extended"));
                    if (!(dvCategoryJoin[i]("GTCFlag") == "C"))
                    {

                        if (onlyHalf == true)
                        {
                            GTCIndex = i;
                        }
                        else
                        {
                            GTCIndex += 1;
                            categoryIndex[i] = false;
                        }
                    }

                    else
                    {
                        GTCIndex = i;

                    }
                    if (dvCategoryJoin[i]("ReqFlag") == "R")
                    {
                        currentTable.ReqModifier = true;
                    }
                    return;
                }
                else
                {
                    // nothing, go to next category
                }

            }
            i += 1;
        }


        // *****  this is the end of the current item after modifiers
        currentTable.ReferenceSIN = currentTable.SIN;
        GTCIndex = -1;
        freeFoodActive = false;

        // this one below removes the highlight of last hit grid cell
        // but it will add items in the begining (if hit ADD button)
        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(EndOfItem(true), false, false)))
            return;

        currentTable.MiddleOfOrder = false;
        if (currentTable.IsPizza == false)
        {
            pnlPizzaSplit.Visible = false;    // ***** added???  8/29/2007
            pnlWineParring.Visible = true;
        }
        // currentTable.si2 = 0
        // currentTable.Tempsi2 = 0
        // currentTable.IsPizza = False

        pnlOrderModifier.Visible = false;
        pnlOrderModifierExt.Visible = false;

        // **********  i think, if this is end of Food only 
        if (currentTable.IsExtended == true)
        {
            pnlOrderQuick.Visible = true;
        }
        else
        {
            pnlOrder.Visible = true;
        }

        // pnlDescription.Visible = False
        if (!(currentTable.Quantity == 1))
        {
            currentTable.Quantity = 1;
            testgridview.ChangeCourseButton(currentTable.Quantity);
        }
        // PutUsInNormalMode()
        if (currentTable.MarkForNextCustomer == true)
        {
            currentTable.CustomerNumber = currentTable.NextCustomerNumber;
            ChangeCustomerButtonColor(c9);
            if (currentTable.MarkForNewCustomerPanel == true)
            {
                AddCustomerPanel();
            }
            currentTable.MarkForNewCustomerPanel = false;
            currentTable.MarkForNextCustomer = false;
        }
    }

    private void BtnOrderModifier_Click(object sender, EventArgs e) // Handles pnlOrderModifier.Click
    {
        UserControlHit();
        if (currentTable.LastStatus == 1)
            return; // can't order on closed check

        OrderButton objButton;
        int index;

        try
        {
            objButton = (OrderButton)sender;
        }
        catch (Exception ex)
        {
            return;
        }

        if (objButton.ID == -1)
        {
            if (objButton.ModifierButtonIndex > 0)   // = 23 Then
            {
                btnOrderModifier[0].ModifierButtonIndex = 0; // -= 23
                btnOrderModifier[0].ModifierMenuIndex = 0;
            }
            else
            {
                btnOrderModifier[0].ModifierButtonIndex = 0;  // -= 22
                btnOrderModifier[0].ModifierMenuIndex = 0;
            }
            if (objButton.Extended == true)
            {
                btnOrderModifier[59].ModifierButtonIndex = btnOrderModifier[0].ModifierButtonIndex;
                btnOrderModifier[59].ModifierMenuIndex = btnOrderModifier[0].ModifierMenuIndex;
            }
            else
            {
                btnOrderModifier[23].ModifierButtonIndex = btnOrderModifier[0].ModifierButtonIndex;
                btnOrderModifier[23].ModifierMenuIndex = btnOrderModifier[0].ModifierMenuIndex;
            }

            // ************************   put Food in for tableType (2 places below) to test **********************
            if (objButton.CategoryID < 100)
            {

            }
            SelectModifier(objButton.FoodID, ref objButton.ActiveDataView, objButton.ModifierButtonIndex, "Food", objButton.ModifierMenuIndex, objButton.Extended);
            return;
        }
        else if (objButton.ID == -2)
        {
            SelectModifier(objButton.FoodID, ref objButton.ActiveDataView, objButton.ModifierButtonIndex, "Food", objButton.ModifierMenuIndex, objButton.Extended);
            return;
        }

        if (objButton.ID > 0)
        {
            // we are in AddMODE or NoMode
            if (ADDorNOmode == true)
            {
                foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
                {
                    if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                    {
                        if (oRow("sin") == currentTable.ReferenceSIN)
                        {
                            if (oRow("ItemStatus") > 1)
                            {
                                info = new DataSet_Builder.Information_UC("This Item Has already been sent to the Kitchen.");
                                info.Location = new Point((this.Width - info.Width) / 2, (this.Height - info.Height) / 2);
                                this.Controls.Add(info);
                                info.BringToFront();
                                // MsgBox("This Item Has already been sent to the Kitchen.")
                                return;
                            }
                        }
                    }
                }
            }

            var currentmodifier = new SelectedItemDetail();
            currentTable.InvMultiplier *= objButton.InvMultiplier;

            // add 3 space for indention
            // must also add when modifing
            currentmodifier.ID = objButton.ID; // (dtr("ModifierID"))
            currentmodifier.Category = objButton.CategoryID; // (dtr("CategoryID"))
            if (currentTable.OrderingStatus == "NO")
            {
                currentmodifier.Quantity = currentTable.Quantity * -1;
                currentmodifier.InvMultiplier = -1 * currentTable.InvMultiplier;
                currentmodifier.Name = " *** " + currentTable.OrderingStatus + " " + objButton.Name;
                currentmodifier.TerminalName = " *** " + currentTable.OrderingStatus + " " + objButton.Name;
                currentmodifier.ChitName = " *** " + currentTable.OrderingStatus + " " + objButton.Name;
                currentmodifier.Price = 0;
                if (!(currentTerminal.TermMethod == "Quick"))
                {
                    PutUsInNormalMode();
                    pnlMain.Visible = true;
                    pnlMain3.Visible = false;
                }

                currentmodifier.FunctionID = objButton.Functions;          // 3
                currentmodifier.FunctionGroup = objButton.FunctionGroup;
                currentmodifier.FunctionFlag = objButton.FunctionFlag;
            }
            // .FunctionID = 0
            // .FunctionGroup = 0
            else
            {
                currentmodifier.Quantity = currentTable.Quantity;
                // moved below  .InvMultiplier = currentTable.Quantity * objButton.InvMultiplier
                if (currentTable.OrderingStatus == "ADD")
                {
                    currentmodifier.Name = " *** " + currentTable.OrderingStatus + " " + objButton.Name;
                    currentmodifier.TerminalName = " *** " + currentTable.OrderingStatus + " " + objButton.Name;
                    currentmodifier.ChitName = " *** " + currentTable.OrderingStatus + " " + objButton.Name;
                    currentmodifier.RoutingID = (int)testgridview.gridViewOrder.Item(OpenOrdersCurrencyMan.Position, 10);
                }
                // If Not currentTerminal.TermMethod = "Quick" Then
                // PutUsInNormalMode()
                // End If

                else
                {
                    currentmodifier.Name = "   " + objButton.Name; // (dtr("ModifierName"))
                    currentmodifier.TerminalName = "   " + objButton.Name; // (dtr("ModifierName"))
                    currentmodifier.ChitName = "   " + objButton.Name;
                } // (dtr("ModifierName"))
                if (currentTable.si2 > 1 & currentTable.si2 < 10)
                {

                    currentmodifier.Price = objButton.Cost * currentTable.Quantity * 0.5d;
                    currentmodifier.InvMultiplier = 0.5d * currentTable.InvMultiplier;
                    if (onlyHalf == false)
                    {
                        if (!(GTCIndex == -1))
                        {
                            categoryIndex[GTCIndex] = true;
                        }
                        onlyHalf = true;
                    }
                    else
                    {
                        if (!(GTCIndex == -1)) // GTCIndex = 0 Then '
                        {
                            if (!(dvCategoryJoin[GTCIndex]("GTCFlag") == "C"))
                            {
                                categoryIndex[GTCIndex] = false;
                            }

                        }
                        onlyHalf = false;
                    }
                }

                else
                {
                    currentmodifier.Price = objButton.Cost * currentTable.Quantity;
                    currentmodifier.InvMultiplier = currentTable.InvMultiplier;
                }
                currentmodifier.FunctionID = objButton.Functions;          // 3
                currentmodifier.FunctionGroup = objButton.FunctionGroup;
                currentmodifier.FunctionFlag = objButton.FunctionFlag;
            }

            if (isSecondLoop == true)
            {
                currentmodifier.Name = ("   " + currentmodifier.Name).ToLower;
                currentmodifier.TerminalName = ("   " + currentmodifier.Name).ToLower;
                currentmodifier.ChitName = ("   " + currentmodifier.Name).ToLower;
            }

            if (currentTable.IsTabNotTable == false)
            {
                currentmodifier.Table = currentTable.TableNumber;
            }
            else
            {
                currentmodifier.Tab = currentTable.TabID;
            }
            currentmodifier.Check = currentTable.CheckNumber;
            currentmodifier.Customer = currentTable.CustomerNumber;
            currentmodifier.Course = currentTable.CourseNumber;
            currentmodifier.SII = currentTable.ReferenceSIN;
            currentmodifier.SIN = currentTable.SIN;
            currentmodifier.si2 = currentTable.si2;
            currentTable.SIN += 1;

            isSecondLoop = Conversions.ToBoolean(CheckForSecondaryModifierLoop(objButton.ID));
            if (isSecondLoop == true)
            {
                if (currentTable.Tempsi2 < 10)
                {
                    // we only record the temp once (memory in case of pizza)
                    currentTable.Tempsi2 = currentTable.si2;
                }
                currentTable.si2 += 10;
                currentmodifier.si2 = currentTable.si2;

            }

            AddItemToOrderTable(ref currentmodifier);
            testgridview.CalculateSubTotal();
            currentTable.ReqModifier = false;

            if (isSecondLoop == true)
            {
                modifierIndexSecondLoop = 0;
                PerformSecondModifierLoop(objButton.ID);
                return;
            }
            else if (currentTable.si2 >= 10)
            {
                currentTable.si2 += 10;
                currentmodifier.si2 = currentTable.si2;
            }

            if (pnlMain3.Visible == false)
            {
                PerformModifierLoop(objButton.FoodID);
                // Else
            }
        }
        // PutUsInNormalMode()

        else if (objButton.ID < 0)
        {
            // this is for cancel button
            if (currentTable.ReqModifier == true)
            {
                // If EndOfItem(False) = True Then Exit Sub
                EndOfItem(false);
                return;
            }
            if (!(GTCIndex == -1))
            {
                categoryIndex[GTCIndex] = false;
                GTCIndex = -1;
            }
            PerformModifierLoop(objButton.FoodID);

            // PutUsInNormalMode()
        }

    }


    // this is for modifiers to modifiers
    // ex: dressing for a salad, that the salad came with the steak

    private object CheckForSecondaryModifierLoop(int foodItem)
    {
        var i = default(int);

        if (currentTable.IsPrimaryMenu == true)
        {
            {
                var withBlock = dvIndividualJoinGroup;
                withBlock.Table = ds.Tables("IndividualJoinMain");
                withBlock.RowFilter = "FoodID = '" + foodItem + "'";
            }
        }
        else
        {
            {
                var withBlock1 = dvIndividualJoinGroup;
                withBlock1.Table = ds.Tables("IndividualJoinSecondary");
                withBlock1.RowFilter = "FoodID = '" + foodItem + "'";
            }
        }

        {
            var withBlock2 = dvCategoryJoinSecondLoop;
            withBlock2.Table = ds.Tables("CategoryJoin");
            withBlock2.RowFilter = "FoodID = '" + foodItem + "'";
            withBlock2.Sort = "Priority, FreeFlag";
        }

        categoryIndexSecondLoop = new bool[dvCategoryJoinSecondLoop.Count + 1];
        foreach (DataRowView vRow in dvCategoryJoinSecondLoop)
        {
            categoryIndexSecondLoop[i] = true;
            i += 1;
        }

        if (dvIndividualJoinGroup.Count + dvCategoryJoinSecondLoop.Count > 0)
        {
            return true;
        }
        else
        {
            // currentTable.si2 = currentTable.Tempsi2
            isSecondLoop = false;
            return false;
        }


    }


    private void PerformSecondModifierLoop(int foodItem)
    {
        var index = default(int);
        DataRowView vRow;
        var i = default(int);
        int c;
        string tableType;
        int currentModifierID;
        DataRow oRow;


        if (dvIndividualJoinGroup.Count > 0)
        {
            while (modifierIndexSecondLoop <= cntModifierLoop - 1)
            {

                if (currentTable.IsPrimaryMenu == true)
                {
                    currentModifierID = mainCategoryIDArrayList[modifierIndexSecondLoop];
                    // dvIndividualJoinAuto = New DataView
                    {
                        var withBlock = dvIndividualJoinAuto;
                        withBlock.Table = ds.Tables("IndividualJoinMain");
                        withBlock.RowFilter = "FoodID = '" + foodItem + "' and CategoryID = '" + currentModifierID + "' and GroupFlag = 'A'";
                    }

                    // dvIndividualJoinGroup = New DataView
                    {
                        var withBlock1 = dvIndividualJoinGroup;
                        withBlock1.Table = ds.Tables("IndividualJoinMain");
                        withBlock1.RowFilter = "FoodID = '" + foodItem + "'and CategoryID = '" + currentModifierID + "' and GroupFlag = 'G'";
                    }
                }
                else
                {
                    currentModifierID = secondaryCategoryIDArrayList[modifierIndexSecondLoop];
                    // dvIndividualJoinAuto = New DataView
                    {
                        var withBlock2 = dvIndividualJoinAuto;
                        withBlock2.Table = ds.Tables("IndividualJoinSecondary");
                        withBlock2.RowFilter = "FoodID = '" + foodItem + "' and CategoryID = '" + currentModifierID + "' and GroupFlag = 'A'";
                    }

                    // dvIndividualJoinGroup = New DataView
                    {
                        var withBlock3 = dvIndividualJoinGroup;
                        withBlock3.Table = ds.Tables("IndividualJoinSecondary");
                        withBlock3.RowFilter = "FoodID = '" + foodItem + "'and CategoryID = '" + currentModifierID + "' and GroupFlag = 'G'";
                    }
                }

                if (dvIndividualJoinAuto.Count > 0 & currentTable.SecondRound == false)
                {
                    // Exit Do
                    foreach (DataRowView currentVRow in dvIndividualJoinAuto)
                    {
                        vRow = currentVRow;
                        var currentmodifier = new SelectedItemDetail();
                        string populatingTable;
                        int catID;
                        string funFlag;
                        funFlag = vRow("FunctionFlag");
                        catID = vRow("CategoryID");
                        // this is NOT needed now
                        // maybe if sometime we want to have an automatic Inv Multiplier added to item
                        currentTable.InvMultiplier *= vRow("InvMultiplier");

                        if (currentTable.IsPrimaryMenu == true)
                        {
                            populatingTable = "MainTable";
                        }
                        else
                        {
                            populatingTable = "SecondaryMainTable";
                        }

                        currentmodifier.ID = vRow("ModifierID");
                        // may get rid of .Name (duplicate?)
                        currentmodifier.Name = "   " + vRow("AbrevFoodName");
                        currentmodifier.TerminalName = "   " + vRow("AbrevFoodName");
                        currentmodifier.ChitName = "   " + vRow("ChitFoodName");
                        // added spaces here b/c it goes directly to datagrid
                        if (vRow("FreeFlag") == "F" & currentTable.SecondRound == false) // Or dvIndividualJoin(0)("Surcharge") Is DBNull.Value Then
                        {
                            currentmodifier.Price = 0;
                        }
                        else if (!object.ReferenceEquals(vRow("Surcharge"), DBNull.Value))
                        {
                            currentmodifier.Price = vRow("Surcharge") * currentTable.Quantity;
                        }
                        else
                        {
                            currentmodifier.Price = 0;
                        }
                        currentmodifier.FunctionID = vRow("FunctionID");
                        currentmodifier.FunctionGroup = vRow("FunctionGroupID");
                        currentmodifier.FunctionFlag = vRow("FunctionFlag");
                        currentmodifier.Category = vRow("CategoryID");

                        if (currentTable.IsTabNotTable == false)
                        {
                            currentmodifier.Table = currentTable.TableNumber;
                        }
                        else
                        {
                            currentmodifier.Tab = currentTable.TabID;
                        }
                        currentmodifier.Check = currentTable.CheckNumber;
                        currentmodifier.Customer = currentTable.CustomerNumber;
                        currentmodifier.Course = currentTable.CourseNumber;
                        currentmodifier.Quantity = currentTable.Quantity;
                        currentmodifier.InvMultiplier = currentTable.InvMultiplier;
                        currentmodifier.SII = currentTable.ReferenceSIN;
                        currentmodifier.SIN = currentTable.SIN;
                        currentmodifier.si2 = currentTable.si2;
                        currentTable.SIN += 1;
                        AddItemToOrderTable(ref currentmodifier);
                        i += 1;
                    }
                }

                if (dvIndividualJoinGroup.Count > 0)
                {
                    if (dvIndividualJoinGroup.Count > 23)
                        freeFood = new bool[dvIndividualJoinGroup.Count + 1];
                    // If currentTable.IsPizza = False  Then
                    // End If
                    freeFoodActive = true;
                    foreach (DataRowView currentVRow1 in dvIndividualJoinGroup)
                    {
                        vRow = currentVRow1;

                        if (vRow("FreeFlag") == "F" & currentTable.SecondRound == false)      // has NO association to function Flag
                        {
                            freeFood[index] = true;
                        }
                        else
                        {
                            freeFood[index] = false;
                        }
                        index += 1;
                        // numberFree(index) = dvIndividualJoin(0)("NumberFree")    'uses the first record only
                    }
                    break;
                }

                modifierIndexSecondLoop += 1;
            }

            if (dvIndividualJoinGroup.Count > 0)
            {
                SelectModifier(foodItem, ref dvIndividualJoinGroup, 0, "Modifier", 0, false);
                modifierIndexSecondLoop += 1;
                // ***         dvIndividualJoinGroup = New DataView   'resets dv for next modifierIndexSecondLoop value
                freeFoodActive = false;
                return;
            }

            if (dvIndividualJoinAuto.Count > 0)
            {
                // ***         dvIndividualJoinAuto = New DataView
                modifierIndexSecondLoop += 1;
                PerformModifierLoop(foodItem);
                return; // this is so it won't keep looping
            }
        }


        // ************************
        // Category Loop

        i = 0;
        foreach (DataRowView currentVRow2 in dvCategoryJoinSecondLoop)
        {
            vRow = currentVRow2;

            if (categoryIndexSecondLoop[i] == true)
            {
                // numberFree(i) = dvCategoryJoin(i)("NumberFree")
                // ***        dvCategoryModifiersSecondLoop = New DataView

                if (dvCategoryJoinSecondLoop[i]("FunctionFlag") == "F" | dvCategoryJoinSecondLoop[i]("FunctionFlag") == "O")
                {

                    if (currentTable.IsPrimaryMenu == true)
                    {
                        // *****    there is a problem if Category is not on Menu      ********
                        if (ds.Tables("MainTable" + dvCategoryJoinSecondLoop[i]("CategoryID")).rows.count > 0)
                        {
                            {
                                var withBlock4 = dvCategoryModifiersSecondLoop;
                                withBlock4.Table = ds.Tables("MainTable" + dvCategoryJoinSecondLoop[i]("CategoryID"));
                                withBlock4.Sort = "MenuIndex";
                                // *** currently Foods do not have order when they are attached modifiers
                            }
                        }
                    }
                    // *****    there is a problem if Category is not on Menu      ********
                    else if (ds.Tables("SecondaryMainTable" + dvCategoryJoinSecondLoop[i]("CategoryID")).rows.count > 0)
                    {
                        {
                            var withBlock5 = dvCategoryModifiersSecondLoop;
                            withBlock5.Table = ds.Tables("SecondaryMainTable" + dvCategoryJoinSecondLoop[i]("CategoryID"));
                            withBlock5.Sort = "MenuIndex";
                            // *** currently Foods do not have order when they are attached modifiers
                        }
                    }
                }

                else
                {

                    {
                        var withBlock6 = dvCategoryModifiersSecondLoop;
                        withBlock6.Table = ds.Tables("ModifierTable" + dvCategoryJoinSecondLoop[i]("CategoryID"));
                        // *** do we want to filter out MenuIndex =0 ????
                        // .RowFilter = "MenuIndex > 0"
                        withBlock6.Sort = "MenuIndex";
                    }

                }

                if (dvCategoryJoin.Count > 0)
                {
                    if (dvCategoryJoin[i]("FreeFlag") == "F" & currentTable.SecondRound == false)
                    {
                        c = 0;
                        foreach (DataRowView cRow in dvCategoryModifiersSecondLoop)
                        {
                            freeFood[c] = true;
                            c += 1;
                        }
                        freeFoodActive = true;
                    }
                    else
                    {
                        freeFoodActive = false;
                    }
                }
                else
                {

                }

                if (dvCategoryModifiersSecondLoop.Count > 0)
                {
                    SelectModifier(foodItem, ref dvCategoryModifiersSecondLoop, 0, "Food", 0, dvCategoryJoin[i]("Extended")); // dvCategoryModifiersSecondLoop(0)("Extended"))
                }
                if (!(dvCategoryJoinSecondLoop[i]("GTCFlag") == "C"))
                {
                    categoryIndexSecondLoop[i] = false;
                }
                else
                {
                    GTCIndex = i;
                }
                return;
            }
            i += 1;
        }


        return;
        // 222 none of this nneded for second loop

        // *****  this is the end of the current item after modifiers
        currentTable.ReferenceSIN = currentTable.SIN;
        GTCIndex = -1;
        freeFoodActive = false;

        // this one below removes the highlight of last hit grid cell
        // but it will add items in the begining (if hit ADD button)
        // EndOfItem()
        currentTable.MiddleOfOrder = false;
        currentTable.si2 = 0;
        currentTable.Tempsi2 = 0;
        currentTable.IsPizza = false;
        // Me.pnlPizzaSplit.Visible = False
        pnlOrderModifier.Visible = false;
        pnlOrderModifierExt.Visible = false;
        if (currentTable.IsExtended == true)
        {
            pnlOrderQuick.Visible = true;
        }
        else
        {
            pnlOrder.Visible = true;
        }
        // pnlDescription.Visible = False
        if (!(currentTable.Quantity == 1))
        {
            currentTable.Quantity = 1;
            testgridview.ChangeCourseButton(currentTable.Quantity);
        }
        // PutUsInNormalMode()
        if (currentTable.MarkForNextCustomer == true)
        {
            currentTable.CustomerNumber = currentTable.NextCustomerNumber;
            ChangeCustomerButtonColor(c9);
            if (currentTable.MarkForNewCustomerPanel == true)
            {
                AddCustomerPanel();
            }
            currentTable.MarkForNewCustomerPanel = false;
            currentTable.MarkForNextCustomer = false;
        }
    }

    private void SelectModifier(int foodItem, ref DataView dv, int modButtonIndex, string tableType, int modMenuIndex, bool modIsExtended)
    {
        int index;
        int secondindex;
        DataRowView vRow;
        int mbi = modMenuIndex;  // modButtonIndex
        int n = 0;
        int lastButton;

        string populatingTable;
        int catID;
        string funFlag;

        try
        {
            funFlag = dv[0]("FunctionFlag");   // dv(mbi)("FunctionFlag")
            catID = dv[0]("CategoryID");   // dv(mbi)("CategoryID")
        }

        catch (Exception ex)
        {
            Interaction.MsgBox("There is a problem with your Menu Setup. Please verify your Menu Joins.");
            // modifierIndex += 1
            // PerformModifierLoop(foodItem)
            return;
        }

        if (currentTable.IsPrimaryMenu == true)
        {
            populatingTable = "MainTable";
        }
        else
        {
            populatingTable = "SecondaryMainTable";
        }

        if (modIsExtended == true)
        {
            lastButton = 59;

            var loopTo = lastButton;
            for (n = 0; n <= loopTo; n++)
            {
                // clear button 
                btnOrderModifierExt[n].Text = (object)null;
                btnOrderModifierExt[n].ID = 0;
                btnOrderModifierExt[n].BackColor = c13;   // c8
            }

            if (mbi == 0)
            {
                index = 0;
            }
            else
            {
                index = 1;
                btnOrderModifierExt[0].Text = "Previous";
                btnOrderModifierExt[0].ID = -1;
                btnOrderModifierExt[0].FoodID = foodItem;
                btnOrderModifierExt[0].ActiveDataView = dv;
                btnOrderModifierExt[0].BackColor = c4;
                btnOrderModifierExt[0].ForeColor = c3;
                btnOrderModifierExt[0].Extended = modIsExtended;
            }

            foreach (DataRowView currentVRow in dv)
            {
                vRow = currentVRow;

                if (mbi >= dv.Count)
                    break;

                if (object.ReferenceEquals(dv[mbi]("MenuIndex"), DBNull.Value))
                {
                    // I don't think we will ever get here
                    // we should get info from:   Menu Class  -  tableCreating = "IndividualJoinMain"
                    // this is for food items that were not put on a menu
                    // like sides (that are listed as food items)
                    // this only works for a limited amount
                    index = mbi;
                }
                else if (modButtonIndex < dv[mbi]("MenuIndex"))
                {
                    index = dv[mbi]("MenuIndex") - modButtonIndex;
                }
                else
                {
                    index = dv[mbi]("MenuIndex");
                }


                if (index > 0)
                {
                    index -= 1;  // b/c the buttons are Zero based

                    if (index >= lastButton)
                        break; // this gives the first 24 records (0-23) w/ last button at 23

                    // changed both from modifiername to foodname
                    btnOrderModifierExt[index].Text = dv[mbi]("AbrevFoodName");  // (tableType & "Name")
                    btnOrderModifierExt[index].Name = dv[mbi]("AbrevFoodName");  // (tableType & "Name")
                    // btnOrderModifierExt(index).ch = dv(mbi)("ChitFoodName")  '(tableType & "Name")

                    // the above two can come from 2 diff places (abrev)
                    btnOrderModifierExt[index].ID = dv[mbi](tableType + "ID");  // ("FoodID")    '

                    // need to do this by index if I can populate by index (in Category Loop 6 leaps above)
                    if (freeFood[mbi] == true & freeFoodActive == true)    // numberFree(0) > 0 Then   'Or dv(mbi)("Surcharge") Is DBNull.Value Then
                    {
                        btnOrderModifierExt[index].Cost = 0;
                    }
                    // numberFree(index) -= 1
                    else if (!object.ReferenceEquals(dv[mbi]("Surcharge"), DBNull.Value))
                    {
                        btnOrderModifierExt[index].Cost = dv[mbi]("Surcharge"); // (tableType & "Cost")
                    }
                    else
                    {
                        btnOrderModifierExt[index].Cost = 0;
                    }

                    btnOrderModifierExt[index].CategoryID = dv[mbi]("CategoryID");
                    btnOrderModifierExt[index].Functions = dv[mbi]("FunctionID");
                    btnOrderModifierExt[index].FunctionGroup = dv[mbi]("FunctionGroupID");
                    btnOrderModifierExt[index].FunctionFlag = dv[mbi]("FunctionFlag");
                    btnOrderModifierExt[index].InvMultiplier = dv[mbi]("InvMultiplier");
                    btnOrderModifierExt[index].FoodID = foodItem;  // dv(mbi)("FoodID")

                    if (!object.ReferenceEquals(dv[mbi]("ButtonColor"), DBNull.Value))
                    {
                        btnOrderModifierExt[index].BackColor = Color.FromArgb(dv[mbi]("ButtonColor"));
                        btnOrderModifierExt[index].ForeColor = Color.FromArgb(dv[mbi]("ButtonForeColor"));
                    }
                    else
                    {
                        // only this was here last
                        btnOrderModifierExt[index].BackColor = c4;
                        btnOrderModifierExt[index].ForeColor = c3;
                    }
                }

                else
                {
                    // should never get here, therefore we skip this item
                    // this is now for the item in staging, index = 0 
                    index = 0;
                }
                // index += 1
                mbi += 1;
                // If index = 23 Then Exit For 'this gives the first 15 records (0-14)
            }

            if (index >= lastButton)
            {
                if (index == lastButton & mbi + 1 == dv.Count)  // dv.Count = modButtonIndex + 24 Then
                {
                    // this is the 16th record (15)
                    btnOrderModifierExt[index].Text = dv[mbi](tableType + "Name");
                    btnOrderModifierExt[index].Name = dv[mbi](tableType + "Name");
                    btnOrderModifierExt[index].ID = dv[mbi](tableType + "ID");
                    if (freeFood[mbi] == true & freeFoodActive == true | object.ReferenceEquals(dv[mbi]("Surcharge"), DBNull.Value))      // numberFree(index) > 0
                    {
                        btnOrderModifierExt[index].Cost = 0;
                    }
                    // numberFree(index) -= 1
                    else
                    {
                        btnOrderModifierExt[index].Cost = dv[mbi]("Surcharge");
                    } // (tableType & "Cost")
                    btnOrderModifierExt[index].CategoryID = dv[mbi]("CategoryID");
                    btnOrderModifierExt[index].Functions = dv[mbi]("FunctionID");
                    btnOrderModifierExt[index].FunctionGroup = dv[mbi]("FunctionGroupID");
                    btnOrderModifierExt[index].FunctionFlag = dv[mbi]("FunctionFlag");
                    btnOrderModifierExt[index].InvMultiplier = dv[mbi]("InvMultiplier");
                    btnOrderModifierExt[index].FoodID = foodItem;
                }
                else  // elseIf dv.Count > modButtonIndex + 25 Then
                {
                    btnOrderModifierExt[lastButton].Text = "More";
                    btnOrderModifierExt[lastButton].ID = -2;
                    btnOrderModifierExt[lastButton].FoodID = foodItem;
                    btnOrderModifierExt[lastButton].ActiveDataView = dv;
                    btnOrderModifierExt[lastButton].Extended = modIsExtended;
                    if (btnOrderModifierExt[lastButton].ModifierButtonIndex == 0)
                    {
                        btnOrderModifierExt[lastButton].ModifierButtonIndex = modButtonIndex + lastButton;  // 24
                        btnOrderModifierExt[lastButton].ModifierMenuIndex += mbi;  // modButtonIndex + 23  '24
                    }
                    else
                    {
                        btnOrderModifierExt[lastButton].ModifierButtonIndex = modButtonIndex + (lastButton - 1); // 23
                        btnOrderModifierExt[lastButton].ModifierMenuIndex += mbi;
                    }  // modButtonIndex + 23  '24
                }
                if (!object.ReferenceEquals(dv[mbi]("ButtonColor"), DBNull.Value))
                {
                    btnOrderModifierExt[index].BackColor = Color.FromArgb(dv[mbi]("ButtonColor"));
                    btnOrderModifierExt[index].ForeColor = Color.FromArgb(dv[mbi]("ButtonForeColor"));
                }
                else
                {
                    // only this was here last
                    btnOrderModifierExt[index].BackColor = c4;
                    btnOrderModifierExt[index].ForeColor = c3;
                }

                if (btnOrderModifierExt[lastButton].ModifierButtonIndex > 0)
                    btnOrderModifierExt[0].ModifierButtonIndex = btnOrderModifierExt[lastButton].ModifierButtonIndex;
            }

            if (pnlOrderModifierExt.Visible == false)
            {
                pnlOrderModifierExt.Visible = true;
                pnlOrderModifier.Visible = false;

            }
        }
        else
        {
            lastButton = 23;

            var loopTo1 = lastButton;
            for (n = 0; n <= loopTo1; n++)
            {
                // clear button 
                btnOrderModifier[n].Text = (object)null;
                btnOrderModifier[n].ID = 0;
                btnOrderModifier[n].BackColor = c13;   // c8
            }

            if (mbi == 0)
            {
                index = 0;
            }
            else
            {
                index = 1;
                btnOrderModifier[0].Text = "Previous";
                btnOrderModifier[0].ID = -1;
                btnOrderModifier[0].FoodID = foodItem;
                btnOrderModifier[0].ActiveDataView = dv;
                btnOrderModifier[0].BackColor = c4;
                btnOrderModifier[0].ForeColor = c3;
                btnOrderModifier[0].Extended = modIsExtended;
            }

            foreach (DataRowView currentVRow1 in dv)
            {
                vRow = currentVRow1;

                if (mbi >= dv.Count)
                    break;

                if (object.ReferenceEquals(dv[mbi]("MenuIndex"), DBNull.Value))
                {
                    // 999
                    // this is for indivual joins that display as a group
                    // index = mbi
                    if (!(mbi == 0))
                    {
                        // do not advance the first button (o based)
                        index += 1;
                    }
                }

                else if (modButtonIndex < dv[mbi]("MenuIndex"))
                {
                    index = dv[mbi]("MenuIndex") - modButtonIndex - 1;
                }
                else
                {
                    index = dv[mbi]("MenuIndex") - 1;
                }


                if (index > -1)
                {
                    // 999 index -= 1  'b/c the buttons are Zero based

                    if (index >= lastButton)
                        break; // this gives the first 24 records (0-23) w/ last button at 23

                    // changed both from modifiername to foodname
                    btnOrderModifier[index].Text = dv[mbi]("AbrevFoodName");  // (tableType & "Name")
                    btnOrderModifier[index].Name = dv[mbi]("AbrevFoodName");  // (tableType & "Name")
                    // btnOrderModifier(index).ch = dv(mbi)("ChitFoodName")  '(tableType & "Name")

                    // the above two can come from 2 diff places (abrev)
                    btnOrderModifier[index].ID = dv[mbi](tableType + "ID");  // ("FoodID")    '

                    // need to do this by index if I can populate by index (in Category Loop 6 leaps above)
                    if (freeFood[mbi] == true & freeFoodActive == true)    // numberFree(0) > 0 Then   'Or dv(mbi)("Surcharge") Is DBNull.Value Then
                    {
                        btnOrderModifier[index].Cost = 0;
                    }
                    // numberFree(index) -= 1
                    else if (!object.ReferenceEquals(dv[mbi]("Surcharge"), DBNull.Value))
                    {
                        btnOrderModifier[index].Cost = dv[mbi]("Surcharge"); // (tableType & "Cost")
                    }
                    else
                    {
                        btnOrderModifier[index].Cost = 0;
                    }

                    btnOrderModifier[index].CategoryID = dv[mbi]("CategoryID");
                    btnOrderModifier[index].Functions = dv[mbi]("FunctionID");
                    btnOrderModifier[index].FunctionGroup = dv[mbi]("FunctionGroupID");
                    btnOrderModifier[index].FunctionFlag = dv[mbi]("FunctionFlag");
                    btnOrderModifier[index].InvMultiplier = dv[mbi]("InvMultiplier");
                    btnOrderModifier[index].FoodID = foodItem;  // dv(mbi)("FoodID")
                    if (!object.ReferenceEquals(dv[mbi]("ButtonColor"), DBNull.Value))
                    {
                        btnOrderModifier[index].BackColor = Color.FromArgb(dv[mbi]("ButtonColor"));
                        btnOrderModifier[index].ForeColor = Color.FromArgb(dv[mbi]("ButtonForeColor"));
                    }
                    else
                    {
                        // only this was here last
                        btnOrderModifier[index].BackColor = c4;
                        btnOrderModifier[index].ForeColor = c3;
                    }
                }

                else
                {
                    // should never get here, therefore we skip this item
                    // this is now for the item in staging, index = 0 
                    index = 0;
                }
                // index += 1
                mbi += 1;
                // If index = 23 Then Exit For 'this gives the first 15 records (0-14)

            }

            if (index >= lastButton)
            {
                if (index == lastButton & mbi + 1 == dv.Count)  // dv.Count = modButtonIndex + 24 Then
                {
                    // this is the 16th record (15)
                    btnOrderModifier[index].Text = dv[mbi](tableType + "Name");
                    btnOrderModifier[index].Name = dv[mbi](tableType + "Name");
                    btnOrderModifier[index].ID = dv[mbi](tableType + "ID");
                    if (freeFood[mbi] == true & freeFoodActive == true | object.ReferenceEquals(dv[mbi]("Surcharge"), DBNull.Value))      // numberFree(index) > 0
                    {
                        btnOrderModifier[index].Cost = 0;
                    }
                    // numberFree(index) -= 1
                    else
                    {
                        btnOrderModifier[index].Cost = dv[mbi]("Surcharge");
                    } // (tableType & "Cost")
                    btnOrderModifier[index].CategoryID = dv[mbi]("CategoryID");
                    btnOrderModifier[index].Functions = dv[mbi]("FunctionID");
                    btnOrderModifier[index].FunctionGroup = dv[mbi]("FunctionGroupID");
                    btnOrderModifier[index].FunctionFlag = dv[mbi]("FunctionFlag");
                    btnOrderModifier[index].InvMultiplier = dv[mbi]("InvMultiplier");
                    btnOrderModifier[index].FoodID = foodItem;
                }
                else  // elseIf dv.Count > modButtonIndex + 25 Then
                {
                    btnOrderModifier[lastButton].Text = "More";
                    btnOrderModifier[lastButton].ID = -2;
                    btnOrderModifier[lastButton].FoodID = foodItem;
                    btnOrderModifier[lastButton].ActiveDataView = dv;
                    btnOrderModifier[lastButton].Extended = modIsExtended;
                    if (btnOrderModifier[lastButton].ModifierButtonIndex == 0)
                    {
                        btnOrderModifier[lastButton].ModifierButtonIndex = modButtonIndex + lastButton;  // 24
                        btnOrderModifier[lastButton].ModifierMenuIndex += mbi;  // modButtonIndex + 23  '24
                    }
                    else
                    {
                        btnOrderModifier[lastButton].ModifierButtonIndex = modButtonIndex + (lastButton - 1); // 23
                        btnOrderModifier[lastButton].ModifierMenuIndex += mbi;
                    }  // modButtonIndex + 23  '24
                }
                if (!object.ReferenceEquals(dv[mbi]("ButtonColor"), DBNull.Value))
                {
                    btnOrderModifier[index].BackColor = Color.FromArgb(dv[mbi]("ButtonColor"));
                    btnOrderModifier[index].ForeColor = Color.FromArgb(dv[mbi]("ButtonForeColor"));
                }
                else
                {
                    // only this was here last
                    btnOrderModifier[index].BackColor = c4;
                    btnOrderModifier[index].ForeColor = c3;
                }

                if (btnOrderModifier[lastButton].ModifierButtonIndex > 0)
                    btnOrderModifier[0].ModifierButtonIndex = btnOrderModifier[lastButton].ModifierButtonIndex;
            }

            if (pnlOrderModifier.Visible == false)
            {
                pnlOrderModifier.Visible = true;
                pnlOrderModifierExt.Visible = false;

            }
        }



        // btnOrderModifierCancel.Text = "NO " & catName  'we need to pull catName to do this
        btnOrderModifierCancel.FoodID = foodItem;

    }

    private void SelectModifier222(int foodItem, ref DataView dv, int modButtonIndex, string tableType)
    {
        int index;
        int secondIndex;
        int mbi = modButtonIndex;

        string populatingTable;
        int catID;
        string funFlag;

        try
        {
            funFlag = dv[mbi]("FunctionFlag");
            catID = dv[mbi]("CategoryID");
        }
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);
            modifierIndex += 1;
            PerformModifierLoop(foodItem);
            return;
        }

        if (currentTable.IsPrimaryMenu == true)
        {
            populatingTable = "MainTable";
        }
        else
        {
            populatingTable = "SecondaryMainTable";
        }
        // If funFlag = "F" Then
        // dvSurcharge = New DataView(ds.Tables(populatingTable & catID), "FoodID ='" & foodItem & "'", "FoodID", DataViewRowState.CurrentRows)
        // Else
        // 
        // End If
        // dvSurcharge = New DataView

        if (mbi == 0)
        {
            index = 0;
        }
        else
        {
            index = 1;
            btnOrderModifier[0].Text = "Previous";
            btnOrderModifier[0].ID = -1;
            btnOrderModifier[0].FoodID = foodItem;
            btnOrderModifier[0].ActiveDataView = dv;
            btnOrderModifier[0].BackColor = c4;
            btnOrderModifier[0].ForeColor = c3;
        }
        foreach (DataRowView vRow in dv)
        {

            if (mbi >= dv.Count)
                break;

            // changed both from modifiername to foodname
            btnOrderModifier[index].Text = dv[mbi]("AbrevFoodName");  // (tableType & "Name")
            btnOrderModifier[index].Name = dv[mbi]("AbrevFoodName");  // (tableType & "Name")
            // btnOrderModifier(index).ch = dv(mbi)("ChitFoodName")  '(tableType & "Name")

            // the above two can come from 2 diff places (abrev)
            btnOrderModifier[index].ID = dv[mbi](tableType + "ID");  // ("FoodID")    '

            // need to do this by index if I can populate by index (in Category Loop 6 leaps above)
            if (freeFood[mbi] == true & freeFoodActive == true)    // numberFree(0) > 0 Then   'Or dv(mbi)("Surcharge") Is DBNull.Value Then
            {
                btnOrderModifier[index].Cost = 0;
            }
            // numberFree(index) -= 1
            // If dvSurcharge.Count > 0 Then
            // If Not dvSurcharge(0)("Surcharge") Is DBNull.Value Then
            // btnOrderModifier(index).Cost = dvSurcharge(0)("Surcharge")
            // Else
            // btnOrderModifier(index).Cost = 0
            // End If
            // Else


            else if (!object.ReferenceEquals(dv[mbi]("Surcharge"), DBNull.Value))
            {
                btnOrderModifier[index].Cost = dv[mbi]("Surcharge"); // (tableType & "Cost")
            }
            else
            {
                btnOrderModifier[index].Cost = 0;

                // End If

            }

            btnOrderModifier[index].CategoryID = dv[mbi]("CategoryID");
            btnOrderModifier[index].Functions = dv[mbi]("FunctionID");
            btnOrderModifier[index].FunctionGroup = dv[mbi]("FunctionGroupID");
            btnOrderModifier[index].FunctionFlag = dv[mbi]("FunctionFlag");
            btnOrderModifier[index].FoodID = foodItem;  // dv(mbi)("FoodID")
            btnOrderModifier[index].BackColor = c4;
            btnOrderModifier[index].ForeColor = c3;
            index += 1;
            mbi += 1;
            if (index == 23)
                break; // this gives the first 15 records (0-14)
        }

        if (index == 23)
        {
            if (dv.Count == modButtonIndex + 24)
            {
                // this is the 16th record (15)
                btnOrderModifier[index].Text = dv[mbi](tableType + "Name");
                btnOrderModifier[index].Name = dv[mbi](tableType + "Name");
                btnOrderModifier[index].ID = dv[mbi](tableType + "ID");
                if (freeFood[mbi] == true & freeFoodActive == true | object.ReferenceEquals(dv[mbi]("Surcharge"), DBNull.Value))      // numberFree(index) > 0
                {
                    btnOrderModifier[index].Cost = 0;
                }
                // numberFree(index) -= 1
                else
                {
                    btnOrderModifier[index].Cost = dv[mbi]("Surcharge");
                } // (tableType & "Cost")
                btnOrderModifier[index].CategoryID = dv[mbi]("CategoryID");
                btnOrderModifier[index].Functions = dv[mbi]("FunctionID");
                btnOrderModifier[index].FunctionGroup = dv[mbi]("FunctionGroupID");
                btnOrderModifier[index].FunctionFlag = dv[mbi]("FunctionFlag");
                btnOrderModifier[index].FoodID = foodItem;
            }
            else if (dv.Count > modButtonIndex + 25)
            {
                btnOrderModifier[index].Text = "More";
                btnOrderModifier[index].ID = -2;
                btnOrderModifier[index].FoodID = foodItem;
                btnOrderModifier[index].ActiveDataView = dv;
                if (btnOrderModifier[index].ModifierButtonIndex == 0)
                {
                    btnOrderModifier[index].ModifierButtonIndex = modButtonIndex + 24;
                }
                else
                {
                    btnOrderModifier[index].ModifierButtonIndex = modButtonIndex + 23;
                }
            }
            btnOrderModifier[index].BackColor = c4;
            btnOrderModifier[index].ForeColor = c3;
            if (btnOrderModifier[index].ModifierButtonIndex > 0)
                btnOrderModifier[0].ModifierButtonIndex = btnOrderModifier[24].ModifierButtonIndex;
        }

        if (index < 23)
        {
            for (secondIndex = index; secondIndex <= 23; secondIndex++)
            {
                btnOrderModifier[secondIndex].Text = (object)null;
                btnOrderModifier[secondIndex].ID = 0;
                btnOrderModifier[secondIndex].BackColor = c13;   // c8
            }
        }

        if (pnlOrderModifier.Visible == false)
        {
            pnlOrderModifier.Visible = true;
            // **************   pnlOrderModifierExt.Visible = False

        }

        // btnOrderModifierCancel.Text = "NO " & catName  'we need to pull catName to do this
        btnOrderModifierCancel.FoodID = foodItem;

    }

    private void CancelDrinkAdds()
    {

        UserControlHit();
        drinkPrep.Visible = false;

        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(EndOfItem(true), false, false)))
            return;

    }

    private void DrinkPrepOrdered(SelectedItemDetail currentItem)
    {
        UserControlHit();

        if (currentItem.dpMethod == "percent")
        {
            int rowNum = OpenOrdersCurrencyMan.Position;
            int valueSIN;
            int valueSII;
            var originalItemPrice = default(decimal);
            valueSIN = (int)testgridview.gridViewOrder.Item(rowNum, 1);
            valueSII = (int)testgridview.gridViewOrder.Item(rowNum, 2);
            foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
            {
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (oRow("sin") == valueSII)
                    {
                        originalItemPrice = oRow("Price");
                    }
                }
            }

            if (currentItem.Price < 1)
            {
                // this means customer entered Ex: 0.50 for 50%
                currentItem.ItemPrice = currentItem.Price * originalItemPrice;
                currentItem.Price = currentItem.Price * originalItemPrice;
            }
            else
            {
                // this means customer entered Ex: 50 for 50%
                currentItem.ItemPrice = currentItem.Price / 100 * originalItemPrice;
                currentItem.Price = currentItem.Price / 100 * originalItemPrice;
            }
        }

        currentItem.Check = currentTable.CheckNumber;
        currentItem.Customer = currentTable.CustomerNumber;
        currentItem.Course = currentTable.CourseNumber;
        currentItem.SIN = currentTable.SIN;
        currentItem.SII = currentTable.ReferenceSIN;
        currentItem.si2 = currentTable.si2;

        // GenerateOrderTables.DetermineFunctionAndTaxInfo(currentItem, currentItem.FunctionGroup, True)
        currentItem.PrintPriorityID = 1;

        foreach (DataRow functionRow in dsOrder.Tables("Functions").Rows)
        {
            if (functionRow("FunctionID") == currentItem.FunctionID)
            {
                // .FunctionID = functionRow("FunctionID")
                currentItem.TaxID = functionRow("TaxID");
                break;
            }
        }

        currentTable.SIN += 1;
        AddItemToOrderTable(ref currentItem);
        testgridview.CalculateSubTotal();

    }


    private void SelectDrinkAdds(int drinkID, int catID, int routeID, int funID, int funGroupID)
    {

        // If companyInfo.servesMixedDrinks = False Then
        // we can always do now, b/c it wont show if no preps
        // Exit Sub
        // End If

        drinkPrep.StartDrinkPrep(drinkID, catID, routeID, funID, funGroupID);
        pnlOrderDrink.Visible = false;
        pnlOrderModifier.Visible = false;
        pnlOrderModifierExt.Visible = false;
        pnlOrder.Visible = false;
        pnlOrderQuick.Visible = false;
        drinkPrep.Visible = true;
        currentTable.MiddleOfOrder = true;
        // Me.DisableControls()

        return;

        int index;
        int secondIndex;

        foreach (DataRow oRow in dtDrinkAdds.Rows)
        {
            btnOrder[index].Text = dtDrinkAdds.Rows(index)("DrinkName");
            btnOrder[index].ID = dtDrinkAdds.Rows(index)("DrinkID");
            // btnOrder(index).UpdateText(btnOrder(index).Text)
            btnOrder[index].CategoryID = catID;
            btnOrder[index].SubCategory = true;
            btnOrder[index].Functions = dtDrinkAdds.Rows(index)("DrinkFunctionID");
            btnOrder[index].FunctionGroup = dtDrinkAdds.Rows(index)("FunctionGroupID");
            btnOrder[index].FunctionFlag = dtDrinkAdds.Rows(index)("FunctionFlag");
            btnOrder[index].DrinkAdds = true;
            btnOrder[index].BackColor = c4;
            btnOrder[index].ForeColor = c3;
            // old        btnOrder(index).InvMultiplier = dtDrinkAdds.Rows(index)("InvMultiplier")
            index += 1;
            if (index == 32)
                break;
        }

        if (index < 32)
        {
            for (secondIndex = index; secondIndex <= 31; secondIndex++)
            {
                btnOrder[secondIndex].Text = (object)null;
                btnOrder[secondIndex].ID = 0;
                btnOrder[secondIndex].BackColor = c13;
                // btnOrder(secondIndex).UpdateText(btnOrder(index).Text)
            }
        }

        pnlOrderDrink.Visible = false;
        pnlOrderModifier.Visible = false;
        pnlOrderModifierExt.Visible = false;
        pnlOrder.Visible = false;
        pnlOrderQuick.Visible = false;
        drinkPrep.Visible = true;
        currentTable.MiddleOfOrder = true;

    }

    private void EventForAddingItem(object sender)
    {
        SelectedItemDetail objItem;

        objItem = (SelectedItemDetail)sender;

        // currentTable.ReferenceSIN = currentTable.SIN
        // currentTable.MiddleOfOrder = False
        currentTable.SIN += 1;
        AddItemToOrderTable(ref sender);
        testgridview.CalculateSubTotal();

        EnableControls();

    }

    private void AddItemToOrderTable(ref SelectedItemDetail newItem)
    {

        if (currentTable.IsClosed == true)
        {
            // info = New DataSet_Builder.Information_UC("Check is Closed")
            // info.Location = New Point((Me.Width - info.Width) / 2, (Me.Height - info.Height) / 2)
            // Me.Controls.Add(info)
            return;
        }

        if (dvOrder.Count > 0)
        {
            PopulateDataRowForOpenOrder(newItem);
        }
        // dsOrder.Tables("OpenOrders").Rows.Add(oRow)
        else
        {
            // 444       DisposeDataViewsOrder()
            // 444 this dispose was a big issue before 
            // i don't remember why, i removed all over
            PopulateDataRowForOpenOrder(newItem);
            // 444    CreateDataViewsOrder()
            // 444        Me.testgridview.gridViewOrder.DataSource = dvOrder
        }


        int i = 0;
        DataRowView vRow;
        // not sure which one we are using ????????
        if (newItem.SIN == newItem.SII)
        {
            foreach (DataRowView currentVRow in testgridview.gridViewOrder.DataSource)
            {
                vRow = currentVRow;
                if (vRow("sin") == newItem.SIN)
                {
                    break;
                }
                i += 1;
            }
            OpenOrdersCurrencyMan.Position = i;
            // Me.testgridview.gridViewOrder.CurrentRowIndex = i
            // OpenOrdersCurrencyMan.Position = Me.testgridview.gridViewOrder.DataSource.count - 1  'dsOrder.Tables("OpenOrders").Rows.Count - 1
            testgridview.gridViewOrder.ScrollToRow(OpenOrdersCurrencyMan.Position);
        }
        else
        {
            foreach (DataRowView currentVRow1 in testgridview.gridViewOrder.DataSource)
            {
                vRow = currentVRow1;
                if (vRow("sin") == newItem.SIN)
                {
                    break;
                }
                i += 1;
            }
            OpenOrdersCurrencyMan.Position = i;
            // Me.testgridview.gridViewOrder.CurrentRowIndex = i '+= 1
            testgridview.gridViewOrder.ScrollToRow(OpenOrdersCurrencyMan.Position);
        } // + 1)

    }

    internal void UpdateTableInfo() // Handles TabEnterScreen.ChangedMethodUse
    {

        if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
        {
            btnTableInfoMenu.Text = "Menu:  " + currentTable.CurrentMenuName;
            btnTableInfoServerNumber.Text = "Server:  " + currentServer.NickName;
            if (currentTable.IsTabNotTable == true)
            {
                if (currentTable.TabID == -888)
                {
                    btnTableInfoTableNumber.Text = "Ticket:  " + currentTable.TicketNumber;
                }
                // btnTableInfoTableNumber.Text = currentTable.TabName
                else
                {
                    btnTableInfoTableNumber.Text = "Tab:  " + currentTable.TabName;
                }
            }
            else
            {
                btnTableInfoTableNumber.Text = "Table:  " + currentTable.TableNumber;
            }

            if (currentTable.MethodUse == "Delivery")
            {
                btnTableInfoNumberOfCustomers.Text = currentTable.MethodUse.ToString + ": " + currentTable.TabName;
            }
            else if (currentTable.TabID == -888)
            {
                // this is b/c earlier we displayed ticket # not tab name
                btnTableInfoNumberOfCustomers.Text = currentTable.NumberOfCustomers + " " + currentTable.MethodUse.ToString + ": " + currentTable.TabName;
            }
            else
            {
                btnTableInfoNumberOfCustomers.Text = currentTable.NumberOfCustomers + " " + currentTable.MethodUse.ToString;
            } // & ": " & currentTable.TabName
        }
        // If currentTable.MethodUse = "Take Out" Then
        // btnTableInfoNumberOfCustomers.Text = "Take Out"
        // ElseIf currentTable.MethodUse = "Dine In" Then
        // btnTableInfoNumberOfCustomers.Text = currentTable.NumberOfCustomers & " " & "Guests: " & currentTable.TabName
        // Else
        // btnTableInfoNumberOfCustomers.Text = "Guests:  " & currentTable.NumberOfCustomers
        // End If


        else
        {
            currentTerminal.TermMethod = "Quick"; // Quick Service
            btnTableInfoMenu.Text = "Menu:  " + currentTable.CurrentMenuName;
            btnTableInfoServerNumber.Text = "Cashier:  " + currentTable.EmployeeName;
            btnTableInfoTableNumber.Text = "Ticket:  " + currentTable.TicketNumber;

            if (currentTable.MethodUse == "Delivery")
            {
                btnTableInfoNumberOfCustomers.Text = currentTable.MethodUse.ToString + ": " + currentTable.TabName;
            }
            else
            {
                btnTableInfoNumberOfCustomers.Text = currentTable.NumberOfCustomers + " " + currentTable.MethodUse.ToString + ": " + currentTable.TabName;
            }

        }

    }

    private void ButtonTableNumber_Click(object sender, EventArgs e)
    {
        UserControlHit();
        // PutUsInNormalMode()

        return;

        // 222
        switch (currentTerminal.TermMethod)
        {
            case "Table":
                {
                    // for Table Service
                    // we just change for this order...we can have someone order 1 item ToGo
                    if (currentTable.MethodUse == "Dine In")
                    {
                        currentTable.MethodUse = "Take Out";
                    }
                    else
                    {
                        currentTable.MethodUse = "Dine In";
                    }
                    UpdateTableInfo();
                    break;
                }
            case "Bar":
                {
                    // 

                    DisposingMethodScreen();

                    if (tabTimerActive == false)
                    {

                        tabDoubleClickTimer = new DateAndTime.Timer();
                        tabTimerActive = true;
                        this.tabDoubleClickTimer.Tick += TabTimerExpired;
                        tabDoubleClickTimer.Interval = 500;
                        tabDoubleClickTimer.Start();
                    }

                    else
                    {
                        // this means we just DOUBLE clicked
                        tabTimerActive = false;
                        tabDoubleClickTimer.Dispose();

                        if (currentTable.MethodUse == "Delivery")
                        {
                            if (tabScreenDisplaying == false)// TabEnterScreen.isDisplaying = False Then 
                            {
                                MethodChanged();
                            }
                            else
                            {
                                DetermineNextMethodRow();
                            }
                        }
                        else
                        {
                            MethodChanged();
                        }             // not set
                    }

                    break;
                }


            // for Table Service
            // we just change for this order...we can have someone order 1 item ToGo
            // If currentTable.MethodUse = "Dine In" Then
            // currentTable.MethodUse = "Take Out"
            // Else
            // currentTable.MethodUse = "Dine In"
            // End If
            // UpdateTableInfo()
            case "Quick":
                {
                    break;
                }
                // using guest button for changing quick service


        }

    }


    // **** we only get here in "Quick Service" ?????

    private object DetermineNextMethodRow()
    {
        int count = 0;
        string definingMethodUse;

        if (dvTerminalsUseOrder.Count <= 1)
        {
            MethodChanged();
            return default;
        }

        // i am trying to go right to tab history if already set
        // it does not work if on take out or dine in
        // If TabEnterScreen Is Nothing Then
        // ' so we won't get error below
        // TabEnterScreen = New Tab_Screen("Phone")
        // TabEnterScreen.isDisplaying = False
        // TabEnterScreen.Dispose()
        // End If

        // If TabEnterScreen.isDisplaying = False And currentTable.TabID > 0 Then
        // If currentTable.MethodUse = "Delivery" Then
        // MethodChanged()
        // Exit Function
        // End If
        // End If

        if (currentTable.MethodUse == "Pickup")
        {
            // we may have Pickup used also for delivery
            // someday we will need a check here
            definingMethodUse = "Take Out";
            wasPickupMethod = true;
        }
        else
        {
            definingMethodUse = currentTable.MethodUse;

        }

        foreach (DataRowView vRow in dvTerminalsUseOrder)
        {
            if (vRow("MethodUse") == definingMethodUse) // 444 currentTable.MethodUse Then
            {
                if (count == dvTerminalsUseOrder.Count - 1)
                {
                    count = 0;
                    break;      // telling us our next method is row zero
                }
                else
                {
                    count += 1;
                    break;
                }
            }
            count += 1;
        }
        if (dvTerminalsUseOrder.Count > 0 & !(count >= dvTerminalsUseOrder.Count))
        {
            // this makes sure we have row in dataview
            currentTable.MethodUse = dvTerminalsUseOrder[count]("MethodUse");
            currentTable.MethodDirection = dvTerminalsUseOrder[count]("MethodDirection");
        }
        else
        {
            currentTable.MethodUse = "Dine In";
            currentTable.MethodDirection = "None";
        }
        if (currentTable.MethodUse == "Take Out")
        {
            if (wasPickupMethod == true)
            {
                currentTable.MethodUse = "Pickup";
            }
        }

        UpdateTableInfo();
        GenerateOrderTables.UpdateMethodDataset();
        if (currentTable.MethodUse == "Delivery")
        {
            TestForCurrentTabInfo?.Invoke();
            // TabEnterScreen.TestForCurrentTabInfo()
            // If TabEnterScreen.HasAddress = False Then
            // Me.StartDeliveryMethod()
            // Exit Function
            // End If
        }

        return default;
        // If tabIdentifierDisplaying = True Then
        // MethodChanged()
        // End If

    }

    private void MethodChanged()
    {

        // DisposingMethodScreen()
        // this is after change or first selecting method

        switch (currentTable.MethodUse)
        {
            case "Dine In":
                {
                    StartDineInMethod(false);
                    break;
                }

            case "Take Out": // Or "Pickup"
                {

                    if (currentTable.TabID > 0)
                    {
                        StartDeliveryMethod();
                    }
                    else
                    {
                        StartTakeOutMethod();
                    }

                    break;
                }
            case "Pickup":
                {

                    if (currentTable.TabID > 0)
                    {
                        StartDeliveryMethod();
                    }
                    else
                    {
                        StartTakeOutMethod();
                    }

                    break;
                }
            // If dsorder.tables("TerminalsMethod")...termDineInIdentifier = true then go to keyboard
            case "Delivery":
                {
                    StartDeliveryMethod();
                    break;
                }

        }

    }


    private void StartTakeOutMethod() // Handles testgridview.DeliverStart
    {
        if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
        {
            orderInactiveTimer.Stop();
            orderInactiveTimer.Tick -= OrderInactiveScreenTimeout;
        }
        DisableControls();
        pnlTableInfo.Enabled = true;

        // SeatingTab = New Seating_EnterTab(False, currentTable.TabName)  'from mgmt
        // SeatingTab.Location = New Point((Me.Width - SeatingTab.Width) / 2, (Me.Height - SeatingTab.Height) / 2)
        // Me.Controls.Add(SeatingTab)
        // SeatingTab.BringToFront()
        tabIdentifierDisplaying = true;
        FireSeatingTab?.Invoke("OrderScreen", currentTable.TabName);

    }

    private void UpdateTabToTakeOut222() // 444Handles SeatingTab.OpenNewTakeOutTab 
    {

        string newTabNameString;
        newTabNameString = SeatingTab.NewTabName;

        // 444      If Not currentTable.MethodUse = "Take Out" Then
        // 444      currentTable.MethodUse = "Take Out"
        // 444     DefineMethodDirection()
        // 444    End If
        if (currentTable.MethodUse == "Pickup")
        {
            wasPickupMethod = true;
        }
        else
        {
            wasPickupMethod = false;
        }
        currentTable.MethodUse = SeatingTab.MethedUse;
        // If currentTable.MethodUse = "Take Out" Then
        // currentTable.TabID = -990 ' -990 is Take Out       'TabEnterScreen.TempTabID
        // Else
        // currentTable.TabID = -991 ' -991 is Pickup
        // End If
        currentTable.TabName = newTabNameString; // TabEnterScreen.TempTabName
        LoadTabIDinExperinceTable();
        SeatingTab.Dispose();
        EnableControls();
        UpdateTableInfo();
        tabIdentifierDisplaying = false;

    }

    private void UpdateTabName222() // 444Handles SeatingTab.OpenNewTabEvent
    {

        wasPickupMethod = false;
        currentTable.TabName = SeatingTab.NewTabName;
        currentTable.MethodUse = SeatingTab.MethedUse;

        LoadTabIDinExperinceTable();
        SeatingTab.Dispose();
        EnableControls();
        UpdateTableInfo();
        tabIdentifierDisplaying = false;

    }

    private void CancelNewTab()
    {

        SeatingTab.Dispose();
        EnableControls();
        tabIdentifierDisplaying = false;

    }

    internal void StartDeliveryMethod()
    {
        if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
        {
            orderInactiveTimer.Stop();
            orderInactiveTimer.Tick -= OrderInactiveScreenTimeout;
        }
        DisableControls();
        pnlTableInfo.Enabled = true;
        tabScreenDisplaying = true;

        FireTabScreen?.Invoke("TabID", currentTable.TabID);

        return;
        // 222 below

        // If TabEnterScreen Is Nothing Then
        // TabEnterScreen = New Tab_Screen("Phone")
        // TabEnterScreen.Location = New Point(((Me.Width - TabEnterScreen.Width - 10) / 2), ((Me.Height - TabEnterScreen.Height) / 2))
        // Me.Controls.Add(TabEnterScreen)

        // Else
        // TabEnterScreen.StartInSearch = "Phone"
        // TabEnterScreen.DetermineSearch()
        // TabEnterScreen.Show()
        // End If
        // TabEnterScreen.Visible = True
        // TabEnterScreen.InitializeOther()
        // TabEnterScreen.BringToFront()
        // tabIdentifierDisplaying = True

    }

    private void StartNewCustomerTab222() // Handles testgridview.DeliverStart
    {
        if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
        {
            orderInactiveTimer.Stop();
            orderInactiveTimer.Tick -= OrderInactiveScreenTimeout;
        }
        DisableControls();
        pnlTableInfo.Enabled = true;
        tabScreenDisplaying = true;

        FireTabScreen?.Invoke("TabID", currentTable.TabID);
        return;
        // 222
        // TabEnterScreen = New Tab_Screen("Account")
        // TabEnterScreen.Location = New Point(((Me.Width - TabEnterScreen.Width - 10) / 2), ((Me.Height - TabEnterScreen.Height) / 2))
        // Me.Controls.Add(TabEnterScreen)

        // TabEnterScreen.StartInSearch = "Phone"
        // TabEnterScreen.DetermineSearch()
        // TabEnterScreen.Show()
        // TabEnterScreen.Visible = True
        // TabEnterScreen.BringToFront()
        // tabIdentifierDisplaying = True

    }

    internal void StartDineInMethod(bool fromNewTab)
    {

        if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
        {
            orderInactiveTimer.Stop();
            orderInactiveTimer.Tick -= OrderInactiveScreenTimeout;
        }
        DisableControls();
        pnlTableInfo.Enabled = true;

        if (currentTable.MethodDirection == "KeyboardAuto" | currentTable.MethodDirection == "Keyboard")
        {
            if (fromNewTab == true & currentTable.MethodDirection == "Keyboard")
            {
                // new Tab but not automatically asking for Keyboard
                return;
            }

            // SeatingTab = New Seating_EnterTab(False, currentTable.TabName)  'from mgmt
            // SeatingTab.Location = New Point((Me.Width - SeatingTab.Width) / 2, (Me.Height - SeatingTab.Height) / 2)
            // Me.Controls.Add(SeatingTab)
            // SeatingTab.BringToFront()
            FireSeatingTab?.Invoke("OrderScreen", currentTable.TabName);
        }

        else if (ds.Tables("TabIdentifier").Rows.Count > 0)
        {
            TabIdentifierScreen = new TabSelection_UC();
            TabIdentifierScreen.InitializeCurrentSettings(currentTable.NumberOfCustomers, currentTable.TabName);

            TabIdentifierScreen.Location = new Point((this.Width - TabIdentifierScreen.Width - 10) / 2, (this.Height - TabIdentifierScreen.Height) / 2);
            this.Controls.Add(TabIdentifierScreen);

            TabIdentifierScreen.BringToFront();
        }
        else
        {
            EnableControls();
        }
        tabIdentifierDisplaying = true;

    }

    private void DisposingMethodScreen()
    {

        // If Not TabEnterScreen Is Nothing Then
        if (tabScreenDisplaying == true) // TabEnterScreen.Visible = True Then
        {
            StopDeliveryMethod();
            // currently not saving any changes, unless hit Save in TabScreen
        }
        if (TabIdentifierScreen is not null)
        {
            StopTabMethod();
        }
        if (SeatingTab is not null)
        {
            CancelNewTab();
        }
        tabIdentifierDisplaying = false;

    }



    // If tabTestNeeded = True Then
    // TabIDTest()
    // Else
    // 'this is comming from 
    // currentTable.TabID = TabEnterScreen.TempTabID
    // currentTable.TabName = TabEnterScreen.TempTabName
    // LoadTabIDinExperinceTable()
    // End If

    internal void TabReorderButtonSelected(DataTable dt, bool tabTestNeeded) // Handles TabEnterScreen.SelectedReOrder
    {
        DataRow funRow;

        foreach (DataRow oldRow in dt.Rows)  // dsCustomer.Tables("TabPreviousOrdersbyItem").Rows    'dtTabPreviousOrdersByItem.Rows '
        {
            var currentItem = new SelectedItemDetail();


            currentItem.ExperienceNumber = currentTable.ExperienceNumber; // expNum  
            currentItem.OrderNumber = (object)null;

            if (object.ReferenceEquals(oldRow("MenuID"), DBNull.Value))
            {
                currentItem.MenuID = currentTable.CurrentMenu;
            }
            else
            {
                currentItem.MenuID = oldRow("MenuID");
            }
            currentItem.ShiftID = currentTerminal.CurrentShift; // currentServer.ShiftID  'oldRow("ShiftID")
            currentItem.EmployeeID = currentTable.EmployeeID; // empID
            currentItem.Check = currentTable.CheckNumber;   // oldRow("CheckNumber")
            currentItem.Customer = oldRow("CustomerNumber");
            currentItem.Course = oldRow("CourseNumber");

            if (oldRow("sin") == oldRow("sii"))
            {
                // this is a main item
                currentTable.ReferenceSIN = currentTable.SIN;
            }
            else
            {

            }
            currentItem.SIN = currentTable.SIN;
            currentItem.SII = currentTable.ReferenceSIN;
            currentItem.si2 = oldRow("si2");

            currentItem.Quantity = oldRow("Quantity");
            // below is wrong ********** 666
            // we are using OpenDecimal1
            // we are not putting anything in OrederDetail as to InvMultiplier
            // dt we are using: TabPreviousOrdersByItem2
            // sqlAdapter to fill: sqlTabPreviousOrdersLocation
            currentItem.InvMultiplier = 1;  // *** 666 oldRow("InvMultiplier")
            currentItem.ItemStatus = 0; // oldRow("ItemStatus")
            currentItem.Name = oldRow("ItemName");
            currentItem.TerminalName = oldRow("TerminalName");
            currentItem.ChitName = oldRow("ChitName");
            currentItem.ItemPrice = oldRow("ItemPrice");

            currentItem.Price = oldRow("ItemPrice") * oldRow("Quantity");
            // .TaxPrice = oldRow("TaxPrice")
            // .TaxID = oldRow("TaxID")

            currentItem.ForceFreeID = 0; // Nothing
            currentItem.ForceFreeAuth = 0; // Nothing
            currentItem.ForceFreeCode = 0; // Nothing

            currentItem.FunctionID = oldRow("FunctionID");
            try
            {
                // 999
                // change this where we don't pull with current item
                // do it where we only pull when flag is needed 
                // as in an if, then statmenet
                funRow = dsOrder.Tables("Functions").Rows.Find(oldRow("FunctionID"));
                currentItem.FunctionGroup = funRow("FunctionGroupID");
                currentItem.FunctionFlag = funRow("FunctionFlag");
            }
            catch (Exception ex)
            {
                currentItem.FunctionGroup = 0;
                currentItem.FunctionFlag = "O";
            }

            currentItem.ID = oldRow("ItemID");
            currentItem.Category = oldRow("CategoryID");
            currentItem.FoodID = oldRow("FoodID");
            currentItem.DrinkCategoryID = oldRow("DrinkCategoryID");
            currentItem.DrinkID = oldRow("DrinkID");
            currentItem.RoutingID = oldRow("RoutingID");
            currentItem.PrintPriorityID = oldRow("PrintPriorityID");

            currentItem.TerminalID = currentTerminal.TermID;    // oldRow("TerminalID")

            currentTable.SIN += 1;
            AddItemToOrderTable(ref currentItem);
        }

        EnableControls();
        testgridview.CalculateSubTotal();

    }

    private void StopDeliveryMethod() // Handles TabEnterScreen.TabScreenDisposing
    {

        // we will need to fix if we turn back on timer 
        // TabEnterScreen is initialized in Login

        orderTimeoutCounter = 1;
        if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
        {
            orderInactiveTimer.Tick += OrderInactiveScreenTimeout;
            orderInactiveTimer.Start();
        }

        // If TabEnterScreen.attemptedToEdit = True Then
        // GenerateOrderTables.UpdateTabInfo(TabEnterScreen.StartInSearch)
        // End If

        tabScreenDisplaying = false;
        TabScreenDisposing?.Invoke();

    }

    private void StopTabMethod()
    {

        orderTimeoutCounter = 1;
        if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
        {
            orderInactiveTimer.Tick += OrderInactiveScreenTimeout;
            orderInactiveTimer.Start();
        }

        TabIdentifierScreen.Dispose();
        TabIdentifierScreen = default;
        tabIdentifierDisplaying = false;

        UpdateTableInfo();
        EnableControls();

    }


    private void ButtonMenu_Click(object sender, EventArgs e)
    {
        UserControlHit();
        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(EndOfItem(true), false, false)))
            return;
        PutUsInNormalMode();
        pnlMain.Visible = true;
        pnlMain3.Visible = false;
        int index;
        int tempPrimaryMenuID;
        int tempSecondaryMenuID;

        if (currentTerminal.currentPrimaryMenuID == currentTerminal.initPrimaryMenuID)
        {
            tempPrimaryMenuID = currentTerminal.primaryMenuID;
            tempSecondaryMenuID = currentTerminal.secondaryMenuID;
        }
        else
        {
            tempPrimaryMenuID = currentTerminal.secondaryMenuID;
            tempSecondaryMenuID = currentTerminal.primaryMenuID;
        }

        if (currentTable.StartingMenu == currentTerminal.currentPrimaryMenuID)
        {
            if (currentTable.CurrentMenu == currentTerminal.currentPrimaryMenuID)
            {
                currentTerminal.CurrentMenuID = tempSecondaryMenuID;
                currentTable.CurrentMenu = tempSecondaryMenuID;
                btnTableInfoMenu.BackColor = c3;
                btnTableInfoMenu.ForeColor = c2;
                if (currentTerminal.currentPrimaryMenuID == currentTerminal.initPrimaryMenuID)
                {
                    currentTable.IsPrimaryMenu = false;
                }
                else
                {
                    currentTable.IsPrimaryMenu = true;
                }
            }
            else
            {
                currentTerminal.CurrentMenuID = tempPrimaryMenuID;
                currentTable.CurrentMenu = tempPrimaryMenuID;
                btnTableInfoMenu.BackColor = c2;
                btnTableInfoMenu.ForeColor = c3;
                if (currentTerminal.currentPrimaryMenuID == currentTerminal.initPrimaryMenuID)
                {
                    currentTable.IsPrimaryMenu = true;
                }
                else
                {
                    currentTable.IsPrimaryMenu = false;
                }
            }
        }

        else if (currentTable.CurrentMenu == currentTerminal.currentPrimaryMenuID)
        {
            currentTerminal.CurrentMenuID = currentTable.StartingMenu;
            currentTable.CurrentMenu = currentTable.StartingMenu;
            btnTableInfoMenu.BackColor = c3;
            btnTableInfoMenu.ForeColor = c2;
            if (currentTerminal.currentPrimaryMenuID == currentTerminal.initPrimaryMenuID)
            {
                currentTable.IsPrimaryMenu = false;
            }
            else
            {
                currentTable.IsPrimaryMenu = true;
            }
        }
        else
        {
            currentTerminal.CurrentMenuID = tempPrimaryMenuID;
            currentTable.CurrentMenu = tempPrimaryMenuID;
            btnTableInfoMenu.BackColor = c2;
            btnTableInfoMenu.ForeColor = c3;
            if (currentTerminal.currentPrimaryMenuID == currentTerminal.initPrimaryMenuID)
            {
                currentTable.IsPrimaryMenu = true;
            }
            else
            {
                currentTable.IsPrimaryMenu = false;
            }
        }

        PopulateMainButtons();

        foreach (DataRow oRow in ds.Tables("MenuChoice").Rows)
        {
            if (oRow("MenuID") == currentTable.CurrentMenu)
            {
                currentTable.CurrentMenuName = oRow("MenuName");
                break;
            }
        }
        UpdateTableInfo();

        if (!(currentTable.TabID == -888) & !(currentTerminal.TermMethod == "Quick"))
        {
            ClearOrderPanels();
            pnlOrder.Visible = false;
            pnlOrderQuick.Visible = false;
        }
        // FirstStepOrdersPending() only at beginning
        else
        {
            for (index = 1; index <= 10; index++)
            {
                if (btnMain[index].CategoryID > 0)
                {
                    RunFoodsRoutine(btnMain[index]);
                    break;
                }
            }
        }

    }

    private void ButtonNumberOfCustomers_Click(object sender, EventArgs e)
    {
        UserControlHit();
        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(EndOfItem(true), false, false)))
            return;

        if (currentTable.LastStatus == 1)
            return; // can't change on closed check

        if (tabTimerActive == false)
        {
            if (tabScreenDisplaying == false) // Me.TabEnterScreen.Visible = False Then
            {
                tabDoubleClickTimer = new DateAndTime.Timer();
                tabTimerActive = true;
                this.tabDoubleClickTimer.Tick += TabTimerExpired;
                tabDoubleClickTimer.Interval = 750;
                tabDoubleClickTimer.Start();
            }

            if (tabIdentifierDisplaying == true)
            {
                DisposingMethodScreen();
                if (dvTerminalsUseOrder.Count > 1)
                {
                    DetermineNextMethodRow();
                    MethodChanged();
                }
                tabTimerActive = false;
                if (tabDoubleClickTimer is not null)
                {
                    // this is Nothing verification is just for the times when we have
                    // no address in delivery, b/c Delivery Panel begins at start
                    tabDoubleClickTimer.Dispose();
                }
            }
            else
            {
                DisposingMethodScreen();
            }
        }

        else
        {

            // this means we just DOUBLE clicked
            DisposingMethodScreen();
            tabTimerActive = false;
            tabDoubleClickTimer.Dispose();

            if (currentTable.MethodUse == "Delivery")
            {
                // If TabEnterScreen.isDisplaying = False Then 'And currentTable.TabID > 0 Then   
                if (tabScreenDisplaying == false) // Me.TabEnterScreen.Visible = False Then
                {
                    MethodChanged();
                }
                else
                {
                    DetermineNextMethodRow();
                }
            }
            else
            {
                MethodChanged();
            }             // not set

        }
        return;




        // *** we could make this double click action for everything
        // downfall, there is a delay to wait for the second click

        switch (currentTerminal.TermMethod)
        {
            case "Table":
                {
                    changeNumberOfCustomers = new DataSet_Builder.NumberOfCustomers_UC();
                    changeNumberOfCustomers.ColorButtonFromStart(currentTable.NumberOfCustomers);
                    changeNumberOfCustomers.Location = new Point((this.Width - changeNumberOfCustomers.Width) / 2, (this.Height - changeNumberOfCustomers.Height) / 2);
                    this.Controls.Add(changeNumberOfCustomers);

                    changeNumberOfCustomers.BringToFront();
                    DisableControls();
                    break;
                }
            case "Bar":
                {
                    changeNumberOfCustomers = new DataSet_Builder.NumberOfCustomers_UC();
                    changeNumberOfCustomers.ColorButtonFromStart(currentTable.NumberOfCustomers);
                    changeNumberOfCustomers.Location = new Point((this.Width - changeNumberOfCustomers.Width) / 2, (this.Height - changeNumberOfCustomers.Height) / 2);
                    this.Controls.Add(changeNumberOfCustomers);

                    changeNumberOfCustomers.BringToFront();
                    DisableControls();
                    break;
                }
            case "Quick":
                {
                    DisposingMethodScreen();

                    if (tabTimerActive == false)
                    {
                        tabDoubleClickTimer = new DateAndTime.Timer();
                        tabTimerActive = true;
                        this.tabDoubleClickTimer.Tick += TabTimerExpired;
                        tabDoubleClickTimer.Interval = 500;
                        tabDoubleClickTimer.Start();
                    }
                    else
                    {
                        // this means we just DOUBLE clicked
                        tabTimerActive = false;
                        tabDoubleClickTimer.Dispose();

                        if (currentTable.MethodUse == "Delivery")
                        {
                            if (tabScreenDisplaying == false) // TabEnterScreen.isDisplaying = False Then 'And currentTable.TabID > 0 Then   
                            {
                                MethodChanged();
                            }
                            else
                            {
                                DetermineNextMethodRow();
                            }
                        }
                        else
                        {
                            MethodChanged();
                        }             // not set

                    }

                    break;
                }

        }

    }

    private void TabTimerExpired(object sender, EventArgs e)
    {
        tabTimerActive = false;
        tabDoubleClickTimer.Dispose();
        // **** this means we clicked


        // If currentTable.MethodUse = "Delivery" And TabEnterScreen.isDisplaying = False And currentTable.TabID > 0 Then
        // MethodChanged() 'pulls up
        // Else
        DetermineNextMethodRow();
        if (tabScreenDisplaying == true) // TabEnterScreen.isDisplaying = True Then
        {
            // this is b/c determineNextRow will remove delivery screen
            // TabEnterScreen.isDisplaying = False
            // 444      tabScreenDisplaying = False
        }
        // End If

    }

    private void NumberOfCustomersSelected(int newNumber)
    {
        UserControlHit();

        DataRow oRow;
        // Dim bRow As DataRow

        if (newNumber == currentTable.NumberOfCustomers)
        {
            EnableControls();
            changeNumberOfCustomers.Dispose();
            return;
        }

        currentTable.NumberOfCustomers = newNumber;

        if (currentTable.IsTabNotTable == true)
        {
            foreach (DataRow currentORow in dsOrder.Tables("AvailTabs").Rows)
            {
                oRow = currentORow;
                if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                {
                    oRow("NumberOfCustomers") = currentTable.NumberOfCustomers;
                }
            }
        }
        // bRow = (dsBackup.Tables("AvailTabsTerminal").Rows.Find(currentTable.ExperienceNumber))
        // If Not (bRow Is Nothing) Then
        // bRow("NumberOfCustomers") = currentTable.NumberOfCustomers
        // End If
        else
        {
            foreach (DataRow currentORow1 in dsOrder.Tables("AvailTables").Rows)
            {
                oRow = currentORow1;
                if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                {
                    oRow("NumberOfCustomers") = currentTable.NumberOfCustomers;
                }
            }
            // bRow = (dsBackup.Tables("AvailTablesTerminal").Rows.Find(currentTable.ExperienceNumber))
            // If Not (bRow Is Nothing) Then
            // bRow("NumberOfCustomers") = currentTable.NumberOfCustomers
            // End If
        }

        // sss      GenerateOrderTables.SaveAvailTabsAndTables()
        EnableControls();
        changeNumberOfCustomers.Dispose();
        UpdateTableInfo();

    }

    private void ClearOrderPanel()
    {
        int index;

        for (index = 0; index <= 31; index++)
        {
            if (!(btnOrder[index].ID == 0))
            {
                {
                    ref var withBlock = ref btnOrder[index];
                    withBlock.Text = (object)null;
                    withBlock.ID = 0;
                    withBlock.DrinkCategory = false;
                    withBlock.SubCategory = false;
                    withBlock.Invalidate();
                }
            }

        }

    }

    private void ResetDrinkCategories()
    {
        int index;

        for (index = 0; index <= 31; index++)
        {
            {
                ref var withBlock = ref btnOrder[index];
                withBlock.DrinkCategory = false;
                // .SubCategory = False
                withBlock.DrinkAdds = false;
            }
        }
    }

    private void SendOrderButton_Click(bool alsoClose)
    {
        UserControlHit();
        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(EndOfItem(false), false, false)))
            return;

        SendingOrderRoutine();
        if (alsoClose == true)
        {
            CashClose_UC argccDisplay = null;
            LeaveAndSave(ccDisplay: ref argccDisplay);
        }

    }

    internal void SendingOrderRoutine()
    {
        var oDetail = default(OrderDetailInfo);
        DataRow oRow;
        bool limittoOneCourse = false;
        bool thereIsAnOrder = false;

        try
        {
            if (limittoOneCourse == false)
            {
                foreach (DataRow currentORow in dsOrder.Tables("OpenOrders").Rows)
                {
                    oRow = currentORow;  // dvOrderPrint
                    if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                    {
                        if (oRow("ItemStatus") == 0)
                        {
                            thereIsAnOrder = true;
                            if (oRow("FunctionFlag") == "F")
                            {
                                oDetail.NumDinners += oRow("Quantity");
                            }
                            else if (oRow("FunctionFlag") == "O")
                            {
                                oDetail.numApps += oRow("Quantity");     // not just apps
                            }
                            // If oRow("FunctionID") = 1 Then
                            // oDetail.NumDinners += oRow("Quantity")
                            // Else
                            // oDetail.numApps += oRow("Quantity")
                            // End If
                            else if (oRow("FunctionFlag") == "D")
                            {
                                if (oRow("sin") == oRow("sii"))
                                {
                                    oDetail.numDrinks += oRow("Quantity");
                                }
                            }
                            oDetail.totalDollar += oRow("Price");
                        }
                    }
                }
            }
            else
            {
                oDetail.isMainCourse = true;
                foreach (DataRow currentORow1 in dsOrder.Tables("OpenOrders").Rows)
                {
                    oRow = currentORow1;
                    if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                    {
                        if (oRow("ItemStatus") == 0)
                        {
                            thereIsAnOrder = true;
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

        if (thereIsAnOrder == false)
            return;

        if (oDetail.NumDinners >= currentTable.NumberOfCustomers / 2)
        {
            oDetail.isMainCourse = true;
        }

        // If oDetail.NumDinners > oDetail.numApps Then
        // oDetail.isMainCourse = True
        // Else
        // If currentTable.NumberOfCustomers > 0 And oDetail.NumDinners > (currentTable.NumberOfCustomers / 2) Then
        // oDetail.isMainCourse = True
        // End If
        // End If
        var prt = new PrintHelper();

        oDetail.orderTime = DateTime.Now;
        oDetail.orderNumber = CreateNewOrder(oDetail);
        DetermineTruncatedOrderNumber(oDetail);
        prt.oDetail = oDetail;
        prt.SendingOrder(default); // (oDetail)

        GenerateOrderTables.ChangeStatusInDataBase(3, oDetail.orderNumber, oDetail.isMainCourse, oDetail.totalDollar, default, default);
        // prt.SendingOrder222()

        foreach (DataRow currentORow2 in dsOrder.Tables("OpenOrders").Rows)
        {
            oRow = currentORow2;  // dvOrderPrint
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("ItemStatus") == 0)
                {
                    oRow("OrderNumber") = oDetail.orderNumber;
                    oRow("ItemStatus") = 2;
                }
            }
        }

        // currently just putting this in order detail
        // AddStatusChangeData(currentTable.ExperienceNumber, 3, oDetail.orderNumber, oDetail.isMainCourse, oDetail.totalDollar)
        // SaveESCStatusChangeData(3, oDetail.orderNumber, oDetail.isMainCourse, oDetail.totalDollar)

    }

    private string DeterminePrintString222(DataRow sRow)
    {
        return default;

        // this is the old printing routine 

        // If vRow("RoutingID") = printingRouting(1) Then
        // If vRow("FunctionID") = 1 Or vRow("FunctionID") = 2 Then
        // sWriter1.Write("*RT*")        'RT ....Reverse Text
        // End If
        // sWriter1.WriteLine(vRow("ItemName"))
        // If s1 = False Then s1 = True
        // '
        // ElseIf vRow("RoutingID") = printingRouting(2) Then
        // If vRow("FunctionID") = 1 Or vRow("FunctionID") = 2 Then
        // sWriter2.Write("*RT*")        'RT ....Reverse Text
        // End If
        // '       sWriter2.WriteLine(vRow("ItemName"))
        // If s2 = False Then s2 = True'

        // ElseIf vRow("RoutingID") = printingRouting(3) Then   'function 4 is drink
        // If vRow("FunctionFlag") = "D" Then
        // If vRow("sin") = vRow("sii") Then
        // sWriter3.Write("*RT*")        'RT ....Reverse Text
        // End If
        // '    sWriter3.WriteLine(vRow("ItemName"))
        // If s3 = False Then s3 = True

        // End If
        // 
        // End If
        // '

    }







    private void PlaceOrderInExperienceStatusChange222(int status, int orderNumber, bool isMainCourse, float avgDollar)
    {

        SqlClient.SqlCommand cmd;

        cmd = new SqlClient.SqlCommand("INSERT INTO ExperienceStatusChange (ExperienceNumber, StatusTime, TableStatusID, OrderNumber, IsMainCourse, AverageDollar) VALUES (@ExperienceNumber, @StatusTime, @TableStatusID, @OrderNumber, @IsMainCourse, @AverageDollar)", sql.cn);

        cmd.Parameters.Add(new SqlClient.SqlParameter("@ExperienceNumber", SqlDbType.BigInt, 8));
        cmd.Parameters("@ExperienceNumber").Value = currentTable.ExperienceNumber;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@StatusTime", SqlDbType.DateTime, 8));
        cmd.Parameters("@StatusTime").Value = DateTime.Now;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@TableStatusID", SqlDbType.Int, 4));
        cmd.Parameters("@TableStatusID").Value = status;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@OrderNumber", SqlDbType.Int, 4));
        cmd.Parameters("@OrderNumber").Value = orderNumber;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@IsMainCourse", SqlDbType.Bit, 1));
        cmd.Parameters("@IsMainCourse").Value = isMainCourse;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@AverageDollar", SqlDbType.Money, 8));
        cmd.Parameters("@AverageDollar").Value = avgDollar;

        sql.cn.Open();
        sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
        cmd.ExecuteNonQuery();
        sql.cn.Close();


    }


    private object GetLastOrderNumber()
    {
        int _lastOrderNumber;
        return default;

    }







    private void btnModifyClick(object sender, EventArgs e)
    {
        UserControlHit();

        // If modifyComboBox.Visible = True Then
        // modifyComboBox.Visible = False
        // Me.testgridview.gridViewOrder.Enabled = True
        // Else

        int rowNum = OpenOrdersCurrencyMan.Position;  // gridViewOrder.CurrentCell.RowNumber

        int valueSIN;
        int valueSII;
        int valueSI2;
        // Dim valueText As String
        int index;
        int valueIndex;

        try
        {
            valueSIN = (int)testgridview.gridViewOrder.Item(rowNum, 1);
            valueSII = (int)testgridview.gridViewOrder.Item(rowNum, 2);
            // valueText = CType(Me.testgridview.gridViewOrder.Item(rowNum, 8), String)
            valueSI2 = (int)testgridview.gridViewOrder.Item(rowNum, 3);
        }

        catch (Exception ex)
        {
            return;
        }

        var oRow = default(DataRow);
        int newStatus;


        // If valueSII = valueSIN Then
        // '   *** need to change to reflect quantity
        // info = New DataSet_Builder.Information_UC("You can only Modify the sub-Items of an Order. Please Delete Item and reorder.")
        // info.Location = New Point((Me.Width - info.Width) / 2, (Me.Height - info.Height) / 2)
        // Me.Controls.Add(info)
        // info.BringToFront()

        // Else
        int catID;
        int drinkCatID;
        int funID;
        string funFlag;
        int currentItemID;
        decimal currentPrice;
        int currentSIN;
        int currentSII;
        string currentName;
        string currentTerminalName;
        string currentChitName;
        int currentQ;
        int currentCN;
        int currentC;
        var alreadyOrdered = default(bool);

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

        if (!(oRow("ItemID") > 0))
            return;
        // this is any non ordered item, transfered, customer panel.....

        if (oRow("ItemStatus") > 1)
        {
            alreadyOrdered = true;

            // info = New DataSet_Builder.Information_UC("You can only Modify items not sent to the Kitchen.")
            // info.Location = New Point((Me.Width - info.Width) / 2, (Me.Height - info.Height) / 2)
            // Me.Controls.Add(info)
            // info.BringToFront()
            // Exit Sub
        }


        catID = oRow("CategoryID");
        drinkCatID = oRow("DrinkCategoryID");
        funID = oRow("FunctionID");
        funFlag = oRow("FunctionFlag");
        currentItemID = oRow("ItemID");
        currentPrice = oRow("Price");
        currentSIN = oRow("sin");
        currentSII = oRow("sii");
        currentName = oRow("ItemName");
        currentTerminalName = oRow("TerminalName");
        currentChitName = oRow("ChitName");
        currentQ = oRow("Quantity");
        currentCN = oRow("CustomerNumber");
        currentC = oRow("CourseNumber");

        string populatingTable;

        if (funFlag == "M")   // catID > 100 Then
        {
            populatingTable = "ModifierTable";
        }
        else if (currentTable.IsPrimaryMenu == true)
        {
            populatingTable = "MainTable";
        }
        else
        {
            populatingTable = "SecondaryMainTable";
        }

        // If valueSI2 >= 10 Then
        // MsgBox("You may not Modify this item. You must delete and ReOrder.")
        // Exit Sub
        // End If

        if (valueSII == valueSIN)
        {
            {
                var withBlock = dvSendToModify;
                withBlock.Table = dsOrder.Tables("OpenOrders");
                withBlock.RowFilter = "sii = '" + valueSII + "'";
            }

            if (funFlag == "F" | funFlag == "O" | funFlag == "M")       // funID < 4 Then
            {
                DisplayModifyOrder(currentSII, currentSIN, currentTerminalName, currentName, currentChitName, dvSendToModify, true, currentItemID, currentPrice, funID, funFlag, currentCN, currentQ, currentC, alreadyOrdered);
            }
            else if (funFlag == "D")   // funID >= 4 And funID <= 7 Then
            {
                DisplayModifyOrder(currentSII, currentSIN, currentTerminalName, currentName, currentChitName, dvSendToModify, false, currentItemID, currentPrice, funID, funFlag, currentCN, currentQ, currentC, alreadyOrdered);
            }
        }


        else if (funFlag == "F" | funFlag == "O" | funFlag == "M")  // funID = 2 Or funID = 3 Then
        {
            // dvFoodJoin = New DataView(ds.Tables("FoodTable"), "CategoryID ='" & catID & "'", "FoodID", DataViewRowState.CurrentRows)
            {
                var withBlock1 = dvFoodJoin;
                withBlock1.Table = ds.Tables(populatingTable + catID);
                withBlock1.Sort = "FoodName";
            }
            DisplayModifyOrder(default, currentSIN, currentTerminalName, currentName, currentChitName, dvFoodJoin, true, currentItemID, currentPrice, funID, funFlag, currentCN, currentQ, currentC, alreadyOrdered);
        }
        else if (funFlag == "D")       // funID >= 4 And funID <= 7 Then
        {
            // MsgBox("You can not Modify a Drink Order. Please Delete Item and reorder.")
            // Exit Sub
            // dvDrink = New DataView(ds.Tables("Drink"), "DrinkCategoryID ='" & drinkCatID & "'", "DrinkIndex", DataViewRowState.CurrentRows)
            {
                var withBlock2 = dvDrink;
                withBlock2.Table = ds.Tables("Drink");
                withBlock2.RowFilter = "DrinkCategoryID ='" + drinkCatID + "'";
                withBlock2.Sort = "DrinkIndex";
            }

            DisplayModifyOrder(default, currentSIN, currentTerminalName, currentName, currentChitName, dvDrink, false, currentItemID, currentPrice, funID, funFlag, currentCN, currentQ, currentC, alreadyOrdered);
        }


    }

    private void DisplayModifyOrder(int currentSII, int currentSIN, string currentTerminalName, string currentname, string currentChitName, DataView dvModify, bool isFood, int currentItemID, decimal currentPrice, int funID, string funFlag, int cn, int q, int c, bool alreadyOrdered)
    {

        modifyOrderUserControl = new ModifyOrder_UC(currentSII, currentSIN, currentTerminalName, currentname, currentChitName, dvModify, isFood, currentItemID, currentPrice, funID, funFlag, cn, q, c, alreadyOrdered);
        modifyOrderUserControl.Location = new Point((this.Width - modifyOrderUserControl.Width) / 2, (this.Height - modifyOrderUserControl.Height) / 2);
        this.Controls.Add(modifyOrderUserControl);
        modifyOrderUserControl.BringToFront();
        DisableControls();

    }

    private void UpdateModifiedSubTotal()
    {

        testgridview.CalculateSubTotal();
        EnableControls();

        int numberNONCourse2;
        if (dsOrder.Tables("OpenOrders").Rows.Count > 0)
        {
            numberNONCourse2 = dsOrder.Tables("OpenOrders").Compute("Count(Quantity)", "CourseNumber > 2 OR CourseNumber = 1");
        }
        else
        {
            numberNONCourse2 = 0;
        }


        if (!(numberNONCourse2 == 0))
        {
            testgridview.MakeRoomForCourseInfo();
        }

        int maxQuantity;
        maxQuantity = dsOrder.Tables("OpenOrders").Compute("Max(Quantity)", "sin = sii");
        testgridview.TestQuantityForDisplay(maxQuantity);


    }

    private void UpdateModifiedItem()
    {
        UserControlHit();
        EnableControls();

        if (modifyOrderUserControl.ModifyItemID > 0)
        {
            var oRow = default(DataRow);

            if (!(typeProgram == "Online_Demo"))
            {
                oRow = dsOrder.Tables("OpenOrders").Rows.Find(modifyOrderUserControl.ModifyCurrentSIN);
            }
            else
            {
                foreach (DataRow currentORow in dsOrder.Tables("OpenOrders").Rows)
                {
                    oRow = currentORow;
                    if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                    {
                        if (oRow("sin") == modifyOrderUserControl.ModifyCurrentSIN)
                        {
                            break;
                        }
                    }
                }
            }
            // For Each oRow In dsOrder.Tables("OpenOrders").Rows
            // If oRow("sin") = Me.modifyOrderUserControl.ModifyCurrentSIN Then
            oRow("ItemID") = modifyOrderUserControl.ModifyItemID;
            oRow("ItemName") = modifyOrderUserControl.ModifyItemName;
            oRow("TerminalName") = modifyOrderUserControl.ModifyAbrevName;
            oRow("ChitName") = modifyOrderUserControl.ModifyChitName;
            oRow("Price") = modifyOrderUserControl.ModifySurcharge;
            oRow("TaxPrice") = GenerateOrderTables.DetermineTaxPrice(modifyOrderUserControl.ModifyTaxID, modifyOrderUserControl.ModifySurcharge);
            oRow("TaxID") = modifyOrderUserControl.ModifyTaxID;
            if (modifyOrderUserControl.isFoodItem == true)
            {
                oRow("FoodID") = modifyOrderUserControl.ModifyItemID;
            }
            else
            {
                oRow("DrinkID") = modifyOrderUserControl.ModifyItemID;
            }
            oRow("RoutingID") = modifyOrderUserControl.ModifyRoutingID;

            testgridview.CalculateSubTotal();
            // End If
            // Next
        }

    }

    private void CancelModifiedItem()
    {
        EnableControls();

    }

    private void Leave_Click()
    {

        UserControlHit();
        // already done     If EndOfItem(False) = False Then Exit Sub

        if (!(currentTerminal.TermMethod == "Quick") | currentServer.EmployeeID == 6986)
        {
            CashClose_UC argccDisplay = null;
            LeaveAndSave(ccDisplay: ref argccDisplay);
        }
        else
        {
            DisposeDataViewsOrder();
            AdjustOpenOrderPosition();

            if (currentTable.EmptyCustPanel > 0)
                RemoveEmptyPanel();
            if (IsManagerMode == true)
            {
                var argccDisplay1 = default;
                TermOrder_Disposing?.Invoke(actingManager, ref argccDisplay1);
            }
            else
            {
                var argccDisplay2 = default;
                TermOrder_Disposing?.Invoke(currentServer, ref argccDisplay2);
            }
        }

    }

    // Private Sub SaveDontLeave() Handles testgridview.JustSaveOrder

    // If dsOrder.Tables("OpenOrders").Rows.Count > 0 Then
    // AdjustOpenOrderPosition()
    // GenerateOrderTables.SaveOpenOrderData()
    // End If

    // End Sub

    private void LeaveAndSave([Optional, DefaultParameterValue(default)] ref CashClose_UC ccDisplay)  // Handles testgridview.LeaveOrderView
    {

        if (repeatOrderUserControl is not null)
        {
            // this is different b/c we use for repeat order and pending order
            // we can change
            repeatOrderUserControl.Dispose();
        }
        if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar" | currentServer.EmployeeID == 6986)
        {
            orderInactiveTimer.Stop();
            orderInactiveTimer.Tick -= OrderInactiveScreenTimeout;

            DisposeDataViewsOrder();
            AdjustOpenOrderPosition();

            if (currentTable.EmptyCustPanel > 0)
                RemoveEmptyPanel();
            if (IsManagerMode == true)
            {
                // DisposeObjects()
                TermOrder_Disposing?.Invoke(actingManager, ref ccDisplay);
            }
            else
            {
                // DisposeObjects()
                TermOrder_Disposing?.Invoke(currentServer, ref ccDisplay);
            }
        }

        else
        {

            QuickOrder_NotDisposing?.Invoke();
        }

        // GC.Collect()
        // Me.Dispose()

    }

    internal void DisposeOrderFormObjects()
    {
        int i;

        for (i = 1; i <= 20; i++)
            // btnMain(i).Dispose()
            btnMain[i] = default;
        for (i = 1; i <= 10; i++)
            // btnModifier(i).Dispose()
            btnModifier[i] = default;
        if (!(currentTerminal.TermMethod == "Quick"))
        {
            for (i = 0; i <= 31; i++)
                // btnOrder(i).Dispose()
                btnOrder[i] = default;
        }
        else
        {
            for (i = 0; i <= 59; i++)
                // btnOrder(i).Dispose()
                btnOrderQuick[i] = default;
        }

        for (i = 1; i <= 60; i++)
            // btnOrderDrink(i).Dispose()
            btnOrderDrink[i] = default;
        for (i = 0; i <= 23; i++)
            // btnOrderModifier(i).Dispose()
            btnOrderModifier[i] = default;

        btnOrderModifierCancel = (object)null;
        btnMainNext = default;
        btnMainNextMain3 = default;
        btnMainPrevious = default;

        btnModifierNo = default;
        btnModifierAdd = default;
        btnModifierExtra = default;
        btnModifierOnFly = default;
        btnModifierNoMake = default;
        btnModifierOnSide = default;
        btnModifierNoCharge = default;
        btnModifierSpecial = default;
        btnModifierRepeat = default;
        btnModifierBlank = (object)null;

        for (i = 1; i <= 5; i++)
            btnCustomer[i] = default;

        btnCustomerNext = default;

        onFullPizza.DataSource = (object)null;
        onFirstHalf.DataSource = (object)null;
        onSecondHalf.DataSource = (object)null;

        extraNoUserControl.Dispose();
        extraNoUserControl = default;
        testgridview.Dispose();
        testgridview = default;

    }

    private void RemoveEmptyPanel()
    {
        // for terminal data

        foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("CustomerNumber") == currentTable.EmptyCustPanel)
                {
                    GenerateOrderTables.DeleteOpenOrdersRowTerminal(oRow);
                    return;
                }
            }
        }
    }

    private void UpdateTableStatus222(int tn, int newStatus, float avg)
    {
        // may be able to improve efficiency by not looking through each row
        // this will take knowing the row index prior and sending to sub

        Interaction.MsgBox("WE do not use this step, Use AddStatusChangeData");

        var dt = DateTime.Now;
        DataRow oRow;

        if (newStatus == 2)
        {
            foreach (DataRow currentORow in dtCurrentStatus.Rows)
            {
                oRow = currentORow;
                if (oRow("TableNumber") == tn)
                {
                    oRow("SatTime") = dt;
                    oRow("LastStatusTime") = dt;
                    oRow("AverageDollar") = avg;
                    oRow("LastStatus") = newStatus;
                }
            }
        }
        else
        {
            foreach (DataRow currentORow1 in dtCurrentStatus.Rows)
            {
                oRow = currentORow1;
                if (oRow("TableNumber") == tn)
                {
                    oRow("LastStatusTime") = dt;
                    oRow("AverageDollar") = avg;
                    oRow("LastStatus") = newStatus;
                }
            }
        }

    }

    private void BtnModifierAdd_Click(object sender, EventArgs e)
    {

        UserControlHit();
        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(EndOfItem(false), false, false)))
            return;

        if (ADDorNOmode == true)
        {
            PutUsInNormalMode();
        }
        else
        {
            if (btnModifierAdd.Text == "Prep")
            {
                currentTable.OrderingStatus = "Prep"; // Nothing
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(sender.text, "Extra", false)))
            {
                currentTable.OrderingStatus = "EXTRA";
            }
            else
            {
                currentTable.OrderingStatus = "ADD";
            }

            btnModifierAdd.BackColor = c9;
            btnModifierNo.BackColor = c4;
            StartAddNOMode();
        }

    }

    private void BtnModifierNo_Click(object sender, EventArgs e)
    {

        UserControlHit();
        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(EndOfItem(false), false, false)))
            return;

        if (ADDorNOmode == true)
        {
            PutUsInNormalMode();
        }
        else
        {
            if (btnModifierAdd.Text == "Prep")
            {
                currentTable.OrderingStatus = "Call"; // Nothing
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(sender.text, "Extra", false)))
            {
                currentTable.OrderingStatus = "EXTRA";
            }
            else
            {
                currentTable.OrderingStatus = "NO";
            }

            btnModifierNo.BackColor = c9;
            btnModifierAdd.BackColor = c4;
            StartAddNOMode();
        }

    }

    private void StartAddNOMode()
    {

        int rowNum = OpenOrdersCurrencyMan.Position;
        var oRow = default(DataRow);
        int itemCatID;
        int itemID;
        int routeID;
        int valueSIN;
        int valueSII;

        try
        {
            valueSIN = (int)testgridview.gridViewOrder.Item(rowNum, 1);
            valueSII = (int)testgridview.gridViewOrder.Item(rowNum, 2);
        }
        catch (Exception ex)
        {
            return;
        }

        if (!(typeProgram == "Online_Demo"))
        {
            oRow = dsOrder.Tables("OpenOrders").Rows.Find(valueSII);
        }
        else
        {
            foreach (DataRow currentORow in dsOrder.Tables("OpenOrders").Rows)
            {
                oRow = currentORow;
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (oRow("sin") == valueSII)
                    {
                        break;
                    }
                }
            }
        }

        {
            var withBlock = dvIngredients;
            withBlock.Table = ds.Tables("Ingredients");
            withBlock.RowFilter = "FoodID = '" + oRow("FoodID") + "'";
        }
        {
            var withBlock1 = dvIngredientsEXTRA;
            withBlock1.Table = ds.Tables("Ingredients");
            withBlock1.RowFilter = "FoodID = '" + oRow("FoodID") + "' AND SelectExtra = True";
        }
        {
            var withBlock2 = dvIngredientsNO;
            withBlock2.Table = ds.Tables("Ingredients");
            withBlock2.RowFilter = "FoodID = '" + oRow("FoodID") + "' AND SelectNo = True";
        }

        currentTable.si2 = oRow("si2");
        // If btnModifierAdd.Text = "Prep" And oRow("FunctionFlag") = "D" Then
        if (currentTable.OrderingStatus == "Prep" & oRow("FunctionFlag") == "D")
        {
            // this is hit Add/No/Extra

            // they should both happen or neither
            itemCatID = oRow("DrinkCategoryID");
            itemID = oRow("DrinkID");
            routeID = oRow("RoutingID");
            currentTable.ReferenceSIN = valueSII;
            SelectDrinkAdds(itemID, itemCatID, routeID, oRow("FunctionID"), oRow("FunctionGroupID"));
        }
        else if (currentTable.OrderingStatus == "Call" & oRow("FunctionFlag") == "D")
        {
            // this hit call drink 
            // drinkcatid = oRow("DrinkCategoryID")
            drinkCall_Click();
        }
        else
        {
            itemCatID = oRow("CategoryID");
            itemID = oRow("FoodID");
            routeID = oRow("RoutingID");
            currentTable.ReferenceSIN = valueSII;
            PutUsInAddNOMode(itemID, itemCatID, routeID, oRow("FunctionID"), oRow("FunctionGroupID"));
        }

    }

    private void PutUsInAddNOMode(int itemID, int catID, int routeID, int funID, int funGroupID)
    {

        ADDorNOmode = true;
        // currentTable.OrderingStatus = "ADD"
        drinkPrep.StartAddNo(itemID, catID, routeID, funID, funGroupID);
        // 444   AssignReferenceSIN()
        // pnlMain.Visible = False
        // pnlMain2.Visible = False
        // pnlMain3.Visible = True
        pnlOrder.Visible = false;
        pnlOrderQuick.Visible = false;
        pnlOrderModifier.Visible = false;
        pnlOrderModifierExt.Visible = false;
        pnlOrderDrink.Visible = false;
        drinkPrep.Visible = true;
        // 444     extraNoUserControl.Visible = False

        currentTable.MiddleOfOrder = true;
        SetCategoryIndexToFalse();

    }

    private void PutUsInNormalMode()
    {
        ADDorNOmode = false;
        // pnlMain.Visible = True
        // pnlMain3.Visible = False
        btnModifierAdd.BackColor = c4;
        btnModifierNo.BackColor = c4;
        btnModifierExtra.BackColor = c4;
        previousCategory = default;
        extraNoUserControl.Visible = false;
        // Me.pnlOrder.Visible = False
        // pnlOrderQuick.Visible = False
        // Me.pnlOrderDrink.Visible = False
        // Me.pnlOrderModifier.Visible = False
        GTCIndex = -1;

        currentTable.OrderingStatus = (object)null;
    }

    private void ClearOrderPanels()
    {
        // also called from this class

        // Me.pnlOrder.Visible = False
        pnlOrderDrink.Visible = false;
        pnlOrderModifier.Visible = false;
        pnlOrderModifierExt.Visible = false;
        extraNoUserControl.Visible = false;

        if (OpenOrdersCurrencyMan.Position > -1)
        {
            if (testgridview.gridViewOrder.Item(OpenOrdersCurrencyMan.Position, 1) == testgridview.gridViewOrder.Item(OpenOrdersCurrencyMan.Position, 2))
            {
                // this is for main drink item
                // sin = sii
                drinkPrep.Visible = false;
            }
        }
        else
        {
            drinkPrep.Visible = false;
        }

    }

    private void SetCategoryIndexToFalse()
    {
        DataRowView vRow;
        int i = 0;
        categoryIndex = new bool[dvCategoryJoin.Count + 1];
        foreach (DataRowView currentVRow in dvCategoryJoin)
        {
            vRow = currentVRow;
            categoryIndex[i] = false;
            i += 1;
        }

        i = 0;
        categoryIndexSecondLoop = new bool[dvCategoryJoinSecondLoop.Count + 1];
        foreach (DataRowView currentVRow1 in dvCategoryJoinSecondLoop)
        {
            vRow = currentVRow1;
            categoryIndex[i] = false;
            i += 1;
        }

    }

    private void ClosingExtraNo()
    {

        PutUsInNormalMode();

    }


    private void BtnModifierSpecial_Click(object sender, EventArgs e)
    {
        // maybe add to time out interval (only temp)
        UserControlHit();
        // maybe don't make req modifier with special
        // this allows for flexibility
        // if we do, (True) make it so we don't reset currenttable.info
        // If EndOfItem(False) = False Then Exit Sub

        int rowNum = OpenOrdersCurrencyMan.Position;  // gridViewOrder.CurrentCell.RowNumber
        var isDrink = default(bool);
        var assocItem = default(bool);
        int currentRouting;

        int valueSIN;
        int valueSII;
        int valueSI2;
        var oRow = default(DataRow);
        bool hasRow = false;

        if (dsOrder.Tables("OpenOrders").Rows.Count > 0)
        {
            if (OpenOrdersCurrencyMan.Count == 0)
            {
                currentTable.SIN += 1;
                currentTable.ReferenceSIN += 1;
                valueSIN = currentTable.SIN;
                valueSII = currentTable.ReferenceSIN;
            }
            else
            {
                try
                {
                    valueSIN = (int)testgridview.gridViewOrder.Item(rowNum, 1);
                    valueSII = (int)testgridview.gridViewOrder.Item(rowNum, 2);
                    valueSI2 = (int)testgridview.gridViewOrder.Item(rowNum, 3);
                }
                catch (Exception ex)
                {
                    return;
                }
            }
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
                            hasRow = true;
                            break;
                        }
                    }
                }
            }

            if (hasRow == true)
            {
                currentRouting = oRow("RoutingID");
            }
            else
            {
                currentRouting = 0;
            }
        }

        else
        {
            valueSIN = currentTable.SIN;
            valueSII = currentTable.ReferenceSIN;
            currentRouting = 0;
        }


        if (currentTable.MiddleOfOrder == true)
        {
            assocItem = true;
            if (drinkPrep.Visible == true)  // pnlDrinkModifier.Visible = True Then
            {
                // ffff()
                isDrink = true;
            }
        }
        else if (IsBartenderMode == true)
        {
            isDrink = true;
        }

        SpecialItem = new SpecialFood(valueSIN, valueSII, isDrink, assocItem, currentRouting);
        SpecialItem.Location = new Point((this.Width - SpecialItem.Width) / 2, (this.Height - SpecialItem.Height) / 2);
        this.Controls.Add(SpecialItem);

        SpecialItem.BringToFront();
        DisableControls();
        // Me.Enabled = False

    }

    private void SpecialCancel_Click(object sender, EventArgs e)
    {

        UserControlHit();
        EnableControls();
        // Me.Enabled = True

    }

    private void DisableControls()
    {
        pnlDescription.Enabled = false;
        // Me.pnlDrinkModifier.Enabled = False
        pnlMain.Enabled = false;
        pnlMain2.Enabled = false;
        pnlMain3.Enabled = false;
        pnlMainModifier.Enabled = false;
        pnlOrder.Enabled = false;
        pnlOrderDrink.Enabled = false;
        pnlOrderModifier.Enabled = false;
        pnlTableInfo.Enabled = false;
        pnlWineParring.Enabled = false;
        testgridview.Enabled = false;
        if (!(currentTerminal.TermMethod == "Quick"))
        {
            customerPanel.Enabled = false;
        }

    }

    internal void EnableControls()
    {
        pnlDescription.Enabled = true;
        // Me.pnlDrinkModifier.Enabled = True
        pnlMain.Enabled = true;
        pnlMain2.Enabled = true;
        pnlMain3.Enabled = true;
        pnlMainModifier.Enabled = true;
        pnlOrder.Enabled = true;
        pnlOrderDrink.Enabled = true;
        pnlOrderModifier.Enabled = true;
        pnlTableInfo.Enabled = true;
        pnlWineParring.Enabled = true;
        testgridview.Enabled = true;
        if (!(currentTerminal.TermMethod == "Quick"))
        {
            customerPanel.Enabled = true;
        }

    }

    private void SpecialInstructionsEntered(object sender, EventArgs e)
    {
        UserControlHit();

        var specialInstructions = default(string);
        decimal specialPrice;
        int associateSIN;

        // If SpecialItem.SpecialKeyboard.EnteredString Is Nothing Or SpecialItem.SpecialKeyboard.EnteredString.Length = 0 Then
        // we do this on the keyboard

        if (SpecialItem.FunctionGroup == 4)
        {
            specialInstructions = "**  Open Liquor *** ";
        }
        else if (SpecialItem.FunctionGroup == 2)
        {
            specialInstructions = "**  Open Beer  *** ";
        }
        else if (SpecialItem.FunctionGroup == 3)
        {
            specialInstructions = "**  Open Wine  *** ";
        }
        else if (SpecialItem.FunctionGroup == 5)
        {
            specialInstructions = "**  Open Drink *** ";
        }
        else if (SpecialItem.FunctionGroup == 1 | SpecialItem.FunctionGroup == 10)
        {
            specialInstructions = "**  Open Food  *** ";
        }
        else if (SpecialItem.FunctionGroup == 8)
        {
            if (SpecialItem.SpecialKeyboard.EnteredString.Length == 0)
            {
                EnableControls();
                SpecialItem.Dispose();
                return;
            }
            else
            {
                specialInstructions = "**  Special  *** ";
            }
        }
        // End If

        if (SpecialItem.SpecialKeyboard.EnteredString.Length > 0)
        {
            specialInstructions = "**  " + SpecialItem.ItemDescription + "  **";
        }

        specialPrice = SpecialItem.NumberPadSmall1.NumberTotal;

        // If specialInstructions.Length > 34 Then
        // specialInstructions = specialInstructions.Substring(0, 20)
        // End If

        var currentItem = new SelectedItemDetail();

        // If currentTable.IsTabNotTable = False Then
        // .Table = currentTable.TableNumber
        // Else
        // .Table = currentTable.TabID
        // End If
        currentItem.Check = currentTable.CheckNumber;
        currentItem.Customer = currentTable.CustomerNumber;
        currentItem.Course = currentTable.CourseNumber;

        currentItem.SIN = currentTable.SIN;
        if (SpecialItem.AssociateSIN != default)
        {
            currentItem.SII = SpecialItem.AssociateSIN;
            currentItem.Name = "   " + specialInstructions;
            currentItem.TerminalName = "   " + specialInstructions;
            currentItem.ChitName = "   " + specialInstructions;
        }
        else
        {
            currentItem.SII = currentTable.SIN;
            currentItem.Name = specialInstructions;
            currentItem.TerminalName = specialInstructions;
            currentItem.ChitName = specialInstructions;
        }
        currentItem.si2 = currentTable.si2;
        currentItem.ID = -1;

        if (SpecialItem.AssociateSIN != default)
        {
            currentItem.Quantity = currentTable.Quantity;
            currentItem.InvMultiplier = currentTable.InvMultiplier;    // can make more variable sometime
            currentItem.ItemPrice = specialPrice;
            currentItem.Price = specialPrice * currentTable.Quantity;
        }
        else
        {
            currentItem.Quantity = 1;
            currentItem.InvMultiplier = 1;    // can make more variable sometime
            currentItem.ItemPrice = specialPrice;
            currentItem.Price = specialPrice;
        }
        currentItem.PrintPriorityID = 1;

        currentItem.FunctionGroup = SpecialItem.FunctionGroup;
        currentItem.FunctionFlag = SpecialItem.FunctionFlag;

        // .FunctionID = SpecialItem.FunctionID
        // .FunctionFlag = SpecialItem.FunctionFlag
        // .RoutingID = SpecialItem.RoutingID
        // .TaxID = GenerateOrderTables.DetermineTaxID(SpecialItem.FunctionID)       '    = SpecialItem.TaxID
        currentItem.Category = -1;  // SpecialItem.CategoryID

        GenerateOrderTables.DetermineFunctionAndTaxInfo(currentItem, SpecialItem.FunctionGroup, true);
        // If SpecialItem.associateItem = True Then
        currentItem.RoutingID = SpecialItem.RoutingID; // CurrentRouting
        // End If

        currentTable.SIN += 1;
        AddItemToOrderTable(ref currentItem);
        testgridview.CalculateSubTotal();

        EnableControls();
        SpecialItem.Dispose();

    }

    private void SpecialInstructionsEnteredOld222(object sender, EventArgs e) // Handles SpecialItem.AcceptSpecial
    {
        UserControlHit();

        // ********** can remove these two b/c we changed to a UC

        // Me.BringToFront()

        var specialInstructions = default(string);
        decimal specialPrice;
        int associateSIN;

        if (SpecialItem.SpecialKeyboard.EnteredString is null | SpecialItem.SpecialKeyboard.EnteredString.Length == 0)
        {
            // we do this on the keyboard
            if (SpecialItem.CategoryID == -1)
            {
                if (SpecialItem.FunctionFlag == "D")
                {
                    specialInstructions = "Open Drink *** ";
                }
                else if (SpecialItem.FunctionID == 1)
                {
                    specialInstructions = "Open Food *** ";
                }
                else
                {
                    specialInstructions = "   Open Food *** ";
                }
            }
            else
            {

            }
        }
        else if (SpecialItem.CategoryID == -1)
        {
            if (SpecialItem.FunctionFlag == "D")
            {
                specialInstructions = SpecialItem.ItemDescription; // SpecialItem.SpecialKeyboard.EnteredString
            }
            else if (SpecialItem.FunctionID == 1)
            {
                specialInstructions = SpecialItem.ItemDescription; // SpecialItem.SpecialKeyboard.EnteredString
            }
            else
            {
                specialInstructions = "   " + SpecialItem.ItemDescription;
            } // SpecialItem.SpecialKeyboard.EnteredString
        }
        else
        {
            specialInstructions = SpecialItem.ItemDescription;
            // specialInstructions = specialInstructions & SpecialItem.SpecialKeyboard.EnteredString
        } // "*** " & SpecialItem.SpecialKeyboard.EnteredString

        specialPrice = SpecialItem.NumberPadSmall1.NumberTotal;
        EnableControls();
        SpecialItem.Dispose();

        // If specialInstructions.Length > 34 Then
        // specialInstructions = specialInstructions.Substring(0, 20)
        // End If

        var currentItem = new SelectedItemDetail();

        // If currentTable.IsTabNotTable = False Then
        // .Table = currentTable.TableNumber
        // Else
        // .Table = currentTable.TabID
        // End If
        currentItem.Check = currentTable.CheckNumber;
        currentItem.Customer = currentTable.CustomerNumber;
        currentItem.Course = currentTable.CourseNumber;

        currentItem.SIN = currentTable.SIN;
        if (SpecialItem.AssociateSIN != default)
        {
            currentItem.SII = SpecialItem.AssociateSIN;
        }
        else
        {
            currentItem.SII = currentTable.SIN;
        }
        currentItem.si2 = currentTable.si2;
        currentItem.ID = -1;
        currentItem.Name = specialInstructions;
        currentItem.TerminalName = specialInstructions;
        currentItem.ChitName = specialInstructions;
        if (SpecialItem.AssociateSIN != default)
        {
            currentItem.Quantity = currentTable.Quantity;
            currentItem.Price = specialPrice * currentTable.Quantity;
        }
        else
        {
            currentItem.Quantity = 1;
            currentItem.Price = specialPrice;
        }

        currentItem.Category = SpecialItem.CategoryID;
        currentItem.FunctionID = SpecialItem.FunctionID;
        currentItem.FunctionGroup = SpecialItem.FunctionGroup;
        currentItem.FunctionFlag = SpecialItem.FunctionFlag;
        currentItem.RoutingID = SpecialItem.RoutingID;
        // .TaxID = GenerateOrderTables.DetermineTaxID(SpecialItem.FunctionID)       '    = SpecialItem.TaxID

        currentItem.PrintPriorityID = 1;

        // EndOfItem
        currentTable.ReferenceSIN = currentTable.SIN;
        currentTable.MiddleOfOrder = false;
        if (!(currentTable.Quantity == 1))
        {
            currentTable.Quantity = 1;
            testgridview.ChangeCourseButton(currentTable.Quantity);
        }
        currentTable.SIN += 1;

        AddItemToOrderTable(ref currentItem);
        testgridview.CalculateSubTotal();
        if (currentTable.MarkForNextCustomer == true)
        {
            currentTable.CustomerNumber = currentTable.NextCustomerNumber;
            ChangeCustomerButtonColor(c9);
            if (currentTable.MarkForNewCustomerPanel == true)
            {
                AddCustomerPanel();
            }
            currentTable.MarkForNewCustomerPanel = false;
            currentTable.MarkForNextCustomer = false;
        }

    }


    private void BtnModifierRepeat_Click(object sender, EventArgs e)
    {
        UserControlHit();
        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(EndOfItem(true), false, false)))
            return;

        long lastOrderNumber;

        lastOrderNumber = Conversions.ToLong(DetermineLastOrderNumber());

        if (lastOrderNumber == 0L)
        {
            info = new DataSet_Builder.Information_UC("There are no previous orders for this Table");
            info.Location = new Point((this.Width - info.Width) / 2, (this.Height - info.Height) / 2);
            this.Controls.Add(info);
            info.BringToFront();
            // MsgBox()
            return;
        }

        FillRepeatOrderDataTable(lastOrderNumber);

        DisplayRepeatOrder(true);

    }


    // *** this is for when we want to list all open orders
    private object CheckForOpenOrderDetail()
    {
        var lon = default(long);
        SqlClient.SqlDataReader dtr;
        int i;
        DataRow oRow;
        int rowCount;

        rowCount = dsOrder.Tables("OrderDetail").Rows.Count;

        // this will give LIFO
        // we will have to show all orders at sometime
        if (rowCount > 0)
        {
            var loopTo = rowCount - 1;
            for (i = 0; i <= loopTo; i++) // To 0 Step -1
            {
                oRow = dsOrder.Tables("OrderDetail").Rows(i);
                if (object.ReferenceEquals(oRow("OrderFilled"), DBNull.Value)) // And oRow("isMainCourse") = True Then
                {
                    if (currentServer.Bartender == true)
                    {
                        if (oRow("NumberOfDinners") + oRow("NumberOfApps") > 0)
                        {
                            lon = oRow("OrderNumber");
                            break;
                        }
                    }
                    else
                    {
                        lon = oRow("OrderNumber");
                        break;
                    }
                }
            }
        }
        else
        {
            lon = 0L;
        }

        return lon;

    }
    private object DetermineLastOrderNumber()
    {
        long lon;

        if (dsOrder.Tables("OrderDetail").Rows.Count > 0)
        {
            lon = dsOrder.Tables("OrderDetail").Rows(dsOrder.Tables("OrderDetail").Rows.Count - 1)("OrderNumber");
        }
        else
        {
            lon = 0L;
        }

        return lon;

        return default;

        // below is 222
        SqlClient.SqlDataReader dtr;

        if (mainServerConnected == true)
        {
            try
            {
                sql.cn.Open();
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                var cmd = new SqlClient.SqlCommand("SELECT MAX(OrderNumber) ordNum FROM ExperienceStatusChange WHERE ExperienceNumber ='" + currentTable.ExperienceNumber + "'", sql.cn);
                dtr = cmd.executereader;
                dtr.Read();

                // ***********************  change all datareaders to this
                if (dtr.IsDBNull(0) == false)     // dtr.HasRows Then
                {
                    lon = dtr("ordNum");
                }
                else
                {
                    // this means we did not have an order sent to the kitchen for this experience
                    lon = 0L;
                }
                dtr.Close();
                sql.cn.Close();
            }

            catch (Exception ex)
            {
                CloseConnection();
                ServerJustWentDown();
                // lon = DetermineLastOrderNumberWhenDown()

            }
        }
        else
        {
            // lon = DetermineLastOrderNumberWhenDown()

        }

        return lon;

    }

    private object DetermineLastOrderNumberWhenDown222()
    {
        var lonDOWN = default(int);

        DataRow[] copyRows;

        copyRows = dsBackup.Tables("ESCTerminal").Select("ExperienceNumber = '" + currentTable.ExperienceNumber + "'");

        // finds the max value
        if (copyRows is not null)
        {
            foreach (var bRow in copyRows)
            {
                if (bRow("OrderNumber") > lonDOWN)
                {
                    lonDOWN = bRow("OrderNumber");
                }
            }
        }

        return lonDOWN;

    }

    private void FillRepeatOrderDataTable(long LastOrderNumber)
    {

        // dvRepeat = New DataView
        DataRowView vRow;
        DataRow newRow;

        {
            var withBlock = dvRepeat;
            withBlock.Table = dsOrder.Tables("OpenOrders");
            withBlock.RowFilter = "ExperienceNumber = '" + currentTable.ExperienceNumber + "' AND OrderNumber = '" + LastOrderNumber + "'";
            withBlock.Sort = "sii, sin";
        }

    }

    private void DisplayRepeatOrder(bool forRepeat)
    {

        repeatOrderUserControl = new LastOrder_UC(forRepeat);
        repeatOrderUserControl.Location = new Point((this.Width - repeatOrderUserControl.Width) / 2, (this.Height - repeatOrderUserControl.Height) / 2);

        this.Controls.Add(repeatOrderUserControl);
        repeatOrderUserControl.BringToFront();

    }

    private void AcceptOrderDelivered()
    {

        DataRow oRow;
        bool allOrdersFilled = true;

        foreach (DataRow currentORow in dsOrder.Tables("OrderDetail").Rows)
        {
            oRow = currentORow;
            if (object.ReferenceEquals(oRow("OrderFilled"), DBNull.Value))
            {
                if (!(oRow("OrderNumber") == repeatOrderUserControl.OrderNumber))
                {
                    allOrdersFilled = false;
                }
                else
                {
                    oRow("OrderFilled") = DateTime.Now;
                }
            }
        }

        foreach (DataRow currentORow1 in dsOrder.Tables("OpenOrders").Rows)
        {
            oRow = currentORow1;
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (!object.ReferenceEquals(oRow("OrderNumber"), DBNull.Value))
                {
                    if (oRow("OrderNumber") == repeatOrderUserControl.OrderNumber)
                    {
                        oRow("ItemStatus") = 4;
                    }
                }
            }
        }

        if (allOrdersFilled == true)
        {
            GenerateOrderTables.ChangeStatusInDataBase(6, default, 0, default, default, default);
        }

    }

    private void AcceptRepeatOrder()
    {
        UserControlHit();

        foreach (SelectedItemDetail repeatedItem in repeatOrderUserControl.currentRepeatOrderCollection)
        {
            if (currentTable.IsTabNotTable == false)
            {
                repeatedItem.Table = currentTable.TableNumber;
            }
            else
            {
                repeatedItem.Tab = currentTable.TabID;
            }
            repeatedItem.SIN = currentTable.SIN;
            repeatedItem.si2 = currentTable.si2;

            if (repeatedItem.SII == -1)
            {
                // we coded it like this for a modifier
                repeatedItem.SII = currentTable.ReferenceSIN;
            }
            else
            {
                repeatedItem.SII = currentTable.SIN();
                currentTable.ReferenceSIN = currentTable.SIN;
                // EndOfItem()
                currentTable.MiddleOfOrder = false;
                if (!(currentTable.Quantity == 1))
                {
                    currentTable.Quantity = 1;
                    testgridview.ChangeCourseButton(currentTable.Quantity);
                }
            }

            currentTable.SIN += 1;

            AddItemToOrderTable(ref repeatedItem);
            testgridview.CalculateSubTotal();
            if (currentTable.MiddleOfOrder == false)
            {
                if (currentTable.MarkForNextCustomer == true)
                {
                    currentTable.CustomerNumber = currentTable.NextCustomerNumber;
                    ChangeCustomerButtonColor(c9);
                    if (currentTable.MarkForNewCustomerPanel == true)
                    {
                        AddCustomerPanel();
                    }
                    currentTable.MarkForNewCustomerPanel = false;
                    currentTable.MarkForNextCustomer = false;
                }
            }
        }

    }


    private void BtnModifierOnFly_Click(object sender, EventArgs e)
    {
        UserControlHit();

        int rowNum = OpenOrdersCurrencyMan.Position;  // gridViewOrder.CurrentCell.RowNumber
        var oRow = default(DataRow);
        int valueSIN;
        try
        {
            valueSIN = (int)testgridview.gridViewOrder.Item(rowNum, 1);
        }
        catch (Exception ex)
        {
            return;
        }

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

        if (oRow("ItemStatus") < 2)
        {
            oRow("TerminalName") = oRow("TerminalName") + "     ** ON FLY  **";
            oRow("ChitName") = oRow("ChitName") + "     ** ON FLY  **";
        }
        else
        {
            info = new DataSet_Builder.Information_UC("This Item Has already been sent to the Kitchen.");
            info.Location = new Point((this.Width - info.Width) / 2, (this.Height - info.Height) / 2);
            this.Controls.Add(info);
            info.BringToFront();
            // MsgBox()
        }

    }

    private void BtnModifierNoMake_Click(object sender, EventArgs e)
    {
        // change this to the same as On Fly     ?????
        UserControlHit();

        int rowNum = OpenOrdersCurrencyMan.Position;  // gridViewOrder.CurrentCell.RowNumber
        var oRow = default(DataRow);
        int valueSIN;
        try
        {
            valueSIN = (int)testgridview.gridViewOrder.Item(rowNum, 1);
        }
        catch (Exception ex)
        {
            return;
        }

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

        if (oRow("ItemStatus") > 1)
        {
            info = new DataSet_Builder.Information_UC("This Item Has already been sent to the Kitchen.");
            info.Location = new Point((this.Width - info.Width) / 2, (this.Height - info.Height) / 2);
            this.Controls.Add(info);
            info.BringToFront();
            // MsgBox
            return;
        }
        else
        {
            oRow("TerminalName") = oRow("TerminalName") + "     ** NO Make  **";
            oRow("ChitName") = oRow("ChitName") + "     ** NO Make  **";
        }

        return;

        // not using below
        var currentitem = new SelectedItemDetail();

        AssignReferenceSIN();

        currentitem.Name = "      ***   No Make      Above   ***";
        currentitem.TerminalName = "      ***   No Make      Above   ***";
        currentitem.ChitName = "      ***   No Make      Above   ***";
        currentitem.Price = 0;
        if (currentTable.IsTabNotTable == false)
        {
            currentitem.Table = currentTable.TableNumber;
        }
        else
        {
            currentitem.Tab = currentTable.TabID;
        }
        currentitem.Check = currentTable.CheckNumber;
        currentitem.Customer = currentTable.CustomerNumber;
        currentitem.SII = currentTable.ReferenceSIN;
        currentitem.SIN = currentTable.SIN;
        currentitem.si2 = currentTable.si2;
        // .FunctionID = 10
        currentitem.Category = -2;
        currentTable.SIN += 1;
        AddItemToOrderTable(ref currentitem);

    }

    private void BtnModifierOnSide_Click(object sender, EventArgs e)
    {
        UserControlHit();

        var currentitem = new SelectedItemDetail();
        int rowNum = OpenOrdersCurrencyMan.Position;  // gridViewOrder.CurrentCell.RowNumber
        var oRow = default(DataRow);
        int valueSIN;
        try
        {
            valueSIN = (int)testgridview.gridViewOrder.Item(rowNum, 1);
        }

        catch (Exception ex)
        {
            return;
        }

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

        if (oRow("ItemStatus") < 2)
        {
            oRow("TerminalName") = oRow("TerminalName") + "     ** On Side  **";
            oRow("ChitName") = oRow("ChitName") + "     ** On Side  **";
        }
        else
        {
            info = new DataSet_Builder.Information_UC("This Item Has already been sent to the Kitchen.");
            info.Location = new Point((this.Width - info.Width) / 2, (this.Height - info.Height) / 2);
            this.Controls.Add(info);
            info.BringToFront();
            // MsgBox()
        }

    }

    private void BtnModifierNoCharge_Click(object sender, EventArgs e)
    {
        UserControlHit();

        var currentitem = new SelectedItemDetail();
        int rowNum = OpenOrdersCurrencyMan.Position;  // gridViewOrder.CurrentCell.RowNumber
        var oRow = default(DataRow);
        int valueSIN;
        int valueSII;
        // Dim valueSI2
        try
        {
            valueSIN = (int)testgridview.gridViewOrder.Item(rowNum, 1);
            valueSII = (int)testgridview.gridViewOrder.Item(rowNum, 2);
        }
        // valueSI2 = CType(Me.testgridview.gridViewOrder.Item(rowNum, 3), Integer)
        catch (Exception ex)
        {
            return;
        }

        if (valueSIN == valueSII)
        {
            info = new DataSet_Builder.Information_UC("Can Not Force **No Charge** On This Item");
            info.Location = new Point((this.Width - info.Width) / 2, (this.Height - info.Height) / 2);
            this.Controls.Add(info);
            info.BringToFront();
        }
        // MsgBox()
        else
        {
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

            // For Each oRow In dsOrder.Tables("OpenOrders").Rows
            // If oRow("sin") = valueSIN Then
            // oRow("ItemName") = oRow("ItemName") & "     ** No Charge  **"
            oRow("TerminalName") = oRow("TerminalName") + "     ** No Charge  **";
            oRow("ForceFreeCode") = 0;   // oRow("Price")
            oRow("Price") = 0;
            testgridview.CalculateSubTotal();
            // End If
            // Next
        }
        // I should record all forced no charges

    }
    private void ClearingControls()
    {

        // Me.pnlOrderModifier.Visible = False
        PutUsInNormalMode();
        if (currentTable.MiddleOfOrder == true)
        {
            // Me.pnlOrderDrink.Visible = False
            // Me.pnlOrderModifier.Visible = False
            ClearOrderPanels();

        }
        // can add special food and modify order here

    }

    private void ResetPizzaControls()
    {

        currentTable.si2 = 0;
        currentTable.Tempsi2 = 0;
        currentTable.IsPizza = false;
        pnlPizzaSplit.Visible = false;
        pnlWineParring.Visible = true;

    }

    private void AssignReferenceSIN()
    {
        int rowNum = OpenOrdersCurrencyMan.Position;  // gridViewOrder.CurrentCell.RowNumber
        int valueSII;

        try
        {
            valueSII = (int)testgridview.gridViewOrder.Item(rowNum, 2);
            currentTable.CustomerNumber = testgridview.gridViewOrder.Item(rowNum, 4);
            currentTable.CourseNumber = testgridview.gridViewOrder.Item(rowNum, 5);
            currentTable.si2 = (int)testgridview.gridViewOrder.Item(rowNum, 3);
        }
        catch (Exception ex)
        {
            return;
        }

        currentTable.ReferenceSIN = valueSII;


    }


    private void drinkDouble_Click222(object sender, EventArgs e) // Handles drinkDouble.Click
    {
        UserControlHit();

        var currentitem = new SelectedItemDetail();

        currentitem.Name = "      ***   Double     Double  ***";
        currentitem.TerminalName = "      ***   Double     Double  ***";
        currentitem.ChitName = "      ***   Double     Double  ***";
        currentitem.Price = ds.Tables("DrinkModifiers").Rows(0)("DrinkPrice") * currentTable.Quantity;

        // .TaxID = ds.Tables("Drink").Rows(0)("TaxID")
        currentitem.ID = ds.Tables("DrinkModifiers").Rows(0)("DrinkID");

        AddDrinkModifier(currentitem);

    }

    private void drinkRocks_Click222(object sender, EventArgs e) // Handles drinkRocks.Click
    {
        UserControlHit();

        var currentitem = new SelectedItemDetail();

        currentitem.Name = "      ***   Rocks      Rocks   ***";
        currentitem.TerminalName = "      ***   Rocks      Rocks   ***";
        currentitem.ChitName = "      ***   Rocks      Rocks   ***";
        currentitem.Price = ds.Tables("DrinkModifiers").Rows(1)("DrinkPrice") * currentTable.Quantity;
        // .TaxID = ds.Tables("Drink").Rows(1)("TaxID")
        currentitem.ID = ds.Tables("DrinkModifiers").Rows(1)("DrinkID");

        AddDrinkModifier(currentitem);
    }

    private void drinkUp_Click222(object sender, EventArgs e) // Handles drinkUp.Click
    {
        UserControlHit();

        var currentitem = new SelectedItemDetail();

        currentitem.Name = "      ***   Up            Up        ***";
        currentitem.TerminalName = "      ***   Up            Up        ***";
        currentitem.ChitName = "      ***   Up            Up        ***";
        currentitem.Price = ds.Tables("DrinkModifiers").Rows(2)("DrinkPrice") * currentTable.Quantity;
        // .TaxID = ds.Tables("Drink").Rows(2)("TaxID")
        currentitem.ID = ds.Tables("DrinkModifiers").Rows(2)("DrinkID");

        AddDrinkModifier(currentitem);
    }

    private void drinkTall_Click222(object sender, EventArgs e) // Handles drinkTall.Click
    {
        UserControlHit();

        var currentitem = new SelectedItemDetail();

        currentitem.Name = "      ***   Tall           Tall       ***";
        currentitem.TerminalName = "      ***   Tall           Tall       ***";
        currentitem.ChitName = "      ***   Tall           Tall       ***";
        currentitem.Price = ds.Tables("DrinkModifiers").Rows(3)("DrinkPrice") * currentTable.Quantity;
        // .TaxID = ds.Tables("Drink").Rows(3)("TaxID")
        currentitem.ID = ds.Tables("DrinkModifiers").Rows(3)("DrinkID");

        AddDrinkModifier(currentitem);
    }

    private void drinkSplash_Click222(object sender, EventArgs e) // Handles drinkSplash.Click
    {
        UserControlHit();

        var currentitem = new SelectedItemDetail();

        currentitem.Name = "      ***   Splash      Splash   ***";
        currentitem.TerminalName = "      ***   Splash      Splash   ***";
        currentitem.ChitName = "      ***   Splash      Splash   ***";
        currentitem.Price = ds.Tables("DrinkModifiers").Rows(4)("DrinkPrice") * currentTable.Quantity;
        // .TaxID = ds.Tables("Drink").Rows(4)("TaxID")
        currentitem.ID = ds.Tables("DrinkModifiers").Rows(4)("DrinkID");

        AddDrinkModifier(currentitem);
    }

    private void drinkCall_Click()   // ByVal sender As Object, ByVal e As System.EventArgs) Handles drinkCall.Click
    {
        UserControlHit();

        int rowNum = OpenOrdersCurrencyMan.Position;
        var oRow = default(DataRow);
        var liquorTypeID = default(int);
        var funID = default(int);
        var funGroup = default(int);
        var funFlag = default(string);
        var preID = default(int);
        var isALiquorType = default(bool);
        var objButton = new OrderButton("10");

        int valueSIN;
        int valueSII;
        try
        {
            valueSIN = (int)testgridview.gridViewOrder.Item(rowNum, 1);
            valueSII = (int)testgridview.gridViewOrder.Item(rowNum, 2);
        }
        catch (Exception ex)
        {
            return;
        }

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


        if (oRow("DrinkID") > 0)
        {
            foreach (DataRow dRow in ds.Tables("Drink").Rows)
            {

                if (dRow("DrinkID") == oRow("DrinkID"))
                {
                    if (dRow("LiquorTypeID") > 0)
                    {
                        // liquor typeID is from drinkTable
                        liquorTypeID = dRow("LiquorTypeID");
                        // funGroup and Flag are from OpenOrders
                        funID = oRow("FunctionID");
                        funGroup = oRow("FunctionGroupID");
                        funFlag = oRow("FunctionFlag");
                        preID = oRow("DrinkCategoryID");
                        isALiquorType = true;
                    }
                    break;
                }
            }
        }

        if (isALiquorType == true)
        {
            currentTable.MiddleOfOrder = true;
            currentTable.ReferenceSIN = valueSII;
            currentTable.OrderingStatus = "Call";
            objButton.CategoryID = liquorTypeID;
            objButton.Functions = funID;
            objButton.FunctionGroup = funGroup;
            objButton.FunctionFlag = funFlag;
            // objButton.DrinkAdds = True
            previousCategory = preID;
            PopulateDrinkSubCategory(objButton);
            // MsgBox(liquorTypeID)
            // perform routing to select a brand from this liquor type
        }

    }

    private void AddDrinkModifier(SelectedItemDetail currentitem)
    {
        AssignReferenceSIN();

        // If currentTable.IsTabNotTable = False Then
        // .Table = currentTable.TableNumber
        // Else
        // .Table = currentTable.TabID
        // End If
        currentitem.Check = currentTable.CheckNumber;
        currentitem.FunctionID = 6;
        currentitem.FunctionGroup = 4;
        currentitem.FunctionFlag = "D";
        currentitem.Category = -1;
        currentitem.ID = -1;
        currentitem.Customer = currentTable.CustomerNumber;
        currentitem.SII = currentTable.ReferenceSIN;
        currentitem.SIN = currentTable.SIN;
        currentitem.si2 = currentTable.si2;
        currentTable.SIN += 1;
        AddItemToOrderTable(ref currentitem);
        testgridview.CalculateSubTotal();

    }

    private void WineParring_RecipeClicked(object sender, EventArgs e)
    {
        UserControlHit();

        lblRecipe.Visible = false;
        lblWineParring.Visible = true;

    }

    private void WineParring_WineClicked(object sender, EventArgs e)
    {
        UserControlHit();

        lblRecipe.Visible = true;
        lblWineParring.Visible = false;

    }

    private void FullPizza_Clicked(object sender, EventArgs e)
    {
        UserControlHit();
        int gridNumberCount;

        pnlOnFullPizza.BackColor = c18;
        pnlOnFirstHalf.BackColor = c3;
        pnlOnSecondHalf.BackColor = c3;
        currentTable.si2 = 1;
        onFullPizza.SelectedIndex = -1;

        gridNumberCount = Conversions.ToInteger(PizzaPanelTest("Main"));    // this is just to adjust gridvieworder
        if (gridNumberCount > 0)
        {
            testgridview.gridViewOrder.CurrentRowIndex = gridNumberCount;
        }

        // currentTable.ReferenceSIN = currentTable.TempReferenceSIN
        // currentTable.SecondRound = True
        // GTCIndex = -1

    }

    private void FirstHalfPizza_Clicked(object sender, EventArgs e)
    {
        UserControlHit();
        int gridNumberCount;

        pnlOnFullPizza.BackColor = c3;
        pnlOnFirstHalf.BackColor = c18;
        pnlOnSecondHalf.BackColor = c3;
        currentTable.si2 = 2;
        onFirstHalf.SelectedIndex = -1;

        gridNumberCount = Conversions.ToInteger(PizzaPanelTest("First"));
        if (gridNumberCount > 0)
        {
            testgridview.gridViewOrder.CurrentRowIndex = gridNumberCount;
        }

        // currentTable.SecondRound = True

    }


    private void SecondHalfPizza_Clicked(object sender, EventArgs e)
    {
        UserControlHit();
        int gridNumberCount;

        pnlOnFullPizza.BackColor = c3;
        pnlOnFirstHalf.BackColor = c3;
        pnlOnSecondHalf.BackColor = c18;
        currentTable.si2 = 3;
        onSecondHalf.SelectedIndex = -1;

        gridNumberCount = Conversions.ToInteger(PizzaPanelTest("Second"));
        if (gridNumberCount > 0)
        {
            testgridview.gridViewOrder.CurrentRowIndex = gridNumberCount;
        }

        // currentTable.SecondRound = True

    }


    internal object PizzaPanelTest(string whichPizzaPanel)
    {
        DataRow oRow;
        var vRow = default(DataRowView);
        var pizzaPanelShowing = default(bool);
        var gridNumberCount = default(int);

        if (whichPizzaPanel == "Main")
        {
            pizzaPanelShowing = true;    // there is no panel to add, just adjusting datavieworder
            foreach (DataRowView currentVRow in testgridview.gridViewOrder.DataSource)
            {
                vRow = currentVRow;
                gridNumberCount += 1;
                if (vRow("si2") == 1 & vRow("sii") == currentTable.TempReferenceSIN) // And vRow("ItemID") = 0 Then
                {
                    break;
                }
            }
        }
        else if (whichPizzaPanel == "First")
        {
            foreach (DataRowView currentVRow1 in testgridview.gridViewOrder.DataSource)
            {
                vRow = currentVRow1;
                gridNumberCount += 1;
                if (vRow("si2") == 2 & vRow("sii") == currentTable.TempReferenceSIN & vRow("ItemID") == 0)
                {
                    pizzaPanelShowing = true;
                    break;
                }
            }
        }

        // For Each oRow In dsOrder.Tables("OpenOrders").Rows
        // If Not oRow.RowState = DataRowState.Deleted And Not oRow.RowState = DataRowState.Detached Then
        // gridNumberCount += 1
        // If oRow("si2") = 2 And oRow("ItemID") = 0 Then
        // pizzaPanelShowing = True
        // Exit For
        // End If
        // End If
        // Next
        else if (whichPizzaPanel == "Second")
        {
            foreach (DataRowView currentVRow2 in testgridview.gridViewOrder.DataSource)
            {
                vRow = currentVRow2; // currentdataview 'dvOrder '
                gridNumberCount += 1;
                if (vRow("si2") == 3 & vRow("sii") == currentTable.TempReferenceSIN & vRow("ItemID") == 0)
                {
                    pizzaPanelShowing = true;
                    break;
                }
            }
            // For Each oRow In dsOrder.Tables("OpenOrders").Rows
            // If Not oRow.RowState = DataRowState.Deleted And Not oRow.RowState = DataRowState.Detached Then
            // gridNumberCount += 1
            // If oRow("si2") = 3 And oRow("ItemID") = 0 Then
            // pizzaPanelShowing = True
            // Exit For
            // End If
            // End If
            // Next
        }

        if (pizzaPanelShowing == false)
        {
            currentTable.TempReferenceSIN = vRow("sii"); // the first time won't matter
            // b/c we want to add a panel
            var currentItem = new SelectedItemDetail();
            string custNumString = "               " + whichPizzaPanel + " Half";

            currentItem.Check = currentTable.CheckNumber;
            currentItem.Customer = currentTable.CustomerNumber;
            currentItem.Course = currentTable.CourseNumber;
            currentItem.SIN = currentTable.SIN;
            currentItem.SII = currentTable.ReferenceSIN;
            currentItem.si2 = currentTable.si2;
            currentItem.ID = 0;
            currentItem.FunctionFlag = "N";
            currentItem.Name = custNumString;
            currentItem.TerminalName = custNumString;
            currentItem.ChitName = custNumString;
            currentItem.Price = (object)null;
            currentItem.Category = (object)null;

            currentTable.SIN += 1;            // ********???????????????????
            if (dvOrder.Count > 0)
            {
                PopulateDataRowForOpenOrder(currentItem);
            }
            else
            {
                // 444     DisposeDataViewsOrder()
                PopulateDataRowForOpenOrder(currentItem);
                // 444     CreateDataViewsOrder()
            }
            gridNumberCount = 0;

        }

        return gridNumberCount;

    }
    private void checkNumberButton_Click(object sender, EventArgs e) // checkNumberButton.Click
    {

        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(EndOfItem(false), false, false)))
            return;

        if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
        {
            orderInactiveTimer.Stop();
            orderInactiveTimer.Tick -= OrderInactiveScreenTimeout;
        }
        // If dsOrder.Tables("OpenOrders").Rows.Count > 0 Then
        // AdjustOpenOrderPosition()
        // GenerateOrderTables.SaveOpenOrderData()
        // End If
        // GenerateOrderTables.PopulatePaymentsAndCredits(currentTable.ExperienceNumber)
        // time1 = Now


        ClosingCheck?.Invoke();

        // LeaveAndSave()
        // ActiveSplit = New SplitChecks           'currentTable._checkCollection) '(cm, empID, tableNumber)

        // Me.Hide()
        // ActiveSplit.Show()
        // time2 = Now
        // timeDiff = time2.Subtract(time1)
        // MsgBox(timeDiff.ToString)
    }

    internal void SplitCheckClosed() // Handles ActiveSplit.SplitCheckClosing
    {


        // Me.Show()
        // do not want to reset timer, this way it times out fast ????? 
        // the only way it reach this point was inactivity in closing the check
        orderTimeoutCounter = 1;
        if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
        {
            orderInactiveTimer.Tick += OrderInactiveScreenTimeout;
            orderInactiveTimer.Start();
        }

        testgridview.gridByCheck = true;
        UpdateDataViewsByCheck();
        testgridview.UpdateCheckNumberButton();
        testgridview.CalculateSubTotal();

        // *************** not sure if right
        // do we need this or always do?????
        // If activeCheckChanged = True Then
        // UpdateCheckNumberButton()
        // UpdateDataViewsByCheck()
        // CalculateSubTotal()
        // '       activeCheckChanged = False
        // End If


    }



    // maybe, place new price on the original check
    // eliminate the original check for the collection
    // then place the split info on new checks w/ new sin's

    private void ApplingSplitCheckSecondStep222(object sender, EventArgs e) // Handles ActiveSplit.ApplySplitCheck
    {
        var eachCheck = default(SplittingCheck);
        var currentItem = new SelectedItemDetail();

        foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("sii") == ActiveSplit.splitItemSIN)
                {
                    if (oRow("sin") == ActiveSplit.splitItemSIN)
                    {
                        // this determines which check in the collection is the original
                        foreach (SplittingCheck currentEachCheck in ActiveSplit.CurrentSplittingChecks)
                        {
                            eachCheck = currentEachCheck;
                            if (oRow("CheckNumber") == eachCheck.CheckNumber)
                            {
                                oRow("Price") = eachCheck.CheckAmount;
                                oRow("TaxPrice") = DetermineTaxPrice(oRow("TaxID"), eachCheck.CheckAmount);
                                oRow("Quantity") = eachCheck.CheckQuantity;

                                // not sure about table
                                currentItem.ItemPrice = oRow("ItemPrice");
                                currentItem.ID = oRow("ItemID");
                                currentItem.Name = oRow("ItemName");
                                currentItem.TerminalName = oRow("TerminalName");
                                currentItem.ChitName = oRow("ChitName");
                                currentItem.TaxID = oRow("TaxID");
                                currentItem.OrderNumber = oRow("OrderNumber");

                                currentItem.Course = oRow("CourseNumber");
                                // .Quantity = currentTable.Quantity
                                currentItem.FunctionID = oRow("FunctionID");
                                currentItem.FunctionGroup = oRow("FunctionGroupID");
                                currentItem.ItemStatus = oRow("ItemStatus");
                                currentItem.RoutingID = oRow("RoutingID");

                                if (oRow("CategoryID") > 0)
                                {
                                    currentItem.Category = oRow("CategoryID");
                                    currentItem.FunctionFlag = oRow("FunctionFlag");
                                    currentItem.ID = oRow("FoodID");
                                }
                                else if (oRow("DrinkCategoryID") > 0)
                                {
                                    currentItem.Category = oRow("DrinkCategoryID");
                                    currentItem.FunctionFlag = "D";
                                    currentItem.ID = oRow("DrinkID");
                                }

                                break;    // this sould keep each check the same ??
                            }
                        }
                        ActiveSplit.CurrentSplittingChecks.Remove(eachCheck);
                    }
                    else    // this is for sub-items
                    {
                        oRow("Price") = 0;
                    }
                }
            }
        }


        foreach (SplittingCheck currentEachCheck1 in ActiveSplit.CurrentSplittingChecks)
        {
            eachCheck = currentEachCheck1;
            currentTable.SIN += 1;       // we need to add an extra (so we have room for cust number)
            currentItem.Check = eachCheck.CheckNumber;
            currentItem.Price = eachCheck.CheckAmount;
            currentItem.Quantity = eachCheck.CheckQuantity;
            currentItem.SIN = currentTable.SIN;
            currentItem.SII = currentTable.SIN;
            currentItem.si2 = currentTable.si2;
            currentItem.Table = currentTable.TableNumber;
            currentItem.Customer = 1;        // should ask for this if multi cust on second check

            AddItemToOrderTable(ref currentItem);
            currentTable.SIN += 1;
        }

        // AdjustOpenOrderPosition()
        // GenerateOrderTables.SaveOpenOrderData()

        // reflects the change
        ResetSplitGrids222();


    }

    private void ResetSplitGrids222()
    {

        ActiveSplit.sgp1.splitGrid.Items.Clear();
        ActiveSplit.sgp2.splitGrid.Items.Clear();
        ActiveSplit.sgp3.splitGrid.Items.Clear();
        ActiveSplit.sgp4.splitGrid.Items.Clear();
        ActiveSplit.sgp5.splitGrid.Items.Clear();
        ActiveSplit.sgp6.splitGrid.Items.Clear();
        ActiveSplit.sgp7.splitGrid.Items.Clear();
        ActiveSplit.sgp8.splitGrid.Items.Clear();
        ActiveSplit.sgp9.splitGrid.Items.Clear();
        ActiveSplit.sgp10.splitGrid.Items.Clear();

        ActiveSplit.sgp1.CreateSplitDataView(1);
        ActiveSplit.sgp2.CreateSplitDataView(2);
        ActiveSplit.sgp3.CreateSplitDataView(3);
        ActiveSplit.sgp4.CreateSplitDataView(4);
        ActiveSplit.sgp5.CreateSplitDataView(5);
        ActiveSplit.sgp6.CreateSplitDataView(6);
        ActiveSplit.sgp7.CreateSplitDataView(7);
        ActiveSplit.sgp8.CreateSplitDataView(8);
        ActiveSplit.sgp9.CreateSplitDataView(9);
        ActiveSplit.sgp10.CreateSplitDataView(10);


    }

    private void AdjustOpenOrderPosition()
    {
        if (OpenOrdersCurrencyMan.Position == 0)
        {
            OpenOrdersCurrencyMan.Position += 1;
            OpenOrdersCurrencyMan.Position -= 1;
        }
        else
        {
            OpenOrdersCurrencyMan.Position -= 1;
            OpenOrdersCurrencyMan.Position += 1;
        }

    }

    private void DisplayingMessage(object msg)
    {

        info = new DataSet_Builder.Information_UC(msg.ToString());
        info.Location = new Point((this.Width - info.Width) / 2, (this.Height - info.Height) / 2);

        this.Controls.Add(info);
        info.BringToFront();

    }




}