using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;


public partial class Manager_Reports_UC : System.Windows.Forms.UserControl
{

    private PrintDocument pdoc;
    // Dim sql As New DataSet_Builder.SQLHelper(connectserver)

    private CrystalDecisions.Windows.Forms.CrystalReportViewer _crv;

    internal virtual CrystalDecisions.Windows.Forms.CrystalReportViewer crv
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _crv;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _crv = value;
        }
    }
    private Report_LocationSales rptLocationSales = new Report_LocationSales();
    private Report_SalesByItem rptSalesByItem = new Report_SalesByItem();


    private string selectedDateRange;

    #region  Windows Form Designer generated code 

    public Manager_Reports_UC() : base()
    {
        pdoc = new PrintDocument();

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        InitializeOther();
        pdoc.PrintPage += pdoc_PrintPage;

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
    private Global.System.Windows.Forms.Button _Button1;

    internal virtual Global.System.Windows.Forms.Button Button1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Button1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_Button1 != null)
            {
                _Button1.Click -= Button1_Click;
            }

            _Button1 = value;
            if (_Button1 != null)
            {
                _Button1.Click += Button1_Click;
            }
        }
    }
    private Global.System.Windows.Forms.ComboBox _cbxLocationSalesDate;

    internal virtual Global.System.Windows.Forms.ComboBox cbxLocationSalesDate
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cbxLocationSalesDate;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cbxLocationSalesDate != null)
            {
                _cbxLocationSalesDate.SelectedIndexChanged -= cbxLocationSalesDate_SelectedIndexChanged;
            }

            _cbxLocationSalesDate = value;
            if (_cbxLocationSalesDate != null)
            {
                _cbxLocationSalesDate.SelectedIndexChanged += cbxLocationSalesDate_SelectedIndexChanged;
            }
        }
    }
    private Global.System.Windows.Forms.ComboBox _cbxSelectReport;

    internal virtual Global.System.Windows.Forms.ComboBox cbxSelectReport
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _cbxSelectReport;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_cbxSelectReport != null)
            {
                _cbxSelectReport.SelectedIndexChanged -= cbxSelectReport_SelectedIndexChanged;
            }

            _cbxSelectReport = value;
            if (_cbxSelectReport != null)
            {
                _cbxSelectReport.SelectedIndexChanged += cbxSelectReport_SelectedIndexChanged;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnPrintReport;

    internal virtual Global.System.Windows.Forms.Button btnPrintReport
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnPrintReport;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnPrintReport != null)
            {
                _btnPrintReport.Click -= btnPrintReport_Click;
            }

            _btnPrintReport = value;
            if (_btnPrintReport != null)
            {
                _btnPrintReport.Click += btnPrintReport_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnPrintPreviewReport;

    internal virtual Global.System.Windows.Forms.Button btnPrintPreviewReport
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnPrintPreviewReport;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnPrintPreviewReport != null)
            {
                _btnPrintPreviewReport.Click -= btnPrintPreviewReport_Click;
            }

            _btnPrintPreviewReport = value;
            if (_btnPrintPreviewReport != null)
            {
                _btnPrintPreviewReport.Click += btnPrintPreviewReport_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnPageSetupReport;

    internal virtual Global.System.Windows.Forms.Button btnPageSetupReport
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnPageSetupReport;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnPageSetupReport != null)
            {
                _btnPageSetupReport.Click -= btnPageSetupReport_Click;
            }

            _btnPageSetupReport = value;
            if (_btnPageSetupReport != null)
            {
                _btnPageSetupReport.Click += btnPageSetupReport_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _Button2;

    internal virtual Global.System.Windows.Forms.Button Button2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Button2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Button2 = value;
        }
    }

    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _Button1 = new System.Windows.Forms.Button();
        _Button1.Click += Button1_Click;
        _cbxLocationSalesDate = new System.Windows.Forms.ComboBox();
        _cbxLocationSalesDate.SelectedIndexChanged += cbxLocationSalesDate_SelectedIndexChanged;
        _cbxSelectReport = new System.Windows.Forms.ComboBox();
        _cbxSelectReport.SelectedIndexChanged += cbxSelectReport_SelectedIndexChanged;
        _btnPrintReport = new System.Windows.Forms.Button();
        _btnPrintReport.Click += btnPrintReport_Click;
        _btnPrintPreviewReport = new System.Windows.Forms.Button();
        _btnPrintPreviewReport.Click += btnPrintPreviewReport_Click;
        _btnPageSetupReport = new System.Windows.Forms.Button();
        _btnPageSetupReport.Click += btnPageSetupReport_Click;
        _Button2 = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // Button1
        // 
        _Button1.Location = new System.Drawing.Point(736, 16);
        _Button1.Name = "_Button1";
        _Button1.Size = new System.Drawing.Size(112, 40);
        _Button1.TabIndex = 6;
        _Button1.Text = "Exit";
        // 
        // cbxLocationSalesDate
        // 
        _cbxLocationSalesDate.Location = new System.Drawing.Point(40, 24);
        _cbxLocationSalesDate.MaxDropDownItems = 12;
        _cbxLocationSalesDate.Name = "_cbxLocationSalesDate";
        _cbxLocationSalesDate.Size = new System.Drawing.Size(160, 21);
        _cbxLocationSalesDate.TabIndex = 7;
        _cbxLocationSalesDate.Text = "Select Date Range";
        // 
        // cbxSelectReport
        // 
        _cbxSelectReport.Location = new System.Drawing.Point(560, 16);
        _cbxSelectReport.Name = "_cbxSelectReport";
        _cbxSelectReport.Size = new System.Drawing.Size(152, 21);
        _cbxSelectReport.TabIndex = 8;
        _cbxSelectReport.Text = "Select Report";
        // 
        // btnPrintReport
        // 
        _btnPrintReport.Location = new System.Drawing.Point(360, 16);
        _btnPrintReport.Name = "_btnPrintReport";
        _btnPrintReport.TabIndex = 9;
        _btnPrintReport.Text = "Print";
        // 
        // btnPrintPreviewReport
        // 
        _btnPrintPreviewReport.Location = new System.Drawing.Point(216, 16);
        _btnPrintPreviewReport.Name = "_btnPrintPreviewReport";
        _btnPrintPreviewReport.Size = new System.Drawing.Size(104, 24);
        _btnPrintPreviewReport.TabIndex = 10;
        _btnPrintPreviewReport.Text = "Print Preview";
        // 
        // btnPageSetupReport
        // 
        _btnPageSetupReport.Location = new System.Drawing.Point(216, 48);
        _btnPageSetupReport.Name = "_btnPageSetupReport";
        _btnPageSetupReport.Size = new System.Drawing.Size(104, 24);
        _btnPageSetupReport.TabIndex = 11;
        _btnPageSetupReport.Text = "Page Setup";
        // 
        // Button2
        // 
        _Button2.Location = new System.Drawing.Point(472, 16);
        _Button2.Name = "_Button2";
        _Button2.TabIndex = 13;
        _Button2.Text = "employee";
        // 
        // Manager_Reports_UC
        // 
        this.BackColor = System.Drawing.Color.LightGray;
        this.Controls.Add(_Button2);
        this.Controls.Add(_btnPageSetupReport);
        this.Controls.Add(_btnPrintPreviewReport);
        this.Controls.Add(_btnPrintReport);
        this.Controls.Add(_cbxSelectReport);
        this.Controls.Add(_cbxLocationSalesDate);
        this.Controls.Add(_Button1);
        this.Name = "Manager_Reports_UC";
        this.Size = new System.Drawing.Size(912, 632);
        this.ResumeLayout(false);

    }

    #endregion


    private void InitializeOther()
    {

        PopulateComboBoxes();

        // 
        // rptSalesByItem
        // 
        rptSalesByItem.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
        rptSalesByItem.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
        rptSalesByItem.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper;
        rptSalesByItem.PrintOptions.PrinterDuplex = CrystalDecisions.Shared.PrinterDuplex.Default;
        rptSalesByItem.SetDataSource(dtOpenOrders);


        // 
        // rptLocationSales
        // 
        rptLocationSales.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
        rptLocationSales.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
        rptLocationSales.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper;
        rptLocationSales.PrintOptions.PrinterDuplex = CrystalDecisions.Shared.PrinterDuplex.Default;

    }

    private void PopulateComboBoxes()
    {

        // cbx DataRanges
        cbxLocationSalesDate.Items.Add("WeekToDateFromSun");
        cbxLocationSalesDate.Items.Add("Last7Days");
        cbxLocationSalesDate.Items.Add("LastFullWeek");
        cbxLocationSalesDate.Items.Add("Last4WeeksToSun");
        cbxLocationSalesDate.Items.Add("MonthToDate");
        cbxLocationSalesDate.Items.Add("LastFullMonth");
        cbxLocationSalesDate.Items.Add("YearToDate");
        cbxLocationSalesDate.Items.Add("Calendar1stQrt");
        cbxLocationSalesDate.Items.Add("Calendar2ndQrt");
        cbxLocationSalesDate.Items.Add("Calendar3rdQrt");
        cbxLocationSalesDate.Items.Add("Calendar4thQrt");


        cbxSelectReport.Items.Add("Location Sales");
        cbxSelectReport.Items.Add("Items Sold");


    }

    private void Button1_Click(object sender, EventArgs e)
    {
        this.Parent.Dispose();

    }

    private void cbxLocationSalesDate_SelectedIndexChanged(object sender, EventArgs e)
    {

        selectedDateRange = "{ExperienceTable.ExperienceDate} in " + cbxLocationSalesDate.SelectedItem.ToString;



    }

    private void cbxSelectReport_SelectedIndexChanged(object sender, EventArgs e)
    {
        crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();

        // 
        // crv
        // 
        crv.ActiveViewIndex = -1;
        crv.Location = new System.Drawing.Point(24, 72);
        crv.Name = "crv";
        // Me.crv.ReportSource = "c:\Data Files\TahscPOS\term_Tahsc\Report_LocationSales.rpt"
        crv.Size = new System.Drawing.Size(872, 520);
        crv.TabIndex = 8;


        if (cbxSelectReport.SelectedItem == "Location Sales")
        {
            // Me.crv.ReportSource = "c:\Data Files\TahscPOS\Reports\Report_LocationSales.rpt"
            // Me.crv.ReportSource = "c:\Data Files\VisualStudioProjects\term_Tahsc\Report_LocationSales.rpt"
            crv.ReportSource = rptLocationSales;
        }

        else if (cbxSelectReport.SelectedItem == "Items Sold")
        {
            // Me.crv.ReportSource = "c:\Data Files\TahscPOS\Reports\Report_SalesByItem.rpt"
            // Me.crv.ReportSource = "c:\Data Files\VisualStudioProjects\term_Tahsc\Report_SalesByItem.rpt"
            crv.ReportSource = rptSalesByItem;

        }
        // Me.crv.SelectionFormula = selectedDateRange

        this.Controls.Add(crv);

    }





    private void btnPrintReport_Click(object sender, EventArgs e)
    {

        crv.PrintReport();

        // Dim dialog As New PrintDialog
        // dialog.Document = pdoc
        // 
        // If dialog.ShowDialog = DialogResult.OK Then
        // pdoc.Print()
        // End If
    }

    private void btnPrintPreviewReport_Click(object sender, EventArgs e)
    {

        var ppd = default(PrintPreviewDialog);
        try
        {
            ppd.Document = pdoc;
            ppd.ShowDialog();
        }

        catch (Exception ex)
        {
            MessageBox.Show("An error has occurred.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }

    private void btnPageSetupReport_Click(object sender, EventArgs e)
    {
        DetermineReportPrintString();


        var psd = new PageSetupDialog();
        psd.Document = pdoc;
        psd.PageSettings = pdoc.DefaultPageSettings;

        // If psd.ShowDialog = DialogResult.OK Then
        // pdoc.DefaultPageSettings = psd.PageSettings
        // End If

    }

    private int _pdoc_PrintPage_intCurrentCar;


    // Decalre variable to hold the position of the last printed char. Declare as STatic so the subsequent PrintPage events can reference it.
    private void pdoc_PrintPage(object sender, Global.System.Drawing.Printing.PrintPageEventArgs e)
    {

        var font = new Font("Microsoft Sans Serif", 24);

        int intPrintAreaHeight;
        int intPrintAreaWidth;
        int marginLeft;
        int marginTop;

        {
            var withBlock = pdoc.DefaultPageSettings;

            intPrintAreaHeight = withBlock.PaperSize.Height - withBlock.Margins.Top - withBlock.Margins.Bottom;
            intPrintAreaWidth = withBlock.PaperSize.Width - withBlock.Margins.Top - withBlock.Margins.Bottom;

            marginLeft = withBlock.Margins.Left;
            marginTop = withBlock.Margins.Top;

        }

        if (pdoc.DefaultPageSettings.Landscape)
        {
            int intTemp;
            intTemp = intPrintAreaHeight;
            intPrintAreaHeight = intPrintAreaWidth;
            intPrintAreaWidth = intTemp;
        }



    }


    private object DetermineReportPrintString()
    {

        // Dim sWriter1 As StreamWriter = New StreamWriter("c:\Data Files\TahscPOS\Reports\Report1.txt")

        DateTime yesterdaysDate;

        yesterdaysDate = Conversions.ToDate(Strings.Format(DateTime.Today.AddDays(-7), "D"));

        sql.cn.Open();
        sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
        sql.SqlSelectCommandReportItemsSold.Parameters("@ExperienceDate").Value = yesterdaysDate;
        sql.SqlDataAdapterReportItemsSold.Fill(dsReport.Tables("Report_ItemsSold"));
        sql.cn.Close();
        var lstReport = new ListView();
        lstReport.View = View.Details;

        var clmCheckTotalName = new System.Windows.Forms.ColumnHeader();
        var clmCheckTotalAmount = new System.Windows.Forms.ColumnHeader();
        lstReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { clmCheckTotalName, clmCheckTotalAmount });
        lstReport.Location = new Point(200, 200);
        lstReport.Size = new Size(200, 400);
        this.Controls.Add(lstReport);

        Interaction.MsgBox(dsReport.Tables("Report_ItemsSold").Rows.Count);

        foreach (DataRow oRow in dsReport.Tables("Report_ItemsSold").Rows)
        {
            var itemReport = new ListViewItem();
            itemReport.Text = oRow("FunctionName").ToString;
            itemReport.SubItems.Add(oRow("FoodName").ToString);
            // itemReport.SubItems.Add(EXPR7)
            lstReport.Items.Add(itemReport);

        }

        return default;



    }



    private void btnExit_Click(object sender, EventArgs e)
    {

        this.Parent.Dispose();

    }

}