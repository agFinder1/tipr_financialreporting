using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIPR_FinancialReporting
{
	public partial class ExpenseIncomeReporting : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			ExpenseDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			IncomeDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
		}

		protected void TextBox1_TextChanged(object sender, EventArgs e)
		{

		}

		protected void txtExpenseAmount_TextChanged(object sender, EventArgs e)
		{

		}
	}
}