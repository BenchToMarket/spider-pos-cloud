using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;


public partial class CashClose_UC : System.Windows.Forms.UserControl
{

    private int numOfItems;
    private int salesNumber;
    private decimal cashDue;
    private decimal cashPaid;
    private decimal change;

    private Label _pnlNoSale;

    private Label pnlNoSale
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlNoSale;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pnlNoSale != null)
            {
                _pnlNoSale.Click -= lblItemsOrdered_Click;
            }

            _pnlNoSale = value;
            if (_pnlNoSale != null)
            {
                _pnlNoSale.Click += lblItemsOrdered_Click;
            }
        }
    }

    #region  Windows Form Designer generated code 

    public CashClose_UC(int _numOfItems, int _salesNumber, decimal _cashDue, decimal _cashPaid) : base()
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        numOfItems = _numOfItems;
        salesNumber = _salesNumber;
        cashDue = Conversions.ToDecimal(Strings.Format(_cashDue, "###,###.00"));
        cashPaid = Conversions.ToDecimal(Strings.Format(_cashPaid, "###,###.00"));
        change = Conversions.ToDecimal(Strings.Format(cashPaid - cashDue, "###,###.00"));

        // Add any initialization after the InitializeComponent() call
        InitializeOther();
        base.Click += lblItemsOrdered_Click;

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
            if (_Panel1 != null)
            {
                _Panel1.Click -= lblItemsOrdered_Click;
            }

            _Panel1 = value;
            if (_Panel1 != null)
            {
                _Panel1.Click += lblItemsOrdered_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblItemsOrdered;

    internal virtual Global.System.Windows.Forms.Label lblItemsOrdered
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblItemsOrdered;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblItemsOrdered != null)
            {
                _lblItemsOrdered.Click -= lblItemsOrdered_Click;
            }

            _lblItemsOrdered = value;
            if (_lblItemsOrdered != null)
            {
                _lblItemsOrdered.Click += lblItemsOrdered_Click;
            }
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
            if (_Label2 != null)
            {
                _Label2.Click -= lblItemsOrdered_Click;
            }

            _Label2 = value;
            if (_Label2 != null)
            {
                _Label2.Click += lblItemsOrdered_Click;
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
            if (_Label3 != null)
            {
                _Label3.Click -= lblItemsOrdered_Click;
            }

            _Label3 = value;
            if (_Label3 != null)
            {
                _Label3.Click += lblItemsOrdered_Click;
            }
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
            if (_Label4 != null)
            {
                _Label4.Click -= lblItemsOrdered_Click;
            }

            _Label4 = value;
            if (_Label4 != null)
            {
                _Label4.Click += lblItemsOrdered_Click;
            }
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
            if (_Label5 != null)
            {
                _Label5.Click -= lblItemsOrdered_Click;
            }

            _Label5 = value;
            if (_Label5 != null)
            {
                _Label5.Click += lblItemsOrdered_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _Label6;

    internal virtual Global.System.Windows.Forms.Label Label6
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label6;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Label6 != null)
            {
                _Label6.Click -= lblItemsOrdered_Click;
            }

            _Label6 = value;
            if (_Label6 != null)
            {
                _Label6.Click += lblItemsOrdered_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblChange;

    internal virtual Global.System.Windows.Forms.Label lblChange
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblChange;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblChange != null)
            {
                _lblChange.Click -= lblItemsOrdered_Click;
            }

            _lblChange = value;
            if (_lblChange != null)
            {
                _lblChange.Click += lblItemsOrdered_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblCashPaid;

    internal virtual Global.System.Windows.Forms.Label lblCashPaid
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCashPaid;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCashPaid != null)
            {
                _lblCashPaid.Click -= lblItemsOrdered_Click;
            }

            _lblCashPaid = value;
            if (_lblCashPaid != null)
            {
                _lblCashPaid.Click += lblItemsOrdered_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblCashDue;

    internal virtual Global.System.Windows.Forms.Label lblCashDue
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCashDue;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblCashDue != null)
            {
                _lblCashDue.Click -= lblItemsOrdered_Click;
            }

            _lblCashDue = value;
            if (_lblCashDue != null)
            {
                _lblCashDue.Click += lblItemsOrdered_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblSalesNum;

    internal virtual Global.System.Windows.Forms.Label lblSalesNum
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblSalesNum;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblSalesNum != null)
            {
                _lblSalesNum.Click -= lblItemsOrdered_Click;
            }

            _lblSalesNum = value;
            if (_lblSalesNum != null)
            {
                _lblSalesNum.Click += lblItemsOrdered_Click;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _Panel1 = new System.Windows.Forms.Panel();
        _Panel1.Click += lblItemsOrdered_Click;
        _lblSalesNum = new System.Windows.Forms.Label();
        _lblSalesNum.Click += lblItemsOrdered_Click;
        _lblCashDue = new System.Windows.Forms.Label();
        _lblCashDue.Click += lblItemsOrdered_Click;
        _lblCashPaid = new System.Windows.Forms.Label();
        _lblCashPaid.Click += lblItemsOrdered_Click;
        _lblChange = new System.Windows.Forms.Label();
        _lblChange.Click += lblItemsOrdered_Click;
        _Label6 = new System.Windows.Forms.Label();
        _Label6.Click += lblItemsOrdered_Click;
        _Label5 = new System.Windows.Forms.Label();
        _Label5.Click += lblItemsOrdered_Click;
        _Label4 = new System.Windows.Forms.Label();
        _Label4.Click += lblItemsOrdered_Click;
        _Label3 = new System.Windows.Forms.Label();
        _Label3.Click += lblItemsOrdered_Click;
        _Label2 = new System.Windows.Forms.Label();
        _Label2.Click += lblItemsOrdered_Click;
        _lblItemsOrdered = new System.Windows.Forms.Label();
        _lblItemsOrdered.Click += lblItemsOrdered_Click;
        _Panel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.Color.LightGray;
        _Panel1.Controls.Add(_lblSalesNum);
        _Panel1.Controls.Add(_lblCashDue);
        _Panel1.Controls.Add(_lblCashPaid);
        _Panel1.Controls.Add(_lblChange);
        _Panel1.Controls.Add(_Label6);
        _Panel1.Controls.Add(_Label5);
        _Panel1.Controls.Add(_Label4);
        _Panel1.Controls.Add(_Label3);
        _Panel1.Controls.Add(_Label2);
        _Panel1.Location = new System.Drawing.Point(8, 104);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(632, 344);
        _Panel1.TabIndex = 0;
        // 
        // lblSalesNum
        // 
        _lblSalesNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblSalesNum.Location = new System.Drawing.Point(336, 24);
        _lblSalesNum.Name = "_lblSalesNum";
        _lblSalesNum.Size = new System.Drawing.Size(224, 56);
        _lblSalesNum.TabIndex = 9;
        _lblSalesNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblCashDue
        // 
        _lblCashDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblCashDue.Location = new System.Drawing.Point(336, 96);
        _lblCashDue.Name = "_lblCashDue";
        _lblCashDue.Size = new System.Drawing.Size(224, 56);
        _lblCashDue.TabIndex = 8;
        _lblCashDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblCashPaid
        // 
        _lblCashPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblCashPaid.Location = new System.Drawing.Point(336, 168);
        _lblCashPaid.Name = "_lblCashPaid";
        _lblCashPaid.Size = new System.Drawing.Size(224, 56);
        _lblCashPaid.TabIndex = 7;
        _lblCashPaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblChange
        // 
        _lblChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblChange.ForeColor = System.Drawing.Color.MediumSeaGreen;
        _lblChange.Location = new System.Drawing.Point(336, 264);
        _lblChange.Name = "_lblChange";
        _lblChange.Size = new System.Drawing.Size(224, 56);
        _lblChange.TabIndex = 6;
        _lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label6
        // 
        _Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label6.ForeColor = System.Drawing.Color.MediumSeaGreen;
        _Label6.Location = new System.Drawing.Point(16, 264);
        _Label6.Name = "_Label6";
        _Label6.Size = new System.Drawing.Size(264, 56);
        _Label6.TabIndex = 5;
        _Label6.Text = "Change:";
        _Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label5
        // 
        _Label5.BackColor = System.Drawing.Color.Black;
        _Label5.Location = new System.Drawing.Point(24, 232);
        _Label5.Name = "_Label5";
        _Label5.Size = new System.Drawing.Size(584, 8);
        _Label5.TabIndex = 4;
        _Label5.Text = "Label5";
        // 
        // Label4
        // 
        _Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label4.Location = new System.Drawing.Point(56, 168);
        _Label4.Name = "_Label4";
        _Label4.Size = new System.Drawing.Size(224, 56);
        _Label4.TabIndex = 3;
        _Label4.Text = "Cash Paid:";
        _Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label3
        // 
        _Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label3.Location = new System.Drawing.Point(56, 96);
        _Label3.Name = "_Label3";
        _Label3.Size = new System.Drawing.Size(224, 56);
        _Label3.TabIndex = 2;
        _Label3.Text = "Cash Due:";
        _Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label2
        // 
        _Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label2.Location = new System.Drawing.Point(56, 24);
        _Label2.Name = "_Label2";
        _Label2.Size = new System.Drawing.Size(224, 56);
        _Label2.TabIndex = 1;
        _Label2.Text = "Sales #:";
        _Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblItemsOrdered
        // 
        _lblItemsOrdered.BackColor = System.Drawing.Color.Black;
        _lblItemsOrdered.Font = new System.Drawing.Font("Microsoft Sans Serif", 48.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblItemsOrdered.ForeColor = System.Drawing.Color.White;
        _lblItemsOrdered.Location = new System.Drawing.Point(8, 8);
        _lblItemsOrdered.Name = "_lblItemsOrdered";
        _lblItemsOrdered.Size = new System.Drawing.Size(632, 96);
        _lblItemsOrdered.TabIndex = 0;
        _lblItemsOrdered.Text = "0 Items Ordered";
        _lblItemsOrdered.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // CashClose_UC
        // 
        this.BackColor = System.Drawing.Color.LightSteelBlue;
        this.Controls.Add(_Panel1);
        this.Controls.Add(_lblItemsOrdered);
        this.Name = "CashClose_UC";
        this.Size = new System.Drawing.Size(648, 456);
        _Panel1.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private void InitializeOther()
    {

        lblItemsOrdered.Text = numOfItems.ToString() + " Items Ordered";
        lblSalesNum.Text = salesNumber;
        lblCashDue.Text = cashDue;
        lblCashPaid.Text = cashPaid;
        lblChange.Text = change;

        if (change >= 0m)
        {
            Label6.Text = "Change:";
        }
        else
        {
            Label6.Text = "Balance Due:";
            Label6.ForeColor = c9;
        }    // Color.Red

    }

    public void BeginNoSale()
    {

        Panel1.Visible = false;
        pnlNoSale = new Label();

        pnlNoSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 48.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        pnlNoSale.Location = new System.Drawing.Point(0, 200);
        pnlNoSale.Size = new System.Drawing.Size(450, 100);
        pnlNoSale.Text = "No Sale";
        pnlNoSale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        this.Controls.Add(pnlNoSale);

    }
    private void lblItemsOrdered_Click(object sender, EventArgs e)
    {

        this.Dispose();

    }
}