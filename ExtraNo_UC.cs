using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DataSet_Builder;



public partial class ExtraNo_UC : System.Windows.Forms.UserControl
{

    private string _mainfoodItemName;
    private int _mainfoodFunID;
    private int _mainfoodFunGroup;
    private string _mainfoodFunFlag;
    private int _mainfoodTaxID;

    private string _rawType;
    private int _selectedRawItemID;
    private string _selectedRawItemName;
    private decimal _selectedRawPriceTotal;
    private int _selectedRawTrackAs;



    internal string MainFoodItemName
    {
        get
        {
            return _mainfoodItemName;
        }
        set
        {
            _mainfoodItemName = value;
        }
    }

    internal int MainFoodFunID
    {
        get
        {
            return _mainfoodFunID;
        }
        set
        {
            _mainfoodFunID = value;
        }
    }

    internal int MainFoodFunGroup
    {
        get
        {
            return _mainfoodFunGroup;
        }
        set
        {
            _mainfoodFunGroup = value;
        }
    }

    internal string MainFoodFunFlag
    {
        get
        {
            return _mainfoodFunFlag;
        }
        set
        {
            _mainfoodFunFlag = value;
        }
    }

    internal int MainFoodTaxID
    {
        get
        {
            return _mainfoodTaxID;
        }
        set
        {
            _mainfoodTaxID = value;
        }
    }


    internal string RawType
    {
        get
        {
            return _rawType;
        }
        set
        {
            _rawType = value;
        }
    }

    internal string SelectedRawItemID
    {
        get
        {
            return _selectedRawItemID.ToString();
        }
        set
        {
            _selectedRawItemID = Conversions.ToInteger(value);
        }
    }

    internal string SelectedRawItemName
    {
        get
        {
            return _selectedRawItemName;
        }
        set
        {
            _selectedRawItemName = value;
        }
    }

    internal decimal SelectedRawPriceTotal
    {
        get
        {
            return _selectedRawPriceTotal;
        }
        set
        {
            _selectedRawPriceTotal = value;
        }
    }

    internal int SelectedRawTrackAs
    {
        get
        {
            return _selectedRawTrackAs;
        }
        set
        {
            _selectedRawTrackAs = value;
        }
    }

    public event SelectedNOEventHandler SelectedNO;

    public delegate void SelectedNOEventHandler();
    public event SelectedEXTRAEventHandler SelectedEXTRA;

    public delegate void SelectedEXTRAEventHandler();
    public event SelectedCloseEventHandler SelectedClose;

    public delegate void SelectedCloseEventHandler();

    public event AddingItemToOrderEventHandler AddingItemToOrder;

    public delegate void AddingItemToOrderEventHandler(object sender);




    #region  Windows Form Designer generated code 

    public ExtraNo_UC() : base()
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call

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
    private Global.System.Windows.Forms.ListView _lstIngredientsExtraNo;

    internal virtual Global.System.Windows.Forms.ListView lstIngredientsExtraNo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lstIngredientsExtraNo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lstIngredientsExtraNo != null)
            {
                _lstIngredientsExtraNo.Click -= lstIngredientsExtraNo_SelectedIndexChanged;
            }

            _lstIngredientsExtraNo = value;
            if (_lstIngredientsExtraNo != null)
            {
                _lstIngredientsExtraNo.Click += lstIngredientsExtraNo_SelectedIndexChanged;
            }
        }
    }
    private Global.System.Windows.Forms.ListView _lstIngredientsAll;

    internal virtual Global.System.Windows.Forms.ListView lstIngredientsAll
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lstIngredientsAll;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lstIngredientsAll = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblRawItemName;

    internal virtual Global.System.Windows.Forms.Label lblRawItemName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblRawItemName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblRawItemName = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnClose;

    internal virtual Global.System.Windows.Forms.Button btnClose
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnClose;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnClose != null)
            {
                _btnClose.Click -= btnClose_Click;
            }

            _btnClose = value;
            if (_btnClose != null)
            {
                _btnClose.Click += btnClose_Click;
            }
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _lstAllBreak;

    internal virtual Global.System.Windows.Forms.ColumnHeader lstAllBreak
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lstAllBreak;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lstAllBreak = value;
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _lstAllUnit;

    internal virtual Global.System.Windows.Forms.ColumnHeader lstAllUnit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lstAllUnit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lstAllUnit = value;
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _lstAllItemName;

    internal virtual Global.System.Windows.Forms.ColumnHeader lstAllItemName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lstAllItemName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lstAllItemName = value;
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _cRawItemID;

    internal virtual Global.System.Windows.Forms.ColumnHeader cRawItemID
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cRawItemID;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _cRawItemID = value;
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _cRawItemName;

    internal virtual Global.System.Windows.Forms.ColumnHeader cRawItemName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cRawItemName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _cRawItemName = value;
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _cRawPriceTotal;

    internal virtual Global.System.Windows.Forms.ColumnHeader cRawPriceTotal
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cRawPriceTotal;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _cRawPriceTotal = value;
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _cRawTrackAs;

    internal virtual Global.System.Windows.Forms.ColumnHeader cRawTrackAs
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cRawTrackAs;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _cRawTrackAs = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnExtra;

    internal virtual Global.System.Windows.Forms.Button btnExtra
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnExtra;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnExtra != null)
            {
                _btnExtra.Click -= btnExtra_Click;
            }

            _btnExtra = value;
            if (_btnExtra != null)
            {
                _btnExtra.Click += btnExtra_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnNo;

    internal virtual Global.System.Windows.Forms.Button btnNo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnNo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnNo != null)
            {
                _btnNo.Click -= btnNo_Click;
            }

            _btnNo = value;
            if (_btnNo != null)
            {
                _btnNo.Click += btnNo_Click;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _lstIngredientsExtraNo = new System.Windows.Forms.ListView();
        _lstIngredientsExtraNo.Click += lstIngredientsExtraNo_SelectedIndexChanged;
        _cRawItemID = new System.Windows.Forms.ColumnHeader();
        _cRawItemName = new System.Windows.Forms.ColumnHeader();
        _cRawPriceTotal = new System.Windows.Forms.ColumnHeader();
        _cRawTrackAs = new System.Windows.Forms.ColumnHeader();
        _btnExtra = new System.Windows.Forms.Button();
        _btnExtra.Click += btnExtra_Click;
        _btnNo = new System.Windows.Forms.Button();
        _btnNo.Click += btnNo_Click;
        _lstIngredientsAll = new System.Windows.Forms.ListView();
        _lstAllBreak = new System.Windows.Forms.ColumnHeader();
        _lstAllUnit = new System.Windows.Forms.ColumnHeader();
        _lstAllItemName = new System.Windows.Forms.ColumnHeader();
        _lblRawItemName = new System.Windows.Forms.Label();
        _btnClose = new System.Windows.Forms.Button();
        _btnClose.Click += btnClose_Click;
        this.SuspendLayout();
        // 
        // lstIngredientsExtraNo
        // 
        _lstIngredientsExtraNo.BackColor = System.Drawing.Color.LightSlateGray;
        _lstIngredientsExtraNo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { _cRawItemID, _cRawItemName, _cRawPriceTotal, _cRawTrackAs });
        _lstIngredientsExtraNo.FullRowSelect = true;
        _lstIngredientsExtraNo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        _lstIngredientsExtraNo.Location = new System.Drawing.Point(16, 96);
        _lstIngredientsExtraNo.MultiSelect = false;
        _lstIngredientsExtraNo.Name = "_lstIngredientsExtraNo";
        _lstIngredientsExtraNo.Size = new System.Drawing.Size(214, 368);
        _lstIngredientsExtraNo.TabIndex = 0;
        _lstIngredientsExtraNo.View = System.Windows.Forms.View.Details;
        // 
        // cRawItemID
        // 
        _cRawItemID.Text = "";
        _cRawItemID.Width = 0;
        // 
        // cRawItemName
        // 
        _cRawItemName.Text = "Item";
        _cRawItemName.Width = 150;
        // 
        // cRawPriceTotal
        // 
        _cRawPriceTotal.Text = "Price";
        _cRawPriceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        // 
        // cRawTrackAs
        // 
        _cRawTrackAs.Text = "";
        _cRawTrackAs.Width = 0;
        // 
        // btnExtra
        // 
        _btnExtra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnExtra.ForeColor = System.Drawing.Color.White;
        _btnExtra.Location = new System.Drawing.Point(24, 32);
        _btnExtra.Name = "_btnExtra";
        _btnExtra.Size = new System.Drawing.Size(88, 48);
        _btnExtra.TabIndex = 1;
        _btnExtra.Text = "Extra";
        // 
        // btnNo
        // 
        _btnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnNo.ForeColor = System.Drawing.Color.White;
        _btnNo.Location = new System.Drawing.Point(128, 32);
        _btnNo.Name = "_btnNo";
        _btnNo.Size = new System.Drawing.Size(88, 48);
        _btnNo.TabIndex = 2;
        _btnNo.Text = "No";
        // 
        // lstIngredientsAll
        // 
        _lstIngredientsAll.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
        _lstIngredientsAll.BackColor = System.Drawing.Color.FromArgb(59, 96, 141);
        _lstIngredientsAll.BorderStyle = System.Windows.Forms.BorderStyle.None;
        _lstIngredientsAll.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { _lstAllBreak, _lstAllUnit, _lstAllItemName });
        _lstIngredientsAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lstIngredientsAll.ForeColor = System.Drawing.Color.White;
        _lstIngredientsAll.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        _lstIngredientsAll.Location = new System.Drawing.Point(240, 192);
        _lstIngredientsAll.Name = "_lstIngredientsAll";
        _lstIngredientsAll.Size = new System.Drawing.Size(264, 256);
        _lstIngredientsAll.TabIndex = 3;
        _lstIngredientsAll.View = System.Windows.Forms.View.Details;
        // 
        // lstAllBreak
        // 
        _lstAllBreak.Text = "";
        _lstAllBreak.Width = 30;
        // 
        // lstAllUnit
        // 
        _lstAllUnit.Text = "";
        _lstAllUnit.Width = 50;
        // 
        // lstAllItemName
        // 
        _lstAllItemName.Text = "";
        _lstAllItemName.Width = 180;
        // 
        // lblRawItemName
        // 
        _lblRawItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblRawItemName.ForeColor = System.Drawing.Color.White;
        _lblRawItemName.Location = new System.Drawing.Point(272, 160);
        _lblRawItemName.Name = "_lblRawItemName";
        _lblRawItemName.Size = new System.Drawing.Size(192, 24);
        _lblRawItemName.TabIndex = 4;
        _lblRawItemName.Text = "Food Item Name";
        _lblRawItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btnClose
        // 
        _btnClose.Location = new System.Drawing.Point(400, 32);
        _btnClose.Name = "_btnClose";
        _btnClose.Size = new System.Drawing.Size(88, 48);
        _btnClose.TabIndex = 5;
        _btnClose.Text = "Close";
        // 
        // ExtraNo_UC
        // 
        this.BackColor = System.Drawing.Color.FromArgb(59, 96, 141);
        this.Controls.Add(_btnClose);
        this.Controls.Add(_lblRawItemName);
        this.Controls.Add(_lstIngredientsAll);
        this.Controls.Add(_btnNo);
        this.Controls.Add(_btnExtra);
        this.Controls.Add(_lstIngredientsExtraNo);
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        this.Name = "ExtraNo_UC";
        this.Size = new System.Drawing.Size(512, 480);
        this.ResumeLayout(false);

    }

    #endregion

    public void PopulateExtraNoListView()
    {

        DataRowView vRow;
        decimal rawPrice;

        lstIngredientsExtraNo.Items.Clear();
        lstIngredientsAll.Items.Clear();

        lblRawItemName.Text = MainFoodItemName;

        foreach (DataRowView currentVRow in dvIngredients)
        {
            vRow = currentVRow;
            var allItem = new ListViewItem();

            allItem.Text = Strings.Format(vRow("RawUsageAmount"), "##0");
            allItem.SubItems.Add(vRow("RecipeUnit"));
            allItem.SubItems.Add(vRow("RawItemName"));

            lstIngredientsAll.Items.Add(allItem);

        }

        if (RawType == "EXTRA")
        {
            foreach (DataRowView currentVRow1 in dvIngredientsEXTRA)
            {
                vRow = currentVRow1;
                var extraItem = new ListViewItem();

                extraItem.Text = vRow("RawItemID");
                extraItem.SubItems.Add(vRow("RawItemName"));
                // rawPrice = (vRow("RawUsageAmount") * vRow("ExtraPrice"))
                rawPrice = vRow("ExtraPrice");
                extraItem.SubItems.Add(Strings.Format(rawPrice, "##.00"));
                if (!object.ReferenceEquals(vRow("TrackAs"), DBNull.Value))
                {
                    extraItem.SubItems.Add(vRow("TrackAs"));
                }
                else
                {
                    // (-6 for NO) (-7 for EXTRA)
                    // we place this in ItemID in OpenOrders
                    extraItem.SubItems.Add(-7);
                }

                lstIngredientsExtraNo.Items.Add(extraItem);

            }
            IsExtraType();
        }
        else
        {
            foreach (DataRowView currentVRow2 in dvIngredientsNO)
            {
                vRow = currentVRow2;
                var extraItem = new ListViewItem();

                extraItem.Text = vRow("RawItemID");
                extraItem.SubItems.Add(vRow("RawItemName"));
                // rawPrice = (vRow("RawUsageAmount") * vRow("NoPrice"))
                rawPrice = vRow("NoPrice");
                extraItem.SubItems.Add(Strings.Format(rawPrice, "##.00"));
                if (!object.ReferenceEquals(vRow("TrackAs"), DBNull.Value))
                {
                    extraItem.SubItems.Add(vRow("TrackAs"));
                }
                else
                {
                    // (-6 for NO) (-7 for EXTRA)
                    // we place this in ItemID in OpenOrders
                    extraItem.SubItems.Add(-6);
                }

                lstIngredientsExtraNo.Items.Add(extraItem);

            }
            IsNoType();
        }

    }

    private void lstIngredientsExtraNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        var currentItem = new SelectedItemDetail();
        var vRow = default(DataRowView);
        var fRow = default(DataRow);
        bool isTrackingFoodInventory = false;

        foreach (ListViewItem sItem in lstIngredientsExtraNo.Items)
        {
            if (sItem.Selected == true)
            {
                _selectedRawItemID = sItem.SubItems(0).Text;
                _selectedRawItemName = sItem.SubItems(1).Text;
                _selectedRawPriceTotal = (decimal)sItem.SubItems(2).Text;
                _selectedRawTrackAs = sItem.SubItems(3).Text;
                break;
            }
        }

        foreach (DataRowView currentVRow in dvIngredients)
        {
            vRow = currentVRow;
            if (vRow("RawItemID") == SelectedRawItemID)
            {
                break;
            }
        }
        // If vRow Is Nothing Then Exit Sub


        // MsgBox(vRow("TrackAs").ToString)

        if (!object.ReferenceEquals(vRow("TrackAs"), DBNull.Value))
        {
            // Raw material has a corresponding food item
            // we need to make sure food item was not deleted
            foreach (DataRow currentFRow in ds.Tables("FoodTable").Rows)
            {
                fRow = currentFRow;
                if (fRow("FoodID") == vRow("TrackAs"))
                {
                    isTrackingFoodInventory = true;
                    break;
                }
            }
        }

        if (isTrackingFoodInventory == true)
        {
            // Raw material has a corresponding food item
            currentItem.ID = vRow("TrackAs");

            currentItem.Category = fRow("CategoryID");
            if (!object.ReferenceEquals(fRow("PrintPriorityID"), DBNull.Value))
            {
                currentItem.PrintPriorityID = fRow("PrintPriorityID");
            }
            else
            {
                currentItem.PrintPriorityID = 3;
            }
            currentItem.RoutingID = currentTable.ReferenceRouting;
            currentItem.FunctionID = fRow("FunctionID");
            currentItem.FunctionGroup = fRow("FunctionGroupID");
            currentItem.FunctionFlag = fRow("FunctionFlag");
            currentItem.TaxID = fRow("TaxID");
        }

        else
        {
            if (RawType == "EXTRA")
            {
                currentItem.ID = -7;
                currentItem.Category = -7;
            }
            else
            {
                currentItem.ID = -6;
                currentItem.Category = -6;
            }

            currentItem.PrintPriorityID = 3;
            currentItem.RoutingID = currentTable.ReferenceRouting; // must do first in case drink
            currentItem.FunctionID = MainFoodFunID;
            currentItem.FunctionGroup = MainFoodFunGroup;
            currentItem.FunctionFlag = MainFoodFunFlag;
            currentItem.TaxID = MainFoodTaxID;

            DetermineFunctionAndTaxInfo(currentItem, 9, false);
            // not sure why we are doing above

        }   // 9 is functionGroup = Modifier

        if (RawType == "EXTRA")
        {
            currentItem.Quantity = 1;
            currentItem.Price = SelectedRawPriceTotal;
        }

        else
        {
            currentItem.Quantity = -1;
            currentItem.Price = -1 * SelectedRawPriceTotal;

        }

        currentItem.Name = " *** " + currentTable.OrderingStatus + "  " + vRow("RawItemName");
        currentItem.TerminalName = " *** " + currentTable.OrderingStatus + "  " + vRow("RawItemName");
        currentItem.ChitName = " *** " + currentTable.OrderingStatus + "  " + vRow("RawItemName");

        currentItem.ItemStatus = 0;
        currentItem.Check = currentTable.CheckNumber;
        currentItem.Customer = currentTable.CustomerNumber;
        currentItem.Course = currentTable.CourseNumber;
        currentItem.SIN = currentTable.SIN;
        currentItem.SII = currentTable.ReferenceSIN;

        currentItem.si2 = currentTable.si2;

        AddingItemToOrder?.Invoke(currentItem);
        // RaiseEvent SelectedClose()

    }

    private void btnNo_Click(object sender, EventArgs e)
    {

        RawType = "NO";
        PopulateExtraNoListView();

    }

    private void IsNoType()
    {
        btnNo.BackColor = Color.Brown;
        btnExtra.BackColor = System.Drawing.Color.FromArgb(59, 96, 141);
        currentTable.OrderingStatus = "NO";
        // RaiseEvent SelectedNO()

    }
    private void btnExtra_Click(object sender, EventArgs e)
    {

        RawType = "EXTRA";
        PopulateExtraNoListView();
    }

    private void IsExtraType()
    {
        btnExtra.BackColor = Color.Brown;
        btnNo.BackColor = System.Drawing.Color.FromArgb(59, 96, 141);
        currentTable.OrderingStatus = "EXTRA";
        // RaiseEvent SelectedEXTRA()

    }

    private void btnClose_Click(object sender, EventArgs e)
    {

        SelectedClose?.Invoke();

    }


}