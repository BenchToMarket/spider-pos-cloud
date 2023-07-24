using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;


public partial class CheckTotal_UC : System.Windows.Forms.UserControl
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
                _btnDown.Click -= btnCloseViewDown_Click;
            }

            _btnDown = value;
            if (_btnDown != null)
            {
                _btnDown.Click += btnCloseViewDown_Click;
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
                _btnUp.Click -= btnCloseViewUp_Click;
            }

            _btnUp = value;
            if (_btnUp != null)
            {
                _btnUp.Click += btnCloseViewUp_Click;
            }
        }
    }

    internal OrderGrid grdCloseCheck;
    private CurrencyManager ClosingCheckCurrencyMan;

    private int[] taxIDInteger;
    internal string[] taxName;
    internal decimal chkSubTotal;
    internal decimal[] taxTotal;

    internal decimal checkTax;
    internal decimal checkSinTax;
    internal decimal chkFood;
    internal decimal chkDrinks;
    private bool _autoGratuity;
    private decimal autoGratuityAmount;


    private decimal remainingBalance;
    private decimal _totalCheckBalance;
    private bool CashPaymentTendered;

    internal bool AutoGratuity
    {
        get
        {
            return _autoGratuity;
        }
        set
        {
            _autoGratuity = value;
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

    #region  Windows Form Designer generated code 

    public CheckTotal_UC() : base()
    {
        grdCloseCheck = new OrderGrid();

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
    private IContainer components;

    // NOTE: The following procedure is required by the Windows Form Designer
    // It can be modified using the Windows Form Designer.  
    // Do not modify it using the code editor.
    private Global.System.Windows.Forms.ListView _lstCloseCheckTotals;

    internal virtual Global.System.Windows.Forms.ListView lstCloseCheckTotals
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lstCloseCheckTotals;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lstCloseCheckTotals = value;
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _clmCheckTotalName;

    internal virtual Global.System.Windows.Forms.ColumnHeader clmCheckTotalName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _clmCheckTotalName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _clmCheckTotalName = value;
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _clmCheckTotalAmount;

    internal virtual Global.System.Windows.Forms.ColumnHeader clmCheckTotalAmount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _clmCheckTotalAmount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _clmCheckTotalAmount = value;
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _lstCloseCheckTotals = new System.Windows.Forms.ListView();
        _clmCheckTotalName = new System.Windows.Forms.ColumnHeader();
        _clmCheckTotalAmount = new System.Windows.Forms.ColumnHeader();
        this.SuspendLayout();
        // 
        // lstCloseCheckTotals
        // 
        _lstCloseCheckTotals.BackColor = System.Drawing.SystemColors.WindowText;
        _lstCloseCheckTotals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { _clmCheckTotalName, _clmCheckTotalAmount });
        _lstCloseCheckTotals.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _lstCloseCheckTotals.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        _lstCloseCheckTotals.Location = new System.Drawing.Point(0, 520);
        _lstCloseCheckTotals.Name = "_lstCloseCheckTotals";
        _lstCloseCheckTotals.Size = new System.Drawing.Size(310, 136);
        _lstCloseCheckTotals.TabIndex = 11;
        _lstCloseCheckTotals.View = System.Windows.Forms.View.Details;
        // 
        // clmCheckTotalName
        // 
        _clmCheckTotalName.Text = "";
        _clmCheckTotalName.Width = 220;
        // 
        // clmCheckTotalAmount
        // 
        _clmCheckTotalAmount.Text = "";
        _clmCheckTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        _clmCheckTotalAmount.Width = 70;
        // 
        // CheckTotal_UC
        // 
        this.Controls.Add(_lstCloseCheckTotals);
        this.Name = "CheckTotal_UC";
        this.Size = new System.Drawing.Size(310, 656);
        this.ResumeLayout(false);

    }

    #endregion


    private void InitializeOther()
    {

        ClosingCheckCurrencyMan = this.BindingContext(dsOrder.Tables("OpenOrders"));

        if (currentTable.AutoGratuity > 0)
        {
            _autoGratuity = true;
        }

        DisplayDirectionPanel();
        DisplayCloseGrid();
        PopulateCloseGrid(ref dvOrder); // dvClosingCheck)


        AddGridCloseCheckColumns();
        CalculatePriceAndTax(currentTable.CheckNumber);
        // AttachTotalsToTotalView()

    }

    private void DisplayDirectionPanel()
    {
        float dirHeight;
        float dirButtonWidth;

        pnlDirection = new Panel();
        btnDown = new Button();
        btnUp = new Button();

        dirHeight = 40f;  // Me.Height * 0.04
        dirButtonWidth = this.Width / 2;

        pnlDirection.Location = new Point(0, 0);
        pnlDirection.Size = new Size(this.Width, dirHeight);
        pnlDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);

        btnDown.Location = new Point(0, 0);
        btnUp.Location = new Point(dirButtonWidth, 0);

        btnDown.Size = new Size(dirButtonWidth, dirHeight);
        btnUp.Size = new Size(dirButtonWidth, dirHeight);

        btnDown.BackColor = c6;
        btnUp.BackColor = c6;
        // Me.btnDown.BackgroundImage = CType(Resources.GetObject("pnlMgrByItem.BackgroundImage"), System.Drawing.Image)

        btnDown.ForeColor = c3;
        btnUp.ForeColor = c3;

        btnDown.TextAlign = ContentAlignment.BottomCenter;
        btnUp.TextAlign = ContentAlignment.TopCenter;

        btnDown.Text = "Down";
        btnUp.Text = "Up";

        pnlDirection.Controls.Add(btnDown);
        pnlDirection.Controls.Add(btnUp);
        this.Controls.Add(pnlDirection);

    }


    private void DisplayCloseGrid()
    {


        // gridview
        grdCloseCheck.Location = new Point(0, pnlDirection.Height);
        grdCloseCheck.Size = new Size(this.Width + 1, 496); // (Me.Height * 0.63))
        grdCloseCheck.BackgroundColor = c2;
        grdCloseCheck.ForeColor = c14;
        grdCloseCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);

        grdCloseCheck.ReadOnly = true;
        grdCloseCheck.Controls(0).Height = 0;
        grdCloseCheck.Controls(1).Width = 0;

        grdCloseCheck.ColumnHeadersVisible = false;
        grdCloseCheck.RowHeadersVisible = false;
        grdCloseCheck.CaptionVisible = false;
        // grdCloseCheck.DataSource = dvClosingCheck
        grdCloseCheck.SelectionBackColor = Color.Blue;
        grdCloseCheck.AllowSorting = false;


        this.Controls.Add(grdCloseCheck);


    }

    internal void PopulateCloseGrid(ref DataView dvDisplay)
    {

        grdCloseCheck.DataSource = dvDisplay;

    }



    private void AddGridCloseCheckColumns()
    {

        DataRow oRow;

        // For Each oRow In dsOrder.Tables("OpenOrders").Rows
        // MsgBox(oRow("ItemStatus"))
        // MsgBox(oRow("sin"))
        // MsgBox(oRow("ItemName"))
        // Next

        var tsOrder = new DataGridTableStyle();
        tsOrder.MappingName = "OpenOrders";
        tsOrder.RowHeadersVisible = false;
        tsOrder.GridLineStyle = DataGridLineStyle.None;

        var csStatus = new DataGridTextBoxColumn();
        csStatus.MappingName = "ItemStatus";
        csStatus.Width = 0;  // 0.08 * viewOrderWidth

        var csSIN = new DataGridTextBoxColumn();
        csSIN.MappingName = "sin";
        csSIN.Width = 0;

        var csSII = new DataGridTextBoxColumn();
        csSII.MappingName = "sii";
        csSII.Width = 0;

        var csItemName = new OrderCloseGridColumn();  // DataGridTextBoxColumn 'OrderGridColumn(False, False) '
        csItemName.MappingName = "TerminalName"; // "ItemName"
        csItemName.Width = 0.8d * this.Width;  // viewOrderWidth

        var csItemCost = new OrderCloseGridColumn();  // DataGridTextBoxColumn 'OrderGridColumn(True, False)  '
        csItemCost.MappingName = "Price";
        csItemCost.Width = 0.17d * this.Width; // viewOrderWidth
        csItemCost.Alignment = HorizontalAlignment.Right;

        tsOrder.GridColumnStyles.Add(csStatus);
        tsOrder.GridColumnStyles.Add(csSIN);
        tsOrder.GridColumnStyles.Add(csSII);
        tsOrder.GridColumnStyles.Add(csItemName);
        tsOrder.GridColumnStyles.Add(csItemCost);
        grdCloseCheck.TableStyles.Add(tsOrder);

    }

    internal void CalculatePriceAndTax(int cn) // View
    {
        int index;
        taxIDInteger = new int[ds.Tables("Tax").Rows.Count + 1];
        taxName = new string[ds.Tables("Tax").Rows.Count + 1];
        taxTotal = new decimal[ds.Tables("Tax").Rows.Count + 1];
        _totalCheckBalance = 0m;
        chkSubTotal = 0m;
        checkTax = 0m;
        checkSinTax = 0m;
        chkFood = 0m;
        chkDrinks = 0m;

        taxName[0] = "Tax";
        index = 1;

        foreach (DataRow oRow in ds.Tables("Tax").Rows)
        {
            taxIDInteger[index] = oRow("TaxID");
            taxName[index] = oRow("TaxName");
            // taxTotal(index) = Format(0, "###0.00")
            foreach (DataRow vRow in dsOrder.Tables("OpenOrders").Rows) // dvOrder 'dvClosingCheck
            {
                if (!(vRow.RowState == DataRowState.Deleted) & !(vRow.RowState == DataRowState.Detached))
                {
                    if (index == 0)
                    {
                        // we loop through this for every tax category
                        // so we only add this 1 time
                        _totalCheckBalance += vRow("Price") + vRow("TaxPrice") + vRow("SinTax");
                    }
                }
                if (!(vRow.RowState == DataRowState.Deleted) & !(vRow.RowState == DataRowState.Detached))
                {
                    if (vRow("CheckNumber") == cn) // currentTable.CheckNumber Then
                    {
                        if (vRow("TaxID") == taxIDInteger[index])
                        {
                            chkSubTotal = chkSubTotal + vRow("Price");
                            taxTotal[0] = taxTotal[0] + vRow("TaxPrice"); // taxTotal(index) + (vRow("Price") * oRow("TaxPercent"))
                            taxTotal[index] = taxTotal[index] + vRow("SinTax"); // taxTotal(index) + (vRow("Price") * oRow("TaxPercent"))

                            if (vRow("FunctionFlag") == "F" | vRow("FunctionFlag") == "O" | vRow("FunctionFlag") == "M")
                            {
                                chkFood += vRow("Price");
                            }
                            else if (vRow("FunctionFlag") == "D")
                            {
                                chkDrinks += vRow("Price");
                            }
                        }
                    }
                }

            }
            taxTotal[index] = Conversions.ToDecimal(Strings.Format(taxTotal[index], "###0.00"));
            checkSinTax += taxTotal[index];
            index += 1;
        }

        taxTotal[0] = Conversions.ToDecimal(Strings.Format(taxTotal[0], "###0.00"));
        checkTax += taxTotal[0];

        currentTable.SubTotal = chkSubTotal;

    }

    internal object AttachTotalsToTotalView(int cn)
    {
        lstCloseCheckTotals.Items.Clear();

        DataRow oRow;
        int index;
        bool isTaxExempt = false;
        var taxExemptAmount = default(decimal);

        decimal chkTotalAmount = chkSubTotal;

        var itemSubTotal = new ListViewItem();
        itemSubTotal.Text = "SubTotal";
        itemSubTotal.SubItems.Add(chkSubTotal);
        lstCloseCheckTotals.Items.Add(itemSubTotal);

        foreach (DataRow currentORow in dsOrder.Tables("OpenOrders").Rows)
        {
            oRow = currentORow;
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("CheckNumber") == cn) // currentTable.CheckNumber Then
                {
                    if (oRow("TaxID") == -1)  // taxIDInteger(index) = -1 Then
                    {
                        isTaxExempt = true;
                        taxExemptAmount += oRow("Price");
                    }
                    // index += 1
                }
            }
        }

        if (isTaxExempt == true & taxTotal[0] == 0m)
        {
            // this is the whole check is exempt
            taxName[0] = "Tax Exempt: $" + taxExemptAmount;
        }

        // If taxTotal(0) > 0 Then
        chkTotalAmount = chkTotalAmount + taxTotal[0];
        var itemTax0 = new ListViewItem();
        itemTax0.Text = taxName[0];
        itemTax0.SubItems.Add(taxTotal[0]);
        // itemTax0.SubItems.Add(taxIDInteger(0))

        lstCloseCheckTotals.Items.Add(itemTax0);
        // End If

        index = 1;
        foreach (DataRow currentORow1 in ds.Tables("Tax").Rows)
        {
            oRow = currentORow1;
            if (oRow("TaxID") == -1)
            {
                if (isTaxExempt == true & taxTotal[0] > 0m)
                {
                    // his means only some items are tax exempt
                    var itemTax = new ListViewItem();
                    itemTax.Text = "Tax Exempt: $" + taxExemptAmount;
                    itemTax.SubItems.Add(0); // taxTotal(index))
                    lstCloseCheckTotals.Items.Add(itemTax);
                }
            }
            else if (taxTotal[index] > 0m)
            {
                chkTotalAmount = chkTotalAmount + taxTotal[index];
                var itemTax = new ListViewItem();
                itemTax.Text = taxName[index] + " Tax";
                itemTax.SubItems.Add(taxTotal[index]);
                lstCloseCheckTotals.Items.Add(itemTax);
            }
            index += 1;
        }

        // *** need to do in the database so it saves the auto gratuity
        if (AutoGratuity == true)
        {
            var itemGratuity = new ListViewItem();
            itemGratuity.Text = "Gratuity " + Strings.Format(companyInfo.autoGratuityPercent * 100, "##0").ToString + "%";
            // this should be calculated by NON-Tax amount
            // but when we swipe credit card it does not know ow much tax going to each card, 
            // who would know what each person is buying unless spilt checks
            // autoGratuityAmount = Format((chkSubTotal * companyInfo.autoGratuityPercent), "####.00")
            autoGratuityAmount = Conversions.ToDecimal(Strings.Format(chkTotalAmount * companyInfo.autoGratuityPercent, "####.00"));
            itemGratuity.SubItems.Add(autoGratuityAmount);
            lstCloseCheckTotals.Items.Add(itemGratuity);
            // 444        chkTotalAmount = chkSubTotal + autoGratuityAmount
        }


        var itemTotal = new ListViewItem();
        itemTotal.Text = "Total";
        itemTotal.SubItems.Add(chkTotalAmount);
        lstCloseCheckTotals.Items.Add(itemTotal);

        remainingBalance = chkTotalAmount;

        var cashAmount = default(decimal);

        foreach (DataRow currentORow2 in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            oRow = currentORow2;
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("Applied") == true & oRow("CheckNumber") == cn) // currentTable.CheckNumber Then
                {
                    if (oRow("PaymentTypeID") == 1)   // 444 Flag") = "Cash" Then
                    {
                        cashAmount = cashAmount + oRow("PaymentAmount") * -1;
                    }
                    else
                    {
                        var itemPayment = new ListViewItem();
                        itemPayment.Text = DisplayPaymentType(oRow("PaymentTypeID"));
                        itemPayment.SubItems.Add(oRow("PaymentAmount") * -1);
                        lstCloseCheckTotals.Items.Add(itemPayment);
                    }
                    remainingBalance -= oRow("PaymentAmount");
                }
            }
        }

        if (cashAmount < 0m)
        {
            var itemPayment = new ListViewItem();
            itemPayment.Text = "Cash Tender";
            itemPayment.SubItems.Add(cashAmount);
            lstCloseCheckTotals.Items.Add(itemPayment);
            CashPaymentTendered = true;
        }

        return remainingBalance;

    }

    private object DisplayPaymentType(int payID)
    {
        var payName = default(string);

        foreach (DataRow oRow in ds.Tables("CreditCardDetail").Rows)
        {
            if (oRow("PaymentTypeID") == payID)
            {
                payName = oRow("PaymentTypeName");
                break;
            }
        }

        return payName;

    }

    private void btnCloseViewDown_Click(object sender, EventArgs e)
    {

        if (ClosingCheckCurrencyMan.Position < grdCloseCheck.DataSource.count)
        {
            // If Me.gridViewOrder.DataSource.count - Me.OpenOrdersCurrencyMan.Position > 15 Then
            // Me.OpenOrdersCurrencyMan.Position += 10
            // ElseIf Me.gridViewOrder.DataSource.count - Me.OpenOrdersCurrencyMan.Position > 10 Then
            // Me.OpenOrdersCurrencyMan.Position += 5
            // ElseIf Me.gridViewOrder.DataSource.count - Me.OpenOrdersCurrencyMan.Position > 5 Then
            // Me.OpenOrdersCurrencyMan.Position += 2
            // '     Else
            ClosingCheckCurrencyMan.Position += 1;
            // End If

            grdCloseCheck.ScrollToRow(ClosingCheckCurrencyMan.Position);
        }

    }

    private void btnCloseViewUp_Click(object sender, EventArgs e)
    {

        if (ClosingCheckCurrencyMan.Position > 0)
        {
            if (ClosingCheckCurrencyMan.Position - 15 > 0)
            {
                ClosingCheckCurrencyMan.Position -= 15;
            }
            else if (ClosingCheckCurrencyMan.Position - 10 > 0)
            {
                ClosingCheckCurrencyMan.Position -= 10;
            }
            else if (ClosingCheckCurrencyMan.Position - 5 > 0)
            {
                ClosingCheckCurrencyMan.Position -= 5;
            }
            else
            {
                ClosingCheckCurrencyMan.Position -= 1;
            }

            grdCloseCheck.ScrollToRow(ClosingCheckCurrencyMan.Position);
        }
    }


}