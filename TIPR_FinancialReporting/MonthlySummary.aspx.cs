using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TIPR_FinancialReporting.DataAccess;

namespace TIPR_FinancialReporting
{
	public partial class MonthlySummary : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{

			}
		}

		private void GetMonthlySummary_Expenses(int monthId, int yearId)
		{
			DataSet ds = Data.GetMonthlyExpenseSummary(monthId, yearId);
			DataRow newDr = null;
			DataTable newDt = new DataTable();

			if(ds.Tables.Count == 2)
			{
				DataTable dt = ds.Tables[0];

				//if(dt.Rows.Count > 0)
				//{
				//	foreach(DataRow dr in dt.Rows)
				//	{
				//		// add a header row
				//		newDr = newDt.NewRow();
				//		newDr["RowNumber"] = newDt.Rows.Count + 1;
				//	}
				//}

				dt = ds.Tables[1];
				newDt = new DataTable();

				if(dt.Rows.Count > 0)
				{
					for(int i = 1; i < dt.Rows.Count; i++)
					{
						newDr = dt.Rows[i];
						newDt.Rows.Add(newDr);
					}
					grdMonthlyExpenses.DataSource = newDt;
					grdMonthlyExpenses.DataBind();
				}
			}
		}

		private void GetMonthySummary_Income(int monthId, int yearId)
		{

		}

		protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				GetMonthlySummary_Expenses(Convert.ToInt16(ddlMonth.SelectedValue), Convert.ToInt16(ddlYear.SelectedItem));
			}
			catch(Exception ex) { }
		}

		protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Convert.ToInt16(ddlMonth.SelectedValue) > 0 & Convert.ToInt16(ddlYear.SelectedValue) > 0)
			{
				GetMonthlySummary_Expenses(Convert.ToInt16(ddlMonth.SelectedValue), Convert.ToInt16(ddlYear.SelectedItem.Text));
			}
		}

		protected void grdMonthlyExpenses_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void grdMonthlyExpenses_RowCreated(object sender, GridViewRowEventArgs e)
		{

		}

		protected void grdMonthlyExpenses_RowDataBound(object sender, GridViewRowEventArgs e)
		{

		}

		protected void grdMonthlyExpenses_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{

		}
	}
}