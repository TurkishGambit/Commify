using System;
using System.Data;
using System.Data.SqlClient;

namespace CommifyMSTestFramework.SQL
{
	class Queries
	{
		//Method to get the status from tblPayments, based on InstanceId and SessionID
		//We are passing the parameters instanceID and sessionID
		//Then, we return the status as a String
		public static String TblPaymentsGetStatusByInstanceIdAndSessionId(int instanceID, string sessionID)
		{
			DataTable QueryResult = GetQueryResult(
				"Data Source=192.168.110.2; Initial Catalog = IVR_BORDER_AGILE_TEST; User ID = ivr; Password = letmein",
				 $"select * from tblPayments where InstanceId = {instanceID} and reference = '{sessionID}' order by 1 desc");
			//Bear in mind, if you want to pass a string into SQL query remember to add ' ' before and after the parameter
			//e.g. and reference = '{sessionID}'
			if (QueryResult.Rows.Count <= 0)
			{
				throw new ArgumentException("QueryResult is empty! No rows returned!");
			}
			// 4 is the index of Column of STATUS
			String Status = QueryResult.Rows[0].ItemArray[4].ToString();
			return Status;
		}

		//Method to get the status from tblSOAP where event LOOKUP-WEB, based on InstanceId and SessionID
		//We are passing the parameters instanceID and sessionID
		//Then, we return the status as a String
		public static String TblSoapsGetLookUpWebStatusByInstanceIdAndSessionId(int instanceID, string sessionID)
		{
			DataTable QueryResult = GetQueryResult(
				"Data Source=192.168.110.2; Initial Catalog = IVR_BORDER_AGILE_TEST; User ID = ivr; Password = letmein",
				 $"select * from tblPayments where InstanceId = {instanceID} and " +
				 $"and event = 'LOOKUP-WEB' and reference = '{sessionID}' order by 1 desc");
			//Bear in mind, if you want to pass a string into SQL query remember to add ' ' before and after the parameter
			//e.g. and reference = '{sessionID}'
			if (QueryResult.Rows.Count <= 0)
			{
				throw new ArgumentException("QueryResult is empty! No rows returned!");
			}
			// 7 is the index of Column of STATUS
			String Status = QueryResult.Rows[0].ItemArray[7].ToString();
			return Status;
		}
		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// Private static method used by those methods, which return just one value
		private static DataTable GetQueryResult(String vConnectionString, String vQuery)
		{
			SqlConnection Connection;  // It is for SQL connection
			DataSet ds = new DataSet();  // it is for store query result

			try
			{
				Connection = new SqlConnection(vConnectionString);  // Declare SQL connection with connection string 
				Connection.Open();  // Connect to Database
				Console.WriteLine("✔Connected to DB✔");
				SqlDataAdapter adp = new SqlDataAdapter(vQuery, Connection);  // Execute query on database 
				adp.Fill(ds);  // Store query result into DataSet object
				Console.WriteLine("✔Data stored into DataSet✔");
				Connection.Close();  // Close connection 
				Connection.Dispose();   // Dispose connection 
				Console.WriteLine("✔SQL connection disposed✔");
			}
			catch (Exception E)
			{
				Console.WriteLine("✘Error in getting result of query✘");
				Console.WriteLine(E.Message);
				return new DataTable();
			}
			return ds.Tables[0];
		}
		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		//Method to delete the rows in tblSOAP based on InstanceId and SessionID
		//We are passing the parameters instanceID and sessionID
		public static void TblSoapDeleteUsingInstanceIdAndSessionId(int instanceID, string sessionID)
		{
			String conn = "Data Source=192.168.110.2; Initial Catalog = IVR_BORDER_AGILE_TEST; User ID = ivr; Password = letmein";
			String query = $"delete from tblSOAP where Reference = '{sessionID}' and InstanceId = {instanceID}";

			SqlConnection Connection;  // It is for SQL connection
			DataSet ds = new DataSet();  // it is for storing query result
			try
			{
				Connection = new SqlConnection(conn);  // Declare SQL connection with connection string 
				Connection.Open();  // Connect to Database
				Console.WriteLine("✔Connected to DB✔");
				SqlDataAdapter adp = new SqlDataAdapter(query, Connection);  // Execute query on database 
				adp.Fill(ds);  // Store query result into DataSet object
				Console.WriteLine("✔Rows deleted in tblSOAP✔");
				Connection.Close();  // Close connection 
				Connection.Dispose();   // Dispose connection 
				Console.WriteLine("✔SQL connection disposed✔");
			}
			catch (Exception E)
			{
				Console.WriteLine("✘Error✘");
				Console.WriteLine(E.Message);
			}
		}
	}
}
