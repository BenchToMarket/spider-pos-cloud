using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public partial class SpecialFood : System.Windows.Forms.UserControl
{

    // Dim messageToKitchen As Boolean
    private string specialPurpose;
    internal bool associateItem;

    private string _itemDescription;
    private decimal _itemPrice;
    private int _associateSIN;
    private int _currentRouting;

    private int _functionID;
    private string _functionFlag;
    private int _functionGroup;

    private int _taxID;
    private int _routingID;
    private int _categoryID;

    private DataView dvAssociateItems;

    private int fRouting;
    private int dRouting;
    private int mRouting;
    private int beerRouting;
    private int wineRouting;
    private int liquorRouting;
    private int naRouting;

    private int fTax;
    private int dTax;
    private int mTax;
    private int beerTax;
    private int wineTax;
    private int liquorTax;
    private int naTax;





    public string ItemDescription
    {
        get
        {
            return _itemDescription;
        }
        set
        {
            _itemDescription = value;
        }
    }

    internal decimal ItemPrice
    {
        get
        {
            return _itemPrice;
        }
        set
        {
            _itemPrice = value;
        }
    }

    internal int AssociateSIN
    {
        get
        {
            return _associateSIN;
        }
        set
        {
            _associateSIN = value;
        }
    }

    internal int CurrentRouting
    {
        get
        {
            return _currentRouting;
        }
        set
        {
            _currentRouting = value;
        }
    }

    internal int FunctionID
    {
        get
        {
            return _functionID;
        }
        set
        {
            _functionID = value;
        }
    }

    internal int FunctionGroup
    {
        get
        {
            return _functionGroup;
        }
        set
        {
            _functionGroup = value;
        }
    }

    internal string FunctionFlag
    {
        get
        {
            return _functionFlag;
        }
        set
        {
            _functionFlag = value;
        }
    }

    internal int TaxID
    {
        get
        {
            return _taxID;
        }
        set
        {
            _taxID = value;
        }
    }

    internal int RoutingID
    {
        get
        {
            return _routingID;
        }
        set
        {
            _routingID = value;
        }
    }

    internal int CategoryID
    {
        get
        {
            return _categoryID;
        }
        set
        {
            _categoryID = value;
        }
    }

    public event UC_HitEventHandler UC_Hit;

    public delegate void UC_HitEventHandler();
    public event CancelSpecialEventHandler CancelSpecial;

    public delegate void CancelSpecialEventHandler(object sender, EventArgs e);
    public event AcceptSpecialEventHandler AcceptSpecial;

    public delegate void AcceptSpecialEventHandler(object sender, EventArgs e);


    #region  Windows Form Designer generated code 

    public SpecialFood(int sin, int sii, bool isDrink, bool assocItem, int currentRouting) : base()
    {

        if (currentRouting != default)
        {
            _currentRouting = currentRouting;
        }
        else
        {
            _currentRouting = 0;
        }

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        InitializeOther(sin, sii, isDrink, assocItem);


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
    private DataSet_Builder.NumberPadSmall _NumberPadSmall1;

    internal virtual DataSet_Builder.NumberPadSmall NumberPadSmall1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _NumberPadSmall1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_NumberPadSmall1 != null)
            {
                _NumberPadSmall1.NumberChanged -= ItemPriceChanged;
            }

            _NumberPadSmall1 = value;
            if (_NumberPadSmall1 != null)
            {
                _NumberPadSmall1.NumberChanged += ItemPriceChanged;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnOpenFood;

    internal virtual Global.System.Windows.Forms.Button btnOpenFood
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnOpenFood;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnOpenFood != null)
            {
                _btnOpenFood.Click -= btnOpenFood_Click;
            }

            _btnOpenFood = value;
            if (_btnOpenFood != null)
            {
                _btnOpenFood.Click += btnOpenFood_Click;
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
    private Global.System.Windows.Forms.Button _btnMessage;

    internal virtual Global.System.Windows.Forms.Button btnMessage
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnMessage;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnMessage != null)
            {
                _btnMessage.Click -= btnMessage_Click;
            }

            _btnMessage = value;
            if (_btnMessage != null)
            {
                _btnMessage.Click += btnMessage_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _pnlAssociateItem;

    internal virtual Global.System.Windows.Forms.Panel pnlAssociateItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlAssociateItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlAssociateItem = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnItemSeperate;

    internal virtual Global.System.Windows.Forms.Button btnItemSeperate
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnItemSeperate;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnItemSeperate != null)
            {
                _btnItemSeperate.Click -= btnItemSeperate_Click;
            }

            _btnItemSeperate = value;
            if (_btnItemSeperate != null)
            {
                _btnItemSeperate.Click += btnItemSeperate_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnItemAssociation;

    internal virtual Global.System.Windows.Forms.Button btnItemAssociation
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnItemAssociation;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnItemAssociation != null)
            {
                _btnItemAssociation.Click -= btnItemAssociation_Click;
            }

            _btnItemAssociation = value;
            if (_btnItemAssociation != null)
            {
                _btnItemAssociation.Click += btnItemAssociation_Click;
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
    private Global.System.Windows.Forms.Label _lblItem;

    internal virtual Global.System.Windows.Forms.Label lblItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblItem = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblTextItem;

    internal virtual Global.System.Windows.Forms.Label lblTextItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTextItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblTextItem = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblPrice;

    internal virtual Global.System.Windows.Forms.Label lblPrice
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPrice;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblPrice = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblTextPrice;

    internal virtual Global.System.Windows.Forms.Label lblTextPrice
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTextPrice;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblTextPrice = value;
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
    private Global.System.Windows.Forms.ListView _lstAssociateItem;

    internal virtual Global.System.Windows.Forms.ListView lstAssociateItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lstAssociateItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lstAssociateItem != null)
            {
                _lstAssociateItem.SelectedIndexChanged -= lstAssociateItem_SelectedIndexChanged;
            }

            _lstAssociateItem = value;
            if (_lstAssociateItem != null)
            {
                _lstAssociateItem.SelectedIndexChanged += lstAssociateItem_SelectedIndexChanged;
            }
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _ItemName;

    internal virtual Global.System.Windows.Forms.ColumnHeader ItemName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ItemName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _ItemName = value;
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _ItemSIN;

    internal virtual Global.System.Windows.Forms.ColumnHeader ItemSIN
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _ItemSIN;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _ItemSIN = value;
        }
    }
    private DataSet_Builder.KeyBoard_UC _SpecialKeyboard;

    internal virtual DataSet_Builder.KeyBoard_UC SpecialKeyboard
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SpecialKeyboard;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SpecialKeyboard != null)
            {
                _SpecialKeyboard.StringChanged -= ItemDescriptionChanged;
            }

            _SpecialKeyboard = value;
            if (_SpecialKeyboard != null)
            {
                _SpecialKeyboard.StringChanged += ItemDescriptionChanged;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnOpenDrink;

    internal virtual Global.System.Windows.Forms.Button btnOpenDrink
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnOpenDrink;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnOpenDrink != null)
            {
                _btnOpenDrink.Click -= btnOpenDrink_Click;
            }

            _btnOpenDrink = value;
            if (_btnOpenDrink != null)
            {
                _btnOpenDrink.Click += btnOpenDrink_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnNonAlc;

    internal virtual Global.System.Windows.Forms.Button btnNonAlc
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnNonAlc;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnNonAlc != null)
            {
                _btnNonAlc.Click -= btnNonAlc_Click;
            }

            _btnNonAlc = value;
            if (_btnNonAlc != null)
            {
                _btnNonAlc.Click += btnNonAlc_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnBeer;

    internal virtual Global.System.Windows.Forms.Button btnBeer
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnBeer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnBeer != null)
            {
                _btnBeer.Click -= btnBeer_Click;
            }

            _btnBeer = value;
            if (_btnBeer != null)
            {
                _btnBeer.Click += btnBeer_Click;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _NumberPadSmall1 = new DataSet_Builder.NumberPadSmall();
        _NumberPadSmall1.NumberChanged += ItemPriceChanged;
        _btnOpenFood = new System.Windows.Forms.Button();
        _btnOpenFood.Click += btnOpenFood_Click;
        _btnMessage = new System.Windows.Forms.Button();
        _btnMessage.Click += btnMessage_Click;
        _Panel1 = new System.Windows.Forms.Panel();
        _pnlAssociateItem = new System.Windows.Forms.Panel();
        _btnBeer = new System.Windows.Forms.Button();
        _btnBeer.Click += btnBeer_Click;
        _btnNonAlc = new System.Windows.Forms.Button();
        _btnNonAlc.Click += btnNonAlc_Click;
        _lstAssociateItem = new System.Windows.Forms.ListView();
        _lstAssociateItem.SelectedIndexChanged += lstAssociateItem_SelectedIndexChanged;
        _ItemName = new System.Windows.Forms.ColumnHeader();
        _ItemSIN = new System.Windows.Forms.ColumnHeader();
        _btnItemAssociation = new System.Windows.Forms.Button();
        _btnItemAssociation.Click += btnItemAssociation_Click;
        _btnItemSeperate = new System.Windows.Forms.Button();
        _btnItemSeperate.Click += btnItemSeperate_Click;
        _Panel3 = new System.Windows.Forms.Panel();
        _btnCancel = new System.Windows.Forms.Button();
        _btnCancel.Click += btnCancel_Click;
        _btnAccept = new System.Windows.Forms.Button();
        _btnAccept.Click += btnAccept_Click;
        _lblTextPrice = new System.Windows.Forms.Label();
        _lblPrice = new System.Windows.Forms.Label();
        _lblTextItem = new System.Windows.Forms.Label();
        _lblItem = new System.Windows.Forms.Label();
        _SpecialKeyboard = new DataSet_Builder.KeyBoard_UC();
        _SpecialKeyboard.StringChanged += ItemDescriptionChanged;
        _btnOpenDrink = new System.Windows.Forms.Button();
        _btnOpenDrink.Click += btnOpenDrink_Click;
        _Panel1.SuspendLayout();
        _pnlAssociateItem.SuspendLayout();
        _Panel3.SuspendLayout();
        this.SuspendLayout();
        // 
        // NumberPadSmall1
        // 
        _NumberPadSmall1.BackColor = System.Drawing.Color.SlateGray;
        _NumberPadSmall1.DecimalUsed = false;
        _NumberPadSmall1.IntegerNumber = 0;
        _NumberPadSmall1.Location = new System.Drawing.Point(568, 32);
        _NumberPadSmall1.Name = "_NumberPadSmall1";
        _NumberPadSmall1.NumberString = (object)null;
        _NumberPadSmall1.NumberTotal = new decimal(new int[] { 0, 0, 0, 0 });
        _NumberPadSmall1.Size = new System.Drawing.Size(144, 240);
        _NumberPadSmall1.TabIndex = 1;
        // 
        // btnOpenFood
        // 
        _btnOpenFood.BackColor = System.Drawing.Color.SlateGray;
        _btnOpenFood.Location = new System.Drawing.Point(32, 8);
        _btnOpenFood.Name = "_btnOpenFood";
        _btnOpenFood.Size = new System.Drawing.Size(104, 40);
        _btnOpenFood.TabIndex = 2;
        _btnOpenFood.Text = "Open Food";
        // 
        // btnMessage
        // 
        _btnMessage.BackColor = System.Drawing.Color.SlateGray;
        _btnMessage.Location = new System.Drawing.Point(256, 8);
        _btnMessage.Name = "_btnMessage";
        _btnMessage.Size = new System.Drawing.Size(112, 40);
        _btnMessage.TabIndex = 3;
        _btnMessage.Text = "Message to Kitchen";
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.Color.SlateGray;
        _Panel1.Controls.Add(_pnlAssociateItem);
        _Panel1.Location = new System.Drawing.Point(32, 56);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(336, 224);
        _Panel1.TabIndex = 4;
        // 
        // pnlAssociateItem
        // 
        _pnlAssociateItem.Controls.Add(_btnBeer);
        _pnlAssociateItem.Controls.Add(_btnNonAlc);
        _pnlAssociateItem.Controls.Add(_lstAssociateItem);
        _pnlAssociateItem.Controls.Add(_btnItemAssociation);
        _pnlAssociateItem.Controls.Add(_btnItemSeperate);
        _pnlAssociateItem.Location = new System.Drawing.Point(8, 8);
        _pnlAssociateItem.Name = "_pnlAssociateItem";
        _pnlAssociateItem.Size = new System.Drawing.Size(320, 224);
        _pnlAssociateItem.TabIndex = 4;
        // 
        // btnBeer
        // 
        _btnBeer.Location = new System.Drawing.Point(232, 112);
        _btnBeer.Name = "_btnBeer";
        _btnBeer.Size = new System.Drawing.Size(88, 40);
        _btnBeer.TabIndex = 7;
        _btnBeer.Text = "Beer";
        _btnBeer.Visible = false;
        // 
        // btnNonAlc
        // 
        _btnNonAlc.Location = new System.Drawing.Point(232, 168);
        _btnNonAlc.Name = "_btnNonAlc";
        _btnNonAlc.Size = new System.Drawing.Size(88, 40);
        _btnNonAlc.TabIndex = 6;
        _btnNonAlc.Text = "Non - Alcoholic";
        _btnNonAlc.Visible = false;
        // 
        // lstAssociateItem
        // 
        _lstAssociateItem.BackColor = System.Drawing.Color.SlateGray;
        _lstAssociateItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { _ItemName, _ItemSIN });
        _lstAssociateItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lstAssociateItem.FullRowSelect = true;
        _lstAssociateItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        _lstAssociateItem.Location = new System.Drawing.Point(0, 0);
        _lstAssociateItem.Name = "_lstAssociateItem";
        _lstAssociateItem.Size = new System.Drawing.Size(224, 208);
        _lstAssociateItem.TabIndex = 1;
        _lstAssociateItem.View = System.Windows.Forms.View.Details;
        // 
        // ItemName
        // 
        _ItemName.Width = 200;
        // 
        // ItemSIN
        // 
        _ItemSIN.Width = 0;
        // 
        // btnItemAssociation
        // 
        _btnItemAssociation.BackColor = System.Drawing.Color.SlateGray;
        _btnItemAssociation.Location = new System.Drawing.Point(232, 0);
        _btnItemAssociation.Name = "_btnItemAssociation";
        _btnItemAssociation.Size = new System.Drawing.Size(88, 40);
        _btnItemAssociation.TabIndex = 0;
        _btnItemAssociation.Text = "Associate Item";
        // 
        // btnItemSeperate
        // 
        _btnItemSeperate.BackColor = System.Drawing.Color.Red;
        _btnItemSeperate.Location = new System.Drawing.Point(232, 56);
        _btnItemSeperate.Name = "_btnItemSeperate";
        _btnItemSeperate.Size = new System.Drawing.Size(88, 40);
        _btnItemSeperate.TabIndex = 5;
        _btnItemSeperate.Text = "Seperate Item";
        // 
        // Panel3
        // 
        _Panel3.BackColor = System.Drawing.Color.SlateGray;
        _Panel3.Controls.Add(_btnCancel);
        _Panel3.Controls.Add(_btnAccept);
        _Panel3.Controls.Add(_lblTextPrice);
        _Panel3.Controls.Add(_lblPrice);
        _Panel3.Controls.Add(_lblTextItem);
        _Panel3.Controls.Add(_lblItem);
        _Panel3.Location = new System.Drawing.Point(384, 32);
        _Panel3.Name = "_Panel3";
        _Panel3.Size = new System.Drawing.Size(168, 240);
        _Panel3.TabIndex = 5;
        // 
        // btnCancel
        // 
        _btnCancel.Location = new System.Drawing.Point(24, 8);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.Size = new System.Drawing.Size(120, 24);
        _btnCancel.TabIndex = 5;
        _btnCancel.Text = "Cancel";
        // 
        // btnAccept
        // 
        _btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnAccept.Location = new System.Drawing.Point(16, 192);
        _btnAccept.Name = "_btnAccept";
        _btnAccept.Size = new System.Drawing.Size(136, 40);
        _btnAccept.TabIndex = 4;
        _btnAccept.Text = "Accept";
        // 
        // lblTextPrice
        // 
        _lblTextPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblTextPrice.ForeColor = System.Drawing.Color.Red;
        _lblTextPrice.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
        _lblTextPrice.Location = new System.Drawing.Point(56, 152);
        _lblTextPrice.Name = "_lblTextPrice";
        _lblTextPrice.Size = new System.Drawing.Size(96, 24);
        _lblTextPrice.TabIndex = 3;
        _lblTextPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblPrice
        // 
        _lblPrice.Location = new System.Drawing.Point(8, 128);
        _lblPrice.Name = "_lblPrice";
        _lblPrice.Size = new System.Drawing.Size(104, 16);
        _lblPrice.TabIndex = 2;
        _lblPrice.Text = "Price:";
        // 
        // lblTextItem
        // 
        _lblTextItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblTextItem.ForeColor = System.Drawing.Color.Red;
        _lblTextItem.Location = new System.Drawing.Point(24, 88);
        _lblTextItem.Name = "_lblTextItem";
        _lblTextItem.Size = new System.Drawing.Size(128, 24);
        _lblTextItem.TabIndex = 1;
        _lblTextItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblItem
        // 
        _lblItem.Location = new System.Drawing.Point(8, 64);
        _lblItem.Name = "_lblItem";
        _lblItem.Size = new System.Drawing.Size(100, 16);
        _lblItem.TabIndex = 0;
        _lblItem.Text = "Item Description:";
        // 
        // SpecialKeyboard
        // 
        _SpecialKeyboard.BackColor = System.Drawing.Color.SlateGray;
        _SpecialKeyboard.EnteredString = (object)null;
        _SpecialKeyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _SpecialKeyboard.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _SpecialKeyboard.Location = new System.Drawing.Point(32, 296);
        _SpecialKeyboard.Name = "_SpecialKeyboard";
        _SpecialKeyboard.Size = new System.Drawing.Size(680, 296);
        _SpecialKeyboard.TabIndex = 6;
        // 
        // btnOpenDrink
        // 
        _btnOpenDrink.BackColor = System.Drawing.Color.SlateGray;
        _btnOpenDrink.Location = new System.Drawing.Point(144, 8);
        _btnOpenDrink.Name = "_btnOpenDrink";
        _btnOpenDrink.Size = new System.Drawing.Size(104, 40);
        _btnOpenDrink.TabIndex = 7;
        _btnOpenDrink.Text = "Open Drink";
        // 
        // SpecialFood
        // 
        this.BackColor = System.Drawing.Color.FromArgb(59, 96, 141);
        this.Controls.Add(_btnOpenDrink);
        this.Controls.Add(_SpecialKeyboard);
        this.Controls.Add(_Panel3);
        this.Controls.Add(_Panel1);
        this.Controls.Add(_NumberPadSmall1);
        this.Controls.Add(_btnOpenFood);
        this.Controls.Add(_btnMessage);
        this.Name = "SpecialFood";
        this.Size = new System.Drawing.Size(744, 600);
        _Panel1.ResumeLayout(false);
        _pnlAssociateItem.ResumeLayout(false);
        _Panel3.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private void InitializeOther(int sin, int sii, bool isDrink, bool assocItem)
    {

        NumberPadSmall1.DecimalUsed = true;
        SpecialKeyboard.EnteredString = "";
        AssociateSIN = sin;
        foreach (DataRow oRow in dsOrder.Tables("Functions").Rows)
        {
            if (oRow("FunctionName") == "Open Food")
            {
                if (!object.ReferenceEquals(oRow("DrinkRoutingID"), DBNull.Value))
                {
                    fRouting = oRow("DrinkRoutingID");
                }
                else
                {
                    fRouting = 0;
                }
            }

            else if (oRow("FunctionName") == "Open Drink")
            {
                if (!object.ReferenceEquals(oRow("DrinkRoutingID"), DBNull.Value))
                {
                    dRouting = oRow("DrinkRoutingID");
                }
                else
                {
                    dRouting = 0;
                }
            }

            else if (oRow("FunctionName") == "Special Message")
            {
                if (!object.ReferenceEquals(oRow("DrinkRoutingID"), DBNull.Value))
                {
                    mRouting = oRow("DrinkRoutingID");
                }
                else
                {
                    mRouting = 0;
                }
            }

        }


        if (isDrink == true & companyInfo.servesMixedDrinks == true)
        {
            ThisIsOpenDrink();
        }

        else
        {
            if (CurrentRouting == 0)
            {
                CurrentRouting = fRouting;
            }
            _functionGroup = 1;
            _functionFlag = "F";
            _routingID = CurrentRouting;
            specialPurpose = "Food";
            btnOpenFood.BackColor = Color.Red;

        }

        if (assocItem == false)
        {
            associateItem = false;
        }
        else
        {
            associateItem = true;
            btnItemAssociation.BackColor = Color.Red;
            btnItemSeperate.BackColor = Color.SlateGray;
        }

        FillAssociateListView(sin, sii, isDrink);

    }

    // ****************
    // maybe we should just fill the main items since that's all we can add under

    private void FillAssociateListView(int sin, int sii, bool isDrink)
    {

        foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("sii") == oRow("sin"))                       // sii Then
                {
                    // add to list view if oRow("sii") = sii
                    var item = new ListViewItem();
                    item.Text = oRow("ItemName");    // col 0
                    item.SubItems.Add(oRow("sii"));  // col 1
                    item.SubItems.Add(oRow("RoutingID"));    // col 2

                    if (associateItem == true)
                    {
                        if (oRow("sin") == sii)                           // sin Then
                        {
                            // change color and make default assoc. item
                            _associateSIN = oRow("sii");
                            _currentRouting = oRow("RoutingID"); // ****not sure about this
                            item.ForeColor = Color.Red;
                        }
                    }

                    lstAssociateItem.Items.Add(item);
                }
            }
        }

    }

    private void btnOpenFood_Click(object sender, EventArgs e)
    {
        UC_Hit?.Invoke();

        specialPurpose = "Food";

        if (associateItem == true)
        {
            _functionGroup = 1;
            _functionFlag = "F";

            // _functionID = 2
            _routingID = CurrentRouting;
        }
        else
        {
            _functionGroup = 10;
            _functionFlag = "O";

            // _functionID = 1
            _routingID = fRouting;
        }

        ResetButtonColors();
        if (associateItem == true)
        {
            btnItemAssociation.BackColor = Color.Red;
        }
        else
        {
            btnItemSeperate.BackColor = Color.Red;
        }

        btnItemAssociation.Text = "Associate Item";
        btnItemSeperate.Text = "Seperate Item";
        btnNonAlc.Visible = false;
        btnBeer.Visible = false;

        btnOpenFood.BackColor = Color.Red;
        btnOpenDrink.BackColor = Color.SlateGray;
        btnMessage.BackColor = Color.SlateGray;
        NumberPadSmall1.Enabled = true;

    }

    private void btnOpenDrink_Click(object sender, EventArgs e)
    {

        UC_Hit?.Invoke();
        ThisIsOpenDrink();

    }

    private void ThisIsOpenDrink()
    {
        if (associateItem == true)
        {
            _routingID = CurrentRouting;
        }
        else if (!(specialPurpose == "Drink"))
        {
            // if already Drink then we keep function the same
            _routingID = dRouting;
        }

        _functionGroup = 4;      // *** this is coding for Liquor..wil nedd to change
        _functionFlag = "D";

        specialPurpose = "Drink";

        btnItemAssociation.Text = "Liquor";
        btnItemSeperate.Text = "Wine";
        btnNonAlc.Visible = true;
        btnBeer.Visible = true;

        ResetButtonColors();
        btnItemAssociation.BackColor = Color.Red;
        btnOpenDrink.BackColor = Color.Red;
        btnOpenFood.BackColor = Color.SlateGray;
        btnMessage.BackColor = Color.SlateGray;
        NumberPadSmall1.Enabled = true;

    }
    private void btnMessage_Click(object sender, EventArgs e)
    {
        UC_Hit?.Invoke();

        specialPurpose = "Message";
        if (associateItem == true)
        {
            // _functionID = 3
            _routingID = CurrentRouting;
        }
        else                    // should probably always be assoc.??
        {
            // _functionID = 1
            _routingID = mRouting;
        }

        _functionFlag = "O";
        _functionGroup = 8;

        btnItemAssociation.Text = "Associate Item";
        btnItemSeperate.Text = "Seperate Item";
        btnNonAlc.Visible = false;
        btnBeer.Visible = false;

        btnOpenFood.BackColor = Color.SlateGray;
        btnOpenDrink.BackColor = Color.SlateGray;
        btnMessage.BackColor = Color.Red;
        NumberPadSmall1.Enabled = false;
        lblPrice.Text = (object)null;
        _itemPrice = default;

    }

    private void btnItemAssociation_Click(object sender, EventArgs e)
    {
        UC_Hit?.Invoke();

        associateItem = true;
        ResetButtonColors();
        btnItemAssociation.BackColor = Color.Red;

        if (specialPurpose == "Message")
        {
            _functionGroup = 8;
        }
        else if (specialPurpose == "Food")
        {
            _functionGroup = 1;
        }
        else if (specialPurpose == "Drink")
        {
            // this is for the Liquor button
            _functionGroup = 4;
        }

    }

    private void btnItemSeperate_Click(object sender, EventArgs e)
    {
        UC_Hit?.Invoke();

        associateItem = false;
        _associateSIN = default;
        ResetButtonColors();
        btnItemSeperate.BackColor = Color.Red;
        foreach (ListViewItem sItem in lstAssociateItem.Items)
            sItem.ForeColor = Color.Black;

        if (specialPurpose == "Message")
        {
            _functionGroup = 8;
        }
        else if (specialPurpose == "Food")
        {
            _functionGroup = 1;
        }
        else if (specialPurpose == "Drink")
        {
            // this is for the Wine button
            _functionGroup = 3;  // 4
        }

    }

    private void btnNonAlc_Click(object sender, EventArgs e)
    {
        UC_Hit?.Invoke();

        _functionGroup = 5;
        ResetButtonColors();
        btnNonAlc.BackColor = Color.Red;

    }

    private void btnBeer_Click(object sender, EventArgs e)
    {
        UC_Hit?.Invoke();

        _functionGroup = 2;
        ResetButtonColors();
        btnBeer.BackColor = Color.Red;

    }

    private void ResetButtonColors()
    {

        btnBeer.BackColor = Color.SlateGray;
        btnNonAlc.BackColor = Color.SlateGray;
        btnItemAssociation.BackColor = Color.SlateGray;
        btnItemSeperate.BackColor = Color.SlateGray;
    }

    private void lstAssociateItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        UC_Hit?.Invoke();

        foreach (ListViewItem sItem in lstAssociateItem.Items)
        {

            if (sItem.Selected == true)
            {
                _associateSIN = sItem.SubItems(1).Text;
                _currentRouting = sItem.SubItems(2).Text;
                sItem.ForeColor = Color.Red;
            }
            else
            {
                sItem.ForeColor = Color.Black;
            }
        }

        btnItemAssociation_Click(sender, e);

    }

    private void ItemDescriptionChanged()
    {
        UC_Hit?.Invoke();

        lblTextItem.Text = SpecialKeyboard.EnteredString;
        ItemDescription = SpecialKeyboard.EnteredString;

    }

    private void ItemPriceChanged()
    {
        UC_Hit?.Invoke();

        lblTextPrice.Text = NumberPadSmall1.NumberTotal;
        ItemPrice = NumberPadSmall1.NumberTotal;

    }

    private void btnCancel_Click(object sender, EventArgs e)
    {

        CancelSpecial?.Invoke(sender, e);

        this.Dispose();

    }

    private void btnAccept_Click(object sender, EventArgs e)
    {

        if (associateItem == false)
        {
            AssociateSIN = default;
        }

        AcceptSpecial?.Invoke(sender, e);

    }



}