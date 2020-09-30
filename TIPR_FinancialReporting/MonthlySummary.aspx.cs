using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TIPR_FinancialReporting.DataAccess;
using System.Globalization;

namespace TIPR_FinancialReporting
{
	public partial class MonthlySummary : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{ }


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

		protected void GetMonthlySummaries(object sender, EventArgs e)
		{
			try
			{
				int total = 0;
				grdMonthlyExpenses.DataSource = null;
				grdMonthlyExpenses.DataBind();
				grdMonthlyIncome.DataSource = null;
				grdMonthlyIncome.DataBind();

				GetMonthlySummary_Expenses(Convert.ToInt16(ddlMonth.SelectedValue), Convert.ToInt16(ddlYear.SelectedItem.Text));
				GetMonthySummary_Income(Convert.ToInt16(ddlMonth.SelectedValue), Convert.ToInt16(ddlYear.SelectedItem.Text));

				for(int i = 0; i < grdMonthlyExpenses.Rows.Count; i++)
				{
					if(grdMonthlyExpenses.Rows[i].Cells[2].Text.All(char.IsNumber))
					{
						total += Convert.ToInt32(grdMonthlyExpenses.Rows[i].Cells[2].Text);
					}
				}
				lblExpenseTotal.InnerText = total.ToString("C0", CultureInfo.CurrentCulture);
				total = 0;

				for (int i = 0; i < grdMonthlyIncome.Rows.Count; i++)
				{
					if (grdMonthlyIncome.Rows[i].Cells[2].Text.All(char.IsNumber))
					{
						total += Convert.ToInt32(grdMonthlyIncome.Rows[i].Cells[2].Text);
					}		
				}
				lblIncomeTotal.InnerText = total.ToString("C0", CultureInfo.CurrentCulture);

				grids.Visible = grdMonthlyExpenses.Rows.Count > 0 | grdMonthlyIncome.Rows.Count > 0;
			}
			catch (Exception ex) { grids.Visible = false; }
		}

		protected void grdMonthlyExpenses_RowDataBound(object sender, GridViewRowEventArgs e)
		{
		}

	}
}