using System;
using System.Linq;

public partial class Menu
{

    // Dim sql As New DataSet_Builder.SQLHelper(connectserver)

    public Menu(int mc, bool isPrimary)
    {
        base..ctor();

        DataRow oRow;

        if (isPrimary == true)
        {
            // the follow 2 now in login since we only need to pull once (not when we change menu)
            // PopulateTables()
            // PopulateModifierMenus()
            PopulateCurrentMenu(mc, true);
            PopulateModifierMenu();
        }
        else
        {
            PopulateCurrentMenu(mc, false);
        }

        if (currentTerminal.TermMethod == "Quick")
        {
            PopulateQuickCategory(mc, isPrimary);
        }
        else
        {
            PopulateBartenderCategory(mc, isPrimary);
        }


        // If isPrimary = False Then       'false so we do this at end
        // maximumCategoryID = DetermineMaximumCategoryID("ModifierCategory")
        // End If

    }

    private void PopulateCurrentMenu(int mc, bool IsPrimary)
    {

        DataRow oRow;
        string customLocationString;
        string sqlStatement;
        string tableCreating;

        if (companyInfo.usingDefaults == false)
        {
            customLocationString = companyInfo.LocationID;
        }
        else
        {
            customLocationString = "000000";
        }

        if (IsPrimary == true)
        {
            tableCreating = "MainCategory";
        }
        else
        {
            tableCreating = "SecondaryMainCategory";
        }

        sqlStatement = "SELECT Category.CompanyID, Category.LocationID, Category.CategoryID, Category.CategoryName, Category.CategoryAbrev, Category.FunctionID, Category.ButtonColor, Category.ButtonForeColor, Category.Extended, MenuDetail.MenuID, MenuDetail.OrderIndex, AABFunctions.FunctionGroupID, AABFunctions.FunctionFlag FROM Category LEFT OUTER JOIN MenuDetail ON Category.CategoryID = MenuDetail.CategoryID LEFT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID WHERE Category.CompanyID = '" + companyInfo.CompanyID + "' AND Category.LocationID = '" + customLocationString + "' AND Category.Active = 1 AND MenuDetail.MenuID = '" + mc + "' AND MenuDetail.CompanyID = '" + companyInfo.CompanyID + "' AND MenuDetail.LocationID = '" + customLocationString + "' AND (AABFunctions.FunctionFlag = 'F' OR AABFunctions.FunctionFlag = 'O' OR AABFunctions.FunctionFlag = 'G') ORDER BY MenuDetail.OrderIndex";     // Panel = 'Main'"
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

        if (IsPrimary == true)
        {
            tableCreating = "IndividualJoinMain";
        }
        else
        {
            tableCreating = "IndividualJoinSecondary";
        }
        // foodjoin for modifiers
        // 444      sqlStatement = "SELECT FoodJoin.CompanyID, FoodJoin.LocationID, FoodJoin.FoodID, FoodJoin.ModifierID, FoodJoin.NumberFree, FoodJoin.FreeFlag, FoodJoin.GroupFlag, Foods.CategoryID, Foods.FoodName, Foods.AbrevFoodName, Foods.ChitFoodName, Foods.Surcharge, Foods.TaxID, Foods.FoodDesc, Foods.MenuIndex, Foods.InvMultiplier, Category.FunctionID, Category.Priority, AABFunctions.FunctionGroupID, AABFunctions.FunctionFlag FROM FoodJoin LEFT OUTER JOIN Foods ON FoodJoin.ModifierID = Foods.FoodID LEFT OUTER JOIN Category ON Foods.CategoryID = Category.CategoryID LEFT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID WHERE Foods.MenuIndex > 0 AND FoodJoin.ModifierID > 0 AND AABFunctions.FunctionFlag = 'M' AND FoodJoin.CompanyID = '" & companyInfo.CompanyID & "' AND FoodJoin.LocationID = '" & customLocationString & "' ORDER BY Priority ASC"
        // ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds)
        // sqlStatement = "SELECT FoodJoin.CompanyID, FoodJoin.LocationID, FoodJoin.FoodID, FoodJoin.ModifierID, FoodJoin.NumberFree, FoodJoin.FreeFlag, FoodJoin.GroupFlag, Foods.CategoryID, Foods.FoodName, Foods.AbrevFoodName, Foods.ChitFoodName, MenuJoin.Surcharge, Foods.TaxID, Foods.FoodDesc, Foods.MenuIndex, Category.FunctionID, Category.Priority, AABFunctions.FunctionGroupID, AABFunctions.FunctionFlag FROM FoodJoin LEFT OUTER JOIN Foods ON FoodJoin.ModifierID = Foods.FoodID LEFT OUTER JOIN Category ON Foods.CategoryID = Category.CategoryID LEFT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID LEFT OUTER JOIN MenuJoin ON FoodJoin.ModifierID = MenuJoin.FoodID WHERE Foods.MenuIndex > 0 AND FoodJoin.ModifierID > 0 AND MenuJoin.MenuID = '" & mc & "' AND MenuJoin.GeneralMenuID IS NULL AND NOT AABFunctions.FunctionFlag = 'M' AND FoodJoin.CompanyID = '" & companyInfo.CompanyID & "' AND FoodJoin.LocationID = '" & customLocationString & "' ORDER BY Priority ASC"
        // ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds)

        // **************************
        // we are using 2 statements
        // the 1st limits to selected menu, and does not include Modifiers
        // these item MUST be defined on the menu, or they won't show up 
        // (only modifiers - 2nd stmt - show on every menu)
        // the second is any Modifiers linked by Indivual Join (no matter menu)
        // they are cummlative, therefore 1 does not cancel the other
        // foodjoin for NON modifiers ("F" and "O") 
        // this first one is only selecting joins that are in a Menu
        // for main foods or (Other Foods) we place the MenuIndex info in the MenuJoin table
        sqlStatement = "SELECT FoodJoin.CompanyID, FoodJoin.LocationID, FoodJoin.FoodID, FoodJoin.ModifierID, FoodJoin.NumberFree, FoodJoin.FreeFlag, FoodJoin.GroupFlag, Foods.CategoryID, Foods.FoodName, Foods.AbrevFoodName, Foods.ChitFoodName, MenuJoin.Surcharge, Foods.TaxID, Foods.FoodDesc, Foods.InvMultiplier, MenuJoin.MenuIndex, Category.FunctionID, Category.Priority, Category.HalfSplit, Category.ButtonColor, Category.ButtonForeColor, Category.Extended, AABFunctions.FunctionGroupID, AABFunctions.FunctionFlag FROM FoodJoin LEFT OUTER JOIN Foods ON FoodJoin.ModifierID = Foods.FoodID LEFT OUTER JOIN Category ON Foods.CategoryID = Category.CategoryID LEFT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID LEFT OUTER JOIN MenuJoin ON FoodJoin.ModifierID = MenuJoin.FoodID WHERE MenuJoin.MenuIndex > 0 AND FoodJoin.ModifierID > 0 AND MenuJoin.MenuID = '" + mc + "' AND MenuJoin.GeneralMenuID IS NULL AND NOT AABFunctions.FunctionFlag = 'M' AND FoodJoin.CompanyID = '" + companyInfo.CompanyID + "' AND FoodJoin.LocationID = '" + customLocationString + "' ORDER BY Priority ASC";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);
        // ** going back to something before, not sure .....MenuJoin.MenuIndex > 0 did not work
        sqlStatement = "SELECT FoodJoin.CompanyID, FoodJoin.LocationID, FoodJoin.FoodID, FoodJoin.ModifierID, FoodJoin.NumberFree, FoodJoin.FreeFlag, FoodJoin.GroupFlag, Foods.CategoryID, Foods.FoodName, Foods.AbrevFoodName, Foods.ChitFoodName, MenuJoin.Surcharge, Foods.TaxID, Foods.FoodDesc, Foods.InvMultiplier, MenuJoin.MenuIndex, Category.FunctionID, Category.Priority, Category.HalfSplit, Category.ButtonColor, Category.ButtonForeColor, Category.Extended, AABFunctions.FunctionGroupID, AABFunctions.FunctionFlag FROM FoodJoin LEFT OUTER JOIN Foods ON FoodJoin.ModifierID = Foods.FoodID LEFT OUTER JOIN Category ON Foods.CategoryID = Category.CategoryID LEFT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID LEFT OUTER JOIN MenuJoin ON FoodJoin.ModifierID = MenuJoin.FoodID WHERE Foods.MenuIndex > 0 AND FoodJoin.ModifierID > 0 AND MenuJoin.GeneralMenuID IS NULL AND AABFunctions.FunctionFlag = 'M' AND FoodJoin.LocationID = '" + customLocationString + "' ORDER BY Priority ASC";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);


        if (IsPrimary == true)
        {
            tableCreating = "DrinkCategory";
        }
        else
        {
            tableCreating = "SecondaryDrinkCategory";
        }
        sqlStatement = "SELECT DrinkCategory.DrinkCategoryID, DrinkCategory.CompanyID, DrinkCategory.LocationID, DrinkCategory.DrinkCategoryNumber, DrinkCategory.DrinkCategoryName, DrinkCategory.ButtonColor, DrinkCategory.ButtonForeColor, DrinkCategory.IsALiquorType, MenuDetail.MenuID, MenuDetail.OrderIndex FROM DrinkCategory LEFT OUTER JOIN MenuDetail ON DrinkCategory.DrinkCategoryID = MenuDetail.DrinkCategoryID WHERE DrinkCategory.CompanyID = '" + companyInfo.CompanyID + "' AND DrinkCategory.LocationID = '" + customLocationString + "' AND MenuDetail.MenuID = '" + mc + "'";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

        // *** I don't think we need both Main and Secodary Tables since
        // we are using an AllFoodCategory table to fill them..they should be the same
        // ________________________________________
        // in these next 2 stmts... we are filling data for the default "000000" and then filling
        // data for the LocationID for the specific rest.

        if (IsPrimary == true)
        {
            foreach (DataRow currentORow in ds.Tables("AllFoodCategory").Rows)
            {
                oRow = currentORow;  // ("MainCategory").Rows
                tableCreating = "MainTable" + oRow("CategoryID");

                if (oRow("FunctionFlag") == "G")
                {
                    try
                    {
                        // sqlStatement = "SELECT Foods.FoodID, Foods.FoodName, Foods.AbrevFoodName, Foods.ChitFoodName, Foods.CategoryID, Foods.FoodCost, Foods.FoodDesc, Foods.WineParringID, Foods.PrintPriorityID, Foods.PrepareTime, Foods.InvMultiplier, MenuJoin.FoodID, MenuJoin.MenuID, MenuJoin.Price, MenuJoin.RoutingID, MenuJoin.Surcharge, MenuJoin.MenuIndex, Category.FunctionID, Category.HalfSplit, Category.ButtonColor, Category.ButtonForeColor, Category.Extended, AABFunctions.FunctionID, AABFunctions.FunctionFlag, AABFunctions.TaxID, AABFunctions.FunctionGroupID FROM Foods INNER JOIN MenuJoin ON Foods.FoodID = MenuJoin.FoodID LEFT OUTER JOIN Category ON Foods.CategoryID = Category.CategoryID LEFT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID WHERE MenuJoin.MenuIndex > 0 AND MenuJoin.GeneralMenuID = " & oRow("CategoryID") & " AND Foods.Active = 1 AND MenuJoin.Active = 1 AND (MenuJoin.MenuID = '" & mc & "') AND (Foods.CompanyID = '" & companyInfo.CompanyID & "') AND (Foods.LocationID = '" & customLocationString & "')"
                        sqlStatement = "SELECT Foods.FoodID, Foods.FoodName, Foods.AbrevFoodName, Foods.ChitFoodName, Foods.CategoryID, Foods.FoodCost, Foods.TaxExempt, Foods.FoodDesc, Foods.WineParringID, Foods.PrintPriorityID, Foods.PrepareTime, Foods.InvMultiplier, MenuJoin.FoodID, MenuJoin.MenuID, MenuJoin.Price, MenuJoin.RoutingID, MenuJoin.Surcharge, MenuJoin.MenuIndex, Category.FunctionID, Category.HalfSplit, Category.ButtonColor, Category.ButtonForeColor, Category.Extended, AABFunctions.FunctionID, AABFunctions.FunctionFlag, AABFunctions.TaxID, AABFunctions.FunctionGroupID FROM Foods INNER JOIN MenuJoin ON Foods.FoodID = MenuJoin.FoodID LEFT OUTER JOIN Category ON Foods.CategoryID = Category.CategoryID LEFT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID WHERE MenuJoin.GeneralMenuID = " + oRow("CategoryID") + " AND Foods.Active = 1 AND MenuJoin.Active = 1 AND (MenuJoin.MenuID = '" + mc + "') AND (Foods.CompanyID = '" + companyInfo.CompanyID + "') AND (Foods.LocationID = '" + customLocationString + "')";
                        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

                        tableCreating = "DrinkMainTable" + oRow("CategoryID");
                        sqlStatement = "SELECT Drinks.DrinkID, Drinks.DrinkName, Drinks.DrinkCategoryID, DrinkCategory.DrinkCategoryNumber, DrinkCategory.ButtonColor, DrinkCategory.ButtonForeColor, MenuJoin.DrinkID, MenuJoin.MenuID, MenuJoin.Price, MenuJoin.RoutingID, MenuJoin.Surcharge, MenuJoin.MenuIndex, AABFunctions.FunctionID, AABFunctions.FunctionFlag, AABFunctions.TaxID, AABFunctions.FunctionGroupID FROM Drinks INNER JOIN MenuJoin ON Drinks.DrinkID = MenuJoin.DrinkID LEFT OUTER JOIN DrinkCategory ON Drinks.DrinkCategoryID = DrinkCategory.DrinkCategoryID LEFT OUTER JOIN AABFunctions ON Drinks.DrinkFunctionID = AABFunctions.FunctionID WHERE MenuJoin.GeneralMenuID = " + oRow("CategoryID") + " AND Drinks.Active = 1 AND MenuJoin.Active = 1 AND (MenuJoin.MenuID = '" + mc + "') AND (Drinks.CompanyID = '" + companyInfo.CompanyID + "') AND (Drinks.LocationID = '" + customLocationString + "')";
                        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);
                    }

                    catch (Exception ex)
                    {
                        Interaction.MsgBox(ex.Message);
                    }
                }
                else
                {
                    // sqlStatement = "SELECT Foods.FoodID, Foods.FoodName, Foods.AbrevFoodName, Foods.ChitFoodName, Foods.CategoryID, Foods.FoodCost, Foods.FoodDesc, Foods.WineParringID, Foods.PrintPriorityID, Foods.PrepareTime, Foods.InvMultiplier, MenuJoin.FoodID, MenuJoin.MenuID, MenuJoin.Price, MenuJoin.RoutingID, MenuJoin.Surcharge, MenuJoin.MenuIndex, Category.FunctionID, Category.HalfSplit, Category.ButtonColor, Category.ButtonForeColor, Category.Extended, AABFunctions.FunctionID, AABFunctions.FunctionFlag, AABFunctions.TaxID, AABFunctions.FunctionGroupID FROM Foods INNER JOIN MenuJoin ON Foods.FoodID = MenuJoin.FoodID LEFT OUTER JOIN Category ON Foods.CategoryID = Category.CategoryID LEFT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID WHERE MenuJoin.MenuIndex > 0 AND Foods.CategoryID = " & oRow("CategoryID") & " AND Foods.Active = 1 AND MenuJoin.Active = 1 AND (MenuJoin.MenuID = '" & mc & "') AND (MenuJoin.GeneralMenuID IS NULL) AND (Foods.CompanyID = '" & companyInfo.CompanyID & "') AND (Foods.LocationID = '" & customLocationString & "')"
                    sqlStatement = "SELECT Foods.FoodID, Foods.FoodName, Foods.AbrevFoodName, Foods.ChitFoodName, Foods.CategoryID, Foods.FoodCost, Foods.TaxExempt, Foods.FoodDesc, Foods.WineParringID, Foods.PrintPriorityID, Foods.PrepareTime, Foods.InvMultiplier, MenuJoin.FoodID, MenuJoin.MenuID, MenuJoin.Price, MenuJoin.RoutingID, MenuJoin.Surcharge, MenuJoin.MenuIndex, Category.FunctionID, Category.HalfSplit, Category.ButtonColor, Category.ButtonForeColor, Category.Extended, AABFunctions.FunctionID, AABFunctions.FunctionFlag, AABFunctions.TaxID, AABFunctions.FunctionGroupID FROM Foods INNER JOIN MenuJoin ON Foods.FoodID = MenuJoin.FoodID LEFT OUTER JOIN Category ON Foods.CategoryID = Category.CategoryID LEFT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID WHERE Foods.CategoryID = " + oRow("CategoryID") + " AND Foods.Active = 1 AND MenuJoin.Active = 1 AND (MenuJoin.MenuID = '" + mc + "') AND (MenuJoin.GeneralMenuID IS NULL) AND (Foods.CompanyID = '" + companyInfo.CompanyID + "') AND (Foods.LocationID = '" + customLocationString + "')";
                    ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

                }
            }
        }

        else
        {
            foreach (DataRow currentORow1 in ds.Tables("AllFoodCategory").Rows)
            {
                oRow = currentORow1;  // ("SecondaryMainCategory").Rows
                tableCreating = "SecondaryMainTable" + oRow("CategoryID");
                if (oRow("FunctionFlag") == "G")
                {
                    sqlStatement = "SELECT Foods.FoodID, Foods.FoodName, Foods.AbrevFoodName, Foods.ChitFoodName, Foods.CategoryID, Foods.FoodCost, Foods.TaxExempt, Foods.FoodDesc, Foods.WineParringID, Foods.PrintPriorityID, Foods.PrepareTime, Foods.InvMultiplier, MenuJoin.FoodID, MenuJoin.MenuID, MenuJoin.Price, MenuJoin.RoutingID, MenuJoin.Surcharge, MenuJoin.MenuIndex, Category.FunctionID, Category.HalfSplit, Category.ButtonColor, Category.ButtonForeColor, Category.Extended, AABFunctions.FunctionID, AABFunctions.FunctionFlag, AABFunctions.TaxID, AABFunctions.FunctionGroupID FROM Foods INNER JOIN MenuJoin ON Foods.FoodID = MenuJoin.FoodID LEFT OUTER JOIN Category ON Foods.CategoryID = Category.CategoryID LEFT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID WHERE MenuJoin.GeneralMenuID = " + oRow("CategoryID") + " AND Foods.Active = 1 AND MenuJoin.Active = 1 AND (MenuJoin.MenuID = '" + mc + "') AND (Foods.CompanyID = '" + companyInfo.CompanyID + "') AND (Foods.LocationID = '" + customLocationString + "')";
                    ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);
                }

                else
                {
                    sqlStatement = "SELECT Foods.FoodID, Foods.FoodName, Foods.AbrevFoodName, Foods.ChitFoodName, Foods.CategoryID, Foods.FoodCost, Foods.TaxExempt, Foods.FoodDesc, Foods.WineParringID, Foods.PrintPriorityID, Foods.PrepareTime, Foods.InvMultiplier, MenuJoin.FoodID, MenuJoin.MenuID, MenuJoin.Price, MenuJoin.RoutingID, MenuJoin.Surcharge, MenuJoin.MenuIndex, Category.FunctionID, Category.HalfSplit, Category.ButtonColor, Category.ButtonForeColor, Category.Extended, AABFunctions.FunctionID, AABFunctions.FunctionFlag, AABFunctions.TaxID, AABFunctions.FunctionGroupID FROM Foods INNER JOIN MenuJoin ON Foods.FoodID = MenuJoin.FoodID LEFT OUTER JOIN Category ON Foods.CategoryID = Category.CategoryID LEFT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID WHERE Foods.CategoryID = " + oRow("CategoryID") + " AND Foods.Active = 1 AND MenuJoin.Active = 1 AND (MenuJoin.MenuID = '" + mc + "') AND (MenuJoin.GeneralMenuID IS NULL) AND (Foods.CompanyID = '" + companyInfo.CompanyID + "') AND (Foods.LocationID = '" + customLocationString + "')";
                    ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);
                }

            }
        }

    }

    private void PopulateBartenderCategory(int mc, bool IsPrimary)
    {

        string sqlStatement;
        string tableCreating;
        string customLocationString;

        if (companyInfo.usingDefaults == false)
        {
            customLocationString = companyInfo.LocationID;
        }
        else
        {
            customLocationString = "000000";
        }

        if (IsPrimary == true)
        {
            tableCreating = "BartenderCategory";
        }
        else
        {
            tableCreating = "SecondaryBartenderCategory";
        }

        sqlStatement = "SELECT Category.CompanyID, Category.LocationID, Category.CategoryID, Category.CategoryName, Category.CategoryAbrev, Category.FunctionID, Category.ButtonColor, Category.ButtonForeColor, Category.Extended, MenuDetail.BartenderMenuID, MenuDetail.OrderIndex, AABFunctions.FunctionGroupID, AABFunctions.FunctionFlag, AABFunctions.TaxID FROM Category LEFT OUTER JOIN MenuDetail ON Category.CategoryID = MenuDetail.CategoryID LEFT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID WHERE Category.CompanyID = '" + companyInfo.CompanyID + "' AND Category.LocationID = '" + customLocationString + "' AND Category.Active = 1 AND MenuDetail.BartenderMenuID = '" + mc + "' AND MenuDetail.CompanyID = '" + companyInfo.CompanyID + "' AND MenuDetail.LocationID = '" + customLocationString + "' AND (AABFunctions.FunctionFlag = 'F' OR AABFunctions.FunctionFlag = 'O' OR AABFunctions.FunctionFlag = 'G') ORDER BY MenuDetail.OrderIndex";     // Panel = 'Main'"
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

        if (IsPrimary == true)
        {
            tableCreating = "BartenderDrinkCategory";
        }
        else
        {
            tableCreating = "SecondaryBartenderDrinkCategory";
        }

        sqlStatement = "SELECT DrinkCategory.DrinkCategoryID, DrinkCategory.CompanyID, DrinkCategory.LocationID, DrinkCategory.DrinkCategoryNumber, DrinkCategory.DrinkCategoryName, DrinkCategory.ButtonColor, DrinkCategory.ButtonForeColor, DrinkCategory.IsALiquorType, MenuDetail.BartenderMenuID, MenuDetail.OrderIndex FROM DrinkCategory LEFT OUTER JOIN MenuDetail ON DrinkCategory.DrinkCategoryID = MenuDetail.DrinkCategoryID WHERE DrinkCategory.CompanyID = '" + companyInfo.CompanyID + "' AND DrinkCategory.LocationID = '" + customLocationString + "' AND MenuDetail.BartenderMenuID = '" + mc + "'";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

    }

    private void PopulateQuickCategory(int mc, bool IsPrimary)
    {

        string sqlStatement;
        string tableCreating;
        string customLocationString;

        if (companyInfo.usingDefaults == false)
        {
            customLocationString = companyInfo.LocationID;
        }
        else
        {
            customLocationString = "000000";
        }

        if (IsPrimary == true)
        {
            tableCreating = "QuickCategory";
        }
        else
        {
            tableCreating = "SecondaryQuickCategory";
        }

        sqlStatement = "SELECT Category.CompanyID, Category.LocationID, Category.CategoryID, Category.CategoryName, Category.CategoryAbrev, Category.FunctionID, Category.ButtonColor, Category.ButtonForeColor, Category.Extended, MenuDetail.BartenderMenuID, MenuDetail.OrderIndex, AABFunctions.FunctionGroupID, AABFunctions.FunctionFlag, AABFunctions.TaxID FROM Category LEFT OUTER JOIN MenuDetail ON Category.CategoryID = MenuDetail.CategoryID LEFT OUTER JOIN AABFunctions ON Category.FunctionID = AABFunctions.FunctionID WHERE Category.CompanyID = '" + companyInfo.CompanyID + "' AND Category.LocationID = '" + customLocationString + "' AND Category.Active = 1 AND MenuDetail.QuickMenuID = '" + mc + "' AND MenuDetail.CompanyID = '" + companyInfo.CompanyID + "' AND MenuDetail.LocationID = '" + customLocationString + "' AND (AABFunctions.FunctionFlag = 'F' OR AABFunctions.FunctionFlag = 'O' OR AABFunctions.FunctionFlag = 'G') ORDER BY MenuDetail.OrderIndex";     // Panel = 'Main'"
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

        if (IsPrimary == true)
        {
            tableCreating = "QuickDrinkCategory";
        }
        else
        {
            tableCreating = "SecondaryQuickDrinkCategory";
        }

        sqlStatement = "SELECT DrinkCategory.DrinkCategoryID, DrinkCategory.CompanyID, DrinkCategory.LocationID, DrinkCategory.DrinkCategoryNumber, DrinkCategory.DrinkCategoryName, DrinkCategory.ButtonColor, DrinkCategory.ButtonForeColor, DrinkCategory.IsALiquorType, MenuDetail.BartenderMenuID, MenuDetail.OrderIndex FROM DrinkCategory LEFT OUTER JOIN MenuDetail ON DrinkCategory.DrinkCategoryID = MenuDetail.DrinkCategoryID WHERE DrinkCategory.CompanyID = '" + companyInfo.CompanyID + "' AND DrinkCategory.LocationID = '" + customLocationString + "' AND MenuDetail.QuickMenuID = '" + mc + "'";
        ds = sql.PopulateSelectedItemTable(tableCreating, sqlStatement, ds);

    }

    private void PopulateModifierMenu()
    {
        string sqlStatement;
        string tableCreating;
        string customLocationString;
        if (companyInfo.usingDefaults == false)
        {
            customLocationString = companyInfo.LocationID;
        }
        else
        {
            customLocationString = "000000";
        }

        try
        {
            foreach (DataRow oRow in ds.Tables("ModifierCategory").Rows)
            {
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

    private object DetermineMaximumCategoryID222(ref string tablecreating)
    {

        var MaxID = default(int);

        if (ds.Tables(tablecreating).Rows.Count > 0)
        {
            MaxID = ds.Tables(tablecreating).Compute("Max(CategoryID)", "");
        }

        return MaxID;

    }



    // *********************
    // old


    private void PopulateTables222()
    {
        // *****************************
        // now in login / GeneralOrderTables
        // *****************************      

    }

    private void PopulateModifierMenus222()
    {
        // *****************************
        // now in login / GeneralOrderTables
        // *****************************      

    }

}