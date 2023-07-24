using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using DataSet_Builder;





internal static partial class GenerateOrderTables
{

    public static DataSet_Builder.SQLHelper sql;
    // Public WithEvents sql222 As New DataSet_Builder.OldSqlHelper    'just so we don't have to delete some code (is old)

    private static DSICLIENTXLib.DSICLientX dsi;

    internal static Timer updateClockTimer;
    internal static Timer tablesInactiveTimer;
    internal static Timer orderInactiveTimer;
    internal static Timer splitInactiveTimer;
    // Friend closeInactiveTimer As Timer
    internal static Timer tmrCardRead;

    internal static CurrencyManager OpenOrdersCurrencyMan;


    internal static DataView dvClosingCheck;
    // Friend dvClosingCheckApplyOrder As DataView
    internal static DataView dvUnAppliedPaymentsAndCredits;
    internal static DataView dvAppliedPayments;
    internal static DataView dvPaymentsAndCredits;
    internal static DataView dvForcePrice;
    internal static DataView dvClosedTables;
    internal static DataView dvClosedTabs;
    internal static DataView dvClosingCheckPayments;
    internal static DataView dvClosedPreAuth;
    internal static DataView dvBatchNotCaptured;
    internal static DataView dvCloseCheck = new DataView();
    public static DataView dvUnAppliedPaymentsAndCredits_MWE;

    internal static DataView dvBatchPreAuth;
    internal static DataView dvBatchPreAuthCapture;
    internal static DataView dvBatchVoiceAuth;
    internal static DataView dvBatchReturn;
    internal static DataView dvIngredients = new DataView();
    internal static DataView dvIngredientsNO = new DataView();
    internal static DataView dvIngredientsEXTRA = new DataView();

    internal static DataSet ds = new DataSet("Menu");
    internal static DataSet dsStarter = new DataSet("StarterMenu");


    // we have this in both here and GenerateReportData
    // this is because we want to access this from Setup
    public static DataSet dsInventory = new DataSet("InventoryData");
    // Friend dtRawCategory As DataTable = dsInventory.Tables.Add("RawCategory")
    internal static DataTable dtRawMatLast = dsInventory.Tables.Add("RawMatLast");
    // Friend dtRawDelivery As DataTable = dsInventory.Tables.Add("RawDelivery")
    // Friend dtRawCycle As DataTable = dsInventory.Tables.Add("RawCycle")

    // other tables are created based on the results of these two
    internal static DataTable dtStarterAllFoodCategory = dsStarter.Tables.Add("StarterAllFoodCategory");
    internal static DataTable dtStarterModifierCategory = dsStarter.Tables.Add("StarterModifierCategory");
    internal static DataTable dtAllFoodCategory = ds.Tables.Add("AllFoodCategory");
    internal static DataTable dtModifierCategory = ds.Tables.Add("ModifierCategory");

    internal static DataTable dtStarterLocationOverview = dsStarter.Tables.Add("StarterLocationOverview");
    internal static DataTable dtLocationOverview = ds.Tables.Add("LocationOverview");
    internal static DataTable dtLocationOpening = ds.Tables.Add("LocationOpening");
    internal static DataTable dtMainCategory = ds.Tables.Add("MainCategory");
    internal static DataTable dtSecondaryMainCategory = ds.Tables.Add("SecondaryMainCategory");
    internal static DataTable dtIndividualJoinMain = ds.Tables.Add("IndividualJoinMain");
    internal static DataTable dtIndividualJoinSecondary = ds.Tables.Add("IndividualJoinSecondary");
    internal static DataTable dtBartenderCategory = ds.Tables.Add("BartenderCategory");
    internal static DataTable dtBartenderDrinkCategory = ds.Tables.Add("BartenderDrinkCategory");
    internal static DataTable dtSecondaryBartenderCategory = ds.Tables.Add("SecondaryBartenderCategory");
    internal static DataTable dtSecondaryBartenderDrinkCategory = ds.Tables.Add("SecondaryBartenderDrinkCategory");
    internal static DataTable dtQuickCategory = ds.Tables.Add("QuickCategory");
    internal static DataTable dtQuickDrinkCategory = ds.Tables.Add("QuickDrinkCategory");
    internal static DataTable dtSecondaryQuickCategory = ds.Tables.Add("SecondaryQuickCategory");
    internal static DataTable dtSecondaryQuickDrinkCategory = ds.Tables.Add("SecondaryQuickDrinkCategory");
    internal static DataTable dtDrinkCategory = ds.Tables.Add("DrinkCategory");
    internal static DataTable dtSecondaryDrinkCategory = ds.Tables.Add("SecondaryDrinkCategory");

    internal static DataTable dtDrinkSubCategory = ds.Tables.Add("DrinkSubCategory");
    internal static DataTable dtDrink = ds.Tables.Add("Drink");
    internal static DataTable dtDrinkAdds = ds.Tables.Add("DrinkAdds");


    internal static DataTable dtFoods = ds.Tables.Add("FoodTable");
    // Friend dtModifiers As DataTable = ds.Tables.Add("Modifiers")
    internal static DataTable dtCategoryJoin = ds.Tables.Add("CategoryJoin");
    internal static DataTable dtLiquorTypes = ds.Tables.Add("LiquorTypes");
    internal static DataTable dtDrinkModifiers = ds.Tables.Add("DrinkModifiers");
    internal static DataTable dtDrinkPrep = ds.Tables.Add("DrinkPrep");
    internal static DataTable dtTableStatusDesc = ds.Tables.Add("TableStatusDesc");
    internal static DataTable dtTax = ds.Tables.Add("Tax");
    internal static DataTable dtMenuChoice = ds.Tables.Add("MenuChoice");
    internal static DataTable dtRoutingChoice = ds.Tables.Add("RoutingChoice");
    // Friend dtByServerLocal As DataTable = ds.Tables.Add("ByServerLocal")
    internal static DataTable dtCreditCardDetail = ds.Tables.Add("CreditCardDetail");
    internal static DataTable dtTabIdentifier = ds.Tables.Add("TabIdentifier");
    internal static DataTable dtReasonsVoid = ds.Tables.Add("ReasonsVoid");


    // Friend ds As DataSet = New DataSet("ClosingData")
    internal static DataTable dtPromotion = ds.Tables.Add("Promotion");
    internal static DataTable dtBSGS = ds.Tables.Add("BSGS");
    internal static DataTable dtCombo = ds.Tables.Add("Combo");
    internal static DataTable dtComboDetail = ds.Tables.Add("ComboDetail");
    internal static DataTable dtCoupon = ds.Tables.Add("Coupon");

    internal static DataTable dtIngredients = ds.Tables.Add("Ingredients");
    internal static DataTable dtTerminalsMethod = ds.Tables.Add("TerminalsMethod");
    internal static DataTable dtTerminalsUseOrder = ds.Tables.Add("TerminalsUseOrder");
    internal static DataTable dtTermsFloor = ds.Tables.Add("TermsFloor");
    internal static DataTable dtTermsTables = ds.Tables.Add("TermsTables");
    internal static DataTable dtTermsWalls = ds.Tables.Add("TermsWalls");
    internal static DataTable dtShiftCodes = ds.Tables.Add("ShiftCodes");
    internal static DataTable dtGroupBartenders = ds.Tables.Add("GroupBartenders");

    internal static DataSet dsOrderDemo = new DataSet("OrderDataDemo");
    internal static DataSet dsEmployeeDemo = new DataSet("EmployeeDemo");


    internal static DataSet dsOrder = new DataSet("OrderData");
    internal static DataTable dtOpenOrders = dsOrder.Tables.Add("OpenOrders");
    internal static DataTable dtOrderDetail = dsOrder.Tables.Add("OrderDetail");
    internal static DataTable dtOrderForceFree = dsOrder.Tables.Add("OrderForceFree");
    // Friend dtRepeatOrder As DataTable = dsOrder.Tables.Add("RepeatOrder")
    // Friend dtOrder As DataTable = dsOrder.Tables.Add("Order")
    internal static DataTable dtCurrentlyHeld = dsOrder.Tables.Add("CurrentlyHeld");
    internal static DataTable dtAvailTables = dsOrder.Tables.Add("AvailTables");
    internal static DataTable dtAvailTabs = dsOrder.Tables.Add("AvailTabs");
    internal static DataTable dtQuickTickets = dsOrder.Tables.Add("QuickTickets");
    // Friend dtCurrentTables As DataTable = dsOrder.Tables.Add("CurrentTables")
    internal static DataTable dtAllTables = dsOrder.Tables.Add("AllTables");
    internal static DataTable dtUnNamedTabID = dsOrder.Tables.Add("UnNamedTabID");
    internal static DataTable dtOpenedTabID = dsOrder.Tables.Add("OpenedTabID");
    internal static DataTable dtInNamedTabs = dsOrder.Tables.Add("UnNamedTabs");
    internal static DataTable dtClosedTables = dsOrder.Tables.Add("ClosedTables");
    internal static DataTable dtClosedTabs = dsOrder.Tables.Add("ClosedTabs");
    // Friend dtOpenTables As DataTable = dsOrder.Tables.Add("OpenTables")
    // Friend dtOpenTabs As DataTable = dsOrder.Tables.Add("OpenTabs")
    internal static DataTable dtOpenBusiness = dsOrder.Tables.Add("OpenBusiness");
    internal static DataTable dtTermsOpen = dsOrder.Tables.Add("TermsOpen");
    internal static DataTable dtCashIn = dsOrder.Tables.Add("CashIn");
    internal static DataTable dtCashOut = dsOrder.Tables.Add("CashOut");
    // Friend dtOpenTickets As DataTable = dsOrder.Tables.Add("OpenTables")


    // Friend dtExperienceTable As DataTable = dsOrder.Tables.Add("ExperienceTable")

    // Friend dtStatusChange As DataTable = dsOrder.Tables.Add("StatusChange")
    internal static DataTable dtOrderByPrinter = dsOrder.Tables.Add("OrderByPrinter");

    // not sure of the following
    internal static DataTable dtCurrentStatus = dsOrder.Tables.Add("CurrentStatus");
    internal static DataTable dtAdjustment = dsOrder.Tables.Add("Adjustment");
    internal static DataTable dtPaymentsAndCredits = dsOrder.Tables.Add("PaymentsAndCredits");
    internal static DataTable dtPaymentType = dsOrder.Tables.Add("PaymentType");
    internal static DataTable dtFunctions = dsOrder.Tables.Add("Functions");

    internal static DataTable dtTrainingDaily = dsOrder.Tables.Add("TrainingDaily");


    internal static DataSet dsBackup = new DataSet("Backup");
    internal static DataTable dtOpenOrdersTerminal = dsBackup.Tables.Add("OpenOrdersTerminal");
    internal static DataTable dtAvailTablesTerminal = dsBackup.Tables.Add("AvailTablesTerminal");
    internal static DataTable dtAvailTabsTerminal = dsBackup.Tables.Add("AvailTabsTerminal");
    internal static DataTable dtESCTerminal = dsBackup.Tables.Add("ESCTerminal");
    internal static DataTable dtPaymentsAndCreditsTerminal = dsBackup.Tables.Add("PaymentsAndCreditsTerminal");
    internal static DataTable dtEmployeeTerminal = dsBackup.Tables.Add("EmployeeTerminal");

    internal static DataSet dsEmployee = new DataSet("Employee");
    internal static DataTable dtClockedIn = dsEmployee.Tables.Add("ClockedIn");
    internal static DataTable dtLoggedInEmploees = dsEmployee.Tables.Add("LoggedInEmployees");
    internal static DataTable dtClockOutSales = dsEmployee.Tables.Add("ClockOutSales");
    internal static DataTable dtClockOutTaxes = dsEmployee.Tables.Add("ClockOutTaxes");
    internal static DataTable dtClockOutPayments = dsEmployee.Tables.Add("ClockOutPayments");
    internal static DataTable dtClockOutAudit = dsEmployee.Tables.Add("ClockOutAudit");
    internal static DataTable dtSalesDetail = dsEmployee.Tables.Add("SalesDetail");
    // these 2 are employee tables but saving in ds 
    // so they will be backed up
    internal static DataTable dtStarterAllEmployees = dsStarter.Tables.Add("StarterAllEmployees");
    internal static DataTable dtStarterJobCodeInfo = dsStarter.Tables.Add("StarterJobCodeInfo");
    internal static DataTable dtAllEmployees = dsEmployee.Tables.Add("AllEmployees");
    internal static DataTable dtJobCodeInfo = dsEmployee.Tables.Add("JobCodeInfo");



    internal static DataSet dsCustomer = new DataSet("Customer");
    internal static DataSet dsCustomerDemo = new DataSet("CustomerDemo");
    internal static DataTable dtTabDirectorySearch = dsCustomer.Tables.Add("TabDirectorySearch");
    // Friend dtTabStorePhone As DataTable = dsCustomer.Tables.Add("TabStorePhone")
    // Friend dtTabStoreName As DataTable = dsCustomer.Tables.Add("TabStoreName")
    // Friend dtTabStoreAcct As DataTable = dsCustomer.Tables.Add("TabStoreAcct")
    // Friend dtTabCompnayPhone As DataTable = dsCustomer.Tables.Add("TabCompanyPhone")
    // Friend dtTabCompnayName As DataTable = dsCustomer.Tables.Add("TabCompanyName")
    // Friend dtTabCompnayAcct As DataTable = dsCustomer.Tables.Add("TabCompanyAcct")
    internal static DataTable dtTabPreviousOrders = dsCustomer.Tables.Add("TabPreviousOrders");
    internal static DataTable dtTabPreviousOrdersByItem = dsCustomer.Tables.Add("TabPreviousOrdersbyItem");


    // Friend dcFunctionGroupSales As DataColumn = dtClockOutSales.Columns.Add("@FunctionGroupSales", Type.GetType("System.Decimal"))
    // Friend dcFunctionName As DataColumn = dtClockOutSales.Columns.Add("@FunctionName", Type.GetType("System.String"))


    // *****************
    // PaymentsAndCredits
    // Friend pcPaymentsAndCreditsID As DataColumn = dtPaymentsAndCredits.Columns.Add("@PaymentsAndCreditsID", Type.GetType("System.Int64"))
    // Friend pcCompanyID As DataColumn = dtPaymentsAndCredits.Columns.Add("@CompanyID", Type.GetType("System.String"))
    // Friend pcLocationID As DataColumn = dtPaymentsAndCredits.Columns.Add("@LocationID", Type.GetType("System.String"))
    // Friend pcOpenOrderID As DataColumn = dtPaymentsAndCredits.Columns.Add("@OpenOrderID", Type.GetType("System.Int64"))
    // Friend pcExperienceNumber As DataColumn = dtPaymentsAndCredits.Columns.Add("@ExperienceNumber", Type.GetType("System.Int64"))
    // Friend pcEmployeeID As DataColumn = dtPaymentsAndCredits.Columns.Add("@EmployeeID", Type.GetType("System.Int32"))
    // '  Friend pcCheckNumber As DataColumn = dtPaymentsAndCredits.Columns.Add("@CheckNumber", Type.GetType("System.Int32"))
    // Friend pcPaymentTypeID As DataColumn = dtPaymentsAndCredits.Columns.Add("@PaymentTypeID", Type.GetType("System.Int32"))
    // Friend pcPaymentFlag As DataColumn = dtPaymentsAndCredits.Columns.Add("@PaymentFlag", Type.GetType("System.String"))
    // Friend pcAccountNumber As DataColumn = dtPaymentsAndCredits.Columns.Add("@AccountNumber", Type.GetType("System.String"))
    // Friend pcCCExpiration As DataColumn = dtPaymentsAndCredits.Columns.Add("@CCExpiration", Type.GetType("System.String"))
    // Friend pcTrack2 As DataColumn = dtPaymentsAndCredits.Columns.Add("@Track2", Type.GetType("System.String"))
    // Friend pcCustomerName As DataColumn = dtPaymentsAndCredits.Columns.Add("@CustomerName", Type.GetType("System.Int32"))
    // Friend pcTransactionType As DataColumn = dtPaymentsAndCredits.Columns.Add("@TransactionType", Type.GetType("System.String"))
    // '   Friend pcTransactionCode As DataColumn = dtPaymentsAndCredits.Columns.Add("@TransactionCode", Type.GetType("System.Int32"))
    // Friend pcSwipeType As DataColumn = dtPaymentsAndCredits.Columns.Add("@SwipeType", Type.GetType("System.Int32"))
    // Friend pcPaymentAmount As DataColumn = dtPaymentsAndCredits.Columns.Add("@PaymentAmount", Type.GetType("System.Decimal"))
    // Friend pcTip As DataColumn = dtPaymentsAndCredits.Columns.Add("@Tip", Type.GetType("System.Decimal"))
    // Friend pcPreAuthAmount As DataColumn = dtPaymentsAndCredits.Columns.Add("@PreAuthAmount", Type.GetType("System.Decimal"))
    // Friend pcApplied As DataColumn = dtPaymentsAndCredits.Columns.Add("@Applied", Type.GetType("System.Boolean"))
    // Friend pcRefNum As DataColumn = dtPaymentsAndCredits.Columns.Add("@RefNum", Type.GetType("System.String"))
    // Friend pcAuthCode As DataColumn = dtPaymentsAndCredits.Columns.Add("@AuthCode", Type.GetType("System.Int32"))
    // Friend pcAcqRefData As DataColumn = dtPaymentsAndCredits.Columns.Add("@AcqRefData", Type.GetType("System.String"))
    // Friend pcTerminalID As DataColumn = dtPaymentsAndCredits.Columns.Add("@TerminalID", Type.GetType("System.Int32"))
    // '  Friend pcdbUP As DataColumn = dtPaymentsAndCredits.Columns.Add("@dbUP", Type.GetType("System.Int32"))


    // *** OpenOrders



    // Friend ooOpenOrderID As DataColumn = dtOpenOrders.Columns.Add("@OpenOrderID", Type.GetType("System.Int64"))
    // Friend ooCompanyID As DataColumn = dtOpenOrders.Columns.Add("@CompanyID", Type.GetType("System.String"))
    // Friend ooLocationID As DataColumn = dtOpenOrders.Columns.Add("@LocationID", Type.GetType("System.String"))
    // Friend ooDailyCode As DataColumn = dtOpenOrders.Columns.Add("@DailyCode", Type.GetType("System.Int64"))
    // Friend ooExperienceNumber As DataColumn = dtOpenOrders.Columns.Add("@ExperienceNumber", Type.GetType("System.Int64"))
    // '   Friend ooOrderNumber As DataColumn = dtOpenOrders.Columns.Add("@OrderNumber", Type.GetType("System.Int64"))
    // Friend ooShiftID As DataColumn = dtOpenOrders.Columns.Add("@ShiftID", Type.GetType("System.Int32"))
    // Friend ooMenuID As DataColumn = dtOpenOrders.Columns.Add("@MenuID", Type.GetType("System.Int32"))
    // Friend ooEmployeeID As DataColumn = dtOpenOrders.Columns.Add("@EmployeeID", Type.GetType("System.Int32"))
    // 'old   '  Friend ooEmployeeNumber As DataColumn = dtOpenOrders.Columns.Add("@EmployeeNumber", Type.GetType("System.Int32"))
    // 'old   '    Friend ooTableNumber As DataColumn = dtOpenOrders.Columns.Add("@TableNumber", Type.GetType("System.Int32"))
    // 'old    '   Friend ooTabID As DataColumn = dtOpenOrders.Columns.Add("@TabID", Type.GetType("System.Int32"))
    // 'old    '  Friend ooTabName As DataColumn = dtOpenOrders.Columns.Add("@TabName", Type.GetType("System.String"))
    // Friend ooCheckNumber As DataColumn = dtOpenOrders.Columns.Add("@CheckNumber", Type.GetType("System.Int32"))
    // Friend ooCustomerNumber As DataColumn = dtOpenOrders.Columns.Add("@CustomerNumber", Type.GetType("System.Int32"))
    // Friend ooCourseNumber As DataColumn = dtOpenOrders.Columns.Add("@CourseNumber", Type.GetType("System.Int32"))
    // Friend ooSIN As DataColumn = dtOpenOrders.Columns.Add("@sin", Type.GetType("System.Int32"))
    // '  Friend ooSII As DataColumn = dtOpenOrders.Columns.Add("@sii", Type.GetType("System.Int32"))
    // Friend ooSi2 As DataColumn = dtOpenOrders.Columns.Add("@si2", Type.GetType("System.Int32"))
    // Friend ooQuantity As DataColumn = dtOpenOrders.Columns.Add("@Quantity", Type.GetType("System.Int32"))
    // Friend ooItemID As DataColumn = dtOpenOrders.Columns.Add("@ItemID", Type.GetType("System.Int32"))
    // Friend ooItemName As DataColumn = dtOpenOrders.Columns.Add("@ItemName", Type.GetType("System.String"))
    // Friend ooTerminalName As DataColumn = dtOpenOrders.Columns.Add("@TerminalName", Type.GetType("System.String"))
    // '   Friend ooChitName As DataColumn = dtOpenOrders.Columns.Add("@ChitName", Type.GetType("System.String"))
    // 'old    '   Friend ooAddChit As DataColumn = dtOpenOrders.Columns.Add("@AddChit", Type.GetType("System.String"))
    // Friend ooItemPrice As DataColumn = dtOpenOrders.Columns.Add("@ItemPrice", Type.GetType("System.Decimal"))
    // '   Friend ooPrice As DataColumn = dtOpenOrders.Columns.Add("@Price", Type.GetType("System.Decimal"))
    // Friend ooTaxPrice As DataColumn = dtOpenOrders.Columns.Add("@TaxPrice", Type.GetType("System.Decimal"))
    // Friend ooSinTax As DataColumn = dtOpenOrders.Columns.Add("@SinTax", Type.GetType("System.Decimal"))
    // Friend ooTaxID As DataColumn = dtOpenOrders.Columns.Add("@TaxID", Type.GetType("System.Int32"))
    // Friend ooForceFreeID As DataColumn = dtOpenOrders.Columns.Add("@ForceFreeID", Type.GetType("System.Int64"))
    // Friend ooForceFreeAuth As DataColumn = dtOpenOrders.Columns.Add("@ForceFreeAuth", Type.GetType("System.Int32"))
    // Friend ooForceFreeCode As DataColumn = dtOpenOrders.Columns.Add("@ForceFreeCode", Type.GetType("System.Int32"))
    // Friend ooFunctionID As DataColumn = dtOpenOrders.Columns.Add("@FunctionID", Type.GetType("System.Int32"))
    // Friend ooCategoryID As DataColumn = dtOpenOrders.Columns.Add("@CategoryID", Type.GetType("System.Int32"))
    // Friend ooFoodID As DataColumn = dtOpenOrders.Columns.Add("@FoodID", Type.GetType("System.Int32"))
    // '   Friend ooDrinkCategoryID As DataColumn = dtOpenOrders.Columns.Add("@DrinkCategoryID", Type.GetType("System.Int32"))
    // Friend ooDrinkID As DataColumn = dtOpenOrders.Columns.Add("@DrinkID", Type.GetType("System.Int32"))
    // Friend ooItemStatus As DataColumn = dtOpenOrders.Columns.Add("@ItemStatus", Type.GetType("System.Int32"))
    // Friend ooRoutingID As DataColumn = dtOpenOrders.Columns.Add("@RoutingID", Type.GetType("System.Int32"))
    // Friend ooPrintPriorityID As DataColumn = dtOpenOrders.Columns.Add("@PrintPriorityID", Type.GetType("System.Int32"))
    // Friend ooRepeat As DataColumn = dtOpenOrders.Columns.Add("@Repeat", Type.GetType("System.Byte"))
    // Friend ooTerminalID As DataColumn = dtOpenOrders.Columns.Add("@TerminalID", Type.GetType("System.Int32"))
    // '  Friend oodbUP As DataColumn = dtOpenOrders.Columns.Add("@dbUP", Type.GetType("System.Int32"))
    // Friend ooFunctionGroupID As DataColumn = dtOpenOrders.Columns.Add("@FunctionGroupID", Type.GetType("System.Int32"))
    // Friend ooFunctionFlag As DataColumn = dtOpenOrders.Columns.Add("@FunctionFlag", Type.GetType("System.String"))


    // *** OpenOrders Backup
    // Friend ooTermCompanyID As DataColumn = dsBackup.Tables("OpenOrdersTerminal").Columns.Add("@CompanyID", Type.GetType("System.String"))
    // Friend ooTermLocationID As DataColumn = dtOpenOrdersTerminal.Columns.Add("@LocationID", Type.GetType("System.String"))
    // Friend ooTermOpenOrderD As DataColumn = dtOpenOrdersTerminal.Columns.Add("@OpenOrderID", Type.GetType("System.Int64"))
    // Friend ooTermDailyCode As DataColumn = dtOpenOrdersTerminal.Columns.Add("@DailyCode", Type.GetType("System.Int64"))
    // '   Friend ooTermExperienceNumber As DataColumn = dtOpenOrdersTerminal.Columns.Add("@ExperienceNumber", Type.GetType("System.Int64"))
    // Friend ooTermOrderNumber As DataColumn = dtOpenOrdersTerminal.Columns.Add("@OrderNumberNumber", Type.GetType("System.Int64"))
    // Friend ooTermMenuID As DataColumn = dtOpenOrdersTerminal.Columns.Add("@MenuID", Type.GetType("System.Int32"))
    // Friend ooTermEmployeeID As DataColumn = dtOpenOrdersTerminal.Columns.Add("@EmployeeID", Type.GetType("System.Int32"))
    // '   don't forget employee number
    // Friend ooTermTableNumber As DataColumn = dtOpenOrdersTerminal.Columns.Add("@TableNumber", Type.GetType("System.Int32"))
    // Friend ooTermTabID As DataColumn = dtOpenOrdersTerminal.Columns.Add("@TabID", Type.GetType("System.Int32"))
    // Friend ooTermTabName As DataColumn = dtOpenOrdersTerminal.Columns.Add("@TabName", Type.GetType("System.String"))
    // Friend ooTermCheckNumber As DataColumn = dtOpenOrdersTerminal.Columns.Add("@CheckNumber", Type.GetType("System.Int32"))
    // '   Friend ooTermCustomerNumber As DataColumn = dtOpenOrdersTerminal.Columns.Add("@CustomerNumber", Type.GetType("System.Int32"))
    // Friend ooTermCourseNumber As DataColumn = dtOpenOrdersTerminal.Columns.Add("@CourseNumber", Type.GetType("System.Int32"))
    // Friend ooTermSIN As DataColumn = dtOpenOrdersTerminal.Columns.Add("@sin", Type.GetType("System.Int32"))
    // Friend ooTermSII As DataColumn = dtOpenOrdersTerminal.Columns.Add("@sii", Type.GetType("System.Int32"))
    // Friend ooTermQuantity As DataColumn = dtOpenOrdersTerminal.Columns.Add("@Quantity", Type.GetType("System.Int32"))
    // '  Friend ooTermItemID As DataColumn = dtOpenOrdersTerminal.Columns.Add("@ItemID", Type.GetType("System.Int32"))
    // Friend ooTermItemName As DataColumn = dtOpenOrdersTerminal.Columns.Add("@ItemName", Type.GetType("System.String"))
    // Friend ooTermPrice As DataColumn = dtOpenOrdersTerminal.Columns.Add("@Price", Type.GetType("System.Decimal"))
    // Friend ooTermTaxPrice As DataColumn = dtOpenOrdersTerminal.Columns.Add("@TaxPrice", Type.GetType("System.Decimal"))
    // Friend ooTermTaxID As DataColumn = dtOpenOrdersTerminal.Columns.Add("@TaxID", Type.GetType("System.Int32"))
    // Friend ooTermForceFreeID As DataColumn = dtOpenOrdersTerminal.Columns.Add("@ForceFreeID", Type.GetType("System.Int64"))
    // Friend ooTermForceFreeAuth As DataColumn = dtOpenOrdersTerminal.Columns.Add("@ForceFreeAuth", Type.GetType("System.Int32"))
    // '   Friend ooTermForceFreeCode As DataColumn = dtOpenOrdersTerminal.Columns.Add("@ForceFreeCode", Type.GetType("System.Int32"))
    // Friend ooTermFunctionID As DataColumn = dtOpenOrdersTerminal.Columns.Add("@FunctionID", Type.GetType("System.Int32"))
    // Friend ooTermFunctionGroupID As DataColumn = dtOpenOrdersTerminal.Columns.Add("@FunctionGroupID", Type.GetType("System.Int32"))
    // Friend ooTermFunctionFlag As DataColumn = dtOpenOrdersTerminal.Columns.Add("@FunctionFlag", Type.GetType("System.String"))
    // '  Friend ooTermCategoryID As DataColumn = dtOpenOrdersTerminal.Columns.Add("@CategoryID", Type.GetType("System.Int32"))
    // Friend ooTermFoodID As DataColumn = dtOpenOrdersTerminal.Columns.Add("@FoodID", Type.GetType("System.Int32"))
    // Friend ooTermDrinkCategoryID As DataColumn = dtOpenOrdersTerminal.Columns.Add("@DrinkCategoryID", Type.GetType("System.Int32"))
    // Friend ooTermDrinkID As DataColumn = dtOpenOrdersTerminal.Columns.Add("@DrinkID", Type.GetType("System.Int32"))
    // Friend ooTermItemStatus As DataColumn = dtOpenOrdersTerminal.Columns.Add("@ItemStatus", Type.GetType("System.Int32"))
    // Friend ooTermRoutingID As DataColumn = dtOpenOrdersTerminal.Columns.Add("@RoutingID", Type.GetType("System.Int32"))
    // Friend ooTermPrintPriorityID As DataColumn = dtOpenOrdersTerminal.Columns.Add("@PrintPriorityID", Type.GetType("System.Int32"))
    // Friend ooTermRepeat As DataColumn = dtOpenOrdersTerminal.Columns.Add("@Repeat", Type.GetType("System.Byte"))
    // Friend ooTermTerminalID As DataColumn = dtOpenOrdersTerminal.Columns.Add("@TerminalID", Type.GetType("System.Int32"))
    // Friend ooTermdbUP As DataColumn = dtOpenOrdersTerminal.Columns.Add("@dbUP", Type.GetType("System.Int32"))



    internal static DataView dvAvailTables = new DataView(dtOpenOrders);
    internal static DataView dvTransferTables = new DataView(dtOpenOrders);
    internal static DataView dvAvailTabs = new DataView(dtOpenOrders);
    internal static DataView dvTransferTabs = new DataView(dtOpenOrders);
    internal static DataView dvRepeat = new DataView();
    internal static DataView dvQuickTickets = new DataView(dtQuickTickets);
    // Friend dvQuickTicketsEmployee As DataView
    internal static DataView dvTerminalsUseOrder;
    internal static DataView dvTermsOpen = new DataView(dtTermsOpen);

    private static string sqlStatement;
    private static string tableCreating;


    // Friend dtFoodJoinModifier As DataTable = ds.Tables.Add("FoodJoinModifier")
    // Friend dtDrinkModifiers As DataTable = ds.Tables.Add("DrinkModifiers")


    // Friend dtMainTable1 As DataTable = ds.Tables.Add("MainTable1")
    // Friend dtMainTable2 As DataTable = ds.Tables.Add("MainTable2")
    // Friend dtMainTable3 As DataTable = ds.Tables.Add("MainTable3")
    // Friend dtMainTable4 As DataTable = ds.Tables.Add("MainTable4")
    // Friend dtMainTable5 As DataTable = ds.Tables.Add("MainTable5")
    // '  Friend dtMainTable6 As DataTable = ds.Tables.Add("MainTable6")
    // Friend dtMainTable7 As DataTable = ds.Tables.Add("MainTable7")
    // Friend dtMainTable8 As DataTable = ds.Tables.Add("MainTable8")
    // Friend dtMainTable9 As DataTable = ds.Tables.Add("MainTable9")
    // Friend dtMainTable10 As DataTable = ds.Tables.Add("MainTable10")
    // Friend dtMainTable11 As DataTable = ds.Tables.Add("MainTable11")
    // '  Friend dtMainTable12 As DataTable = ds.Tables.Add("MainTable12")
    // Friend dtMainTable13 As DataTable = ds.Tables.Add("MainTable13")
    // Friend dtMainTable14 As DataTable = ds.Tables.Add("MainTable14")
    // Friend dtMainTable15 As DataTable = ds.Tables.Add("MainTable15")
    // Friend dtMainTable16 As DataTable = ds.Tables.Add("MainTable16")
    // ' Friend dtMainTable17 As DataTable = ds.Tables.Add("MainTable17")
    // Friend dtMainTable18 As DataTable = ds.Tables.Add("MainTable18")
    // Friend dtMainTable19 As DataTable = ds.Tables.Add("MainTable19")
    // Friend dtMainTable20 As DataTable = ds.Tables.Add("MainTable20")
    // '
    // Friend dtModifierTable1 As DataTable = ds.Tables.Add("ModifierTable101")
    // Friend dtModifierTable2 As DataTable = ds.Tables.Add("ModifierTable102")
    // Friend dtModifierTable3 As DataTable = ds.Tables.Add("ModifierTable103")
    // Friend dtModifierTable4 As DataTable = ds.Tables.Add("ModifierTable104")
    // Friend dtModifierTable5 As DataTable = ds.Tables.Add("ModifierTable105")
    // Friend dtModifierTable6 As DataTable = ds.Tables.Add("ModifierTable106")
    // Friend dtModifierTable7 As DataTable = ds.Tables.Add("ModifierTable107")
    // Friend dtModifierTable8 As DataTable = ds.Tables.Add("ModifierTable108")
    // Friend dtModifierTable9 As DataTable = ds.Tables.Add("ModifierTable109")
    // '   Friend dtModifierTable10 As DataTable = ds.Tables.Add("ModifierTable110")
    // Friend dtModifierTable11 As DataTable = ds.Tables.Add("ModifierTable111")
    // '   Friend dtModifierTable12 As DataTable = ds.Tables.Add("ModifierTable112")
    // Friend dtModifierTable13 As DataTable = ds.Tables.Add("ModifierTable113")
    // Friend dtModifierTable14 As DataTable = ds.Tables.Add("ModifierTable114")
    // Friend dtModifierTable15 As DataTable = ds.Tables.Add("ModifierTable115")
    // Friend dtModifierTable16 As DataTable = ds.Tables.Add("ModifierTable116")
    // Friend dtModifierTable17 As DataTable = ds.Tables.Add("ModifierTable117")
    // '  Friend dtModifierTable18 As DataTable = ds.Tables.Add("ModifierTable118")
    // Friend dtModifierTable19 As DataTable = ds.Tables.Add("ModifierTable119")
    // Friend dtModifierTable20 As DataTable = ds.Tables.Add("ModifierTable120")

    // Friend dtSecondaryMainTable1 As DataTable = ds.Tables.Add("SecondaryMainTable1")
    // Friend dtSecondaryMainTable2 As DataTable = ds.Tables.Add("SecondaryMainTable2")
    // Friend dtSecondaryMainTable3 As DataTable = ds.Tables.Add("SecondaryMainTable3")
    // Friend dtSecondaryMainTable4 As DataTable = ds.Tables.Add("SecondaryMainTable4")
    // Friend dtSecondaryMainTable5 As DataTable = ds.Tables.Add("SecondaryMainTable5")
    // Friend dtSecondaryMainTable6 As DataTable = ds.Tables.Add("SecondaryMainTable6")
    // Friend dtSecondaryMainTable7 As DataTable = ds.Tables.Add("SecondaryMainTable7")
    // Friend dtSecondaryMainTable8 As DataTable = ds.Tables.Add("SecondaryMainTable8")
    // Friend dtSecondaryMainTable9 As DataTable = ds.Tables.Add("SecondaryMainTable9")
    // '   Friend dtSecondaryMainTable10 As DataTable = ds.Tables.Add("SecondaryMainTable10")
    // Friend dtSecondaryMainTable11 As DataTable = ds.Tables.Add("SecondaryMainTable11")
    // Friend dtSecondaryMainTable12 As DataTable = ds.Tables.Add("SecondaryMainTable12")
    // Friend dtSecondaryMainTable13 As DataTable = ds.Tables.Add("SecondaryMainTable13")
    // Friend dtSecondaryMainTable14 As DataTable = ds.Tables.Add("SecondaryMainTable14")
    // Friend dtSecondaryMainTable15 As DataTable = ds.Tables.Add("SecondaryMainTable15")
    // Friend dtSecondaryMainTable16 As DataTable = ds.Tables.Add("SecondaryMainTable16")
    // '  Friend dtSecondaryMainTable17 As DataTable = ds.Tables.Add("SecondaryMainTable17")
    // Friend dtSecondaryMainTable18 As DataTable = ds.Tables.Add("SecondaryMainTable18")
    // Friend dtSecondaryMainTable19 As DataTable = ds.Tables.Add("SecondaryMainTable19")
    // Friend dtSecondaryMainTable20 As DataTable = ds.Tables.Add("SecondaryMainTable20")


    internal static DataView dvOrder = new DataView(dtOpenOrders);
    internal static DataView dvOrderPrint = new DataView(dtOpenOrders);
    internal static DataView dvOrderTopHierarcy = new DataView(dtOpenOrders);
    internal static DataView dvOrderHolds = new DataView(dtOpenOrders);
    internal static DataView dvAllChecks = new DataView(dtOpenOrders);
    internal static DataView dvKitchen = new DataView(dtOpenOrders);
    internal static DataView dvFood = new DataView();
    internal static DataView dvPizzaFull = new DataView();
    internal static DataView dvPizzaFirst = new DataView();
    internal static DataView dvPizzaSecond = new DataView();
    // Friend dvModifier As DataView = New DataView
    // Friend dvAdjustment As DataView = New DataView
    // Friend dvFreeFood As DataView = New DataView
    internal static DataView dvDrink = new DataView();
    internal static DataView dvFoodJoin = new DataView();
    internal static DataView dvIndividualJoinAuto = new DataView();
    internal static DataView dvIndividualJoinGroup = new DataView();

    internal static DataView dvCategoryJoin = new DataView();
    internal static DataView dvCategoryModifiers = new DataView();
    internal static DataView dvCategoryJoinSecondLoop = new DataView();
    internal static DataView dvCategoryModifiersSecondLoop = new DataView();
    internal static DataView dvSurcharge = new DataView();
    internal static DataView dvSendToModify = new DataView(dtOpenOrders);

    static GenerateOrderTables()
    {
        sql = new DataSet_Builder.SQLHelper();
    }

    // Friend dsReport As DataSet = New DataSet("ReportData")
    // Friend dtReport_ItemsSold As DataTable = dsReport.Tables.Add("Report_ItemsSold")

    public static void TempConnectToPhoenix()
    {
        // If System.Windows.Forms.SystemInformation.ComputerName = "DILEO" Then Exit Sub

        if (localConnectServer == @"rasoi2\rasoi2" & !(System.Windows.Forms.SystemInformation.ComputerName == "EGLOBALMAIN"))
        {
            // only rasoi2 and not testing
            RestateConnectionString(sql.cn, localConnectServer);
        }
        else
        {
            RestateConnectionString(sql.cn, @"Phoenix\Phoenix");
        }

    }

    public static void ConnectBackFromTempDatabase()
    {
        // If System.Windows.Forms.SystemInformation.ComputerName = "DILEO" Then Exit Sub

        RestateConnectionString(sql.cn, connectserver);

    }

    public static void SwitchConnection()
    {

        if (connectserver == @"Phoenix\Phoenix")
        {
            connectserver = localConnectServer;  // "LABMAIN\labmain"      
            RestateConnectionString(sql.cn, connectserver);
        }
        // InitiateApplicationSecurity()
        else
        {

            connectserver = @"Phoenix\Phoenix";
            RestateConnectionString(sql.cn, connectserver);
            // InitiateApplicationSecurity()
        }

    }

    public static void InitiateApplicationSecurity222()
    {

        // the security true/false test are meaningless
        // we have to initiate security everytime we open connection
        sql.cn.Open();
        sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
        if (connectserver == @"Phoenix\Phoenix")
        {
            if (securityPhoenixEst == false)
            {
                try
                {
                    sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                    securityPhoenixEst = true;
                }
                catch (Exception ex)
                {
                    CloseConnection();
                    Interaction.MsgBox("DataCenter Not Connected. Verify all wire connection are established and your router is working. Then call 404-869-4700: " + ex.Message);
                }

            }
        }
        else if (securityLocalEst == false)
        {
            try
            {
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                securityLocalEst = true;
            }
            catch (Exception ex)
            {
                CloseConnection();
                Interaction.MsgBox("Local Database Not Connected. Verify all wire connection are established and your router is working. Then call 404-869-4700: " + ex.Message);
            }

        }
        sql.cn.Close();

    }


    public static void RestateConnectionString(SqlClient.SqlConnection myConnection, string cs)
    {
        // cs = "Phoenix\Phoenix"
        // sql.cn.ConnectionString = "packet size=4096;integrated security=SSPI;data source='" & cs & "';pe" & _
        // "rsist security info=False;Pooling=False;initial catalog=Restaurant_Server"
        // Exit Sub
        connectionDown = false;
        // 
        // cn

        // ******************
        // when testing Connection Down 
        // we need below cs = current sql server
        // we need to make the below .ComputerName = "EGLOBALMAIN" fail
        // cs = "eglobalmain\eglobalmain"

        if (System.Windows.Forms.SystemInformation.ComputerName == "EGLOBALMAIN") // And Not companyInfo.companyName = "eGlobal Partners" Then '** (for testing connection down) And Not companyInfo.companyName = Nothing Then
        {
            // below replaces above when testing Connection Down   
            // ******    
            // If System.Windows.Forms.SystemInformation.ComputerName = "EGLOBALMAIN" And Not companyInfo.companyName = "eGlobal Partners" And Not companyInfo.companyName = Nothing Then
            // sql.cn.ConnectionString = "packet size=4096;integrated security=SSPI;data source=Phoenix\Phoenix;pe" & _
            // "rsist security info=False;Pooling=False;initial catalog=Restaurant_Server"
            // end of connection down testing
            // ******

            // ******
            // remove below when testing Connection Down 
            if (companyInfo.companyName == "eGlobal Partners" | localConnectServer == @"eglobalmain\eglobalmain") // Or attemptedToLoad = True Then 'companyInfo.companyName = Nothing Then 'Or cs = "eglobalmain\eglobalmain" Then
            {
                // below makes me able to access data base on demo
                sql.cn.ConnectionString = @"packet size=4096;integrated security=SSPI;data source=eglobalmain\eglobalmain;pe" + "rsist security info=False;Pooling=False;initial catalog=Restaurant_Server";
            }
            else
            {
                // below makes me able to access every account from my computer
                sql.cn.ConnectionString = @"packet size=4096;integrated security=SSPI;data source=Phoenix\Phoenix;pe" + "rsist security info=False;Pooling=False;initial catalog=Restaurant_Server";
            }
        }
        else
        {
            sql.cn.ConnectionString = "packet size=4096;integrated security=SSPI;data source='" + cs + "';pe" + "rsist security info=False;Pooling=False;initial catalog=Restaurant_Server";
            // sql.cn.ConnectionString = "packet size=4096;integrated security=SSPI;data source='" & cs & "';pe" & _
            // "rsist security info=False;initial catalog=Restaurant_Server"
        }


        return;

        cs = @"eglobalmain\eglobalmain";
        cs = @"Phoenix\Phoenix";

        // myConnection.ConnectionString = "packet size=4096;integrated security=SSPI;data source='" & cs & "';pe" & _
        // "rsist security info=False;initial catalog=Restaurant_Server"
        sql.cn.ConnectionString = "packet size=4096;integrated security=SSPI;Connect Timeout=240;data source='" + cs + "';pe" + "rsist security info=False;initial catalog=Restaurant_Server";
        // Me.cn.ConnectionString = "packet size=4096;integrated security=SSPI;data source=Phoenix;pe" & _
        // "rsist security info=False;initial catalog=Restaurant_Server"

        // Me.cn.ConnectionString = "workstation id=VAIO;packet size=4096;integrated security=SSPI;data source=VAIO;pe" & _
        // "rsist security info=False;initial catalog=Restaurant_Server"
        // Me.cn.ConnectionString = "workstation id=VAIO;packet size=4096;integrated security=SSPI;data source=Phoenix;pe" & _
        // "rsist security info=False;initial catalog=Restaurant_Server"


        // thi is dup of above w/o persist security
        sql.cn.ConnectionString = "packet size=4096;integrated security=SSPI;Connect Timeout=240;Pooling=False;data source='" + cs + "';initial catalog=Restaurant_Server";


        try
        {
            if (cs == @"Phoenix\Phoenix")
            {
                // sql.cn.ConnectionString = "packet size=4096;User Id=TAHSC\LabmainAuto;Password=egghead103;data source='" & cs & "';initial catalog=Restaurant_Server"

                // *************** this above connection fails
                sql.cn.ConnectionString = "packet size=4096;integrated security=SSPI;Connect Timeout=240;Pooling=False;data source='" + cs + "';initial catalog=Restaurant_Server";

                sql.cn.ConnectionString = "packet size=4096;integrated security=SSPI;data source='" + cs + "';pe" + "rsist security info=False;initial catalog=Restaurant_Server";
            }

            else
            {

                sql.cn.ConnectionString = "packet size=4096;integrated security=SSPI;data source='" + cs + "';pe" + "rsist security info=False;initial catalog=Restaurant_Server";


            }
        }
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);

        }




    }

    internal static void PopulateOrderTables(bool fromStart)  // ByVal tn As Integer)
    {

        // updateClockTimer = New Timer
        orderInactiveTimer = new DateAndTime.Timer();
        tablesInactiveTimer = new DateAndTime.Timer();
        splitInactiveTimer = new DateAndTime.Timer();
        // closeInactiveTimer = New Timer
        tmrCardRead = new DateAndTime.Timer();

        string customLocationString;
        if (companyInfo.usingDefaults == false)
        {
            customLocationString = companyInfo.LocationID;
        }
        else
        {
            customLocationString = "000000";
        }

        // populates to setup dataset organization , for if we go down
        // 444    PopulateOpenOrderData(0, True)
        PopulateThisExperience(0L, true);
        // PopulatePaymentsAndCredits(0)   doing in above
        // PopulateOrderDetail(0)

        // ***** may need to fill both StatusChange & PaymnetCredit Tables
        // tableCreating = "StatusChange"
        // sqlStatement = "SELECT CompanyID, LocationID, DailyCode, ExperienceStatusChangeID, ExperienceNumber, StatusTime, TableStatusID, OrderNumber, IsMainCourse, AverageDollar, TerminalID, dbUP FROM ExperienceStatusChange WHERE CompanyID = '" & companyInfo.CompanyID & "' AND LocationID = '" & companyInfo.LocationID & "' AND DailyCode = -1"
        // dsOrder = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, dsOrder)


        tableCreating = "Functions";
        // *** remember to change .. we will keep the same function for all locations
        // the database is already setup, just not pulling by location until we need to
        sqlStatement = "SELECT FunctionID, FunctionGroupID, FunctionName, FunctionFlag, TaxID, DrinkRoutingID FROM AABFunctions WHERE CompanyID = '" + companyInfo.CompanyID + "' AND LocationID = '" + customLocationString + "'";
        dsOrder = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, dsOrder);

        // tableCreating = "PaymentsAndCredits"
        // sqlStatement = "SELECT PaymentsAndCredits.PaymentsAndCreditsID, PaymentsAndCredits.CompanyID, PaymentsAndCredits.LocationID, PaymentsAndCredits.DailyCode, PaymentsAndCredits.ExperienceNumber, PaymentsAndCredits.PaymentDate, PaymentsAndCredits.EmployeeID, PaymentsAndCredits.CheckNumber, PaymentsAndCredits.PaymentTypeID, PaymentsAndCredits.AccountNumber, PaymentsAndCredits.CCExpiration, PaymentsAndCredits.Track2, PaymentsAndCredits.CustomerName, PaymentsAndCredits.TransactionType, PaymentsAndCredits.TransactionCode, PaymentsAndCredits.SwipeType, PaymentsAndCredits.PaymentAmount, PaymentsAndCredits.Surcharge, PaymentsAndCredits.Tip, PaymentsAndCredits.PreAuthAmount, PaymentsAndCredits.Applied, PaymentsAndCredits.RefNum, PaymentsAndCredits.AuthCode, PaymentsAndCredits.AcqRefData, PaymentsAndCredits.TerminalID, PaymentsAndCredits.dbUP, AABPaymentType.PaymentTypeName FROM PaymentsAndCredits LEFT OUTER JOIN AABPaymentType ON PaymentsAndCredits.PaymentTypeID = AABPaymentType.PaymentTypeID WHERE CompanyID = '" & companyInfo.CompanyID & "' AND LocationID = '" & companyInfo.LocationID & "' AND ExperienceNumber = 0"
        // dsOrder = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, dsOrder)

        tableCreating = "PaymentType";
        sqlStatement = "SELECT PaymentTypeID, PaymentTypeName, PaymentFlag FROM AABPaymentType";
        dsOrder = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, dsOrder);

    }

    internal static void PopulateLocationOpening(bool fromStart)
    {

        var changedVersion = default(bool);
        var lastVersion = default(int);

        ds.Tables("LocationOpening").Rows.Clear();

        // true fromStart just means connection already open
        if (fromStart == false)
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
        }
        sql.SqlSelectLocationOpening.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlLocationOpening.Fill(ds.Tables("LocationOpening"));
        if (fromStart == false)
        {
            sql.cn.Close();
            // Else
            // If ds.Tables("LocationOpening").Rows.Count > 0 Then
            // If My.Application.Info.Version.MinorRevision > ds.Tables("LocationOpening").Rows(0)("LastAppVersion") Then
            // End If
            // End If
        }

        try
        {
            if (ds.Tables("LocationOpening").Rows.Count > 0)
            {
                if (global::My.Application.Info.Version.MinorRevision > ds.Tables("LocationOpening").Rows(0)("LastAppVersion"))
                {
                    lastVersion = global::My.Application.Info.Version.MinorRevision;
                    changedVersion = true;
                }
            }
            if (changedVersion == true)
            {
                ds.Tables("LocationOpening").Rows(0)("LastAppVersion") = lastVersion;
                if (fromStart == false)
                {
                    sql.cn.Open();
                    sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                }
                sql.SqlLocationOpening.Update(ds.Tables("LocationOpening"));
                if (fromStart == false)
                {
                    sql.cn.Close();
                }
                ds.Tables("LocationOpening").AcceptChanges();
            }
        }

        catch (Exception ex)
        {
            // CloseConnection()   'is open already 
        }

    }

    internal static void PopulateMenuSupport()
    {
        string customLocationString;
        if (companyInfo.usingDefaults == false)
        {
            customLocationString = companyInfo.LocationID;
        }
        else
        {
            customLocationString = "000000";
        }

        // *** these 2 tables are needed to make other table
        tableCreating = "AllFoodCategory";
        sqlStatement = "SELECT Category.CompanyID, Category.LocationID, Category.CategoryID, Category.FunctionID, Category.ButtonColor, Category.ButtonForeColor, Category.Extended, AABFunctions.FunctionGroupID, AABFunctions.FunctionFlag, AABFunctions.TaxID FROM Category LEFT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID WHERE Category.CompanyID = '" + companyInfo.CompanyID + "' AND Category.LocationID = '" + customLocationString + "' AND Category.Active = 1 AND (AABFunctions.FunctionFlag = 'F' OR AABFunctions.FunctionFlag = 'O' OR AABFunctions.FunctionFlag = 'G' OR AABFunctions.FunctionFlag = 'M') ORDER BY Priority ASC";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

        tableCreating = "ModifierCategory";
        sqlStatement = "SELECT Category.CompanyID, Category.LocationID, Category.CategoryID, Category.CategoryName, Category.CategoryAbrev, Category.CategoryOrder, Category.FunctionID, Category.ButtonColor, Category.ButtonForeColor, Category.Extended, AABFunctions.FunctionGroupID, AABFunctions.FunctionFlag FROM Category RIGHT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID WHERE AABFunctions.FunctionFlag = 'M' AND Category.CompanyID = '" + companyInfo.CompanyID + "' AND Category.LocationID = '" + customLocationString + "' AND Category.Active = 1 ORDER BY Priority ASC";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

        // 666 below is new
        // sqlStatement = "SELECT Category.CompanyID, Category.LocationID, Category.CategoryID, Category.CategoryName, Category.CategoryAbrev, Category.CategoryOrder, Category.FunctionID, Category.Extended, AABFunctions.FunctionGroupID, AABFunctions.FunctionFlag FROM Category RIGHT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID WHERE AABFunctions.FunctionFlag = 'G' AND Category.CompanyID = '" & companyInfo.CompanyID & "' AND Category.LocationID = '" & customLocationString & "' AND Category.Active = 1 ORDER BY Priority ASC"
        // ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds)

        // these 2 tables are the exact same as the above 2
        // we just need them in 2 datasets for recovery
        tableCreating = "StarterAllFoodCategory";
        sqlStatement = "SELECT Category.CompanyID, Category.LocationID, Category.CategoryID, Category.FunctionID, Category.ButtonColor, Category.ButtonForeColor, Category.Extended, AABFunctions.FunctionGroupID, AABFunctions.FunctionFlag, AABFunctions.TaxID FROM Category LEFT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID WHERE Category.CompanyID = '" + companyInfo.CompanyID + "' AND Category.LocationID = '" + customLocationString + "' AND Category.Active = 1 AND (AABFunctions.FunctionFlag = 'F' OR AABFunctions.FunctionFlag = 'O' OR AABFunctions.FunctionFlag = 'G') ORDER BY Priority ASC";
        dsStarter = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, dsStarter);

        tableCreating = "StarterModifierCategory";
        sqlStatement = "SELECT Category.CompanyID, Category.LocationID, Category.CategoryID, Category.CategoryName, Category.CategoryAbrev, Category.CategoryOrder, Category.FunctionID, Category.ButtonColor, Category.ButtonForeColor, Category.Extended, AABFunctions.FunctionGroupID, AABFunctions.FunctionFlag FROM Category RIGHT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID WHERE AABFunctions.FunctionFlag = 'M' AND Category.CompanyID = '" + companyInfo.CompanyID + "' AND Category.LocationID = '" + customLocationString + "' AND Category.Active = 1 ORDER BY Priority ASC";
        dsStarter = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, dsStarter);


        // maybe don't need?????????????????????
        // tableCreating = "Modifiers"
        // sqlStatement = "SELECT FoodID, CategoryID, FoodName, FoodCost, TaxID, Surcharge, FoodDesc FROM Foods WHERE CategoryID > 100 and CategoryID < 200"
        // ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds)

        tableCreating = "CategoryJoin";
        sqlStatement = "SELECT FoodJoin.CompanyID, FoodJoin.LocationID, FoodJoin.FoodID, FoodJoin.CategoryID, FoodJoin.NumberFree, FoodJoin.FreeFlag, FoodJoin.GroupFlag, FoodJoin.GTCFlag, FoodJoin.ReqFlag, Category.CategoryID, Category.CategoryAbrev, Category.FunctionID, Category.Priority, Category.HalfSplit, Category.ButtonColor, Category.ButtonForeColor, Category.Extended, AABFunctions.FunctionID, AABFunctions.FunctionGroupID, AABFunctions.FunctionFlag FROM FoodJoin LEFT OUTER JOIN Category ON FoodJoin.CategoryID = Category.CategoryID LEFT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID WHERE FoodJoin.CategoryID > 0 AND FoodJoin.CompanyID = '" + companyInfo.CompanyID + "' AND FoodJoin.LocationID = '" + customLocationString + "' ORDER BY Priority ASC";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

        // tableCreating = "IndividualJoin"
        // sqlStatement = "SELECT FoodJoin.CompanyID, FoodJoin.LocationID, FoodJoin.FoodID, FoodJoin.ModifierID, FoodJoin.NumberFree, FoodJoin.FreeFlag, FoodJoin.GroupFlag, Foods.FoodID, Foods.CategoryID, Foods.FoodName, Foods.AbrevFoodName, Foods.ChitFoodName, Foods.Surcharge, Foods.TaxID, Foods.FoodDesc, Category.FunctionID, Category.Priority, Functions.FunctionGroupID, Functions.FunctionFlag FROM FoodJoin LEFT OUTER JOIN Foods ON FoodJoin.ModifierID = Foods.FoodID LEFT OUTER JOIN Category ON Foods.CategoryID = Category.CategoryID LEFT OUTER JOIN Functions ON Category.FunctionID = Functions.FunctionID WHERE FoodJoin.ModifierID > 0 AND Functions.FunctionFlag = 'M' AND FoodJoin.CompanyID = '" & companyInfo.CompanyID & "' AND FoodJoin.LocationID = '" & customLocationString & "' ORDER BY Priority ASC"
        // ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds)
        // sqlStatement = "SELECT FoodJoin.CompanyID, FoodJoin.LocationID, FoodJoin.FoodID, FoodJoin.ModifierID, FoodJoin.NumberFree, FoodJoin.FreeFlag, FoodJoin.GroupFlag, Foods.FoodID, Foods.CategoryID, Foods.FoodName, Foods.AbrevFoodName, Foods.ChitFoodName, MenuJoin.Surcharge, Foods.TaxID, Foods.FoodDesc, Category.FunctionID, Category.Priority, Functions.FunctionGroupID, Functions.FunctionFlag FROM FoodJoin LEFT OUTER JOIN Foods ON FoodJoin.ModifierID = Foods.FoodID LEFT OUTER JOIN Category ON Foods.CategoryID = Category.CategoryID LEFT OUTER JOIN Functions ON Category.FunctionID = Functions.FunctionID LEFT OUTER JOIN MenuJoin ON FoodJoin.ModifierID = MenuJoin.FoodID WHERE FoodJoin.ModifierID > 0 AND MenuJoin.MenuID = 1 AND MenuJoin.GeneralMenuID IS NULL AND NOT Functions.FunctionFlag = 'M' AND FoodJoin.CompanyID = '" & companyInfo.CompanyID & "' AND FoodJoin.LocationID = '" & customLocationString & "' ORDER BY Priority ASC"
        // ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds)

        tableCreating = "DrinkSubCategory";
        sqlStatement = "SELECT DrinkCategory.DrinkCategoryID, DrinkCategory.DrinkCategoryName, DrinkCategory.DrinkCategoryNumber, DrinkCategory.ButtonColor, DrinkCategory.ButtonForeColor, DrinkCategory.IsALiquorType, MenuDetail.MenuID, MenuDetail.OrderIndex FROM DrinkCategory LEFT OUTER JOIN MenuDetail ON DrinkCategory.DrinkCategoryID = MenuDetail.DrinkCategoryID WHERE DrinkCategory.CompanyID = '" + companyInfo.CompanyID + "' AND DrinkCategory.LocationID = '" + customLocationString + "' AND DrinkCategory.DrinkCategoryID > 0";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

        tableCreating = "Drink";
        sqlStatement = "SELECT Drinks.DrinkID, Drinks.DrinkIndex, Drinks.DrinkName, Drinks.DrinkCategoryID, Drinks.DrinkPrice, Drinks.DrinkFunctionID, Drinks.TaxID, Drinks.DrinkDesc, Drinks.DrinkAddOnChoice, Drinks.IsDrinkAdd, Drinks.IsWineParring, Drinks.LiquorTypeID, Drinks.CallPrice, Drinks.AddOnPrice, Drinks.Active, Drinks.InvMultiplier, AABFunctions.FunctionGroupID, AABFunctions.FunctionFlag, AABFunctions.TaxID, AABFunctions.DrinkRoutingID FROM Drinks LEFT OUTER JOIN AABFunctions ON Drinks.DrinkFunctionID = AABFunctions.FunctionID WHERE Drinks.CompanyID = '" + companyInfo.CompanyID + "' AND Drinks.LocationID = '" + customLocationString + "' ORDER BY DrinkIndex";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

        tableCreating = "LiquorTypes";
        sqlStatement = "SELECT DrinkCategoryID, DrinkCategoryName, DrinkCategoryOrder FROM DrinkCategory WHERE CompanyID = '" + companyInfo.CompanyID + "' AND LocationID = '" + customLocationString + "' AND IsALiquorType = 1";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

        tableCreating = "DrinkAdds";
        sqlStatement = "SELECT Drinks.DrinkID, Drinks.DrinkName, Drinks.DrinkCategoryID, Drinks.DrinkFunctionID, Drinks.AddOnPrice, Drinks.TaxID , Drinks.InvMultiplier, AABFunctions.FunctionGroupID, AABFunctions.FunctionFlag, AABFunctions.TaxID, AABFunctions.DrinkRoutingID FROM Drinks LEFT OUTER JOIN AABFunctions ON Drinks.DrinkFunctionID = AABFunctions.FunctionID WHERE Drinks.CompanyID = '" + companyInfo.CompanyID + "' AND Drinks.LocationID = '" + customLocationString + "' AND Drinks.IsDrinkAdd = 1 ORDER BY Drinks.DrinkName";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

        // ***     ***    ***   need to change
        // tableCreating = "DrinkModifiers"
        // sqlStatement = "SELECT DrinkModifierID, DrinkID, DrinkName, DrinkPrice, TaxID FROM DrinkModifiers WHERE LocationID = '" & customLocationString & "' ORDER BY DrinkModifierID ASC"
        // ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds)

        tableCreating = "DrinkPrep";
        sqlStatement = "SELECT DrinkPrepLocation.DrinkPrepID, DrinkPrepLocation.DrinkPrepMethod, DrinkPrepLocation.DrinkPrepPrice, DrinkPrepLocation.Active, DrinkPrepLocation.DrinkPrepOrder, DrinkPrepLocation.InvMultiplier, DrinkPrep.DrinkPrepName FROM DrinkPrepLocation LEFT OUTER JOIN DrinkPrep ON DrinkPrepLocation.DrinkPrepID = DrinkPrep.DrinkPrepID WHERE (DrinkPrepLocation.Active = 1) AND DrinkPrepLocation.LocationID = '" + customLocationString + "' ORDER BY DrinkPrepLocation.DrinkPrepOrder, DrinkPrep.DrinkPrepName";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);


        DataRow oRow;

        try
        {
            foreach (DataRow currentORow in ds.Tables("AllFoodCategory").Rows)
            {
                oRow = currentORow;
                mainCategoryIDArrayList.Add(oRow("CategoryID"));
                secondaryCategoryIDArrayList.Add(oRow("CategoryID"));
            }
        }

        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);
        }

        return;
        // 222 below
        try
        {
            foreach (DataRow currentORow1 in ds.Tables("ModifierCategory").Rows)
            {
                oRow = currentORow1;
                tableCreating = "ModifierTable" + oRow("CategoryID");
                // 444     If oRow("FunctionFlag") = "G" Then
                // this was an attempt to ask for GeneralMenuID categories in Modifies
                // actually is getting this from FoodJoin in Menu Sub
                // 444       sqlStatement = "SELECT Foods.FoodID, Foods.CategoryID, Foods.FoodName, Foods.AbrevFoodName, Foods.ChitFoodName, Foods.Surcharge, Foods.FoodDesc, Foods.PrintPriorityID, Foods.RoutingID, Foods.PrepareTime, Foods.InvMultiplier, MenuJoin.MenuIndex, Category.FunctionID, Category.ButtonColor, Category.ButtonForeColor, Category.Extended, AABFunctions.FunctionID, AABFunctions.FunctionGroupID, AABFunctions.FunctionFlag, AABFunctions.TaxID FROM Foods LEFT OUTER JOIN Category ON Foods.CategoryID = Category.CategoryID LEFT OUTER JOIN MenuJoin ON Category.CategoryID = MenuJoin.GeneralMenuID LEFT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID WHERE MenuJoin.GeneralMenuID = '" & oRow("CategoryID") & "' AND MenuJoin.MenuID = '" & oRow("MenuID") & "' AND Foods.Active = 1 AND (Foods.CompanyID = '" & companyInfo.CompanyID & "') AND (Foods.LocationID = '" & customLocationString & "') ORDER BY Priority ASC"
                // 444    Else
                // sqlStatement = "SELECT Foods.FoodID, Foods.CategoryID, Foods.FoodName, Foods.AbrevFoodName, Foods.ChitFoodName, Foods.Surcharge, Foods.FoodDesc, Foods.PrintPriorityID, Foods.RoutingID, Foods.PrepareTime, Foods.InvMultiplier, Foods.MenuIndex, Category.FunctionID, Category.ButtonColor, Category.ButtonForeColor, Category.Extended, AABFunctions.FunctionID, AABFunctions.FunctionGroupID, AABFunctions.FunctionFlag, AABFunctions.TaxID FROM Foods LEFT OUTER JOIN Category ON Foods.CategoryID = Category.CategoryID LEFT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID WHERE Foods.MenuIndex > 0 AND Foods.CategoryID = '" & oRow("CategoryID") & "' AND Foods.Active = 1 AND (Foods.CompanyID = '" & companyInfo.CompanyID & "') AND (Foods.LocationID = '" & customLocationString & "') ORDER BY Priority ASC"
                // 444    End If
                sqlStatement = "SELECT Foods.FoodID, Foods.CategoryID, Foods.FoodName, Foods.AbrevFoodName, Foods.ChitFoodName, Foods.Surcharge, Foods.FoodDesc, Foods.PrintPriorityID, Foods.RoutingID, Foods.PrepareTime, Foods.InvMultiplier, Foods.MenuIndex, Category.FunctionID, Category.ButtonColor, Category.ButtonForeColor, Category.Extended, AABFunctions.FunctionID, AABFunctions.FunctionGroupID, AABFunctions.FunctionFlag, AABFunctions.TaxID FROM Foods LEFT OUTER JOIN Category ON Foods.CategoryID = Category.CategoryID LEFT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID WHERE Foods.MenuIndex > 0 AND Foods.CategoryID = '" + oRow("CategoryID") + "' AND Foods.Active = 1 AND (Foods.CompanyID = '" + companyInfo.CompanyID + "') AND (Foods.LocationID = '" + customLocationString + "') ORDER BY Priority ASC";
                ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);
                // below seems to be repeat, "M" is included in AllFoodCategory
                mainCategoryIDArrayList.Add(oRow("CategoryID"));
                secondaryCategoryIDArrayList.Add(oRow("CategoryID"));
                // DetermineMaxMenuIndex(tableCreating)
            }
        }
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);
        }

        // 999
        // this includes non-main food items for Add/No, only when category flagged 
        tableCreating = "ModifierCategory";
        sqlStatement = "SELECT Category.CompanyID, Category.LocationID, Category.CategoryID, Category.CategoryName, Category.CategoryAbrev, Category.CategoryOrder, Category.FunctionID, Category.ButtonColor, Category.ButtonForeColor, Category.Extended, AABFunctions.FunctionGroupID, AABFunctions.FunctionFlag FROM Category RIGHT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID WHERE (AABFunctions.FunctionFlag = 'G' OR AABFunctions.FunctionFlag = 'O') AND Category.DisplayWithAdd = '1' AND Category.CompanyID = '" + companyInfo.CompanyID + "' AND Category.LocationID = '" + customLocationString + "' AND Category.Active = 1 ORDER BY Priority ASC";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

    }

    public static void DetermineMaxMenuIndex222(string tableCreating)
    {

        // If ds.Tables(tableCreating).Rows.Count > 0 Then
        // If ds.Tables(tableCreating).Compute("Max(MenuIndex)", "") >= currentTerminal.MaxMenuIndex Then
        // 'currentTerminal.MaxMenuIndex = (ds.Tables(tableCreating).Compute("Max(MenuIndex)", "") + 60)
        // End If
        // End If
    }

    internal static void PopulateNONOrderTables()
    {

        string customLocationString;
        if (companyInfo.usingDefaults == false)
        {
            customLocationString = companyInfo.LocationID;
        }
        else
        {
            customLocationString = "000000";
        }


        tableCreating = "TableStatusDesc";
        sqlStatement = "SELECT TableStatusID, TableStatusDesc FROM TableStatusDesc";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

        tableCreating = "Tax";
        // sqlStatement = "SELECT TaxID, TaxName, TaxPercent FROM AABTaxTable WHERE CompanyID = '" & companyInfo.CompanyID & "' AND LocationID = '" & customLocationString & "'"
        sqlStatement = "SELECT TaxID, TaxName, TaxPercent FROM AABTaxTable WHERE TaxID = -1 OR LocationID = '" + customLocationString + "' ORDER BY TaxOrder ASC";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

        // Dim o As DataRow
        // For Each o In ds.Tables("Tax").Rows
        // MsgBox(o("TaxID"))
        // MsgBox(o("TaxName"))
        // Next
        // tableCreating = "MenuChoice"
        // sqlStatement = "SELECT MenuID, MenuName, LastOrder FROM MenuChoice WHERE Active = 1 AND CompanyID = '" & companyInfo.CompanyID & "' AND LocationID = '" & customLocationString & "'"
        // ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds)

        tableCreating = "RoutingChoice";
        sqlStatement = "SELECT RoutingID, RoutingName, isExpediterPrinter FROM RoutingChoice WHERE isServicePrinter = 1 AND CompanyID = '" + companyInfo.CompanyID + "' AND LocationID = '" + customLocationString + "'";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

        tableCreating = "CreditCardDetail";
        sqlStatement = "SELECT PaymentTypeID, PaymentTypeName FROM AABPaymentType"; // WHERE LocationID = '" & customLocationString & "'"
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

        tableCreating = "TabIdentifier";
        sqlStatement = "SELECT TabIdentifierID, TabSelectorIdentity, TabSelectorOrder FROM TabIdentity WHERE CompanyID = '" + companyInfo.CompanyID + "' AND LocationID = '" + customLocationString + "' ORDER BY TabSelectorOrder ASC";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);


        tableCreating = "ReasonsVoid";
        sqlStatement = "SELECT VoidID, VoidReason, VoidDescription, DisplayOrder, TypeDiscount FROM ReasonsVoid WHERE CompanyID = '" + companyInfo.CompanyID + "' AND LocationID = '" + customLocationString + "' ORDER BY DisplayOrder ASC";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

        if (ds.Tables("ReasonsVoid").Rows.Count == 0)
        {
            // this is for defaults at Location 000000
            tableCreating = "ReasonsVoid";
            sqlStatement = "SELECT VoidID, VoidReason, VoidDescription, DisplayOrder, TypeDiscount FROM ReasonsVoid WHERE LocationID = 000000 ORDER BY DisplayOrder ASC";
            ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);
        }
        // reasonsVoid()



        // need only for Modifying Order with Modify USer Control
        // now i think we only use for Extra / No and Special

        // sql.cn.Open()   ' we get error in previous sub
        // sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery()

        sql.SqlSelectCommandMenuRawUsage.Parameters("@LocationID").Value = customLocationString;
        sql.SqlMenuRawUsage.Fill(ds.Tables("Ingredients"));

        sql.SqlSelectCommandFoodTable.Parameters("@LocationID").Value = customLocationString;
        sql.SqlFoodTable.Fill(ds.Tables("FoodTable"));
        // sql.cn.Close()
        sql.SqlSelectCommandDailyShifts.Parameters("@LocationID").Value = customLocationString;
        sql.SqlSelectCommandDailyMenuChoice.Parameters("@LocationID").Value = customLocationString;

        sql.SqlDailyShifts.Fill(ds.Tables("ShiftCodes"));
        sql.SqlDailyMenuChoice.Fill(ds.Tables("MenuChoice"));

        PopulatePromoTables();

        // tableCreating = "Functions"
        // sqlStatement = "SELECT FunctionJoin.FunctionJoinID, FunctionJoin.CompanyID, FunctionJoin.LocationID, FunctionJoin.TaxID, FunctionJoin.DrinkRoutingID, Functions.FunctionGroupID, Functions.FunctionName, Functions.FunctionFlag FROM FunctionJoin LEFT OUTER JOIN Functions ON FunctionJoin.FunctionID = Functions.FunctionID WHERE CompanyID = '" & companyInfo.CompanyID & "' AND LocationID = '" & companyInfo.LocationID & "'"
        // dsOrder = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, dsOrder)

        // tableCreating = "ByServerLocal"
        // sqlStatement = "SELECT ByServerCategory, Dollar1, Dollar2, Sales1, Sales2, Time1 FROM ByServer"
        // ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds, True)

    }

    internal static void PopulatePromoTables()
    {
        // *************
        // we need to move this to the opening of the app
        // only do this once

        string customLocationString;
        if (companyInfo.usingDefaults == false)
        {
            customLocationString = companyInfo.LocationID;
        }
        else
        {
            customLocationString = "000000";
        }

        tableCreating = "Promotion";
        // sqlStatement = "SELECT PromoID, PromoName, BSGS, Combo, Coupon, MaxAmount, MaxCheck, MaxTable, TaxPromoAmount, TaxFoodCost, EstFoodCost, GuestPayTax, ManagerLevel, TipPromo FROM Promotion WHERE CompanyID = '" & companyInfo.CompanyID & "' AND LocationID = '" & customLocationString & "' AND StartDate < = '" & Today & "' AND EndDate > = '" & Today & "' AND Active = 1 OR StartDate IS NUll AND EndDate IS NULL"
        sqlStatement = "SELECT PromoID, PromoName, BSGS, Combo, Coupon, MaxAmount, MaxCheck, MaxTable, TaxPromoAmount, TaxFoodCost, EstFoodCost, GuestPayTax, ManagerLevel, TipPromo FROM Promotion WHERE CompanyID = '" + companyInfo.CompanyID + "' AND LocationID = '" + customLocationString + "' AND (StartDate < = '" + DateTime.Today + "' AND EndDate > = '" + DateTime.Today + "' OR Active = 1)"; // OR StartDate IS NUll AND EndDate IS NULL"
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);
        ds.Tables("Promotion").PrimaryKey = new DataColumn[] { ds.Tables("Promotion").Columns("PromoID") };

        tableCreating = "BSGS";
        sqlStatement = "SELECT PromoBSGS.PromoID, PromoBSGS.BuyFD_flag, PromoBSGS.BuyCategoryID, PromoBSGS.BuyCategoryAmount, PromoBSGS.BuyDrinkCategoryID, PromoBSGS.GetFD_flag, PromoBSGS.GetCategoryID, PromoBSGS.GetCategoryAmount, PromoBSGS.GetQuantityDiscount, PromoBSGS.GetDrinkCategoryID, Promotion.BSGS FROM PromoBSGS INNER JOIN Promotion ON PromoBSGS.PromoID = Promotion.PromoID WHERE PromoBSGS.CompanyID = '" + companyInfo.CompanyID + "' AND PromoBSGS.LocationID = '" + customLocationString + "' AND Promotion.BSGS = 1";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

        tableCreating = "Combo";
        sqlStatement = "SELECT PromoCombo.PromoID, PromoCombo.ComboFD_flag, PromoCombo.ComboCategoryID, PromoCombo.ComboCategoryMax, PromoCombo.ComboDrinkCategoryID, PromoCombo.ComboDrinkCategoryMax, Promotion.Combo FROM PromoCombo INNER JOIN Promotion ON PromoCombo.PromoID = Promotion.PromoID WHERE PromoCombo.CompanyID = '" + companyInfo.CompanyID + "' AND PromoCombo.LocationID = '" + customLocationString + "' AND Promotion.Combo = 1";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

        tableCreating = "ComboDetail";
        sqlStatement = "SELECT PromoComboDetail.PromoID, PromoComboDetail.ComboPrice, Promotion.Combo FROM PromoComboDetail INNER JOIN Promotion ON PromoComboDetail.PromoID = Promotion.PromoID WHERE PromoComboDetail.CompanyID = '" + companyInfo.CompanyID + "' AND PromoComboDetail.LocationID = '" + customLocationString + "' AND Promotion.Combo = 1";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);
        ds.Tables("ComboDetail").PrimaryKey = new DataColumn[] { ds.Tables("ComboDetail").Columns("PromoID") };

        tableCreating = "Coupon";
        sqlStatement = "SELECT PromoCoupon.PromoID, PromoCoupon.DiscountFD_flag, PromoCoupon.DiscountCategoryID, PromoCoupon.DiscountCategoryAmount, PromoCoupon.DiscountDrinkCategoryID, PromoCoupon.AtleastFD_flag, PromoCoupon.AtleastCategoryID, PromoCoupon.AtleastCategoryAmount, PromoCoupon.AtleastDrinkCategoryID, PromoCoupon.CouponDollarFlag, PromoCoupon.CouponDollarAmount, PromoCoupon.CouponPercentFlag, PromoCoupon.CouponPercentAmount, Promotion.Coupon FROM PromoCoupon INNER JOIN Promotion ON PromoCoupon.PromoID = Promotion.PromoID WHERE PromoCoupon.CompanyID = '" + companyInfo.CompanyID + "' AND PromoCoupon.LocationID = '" + customLocationString + "' AND Promotion.Coupon = 1";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

    }

    internal static void PopulateTerminalData()
    {

        // dsSetup.Tables("TermGroups").Clear()
        // dsSetup.Tables("Terminals").Clear()
        // dsSetup.Tables("TerminalsUseOrder").Clear()

        ds.Tables("TermsFloor").Clear();
        ds.Tables("TermsTables").Clear();
        ds.Tables("TermsWalls").Clear();

        // sql.cn.Open()
        // sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery()

        sql.SqlSelectCommandTermsFloor.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlSelectCommandTermsTables.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlSelectCommandTermsWalls.Parameters("@LocationID").Value = companyInfo.LocationID;

        sql.SqlSelectCommandTerms.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlSelectCommandTermsUse.Parameters("@LocationID").Value = companyInfo.LocationID;

        sql.SqlTermsFloor.Fill(ds.Tables("TermsFloor"));
        sql.SqlTermsTables.Fill(ds.Tables("TermsTables"));
        sql.SqlTermsWalls.Fill(ds.Tables("TermsWalls"));

        sql.SqlTerms.Fill(ds.Tables("TerminalsMethod"));
        sql.SqlTermsUse.Fill(ds.Tables("TerminalsUseOrder"));
        // sql.cn.Close()

        TestArray();


    }

    internal static void JustTestingTermsTables222()
    {

        foreach (DataRow oRow in ds.Tables("TermsTables").Rows)
        {
            if (oRow("TableNumber") == 12)
            {

                // don't think I need  Flag for new exp
                break;
            }
        }

    }

    internal static void PopulateEmployeeData()
    {

        dsEmployee.Tables("AllEmployees").Clear();
        dsEmployee.Tables("JobCodeInfo").Clear();
        dsStarter.Tables("StarterAllEmployees").Clear();
        dsStarter.Tables("StarterJobCodeInfo").Clear();

        sql.SqlSelectCommandEmployeesAll.Parameters("@CompanyID").Value = companyInfo.CompanyID;
        sql.SqlSelectCommandEmployeesAll.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlSelectCommandJobCodeInfo.Parameters("@CompanyID").Value = companyInfo.CompanyID;
        sql.SqlSelectCommandJobCodeInfo.Parameters("@LocationID").Value = companyInfo.LocationID;

        // opened before we get here
        try
        {
            sql.SqlDataAdapterEmployeesAll.Fill(dsEmployee.Tables("AllEmployees"));
            sql.SqlDataAdapterJobCodeInfo.Fill(dsEmployee.Tables("JobCodeInfo"));

            sql.SqlDataAdapterEmployeesAll.Fill(dsStarter.Tables("StarterAllEmployees"));
            sql.SqlDataAdapterJobCodeInfo.Fill(dsStarter.Tables("StarterJobCodeInfo"));
        }

        catch (Exception ex)
        {

        }

    }

    internal static void ClearEmployeeCollections()
    {

        currentManagers.Clear();
        currentServers.Clear();
        currentBartenders.Clear();
        todaysFloorPersonnel.Clear();
        AllEmployees.Clear();
        allFloorPersonnel.Clear();
        SalariedEmployees.Clear();
        workingEmployees.Clear();

    }

    internal static void PopulateAllEmployeeColloection()
    {
        Employee newEmployee;
        var tempDT = new DataTable();
        bool isFloor;

        ClearEmployeeCollections();

        if (dsEmployee.Tables("AllEmployees").Rows.Count > 0)
        {
            tempDT = dsEmployee.Tables("AllEmployees");
        }
        else
        {
            tempDT = dsStarter.Tables("StarterAllEmployees");
        }

        if (tempDT is null)
        {
            // we have no employees
            Interaction.MsgBox("There are no employees in the system. Spider POS can't operate without employees.");
        }


        foreach (DataRow oRow in tempDT.Rows)  // dsEmployee.Tables("AllEmployees").Rows '
        {
            isFloor = false;
            newEmployee = new Employee();

            newEmployee.EmployeeID = oRow("EmployeeID");
            newEmployee.EmployeeNumber = oRow("EmployeeNumber");
            newEmployee.FullName = oRow("FirstName") + " " + oRow("LastName");
            if (object.ReferenceEquals(oRow("NickName"), DBNull.Value))
            {
                newEmployee.NickName = oRow("FirstName");
            }
            else
            {
                newEmployee.NickName = oRow("NickName");
            }
            if (newEmployee.NickName.Length < 1)
            {
                newEmployee.NickName = oRow("FirstName");
            }
            newEmployee.PasscodeID = oRow("Passcode");
            if (!object.ReferenceEquals(oRow("SwipeCode"), DBNull.Value))
            {
                newEmployee.SwipeCode = oRow("SwipeCode");
            }
            else
            {
                newEmployee.SwipeCode = "no swipe";
            }
            newEmployee.Training = oRow("Training");
            newEmployee.ClockInReq = oRow("ClockInReq");
            newEmployee.ReportMgmtAll = oRow("ReportMgmtAll");
            newEmployee.ReportMgmtLimited = oRow("ReportMgmtLimited");
            newEmployee.OperationMgmtAll = oRow("OperationMgmtAll");
            newEmployee.OperationMgmtLimited = oRow("OperationMgmtLimited");
            newEmployee.SystemMgmtAll = oRow("SystemMgmtAll");
            newEmployee.SystemMgmtLimited = oRow("SystemMgmtLimited");
            newEmployee.EmployeeMgmtAll = oRow("EmployeeMgmtAll");
            newEmployee.EmployeeMgmtLimited = oRow("EmployeeMgmtLimited");
            // this makes the first time for ewach day password is req
            newEmployee.PasswordReq = true;

            if (!object.ReferenceEquals(oRow("JobCodeID1"), DBNull.Value))
            {
                newEmployee.JobCode1 = oRow("JobCodeID1");
                newEmployee.JobRate1 = oRow("JobRate1");
                newEmployee.JobName1 = oRow("JobName1");
                if (isFloor == false)
                {
                    isFloor = Conversions.ToBoolean(TestIfFloorPersonnel(newEmployee.JobCode1));
                }
            }
            if (!object.ReferenceEquals(oRow("JobCodeID2"), DBNull.Value))
            {
                newEmployee.JobCode2 = oRow("JobCodeID2");
                newEmployee.JobRate2 = oRow("JobRate2");
                newEmployee.JobName2 = oRow("JobName2");
                if (isFloor == false)
                {
                    isFloor = Conversions.ToBoolean(TestIfFloorPersonnel(newEmployee.JobCode2));
                }
            }
            if (!object.ReferenceEquals(oRow("JobCodeID3"), DBNull.Value))
            {
                newEmployee.JobCode3 = oRow("JobCodeID3");
                newEmployee.JobRate3 = oRow("JobRate3");
                newEmployee.JobName3 = oRow("JobName3");
                if (isFloor == false)
                {
                    isFloor = Conversions.ToBoolean(TestIfFloorPersonnel(newEmployee.JobCode3));
                }
            }
            if (!object.ReferenceEquals(oRow("JobCodeID4"), DBNull.Value))
            {
                newEmployee.JobCode4 = oRow("JobCodeID4");
                newEmployee.JobRate4 = oRow("JobRate4");
                newEmployee.JobName4 = oRow("JobName4");
                if (isFloor == false)
                {
                    isFloor = Conversions.ToBoolean(TestIfFloorPersonnel(newEmployee.JobCode4));
                }
            }
            if (!object.ReferenceEquals(oRow("JobCodeID5"), DBNull.Value))
            {
                newEmployee.JobCode5 = oRow("JobCodeID5");
                newEmployee.JobRate5 = oRow("JobRate5");
                newEmployee.JobName5 = oRow("JobName5");
                if (isFloor == false)
                {
                    isFloor = Conversions.ToBoolean(TestIfFloorPersonnel(newEmployee.JobCode5));
                }
            }
            if (!object.ReferenceEquals(oRow("JobCodeID6"), DBNull.Value))
            {
                newEmployee.JobCode6 = oRow("JobCodeID6");
                newEmployee.JobRate6 = oRow("JobRate6");
                newEmployee.JobName6 = oRow("JobName6");
                if (isFloor == false)
                {
                    isFloor = Conversions.ToBoolean(TestIfFloorPersonnel(newEmployee.JobCode6));
                }
            }
            if (!object.ReferenceEquals(oRow("JobCodeID7"), DBNull.Value))
            {
                newEmployee.JobCode7 = oRow("JobCodeID7");
                newEmployee.JobRate7 = oRow("JobRate7");
                newEmployee.JobName7 = oRow("JobName7");
                if (isFloor == false)
                {
                    isFloor = Conversions.ToBoolean(TestIfFloorPersonnel(newEmployee.JobCode7));
                }
            }
            if (!object.ReferenceEquals(oRow("Lefty"), DBNull.Value))
            {
                newEmployee.Lefty = oRow("Lefty");
            }
            else
            {
                newEmployee.Lefty = false;
            }

            AddEmployeeToAllEmployeeCollection(newEmployee);
            if (isFloor == true & !(newEmployee.EmployeeID == 6986))
            {
                AddEmployeeToAllFloorCollection(newEmployee);
            }
            if (!(newEmployee.SwipeCode == "no swipe"))
            {
                AddEmployeeToSwipeCodeEmployeesEmployeeCollection(newEmployee);
                // we are alos populating the same collection in ReadAuth_MWE
                // we can remove this after we go to onlyReadAuth_MWE
            }

            if (newEmployee.ClockInReq == false)
            {
                // If Not newEmployee.EmployeeID = 6986 Then
                newEmployee.JobCodeID = newEmployee.JobCode1;
                // Else
                // newEmployee.Bartender = True
                // End If

                // ************
                // currently only managers can not req a Clock In
                AddEmployeeToSalariedEmployeeCollection(newEmployee);
                FillJobCodeInfo(ref newEmployee, newEmployee.JobCodeID);
                AddEmployeeToCollections(newEmployee);

            }

            if (typeProgram == "Online_Demo" & !(newEmployee.EmployeeID == 6986))
            {
                Demo_LoadJobCodeFunctions(ref newEmployee);
                GenerateWorkingCollections.AddEmployeeToCollections(newEmployee);
            }
        }

    }

    private static object TestIfFloorPersonnel(int jID)
    {

        bool isFloor = false;

        foreach (DataRow oRow in dsEmployee.Tables("JobCodeInfo").Rows)
        {
            if (oRow("JobCodeID") == jID)
            {
                if (oRow("Manager") == true | oRow("Bartender") == true | oRow("Server") == true | oRow("Cashier") == true)
                {
                    isFloor = true;
                    break;
                }
            }
        }

        return isFloor;

    }

    private static void TestArray()
    {

        if (ds.Tables("TermsTables").Rows.Count > numberOfTables)
        {
            numberOfTables = ds.Tables("TermsTables").Rows.Count;
            ;
#error Cannot convert ReDimStatementSyntax - see comment for details
            /* Cannot convert ReDimStatementSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.VisualBasic.Symbols.ErrorTypeSymbol' to type 'Microsoft.CodeAnalysis.IArrayTypeSymbol'.
                           at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.CreateNewArrayAssignment(ExpressionSyntax vbArrayExpression, ExpressionSyntax csArrayExpression, List`1 convertedBounds) in D:\GitWorkspace\CodeConverter\CodeConverter\CSharp\MethodBodyExecutableStatementVisitor.cs:line 423
                           at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.ConvertRedimClauseAsync(RedimClauseSyntax node) in D:\GitWorkspace\CodeConverter\CodeConverter\CSharp\MethodBodyExecutableStatementVisitor.cs:line 321
                           at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<VisitReDimStatement>b__41_0(RedimClauseSyntax arrayExpression) in D:\GitWorkspace\CodeConverter\CodeConverter\CSharp\MethodBodyExecutableStatementVisitor.cs:line 303
                           at ICSharpCode.CodeConverter.Common.AsyncEnumerableTaskExtensions.SelectAsync[TArg,TResult](IEnumerable`1 source, Func`2 selector) in D:\GitWorkspace\CodeConverter\CodeConverter\Common\AsyncEnumerableTaskExtensions.cs:line 0
                           at ICSharpCode.CodeConverter.Common.AsyncEnumerableTaskExtensions.SelectManyAsync[TArg,TResult](IEnumerable`1 nodes, Func`2 selector) in D:\GitWorkspace\CodeConverter\CodeConverter\Common\AsyncEnumerableTaskExtensions.cs:line 0
                           at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.VisitReDimStatement(ReDimStatementSyntax node) in D:\GitWorkspace\CodeConverter\CodeConverter\CSharp\MethodBodyExecutableStatementVisitor.cs:line 303
                           at ICSharpCode.CodeConverter.CSharp.PerScopeStateVisitorDecorator.AddLocalVariablesAsync(VisualBasicSyntaxNode node, SyntaxKind exitableType, Boolean isBreakableInCs) in D:\GitWorkspace\CodeConverter\CodeConverter\CSharp\PerScopeStateVisitorDecorator.cs:line 38
                           at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisitInnerAsync(SyntaxNode node) in D:\GitWorkspace\CodeConverter\CodeConverter\CSharp\CommentConvertingMethodBodyVisitor.cs:line 24

                        Input:
                                    ReDim btnTable(numberOfTables)

                         */
        }

        if (ds.Tables("TermsWalls").Rows.Count > numberOfWalls)
        {
            numberOfWalls = ds.Tables("TermsWalls").Rows.Count;
            ;
#error Cannot convert ReDimStatementSyntax - see comment for details
            /* Cannot convert ReDimStatementSyntax, System.InvalidCastException: Unable to cast object of type 'Microsoft.CodeAnalysis.VisualBasic.Symbols.ErrorTypeSymbol' to type 'Microsoft.CodeAnalysis.IArrayTypeSymbol'.
                           at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.CreateNewArrayAssignment(ExpressionSyntax vbArrayExpression, ExpressionSyntax csArrayExpression, List`1 convertedBounds) in D:\GitWorkspace\CodeConverter\CodeConverter\CSharp\MethodBodyExecutableStatementVisitor.cs:line 423
                           at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.ConvertRedimClauseAsync(RedimClauseSyntax node) in D:\GitWorkspace\CodeConverter\CodeConverter\CSharp\MethodBodyExecutableStatementVisitor.cs:line 321
                           at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<VisitReDimStatement>b__41_0(RedimClauseSyntax arrayExpression) in D:\GitWorkspace\CodeConverter\CodeConverter\CSharp\MethodBodyExecutableStatementVisitor.cs:line 303
                           at ICSharpCode.CodeConverter.Common.AsyncEnumerableTaskExtensions.SelectAsync[TArg,TResult](IEnumerable`1 source, Func`2 selector) in D:\GitWorkspace\CodeConverter\CodeConverter\Common\AsyncEnumerableTaskExtensions.cs:line 0
                           at ICSharpCode.CodeConverter.Common.AsyncEnumerableTaskExtensions.SelectManyAsync[TArg,TResult](IEnumerable`1 nodes, Func`2 selector) in D:\GitWorkspace\CodeConverter\CodeConverter\Common\AsyncEnumerableTaskExtensions.cs:line 0
                           at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.VisitReDimStatement(ReDimStatementSyntax node) in D:\GitWorkspace\CodeConverter\CodeConverter\CSharp\MethodBodyExecutableStatementVisitor.cs:line 303
                           at ICSharpCode.CodeConverter.CSharp.PerScopeStateVisitorDecorator.AddLocalVariablesAsync(VisualBasicSyntaxNode node, SyntaxKind exitableType, Boolean isBreakableInCs) in D:\GitWorkspace\CodeConverter\CodeConverter\CSharp\PerScopeStateVisitorDecorator.cs:line 38
                           at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisitInnerAsync(SyntaxNode node) in D:\GitWorkspace\CodeConverter\CodeConverter\CSharp\CommentConvertingMethodBodyVisitor.cs:line 24

                        Input:
                                    ReDim btnWall(numberOfWalls)

                         */
        }

    }

    internal static void GenerateOverrideCodes()
    {

        // 2       All     (most restrictive)
        // 1       Limited
        // 0       Nothing

        systemAuthorization = new OverrideSystemCode();

        systemAuthorization.VoidItem = 2;
        systemAuthorization.ForcePrice = 1;
        systemAuthorization.CompItem = 1;
        systemAuthorization.TaxExempt = 1;
        systemAuthorization.ReopenCheck = 2;
        systemAuthorization.VoidCheck = 2;
        systemAuthorization.AdjustPayment = 2;
        systemAuthorization.AssignComps = 2;
        systemAuthorization.AssignGratuity = 2;
        systemAuthorization.TransferItem = 1;
        systemAuthorization.TransferCheck = 1;
        systemAuthorization.ReprintCheck = 1;
        systemAuthorization.ReprintOrder = 2;
        systemAuthorization.ReprintCredit = 2;



    }

    internal static void AssignManagementAuthorization(ref Employee empAuth)
    {

        // employeeAuthorization = New ManagementAuthorization

        employeeAuthorization.FullName = empAuth.FullName;

        if (empAuth.OperationMgmtAll == true)
        {
            employeeAuthorization.OperationLevel = 2;
        }
        else if (empAuth.OperationMgmtLimited == true)
        {
            employeeAuthorization.OperationLevel = 1;
        }
        else
        {
            employeeAuthorization.OperationLevel = 0;
        }

        if (empAuth.EmployeeMgmtAll == true)
        {
            employeeAuthorization.EmployeeLevel = 2;
        }
        else if (empAuth.EmployeeMgmtLimited == true)
        {
            employeeAuthorization.EmployeeLevel = 1;
        }
        else
        {
            employeeAuthorization.EmployeeLevel = 0;
        }

        if (empAuth.ReportMgmtAll == true)
        {
            employeeAuthorization.ReportLevel = 2;
        }
        else if (empAuth.ReportMgmtLimited == true)
        {
            employeeAuthorization.ReportLevel = 1;
        }
        else
        {
            employeeAuthorization.ReportLevel = 0;
        }

        if (empAuth.SystemMgmtAll == true)
        {
            employeeAuthorization.SystemLevel = 2;
        }
        else if (empAuth.SystemMgmtLimited == true)
        {
            employeeAuthorization.SystemLevel = 1;
        }
        else
        {
            employeeAuthorization.SystemLevel = 0;
        }

        // do not need below anymore
        // employeeAuthorization.OperationAll = empAuth.OperationMgmtAll
        // employeeAuthorization.OperationLimited = empAuth.OperationMgmtLimited
        // employeeAuthorization.EmployeeAll = empAuth.EmployeeMgmtAll
        // employeeAuthorization.EmployeeLimited = empAuth.EmployeeMgmtLimited
        // employeeAuthorization.ReportAll = empAuth.ReportMgmtAll
        // '     employeeAuthorization.ReportLimited = empAuth.ReportMgmtLimited
        // employeeAuthorization.SystemAll = empAuth.SystemMgmtAll
        // employeeAuthorization.SystemLimited = empAuth.SystemMgmtLimited

    }

    // Friend Sub PopulateAvailTables(ByVal empID As Integer)

    // '     tableCreating = "AvailTables"
    // sqlStatement = "SELECT TableStatus.TableNumber, TableStatus.SatTime, TableStatus.LastStatus, TableStatus.LastStatusTime, TableStatus.AverageDollar FROM TableStatus WHERE EmployeeID ='" & empID & "'"
    // dsOrder = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, dsOrder)

    // tableCreating = "AvailTabs"
    // sqlStatement = "SELECT TabID, TabName, MenuID, EmployeeID, NumberOfCustomers, NumberOfChecks, SatTime, CloseTime, LastStatus, LastStatusTime, AverageDollar FROM TabStatus WHERE EmployeeID ='" & empID & "'"
    // dsOrder = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, dsOrder)

    // End Sub


    // not sure if needed
    public static void SetUpPrimaryKeys()
    {

        // we must clone before we add primary keys, since all terminal tables do not have pk's
        // don't use  dtOpenOrdersTerminal = dtOpenOrders.Clone
        // dtPaymentsAndCreditsTerminal = dtPaymentsAndCredits.Clone

        if (!(typeProgram == "Online_Demo"))
        {
            dsOrder.Tables("OpenOrders").PrimaryKey = new DataColumn[] { dsOrder.Tables("OpenOrders").Columns("sin") };
        }
        // don't use      dsBackup.Tables("OpenOrdersTerminal").PrimaryKey = New DataColumn() {dsBackup.Tables("OpenOrdersTerminal").Columns("OpenOrderTerminalID")}
        ds.Tables("Tax").PrimaryKey = new DataColumn[] { ds.Tables("Tax").Columns("TaxID") };
        dsOrder.Tables("Functions").PrimaryKey = new DataColumn[] { dsOrder.Tables("Functions").Columns("FunctionID") };


        // dsBackup.Tables("AvailTablesTerminal").PrimaryKey = New DataColumn() {dsBackup.Tables("AvailTablesTerminal").Columns("ExperienceNumber")}
        // dsBackup.Tables("AvailTabsTerminal").PrimaryKey = New DataColumn() {dsBackup.Tables("AvailTabsTerminal").Columns("ExperienceNumber")}
        // ds.Tables("Ingredients").PrimaryKey = New DataColumn() {ds.Tables("Ingredients").Columns("RawItemID")}

    }

    internal static void SetAutoIncrement222()
    {

        // ????   don't we want auto increment when down ?????
        dsBackup.Tables("AvailTablesTerminal").Columns("ExperienceNumber").AutoIncrement = true;
        dsBackup.Tables("AvailTabsTerminal").Columns("ExperienceNumber").AutoIncrement = true;
        // dsBackup.Tables("OpenOrdersTerminal").Columns("OpenOrderID").AutoIncrement = True

    }

    internal static void FillLocationOverviewData(ref DataRow oRow)
    {

        try
        {
            companyInfo.CompanyID = oRow("CompanyID");
            companyInfo.LocationID = oRow("LocationID");
            companyInfo.companyName = oRow("CompanyName");
            if (!object.ReferenceEquals(oRow("LocationName"), DBNull.Value))
            {
                companyInfo.locationName = oRow("LocationName");
            }
            companyInfo.locationUsername = oRow("Username");
            companyInfo.locationPassword = oRow("Password");
            companyInfo.locationCity = oRow("City");
            companyInfo.locationState = oRow("State");
            companyInfo.address1 = oRow("Address1");
            companyInfo.address2 = oRow("Address2");
            companyInfo.locationPhone = oRow("PhoneNumber");
            companyInfo.usingDefaults = oRow("UsingDefaults");
            companyInfo.autoPrint = oRow("AutoPrint");
            companyInfo.endOfWeek = oRow("EndOfWeek");
            companyInfo.overtimeRate = oRow("OvertimeRate");
            companyInfo.onlyOneLocation = oRow("OnlyOneLocation");
            if (!object.ReferenceEquals(oRow("Processor"), DBNull.Value))
            {
                companyInfo.processor = oRow("Processor");
            }
            if (!object.ReferenceEquals(oRow("MerchantID"), DBNull.Value))
            {
                companyInfo.merchantID = oRow("MerchantID");
            }
            if (!object.ReferenceEquals(oRow("MerchantIDPhone"), DBNull.Value))
            {
                companyInfo.merchantIDPhone = oRow("MerchantIDPhone");
            }
            if (!object.ReferenceEquals(oRow("OperatorID"), DBNull.Value))
            {
                companyInfo.operatorID = oRow("OperatorID");
            }

            companyInfo.ClientID = oRow("ClientID");
            companyInfo.UserID = oRow("UserID");
            companyInfo.UserPW = oRow("UserPW");
            companyInfo.IPAddress = oRow("IPAddress");
            if (!object.ReferenceEquals(oRow("LocalHostName"), DBNull.Value))
            {
                companyInfo.localHostName = oRow("LocalHostName");
            }
            if (!object.ReferenceEquals(oRow("dbName"), DBNull.Value))
            {
                companyInfo.dbName = oRow("dbName");
            }

            companyInfo.numberOfTerminals = oRow("NumberTerminals");
            companyInfo.numberOfFloorPlans = oRow("NumberFloorPlans");
            companyInfo.timeoutMultiplier = oRow("TimeoutSeconds");
            companyInfo.colorAdjust = oRow("ColorAdjust");
            companyInfo.VersionNumber = "Spider POS v" + global::My.Application.Info.Version.ToString();
            // MsgBox(companyInfo.VersionNumber)

            if (!object.ReferenceEquals(oRow("LastUpdate"), DBNull.Value))
            {
                companyInfo.lastUpdate = oRow("LastUpdate");
            }
            companyInfo.autoUpdate = oRow("AutoUpdate");
            companyInfo.usingBartenderMethod = oRow("UsingBartenderMethod");
            companyInfo.calculateAvgByEntrees = oRow("CalculateAvgByEntrees");
            companyInfo.isKitchenExpiditer = oRow("IsKitchenExpiditer");
            companyInfo.isDelivery = oRow("IsDelivery");
            companyInfo.autoCloseCheck = oRow("AutoCloseCheck");
            companyInfo.usingOutsideCreditProcessor = oRow("UsingOtherCreditProcessor");
            companyInfo.autoReleaseExperience = oRow("AutoReleaseExperience"); // True
            companyInfo.fastCashClose = oRow("FastCashClose");
            companyInfo.servesMixedDrinks = oRow("ServesMixedDrinks"); // False
            companyInfo.deliveryCharge = oRow("DeliveryCharge");
            companyInfo.togoCharge = oRow("ToGoCharge");
            companyInfo.autoGratuityPercent = oRow("AutoGratuity");
            companyInfo.autoGratuityNumber = oRow("AutoGratuityNumber");
            companyInfo.salesTax = oRow("SalesTax");
            companyInfo.empDisc = oRow("EmpDisc");

            if (!object.ReferenceEquals(oRow("ReceiptMessage1"), DBNull.Value))
            {
                companyInfo.receiptMessage1 = oRow("ReceiptMessage1");
            }
            if (!object.ReferenceEquals(oRow("ReceiptMessage2"), DBNull.Value))
            {
                companyInfo.receiptMessage2 = oRow("ReceiptMessage2");
            }
            if (!object.ReferenceEquals(oRow("ReceiptMessage3"), DBNull.Value))
            {
                companyInfo.receiptMessage3 = oRow("ReceiptMessage3");
            }
            if (!object.ReferenceEquals(oRow("CCMessage1"), DBNull.Value))
            {
                companyInfo.CCMessage1 = oRow("CCMessage1");
            }
            if (!object.ReferenceEquals(oRow("CCMessage2"), DBNull.Value))
            {
                companyInfo.CCMessage2 = oRow("CCMessage2");
            }

            companyInfo.digitsInTicketNumber = oRow("DigitsInTicketNumber");
        }

        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);
        }

    }



    internal static void LoadStarterDataSet()
    {

        // we can try these as groups b/c they will Structure as groups
        // 444      Try
        // we want to fail in the sending sub

        CreateLocationOverviewTableStructure(dtStarterLocationOverview);
        CreateAllFoodCategoryTableStructure(dtStarterAllFoodCategory);
        CreateModifierCategoryTableStructure(dtStarterModifierCategory);
        CreateAllEmployeesTableStructure(dtStarterAllEmployees);
        CreateJobCodeInfoTableStructure(dtStarterJobCodeInfo);

        dsStarter.Clear();

        if (typeProgram == "Online_Demo")
        {
            dsStarter.ReadXml("StarterMenu.xml", XmlReadMode.ReadSchema);
        }
        else
        {
            dsStarter.ReadXml(@"c:\Data Files\spiderPOS\StarterMenu.xml", XmlReadMode.ReadSchema);
        }

        // Catch ex As Exception

        // MsgBox(ex.Message)

        // End Try

        // Try
        // CreateAllEmployeesTableStructure(dtStarterAllEmployees)
        // CreateJobCodeInfoTableStructure(dtStarterJobCodeInfo)
        // Catch ex As Exception
        // End Try

    }


    internal static void CreateLocationOverviewTableStructure(DataTable tName)
    {

        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("CompanyName", Type.GetType("System.String"));
        tName.Columns.Add("LocationName", Type.GetType("System.String"));
        tName.Columns.Add("Username", Type.GetType("System.String"));
        tName.Columns.Add("Password", Type.GetType("System.String"));
        tName.Columns.Add("BackPass", Type.GetType("System.String"));
        tName.Columns.Add("Domain_Report", Type.GetType("System.String"));
        tName.Columns.Add("Hostname_Report", Type.GetType("System.String"));

        tName.Columns.Add("Address1", Type.GetType("System.String"));
        tName.Columns.Add("Address2", Type.GetType("System.String"));
        tName.Columns.Add("City", Type.GetType("System.String"));
        tName.Columns.Add("State", Type.GetType("System.String"));
        tName.Columns.Add("Zip", Type.GetType("System.String"));
        tName.Columns.Add("PhoneNumber", Type.GetType("System.String"));

        tName.Columns.Add("UsingDefaults", Type.GetType("System.Boolean"));
        tName.Columns.Add("AutoPrint", Type.GetType("System.Boolean"));
        tName.Columns.Add("EndOfWeek", Type.GetType("System.Int16"));
        tName.Columns.Add("EndOfNightDecimal", Type.GetType("System.Decimal"));
        tName.Columns.Add("OvertimeHours", Type.GetType("System.Int16"));
        tName.Columns.Add("OvertimeRate", Type.GetType("System.Decimal"));
        tName.Columns.Add("OnlyOneLocation", Type.GetType("System.Boolean"));
        tName.Columns.Add("Processor", Type.GetType("System.String"));
        tName.Columns.Add("MerchantID", Type.GetType("System.String"));
        tName.Columns.Add("MerchantIDPhone", Type.GetType("System.String"));
        tName.Columns.Add("OperatorID", Type.GetType("System.String"));

        tName.Columns.Add("ClientID", Type.GetType("System.String"));
        tName.Columns.Add("UserID", Type.GetType("System.String"));
        tName.Columns.Add("UserPW", Type.GetType("System.String"));
        tName.Columns.Add("IPAddress", Type.GetType("System.String"));
        tName.Columns.Add("LocalHostName", Type.GetType("System.String"));
        tName.Columns.Add("dbName", Type.GetType("System.String"));

        tName.Columns.Add("NumberTerminals", Type.GetType("System.Int16"));
        tName.Columns.Add("NumberFloorPlans", Type.GetType("System.Int16"));
        tName.Columns.Add("TimeoutSeconds", Type.GetType("System.Int16"));
        tName.Columns.Add("ColorAdjust", Type.GetType("System.Int16"));
        tName.Columns.Add("VersionNumber", Type.GetType("System.String"));
        tName.Columns.Add("LastUpdate", Type.GetType("System.DateTime"));
        tName.Columns.Add("AutoUpdate", Type.GetType("System.Boolean"));
        tName.Columns.Add("UsingBartenderMethod", Type.GetType("System.Boolean"));
        tName.Columns.Add("BarDoNotPrintDrinks", Type.GetType("System.Boolean"));
        tName.Columns.Add("CalculateAvgByEntrees", Type.GetType("System.Boolean"));

        tName.Columns.Add("IsKitchenExpiditer", Type.GetType("System.Boolean"));
        tName.Columns.Add("IsDelivery", Type.GetType("System.Boolean"));
        tName.Columns.Add("AutoCloseCheck", Type.GetType("System.Boolean"));
        tName.Columns.Add("UsingOtherCreditProcessor", Type.GetType("System.Boolean"));
        tName.Columns.Add("AutoReleaseExperience", Type.GetType("System.Boolean"));
        tName.Columns.Add("FastCashClose", Type.GetType("System.Boolean"));
        tName.Columns.Add("ServesMixedDrinks", Type.GetType("System.Boolean"));
        tName.Columns.Add("DeliveryCharge", Type.GetType("System.Decimal"));
        tName.Columns.Add("ToGoCharge", Type.GetType("System.Decimal"));
        tName.Columns.Add("AutoGratuity", Type.GetType("System.Decimal"));
        tName.Columns.Add("AutoGratuityNumber", Type.GetType("System.Int32"));
        tName.Columns.Add("SalesTax", Type.GetType("System.Decimal"));
        tName.Columns.Add("EmpDisc", Type.GetType("System.Decimal"));

        tName.Columns.Add("ReceiptMessage1", Type.GetType("System.String"));
        tName.Columns.Add("ReceiptMessage2", Type.GetType("System.String"));
        tName.Columns.Add("ReceiptMessage3", Type.GetType("System.String"));
        tName.Columns.Add("CCMessage1", Type.GetType("System.String"));
        tName.Columns.Add("CCMessage2", Type.GetType("System.String"));
        tName.Columns.Add("DigitsInTicketNumber", Type.GetType("System.Int32"));



    }

    internal static void CreateLocationOpeningTableStructure(DataTable tName)
    {

        tName.Columns.Add("LocationOpeningPK", Type.GetType("System.Int32"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("AppType", Type.GetType("System.String"));
        tName.Columns.Add("LastAppVersion", Type.GetType("System.Int32"));
        tName.Columns.Add("menuVersion", Type.GetType("System.Int32"));
        tName.Columns.Add("empVersion", Type.GetType("System.Int32"));
        tName.Columns.Add("menuChangeDate", Type.GetType("System.DateTime"));
        tName.Columns.Add("empChangeDate", Type.GetType("System.DateTime"));
        tName.Columns.Add("mainTerminalsPrimaryKey", Type.GetType("System.Int32"));

    }


    internal static void CreateAllFoodCategoryTableStructure(DataTable tName)
    {

        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("CategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionID", Type.GetType("System.Int32"));
        tName.Columns.Add("ButtonColor", Type.GetType("System.Int32"));
        tName.Columns.Add("ButtonForeColor", Type.GetType("System.Int32"));
        tName.Columns.Add("Extended", Type.GetType("System.Boolean"));
        tName.Columns.Add("FunctionGroupID", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionFlag", Type.GetType("System.String"));
        tName.Columns.Add("TaxID", Type.GetType("System.Int32"));

    }

    internal static void CreateModifierCategoryTableStructure(DataTable tName)
    {

        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("CategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("CategoryName", Type.GetType("System.String"));
        tName.Columns.Add("CategoryAbrev", Type.GetType("System.String"));
        tName.Columns.Add("CategoryOrder", Type.GetType("System.Int32"));
        tName.Columns.Add("ButtonColor", Type.GetType("System.Int32"));
        tName.Columns.Add("ButtonForeColor", Type.GetType("System.Int32"));
        tName.Columns.Add("Extended", Type.GetType("System.Boolean"));
        tName.Columns.Add("FunctionID", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionGroupID", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionFlag", Type.GetType("System.String"));

    }



    internal static void CreateModifierTableStructure(string tName)
    {

        ds.Tables.Add(tName);

        ds.Tables(tName).Columns.Add("FoodID", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("CategoryID", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("FoodName", Type.GetType("System.String"));
        ds.Tables(tName).Columns.Add("AbrevFoodName", Type.GetType("System.String"));
        ds.Tables(tName).Columns.Add("ChitFoodName", Type.GetType("System.String"));
        ds.Tables(tName).Columns.Add("Surcharge", Type.GetType("System.Decimal"));
        ds.Tables(tName).Columns.Add("FoodDesc", Type.GetType("System.String"));
        ds.Tables(tName).Columns.Add("PrintPriorityID", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("RoutingID", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("PrepareTime", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("InvMultiplier", Type.GetType("System.Decimal"));
        ds.Tables(tName).Columns.Add("MenuIndex", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("FunctionID", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("ButtonColor", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("ButtonForeColor", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("Extended", Type.GetType("System.Boolean"));
        ds.Tables(tName).Columns.Add("FunctionID1", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("FunctionGroupID", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("FunctionFlag", Type.GetType("System.String"));
        ds.Tables(tName).Columns.Add("TaxID", Type.GetType("System.Int32"));

    }


    internal static void CreateFoodTableTableStructure(DataTable tName)
    {

        tName.Columns.Add("FoodID", Type.GetType("System.Int32"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("FoodName", Type.GetType("System.String"));
        tName.Columns.Add("AbrevFoodName", Type.GetType("System.String"));
        tName.Columns.Add("ChitFoodName", Type.GetType("System.String"));
        tName.Columns.Add("CategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("TaxExempt", Type.GetType("System.Boolean"));
        tName.Columns.Add("FoodDesc", Type.GetType("System.String"));
        tName.Columns.Add("WineParringID", Type.GetType("System.Int32"));
        tName.Columns.Add("RoutingID", Type.GetType("System.Int32"));
        tName.Columns.Add("PrintPriorityID", Type.GetType("System.Int32"));
        tName.Columns.Add("Active", Type.GetType("System.Boolean"));
        tName.Columns.Add("PrepareTime", Type.GetType("System.Int32"));
        tName.Columns.Add("InvMultiplier", Type.GetType("System.Decimal"));
        tName.Columns.Add("FoodInvOn", Type.GetType("System.Boolean"));
        tName.Columns.Add("FoodInv", Type.GetType("System.Int32"));
        tName.Columns.Add("AvailForExtraNo", Type.GetType("System.Boolean"));
        tName.Columns.Add("FunctionID", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionGroupID", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionName", Type.GetType("System.String"));
        tName.Columns.Add("FunctionFlag", Type.GetType("System.String"));
        tName.Columns.Add("TaxID", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkRoutingID", Type.GetType("System.Int32"));
        tName.Columns.Add("Expr1", Type.GetType("System.Int32"));
        tName.Columns.Add("Expr2", Type.GetType("System.Int32"));

    }

    internal static void CreateCatJoinTableStructure(DataTable tName)
    {

        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("FoodID", Type.GetType("System.Int32"));
        tName.Columns.Add("CategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("CategoryAbrev", Type.GetType("System.String"));
        tName.Columns.Add("NumberFree", Type.GetType("System.Int32"));
        tName.Columns.Add("FreeFlag", Type.GetType("System.String"));
        tName.Columns.Add("GroupFlag", Type.GetType("System.String"));
        tName.Columns.Add("GTCFlag", Type.GetType("System.String"));
        tName.Columns.Add("ReqFlag", Type.GetType("System.String"));
        tName.Columns.Add("CategoryID1", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionID", Type.GetType("System.Int32"));
        tName.Columns.Add("Priority", Type.GetType("System.Int16"));
        tName.Columns.Add("HalfSplit", Type.GetType("System.Boolean"));
        tName.Columns.Add("ButtonColor", Type.GetType("System.Int32"));
        tName.Columns.Add("ButtonForeColor", Type.GetType("System.Int32"));
        tName.Columns.Add("Extended", Type.GetType("System.Boolean"));
        tName.Columns.Add("FunctionID1", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionGroupID", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionFlag", Type.GetType("System.String"));

    }

    internal static void CreateLiquorTypesTableStructure(DataTable tName)
    {

        tName.Columns.Add("DrinkCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkCategoryName", Type.GetType("System.String"));
        tName.Columns.Add("DrinkCategoryOrder", Type.GetType("System.Int32"));

    }

    internal static void CreateDrinkModifiersTableStructure(DataTable tName)
    {

        tName.Columns.Add("DrinkModifierID", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkID", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkName", Type.GetType("System.String"));
        tName.Columns.Add("DrinkPrice", Type.GetType("System.Decimal"));
        tName.Columns.Add("TaxID", Type.GetType("System.Int32"));

    }

    internal static void CreateDrinkPrepTableStructure(DataTable tName)
    {

        tName.Columns.Add("DrinkPrepID", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkPrepMethod", Type.GetType("System.String"));
        tName.Columns.Add("DrinkPrepPrice", Type.GetType("System.Decimal"));
        tName.Columns.Add("Active", Type.GetType("System.Boolean"));
        tName.Columns.Add("DrinkPrepOrder", Type.GetType("System.Int32"));
        tName.Columns.Add("InvMultiplier", Type.GetType("System.Decimal"));
        tName.Columns.Add("DrinkPrepName", Type.GetType("System.String"));

    }


    internal static void CreateTableStatusDescriptionTableStructure(DataTable tName)
    {

        tName.Columns.Add("TableStatusID", Type.GetType("System.Int32"));
        tName.Columns.Add("TableStatusDesc", Type.GetType("System.String"));

    }

    internal static void CreateTaxTableStructure(DataTable tName)
    {

        tName.Columns.Add("TaxID", Type.GetType("System.Int32"));
        tName.Columns.Add("TaxName", Type.GetType("System.String"));
        tName.Columns.Add("TaxPercent", Type.GetType("System.Decimal"));

    }

    internal static void CreateMenuChoiceTableStructure(DataTable tName)
    {

        tName.Columns.Add("MenuID", Type.GetType("System.Int32"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("MenuName", Type.GetType("System.String"));
        tName.Columns.Add("Active", Type.GetType("System.Boolean"));
        tName.Columns.Add("LastOrder", Type.GetType("System.Int32"));
        tName.Columns.Add("AutoChange", Type.GetType("System.DateTime"));

    }

    internal static void CreateShiftCodesTableStructure(DataTable tName)
    {

        tName.Columns.Add("ShiftID", Type.GetType("System.Int32"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("ShiftName", Type.GetType("System.String"));
        tName.Columns.Add("TimeStart", Type.GetType("System.DateTime"));

    }
    internal static void CreateRoutingChoiceTableStructure(DataTable tName)
    {

        tName.Columns.Add("RoutingID", Type.GetType("System.Int32"));
        tName.Columns.Add("RoutingName", Type.GetType("System.String"));
        tName.Columns.Add("isExpediterPrinter", Type.GetType("System.Boolean"));

    }

    internal static void CreateCreditCardDetailTableStructure(DataTable tName)
    {

        tName.Columns.Add("PaymentTypeID", Type.GetType("System.Int32"));
        tName.Columns.Add("PaymentTypeName", Type.GetType("System.String"));

    }

    internal static void CreateTabIdentifierTableStructure(DataTable tName)
    {

        tName.Columns.Add("TabIdentifierID", Type.GetType("System.Int32"));
        tName.Columns.Add("TabSelectorIdentity", Type.GetType("System.String"));
        tName.Columns.Add("TabSelectorOrder", Type.GetType("System.Int16"));

    }

    internal static void CreateReasonsVoidTableStructure(DataTable tName)
    {

        tName.Columns.Add("VoidID", Type.GetType("System.Int32"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("VoidReason", Type.GetType("System.String"));
        tName.Columns.Add("VoidDescription", Type.GetType("System.String"));
        tName.Columns.Add("DisplayOrder", Type.GetType("System.Int16"));
        tName.Columns.Add("TypeDiscount", Type.GetType("System.String"));

    }


    internal static void CreateDrinkSubCategoryTableStructure(DataTable tName)
    {

        tName.Columns.Add("DrinkCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkCategoryName", Type.GetType("System.String"));
        tName.Columns.Add("DrinkCategoryNumber", Type.GetType("System.Int32"));
        tName.Columns.Add("ButtonColor", Type.GetType("System.Int32"));
        tName.Columns.Add("ButtonForeColor", Type.GetType("System.Int32"));
        tName.Columns.Add("IsALiquorType", Type.GetType("System.Boolean"));
        tName.Columns.Add("MenuID", Type.GetType("System.Int32"));
        tName.Columns.Add("OrderIndex", Type.GetType("System.Int32"));

    }

    internal static void CreateDrinkTableStructure(DataTable tName)
    {


        tName.Columns.Add("DrinkID", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkIndex", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkName", Type.GetType("System.String"));
        tName.Columns.Add("DrinkCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkPrice", Type.GetType("System.Decimal"));
        tName.Columns.Add("DrinkFunctionID", Type.GetType("System.Int32"));
        tName.Columns.Add("TaxID", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkDesc", Type.GetType("System.String"));
        tName.Columns.Add("DrinkAddOnChoice", Type.GetType("System.Boolean"));
        tName.Columns.Add("IsDrinkAdd", Type.GetType("System.Boolean"));
        tName.Columns.Add("IsWineParring", Type.GetType("System.Boolean"));
        tName.Columns.Add("LiquorTypeID", Type.GetType("System.Int32"));
        tName.Columns.Add("CallPrice", Type.GetType("System.Decimal"));
        tName.Columns.Add("AddOnPrice", Type.GetType("System.Decimal"));
        tName.Columns.Add("Active", Type.GetType("System.Boolean"));
        tName.Columns.Add("InvMultiplier", Type.GetType("System.Decimal"));
        tName.Columns.Add("FunctionGroupID", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionFlag", Type.GetType("System.String"));
        tName.Columns.Add("TaxID1", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkRoutingID", Type.GetType("System.Int32"));

    }

    internal static void CreateDrinkAddsTableStructure(DataTable tName)
    {

        tName.Columns.Add("DrinkID", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkName", Type.GetType("System.String"));
        tName.Columns.Add("DrinkCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkFunctionID", Type.GetType("System.Int32"));
        tName.Columns.Add("AddOnPrice", Type.GetType("System.Decimal"));
        tName.Columns.Add("TaxID", Type.GetType("System.Int32"));
        tName.Columns.Add("InvMultiplier", Type.GetType("System.Decimal"));
        tName.Columns.Add("FunctionGroupID", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionFlag", Type.GetType("System.String"));
        tName.Columns.Add("TaxID1", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkRoutingID", Type.GetType("System.Int32"));

    }

    internal static void CreatePromotionTableStructure(DataTable tName)
    {

        tName.Columns.Add("PromoID", Type.GetType("System.Int32"));
        tName.Columns.Add("PromoName", Type.GetType("System.String"));
        tName.Columns.Add("BSGS", Type.GetType("System.Boolean"));
        tName.Columns.Add("Combo", Type.GetType("System.Boolean"));
        tName.Columns.Add("Coupon", Type.GetType("System.Boolean"));
        tName.Columns.Add("MaxAmount", Type.GetType("System.Decimal"));
        tName.Columns.Add("MaxCheck", Type.GetType("System.Int32"));
        tName.Columns.Add("MaxTable", Type.GetType("System.Int32"));
        tName.Columns.Add("TaxPromoAmount", Type.GetType("System.Boolean"));
        tName.Columns.Add("TaxFoodCost", Type.GetType("System.Boolean"));
        tName.Columns.Add("EstFoodCost", Type.GetType("System.Decimal"));
        tName.Columns.Add("GuestPayTax", Type.GetType("System.Boolean"));
        tName.Columns.Add("ManagerLevel", Type.GetType("System.Int32"));
        tName.Columns.Add("TipPromo", Type.GetType("System.Boolean"));
        tName.PrimaryKey = new DataColumn[] { tName.Columns("PromoID") };

    }

    internal static void CreateBSGSTableStructure(DataTable tName)
    {

        tName.Columns.Add("PromoID", Type.GetType("System.Int32"));
        tName.Columns.Add("BuyFD_flag", Type.GetType("System.String"));
        tName.Columns.Add("BuyCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("BuyCategoryAmount", Type.GetType("System.Int32"));
        tName.Columns.Add("BuyDrinkCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("GetFD_flag", Type.GetType("System.String"));
        tName.Columns.Add("GetCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("GetCategoryAmount", Type.GetType("System.Int32"));
        tName.Columns.Add("GetQuantityDiscount", Type.GetType("System.Decimal"));
        tName.Columns.Add("GetDrinkCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("BSGS", Type.GetType("System.Boolean"));

    }

    internal static void CreateComboTableStructure(DataTable tName)
    {

        tName.Columns.Add("PromoID", Type.GetType("System.Int32"));
        tName.Columns.Add("ComboFD_flag", Type.GetType("System.String"));
        tName.Columns.Add("ComboCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("ComboCategoryMax", Type.GetType("System.Int32"));
        tName.Columns.Add("ComboDrinkCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("ComboDrinkCategoryMax", Type.GetType("System.Int32"));
        tName.Columns.Add("Combo", Type.GetType("System.Boolean"));

    }

    internal static void CreateComboDetailTableStructure(DataTable tName)
    {

        tName.Columns.Add("PromoID", Type.GetType("System.Int32"));
        tName.Columns.Add("ComboPrice", Type.GetType("System.Decimal"));
        tName.Columns.Add("Combo", Type.GetType("System.Boolean"));

    }

    internal static void CreateCouponTableStructure(DataTable tName)
    {

        tName.Columns.Add("PromoID", Type.GetType("System.Int32"));
        tName.Columns.Add("DiscountFD_flag", Type.GetType("System.String"));
        tName.Columns.Add("DiscountCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("DiscountCategoryAmount", Type.GetType("System.Int32"));
        tName.Columns.Add("DiscountDrinkCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("AtleastFD_flag", Type.GetType("System.String"));
        tName.Columns.Add("AtleastCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("AtleastCategoryAmount", Type.GetType("System.Int32"));
        tName.Columns.Add("AtleastDrinkCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("CouponDollarFlag", Type.GetType("System.Boolean"));
        tName.Columns.Add("CouponDollarAmount", Type.GetType("System.Decimal"));
        tName.Columns.Add("CouponPercentFlag", Type.GetType("System.Boolean"));
        tName.Columns.Add("CouponPercentAmount", Type.GetType("System.Decimal"));
        tName.Columns.Add("Coupon", Type.GetType("System.Boolean"));

    }

    internal static void CreateIngredientsTableStructure(DataTable tName)
    {

        tName.Columns.Add("FoodID", Type.GetType("System.Int32"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("RawItemID", Type.GetType("System.Int32"));
        tName.Columns.Add("RawUsageAmount", Type.GetType("System.Decimal"));
        tName.Columns.Add("RawUsageIndex", Type.GetType("System.Int16"));
        tName.Columns.Add("RawCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("RawItemName", Type.GetType("System.String"));
        tName.Columns.Add("PurchaseUnits", Type.GetType("System.String"));
        tName.Columns.Add("PurchaseCost", Type.GetType("System.Decimal"));
        tName.Columns.Add("RecipeUnit", Type.GetType("System.String"));
        tName.Columns.Add("RecipeConversion", Type.GetType("System.Int16"));
        tName.Columns.Add("UnitCost", Type.GetType("System.Decimal"));
        tName.Columns.Add("SelectNo", Type.GetType("System.Boolean"));
        tName.Columns.Add("NoPrice", Type.GetType("System.Decimal"));
        tName.Columns.Add("SelectExtra", Type.GetType("System.Boolean"));
        tName.Columns.Add("ExtraPrice", Type.GetType("System.Decimal"));
        tName.Columns.Add("PhysicalUnit", Type.GetType("System.String"));
        tName.Columns.Add("PhysicalConversion", Type.GetType("System.Int16"));
        tName.Columns.Add("PhysicalUnitCost", Type.GetType("System.Decimal"));
        tName.Columns.Add("InvDate", Type.GetType("System.DateTime"));
        tName.Columns.Add("InvQuantity", Type.GetType("System.Decimal"));
        tName.Columns.Add("InvDollarAmount", Type.GetType("System.Decimal"));
        tName.Columns.Add("CalculatedBegInvWeek", Type.GetType("System.Decimal"));
        tName.Columns.Add("RecipeQuantity", Type.GetType("System.Decimal"));
        tName.Columns.Add("TrackInvLevels", Type.GetType("System.Boolean"));
        tName.Columns.Add("PrintInReport", Type.GetType("System.Boolean"));
        tName.Columns.Add("TrackAs", Type.GetType("System.Int32"));
        tName.Columns.Add("Warning", Type.GetType("System.Boolean"));
        tName.Columns.Add("WarningLevel", Type.GetType("System.Int16"));
        tName.Columns.Add("TempRecipeQuantity", Type.GetType("System.Int16"));
        tName.Columns.Add("Expr1", Type.GetType("System.Int32"));
        tName.Columns.Add("RawUsageID", Type.GetType("System.Int32"));

    }


    internal static void CreateRawCategoryTableStructure(DataTable tName)
    {

        tName.Columns.Add("RawCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("RawCategoryName", Type.GetType("System.String"));
        tName.Columns.Add("RawSubCategory", Type.GetType("System.Int32"));

    }

    internal static void CreateRawMatTableStructure(DataTable tName)
    {

        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("RawCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("RawItemName", Type.GetType("System.String"));
        tName.Columns.Add("PurchaseUnits", Type.GetType("System.String"));
        tName.Columns.Add("PurchaseCost", Type.GetType("System.decimal"));
        tName.Columns.Add("Blank", Type.GetType("System.String"));
        tName.Columns.Add("RecipeUnit", Type.GetType("System.String"));
        tName.Columns.Add("RecipeConversion", Type.GetType("System.Int16"));
        tName.Columns.Add("UnitCost", Type.GetType("System.Decimal"));
        tName.Columns.Add("SelectNo", Type.GetType("System.Boolean"));
        tName.Columns.Add("NoPrice", Type.GetType("System.Decimal"));
        tName.Columns.Add("SelectExtra", Type.GetType("System.Boolean"));
        tName.Columns.Add("ExtraPrice", Type.GetType("System.Decimal"));
        tName.Columns.Add("Blank", Type.GetType("System.String"));
        tName.Columns.Add("PhysicalUnit", Type.GetType("System.String"));
        tName.Columns.Add("PhysicalConversion", Type.GetType("System.Int16"));
        tName.Columns.Add("PhysicalUnitCost", Type.GetType("System.Decimal"));
        tName.Columns.Add("InvDate", Type.GetType("System.DateTime"));
        tName.Columns.Add("InvQuantity", Type.GetType("System.Decimal"));
        tName.Columns.Add("InvDollarAmount", Type.GetType("System.Decimal"));
        tName.Columns.Add("CalculatedBegInvWeek", Type.GetType("System.decimal"));
        tName.Columns.Add("RecipeQuantity", Type.GetType("System.Decimal"));
        tName.Columns.Add("TrackInvLevels", Type.GetType("System.Boolean"));
        tName.Columns.Add("PrintInReport", Type.GetType("System.Boolean"));
        tName.Columns.Add("Warning", Type.GetType("System.Boolean"));
        tName.Columns.Add("WarningLevel", Type.GetType("System.Int16"));
        tName.Columns.Add("TempRecipeQuantity", Type.GetType("System.Int16"));
        tName.Columns.Add("Qty", Type.GetType("System.Decimal"));

    }


    internal static void CreateRawDeliveryTableStructure(DataTable tName)
    {

        tName.Columns.Add("InvFoodDeliveryID", Type.GetType("System.Int64"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("DailyCode", Type.GetType("System.Int64"));
        tName.Columns.Add("ReceivedDate", Type.GetType("System.DateTime"));
        tName.Columns.Add("EmployeeID", Type.GetType("System.Int32"));
        tName.Columns.Add("RawItemID", Type.GetType("System.Int32"));
        tName.Columns.Add("DeliveredQuantity", Type.GetType("System.decimal"));
        tName.Columns.Add("InvCounted", Type.GetType("System.Boolean")); // it is Boolean here and Int16 in DailyBusiness
        tName.Columns.Add("DeliveryFlag", Type.GetType("System.String"));
        tName.Columns.Add("StoredAt", Type.GetType("System.String"));
        tName.Columns.Add("RawItemName", Type.GetType("System.String"));
        tName.Columns.Add("PurchaseUnits", Type.GetType("System.String"));
        tName.Columns.Add("Blank", Type.GetType("System.String"));


    }







    internal static void CreateTerminalsMethodTableStructure(DataTable tName)
    {

        tName.Columns.Add("TerminalsPrimaryKey", Type.GetType("System.Int32"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("TerminalID", Type.GetType("System.Int32"));
        tName.Columns.Add("TerminalName", Type.GetType("System.String"));
        tName.Columns.Add("TerminalMethod", Type.GetType("System.String"));
        tName.Columns.Add("TerminalsGroupID", Type.GetType("System.Int32"));
        tName.Columns.Add("FloorPlanID", Type.GetType("System.Int32"));
        tName.Columns.Add("TermX", Type.GetType("System.Int16"));
        tName.Columns.Add("TermY", Type.GetType("System.Int16"));
        tName.Columns.Add("ReceiptPrinterID", Type.GetType("System.Int32"));
        tName.Columns.Add("OpenDefaultSceen", Type.GetType("System.Boolean"));
        tName.Columns.Add("hasCashDrawer", Type.GetType("System.Boolean"));
        tName.Columns.Add("normalOpenAmount", Type.GetType("System.Decimal"));
        tName.Columns.Add("autoOpenDrawer", Type.GetType("System.Boolean"));
        tName.Columns.Add("RoutingName", Type.GetType("System.String"));
        tName.Columns.Add("PhysicalAddress", Type.GetType("System.String"));

    }

    internal static void CreateTerminalsUseOrderTableStructure(DataTable tName)
    {

        tName.Columns.Add("TerminalsMethodKey", Type.GetType("System.Int32"));
        tName.Columns.Add("TerminalsPrimaryKey", Type.GetType("System.Int32"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("MethodUse", Type.GetType("System.String"));
        tName.Columns.Add("MethodDirection", Type.GetType("System.String"));
        tName.Columns.Add("UsePriority", Type.GetType("System.Int32"));
        tName.Columns.Add("Active", Type.GetType("System.Boolean"));

    }

    internal static void CreateTermsFloorTableStructure(DataTable tName)
    {

        tName.Columns.Add("FloorPlanID", Type.GetType("System.Int32"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("FloorPlanName", Type.GetType("System.String"));
        tName.Columns.Add("FloorPlanOrder", Type.GetType("System.Int16"));
        tName.Columns.Add("FloorPlanVisible", Type.GetType("System.Boolean"));
        tName.Columns.Add("FloorPlanActive", Type.GetType("System.Boolean"));
        tName.Columns.Add("meWidth", Type.GetType("System.Int16"));
        tName.Columns.Add("meHeight", Type.GetType("System.Int16"));

    }


    internal static void CreateTermsTablesTableStructure(DataTable tName)
    {

        tName.Columns.Add("TableOverviewID", Type.GetType("System.Int32"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("TableNumber", Type.GetType("System.Int32"));
        tName.Columns.Add("FloorPlanID", Type.GetType("System.Int32"));
        tName.Columns.Add("TableSectionID", Type.GetType("System.Int32"));
        tName.Columns.Add("Seats", Type.GetType("System.Int32"));
        tName.Columns.Add("Available", Type.GetType("System.Boolean"));
        tName.Columns.Add("isTable", Type.GetType("System.Boolean"));
        tName.Columns.Add("isWall", Type.GetType("System.Boolean"));
        tName.Columns.Add("isOther", Type.GetType("System.Boolean"));
        tName.Columns.Add("isRound", Type.GetType("System.Boolean"));
        tName.Columns.Add("xLoc", Type.GetType("System.Int16"));
        tName.Columns.Add("yLoc", Type.GetType("System.Int16"));
        tName.Columns.Add("myWidth", Type.GetType("System.Int16"));
        tName.Columns.Add("myHeight", Type.GetType("System.Int16"));
        // 444     tName.Columns.Add("Active", Type.GetType("System.Boolean"))
        tName.Columns.Add("FloorPlanName", Type.GetType("System.String"));
        tName.Columns.Add("OpenBigInt1", Type.GetType("System.Int64"));


    }

    internal static void CreateTermsWallsTableStructure(DataTable tName)
    {

        tName.Columns.Add("TableOverviewID", Type.GetType("System.Int32"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("TableNumber", Type.GetType("System.Int32"));
        tName.Columns.Add("FloorPlanID", Type.GetType("System.Int32"));
        tName.Columns.Add("isTable", Type.GetType("System.Boolean"));
        tName.Columns.Add("isWall", Type.GetType("System.Boolean"));
        tName.Columns.Add("isOther", Type.GetType("System.Boolean"));
        tName.Columns.Add("isRound", Type.GetType("System.Boolean"));
        tName.Columns.Add("xLoc", Type.GetType("System.Int16"));
        tName.Columns.Add("yLoc", Type.GetType("System.Int16"));
        tName.Columns.Add("myWidth", Type.GetType("System.Int16"));
        tName.Columns.Add("myHeight", Type.GetType("System.Int16"));
        tName.Columns.Add("Active", Type.GetType("System.Boolean"));

    }

    internal static void CreateMainCatTableStructure(DataTable tName)
    {

        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("CategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("CategoryName", Type.GetType("System.String"));
        tName.Columns.Add("CategoryAbrev", Type.GetType("System.String"));
        tName.Columns.Add("FunctionID", Type.GetType("System.Int32"));
        tName.Columns.Add("ButtonColor", Type.GetType("System.Int32"));
        tName.Columns.Add("ButtonForeColor", Type.GetType("System.Int32"));
        tName.Columns.Add("Extended", Type.GetType("System.Boolean"));
        tName.Columns.Add("MenuID", Type.GetType("System.Int32"));
        tName.Columns.Add("OrderIndex", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionGroupID", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionFlag", Type.GetType("System.String"));

    }

    internal static void CreateMainDrinkCatTableStructure(DataTable tName)
    {

        tName.Columns.Add("DrinkCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("DrinkCategoryNumber", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkCategoryName", Type.GetType("System.String"));
        tName.Columns.Add("ButtonColor", Type.GetType("System.Int32"));
        tName.Columns.Add("ButtonForeColor", Type.GetType("System.Int32"));
        tName.Columns.Add("IsALiquorType", Type.GetType("System.Boolean"));
        tName.Columns.Add("MenuID", Type.GetType("System.Int32"));
        tName.Columns.Add("OrderIndex", Type.GetType("System.Int32"));

    }


    internal static void CreateIndJoinTableStructure(DataTable tName)
    {

        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("FoodID", Type.GetType("System.Int32"));
        tName.Columns.Add("ModifierID", Type.GetType("System.Int32"));
        tName.Columns.Add("NumberFree", Type.GetType("System.Int32"));
        tName.Columns.Add("FreeFlag", Type.GetType("System.String"));
        tName.Columns.Add("GroupFlag", Type.GetType("System.String"));
        // tName.Columns.Add("FoodID1", Type.GetType("System.Int32"))
        tName.Columns.Add("CategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("FoodName", Type.GetType("System.String"));
        tName.Columns.Add("AbrevFoodName", Type.GetType("System.String"));
        tName.Columns.Add("ChitFoodName", Type.GetType("System.String"));
        tName.Columns.Add("Surcharge", Type.GetType("System.Decimal"));
        tName.Columns.Add("TaxID", Type.GetType("System.Int32"));
        tName.Columns.Add("FoodDesc", Type.GetType("System.String"));
        tName.Columns.Add("MenuIndex", Type.GetType("System.Int32"));
        tName.Columns.Add("InvMultiplier", Type.GetType("System.Decimal"));
        tName.Columns.Add("FunctionID", Type.GetType("System.Int32"));
        tName.Columns.Add("Priority", Type.GetType("System.Int16"));
        tName.Columns.Add("HalfSplit", Type.GetType("System.Boolean"));
        tName.Columns.Add("ButtonColor", Type.GetType("System.Int32"));
        tName.Columns.Add("ButtonForeColor", Type.GetType("System.Int32"));
        tName.Columns.Add("Extended", Type.GetType("System.Boolean"));
        tName.Columns.Add("FunctionGroupID", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionFlag", Type.GetType("System.String"));

    }


    internal static void CreateBarCatTableStructure(DataTable tName)
    {

        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("CategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("CategoryName", Type.GetType("System.String"));
        tName.Columns.Add("CategoryAbrev", Type.GetType("System.String"));
        tName.Columns.Add("FunctionID", Type.GetType("System.Int32"));
        tName.Columns.Add("ButtonColor", Type.GetType("System.Int32"));
        tName.Columns.Add("ButtonForeColor", Type.GetType("System.Int32"));
        tName.Columns.Add("Extended", Type.GetType("System.Boolean"));
        tName.Columns.Add("BartenderMenuID", Type.GetType("System.Int32"));
        tName.Columns.Add("OrderIndex", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionGroupID", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionFlag", Type.GetType("System.String"));
        tName.Columns.Add("TaxID", Type.GetType("System.Int32"));

    }

    internal static void CreateBarDrinkCatTableStructure(DataTable tName)
    {

        tName.Columns.Add("DrinkCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("DrinkCategoryNumber", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkCategoryName", Type.GetType("System.String"));
        tName.Columns.Add("ButtonColor", Type.GetType("System.Int32"));
        tName.Columns.Add("ButtonForeColor", Type.GetType("System.Int32"));
        tName.Columns.Add("IsALiquorType", Type.GetType("System.Boolean"));
        tName.Columns.Add("BartenderMenuID", Type.GetType("System.Int32"));
        tName.Columns.Add("OrderIndex", Type.GetType("System.Int32"));

    }


    internal static void CreateMainTableStructure(string tName)
    {

        ds.Tables.Add(tName);

        ds.Tables(tName).Columns.Add("FoodID", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("FoodName", Type.GetType("System.String"));
        ds.Tables(tName).Columns.Add("AbrevFoodName", Type.GetType("System.String"));
        ds.Tables(tName).Columns.Add("ChitFoodName", Type.GetType("System.String"));
        ds.Tables(tName).Columns.Add("CategoryID", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("FoodCost", Type.GetType("System.Decimal"));
        ds.Tables(tName).Columns.Add("TaxExempt", Type.GetType("System.Boolean"));
        ds.Tables(tName).Columns.Add("FoodDesc", Type.GetType("System.String"));
        ds.Tables(tName).Columns.Add("WineParringID", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("PrintPriorityID", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("PrepareTime", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("InvMultiplier", Type.GetType("System.Decimal"));
        ds.Tables(tName).Columns.Add("FoodID1", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("MenuID", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("Price", Type.GetType("System.Decimal"));
        ds.Tables(tName).Columns.Add("RoutingID", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("Surcharge", Type.GetType("System.Decimal"));
        ds.Tables(tName).Columns.Add("MenuIndex", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("FunctionID", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("HalfSplit", Type.GetType("System.Boolean"));
        ds.Tables(tName).Columns.Add("ButtonColor", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("ButtonForeColor", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("Extended", Type.GetType("System.Boolean"));
        ds.Tables(tName).Columns.Add("FunctionID1", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("FunctionFlag", Type.GetType("System.String"));
        ds.Tables(tName).Columns.Add("TaxID", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("FunctionGroupID", Type.GetType("System.Int32"));

    }

    internal static void CreateDrinkMainTableStructure(string tName)
    {

        ds.Tables.Add(tName);

        ds.Tables(tName).Columns.Add("DrinkID", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("DrinkName", Type.GetType("System.String"));
        ds.Tables(tName).Columns.Add("DrinkCategoryID", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("DrinkCategoryNumber", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("ButtonColor", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("ButtonForeColor", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("DrinkID1", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("MenuID", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("Price", Type.GetType("System.Decimal"));
        ds.Tables(tName).Columns.Add("RoutingID", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("Surcharge", Type.GetType("System.Decimal"));
        ds.Tables(tName).Columns.Add("MenuIndex", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("FunctionID", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("FunctionFlag", Type.GetType("System.String"));
        ds.Tables(tName).Columns.Add("TaxID", Type.GetType("System.Int32"));
        ds.Tables(tName).Columns.Add("FunctionGroupID", Type.GetType("System.Int32"));

    }

    internal static void CreateQuickCatTableStructure(DataTable tName)
    {

        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("CategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("CategoryName", Type.GetType("System.String"));
        tName.Columns.Add("CategoryAbrev", Type.GetType("System.String"));
        tName.Columns.Add("FunctionID", Type.GetType("System.Int32"));
        tName.Columns.Add("ButtonColor", Type.GetType("System.Int32"));
        tName.Columns.Add("ButtonForeColor", Type.GetType("System.Int32"));
        tName.Columns.Add("Extended", Type.GetType("System.Boolean"));
        tName.Columns.Add("BarenderMenuID", Type.GetType("System.Int32"));
        tName.Columns.Add("OrderIndex", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionGroupID", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionFlag", Type.GetType("System.String"));
        tName.Columns.Add("TaxID", Type.GetType("System.Int32"));        // not sure why TAXID?

    }

    internal static void CreateQuickDrinkCatTableStructure(DataTable tName)
    {

        tName.Columns.Add("DrinkCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("DrinkCategoryNumber", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkCategoryName", Type.GetType("System.String"));
        tName.Columns.Add("ButtonColor", Type.GetType("System.Int32"));
        tName.Columns.Add("ButtonForeColor", Type.GetType("System.Int32"));
        tName.Columns.Add("IsALiquorType", Type.GetType("System.Boolean"));
        tName.Columns.Add("BartenderMenuID", Type.GetType("System.Int32"));
        tName.Columns.Add("OrderIndex", Type.GetType("System.Int32"));

    }

    internal static void CreateLoggedInEmployeeTableStructure(DataTable tName)
    {

        tName.Columns.Add("LoginTrackingID", Type.GetType("System.Int64"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("EmployeeID", Type.GetType("System.Int32"));
        tName.Columns.Add("JobCode", Type.GetType("System.Int32"));
        tName.Columns.Add("LogInTime", Type.GetType("System.DateTime"));
        tName.Columns.Add("LogOutTime", Type.GetType("System.DateTime"));
        tName.Columns.Add("TerminalsGroupID", Type.GetType("System.Int32"));
        tName.Columns.Add("RegPayRate", Type.GetType("System.Decimal"));
        tName.Columns.Add("OTPayRate", Type.GetType("System.Decimal"));
        tName.Columns.Add("TipableSales", Type.GetType("System.Decimal"));
        tName.Columns.Add("DeclaredTips", Type.GetType("System.Decimal"));
        tName.Columns.Add("ChargedSales", Type.GetType("System.Decimal"));
        tName.Columns.Add("ChargedTips", Type.GetType("System.Decimal"));
        tName.Columns.Add("OverrideLogin", Type.GetType("System.Int32"));
        tName.Columns.Add("OverrideLogout", Type.GetType("System.Int32"));
        tName.Columns.Add("OverrideRegPay", Type.GetType("System.Int32"));
        tName.Columns.Add("OverrideOTPay", Type.GetType("System.Int32"));
        tName.Columns.Add("OverrideDeclaredTips", Type.GetType("System.Int32"));
        tName.Columns.Add("Terminal", Type.GetType("System.Int32"));
        tName.Columns.Add("dbUP", Type.GetType("System.Int32"));
        tName.Columns.Add("LastName", Type.GetType("System.String"));
        tName.Columns.Add("FirstName", Type.GetType("System.String"));
        tName.Columns.Add("MiddleName", Type.GetType("System.String"));
        tName.Columns.Add("NickName", Type.GetType("System.String"));
        tName.Columns.Add("ClockInReq", Type.GetType("System.Boolean"));

    }


    internal static void CreateJobCodeInfoTableStructure(DataTable tName)
    {

        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("JobCodeID", Type.GetType("System.Int32"));
        tName.Columns.Add("JobCodeName", Type.GetType("System.String"));
        tName.Columns.Add("Manager", Type.GetType("System.Boolean"));
        tName.Columns.Add("Cashier", Type.GetType("System.Boolean"));
        tName.Columns.Add("Bartender", Type.GetType("System.Boolean"));
        tName.Columns.Add("Server", Type.GetType("System.Boolean"));
        tName.Columns.Add("Hostess", Type.GetType("System.Boolean"));
        tName.Columns.Add("PasswordReq", Type.GetType("System.Boolean"));
        tName.Columns.Add("ClockInReq", Type.GetType("System.Boolean"));
        tName.Columns.Add("ReportTipsReq", Type.GetType("System.Boolean"));
        tName.Columns.Add("ShareTipsReq", Type.GetType("System.Boolean"));
        // openInt1 never pulled in front end

    }


    internal static void CreateClockOutSalesTableStructure(DataTable tName)
    {

        tName.Columns.Add("FunctionGroupSales", Type.GetType("System.Decimal"));
        tName.Columns.Add("FunctionName", Type.GetType("System.String"));
    }

    internal static void CreateAllEmployeesTableStructure(DataTable tName)
    {

        tName.Columns.Add("EmployeeID", Type.GetType("System.Int32"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("EmployeeNumber", Type.GetType("System.Int32"));
        tName.Columns.Add("LastName", Type.GetType("System.String"));
        tName.Columns.Add("FirstName", Type.GetType("System.String"));
        tName.Columns.Add("NickName", Type.GetType("System.String"));
        tName.Columns.Add("Passcode", Type.GetType("System.String"));
        tName.Columns.Add("SwipeCode", Type.GetType("System.String"));
        tName.Columns.Add("Training", Type.GetType("System.Boolean"));
        tName.Columns.Add("Terminated", Type.GetType("System.Boolean"));
        tName.Columns.Add("ClockInReq", Type.GetType("System.Boolean"));
        tName.Columns.Add("ReportMgmtAll", Type.GetType("System.Boolean"));
        tName.Columns.Add("ReportMgmtLimited", Type.GetType("System.Boolean"));
        tName.Columns.Add("OperationMgmtAll", Type.GetType("System.Boolean"));
        tName.Columns.Add("OperationMgmtLimited", Type.GetType("System.Boolean"));
        tName.Columns.Add("SystemMgmtAll", Type.GetType("System.Boolean"));
        tName.Columns.Add("SystemMgmtLimited", Type.GetType("System.Boolean"));
        tName.Columns.Add("EmployeeMgmtAll", Type.GetType("System.Boolean"));
        tName.Columns.Add("EmployeeMgmtLimited", Type.GetType("System.Boolean"));

        tName.Columns.Add("JobCodeID1", Type.GetType("System.Int32"));
        tName.Columns.Add("JobRate1", Type.GetType("System.Decimal"));
        tName.Columns.Add("JobCodeID2", Type.GetType("System.Int32"));
        tName.Columns.Add("JobRate2", Type.GetType("System.Decimal"));
        tName.Columns.Add("JobCodeID3", Type.GetType("System.Int32"));
        tName.Columns.Add("JobRate3", Type.GetType("System.Decimal"));
        tName.Columns.Add("JobCodeID4", Type.GetType("System.Int32"));
        tName.Columns.Add("JobRate4", Type.GetType("System.Decimal"));
        tName.Columns.Add("JobCodeID5", Type.GetType("System.Int32"));
        tName.Columns.Add("JobRate5", Type.GetType("System.Decimal"));
        tName.Columns.Add("JobCodeID6", Type.GetType("System.Int32"));
        tName.Columns.Add("JobRate6", Type.GetType("System.Decimal"));
        tName.Columns.Add("JobCodeID7", Type.GetType("System.Int32"));
        tName.Columns.Add("JobRate7", Type.GetType("System.Decimal"));
        tName.Columns.Add("Lefty", Type.GetType("System.Boolean"));

        tName.Columns.Add("JobName1", Type.GetType("System.String"));
        tName.Columns.Add("JobName2", Type.GetType("System.String"));
        tName.Columns.Add("JobName3", Type.GetType("System.String"));
        tName.Columns.Add("JobName4", Type.GetType("System.String"));
        tName.Columns.Add("JobName5", Type.GetType("System.String"));
        tName.Columns.Add("JobName6", Type.GetType("System.String"));
        tName.Columns.Add("JobName7", Type.GetType("System.String"));

    }

    internal static void CreateOpenOrdersTableStructure(DataTable tName)
    {

        tName.Columns.Add("OpenOrderID", Type.GetType("System.Int64"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("DailyCode", Type.GetType("System.Int64"));
        tName.Columns.Add("ExperienceNumber", Type.GetType("System.Int64"));
        tName.Columns.Add("OrderNumber", Type.GetType("System.Int64"));
        tName.Columns.Add("ShiftID", Type.GetType("System.Int32"));
        tName.Columns.Add("MenuID", Type.GetType("System.Int32"));
        tName.Columns.Add("EmployeeID", Type.GetType("System.Int32"));
        tName.Columns.Add("CheckNumber", Type.GetType("System.Int32"));
        tName.Columns.Add("CustomerNumber", Type.GetType("System.Int32"));
        tName.Columns.Add("CourseNumber", Type.GetType("System.Int32"));
        tName.Columns.Add("sin", Type.GetType("System.Int32"));
        tName.Columns.Add("sii", Type.GetType("System.Int32"));
        tName.Columns.Add("si2", Type.GetType("System.Int32"));
        tName.Columns.Add("Quantity", Type.GetType("System.Int32"));
        tName.Columns.Add("ItemID", Type.GetType("System.Int32"));
        tName.Columns.Add("ItemName", Type.GetType("System.String"));
        tName.Columns.Add("TerminalName", Type.GetType("System.String"));
        tName.Columns.Add("ChitName", Type.GetType("System.String"));
        tName.Columns.Add("ItemPrice", Type.GetType("System.Decimal"));
        tName.Columns.Add("Price", Type.GetType("System.Decimal"));
        tName.Columns.Add("TaxPrice", Type.GetType("System.Decimal"));
        tName.Columns.Add("SinTax", Type.GetType("System.Decimal"));
        tName.Columns.Add("TaxID", Type.GetType("System.Int32"));
        tName.Columns.Add("ForceFreeID", Type.GetType("System.Int64"));
        tName.Columns.Add("ForceFreeAuth", Type.GetType("System.Int32"));
        tName.Columns.Add("ForceFreeCode", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionID", Type.GetType("System.Int32"));
        tName.Columns.Add("CategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("FoodID", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkID", Type.GetType("System.Int32"));
        tName.Columns.Add("ItemStatus", Type.GetType("System.Int32"));
        tName.Columns.Add("RoutingID", Type.GetType("System.Int32"));
        tName.Columns.Add("PrintPriorityID", Type.GetType("System.Int32"));
        tName.Columns.Add("Repeat", Type.GetType("System.Boolean"));
        tName.Columns.Add("TerminalID", Type.GetType("System.Int32"));
        tName.Columns.Add("dbUP", Type.GetType("System.Int32"));
        tName.Columns.Add("OpenDecimal1", Type.GetType("System.Int64"));
        tName.Columns.Add("FunctionGroupID", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionFlag", Type.GetType("System.String"));

    }


    internal static void CreatePaymentsAndCreditsTableStructure(DataTable tName)
    {

        tName.Columns.Add("PaymentsAndCreditsID", Type.GetType("System.Int64"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("DailyCode", Type.GetType("System.Int64"));
        tName.Columns.Add("ExperienceNumber", Type.GetType("System.Int64"));
        tName.Columns.Add("PaymentDate", Type.GetType("System.DateTime"));
        tName.Columns.Add("EmployeeID", Type.GetType("System.Int32"));
        tName.Columns.Add("CheckNumber", Type.GetType("System.Int32"));
        tName.Columns.Add("PaymentTypeID", Type.GetType("System.Int32"));
        tName.Columns.Add("AccountNumber", Type.GetType("System.String"));
        tName.Columns.Add("CCExpiration", Type.GetType("System.String"));
        tName.Columns.Add("CVV", Type.GetType("System.String"));
        tName.Columns.Add("Track2", Type.GetType("System.String"));
        tName.Columns.Add("CustomerName", Type.GetType("System.String"));
        tName.Columns.Add("TransactionType", Type.GetType("System.String"));
        tName.Columns.Add("TransactionCode", Type.GetType("System.String"));
        tName.Columns.Add("SwipeType", Type.GetType("System.Int32"));
        tName.Columns.Add("PaymentAmount", Type.GetType("System.Decimal"));
        tName.Columns.Add("Surcharge", Type.GetType("System.Decimal"));
        tName.Columns.Add("Tip", Type.GetType("System.Decimal"));
        tName.Columns.Add("PreAuthAmount", Type.GetType("System.Decimal"));
        tName.Columns.Add("Applied", Type.GetType("System.Boolean"));
        tName.Columns.Add("RefNum", Type.GetType("System.String"));
        tName.Columns.Add("AuthCode", Type.GetType("System.String"));
        tName.Columns.Add("AcqRefData", Type.GetType("System.String"));
        tName.Columns.Add("BatchCleared", Type.GetType("System.Boolean"));
        tName.Columns.Add("Duplicate", Type.GetType("System.Boolean"));
        tName.Columns.Add("TerminalID", Type.GetType("System.Int32"));
        tName.Columns.Add("TerminalsOpenID", Type.GetType("System.Int64"));
        tName.Columns.Add("AlreadyPrinted", Type.GetType("System.Boolean"));
        tName.Columns.Add("Description", Type.GetType("System.String"));
        tName.Columns.Add("dbUP", Type.GetType("System.Int32"));
        tName.Columns.Add("LastName", Type.GetType("System.String"));
        tName.Columns.Add("FirstName", Type.GetType("System.String"));
        tName.Columns.Add("PaymentTypeName", Type.GetType("System.String"));
        tName.Columns.Add("PaymentFlag", Type.GetType("System.String"));
        tName.Columns.Add("OpenBigInt1", Type.GetType("System.Int64"));

    }

    internal static void CreateAvailTablesAndTabsTableStructure(DataTable tName)
    {

        tName.Columns.Add("ExperienceNumber", Type.GetType("System.Int64"));
        tName.Columns.Add("DailyCode", Type.GetType("System.Int64"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("ExperienceDate", Type.GetType("System.DateTime"));
        tName.Columns.Add("LoginTrackingID", Type.GetType("System.Int64"));
        tName.Columns.Add("TableNumber", Type.GetType("System.Int32"));
        tName.Columns.Add("TabID", Type.GetType("System.Int64"));
        tName.Columns.Add("TabName", Type.GetType("System.String"));
        tName.Columns.Add("TicketNumber", Type.GetType("System.Int32"));
        tName.Columns.Add("EmployeeID", Type.GetType("System.Int32"));
        tName.Columns.Add("NumberOfCustomers", Type.GetType("System.Int32"));
        tName.Columns.Add("NumberOfChecks", Type.GetType("System.Int32"));
        tName.Columns.Add("ShiftID", Type.GetType("System.Int32"));
        tName.Columns.Add("MenuID", Type.GetType("System.Int32"));
        tName.Columns.Add("CheckDown", Type.GetType("System.DateTime"));
        tName.Columns.Add("FoodOrdered", Type.GetType("System.DateTime"));
        tName.Columns.Add("AvailForSeating", Type.GetType("System.DateTime"));
        tName.Columns.Add("LastStatus", Type.GetType("System.Int32"));
        tName.Columns.Add("LastStatusTime", Type.GetType("System.DateTime"));
        tName.Columns.Add("ItemsOnHold", Type.GetType("System.Int16"));
        tName.Columns.Add("LastView", Type.GetType("System.String"));
        tName.Columns.Add("ClosedSubTotal", Type.GetType("System.Decimal"));
        tName.Columns.Add("TerminalID", Type.GetType("System.Int32"));
        tName.Columns.Add("AutoGratuity", Type.GetType("System.Decimal"));
        tName.Columns.Add("MethodUse", Type.GetType("System.String"));
        tName.Columns.Add("Delivery", Type.GetType("System.String"));
        tName.Columns.Add("TabIndicator", Type.GetType("System.String"));
        tName.Columns.Add("Reference", Type.GetType("System.String"));
        if (object.ReferenceEquals(tName, dtCurrentlyHeld))
        {
            tName.Columns.Add("CurrentlyHeld", Type.GetType("System.String"));
        }
        tName.Columns.Add("dbUP", Type.GetType("System.Int32"));

    }

    internal static void CreateAllTablesTableStructure(DataTable tName)
    {

        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("TableOverviewID", Type.GetType("System.Int32"));
        tName.Columns.Add("TableNumber", Type.GetType("System.Int32"));
        tName.Columns.Add("MaxExpNumByTable", Type.GetType("System.Int64"));
        tName.Columns.Add("SatTime", Type.GetType("System.DateTime"));
        tName.Columns.Add("EmployeeID", Type.GetType("System.Int32"));
        tName.Columns.Add("DailyCode", Type.GetType("System.Int64"));
        tName.Columns.Add("TableStatusID", Type.GetType("System.Int32"));
        tName.Columns.Add("LastStatusTime", Type.GetType("System.DateTime"));
        tName.Columns.Add("ItemsOnHold", Type.GetType("System.Int16"));
        tName.Columns.Add("FloorPlanID", Type.GetType("System.Int32"));
        tName.Columns.Add("TableSectionID", Type.GetType("System.Int32"));
        tName.Columns.Add("Seats", Type.GetType("System.Int32"));
        tName.Columns.Add("Available", Type.GetType("System.Boolean"));
        // tName.Columns.Add("Active", Type.GetType("System.Boolean"))

    }

    internal static void CreateOpenBusinessTableStructure(DataTable tName)
    {

        tName.Columns.Add("DailyCode", Type.GetType("System.Int64"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("StartTime", Type.GetType("System.DateTime"));
        tName.Columns.Add("EndTime", Type.GetType("System.DateTime"));
        tName.Columns.Add("EmployeeOpened", Type.GetType("System.Int32"));
        tName.Columns.Add("EmployeeClosed", Type.GetType("System.Int32"));
        tName.Columns.Add("PrimaryMenu", Type.GetType("System.Int32"));
        tName.Columns.Add("SecondaryMenu", Type.GetType("System.Int32"));
        tName.Columns.Add("ShiftID", Type.GetType("System.Int32"));
        tName.Columns.Add("InvCounted", Type.GetType("System.Int16"));


    }

    internal static void CreateFunctionsTableStructure(DataTable tName)
    {

        tName.Columns.Add("FunctionID", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionGroupID", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionName", Type.GetType("System.String"));
        tName.Columns.Add("FunctionFlag", Type.GetType("System.String"));
        tName.Columns.Add("TaxID", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkRoutingID", Type.GetType("System.Int32"));

    }

    internal static void CreatePaymentTypeTableStructure(DataTable tName)
    {

        tName.Columns.Add("PaymentTypeID", Type.GetType("System.Int32"));
        tName.Columns.Add("PaymentTypeName", Type.GetType("System.String"));
        tName.Columns.Add("PaymentFlag", Type.GetType("System.String"));

    }

    internal static void CreateOrderDetailTableStructure(DataTable tName)
    {

        tName.Columns.Add("OrderNumber", Type.GetType("System.Int64"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("DailyCode", Type.GetType("System.Int64"));
        tName.Columns.Add("ExperienceNumber", Type.GetType("System.Int64"));
        tName.Columns.Add("OrderTime", Type.GetType("System.DateTime"));
        tName.Columns.Add("OrderReady", Type.GetType("System.DateTime"));
        tName.Columns.Add("OrderFilled", Type.GetType("System.DateTime"));
        tName.Columns.Add("NumberOfDinners", Type.GetType("System.Int16"));
        tName.Columns.Add("NumberOfApps", Type.GetType("System.Int16"));
        tName.Columns.Add("NumberOfDrinks", Type.GetType("System.Int16"));
        tName.Columns.Add("isMainCourse", Type.GetType("System.Boolean"));
        tName.Columns.Add("TotalDollar", Type.GetType("System.Decimal"));
        tName.Columns.Add("AvgDollar", Type.GetType("System.Decimal"));
        tName.Columns.Add("ExperienceDate", Type.GetType("System.DateTime"));

    }

    internal static void CreateTermsOpenTableStructure(DataTable tName)
    {

        tName.Columns.Add("TerminalsOpenID", Type.GetType("System.Int64"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("DailyCode", Type.GetType("System.Int64"));
        tName.Columns.Add("TerminalsPrimaryKey", Type.GetType("System.Int32"));
        tName.Columns.Add("OpenBy", Type.GetType("System.Int16"));
        tName.Columns.Add("OpenTime", Type.GetType("System.DateTime"));
        tName.Columns.Add("OpenCash", Type.GetType("System.Decimal"));
        tName.Columns.Add("CloseBy", Type.GetType("System.Int16"));
        tName.Columns.Add("CloseTime", Type.GetType("System.DateTime"));
        tName.Columns.Add("CloseCash", Type.GetType("System.Decimal"));
        tName.Columns.Add("CashIn", Type.GetType("System.Decimal"));
        tName.Columns.Add("CashOut", Type.GetType("System.Decimal"));
        tName.Columns.Add("OverShort", Type.GetType("System.Decimal"));
        tName.Columns.Add("ReasonShort", Type.GetType("System.String"));
        tName.Columns.Add("LastName", Type.GetType("System.String"));
        tName.Columns.Add("FirstName", Type.GetType("System.String"));

    }

    internal static void CreateTabDirectorySearchTableStructure(DataTable tName)
    {

        tName.Columns.Add("TabID", Type.GetType("System.Int64"));
        tName.Columns.Add("CompanyID", Type.GetType("System.String"));
        tName.Columns.Add("LocationID", Type.GetType("System.String"));
        tName.Columns.Add("AccountNumber", Type.GetType("System.String"));
        tName.Columns.Add("AccountPhone", Type.GetType("System.String"));
        tName.Columns.Add("LastName", Type.GetType("System.String"));
        tName.Columns.Add("FirstName", Type.GetType("System.String"));
        tName.Columns.Add("MiddleName", Type.GetType("System.String"));
        tName.Columns.Add("NickName", Type.GetType("System.String"));
        tName.Columns.Add("Address1", Type.GetType("System.String"));
        tName.Columns.Add("Address2", Type.GetType("System.String"));
        tName.Columns.Add("City", Type.GetType("System.String"));
        tName.Columns.Add("State", Type.GetType("System.String"));
        tName.Columns.Add("PostalCode", Type.GetType("System.String"));
        tName.Columns.Add("Country", Type.GetType("System.String"));
        tName.Columns.Add("Phone1", Type.GetType("System.String"));
        tName.Columns.Add("Ext1", Type.GetType("System.String"));
        tName.Columns.Add("Phone2", Type.GetType("System.String"));
        tName.Columns.Add("Ext2", Type.GetType("System.String"));
        tName.Columns.Add("DeliveryZone", Type.GetType("System.Int32"));
        tName.Columns.Add("CrossRoads", Type.GetType("System.String"));
        tName.Columns.Add("SpecialInstructions", Type.GetType("System.String"));
        tName.Columns.Add("DoNotDeliver", Type.GetType("System.Boolean"));
        tName.Columns.Add("VIP", Type.GetType("System.Boolean"));
        tName.Columns.Add("UpdatedDate", Type.GetType("System.DateTime"));
        tName.Columns.Add("UpdatedByEmployee", Type.GetType("System.Int32"));
        tName.Columns.Add("Active", Type.GetType("System.Boolean"));
        tName.Columns.Add("OpenChar1", Type.GetType("System.String"));

    }

    internal static void CreateTabPreviousOrdersTableStructure(DataTable tName)
    {

        tName.Columns.Add("ExperienceNumber", Type.GetType("System.Int64"));
        tName.Columns.Add("ExperienceDate", Type.GetType("System.DateTime"));
        tName.Columns.Add("TabID", Type.GetType("System.Int64"));
        tName.Columns.Add("ClosedSubTotal", Type.GetType("System.Decimal"));
        tName.Columns.Add("NumberOfDinners", Type.GetType("System.Int32"));
        tName.Columns.Add("NumberOfApps", Type.GetType("System.Int32"));
        tName.Columns.Add("TotalDollar", Type.GetType("System.Decimal"));

    }

    internal static void CreateTabPreviousOrdersByItemTableStructure(DataTable tName)
    {

        tName.Columns.Add("ExperienceNumber", Type.GetType("System.Int64"));
        tName.Columns.Add("MenuID", Type.GetType("System.Int32"));
        tName.Columns.Add("CustomerNumber", Type.GetType("System.Int32"));
        tName.Columns.Add("CourseNumber", Type.GetType("System.Int32"));
        tName.Columns.Add("sin", Type.GetType("System.Int32"));
        tName.Columns.Add("sii", Type.GetType("System.Int32"));
        tName.Columns.Add("si2", Type.GetType("System.Int32"));
        tName.Columns.Add("Quantity", Type.GetType("System.Int32"));
        tName.Columns.Add("ItemID", Type.GetType("System.Int32"));
        tName.Columns.Add("ItemName", Type.GetType("System.String"));
        tName.Columns.Add("TerminalName", Type.GetType("System.String"));
        tName.Columns.Add("ChitName", Type.GetType("System.String"));
        tName.Columns.Add("ItemPrice", Type.GetType("System.Decimal"));
        tName.Columns.Add("Price", Type.GetType("System.Decimal"));
        tName.Columns.Add("TaxPrice", Type.GetType("System.Decimal"));
        // tName.Columns.Add("SinTax", Type.GetType("System.Decimal"))
        // tName.Columns.Add("TaxID", Type.GetType("System.Int32"))
        tName.Columns.Add("FunctionID", Type.GetType("System.Int32"));
        tName.Columns.Add("CategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("FoodID", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkCategoryID", Type.GetType("System.Int32"));
        tName.Columns.Add("DrinkID", Type.GetType("System.Int32"));
        tName.Columns.Add("ItemStatus", Type.GetType("System.Int32"));
        tName.Columns.Add("RoutingID", Type.GetType("System.Int32"));
        tName.Columns.Add("PrintPriorityID", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionGroupID", Type.GetType("System.Int32"));
        tName.Columns.Add("FunctionFlag", Type.GetType("System.String"));

    }


    internal static object CreateTerminals()
    {

        DataRow oRow;
        int i;
        int shiftMin;

        i = 1;
        foreach (DataRow currentORow in ds.Tables("RoutingChoice").Rows)
        {
            oRow = currentORow;
            if (!(oRow("RoutingName") == "Do Not Route"))
            {
                printingRouting[i] = oRow("RoutingID");
                printingName[i] = oRow("RoutingName");
            }
            i += 1;
            if (i == 20)
                break;
        }

        if (!(typeProgram == "Online_Demo"))
        {
            currentTerminal = new Terminal();
        }

        foreach (DataRow currentORow1 in ds.Tables("TerminalsMethod").Rows)
        {
            oRow = currentORow1;

            if (string.Compare(oRow("TerminalName"), SystemInformation.ComputerName, true) == 0 | typeProgram == "Online_Demo" & oRow("TerminalName") == "eglobal" | System.Windows.Forms.SystemInformation.ComputerName == "EGLOBALMAIN" & !(companyInfo.companyName == "eGlobal Partners"))
            {
                // ****   TRUE means IGNORE CASE  ***
                // ******
                // the last half (the or part) makes my computer accout use their last terminal info
                // i need to ask which terminal (for multiple terminal restaurants)
                // ******

                {
                    var withBlock = currentTerminal;
                    withBlock.TermPrimaryKey = oRow("TerminalsPrimaryKey");
                    withBlock.TermID = oRow("TerminalID");
                    withBlock.TermName = oRow("TerminalName");
                    withBlock.TermMethod = oRow("TerminalMethod");
                    withBlock.TermGroupID = oRow("TerminalsGroupID");
                    withBlock.FloorPlanID = oRow("FloorPlanID");
                    withBlock.xLoc = oRow("TermX");
                    withBlock.yLoc = oRow("TermY");
                    withBlock.HasCashDrawer = oRow("hasCashDrawer");
                    withBlock.NormalOpenAmount = oRow("normalOpenAmount");
                    withBlock.AutoOpenDrawer = oRow("autoOpenDrawer");
                    if (System.Windows.Forms.SystemInformation.ComputerName == "EGLOBALMAIN")
                    {
                        withBlock.ReceiptName = "Receipt2";
                    }
                    // .ReceiptName = "HP DeskJet 722C on Phoenix"
                    else if (!object.ReferenceEquals(oRow("ReceiptPrinterID"), DBNull.Value))
                    {
                        if (oRow("ReceiptPrinterID") != 0)
                        {
                            withBlock.ReceiptName = oRow("RoutingName");
                        }
                    }
                    if (!object.ReferenceEquals(oRow("PhysicalAddress"), DBNull.Value))
                    {
                        withBlock.PhyAdd = oRow("PhysicalAddress");
                    }
                    else
                    {
                        withBlock.PhyAdd = "0000";
                    }

                    // shift codes
                    if (ds.Tables("ShiftCodes").Rows.Count > 0)
                    {
                        foreach (DataRow sRow in ds.Tables("ShiftCodes").Rows)
                        {
                            if (DateAndTime.TimeOfDay.Hour > sRow("TimeStart").hour)
                            {
                                withBlock.CurrentShift = sRow("ShiftID");
                                break;
                            }
                            else if (sRow("TimeStart").hour == DateAndTime.TimeOfDay.Hour)
                            {
                                if (DateAndTime.TimeOfDay.Minute > sRow("TimeStart").minute)
                                {
                                    withBlock.CurrentShift = sRow("ShiftID");
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        withBlock.CurrentShift = 0;
                    }

                    // these are kept in Experience Table (different for each order)
                    // .TermUseName = oRow("UseName")
                    // .TermUsePriority = oRow("UsePriority")
                }
                break;

            }
        }

        if (currentTerminal.TermGroupID > 0)
        {
            Terminal groupTerminal;
            foreach (DataRow currentORow2 in ds.Tables("TerminalsMethod").Rows)
            {
                oRow = currentORow2;
                if (oRow("TerminalsGroupID") == currentTerminal.TermGroupID)
                {
                    groupTerminal = new Terminal();
                    groupTerminal.TermPrimaryKey = oRow("TerminalsPrimaryKey");
                    groupTerminal.TermID = oRow("TerminalID");
                    groupTerminal.TermName = oRow("TerminalName");
                    groupTerminal.TermMethod = oRow("TerminalMethod");
                    groupTerminal.TermGroupID = oRow("TerminalsGroupID");
                    groupTerminals.Add(groupTerminal);
                }
            }
        }

        dvTerminalsUseOrder = new DataView();
        {
            ref var withBlock1 = ref dvTerminalsUseOrder;
            withBlock1.Table = ds.Tables("TerminalsUseOrder");
            withBlock1.RowFilter = "TerminalsPrimaryKey = '" + currentTerminal.TermPrimaryKey + "' and Active = 1";
            withBlock1.Sort = "UsePriority ASC";   // already sorted in table 
        }

        return default;

    }




    internal static object OpenNewTab(long tabId, string tabName) // , ByVal isDineIn As Boolean, ByRef tabAccountInfo As DataSet_Builder.Payment)
    {
        // there is another OpenNewTab in Table_Screen_Bar ?????

        long expNum;
        int tktNum;
        bool isCurrentlyHeld;
        DateTime satTm;

        if (tabId == -888 | currentTerminal.TermMethod == "Quick")
        {
            tktNum = Conversions.ToInteger(CreateNewTicketNumber());
            if (tabName == "New Tab")
            {
                tabName = "Tkt# " + tktNum.ToString();
            }
        }
        else
        {
            // 444      If tabName = "New Tab" Then
            // somehow this is making program change Method Use to TakeOut
            // tktNum = CreateNewTicketNumber()
            // tabName = "Tkt# " & tktNum.ToString
            // Else
            tktNum = 0;
            // End If
        }

        expNum = Conversions.ToLong(CreateNewExperience(currentServer.EmployeeID, default, tabId, tabName, 1, 2, tktNum, 0, currentServer.LoginTrackingID));
        if (expNum > 0L)
        {
            isCurrentlyHeld = PopulateThisExperience(expNum, false);

            currentTable = new DinnerTable();
            currentTable.ExperienceNumber = expNum;
            currentTable.IsTabNotTable = true;
            currentTable.TabID = tabId;
            currentTable.TabName = tabName;
            currentTable.TableNumber = 0;
            currentTable.TicketNumber = tktNum;
            currentTable.EmployeeID = currentServer.EmployeeID;
            currentTable.CurrentMenu = currentTerminal.currentPrimaryMenuID; // 444primaryMenuID  'this is the system menu - can change during order process
            currentTable.StartingMenu = currentTerminal.currentPrimaryMenuID; // 444primaryMenuID
            currentTable.NumberOfCustomers = 1;      // is 1 when you first open
            currentTable.NumberOfChecks = 1;
            currentTable.LastStatus = 2;
            currentTable.SatTime = DateTime.Now;
            currentTable.ItemsOnHold = 0;
            if (tabId == -888) // maybe or -999 ???
            {
                currentTable.MethodUse = "Dine In";
            }
            else if (tabId == -990)
            {
                currentTable.MethodUse = "Take Out";
            }
            else if (tabId == -991)
            {
                currentTable.MethodUse = "Pickup";
            }
            else if (tabId == -777)
            {
                currentTable.MethodUse = "Return";
            }
            else
            {
                currentTable.MethodUse = DetermineInitialMethod(ref tktNum);
            }
            // currentTable.MethodUse = SeatingTab.MethedUse
            // 444    tabAccountInfo.experienceNumber = currentTable.ExperienceNumber

            StartOrderProcess(currentTable.ExperienceNumber);
            return true;
        }
        else
        {
            return false;
        } // this means something failed

    }


    internal static object CreateNewExperience(int EmployeeID, int TableSelected, long tabID, string tabName, int numCust, int status, int ntn, short hold, long loginTrackID)
    {
        DataRow tableRow = dsOrder.Tables("AvailTables").NewRow;
        DataRow tabRow = dsOrder.Tables("AvailTabs").NewRow;
        DataRow quickRow = dsOrder.Tables("QuickTickets").NewRow;
        // Dim termTableRow As DataRow = dsBackup.Tables("AvailTablesTerminal").NewRow
        // Dim termTabRow As DataRow = dsBackup.Tables("AvailTabsTerminal").NewRow
        int newTicketNumber;

        if (currentTerminal.TermMethod == "Quick" | tabID == -888)
        {
            newTicketNumber = ntn;
            PerformNewExperienceAdd(ref quickRow, default, EmployeeID, TableSelected, tabID, tabName, numCust, status, newTicketNumber, hold, loginTrackID);
            if (typeProgram == "Online_Demo")
            {
                quickRow("ExperienceNumber") = demoExpNumID;
                demoExpNumID += 1;
            }

            dsOrder.Tables("QuickTickets").Rows.Add(quickRow);
            try
            {
                if (typeProgram == "Online_Demo")
                {
                    return quickRow("ExperienceNumber");
                    return default;
                }
                sql.cn.Open();
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                if (currentTerminal.TermMethod == "Quick")
                {
                    sql.SqlQuickTicketSP.Update(dsOrder, "QuickTickets");
                }
                else
                {
                    sql.SqlQuickTicketsBar.Update(dsOrder, "QuickTickets");
                }
                sql.cn.Close();
                if (TableSelected != default | TableSelected > 0)
                {
                    // is a table
                    sql.cn.Open();
                    sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                    PlaceNewExpNumInAABTablesOverview(TableSelected, quickRow("ExperienceNumber"));
                    // really should be AllTables but not auto making Update COmmand in SQLHelper
                    sql.SqlDataAdapterAllTables.Update(dsOrder.Tables("AllTables"));
                    // 777   sql.SqlTermsTables.Update(ds.Tables("TermsTables"))
                    sql.cn.Close();
                }
                currentTerminal.NumOpenTickets += 1;
            }
            catch (Exception ex)
            {
                CloseConnection();
                Interaction.MsgBox(ex.Message);
            }

            return quickRow("ExperienceNumber");
        }
        else
        {
            newTicketNumber = ntn;                                   // (ntn is zero if isDineIn = true)

            if (TableSelected == default | TableSelected == 0)      // is a tab
            {
                PerformNewExperienceAdd(ref tabRow, default, EmployeeID, TableSelected, tabID, tabName, numCust, status, newTicketNumber, hold, loginTrackID);
                if (typeProgram == "Online_Demo")
                {
                    tabRow("ExperienceNumber") = demoExpNumID;
                    demoExpNumID += 1;
                }

                dsOrder.Tables("AvailTabs").Rows.Add(tabRow);
                try
                {
                    if (typeProgram == "Online_Demo")
                    {
                        return tabRow("ExperienceNumber");
                        return default;
                    }
                    sql.cn.Open();
                    sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                    sql.SqlAvailTabsSP.Update(dsOrder, "AvailTabs");
                    sql.cn.Close();
                }
                catch (Exception ex)
                {
                    CloseConnection();
                    Interaction.MsgBox(ex.Message);
                }
                return tabRow("ExperienceNumber");
            }



            else    // If tabID = Nothing Or tabID = 0 Then     'is a table
            {
                PerformNewExperienceAdd(ref tableRow, default, EmployeeID, TableSelected, tabID, tabName, numCust, status, newTicketNumber, hold, loginTrackID);
                if (typeProgram == "Online_Demo")
                {
                    tableRow("ExperienceNumber") = demoExpNumID;
                    demoExpNumID += 1;
                }

                dsOrder.Tables("AvailTables").Rows.Add(tableRow);
                try
                {
                    if (typeProgram == "Online_Demo")
                    {
                        return tableRow("ExperienceNumber");
                        return default;
                    }
                    sql.cn.Open();
                    sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                    sql.SqlAvailTablesSP.Update(dsOrder, "AvailTables");
                    // dsOrder.Tables("AvailTables").AcceptChanges()


                    PlaceNewExpNumInAABTablesOverview(TableSelected, tableRow("ExperienceNumber"));
                    sql.SqlDataAdapterAllTables.Update(dsOrder.Tables("AllTables"));
                    // 777 sql.SqlTermsTables.Update(ds.Tables("TermsTables"))
                    sql.cn.Close();
                }

                // 
                // PlaceNewExpNumInAABTablesOverview(TableSelected, tableRow("ExperienceNumber"))
                // sql.cn.Open()
                // sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery()
                // ' old   sql.SqlDataAdapterAllTables.Update(dsOrder.Tables("AllTables"))
                // sql.SqlTermsTables.Update(ds.Tables("TermsTables"))
                // sql.cn.Close()

                catch (Exception ex)
                {
                    CloseConnection();
                    Interaction.MsgBox(ex.Message);
                }

                return tableRow("ExperienceNumber");
            }

            return default;

            // 222
            // *** below is copied above, but not changing TABID from -999
            if (TableSelected == default | TableSelected == 0)
            {
                // for now we are reinserting TabID
                // this is for new tabs
                if (tabID == -999)
                {
                    tabRow("TabID") = tabRow("ExperienceNumber");
                    // termTabRow("TabID") = termTabRow("ExperienceNumber")
                    ///    *         SaveAvailTabsAndTables()
                    if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
                    {
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
                            Interaction.MsgBox(ex.Message);
                        }
                    }
                    else if (currentTerminal.TermMethod == "Quick")
                    {
                        try
                        {
                            sql.cn.Open();
                            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                            sql.SqlQuickTicketSP.Update(dsOrder, "QuickTickets");
                            sql.cn.Close();
                        }
                        catch (Exception ex)
                        {
                            CloseConnection();
                            Interaction.MsgBox(ex.Message);
                        }
                    }

                }

                // *** not sure about the following two
                // we send term because it has a value no matter if server up or down
                // Return termTabRow("ExperienceNumber")
                return tabRow("ExperienceNumber");
            }
            else
            {
                // Return termTableRow("ExperienceNumber")
                return tableRow("ExperienceNumber");
            }

        }

    }

    internal static void PopulateBartenderCollection()
    {

        string strBartenders;
        bool firstTime = true;
        Terminal term;
        Employee barMan;
        Employee emp;
        SqlClient.SqlDataReader dtr;
        SqlClient.SqlCommand cmd;

        if (typeProgram == "Online_Demo")
        {
            loggedInBartenders = currentBartenders;
            return;
        }

        var lastBarID = default(int);
        currentBartenders.Clear();
        loggedInBartenders.Clear();

        ds.Tables("GroupBartenders").Clear();

        // sql.SqlSelectCommandClockedIn.Parameters("@CompanyID").Value = CompanyID
        sql.SqlSelectGroupBartenders.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlSelectGroupBartenders.Parameters("@DailyCode").Value = currentTerminal.CurrentDailyCode;
        sql.SqlSelectGroupBartenders.Parameters("@TerminalsGroup").Value = currentTerminal.TermGroupID;

        // this is pulling from view that has NULL Logout's
        // if fails we want to fail in Login_Entered
        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlGroupBartenders.Fill(ds.Tables("GroupBartenders"));
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
        }

        foreach (DataRow oRow in ds.Tables("GroupBartenders").Rows)
        {
            if (oRow("EmployeeID") == lastBarID)
            {
            }
            // saem bartender, we only care about first time pass
            else
            {
                lastBarID = oRow("EmployeeID");
                foreach (Employee currentEmp in AllEmployees)
                {
                    emp = currentEmp;
                    if (emp.EmployeeID == oRow("EmployeeID"))
                    {
                        barMan = new Employee();
                        barMan = emp;
                        barMan.Bartender = true;

                        currentBartenders.Add(barMan);
                        // all bartender for day, this term group
                        if (object.ReferenceEquals(oRow("LogOutTime"), DBNull.Value))
                        {
                            loggedInBartenders.Add(barMan);
                        }
                        break;
                    }
                }
            }
        }

        // 222
        return;

        strBartenders = "SELECT EmployeeID, NickName FROM ClockedInView WHERE LocationID = '" + companyInfo.LocationID + "' AND LogOutTime IS NULL AND Bartender = '1'";

        if (groupTerminals.Count > 0)
        {
            strBartenders = strBartenders + " AND TerminalsGroupID = '" + currentTerminal.TermGroupID + "'";
        }

        // For Each term In groupTerminals
        // If firstTime = True Then
        // strBartenders = strBartenders & " AND TerminalsGroupID = '" & term.TermGroupID & "'"
        // firstTime = False
        // Else
        // strBartenders = strBartenders & " OR TerminalGroupID = '" & term.TermGroupID & "'"
        // End If
        // Next
        else
        {
            // strBartenders = strBartenders & " Terminal = '" & term.TermID & "'"
        }

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            cmd = new SqlClient.SqlCommand(strBartenders, sql.cn);
            dtr = cmd.ExecuteReader;
            while (dtr.Read())
            {
                foreach (Employee currentEmp1 in AllEmployees)
                {
                    emp = currentEmp1;
                    if (emp.EmployeeID == dtr("EmployeeID"))
                    {
                        barMan = new Employee();
                        barMan = emp;
                        barMan.Bartender = true;
                        currentBartenders.Add(barMan);
                        // MsgBox(barMan.NickName)
                        // MsgBox(barMan.Bartender.ToString)
                    }
                }
            }
            dtr.Close();
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            if (dtr is not null)
            {
                if (dtr.IsClosed == false)
                {
                    dtr.Close();
                }
            }
            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }

        // salaried 
        foreach (Employee currentEmp2 in SalariedEmployees)
        {
            emp = currentEmp2;
            if (!(emp.EmployeeID == 6986))   // Or currentServer.EmployeeID = 6986 Then
            {
                currentBartenders.Add(emp);
            }
        }

    }

    internal static void PopulateServerCollection(ref EmployeeCollection activeCollection)
    {

        if (typeProgram == "Online_Demo")
        {
            Interaction.MsgBox("Transfer is not fully functional in Demo. Not all Personnel Categories can populate in Demo.", MsgBoxStyle.Information, "DEMO Purposes only");
            return;
        }

        string strCollection;
        Employee newMan;
        Employee emp;
        var dtr = default(SqlClient.SqlDataReader);
        SqlClient.SqlCommand cmd;

        activeCollection.Clear();

        strCollection = "SELECT EmployeeID FROM ClockedInView WHERE LocationID = '" + companyInfo.LocationID + "' AND LogOutTime IS NULL"; // AND Server = '1'"

        if (object.ReferenceEquals(activeCollection, currentServers))
        {
            strCollection = strCollection + " AND Server = '1'";
        }

        else if (object.ReferenceEquals(activeCollection, currentManagers))
        {
            strCollection = strCollection + " AND Manager = '1'";
        }
        else if (object.ReferenceEquals(activeCollection, currentBartenders))
        {
            strCollection = strCollection + " AND Bartender = '1'";
        }
        else if (object.ReferenceEquals(activeCollection, todaysFloorPersonnel))
        {
            strCollection = strCollection + " AND (Server = '1' OR Bartender = '1' OR Manager = '1' OR Cashier = '1')";
        }

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            cmd = new SqlClient.SqlCommand(strCollection, sql.cn);
            dtr = cmd.ExecuteReader;
            while (dtr.Read())
            {
                foreach (Employee currentEmp in AllEmployees)
                {
                    emp = currentEmp;
                    if (emp.EmployeeID == dtr("EmployeeID"))
                    {
                        newMan = new Employee();
                        newMan = emp;
                        // 444           newMan.Server = True
                        activeCollection.Add(newMan);
                    }
                }
            }
            dtr.Close();
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            if (dtr is not null)
            {
                if (dtr.IsClosed == false)
                {
                    dtr.Close();
                }
            }

            CloseConnection();
            return;

        }

        if (object.ReferenceEquals(activeCollection, currentManagers) | object.ReferenceEquals(activeCollection, todaysFloorPersonnel))
        {
            foreach (Employee currentEmp1 in SalariedEmployees)
            {
                emp = currentEmp1;
                if (!(emp.EmployeeID == 6986) | currentServer.EmployeeID == 6986)
                {
                    activeCollection.Add(emp);
                }
            }
        }

    }


    public static object PerformNewExperienceAdd(ref DataRow dr, long newexperiencenumber, int EmployeeID, int TableSelected, long tabID, string tabName, int numCust, int status, int newTicketNumber, short hold, long loginTrackID)
    {

        dr("CompanyID") = companyInfo.CompanyID;
        dr("LocationID") = companyInfo.LocationID;
        // dr("DailyCode") = DailyCode
        if (newexperiencenumber != default)
        {
            dr("ExperienceNumber") = newexperiencenumber;
        }
        dr("ExperienceDate") = DateTime.Now;
        dr("LoginTrackingID") = loginTrackID;
        dr("DailyCode") = currentTerminal.CurrentDailyCode;
        if (TableSelected == default | TableSelected == 0)      // is a tab
        {
            dr("TabID") = tabID;
            dr("TabName") = tabName;
        }
        else    // If tabID = Nothing Or tabID = 0 Then     'is a table
        {
            dr("TableNumber") = TableSelected;
            dr("TabID") = -22; // i have no idea WHY? 
            dr("TabName") = TableSelected.ToString();
            // PlaceNewExpNumInAABTablesOverview(TableSelected, newexperiencenumber)
        }
        dr("EmployeeID") = EmployeeID;
        dr("NumberOfCustomers") = numCust;
        dr("NumberOfChecks") = 1;
        dr("ShiftID") = currentTerminal.CurrentShift; // currentServer.ShiftID
        dr("MenuID") = currentTerminal.currentPrimaryMenuID; // 444primaryMenuID
        dr("LastStatus") = status;
        dr("LastStatusTime") = DateTime.Now;
        dr("ItemsOnHold") = hold;
        dr("LastView") = "Detail";
        dr("TerminalID") = currentTerminal.TermID;
        // If newTicketNumber = 0 Then
        // dr("TicketNumber") = 0
        dr("TicketNumber") = newTicketNumber;
        if (numCust >= companyInfo.autoGratuityNumber)
        {
            dr("AutoGratuity") = companyInfo.autoGratuityPercent;
        }
        else
        {
            dr("AutoGratuity") = -1;
        }

        if (tabID == -888)
        {
            dr("MethodUse") = "Dine In";
        }
        else if (tabID == -990)
        {
            dr("MethodUse") = "Take Out";
        }
        else if (tabID == -991)
        {
            dr("MethodUse") = "Pickup";
        }
        else if (tabID == -777)
        {
            dr("MethodUse") = "Return";
        }
        else
        {
            dr("MethodUse") = DetermineInitialMethod(ref newTicketNumber);
        }
        if (mainServerConnected == true)
        {
            dr("dbUP") = 1;
        }
        else
        {
            dr("dbUP") = 0;
        }

        return default;

    }

    internal static void PlaceNewExpNumInAABTablesOverview(int tn, long expNum)
    {

        try
        {
            // For Each oRow In ds.Tables("TermsTables").Rows
            foreach (DataRow oRow in dsOrder.Tables("AllTables").Rows)  // 777
            {
                if (oRow("TableNumber") == tn)
                {
                    oRow("OpenBigInt1") = expNum;
                    // don't think I need  Flag for new exp
                    break;
                }
            }
        }

        catch (Exception ex)
        {

        }
    }
    internal static object CreatingNewTicket()
    {

        long expNum;
        int tktNum;
        string tabNameString;

        // 444 in previous sub      qtRow += 1
        tktNum = Conversions.ToInteger(CreateNewTicketNumber());
        // in new experience TabID should stay the same (-888, -111, -222)
        if (currentTable.TabID == -888)
        {
            // tabNameString = "Tkt# " & tktNum.ToString
            tabNameString = currentServer.NickName + "'s Tabs";
        }
        else
        {
            currentTable.TabID = -999;
            tabNameString = "Tkt# " + tktNum.ToString();
        }

        // ResetsMethodUse()

        if (dvTerminalsUseOrder.Count > 0)
        {
            currentTable.MethodUse = GenerateOrderTables.dvTerminalsUseOrder(0)("MethodUse");
            currentTable.MethodDirection = GenerateOrderTables.dvTerminalsUseOrder(0)("MethodDirection");
        }
        else
        {
            currentTable.MethodUse = "Dine In";
            currentTable.MethodDirection = "None";
        }

        expNum = Conversions.ToLong(CreateNewExperience(currentServer.EmployeeID, default, currentTable.TabID, tabNameString, 1, 2, tktNum, 0, currentServer.LoginTrackingID));
        currentTerminal.NumOpenTickets += 1;
        currentTable.NumberOfCustomers = 1;
        currentTable.TicketNumber = tktNum;
        currentTable.TabName = "";

        return expNum;

    }

    internal static object CreateNewTicketNumber()
    {

        DataRow oRow;
        var newTicketNumber = default(int);
        int lastTicketNumber;

        if (typeProgram == "Online_Demo")
        {
            newTicketNumber = demoNewTicketID;
            demoNewTicketID += 1;
            return newTicketNumber;
            return default;
        }

        // Dim cmd = New SqlClient.SqlCommand("SELECT MAX(TicketNumber) currentTerminal.lastTicketNumber FROM ExperienceTable WHERE LocationID = '" & companyInfo.LocationID & "' AND DailyCode = '" & currentTerminal.CurrentDailyCode & "' AND TerminalID = '" & currentTerminal.TermID & "' AND (TicketNumber > 0)", sql.cn)
        var cmd = new SqlClient.SqlCommand("SELECT MAX(TicketNumber) lastTicketNumber FROM ExperienceTable WHERE LocationID = '" + companyInfo.LocationID + "' AND DailyCode = '" + currentTerminal.CurrentDailyCode + "' AND TerminalID = '" + currentTerminal.TermID + "' AND (TicketNumber > 0)", sql.cn);
        var dtr = default(SqlClient.SqlDataReader);
        // Dim expDate As DateTime
        // Dim expNumber As Int64
        // Dim tixNumber As Integer

        if (!(currentTerminal.LastTicketNumber == 0))
        {
            newTicketNumber = currentTerminal.LastTicketNumber + 1;
            if (newTicketNumber / 10000d == currentTerminal.TermID)
            {
                newTicketNumber = currentTerminal.TermID * 10000 + 1;
            }
            currentTerminal.LastTicketNumber = newTicketNumber;
        }
        else
        {

            // no longer     'we must find the MAX exp number first becuse ticket numbers revolve (start back at tkt#1)
            try
            {
                sql.cn.Open();
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                dtr = cmd.executereader;
                dtr.Read();

                if (!object.ReferenceEquals(dtr("lastTicketNumber"), DBNull.Value))
                {
                    newTicketNumber = dtr("lastTicketNumber") + 1;
                    if (newTicketNumber / 10000d == currentTerminal.TermID)
                    {
                        newTicketNumber = currentTerminal.TermID * 10000 + 1;
                    }
                }
                // expNumber = dtr("ExperienceNumber")
                else
                {
                    newTicketNumber = currentTerminal.TermID * 10000 + 1;
                    // dtr.Close()
                    // sql.cn.Close()
                    // Return newTicketNumber
                }
                currentTerminal.LastTicketNumber = newTicketNumber;

                dtr.Close();
                sql.cn.Close();
            }

            catch (Exception ex)
            {
                if (dtr is not null)
                {
                    if (dtr.IsClosed == false)
                    {
                        dtr.Close();
                    }
                }
                CloseConnection();
                Interaction.MsgBox(ex.Message);
            }
        }

        return newTicketNumber;

    }

    internal static object DetermineInitialMethod(ref int newTicketNumber)
    {

        var cm = default(string);

        if (newTicketNumber == -777)
        {
            cm = "Return";
            return cm;
        }

        if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
        {
            // Table Service
            // If currentTable.TicketNumber > 0 Then
            if (newTicketNumber > 0)
            {
                cm = "Take Out";
            }
            else
            {
                cm = "Dine In";
            }
        }

        else if (currentTerminal.TermMethod == "Quick")
        {

            if (dvTerminalsUseOrder.Count > 0)
            {
                cm = GenerateOrderTables.dvTerminalsUseOrder(0)("MethodUse"); // called MethodUse in Exp Table
            }
            else
            {
                cm = "Dine In";
            }
            // ElseIf currentTerminal.TermMethod = "Quick" Then
            // If dsOrder.Tables("TerminalsUseOrder").Rows.Count > 0 Then
            // cm = dsOrder.Tables("TerminalsUseOrder").Rows(0)("MethodUse") 'called MethodUse in Exp Table
            // Else
            // cm = "Dine In"
            // End If
        }

        return cm;

    }

    // for special and extra

    internal static object DetermineFunctionAndTaxInfo(ref SelectedItemDetail currentItem, int funGroup, bool fromSpecial)
    {

        foreach (DataRow functionRow in dsOrder.Tables("Functions").Rows)
        {
            if (fromSpecial == true)
            {
                if (functionRow("FunctionGroupID") == funGroup)
                {
                    currentItem.FunctionID = functionRow("FunctionID");
                    // .FunctionFlag = functionRow("FunctionFlag")
                    currentItem.TaxID = functionRow("TaxID");
                    // 444       If .FunctionFlag = "D" Or fromSpecial = True Then
                    if (!object.ReferenceEquals(functionRow("DrinkRoutingID"), DBNull.Value))
                    {
                        // DrinkRoutingID in function table is routing ID
                        currentItem.RoutingID = functionRow("DrinkRoutingID");
                        // 444    End If
                    }
                    break;

                }
            }
            else if (functionRow("FunctionGroupID") == funGroup)        // not from special
            {
                currentItem.FunctionID = functionRow("FunctionID");
                // .FunctionFlag = functionRow("FunctionFlag")
                // 444       If .FunctionFlag = "D" Or fromSpecial = True Then
                // If Not functionRow("DrinkRoutingID") Is DBNull.Value Then
                // .RoutingID = functionRow("DrinkRoutingID")
                // End If
                // End If
                currentItem.TaxID = functionRow("TaxID");
                break;
            }
        }

        return default;

    }

    internal static object DetermineTaxID(int aFunctionID)
    {
        DataRow functionRow;
        int aTaxID;

        if (aFunctionID > 0)
        {
            functionRow = dsOrder.Tables("Functions").Rows.Find(aFunctionID);
            aTaxID = functionRow("TaxID");
        }
        else
        {
            aTaxID = 0;
        }

        return aTaxID;

    }

    internal static object DetermineTaxPrice(int aTaxID, decimal aTaxPrice)
    {
        decimal calculatedTaxPrice;
        decimal roundedTaxPrice;
        DataRow taxRow;

        if (aTaxID == -1 | aTaxID == 0)
        {
            // taxExempt
            calculatedTaxPrice = 0m;
        }
        else
        {
            // Try
            // taxRow = (ds.Tables("Tax").Rows.Find(aTaxID))
            // calculatedTaxPrice = aTaxPrice * taxRow("TaxPercent") '(Format((aTaxPrice * taxRow("TaxPercent")), "#####0.00"))
            // Catch ex As Exception
            // calculatedTaxPrice = 0
            calculatedTaxPrice = aTaxPrice * companyInfo.salesTax;
            // End Try

        } // Format((aTaxPrice * companyInfo.salesTax), "#####0.00")

        return calculatedTaxPrice;

    }

    internal static object DetermineSinTax(int aTaxID, decimal aTaxPrice)
    {
        decimal calculatedTaxPrice;
        DataRow taxRow;

        if (aTaxID == -1 | aTaxID == 0)
        {
            // taxExempt
            calculatedTaxPrice = 0m;
        }
        else
        {
            taxRow = ds.Tables("Tax").Rows.Find(aTaxID);
            calculatedTaxPrice += aTaxPrice * taxRow("TaxPercent");
        } // (Format((aTaxPrice * taxRow("TaxPercent")), "#####0.00"))

        return calculatedTaxPrice;

    }

    internal static object DetermineTaxName(int aTaxID)
    {
        string aTaxName;
        DataRow taxRow;

        if (aTaxID == -1 | aTaxID == 0)
        {
            // taxExempt
            aTaxName = "Tax";
        }
        else
        {
            taxRow = ds.Tables("Tax").Rows.Find(aTaxID);
            aTaxName = taxRow("TaxName");
        }

        return aTaxName;

    }


    internal static object AddStatusChangeData222(int status, int orderNumber, bool isMainCourse, decimal avgDollar)
    {
        // we do not use this for orders
        // we have the exact same sub in term_OrderForm (b/c we must do at the same time as generate OrderNumber)
        SqlClient.SqlCommand cmd;

        cmd = new SqlClient.SqlCommand("INSERT INTO ExperienceStatusChange (CompanyID, LocationID, ExperienceNumber, StatusTime, TableStatusID, OrderNumber, IsMainCourse, AverageDollar, TerminalID, dbUP) VALUES (@CompanyID, @LocationID, @ExperienceNumber, @StatusTime, @TableStatusID, @OrderNumber, @IsMainCourse, @AverageDollar, @TerminalID, @dbUP)", sql.cn);

        cmd.Parameters.Add(new SqlClient.SqlParameter("@CompanyID", System.Data.SqlDbType.NChar, 6));
        cmd.Parameters("@CompanyID").Value = companyInfo.CompanyID;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@LocationID", System.Data.SqlDbType.NChar, 6));
        cmd.Parameters("@LocationID").Value = companyInfo.LocationID;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@ExperienceNumber", SqlDbType.BigInt, 8));
        cmd.Parameters("@ExperienceNumber").Value = currentTable.ExperienceNumber;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@StatusTime", SqlDbType.DateTime, 8));
        cmd.Parameters("@StatusTime").Value = DateTime.Now;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@TableStatusID", SqlDbType.Int, 4));
        cmd.Parameters("@TableStatusID").Value = status;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@OrderNumber", SqlDbType.Int, 4));
        cmd.Parameters("@OrderNumber").Value = orderNumber;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@IsMainCourse", SqlDbType.Bit, 1));
        cmd.Parameters("@IsMainCourse").Value = isMainCourse;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@AverageDollar", SqlDbType.Decimal, 5));
        cmd.Parameters("@AverageDollar").Value = avgDollar;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@TerminalID", SqlDbType.Int, 4));
        cmd.Parameters("@TerminalID").Value = currentTerminal.TermID;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@dbUP", SqlDbType.Bit, 1));
        cmd.Parameters("@dbUP").Value = 1;

        if (mainServerConnected == true)
        {
            try
            {
                sql.cn.Open();
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                sql.cn.Close();
            }
            catch (Exception ex)
            {
                CloseConnection();
                if (mainServerConnected == true)
                {
                    ServerJustWentDown();
                }
                // TerminalAddStatusChangeData(status, orderNumber, isMainCourse, avgDollar)
            }
        }
        else
        {
            // TerminalAddStatusChangeData(status, orderNumber, isMainCourse, avgDollar)
        }

        return default;


    }

    internal static object AddStatusChangeData222(long expNum, int status, int orderNumber, bool isMainCourse, decimal avgDollar)
    {
        DateTime statusTime;

        // effects the experienceStatusChange table
        DataRow oRow = dsOrder.Tables("StatusChange").NewRow;
        oRow("CompanyID") = companyInfo.CompanyID;
        oRow("LocationID") = companyInfo.LocationID;
        oRow("DailyCode") = currentTerminal.CurrentDailyCode;
        oRow("ExperienceNumber") = expNum;
        oRow("StatusTime") = DateTime.Now;
        oRow("TableStatusID") = status;
        oRow("OrderNumber") = orderNumber;
        oRow("IsMainCourse") = isMainCourse;
        oRow("AverageDollar") = avgDollar;
        oRow("TerminalID") = currentTerminal.TermPrimaryKey;
        oRow("dbUP") = 1;
        dsOrder.Tables("StatusChange").Rows.Add(oRow);
        return default;

        // TerminalAddStatusChangeData(status, orderNumber, isMainCourse, avgDollar)


    }

    // this only supply specifics about Job Code already selected
    public static void FillJobCodeInfo(ref Employee emp, int thisJobCode)
    {

        var tempDT = new DataTable();

        if (dsEmployee.Tables("JobCodeInfo").Rows.Count > 0)
        {
            tempDT = dsEmployee.Tables("JobCodeInfo");
        }
        else
        {
            tempDT = dsStarter.Tables("StarterJobCodeInfo");
        }

        foreach (DataRow oRow in tempDT.Rows) // dsEmployee.Tables("JobCodeInfo").Rows
        {
            if (oRow("JobCodeID") == thisJobCode)
            {
                emp.JobCodeName = oRow("JobCodeName");
                emp.Manager = oRow("Manager");
                emp.Cashier = oRow("Cashier");
                emp.Bartender = oRow("Bartender");
                emp.Server = oRow("Server");
                emp.Hostess = oRow("Hostess");
                emp.PasswordReq = oRow("PasswordReq");
                // 444       emp.ClockInReq = oRow("ClockInReq")
                emp.ReportTipsReq = oRow("ReportTipsReq");
                emp.ShareTipsReq = oRow("ShareTipsReq");
            }
        }

    }
    internal static void EnterEmployeeToLoginDataSet(Employee emp)
    {

        DataRow oRow = dsEmployee.Tables("LoggedInEmployees").NewRow;
        decimal otPay;

        if (emp.OTPayRate > emp.RegPayRate)
        {
            otPay = emp.OTPayRate;
        }
        else
        {
            otPay = emp.RegPayRate;
        }

        oRow("CompanyID") = companyInfo.CompanyID;
        oRow("LocationID") = companyInfo.LocationID;
        oRow("EmployeeID") = emp.EmployeeID;
        oRow("JobCode") = emp.JobCodeID;
        oRow("LogInTime") = emp.LogInTime;
        // oRow("LogOutTime") = emp.LogOutTime       '*** change allow for clock out
        oRow("TerminalsGroupID") = currentTerminal.TermGroupID;
        oRow("RegPayRate") = emp.RegPayRate;
        oRow("OTPayRate") = otPay;
        dsEmployee.Tables("LoggedInEmployees").Rows.Add(oRow);

        // sql.cn.Open()
        // sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery()
        // sql.SqlClockedInList.Update(dsEmployee.Tables("LoggedInEmployees"))
        // sql.cn.Close()

        dsEmployee.Tables("LoggedInEmployees").AcceptChanges();

    }

    internal static Employee TestUsernamePassword(string loginEnter, bool checkPassword)
    {

        if (loginEnter is null)
            return default;

        if (loginEnter.Length < 4)
        {
            Interaction.MsgBox("Username Incorrect: Please Reenter or See Manager");
            return default;
        }

        foreach (Employee emp in AllEmployees)
        {

            if (emp.EmployeeNumber == loginEnter.ToString().Substring(0, 4))
            {

                if (emp.PasswordReq == true | checkPassword == true)
                {
                    if (loginEnter.Length < 8)
                    {
                        Interaction.MsgBox("You MUST enter your password: Please Reenter or See Manager");
                        return default;
                    }
                    if (emp.PasscodeID == loginEnter.ToString().Substring(4, 4))
                    {
                        // LoginEmployee(emp)
                        return emp;
                    }
                    else
                    {
                        Interaction.MsgBox("Password Incorrect: Please Reenter or See Manager");
                        return default;
                    }
                }
                // LoginEmployee(emp)
                return emp;
            }
        }

        Interaction.MsgBox("Employee Number: " + loginEnter + " Is Not In System");
        return default;

    }

    internal static object TestClockOut(string loginEnter)
    {
        var emp = default(Employee);
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
            return false;
        }
        if (emp.ClockInReq == false)
        {
            // MsgBox(emp.FullName & " does not need to Clock In.")
            return false;
        }

        try
        {
            isClockedIn = Conversions.ToInteger(ActuallyLogIn(ref emp));
        }
        catch (Exception ex)
        {
            CloseConnection();
            return default;
        }

        if (isClockedIn == 0)
        {
            return false;
        }
        else if (isClockedIn == 1)
        {
            // MsgBox(emp.FullName & " is currently logged-in as " & emp.JobCodeName)
            return true;
        }
        else
        {
            // MsgBox("Employee Is Clocked in more than once. Please See Manager.")
            return true;
        }

    }


    internal static object TestLogin222(ref Employee emp)
    {

        dsEmployee.Tables("ClockedIn").Clear();

        // sql.SqlSelectCommandClockedIn.Parameters("@CompanyID").Value = CompanyID
        sql.SqlSelectCommandClockedIn.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlSelectCommandClockedIn.Parameters("@EmployeeID").Value = emp.EmployeeID;

        // this is pulling from view that has NULL Logout's
        // if fails we want to fail in Login_Entered
        sql.cn.Open();
        sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
        sql.SqlClockedIn.Fill(dsEmployee.Tables("ClockedIn"));
        sql.cn.Close();

        if (dsEmployee.Tables("ClockedIn").Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private static void Demo_LoadJobCodeFunctions(ref Employee newEmployee)
    {
        // Dim isCLockedIn As Integer

        foreach (DataRow oRow in dsEmployee.Tables("LoggedInEmployees").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (newEmployee.EmployeeID == oRow("EmployeeID"))
                {
                    // isCLockedIn += 1

                    newEmployee.LoginTrackingID = oRow("LoginTrackingID");
                    newEmployee.JobCodeID = oRow("JobCode");
                    newEmployee.LogInTime = oRow("LogInTime");

                    foreach (DataRow cRow in dsEmployee.Tables("JobCodeInfo").Rows)
                    {
                        if (newEmployee.JobCodeID == cRow("JobCodeID"))
                        {
                            newEmployee.JobCodeName = cRow("JobCodeName");
                            newEmployee.Manager = cRow("Manager");
                            newEmployee.Cashier = cRow("Cashier");
                            newEmployee.Bartender = cRow("Bartender");
                            newEmployee.Server = cRow("Server");
                            newEmployee.Hostess = cRow("Hostess");
                            newEmployee.ClockInReq = cRow("ClockInReq");
                            newEmployee.PasswordReq = cRow("PasswordReq");
                        }
                    }
                    break;
                }
            }

        }
        // Return isCLockedIn

    }

    internal static object ActuallyLogIn(ref Employee emp)
    {
        // **********************************************
        // this needs to fail from sub it is called from

        string strCollection;
        SqlClient.SqlDataReader dtr;
        SqlClient.SqlCommand cmd;
        var isCLockedIn = default(int);

        foreach (Employee salaried in SalariedEmployees)
        {
            if (salaried.EmployeeID == emp.EmployeeID)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(CheckingDatabaseConection(), true, false)))
                {
                    return 1;
                }
                else
                {
                    return -999;
                }
                return default;
            }
        }

        if (typeProgram == "Online_Demo")
        {
            // isCLockedIn = Demo_LoadJobCodeFunctions(emp)
            foreach (DataRow oRow in dsEmployee.Tables("LoggedInEmployees").Rows)
            {
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (emp.EmployeeID == oRow("EmployeeID"))
                    {
                        isCLockedIn += 1;
                    }
                }
            }
            return isCLockedIn;
            return default;
        }

        // 444     Try
        strCollection = "SELECT LoginTrackingID, JobCode, LogInTime, JobCodeName, Manager, Cashier, Bartender, Server, Hostess, ClockInReq, PasswordReq FROM ClockedInView WHERE LocationID = '" + companyInfo.LocationID + "' AND EmployeeID = '" + emp.EmployeeID + "'";

        sql.cn.Open();
        sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
        cmd = new SqlClient.SqlCommand(strCollection, sql.cn);

        dtr = cmd.ExecuteReader;

        while (dtr.Read())
        {
            isCLockedIn += 1;

            emp.LoginTrackingID = dtr("LoginTrackingID");
            emp.JobCodeID = dtr("JobCode");
            emp.LogInTime = dtr("LogInTime");
            emp.JobCodeName = dtr("JobCodeName");
            emp.Manager = dtr("Manager");
            emp.Cashier = dtr("Cashier");
            emp.Bartender = dtr("Bartender");
            emp.Server = dtr("Server");
            emp.Hostess = dtr("Hostess");
            emp.ClockInReq = dtr("ClockInReq");
            emp.PasswordReq = dtr("PasswordReq");

        }

        dtr.Close();
        sql.cn.Close();
        // in the middle of try,catch
        // 444   Catch ex As Exception

        // If dtr.IsClosed = False Then
        // dtr.Close()
        // End If
        // CloseConnection()
        // MsgBox(ex.Message)
        // End Try

        return isCLockedIn;

    }

    internal static Employee DetermineSecondEmployeeAuthorization(ref string authLogin)
    {
        string empID;
        string passcode;

        empID = authLogin.Substring(0, 4);
        passcode = authLogin.Substring(4, 4);

        foreach (Employee emp in AllEmployees)
        {
            if (empID == emp.EmployeeNumber)
            {
                if (passcode == emp.PasscodeID)
                {

                    actingManager = emp;
                    return emp;
                }
                else
                {
                    Interaction.MsgBox("Passcode incorrect");
                    return default;
                }
            }
        }

        return default;
    }



    internal static void EnterEmployeeToLoginDatabase(ref Employee emp)    // (ByVal clockInJunk As ClockInInfo222)
    {

        if (typeProgram == "Online_Demo")
        {
            EnterEmployeeToLoginDataSet(emp);
            return;
        }

        SqlClient.SqlCommand cmd;
        decimal otPay;

        if (emp.OTPayRate > emp.RegPayRate)
        {
            otPay = emp.OTPayRate;
        }
        else
        {
            otPay = emp.RegPayRate;
        }

        cmd = new SqlClient.SqlCommand("INSERT INTO AAALoginTracking (CompanyID, LocationID, DailyCode, EmployeeID, JobCode, LogInTime, TerminalsGroupID, RegPayRate, OTPayRate, Terminal) VALUES (@CompanyID, @LocationID, @DailyCode, @EmployeeID, @JobCode, @LogInTime, @TerminalsGroupID, @RegPayRate, @OTPayRate, @Terminal)", sql.cn);

        cmd.Parameters.Add(new SqlClient.SqlParameter("@CompanyID", System.Data.SqlDbType.NChar, 6));
        cmd.Parameters("@CompanyID").Value = companyInfo.CompanyID;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@LocationID", System.Data.SqlDbType.NChar, 6));
        cmd.Parameters("@LocationID").Value = companyInfo.LocationID;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@DailyCode", SqlDbType.BigInt, 8));
        if (currentTerminal.CurrentDailyCode == default)
        {
            cmd.Parameters("@DailyCode").Value = 0;
        }
        else
        {
            cmd.Parameters("@DailyCode").Value = currentTerminal.CurrentDailyCode;
        }
        cmd.Parameters.Add(new SqlClient.SqlParameter("@EmployeeID", SqlDbType.Int, 4));
        cmd.Parameters("@EmployeeID").Value = emp.EmployeeID; // clockInJunk.EmpID
        cmd.Parameters.Add(new SqlClient.SqlParameter("@JobCode", SqlDbType.Int, 4));
        cmd.Parameters("@JobCode").Value = emp.JobCodeID;  // clockInJunk.JobCodeID
        cmd.Parameters.Add(new SqlClient.SqlParameter("@LogInTime", SqlDbType.DateTime, 4));
        cmd.Parameters("@LogInTime").Value = DateTime.Now.AddSeconds(-1 * DateTime.Now.Second);
        cmd.Parameters.Add(new SqlClient.SqlParameter("@TerminalsGroupID", SqlDbType.Int, 4));
        cmd.Parameters("@TerminalsGroupID").Value = currentTerminal.TermGroupID;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@RegPayRate", SqlDbType.Decimal, 5));
        cmd.Parameters("@RegPayRate").Value = emp.RegPayRate;   // clockInJunk.RegPayRate
        cmd.Parameters.Add(new SqlClient.SqlParameter("@OTPayRate", SqlDbType.Decimal, 5));
        cmd.Parameters("@OTPayRate").Value = otPay;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@Terminal", SqlDbType.Int, 4));
        cmd.Parameters("@Terminal").Value = currentTerminal.TermPrimaryKey;


        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
        }


    }

    internal static void UpdateEmployeeToLoginDatabase(ref Employee emp, ref ClockOutInfo clockOutJunk)
    {

        SqlClient.SqlCommand cmd;

        cmd = new SqlClient.SqlCommand("UPDATE AAALoginTracking SET LogOutTime = @LogOutTime, TerminalsGroupID = @TerminalsGroupID, TipableSales = @TipableSales, DeclaredTips = @DeclaredTips, ChargedSales = @ChargedSales, ChargedTips = @ChargedTips, DailyCode = @DailyCode WHERE LoginTrackingID = @LoginTrackingID", sql.cn);


        cmd.Parameters.Add(new SqlClient.SqlParameter("@LoginTrackingID", SqlDbType.BigInt, 8));
        cmd.Parameters("@LoginTrackingID").Value = emp.LoginTrackingID;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@DailyCode", SqlDbType.BigInt, 8));
        cmd.Parameters("@DailyCode").Value = currentTerminal.CurrentDailyCode;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@LogOutTime", SqlDbType.DateTime, 4));
        cmd.Parameters("@LogOutTime").Value = clockOutJunk.TimeOut;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@TerminalsGroupID", SqlDbType.Int, 4));
        cmd.Parameters("@TerminalsGroupID").Value = currentTerminal.TermGroupID;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@TipableSales", SqlDbType.Decimal, 5));
        cmd.Parameters("@TipableSales").Value = clockOutJunk.TipableSales;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@DeclaredTips", SqlDbType.Decimal, 5));
        cmd.Parameters("@DeclaredTips").Value = clockOutJunk.DeclaredTips;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@ChargedSales", SqlDbType.Decimal, 5));
        cmd.Parameters("@ChargedSales").Value = clockOutJunk.ChargedSales;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@ChargedTips", SqlDbType.Decimal, 5));
        cmd.Parameters("@ChargedTips").Value = clockOutJunk.ChargedTips;
        // If currentTerminal.CurrentDailyCode = Nothing Then
        // should always have a dailycode b/c otherwise 
        // we could not get tot this screen
        // Else
        // End If

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }

    }



    internal static void AddPaymentsAndCredits222(string payType, decimal amount)
    {
        // *********************
        // not using yet
        // by doing this we do not update the dataset which grids are linked to

        SqlClient.SqlCommand cmd;

        cmd = new SqlClient.SqlCommand("INSERT INTO PaymentsAndCredits(ExperienceNumber, CheckNumber, PaymentType, PaymentAmount, Tip, TipAdjustment, Applied) VALUES (@ExperienceNumber, @CheckNumber, @PaymentType, @PaymentAmount, @Tip, @TipAdjustment, @Applied)", sql.cn);

        cmd.Parameters.Add(new SqlClient.SqlParameter("@ExperienceNumber", SqlDbType.BigInt, 8));
        cmd.Parameters("@ExperienceNumber").Value = currentTable.ExperienceNumber;
        cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CheckNumber", System.Data.SqlDbType.Int, 4, "CheckNumber"));
        cmd.Parameters("@CheckNumber").Value = currentTable.CheckNumber;
        cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentType", System.Data.SqlDbType.Int, 4, "PaymentTypeID"));
        cmd.Parameters("@PaymentType").Value = payType;

        cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentAmount", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, 19, 2, "PaymentAmount", System.Data.DataRowVersion.Current, null));
        cmd.Parameters("@PaymentAmount").Value = amount;

        cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Tip", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, 19, 2, "Tip", System.Data.DataRowVersion.Current, null));
        cmd.Parameters("@Tip").Value = 0;

        // cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TipAdjustment", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(19, Byte), CType(2, Byte), "TipAdjustment", System.Data.DataRowVersion.Current, Nothing))
        // cmd.Parameters("@TipAdjustment").Value = 0

        cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Applied", System.Data.SqlDbType.Bit, 1, "Applied"));
        cmd.Parameters("@Applied").Value = 0;

        // cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PaymentAuthorizeID", System.Data.SqlDbType.Int, 4, "PaymentAuthorizeID"))
        // cmd.Parameters("@PaymentType").Value = authID


        sql.cn.Open();
        sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
        cmd.ExecuteNonQuery();
        sql.cn.Close();

        dsOrder.Tables("PaymentsAndCredits").Clear();

        sql.cn.Open();
        sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
        sql.SqlSelectCommandPayments.Parameters("@ExperienceNumber").Value = currentTable.ExperienceNumber;
        sql.SqlDataAdapterPayments.Fill(dsOrder.Tables("PaymentsAndCredits"));
        sql.cn.Close();

    }

    internal static void PopulateAllTablesWithStatus(bool fromStart)
    {

        // this is pulled from    stored proc:  AllTablesSelectCommand
        // view: TableStatusView

        if (typeProgram == "Online_Demo")
        {
            return;
        }
        dsOrder.Tables("AllTables").Rows.Clear();

        sql.SqlSelectCommandAllTables.Parameters("@LocationID").Value = companyInfo.LocationID;

        try
        {
            // gets a collection of all tables in TableOverview
            // with Last Status from Experience Status Table
            if (fromStart == false)
            {
                sql.cn.Open();
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            }
            sql.SqlDataAdapterAllTables.Fill(dsOrder.Tables("AllTables"));
            if (fromStart == false)
            {
                sql.cn.Close();
            }
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }

        return;
        // 222 below
        // the following finds any table with no previous experience
        // fills in the default availability in TableOverview
        foreach (DataRow oRow in dsOrder.Tables("AllTables").Rows)
        {
            if (object.ReferenceEquals(oRow("TableStatusID"), DBNull.Value) | oRow("Available") == 0)
            {
                oRow("TableStatusID") = oRow("Available");
                oRow("LastStatusTime") = DateTime.Now;
                oRow("SatTime") = DateTime.Now;
                oRow("ItemsOnHold") = 0;
            }
        }

    }

    internal static void ChangeStatusInDataBase(int newStatus, long orderNumber, bool isMainCourse, decimal avgDollar, DateTime chkDown, DateTime availSeating)
    {

        DataRow oRow;

        if (currentTerminal.TermMethod == "Quick" | currentTable.TicketNumber > 0) // currentTable.TabID = -888 Then
        {
            foreach (DataRow currentORow in dsOrder.Tables("QuickTickets").Rows)
            {
                oRow = currentORow;
                if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                {
                    oRow("LastStatusTime") = DateTime.Now;
                    if (chkDown != default)
                    {
                        oRow("CheckDown") = chkDown;
                    }
                    if (availSeating != default)
                    {
                        oRow("AvailForSeating") = availSeating;
                    }
                    oRow("LastStatus") = newStatus;
                }
            }
        }

        else if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
        {

            if (currentTable.IsTabNotTable == false)
            {

                foreach (DataRow currentORow1 in dsOrder.Tables("AvailTables").Rows)
                {
                    oRow = currentORow1;
                    if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        oRow("LastStatusTime") = DateTime.Now;
                        if (chkDown != default)
                        {
                            oRow("CheckDown") = chkDown;
                        }
                        if (availSeating != default)
                        {
                            oRow("AvailForSeating") = availSeating;
                        }
                        oRow("LastStatus") = newStatus;
                    }
                }
            }

            else
            {
                foreach (DataRow currentORow2 in dsOrder.Tables("AvailTabs").Rows)
                {
                    oRow = currentORow2;
                    if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        oRow("LastStatusTime") = DateTime.Now;
                        if (chkDown != default)
                        {
                            oRow("CheckDown") = chkDown;
                        }
                        if (availSeating != default)
                        {
                            oRow("AvailForSeating") = availSeating;
                        }
                        oRow("LastStatus") = newStatus;
                    }
                }
            }
        }

        // sss       SaveAvailTabsAndTables()

    }

    internal static void PopulateQuickTicket()
    {
        dsOrder.Tables("QuickTickets").Rows.Clear();

        if (typeProgram == "Online_Demo")
        {


            if (dsOrderDemo.Tables("QuickTickets").Rows.Count > 0)
            {
                string filterString;
                string NotfilterString;
                filterString = "TerminalID = " + currentTerminal.TermID;
                NotfilterString = "NOT TerminalID = " + currentTerminal.TermID;
                var argdtTO = dsOrder.Tables("QuickTickets");
                Demo_FilterDemoDataTabble(dsOrderDemo.Tables("QuickTickets"), ref argdtTO, filterString, NotfilterString);
            }
            // MsgBox(dsOrderDemo.Tables("QuickTickets").Rows.Count)

            return;
        }

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            // sql.SqlSelectCommandQuickTicketSP.Parameters("@CompanyID").Value = CompanyID
            if (currentTerminal.TermMethod == "Quick")
            {
                sql.SqlSelectCommandQuickTicketSP.Parameters("@LocationID").Value = companyInfo.LocationID;
                sql.SqlSelectCommandQuickTicketSP.Parameters("@TerminalID").Value = currentTerminal.TermID;
                sql.SqlSelectCommandQuickTicketSP.Parameters("@DailyCode").Value = currentTerminal.CurrentDailyCode;
                sql.SqlQuickTicketSP.Fill(dsOrder.Tables("QuickTickets"));
            }
            else
            {
                sql.SqlSelectCommandQuickTicketsBar.Parameters("@LocationID").Value = companyInfo.LocationID;
                sql.SqlSelectCommandQuickTicketsBar.Parameters("@DailyCode").Value = currentTerminal.CurrentDailyCode;
                sql.SqlQuickTicketsBar.Fill(dsOrder.Tables("QuickTickets"));

            }

            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
        }

    }

    internal static void PopulateLoggedInEmployees(bool fromStart)
    {

        dsEmployee.Tables("LoggedInEmployees").Rows.Clear();

        sql.SqlSelectCommandClockedInList.Parameters("@CompanyID").Value = companyInfo.CompanyID;
        sql.SqlSelectCommandClockedInList.Parameters("@LocationID").Value = companyInfo.LocationID;

        if (fromStart == false)
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
        }
        sql.SqlClockedInList.Fill(dsEmployee.Tables("LoggedInEmployees"));
        if (fromStart == false)
        {
            sql.cn.Close();
        }

    }

    internal static void Demo_FilterDemoDataTabble(DataTable dtFrom, ref DataTable dtTO, string filter, string NOTfilter)
    {

        DataRow[] iArray;
        DataRow[] dArray;
        int i;

        // MsgBox(dtTO.TableName.ToString)
        // MsgBox(dtTO.Rows.Count)
        // MsgBox(dtFrom.Rows.Count)

        try
        {
            iArray = dtFrom.Select(filter);
            dArray = dtFrom.Select(NOTfilter);

            var loopTo = iArray.Length - 1;
            for (i = 0; i <= loopTo; i++)
            {
                dtTO.ImportRow(iArray[i]);

                foreach (DataRow demoRow in dtFrom.Rows)
                {
                    if (!(demoRow.RowState == DataRowState.Deleted) | !(demoRow.RowState == DataRowState.Detached))
                    {
                        // Try
                        // If dtTO.TableName.ToString = "OpenOrders" Then
                        // MsgBox(demoRow("ItemName"))
                        // MsgBox(demoRow(0))
                        // MsgBox(dtTO.Rows(i)(0))
                        // End If
                        // '               Catch ex As Exception
                        // End Try

                        if (demoRow[0] == dtTO.Rows(i)(0))
                        {
                            demoRow.Delete();
                            dtFrom.AcceptChanges();
                            break;
                        }
                    }
                }

            }
        }
        catch (Exception ex)
        {

        }


        // dtFrom.Clear()
        // For i = 0 To (dArray.Length - 1)
        // dtFrom.ImportRow(dArray(i))
        // Next
        dtTO.AcceptChanges();
        dtFrom.AcceptChanges();

    }
    internal static void Demo_FilterDontDelete(DataTable dtFrom, ref DataTable dtTO, string filter)
    {

        DataRow[] iArray;
        int i;

        try
        {
            iArray = dtFrom.Select(filter);

            var loopTo = iArray.Length - 1;
            for (i = 0; i <= loopTo; i++)
                dtTO.ImportRow(iArray[i]);
        }
        catch (Exception ex)
        {

        }

    }

    internal static void PopulateTabsAndTables(Employee emp, long dc, bool IsBartender, bool IsOneBartender, ref EmployeeCollection empCollection)
    {
        dsOrder.Tables("AvailTables").Rows.Clear();
        dsOrder.Tables("AvailTabs").Rows.Clear();

        // Dim todaysDate As Date
        // Dim yesterdaysDate As Date

        // MsgBox(dsOrderDemo.Tables("AvailTables").Rows.Count)

        if (typeProgram == "Online_Demo")
        {
            string filterString = "";
            string NotfilterString = "";
            bool firstPass = true;

            if (IsBartender == true & IsOneBartender == false)
            {

                foreach (Employee BarMan in empCollection)    // currentBartenders
                {
                    if (firstPass == true)
                    {
                        firstPass = false;
                        filterString = "EmployeeID = " + BarMan.EmployeeID;
                        NotfilterString = "NOT EmployeeID = " + BarMan.EmployeeID;
                    }
                    else
                    {
                        filterString = filterString + " OR EmployeeID = " + BarMan.EmployeeID;
                        NotfilterString = filterString + " OR NOT EmployeeID = " + BarMan.EmployeeID;
                    }
                }
                var argdtTO = dsOrder.Tables("AvailTables");
                Demo_FilterDontDelete(dsOrderDemo.Tables("AvailTables"), ref argdtTO, filterString); // , NotfilterString)
                var argdtTO1 = dsOrder.Tables("AvailTabs");
                Demo_FilterDontDelete(dsOrderDemo.Tables("AvailTabs"), ref argdtTO1, filterString); // , NotfilterString)
            }

            else
            {
                filterString = "EmployeeID = " + emp.EmployeeID;
                NotfilterString = "NOT EmployeeID = " + emp.EmployeeID;
                var argdtTO2 = dsOrder.Tables("AvailTables");
                Demo_FilterDontDelete(dsOrderDemo.Tables("AvailTables"), ref argdtTO2, filterString); // , NotfilterString)
                var argdtTO3 = dsOrder.Tables("AvailTabs");
                Demo_FilterDontDelete(dsOrderDemo.Tables("AvailTabs"), ref argdtTO3, filterString);
            } // , NotfilterString)
            return;
        }


        // ********************
        // if its between mindight and 6am. (or prreset time) we look at last 24 hours
        // todaysDate = Format(Today, "D")
        // yesterdaysDate = Format(Today.AddDays(-52), "D")


        if (IsBartender == true & IsOneBartender == false)
        {

            try
            {
                sql.cn.Open();
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                foreach (Employee BarMan in empCollection)    // currentBartenders
                {
                    // **** uses parameter LastStatus > 1 in SQL SERVER stored procedures
                    // **** we now use SQL Helper 
                    // can remove stored procedures
                    // later we can do in order of currentServer.empID
                    // we will have to loop through this twice  ?????
                    // sql.SqlSelectCommandAvailTablesSP.Parameters("@CompanyID").Value = CompanyID
                    sql.SqlSelectCommandAvailTablesSP.Parameters("@LocationID").Value = companyInfo.LocationID;
                    sql.SqlSelectCommandAvailTablesSP.Parameters("@EmployeeID").Value = BarMan.EmployeeID;
                    sql.SqlSelectCommandAvailTablesSP.Parameters("@DailyCode").Value = dc;
                    sql.SqlAvailTablesSP.Fill(dsOrder.Tables("AvailTables"));

                    // sql.SqlSelectCommandAvailTabsSP.Parameters("@CompanyID").Value = CompanyID
                    sql.SqlSelectCommandAvailTabsSP.Parameters("@LocationID").Value = companyInfo.LocationID;
                    sql.SqlSelectCommandAvailTabsSP.Parameters("@EmployeeID").Value = BarMan.EmployeeID;
                    sql.SqlSelectCommandAvailTabsSP.Parameters("@DailyCode").Value = dc;
                    sql.SqlAvailTabsSP.Fill(dsOrder.Tables("AvailTabs"));
                }
                sql.cn.Close();
            }

            catch (Exception ex)
            {
                CloseConnection();
                Interaction.MsgBox(ex.Message);
                // PopulateTabsAndTablesWhenDown(IsBartender, IsOneBartender)
            }
        }

        else
        {
            try
            {
                sql.cn.Open();
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                // sql.SqlSelectCommandAvailTablesSP.Parameters("@CompanyID").Value = CompanyID
                sql.SqlSelectCommandAvailTablesSP.Parameters("@LocationID").Value = companyInfo.LocationID;
                sql.SqlSelectCommandAvailTablesSP.Parameters("@EmployeeID").Value = emp.EmployeeID;  // currentServer.EmployeeID
                sql.SqlSelectCommandAvailTablesSP.Parameters("@DailyCode").Value = dc;
                sql.SqlAvailTablesSP.Fill(dsOrder.Tables("AvailTables"));
                // sql.SqlSelectCommandAvailTabsSP.Parameters("@CompanyID").Value = CompanyID
                sql.SqlSelectCommandAvailTabsSP.Parameters("@LocationID").Value = companyInfo.LocationID;
                sql.SqlSelectCommandAvailTabsSP.Parameters("@DailyCode").Value = dc;
                sql.SqlSelectCommandAvailTabsSP.Parameters("@EmployeeID").Value = emp.EmployeeID; // currentServer.EmployeeID
                sql.SqlAvailTabsSP.Fill(dsOrder.Tables("AvailTabs"));
                sql.cn.Close();
            }

            catch (Exception ex)
            {
                CloseConnection();
                Interaction.MsgBox(ex.Message);
                // PopulateTabsAndTablesWhenDown(IsBartender, IsOneBartender)
            }

        }

    }

    internal static void PopulateTabsAndTablesEveryone(Employee emp, long dc, bool IsBartender, bool IsOneBartender, ref EmployeeCollection empCollection)
    {
        dsOrder.Tables("AvailTables").Rows.Clear();
        dsOrder.Tables("AvailTabs").Rows.Clear();
        dsOrder.Tables("QuickTickets").Rows.Clear();

        // already in middle of Try/catch
        sql.cn.Open();
        sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();

        if (!(currentTerminal.TermMethod == "Quick"))
        {
            sql.SqlSelectCommandOpenTables.Parameters("@LocationID").Value = companyInfo.LocationID;
            sql.SqlSelectCommandOpenTables.Parameters("@DailyCode").Value = dc;
            sql.SqlOpenTables.Fill(dsOrder.Tables("AvailTables"));
            // sql.SqlOpenTickets.Fill(dsOrder.Tables("OpenTickets"))
            sql.SqlSelectCommandOpenTabs.Parameters("@LocationID").Value = companyInfo.LocationID;
            sql.SqlSelectCommandOpenTabs.Parameters("@DailyCode").Value = dc;
            sql.SqlOpenTabs.Fill(dsOrder.Tables("AvailTabs"));
        }

        // we fill this for non-quick for Beth's Tabs
        sql.SqlSelectCommandOpenQuick.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlSelectCommandOpenQuick.Parameters("@DailyCode").Value = currentTerminal.CurrentDailyCode;
        sql.SqlOpenQuick.Fill(dsOrder.Tables("QuickTickets"));

        sql.cn.Close();

    }

    internal static void CreateDataViews(int empID, bool filterQuick)
    {

        dvAvailTables = new DataView();
        {
            ref var withBlock = ref dvAvailTables;
            withBlock.Table = dsOrder.Tables("AvailTables");
            withBlock.RowFilter = "LastStatus < 8 AND LastStatus > 1"; // (-2)" '(-1) was voided check
            withBlock.RowStateFilter = DataViewRowState.CurrentRows;
            withBlock.Sort = "ExperienceDate DESC"; // ASC"
        }

        dvTransferTables = new DataView();
        {
            ref var withBlock1 = ref dvTransferTables;
            withBlock1.Table = dsOrder.Tables("AvailTables");
            withBlock1.RowFilter = "LastStatus = 8";
            withBlock1.Sort = "ExperienceDate DESC"; // ASC"
        }

        dvAvailTabs = new DataView();
        {
            ref var withBlock2 = ref dvAvailTabs;
            withBlock2.Table = dsOrder.Tables("AvailTabs");
            withBlock2.RowFilter = "LastStatus < 8 AND LastStatus > 1"; // " ' AND LastStatus > (-2)"
            withBlock2.RowStateFilter = DataViewRowState.CurrentRows;
            withBlock2.Sort = "TabName ASC";
        }

        dvTransferTabs = new DataView();
        {
            ref var withBlock3 = ref dvTransferTabs;
            withBlock3.Table = dsOrder.Tables("AvailTabs");
            withBlock3.RowFilter = "LastStatus = 8";
            withBlock3.Sort = "TabName ASC";
        }

        if (currentTerminal.TermMethod == "Bar")
        {
            // 444       dvQuickTickets = New DataView
            {
                ref var withBlock4 = ref dvQuickTickets;
                withBlock4.Table = dsOrder.Tables("QuickTickets");
                if (filterQuick == true)
                {
                    withBlock4.RowFilter = "EmployeeID = " + empID;
                }
                // 444  .Sort = "ExperienceDate ASC"
                withBlock4.Sort = "ExperienceDate DESC";
            }
        }

    }

    internal static void CreateDataViewsOrder()   // Handles testgridview.RePopulateDataViews
    {

        // 444 
        dvOrder = new DataView();
        dvOrderPrint = new DataView();
        dvOrderTopHierarcy = new DataView();
        dvOrderHolds = new DataView();
        dvKitchen = new DataView();

        {
            ref var withBlock = ref dvOrder;
            withBlock.Table = dsOrder.Tables("OpenOrders");
            withBlock.AllowEdit = true;
            withBlock.Sort = "CustomerNumber, sii, si2, sin";
        }

        {
            ref var withBlock1 = ref dvOrderPrint;
            withBlock1.Table = dsOrder.Tables("OpenOrders");
            withBlock1.AllowEdit = true;
            withBlock1.RowFilter = "ItemStatus = 0";
            withBlock1.Sort = "CourseNumber, CustomerNumber, sii, si2, sin";
        }

        {
            ref var withBlock2 = ref dvOrderTopHierarcy;
            withBlock2.Table = dsOrder.Tables("OpenOrders");
            withBlock2.AllowEdit = true;
            withBlock2.RowFilter = "sin = sii"; // AND CheckNumber ='" & currentTable.CheckNumber & "'"
            // .RowStateFilter = DataViewRowState.CurrentRows
            withBlock2.Sort = "CustomerNumber, sii, si2, sin";
        }

        {
            ref var withBlock3 = ref dvOrderHolds;
            // is all holds for check
            withBlock3.Table = dsOrder.Tables("OpenOrders");
            withBlock3.AllowEdit = true;
            withBlock3.RowFilter = "ItemStatus = 1";
            // .RowStateFilter = DataViewRowState.CurrentRows
            withBlock3.Sort = "CustomerNumber, sii, si2, sin";
        }

        {
            ref var withBlock4 = ref dvKitchen;
            // is all items sent to kitchen but not delivered for check
            withBlock4.Table = dsOrder.Tables("OpenOrders");
            withBlock4.AllowEdit = true;
            withBlock4.RowFilter = "ItemStatus = 2";
            // .RowStateFilter = DataViewRowState.CurrentRows
            withBlock4.Sort = "CustomerNumber, sii, si2, sin";
        }
        // Me.testgridview.CalculateSubTotal()

    }

    internal static void DisposeDataViewsOrder()
    {
        // 444
        // 444   Exit Sub

        dvOrder.Dispose();
        dvOrderPrint.Dispose();
        dvOrderTopHierarcy.Dispose();
        dvOrderHolds.Dispose();
        dvKitchen.Dispose();


    }

    internal static void CreateDataViewsPizza()
    {
        // dvPizzaFull = New DataView
        // dvPizzaFirst = New DataView
        // dvPizzaSecond = New DataView

        {
            ref var withBlock = ref dvPizzaFull;
            withBlock.Table = dsOrder.Tables("OpenOrders");
            withBlock.RowFilter = "ItemID > 0 AND si2 = 1 AND sii = " + currentTable.ReferenceSIN;
            withBlock.Sort = "sin";
        }

        {
            ref var withBlock1 = ref dvPizzaFirst;
            withBlock1.Table = dsOrder.Tables("OpenOrders");
            withBlock1.RowFilter = "ItemID > 0 AND si2 = 2 AND sii = " + currentTable.ReferenceSIN;
            withBlock1.Sort = "sin";
        }

        {
            ref var withBlock2 = ref dvPizzaSecond;
            withBlock2.Table = dsOrder.Tables("OpenOrders");
            withBlock2.RowFilter = "ItemID > 0 AND si2 = 3 AND sii = " + currentTable.ReferenceSIN;
            withBlock2.Sort = "sin";
        }

    }


    internal static void CalculateClosingTotal()
    {

        try
        {
            if (dsOrder.Tables("OpenOrders").Rows.Count > 0)
            {
                currentTable.SubTotal = dsOrder.Tables("OpenOrders").Compute("Sum(Price)", ""); // "ItemStatus < 8")
            }
            else
            {
                currentTable.SubTotal = 0;
            }
        }
        catch (Exception ex)
        {
            // this is the exception when all items were transfered
            currentTable.SubTotal = 0;
        }

    }


    private static void PopulateTabsAndTablesWhenDown222(bool IsBartender, bool IsOneBartender)
    {

        DataRow bRow;
        DataRow oRow;

        if (IsBartender == true & IsOneBartender == false)
        {

            foreach (Employee BarMan in currentBartenders)
            {
                foreach (DataRow currentBRow in dsBackup.Tables("AvailTablesTerminal").Rows)
                {
                    bRow = currentBRow;

                    if (bRow("EmployeeID") == BarMan.EmployeeID)
                    {
                        if (!object.ReferenceEquals(bRow("TableNumber"), DBNull.Value) & bRow("LastStatus") > 1)
                        {
                            oRow = dsOrder.Tables("AvailTables").NewRow;
                            oRow = CopyOneRowToAnotherAvailTabsAndTables222(bRow, ref oRow);
                            dsOrder.Tables("AvailTables").Rows.Add(oRow);
                        }
                    }
                }

                foreach (DataRow currentBRow1 in dsBackup.Tables("AvailTabsTerminal").Rows)
                {
                    bRow = currentBRow1;
                    if (bRow("EmployeeID") == BarMan.EmployeeID)
                    {
                        if (!object.ReferenceEquals(bRow("TabID"), DBNull.Value) & bRow("LastStatus") > 1)
                        {
                            oRow = dsOrder.Tables("AvailTabs").NewRow;
                            oRow = CopyOneRowToAnotherAvailTabsAndTables222(bRow, ref oRow);
                            dsOrder.Tables("AvailTabs").Rows.Add(oRow);
                        }
                    }
                }
            }
        }

        else
        {

            foreach (DataRow currentBRow2 in dsBackup.Tables("AvailTablesTerminal").Rows)
            {
                bRow = currentBRow2;
                if (bRow("EmployeeID") == currentServer.EmployeeID)
                {
                    if (!object.ReferenceEquals(bRow("TableNumber"), DBNull.Value) & bRow("LastStatus") > 1)
                    {
                        oRow = dsOrder.Tables("AvailTables").NewRow;
                        oRow = CopyOneRowToAnotherAvailTabsAndTables222(bRow, ref oRow);
                        dsOrder.Tables("AvailTables").Rows.Add(oRow);
                    }
                }
            }

            foreach (DataRow currentBRow3 in dsBackup.Tables("AvailTabsTerminal").Rows)
            {
                bRow = currentBRow3;
                if (bRow("EmployeeID") == currentServer.EmployeeID)
                {
                    if (!object.ReferenceEquals(bRow("TabID"), DBNull.Value) & bRow("LastStatus") > 1)
                    {
                        oRow = dsOrder.Tables("AvailTabs").NewRow;
                        oRow = CopyOneRowToAnotherAvailTabsAndTables222(bRow, ref oRow);
                        dsOrder.Tables("AvailTabs").Rows.Add(oRow);
                    }
                }
            }
        }

        dsOrder.Tables("AvailTables").AcceptChanges();
        dsOrder.Tables("AvailTabs").AcceptChanges();

    }

    internal static void UpdateMethodDataset()
    {
        DataRow orow;

        if (currentTerminal.TermMethod == "Quick" | currentTable.TicketNumber > 0) // currentTable.TabID = -888 Then
        {
            foreach (DataRow currentOrow in dsOrder.Tables("QuickTickets").Rows)
            {
                orow = currentOrow;
                if (orow("ExperienceNumber") == currentTable.ExperienceNumber)
                {
                    orow("MethodUse") = currentTable.MethodUse;
                }
            }
        }
        else if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
        {
            if (currentTable.IsTabNotTable == false)
            {
                foreach (DataRow currentOrow1 in dsOrder.Tables("AvailTables").Rows)
                {
                    orow = currentOrow1;
                    if (orow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        orow("MethodUse") = currentTable.MethodUse;
                    }
                }
            }
            else
            {
                foreach (DataRow currentOrow2 in dsOrder.Tables("AvailTabs").Rows)
                {
                    orow = currentOrow2;
                    if (orow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        orow("MethodUse") = currentTable.MethodUse;
                    }
                }
            }
        }
        // DefineMethodDirection()
        // GenerateOrderTables.SaveAvailTabsAndTables()    'will only effect QuickService

    }

    internal static void SaveAvailTabsAndTables()
    {

        if (currentTerminal.TermMethod == "Quick" | currentTable.TicketNumber > 0)   // = -888 Then
        {
            if (currentTerminal.TermMethod == "Quick")
            {
                sql.SqlQuickTicketSP.Update(dsOrder, "QuickTickets");
            }
            else
            {
                sql.SqlQuickTicketsBar.Update(dsOrder, "QuickTickets");
            }
        }

        else if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
        {
            if (currentTable.IsTabNotTable == false)
            {
                sql.SqlAvailTablesSP.Update(dsOrder, "AvailTables");
            }
            else
            {
                sql.SqlAvailTabsSP.Update(dsOrder, "AvailTabs");
            }
        }

    }

    internal static void SaveTerminalTabsAndTables222()
    {
        // Dim oRow As DataRow
        DataRow bRow;

        // we place all tabs and table avail info in both regular and terminal datasets
        // in Perform New Experience ADD
        // a "1" in dbUP if up, "0" if down, "2" if changed when down
        if (currentTable.IsTabNotTable == false)
        {
            bRow = dsBackup.Tables("AvailTablesTerminal").Rows.Find(currentTable.ExperienceNumber);
        }
        else
        {
            bRow = dsBackup.Tables("AvailTabsTerminal").Rows.Find(currentTable.ExperienceNumber);
        }

        if (bRow is not null)
        {
            // we assign 2 when we made a change to a row created when db UP
            if (bRow("dbUP") == 1)
            {
                bRow("dbUP") = 2;
            }
        }

        return;

        // not doing this
        if (currentTable.IsTabNotTable == false)
        {
        }
        // sql222.SqlDataAdapterAvailTablesTerminal.Update(dsBackup.Tables("AvailTablesTerminal"))
        else
        {
            // sql222.SqlDataAdapterAvailTabsTerminal.Update(dsBackup.Tables("AvailTabsTerminal"))
        }

    }

    internal static bool PopulateThisExperience(long expNum, bool fromStart)
    {
        var isHeld = default(bool);
        string newvalueAcct;
        string newvalueExpDate;

        dsOrder.Tables("CurrentlyHeld").Rows.Clear();
        dsOrder.Tables("OpenOrders").Rows.Clear();
        dsOrder.Tables("PaymentsAndCredits").Rows.Clear();
        // dsOrder.Tables("StatusChange").Rows.Clear()
        dsOrder.Tables("OrderDetail").Rows.Clear();
        // dsOrder.Tables("OrderForceFree").Rows.Clear()

        // MsgBox(dsOrderDemo.Tables("AvailTables").Rows.Count)
        // MsgBox(dsOrder.Tables("AvailTables").Rows.Count)
        if (typeProgram == "Online_Demo")
        {
            string filterString;
            string NotfilterString;
            filterString = "ExperienceNumber = " + expNum;
            NotfilterString = "NOT ExperienceNumber = " + expNum;

            var argdtTO = dsOrder.Tables("OpenOrders");
            Demo_FilterDemoDataTabble(dsOrderDemo.Tables("OpenOrders"), ref argdtTO, filterString, NotfilterString); // "ExperienceNumber = '" & expNum & "'")
            var argdtTO1 = dsOrder.Tables("PaymentsAndCredits");
            Demo_FilterDemoDataTabble(dsOrderDemo.Tables("PaymentsAndCredits"), ref argdtTO1, filterString, NotfilterString); // "ExperienceNumber = '" & expNum & "'")
            var argdtTO2 = dsOrder.Tables("OrderDetail");
            Demo_FilterDemoDataTabble(dsOrderDemo.Tables("OrderDetail"), ref argdtTO2, filterString, NotfilterString); // "ExperienceNumber = '" & expNum & "'")
            // Demo_FilterDemoDataTabble(dsOrderDemo.Tables("CurrentlyHeld"), dsOrder.Tables("CurrentlyHeld"), filterString, NotfilterString) '"ExperienceNumber = '" & expNum & "'")
            return default;
        }

        try
        {
            sql.SqlSelectCommandCurrentlyHeld.Parameters("@ExperienceNumber").Value = expNum;

            sql.SqlSelectCommandOpenOrdersSP.Parameters("@LocationID").Value = companyInfo.LocationID;
            sql.SqlSelectCommandOpenOrdersSP.Parameters("@ExperienceNumber").Value = expNum;

            sql.SqlSelectCommandPayments.Parameters("@LocationID").Value = companyInfo.LocationID;
            sql.SqlSelectCommandPayments.Parameters("@ExperienceNumber").Value = expNum;

            // sql.SqlSelectCommandESC.Parameters("@LocationID").Value = companyInfo.LocationID
            // sql.SqlSelectCommandESC.Parameters("@ExperienceNumber").Value = expNum

            sql.SqlSelectCommandOrderDetail.Parameters("@LocationID").Value = companyInfo.LocationID;
            sql.SqlSelectCommandOrderDetail.Parameters("@ExperienceNumber").Value = expNum;

            // sql.SqlSelectCommandOrderForceFree.Parameters("@LocationID").Value = companyInfo.LocationID
            // sql.SqlSelectCommandOrderForceFree.Parameters("@ExperienceNumber").Value = expNum
            if (fromStart == false)
            {
                sql.cn.Open();
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            }
            sql.SqlDataAdapterCurrentlyHeld.Fill(dsOrder.Tables("CurrentlyHeld"));
            sql.SqlDataAdapterOpenOrdersSP.Fill(dsOrder.Tables("OpenOrders"));
            sql.SqlDataAdapterPayments.Fill(dsOrder.Tables("PaymentsAndCredits"));
            // sql.SqlDataAdapterESC.Fill(dsOrder.Tables("StatusChange"))
            sql.SqlDataAdapterOrderDetail.Fill(dsOrder.Tables("OrderDetail"));
            // sql.SqlDataAdapterOrderForceFree.Fill(dsOrder.Tables("OrderForceFree"))
            // at some point we can do this first
            // if held no need to populate all other tables

            if (dsOrder.Tables("CurrentlyHeld").Rows.Count == 1)
            {

                if (!object.ReferenceEquals(dsOrder.Tables("CurrentlyHeld").Rows(0)("CurrentlyHeld"), DBNull.Value))
                {
                    if (dsOrder.Tables("CurrentlyHeld").Rows(0)("CurrentlyHeld") == currentServer.FullName)
                    {
                        isHeld = false;
                    }
                    else
                    {
                        isHeld = true;
                    }
                }
                // currentTable.CurrentlyHeld = dsOrder.Tables("CurrentlyHeld").Rows(0)("CurrentlyHeld")
                else
                {
                    // now we will hold it
                    isHeld = false;
                    UpdateCurrentlyHeld(currentServer.FullName, expNum);
                    // dsOrder.Tables("CurrentlyHeld").Rows(0)("CurrentlyHeld") = currentServer.FullName
                    // sql.SqlDataAdapterCurrentlyHeld.Update(dsOrder.Tables("CurrentlyHeld"))
                    // dsOrder.Tables("CurrentlyHeld").AcceptChanges()
                }
            }

            if (fromStart == false)
            {
                sql.cn.Close();
            }
        }

        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox("Data base connection problem: " + connectserver);
        }

        if (fromStart == false)
        {
            foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)
            {
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    // If oRow("PaymentTypeID") > 1 Then
                    if (oRow("PaymentFlag") == "cc" | oRow("PaymentFlag") == "Gift" | oRow("PaymentFlag") == "Issue")
                    {
                        if (!(oRow("AccountNumber").Substring(0, 4) == "xxxx") & !(oRow("AccountNumber") == "Manual"))
                        {
                            try
                            {
                                if (oRow("AccountNumber").ToString.Length > 20)
                                {
                                    newvalueAcct = CryOutloud.Decrypt(oRow("AccountNumber"), "test");
                                    oRow("AccountNumber") = newvalueAcct;
                                }
                            }

                            // can't encrypt exp date b/c database only holds 4 chars
                            // newvalueExpDate = CryOutloud.Decrypt(oRow("CCExpiration"), "test")
                            // oRow("CCExpiration") = newvalueExpDate
                            catch (Exception ex)
                            {

                            }

                        }
                    }
                }
            }
        }

        return isHeld;

    }

    internal static void UpdateCurrentlyHeld(string empName, long expNum)
    {

        SqlClient.SqlCommand cmd;

        cmd = new SqlClient.SqlCommand("UPDATE ExperienceTable SET CurrentlyHeld = @CurrentlyHeld WHERE ExperienceNumber = @ExperienceNumber", sql.cn);

        cmd.Parameters.Add(new SqlClient.SqlParameter("@ExperienceNumber", SqlDbType.BigInt, 8));
        cmd.Parameters("@ExperienceNumber").Value = expNum;

        cmd.Parameters.Add(new SqlClient.SqlParameter("@CurrentlyHeld", SqlDbType.NVarChar, 50));
        if (empName != default)
        {
            cmd.Parameters("@CurrentlyHeld").Value = empName;
        }
        else
        {
            cmd.Parameters("@CurrentlyHeld").Value = DBNull.Value;
        }

        cmd.ExecuteNonQuery();

    }

    internal static void UpdateCurrentlyHeldOnRelease(string empName, long expNum, short itemsOnHold)
    {

        SqlClient.SqlCommand cmd;

        cmd = new SqlClient.SqlCommand("UPDATE ExperienceTable SET CurrentlyHeld = @CurrentlyHeld, ItemsOnHold = @ItemsOnHold WHERE ExperienceNumber = @ExperienceNumber", sql.cn);

        cmd.Parameters.Add(new SqlClient.SqlParameter("@ExperienceNumber", SqlDbType.BigInt, 8));
        cmd.Parameters("@ExperienceNumber").Value = expNum;

        cmd.Parameters.Add(new SqlClient.SqlParameter("@CurrentlyHeld", SqlDbType.NVarChar, 50));
        if (empName != default)
        {
            cmd.Parameters("@CurrentlyHeld").Value = empName;
        }
        else
        {
            cmd.Parameters("@CurrentlyHeld").Value = DBNull.Value;
        }

        cmd.Parameters.Add(new SqlClient.SqlParameter("@ItemsOnHold", SqlDbType.SmallInt, 2));
        cmd.Parameters("@ItemsOnHold").Value = itemsOnHold;

        cmd.ExecuteNonQuery();

    }


    internal static void TransferTableToOpenOrder(int empID, long expNum, int newStatus)
    {

        DataRow oRow;
        DataRow bRow;
        bool RemainingChecks;

        // **********not sure

        // ?????        If RemainingChecks = False Then
        // place a 1 or 9 in LastStatus in ExperienceTable

        // If currentTerminal.TermMethod = "Quick" Or currentTable.TicketNumber > 0 Then
        // For Each oRow In dsOrder.Tables("QuickTickets").Rows

        if (currentTable.IsTabNotTable == true)
        {
            foreach (DataRow currentORow in dsOrder.Tables("AvailTabs").Rows)
            {
                oRow = currentORow;
                if (oRow("ExperienceNumber") == expNum)
                {
                    if (newStatus == 1)                            // not sure what this is for??   
                    {
                    }
                    // if = 1 then must meet extra criteria
                    else    // new status <> 1 (making active from transfer)
                    {
                        oRow("LastStatusTime") = DateTime.Now;
                        oRow("LastStatus") = newStatus;
                    }
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
                    if (newStatus == 1)
                    {
                    }
                    // if = 1 then must meet extra criteria
                    else    // new status <> 1 (making active from transfer)
                    {
                        oRow("LastStatusTime") = DateTime.Now;
                        oRow("LastStatus") = newStatus;

                    }
                }
            }
        }
        // End If

        // sss      SaveAvailTabsAndTables()
        // 222  AddStatusChangeData(currentTable.ExperienceNumber, 2, Nothing, 0, Nothing)

    }

    internal static object CopyViewForTransferItem(DataRowView oldRow, int empID, long expNum, bool isTransferedItem, int checkNum)
    {
        // for changing customer during order
        // this could be used for any transfer

        // *** need to update

        var currentItem = new SelectedItemDetail();


        currentItem.ExperienceNumber = expNum;  // this will be different if xFer Table
        if (object.ReferenceEquals(oldRow("OrderNumber"), DBNull.Value))
        {
            currentItem.OrderNumber = (object)null;
        }
        else
        {
            currentItem.OrderNumber = oldRow("OrderNumber");
        }
        if (object.ReferenceEquals(oldRow("MenuID"), DBNull.Value))
        {
            currentItem.MenuID = currentTable.CurrentMenu;
        }
        else
        {
            currentItem.MenuID = oldRow("MenuID");
        }
        currentItem.ShiftID = oldRow("ShiftID");
        currentItem.EmployeeID = empID;

        if (checkNum != default)
        {
            currentItem.Check = checkNum;
        }
        else
        {
            currentItem.Check = oldRow("CheckNumber");
        }
        currentItem.Customer = oldRow("CustomerNumber");
        currentItem.Course = oldRow("CourseNumber");

        if (isTransferedItem == true)
        {
            currentItem.SIN = oldRow("sin") + 8000000;  // currentTable.SIN
            currentItem.SII = oldRow("sii") + 8000000;  // currentTable.ReferenceSIN
            currentItem.si2 = oldRow("si2");
        }
        else if (oldRow("sin") < 8000000)
        {
            currentItem.SIN = currentTable.SIN;     // oldRow("sin") +
            currentItem.SII = currentTable.ReferenceSIN;    // oldRow("sii") +
            currentItem.si2 = oldRow("si2");
        }
        else
        {
            currentItem.SIN = oldRow("sin") + 10000;    // add smaller amount so no duplicates of transfered items
            currentItem.SII = oldRow("sii") + 10000;
            currentItem.si2 = oldRow("si2");
        }
        // If oldRow("sin") < 1000000 And isTransferedItem = True Then
        // .SIN = oldRow("sin") + 9000000  'currentTable.SIN
        // .SII = oldRow("sii") + 9000000  'currentTable.ReferenceSIN
        // .si2 = oldRow("si2")
        // Else
        // .SIN = oldRow("sin") + 1000000
        // .SII = oldRow("sii") + 1000000
        // .si2 = oldRow("si2")
        // '        End If

        currentItem.Quantity = oldRow("Quantity");
        currentItem.ID = oldRow("ItemID");
        currentItem.ItemStatus = oldRow("ItemStatus");
        currentItem.Name = oldRow("ItemName");
        currentItem.TerminalName = oldRow("TerminalName");
        currentItem.ChitName = oldRow("ChitName");
        currentItem.ItemPrice = oldRow("ItemPrice");
        currentItem.Price = oldRow("Price");
        currentItem.TaxPrice = oldRow("TaxPrice");
        currentItem.SinTax = oldRow("SinTax");
        currentItem.TaxID = oldRow("TaxID");
        // these may be DBNull... keep these catches
        if (object.ReferenceEquals(oldRow("ForceFreeID"), DBNull.Value))
        {
            currentItem.ForceFreeID = (object)null;
        }
        else
        {
            currentItem.ForceFreeID = oldRow("ForceFreeID");
        }
        if (object.ReferenceEquals(oldRow("ForceFreeAuth"), DBNull.Value))
        {
            currentItem.ForceFreeAuth = (object)null;
        }
        else
        {
            currentItem.ForceFreeAuth = oldRow("ForceFreeAuth");
        }
        if (object.ReferenceEquals(oldRow("ForceFreeCode"), DBNull.Value))
        {
            currentItem.ForceFreeCode = (object)null;
        }
        else
        {
            currentItem.ForceFreeCode = oldRow("ForceFreeCode");
        }
        currentItem.FunctionID = oldRow("FunctionID");
        currentItem.FunctionGroup = oldRow("FunctionGroupID");
        currentItem.FunctionFlag = oldRow("FunctionFlag");
        currentItem.Category = oldRow("CategoryID");
        currentItem.FoodID = oldRow("FoodID");
        currentItem.DrinkCategoryID = oldRow("DrinkCategoryID");
        currentItem.DrinkID = oldRow("DrinkID");
        currentItem.RoutingID = oldRow("RoutingID");
        currentItem.PrintPriorityID = oldRow("PrintPriorityID");
        currentItem.TerminalID = oldRow("TerminalID");


        currentTable.SIN += 1;

        PopulateDataRowForOpenOrderFromTransfer(ref currentItem);
        return default;

    }

    internal static void SaveOpenOrderData()
    {

        currentTable.ItemsOnHold = CountItemsOnHold();

        string newvalueAcct;
        string newvalueExpDate;

        foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                // If oRow("PaymentTypeID") > 1 Then
                if (oRow("PaymentFlag") == "cc" | oRow("PaymentFlag") == "Gift" | oRow("PaymentFlag") == "Issue")
                {

                    if (!(oRow("AccountNumber").Substring(0, 4) == "xxxx") & !(oRow("AccountNumber") == "Manual"))
                    {
                        if (oRow("AccountNumber").ToString.Length < 20)
                        {
                            newvalueAcct = CryOutloud.Encrypt(oRow("AccountNumber"), "test");
                            if (newvalueAcct.Length > 50)
                            {
                                // this will create an incorrect account number
                                Interaction.MsgBox("Account Number will be truncated");
                                newvalueAcct = newvalueAcct.Substring(0, 50);
                            }
                            oRow("AccountNumber") = newvalueAcct;
                        }


                        // can't encrypt exp date b/c database only holds 4 chars
                        // newvalueExpDate = CryOutloud.Encrypt(oRow("CCExpiration"), "test")
                        // oRow("CCExpiration") = newvalueExpDate

                        // MsgBox(oRow("AccountNumber"))
                        // MsgBox(newvalueAcct.Length)

                        // Dim newvalue2 As String
                        // newvalue2 = CryOutloud.Decrypt(newvalue, "test")
                        // MsgBox(newvalue2)

                    }
                }
            }
        }

        if (typeProgram == "Online_Demo")
        {

            dsOrderDemo.Merge(dsOrder.Tables("OpenOrders"), false, MissingSchemaAction.Add);
            dsOrderDemo.Merge(dsOrder.Tables("PaymentsAndCredits"), false, MissingSchemaAction.Add);
            dsOrderDemo.Merge(dsOrder.Tables("OrderDetail"), false, MissingSchemaAction.Add);
            // dsOrderDemo.Merge(dsOrder.Tables("CurrentlyHeld"), False, MissingSchemaAction.Add)

            if (currentTerminal.TermMethod == "Quick" | currentTable.TicketNumber > 0)   // = -888 Then
            {
                dsOrderDemo.Merge(dsOrder.Tables("QuickTickets"), false, MissingSchemaAction.Add);
            }
            else if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
            {
                if (currentTable.IsTabNotTable == false)
                {
                    dsOrderDemo.Merge(dsOrder.Tables("AvailTables"), false, MissingSchemaAction.Add);
                }
                else
                {
                    dsOrderDemo.Merge(dsOrder.Tables("AvailTabs"), false, MissingSchemaAction.Add);
                }
            }
            return;
        }


        // MergeNewOpenOrdersToTerminalBackup()
        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlDataAdapterOpenOrdersSP.Update(dsOrder, "OpenOrders");
            sql.SqlDataAdapterPayments.Update(dsOrder, "PaymentsAndCredits");
            // sql.SqlDataAdapterESC.Update(dsOrder, "StatusChange")
            sql.SqlDataAdapterOrderDetail.Update(dsOrder, "OrderDetail");    // only for delivered status
            SaveAvailTabsAndTables();
            UpdateCurrentlyHeldOnRelease(default, currentTable.ExperienceNumber, currentTable.ItemsOnHold);
            // sql.SqlDataAdapterCurrentlyHeld.Update(dsOrder, "CurrentlyHeld")
            sql.cn.Close();

            dsOrder.AcceptChanges(); // need this so we don't repopulate Terminal Data with previous changes
        }
        // we clear datasets when new table is populated
        // keeping full in case we write code to pul up order right after we close 
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
            try
            {
                dsOrder.Tables("PaymentsAndCredits").WriteXml(@"c:\Data Files\spiderPOS\PaymentError'" + currentTable.TruncatedExpNum + "'.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception ex2)
            {
            }
            ServerJustWentDown();
            // MarkBackupAsNOTRecorded()
        }


    }


    internal static void SaveOpenOrderDataExceptQuick()
    {

        // currentTable.ItemsOnHold = CountItemsOnHold()

        dsOrderDemo.Merge(dsOrder.Tables("OpenOrders"), false, MissingSchemaAction.Add);
        dsOrderDemo.Merge(dsOrder.Tables("PaymentsAndCredits"), false, MissingSchemaAction.Add);
        dsOrderDemo.Merge(dsOrder.Tables("OrderDetail"), false, MissingSchemaAction.Add);
        // dsOrderDemo.Merge(dsOrder.Tables("CurrentlyHeld"), False, MissingSchemaAction.Add)

    }




    private static object CountItemsOnHold()
    {
        int itemsHoldCount = 0;

        foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("sin") == oRow("sii"))
                {
                    if (oRow("ItemStatus") == 1)
                    {
                        itemsHoldCount += 1;
                    }
                }
            }
        }
        return itemsHoldCount;

    }

    internal static void ReleaseWithoutSaving()
    {


        if (typeProgram == "Online_Demo")
        {

            dsOrder.Tables("OpenOrders").RejectChanges();
            dsOrder.Tables("PaymentsAndCredits").RejectChanges();
            dsOrder.Tables("OrderDetail").RejectChanges();

            dsOrderDemo.Merge(dsOrder.Tables("OpenOrders"), false, MissingSchemaAction.Add);
            dsOrderDemo.Merge(dsOrder.Tables("PaymentsAndCredits"), false, MissingSchemaAction.Add);
            dsOrderDemo.Merge(dsOrder.Tables("OrderDetail"), false, MissingSchemaAction.Add);
            // dsOrderDemo.Merge(dsOrder.Tables("CurrentlyHeld"), False, MissingSchemaAction.Add)

            return;
        }

        try
        {
            if (currentTable is not null)
            {
                sql.cn.Open();
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                UpdateCurrentlyHeld(default, currentTable.ExperienceNumber);
                sql.cn.Close();
            }
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
            ServerJustWentDown();
        }

    }

    internal static void SaveOrderDetailData222()
    {

        // MergeNewOpenOrdersToTerminalBackup()

        if (mainServerConnected == true)
        {

            try
            {
                sql.cn.Open();
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                sql.SqlDataAdapterOrderDetail.Update(dsOrder, "OrderDetail");
                sql.cn.Close();
            }

            catch (Exception ex)
            {
                CloseConnection();
                Interaction.MsgBox(ex.Message);

                ServerJustWentDown();
                // MarkBackupAsNOTRecorded()
            }
        }
        else
        {
            // MarkBackupAsNOTRecorded()
        }

        // dsOrder.AcceptChanges() ' need this so we don't repopulate Terminal Data with previous changes

    }

    internal static object PopulateMenu(bool fromStart) // fromStart may be temp
    {
        Menu currentMenu;
        Menu secondaryMenu;
        DataSet_Builder.Information_UC info;
        bool isDataBaseConnected;

        try
        {
            TempConnectToPhoenix();

            // isDataBaseConnected = CheckingDatabaseConection()
            // If isDataBaseConnected = False Then
            // ConnectBackFromTempDatabase()
            // MsgBox("Connection to Phoenix Down")
            // Return False
            // Exit Function
            // Else
            // mainCategoryIDArrayList.Clear()
            // ds.Clear()
            // End If

            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            if (tablesFilled == false)
            {
                mainCategoryIDArrayList.Clear();
                ds.Clear(); // not sure if we want to clear, this may hurt table structure
                PopulateLocationOpening(true);
                PopulateMenuSupport();
                PopulateNONOrderTables();
                PopulateTerminalData();
                PopulateEmployeeData();
                PopulateAllEmployeeColloection();
                if (fromStart == true)
                {
                    CreateTerminals();
                }

            }

            if (fromStart == false)
            {
                currentMenu = new Menu(currentTerminal.primaryMenuID, true);
                if (currentTerminal.secondaryMenuID > 0)
                {
                    secondaryMenu = new Menu(currentTerminal.secondaryMenuID, false);
                }
                currentTerminal.DailyDate = DateTime.Now;
            }

            sql.cn.Close();
            ConnectBackFromTempDatabase();

            // If fromStart = True Then
            // CreateTerminals()
            // End If

            return true;
        }

        catch (Exception ex)
        {
            // nned to reload the primary menu from XML
            CloseConnection();
            Interaction.MsgBox(ex.Message + " Error in Populating Menu");
            ConnectBackFromTempDatabase();
            return false;

        }

    }

    internal static void ReleaseCurrentlyHeld()
    {

        if (typeProgram == "Online_Demo")
        {
            return;
        }

        try
        {
            if (dsOrder.Tables("CurrentlyHeld").Rows.Count == 1)
            {
                if (!object.ReferenceEquals(dsOrder.Tables("CurrentlyHeld").Rows(0)("CurrentlyHeld"), DBNull.Value))
                {
                    dsOrder.Tables("CurrentlyHeld").Rows(0)("CurrentlyHeld") = DBNull.Value;
                }
            }
        }
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);
        }

    }

    private static void MarkBackupAsNOTRecorded222()
    {
        DataRow bRow;
        var terminalData = new DataView();
        int ri;

        terminalData.Table = dsBackup.Tables("OpenOrdersTerminal");          // dtOpenOrdersTerminal '
        terminalData.RowFilter = "ExperienceNumber = '" + currentTable.ExperienceNumber + "'";
        terminalData.Sort = "sin";

        foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
        {
            // **** not sure about the catch below
            if (oRow.RowState == DataRowState.Added)
            {
                ri = terminalData.Find(oRow("sin"));
                if (!(ri == -1))
                {
                    terminalData[ri]("dbUP") = 0;
                }
            }
            else if (oRow.RowState == DataRowState.Modified)
            {
                if (oRow("dbUP") == 1)
                {
                    ri = terminalData.Find(oRow("sin"));
                    if (!(ri == -1))
                    {
                        terminalData[ri]("dbUP") = 2;
                    }
                }
            }
        }

    }

    internal static void SaveESCStatusChangeData222(int status, long orderNumber, bool isMainCourse, decimal avgDollar)
    {

        // Try
        // sql.cn.Open()
        // sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery()
        // sql.SqlDataAdapterESC.Update(dsOrder.Tables("StatusChange"))
        // sql.cn.Close()
        // '     Catch ex As Exception'
        // CloseConnection() '
        // End Try

    }

    internal static void TerminalAddStatusChangeData222(int status, int orderNumber, bool isMainCourse, decimal avgDollar)
    {
        // *************************
        // adding directly after we save, so if down we will know

        DataRow bRow = dsBackup.Tables("ESCTerminal").NewRow;

        bRow("CompanyID") = companyInfo.CompanyID;
        bRow("LocationID") = companyInfo.LocationID;
        bRow("DailyCode") = currentTerminal.CurrentDailyCode;
        // bRow("ExperienceStatusChangeID") = 
        bRow("ExperienceNumber") = currentTable.ExperienceNumber;
        bRow("StatusTime") = DateTime.Now;
        bRow("TableStatusID") = status;
        if (orderNumber == 0)
        {
            bRow("OrderNumber") = -1;          // will auto fill when db comes back up
        }
        else
        {
            bRow("OrderNumber") = orderNumber;
        }
        bRow("IsMainCourse") = isMainCourse;
        bRow("AverageDollar") = avgDollar;
        bRow("TerminalID") = currentTerminal.TermID;
        if (mainServerConnected == false)
        {
            bRow("dbUP") = 0;
        }
        else
        {
            bRow("dbUP") = 1;
        }

        dsBackup.Tables("ESCTerminal").Rows.Add(bRow);

    }

    internal static void CloseConnection()
    {
        if (sql.cn.State == ConnectionState.Open)
        {
            sql.cn.Close();
        }
        connectionDown = true;

    }


    internal static void CompThisItem(ItemPromoInfo iPromo)
    {

        var currentItem = new SelectedItemDetail();
        currentItem.SIN = currentTable.SIN;
        currentItem.SII = iPromo.sii;   // oRow("sii")
        currentItem.si2 = iPromo.si2;   // oRow("si2")
        currentItem.Name = iPromo.PromoName;
        currentItem.TerminalName = iPromo.PromoName;
        currentItem.ChitName = iPromo.PromoName;

        if (iPromo.OrderNumber == default)
        {
            currentItem.OrderNumber = (object)null;
        }
        else
        {
            currentItem.OrderNumber = iPromo.OrderNumber;
        }
        currentItem.Check = iPromo.CheckNumber;
        currentItem.Customer = iPromo.CustomerNumber;
        currentItem.Course = iPromo.CourseNumber;



        // the next 3 are the DISCOUNT
        // the reason they are lifted directly is its COMP'd
        if (iPromo.Quantity == default)
        {
            currentItem.Quantity = 0;
        }
        else
        {
            currentItem.Quantity = iPromo.Quantity;
        }
        if (iPromo.InvMultiplier == default)
        {
            currentItem.InvMultiplier = 1;
        }
        else
        {
            currentItem.InvMultiplier = iPromo.InvMultiplier;
        }
        if (iPromo.ItemID == default)
        {
            currentItem.ID = -1;
        }
        else
        {
            currentItem.ID = iPromo.ItemID;
        }
        currentItem.ItemPrice = Strings.Format(iPromo.ItemPrice, "##,###.00");
        currentItem.TaxID = iPromo.taxID;
        currentItem.Price = Strings.Format(iPromo.Price * -1, "##,###.00");
        currentItem.TaxPrice = iPromo.TaxPrice * -1;
        currentItem.SinTax = iPromo.SinTax * -1;

        currentItem.FunctionID = iPromo.FunctionID;
        currentItem.FunctionGroup = iPromo.FunctionGroup;
        currentItem.FunctionFlag = iPromo.FunctionFlag;

        if (currentItem.FunctionFlag == "F" | currentItem.FunctionFlag == "O" | currentItem.FunctionFlag == "M")
        {
            currentItem.Category = iPromo.CategoryID;
            currentItem.FoodID = iPromo.FoodID;
        }
        else if (currentItem.FunctionFlag == "D")
        {
            currentItem.Category = iPromo.DrinkCategoryID;
            currentItem.FoodID = iPromo.DrinkID;
        }
        else if (currentItem.FunctionFlag == "P")
        {
            currentItem.Category = 0; // iPromo.DrinkCategoryID
            currentItem.FoodID = 0; // iPromo.DrinkID
        }
        // we do not use DrinkCatID, we use general ID 
        // then go by Function
        // .DrinkCategoryID = iPromo.DrinkCategoryID
        // .DrinkID = iPromo.DrinkID

        currentItem.RoutingID = iPromo.RoutingID;
        currentItem.PrintPriorityID = iPromo.PrintPriorityID;

        currentItem.ForceFreeID = iPromo.PromoCode;
        currentItem.ForceFreeAuth = iPromo.empID;
        if (iPromo.PromoReason > 0)
        {
            // temp coding voids as mistakes
            currentItem.ForceFreeCode = iPromo.PromoReason;
        }
        else
        {
            currentItem.ForceFreeCode = 9;
        }
        currentItem.ItemStatus = iPromo.ItemStatus;
        currentTable.SIN += 1;
        newItemCollection.Add(currentItem);


        // Dim ffInfo As ForceFreeInfo

        // ffInfo = New ForceFreeInfo
        // ffInfo.DailyCode = currentTerminal.CurrentDailyCode
        // ffInfo.ExpNum = currentTable.ExperienceNumber
        // ffInfo.OpenOrderID = iPromo.openOrderID 'oRow("OpenOrderID")
        // ffInfo.AuthID = iPromo.empID
        // '     ffInfo.Price = 0
        // ffInfo.TaxID = iPromo.taxID ' oRow("TaxID")
        // ffInfo.TaxPrice = 0
        // '    ffInfo.CompID = iPromo.PromoCode   'can letter choose from list of reasons
        // ffInfo.CompPrice = iPromo.Price
        // '    ffInfo.AmountDiscount = iPromo.Price
        // ffInfo.TaxDicount = iPromo.TaxPrice + iPromo.SinTax
        // ffInfo.ffID = GenerateOrderTables.CreateNewOrderForceFree(ffInfo)

    }

    internal static void PopulateDataRowForOpenOrder(ref SelectedItemDetail newItem)
    {

        try
        {
            DataRow oRow = dsOrder.Tables("OpenOrders").NewRow;

            PerformOpenOrdersAdd(ref newItem, ref oRow);
            if (typeProgram == "Online_Demo")
            {
                oRow("OpenOrderID") = demoOpenOrdersID;
                demoOpenOrdersID += 1;
            }
            dsOrder.Tables("OpenOrders").Rows.Add(oRow);
            if (currentTable.EmptyCustPanel == currentTable.CustomerNumber)
            {
                currentTable.EmptyCustPanel = 0;
            }
        }


        // Dim bRow As DataRow = dsBackup.Tables("OpenOrdersTerminal").NewRow
        // PerformOpenOrdersAdd(newItem, bRow)
        // dsBackup.Tables("OpenOrdersTerminal").Rows.Add(bRow)

        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);

        }

        // trying to adjust OpenOrderCurrencuyMan to reflect just ordered main item
        // If newItem.SIN = newItem.SII Then
        // OpenOrdersCurrencyMan.Position = dsOrder.Tables("OpenOrders").R
        // Me.testgridview.gridViewOrder.ScrollToRow(OpenOrdersCurrencyMan.Position)
        // End If


    }

    private static void PerformOpenOrdersAdd(ref SelectedItemDetail newitem, ref DataRow dr)
    {

        int taxID;
        decimal taxPrice;
        decimal sinTax;

        if (newitem.TaxID == default | newitem.TaxID == 0)
        {
            taxID = Conversions.ToInteger(DetermineTaxID(newitem.FunctionID));
        }
        else
        {
            taxID = newitem.TaxID;
        }
        taxPrice = Conversions.ToDecimal(DetermineTaxPrice(taxID, newitem.Price));
        sinTax = Conversions.ToDecimal(DetermineSinTax(taxID, newitem.Price));

        dr("CompanyID") = companyInfo.CompanyID;
        dr("LocationID") = companyInfo.LocationID;
        dr("DailyCode") = currentTable.DailyCode;
        dr("ExperienceNumber") = currentTable.ExperienceNumber;
        if (newitem.OrderNumber == default)
        {
            dr("OrderNumber") = DBNull.Value;
        }
        else
        {
            dr("OrderNumber") = newitem.OrderNumber;
        }
        if (newitem.MenuID == default)
        {
            dr("MenuID") = currentTable.CurrentMenu;
        }
        else
        {
            dr("MenuID") = newitem.MenuID;
        }
        if (currentTerminal.CurrentShift == default) // currentServer.ShiftID = Nothing Then
        {
            dr("ShiftID") = 0;
        }
        else
        {
            dr("ShiftID") = currentTerminal.CurrentShift;
        }

        if (newitem.EmployeeID == default)
        {
            dr("EmployeeID") = currentTable.EmployeeID;
        }
        else
        {
            dr("EmployeeID") = newitem.EmployeeID;
        }
        dr("CheckNumber") = newitem.Check;
        dr("CustomerNumber") = newitem.Customer;
        dr("CourseNumber") = newitem.Course;
        dr("sin") = newitem.SIN;
        dr("sii") = newitem.SII;
        dr("si2") = newitem.si2;
        if (newitem.Quantity == default)
        {
            dr("Quantity") = 1;
        }
        else
        {
            dr("Quantity") = newitem.Quantity;
        }
        if (newitem.Voiding == true)
        {
            dr("ItemID") = -9;
            dr("itemStatus") = 9;           // *** changed from -9
        }
        else
        {
            dr("ItemID") = newitem.ID;
            if (newitem.ItemStatus > 0)
            {
                dr("itemStatus") = newitem.ItemStatus;
            }
            else
            {
                dr("itemStatus") = 0;
            }
        }
        dr("ItemName") = newitem.Name;
        dr("TerminalName") = newitem.TerminalName;
        dr("ChitName") = newitem.ChitName;

        if (newitem.ItemPrice == default)
        {
            dr("ItemPrice") = Strings.Format(newitem.Price, "###,##0.00");
        }
        else
        {
            dr("ItemPrice") = Strings.Format(newitem.ItemPrice, "###,##0.00");
        }
        dr("Price") = Strings.Format(newitem.Price, "###,##0.00");
        if (newitem.TaxPrice == default)
        {
            dr("TaxPrice") = taxPrice;
        }
        else
        {
            dr("TaxPrice") = newitem.TaxPrice;
        }
        if (newitem.SinTax == default)
        {
            dr("SinTax") = sinTax;
        }
        else
        {
            dr("SinTax") = newitem.SinTax;
        }
        dr("TaxID") = taxID;       // newItem.TaxID
        if (newitem.ForceFreeID != default)
        {
            dr("ForceFreeID") = newitem.ForceFreeID;
        }
        else
        {
            dr("ForceFreeID") = 0;
        }
        if (newitem.ForceFreeAuth != default)
        {
            dr("ForceFreeAuth") = newitem.ForceFreeAuth;
        }
        else
        {
            dr("ForceFreeAuth") = 0;
        }
        if (newitem.ForceFreeCode != default)
        {
            dr("ForceFreeCode") = newitem.ForceFreeCode;
        }
        else
        {
            dr("ForceFreeCode") = 0;
        }
        if (newitem.FunctionFlag == "F" | newitem.FunctionFlag == "O" | newitem.FunctionFlag == "M")  // newitem.FunctionID = 1 Or newitem.FunctionID = 2 Or newitem.FunctionID = 3 Then
        {
            dr("CategoryID") = newitem.Category;
            dr("FoodID") = newitem.ID;
            dr("DrinkID") = 0;
            dr("DrinkCategoryID") = 0;
        }
        else if (newitem.FunctionFlag == "D") // newitem.FunctionID >= 4 And newitem.FunctionID <= 7 Then
        {
            dr("DrinkCategoryID") = newitem.Category;
            if (newitem.FunctionGroup == 11)
            {
                // this is for Drink Preps, we record these differntly
                dr("DrinkID") = newitem.DrinkID;
            }
            else
            {
                dr("DrinkID") = newitem.ID;
            }
            dr("FoodID") = 0;
            dr("CategoryID") = 0;
        }
        // *** ??? below do we use funFlag ???
        else if (newitem.FunctionID == 0 | newitem.FunctionFlag == "N")
        {
            dr("FoodID") = 0;
            dr("DrinkID") = 0;
            dr("CategoryID") = 0;
            dr("DrinkCategoryID") = 0;
        }
        dr("FunctionID") = newitem.FunctionID;
        dr("FunctionGroupID") = newitem.FunctionGroup;
        dr("FunctionFlag") = newitem.FunctionFlag;    // at this point not keeping Flag
        if (newitem.SIN == newitem.SII)
        {
            dr("RoutingID") = newitem.RoutingID;
            currentTable.ReferenceRouting = newitem.RoutingID;
        }
        else if (newitem.RoutingID == 0 | newitem.RoutingID == default)
        {
            dr("RoutingID") = currentTable.ReferenceRouting;
        }
        else
        {
            dr("RoutingID") = newitem.RoutingID;
        }
        dr("PrintPriorityID") = newitem.PrintPriorityID;
        // dr("BlankValue") = 0
        if (newitem.FunctionFlag == "D") // newitem.FunctionID >= 4 And newitem.FunctionID <= 7 Then
        {
            dr("Repeat") = 1;
        }
        else
        {
            dr("Repeat") = 0;
        }
        dr("TerminalID") = currentTerminal.TermPrimaryKey;
        dr("dbUP") = 1;

        // this is InvMultiplier
        dr("OpenDecimal1") = newitem.InvMultiplier;

    }

    internal static void PopulateDataRowForOpenOrderFromTransfer(ref SelectedItemDetail newItem)
    {


        try
        {
            DataRow oRow = dsOrder.Tables("OpenOrders").NewRow;
            PerformOpenOrdersAddFromTransfer(ref newItem, ref oRow);
            if (typeProgram == "Online_Demo")
            {
                oRow("OpenOrderID") = demoOpenOrdersID;
                demoOpenOrdersID += 1;
            }
            dsOrder.Tables("OpenOrders").Rows.Add(oRow);
            if (currentTable.EmptyCustPanel == currentTable.CustomerNumber)
            {
                currentTable.EmptyCustPanel = 0;
            }
        }
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);
        }

    }

    private static void PerformOpenOrdersAddFromTransfer(ref SelectedItemDetail newitem, ref DataRow dr)
    {

        dr("CompanyID") = companyInfo.CompanyID;
        dr("LocationID") = companyInfo.LocationID;
        dr("DailyCode") = currentTable.DailyCode;
        dr("ExperienceNumber") = newitem.ExperienceNumber;
        if (newitem.OrderNumber == default)
        {
            dr("OrderNumber") = DBNull.Value;
        }
        else
        {
            dr("OrderNumber") = newitem.OrderNumber;
        }
        dr("MenuID") = newitem.MenuID;
        dr("ShiftID") = newitem.ShiftID;
        dr("EmployeeID") = newitem.EmployeeID;
        dr("CheckNumber") = newitem.Check;
        dr("CustomerNumber") = newitem.Customer;
        dr("CourseNumber") = newitem.Course;
        dr("sin") = newitem.SIN;
        dr("si2") = newitem.si2;
        dr("sii") = newitem.SII;
        dr("Quantity") = newitem.Quantity;
        dr("ItemID") = newitem.ID;
        dr("itemStatus") = newitem.ItemStatus;
        dr("ItemName") = newitem.Name;
        dr("TerminalName") = newitem.TerminalName;
        dr("ChitName") = newitem.ChitName;
        dr("ItemPrice") = Strings.Format(newitem.Price, "###,##0.00");
        dr("Price") = Strings.Format(newitem.Price, "###,##0.00");
        dr("TaxPrice") = newitem.TaxPrice;
        dr("SinTax") = newitem.SinTax;
        dr("TaxID") = newitem.TaxID;
        dr("ForceFreeID") = newitem.ForceFreeID;
        dr("ForceFreeAuth") = newitem.ForceFreeAuth;
        dr("ForceFreeCode") = newitem.ForceFreeCode;
        dr("CategoryID") = newitem.Category;
        dr("FoodID") = newitem.FoodID;
        dr("DrinkCategoryID") = newitem.DrinkCategoryID;
        dr("DrinkID") = newitem.DrinkID;
        dr("FunctionID") = newitem.FunctionID;
        // flag and group are TableJoins
        dr("FunctionGroupID") = newitem.FunctionGroup;
        dr("FunctionFlag") = newitem.FunctionFlag;    // at this point not keeping Flag
        dr("RoutingID") = newitem.RoutingID;     // routing different in reg perform OO add
        dr("PrintPriorityID") = newitem.PrintPriorityID;
        // dr("BlankValue") = 0
        dr("Repeat") = 0;        // always for transfers or voids
        dr("TerminalID") = currentTerminal.TermPrimaryKey;
        dr("dbUP") = 1;

    }

    private static void MergeNewOpenOrdersToTerminalBackup222()
    {
        DataRow bRow;
        DataRow pRow;
        var terminalData = new DataView();
        int ri;
        SelectedItemDetail modifiedItem;

        // we do this every time we SaveOpenOrderData
        // ***
        // If dsBackup.Tables("OpenOrdersTerminal").Rows.Count > 0 Then
        terminalData.Table = dsBackup.Tables("OpenOrdersTerminal");      // dtOpenOrdersTerminal       ' 
        terminalData.RowFilter = "ExperienceNumber = '" + currentTable.ExperienceNumber + "'";
        terminalData.Sort = "sin";
        // End If

        foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
        {

            if (oRow.RowState == DataRowState.Added)
            {
                bRow = dsBackup.Tables("OpenOrdersTerminal").NewRow;
                CopyOneRowToAnotherOpenOrders222(oRow, ref bRow);
                dsBackup.Tables("OpenOrdersTerminal").Rows.Add(bRow);
            }

            else if (oRow.RowState == DataRowState.Modified)
            {
                ri = terminalData.Find(oRow("sin"));
                if (!(ri == -1))
                {
                    var tmp = terminalData;
                    var argnewRow = tmp[ri];
                    CopyOneRowToViewOpenOrders222(oRow, ref argnewRow);
                }
            }

            else if (oRow.RowState == DataRowState.Deleted)
            {
            }
            // we are deleting when we delete regular oRow in  DeleteOpenOrdersRow
            // ri = terminalData.Find(oRow("sin"))
            // If Not ri = -1 Then
            // terminalData.Delete(ri)
            // End If

            else if (oRow.RowState == DataRowState.Detached)
            {
                // do nothing .. row was never added
                // this is when we added a row but then decided to delete
            }
        }
    }

    internal static object CopyOneRowToAnotherExpStatusChange(DataRow oldRow, ref DataRow newRow)
    {

        newRow("CompanyID") = oldRow("CompanyID");
        newRow("LocationID") = oldRow("LocationID");
        newRow("DailyCode") = oldRow("DailyCode");
        newRow("ExperienceStatusChangeID") = oldRow("ExperienceStatusChangeID");
        newRow("ExperienceNumber") = oldRow("ExperienceNumber");
        newRow("StatusTime") = oldRow("StatusTime");
        if (!object.ReferenceEquals(oldRow("TableStatusID"), DBNull.Value))
        {
            newRow("TableStatusID") = oldRow("TableStatusID");
        }
        else
        {
            newRow("TableStatusID") = 0;
        }
        newRow("OrderNumber") = oldRow("OrderNumber");
        newRow("IsMainCourse") = oldRow("IsMainCourse");
        newRow("AverageDollar") = oldRow("AverageDollar");
        newRow("TerminalID") = oldRow("TerminalID");
        newRow("dbUP") = oldRow("dbUP");

        return newRow;

    }



    internal static object CopyOneRowToAnotherAvailTabsAndTables222(DataRow oldRow, ref DataRow newRow)
    {

        newRow("ExperienceNumber") = oldRow("ExperienceNumber");
        newRow("DailyCode") = oldRow("DailyCode");
        newRow("CompanyID") = oldRow("CompanyID");
        newRow("LocationID") = oldRow("LocationID");
        newRow("ExperienceDate") = oldRow("ExperienceDate");
        if (!object.ReferenceEquals(oldRow("TableNumber"), DBNull.Value))
        {
            // Availtabs does not have TableNumber column 
            newRow("TableNumber") = oldRow("TableNumber");
        }
        newRow("TabID") = oldRow("TabID");
        newRow("TabName") = oldRow("TabName");
        newRow("EmployeeID") = oldRow("EmployeeID");
        newRow("NumberOfCustomers") = oldRow("NumberOfCustomers");
        newRow("NumberOfChecks") = oldRow("NumberOfChecks");
        newRow("ShiftID") = oldRow("ShiftID");                     // ***********  ???????? are we using
        // we use ShiftID in closed tables only right now... we need to add in Avail, open
        newRow("MenuID") = oldRow("MenuID");
        newRow("LastStatus") = oldRow("LastStatus");
        newRow("LastStatusTime") = oldRow("LastStatusTime");
        newRow("ClosedSubTotal") = oldRow("ClosedSubTotal");
        newRow("TerminalID") = oldRow("TerminalID");
        newRow("TicketNumber") = oldRow("TicketNumber");
        newRow("dbUP") = oldRow("dbUP");

        return newRow;

    }

    internal static void CopyOneRowToAnotherOpenOrders222(DataRow oldRow, ref DataRow newRow)
    {
        return;
        // 222
        // **********************
        // this is bad we should never do this
        // we would be resetting OpenOrderID IDENTITY

        newRow("CompanyID") = oldRow("CompanyID");
        newRow("LocationID") = oldRow("LocationID");
        newRow("OpenOrderID") = oldRow("OpenOrderID");
        newRow("DailyCode") = oldRow("DailyCode");
        newRow("ExperienceNumber") = oldRow("ExperienceNumber");
        newRow("OrderNumber") = oldRow("OrderNumber");
        newRow("ShiftID") = oldRow("ShiftID");
        newRow("MenuID") = oldRow("MenuID");
        newRow("EmployeeID") = oldRow("EmployeeID");
        // newRow("TableNumber") = oldRow("TableNumber")
        // newRow("TabID") = oldRow("TabID")
        // newRow("TabName") = oldRow("TabName")
        newRow("CheckNumber") = oldRow("CheckNumber");
        newRow("CustomerNumber") = oldRow("CustomerNumber");
        newRow("CourseNumber") = oldRow("CourseNumber");
        newRow("sin") = oldRow("sin");
        newRow("sii") = oldRow("sii");
        newRow("Quantity") = oldRow("Quantity");
        newRow("ItemID") = oldRow("ItemID");
        newRow("ItemName") = oldRow("ItemName");
        newRow("TerminalName") = oldRow("TerminalName");
        newRow("ChitName") = oldRow("ChitName");
        newRow("ItemPrice") = oldRow("ItemPrice");
        newRow("Price") = oldRow("Price");
        newRow("TaxPrice") = oldRow("TaxPrice");
        // sin tax
        newRow("TaxID") = oldRow("TaxID");
        newRow("ForceFreeID") = oldRow("ForceFreeID");
        newRow("ForceFreeAuth") = oldRow("ForceFreeAuth");
        newRow("ForceFreeCode") = oldRow("ForceFreeCode");
        newRow("FunctionID") = oldRow("FunctionID");
        newRow("FunctionGroupID") = oldRow("FunctionGroupID");
        newRow("FunctionFlag") = oldRow("FunctionFlag");
        newRow("CategoryID") = oldRow("CategoryID");
        newRow("FoodID") = oldRow("FoodID");
        newRow("DrinkCategoryID") = oldRow("DrinkCategoryID");
        newRow("DrinkID") = oldRow("DrinkID");
        newRow("itemStatus") = oldRow("itemStatus");
        newRow("RoutingID") = oldRow("RoutingID");
        newRow("PrintPriorityID") = oldRow("PrintPriorityID");
        newRow("Repeat") = oldRow("Repeat");
        newRow("TerminalID") = oldRow("TerminalID");
        newRow("dbUP") = oldRow("dbUP");


    }

    internal static void CopyOneRowToAnotherPaymentsAndCredits(DataRow oldRow, ref DataRow newRow, int dbUP)
    {


        newRow("PaymentsAndCreditsID") = oldRow("PaymentsAndCreditsID");

        newRow("CompanyID") = oldRow("CompanyID");
        newRow("LocationID") = oldRow("LocationID");
        newRow("DailyCode") = oldRow("DailyCode");
        newRow("ExperienceNumber") = oldRow("ExperienceNumber");
        newRow("EmployeeID") = oldRow("EmployeeID");
        newRow("CheckNumber") = oldRow("CheckNumber");
        newRow("PaymentTypeID") = oldRow("PaymentTypeID");
        newRow("PaymentTypeName") = oldRow("PaymentTypeName");
        newRow("PaymentFlag") = oldRow("PaymentFlag");
        newRow("AccountNumber") = oldRow("AccountNumber");
        newRow("CCExpiration") = oldRow("CCExpiration");
        newRow("Track2") = oldRow("Track2");
        newRow("CustomerName") = oldRow("CustomerName");
        newRow("TransactionType") = oldRow("TransactionType");
        newRow("TransactionCode") = oldRow("TransactionCode");
        newRow("SwipeType") = oldRow("SwipeType");
        newRow("PaymentAmount") = oldRow("PaymentAmount");
        newRow("Tip") = oldRow("Tip");
        newRow("PreAuthAmount") = oldRow("PreAuthAmount");
        newRow("Applied") = oldRow("Applied");
        newRow("RefNum") = oldRow("RefNum");
        newRow("AuthCode") = oldRow("AuthCode");
        newRow("AcqRefData") = oldRow("AcqRefData");
        newRow("TerminalID") = oldRow("TerminalID");
        if (dbUP == -1)
        {
            // when we are pop from terminal data
            newRow("dbUP") = oldRow("dbUP");
        }
        else
        {
            // when we are pop to terminal data
            newRow("dbUP") = dbUP;
        }

    }


    private static void CopyOneRowToViewOpenOrders222(DataRow oldRow, ref DataRowView newRow)
    {
        return;
        // newRow("OpenOrderID") = oldRow("OpenOrderID")
        newRow("CompanyID") = oldRow("CompanyID");
        newRow("LocationID") = oldRow("LocationID");
        newRow("DailyCode") = oldRow("DailyCode");
        newRow("ExperienceNumber") = oldRow("ExperienceNumber");
        newRow("OrderNumber") = oldRow("OrderNumber");
        newRow("ShiftID") = oldRow("ShiftID");
        newRow("MenuID") = oldRow("MenuID");
        newRow("EmployeeID") = oldRow("EmployeeID");
        // newRow("TableNumber") = oldRow("TableNumber")
        // newRow("TabID") = oldRow("TabID")
        // newRow("TabName") = oldRow("TabName")
        newRow("CheckNumber") = oldRow("CheckNumber");
        newRow("CustomerNumber") = oldRow("CustomerNumber");
        newRow("CourseNumber") = oldRow("CourseNumber");
        newRow("sin") = oldRow("sin");
        newRow("sii") = oldRow("sii");
        newRow("Quantity") = oldRow("Quantity");
        newRow("ItemID") = oldRow("ItemID");
        newRow("ItemName") = oldRow("ItemName");
        newRow("Price") = oldRow("Price");
        newRow("TaxPrice") = oldRow("TaxPrice");
        // sin tax
        newRow("TaxID") = oldRow("TaxID");
        newRow("ForceFreeID") = oldRow("ForceFreeID");
        newRow("ForceFreeAuth") = oldRow("ForceFreeAuth");
        newRow("ForceFreeCode") = oldRow("ForceFreeCode");
        newRow("FunctionID") = oldRow("FunctionID");
        newRow("FunctionGroupID") = oldRow("FunctionGroupID");
        newRow("FunctionFlag") = oldRow("FunctionFlag");
        newRow("CategoryID") = oldRow("CategoryID");
        newRow("FoodID") = oldRow("FoodID");
        newRow("DrinkCategoryID") = oldRow("DrinkCategoryID");
        newRow("DrinkID") = oldRow("DrinkID");
        newRow("itemStatus") = oldRow("itemStatus");
        newRow("RoutingID") = oldRow("RoutingID");
        newRow("PrintPriorityID") = oldRow("PrintPriorityID");
        newRow("Repeat") = oldRow("Repeat");
        newRow("TerminalID") = oldRow("TerminalID");
        if (mainServerConnected == true)
        {
            newRow("dbUP") = 1;
        }
        else
        {
            newRow("dbUP") = 0;
        }

        // Return newRow

    }

    internal static void AddItemViewToOpenOrders222(ref DataRowView oRow) // , ByVal empID As Integer, ByVal expNum As Integer)
    {
        return;

        sql.SqlInsertCommandOpenOrdersSP.Parameters("@CompanyID").Value = oRow("CompanyID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@LocationID").Value = oRow("LocationID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@DailyCode").Value = oRow("DailyCode");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@ExperienceNumber").Value = oRow("ExperienceNumber"); // expNum

        sql.SqlInsertCommandOpenOrdersSP.Parameters("@OrderNumber").Value = oRow("OrderNumber");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@ShiftID").Value = oRow("ShiftID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@MenuID").Value = oRow("MenuID");
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@EmployeeID").Value = oRow("EmployeeID");             // empID
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
        sql.SqlInsertCommandOpenOrdersSP.Parameters("@ItemPrice").Value = oRow("ItemPrice");
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

        sql.SqlInsertCommandOpenOrdersSP.ExecuteNonQuery();

    }

    internal static object AddItemViewToAvailTabsAndTables222(ref DataRowView oRow, bool IsTabNotTable)
    {

        long expNum;

        sql.SqlInsertCommandAvailTablesSP.Parameters("@CompanyID").Value = oRow("CompanyID");
        sql.SqlInsertCommandAvailTablesSP.Parameters("@LocationID").Value = oRow("LocationID");
        sql.SqlInsertCommandAvailTablesSP.Parameters("@DailyCode").Value = oRow("DailyCode");
        // sql.SqlInsertCommandAvailTablesSP.Parameters("@ExperienceNumber").Value = oRow("ExperienceNumber") ' expNum
        sql.SqlInsertCommandAvailTablesSP.Parameters("@ExperienceDate").Value = oRow("ExperienceDate");
        sql.SqlInsertCommandAvailTablesSP.Parameters("@TableNumber").Value = oRow("TableNumber");
        sql.SqlInsertCommandAvailTablesSP.Parameters("@TabID").Value = oRow("TabID");
        sql.SqlInsertCommandAvailTablesSP.Parameters("@TabName").Value = oRow("TabName");
        sql.SqlInsertCommandAvailTablesSP.Parameters("@EmployeeID").Value = oRow("EmployeeID");             // empID
        sql.SqlInsertCommandAvailTablesSP.Parameters("@NumberOfCustomers").Value = oRow("NumberOfCustomers");
        sql.SqlInsertCommandAvailTablesSP.Parameters("@NumberOfChecks").Value = oRow("NumberOfChecks");   // ??
        sql.SqlInsertCommandAvailTablesSP.Parameters("@MenuID").Value = oRow("MenuID");
        sql.SqlInsertCommandAvailTablesSP.Parameters("@LastStatus").Value = oRow("LastStatus"); // 9
        sql.SqlInsertCommandAvailTablesSP.Parameters("@LastStatusTime").Value = oRow("LastStatusTime");
        sql.SqlInsertCommandAvailTablesSP.Parameters("@ClosedSubTotal").Value = oRow("ClosedSubTotal");
        sql.SqlInsertCommandAvailTablesSP.Parameters("@TerminalID").Value = oRow("TerminalID");
        sql.SqlInsertCommandAvailTablesSP.Parameters("@TicketNumber").Value = oRow("TicketNumber");
        sql.SqlInsertCommandAvailTablesSP.Parameters("@dbUP").Value = 1;


        expNum = (long)sql.SqlInsertCommandAvailTablesSP.ExecuteScalar;

        return expNum;

    }

    internal static void AddItemViewToESCStatusChange(ref DataRowView oRow)
    {

        sql.SqlInsertCommandESC.Parameters("@CompanyID").Value = oRow("CompanyID");
        sql.SqlInsertCommandESC.Parameters("@LocationID").Value = oRow("LocationID");
        sql.SqlInsertCommandESC.Parameters("@DailyCode").Value = oRow("DailyCode");
        sql.SqlInsertCommandESC.Parameters("@ExperienceNumber").Value = oRow("ExperienceNumber");
        sql.SqlInsertCommandESC.Parameters("@StatusTime").Value = oRow("StatusTime");
        if (!object.ReferenceEquals(oRow("TableStatusID"), DBNull.Value))
        {
            sql.SqlInsertCommandESC.Parameters("@TableStatusID").Value = oRow("TableStatusID");
        }
        else
        {
            sql.SqlInsertCommandESC.Parameters("@TableStatusID").Value = 0;
        }
        sql.SqlInsertCommandESC.Parameters("@OrderNumber").Value = oRow("OrderNumber");
        sql.SqlInsertCommandESC.Parameters("@IsMainCourse").Value = oRow("IsMainCourse");
        sql.SqlInsertCommandESC.Parameters("@AverageDollar").Value = oRow("AverageDollar");
        sql.SqlInsertCommandESC.Parameters("@TerminalID").Value = oRow("TerminalID");
        sql.SqlInsertCommandESC.Parameters("@dbUP").Value = 1;

        sql.SqlInsertCommandESC.ExecuteNonQuery();

    }

    internal static void AddItemViewToPaymentsAndCredits(ref DataRowView oRow)
    {

        sql.SqlInsertCommandPayments.Parameters("@CompanyID").Value = oRow("CompanyID");
        sql.SqlInsertCommandPayments.Parameters("@LocationID").Value = oRow("LocationID");
        sql.SqlInsertCommandPayments.Parameters("@DailyCode").Value = oRow("DailyCode");
        sql.SqlInsertCommandPayments.Parameters("@ExperienceNumber").Value = oRow("ExperienceNumber");
        sql.SqlInsertCommandPayments.Parameters("@EmployeeID").Value = oRow("EmployeeID");
        sql.SqlInsertCommandPayments.Parameters("@CheckNumber").Value = oRow("CheckNumber");
        sql.SqlInsertCommandPayments.Parameters("@PaymentTypeID").Value = oRow("PaymentTypeID");
        sql.SqlInsertCommandPayments.Parameters("@AccountNumber").Value = oRow("AccountNumber");
        sql.SqlInsertCommandPayments.Parameters("@CCExpiration").Value = oRow("CCExpiration");
        sql.SqlInsertCommandPayments.Parameters("@Track2").Value = oRow("Track2");
        sql.SqlInsertCommandPayments.Parameters("@CustomerName").Value = oRow("CustomerName");
        sql.SqlInsertCommandPayments.Parameters("@TransactionType").Value = oRow("TransactionType");
        sql.SqlInsertCommandPayments.Parameters("@TransactionCode").Value = oRow("TransactionCode");
        sql.SqlInsertCommandPayments.Parameters("@SwipeType").Value = oRow("SwipeType");
        sql.SqlInsertCommandPayments.Parameters("@PaymentAmount").Value = oRow("PaymentAmount");
        sql.SqlInsertCommandPayments.Parameters("@Tip").Value = oRow("Tip");
        sql.SqlInsertCommandPayments.Parameters("@PreAuthAmount").Value = oRow("PreAuthAmount");
        sql.SqlInsertCommandPayments.Parameters("@Applied").Value = oRow("Applied");
        sql.SqlInsertCommandPayments.Parameters("@RefNum").Value = oRow("RefNum");
        sql.SqlInsertCommandPayments.Parameters("@AuthCode").Value = oRow("AuthCode");
        sql.SqlInsertCommandPayments.Parameters("@AcqRefData").Value = oRow("AcqRefData");
        sql.SqlInsertCommandPayments.Parameters("@TerminalID").Value = oRow("TerminalID");
        sql.SqlInsertCommandPayments.Parameters("@dbUP").Value = 1;

        sql.SqlInsertCommandESC.ExecuteNonQuery();

    }

    internal static void CreateNewBatch()
    {

    }

    private static void CopyOneViewToRowOpenOrders222(DataRowView oldRow, ref DataRow newRow)
    {

        newRow("OpenOrderID") = oldRow("OpenOrderID");
        newRow("CompanyID") = oldRow("CompanyID");
        newRow("LocationID") = oldRow("LocationID");
        newRow("DailyCode") = oldRow("DailyCode");
        newRow("ExperienceNumber") = oldRow("ExperienceNumber");
        newRow("OrderNumber") = oldRow("OrderNumber");
        newRow("ShiftID") = oldRow("ShiftID");
        newRow("MenuID") = oldRow("MenuID");
        newRow("EmployeeID") = oldRow("EmployeeID");
        newRow("TableNumber") = oldRow("TableNumber");
        newRow("TabID") = oldRow("TabID");
        newRow("TabName") = oldRow("TabName");
        newRow("CheckNumber") = oldRow("CheckNumber");
        newRow("CustomerNumber") = oldRow("CustomerNumber");
        newRow("CourseNumber") = oldRow("CourseNumber");
        newRow("sin") = oldRow("sin");
        newRow("sii") = oldRow("sii");
        newRow("Quantity") = oldRow("Quantity");
        newRow("ItemID") = oldRow("ItemID");
        newRow("ItemName") = oldRow("ItemName");
        newRow("ItemPrice") = oldRow("ItemPrice");
        newRow("Price") = oldRow("Price");
        newRow("TaxPrice") = oldRow("TaxPrice");
        newRow("TaxID") = oldRow("TaxID");
        newRow("ForceFreeID") = oldRow("ForceFreeID");
        newRow("ForceFreeAuth") = oldRow("ForceFreeAuth");
        newRow("ForceFreeCode") = oldRow("ForceFreeCode");
        newRow("FunctionID") = oldRow("FunctionID");
        newRow("FunctionGroupID") = oldRow("FunctionGroupID");
        newRow("FunctionFlag") = oldRow("FunctionFlag");
        newRow("CategoryID") = oldRow("CategoryID");
        newRow("FoodID") = oldRow("FoodID");
        newRow("DrinkCategoryID") = oldRow("DrinkCategoryID");
        newRow("DrinkID") = oldRow("DrinkID");
        newRow("itemStatus") = oldRow("itemStatus");
        newRow("RoutingID") = oldRow("RoutingID");
        newRow("PrintPriorityID") = oldRow("PrintPriorityID");
        newRow("Repeat") = oldRow("Repeat");
        newRow("TerminalID") = oldRow("TerminalID");
        if (mainServerConnected == true)
        {
            newRow("dbUP") = 1;
        }
        else
        {
            newRow("dbUP") = 0;
        }

        // Return newRow

    }

    internal static void LoadTabIDinExperinceTable()
    {
        DataRow oRow;

        if (currentTerminal.TermMethod == "Quick" | currentTable.TicketNumber > 0)  // currentTable.TabID = -888 Then
        {

            foreach (DataRow currentORow in dsOrder.Tables("QuickTickets").Rows)
            {
                oRow = currentORow;
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        oRow("TabID") = currentTable.TabID;
                        oRow("TabName") = currentTable.TabName;
                        oRow("MethodUse") = currentTable.MethodUse;
                        oRow("NumberOfCustomers") = currentTable.NumberOfCustomers;
                        break;
                    }
                }
            }
        }
        else if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
        {
            if (currentTable.IsTabNotTable == true)
            {
                foreach (DataRow currentORow1 in dsOrder.Tables("AvailTabs").Rows)
                {
                    oRow = currentORow1;
                    if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        oRow("TabID") = currentTable.TabID;
                        oRow("TabName") = currentTable.TabName;
                        oRow("MethodUse") = currentTable.MethodUse;
                        oRow("NumberOfCustomers") = currentTable.NumberOfCustomers;
                        break;
                    }
                }
            }
            else
            {
                foreach (DataRow currentORow2 in dsOrder.Tables("AvailTables").Rows)
                {
                    oRow = currentORow2;
                    if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        oRow("TabID") = currentTable.TabID;
                        oRow("TabName") = currentTable.TabName;
                        oRow("MethodUse") = currentTable.MethodUse;
                        break;
                    }
                }

            }
        }

    }

    internal static void ReleaseTableOrTab()
    {
        DataRow oRow;
        DataRow bRow;
        DataRowView vRow;

        if (currentTerminal.TermMethod == "Quick" | currentTable.TicketNumber > 0)   // currentTable.TabID = -888 Then
        {

            foreach (DataRow currentORow in dsOrder.Tables("QuickTickets").Rows)
            {
                oRow = currentORow;
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        // we should add subtotal to show closed
                        oRow("ClosedSubTotal") = currentTable.SubTotal;
                        oRow("LastStatusTime") = DateTime.Now;
                        if (object.ReferenceEquals(oRow("AvailForSeating"), DBNull.Value))
                        {
                            oRow("AvailForSeating") = DateTime.Now;
                        }
                        oRow("LastStatus") = 10;
                        // oRow("TabName") = "Closed " & currentTable.TableNumber.ToString
                        break;
                    }
                }
            }
        }
        else if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
        {
            // default can be ex: Old Table 11
            if (currentTable.IsTabNotTable == true)
            {
                // *************************
                // we do not need this for tabs

                foreach (DataRow currentORow1 in dsOrder.Tables("AvailTabs").Rows)
                {
                    oRow = currentORow1;
                    if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        // we should add subtotal to show closed
                        oRow("ClosedSubTotal") = currentTable.SubTotal;
                        oRow("LastStatusTime") = DateTime.Now;
                        if (object.ReferenceEquals(oRow("AvailForSeating"), DBNull.Value))
                        {
                            oRow("AvailForSeating") = DateTime.Now;
                        }
                        oRow("LastStatus") = 10;
                        // oRow("TabName") = "Closed " & currentTable.TableNumber.ToString
                    }
                }
            }
            // bRow = (dsBackup.Tables("AvailTabsTerminal").Rows.Find(currentTable.ExperienceNumber))
            // If Not (bRow Is Nothing) Then
            // bRow("ClosedSubTotal") = currentTable.SubTotal
            // bRow("LastStatus") = 1
            // '           bRow("LastStatusTime") = Now
            // End If

            else
            {

                foreach (DataRow currentORow2 in dsOrder.Tables("AvailTables").Rows)
                {
                    oRow = currentORow2;

                    if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        // we should add closed Sub Total
                        // to indicate table is closed
                        oRow("ClosedSubTotal") = currentTable.SubTotal;
                        oRow("LastStatusTime") = DateTime.Now;
                        oRow("TabName") = "Closed " + currentTable.TableNumber.ToString;
                        if (object.ReferenceEquals(oRow("AvailForSeating"), DBNull.Value))
                        {
                            oRow("AvailForSeating") = DateTime.Now;
                        }
                        oRow("LastStatus") = 10;
                        break;
                    }
                }

                if (typeProgram == "Online_Demo")
                {
                    foreach (DataRow aRow in dsOrder.Tables("AllTables").Rows)
                    {
                        // MsgBox(aRow("TableNumber"))
                        // MsgBox(oRow("TableNumber"))

                        if (aRow("TableNumber") == currentTable.TableNumber) // oRow("TableNumber") Then
                        {
                            aRow("EmployeeID") = 0;
                            aRow("TableStatusID") = 10;
                            break;
                        }
                    }
                }
                // GenerateOrderTables.ChangeStatusInDataBase(1, Nothing, 0, Nothing)
            }
        }

        // sss     SaveAvailTabsAndTables()
        // 222     AddStatusChangeData(currentTable.ExperienceNumber, 1, Nothing, 0, Nothing)


    }

    internal static void JustMarkAsCloseNoRelease222()
    {
        DataRow oRow;
        DataRow bRow;
        DataRowView vRow;

        if (currentTerminal.TermMethod == "Quick" | currentTable.TicketNumber > 0)   // currentTable.TabID = -888 Then
        {

            foreach (DataRow currentORow in dsOrder.Tables("QuickTickets").Rows)
            {
                oRow = currentORow;
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        oRow("LastStatus") = 10;
                        break;
                    }
                }
            }
        }
        else if (currentTerminal.TermMethod == "Table" | currentTerminal.TermMethod == "Bar")
        {

            if (currentTable.IsTabNotTable == true)
            {
                foreach (DataRow currentORow1 in dsOrder.Tables("AvailTabs").Rows)
                {
                    oRow = currentORow1;
                    if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        oRow("LastStatus") = 10;
                        break;
                    }
                }
            }
            else
            {

                foreach (DataRow currentORow2 in dsOrder.Tables("AvailTables").Rows)
                {
                    oRow = currentORow2;

                    if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        oRow("LastStatus") = 10;
                        break;
                    }
                }

                if (typeProgram == "Online_Demo")
                {
                    foreach (DataRow aRow in dsOrder.Tables("AllTables").Rows)
                    {
                        if (aRow("TableNumber") == currentTable.TableNumber) // oRow("TableNumber") Then
                        {
                            aRow("EmployeeID") = 0;
                            aRow("TableStatusID") = 10;
                            break;
                        }
                    }
                }
            }
        }

    }

    internal static object ResetSeatingChartTableStatus(int ts, bool overrideAvail)
    {

        DataRow oRow;
        var newStatus = default(int);
        // Dim lastExpNum As Int64
        Color cc;
        var i = default(int);

        if (overrideAvail == true)
        {
            foreach (DataRow currentORow in dsOrder.Tables("AllTables").Rows)
            {
                oRow = currentORow; // 777 ds.Tables("TermsTables").Rows
                if (oRow("Active") == true)
                {
                    if (oRow("TableNumber") == ts)
                    {
                        if (oRow("Available") == true)       // avail for seating
                        {
                            oRow("Available") = false;
                            newStatus = 0;
                        }
                        else                                // all other including sat
                        {
                            oRow("Available") = true;
                            newStatus = 1;
                        }
                        cc = DetermineColor(newStatus);

                        btnTable[i].lblTableNum.BackColor = cc;
                        if (cc.ToString == c15.ToString)
                        {
                            btnTable[i].IsAvail = true;
                        }
                        else
                        {
                            btnTable[i].IsAvail = false;
                        }
                        break;
                    }
                }
                i += 1;
            }

            try
            {
                sql.cn.Open();
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                sql.SqlDataAdapterAllTables.Update(dsOrder.Tables("AllTables"));
                // 777    sql.SqlTermsTables.Update(ds.Tables("TermsTables"))
                sql.cn.Close();
                dsOrder.Tables("AllTables").AcceptChanges();
            }
            // 777      ds.Tables("TermsTables").AcceptChanges()
            catch (Exception ex)
            {
                CloseConnection();
            }
        }
        else
        {
            // we are only changing this temp, will be perm when when reenter
            foreach (DataRow currentORow1 in dsOrder.Tables("AllTables").Rows)
            {
                oRow = currentORow1; // For Each tbl In currentPhysicalTables
                // 777 For Each oRow In dsOrder.Tables("TermsTables").Rows '  For Each tbl In currentPhysicalTables
                // 444      If oRow("Active") = True Then
                if (oRow("TableNumber") == ts)
                {

                    oRow("TableStatusID") = 1;
                    newStatus = 1;

                    cc = DetermineColor(newStatus);
                    btnTable[i].lblTableNum.BackColor = cc;
                    if (cc.ToString == c15.ToString)
                    {
                        btnTable[i].IsAvail = true;
                    }
                    else
                    {
                        btnTable[i].IsAvail = false;
                    }
                    // If Not oRow("MaxExpNumByTable") Is DBNull.Value Then
                    // lastExpNum = oRow("MaxExpNumByTable")
                    // Else
                    // lastExpNum = 0
                    // End If
                    break;
                }
                // 444    End If
                i += 1;
            }
        }

        return newStatus;

    }

    internal static object DetermineColor(int currentStatus)
    {
        Color colorChoice;
        // do not change colors
        // status is dependant on colors in other parts of program

        if (currentStatus == 0)      // unavailable
        {
            colorChoice = c5;            // dim gray
        }
        else if (currentStatus == 1 | currentStatus == 9 | currentStatus == 10)  // available for seating
        {
            colorChoice = c15;            // cornflower blue
        }
        else if (currentStatus == 7) // check down
        {
            colorChoice = c1;            // yellow
        }
        else                                // table sat (includes all)
        {
            colorChoice = c9;
        }            // red

        return colorChoice;
    }

    private static void ChangeTableStatusInCollection222()
    {

        foreach (PhysicalTable tbl in currentPhysicalTables)
        {
            if (tbl.PhysicalTableNumber == currentTable.TableNumber)
            {
                tbl.CurrentStatus = 1;       // avail for seating
            }
        }

        // *** we must do this for every terminal
        // all terminals have their own collections

    }

    private static void RemoveTableFromCollection222()
    {

        foreach (DataSet_Builder.AvailTableUserControl btnTabsAndTables in currentActiveTables)
        {
            if (btnTabsAndTables.ExperienceNumber == currentTable.ExperienceNumber)
            {
                currentActiveTables.Remove(btnTabsAndTables);
                return;
            }
        }

    }

    internal static void RecalculateCheckNumber(long expNum, int cnIncrease)
    {
        DataRow oRow;
        // Dim bRow As DataRow

        if (currentTerminal.TermMethod == "Quick" | currentTable.TicketNumber > 0)
        {
            foreach (DataRow currentORow in dsOrder.Tables("QuickTickets").Rows)
            {
                oRow = currentORow;
                if (oRow("ExperienceNumber") == expNum)
                {
                    oRow("NumberOfChecks") += cnIncrease;
                }
            }
        }
        else if (currentTable.IsTabNotTable == true)
        {
            foreach (DataRow currentORow1 in dsOrder.Tables("AvailTabs").Rows)
            {
                oRow = currentORow1;
                if (oRow("ExperienceNumber") == expNum)
                {
                    oRow("NumberOfChecks") += cnIncrease;
                }
            }
        }
        else
        {
            foreach (DataRow currentORow2 in dsOrder.Tables("AvailTables").Rows)
            {
                oRow = currentORow2;
                if (oRow("ExperienceNumber") == expNum)
                {
                    oRow("NumberOfChecks") += cnIncrease;
                }
            }
        }



    }


    internal static object DetermineCnTest(int cn)
    {
        // this tests to see how if the new or old customer number has any information and how much
        int cnTestValue;

        if (dsOrder.Tables("OpenOrders").Rows.Count > 0)
        {
            cnTestValue = dsOrder.Tables("OpenOrders").Compute("Count(CustomerNumber)", "CustomerNumber ='" + cn + "'");
        }
        else
        {
            cnTestValue = 0;
        }

        return cnTestValue;

    }

    internal static object DeterminePizzaHalfCount222(int currentSI2)
    {
        // this tests to see how if the new or old customer number has any information and how much
        int cnTestValue;

        if (dsOrder.Tables("OpenOrders").Rows.Count > 0)
        {
            cnTestValue = dsOrder.Tables("OpenOrders").Compute("Count(si2)", "si2 ='" + currentSI2 + "'");
        }
        else
        {
            cnTestValue = 0;
        }

        return cnTestValue;

    }

    internal static object DetermineCheckCount(int ct)
    {
        int cnTestValue;

        if (dsOrder.Tables("OpenOrders").Rows.Count > 0)
        {
            cnTestValue = dsOrder.Tables("OpenOrders").Compute("Count(CheckNumber)", "CheckNumber ='" + ct + "'");
        }
        else
        {
            cnTestValue = 0;
        }

        return cnTestValue;
    }

    internal static void GotoNextCheckNumber()
    {

        int firstCheckNumber;
        int i;
        int checkCount;
        int maxCN;

        if (dsOrder.Tables("OpenOrders").Rows.Count > 0)
        {
            maxCN = dsOrder.Tables("OpenOrders").Compute("Max(CheckNumber)", default);
        }
        else
        {
            return;
        }

        if (currentTable.CheckNumber >= maxCN)    // currentTable.NumberOfChecks Then
        {
            firstCheckNumber = 1;
        }
        else
        {
            firstCheckNumber = currentTable.CheckNumber + 1;
        }

        // this will never occur . but putting this here to avoid a forever loop
        if (firstCheckNumber > currentTable.NumberOfChecks)
        {
            currentTable.CheckNumber = 1;
            return;
        }

        var loopTo = maxCN;
        for (i = firstCheckNumber; i <= loopTo; i++)   // currentTable.NumberOfChecks
        {
            checkCount = Conversions.ToInteger(DetermineCheckCount(i));
            if (checkCount > 0)
            {
                currentTable.CheckNumber = i;
                return;
            }
        }

        // default
        currentTable.CheckNumber = 1;

    }

    internal static object CustomerPanelOneTest()
    {
        var cust1Showing = default(bool);

        foreach (DataRow oRow in dsOrder.Tables("OpenOrders").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                if (oRow("sin") == 1 & oRow("ItemID") == 0)
                {
                    cust1Showing = true;
                    break;
                }
            }
        }

        if (cust1Showing == false)
        {
            var currentItem = new SelectedItemDetail();
            string custNumString = "               1   CUSTOMER   1";

            currentItem.Check = currentTable.CheckNumber;
            currentItem.Customer = 1;
            currentItem.Course = 2; // currentTable.CourseNumber
            currentItem.SIN = 1;
            currentItem.SII = 1;
            currentItem.si2 = 0;
            currentItem.ID = 0;
            currentItem.FunctionFlag = "N";
            currentItem.Name = custNumString;
            currentItem.TerminalName = custNumString;
            currentItem.ChitName = custNumString;
            currentItem.Price = (object)null;
            currentItem.Category = (object)null;

            currentTable.SIN += 1;            // ********???????????????????
            if (dvOrder.Count > 0)
            {
                PopulateDataRowForOpenOrder(ref currentItem);
            }
            else
            {
                // 444            DisposeDataViewsOrder()
                PopulateDataRowForOpenOrder(ref currentItem);
                // 444           CreateDataViewsOrder()
            }
        }

        return cust1Showing;

    }



    internal static void DeleteOpenOrdersRowTerminal(ref DataRow dRow)
    {

        // this is repeated below
        // we can remove if we active below
        if (dRow is not null)
        {
            if (!(dRow.RowState == DataRowState.Deleted) | !(dRow.RowState == DataRowState.Detached))
            {
                dRow.Delete();
            }
        }

        return;

        // 222 the below is for terminal data
        if (dRow is not null)
        {
            if (!(dRow.RowState == DataRowState.Added))
            {
                // this means it is probably an old row somewhere in terminal dataset
                // this is slow (maybe we can find some better)
                // but not frequent.. only when we delete an item ordered and saved
                var terminalData = new DataView();
                int ri;

                terminalData.Table = dsBackup.Tables("OpenOrdersTerminal");         // 'dtOpenOrdersTerminal
                terminalData.RowFilter = "ExperienceNumber = '" + currentTable.ExperienceNumber + "'";
                terminalData.Sort = "sin";

                ri = terminalData.Find(dRow("sin"));
                if (!(ri == -1))
                {
                    // will not delete a row that is not there
                    terminalData.Delete(ri);
                }
            }
            if (!(dRow.RowState == DataRowState.Deleted) | !(dRow.RowState == DataRowState.Detached))
            {
                dRow.Delete();
            }
        }

    }

    internal static void PopulateCurrentTableData(ref DataRow oRow)
    {

        currentTable.ExperienceNumber = oRow("ExperienceNumber");
        if (object.ReferenceEquals(oRow("TableNumber"), DBNull.Value))
        {
            // this is tab
            currentTable.IsTabNotTable = true;
            currentTable.TableNumber = 0;
        }
        else
        {
            currentTable.IsTabNotTable = false;
            currentTable.TableNumber = oRow("TableNumber");
        }
        currentTable.TabID = oRow("TabID");
        currentTable.TabName = oRow("TabName");
        currentTable.TicketNumber = oRow("TicketNumber");
        currentTable.EmployeeID = oRow("EmployeeID");
        currentTable.EmployeeNumber = currentServer.EmployeeNumber;
        foreach (DataRow sRow in dsEmployee.Tables("AllEmployees").Rows)
        {
            if (sRow("EmployeeID") == currentTable.EmployeeID)
            {
                currentTable.EmployeeName = sRow("NickName");
                break;
            }
        }
        currentTable.CurrentMenu = oRow("MenuID");
        currentTable.StartingMenu = oRow("MenuID");
        currentTable.NumberOfChecks = oRow("NumberOfChecks");
        currentTable.NumberOfCustomers = oRow("NumberOfCustomers");
        currentTable.LastStatus = oRow("LastStatus");
        // currentTable.FoodOrdered = oRow("FoodOrdered")
        currentTable.ItemsOnHold = oRow("ItemsOnHold");
        currentTable.OrderView = oRow("LastView");
        if (!object.ReferenceEquals(oRow("ClosedSubTotal"), DBNull.Value))
        {
            currentTable.IsClosed = true;
        }
        else
        {
            currentTable.IsClosed = false;
        }
        currentTable.AutoGratuity = oRow("AutoGratuity");
        currentTable.MethodUse = oRow("MethodUse");
        DefineMethodDirection();

    }

    internal static void DefineMethodDirection()
    {
        foreach (DataRowView vRow in dvTerminalsUseOrder)
        {
            if (vRow("MethodUse") == currentTable.MethodUse)
            {
                currentTable.MethodDirection = vRow("MethodDirection");
                break;
            }
        }
    }

    internal static void StartOrderProcess(long experienceNumber)
    {
        int tableNumber = currentTable.TableNumber;
        DateTime satTm;
        // above is not correct

        currentTable.SatTime = DateTime.Today;

        foreach (DataRow oRow in ds.Tables("MenuChoice").Rows)
        {
            if (oRow("MenuID") == currentTable.CurrentMenu)
            {
                currentTable.CurrentMenuName = oRow("MenuName");
                break;
            }
        }

        if (dsOrder.Tables("OpenOrders").Rows.Count == 0)
        {
            // when there is no order history for table

            satTm = Conversions.ToDate(DetermineStatusTime(2));
            int orderStat = 2;
            currentTable.NumberOfChecks = 1;
            currentTable.CheckNumber = 1;
            if (satTm != default)
            {
                currentTable.SatTime = satTm;
            }

            currentTable.SIN = 2;            // lSIN
            currentTable.CustomerNumber = 1;
            currentTable.NextCustomerNumber = 1;
            // 444      currentTable.IsPrimaryMenu = True

            if (currentTerminal.currentPrimaryMenuID == currentTerminal.initPrimaryMenuID) // currentTable.CurrentMenu Then
            {
                currentTable.IsPrimaryMenu = true;
            }
            else
            {
                currentTable.IsPrimaryMenu = false;
            }
            currentTable.DailyCode = currentTerminal.CurrentDailyCode;

            CreateCheck(currentTable.CheckNumber, currentTable.NumberOfCustomers);
        }

        else
        {

            currentTable.SIN = Operators.AddObject(DetermineSelectedItemNumber(), 2);    // add 2 b/c of Customer Panel (subtracts 1)
            if (currentTable.NumberOfChecks > 1)
            {
                GotoNextCheckNumber();   // sending 0 so next should be 1 unless empty
            }
            else
            {
                currentTable.CheckNumber = 1;
            }
            currentTable.CustomerNumber = 1;
            currentTable.NextCustomerNumber = 1;
            currentTable.DailyCode = dsOrder.Tables("OpenOrders").Rows(0)("DailyCode");
            satTm = Conversions.ToDate(DetermineStatusTime(2));
            if (satTm != default)
            {
                currentTable.SatTime = satTm;
            }
            // 444     If primaryMenuID = currentTable.CurrentMenu Then
            if (currentTerminal.currentPrimaryMenuID == currentTerminal.initPrimaryMenuID)
            {
                currentTable.IsPrimaryMenu = true;
            }
            else
            {
                currentTable.IsPrimaryMenu = false;
            }
        }

        if (!(currentTerminal.TermMethod == "Quick"))
        {
            CreateDataViewsOrder();
        }
        else if (actingManager is not null)
        {
            // this is b/c when comming from manager in QUICK we must do this
            // b/c we deleted data views when leaving last order
            CreateDataViewsOrder();
        }

        currentTable.OrderView = "Detailed Order";
        currentTable.ReferenceSIN = currentTable.SIN;
        currentTable.MiddleOfOrder = false;
        currentTable.CourseNumber = 2;
        currentTable.Quantity = 1;
        currentTable.EmptyCustPanel = 0;
        currentTable.si2 = 0;        // this is coded for pizza's or split items as 1
        currentTable.Tempsi2 = 0;
        currentTable.IsPizza = false;

    }

    // *** this is for when we want to list all open orders
    private static void CheckForOpenOrderDetail222()
    {
        long lon;
        SqlClient.SqlDataReader dtr;
        int i;
        DataRow oRow;
        int rowCount;

        rowCount = dsOrder.Tables("OrderDetail").Rows.Count;

        if (rowCount > 0)
        {
            for (i = rowCount - 1; i >= 0; i -= 1)
            {
                oRow = dsOrder.Tables("OrderDetail").Rows(i);
                Interaction.MsgBox(oRow("OrderNumber"));
                if (object.ReferenceEquals(oRow("OrderFilled"), DBNull.Value))
                {
                    lon = oRow("OrderNumber");
                    break;
                }
            }
        }
        else
        {
            lon = 0L;
        }

    }

    private static void CreateCheck(int chkNum, int numCust)
    {
        var newCheck = default(Check);
        // check is a structure defined in term_Tahsc

        newCheck.StructureCheckNumber = chkNum;
        newCheck.NumberOfCustomers = numCust;

        currentTable._checkCollection.Add(newCheck);


    }

    internal static object DetermineSelectedItemNumber()
    {
        var currentSIN = default(int);

        if (dsOrder.Tables("OpenOrders").Rows.Count > 0)
        {
            currentSIN = dsOrder.Tables("OpenOrders").Compute("Max(sin)", "");
        }

        return currentSIN;

    }

    private static object DetermineSelectedItemIndex222()
    {
        var currentSII = default(int);

        if (dsOrder.Tables("OpenOrders").Rows.Count > 0)
        {
            currentSII = dsOrder.Tables("OpenOrders").Compute("Max(sii)", "");
        }

        return currentSII;

    }

    internal static object DetermineStatusTime(int status)
    {
        var statusTime = default(DateTime);
        DataRow oRow;

        // this will only return the latest time for this status
        // For Each oRow In dsOrder.Tables("StatusChange").Rows
        // If Not oRow("TableStatusID") Is DBNull.Value Then
        // If oRow("TableStatusID") = status Then
        // statusTime = oRow("StatusTime")
        // End If
        // '  End If
        // Next

        // this will only sat time

        if (currentTable.IsTabNotTable == true)
        {
            foreach (DataRow currentORow in dsOrder.Tables("AvailTabs").Rows)
            {
                oRow = currentORow;
                statusTime = oRow("ExperienceDate");
                break;
            }
        }
        else
        {
            foreach (DataRow currentORow1 in dsOrder.Tables("AvailTables").Rows)
            {
                oRow = currentORow1;
                statusTime = oRow("ExperienceDate");
                break;
            }
        }

        return statusTime;

    }

    internal static void PopulateStatusData222(long experienceNumber)
    {
        // statusChangeSelectCommand (stored procedure)
        dsOrder.Tables("StatusChange").Rows.Clear();

        // Try
        // sql.cn.Open()
        // sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery()
        // sql.SqlSelectCommandESC.Parameters("@LocationID").Value = companyInfo.LocationID
        // '     sql.SqlSelectCommandESC.Parameters("@ExperienceNumber").Value = experienceNumber
        // sql.SqlDataAdapterESC.Fill(dsOrder.Tables("StatusChange"))
        // sql.cn.Close()
        // Catch ex As Exception
        // '        GenerateOrderTables.CloseConnection()
        // End Try

    }

    private static void PopulateStatusDataWhenDown222(long experienceNumber)
    {
        DataRow oRow;

        DataRow[] copyRows;

        copyRows = dsBackup.Tables("ESCTerminal").Select("ExperienceNumber = '" + experienceNumber + "'");
        if (copyRows is not null)
        {
            foreach (var bRow in copyRows)
            {

                oRow = dsOrder.Tables("StatusChange").NewRow;
                oRow = CopyOneRowToAnotherExpStatusChange(bRow, ref oRow);
                dsOrder.Tables("StatusChange").Rows.Add(oRow);

            }
        }
        else
        {
            Interaction.MsgBox("Copy Rows is nothing");
        }
        dsOrder.Tables("StatusChange").AcceptChanges();

    }

    internal static void PopulateOpenOrderData222(long experienceNumber, bool fromStart)
    {
        // I only call at beginning to initiate dataset

        dsOrder.Tables("OpenOrders").Rows.Clear();


        try
        {
            if (fromStart == false)
            {
                sql.cn.Open();
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            }
            sql.SqlSelectCommandOpenOrdersSP.Parameters("@LocationID").Value = companyInfo.LocationID;
            sql.SqlSelectCommandOpenOrdersSP.Parameters("@ExperienceNumber").Value = experienceNumber;
            sql.SqlDataAdapterOpenOrdersSP.Fill(dsOrder.Tables("OpenOrders"));

            sql.SqlSelectCommandPayments.Parameters("@LocationID").Value = companyInfo.LocationID;
            sql.SqlSelectCommandPayments.Parameters("@ExperienceNumber").Value = experienceNumber;
            sql.SqlDataAdapterPayments.Fill(dsOrder.Tables("PaymentsAndCredits"));

            sql.SqlSelectCommandOrderDetail.Parameters("@LocationID").Value = companyInfo.LocationID;
            sql.SqlSelectCommandOrderDetail.Parameters("@ExperienceNumber").Value = experienceNumber;
            sql.SqlDataAdapterOrderDetail.Fill(dsOrder.Tables("OrderDetail"));

            // sql.SqlSelectCommandESC.Parameters("@LocationID").Value = companyInfo.LocationID
            // sql.SqlSelectCommandESC.Parameters("@ExperienceNumber").Value = experienceNumber
            // sql.SqlDataAdapterESC.Fill(dsOrder.Tables("StatusChange"))

            sql.SqlSelectCommandAvailTablesSP.Parameters("@LocationID").Value = companyInfo.LocationID;
            sql.SqlSelectCommandAvailTablesSP.Parameters("@EmployeeID").Value = -1;
            sql.SqlSelectCommandAvailTablesSP.Parameters("@DailyCode").Value = -1;
            sql.SqlAvailTablesSP.Fill(dsOrder.Tables("AvailTables"));

            sql.SqlSelectCommandAvailTabsSP.Parameters("@LocationID").Value = companyInfo.LocationID;
            sql.SqlSelectCommandAvailTabsSP.Parameters("@DailyCode").Value = -1;
            sql.SqlSelectCommandAvailTabsSP.Parameters("@EmployeeID").Value = -1;
            sql.SqlAvailTabsSP.Fill(dsOrder.Tables("AvailTabs"));
            if (fromStart == false)
            {
                sql.cn.Close();
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
            // PoplulateOpenOrderDataWhenDown()
        }

        // PoplulateOpenOrderDataWhenDown()



    }

    private static void PoplulateOpenOrderDataWhenDown222()
    {
        DataRow oRow;
        DataRow[] copyRows;
        dsOrder.Tables("OpenOrders").Clear();

        copyRows = dsBackup.Tables("OpenOrdersTerminal").Select("ExperienceNumber = '" + currentTable.ExperienceNumber + "'");

        foreach (var bRow in copyRows)
        {
            oRow = dsOrder.Tables("OpenOrders").NewRow;
            CopyOneRowToAnotherOpenOrders222(bRow, ref oRow);
            dsOrder.Tables("OpenOrders").Rows.Add(oRow);
        }
        dsOrder.Tables("OpenOrders").AcceptChanges();

    }

    private static void PopulateOrderDetail(long expNum)
    {
        dsOrder.Tables("OrderDetail").Rows.Clear();

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            // sql.SqlSelectCommandOpenOrdersSP.Parameters("@CompanyID").Value = CompanyID
            sql.SqlSelectCommandOrderDetail.Parameters("@LocationID").Value = companyInfo.LocationID;
            sql.SqlSelectCommandOrderDetail.Parameters("@ExperienceNumber").Value = expNum;
            // sql.SqlSelectCommandOrderDetail.Parameters("@DailyCode").Value = currentTerminal.currentDailyCode
            sql.SqlDataAdapterOrderDetail.Fill(dsOrder.Tables("OrderDetail"));
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
            if (Information.Err().Number == Conversions.ToDouble("5"))
            {
                ServerJustWentDown();
            }
            // PoplulateOpenOrderDataWhenDown()
        }


    }


    // **************************
    // Payments And Credits
    // **************************

    internal static void AddPaymentToCollection(ref DataSet_Builder.Payment newpayment)
    {

        foreach (DataSet_Builder.Payment testPay in tabcc)
        {
            if (testPay.experienceNumber == newpayment.experienceNumber)
            {
                if (testPay.AccountNumber == newpayment.AccountNumber)
                {
                    // we have the same payment assc with this account, 
                    // REMOVE, put in most current info
                    tabcc.Remove(testPay);
                    break;
                }
            }
        }

        tabcc.Add(newpayment);

    }

    internal static void RemovePaymentFromCollection(ref string acctNum) // newpayment As DataSet_Builder.Payment)
    {

        foreach (DataSet_Builder.Payment testPay in tabcc)
        {
            if (testPay.experienceNumber == currentTable.ExperienceNumber)
            {
                if (testPay.AccountNumber == acctNum)
                {
                    // we have the same payment assc with this account, 
                    // REMOVE, put in most current info
                    tabcc.Remove(testPay);
                    break;
                }
            }
        }
    }

    internal static object RetreivePaymentFromColloection222()
    {
        tabccThisExperience.Clear();

        foreach (Payment storedPayment in tabcc)
        {
            if (storedPayment.experienceNumber == currentTable.ExperienceNumber)
            {
                tabccThisExperience.Add(storedPayment);
            }
        }

        return default;

        // Return storedPayment
    }

    internal static void PopulatePaymentsAndCredits222(long experienceNumber)
    {
        dsOrder.Tables("PaymentsAndCredits").Rows.Clear();

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            // sql.SqlSelectCommandPayments.Parameters("@CompanyID").Value = CompanyID
            sql.SqlSelectCommandPayments.Parameters("@LocationID").Value = companyInfo.LocationID;
            sql.SqlSelectCommandPayments.Parameters("@ExperienceNumber").Value = experienceNumber;
            sql.SqlDataAdapterPayments.Fill(dsOrder.Tables("PaymentsAndCredits"));
            sql.cn.Close();
        }

        catch (Exception ex)
        {
            CloseConnection();
            if (Information.Err().Number == Conversions.ToDouble("5"))
            {
                ServerJustWentDown();
            }
            // PopulatePaymentsAndCreditsWhenDown(currentTable.ExperienceNumber)
        }

    }

    internal static object PopulatePaymentsAndCreditsByDaily(long dc)
    {
        string newvalueAcct;

        dsOrder.Tables("PaymentsAndCredits").Rows.Clear();

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlSelectCommandPaymentsBatch.Parameters("@LocationID").Value = companyInfo.LocationID;
            sql.SqlSelectCommandPaymentsBatch.Parameters("@DailyCode").Value = dc;
            sql.SqlDataAdapterPaymentsBatch.Fill(dsOrder.Tables("PaymentsAndCredits"));
            sql.cn.Close();

            foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)
            {
                if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
                {
                    // If oRow("PaymentTypeID") > 1 Then
                    if (oRow("PaymentFlag") == "cc" | oRow("PaymentFlag") == "Gift" | oRow("PaymentFlag") == "Issue")
                    {

                        if (!(oRow("AccountNumber").Substring(0, 4) == "xxxx") & !(oRow("AccountNumber") == "Manual"))
                        {
                            try
                            {
                                if (oRow("AccountNumber").ToString.Length > 20)
                                {
                                    // if encrypt acct# length > 50, then this will account# will be wrong
                                    newvalueAcct = CryOutloud.Decrypt(oRow("AccountNumber"), "test");
                                    oRow("AccountNumber") = newvalueAcct;
                                }
                            }

                            // can't encrypt exp date b/c database only holds 4 chars
                            // newvalueExpDate = CryOutloud.Decrypt(oRow("CCExpiration"), "test")
                            // oRow("CCExpiration") = newvalueExpDate
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            CloseConnection();
            if (Information.Err().Number == Conversions.ToDouble("5"))
            {
                ServerJustWentDown();
            }
            return false;
            // PopulatePaymentsAndCreditsWhenDown(currentTable.ExperienceNumber)
        }

    }

    internal static void UpdatePaymentsAndCreditsBatch()
    {
        string newvalueAcct;

        foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                // If oRow("PaymentTypeID") > 1 Then
                if (oRow("PaymentFlag") == "cc" | oRow("PaymentFlag") == "Gift" | oRow("PaymentFlag") == "Issue")
                {

                    if (!(oRow("AccountNumber").Substring(0, 4) == "xxxx") & !(oRow("AccountNumber") == "Manual"))
                    {
                        try
                        {
                            if (oRow("AccountNumber").ToString.Length < 20)
                            {
                                newvalueAcct = CryOutloud.Encrypt(oRow("AccountNumber"), "test");
                                oRow("AccountNumber") = newvalueAcct;
                            }
                        }

                        // can't encrypt exp date b/c database only holds 4 chars
                        // newvalueExpDate = CryOutloud.Decrypt(oRow("CCExpiration"), "test")
                        // oRow("CCExpiration") = newvalueExpDate
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
        }

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlDataAdapterPaymentsBatch.Update(dsOrder.Tables("PaymentsAndCredits"));
            sql.cn.Close();
        }

        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }

        dsOrder.Tables("PaymentsAndCredits").AcceptChanges();

    }

    private static void VerifyPaymentInfo(ref Payment newPayment)
    {

        // If newPayment.PaymentFlag = "cc" Or newPayment.PaymentFlag = "Issue" Or newPayment.PaymentFlag = "Gift" Then
        if (newPayment.PaymentTypeID > 1)
        {

            if (newPayment.AccountNumber.Length > 50)
            {
                newPayment.AccountNumber = newPayment.AccountNumber.Substring(0, 50);
            }
            if (newPayment.ExpDate.Length > 4)
            {
                newPayment.ExpDate = newPayment.ExpDate.Substring(0, 4);
            }
            // CCV
            if (newPayment.Track2 is not null)
            {
                if (newPayment.Track2.Length > 50)
                {
                    newPayment.Track2 = newPayment.Track2.Substring(0, 50);
                }
            }

            if (newPayment.Name.Length == 0)
            {
                newPayment.Name = "Customer";
            }
            else if (newPayment.Name.Length > 50)
            {
                newPayment.Name = newPayment.Name.Substring(0, 50);
            }
        }

    }
    public static void AddPaymentToDataRow(ref DataSet_Builder.Payment newPayment, bool doApply, long en, int empID, int cn, bool autoGrat)
    {

        VerifyPaymentInfo(ref newPayment);

        DataRow oRow = dsOrder.Tables("PaymentsAndCredits").NewRow;

        // oRow("PaymentsAndCreditsID") = DBNull.Value
        oRow("CompanyID") = companyInfo.CompanyID;
        oRow("LocationID") = companyInfo.LocationID;
        oRow("DailyCode") = currentTerminal.CurrentDailyCode;
        oRow("ExperienceNumber") = en;   // currentTable.ExperienceNumber
        oRow("PaymentDate") = DateTime.Now;
        oRow("EmployeeID") = empID;  // currentServer.EmployeeID 
        oRow("CheckNumber") = cn;    // currentTable.CheckNumber
        oRow("PaymentTypeID") = newPayment.PaymentTypeID;
        oRow("PaymentTypeName") = newPayment.PaymentTypeName;
        // *** will change 
        if (newPayment.PaymentTypeID == 1) // TypeName = "Cash" Then
        {
            oRow("PaymentFlag") = "Cash";
        }
        else if (newPayment.PaymentTypeID == -98) // Gift Certificate
        {
            oRow("PaymentFlag") = "Gift Cert"; // "Cash" '
        }
        else if (newPayment.PaymentTypeID == 6) // = "MPS Gift" Then
        {
            oRow("PaymentFlag") = "Gift";
            oRow("TransactionType") = "PrePaid";
            oRow("TransactionCode") = newPayment.TranCode;
        }
        else if (newPayment.PaymentTypeID == -97) // = "Issue Gift" Then
        {
            oRow("PaymentFlag") = "Issue";
            oRow("TransactionType") = "PrePaid";
            // **** is trans code is not correct ????
            oRow("TransactionCode") = newPayment.TranCode;
        }
        else if (newPayment.PaymentTypeID == 9) // outside credit
        {
            oRow("PaymentFlag") = "outside";
            oRow("TransactionType") = "Credit";
            oRow("TransactionCode") = newPayment.TranCode;
        }
        else
        {
            oRow("PaymentFlag") = "cc";
            oRow("TransactionType") = "Credit";
            oRow("TransactionCode") = newPayment.TranCode;
        }
        oRow("AccountNumber") = newPayment.AccountNumber;
        oRow("CCExpiration") = newPayment.ExpDate;
        oRow("CVV") = DBNull.Value;
        oRow("Track2") = newPayment.Track2;
        oRow("CustomerName") = newPayment.Name;
        oRow("SwipeType") = newPayment.Swiped;
        oRow("PaymentAmount") = newPayment.Purchase;
        oRow("Surcharge") = 0;
        if (autoGrat == true)
        {
            oRow("Tip") = Strings.Format(newPayment.Purchase * companyInfo.autoGratuityPercent, "##,###.00");
        }
        else
        {
            oRow("Tip") = 0;
        }

        if (doApply == true)
        {
            if (oRow("PaymentFlag") == "Cash")
            {
                oRow("AuthCode") = "Cash";
            }
            else
            {
                oRow("AuthCode") = DBNull.Value;
            }
        }
        else
        {
            oRow("AuthCode") = DBNull.Value;
        }

        oRow("Applied") = doApply;
        oRow("RefNum") = newPayment.RefNo; // (currentTable.ExperienceNumber).ToString
        // refNo: & "-" & currentTable.CheckNumber & "-" & paymentRowIndex).ToString
        oRow("BatchCleared") = 0;
        oRow("Duplicate") = 0;
        oRow("TerminalID") = currentTerminal.TermID;
        oRow("TerminalsOpenID") = currentTerminal.TerminalsOpenID;
        oRow("AlreadyPrinted") = 0;
        oRow("Description") = newPayment.Description;
        if (mainServerConnected == true)
        {
            oRow("dbUP") = 1;
        }
        else
        {
            oRow("dbUP") = 0;
        }
        if (oRow("PaymentFlag") == "Issue" | oRow("PaymentFlag") == "Gift")
        {
            // leter we can place all swipe codes in payment
            // not doing yet b/c it might be easieer to search w/o clutter
            if (newPayment.TabID != default)
            {
                oRow("OpenBigInt1") = newPayment.TabID;
            }
            else
            {
                oRow("OpenBigInt1") = DBNull.Value;
            }
        }
        else
        {
            oRow("OpenBigInt1") = DBNull.Value;
        }

        if (typeProgram == "Online_Demo")
        {
            oRow("PaymentsAndCreditsID") = demoPaymentID;
            demoPaymentID += 1;
        }

        dsOrder.Tables("PaymentsAndCredits").Rows.Add(oRow);

    }
    public static object ValidateExpDate(string expDate)
    {

        try
        {
            if (expDate.Length < 4 | expDate == "MMYY")
            {
                Interaction.MsgBox("Expiration date need to be in Format:   MMYY ");
                return false;
            }
            else
            {
                if (Conversions.ToInteger(expDate.Substring(2, 2)) < DateTime.Now.Year - 2000)
                {
                    Interaction.MsgBox("Customer Card Expired!");
                    return false;
                }
                else if (Conversions.ToInteger(expDate.Substring(2, 2)) == DateTime.Now.Year - 2000)
                {
                    if (Conversions.ToInteger(expDate.Substring(0, 2)) < DateTime.Now.Month)
                    {
                        Interaction.MsgBox("Customer Card Expired!");
                        return false;
                    }
                }

                return true;
            }
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Expiration date need to be in Format:   MMYY ");
            return false;
        }

    }

    public static object DetermineCreditCardName(string newAcctNum)
    {
        string firstDigit;
        string secondDigit;
        string thirdDigit;
        string TypeName;
        TypeName = "";

        if (!(newAcctNum.Length > 3))
        {
            return TypeName;
            return default;
        }

        firstDigit = newAcctNum.Substring(0, 1);

        switch (firstDigit ?? "")
        {
            case "3":
                {
                    secondDigit = newAcctNum.Substring(1, 1);
                    if (secondDigit == "4" | secondDigit == "7")
                    {
                        TypeName = "AMEX";
                    }
                    else if (secondDigit == "6" | secondDigit == "0" | secondDigit == "8")
                    {
                        // "0" and "8" are going away soon
                        TypeName = "DCLB";   // diner's club
                    }

                    break;
                }
            case "4":
                {
                    TypeName = "VISA";
                    break;
                }
            case "5":
                {
                    // this is for Dinner's Club cards bought by Master Card
                    TypeName = "M/C";
                    break;
                }
            case "6":
                {
                    secondDigit = newAcctNum.Substring(1, 3);
                    if (secondDigit == "011")
                    {
                        TypeName = "DCVR";
                    }
                    else if (secondDigit == "050")
                    {
                        thirdDigit = newAcctNum.Substring(4, 3);
                        if (thirdDigit == "110")
                        {
                            TypeName = "MPS Gift";
                            // ElseIf thirdDigit = "000" Then
                            // for other gift types
                        }
                    }

                    break;
                }
        }

        return TypeName;

    }

    public static int DetermineCreditCardID(string TypeName)
    {
        int creditCardID = 0;

        // *** ADD FLAG    
        // this will change when redo credit card crap
        // right now its backwards

        foreach (DataRow oRow in ds.Tables("CreditCardDetail").Rows)
        {
            if (oRow("PaymentTypeName") == TypeName)
            {
                creditCardID = oRow("PaymentTypeID");
                break;
            }
        }

        return creditCardID;

    }

    public static object DeterminePaymentFlag222(string TypeName)
    {
        var PayFlag = default(string);

        foreach (DataRow oRow in ds.Tables("CreditCardDetail").Rows)
        {
            if (oRow("PaymentTypeName") == TypeName)
            {
                PayFlag = oRow("PaymentFlag");
                break;
            }
        }

        return PayFlag;

    }

    private static void PopulatePaymentsAndCreditsWhenDown222(long expNum)
    {
        DataRow bRow;
        DataRow oRow;
        DataRow[] copyRows;
        dsOrder.Tables("PaymentsAndCredits").Rows.Clear();
        int numberCopied;

        // we are copying all rows for this experience number
        // then deleting any rows from terminal not in SQL Server
        // then we are setting these to new rows, so they get re-entered
        // we do this because we must record any changes and we can't keep track w/o ID#
        try
        {
            var argnewdTable = dsOrder.Tables("PaymentsAndCredits");
            var argolddTable = dsBackup.Tables("PaymentsAndCreditsTerminal");
            CopyPaymentRows(ref argnewdTable, ref argolddTable, "ExperienceNumber = '" + expNum + "' AND PaymentsAndCreditsID IS NOT NULL");

            // must reinitialize our table (this tell us all this info is old)
            dsOrder.Tables("PaymentsAndCredits").AcceptChanges();

            var argnewdTable1 = dsOrder.Tables("PaymentsAndCredits");
            var argolddTable1 = dsBackup.Tables("PaymentsAndCreditsTerminal");
            numberCopied = Conversions.ToInteger(CopyPaymentRows(ref argnewdTable1, ref argolddTable1, "ExperienceNumber = '" + expNum + "' AND PaymentsAndCreditsID IS NULL"));

            if (numberCopied > 0)
            {
                var argdTable = dsBackup.Tables("PaymentsAndCreditsTerminal");
                DeleteNonSQLRecordedRowsPayments(ref argdTable);
                dsBackup.Tables("PaymentsAndCreditsTerminal").AcceptChanges();
            }
        }

        catch (Exception ex)
        {
            // if copying fails    .... we revert to an empty table  ???
            // can't use here.. since we are deleting terminal rows
            // dsOrder.Tables("PaymentsAndCredits").Rows.Clear()
            Interaction.MsgBox(ex.Message);
        }

    }

    private static object CopyPaymentRows(ref DataTable newdTable, ref DataTable olddTable, string selectionString)
    {
        DataRow oRow;
        DataRow[] copyRows;

        copyRows = olddTable.Select(selectionString);
        if (copyRows is not null)
        {
            foreach (var bRow in copyRows)
            {
                oRow = newdTable.NewRow;
                CopyOneRowToAnotherPaymentsAndCredits(bRow, ref oRow, -1); // will copy db value
                newdTable.Rows.Add(oRow);
            }
        }
        else
        {

        }

        return copyRows.Length;

    }

    internal static void PopulatePaymentsAndCreditsWhenClosing()
    {
        // Dim oRow As DataRow
        // same as without closing but we don't want to keep openinf and closing database
        // there is a better way to do this
        string newvalueAcct;

        dsOrder.Tables("PaymentsAndCredits").Clear();

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            // For Each oRow In dsOrder.Tables("AvailTables").Rows
            sql.SqlSelectCommandPaymentsByEmployee.Parameters("@LocationID").Value = companyInfo.LocationID;
            sql.SqlSelectCommandPaymentsByEmployee.Parameters("@DailyCode").Value = currentTerminal.CurrentDailyCode;
            sql.SqlSelectCommandPaymentsByEmployee.Parameters("@EmployeeID").Value = currentClockEmp.EmployeeID; // currentServer.EmployeeID
            sql.SqlDataAdapterPaymentsByEmployee.Fill(dsOrder.Tables("PaymentsAndCredits"));
            // Next
            // For Each oRow In dsOrder.Tables("AvailTabs").Rows
            // sql.SqlSelectCommandPaymentsByEmployee.Parameters("@CompanyID").Value = CompanyID
            // sql.SqlSelectCommandPaymentsByEmployee.Parameters("@LocationID").Value = LocationID
            // sql.SqlSelectCommandPaymentsByEmployee.Parameters("@DailyCode").Value = currentTerminal.currentDailyCode
            // sql.SqlSelectCommandPaymentsByEmployee.Parameters("@EmployeeID").Value = currentServer.EmployeeID
            // sql.SqlDataAdapterPaymentsByEmployee.Fill(dsOrder.Tables("PaymentsAndCredits"))
            // Next
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
        }

        foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            if (!(oRow.RowState == DataRowState.Deleted) & !(oRow.RowState == DataRowState.Detached))
            {
                // If oRow("PaymentTypeID") > 1 Then
                if (oRow("PaymentFlag") == "cc" | oRow("PaymentFlag") == "Gift" | oRow("PaymentFlag") == "Issue")
                {
                    if (!(oRow("AccountNumber").Substring(0, 4) == "xxxx") & !(oRow("AccountNumber") == "Manual"))
                    {
                        try
                        {
                            if (oRow("AccountNumber").ToString.Length > 20)
                            {
                                newvalueAcct = CryOutloud.Decrypt(oRow("AccountNumber"), "test");
                                oRow("AccountNumber") = newvalueAcct;
                            }
                        }

                        // can't encrypt exp date b/c database only holds 4 chars
                        // newvalueExpDate = CryOutloud.Decrypt(oRow("CCExpiration"), "test")
                        // oRow("CCExpiration") = newvalueExpDate
                        catch (Exception ex)
                        {

                        }

                    }
                }
            }
        }

    }

    internal static void UpdatePaymentsAndCreditsByEmployee()
    {

        try
        {
            if (typeProgram == "Online_Demo")
            {
                dsOrderDemo.Merge(dsOrder.Tables("PaymentsAndCredits"), false, MissingSchemaAction.Add);
            }
            // ???   dsOrder.Tables("PaymentsAndCredits").Clear()
            else
            {
                sql.cn.Open();
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                sql.SqlDataAdapterPaymentsByEmployee.Update(dsOrder.Tables("PaymentsAndCredits"));
                sql.cn.Close();
            }
        }

        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }

        dsOrder.Tables("PaymentsAndCredits").AcceptChanges();

    }


    // *** this is wrong
    // we need to do this for each closing table
    // if we even want to close out when were down

    private static void PopulatePaymentsAndCreditsWhenDownWhenClosing222()
    {
        DataRow oRow;
        DataRow[] copyRows;

        try
        {
            copyRows = dsBackup.Tables("PaymentsAndCreditsTerminal").Select("ExperienceID = '" + currentServer.EmployeeID + "' AND currentTerminal.currentDailyCode = '" + currentTerminal.CurrentDailyCode + "'");
            if (copyRows is not null)
            {
                foreach (var bRow in copyRows)
                {

                    oRow = dsOrder.Tables("PaymentsAndCredits").NewRow;
                    CopyOneRowToAnotherPaymentsAndCredits(bRow, ref oRow, -1); // will copy db value
                    if (typeProgram == "Online_Demo")
                    {
                        oRow("PaymentsAndCreditsID") = demoPaymentID;
                        demoPaymentID += 1;
                    }
                    dsOrder.Tables("PaymentsAndCredits").Rows.Add(oRow);
                }
            }
            else
            {

            }
            // must reinitialize our table (this tell us all this info is old)
            dsOrder.Tables("PaymentsAndCredits").AcceptChanges();
        }
        catch (Exception ex)
        {
            // if copying fails    .... we revert to an empty table  ???
            dsOrder.Tables("PaymentsAndCredits").Rows.Clear();

        }

    }

    internal static void PopulateOpenOrdersWhenClosing222()
    {
        DataRow oRow;

        if (mainServerConnected == true)
        {
            try
            {
                foreach (DataRow currentORow in dsOrder.Tables("AvailTables").Rows)
                {
                    oRow = currentORow;
                    sql.cn.Open();
                    sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                    sql.SqlSelectCommandOpenOrdersByEmployee.Parameters("@CompanyID").Value = companyInfo.CompanyID;
                    sql.SqlSelectCommandOpenOrdersByEmployee.Parameters("@LocationID").Value = companyInfo.LocationID;
                    sql.SqlSelectCommandOpenOrdersByEmployee.Parameters("@ExperienceNumber").Value = oRow("ExperienceNumber");
                    sql.SqlSelectCommandOpenOrdersByEmployee.Parameters("@EmployeeID").Value = currentServer.EmployeeID;
                    sql.SqlDataAdapterOpenOrdersByEmployee.Fill(dsOrder.Tables("OpenOrders"));
                    sql.cn.Close();
                }
                foreach (DataRow currentORow1 in dsOrder.Tables("AvailTabs").Rows)
                {
                    oRow = currentORow1;
                    sql.cn.Open();
                    sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                    sql.SqlSelectCommandOpenOrdersByEmployee.Parameters("@CompanyID").Value = companyInfo.CompanyID;
                    sql.SqlSelectCommandOpenOrdersByEmployee.Parameters("@LocationID").Value = companyInfo.LocationID;
                    sql.SqlSelectCommandOpenOrdersByEmployee.Parameters("@ExperienceNumber").Value = oRow("ExperienceNumber");
                    sql.SqlSelectCommandOpenOrdersByEmployee.Parameters("@EmployeeID").Value = currentServer.EmployeeID;
                    sql.SqlDataAdapterOpenOrdersByEmployee.Fill(dsOrder.Tables("OpenOrders"));
                    sql.cn.Close();
                }
            }
            catch (Exception ex)
            {
                CloseConnection();
                if (Information.Err().Number == Conversions.ToDouble("5"))
                {
                    ServerJustWentDown();
                }
                dsOrder.Tables("OpenOrders").Clear();
                PopulateOpenOrdersWhenDownWhenClosing222();
            }
        }
        else
        {
            PopulateOpenOrdersWhenDownWhenClosing222();
        }

    }

    // *** this is wrong
    // we need to do this for each closing table
    // if we even want to close out when were down

    private static void PopulateOpenOrdersWhenDownWhenClosing222()
    {
        DataRow oRow;
        DataRow[] copyRows;

        try
        {
            copyRows = dsBackup.Tables("OpenOrdersTerminal").Select("ExperienceID = '" + currentServer.EmployeeID + "' AND currentTerminal.currentDailyCode = '" + currentTerminal.CurrentDailyCode + "'");
            if (copyRows is not null)
            {
                foreach (var bRow in copyRows)
                {

                    oRow = dsOrder.Tables("OpenOrders").NewRow;
                    CopyOneRowToAnotherOpenOrders222(bRow, ref oRow); // will copy db value
                    dsOrder.Tables("OpenOrders").Rows.Add(oRow);
                }
            }
            else
            {

            }
            // must reinitialize our table (this tell us all this info is old)
            dsOrder.Tables("OpenOrders").AcceptChanges();
        }
        catch (Exception ex)
        {
            // if copying fails    .... we revert to an empty table  ???
            dsOrder.Tables("OpenOrders").Rows.Clear();

        }

    }

    internal static void UpdatePaymentsAndCredits()
    {

        try
        {
            if (typeProgram == "Online_Demo")
            {
                dsOrderDemo.Merge(dsOrder.Tables("PaymentsAndCredits"), false, MissingSchemaAction.Add);
                dsOrder.Tables("PaymentsAndCredits").Clear();
            }
            else
            {
                sql.cn.Open();
                sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                sql.SqlDataAdapterPayments.Update(dsOrder.Tables("PaymentsAndCredits"));
                sql.cn.Close();
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
        }

        // TerminalAddPayments()
        dsOrder.Tables("PaymentsAndCredits").AcceptChanges();

    }

    private static void TerminalAddPayments222()
    {
        var bRow = default(DataRow);
        int dbUP;
        bool modifiedPayment;

        foreach (DataRow oRow in dsOrder.Tables("PaymentsAndCredits").Rows)
        {
            if (oRow.RowState == DataRowState.Added)
            {
                AddNewTerminalPayment222(ref oRow, ref bRow);
            }

            else if (oRow.RowState == DataRowState.Modified)
            {

                if (object.ReferenceEquals(oRow("PaymentsAndCreditsID"), DBNull.Value))
                {
                }
                // meaning this is new data not on SQL Server
                // this row was deleted in terminal when copied
                // we should never be here... all non ID's are new rows    ????
                // dbUP = 0
                // AddNewTerminalPayment(oRow, bRow)
                // oRow("PaymentsAndCreditsID") = -1
                // modifiedPayment = True

                else
                {
                    // is old data we just changed
                    if (mainServerConnected == true)
                    {
                        dbUP = 1;
                    }
                    else
                    {
                        dbUP = 2;
                    }

                    foreach (DataRow currentBRow in dsBackup.Tables("PaymentsAndCreditsTerminal").Rows)
                    {
                        bRow = currentBRow;
                        if (bRow("PaymentsAndCreditsID") == oRow("PaymentsAndCreditsID"))
                        {
                            CopyOneRowToAnotherPaymentsAndCredits(oRow, ref bRow, dbUP); // will place db value
                        }
                    }

                }
            }
        }

        // If modifiedPayment = True Then
        // DeleteNonSQLRecordedRowsPayments(dsOrder.Tables("PaymentsAndCredits"))
        // End If

    }

    private static void DeleteNonSQLRecordedRowsPayments(ref DataTable dTable)
    {
        DataRow[] dRows;
        int i;

        dRows = dTable.Select("PaymentsAndCreditsID IS NULL");

        var loopTo = dRows.Length - 1;
        for (i = 0; i <= loopTo; i++)
            dRows[i].Delete();

    }

    private static void AddNewTerminalPayment222(ref DataRow oRow, ref DataRow bRow)
    {
        int dbUP;

        if (mainServerConnected == true)
        {
            dbUP = 1;
        }
        else
        {
            dbUP = 0;
        }

        bRow = dsBackup.Tables("PaymentsAndCreditsTerminal").NewRow;
        CopyOneRowToAnotherPaymentsAndCredits(oRow, ref bRow, dbUP); // will place db value
        dsBackup.Tables("PaymentsAndCreditsTerminal").Rows.Add(bRow);

    }

    internal static void UpdateAvailTablesData()
    {

        // we don't come here unless the db is UP

        // *** we need to add conflict resolution
        // we we come here after we just came UP
        // 
        // "CurrenTables" below not used
        // Try
        // sql.cn.Open()
        // sql.SqlDataAdapterCurrentTables.Update(dsOrder.Tables("CurrentTables"))
        // sql.cn.Close()
        // '
        // dsOrder.Tables("CurrentTables").AcceptChanges()
        // Catch ex As Exception
        // MsgBox(ex.Message)
        // CloseConnection()
        // ServerJustWentDown()
        // End Try
    }


    // **************************
    // Closed Tables



    private static void PopulateClosedTabsAndTablesWhenDown222()
    {
        // currently can't do because we can not poplate Close Tables for all terminals
        // when we do we have to create a closedTableDataSet ByEmployee
        return;

        DataRow bRow;
        DataRow oRow;
        DataRow[] copyRows;

        try
        {
            // the below would have to use a "ClosedTablesTerminal"
            copyRows = dsBackup.Tables("AvailTablesTerminal").Select("LastStatus < 2");
            if (copyRows is not null)
            {
                foreach (var currentBRow in copyRows)
                {
                    bRow = currentBRow;

                    oRow = dsOrder.Tables("ClosedTables").NewRow;
                    CopyOneRowToAnotherAvailTabsAndTables222(bRow, ref oRow);
                    dsOrder.Tables("ClosedTables").Rows.Add(oRow);
                }
            }
            else
            {

            }
            // the below would have to use a "ClosedTablesTerminal"
            copyRows = dsBackup.Tables("AvailTabsTerminal").Select("LastStatus < 2");
            if (copyRows is not null)
            {
                foreach (var currentBRow1 in copyRows)
                {
                    bRow = currentBRow1;

                    oRow = dsOrder.Tables("ClosedTabs").NewRow;
                    CopyOneRowToAnotherAvailTabsAndTables222(bRow, ref oRow);
                    dsOrder.Tables("ClosedTabs").Rows.Add(oRow);
                }
            }
            else
            {

            }
            // must reinitialize our table (this tell us all this info is old)
            dsOrder.Tables("ClosedTables").AcceptChanges();
            dsOrder.Tables("ClosedTabs").AcceptChanges();
        }
        catch (Exception ex)
        {
            // if copying fails    .... we revert to an empty table  ???
            // don't need this here, incomplete info is ok
        }

    }

    // ****************
    // Daily's

    internal static void DetermineOpenBusiness()
    {

        if (typeProgram == "Online_Demo")
        {
            return;
        }

        sql.SqlSelectCommandOpenBusiness.Parameters("@LocationID").Value = companyInfo.LocationID;

        try
        {
            dsOrder.Tables("OpenBusiness").Rows.Clear();
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlDataAdapterOpenBusiness.Fill(dsOrder.Tables("OpenBusiness"));
            sql.cn.Close();
        }

        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
            if (Information.Err().Number == Conversions.ToDouble("5"))
            {
                ServerJustWentDown();
            }
        }

    }

    internal static void DetermineOpenCashDrawer(long dc)
    {

        if (typeProgram == "Online_Demo")
        {
            return;
            string filterString;
            string NotfilterString;
            filterString = "DailyCode = " + dc;
            NotfilterString = "NOT DailyCode = " + dc;

            var argdtTO = dsOrder.Tables("OpenBusiness");
            Demo_FilterDemoDataTabble(dsOrderDemo.Tables("OpenBusiness"), ref argdtTO, filterString, NotfilterString);
            return;
        }

        // dc = 26
        sql.SqlSelectCommandTermsOpen.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlSelectCommandTermsOpen.Parameters("@DailyCode").Value = dc;   // currentTerminal.CurrentDailyCode
        // sql.SqlSelectCommandTermsOpen.Parameters("@TerminalsPrimaryKey").Value = currentTerminal.TermPrimaryKey

        // in the middle of try, catch
        dsOrder.Tables("TermsOpen").Rows.Clear();
        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlTermsOpen.Fill(dsOrder.Tables("TermsOpen"));
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
        }


    }

    internal static void DetermineCashTransactions(long activeTerminalsOpenID)
    {

        dsOrder.Tables("CashIn").Rows.Clear();
        dsOrder.Tables("CashOut").Rows.Clear();

        if (typeProgram == "Online_Demo")
        {
            string filterString;

            filterString = "PaymentTypeID = 1";
            var argdtTO = dsOrder.Tables("CashIn");
            Demo_FilterDontDelete(dsOrderDemo.Tables("PaymentsAndCredits"), ref argdtTO, filterString); // , NotfilterString)

            filterString = "PaymentTypeID = -3";
            var argdtTO1 = dsOrder.Tables("CashOut");
            Demo_FilterDontDelete(dsOrderDemo.Tables("PaymentsAndCredits"), ref argdtTO1, filterString); // , NotfilterString)

            Interaction.MsgBox(dsOrder.Tables("CashIn").Rows(0)("PaymentAmount"));
            Interaction.MsgBox(dsOrder.Tables("CashOut").Rows(0)("PaymentAmount"));

            return;
        }

        sql.SqlSelectCommandTermsCashTransactions.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlSelectCommandTermsCashTransactions.Parameters("@PaymentTypeID").Value = 1;
        sql.SqlSelectCommandTermsCashTransactions.Parameters("@TerminalsOpenID").Value = activeTerminalsOpenID;

        // in the middle of try, catch
        sql.cn.Open();
        sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
        sql.SqlTermsCashTransactions.Fill(dsOrder.Tables("CashIn"));
        sql.SqlSelectCommandTermsCashTransactions.Parameters("@PaymentTypeID").Value = -3;
        sql.SqlTermsCashTransactions.Fill(dsOrder.Tables("CashOut"));
        sql.cn.Close();

    }

    internal static object ReadCashOutData(ref SqlClient.SqlCommand cmd, string cashType) // , ByRef cmd As SqlClient.SqlCommand)
    {

        var decimalAmount = default(decimal);
        SqlClient.SqlDataReader dtr;

        dtr = cmd.ExecuteReader;

        // If dtr.HasRows Then 'dtr.HasRows Then
        while (dtr.Read())
        {
            switch (cashType ?? "")
            {
                case var @case when @case == "Sales":
                    {
                        decimalAmount += dtr("PaymentAmount");
                        decimalAmount += dtr("Surcharge");
                        break;
                    }
                case var case1 when case1 == "Tip":
                    {
                        decimalAmount += dtr("Tip");
                        break;
                    }
            }
        }
        // Else
        // dtr.Close()
        // Return 0
        // Exit Function
        // End If


        dtr.Close();

        return decimalAmount;

    }

    internal static void StartDailyBusinessClose(int empID, long dc)
    {
        RawMaterial newRM;

        UpdateDailyBusinessClose(empID, dc);

        return;
        // 222
        // currently below does nothing
        // was meant to do adjustments in InvFoodCurrent
        // i think we now just do when we do Physical Inventory
        TempConnectToPhoenix();
        // ******* this is just for testing, later go local

        if (currentRawMaterials.Count == 0)
        {
            PopluateRawMatLast();
        }

        foreach (DataRow oRow in dsInventory.Tables("RawMatLast").Rows)
        {

            newRM.RawItemID = oRow("RawItemID");
            newRM.LastRecipeQuantity = oRow("RecipeQuantity");
            newRM.LastUnitCost = oRow("UnitCost");
            currentRawMaterials.Add(newRM);
        }

        foreach (RawMaterial currentNewRM in currentRawMaterials)
            // determine adjustments InvFoodCurrent View
            newRM = currentNewRM;

        ConnectBackFromTempDatabase();

    }

    internal static void PopluateRawMatLast()
    {

        dsInventory.Tables("RawMatLast").Rows.Clear();

        sql.SqlSelectCommandRawMatLast.Parameters("@CompanyID").Value = companyInfo.CompanyID;
        sql.SqlSelectCommandRawMatLast.Parameters("@LocationID").Value = companyInfo.LocationID; // customLocationString

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlRawMatLast.Fill(dsInventory.Tables("RawMatLast"));
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }

    }
    internal static void TransactionLoadInventory()
    {


    }

    internal static void OpenCashDrawer(decimal openAmount, int termPrimaryKey)
    {

        if (typeProgram == "Online_Demo")
        {
            demoCashOpen = openAmount; // NumberPadMedium1.NumberTotal
            return;
        }

        DataRow oRow = dsOrder.Tables("TermsOpen").NewRow;

        oRow("CompanyID") = companyInfo.CompanyID;
        oRow("LocationID") = companyInfo.LocationID;
        oRow("DailyCode") = currentTerminal.CurrentDailyCode;
        oRow("TerminalsPrimaryKey") = termPrimaryKey;
        if (actingManager is null)
        {
            oRow("OpenBy") = 0;
        }
        else
        {
            oRow("OpenBy") = actingManager.EmployeeID;
        }
        oRow("OpenTime") = DateTime.Now;
        oRow("OpenCash") = openAmount; // NumberPadMedium1.NumberTotal
        oRow("CloseBy") = DBNull.Value;
        oRow("CloseTime") = DBNull.Value;
        oRow("CloseCash") = DBNull.Value;
        oRow("CashIn") = DBNull.Value;
        oRow("CashOut") = DBNull.Value;
        oRow("OverShort") = DBNull.Value;
        oRow("ReasonShort") = DBNull.Value;

        oRow("TerminalsOpenID") = InsertNewTerminalsOpenData(ref oRow);
        currentTerminal.TerminalsOpenID = oRow("TerminalsOpenID");

        try
        {
            UpdateTermsOpen();
            dsOrder.Tables("TermsOpen").AcceptChanges();
        }

        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }

    }

    private static long InsertNewTerminalsOpenData(ref DataRow oRow)
    {

        var termOpenID = default(long);

        sql.SqlInsertCommandTermsOpen.Parameters("@CompanyID").Value = oRow("CompanyID");
        sql.SqlInsertCommandTermsOpen.Parameters("@LocationID").Value = oRow("LocationID");
        sql.SqlInsertCommandTermsOpen.Parameters("@DailyCode").Value = oRow("DailyCode");
        sql.SqlInsertCommandTermsOpen.Parameters("@TerminalsPrimaryKey").Value = oRow("TerminalsPrimaryKey");
        sql.SqlInsertCommandTermsOpen.Parameters("@OpenBy").Value = oRow("OpenBy");
        sql.SqlInsertCommandTermsOpen.Parameters("@OpenTime").Value = oRow("OpenTime");
        sql.SqlInsertCommandTermsOpen.Parameters("@OpenCash").Value = oRow("OpenCash");
        sql.SqlInsertCommandTermsOpen.Parameters("@CloseBy").Value = oRow("CloseBy");
        sql.SqlInsertCommandTermsOpen.Parameters("@CloseTime").Value = oRow("CloseTime");
        sql.SqlInsertCommandTermsOpen.Parameters("@CloseCash").Value = oRow("CloseCash");
        sql.SqlInsertCommandTermsOpen.Parameters("@CashIn").Value = oRow("CashIn");
        sql.SqlInsertCommandTermsOpen.Parameters("@CashOut").Value = oRow("CashOut");
        sql.SqlInsertCommandTermsOpen.Parameters("@OverShort").Value = oRow("OverShort");
        sql.SqlInsertCommandTermsOpen.Parameters("@ReasonShort").Value = oRow("ReasonShort");

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            termOpenID = (long)sql.SqlInsertCommandTermsOpen.ExecuteScalar;
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }

        return termOpenID;

    }

    internal static void UpdateTermsOpen()
    {

        // in the middle of try, catch
        sql.cn.Open();
        sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
        sql.SqlTermsOpen.Update(dsOrder.Tables("TermsOpen"));
        sql.cn.Close();

    }

    internal static void UpdateDailyBusinessClose(int empID, long dc)
    {

        try
        {
            foreach (DataRow oRow in dsOrder.Tables("OpenBusiness").Rows)
            {
                if (oRow("DailyCode") == dc)
                {
                    oRow("EndTime") = DateTime.Now;
                    oRow("EmployeeClosed") = empID;
                }
            }
        }
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);
        }
        // there is a xp_mapdown_bitmap problem here
        // this is caused by replication error or something
        // workaround, we gave public permission in Master db
        // SqlDbType.DateTime 
        // tName.Columns.Add("EndTime", Type.GetType("System.DateTime"))
        UpdateDailyBusiness();

    }

    internal static void SwitchToSecondaryMenu()
    {

        if (currentTerminal.currentPrimaryMenuID == currentTerminal.primaryMenuID)
        {
            currentTerminal.currentPrimaryMenuID = currentTerminal.secondaryMenuID;
            currentTerminal.currentSecondaryMenuID = currentTerminal.primaryMenuID;
        }
        else
        {
            currentTerminal.currentPrimaryMenuID = currentTerminal.primaryMenuID;
            currentTerminal.currentSecondaryMenuID = currentTerminal.secondaryMenuID;
        }

        foreach (DataRow oRow in dsOrder.Tables("OpenBusiness").Rows)
        {
            if (oRow("DailyCode") == currentTerminal.CurrentDailyCode)
            {
                oRow("PrimaryMenu") = currentTerminal.currentPrimaryMenuID;
                oRow("SecondaryMenu") = currentTerminal.currentSecondaryMenuID;
            }
        }

        UpdateDailyBusiness();

    }

    internal static void UpdateDailyBusiness()
    {

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlDataAdapterOpenBusiness.Update(dsOrder.Tables("OpenBusiness"));
            sql.cn.Close();
            dsOrder.Tables("OpenBusiness").AcceptChanges();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }

    }

    internal static void StartNewDaily()
    {
        long newDailyCode;

        try
        {
            newDailyCode = Conversions.ToLong(CreateNewDaily());
            currentTerminal.CurrentDailyCode = newDailyCode;
        }

        catch (Exception ex)
        {
            CloseConnection();
            if (Information.Err().Number == Conversions.ToDouble("5"))
            {
                ServerJustWentDown();
            }
        }

    }

    internal static object CreateNewDaily()
    {
        var bi = default(long);

        sql.SqlInsertCommandOpenBusiness.Parameters("@CompanyID").Value = companyInfo.CompanyID;
        sql.SqlInsertCommandOpenBusiness.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlInsertCommandOpenBusiness.Parameters("@StartTime").Value = DateTime.Now;
        sql.SqlInsertCommandOpenBusiness.Parameters("@EndTime").Value = DBNull.Value;
        if (actingManager is null)
        {
            sql.SqlInsertCommandOpenBusiness.Parameters("@EmployeeOpened").Value = 0;
        }
        else
        {
            sql.SqlInsertCommandOpenBusiness.Parameters("@EmployeeOpened").Value = actingManager.EmployeeID;
        }
        sql.SqlInsertCommandOpenBusiness.Parameters("@EmployeeClosed").Value = DBNull.Value;
        sql.SqlInsertCommandOpenBusiness.Parameters("@PrimaryMenu").Value = currentTerminal.primaryMenuID;
        sql.SqlInsertCommandOpenBusiness.Parameters("@SecondaryMenu").Value = currentTerminal.secondaryMenuID;
        sql.SqlInsertCommandOpenBusiness.Parameters("@ShiftID").Value = currentTerminal.CurrentShift;
        sql.SqlInsertCommandOpenBusiness.Parameters("@InvCounted").Value = 0;

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            bi = (long)sql.SqlInsertCommandOpenBusiness.ExecuteScalar;
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
            ServerJustWentDown();
        }

        // 444    currentTerminal.CurrentMenuID = currentTerminal.primaryMenuID
        // 444   currentTerminal.initPrimaryMenuID = currentTerminal.primaryMenuID
        // 444  currentTerminal.currentPrimaryMenuID = currentTerminal.primaryMenuID

        return bi;

    }

    internal static void InsertBatchInfo(ref BatchInfo batch, long closingDailyCode)
    {
        return;

        SqlClient.SqlCommand cmd;

        cmd = new SqlClient.SqlCommand("INSERT INTO Batch(CompanyID, LocationID, DailyCode, BatchNetCount, BatchNetDollar, BatchCreditPurchaseCount, BatchCreditPurchaseDollar, BatchCreditReturnCount, BatchCreditReturnDollar, BatchDebitPurchaseCount, BatchDebitPurchaseDollar, BatchDebitReturnCount, BatchDebitReturnDollar) VALUES (@CompanyID, @LocationID, @DailyCode, @BatchNetCount, @BatchNetDollar, @BatchCreditPurchaseCount, @BatchCreditPurchaseDollar, @BatchCreditReturnCount, @BatchCreditReturnDollar, @BatchDebitPurchaseCount, @BatchDebitPurchaseDollar, @BatchDebitReturnCount, @BatchDebitReturnDollar)", sql.cn);  // ; SELECT  BatchID, CompanyID, LocationID, DailyCode, BatchNetCount, BatchNetDollar, BatchCreditPurchaseCount, BatchCreditPurcahaseDollar, BatchCreditReturnCount, BatchCreditReturnDollar, BatchDebitPurchaseCount, BatchDebitPurcahaseDollar, BatchDebitReturnCount, BatchDebitReturnDollar WHERE (BatchID = @@IDENTITY)", sql.cn)

        cmd.Parameters.Add(new SqlClient.SqlParameter("@CompanyID", SqlDbType.NChar, 6));
        cmd.Parameters("@CompanyID").Value = companyInfo.CompanyID;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@LocationID", SqlDbType.NChar, 6));
        cmd.Parameters("@LocationID").Value = companyInfo.LocationID;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@DailyCode", SqlDbType.BigInt, 8));
        cmd.Parameters("@DailyCode").Value = closingDailyCode;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@BatchNumber", SqlDbType.NVarChar, 10));
        cmd.Parameters("@BatchNumber").Value = batch.batchNumber;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@BatchNetCount", SqlDbType.SmallInt, 2));
        cmd.Parameters("@BatchNetCount").Value = batch.NetCount;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@BatchNetDollar", SqlDbType.Decimal, 9));
        cmd.Parameters("@BatchNetDollar").Value = batch.NetDollar;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@BatchCreditPurchaseCount", SqlDbType.SmallInt, 2));
        cmd.Parameters("@BatchCreditPurchaseCount").Value = batch.CreditPurchaseCount;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@BatchCreditPurchaseDollar", SqlDbType.Decimal, 9));
        cmd.Parameters("@BatchCreditPurchaseDollar").Value = batch.CreditPurchaseDollar;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@BatchCreditReturnCount", SqlDbType.SmallInt, 2));
        cmd.Parameters("@BatchCreditReturnCount").Value = batch.CreditReturnCount;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@BatchCreditReturnDollar", SqlDbType.Decimal, 9));
        cmd.Parameters("@BatchCreditReturnDollar").Value = batch.CreditReturnDollar;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@BatchDebitPurchaseCount", SqlDbType.SmallInt, 2));
        cmd.Parameters("@BatchDebitPurchaseCount").Value = batch.DebitPurchaseCount;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@BatchDebitPurchaseDollar", SqlDbType.Decimal, 9));
        cmd.Parameters("@BatchDebitPurchaseDollar").Value = batch.DebitPurchaseDollar;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@BatchDebitReturnCount", SqlDbType.SmallInt, 2));
        cmd.Parameters("@BatchDebitReturnCount").Value = batch.DebitReturnCount;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@BatchDebitReturnDollar", SqlDbType.Decimal, 9));
        cmd.Parameters("@BatchDebitReturnDollar").Value = batch.DebitReturnDollar;

        try
        {
            TempConnectToPhoenix();
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            sql.cn.Close();
            ConnectBackFromTempDatabase();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }

    }

    internal static object CreateNewOrder(ref OrderDetailInfo oDetail)
    {
        DataTable dsChangedDetail;

        try
        {
            // in case there was an order delivered
            dsChangedDetail = dsOrder.Tables("OrderDetail").GetChanges;

            if (dsChangedDetail is not null)
            {
                if (typeProgram == "Online_Demo")
                {
                    dsOrderDemo.Merge(dsOrder.Tables("OrderDetail"), false, MissingSchemaAction.Add);
                    dsOrder.Tables("OrderDetail").AcceptChanges();
                }
                else
                {
                    sql.cn.Open();
                    sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
                    sql.SqlDataAdapterOrderDetail.Update(dsChangedDetail); // (dsOrder, "OrderDetail")
                    sql.cn.Close();
                    dsOrder.Tables("OrderDetail").AcceptChanges();
                }
            }
        }

        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
            ServerJustWentDown();
        }

        DataRow oRow;
        oRow = dsOrder.Tables("OrderDetail").NewRow;

        oRow("CompanyID") = companyInfo.CompanyID;
        oRow("LocationID") = companyInfo.LocationID;
        oRow("DailyCode") = currentTerminal.CurrentDailyCode;
        oRow("ExperienceNumber") = currentTable.ExperienceNumber;
        oRow("OrderTime") = oDetail.orderTime;
        oRow("OrderFilled") = DBNull.Value;      // time filled
        oRow("OrderReady") = DBNull.Value;       // time ready
        oRow("NumberOfDinners") = oDetail.NumDinners;
        oRow("NumberOfApps") = oDetail.numApps;
        oRow("NumberOfDrinks") = oDetail.numDrinks;
        oRow("isMainCourse") = oDetail.isMainCourse;
        oRow("TotalDollar") = oDetail.totalDollar;
        oRow("AvgDollar") = DBNull.Value;    // oDetail.totalDollar

        if (typeProgram == "Online_Demo")
        {
            oRow("OrderNumber") = demoOrderNumber;
            demoOrderNumber += 1;
            dsOrder.Tables("OrderDetail").Rows.Add(oRow);
            return oRow("OrderNumber");
            return default;
        }

        dsOrder.Tables("OrderDetail").Rows.Add(oRow);
        oRow("OrderNumber") = InsertNewOrder(ref oRow);
        dsOrder.Tables("OrderDetail").AcceptChanges();

        return oRow("OrderNumber");

        // I tried below without saving first and accepting
        // but it adds two orders
        // if we just make oRow = InsertNewOrder, we get concurrent violation
        // newOrderNum = InsertNewOrder(oRow)
        // Return newOrderNum

    }

    private static object InsertNewOrder(ref DataRow oRow)
    {
        var ordNum = default(long);
        SqlClient.SqlCommand cmd;

        sql.SqlInsertCommandOrderDetail.Parameters("@CompanyID").Value = companyInfo.CompanyID;
        sql.SqlInsertCommandOrderDetail.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlInsertCommandOrderDetail.Parameters("@DailyCode").Value = currentTerminal.CurrentDailyCode;
        sql.SqlInsertCommandOrderDetail.Parameters("@ExperienceNumber").Value = currentTable.ExperienceNumber;
        sql.SqlInsertCommandOrderDetail.Parameters("@OrderTime").Value = oRow("OrderTime");
        sql.SqlInsertCommandOrderDetail.Parameters("@OrderFilled").Value = oRow("OrderFilled");
        sql.SqlInsertCommandOrderDetail.Parameters("@OrderReady").Value = oRow("OrderReady");
        sql.SqlInsertCommandOrderDetail.Parameters("@NumberOfDinners").Value = oRow("NumberOfDinners");
        sql.SqlInsertCommandOrderDetail.Parameters("@NumberOfApps").Value = oRow("NumberOfApps");
        sql.SqlInsertCommandOrderDetail.Parameters("@NumberOfDrinks").Value = oRow("NumberOfDrinks");
        sql.SqlInsertCommandOrderDetail.Parameters("@isMainCourse").Value = oRow("isMainCourse");
        sql.SqlInsertCommandOrderDetail.Parameters("@TotalDollar").Value = oRow("TotalDollar");
        sql.SqlInsertCommandOrderDetail.Parameters("@AvgDollar").Value = oRow("AvgDollar");

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            ordNum = (long)sql.SqlInsertCommandOrderDetail.ExecuteScalar;
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);

        }

        return ordNum;

    }

    internal static void VerifyTabInfoDataLength(ref TabInfo currenttabinfo)
    {


        if (currenttabinfo.AccountNumber is not null)
        {
            if (currenttabinfo.AccountNumber.Length > 10)
            {
                currenttabinfo.AccountNumber = currenttabinfo.AccountNumber.Substring(0, 10);
            }
        }
        if (currenttabinfo.AccountPhone is not null)
        {
            if (currenttabinfo.AccountPhone.Length > 10)
            {
                currenttabinfo.AccountPhone = currenttabinfo.AccountPhone.Substring(0, 10);
            }
        }
        if (currenttabinfo.LastName is not null)
        {
            if (currenttabinfo.LastName.Length > 20)
            {
                currenttabinfo.LastName = currenttabinfo.LastName.Substring(0, 20);
            }
        }
        if (currenttabinfo.FirstName is not null)
        {
            if (currenttabinfo.FirstName.Length > 10)
            {
                currenttabinfo.FirstName = currenttabinfo.FirstName.Substring(0, 10);
            }
        }
        if (currenttabinfo.MiddleName is not null)
        {
            if (currenttabinfo.MiddleName.Length > 10)
            {
                currenttabinfo.MiddleName = currenttabinfo.MiddleName.Substring(0, 10);
            }
        }
        if (currenttabinfo.NickName is not null)
        {
            if (currenttabinfo.NickName.Length > 20)
            {
                currenttabinfo.NickName = currenttabinfo.NickName.Substring(0, 20);
            }
        }
        if (currenttabinfo.Address1 is not null)
        {
            if (currenttabinfo.Address1.Length > 50)
            {
                currenttabinfo.Address1 = currenttabinfo.Address1.Substring(0, 50);
            }
        }
        if (currenttabinfo.Address2 is not null)
        {
            if (currenttabinfo.Address2.Length > 50)
            {
                currenttabinfo.Address2 = currenttabinfo.Address2.Substring(0, 50);
            }
        }
        if (currenttabinfo.City is not null)
        {
            if (currenttabinfo.City.Length > 15)
            {
                currenttabinfo.City = currenttabinfo.City.Substring(0, 15);
            }
        }
        if (currenttabinfo.State is not null)
        {
            if (currenttabinfo.State.Length > 15)
            {
                currenttabinfo.State = currenttabinfo.State.Substring(0, 15);
            }
        }
        if (currenttabinfo.PostalCode is not null)
        {
            if (currenttabinfo.PostalCode.Length > 10)
            {
                currenttabinfo.PostalCode = currenttabinfo.PostalCode.Substring(0, 10);
            }
        }
        if (currenttabinfo.Phone1 is not null)
        {
            if (currenttabinfo.Phone1.Length > 24)
            {
                currenttabinfo.Phone1 = currenttabinfo.Phone1.Substring(0, 24);
            }
        }
        if (currenttabinfo.Ext1 is not null)
        {
            if (currenttabinfo.Ext1.Length > 4)
            {
                currenttabinfo.Ext1 = currenttabinfo.Ext1.Substring(0, 4);
            }
        }
        if (currenttabinfo.Phone2 is not null)
        {
            if (currenttabinfo.Phone2.Length > 24)
            {
                currenttabinfo.Phone2 = currenttabinfo.Phone2.Substring(0, 24);
            }
        }
        if (currenttabinfo.Ext2 is not null)
        {
            if (currenttabinfo.Ext2.Length > 4)
            {
                currenttabinfo.Ext2 = currenttabinfo.Ext2.Substring(0, 4);
            }
        }
        if (currenttabinfo.CrossRoads is not null)
        {
            if (currenttabinfo.CrossRoads.Length > 50)
            {
                currenttabinfo.CrossRoads = currenttabinfo.CrossRoads.Substring(0, 50);
            }
        }

        if (currenttabinfo.SpecialInstructions is not null)
        {
            if (currenttabinfo.SpecialInstructions.Length > 255)
            {
                currenttabinfo.SpecialInstructions = currenttabinfo.SpecialInstructions.Substring(0, 255);
            }

        }

    }
    internal static object CreateNewTabInfoData(TabInfo currentTabInfo, string startInSearch)
    {

        DataTable dsChangedDetail;
        dsChangedDetail = dsCustomer.Tables("TabDirectorySearch").GetChanges;
        // in case there was an order delivered
        if (dsChangedDetail is not null)
        {
            UpdateTabInfo(startInSearch);
        }

        VerifyTabInfoDataLength(ref currentTabInfo);

        DataRow oRow;
        oRow = dsCustomer.Tables("TabDirectorySearch").NewRow;

        oRow("CompanyID") = companyInfo.CompanyID;
        oRow("LocationID") = companyInfo.LocationID;
        if (currentTabInfo.AccountNumber is not null)
        {
            if (currentTabInfo.AccountNumber.Length == 0)
            {
                oRow("AccountNumber") = DBNull.Value;
            }
            else
            {
                oRow("AccountNumber") = currentTabInfo.AccountNumber;
            }
        }
        else
        {
            oRow("AccountNumber") = DBNull.Value;
        }
        if (currentTabInfo.AccountPhone is not null)
        {
            if (currentTabInfo.AccountPhone.Length == 0)
            {
                oRow("AccountPhone") = DBNull.Value;
            }
            else
            {
                oRow("AccountPhone") = currentTabInfo.AccountPhone;
            }
        }
        else
        {
            oRow("AccountPhone") = DBNull.Value;
        }

        // MsgBox(currentTabInfo.LastName)
        oRow("LastName") = currentTabInfo.LastName;
        oRow("FirstName") = currentTabInfo.FirstName;
        oRow("MiddleName") = currentTabInfo.MiddleName;
        oRow("NickName") = currentTabInfo.NickName;
        oRow("Address1") = currentTabInfo.Address1;
        oRow("Address2") = currentTabInfo.Address2;
        oRow("City") = currentTabInfo.City;
        oRow("State") = currentTabInfo.State;
        oRow("PostalCode") = currentTabInfo.PostalCode;
        oRow("Country") = currentTabInfo.Country;
        oRow("Phone1") = currentTabInfo.Phone1;
        oRow("Ext1") = currentTabInfo.Ext1;
        oRow("Phone2") = currentTabInfo.Phone2;
        oRow("Ext2") = currentTabInfo.Ext2;
        oRow("DeliveryZone") = 0; // currentTabInfo.DeliverZone
        oRow("CrossRoads") = currentTabInfo.CrossRoads;
        oRow("SpecialInstructions") = currentTabInfo.SpecialInstructions;
        oRow("DoNotDeliver") = currentTabInfo.DoNotDeliver;
        oRow("VIP") = currentTabInfo.VIP;
        oRow("UpdatedDate") = currentTabInfo.UpdatedDate;
        oRow("UpdatedByEmployee") = currentTabInfo.UpdatedByEmployee;
        oRow("Active") = currentTabInfo.Active;
        oRow("OpenChar1") = currentTabInfo.Email;

        if (typeProgram == "Online_Demo")
        {
            oRow("TabID") = demoTabID;
            demoTabID += 1;
            dsCustomer.Tables("TabDirectorySearch").Rows.Add(oRow);
            dsCustomerDemo.Merge(dsCustomer.Tables("TabDirectorySearch"), false, MissingSchemaAction.Add);
            dsCustomer.Tables("TabDirectorySearch").AcceptChanges();
            return oRow("TabID");
            return default;
        }

        // *************
        // testing below, when Insert Fails
        // if works - need to replicate for all Inserts
        dsCustomer.Tables("TabDirectorySearch").Rows.Add(oRow);
        oRow("TabID") = InsertNewTabInfo(ref oRow);
        if (oRow("TabID") == -1)
        {
            dsCustomer.Tables("TabDirectorySearch").RejectChanges();
        }
        else
        {
            dsCustomer.Tables("TabDirectorySearch").AcceptChanges();
        }

        return oRow("TabID");

    }

    private static object InsertNewTabInfo(ref DataRow oRow)
    {
        long tabInfoID;
        SqlClient.SqlCommand cmd;

        sql.SqlInsertCommandTabStorePhone.Parameters("@CompanyID").Value = companyInfo.CompanyID;
        sql.SqlInsertCommandTabStorePhone.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlInsertCommandTabStorePhone.Parameters("@AccountNumber").Value = oRow("AccountNumber");
        sql.SqlInsertCommandTabStorePhone.Parameters("@AccountPhone").Value = oRow("AccountPhone");
        sql.SqlInsertCommandTabStorePhone.Parameters("@LastName").Value = oRow("LastName");
        sql.SqlInsertCommandTabStorePhone.Parameters("@FirstName").Value = oRow("FirstName");
        sql.SqlInsertCommandTabStorePhone.Parameters("@MiddleName").Value = oRow("MiddleName");
        sql.SqlInsertCommandTabStorePhone.Parameters("@NickName").Value = oRow("NickName");
        sql.SqlInsertCommandTabStorePhone.Parameters("@Address1").Value = oRow("Address1");
        sql.SqlInsertCommandTabStorePhone.Parameters("@Address2").Value = oRow("Address2");
        sql.SqlInsertCommandTabStorePhone.Parameters("@City").Value = oRow("City");
        sql.SqlInsertCommandTabStorePhone.Parameters("@State").Value = oRow("State");
        sql.SqlInsertCommandTabStorePhone.Parameters("@PostalCode").Value = oRow("PostalCode");
        sql.SqlInsertCommandTabStorePhone.Parameters("@Country").Value = oRow("Country");
        sql.SqlInsertCommandTabStorePhone.Parameters("@Phone1").Value = oRow("Phone1");
        sql.SqlInsertCommandTabStorePhone.Parameters("@Ext1").Value = oRow("Ext1");
        sql.SqlInsertCommandTabStorePhone.Parameters("@Phone2").Value = oRow("Phone2");
        sql.SqlInsertCommandTabStorePhone.Parameters("@Ext2").Value = oRow("Ext2");
        sql.SqlInsertCommandTabStorePhone.Parameters("@DeliveryZone").Value = oRow("DeliveryZone");
        sql.SqlInsertCommandTabStorePhone.Parameters("@CrossRoads").Value = oRow("CrossRoads");
        sql.SqlInsertCommandTabStorePhone.Parameters("@SpecialInstructions").Value = oRow("SpecialInstructions");
        sql.SqlInsertCommandTabStorePhone.Parameters("@DoNotDeliver").Value = oRow("DoNotDeliver");
        sql.SqlInsertCommandTabStorePhone.Parameters("@VIP").Value = oRow("VIP");
        sql.SqlInsertCommandTabStorePhone.Parameters("@UpdatedDate").Value = oRow("UpdatedDate");
        sql.SqlInsertCommandTabStorePhone.Parameters("@UpdatedByEmployee").Value = oRow("UpdatedByEmployee");
        sql.SqlInsertCommandTabStorePhone.Parameters("@Active").Value = oRow("Active");
        sql.SqlInsertCommandTabStorePhone.Parameters("@OpenChar1").Value = oRow("OpenChar1");

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            tabInfoID = (long)sql.SqlInsertCommandTabStorePhone.ExecuteScalar;
            sql.cn.Close();
            return tabInfoID;
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
            return -1;
        }

    }

    internal static void UpdateTabInfo(string startInSearch)
    {

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            if (startInSearch == "Account")
            {
                sql.SqlTabStoreAccountLocation.Update(dsCustomer.Tables("TabDirectorySearch"));
            }
            else if (startInSearch == "Phone")
            {
                sql.SqlTabStorePhoneLocation.Update(dsCustomer.Tables("TabDirectorySearch"));
            }
            else if (startInSearch == "TabID")
            {
                sql.SqlTabStoreTabIDLocation.Update(dsCustomer.Tables("TabDirectorySearch"));
            }
            sql.cn.Close();
        }

        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);

        }

        dsCustomer.Tables("TabDirectorySearch").AcceptChanges();

    }

    internal static void PopulateSearchPhone(string searchCriteriaString) // , ByVal searchTabID As Int64)
    {


        // MsgBox(dsCustomer.Tables("TabDirectorySearch").Rows.Count)
        // MsgBox(dsCustomerDemo.Tables("TabDirectorySearch").Rows.Count)
        // MsgBox(dsCustomer.Tables("TabDirectorySearch").Rows(0)("TabID"))
        // MsgBox(dsCustomerDemo.Tables("TabDirectorySearch").Rows(0)("TabID"))

        dsCustomer.Tables("TabDirectorySearch").Rows.Clear();

        if (typeProgram == "Online_Demo")
        {
            if (!(searchCriteriaString == "BlankSearch"))
            {
                string filterString;
                filterString = "AccountPhone = " + searchCriteriaString;
                var argdtTO = dsCustomer.Tables("TabDirectorySearch");
                Demo_FilterDontDelete(dsCustomerDemo.Tables("TabDirectorySearch"), ref argdtTO, filterString);
            }
            return;
        }

        sql.SqlSelectCommandTabStorePhone.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlSelectCommandTabStorePhone.Parameters("@AccountPhone").Value = searchCriteriaString;
        // sql.SqlSelectCommandTabStorePhone.Parameters("@TabID").Value = searchTabID
        // sql.SqlSelectCommandTabStorePhone.Parameters("@AccountNumber").Value = "****----****----"

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlTabStorePhoneLocation.Fill(dsCustomer.Tables("TabDirectorySearch"));
            // ccc       dsCustomer.WriteXml("CustomerData.xml", XmlWriteMode.WriteSchema)
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }


    }

    internal static object CreateAccountNumber(ref DataSet_Builder.Payment newPayment) // ByVal lname As String, ByVal anumber As String)
    {

        // this is for TabOverview, Tab account number

        var spiderAcct = default(string);
        int acctNumLength;

        if (newPayment.PaymentTypeName == "MPS Gift")
        {
            if (newPayment.AccountNumber > 7)
            {
                spiderAcct = "MPS" + newPayment.AccountNumber.Substring(newPayment.AccountNumber.Length - 7, 7);
            }
            else
            {
                spiderAcct = "MPS" + newPayment.AccountNumber;
            }
        }
        else
        {
            // credit cards
            switch (newPayment.LastName.Length)
            {
                // this takes first 5 didgits of last name
                case 0:
                    {
                        spiderAcct = companyInfo.CompanyID.Substring(0, 5); // "xxxx"
                        break;
                    }
                case 1:
                    {
                        spiderAcct = newPayment.LastName.Substring(0, 1) + "xxxx";
                        break;
                    }
                case 2:
                    {
                        spiderAcct = newPayment.LastName.Substring(0, 2) + "xxx";
                        break;
                    }
                case 3:
                    {
                        spiderAcct = newPayment.LastName.Substring(0, 3) + "xx";
                        break;
                    }
                case 4:
                    {
                        spiderAcct = newPayment.LastName.Substring(0, 4) + "x";
                        break;
                    }
                case var @case when @case > 4:
                    {
                        spiderAcct = newPayment.LastName.Substring(0, 5);
                        break;
                    }
            }

            acctNumLength = newPayment.AccountNumber.Length;

            if (acctNumLength < 4)
            {
                spiderAcct = spiderAcct + newPayment.AccountNumber;
            }
            else
            {
                // this takes last 4 digits of account number
                spiderAcct = spiderAcct + newPayment.AccountNumber.Substring(acctNumLength - 4, 4);
            }
        }

        return spiderAcct;

    }

    internal static void PopulateSearchAccount(string searchCriteriaString) // , ByVal searchTabID As Int64)
    {
        // If searchCriteriaString = "****----****----" Then
        // filterString = "TabID = " & searchTabID
        // Else
        // filterString = "AccountPhone = " & searchCriteriaString
        // End If

        dsCustomer.Tables("TabDirectorySearch").Rows.Clear();

        if (typeProgram == "Online_Demo")
        {
            string filterString;
            filterString = "AccountNumber = " + searchCriteriaString;
            var argdtTO = dsCustomer.Tables("TabDirectorySearch");
            Demo_FilterDontDelete(dsCustomerDemo.Tables("TabDirectorySearch"), ref argdtTO, filterString);
            return;
        }

        sql.SqlSelectCommandAccountLocation.Parameters("@LocationID").Value = companyInfo.LocationID;
        // sql.SqlSelectCommandTabStorePhone.Parameters("@AccountPhone").Value = "****----****----"
        // sql.SqlSelectCommandTabStorePhone.Parameters("@TabID").Value = searchTabID
        sql.SqlSelectCommandAccountLocation.Parameters("@AccountNumber").Value = searchCriteriaString;

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlTabStoreAccountLocation.Fill(dsCustomer.Tables("TabDirectorySearch"));
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }

    }

    internal static void PopulateSearchTabID(string searchCriteriaString) // , ByVal searchTabID As Int64)
    {

        dsCustomer.Tables("TabDirectorySearch").Rows.Clear();

        if (typeProgram == "Online_Demo")
        {
            string filterString;
            filterString = "TabID = " + searchCriteriaString;
            var argdtTO = dsCustomer.Tables("TabDirectorySearch");
            Demo_FilterDontDelete(dsCustomerDemo.Tables("TabDirectorySearch"), ref argdtTO, filterString);
            return;
        }

        sql.SqlSelectCommandTabStoreTabIDLocation.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlSelectCommandTabStoreTabIDLocation.Parameters("@TabID").Value = searchCriteriaString;

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlTabStoreTabIDLocation.Fill(dsCustomer.Tables("TabDirectorySearch"));
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }

    }

    internal static void CreateTabAcctPlaceInExperience(ref DataSet_Builder.Payment newPayment)
    {
        // ****   must have experience created before this step

        DataRow oRow;
        var changedTabID = default(bool);

        if (currentTable.TruncatedExpNum is not null)
        {
            // i think this is only for mercury Gift
            newPayment.RefNo = currentTable.TruncatedExpNum.ToString;
        }
        else
        {
            newPayment.RefNo = 0;
        }

        // placing account infomation into experience
        // moved to readAuth and MWE
        // 444 newPayment.SpiderAcct = CreateAccountNumber(newPayment) '.LastName, newPayment.AccountNumber)

        PopulateSearchAccount(newPayment.SpiderAcct); // , -123456789)

        if (dsCustomer.Tables("TabDirectorySearch").Rows.Count == 0)
        {
            // must create the account

            var currentTabInfo = new TabInfo();
            currentTabInfo.AccountNumber = newPayment.SpiderAcct;   // AccountNumber
            currentTabInfo.LastName = newPayment.LastName;
            currentTabInfo.FirstName = newPayment.FirstName;
            currentTabInfo.DeliverZone = 0;  // ****** needs to be INT **** CInt(Me.lblNewTabDeliveryZone.Text)
            currentTabInfo.DoNotDeliver = false;
            currentTabInfo.VIP = false;
            currentTabInfo.UpdatedDate = DateTime.Now;
            currentTabInfo.UpdatedByEmployee = currentTable.EmployeeID;
            currentTabInfo.Active = true;
            if (!(currentTable.TabID > 0))
            {
                currentTable.TabID = CreateNewTabInfoData(currentTabInfo, "TabID");
                TestToReplaceTabName(newPayment.Name);
                newPayment.TabID = currentTable.TabID;
                changedTabID = true;
            }
            else
            {
                newPayment.TabID = CreateNewTabInfoData(currentTabInfo, "TabID");
                changedTabID = true;
            }
        }

        else if (dsCustomer.Tables("TabDirectorySearch").Rows.Count == 1)
        {

            if (!(currentTable.TabID == -888) | !(currentTable.TabID == -777))
            {
                // this is group tabs                'return

            }

            // *** we are only adjusting Tab Info if nothing there
            // if we swipe from Seating Tab, we will always adjust in Login.CardReadSuccessful
            // if we swipe from Delivery, we will always adjust also in Login.TabIDTest (after saving)
            // ***
            if (!(currentTable.TabID > 0)) // = dsCustomer.Tables("TabDirectorySearch").Rows(0)("TabID") Then ' > 0 Then
            {
                currentTable.TabID = dsCustomer.Tables("TabDirectorySearch").Rows(0)("TabID");
                newPayment.TabID = currentTable.TabID;
                TestToReplaceTabName(newPayment.Name);
                changedTabID = true;
            }
            else
            {
                newPayment.TabID = dsCustomer.Tables("TabDirectorySearch").Rows(0)("TabID");
            }
        }

        else if (dsCustomer.Tables("TabDirectorySearch").Rows.Count > 1)
        {
            // giving credit to last account if there are mult accounts
            if (!(currentTable.TabID == -888) | !(currentTable.TabID == -777))
            {
                // this is group tabs                'return

            }
            if (!(currentTable.TabID > 0))
            {
                currentTable.TabID = dsCustomer.Tables("TabDirectorySearch").Rows(dsCustomer.Tables("TabDirectorySearch").Rows.Count - 1)("TabID");
                TestToReplaceTabName(newPayment.Name);
                newPayment.TabID = currentTable.TabID;
                changedTabID = true;
            }
            else
            {
                newPayment.TabID = dsCustomer.Tables("TabDirectorySearch").Rows(dsCustomer.Tables("TabDirectorySearch").Rows.Count - 1)("TabID");
            }


        }

        // **** currently not giving tab Credit for Quick Tickets or Beth's Tabs
        if (changedTabID == true)
        {
            if (currentTerminal.TermMethod == "Quick") // Or currentTable.TicketNumber > 0 Then 'currentTable.TabID = -888 Then
            {
                // (ticket Number > 0 for both Quick and Beth's Tabs
                foreach (DataRow currentORow in dsOrder.Tables("QuickTickets").Rows)
                {
                    oRow = currentORow;
                    if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        oRow("TabID") = currentTable.TabID;
                        oRow("TabName") = currentTable.TabName;
                    }
                }
            }
            else if (currentTable.IsTabNotTable == false)
            {
                foreach (DataRow currentORow1 in dsOrder.Tables("AvailTables").Rows)
                {
                    oRow = currentORow1;
                    if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        oRow("TabID") = currentTable.TabID;
                        oRow("TabName") = currentTable.TabName; // 444 not on tables    
                        break;
                    }
                }
            }
            // sss          SaveAvailTabsAndTables()
            else
            {
                foreach (DataRow currentORow2 in dsOrder.Tables("AvailTabs").Rows)
                {
                    oRow = currentORow2;
                    if (oRow("ExperienceNumber") == currentTable.ExperienceNumber)
                    {
                        oRow("TabID") = currentTable.TabID;
                        oRow("TabName") = currentTable.TabName;
                        break;
                    }
                }
                // sss            SaveAvailTabsAndTables()
            }
        }

    }


    private static void TestToReplaceTabName(string tn)
    {

        if (currentTable.TabName.Length == 0 | currentTable.TabName == "Dine In Tab" | currentTable.TabName == "Take Out Tab" | currentTable.TabName == "Pickup Tab")
        {
            currentTable.TabName = tn;
        }
    }


    internal static object CreateNewOrderForceFree222(ref ForceFreeInfo ffInfo)
    {
        long bi;

        SqlClient.SqlCommand cmd;

        cmd = new SqlClient.SqlCommand("INSERT INTO OrderForceFree(CompanyID, LocationID, EmployeeID, DailyCode, ExperienceNumber, OpenOrderID, ForceFreeAuth, ForceFreePrice, ForceFreeTaxPrice, ForceFreeTaxID, AmountDiscount, TaxDiscount, AdjID, AdjPrice, CompID, CompPrice, VoidID, VoidPrice, PromoID, PromoPrice, TransferID, TransferPrice, TransferToEmployeeID) VALUES ( @CompanyID, @LocationID, @EmployeeID, @DailyCode, @ExperienceNumber, @OpenOrderID, @ForceFreeAuth, @ForceFreePrice, @ForceFreeTaxPrice, @ForceFreeTaxID, @AmountDiscount, @TaxDiscount, @AdjID, @AdjPrice, @CompID, @CompPrice, @VoidID, @VoidPrice, @PromoID, @PromoPrice, @TransferID, @TransferPrice, @TransferToEmployeeID); SELECT ForceFreeID, CompanyID, LocationID, EmployeeID, DailyCode, OpenOrderID, ForceFreeAuth, ForceFreePrice, ForceFreeTaxPrice, ForceFreeTaxID, CompID, CompPrice, VoidID, VoidPrice, PromoID, PromoPrice, TransferID, TransferPrice, TransferToEmployeeID FROM OrderForceFree WHERE (ForceFreeID = @@IDENTITY)", sql.cn);
        // cmd.Parameters.Add(New SqlClient.SqlParameter("@DailyCode", SqlDbType.BigInt, 8))
        // cmd.Parameters("@DailyCode").Value = currentTerminal.currentDailyCode
        cmd.Parameters.Add(new SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.BigInt, 8, System.Data.ParameterDirection.ReturnValue, false, (byte)0, (byte)0, "", System.Data.DataRowVersion.Current, (object)null));

        cmd.Parameters.Add(new SqlClient.SqlParameter("@CompanyID", SqlDbType.NChar, 6));
        cmd.Parameters("@CompanyID").Value = companyInfo.CompanyID;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@LocationID", SqlDbType.NChar, 6));
        cmd.Parameters("@LocationID").Value = companyInfo.LocationID;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@EmployeeID", SqlDbType.Int, 4));
        cmd.Parameters("@EmployeeID").Value = currentTable.EmployeeID;
        cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DailyCode", System.Data.SqlDbType.BigInt, 8));
        cmd.Parameters("@DailyCode").Value = ffInfo.DailyCode;    // currentTerminal.currentDailyCode
        cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExperienceNumber", System.Data.SqlDbType.BigInt, 8));
        cmd.Parameters("@ExperienceNumber").Value = ffInfo.ExpNum;
        cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OpenOrderID", System.Data.SqlDbType.BigInt, 8));
        cmd.Parameters("@OpenOrderID").Value = ffInfo.OpenOrderID;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@ForceFreeAuth", SqlDbType.Int, 4));
        cmd.Parameters("@ForceFreeAuth").Value = ffInfo.AuthID;
        cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ForceFreePrice", System.Data.SqlDbType.Decimal, 5));
        cmd.Parameters("@ForceFreePrice").Value = ffInfo.Price;
        cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ForceFreeTaxPrice", System.Data.SqlDbType.Decimal, 5));
        cmd.Parameters("@ForceFreeTaxPrice").Value = ffInfo.TaxPrice;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@ForceFreeTaxID", SqlDbType.Int, 4));
        cmd.Parameters("@ForceFreeTaxID").Value = ffInfo.TaxID;
        cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AmountDiscount", System.Data.SqlDbType.Decimal, 5));
        cmd.Parameters("@AmountDiscount").Value = ffInfo.AmountDiscount;
        cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TaxDiscount", System.Data.SqlDbType.Decimal, 5));
        cmd.Parameters("@TaxDiscount").Value = ffInfo.TaxDicount;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@AdjID", SqlDbType.Int, 4));
        cmd.Parameters("@AdjID").Value = ffInfo.AdjID;
        cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AdjPrice", System.Data.SqlDbType.Decimal, 5));
        cmd.Parameters("@AdjPrice").Value = ffInfo.AdjPrice;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@CompID", SqlDbType.Int, 4));
        cmd.Parameters("@CompID").Value = ffInfo.CompID;
        cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompPrice", System.Data.SqlDbType.Decimal, 5));
        cmd.Parameters("@CompPrice").Value = ffInfo.CompPrice;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@VoidID", SqlDbType.Int, 4));
        cmd.Parameters("@VoidID").Value = ffInfo.VoidID;
        cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VoidPrice", System.Data.SqlDbType.Decimal, 5));
        cmd.Parameters("@VoidPrice").Value = ffInfo.VoidPrice;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@PromoID", SqlDbType.Int, 4));
        cmd.Parameters("@PromoID").Value = ffInfo.PromoID;
        cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PromoPrice", System.Data.SqlDbType.Decimal, 5));
        cmd.Parameters("@PromoPrice").Value = ffInfo.PromoPrice;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@TransferID", SqlDbType.Int, 4));
        cmd.Parameters("@TransferID").Value = ffInfo.TransferID;
        cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TransferPrice", System.Data.SqlDbType.Decimal, 5));
        cmd.Parameters("@TransferPrice").Value = ffInfo.TransferPrice;
        cmd.Parameters.Add(new SqlClient.SqlParameter("@TransferToEmployeeID", SqlDbType.Int, 4));
        cmd.Parameters("@TransferToEmployeeID").Value = ffInfo.TransferToEmployeeID;

        // Try
        bi = cmd.ExecuteScalar;
        ffInfo.ffID = bi;            // need to remove ******
        return bi;
        // Catch ex As Exception
        // MsgBox(ex.Message)
        // End Try

        // we are opening and closing database before this function
        // this is so we don't have to reopen and close for multiple items
        try
        {
        }
        // sql.cn.Open()
        // sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery()
        // bi = cmd.ExecuteScalar
        // sql.cn.Close()
        catch (Exception ex)
        {
            // MsgBox(ex.Message)
            // CloseConnection()
        }

    }

    internal static object GetDailyBusiness222()
    {

        SqlClient.SqlCommand cmd;
        var dtr = default(SqlClient.SqlDataReader);

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            cmd = new SqlClient.SqlCommand("SELECT DailyCode, StartTime, EmployeeOpened, PrimaryMenu, SecondaryMenu, ShiftID FROM DailyBusinessView WHERE LocationID = '" + companyInfo.LocationID + "'", sql.cn);
            dtr = cmd.ExecuteReader;
            while (dtr.Read())
            {
                currentTerminal.CurrentDailyCode = dtr("DailyCode");
                currentTerminal.primaryMenuID = dtr("PrimaryMenu");
                currentTerminal.secondaryMenuID = dtr("SecondaryMenu");
                currentTerminal.CurrentShift = dtr("ShiftID");
            }

            dtr.Close();
            sql.cn.Close();
            if (currentTerminal.CurrentDailyCode > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        catch (Exception ex)
        {
            if (dtr is not null)
            {
                if (dtr.IsClosed == false)
                {
                    dtr.Close();
                }
            }
            CloseConnection();
        }

        return default;

    }
    internal static void AddAutoSalariedEmployeesToCollection222(string ci, string li)
    {
        // ************  not using yet
        // the problem with this is we don;t know the job code
        // we also not sure if we want these people in working employee collection

        if (ci == "000000")   // so we don't redo
        {
            // sql.SqlSelectCommandClockInJobCodes.Parameters("@CompanyID").Value = ci
            // sql.SqlSelectCommandClockInJobCodes.Parameters("@LocationID").Value = li
            // sql.SqlSelectCommandJobCodeInfo.Parameters("@CompanyID").Value = ci
            // sql.SqlSelectCommandJobCodeInfo.Parameters("@LocationID").Value = li
            try
            {
            }
            // sql.cn.Open()
            // sql.SqlDataAdapterClockInJobCodes.Fill(dsEmployee.Tables("ClockInJobCodes"))
            // sql.SqlDataAdapterJobCodeInfo.Fill(dsEmployee.Tables("JobCodeInfo"))
            // sql.cn.Close()
            catch (Exception ex)
            {
                CloseConnection();
            }

        }

        var salariedEmployees = new ArrayList();
        int empID;
        var newEmployee = new Employee();

        // Dim empID As String
        // Dim passcode As Integer
        string sqlEmpID;
        string sqlPasscode;
        bool opMgmtAll;
        bool opMgmtLimit;
        // Dim reqClockIn As Boolean
        string empName;

        SqlClient.SqlCommand cmd;
        SqlClient.SqlDataReader dtr;

        try
        {
            sql.cn.Open();   // cmd should be almost the same as in clockInEmployee sub
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            cmd = new SqlClient.SqlCommand("SELECT EmployeeID, CompanyID, LocationID, EmployeeNumber, LastName, FirstName, NickName, Passcode, ReportMgmtAll, ReportMgmtLimited, OperationMgmtAll, OperationMgmtLimited, SystemMgmtAll, SystemMgmtLimited, EmployeeMgmtAll, EmployeeMgmtLimited, JobCodeID1 FROM Employee WHERE CompanyID = '" + ci + "' AND LocationID = '" + li + "' AND ClockInReq = 0 AND Terminated = 0", sql.cn);
            dtr = cmd.ExecuteReader;
            while (dtr.Read())
            {

                // If dtr.HasRows Then '    dtr.HasRows Then
                newEmployee = new Employee();

                // job code # 1 is the default for any salaried employee'  
                // if they don't have to clock in then they can't define their position
                newEmployee.EmployeeID = dtr("EmployeeID");
                newEmployee.EmployeeNumber = dtr("EmployeeNumber");
                newEmployee.FullName = dtr("FirstName") + " " + dtr("LastName");
                newEmployee.NickName = dtr("NickName");
                if (newEmployee.NickName.Length < 1)
                {
                    newEmployee.NickName = dtr("FirstName");
                }
                newEmployee.PasscodeID = dtr("Passcode");
                newEmployee.ReportMgmtAll = dtr("ReportMgmtAll");
                newEmployee.ReportMgmtLimited = dtr("ReportMgmtLimited");
                newEmployee.OperationMgmtAll = dtr("OperationMgmtAll");
                newEmployee.OperationMgmtLimited = dtr("OperationMgmtLimited");
                newEmployee.SystemMgmtAll = dtr("SystemMgmtAll");
                newEmployee.SystemMgmtLimited = dtr("SystemMgmtLimited");
                newEmployee.EmployeeMgmtAll = dtr("EmployeeMgmtAll");
                newEmployee.EmployeeMgmtLimited = dtr("EmployeeMgmtLimited");
                newEmployee.JobCodeID = dtr("JobCodeID1");
                newEmployee.ShiftID = currentTerminal.CurrentShift;
                newEmployee.ClockInReq = false;

                salariedEmployees.Add(newEmployee);

            }

            dtr.Close();

            foreach (Employee currentNewEmployee in salariedEmployees)
            {
                newEmployee = currentNewEmployee;
                if (newEmployee.JobCodeID != default)
                {
                    FillJobCodeInfo(ref newEmployee, newEmployee.JobCodeID);
                }
            }

            sql.cn.Close();
        }

        catch (Exception ex)
        {
            CloseConnection();
        }

        foreach (Employee currentNewEmployee1 in salariedEmployees)
        {
            newEmployee = currentNewEmployee1;
            AddEmployeeToCollections(newEmployee);
            // we do not add to current floor personel or current management
            // they must clock in for that
        }

    }

    internal static object AnyOpenTables(Employee emp)
    {
        int qtCount;
        var argempCollection = default;
        PopulateTabsAndTables(emp, currentTerminal.CurrentDailyCode, false, false, ref argempCollection);
        CreateDataViews(emp.EmployeeID, true);
        if (currentTerminal.TermMethod == "Bar") // Or currentTerminal.TermMethod = "Quick" Then
        {
            // probably want "Quick" as well
            qtCount = dvQuickTickets.Count;
        }
        else
        {
            qtCount = 0;
        }
        // If currentTerminal.TermMethod = "Quick" Then
        // With dvQuickTickets
        // .Table = dsOrder.Tables("QuickTickets")
        // 444      .RowFilter = "EmployeeID = " & emp.EmployeeID
        // .Sort = "ExperienceDate ASC"
        // End With
        // End If
        if (dvAvailTables.Count + dvTransferTables.Count + dvAvailTabs.Count + dvTransferTabs.Count + qtCount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    internal static void CreateClosedDataViews()
    {

        dvClosedTables = new DataView();
        dvClosedTabs = new DataView();

        {
            ref var withBlock = ref dvClosedTables;
            withBlock.Table = dsOrder.Tables("AvailTables");
            withBlock.RowFilter = "LastStatus = 9 OR LastStatus = 10"; // "EmployeeID = " & empActive.EmployeeID   
            withBlock.Sort = "ExperienceDate DESC";
        }
        {
            ref var withBlock1 = ref dvClosedTabs;
            withBlock1.Table = dsOrder.Tables("AvailTabs");
            withBlock1.RowFilter = "LastStatus = 9 OR LastStatus = 10"; // "EmployeeID = " & empActive.EmployeeID    
            withBlock1.Sort = "ExperienceDate DESC";
        }

    }

    internal static void CreateAvailDataViews()
    {
        // MsgBox("here at CreateAvailDataViews222")

        dvAvailTables = new DataView();
        dvAvailTabs = new DataView();

        {
            ref var withBlock = ref dvAvailTables;
            withBlock.Table = dsOrder.Tables("OpenTables");
            withBlock.RowFilter = "LastStatus < 8";
            withBlock.RowStateFilter = DataViewRowState.CurrentRows;
            withBlock.Sort = "ExperienceDate DESC";
        }

        {
            ref var withBlock1 = ref dvAvailTabs;
            withBlock1.Table = dsOrder.Tables("OpenTabs");
            withBlock1.RowFilter = "LastStatus < 8";
            withBlock1.RowStateFilter = DataViewRowState.CurrentRows;
            withBlock1.Sort = "ExperienceDate DESC";
        }

    }
    internal static void CreateClosingDataViews(int closingCheck, bool filterCheck)
    {
        dvClosingCheck = new DataView();
        dvClosingCheckPayments = new DataView();
        dvUnAppliedPaymentsAndCredits = new DataView();
        dvAppliedPayments = new DataView();

        {
            ref var withBlock = ref dvClosingCheck;
            withBlock.Table = dsOrder.Tables("OpenOrders");
            // If filterCheck = True Then
            // If currentTable.IsTabNotTable = False Then
            withBlock.RowFilter = "CheckNumber = '" + closingCheck + "'";
            // Else
            // .RowFilter = "CheckNumber = '" & closingCheck & "'"   
            // End If
            // End If
            // .RowStateFilter = DataViewRowState.CurrentRows
            withBlock.Sort = "CustomerNumber, sii, si2, sin";
        }

        {
            ref var withBlock1 = ref dvClosingCheckPayments;
            withBlock1.Table = dsOrder.Tables("PaymentsAndCredits");
            if (filterCheck == true)
            {
                withBlock1.RowFilter = "CheckNumber = '" + closingCheck + "'";
            }
            withBlock1.RowStateFilter = DataViewRowState.CurrentRows;
            withBlock1.Sort = "AuthCode";
        }

        // If dsOrder.Tables("PaymentsAndCredits").Rows.Count > 0 Then
        // we must only apply filter if there are any rows to apply a filter
        // otherwise when we change our filoter critria program delays
        // not 100% sure
        {
            ref var withBlock2 = ref dvUnAppliedPaymentsAndCredits;
            withBlock2.Table = dsOrder.Tables("PaymentsAndCredits");
            if (filterCheck == true)
            {
                withBlock2.RowFilter = "Applied = False AND CheckNumber = '" + closingCheck + "'";
            }
            else
            {
                withBlock2.RowFilter = "Applied = False";
            }
            withBlock2.Sort = "PaymentFlag";
        }
        // Me.closeCheckAdjustments.grdPaymentTotals.DataSource = dvUnAppliedPaymentsAndCredits
        // End If
        // this determines the number for invoicing

        {
            ref var withBlock3 = ref dvAppliedPayments;
            withBlock3.Table = dsOrder.Tables("PaymentsAndCredits");
            withBlock3.RowFilter = "Applied = True AND PaymentFlag = 'cc'";
        }

        // With dvUnAppliedPaymentsAndCredits_MWE
        // .Table = Login.readAuth_MWE.dtPaymentsAndCreditsUnauthorized_MWE
        // .RowFilter = "Applied = False AND ExperienceNumber = '" & currentTable.ExperienceNumber & "' AND CheckNumber = '" & currentTable.CheckNumber & "'"
        // .Sort = "PaymentFlag"
        // End With
    }

    internal static void DetermineTruncatedOrderNumber(ref OrderDetailInfo oDetail)
    {

        string trunkOrderNumber;

        trunkOrderNumber = (string)oDetail.orderNumber;

        if (trunkOrderNumber.Length > 6)
        {
            oDetail.trunkOrderNumber = trunkOrderNumber.Substring(trunkOrderNumber.Length - 6, 6);
        }
        else
        {
            oDetail.trunkOrderNumber = trunkOrderNumber;
        }

    }

    internal static void DetermineTruncatedExperienceNumber()
    {

        string trunkExpNumber;

        trunkExpNumber = currentTable.ExperienceNumber.ToString;

        if (trunkExpNumber.Length > 6)
        {
            currentTable.TruncatedExpNum = trunkExpNumber.Substring(trunkExpNumber.Length - 6, 6);
        }
        else
        {
            currentTable.TruncatedExpNum = trunkExpNumber;
        }

    }

    internal static object DetermineTruncatedExperienceNumberFunction(long expNum)
    {

        string temp;
        string trunkExpNumber;

        temp = expNum.ToString();

        if (temp.Length > 6)
        {
            trunkExpNumber = temp.Substring(temp.Length - 6, 6);
        }
        else
        {
            trunkExpNumber = temp;
        }

        return trunkExpNumber;

    }

    // ***********************
    // Credit Transactions
    // ***********************

    public static object GiftCardTransaction(ref DataRowView vrow, ref Payment newPayment, string whatWereDoing)
    {

        if (!(companyInfo.processor == "Mercury"))
        {
            return "MPS Gift Card";
        }

        string authStatus;
        // currently Gift Card using same CLASS as Credit Card
        var mpsPreAuth = new TStream();
        var mpsPreAuthTransaction = new PreAuthTransactionClass();
        var mpsAmount = new PreAuthAmountClass();
        var mpsAccount = new AccountClass();
        var mpsTransInfo = new TranInfoClass();

        mpsPreAuthTransaction.IpPort = "9100";
        mpsPreAuthTransaction.OperatorID = companyInfo.operatorID;
        mpsPreAuthTransaction.TerminalName = currentServer.FullName;
        mpsPreAuthTransaction.MerchantID = "595901"; // companyInfo.merchantID
        mpsPreAuthTransaction.TranType = "PrePaid";

        switch (whatWereDoing ?? "")
        {
            case "Balance":
                {
                    // currently doing in DetermineGiftCardBalance
                    mpsPreAuthTransaction.TranCode = "Balance";
                    break;
                }
            case "Sale":
                {
                    mpsPreAuthTransaction.TranCode = "Sale";
                    break;
                }
            case "Issue":
                {
                    mpsPreAuthTransaction.TerminalName = currentServer.FullName;
                    mpsPreAuthTransaction.TranCode = "Issue";
                    break;
                }
            case "Return":
                {
                    mpsPreAuthTransaction.TerminalName = currentServer.FullName;
                    mpsPreAuthTransaction.TranCode = "Return";
                    break;
                }
            case "VoidSale":
                {
                    mpsPreAuthTransaction.TerminalName = currentServer.FullName;
                    mpsPreAuthTransaction.TranCode = "VoidSale";
                    mpsTransInfo.AuthCode = vrow("AuthCode");
                    break;
                }
        }

        if (whatWereDoing == "Balance")
        {
            mpsPreAuthTransaction.InvoiceNo = newPayment.RefNo;
            mpsPreAuthTransaction.RefNo = newPayment.RefNo;
            mpsPreAuthTransaction.Memo = companyInfo.VersionNumber;

            mpsAmount.Purchase = "0.00"; // newPayment.Purchase
            if (newPayment.Track2 is not null)
            {
                mpsAccount.Track2 = newPayment.Track2;
            }
            else
            {
                mpsAccount.AcctNo = newPayment.AccountNumber;
                mpsAccount.ExpDate = "0199";
            }

            // newPayment.pr("PreAuthAmount") = _closeAuthAmount.Authorize
            newPayment.TranCode = mpsPreAuthTransaction.TranCode;
        }

        else
        {
            mpsPreAuthTransaction.InvoiceNo = vrow("RefNum");
            if (whatWereDoing == "VoidSale")
            {
                mpsPreAuthTransaction.RefNo = vrow("AuthCode");
            }
            else
            {
                mpsPreAuthTransaction.RefNo = vrow("RefNum");
            }
            mpsPreAuthTransaction.Memo = companyInfo.VersionNumber;

            if (whatWereDoing == "Issue" | whatWereDoing == "Return")
            {
                // we are reversing again to send positive to Mercury
                mpsAmount.Purchase = vrow("PaymentAmount") * -1;
            }
            else
            {
                mpsAmount.Purchase = vrow("PaymentAmount");
            }

            if (!object.ReferenceEquals(vrow("Track2"), DBNull.Value))
            {
                mpsAccount.Track2 = vrow("Track2");
            }
            else
            {
                mpsAccount.AcctNo = vrow("AccountNumber");
                mpsAccount.ExpDate = "0199";
            }

            // vrow("PreAuthAmount") = _closeAuthAmount.Authorize
            vrow("TransactionCode") = mpsPreAuthTransaction.TranCode;

        }

        mpsPreAuthTransaction.Account = mpsAccount;
        mpsPreAuthTransaction.Amount = mpsAmount;

        if (whatWereDoing == "VoidSale")
        {
            mpsPreAuthTransaction.TranInfo = mpsTransInfo;
        }

        mpsPreAuth.Transaction = mpsPreAuthTransaction;

        var output = new StringWriter(new StringBuilder());
        var s = new XmlSerializer(typeof(TStream));
        s.Serialize(output, mpsPreAuth);

        // we send Gift Output to other routine
        authStatus = Conversions.ToString(SendingGift(output.ToString(), mpsPreAuthTransaction.TranCode, ref vrow, ref newPayment)); // , orow, vRow, useVIEW)

        return authStatus;

    }

    private static object SendingGift(string XMLString, string transDetails, ref DataRowView vRow, ref Payment newPayment) // , ByRef orow As DataRow, ByRef vRow As DataRowView, ByVal useVIEW As Boolean)
    {
        string resp;
        var authStatus = default(string);
        string dataFileLocation;
        // 444     Dim sWriter1 As StreamWriter
        // 444     Dim sWriter2 As StreamWriter

        dsi = new DSICLIENTXLib.DSICLientX();

        try
        {
            // dsi.ServerIPConfig("g1.mercurypay.com;g2.backuppay.com", 0)
            dsi.ServerIPConfig("g1.mercurydev.net", 0); // testing only
            resp = dsi.ProcessTransaction(XMLString, 0, "", "");
        }
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);
            Interaction.MsgBox("Could not establish connection to Payment Processor.");
            return default;
        }

        if (transDetails == "Balance")
        {
        }
        // sWriter1 = New StreamWriter("c:\Data Files\spiderPOS\sendGiftBalance.txt")
        // sWriter2 = New StreamWriter("c:\Data Files\spiderPOS\ResponseGiftBalance.txt")
        else if (transDetails == "Sale")
        {
        }
        // sWriter1 = New StreamWriter("c:\Data Files\spiderPOS\sendGiftSale.txt")
        // sWriter2 = New StreamWriter("c:\Data Files\spiderPOS\ResponseGiftSale.txt")
        else if (transDetails == "Return")
        {
        }
        // sWriter1 = New StreamWriter("c:\Data Files\spiderPOS\sendGiftReturn.txt")
        // sWriter2 = New StreamWriter("c:\Data Files\spiderPOS\ResponseReturn.txt")
        else if (transDetails == "Issue")
        {
        }
        // sWriter1 = New StreamWriter("c:\Data Files\spiderPOS\sendGiftIssue.txt")
        // sWriter2 = New StreamWriter("c:\Data Files\spiderPOS\ResponseGiftIssue.txt")
        else if (transDetails == "VoidSale")
        {
        }
        // sWriter1 = New StreamWriter("c:\Data Files\spiderPOS\sendVoidSale.txt")
        // sWriter2 = New StreamWriter("c:\Data Files\spiderPOS\ResponseVoidSale.txt")
        else if (transDetails == "NoNSFSale")
        {
        }
        // actually not doing now
        // sWriter1 = New StreamWriter("c:\Data Files\spiderPOS\sendGiftNoNSFSale.txt")
        // sWriter2 = New StreamWriter("c:\Data Files\spiderPOS\ResponseGiftNoNSFSale.txt")
        else // means something wrong
        {
            return default;
        }

        // sWriter1.Write(XMLString)
        // sWriter1.Close()
        // 
        // sWriter2.Write(resp)
        // sWriter2.Close()

        // MsgBox(resp)
        if (transDetails == "Balance")
        {
            authStatus = Conversions.ToString(ParseXMLGiftMPS(transDetails, resp, ref vRow, ref newPayment));
        }
        else if (transDetails == "Sale")
        {
            authStatus = Conversions.ToString(ParseXMLGiftMPS(transDetails, resp, ref vRow, ref newPayment));
        }

        else if (transDetails == "Return")
        {
            authStatus = Conversions.ToString(ParseXMLGiftMPS(transDetails, resp, ref vRow, ref newPayment));
        }

        else if (transDetails == "Issue")
        {
            authStatus = Conversions.ToString(ParseXMLGiftMPS(transDetails, resp, ref vRow, ref newPayment));
        }
        else if (transDetails == "VoidSale")
        {
            authStatus = Conversions.ToString(ParseXMLGiftMPS(transDetails, resp, ref vRow, ref newPayment));
        }

        else if (transDetails == "GiftNoNSFSale")
        {
        }
        // not doing yet
        else // means something wrong
        {
            return default;
        }

        return authStatus;


    }

    private static object ParseXMLGiftMPS(string transDetails, string resp, ref DataRowView vRow, ref Payment newPayment)
    {

        var reader = new XmlTextReader(new StringReader(resp));
        bool someError;
        bool isPreAuth;
        var isApproved = default(bool);
        var authStatus = default(string);
        bool isDeclined;
        DataRow pRow;
        bool looksLikeDup;
        string tempAuthCode;
        string tempAcqRef;
        bool isAmexDcvr;
        string tempCardType;

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
                                            isApproved = true;
                                            authStatus = "Approved";
                                            break;
                                        }
                                    case "Declined":
                                        {
                                            isDeclined = true;
                                            break;
                                        }

                                    case "Success":
                                        {
                                            break;
                                        }

                                    case "Error":
                                        {
                                            break;
                                        }

                                }

                                break;
                            }

                        case "TextResponse":
                            {

                                if (!(transDetails == "Balance"))
                                {
                                    vRow("Description") = reader.ReadInnerXml().ToString();
                                }
                                switch (reader.ReadInnerXml() ?? "")
                                {
                                    case "AP":
                                        {
                                            // isApproved = True
                                            authStatus = "Approved";
                                            break;
                                        }
                                    case "Account Not Issued":
                                        {
                                            authStatus = "Account Not Issued";
                                            break;
                                        }

                                    case var @case when @case == "":
                                        {
                                            break;
                                        }

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
                        case "AuthCode":
                            {

                                if (!(transDetails == "Balance") & !(transDetails == "VoidSale"))
                                {
                                    tempAuthCode = reader.ReadInnerXml().ToString();
                                    if (isApproved == true)
                                    {
                                        // place authcode in database
                                        vRow("AuthCode") = tempAuthCode;
                                    }
                                }

                                break;
                            }

                        case "AcqRefData":
                            {

                                if (!(transDetails == "Balance") & !(transDetails == "VoidSale"))
                                {
                                    tempAcqRef = reader.ReadInnerXml().ToString();
                                    if (isApproved == true)
                                    {
                                        // place acqRefData in database
                                        vRow("AcqRefData") = tempAcqRef;
                                    }
                                }

                                break;
                            }

                        case "Balance":
                            {

                                if (transDetails == "Balance" & !(transDetails == "VoidSale"))
                                {
                                    // tempAcqRef = reader.ReadInnerXml.ToString
                                    if (isApproved == true)
                                    {
                                        newPayment.Balance = Conversions.ToDecimal(reader.ReadInnerXml());
                                    }
                                }

                                break;
                            }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);
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


    internal static object TruncateAccountNumber(string oldAccountNumber)
    {

        // ****************************************
        // we will not have to do this as much (everytime just the start)
        // after we don't hold account number with Mercury

        int numberOfDigits;
        int xAmount;
        var newAccountNumber = default(string);
        int i;

        numberOfDigits = oldAccountNumber.Length;

        // If oldAccountNumber.Substring(0, 4) = "xxxx" Then
        // already truncated
        // Return oldAccountNumber
        // Exit Function
        // End If

        try
        {
            if (numberOfDigits < 4 | numberOfDigits > 30)
            {
                newAccountNumber = "xxxx";
            }
            else
            {
                xAmount = numberOfDigits - 4;

                var loopTo = xAmount;
                for (i = 1; i <= loopTo; i++)
                {
                    newAccountNumber = newAccountNumber + "x";
                    if (i == xAmount)
                        break;
                }

                newAccountNumber = newAccountNumber + oldAccountNumber.Substring(xAmount, 4);
            }
        }
        catch (Exception ex)
        {
            newAccountNumber = "xxxx";
        }

        return newAccountNumber;

    }

    internal static void ReadyToProcessPaywarePC(ref SIM.Charge PaywarePCCharge)
    {

        PaywarePCCharge.PaymentEngine = SIM.Charge.PaymentSoftware.RiTA_PAYware;
        PaywarePCCharge.ClientID = companyInfo.ClientID; // "100010001"
        PaywarePCCharge.UserID = companyInfo.UserID; // "Admin"
        PaywarePCCharge.UserPW = companyInfo.UserPW; // "PCBeta68$"
        PaywarePCCharge.ServerID = "001";

        PaywarePCCharge.IPAddress = companyInfo.IPAddress; // "127.0.0.1"
        PaywarePCCharge.Port = "4532";
        PaywarePCCharge.CommMethod = SIM.Charge.CommType.IP;

    }

    // **************************
    // Server Connection Changed
    // **************************


    public static object CheckingDatabaseConection()
    {
        // test if connection Just came UP
        var isDataBaseConnected = default(bool);
        SqlClient.SqlCommand cmd;
        var dtr = default(SqlClient.SqlDataReader);

        try
        {

            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            cmd = new SqlClient.SqlCommand("SELECT DailyCode FROM AAADailyBusiness WHERE CompanyID = '" + companyInfo.CompanyID + "'", sql.cn);
            dtr = cmd.ExecuteReader;
            // dtr.Read()
            while (dtr.Read())
            {
                if (object.ReferenceEquals(dtr("DailyCode"), DBNull.Value))
                {
                    isDataBaseConnected = false;
                }
                else
                {
                    isDataBaseConnected = true;
                }
                break;
            }

            dtr.Close();
            sql.cn.Close();
        }

        catch (Exception ex)
        {
            // still not UP
            if (dtr is not null)
            {
                if (dtr.IsClosed == false)
                {
                    dtr.Close();
                }
            }
            CloseConnection();
            isDataBaseConnected = false;
        }

        return isDataBaseConnected;

    }

    internal static void ServerJustWentDown()
    {

        // MsgBox("Server Not Connected. If problem continues, switch to backup server.")
        mainServerConnected = false;
        Interaction.Beep();
        return;


        try
        {
            dsBackup.Tables("AvailTablesTerminal").Columns("ExperienceNumber").AutoIncrement = true;
            dsBackup.Tables("AvailTabsTerminal").Columns("ExperienceNumber").AutoIncrement = true;
        }
        // dsBackup.Tables("OpenOrdersTerminal").Columns("OpenOrderID").AutoIncrement = True
        catch (Exception ex)
        {

        }

    }


    internal static void ServerJustCameUp()
    {
        mainServerConnected = true;
        return;


        // populate Experirence Table
        ServerUPAvailTabsAndTables222();

        // 222   UpdateReopenedChecks()

        // populate ESC from ESCTerminal (StatusChange)
        ServerUPExperienceStatusChange222();

        // to regenerate ORDER NUMBERS
        // 222     ServerUpPlaceInOrderDetail()

        // populate OpenOrders
        ServerUPOpenOrders222();

        // populate Payments And Credits
        ServerUpPaymentsAndCredits();

        UpdateAvailTablesData();

        LogInEmployeesEnteredWhenBackUp222();
        // this is different .. we only need this once
        // b/c working collections are the same on every terminal

        dsBackup.Tables("AvailTablesTerminal").Columns("ExperienceNumber").AutoIncrement = false;
        dsBackup.Tables("AvailTabsTerminal").Columns("ExperienceNumber").AutoIncrement = false;
        // dsBackup.Tables("OpenOrdersTerminal").Columns("OpenOrderID").AutoIncrement = False

        // *** for testing
        if (mainServerConnected == false)
        {
            Interaction.MsgBox(mainServerConnected, Title: "Server Connected");
        }

    }

    private static void ServerUPAvailTabsAndTables222()
    {

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            // sql222.SqlDataAdapterAvailTablesTerminal.Update(dsBackup, "AvailTablesTerminal")
            // sql222.SqlDataAdapterAvailTabsTerminal.Update(dsBackup, "AvailTabsTerminal")
            sql.cn.Close();
            dsBackup.Tables("AvailTablesTerminal").AcceptChanges();
            dsBackup.Tables("AvailTabsTerminal").AcceptChanges();
        }
        catch (Exception ex)
        {
            CloseConnection();
        }

        // **********************************************************************
        // *** do below only for multiple terminals
        return;

        DataRow newRow;
        long oldExpNum;
        var terminalDataTables = new DataView();
        var terminalDataTablesUpdate = new DataView();
        var terminalDataTabs = new DataView();
        var terminalDataTabsUpdate = new DataView();
        long newExpNum;

        DataRowView bRow;

        terminalDataTables.Table = dsBackup.Tables("AvailTablesTerminal");
        terminalDataTables.RowFilter = "dbUP = 0"; // or dbUP = 2"
        terminalDataTables.Sort = "ExperienceNumber";

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();

            foreach (DataRowView currentBRow in terminalDataTables)
            {
                bRow = currentBRow;
                if (bRow("dbUP") == 0)
                {
                    // this row created when db down
                    // our experience Number was generated locally
                    // we must reassign our experienceNumber then replace the new number into OpenOrdersTerminal
                    oldExpNum = bRow("ExperienceNumber");
                    // bRow("ExperienceNumber") = Nothing

                    newExpNum = Conversions.ToLong(AddItemViewToAvailTabsAndTables222(ref bRow, false));
                    // MsgBox(newExpNum, , "New Exprience Number")

                    // *** we need to do this for all
                    // then we need to delete all oldRows from AvailTabsAndTables
                    if (oldExpNum != newExpNum)
                    {
                        ReassignNewExperienceNumberToOpenOrders(oldExpNum, newExpNum);   // (newExpNum + 10)(for testing w/ 1 terminal)
                    }
                }

                else if (bRow("dbUP") == 2)
                {
                    // this previously saved row changed when db down
                    // this is when we close table in Experience Table    ???????

                }
            }
            // sql222.SqlDataAdapterAvailTablesTerminal.Update(dsBackup, "AvailTablesTerminal")
            // sql222.SqlDataAdapterAvailTabsTerminal.Update(dsBackup, "AvailTabsTerminal")
            sql.cn.Close();
            // we only change to 1 after data is saved to SQL Server
            foreach (DataRowView currentBRow1 in terminalDataTables)
            {
                bRow = currentBRow1;
                if (bRow("dbUP") == 0 | bRow("dbUP") == 2)
                {
                    bRow("dbUP") = 1;
                }
            }
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }
        // MsgBox("at END of table add")

    }

    private static void ReassignNewExperienceNumberToOpenOrders(long oldExpNum, long newExpNum)
    {

        // we need to do this b/c we assigned an exp num when we were down
        // they must be consectutive for each location (no duplicates)
        // we would have duplicates if each terminal is assigning there own
        // I think we will never have old experience numbers saved in open order data
        // since we created the experience while we were down


        // *** the below is not efficient
        // we are go through the OOTerminal table for every new exp num
        // it would be good to go through this only once   ?????
        // this also might provide a sufficient delay for other terminals to get back online
        var dvTerminalOO = new DataView();

        foreach (DataRow bRow in dsBackup.Tables("OpenOrdersTerminal").Rows)
        {
            if (bRow("ExperienceNumber") == oldExpNum)
            {
                // bRow.Delete()
                // Exit Sub
                bRow("ExperienceNumber") = newExpNum;
            }

        }

        return;
        // ********************************************************************************************
        // the following does not work
        // \i believe it does not allow change to Exp Num b/c this is how we filtered the datatable
        dvTerminalOO.Table = dsBackup.Tables("OpenOrdersTerminal");
        dvTerminalOO.RowFilter = "ExperienceNumber = '" + oldExpNum + "'";

        foreach (DataRowView enRow in dvTerminalOO)
            enRow("ExperienceNumner") = newExpNum;

    }

    private static void UpdateReopenedChecks222()
    {

        // 222 
        // no longer using, this is from server just came up
        // will have to Change stauts??
        // only do after we close and accept
        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            // sql222.SqlDataAdapterClosedTabs.Update(dsOrder.Tables("ClosedTabs"))
            // sql222.SqlDataAdapterClosedTables.Update(dsOrder.Tables("ClosedTables"))
            sql.cn.Close();
            dsOrder.Tables("ClosedTabs").AcceptChanges();
            dsOrder.Tables("ClosedTables").AcceptChanges();
        }
        // do we not put this in some terminal dataset ???
        // GenerateOrderTables.AddStatusChangeData(9, Nothing, Nothing, Nothing)

        catch (Exception ex)
        {
            CloseConnection();
            if (Information.Err().Number == Conversions.ToDouble("5"))
            {
                ServerJustWentDown();
            }
        }

        // *** may want to place a 2 then 10   ???
        // SaveESCStatusChangeData(10, Nothing, Nothing, Nothing)

    }

    private static void ServerUPExperienceStatusChange222()
    {
        var terminalData = new DataView();
        DataRowView tRow;

        terminalData.Table = dsBackup.Tables("ESCTerminal");
        terminalData.RowFilter = "dbUP = 0";

        try
        {
            // *** we only change to 1 after data is saved to SQL Server
            // this should be lower but was giving an error
            foreach (DataRowView currentTRow in terminalData)
            {
                tRow = currentTRow;
                if (tRow("dbUP") == 0)
                {
                    tRow("dbUP") = 1;
                }
            }
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            foreach (DataRowView currentTRow1 in terminalData)
            {
                tRow = currentTRow1;
                AddItemViewToESCStatusChange(ref tRow);
            }
            sql.cn.Close();
        }

        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox(ex.Message);
        }

    }

    internal static void ServerUpPlaceInOrderDetail222()
    {
        int newOrderNum;

        foreach (DataRow tRow in dsBackup.Tables("ESCTerminal").Rows)
        {
            if (tRow("OrderNumber") < 0)
            {
                newOrderNum = Conversions.ToInteger(ServerUpGenerateNewOrderNumbers222(tRow("OrderNumber")));
            }
        }

    }

    private static object ServerUpGenerateNewOrderNumbers222(int oldOrderNumber)
    {
        // *** will be different with multiple terminals

        int newOrderNumber;
        int escID;

        var cmdOrderNumber = new SqlClient.SqlCommand("SELECT MAX(OrderNumber) lastOrderNumber FROM ExperienceStatusChange WHERE LocationID = '" + companyInfo.LocationID + "' AND CompanyID = '" + companyInfo.CompanyID + "'", sql.cn);
        var cmdESCid = new SqlClient.SqlCommand("SELECT ExperienceStatusChangeID FROM ExperienceStatusChange WHERE LocationID = '" + companyInfo.LocationID + "' AND companyInfo.CompanyID = '" + companyInfo.CompanyID + "' AND OrderNumber = '" + oldOrderNumber + "'", sql.cn);
        // Dim cmd As SqlClient.SqlCommand
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
                newOrderNumber = 1;
            }
            dtr.Close();

            dtr = cmdESCid.executereader;
            dtr.Read();
            escID = dtr("ExperienceStatusChangeID");
            dtr.Close();

            SqlClient.SqlCommand cmdUpdateOrderNumber;
            SqlClient.SqlCommand cmdUpdateInOpenOrders;


            cmdUpdateOrderNumber = new SqlClient.SqlCommand("UPDATE ExperienceStatusChange set OrderNumber = @OrderNumber WHERE (ExperienceStatusChangeID = @Original_ExperienceStatusChangeID)", sql.cn);
            cmdUpdateOrderNumber.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderNumber", System.Data.SqlDbType.Int, 4, "OrderNumber"));
            cmdUpdateOrderNumber.Parameters("@OrderNumber").Value = newOrderNumber;
            cmdUpdateOrderNumber.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ExperienceStatusChangeID", System.Data.SqlDbType.Int, 4, "ExperienceStatusChangeID"));
            cmdUpdateOrderNumber.Parameters("@Original_ExperienceStatusChangeID").Value = escID;

            cmdUpdateInOpenOrders = new SqlClient.SqlCommand("UPDATE OpenOrders set OrderNumber = @OrderNumber WHERE (OrderNumber = @Original_OrderNumber)", sql.cn);
            cmdUpdateInOpenOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderNumber", System.Data.SqlDbType.Int, 4, "OrderNumber"));
            cmdUpdateInOpenOrders.Parameters("@OrderNumber").Value = newOrderNumber;
            cmdUpdateInOpenOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrderNumber", System.Data.SqlDbType.Int, 4, "ExperienceStatusChangeID"));
            cmdUpdateInOpenOrders.Parameters("@Original_OrderNumber").Value = oldOrderNumber;

            cmdUpdateOrderNumber.ExecuteNonQuery();
            cmdUpdateInOpenOrders.ExecuteNonQuery();
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
        }

        return default;

    }


    private static void ServerUPOpenOrders222()
    {
        DataRow newRow;
        DataRow oRow;
        var TerminalDataUpdate = new DataView();
        var terminalData = new DataView();
        DataRowView tRow;

        // we must first do this to get all new unsaved data in one place
        // in case we are in the middle of an order when db comes back up
        // MergeNewOpenOrdersToTerminalBackup()
        dsOrder.Tables("OpenOrders").Rows.Clear();               // do we want this here???
        dsOrder.Tables("OpenOrders").AcceptChanges();

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            // sql.SqlSelectCommandOpenOrdersSP.Parameters("@CompanyID").Value = CompanyID
            sql.SqlSelectCommandOpenOrdersSP.Parameters("@LocationID").Value = companyInfo.LocationID;
            sql.SqlSelectCommandOpenOrdersSP.Parameters("@ExperienceNumber").Value = currentTable.ExperienceNumber;
            sql.SqlDataAdapterOpenOrdersSP.Fill(dsOrder.Tables("OpenOrders"));
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
        }

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            // sql222.SqlDataAdapterOOTerminal.Update(dsBackup.Tables("OpenOrdersTerminal"))
            sql.cn.Close();
            dsBackup.Tables("OpenOrdersTerminal").AcceptChanges();
        }
        catch (Exception ex)
        {
            CloseConnection();
        }

        TerminalDataUpdate.Table = dsBackup.Tables("OpenOrdersTerminal");      // dtOpenOrdersTerminal       '
        TerminalDataUpdate.RowFilter = "ExperienceNumber = '" + currentTable.ExperienceNumber + "' AND dbUP = 2";
        TerminalDataUpdate.Sort = "sin";

        foreach (DataRowView currentTRow in TerminalDataUpdate)
        {
            tRow = currentTRow;
            oRow = dsOrder.Tables("OpenOrders").Rows.Find(tRow("sin"));
            oRow.Delete();
        }

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlDataAdapterOpenOrdersSP.Update(dsOrder.Tables("OpenOrders"));
            sql.cn.Close();

            dsOrder.Tables("OpenOrders").AcceptChanges();
        }
        catch (Exception ex)
        {
            CloseConnection();
        }

        return;

        // *****************************************************************************
        sql.cn.Open();
        sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
        // sql222.SqlDataAdapterOOTerminal.Update(dsOrder.Tables("OpenOrdersTerminal"))
        sql.cn.Close();

        dsBackup.Tables("OpenOrdersTerminal").AcceptChanges();
        // *** not sure which way to use
        // below is another way to do this

        TerminalDataUpdate.Table = dsBackup.Tables("OpenOrdersTerminal");      // dtOpenOrdersTerminal       '
        TerminalDataUpdate.RowFilter = "dbUP = 2";
        TerminalDataUpdate.Sort = "sin";

        // we will need to update directly in the database to make these changes 
        // (b/c we are updating every exp from this terminal)
        // sql.cn.Open()
        foreach (DataRowView currentTRow1 in TerminalDataUpdate)
            // oRow = dsOrder.Tables("OpenOrders").Rows.Find(tRow("sin"))

            tRow = currentTRow1;
        // sql.cn.close
        // we only change to 1 after data is saved to SQL Server
        foreach (DataRowView currentTRow2 in TerminalDataUpdate)
        {
            tRow = currentTRow2;
            if (tRow("dbUP") == 2)
            {
                tRow("dbUP") = 1;
            }
        }

        terminalData.Table = dsBackup.Tables("OpenOrdersTerminal");      // dtOpenOrdersTerminal   '
        terminalData.RowFilter = "dbUP = 0";

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            foreach (DataRowView currentTRow3 in terminalData)
            {
                tRow = currentTRow3;
                AddItemViewToOpenOrders222(ref tRow);

            }
            sql.cn.Close();
            // we only change to 1 after data is saved to SQL Server
            foreach (DataRowView currentTRow4 in terminalData)
            {
                tRow = currentTRow4;
                if (tRow("dbUP") == 0)
                {
                    tRow("dbUP") = 1;
                }
            }
        }
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);

        }

        Interaction.MsgBox("Updated Open Orders?");

    }

    private static void ServerUpPaymentsAndCredits()
    {
        var terminalData = new DataView();
        DataRowView tRow;

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlDataAdapterPayments.Update(dsBackup.Tables("PaymentsAndCreditsTerminal"));
            sql.cn.Close();

            foreach (DataRowView currentTRow in terminalData)
            {
                tRow = currentTRow;
                if (tRow("dbUP") == 0 | tRow("dbUP") == 2)
                {
                    tRow("dbUP") = 1;
                }
            }
            dsBackup.Tables("PaymentsAndCreditsTerminal").AcceptChanges();
        }

        catch (Exception ex)
        {
            CloseConnection();
        }

        return;

        // ************************************************************************
        // *** below is not used
        var terminalDataUpdate = new DataView();
        DataRow oRow;
        int ri;

        // Updates will all have PaymentsAndCreditsID
        terminalDataUpdate.Table = dtPaymentsAndCreditsTerminal;           // dsBackup.Tables("PaymentsAndCreditsTerminal")
        terminalDataUpdate.RowFilter = "dbUP = 2";
        terminalDataUpdate.Sort = "PaymentsAndCreditsID";

        // UpdatePaymentsAndCredits()
        // *** must find a way to update row in database

        terminalData.Table = dtPaymentsAndCreditsTerminal;           // dsBackup.Tables("PaymentsAndCreditsTerminal")
        terminalData.RowFilter = "dbUP = 0";

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            foreach (DataRowView currentTRow1 in terminalData)
            {
                tRow = currentTRow1;
                AddItemViewToPaymentsAndCredits(ref tRow);
            }
            sql.cn.Close();
            // we only change to 1 after data is saved to SQL Server
            foreach (DataRowView currentTRow2 in terminalData)
            {
                tRow = currentTRow2;
                if (tRow("dbUP") == 0)
                {
                    tRow("dbUP") = 1;
                }
            }
        }
        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);
        }

    }






    internal static void FlagOpenOrdersRow222(ref DataRow dRow)
    {

        if (dRow is not null)
        {
            if (!(dRow.RowState == DataRowState.Added))
            {
                // this means it is probably an old row somewhere in terminal dataset
                // this is slow (maybe we can find some better)
                // but not frequent.. only when we delete an item ordered and saved
                var terminalData = new DataView();
                int ri;

                terminalData.Table = dsBackup.Tables("OpenOrdersTerminal");         // 'dtOpenOrdersTerminal
                terminalData.RowFilter = "ExperienceNumber = '" + currentTable.ExperienceNumber + "'";
                terminalData.Sort = "sin";

                ri = terminalData.Find(dRow("sin"));
                if (!(ri == -1))
                {
                    // will not delete a row that is not there
                    terminalData[ri]("dbUP") = 2;
                }
            }
            // If Not dRow.RowState = DataRowState.Deleted Or Not dRow.RowState = DataRowState.Detached Then
            // dRow("dbUP") = 2
            // End If
        }

    }


    internal static object DetermineHoursWorked(int empID, DateTime LogInDate, DateTime endPayPeriod)
    {

        SqlClient.SqlCommand cmd;
        var dtr = default(SqlClient.SqlDataReader);

        var runningWeekHours = default(int);
        int dailyMin;

        LogInDate = LogInDate.AddDays(-0);

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            // this counts this logout for said week,
            // even if logout was during new week, so it appears consistant on time sheet
            // cmd = New SqlClient.SqlCommand("SELECT JobCode, LogInTime, LogOutTime FROM LoginTracking WHERE CompanyID = '" & companyInfo.CompanyID & "' AND LocationID = '" & companyInfo.LocationID & "' AND EmployeeID = '" & empID & "' AND (LogInTime >= '" & LogInDate & "' OR LogOutTime IS NULL)", sql.cn)
            cmd = new SqlClient.SqlCommand("SELECT JobCode, LogInTime, LogOutTime FROM AAALoginTracking WHERE CompanyID = '" + companyInfo.CompanyID + "' AND LocationID = '" + companyInfo.LocationID + "' AND EmployeeID = '" + empID + "' AND LogInTime < '" + endPayPeriod + "' AND (LogInTime >= '" + LogInDate + "' OR LogOutTime IS NULL)", sql.cn);
            dtr = cmd.ExecuteReader;
            while (dtr.Read())
            {
                if (!object.ReferenceEquals(dtr("LogOutTime"), DBNull.Value))
                {
                    DateTime dailyLogIn;
                    DateTime dailyLogOut;
                    dailyLogIn = dtr("LogInTime");
                    dailyLogOut = dtr("LogOutTime");
                    dailyMin = (int)DateAndTime.DateDiff(DateInterval.Minute, dailyLogIn, dailyLogOut);
                    // dailyHours = dailyLogOut.AddDay(-dailyLogIn)
                    runningWeekHours += dailyMin;
                }
            }

            dtr.Close();
            sql.cn.Close();

            return runningWeekHours;
        }
        catch (Exception ex)
        {
            if (dtr is not null)
            {
                if (dtr.IsClosed == false)
                {
                    dtr.Close();
                }
            }
            CloseConnection();
        }

        return default;


    }

    internal static void CreatespiderPOSDirectory()
    {

        if (typeProgram == "Online_Demo")
            return;

        if (Directory.Exists(@"c:\Data Files") == false)
        {
            Directory.CreateDirectory(@"c:\Data Files");
        }
        if (Directory.Exists(@"c:\Data Files\spiderPOS") == false)
        {
            Directory.CreateDirectory(@"c:\Data Files\spiderPOS");
        }
        if (Directory.Exists(@"c:\Data Files\spiderPOS\Menu") == false)
        {
            Directory.CreateDirectory(@"c:\Data Files\spiderPOS\Menu");
        }


    }

    internal static void DemoThisNotAvail()
    {

        Interaction.MsgBox("Function NOT avail in Demo. Call for online Demo 404.869.4700");
    }




    // *******************************
    // Training Module
    // *******************************




}