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
			grdMonthlyExpenses.DataSource = Data.GetMonthlyExpenseSummary(monthId, yearId);
			grdMonthlyExpenses.DataBind();
		}

		private void GetMonthySummary_Income(int monthId, int yearId)
		{
			grdMonthlyIncome.DataSource = Data.GetMonthlyIncomeSummary(monthId, yearId);
			grdMonthlyIncome.DataBind();
		}

		protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				grdMonthlyExpenses.DataSource = null;
				grdMonthlyExpenses.DataBind();
				GetMonthlySummary_Expenses(Convert.ToInt16(ddlMonth.SelectedValue), Convert.ToInt16(ddlYear.SelectedItem.Text));
				GetMonthySummary_Income(Convert.ToInt16(ddlMonth.SelectedValue), Convert.ToInt16(ddlYear.SelectedItem.Text));
				grids.Visible = grdMonthlyExpenses.Rows.Count > 0 | grdMonthlyIncome.Rows.Count > 0;
			}
			catch (Exception ex) { }
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
			e.Row.BorderStyle = BorderStyle.None;
		}

		protected void grdMonthlyExpenses_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{

		}
	}
}