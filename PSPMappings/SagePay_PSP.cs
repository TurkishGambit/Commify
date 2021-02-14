using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CommifyMSTestFramework.PSPMappings
{
	public class SagePay_PSP
	{
		public static String VendorTxCode(int instanceID, string sessionID)
		{
			DataTable QueryResult = GetQueryResult(
				"Data Source=192.168.130.2; Initial Catalog = IVR_BORDER_AGILE_TEST; User ID = ivr; Password = letmein",
				 $"DECLARE @ClientUniqueID_tblSOAP varchar(500); " +
				 $"SET @ClientUniqueID_tblSOAP = (" +
				 $"SELECT top(1) ClientUniqueId " +
				 $"FROM " +
				 $"tblSOAP " +
				 $"WHERE InstanceId = {instanceID} AND event = 'LOOKUP-WEB' and Reference = '{sessionID}' " +
				 $"order by submittedAt desc); " +
				 $"DECLARE @ClientUniqueID_tblPayments varchar(500); " +
				 $"SET @ClientUniqueID_tblPayments = ( SELECT top(1) P.ClientUniqueID " +
				 $"FROM tblPayments as P " +
				 $"INNER JOIN tblSOAP as S on S.InstanceId = P.InstanceId " +
				 $"WHERE P.InstanceId = {instanceID} " +
				 $"and S.Reference = '{sessionID}' " +
				 $"AND S.event = 'LOOKUP-WEB' " +
				 $"AND P.ID = S.PaymentGUID " +
				 $"ORDER BY IVRSubmittedDate desc); " +
				 $"IF (@ClientUniqueID_tblSOAP = @ClientUniqueID_tblPayments) " +
				 $"BEGIN " +
				 $"DECLARE @substring_XML_Sent varchar(100); " +
				 $"SET @substring_XML_Sent = (SELECT top(1) row " +
				 $"FROM " +
				 $"(SELECT top (1) SUBSTRING(XML_SENT, CHARINDEX('VendorTxCode=' , XML_SENT), 13 + LEN(@ClientUniqueID_tblSOAP)) as row " +
				 $"FROM tblPayments where InstanceId = {instanceID} order by IVRSubmittedDate desc) p); " +
				 $"DECLARE @ordercode_tblPayments_XML_Sent varchar(100); " +
				 $"SET @ordercode_tblPayments_XML_Sent = (" +
				 $"SUBSTRING(@substring_XML_Sent, 14, LEN(@ClientUniqueID_tblSOAP))); " +
				 $"IF(@ordercode_tblPayments_XML_Sent = @ClientUniqueID_tblSOAP) " +
				 $"BEGIN " +
				 $"SELECT " +
				 $"'Status' = 'SUCCESS -> VendorTxCode sent: ' + @ordercode_tblPayments_XML_Sent " +
				 $"END " +
				 $"ELSE " +
				 $"BEGIN " +
				 $"SELECT 'Status' = 'Failed - VendorTXCode doesn''t match' " +
				 $"END " +
				 $"END " +
				 $"ELSE " +
				 $"BEGIN " +
				 $"SELECT 'Status' = 'Failed - ClientUniqueIDs don''t match' " +
				 $"END");
			//Bear in mind, if you want to pass a string into SQL query remember to add ' ' before and after the parameter
			//e.g. and reference = '{sessionID}'
			if (QueryResult.Rows.Count <= 0)
			{
				throw new Exception("QueryResult is empty! No rows returned!");
			}
			String Status = QueryResult.Rows[0].ItemArray[0].ToString();
			return Status;
		}

		public static String Description(int instanceID, string sessionID)
		{
			DataTable QueryResult = GetQueryResult(
				"Data Source=192.168.130.2; Initial Catalog = IVR_BORDER_AGILE_TEST; User ID = ivr; Password = letmein",
				 $"DECLARE @Reference_tblPayments varchar(500); " +
				 $"SET @Reference_tblPayments = (SELECT top(1) " +
				 $"P.reference " +
				 $"FROM tblPayments as P " +
				 $"INNER JOIN tblSOAP as S on S.InstanceId = P.InstanceId " +
				 $"WHERE S.InstanceId = {instanceID} AND event = 'LOOKUP-WEB' and S.Reference = '{sessionID}' " +
				 $"AND S.PaymentGUID = P.ID " +
				 $"ORDER BY submittedAt desc ); " +
				 $"DECLARE @substring_XML_Sent varchar(500); " +
				 $"SET @substring_XML_Sent = (SELECT top(1)	row " +
				 $"FROM (SELECT top (1) SUBSTRING(XML_SENT, CHARINDEX('Description=', XML_SENT), " +
				 $"12 + LEN(@Reference_tblPayments)) as row " +
				 $"FROM tblPayments where InstanceId = {instanceID} order by IVRSubmittedDate desc) p); " +
				 $"DECLARE @description_tblPayments_XML_Sent varchar(100); " +
				 $"SET @description_tblPayments_XML_Sent = (SUBSTRING(@substring_XML_Sent, 13, LEN(@Reference_tblPayments))); " +
				 $"IF(@description_tblPayments_XML_Sent = @Reference_tblPayments) " +
				 $"BEGIN " +
				 $"SELECT 'Status' = 'SUCCESS -> Description sent: ' + @description_tblPayments_XML_Sent " +
				 $"END " +
				 $"ELSE	" +
				 $"BEGIN " +
				 $"SELECT 'Status' = 'Failed - Description doesn''t match' " +
				 $"END");
			//Bear in mind, if you want to pass a string into SQL query remember to add ' ' before and after the parameter
			//e.g. and reference = '{sessionID}'
			if (QueryResult.Rows.Count <= 0)
			{
				throw new Exception("QueryResult is empty! No rows returned!");
			}
			String Status = QueryResult.Rows[0].ItemArray[0].ToString();
			return Status;
		}




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
	}
}
