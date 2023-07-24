using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using DataSet_Builder;


public partial class ReturnCredit_UC : System.Windows.Forms.UserControl
{

    private DSICLIENTXLib.DSICLientX dsi = new DSICLIENTXLib.DSICLientX();
    // Dim dsi As New AxDSICLIENTXLib.AxDSICLientX

    private ReadCredit readAuth;
    // Dim sql As New DataSet_Builder.SQLHelper(connectserver)
    // Dim sWriter1 As StreamWriter

    private TStream mpsTStream;
    private PreAuthTransactionClass mpsTransaction;
    private PreAuthAmountClass mpsAmount;
    private AccountClass mpsAccount;


    private bool isReadyForReturn;

    private string returnTrack2;
    private string returnAcctNum;
    private string returnExpDate;
    private decimal returnAmount = 0m;
    private int returnInvoiceNumber;
    // Dim returnPaymentTypeID As Integer
    private string returnPaymentTypeName;


    private DataSet_Builder.Payment returnPayment = new DataSet_Builder.Payment();


    public PanelActive ReturnPanelActive;

    public enum PanelActive : int
    {

        AccountPanel = 1,
        ExpDatePanel = 2,
        ReturnAmountPanel = 3,
        InvoicePanel = 4

    }

    #region  Windows Form Designer generated code 

    public ReturnCredit_UC() : base()
    {
        readAuth = new ReadCredit(false);

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        InitializeOther();
        readAuth.CardReadSuccessful += NewCardRead;
        readAuth.CardReadFailed += CardRead_Failed;


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
                _NumberPadLarge1.NumberEntered -= PaymentEnterHit;
            }

            _NumberPadLarge1 = value;
            if (_NumberPadLarge1 != null)
            {
                _NumberPadLarge1.NumberEntered += PaymentEnterHit;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblAcctNum;

    internal virtual Global.System.Windows.Forms.Label lblAcctNum
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblAcctNum;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblAcctNum != null)
            {
                _lblAcctNum.Click -= lblAcctNum_Click;
            }

            _lblAcctNum = value;
            if (_lblAcctNum != null)
            {
                _lblAcctNum.Click += lblAcctNum_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblReturnAmount;

    internal virtual Global.System.Windows.Forms.Label lblReturnAmount
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblReturnAmount;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblReturnAmount != null)
            {
                _lblReturnAmount.Click -= lblReturnAmount_Click;
            }

            _lblReturnAmount = value;
            if (_lblReturnAmount != null)
            {
                _lblReturnAmount.Click += lblReturnAmount_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblAcctNumDetail;

    internal virtual Global.System.Windows.Forms.Label lblAcctNumDetail
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblAcctNumDetail;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblAcctNumDetail = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblInvoiceNum;

    internal virtual Global.System.Windows.Forms.Label lblInvoiceNum
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblInvoiceNum;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lblInvoiceNum != null)
            {
                _lblInvoiceNum.Click -= lblInvoiceNum_Click;
            }

            _lblInvoiceNum = value;
            if (_lblInvoiceNum != null)
            {
                _lblInvoiceNum.Click += lblInvoiceNum_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblReturnAmountDetail;

    internal virtual Global.System.Windows.Forms.Label lblReturnAmountDetail
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblReturnAmountDetail;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblReturnAmountDetail = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblInvoiceNumDetail;

    internal virtual Global.System.Windows.Forms.Label lblInvoiceNumDetail
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblInvoiceNumDetail;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblInvoiceNumDetail = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlInvoiceDetail;

    internal virtual Global.System.Windows.Forms.Panel pnlInvoiceDetail
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlInvoiceDetail;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlInvoiceDetail = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblExpDateDetail;

    internal virtual Global.System.Windows.Forms.Label lblExpDateDetail
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblExpDateDetail;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblExpDateDetail = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnReturn;

    internal virtual Global.System.Windows.Forms.Button btnReturn
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnReturn;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnReturn != null)
            {
                _btnReturn.Click -= btnReturn_Click;
            }

            _btnReturn = value;
            if (_btnReturn != null)
            {
                _btnReturn.Click += btnReturn_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnCanel;

    internal virtual Global.System.Windows.Forms.Button btnCanel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnCanel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnCanel != null)
            {
                _btnCanel.Click -= ButtonCancel_Click;
            }

            _btnCanel = value;
            if (_btnCanel != null)
            {
                _btnCanel.Click += ButtonCancel_Click;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _NumberPadLarge1 = new DataSet_Builder.NumberPadLarge();
        _NumberPadLarge1.NumberEntered += PaymentEnterHit;
        _lblAcctNum = new System.Windows.Forms.Label();
        _lblAcctNum.Click += lblAcctNum_Click;
        _lblReturnAmount = new System.Windows.Forms.Label();
        _lblReturnAmount.Click += lblReturnAmount_Click;
        _lblInvoiceNum = new System.Windows.Forms.Label();
        _lblInvoiceNum.Click += lblInvoiceNum_Click;
        _lblAcctNumDetail = new System.Windows.Forms.Label();
        _lblReturnAmountDetail = new System.Windows.Forms.Label();
        _lblInvoiceNumDetail = new System.Windows.Forms.Label();
        _btnReturn = new System.Windows.Forms.Button();
        _btnReturn.Click += btnReturn_Click;
        _btnCanel = new System.Windows.Forms.Button();
        _btnCanel.Click += ButtonCancel_Click;
        _pnlInvoiceDetail = new System.Windows.Forms.Panel();
        _lblExpDateDetail = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // NumberPadLarge1
        // 
        _NumberPadLarge1.BackColor = System.Drawing.Color.SlateGray;
        _NumberPadLarge1.DecimalUsed = true;
        _NumberPadLarge1.ForeColor = System.Drawing.Color.CornflowerBlue;
        _NumberPadLarge1.IntegerNumber = 0;
        _NumberPadLarge1.Location = new System.Drawing.Point(392, 136);
        _NumberPadLarge1.Name = "_NumberPadLarge1";
        _NumberPadLarge1.NumberString = "";
        _NumberPadLarge1.NumberTotal = new decimal(new int[] { 0, 0, 0, 0 });
        _NumberPadLarge1.Size = new System.Drawing.Size(240, 368);
        _NumberPadLarge1.TabIndex = 0;
        // 
        // lblAcctNum
        // 
        _lblAcctNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblAcctNum.Location = new System.Drawing.Point(56, 16);
        _lblAcctNum.Name = "_lblAcctNum";
        _lblAcctNum.Size = new System.Drawing.Size(240, 40);
        _lblAcctNum.TabIndex = 1;
        _lblAcctNum.Text = "Swipe Credit Card:";
        // 
        // lblReturnAmount
        // 
        _lblReturnAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblReturnAmount.Location = new System.Drawing.Point(56, 96);
        _lblReturnAmount.Name = "_lblReturnAmount";
        _lblReturnAmount.Size = new System.Drawing.Size(240, 40);
        _lblReturnAmount.TabIndex = 2;
        _lblReturnAmount.Text = "Enter Return Amount $:";
        // 
        // lblInvoiceNum
        // 
        _lblInvoiceNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblInvoiceNum.Location = new System.Drawing.Point(56, 176);
        _lblInvoiceNum.Name = "_lblInvoiceNum";
        _lblInvoiceNum.Size = new System.Drawing.Size(240, 56);
        _lblInvoiceNum.TabIndex = 3;
        _lblInvoiceNum.Text = "Enter Invoice Number from old Ticket:";
        // 
        // lblAcctNumDetail
        // 
        _lblAcctNumDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblAcctNumDetail.Location = new System.Drawing.Point(56, 56);
        _lblAcctNumDetail.Name = "_lblAcctNumDetail";
        _lblAcctNumDetail.Size = new System.Drawing.Size(168, 32);
        _lblAcctNumDetail.TabIndex = 4;
        _lblAcctNumDetail.Text = "Account Number";
        _lblAcctNumDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblReturnAmountDetail
        // 
        _lblReturnAmountDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblReturnAmountDetail.Location = new System.Drawing.Point(88, 136);
        _lblReturnAmountDetail.Name = "_lblReturnAmountDetail";
        _lblReturnAmountDetail.Size = new System.Drawing.Size(160, 32);
        _lblReturnAmountDetail.TabIndex = 5;
        _lblReturnAmountDetail.Text = "Return Amount";
        _lblReturnAmountDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblInvoiceNumDetail
        // 
        _lblInvoiceNumDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblInvoiceNumDetail.Location = new System.Drawing.Point(104, 232);
        _lblInvoiceNumDetail.Name = "_lblInvoiceNumDetail";
        _lblInvoiceNumDetail.Size = new System.Drawing.Size(144, 32);
        _lblInvoiceNumDetail.TabIndex = 6;
        _lblInvoiceNumDetail.Text = "Invoice Number";
        _lblInvoiceNumDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btnReturn
        // 
        _btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnReturn.Location = new System.Drawing.Point(376, 40);
        _btnReturn.Name = "_btnReturn";
        _btnReturn.Size = new System.Drawing.Size(120, 64);
        _btnReturn.TabIndex = 7;
        _btnReturn.Text = "Return";
        // 
        // btnCanel
        // 
        _btnCanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnCanel.Location = new System.Drawing.Point(520, 40);
        _btnCanel.Name = "_btnCanel";
        _btnCanel.Size = new System.Drawing.Size(120, 64);
        _btnCanel.TabIndex = 8;
        _btnCanel.Text = "Cancel";
        // 
        // pnlInvoiceDetail
        // 
        _pnlInvoiceDetail.Location = new System.Drawing.Point(40, 272);
        _pnlInvoiceDetail.Name = "_pnlInvoiceDetail";
        _pnlInvoiceDetail.Size = new System.Drawing.Size(272, 232);
        _pnlInvoiceDetail.TabIndex = 9;
        // 
        // lblExpDateDetail
        // 
        _lblExpDateDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblExpDateDetail.Location = new System.Drawing.Point(232, 56);
        _lblExpDateDetail.Name = "_lblExpDateDetail";
        _lblExpDateDetail.Size = new System.Drawing.Size(64, 32);
        _lblExpDateDetail.TabIndex = 10;
        _lblExpDateDetail.Text = "Exp Date";
        _lblExpDateDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // ReturnCredit_UC
        // 
        this.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
        this.Controls.Add(_lblExpDateDetail);
        this.Controls.Add(_pnlInvoiceDetail);
        this.Controls.Add(_btnCanel);
        this.Controls.Add(_btnReturn);
        this.Controls.Add(_lblInvoiceNumDetail);
        this.Controls.Add(_lblReturnAmountDetail);
        this.Controls.Add(_lblAcctNumDetail);
        this.Controls.Add(_lblInvoiceNum);
        this.Controls.Add(_lblReturnAmount);
        this.Controls.Add(_lblAcctNum);
        this.Controls.Add(_NumberPadLarge1);
        this.Name = "ReturnCredit_UC";
        this.Size = new System.Drawing.Size(696, 528);
        this.ResumeLayout(false);

    }

    #endregion


    private void InitializeOther()
    {

        currentTable = new DinnerTable();

        // ReturnPanelActive = PanelActive.InvoicePanel
        lblAcctNum.BackColor = c6;
        lblAcctNum.ForeColor = c3;

        PreAuthAmountClass returnhamount;
        PreAuthTransactionClass returnTransaction;


        // readAuth = New ReadCredit
        // readAuth.CloseManualAuth_Load()

        ActivateAcctNumberPanel();

    }

    private void ResetPanels()
    {

        lblAcctNum.BackColor = c11;
        lblAcctNum.ForeColor = c2;
        lblReturnAmount.BackColor = c11;
        lblReturnAmount.ForeColor = c2;
        lblInvoiceNum.BackColor = c11;
        lblInvoiceNum.ForeColor = c2;



    }

    private void ActivateAcctNumberPanel()
    {
        ResetPanels();
        ReturnPanelActive = PanelActive.AccountPanel;
        lblAcctNum.BackColor = c6;
        lblAcctNum.ForeColor = c3;

        NumberPadLarge1.DecimalUsed = false;
        if (companyInfo.usingOutsideCreditProcessor == false)
        {
            NumberPadLarge1.NumberString = "Enter Acct Number ";
        }
        NumberPadLarge1.ShowNumberString();
        NumberPadLarge1.NumberString = "";

    }

    private void ActivateExpDatePanel()
    {
        ResetPanels();
        ReturnPanelActive = PanelActive.ExpDatePanel;
        lblAcctNum.BackColor = c6;
        lblAcctNum.ForeColor = c3;


        NumberPadLarge1.DecimalUsed = false;
        NumberPadLarge1.NumberString = "Enter Exp Date ";
        NumberPadLarge1.ShowNumberString();
        NumberPadLarge1.NumberString = "";

    }

    private void ActiveReturnAmountPanel()
    {
        ResetPanels();
        ReturnPanelActive = PanelActive.ReturnAmountPanel;
        lblReturnAmount.BackColor = c6;
        lblReturnAmount.ForeColor = c3;

        NumberPadLarge1.DecimalUsed = true;
        NumberPadLarge1.NumberString = returnAmount;


    }

    private void ActivateInvoiceNumPanel()
    {
        ResetPanels();
        ReturnPanelActive = PanelActive.InvoicePanel;
        lblInvoiceNum.BackColor = c6;
        lblInvoiceNum.ForeColor = c3;

        NumberPadLarge1.DecimalUsed = false;
        NumberPadLarge1.NumberString = returnInvoiceNumber;
        NumberPadLarge1.ShowNumberString();
        NumberPadLarge1.NumberString = "";

    }


    private void NewCardRead(ref DataSet_Builder.Payment newPayment)
    {

        returnPayment = newPayment;

        returnTrack2 = newPayment.Track2;
        lblAcctNumDetail.Text = newPayment.AccountNumber;
        lblExpDateDetail.Text = newPayment.ExpDate;

        GoToNextState();

    }

    private void CardRead_Failed()
    {

        Interaction.MsgBox("Card Read FAILED");
        lblAcctNum.Text = "Enter Account Number:";
        ActivateAcctNumberPanel();

    }

    private void PaymentEnterHit(object sender, EventArgs e)
    {

        switch (ReturnPanelActive)
        {
            case PanelActive.AccountPanel:
                {

                    // Dim ccID As Integer

                    returnPaymentTypeName = DetermineCreditCardName(NumberPadLarge1.NumberString);
                    if (returnPaymentTypeName.Length > 0)
                    {
                        // ccID = DetermineCreditCardID(Me.NumberPadLarge1.NumberString)
                        returnAcctNum = NumberPadLarge1.NumberString;
                        lblAcctNumDetail.Text = NumberPadLarge1.NumberString;
                        GoToNextState();

                    }

                    break;
                }

            case PanelActive.ExpDatePanel:
                {

                    if (NumberPadLarge1.NumberString.Length == 4)
                    {
                        returnExpDate = NumberPadLarge1.NumberString;
                        lblExpDateDetail.Text = NumberPadLarge1.NumberString;
                        GoToNextState();
                    }

                    else
                    {
                        Interaction.MsgBox("Expiration Date Must be in MMYY Format");
                        NumberPadLarge1.NumberString = "Enter Exp Date ";
                        NumberPadLarge1.ShowNumberString();
                        NumberPadLarge1.NumberString = "";
                    }

                    break;
                }


            case PanelActive.ReturnAmountPanel:
                {

                    lblReturnAmountDetail.Text = "$  " + Strings.Format(NumberPadLarge1.NumberTotal, "##,###.00");
                    returnAmount = NumberPadLarge1.NumberTotal;
                    GoToNextState();
                    break;
                }

            case PanelActive.InvoicePanel:
                {

                    returnInvoiceNumber = NumberPadLarge1.NumberString;
                    lblInvoiceNumDetail.Text = NumberPadLarge1.NumberString;
                    GoToNextState();
                    break;
                }

        }

    }

    private void GoToNextState()
    {

        if (string.IsNullOrEmpty(returnTrack2))
        {

            if (string.IsNullOrEmpty(returnAcctNum))
            {
                ActivateAcctNumberPanel();
                return;
            }
            else if (string.IsNullOrEmpty(returnExpDate))
            {
                ActivateExpDatePanel();
                return;
            }
        }

        else if (returnAmount == 0m)
        {

            ActiveReturnAmountPanel();
            return;
        }


        else if (returnInvoiceNumber == default)
        {
            ActivateInvoiceNumPanel();
            // when it passes all above it 
            // isReadyForReturn = True    we don't need invoice#

        }

        isReadyForReturn = true;


    }


    private void ButtonCancel_Click(object sender, EventArgs e)
    {
        // readAuth.tmrCardRead.Dispose()
        // readAuth.tmrCardRead = Nothing
        currentTable = (object)null;
        returnPayment = (object)null;
        tmrCardRead.Stop();
        tmrCardRead.Tick -= readAuth.tmrCardRead_Tick;
        this.Dispose();

    }

    private void btnReturn_Click(object sender, EventArgs e)
    {

        Interaction.MsgBox("Your restaurant is not setup for Credit Card Return.");
        return;



        if (isReadyForReturn == false)
        {
            GoToNextState();
            return;
        }

        StartTransaction();

    }


    public void StartTransaction()
    {

        mpsTStream = new TStream();
        mpsTransaction = new PreAuthTransactionClass();
        mpsAmount = new PreAuthAmountClass();
        mpsAccount = new AccountClass();

        // creates new experience number
        // this will never show up anywhere, we just need it to define the return in PaymentsAndCredits
        DataRow tabRow = dsOrder.Tables("AvailTabs").NewRow;

        PerformNewExperienceAdd(tabRow, default, actingManager.EmployeeID, default, -999, "Return", 1, 1, -777, 0, currentServer.LoginTrackingID);
        // -999  to indicate is a tab
        // -777 to indicate is a return
        tabRow("ClosedSubTotal") = -1 * returnAmount;
        dsOrder.Tables("AvailTabs").Rows.Add(tabRow);
        tabRow("Reference") = returnInvoiceNumber;
        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlAvailTabsSP.Update(dsOrder, "AvailTabs");
            sql.cn.Close();
        }

        catch (Exception ex)
        {
            CloseConnection();
            if (mainServerConnected == false)
            {
            }
            else
            {
                ServerJustWentDown();
            }
        }
        finally
        {

        }

        // this so we can populate PaymentRow
        currentTable.ExperienceNumber = tabRow("ExperienceNumber");
        currentTable.EmployeeID = actingManager.EmployeeID;
        currentTable.CheckNumber = 1;

        if (returnPayment.PaymentTypeName == default)
        {
            returnPayment.PaymentTypeName = DetermineCreditCardName(returnAcctNum);
        }

        // other payments defined in ReadAuth or when entered from NumberPad
        {
            ref var withBlock = ref returnPayment;
            withBlock.PaymentTypeID = DetermineCreditCardID(returnPayment.PaymentTypeName);
            withBlock.Purchase = -1 * returnAmount;
            withBlock.TranType = "Credit";
            withBlock.TranCode = "Return";
            withBlock.RefNo = returnInvoiceNumber;

            if (withBlock.Swiped == false)
            {
                withBlock.AccountNumber = returnAcctNum;
                withBlock.ExpDate = returnExpDate;
            }
            returnPayment.Track2 = (object)null;
        }

        GenerateOrderTables.AddPaymentToDataRow(returnPayment, true, currentTable.ExperienceNumber, actingManager.EmployeeID, currentTable.CheckNumber, false);
        GenerateOrderTables.UpdatePaymentsAndCredits();
        tmrCardRead.Stop();
        tmrCardRead.Tick -= readAuth.tmrCardRead_Tick;
        // 

        Interaction.MsgBox("Return went through. Receipt does not print for Credit Return. Give customer a handwritten receipt.");

        // Dim prt As New PrintHelper
        // prt.closeDetail.isCashTendered = True
        // prt.closeDetail.chkTendered = reducePaymentAmount
        // prt.closeDetail.chkChangeDue = reducePaymentAmount - RemainingBalance
        // prt.StartPrintCheckReceipt()
        // MsgBox("Printer Not Conected")
        this.Dispose();
        return;
        // *****************
        // for testing only
        // we do not send to Mercury until close of day

        {
            ref var withBlock1 = ref returnPayment;
            if (withBlock1.Swiped == false)
            {
                mpsAccount.AcctNo = withBlock1.AccountNumber;
                mpsAccount.ExpDate = withBlock1.ExpDate;
            }
            else
            {
                mpsAccount.Track2 = withBlock1.Track2;
            }

            mpsAmount.Purchase = withBlock1.Purchase;  // Me.returnAmount

            mpsTransaction.MerchantID = companyInfo.merchantID;
            mpsTransaction.OperatorID = companyInfo.operatorID;
            mpsTransaction.TranType = withBlock1.TranType;
            mpsTransaction.TranCode = withBlock1.TranCode;
            mpsTransaction.InvoiceNo = withBlock1.RefNo;
            mpsTransaction.RefNo = withBlock1.RefNo;
        }

        // *****************
        // for testing only
        mpsAccount.AcctNo = "5499990123456781";
        mpsAccount.ExpDate = "0809";
        mpsAccount.Track2 = (object)null;
        // end testing
        // *****************


        mpsTransaction.Account = mpsAccount;
        mpsTransaction.Amount = mpsAmount;

        mpsTStream.Transaction = mpsTransaction;


        var output = new StringWriter(new StringBuilder());
        var s = new XmlSerializer(typeof(TStream));
        s.Serialize(output, mpsTStream);

        StartReturn(ref output.ToString(), ref returnPayment);

    }

    private void StartReturn(ref string XMLString, ref DataSet_Builder.Payment returnPayment)
    {

        string resp;
        string authStatus;

        dsi.ServerIPConfig("x1.mercurypay.com;x2.mercurypay.com;b1.backuppay.com;b2.backuppay.com", 0);
        resp = dsi.ProcessTransaction(XMLString, 0, "", "");


        // sWriter1 = New StreamWriter("c:\Data Files\spiderPOS\Return.txt")
        // sWriter1.Write(resp)
        // sWriter1.Close()
        // MsgBox(resp)

        // *** not sure what we get as a response
        // Approved ... Success    ???
        authStatus = Conversions.ToString(ParseXMLResponse(resp, ref returnPayment));



        if (authStatus == "Approved")     // maybe Success
        {
            GenerateOrderTables.AddPaymentToDataRow(returnPayment, true, currentTable.ExperienceNumber, actingManager.EmployeeID, currentTable.CheckNumber, false);
            GenerateOrderTables.UpdatePaymentsAndCredits();
            tmrCardRead.Stop();
            tmrCardRead.Tick -= readAuth.tmrCardRead_Tick;

            this.Dispose();

        }

    }

    private object ParseXMLResponse(string resp, ref DataSet_Builder.Payment returnPayment)
    {

        var reader = new XmlTextReader(new StringReader(resp));
        var someError = default(bool);
        var isPreAuth = default(bool);
        var isReturn = default(bool);
        var isApproved = default(bool);
        var authStatus = default(string);

        try
        {
            while (reader.EOF != true)
            {
                reader.Read();
                reader.MoveToContent();
                if (reader.NodeType == XmlNodeType.Element)
                {
                    // MsgBox(reader.Name)
                    switch (reader.Name ?? "")
                    {

                        case "DSIXReturnCode":
                            {
                                if (string.Compare(reader.ReadInnerXml(), "000000", true) != 0)
                                {
                                    // false, do not honor case (is not case sensitive)
                                    // a zero means the same (therefore this is not the same)
                                    // there is sometype of error
                                    someError = true;


                                }

                                break;
                            }
                        // MsgBox(reader.ReadInnerXml, , "OperatorID")
                        case "CmdStatus":
                            {
                                switch (reader.ReadInnerXml() ?? "")
                                {
                                    case "Approved":
                                        {
                                            // isApproved = True
                                            // authStatus = "Approved"

                                            Interaction.MsgBox(reader.ReadInnerXml());
                                            break;
                                        }

                                    case "Declined":
                                        {
                                            Interaction.MsgBox(reader.ReadInnerXml());
                                            break;
                                        }

                                    case "Success":
                                        {
                                            isApproved = true;
                                            authStatus = "Approved";
                                            Interaction.MsgBox(reader.ReadInnerXml());
                                            break;
                                        }

                                    case "Error":
                                        {
                                            Interaction.MsgBox(reader.ReadInnerXml());
                                            break;
                                        }

                                }

                                break;
                            }

                        case "TextResponse":
                            {
                                if (someError == true)
                                {
                                    Interaction.MsgBox(reader.ReadInnerXml());
                                    return default;
                                }
                                else
                                {

                                }

                                break;
                            }

                        case "UserTraceData":
                            {
                                break;
                            }

                        // **************************************
                        // Transaction Response
                        // **************************************

                        case "TranCode":
                            {
                                if (string.Compare(reader.ReadInnerXml(), "PreAuth", true) == 0)
                                {
                                    isPreAuth = true;
                                }
                                else if (string.Compare(reader.ReadInnerXml(), "Return", true) == 0)
                                {
                                    isReturn = true;
                                }

                                break;
                            }

                        case "RefNo":
                            {
                                if (isPreAuth == true & isApproved == true)
                                {
                                    // *** ? place RefNo in database
                                    // vrow("RefNo") = reader.ReadInnerXml

                                }

                                break;
                            }

                        case "AuthCode":
                            {
                                // If isPreAuth = True And isApproved = True Then
                                // '   place authcode in database
                                // vrow("AuthCode") = reader.ReadInnerXml
                                // End If
                                if (isReturn == true & isApproved == true)
                                {
                                    returnPayment.AuthCode = reader.ReadInnerXml();   // *** not sure if we get response
                                    Interaction.MsgBox(reader.ReadInnerXml());
                                }

                                break;
                            }

                        case "AcqRefData":
                            {
                                // If isPreAuth = True And isApproved = True Then
                                // '   place acqRefData in database
                                // vrow("AcqRefData") = reader.ReadInnerXml
                                // End If
                                if (isReturn == true & isApproved == true)
                                {
                                    returnPayment.AcqRefData = reader.ReadInnerXml();   // *** not sure if we get response
                                }

                                break;
                            }

                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            if (reader is not null)
            {
                reader.Close();
            }

        }

        return authStatus;

    }



    private void PrintReturnReceipt()
    {

        // ***


    }

    private void lblInvoiceNum_Click(object sender, EventArgs e)
    {
        ActivateInvoiceNumPanel();

    }

    private void lblReturnAmount_Click(object sender, EventArgs e)
    {
        ActiveReturnAmountPanel();

    }

    private void lblAcctNum_Click(object sender, EventArgs e)
    {
        if (returnPayment.Swiped == false)
        {
            ActivateAcctNumberPanel();
        }

    }


}