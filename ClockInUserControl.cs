using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DataSet_Builder;


internal partial struct ClockInInfo222
{
    private int _empID;
    private int _passcodeID;
    private int _jobCodeID;
    private decimal _regPayRate;
    private decimal _otPayRate;
    private DateTime _logInTime;


    internal int EmpID
    {
        get
        {
            return _empID;
        }
        set
        {
            _empID = value;
        }
    }

    internal int PasscodeID
    {
        get
        {
            return _passcodeID;
        }
        set
        {
            _passcodeID = value;
        }
    }

    internal int JobCodeID
    {
        get
        {
            return _jobCodeID;
        }
        set
        {
            _jobCodeID = value;
        }
    }

    internal decimal RegPayRate
    {
        get
        {
            return _regPayRate;
        }
        set
        {
            _regPayRate = value;
        }
    }

    internal decimal OTPayRate
    {
        get
        {
            return _otPayRate;
        }
        set
        {
            _otPayRate = value;
        }
    }

    internal DateTime LogInTime
    {
        get
        {
            return _logInTime;
        }
        set
        {
            _logInTime = value;
        }
    }

}

internal partial struct ClockOutInfo
{

    private DateTime _timeIn;
    private DateTime _timeOut;
    private int _shiftHours;
    private int _shiftMins;
    private int _weekHours;
    private int _weekMins;


    private decimal _tipableSales;
    private decimal _declaredTips;
    private decimal _chargedSales;
    private decimal _chargedTips;
    private long _dailyCode;

    internal DateTime TimeIn
    {
        get
        {
            return _timeIn;
        }
        set
        {
            _timeIn = value;
        }
    }

    internal DateTime TimeOut
    {
        get
        {
            return _timeOut;
        }
        set
        {
            _timeOut = value;
        }
    }

    internal int ShiftHours
    {
        get
        {
            return _shiftHours;
        }
        set
        {
            _shiftHours = value;
        }
    }

    internal int ShiftMins
    {
        get
        {
            return _shiftMins;
        }
        set
        {
            _shiftMins = value;
        }
    }

    internal int WeekHours
    {
        get
        {
            return _weekHours;
        }
        set
        {
            _weekHours = value;
        }
    }

    internal int WeekMins
    {
        get
        {
            return _weekMins;
        }
        set
        {
            _weekMins = value;
        }
    }

    internal decimal TipableSales
    {
        get
        {
            return _tipableSales;
        }
        set
        {
            _tipableSales = value;
        }
    }

    internal decimal DeclaredTips
    {
        get
        {
            return _declaredTips;
        }
        set
        {
            _declaredTips = value;
        }
    }

    internal decimal ChargedSales
    {
        get
        {
            return _chargedSales;
        }
        set
        {
            _chargedSales = value;
        }
    }

    internal decimal ChargedTips
    {
        get
        {
            return _chargedTips;
        }
        set
        {
            _chargedTips = value;
        }
    }

    internal long DailyCode
    {
        get
        {
            return _dailyCode;
        }
        set
        {
            _dailyCode = value;
        }
    }

}

public partial class ClockInUserControl : System.Windows.Forms.UserControl
{

    // Dim sql As New DataSet_Builder.SQLHelper(connectserver)
    private Employee emp = new Employee();
    private bool currentPasscodeReq;
    private KitchenButton[] btnJobName = new KitchenButton[7];

    // 222 Friend currentClockIn As New ClockInInfo222

    public event ApplyClockInCheckEventHandler ApplyClockInCheck;

    public delegate void ApplyClockInCheckEventHandler(); // ByVal sender As Object, ByVal e As System.EventArgs)
    public event ClosingClockInEventHandler ClosingClockIn;

    public delegate void ClosingClockInEventHandler(object sender, EventArgs e);


    #region  Windows Form Designer generated code 

    public ClockInUserControl() : base()
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call

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
    private Global.System.Windows.Forms.Button _btnApplyClockIn;

    internal virtual Global.System.Windows.Forms.Button btnApplyClockIn
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _btnApplyClockIn;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_btnApplyClockIn != null)
            {
                _btnApplyClockIn.Click -= btnApplyClockIn_Click;
            }

            _btnApplyClockIn = value;
            if (_btnApplyClockIn != null)
            {
                _btnApplyClockIn.Click += btnApplyClockIn_Click;
            }
        }
    }
    // Friend WithEvents NumberPadSmallClockIn As DataSet_Builder.NumberPadSmall
    private Global.System.Windows.Forms.Panel _pnlJobCodes;

    internal virtual Global.System.Windows.Forms.Panel pnlJobCodes
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _pnlJobCodes;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _pnlJobCodes = value;
        }
    }
    private Global.System.Windows.Forms.Label _lblClockIn;

    internal virtual Global.System.Windows.Forms.Label lblClockIn
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _lblClockIn;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _lblClockIn = value;
        }
    }
    private DataSet_Builder.NumberPadMedium _NumberPadSmallClockIn;

    internal virtual DataSet_Builder.NumberPadMedium NumberPadSmallClockIn
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _NumberPadSmallClockIn;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_NumberPadSmallClockIn != null)
            {
                _NumberPadSmallClockIn.NumberEntered -= ClockIn_Entered;
            }

            _NumberPadSmallClockIn = value;
            if (_NumberPadSmallClockIn != null)
            {
                _NumberPadSmallClockIn.NumberEntered += ClockIn_Entered;
            }
        }
    }
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        _Panel1 = new System.Windows.Forms.Panel();
        _NumberPadSmallClockIn = new DataSet_Builder.NumberPadMedium();
        _NumberPadSmallClockIn.NumberEntered += ClockIn_Entered;
        _pnlJobCodes = new System.Windows.Forms.Panel();
        _btnCancel = new System.Windows.Forms.Button();
        _btnCancel.Click += btnCancel_Click;
        _lblClockIn = new System.Windows.Forms.Label();
        _btnApplyClockIn = new System.Windows.Forms.Button();
        _btnApplyClockIn.Click += btnApplyClockIn_Click;
        _Panel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // Panel1
        // 
        _Panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
        _Panel1.Controls.Add(_NumberPadSmallClockIn);
        _Panel1.Controls.Add(_pnlJobCodes);
        _Panel1.Controls.Add(_btnCancel);
        _Panel1.Controls.Add(_lblClockIn);
        _Panel1.Controls.Add(_btnApplyClockIn);
        _Panel1.Location = new System.Drawing.Point(8, 8);
        _Panel1.Name = "_Panel1";
        _Panel1.Size = new System.Drawing.Size(440, 360);
        _Panel1.TabIndex = 6;
        // 
        // NumberPadSmallClockIn
        // 
        _NumberPadSmallClockIn.BackColor = System.Drawing.Color.SlateGray;
        _NumberPadSmallClockIn.DecimalUsed = false;
        _NumberPadSmallClockIn.ForeColor = System.Drawing.Color.Black;
        _NumberPadSmallClockIn.IntegerNumber = 0;
        _NumberPadSmallClockIn.Location = new System.Drawing.Point(240, 32);
        _NumberPadSmallClockIn.Name = "_NumberPadSmallClockIn";
        _NumberPadSmallClockIn.NumberString = "";
        _NumberPadSmallClockIn.NumberTotal = new decimal(new int[] { 0, 0, 0, 0 });
        _NumberPadSmallClockIn.Size = new System.Drawing.Size(192, 296);
        _NumberPadSmallClockIn.TabIndex = 12;
        // 
        // pnlJobCodes
        // 
        _pnlJobCodes.BackColor = System.Drawing.SystemColors.Info;
        _pnlJobCodes.Location = new System.Drawing.Point(8, 32);
        _pnlJobCodes.Name = "_pnlJobCodes";
        _pnlJobCodes.Size = new System.Drawing.Size(224, 272);
        _pnlJobCodes.TabIndex = 11;
        // 
        // btnCancel
        // 
        _btnCancel.BackColor = System.Drawing.Color.LightSlateGray;
        _btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
        _btnCancel.Location = new System.Drawing.Point(24, 312);
        _btnCancel.Name = "_btnCancel";
        _btnCancel.Size = new System.Drawing.Size(64, 40);
        _btnCancel.TabIndex = 10;
        _btnCancel.Text = "Cancel";
        // 
        // lblClockIn
        // 
        _lblClockIn.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
        _lblClockIn.Dock = System.Windows.Forms.DockStyle.Top;
        _lblClockIn.Font = new System.Drawing.Font("Bookman Old Style", 12.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
        _lblClockIn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
        _lblClockIn.Location = new System.Drawing.Point(0, 0);
        _lblClockIn.Name = "_lblClockIn";
        _lblClockIn.Size = new System.Drawing.Size(440, 24);
        _lblClockIn.TabIndex = 9;
        _lblClockIn.Text = "Clock In";
        _lblClockIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btnApplyClockIn
        // 
        _btnApplyClockIn.BackColor = System.Drawing.Color.LightSlateGray;
        _btnApplyClockIn.Enabled = false;
        _btnApplyClockIn.Location = new System.Drawing.Point(112, 312);
        _btnApplyClockIn.Name = "_btnApplyClockIn";
        _btnApplyClockIn.Size = new System.Drawing.Size(104, 40);
        _btnApplyClockIn.TabIndex = 7;
        _btnApplyClockIn.Text = "Apply";
        // 
        // ClockInUserControl
        // 
        this.BackColor = System.Drawing.SystemColors.Control;
        this.Controls.Add(_Panel1);
        this.ForeColor = System.Drawing.Color.White;
        this.Name = "ClockInUserControl";
        this.Size = new System.Drawing.Size(456, 376);
        _Panel1.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private void ClockIn_Entered(object sender, EventArgs e)
    {

        string loginEnter;

        loginEnter = NumberPadSmallClockIn.NumberString;

        TestClockInFirstStep(loginEnter);

    }

    internal object StartClockIn(string loginEnter)
    {
        bool doesNotneedToClockIn = false;

        if (loginEnter is not null)
        {
            if (loginEnter.Length > 0)
            {
                NumberPadSmallClockIn.NumberString = loginEnter;
                NumberPadSmallClockIn.ShowNumberString();
                doesNotneedToClockIn = Conversions.ToBoolean(TestClockInFirstStep(loginEnter));
            }
        }

        return doesNotneedToClockIn;

    }

    private object TestClockInFirstStep(string loginEnter)
    {
        bool doesNotneedToClockIn = false;
        // Dim loginMatch As Boolean

        if (loginEnter.Length == 8)
        {
            pnlJobCodes.Controls.Clear();
            doesNotneedToClockIn = Conversions.ToBoolean(TestClockIn(loginEnter));
        }
        else
        {
            Interaction.MsgBox("Please Combine Your EmployeeID and Password then Press Enter");
            if (!(loginEnter.Length == 4))
            {
                NumberPadSmallClockIn.ResetValues();
            }
        }

        return doesNotneedToClockIn;

    }

    private object TestClockIn(string loginEnter)
    {
        int empID;
        int passcode;
        int sqlEmpID;
        int sqlPasscode;
        string empName;
        bool empInSystem = false;
        // Dim doesNotneedToClockIn As Boolean = False

        empID = Conversions.ToInteger(loginEnter.ToString().Substring(0, 4));
        passcode = Conversions.ToInteger(loginEnter.ToString().Substring(4, 4));

        // Dim emp As Employee
        int isClockedIn;

        if (loginEnter.Length < 8)
        {
            Interaction.MsgBox("Enter both EmployeeID as Passcode");
            return default;
        }

        foreach (Employee currentEmp in AllEmployees)
        {
            emp = currentEmp;
            if (emp.EmployeeNumber == empID)
            {
                if (emp.PasscodeID == loginEnter.ToString().Substring(4, 4))
                {
                    empInSystem = true;
                    break;
                }
                else
                {
                    Interaction.MsgBox("Password Incorrect: Please Reenter or See Manager");
                    return default;
                }
            }
        }

        if (empInSystem == false) // emp Is Nothing Then
        {
            Interaction.MsgBox("Employee Number: " + empID + " Is Not In System");
            return default;
        }

        try
        {
            isClockedIn = ActuallyLogIn(emp);
        }
        catch (Exception ex)
        {
            CloseConnection();
            return default;
        }

        if (currentClockEmp is null)
        {
            currentClockEmp = new Employee();
        }
        currentClockEmp = emp;

        if (isClockedIn == 0)
        {
        }

        else if (isClockedIn == 1)
        {
            Interaction.MsgBox(emp.FullName + " is currently logged-in as " + emp.JobCodeName);
            return true;
        }
        // Exit Function
        else
        {
            Interaction.MsgBox("Employee Is Clocked in more than once. Please See Manager.");
            return true;
        }

        if (emp.ClockInReq == false)
        {
            Interaction.MsgBox(emp.FullName + " does not need to Clock In.");
            return true;
        }

        DisplayJobNames(ref emp);
        return default;

    }

    private void DisplayJobNames(ref Employee emp)  // (ByVal empID As Integer, ByVal passcodeID As Integer)
    {

        int x = buttonSpace;
        int y = buttonSpace;
        int h;
        var numberOfJobCodes = default(int);

        lblClockIn.Text = emp.FullName;

        h = (pnlJobCodes.Height - 8 * buttonSpace) / 7;

        if (emp.JobCode1 != default)
        {
            btnJobName[0] = new KitchenButton(emp.JobName1, pnlJobCodes.Width - 2 * buttonSpace, h, c7, c2);
            {
                ref var withBlock = ref btnJobName[0];
                withBlock.Location = new Point(x, y);
                withBlock.ID = emp.JobCode1;
                withBlock.PayRate = emp.JobRate1;
                withBlock.ForeColor = c3;
                pnlJobCodes.Controls.Add(btnJobName[0]);
                this.btnJobName[0].Click += pnlJobCodes_Click;
            }
            numberOfJobCodes += 1;
            if (numberOfJobCodes == 1)
            {
                MakeThisJobFunctionActive(btnJobName[0], false);
            }
        }
        y += h + buttonSpace;

        if (emp.JobCode2 != default)
        {
            btnJobName[1] = new KitchenButton(emp.JobName2, pnlJobCodes.Width - 2 * buttonSpace, h, c7, c2);
            {
                ref var withBlock1 = ref btnJobName[1];
                withBlock1.Location = new Point(x, y);
                withBlock1.ID = emp.JobCode2;
                withBlock1.PayRate = emp.JobRate2;
                withBlock1.ForeColor = c3;
                pnlJobCodes.Controls.Add(btnJobName[1]);
                this.btnJobName[1].Click += pnlJobCodes_Click;
            }
            numberOfJobCodes += 1;
            if (numberOfJobCodes == 1)
            {
                MakeThisJobFunctionActive(btnJobName[1], false);
            }
        }
        y += h + buttonSpace;

        if (emp.JobCode3 != default)
        {
            btnJobName[2] = new KitchenButton(emp.JobName3, pnlJobCodes.Width - 2 * buttonSpace, h, c7, c2);
            {
                ref var withBlock2 = ref btnJobName[2];
                withBlock2.Location = new Point(x, y);
                withBlock2.ID = emp.JobCode3;
                withBlock2.PayRate = emp.JobRate3;
                withBlock2.ForeColor = c3;
                pnlJobCodes.Controls.Add(btnJobName[2]);
                this.btnJobName[2].Click += pnlJobCodes_Click;
            }
            numberOfJobCodes += 1;
            if (numberOfJobCodes == 1)
            {
                MakeThisJobFunctionActive(btnJobName[2], false);
            }
        }
        y += h + buttonSpace;

        if (emp.JobCode4 != default)
        {
            btnJobName[3] = new KitchenButton(emp.JobName4, pnlJobCodes.Width - 2 * buttonSpace, h, c7, c2);
            {
                ref var withBlock3 = ref btnJobName[3];
                withBlock3.Location = new Point(x, y);
                withBlock3.ID = emp.JobCode4;
                withBlock3.PayRate = emp.JobRate4;
                withBlock3.ForeColor = c3;
                pnlJobCodes.Controls.Add(btnJobName[3]);
                this.btnJobName[3].Click += pnlJobCodes_Click;
            }
            numberOfJobCodes += 1;
            if (numberOfJobCodes == 1)
            {
                MakeThisJobFunctionActive(btnJobName[3], false);
            }
        }
        y += h + buttonSpace;

        if (emp.JobCode5 != default)
        {
            btnJobName[4] = new KitchenButton(emp.JobName5, pnlJobCodes.Width - 2 * buttonSpace, h, c7, c2);
            {
                ref var withBlock4 = ref btnJobName[4];
                withBlock4.Location = new Point(x, y);
                withBlock4.ID = emp.JobCode5;
                withBlock4.PayRate = emp.JobRate5;
                withBlock4.ForeColor = c3;
                pnlJobCodes.Controls.Add(btnJobName[4]);
                this.btnJobName[4].Click += pnlJobCodes_Click;
            }
            numberOfJobCodes += 1;
            if (numberOfJobCodes == 1)
            {
                MakeThisJobFunctionActive(btnJobName[4], false);
            }
        }
        y += h + buttonSpace;

        if (emp.JobCode6 != default)
        {
            btnJobName[5] = new KitchenButton(emp.JobName6, pnlJobCodes.Width - 2 * buttonSpace, h, c7, c2);
            {
                ref var withBlock5 = ref btnJobName[5];
                withBlock5.Location = new Point(x, y);
                withBlock5.ID = emp.JobCode6;
                withBlock5.PayRate = emp.JobRate6;
                withBlock5.ForeColor = c3;
                pnlJobCodes.Controls.Add(btnJobName[5]);
                this.btnJobName[5].Click += pnlJobCodes_Click;
            }
            numberOfJobCodes += 1;
            if (numberOfJobCodes == 1)
            {
                MakeThisJobFunctionActive(btnJobName[5], false);
            }
        }
        y += h + buttonSpace;

        if (emp.JobCode7 != default)
        {
            btnJobName[6] = new KitchenButton(emp.JobName7, pnlJobCodes.Width - 2 * buttonSpace, h, c7, c2);
            {
                ref var withBlock6 = ref btnJobName[6];
                withBlock6.Location = new Point(x, y);
                withBlock6.ID = emp.JobCode7;
                withBlock6.PayRate = emp.JobRate7;
                withBlock6.ForeColor = c3;
                pnlJobCodes.Controls.Add(btnJobName[6]);
                this.btnJobName[6].Click += pnlJobCodes_Click;
            }
            numberOfJobCodes += 1;
            if (numberOfJobCodes == 1)
            {
                MakeThisJobFunctionActive(btnJobName[6], false);
            }
        }

        if (numberOfJobCodes == 1)
        {
            // we need to check if they are floor personel
            // then check how many floor plans
            // then Apply ClockIn

            ApplyClockIn();

        }

    }

    private void pnlJobCodes_Click(object sender, EventArgs e)
    {
        var btnKitchen = new KitchenButton("ForTestOnly", 0, 0, c3, c2);
        KitchenButton objButton;

        if (!object.ReferenceEquals(sender.GetType(), btnKitchen.GetType))
            return;

        objButton = (KitchenButton)sender;

        MakeThisJobFunctionActive(objButton, true);

    }

    private void MakeThisJobFunctionActive(KitchenButton objButton, bool resettingColor)
    {

        if (resettingColor == true)
        {
            ResetJobButtonColors();
        }

        emp.JobCodeID = objButton.ID;
        emp.RegPayRate = objButton.PayRate;
        emp.OTPayRate = Math.Round(emp.RegPayRate * companyInfo.overtimeRate, 2);

        objButton.BackColor = c9;    // Color.Red
        btnApplyClockIn.Enabled = true;
        btnApplyClockIn.BackColor = c9;   // Color.Red
    }

    private void ResetJobButtonColors()
    {

        if (btnJobName[0] is not null)
        {
            btnJobName[0].BackColor = c7;
        }
        if (btnJobName[1] is not null)
        {
            btnJobName[1].BackColor = c7;
        }
        if (btnJobName[2] is not null)
        {
            btnJobName[2].BackColor = c7;
        }
        if (btnJobName[3] is not null)
        {
            btnJobName[3].BackColor = c7;
        }
        if (btnJobName[4] is not null)
        {
            btnJobName[4].BackColor = c7;
        }
        if (btnJobName[5] is not null)
        {
            btnJobName[5].BackColor = c7;
        }
        if (btnJobName[6] is not null)
        {
            btnJobName[6].BackColor = c7;
        }

    }
    private void btnCancel_Click(object sender, EventArgs e)
    {

        ClosingClockIn?.Invoke(sender, e);
        this.Dispose();

    }

    private void btnApplyClockIn_Click(object sender, EventArgs e)
    {

        // at startup we are allowing clockIn even without connection to Phoenix
        // this will place a 0 in terminalPrimary Key

        ApplyClockIn();

    }

    private void ApplyClockIn()
    {
        // at startup we are allowing clockIn even without connection to Phoenix
        // this will place a 0 in terminalPrimary Key

        // could / should add enter of LastFloorPlan in emp.LastFloorPlan
        // this can change every time they leave floor plan

        GenerateOrderTables.EnterEmployeeToLoginDatabase(emp);
        GenerateOrderTables.FillJobCodeInfo(emp, emp.JobCodeID);
        ApplyClockInCheck?.Invoke(); // ByVal sender As System.Object, ByVal e As System.EventArgs)
        this.Dispose();

    }


}