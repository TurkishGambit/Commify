using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommifyMSTestFramework.SQL
{
	class SQL
	{
		public String GetStatusByInstanceIdAndSessionIdFromTblPayments(int instanceID, string sessionID)
		{
			DataTable QueryResult = GetQueryResult("Data Source=192.168.110.2; Initial Catalog = IVR_BORDER_AGILE_TEST; User ID = ivr; Password = letmein",
													$"select * from [IVR_BORDER_AGILE_TEST].[dbo].[tblPayments] where InstanceId = {instanceID} and reference = {sessionID} order by 1 desc");

			// 4 is the index of Column of STATUS
			String paymentStatus = QueryResult.Rows[0].ItemArray[4].ToString();
			return paymentStatus;
		}








		public DataTable GetQueryResult(String vConnectionString, String vQuery)
		{
			SqlConnection Connection;  // It is for SQL connection
			DataSet ds = new DataSet();  // it is for store query result

			try
			{
				Connection = new SqlConnection(vConnectionString);  // Declare SQL connection with connection string 
				Connection.Open();  // Connect to Database
				Console.WriteLine("✔✔✔Connected to DB✔✔✔");

				SqlDataAdapter adp = new SqlDataAdapter(vQuery, Connection);  // Execute query on database 
				adp.Fill(ds);  // Store query result into DataSet object   
				Connection.Close();  // Close connection 
				Connection.Dispose();   // Dispose connection             
			}
			catch (Exception E)
			{
				Console.WriteLine("✘✘✘Error in getting result of query✘✘✘");
				Console.WriteLine(E.Message);
				return new DataTable();
			}
			return ds.Tables[0];
		}
	}
}
