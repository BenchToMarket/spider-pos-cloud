using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DataSet_Builder;

public partial class LastOrder_UC : System.Windows.Forms.UserControl
{

    internal RepeatOrderItemCollection currentRepeatOrderCollection;
    private SelectedItemDetail currentRepeatItem;

    private int _repeatQuantity;
    private string _repeatName;
    private decimal _repeatPrice;
    private int _repeatTaxID;
    private int _repeatFunction;
    private int _itemNumber;
    private bool _forRepeat;
    private long _orderNumber;

    // ********************************
    // not really using these property's 
    // we can get rid of after we no there is no other use

    internal int RepeatQuantity
    {
        get
        {
            return _repeatQuantity;
        }
        set
        {
            _repeatQuantity = value;
        }
    }

    internal string RepeatName
    {
        get
        {
            return _repeatName;
        }
        set
        {
            _repeatName = value;
        }
    }

    internal decimal RepeatPrice
    {
        get
        {
            return _repeatPrice;
        }
        set
        {
            _repeatPrice = value;
        }
    }

    internal int RepeatTaxId
    {
        get
        {
            return _repeatTaxID;
        }
        set
        {
            _repeatTaxID = value;
        }
    }

    internal int RepeatFunction
    {
        get
        {
            return _repeatFunction;
        }
        set
        {
            _repeatFunction = value;
        }
    }

    internal int ItemNumber
    {
        get
        {
            return _itemNumber;
        }
        set
        {
            _itemNumber = value;
        }
    }

    internal long OrderNumber
    {
        get
        {
            return _orderNumber;
        }
        set
        {
            _orderNumber = value;
        }
    }


    public event AcceptRepeatEventHandler AcceptRepeat;

    public delegate void AcceptRepeatEventHandler();
    public event OrderDeliveredEventHandler OrderDelivered;

    public delegate void OrderDeliveredEventHandler();


    #region  Windows Form Designer generated code 

    public LastOrder_UC(bool forRepeat) : base()
    {

        _forRepeat = forRepeat;
        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        if (_forRepeat == false)
        {
            ReshowForOrderDelivery();
        }

        base.Load += Repeat_Load;

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
    private Global.System.Windows.Forms.Button _btnDrinksOnly;

    internal virtual Global.System.Windows.Forms.Button btnDrinksOnly
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDrinksOnly;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _btnDrinksOnly = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnAccept;

    internal virtual Global.System.Windows.Forms.Button btnAccept
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnAccept;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnAccept != null)
            {
                _btnAccept.Click -= btnAccept_Click;
            }

            _btnAccept = value;
            if (_btnAccept != null)
            {
                _btnAccept.Click += btnAccept_Click;
            }
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
    private Global.System.Windows.Forms.ListView _lstRepeat;

    internal virtual Global.System.Windows.Forms.ListView lstRepeat
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lstRepeat;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lstRepeat = value;
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _repeatNameCol;

    internal virtual Global.System.Windows.Forms.ColumnHeader repeatNameCol
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _repeatNameCol;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _repeatNameCol = value;
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _repeatPriceCol;

    internal virtual Global.System.Windows.Forms.ColumnHeader repeatPriceCol
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _repeatPriceCol;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _repeatPriceCol = value;
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _repeatItemIDCol;

    internal virtual Global.System.Windows.Forms.ColumnHeader repeatItemIDCol
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _repeatItemIDCol;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _repeatItemIDCol = value;
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _repeatQuantityCol;

    internal virtual Global.System.Windows.Forms.ColumnHeader repeatQuantityCol
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _repeatQuantityCol;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _repeatQuantityCol = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblLastOrder;

    internal virtual Global.System.Windows.Forms.Label lblLastOrder
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblLastOrder;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblLastOrder = value;
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
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _lblLastOrder = new System.Windows.Forms.Label();
        _Panel1 = new System.Windows.Forms.Panel();
        _lstRepeat = new System.Windows.Forms.ListView();
        _repeatQuantityCol = new System.Windows.Forms.ColumnHeader();
        _repeatNameCol = new System.Windows.Forms.ColumnHeader();
        _repeatPriceCol = new System.Windows.Forms.ColumnHeader();
        _repeatItemIDCol = new System.Windows.Forms.ColumnHeader();
        _btnDrinksOnly = new System.Windows.Forms.Button();
        _btnAccept = new System.Windows.Forms.Button();
        _btnAccept.Click += btnAccept_Click;
        _btnCancel = new System.Windows.Forms.Button();
        _btnCancel.Click += btnCancel_Click;
        _Panel2 = new System.Windows.Forms.Panel();
        _Panel1.SuspendLayout();
        _Panel2.SuspendLayout();
        this.SuspendLayout();
        // 
        // lblLastOrder
        // 
        _lblLastOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblLastOrder.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _lblLastOrder.Location = new System.Drawing.Point(24, 24);
        _lblLastOrder.Name = "_lblLastOrder";
        _lblLastOrder.Size = new System.Drawing.Size(224, 32);
        _lblLastOrder.TabIndex = 0;
        _lblLastOrder.Text = "Repeat the Last Order";
        _lblLastOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.Color.GhostWhite;
        _Panel1.Controls.Add(_lstRepeat);
        _Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Panel1.Location = new System.Drawing.Point(8, 72);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(448, 320);
        _Panel1.TabIndex = 1;
        // 
        // lstRepeat
        // 
        _lstRepeat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { _repeatQuantityCol, _repeatNameCol, _repeatPriceCol, _repeatItemIDCol });
        _lstRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lstRepeat.FullRowSelect = true;
        _lstRepeat.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        _lstRepeat.Location = new System.Drawing.Point(8, 8);
        _lstRepeat.Name = "_lstRepeat";
        _lstRepeat.Size = new System.Drawing.Size(232, 304);
        _lstRepeat.TabIndex = 0;
        _lstRepeat.View = System.Windows.Forms.View.Details;
        // 
        // repeatQuantityCol
        // 
        _repeatQuantityCol.Width = 20;
        // 
        // repeatNameCol
        // 
        _repeatNameCol.Text = "";
        _repeatNameCol.Width = 145;
        // 
        // repeatPriceCol
        // 
        _repeatPriceCol.Text = "";
        _repeatPriceCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        // 
        // repeatItemIDCol
        // 
        _repeatItemIDCol.Text = "";
        _repeatItemIDCol.Width = 0;
        // 
        // btnDrinksOnly
        // 
        _btnDrinksOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnDrinksOnly.ForeColor = System.Drawing.Color.White;
        _btnDrinksOnly.Location = new System.Drawing.Point(288, 16);
        _btnDrinksOnly.Name = "_btnDrinksOnly";
        _btnDrinksOnly.Size = new System.Drawing.Size(160, 40);
        _btnDrinksOnly.TabIndex = 2;
        _btnDrinksOnly.Text = "Drinks Only";
        // 
        // btnAccept
        // 
        _btnAccept.BackColor = System.Drawing.Color.LightSlateGray;
        _btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnAccept.ForeColor = System.Drawing.Color.White;
        _btnAccept.Location = new System.Drawing.Point(40, 400);
        _btnAccept.Name = "_btnAccept";
        _btnAccept.Size = new System.Drawing.Size(144, 64);
        _btnAccept.TabIndex = 3;
        _btnAccept.Text = "Accept";
        // 
        // btnCancel
        // 
        _btnCancel.BackColor = System.Drawing.Color.LightSlateGray;
        _btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnCancel.ForeColor = System.Drawing.Color.White;
        _btnCancel.Location = new System.Drawing.Point(272, 400);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.Size = new System.Drawing.Size(144, 64);
        _btnCancel.TabIndex = 4;
        _btnCancel.Text = "Cancel";
        // 
        // Panel2
        // 
        _Panel2.BackColor = System.Drawing.Color.Black;
        _Panel2.Controls.Add(_Panel1);
        _Panel2.Controls.Add(_btnCancel);
        _Panel2.Controls.Add(_btnAccept);
        _Panel2.Controls.Add(_lblLastOrder);
        _Panel2.Controls.Add(_btnDrinksOnly);
        _Panel2.Location = new System.Drawing.Point(8, 8);
        _Panel2.Name = "_Panel2";
        _Panel2.Size = new System.Drawing.Size(472, 472);
        _Panel2.TabIndex = 5;
        // 
        // LastOrder_UC
        // 
        this.BackColor = System.Drawing.Color.RoyalBlue;
        this.Controls.Add(_Panel2);
        this.Name = "LastOrder_UC";
        this.Size = new System.Drawing.Size(488, 488);
        _Panel1.ResumeLayout(false);
        _Panel2.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private void Repeat_Load(object sender, EventArgs e)
    {
        lstRepeat.Items.Clear();
        currentRepeatOrderCollection = new RepeatOrderItemCollection();

        StartRepeatProcess();

    }

    private void ReshowForOrderDelivery()
    {
        btnAccept.Text = "Delivered";
        btnCancel.Text = "Not Ready";
        lblLastOrder.Text = "Pending Order";
        btnDrinksOnly.Visible = false;

    }
    // Dim oRow As DataRow
    private void StartRepeatProcess()
    {

        foreach (DataRowView vRow in dvRepeat)   // dsOrder.Tables("RepeatOrder").Rows
        {

            // If vRow("Repeat") = True Then
            if (_forRepeat == true & vRow("DrinkID") == 0)
            {
                // this is for the non drinks     '???? just moved up
                vRow("Repeat") = 0;
            }
            else
            {

                currentRepeatItem = new SelectedItemDetail();
                {
                    ref var withBlock = ref currentRepeatItem;
                    withBlock.Name = vRow("ItemName");
                    withBlock.TerminalName = vRow("ItemName");
                    withBlock.ChitName = vRow("ItemName");
                    // .TaxID = vRow("TaxID")
                    withBlock.Check = vRow("CheckNumber");
                    withBlock.Customer = vRow("CustomerNumber");
                    withBlock.Quantity = vRow("Quantity");
                    withBlock.ID = vRow("DrinkID");
                    withBlock.Category = vRow("DrinkCategoryID");
                    withBlock.ItemStatus = 0;
                    withBlock.FunctionID = vRow("FunctionID");
                    withBlock.FunctionGroup = vRow("FunctionGroupID");
                    withBlock.FunctionFlag = vRow("FunctionFlag");
                    withBlock.RoutingID = vRow("RoutingID");
                    withBlock.PrintPriorityID = vRow("PrintPriorityID");
                    withBlock.ItemPrice = vRow("ItemPrice");
                }
                _repeatQuantity = vRow("Quantity");
                _repeatName = vRow("ItemName");

                _repeatFunction = vRow("FunctionID");
                _itemNumber = vRow("DrinkID");

                // _repeatTaxID = vRow("TaxID")
                if (vRow("sin") == vRow("sii"))
                {
                    currentRepeatItem.Price = vRow("Price");
                    _repeatPrice = vRow("Price");
                    PopulateRepeatListView(vRow("DrinkID"));
                }
                // DetermineDrinkMainDetails(vRow("DrinkID"))
                else
                {
                    currentRepeatItem.Price = vRow("Price");
                    currentRepeatItem.SII = -1;
                    _repeatPrice = vRow("Price");
                    _repeatQuantity = default;
                    PopulateRepeatListView(vRow("DrinkID"));
                    // DetermineDrinkModifierDetails(vRow("DrinkID"))
                }
                if (vRow("si2") > 0)
                {
                    currentTable.si2 = vRow("si2");
                }
            }

            // End If

        }


    }

    // ********************'   
    // This is if we wnat to look up previous order original prices
    // and recalculate all info

    private void DetermineDrinkMainDetails222(int itemID)
    {
        _repeatFunction = 4;
        _itemNumber = itemID;

        foreach (DataRow oRow in ds.Tables("Drink").Rows)
        {
            if (oRow("DrinkID") == itemID)
            {
                {
                    ref var withBlock = ref currentRepeatItem;
                    withBlock.Name = oRow("DrinkName");
                    withBlock.TerminalName = oRow("DrinkName");
                    withBlock.ChitName = oRow("DrinkName");
                    withBlock.Price = oRow("DrinkPrice") * RepeatQuantity;
                    // .TaxID = oRow("TaxID")

                }
                _repeatName = oRow("DrinkName");
                _repeatPrice = oRow("DrinkPrice") * RepeatQuantity;
                // _repeatTaxID = oRow("TaxID")

            }
        }


        PopulateRepeatListView(itemID);



    }

    private void DetermineDrinkModifierDetails222(int itemID)
    {
        _repeatFunction = 4;
        _itemNumber = itemID;

        foreach (DataRow oRow in ds.Tables("Drink").Rows)
        {
            if (oRow("DrinkID") == itemID)
            {
                {
                    ref var withBlock = ref currentRepeatItem;
                    withBlock.Name = oRow("DrinkName");
                    withBlock.TerminalName = oRow("DrinkName");
                    withBlock.ChitName = oRow("DrinkName");
                    withBlock.Price = oRow("AddOnPrice") * RepeatQuantity;
                    // .TaxID = oRow("TaxID")
                    withBlock.SII = -1;
                }
                _repeatName = "   " + oRow("DrinkName");
                _repeatPrice = oRow("AddOnPrice") * RepeatQuantity;
                _repeatTaxID = oRow("TaxID");
            }
        }

        // we put to nothing b/c we arleady used in calculations 
        // but this way we don't show a modifier quantity
        _repeatQuantity = default;
        PopulateRepeatListView(itemID);



    }

    private void PopulateRepeatListView(int itemID)
    {

        // ***********************
        // creates a collection of selectedItemDetail
        currentRepeatOrderCollection.Add(currentRepeatItem);


        var repeatItem = new ListViewItem();

        if (RepeatQuantity > 1)
        {
            repeatItem.Text = RepeatQuantity;
        }
        else
        {
            repeatItem.Text = " ";
        }
        repeatItem.SubItems.Add(RepeatName);
        repeatItem.SubItems.Add(RepeatPrice);
        repeatItem.SubItems.Add(itemID);
        lstRepeat.Items.Add(repeatItem);

    }



    private void btnCancel_Click(object sender, EventArgs e)
    {

        currentTable.si2 = 0;
        currentTable.Tempsi2 = 0;
        this.Dispose();

    }

    private void btnAccept_Click(object sender, EventArgs e)
    {

        if (_forRepeat == true)
        {
            AcceptRepeat?.Invoke();
        }
        else
        {
            OrderDelivered?.Invoke();
        }

        this.Dispose();

    }
}