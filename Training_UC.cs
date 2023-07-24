using System;
using System.Linq;



public partial class Training_UC : System.Windows.Forms.UserControl
{


    public Training_UC() : base()
    {

        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call
        InitializeOther();

    }

    internal void InitializeOther()
    {

        this.grdPreviousDailys.DataSource = dtTrainingDaily;
        DeterminePreviousDailys();

    }

    private void DeterminePreviousDailys()
    {

        sql.SqlTrainingDailyCodeSelect.Parameters("@LocationID").Value = companyInfo.LocationID;
        sql.SqlTrainingDailyCodeSelect.Parameters("@DailyCode").Value = currentTerminal.CurrentDailyCode;
        dsOrder.Tables("TrainingDaily").Clear();

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
            sql.SqlTrainingDailyCode.Fill(dsOrder.Tables("TrainingDaily"));
            sql.cn.Close();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox("Issues with Loading Previous Training Dailys: " + ex.Message);

        }

        if (dsOrder.Tables("TrainingDaily").Rows.Count > 0)
        {

        }

    }

    private bool DeleteOrdersDetail(long delDaily) // whereString As Int64) As Boolean
    {
        // use above sub
        SqlClient.SqlCommand cmd;
        SqlClient.SqlDataReader dtr;

        try
        {
            // sql.cn.Open()
            // sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery()
            cmd = new SqlClient.SqlCommand("DELETE FROM OpenOrders WHERE DailyCode = " + delDaily, sql.cn);
            dtr = cmd.ExecuteReader;
            dtr.Read();
            dtr.Close();

            cmd = new SqlClient.SqlCommand("DELETE FROM OrderDetail WHERE DailyCode = " + delDaily, sql.cn);
            dtr = cmd.ExecuteReader;
            dtr.Read();
            dtr.Close();

            cmd = new SqlClient.SqlCommand("DELETE FROM PaymentsAndCredits WHERE DailyCode = " + delDaily, sql.cn);
            dtr = cmd.ExecuteReader;
            dtr.Read();
            dtr.Close();
        }

        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);
            // dtr.Close()
            CloseConnection();
            return false;

        }

        // dtr.Close()
        // sql.cn.Close()
        return true;

    }

    private bool DeleteExperienceTable(long delDaily) // whereString As Int64) As Boolean
    {
        // use above sub
        SqlClient.SqlCommand cmd;
        SqlClient.SqlDataReader dtr;

        try
        {
            // sql.cn.Open()
            // sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery()
            cmd = new SqlClient.SqlCommand("DELETE FROM ExperienceTable WHERE DailyCode = " + delDaily, sql.cn);
            dtr = cmd.ExecuteReader;
            dtr.Read();
            dtr.Close();
        }

        catch (Exception ex)
        {
            Interaction.MsgBox(ex.Message);
            CloseConnection();
            return false;

        }

        // sql.cn.Close()
        return true;

    }

    private bool DeleteTerminalLogin(long delDaily) // whereString As Int64) As Boolean
    {
        // use above sub
        SqlClient.SqlCommand cmd;
        SqlClient.SqlDataReader dtr;

        try
        {
            // sql.cn.Open()
            // sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery()
            cmd = new SqlClient.SqlCommand("DELETE FROM AAATerminalsOpen WHERE DailyCode = " + delDaily, sql.cn);
            dtr = cmd.ExecuteReader;
            dtr.Read();
            dtr.Close();
            // cmd = New SqlClient.SqlCommand("DELETE FROM AAATabOverview WHERE DailyCode = " & whereString, sql.cn)
            // dtr = cmd.ExecuteReader
            // dtr.Read()
            // dtr.Close()
            cmd = new SqlClient.SqlCommand("DELETE FROM AAALoginTracking WHERE DailyCode = " + delDaily, sql.cn);
            dtr = cmd.ExecuteReader;
            dtr.Read();
            dtr.Close();
        }

        catch (Exception ex)
        {
            CloseConnection();
            return false;

        }

        // sql.cn.Close()
        return true;

    }

    private bool DeleteDaily(long delDaily) // whereString As Int64) As Boolean
    {
        // use above sub
        SqlClient.SqlCommand cmd;
        SqlClient.SqlDataReader dtr;

        try
        {
            // sql.cn.Open()
            // sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery()
            cmd = new SqlClient.SqlCommand("DELETE FROM AAADailyBusiness WHERE DailyCode = " + delDaily, sql.cn);
            dtr = cmd.ExecuteReader;
            dtr.Read();
            dtr.Close();
        }

        catch (Exception ex)
        {
            CloseConnection();
            return false;

        }

        // sql.cn.Close()
        return true;

    }

    private void Button1_Click(object sender, EventArgs e)
    {
        this.Dispose();

    }

    private void btnDeleteTraining_Click(object sender, EventArgs e)
    {
        bool didStep1Succeed;
        bool didStep2Succeed;
        bool didStep3Succeed;
        bool didStep4Succeed;
        var whereString = default(string);
        var countTraining = default(int);
        DataRow oRow;
        bool isFirstRow = true;

        // not used now, except to say none are being deleted
        if (dsOrder.Tables("TrainingDaily").Rows.Count > 0)
        {
            foreach (DataRow currentORow in dsOrder.Tables("TrainingDaily").Rows)
            {
                oRow = currentORow;
                if (oRow("ActiveDaily") == true)
                {
                    if (isFirstRow == true)
                    {
                        whereString = oRow("DailyCode"); // .ToString
                        isFirstRow = false;
                    }
                    else
                    {
                        whereString = whereString + " AND " + oRow("DailyCode");
                    } // .ToString
                    countTraining += 1;
                }
            }
            if (whereString.Length < 1)
            {
                Interaction.MsgBox("No Dailys are marked as Training");
                return; // means there are no dailys to delete
            }
        }
        else
        {
            return;
        }

        long delDaily;

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox("Removing Training Daily Failed opening database");
            return;
        }

        if (dsOrder.Tables("TrainingDaily").Rows.Count > 0)
        {
            foreach (DataRow currentORow1 in dsOrder.Tables("TrainingDaily").Rows)
            {
                oRow = currentORow1;
                if (oRow("ActiveDaily") == true)
                {
                    // If isFirstRow = True Then
                    delDaily = oRow("DailyCode"); // .ToString
                    didStep1Succeed = DeleteOrdersDetail(delDaily);
                    if (didStep1Succeed == true)
                    {
                        didStep2Succeed = DeleteExperienceTable(delDaily);
                        if (didStep2Succeed == true)
                        {
                            didStep3Succeed = DeleteTerminalLogin(delDaily);
                            if (didStep3Succeed == true)
                            {
                                didStep4Succeed = DeleteDaily(delDaily);
                                if (didStep4Succeed == true)
                                {
                                }
                                // this means training dailys were deleted
                                // sql.cn.Close()
                                // MsgBox(countTraining & " Training Dailys were removed from the database")
                                else
                                {
                                    // any failure sql.cn.close is in Catch
                                    Interaction.MsgBox("Removing Training Daily Failed at the last step");
                                    return;
                                }
                            }
                            else
                            {
                                Interaction.MsgBox("Removing Training Daily Failed after Experience Detail was deleted");
                                return;
                            }
                        }
                        else
                        {
                            Interaction.MsgBox("Removing Training Daily Failed after Order Detail was deleted");
                            return;
                        }
                    }
                    else
                    {
                        Interaction.MsgBox("Removing Training Daily Failed at the Start");
                        return;
                    }
                    // End If
                }
            }
        }


        // sql.cn.Close()
        CloseConnection();
        Interaction.MsgBox(countTraining + " Training Dailys were removed from the database");


    }


    private void btnDeleteTraining_Click222(object sender, EventArgs e) // Handles btnDeleteTraining.Click
    {
        bool didStep1Succeed;
        bool didStep2Succeed;
        bool didStep3Succeed;
        bool didStep4Succeed;
        var whereString = default(string);
        var countTraining = default(int);
        DataRow oRow;
        bool isFirstRow = true;

        if (dsOrder.Tables("TrainingDaily").Rows.Count > 0)
        {
            foreach (DataRow currentORow in dsOrder.Tables("TrainingDaily").Rows)
            {
                oRow = currentORow;
                if (oRow("ActiveDaily") == true)
                {
                    if (isFirstRow == true)
                    {
                        whereString = oRow("DailyCode"); // .ToString
                        isFirstRow = false;
                    }
                    else
                    {
                        whereString = whereString + " AND " + oRow("DailyCode");
                    } // .ToString
                    countTraining += 1;
                }
            }
            if (whereString.Length < 1)
            {
                Interaction.MsgBox("No Dailys are marked as Training");
                return; // means there are no dailys to delete
            }
        }
        else
        {
            return;
        }

        if (dsOrder.Tables("TrainingDaily").Rows.Count > 0)
        {
            foreach (DataRow currentORow1 in dsOrder.Tables("TrainingDaily").Rows)
            {
                oRow = currentORow1;
                if (oRow("ActiveDaily") == true)
                {
                    if (isFirstRow == true)
                    {
                        whereString = oRow("DailyCode"); // .ToString
                    }
                }
            }
        }

        try
        {
            sql.cn.Open();
            sql.sqlSelectAppRoleCommandPhoenix.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            CloseConnection();
            Interaction.MsgBox("Removing Training Daily Failed opening database");
            return;
        }

        didStep1Succeed = DeleteOrdersDetail(Conversions.ToLong(whereString));
        if (didStep1Succeed == true)
        {
            didStep2Succeed = DeleteExperienceTable(Conversions.ToLong(whereString));
            if (didStep2Succeed == true)
            {
                didStep3Succeed = DeleteTerminalLogin(Conversions.ToLong(whereString));
                if (didStep3Succeed == true)
                {
                    didStep4Succeed = DeleteDaily(Conversions.ToLong(whereString));
                    if (didStep4Succeed == true)
                    {
                        // this means training dailys were deleted
                        sql.cn.Close();
                        Interaction.MsgBox(countTraining + " Training Dailys were removed from the database");
                    }
                    else
                    {
                        // any failure sql.cn.close is in Catch
                        Interaction.MsgBox("Removing Training Daily Failed at the last step");
                        return;
                    }
                }
                else
                {
                    Interaction.MsgBox("Removing Training Daily Failed after Experience Detail was deleted");
                    return;
                }
            }
            else
            {
                Interaction.MsgBox("Removing Training Daily Failed after Order Detail was deleted");
                return;
            }
        }
        else
        {
            Interaction.MsgBox("Removing Training Daily Failed at the Start");
            return;
        }
    }


}