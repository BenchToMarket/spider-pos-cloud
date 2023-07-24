using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using DataSet_Builder;


public partial class OrderGridView : System.Windows.Forms.UserControl
{

    private Panel pnlDirection;
    private Button _btnDown;

    private Button btnDown
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDown;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnDown != null)
            {
                _btnDown.Click -= btnOrderViewDown_Click;
            }

            _btnDown = value;
            if (_btnDown != null)
            {
                _btnDown.Click += btnOrderViewDown_Click;
            }
        }
    }
    private Button _btnUp;

    private Button btnUp
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnUp;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnUp != null)
            {
                _btnUp.Click -= btnOrderViewUp_Click;
            }

            _btnUp = value;
            if (_btnUp != null)
            {
                _btnUp.Click += btnOrderViewUp_Click;
            }
        }
    }
    private Label _lblOrderView;

    private Label lblOrderView
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblOrderView;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblOrderView != null)
            {
                _lblOrderView.Click -= ChangeCheckNumberLabelHit;
            }

            _lblOrderView = value;
            if (_lblOrderView != null)
            {
                _lblOrderView.Click += ChangeCheckNumberLabelHit;
            }
        }
    }
    private Timer holdDoubleClickTimer;
    internal bool holdTimerActive;
    internal bool isInHoldMode;
    internal bool justAddedPanel;

    internal OrderGrid gridViewOrder;
    private OrderGridColumn csCourse;
    private OrderGridColumn csItemName;
    private OrderGridColumn csQuantity;
    private float csItemDefaultWidth;

    internal bool gridByCheck;
    internal int qtRow;    // quick ticket row

    private Panel pnlSubTotal;
    private Button checkNumberButton;
    private Label totalOrderLabel = new Label();
    internal Label totalOrderTax;
    internal Label totalOrder;
    private string totalOrderLabelString = "Sub Total:";
    private DataSet_Builder.Information_UC info;

    private Panel _coursePanel;

    private Panel coursePanel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _coursePanel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _coursePanel = value;
        }
    }
    private KitchenButton btnCourse1;
    private KitchenButton btnCourse2;
    private KitchenButton btnCourse3;
    private KitchenButton btnCourse4;
    // Private btnCourse5 As KitchenButton

    private Panel kitchenCommands = new Panel();
    private KitchenButton _btnSend;

    private KitchenButton btnSend
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnSend;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnSend != null)
            {
                _btnSend.Click -= btnSendClick;
            }

            _btnSend = value;
            if (_btnSend != null)
            {
                _btnSend.Click += btnSendClick;
            }
        }
    }
    private KitchenButton _btnHold;

    private KitchenButton btnHold
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnHold;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnHold != null)
            {
                _btnHold.Click -= btnHoldClick;
            }

            _btnHold = value;
            if (_btnHold != null)
            {
                _btnHold.Click += btnHoldClick;
            }
        }
    }
    private KitchenButton _btnVoid;

    private KitchenButton btnVoid
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnVoid;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnVoid != null)
            {
                _btnVoid.Click -= btnVoidClick;
            }

            _btnVoid = value;
            if (_btnVoid != null)
            {
                _btnVoid.Click += btnVoidClick;
            }
        }
    }
    private KitchenButton _btnModify;

    private KitchenButton btnModify
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnModify;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnModify != null)
            {
                _btnModify.Click -= btnModify_Click;
            }

            _btnModify = value;
            if (_btnModify != null)
            {
                _btnModify.Click += btnModify_Click;
            }
        }
    }
    private KitchenButton _btnView;

    private KitchenButton btnView
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnView;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnView != null)
            {
                _btnView.Click -= btnStatusClick;
            }

            _btnView = value;
            if (_btnView != null)
            {
                _btnView.Click += btnStatusClick;
            }
        }
    }
    private KitchenButton _btnLeave;

    private KitchenButton btnLeave
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnLeave;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnLeave != null)
            {
                _btnLeave.Click -= btnLeaveClick;
            }

            _btnLeave = value;
            if (_btnLeave != null)
            {
                _btnLeave.Click += btnLeaveClick;
            }
        }
    }
    // Quick Service
    private KitchenButton _btnPrevious;

    private KitchenButton btnPrevious
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnPrevious;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnPrevious != null)
            {
                _btnPrevious.Click -= btnPreviousClick;
            }

            _btnPrevious = value;
            if (_btnPrevious != null)
            {
                _btnPrevious.Click += btnPreviousClick;
            }
        }
    }
    private KitchenButton _btnNew;

    private KitchenButton btnNew
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnNew;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnNew != null)
            {
                _btnNew.Click -= btnNewClick;
            }

            _btnNew = value;
            if (_btnNew != null)
            {
                _btnNew.Click += btnNewClick;
            }
        }
    }

    private Panel ViewStatus;
    private KitchenButton _btnViewDetail;

    private KitchenButton btnViewDetail
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnViewDetail;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _btnViewDetail = value;
        }
    }
    private KitchenButton _btnViewHolds;

    private KitchenButton btnViewHolds
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnViewHolds;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _btnViewHolds = value;
        }
    }
    private KitchenButton _btnViewKitchen;

    private KitchenButton btnViewKitchen
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnViewKitchen;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _btnViewKitchen = value;
        }
    }
    private KitchenButton _btnViewMain;

    private KitchenButton btnViewMain
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnViewMain;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _btnViewMain = value;
        }
    }
    private KitchenButton _btnViewCourse;

    private KitchenButton btnViewCourse
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnViewCourse;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _btnViewCourse = value;
        }
    }
    private KitchenButton _btnViewTable;

    private KitchenButton btnViewTable
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnViewTable;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _btnViewTable = value;
        }
    }



    // Event AddingItemToOrder(ByVal sender As Object)
    public event ChangeCustColorEventHandler ChangeCustColor;

    public delegate void ChangeCustColorEventHandler(Color c);
    public event ChangeCustomerEventEventHandler ChangeCustomerEvent;

    public delegate void ChangeCustomerEventEventHandler(string btnText, bool testForPanel1);
    // Event RePopulateDataViews()
    public event UpdatingViewsByCheckEventHandler UpdatingViewsByCheck;

    public delegate void UpdatingViewsByCheckEventHandler();
    public event JustSaveOrderEventHandler JustSaveOrder;

    public delegate void JustSaveOrderEventHandler();
    public event LeaveOrderViewEventHandler LeaveOrderView;

    public delegate void LeaveOrderViewEventHandler();
    public event ModifyItemEventHandler ModifyItem;

    public delegate void ModifyItemEventHandler(object sender, EventArgs e);
    public event ClearControlsEventHandler ClearControls;

    public delegate void ClearControlsEventHandler();
    public event ClearPanelsEventHandler ClearPanels;

    public delegate void ClearPanelsEventHandler();
    public event CloseFastEventHandler CloseFast;

    public delegate void CloseFastEventHandler(object sender, EventArgs e);
    public event CloseCheckEventHandler CloseCheck;

    public delegate void CloseCheckEventHandler(object sender, EventArgs e);
    public event SendOrderEventHandler SendOrder;

    public delegate void SendOrderEventHandler(bool alsoClose);
    public event VoidItemEventHandler VoidItem;

    public delegate void VoidItemEventHandler();
    public event UC_HitEventHandler UC_Hit;

    public delegate void UC_HitEventHandler();
    public event DisplayInfoEventHandler DisplayInfo;

    public delegate void DisplayInfoEventHandler(object msg);
    public event NewQuickServiceOrderEventHandler NewQuickServiceOrder;

    public delegate void NewQuickServiceOrderEventHandler(long expNum);
    public event RunPizzaRoutineEventHandler RunPizzaRoutine;

    public delegate void RunPizzaRoutineEventHandler(int valuesi2);
    public event ResetPizzaRoutineEventHandler ResetPizzaRoutine;

    public delegate void ResetPizzaRoutineEventHandler();
    public event DeliverStartEventHandler DeliverStart;

    public delegate void DeliverStartEventHandler();
    public event DineInStartEventHandler DineInStart;

    public delegate void DineInStartEventHandler(bool fromNewTab);
    public event OnFullPizzaEventHandler OnFullPizza;

    public delegate void OnFullPizzaEventHandler(object sender, EventArgs e);
    public event DrinkButtonsONEventHandler DrinkButtonsON;

    public delegate void DrinkButtonsONEventHandler();
    public event DrinkButtonsOFFEventHandler DrinkButtonsOFF;

    public delegate void DrinkButtonsOFFEventHandler();
    public event EndingItemEventHandler EndingItem;

    public delegate void EndingItemEventHandler(bool LeavingAnyway);


    #region  Windows Form Designer generated code 

    public OrderGridView() : base()
    {
        gridViewOrder = new OrderGrid();
        checkNumberButton = new Button();
        totalOrderTax = new Label();
        totalOrder = new Label();
        ViewStatus = new Panel();

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        InitializeOther();
        gridViewOrder.CurrentCellChanged += gridViewOrder_CellChanged;
        ViewStatus.Click += ViewStatusClick;
        totalOrder.Click += TotalOrderButton_Click;
        totalOrderTax.Click += TotalOrderTaxButton_Click;
        checkNumberButton.Click += CheckNumberButton_Click;

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
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        // 
        // OrderGridView
        // 
        this.Name = "OrderGridView";
        this.Size = new System.Drawing.Size(312, 448);

    }

    #endregion

    private void InitializeOther()
    {

        this.SuspendLayout();

        this.Height = 768 - 2 * buttonSpace; // totalArea.Height - (2 * buttonSpace)

        OpenOrdersCurrencyMan = this.BindingContext(dsOrder.Tables("OpenOrders"));

        DisplayDirectionPanel();

        DisplayOrderView();

        AddGridViewOrderColumns();

        CreateSubTotalPanel();

        CreateCourseButtonPanel();

        CreateKitchenCommandPanel();

        InitializeViewSecondStep();

        this.ResumeLayout();

    }

    internal void InitializeViewSecondStep()
    {

        int numberNONCourse2;
        int maxQuantity;

        holdTimerActive = false;
        isInHoldMode = false;
        justAddedPanel = false;

        if (dsOrder.Tables("OpenOrders").Rows.Count == 0)
        {
            numberNONCourse2 = 0;
        }
        else
        {
            numberNONCourse2 = dsOrder.Tables("OpenOrders").Compute("Count(Quantity)", "CourseNumber > 2 OR CourseNumber = 1");
        }

        if (numberNONCourse2 == 0)
        {
            csCourse.Width = 0;
            csItemName.Width = csItemDefaultWidth;
        }
        else
        {
            maxQuantity = dsOrder.Tables("OpenOrders").Compute("Max(Quantity)", "sin = sii");
            MakeRoomForCourseInfo();
            // Me.csCourse.Width = 20
            // csItemName.Width = Me.csItemDefaultWidth - 20
            TestQuantityForDisplay(maxQuantity);
        }

        if (currentTable.IsClosed == true)
        {
            totalOrder.BackColor = c7;
            totalOrderTax.BackColor = c7;
        }
        else
        {
            totalOrder.BackColor = c3;
            totalOrderTax.BackColor = c3;
        }

        if (!(currentTerminal.TermMethod == "Quick") & !(currentTerminal.TermMethod == "Bar"))
        {
            btnCourse1.BackColor = c7;
            btnCourse2.BackColor = c9;
        }
        else
        {
            btnCourse1.BackColor = c9;
            btnCourse2.BackColor = c7;
        }

        switch (currentTerminal.TermMethod)
        {
            case "Table":
                {
                    break;
                }

            case "Bar":
                {
                    if (currentTable.TabID == -888)
                    {
                        // -888 is for TabGroup  
                        btnPrevious.Visible = true;
                        btnNew.Visible = true;
                        btnHold.Visible = false;
                        btnView.Visible = false;
                    }
                    else
                    {
                        btnPrevious.Visible = false;
                        btnNew.Visible = false;
                        btnHold.Visible = true;
                        btnView.Visible = true;
                    }

                    break;
                }

            case "Quick":
                {
                    try
                    {
                        if (dvQuickTickets(dvQuickTickets.Count - 1)("ExperienceNumber") == currentTable.ExperienceNumber)
                        {
                            btnNew.Text = "New";
                        }
                        else
                        {
                            btnNew.Text = "Next";
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    break;
                }
        }

        ReStateOrderView();

        UpdateCheckNumberButton();

        CalculateSubTotal();

        DetermineQuickTicketRow();

    }

    private void DisplayDirectionPanel()
    {
        float dirHeight;
        float dirButtonWidth;

        pnlDirection = new Panel();
        btnDown = new Button();
        btnUp = new Button();
        lblOrderView = new Label();

        dirHeight = this.Height * 0.07d;
        dirButtonWidth = this.Width / 3;

        pnlDirection.Location = new Point(0, 0);
        pnlDirection.Size = new Size(this.Width, dirHeight);
        pnlDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

        btnDown.Location = new Point(0, 0);
        lblOrderView.Location = new Point(dirButtonWidth, 0);
        btnUp.Location = new Point(2f * dirButtonWidth, 0);

        btnDown.Size = new Size(dirButtonWidth, dirHeight);
        lblOrderView.Size = new Size(dirButtonWidth, dirHeight);
        btnUp.Size = new Size(dirButtonWidth, dirHeight);

        btnDown.BackColor = c6;
        lblOrderView.BackColor = c6;
        btnUp.BackColor = c6;

        btnDown.ForeColor = c3;
        lblOrderView.ForeColor = c3;
        btnUp.ForeColor = c3;

        btnDown.TextAlign = ContentAlignment.BottomCenter;
        btnUp.TextAlign = ContentAlignment.TopCenter;
        lblOrderView.TextAlign = ContentAlignment.MiddleCenter;
        // Me.lblDirection.Te()  word wrap??


        pnlDirection.Controls.Add(btnDown);
        pnlDirection.Controls.Add(lblOrderView);
        pnlDirection.Controls.Add(btnUp);
        this.Controls.Add(pnlDirection);

        DisplayDownButtonText();
        DisplayUpButtonText();
        DisplayDirectionLabel("Detail");


    }

    private void DisplayOrderView()
    {

        // gridview
        gridViewOrder.Location = new Point(0, pnlDirection.Height);
        gridViewOrder.Size = new Size(this.Width, this.Height * 0.63d);
        // Me.gridViewOrder.BackColor = Color.White
        gridViewOrder.BackgroundColor = c2;
        gridViewOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.0d, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        // Me.gridViewOrder.Font = New System.Drawing.Font("Myriad Condensed Web", 12.0, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        // Me.gridViewOrder.Font = New System.Drawing.Font("Century Gothic", 12.0, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        // Me.gridViewOrder.Font = New System.Drawing.Font("TImes New Roman", 12.0, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        gridViewOrder.ReadOnly = true;
        gridViewOrder.Controls(0).Height = 0;
        gridViewOrder.Controls(1).Width = 0;

        gridViewOrder.ColumnHeadersVisible = false;
        gridViewOrder.RowHeadersVisible = false;
        gridViewOrder.CaptionVisible = false;
        gridViewOrder.DataSource = dvOrder; // dsOrder.Tables("Order")
        currentTable.OrderView = "Detail";
        gridViewOrder.SelectionBackColor = Color.Blue;
        gridViewOrder.AllowSorting = false;
        this.BackColor = c2;

        this.Controls.Add(gridViewOrder);


    }

    private void ReStateOrderView()
    {

        OpenOrdersCurrencyMan = this.BindingContext(dsOrder.Tables("OpenOrders"));
        gridViewOrder.DataSource = dvOrder; // dsOrder.Tables("Order")
        currentTable.OrderView = "Detail";

    }


    private void AddGridViewOrderColumns()
    {

        var tsOrder = new DataGridTableStyle();
        tsOrder.MappingName = "OpenOrders"; // "Order"
        tsOrder.RowHeadersVisible = false;
        tsOrder.GridLineStyle = DataGridLineStyle.None;

        var csStatus = new DataGridTextBoxColumn();
        csStatus.MappingName = "ItemStatus";
        csStatus.Width = 0;

        var csSIN = new DataGridTextBoxColumn();
        csSIN.MappingName = "sin";
        csSIN.Width = 0;

        var csSII = new DataGridTextBoxColumn();
        csSII.MappingName = "sii";
        csSII.Width = 0;

        var csSI2 = new DataGridTextBoxColumn();
        csSI2.MappingName = "si2";
        csSI2.Width = 0;

        var csCust = new DataGridTextBoxColumn();
        csCust.MappingName = "CustomerNumber";
        csCust.Width = 0;

        // *** changed from dataGridTextBoxColumn (which gave it a reverse text)
        csCourse = new OrderGridColumn(false, false, true); // (Price, Quantity, Course)
        csCourse.MappingName = "CourseNumber";
        // csCourse.width is below

        var csItemID = new DataGridTextBoxColumn();
        csItemID.MappingName = "ItemID";
        csItemID.Width = 0;

        csQuantity = new OrderGridColumn(false, true, false); // (Price, Quantity, Course)
        csQuantity.MappingName = "Quantity";
        csQuantity.Width = 15;
        csQuantity.Alignment = HorizontalAlignment.Right;

        csItemName = new OrderGridColumn(false, false, false); // DataGridTextBoxColumn 
        csItemDefaultWidth = 235f; // (0.8 * Me.Width) - 15
        csItemName.MappingName = "TerminalName";
        // csItemName.TextBox.WordWrap = True
        // csItemName.Width = Me.csItemDefaultWidth (below)

        var csItemCost = new OrderGridColumn(true, false, false); // (Price, Quantity)   'Price   'DataGridTextBoxColumn
        csItemCost.MappingName = "Price";
        csItemCost.Width = 0.19d * this.Width;                  // this is column 9
        csItemCost.Alignment = HorizontalAlignment.Right;

        // moved courseColumn to 2nd step
        csCourse.Width = 0;
        csItemName.Width = csItemDefaultWidth;

        var csRoutingID = new DataGridTextBoxColumn();
        csRoutingID.MappingName = "RoutingID";
        csRoutingID.Width = 0;

        var csDrinkFlag = new DataGridTextBoxColumn();
        csDrinkFlag.MappingName = "FunctionFlag";
        csDrinkFlag.Width = 0;

        tsOrder.GridColumnStyles.Add(csStatus);
        tsOrder.GridColumnStyles.Add(csSIN);
        tsOrder.GridColumnStyles.Add(csSII);
        tsOrder.GridColumnStyles.Add(csSI2);
        tsOrder.GridColumnStyles.Add(csCust);
        tsOrder.GridColumnStyles.Add(csCourse);
        tsOrder.GridColumnStyles.Add(csItemID);
        tsOrder.GridColumnStyles.Add(csQuantity);
        tsOrder.GridColumnStyles.Add(csItemName);
        tsOrder.GridColumnStyles.Add(csItemCost);
        tsOrder.GridColumnStyles.Add(csRoutingID);
        tsOrder.GridColumnStyles.Add(csDrinkFlag);
        // tsOrder.GridColumnStyles.Add(csBlank)
        gridViewOrder.TableStyles.Add(tsOrder);

    }

    private void gridViewOrder_CellChanged(object sender, EventArgs e)
    {
        UC_Hit?.Invoke();

        int tempReferenceSIN;
        int valueSIN;
        int valueSII;
        var valueSI2 = default(int);
        int rowNum;

        // MsgBox(currentTable.SIN)

        // if in middle of order do not adjust customer number
        // If currentTable.SIN > currentTable.ReferenceSIN Then
        if (currentTable.MiddleOfOrder == true)
        {
            // Exit Sub
            EndingItem?.Invoke(false);
            // this would be reset to false if no longer req modifier
            if (currentTable.ReqModifier == true)
            {
                // Me.gridViewOrder.CurrentRowIndex = OpenOrdersCurrencyMan.Position
                return;
            }

            OpenOrdersCurrencyMan.Position = gridViewOrder.CurrentRowIndex;
        }
        // 444      currentTable.MiddleOfOrder = False
        // Exit Sub
        else
        {
            ClearControls?.Invoke();
            OpenOrdersCurrencyMan.Position = gridViewOrder.CurrentRowIndex;
            currentTable.TempReferenceSIN = (int)gridViewOrder.Item(OpenOrdersCurrencyMan.Position, 2);
        }

        rowNum = OpenOrdersCurrencyMan.Position;
        // If CType(gridViewOrder.Item(rowNum, 4), Integer) = currentTable.CustomerNumber Or currentTable.MiddleOfOrder = False Then
        // currentTable.TempReferenceSIN = CType(Me.gridViewOrder.Item(OpenOrdersCurrencyMan.Position, 2), Integer)
        // End If

        try
        {
            valueSI2 = (int)gridViewOrder.Item(rowNum, 3);
        }
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);
        }

        try
        {
            valueSIN = (int)gridViewOrder.Item(rowNum, 1);
            valueSII = (int)gridViewOrder.Item(rowNum, 2);
        }
        catch (Exception ex)
        {
            return;
        }

        if (isInHoldMode == true)
        {
            RunHoldRoutine(rowNum, valueSIN, valueSII);
            return;
        }

        if (valueSI2 > 0 & valueSI2 < 10)
        {
            currentTable.ReferenceSIN = currentTable.TempReferenceSIN;   // ????
            currentTable.SecondRound = true;
            RunPizzaRoutine?.Invoke(valueSI2);
            currentTable.si2 = valueSI2; // CType(Me.gridViewOrder.Item(rowNum, 3), Integer)
        }

        else
        {

            // 444    If currentTable.si2 > 0 Then
            // RaiseEvent ResetPizzaRoutine()
            // End If

        }

        // 444      If Not currentTerminal.TermMethod = "Quick" Then ' And Not currentTerminal.TermMethod = "Bar" Then
        foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("sin") == currentTable.TempReferenceSIN)
                {
                    if (!(currentTerminal.TermMethod == "Quick") & !(currentTerminal.TermMethod == "Bar"))
                    {
                        if (!(oRow("CourseNumber") == 0))
                        {
                            currentTable.CourseNumber = oRow("CourseNumber");
                            ChangeCourseButton(currentTable.CourseNumber);
                        }
                    }
                    else if (!(oRow("Quantity") == 0))
                    {
                        currentTable.Quantity = oRow("Quantity");
                        ChangeCourseButton(currentTable.Quantity);

                    }

                    if (justAddedPanel == true)
                    {
                        justAddedPanel = false;
                    }
                    else
                    {
                        ChangeCustColor?.Invoke(c7);
                        currentTable.CustomerNumber = oRow("CustomerNumber");
                        ChangeCustomerEvent?.Invoke(oRow("CustomerNumber").ToString, false);
                        // *****************************************
                        // this is for problem jumping customers after deleting
                        // If currentTable.JumpedToNextCustomer = False Then
                        // 'this is defined oin delete (btnVoidClick)
                        // RaiseEvent ChangeCustomerEvent(oRow("CustomerNumber").ToString, False)
                        // Else
                        // currentTable.JumpedToNextCustomer = False
                        // End If
                    }
                    break;
                }
            }
        }
        // 444 End If

        if (gridViewOrder.Item(rowNum, 11) == "D")
        {

            DrinkButtonsON?.Invoke();
        }
        else
        {
            DrinkButtonsOFF?.Invoke();
        }

    }

    private void CreateSubTotalPanel()
    {
        float adjHeight;

        pnlSubTotal = new Panel();
        pnlSubTotal.Location = new Point(0, pnlDirection.Height + gridViewOrder.Height);
        pnlSubTotal.Size = new Size(this.Width, this.Height * 0.07d);

        adjHeight = pnlSubTotal.Height * 0.7d;

        // **********************
        // Panel with SubTotal
        checkNumberButton.Location = new Point(0, 0);
        totalOrderLabel.Location = new Point(0.35d * this.Width, 0);
        totalOrder.Location = new Point(0.55d * this.Width, 20);
        totalOrderTax.Location = new Point(0.55d * this.Width, 0);
        totalOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        totalOrderTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        checkNumberButton.Size = new Size(0.34d * this.Width, adjHeight);
        totalOrderLabel.Size = new Size(0.2d * this.Width, adjHeight);
        totalOrder.Size = new Size(0.45d * this.Width, pnlSubTotal.Height - 20);
        totalOrderTax.Size = new Size(0.45d * this.Width, 20); // Me.pnlSubTotal.Height)
        // totalOrder displays subtotal

        totalOrderLabel.Text = totalOrderLabelString;
        totalOrder.Text = Strings.Format((decimal)(currentTable.SubTotal + currentTable.SubTax), "##,##0.00");
        totalOrderTax.Text = Strings.Format((decimal)currentTable.SubTax, "##,##0.00");

        totalOrderLabel.TextAlign = ContentAlignment.MiddleLeft;
        totalOrder.TextAlign = ContentAlignment.MiddleRight;
        totalOrderTax.TextAlign = ContentAlignment.TopRight;
        if (currentTable.IsClosed == true)
        {
            totalOrder.BackColor = c7;
            totalOrderTax.BackColor = c7;
        }
        else
        {
            totalOrder.BackColor = c3;
            totalOrderTax.BackColor = c3;
        }
        totalOrderTax.BackColor = Color.Transparent;
        checkNumberButton.BackColor = c1;

        pnlSubTotal.Controls.Add(checkNumberButton);
        pnlSubTotal.Controls.Add(totalOrderLabel);
        pnlSubTotal.Controls.Add(totalOrder);
        pnlSubTotal.Controls.Add(totalOrderTax);
        this.Controls.Add(pnlSubTotal);

    }

    private void CreateCourseButtonPanel()
    {

        coursePanel = new Panel();
        coursePanel.SuspendLayout();

        coursePanel.Location = new Point(1, pnlDirection.Height + gridViewOrder.Height + pnlSubTotal.Height);
        coursePanel.Size = new Size(this.Width, this.Height * 0.05d);
        coursePanel.BackColor = c7;

        float w = coursePanel.Width / 4;
        float h = coursePanel.Height;
        float x = 0f;

        if (!(currentTerminal.TermMethod == "Quick") & !(currentTerminal.TermMethod == "Bar"))
        {
            btnCourse1 = new KitchenButton(1, w, h, c7, c2);
        }
        else
        {
            btnCourse1 = new KitchenButton(1, w, h, c9, c2);
        }
        {
            ref var withBlock = ref btnCourse1;
            withBlock.Location = new Point(x, 0);
            withBlock.ForeColor = c3;
            this.btnCourse1.Click += CourseButton_Click;
        }
        x = x + w;

        if (!(currentTerminal.TermMethod == "Quick") & !(currentTerminal.TermMethod == "Bar"))
        {
            btnCourse2 = new KitchenButton(2, w, h, c9, c2);
        }
        else
        {
            btnCourse2 = new KitchenButton(2, w, h, c7, c2);
        }
        {
            ref var withBlock1 = ref btnCourse2;
            withBlock1.Location = new Point(x, 0);
            withBlock1.ForeColor = c3;
            this.btnCourse2.Click += CourseButton_Click;
        }
        x = x + w;

        btnCourse3 = new KitchenButton(3, w, h, c7, c2);
        {
            ref var withBlock2 = ref btnCourse3;
            withBlock2.Location = new Point(x, 0);
            withBlock2.ForeColor = c3;
            this.btnCourse3.Click += CourseButton_Click;
        }
        x = x + w;

        btnCourse4 = new KitchenButton(4, w, h, c7, c2);
        {
            ref var withBlock3 = ref btnCourse4;
            withBlock3.Location = new Point(x, 0);
            withBlock3.ForeColor = c3;
            this.btnCourse4.Click += CourseButton_Click;
        }
        // x = x + w

        // btnCourse5 = New KitchenButton(5, w, h, c7, c2)
        // With btnCourse5
        // .Location = New Point(x, 0)
        // .ForeColor = c3
        // AddHandler btnCourse5.Click, AddressOf CourseButton_Click
        // End With
        // x = x + w

        coursePanel.Controls.Add(btnCourse1);
        coursePanel.Controls.Add(btnCourse2);
        coursePanel.Controls.Add(btnCourse3);
        coursePanel.Controls.Add(btnCourse4);
        // coursePanel.Controls.Add(btnCourse5)

        coursePanel.ResumeLayout();
        this.Controls.Add(coursePanel);

    }

    private void CreateKitchenCommandPanel()
    {

        double xPanelSize = this.Width;
        double yPanelSize = this.Height * 0.18d;
        double xButtonSize = (xPanelSize - 4 * buttonSpace) / 3;
        double yButtonSize = (yPanelSize - 3 * buttonSpace) / 2;
        double xButtonStep = xButtonSize + buttonSpace;
        double yButtonStep = yButtonSize + buttonSpace;
        double x = buttonSpace;
        double y = buttonSpace;

        switch (currentTerminal.TermMethod)
        {
            case "Table":
                {
                    btnHold = new KitchenButton("Hold", xButtonSize, yButtonSize, c4, c3);
                    btnHold.Location = new Point(x, y);
                    break;
                }
            case "Bar":
                {
                    // 444    If currentTable.TabID = -888 Then
                    // -888 is for TabGroup
                    btnPrevious = new KitchenButton("Previous", xButtonSize, yButtonSize, c4, c3);
                    btnPrevious.Location = new Point(x, y);
                    // Else
                    btnHold = new KitchenButton("Hold", xButtonSize, yButtonSize, c4, c3);
                    btnHold.Location = new Point(x, y);
                    break;
                }
            // End If

            case "Quick":
                {
                    btnPrevious = new KitchenButton("Previous", xButtonSize, yButtonSize, c4, c3);
                    btnPrevious.Location = new Point(x, y);
                    break;
                }
        }
        x = x + xButtonStep;
        btnVoid = new KitchenButton("Delete", xButtonSize, yButtonSize, c4, c3);
        btnVoid.Location = new Point(x, y);
        x = x + xButtonStep;

        switch (currentTerminal.TermMethod)
        {
            case "Table":
                {
                    btnView = new KitchenButton("View", xButtonSize, yButtonSize, c4, c3);
                    btnView.Location = new Point(x, y);
                    break;
                }
            case "Bar":
                {
                    // 444       If currentTable.TabID = -888 Then
                    // -888 is for TabGroup
                    btnNew = new KitchenButton("New", xButtonSize, yButtonSize, c4, c3);
                    btnNew.Location = new Point(x, y);
                    // Else
                    btnView = new KitchenButton("View", xButtonSize, yButtonSize, c4, c3);
                    btnView.Location = new Point(x, y);
                    break;
                }
            // End If

            case "Quick":
                {
                    try
                    {
                        if (dvQuickTickets(dvQuickTickets.Count - 1)("ExperienceNumber") == currentTable.ExperienceNumber)
                        {
                            btnNew = new KitchenButton("New", xButtonSize, yButtonSize, c4, c3);
                            btnNew.Location = new Point(x, y);
                        }
                        else
                        {
                            btnNew = new KitchenButton("Next", xButtonSize, yButtonSize, c4, c3);
                            btnNew.Location = new Point(x, y);
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    break;
                }

        }
        x = buttonSpace;
        y = y + yButtonStep;

        btnSend = new KitchenButton("Send", xButtonSize, yButtonSize, c4, c3);
        btnSend.Location = new Point(x, y);
        x = x + xButtonStep;
        btnModify = new KitchenButton("Modify", xButtonSize, yButtonSize, c4, c3);
        btnModify.Location = new Point(x, y);
        x = x + xButtonStep;
        btnLeave = new KitchenButton("Leave", xButtonSize, yButtonSize, c4, c3);
        btnLeave.Location = new Point(x, y);

        // in reverse order
        kitchenCommands.Controls.Add(btnLeave);
        kitchenCommands.Controls.Add(btnModify);
        kitchenCommands.Controls.Add(btnSend);
        kitchenCommands.Controls.Add(btnVoid);

        switch (currentTerminal.TermMethod)
        {
            case "Table":
                {
                    kitchenCommands.Controls.Add(btnView);
                    kitchenCommands.Controls.Add(btnHold);
                    break;
                }
            case "Bar":
                {
                    // 444      If currentTable.TabID = -888 Then
                    // -888 is for TabGroup
                    kitchenCommands.Controls.Add(btnNew);
                    kitchenCommands.Controls.Add(btnPrevious);
                    // Else
                    kitchenCommands.Controls.Add(btnView);
                    kitchenCommands.Controls.Add(btnHold);
                    break;
                }
            // End If
            case "Quick":
                {
                    kitchenCommands.Controls.Add(btnNew);
                    kitchenCommands.Controls.Add(btnPrevious);
                    break;
                }
        }
        x = buttonSpace;
        y = buttonSpace;

        btnViewKitchen = new KitchenButton("Sent", xButtonSize, yButtonSize, c1, c2);
        btnViewKitchen.Location = new Point(x, y);
        x = x + xButtonStep;
        btnViewHolds = new KitchenButton("Holds", xButtonSize, yButtonSize, c1, c2);
        btnViewHolds.Location = new Point(x, y);
        x = x + xButtonStep;
        btnViewDetail = new KitchenButton("Detail", xButtonSize, yButtonSize, c1, c2);
        btnViewDetail.Location = new Point(x, y);
        x = buttonSpace;
        y = y + yButtonStep;
        btnViewTable = new KitchenButton("By Check", xButtonSize, yButtonSize, c1, c2);
        btnViewTable.Location = new Point(x, y);
        x = x + xButtonStep;
        btnViewCourse = new KitchenButton("Course", xButtonSize, yButtonSize, c1, c2);
        btnViewCourse.Location = new Point(x, y);
        x = x + xButtonStep;
        btnViewMain = new KitchenButton("Main", xButtonSize, yButtonSize, c1, c2);
        btnViewMain.Location = new Point(x, y);

        this.btnViewDetail.Click += ViewStatusClick;
        this.btnViewHolds.Click += ViewStatusClick;
        this.btnViewKitchen.Click += ViewStatusClick;
        this.btnViewMain.Click += ViewStatusClick;
        this.btnViewCourse.Click += ViewStatusClick;
        this.btnViewTable.Click += ViewStatusClick;

        // in reverse order
        ViewStatus.Controls.Add(btnViewTable);
        ViewStatus.Controls.Add(btnViewCourse);
        ViewStatus.Controls.Add(btnViewMain);
        ViewStatus.Controls.Add(btnViewKitchen);
        ViewStatus.Controls.Add(btnViewHolds);
        ViewStatus.Controls.Add(btnViewDetail);

        kitchenCommands.Location = new Point(0, pnlDirection.Height + gridViewOrder.Height + pnlSubTotal.Height + coursePanel.Height + buttonSpace);
        kitchenCommands.Size = new Size(this.Width, yPanelSize);
        // kitchenCommands.BackColor = c7
        kitchenCommands.BackColor = c2;
        kitchenCommands.BorderStyle = BorderStyle.FixedSingle;

        ViewStatus.Location = new Point(0, pnlDirection.Height + gridViewOrder.Height + pnlSubTotal.Height + coursePanel.Height + buttonSpace);
        ViewStatus.Size = new Size(this.Width, yPanelSize);
        ViewStatus.BackColor = c7;
        ViewStatus.Visible = false;

        this.Controls.Add(kitchenCommands);
        this.Controls.Add(ViewStatus);

    }

    private void CourseButton_Click(object sender, EventArgs e) // Handles coursePanel.Click
    {
        UC_Hit?.Invoke();
        if (currentTable.IsClosed == true)
        {
            return;
        }

        KitchenButton objButton;
        var increaseQuanity = default(int);


        int rowNum = OpenOrdersCurrencyMan.Position;  // gridViewOrder.CurrentCell.RowNumber
        int valueSIN;
        int valueSII;


        try
        {
            objButton = (KitchenButton)sender;
        }
        catch (Exception ex)
        {
            return;
        }
        try
        {
            valueSIN = (int)gridViewOrder.Item(rowNum, 1);
            valueSII = (int)gridViewOrder.Item(rowNum, 2);
        }
        catch (Exception ex)
        {
            return;
        }


        if (!object.ReferenceEquals(objButton.GetType, btnCourse1.GetType))
            return;
        if (!(currentTerminal.TermMethod == "Quick") & !(currentTerminal.TermMethod == "Bar"))
        {
            currentTable.CourseNumber = objButton.Text;
            ChangeCourseButton(currentTable.CourseNumber);
        }
        else
        {
            if (!(valueSII == valueSIN))
            {
                EndingItem?.Invoke(true);
                // this would be reset to false if no longer req modifier
                if (currentTable.ReqModifier == true)
                    return;

                // this will not allow you to change quantity mid orders
                // 444       Exit Sub
            }

            increaseQuanity = objButton.Text;
            if (currentTable.Quantity == 1)
            {
                // this is b/c the first time we hit we are only selecting quantithy
                currentTable.Quantity = increaseQuanity;
            }
            else
            {
                currentTable.Quantity += increaseQuanity;
            }    // CInt(objButton.Text)
            ChangeCourseButton(increaseQuanity);
        }

        if (!(currentTerminal.TermMethod == "Quick") & !(currentTerminal.TermMethod == "Bar"))
        {

            if (isInHoldMode == true)
            {
                foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
                {
                    if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                    {
                        if (oRow("CourseNumber") == currentTable.CourseNumber)
                        {
                            if (oRow("ItemStatus") == 0)
                            {
                                oRow("ItemStatus") = 1;
                            }
                            else if (oRow("ItemStatus") == 1)
                            {
                                oRow("ItemStatus") = 0;
                            }
                        }
                    }
                }
            }
        }
        else
        {
            // we change quantity for current item by this much

            if (dsOrder.Tables("OpenOrders").Rows.Count == 0)
                return;

            DataRow oRow;
            var oldQuantity = default(int);
            var newQuantity = default(int);


            if (valueSIN == valueSII)
            {
                // this is if it is a main food, therefore we can change the quantity
                foreach (DataRow currentORow in dsOrder.Tables("OpenOrders").Rows)
                {
                    oRow = currentORow;
                    if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                    {
                        if (!(oRow("ItemStatus") > 1) & !(oRow("ItemID") == 0))
                        {
                            // not already ordered or customer button
                            if (oRow("sin") == valueSIN)
                            {
                                oldQuantity = oRow("Quantity");
                                if (oldQuantity == 1)
                                {
                                    increaseQuanity -= 1;
                                }
                                newQuantity = oldQuantity + increaseQuanity;
                            }
                            if (oRow("sii") == valueSII)
                            {
                                oRow("Quantity") = newQuantity;
                                // the below updates prices for the change
                                oRow("Price") = Strings.Format(oRow("Price") * (newQuantity / (double)oldQuantity), "####0.00");
                                oRow("TaxPrice") = Strings.Format(oRow("TaxPrice") * (newQuantity / (double)oldQuantity), "####0.00");
                            }
                        }
                    }
                }
            }
            else
            {

                foreach (DataRow currentORow1 in dsOrder.Tables("OpenOrders").Rows)
                {
                    oRow = currentORow1;
                    if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                    {
                        if (!(oRow("ItemStatus") > 1) & !(oRow("ItemID") == 0))
                        {
                            // not already ordered or customer button
                            if (oRow("sin") == valueSII)
                            {
                                oldQuantity = oRow("Quantity");
                                if (oldQuantity == 1)
                                {
                                    increaseQuanity -= 1;
                                }
                                newQuantity = oldQuantity + increaseQuanity;
                            }
                            if (oRow("sii") == valueSII)
                            {
                                oRow("Quantity") = newQuantity;
                                // the below updates prices for the change
                                oRow("Price") = Strings.Format(oRow("Price") * (newQuantity / (double)oldQuantity), "####0.00");
                                oRow("TaxPrice") = Strings.Format(oRow("TaxPrice") * (newQuantity / (double)oldQuantity), "####0.00");
                            }
                        }
                    }
                }
            }

            TestQuantityForDisplay(newQuantity);

            CalculateSubTotal();
        }
        // End If

    }

    internal void TestQuantityForDisplay(int maxQuantity)
    {

        if (maxQuantity > 9)
        {
            csQuantity.Width = 25;
            if (csItemName.Width == csItemDefaultWidth)
            {
                csItemName.Width = csItemDefaultWidth - 10f;
            }
            else if (csItemName.Width == csItemDefaultWidth - 20f)
            {
                // when couse panel is showing
                csItemName.Width = csItemDefaultWidth - 30f;
            }
        }

    }

    internal void MakeRoomForCourseInfo()
    {

        csCourse.Width = 20;
        csItemName.Width = csItemDefaultWidth - 20f;
    }

    internal void ChangeCourseButton(int btnChange)
    {

        btnCourse1.BackColor = c7;
        btnCourse2.BackColor = c7;
        btnCourse3.BackColor = c7;
        btnCourse4.BackColor = c7;
        // btnCourse5.BackColor = c7

        switch (btnChange)   // currentTable.CourseNumber
        {
            case 1:
                {
                    btnCourse1.BackColor = c9;
                    break;
                }
            case 2:
                {
                    btnCourse2.BackColor = c9;
                    break;
                }
            case 3:
                {
                    btnCourse3.BackColor = c9;
                    break;
                }
            case 4:
                {
                    btnCourse4.BackColor = c9;
                    break;
                }
            case 5:
                {
                    break;
                }
                // btnCourse5.BackColor = c9
        }


    }



    internal object DetermineQuickTicketRow()
    {
        int count = 0;
        // this is a one time routine

        foreach (DataRowView vRow in dvQuickTickets)
        {
            if (vRow("ExperienceNumber") == currentTable.ExperienceNumber)
            {
                qtRow = count;
                return default;
            }
            count += 1;
        }

        return qtRow;

    }

    private void ViewStatusClick(object sender, EventArgs e)
    {
        UC_Hit?.Invoke();

        KitchenButton objButton = (KitchenButton)sender;

        if (object.ReferenceEquals(objButton, btnViewDetail))             // all items with detail     by check
        {
            gridViewOrder.DataSource = dvOrder; // dsOrder.Tables("Order")
            currentTable.OrderView = "Detail";
        }

        else if (object.ReferenceEquals(objButton, btnViewHolds))         // just holds for all checks
        {
            gridViewOrder.DataSource = dvOrderHolds;
            currentTable.OrderView = "Holds";
        }

        else if (object.ReferenceEquals(objButton, btnViewKitchen))         // to kitchen for all checks
        {
            gridViewOrder.DataSource = dvKitchen;
            currentTable.OrderView = "Sent";
        }

        else if (object.ReferenceEquals(objButton, btnViewMain))         // main items
        {
            gridViewOrder.DataSource = dvOrderTopHierarcy;
            currentTable.OrderView = "Main Items";
        }

        else if (object.ReferenceEquals(objButton, btnViewCourse))         // open
        {
            if (csCourse.Width == 0)
            {
                csCourse.Width = 20;

                if (csItemName.Width == csItemDefaultWidth)
                {
                    csItemName.Width = csItemDefaultWidth - 20f;
                }
                else if (csItemName.Width == csItemDefaultWidth - 10f)
                {
                    // when quantity > 10
                    csItemName.Width = csItemDefaultWidth - 30f;
                }
            }
            else
            {
                csCourse.Width = 0;
                csItemName.Width = csItemDefaultWidth;
            }
        }

        else if (object.ReferenceEquals(objButton, btnViewTable))         // All Checks
        {
            if (gridByCheck == true)
            {
                gridByCheck = false;
                btnViewTable.Text = "By Check";
                CreateDataViewsOrder();
            }
            // RaiseEvent RePopulateDataViews()
            // CreateDataViews()
            else
            {
                gridByCheck = true;
                btnViewTable.Text = "Table";
                UpdatingViewsByCheck?.Invoke();

                // UpdateDataViewsByCheck()
            }


            switch (currentTable.OrderView)
            {
                case "Detail":
                    {
                        gridViewOrder.DataSource = dvOrder;
                        break;
                    }
                case "Holds":
                    {
                        gridViewOrder.DataSource = dvOrderHolds;
                        break;
                    }
                case "Sent":
                    {
                        gridViewOrder.DataSource = dvKitchen;
                        break;
                    }
                case "Main Items":
                    {
                        gridViewOrder.DataSource = dvOrderTopHierarcy;
                        break;
                    }
            }

        }


        // *******************
        // table / ByCheck could be better

        UpdateCheckNumberButton();

        // not sure if we need to update subtotal  ?????????????
        // CalculateSubTotal()
        ViewStatus.Visible = false;
        kitchenCommands.Visible = true;

    }

    private void HoldTimerExpired(object sender, EventArgs e)
    {
        holdTimerActive = false;
        holdDoubleClickTimer.Dispose();

    }

    private void btnNewClick(object sender, EventArgs e)
    {
        var expNum = default(long);
        int tktNum;
        string tabNameString;

        EndingItem?.Invoke(true);
        // this would be reset to false if no longer req modifier
        if (currentTable.ReqModifier == true)
            return;

        if (qtRow < dvQuickTickets.Count - 1)
        {
            qtRow += 1;
            expNum = dvQuickTickets[qtRow]("ExperienceNumber");
            if (qtRow == dvQuickTickets.Count - 1)
            {
                btnNew.Text = "New";
            }

            GotoDifferentTable(expNum);
            NewQuickServiceOrder?.Invoke(expNum);
        }
        else
        {
            // here we are at the end creating a new ticket
            if (dsOrder.Tables("OpenOrders").Rows.Count == 0 & currentTable.IsClosed == false)
                return;

            try
            {
                qtRow += 1;
                expNum = GenerateOrderTables.CreatingNewTicket();
                currentTable.TabName = "Tkt# " + currentTable.TicketNumber.ToString;
                if (qtRow > dvQuickTickets.Count - 1)
                {
                    // this is a just in case
                    qtRow = dvQuickTickets.Count - 1;
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Error Creating New Ticket: " + ex.Message);
            }

            try
            {
                if (!(currentTable.TabID == -888))
                {
                    if (currentTable.MethodUse == "Delivery")
                    {
                        DeliverStart?.Invoke();
                    }
                    else if (currentTable.MethodUse == "Dine In")
                    {
                        // 444   If ds.Tables("TabIdentifier").Rows.Count > 0 Then
                        DineInStart?.Invoke(true);
                        // 444   End If
                    }
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Error Dine In Start: " + ex.Message);
            }

            try
            {
                GotoDifferentTable(expNum);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("Error Goto Different Table: " + ex.Message);
            }
            try
            {
                NewQuickServiceOrder?.Invoke(expNum);
            }
            catch (Exception ex)
            {
                Interaction.MsgBox("New Quick Service Order: " + ex.Message);
            }

        }


    }

    private void btnPreviousClick(object sender, EventArgs e)
    {
        if (qtRow == 0)
            return;
        EndingItem?.Invoke(true);
        // this would be reset to false if no longer req modifier
        if (currentTable.ReqModifier == true)
            return;

        long expNum;

        qtRow -= 1;
        expNum = dvQuickTickets[qtRow]("ExperienceNumber");
        btnNew.Text = "Next";

        GotoDifferentTable(expNum);

        NewQuickServiceOrder?.Invoke(expNum);

    }

    private void GotoDifferentTable(long expNum)
    {

        ClearControls?.Invoke();
        if (currentTable.si2 > 0 & currentTable.si2 < 10)
        {
            ClearPanels?.Invoke();
        }

        if (!(typeProgram == "Online_Demo"))
        {
            GenerateOrderTables.ReleaseCurrentlyHeld();
            // sss     GenerateOrderTables.SaveAvailTabsAndTables()
            GenerateOrderTables.SaveOpenOrderData();
        }
        // dsOrder.Tables("OpenOrders").Rows.Clear()
        else
        {
            GenerateOrderTables.SaveOpenOrderDataExceptQuick();
        }

        currentTable = (object)null;

        bool isCurrentlyHeld;

        isCurrentlyHeld = PopulateThisExperience(dvQuickTickets[qtRow]("ExperienceNumber"), false);
        currentTable = new DinnerTable();

        currentTable.CurrentMenu = dvQuickTickets[qtRow]("MenuID");
        currentTable.StartingMenu = dvQuickTickets[qtRow]("MenuID");
        currentTable.EmployeeID = dvQuickTickets[qtRow]("EmployeeID");
        foreach (DataRow oRow in dsEmployee.Tables("AllEmployees").Rows)
        {
            if (oRow("EmployeeID") == currentTable.EmployeeID)
            {
                currentTable.EmployeeName = oRow("NickName");
                break;
            }
        }
        // currentTable.EmployeeName = dvQuickTickets(qtRow)("NickName")

        currentTable.IsTabNotTable = true;
        currentTable.TableNumber = (object)null;
        currentTable.TabID = dvQuickTickets[qtRow]("TabID");
        currentTable.TabName = dvQuickTickets[qtRow]("TabName");
        currentTable.TicketNumber = dvQuickTickets[qtRow]("TicketNumber");

        currentTable.ExperienceNumber = dvQuickTickets[qtRow]("ExperienceNumber");
        currentTable.NumberOfChecks = dvQuickTickets[qtRow]("NumberOfChecks");
        currentTable.CheckNumber = 1;
        currentTable.NumberOfCustomers = dvQuickTickets[qtRow]("NumberOfCustomers");
        currentTable.LastStatus = dvQuickTickets[qtRow]("LastStatus");
        currentTable.OrderView = dvQuickTickets[qtRow]("LastView");
        currentTable.MethodUse = dvQuickTickets[qtRow]("MethodUse");
        DefineMethodDirection();

        if (!object.ReferenceEquals(dvQuickTickets[qtRow]("ClosedSubTotal"), DBNull.Value))
        {
            currentTable.IsClosed = true;
        }
        else
        {
            currentTable.IsClosed = false;
        }
        currentTable.ItemsOnHold = dvQuickTickets[qtRow]("ItemsOnHold");

        UpdateCheckNumberButton();

    }

    private void btnHoldClick(object sender, EventArgs e)
    {
        UC_Hit?.Invoke();
        // If dvOrder.Count = 0 Then Exit Sub

        if (holdTimerActive == false)
        {
            holdDoubleClickTimer = new DateAndTime.Timer();
            holdTimerActive = true;
            this.holdDoubleClickTimer.Tick += HoldTimerExpired;
            holdDoubleClickTimer.Interval = 500;
            holdDoubleClickTimer.Start();
        }
        else if (isInHoldMode == false)
        {
            isInHoldMode = true;
            btnHold.BackColor = Color.Red;
        }
        else
        {
            isInHoldMode = false;
            btnHold.BackColor = c4;
        }


        int rowNum = OpenOrdersCurrencyMan.Position;  // gridViewOrder.CurrentCell.RowNumber
        int valueSIN;
        int valueSII;
        try
        {
            valueSIN = (int)gridViewOrder.Item(rowNum, 1);
            valueSII = (int)gridViewOrder.Item(rowNum, 2);
        }
        catch (Exception ex)
        {
            return;
        }

        RunHoldRoutine(rowNum, valueSIN, valueSII);

    }

    private void RunHoldRoutine(int rowNum, int valueSIN, int valueSII)
    {
        var newStatus = default(int);

        // If dvOrder(rowNum)("ItemStatus") = 0 Then
        if (gridViewOrder.DataSource(rowNum)("ItemStatus") == 0)
        {
            newStatus = 1;
        }
        else if (gridViewOrder.DataSource(rowNum)("ItemStatus") == 1)
        {
            newStatus = 0;
        }
        else if (gridViewOrder.DataSource(rowNum)("ItemStatus") == 2)
        {
            return;
        }
        else if (gridViewOrder.DataSource(rowNum)("ItemStatus") == 3)
        {
            return;
        }
        else if (gridViewOrder.DataSource(rowNum)("ItemStatus") == 4)
        {
            return;
        }

        foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
        {
            // If oRow("sii") = valueSIN Then       this is if we just want to hold if press main item
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("sii") == valueSII)
                {
                    oRow("ItemStatus") = newStatus;
                }
            }
        }

    }

    private void btnVoidClick(object sender, EventArgs e)
    {
        // this is for DELETE not void
        UC_Hit?.Invoke();
        if (dvOrder.Count == 0)
            return;
        if (currentTable.IsClosed == true)
        {
            return;
        }
        if (gridViewOrder.Item(gridViewOrder.CurrentRowIndex, 9) < 0)
            return;

        int rowNum = OpenOrdersCurrencyMan.Position;

        int valueSIN;
        int valueSII;
        try
        {
            valueSIN = (int)gridViewOrder.Item(rowNum, 1);
            valueSII = (int)gridViewOrder.Item(rowNum, 2);
        }
        catch (Exception ex)
        {
            return;
        }

        if (valueSIN == valueSII)
        {
            ClearControls?.Invoke();
        }

        DeleteItem(valueSIN, valueSII);

    }

    internal void DeleteItem(int valueSIN, int valueSII)
    {
        var oRow = default(DataRow);
        var sinArray = new int[dsOrder.Tables("OpenOrders").Rows.Count + 1 + 1];
        var count = default(int);

        // this is so when we start deleting rows it won't place new rows as detached and give us error
        if (valueSII == valueSIN)
        {
            // *** main food
            foreach (DataRow currentORow in dsOrder.Tables("OpenOrders").Rows)
            {
                oRow = currentORow;
                // oRow.BeginEdit()
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (oRow("sii") == valueSIN)
                    {
                        if (oRow("ItemID") == 0 & oRow("si2") < 2)
                        {
                            // this is only cutomer panels (pizza panels will have si2 > 1)
                            int cnCount;
                            cnCount = DetermineCnTest(oRow("CustomerNumber"));
                            if (cnCount > 1)
                            {
                                return;    // we exit if it is a customer panel associated with an order
                            }
                            else
                            {
                                currentTable.EmptyCustPanel = 0;
                            }
                        }
                        if (oRow("ItemStatus") < 0 | oRow("ItemStatus") > 1)
                        {
                            DisplayInfo?.Invoke("Can not delete this Item. Please see Manager");
                            return;
                        }
                        if (oRow("ItemStatus") == 0 | oRow("itemStatus") == 1)
                        {
                            sinArray[count] = oRow("sin");
                            // terminalID(count) = oRow("OpenOrderID")
                            count += 1;
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
                        foreach (DataRow currentORow1 in dsOrder.Tables("OpenOrders").Rows)
                        {
                            oRow = currentORow1;
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
                if (currentTable.si2 == 1)
                {
                    ClearPanels?.Invoke();
                    ResetPizzaRoutine?.Invoke();
                }
            }

            if (!(currentTable.Quantity == 1))
            {
                currentTable.Quantity = 1;
                ChangeCourseButton(currentTable.Quantity);
            }

            if (currentTable.ReqModifier == true)
            {
                currentTable.ReqModifier = false; // this is because we deleted the item, so who cares
            }
            // we already tested EndingItem, so don't repeat
            else
            {
                EndingItem?.Invoke(true);
            }
        }

        // *****************************************
        // this is for problem jumping customers after deleting
        // if we delete an item and and we fall to the next customer 
        // this will prevent us from defaulting to nextCustomer in gridViewOrder
        // (which is called automatically when we delete and change current cell)

        // currentTable.JumpedToNextCustomer = False

        // For Each oRow In dsOrder.Tables("OpenOrders").Rows
        // If Not oRow.RowState = DataRowState.Deleted And Not oRow.RowState = DataRowState.Detached Then
        // If oRow("CustomerNumber") = currentTable.CustomerNumber Then
        // If oRow("sin") > valueSIN Then
        // currentTable.JumpedToNextCustomer = False
        // 'this means that there still are items below this deleted item
        // Exit For
        // End If
        // End If
        // If oRow("CustomerNumber") > currentTable.CustomerNumber Then
        // currentTable.JumpedToNextCustomer = True
        // End If
        // '       End If
        // Next


        else if (valueSII < valueSIN)
        {
            // *** food modifier
            if (!(typeProgram == "Online_Demo"))
            {
                oRow = dsOrder.Tables("OpenOrders").Rows.Find(valueSIN);
            }
            else
            {
                foreach (DataRow currentORow2 in dsOrder.Tables("OpenOrders").Rows)
                {
                    oRow = currentORow2;
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
                if (oRow("ItemStatus") < 0 | oRow("ItemStatus") > 1)
                {
                    DisplayInfo?.Invoke("Can not delete this Item. Please see Manager");
                    return;
                }
                if (oRow("ItemID") == 0 & oRow("si2") > 1)
                {
                    // for pizza half panels
                    foreach (DataRow pRow in dsOrder.Tables("OpenOrders").Rows)
                    {
                        if (!(pRow.RowState == DataRowState.Deleted) & !(pRow.RowState == DataRowState.Detached))
                        {
                            if (pRow("sii") == valueSII & pRow("si2") == oRow("si2"))
                            {
                                if (pRow("ItemStatus") < 0 | pRow("ItemStatus") > 1)
                                {
                                    DisplayInfo?.Invoke("Can not delete this Item. Please see Manager");
                                    return;
                                }
                                if (pRow("ItemStatus") == 0 | pRow("itemStatus") == 1)
                                {
                                    sinArray[count] = pRow("sin");
                                    count += 1;
                                }
                            }
                        }
                    }
                }

                if (count > 0)
                {
                    int i;
                    var loopTo1 = count - 1;
                    for (i = 0; i <= loopTo1; i++)
                    {
                        if (!(typeProgram == "Online_Demo"))
                        {
                            oRow = dsOrder.Tables("OpenOrders").Rows.Find(sinArray[i]);
                        }
                        else
                        {
                            foreach (DataRow currentORow3 in dsOrder.Tables("OpenOrders").Rows)
                            {
                                oRow = currentORow3;
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

                    if (currentTable.si2 == 2 | currentTable.si2 == 3)
                    {
                        // this is for fist or second panel
                        currentTable.si2 = 1;
                        gridViewOrder.CurrentRowIndex -= count;
                    }
                }
                else
                {
                    GenerateOrderTables.DeleteOpenOrdersRowTerminal(oRow);
                }

            }
        }

        CalculateSubTotal();

        // *****************************************
        // this is for problem jumping customers after deleting
        // currentTable.MiddleOfOrder = False
        currentTable.MarkForNextCustomer = false;
        currentTable.NextCustomerNumber = currentTable.CustomerNumber;

    }

    private void btnModify_Click(object sender, EventArgs e)
    {
        if (dvOrder.Count == 0)
            return;
        EndingItem?.Invoke(true);
        // this would be reset to false if no longer req modifier
        if (currentTable.ReqModifier == true)
            return;

        if (currentTable.IsClosed == true)
        {
            return;
        }

        // we kept on term_Order b/c that is where we display Modify UC
        ModifyItem?.Invoke(sender, e);

    }










    private void TotalOrderButton_Click(object sender, EventArgs e)
    {

        if (dsOrder.Tables("OpenOrders").Rows.Count == 0 | currentTable.IsClosed == true)
            return;
        CloseFast?.Invoke(sender, e);

    }

    private void TotalOrderTaxButton_Click(object sender, EventArgs e)
    {

        if (dsOrder.Tables("OpenOrders").Rows.Count == 0 | currentTable.IsClosed == true)
            return;
        CloseFast?.Invoke(sender, e);

    }

    private void CheckNumberButton_Click(object sender, EventArgs e)
    {

        if (currentTable.IsClosed == true)
            return;

        // currently forcing send in SplitChecks after Exit/Release
        // 444    RaiseEvent SendOrder(False)

        CloseCheck?.Invoke(sender, e);

    }

    internal void UpdateCheckNumberButton()
    {
        string orderHeaderText;

        if (currentTerminal.TermMethod == "Quick" | currentTable.TicketNumber > 0)
        {
            // 444      If Not currentTerminal.TermMethod = "Quick" Then
            DataRowView vrow;
            currentTerminal.NumOpenTickets = 0;
            if (currentTerminal.TermMethod == "Quick")
            {
                foreach (DataRowView currentVrow in dvQuickTickets)
                {
                    vrow = currentVrow;
                    if (object.ReferenceEquals(vrow("ClosedSubTotal"), DBNull.Value))
                    {
                        currentTerminal.NumOpenTickets += 1;
                    }
                }
            }
            else
            {
                foreach (DataRowView currentVrow1 in dvQuickTickets)
                {
                    vrow = currentVrow1;
                    if (object.ReferenceEquals(vrow("ClosedSubTotal"), DBNull.Value) & vrow("EmployeeID") == currentTable.EmployeeID)
                    {
                        currentTerminal.NumOpenTickets += 1;
                    }
                }
            }

            // 444 End If
            checkNumberButton.Text = currentTerminal.NumOpenTickets.ToString + "   Open";

            if (currentTable.NumberOfChecks == 1)
            {
                orderHeaderText = "                  " + currentTable.OrderView.ToString;    // 18 spaces
                lblOrderView.BackColor = c6;
                lblOrderView.ForeColor = c3;
            }
            else
            {
                orderHeaderText = "Check   " + currentTable.CheckNumber + " of " + currentTable.NumberOfChecks;
                lblOrderView.BackColor = c1;
                lblOrderView.ForeColor = c2;
            }
        }

        else if (currentTable.NumberOfChecks == 1)
        {
            checkNumberButton.Text = "Check   " + currentTable.CheckNumber + " of " + currentTable.NumberOfChecks;
            orderHeaderText = "                  " + currentTable.OrderView.ToString;    // 18 spaces
            lblOrderView.BackColor = c6;
            lblOrderView.ForeColor = c3;
        }
        else if (gridByCheck == false)
        {
            checkNumberButton.Text = "Check   All of " + currentTable.NumberOfChecks;
            orderHeaderText = "                  " + currentTable.OrderView.ToString;    // 18 spaces
            lblOrderView.BackColor = c6;
            lblOrderView.ForeColor = c3;
        }
        else
        {
            checkNumberButton.Text = "Check   " + currentTable.CheckNumber + " of " + currentTable.NumberOfChecks; // currentTable._checkCollection.Count
            orderHeaderText = "  " + currentTable.OrderView.ToString;     // 6 spaces
            lblOrderView.BackColor = c1;
            lblOrderView.ForeColor = c2;

        }

        DisplayDirectionLabel(orderHeaderText);

    }










    internal void DisplayDownButtonText()
    {
        string downString;

        // chrString = ChrW(&HDACE)
        downString = "Down";
        btnDown.Text = downString;

    }

    private void DisplayUpButtonText()
    {
        string upString;

        upString = "Up";
        btnUp.Text = upString;

    }

    private void DisplayDirectionLabel(string orderviewText)
    {

        lblOrderView.Text = orderviewText;

    }

    private void ChangeCheckNumberLabelHit(object sender, EventArgs e)
    {

        UC_Hit?.Invoke();
        if (newlyCreatedCheck == true)
        {
            // this is when we create a check in split check but add no items
            DoWeRemoveNewCheck();
        }

        if (currentTable.NumberOfChecks > 1)
        {
            if (gridByCheck == false)
            {
                gridByCheck = true;
                btnViewTable.Text = "Table";
                currentTable.CheckNumber = 0;    // so we start at # 1
            }
            GotoNextCheckNumber();
            UpdateCheckNumberButton();
            CalculateSubTotal();
            UpdatingViewsByCheck?.Invoke();
        }

    }
    private void DoWeRemoveNewCheck()
    {

        newlyCreatedCheck = false;
        if (dvOrder.Count == 0)
        {
            currentTable.NumberOfChecks -= 1;
            RecalculateCheckNumber(currentTable.ExperienceNumber, -1);
            GotoNextCheckNumber();
        }

    }
    private void btnOrderViewDown_Click(object sender, EventArgs e)
    {

        UC_Hit?.Invoke();
        // ???       RaiseEvent EndOfItem(True)
        // this would be reset to false if no longer req modifier
        // If currentTable.ReqModifier = True Then Exit Sub

        if (OpenOrdersCurrencyMan.Position < gridViewOrder.DataSource.count)
        {
            if (gridViewOrder.DataSource.count - OpenOrdersCurrencyMan.Position > 15)
            {
                OpenOrdersCurrencyMan.Position += 10;
            }
            else if (gridViewOrder.DataSource.count - OpenOrdersCurrencyMan.Position > 10)
            {
                OpenOrdersCurrencyMan.Position += 5;
            }
            else if (gridViewOrder.DataSource.count - OpenOrdersCurrencyMan.Position > 5)
            {
                OpenOrdersCurrencyMan.Position += 2;
            }
            else
            {
                OpenOrdersCurrencyMan.Position += 1;
            }

            gridViewOrder.ScrollToRow(OpenOrdersCurrencyMan.Position);
        }

    }

    private void btnOrderViewUp_Click(object sender, EventArgs e)
    {

        UC_Hit?.Invoke();
        if (OpenOrdersCurrencyMan.Position > 0)
        {
            if (OpenOrdersCurrencyMan.Position - 15 > 0)
            {
                OpenOrdersCurrencyMan.Position -= 15;
            }
            else if (OpenOrdersCurrencyMan.Position - 10 > 0)
            {
                OpenOrdersCurrencyMan.Position -= 10;
            }
            else if (OpenOrdersCurrencyMan.Position - 5 > 0)
            {
                OpenOrdersCurrencyMan.Position -= 5;
            }
            else
            {
                OpenOrdersCurrencyMan.Position -= 1;
            }

            gridViewOrder.ScrollToRow(OpenOrdersCurrencyMan.Position);
        }
    }

    internal void SplitCheckClosed222()
    {


        btnViewTable.Text = "Table";
        UpdateCheckNumberButton();
        CalculateSubTotal();

        gridViewOrder.DataSource = dvOrder;
        currentTable.OrderView = "Detailed Order";

    }

    private void btnStatusClick(object sender, EventArgs e)
    {

        UC_Hit?.Invoke();
        kitchenCommands.Visible = false;
        ViewStatus.Visible = true;

    }

    internal void CalculateSubTotal()
    {

        var dvByCheck = new DataView();
        decimal UnNamedTabPayments;

        dvByCheck.Table = dsOrder.Tables("OpenOrders");
        dvByCheck.RowFilter = "CheckNumber = '" + currentTable.CheckNumber + "'";

        // If dsOrder.Tables("OpenOrders").Rows.Count > 0 Then
        if (dvByCheck.Count > 0)
        {
            if (gridByCheck == true)
            {
                currentTable.SubTotal = dsOrder.Tables("OpenOrders").Compute("Sum(Price)", "CheckNumber = '" + currentTable.CheckNumber + "'");
                currentTable.SubTax = dsOrder.Tables("OpenOrders").Compute("Sum(TaxPrice)+ SUM(SinTax)", "CheckNumber = '" + currentTable.CheckNumber + "'");
            }
            else
            {
                currentTable.SubTotal = dsOrder.Tables("OpenOrders").Compute("Sum(Price)", "");
                currentTable.SubTax = dsOrder.Tables("OpenOrders").Compute("Sum(TaxPrice)+ SUM(SinTax)", "");
            }
        }
        else
        {
            currentTable.SubTotal = 0;
            currentTable.SubTax = 0;
        }

        totalOrder.Text = Strings.Format(currentTable.SubTotal + currentTable.SubTax, "##,###.00");
        totalOrderTax.Text = Strings.Format(currentTable.SubTax, "##,###.00");
        if (currentTable.IsClosed == true)
        {
            totalOrder.BackColor = c7;
            totalOrderTax.BackColor = c7;
        }
        else
        {
            totalOrder.BackColor = c3;
            totalOrderTax.BackColor = c3;
        }
        // If currentTable.TabID < 0 Then
        // for unNamedSubTotal
        // If gridByCheck = True Then
        // UnNamedTabPayments = dsOrder.Tables("PaymentsAndCredits").Compute("Sum(PaymentAmount)", "CheckNumber = '" & currentTable.CheckNumber & "'")
        // Else
        // UnNamedTabPayments = dsOrder.Tables("PaymentsAndCredits").Compute("Sum(PaymentAmount)", "")
        // End If
        // currentTable.SubTotal -= UnNamedTabPayments
        // End If

    }



    // this is for HOLD ALL ITEMS
    // not used currently

    private void PlaceItemOnHold222(int rowNum, int valueSIN)
    {
        var newStatus = default(int);

        // DataSource may be either dtOrder or specific DataViews
        // so the testing is done on the same information(view)
        if (object.ReferenceEquals(gridViewOrder.DataSource, dsOrder.Tables("OpenOrders")))
        {
            dvOrder = new DataView(dsOrder.Tables("OpenOrders"));
            // might have to add cuurenttable.orderview = "dvOrder"
        }

        if (dvOrder[rowNum]("ItemStatus") == 0)
        {
            newStatus = 1;
        }
        else if (dvOrder[rowNum]("ItemStatus") == 1)
        {
            newStatus = 0;
        }
        else if (dvOrder[rowNum]("ItemStatus") == 2)
        {
            return;
        }
        else if (dvOrder[rowNum]("ItemStatus") == 3)
        {
            return;
        }
        else if (dvOrder[rowNum]("ItemStatus") == 4)
        {
            return;
        }

        foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("sii") == valueSIN)
                {
                    oRow("ItemStatus") = newStatus;
                }
            }
        }

    }

    private void btnSendClick(object sender, EventArgs e)
    {

        // 444     RaiseEvent EndingItem(False)
        // this would be reset to false if no longer req modifier
        // 444     If currentTable.ReqModifier = True Then Exit Sub

        SendOrder?.Invoke(true);

    }

    private void btnLeaveClick(object sender, EventArgs e)
    {
        UC_Hit?.Invoke();

        if (newlyCreatedCheck == true)
        {
            // this is when we create a check in split check but add no items
            DoWeRemoveNewCheck();
        }
        EndingItem?.Invoke(false);
        // this would be reset to false if no longer req modifier
        if (currentTable.ReqModifier == true)
            return;

        LeaveOrderView?.Invoke();
    }


}