using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic; // Install-Package Microsoft.VisualBasic
public partial class Comp_Ticket_UC : System.Windows.Forms.UserControl
{

    private decimal _checkFood;
    private decimal _checkDrinks;
    private decimal _checkTicket;
    private decimal _checkTax;
    private decimal _checkSinTax;
    private decimal _manualTicket;
    private decimal _manualTax;
    private bool compTax;
    private bool onManualTicket;
    private decimal _totalTicket;

    internal bool AllFood;
    internal bool AllDrinks;
    internal decimal AdjPrice;
    internal decimal AdjTax;
    internal decimal AdjSinTax;



    internal decimal CheckFood
    {
        get
        {
            return _checkFood;
        }
        set
        {
            _checkFood = value;
        }
    }

    internal decimal CheckDrinks
    {
        get
        {
            return _checkDrinks;
        }
        set
        {
            _checkDrinks = value;
        }
    }

    internal decimal CheckTicket
    {
        get
        {
            return _checkTicket;
        }
        set
        {
            _checkTicket = value;
        }
    }

    internal decimal CheckTax
    {
        get
        {
            return _checkTax;
        }
        set
        {
            _checkTax = value;
        }
    }

    internal decimal CheckSinTax
    {
        get
        {
            return _checkSinTax;
        }
        set
        {
            _checkSinTax = value;
        }
    }

    internal decimal ManualTicket
    {
        get
        {
            return _manualTicket;
        }
        set
        {
            _manualTicket = value;
        }
    }

    internal decimal ManualTax
    {
        get
        {
            return _manualTax;
        }
        set
        {
            _manualTax = value;
        }
    }

    public event DisposeCompTicketEventHandler DisposeCompTicket;

    public delegate void DisposeCompTicketEventHandler();
    public event AcceptCompTicketEventHandler AcceptCompTicket;

    public delegate void AcceptCompTicketEventHandler();

    #region  Windows Form Designer generated code 

    public Comp_Ticket_UC(decimal cf, decimal cd, decimal tkt, decimal tax, decimal SinTax) : base()
    {

        _checkFood = cf;
        _checkDrinks = cd;
        _checkTicket = tkt;
        _checkTax = tax;
        _checkSinTax = SinTax;
        _totalTicket = tkt + tax + SinTax;

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // MsgBox(dsOrder.Tables("PaymentsAndCredits").Rows.Count)

        // If dsOrder.Tables("PaymentsAndCredits").Rows.Count = 0 Then
        // if no payments 
        _manualTicket = tkt;
        _manualTax = tax + SinTax;
        btnTicket.BackColor = Color.CornflowerBlue;
        btnTax.BackColor = Color.CornflowerBlue;
        compTax = true;
        // Else
        btnManual.BackColor = Color.CornflowerBlue;
        onManualTicket = true;
        // End If


        // Add any initialization after the InitializeComponent() call
        DisplayCompAmounts();

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
                _NumberPadMedium1.NumberEntered -= ManualCompEntered;
            }

            _NumberPadMedium1 = value;
            if (_NumberPadMedium1 != null)
            {
                _NumberPadMedium1.NumberEntered += ManualCompEntered;
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
    private Global.System.Windows.Forms.Button _btnFood;

    internal virtual Global.System.Windows.Forms.Button btnFood
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnFood;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnFood != null)
            {
                _btnFood.Click -= btnFood_Click;
            }

            _btnFood = value;
            if (_btnFood != null)
            {
                _btnFood.Click += btnFood_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnDrinks;

    internal virtual Global.System.Windows.Forms.Button btnDrinks
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDrinks;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnDrinks != null)
            {
                _btnDrinks.Click -= btnDrinks_Click;
            }

            _btnDrinks = value;
            if (_btnDrinks != null)
            {
                _btnDrinks.Click += btnDrinks_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnTax;

    internal virtual Global.System.Windows.Forms.Button btnTax
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnTax;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnTax != null)
            {
                _btnTax.Click -= btnTax_Click;
            }

            _btnTax = value;
            if (_btnTax != null)
            {
                _btnTax.Click += btnTax_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnManual;

    internal virtual Global.System.Windows.Forms.Button btnManual
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnManual;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnManual != null)
            {
                _btnManual.Click -= btnManual_Click;
            }

            _btnManual = value;
            if (_btnManual != null)
            {
                _btnManual.Click += btnManual_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnTicket;

    internal virtual Global.System.Windows.Forms.Button btnTicket
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnTicket;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnTicket != null)
            {
                _btnTicket.Click -= btnTicket_Click;
            }

            _btnTicket = value;
            if (_btnTicket != null)
            {
                _btnTicket.Click += btnTicket_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnApply;

    internal virtual Global.System.Windows.Forms.Button btnApply
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnApply;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnApply != null)
            {
                _btnApply.Click -= btnApply_Click;
            }

            _btnApply = value;
            if (_btnApply != null)
            {
                _btnApply.Click += btnApply_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblTax;

    internal virtual Global.System.Windows.Forms.Label lblTax
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTax;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblTax = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblTicket;

    internal virtual Global.System.Windows.Forms.Label lblTicket
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTicket;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblTicket = value;
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
        _NumberPadMedium1 = new DataSet_Builder.NumberPadMedium();
        _NumberPadMedium1.NumberEntered += ManualCompEntered;
        _btnTicket = new System.Windows.Forms.Button();
        _btnTicket.Click += btnTicket_Click;
        _btnFood = new System.Windows.Forms.Button();
        _btnFood.Click += btnFood_Click;
        _btnDrinks = new System.Windows.Forms.Button();
        _btnDrinks.Click += btnDrinks_Click;
        _btnTax = new System.Windows.Forms.Button();
        _btnTax.Click += btnTax_Click;
        _btnManual = new System.Windows.Forms.Button();
        _btnManual.Click += btnManual_Click;
        _btnCancel = new System.Windows.Forms.Button();
        _btnCancel.Click += btnCancel_Click;
        _btnApply = new System.Windows.Forms.Button();
        _btnApply.Click += btnApply_Click;
        _lblTax = new System.Windows.Forms.Label();
        _lblTicket = new System.Windows.Forms.Label();
        _Label1 = new System.Windows.Forms.Label();
        _Label2 = new System.Windows.Forms.Label();
        _Panel1 = new System.Windows.Forms.Panel();
        _Panel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // NumberPadMedium1
        // 
        _NumberPadMedium1.BackColor = System.Drawing.Color.SlateGray;
        _NumberPadMedium1.DecimalUsed = true;
        _NumberPadMedium1.IntegerNumber = 0;
        _NumberPadMedium1.Location = new System.Drawing.Point(280, 0);
        _NumberPadMedium1.Name = "_NumberPadMedium1";
        _NumberPadMedium1.NumberString = "";
        _NumberPadMedium1.NumberTotal = new decimal(new int[] { 0, 0, 0, 0 });
        _NumberPadMedium1.Size = new System.Drawing.Size(192, 296);
        _NumberPadMedium1.TabIndex = 0;
        // 
        // btnTicket
        // 
        _btnTicket.BackColor = System.Drawing.Color.SlateGray;
        _btnTicket.Font = new System.Drawing.Font("Comic Sans MS", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnTicket.Location = new System.Drawing.Point(160, 120);
        _btnTicket.Name = "_btnTicket";
        _btnTicket.Size = new System.Drawing.Size(96, 40);
        _btnTicket.TabIndex = 1;
        _btnTicket.Text = "Ticket";
        // 
        // btnFood
        // 
        _btnFood.BackColor = System.Drawing.Color.SlateGray;
        _btnFood.Font = new System.Drawing.Font("Comic Sans MS", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnFood.Location = new System.Drawing.Point(160, 8);
        _btnFood.Name = "_btnFood";
        _btnFood.Size = new System.Drawing.Size(96, 40);
        _btnFood.TabIndex = 2;
        _btnFood.Text = "Food";
        // 
        // btnDrinks
        // 
        _btnDrinks.BackColor = System.Drawing.Color.SlateGray;
        _btnDrinks.Font = new System.Drawing.Font("Comic Sans MS", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnDrinks.Location = new System.Drawing.Point(160, 64);
        _btnDrinks.Name = "_btnDrinks";
        _btnDrinks.Size = new System.Drawing.Size(96, 40);
        _btnDrinks.TabIndex = 3;
        _btnDrinks.Text = "Drinks";
        // 
        // btnTax
        // 
        _btnTax.BackColor = System.Drawing.Color.SlateGray;
        _btnTax.Font = new System.Drawing.Font("Comic Sans MS", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnTax.Location = new System.Drawing.Point(160, 176);
        _btnTax.Name = "_btnTax";
        _btnTax.Size = new System.Drawing.Size(96, 40);
        _btnTax.TabIndex = 4;
        _btnTax.Text = "Tax";
        // 
        // btnManual
        // 
        _btnManual.BackColor = System.Drawing.Color.SlateGray;
        _btnManual.Font = new System.Drawing.Font("Comic Sans MS", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnManual.Location = new System.Drawing.Point(160, 232);
        _btnManual.Name = "_btnManual";
        _btnManual.Size = new System.Drawing.Size(96, 56);
        _btnManual.TabIndex = 5;
        _btnManual.Text = "Manual Ticket";
        // 
        // btnCancel
        // 
        _btnCancel.Location = new System.Drawing.Point(40, 8);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.Size = new System.Drawing.Size(75, 32);
        _btnCancel.TabIndex = 6;
        _btnCancel.Text = "Cancel";
        // 
        // btnApply
        // 
        _btnApply.BackColor = System.Drawing.Color.Red;
        _btnApply.Location = new System.Drawing.Point(32, 240);
        _btnApply.Name = "_btnApply";
        _btnApply.Size = new System.Drawing.Size(88, 40);
        _btnApply.TabIndex = 7;
        _btnApply.Text = "Apply";
        // 
        // lblTax
        // 
        _lblTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblTax.Location = new System.Drawing.Point(32, 192);
        _lblTax.Name = "_lblTax";
        _lblTax.Size = new System.Drawing.Size(88, 23);
        _lblTax.TabIndex = 8;
        _lblTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblTicket
        // 
        _lblTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblTicket.Location = new System.Drawing.Point(32, 128);
        _lblTicket.Name = "_lblTicket";
        _lblTicket.Size = new System.Drawing.Size(88, 23);
        _lblTicket.TabIndex = 9;
        _lblTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label1
        // 
        _Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label1.Location = new System.Drawing.Point(8, 128);
        _Label1.Name = "_Label1";
        _Label1.Size = new System.Drawing.Size(24, 24);
        _Label1.TabIndex = 10;
        _Label1.Text = "$";
        _Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Label2
        // 
        _Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label2.Location = new System.Drawing.Point(8, 192);
        _Label2.Name = "_Label2";
        _Label2.Size = new System.Drawing.Size(24, 24);
        _Label2.TabIndex = 11;
        _Label2.Text = "$";
        _Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // Panel1
        // 
        _Panel1.Controls.Add(_btnCancel);
        _Panel1.Controls.Add(_Label2);
        _Panel1.Controls.Add(_lblTax);
        _Panel1.Controls.Add(_lblTicket);
        _Panel1.Controls.Add(_Label1);
        _Panel1.Controls.Add(_btnApply);
        _Panel1.Controls.Add(_btnFood);
        _Panel1.Controls.Add(_btnDrinks);
        _Panel1.Controls.Add(_btnTicket);
        _Panel1.Controls.Add(_btnTax);
        _Panel1.Controls.Add(_btnManual);
        _Panel1.Location = new System.Drawing.Point(0, 0);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(280, 296);
        _Panel1.TabIndex = 12;
        // 
        // Comp_Ticket_UC
        // 
        this.Controls.Add(_Panel1);
        this.Controls.Add(_NumberPadMedium1);
        this.Name = "Comp_Ticket_UC";
        this.Size = new System.Drawing.Size(472, 296);
        _Panel1.ResumeLayout(false);
        this.ResumeLayout(false);

    }



    #endregion

    private void DisplayCompAmounts()
    {

        lblTicket.Text = ManualTicket;
        lblTax.Text = ManualTax;

    }

    private void btnFood_Click(object sender, EventArgs e)
    {
        // will just comp food items

        ResetButtonColors();
        btnFood.BackColor = Color.CornflowerBlue;
        _manualTicket = CheckFood;

        // 666
        // ****** need to loop through for tax ID
        _manualTax = DetermineTaxPrice(ds.Tables("Tax").Rows(0)("TaxID"), CheckFood);
        DisplayCompAmounts();
        compTax = false;
        AllFood = true;
        AllDrinks = false;

    }

    private void btnDrinks_Click(object sender, EventArgs e)
    {
        // will just comp drink items

        ResetButtonColors();
        btnDrinks.BackColor = Color.CornflowerBlue;
        // CheckTax = GenerateOrderTables.DetermineTaxPrice(TaxID???, CheckDrinks)
        _manualTicket = CheckDrinks;
        _manualTax = DetermineTaxPrice(ds.Tables("Tax").Rows(0)("TaxID"), CheckDrinks);
        DisplayCompAmounts();
        compTax = false;
        AllFood = false;
        AllDrinks = true;
    }

    private void btnTicket_Click(object sender, EventArgs e)
    {

        ResetButtonColors();
        btnTicket.BackColor = Color.CornflowerBlue;
        _manualTicket = CheckTicket;
        if (compTax == true)
        {
            _manualTax = DetermineTaxPrice(ds.Tables("Tax").Rows(0)("TaxID"), CheckTicket);
            // 666 need to loop
            // _manualTax = CheckTax + CheckSinTax
        }

        DisplayCompAmounts();
        AllFood = false;
        AllDrinks = false;

    }

    private void btnTax_Click(object sender, EventArgs e)
    {
        return;

        if (compTax == true)
        {
            compTax = false;
            btnTax.BackColor = Color.LightGray;
            _manualTax = 0m;
            DisplayCompAmounts();
        }
        else
        {
            compTax = true;
            btnTax.BackColor = Color.CornflowerBlue;
            _manualTax = CheckTax + CheckSinTax;
            DisplayCompAmounts();
        }

    }

    private void btnManual_Click(object sender, EventArgs e)
    {

        ResetButtonColors();
        btnManual.BackColor = Color.CornflowerBlue;
        if (onManualTicket == true)
        {
            _manualTicket = 0m;
            lblTicket.Text = "";
        }

        // 666        onManualTicket = False
        // Me.btnManual.Text = "Manual Tax"
        else
        {
            _manualTax = 0m;
            lblTax.Text = "";

            onManualTicket = true;
            btnManual.Text = "Manual Ticket";
        }

    }

    private void ManualCompEntered(object sender, EventArgs e)
    {

        if (onManualTicket == false)
        {
            if (NumberPadMedium1.NumberTotal > CheckTax + CheckSinTax)
            {
                Interaction.MsgBox("You can not comp more than Check Tax");
                NumberPadMedium1.ResetValues();
                return;
            }
            _manualTax = NumberPadMedium1.NumberTotal;  // (Format(Me.NumberPadMedium1.NumberTotal, "####0.00"))
            onManualTicket = true;
            btnManual.Text = "Manual Ticket";
            NumberPadMedium1.IntegerNumber = 0;
            NumberPadMedium1.ShowNumberString();
        }
        else
        {
            if (NumberPadMedium1.NumberTotal > CheckTicket)
            {
                Interaction.MsgBox("You can not comp more than Check Ticket");
                NumberPadMedium1.ResetValues();
                return;
            }
            _manualTicket = NumberPadMedium1.NumberTotal; // (Format(Me.NumberPadMedium1.NumberTotal, "####0.00"))
            // 666    '    _manualTax = 0
            _manualTax = DetermineTaxPrice(ds.Tables("Tax").Rows(0)("TaxID"), ManualTicket);
            // 666        onManualTicket = False
            // Me.btnManual.Text = "Manual Tax"
            NumberPadMedium1.IntegerNumber = 0;
            NumberPadMedium1.ShowNumberString();
        }

        ResetButtonColors();
        btnManual.BackColor = Color.CornflowerBlue;
        DisplayCompAmounts();

    }

    private void ResetButtonColors()
    {

        btnFood.BackColor = Color.LightGray;
        btnDrinks.BackColor = Color.LightGray;
        btnTicket.BackColor = Color.LightGray;
        btnTax.BackColor = Color.LightGray;
        btnManual.BackColor = Color.LightGray;

    }

    private void btnCancel_Click(object sender, EventArgs e)
    {

        DisposeCompTicket?.Invoke();

    }

    private void btnApply_Click(object sender, EventArgs e)
    {
        // Dim compTotal As Decimal
        // Dim newPayment As DataSet_Builder.Payment

        if (ManualTax > CheckTax)
        {
            AdjSinTax = ManualTax - CheckTax;
            AdjTax = CheckTax;
        }
        else
        {
            AdjSinTax = 0m;
            AdjTax = ManualTax;
        }
        AdjPrice = ManualTicket;


        // compTotal = ManualTicket + ManualTax

        // newPayment.Purchase = Format(compTotal, "##,###.00")
        // newPayment.PaymentTypeID = -7
        // newPayment.PaymentTypeName = "Comp'd"   ' & currentTable.EmployeeID
        // AddPaymentToDataRow(newPayment, True, currentTable.ExperienceNumber, actingManager.EmployeeID)

        AcceptCompTicket?.Invoke();

    }
}