using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;


public partial class CashOut_UC : System.Windows.Forms.UserControl
{


    private string _itemDescription;
    private decimal _itemPrice;

    private int _paymentTypeID;
    private decimal _maxCashAmount;



    private long _expNum;



    // Event UC_Hit()



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

    internal long ExpNum
    {
        get
        {
            return _expNum;
        }
        set
        {
            _expNum = value;
        }
    }

    internal int PaymentTypeID
    {
        get
        {
            return _paymentTypeID;
        }
        set
        {
            _paymentTypeID = value;
        }
    }

    internal decimal MaxCashAmount
    {
        get
        {
            return _maxCashAmount;
        }
        set
        {
            _maxCashAmount = value;
        }
    }



    public event CancelCashOutEventHandler CancelCashOut;

    public delegate void CancelCashOutEventHandler(object sender, EventArgs e);
    public event AcceptCashOutEventHandler AcceptCashOut;

    public delegate void AcceptCashOutEventHandler(object sender, EventArgs e);


    #region  Windows Form Designer generated code 

    public CashOut_UC(long en, int pt, decimal maxCA) : base()
    {

        _paymentTypeID = pt;
        _expNum = en;
        _maxCashAmount = maxCA;

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        InitializeOther();


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
    private Global.System.Windows.Forms.Label _lblCashOut;

    internal virtual Global.System.Windows.Forms.Label lblCashOut
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCashOut;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblCashOut = value;
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _NumberPadSmall1 = new DataSet_Builder.NumberPadSmall();
        _NumberPadSmall1.NumberChanged += ItemPriceChanged;
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
        _lblCashOut = new System.Windows.Forms.Label();
        _Panel3.SuspendLayout();
        this.SuspendLayout();
        // 
        // NumberPadSmall1
        // 
        _NumberPadSmall1.BackColor = System.Drawing.Color.SlateGray;
        _NumberPadSmall1.DecimalUsed = false;
        _NumberPadSmall1.IntegerNumber = 0;
        _NumberPadSmall1.Location = new System.Drawing.Point(568, 8);
        _NumberPadSmall1.Name = "_NumberPadSmall1";
        _NumberPadSmall1.NumberString = (object)null;
        _NumberPadSmall1.NumberTotal = new decimal(new int[] { 0, 0, 0, 0 });
        _NumberPadSmall1.Size = new System.Drawing.Size(144, 240);
        _NumberPadSmall1.TabIndex = 1;
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
        _Panel3.Location = new System.Drawing.Point(384, 8);
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
        _lblTextPrice.Location = new System.Drawing.Point(56, 160);
        _lblTextPrice.Name = "_lblTextPrice";
        _lblTextPrice.Size = new System.Drawing.Size(96, 24);
        _lblTextPrice.TabIndex = 3;
        _lblTextPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblPrice
        // 
        _lblPrice.Location = new System.Drawing.Point(8, 136);
        _lblPrice.Name = "_lblPrice";
        _lblPrice.Size = new System.Drawing.Size(104, 16);
        _lblPrice.TabIndex = 2;
        _lblPrice.Text = "Price:";
        // 
        // lblTextItem
        // 
        _lblTextItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblTextItem.ForeColor = System.Drawing.Color.Red;
        _lblTextItem.Location = new System.Drawing.Point(24, 72);
        _lblTextItem.Name = "_lblTextItem";
        _lblTextItem.Size = new System.Drawing.Size(128, 56);
        _lblTextItem.TabIndex = 1;
        // 
        // lblItem
        // 
        _lblItem.Location = new System.Drawing.Point(8, 48);
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
        _SpecialKeyboard.Location = new System.Drawing.Point(32, 256);
        _SpecialKeyboard.Name = "_SpecialKeyboard";
        _SpecialKeyboard.Size = new System.Drawing.Size(680, 296);
        _SpecialKeyboard.TabIndex = 6;
        // 
        // lblCashOut
        // 
        _lblCashOut.Location = new System.Drawing.Point(16, 16);
        _lblCashOut.Name = "_lblCashOut";
        _lblCashOut.Size = new System.Drawing.Size(160, 23);
        _lblCashOut.TabIndex = 7;
        // 
        // CashOut_UC
        // 
        this.BackColor = System.Drawing.Color.FromArgb(59, 96, 141);
        this.Controls.Add(_lblCashOut);
        this.Controls.Add(_SpecialKeyboard);
        this.Controls.Add(_Panel3);
        this.Controls.Add(_NumberPadSmall1);
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        this.ForeColor = System.Drawing.Color.White;
        this.Name = "CashOut_UC";
        this.Size = new System.Drawing.Size(744, 565);
        _Panel3.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private void InitializeOther()
    {

        NumberPadSmall1.DecimalUsed = true;
        SpecialKeyboard.EnteredString = "";




    }



    private void ItemDescriptionChanged()
    {
        // RaiseEvent UC_Hit()

        if (SpecialKeyboard.EnteredString.Length > 50)
        {
            SpecialKeyboard.EnteredString = SpecialKeyboard.EnteredString.Substring(0, 50);
        }

        lblTextItem.Text = SpecialKeyboard.EnteredString;
        ItemDescription = SpecialKeyboard.EnteredString;

    }

    private void ItemPriceChanged()
    {
        // RaiseEvent UC_Hit()

        lblTextPrice.Text = NumberPadSmall1.NumberTotal;
        ItemPrice = NumberPadSmall1.NumberTotal;

    }

    private void btnCancel_Click(object sender, EventArgs e)
    {

        CancelCashOut?.Invoke(sender, e);

        this.Dispose();

    }

    private void btnAccept_Click(object sender, EventArgs e)
    {

        if (NumberPadSmall1.NumberTotal > MaxCashAmount)
        {
            if (PaymentTypeID == 1)
            {
                // this is a refund
                Interaction.MsgBox("You can not refund more cash then paid in.");
            }
            else if (PaymentTypeID == -3)
            {
                // this is cash out
                Interaction.MsgBox("The restaurant has a limit of cash out: $ " + MaxCashAmount);
            }
            return;
        }

        AcceptCashOut?.Invoke(sender, e);

    }



}