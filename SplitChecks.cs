using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using DataSet_Builder;


public partial class SplitChecks : System.Windows.Forms.UserControl
{

    // Dim sql As New DataSet_Builder.SQLHelper(connectserver)

    // Dim splitPanel2 As Panel
    private bool IsFromManager;
    private Button _transferCheckButton;

    private Button transferCheckButton
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _transferCheckButton;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_transferCheckButton != null)
            {
                _transferCheckButton.Click -= StartCheckTransfer;
            }

            _transferCheckButton = value;
            if (_transferCheckButton != null)
            {
                _transferCheckButton.Click += StartCheckTransfer;
            }
        }
    }
    private Button _splitItemButton;

    private Button splitItemButton
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _splitItemButton;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_splitItemButton != null)
            {
                _splitItemButton.Click -= StartSplitItem;
            }

            _splitItemButton = value;
            if (_splitItemButton != null)
            {
                _splitItemButton.Click += StartSplitItem;
            }
        }
    }
    private Button _closeExperienceButton;

    private Button closeExperienceButton  // one check button
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _closeExperienceButton;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_closeExperienceButton != null)
            {
                _closeExperienceButton.Click -= ReleaseTable;
            }

            _closeExperienceButton = value;
            if (_closeExperienceButton != null)
            {
                _closeExperienceButton.Click += ReleaseTable;
            }
        }
    }
    private Button _changeNumberOfGridsButton;

    private Button changeNumberOfGridsButton
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _changeNumberOfGridsButton;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_changeNumberOfGridsButton != null)
            {
                _changeNumberOfGridsButton.Click -= changeNumberOfGrids;
            }

            _changeNumberOfGridsButton = value;
            if (_changeNumberOfGridsButton != null)
            {
                _changeNumberOfGridsButton.Click += changeNumberOfGrids;
            }
        }
    }
    internal int splitItemSIN;
    internal string splitItemName;
    private Panel actionPanel;
    private Label actionPanelLabel;
    internal int splitItemQuantity;
    internal decimal splitItemInvMultiplier;
    private int numberGridsInView;

    private SplitItemUserControl _splitItemPanel;

    private SplitItemUserControl splitItemPanel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _splitItemPanel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_splitItemPanel != null)
            {
                _splitItemPanel.ApplySplitCheck -= ApplingSplitCheckFirstStep;
            }

            _splitItemPanel = value;
            if (_splitItemPanel != null)
            {
                _splitItemPanel.ApplySplitCheck += ApplingSplitCheckFirstStep;
            }
        }
    }
    internal SplittingCheckCollection CurrentSplittingChecks;
    private Manager_Transfer_UC _transCheck;

    private Manager_Transfer_UC transCheck
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _transCheck;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_transCheck != null)
            {
                _transCheck.UpdatingCurrentTables -= TransUC_Closed;
            }

            _transCheck = value;
            if (_transCheck != null)
            {
                _transCheck.UpdatingCurrentTables += TransUC_Closed;
            }
        }
    }
    private CloseCheck __closeCheck;

    internal virtual CloseCheck _closeCheck
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return __closeCheck;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (__closeCheck != null)
            {
                __closeCheck.CloseGotoSplitting -= StartTimer;
                __closeCheck.MakeGiftAddingAmountTrue -= MakingGiftAddingAmountTrue;
                __closeCheck.CloseExiting -= Manager_ClosingClose;
                __closeCheck.SplitSingleCheck -= PerformChangeOfGrids;
                __closeCheck.CloseExitAndRelease -= GoToTestRemainingBalance;
                __closeCheck.SelectedReOrder -= CloseCheckSelectedReOrder;
                __closeCheck.FireTabScreen -= FiringTabScreen;
                __closeCheck.MerchantAuthPayment -= MerchantAuthirizingPaymentStep1;
            }

            __closeCheck = value;
            if (__closeCheck != null)
            {
                __closeCheck.CloseGotoSplitting += StartTimer;
                __closeCheck.MakeGiftAddingAmountTrue += MakingGiftAddingAmountTrue;
                __closeCheck.CloseExiting += Manager_ClosingClose;
                __closeCheck.SplitSingleCheck += PerformChangeOfGrids;
                __closeCheck.CloseExitAndRelease += GoToTestRemainingBalance;
                __closeCheck.SelectedReOrder += CloseCheckSelectedReOrder;
                __closeCheck.FireTabScreen += FiringTabScreen;
                __closeCheck.MerchantAuthPayment += MerchantAuthirizingPaymentStep1;
            }
        }
    }
    // Dim WithEvents closeCreditCardAuth As CloseManualAuth
    private bool goingToSelectedCheck;
    private bool RemainingBalancesZero;

    // Dim actionPanelSplit As Panel
    // Dim actionPanelSplitLabel As Label
    // Dim actionPanelRemainingLabel As Label
    // Dim actionPanelRemaining As TextBox
    private ListView _transferListView;

    private ListView transferListView
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _transferListView;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _transferListView = value;
        }
    }
    private ColumnHeader nameColumn = new ColumnHeader();
    // Dim WithEvents splitListView As ListView
    // Dim checkNameColumn As New ColumnHeader
    // Dim checkAmountColumn As New ColumnHeader

    // testing
    // Dim grdSplitItem As DataGrid


    // Dim CurrentSplittingChecks As new SplittingCheckCollection
    private SplittingCheck[] checksSplitting = new SplittingCheck[2];

    // Private splitInactiveTimer As Timer
    private int splitTimeoutCounter;

    private SplitGridPanel _sgp1;

    internal virtual SplitGridPanel sgp1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sgp1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sgp1 != null)
            {
                _sgp1.ResetTimerFromPanel -= ItemMoving;
                _sgp1.ItemSelected -= ItemSelectedChanged;
                _sgp1.ButtonCloseClick -= OpenCloseCheck;
                _sgp1.ButtonSelectClick -= CheckSelected;
            }

            _sgp1 = value;
            if (_sgp1 != null)
            {
                _sgp1.ResetTimerFromPanel += ItemMoving;
                _sgp1.ItemSelected += ItemSelectedChanged;
                _sgp1.ButtonCloseClick += OpenCloseCheck;
                _sgp1.ButtonSelectClick += CheckSelected;
            }
        }
    }
    private SplitGridPanel _sgp2;

    internal virtual SplitGridPanel sgp2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sgp2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sgp2 != null)
            {
                _sgp2.ResetTimerFromPanel -= ItemMoving;
                _sgp2.ItemSelected -= ItemSelectedChanged;
                _sgp2.ButtonCloseClick -= OpenCloseCheck;
                _sgp2.ButtonSelectClick -= CheckSelected;
            }

            _sgp2 = value;
            if (_sgp2 != null)
            {
                _sgp2.ResetTimerFromPanel += ItemMoving;
                _sgp2.ItemSelected += ItemSelectedChanged;
                _sgp2.ButtonCloseClick += OpenCloseCheck;
                _sgp2.ButtonSelectClick += CheckSelected;
            }
        }
    }
    private SplitGridPanel _sgp3;

    internal virtual SplitGridPanel sgp3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sgp3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sgp3 != null)
            {
                _sgp3.ResetTimerFromPanel -= ItemMoving;
                _sgp3.ItemSelected -= ItemSelectedChanged;
                _sgp3.ButtonCloseClick -= OpenCloseCheck;
                _sgp3.ButtonSelectClick -= CheckSelected;
            }

            _sgp3 = value;
            if (_sgp3 != null)
            {
                _sgp3.ResetTimerFromPanel += ItemMoving;
                _sgp3.ItemSelected += ItemSelectedChanged;
                _sgp3.ButtonCloseClick += OpenCloseCheck;
                _sgp3.ButtonSelectClick += CheckSelected;
            }
        }
    }
    private SplitGridPanel _sgp4;

    internal virtual SplitGridPanel sgp4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sgp4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sgp4 != null)
            {
                _sgp4.ResetTimerFromPanel -= ItemMoving;
                _sgp4.ItemSelected -= ItemSelectedChanged;
                _sgp4.ButtonCloseClick -= OpenCloseCheck;
                _sgp4.ButtonSelectClick -= CheckSelected;
            }

            _sgp4 = value;
            if (_sgp4 != null)
            {
                _sgp4.ResetTimerFromPanel += ItemMoving;
                _sgp4.ItemSelected += ItemSelectedChanged;
                _sgp4.ButtonCloseClick += OpenCloseCheck;
                _sgp4.ButtonSelectClick += CheckSelected;
            }
        }
    }
    private SplitGridPanel _sgp5;

    internal virtual SplitGridPanel sgp5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sgp5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sgp5 != null)
            {
                _sgp5.ResetTimerFromPanel -= ItemMoving;
                _sgp5.ItemSelected -= ItemSelectedChanged;
                _sgp5.ButtonCloseClick -= OpenCloseCheck;
                _sgp5.ButtonSelectClick -= CheckSelected;
            }

            _sgp5 = value;
            if (_sgp5 != null)
            {
                _sgp5.ResetTimerFromPanel += ItemMoving;
                _sgp5.ItemSelected += ItemSelectedChanged;
                _sgp5.ButtonCloseClick += OpenCloseCheck;
                _sgp5.ButtonSelectClick += CheckSelected;
            }
        }
    }
    private SplitGridPanel _sgp6;

    internal virtual SplitGridPanel sgp6
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sgp6;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sgp6 != null)
            {
                _sgp6.ResetTimerFromPanel -= ItemMoving;
                _sgp6.ItemSelected -= ItemSelectedChanged;
                _sgp6.ButtonCloseClick -= OpenCloseCheck;
                _sgp6.ButtonSelectClick -= CheckSelected;
            }

            _sgp6 = value;
            if (_sgp6 != null)
            {
                _sgp6.ResetTimerFromPanel += ItemMoving;
                _sgp6.ItemSelected += ItemSelectedChanged;
                _sgp6.ButtonCloseClick += OpenCloseCheck;
                _sgp6.ButtonSelectClick += CheckSelected;
            }
        }
    }
    private SplitGridPanel _sgp7;

    internal virtual SplitGridPanel sgp7
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sgp7;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sgp7 != null)
            {
                _sgp7.ResetTimerFromPanel -= ItemMoving;
                _sgp7.ItemSelected -= ItemSelectedChanged;
                _sgp7.ButtonCloseClick -= OpenCloseCheck;
                _sgp7.ButtonSelectClick -= CheckSelected;
            }

            _sgp7 = value;
            if (_sgp7 != null)
            {
                _sgp7.ResetTimerFromPanel += ItemMoving;
                _sgp7.ItemSelected += ItemSelectedChanged;
                _sgp7.ButtonCloseClick += OpenCloseCheck;
                _sgp7.ButtonSelectClick += CheckSelected;
            }
        }
    }
    private SplitGridPanel _sgp8;

    internal virtual SplitGridPanel sgp8
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sgp8;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sgp8 != null)
            {
                _sgp8.ResetTimerFromPanel -= ItemMoving;
                _sgp8.ItemSelected -= ItemSelectedChanged;
                _sgp8.ButtonCloseClick -= OpenCloseCheck;
                _sgp8.ButtonSelectClick -= CheckSelected;
            }

            _sgp8 = value;
            if (_sgp8 != null)
            {
                _sgp8.ResetTimerFromPanel += ItemMoving;
                _sgp8.ItemSelected += ItemSelectedChanged;
                _sgp8.ButtonCloseClick += OpenCloseCheck;
                _sgp8.ButtonSelectClick += CheckSelected;
            }
        }
    }
    private SplitGridPanel _sgp9;

    internal virtual SplitGridPanel sgp9
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sgp9;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sgp9 != null)
            {
                _sgp9.ResetTimerFromPanel -= ItemMoving;
                _sgp9.ItemSelected -= ItemSelectedChanged;
                _sgp9.ButtonCloseClick -= OpenCloseCheck;
                _sgp9.ButtonSelectClick -= CheckSelected;
            }

            _sgp9 = value;
            if (_sgp9 != null)
            {
                _sgp9.ResetTimerFromPanel += ItemMoving;
                _sgp9.ItemSelected += ItemSelectedChanged;
                _sgp9.ButtonCloseClick += OpenCloseCheck;
                _sgp9.ButtonSelectClick += CheckSelected;
            }
        }
    }
    private SplitGridPanel _sgp10;

    internal virtual SplitGridPanel sgp10
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _sgp10;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_sgp10 != null)
            {
                _sgp10.ResetTimerFromPanel -= ItemMoving;
                _sgp10.ItemSelected -= ItemSelectedChanged;
                _sgp10.ButtonCloseClick -= OpenCloseCheck;
                _sgp10.ButtonSelectClick -= CheckSelected;
            }

            _sgp10 = value;
            if (_sgp10 != null)
            {
                _sgp10.ResetTimerFromPanel += ItemMoving;
                _sgp10.ItemSelected += ItemSelectedChanged;
                _sgp10.ButtonCloseClick += OpenCloseCheck;
                _sgp10.ButtonSelectClick += CheckSelected;
            }
        }
    }

    // flag of active checks
    // 444    Dim checkActive(10) As Boolean
    // Dim check2 As Boolean
    // Dim check3 As Boolean
    // Dim check4 As Boolean
    // Dim check5 As Boolean
    // Dim check6 As Boolean
    // Dim check7 As Boolean
    // Dim check8 As Boolean
    // Dim check9 As Boolean
    // Dim check10 As Boolean

    public event SplitCheckClosingEventHandler SplitCheckClosing;

    public delegate void SplitCheckClosingEventHandler();
    // Event ApplySplitCheck(ByVal sender As Object, ByVal e As System.EventArgs)
    public event ManagerClosingEventHandler ManagerClosing;

    public delegate void ManagerClosingEventHandler(bool fromManager, Employee emp, bool goingToSelectedCheck);
    public event SelectedReOrderEventHandler SelectedReOrder;

    public delegate void SelectedReOrderEventHandler(DataTable dt, bool tabTestNeeded);
    public event SendOrderEventHandler SendOrder;

    public delegate void SendOrderEventHandler(bool alsoClose);
    public event FireTabScreenEventHandler FireTabScreen;

    public delegate void FireTabScreenEventHandler(string startInSearch, string searchCriteria);
    public event MakeGiftAddingAmountTrueEventHandler MakeGiftAddingAmountTrue;

    public delegate void MakeGiftAddingAmountTrueEventHandler();
    public event MerchantAuthPaymentEventHandler MerchantAuthPayment;

    public delegate void MerchantAuthPaymentEventHandler(int paymentID, bool justActive);


    #region  Windows Form Designer generated code 

    public SplitChecks() : base() // ByVal _isFromManager As Boolean, ByVal _goingToSelectedCheck As Boolean)
    {

        // IsFromManager = _isFromManager
        // goingToSelectedCheck = _goingToSelectedCheck

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call

        InitializeOther();       // _checks)

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
    private Global.System.Windows.Forms.Panel _splitPanel;

    internal virtual Global.System.Windows.Forms.Panel splitPanel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _splitPanel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _splitPanel = value;
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _splitPanel = new System.Windows.Forms.Panel();
        this.SuspendLayout();
        // 
        // splitPanel
        // 
        _splitPanel.Location = new System.Drawing.Point(0, 0);
        _splitPanel.Name = "_splitPanel";
        _splitPanel.Size = new System.Drawing.Size(1024, 768);
        _splitPanel.TabIndex = 0;
        // 
        // SplitChecks
        // 
        this.BackColor = System.Drawing.Color.LightSlateGray;
        this.Controls.Add(_splitPanel);
        this.Name = "SplitChecks";
        this.Size = new System.Drawing.Size(1024, 768);
        this.ResumeLayout(false);

    }

    #endregion

    private void InitializeOther()       // ByRef _checkCollection As CheckCollection)
    {

        splitTimeoutCounter = 1;
        // splitInactiveTimer = New Timer
        splitInactiveTimer.Tick += MeTimeOutTick; // InactiveScreenTimeout
        splitInactiveTimer.Interval = timeoutInterval;
        splitInactiveTimer.Start();

        int index;
        // Me.ClientSize = New Size(ssX, ssY)

        // splitPanel2 = New Panel
        // splitPanel2.Size = Me.ClientSize
        // Me.Controls.Add(splitPanel2)

        transferCheckButton = new Button();
        transferCheckButton.Size = new Size(ssX * 0.16d, ssY * 0.07d);
        transferCheckButton.Location = new Point(ssX * 0.22d, ssY * 0.93d);
        transferCheckButton.BackColor = c3;
        transferCheckButton.TextAlign = ContentAlignment.MiddleCenter;
        transferCheckButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        transferCheckButton.Text = "Transfer Check:  " + currentTable.CheckNumber;
        splitPanel.Controls.Add(transferCheckButton);


        splitItemButton = new Button();
        splitItemButton.Size = new Size(ssX * 0.16d, ssY * 0.07d);
        splitItemButton.Location = new Point(ssX * 0.42d, ssY * 0.93d);
        splitItemButton.BackColor = c3;
        splitItemButton.TextAlign = ContentAlignment.MiddleCenter;
        splitItemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        splitItemButton.Text = "Split:  ";
        splitPanel.Controls.Add(splitItemButton);

        closeExperienceButton = new Button();
        closeExperienceButton.Size = new Size(ssX * 0.16d, ssY * 0.07d);
        closeExperienceButton.Location = new Point(ssX * 0.62d, ssY * 0.93d);
        closeExperienceButton.BackColor = c3;
        closeExperienceButton.TextAlign = ContentAlignment.MiddleCenter;
        closeExperienceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        closeExperienceButton.Text = "One Check";
        splitPanel.Controls.Add(closeExperienceButton);

        changeNumberOfGridsButton = new Button();
        changeNumberOfGridsButton.Size = new Size(ssX * 0.09d, ssY * 0.07d);
        changeNumberOfGridsButton.Location = new Point(ssX * 0.87d, ssY * 0.93d);
        changeNumberOfGridsButton.BackColor = c3;
        changeNumberOfGridsButton.TextAlign = ContentAlignment.MiddleCenter;
        changeNumberOfGridsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        changeNumberOfGridsButton.Text = "Display";
        splitPanel.Controls.Add(changeNumberOfGridsButton);

        actionPanel = new Panel();
        actionPanel.Size = new Size(300, 300);
        actionPanel.Location = new Point((this.Width - actionPanel.Width) / 2, (this.Height - actionPanel.Height) / 2);
        actionPanel.BackColor = c3;
        actionPanel.BorderStyle = BorderStyle.Fixed3D;

        actionPanelLabel = new Label();
        actionPanelLabel.Text = "Transfer Check to:";
        actionPanelLabel.BackColor = c6;
        actionPanelLabel.ForeColor = c3;
        actionPanelLabel.TextAlign = ContentAlignment.MiddleCenter;
        actionPanelLabel.Font = new System.Drawing.Font("Bookman Old Style", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        actionPanelLabel.Dock = DockStyle.Top;
        actionPanel.Controls.Add(actionPanelLabel);

        transferListView = new ListView();
        transferListView.Size = new Size(actionPanel.Width, actionPanel.Height - actionPanelLabel.Height);
        transferListView.Location = new Point(0, actionPanelLabel.Height);
        transferListView.BackColor = c3;
        transferListView.Font = new System.Drawing.Font("Bookman Old Style", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        transferListView.Columns.Add(nameColumn);
        transferListView.HeaderStyle = ColumnHeaderStyle.None;
        transferListView.View = View.Details;
        nameColumn.Width = transferListView.Width - 30;

        actionPanel.Controls.Add(transferListView);
        actionPanel.Visible = false;
        splitPanel.Controls.Add(actionPanel);

        if (currentTable.NumberOfChecks > 4)
        {
            numberGridsInView = 10;
        }
        else
        {
            numberGridsInView = 4;
        }

        InitializeSplitGridPanels();

        // 444  DisplayCloseCheck()     'we are going straight to close check
        base.Focus();

    }

    private void InitializeSplitGridPanels()
    {

        sgp1 = new SplitGridPanel(1, numberGridsInView);
        splitPanel.Controls.Add(sgp1);
        sgp2 = new SplitGridPanel(2, numberGridsInView);
        splitPanel.Controls.Add(sgp2);
        sgp3 = new SplitGridPanel(3, numberGridsInView);
        splitPanel.Controls.Add(sgp3);
        sgp4 = new SplitGridPanel(4, numberGridsInView);
        splitPanel.Controls.Add(sgp4);

        sgp5 = new SplitGridPanel(5, numberGridsInView);
        sgp6 = new SplitGridPanel(6, numberGridsInView);
        sgp7 = new SplitGridPanel(7, numberGridsInView);
        sgp8 = new SplitGridPanel(8, numberGridsInView);
        sgp9 = new SplitGridPanel(9, numberGridsInView);
        sgp10 = new SplitGridPanel(10, numberGridsInView);

        if (numberGridsInView == 4)
            return;

        splitPanel.Controls.Add(sgp5);
        splitPanel.Controls.Add(sgp6);
        splitPanel.Controls.Add(sgp7);
        splitPanel.Controls.Add(sgp8);
        splitPanel.Controls.Add(sgp9);
        splitPanel.Controls.Add(sgp10);

    }


    // combine
    private void StartTimer(object sender, EventArgs e)
    {
        // this is what we do when we close checkClose screen

        if (currentTable.NumberOfChecks == 1)
        {
        }
        // InitializeSplitGridPanels()

        _closeCheck.Visible = false;
        // Me.splitPanel.Enabled = True

        // If _closeCheck.singleSplit = True Then
        // PerformChangeOfGrids()
        // _closeCheck.singleSplit = False
        // End If


        splitPanel.BringToFront();

        ResetTimer();

        // currently timer is never stopping
        // AddHandler splitInactiveTimer.Tick, AddressOf MeTimeOutTick
        // splitInactiveTimer.Start()

        RecaculatePriceAndTaxRemaining();
        // ????????????????

    }

    private void ResetTimer()
    {

        splitTimeoutCounter = 1;

    }

    private void RePopulateSplitGrids()
    {

        sgp1.CreateSplitDataView(1);
        sgp2.CreateSplitDataView(2);
        sgp3.CreateSplitDataView(3);
        sgp4.CreateSplitDataView(4);

        // If numberGridsInView = 4 Then Exit Sub
        sgp5.CreateSplitDataView(5);
        sgp6.CreateSplitDataView(6);
        sgp7.CreateSplitDataView(7);
        sgp8.CreateSplitDataView(8);
        sgp9.CreateSplitDataView(9);
        sgp10.CreateSplitDataView(10);
    }

    private void RecaculatePriceAndTaxRemaining()
    {

        sgp1.CalculatePriceTaxAndRemaining();
        sgp2.CalculatePriceTaxAndRemaining();
        sgp3.CalculatePriceTaxAndRemaining();
        sgp4.CalculatePriceTaxAndRemaining();

        if (numberGridsInView == 4)
            return;
        sgp5.CalculatePriceTaxAndRemaining();
        sgp6.CalculatePriceTaxAndRemaining();
        sgp7.CalculatePriceTaxAndRemaining();
        sgp8.CalculatePriceTaxAndRemaining();
        sgp9.CalculatePriceTaxAndRemaining();
        sgp10.CalculatePriceTaxAndRemaining();

    }
    private void ItemMoving()
    {
        ResetTimer();

    }
    private void ItemSelectedChanged(object sender, EventArgs e)
    {
        ResetTimer();

        SplitGridPanel objSent;
        objSent = sender;

        currentTable.CheckNumber = objSent.CheckIndex;
        splitItemName = objSent.SelectedItemName;
        splitItemSIN = objSent.SIN_Split;

        transferCheckButton.Text = "Transfer Check:  " + objSent.CheckIndex;

        {
            var withBlock = dvCloseCheck;
            withBlock.Table = dsOrder.Tables("PaymentsAndCredits");
            withBlock.RowFilter = "CheckNumber = " + objSent.CheckIndex;
        }

        splitItemButton.Text = "Split:  " + objSent.SelectedItemName;
        // sin dragsouce will give the "sin" so we can split check

    }

    private void StartCheckTransfer(object sender, EventArgs e)
    {
        ResetTimer();

        var restrictToItemOnly = default(bool);
        DataRow oRow;

        actingManager = currentServer;
        GenerateOrderTables.AssignManagementAuthorization(actingManager);

        if (employeeAuthorization.OperationLevel < systemAuthorization.TransferCheck)
        {
            Interaction.MsgBox(employeeAuthorization.FullName + " does not have Authorization");
            return;
            // restrictToItemOnly = True
        }


        if (dvCloseCheck.Count == 0)
        {
            transCheck = new Manager_Transfer_UC(splitItemSIN, splitItemName, currentTable.CheckNumber, currentTable.ExperienceNumber, false, restrictToItemOnly);
            transCheck.Location = new Point((this.Width - transCheck.Width) / 2, (this.Height - transCheck.Height) / 2);

            this.Controls.Add(transCheck);
            transCheck.BringToFront();
        }
        else
        {
            Interaction.MsgBox("You may NOT transfer a check if a Payment has been applied.");
        }

    }

    private void TransUC_Closed(bool releasingTable)
    {
        goingToSelectedCheck = false;

        if (releasingTable == true)
        {
            CalculateClosingTotal();
            _closeCheck.releaseFlag = true;
        }
        SplitDisposeSelf();
        // RaiseEvent UpdatingAfterTransfer()

    }

    private void OpenCloseCheck(object sender, EventArgs e)
    {

        ResetTimer();
        // splitInactiveTimer.Stop()
        // RemoveHandler splitInactiveTimer.Tick, AddressOf MeTimeOutTick

        PropertyAttributes objGrid; // SplitGridPanel
        objGrid = (PropertyAttributes)Conversions.ToInteger(sender);

        currentTable.CheckNumber = (int)objGrid;
        // MsgBox(currentTable.CheckNumber.GetType.ToString, , "here")
        // currentTable.CheckNumber = 1

        _closeCheck.Visible = true;
        _closeCheck.ReinitializeCloseCheck(true);
        _closeCheck.BringToFront();

        // DisplayCloseCheck()

    }

    internal void DisplayCloseCheck(bool _isFromManager) // , ByVal _goingToSelectedCheck As Boolean)
    {

        // this step we do everytime we close

        IsFromManager = _isFromManager;
        if (IsFromManager == true)
        {
            goingToSelectedCheck = false;
        }
        else
        {
            goingToSelectedCheck = true;
        }
        RePopulateSplitGrids();
        RecaculatePriceAndTaxRemaining();

        try
        {
        }
        // splitInactiveTimer.Stop()
        // RemoveHandler splitInactiveTimer.Tick, AddressOf MeTimeOutTick
        catch (Exception ex)
        {
            // MsgBox(ex.Message)
        }

        if (_closeCheck is not null)
        {
            _closeCheck.Visible = true;
            _closeCheck.ReinitializeCloseCheck(true);    // False)
        }
        else
        {
            _closeCheck = new CloseCheck(currentTable.CheckNumber); // (dvSplitCheck)
            _closeCheck.Location = new Point(0, 0);  // ((Me.Width - Me._closeCheck.Width) / 2, (Me.Height - Me._closeCheck.Height) / 2)
            this.Controls.Add(_closeCheck);
            _closeCheck.BringToFront();
        }

        // Me.splitPanel.Enabled = False

    }

    // testing for keyboard emulation of HID devices

    // Friend Sub handlesSwipe(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles MyBase.KeyPress
    // MsgBox(sender.ToString)
    // End Sub
    // Friend Sub handlesSwipe2(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    // MsgBox(sender.ToString)
    // End Sub
    // 
    // Friend Sub handlesSwipe3(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles MyBase.KeyPress
    // MsgBox(sender.ToString)
    // End Sub

    private void CheckSelected(object sender, EventArgs e)
    {
        ResetTimer();

        // splitInactiveTimer.Stop()
        // RemoveHandler splitInactiveTimer.Tick, AddressOf MeTimeOutTick

        PropertyAttributes objGrid; // SplitGridPanel
        objGrid = (PropertyAttributes)Conversions.ToInteger(sender);

        currentTable.CheckNumber = (int)objGrid;
        // activeCheck = objGrid
        activeCheckChanged = true;
        goingToSelectedCheck = true;
        // _closeCheck.Visible = True

        SplitDisposeSelf();

        // Me.Dispose()

    }

    private void SplitTimedOut()
    {

        SplitDisposeSelf();

    }

    private void MeTimeOutTick(object sender, EventArgs e) // Handles _closeCheck.DisposeSplitScreen
    {

        splitTimeoutCounter += 1;

        if (splitTimeoutCounter == companyInfo.timeoutMultiplier * 5)
        {
            SplitDisposeSelf();
        }

    }

    private void SplitDisposeSelf()
    {

        splitInactiveTimer.Stop();
        splitInactiveTimer.Tick -= MeTimeOutTick;
        // 444      tmrCardRead.Stop()
        // 444  RemoveHandler tmrCardRead.Tick, AddressOf _closeCheck.readAuth.tmrCardRead_Tick

        // 444      Dim doNotDisposeSelf As Boolean
        // 444     doNotDisposeSelf = _closeCheck.CheckForUnappliedCredit222(False)       'false for removeCash
        // 444    If doNotDisposeSelf = True Then Exit Sub

        // GenerateOrderTables.UpdatePaymentsAndCredits()

        if (RemainingBalancesZero == true & ds.Tables("RoutingChoice").Rows.Count > 0)
        {
            // Routing = 0 means no service printer
            // this forces send order, if Bal zero =, but only is service printer
            SendOrder?.Invoke(false);
        }


        if (_closeCheck.releaseFlag == true)
        {
            GenerateOrderTables.ReleaseTableOrTab();
        }
        else
        {
            // ********
            // we need to flag closed as 99 and fully paid (not released as 10)
            // If _closeCheck.RemainingBalancesZero = True Then
            // GenerateOrderTables.JustMarkAsCloseNoRelease()
            // End If
        }

        // 444   _closeCheck.readAuth.Shutdown()
        // 444    _closeCheck.readAuth = Nothing
        // 444new043009  _closeCheck.Visible = False

        // 444        _closeCheck.Dispose()
        // 444    _closeCheck = Nothing

        if (IsFromManager == true)    // Or goingToSelectedCheck = False Then
        {
            // goingToSelectedCheck is directing user to either manager or activeOrder
            // depends on where process orignated or if manager input their password
            if (actingManager is not null)
            {
                if (currentServer.EmployeeID == actingManager.EmployeeID)
                {
                    ManagerClosing?.Invoke(IsFromManager, actingManager, goingToSelectedCheck);
                }
                else
                {
                    // this means started as a server, then manager logged in
                    ManagerClosing?.Invoke(IsFromManager, currentServer, goingToSelectedCheck);
                }
            }
            else
            {
                // this is here just in case... should never get here
                ManagerClosing?.Invoke(IsFromManager, currentServer, goingToSelectedCheck);
            }
        }
        // RaiseEvent FireOrderScreen()
        else if (IsFromManager == false)
        {
            if (goingToSelectedCheck == false)
            {
                ManagerClosing?.Invoke(IsFromManager, currentServer, goingToSelectedCheck);
            }
            else
            {
                SplitCheckClosing?.Invoke();
                // _closeCheck.Visible = True

            }

        }

    }
    private void MakingGiftAddingAmountTrue()
    {

        MakeGiftAddingAmountTrue?.Invoke();

    }
    private void Manager_ClosingClose(bool going, bool remainBalZero)
    {

        goingToSelectedCheck = going;
        RemainingBalancesZero = remainBalZero;
        SplitDisposeSelf();

    }

    private void changeNumberOfGrids(object sender, EventArgs e)
    {
        ResetTimer();

        if (numberGridsInView == 4)
        {
            numberGridsInView = 10;
        }
        else
        {
            numberGridsInView = 4;
        }

        PerformChangeOfGrids();

    }

    private void PerformChangeOfGrids()
    {
        sgp1.Dispose();
        sgp2.Dispose();
        sgp3.Dispose();
        sgp4.Dispose();
        sgp5.Dispose();
        sgp6.Dispose();
        sgp7.Dispose();
        sgp8.Dispose();
        sgp9.Dispose();
        sgp10.Dispose();

        InitializeSplitGridPanels();
    }

    private void StartSplitItem(object sender, EventArgs e)
    {
        // Me.CurrentSplittingChecks.Clear()
        ResetTimer();
        var splitItemName = default(string);
        var splitItemPrice = default(decimal);
        int numberOfChecks;
        decimal amountOnEachCheck;
        decimal roundingError;

        foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("sin") == splitItemSIN)
                {
                    // verify food / drink item has been ordered
                    // can not split item before ordered
                    if (oRow("ForceFreeID") == -8 | oRow("ForceFreeID") == -9)
                    {
                        Interaction.MsgBox("This Item has been Transfered or Voided.");
                        return;
                    }
                    if (oRow("ItemStatus") < 2)
                    {
                        Interaction.MsgBox("You can not split an item until after it is ordered.");
                        return;
                    }
                    splitItemName = oRow("ItemName");
                    splitItemQuantity = oRow("Quantity");
                    splitItemInvMultiplier = oRow("OpenDecimal1");
                }
                if (oRow("sii") == splitItemSIN)
                {
                    splitItemPrice += oRow("Price");
                }
            }
        }

        // determine number of checks (possible)
        numberOfChecks = Conversions.ToInteger(DetermineCheckCount());
        checksSplitting = new SplittingCheck[numberOfChecks];
        // display label


        DetermineChecksToAddToCollection();

        // determine amount to each check
        amountOnEachCheck = Conversions.ToDecimal(DetermineAmountOnEachCheck(splitItemPrice, numberOfChecks));
        // determine rounding error
        roundingError = Conversions.ToDecimal(DetermineRoundingError(splitItemPrice, amountOnEachCheck, numberOfChecks));

        AddAmountToCollection(amountOnEachCheck, splitItemQuantity, numberOfChecks);

        splitItemPanel = new SplitItemUserControl(checksSplitting, splitItemPrice, splitItemQuantity, numberOfChecks);
        splitItemPanel.Location = new Point((this.Width - splitItemPanel.Width) / 2, (this.Height - splitItemPanel.Height) / 2);
        this.Controls.Add(splitItemPanel);

        splitItemPanel.BringToFront();

        DisplaySplitLabel(splitItemName);

    }

    private void ReleaseTable(object sender, EventArgs e)
    {
        // this will make table avail for seating and transfer any outstanding check with balances to named experience
        // ****************************************
        // *** this is for ONE CHECK .. no spliting
        ResetTimer();

        DataRow oRow;

        foreach (DataRow currentORow in dsOrder.Tables("OpenOrders").Rows)
        {
            oRow = currentORow;
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (!(oRow("CheckNumber") == 1))
                {
                    oRow("CheckNumber") = 1;
                }
            }
        }
        currentTable.NumberOfChecks = 1;

        if (currentTerminal.TermMethod == "Quick" | currentTable.TicketNumber > 0)
        {
            foreach (DataRow currentORow1 in dsOrder.Tables("QuickTickets").Rows)
            {
                oRow = currentORow1;
                if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                {
                    oRow("NumberOfChecks") = 1;
                }
            }
        }
        else if (currentTable.IsTabNotTable == true)
        {
            foreach (DataRow currentORow2 in dsOrder.Tables("AvailTabs").Rows)
            {
                oRow = currentORow2;
                if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                {
                    oRow("NumberOfChecks") = 1;
                }
            }
        }
        else
        {
            foreach (DataRow currentORow3 in dsOrder.Tables("AvailTables").Rows)
            {
                oRow = currentORow3;
                if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                {
                    oRow("NumberOfChecks") = 1;
                }
            }
        }

        // sss   GenerateOrderTables.SaveAvailTabsAndTables()

        numberGridsInView = 4;
        PerformChangeOfGrids();

    }

    private void RemoveTableFromCollection222()
    {

        foreach (DataSet_Builder.AvailTableUserControl btnTabsAndTables in currentActiveTables)
        {
            if (btnTabsAndTables.ExperienceNumber == currentTable.ExperienceNumber)
            {
                currentActiveTables.Remove(btnTabsAndTables);
                return;
            }
        }

    }
    private void GoToTestRemainingBalance()
    {

        // InitializeSplitGridPanels()
        RecaculatePriceAndTaxRemaining();
        _closeCheck.RemainingBalancesZero = TestRemainingBalances();
        // stops timer in CloseExiting

    }

    internal object TestRemainingBalances()
    {

        if (sgp1.remainingBalance > 0.03d & sgp1.remainingBalance < -0.03d)
        {
            return false;
        }
        else if (sgp2.remainingBalance > 0.03d & sgp2.remainingBalance < -0.03d)
        {
            return false;
        }
        else if (sgp3.remainingBalance > 0.03d & sgp3.remainingBalance < -0.03d)
        {
            return false;
        }
        else if (sgp4.remainingBalance > 0.03d & sgp4.remainingBalance < -0.03d)
        {
            return false;
        }
        else if (sgp5.remainingBalance > 0.03d & sgp5.remainingBalance < -0.03d)
        {
            return false;
        }
        else if (sgp6.remainingBalance > 0.03d & sgp6.remainingBalance < -0.03d)
        {
            return false;
        }
        else if (sgp7.remainingBalance > 0.03d & sgp7.remainingBalance < -0.03d)
        {
            return false;
        }
        else if (sgp8.remainingBalance > 0.03d & sgp8.remainingBalance < -0.03d)
        {
            return false;
        }
        else if (sgp9.remainingBalance > 0.03d & sgp9.remainingBalance < -0.03d)
        {
            return false;
        }
        else if (sgp10.remainingBalance > 0.03d & sgp10.remainingBalance < -0.03d)
        {
            return false;
        }

        return true;

    }

    private object DetermineCheckCount()
    {
        var checkCount = default(int);

        if (sgp1.splitGrid.Items.Count > 0)
        {
            checkCount += 1;
        }
        if (sgp2.splitGrid.Items.Count > 0)
        {
            checkCount += 1;
        }
        if (sgp3.splitGrid.Items.Count > 0)
        {
            checkCount += 1;
        }
        if (sgp4.splitGrid.Items.Count > 0)
        {
            checkCount += 1;
        }
        if (sgp5.splitGrid.Items.Count > 0)
        {
            checkCount += 1;
        }
        if (sgp6.splitGrid.Items.Count > 0)
        {
            checkCount += 1;
        }
        if (sgp7.splitGrid.Items.Count > 0)
        {
            checkCount += 1;
        }
        if (sgp8.splitGrid.Items.Count > 0)
        {
            checkCount += 1;
        }
        if (sgp9.splitGrid.Items.Count > 0)
        {
            checkCount += 1;
        }
        if (sgp10.splitGrid.Items.Count > 0)
        {
            checkCount += 1;
        }

        return checkCount;

    }

    private void DetermineChecksToAddToCollection()
    {
        int index = 0;

        if (sgp1.splitGrid.Items.Count > 0)
        {
            AddCheckToCollection(1, index);
            index += 1;
        }
        if (sgp2.splitGrid.Items.Count > 0)
        {
            AddCheckToCollection(2, index);
            index += 1;
        }
        if (sgp3.splitGrid.Items.Count > 0)
        {
            AddCheckToCollection(3, index);
            index += 1;
        }
        if (sgp4.splitGrid.Items.Count > 0)
        {
            AddCheckToCollection(4, index);
            index += 1;
        }
        if (sgp5.splitGrid.Items.Count > 0)
        {
            AddCheckToCollection(5, index);
            index += 1;
        }
        if (sgp6.splitGrid.Items.Count > 0)
        {
            AddCheckToCollection(6, index);
            index += 1;
        }
        if (sgp7.splitGrid.Items.Count > 0)
        {
            AddCheckToCollection(7, index);
            index += 1;
        }
        if (sgp8.splitGrid.Items.Count > 0)
        {
            AddCheckToCollection(8, index);
            index += 1;
        }
        if (sgp9.splitGrid.Items.Count > 0)
        {
            AddCheckToCollection(9, index);
            index += 1;
        }
        if (sgp10.splitGrid.Items.Count > 0)
        {
            AddCheckToCollection(10, index);
            index += 1;
        }


    }

    private void AddCheckToCollection(int checkNumber, int indexNumber)
    {

        checksSplitting[indexNumber] = new SplittingCheck();
        checksSplitting[indexNumber].CheckNumber = checkNumber;

    }

    private void AddAmountToCollection(decimal amount, int quantity, int number)
    {
        int extraQuantity;
        int index;
        int checksWithQuantitySplit;

        extraQuantity = splitItemQuantity - number;

        var loopTo = number - 1;
        for (index = 0; index <= loopTo; index++)
        {
            checksSplitting[index].CheckAmount = amount;

            if (extraQuantity >= 0)
            {
                if (index == 0)
                {
                    // first check gets any extra
                    checksSplitting[index].CheckQuantity = 1 + extraQuantity;
                    checksSplitting[index].CheckInvMultiplier = splitItemInvMultiplier; // + (splitItemInvMultiplier * extraQuantity)
                }
                else
                {
                    checksSplitting[index].CheckQuantity = 1;
                    checksSplitting[index].CheckInvMultiplier = splitItemInvMultiplier;
                }
            }
            else if (extraQuantity < 0)
            {
                if (index + 1 > splitItemQuantity)
                {
                    checksSplitting[index].CheckQuantity = 0;
                    checksSplitting[index].CheckInvMultiplier = 0;
                }
                else
                {
                    checksSplitting[index].CheckQuantity = 1;
                    checksSplitting[index].CheckInvMultiplier = splitItemInvMultiplier;
                }
            }
        }

    }

    private object DetermineAmountOnEachCheck(decimal totalPrice, int n)
    {
        decimal amount;

        amount = Conversions.ToDecimal(Strings.Format(totalPrice / n, "###0.00"));

        return amount;

    }

    private object DetermineRoundingError(decimal totalPrice, decimal eachAmount, int n)
    {
        decimal rounding;

        rounding = Conversions.ToDecimal(Strings.Format(totalPrice - eachAmount * n, "###0.00"));

        return rounding;

    }

    private void DisplaySplitLabel(string itemName)
    {

        splitItemPanel.splitItemLabel.Text = "Spliting Item: " + itemName;

    }

    private void ApplingSplitCheckFirstStep(object sender, EventArgs e)
    {
        ResetTimer();

        CurrentSplittingChecks = new SplittingCheckCollection();

        foreach (SplittingCheck check in splitItemPanel.checkArray)
        {
            if (check.CheckAmount > 0)
            {
                CurrentSplittingChecks.Add(check);
            }
        }

        ApplingSplitCheckSecondStep();
        // RaiseEvent ApplySplitCheck(sender, e)

    }


    // maybe, place new price on the original check
    // eliminate the original check for the collection
    // then place the split info on new checks w/ new sin's

    private void ApplingSplitCheckSecondStep()
    {
        var eachCheck = default(SplittingCheck);
        var currentItem = new SelectedItemDetail();

        foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("sii") == splitItemSIN)
                {
                    if (oRow("sin") == splitItemSIN)
                    {
                        // this determines which check in the collection is the original
                        foreach (SplittingCheck currentEachCheck in CurrentSplittingChecks)
                        {
                            eachCheck = currentEachCheck;
                            if (oRow("CheckNumber") == eachCheck.CheckNumber)
                            {

                                oRow("Price") = eachCheck.CheckAmount;
                                oRow("TaxPrice") = DetermineTaxPrice(oRow("TaxID"), eachCheck.CheckAmount);
                                oRow("SinTax") = DetermineSinTax(oRow("TaxID"), eachCheck.CheckAmount);
                                oRow("Quantity") = eachCheck.CheckQuantity;

                                currentItem.InvMultiplier = eachCheck.CheckInvMultiplier; // oRow("OpenDecimal1") 'don't think correct
                                // not sure about table
                                currentItem.ItemPrice = oRow("ItemPrice");
                                currentItem.ID = oRow("ItemID");
                                currentItem.Name = oRow("ItemName");
                                currentItem.TerminalName = oRow("ItemName");
                                currentItem.ChitName = oRow("ItemName");
                                currentItem.TaxID = oRow("TaxID");
                                currentItem.OrderNumber = oRow("OrderNumber");

                                currentItem.Course = oRow("CourseNumber");
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
                        CurrentSplittingChecks.Remove(eachCheck);
                    }
                    else    // this is for sub-items
                    {
                        oRow("Price") = 0;
                    }
                }
            }
        }

        foreach (SplittingCheck currentEachCheck1 in CurrentSplittingChecks)
        {
            eachCheck = currentEachCheck1;
            currentTable.SIN += 1;       // we need to add an extra (so we have room for cust number)
            currentItem.Check = eachCheck.CheckNumber;
            currentItem.Price = eachCheck.CheckAmount;
            currentItem.Quantity = eachCheck.CheckQuantity;
            currentItem.InvMultiplier = eachCheck.CheckInvMultiplier;
            currentItem.SIN = currentTable.SIN;
            currentItem.SII = currentTable.SIN;
            currentItem.InvMultiplier = 0;   // ****** don't think correct, but want original to have 
            // need to figure in SplittingCheck Collection

            currentItem.Table = currentTable.TableNumber;
            currentItem.Customer = eachCheck.CheckNumber;        // should ask for this if multi cust on second check

            GenerateOrderTables.PopulateDataRowForOpenOrder(currentItem);
            currentTable.SIN += 1;
        }

        // AdjustOpenOrderPosition()
        // GenerateOrderTables.SaveOpenOrderData()

        // reflects the change
        ResetSplitGrids();

    }

    private void ResetSplitGrids()
    {

        sgp1.splitGrid.Items.Clear();
        sgp2.splitGrid.Items.Clear();
        sgp3.splitGrid.Items.Clear();
        sgp4.splitGrid.Items.Clear();
        sgp5.splitGrid.Items.Clear();
        sgp6.splitGrid.Items.Clear();
        sgp7.splitGrid.Items.Clear();
        sgp8.splitGrid.Items.Clear();
        sgp9.splitGrid.Items.Clear();
        sgp10.splitGrid.Items.Clear();

        sgp1.CreateSplitDataView(1);
        sgp2.CreateSplitDataView(2);
        sgp3.CreateSplitDataView(3);
        sgp4.CreateSplitDataView(4);
        sgp5.CreateSplitDataView(5);
        sgp6.CreateSplitDataView(6);
        sgp7.CreateSplitDataView(7);
        sgp8.CreateSplitDataView(8);
        sgp9.CreateSplitDataView(9);
        sgp10.CreateSplitDataView(10);


    }

    private void CloseCheckSelectedReOrder(DataTable dt, bool tabTestNeeded)
    {

        SelectedReOrder?.Invoke(dt, true);

    }

    private void FiringTabScreen(string startInSearch, string searchCriteria)
    {

        FireTabScreen?.Invoke(startInSearch, searchCriteria);

    }

    // Private Sub AuthPaymentButtonSelected(ByRef authamount As PreAuthAmountClass, ByRef authtransaction As PreAuthTransactionClass, ByVal cardSwipedDatabaseInfo As Boolean) Handles _closeCheck.AuthPayments

    // closeCreditCardAuth = New CloseManualAuth(authamount, authtransaction, cardSwipedDatabaseInfo)
    // Me.closeCreditCardAuth.Location = New Point((Me.Width - Me.closeCreditCardAuth.Width) / 2, (Me.Height - Me.closeCreditCardAuth.Height) / 2)
    // Me.Controls.Add(Me.closeCreditCardAuth)
    // Me.closeCreditCardAuth.BringToFront()

    // End Sub

    private void MerchantAuthirizingPaymentStep1(int paymentID, bool justActive)
    {

        MerchantAuthPayment?.Invoke(paymentID, justActive);

    }



    // **** not using *****
    private void AddTransferedItemsToOpenOrder222(int empID, long expNum)
    {
        DataRow nRow;

        foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("CheckNumber") == currentTable.CheckNumber)
                {

                    // cmd = New SqlClient.SqlCommand("INSERT INTO OpenOrders(EmployeeID, TableNumber, ExperienceNumber) VALUES (@EmployeeID, @TableNumber, @ExperienceNumber)", sql.cn)
                    // cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4)) ', "EmployeeID"))
                    // cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ExperienceNumber", System.Data.SqlDbType.Int, 4)) ', "ExperienceNumber"))
                    // cmd.Parameters("@ExperienceNumber").Value = expNum
                    // '              cmd.Parameters("@EmployeeID").Value = empID

                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@TabID").Value = oRow("TabID");
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@TabName").Value = oRow("TabName");
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@TableNumber").Value = oRow("TableNumber");
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@ExperienceNumber").Value = expNum;
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@OrderNumber").Value = oRow("OrderNumber");
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@MenuID").Value = oRow("MenuID");
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@EmployeeID").Value = empID;
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@CheckNumber").Value = oRow("CheckNumber");   // ??
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@CustomerNumber").Value = oRow("CustomerNumber");
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@sin").Value = oRow("sin");
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@sii").Value = oRow("sii");
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@ItemID").Value = oRow("ItemID");
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@ItemName").Value = oRow("ItemName");
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@Price").Value = oRow("Price");
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@TaxID").Value = oRow("TaxID");
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@ForceFreeCode").Value = 0;
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@CategoryID").Value = oRow("CategoryID");
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@FoodID").Value = oRow("FoodID");
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@DrinkCategoryID").Value = oRow("DrinkCategoryID");
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@DrinkID").Value = oRow("DrinkID");
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@FunctionID").Value = oRow("FunctionID");
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@RoutingID").Value = oRow("RoutingID");
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@PrintPriorityID").Value = oRow("PrintPriorityID");
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@ItemStatus").Value = oRow("ItemStatus"); // 9
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@TerminalID").Value = oRow("TerminalID");
                    sql.SqlInsertCommandOpenOrdersSP.Parameters("@dbUP").Value = oRow("dbUP");
                    oRow("ItemStatus") = 9;

                    sql.cn.Open();
                    sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                    sql.SqlInsertCommandOpenOrdersSP.ExecuteNonQuery();
                    // cmd.ExecuteNonQuery()
                    sql.cn.Close();

                }
            }

        }


    }



}