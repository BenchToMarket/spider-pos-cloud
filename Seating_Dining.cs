using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public partial class Seating_Dining : System.Windows.Forms.UserControl
{

    private int _tableSelected;

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

    public event TableSelectedEventEventHandler TableSelectedEvent;

    public delegate void TableSelectedEventEventHandler(object sender, EventArgs e);


    #region  Windows Form Designer generated code 

    public Seating_Dining() : base()
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
    private Global.System.Windows.Forms.Button _tbl13;

    internal virtual Global.System.Windows.Forms.Button tbl13
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl13;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl13 != null)
            {
                _tbl13.Click -= Seating_Dining_Click;
            }

            _tbl13 = value;
            if (_tbl13 != null)
            {
                _tbl13.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl20;

    internal virtual Global.System.Windows.Forms.Button tbl20
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl20;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl20 != null)
            {
                _tbl20.Click -= Seating_Dining_Click;
            }

            _tbl20 = value;
            if (_tbl20 != null)
            {
                _tbl20.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl30;

    internal virtual Global.System.Windows.Forms.Button tbl30
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl30;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl30 != null)
            {
                _tbl30.Click -= Seating_Dining_Click;
            }

            _tbl30 = value;
            if (_tbl30 != null)
            {
                _tbl30.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl14;

    internal virtual Global.System.Windows.Forms.Button tbl14
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl14;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl14 != null)
            {
                _tbl14.Click -= Seating_Dining_Click;
            }

            _tbl14 = value;
            if (_tbl14 != null)
            {
                _tbl14.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl21;

    internal virtual Global.System.Windows.Forms.Button tbl21
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl21;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl21 != null)
            {
                _tbl21.Click -= Seating_Dining_Click;
            }

            _tbl21 = value;
            if (_tbl21 != null)
            {
                _tbl21.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl31;

    internal virtual Global.System.Windows.Forms.Button tbl31
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl31;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl31 != null)
            {
                _tbl31.Click -= Seating_Dining_Click;
            }

            _tbl31 = value;
            if (_tbl31 != null)
            {
                _tbl31.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl22;

    internal virtual Global.System.Windows.Forms.Button tbl22
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl22;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl22 != null)
            {
                _tbl22.Click -= Seating_Dining_Click;
            }

            _tbl22 = value;
            if (_tbl22 != null)
            {
                _tbl22.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl32;

    internal virtual Global.System.Windows.Forms.Button tbl32
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl32;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl32 != null)
            {
                _tbl32.Click -= Seating_Dining_Click;
            }

            _tbl32 = value;
            if (_tbl32 != null)
            {
                _tbl32.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl15;

    internal virtual Global.System.Windows.Forms.Button tbl15
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl15;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl15 != null)
            {
                _tbl15.Click -= Seating_Dining_Click;
            }

            _tbl15 = value;
            if (_tbl15 != null)
            {
                _tbl15.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl16;

    internal virtual Global.System.Windows.Forms.Button tbl16
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl16;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl16 != null)
            {
                _tbl16.Click -= Seating_Dining_Click;
            }

            _tbl16 = value;
            if (_tbl16 != null)
            {
                _tbl16.Click += Seating_Dining_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _tbl17;

    internal virtual Global.System.Windows.Forms.Button tbl17
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _tbl17;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_tbl17 != null)
            {
                _tbl17.Click -= Seating_Dining_Click;
            }

            _tbl17 = value;
            if (_tbl17 != null)
            {
                _tbl17.Click += Seating_Dining_Click;
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
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _pnlDownStairs = new System.Windows.Forms.Panel();
        _Panel1 = new System.Windows.Forms.Panel();
        _Panel5 = new System.Windows.Forms.Panel();
        _Panel6 = new System.Windows.Forms.Panel();
        _Panel2 = new System.Windows.Forms.Panel();
        _tbl17 = new System.Windows.Forms.Button();
        _tbl17.Click += Seating_Dining_Click;
        _tbl16 = new System.Windows.Forms.Button();
        _tbl16.Click += Seating_Dining_Click;
        _tbl15 = new System.Windows.Forms.Button();
        _tbl15.Click += Seating_Dining_Click;
        _tbl32 = new System.Windows.Forms.Button();
        _tbl32.Click += Seating_Dining_Click;
        _tbl22 = new System.Windows.Forms.Button();
        _tbl22.Click += Seating_Dining_Click;
        _tbl31 = new System.Windows.Forms.Button();
        _tbl31.Click += Seating_Dining_Click;
        _tbl21 = new System.Windows.Forms.Button();
        _tbl21.Click += Seating_Dining_Click;
        _tbl14 = new System.Windows.Forms.Button();
        _tbl14.Click += Seating_Dining_Click;
        _tbl30 = new System.Windows.Forms.Button();
        _tbl30.Click += Seating_Dining_Click;
        _tbl20 = new System.Windows.Forms.Button();
        _tbl20.Click += Seating_Dining_Click;
        _tbl13 = new System.Windows.Forms.Button();
        _tbl13.Click += Seating_Dining_Click;
        _Panel3 = new System.Windows.Forms.Panel();
        _Panel4 = new System.Windows.Forms.Panel();
        _tbl12 = new System.Windows.Forms.Button();
        _tbl12.Click += Seating_Dining_Click;
        _tbl11 = new System.Windows.Forms.Button();
        _tbl11.Click += Seating_Dining_Click;
        _pnlDownStairs.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlDownStairs
        // 
        _pnlDownStairs.BackColor = System.Drawing.Color.Black;
        _pnlDownStairs.Controls.Add(_Panel1);
        _pnlDownStairs.Controls.Add(_Panel5);
        _pnlDownStairs.Controls.Add(_Panel6);
        _pnlDownStairs.Controls.Add(_Panel2);
        _pnlDownStairs.Controls.Add(_tbl17);
        _pnlDownStairs.Controls.Add(_tbl16);
        _pnlDownStairs.Controls.Add(_tbl15);
        _pnlDownStairs.Controls.Add(_tbl32);
        _pnlDownStairs.Controls.Add(_tbl22);
        _pnlDownStairs.Controls.Add(_tbl31);
        _pnlDownStairs.Controls.Add(_tbl21);
        _pnlDownStairs.Controls.Add(_tbl14);
        _pnlDownStairs.Controls.Add(_tbl30);
        _pnlDownStairs.Controls.Add(_tbl20);
        _pnlDownStairs.Controls.Add(_tbl13);
        _pnlDownStairs.Controls.Add(_Panel3);
        _pnlDownStairs.Controls.Add(_Panel4);
        _pnlDownStairs.Controls.Add(_tbl12);
        _pnlDownStairs.Controls.Add(_tbl11);
        _pnlDownStairs.Location = new System.Drawing.Point(40, 24);
        _pnlDownStairs.Name = "_pnlDownStairs";
        _pnlDownStairs.Size = new System.Drawing.Size(704, 512);
        _pnlDownStairs.TabIndex = 19;
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
        _Panel5.Location = new System.Drawing.Point(248, 240);
        _Panel5.Name = "_Panel5";
        _Panel5.Size = new System.Drawing.Size(16, 96);
        _Panel5.TabIndex = 33;
        // 
        // Panel6
        // 
        _Panel6.BackColor = System.Drawing.Color.SlateBlue;
        _Panel6.Location = new System.Drawing.Point(264, 240);
        _Panel6.Name = "_Panel6";
        _Panel6.Size = new System.Drawing.Size(304, 16);
        _Panel6.TabIndex = 32;
        // 
        // Panel2
        // 
        _Panel2.BackColor = System.Drawing.Color.SlateBlue;
        _Panel2.Location = new System.Drawing.Point(184, 192);
        _Panel2.Name = "_Panel2";
        _Panel2.Size = new System.Drawing.Size(384, 16);
        _Panel2.TabIndex = 30;
        // 
        // tbl17
        // 
        _tbl17.BackColor = System.Drawing.Color.DarkGray;
        _tbl17.ForeColor = System.Drawing.Color.White;
        _tbl17.Location = new System.Drawing.Point(448, 64);
        _tbl17.Name = "_tbl17";
        _tbl17.Size = new System.Drawing.Size(72, 72);
        _tbl17.TabIndex = 29;
        _tbl17.Text = "17";
        // 
        // tbl16
        // 
        _tbl16.BackColor = System.Drawing.Color.DarkGray;
        _tbl16.ForeColor = System.Drawing.Color.White;
        _tbl16.Location = new System.Drawing.Point(480, 8);
        _tbl16.Name = "_tbl16";
        _tbl16.Size = new System.Drawing.Size(72, 40);
        _tbl16.TabIndex = 28;
        _tbl16.Text = "16";
        // 
        // tbl15
        // 
        _tbl15.BackColor = System.Drawing.Color.DarkGray;
        _tbl15.ForeColor = System.Drawing.Color.White;
        _tbl15.Location = new System.Drawing.Point(400, 8);
        _tbl15.Name = "_tbl15";
        _tbl15.Size = new System.Drawing.Size(72, 40);
        _tbl15.TabIndex = 27;
        _tbl15.Text = "15";
        // 
        // tbl32
        // 
        _tbl32.BackColor = System.Drawing.Color.DarkGray;
        _tbl32.ForeColor = System.Drawing.Color.White;
        _tbl32.Location = new System.Drawing.Point(376, 128);
        _tbl32.Name = "_tbl32";
        _tbl32.Size = new System.Drawing.Size(48, 48);
        _tbl32.TabIndex = 26;
        _tbl32.Text = "32";
        // 
        // tbl22
        // 
        _tbl22.BackColor = System.Drawing.Color.DarkGray;
        _tbl22.ForeColor = System.Drawing.Color.White;
        _tbl22.Location = new System.Drawing.Point(376, 64);
        _tbl22.Name = "_tbl22";
        _tbl22.Size = new System.Drawing.Size(48, 48);
        _tbl22.TabIndex = 25;
        _tbl22.Text = "22";
        // 
        // tbl31
        // 
        _tbl31.BackColor = System.Drawing.Color.DarkGray;
        _tbl31.ForeColor = System.Drawing.Color.White;
        _tbl31.Location = new System.Drawing.Point(304, 128);
        _tbl31.Name = "_tbl31";
        _tbl31.Size = new System.Drawing.Size(48, 48);
        _tbl31.TabIndex = 24;
        _tbl31.Text = "31";
        // 
        // tbl21
        // 
        _tbl21.BackColor = System.Drawing.Color.DarkGray;
        _tbl21.ForeColor = System.Drawing.Color.White;
        _tbl21.Location = new System.Drawing.Point(304, 64);
        _tbl21.Name = "_tbl21";
        _tbl21.Size = new System.Drawing.Size(48, 48);
        _tbl21.TabIndex = 23;
        _tbl21.Text = "21";
        // 
        // tbl14
        // 
        _tbl14.BackColor = System.Drawing.Color.DarkGray;
        _tbl14.ForeColor = System.Drawing.Color.White;
        _tbl14.Location = new System.Drawing.Point(312, 8);
        _tbl14.Name = "_tbl14";
        _tbl14.Size = new System.Drawing.Size(72, 40);
        _tbl14.TabIndex = 22;
        _tbl14.Text = "14";
        // 
        // tbl30
        // 
        _tbl30.BackColor = System.Drawing.Color.DarkGray;
        _tbl30.ForeColor = System.Drawing.Color.White;
        _tbl30.Location = new System.Drawing.Point(224, 128);
        _tbl30.Name = "_tbl30";
        _tbl30.Size = new System.Drawing.Size(56, 48);
        _tbl30.TabIndex = 21;
        _tbl30.Text = "30";
        // 
        // tbl20
        // 
        _tbl20.BackColor = System.Drawing.Color.DarkGray;
        _tbl20.ForeColor = System.Drawing.Color.White;
        _tbl20.Location = new System.Drawing.Point(224, 64);
        _tbl20.Name = "_tbl20";
        _tbl20.Size = new System.Drawing.Size(56, 48);
        _tbl20.TabIndex = 20;
        _tbl20.Text = "20";
        // 
        // tbl13
        // 
        _tbl13.BackColor = System.Drawing.Color.DarkGray;
        _tbl13.ForeColor = System.Drawing.Color.White;
        _tbl13.Location = new System.Drawing.Point(224, 8);
        _tbl13.Name = "_tbl13";
        _tbl13.Size = new System.Drawing.Size(72, 40);
        _tbl13.TabIndex = 19;
        _tbl13.Text = "13";
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
        // tbl12
        // 
        _tbl12.BackColor = System.Drawing.Color.DarkGray;
        _tbl12.ForeColor = System.Drawing.Color.White;
        _tbl12.Location = new System.Drawing.Point(8, 96);
        _tbl12.Name = "_tbl12";
        _tbl12.Size = new System.Drawing.Size(48, 80);
        _tbl12.TabIndex = 15;
        _tbl12.Text = "12";
        // 
        // tbl11
        // 
        _tbl11.BackColor = System.Drawing.Color.DarkGray;
        _tbl11.ForeColor = System.Drawing.Color.White;
        _tbl11.Location = new System.Drawing.Point(8, 8);
        _tbl11.Name = "_tbl11";
        _tbl11.Size = new System.Drawing.Size(48, 72);
        _tbl11.TabIndex = 1;
        _tbl11.Text = "11";
        // 
        // Seating_Dining
        // 
        this.BackColor = System.Drawing.Color.LightSlateGray;
        this.Controls.Add(_pnlDownStairs);
        this.Name = "Seating_Dining";
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
            case 13:
                {
                    tbl13.BackColor = cc;
                    break;
                }
            case 14:
                {
                    tbl14.BackColor = cc;
                    break;
                }
            case 15:
                {
                    tbl15.BackColor = cc;
                    break;
                }
            case 16:
                {
                    tbl16.BackColor = cc;
                    break;
                }
            case 17:
                {
                    tbl17.BackColor = cc;
                    break;
                }
            case 20:
                {
                    tbl20.BackColor = cc;
                    break;
                }
            case 21:
                {
                    tbl21.BackColor = cc;
                    break;
                }
            case 22:
                {
                    tbl22.BackColor = cc;
                    break;
                }
            case 30:
                {
                    tbl30.BackColor = cc;
                    break;
                }
            case 31:
                {
                    tbl31.BackColor = cc;
                    break;
                }
            case 32:
                {
                    tbl32.BackColor = cc;
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