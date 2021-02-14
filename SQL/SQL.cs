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
		public static String TblPayments_GetStatus(int instanceID, string sessionID)
		{
			DataTable QueryResult = GetQueryResult(
				"Data Source=192.168.130.2; Initial Catalog = IVR_BORDER_AGILE_TEST; User ID = ivr; Password = letmein",
					$"select P.status from tblPayments as P " +
					$"inner join tblSOAP as S on P.InstanceId = S.InstanceId " +
					$"where S.Reference = '{sessionID}' " +
					$"and P.ID = S.PaymentGUID " +
					$"and p.InstanceId = {instanceID}");
			//Bear in mind, if you want to pass a string into SQL query remember to add ' ' before and after the parameter
			//e.g. and reference = '{sessionID}'
			if (QueryResult.Rows.Count <= 0)
			{
				throw new Exception("QueryResult is empty! No rows returned!");
			}
			String Status = QueryResult.Rows[0].ItemArray[0].ToString();
			return Status;
		}

		//Method to get the status from tblSOAP where event LOOKUP-WEB, based on InstanceId and SessionID
		//We are passing the parameters instanceID and sessionID
		//Then, we return the status as a String
		public static String TblSOAP_GetLookUpWeb_Status(int instanceID, string sessionID)
		{
			DataTable QueryResult = GetQueryResult(
				"Data Source=192.168.130.2; Initial Catalog = IVR_BORDER_AGILE_TEST; User ID = ivr; Password = letmein",
				 $"select top (1) status from tblSOAP where InstanceId = {instanceID} " +
				 $"and event = 'LOOKUP-WEB' and Reference = '{sessionID}' order by 1 desc");
			//Bear in mind, if you want to pass a string into SQL query remember to add ' ' before and after the parameter
			//e.g. and reference = '{sessionID}'
			if (QueryResult.Rows.Count <= 0)
			{
				throw new Exception("QueryResult is empty! No rows returned!");
			}
			// 7 is the index of column STATUS
			String Status = QueryResult.Rows[0].ItemArray[0].ToString();
			return Status;
		}

		//Method to get the status from tblSOAP where event LOOKUP-WEBHOOKS, based on InstanceId and SessionID
		//We are passing the parameters instanceID and sessionID
		//Then, we return the status as a String
		public static String TblSOAP_GetLookUpWebHook_Status(int instanceID, string sessionID)
		{
			DataTable QueryResult = GetQueryResult(
				"Data Source=192.168.130.2; Initial Catalog = IVR_BORDER_AGILE_TEST; User ID = ivr; Password = letmein",
				$"select top(1) S.status from tblSOAP as S " +
				$"inner join tblPayments as P on P.InstanceId = S.InstanceId " +
				$"where S.Reference2 = '{sessionID}' " +
				$"and S.event = 'LOOKUP-WEBHOOKS' " +
				$"and P.PaymentID = S.PaymentID " +
				$"and P.InstanceId = {instanceID} " +
				$"order by S.submittedAt desc;");
			//Bear in mind, if you want to pass a string into SQL query remember to add ' ' before and after the parameter
			//e.g. and reference = '{sessionID}'
			if (QueryResult.Rows.Count <= 0)
			{
				throw new Exception("QueryResult is empty! No rows returned!");
			}
			// 7 is the index of column STATUS
			String Status = QueryResult.Rows[0].ItemArray[0].ToString();
			return Status;
		}

		//Method to get the CompletionRedirectUrl from tblSOAP where event LOOKUP-WEB, based on InstanceId and SessionID
		//We are passing the parameters instanceID and sessionID
		//Then, we return the CompletionRedirectUrl as a String
		public static String TblSOAP_GetCompletionRedirectUrl(int instanceID, string sessionID)
		{
			DataTable QueryResult = GetQueryResult(
				"Data Source=192.168.130.2; Initial Catalog = IVR_BORDER_AGILE_TEST; User ID = ivr; Password = letmein",
					$"select S.Reference4 from tblSOAP as S " +
					$"inner join tblPayments as P on P.InstanceId = S.InstanceId " +
					$"where S.Reference = '{sessionID}' " +
					$"and S.event = 'LOOKUP-WEB' " +
					$"and P.ID = S.PaymentGUID " +
					$"and p.InstanceId = {instanceID}");
			//Bear in mind, if you want to pass a string into SQL query remember to add ' ' before and after the parameter
			//e.g. and reference = '{sessionID}'
			if (QueryResult.Rows.Count <= 0)
			{
				throw new Exception("QueryResult is empty! No rows returned!");
			}
			String Status = QueryResult.Rows[0].ItemArray[0].ToString();
			return Status;
		}

		//Method to get the CancelRedirectUrl from tblSOAP where event LOOKUP-WEB, based on InstanceId and SessionID
		//We are passing the parameters instanceID and sessionID
		//Then, we return the CancelRedirectUrl as a String
		public static String TblSOAP_GetCancelRedirectUrl(int instanceID, string sessionID)
		{
			DataTable QueryResult = GetQueryResult(
				"Data Source=192.168.130.2; Initial Catalog = IVR_BORDER_AGILE_TEST; User ID = ivr; Password = letmein",
					$"select top (1) Reference5 from tblSOAP where InstanceId = {instanceID} " +
					$"and event = 'LOOKUP-WEB' and Reference = '{sessionID}' order by 1 desc");
			//Bear in mind, if you want to pass a string into SQL query remember to add ' ' before and after the parameter
			//e.g. and reference = '{sessionID}'
			if (QueryResult.Rows.Count <= 0)
			{
				throw new Exception("QueryResult is empty! No rows returned!");
			}
			String Status = QueryResult.Rows[0].ItemArray[0].ToString();
			return Status;
		}

		//Method to get the value for "agile_web_debit_card_only" from tblConfig_Boolean
		//We are passing the instanceID as parameter
		//Then, we return the value as a String
		public static String TblConfig_BooleanCheck_agile_web_debit_card_only(int instanceID)
		{
			DataTable QueryResult = GetQueryResult(
				"Data Source=192.168.130.2; Initial Catalog = IVR_BORDER_AGILE_TEST; User ID = ivr; Password = letmein",
				 $"select * from tblConfig_Boolean where InstanceId = {instanceID} and setting = 'agile_web_debit_card_only'");
			//Bear in mind, if you want to pass a string into SQL query remember to add ' ' before and after the parameter
			//e.g. and reference = '{sessionID}'
			if (QueryResult.Rows.Count <= 0)
			{
				throw new Exception("QueryResult is empty! No rows returned!");
			}
			// 2 is the index of column value
			String Status = QueryResult.Rows[0].ItemArray[2].ToString();
			return Status;
		}


		//Method to delete the rows in tblSOAP based on InstanceId and SessionID
		//We are passing the parameters instanceID and sessionID
		public static void TblSoap_DeleteRow(int instanceID, string sessionID)
		{
			String conn = "Data Source=192.168.130.2; Initial Catalog = IVR_BORDER_AGILE_TEST; User ID = ivr; Password = letmein";
			String query = $"delete from tblSOAP where Reference = '{sessionID}' and InstanceId = {instanceID}";

			SqlConnection Connection;  // It is for SQL connection
			DataSet ds = new DataSet();  // it is for storing query result
			try
			{
				Connection = new SqlConnection(conn);  // Declare SQL connection with connection string 
				Connection.Open();  // Connect to Database
				SqlDataAdapter adp = new SqlDataAdapter(query, Connection);  // Execute query on database 
				adp.Fill(ds);  // Store query result into DataSet object
				Console.WriteLine("Rows deleted in tblSOAP");
				Connection.Close();  // Close connection 
				Connection.Dispose();   // Dispose connection 
			}
			catch (Exception E)
			{
				Console.WriteLine("SQL Error");
				Console.WriteLine(E.Message);
			}
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
				SqlDataAdapter adp = new SqlDataAdapter(vQuery, Connection);  // Execute query on database 
				adp.Fill(ds);  // Store query result into DataSet object
				Connection.Close();  // Close connection 
				Connection.Dispose();   // Dispose connection 
			}
			catch (Exception E)
			{
				Console.WriteLine("SQL Error");
				Console.WriteLine(E.Message);
				return new DataTable();
			}
			return ds.Tables[0];
		}
		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	}
}
//Forza Juve! MM