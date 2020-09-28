<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TIPR_FinancialReporting.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
			<label>Login</label>
        </div>
			<br />
		<div>
    		User name: <asp:TextBox ID="txtUserName" runat="server" OnTextChanged="txtUserName_TextChanged" Width="102px" MaxLength="20"></asp:TextBox>
			&nbsp;<asp:Label runat="server" ID="lblUsrErr" Text="Enter User Name" Visible="False" ForeColor="Red"></asp:Label>
			<br />
			<br />
			Password: &nbsp;<asp:TextBox ID="txtPassword" runat="server" OnTextChanged="txtPassword_TextChanged" Width="102px" MaxLength="20"></asp:TextBox>
			&nbsp;<asp:Label runat="server" ID="lblPwdErr" Text="Enter Password" Visible="False" ForeColor="Red"></asp:Label>
		</div>
		<br />
		<div>
			<asp:Button ID="Submit" runat="server" Text="Login" OnClick="Submit_Click"/>
		</div>
    </form>
</body>
</html>
