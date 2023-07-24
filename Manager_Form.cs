using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using DataSet_Builder;



internal partial struct ManagementAuthorization
{
    // this is used for a second employee(manager) authorizing something 
    // while first employee is logged-in

    private string _fullName;
    private bool _operationAll;
    private bool _operationLimited;
    private bool _employeeAll;
    private bool _employeeLimited;
    private bool _reportAll;
    private bool _reportLimited;
    private bool _systemAll;
    private bool _systemLimited;

    private int _operationLevel;
    private int _employeeLevel;
    private int _reportLevel;
    private int _systemLevel;


    internal int OperationLevel
    {
        get
        {
            return _operationLevel;
        }
        set
        {
            _operationLevel = value;
        }
    }

    internal int EmployeeLevel
    {
        get
        {
            return _employeeLevel;
        }
        set
        {
            _employeeLevel = value;
        }
    }

    internal int ReportLevel
    {
        get
        {
            return _reportLevel;
        }
        set
        {
            _reportLevel = value;
        }
    }

    internal int SystemLevel
    {
        get
        {
            return _systemLevel;
        }
        set
        {
            _systemLevel = value;
        }
    }

    internal string FullName
    {
        get
        {
            return _fullName;
        }
        set
        {
            _fullName = value;
        }
    }


    internal bool OperationAll
    {
        get
        {
            return _operationAll;
        }
        set
        {
            _operationAll = value;
        }
    }

    internal bool OperationLimited
    {
        get
        {
            return _operationLimited;
        }
        set
        {
            _operationLimited = value;
        }
    }

    internal bool EmployeeAll
    {
        get
        {
            return _employeeAll;
        }
        set
        {
            _employeeAll = value;
        }
    }

    internal bool EmployeeLimited
    {
        get
        {
            return _employeeLimited;
        }
        set
        {
            _employeeLimited = value;
        }
    }

    internal bool ReportAll
    {
        get
        {
            return _reportAll;
        }
        set
        {
            _reportAll = value;
        }
    }

    internal bool ReportLimited
    {
        get
        {
            return _reportLimited;
        }
        set
        {
            _reportLimited = value;
        }
    }

    internal bool SystemAll
    {
        get
        {
            return _systemAll;
        }
        set
        {
            _systemAll = value;
        }
    }

    internal bool SystemLimited
    {
        get
        {
            return _systemLimited;
        }
        set
        {
            _systemLimited = value;
        }
    }

}



public partial class Manager_Form : System.Windows.Forms.UserControl
{

    // Dim sql As New DataSet_Builder.SQLHelper(connectserver)
    internal CurrencyManager ManagerOpenOrdersCurrencyMan;

    private Manager_Main_UC _mainManager;

    internal virtual Manager_Main_UC mainManager
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _mainManager;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_mainManager != null)
            {
                _mainManager.DisposeManager -= ClosingFromManager_Main;
                _mainManager.OpenOrderAdjustment -= DisplayOrderAdjustment;
                _mainManager.CloseBatchManagerForm -= InitiateCloseBatch;
                _mainManager.OverrideTableStatus -= OverrideTableStatus_Click;
                _mainManager.ReReadCredit -= ReReadCredit_Click;
                _mainManager.OpenNewTable -= OpenNewTable_ButtonHit;
                _mainManager.OpenNewTabEvent -= OpenNewTab_ButtonHit;
                _mainManager.OpenReports -= StartManagerReports;
                _mainManager.StartExit -= ClosePOS_Selected;
            }

            _mainManager = value;
            if (_mainManager != null)
            {
                _mainManager.DisposeManager += ClosingFromManager_Main;
                _mainManager.OpenOrderAdjustment += DisplayOrderAdjustment;
                _mainManager.CloseBatchManagerForm += InitiateCloseBatch;
                _mainManager.OverrideTableStatus += OverrideTableStatus_Click;
                _mainManager.ReReadCredit += ReReadCredit_Click;
                _mainManager.OpenNewTable += OpenNewTable_ButtonHit;
                _mainManager.OpenNewTabEvent += OpenNewTab_ButtonHit;
                _mainManager.OpenReports += StartManagerReports;
                _mainManager.StartExit += ClosePOS_Selected;
            }
        }
    }
    private Manager_OrderAdj_UC _orderAdj;

    private Manager_OrderAdj_UC orderAdj
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _orderAdj;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_orderAdj != null)
            {
                _orderAdj.ReinitializeMain -= ReinitializeWithoutLogon;
                _orderAdj.VoidedCheckTableStatusChange -= ReinitializeWithoutLogonAfterVoidCheck;
                _orderAdj.SaveReopenedCheck -= SavingReopenedCheck222;
                _orderAdj.PlacingOrder -= PlaceOrder;
                _orderAdj.MgrClosingCheck -= ManagerClosingCheck;
                _orderAdj.TransferingCheck -= TransferingCheck;
            }

            _orderAdj = value;
            if (_orderAdj != null)
            {
                _orderAdj.ReinitializeMain += ReinitializeWithoutLogon;
                _orderAdj.VoidedCheckTableStatusChange += ReinitializeWithoutLogonAfterVoidCheck;
                _orderAdj.SaveReopenedCheck += SavingReopenedCheck222;
                _orderAdj.PlacingOrder += PlaceOrder;
                _orderAdj.MgrClosingCheck += ManagerClosingCheck;
                _orderAdj.TransferingCheck += TransferingCheck;
            }
        }
    }
    // Dim WithEvents ActiveMgrOrder As term_OrderForm
    private Manager_Transfer_UC _transCheck;

    private Manager_Transfer_UC transCheck
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _transCheck;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_transCheck != null)
            {
                _transCheck.UpdatingCurrentTables -= TransUC_Closed;
            }

            _transCheck = value;
            if (_transCheck != null)
            {
                _transCheck.UpdatingCurrentTables += TransUC_Closed;
            }
        }
    }
    // Dim WithEvents _closeCheck As CloseCheck
    // Dim WithEvents ActiveSplit As SplitChecks
    private DataSet_Builder.Manager_Reports_UC _reportManager;

    private DataSet_Builder.Manager_Reports_UC reportManager // Manager_Reports_UC '  DataSet_Builder.Reports_EmployeeHours     '
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _reportManager;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_reportManager != null)
            {
                _reportManager.ExitReports -= ExitReports_Selected;
            }

            _reportManager = value;
            if (_reportManager != null)
            {
                _reportManager.ExitReports += ExitReports_Selected;
            }
        }
    }
    private Seating_ChooseTable _SeatingChart;

    private Seating_ChooseTable SeatingChart // not using (using FireOrderScreen)
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _SeatingChart;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _SeatingChart = value;
        }
    }
    internal Seating_EnterTab SeatingTab;
    private Seating_ChooseTable _overrideSeating;

    private Seating_ChooseTable overrideSeating
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _overrideSeating;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            _overrideSeating = value;
        }
    }
    private BatchClose_UC _closeBatch;

    private BatchClose_UC closeBatch
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get
        {
            return _closeBatch;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        set
        {
            if (_closeBatch != null)
            {
                _closeBatch.ExitBatchClose -= BatchCloseComplete;
                _closeBatch.ExitWithoutClose -= BatchExitWithoutClose;
            }

            _closeBatch = value;
            if (_closeBatch != null)
            {
                _closeBatch.ExitBatchClose += BatchCloseComplete;
                _closeBatch.ExitWithoutClose += BatchExitWithoutClose;
            }
        }
    }
    // Dim WithEvents employeeLog As EmployeeLoggedInUserControl

    // Friend empActive As Employee
    private bool usernameEnterOnLogin;
    private bool isBartender;
    private long weAreClosingDaily;

    private bool _reopenedTabNotTable;
    // Private _reopenedTable As Boolean


    internal object ReopenedTabNotTable
    {
        get
        {
            return _reopenedTabNotTable;
        }
        set
        {
            _reopenedTabNotTable = Conversions.ToBoolean(value);
        }
    }


    // Friend Property ReopenedTable()
    // Get
    // Return _reopenedTable
    // End Get
    // '       Set(ByVal Value)
    // _reopenedTable = Value
    // End Set
    // End Property
    public event ClosePOSEventHandler ClosePOS;

    public delegate void ClosePOSEventHandler();
    public event UpdatingAfterTransferEventHandler UpdatingAfterTransfer;

    public delegate void UpdatingAfterTransferEventHandler();
    public event MgrClosingCheckEventHandler MgrClosingCheck;

    public delegate void MgrClosingCheckEventHandler();
    public event FireOrderScreenEventHandler FireOrderScreen;

    public delegate void FireOrderScreenEventHandler();
    public event FireSeatingChartEventHandler FireSeatingChart;

    public delegate void FireSeatingChartEventHandler(bool fromMgmt);
    public event OverrideTableStatusEventHandler OverrideTableStatus;

    public delegate void OverrideTableStatusEventHandler(bool fromMgmt);
    public event DisposingOfManagerEventHandler DisposingOfManager;

    public delegate void DisposingOfManagerEventHandler();
    public event FireSeatingTabEventHandler FireSeatingTab;

    public delegate void FireSeatingTabEventHandler(string startedFrom, string tn); // As Boolean)
    public event ReReadCreditEventHandler ReReadCredit;

    public delegate void ReReadCreditEventHandler();



    #region  Windows Form Designer generated code 

    public Manager_Form(ref Employee emp, bool userEntered) : base()
    {

        actingManager = new Employee();
        empActive = new Employee();
        // actingManager = emp
        // If currentServer.EmployeeID = 0 Then
        // currentServer = actingManager
        // End If

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        usernameEnterOnLogin = userEntered;
        if (usernameEnterOnLogin == true)
        {
            actingManager = emp;
        }
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
    [DebuggerStepThrough()]
    private void InitializeComponent()
    {
        // 
        // Manager_Form
        // 
        this.BackColor = System.Drawing.Color.Black;
        this.Name = "Manager_Form";
        this.Size = new System.Drawing.Size(1024, 768);

    }

    #endregion

    private void InitializeOther()
    {

        // Me.ClientSize = New Size(ssX, ssY)
        PopulateAllTablesWithStatus(false);
        ManagerOpenOrdersCurrencyMan = this.BindingContext(dsOrder.Tables("OpenOrders"));

        // currentServer = New Employee
        DisplayMainManager();

    }

    internal void CommingBackFromCloseCheck()
    {


    }


    internal void ReinitializeWithoutLogon(bool saveChanges, bool disposeOrdAdj)
    {

        if (saveChanges == true)
        {
            SaveChanges_Manager();
        }
        else
        {
            ReleaseWithoutSaving();
        }
        if (disposeOrdAdj == true)
        {
            DisposeOrderAdj();
        }
        DisposeDataViewsOrder(); // 999

        usernameEnterOnLogin = true;
        DisplayMainManager();

        if (!object.ReferenceEquals(empActive, actingManager))
        {

            // If Me.OperationFlag = True Then
            if (weAreClosingDaily == 0L)
            {
                GenerateOrderTables.PopulateTabsAndTables(empActive, currentTerminal.CurrentDailyCode, false, false, default);
                CreateDataViews(currentServer.EmployeeID, true);
                // PopulateOpenTabsAndTables()
                mainManager.DisplayOpenTabsAndTables();
            }
            else
            {
                // this means we assigned a closing daily
                mainManager.ReinitializeOpenTicketsFromForm(weAreClosingDaily);
            }

        }
        // End If

    }

    private void SaveChanges_Manager()
    {

        if (dsOrder.HasChanges)
        {
            GenerateOrderTables.ReleaseCurrentlyHeld();
            GenerateOrderTables.SaveOpenOrderData();
            // not sure????
            currentTable = (object)null;
        }
        if (dsOrder.Tables("OpenOrders").Rows.Count > 0)
        {

        }

    }

    private void ClosingFromManager_Main()
    {

        DisposingOfManager?.Invoke();

    }

    private void DisposeOrderAdj()
    {
        dvForcePrice.Dispose();
        dvUnAppliedPaymentsAndCredits.Dispose();
        dvPaymentsAndCredits.Dispose();
        orderAdj.Dispose();

    }


    private void ReinitializeWithoutLogonAfterVoidCheck(int tn)
    {
        mainManager.JustVoidedCheck(tn);

    }

    public void DisplayMainManager()
    {

        mainManager = new Manager_Main_UC(usernameEnterOnLogin);
        mainManager.Location = new Point((this.Width - mainManager.Width) / 2, (this.Height - mainManager.Height) / 2);
        this.Controls.Add(mainManager);

    }


    private void DisplayOrderAdjustment(object sender, EventArgs e, long weClosingDaily)
    {
        var objButton = new DataSet_Builder.AvailTableUserControl();
        if (!object.ReferenceEquals(sender.GetType(), objButton.GetType))
            return;

        currentTable = new DinnerTable();
        weAreClosingDaily = weClosingDaily;

        DataRow oRow;
        bool isCurrentlyHeld;
        int tableNumber;
        long tabID;
        string tabName;

        long experienceNumber;
        var mgrReopen = default(bool);
        int numberOfChecks;
        int numberOfCustomers;
        int currentMenu;
        int empID;

        if (mainManager.ReopenFlag == true)
        {
            mgrReopen = true;
        }
        objButton = (DataSet_Builder.AvailTableUserControl)sender;
        experienceNumber = objButton.ExperienceNumber;

        if (!(typeProgram == "Online_Demo"))
        {
            DisplayOrderAdjustmentStep2(experienceNumber, Conversions.ToBoolean(weClosingDaily), mgrReopen);
        }
        else
        {
            isCurrentlyHeld = GenerateOrderTables.PopulateThisExperience(experienceNumber, false);

            string filterString = "ExperienceNumber = " + experienceNumber;
            string NotfilterString = " NOT ExperienceNumber = " + experienceNumber;

            if (objButton.TableNumber == 0 == true)
            {
                // is Tab or ticket
                if (objButton.TicketNumber == 0)
                {
                    // is tab
                    Demo_FilterDontDelete(dsOrder.Tables("AvailTabs"), dsOrder.Tables("CurrentlyHeld"), filterString); // , NotfilterString) '"ExperienceNumber = '" & experienceNumber & "'")
                    if (mainManager.ReopenFlag == false)
                    {
                        dsOrder.Tables("AvailTabs").Clear();
                    }
                }
                else
                {
                    // is ticket
                    Demo_FilterDontDelete(dsOrder.Tables("QuickTickets"), dsOrder.Tables("CurrentlyHeld"), filterString); // , NotfilterString) '"ExperienceNumber = '" & experienceNumber & "'")
                    if (mainManager.ReopenFlag == false)
                    {
                        dsOrder.Tables("QuickTickets").Clear();
                    }
                }
            }
            else
            {
                // is table
                Demo_FilterDontDelete(dsOrder.Tables("AvailTables"), dsOrder.Tables("CurrentlyHeld"), filterString); // , NotfilterString) '"ExperienceNumber = '" & experienceNumber & "'")

                if (mainManager.ReopenFlag == false)  // ReopenIndex > 0 Then
                {
                    dsOrder.Tables("AvailTables").Clear();
                }
            }

            dsOrder.Tables("CurrentlyHeld").Rows(0)("CurrentlyHeld") = false;
        }

        return;
        // 222  below





        isCurrentlyHeld = GenerateOrderTables.PopulateThisExperience(experienceNumber, false);
        oRow = dsOrder.Tables("CurrentlyHeld").Rows(0);


        if (typeProgram == "Online_Demo")
        {
            string filterString = "ExperienceNumber = " + experienceNumber;
            string NotfilterString = " NOT ExperienceNumber = " + experienceNumber;

            if (objButton.TableNumber == 0 == true)
            {
                // is Tab or ticket
                if (objButton.TicketNumber == 0)
                {
                    // is tab
                    Demo_FilterDontDelete(dsOrder.Tables("AvailTabs"), dsOrder.Tables("CurrentlyHeld"), filterString); // , NotfilterString) '"ExperienceNumber = '" & experienceNumber & "'")
                    if (mainManager.ReopenFlag == false)
                    {
                        dsOrder.Tables("AvailTabs").Clear();
                    }
                }
                else
                {
                    // is ticket
                    Demo_FilterDontDelete(dsOrder.Tables("QuickTickets"), dsOrder.Tables("CurrentlyHeld"), filterString); // , NotfilterString) '"ExperienceNumber = '" & experienceNumber & "'")
                    if (mainManager.ReopenFlag == false)
                    {
                        dsOrder.Tables("QuickTickets").Clear();
                    }
                }
            }
            else
            {
                // is table
                Demo_FilterDontDelete(dsOrder.Tables("AvailTables"), dsOrder.Tables("CurrentlyHeld"), filterString); // , NotfilterString) '"ExperienceNumber = '" & experienceNumber & "'")

                if (mainManager.ReopenFlag == false)  // ReopenIndex > 0 Then
                {
                    dsOrder.Tables("AvailTables").Clear();
                }
            }

            dsOrder.Tables("CurrentlyHeld").Rows(0)("CurrentlyHeld") = false;
        }




        if (objButton.TabID != 0)
        {
            tabID = objButton.TabID;
            tabName = objButton.Text;
            // *************  we will remove the exit sub
            // we need to add somethinhg that will replace the held by in ExperienceTable and
            // not let the server save changes
            // we are allowing managers to enter currently held experiences
            // just warning them when they do
            if (isCurrentlyHeld == true)
            {
                if (Interaction.MsgBox("Tab " + tabName + " is currently held by " + dsOrder.Tables("CurrentlyHeld").Rows(0)("CurrentlyHeld"), MsgBoxStyle.OkCancel) == MsgBoxResult.Cancel)
                {
                    return;
                }
                // MsgBox("Tab " & tabName & " is currently held by " & dsOrder.Tables("CurrentlyHeld").Rows(0)("CurrentlyHeld"))
            }

            currentTable.SatTime = objButton.SatTime;
            oRow = dsOrder.Tables("CurrentlyHeld").Rows(0);

            if (mainManager.ReopenFlag == true)
            {
                ReopenCheck(true, oRow("TicketNumber"));
            }

            GenerateOrderTables.PopulateCurrentTableData(oRow);
            GenerateOrderTables.StartOrderProcess(currentTable.ExperienceNumber);
        }

        // 444        orderAdj = New Manager_OrderAdj_UC(mainManager.ReopenFlag, objButton.CurrentMenu, objButton.EmpID, True, objButton.ExperienceNumber, objButton.NumberOfChecks, objButton.NumberOfCustomers)

        else
        {
            if (isCurrentlyHeld == true)
            {
                if (Interaction.MsgBox("Tab " + tabName + " is currently held by " + dsOrder.Tables("CurrentlyHeld").Rows(0)("CurrentlyHeld"), MsgBoxStyle.OkCancel) == MsgBoxResult.Cancel)
                {
                    return;
                }
                // MsgBox("Tab " & tabName & " is currently held by " & dsOrder.Tables("CurrentlyHeld").Rows(0)("CurrentlyHeld"))
            }

            tableNumber = objButton.TableNumber;
            currentTable.SatTime = objButton.SatTime;
            oRow = dsOrder.Tables("CurrentlyHeld").Rows(0);

            if (mainManager.ReopenFlag == true)
            {
                ReopenCheck(false, oRow("TicketNumber"));
            }

            GenerateOrderTables.PopulateCurrentTableData(oRow);
            GenerateOrderTables.StartOrderProcess(currentTable.ExperienceNumber);

            // 444      orderAdj = New Manager_OrderAdj_UC(mainManager.ReopenFlag, objButton.CurrentMenu, objButton.EmpID, False, objButton.ExperienceNumber, objButton.NumberOfChecks, objButton.NumberOfCustomers)

        }

        orderAdj.Location = new Point((this.Width - orderAdj.Width) / 2, (this.Height - orderAdj.Height) / 2);
        this.Controls.Add(orderAdj);
        mainManager.Dispose();

    }

    internal void DisplayOrderAdjustmentStep2(long experienceNumber, bool weClosingDaily, bool mgrReopen)
    {
        // 2nd will be false from Mgr Swipe
        if (typeProgram == "Online_Demo")
            return;

        // ???     currentTable = New DinnerTable
        weAreClosingDaily = Conversions.ToLong(weClosingDaily);

        DataRow oRow;
        bool isCurrentlyHeld;

        // Dim mgrReopen As Boolean
        int numberOfChecks;
        int numberOfCustomers;
        int currentMenu;
        int empID;

        isCurrentlyHeld = GenerateOrderTables.PopulateThisExperience(experienceNumber, false);
        oRow = dsOrder.Tables("CurrentlyHeld").Rows(0);

        if (isCurrentlyHeld == true)
        {
            if (Interaction.MsgBox("Tab " + oRow("TabName") + " is currently held by " + dsOrder.Tables("CurrentlyHeld").Rows(0)("CurrentlyHeld"), MsgBoxStyle.OkCancel) == MsgBoxResult.Cancel)
            {
                return;
            }
        }

        GenerateOrderTables.PopulateCurrentTableData(oRow);
        GenerateOrderTables.StartOrderProcess(experienceNumber); // currentTable.ExperienceNumber)
        orderAdj = new Manager_OrderAdj_UC(mgrReopen, experienceNumber);
        orderAdj.Location = new Point((this.Width - orderAdj.Width) / 2, (this.Height - orderAdj.Height) / 2);
        this.Controls.Add(orderAdj);
        if (mainManager is not null)
        {
            // will be nothing if sent from mgr swipe
            mainManager.Dispose();
        }

    }


    private void InitiateCloseBatch(long closingDailyCode)
    {

        closeBatch = new BatchClose_UC(closingDailyCode);
        closeBatch.Location = new Point(0, 0);
        // closeBatch.Location = New Point((Me.Width - closeBatch.Width) / 2, (Me.Height - closeBatch.Height) / 2)
        this.Controls.Add(closeBatch);
        mainManager.Dispose();

    }

    private void BatchCloseComplete(long closingDailyCode)
    {
        DataSet_Builder.Information_UC info;

        closeBatch.Dispose();

        if (currentTerminal.CurrentDailyCode == closingDailyCode)
        {
            // MsgBox("Current Daily Closed.") ' Restart POS to Select another Daily.")
            currentTerminal.CurrentDailyCode = 0;
            ClosePOS?.Invoke(); // StartExit()
            return;
        }

        else
        {
            Interaction.MsgBox("Daily Closed.  " + currentTerminal.CurrentDailyCode + " is still active.");
            // info = New DataSet_Builder.Information_UC("Daily Closed.  " & currentTerminal.currentDailyCode & " is still active.")
        }

        // info.Location = New Point((Me.Width - info.Width) / 2, (Me.Height - info.Height) / 2)
        // Me.Controls.Add(info)
        // info.BringToFront()

        usernameEnterOnLogin = true;
        DisplayMainManager();


    }

    private void BatchExitWithoutClose()
    {

        closeBatch.Dispose();
        usernameEnterOnLogin = true;
        DisplayMainManager();
        // Me.Dispose()

    }




    private void ReopenCheck(bool IsTabNotTable, int tktNum)
    {

        DataRowView oRow;

        if (IsTabNotTable == true)
        {
            if (tktNum > 0)
            {
                foreach (DataRowView currentORow in dvQuickTickets)
                {
                    oRow = currentORow;
                    if (oRow("ExperienceNumber") == mainManager.ReopenIndex)
                    {
                        oRow("ClosedSubTotal") = DBNull.Value;
                        oRow("LastStatus") = 2;
                        _reopenedTabNotTable = true;
                    }
                    return;
                }
            }
            else
            {
                foreach (DataRowView currentORow1 in dvClosedTabs)
                {
                    oRow = currentORow1; // dsOrder.Tables("ClosedTabs").Rows
                    if (oRow("ExperienceNumber") == mainManager.ReopenIndex)
                    {
                        oRow("ClosedSubTotal") = DBNull.Value;
                        oRow("LastStatus") = 2;
                        _reopenedTabNotTable = true;
                    }
                    return;
                }
            }
        }


        else
        {
            foreach (DataRowView currentORow2 in dvClosedTables)
            {
                oRow = currentORow2; // dsOrder.Tables("ClosedTables").Rows
                if (oRow("ExperienceNumber") == mainManager.ReopenIndex)
                {
                    oRow("ClosedSubTotal") = DBNull.Value;
                    oRow("LastStatus") = 2;
                    _reopenedTabNotTable = false;
                }
                return;
            }
        }

    }

    private void SavingReopenedCheck222()
    {
        DataRow oROw;

        // only do after we close and accept
        // only gets here if db UP

        try
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ReopenedTabNotTable, true, false)))
            {
                sql.cn.Open();
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                // sql222.SqlDataAdapterClosedTabs.Update(dsOrder.Tables("ClosedTabs"))
                sql.cn.Close();
                dsOrder.Tables("ClosedTabs").AcceptChanges();
            }
            // 222         GenerateOrderTables.AddStatusChangeData(currentTable.ExperienceNumber, 2, Nothing, Nothing, Nothing)
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ReopenedTabNotTable, false, false)))
            {
                sql.cn.Open();
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                // sql222.SqlDataAdapterClosedTables.Update(dsOrder.Tables("ClosedTables"))
                sql.cn.Close();
                dsOrder.Tables("ClosedTables").AcceptChanges();
                // 222         GenerateOrderTables.AddStatusChangeData(currentTable.ExperienceNumber, 2, Nothing, Nothing, Nothing)
            }
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
            if (Information.Err().Number == Conversions.ToDouble("5"))
            {
                ServerJustWentDown();
            }
            Interaction.MsgBox("You can only reopen a check when connected to the main Server");
        }

        // SaveESCStatusChangeData(2, Nothing, Nothing, Nothing)

    }


    private void PlaceOrder()
    {


        // everything below      Dim oRow As DataRow
        // currentTable.EmployeeID = actingManager.EmployeeID
        // currentTable.EmployeeNumber = actingManager.EmployeeNumber

        // PopulateThisExperience(currentTable.ExperienceNumber)
        // If currentTable Is Nothing Or dsOrder.Tables("CurrentlyHeld").Rows.Count = 0 Then
        // MsgBox("Table Does Not Exist")
        // Exit Sub
        // Else
        // 
        // End If
        // 'as a manager we don't care if it is held
        // '     oRow = dsOrder.Tables("CurrentlyHeld").Rows(0)
        // PopulateCurrentTableData(oRow)
        // StartOrderProcess(currentTable.ExperienceNumber)

        FireOrderScreen?.Invoke();


    }

    private void OverrideTableStatus_Click()
    {

        OverrideTableStatus?.Invoke(true);
        return;

        // 222
        overrideSeating = new Seating_ChooseTable();   // Seating_Dining(currentServer.EmployeeID)
        overrideSeating.Location = new Point(0, 0);
        overrideSeating.OverrideAvail = true;
        this.Controls.Add(overrideSeating);
        overrideSeating.BringToFront();

    }
    private void ReReadCredit_Click()
    {

        ReReadCredit?.Invoke();

    }

    // **********************
    // need to fire in Login
    private void OpenNewTable_ButtonHit()
    {

        if (typeProgram == "Online_Demo")
        {
            dsOrder.Tables("AvailTables").Clear();
        }

        // SeatingChart._seatingUsernameEnterOnLogin = True
        FireSeatingChart?.Invoke(true);
        // Me.Dispose()
        return;

        try
        {
            SeatingChart.AdjustTableColor();
            SeatingChart.Visible = true;
            SeatingChart.BringToFront();
        }
        catch (Exception ex)
        {
            // *********          InitializeSeatingChart()
            SeatingChart.AdjustTableColor();
            SeatingChart.Visible = true;
            SeatingChart.BringToFront();
        }



        SeatingChart = new Seating_ChooseTable();   // Seating_Dining(currentServer.EmployeeID)
        SeatingChart.Location = new Point(0, 0);
        this.Controls.Add(SeatingChart);
        SeatingChart.BringToFront();

    }

    private void OpenNewTab_ButtonHit()
    {

        FireSeatingTab?.Invoke("Manager", null);

        if (typeProgram == "Online_Demo")
        {
            dsOrder.Tables("AvailTabs").Clear();
        }

        return;
        // 
        // SeatingTab = New Seating_EnterTab(True, Nothing)
        // SeatingTab.Location = New Point((Me.Width - SeatingTab.Width) / 2, (Me.Height - SeatingTab.Height) / 2)
        // Me.Controls.Add(SeatingTab)
        // SeatingTab.BringToFront()
        // RaiseEvent FiredSeating_EnteredTab()

    }

    private void NewAddNewTab222() // 444Handles SeatingTab.OpenNewTabEvent
    {

        this.Enabled = true;
        string newTabNameString;
        newTabNameString = SeatingTab.NewTabName;

        // -999 for tabID will tell it to generate New TabID (which will be experience Number)
        // later we will have a look-up for returning customers
        OpenNewTab(-999, newTabNameString, true);
        SeatingTab.Dispose();

    }

    private void NewAddNewTakeOutTab222() // 444Handles SeatingTab.OpenNewTakeOutTab
    {

        this.Enabled = true;
        string newTabNameString;
        newTabNameString = SeatingTab.NewTabName;

        // -999 for tabID will tell it to generate New TabID (which will be experience Number)
        // later we will have a look-up for returning customers
        OpenNewTab(-990, newTabNameString, false);
        SeatingTab.Dispose();

    }
    private void CancelNewTab222() // 444Handles SeatingTab.CancelNewTab
    {

        // Me.Enabled = True
        SeatingTab.Dispose();
        // Me.Dispose()
        usernameEnterOnLogin = true;
        DisplayMainManager();

    }

    private void OpenNewTab(long tabId, string tabName, bool isDineIn)
    {
        long expNum;
        int tktNum;
        // Dim satTm As DateTime

        // If isDineIn = False Then
        // tktNum = CreateNewTicketNumber()
        // Else
        if (tabId == -888 | currentTerminal.TermMethod == "Quick")
        {
            tktNum = CreateNewTicketNumber();
        }
        else
        {
            tktNum = 0;
        }
        // End If

        expNum = CreateNewExperience(currentServer.EmployeeID, default, tabId, tabName, 1, 2, tktNum, 0, currentServer.LoginTrackingID);
        GenerateOrderTables.PopulateThisExperience(expNum, false);

        currentTable = new DinnerTable();
        currentTable.ExperienceNumber = expNum;
        currentTable.IsTabNotTable = true;
        currentTable.TabID = tabId;
        currentTable.TabName = tabName;
        currentTable.TableNumber = 0;
        currentTable.TicketNumber = tktNum;
        currentTable.EmployeeID = currentServer.EmployeeID;
        currentTable.EmployeeNumber = currentServer.EmployeeNumber;
        currentTable.CurrentMenu = currentTerminal.currentPrimaryMenuID; // 444 primaryMenuID  'this is the system menu - can change during order process
        currentTable.StartingMenu = currentTerminal.currentPrimaryMenuID; // 444primaryMenuID
        currentTable.NumberOfCustomers = 1;      // is 1 when you first open
        currentTable.NumberOfChecks = 1;
        currentTable.LastStatus = 2;
        currentTable.SatTime = DateTime.Now;
        currentTable.ItemsOnHold = 0;
        currentTable.MethodUse = SeatingTab.MethedUse;
        DefineMethodDirection();

        StartOrderProcess(currentTable.ExperienceNumber);
        // 222      satTm = AddStatusChangeData(currentTable.ExperienceNumber, 2, Nothing, 0, Nothing)
        // SaveESCStatusChangeData(2, Nothing, 0, Nothing)

        FireOrderScreen?.Invoke();

    }


    // *********
    // Employee Clock Adjustment

    // Private Sub AdjustingEmployeeClock222() Handles mainManager.AdjustEmpClock
    // 
    // employeeLog = New EmployeeLoggedInUserControl(True)
    // employeeLog.Location = New Point((Me.Width - employeeLog.Width) / 2, (Me.Height - employeeLog.Height) / 2)
    // Me.Controls.Add(employeeLog)
    // employeeLog.BringToFront()
    // 
    // End Sub

    // Private Sub EndAdjustEmployeeClock222(ByVal sender As Object, ByVal e As System.EventArgs) Handles employeeLog.ClosedEmployeeLog
    // 
    // employeeLog.Dispose()
    // usernameEnterOnLogin = True
    // DisplayMainManager()
    // Me.mainManager.btnEmployees_Click(sender, e)
    // 
    // End Sub

    private void ManagerClosingCheck()
    {

        MgrClosingCheck?.Invoke();


        return;
        // we should have below work at sometime

        DataRow oRow;
        currentTable.EmployeeID = actingManager.EmployeeID;
        currentTable.EmployeeNumber = actingManager.EmployeeNumber;

        PopulateThisExperience(currentTable.ExperienceNumber, false);

        if (currentTable is null | dsOrder.Tables("CurrentlyHeld").Rows.Count == 0)
        {
            Interaction.MsgBox("Table Does Not Exist");
            return;
        }
        else
        {

        }
        // as a manager we don't care if it is held
        oRow = dsOrder.Tables("CurrentlyHeld").Rows(0);
        // UpdateCurrentlyHeld(currentServer.FullName, currentTable.ExperienceNumber)
        PopulateCurrentTableData(oRow);

        StartOrderProcess(currentTable.ExperienceNumber);


    }

    // Private Sub ManagerCloseCheckExit222() Handles ActiveSplit.ManagerClosing
    // ActiveSplit.Dispose()
    // '       ActiveSplit = Nothing
    // currentTable = Nothing
    // Me.Dispose()
    // End Sub

    // Private Sub SplitCheckClosed222() Handles ActiveSplit.SplitCheckClosing
    // StartOrderProcess(currentTable.ExperienceNumber)
    // ActiveMgrOrder = New term_OrderForm(False)
    // ' not sure about below
    // '      ActiveMgrOrder.Location = New Point(0, 0)
    // Me.Controls.Add(ActiveMgrOrder)
    // ActiveMgrOrder.BringToFront()
    // '     ActiveMgrOrder.SplitCheckClosed()
    // End Sub

    private void TransferingCheck()
    {
        var restrictToItemOnly = default(bool);
        DataRow oRow;

        // this is before we raiseEvent
        // If employeeAuthorization.OperationLevel < systemAuthorization.TransferCheck Then
        // restrictToItemOnly = True
        // End If

        {
            var withBlock = dvCloseCheck;
            withBlock.Table = dsOrder.Tables("PaymentsAndCredits");
            withBlock.RowFilter = "CheckNumber = " + currentTable.CheckNumber;
        }

        if (dvCloseCheck.Count == 0)
        {
            transCheck = new Manager_Transfer_UC(orderAdj.TransSIN, orderAdj.TransName, currentTable.CheckNumber, currentTable.ExperienceNumber, false, restrictToItemOnly);
            transCheck.Location = new Point((this.Width - transCheck.Width) / 2, (this.Height - transCheck.Height) / 2);

            this.Controls.Add(transCheck);
            transCheck.BringToFront();
        }
        else
        {
            Interaction.MsgBox("You may NOT transfer a check if a Payment has been applied.");
        }

    }

    private void TransUC_Closed(bool releasingTable)
    {
        if (releasingTable == true)
        {
            CalculateClosingTotal();
            GenerateOrderTables.ReleaseTableOrTab();
            GenerateOrderTables.PopulateAllTablesWithStatus(false);

            // GenerateOrderTables.ReleaseCurrentlyHeld()
            // GenerateOrderTables.SaveOpenOrderData()
            // currentTable = Nothing
            // orderAdj.Dispose()
            ReinitializeWithoutLogon(true, true);
        }
        transCheck.Dispose();
        // SplitDisposeSelf()
        // RaiseEvent UpdatingAfterTransfer()

    }

    private void StartManagerReports()
    {

        // reports should be built in Manager_Main
        // we should not dispose of Maanager_Mail
        reportManager = new DataSet_Builder.Manager_Reports_UC(connectserver, companyInfo, currentTerminal, connectserver, typeProgram); // DataSet_Builder.Reports_EmployeeHours '
        reportManager.Location = new Point((this.Width - reportManager.Width) / 2, (this.Height - reportManager.Height) / 2);
        this.Controls.Add(reportManager);

    }

    private void ExitReports_Selected()
    {

        reportManager.Dispose();
        DisposingOfManager?.Invoke();

        // reports should be built in Manager_Main
        // we should not dispose of Maanager_Main
        // then we can do this:
        // usernameEnterOnLogin = True
        // DisplayMainManager()


    }
    private void ClosePOS_Selected()
    {

        ClosePOS?.Invoke();

    }





    private void DisposedActiveMgrOrder222(Employee emp) // Handles ActiveMgrOrder.TermOrder_Disposing
    {

        GenerateOrderTables.ReleaseCurrentlyHeld();
        GenerateOrderTables.SaveOpenOrderData();
        // dsOrder.Tables("OpenOrders").Rows.Clear()

        currentTable = (object)null;

        // 666      Me.Dispose()
        // 666  ActiveMgrOrder = Nothing

    }
    private void CancelNewTable222(object sender, EventArgs e) // Handles SeatingChart.NoTableSelected
    {
        usernameEnterOnLogin = true;
        DisplayMainManager();


    }
    private void NewAddNewTable222() // Handles SeatingChart.NumberCustomerEvent
    {
        long expNum;
        int numCust;
        this.Enabled = true;
        isBartender = false;     // *** may change to dynamic for rest.
        DateTime satTm;

        foreach (DataRow oRow in dsOrder.Tables("AllTables").Rows)    // currentPhysicalTables
        {
            if (oRow("TableNumber") == SeatingChart.TableSelected)
            {

                numCust = SeatingChart.NumberCustomers;
                expNum = CreateNewExperience(currentServer.EmployeeID, SeatingChart.TableSelected, default, default, numCust, 2, 0, 0, currentServer.LoginTrackingID);
                PopulateThisExperience(expNum, false);

                currentTable = new DinnerTable();
                currentTable.ExperienceNumber = expNum;
                currentTable.IsTabNotTable = false;
                currentTable.TableNumber = SeatingChart.TableSelected;
                currentTable.TabID = 0;
                currentTable.TabName = SeatingChart.TableSelected.ToString;
                currentTable.TicketNumber = 0;
                currentTable.EmployeeID = currentServer.EmployeeID;
                currentTable.EmployeeNumber = currentServer.EmployeeNumber;
                currentTable.ExperienceNumber = currentServer.EmployeeNumber;
                currentTable.CurrentMenu = currentTerminal.currentPrimaryMenuID; // 444primaryMenuID
                currentTable.StartingMenu = currentTerminal.currentPrimaryMenuID; // 444primaryMenuID
                currentTable.NumberOfChecks = 1;
                currentTable.NumberOfCustomers = numCust;
                currentTable.LastStatus = 2;
                currentTable.SatTime = DateTime.Now;
                currentTable.ItemsOnHold = 0;

                // **** might have to have a check for the bartenders on which employee this is
                SeatingChart.Visible = false;
                StartOrderProcess(currentTable.ExperienceNumber);

                // satTm = AddStatusChangeData(currentTable.ExperienceNumber, 2, Nothing, 0, Nothing)
                // SaveESCStatusChangeData(2, Nothing, 0, Nothing)

                FireOrderScreen?.Invoke();

                // ActiveMgrOrder = New term_OrderForm  'isBartender)
                // ActiveMgrOrder.Location = New Point(0, 0)
                // Me.Controls.Add(ActiveMgrOrder)
                // ActiveMgrOrder.BringToFront()
                break;
            }
        }

    }

}