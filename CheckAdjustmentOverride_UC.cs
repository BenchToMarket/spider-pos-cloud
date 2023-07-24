using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using DataSet_Builder;

public partial class CheckAdjustmentOverride_UC : System.Windows.Forms.UserControl
{

    private DataView _adjGridDataSource;
    private PrintHelper prt = new PrintHelper();
    private SIM.Charge _PaywarePCCharge;

    private SIM.Charge PaywarePCCharge
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _PaywarePCCharge;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _PaywarePCCharge = value;
        }
    }

    private int _paymentRowNum;
    private int _paymentColNum;
    // Dim _cashFlag As Boolean
    private decimal _remainingBalance;     // on both


    public DataView AdjGridDataSource
    {
        get
        {
            return _adjGridDataSource;
        }
        set
        {
            _adjGridDataSource = value;
        }
    }

    public int PaymentRowNum
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

    public int PaymentColNum
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

    // Friend Property CashFlag() As Boolean
    // Get
    // Return _cashFlag
    // End Get
    // Set(ByVal Value As Boolean)
    // _cashFlag = Value
    // End Set
    // End Property
    public decimal RemainingBalance
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


    // ******************************************************
    // waiting to do until after credit card payment in place
    // ******************************************************


    public event UpdateAdjGridPaymentEventHandler UpdateAdjGridPayment;

    public delegate void UpdateAdjGridPaymentEventHandler();






    #region  Windows Form Designer generated code 

    public CheckAdjustmentOverride_UC() : base()
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
                _grdPaymentTotals.CurrentCellChanged -= gridPaymentTotals_CellChanged;
            }

            _grdPaymentTotals = value;
            if (_grdPaymentTotals != null)
            {
                _grdPaymentTotals.CurrentCellChanged += gridPaymentTotals_CellChanged;
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
    private Global.System.Windows.Forms.TextBox _txtCloseRemain;

    public virtual Global.System.Windows.Forms.TextBox txtCloseRemain
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
    private Global.System.Windows.Forms.Button _btnDeletePayment;

    internal virtual Global.System.Windows.Forms.Button btnDeletePayment
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDeletePayment;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnDeletePayment != null)
            {
                _btnDeletePayment.Click -= Button1_Click;
            }

            _btnDeletePayment = value;
            if (_btnDeletePayment != null)
            {
                _btnDeletePayment.Click += Button1_Click;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _grdPaymentTotals = new System.Windows.Forms.DataGrid();
        _grdPaymentTotals.CurrentCellChanged += gridPaymentTotals_CellChanged;
        _txtCloseRemain = new System.Windows.Forms.TextBox();
        _Label1 = new System.Windows.Forms.Label();
        _btnDeletePayment = new System.Windows.Forms.Button();
        _btnDeletePayment.Click += Button1_Click;
        ((System.ComponentModel.ISupportInitialize)_grdPaymentTotals).BeginInit();
        this.SuspendLayout();
        // 
        // grdPaymentTotals
        // 
        _grdPaymentTotals.AllowSorting = false;
        _grdPaymentTotals.AlternatingBackColor = System.Drawing.Color.Black;
        _grdPaymentTotals.BackColor = System.Drawing.Color.Black;
        _grdPaymentTotals.BackgroundColor = System.Drawing.Color.Black;
        _grdPaymentTotals.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _grdPaymentTotals.CaptionVisible = false;
        _grdPaymentTotals.DataMember = "";
        _grdPaymentTotals.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _grdPaymentTotals.ForeColor = System.Drawing.Color.White;
        _grdPaymentTotals.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        _grdPaymentTotals.Location = new System.Drawing.Point(8, 8);
        _grdPaymentTotals.Name = "_grdPaymentTotals";
        _grdPaymentTotals.ReadOnly = true;
        _grdPaymentTotals.RowHeadersVisible = false;
        _grdPaymentTotals.Size = new System.Drawing.Size(422, 224);
        _grdPaymentTotals.TabIndex = 15;
        // 
        // txtCloseRemain
        // 
        _txtCloseRemain.BackColor = System.Drawing.Color.LightSlateGray;
        _txtCloseRemain.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _txtCloseRemain.Location = new System.Drawing.Point(184, 264);
        _txtCloseRemain.Name = "_txtCloseRemain";
        _txtCloseRemain.Size = new System.Drawing.Size(88, 20);
        _txtCloseRemain.TabIndex = 17;
        _txtCloseRemain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        _txtCloseRemain.Visible = false;
        // 
        // Label1
        // 
        _Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label1.Location = new System.Drawing.Point(120, 264);
        _Label1.Name = "_Label1";
        _Label1.Size = new System.Drawing.Size(56, 16);
        _Label1.TabIndex = 18;
        _Label1.Text = "Balance:";
        _Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        _Label1.Visible = false;
        // 
        // btnDeletePayment
        // 
        _btnDeletePayment.BackColor = System.Drawing.Color.CornflowerBlue;
        _btnDeletePayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnDeletePayment.Location = new System.Drawing.Point(16, 240);
        _btnDeletePayment.Name = "_btnDeletePayment";
        _btnDeletePayment.Size = new System.Drawing.Size(80, 48);
        _btnDeletePayment.TabIndex = 21;
        _btnDeletePayment.Text = "Delete";
        _btnDeletePayment.UseVisualStyleBackColor = false;
        // 
        // CheckAdjustmentOverride_UC
        // 
        this.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
        this.Controls.Add(_btnDeletePayment);
        this.Controls.Add(_Label1);
        this.Controls.Add(_txtCloseRemain);
        this.Controls.Add(_grdPaymentTotals);
        this.Name = "CheckAdjustmentOverride_UC";
        this.Size = new System.Drawing.Size(472, 296);
        ((System.ComponentModel.ISupportInitialize)_grdPaymentTotals).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion


    private void InitializeOther()
    {

        // MsgBox(dvPaymentsAndCredits.Count)
        // MsgBox(dsOrder.Tables("PaymentsAndCredits").Rows.Count)


        var tsPaymentTotals = new DataGridTableStyle();
        tsPaymentTotals.MappingName = "PaymentsAndCredits";
        tsPaymentTotals.RowHeadersVisible = false;
        tsPaymentTotals.AllowSorting = false;
        tsPaymentTotals.GridLineColor = Color.Black;
        tsPaymentTotals.AlternatingBackColor = Color.Black;
        tsPaymentTotals.BackColor = Color.Black;
        tsPaymentTotals.ForeColor = Color.White;
        tsPaymentTotals.SelectionBackColor = c15;

        var csPaymentType = new DataGridTextBoxColumn();
        csPaymentType.MappingName = "PaymentTypeName";
        csPaymentType.HeaderText = "Pay Type";
        csPaymentType.NullText = "";
        csPaymentType.Width = 95;

        var csAccount = new DataGridTextBoxColumn();
        csAccount.MappingName = "AccountNumber";
        csAccount.HeaderText = "Acct ";
        csAccount.NullText = "";
        csAccount.Alignment = HorizontalAlignment.Right;
        csAccount.Width = 140;

        var csDescription = new DataGridTextBoxColumn();
        csDescription.MappingName = "Description";
        csDescription.HeaderText = " "; // "Disposition"
        csDescription.NullText = "";
        csDescription.Alignment = HorizontalAlignment.Right;
        csDescription.Width = 100;

        var csPaymentAmount = new DataGridTextBoxColumn();
        csPaymentAmount.MappingName = "PaymentAmount";
        csPaymentAmount.HeaderText = "Amount ";
        csPaymentAmount.NullText = "";
        csPaymentAmount.Alignment = HorizontalAlignment.Right;
        csPaymentAmount.Width = 83;


        // Dim csTipAdj As New DataGridTextBoxColumn
        // csTipAdj.MappingName = "Surcharge"  '"TipAdjustment"
        // csTipAdj.HeaderText = "Tip adj "
        // '    csTipAdj.Alignment = HorizontalAlignment.Right
        // csTipAdj.Width = 50

        var csBlankPay = new DataGridTextBoxColumn();

        tsPaymentTotals.GridColumnStyles.Add(csPaymentType);
        tsPaymentTotals.GridColumnStyles.Add(csAccount);
        tsPaymentTotals.GridColumnStyles.Add(csDescription);
        tsPaymentTotals.GridColumnStyles.Add(csPaymentAmount);
        // tsPaymentTotals.GridColumnStyles.Add(csTipAdj)
        grdPaymentTotals.TableStyles.Add(tsPaymentTotals);
        AdjGridDataSource = dvPaymentsAndCredits;
        ChangePaymentDataSource();

        if (dvPaymentsAndCredits.Count == 0)
        {
            _paymentRowNum = -1;
        }
        ShowRemainingBalance();

    }

    private void gridPaymentTotals_CellChanged(object sender, EventArgs e)
    {
        _paymentRowNum = grdPaymentTotals.CurrentRowIndex;

    }


    public void ChangePaymentDataSource()
    {
        grdPaymentTotals.DataSource = AdjGridDataSource;

    }

    internal void ShowRemainingBalance()
    {
        decimal unauthorizedRemainingBalance;
        DataRowView vrow;


        unauthorizedRemainingBalance = RemainingBalance;

        // For Each vrow In dvUnAppliedPaymentsAndCredits
        // unauthorizedRemainingBalance -= vrow("PaymentAmount")
        // Next

        txtCloseRemain.Text = Strings.Format(unauthorizedRemainingBalance, "####0.00");

    }

    private void PrintCreditCardReceipt(ref DataRow orow, ref DataRowView vRow, bool useVIEW)
    {

        prt.ccDataRow = orow;
        prt.ccDataRowView = vRow;
        prt.useVIEW = useVIEW;
        prt.StartPrintCreditCardVoid();

        // ***
        // vRow("AccountNumber") = TruncateAccountNumber(vRow("AccountNumber"))

    }

    private void Button1_Click(object sender, EventArgs e)
    {

        var voidWentThrough = default(bool);
        string authStatus;

        if (PaymentRowNum > -1)
        {
            if (dvPaymentsAndCredits[PaymentRowNum]("PaymentTypeID") == -98)
            {
                // gift certificate
                dvPaymentsAndCredits[PaymentRowNum]("TransactionCode") = "Voided";
                dvPaymentsAndCredits[PaymentRowNum]("SwipeType") = -9;
                dvPaymentsAndCredits[PaymentRowNum]("TerminalID") = actingManager.EmployeeID;
                dvPaymentsAndCredits[PaymentRowNum]("Description") = "Voided";
                // dvPaymentsAndCredits(PaymentRowNum)("AuthCode") = DBNull.Value
                // dvPaymentsAndCredits(PaymentRowNum)("Applied") = False

                var argorow = default;
                var tmp = dvPaymentsAndCredits;
                var argvRow = tmp[PaymentRowNum];
                PrintCreditCardReceipt(ref argorow, ref argvRow, true);

                UpdateAdjGridPayment?.Invoke();
                ShowRemainingBalance();

                if (dvPaymentsAndCredits.Count == 0)
                {
                    _paymentRowNum = -1;
                }
                return;
            }

            if (dvPaymentsAndCredits[PaymentRowNum]("TransactionCode") == "PreAuth" | dvPaymentsAndCredits[PaymentRowNum]("TransactionCode") == "Credit" | dvPaymentsAndCredits[PaymentRowNum]("TransactionCode") == "Sale")
            {
                // transaction Code "Credit" is for manual credit cards, or outside
                // code "Sale" is for Gift
                if (companyInfo.processor == "Mercury")
                {

                    if (dvPaymentsAndCredits[PaymentRowNum]("TransactionCode") == "Sale")
                    {
                        // this is for void sale of Gift Card (MPS only)
                        authStatus = GenerateOrderTables.GiftCardTransaction(dvPaymentsAndCredits[PaymentRowNum], default, "VoidSale");
                        if (authStatus == "MPS Gift Card")
                        {
                            Interaction.MsgBox(authStatus);
                            return;
                        }
                        else if (authStatus == "Approved")
                        {
                            voidWentThrough = true;
                            // dvPaymentsAndCredits(PaymentRowNum)("OpenBigInt1") = currentTable.TabID
                        }
                    }
                    else // this is just regular Mercury PreAuth
                    {
                        // we just need to not send Capture
                        voidWentThrough = true;
                    }
                }
                else if (companyInfo.processor == "PaywarePC")
                {
                    voidWentThrough = VoidPaywarePCSale(dvPaymentsAndCredits[PaymentRowNum]);
                }


                if (voidWentThrough == true)
                {
                    dvPaymentsAndCredits[PaymentRowNum]("TransactionCode") = "Voided";
                    dvPaymentsAndCredits[PaymentRowNum]("SwipeType") = -9;
                    dvPaymentsAndCredits[PaymentRowNum]("TerminalID") = actingManager.EmployeeID;
                    dvPaymentsAndCredits[PaymentRowNum]("Description") = "Voided";
                    // dvPaymentsAndCredits(PaymentRowNum)("AuthCode") = DBNull.Value
                    // dvPaymentsAndCredits(PaymentRowNum)("Applied") = False

                    var argorow1 = default;
                    var tmp1 = dvPaymentsAndCredits;
                    var argvRow1 = tmp1[PaymentRowNum];
                    PrintCreditCardReceipt(ref argorow1, ref argvRow1, true);

                }
            }

            else
            {

                // dvPaymentsAndCredits(PaymentRowNum).Delete()
            }

            UpdateAdjGridPayment?.Invoke();
            ShowRemainingBalance();

            if (dvPaymentsAndCredits.Count == 0)
            {
                _paymentRowNum = -1;
            }

        }

        return;
        // 222 below
        if (PaymentRowNum > -1)
        {
            dvPaymentsAndCredits[PaymentRowNum].Delete();
            ShowRemainingBalance();

            if (dvPaymentsAndCredits.Count == 0)
            {
                _paymentRowNum = -1;
            }

        }


    }

    private bool VoidPaywarePCSale(DataRowView vRow)
    {

        PaywarePCCharge = new SIM.Charge();

        GenerateOrderTables.ReadyToProcessPaywarePC(PaywarePCCharge);

        {
            var withBlock = PaywarePCCharge;

            withBlock.Amount = Strings.Format(vRow("PaymentAmount") + vRow("Surcharge"), "#####0.00").ToString;
            withBlock.TroutD = vRow("RefNum");
            withBlock.Action = SIM.Charge.Command.Credit_Void;

            if (withBlock.Process)
            {
                try
                {
                    if (withBlock.GetResult == "VOIDED")
                    {

                        return true;
                    }

                    else // If .GetResult = "DECLINED" Or .GetResultCode = "6" Then
                    {
                        Interaction.MsgBox("CARD '" + vRow("AccountNumber") + "' " + withBlock.GetResult + ": " + withBlock.GetResponseText);
                        // MsgBox("CARD '" & vRow("AccountNumber") & "' DECLINED: " & .GetResponseText)
                    }
                }

                catch (Exception ex)
                {

                }
            }

            // MsgBox(.GetResult)
            // MsgBox(.GetAuthCode)
            // MsgBox(.GetReference)
            // MsgBox(.GetResultCode)
            // MsgBox(.GetTroutD)
            // MsgBox(.GetResponseText)

            else
            {
                Interaction.MsgBox("" + withBlock.ErrorCode + ": " + withBlock.ErrorDescription);
            }
        }

        return default;
    }
}