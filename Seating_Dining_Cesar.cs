using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public partial class Seating_Dining_Cesar : System.Windows.Forms.UserControl
{
    private int _tableSelected;
    // Private _numberCustomers As Integer

    internal int TableSelected
    {
        get
        {
            return _tableSelected;
        }
        set
        {
            _tableSelected = value;
        }
    }

    // Friend Property NumberCustomers() As Integer
    // Get
    // Return _numberCustomers
    // End Get
    // Set(ByVal Value As Integer)
    // _numberCustomers = Value
    // End Set
    // End Property


    public event TableSelectedEventEventHandler TableSelectedEvent;

    public delegate void TableSelectedEventEventHandler(object sender, EventArgs e);
    // Event NumberCustomerEvent(ByVal sender As Object, ByVal e As System.EventArgs)


    #region  Windows Form Designer generated code 

    public Seating_Dining_Cesar() : base()
    {

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
    private Global.System.Windows.Forms.Panel _pnlDownStairs;

    internal virtual Global.System.Windows.Forms.Panel pnlDownStairs
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlDownStairs;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlDownStairs = value;
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
    private Global.System.Windows.Forms.Panel _Panel6;

    internal virtual Global.System.Windows.Forms.Panel Panel6
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel6;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel6 = value;
        }
    }
    private Global.System.Windows.Forms.Panel _Panel5;

    internal virtual Global.System.Windows.Forms.Panel Panel5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel5 = value;
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
    private Global.System.Windows.Forms.Button _tbl9;

    internal virtual Global.System.Windows.Forms.Button tbl9
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl9;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl9 != null)
            {
                _tbl9.Click -= Seating_Dining_Click;
            }

            _tbl9 = value;
            if (_tbl9 != null)
            {
                _tbl9.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl101;

    internal virtual Global.System.Windows.Forms.Button tbl101
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl101;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl101 != null)
            {
                _tbl101.Click -= Seating_Dining_Click;
            }

            _tbl101 = value;
            if (_tbl101 != null)
            {
                _tbl101.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl105;

    internal virtual Global.System.Windows.Forms.Button tbl105
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl105;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl105 != null)
            {
                _tbl105.Click -= Seating_Dining_Click;
            }

            _tbl105 = value;
            if (_tbl105 != null)
            {
                _tbl105.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl106;

    internal virtual Global.System.Windows.Forms.Button tbl106
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl106;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl106 != null)
            {
                _tbl106.Click -= Seating_Dining_Click;
            }

            _tbl106 = value;
            if (_tbl106 != null)
            {
                _tbl106.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl107;

    internal virtual Global.System.Windows.Forms.Button tbl107
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl107;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl107 != null)
            {
                _tbl107.Click -= Seating_Dining_Click;
            }

            _tbl107 = value;
            if (_tbl107 != null)
            {
                _tbl107.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl108;

    internal virtual Global.System.Windows.Forms.Button tbl108
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl108;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl108 != null)
            {
                _tbl108.Click -= Seating_Dining_Click;
            }

            _tbl108 = value;
            if (_tbl108 != null)
            {
                _tbl108.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl103;

    internal virtual Global.System.Windows.Forms.Button tbl103
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl103;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl103 != null)
            {
                _tbl103.Click -= Seating_Dining_Click;
            }

            _tbl103 = value;
            if (_tbl103 != null)
            {
                _tbl103.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl102;

    internal virtual Global.System.Windows.Forms.Button tbl102
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl102;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl102 != null)
            {
                _tbl102.Click -= Seating_Dining_Click;
            }

            _tbl102 = value;
            if (_tbl102 != null)
            {
                _tbl102.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl104;

    internal virtual Global.System.Windows.Forms.Button tbl104
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl104;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl104 != null)
            {
                _tbl104.Click -= Seating_Dining_Click;
            }

            _tbl104 = value;
            if (_tbl104 != null)
            {
                _tbl104.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl7;

    internal virtual Global.System.Windows.Forms.Button tbl7
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl7;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl7 != null)
            {
                _tbl7.Click -= Seating_Dining_Click;
            }

            _tbl7 = value;
            if (_tbl7 != null)
            {
                _tbl7.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl6;

    internal virtual Global.System.Windows.Forms.Button tbl6
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl6;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl6 != null)
            {
                _tbl6.Click -= Seating_Dining_Click;
            }

            _tbl6 = value;
            if (_tbl6 != null)
            {
                _tbl6.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl5;

    internal virtual Global.System.Windows.Forms.Button tbl5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl5 != null)
            {
                _tbl5.Click -= Seating_Dining_Click;
            }

            _tbl5 = value;
            if (_tbl5 != null)
            {
                _tbl5.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl4;

    internal virtual Global.System.Windows.Forms.Button tbl4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl4 != null)
            {
                _tbl4.Click -= Seating_Dining_Click;
            }

            _tbl4 = value;
            if (_tbl4 != null)
            {
                _tbl4.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl8;

    internal virtual Global.System.Windows.Forms.Button tbl8
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl8;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl8 != null)
            {
                _tbl8.Click -= Seating_Dining_Click;
            }

            _tbl8 = value;
            if (_tbl8 != null)
            {
                _tbl8.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl2;

    internal virtual Global.System.Windows.Forms.Button tbl2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl2 != null)
            {
                _tbl2.Click -= Seating_Dining_Click;
            }

            _tbl2 = value;
            if (_tbl2 != null)
            {
                _tbl2.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl1;

    internal virtual Global.System.Windows.Forms.Button tbl1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl1 != null)
            {
                _tbl1.Click -= Seating_Dining_Click;
            }

            _tbl1 = value;
            if (_tbl1 != null)
            {
                _tbl1.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl11;

    internal virtual Global.System.Windows.Forms.Button tbl11
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl11;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl11 != null)
            {
                _tbl11.Click -= Seating_Dining_Click;
            }

            _tbl11 = value;
            if (_tbl11 != null)
            {
                _tbl11.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl12;

    internal virtual Global.System.Windows.Forms.Button tbl12
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl12;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl12 != null)
            {
                _tbl12.Click -= Seating_Dining_Click;
            }

            _tbl12 = value;
            if (_tbl12 != null)
            {
                _tbl12.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl10;

    internal virtual Global.System.Windows.Forms.Button tbl10
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl10;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl10 != null)
            {
                _tbl10.Click -= Seating_Dining_Click;
            }

            _tbl10 = value;
            if (_tbl10 != null)
            {
                _tbl10.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl3;

    internal virtual Global.System.Windows.Forms.Button tbl3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl3 != null)
            {
                _tbl3.Click -= Seating_Dining_Click;
            }

            _tbl3 = value;
            if (_tbl3 != null)
            {
                _tbl3.Click += Seating_Dining_Click;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _pnlDownStairs = new System.Windows.Forms.Panel();
        _tbl104 = new System.Windows.Forms.Button();
        _tbl104.Click += Seating_Dining_Click;
        _tbl108 = new System.Windows.Forms.Button();
        _tbl108.Click += Seating_Dining_Click;
        _tbl107 = new System.Windows.Forms.Button();
        _tbl107.Click += Seating_Dining_Click;
        _tbl106 = new System.Windows.Forms.Button();
        _tbl106.Click += Seating_Dining_Click;
        _tbl105 = new System.Windows.Forms.Button();
        _tbl105.Click += Seating_Dining_Click;
        _tbl103 = new System.Windows.Forms.Button();
        _tbl103.Click += Seating_Dining_Click;
        _tbl102 = new System.Windows.Forms.Button();
        _tbl102.Click += Seating_Dining_Click;
        _Panel1 = new System.Windows.Forms.Panel();
        _Panel5 = new System.Windows.Forms.Panel();
        _Panel6 = new System.Windows.Forms.Panel();
        _Panel2 = new System.Windows.Forms.Panel();
        _tbl7 = new System.Windows.Forms.Button();
        _tbl7.Click += Seating_Dining_Click;
        _tbl6 = new System.Windows.Forms.Button();
        _tbl6.Click += Seating_Dining_Click;
        _tbl5 = new System.Windows.Forms.Button();
        _tbl5.Click += Seating_Dining_Click;
        _tbl11 = new System.Windows.Forms.Button();
        _tbl11.Click += Seating_Dining_Click;
        _tbl12 = new System.Windows.Forms.Button();
        _tbl12.Click += Seating_Dining_Click;
        _tbl9 = new System.Windows.Forms.Button();
        _tbl9.Click += Seating_Dining_Click;
        _tbl10 = new System.Windows.Forms.Button();
        _tbl10.Click += Seating_Dining_Click;
        _tbl4 = new System.Windows.Forms.Button();
        _tbl4.Click += Seating_Dining_Click;
        _tbl101 = new System.Windows.Forms.Button();
        _tbl101.Click += Seating_Dining_Click;
        _tbl8 = new System.Windows.Forms.Button();
        _tbl8.Click += Seating_Dining_Click;
        _tbl3 = new System.Windows.Forms.Button();
        _tbl3.Click += Seating_Dining_Click;
        _Panel3 = new System.Windows.Forms.Panel();
        _Panel4 = new System.Windows.Forms.Panel();
        _tbl2 = new System.Windows.Forms.Button();
        _tbl2.Click += Seating_Dining_Click;
        _tbl1 = new System.Windows.Forms.Button();
        _tbl1.Click += Seating_Dining_Click;
        _pnlDownStairs.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlDownStairs
        // 
        _pnlDownStairs.BackColor = System.Drawing.Color.Black;
        _pnlDownStairs.Controls.Add(_tbl104);
        _pnlDownStairs.Controls.Add(_tbl108);
        _pnlDownStairs.Controls.Add(_tbl107);
        _pnlDownStairs.Controls.Add(_tbl106);
        _pnlDownStairs.Controls.Add(_tbl105);
        _pnlDownStairs.Controls.Add(_tbl103);
        _pnlDownStairs.Controls.Add(_tbl102);
        _pnlDownStairs.Controls.Add(_Panel1);
        _pnlDownStairs.Controls.Add(_Panel5);
        _pnlDownStairs.Controls.Add(_Panel6);
        _pnlDownStairs.Controls.Add(_Panel2);
        _pnlDownStairs.Controls.Add(_tbl7);
        _pnlDownStairs.Controls.Add(_tbl6);
        _pnlDownStairs.Controls.Add(_tbl5);
        _pnlDownStairs.Controls.Add(_tbl11);
        _pnlDownStairs.Controls.Add(_tbl12);
        _pnlDownStairs.Controls.Add(_tbl9);
        _pnlDownStairs.Controls.Add(_tbl10);
        _pnlDownStairs.Controls.Add(_tbl4);
        _pnlDownStairs.Controls.Add(_tbl101);
        _pnlDownStairs.Controls.Add(_tbl8);
        _pnlDownStairs.Controls.Add(_tbl3);
        _pnlDownStairs.Controls.Add(_Panel3);
        _pnlDownStairs.Controls.Add(_Panel4);
        _pnlDownStairs.Controls.Add(_tbl2);
        _pnlDownStairs.Controls.Add(_tbl1);
        _pnlDownStairs.Location = new System.Drawing.Point(40, 24);
        _pnlDownStairs.Name = "_pnlDownStairs";
        _pnlDownStairs.Size = new System.Drawing.Size(712, 528);
        _pnlDownStairs.TabIndex = 19;
        // 
        // tbl104
        // 
        _tbl104.BackColor = System.Drawing.Color.DarkGray;
        _tbl104.ForeColor = System.Drawing.Color.White;
        _tbl104.Location = new System.Drawing.Point(312, 72);
        _tbl104.Name = "_tbl104";
        _tbl104.Size = new System.Drawing.Size(40, 40);
        _tbl104.TabIndex = 41;
        _tbl104.Text = "104";
        // 
        // tbl108
        // 
        _tbl108.BackColor = System.Drawing.Color.DarkGray;
        _tbl108.ForeColor = System.Drawing.Color.White;
        _tbl108.Location = new System.Drawing.Point(536, 72);
        _tbl108.Name = "_tbl108";
        _tbl108.Size = new System.Drawing.Size(40, 40);
        _tbl108.TabIndex = 40;
        _tbl108.Text = "108";
        // 
        // tbl107
        // 
        _tbl107.BackColor = System.Drawing.Color.DarkGray;
        _tbl107.ForeColor = System.Drawing.Color.White;
        _tbl107.Location = new System.Drawing.Point(480, 72);
        _tbl107.Name = "_tbl107";
        _tbl107.Size = new System.Drawing.Size(40, 40);
        _tbl107.TabIndex = 39;
        _tbl107.Text = "107";
        // 
        // tbl106
        // 
        _tbl106.BackColor = System.Drawing.Color.DarkGray;
        _tbl106.ForeColor = System.Drawing.Color.White;
        _tbl106.Location = new System.Drawing.Point(424, 72);
        _tbl106.Name = "_tbl106";
        _tbl106.Size = new System.Drawing.Size(40, 40);
        _tbl106.TabIndex = 38;
        _tbl106.Text = "106";
        // 
        // tbl105
        // 
        _tbl105.BackColor = System.Drawing.Color.DarkGray;
        _tbl105.ForeColor = System.Drawing.Color.White;
        _tbl105.Location = new System.Drawing.Point(368, 72);
        _tbl105.Name = "_tbl105";
        _tbl105.Size = new System.Drawing.Size(40, 40);
        _tbl105.TabIndex = 37;
        _tbl105.Text = "105";
        // 
        // tbl103
        // 
        _tbl103.BackColor = System.Drawing.Color.DarkGray;
        _tbl103.ForeColor = System.Drawing.Color.White;
        _tbl103.Location = new System.Drawing.Point(256, 72);
        _tbl103.Name = "_tbl103";
        _tbl103.Size = new System.Drawing.Size(40, 40);
        _tbl103.TabIndex = 36;
        _tbl103.Text = "103";
        // 
        // tbl102
        // 
        _tbl102.BackColor = System.Drawing.Color.DarkGray;
        _tbl102.ForeColor = System.Drawing.Color.White;
        _tbl102.Location = new System.Drawing.Point(200, 72);
        _tbl102.Name = "_tbl102";
        _tbl102.Size = new System.Drawing.Size(40, 40);
        _tbl102.TabIndex = 35;
        _tbl102.Text = "102";
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.Color.SlateBlue;
        _Panel1.Location = new System.Drawing.Point(696, 0);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(16, 528);
        _Panel1.TabIndex = 34;
        // 
        // Panel5
        // 
        _Panel5.BackColor = System.Drawing.Color.SlateBlue;
        _Panel5.Location = new System.Drawing.Point(584, 64);
        _Panel5.Name = "_Panel5";
        _Panel5.Size = new System.Drawing.Size(32, 48);
        _Panel5.TabIndex = 33;
        // 
        // Panel6
        // 
        _Panel6.BackColor = System.Drawing.Color.SlateBlue;
        _Panel6.Location = new System.Drawing.Point(160, 32);
        _Panel6.Name = "_Panel6";
        _Panel6.Size = new System.Drawing.Size(456, 32);
        _Panel6.TabIndex = 32;
        // 
        // Panel2
        // 
        _Panel2.BackColor = System.Drawing.Color.SlateBlue;
        _Panel2.Location = new System.Drawing.Point(568, 400);
        _Panel2.Name = "_Panel2";
        _Panel2.Size = new System.Drawing.Size(128, 16);
        _Panel2.TabIndex = 30;
        // 
        // tbl7
        // 
        _tbl7.BackColor = System.Drawing.Color.DarkGray;
        _tbl7.ForeColor = System.Drawing.Color.White;
        _tbl7.Location = new System.Drawing.Point(336, 168);
        _tbl7.Name = "_tbl7";
        _tbl7.Size = new System.Drawing.Size(64, 48);
        _tbl7.TabIndex = 29;
        _tbl7.Text = "7";
        // 
        // tbl6
        // 
        _tbl6.BackColor = System.Drawing.Color.DarkGray;
        _tbl6.ForeColor = System.Drawing.Color.White;
        _tbl6.Location = new System.Drawing.Point(192, 336);
        _tbl6.Name = "_tbl6";
        _tbl6.Size = new System.Drawing.Size(64, 48);
        _tbl6.TabIndex = 28;
        _tbl6.Text = "6";
        // 
        // tbl5
        // 
        _tbl5.BackColor = System.Drawing.Color.DarkGray;
        _tbl5.ForeColor = System.Drawing.Color.White;
        _tbl5.Location = new System.Drawing.Point(192, 248);
        _tbl5.Name = "_tbl5";
        _tbl5.Size = new System.Drawing.Size(64, 48);
        _tbl5.TabIndex = 27;
        _tbl5.Text = "5";
        // 
        // tbl11
        // 
        _tbl11.BackColor = System.Drawing.Color.DarkGray;
        _tbl11.ForeColor = System.Drawing.Color.White;
        _tbl11.Location = new System.Drawing.Point(400, 336);
        _tbl11.Name = "_tbl11";
        _tbl11.Size = new System.Drawing.Size(96, 48);
        _tbl11.TabIndex = 26;
        _tbl11.Text = "11";
        // 
        // tbl12
        // 
        _tbl12.BackColor = System.Drawing.Color.DarkGray;
        _tbl12.ForeColor = System.Drawing.Color.White;
        _tbl12.Location = new System.Drawing.Point(600, 200);
        _tbl12.Name = "_tbl12";
        _tbl12.Size = new System.Drawing.Size(48, 80);
        _tbl12.TabIndex = 25;
        _tbl12.Text = "12";
        // 
        // tbl9
        // 
        _tbl9.BackColor = System.Drawing.Color.DarkGray;
        _tbl9.ForeColor = System.Drawing.Color.White;
        _tbl9.Location = new System.Drawing.Point(472, 168);
        _tbl9.Name = "_tbl9";
        _tbl9.Size = new System.Drawing.Size(48, 48);
        _tbl9.TabIndex = 24;
        _tbl9.Text = "9";
        // 
        // tbl10
        // 
        _tbl10.BackColor = System.Drawing.Color.DarkGray;
        _tbl10.ForeColor = System.Drawing.Color.White;
        _tbl10.Location = new System.Drawing.Point(464, 248);
        _tbl10.Name = "_tbl10";
        _tbl10.Size = new System.Drawing.Size(64, 48);
        _tbl10.TabIndex = 23;
        _tbl10.Text = "10";
        // 
        // tbl4
        // 
        _tbl4.BackColor = System.Drawing.Color.DarkGray;
        _tbl4.ForeColor = System.Drawing.Color.White;
        _tbl4.Location = new System.Drawing.Point(192, 168);
        _tbl4.Name = "_tbl4";
        _tbl4.Size = new System.Drawing.Size(64, 48);
        _tbl4.TabIndex = 22;
        _tbl4.Text = "4";
        // 
        // tbl101
        // 
        _tbl101.BackColor = System.Drawing.Color.DarkGray;
        _tbl101.ForeColor = System.Drawing.Color.White;
        _tbl101.Location = new System.Drawing.Point(144, 72);
        _tbl101.Name = "_tbl101";
        _tbl101.Size = new System.Drawing.Size(40, 40);
        _tbl101.TabIndex = 21;
        _tbl101.Text = "101";
        // 
        // tbl8
        // 
        _tbl8.BackColor = System.Drawing.Color.DarkGray;
        _tbl8.ForeColor = System.Drawing.Color.White;
        _tbl8.Location = new System.Drawing.Point(336, 248);
        _tbl8.Name = "_tbl8";
        _tbl8.Size = new System.Drawing.Size(64, 48);
        _tbl8.TabIndex = 20;
        _tbl8.Text = "8";
        // 
        // tbl3
        // 
        _tbl3.BackColor = System.Drawing.Color.DarkGray;
        _tbl3.ForeColor = System.Drawing.Color.White;
        _tbl3.Location = new System.Drawing.Point(16, 336);
        _tbl3.Name = "_tbl3";
        _tbl3.Size = new System.Drawing.Size(64, 48);
        _tbl3.TabIndex = 19;
        _tbl3.Text = "3";
        // 
        // Panel3
        // 
        _Panel3.BackColor = System.Drawing.Color.SlateBlue;
        _Panel3.Location = new System.Drawing.Point(144, 0);
        _Panel3.Name = "_Panel3";
        _Panel3.Size = new System.Drawing.Size(16, 64);
        _Panel3.TabIndex = 18;
        // 
        // Panel4
        // 
        _Panel4.BackColor = System.Drawing.Color.SlateBlue;
        _Panel4.Location = new System.Drawing.Point(0, 408);
        _Panel4.Name = "_Panel4";
        _Panel4.Size = new System.Drawing.Size(120, 16);
        _Panel4.TabIndex = 17;
        // 
        // tbl2
        // 
        _tbl2.BackColor = System.Drawing.Color.DarkGray;
        _tbl2.ForeColor = System.Drawing.Color.White;
        _tbl2.Location = new System.Drawing.Point(16, 248);
        _tbl2.Name = "_tbl2";
        _tbl2.Size = new System.Drawing.Size(64, 48);
        _tbl2.TabIndex = 15;
        _tbl2.Text = "2";
        // 
        // tbl1
        // 
        _tbl1.BackColor = System.Drawing.Color.DarkGray;
        _tbl1.ForeColor = System.Drawing.Color.White;
        _tbl1.Location = new System.Drawing.Point(16, 168);
        _tbl1.Name = "_tbl1";
        _tbl1.Size = new System.Drawing.Size(64, 48);
        _tbl1.TabIndex = 1;
        _tbl1.Text = "1";
        // 
        // Seating_Dining_Cesar
        // 
        this.BackColor = System.Drawing.Color.LightSlateGray;
        this.Controls.Add(_pnlDownStairs);
        this.Name = "Seating_Dining_Cesar";
        this.Size = new System.Drawing.Size(792, 573);
        _pnlDownStairs.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private void InitializeOther()
    {


        AdjustTableColor();
        // not using below line while testing
        AdjustTableColorForCurrentEmployee();

    }

    private void AdjustTableColor()
    {
        Color cc;  // PhysicalTable

        foreach (DataRow oRow in dsOrder.Tables("AllTables").Rows)    // currentPhysicalTables
        {
            cc = DetermineColor(oRow("TableStatusID"));    // .CurrentStatus)
            ChangeColor(oRow("TableNumber"), cc);     // .PhysicalTableNumber, cc)
        }

    }

    internal void ChangeColor(int tableNumber, Color cc)
    {

        switch (tableNumber)
        {
            case 1:
                {
                    tbl1.BackColor = cc;
                    break;
                }
            case 2:
                {
                    tbl2.BackColor = cc;
                    break;
                }
            case 3:
                {
                    tbl3.BackColor = cc;
                    break;
                }
            case 4:
                {
                    tbl4.BackColor = cc;
                    break;
                }
            case 5:
                {
                    tbl5.BackColor = cc;
                    break;
                }
            case 6:
                {
                    tbl6.BackColor = cc;
                    break;
                }
            case 7:
                {
                    tbl7.BackColor = cc;
                    break;
                }
            case 8:
                {
                    tbl8.BackColor = cc;
                    break;
                }
            case 9:
                {
                    tbl9.BackColor = cc;
                    break;
                }
            case 10:
                {
                    tbl10.BackColor = cc;
                    break;
                }
            case 11:
                {
                    tbl11.BackColor = cc;
                    break;
                }
            case 12:
                {
                    tbl12.BackColor = cc;
                    break;
                }
            case 101:
                {
                    tbl101.BackColor = cc;
                    break;
                }
            case 102:
                {
                    tbl102.BackColor = cc;
                    break;
                }
            case 103:
                {
                    tbl103.BackColor = cc;
                    break;
                }
            case 104:
                {
                    tbl104.BackColor = cc;
                    break;
                }
            case 105:
                {
                    tbl105.BackColor = cc;
                    break;
                }
            case 106:
                {
                    tbl106.BackColor = cc;
                    break;
                }
            case 107:
                {
                    tbl107.BackColor = cc;
                    break;
                }
            case 108:
                {
                    tbl108.BackColor = cc;
                    break;
                }

        }

    }


    internal object DetermineColor(int currentStatus)
    {
        Color colorChoice;
        // do not change colors
        // status is dependant on colors in other parts of program

        if (currentStatus == 0)      // unavailable
        {
            colorChoice = c5;            // dim gray
        }
        else if (currentStatus == 1)  // available for seating
        {
            colorChoice = c6;            // slate blue
        }
        else if (currentStatus == 7) // check down
        {
            colorChoice = c1;            // yellow
        }
        else                                // table sat (includes all)
        {
            colorChoice = c9;
        }            // red

        return colorChoice;
    }

    private void AdjustTableColorForCurrentEmployee()
    {

        foreach (DataRow oRow in dsOrder.Tables("AvailTables").Rows)
            ChangeColor(oRow("TableNumber"), Color.LightGreen);

    }
    private void Seating_Dining_Click(object sender, EventArgs e)
    {

        TableSelectedEvent?.Invoke(sender, e);


    }


}