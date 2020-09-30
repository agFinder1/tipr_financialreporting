<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpenseIncomeReporting.aspx.cs" MasterPageFile="~/Site.Master" Inherits="TIPR_FinancialReporting.ExpenseIncomeReporting" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<body>

		<div id="divExpenses" class="div_Member font_Main" style="width:230px">
			<asp:UpdatePanel runat="server" ID="pnl2">
				<ContentTemplate>
					Expense Category
					<br />
					<asp:DropDownList ID="ddlExpenseHeading" runat="server" OnSelectedIndexChanged="ddlExpenseHeading_SelectedIndexChanged" AutoPostBack="true" />
					<asp:Table ID="tblExpense" runat="server" Width="250" Visible="false">
						<asp:TableRow>
							<asp:TableCell>
								Sub-Category
								<br /><asp:DropDownList ID="ddlExpenseCategory" runat="server"/>
							</asp:TableCell>
						</asp:TableRow>
						<asp:TableRow>
							<asp:TableCell>
								Amount:&nbsp;
								<asp:TextBox ID="txtExpenseAmount" runat="server" Width="40px"></asp:TextBox>
								<asp:RegularExpressionValidator runat="server" ID="regNumericExpAmount" ControlToValidate="txtExpenseAmount" 
										ValidationExpression="\d+" Display="Dynamic" ForeColor="Red" ErrorMessage="whole numbers">
								</asp:RegularExpressionValidator>							
							</asp:TableCell>
						</asp:TableRow>
						<asp:TableRow>
							<asp:TableCell>
								Date:&nbsp;
								<asp:TextBox ID="txtExpenseDate" runat="server" TextMode="Date" Width="130"></asp:TextBox>							
							</asp:TableCell>
						</asp:TableRow>
						<asp:TableRow>
							<asp:TableCell>
								Note:&nbsp;
								<asp:TextBox ID="txtExpenseNotes" runat="server" Width="130"></asp:TextBox>
							</asp:TableCell>
						</asp:TableRow>
					</asp:Table>
				</ContentTemplate>
				<Triggers>
					<asp:AsyncPostBackTrigger ControlID="ddlExpenseHeading" EventName="SelectedIndexChanged" />
				</Triggers>
			</asp:UpdatePanel>
		</div>

		<div id="divIncome" class="div_Member font_Main" style="width:230px">
			<asp:UpdatePanel runat="server" ID="pnl1">
				<ContentTemplate>
					Income Category
					<br />
					<asp:DropDownList ID="ddlIncomeHeading" runat="server" OnSelectedIndexChanged="ddlIncomeHeading_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
					<asp:Table ID="tblIncome" runat="server" Width="250" Visible="false">
						<asp:TableRow>
							<asp:TableCell>
								Sub-Category
								<br /><asp:DropDownList ID="ddlIncomeCategory" runat="server"></asp:DropDownList>
							</asp:TableCell>
						</asp:TableRow>
						<asp:TableRow>
							<asp:TableCell>
								Amount:&nbsp;
								<asp:TextBox ID="txtIncomeAmount" runat="server" Width="40px"></asp:TextBox>
								<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator2" ControlToValidate="txtExpenseAmount" 
										ValidationExpression="\d+" Display="Dynamic" ForeColor="Red" ErrorMessage="whole numbers">
								</asp:RegularExpressionValidator>							
							</asp:TableCell>
						</asp:TableRow>
						<asp:TableRow>
							<asp:TableCell>
								Date: <asp:TextBox ID="txtIncomeDate" runat="server" TextMode="Date" Width="130"></asp:TextBox>
							</asp:TableCell>
						</asp:TableRow>
						<asp:TableRow>
							<asp:TableCell>
								Note: <asp:TextBox ID="txtIncomeNotes" runat="server" Width="130"></asp:TextBox>
							</asp:TableCell>
						</asp:TableRow>
					</asp:Table>

				</ContentTemplate>
				<Triggers>
					<asp:AsyncPostBackTrigger ControlID="ddlIncomeHeading" EventName="SelectedIndexChanged" />
				</Triggers>
			</asp:UpdatePanel>
		</div>

		<div class="div_Member font_Main" style="width:230px; border-width:0px;">
			<asp:Table runat="server" Width="200">
				<asp:TableRow>
					<asp:TableCell HorizontalAlign="Center">
    					<asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /><br />
						<asp:Label runat="server" ID="lblExpenseCreated" ForeColor="Blue" Text="*Expense Transaction Created" Visible="false"></asp:Label><br />
						<asp:Label runat="server" ID="lblIncomeCreated" ForeColor="Blue" Text="*Income Transaction Created" Visible="false"></asp:Label><br />
						<asp:Label runat="server" ID="lblNoExpenseAmount" ForeColor="Red" Text="*Expense Amount Missing" Visible="false"></asp:Label><br />
						<asp:Label runat="server" ID="lblNoIncomeAmount" ForeColor="Red" Text="*Income Amount Missing" Visible="false"></asp:Label><br />
						<asp:Label runat="server" ID="lblErrorExpense" ForeColor="Red" Text="*Error Posting Expense" Visible="false"></asp:Label><br />
						<asp:Label runat="server" ID="lblErrorIncome" ForeColor="Red" Text="*Error Posting Income" Visible="false"></asp:Label>
					</asp:TableCell>
				</asp:TableRow>
			</asp:Table>
		</div>
		<asp:Timer ID="tmrLabels" runat="server" Interval="4000" OnTick="tmrLabels_Tick" Enabled="false" />
</body>
</html>
</asp:Content>