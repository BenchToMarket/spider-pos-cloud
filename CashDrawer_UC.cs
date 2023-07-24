using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using DataSet_Builder;



public partial class CashDrawer_UC : System.Windows.Forms.UserControl
{

    // Dim prt As New PrintHelper

    internal int ThisCashTerminal;
    internal long activeTerminalsOpenID;
    // 0 is for this cash terminal is true
    // anything over that is closing multiple terminals and the number
    // indicates the number of terminals open
    internal string WhatToCashDrawer;

    private CashInfoStructure cashInfo;

    // Dim _openCash As Decimal
    // Dim _closeCash As Decimal

    // Dim _cashIn As Decimal

    // Dim _cashOut As Decimal
    // Dim _overShort As Decimal
    // Dim _reasonShort As String

    // Dim _netSales As Decimal
    // Dim _ccSales As Decimal
    // Dim _cashSales As Decimal
    // Dim _ccTips As Decimal
    // Dim _cashBeforeOut As Decimal


    private Button[] btnOtherTerminals = new Button[21];

    public event TerminalsNowOpenEventHandler TerminalsNowOpen;

    public delegate void TerminalsNowOpenEventHandler(int termOpen);
    public event ResetClosingDataEventHandler ResetClosingData;

    public delegate void ResetClosingDataEventHandler();

    #region  Windows Form Designer generated code 

    public CashDrawer_UC(int _thisCashTerminal) : base()
    {

        ThisCashTerminal = _thisCashTerminal;

        // This call is required by the Windows Form Designer.
        InitializeComponent();
        pnlOtherDrawers.Location = new Point(144, 128);
        pnlOtherDrawers.Size = new Size(208, 296);

        // Add any initialization after the InitializeComponent() call
        InitializeOther();

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
    private Global.System.Windows.Forms.Button _btnOpen;

    internal virtual Global.System.Windows.Forms.Button btnOpen
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnOpen;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnOpen != null)
            {
                _btnOpen.Click -= btnOpen_Click;
            }

            _btnOpen = value;
            if (_btnOpen != null)
            {
                _btnOpen.Click += btnOpen_Click;
            }
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
    private Global.System.Windows.Forms.Button _btnSwitch;

    internal virtual Global.System.Windows.Forms.Button btnSwitch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnSwitch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnSwitch != null)
            {
                _btnSwitch.Click -= btnSwitch_Click;
            }

            _btnSwitch = value;
            if (_btnSwitch != null)
            {
                _btnSwitch.Click += btnSwitch_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnOther;

    internal virtual Global.System.Windows.Forms.Button btnOther
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnOther;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnOther != null)
            {
                _btnOther.Click -= btnOther_Click;
            }

            _btnOther = value;
            if (_btnOther != null)
            {
                _btnOther.Click += btnOther_Click;
            }
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
    private Global.System.Windows.Forms.Label _lblTerminalName;

    internal virtual Global.System.Windows.Forms.Label lblTerminalName
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTerminalName;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblTerminalName = value;
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
    private DataSet_Builder.NumberPadMedium _NumberPadMedium1;

    internal virtual DataSet_Builder.NumberPadMedium NumberPadMedium1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _NumberPadMedium1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_NumberPadMedium1 != null)
            {
                _NumberPadMedium1.NumberEntered -= CashAmountEntered;
            }

            _NumberPadMedium1 = value;
            if (_NumberPadMedium1 != null)
            {
                _NumberPadMedium1.NumberEntered += CashAmountEntered;
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
    private Global.System.Windows.Forms.Label _lblOpenClose;

    internal virtual Global.System.Windows.Forms.Label lblOpenClose
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblOpenClose;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblOpenClose = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblCashInstructions;

    internal virtual Global.System.Windows.Forms.Label lblCashInstructions
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCashInstructions;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblCashInstructions = value;
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
            _Label6 = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblOS;

    internal virtual Global.System.Windows.Forms.Label lblOS
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblOS;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblOS = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblOpenedBy;

    internal virtual Global.System.Windows.Forms.Label lblOpenedBy
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblOpenedBy;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblOpenedBy = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblDateTime;

    internal virtual Global.System.Windows.Forms.Label lblDateTime
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblDateTime;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblDateTime = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblCashAtOpen;

    internal virtual Global.System.Windows.Forms.Label lblCashAtOpen
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCashAtOpen;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblCashAtOpen = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblCashIn;

    internal virtual Global.System.Windows.Forms.Label lblCashIn
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCashIn;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblCashIn = value;
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
    private Global.System.Windows.Forms.Label _lblCashAtClose;

    internal virtual Global.System.Windows.Forms.Label lblCashAtClose
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblCashAtClose;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblCashAtClose = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblOverShort;

    internal virtual Global.System.Windows.Forms.Label lblOverShort
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblOverShort;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblOverShort = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlCloseCash;

    internal virtual Global.System.Windows.Forms.Panel pnlCloseCash
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlCloseCash;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlCloseCash = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlOtherDrawers;

    internal virtual Global.System.Windows.Forms.Panel pnlOtherDrawers
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlOtherDrawers;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlOtherDrawers = value;
        }
    }
    private Global.System.Windows.Forms.Label _Label7;

    internal virtual Global.System.Windows.Forms.Label Label7
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Label7;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Label7 = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblccTips;

    internal virtual Global.System.Windows.Forms.Label lblccTips
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblccTips;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblccTips = value;
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _Panel1 = new System.Windows.Forms.Panel();
        _btnOther = new System.Windows.Forms.Button();
        _btnOther.Click += btnOther_Click;
        _btnSwitch = new System.Windows.Forms.Button();
        _btnSwitch.Click += btnSwitch_Click;
        _btnClose = new System.Windows.Forms.Button();
        _btnClose.Click += btnClose_Click;
        _btnOpen = new System.Windows.Forms.Button();
        _btnOpen.Click += btnOpen_Click;
        _Label1 = new System.Windows.Forms.Label();
        _lblTerminalName = new System.Windows.Forms.Label();
        _btnCancel = new System.Windows.Forms.Button();
        _btnCancel.Click += btnCancel_Click;
        _btnAccept = new System.Windows.Forms.Button();
        _btnAccept.Click += btnAccept_Click;
        _NumberPadMedium1 = new DataSet_Builder.NumberPadMedium();
        _NumberPadMedium1.NumberEntered += CashAmountEntered;
        _Panel2 = new System.Windows.Forms.Panel();
        _lblOpenClose = new System.Windows.Forms.Label();
        _lblCashInstructions = new System.Windows.Forms.Label();
        _pnlCloseCash = new System.Windows.Forms.Panel();
        _lblccTips = new System.Windows.Forms.Label();
        _Label7 = new System.Windows.Forms.Label();
        _lblOverShort = new System.Windows.Forms.Label();
        _lblCashAtClose = new System.Windows.Forms.Label();
        _lblCashOut = new System.Windows.Forms.Label();
        _lblCashIn = new System.Windows.Forms.Label();
        _lblCashAtOpen = new System.Windows.Forms.Label();
        _lblDateTime = new System.Windows.Forms.Label();
        _lblOpenedBy = new System.Windows.Forms.Label();
        _lblOS = new System.Windows.Forms.Label();
        _Label6 = new System.Windows.Forms.Label();
        _Label5 = new System.Windows.Forms.Label();
        _Label4 = new System.Windows.Forms.Label();
        _Label3 = new System.Windows.Forms.Label();
        _Label2 = new System.Windows.Forms.Label();
        _pnlOtherDrawers = new System.Windows.Forms.Panel();
        _Panel1.SuspendLayout();
        _Panel2.SuspendLayout();
        _pnlCloseCash.SuspendLayout();
        this.SuspendLayout();
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.Color.SlateGray;
        _Panel1.Controls.Add(_btnOther);
        _Panel1.Controls.Add(_btnSwitch);
        _Panel1.Controls.Add(_btnClose);
        _Panel1.Controls.Add(_btnOpen);
        _Panel1.Location = new System.Drawing.Point(16, 128);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(104, 320);
        _Panel1.TabIndex = 0;
        // 
        // btnOther
        // 
        _btnOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnOther.Location = new System.Drawing.Point(8, 232);
        _btnOther.Name = "_btnOther";
        _btnOther.Size = new System.Drawing.Size(88, 72);
        _btnOther.TabIndex = 3;
        _btnOther.Text = "Close Other";
        // 
        // btnSwitch
        // 
        _btnSwitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnSwitch.Location = new System.Drawing.Point(8, 160);
        _btnSwitch.Name = "_btnSwitch";
        _btnSwitch.Size = new System.Drawing.Size(88, 64);
        _btnSwitch.TabIndex = 2;
        _btnSwitch.Text = "Close && Reopen";
        // 
        // btnClose
        // 
        _btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnClose.Location = new System.Drawing.Point(8, 88);
        _btnClose.Name = "_btnClose";
        _btnClose.Size = new System.Drawing.Size(88, 64);
        _btnClose.TabIndex = 1;
        _btnClose.Text = "Close";
        // 
        // btnOpen
        // 
        _btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnOpen.Location = new System.Drawing.Point(8, 16);
        _btnOpen.Name = "_btnOpen";
        _btnOpen.Size = new System.Drawing.Size(88, 64);
        _btnOpen.TabIndex = 0;
        _btnOpen.Text = "Open";
        // 
        // Label1
        // 
        _Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label1.ForeColor = System.Drawing.Color.White;
        _Label1.Location = new System.Drawing.Point(104, 24);
        _Label1.Name = "_Label1";
        _Label1.Size = new System.Drawing.Size(128, 40);
        _Label1.TabIndex = 1;
        _Label1.Text = "Cash Drawer:";
        _Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblTerminalName
        // 
        _lblTerminalName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblTerminalName.ForeColor = System.Drawing.Color.White;
        _lblTerminalName.Location = new System.Drawing.Point(240, 24);
        _lblTerminalName.Name = "_lblTerminalName";
        _lblTerminalName.Size = new System.Drawing.Size(160, 40);
        _lblTerminalName.TabIndex = 2;
        _lblTerminalName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // btnCancel
        // 
        _btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnCancel.Location = new System.Drawing.Point(16, 8);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.Size = new System.Drawing.Size(88, 56);
        _btnCancel.TabIndex = 3;
        _btnCancel.Text = "Cancel";
        // 
        // btnAccept
        // 
        _btnAccept.Enabled = false;
        _btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnAccept.Location = new System.Drawing.Point(136, 8);
        _btnAccept.Name = "_btnAccept";
        _btnAccept.Size = new System.Drawing.Size(88, 56);
        _btnAccept.TabIndex = 4;
        _btnAccept.Text = "Accept";
        // 
        // NumberPadMedium1
        // 
        _NumberPadMedium1.BackColor = System.Drawing.Color.SlateGray;
        _NumberPadMedium1.DecimalUsed = false;
        _NumberPadMedium1.IntegerNumber = 0;
        _NumberPadMedium1.Location = new System.Drawing.Point(384, 128);
        _NumberPadMedium1.Name = "_NumberPadMedium1";
        _NumberPadMedium1.NumberString = "";
        _NumberPadMedium1.NumberTotal = new decimal(new int[] { 0, 0, 0, 0 });
        _NumberPadMedium1.Size = new System.Drawing.Size(192, 296);
        _NumberPadMedium1.TabIndex = 5;
        // 
        // Panel2
        // 
        _Panel2.Controls.Add(_btnCancel);
        _Panel2.Controls.Add(_btnAccept);
        _Panel2.Location = new System.Drawing.Point(360, 440);
        _Panel2.Name = "_Panel2";
        _Panel2.Size = new System.Drawing.Size(240, 64);
        _Panel2.TabIndex = 6;
        // 
        // lblOpenClose
        // 
        _lblOpenClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblOpenClose.ForeColor = System.Drawing.Color.White;
        _lblOpenClose.Location = new System.Drawing.Point(24, 24);
        _lblOpenClose.Name = "_lblOpenClose";
        _lblOpenClose.Size = new System.Drawing.Size(72, 40);
        _lblOpenClose.TabIndex = 7;
        _lblOpenClose.Text = "Open";
        _lblOpenClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblCashInstructions
        // 
        _lblCashInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblCashInstructions.ForeColor = System.Drawing.Color.White;
        _lblCashInstructions.Location = new System.Drawing.Point(384, 88);
        _lblCashInstructions.Name = "_lblCashInstructions";
        _lblCashInstructions.Size = new System.Drawing.Size(192, 24);
        _lblCashInstructions.TabIndex = 8;
        _lblCashInstructions.Text = "Enter Open Cash";
        _lblCashInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // pnlCloseCash
        // 
        _pnlCloseCash.BackColor = System.Drawing.Color.LightSlateGray;
        _pnlCloseCash.Controls.Add(_lblccTips);
        _pnlCloseCash.Controls.Add(_Label7);
        _pnlCloseCash.Controls.Add(_lblOverShort);
        _pnlCloseCash.Controls.Add(_lblCashAtClose);
        _pnlCloseCash.Controls.Add(_lblCashOut);
        _pnlCloseCash.Controls.Add(_lblCashIn);
        _pnlCloseCash.Controls.Add(_lblCashAtOpen);
        _pnlCloseCash.Controls.Add(_lblDateTime);
        _pnlCloseCash.Controls.Add(_lblOpenedBy);
        _pnlCloseCash.Controls.Add(_lblOS);
        _pnlCloseCash.Controls.Add(_Label6);
        _pnlCloseCash.Controls.Add(_Label5);
        _pnlCloseCash.Controls.Add(_Label4);
        _pnlCloseCash.Controls.Add(_Label3);
        _pnlCloseCash.Controls.Add(_Label2);
        _pnlCloseCash.Location = new System.Drawing.Point(144, 128);
        _pnlCloseCash.Name = "_pnlCloseCash";
        _pnlCloseCash.Size = new System.Drawing.Size(208, 296);
        _pnlCloseCash.TabIndex = 9;
        _pnlCloseCash.Visible = false;
        // 
        // lblccTips
        // 
        _lblccTips.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblccTips.ForeColor = System.Drawing.Color.White;
        _lblccTips.Location = new System.Drawing.Point(136, 168);
        _lblccTips.Name = "_lblccTips";
        _lblccTips.Size = new System.Drawing.Size(64, 24);
        _lblccTips.TabIndex = 14;
        _lblccTips.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label7
        // 
        _Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label7.ForeColor = System.Drawing.Color.White;
        _Label7.Location = new System.Drawing.Point(16, 168);
        _Label7.Name = "_Label7";
        _Label7.Size = new System.Drawing.Size(104, 24);
        _Label7.TabIndex = 13;
        _Label7.Text = "cc Tips $";
        _Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblOverShort
        // 
        _lblOverShort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblOverShort.ForeColor = System.Drawing.Color.White;
        _lblOverShort.Location = new System.Drawing.Point(136, 248);
        _lblOverShort.Name = "_lblOverShort";
        _lblOverShort.Size = new System.Drawing.Size(64, 24);
        _lblOverShort.TabIndex = 12;
        _lblOverShort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblCashAtClose
        // 
        _lblCashAtClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblCashAtClose.ForeColor = System.Drawing.Color.White;
        _lblCashAtClose.Location = new System.Drawing.Point(136, 200);
        _lblCashAtClose.Name = "_lblCashAtClose";
        _lblCashAtClose.Size = new System.Drawing.Size(64, 24);
        _lblCashAtClose.TabIndex = 11;
        _lblCashAtClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblCashOut
        // 
        _lblCashOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblCashOut.ForeColor = System.Drawing.Color.White;
        _lblCashOut.Location = new System.Drawing.Point(136, 144);
        _lblCashOut.Name = "_lblCashOut";
        _lblCashOut.Size = new System.Drawing.Size(64, 24);
        _lblCashOut.TabIndex = 10;
        _lblCashOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblCashIn
        // 
        _lblCashIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblCashIn.ForeColor = System.Drawing.Color.White;
        _lblCashIn.Location = new System.Drawing.Point(136, 112);
        _lblCashIn.Name = "_lblCashIn";
        _lblCashIn.Size = new System.Drawing.Size(64, 24);
        _lblCashIn.TabIndex = 9;
        _lblCashIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblCashAtOpen
        // 
        _lblCashAtOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblCashAtOpen.ForeColor = System.Drawing.Color.White;
        _lblCashAtOpen.Location = new System.Drawing.Point(136, 80);
        _lblCashAtOpen.Name = "_lblCashAtOpen";
        _lblCashAtOpen.Size = new System.Drawing.Size(64, 24);
        _lblCashAtOpen.TabIndex = 8;
        _lblCashAtOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblDateTime
        // 
        _lblDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblDateTime.ForeColor = System.Drawing.Color.White;
        _lblDateTime.Location = new System.Drawing.Point(48, 48);
        _lblDateTime.Name = "_lblDateTime";
        _lblDateTime.Size = new System.Drawing.Size(144, 24);
        _lblDateTime.TabIndex = 7;
        _lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblOpenedBy
        // 
        _lblOpenedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblOpenedBy.ForeColor = System.Drawing.Color.White;
        _lblOpenedBy.Location = new System.Drawing.Point(104, 16);
        _lblOpenedBy.Name = "_lblOpenedBy";
        _lblOpenedBy.Size = new System.Drawing.Size(88, 32);
        _lblOpenedBy.TabIndex = 6;
        _lblOpenedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblOS
        // 
        _lblOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblOS.ForeColor = System.Drawing.Color.White;
        _lblOS.Location = new System.Drawing.Point(24, 248);
        _lblOS.Name = "_lblOS";
        _lblOS.Size = new System.Drawing.Size(88, 24);
        _lblOS.TabIndex = 5;
        _lblOS.Text = "Short $ ";
        _lblOS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        _lblOS.Visible = false;
        // 
        // Label6
        // 
        _Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label6.ForeColor = System.Drawing.Color.White;
        _Label6.Location = new System.Drawing.Point(16, 200);
        _Label6.Name = "_Label6";
        _Label6.Size = new System.Drawing.Size(104, 24);
        _Label6.TabIndex = 4;
        _Label6.Text = "Cash at Close $ ";
        _Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label5
        // 
        _Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label5.ForeColor = System.Drawing.Color.White;
        _Label5.Location = new System.Drawing.Point(32, 144);
        _Label5.Name = "_Label5";
        _Label5.Size = new System.Drawing.Size(88, 24);
        _Label5.TabIndex = 3;
        _Label5.Text = "Cash Out $ ";
        _Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label4
        // 
        _Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label4.ForeColor = System.Drawing.Color.White;
        _Label4.Location = new System.Drawing.Point(32, 112);
        _Label4.Name = "_Label4";
        _Label4.Size = new System.Drawing.Size(88, 24);
        _Label4.TabIndex = 2;
        _Label4.Text = "Cash In $ ";
        _Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label3
        // 
        _Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label3.ForeColor = System.Drawing.Color.White;
        _Label3.Location = new System.Drawing.Point(16, 80);
        _Label3.Name = "_Label3";
        _Label3.Size = new System.Drawing.Size(104, 24);
        _Label3.TabIndex = 1;
        _Label3.Text = "Cash at Open $ ";
        _Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label2
        // 
        _Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label2.ForeColor = System.Drawing.Color.White;
        _Label2.Location = new System.Drawing.Point(8, 16);
        _Label2.Name = "_Label2";
        _Label2.Size = new System.Drawing.Size(88, 32);
        _Label2.TabIndex = 0;
        _Label2.Text = "Opened By :";
        _Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // pnlOtherDrawers
        // 
        _pnlOtherDrawers.BackColor = System.Drawing.Color.LightSlateGray;
        _pnlOtherDrawers.Location = new System.Drawing.Point(152, 456);
        _pnlOtherDrawers.Name = "_pnlOtherDrawers";
        _pnlOtherDrawers.Size = new System.Drawing.Size(200, 100);
        _pnlOtherDrawers.TabIndex = 10;
        _pnlOtherDrawers.Visible = false;
        // 
        // CashDrawer_UC
        // 
        this.BackColor = System.Drawing.Color.FromArgb(59, 96, 141);
        this.Controls.Add(_pnlOtherDrawers);
        this.Controls.Add(_pnlCloseCash);
        this.Controls.Add(_lblCashInstructions);
        this.Controls.Add(_lblOpenClose);
        this.Controls.Add(_Panel2);
        this.Controls.Add(_NumberPadMedium1);
        this.Controls.Add(_lblTerminalName);
        this.Controls.Add(_Label1);
        this.Controls.Add(_Panel1);
        this.Name = "CashDrawer_UC";
        this.Size = new System.Drawing.Size(608, 512);
        _Panel1.ResumeLayout(false);
        _Panel2.ResumeLayout(false);
        _pnlCloseCash.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion


    private void InitializeOther()
    {

        NumberPadMedium1.DecimalUsed = true;

        if (dtTerminalsMethod.Rows.Count > 1)
        {
            // we have more than 1 terminal
            if (employeeAuthorization.OperationLevel > 1)
            {
                btnOther.Enabled = true;
            }
        }

        if (ThisCashTerminal == 0 | ThisCashTerminal == 1) // 0 Then 
        {
            btnOther.Enabled = false;
            PrepareThisCashTerminal();
        }
        else
        {
            PrepareAnotherCashTerminal();
        }

    }

    private void SwitchToOpenAnotherCashDrawer()
    {
        WhatToCashDrawer = "Open";
        lblOpenClose.Text = WhatToCashDrawer;
        btnOpen.Enabled = true;
        btnClose.Enabled = false;
        btnSwitch.Enabled = false;

        pnlCloseCash.Visible = false;
        pnlOtherDrawers.Visible = false;
        lblCashInstructions.Text = "Enter Open Cash";

        try
        {
            DetermineOpenCashDrawer(currentTerminal.CurrentDailyCode);
            {
                var withBlock = dvTermsOpen;
                withBlock.Table = dtTermsOpen;
                withBlock.RowFilter = "TerminalsPrimaryKey = " + currentTerminal.TermPrimaryKey;
            }
            InitializeOther();
        }
        catch (Exception ex)
        {
            CloseConnection();
        }

    }
    private void PrepareThisCashTerminal()
    {

        // Me.btnOther.Enabled = False
        pnlOtherDrawers.Visible = false;
        lblTerminalName.Text = currentTerminal.TermName;

        if (dvTermsOpen.Count == 0)
        {
            // we are ready to open cash drawer
            btnOpen.Enabled = true;
            btnClose.Enabled = false;
            btnSwitch.Enabled = false;
            WhatToCashDrawer = "Open";
        }

        else if (dvTermsOpen.Count == 1)
        {
            // we are ready to close or switch cash drawer
            btnOpen.Enabled = false;
            btnClose.Enabled = true;
            btnSwitch.Enabled = true;
            WhatToCashDrawer = "Close";

            activeTerminalsOpenID = dvTermsOpen[0]("TerminalsOpenID");

            StartCloseDrawer();
        }

        else if (dvTermsOpen.Count > 1)
        {
            // there is a problem, we should not have more than one drawer open at a time

        }

        lblOpenClose.Text = WhatToCashDrawer;

    }


    private void PrepareAnotherCashTerminal()
    {

        btnOpen.Enabled = false;
        btnClose.Enabled = false;
        btnSwitch.Enabled = false;
        btnOther.Enabled = true;

    }

    private void btnOpen_Click(object sender, EventArgs e)
    {
        WhatToCashDrawer = "Open";
        lblOpenClose.Text = WhatToCashDrawer;

    }

    private void btnClose_Click(object sender, EventArgs e)
    {

        if (!(WhatToCashDrawer == "Close"))
        {
            StartCloseDrawer();
            WhatToCashDrawer = "Close";
            lblOpenClose.Text = WhatToCashDrawer;
        }

    }

    private void btnSwitch_Click(object sender, EventArgs e)
    {
        WhatToCashDrawer = "Switch";
        lblOpenClose.Text = WhatToCashDrawer;

    }

    private void btnOther_Click(object sender, EventArgs e)
    {
        float x = 10f;
        float y = 10f;
        var index = default(int);

        var t = default(int);

        if (employeeAuthorization.OperationLevel > 0 | employeeAuthorization.SystemLevel > 0)
        {
            // allow manager to swith terminals for close out
            pnlOtherDrawers.Visible = true;

            // For t = 1 To 20

            foreach (DataRow oRow in dtTermsOpen.Rows)
            {
                // add button for each terminal name
                btnOtherTerminals[index] = new Button();
                {
                    ref var withBlock = ref btnOtherTerminals[index];
                    withBlock.Location = new Point(x, y);
                    withBlock.BackColor = System.Drawing.Color.FromArgb(59, 96, 141);
                    withBlock.Size = new Size(90, 30);
                    withBlock.ForeColor = c3;

                    if (t == 8)
                    {
                        withBlock.Text = "Last";
                    }
                    else
                    {
                        foreach (DataRow tRow in dtTerminalsMethod.Rows)
                        {
                            if (oRow("TerminalsPrimaryKey") == tRow("TerminalsPrimaryKey"))
                            {
                                withBlock.Text = tRow("TerminalName");
                            }
                        }
                    }

                    this.btnOtherTerminals[index].Click += OtherTerminalsButton_Click;
                    pnlOtherDrawers.Controls.Add(btnOtherTerminals[index]);
                }
                y += 35f;
                index += 1;
                if (index == 8)
                {
                    x = 110f;
                    y = 10f;
                }
                else if (index == 16)
                {
                    return;
                }
            }
        }
        // Next

        else
        {
            Interaction.MsgBox(actingManager.FullName + " is not authorized for Operational changes.");
            return;
        }

    }

    private void OtherTerminalsButton_Click(object sender, EventArgs e)
    {

        foreach (DataRow tRow in dtTerminalsMethod.Rows)
        {
            if (Operators.ConditionalCompareObjectEqual(sender.text, tRow("TerminalName"), false))
            {
                foreach (DataRow oRow in dtTermsOpen.Rows) // dtTerminalsMethod.Rows
                {
                    if (oRow("TerminalsPrimaryKey") == tRow("TerminalsPrimaryKey"))
                    {
                        {
                            var withBlock = dvTermsOpen;
                            withBlock.Table = dtTermsOpen;
                            withBlock.RowFilter = "TerminalsOpenID = " + oRow("TerminalsOpenID");
                        }
                        PrepareThisCashTerminal();
                        break;
                    }
                }

                // 444        With dvTermsOpen
                // .Table = dtTermsOpen
                // .RowFilter = "TerminalsPrimaryKey = " & tRow("TerminalsPrimaryKey")
                // End With
                // 444      PrepareThisCashTerminal()
                break;
            }
        }



    }


    private void CashAmountEntered(object sender, EventArgs e)
    {

        btnAccept.Enabled = true;

        if (WhatToCashDrawer == "Open")
        {
            btnAccept_Click(sender, e);
        }

        else if (WhatToCashDrawer == "Close" | WhatToCashDrawer == "Switch")
        {

            cashInfo._closeCash = NumberPadMedium1.NumberTotal;

            lblCashAtClose.Text = cashInfo._closeCash;
            cashInfo._overShort = Strings.Format(cashInfo._closeCash - (cashInfo._cashBeforeOut + cashInfo._cashOut + cashInfo._openCash), "###,###.00"); // (cashInfo._openCash + cashInfo._cashSales + cashInfo._cashOut)), "###,###.00")
            if (cashInfo._overShort > 0)
            {
                // the drawer is over
                lblOS.Text = "Over $ ";
            }
            else
            {
                lblOS.Text = "Short $ ";
            }
            lblOverShort.Text = cashInfo._overShort;
            lblOS.Visible = true;

        }

    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        var prt = new PrintHelper();

        if (btnAccept.Enabled == true)
        {
            try
            {
                prt.PrintCashSalesDrawer(cashInfo);
            }
            catch (Exception ex)
            {

            }
        }

        this.Dispose();

    }


    private void btnAccept_Click(object sender, EventArgs e)
    {
        if (WhatToCashDrawer == "Open")
        {
            if (NumberPadMedium1.NumberTotal == 0)
            {
                if (Interaction.MsgBox("You are opening the Cash Drawer with $ 0", MsgBoxStyle.OkCancel) == MsgBoxResult.Cancel)
                {
                    return;
                }
                else
                {
                    OpenCashDrawer(NumberPadMedium1.NumberTotal, currentTerminal.TermPrimaryKey);
                    this.Dispose();
                }
            }

            else if (Interaction.MsgBox("OPENING with $ " + NumberPadMedium1.NumberTotal.ToString, MsgBoxStyle.OkCancel) == MsgBoxResult.Cancel)
            {
                return;
            }
            else
            {
                OpenCashDrawer(NumberPadMedium1.NumberTotal, currentTerminal.TermPrimaryKey);
                this.Dispose();
            }
        }

        else if (WhatToCashDrawer == "Close" | WhatToCashDrawer == "Switch")
        {
            if (cashInfo._closeCash == 0)
            {
                CashAmountEntered(null, null);
                // this just ensures that we hit Enter on NumberPad
            }
            if (cashInfo._closeCash == 0)
            {
                if (Interaction.MsgBox("You are closing the Cash Drawer with $ 0", MsgBoxStyle.OkCancel) == MsgBoxResult.Cancel)
                {
                    return;
                }
                else
                {
                    PopulateCloseData();
                }
            }
            else
            {
                PopulateCloseData();
            }

        }
    }

    private void StartCloseDrawer()
    {

        if (typeProgram == "Online_Demo")
        {
            // cashInfo._netsales = "1,000.00"
            // cashInfo._ccSales = "100.00"
            // cashInfo._cashSales = "900.00"
            // cashInfo._ccTips = "50.00"
            cashInfo._openCash = Strings.Format(demoCashOpen, "###,###.00");
        }
        else
        {

        }

        DetermineCashOutDrawer();



        try
        {
            DetermineCashTransactions[activeTerminalsOpenID];
            if (typeProgram == "Online_Demo")
            {
                cashInfo._openCash = Strings.Format(demoCashOpen, "###,###.00");
            }
            else
            {
                cashInfo._openCash = dvTermsOpen[0]("OpenCash");
            }

            // If dsOrder.Tables("CashIn").Rows.Count > 0 Then
            // _cashIn = (dsOrder.Tables("CashIn").Compute("Sum(PaymentAmount)+ Sum(Surcharge)", ""))
            // Else
            // _cashIn = 0
            // End If

            if (dsOrder.Tables("CashOut").Rows.Count > 0)
            {
                cashInfo._cashOut = Strings.Format(dsOrder.Tables("CashOut").Compute("Sum(PaymentAmount) + Sum(Surcharge)", ""), "###,###.00");
            }
            else
            {
                cashInfo._cashOut = 0;
            }

            // cashInfo._cashSales = Format(cashInfo._netsales - cashInfo._ccSales, "###,###.00")
            cashInfo._cashBeforeOut = Strings.Format(cashInfo._cashSales - cashInfo._ccTips, "###,###.00");
            cashInfo._drawerTotal = Strings.Format(cashInfo._cashBeforeOut + cashInfo._cashOut, "###,###.00");


            pnlCloseCash.Visible = true;
            pnlOtherDrawers.Visible = false;
            lblCashInstructions.Text = "Enter Close Cash";
            lblOpenedBy.Text = dvTermsOpen[0]("FirstName") + " " + dvTermsOpen[0]("LastName");
            lblDateTime.Text = dvTermsOpen[0]("OpenTime");
            lblCashAtOpen.Text = cashInfo._openCash;
            lblCashIn.Text = cashInfo._cashSales; // _cashIn
            lblCashOut.Text = cashInfo._cashOut;
            lblccTips.Text = cashInfo._ccTips;
        }

        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);

        }

    }

    internal void DetermineCashOutDrawer()
    {

        if (typeProgram == "Online_Demo")
        {
            cashInfo._netsales = Strings.Format(dsOrderDemo.Tables("PaymentsAndCredits").Compute("Sum(PaymentAmount) + Sum(Surcharge)", "PaymentTypeID > 0"), "###,###.00");

            cashInfo._ccSales = "100.00";
            cashInfo._cashSales = "900.00";
            cashInfo._ccTips = "50.00";
        }




        SqlClient.SqlCommand cmd;

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();

            cmd = new SqlClient.SqlCommand("SELECT PaymentAmount, Surcharge FROM PaymentsAndCredits WHERE (PaymentTypeID > -1 OR PaymentTypeID < -90) AND LocationID = '" + companyInfo.LocationID + "' AND DailyCode = '" + currentTerminal.CurrentDailyCode + "' AND TerminalsOpenID = '" + activeTerminalsOpenID + "'", sql.cn);
            // cmd = New SqlClient.SqlCommand("SELECT PaymentAmount, Surcharge FROM PaymentsAndCredits WHERE LocationID = '" & companyInfo.LocationID & "'", sql.cn)
            cashInfo._netsales = GenerateOrderTables.ReadCashOutData(cmd, "Sales"); // , "###,###.00")

            // 444    cmd = New SqlClient.SqlCommand("SELECT PaymentsAndCredits.PaymentAmount, PaymentsAndCredits.Surcharge, AABPaymentType.PaymentFlag FROM PaymentsAndCredits LEFT OUTER JOIN AABPaymentType ON PaymentsAndCredits.PaymentTypeID = AABPaymentType.PaymentTypeID WHERE AABPaymentType.PaymentFlag = 'cc' AND LocationID = '" & companyInfo.LocationID & "' AND DailyCode = '" & currentTerminal.CurrentDailyCode & "' AND TerminalsOpenID = '" & activeTerminalsOpenID & "'", sql.cn)
            cmd = new SqlClient.SqlCommand("SELECT PaymentAmount, Surcharge FROM PaymentsAndCredits WHERE PaymentTypeID > 1 AND LocationID = '" + companyInfo.LocationID + "' AND DailyCode = '" + currentTerminal.CurrentDailyCode + "' AND TerminalsOpenID = '" + activeTerminalsOpenID + "'", sql.cn);
            cashInfo._ccSales = Strings.Format(GenerateOrderTables.ReadCashOutData(cmd, "Sales"), "###,###.00");

            cmd = new SqlClient.SqlCommand("SELECT PaymentAmount, Surcharge FROM PaymentsAndCredits WHERE PaymentTypeID = 1 AND LocationID = '" + companyInfo.LocationID + "' AND DailyCode = '" + currentTerminal.CurrentDailyCode + "' AND TerminalsOpenID = '" + activeTerminalsOpenID + "'", sql.cn);
            cashInfo._cashSales = Strings.Format(GenerateOrderTables.ReadCashOutData(cmd, "Sales"), "###,###.00");

            // 444   cmd = New SqlClient.SqlCommand("SELECT PaymentsAndCredits.Tip, AABPaymentType.PaymentFlag FROM PaymentsAndCredits LEFT OUTER JOIN AABPaymentType ON PaymentsAndCredits.PaymentTypeID = AABPaymentType.PaymentTypeID WHERE AABPaymentType.PaymentFlag = 'cc' AND LocationID = '" & companyInfo.LocationID & "' AND DailyCode = '" & currentTerminal.CurrentDailyCode & "' AND TerminalsOpenID = '" & activeTerminalsOpenID & "'", sql.cn)
            cmd = new SqlClient.SqlCommand("SELECT Tip FROM PaymentsAndCredits WHERE PaymentTypeID > 1 AND SwipeType > 0 AND LocationID = '" + companyInfo.LocationID + "' AND DailyCode = '" + currentTerminal.CurrentDailyCode + "' AND TerminalsOpenID = '" + activeTerminalsOpenID + "'", sql.cn);
            cashInfo._ccTips = Strings.Format(GenerateOrderTables.ReadCashOutData(cmd, "Tip"), "###,###.00");

            // MsgBox("Net Sales  " & cashInfo._netsales)
            // MsgBox("cc Sales  " & cashInfo._ccSales)
            // MsgBox("cash Sales  " & cashInfo._cashSales)
            // MsgBox("tips  " & cashInfo._ccTips)

            sql.cn.Close();
        }

        catch (Exception ex)
        {

            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }




    }





    private void PopulateCloseData()
    {
        var prt = new PrintHelper();

        if (dvTermsOpen.Count > 0)
        {

            dvTermsOpen[0]("CloseBy") = actingManager.EmployeeID;
            dvTermsOpen[0]("CloseTime") = DateTime.Now;
            dvTermsOpen[0]("CloseCash") = cashInfo._closeCash;
            dvTermsOpen[0]("CashIn") = cashInfo._cashSales;  // _cashIn
            dvTermsOpen[0]("CashOut") = cashInfo._cashOut;
            dvTermsOpen[0]("OverShort") = cashInfo._overShort;
            dvTermsOpen[0]("ReasonShort") = DBNull.Value;

            try
            {
                UpdateTermsOpen();
                dsOrder.Tables("TermsOpen").AcceptChanges();
                prt.PrintCashSalesDrawer(cashInfo);

                if (WhatToCashDrawer == "Switch")
                {
                    SwitchToOpenAnotherCashDrawer();
                }
                else if (ThisCashTerminal > 1)
                {
                    // this means we still have terminals open
                    ThisCashTerminal -= 1;
                    TerminalsNowOpen?.Invoke(ThisCashTerminal);
                    pnlCloseCash.Visible = false;
                    PrepareAnotherCashTerminal();
                }
                else
                {
                    ResetClosingData?.Invoke();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                CloseConnection();
                Interaction.MsgBox(ex.Message);
            }
        }
        else
        {
            ResetClosingData?.Invoke();
            this.Dispose();
        }


    }

}