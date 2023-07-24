using System;
using System.Drawing;
using System.IO;
using System.Linq;
using DataSet_Builder;




public partial class PrinterHelperMgr
{
    // Left       0
    // Right      2
    // Center     6

    private float yPos = 80f;
    private float leftMargin = 0f;    // ev.MarginBounds.Left
    private int count;
    private int lastHeight;
    private DataRowView vRow;
    private int midWidth = 250;
    private int pageWidth = 500;

    private FontInfo pInfoA11 = new FontInfo("FontA11", 9.5d, 1);
    private FontInfo pInfoA12 = new FontInfo("FontA12", 16, 1); // ("FontA12", 19, 1)
    private FontInfo pInfoA21 = new FontInfo("FontA21", 9.5d, 1);

    private FontInfo pInfoB12 = new FontInfo("FontB12", 13.5d, 1);
    private FontInfo pInfoB21 = new FontInfo("FontB21", 7, 1);
    private FontInfo pInfoB22 = new FontInfo("FontB22", 13.5d, 1);
    private FontInfo pInfoB24 = new FontInfo("FontB24", 27, 1);

    // Dim sql As New DataSet_Builder.SQLHelper(connectserver)
    private DataView dvOrderByPrinter;

    private Font printFont;
    private StreamWriter StreamToFile;
    private StreamReader streamToPrint;

    private StreamWriter closeCheckWriter1;
    private StreamWriter clockoutWriter1;

    private StreamWriter sWriter1;
    private StreamWriter sWriter2;
    private StreamWriter sWriter3;
    private StreamWriter sWriter4;
    private StreamWriter sWriter5;

    private bool allCourse1;
    private int lastCourseNumber = 0;
    private string currentRoutingName;
    private bool isReprinting;

    private bool s1;
    private bool s2;
    private bool s3;
    private bool s4;
    private bool s5;

    internal OrderDetailInfo oDetail;
    internal CloseDetailInfo closeDetail;
    internal bool useVIEW;
    private DataRow _ccDataRow;
    private DataRowView _ccDataRowView;
    private ClockOutInfo _clockOutJunk;

    internal DataRow ccDataRow
    {
        get
        {
            return _ccDataRow;
        }
        set
        {
            _ccDataRow = value;
        }
    }

    internal DataRowView ccDataRowView
    {
        get
        {
            return _ccDataRowView;
        }
        set
        {
            _ccDataRowView = value;
        }
    }

    internal ClockOutInfo ClockOutJunk
    {
        get
        {
            return _clockOutJunk;
        }
        set
        {
            _clockOutJunk = value;
        }
    }

    internal void SendingOrder(long reprint)  // (ByRef oDetail As OrderDetailInfo)
    {
        int countCourse1;
        int countTotalSending;
        var pd = new PrintDocument();

        if (dsOrder.Tables("OpenOrders").Rows.Count > 0)
        {
            countCourse1 = dsOrder.Tables("OpenOrders").Compute("Count(CourseNumber)", "CourseNumber = 2 AND ItemStatus = 0"); // (FunctionFlag = 'F' or FunctionFlag = 'M')")
            countTotalSending = dsOrder.Tables("OpenOrders").Compute("Count(ItemStatus)", "ItemStatus = 0");
        }
        else
        {
            countCourse1 = 0;
            countTotalSending = 0;
        }

        if (countCourse1 == countTotalSending)
        {
            allCourse1 = true;
        }

        if (companyInfo.isKitchenExpiditer == true)
        {
            // send order from dvOrderPrint
            // must determine if sent to kitchen group
        }

        foreach (DataRow oRow in ds.Tables("RoutingChoice").Rows)
        {
            if (!(oRow("RoutingName") == "Do Not Route"))
            {
                currentRoutingName = oRow("RoutingName");
                dvOrderByPrinter = new DataView();
                {
                    ref var withBlock = ref dvOrderByPrinter;
                    withBlock.Table = dsOrder.Tables("OpenOrders");
                    if (reprint == default | reprint == 0L)
                    {
                        withBlock.RowFilter = "RoutingID = " + oRow("RoutingID") + " AND ItemStatus = 0";
                    }
                    else
                    {
                        withBlock.RowFilter = "RoutingID = " + oRow("RoutingID") + " AND OrderNumber = " + reprint;
                        isReprinting = true;
                    }
                    withBlock.Sort = "CourseNumber, CustomerNumber, sii, si2, sin";
                }

                try
                {
                    if (dvOrderByPrinter.Count > 0)
                    {
                        pd.PrintController = new StandardPrintController();
                        pd.PrintPage += pd_PrintPageEPSONFix;
                        // AddHandler pd.PrintPage, AddressOf CreateTicketHeader
                        pd.PrinterSettings.PrinterName = currentRoutingName; // oRow("RoutingName")

                        // pd.PrinterSettings.PrinterName = "Receipt" & currentTerminal.TermID                        '*** need to remove
                        // pd.PrinterSettings.PrinterName = "Kitchen"                  '*** need to remove
                        // pd.PrinterSettings.PrinterName = "HP 722 local"
                        pd.Print();
                    }
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox(ex.Message);
                    Interaction.MsgBox("Printer " + pd.PrinterSettings.PrinterName + " is not connected");
                }
            }
        }

    }

    private void pd_PrintPageEPSONFix(object sender, PrintPageEventArgs ev)
    {

        // page width is 500
        leftMargin = 0f;
        count = 0;
        yPos = 80f;
        var quantityCount = default(int);

        // ticket Header
        if (isReprinting == false)
        {
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 200, yPos, 0, pInfoB24, "Reprint"));
        }
        else
        {
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 200, yPos, 0, pInfoB24, currentTable.MethodUse));
        }
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, leftMargin, yPos, 0, pInfoA12, currentRoutingName));
        yPos += 60 + lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, leftMargin, yPos, 0, pInfoA12, "*******************************"));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 500, yPos, 2, pInfoA12, Strings.Format(DateTime.Now, "hh:mm tt")));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, leftMargin, yPos, 0, pInfoA12, "Table: " + currentTable.TabName));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, leftMargin, yPos, 0, pInfoA12, "Guests: " + currentTable.NumberOfCustomers));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, leftMargin, yPos, 0, pInfoA12, "Order: " + oDetail.trunkOrderNumber));
        yPos += 40 + lastHeight;

        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA12, "-------------------------------"));
        yPos += 20 + lastHeight;

        var lastCourseNumber = default(int);
        bool firstCustomer = false;

        foreach (DataRowView currentVRow in dvOrderByPrinter)
        {
            vRow = currentVRow;
            if (allCourse1 == false)
            {
                if (this.vRow("CourseNumber") != lastCourseNumber)
                {
                    firstCustomer = true;
                    lastCourseNumber = this.vRow("CourseNumber");
                    yPos += 40f;
                    lastHeight = Conversions.ToInteger(DoPrinting(ev, 200, yPos, 2, pInfoB24, "Course    " + this.vRow("CourseNumber")));
                    yPos += lastHeight;
                    lastHeight = Conversions.ToInteger(DoPrinting(ev, 200, yPos, 2, pInfoA12, "*****************"));
                    yPos += 2 * lastHeight;
                }
            }

            if (this.vRow("FunctionFlag") == "F" | this.vRow("FunctionFlag") == "O" | this.vRow("FunctionFlag") == "M" | this.vRow("FunctionFlag") == "D")
            {
                while (quantityCount < this.vRow("Quantity"))
                {
                    if (this.vRow("sin") == this.vRow("sii"))
                    {

                        if (firstCustomer == false)
                        {
                            // lastHeight = DoPrinting(ev, 0, yPos, 0, pInfoA12, "-------------------------------")
                            // just giving space
                            yPos = (float)(yPos + lastHeight * 0.75d);
                        }
                        else
                        {
                            firstCustomer = false;
                        }
                        if (this.vRow("Quantity") > 9)
                        {
                            lastHeight = Conversions.ToInteger(DoPrinting(ev, 10, yPos, 0, pInfoB24, "Quantity:    " + this.vRow("Quantity")));
                            yPos += lastHeight;
                            lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA12, "C" + this.vRow("CustomerNumber")));
                            lastHeight = Conversions.ToInteger(DoPrinting(ev, 50, yPos, 0, pInfoA12, this.vRow("ChitName")));             // need price too
                            yPos += lastHeight;     // 100 + (count * nHeight)
                            break;
                        }

                        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA12, "C" + this.vRow("CustomerNumber")));
                    }
                    lastHeight = Conversions.ToInteger(DoPrinting(ev, 50, yPos, 0, pInfoA12, this.vRow("ChitName")));             // need price too
                    yPos += lastHeight;     // 100 + (count * nHeight)
                    quantityCount += 1;
                }
                quantityCount = 0;
            }
            // MsgBox(ev.MarginBounds.ToString, , "Margin Bounds")
            // MsgBox(ev.PageBounds.ToString, , "Page Bounds")
            // MsgBox(ev.PageBounds.Width.ToString, , "Page Bounds Width")
            // MsgBox(ev.PageSettings.PaperSize.Width.ToString, , "Paper Width")
            // count += 1
        }

        // space on bottom
        yPos += 20 + lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA12, "-------------------------------"));
        lastHeight += 50;
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 50, yPos, 0, pInfoA12, "    "));


    }

    private object DoPrinting(Global.System.Drawing.Printing.PrintPageEventArgs ev, int nXPosition, int yPos, int tAlign, FontInfo pInfo, string pText)
    {
        var hdc = new IntPtr();
        var font = new IntPtr();

        hdc = ev.Graphics.GetHdc();


        int nHeight;
        nHeight = pInfo.nFontSize * UsingGDI.GetDeviceCaps(hdc, 90) / 72;

        font = UsingGDI.CreateFont(nHeight, 0, 0, 0, 400, 0, 0, 0, pInfo.nCharSet, 0, 0, 0, 0, pInfo.sFontName);

        // nXPosition = (ev.PageBounds.Width)
        UsingGDI.SetTextAlign(hdc, tAlign);

        UsingGDI.SelectObject(hdc, font);
        UsingGDI.TextOut(hdc, nXPosition, yPos, pText, pText.Length);
        // we can truncate line by changing the pText.Length value
        ev.Graphics.ReleaseHdc(hdc);

        return nHeight;

    }

    private object DoPrinting2(Global.System.Drawing.Printing.PrintPageEventArgs ev, int nXPosition, int yPos, FontInfo pInfo, string pText)
    {

        int nHeight;
        Graphics g;
        g = ev.Graphics;
        var f = new Font("FontA11", 9.5d);
        var sf = new StringFormat();
        var r = new Rectangle(10, 10, 80, 80);
        sf.Alignment = StringAlignment.Center;
        nHeight = f.Height;

        g.DrawString(pText, f, Brushes.Black, nXPosition, yPos, sf);

        return nHeight;

    }

    internal void StartPrintCreditCardRest()
    {

        yPos = 80f;
        var pd = new PrintDocument();
        pd.PrintController = new StandardPrintController();
        pd.PrintPage += pd_PrintPageCreditCardRest;

        // pd.PrinterSettings.PrinterName = "Receipt"
        pd.PrinterSettings.PrinterName = currentTerminal.ReceiptName; // "Receipt" & currentTerminal.TermID
        pd.Print();

    }

    internal void StartPrintCreditCardGuest()
    {

        yPos = 80f;
        var pd = new PrintDocument();
        pd.PrintController = new StandardPrintController();
        pd.PrintPage += pd_PrintPageCreditCardGuest;

        // pd.PrinterSettings.PrinterName = "Receipt"
        pd.PrinterSettings.PrinterName = currentTerminal.ReceiptName;     // "Receipt" & currentTerminal.TermID
        pd.Print();

    }

    private void pd_PrintPageCreditCardRest(object sender, PrintPageEventArgs ev)
    {
        string invNumber;

        // DetermineTruncatedExperienceNumber()
        // yPos = CreateCheckHeader(ev)

        if (useVIEW == true)
        {
            invNumber = ccDataRowView("RefNum");
            yPos = Conversions.ToSingle(CreateCheckHeader(ev, invNumber));
            FillCreditCardDetailView(ev, yPos, true);
        }
        else
        {
            invNumber = ccDataRow("RefNum");
            yPos = Conversions.ToSingle(CreateCheckHeader(ev, invNumber));
            FillCreditCardDetail(ev, yPos, true);
        }    // true is restaurant copy

    }

    private void pd_PrintPageCreditCardGuest(object sender, PrintPageEventArgs ev)
    {
        string invNumber;

        // DetermineTruncatedExperienceNumber()
        // yPos = CreateCheckHeader(ev)

        if (useVIEW == true)
        {
            invNumber = ccDataRowView("RefNum");
            yPos = Conversions.ToSingle(CreateCheckHeader(ev, invNumber));
            FillCreditCardDetailView(ev, yPos, false);
        }
        else
        {
            invNumber = ccDataRow("RefNum");
            yPos = Conversions.ToSingle(CreateCheckHeader(ev, invNumber));
            FillCreditCardDetail(ev, yPos, false);
        }

    }

    private object FillCreditCardDetail(Global.System.Drawing.Printing.PrintPageEventArgs ev, float yPos, bool isRestCopy) // ByVal copyString As String)
    {

        float leftMargin = 0f;
        int count;
        int lastHeight;
        DataRowView vRow;
        var pInfo2 = new FontInfo("FontB12", 13.5d, 1); // ("FontA11", 9.5, 1) '("FontB48", 15, 1) '("FontB42", 13.5, 1)
        var pInfo = new FontInfo("FontA11", 9.5d, 1);
        var pInfo3 = new FontInfo("FontB21", 7, 1);
        int pageWidth;
        int midWidth;
        decimal runingPaymentTotal;
        string ccName;

        pageWidth = 500;
        midWidth = 250;

        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, ccDataRow("PaymentTypeName")));
        lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(currentTable.SatTime, "M/d/yyyy")));
        // using sat time b/c if we reprint this ticket another day we want to date it by open time
        yPos += lastHeight;

        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Card # " + TruncateAccountNumber(ccDataRow("AccountNumber"))));
        if (isRestCopy == true)
        {
            // lastHeight = DoPrinting(ev, 0, yPos, 0, pInfoA11, "Card # " & ccDataRow("AccountNumber"))
            lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, "Exp:" + ccDataRow("CCExpiration")));
        }


        yPos += lastHeight;
        if (ccDataRow("CustomerName") is not null)
        {
            ccName = ccDataRow("CustomerName");
        }
        else
        {
            ccName = "-none-";
        }
        if (ccDataRow("SwipeType") == 1)
        {
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Magnetic card present: " + ccName));
        }
        else
        {
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "No card present: " + ccName));
        }

        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Approval: " + ccDataRow("AuthCode")));
        yPos += 60 + lastHeight;



        lastHeight = Conversions.ToInteger(DoPrinting(ev, 350, yPos, 2, pInfoA11, "Amount:"));
        lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(ccDataRow("PaymentAmount"), "##,###.00")));


        if (ccDataRow("Surcharge") > 0)
        {
            yPos += lastHeight + 15;
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 350, yPos, 2, pInfoA11, "Auto Gratuity (" + Strings.Format(companyInfo.autoGratuityPercent, "### %") + ")"));
            lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(ccDataRow("Surcharge"), "##,###.00")));
        }

        if (ccDataRow("BatchCleared") == true | ccDataRow("Tip") > 0)    // Is Nothing
        {
            yPos += lastHeight + 15;
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 350, yPos, 2, pInfoA11, "   + Tip:"));
            lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(ccDataRow("Tip"), "##,###.00")));
            yPos += lastHeight + 15;
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 350, yPos, 2, pInfoA11, " = Total:"));
            lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(ccDataRow("PaymentAmount") + ccDataRow("Tip") + ccDataRow("Surcharge"), "##,###.00")));
        }
        else
        {
            yPos += lastHeight + 40;
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 350, yPos, 2, pInfoA11, "   + Tip:"));
            lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, "____________"));
            yPos += lastHeight + 40;
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 350, yPos, 2, pInfoA11, " = Total:"));
            lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, "____________"));
        }


        yPos += 60 + lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "X________________________________________"));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Approval: " + ccDataRow("AuthCode")));
        if (isRestCopy == true)
        {
            yPos += 30 + lastHeight;
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "    I agree to pay above total amount"));
            yPos += lastHeight;
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "    according to card issuer agreement."));
        }
        yPos += 100 + lastHeight;

        lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 6, pInfoB21, "Thank You"));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 6, pInfoB21, "Please Come Again"));
        yPos += 40 + lastHeight;

        // If Not companyInfo.receiptMessage1 Is Nothing Then
        // lastHeight = DoPrinting(ev, midWidth, yPos, 6, pinfoB21, companyInfo.receiptMessage1)
        // yPos += (40 + lastHeight)
        // End If
        // If Not companyInfo.receiptMessage2 Is Nothing Then
        // '      lastHeight = DoPrinting(ev, midWidth, yPos, 6, pinfoB21, companyInfo.receiptMessage2)
        // yPos += (40 + lastHeight)
        // End If
        // If Not companyInfo.receiptMessage3 Is Nothing Then
        // lastHeight = DoPrinting(ev, midWidth, yPos, 6, pinfoB21, companyInfo.receiptMessage3)
        // '     yPos += (40 + lastHeight)
        // End If

        if (isRestCopy == true)
        {
            lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 6, pInfoB21, "*****Restaurant's Copy*****"));
        }
        else
        {
            lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 6, pInfoB21, "*****Guest's Copy*****"));
        }

        return default;

    }


    private object FillCreditCardDetailView(Global.System.Drawing.Printing.PrintPageEventArgs ev, float yPos, bool isRestCopy) // ByVal copyString As String)
    {

        float leftMargin = 0f;
        int count;
        int lastHeight;
        DataRowView vRow;
        var pInfo2 = new FontInfo("FontB12", 13.5d, 1); // ("FontA11", 9.5, 1) '("FontB48", 15, 1) '("FontB42", 13.5, 1)
        var pInfo = new FontInfo("FontA11", 9.5d, 1);
        var pInfo3 = new FontInfo("FontB21", 7, 1);
        int pageWidth;
        int midWidth;
        decimal runingPaymentTotal;
        string ccName;

        pageWidth = 500;
        midWidth = 250;

        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, ccDataRowView("PaymentTypeName")));
        lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(currentTable.SatTime, "M/d/yyyy")));
        // using sat time b/c if we reprint this ticket another day we want to date it by open time
        yPos += lastHeight;

        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Card # " + TruncateAccountNumber(ccDataRowView("AccountNumber"))));
        if (isRestCopy == true)
        {
            // lastHeight = DoPrinting(ev, 0, yPos, 0, pInfoA11, "Card # " & ccDataRowView("AccountNumber"))
            lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, "Exp:" + ccDataRowView("CCExpiration")));
        }

        yPos += lastHeight;
        if (ccDataRowView("CustomerName") is not null)
        {
            ccName = ccDataRowView("CustomerName");
        }
        else
        {
            ccName = "-none-";
        }
        if (ccDataRowView("SwipeType") == 1)
        {
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Magnetic card present: " + ccName));
        }
        else
        {
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "No card present: " + ccName));
        }

        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Approval: " + ccDataRowView("AuthCode")));
        yPos += 60 + lastHeight;



        lastHeight = Conversions.ToInteger(DoPrinting(ev, 350, yPos, 2, pInfoA11, "Amount:"));
        lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(ccDataRowView("PaymentAmount"), "##,###.00")));


        if (ccDataRowView("Surcharge") > 0)
        {
            yPos += lastHeight + 15;
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 350, yPos, 2, pInfoA11, "Auto Gratuity (" + Strings.Format(companyInfo.autoGratuityPercent, "### %") + ")"));
            lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(ccDataRowView("Surcharge"), "##,###.00")));
        }

        if (ccDataRowView("BatchCleared") == true | ccDataRowView("Tip") > 0)    // Is Nothing
        {
            yPos += lastHeight + 15;
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 350, yPos, 2, pInfoA11, "   + Tip:"));
            lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(ccDataRowView("Tip"), "##,###.00")));
            yPos += lastHeight + 15;
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 350, yPos, 2, pInfoA11, " = Total:"));
            lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(ccDataRowView("PaymentAmount") + ccDataRowView("Tip") + ccDataRow("Surcharge"), "##,###.00")));
        }
        else
        {
            yPos += lastHeight + 40;
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 350, yPos, 2, pInfoA11, "   + Tip:"));
            lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, "____________"));
            yPos += lastHeight + 40;
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 350, yPos, 2, pInfoA11, " = Total:"));
            lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, "____________"));
        }


        yPos += 60 + lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "X________________________________________"));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Approval: " + ccDataRowView("AuthCode")));
        if (isRestCopy == true)
        {
            yPos += 30 + lastHeight;
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "    I agree to pay above total amount"));
            yPos += lastHeight;
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "    according to card issuer agreement."));
        }
        yPos += 100 + lastHeight;

        lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 6, pInfoB21, "Thank You"));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 6, pInfoB21, "Please Come Again"));
        yPos += 40 + lastHeight;

        // If Not companyInfo.receiptMessage1 Is Nothing Then
        // lastHeight = DoPrinting(ev, midWidth, yPos, 6, pinfoB21, companyInfo.receiptMessage1)
        // yPos += (40 + lastHeight)
        // End If
        // If Not companyInfo.receiptMessage2 Is Nothing Then
        // '      lastHeight = DoPrinting(ev, midWidth, yPos, 6, pinfoB21, companyInfo.receiptMessage2)
        // yPos += (40 + lastHeight)
        // End If
        // If Not companyInfo.receiptMessage3 Is Nothing Then
        // lastHeight = DoPrinting(ev, midWidth, yPos, 6, pinfoB21, companyInfo.receiptMessage3)
        // '     yPos += (40 + lastHeight)
        // End If

        if (isRestCopy == true)
        {
            lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 6, pInfoB21, "*****Restaurant's Copy*****"));
        }
        else
        {
            lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 6, pInfoB21, "*****Guest's Copy*****"));
        }

        return default;

    }


    private object CreateCreditCardHeader222(Global.System.Drawing.Printing.PrintPageEventArgs ev)
    {
        return default;

    }

    internal void StartPrintCheckReceipt() // ByRef dvClosing As DataView, ByVal chkSubTotal As Decimal, ByVal checkTax As Decimal)
    {

        var pd = new PrintDocument();

        try
        {
            pd.PrintController = new StandardPrintController();
            pd.PrintPage += pd_PrintPageCloseCheck;
            pd.PrinterSettings.PrinterName = currentTerminal.ReceiptName;     // "Receipt" & currentTerminal.TermID     '  number by terminal
            pd.Print();
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Printer " + pd.PrinterSettings.PrinterName + " is not connected");

        }

    }

    private void pd_PrintPageCloseCheck(object sender, PrintPageEventArgs ev)
    {
        leftMargin = 0f;
        count = 0;
        yPos = 80f;
        string invNumber;

        invNumber = DetermineTruncatedExperienceNumberFunction(dvOrder[0]("ExperienceNumber"));

        yPos = Conversions.ToSingle(CreateCheckHeader(ev, invNumber));

        FillCheckDetail(ev, yPos, ref closeDetail.dvClosing, closeDetail.chkSubTotal, closeDetail.chktaxTotal, closeDetail.chktaxName);

        // if..then.... FillCheckPayemtns

    }

    private object CreateCheckHeader(Global.System.Drawing.Printing.PrintPageEventArgs ev, string invoiceNumber)
    {

        if (companyInfo.companyName is not null)
        {
            lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 6, pInfoB22, companyInfo.companyName));
            yPos += lastHeight;
        }
        if (companyInfo.address1 is not null)
        {
            lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 6, pInfoA11, companyInfo.address1));
            yPos += lastHeight;
        }
        // lastHeight = DoPrinting(ev, midWidth, yPos, 6, pinfoA11, companyInfo.address2)
        // yPos += (lastHeight)
        if (companyInfo.locationCity != default | companyInfo.locationState != default)
        {
            lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 6, pInfoA11, companyInfo.locationCity + ",  " + companyInfo.locationState));
            yPos += lastHeight;
        }
        if (companyInfo.locationPhone is not null)
        {
            lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 6, pInfoA11, companyInfo.locationPhone));
            yPos += lastHeight;
        }
        yPos += 60;

        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Server: " + currentServer.NickName));
        lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(currentTable.SatTime, "M/d/yyyy")));
        // using sat time b/c if we reprint this ticket another day we want to date it by open time
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Table: " + currentTable.TabName));
        lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(currentTable.SatTime, "h:mm tt")));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Check: " + currentTable.CheckNumber + " of " + currentTable.NumberOfChecks));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Guests: " + currentTable.NumberOfCustomers));
        if (string.IsNullOrEmpty(invoiceNumber))
        {
            lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, "# " + currentTable.TruncatedExpNum));
        }
        else
        {
            lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, "# " + invoiceNumber));
        }

        yPos += 60 + lastHeight;

        return yPos;

    }

    private void FillCheckDetail(Global.System.Drawing.Printing.PrintPageEventArgs ev, float yPos, ref DataView dvClosing, decimal chkSubTotal, decimal[] checkTax, string[] checkName)
    {

        decimal runningTotal;
        int index;

        foreach (DataRowView currentVRow in dvClosing)
        {
            vRow = currentVRow;
            if (!(this.vRow("ItemID") == 0))
            {

                if (this.vRow("sin") == this.vRow("sii") & this.vRow("Quantity") > 1)
                {
                    lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, this.vRow("Quantity")));
                }

                lastHeight = Conversions.ToInteger(DoPrinting(ev, 40, yPos, 0, pInfoA11, this.vRow("ItemName")));
                if (this.vRow("sin") == this.vRow("sii") | this.vRow("Price") != 0)
                {
                    lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(this.vRow("Price"), "##,###.00")));
                }
                yPos += lastHeight;
            }
        }

        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 0, pInfoA11, "SubTotal:"));
        lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(chkSubTotal, "##,###.00")));
        yPos += lastHeight;
        runningTotal = chkSubTotal;


        lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 0, pInfoA11, checkName[0])); // )"Tax:")
        lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(checkTax[0], "##,###.00")));
        yPos += lastHeight;
        runningTotal = runningTotal + checkTax[0];

        index = 1;
        foreach (DataRow oRow in ds.Tables("Tax").Rows)
        {
            if (checkTax[index] > 0m)
            {
                lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 0, pInfoA11, checkName[index] + " Tax:"));
                lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(checkTax[index], "##,###.00")));
                yPos += lastHeight;
                runningTotal = runningTotal + checkTax[index];
            }
            index += 1;
        }

        lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 0, pInfoA11, "TOTAL:"));
        lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(runningTotal, "##,###.00")));

        if (closeDetail.isCashTendered == true)
        {
            yPos += 2 * lastHeight;
            lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 0, pInfoA11, "Tendered:"));
            lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(closeDetail.cashTendered, "##,###.00")));
            yPos += lastHeight;

            if (closeDetail.chkChangeDue >= 0)
            {
                lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 0, pInfoA11, "CHANGE:"));
            }
            else
            {
                lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 0, pInfoB21, "BALANCE DUE:"));
            }
            lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(closeDetail.chkChangeDue, "##,###.00")));

        }
        yPos += 100 + lastHeight;

        lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 6, pInfoB21, "Thank You"));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 6, pInfoB21, "Please Come Again"));
        yPos += 40 + lastHeight;

        // If Not companyInfo.receiptMessage1 Is Nothing Then
        // lastHeight = DoPrinting(ev, midWidth, yPos, 6, pinfoB21, companyInfo.receiptMessage1)
        // yPos += (40 + lastHeight)
        // End If
        // If Not companyInfo.receiptMessage2 Is Nothing Then
        // '      lastHeight = DoPrinting(ev, midWidth, yPos, 6, pinfoB21, companyInfo.receiptMessage2)
        // yPos += (40 + lastHeight)
        // End If
        // If Not companyInfo.receiptMessage3 Is Nothing Then
        // lastHeight = DoPrinting(ev, midWidth, yPos, 6, pinfoB21, companyInfo.receiptMessage3)
        // '     yPos += (40 + lastHeight)
        // End If

        lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 6, pInfoA11, "   "));

    }

    internal void StartClockOutPrint()
    {

        var pd = new PrintDocument();

        try
        {
            pd.PrintController = new StandardPrintController();
            pd.PrintPage += pd_PrintPageClockOut;
            pd.PrinterSettings.PrinterName = currentTerminal.ReceiptName;     // "Receipt"                   '  number by terminal
            pd.Print();
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Printer " + pd.PrinterSettings.PrinterName + " is not connected");
        }

    }

    private void pd_PrintPageClockOut(object sender, PrintPageEventArgs ev)
    {

        leftMargin = 0f;
        count = 0;
        yPos = 40f;

        CreateClockoutHeader(ev);
        PrintClockOut(ev);
        PrintClockOutFooter(ev);

    }


    private void CreateClockoutHeader(Global.System.Drawing.Printing.PrintPageEventArgs ev)
    {

        lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 6, pInfoB22, "EMPLOYEE CLOCK OUT"));
        yPos += lastHeight + 30;
        if (companyInfo.companyName is not null)
        {
            lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, companyInfo.companyName));
        }
        lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(DateTime.Now, "M/d/yyyy")));
        // using sat time b/c if we reprint this ticket another day we want to date it by open time
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Server: " + currentServer.FullName));
        lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, Strings.Format(DateTime.Now, "h:mm tt")));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Job: " + currentServer.JobCodeName));
        yPos += lastHeight + 30;

    }

    private void PrintClockOut(Global.System.Drawing.Printing.PrintPageEventArgs ev)
    {

        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Shift Date:"));
        lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA21, Strings.Format(ClockOutJunk.TimeIn, "M/d/yyyy")));
        // using sat time b/c if we reprint this ticket another day we want to date it by open time
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Time in: "));
        lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA21, Strings.Format(currentServer.LogInTime, "h:mm tt")));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Time out: "));
        lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA21, Strings.Format(ClockOutJunk.TimeOut, "h:mm tt")));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Hours this shift:"));
        lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA21, ClockOutJunk.ShiftHours + ":" + ClockOutJunk.ShiftMins));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Hours this week:"));
        lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA21, ClockOutJunk.WeekHours + ":" + ClockOutJunk.WeekMins));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Tipable Sales:"));
        lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA21, Strings.Format(ClockOutJunk.TipableSales, "###,###.00")));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Charge Sales:"));
        lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA21, Strings.Format(ClockOutJunk.ChargedSales, "###,###.00")));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Charge Tips:"));
        lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA21, Strings.Format(ClockOutJunk.ChargedTips, "###,###.00")));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoA11, "Declared Tips:"));
        lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA21, Strings.Format(ClockOutJunk.DeclaredTips, "###,###.00")));


    }

    private void PrintClockOutFooter(Global.System.Drawing.Printing.PrintPageEventArgs ev)
    {

        yPos += lastHeight + 30;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoB21, "**********************"));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoB21, "Verification of hours worked"));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoB21, "Keep copy for your records."));
        yPos += lastHeight + 30;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfoB21, "    "));

    }

    public void PrintOpenCashDrawer()
    {

        var pd = new PrintDocument();
        pd.PrintController = new StandardPrintController();
        // AddHandler pd.PrintPage, AddressOf pd_PrintAllAuth

        pd.PrinterSettings.PrinterName = currentTerminal.ReceiptName;     // "Receipt" & currentTerminal.TermID
        pd.Print();
    }

    public void PrintAllAuthDuringBatch()
    {
        yPos = 80f;
        var pd = new PrintDocument();
        pd.PrintController = new StandardPrintController();
        pd.PrintPage += pd_PrintAllAuth;

        // pd.PrinterSettings.PrinterName = "Receipt"
        pd.PrinterSettings.PrinterName = currentTerminal.ReceiptName;  // "Receipt" & currentTerminal.TermID
        pd.Print();

    }

    private void pd_PrintAllAuth(object sender, PrintPageEventArgs ev)
    {
        string isApproved;
        string SwipeType;
        string tempExpNum;
        string trunkExpNum;
        string tempAcctNum;
        string trunkAcctNum;


        // page width is 500
        leftMargin = 0f;
        yPos = 80f;

        lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 6, pInfoB21, "Go to www.MercuryPay.com"));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 6, pInfoB21, "(800) 846 - 4472"));
        yPos += lastHeight + 60;

        foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (object.ReferenceEquals(oRow("AuthCode"), DBNull.Value))
                {
                    isApproved = "Declined";
                }
                else
                {
                    isApproved = "Approved";
                }

                if (oRow("SwipeType") == 1)
                {
                    SwipeType = "Swiped";
                }
                else
                {
                    SwipeType = "Manual";
                }

                // tempExpNum = oRow("ExperienceNumber").ToString
                // If tempExpNum.Length > 6 Then
                // trunkExpNum = tempExpNum.Substring(tempExpNum.Length - 6, 6)
                // Else
                // trunkExpNum = tempExpNum
                // End If
                if (!(oRow("AccountNumber").Substring(0, 4) == "xxxx") & !(oRow("AccountNumber") == "Manual"))
                {
                    tempAcctNum = TruncateAccountNumber(oRow("AccountNumber"));
                }
                else
                {
                    tempAcctNum = oRow("AccountNumber");
                }

                if (tempAcctNum.Length > 6)
                {
                    trunkAcctNum = tempAcctNum.Substring(tempAcctNum.Length - 6, 6);
                }
                else
                {
                    trunkAcctNum = tempAcctNum;
                }

                lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, oRow("PaymentDate")));
                yPos += lastHeight + 3;
                lastHeight = Conversions.ToInteger(DoPrinting(ev, 100, yPos, 2, pInfoA11, oRow("TransactionCode")));
                lastHeight = Conversions.ToInteger(DoPrinting(ev, 230, yPos, 2, pInfoA11, trunkAcctNum));
                lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, SwipeType));
                yPos += lastHeight + 3;
                lastHeight = Conversions.ToInteger(DoPrinting(ev, 100, yPos, 2, pInfoA11, isApproved));
                lastHeight = Conversions.ToInteger(DoPrinting(ev, 230, yPos, 2, pInfoA11, Strings.Format(oRow("PaymentAmount") + oRow("Surcharge") + oRow("Tip"), "$###,##0.00")));
                lastHeight = Conversions.ToInteger(DoPrinting(ev, pageWidth, yPos, 2, pInfoA11, "# " + oRow("RefNum")));  // trunkExpNum)
                yPos += lastHeight + 30;
            }
        }

    }



















    // 222
    // there is some code at bottom that is needed

    private void PrintCloseCheck222()
    {

        try
        {
            streamToPrint = new StreamReader(@"c:\Data Files\spiderPOS\Receipt.txt");
            try
            {
                // Me.printFont = New Font("Times New Roman", 12)
                // Me.printFont = New Font("Microsoft Sans Serif", 12)
                printFont = new Font("FontB12", 13.5d);  // ("Arial", 11) '("FontA42", 8)  '
                var pd = new PrintDocument();
                pd.PrintController = new StandardPrintController();
                pd.PrintPage += pd_PrintPage222;                 // EPSONFix
                pd.PrinterSettings.PrinterName = "Bar";
                pd.PrinterSettings.PrinterName = "Receipt";
                // pd.PrinterSettings.PrinterName = "HP 722 local"
                pd.Print();
            }
            finally
            {
                streamToPrint.Close();
            }
        }
        catch (Exception ex)
        {
            // info = New DataSet_Builder.Information_UC(ex.Message)
            // info.Location = New Point((Me.Width - info.Width) / 2, (Me.Height - info.Height) / 2)
            // Me.Controls.Add(info)
            // info.BringToFront()
        }

    }

    internal void StartClockOutPrint222(ref ClockOutInfo clockOutJunk)
    {
        clockoutWriter1 = new StreamWriter(@"c:\Data Files\spiderPOS\ClockOut.txt");

        CreateCloseoutHeader222(ref clockOutJunk);

        clockoutWriter1.Close();
        PrintClockOut222();

    }

    private void CreateCloseoutHeader222(ref ClockOutInfo clockOutJunk)
    {

        clockoutWriter1.Write("*CN*");
        clockoutWriter1.WriteLine("EMPLOYEE CLOCK OUT");

        clockoutWriter1.WriteLine("*BL*");
        clockoutWriter1.Write("*RJ*");
        clockoutWriter1.Write(companyInfo.companyName);
        clockoutWriter1.Write("%");
        clockoutWriter1.WriteLine(Strings.Format(DateTime.Now, "M/d/yyyy"));

        clockoutWriter1.Write("*RJ*");
        clockoutWriter1.Write(currentServer.JobCodeName + ":  ");   // ("Server: ")
        clockoutWriter1.Write(currentServer.FullName);
        clockoutWriter1.Write("%");
        clockoutWriter1.WriteLine(Strings.Format(DateTime.Now, "h:mm tt"));

        clockoutWriter1.WriteLine("*BL*");
        clockoutWriter1.WriteLine("Job: " + currentServer.JobCodeName);

        clockoutWriter1.Write("*RJ*");
        clockoutWriter1.Write("Time in:");
        clockoutWriter1.Write("%");
        clockoutWriter1.WriteLine(Strings.Format(clockOutJunk.TimeIn, "h:m tt"));

        clockoutWriter1.Write("*RJ*");
        clockoutWriter1.Write("Time out:");
        clockoutWriter1.Write("%");
        clockoutWriter1.WriteLine(Strings.Format(clockOutJunk.TimeOut, "h:m tt"));

        clockoutWriter1.Write("*RJ*");
        clockoutWriter1.Write("Hours this shift:");
        clockoutWriter1.Write("%");
        clockoutWriter1.WriteLine(clockOutJunk.ShiftHours + ":" + Strings.Format(clockOutJunk.ShiftMins, "##"));

        clockoutWriter1.Write("*RJ*");
        clockoutWriter1.Write("Hours this week:");
        clockoutWriter1.Write("%");
        clockoutWriter1.WriteLine(clockOutJunk.WeekHours + ":" + Strings.Format(clockOutJunk.WeekMins, "##"));

        clockoutWriter1.Write("*RJ*");
        clockoutWriter1.Write("Tipable Sales:");
        clockoutWriter1.Write("%");
        clockoutWriter1.WriteLine("$  " + clockOutJunk.TipableSales);

        clockoutWriter1.Write("*RJ*");
        clockoutWriter1.Write("Charge Sales:");
        clockoutWriter1.Write("%");
        clockoutWriter1.WriteLine("$  " + clockOutJunk.ChargedSales);

        clockoutWriter1.Write("*RJ*");
        clockoutWriter1.Write("Charge Tips:");
        clockoutWriter1.Write("%");
        clockoutWriter1.WriteLine("$  " + clockOutJunk.ChargedTips);

        clockoutWriter1.Write("*RJ*");
        clockoutWriter1.Write("Declared Tips:");
        clockoutWriter1.Write("%");
        clockoutWriter1.WriteLine("$  " + clockOutJunk.DeclaredTips);

        clockoutWriter1.WriteLine("*BL*");
        clockoutWriter1.WriteLine("*BL*");
        clockoutWriter1.WriteLine("**********************************");
        clockoutWriter1.WriteLine("Verification for hours worked.");
        clockoutWriter1.WriteLine("Keep this for your records.");
        clockoutWriter1.WriteLine("*BL*");
        clockoutWriter1.WriteLine("*BL*");

    }

    private void PrintClockOut222()
    {
        try
        {
            streamToPrint = new StreamReader(@"c:\Data Files\spiderPOS\ClockOut.txt");
            try
            {
                // Me.printFont = New Font("Times New Roman", 12)
                // Me.printFont = New Font("Microsoft Sans Serif", 12)
                printFont = new Font("Arial", 11);
                var pd = new PrintDocument();
                pd.PrintController = new StandardPrintController();
                pd.PrintPage += pd_PrintPage222;
                pd.PrinterSettings.PrinterName = "Bar";
                // pd.PrinterSettings.PrinterName = "Receipt"
                // pd.PrinterSettings.PrinterName = "Kitchen"
                pd.Print();
            }
            finally
            {
                streamToPrint.Close();
            }
        }
        catch (Exception ex)
        {
            // info = New DataSet_Builder.Information_UC(ex.Message)
            // info.Location = New Point((Me.Width - info.Width) / 2, (Me.Height - info.Height) / 2)
            // Me.Controls.Add(info)
            // info.BringToFront()
        }

    }
    private object PlaceOrderInOrderDetail222(bool isMainCourse, decimal avgDollar)
    {

        long newOrderNumber;
        var cmdOrderNumber = new SqlClient.SqlCommand("SELECT MAX(OrderNumber) lastOrderNumber FROM ExperienceStatusChange WHERE LocationID = '" + companyInfo.LocationID + "' AND CompanyID = '" + companyInfo.CompanyID + "'", sql.cn);

        SqlClient.SqlCommand cmd;
        SqlClient.SqlDataReader dtr;

        try
        {
            // must keep database open so nobody else retreives this OrderNumber
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            dtr = cmdOrderNumber.executereader;
            dtr.Read();
            if (!object.ReferenceEquals(dtr("lastOrderNumber"), DBNull.Value))
            {
                newOrderNumber = dtr("lastOrderNumber") + 1;
            }
            else
            {
                newOrderNumber = 1L;
            }
            // ??            AddStatusChangeData(3, newOrderNumber, isMainCourse, avgDollar)

            dtr.Close();

            // this is duplicated in GenerateOrderTables but we need not to close the SQL connection
            cmd = new SqlClient.SqlCommand("INSERT INTO ExperienceStatusChange (CompanyID, LocationID, DailyCode, ExperienceNumber, StatusTime, TableStatusID, OrderNumber, IsMainCourse, AverageDollar, TerminalID, dbUP) VALUES (@CompanyID, @LocationID, @DailyCode, @ExperienceNumber, @StatusTime, @TableStatusID, @OrderNumber, @IsMainCourse, @AverageDollar, @TerminalID, @dbUP)", sql.cn);

            cmd.Parameters.Add(new SqlClient.SqlParameter("@CompanyID", System.Data.SqlDbType.NChar, 6));
            cmd.Parameters("@CompanyID").Value = companyInfo.CompanyID;
            cmd.Parameters.Add(new SqlClient.SqlParameter("@LocationID", System.Data.SqlDbType.NChar, 6));
            cmd.Parameters("@LocationID").Value = companyInfo.LocationID;
            cmd.Parameters.Add(new SqlClient.SqlParameter("@DailyCode", SqlDbType.BigInt, 8));
            cmd.Parameters("@DailyCode").Value = currentTerminal.CurrentDailyCode;
            cmd.Parameters.Add(new SqlClient.SqlParameter("@ExperienceNumber", SqlDbType.BigInt, 8));
            cmd.Parameters("@ExperienceNumber").Value = currentTable.ExperienceNumber;
            cmd.Parameters.Add(new SqlClient.SqlParameter("@StatusTime", SqlDbType.DateTime, 8));
            cmd.Parameters("@StatusTime").Value = DateTime.Now;
            cmd.Parameters.Add(new SqlClient.SqlParameter("@TableStatusID", SqlDbType.Int, 4));
            cmd.Parameters("@TableStatusID").Value = 3;
            cmd.Parameters.Add(new SqlClient.SqlParameter("@OrderNumber", SqlDbType.BigInt, 8));
            cmd.Parameters("@OrderNumber").Value = newOrderNumber;
            cmd.Parameters.Add(new SqlClient.SqlParameter("@IsMainCourse", SqlDbType.Bit, 1));
            cmd.Parameters("@IsMainCourse").Value = isMainCourse;
            cmd.Parameters.Add(new SqlClient.SqlParameter("@AverageDollar", SqlDbType.Decimal, 5));
            cmd.Parameters("@AverageDollar").Value = avgDollar;
            cmd.Parameters.Add(new SqlClient.SqlParameter("@TerminalID", SqlDbType.Int, 4));
            cmd.Parameters("@TerminalID").Value = currentTerminal.TermID;
            cmd.Parameters.Add(new SqlClient.SqlParameter("@dbUP", SqlDbType.Bit, 1));
            cmd.Parameters("@dbUP").Value = 1; // True


            cmd.ExecuteNonQuery();

            sql.cn.Close();
        }

        // ***    not sure .. 
        // 222      GenerateOrderTables.ChangeStatusInDataBase(3, newOrderNumber, isMainCourse, avgDollar)
        // 222  PlaceOrderNumberInOpenOrders222(newOrderNumber)
        // AddStatusChangeData(3, newOrderNumber, isMainCourse, avgDollar)
        // TerminalAddStatusChangeData(3, newOrderNumber, isMainCourse, avgDollar)

        catch (Exception ex)
        {
            CloseConnection();
            if (mainServerConnected == true)
            {
                ServerJustWentDown();
            }
            // TerminalAddStatusChangeData(3, -1, isMainCourse, avgDollar) '-1 indicates server down when ordering
            // GenerateOrderTables.ChangeStatusInDataBase(3, -1, isMainCourse, avgDollar)
            // PlaceOrderNumberInOpenOrders(-1)
        }

        return default;


        // we sould add in OrderByPrinter      ****************************************
        // we will create a collection keeping track of each printer totals



    }

    private void PlaceOrderNumberInOpenOrders222(long ordNum)
    {

        foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("ItemStatus") == 0)
                {
                    oRow("ItemStatus") = 2;
                    oRow("OrderNumber") = ordNum;
                }
            }
        }

    }

    private object CalculateAverageDollar222()
    {
        float avgCalculation;
        float denominatorCurrent;

        if (dsOrder.Tables("OpenOrders").Rows.Count > 0)
        {
            if (companyInfo.calculateAvgByEntrees == true)
            {
                // If dsOrder.Tables("OpenOrders").Rows.Count > 0 Then
                denominatorCurrent = dsOrder.Tables("OpenOrders").Compute("Count(FunctionID)", "FunctionID = 1 AND ItemStatus = 0");
                // Else : denominatorCurrent = 0
                // End If
                if (denominatorCurrent == 0f)
                    denominatorCurrent = 1f;
            }
            else        // calculate avg by number of guests
            {
                denominatorCurrent = currentTable.NumberOfCustomers;
                if (denominatorCurrent == 0f)
                    denominatorCurrent = 1f;
            }
            avgCalculation = dsOrder.Tables("OpenOrders").Compute("Sum(Price)", "") / denominatorCurrent;
        }
        else
        {
            avgCalculation = 0f;
        }

        return avgCalculation;

    }


    private object TerminalOrderNumber222()
    {
        object lowestOrderNumber;
        var dvOrderNumber = new DataView();

        dvOrderNumber.Table = dsBackup.Tables("ESCTerminal");
        dvOrderNumber.Sort = "OrderNumber";


        lowestOrderNumber = dvOrderNumber[0]("OrderNumber");


        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(lowestOrderNumber, 0, false)))
        {
            lowestOrderNumber = 0;
        }

        lowestOrderNumber -= (object)1;
        return lowestOrderNumber;


    }




    internal void SendingOrder222()
    {

        float avgDollar;

        if (dsOrder.Tables("OpenOrders").Rows.Count > 0)
        {
            avgDollar = Conversions.ToSingle(CalculateAverageDollar222());
        }
        else
        {
            return;
        }

        DataRow oRow;
        int i;

        i = 1;
        foreach (DataRow currentORow in ds.Tables("RoutingChoice").Rows)
        {
            oRow = currentORow;
            if (!(oRow("RoutingName") == "Do Not Route"))
            {
                switch (i)
                {
                    case 1:
                        {
                            sWriter1 = new StreamWriter(@"c:\Data Files\spiderPOS\Printer1.txt");
                            break;
                        }
                    case 2:
                        {
                            sWriter2 = new StreamWriter(@"c:\Data Files\spiderPOS\Printer2.txt");
                            break;
                        }
                    case 3:
                        {
                            sWriter3 = new StreamWriter(@"c:\Data Files\spiderPOS\Printer3.txt");
                            break;
                        }
                    case 4:
                        {
                            sWriter4 = new StreamWriter(@"c:\Data Files\spiderPOS\Printer4.txt");
                            break;
                        }
                    case 5:
                        {
                            sWriter5 = new StreamWriter(@"c:\Data Files\spiderPOS\Printer5.txt");
                            break;
                        }
                }
            }
            i += 1;
            if (i == 20)
                break;
        }
        var numberOfApps = default(int);
        var numberOfDinners = default(int);
        var isMainCourse = default(bool);
        bool newOrder = false;
        string RouteNameOnTicket;
        int countCourse1;
        int countTotalSending;


        // in 222
        countCourse1 = dsOrder.Tables("OpenOrders").Compute("Count(CourseNumber)", "CourseNumber = 1 AND ItemStatus = 0"); // (FunctionFlag = 'F' or FunctionFlag = 'M')")
        countTotalSending = dsOrder.Tables("OpenOrders").Compute("Count(ItemStatus)", "ItemStatus = 0");
        if (countCourse1 == countTotalSending)
        {
            allCourse1 = true;
        }

        foreach (DataRowView vRow in dvOrderPrint)            // dsOrder.Tables("OpenOrders").Rows
        {
            // For Each vRow In dvOrder
            // If Not vRow.RowState = DataRowState.Deleted Then

            if (vRow("ItemStatus") == 0)
            {
                newOrder = true;
                if (vRow("sin") == vRow("sii"))    // and not a drink
                {
                    if (vRow("FunctionFlag") == "F")
                    {
                        numberOfDinners += 1;
                    }
                    else if (vRow("FunctionFlag") == "M")
                    {
                        numberOfApps += 1;
                    }
                }

                switch (vRow("RoutingID"))
                {
                    case var @case when @case == printingRouting[1]:
                        {
                            // RouteNameOnTicket = printingName(1)
                            CreateOrderString(ref vRow, ref sWriter1, ref s1); // , 1) ', printingName(1))
                            break;
                        }

                    case var case1 when case1 == printingRouting[2]:
                        {
                            // RouteNameOnTicket = printingName(2)
                            CreateOrderString(ref vRow, ref sWriter2, ref s2); // , 2) ', printingName(2))
                            break;
                        }

                    case var case2 when case2 == printingRouting[3]:
                        {
                            // RouteNameOnTicket = printingName(3)
                            CreateOrderString(ref vRow, ref sWriter3, ref s3); // , 3) ', printingName(3))
                            break;
                        }
                    case var case3 when case3 == printingRouting[4]:
                        {
                            // RouteNameOnTicket = printingName(4)
                            CreateOrderString(ref vRow, ref sWriter4, ref s4); // , 4) ', printingName(4))
                            break;
                        }
                    case var case4 when case4 == printingRouting[5]:
                        {
                            // RouteNameOnTicket = printingName(5)
                            CreateOrderString(ref vRow, ref sWriter5, ref s5); // , 5) ', printingName(5))
                            break;
                        }
                }
            }
            // End If
        }

        i = 1;
        foreach (DataRow currentORow1 in ds.Tables("RoutingChoice").Rows)
        {
            oRow = currentORow1;
            if (!(oRow("RoutingName") == "Do Not Route"))
            {
                switch (i)
                {
                    case 1:
                        {
                            sWriter1.Close();
                            if (s1 == true)
                            {
                                PrintTo(1);
                            }

                            break;
                        }
                    case 2:
                        {
                            sWriter2.Close();
                            if (s2 == true)
                            {
                                PrintTo(2);
                            }

                            break;
                        }
                    case 3:
                        {
                            sWriter3.Close();
                            if (s3 == true)
                            {
                                PrintTo(3);
                            }

                            break;
                        }
                    case 4:
                        {
                            sWriter4.Close();
                            if (s4 == true)
                            {
                                PrintTo(4);
                            }

                            break;
                        }
                    case 5:
                        {
                            sWriter5.Close();
                            if (s5 == true)
                            {
                                PrintTo(5);
                            }

                            break;
                        }
                }
            }
            i += 1;
            if (i == 20)
                break;
        }


        // *** need to put below first if we want to print ORDER NUMBER on ticket
        // we can do after we have a better understanding how we will generate order numbers 
        // with multiple terminals
        if (numberOfDinners > numberOfApps)
        {
            isMainCourse = true;
        }
        else if (currentTable.NumberOfCustomers > 0 & numberOfDinners > currentTable.NumberOfCustomers / 2)
        {
            isMainCourse = true;
        }

        // we do this after printing 
        if (newOrder == true)
        {
            if (mainServerConnected == true)
            {
                PlaceOrderInOrderDetail222(isMainCourse, (decimal)avgDollar);
            }
            else
            {
                // Dim termOrderNumber As Integer
                // termOrderNumber = TerminalOrderNumber()
                // TerminalAddStatusChangeData(3, termOrderNumber, isMainCourse, avgDollar)  '-1 indicates server down when ordering
                // GenerateOrderTables.ChangeStatusInDataBase(3, termOrderNumber, isMainCourse, avgDollar)
                // PlaceOrderNumberInOpenOrders(termOrderNumber)
            }
        }

    }
    private void pd_PrintPageEPSONFix222(object sender, PrintPageEventArgs ev)
    {

        float yPos = 80f;
        float leftMargin = 0f;    // ev.MarginBounds.Left
        int count;
        int lastHeight;
        var pInfo = new FontInfo("FontA12", 19, 1); // ("FontA11", 9.5, 1) '("FontB48", 15, 1) '("FontB42", 13.5, 1)
        var pInfo2 = new FontInfo("FontB24", 27, 1);
        int midWidth;
        // page width is 500

        midWidth = 250;

        // ticket Header
        lastHeight = Conversions.ToInteger(DoPrinting(ev, leftMargin, yPos, 0, pInfo, currentRoutingName));
        lastHeight = Conversions.ToInteger(DoPrinting(ev, midWidth, yPos, 0, pInfo2, currentTable.MethodUse));
        yPos += 60 + lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, leftMargin, yPos, 0, pInfo, "******************************************"));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 500, yPos, 2, pInfo, Strings.Format(DateTime.Now, "hh:mm tt")));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, leftMargin, yPos, 0, pInfo, "Table: " + currentTable.TabName));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, leftMargin, yPos, 0, pInfo, "Guests: " + currentTable.NumberOfCustomers));
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, leftMargin, yPos, 0, pInfo, "Order: " + oDetail.trunkOrderNumber));
        yPos += 40 + lastHeight;


        var lastCourseNumber = default(int);
        bool firstCustomer = true;

        foreach (DataRowView vRow in dvOrderByPrinter)
        {
            if (allCourse1 == false)
            {
                if (vRow("CourseNumber") != lastCourseNumber)
                {
                    firstCustomer = true;
                    lastCourseNumber = vRow("CourseNumber");
                    yPos += 80f;
                    lastHeight = Conversions.ToInteger(DoPrinting(ev, 500, yPos, 2, pInfo2, "Course    " + vRow("CourseNumber")));
                    yPos += lastHeight;
                    lastHeight = Conversions.ToInteger(DoPrinting(ev, 500, yPos, 2, pInfo, "*****************"));
                    yPos += lastHeight;
                }
            }
            if (vRow("FunctionFlag") == "F" | vRow("FunctionFlag") == "O" | vRow("FunctionFlag") == "M" | vRow("FunctionFlag") == "D")
            {
                if (vRow("sin") == vRow("sii"))
                {
                    if (vRow("Quantity") > 1)
                    {
                        lastHeight = Conversions.ToInteger(DoPrinting(ev, 50, yPos, 0, pInfo2, "Quantity:    " + vRow("Quantity")));
                        yPos += lastHeight;
                    }
                    if (firstCustomer == false)
                    {
                        lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfo, "-------------------------------"));
                        yPos += lastHeight;
                    }
                    else
                    {
                        firstCustomer = false;
                    }
                    lastHeight = Conversions.ToInteger(DoPrinting(ev, 0, yPos, 0, pInfo, "C" + vRow("CustomerNumber")));
                }
                lastHeight = Conversions.ToInteger(DoPrinting(ev, 50, yPos, 0, pInfo, vRow("ChitName")));             // need price too
                yPos += lastHeight;     // 100 + (count * nHeight)
            }
            // MsgBox(ev.MarginBounds.ToString, , "Margin Bounds")
            // MsgBox(ev.PageBounds.ToString, , "Page Bounds")
            // MsgBox(ev.PageBounds.Width.ToString, , "Page Bounds Width")
            // MsgBox(ev.PageSettings.PaperSize.Width.ToString, , "Paper Width")
            // count += 1
        }

        // space on bottom
        yPos += lastHeight;
        lastHeight = Conversions.ToInteger(DoPrinting(ev, 50, yPos, 0, pInfo, "    "));

        return;

        // ***  this is just testing for epson
        float linesPerPage;

        int nHeight;

        float topMargin = ev.MarginBounds.Top;
        string line = null;
        // Dim boldFont = New Font(printFont, FontStyle.Bold)
        float pageWidthUsing;
        pageWidthUsing = ev.MarginBounds.Right - leftMargin;
        var drawFormat = new StringFormat();

        linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);


        var hdc = new IntPtr();
        var font = new IntPtr();
        nHeight = -pInfo.nFontSize * UsingGDI.GetDeviceCaps(hdc, 90) / 72;
        font = UsingGDI.CreateFont(nHeight, 0, 0, 0, 400, 0, 0, 0, pInfo.nCharSet, 0, 0, 0, 0, pInfo.sFontName);


        var loopTo = (int)Math.Round(linesPerPage);
        for (count = 0; count <= loopTo; count++)
        {

        }


        while (count < linesPerPage)
        {
            line = streamToPrint.ReadLine();

            yPos = 100 + count * nHeight;

            DoPrinting(ev, leftMargin, yPos, 0, pInfo, line);
            // If line Is Nothing Then Exit While 


            count += 1;
        }

        return;

        while (count < linesPerPage)
        {
            line = streamToPrint.ReadLine();
            if (line is null)
                break;
            // yPos = topMargin + count * printFont.GetHeight(ev.Graphics)
            if (line.Substring(0, 4) == "*RT*")       // REVERSE TEXT
            {

                line = line.Remove(0, 4);
                var rect = new Rectangle(0, yPos, ev.PageBounds.Width / 4, printFont.GetHeight(ev.Graphics));

                ev.Graphics.FillRectangle(Brushes.Black, rect);
                ev.Graphics.DrawString(line, printFont, Brushes.White, leftMargin, yPos, new StringFormat());
            }
            else if (line.Substring(0, 4) == "*BL*")   // BLANK LINE
            {
                line = line.Remove(0, 4);
                var rect = new Rectangle(0, yPos, ev.PageBounds.Width / 4, printFont.GetHeight(ev.Graphics));
            }
            // ev.Graphics.FillRectangle(Brushes.White, rect)
            else if (line.Substring(0, 4) == "*CN*")   // CENTER
            {
                line = line.Remove(0, 4);
                // drawFormat.Alignment = StringAlignment.Center
                // DoPrinting(ev, ((ev.PageBounds.Width) / 2) - 15, count, pInfo, line)
                DoPrinting(ev, leftMargin, count, 0, pInfo, line);
            }

            // ev.Graphics.DrawString(line, printFont, Brushes.Black, ((ev.PageBounds.Width) / 2) - 15, yPos, drawFormat)
            else if (line.Substring(0, 4) == "*RJ*")   // RIGHT JUSTIFY
            {
                line = line.Remove(0, 4);

                string[] split;
                // split = line.Split("%", 1)
                // split = line.Split("%", 2)

                DoPrinting(ev, leftMargin, count, 0, pInfo, split[0]);
                // ev.Graphics.DrawString(split(0), printFont, Brushes.Black, leftMargin, yPos, New StringFormat)
                drawFormat.Alignment = StringAlignment.Far;
                DoPrinting(ev, ev.PageBounds.Width - line.Length, count, 0, pInfo, split[0]);
            }
            // ev.Graphics.DrawString(split(1), printFont, Brushes.Black, ev.PageBounds.Width - 45, yPos, drawFormat)

            else
            {
                DoPrinting(ev, leftMargin, count, 0, pInfo, line);
                // ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, New StringFormat)
            }
            count += 1;
        }

    }
    private object CreateOrderString(ref DataRowView vRow, ref StreamWriter sw, ref bool sFlag) // , ByVal routingid As Integer)
    {

        string currentPrintString;
        string stringCheckNumber;
        int quantityOrdered;

        if (vRow("FunctionFlag") == "F" | vRow("FunctionFlag") == "O" | vRow("FunctionFlag") == "M" | vRow("FunctionFlag") == "D")
        {
            if (vRow("sin") == vRow("sii"))
            {
                if (sFlag == false)
                {
                    stringCheckNumber = vRow("CheckNumber") + "  of  " + currentTable.NumberOfChecks.ToString + "          " + Strings.Format(DateTime.Now, "hh:mm tt");
                    sw.WriteLine("New Ticket ");
                    // sw.WriteLine(printingName(routingid))
                    // sw.WriteLine(routingName)
                    // sw.WriteLine(printingName(1))
                    sw.WriteLine("*BL*");
                    sw.WriteLine("*****************************");
                    sw.WriteLine("*BL*");
                    sw.WriteLine("*BL*");
                    sw.WriteLine(stringCheckNumber);    // add time
                    sw.WriteLine("Table:    " + currentTable.TabName); // vRow("TabName")) 'this is table#
                    sw.WriteLine("Guests:  " + currentTable.NumberOfCustomers);
                    sw.WriteLine("Order:   " + vRow("OrderNumber"));
                    sw.WriteLine("*BL*");

                    sFlag = true;
                }
                else
                {
                    sw.WriteLine("------------------------------");
                }      // divider

                if (allCourse1 == false)
                {
                    if (vRow("CourseNumber") != lastCourseNumber)
                    {
                        // start of new course
                        lastCourseNumber = vRow("CourseNumber");
                        sw.WriteLine("*BL*");
                        sw.WriteLine("*RT*   COURSE  " + lastCourseNumber);
                        sw.WriteLine("*BL*");
                        // sw.WriteLine("*BL*")
                    }
                }
                if (vRow("Quantity") > 1)
                {
                    quantityOrdered = vRow("Quantity");
                    sw.WriteLine("   Quantity  " + quantityOrdered);
                }
                currentPrintString = "C" + vRow("CustomerNumber") + "   ";   // 3 spaces
            }
            else
            {
                currentPrintString = "        ";
            }     // eight spaces
            currentPrintString = currentPrintString + vRow("ChitName");
            sw.WriteLine(currentPrintString);
        }

        return default;
        // sw.WriteLine("  ") screws printing up


    }
    private void CreateCheckHeader222()
    {
        int numberLeft;

        if (companyInfo.companyName != default)
        {
            closeCheckWriter1.Write("*CN*");
            closeCheckWriter1.WriteLine(companyInfo.companyName);
        }
        if (companyInfo.locationName != default)
        {
            closeCheckWriter1.Write("*CN*");
            closeCheckWriter1.WriteLine(companyInfo.locationName);
        }
        if (companyInfo.locationCity != default | companyInfo.locationState != default)
        {
            closeCheckWriter1.Write("*CN*");
            closeCheckWriter1.WriteLine(companyInfo.locationCity + ",  " + companyInfo.locationState);
        }
        if (companyInfo.locationPhone != default)
        {
            closeCheckWriter1.Write("*CN*");
            closeCheckWriter1.WriteLine(companyInfo.locationPhone);
        }
        closeCheckWriter1.WriteLine("*BL*");
        closeCheckWriter1.WriteLine("*BL*");

        closeCheckWriter1.Write("*RJ*");
        closeCheckWriter1.Write("Server: ");
        closeCheckWriter1.Write(currentServer.NickName);
        closeCheckWriter1.Write("%");
        closeCheckWriter1.WriteLine(Strings.Format(DateTime.Now, "M/d/yyyy"));

        closeCheckWriter1.Write("*RJ*");
        closeCheckWriter1.Write("Table: ");
        closeCheckWriter1.Write(currentTable.TabName);
        closeCheckWriter1.Write("%");
        closeCheckWriter1.WriteLine(Strings.Format(DateTime.Now, "h:mm tt"));

        closeCheckWriter1.WriteLine("Guests: " + currentTable.NumberOfCustomers);

        closeCheckWriter1.Write("*RJ*");
        closeCheckWriter1.Write("Check: ");
        closeCheckWriter1.Write(currentTable.CheckNumber);
        closeCheckWriter1.Write(" of " + currentTable.NumberOfChecks);
        closeCheckWriter1.Write("%");
        closeCheckWriter1.WriteLine("# " + currentTable.ExperienceNumber);


        closeCheckWriter1.WriteLine("*BL*");
        closeCheckWriter1.WriteLine("*BL*");


    }

    private void FillCheckDetail222(ref DataView dvClosing, decimal chkSubTotal, decimal checkTax)
    {
        decimal runingPaymentTotal;

        foreach (DataRowView vRow in dvClosing)
        {
            if (!(vRow("ItemID") == 0))
            {
                closeCheckWriter1.Write("*RJ*");
                closeCheckWriter1.Write(vRow("ChitName"));
                closeCheckWriter1.Write("%");
                closeCheckWriter1.WriteLine(vRow("Price"));
            }
        }

        closeCheckWriter1.WriteLine("*BL*");

        closeCheckWriter1.Write("*RJ*");
        closeCheckWriter1.Write("Sub Total: ");
        closeCheckWriter1.Write("%");
        closeCheckWriter1.WriteLine(chkSubTotal);

        closeCheckWriter1.Write("*RJ*");
        closeCheckWriter1.Write("Tax: ");
        closeCheckWriter1.Write("%");
        closeCheckWriter1.WriteLine(checkTax);

        closeCheckWriter1.WriteLine("*BL*");
        closeCheckWriter1.Write("*RJ*");
        closeCheckWriter1.Write("Total: ");
        closeCheckWriter1.Write("%");
        closeCheckWriter1.WriteLine(chkSubTotal + checkTax);

        closeCheckWriter1.WriteLine("*BL*");


    }

    private void FillCheckPayments()
    {


        // For Each vRow In Payments

        // Next

        closeCheckWriter1.Write("*RJ*");
        closeCheckWriter1.Write("Change: ");
        closeCheckWriter1.Write("%");
        closeCheckWriter1.WriteLine(); // change)


    }

    private void CreateCheckFooter222()
    {
        closeCheckWriter1.WriteLine("*BL*");
        closeCheckWriter1.WriteLine("*BL*");

        closeCheckWriter1.Write("*CN*");
        closeCheckWriter1.WriteLine("Thank You");
        closeCheckWriter1.Write("*CN*");
        closeCheckWriter1.WriteLine("Please Come Again");

        closeCheckWriter1.WriteLine("*BL*");
        closeCheckWriter1.WriteLine("*BL*");

    }

    internal void PrintTo(int printerFile)
    {


        try
        {
            streamToPrint = new StreamReader(@"c:\Data Files\spiderPOS\Printer" + printerFile.ToString() + ".txt");
            // streamToPrint = New StreamReader("c:\Data Files\spiderPOS\Printer2.txt")

            try
            {
                printFont = new Font("Arial", 16);    // ("FontA12", 19)  '
                var pd = new PrintDocument();
                pd.PrintController = new StandardPrintController();
                pd.PrintPage += pd_PrintPageEPSONFix;
                pd.PrinterSettings.PrinterName = printingName[printerFile];

                pd.PrinterSettings.PrinterName = "Receipt";                         // *** need to remove
                // pd.PrinterSettings.PrinterName = "Kitchen"                  '*** need to remove
                // pd.PrinterSettings.PrinterName = "HP 722 local"
                pd.Print();
            }
            finally
            {
                streamToPrint.Close();
            }
        }
        catch (Exception ex)
        {
            // info = New DataSet_Builder.Information_UC(ex.Message)
            // info.Location = New Point((Me.Width - info.Width) / 2, (Me.Height - info.Height) / 2)
            // Me.Controls.Add(info)
            // info.BringToFront()
        }

    }


    private void pd_PrintPage222(object sender, PrintPageEventArgs ev)
    {
        float linesPerPage;
        float yPos;
        var count = default(int);
        float leftMargin = 0f;    // ev.MarginBounds.Left
        float topMargin = ev.MarginBounds.Top;
        string line = null;
        // Dim boldFont = New Font(printFont, FontStyle.Bold)
        float pageWidthUsing;
        pageWidthUsing = ev.MarginBounds.Right - leftMargin;
        var drawFormat = new StringFormat();

        linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

        var split = default(string[]);
        while (count < linesPerPage)
        {
            line = streamToPrint.ReadLine();
            if (line is null)
                break;
            yPos = topMargin + count * printFont.GetHeight(ev.Graphics);
            if (line.Substring(0, 4) == "*RT*")       // REVERSE TEXT
            {

                line = line.Remove(0, 4);
                var rect = new Rectangle(0, yPos, ev.PageBounds.Width / 4, printFont.GetHeight(ev.Graphics));

                ev.Graphics.FillRectangle(Brushes.Black, rect);
                ev.Graphics.DrawString(line, printFont, Brushes.White, leftMargin, yPos, new StringFormat());
            }
            else if (line.Substring(0, 4) == "*BL*")   // BLANK LINE
            {
                line = line.Remove(0, 4);
                var rect = new Rectangle(0, yPos, ev.PageBounds.Width / 4, printFont.GetHeight(ev.Graphics));
                ev.Graphics.FillRectangle(Brushes.White, rect);
            }
            else if (line.Substring(0, 4) == "*CN*")   // CENTER
            {
                line = line.Remove(0, 4);
                drawFormat.Alignment = StringAlignment.Center;
                ev.Graphics.DrawString(line, printFont, Brushes.Black, ev.PageBounds.Width / 2 - 15, yPos, drawFormat);
            }
            else if (line.Substring(0, 4) == "*RJ*")   // RIGHT JUSTIFY
            {
                line = line.Remove(0, 4);
                // split = line.Split("%", 1)
                // split = line.Split("%", 2)

                ev.Graphics.DrawString(split[0], printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                drawFormat.Alignment = StringAlignment.Far;
                ev.Graphics.DrawString(split[1], printFont, Brushes.Black, ev.PageBounds.Width - 45, yPos, drawFormat);
            }

            else
            {
                ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
            }
            count += 1;
        }

    }

    private void CreateTicketHeader222(object sender, PrintPageEventArgs ev)
    {

        var ppInfo = new FontInfo[10];
        ppInfo[0] = new FontInfo("FontA11", 9.5d, 1);
        ppInfo[1] = new FontInfo("FontA12", 19, 1);
        ppInfo[2] = new FontInfo("FontA21", 9.5d, 1);
        ppInfo[3] = new FontInfo("FontA22", 19, 1);

        ppInfo[4] = new FontInfo("FontB11", 7, 1);
        ppInfo[5] = new FontInfo("FontB12", 13.5d, 1);
        ppInfo[6] = new FontInfo("FontB21", 7.0d, 1);
        ppInfo[7] = new FontInfo("FontB22", 13.5d, 1);
        ppInfo[8] = new FontInfo("FontB24", 27, 1);
        ppInfo[9] = new FontInfo("FontB48", 54.5d, 1);

        int i;
        string s;


        for (i = 0; i <= 9; i++)
        {
            s = ppInfo[i].sFontName + "  " + ppInfo[i].nFontSize;
            DoPrinting(ev, 0, 100 * i, 0, ppInfo[i], s);
        }
    }


}