<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenIDLogin.aspx.cs" Inherits="GrabbaRide.Frontend.OpenIDLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Log in with OpenID</title>
    <style type="text/css">
        #Text1
        {
            width: 214px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <img alt="OpenID" src="Images/OpenIDSmall.jpeg" 
        style="width: 166px; height: 44px" /><asp:TextBox 
        ID="textBox_openIDidentity" runat="server" AutoPostBack="True"></asp:TextBox>
    <asp:Button ID="Bttn_OpenIDLogin" runat="server" 
        onclick="Bttn_OpenIDLogin_Click" Text="LogIn" />
    <asp:CheckBox ID="CheckBox1" runat="server" />
    <div>
    
    </div>
    </form>
</body>
</html>
