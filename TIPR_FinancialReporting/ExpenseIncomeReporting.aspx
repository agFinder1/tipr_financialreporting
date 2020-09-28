<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpenseIncomeReporting.aspx.cs" Inherits="TIPR_FinancialReporting.ExpenseIncomeReporting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
		<div>
		<asp:Table runat="server">
			<asp:TableRow>
				<asp:TableCell>
					<label>Expenses</label>
				</asp:TableCell>
			</asp:TableRow>
			<asp:TableRow>
				<asp:TableCell>
					Type:
					<asp:DropDownList ID="ddlExpenseTypes" runat="server">
						<asp:ListItem Text="Animals - Health/Medical/Vet"></asp:ListItem>
					</asp:DropDownList>
				</asp:TableCell>
				<asp:TableCell>
				</asp:TableCell>
			</asp:TableRow>
			<asp:TableRow>
				<asp:TableCell>
					Amount: 
					<asp:TextBox ID="txtExpenseAmount" runat="server" Width="40px"></asp:TextBox>
					<asp:RegularExpressionValidator runat="server" ID="regNumericExpAmount" ControlToValidate="txtExpenseAmount" 
							ValidationExpression="\d+" Display="Dynamic" ErrorMessage="* whole numbers only">
					</asp:RegularExpressionValidator>
					Date: <asp:TextBox ID="ExpenseDate" runat="server" TextMode="Date"></asp:TextBox>
				</asp:TableCell>
			</asp:TableRow>
			<asp:TableRow>
				<asp:TableCell>
					Notes: 
					<asp:TextBox ID="txtExpenseNotes" runat="server" Width="120px"></asp:TextBox>
				</asp:TableCell>
			</asp:TableRow>
		</asp:Table>
		<br />
		<asp:Table runat="server">
			<asp:TableRow>
				<asp:TableCell>
					<label>Income</label>
				</asp:TableCell>
			</asp:TableRow>
			<asp:TableRow>
				<asp:TableCell>
					Type:
					<asp:DropDownList ID="ddlIncomeTypes" runat="server">
						<asp:ListItem Text="Donations - PayPal"></asp:ListItem>
					</asp:DropDownList>
				</asp:TableCell>
				<asp:TableCell>
				</asp:TableCell>
			</asp:TableRow>
			<asp:TableRow>
				<asp:TableCell>
					Amount: 
					<asp:TextBox ID="txtIncomeAmount" runat="server" Width="40px"></asp:TextBox>
					<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="txtExpenseAmount" 
							ValidationExpression="\d+" Display="Dynamic" ErrorMessage="* whole numbers only">
					</asp:RegularExpressionValidator>
					Date: <asp:TextBox ID="IncomeDate" runat="server" TextMode="Date"></asp:TextBox>
				</asp:TableCell>
			</asp:TableRow>
			<asp:TableRow>
				<asp:TableCell>
					Notes: 
					<asp:TextBox ID="txtIncomeNotes" runat="server" Width="120px"></asp:TextBox>
				</asp:TableCell>
			</asp:TableRow>
		</asp:Table>
	</div>
    </form>
</body>
</html>
