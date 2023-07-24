using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public partial class CheckAdjustment_UC : System.Windows.Forms.UserControl
{

    // numberPadSamll is really NumberPadMEDIUM here

    private int _paymentRowNum;
    private int _paymentColNum;
    private bool _creditAmountAdjusted;
    private bool _cashFlag;
    private decimal _remainingBalance;     // on both


    internal int PaymentRowNum
    {
        get
        {
            return _paymentRowNum;
        }
        set
        {
            _paymentRowNum = value;
        }
    }

    internal int PaymentColNum
    {
        get
        {
            return _paymentColNum;
        }
        set
        {
            _paymentColNum = value;
        }
    }

    internal bool CreditAmountAdjusted
    {
        get
        {
            return _creditAmountAdjusted;
        }
        set
        {
            _creditAmountAdjusted = value;
        }
    }

    internal bool CashFlag
    {
        get
        {
            return _cashFlag;
        }
        set
        {
            _cashFlag = value;
        }
    }

    internal decimal RemainingBalance
    {
        get
        {
            return _remainingBalance;
        }
        set
        {
            _remainingBalance = value;
        }
    }

    public event ApplyPaymentsEventHandler ApplyPayments;

    public delegate void ApplyPaymentsEventHandler(object sender, EventArgs e);
    public event AuthButtonHitEventHandler AuthButtonHit;

    public delegate void AuthButtonHitEventHandler(ref PreAuthAmountClass authamount, ref PreAuthTransactionClass authtransaction, bool cardSwipedDatabaseInfo);
    public event UC_HitEventHandler UC_Hit;

    public delegate void UC_HitEventHandler();



    #region  Windows Form Designer generated code 

    public CheckAdjustment_UC() : base()
    {

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
    private Global.System.Windows.Forms.DataGrid _grdPaymentTotals;

    internal virtual Global.System.Windows.Forms.DataGrid grdPaymentTotals
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _grdPaymentTotals;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_grdPaymentTotals != null)
            {
                _grdPaymentTotals.CurrentCellChanged -= PaymentGrid_Selected;
            }

            _grdPaymentTotals = value;
            if (_grdPaymentTotals != null)
            {
                _grdPaymentTotals.CurrentCellChanged += PaymentGrid_Selected;
            }
        }
    }
    private Global.System.Windows.Forms.TextBox _txtCloseRemain;

    internal virtual Global.System.Windows.Forms.TextBox txtCloseRemain
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtCloseRemain;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _txtCloseRemain = value;
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
    private Global.System.Windows.Forms.Button _btnApplyPayments;

    internal virtual Global.System.Windows.Forms.Button btnApplyPayments
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnApplyPayments;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnApplyPayments != null)
            {
                _btnApplyPayments.Click -= btnApplyPayments_Click;
            }

            _btnApplyPayments = value;
            if (_btnApplyPayments != null)
            {
                _btnApplyPayments.Click += btnApplyPayments_Click;
            }
        }
    }
    private DataSet_Builder.NumberPadMedium _NumberPadSmall1;

    internal virtual DataSet_Builder.NumberPadMedium NumberPadSmall1
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
                _NumberPadSmall1.NumberChanged -= NumberPadActivity;
                _NumberPadSmall1.NumberEntered -= AdjustPaymentAmount;
            }

            _NumberPadSmall1 = value;
            if (_NumberPadSmall1 != null)
            {
                _NumberPadSmall1.NumberChanged += NumberPadActivity;
                _NumberPadSmall1.NumberEntered += AdjustPaymentAmount;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnPaymentsAuth;

    internal virtual Global.System.Windows.Forms.Button btnPaymentsAuth
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnPaymentsAuth;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnPaymentsAuth != null)
            {
                _btnPaymentsAuth.Click -= btnPaymentsAuth_Click;
            }

            _btnPaymentsAuth = value;
            if (_btnPaymentsAuth != null)
            {
                _btnPaymentsAuth.Click += btnPaymentsAuth_Click;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _grdPaymentTotals = new System.Windows.Forms.DataGrid();
        _grdPaymentTotals.CurrentCellChanged += PaymentGrid_Selected;
        _txtCloseRemain = new System.Windows.Forms.TextBox();
        _Label1 = new System.Windows.Forms.Label();
        _btnApplyPayments = new System.Windows.Forms.Button();
        _btnApplyPayments.Click += btnApplyPayments_Click;
        _NumberPadSmall1 = new DataSet_Builder.NumberPadMedium();
        _NumberPadSmall1.NumberChanged += NumberPadActivity;
        _NumberPadSmall1.NumberEntered += AdjustPaymentAmount;
        _btnPaymentsAuth = new System.Windows.Forms.Button();
        _btnPaymentsAuth.Click += btnPaymentsAuth_Click;
        ((System.ComponentModel.ISupportInitialize)_grdPaymentTotals).BeginInit();
        this.SuspendLayout();
        // 
        // grdPaymentTotals
        // 
        _grdPaymentTotals.AllowSorting = false;
        _grdPaymentTotals.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
        _grdPaymentTotals.CaptionVisible = false;
        _grdPaymentTotals.DataMember = "";
        _grdPaymentTotals.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        _grdPaymentTotals.Location = new System.Drawing.Point(8, 8);
        _grdPaymentTotals.Name = "_grdPaymentTotals";
        _grdPaymentTotals.ReadOnly = true;
        _grdPaymentTotals.RowHeadersVisible = false;
        _grdPaymentTotals.Size = new System.Drawing.Size(272, 224);
        _grdPaymentTotals.TabIndex = 15;
        // 
        // txtCloseRemain
        // 
        _txtCloseRemain.BackColor = System.Drawing.Color.LightSlateGray;
        _txtCloseRemain.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _txtCloseRemain.Location = new System.Drawing.Point(200, 264);
        _txtCloseRemain.Name = "_txtCloseRemain";
        _txtCloseRemain.Size = new System.Drawing.Size(72, 20);
        _txtCloseRemain.TabIndex = 17;
        _txtCloseRemain.Text = "";
        _txtCloseRemain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        // 
        // Label1
        // 
        _Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label1.Location = new System.Drawing.Point(208, 240);
        _Label1.Name = "_Label1";
        _Label1.Size = new System.Drawing.Size(56, 16);
        _Label1.TabIndex = 18;
        _Label1.Text = "Balance:";
        _Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // btnApplyPayments
        // 
        _btnApplyPayments.BackColor = System.Drawing.Color.Red;
        _btnApplyPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnApplyPayments.Location = new System.Drawing.Point(8, 248);
        _btnApplyPayments.Name = "_btnApplyPayments";
        _btnApplyPayments.Size = new System.Drawing.Size(88, 40);
        _btnApplyPayments.TabIndex = 19;
        _btnApplyPayments.Text = "Apply";
        // 
        // NumberPadSmall1
        // 
        _NumberPadSmall1.BackColor = System.Drawing.Color.SlateGray;
        _NumberPadSmall1.DecimalUsed = false;
        _NumberPadSmall1.IntegerNumber = 0;
        _NumberPadSmall1.Location = new System.Drawing.Point(280, 0);
        _NumberPadSmall1.Name = "_NumberPadSmall1";
        _NumberPadSmall1.NumberString = (object)null;
        _NumberPadSmall1.NumberTotal = new decimal(new int[] { 0, 0, 0, 0 });
        _NumberPadSmall1.Size = new System.Drawing.Size(192, 304);
        _NumberPadSmall1.TabIndex = 20;
        // 
        // btnPaymentsAuth
        // 
        _btnPaymentsAuth.BackColor = System.Drawing.Color.SlateGray;
        _btnPaymentsAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnPaymentsAuth.Location = new System.Drawing.Point(104, 248);
        _btnPaymentsAuth.Name = "_btnPaymentsAuth";
        _btnPaymentsAuth.Size = new System.Drawing.Size(88, 40);
        _btnPaymentsAuth.TabIndex = 21;
        _btnPaymentsAuth.Text = "Auth";
        // 
        // CheckAdjustment_UC
        // 
        this.BackColor = System.Drawing.SystemColors.Control;
        this.Controls.Add(_btnPaymentsAuth);
        this.Controls.Add(_NumberPadSmall1);
        this.Controls.Add(_btnApplyPayments);
        this.Controls.Add(_Label1);
        this.Controls.Add(_txtCloseRemain);
        this.Controls.Add(_grdPaymentTotals);
        this.Name = "CheckAdjustment_UC";
        this.Size = new System.Drawing.Size(472, 296);
        ((System.ComponentModel.ISupportInitialize)_grdPaymentTotals).EndInit();
        this.ResumeLayout(false);

    }

    #endregion




    private void InitializeOther()
    {

        NumberPadSmall1.DecimalUsed = true;
        DisplayPaymentsAndCredits();

    }


    private void DisplayPaymentsAndCredits()
    {

        // we are using this in CLose Check class after we filter our dv
        grdPaymentTotals.DataSource = dvUnAppliedPaymentsAndCredits; // dsOrder.Tables("PaymentsAndCredits") '

        var tsPaymentTotals = new DataGridTableStyle();
        tsPaymentTotals.MappingName = "PaymentsAndCredits";
        tsPaymentTotals.RowHeadersVisible = false;
        tsPaymentTotals.AllowSorting = false;
        tsPaymentTotals.GridLineColor = Color.White;

        var csPaymentType = new DataGridTextBoxColumn();
        csPaymentType.MappingName = "PaymentTypeName";
        csPaymentType.HeaderText = "Pay Type";
        csPaymentType.Width = 70;

        var csPaymentAmount = new DataGridTextBoxColumn();
        csPaymentAmount.MappingName = "PaymentAmount";
        csPaymentAmount.HeaderText = "    Amount ";
        // csPaymentAmount.Alignment = HorizontalAlignment.Right
        csPaymentAmount.Width = 80;

        var csTipAmount = new DataGridTextBoxColumn();
        csTipAmount.MappingName = "Tip";
        csTipAmount.HeaderText = "    Tip ";
        // csTipAmount.Alignment = HorizontalAlignment.Right
        csTipAmount.Width = 53;

        var csAuthCode = new DataGridTextBoxColumn();
        csAuthCode.MappingName = "AuthCode";
        csAuthCode.HeaderText = " Auth    _";
        csAuthCode.Width = 65;
        csAuthCode.ReadOnly = true;
        csAuthCode.Alignment = HorizontalAlignment.Right;

        // Dim csBlankPay As New DataGridTextBoxColumn


        tsPaymentTotals.GridColumnStyles.Add(csPaymentType);
        tsPaymentTotals.GridColumnStyles.Add(csPaymentAmount);
        tsPaymentTotals.GridColumnStyles.Add(csTipAmount);
        tsPaymentTotals.GridColumnStyles.Add(csAuthCode);
        grdPaymentTotals.TableStyles.Add(tsPaymentTotals);



    }

    private void NumberPadActivity()
    {
        UC_Hit?.Invoke();

    }

    private void PaymentGrid_Selected(object sender, EventArgs e)
    {

        UC_Hit?.Invoke();

        PaymentRowNum = grdPaymentTotals.CurrentCell.RowNumber;
        PaymentColNum = grdPaymentTotals.CurrentCell.ColumnNumber;

        // numberPadSamll is really NumberPadMEDIUM here
        if (PaymentColNum > 0)
        {
            NumberPadSmall1.NumberTotal = this.grdPaymentTotals(PaymentRowNum, PaymentColNum);
            NumberPadSmall1.ShowNumberString();
            NumberPadSmall1.Focus();
            NumberPadSmall1.IntegerNumber = 0;
            NumberPadSmall1.NumberString = (object)null;
        }

        string authCode;

        authCode = grdPaymentTotals(PaymentRowNum, 3);
        if (authCode.Length > 1)
        {
            btnPaymentsAuth.Text = "Auth";
        }
        else
        {
            btnPaymentsAuth.Text = "Pre-Auth";
        }


    }

    private void AdjustPaymentAmount(object sender, EventArgs e)
    {
        UC_Hit?.Invoke();

        if (PaymentColNum == 1)
        {
            dvUnAppliedPaymentsAndCredits[PaymentRowNum]("PaymentAmount") = NumberPadSmall1.NumberTotal;
            // flags account to state already made manual adjustment
            // therefore will not auto calculate
            if (CashFlag == false)
            {
                CreditAmountAdjusted = true;
            }
            else
            {
                CashFlag = false;
            }
        }
        else if (PaymentColNum == 2)
        {
            dvUnAppliedPaymentsAndCredits[PaymentRowNum]("Tip") = NumberPadSmall1.NumberTotal;
        }
        else if (PaymentColNum == 3)
        {
            // dvUnAppliedPaymentsAndCredits(PaymentRowNum)("TipAdjustment") = NumberPadSmall1.NumberTotal
        }

        ShowRemainingBalance();

    }


    internal void ShowRemainingBalance()
    {
        decimal unauthorizedRemainingBalance;

        unauthorizedRemainingBalance = RemainingBalance;

        foreach (DataRowView vrow in dvUnAppliedPaymentsAndCredits)
            unauthorizedRemainingBalance -= vrow("PaymentAmount");
        txtCloseRemain.Text = Strings.Format(unauthorizedRemainingBalance, "####0.00");


    }


    private void btnApplyPayments_Click(object sender, EventArgs e)
    {
        UC_Hit?.Invoke();
        var unappliedPayments = default(decimal);

        // this is a test to verify payments are not more than check

        foreach (DataRowView vRow in dvUnAppliedPaymentsAndCredits)

            unappliedPayments += vRow("PaymentAmount");

        // ***************
        // might change to not allow this
        if ((double)unappliedPayments > (double)RemainingBalance + 0.02d)
        {
            // remainingBalance is what has already been applied
            if (Interaction.MsgBox("You are applying more than the balance. Are you sure?", MsgBoxStyle.YesNo) == MsgBoxResult.No)
            {
                return;
            }
        }

        RemainingBalance -= unappliedPayments;

        foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            if (oRow("PaymentAmount") != 0)
            {
                if (oRow("Applied") == false)
                {
                    oRow("Applied") = true;
                }
            }
        }


        ApplyPayments?.Invoke(sender, e);


    }


    private void btnPaymentsAuth_Click(object sender, EventArgs e)
    {
        UC_Hit?.Invoke();

        // Exit Sub
        // ***    currently not using


        // Dim authPayment As TStream
        var authTransaction = new PreAuthTransactionClass();
        var authAmount = new PreAuthAmountClass();
        var cardSwipedDatabaseInfo = default(bool);

        PaymentRowNum = grdPaymentTotals.CurrentCell.RowNumber;


        authAmount.Purchase = dvUnAppliedPaymentsAndCredits[PaymentRowNum]("PaymentAmount").ToString;
        authAmount.Authorize = Strings.Format(dvUnAppliedPaymentsAndCredits[PaymentRowNum]("PaymentAmount") * 1.2d, "######.00").ToString;
        // authAmount.Gratuity = Nothing

        authTransaction.MerchantID = "494901";       // CompanyID & LocationID
        authTransaction.OperatorID = "eGlobal";       // currentServer.EmployeeID.ToString
        authTransaction.TranType = "Credit";
        authTransaction.TranCode = "PreAuth";
        authTransaction.InvoiceNo = dvUnAppliedPaymentsAndCredits[PaymentRowNum]("ExperienceNumber") + "-" + dvUnAppliedPaymentsAndCredits[PaymentRowNum]("CheckNumber");
        authTransaction.RefNo = dvUnAppliedPaymentsAndCredits[PaymentRowNum]("ExperienceNumber") + "-" + dvUnAppliedPaymentsAndCredits[PaymentRowNum]("CheckNumber");

        if (!object.ReferenceEquals(dvUnAppliedPaymentsAndCredits[PaymentRowNum]("SwipeType"), DBNull.Value))
        {
            if (dvUnAppliedPaymentsAndCredits[PaymentRowNum]("SwipeType") == 1)
            {
                cardSwipedDatabaseInfo = true;
            }
            else
            {
                cardSwipedDatabaseInfo = false;
            }
        }


        AuthButtonHit?.Invoke(ref authAmount, ref authTransaction, cardSwipedDatabaseInfo);



    }


    private void OldAuth222()
    {

        var authPayment = new DataSet_Builder.Payment();

        if (PaymentRowNum >= 0)
        {
            authPayment.InvoiceNo = dvUnAppliedPaymentsAndCredits[PaymentRowNum]("CheckNumber");
            if (!object.ReferenceEquals(dvUnAppliedPaymentsAndCredits[PaymentRowNum]("RefNum"), DBNull.Value))
            {
                authPayment.RefNo = dvUnAppliedPaymentsAndCredits[PaymentRowNum]("RefNum");
            }

            if (!object.ReferenceEquals(dvUnAppliedPaymentsAndCredits[PaymentRowNum]("SwipeType"), DBNull.Value))
            {
                if (dvUnAppliedPaymentsAndCredits[PaymentRowNum]("SwipeType") == 1)
                {
                    authPayment.Swiped = true;
                }
                else
                {
                    authPayment.Swiped = false;
                }
            }

            if (!object.ReferenceEquals(dvUnAppliedPaymentsAndCredits[PaymentRowNum]("Track2"), DBNull.Value))
            {
                authPayment.Track2 = dvUnAppliedPaymentsAndCredits[PaymentRowNum]("Track2");
            }
            if (!object.ReferenceEquals(dvUnAppliedPaymentsAndCredits[PaymentRowNum]("CustomerName"), DBNull.Value))
            {
                authPayment.Name = dvUnAppliedPaymentsAndCredits[PaymentRowNum]("CustomerName");
            }

            if (!object.ReferenceEquals(dvUnAppliedPaymentsAndCredits[PaymentRowNum]("PaymentAmount"), DBNull.Value))
            {
                authPayment.Purchase = dvUnAppliedPaymentsAndCredits[PaymentRowNum]("PaymentAmount");
                authPayment.Authorize = authPayment.Purchase * 1.2d;
            }
            if (!object.ReferenceEquals(dvUnAppliedPaymentsAndCredits[PaymentRowNum]("Tip"), DBNull.Value))
            {
                authPayment.Gratuity = dvUnAppliedPaymentsAndCredits[PaymentRowNum]("Tip");
            }
            authPayment.AuthCode = dvUnAppliedPaymentsAndCredits[PaymentRowNum]("AuthCode");
            if (!object.ReferenceEquals(dvUnAppliedPaymentsAndCredits[PaymentRowNum]("AcqRefData"), DBNull.Value))
            {
                authPayment.AcqRefData = dvUnAppliedPaymentsAndCredits[PaymentRowNum]("AcqRefData");
            }

        }

    }


}