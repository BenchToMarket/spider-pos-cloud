using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using DataSet_Builder;


public partial class ModifyOrder_UC : System.Windows.Forms.UserControl
{

    // Dim sql As New DataSet_Builder.SQLHelper(connectserver)

    private DataView dvModifyOrder;
    private int _currentItemID;
    private decimal _currentPrice;
    private bool newItemIsFree;
    private int _funID;
    private string _funFlag;
    private bool modifyingOrderGroup = false;

    internal bool isFoodItem;
    internal int ModifyCurrentSIN;
    internal int ModifyCurrentSII;
    internal string ModifyCurrentName;
    internal string ModifyCurrentChitName;

    private int _modifyItemID;
    private string _modifyItemName;
    private string _modifyAbrevName;
    private string _modifyChitName;
    private decimal _modifySurcharge;
    private int _modifyTaxId;
    private int _modifyRoutingID;
    private int _modifyPrepareTime;           // ?????????????????
    private int _modifyCategoryID;
    private int _modifySIN;

    private int _modifyCustomerNumber;
    private int _modifyQuantity;
    private int _modifyCourse;
    private bool _alreadyOrdered;

    private KitchenButton[] btnModifyQuantity = new KitchenButton[11];
    private KitchenButton[] btnModifyCustomer = new KitchenButton[11];
    private KitchenButton[] btnModifyCourse = new KitchenButton[6];

    public event AddingItemToOrderEventHandler AddingItemToOrder;

    public delegate void AddingItemToOrderEventHandler(object sender);

    internal int ModifyItemID
    {
        get
        {
            return _modifyItemID;
        }
        set
        {
            _modifyItemID = value;
        }
    }

    internal string ModifyItemName
    {
        get
        {
            return _modifyItemName;
        }
        set
        {
            _modifyItemName = value;
        }
    }

    internal string ModifyAbrevName
    {
        get
        {
            return _modifyAbrevName;
        }
        set
        {
            _modifyAbrevName = value;
        }
    }

    internal string ModifyChitName
    {
        get
        {
            return _modifyChitName;
        }
        set
        {
            _modifyChitName = value;
        }
    }

    internal decimal ModifySurcharge
    {
        get
        {
            return _modifySurcharge;
        }
        set
        {
            _modifySurcharge = value;
        }
    }

    internal int ModifyTaxID
    {
        get
        {
            return _modifyTaxId;
        }
        set
        {
            _modifyTaxId = value;
        }
    }

    internal int ModifyRoutingID
    {
        get
        {
            return _modifyRoutingID;
        }
        set
        {
            _modifyRoutingID = value;
        }
    }

    internal int ModifyPrepareTime
    {
        get
        {
            return _modifyPrepareTime;
        }
        set
        {
            _modifyPrepareTime = value;
        }
    }

    internal int ModifyCategoryID
    {
        get
        {
            return _modifyCategoryID;
        }
        set
        {
            _modifyCategoryID = value;
        }
    }

    internal int ModifySIN
    {
        get
        {
            return _modifySIN;
        }
        set
        {
            _modifySIN = value;
        }
    }

    internal int ModifyQuantity
    {
        get
        {
            return _modifyQuantity;
        }
        set
        {
            _modifyQuantity = value;
        }
    }

    internal int ModifyCustomerNumber
    {
        get
        {
            return _modifyCustomerNumber;
        }
        set
        {
            _modifyCustomerNumber = value;
        }

    }

    internal int ModifyCourse
    {
        get
        {
            return _modifyCourse;
        }
        set
        {
            _modifyCourse = value;
        }
    }


    public event AcceptModifyEventHandler AcceptModify;

    public delegate void AcceptModifyEventHandler();
    public event AcceptModifySubTotalEventHandler AcceptModifySubTotal;

    public delegate void AcceptModifySubTotalEventHandler();
    public event CancelModifyEventHandler CancelModify;

    public delegate void CancelModifyEventHandler();



    #region  Windows Form Designer generated code 

    public ModifyOrder_UC(int currentSII, int currentSIN, string currentTerminalName, string currentName, string currentChitName, ref DataView dvModify, bool isFood, int currentItemID, decimal currentPrice, int funID, string funFlag, int cn, int q, int c, bool alrOrdered) : base()
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        dvModifyOrder = dvModify;
        isFoodItem = isFood;
        _currentItemID = currentItemID;
        _currentPrice = currentPrice;
        ModifyCurrentSIN = currentSIN;
        ModifyCurrentSII = currentSII;
        ModifyCurrentName = currentName;
        ModifyAbrevName = currentTerminalName;
        ModifyCurrentChitName = currentChitName;
        _funID = funID;
        _funFlag = funFlag;
        _modifyQuantity = q;
        _modifyCustomerNumber = cn;
        _modifyCourse = c;
        if (ModifyCurrentSIN == ModifyCurrentSII)
        {
            modifyingOrderGroup = true;
        }
        else
        {
            modifyingOrderGroup = false;
        }
        _alreadyOrdered = alrOrdered;

        CreateModifyButtonPanel();
        if (_alreadyOrdered == true)
        {
            pnlCourse.Enabled = false;
            pnlQuantity.Enabled = false;
            lblModifyOld.Text = "Can Only Modify Customer";
        }
        else
        {
            PopulateModifyListView();
        }

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
    private Global.System.Windows.Forms.Label _Label1;

    internal virtual Global.System.Windows.Forms.Label Label1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label1 = value;
        }
    }
    private Global.System.Windows.Forms.ListView _lstModify;

    internal virtual Global.System.Windows.Forms.ListView lstModify
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lstModify;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lstModify != null)
            {
                _lstModify.SelectedIndexChanged -= ModifyListView_Click;
            }

            _lstModify = value;
            if (_lstModify != null)
            {
                _lstModify.SelectedIndexChanged += ModifyListView_Click;
            }
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _ModifyName;

    internal virtual Global.System.Windows.Forms.ColumnHeader ModifyName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ModifyName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _ModifyName = value;
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _ModifyID;

    internal virtual Global.System.Windows.Forms.ColumnHeader ModifyID
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ModifyID;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _ModifyID = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnModifyCancel;

    internal virtual Global.System.Windows.Forms.Button btnModifyCancel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnModifyCancel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnModifyCancel != null)
            {
                _btnModifyCancel.Click -= btnModifyCancel_Click;
            }

            _btnModifyCancel = value;
            if (_btnModifyCancel != null)
            {
                _btnModifyCancel.Click += btnModifyCancel_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnModifyAccept;

    internal virtual Global.System.Windows.Forms.Button btnModifyAccept
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnModifyAccept;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnModifyAccept != null)
            {
                _btnModifyAccept.Click -= btnModifyAccept_Click;
            }

            _btnModifyAccept = value;
            if (_btnModifyAccept != null)
            {
                _btnModifyAccept.Click += btnModifyAccept_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _Label3;

    internal virtual Global.System.Windows.Forms.Label Label3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label3 = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblModifyOld;

    internal virtual Global.System.Windows.Forms.Label lblModifyOld
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblModifyOld;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblModifyOld = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblModifyNew;

    internal virtual Global.System.Windows.Forms.Label lblModifyNew
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblModifyNew;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblModifyNew = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlQuantity;

    internal virtual Global.System.Windows.Forms.Panel pnlQuantity
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlQuantity;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlQuantity = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlCustomer;

    internal virtual Global.System.Windows.Forms.Panel pnlCustomer
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlCustomer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlCustomer = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label2;

    internal virtual Global.System.Windows.Forms.Label Label2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label2 = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label4;

    internal virtual Global.System.Windows.Forms.Label Label4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label4 = value;
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _CategoryID;

    internal virtual Global.System.Windows.Forms.ColumnHeader CategoryID
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _CategoryID;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _CategoryID = value;
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _SelectedItemSIN;

    internal virtual Global.System.Windows.Forms.ColumnHeader SelectedItemSIN
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SelectedItemSIN;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _SelectedItemSIN = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label5;

    internal virtual Global.System.Windows.Forms.Label Label5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label5 = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlCourse;

    internal virtual Global.System.Windows.Forms.Panel pnlCourse
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlCourse;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlCourse = value;
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _Panel1 = new System.Windows.Forms.Panel();
        _lstModify = new System.Windows.Forms.ListView();
        _lstModify.SelectedIndexChanged += ModifyListView_Click;
        _ModifyName = new System.Windows.Forms.ColumnHeader();
        _ModifyID = new System.Windows.Forms.ColumnHeader();
        _CategoryID = new System.Windows.Forms.ColumnHeader();
        _SelectedItemSIN = new System.Windows.Forms.ColumnHeader();
        _Label1 = new System.Windows.Forms.Label();
        _lblModifyOld = new System.Windows.Forms.Label();
        _btnModifyCancel = new System.Windows.Forms.Button();
        _btnModifyCancel.Click += btnModifyCancel_Click;
        _btnModifyAccept = new System.Windows.Forms.Button();
        _btnModifyAccept.Click += btnModifyAccept_Click;
        _Label3 = new System.Windows.Forms.Label();
        _lblModifyNew = new System.Windows.Forms.Label();
        _pnlQuantity = new System.Windows.Forms.Panel();
        _pnlCustomer = new System.Windows.Forms.Panel();
        _Label2 = new System.Windows.Forms.Label();
        _Label4 = new System.Windows.Forms.Label();
        _Label5 = new System.Windows.Forms.Label();
        _pnlCourse = new System.Windows.Forms.Panel();
        _Panel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.Color.LightSlateGray;
        _Panel1.Controls.Add(_lstModify);
        _Panel1.Location = new System.Drawing.Point(472, 48);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(280, 504);
        _Panel1.TabIndex = 0;
        // 
        // lstModify
        // 
        _lstModify.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { _ModifyName, _ModifyID, _CategoryID, _SelectedItemSIN });
        _lstModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lstModify.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        _lstModify.Location = new System.Drawing.Point(16, 16);
        _lstModify.Name = "_lstModify";
        _lstModify.Size = new System.Drawing.Size(248, 472);
        _lstModify.TabIndex = 0;
        _lstModify.View = System.Windows.Forms.View.Details;
        // 
        // ModifyName
        // 
        _ModifyName.Text = "";
        _ModifyName.Width = 240;
        // 
        // ModifyID
        // 
        _ModifyID.Text = "";
        _ModifyID.Width = 0;
        // 
        // CategoryID
        // 
        _CategoryID.Width = 0;
        // 
        // SelectedItemSIN
        // 
        _SelectedItemSIN.Width = 0;
        // 
        // Label1
        // 
        _Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _Label1.Location = new System.Drawing.Point(16, 16);
        _Label1.Name = "_Label1";
        _Label1.Size = new System.Drawing.Size(80, 32);
        _Label1.TabIndex = 1;
        _Label1.Text = "Modify:";
        _Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblModifyOld
        // 
        _lblModifyOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblModifyOld.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _lblModifyOld.Location = new System.Drawing.Point(104, 16);
        _lblModifyOld.Name = "_lblModifyOld";
        _lblModifyOld.Size = new System.Drawing.Size(160, 32);
        _lblModifyOld.TabIndex = 2;
        _lblModifyOld.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // btnModifyCancel
        // 
        _btnModifyCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnModifyCancel.Location = new System.Drawing.Point(56, 552);
        _btnModifyCancel.Name = "_btnModifyCancel";
        _btnModifyCancel.Size = new System.Drawing.Size(144, 48);
        _btnModifyCancel.TabIndex = 3;
        _btnModifyCancel.Text = "Cancel";
        // 
        // btnModifyAccept
        // 
        _btnModifyAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnModifyAccept.Location = new System.Drawing.Point(232, 552);
        _btnModifyAccept.Name = "_btnModifyAccept";
        _btnModifyAccept.Size = new System.Drawing.Size(152, 48);
        _btnModifyAccept.TabIndex = 4;
        _btnModifyAccept.Text = "Accept";
        // 
        // Label3
        // 
        _Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _Label3.Location = new System.Drawing.Point(56, 56);
        _Label3.Name = "_Label3";
        _Label3.Size = new System.Drawing.Size(48, 32);
        _Label3.TabIndex = 5;
        _Label3.Text = "To:";
        _Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblModifyNew
        // 
        _lblModifyNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblModifyNew.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _lblModifyNew.Location = new System.Drawing.Point(120, 56);
        _lblModifyNew.Name = "_lblModifyNew";
        _lblModifyNew.Size = new System.Drawing.Size(192, 32);
        _lblModifyNew.TabIndex = 6;
        _lblModifyNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // pnlQuantity
        // 
        _pnlQuantity.BackColor = System.Drawing.Color.LightSlateGray;
        _pnlQuantity.Location = new System.Drawing.Point(24, 152);
        _pnlQuantity.Name = "_pnlQuantity";
        _pnlQuantity.Size = new System.Drawing.Size(392, 112);
        _pnlQuantity.TabIndex = 7;
        // 
        // pnlCustomer
        // 
        _pnlCustomer.BackColor = System.Drawing.Color.LightSlateGray;
        _pnlCustomer.Location = new System.Drawing.Point(24, 312);
        _pnlCustomer.Name = "_pnlCustomer";
        _pnlCustomer.Size = new System.Drawing.Size(392, 112);
        _pnlCustomer.TabIndex = 8;
        // 
        // Label2
        // 
        _Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _Label2.Location = new System.Drawing.Point(16, 120);
        _Label2.Name = "_Label2";
        _Label2.TabIndex = 9;
        _Label2.Text = "Quantity";
        // 
        // Label4
        // 
        _Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
        _Label4.Location = new System.Drawing.Point(16, 280);
        _Label4.Name = "_Label4";
        _Label4.TabIndex = 10;
        _Label4.Text = "Customer";
        // 
        // Label5
        // 
        _Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
        _Label5.Location = new System.Drawing.Point(16, 440);
        _Label5.Name = "_Label5";
        _Label5.TabIndex = 11;
        _Label5.Text = "Course";
        // 
        // pnlCourse
        // 
        _pnlCourse.BackColor = System.Drawing.Color.LightSlateGray;
        _pnlCourse.Location = new System.Drawing.Point(24, 472);
        _pnlCourse.Name = "_pnlCourse";
        _pnlCourse.Size = new System.Drawing.Size(392, 56);
        _pnlCourse.TabIndex = 12;
        // 
        // ModifyOrder_UC
        // 
        this.BackColor = System.Drawing.Color.FromArgb(59, 96, 141);
        this.Controls.Add(_pnlCourse);
        this.Controls.Add(_Label5);
        this.Controls.Add(_Label4);
        this.Controls.Add(_Label2);
        this.Controls.Add(_pnlQuantity);
        this.Controls.Add(_lblModifyNew);
        this.Controls.Add(_Label3);
        this.Controls.Add(_btnModifyAccept);
        this.Controls.Add(_btnModifyCancel);
        this.Controls.Add(_lblModifyOld);
        this.Controls.Add(_Label1);
        this.Controls.Add(_Panel1);
        this.Controls.Add(_pnlCustomer);
        this.Name = "ModifyOrder_UC";
        this.Size = new System.Drawing.Size(784, 616);
        _Panel1.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion


    private void PopulateModifyListView()
    {

        lstModify.Items.Clear();

        DataRowView vRow;

        if (isFoodItem == true)
        {

            foreach (DataRowView currentVRow in dvModifyOrder)
            {
                vRow = currentVRow;


                if (modifyingOrderGroup == true)
                {
                    // If vRow("ItemID") = _currentItemID Then
                    if (vRow("sin") == ModifyCurrentSIN)
                    {
                        lblModifyOld.Text = vRow("ItemName");
                        return;
                    }
                }
                else if (vRow("FoodID") == _currentItemID)
                {
                    lblModifyOld.Text = vRow("FoodName");
                    if (_currentPrice == 0m)
                    {
                        // test to see if Food usually has price

                        newItemIsFree = Conversions.ToBoolean(IsItemIncluded(vRow("FoodID"), _funID, vRow("CategoryID")));
                    }
                }

                if (vRow("FoodID") != _currentItemID | modifyingOrderGroup == true)
                {

                    var modifyItem = new ListViewItem();


                    if (modifyingOrderGroup == true)
                    {
                    }
                    // not populating for main item
                    // modifyItem.Text = vRow("ItemName")
                    // modifyItem.SubItems.Add(vRow("ItemID"))
                    // modifyItem.SubItems.Add(vRow("CategoryID"))
                    // modifyItem.SubItems.Add(vRow("sin"))
                    else
                    {
                        modifyItem.Text = vRow("FoodName");
                        modifyItem.SubItems.Add(vRow("FoodID"));
                        modifyItem.SubItems.Add(vRow("CategoryID"));
                        modifyItem.SubItems.Add(0);
                    }

                    lstModify.Items.Add(modifyItem);
                }
            }
        }
        else            // for drink item
        {

            foreach (DataRowView currentVRow1 in dvModifyOrder)
            {
                vRow = currentVRow1;

                if (vRow("DrinkID") == _currentItemID)
                {
                    if (modifyingOrderGroup == true)
                    {

                        lblModifyOld.Text = vRow("ItemName");
                    }
                    else
                    {
                        lblModifyOld.Text = vRow("DrinkName");
                    }

                    if (_currentPrice == 0m)
                    {
                        // test to see if Drink usually has price
                        // 222 not sure about DrinkCategoryID...
                        newItemIsFree = Conversions.ToBoolean(IsItemIncluded(vRow("DrinkID"), _funID, vRow("DrinkCategoryID")));
                    }
                    return;
                }
                else
                {
                    var modifyItem = new ListViewItem();


                    if (modifyingOrderGroup == true)
                    {
                    }
                    // modifyItem.Text = vRow("ItemName")
                    // modifyItem.SubItems.Add(vRow("ItemID"))
                    // modifyItem.SubItems.Add(vRow("DrinkCategoryID"))
                    // modifyItem.SubItems.Add(vRow("sin"))
                    else
                    {
                        modifyItem.Text = vRow("DrinkName");
                        modifyItem.SubItems.Add(vRow("DrinkID"));
                        modifyItem.SubItems.Add(vRow("DrinkCategoryID"));
                        modifyItem.SubItems.Add(0);
                    }
                    lstModify.Items.Add(modifyItem);
                }
            }
        }
    }

    private void ModifyListView_Click(object sender, EventArgs e)
    {

        DataRowView vRow;

        foreach (ListViewItem sItem in lstModify.Items)
        {

            if (sItem.Selected == true)
            {
                if (modifyingOrderGroup == true)
                {
                    _modifySIN = sItem.SubItems(3).Text;   // selected sin
                    if (ModifyCurrentSIN == ModifySIN)
                    {
                        // we just selected to modify the main item in a order group
                        // can't do this
                        return;
                    }
                    if (lstModify.Items.Count > 1)
                    {
                        // ???????????
                    }
                    // we are now going to modify part of the group order
                    _modifyCategoryID = sItem.SubItems(2).Text; // CategroyID
                    _currentItemID = sItem.SubItems(1).Text;    // FoodID or DrinkID
                    ModifyCurrentSIN = _modifySIN;
                    CreateNewModifyDataView();
                    modifyingOrderGroup = false;
                    PopulateModifyListView();
                    return;                            // **** not sure to exit??
                }
                _modifyItemID = sItem.SubItems(1).Text;    // FoodID or DrinkID
                sItem.ForeColor = Color.Red;
            }

            else
            {
                sItem.ForeColor = Color.Black;
            }
        }


        var subString = default(string);

        if (isFoodItem == true)
        {

            // **********************************
            // need to verify which of these we need 
            // we are taking this info from Foods Table and placing in OpenOrders Table

            foreach (DataRowView currentVRow in dvModifyOrder)
            {
                vRow = currentVRow;
                if (vRow("FoodID") == _modifyItemID)
                {
                    if (!(ModifyCurrentName.Substring(0, 5) == "*Sub*"))
                    {
                        subString = "*Sub* ";
                    }
                    if (!object.ReferenceEquals(vRow("ChitFoodName"), DBNull.Value))
                    {
                        _modifyChitName = "   " + subString + vRow("ChitFoodName");
                        // lblModifyNew.Text = vRow("ChitFoodName")
                    }

                    if (!object.ReferenceEquals(vRow("AbrevFoodName"), DBNull.Value))
                    {
                        _modifyAbrevName = "   " + subString + vRow("AbrevFoodName");
                        lblModifyNew.Text = vRow("AbrevFoodName");
                    }
                    if (!object.ReferenceEquals(vRow("FoodName"), DBNull.Value))
                    {
                        _modifyItemName = "   " + subString + vRow("FoodName");
                        // lblModifyNew.Text = vRow("FoodName")
                    }

                    if (newItemIsFree == true)
                    {
                        _modifySurcharge = 0m;
                    }
                    else if (!object.ReferenceEquals(vRow("Surcharge"), DBNull.Value))
                    {
                        if (currentTable.si2 > 1 & currentTable.si2 < 10)
                        {
                            _modifySurcharge = Conversions.ToDecimal(Strings.Format(vRow("Surcharge") * 0.5d, "##,###.00"));
                        }
                        else
                        {
                            _modifySurcharge = Conversions.ToDecimal(Strings.Format(vRow("Surcharge"), "##,###.00"));
                        }
                    }
                    else
                    {
                        _modifySurcharge = 0m;
                    }
                    if (!object.ReferenceEquals(vRow("TaxID"), DBNull.Value))
                    {
                        _modifyTaxId = vRow("TaxID");
                    }
                    else
                    {
                        _modifyTaxId = 0;
                    }

                    if (!object.ReferenceEquals(vRow("RoutingID"), DBNull.Value))
                    {
                        _modifyRoutingID = vRow("RoutingID");
                    }
                    else
                    {
                        _modifyRoutingID = 0;
                    }
                    // If modifyingOrderGroup = False Then
                    if (!object.ReferenceEquals(vRow("PrepareTime"), DBNull.Value))
                    {
                        _modifyPrepareTime = vRow("PrepareTime");
                    }
                    else
                    {
                        _modifyPrepareTime = 0;
                    }
                    // End If


                    break;
                }
            }
        }
        else                // when drink item
        {
            foreach (DataRowView currentVRow1 in dvModifyOrder)
            {
                vRow = currentVRow1;
                if (vRow("DrinkID") == _modifyItemID)
                {
                    if (!(ModifyCurrentName.Substring(0, 5) == "*Sub*"))
                    {
                        subString = "*Sub* ";
                    }
                    _modifyChitName = "   " + subString + vRow("DrinkName");
                    _modifyAbrevName = "   " + subString + vRow("DrinkName");
                    _modifyItemName = "   " + subString + vRow("DrinkName");
                    lblModifyNew.Text = vRow("DrinkName");
                    if (newItemIsFree == true)
                    {
                        _modifySurcharge = 0m;
                    }
                    else
                    {
                        _modifySurcharge = vRow("AddOnPrice");
                    }
                    _modifyTaxId = vRow("TaxID");
                    _modifyRoutingID = vRow("RoutingID");            // this is only temp
                    _modifyPrepareTime = default;
                    break;
                }
            }
        }

        AcceptModify?.Invoke();

        this.Dispose();

    }

    private void CreateNewModifyDataView()
    {
        string populatingTable;

        if (ModifyCategoryID > 100)
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

        if (isFoodItem == true)
        {
            dvModifyOrder = new DataView();
            {
                ref var withBlock = ref dvModifyOrder;
                withBlock.Table = ds.Tables(populatingTable + ModifyCategoryID);
                withBlock.Sort = "FoodName";
            }
        }


        else
        {
            // With dvModifyOrder
            // .Table = ds.Tables(populatingTable & catID)
            // .Sort = "FoodName"
            // End With

        }    // *** for drink    redo   ??????

    }
    private object IsItemIncluded(int testingFoodID, int funID, int catID)
    {
        // if current item has no price, we check to see if it nomally does
        // if it normally does we consider it included and flag true
        // for Drink Adds may not work as good b/c we would have used add-on price

        DataRow oRow;
        SqlClient.SqlDataReader dtr;
        var originalPrice = default(decimal);

        // *222checking(FoodTable)

        if (isFoodItem == true)
        {

            string populatingTable;
            // If catID > 100 Then
            if (_funFlag == "M")
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

            if (funID == 2 | funID == 3)
            {
                foreach (DataRow currentORow in ds.Tables(populatingTable + catID).Rows)
                {
                    oRow = currentORow;
                    if (oRow("FoodID") == testingFoodID)
                    {
                        if (object.ReferenceEquals(oRow("Surcharge"), DBNull.Value))
                        {
                            originalPrice = 0m;
                        }
                        else
                        {
                            originalPrice = oRow("Surcharge");
                        }
                        break;
                    }
                }

            }
        }

        // For Each oRow In ds.Tables("FoodTable").Rows
        // If oRow("FoodID") = testingFoodID Then
        // originalPrice = oRow("Surcharge")
        // Exit For
        // End If
        // Next

        else
        {
            foreach (DataRow currentORow1 in ds.Tables("Drink").Rows)
            {
                oRow = currentORow1;
                if (oRow("DrinkID") == testingFoodID)
                {
                    if (!object.ReferenceEquals(oRow("AddOnPrice"), DBNull.Value))
                    {
                        originalPrice = oRow("AddOnPrice");
                    }
                    else if (!object.ReferenceEquals(oRow("DrinkPrice"), DBNull.Value))
                    {
                        originalPrice = oRow("DrinkPrice");
                    }
                    else
                    {
                        originalPrice = 0m;

                    }
                    break;
                }
            }

        }

        if (originalPrice > 0m)
        {
            newItemIsFree = true;
        }

        return newItemIsFree;

    }

    private void btnModifyCancel_Click(object sender, EventArgs e)
    {
        CancelModify?.Invoke();
        this.Dispose();

    }

    private void btnModifyAccept_Click(object sender, EventArgs e)
    {

        AcceptModify?.Invoke();
        this.Dispose();

    }



    private void CreateModifyButtonPanel()
    {
        float w = pnlQuantity.Width / 5;
        float h = pnlQuantity.Height / 2;
        float x = 0f;
        float y = 0f;
        pnlQuantity.SuspendLayout();
        pnlCustomer.SuspendLayout();
        pnlCourse.SuspendLayout();


        int index;

        for (index = 1; index <= 10; index++)
        {
            if (ModifyQuantity == index)
            {
                CreateModifyOrderQuantityButton(index, x, y, w, h, c9);
            }
            else
            {
                CreateModifyOrderQuantityButton(index, x, y, w, h, c7);
            }
            if (index == 5)
            {
                x = 0f;
                y = y + h;
            }
            else if (index > 5)
            {
                x = w * (index - 5);
            }
            else
            {
                x = w * index;
            }

        }

        x = 0f;
        y = 0f;

        for (index = 1; index <= 10; index++)
        {
            if (ModifyCustomerNumber == index)
            {
                CreateModifyOrderCustomerButton(index, x, y, w, h, c9);
            }
            else
            {
                CreateModifyOrderCustomerButton(index, x, y, w, h, c7);
            }
            if (index == 5)
            {
                x = 0f;
                y = y + h;
            }
            else if (index > 5)
            {
                x = w * (index - 5);
            }
            else
            {
                x = w * index;
            }
        }

        x = 0f;
        y = 0f;

        for (index = 1; index <= 5; index++)
        {
            if (ModifyCourse == index)
            {
                CreateModifyOrderCourseButton(index, x, y, w, h, c9);
            }
            else
            {
                CreateModifyOrderCourseButton(index, x, y, w, h, c7);
            }
            x = w * index;
        }

        if (ModifyCurrentSIN != ModifyCurrentSII)
        {
            pnlQuantity.Enabled = false;
            pnlCustomer.Enabled = false;
            pnlCourse.Enabled = false;
        }

        pnlQuantity.ResumeLayout();
        pnlCustomer.ResumeLayout();
        pnlCourse.ResumeLayout();


    }

    private void CreateModifyOrderQuantityButton(int btnNo, float xPos, float yPos, float w, float h, Color cc)
    {

        // we don't create the first one son they match with the ID integer
        btnModifyQuantity[btnNo] = new KitchenButton(btnNo, w, h, cc, c2);
        {
            ref var withBlock = ref btnModifyQuantity[btnNo];
            withBlock.Location = new Point(xPos, yPos);
            withBlock.ForeColor = c3;
            this.btnModifyQuantity[btnNo].Click += ModifyOrderQuantityButton_Click;

            btnModifyQuantity[btnNo].ID = btnNo;
        }

        pnlQuantity.Controls.Add(btnModifyQuantity[btnNo]);

    }

    private void CreateModifyOrderCourseButton(int btnNo, float xPos, float yPos, float w, float h, Color cc)
    {
        // we don't create the first one son they match with the ID integer
        btnModifyCourse[btnNo] = new KitchenButton(btnNo, w, h, cc, c2);
        {
            ref var withBlock = ref btnModifyCourse[btnNo];
            withBlock.Location = new Point(xPos, yPos);
            withBlock.ForeColor = c3;
            this.btnModifyCourse[btnNo].Click += ModifyOrderCourseButton_Click;

            btnModifyCourse[btnNo].ID = btnNo;
        }

        pnlCourse.Controls.Add(btnModifyCourse[btnNo]);

    }

    private void CreateModifyOrderCustomerButton(int btnNo, float xPos, float yPos, float w, float h, Color cc)
    {
        // we don't create the first one son they match with the ID integer
        btnModifyCustomer[btnNo] = new KitchenButton(btnNo, w, h, cc, c2);
        {
            ref var withBlock = ref btnModifyCustomer[btnNo];
            withBlock.Location = new Point(xPos, yPos);
            withBlock.ForeColor = c3;
            this.btnModifyCustomer[btnNo].Click += ModifyOrderCustomerButton_Click;

            btnModifyCustomer[btnNo].ID = btnNo;
        }

        pnlCustomer.Controls.Add(btnModifyCustomer[btnNo]);

    }

    private void ModifyOrderCourseButton_Click(object sender, EventArgs e) // Handles coursePanel.Click
    {

        KitchenButton objButton;
        int index;
        int oldCourse = ModifyCourse;

        try
        {
            objButton = (KitchenButton)sender;
        }
        catch (Exception ex)
        {
            return;
        }
        // If Not objButton.GetType Is btnCourse1.GetType Then Exit Sub

        for (index = 1; index <= 5; index++)
            btnModifyCourse[index].BackColor = c7;
        _modifyCourse = objButton.ID;

        objButton.BackColor = c9;

        if (ModifyCurrentSII != default)
        {
            // this is if it is a main food, therefore we can change the quantity
            foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
            {
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (oRow("sii") == ModifyCurrentSII)
                    {
                        oRow("CourseNumber") = ModifyCourse;
                    }
                }
            }
        }

        AcceptModifySubTotal?.Invoke();
        this.Dispose();

    }

    private void ModifyOrderQuantityButton_Click(object sender, EventArgs e) // Handles coursePanel.Click
    {

        KitchenButton objButton;
        int index;
        int oldQuantity = ModifyQuantity;

        try
        {
            objButton = (KitchenButton)sender;
        }
        catch (Exception ex)
        {
            return;
        }
        // If Not objButton.GetType Is btnCourse1.GetType Then Exit Sub

        for (index = 1; index <= 10; index++)
            btnModifyQuantity[index].BackColor = c7;
        ModifyQuantity = objButton.ID;

        objButton.BackColor = c9;

        if (ModifyCurrentSII != default)
        {
            // this is if it is a main food, therefore we can change the quantity
            foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
            {
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (oRow("sii") == ModifyCurrentSII)
                    {
                        oRow("Quantity") = ModifyQuantity;
                        // the below updates prices for the change
                        oRow("Price") = Strings.Format(oRow("Price") * (ModifyQuantity / (double)oldQuantity), "####0.00");
                        oRow("TaxPrice") = Strings.Format(oRow("TaxPrice") * (ModifyQuantity / (double)oldQuantity), "####0.00");
                        oRow("SinTax") = Strings.Format(oRow("SinTax") * (ModifyQuantity / (double)oldQuantity), "####0.00");
                    }
                }
            }
        }

        AcceptModifySubTotal?.Invoke();
        this.Dispose();

    }

    private void ModifyOrderCustomerButton_Click(object sender, EventArgs e) // Handles coursePanel.Click
    {
        KitchenButton objButton;
        int index;
        var oRow = default(DataRow);
        int newCNTest;

        try
        {
            objButton = (KitchenButton)sender;
        }
        catch (Exception ex)
        {
            return;
        }
        // If Not objButton.GetType Is btnCourse1.GetType Then Exit Sub

        // *** currently not allowing us to change customer number on sub item
        if (!(ModifyCurrentSIN == ModifyCurrentSII))
        {
            CancelModify?.Invoke();
            this.Dispose();
            return;
        }

        for (index = 1; index <= 9; index++)
            btnModifyCustomer[index].BackColor = c7;
        ModifyCustomerNumber = objButton.ID;
        objButton.BackColor = c9;

        newCNTest = GenerateOrderTables.DetermineCnTest(ModifyCustomerNumber);

        if (newCNTest == 0)
        {
            var currentItem = new SelectedItemDetail();
            string custNumString = "               " + ModifyCustomerNumber.ToString() + "   CUSTOMER   " + ModifyCustomerNumber.ToString();

            currentItem.Check = currentTable.CheckNumber;
            currentItem.Customer = ModifyCustomerNumber;
            currentItem.Course = currentTable.CourseNumber;
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

            AddingItemToOrder?.Invoke(currentItem);
            // If currentTable.CustomerNumber <> 1 Then
            // currentTable.EmptyCustPanel = currentTable.CustomerNumber
            // End If
            GenerateOrderTables.CustomerPanelOneTest();


        }

        if (ModifyCurrentSII != default)
        {
            // this is if it is a main food, therefore we can change the quantity
            foreach (DataRow currentORow in dsOrder.Tables("OpenOrders").Rows)
            {
                oRow = currentORow;
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (oRow("sii") == ModifyCurrentSII)
                    {
                        oRow("CustomerNumber") = ModifyCustomerNumber;
                    }
                }
            }
        }

        // I just added this back without knowing ?????
        // RaiseEvent AcceptModifySubTotal()
        // Me.Dispose()
        // Exit Sub

        // *** i think we can get rid of all this
        currentTable.ReferenceSIN = currentTable.SIN;

        // ElseIf newCNTest > 0 Then
        var sinArray = new int[dvModifyOrder.Count + 1];
        var count = default(int);
        // Dim OOnewRow As DataRow = dsOrder.Tables("OpenOrders").NewRow

        foreach (DataRowView vRow in dvModifyOrder)
        {
            // add a new oRow(OOnewRow) for each row in dvModifyOrder and delete old vrow from Table

            // If vRow("sii") = ModifyCurrentSII Then
            if (vRow("CustomerNumber") == ModifyCustomerNumber)
            {
                CopyViewForTransferItem(vRow, vRow("EmployeeID"), vRow("ExperienceNumber"), false, default);

                // dsOrder.Tables("OpenOrders").Rows.Add(OOnewRow)
                // bRow = (dsBackup.Tables("OpenOrdersTerminal").Rows.Find(oRow("sin")))
                // bRow.Delete()
                // oRow.Delete()
                sinArray[count] = vRow("sin");
                count += 1;
                // dsBackup.Tables("OpenOrdersTerminal").AcceptChanges()
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
        }

        AcceptModifySubTotal?.Invoke();
        this.Dispose();

    }


    // sql.cn.Open()
    // If isFoodItem = True Then
    // Dim cmd As New SqlClient.SqlCommand("SELECT Price From MenuJoin WHERE MenuID = '" & currentTable.CurrentMenu & "' AND FoodID = '" & testingFoodID & "'", sql.cn)
    // dtr = cmd.ExecuteReader
    // dtr.Read()
    // originalPrice = (dtr("Price"))
    // Else
    // Dim cmd As New SqlClient.SqlCommand("SELECT DrinkPrice From Drinks WHERE DrinkID = '" & testingFoodID & "'", sql.cn)
    // dtr = cmd.ExecuteReader
    // '           dtr.Read()
    // originalPrice = (dtr("DrinkPrice"))
    // End If
    // dtr.Close()
    // sql.cn.Close()


}