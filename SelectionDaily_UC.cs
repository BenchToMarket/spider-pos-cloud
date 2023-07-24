using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;


public partial class SelectionDaily_UC : System.Windows.Forms.UserControl
{
    // Dim sql As New DataSet_Builder.SQLHelper(connectserver)

    internal long sDailyCode;
    internal int sPrimaryMenu;
    internal int sSecondaryMenu;
    internal string chosenTermMethod;

    public event NewDailyEventHandler NewDaily;

    public delegate void NewDailyEventHandler();
    public event DailySelectedEventHandler DailySelected;

    public delegate void DailySelectedEventHandler(); // ByVal sender As Object, ByVal e As System.EventArgs)

    #region  Windows Form Designer generated code 

    // Dim dvUsing As DataView
    // Dim dtUsing As DataTable

    public SelectionDaily_UC(ref DataView dv) : base()    // dv is dvOpenBusiness
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call

        // Me.SelectionPanel_Daily.dvUsing = New DataView

        SelectionPanel_DailyNew.dvUsing = dv;
        SelectionPanel_DailyNew.dtUsing = ds.Tables("MenuChoice");

        if (dv.Count == 0)
        {
            SelectionPanel_DailyNew.StartOpenNewBusiness();
        }
        else
        {
            SelectionPanel_DailyNew.DetermineButtonSizes();
            SelectionPanel_DailyNew.DetermineButtonLocations();
        }

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
    private Global.System.Windows.Forms.Button _Button6;

    internal virtual Global.System.Windows.Forms.Button Button6
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Button6;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Button6 = value;
        }
    }
    private Global.System.Windows.Forms.Button _Button5;

    internal virtual Global.System.Windows.Forms.Button Button5
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Button5;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Button5 = value;
        }
    }
    private Global.System.Windows.Forms.Button _Button4;

    internal virtual Global.System.Windows.Forms.Button Button4
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Button4;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Button4 = value;
        }
    }
    private Global.System.Windows.Forms.Button _Button3;

    internal virtual Global.System.Windows.Forms.Button Button3
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _Button3;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _Button3 = value;
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
    // Friend WithEvents SelectionPanel_Daily As DataSet_Builder.SelectionPanel_UC
    // Friend WithEvents SelectionPanel_DailyNew As DataSet_Builder.SelectionPanel_UC
    private DataSet_Builder.SelectionPanel_UC _SelectionPanel_DailyNew;

    internal virtual DataSet_Builder.SelectionPanel_UC SelectionPanel_DailyNew
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SelectionPanel_DailyNew;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_SelectionPanel_DailyNew != null)
            {
                _SelectionPanel_DailyNew.ButtonSelected -= OpenDailyBusinessSelected;
                _SelectionPanel_DailyNew.AcceptMenuEvent -= AcceptMenu_Click;
                _SelectionPanel_DailyNew.ChangeMenus -= ChangeMenu_Click;
            }

            _SelectionPanel_DailyNew = value;
            if (_SelectionPanel_DailyNew != null)
            {
                _SelectionPanel_DailyNew.ButtonSelected += OpenDailyBusinessSelected;
                _SelectionPanel_DailyNew.AcceptMenuEvent += AcceptMenu_Click;
                _SelectionPanel_DailyNew.ChangeMenus += ChangeMenu_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnDailyQuick;

    internal virtual Global.System.Windows.Forms.Button btnDailyQuick
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDailyQuick;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnDailyQuick != null)
            {
                _btnDailyQuick.Click -= btnDailyQuick_Click;
            }

            _btnDailyQuick = value;
            if (_btnDailyQuick != null)
            {
                _btnDailyQuick.Click += btnDailyQuick_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnDailyTable;

    internal virtual Global.System.Windows.Forms.Button btnDailyTable
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDailyTable;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnDailyTable != null)
            {
                _btnDailyTable.Click -= btnDailyTable_Click;
            }

            _btnDailyTable = value;
            if (_btnDailyTable != null)
            {
                _btnDailyTable.Click += btnDailyTable_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Button _btnDailyBar;

    internal virtual Global.System.Windows.Forms.Button btnDailyBar
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnDailyBar;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnDailyBar != null)
            {
                _btnDailyBar.Click -= btnDailyBar_Click;
            }

            _btnDailyBar = value;
            if (_btnDailyBar != null)
            {
                _btnDailyBar.Click += btnDailyBar_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblDailyChoose;

    internal virtual Global.System.Windows.Forms.Label lblDailyChoose
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblDailyChoose;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblDailyChoose = value;
        }
    }
    private Global.System.Windows.Forms.Panel _pnlDailyChooseTermMethod;

    internal virtual Global.System.Windows.Forms.Panel pnlDailyChooseTermMethod
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlDailyChooseTermMethod;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlDailyChooseTermMethod = value;
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        var resources = new System.Resources.ResourceManager(typeof(SelectionDaily_UC));
        _Panel1 = new System.Windows.Forms.Panel();
        _Button6 = new System.Windows.Forms.Button();
        _Button5 = new System.Windows.Forms.Button();
        _Button4 = new System.Windows.Forms.Button();
        _Button3 = new System.Windows.Forms.Button();
        _Button2 = new System.Windows.Forms.Button();
        _Button1 = new System.Windows.Forms.Button();
        _Button1.Click += Button1_Click;
        _Label1 = new System.Windows.Forms.Label();
        _SelectionPanel_DailyNew = new DataSet_Builder.SelectionPanel_UC();
        _SelectionPanel_DailyNew.ButtonSelected += OpenDailyBusinessSelected;
        _SelectionPanel_DailyNew.AcceptMenuEvent += AcceptMenu_Click;
        _SelectionPanel_DailyNew.ChangeMenus += ChangeMenu_Click;
        _pnlDailyChooseTermMethod = new System.Windows.Forms.Panel();
        _lblDailyChoose = new System.Windows.Forms.Label();
        _btnDailyBar = new System.Windows.Forms.Button();
        _btnDailyBar.Click += btnDailyBar_Click;
        _btnDailyTable = new System.Windows.Forms.Button();
        _btnDailyTable.Click += btnDailyTable_Click;
        _btnDailyQuick = new System.Windows.Forms.Button();
        _btnDailyQuick.Click += btnDailyQuick_Click;
        _Panel1.SuspendLayout();
        _pnlDailyChooseTermMethod.SuspendLayout();
        this.SuspendLayout();
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.Color.Transparent;
        _Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        _Panel1.Controls.Add(_Button6);
        _Panel1.Controls.Add(_Button5);
        _Panel1.Controls.Add(_Button4);
        _Panel1.Controls.Add(_Button3);
        _Panel1.Controls.Add(_Button2);
        _Panel1.Controls.Add(_Button1);
        _Panel1.Location = new System.Drawing.Point(16, 88);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(128, 448);
        _Panel1.TabIndex = 3;
        // 
        // Button6
        // 
        _Button6.BackColor = System.Drawing.Color.LightSlateGray;
        _Button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button6.Location = new System.Drawing.Point(16, 376);
        _Button6.Name = "_Button6";
        _Button6.Size = new System.Drawing.Size(96, 56);
        _Button6.TabIndex = 5;
        // 
        // Button5
        // 
        _Button5.BackColor = System.Drawing.Color.LightSlateGray;
        _Button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button5.Location = new System.Drawing.Point(16, 304);
        _Button5.Name = "_Button5";
        _Button5.Size = new System.Drawing.Size(96, 56);
        _Button5.TabIndex = 4;
        // 
        // Button4
        // 
        _Button4.BackColor = System.Drawing.Color.LightSlateGray;
        _Button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button4.Location = new System.Drawing.Point(16, 232);
        _Button4.Name = "_Button4";
        _Button4.Size = new System.Drawing.Size(96, 56);
        _Button4.TabIndex = 3;
        // 
        // Button3
        // 
        _Button3.BackColor = System.Drawing.Color.LightSlateGray;
        _Button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button3.Location = new System.Drawing.Point(16, 160);
        _Button3.Name = "_Button3";
        _Button3.Size = new System.Drawing.Size(96, 56);
        _Button3.TabIndex = 2;
        // 
        // Button2
        // 
        _Button2.BackColor = System.Drawing.Color.LightSlateGray;
        _Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button2.Location = new System.Drawing.Point(16, 88);
        _Button2.Name = "_Button2";
        _Button2.Size = new System.Drawing.Size(96, 56);
        _Button2.TabIndex = 1;
        // 
        // Button1
        // 
        _Button1.BackColor = System.Drawing.Color.LightSlateGray;
        _Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _Button1.Location = new System.Drawing.Point(16, 16);
        _Button1.Name = "_Button1";
        _Button1.Size = new System.Drawing.Size(96, 56);
        _Button1.TabIndex = 0;
        _Button1.Text = "Create New Daily Business";
        // 
        // Label1
        // 
        _Label1.BackColor = System.Drawing.Color.Transparent;
        _Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _Label1.Location = new System.Drawing.Point(312, 0);
        _Label1.Name = "_Label1";
        _Label1.Size = new System.Drawing.Size(328, 32);
        _Label1.TabIndex = 4;
        _Label1.Text = "Current Open Daily Business";
        _Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // SelectionPanel_DailyNew
        // 
        _SelectionPanel_DailyNew.BackColor = System.Drawing.Color.LightSlateGray;
        _SelectionPanel_DailyNew.Location = new System.Drawing.Point(160, 32);
        _SelectionPanel_DailyNew.Name = "_SelectionPanel_DailyNew";
        _SelectionPanel_DailyNew.PMenuID = 0;
        _SelectionPanel_DailyNew.Purpose = (object)null;
        _SelectionPanel_DailyNew.Size = new System.Drawing.Size(728, 552);
        _SelectionPanel_DailyNew.SMenuID = 0;
        _SelectionPanel_DailyNew.TabIndex = 5;
        // 
        // pnlDailyChooseTermMethod
        // 
        _pnlDailyChooseTermMethod.Controls.Add(_lblDailyChoose);
        _pnlDailyChooseTermMethod.Controls.Add(_btnDailyBar);
        _pnlDailyChooseTermMethod.Controls.Add(_btnDailyTable);
        _pnlDailyChooseTermMethod.Controls.Add(_btnDailyQuick);
        _pnlDailyChooseTermMethod.Location = new System.Drawing.Point(392, 288);
        _pnlDailyChooseTermMethod.Name = "_pnlDailyChooseTermMethod";
        _pnlDailyChooseTermMethod.Size = new System.Drawing.Size(288, 104);
        _pnlDailyChooseTermMethod.TabIndex = 6;
        _pnlDailyChooseTermMethod.Visible = false;
        // 
        // lblDailyChoose
        // 
        _lblDailyChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblDailyChoose.Location = new System.Drawing.Point(32, 8);
        _lblDailyChoose.Name = "_lblDailyChoose";
        _lblDailyChoose.Size = new System.Drawing.Size(216, 24);
        _lblDailyChoose.TabIndex = 3;
        _lblDailyChoose.Text = "Choose Terminal Method";
        _lblDailyChoose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btnDailyBar
        // 
        _btnDailyBar.BackColor = System.Drawing.Color.CornflowerBlue;
        _btnDailyBar.Location = new System.Drawing.Point(16, 40);
        _btnDailyBar.Name = "_btnDailyBar";
        _btnDailyBar.Size = new System.Drawing.Size(80, 48);
        _btnDailyBar.TabIndex = 2;
        _btnDailyBar.Text = "Bar";
        // 
        // btnDailyTable
        // 
        _btnDailyTable.BackColor = System.Drawing.Color.LightSlateGray;
        _btnDailyTable.Location = new System.Drawing.Point(104, 40);
        _btnDailyTable.Name = "_btnDailyTable";
        _btnDailyTable.Size = new System.Drawing.Size(80, 48);
        _btnDailyTable.TabIndex = 1;
        _btnDailyTable.Text = "Table";
        // 
        // btnDailyQuick
        // 
        _btnDailyQuick.Location = new System.Drawing.Point(192, 40);
        _btnDailyQuick.Name = "_btnDailyQuick";
        _btnDailyQuick.Size = new System.Drawing.Size(80, 48);
        _btnDailyQuick.TabIndex = 0;
        _btnDailyQuick.Text = "Quick";
        // 
        // SelectionDaily_UC
        // 
        this.BackColor = System.Drawing.Color.LightSlateGray;
        this.BackgroundImage = (Global.System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
        this.Controls.Add(_pnlDailyChooseTermMethod);
        this.Controls.Add(_SelectionPanel_DailyNew);
        this.Controls.Add(_Label1);
        this.Controls.Add(_Panel1);
        this.Name = "SelectionDaily_UC";
        this.Size = new System.Drawing.Size(920, 600);
        _Panel1.ResumeLayout(false);
        _pnlDailyChooseTermMethod.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private void InitializeOther()
    {

        TestNumberOpenBusiness(1);
        // If System.Windows.Forms.SystemInformation.ComputerName = "DILEO" Or System.Windows.Forms.SystemInformation.ComputerName = "EGLOBAL" Then
        if (typeProgram == "Demo" | typeProgram == "Online_Demo" | SystemInformation.ComputerName == "EGLOBALMAIN" | SystemInformation.ComputerName == "DILEO")
        {
            pnlDailyChooseTermMethod.Visible = true;
            chosenTermMethod = "Bar";
        }
        else
        {
            chosenTermMethod = currentTerminal.TermMethod;
        }

    }

    private void TestNumberOpenBusiness(int maxAllowed)
    {

        if (dsOrder.Tables("OpenBusiness").Rows.Count > maxAllowed)
        {
            Interaction.MsgBox("You should have only 1 (one) Daily Business Open at a time. The only Daily Code active will be the Last Opened. Please close all others.", MsgBoxStyle.Exclamation);
        }

    }

    private void OpenDailyBusinessSelected(object sender, EventArgs e)
    {

        sDailyCode = Conversions.ToLong(sender.dailyCode);
        sPrimaryMenu = Conversions.ToInteger(sender.PrimaryMenu);
        sSecondaryMenu = Conversions.ToInteger(sender.SecondaryMenu);

        // currentTerminal.currentDailyCode = sender.dailyCode
        if (typeProgram == "Online_Demo")
        {
            if (chosenTermMethod == "Quick")
            {
                ds.ReadXml("Lunch_Dinner_QuickDemo.xml", XmlReadMode.ReadSchema);
            }
            else
            {
                ds.ReadXml("Lunch_Dinner.xml", XmlReadMode.ReadSchema);
            }
            ds.AcceptChanges();
        }

        DailySelected?.Invoke();  // sender, e)

        // Dim info As New DataSet_Builder.Info2_UC("Loading ...")
        // info.Location = New Point((SelectionPanel_DailyNew.Width - info.Width) / 2, (SelectionPanel_DailyNew.Height - info.Height) / 2)
        // Me.SelectionPanel_DailyNew.Controls.Add(info)
        // info.BringToFront()

        this.Dispose();

    }


    private void Button1_Click(object sender, EventArgs e)
    {

        if (typeProgram == "Online_Demo")
        {
            Interaction.MsgBox("Select which module you want. This will take you to the Demo.");
        }
        else
        {
            Interaction.MsgBox("Select the button on the bottom right to open new Daily or Exit and Re-enter spiderPOS.");
        }
        return;

        if (dsOrder.Tables("OpenBusiness").Rows.Count > 0)
        {
            if (Interaction.MsgBox("You should have only 1 (one) Daily Business Open at a time. This new Daily Code will be the only one active. All Tables and Tabs started in other Daily Business will not be available to any Employees. Please Verify Opening New Daily Business.", MsgBoxStyle.OkCancel) == MsgBoxResult.Ok)
            {
                SelectionPanel_DailyNew.ClearSelectionPanel();
                SelectionPanel_DailyNew.StartOpenNewBusiness();
            }
        }

    }

    private void AcceptMenu_Click()
    {


        currentTerminal.primaryMenuID = SelectionPanel_DailyNew.PMenuID;
        currentTerminal.secondaryMenuID = SelectionPanel_DailyNew.SMenuID;
        // RepopulateMenu()

        NewDaily?.Invoke();

        foreach (DataRow oRow in ds.Tables("MenuChoice").Rows)
        {
            if (oRow("MenuID") == currentTerminal.primaryMenuID)
            {
                oRow("LastOrder") = 1;
            }
            else if (oRow("MenuID") == currentTerminal.secondaryMenuID)
            {
                oRow("LastOrder") = 2;
            }
            else
            {
                oRow("LastOrder") = DBNull.Value;
            }
        }

        // 444     If mainServerConnected = True Then
        try
        {
            GenerateOrderTables.TempConnectToPhoenix();
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlDailyMenuChoice.Update(ds.Tables("MenuChoice"));
            ds.Tables("MenuChoice").AcceptChanges();
            sql.cn.Close();
        }

        catch (Exception ex)
        {
            CloseConnection();
            GenerateOrderTables.ConnectBackFromTempDatabase();
            Interaction.MsgBox(ex.Message);
        }
        GenerateOrderTables.ConnectBackFromTempDatabase();
        // 444     End If

        SelectionPanel_DailyNew.Dispose();
        this.Dispose();

    }

    private void ChangeMenu_Click()
    {

        currentTerminal.primaryMenuID = SelectionPanel_DailyNew.PMenuID;
        currentTerminal.secondaryMenuID = SelectionPanel_DailyNew.SMenuID;
        SelectionPanel_DailyNew.Dispose();
        // RaiseEvent NewDaily(sender, e)
        this.Dispose();

    }




    private void btnDailyBar_Click(object sender, EventArgs e)
    {
        btnDailyTable.BackColor = Color.LightSlateGray;
        btnDailyBar.BackColor = Color.CornflowerBlue;
        btnDailyQuick.BackColor = Color.LightSlateGray;
        chosenTermMethod = "Bar";

        TestForDemo();

    }

    private void btnDailyTable_Click(object sender, EventArgs e)
    {
        btnDailyTable.BackColor = Color.CornflowerBlue;
        btnDailyBar.BackColor = Color.LightSlateGray;
        btnDailyQuick.BackColor = Color.LightSlateGray;
        chosenTermMethod = "Table";

        TestForDemo();

    }

    private void btnDailyQuick_Click(object sender, EventArgs e)
    {
        btnDailyTable.BackColor = Color.LightSlateGray;
        btnDailyBar.BackColor = Color.LightSlateGray;
        btnDailyQuick.BackColor = Color.CornflowerBlue;
        chosenTermMethod = "Quick";

        TestForDemo();

    }

    private void TestForDemo()
    {

        if (typeProgram == "Online_Demo")
        {
            if (dsOrder.Tables("OpenBusiness").Rows.Count == 1) // > 0 Then
            {
                sDailyCode = dsOrder.Tables("OpenBusiness").Rows(0)("DailyCode");
                sPrimaryMenu = dsOrder.Tables("OpenBusiness").Rows(0)("PrimaryMenu");
                sSecondaryMenu = dsOrder.Tables("OpenBusiness").Rows(0)("SecondaryMenu");

                if (chosenTermMethod == "Quick")
                {
                    ds.ReadXml("Lunch_Dinner_QuickDemo.xml", XmlReadMode.ReadSchema);
                }
                else
                {
                    ds.ReadXml("Lunch_Dinner.xml", XmlReadMode.ReadSchema);
                }
                ds.AcceptChanges();

                DailySelected?.Invoke();
                this.Dispose();
            }
        }
    }

}