using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DataSet_Builder;
using Microsoft.VisualBasic; // Install-Package Microsoft.VisualBasic
using Microsoft.VisualBasic.CompilerServices; // Install-Package Microsoft.VisualBasic

public partial class ForcePrice_UC : System.Windows.Forms.UserControl
{

    private int splitRowNumber;

    private decimal begAdjustmentAmount;
    // Dim totalAdjustmentAmount As Decimal
    // Dim amountForcedAdj As Decimal

    public event UpdateAdjGridEventHandler UpdateAdjGrid;

    public delegate void UpdateAdjGridEventHandler(decimal newAdjAmount, decimal discountedAmount);
    // Event UpdateForcePrice()
    public event DisposeForcePriceEventHandler DisposeForcePrice;

    public delegate void DisposeForcePriceEventHandler();


    #region  Windows Form Designer generated code 

    public ForcePrice_UC(decimal firstValue) : base()
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        InitializeOther();
        begAdjustmentAmount = firstValue;
        lblTotalAmount.Text = Strings.Format(firstValue, "$ ##,###.00");

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
    private Global.System.Windows.Forms.Label _lblAdjustmentCredit;

    internal virtual Global.System.Windows.Forms.Label lblAdjustmentCredit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblAdjustmentCredit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblAdjustmentCredit = value;
        }
    }
    private Global.System.Windows.Forms.DataGrid _grdForcePrice;

    internal virtual Global.System.Windows.Forms.DataGrid grdForcePrice
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _grdForcePrice;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _grdForcePrice = value;
        }
    }
    private Global.System.Windows.Forms.TextBox _txtForceAdjustment;

    internal virtual Global.System.Windows.Forms.TextBox txtForceAdjustment
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtForceAdjustment;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _txtForceAdjustment = value;
        }
    }
    private DataSet_Builder.NumberPadMedium _NumberPadSmallForce;

    internal virtual DataSet_Builder.NumberPadMedium NumberPadSmallForce
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _NumberPadSmallForce;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_NumberPadSmallForce != null)
            {
                _NumberPadSmallForce.NumberEntered -= AdjustForcePriceAmount;
            }

            _NumberPadSmallForce = value;
            if (_NumberPadSmallForce != null)
            {
                _NumberPadSmallForce.NumberEntered += AdjustForcePriceAmount;
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
    private Global.System.Windows.Forms.Label _lblTotalAmount;

    internal virtual Global.System.Windows.Forms.Label lblTotalAmount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblTotalAmount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblTotalAmount = value;
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _Panel1 = new System.Windows.Forms.Panel();
        _btnCancel = new System.Windows.Forms.Button();
        _btnCancel.Click += btnCancel_Click;
        _NumberPadSmallForce = new DataSet_Builder.NumberPadMedium();
        _NumberPadSmallForce.NumberEntered += AdjustForcePriceAmount;
        _grdForcePrice = new System.Windows.Forms.DataGrid();
        _lblAdjustmentCredit = new System.Windows.Forms.Label();
        _txtForceAdjustment = new System.Windows.Forms.TextBox();
        _Label1 = new System.Windows.Forms.Label();
        _lblTotalAmount = new System.Windows.Forms.Label();
        _Panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_grdForcePrice).BeginInit();
        this.SuspendLayout();
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.SystemColors.Control;
        _Panel1.Controls.Add(_lblTotalAmount);
        _Panel1.Controls.Add(_Label1);
        _Panel1.Controls.Add(_btnCancel);
        _Panel1.Controls.Add(_NumberPadSmallForce);
        _Panel1.Controls.Add(_grdForcePrice);
        _Panel1.Controls.Add(_lblAdjustmentCredit);
        _Panel1.Controls.Add(_txtForceAdjustment);
        _Panel1.Location = new System.Drawing.Point(0, 0);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(472, 296);
        _Panel1.TabIndex = 16;
        // 
        // btnCancel
        // 
        _btnCancel.Location = new System.Drawing.Point(16, 256);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.Size = new System.Drawing.Size(72, 23);
        _btnCancel.TabIndex = 10;
        _btnCancel.Text = "Close";
        // 
        // NumberPadSmallForce
        // 
        _NumberPadSmallForce.BackColor = System.Drawing.Color.SlateGray;
        _NumberPadSmallForce.DecimalUsed = false;
        _NumberPadSmallForce.IntegerNumber = 0;
        _NumberPadSmallForce.Location = new System.Drawing.Point(280, 0);
        _NumberPadSmallForce.Name = "_NumberPadSmallForce";
        _NumberPadSmallForce.NumberString = (object)null;
        _NumberPadSmallForce.NumberTotal = new decimal(new int[] { 0, 0, 0, 0 });
        _NumberPadSmallForce.Size = new System.Drawing.Size(192, 296);
        _NumberPadSmallForce.TabIndex = 9;
        // 
        // grdForcePrice
        // 
        _grdForcePrice.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
        _grdForcePrice.CaptionVisible = false;
        _grdForcePrice.DataMember = "";
        _grdForcePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _grdForcePrice.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        _grdForcePrice.Location = new System.Drawing.Point(8, 8);
        _grdForcePrice.Name = "_grdForcePrice";
        _grdForcePrice.RowHeadersVisible = false;
        _grdForcePrice.Size = new System.Drawing.Size(264, 208);
        _grdForcePrice.TabIndex = 8;
        // 
        // lblAdjustmentCredit
        // 
        _lblAdjustmentCredit.ForeColor = System.Drawing.SystemColors.ActiveCaption;
        _lblAdjustmentCredit.Location = new System.Drawing.Point(112, 264);
        _lblAdjustmentCredit.Name = "_lblAdjustmentCredit";
        _lblAdjustmentCredit.Size = new System.Drawing.Size(64, 16);
        _lblAdjustmentCredit.TabIndex = 6;
        _lblAdjustmentCredit.Text = "Adjustment:";
        _lblAdjustmentCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // txtForceAdjustment
        // 
        _txtForceAdjustment.Location = new System.Drawing.Point(176, 264);
        _txtForceAdjustment.Name = "_txtForceAdjustment";
        _txtForceAdjustment.Size = new System.Drawing.Size(72, 20);
        _txtForceAdjustment.TabIndex = 5;
        _txtForceAdjustment.Text = "";
        // 
        // Label1
        // 
        _Label1.Location = new System.Drawing.Point(72, 232);
        _Label1.Name = "_Label1";
        _Label1.TabIndex = 11;
        _Label1.Text = "Amount Total:";
        _Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblTotalAmount
        // 
        _lblTotalAmount.Location = new System.Drawing.Point(184, 232);
        _lblTotalAmount.Name = "_lblTotalAmount";
        _lblTotalAmount.Size = new System.Drawing.Size(72, 23);
        _lblTotalAmount.TabIndex = 12;
        _lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // ForcePrice_UC
        // 
        this.BackColor = System.Drawing.SystemColors.Control;
        this.Controls.Add(_Panel1);
        this.Name = "ForcePrice_UC";
        this.Size = new System.Drawing.Size(472, 296);
        _Panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_grdForcePrice).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private void InitializeOther()
    {

        NumberPadSmallForce.DecimalUsed = true;
        DisplayForcePriceDataGrid();

    }

    private void DisplayForcePriceDataGrid()
    {

        grdForcePrice.DataSource = dvForcePrice;

        var tsForcePrice = new DataGridTableStyle();
        tsForcePrice.MappingName = "OpenOrders";
        tsForcePrice.RowHeadersVisible = false;
        tsForcePrice.GridLineColor = Color.White;

        var csForceSIN = new DataGridTextBoxColumn();
        csForceSIN.MappingName = "sin";
        csForceSIN.Width = 0;

        var csForceItemName = new DataGridTextBoxColumn();
        csForceItemName.MappingName = "TerminalName";
        csForceItemName.HeaderText = "Item Name";
        csForceItemName.Alignment = HorizontalAlignment.Left;
        csForceItemName.Width = 180;

        var csForcePrice = new DataGridTextBoxColumn();
        csForcePrice.MappingName = "Price";
        csForcePrice.HeaderText = "Price";
        csForcePrice.Alignment = HorizontalAlignment.Right;
        csForcePrice.Width = 60;

        var csBlank = new DataGridTextBoxColumn();
        csBlank.HeaderText = " ";
        csBlank.Width = 20;

        tsForcePrice.GridColumnStyles.Add(csForceSIN);
        tsForcePrice.GridColumnStyles.Add(csForceItemName);
        tsForcePrice.GridColumnStyles.Add(csForcePrice);
        tsForcePrice.GridColumnStyles.Add(csBlank);
        grdForcePrice.TableStyles.Add(tsForcePrice);


    }


    private void ForcePriceGrid_Selected() // (ByVal sender As Object, ByVal e As System.EventArgs) Handles grdForcePrice.CurrentCellChanged
    {

        // splitRowNumber = Me.grdForcePrice.CurrentCell.RowNumber
        // Me.NumberPadSmallForce.NumberTotal = Me.grdForcePrice(splitRowNumber, 2)
        // Me.NumberPadSmallForce.ShowNumberString()

        // Me.NumberPadSmallForce.Focus()
        // Me.NumberPadSmallForce.IntegerNumber = 0
        // Me.NumberPadSmallForce.NumberString = Nothing
        NumberPadSmallForce.ResetValues();
        NumberPadSmallForce.ShowNumberString();

        // begAdjustmentAmount = (Format(Me.NumberPadSmallForce.NumberTotal, "####0.00"))
        // begAdjustmentAmount = (Format(Me.grdForcePrice(splitRowNumber, 2), "####0.00"))

    }

    private void AdjustForcePriceAmount(object sender, EventArgs e)
    {

        decimal newAdjAmount;
        decimal discountedAmount;

        discountedAmount = Conversions.ToDecimal(Strings.Format(NumberPadSmallForce.NumberTotal, "####0.00"));

        // grdForcePrice(splitRowNumber, 2) = adjAmount

        newAdjAmount = begAdjustmentAmount - discountedAmount;
        if (newAdjAmount < 0m)
        {
            Interaction.MsgBox("You can not Credit more than the total amount: " + begAdjustmentAmount);
            ForcePriceGrid_Selected();
            return;
        }
        // totalAdjustmentAmount = adjAmount

        DisplayAdjustmentAmount(newAdjAmount * -1);
        // ApplyForcePrice()
        UpdateAdjGrid?.Invoke(newAdjAmount, discountedAmount);

    }

    private void DisplayAdjustmentAmount(decimal adjAmount)
    {

        txtForceAdjustment.Text = adjAmount;  // totalAdjustmentAmount

    }


    private void btnCancel_Click(object sender, EventArgs e)
    {
        DisposeForcePrice?.Invoke();

    }
}