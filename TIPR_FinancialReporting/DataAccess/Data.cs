using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;


/*	Created On:	09/20/20
 *	Created By:	JS Rushing
 *	Descrip.:	Data access methods
 *	ToDo:
 *	Bug List:
 */

namespace TIPR_FinancialReporting.DataAccess
{
	public static class Data
	{
		private static string ConnString()
		{
			return ConfigurationManager.ConnectionStrings["main"].ToString();
		}

		public static DataTable GetExpenseCategoryHeadings()
		{
			DataTable dt = new DataTable();
			try
			{
				using (SqlConnection cnn = new SqlConnection(ConnString()))
				{
					using (SqlCommand cmd = new SqlCommand("GetExpenseCategoryHeadings", cnn))
					{
						cmd.Connection.Open();
						cmd.CommandType = CommandType.StoredProcedure;
						using (SqlDataAdapter da = new SqlDataAdapter(cmd))
						{
							da.Fill(dt);
							return dt;
						}
					}
				}
			}
			catch (Exception ex) { string s = ex.Message; }
			return dt;
		}

		public static DataTable GetExpenseCategories(int categoryHeaderId)
		{
			DataTable dt = new DataTable();
			try
			{
				using (SqlConnection cnn = new SqlConnection(ConnString()))
				{
					using (SqlCommand cmd = new SqlCommand("GetExpenseCategories", cnn))
					{
						cmd.Connection.Open();
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("categoryHeaderId", categoryHeaderId);
						using (SqlDataAdapter da = new SqlDataAdapter(cmd))
						{
							da.Fill(dt);
							return dt;
						}
					}
				}
			}
			catch (Exception ex) { string s = ex.Message; }
			return dt;
		}
		public static DataTable GetIncomeCategoryHeadings()
		{
			DataTable dt = new DataTable();
			try
			{
				using (SqlConnection cnn = new SqlConnection(ConnString()))
				{
					using (SqlCommand cmd = new SqlCommand("GetIncomeCategoryHeadings", cnn))
					{
						cmd.Connection.Open();
						cmd.CommandType = CommandType.StoredProcedure;
						using (SqlDataAdapter da = new SqlDataAdapter(cmd))
						{
							da.Fill(dt);
							return dt;
						}
					}
				}
			}
			catch (Exception ex) { string s = ex.Message; }
			return dt;
		}

		public static DataTable GetIncomeCategories(int categoryHeaderId)
		{
			DataTable dt = new DataTable();
			try
			{
				using (SqlConnection cnn = new SqlConnection(ConnString()))
				{
					using (SqlCommand cmd = new SqlCommand("GetIncomeCategories", cnn))
					{
						cmd.Connection.Open();
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("categoryHeaderId", categoryHeaderId);
						using (SqlDataAdapter da = new SqlDataAdapter(cmd))
						{
							da.Fill(dt);
							return dt;
						}
					}
				}
			}
			catch (Exception ex) { string s = ex.Message; }
			return dt;
		}
	}
}