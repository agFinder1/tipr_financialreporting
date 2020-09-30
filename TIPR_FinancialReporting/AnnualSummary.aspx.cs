using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIPR_FinancialReporting.DataAccess;
using System.Globalization;

namespace TIPR_FinancialReporting
{
	public partial class AnnualSummary : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				int total = 0;
				grdMonthlyExpenses.DataSource = Data.GetAnnualExpenseSummary(Convert.ToInt16(ddlYear.SelectedValue));
				grdMonthlyIncome.DataSource = Data.GetAnnualIncomeSummary(Convert.ToInt16(ddlYear.SelectedValue));
				grdMonthlyExpenses.DataBind();
				grdMonthlyIncome.DataBind();

				for (int i = 0; i < grdMonthlyExpenses.Rows.Count; i++)
				{
					if (grdMonthlyExpenses.Rows[i].Cells[1].Text.All(char.IsNumber))
					{
						total += Convert.ToInt32(grdMonthlyExpenses.Rows[i].Cells[1].Text);
					}
				}
				lblExpenseTotal.InnerText = total.ToString("C0", CultureInfo.CurrentCulture);
				total = 0;

				for (int i = 0; i < grdMonthlyIncome.Rows.Count; i++)
				{
					if (grdMonthlyIncome.Rows[i].Cells[1].Text.All(char.IsNumber))
					{
						total += Convert.ToInt32(grdMonthlyIncome.Rows[i].Cells[1].Text);
					}
				}
				lblIncomeTotal.InnerText = total.ToString("C0", CultureInfo.CurrentCulture);

				grids.Visible = grdMonthlyExpenses.Rows.Count > 0 | grdMonthlyIncome.Rows.Count > 0;

			}
			catch (Exception ex) { grids.Visible = false; }
		}

		protected void grdMonthlyExpenses_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if(e.Row.Cells[0].Text.All(char.IsNumber)) e.Row.Cells[0].Text = DateTimeFormatInfo.CurrentInfo.MonthNames[Convert.ToInt16(e.Row.Cells[0].Text) - 1];
		}

		protected void grdMonthlyIncome_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.Cells[0].Text.All(char.IsNumber)) e.Row.Cells[0].Text = DateTimeFormatInfo.CurrentInfo.MonthNames[Convert.ToInt16(e.Row.Cells[0].Text) - 1];
		}
	}
}