using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;


public partial class Tables_Screen : System.Windows.Forms.Form
{

    private term_OrderForm ActiveOrder;

    private AvailTableButton[] btnAvailTable = new AvailTableButton[25];
    private AvailTableButton[] btnTransferTable = new AvailTableButton[10];
    // Dim availTableList As New ArrayList
    private ArrayList transferTableList = new ArrayList();


    private DataSet_Builder.SQLHelper sql = new DataSet_Builder.SQLHelper();


    #region  Windows Form Designer generated code 

    public Tables_Screen(int employeeID, int currentMenu) : base()
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        InitializeOther();


    }

    // Form overrides dispose to clean up the component list.
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
    private Global.System.Windows.Forms.Button _btnAddTable;

    internal virtual Global.System.Windows.Forms.Button btnAddTable
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnAddTable;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnAddTable != null)
            {
                _btnAddTable.Click -= btnAddTable_Click;
            }

            _btnAddTable = value;
            if (_btnAddTable != null)
            {
                _btnAddTable.Click += btnAddTable_Click;
            }
        }
    }
    private Global.System.Windows.Forms.TextBox _txtAddTable;

    internal virtual Global.System.Windows.Forms.TextBox txtAddTable
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _txtAddTable;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _txtAddTable = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlAvailTables;

    internal virtual Global.System.Windows.Forms.Panel pnlAvailTables
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlAvailTables;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_pnlAvailTables != null)
            {
                _pnlAvailTables.Click -= TableSelect;
            }

            _pnlAvailTables = value;
            if (_pnlAvailTables != null)
            {
                _pnlAvailTables.Click += TableSelect;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _pnlTransferTables;

    internal virtual Global.System.Windows.Forms.Panel pnlTransferTables
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlTransferTables;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlTransferTables = value;
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
    private System.Data.SqlClient.SqlConnection _SqlConnection1;

    internal virtual System.Data.SqlClient.SqlConnection SqlConnection1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SqlConnection1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _SqlConnection1 = value;
        }
    }
    private System.Data.SqlClient.SqlDataAdapter _SqlDataAdapterTablesAvail;

    internal virtual System.Data.SqlClient.SqlDataAdapter SqlDataAdapterTablesAvail
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SqlDataAdapterTablesAvail;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _SqlDataAdapterTablesAvail = value;
        }
    }
    private System.Data.SqlClient.SqlCommand _SqlSelectCommand1;

    internal virtual System.Data.SqlClient.SqlCommand SqlSelectCommand1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SqlSelectCommand1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _SqlSelectCommand1 = value;
        }
    }
    private System.Data.SqlClient.SqlCommand _SqlInsertCommand1;

    internal virtual System.Data.SqlClient.SqlCommand SqlInsertCommand1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SqlInsertCommand1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _SqlInsertCommand1 = value;
        }
    }
    private System.Data.SqlClient.SqlCommand _SqlUpdateCommand1;

    internal virtual System.Data.SqlClient.SqlCommand SqlUpdateCommand1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SqlUpdateCommand1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _SqlUpdateCommand1 = value;
        }
    }
    private System.Data.SqlClient.SqlCommand _SqlDeleteCommand1;

    internal virtual System.Data.SqlClient.SqlCommand SqlDeleteCommand1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SqlDeleteCommand1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _SqlDeleteCommand1 = value;
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _pnlAvailTables = new System.Windows.Forms.Panel();
        _pnlAvailTables.Click += TableSelect;
        _Label1 = new System.Windows.Forms.Label();
        _btnAddTable = new System.Windows.Forms.Button();
        _btnAddTable.Click += btnAddTable_Click;
        _txtAddTable = new System.Windows.Forms.TextBox();
        _pnlTransferTables = new System.Windows.Forms.Panel();
        _Label2 = new System.Windows.Forms.Label();
        _SqlConnection1 = new System.Data.SqlClient.SqlConnection();
        _SqlDataAdapterTablesAvail = new System.Data.SqlClient.SqlDataAdapter();
        _SqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
        _SqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
        _SqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
        _SqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
        this.SuspendLayout();
        // 
        // pnlAvailTables
        // 
        _pnlAvailTables.BackColor = System.Drawing.SystemColors.Desktop;
        _pnlAvailTables.Location = new System.Drawing.Point(112, 48);
        _pnlAvailTables.Name = "_pnlAvailTables";
        _pnlAvailTables.Size = new System.Drawing.Size(560, 310);
        _pnlAvailTables.TabIndex = 0;
        // 
        // Label1
        // 
        _Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label1.Location = new System.Drawing.Point(264, 16);
        _Label1.Name = "_Label1";
        _Label1.Size = new System.Drawing.Size(296, 24);
        _Label1.TabIndex = 1;
        _Label1.Text = "Current Tables";
        _Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btnAddTable
        // 
        _btnAddTable.Location = new System.Drawing.Point(184, 520);
        _btnAddTable.Name = "_btnAddTable";
        _btnAddTable.Size = new System.Drawing.Size(120, 48);
        _btnAddTable.TabIndex = 2;
        _btnAddTable.Text = "Add Table";
        // 
        // txtAddTable
        // 
        _txtAddTable.Location = new System.Drawing.Point(320, 536);
        _txtAddTable.Name = "_txtAddTable";
        _txtAddTable.Size = new System.Drawing.Size(64, 20);
        _txtAddTable.TabIndex = 3;
        _txtAddTable.Text = "TextBox1";
        // 
        // pnlTransferTables
        // 
        _pnlTransferTables.BackColor = System.Drawing.SystemColors.Desktop;
        _pnlTransferTables.Location = new System.Drawing.Point(112, 400);
        _pnlTransferTables.Name = "_pnlTransferTables";
        _pnlTransferTables.Size = new System.Drawing.Size(560, 72);
        _pnlTransferTables.TabIndex = 4;
        // 
        // Label2
        // 
        _Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label2.Location = new System.Drawing.Point(344, 368);
        _Label2.Name = "_Label2";
        _Label2.Size = new System.Drawing.Size(160, 32);
        _Label2.TabIndex = 5;
        _Label2.Text = "Transfer Tables";
        _Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // SqlConnection1
        // 
        _SqlConnection1.ConnectionString = "workstation id=VAIO;packet size=4096;integrated security=SSPI;data source=VAIO;pe" + "rsist security info=False;initial catalog=Restaurant_Server";
        // 
        // SqlDataAdapterTablesAvail
        // 
        _SqlDataAdapterTablesAvail.DeleteCommand = _SqlDeleteCommand1;
        _SqlDataAdapterTablesAvail.InsertCommand = _SqlInsertCommand1;
        _SqlDataAdapterTablesAvail.SelectCommand = _SqlSelectCommand1;
        _SqlDataAdapterTablesAvail.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] { new System.Data.Common.DataTableMapping("Table", "ExperienceTable", new System.Data.Common.DataColumnMapping[] { new System.Data.Common.DataColumnMapping("ExperienceNumber", "ExperienceNumber"), new System.Data.Common.DataColumnMapping("ExperienceDate", "ExperienceDate"), new System.Data.Common.DataColumnMapping("TableNumber", "TableNumber"), new System.Data.Common.DataColumnMapping("EmployeeID", "EmployeeID"), new System.Data.Common.DataColumnMapping("NumberOfCustomers", "NumberOfCustomers"), new System.Data.Common.DataColumnMapping("LastStatus", "LastStatus") }) });
        _SqlDataAdapterTablesAvail.UpdateCommand = _SqlUpdateCommand1;
        // 
        // SqlSelectCommand1
        // 
        _SqlSelectCommand1.CommandText = "[TablesAvailSelectCommand]";
        _SqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
        _SqlSelectCommand1.Connection = _SqlConnection1;
        _SqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, 0, 0, "", System.Data.DataRowVersion.Current, null));
        _SqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, "EmployeeID"));
        _SqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExperienceDate", System.Data.SqlDbType.DateTime, 8, "ExperienceDate"));
        // 
        // SqlInsertCommand1
        // 
        _SqlInsertCommand1.CommandText = "[TablesAvailInsertCommand]";
        _SqlInsertCommand1.CommandType = System.Data.CommandType.StoredProcedure;
        _SqlInsertCommand1.Connection = _SqlConnection1;
        _SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, 0, 0, "", System.Data.DataRowVersion.Current, null));
        _SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExperienceNumber", System.Data.SqlDbType.Int, 4, "ExperienceNumber"));
        _SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExperienceDate", System.Data.SqlDbType.DateTime, 8, "ExperienceDate"));
        _SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TableNumber", System.Data.SqlDbType.Int, 4, "TableNumber"));
        _SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, "EmployeeID"));
        _SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NumberOfCustomers", System.Data.SqlDbType.Int, 4, "NumberOfCustomers"));
        _SqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LastStatus", System.Data.SqlDbType.Int, 4, "LastStatus"));
        // 
        // SqlUpdateCommand1
        // 
        _SqlUpdateCommand1.CommandText = "[TablesAvailUpdateCommand]";
        _SqlUpdateCommand1.CommandType = System.Data.CommandType.StoredProcedure;
        _SqlUpdateCommand1.Connection = _SqlConnection1;
        _SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, 0, 0, "", System.Data.DataRowVersion.Current, null));
        _SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExperienceNumber", System.Data.SqlDbType.Int, 4, "ExperienceNumber"));
        _SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExperienceDate", System.Data.SqlDbType.DateTime, 8, "ExperienceDate"));
        _SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TableNumber", System.Data.SqlDbType.Int, 4, "TableNumber"));
        _SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, "EmployeeID"));
        _SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NumberOfCustomers", System.Data.SqlDbType.Int, 4, "NumberOfCustomers"));
        _SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LastStatus", System.Data.SqlDbType.Int, 4, "LastStatus"));
        _SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ExperienceNumber", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, 0, 0, "ExperienceNumber", System.Data.DataRowVersion.Original, null));
        _SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, 0, 0, "EmployeeID", System.Data.DataRowVersion.Original, null));
        _SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ExperienceDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, 0, 0, "ExperienceDate", System.Data.DataRowVersion.Original, null));
        _SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LastStatus", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, 0, 0, "LastStatus", System.Data.DataRowVersion.Original, null));
        _SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_NumberOfCustomers", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, 0, 0, "NumberOfCustomers", System.Data.DataRowVersion.Original, null));
        _SqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_TableNumber", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, 0, 0, "TableNumber", System.Data.DataRowVersion.Original, null));
        // 
        // SqlDeleteCommand1
        // 
        _SqlDeleteCommand1.CommandText = "[TablesAvailDeleteCommand]";
        _SqlDeleteCommand1.CommandType = System.Data.CommandType.StoredProcedure;
        _SqlDeleteCommand1.Connection = _SqlConnection1;
        _SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, 0, 0, "", System.Data.DataRowVersion.Current, null));
        _SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ExperienceNumber", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, 0, 0, "ExperienceNumber", System.Data.DataRowVersion.Original, null));
        _SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, 0, 0, "EmployeeID", System.Data.DataRowVersion.Original, null));
        _SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ExperienceDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, 0, 0, "ExperienceDate", System.Data.DataRowVersion.Original, null));
        _SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LastStatus", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, 0, 0, "LastStatus", System.Data.DataRowVersion.Original, null));
        _SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_NumberOfCustomers", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, 0, 0, "NumberOfCustomers", System.Data.DataRowVersion.Original, null));
        _SqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_TableNumber", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, 0, 0, "TableNumber", System.Data.DataRowVersion.Original, null));
        // 
        // Tables_Screen
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
        this.ClientSize = new System.Drawing.Size(792, 573);
        this.Controls.Add(_Label2);
        this.Controls.Add(_pnlTransferTables);
        this.Controls.Add(_txtAddTable);
        this.Controls.Add(_btnAddTable);
        this.Controls.Add(_Label1);
        this.Controls.Add(_pnlAvailTables);
        this.Name = "Tables_Screen";
        this.Text = "Tables Screen";
        this.ResumeLayout(false);

    }

    #endregion


    private void InitializeOther()
    {

        // PopulateAvailTables(currentServer.EmployeeID)
        populateStoredProcedure(currentServer.EmployeeID);

        CreateDataViewsAvailTables();
        DisplayAvailTables();

    }

    private void PopulateStoredProcedure(int empID)
    {
        DateTime todaysDate;
        DateTime yesterdaysDate;

        // will need to add yesterdays date to parameters if we can not adjust day definition
        // to do this: perform 2 seperate FILL requests back to back
        todaysDate = Conversions.ToDate(Strings.Format(DateTime.Today, "D"));
        yesterdaysDate = Conversions.ToDate(Strings.Format(DateTime.Today.AddDays(-1), "D"));

        SqlConnection1.Open();
        SqlSelectCommand1.Parameters["@EmployeeID"].Value = empID;
        SqlSelectCommand1.Parameters["@ExperienceDate"].Value = todaysDate;
        SqlDataAdapterTablesAvail.Fill(dsOrder.Tables("AvailTables"));
        SqlConnection1.Close();

    }

    private void CreateDataViewsAvailTables()
    {

        dvAvailTables = new DataView();
        {
            var withBlock = dvAvailTables;
            withBlock.Table = dsOrder.Tables("AvailTables");
            withBlock.RowFilter = "LastStatus < 8";
            withBlock.RowStateFilter = DataViewRowState.CurrentRows;

        }

        dvTransferTables = new DataView();
        {
            var withBlock1 = dvTransferTables;
            withBlock1.Table = dsOrder.Tables("AvailTables");
            withBlock1.RowFilter = "LastStatus = 8";
        }

    }

    private void DisplayAvailTables()
    {

        int index;
        var counterIndex = default(int);
        int bs = 10;
        int x = 10;
        int y = 10;
        int w = 100;
        int h = 50;


        var loopTo = dvAvailTables.Count - 1;
        for (index = 0; index <= loopTo; index++)
        {
            btnAvailTable[index] = new AvailTableButton();
            {
                ref var withBlock = ref btnAvailTable[index];
                withBlock.Text = dvAvailTables[index]("TableNumber");
                withBlock.Size = new Size(w, h);
                withBlock.Location = new Point(x, y);
                withBlock.TabStop = false;
                withBlock.ExperienceNumber = dvAvailTables[index]("ExperienceNumber");
                if (dvAvailTables[index]("LastStatus") == 8)
                {
                    withBlock.BackColor = Color.Blue; // transfered
                }
                else if (dvAvailTables[index]("LastStatus") == 2)
                {
                    withBlock.BackColor = c7;  // sat
                }
                else if (dvAvailTables[index]("LastStatus") > 2)
                {
                    withBlock.BackColor = c9;
                }
                withBlock.ForeColor = c3;
                pnlAvailTables.Controls.Add(btnAvailTable[index]);
                this.btnAvailTable[index].Click += TableSelect;

            }

            x = x + w + bs;

            counterIndex += 1;
            if (counterIndex == 5)
            {
                x = 10;
                y = y + h + bs;
                counterIndex = 0;
            }

        }


    }

    private void DisplayTransferTables()
    {

    }


    private void TableSelect(object sender, EventArgs e)
    {
        var objButton = new AvailTableButton();
        if (!object.ReferenceEquals(sender.GetType(), objButton.GetType))
            return;

        int tableNumber;
        int ExperienceNumber;

        objButton = (AvailTableButton)sender;
        tableNumber = (int)objButton.Text;
        ExperienceNumber = (int)objButton.ExperienceNumber;

        ActiveOrder = new term_OrderForm(currentMenu, currentServer.EmployeeID, tableNumber, ExperienceNumber);
        currentTable.TableNumber = tableNumber;
        currentTable.NumberOfCustomers = (int)objButton.NumberOfCustomers;

        ActiveOrder.Show();

    }

    private void btnAddTable_Click(object sender, EventArgs e)
    {

        int tn;
        tn = (int)txtAddTable.Text;

        InitializeAvailTable(tn);

    }

    private void InitializeAvailTable(int tn)
    {

    }

    // Private Function CreateTableList(ByVal empID As Integer, ByVal tableType As String)
    // sql.cn.Open()
    // If tableType Is "Avail" Then
    // cmd = New SqlClient.SqlCommand("SELECT TableNumber From TablesAvail WHERE TableStatus < 5 AND EmployeeID = '" & empID & "'", sql.cn)
    // dtr = cmd.ExecuteReader()'
    // 
    // While dtr.Read
    // '               availTableList.Add(dtr.Item("TableNumber"))
    // End While

    // ElseIf tableType Is "Transfer" Then
    // cmd = New SqlClient.SqlCommand("SELECT TableNumber From TablesAvail WHERE TableStatus = 5 and EmployeeID = '" & empID & "'", sql.cn)
    // End If
    // dtr.Close()
    // sql.cn.Close()
    // End Function
}