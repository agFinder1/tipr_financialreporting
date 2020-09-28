using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIPR_FinancialReporting
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Submit_Click(object sender, EventArgs e)
		{
			if (txtUserName.Text == "") lblUsrErr.Visible = true;
			if (txtPassword.Text == "") lblPwdErr.Visible = true;

			if(txtUserName.Text != "" & txtPassword.Text != "")
			{
				// check db

			}
		}

		protected void txtUserName_TextChanged(object sender, EventArgs e)
		{
			lblUsrErr.Visible = false;
		}

		protected void txtPassword_TextChanged(object sender, EventArgs e)
		{
			lblPwdErr.Visible = false;
		}
	}
}