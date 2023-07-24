using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using DataSet_Builder;
using Microsoft.VisualBasic; // Install-Package Microsoft.VisualBasic
using Microsoft.VisualBasic.CompilerServices; // Install-Package Microsoft.VisualBasic


public partial class Manager_Transfer_UC : System.Windows.Forms.UserControl
{

    // Dim sql As New DataSet_Builder.SQLHelper(connectserver)

    private int empIDTransferTo;

    private int _transItemSelectedNumber;
    private string _transItemName;
    private int _transCheckNumber;
    private long _transExpNumber;
    private bool _transItemFlag;
    private bool _transCheckFlag;
    private bool _transAllTableFlag;
    private bool RestrictToItemOnly;

    private int newStatus;


    internal int TransItemSelectedNumber
    {
        get
        {
            return _transItemSelectedNumber;
        }
        set
        {
            _transItemSelectedNumber = value;
        }
    }

    internal string TransItemName
    {
        get
        {
            return _transItemName;
        }
        set
        {
            _transItemName = value;
        }
    }

    internal int TransCheckNumber
    {
        get
        {
            return _transCheckNumber;
        }
        set
        {
            _transCheckNumber = value;
        }
    }

    internal long TransExpNumber
    {
        get
        {
            return _transExpNumber;
        }
        set
        {
            _transExpNumber = value;
        }
    }

    internal bool TransItemFlag
    {
        get
        {
            return _transItemFlag;
        }
        set
        {
            _transItemFlag = value;
        }
    }

    internal bool TransCheckFlag
    {
        get
        {
            return _transCheckFlag;
        }
        set
        {
            _transCheckFlag = value;
        }
    }

    internal bool TransAllTableFlag
    {
        get
        {
            return _transAllTableFlag;
        }
        set
        {
            _transAllTableFlag = value;
        }
    }

    public event UpdatingCurrentTablesEventHandler UpdatingCurrentTables;

    public delegate void UpdatingCurrentTablesEventHandler(bool releasingTable);


    #region  Windows Form Designer generated code 

    public Manager_Transfer_UC(int itemSII, string itemName, int checkID, long expNumber, bool itemFlag, bool onlyItem) : base()
    {

        _transItemSelectedNumber = itemSII;
        _transItemName = itemName;

        RestrictToItemOnly = onlyItem;

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call

        TestForOpenOrderID();

        _transItemFlag = itemFlag;
        _transExpNumber = expNumber;
        _transCheckNumber = checkID;
        if (RestrictToItemOnly == false)
        {
            if (_transItemFlag == false)
            {
                _transCheckFlag = true;
                UpdateCheckButton();
            }
            else
            {
                UpdateItemButton();
            }
        }
        else
        {
            UpdateItemButton();
        }

    }

    private void TestForOpenOrderID()
    {

        bool noOpenOrderID = false;

        foreach (DataRowView vRow in dvOrder) // dvClosingCheck
        {
            if (object.ReferenceEquals(vRow("OpenOrderID"), DBNull.Value))
            {
                noOpenOrderID = true;
                break;
            }
        }

        if (noOpenOrderID == true)
        {
            SaveOpenOrderData();
            DisposeDataViewsOrder();
            PopulateThisExperience(currentTable.ExperienceNumber, false);
            // 444    CreateDataViewsOrder()
        }

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
    private Global.System.Windows.Forms.Panel _pnlMgrTransfer;

    internal virtual Global.System.Windows.Forms.Panel pnlMgrTransfer
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlMgrTransfer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlMgrTransfer = value;
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
    private Global.System.Windows.Forms.Button _btnTransItem;

    internal virtual Global.System.Windows.Forms.Button btnTransItem
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnTransItem;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnTransItem != null)
            {
                _btnTransItem.Click -= btnTransItem_Click;
            }

            _btnTransItem = value;
            if (_btnTransItem != null)
            {
                _btnTransItem.Click += btnTransItem_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnTransCheck;

    internal virtual Global.System.Windows.Forms.Button btnTransCheck
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnTransCheck;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnTransCheck != null)
            {
                _btnTransCheck.Click -= btnTransCheck_Click;
            }

            _btnTransCheck = value;
            if (_btnTransCheck != null)
            {
                _btnTransCheck.Click += btnTransCheck_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnTransTable;

    internal virtual Global.System.Windows.Forms.Button btnTransTable
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnTransTable;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnTransTable != null)
            {
                _btnTransTable.Click -= btnTransTable_Click;
            }

            _btnTransTable = value;
            if (_btnTransTable != null)
            {
                _btnTransTable.Click += btnTransTable_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Panel _Panel2;

    internal virtual Global.System.Windows.Forms.Panel Panel2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Panel2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Panel2 = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnTransServers;

    internal virtual Global.System.Windows.Forms.Button btnTransServers
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnTransServers;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnTransServers != null)
            {
                _btnTransServers.Click -= btnTransServers_Click;
            }

            _btnTransServers = value;
            if (_btnTransServers != null)
            {
                _btnTransServers.Click += btnTransServers_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnTransBar;

    internal virtual Global.System.Windows.Forms.Button btnTransBar
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnTransBar;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnTransBar != null)
            {
                _btnTransBar.Click -= btnTransBar_Click;
            }

            _btnTransBar = value;
            if (_btnTransBar != null)
            {
                _btnTransBar.Click += btnTransBar_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnTransManagers;

    internal virtual Global.System.Windows.Forms.Button btnTransManagers
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnTransManagers;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnTransManagers != null)
            {
                _btnTransManagers.Click -= btnTransManagers_Click;
            }

            _btnTransManagers = value;
            if (_btnTransManagers != null)
            {
                _btnTransManagers.Click += btnTransManagers_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnTransTodaysFloor;

    internal virtual Global.System.Windows.Forms.Button btnTransTodaysFloor
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnTransTodaysFloor;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnTransTodaysFloor != null)
            {
                _btnTransTodaysFloor.Click -= btnTransTodaysFloor_Click;
            }

            _btnTransTodaysFloor = value;
            if (_btnTransTodaysFloor != null)
            {
                _btnTransTodaysFloor.Click += btnTransTodaysFloor_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnTransAllFloor;

    internal virtual Global.System.Windows.Forms.Button btnTransAllFloor
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnTransAllFloor;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnTransAllFloor != null)
            {
                _btnTransAllFloor.Click -= btnTransAllFloor_Click;
            }

            _btnTransAllFloor = value;
            if (_btnTransAllFloor != null)
            {
                _btnTransAllFloor.Click += btnTransAllFloor_Click;
            }
        }
    }
    private Global.System.Windows.Forms.ListView _lstTransNames;

    internal virtual Global.System.Windows.Forms.ListView lstTransNames
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lstTransNames;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_lstTransNames != null)
            {
                _lstTransNames.SelectedIndexChanged -= DetermineTranseree;
            }

            _lstTransNames = value;
            if (_lstTransNames != null)
            {
                _lstTransNames.SelectedIndexChanged += DetermineTranseree;
            }
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _TransTo;

    internal virtual Global.System.Windows.Forms.ColumnHeader TransTo
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TransTo;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _TransTo = value;
        }
    }
    private Global.System.Windows.Forms.ColumnHeader _TransEmpID;

    internal virtual Global.System.Windows.Forms.ColumnHeader TransEmpID
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _TransEmpID;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _TransEmpID = value;
        }
    }
    private Global.System.Windows.Forms.Button _btnTransCancel;

    internal virtual Global.System.Windows.Forms.Button btnTransCancel
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnTransCancel;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnTransCancel != null)
            {
                _btnTransCancel.Click -= btnTransCancel_Click;
            }

            _btnTransCancel = value;
            if (_btnTransCancel != null)
            {
                _btnTransCancel.Click += btnTransCancel_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnAccept;

    internal virtual Global.System.Windows.Forms.Button btnAccept
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnAccept;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnAccept != null)
            {
                _btnAccept.Click -= btnAccept_Click;
            }

            _btnAccept = value;
            if (_btnAccept != null)
            {
                _btnAccept.Click += btnAccept_Click;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _pnlMgrTransfer = new System.Windows.Forms.Panel();
        _lstTransNames = new System.Windows.Forms.ListView();
        _lstTransNames.SelectedIndexChanged += DetermineTranseree;
        _TransTo = new System.Windows.Forms.ColumnHeader();
        _TransEmpID = new System.Windows.Forms.ColumnHeader();
        _Panel2 = new System.Windows.Forms.Panel();
        _btnTransAllFloor = new System.Windows.Forms.Button();
        _btnTransAllFloor.Click += btnTransAllFloor_Click;
        _btnTransTodaysFloor = new System.Windows.Forms.Button();
        _btnTransTodaysFloor.Click += btnTransTodaysFloor_Click;
        _btnTransManagers = new System.Windows.Forms.Button();
        _btnTransManagers.Click += btnTransManagers_Click;
        _btnTransBar = new System.Windows.Forms.Button();
        _btnTransBar.Click += btnTransBar_Click;
        _btnTransServers = new System.Windows.Forms.Button();
        _btnTransServers.Click += btnTransServers_Click;
        _Panel1 = new System.Windows.Forms.Panel();
        _btnTransCheck = new System.Windows.Forms.Button();
        _btnTransCheck.Click += btnTransCheck_Click;
        _btnTransItem = new System.Windows.Forms.Button();
        _btnTransItem.Click += btnTransItem_Click;
        _btnTransTable = new System.Windows.Forms.Button();
        _btnTransTable.Click += btnTransTable_Click;
        _btnTransCancel = new System.Windows.Forms.Button();
        _btnTransCancel.Click += btnTransCancel_Click;
        _btnAccept = new System.Windows.Forms.Button();
        _btnAccept.Click += btnAccept_Click;
        _pnlMgrTransfer.SuspendLayout();
        _Panel2.SuspendLayout();
        _Panel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlMgrTransfer
        // 
        _pnlMgrTransfer.BackColor = System.Drawing.SystemColors.ControlLight;
        _pnlMgrTransfer.Controls.Add(_lstTransNames);
        _pnlMgrTransfer.Controls.Add(_Panel2);
        _pnlMgrTransfer.Controls.Add(_Panel1);
        _pnlMgrTransfer.Location = new System.Drawing.Point(32, 72);
        _pnlMgrTransfer.Name = "_pnlMgrTransfer";
        _pnlMgrTransfer.Size = new System.Drawing.Size(736, 512);
        _pnlMgrTransfer.TabIndex = 0;
        // 
        // lstTransNames
        // 
        _lstTransNames.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
        _lstTransNames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { _TransTo, _TransEmpID });
        _lstTransNames.Font = new System.Drawing.Font("Bookman Old Style", 16.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lstTransNames.Location = new System.Drawing.Point(256, 16);
        _lstTransNames.Name = "_lstTransNames";
        _lstTransNames.Size = new System.Drawing.Size(328, 480);
        _lstTransNames.TabIndex = 2;
        _lstTransNames.View = System.Windows.Forms.View.Details;
        // 
        // TransTo
        // 
        _TransTo.Text = "          Transferring To:";
        _TransTo.Width = 324;
        // 
        // TransEmpID
        // 
        _TransEmpID.Text = "";
        _TransEmpID.Width = 0;
        // 
        // Panel2
        // 
        _Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        _Panel2.Controls.Add(_btnTransAllFloor);
        _Panel2.Controls.Add(_btnTransTodaysFloor);
        _Panel2.Controls.Add(_btnTransManagers);
        _Panel2.Controls.Add(_btnTransBar);
        _Panel2.Controls.Add(_btnTransServers);
        _Panel2.Location = new System.Drawing.Point(32, 208);
        _Panel2.Name = "_Panel2";
        _Panel2.Size = new System.Drawing.Size(168, 288);
        _Panel2.TabIndex = 1;
        // 
        // btnTransAllFloor
        // 
        _btnTransAllFloor.BackColor = System.Drawing.Color.LightSlateGray;
        _btnTransAllFloor.Font = new System.Drawing.Font("Comic Sans MS", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnTransAllFloor.Location = new System.Drawing.Point(8, 232);
        _btnTransAllFloor.Name = "_btnTransAllFloor";
        _btnTransAllFloor.Size = new System.Drawing.Size(152, 48);
        _btnTransAllFloor.TabIndex = 4;
        _btnTransAllFloor.Text = "All Floor";
        // 
        // btnTransTodaysFloor
        // 
        _btnTransTodaysFloor.BackColor = System.Drawing.Color.LightSlateGray;
        _btnTransTodaysFloor.Font = new System.Drawing.Font("Comic Sans MS", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnTransTodaysFloor.Location = new System.Drawing.Point(8, 176);
        _btnTransTodaysFloor.Name = "_btnTransTodaysFloor";
        _btnTransTodaysFloor.Size = new System.Drawing.Size(152, 48);
        _btnTransTodaysFloor.TabIndex = 3;
        _btnTransTodaysFloor.Text = "Today's Floor";
        // 
        // btnTransManagers
        // 
        _btnTransManagers.BackColor = System.Drawing.Color.LightSlateGray;
        _btnTransManagers.Font = new System.Drawing.Font("Comic Sans MS", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnTransManagers.Location = new System.Drawing.Point(8, 120);
        _btnTransManagers.Name = "_btnTransManagers";
        _btnTransManagers.Size = new System.Drawing.Size(152, 48);
        _btnTransManagers.TabIndex = 2;
        _btnTransManagers.Text = "Managers";
        // 
        // btnTransBar
        // 
        _btnTransBar.BackColor = System.Drawing.Color.LightSlateGray;
        _btnTransBar.Font = new System.Drawing.Font("Comic Sans MS", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnTransBar.Location = new System.Drawing.Point(8, 64);
        _btnTransBar.Name = "_btnTransBar";
        _btnTransBar.Size = new System.Drawing.Size(152, 48);
        _btnTransBar.TabIndex = 1;
        _btnTransBar.Text = "Bartenders";
        // 
        // btnTransServers
        // 
        _btnTransServers.BackColor = System.Drawing.Color.LightSlateGray;
        _btnTransServers.Font = new System.Drawing.Font("Comic Sans MS", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnTransServers.Location = new System.Drawing.Point(8, 8);
        _btnTransServers.Name = "_btnTransServers";
        _btnTransServers.Size = new System.Drawing.Size(152, 48);
        _btnTransServers.TabIndex = 0;
        _btnTransServers.Text = "Servers";
        // 
        // Panel1
        // 
        _Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        _Panel1.Controls.Add(_btnTransCheck);
        _Panel1.Controls.Add(_btnTransItem);
        _Panel1.Controls.Add(_btnTransTable);
        _Panel1.Location = new System.Drawing.Point(32, 16);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(168, 176);
        _Panel1.TabIndex = 0;
        // 
        // btnTransCheck
        // 
        _btnTransCheck.BackColor = System.Drawing.Color.LightSlateGray;
        _btnTransCheck.Font = new System.Drawing.Font("Comic Sans MS", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnTransCheck.Location = new System.Drawing.Point(8, 64);
        _btnTransCheck.Name = "_btnTransCheck";
        _btnTransCheck.Size = new System.Drawing.Size(152, 48);
        _btnTransCheck.TabIndex = 1;
        _btnTransCheck.Text = "Check 1 of ...";
        // 
        // btnTransItem
        // 
        _btnTransItem.BackColor = System.Drawing.SystemColors.ControlLight;
        _btnTransItem.Font = new System.Drawing.Font("Comic Sans MS", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnTransItem.Location = new System.Drawing.Point(8, 8);
        _btnTransItem.Name = "_btnTransItem";
        _btnTransItem.Size = new System.Drawing.Size(152, 48);
        _btnTransItem.TabIndex = 0;
        _btnTransItem.Text = "Item: ...";
        // 
        // btnTransTable
        // 
        _btnTransTable.BackColor = System.Drawing.Color.LightSlateGray;
        _btnTransTable.Font = new System.Drawing.Font("Comic Sans MS", 12.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnTransTable.Location = new System.Drawing.Point(8, 120);
        _btnTransTable.Name = "_btnTransTable";
        _btnTransTable.Size = new System.Drawing.Size(152, 48);
        _btnTransTable.TabIndex = 2;
        _btnTransTable.Text = "Table";
        // 
        // btnTransCancel
        // 
        _btnTransCancel.BackColor = System.Drawing.Color.LightSlateGray;
        _btnTransCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnTransCancel.Location = new System.Drawing.Point(96, 16);
        _btnTransCancel.Name = "_btnTransCancel";
        _btnTransCancel.Size = new System.Drawing.Size(104, 40);
        _btnTransCancel.TabIndex = 1;
        _btnTransCancel.Text = "Cancel";
        // 
        // btnAccept
        // 
        _btnAccept.BackColor = System.Drawing.Color.LightSlateGray;
        _btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _btnAccept.Location = new System.Drawing.Point(360, 8);
        _btnAccept.Name = "_btnAccept";
        _btnAccept.Size = new System.Drawing.Size(192, 56);
        _btnAccept.TabIndex = 2;
        _btnAccept.Text = "Accept";
        // 
        // Manager_Transfer_UC
        // 
        this.BackColor = System.Drawing.Color.CornflowerBlue;
        this.Controls.Add(_btnAccept);
        this.Controls.Add(_btnTransCancel);
        this.Controls.Add(_pnlMgrTransfer);
        this.Name = "Manager_Transfer_UC";
        this.Size = new System.Drawing.Size(800, 600);
        _pnlMgrTransfer.ResumeLayout(false);
        _Panel2.ResumeLayout(false);
        _Panel1.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private void btnTransItem_Click(object sender, EventArgs e)
    {

        Interaction.MsgBox("Transfering an item is NOT allowed.");
        return;
        UpdateItemButton();

    }

    private void btnTransCheck_Click(object sender, EventArgs e)
    {
        if (RestrictToItemOnly == false)
        {
            UpdateCheckButton();
        }
        else
        {
            Interaction.MsgBox(actingManager.FullName + " does not have Authorization");
        }

    }

    private void UpdateItemButton()
    {
        ResetColorFlagButtons();

        _transItemFlag = true;
        btnTransItem.BackColor = c6;
        btnTransItem.ForeColor = c3;

        btnTransItem.Text = "Item " + TransItemName;

    }

    private void UpdateCheckButton()
    {
        ResetColorFlagButtons();

        _transCheckFlag = true;
        btnTransCheck.BackColor = c6;
        btnTransCheck.ForeColor = c3;

        btnTransCheck.Text = "Check " + TransCheckNumber + " of " + currentTable.NumberOfChecks;


    }

    private void btnTransTable_Click(object sender, EventArgs e)
    {
        if (RestrictToItemOnly == false)
        {
            ResetColorFlagButtons();

            _transAllTableFlag = true;
            btnTransTable.BackColor = c6;
            btnTransTable.ForeColor = c3;
        }
        else
        {
            Interaction.MsgBox(actingManager.FullName + " does not have Authorization");
        }

    }

    private void btnTransServers_Click(object sender, EventArgs e)
    {

        PopulateServerCollection(currentServers);

        lstTransNames.Items.Clear();
        ResetColorPersonnelButtons();
        btnTransServers.BackColor = c6;
        btnTransServers.ForeColor = c3;

        PopulateTransListView(ref currentServers);

    }

    private void btnTransBar_Click(object sender, EventArgs e)
    {

        PopulateServerCollection(currentBartenders);

        lstTransNames.Items.Clear();
        ResetColorPersonnelButtons();
        btnTransBar.BackColor = c6;
        btnTransBar.ForeColor = c3;
        PopulateTransListView(ref currentBartenders);

    }

    private void btnTransManagers_Click(object sender, EventArgs e)
    {

        PopulateServerCollection(currentManagers);

        lstTransNames.Items.Clear();
        ResetColorPersonnelButtons();
        btnTransManagers.BackColor = c6;
        btnTransManagers.ForeColor = c3;

        PopulateTransListView(ref currentManagers);

    }

    private void btnTransTodaysFloor_Click(object sender, EventArgs e)
    {

        PopulateServerCollection(todaysFloorPersonnel);

        lstTransNames.Items.Clear();
        ResetColorPersonnelButtons();
        btnTransTodaysFloor.BackColor = c6;
        btnTransTodaysFloor.ForeColor = c3;
        PopulateTransListView(ref todaysFloorPersonnel);

    }


    private void ResetColorFlagButtons()
    {

        btnTransItem.BackColor = c10;
        btnTransCheck.BackColor = c10;
        btnTransTable.BackColor = c10;
        btnTransItem.ForeColor = c2;
        btnTransCheck.ForeColor = c2;
        btnTransTable.ForeColor = c2;

        _transItemFlag = false;
        _transCheckFlag = false;
        _transAllTableFlag = false;
        btnTransItem.Text = "Item";
        btnTransCheck.Text = "Check";


    }

    private void ResetColorPersonnelButtons()
    {

        btnTransServers.BackColor = c10;
        btnTransBar.BackColor = c10;
        btnTransManagers.BackColor = c10;
        btnTransTodaysFloor.BackColor = c10;
        btnTransAllFloor.BackColor = c10;
        btnTransServers.ForeColor = c2;
        btnTransBar.ForeColor = c2;
        btnTransManagers.ForeColor = c2;
        btnTransTodaysFloor.ForeColor = c2;
        btnTransAllFloor.ForeColor = c2;

    }

    private void PopulateTransListView(ref EmployeeCollection tempEmpCollection)
    {

        if (tempEmpCollection.Count > 15)
        {
            TransTo.Width = 308;
        }

        foreach (Employee emp in tempEmpCollection)
        {
            var itemEmployee = new ListViewItem();

            // If emp.EmployeeID <> currentTable.EmployeeID Then
            itemEmployee.Text = emp.FullName;
            itemEmployee.SubItems.Add(emp.EmployeeID);
            lstTransNames.Items.Add(itemEmployee);
            // End If
        }

    }

    private void DetermineTranseree(object sender, EventArgs e)
    {

        ListView itemView;

        itemView = sender;

        foreach (ListViewItem item in itemView.Items)
        {
            if (item.Selected == true)
            {
                empIDTransferTo = item.SubItems(1).Text;
                break;
            }
        }

    }

    private void ChangeItemStatusPriorTrans(int empID, long expNum)
    {
        DataRowView oRow;
        // Dim remainingChecks As Boolean
        var iPromo = default(ItemPromoInfo);

        iPromo.PromoCode = 8;
        iPromo.PromoReason = 9;  // kitch mistake, need to change to a GUI choice

        try
        {
            // sql.cn.Open()
            // sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery()
            if (TransItemFlag == true)
            {
                foreach (DataRowView currentORow in dvOrder)
                {
                    oRow = currentORow;            // dsOrder.Tables("OpenOrders").Rows
                    // changed 1 line below for dataview
                    if (!(oRow.Row.RowState == DataRowState.Deleted) & !(oRow.Row.RowState == DataRowState.Detached))
                    {
                        if (oRow("sii") == TransItemSelectedNumber)
                        {
                            if (!(oRow("ForceFreeID") == 9) | !(oRow("ForceFreeID") == 8) & !(oRow("ForceFreeID") == -9) & !(oRow("ForceFreeID") == -8))
                            {
                                // ALREADY comp'd or transfered
                                // AddTransferedItemsToOpenOrder(oRow, empID, expNum)
                                // oRow("CheckNumber") = 1

                                GenerateOrderTables.CopyViewForTransferItem(oRow, empID, expNum, true, 1);

                                iPromo.empID = actingManager.EmployeeID;
                                iPromo.PromoName = "   ** Transfer: " + oRow("TerminalName");
                                iPromo.ItemID = oRow("ItemID");
                                iPromo.Quantity = oRow("Quantity") * -1;
                                iPromo.InvMultiplier = oRow("OpenDecimal1");
                                iPromo.ItemPrice = oRow("ItemPrice");
                                iPromo.Price = oRow("Price");
                                iPromo.TaxPrice = oRow("TaxPrice");
                                iPromo.SinTax = oRow("SinTax");

                                iPromo.FunctionID = oRow("FunctionID");
                                iPromo.FunctionGroup = oRow("FunctionGroupID");
                                iPromo.FunctionFlag = oRow("FunctionFlag");
                                iPromo.CategoryID = oRow("CategoryID");
                                iPromo.FoodID = oRow("FoodID");
                                iPromo.DrinkCategoryID = oRow("DrinkCategoryID");
                                iPromo.DrinkID = oRow("DrinkID");
                                iPromo.RoutingID = oRow("RoutingID");
                                iPromo.PrintPriorityID = oRow("PrintPriorityID");

                                iPromo.ItemStatus = 8;
                                oRow("ForceFreeID") = -8;
                                oRow("ForceFreeAuth") = empID;   // this is who we transfered to
                                oRow("ItemStatus") = 8;

                                iPromo.CheckNumber = TransCheckNumber; // 1  'oRow("CheckNumber")
                                iPromo.CustomerNumber = oRow("CustomerNumber");
                                iPromo.CourseNumber = oRow("CourseNumber");

                                iPromo.openOrderID = oRow("OpenOrderID");
                                iPromo.taxID = oRow("TaxID");
                                iPromo.sii = oRow("sii");
                                iPromo.si2 = oRow("si2");

                                CompThisItem(iPromo);

                            }
                        }
                    }
                }
            }

            else if (TransCheckFlag == true)
            {
                foreach (DataRowView currentORow1 in dvOrder)
                {
                    oRow = currentORow1;             // dsOrder.Tables("OpenOrders").Rows
                    if (!(oRow.Row.RowState == DataRowState.Deleted) & !(oRow.Row.RowState == DataRowState.Detached))
                    {

                        if (oRow("CheckNumber") == TransCheckNumber)
                        {
                            if (!(oRow("ForceFreeID") == 9) & !(oRow("ForceFreeID") == 8) & !(oRow("ForceFreeID") == -9) & !(oRow("ForceFreeID") == -8))
                            {
                                // ALREADY comp'd or transfered
                                // AddTransferedItemsToOpenOrder(oRow, empID, expNum)

                                // oRow("CheckNumber") = 1
                                GenerateOrderTables.CopyViewForTransferItem(oRow, empID, expNum, true, 1);


                                iPromo.empID = actingManager.EmployeeID;
                                iPromo.PromoName = "   ** Transfer: " + oRow("TerminalName");
                                iPromo.ItemID = oRow("ItemID");
                                iPromo.Quantity = oRow("Quantity") * -1;
                                iPromo.InvMultiplier = oRow("OpenDecimal1");
                                iPromo.ItemPrice = oRow("ItemPrice");
                                iPromo.Price = oRow("Price");
                                iPromo.TaxPrice = oRow("TaxPrice");
                                iPromo.SinTax = oRow("SinTax");

                                iPromo.FunctionID = oRow("FunctionID");
                                iPromo.FunctionGroup = oRow("FunctionGroupID");
                                iPromo.FunctionFlag = oRow("FunctionFlag");
                                iPromo.CategoryID = oRow("CategoryID");
                                iPromo.FoodID = oRow("FoodID");
                                iPromo.DrinkCategoryID = oRow("DrinkCategoryID");
                                iPromo.DrinkID = oRow("DrinkID");
                                iPromo.RoutingID = oRow("RoutingID");
                                iPromo.PrintPriorityID = oRow("PrintPriorityID");

                                iPromo.ItemStatus = 8;
                                oRow("ForceFreeID") = -8;
                                oRow("ForceFreeAuth") = empID;
                                oRow("ItemStatus") = 8;

                                iPromo.CheckNumber = TransCheckNumber;  // 1  'oRow("CheckNumber")
                                iPromo.CustomerNumber = oRow("CustomerNumber");
                                iPromo.CourseNumber = oRow("CourseNumber");

                                iPromo.openOrderID = oRow("OpenOrderID");
                                iPromo.taxID = oRow("TaxID");

                                if (oRow("sii") < oRow("sin"))   // <> valueSIN Then
                                {
                                    // we populate openOrder we increase sin by 1, now they equal
                                    if (currentTable.ReferenceSIN == 0)
                                    {
                                        currentTable.ReferenceSIN = currentTable.SIN + 1;
                                    }
                                }
                                else
                                {
                                    currentTable.ReferenceSIN = currentTable.SIN + 1;
                                }
                                iPromo.sii = currentTable.ReferenceSIN;
                                iPromo.si2 = oRow("si2");

                                CompThisItem(iPromo);

                            }
                        }

                    }
                }
            }

            else if (TransAllTableFlag == true)
            {
                foreach (DataRowView currentORow2 in dvOrder)
                {
                    oRow = currentORow2;             // dsOrder.Tables("OpenOrders").Rows
                    if (!(oRow.Row.RowState == DataRowState.Deleted) & !(oRow.Row.RowState == DataRowState.Detached))
                    {
                        if (oRow("ExperienceNumber") == TransExpNumber)
                        {
                            if (!(oRow("ForceFreeID") == 9) & !(oRow("ForceFreeID") == 8) & !(oRow("ForceFreeID") == -9) & !(oRow("ForceFreeID") == -8))
                            {
                                // ALREADY comp'd or transfered
                                // AddTransferedItemsToOpenOrder(oRow, empID, expNum)

                                GenerateOrderTables.CopyViewForTransferItem(oRow, empID, expNum, true, default);

                                iPromo.empID = actingManager.EmployeeID;
                                iPromo.PromoName = "   ** Transfer: " + oRow("TerminalName");
                                iPromo.ItemID = oRow("ItemID");
                                iPromo.Quantity = oRow("Quantity") * -1;
                                iPromo.InvMultiplier = oRow("OpenDecimal1");
                                iPromo.ItemPrice = oRow("ItemPrice");
                                iPromo.Price = oRow("Price");
                                iPromo.TaxPrice = oRow("TaxPrice");
                                iPromo.SinTax = oRow("SinTax");
                                iPromo.FunctionID = oRow("FunctionID");
                                iPromo.FunctionGroup = oRow("FunctionGroupID");
                                iPromo.FunctionFlag = oRow("FunctionFlag");
                                iPromo.CategoryID = oRow("CategoryID");
                                iPromo.FoodID = oRow("FoodID");
                                iPromo.DrinkCategoryID = oRow("DrinkCategoryID");
                                iPromo.DrinkID = oRow("DrinkID");
                                iPromo.RoutingID = oRow("RoutingID");
                                iPromo.PrintPriorityID = oRow("PrintPriorityID");

                                iPromo.ItemStatus = 8;
                                oRow("ForceFreeID") = -8;
                                oRow("ForceFreeAuth") = empID;
                                oRow("ItemStatus") = 8;

                                iPromo.CheckNumber = oRow("CheckNumber");
                                iPromo.CustomerNumber = oRow("CustomerNumber");
                                iPromo.CourseNumber = oRow("CourseNumber");

                                iPromo.openOrderID = oRow("OpenOrderID");
                                iPromo.taxID = oRow("TaxID");


                                if (oRow("sii") < oRow("sin"))   // <> valueSIN Then
                                {
                                    // we populate openOrder we increase sin by 1, now they equal
                                    if (currentTable.ReferenceSIN == 0)
                                    {
                                        currentTable.ReferenceSIN = currentTable.SIN + 1;
                                    }
                                }
                                else
                                {
                                    currentTable.ReferenceSIN = currentTable.SIN + 1;
                                }
                                iPromo.sii = currentTable.ReferenceSIN;
                                iPromo.si2 = oRow("si2");

                                CompThisItem(iPromo);

                            }
                        }
                    }
                }
            }

            // sql.cn.Close()
            foreach (SelectedItemDetail ni in newItemCollection)
                GenerateOrderTables.PopulateDataRowForOpenOrder(ni);
            newItemCollection.Clear();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
            newItemCollection.Clear();
        }

    }

    private void UpdateTramsferCheckExperience222(long expNum)
    {

        DataRow oRow;
        // Dim bRow As DataRow

        if (currentTable.IsTabNotTable == true)
        {
            foreach (DataRow currentORow in dsOrder.Tables("AvailTabs").Rows)
            {
                oRow = currentORow;
                if (oRow("ExperienceNumber") == expNum)
                {
                    oRow("LastStatusTime") = DateTime.Now;
                    oRow("TabName") = "Transf " + oRow("TabName");
                    oRow("LastStatus") = 1;
                    oRow("ClosedSubTotal") = 0;
                }
            }
        }
        // bRow = (dsBackup.Tables("AvailTabsTerminal").Rows.Find(expNum))
        // If Not (bRow Is Nothing) Then
        // bRow("LastStatus") = 1
        // bRow("LastStatusTime") = Now
        // '          bRow("TabName") = "Transf " & oRow("TabName")
        // End If
        else
        {
            foreach (DataRow currentORow1 in dsOrder.Tables("AvailTables").Rows)
            {
                oRow = currentORow1;
                if (oRow("ExperienceNumber") == expNum)
                {
                    oRow("LastStatusTime") = DateTime.Now;
                    oRow("TabName") = "Transf " + oRow("TabName");
                    oRow("LastStatus") = 1;
                    oRow("ClosedSubTotal") = 0;
                }
            }
            // bRow = (dsBackup.Tables("AvailTablesTerminal").Rows.Find(expNum))
            // If Not (bRow Is Nothing) Then
            // '          bRow("LastStatus") = 1
            // bRow("LastStatusTime") = Now
            // bRow("TabName") = "Transf " & oRow("TabName")
            // End If
        }

    }

    private void AddTransferedItemsToOpenOrder222(ref DataRow oRow, int empID, long expNum)
    {
        // in OpenOrders make duplicate all orders for check(s) with TransferedTo flag TRUE

        // ***************************
        // *** this is wrong
        // should look something like  GenerateOrderTables.AddItemViewToOpenOrders
        // we changed the database schematic

        sql.SqlInsertCommandOpenOrdersSP.Parameters("@CompanyID").Value = oRow("CompanyID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@LocationID").Value = oRow("LocationID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@DailyCode").Value = oRow("DailyCode");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@ExperienceNumber").Value = expNum;
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@OrderNumber").Value = oRow("OrderNumber");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@ShiftID").Value = oRow("ShiftID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@MenuID").Value = oRow("MenuID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@EmployeeID").Value = empID;
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@TableNumber").Value = oRow("TableNumber");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@TabID").Value = oRow("TabID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@TabName").Value = oRow("TabName");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@CheckNumber").Value = oRow("CheckNumber");   // ??
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@CustomerNumber").Value = oRow("CustomerNumber");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@CourseNumber").Value = oRow("CourseNumber");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@sin").Value = oRow("sin");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@sii").Value = oRow("sii");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@Quantity").Value = oRow("Quantity");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@ItemID").Value = oRow("ItemID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@ItemName").Value = oRow("ItemName");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@Price").Value = oRow("Price");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@TaxPrice").Value = oRow("TaxPrice");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@TaxID").Value = oRow("TaxID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@ForceFreeID").Value = oRow("ForceFreeID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@ForceFreeAuth").Value = oRow("ForceFreeAuth");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@ForceFreeCode").Value = oRow("ForceFreeCode");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@FunctionID").Value = oRow("FunctionID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@FunctionGroupID").Value = oRow("FunctionGroupID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@FunctionFlag").Value = oRow("FunctionFlag");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@CategoryID").Value = oRow("CategoryID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@FoodID").Value = oRow("FoodID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@DrinkCategoryID").Value = oRow("DrinkCategoryID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@DrinkID").Value = oRow("DrinkID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@ItemStatus").Value = oRow("ItemStatus"); // 9
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@RoutingID").Value = oRow("RoutingID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@PrintPriorityID").Value = oRow("PrintPriorityID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@Repeat").Value = 1;  // oRow("Repeat")
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@TerminalID").Value = oRow("TerminalID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@dbUP").Value = 1;

        // sql.cn.Open()
        // sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery()
        sql.SqlInsertCommandOpenOrdersSP.ExecuteNonQuery();
        // sql.cn.Close()

    }

    private object AddTransferedExperience(int empID)
    {

        var transferExpNumber = default(long);
        DataRowView oRow;
        var loginTrackID = default(long);
        // empID is for the new employee

        // with Quick Tickets, we will always transfer to 
        // new experience.. therefore no need for quick ticket routine here

        // first determine if we have experience number for this transfer
        if (currentTable.IsTabNotTable == true)
        {
            foreach (DataRowView currentORow in dvAvailTabs)
            {
                oRow = currentORow;    // dsOrder.Tables("AvailTabs").Rows
                if (oRow("EmployeeID") == empID)
                {
                    if (oRow("TabID") == currentTable.TabID)
                    {
                        transferExpNumber = oRow("ExperienceNumber");
                    }
                }
            }
        }
        else
        {
            foreach (DataRowView currentORow1 in dvAvailTables)
            {
                oRow = currentORow1;  // dsOrder.Tables("AvailTables").Rows
                if (oRow("EmployeeID") == empID)
                {
                    if (oRow("TableNumber") == currentTable.TableNumber)
                    {
                        transferExpNumber = oRow("ExperienceNumber");
                    }
                }
            }
        }

        foreach (Employee emp in AllEmployees)
        {
            if (emp.EmployeeID == empID)
            {
                loginTrackID = emp.LoginTrackingID;
                break;
            }
        }
        if (loginTrackID == default | loginTrackID == 0L)
        {
            loginTrackID = currentServer.LoginTrackingID;
        }

        if (transferExpNumber == 0L)
        {
            transferExpNumber = CreateNewExperience(empID, currentTable.TableNumber, currentTable.TabID, currentTable.TabName, currentTable.NumberOfCustomers, 8, 0, currentTable.ItemsOnHold, loginTrackID);
        }
        else
        {
            currentTable.NumberOfChecks += 1;
            AddOneMoreCheckNumber(transferExpNumber);
        }

        return transferExpNumber;

    }

    private void AddOneMoreCheckNumber(long expNum)
    {
        DataRow oRow;

        // with Quick Tickets, we will always transfer to 
        // new experience.. therefore no need for quick ticket routine here

        if (currentTable.IsTabNotTable == true)
        {
            foreach (DataRow currentORow in dsOrder.Tables("AvailTabs").Rows)
            {
                oRow = currentORow;
                if (oRow("ExperienceNumber") == expNum)
                {
                    oRow("NumberOfChecks") += 1;
                }
            }
        }
        else
        {
            foreach (DataRow currentORow1 in dsOrder.Tables("AvailTables").Rows)
            {
                oRow = currentORow1;
                if (oRow("ExperienceNumber") == expNum)
                {
                    oRow("NumberOfChecks") += 1;
                }
            }
        }

        // possible change 
        // ************ ???? only need to update experience table
        // probably do not need at all (will do anyway next step)
        // UpdateOpenOrdersAfterTransfer()

    }

    private void btnTransCancel_Click(object sender, EventArgs e)
    {
        this.Dispose();

    }



    private void btnAccept_Click(object sender, EventArgs e)
    {

        if (empIDTransferTo == 0)
            return;
        long transferExpNumber;

        // check to determine if any other check # with this table# has been transfered
        // if not create another experience number
        transferExpNumber = Conversions.ToLong(AddTransferedExperience(empIDTransferTo));

        ChangeItemStatusPriorTrans(empIDTransferTo, transferExpNumber);

        if (typeProgram == "Online_Demo")
        {
            if (currentTable.IsTabNotTable == false)
            {
                dsOrderDemo.Merge(dsOrder.Tables("AvailTables"), false, MissingSchemaAction.Add);
            }
            else
            {
                dsOrderDemo.Merge(dsOrder.Tables("AvailTabs"), false, MissingSchemaAction.Add);
            }

            dsOrder.Tables("AvailTables").Clear();
            dsOrder.Tables("AvailTabs").Clear();

            string filterString;
            string NotfilterString;
            filterString = "EmployeeID = " + currentTable.EmployeeID;
            NotfilterString = "NOT EmployeeID = " + currentTable.EmployeeID;
            Demo_FilterDemoDataTabble(dsOrderDemo.Tables("AvailTables"), dsOrder.Tables("AvailTables"), filterString, NotfilterString);
            Demo_FilterDemoDataTabble(dsOrderDemo.Tables("AvailTabs"), dsOrder.Tables("AvailTabs"), filterString, NotfilterString);
        }

        // If remainingChecks = False Then
        if (_transCheckFlag == true)
        {
            currentTable.NumberOfChecks -= 1;
            if (currentTable.NumberOfChecks == 0)
            {
                UpdatingCurrentTables?.Invoke(true);
                return;
            }
        }
        if (_transAllTableFlag == true)
        {
            UpdatingCurrentTables?.Invoke(true);
            return;
        }
        // only if we have checks or items left
        UpdatingCurrentTables?.Invoke(false);

    }

    private void btnTransAllFloor_Click(object sender, EventArgs e)
    {

        lstTransNames.Items.Clear();
        ResetColorPersonnelButtons();
        btnTransTodaysFloor.BackColor = c6;
        btnTransTodaysFloor.ForeColor = c3;
        PopulateTransListView(ref allFloorPersonnel);

    }
}