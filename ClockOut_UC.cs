using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using DataSet_Builder;



public partial class ClockOut_UC : System.Windows.Forms.UserControl
{

    // Dim sql As New DataSet_Builder.SQLHelper(connectserver)
    // Dim prt As New PrintHelper

    // Private _empClockOut As Employee
    private bool _hasOpenTables;

    private decimal totalSales;
    private decimal totalTaxes;
    private decimal grossSales;
    private decimal totalPayments;
    private decimal cashPayments;
    private decimal chargePayments;
    private decimal chargeTips;
    private decimal declaredTips;
    private decimal lessChargeTips;
    private bool adjustingClaimTips;

    private ClockOutInfo clockOutJunk;
    private DataSet_Builder.Payment_UC[] paymentPanel = new DataSet_Builder.Payment_UC[51];
    private int paymentRowIndex;
    private int startPaymentIndex = 1;

    public event ClockOutCompleteEventHandler ClockOutComplete;

    public delegate void ClockOutCompleteEventHandler(); // (ByVal sender As Object, ByVal e As System.EventArgs)
    public event ClockOutCancelEventHandler ClockOutCancel;

    public delegate void ClockOutCancelEventHandler();

    // Friend Property EmpClockOut() As Employee
    // Get
    // Return _empClockOut
    // End Get
    // Set(ByVal Value As Employee)
    // _empClockOut = Value
    // End Set
    // End Property

    #region  Windows Form Designer generated code 

    public ClockOut_UC(ref Employee emp, bool hasOpenTables) : base() // , ByVal tSales As Decimal, ByVal cSales As Decimal, ByVal cTips As Decimal)
    {

        // _tipableSales = tSales
        // _chargedSales = cSales
        // _chargedTips = cTips
        // _empClockOut = emp
        _hasOpenTables = hasOpenTables;

        // This call is required by the Windows Form Designer.
        InitializeComponent();

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
    private Global.System.Windows.Forms.Panel _pnlClockOut;

    internal virtual Global.System.Windows.Forms.Panel pnlClockOut
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlClockOut;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlClockOut = value;
        }
    }
    private DataSet_Builder.NumberPadLarge _NumberPadLarge1;

    internal virtual DataSet_Builder.NumberPadLarge NumberPadLarge1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _NumberPadLarge1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_NumberPadLarge1 != null)
            {
                _NumberPadLarge1.NumberEntered -= TipEnterHit;
            }

            _NumberPadLarge1 = value;
            if (_NumberPadLarge1 != null)
            {
                _NumberPadLarge1.NumberEntered += TipEnterHit;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _pnlClockOutInfo;

    internal virtual Global.System.Windows.Forms.Panel pnlClockOutInfo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlClockOutInfo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlClockOutInfo = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblClockOut;

    internal virtual Global.System.Windows.Forms.Label lblClockOut
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblClockOut;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblClockOut = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnClockOutCancel;

    internal virtual Global.System.Windows.Forms.Button btnClockOutCancel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnClockOutCancel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnClockOutCancel != null)
            {
                _btnClockOutCancel.Click -= btnClockOutCancel_Click;
            }

            _btnClockOutCancel = value;
            if (_btnClockOutCancel != null)
            {
                _btnClockOutCancel.Click += btnClockOutCancel_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _label4;

    internal virtual Global.System.Windows.Forms.Label label4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _label4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_label4 != null)
            {
                _label4.Click -= label4_Click;
            }

            _label4 = value;
            if (_label4 != null)
            {
                _label4.Click += label4_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblClockChargedTips;

    internal virtual Global.System.Windows.Forms.Label lblClockChargedTips
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblClockChargedTips;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblClockChargedTips != null)
            {
                _lblClockChargedTips.Click -= lblClockChargedTips_Click;
            }

            _lblClockChargedTips = value;
            if (_lblClockChargedTips != null)
            {
                _lblClockChargedTips.Click += lblClockChargedTips_Click;
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
    private Global.System.Windows.Forms.Panel _pnlClosePayments;

    internal virtual Global.System.Windows.Forms.Panel pnlClosePayments
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlClosePayments;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pnlClosePayments != null)
            {
                _pnlClosePayments.Click -= PaymentUserControl_Click;
            }

            _pnlClosePayments = value;
            if (_pnlClosePayments != null)
            {
                _pnlClosePayments.Click += PaymentUserControl_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnClockOut;

    internal virtual Global.System.Windows.Forms.Button btnClockOut
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnClockOut;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnClockOut != null)
            {
                _btnClockOut.Click -= btnClockOut_Click;
            }

            _btnClockOut = value;
            if (_btnClockOut != null)
            {
                _btnClockOut.Click += btnClockOut_Click;
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
    private Global.System.Windows.Forms.Label _lblbAddTips;

    internal virtual Global.System.Windows.Forms.Label lblbAddTips
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblbAddTips;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblbAddTips != null)
            {
                _lblbAddTips.Click -= lblbAddTips_Click222;
            }

            _lblbAddTips = value;
            if (_lblbAddTips != null)
            {
                _lblbAddTips.Click += lblbAddTips_Click222;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnPrintOut;

    internal virtual Global.System.Windows.Forms.Button btnPrintOut
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnPrintOut;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnPrintOut != null)
            {
                _btnPrintOut.Click -= btnPrintOut_Click;
            }

            _btnPrintOut = value;
            if (_btnPrintOut != null)
            {
                _btnPrintOut.Click += btnPrintOut_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _Panel12;

    internal virtual Global.System.Windows.Forms.Panel Panel12
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel12;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel12 = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnDailyNextPage;

    internal virtual Global.System.Windows.Forms.Button btnDailyNextPage
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDailyNextPage;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnDailyNextPage != null)
            {
                _btnDailyNextPage.Click -= btnDailyNextPage_Click;
            }

            _btnDailyNextPage = value;
            if (_btnDailyNextPage != null)
            {
                _btnDailyNextPage.Click += btnDailyNextPage_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnDailyPreviousPage;

    internal virtual Global.System.Windows.Forms.Button btnDailyPreviousPage
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDailyPreviousPage;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnDailyPreviousPage != null)
            {
                _btnDailyPreviousPage.Click -= btnDailyPreviousPage_Click;
            }

            _btnDailyPreviousPage = value;
            if (_btnDailyPreviousPage != null)
            {
                _btnDailyPreviousPage.Click += btnDailyPreviousPage_Click;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _pnlClockOut = new System.Windows.Forms.Panel();
        _btnPrintOut = new System.Windows.Forms.Button();
        _btnPrintOut.Click += btnPrintOut_Click;
        _lblbAddTips = new System.Windows.Forms.Label();
        _lblbAddTips.Click += lblbAddTips_Click222;
        _Panel2 = new System.Windows.Forms.Panel();
        _lblClockOut = new System.Windows.Forms.Label();
        _btnClockOutCancel = new System.Windows.Forms.Button();
        _btnClockOutCancel.Click += btnClockOutCancel_Click;
        _pnlClosePayments = new System.Windows.Forms.Panel();
        _pnlClosePayments.Click += PaymentUserControl_Click;
        _NumberPadLarge1 = new DataSet_Builder.NumberPadLarge();
        _NumberPadLarge1.NumberEntered += TipEnterHit;
        _pnlClockOutInfo = new System.Windows.Forms.Panel();
        _label4 = new System.Windows.Forms.Label();
        _label4.Click += label4_Click;
        _lblClockChargedTips = new System.Windows.Forms.Label();
        _lblClockChargedTips.Click += lblClockChargedTips_Click;
        _btnClockOut = new System.Windows.Forms.Button();
        _btnClockOut.Click += btnClockOut_Click;
        _Panel1 = new System.Windows.Forms.Panel();
        _Panel12 = new System.Windows.Forms.Panel();
        _btnDailyNextPage = new System.Windows.Forms.Button();
        _btnDailyNextPage.Click += btnDailyNextPage_Click;
        _btnDailyPreviousPage = new System.Windows.Forms.Button();
        _btnDailyPreviousPage.Click += btnDailyPreviousPage_Click;
        _pnlClockOut.SuspendLayout();
        _Panel2.SuspendLayout();
        _Panel1.SuspendLayout();
        _Panel12.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlClockOut
        // 
        _pnlClockOut.BackColor = System.Drawing.Color.Black;
        _pnlClockOut.Controls.Add(_Panel12);
        _pnlClockOut.Controls.Add(_btnPrintOut);
        _pnlClockOut.Controls.Add(_lblbAddTips);
        _pnlClockOut.Controls.Add(_Panel2);
        _pnlClockOut.Controls.Add(_pnlClosePayments);
        _pnlClockOut.Controls.Add(_NumberPadLarge1);
        _pnlClockOut.Controls.Add(_pnlClockOutInfo);
        _pnlClockOut.Controls.Add(_label4);
        _pnlClockOut.Controls.Add(_lblClockChargedTips);
        _pnlClockOut.Controls.Add(_btnClockOut);
        _pnlClockOut.Location = new System.Drawing.Point(8, 8);
        _pnlClockOut.Name = "_pnlClockOut";
        _pnlClockOut.Size = new System.Drawing.Size(1008, 750);
        _pnlClockOut.TabIndex = 0;
        // 
        // btnPrintOut
        // 
        _btnPrintOut.BackColor = System.Drawing.Color.LightSlateGray;
        _btnPrintOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnPrintOut.Location = new System.Drawing.Point(760, 664);
        _btnPrintOut.Name = "_btnPrintOut";
        _btnPrintOut.Size = new System.Drawing.Size(104, 64);
        _btnPrintOut.TabIndex = 19;
        _btnPrintOut.Text = "Print";
        // 
        // lblbAddTips
        // 
        _lblbAddTips.BackColor = System.Drawing.Color.White;
        _lblbAddTips.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        _lblbAddTips.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblbAddTips.Location = new System.Drawing.Point(752, 96);
        _lblbAddTips.Name = "_lblbAddTips";
        _lblbAddTips.Size = new System.Drawing.Size(112, 32);
        _lblbAddTips.TabIndex = 18;
        _lblbAddTips.Text = "Additional Tips";
        _lblbAddTips.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        _lblbAddTips.Visible = false;
        // 
        // Panel2
        // 
        _Panel2.BackColor = System.Drawing.Color.DodgerBlue;
        _Panel2.Controls.Add(_lblClockOut);
        _Panel2.Controls.Add(_btnClockOutCancel);
        _Panel2.Location = new System.Drawing.Point(0, 0);
        _Panel2.Name = "_Panel2";
        _Panel2.Size = new System.Drawing.Size(1000, 32);
        _Panel2.TabIndex = 17;
        // 
        // lblClockOut
        // 
        _lblClockOut.BackColor = System.Drawing.Color.Transparent;
        _lblClockOut.Font = new System.Drawing.Font("Bookman Old Style", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblClockOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _lblClockOut.Location = new System.Drawing.Point(288, 0);
        _lblClockOut.Name = "_lblClockOut";
        _lblClockOut.Size = new System.Drawing.Size(448, 32);
        _lblClockOut.TabIndex = 0;
        _lblClockOut.Text = "Clock Out: ";
        _lblClockOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btnClockOutCancel
        // 
        _btnClockOutCancel.BackColor = System.Drawing.Color.LightSlateGray;
        _btnClockOutCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnClockOutCancel.Location = new System.Drawing.Point(88, 0);
        _btnClockOutCancel.Name = "_btnClockOutCancel";
        _btnClockOutCancel.Size = new System.Drawing.Size(104, 32);
        _btnClockOutCancel.TabIndex = 1;
        _btnClockOutCancel.Text = "Close";
        // 
        // pnlClosePayments
        // 
        _pnlClosePayments.BackColor = System.Drawing.Color.BlanchedAlmond;
        _pnlClosePayments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        _pnlClosePayments.Location = new System.Drawing.Point(288, 48);
        _pnlClosePayments.Name = "_pnlClosePayments";
        _pnlClosePayments.Size = new System.Drawing.Size(456, 672);
        _pnlClosePayments.TabIndex = 15;
        // 
        // NumberPadLarge1
        // 
        _NumberPadLarge1.BackColor = System.Drawing.Color.SlateGray;
        _NumberPadLarge1.DecimalUsed = true;
        _NumberPadLarge1.ForeColor = System.Drawing.Color.CornflowerBlue;
        _NumberPadLarge1.IntegerNumber = 0;
        _NumberPadLarge1.Location = new System.Drawing.Point(752, 280);
        _NumberPadLarge1.Name = "_NumberPadLarge1";
        _NumberPadLarge1.NumberString = (object)null;
        _NumberPadLarge1.NumberTotal = new decimal(new int[] { 0, 0, 0, 0 });
        _NumberPadLarge1.Size = new System.Drawing.Size(244, 370);
        _NumberPadLarge1.TabIndex = 10;
        // 
        // pnlClockOutInfo
        // 
        _pnlClockOutInfo.BackColor = System.Drawing.Color.CornflowerBlue;
        _pnlClockOutInfo.Location = new System.Drawing.Point(16, 48);
        _pnlClockOutInfo.Name = "_pnlClockOutInfo";
        _pnlClockOutInfo.Size = new System.Drawing.Size(264, 672);
        _pnlClockOutInfo.TabIndex = 9;
        // 
        // label4
        // 
        _label4.BackColor = System.Drawing.Color.White;
        _label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        _label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _label4.Location = new System.Drawing.Point(752, 48);
        _label4.Name = "_label4";
        _label4.Size = new System.Drawing.Size(112, 32);
        _label4.TabIndex = 5;
        _label4.Text = "Declaring Tips:  $";
        _label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblClockChargedTips
        // 
        _lblClockChargedTips.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _lblClockChargedTips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblClockChargedTips.ForeColor = System.Drawing.Color.DodgerBlue;
        _lblClockChargedTips.Location = new System.Drawing.Point(872, 40);
        _lblClockChargedTips.Name = "_lblClockChargedTips";
        _lblClockChargedTips.Size = new System.Drawing.Size(112, 40);
        _lblClockChargedTips.TabIndex = 8;
        _lblClockChargedTips.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // btnClockOut
        // 
        _btnClockOut.BackColor = System.Drawing.Color.LightSlateGray;
        _btnClockOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnClockOut.Location = new System.Drawing.Point(888, 664);
        _btnClockOut.Name = "_btnClockOut";
        _btnClockOut.Size = new System.Drawing.Size(104, 64);
        _btnClockOut.TabIndex = 16;
        _btnClockOut.Text = "Clock Out";
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
        _Panel1.Controls.Add(_pnlClockOut);
        _Panel1.Location = new System.Drawing.Point(0, 0);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(1024, 768);
        _Panel1.TabIndex = 1;
        // 
        // Panel12
        // 
        _Panel12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _Panel12.Controls.Add(_btnDailyNextPage);
        _Panel12.Controls.Add(_btnDailyPreviousPage);
        _Panel12.Location = new System.Drawing.Point(760, 144);
        _Panel12.Name = "_Panel12";
        _Panel12.Size = new System.Drawing.Size(104, 120);
        _Panel12.TabIndex = 20;
        // 
        // btnDailyNextPage
        // 
        _btnDailyNextPage.BackColor = System.Drawing.Color.BlanchedAlmond;
        _btnDailyNextPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnDailyNextPage.Location = new System.Drawing.Point(8, 64);
        _btnDailyNextPage.Name = "_btnDailyNextPage";
        _btnDailyNextPage.Size = new System.Drawing.Size(88, 48);
        _btnDailyNextPage.TabIndex = 1;
        _btnDailyNextPage.Text = "Next Page";
        // 
        // btnDailyPreviousPage
        // 
        _btnDailyPreviousPage.BackColor = System.Drawing.Color.BlanchedAlmond;
        _btnDailyPreviousPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnDailyPreviousPage.Location = new System.Drawing.Point(8, 8);
        _btnDailyPreviousPage.Name = "_btnDailyPreviousPage";
        _btnDailyPreviousPage.Size = new System.Drawing.Size(88, 48);
        _btnDailyPreviousPage.TabIndex = 0;
        _btnDailyPreviousPage.Text = "Previous Page";
        // 
        // ClockOut_UC
        // 
        this.Controls.Add(_Panel1);
        this.Name = "ClockOut_UC";
        this.Size = new System.Drawing.Size(1024, 768);
        _pnlClockOut.ResumeLayout(false);
        _Panel2.ResumeLayout(false);
        _Panel1.ResumeLayout(false);
        _Panel12.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private void InitializeOther()
    {


        // Me.lblClockTipableSales.Text = "$  " & Me.TipableSales
        // Me.lblClockChargeSales.Text = "$  " & Me.ChargedSales
        // Me.lblClockChargedTips.Text = "$  " & Me.ChargedTips

        if (_hasOpenTables == true)
        {
            btnClockOut.Text = "You still have open Tickets";
            // 444        btnClockOut.Enabled = False
        }

        lblClockOut.Text = "Clock Out:  " + currentClockEmp.FullName;


        if (currentServer.LoginTrackingID == 0)
        {
            // this is when bartenders are clocking out on someone else's login
            int isCLockedin;
            try
            {
                isCLockedin = ActuallyLogIn(currentClockEmp);
            }
            catch (Exception ex)
            {
                CloseConnection();
            }

        }


        PopulatePaymentsAndCreditsWhenClosing();
        DetermineSalesAndPayments();
        DisplaySalesAndPayments();
        FilterPreAuthDataview();
        DisplayPreAuthPaymentPanels();


    }

    private void DetermineSalesAndPayments()
    {
        // determine all experiences for this employee on this day (or for current batch)

        dsOrder.Tables("OpenOrders").Clear();

        // not sure if we need the following 3
        // ClearClosedTabsAndTables()
        dsEmployee.Tables("ClockOutSales").Clear();
        dsEmployee.Tables("ClockOutTaxes").Clear();
        dsEmployee.Tables("ClockOutPayments").Clear();

        if (typeProgram == "Online_Demo")
        {
            Interaction.MsgBox("Demo will not display Zero's for Sales and Payment data.");
            return;
        }

        string strClockOutSales;
        string strClockOutTaxes;
        string strClockOutPayments;
        bool firstTime = true;
        string tableCreating;
        DataRowView vRow;

        try
        {

            sql.SqlSelectCommandEmpClockOutSales.Parameters("@LoginID").Value = currentClockEmp.LoginTrackingID;
            sql.SqlSelectCommandEmpClockOutSales.Parameters("@DailyCode").Value = currentTerminal.CurrentDailyCode;
            sql.SqlSelectCommandEmpClockOutTaxes.Parameters("@LoginID").Value = currentClockEmp.LoginTrackingID;
            sql.SqlSelectCommandEmpClockOutTaxes.Parameters("@DailyCode").Value = currentTerminal.CurrentDailyCode;
            sql.SqlSelectCommandEmpClockOutPayments.Parameters("@LoginID").Value = currentClockEmp.LoginTrackingID;
            sql.SqlSelectCommandEmpClockOutPayments.Parameters("@DailyCode").Value = currentTerminal.CurrentDailyCode;

            // **********
            // can we combine all these together
            // this might save time???
            // also FFID < 1 not 0
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();

            sql.SqlEmpClockOutSales.Fill(dsEmployee.Tables("ClockOutSales"));
            sql.SqlEmpClockOutTaxes.Fill(dsEmployee.Tables("ClockOutTaxes"));
            sql.SqlEmpClockOutPayments.Fill(dsEmployee.Tables("ClockOutPayments"));
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }

    }

    private void DisplaySalesAndPayments()
    {
        DataRow oRow;
        float x = buttonSpace;
        var y = default(float);
        string aTaxName;

        pnlClockOutInfo.Controls.Clear();
        totalSales = 0m;
        totalTaxes = 0m;
        grossSales = 0m;
        totalPayments = 0m;
        cashPayments = 0m;
        chargePayments = 0m;
        chargeTips = 0m;
        lessChargeTips = 0m;

        DisplaySalesAndPaymentTitle("*** SALES ***", y);

        y += 20f;

        foreach (DataRow currentORow in dsEmployee.Tables("ClockOutSales").Rows)
        {
            oRow = currentORow;
            if (oRow("FunctionGroupSales") != 0)
            {
                DisplayNewSalesAndPaymentLabel(oRow("FunctionName"), oRow("FunctionGroupSales"), y);
                totalSales += oRow("FunctionGroupSales");
                y += 20f;
            }
        }

        DisplayNewSalesAndPaymentLabel("Total:", totalSales, y);
        y += 30f;

        DisplaySalesAndPaymentTitle("*** TAXES ***", y);
        y += 20f;

        foreach (DataRow currentORow1 in dsEmployee.Tables("ClockOutTaxes").Rows)
        {
            oRow = currentORow1;
            if (oRow("GroupTaxes") != 0)
            {
                // MsgBox(oRow("TaxID"))
                aTaxName = DetermineTaxName(oRow("TaxID"));
                DisplayNewSalesAndPaymentLabel(aTaxName, oRow("GroupTaxes"), y);
                totalTaxes += oRow("GroupTaxes");
                y += 20f;
            }
        }
        grossSales = totalSales + totalTaxes;

        DisplayNewSalesAndPaymentLabel("Total:", totalTaxes, y);
        y += 30f;
        DisplayNewSalesAndPaymentLabel("Gross Sales", grossSales, y);
        y += 30f;


        DisplaySalesAndPaymentTitle("*** PAYMENTS ***", y);
        y += 20f;

        foreach (DataRow currentORow2 in dsEmployee.Tables("ClockOutPayments").Rows)
        {
            oRow = currentORow2;
            if (oRow("GroupPayments") != 0)
            {
                DisplayNewSalesAndPaymentLabel(oRow("PaymentTypeName"), oRow("GroupPayments"), y);
                totalPayments += oRow("GroupPayments");
                if (oRow("PaymentFlag") == "Cash")
                {
                    cashPayments += oRow("GroupPayments");
                }
                else if (oRow("PaymentFlag") == "cc")
                {
                    chargePayments += oRow("GroupPayments");
                    chargeTips += oRow("GroupTips");
                }
                y += 20f;
            }
        }

        DisplayNewSalesAndPaymentLabel("Total Payments", totalPayments, y);

        if (chargeTips > declaredTips)
        {
            declaredTips = chargeTips;
        }
        lblClockChargedTips.Text = Strings.Format(declaredTips, "###,##0.00");
        lessChargeTips = -1 * chargeTips;

        y += 30f;

        DisplaySalesAndPaymentTitle("*** CASH OWED ***", y);
        y += 20f;
        DisplayNewSalesAndPaymentLabel("Cash Payments", cashPayments, y);
        y += 20f;
        DisplayNewSalesAndPaymentLabel("CC Tips", lessChargeTips, y);
        y += 20f;
        DisplayNewSalesAndPaymentLabel("TOTAL CASH OWED", cashPayments + lessChargeTips, y);
        y += 20f;

        // PrepareClockOutPrint()

    }

    private void FilterPreAuthDataview()
    {
        dvClosedPreAuth = new DataView();

        {
            var withBlock = dvClosedPreAuth;
            withBlock.Table = dsOrder.Tables("PaymentsAndCredits");
            // 444  .RowFilter = "PaymentFlag = 'cc' AND BatchCleared = 'False'"     ' "TransactionCode = 'PreAuth' AND PaymentTypeID > 1"
            // .RowFilter = "PaymentFlag = 'cc' AND BatchCleared = 'False' AND TransactionCode = 'PreAuth' AND PaymentTypeID > 1"
            withBlock.RowFilter = "BatchCleared = 'False' AND PaymentTypeID > 1";
            // currently will not pull GIFT
            // .Sort = "TransactionCode, AuthCode ASC"
            // sort will put all the PreAuthCatures on the bottom
        }

        if (dvClosedPreAuth.Count > 50)
        {
            paymentPanel = new DataSet_Builder.Payment_UC[dvClosedPreAuth.Count + 1];
        }

    }

    private void btnDailyPreviousPage_Click(object sender, EventArgs e)
    {
        if (startPaymentIndex <= 1)
            return;
        startPaymentIndex -= 9;
        DisplayPreAuthPaymentPanels();

    }

    private void btnDailyNextPage_Click(object sender, EventArgs e)
    {
        if (startPaymentIndex >= dvClosedPreAuth.Count)
            return;
        startPaymentIndex += 9;
        DisplayPreAuthPaymentPanels();

    }
    private void DisplayPreAuthPaymentPanels()
    {
        DataRowView vRow;
        var count = default(int);
        var position = default(int);

        pnlClosePayments.Controls.Clear();


        foreach (DataRowView currentVRow in dvClosedPreAuth)
        {
            vRow = currentVRow;    // dsOrder.Tables("PaymentsAndCredits").Rows
            // If oRow("TransactionCode") = "PreAuth" Then
            count += 1;
            if (count >= startPaymentIndex)  // (***removed temp*****)And count <= (startPaymentIndex + 9) Then
            {
                CreateNewPaymentPanel(ref vRow, count, position);
                position += 1;
            }

            // End If
        }

        if (dvClosedPreAuth.Count > 0)
        {
            paymentRowIndex = 1;
            ActiveThisPanel(paymentRowIndex);
        }

        foreach (DataRowView currentVRow1 in dvClosedPreAuth)

            vRow = currentVRow1;

    }

    private void CreateNewPaymentPanel(ref DataRowView vRow, int PnlNo, int position)
    {

        var truncAcctNum = default(string);

        if (!object.ReferenceEquals(vRow("AccountNumber"), DBNull.Value))
        {
            if (!object.ReferenceEquals(vRow("AuthCode"), DBNull.Value))
            {
                // already authorized
                if (!(vRow("AccountNumber").Substring(0, 4) == "xxxx") & !(vRow("AccountNumber") == "Manual"))
                {
                    truncAcctNum = TruncateAccountNumber(vRow("AccountNumber"));
                }
                else
                {
                    truncAcctNum = vRow("AccountNumber");
                }
            }
            else
            {
                truncAcctNum = vRow("AccountNumber");
            }
        }

        paymentPanel[PnlNo] = new DataSet_Builder.Payment_UC("ClockOut", vRow, (object)null, PnlNo, (object)null, truncAcctNum, 0);

        {
            ref var withBlock = ref paymentPanel[PnlNo];

            withBlock.Location = new Point(0, withBlock.Height * position);
            withBlock.BackColor = Color.DarkGray;
            withBlock.ReverseAlignment();
            this.paymentPanel[PnlNo].ActivePanel += PaymentUserControl_Click;
            pnlClosePayments.Controls.Add(paymentPanel[PnlNo]);
        }

    }

    private void PaymentUserControl_Click(object sender, EventArgs e)
    {

        DataSet_Builder.Payment_UC objButton;

        try
        {
            objButton = (DataSet_Builder.Payment_UC)sender;
        }
        catch (Exception ex)
        {
            return;
        }

        // If objButton.CurrentState = DataSet_Builder.Payment_UC.PanelHit.TipPanel Then
        // Me.NumberPadLarge1.DecimalUsed = True
        // NumberPadLarge1.NumberString = objButton.TipAmount
        // NumberPadLarge1.ShowNumberString()
        // NumberPadLarge1.NumberString = ""
        // End If

        if (!(paymentRowIndex == objButton.ActiveIndex))
        {
            paymentRowIndex = objButton.ActiveIndex;
            ActiveThisPanel(objButton.ActiveIndex);
        }
    }

    private void ActiveThisPanel(int ai)
    {
        int index = 1;

        // MsgBox(dvClosedPreAuth.Count)
        // If dvClosedPreAuth.Count > 20 Then ReDim paymentPanel(dvClosedPreAuth.Count)

        foreach (DataRowView oRow in dvClosedPreAuth)   // dsOrder.Tables("PaymentsAndCredits").Rows
        {
            // If Not oRow.RowState = DataRowState.Deleted Then
            if (index >= startPaymentIndex)
            {
                if (!(index == ai))
                {
                    paymentPanel[index].BackColor = Color.DarkGray;
                    paymentPanel[index].IsActive = false;
                }
                else
                {
                    paymentPanel[index].BackColor = Color.WhiteSmoke;
                    paymentPanel[paymentRowIndex].CurrentState = DataSet_Builder.Payment_UC.PanelHit.TipPanel;
                    PaymentPanelActivated();
                }
            }
            index += 1;
            // End If
        }

    }

    private void PaymentPanelActivated()
    {

        // If paymentPanel(paymentRowIndex).CurrentState = DataSet_Builder.Payment_UC.PanelHit.TipPanel Then
        NumberPadLarge1.DecimalUsed = true;
        NumberPadLarge1.NumberTotal = paymentPanel[paymentRowIndex].TipAmount;
        NumberPadLarge1.ShowNumberString();
        NumberPadLarge1.Focus();
        NumberPadLarge1.IntegerNumber = 0;
        NumberPadLarge1.NumberString = (object)null;
        // End If

    }







    private void DisplayNewSalesAndPaymentLabel(string catName, decimal catAmount, float y)
    {
        string isPositive;
        float spWidth;
        float spHeight = 50f;
        float x = buttonSpace;

        if (catAmount < 0m)
        {
            isPositive = "(-)";
        }
        else
        {
            isPositive = "(+)";
        }
        spWidth = pnlClockOutInfo.Width - 100;

        Label lblTitle;
        Label lblAmount;

        lblTitle = new Label();
        lblTitle.Text = catName;
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblTitle.Location = new Point(x, y);

        lblTitle.Size = new Size(spWidth, 30);
        x = x + spWidth;
        spWidth = 80f;

        lblAmount = new Label();
        lblAmount.Text = Strings.Format(catAmount, "###,##0.00") + isPositive;
        lblAmount.TextAlign = ContentAlignment.MiddleRight;
        lblAmount.Location = new Point(x, y);

        lblAmount.Size = new Size(spWidth, 30);

        pnlClockOutInfo.Controls.Add(lblTitle);
        pnlClockOutInfo.Controls.Add(lblAmount);

    }

    private void DisplaySalesAndPaymentTitle(string catTitle, float y)
    {
        Label lblTitle;
        float x = buttonSpace;

        lblTitle = new Label();
        lblTitle.Text = catTitle;
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        lblTitle.Location = new Point(x, y);

        lblTitle.Size = new Size(pnlClockOutInfo.Width, 30);
        pnlClockOutInfo.Controls.Add(lblTitle);

    }

    private void TipEnterHit(object sender, EventArgs e)
    {

        if (adjustingClaimTips == true)
        {
            if (chargeTips > declaredTips)
            {
                if (Interaction.MsgBox("Declared Tips should be more than Charged Tips. Please Verify", MsgBoxStyle.OkCancel) == MsgBoxResult.Cancel)
                {
                    return;
                }
            }
            adjustingClaimTips = false;
            declaredTips = NumberPadLarge1.NumberTotal;
            lblClockChargedTips.Text = Strings.Format(declaredTips, "###,##0.00");
            return;
        }

        if (NumberPadLarge1.NumberTotal > dvClosedPreAuth[paymentRowIndex - 1]("PaymentAmount"))
        {
            if (Interaction.MsgBox("Gratuity Amount is greater than Purchase. Please Verify", MsgBoxStyle.OkCancel) == MsgBoxResult.Cancel)
            {
                return;
            }
        }

        chargeTips -= paymentPanel[paymentRowIndex].TipAmount;
        chargeTips += NumberPadLarge1.NumberTotal;
        if (chargeTips > declaredTips)
        {
            declaredTips = chargeTips;
        }

        dvClosedPreAuth[paymentRowIndex - 1]("Tip") = NumberPadLarge1.NumberTotal;
        dvClosedPreAuth[paymentRowIndex - 1]("TransactionCode") = "PreAuthCapture";
        paymentPanel[paymentRowIndex].UpdateTip(NumberPadLarge1.NumberTotal);

        lblClockChargedTips.Text = Strings.Format(declaredTips, "###,##0.00");

        if (paymentRowIndex < dvClosedPreAuth.Count)
        {
            paymentRowIndex += 1;
            ActiveThisPanel(paymentRowIndex);
        }

    }

    private void btnClockOut_Click(object sender, EventArgs e)
    {

        EitherPrintOrClockOut(true);

        // If NumberPadLarge1.NumberTotal = Nothing Then
        // declaredTips = Format(0.0, "#0.00")
        // Else
        // declaredTips = Format(NumberPadLarge1.NumberTotal, "####0.00")
        // '   End If
        // declaredTips.Round(NumberPadLarge1.NumberTotal, 2)

        // For Each oRow In dsEmployee.Tables("LoggedInEmployees").Rows
        // If oRow("EmployeeID") = currentServer.EmployeeID Then
        // clockOutJunk.TimeIn = oRow("LogInTime")
        // oRow("LogOutTime") = clockOutJunk.TimeOut
        // oRow("TipableSales") = totalSales
        // oRow("DeclaredTips") = chargeTips + declaredTips
        // oRow("ChargedSales") = chargePayments
        // oRow("ChargedTips") = chargeTips
        // Exit For
        // End If
        // Next

    }

    private void btnPrintOut_Click(object sender, EventArgs e)
    {
        EitherPrintOrClockOut(false);

    }

    internal void EitherPrintOrClockOut(bool isFullClockout)
    {
        int shiftMins;
        // need to run auth and save tips input
        int amountZeroTips;
        amountZeroTips = Conversions.ToInteger(CountZeroTips());

        if (typeProgram == "Online_Demo")
        {
            foreach (DataRow oRow in dsEmployee.Tables("LoggedInEmployees").Rows)
            {
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (currentClockEmp.EmployeeID == oRow("EmployeeID"))
                    {
                        oRow.Delete();
                        ClockOutComplete?.Invoke();
                        this.Dispose();
                        return;
                    }
                }
            }
            ClockOutComplete?.Invoke();
            this.Dispose();
            return;
        }

        if (amountZeroTips == -99)
        {
            // this means we have non-auth credit cards
            return;
        }

        if (isFullClockout == true)
        {
            if (amountZeroTips > 0)
            {
                if (amountZeroTips == 1)
                {
                    if (Interaction.MsgBox("There is " + amountZeroTips + " Gratuity of $0.00 which was not physically entered. Do you wish to continue?", MsgBoxStyle.OkCancel) == MsgBoxResult.Cancel)
                    {
                        return;
                    }
                }
                else if (Interaction.MsgBox("There are " + amountZeroTips + " Gratuities of $0.00 which were not physically entered. Do you wish to continue?", MsgBoxStyle.OkCancel) == MsgBoxResult.Cancel)
                {
                    return;
                }
                // not sure if we want this here or a second catch 
                // we we close daily
                // Dim vRow As DataRowView
                // For Each vRow In dvClosedPreAuth
                // If vRow("TransactionCode") = "PreAuth" Then
                // '      vRow("TransactionCode") = "PreAuthCapture"
                // End If
                // Next
            }
        }

        UpdatePaymentsAndCreditsByEmployee();
        DetermineSalesAndPayments();
        DisplaySalesAndPayments();

        // 444        For Each oRow In dsEmployee.Tables("LoggedInEmployees").Rows
        // If oRow("EmployeeID") = currentClockEmp.EmployeeID Then
        // clockOutJunk.TimeIn = oRow("LogInTime")
        // End If
        // Next
        clockOutJunk.TimeIn = currentClockEmp.LogInTime;

        clockOutJunk.TimeOut = DateTime.Now.AddSeconds(-1 * DateTime.Now.Second);
        clockOutJunk.TipableSales = totalSales;
        clockOutJunk.DeclaredTips = declaredTips;
        clockOutJunk.ChargedSales = chargePayments;
        clockOutJunk.ChargedTips = chargeTips;


        if (isFullClockout == true)
        {
            UpdateEmployeeToLoginDatabase(currentClockEmp, clockOutJunk);
        }

        if (!(typeProgram == "Online_Demo"))
        {
            PrepareClockOutPrint();
        }

        if (isFullClockout == true)
        {
            // currentServer = New Employee
            ClockOutComplete?.Invoke();
            this.Dispose();
        }

    }

    private object CountZeroTips()
    {

        var zeroTips = default(int);
        DataRow orow;
        // Dim count As Integer

        foreach (DataRowView vRow in dvClosedPreAuth)
        {
            if (!object.ReferenceEquals(vRow("TransactionCode"), DBNull.Value))
            {
                if (vRow("TransactionCode") == "PreAuth" & vRow("Tip") == 0)
                {
                    zeroTips += 1;
                }
            }
            else
            {
                // MsgBox("You have at least 1 Credit Card (" & vRow("AccountNumber") & ") not processed. Please process or delete beofer clocking out.")
                foreach (DataRow currentOrow in dsOrder.Tables("AvailTables").Rows)
                {
                    orow = currentOrow;
                    if (orow("ExperienceNumber") == vRow("ExperienceNumber"))
                    {
                        Interaction.MsgBox("You have at least 1 Credit Card (Table: " + orow("TabName") + ") not processed. Please process or delete beofer clocking out.");
                        return -99;
                    }
                }
                foreach (DataRow currentOrow1 in dsOrder.Tables("AvailTabs").Rows)
                {
                    orow = currentOrow1;
                    if (orow("ExperienceNumber") == vRow("ExperienceNumber"))
                    {
                        Interaction.MsgBox("You have at least 1 Credit Card (Tab: " + orow("TabName") + ") not processed. Please process or delete beofer clocking out.");
                        return -99;
                    }
                }
                // Return -99
            }

        }

        return zeroTips;

    }

    private void btnClockOutCancel_Click(object sender, EventArgs e)
    {

        Interaction.MsgBox("You will NOT be Clocked Out.");


        GenerateOrderTables.UpdatePaymentsAndCreditsByEmployee();
        ClockOutCancel?.Invoke();
        this.Dispose();

    }


    private void PrepareClockOutPrint()
    {
        DataRow oRow;
        TimeSpan numberOfHoursWeek;
        int numberOfMinWeek;
        int numberOfMinShift;

        DateTime begDateOfWeek;
        begDateOfWeek = DetermineFirstDateOfWeek(0);
        DateTime endDateOfWeek;
        endDateOfWeek = begDateOfWeek.AddDays(7d);
        var prt = new PrintHelper();

        // numberOfHoursWeek = DetermineHoursWorked(currentServer.EmployeeID, begDateOfWeek)
        numberOfMinWeek = DetermineHoursWorked(currentClockEmp.EmployeeID, begDateOfWeek, endDateOfWeek);

        numberOfMinShift = (int)DateDiff(DateInterval.Minute, currentClockEmp.LogInTime, clockOutJunk.TimeOut);
        clockOutJunk.ShiftHours = DetermineHours(numberOfMinShift);
        clockOutJunk.ShiftMins = DetermineRemainingMin(numberOfMinShift, clockOutJunk.ShiftHours);

        clockOutJunk.WeekHours = DetermineHours(numberOfMinWeek);
        clockOutJunk.WeekMins = DetermineRemainingMin(numberOfMinWeek, clockOutJunk.WeekHours);

        prt.ClockOutJunk = clockOutJunk;
        prt.StartClockOutPrint();


    }


    private void PrepareClockOutReport222()
    {
        DataRow oRow;
        TimeSpan numberOfHoursWeek;
        int numberOfMinWeek;
        int numberOfMinShift;

        DateTime begDateOfWeek;
        begDateOfWeek = DetermineFirstDateOfWeek(1); // # is how many weeks ago
        DateTime endDateOfWeek;
        endDateOfWeek = begDateOfWeek.AddDays(7d);
        var prt = new PrintHelper();

        // numberOfHoursWeek = DetermineHoursWorked(currentServer.EmployeeID, begDateOfWeek)
        numberOfMinWeek = DetermineHoursWorked(currentClockEmp.EmployeeID, begDateOfWeek, endDateOfWeek);

        numberOfMinShift = (int)DateDiff(DateInterval.Minute, currentClockEmp.LogInTime, clockOutJunk.TimeOut);
        clockOutJunk.ShiftHours = DetermineHours(numberOfMinShift);
        clockOutJunk.ShiftMins = DetermineRemainingMin(numberOfMinShift, clockOutJunk.ShiftHours);

        clockOutJunk.WeekHours = DetermineHours(numberOfMinWeek);
        clockOutJunk.WeekMins = DetermineRemainingMin(numberOfMinWeek, clockOutJunk.WeekHours);

        prt.ClockOutJunk = clockOutJunk;
        prt.StartClockOutPrint();


    }


    private int DetermineHours(float numberOfMinWeek)
    {
        int hrs;

        hrs = (int)Math.Round(Conversion.Int(numberOfMinWeek / 60f));

        return hrs;

    }

    private float DetermineRemainingMin(float numberOfMinWeek, float intHours)
    {
        int min;

        min = (int)Math.Round(Conversion.Int(numberOfMinWeek - intHours * 60f));
        return min;

    }

    private DateTime DetermineFirstDateOfWeek(int numWeeksAgo)
    {

        DateTime begDateOfWeek;
        int numOfDaysThisWeek;
        // numWeeksAgo -= 1

        if (companyInfo.begOfWeek > DateTime.Now.DayOfWeek)
        {
            numOfDaysThisWeek = 7 - (companyInfo.begOfWeek - DateTime.Now.DayOfWeek);
        }
        else
        {
            numOfDaysThisWeek = DateTime.Now.DayOfWeek - companyInfo.begOfWeek;
        }

        begDateOfWeek = DateTime.Now.AddDays(-1 * numOfDaysThisWeek);
        begDateOfWeek = begDateOfWeek.AddDays(-7 * numWeeksAgo);

        return Conversions.ToDate(begDateOfWeek.ToShortDateString());

    }




    private void lblClockChargedTips_Click(object sender, EventArgs e)
    {
        AdjustDeclaredTips();

    }


    private void label4_Click(object sender, EventArgs e)
    {
        AdjustDeclaredTips();
    }

    private void AdjustDeclaredTips()
    {
        adjustingClaimTips = true;
        NumberPadLarge1.DecimalUsed = true;
        NumberPadLarge1.NumberTotal = declaredTips;
        NumberPadLarge1.ShowNumberString();

        NumberPadLarge1.Focus();
        NumberPadLarge1.IntegerNumber = 0;
        NumberPadLarge1.NumberString = "";

    }

    private void lblbAddTips_Click222(object sender, EventArgs e)
    {

        // currently not using
        // we just adjust tips to whatever we want
        // this does not change charged tips, they are always calculated

        adjustingClaimTips = false;
        NumberPadLarge1.DecimalUsed = true;
        NumberPadLarge1.NumberTotal = declaredTips;
        NumberPadLarge1.ShowNumberString();

        NumberPadLarge1.Focus();
        NumberPadLarge1.IntegerNumber = 0;
        NumberPadLarge1.NumberString = "";



    }




}