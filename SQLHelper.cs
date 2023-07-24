
internal partial class SQLHelper
{

    internal System.Data.SqlClient.SqlConnection cn;

    public SQLHelper()
    {
        cn = new System.Data.SqlClient.SqlConnection("integrated security=SSPI;data source=VAIO;initial catalog=Restaurant_Server"); // ;User ID=VAIO\Administrator;Password=;") '("Data Source=\SC_Restaurant.sdf")
    }



    public DataSet PopulateSelectedItemTable(string strSelectedCategoy, string sql, ref DataSet dsItem)
    {

        cn.Open();
        var itemAdapter = new SqlClient.SqlDataAdapter();

        itemAdapter.TableMappings.Add("Table", strSelectedCategoy);
        var cmdItemTable = new SqlClient.SqlCommand(sql, cn);

        itemAdapter.SelectCommand = cmdItemTable;
        itemAdapter.Fill(dsItem);

        cn.Close();

        return dsItem;


    }



}