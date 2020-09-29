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
			if(ddlExpenseHeading.SelectedIndex > 0)
			{
				if(txtExpenseAmount.Text.Length == 0)
				{
					lblNoExpenseAmount.Visible = true;
				}
				else
				{
					if(Data.CreateTransaction(1, Convert.ToInt16(ddlExpenseHeading.SelectedItem.Value), Convert.ToInt16(ddlExpenseCategory.SelectedItem.Value), 
						Convert.ToInt32(txtExpenseAmount.Text), txtExpenseNotes.Text, Convert.ToDateTime(txtExpenseDate.Text)) > 0)
					{
						lblExpenseCreated.Visible = true;
						ddlExpenseHeading.SelectedIndex = 0;
						ddlExpenseHeading_SelectedIndexChanged(null, null);
					}
					else
					{
						lblErrorExpense.Visible = true;
					}
				}
			}

			if(ddlIncomeHeading.SelectedIndex > 0)
			{
				if (txtIncomeAmount.Text.Length == 0)
				{
					lblNoIncomeAmount.Visible = true;
				}
				else
				{
					if (Data.CreateTransaction(2, Convert.ToInt16(ddlIncomeHeading.SelectedItem.Value), Convert.ToInt16(ddlIncomeCategory.SelectedItem.Value),
						Convert.ToInt32(txtIncomeAmount.Text), txtIncomeNotes.Text, Convert.ToDateTime(txtIncomeDate.Text)) > 0)
					{
						lblIncomeCreated.Visible = true;
						ddlIncomeHeading.SelectedIndex = 0;
						ddlIncomeHeading_SelectedIndexChanged(null, null);
					}
					else
					{
						lblErrorIncome.Visible = true;
					}
				}
			}

			tmrLabels.Enabled = lblExpenseCreated.Visible | lblIncomeCreated.Visible | lblErrorExpense.Visible | 
				lblErrorIncome.Visible | lblNoExpenseAmount.Visible | lblNoIncomeAmount.Visible;

		}

		protected void ddlExpenseHeading_SelectedIndexChanged(object sender, EventArgs e)
		{
			tblExpense.Visible = Convert.ToInt16(ddlExpenseHeading.SelectedItem.Value) > 0;

			if (tblExpense.Visible)
			{
				ddlExpenseCategory.DataSource = Data.GetExpenseCategories(Convert.ToInt16(ddlExpenseHeading.SelectedItem.Value));
				ddlExpenseCategory.DataTextField = "Category";
				ddlExpenseCategory.DataValueField = "Id";
				ddlExpenseCategory.DataBind();
			}
			else
			{
				txtExpenseAmount.Text = string.Empty;
				txtExpenseDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
				txtExpenseNotes.Text = string.Empty;
			}	
		}

		protected void ddlIncomeHeading_SelectedIndexChanged(object sender, EventArgs e)
		{
			tblIncome.Visible = Convert.ToInt16(ddlIncomeHeading.SelectedItem.Value) > 0;

			if(tblIncome.Visible)
			{
				ddlIncomeCategory.DataSource = Data.GetIncomeCategories(Convert.ToInt16(ddlIncomeHeading.SelectedItem.Value));
				ddlIncomeCategory.DataTextField = "Category";
				ddlIncomeCategory.DataValueField = "Id";
				ddlIncomeCategory.DataBind();
			}
			else
			{
				txtIncomeAmount.Text = string.Empty;
				txtIncomeDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
				txtIncomeNotes.Text = string.Empty;
			}
		}

		protected void tmrLabels_Tick(object sender, EventArgs e)
		{
			tmrLabels.Enabled = false;
			lblExpenseCreated.Visible = false;
			lblIncomeCreated.Visible = false;
			lblNoExpenseAmount.Visible = false;
			lblNoIncomeAmount.Visible = false;
		}
	}
}