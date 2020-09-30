<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonthlySummary.aspx.cs" MasterPageFile="~/Site.Master" Inherits="TIPR_FinancialReporting.MonthlySummary" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<body>
	<br />
        <div class="div_Member font_Main" style="width:350px">
			<label style="margin-bottom:18px">Select a month and year:</label> 
			<br />
			Month: 
			<asp:DropDownList runat="server" ID="ddlMonth" AutoPostBack="true" OnSelectedIndexChanged="GetMonthlySummaries">
				<asp:ListItem></asp:ListItem>
				<asp:ListItem Value ="1">January</asp:ListItem>
				<asp:ListItem Value ="2">February</asp:ListItem>
				<asp:ListItem Value ="3">March</asp:ListItem>
				<asp:ListItem Value ="4">April</asp:ListItem>
				<asp:ListItem Value ="5">May</asp:ListItem>
				<asp:ListItem Value ="6">June</asp:ListItem>
				<asp:ListItem Value ="7">July</asp:ListItem>
				<asp:ListItem Value ="8">August</asp:ListItem>
				<asp:ListItem Value ="9">September</asp:ListItem>
				<asp:ListItem Value ="10">October</asp:ListItem>
				<asp:ListItem Value ="11">November</asp:ListItem>
				<asp:ListItem Value ="12">December</asp:ListItem>
			</asp:DropDownList>
			Year:
			<asp:DropDownList runat="server" ID="ddlYear" AutoPostBack="true" OnSelectedIndexChanged="GetMonthlySummaries">
				<asp:ListItem></asp:ListItem>
				<asp:ListItem Value="1">2020</asp:ListItem>
			</asp:DropDownList>
        </div>

		<div id="grids" runat="server" visible="false" class="div_Member font_Main" style="width:350px;border-width:0px">
			Expenses:&nbsp;&nbsp;&nbsp;<label runat="server" id="lblExpenseTotal"></label><br />
					<asp:GridView ID="grdMonthlyExpenses" runat="server" CssClass="mGrid" ShowHeader="false" GridLines="None" OnRowDataBound="grdMonthlyExpenses_RowDataBound">
					</asp:GridView>
			<br /><br />
			Income:&nbsp;&nbsp;&nbsp;<label runat="server" id="lblIncomeTotal"></label><br />
					<asp:GridView ID="grdMonthlyIncome" runat="server" CssClass="mGrid" ShowHeader="false" GridLines="None">
					</asp:GridView>
		</div>
</body>
</html>
</asp:Content>