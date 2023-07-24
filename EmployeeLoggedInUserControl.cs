using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;


public partial class EmployeeLoggedInUserControl : System.Windows.Forms.UserControl
{

    // Dim sql As New DataSet_Builder.SQLHelper(connectserver)

    private int empRowNumber;
    private int empColNumber;
    private bool isByEmployee;
    private ArrayList employeeRemovingList = new ArrayList();
    private DataView employeeDataview;

    private bool logoutErased;

    private DataSet_Builder.NumberPadMedium _NumberPadEmployee2;

    internal virtual DataSet_Builder.NumberPadMedium NumberPadEmployee2
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _NumberPadEmployee2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_NumberPadEmployee2 != null)
            {
                _NumberPadEmployee2.NumberEntered -= NumberPad_EnterClick;
            }

            _NumberPadEmployee2 = value;
            if (_NumberPadEmployee2 != null)
            {
                _NumberPadEmployee2.NumberEntered += NumberPad_EnterClick;
            }
        }
    }

    public event ClosedEmployeeLogEventHandler ClosedEmployeeLog;

    public delegate void ClosedEmployeeLogEventHandler(object sender, EventArgs e);


    #region  Windows Form Designer generated code 

    public EmployeeLoggedInUserControl(bool byEmp) : base()
    {

        isByEmployee = byEmp;

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
                _btnApplySplit.Click -= btnApplySplit_Click_1;
            }

            _btnApplySplit = value;
            if (_btnApplySplit != null)
            {
                _btnApplySplit.Click += btnApplySplit_Click_1;
            }
        }
    }
    private DataSet_Builder.NumberPadEmployee _NumberPadEmployee1;

    internal virtual DataSet_Builder.NumberPadEmployee NumberPadEmployee1
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _NumberPadEmployee1;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_NumberPadEmployee1 != null)
            {
                _NumberPadEmployee1.NumberEntered -= NewClockInEntered_Click;
            }

            _NumberPadEmployee1 = value;
            if (_NumberPadEmployee1 != null)
            {
                _NumberPadEmployee1.NumberEntered += NewClockInEntered_Click;
            }
        }
    }
    private Global.System.Windows.Forms.DataGrid _grdEmpoyeeLoggedIn;

    internal virtual Global.System.Windows.Forms.DataGrid grdEmpoyeeLoggedIn
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _grdEmpoyeeLoggedIn;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_grdEmpoyeeLoggedIn != null)
            {
                _grdEmpoyeeLoggedIn.CurrentCellChanged -= grdEmpoyeeLoggedIn_Slected;
            }

            _grdEmpoyeeLoggedIn = value;
            if (_grdEmpoyeeLoggedIn != null)
            {
                _grdEmpoyeeLoggedIn.CurrentCellChanged += grdEmpoyeeLoggedIn_Slected;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblEmployeeLoggedIn;

    internal virtual Global.System.Windows.Forms.Label lblEmployeeLoggedIn
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblEmployeeLoggedIn;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblEmployeeLoggedIn = value;
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
    private Global.System.Windows.Forms.Button _btnEraseLogout;

    internal virtual Global.System.Windows.Forms.Button btnEraseLogout
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnEraseLogout;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnEraseLogout != null)
            {
                _btnEraseLogout.Click -= btnEraseLogout_Click;
            }

            _btnEraseLogout = value;
            if (_btnEraseLogout != null)
            {
                _btnEraseLogout.Click += btnEraseLogout_Click;
            }
        }
    }
    private Global.System.Windows.Forms.Label _lblNumberClockedIn;

    internal virtual Global.System.Windows.Forms.Label lblNumberClockedIn
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblNumberClockedIn;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblNumberClockedIn = value;
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _Panel1 = new System.Windows.Forms.Panel();
        _btnEraseLogout = new System.Windows.Forms.Button();
        _btnEraseLogout.Click += btnEraseLogout_Click;
        _grdEmpoyeeLoggedIn = new System.Windows.Forms.DataGrid();
        _grdEmpoyeeLoggedIn.CurrentCellChanged += grdEmpoyeeLoggedIn_Slected;
        _NumberPadEmployee1 = new DataSet_Builder.NumberPadEmployee();
        _NumberPadEmployee1.NumberEntered += NewClockInEntered_Click;
        _btnCancel = new System.Windows.Forms.Button();
        _btnCancel.Click += btnCancel_Click;
        _btnApplySplit = new System.Windows.Forms.Button();
        _btnApplySplit.Click += btnApplySplit_Click_1;
        _lblEmployeeLoggedIn = new System.Windows.Forms.Label();
        _lblNumberClockedIn = new System.Windows.Forms.Label();
        _Panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_grdEmpoyeeLoggedIn).BeginInit();
        this.SuspendLayout();
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.Color.RoyalBlue;
        _Panel1.Controls.Add(_btnEraseLogout);
        _Panel1.Controls.Add(_grdEmpoyeeLoggedIn);
        _Panel1.Controls.Add(_NumberPadEmployee1);
        _Panel1.Controls.Add(_btnCancel);
        _Panel1.Controls.Add(_btnApplySplit);
        _Panel1.Location = new System.Drawing.Point(8, 48);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(776, 360);
        _Panel1.TabIndex = 0;
        // 
        // btnEraseLogout
        // 
        _btnEraseLogout.Location = new System.Drawing.Point(48, 296);
        _btnEraseLogout.Name = "_btnEraseLogout";
        _btnEraseLogout.Size = new System.Drawing.Size(96, 40);
        _btnEraseLogout.TabIndex = 14;
        _btnEraseLogout.Text = "Erase Logout";
        // 
        // grdEmpoyeeLoggedIn
        // 
        _grdEmpoyeeLoggedIn.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
        _grdEmpoyeeLoggedIn.CaptionVisible = false;
        _grdEmpoyeeLoggedIn.DataMember = "";
        _grdEmpoyeeLoggedIn.Font = new System.Drawing.Font("Bookman Old Style", 9.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _grdEmpoyeeLoggedIn.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _grdEmpoyeeLoggedIn.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        _grdEmpoyeeLoggedIn.Location = new System.Drawing.Point(8, 8);
        _grdEmpoyeeLoggedIn.Name = "_grdEmpoyeeLoggedIn";
        _grdEmpoyeeLoggedIn.PreferredRowHeight = 30;
        _grdEmpoyeeLoggedIn.ReadOnly = true;
        _grdEmpoyeeLoggedIn.RowHeadersVisible = false;
        _grdEmpoyeeLoggedIn.Size = new System.Drawing.Size(560, 272);
        _grdEmpoyeeLoggedIn.TabIndex = 13;
        // 
        // NumberPadEmployee1
        // 
        _NumberPadEmployee1.AM_PMEnter = (object)null;
        _NumberPadEmployee1.BackColor = System.Drawing.Color.SlateGray;
        _NumberPadEmployee1.DayEnter = 0;
        _NumberPadEmployee1.HourEnter = 0;
        _NumberPadEmployee1.Location = new System.Drawing.Point(576, 8);
        _NumberPadEmployee1.MinuteEnter = 0;
        _NumberPadEmployee1.MonthEnter = 0;
        _NumberPadEmployee1.Name = "_NumberPadEmployee1";
        _NumberPadEmployee1.Size = new System.Drawing.Size(192, 344);
        _NumberPadEmployee1.TabIndex = 12;
        _NumberPadEmployee1.YearEnter = 0;
        // 
        // btnCancel
        // 
        _btnCancel.BackColor = System.Drawing.Color.LightSlateGray;
        _btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
        _btnCancel.Location = new System.Drawing.Point(288, 296);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.Size = new System.Drawing.Size(88, 48);
        _btnCancel.TabIndex = 11;
        _btnCancel.Text = "Cancel";
        // 
        // btnApplySplit
        // 
        _btnApplySplit.BackColor = System.Drawing.Color.Red;
        _btnApplySplit.Location = new System.Drawing.Point(408, 296);
        _btnApplySplit.Name = "_btnApplySplit";
        _btnApplySplit.Size = new System.Drawing.Size(128, 48);
        _btnApplySplit.TabIndex = 8;
        _btnApplySplit.Text = "Apply";
        // 
        // lblEmployeeLoggedIn
        // 
        _lblEmployeeLoggedIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblEmployeeLoggedIn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _lblEmployeeLoggedIn.Location = new System.Drawing.Point(136, 16);
        _lblEmployeeLoggedIn.Name = "_lblEmployeeLoggedIn";
        _lblEmployeeLoggedIn.Size = new System.Drawing.Size(400, 24);
        _lblEmployeeLoggedIn.TabIndex = 1;
        _lblEmployeeLoggedIn.Text = "Current Employees Clocked-In SpiderPOS:";
        _lblEmployeeLoggedIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblNumberClockedIn
        // 
        _lblNumberClockedIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblNumberClockedIn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _lblNumberClockedIn.Location = new System.Drawing.Point(544, 16);
        _lblNumberClockedIn.Name = "_lblNumberClockedIn";
        _lblNumberClockedIn.Size = new System.Drawing.Size(86, 24);
        _lblNumberClockedIn.TabIndex = 2;
        _lblNumberClockedIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // EmployeeLoggedInUserControl
        // 
        this.BackColor = System.Drawing.Color.SlateGray;
        this.Controls.Add(_lblNumberClockedIn);
        this.Controls.Add(_lblEmployeeLoggedIn);
        this.Controls.Add(_Panel1);
        this.Name = "EmployeeLoggedInUserControl";
        this.Size = new System.Drawing.Size(792, 416);
        _Panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_grdEmpoyeeLoggedIn).EndInit();
        this.ResumeLayout(false);

    }

    #endregion


    private void InitializeOther()
    {

        CreateEmpDataview();
        BindEmployeeGrid();

        if (isByEmployee == true)
        {
            if (empActive is null)
            {
                lblEmployeeLoggedIn.Text = currentServer.FullName;
            }
            else
            {
                lblEmployeeLoggedIn.Text = empActive.FullName;
            }
            btnEraseLogout.Visible = false;
        }
        else
        {
            lblNumberClockedIn.Text = employeeDataview.Count.ToString;
        }

        NumberPadEmployee2 = new DataSet_Builder.NumberPadMedium();
        NumberPadEmployee2.DecimalUsed = true;
        NumberPadEmployee2.Location = new Point(648, 8);
        NumberPadEmployee2.Visible = false;
        Panel1.Controls.Add(NumberPadEmployee2);

    }

    private void CreateEmpDataview()
    {

        employeeDataview = new DataView();

        {
            ref var withBlock = ref employeeDataview;
            withBlock.Table = dsEmployee.Tables("LoggedInEmployees");
            // .RowFilter = "ClockInReq = 1"
        }

    }
    private void BindEmployeeGrid()
    {

        // *** can pull a dataview here with non salaried employees (or no clock in)
        grdEmpoyeeLoggedIn.DataSource = dsEmployee.Tables("LoggedInEmployees");
        // employeeDataview() '

        var tsEmployeeLoggedIn = new DataGridTableStyle();
        tsEmployeeLoggedIn.MappingName = "LoggedInEmployees";
        tsEmployeeLoggedIn.RowHeadersVisible = false;
        tsEmployeeLoggedIn.AllowSorting = false;
        tsEmployeeLoggedIn.GridLineColor = Color.White;

        var csEmpNum = new DataGridTextBoxColumn();
        csEmpNum.MappingName = "EmployeeID";
        if (isByEmployee == true)
        {
            csEmpNum.Width = 0;
        }
        else
        {
            csEmpNum.Width = 0;
        }

        var csEmpFirst = new DataGridTextBoxColumn();
        csEmpFirst.MappingName = "FirstName";
        if (isByEmployee == true)
        {
            csEmpFirst.Width = 0;
        }
        else
        {
            csEmpFirst.Width = 68;
        }

        // Dim csBlank As New DataGridTextBoxColumn
        // csBlank.HeaderText = "   "
        // If isByEmployee = True Then
        // csBlank.Width = 0
        // Else
        // csBlank.Width = 20
        // End If

        var csEmpLast = new DataGridTextBoxColumn();
        csEmpLast.MappingName = "LastName";
        if (isByEmployee == true)
        {
            csEmpLast.Width = 0;
        }
        else
        {
            csEmpLast.Width = 128;
        }

        var csLogIn = new DataGridTextBoxColumn();
        csLogIn.MappingName = "LogInTime";
        csLogIn.Width = 175;
        csLogIn.HeaderText = "          Login";

        var csLogOut = new DataGridTextBoxColumn();
        csLogOut.MappingName = "LogOutTime";
        csLogOut.Width = 175;
        csLogOut.HeaderText = "          Logout";
        csLogOut.NullText = "";

        var csCharges = new DataGridTextBoxColumn();
        csCharges.MappingName = "TipableSales";
        if (isByEmployee == true)
        {
            csCharges.Width = 65;
            csCharges.HeaderText = "  Sales";
        }
        else
        {
            csCharges.Width = 0;
        }
        csCharges.NullText = "";

        var csChargeTips = new DataGridTextBoxColumn();
        csChargeTips.MappingName = "ChargedTips";
        if (isByEmployee == true)
        {
            csChargeTips.Width = 63;
            csChargeTips.HeaderText = "Chg Tips";
        }
        else
        {
            csChargeTips.Width = 0;
        }
        csChargeTips.NullText = "";

        var csTips = new DataGridTextBoxColumn();
        csTips.MappingName = "DeclaredTips";
        if (isByEmployee == true)
        {
            csTips.Width = 63;
            csTips.HeaderText = "   Tips";
        }
        else
        {
            csTips.Width = 0;
        }
        csTips.NullText = "";

        // Dim csTerminals As New DataGridTextBoxColumn
        // csTerminals.MappingName = "TerminalsGroupID"
        // csTerminals.Width = 0


        tsEmployeeLoggedIn.GridColumnStyles.Add(csEmpNum);
        tsEmployeeLoggedIn.GridColumnStyles.Add(csEmpFirst);
        // tsEmployeeLoggedIn.GridColumnStyles.Add(csBlank)
        tsEmployeeLoggedIn.GridColumnStyles.Add(csEmpLast);
        tsEmployeeLoggedIn.GridColumnStyles.Add(csLogIn);
        tsEmployeeLoggedIn.GridColumnStyles.Add(csLogOut);
        tsEmployeeLoggedIn.GridColumnStyles.Add(csCharges);
        tsEmployeeLoggedIn.GridColumnStyles.Add(csChargeTips);
        tsEmployeeLoggedIn.GridColumnStyles.Add(csTips);
        // tsEmployeeLoggedIn.GridColumnStyles.Add(csTerminals)

        grdEmpoyeeLoggedIn.TableStyles.Add(tsEmployeeLoggedIn);

    }

    private void grdEmpoyeeLoggedIn_Slected(object sender, EventArgs e)
    {
        var currentMonth = default(int);
        var currentDay = default(int);
        var currentYear = default(int);
        var currentHour = default(int);
        var currentMinute = default(int);
        var currentAMPM = default(string);

        if (logoutErased == false)
        {
            NewClockInEntered_Click(sender, e);
        }
        else
        {
            logoutErased = false;
        }

        empRowNumber = grdEmpoyeeLoggedIn.CurrentCell.RowNumber;
        empColNumber = grdEmpoyeeLoggedIn.CurrentCell.ColumnNumber;

        if (empColNumber == 3)
        {
            // this is to adjust log in time
            currentMonth = Strings.Format(this.grdEmpoyeeLoggedIn(empRowNumber, 3), "MM,dd,yyyy").ToString.Substring(0, 2);
            currentDay = Strings.Format(this.grdEmpoyeeLoggedIn(empRowNumber, 3), "MM,dd,yyyy").ToString.Substring(3, 2);
            currentYear = Strings.Format(this.grdEmpoyeeLoggedIn(empRowNumber, 3), "MM,dd,yyyy").ToString.Substring(6, 4);
            currentHour = Strings.Format(this.grdEmpoyeeLoggedIn(empRowNumber, 3), "hh,mm,tt").ToString.Substring(0, 2);
            currentMinute = Strings.Format(this.grdEmpoyeeLoggedIn(empRowNumber, 3), "hh,mm,tt").ToString.Substring(3, 2);
            currentAMPM = Strings.Format(this.grdEmpoyeeLoggedIn(empRowNumber, 3), "hh,mm,tt").ToString.Substring(6, 2);
        }


        else if (empColNumber == 4)
        {
            // this is for log out time
            if (object.ReferenceEquals(this.grdEmpoyeeLoggedIn(empRowNumber, 4), DBNull.Value))
            {

                currentMonth = Conversions.ToInteger(Strings.Format(DateTime.Now, "MM,dd,yyyy").ToString().Substring(0, 2));
                currentDay = Conversions.ToInteger(Strings.Format(DateTime.Now, "MM,dd,yyyy").ToString().Substring(3, 2));
                currentYear = Conversions.ToInteger(Strings.Format(DateTime.Now, "MM,dd,yyyy").ToString().Substring(6, 4));
                currentHour = Conversions.ToInteger(Strings.Format(DateTime.Now, "hh,mm,tt").ToString().Substring(0, 2)); // (11, 2))
                currentMinute = Conversions.ToInteger(Strings.Format(DateTime.Now, "hh,mm,tt").ToString().Substring(3, 2)); // (14, 2))
                currentAMPM = Strings.Format(DateTime.Now, "hh,mm,tt").ToString().Substring(6, 2); // (20, 2))
            }

            else
            {
                currentMonth = Strings.Format(this.grdEmpoyeeLoggedIn(empRowNumber, 4), "MM,dd,yyyy").ToString.Substring(0, 2);
                currentDay = Strings.Format(this.grdEmpoyeeLoggedIn(empRowNumber, 4), "MM,dd,yyyy").ToString.Substring(3, 2);
                currentYear = Strings.Format(this.grdEmpoyeeLoggedIn(empRowNumber, 4), "MM,dd,yyyy").ToString.Substring(6, 4);
                currentHour = Strings.Format(this.grdEmpoyeeLoggedIn(empRowNumber, 4), "hh,mm,tt").ToString.Substring(0, 2);
                currentMinute = Strings.Format(this.grdEmpoyeeLoggedIn(empRowNumber, 4), "hh,mm,tt").ToString.Substring(3, 2);
                currentAMPM = Strings.Format(this.grdEmpoyeeLoggedIn(empRowNumber, 4), "hh,mm,tt").ToString.Substring(6, 2);

            }
        }

        else if (empColNumber == 6)
        {
            if (object.ReferenceEquals(this.grdEmpoyeeLoggedIn(empRowNumber, 6), DBNull.Value))
            {
                NumberPadEmployee2.NumberTotal = 0;
            }
            else
            {
                NumberPadEmployee2.NumberTotal = this.grdEmpoyeeLoggedIn(empRowNumber, 6);
            }
        }

        // Me.NumberPadEmployee2.ShowNumberString()

        else if (empColNumber == 7)
        {
            if (object.ReferenceEquals(this.grdEmpoyeeLoggedIn(empRowNumber, 7), DBNull.Value))
            {
                NumberPadEmployee2.NumberTotal = 0;
            }
            else
            {
                NumberPadEmployee2.NumberTotal = this.grdEmpoyeeLoggedIn(empRowNumber, 7);
            }

            // Me.NumberPadEmployee2.ShowNumberString()

        }


        if (empColNumber == 3 | empColNumber == 4)
        {
            NumberPadEmployee1.Visible = true;
            NumberPadEmployee2.Visible = false;

            NumberPadEmployee1.MonthEnter = currentMonth;
            NumberPadEmployee1.DayEnter = currentDay;
            NumberPadEmployee1.YearEnter = currentYear;
            NumberPadEmployee1.HourEnter = currentHour;
            NumberPadEmployee1.MinuteEnter = currentMinute;
            NumberPadEmployee1.AM_PMEnter = currentAMPM;

            NumberPadEmployee1.ShowNumberTotal();     // string???
            NumberPadEmployee1.Focus();

            if (empColNumber == 4)
            {
                NewClockInEntered_Click(sender, e);
            }
        }

        else if (empColNumber == 6 | empColNumber == 7)
        {
            NumberPadEmployee1.Visible = false;
            NumberPadEmployee2.Visible = true;


            // Me.NumberPadEmployee2.NumberString = ""
            NumberPadEmployee2.ShowNumberString();
            NumberPadEmployee2.IntegerNumber = 0;
            NumberPadEmployee2.Focus();

        }

    }


    private void NewClockInEntered_Click(object sender, EventArgs e) // btnApplySplit.Click
    {
        NumberPadEmployee1.ReflectChanges();

        DataRow oRow;
        DateTime dateStr;  // System.Data.SqlDbType.datetime
        decimal newTipAmount;
        var info = new CultureInfo("en-US", false);
        Calendar cal;
        cal = info.Calendar;
        int newHour;

        if (NumberPadEmployee1.AM_PMEnter == "PM")
        {
            newHour = NumberPadEmployee1.HourEnter + 12;
            if (newHour == 24)
                newHour = 12;
        }
        else
        {
            newHour = NumberPadEmployee1.HourEnter;
            // if 12:30 AM we need to reflect 00:30
            if (newHour == 12)
                newHour = 0;
        }

        // ****  should have some kind of check for abnormal logout times (anything over 24 hours)

        if (empColNumber == 3)
        {
            dateStr = new DateTime(NumberPadEmployee1.YearEnter, NumberPadEmployee1.MonthEnter, NumberPadEmployee1.DayEnter, newHour, NumberPadEmployee1.MinuteEnter, 0, 15, cal);
            dsEmployee.Tables("LoggedInEmployees").Rows(empRowNumber)("LogInTime") = dateStr;
        }
        else if (empColNumber == 4)
        {
            dateStr = new DateTime(NumberPadEmployee1.YearEnter, NumberPadEmployee1.MonthEnter, NumberPadEmployee1.DayEnter, newHour, NumberPadEmployee1.MinuteEnter, 0, 15, cal);
            // MsgBox(dateStr)
            // MsgBox(Now)

            // ***********
            // if empcolnumber = 4 and currentinfo IS NULL (emp was not logged out)
            // we must determine which tables are being held by employee before we log them out


            dsEmployee.Tables("LoggedInEmployees").Rows(empRowNumber)("LogOutTime") = dateStr;
            employeeRemovingList.Add(this.grdEmpoyeeLoggedIn(empRowNumber, 0));
        }

        else if (empColNumber == 6)
        {
            newTipAmount = NumberPadEmployee2.NumberTotal; // Format(Me.NumberPadEmployee2.NumberTotal, "#,###.00")
            dsEmployee.Tables("LoggedInEmployees").Rows(empRowNumber)("ChargedTips") = newTipAmount;
        }

        else if (empColNumber == 7)
        {
            newTipAmount = NumberPadEmployee2.NumberTotal; // Format(Me.NumberPadEmployee2.NumberTotal, "#,###.00")
            dsEmployee.Tables("LoggedInEmployees").Rows(empRowNumber)("DeclaredTips") = newTipAmount;
        }

    }

    private void NumberPad_EnterClick(object sender, EventArgs e)
    {

        NewClockInEntered_Click(sender, e);

    }

    private void btnApplySplit_Click_1(object sender, EventArgs e)
    {

        int i;
        if (logoutErased == false)
        {
            NewClockInEntered_Click(sender, e);
        }

        if (typeProgram == "Online_Demo")
        {
            Interaction.MsgBox("Demo does not allow. Licensed program will allow you to clock last night's employees out.");

            dsEmployee.Tables("LoggedInEmployees").RejectChanges();
            ClosedEmployeeLog?.Invoke(sender, e);
            this.Dispose();
            return;
            int empID;

            empID = this.grdEmpoyeeLoggedIn(empRowNumber, 0);
            foreach (DataRow oRow in dsEmployee.Tables("LoggedInEmployees").Rows)
            {
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (empID == oRow("EmployeeID"))
                    {
                        oRow.Delete();
                        this.Dispose();
                        return;
                    }
                }
            }
            this.Dispose();
            return;
        }

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            if (isByEmployee == false)
            {

                sql.SqlClockedInList.Update(dsEmployee.Tables("LoggedInEmployees"));
            }
            else
            {

                sql.SqlCLockedInByEmp.Update(dsEmployee.Tables("LoggedInEmployees"));
            }
            sql.cn.Close();

            dsEmployee.Tables("LoggedInEmployees").AcceptChanges();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
            if (Information.Err().Number == Conversions.ToDouble("5"))
            {
                ServerJustWentDown();
            }
            // we might want to put something here to keep track of clock outs when down
        }

        ClosedEmployeeLog?.Invoke(sender, e);
        this.Dispose();

    }

    private void btnCancel_Click(object sender, EventArgs e)
    {

        dsEmployee.Tables("LoggedInEmployees").RejectChanges();

        ClosedEmployeeLog?.Invoke(sender, e);
        this.Dispose();

    }


    private void btnEraseLogout_Click(object sender, EventArgs e)
    {

        if (!object.ReferenceEquals(dsEmployee.Tables("LoggedInEmployees").Rows(empRowNumber)("LogOutTime"), DBNull.Value))
        {
            dsEmployee.Tables("LoggedInEmployees").Rows(empRowNumber)("LogOutTime") = DBNull.Value;
            employeeRemovingList.Remove(this.grdEmpoyeeLoggedIn(empRowNumber, 0));
            logoutErased = true;
        }

    }
}