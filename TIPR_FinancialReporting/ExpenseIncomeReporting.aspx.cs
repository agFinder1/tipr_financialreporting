using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIPR_FinancialReporting.DataAccess;

namespace TIPR_FinancialReporting
{
	public partial class ExpenseIncomeReporting : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				txtExpenseDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
				txtIncomeDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

				ddlExpenseHeading.DataSource = DataAccess.Data.GetExpenseCategoryHeadings();
				ddlExpenseHeading.DataTextField = "CategoryHeader";
				ddlExpenseHeading.DataValueField = "CategoryHeaderId";
				ddlExpenseHeading.DataBind();

				ddlIncomeHeading.DataSource = Data.GetIncomeCategoryHeadings();
				ddlIncomeHeading.DataTextField = "CategoryHeader";
				ddlIncomeHeading.DataValueField = "CategoryHeaderId";
				ddlIncomeHeading.DataBind();
			}
		}


		protected void btnSubmit_Click(object sender, EventArgs e)
		{

		}

		protected void ddlExpenseHeading_SelectedIndexChanged(object sender, EventArgs e)
		{
			tblExpense.Visible = Convert.ToInt16(ddlExpenseHeading.SelectedItem.Value) > 0;

			if (tblExpense.Visible)
			{
				ddlExpenseCategory.DataSource = Data.GetExpenseCategories(Convert.ToInt16(ddlExpenseHeading.SelectedItem.Value));
				ddlExpenseCategory.DataTextField = "Category";
				ddlExpenseCategory.DataBind();
			}
			
		}

		protected void ddlIncomeHeading_SelectedIndexChanged(object sender, EventArgs e)
		{
			tblIncome.Visible = Convert.ToInt16(ddlIncomeHeading.SelectedItem.Value) > 0;

			if(tblIncome.Visible)
			{
				ddlIncomeCategory.DataSource = Data.GetIncomeCategories(Convert.ToInt16(ddlIncomeHeading.SelectedItem.Value));
				ddlIncomeCategory.DataValueField = "Category";
				ddlIncomeCategory.DataBind();
			}
		}
	}
}