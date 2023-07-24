using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public partial class Seating_Dining2 : System.Windows.Forms.UserControl
{

    private DataSet_Builder.SQLHelper sql;


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

    public Seating_Dining2() : base()
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
    private Global.System.Windows.Forms.Button _tbl904;

    internal virtual Global.System.Windows.Forms.Button tbl904
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl904;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl904 != null)
            {
                _tbl904.Click -= Seating_Dining_Click;
            }

            _tbl904 = value;
            if (_tbl904 != null)
            {
                _tbl904.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl903;

    internal virtual Global.System.Windows.Forms.Button tbl903
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl903;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl903 != null)
            {
                _tbl903.Click -= Seating_Dining_Click;
            }

            _tbl903 = value;
            if (_tbl903 != null)
            {
                _tbl903.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl902;

    internal virtual Global.System.Windows.Forms.Button tbl902
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl902;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl902 != null)
            {
                _tbl902.Click -= Seating_Dining_Click;
            }

            _tbl902 = value;
            if (_tbl902 != null)
            {
                _tbl902.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl901;

    internal virtual Global.System.Windows.Forms.Button tbl901
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl901;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl901 != null)
            {
                _tbl901.Click -= Seating_Dining_Click;
            }

            _tbl901 = value;
            if (_tbl901 != null)
            {
                _tbl901.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl905;

    internal virtual Global.System.Windows.Forms.Button tbl905
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl905;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl905 != null)
            {
                _tbl905.Click -= Seating_Dining_Click;
            }

            _tbl905 = value;
            if (_tbl905 != null)
            {
                _tbl905.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl917;

    internal virtual Global.System.Windows.Forms.Button tbl917
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl917;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl917 != null)
            {
                _tbl917.Click -= Seating_Dining_Click;
            }

            _tbl917 = value;
            if (_tbl917 != null)
            {
                _tbl917.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl916;

    internal virtual Global.System.Windows.Forms.Button tbl916
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl916;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl916 != null)
            {
                _tbl916.Click -= Seating_Dining_Click;
            }

            _tbl916 = value;
            if (_tbl916 != null)
            {
                _tbl916.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl915;

    internal virtual Global.System.Windows.Forms.Button tbl915
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl915;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl915 != null)
            {
                _tbl915.Click -= Seating_Dining_Click;
            }

            _tbl915 = value;
            if (_tbl915 != null)
            {
                _tbl915.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl906;

    internal virtual Global.System.Windows.Forms.Button tbl906
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl906;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl906 != null)
            {
                _tbl906.Click -= Seating_Dining_Click;
                _tbl906.Click -= Seating_Dining_Click;
            }

            _tbl906 = value;
            if (_tbl906 != null)
            {
                _tbl906.Click += Seating_Dining_Click;
                _tbl906.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl920;

    internal virtual Global.System.Windows.Forms.Button tbl920
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl920;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl920 != null)
            {
                _tbl920.Click -= Seating_Dining_Click;
            }

            _tbl920 = value;
            if (_tbl920 != null)
            {
                _tbl920.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl922;

    internal virtual Global.System.Windows.Forms.Button tbl922
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl922;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl922 != null)
            {
                _tbl922.Click -= Seating_Dining_Click;
            }

            _tbl922 = value;
            if (_tbl922 != null)
            {
                _tbl922.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl919;

    internal virtual Global.System.Windows.Forms.Button tbl919
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl919;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl919 != null)
            {
                _tbl919.Click -= Seating_Dining_Click;
            }

            _tbl919 = value;
            if (_tbl919 != null)
            {
                _tbl919.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl914;

    internal virtual Global.System.Windows.Forms.Button tbl914
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl914;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl914 != null)
            {
                _tbl914.Click -= Seating_Dining_Click;
            }

            _tbl914 = value;
            if (_tbl914 != null)
            {
                _tbl914.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl921;

    internal virtual Global.System.Windows.Forms.Button tbl921
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl921;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl921 != null)
            {
                _tbl921.Click -= Seating_Dining_Click;
            }

            _tbl921 = value;
            if (_tbl921 != null)
            {
                _tbl921.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl918;

    internal virtual Global.System.Windows.Forms.Button tbl918
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl918;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl918 != null)
            {
                _tbl918.Click -= Seating_Dining_Click;
            }

            _tbl918 = value;
            if (_tbl918 != null)
            {
                _tbl918.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl913;

    internal virtual Global.System.Windows.Forms.Button tbl913
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl913;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl913 != null)
            {
                _tbl913.Click -= Seating_Dining_Click;
            }

            _tbl913 = value;
            if (_tbl913 != null)
            {
                _tbl913.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl912;

    internal virtual Global.System.Windows.Forms.Button tbl912
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl912;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl912 != null)
            {
                _tbl912.Click -= Seating_Dining_Click;
            }

            _tbl912 = value;
            if (_tbl912 != null)
            {
                _tbl912.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl911;

    internal virtual Global.System.Windows.Forms.Button tbl911
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl911;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl911 != null)
            {
                _tbl911.Click -= Seating_Dining_Click;
            }

            _tbl911 = value;
            if (_tbl911 != null)
            {
                _tbl911.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl910;

    internal virtual Global.System.Windows.Forms.Button tbl910
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl910;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl910 != null)
            {
                _tbl910.Click -= Seating_Dining_Click;
            }

            _tbl910 = value;
            if (_tbl910 != null)
            {
                _tbl910.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl909;

    internal virtual Global.System.Windows.Forms.Button tbl909
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl909;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl909 != null)
            {
                _tbl909.Click -= Seating_Dining_Click;
            }

            _tbl909 = value;
            if (_tbl909 != null)
            {
                _tbl909.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl908;

    internal virtual Global.System.Windows.Forms.Button tbl908
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl908;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl908 != null)
            {
                _tbl908.Click -= Seating_Dining_Click;
            }

            _tbl908 = value;
            if (_tbl908 != null)
            {
                _tbl908.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl907;

    internal virtual Global.System.Windows.Forms.Button tbl907
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl907;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl907 != null)
            {
                _tbl907.Click -= Seating_Dining_Click;
            }

            _tbl907 = value;
            if (_tbl907 != null)
            {
                _tbl907.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _pnlBar;

    internal virtual Global.System.Windows.Forms.Panel pnlBar
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlBar;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlBar = value;
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _pnlBar = new System.Windows.Forms.Panel();
        _tbl905 = new System.Windows.Forms.Button();
        _tbl905.Click += Seating_Dining_Click;
        _tbl907 = new System.Windows.Forms.Button();
        _tbl907.Click += Seating_Dining_Click;
        _tbl908 = new System.Windows.Forms.Button();
        _tbl908.Click += Seating_Dining_Click;
        _tbl909 = new System.Windows.Forms.Button();
        _tbl909.Click += Seating_Dining_Click;
        _tbl910 = new System.Windows.Forms.Button();
        _tbl910.Click += Seating_Dining_Click;
        _tbl901 = new System.Windows.Forms.Button();
        _tbl901.Click += Seating_Dining_Click;
        _tbl902 = new System.Windows.Forms.Button();
        _tbl902.Click += Seating_Dining_Click;
        _tbl903 = new System.Windows.Forms.Button();
        _tbl903.Click += Seating_Dining_Click;
        _tbl904 = new System.Windows.Forms.Button();
        _tbl904.Click += Seating_Dining_Click;
        _Panel1 = new System.Windows.Forms.Panel();
        _Panel5 = new System.Windows.Forms.Panel();
        _tbl917 = new System.Windows.Forms.Button();
        _tbl917.Click += Seating_Dining_Click;
        _tbl916 = new System.Windows.Forms.Button();
        _tbl916.Click += Seating_Dining_Click;
        _tbl915 = new System.Windows.Forms.Button();
        _tbl915.Click += Seating_Dining_Click;
        _tbl906 = new System.Windows.Forms.Button();
        _tbl906.Click += Seating_Dining_Click;
        _tbl906.Click += Seating_Dining_Click;
        _tbl920 = new System.Windows.Forms.Button();
        _tbl920.Click += Seating_Dining_Click;
        _tbl922 = new System.Windows.Forms.Button();
        _tbl922.Click += Seating_Dining_Click;
        _tbl919 = new System.Windows.Forms.Button();
        _tbl919.Click += Seating_Dining_Click;
        _tbl914 = new System.Windows.Forms.Button();
        _tbl914.Click += Seating_Dining_Click;
        _tbl921 = new System.Windows.Forms.Button();
        _tbl921.Click += Seating_Dining_Click;
        _tbl918 = new System.Windows.Forms.Button();
        _tbl918.Click += Seating_Dining_Click;
        _tbl913 = new System.Windows.Forms.Button();
        _tbl913.Click += Seating_Dining_Click;
        _Panel3 = new System.Windows.Forms.Panel();
        _Panel4 = new System.Windows.Forms.Panel();
        _tbl912 = new System.Windows.Forms.Button();
        _tbl912.Click += Seating_Dining_Click;
        _tbl911 = new System.Windows.Forms.Button();
        _tbl911.Click += Seating_Dining_Click;
        _pnlBar.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlBar
        // 
        _pnlBar.BackColor = System.Drawing.Color.Black;
        _pnlBar.Controls.Add(_tbl905);
        _pnlBar.Controls.Add(_tbl907);
        _pnlBar.Controls.Add(_tbl908);
        _pnlBar.Controls.Add(_tbl909);
        _pnlBar.Controls.Add(_tbl910);
        _pnlBar.Controls.Add(_tbl901);
        _pnlBar.Controls.Add(_tbl902);
        _pnlBar.Controls.Add(_tbl903);
        _pnlBar.Controls.Add(_tbl904);
        _pnlBar.Controls.Add(_Panel1);
        _pnlBar.Controls.Add(_Panel5);
        _pnlBar.Controls.Add(_tbl917);
        _pnlBar.Controls.Add(_tbl916);
        _pnlBar.Controls.Add(_tbl915);
        _pnlBar.Controls.Add(_tbl906);
        _pnlBar.Controls.Add(_tbl920);
        _pnlBar.Controls.Add(_tbl922);
        _pnlBar.Controls.Add(_tbl919);
        _pnlBar.Controls.Add(_tbl914);
        _pnlBar.Controls.Add(_tbl921);
        _pnlBar.Controls.Add(_tbl918);
        _pnlBar.Controls.Add(_tbl913);
        _pnlBar.Controls.Add(_Panel3);
        _pnlBar.Controls.Add(_Panel4);
        _pnlBar.Controls.Add(_tbl912);
        _pnlBar.Controls.Add(_tbl911);
        _pnlBar.Location = new System.Drawing.Point(40, 24);
        _pnlBar.Name = "_pnlBar";
        _pnlBar.Size = new System.Drawing.Size(696, 512);
        _pnlBar.TabIndex = 19;
        // 
        // tbl905
        // 
        _tbl905.BackColor = System.Drawing.Color.DarkGray;
        _tbl905.ForeColor = System.Drawing.Color.White;
        _tbl905.Location = new System.Drawing.Point(216, 96);
        _tbl905.Name = "_tbl905";
        _tbl905.Size = new System.Drawing.Size(40, 40);
        _tbl905.TabIndex = 43;
        _tbl905.Text = "905";
        // 
        // tbl907
        // 
        _tbl907.BackColor = System.Drawing.Color.DarkGray;
        _tbl907.ForeColor = System.Drawing.Color.White;
        _tbl907.Location = new System.Drawing.Point(64, 144);
        _tbl907.Name = "_tbl907";
        _tbl907.Size = new System.Drawing.Size(40, 40);
        _tbl907.TabIndex = 42;
        _tbl907.Text = "907";
        // 
        // tbl908
        // 
        _tbl908.BackColor = System.Drawing.Color.DarkGray;
        _tbl908.ForeColor = System.Drawing.Color.White;
        _tbl908.Location = new System.Drawing.Point(112, 144);
        _tbl908.Name = "_tbl908";
        _tbl908.Size = new System.Drawing.Size(40, 40);
        _tbl908.TabIndex = 41;
        _tbl908.Text = "908";
        // 
        // tbl909
        // 
        _tbl909.BackColor = System.Drawing.Color.DarkGray;
        _tbl909.ForeColor = System.Drawing.Color.White;
        _tbl909.Location = new System.Drawing.Point(160, 144);
        _tbl909.Name = "_tbl909";
        _tbl909.Size = new System.Drawing.Size(40, 40);
        _tbl909.TabIndex = 40;
        _tbl909.Text = "909";
        // 
        // tbl910
        // 
        _tbl910.BackColor = System.Drawing.Color.DarkGray;
        _tbl910.ForeColor = System.Drawing.Color.White;
        _tbl910.Location = new System.Drawing.Point(216, 144);
        _tbl910.Name = "_tbl910";
        _tbl910.Size = new System.Drawing.Size(40, 40);
        _tbl910.TabIndex = 39;
        _tbl910.Text = "910";
        // 
        // tbl901
        // 
        _tbl901.BackColor = System.Drawing.Color.DarkGray;
        _tbl901.ForeColor = System.Drawing.Color.White;
        _tbl901.Location = new System.Drawing.Point(16, 96);
        _tbl901.Name = "_tbl901";
        _tbl901.Size = new System.Drawing.Size(40, 40);
        _tbl901.TabIndex = 38;
        _tbl901.Text = "901";
        // 
        // tbl902
        // 
        _tbl902.BackColor = System.Drawing.Color.DarkGray;
        _tbl902.ForeColor = System.Drawing.Color.White;
        _tbl902.Location = new System.Drawing.Point(64, 96);
        _tbl902.Name = "_tbl902";
        _tbl902.Size = new System.Drawing.Size(40, 40);
        _tbl902.TabIndex = 37;
        _tbl902.Text = "902";
        // 
        // tbl903
        // 
        _tbl903.BackColor = System.Drawing.Color.DarkGray;
        _tbl903.ForeColor = System.Drawing.Color.White;
        _tbl903.Location = new System.Drawing.Point(112, 96);
        _tbl903.Name = "_tbl903";
        _tbl903.Size = new System.Drawing.Size(40, 40);
        _tbl903.TabIndex = 36;
        _tbl903.Text = "903";
        // 
        // tbl904
        // 
        _tbl904.BackColor = System.Drawing.Color.DarkGray;
        _tbl904.ForeColor = System.Drawing.Color.White;
        _tbl904.Location = new System.Drawing.Point(160, 96);
        _tbl904.Name = "_tbl904";
        _tbl904.Size = new System.Drawing.Size(40, 40);
        _tbl904.TabIndex = 35;
        _tbl904.Text = "904";
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.Color.SlateBlue;
        _Panel1.Location = new System.Drawing.Point(568, 0);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(16, 480);
        _Panel1.TabIndex = 34;
        // 
        // Panel5
        // 
        _Panel5.BackColor = System.Drawing.Color.SlateBlue;
        _Panel5.Location = new System.Drawing.Point(120, 192);
        _Panel5.Name = "_Panel5";
        _Panel5.Size = new System.Drawing.Size(16, 304);
        _Panel5.TabIndex = 33;
        // 
        // tbl917
        // 
        _tbl917.BackColor = System.Drawing.Color.DarkGray;
        _tbl917.ForeColor = System.Drawing.Color.White;
        _tbl917.Location = new System.Drawing.Point(216, 192);
        _tbl917.Name = "_tbl917";
        _tbl917.Size = new System.Drawing.Size(40, 40);
        _tbl917.TabIndex = 29;
        _tbl917.Text = "917";
        // 
        // tbl916
        // 
        _tbl916.BackColor = System.Drawing.Color.DarkGray;
        _tbl916.ForeColor = System.Drawing.Color.White;
        _tbl916.Location = new System.Drawing.Point(160, 432);
        _tbl916.Name = "_tbl916";
        _tbl916.Size = new System.Drawing.Size(40, 40);
        _tbl916.TabIndex = 28;
        _tbl916.Text = "916";
        // 
        // tbl915
        // 
        _tbl915.BackColor = System.Drawing.Color.DarkGray;
        _tbl915.ForeColor = System.Drawing.Color.White;
        _tbl915.Location = new System.Drawing.Point(160, 384);
        _tbl915.Name = "_tbl915";
        _tbl915.Size = new System.Drawing.Size(40, 40);
        _tbl915.TabIndex = 27;
        _tbl915.Text = "915";
        // 
        // tbl906
        // 
        _tbl906.BackColor = System.Drawing.Color.DarkGray;
        _tbl906.ForeColor = System.Drawing.Color.White;
        _tbl906.Location = new System.Drawing.Point(16, 144);
        _tbl906.Name = "_tbl906";
        _tbl906.Size = new System.Drawing.Size(40, 40);
        _tbl906.TabIndex = 26;
        _tbl906.Text = "906";
        // 
        // tbl920
        // 
        _tbl920.BackColor = System.Drawing.Color.DarkGray;
        _tbl920.ForeColor = System.Drawing.Color.White;
        _tbl920.Location = new System.Drawing.Point(216, 336);
        _tbl920.Name = "_tbl920";
        _tbl920.Size = new System.Drawing.Size(40, 40);
        _tbl920.TabIndex = 25;
        _tbl920.Text = "920";
        // 
        // tbl922
        // 
        _tbl922.BackColor = System.Drawing.Color.DarkGray;
        _tbl922.ForeColor = System.Drawing.Color.White;
        _tbl922.Location = new System.Drawing.Point(216, 432);
        _tbl922.Name = "_tbl922";
        _tbl922.Size = new System.Drawing.Size(40, 40);
        _tbl922.TabIndex = 24;
        _tbl922.Text = "922";
        // 
        // tbl919
        // 
        _tbl919.BackColor = System.Drawing.Color.DarkGray;
        _tbl919.ForeColor = System.Drawing.Color.White;
        _tbl919.Location = new System.Drawing.Point(216, 288);
        _tbl919.Name = "_tbl919";
        _tbl919.Size = new System.Drawing.Size(40, 40);
        _tbl919.TabIndex = 23;
        _tbl919.Text = "919";
        // 
        // tbl914
        // 
        _tbl914.BackColor = System.Drawing.Color.DarkGray;
        _tbl914.ForeColor = System.Drawing.Color.White;
        _tbl914.Location = new System.Drawing.Point(160, 336);
        _tbl914.Name = "_tbl914";
        _tbl914.Size = new System.Drawing.Size(40, 40);
        _tbl914.TabIndex = 22;
        _tbl914.Text = "914";
        // 
        // tbl921
        // 
        _tbl921.BackColor = System.Drawing.Color.DarkGray;
        _tbl921.ForeColor = System.Drawing.Color.White;
        _tbl921.Location = new System.Drawing.Point(216, 384);
        _tbl921.Name = "_tbl921";
        _tbl921.Size = new System.Drawing.Size(40, 40);
        _tbl921.TabIndex = 21;
        _tbl921.Text = "921";
        // 
        // tbl918
        // 
        _tbl918.BackColor = System.Drawing.Color.DarkGray;
        _tbl918.ForeColor = System.Drawing.Color.White;
        _tbl918.Location = new System.Drawing.Point(216, 240);
        _tbl918.Name = "_tbl918";
        _tbl918.Size = new System.Drawing.Size(40, 40);
        _tbl918.TabIndex = 20;
        _tbl918.Text = "918";
        // 
        // tbl913
        // 
        _tbl913.BackColor = System.Drawing.Color.DarkGray;
        _tbl913.ForeColor = System.Drawing.Color.White;
        _tbl913.Location = new System.Drawing.Point(160, 288);
        _tbl913.Name = "_tbl913";
        _tbl913.Size = new System.Drawing.Size(40, 40);
        _tbl913.TabIndex = 19;
        _tbl913.Text = "913";
        // 
        // Panel3
        // 
        _Panel3.BackColor = System.Drawing.Color.Crimson;
        _Panel3.Location = new System.Drawing.Point(72, 0);
        _Panel3.Name = "_Panel3";
        _Panel3.Size = new System.Drawing.Size(136, 16);
        _Panel3.TabIndex = 18;
        // 
        // Panel4
        // 
        _Panel4.BackColor = System.Drawing.Color.SlateBlue;
        _Panel4.Location = new System.Drawing.Point(0, 192);
        _Panel4.Name = "_Panel4";
        _Panel4.Size = new System.Drawing.Size(120, 16);
        _Panel4.TabIndex = 17;
        // 
        // tbl912
        // 
        _tbl912.BackColor = System.Drawing.Color.DarkGray;
        _tbl912.ForeColor = System.Drawing.Color.White;
        _tbl912.Location = new System.Drawing.Point(160, 240);
        _tbl912.Name = "_tbl912";
        _tbl912.Size = new System.Drawing.Size(40, 40);
        _tbl912.TabIndex = 15;
        _tbl912.Text = "912";
        // 
        // tbl911
        // 
        _tbl911.BackColor = System.Drawing.Color.DarkGray;
        _tbl911.ForeColor = System.Drawing.Color.White;
        _tbl911.Location = new System.Drawing.Point(160, 192);
        _tbl911.Name = "_tbl911";
        _tbl911.Size = new System.Drawing.Size(40, 40);
        _tbl911.TabIndex = 1;
        _tbl911.Text = "911";
        // 
        // Seating_Dining2
        // 
        this.BackColor = System.Drawing.Color.LightSlateGray;
        this.Controls.Add(_pnlBar);
        this.Name = "Seating_Dining2";
        this.Size = new System.Drawing.Size(792, 573);
        _pnlBar.ResumeLayout(false);
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
            case 901:
                {
                    tbl901.BackColor = cc;
                    break;
                }
            case 902:
                {
                    tbl902.BackColor = cc;
                    break;
                }
            case 903:
                {
                    tbl903.BackColor = cc;
                    break;
                }
            case 904:
                {
                    tbl904.BackColor = cc;
                    break;
                }
            case 905:
                {
                    tbl905.BackColor = cc;
                    break;
                }
            case 906:
                {
                    tbl906.BackColor = cc;
                    break;
                }
            case 907:
                {
                    tbl907.BackColor = cc;
                    break;
                }
            case 908:
                {
                    tbl908.BackColor = cc;
                    break;
                }
            case 909:
                {
                    tbl909.BackColor = cc;
                    break;
                }
            case 910:
                {
                    tbl910.BackColor = cc;
                    break;
                }
            case 911:
                {
                    tbl911.BackColor = cc;
                    break;
                }
            case 912:
                {
                    tbl912.BackColor = cc;
                    break;
                }
            case 913:
                {
                    tbl913.BackColor = cc;
                    break;
                }
            case 914:
                {
                    tbl914.BackColor = cc;
                    break;
                }
            case 915:
                {
                    tbl915.BackColor = cc;
                    break;
                }
            case 916:
                {
                    tbl916.BackColor = cc;
                    break;
                }
            case 917:
                {
                    tbl917.BackColor = cc;
                    break;
                }
            case 918:
                {
                    tbl918.BackColor = cc;
                    break;
                }
            case 919:
                {
                    tbl919.BackColor = cc;
                    break;
                }
            case 920:
                {
                    tbl920.BackColor = cc;
                    break;
                }
            case 921:
                {
                    tbl921.BackColor = cc;
                    break;
                }
            case 922:
                {
                    tbl922.BackColor = cc;
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