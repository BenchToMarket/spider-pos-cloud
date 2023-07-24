using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;


public partial class SplitGridPanel : System.Windows.Forms.UserControl
{

    // Dim sql As New DataSet_Builder.SQLHelper(connectserver)


    private ListBox _splitGrid;

    internal virtual ListBox splitGrid
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _splitGrid;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_splitGrid != null)
            {
                _splitGrid.MouseDown -= ListDragSource_MouseDown;
                _splitGrid.MouseMove -= ListDragSource_MouseMove;
                _splitGrid.DragOver -= ListDragTarget_DragOver;
                _splitGrid.DragDrop -= ListDragTarget_DragDrop;
                _splitGrid.QueryContinueDrag -= ListDragSource_QueryContinueDrag;
                _splitGrid.Click -= SplitGrid_Click;
            }

            _splitGrid = value;
            if (_splitGrid != null)
            {
                _splitGrid.MouseDown += ListDragSource_MouseDown;
                _splitGrid.MouseMove += ListDragSource_MouseMove;
                _splitGrid.DragOver += ListDragTarget_DragOver;
                _splitGrid.DragDrop += ListDragTarget_DragDrop;
                _splitGrid.QueryContinueDrag += ListDragSource_QueryContinueDrag;
                _splitGrid.Click += SplitGrid_Click;
            }
        }
    }
    private Button _btnSelectCheck;

    internal virtual Button btnSelectCheck
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnSelectCheck;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnSelectCheck != null)
            {
                _btnSelectCheck.Click -= btnSelect_Click;
            }

            _btnSelectCheck = value;
            if (_btnSelectCheck != null)
            {
                _btnSelectCheck.Click += btnSelect_Click;
            }
        }
    }
    private Button _btnCloseCheck;

    internal virtual Button btnCloseCheck
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCloseCheck;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCloseCheck != null)
            {
                _btnCloseCheck.Click -= btnClose_Click;
            }

            _btnCloseCheck = value;
            if (_btnCloseCheck != null)
            {
                _btnCloseCheck.Click += btnClose_Click;
            }
        }
    }
    internal Label lblRemainingBalance;
    internal TextBox txtRemainingBalance;

    private DataView dvSplitCheck;
    private DataView dvSplitCheckPrices;
    private DataView dvPaymentsAndCreditsSplit;

    private decimal checkTotal;
    private decimal paymentTotal;
    internal decimal remainingBalance;

    private int indexOfItemUnderMouseToDrag;
    private int indexOfItemUnderMouseToDrop;

    private Rectangle dragBoxFromMouseDown;
    private Point screenOffset;

    private Cursor MyNoDropCursor;
    private Cursor MyNormalCursor;

    private int _checkIndex;
    private int _totalGrids;
    private int totalRows;
    private int totalColumns;
    private string _selectedItemName;
    private float gridWidth;
    private float gridHeight;




    internal int CheckIndex
    {
        get
        {
            return _checkIndex;
        }
        set
        {
            _checkIndex = value;
        }
    }

    internal int TotalGrids
    {
        get
        {
            return _totalGrids;
        }
        set
        {
            _totalGrids = value;
        }
    }

    internal string SelectedItemName
    {
        get
        {
            return _selectedItemName;
        }
        set
        {
            _selectedItemName = value;
        }
    }

    internal int SIN_Split
    {
        get
        {
            return sinDragSource;
        }
        set
        {
            sinDragSource = value;
        }
    }

    public event GridMouseDownEventHandler GridMouseDown;

    public delegate void GridMouseDownEventHandler(object sender, MouseEventArgs e);
    public event GridMouseUpEventHandler GridMouseUp;

    public delegate void GridMouseUpEventHandler(object sender, MouseEventArgs e);
    public event GridMouseMoveEventHandler GridMouseMove;

    public delegate void GridMouseMoveEventHandler(object sender, MouseEventArgs e);
    public event GridDragOverEventHandler GridDragOver;

    public delegate void GridDragOverEventHandler(object sender, DragEventArgs e);
    public event GridDragDropEventHandler GridDragDrop;

    public delegate void GridDragDropEventHandler(object sender, DragEventArgs e);
    public event GridQueryContinueDragEventHandler GridQueryContinueDrag;

    public delegate void GridQueryContinueDragEventHandler(object sender, QueryContinueDragEventArgs e);
    public event ButtonSelectClickEventHandler ButtonSelectClick;

    public delegate void ButtonSelectClickEventHandler(object sender, EventArgs e);
    public event ButtonCloseClickEventHandler ButtonCloseClick;

    public delegate void ButtonCloseClickEventHandler(object sender, EventArgs e);
    public event ItemSelectedEventHandler ItemSelected;

    public delegate void ItemSelectedEventHandler(object sender, EventArgs e);
    public event ResetTimerFromPanelEventHandler ResetTimerFromPanel;

    public delegate void ResetTimerFromPanelEventHandler();

    #region  Windows Form Designer generated code 

    public SplitGridPanel(int gridNumber, int tg) : base()
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        _checkIndex = gridNumber;
        _totalGrids = tg;
        if (TotalGrids == 4)
        {
            totalRows = 1;
            totalColumns = 4;
        }
        else
        {
            totalRows = 2;
            totalColumns = 5;
        }

        InitializeOther(gridNumber);
        CreateSplitDataView(gridNumber);


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
        // SplitGridPanel
        // 
        this.Name = "SplitGridPanel";
        this.Size = new System.Drawing.Size(264, 336);

    }

    #endregion

    private void InitializeOther(int gridnumber)
    {
        float width = (ssX - 60) / totalColumns;
        float height = (ssY - 80) / totalRows;
        float splitSpace = 10f;
        var x = default(float);
        var y = default(float);
        float btnWidth = (float)((double)width * 0.44d);
        float btnHeight = 45f;    // 0.1 * height
        float btnSelectX = (float)((double)width * 0.04d); // btnWidth / 3
        float btnRemoveX = (float)((double)width * 0.08d + (double)btnWidth); // (btnWidth * (2 / 3)) + btnWidth
        float btnLocationY = height - 50f; // height * 0.85
        float balanceLocationY = height - 80f;   // height * 0.75

        if (gridnumber < 6)
        {
            x = (splitSpace + width) * gridnumber - width;
            y = splitSpace;
        }
        else if (gridnumber < 11)
        {
            x = (splitSpace + width) * (gridnumber - 5) - width;
            y = 2f * splitSpace + height;
        }

        // Dim panelString = "splitGridPanel" & gridNumber
        // Dim gridString = "splitGrid" & gridNumber


        splitGrid = new ListBox();
        lblRemainingBalance = new Label();
        txtRemainingBalance = new TextBox();
        btnSelectCheck = new Button();
        btnCloseCheck = new Button();

        this.Size = new Size(width, height);
        this.Location = new Point(x, y);
        this.BackColor = c2; // c6

        splitGrid.Size = new Size((double)width * 0.98d, height - 85f); // * 0.75)
        splitGrid.Location = new Point((double)width * 0.01d, (double)height * 0.01d);
        if (TotalGrids == 4)
        {
            splitGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        }
        else
        {
            splitGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        }
        splitGrid.BackColor = c2;
        splitGrid.AllowDrop = true;
        splitGrid.BorderStyle = BorderStyle.Fixed3D;
        splitGrid.ForeColor = c3;

        // 444 tried to make a larger move area
        // Dim r As Rectangle
        // r.Height = 100
        // splitGrid.RectangleToClient(r)

        lblRemainingBalance.Size = new Size(btnWidth, btnHeight / 2f);
        lblRemainingBalance.Location = new Point(btnSelectX, balanceLocationY);
        lblRemainingBalance.ForeColor = c1;

        txtRemainingBalance.Size = new Size(btnWidth, btnHeight / 2f);
        txtRemainingBalance.Location = new Point(btnRemoveX, balanceLocationY);
        txtRemainingBalance.TextAlign = HorizontalAlignment.Right;

        btnSelectCheck.Size = new Size(btnWidth, btnHeight);
        btnSelectCheck.Location = new Point(btnSelectX, btnLocationY);
        btnSelectCheck.BackColor = c6;
        btnSelectCheck.ForeColor = c3;

        btnCloseCheck.Size = new Size(btnWidth, btnHeight);
        btnCloseCheck.Location = new Point(btnRemoveX, btnLocationY);
        btnCloseCheck.BackColor = c6;
        btnCloseCheck.ForeColor = c3;


        lblRemainingBalance.Text = "Balance: ";

        this.Controls.Add(splitGrid);
        this.Controls.Add(lblRemainingBalance);
        this.Controls.Add(txtRemainingBalance);
        this.Controls.Add(btnSelectCheck);
        this.Controls.Add(btnCloseCheck);

        dvSplitCheck = new DataView();
        dvSplitCheckPrices = new DataView();
        dvPaymentsAndCreditsSplit = new DataView();


    }



    internal void CreateSplitDataView(int gridNumber)
    {

        // 444     dvSplitCheck = New DataView

        splitGrid.Items.Clear();
        // Dim itemPanel As Label            tried to create a label to grab but did not work


        {
            ref var withBlock = ref dvSplitCheck;
            withBlock.Table = dsOrder.Tables("OpenOrders");
            withBlock.RowFilter = "CheckNumber = '" + gridNumber + "' AND sii = sin";
            withBlock.RowStateFilter = DataViewRowState.CurrentRows;
            withBlock.Sort = "CustomerNumber, sin";
        }


        foreach (DataRowView vRow in dvSplitCheck)
            // itemPanel = New Label
            // With itemPanel
            // .Size = New Size(splitGrid.Width, 75)
            // .BackColor = c9
            // End With
            // 
            // itemPanel.Text = (vRow("ItemName"))
            // splitGrid.Items.Add(itemPanel)

            splitGrid.Items.Add(vRow("ItemName"));

        // 444      dvSplitCheckPrices = New DataView

        {
            ref var withBlock1 = ref dvSplitCheckPrices;
            withBlock1.Table = dsOrder.Tables("OpenOrders");
            withBlock1.RowFilter = "CheckNumber = '" + gridNumber + "'";
            withBlock1.RowStateFilter = DataViewRowState.CurrentRows;
            // .Sort = "CustomerNumber, sin"
        }

        // 444      dvPaymentsAndCreditsSplit = New DataView

        {
            ref var withBlock2 = ref dvPaymentsAndCreditsSplit;
            withBlock2.Table = dsOrder.Tables("PaymentsAndCredits");
            withBlock2.RowFilter = "CheckNumber = '" + gridNumber + "'";
            withBlock2.RowStateFilter = DataViewRowState.CurrentRows;
            // .Sort = "CustomerNumber, sin"
        }

        CalculatePriceTaxAndRemaining();
        DisplayButtonText();


    }

    internal void CalculatePriceTaxAndRemaining()
    {
        DataRowView vRow;
        checkTotal = 0m;
        paymentTotal = 0m;

        foreach (DataRowView currentVRow in dvSplitCheckPrices)
        {
            vRow = currentVRow;
            checkTotal += vRow("Price");
            checkTotal += vRow("TaxPrice");
            checkTotal += vRow("SinTax");
        }

        foreach (DataRowView currentVRow1 in dvPaymentsAndCreditsSplit)
        {
            vRow = currentVRow1;
            if (vRow("Applied") == true)
            {
                paymentTotal += vRow("PaymentAmount");
            }
        }

        checkTotal = Conversions.ToDecimal(Strings.Format(checkTotal, "####0.00"));
        paymentTotal = Conversions.ToDecimal(Strings.Format(paymentTotal, "####0.00"));
        remainingBalance = checkTotal - paymentTotal;

        txtRemainingBalance.Text = remainingBalance;

        // MsgBox(checkTotal, , "CheckTotal")
        // MsgBox(paymentTotal, , "Payment")
        // MsgBox(remainingBalance, , "Remain")


    }

    private void DisplayButtonText()
    {
        if (dvSplitCheck.Count == 0)
        {
            btnSelectCheck.Text = "Create";
            btnCloseCheck.Text = "";
        }
        else
        {
            btnSelectCheck.Text = "Select";
            btnCloseCheck.Text = "Close";
        }

        // Dim maxCN As Integer
        // maxCN = (dsOrder.Tables("OpenOrders")).Compute("Max(CheckNumber)", Nothing)

        // If CheckIndex > maxCN Then                'currentTable.NumberOfChecks Then
        // btnSelectCheck.Text = "Create"
        // Else
        // If Me.dvSplitCheck.Count = 0 Then
        // btnSelectCheck.Text = "Create"
        // '                btnSelectCheck.Text = "Select"
        // '               btnCloseCheck.Text = "Remove"
        // Else
        // btnSelectCheck.Text = "Select"
        // btnCloseCheck.Text = "Close"
        // End If
        // End If

    }

    private void ListDragSource_MouseDown(object sender, MouseEventArgs e)
    {
        ResetTimerFromPanel?.Invoke();

        // Get the index of the item the mouse is below.
        indexOfItemUnderMouseToDrag = splitGrid.IndexFromPoint(e.X, e.Y);

        // *** having problems if we move an item away from its customer panel
        // then we move the panel.. program places all customer items with 
        // panel but does not remove items from other panel
        try
        {
            if (indexOfItemUnderMouseToDrag != ListBox.NoMatches)
            {

                // not sure if this should be before above stmt?
                sinDragSource = this.dvSplitCheck(indexOfItemUnderMouseToDrag)("sin");

                // this determines if we are selecting a customer panel
                // if yes, we place the customer number in memory
                // if not, we assign 0
                foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
                {
                    if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                    {
                        if (oRow("sin") == sinDragSource)
                        {
                            if (oRow("ItemID") == 0)
                            {
                                // is a customer panel
                                movingCustomer = oRow("CustomerNumber");
                            }
                            else
                            {
                                movingCustomer = 0;
                            }
                        }
                    }
                }

                // for split checks name only
                _selectedItemName = this.dvSplitCheck(indexOfItemUnderMouseToDrag)("ItemName");

                // ******           RaiseEvent ItemSelected(Me, e) 'sinDragSource, e)

                // Remember the point where the mouse down occurred. The DragSize indicates
                // the size that the mouse can move before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - dragSize.Width / 2, e.Y - dragSize.Height / 2), dragSize);
            }
            else
            {
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
            }

            GridMouseDown?.Invoke(sender, e);
        }
        catch (Exception ex)
        {

        }


    }


    private void ListDragSource_MouseMove(object sender, MouseEventArgs e)
    {

        if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
        {

            // If the mouse moves outside the rectangle, start the drag.
            if (Rectangle.op_Inequality(dragBoxFromMouseDown, Rectangle.Empty) & !dragBoxFromMouseDown.Contains(e.X, e.Y))
            {


                // The screenOffset is used to account for any desktop bands 
                // that may be at the top or left side of the screen when 
                // determining when to cancel the drag drop operation.
                screenOffset = SystemInformation.WorkingArea.Location;

                // Proceed with the drag and drop, passing in the list item.                    
                DragDropEffects dropEffect = splitGrid.DoDragDrop(splitGrid.Items(indexOfItemUnderMouseToDrag), DragDropEffects.All | DragDropEffects.Link);

                // If the drag operation was a move then remove the item.
                if (dropEffect == DragDropEffects.Move)
                {
                    splitGrid.Items.RemoveAt(indexOfItemUnderMouseToDrag);

                    // if > 0 then we have selected to move customer panel
                    // and all its order for that customer
                    if (movingCustomer > 0)
                    {
                        CreateSplitDataView(CheckIndex);
                    }

                    CalculatePriceTaxAndRemaining();

                    if (splitGrid.Items.Count == 0)
                    {
                        currentTable.NumberOfChecks -= 1;
                        RecalculateCheckNumber(currentTable.ExperienceNumber, -1);
                    }
                    // Select the previous item in the list as long as the list has an item.
                    if (indexOfItemUnderMouseToDrag > 0)
                    {
                        splitGrid.SelectedIndex = indexOfItemUnderMouseToDrag - 1;
                    }

                    else if (splitGrid.Items.Count > 0)
                    {
                        // Selects the first item.
                        splitGrid.SelectedIndex = 0;
                    }

                }
            }
        }

        GridMouseMove?.Invoke(sender, e);
    }

    private void ListDragTarget_DragOver(object sender, DragEventArgs e)
    {

        // Determine whether string data exists in the drop data. If not, then
        // the drop effect reflects that the drop cannot occur.
        if (!e.Data.GetDataPresent(typeof(string)))
        {

            e.Effect = DragDropEffects.None;
            // DropLocationLabel.Text = "None - no string data."
            return;
        }

        // Set the effect based upon the KeyState.
        if ((e.KeyState & 8 + 32) == 8 + 32 & (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link)
        {
            // KeyState 8 + 32 = CTL + ALT

            // Link drag and drop effect.
            e.Effect = DragDropEffects.Link;
        }

        else if ((e.KeyState & 32) == 32 & (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link)
        {

            // ALT KeyState for link.
            e.Effect = DragDropEffects.Link;
        }

        else if ((e.KeyState & 4) == 4 & (e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
        {

            // SHIFT KeyState for move.
            e.Effect = DragDropEffects.Move;
        }

        else if ((e.KeyState & 8) == 8 & (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
        {

            // CTL KeyState for copy.
            e.Effect = DragDropEffects.Copy;
        }

        else if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
        {

            // By default, the drop action should be move, if allowed.
            e.Effect = DragDropEffects.Move;
        }

        else
        {
            e.Effect = DragDropEffects.None;
        }

        // Gets the index of the item the mouse is below. 

        // The mouse locations are relative to the screen, so they must be 
        // converted to client coordinates.

        indexOfItemUnderMouseToDrop = splitGrid.IndexFromPoint(splitGrid.PointToClient(new Point(e.X, e.Y)));

        // Updates the label text.
        if (indexOfItemUnderMouseToDrop != ListBox.NoMatches)
        {
        }

        // DropLocationLabel.Text = "Drops before item #" & (indexOfItemUnderMouseToDrop + 1)
        else
        {
            // DropLocationLabel.Text = "Drops at the end."
        }

        GridDragOver?.Invoke(sender, e);
    }

    private void ListDragTarget_DragDrop(object sender, DragEventArgs e)
    {
        // Ensures that the list item index is contained in the data.

        // placed here just for a test if we are have errors when moving too fast
        // RemoveHandler splitGrid.MouseDown, AddressOf ListDragSource_MouseDown

        if (e.Data.GetDataPresent(typeof(string)))
        {

            object item = (object)e.Data.GetData(typeof(string));
            checkDragTarget = _checkIndex;

            // Perform drag and drop, depending upon the effect.
            if (e.Effect == DragDropEffects.Copy | e.Effect == DragDropEffects.Move)
            {

                // Insert the item.
                if (indexOfItemUnderMouseToDrop != ListBox.NoMatches)
                {
                    splitGrid.Items.Insert(indexOfItemUnderMouseToDrop, item);
                }
                else
                {
                    splitGrid.Items.Add(item);
                }

                if (splitGrid.Items.Count == 1)
                {
                    currentTable.NumberOfChecks += 1;
                    RecalculateCheckNumber(currentTable.ExperienceNumber, 1);
                    // currentTable.CustomerNumber = CheckIndex
                    currentTable.CheckNumber = CheckIndex;
                }
                // MsgBox("drop before update")
                UpdateCheckNumbersForOrder();
            }
            // MsgBox("drop after update")

            CalculatePriceTaxAndRemaining();

            GridDragDrop?.Invoke(sender, e);
            // AddHandler splitGrid.MouseDown, AddressOf ListDragSource_MouseDown

        }
    }

    private void ListDragSource_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
    {
        // Cancel the drag if the mouse moves off the form.
        ListBox lb = (Global.System.Windows.Forms.ListBox)sender;

        if (lb is not null)
        {

            Form f = lb.FindForm();

            // Cancel the drag if the mouse moves off the form. The screenOffset
            // takes into account any desktop bands that may be at the top or left
            // side of the screen.
            if (Control.MousePosition.X - screenOffset.X < f.DesktopBounds.Left | Control.MousePosition.X - screenOffset.X > f.DesktopBounds.Right | Control.MousePosition.Y - screenOffset.Y < f.DesktopBounds.Top | Control.MousePosition.Y - screenOffset.Y > f.DesktopBounds.Bottom)


            {

                e.Action = DragAction.Cancel;
            }
        }

        GridQueryContinueDrag?.Invoke(sender, e);
    }


    private void UpdateCheckNumbersForOrder()
    {

        if (movingCustomer > 0)
        {
            MoveEntireCustomer(movingCustomer);
        }
        else
        {
            // this is to move just an item with all attachments
            foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
            {
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (oRow("sii") == sinDragSource)
                    {
                        oRow("CheckNumber") = checkDragTarget;
                    }
                }
            }
        }

    }

    private void MoveEntireCustomer(int cn)
    {

        foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("CustomerNumber") == cn)
                {
                    oRow("CheckNumber") = checkDragTarget;
                }
            }
        }

        CreateSplitDataView(checkDragTarget);

    }

    private void btnSelect_Click(object sender, EventArgs e)
    {

        if (dvSplitCheck.Count == 0)   // And CheckIndex > currentTable.NumberOfChecks Then
        {
            currentTable.NumberOfChecks += 1;
            RecalculateCheckNumber(currentTable.ExperienceNumber, 1);
            // currentTable.CustomerNumber = CheckIndex
            currentTable.CheckNumber = CheckIndex;
            newlyCreatedCheck = true;    // we will remove check if no items ordered
        }
        else
        {
            // If btnSelectCheck.Text = "Create" Then
            // '   this is when we have items but have not created the check yet
            // currentTable.NumberOfChecks += 1
            // RecalculateCheckNumber(currentTable.ExperienceNumber, 1)
            // End If
        }

        ButtonSelectClick?.Invoke(CheckIndex, e);

    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        if (splitGrid.Items.Count == 0)
        {
            if (btnCloseCheck.Text == "Remove")
            {
                if (CheckIndex > currentTable.NumberOfChecks)
                {

                }
                currentTable.NumberOfChecks -= 1;
                RecalculateCheckNumber(currentTable.ExperienceNumber, -1);
                btnSelectCheck.Text = "Create";
                btnCloseCheck.Text = "";

                // Else
                // MsgBox("You can not close a empty Check.")
            }
        }
        // Return
        else if (btnCloseCheck.Text == "Close")
        {
            // verifys check was created
            // Dim vRow As DataRowView
            // For Each vRow In dvSplitCheck
            // If vRow("ItemStatus") < 2 Then
            // MsgBox("All Items must be at least Sent to the Kitchen before closing a Check")
            // Return
            // End If
            // Next
            ButtonCloseClick?.Invoke(CheckIndex, e);
        }

    }

    private void SplitGrid_Click(object sender, EventArgs e)
    {

        ItemSelected?.Invoke(this, e);

    }



}