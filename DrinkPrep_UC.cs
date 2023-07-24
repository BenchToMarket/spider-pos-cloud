using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using DataSet_Builder;


public partial class DrinkPrep_UC : System.Windows.Forms.UserControl
{

    private int modifierIndex;
    private int prepIndex;
    private int _drinkCatID;
    private int _drinkID;
    private int _drinkRoute;
    private int _drinkFunctionID;
    private int _drinkFunGroup;

    private int _foodCatID;
    private int _foodID;
    private int _foodRoute;
    private int _foodFunctionID;
    private int _foodFunGroup;
    private int _modifierCatID;

    private int _selectedRawItemID;
    private string _selectedRawItemName;
    private decimal _selectedRawPriceTotal;
    private int _selectedRawTrackAs;

    private int _associateSIN;
    private string whatWereDoing;
    private bool isForDrink;
    private int maxmenuindex;
    private bool isExtended;


    public int DrinkCatID
    {
        get
        {
            return _drinkCatID;
        }
        set
        {
            _drinkCatID = value;
        }
    }

    public int DrinkID
    {
        get
        {
            return _drinkID;
        }
        set
        {
            _drinkID = value;
        }
    }

    public int DrinkRoute
    {
        get
        {
            return _drinkRoute;
        }
        set
        {
            _drinkRoute = value;
        }
    }

    public int DrinkFuctionID
    {
        get
        {
            return _drinkFunctionID;
        }
        set
        {
            _drinkFunctionID = value;
        }
    }

    public int DrinkFunGroup
    {
        get
        {
            return _drinkFunGroup;
        }
        set
        {
            _drinkFunGroup = value;
        }
    }

    public int FoodCatID
    {
        get
        {
            return _foodCatID;
        }
        set
        {
            _foodCatID = value;
        }
    }

    public int FoodID
    {
        get
        {
            return _foodID;
        }
        set
        {
            _foodID = value;
        }
    }

    public int FoodRoute
    {
        get
        {
            return _foodRoute;
        }
        set
        {
            _foodRoute = value;
        }
    }

    public int FoodFuctionID
    {
        get
        {
            return _foodFunctionID;
        }
        set
        {
            _foodFunctionID = value;
        }
    }

    public int FoodFunGroup
    {
        get
        {
            return _foodFunGroup;
        }
        set
        {
            _foodFunGroup = value;
        }
    }

    public int ModifierCatID
    {
        get
        {
            return _modifierCatID;
        }
        set
        {
            _modifierCatID = value;
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

    public int AssociateSIN
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

    private OrderButton[] btnOrderDrinkAdds = new OrderButton[33];
    private Global.System.Windows.Forms.Panel _pnlExtraNo;

    internal virtual Global.System.Windows.Forms.Panel pnlExtraNo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlExtraNo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlExtraNo = value;
        }
    }
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
    private OrderButton[] btnOrderDrinkPrep = new OrderButton[33];


    public event AcceptPrepEventHandler AcceptPrep;

    public delegate void AcceptPrepEventHandler(SelectedItemDetail currentItem);
    public event CancelEventHandler Cancel;

    public delegate void CancelEventHandler();



    #region  Windows Form Designer generated code 

    public DrinkPrep_UC() : base()
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        CreateOrderDrinkButtonArray();
        CreateOrderDrinkPrepArray();

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
    private Global.System.Windows.Forms.Button _btnAdd;

    internal virtual Global.System.Windows.Forms.Button btnAdd
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnAdd;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnAdd != null)
            {
                _btnAdd.Click -= btnAdd_Click;
            }

            _btnAdd = value;
            if (_btnAdd != null)
            {
                _btnAdd.Click += btnAdd_Click;
            }
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
    private Global.System.Windows.Forms.Panel _pnlModifiers;

    internal virtual Global.System.Windows.Forms.Panel pnlModifiers
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlModifiers;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlModifiers = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlChangeModifiers;

    internal virtual Global.System.Windows.Forms.Panel pnlChangeModifiers
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlChangeModifiers;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlChangeModifiers = value;
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
    private Global.System.Windows.Forms.Panel _Panel4;

    internal virtual Global.System.Windows.Forms.Panel Panel4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel4 = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblPrep;

    internal virtual Global.System.Windows.Forms.Label lblPrep
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblPrep;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblPrep = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnDone;

    internal virtual Global.System.Windows.Forms.Button btnDone
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDone;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnDone != null)
            {
                _btnDone.Click -= btnDone_Click;
            }

            _btnDone = value;
            if (_btnDone != null)
            {
                _btnDone.Click += btnDone_Click;
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
    private Global.System.Windows.Forms.Button _btnModifierDown;

    internal virtual Global.System.Windows.Forms.Button btnModifierDown
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnModifierDown;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnModifierDown != null)
            {
                _btnModifierDown.Click -= btnModifierDown_Click;
            }

            _btnModifierDown = value;
            if (_btnModifierDown != null)
            {
                _btnModifierDown.Click += btnModifierDown_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnModifierUp;

    internal virtual Global.System.Windows.Forms.Button btnModifierUp
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnModifierUp;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnModifierUp != null)
            {
                _btnModifierUp.Click -= btnModifierUp_Click;
            }

            _btnModifierUp = value;
            if (_btnModifierUp != null)
            {
                _btnModifierUp.Click += btnModifierUp_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _pnlModiferiArrows;

    internal virtual Global.System.Windows.Forms.Panel pnlModiferiArrows
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlModiferiArrows;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlModiferiArrows = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlPrep;

    internal virtual Global.System.Windows.Forms.Panel pnlPrep
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlPrep;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlPrep = value;
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
    private Global.System.Windows.Forms.Button _btnPrepDown;

    internal virtual Global.System.Windows.Forms.Button btnPrepDown
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnPrepDown;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnPrepDown != null)
            {
                _btnPrepDown.Click -= btnPrepDown_Click;
            }

            _btnPrepDown = value;
            if (_btnPrepDown != null)
            {
                _btnPrepDown.Click += btnPrepDown_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnPrepUp;

    internal virtual Global.System.Windows.Forms.Button btnPrepUp
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnPrepUp;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnPrepUp != null)
            {
                _btnPrepUp.Click -= btnPrepUp_Click;
            }

            _btnPrepUp = value;
            if (_btnPrepUp != null)
            {
                _btnPrepUp.Click += btnPrepUp_Click;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(DrinkPrep_UC));
        _Panel1 = new System.Windows.Forms.Panel();
        _pnlPrep = new System.Windows.Forms.Panel();
        _Panel4 = new System.Windows.Forms.Panel();
        _Panel3 = new System.Windows.Forms.Panel();
        _btnPrepDown = new System.Windows.Forms.Button();
        _btnPrepDown.Click += btnPrepDown_Click;
        _btnPrepUp = new System.Windows.Forms.Button();
        _btnPrepUp.Click += btnPrepUp_Click;
        _lblPrep = new System.Windows.Forms.Label();
        _pnlModifiers = new System.Windows.Forms.Panel();
        _pnlExtraNo = new System.Windows.Forms.Panel();
        _lstIngredientsAll = new System.Windows.Forms.ListView();
        _lstAllBreak = new System.Windows.Forms.ColumnHeader();
        _lstAllUnit = new System.Windows.Forms.ColumnHeader();
        _lstAllItemName = new System.Windows.Forms.ColumnHeader();
        _lstIngredientsExtraNo = new System.Windows.Forms.ListView();
        _lstIngredientsExtraNo.Click += lstIngredientsExtraNo_SelectedIndexChanged;
        _cRawItemID = new System.Windows.Forms.ColumnHeader();
        _cRawItemName = new System.Windows.Forms.ColumnHeader();
        _cRawPriceTotal = new System.Windows.Forms.ColumnHeader();
        _cRawTrackAs = new System.Windows.Forms.ColumnHeader();
        _pnlChangeModifiers = new System.Windows.Forms.Panel();
        _Label1 = new System.Windows.Forms.Label();
        _pnlModiferiArrows = new System.Windows.Forms.Panel();
        _btnModifierDown = new System.Windows.Forms.Button();
        _btnModifierDown.Click += btnModifierDown_Click;
        _btnModifierUp = new System.Windows.Forms.Button();
        _btnModifierUp.Click += btnModifierUp_Click;
        _Panel2 = new System.Windows.Forms.Panel();
        _btnDone = new System.Windows.Forms.Button();
        _btnDone.Click += btnDone_Click;
        _btnNo = new System.Windows.Forms.Button();
        _btnNo.Click += btnNo_Click;
        _btnExtra = new System.Windows.Forms.Button();
        _btnExtra.Click += btnExtra_Click;
        _btnAdd = new System.Windows.Forms.Button();
        _btnAdd.Click += btnAdd_Click;
        _Label3 = new System.Windows.Forms.Label();
        _Panel1.SuspendLayout();
        _pnlPrep.SuspendLayout();
        _Panel4.SuspendLayout();
        _Panel3.SuspendLayout();
        _pnlModifiers.SuspendLayout();
        _pnlExtraNo.SuspendLayout();
        _pnlChangeModifiers.SuspendLayout();
        _pnlModiferiArrows.SuspendLayout();
        _Panel2.SuspendLayout();
        this.SuspendLayout();
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.Color.Black;
        _Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        _Panel1.Controls.Add(_pnlPrep);
        _Panel1.Controls.Add(_pnlModifiers);
        _Panel1.Controls.Add(_Panel2);
        _Panel1.Location = new System.Drawing.Point(4, 4);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(560, 552);
        _Panel1.TabIndex = 0;
        // 
        // pnlPrep
        // 
        _pnlPrep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _pnlPrep.Controls.Add(_Panel4);
        _pnlPrep.Location = new System.Drawing.Point(368, 4);
        _pnlPrep.Name = "_pnlPrep";
        _pnlPrep.Size = new System.Drawing.Size(189, 480);
        _pnlPrep.TabIndex = 2;
        // 
        // Panel4
        // 
        _Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _Panel4.Controls.Add(_Panel3);
        _Panel4.Controls.Add(_lblPrep);
        _Panel4.Location = new System.Drawing.Point(0, 0);
        _Panel4.Name = "_Panel4";
        _Panel4.Size = new System.Drawing.Size(188, 48);
        _Panel4.TabIndex = 0;
        // 
        // Panel3
        // 
        _Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _Panel3.Controls.Add(_btnPrepDown);
        _Panel3.Controls.Add(_btnPrepUp);
        _Panel3.Location = new System.Drawing.Point(88, 0);
        _Panel3.Name = "_Panel3";
        _Panel3.Size = new System.Drawing.Size(96, 48);
        _Panel3.TabIndex = 2;
        // 
        // btnPrepDown
        // 
        _btnPrepDown.BackColor = System.Drawing.Color.CornflowerBlue;
        _btnPrepDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnPrepDown.Image = (Global.System.Drawing.Image)resources.GetObject("btnPrepDown.Image");
        _btnPrepDown.Location = new System.Drawing.Point(4, 0);
        _btnPrepDown.Name = "_btnPrepDown";
        _btnPrepDown.Size = new System.Drawing.Size(40, 40);
        _btnPrepDown.TabIndex = 1;
        _btnPrepDown.UseVisualStyleBackColor = false;
        // 
        // btnPrepUp
        // 
        _btnPrepUp.BackColor = System.Drawing.Color.CornflowerBlue;
        _btnPrepUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnPrepUp.Image = (Global.System.Drawing.Image)resources.GetObject("btnPrepUp.Image");
        _btnPrepUp.Location = new System.Drawing.Point(48, 0);
        _btnPrepUp.Name = "_btnPrepUp";
        _btnPrepUp.Size = new System.Drawing.Size(40, 40);
        _btnPrepUp.TabIndex = 2;
        _btnPrepUp.UseVisualStyleBackColor = false;
        // 
        // lblPrep
        // 
        _lblPrep.Font = new System.Drawing.Font("Cambria", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblPrep.ForeColor = System.Drawing.Color.White;
        _lblPrep.Location = new System.Drawing.Point(12, 12);
        _lblPrep.Name = "_lblPrep";
        _lblPrep.Size = new System.Drawing.Size(68, 24);
        _lblPrep.TabIndex = 0;
        _lblPrep.Text = "Prep";
        _lblPrep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pnlModifiers
        // 
        _pnlModifiers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _pnlModifiers.Controls.Add(_pnlExtraNo);
        _pnlModifiers.Controls.Add(_pnlChangeModifiers);
        _pnlModifiers.Location = new System.Drawing.Point(4, 4);
        _pnlModifiers.Name = "_pnlModifiers";
        _pnlModifiers.Size = new System.Drawing.Size(360, 480);
        _pnlModifiers.TabIndex = 1;
        // 
        // pnlExtraNo
        // 
        _pnlExtraNo.Controls.Add(_Label3);
        _pnlExtraNo.Controls.Add(_lstIngredientsAll);
        _pnlExtraNo.Controls.Add(_lstIngredientsExtraNo);
        _pnlExtraNo.Location = new System.Drawing.Point(3, 52);
        _pnlExtraNo.Name = "_pnlExtraNo";
        _pnlExtraNo.Size = new System.Drawing.Size(350, 421);
        _pnlExtraNo.TabIndex = 1;
        // 
        // lstIngredientsAll
        // 
        _lstIngredientsAll.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
        _lstIngredientsAll.BackColor = System.Drawing.Color.LightSlateGray;
        _lstIngredientsAll.BorderStyle = System.Windows.Forms.BorderStyle.None;
        _lstIngredientsAll.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { _lstAllBreak, _lstAllUnit, _lstAllItemName });
        _lstIngredientsAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lstIngredientsAll.ForeColor = System.Drawing.Color.Black;
        _lstIngredientsAll.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        _lstIngredientsAll.Location = new System.Drawing.Point(198, 157);
        _lstIngredientsAll.Name = "_lstIngredientsAll";
        _lstIngredientsAll.Size = new System.Drawing.Size(149, 232);
        _lstIngredientsAll.TabIndex = 4;
        _lstIngredientsAll.UseCompatibleStateImageBehavior = false;
        _lstIngredientsAll.View = System.Windows.Forms.View.Details;
        // 
        // lstAllBreak
        // 
        _lstAllBreak.Text = "";
        _lstAllBreak.Width = 20;
        // 
        // lstAllUnit
        // 
        _lstAllUnit.Text = "";
        _lstAllUnit.Width = 35;
        // 
        // lstAllItemName
        // 
        _lstAllItemName.Text = "";
        _lstAllItemName.Width = 90;
        // 
        // lstIngredientsExtraNo
        // 
        _lstIngredientsExtraNo.BackColor = System.Drawing.Color.FromArgb(59, 96, 141);
        _lstIngredientsExtraNo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { _cRawItemID, _cRawItemName, _cRawPriceTotal, _cRawTrackAs });
        _lstIngredientsExtraNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lstIngredientsExtraNo.ForeColor = System.Drawing.Color.White;
        _lstIngredientsExtraNo.FullRowSelect = true;
        _lstIngredientsExtraNo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        _lstIngredientsExtraNo.Location = new System.Drawing.Point(3, 21);
        _lstIngredientsExtraNo.MultiSelect = false;
        _lstIngredientsExtraNo.Name = "_lstIngredientsExtraNo";
        _lstIngredientsExtraNo.Size = new System.Drawing.Size(189, 368);
        _lstIngredientsExtraNo.TabIndex = 1;
        _lstIngredientsExtraNo.UseCompatibleStateImageBehavior = false;
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
        _cRawItemName.Width = 135;
        // 
        // cRawPriceTotal
        // 
        _cRawPriceTotal.Text = "Price";
        _cRawPriceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        _cRawPriceTotal.Width = 50;
        // 
        // cRawTrackAs
        // 
        _cRawTrackAs.Text = "";
        _cRawTrackAs.Width = 0;
        // 
        // pnlChangeModifiers
        // 
        _pnlChangeModifiers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _pnlChangeModifiers.Controls.Add(_Label1);
        _pnlChangeModifiers.Controls.Add(_pnlModiferiArrows);
        _pnlChangeModifiers.Location = new System.Drawing.Point(0, 0);
        _pnlChangeModifiers.Name = "_pnlChangeModifiers";
        _pnlChangeModifiers.Size = new System.Drawing.Size(356, 48);
        _pnlChangeModifiers.TabIndex = 0;
        // 
        // Label1
        // 
        _Label1.Font = new System.Drawing.Font("Cambria", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label1.ForeColor = System.Drawing.Color.White;
        _Label1.Location = new System.Drawing.Point(20, 12);
        _Label1.Name = "_Label1";
        _Label1.Size = new System.Drawing.Size(164, 24);
        _Label1.TabIndex = 0;
        _Label1.Text = "Modifiers";
        _Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pnlModiferiArrows
        // 
        _pnlModiferiArrows.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _pnlModiferiArrows.Controls.Add(_btnModifierDown);
        _pnlModiferiArrows.Controls.Add(_btnModifierUp);
        _pnlModiferiArrows.Location = new System.Drawing.Point(244, 0);
        _pnlModiferiArrows.Name = "_pnlModiferiArrows";
        _pnlModiferiArrows.Size = new System.Drawing.Size(96, 48);
        _pnlModiferiArrows.TabIndex = 1;
        // 
        // btnModifierDown
        // 
        _btnModifierDown.BackColor = System.Drawing.Color.CornflowerBlue;
        _btnModifierDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnModifierDown.Image = (Global.System.Drawing.Image)resources.GetObject("btnModifierDown.Image");
        _btnModifierDown.Location = new System.Drawing.Point(4, 0);
        _btnModifierDown.Name = "_btnModifierDown";
        _btnModifierDown.Size = new System.Drawing.Size(40, 40);
        _btnModifierDown.TabIndex = 1;
        _btnModifierDown.UseVisualStyleBackColor = false;
        // 
        // btnModifierUp
        // 
        _btnModifierUp.BackColor = System.Drawing.Color.CornflowerBlue;
        _btnModifierUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnModifierUp.Image = (Global.System.Drawing.Image)resources.GetObject("btnModifierUp.Image");
        _btnModifierUp.Location = new System.Drawing.Point(48, 0);
        _btnModifierUp.Name = "_btnModifierUp";
        _btnModifierUp.Size = new System.Drawing.Size(40, 40);
        _btnModifierUp.TabIndex = 2;
        _btnModifierUp.UseVisualStyleBackColor = false;
        // 
        // Panel2
        // 
        _Panel2.BackColor = System.Drawing.Color.Black;
        _Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _Panel2.Controls.Add(_btnDone);
        _Panel2.Controls.Add(_btnNo);
        _Panel2.Controls.Add(_btnExtra);
        _Panel2.Controls.Add(_btnAdd);
        _Panel2.Location = new System.Drawing.Point(8, 492);
        _Panel2.Name = "_Panel2";
        _Panel2.Size = new System.Drawing.Size(544, 52);
        _Panel2.TabIndex = 0;
        // 
        // btnDone
        // 
        _btnDone.BackColor = System.Drawing.Color.CornflowerBlue;
        _btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnDone.Location = new System.Drawing.Point(452, 4);
        _btnDone.Name = "_btnDone";
        _btnDone.Size = new System.Drawing.Size(76, 40);
        _btnDone.TabIndex = 4;
        _btnDone.Text = "DONE";
        _btnDone.UseVisualStyleBackColor = false;
        // 
        // btnNo
        // 
        _btnNo.BackColor = System.Drawing.Color.CornflowerBlue;
        _btnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnNo.Location = new System.Drawing.Point(132, 4);
        _btnNo.Name = "_btnNo";
        _btnNo.Size = new System.Drawing.Size(80, 40);
        _btnNo.TabIndex = 3;
        _btnNo.Text = "NO";
        _btnNo.UseVisualStyleBackColor = false;
        // 
        // btnExtra
        // 
        _btnExtra.BackColor = System.Drawing.Color.CornflowerBlue;
        _btnExtra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnExtra.Location = new System.Drawing.Point(244, 4);
        _btnExtra.Name = "_btnExtra";
        _btnExtra.Size = new System.Drawing.Size(72, 40);
        _btnExtra.TabIndex = 1;
        _btnExtra.Text = "EXTRA";
        _btnExtra.UseVisualStyleBackColor = false;
        // 
        // btnAdd
        // 
        _btnAdd.BackColor = System.Drawing.Color.CornflowerBlue;
        _btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnAdd.Location = new System.Drawing.Point(28, 4);
        _btnAdd.Name = "_btnAdd";
        _btnAdd.Size = new System.Drawing.Size(76, 40);
        _btnAdd.TabIndex = 0;
        _btnAdd.Text = "ADD";
        _btnAdd.UseVisualStyleBackColor = false;
        // 
        // Label3
        // 
        _Label3.AutoSize = true;
        _Label3.Font = new System.Drawing.Font("Cambria", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label3.ForeColor = System.Drawing.Color.White;
        _Label3.Location = new System.Drawing.Point(242, 127);
        _Label3.Name = "_Label3";
        _Label3.Size = new System.Drawing.Size(55, 15);
        _Label3.TabIndex = 5;
        _Label3.Text = "Reciepe";
        // 
        // DrinkPrep_UC
        // 
        this.BackColor = System.Drawing.Color.White;
        this.Controls.Add(_Panel1);
        this.Name = "DrinkPrep_UC";
        this.Size = new System.Drawing.Size(568, 560);
        _Panel1.ResumeLayout(false);
        _pnlPrep.ResumeLayout(false);
        _Panel4.ResumeLayout(false);
        _Panel3.ResumeLayout(false);
        _pnlModifiers.ResumeLayout(false);
        _pnlExtraNo.ResumeLayout(false);
        _pnlExtraNo.PerformLayout();
        _pnlChangeModifiers.ResumeLayout(false);
        _pnlModiferiArrows.ResumeLayout(false);
        _Panel2.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    internal void StartDrinkPrep(int dID, int catID, int rID, int funID, int funGroup)
    {

        lblPrep.Visible = true;
        pnlExtraNo.Visible = false;
        modifierIndex = 0;
        prepIndex = 0;
        _drinkCatID = catID;
        _drinkID = dID;
        _drinkRoute = rID;
        _drinkFunctionID = funID;
        _drinkFunGroup = funGroup;
        PopulateDrinkSubCategory();
        PopulateDrinkPrep();
        whatWereDoing = "ADD";
        ResetButtonColors();
        isForDrink = true;

    }

    internal void StartAddNo(int dID, int catID, int rID, int funID, int funGroup)
    {

        bool hasIngredientTest = false;
        int index;

        lblPrep.Visible = false;
        modifierIndex = 0;
        prepIndex = 0;
        _foodCatID = catID;
        _foodID = dID;
        _foodRoute = rID;
        _foodFunctionID = funID;
        _foodFunGroup = funGroup;

        PopulateAddNoCategories();
        whatWereDoing = currentTable.OrderingStatus;
        isForDrink = false;
        isExtended = false;
        maxmenuindex = 0;
        ResetButtonColors();

        if (whatWereDoing == "EXTRA" | whatWereDoing == "ADD")
        {
            if (dvIngredientsEXTRA.Count > 0)
            {
                hasIngredientTest = true;
            }
        }
        else if (dvIngredientsNO.Count > 0)
        {
            hasIngredientTest = true;
        }

        if (hasIngredientTest == true)
        {
            PopulateExtraNoListView();
            pnlExtraNo.Visible = true;
            return;
        }
        else
        {
            pnlExtraNo.Visible = false;
        }

        if (dvCategoryJoin.Count == 1)
        {
            isExtended = dvCategoryJoin[0]("Extended");
            _modifierCatID = dvCategoryJoin[0]("CategoryID");
            PrepareForAddNo(dvCategoryJoin[0]("FunctionFlag"));
            PopulateAddNoCategory();
        }
        else
        {
            for (index = 1; index <= 32; index++)
                BlankDrinkAddButton(index);
        }

    }


    private void CreateOrderDrinkButtonArray()
    {

        int index;
        int x = buttonSpace;
        int y = pnlChangeModifiers.Height + buttonSpace;
        var count = default(int);
        float drinkButtonWidth = (pnlModifiers.Width - 6 * buttonSpace) / 4;  // (opHeight - (13 * buttonSpace)) / 12
        float drinkButtonHeight = (pnlModifiers.Height - 10 * buttonSpace - pnlChangeModifiers.Height) / 8; // (opHeight - (13 * buttonSpace)) / 12

        for (index = 1; index <= 32; index++)
        {

            btnOrderDrinkAdds[index] = new OrderButton("8");

            {
                ref var withBlock = ref btnOrderDrinkAdds[index];
                withBlock.Size() = new Size(drinkButtonWidth, drinkButtonHeight);
                withBlock.Location = new Point(x, y);
                this.btnOrderDrinkAdds[index].Click += BtnOrderDrinkModifier_Click;   // BtnOrderDrink_Click
            }

            count = count + 1;
            if (count < 4)
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

        for (index = 32; index >= 1; index -= 1)
            pnlModifiers.Controls.Add(btnOrderDrinkAdds[index]);

    }

    private void CreateOrderDrinkPrepArray()
    {

        int index;
        int x = buttonSpace;
        int y = pnlChangeModifiers.Height + buttonSpace;
        var count = default(int);
        float drinkButtonWidth = (pnlPrep.Width - 4 * buttonSpace) / 2;  // (opHeight - (13 * buttonSpace)) / 12
        float drinkButtonHeight = (pnlPrep.Height - 10 * buttonSpace - pnlChangeModifiers.Height) / 8; // (opHeight - (13 * buttonSpace)) / 12

        for (index = 1; index <= 16; index++)
        {

            btnOrderDrinkPrep[index] = new OrderButton("8");

            {
                ref var withBlock = ref btnOrderDrinkPrep[index];
                withBlock.Size() = new Size(drinkButtonWidth, drinkButtonHeight);
                withBlock.Location = new Point(x, y);
                this.btnOrderDrinkPrep[index].Click += BtnOrderPrep_Click;   // BtnOrderDrink_Click
            }

            count = count + 1;
            if (count < 2)
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

        for (index = 16; index >= 1; index -= 1)
            pnlPrep.Controls.Add(btnOrderDrinkPrep[index]);

    }

    private void BtnOrderDrinkModifier_Click(object sender, EventArgs e) // Handles pnlOrder.Click
    {

        OrderButton objButton;
        try
        {
            objButton = (OrderButton)sender;
        }
        catch (Exception ex)
        {
            return;
        }

        var currentItem = new SelectedItemDetail();


        if (whatWereDoing == "ADD")
        {
            if (isForDrink == true)
            {
                currentItem.Name = "   " + objButton.Text;
                currentItem.TerminalName = "   " + objButton.Text;
                currentItem.ChitName = "   " + objButton.Text;
            }
            else
            {
                currentItem.Name = "   " + objButton.Text;
                currentItem.TerminalName = "   *** " + whatWereDoing + "  " + objButton.Text;
                currentItem.ChitName = "   *** " + whatWereDoing + "  " + objButton.Text;
            }

            currentItem.Quantity = currentTable.Quantity;
            currentItem.ItemPrice = objButton.Price;
            currentItem.Price = objButton.Price * currentTable.Quantity;
        }

        else if (whatWereDoing == "NO")
        {
            currentItem.Name = "   " + objButton.Text;
            currentItem.TerminalName = "   *** " + whatWereDoing + "  " + objButton.Text;
            currentItem.ChitName = "   *** " + whatWereDoing + "  " + objButton.Text;
            currentItem.Quantity = currentTable.Quantity * -1;
            currentItem.ItemPrice = 0;
            currentItem.Price = 0;
        }
        else if (whatWereDoing == "EXTRA")
        {
            currentItem.Name = "   " + objButton.Text;
            currentItem.TerminalName = "   *** " + whatWereDoing + "  " + objButton.Text;
            currentItem.ChitName = "   *** " + whatWereDoing + "  " + objButton.Text;
            currentItem.Quantity = currentTable.Quantity;
            currentItem.ItemPrice = objButton.Price;
            currentItem.Price = objButton.Price * currentTable.Quantity;
        }

        currentItem.ID = objButton.ID;
        currentItem.Category = objButton.CategoryID;
        if (isForDrink == true)
        {
            // this is for Drink Preps, we record these differntly
            currentItem.DrinkID = objButton.ID;
        }
        currentItem.RoutingID = DrinkRoute;
        currentItem.FunctionID = objButton.Functions;
        currentItem.FunctionGroup = objButton.FunctionGroup;
        currentItem.FunctionFlag = objButton.FunctionFlag;

        if (currentTable.si2 > 1 & currentTable.si2 < 10)
        {
            // half order
            currentItem.Quantity *= 0.5d;
            currentItem.ItemPrice *= 0.5d;
            currentItem.Price *= 0.5d;

        }

        AcceptPrep?.Invoke(currentItem);

    }

    private void BtnOrderPrep_Click(object sender, EventArgs e) // Handles pnlOrder.Click
    {

        OrderButton objButton;
        try
        {
            objButton = (OrderButton)sender;
        }
        catch (Exception ex)
        {
            return;
        }

        if (isForDrink == true)
        {
            var currentItem = new SelectedItemDetail();
            currentTable.InvMultiplier *= objButton.InvMultiplier;


            currentItem.ID = -1;
            if (whatWereDoing == "ADD")
            {
                currentItem.Name = "   " + objButton.Text;
                currentItem.TerminalName = "   " + objButton.Text;
                currentItem.ChitName = "   " + objButton.Text;

                currentItem.Quantity = currentTable.Quantity;
                currentItem.ItemPrice = objButton.Price;
                currentItem.Price = objButton.Price * currentTable.Quantity;
            }

            else if (whatWereDoing == "NO")
            {
                currentItem.Name = "   " + objButton.Text;
                currentItem.TerminalName = "   *** " + whatWereDoing + "  " + objButton.Text;
                currentItem.ChitName = "   *** " + whatWereDoing + "  " + objButton.Text;
                currentItem.Quantity = currentTable.Quantity * -1;
                currentItem.ItemPrice = 0;
                currentItem.Price = 0;
            }

            else if (whatWereDoing == "EXTRA")
            {
                currentItem.Name = "   " + objButton.Text;
                currentItem.TerminalName = "   *** " + whatWereDoing + "  " + objButton.Text;
                currentItem.ChitName = "   *** " + whatWereDoing + "  " + objButton.Text;
                currentItem.Quantity = currentTable.Quantity;
                currentItem.ItemPrice = objButton.Price;
                currentItem.Price = objButton.Price * currentTable.Quantity;
            }

            currentItem.dpMethod = objButton.dpMethod;
            currentItem.RoutingID = DrinkRoute;
            currentItem.FunctionID = DrinkFuctionID;
            currentItem.FunctionGroup = DrinkFunGroup;
            currentItem.FunctionFlag = "D"; // objButton.FunctionFlag

            if (!(objButton.Price > 0))   // objButton.InvMultiplier = 1 Then    '
            {
                // this is Prep, so this will be Double or addition to alcohol
                currentItem.DrinkID = DrinkID;
                currentItem.Category = DrinkCatID;
            }
            else
            {
                currentItem.DrinkID = objButton.ID;
                currentItem.Category = objButton.CategoryID;
            }

            AcceptPrep?.Invoke(currentItem);
        }
        else
        {
            // Add No for food items

            pnlExtraNo.Visible = false;
            isExtended = objButton.Extended;
            _modifierCatID = objButton.CategoryID;

            PrepareForAddNo(objButton.FunctionFlag);
            PopulateAddNoCategory();
        }

    }


    private void PopulateDrinkSubCategory()
    {

        int index;
        int secondIndex = modifierIndex;
        DataRow oRow;

        for (index = 1; index <= 32; index++)
        {
            if (secondIndex < dtDrinkAdds.Rows.Count)
            {
                btnOrderDrinkAdds[index].Text = dtDrinkAdds.Rows(secondIndex)("DrinkName");
                btnOrderDrinkAdds[index].ID = dtDrinkAdds.Rows(secondIndex)("DrinkID");
                btnOrderDrinkAdds[index].Price = dtDrinkAdds.Rows(secondIndex)("AddOnPrice");
                btnOrderDrinkAdds[index].CategoryID = DrinkCatID;
                btnOrderDrinkAdds[index].SubCategory = true;
                btnOrderDrinkAdds[index].Functions = dtDrinkAdds.Rows(secondIndex)("DrinkFunctionID");
                btnOrderDrinkAdds[index].FunctionGroup = dtDrinkAdds.Rows(secondIndex)("FunctionGroupID");
                btnOrderDrinkAdds[index].FunctionFlag = dtDrinkAdds.Rows(secondIndex)("FunctionFlag");
                btnOrderDrinkAdds[index].DrinkAdds = true;
                btnOrderDrinkAdds[index].BackColor = c16;
                btnOrderDrinkAdds[index].ForeColor = c3;
            }
            // not here      btnOrderDrinkAdds(index).InvMultiplier = dtDrinkAdds.Rows(index)("InvMultiplier")
            else
            {
                btnOrderDrinkAdds[index].Text = (object)null;
                btnOrderDrinkAdds[index].ID = 0;
                btnOrderDrinkAdds[index].BackColor = c13;
            }
            secondIndex += 1;
        }

    }

    private void PrepareForAddNo(string funFlag)
    {

        string populatingTable;

        if (funFlag == "M")
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

        {
            var withBlock = dvCategoryModifiers;
            withBlock.Table = ds.Tables(populatingTable + ModifierCatID);
            withBlock.Sort = "CategoryID, FoodName";
        }

        if (isExtended == true)
        {
            maxmenuindex = 0; // we don't care, maxmenuindex does not matter
        }
        else if (ds.Tables(populatingTable + ModifierCatID).Rows.Count > 0)
        {
            maxmenuindex = ds.Tables(populatingTable + ModifierCatID).Compute("Max(MenuIndex)", "");
        }
        else
        {
            maxmenuindex = 0;
        }
    }
    private void PopulateAddNoCategory() // ByVal catID As Integer, ByVal funFlag As String)
    {

        int index;
        int secondIndex = modifierIndex;
        DataRowView vRow;

        if (isExtended == true | maxmenuindex > 32)
        {
            for (index = 1; index <= 32; index++)
            {
                if (secondIndex < dvCategoryModifiers.Count)
                {
                    vRow = dvCategoryModifiers[secondIndex];
                    btnOrderDrinkAdds[index].Text = dvCategoryModifiers[secondIndex]("FoodName");
                    btnOrderDrinkAdds[index].ID = dvCategoryModifiers[secondIndex]("FoodID");
                    if (object.ReferenceEquals(dvCategoryModifiers[secondIndex]("Surcharge"), DBNull.Value))
                    {
                        btnOrderDrinkAdds[index].Price = 0;
                    }
                    else
                    {
                        btnOrderDrinkAdds[index].Price = dvCategoryModifiers[secondIndex]("Surcharge");
                    } // ("AddOnPrice")
                    btnOrderDrinkAdds[index].CategoryID = DrinkCatID;
                    btnOrderDrinkAdds[index].SubCategory = true;
                    btnOrderDrinkAdds[index].Functions = dvCategoryModifiers[secondIndex]("FunctionID");
                    btnOrderDrinkAdds[index].FunctionGroup = dvCategoryModifiers[secondIndex]("FunctionGroupID");
                    btnOrderDrinkAdds[index].FunctionFlag = dvCategoryModifiers[secondIndex]("FunctionFlag");
                    btnOrderDrinkAdds[index].DrinkAdds = true;
                    if (object.ReferenceEquals(dvCategoryModifiers[secondIndex]("ButtonColor"), DBNull.Value))
                    {
                        btnOrderDrinkAdds[index].BackColor = c16;
                        btnOrderDrinkAdds[index].ForeColor = c3;
                    }
                    else
                    {
                        btnOrderDrinkAdds[index].BackColor = Color.FromArgb(dvCategoryModifiers[secondIndex]("ButtonColor"));
                        btnOrderDrinkAdds[index].ForeColor = Color.FromArgb(dvCategoryModifiers[secondIndex]("ButtonForeColor"));
                    }
                }
                // not here      btnOrderDrinkAdds(index).InvMultiplier = dtDrinkAdds.Rows(index)("InvMultiplier")
                else
                {
                    btnOrderDrinkAdds[index].Text = (object)null;
                    btnOrderDrinkAdds[index].ID = 0;
                    btnOrderDrinkAdds[index].BackColor = c13;
                }
                secondIndex += 1;
            }
        }
        else
        {
            // will not be here if MenuIndex > 32
            for (index = 1; index <= 32; index++)
                BlankDrinkAddButton(index);
            foreach (DataRowView currentVRow in dvCategoryModifiers)
            {
                vRow = currentVRow;
                if (vRow("MenuIndex") > 0)
                {
                    PopulateDrinkAddButton(vRow("MenuIndex"), ref vRow);
                }
            }
        }

    }

    private void PopulateDrinkAddButton(int index, ref DataRowView vRow)
    {

        btnOrderDrinkAdds[index].Text = vRow("FoodName");
        btnOrderDrinkAdds[index].ID = vRow("FoodID");
        if (object.ReferenceEquals(vRow("Surcharge"), DBNull.Value))
        {
            btnOrderDrinkAdds[index].Price = 0;
        }
        else
        {
            btnOrderDrinkAdds[index].Price = vRow("Surcharge");
        } // ("AddOnPrice")
        btnOrderDrinkAdds[index].CategoryID = DrinkCatID;
        btnOrderDrinkAdds[index].SubCategory = true;
        btnOrderDrinkAdds[index].Functions = vRow("FunctionID");
        btnOrderDrinkAdds[index].FunctionGroup = vRow("FunctionGroupID");
        btnOrderDrinkAdds[index].FunctionFlag = vRow("FunctionFlag");
        btnOrderDrinkAdds[index].DrinkAdds = true;
        if (object.ReferenceEquals(vRow("ButtonColor"), DBNull.Value))
        {
            btnOrderDrinkAdds[index].BackColor = c16;
            btnOrderDrinkAdds[index].ForeColor = c3;
        }
        else
        {
            btnOrderDrinkAdds[index].BackColor = Color.FromArgb(vRow("ButtonColor"));
            btnOrderDrinkAdds[index].ForeColor = Color.FromArgb(vRow("ButtonForeColor"));
        }

        // not here      btnOrderDrinkAdds(index).InvMultiplier = dtDrinkAdds.Rows(index)("InvMultiplier")

    }

    private void BlankDrinkAddButton(int index)
    {
        btnOrderDrinkAdds[index].Text = (object)null;
        btnOrderDrinkAdds[index].ID = 0;
        btnOrderDrinkAdds[index].BackColor = c13;
    }


    private void btnModifierDown_Click(object sender, EventArgs e)
    {

        if (isForDrink == true)
        {
            if (dtDrinkAdds.Rows.Count > modifierIndex + 32)
            {
                modifierIndex += 32;
                PopulateDrinkSubCategory();
            }
        }
        else if (dvCategoryModifiers.Count > modifierIndex + 32)
        {
            modifierIndex += 32;
            PopulateAddNoCategory();
        }

    }

    private void btnModifierUp_Click(object sender, EventArgs e)
    {

        if (modifierIndex > 1)
        {
            modifierIndex -= 32;
            if (isForDrink == true)
            {
                PopulateDrinkSubCategory();
            }
            else
            {
                PopulateAddNoCategory();
            }
        }

    }

    private void PopulateDrinkPrep()
    {

        int index;
        int secondIndex = prepIndex;
        DataRow oRow;

        for (index = 1; index <= 16; index++)
        {
            if (secondIndex < dtDrinkPrep.Rows.Count)
            {
                btnOrderDrinkPrep[index].Text = dtDrinkPrep.Rows(secondIndex)("DrinkPrepName");
                btnOrderDrinkPrep[index].ID = dtDrinkPrep.Rows(secondIndex)("DrinkPrepID");
                btnOrderDrinkPrep[index].dpMethod = dtDrinkPrep.Rows(secondIndex)("DrinkPrepMethod");
                btnOrderDrinkPrep[index].Price = dtDrinkPrep.Rows(secondIndex)("DrinkPrepPrice");
                if (!object.ReferenceEquals(dtDrinkPrep.Rows(secondIndex)("InvMultiplier"), DBNull.Value))
                {
                    btnOrderDrinkPrep[index].InvMultiplier = dtDrinkPrep.Rows(secondIndex)("InvMultiplier");
                }
                else
                {
                    btnOrderDrinkPrep[index].InvMultiplier = 1;
                }
                btnOrderDrinkPrep[index].CategoryID = DrinkCatID;
                btnOrderDrinkPrep[index].SubCategory = true;
                // btnOrderDrinkPrep(index).Functions = dtDrinkPrep.Rows(secondIndex)("DrinkFunctionID")
                btnOrderDrinkPrep[index].FunctionGroup = 11; // dtDrinkPrep.Rows(secondIndex)("FunctionGroupID")
                btnOrderDrinkPrep[index].FunctionFlag = "D"; // dtDrinkPrep.Rows(secondIndex)("FunctionFlag")
                btnOrderDrinkPrep[index].DrinkAdds = true;
                btnOrderDrinkPrep[index].BackColor = c16;
                btnOrderDrinkPrep[index].ForeColor = c3;
            }
            else
            {
                btnOrderDrinkPrep[index].Text = (object)null;
                btnOrderDrinkPrep[index].ID = 0;
                btnOrderDrinkPrep[index].BackColor = c13;
            }
            secondIndex += 1;
        }

    }


    private void PopulateAddNoCategories()
    {

        int index;
        int secondIndex = prepIndex;
        DataRow oRow;

        for (index = 1; index <= 16; index++)
        {
            if (secondIndex < dtModifierCategory.Rows.Count)
            {
                btnOrderDrinkPrep[index].Text = dtModifierCategory.Rows(secondIndex)("CategoryAbrev");
                btnOrderDrinkPrep[index].CategoryID = dtModifierCategory.Rows(secondIndex)("CategoryID");
                // btnOrderDrinkPrep(index).SubCategory = True
                btnOrderDrinkPrep[index].FunctionGroup = dtModifierCategory.Rows(secondIndex)("FunctionGroupID");
                btnOrderDrinkPrep[index].FunctionFlag = dtModifierCategory.Rows(secondIndex)("FunctionFlag");
                btnOrderDrinkPrep[index].Extended = dtModifierCategory.Rows(secondIndex)("Extended");
                // dtModifierCategory.Rows(secondIndex)("CategoryAbrev")
                if (object.ReferenceEquals(dtModifierCategory.Rows(secondIndex)("ButtonColor"), DBNull.Value))
                {
                    btnOrderDrinkPrep[index].BackColor = c7;
                    btnOrderDrinkPrep[index].ForeColor = c3;
                }
                else
                {
                    btnOrderDrinkPrep[index].BackColor = Color.FromArgb(dtModifierCategory.Rows(secondIndex)("ButtonColor"));
                    btnOrderDrinkPrep[index].ForeColor = Color.FromArgb(dtModifierCategory.Rows(secondIndex)("ButtonForeColor"));

                }
            }
            else
            {

                btnOrderDrinkPrep[index].Text = (object)null;
                btnOrderDrinkPrep[index].ID = 0;
                btnOrderDrinkPrep[index].BackColor = c13;
            }
            secondIndex += 1;
        }

    }

    private void btnPrepDown_Click(object sender, EventArgs e)
    {

        if (isForDrink == true)
        {
            if (dtDrinkPrep.Rows.Count > prepIndex + 16)
            {
                prepIndex += 16;
                PopulateDrinkPrep();
            }
        }
        else if (dtModifierCategory.Rows.Count > prepIndex + 16)
        {
            prepIndex += 16;
            PopulateAddNoCategories();
        }

    }

    private void btnPrepUp_Click(object sender, EventArgs e)
    {

        if (prepIndex > 1)
        {
            prepIndex -= 16;
            if (isForDrink == true)
            {
                PopulateDrinkPrep();
            }
            else
            {
                PopulateAddNoCategories();
            }

        }
    }

    private void btnDone_Click(object sender, EventArgs e)
    {
        Cancel?.Invoke();

    }

    private void btnAdd_Click(object sender, EventArgs e)
    {

        whatWereDoing = "ADD";
        ResetButtonColors();

    }

    private void btnNo_Click(object sender, EventArgs e)
    {
        whatWereDoing = "NO";
        ResetButtonColors();

    }

    private void btnExtra_Click(object sender, EventArgs e)
    {
        whatWereDoing = "EXTRA";
        ResetButtonColors();

    }

    private void ResetButtonColors()
    {

        btnAdd.BackColor = Color.CornflowerBlue;
        btnNo.BackColor = Color.CornflowerBlue;
        btnExtra.BackColor = Color.CornflowerBlue;
        switch (whatWereDoing ?? "")
        {
            case "ADD":
                {
                    btnAdd.BackColor = Color.IndianRed;
                    break;
                }
            case "NO":
                {
                    btnNo.BackColor = Color.IndianRed;
                    break;
                }
            case "EXTRA":
                {
                    btnExtra.BackColor = Color.IndianRed;
                    break;
                }
        }

    }

    public void PopulateExtraNoListView()
    {

        DataRowView vRow;
        decimal rawPrice;

        lstIngredientsExtraNo.Items.Clear();
        lstIngredientsAll.Items.Clear();

        // Me.lblRawItemName.Text = MainFoodItemName

        foreach (DataRowView currentVRow in dvIngredients)
        {
            vRow = currentVRow;
            var allItem = new ListViewItem();

            allItem.Text = Strings.Format(vRow("RawUsageAmount"), "##0");
            allItem.SubItems.Add(vRow("RecipeUnit"));
            allItem.SubItems.Add(vRow("RawItemName"));

            lstIngredientsAll.Items.Add(allItem);

        }

        if (whatWereDoing == "EXTRA" | whatWereDoing == "ADD")
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
        }
        // IsExtraType()
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
            // IsNoType()
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
            if (whatWereDoing == "EXTRA" | whatWereDoing == "ADD")
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
            currentItem.RoutingID = FoodRoute; // currentTable.ReferenceRouting 'must do first in case drink
            currentItem.FunctionID = FoodFuctionID; // MainFoodFunID
            currentItem.FunctionGroup = FoodFunGroup; // MainFoodFunGroup
            currentItem.FunctionFlag = "M";
            // 444     .TaxID = MainFoodTaxID
            // 444       DetermineFunctionAndTaxInfo(currentItem, 9, False)   '9 is functionGroup = Modifier
            // not sure why we are doing above

        }

        if (whatWereDoing == "EXTRA" | whatWereDoing == "ADD")
        {
            currentItem.Quantity = 1;
            currentItem.Price = SelectedRawPriceTotal;
        }

        else
        {
            currentItem.Quantity = -1;
            currentItem.Price = -1 * SelectedRawPriceTotal;

        }

        currentItem.Name = " *** " + whatWereDoing + "  " + vRow("RawItemName");
        currentItem.TerminalName = " *** " + whatWereDoing + "  " + vRow("RawItemName");
        currentItem.ChitName = " *** " + whatWereDoing + "  " + vRow("RawItemName");

        currentItem.ItemStatus = 0;
        currentItem.Check = currentTable.CheckNumber;
        currentItem.Customer = currentTable.CustomerNumber;
        currentItem.Course = currentTable.CourseNumber;
        currentItem.SIN = currentTable.SIN;
        currentItem.SII = currentTable.ReferenceSIN;

        currentItem.si2 = currentTable.si2;

        AcceptPrep?.Invoke(currentItem);

    }

}