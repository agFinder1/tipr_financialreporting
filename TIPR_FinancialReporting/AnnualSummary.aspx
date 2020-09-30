<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnualSummary.aspx.cs" MasterPageFile="~/Site.Master" Inherits="TIPR_FinancialReporting.AnnualSummary" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<body>
	<div class="div_Member font_Main" style="width:350px;border-width:0px">	
		<asp:Table HorizontalAlign="Center" runat="server">
			<asp:TableRow>
				<asp:TableCell HorizontalAlign="Center">
					<label style="font-size:18px">Annual Summary</label>
				</asp:TableCell>
			</asp:TableRow>
		</asp:Table>
		<asp:UpdatePanel runat="server" ID="pnl1">
			<ContentTemplate>
				<div class="div_Member font_Main" style="width:350px;border-width:0px">	
					<label style="margin-bottom:18px">Select a year:</label> 
					<asp:DropDownList runat="server" ID="ddlYear" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
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
							<asp:GridView ID="grdMonthlyIncome" runat="server" CssClass="mGrid" ShowHeader="false" GridLines="None" OnRowDataBound="grdMonthlyIncome_RowDataBound">
							</asp:GridView>
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
    </div>
</body>
</html>
</asp:Content>