using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DataSet_Builder;



public partial class SplitItemUserControl : System.Windows.Forms.UserControl
{

    private int splitRowNumber;
    private int splitColNumber;

    internal SplittingCheck[] checkArray = new SplittingCheck[2];
    private int splittingQuantity;

    private decimal totalValue;
    private decimal itemAmountTotal;
    private decimal remainingTotal;

    private int remainingQuantity;

    public event ApplySplitCheckEventHandler ApplySplitCheck;

    public delegate void ApplySplitCheckEventHandler(object sender, EventArgs e);


    #region  Windows Form Designer generated code 

    public SplitItemUserControl(ref SplittingCheck[] checksSplitting, decimal price, int sq, int numberOfChecks) : base()
    {

        itemAmountTotal = price;
        checkArray = new SplittingCheck[numberOfChecks];

        Array.Copy(checksSplitting, checkArray, numberOfChecks);
        splittingQuantity = sq;


        // This call is required by the Windows Form Designer.
        InitializeComponent();
        NumberPadMediumSplit.DecimalUsed = true;

        // Add any initialization after the InitializeComponent() call
        InitializeOther(ref checkArray, numberOfChecks);



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
    private Global.System.Windows.Forms.TextBox _txtRemainingSplit;

    internal virtual Global.System.Windows.Forms.TextBox txtRemainingSplit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtRemainingSplit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _txtRemainingSplit = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblRemainingSplit;

    internal virtual Global.System.Windows.Forms.Label lblRemainingSplit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblRemainingSplit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblRemainingSplit = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnApplySplit;

    internal virtual Global.System.Windows.Forms.Button btnApplySplit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnApplySplit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnApplySplit != null)
            {
                _btnApplySplit.Click -= btnApplySplit_Click;
            }

            _btnApplySplit = value;
            if (_btnApplySplit != null)
            {
                _btnApplySplit.Click += btnApplySplit_Click;
            }
        }
    }
    private Global.System.Windows.Forms.DataGrid _grdSplitItem;

    internal virtual Global.System.Windows.Forms.DataGrid grdSplitItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _grdSplitItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_grdSplitItem != null)
            {
                _grdSplitItem.CurrentCellChanged -= SplitItemGrid_Selected;
            }

            _grdSplitItem = value;
            if (_grdSplitItem != null)
            {
                _grdSplitItem.CurrentCellChanged += SplitItemGrid_Selected;
            }
        }
    }
    private Global.System.Windows.Forms.Label _splitItemLabel;

    internal virtual Global.System.Windows.Forms.Label splitItemLabel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _splitItemLabel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _splitItemLabel = value;
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
    private DataSet_Builder.NumberPadMedium _NumberPadMediumSplit;

    internal virtual DataSet_Builder.NumberPadMedium NumberPadMediumSplit
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _NumberPadMediumSplit;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_NumberPadMediumSplit != null)
            {
                _NumberPadMediumSplit.NumberEntered -= AdjustSplitAmount;
            }

            _NumberPadMediumSplit = value;
            if (_NumberPadMediumSplit != null)
            {
                _NumberPadMediumSplit.NumberEntered += AdjustSplitAmount;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _Panel1 = new System.Windows.Forms.Panel();
        _NumberPadMediumSplit = new DataSet_Builder.NumberPadMedium();
        _NumberPadMediumSplit.NumberEntered += AdjustSplitAmount;
        _btnCancel = new System.Windows.Forms.Button();
        _btnCancel.Click += btnCancel_Click;
        _splitItemLabel = new System.Windows.Forms.Label();
        _grdSplitItem = new System.Windows.Forms.DataGrid();
        _grdSplitItem.CurrentCellChanged += SplitItemGrid_Selected;
        _btnApplySplit = new System.Windows.Forms.Button();
        _btnApplySplit.Click += btnApplySplit_Click;
        _lblRemainingSplit = new System.Windows.Forms.Label();
        _txtRemainingSplit = new System.Windows.Forms.TextBox();
        _Panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_grdSplitItem).BeginInit();
        this.SuspendLayout();
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
        _Panel1.Controls.Add(_NumberPadMediumSplit);
        _Panel1.Controls.Add(_btnCancel);
        _Panel1.Controls.Add(_splitItemLabel);
        _Panel1.Controls.Add(_grdSplitItem);
        _Panel1.Controls.Add(_btnApplySplit);
        _Panel1.Controls.Add(_lblRemainingSplit);
        _Panel1.Controls.Add(_txtRemainingSplit);
        _Panel1.Location = new System.Drawing.Point(16, 8);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(480, 384);
        _Panel1.TabIndex = 6;
        // 
        // NumberPadMediumSplit
        // 
        _NumberPadMediumSplit.BackColor = System.Drawing.Color.SlateGray;
        _NumberPadMediumSplit.DecimalUsed = true;
        _NumberPadMediumSplit.ForeColor = System.Drawing.Color.Black;
        _NumberPadMediumSplit.IntegerNumber = 0;
        _NumberPadMediumSplit.Location = new System.Drawing.Point(272, 32);
        _NumberPadMediumSplit.Name = "_NumberPadMediumSplit";
        _NumberPadMediumSplit.NumberString = "";
        _NumberPadMediumSplit.NumberTotal = new decimal(new int[] { 0, 0, 0, 0 });
        _NumberPadMediumSplit.Size = new System.Drawing.Size(192, 296);
        _NumberPadMediumSplit.TabIndex = 11;
        // 
        // btnCancel
        // 
        _btnCancel.BackColor = System.Drawing.Color.LightSlateGray;
        _btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
        _btnCancel.Location = new System.Drawing.Point(272, 344);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.Size = new System.Drawing.Size(64, 24);
        _btnCancel.TabIndex = 10;
        _btnCancel.Text = "Cancel";
        // 
        // splitItemLabel
        // 
        _splitItemLabel.BackColor = System.Drawing.Color.FromArgb(59, 96, 141);
        _splitItemLabel.Dock = System.Windows.Forms.DockStyle.Top;
        _splitItemLabel.Font = new System.Drawing.Font("Bookman Old Style", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _splitItemLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _splitItemLabel.Location = new System.Drawing.Point(0, 0);
        _splitItemLabel.Name = "_splitItemLabel";
        _splitItemLabel.Size = new System.Drawing.Size(480, 24);
        _splitItemLabel.TabIndex = 9;
        _splitItemLabel.Text = "Splitting Item: ";
        _splitItemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // grdSplitItem
        // 
        _grdSplitItem.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
        _grdSplitItem.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _grdSplitItem.CaptionVisible = false;
        _grdSplitItem.DataMember = "";
        _grdSplitItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _grdSplitItem.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        _grdSplitItem.Location = new System.Drawing.Point(16, 32);
        _grdSplitItem.Name = "_grdSplitItem";
        _grdSplitItem.RowHeadersVisible = false;
        _grdSplitItem.Size = new System.Drawing.Size(224, 264);
        _grdSplitItem.TabIndex = 8;
        // 
        // btnApplySplit
        // 
        _btnApplySplit.BackColor = System.Drawing.Color.Red;
        _btnApplySplit.Location = new System.Drawing.Point(368, 336);
        _btnApplySplit.Name = "_btnApplySplit";
        _btnApplySplit.Size = new System.Drawing.Size(88, 40);
        _btnApplySplit.TabIndex = 7;
        _btnApplySplit.Text = "Apply";
        // 
        // lblRemainingSplit
        // 
        _lblRemainingSplit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblRemainingSplit.ForeColor = System.Drawing.Color.FromArgb(59, 96, 141);
        _lblRemainingSplit.Location = new System.Drawing.Point(24, 320);
        _lblRemainingSplit.Name = "_lblRemainingSplit";
        _lblRemainingSplit.Size = new System.Drawing.Size(112, 16);
        _lblRemainingSplit.TabIndex = 6;
        _lblRemainingSplit.Text = "Remaining:";
        _lblRemainingSplit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // txtRemainingSplit
        // 
        _txtRemainingSplit.Location = new System.Drawing.Point(136, 320);
        _txtRemainingSplit.Name = "_txtRemainingSplit";
        _txtRemainingSplit.Size = new System.Drawing.Size(72, 20);
        _txtRemainingSplit.TabIndex = 5;
        _txtRemainingSplit.Text = "";
        // 
        // SplitItemUserControl
        // 
        this.BackColor = System.Drawing.Color.FromArgb(59, 96, 141);
        this.Controls.Add(_Panel1);
        this.ForeColor = System.Drawing.Color.White;
        this.Name = "SplitItemUserControl";
        this.Size = new System.Drawing.Size(512, 408);
        _Panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_grdSplitItem).EndInit();
        this.ResumeLayout(false);

    }

    #endregion


    private void InitializeOther(ref SplittingCheck[] checkarray, int numberOfChecks)
    {
        if (splittingQuantity > 1)
        {
            NumberPadMediumSplit.DisplayIntegerNumber = true;
            remainingQuantity = Conversions.ToInteger(DetermineRemainingQuantity());
        }


        decimal roundingError;

        // CreateCheckCollection(checksSplitting, numberOfChecks)

        roundingError = Conversions.ToDecimal(DetermineRemainingValue());

        if (roundingError != 0m)
        {
            foreach (var checkSplit in checkarray)   // CurrentSplittingChecks
            {
                // add to first one only in both array and collection
                // checkSplit.CheckAmount += roundingError
                // this will always be the first position
                checkarray[0].CheckAmount += roundingError;
                roundingError = 0m;
                break;
            }
        }

        DisplayRemainingValue();


        grdSplitItem.DataSource = checkarray; // CurrentSplittingChecks '

        var tsCheckSplit = new DataGridTableStyle();
        tsCheckSplit.MappingName = "SplittingCheck[]"; // "SplittingCheckCollection[]" '
        tsCheckSplit.RowHeadersVisible = false;
        tsCheckSplit.AllowSorting = false;
        tsCheckSplit.GridLineColor = Color.White;

        var csCheckName = new DataGridTextBoxColumn();
        csCheckName.MappingName = "CheckNumber";
        csCheckName.HeaderText = "Check #";
        csCheckName.Alignment = HorizontalAlignment.Center;
        csCheckName.Width = 100;

        var csCheckAmount = new DataGridTextBoxColumn();
        csCheckAmount.Alignment = HorizontalAlignment.Center;
        csCheckAmount.MappingName = "CheckAmount";
        if (splittingQuantity > 1)
        {
            csCheckAmount.Width = 0;
        }
        else
        {
            csCheckAmount.HeaderText = "Amount";
            csCheckAmount.Width = grdSplitItem.Width - 105;
        }

        var csCheckQuantity = new DataGridTextBoxColumn();
        csCheckQuantity.MappingName = "CheckQuantity";
        csCheckQuantity.Alignment = HorizontalAlignment.Center;
        if (splittingQuantity > 1)
        {
            csCheckQuantity.HeaderText = "Quantity";
            csCheckQuantity.Width = grdSplitItem.Width - 105;
        }
        else
        {
            csCheckQuantity.Width = 0;
        }

        // Dim csBlank As New DataGridTextBoxColumn
        // csBlank.Width = 30


        tsCheckSplit.GridColumnStyles.Add(csCheckName);
        tsCheckSplit.GridColumnStyles.Add(csCheckAmount);
        tsCheckSplit.GridColumnStyles.Add(csCheckQuantity);
        // tsCheckSplit.GridColumnStyles.Add(csBlank)
        grdSplitItem.TableStyles.Add(tsCheckSplit);

        // this is for quantity change
        totalValue = Conversions.ToDecimal(DetermineTotalValue());

    }


    private void SplitItemGrid_Selected(object sender, EventArgs e)
    {

        // If Me.NumberPadMediumSplit.changesMade = True Then
        // AdjustingSplitAmount()
        // End If

        splitRowNumber = grdSplitItem.CurrentCell.RowNumber;
        splitColNumber = grdSplitItem.CurrentCell.ColumnNumber;


        if (splitColNumber == 1 | splitColNumber == 2)
        {
            if (splittingQuantity > 1)
            {
                NumberPadMediumSplit.NumberTotal = this.grdSplitItem(splitRowNumber, splitColNumber);
            }
            else
            {
                NumberPadMediumSplit.NumberTotal = this.grdSplitItem(splitRowNumber, splitColNumber);
            }
            NumberPadMediumSplit.ShowNumberString();
            NumberPadMediumSplit.Focus();
        }


    }


    private void AdjustSplitAmount(object sender, EventArgs e)
    {

        AdjustingSplitAmount();

    }

    private void AdjustingSplitAmount()
    {
        NumberPadMediumSplit.changesMade = false;

        if (splitColNumber == 1 | splitColNumber == 2)
        {
            if (splittingQuantity > 1)
            {
                grdSplitItem(splitRowNumber, splitColNumber) = Conversions.ToInteger(Strings.Format(NumberPadMediumSplit.IntegerNumber, "####0"));
                // next line adjust price for quantity change
                grdSplitItem(splitRowNumber, 1) = Conversions.ToDecimal(Strings.Format(totalValue / splittingQuantity * NumberPadMediumSplit.IntegerNumber, "####0.00"));

                remainingQuantity = Conversions.ToInteger(DetermineRemainingQuantity());
            }
            else
            {
                grdSplitItem(splitRowNumber, splitColNumber) = Conversions.ToDecimal(Strings.Format(NumberPadMediumSplit.NumberTotal, "####0.00"));
                remainingTotal = Conversions.ToDecimal(DetermineRemainingValue());
            }
        }

        DisplayRemainingValue();
        NumberPadMediumSplit.ResetValues();

    }

    private object DetermineTotalValue()
    {
        var amountAccountedFor = default(decimal);

        foreach (var check in checkArray)
            amountAccountedFor = Conversions.ToDecimal(amountAccountedFor + Strings.Format(check.CheckAmount, "####0.00"));

        return amountAccountedFor;

    }

    private object DetermineRemainingValue() // ByVal totalPrice As Decimal, ByVal eachAmount As Decimal, ByVal number As Integer)
    {
        decimal remaining;
        var amountAccountedFor = default(decimal);

        foreach (var check in checkArray)
            amountAccountedFor = Conversions.ToDecimal(amountAccountedFor + Strings.Format(check.CheckAmount, "####0.00"));

        remaining = Conversions.ToDecimal(Strings.Format(itemAmountTotal - amountAccountedFor, "####0.00"));

        // don't need return now
        return remaining;

    }

    private object DetermineRemainingQuantity()
    {
        int remaining;
        var quantityAccountedFor = default(int);

        foreach (var check in checkArray)
            quantityAccountedFor = Conversions.ToInteger(quantityAccountedFor + Strings.Format(check.CheckQuantity, "###0"));

        remaining = Conversions.ToInteger(Strings.Format(splittingQuantity - quantityAccountedFor, "###0"));

        return remaining;


    }



    private void DisplayRemainingValue()
    {

        if (splittingQuantity > 1)
        {
            txtRemainingSplit.Text = remainingQuantity;
        }
        else
        {
            txtRemainingSplit.Text = remainingTotal;
        }

    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.Dispose();

    }



    private void btnApplySplit_Click(object sender, EventArgs e)
    {

        if (splittingQuantity > 1)
        {
            if (remainingQuantity > 0)
            {
                Interaction.MsgBox("You must add the remaining " + remainingQuantity + " item(s) to at least one of the checks.");
                return;
            }
            else if (remainingQuantity < 0)
            {
                Interaction.MsgBox("You must deduct the remaining " + -remainingQuantity + " item(s) from at least one of the checks.");
                return;
            }
        }
        else if (remainingTotal > 0m)
        {
            Interaction.MsgBox("You must add the remaining $ " + remainingTotal + " to at least one of the checks.");
            return;
        }
        else if (remainingTotal < 0m)
        {
            Interaction.MsgBox("You must deduct the remaining $ " + -remainingTotal + " from at least one of the checks.");
            return;
        }


        ApplySplitCheck?.Invoke(sender, e);
        this.Dispose();

    }

}