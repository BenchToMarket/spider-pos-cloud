using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using DataSet_Builder;


public partial class ConnectionDown_UC : System.Windows.Forms.UserControl
{

    private Button[] btnSavedMenu = new Button[31];
    internal string menuString;

    public event ArchiveMenuLoadedEventHandler ArchiveMenuLoaded;

    public delegate void ArchiveMenuLoadedEventHandler();
    public event ConnectionHelpCanceledEventHandler ConnectionHelpCanceled;

    public delegate void ConnectionHelpCanceledEventHandler();

    #region  Windows Form Designer generated code 

    public ConnectionDown_UC() : base()
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
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _Label1 = new System.Windows.Forms.Label();
        _btnCancel = new System.Windows.Forms.Button();
        _btnCancel.Click += btnCancel_Click;
        this.SuspendLayout();
        // 
        // Label1
        // 
        _Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label1.ForeColor = System.Drawing.Color.White;
        _Label1.Location = new System.Drawing.Point(40, 24);
        _Label1.Name = "_Label1";
        _Label1.Size = new System.Drawing.Size(296, 80);
        _Label1.TabIndex = 0;
        _Label1.Text = "Connection to Phoenix is down.  Report  issue   404.869.4700          Please choo" + "se your Primary_Secondary Menu from list.";
        // 
        // btnCancel
        // 
        _btnCancel.ForeColor = System.Drawing.Color.White;
        _btnCancel.Location = new System.Drawing.Point(264, 464);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.Size = new System.Drawing.Size(96, 40);
        _btnCancel.TabIndex = 1;
        _btnCancel.Text = "Cancel";
        // 
        // ConnectionDown_UC
        // 
        this.BackColor = System.Drawing.Color.FromArgb(59, 96, 141);
        this.Controls.Add(_btnCancel);
        this.Controls.Add(_Label1);
        this.Name = "ConnectionDown_UC";
        this.Size = new System.Drawing.Size(384, 520);
        this.ResumeLayout(false);

    }

    #endregion

    private void InitializeOther()
    {

        if (typeProgram == "Online_Demo")
            return;

        var i = default(int);
        float x = 16f;
        float y = 120f;

        DirectoryInfo myDirectory;
        myDirectory = new DirectoryInfo(path: @"c:\Data Files\spiderPOS\Menu");

        // get the files
        FileInfo[] myfiles;
        // myfiles.Sort(Of Date)()

        // check file in the files collection

        myfiles = myDirectory.GetFiles();
        string fString;

        foreach (var fs in myfiles)
        {
            if (fs.Name.Length > 3)
            {
                fString = fs.Name.ToString().Substring(0, fs.Name.Length - 4);
            }
            else
            {
                fString = "No Menu";
            }
            btnSavedMenu[i] = new Button();
            {
                ref var withBlock = ref btnSavedMenu[i];
                withBlock.Size = new Size(172, 32);
                withBlock.Location = new Point(x, y);
                withBlock.Text = fString; // fs.Name.ToString
                withBlock.ForeColor = c3;
                withBlock.BackColor = c16;
                withBlock.Click += MenuChoice_Click;
            }

            this.Controls.Add(btnSavedMenu[i]);


            y += 40f;
            i += 1;
            if (i == 14)
            {
                x = 200f;
                y = 120f;
            }
            else if (i == 29)
            {
                return;
            }

        }

    }

    private void MenuChoice_Click(object sender, EventArgs e)
    {

        // we structure the tables in REVERSE order from how they load
        string fString;
        fString = Conversions.ToString(Operators.ConcatenateObject(sender.text, ".xml"));

        MenuChoiceRoutine(fString);

    }

    internal void MenuChoiceRoutine(string fString)
    {

        // Dim sRow As DataRow
        DataRow oRow;
        // Dim mTable As String


        if (dsStarter.Tables("StarterLocationOverview").Rows.Count == 0)
        {
            try
            {
                LoadStarterDataSet();

                oRow = dsStarter.Tables("StarterLocationOverview").Rows(0);
                FillLocationOverviewData(oRow);
            }


            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, (MsgBoxStyle)Conversions.ToInteger("   Can't load Starter Menu. Call spiderPOS at 404.869.4700"));
                return;
            }

        }

        // ***this was the place for creating table structure


        // currently pulling backup automatically
        try
        {

            ds.Clear();

            if (typeProgram == "Online_Demo")
            {

                // If currentTerminal.TermMethod = "Quick" Then
                // ds.ReadXml("Lunch_Dinner_QuickDemo.xml", XmlReadMode.ReadSchema)
                // Else
                // ds.ReadXml("Lunch_Dinner.xml", XmlReadMode.ReadSchema)
                // End If
                dsOrder.ReadXml("OrderData.xml", XmlReadMode.ReadSchema);
                dsEmployee.ReadXml("EmployeeData.xml", XmlReadMode.ReadSchema);
                dsOrderDemo.ReadXml("OrderData.xml", XmlReadMode.ReadSchema);
                dsEmployeeDemo.ReadXml("EmployeeData.xml", XmlReadMode.ReadSchema);
                dsCustomer.ReadXml("CustomerData.xml", XmlReadMode.ReadSchema);
                dsCustomerDemo.ReadXml("CustomerData.xml", XmlReadMode.ReadSchema);
                // dsInventory.ReadXml("InventoryData.xml", XmlReadMode.ReadSchema)
                // dsOrderDemo.Tables("OpenOrders").PrimaryKey = Nothing
                // dsOrderDemo.dtCurrentlyHeld.Rows(0)("CurrentlyHeld") = False

                ds.AcceptChanges();
                dsOrder.AcceptChanges();
                dsEmployee.AcceptChanges();
                dsCustomer.AcceptChanges();
                dsCustomer.AcceptChanges();

                dsOrderDemo.AcceptChanges();
                dsEmployeeDemo.AcceptChanges();
                dsCustomerDemo.AcceptChanges();


                orderInactiveTimer = new DateAndTime.Timer();
                tablesInactiveTimer = new DateAndTime.Timer();
                splitInactiveTimer = new DateAndTime.Timer();
                tmrCardRead = new DateAndTime.Timer();

                // currentTerminal = New Terminal
                // GenerateOrderTables.CreateTerminals()
                PopulateAllEmployeeColloection();
            }

            // MsgBox(dsOrder.Tables(0).Rows.Count)
            // MsgBox(dsEmployee.Tables("LoggedInEmployees").Rows.Count)
            // MsgBox(dsEmployee.Tables("AllEmployees").Rows.Count)

            // aaaaa()

            else
            {
                // not online demo
                ds.ReadXml(@"c:\Data Files\spiderPOS\Menu\" + fString, XmlReadMode.ReadSchema);
            }

            ArchiveMenuLoaded?.Invoke();
            SetUpPrimaryKeys();
        }

        // 999 right before this is our trouble
        // JustTestingTermsTables()

        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);

            Interaction.MsgBox("Menu NOT Found");
            ConnectionHelpCanceled?.Invoke();
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {

        ConnectionHelpCanceled?.Invoke();

    }
}