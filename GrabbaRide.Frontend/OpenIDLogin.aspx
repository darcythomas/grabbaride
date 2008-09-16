<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenIDLogin.aspx.cs" Inherits="GrabbaRide.Frontend.OpenIDLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Login With Your OpenID</title>
    <style type="text/css">
        #OpenIDLoginFeild
        {
            width: 232px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <img alt="Log in with OpenID" src="Images/OpenIDSmall.jpeg" 
            style="width: 135px; height: 41px" /><input id="OpenIDLoginFeild" 
            type="text" /><input id="LogInButton" type="button" value="Log In" onclick="return LogInButton_onclick()" /></div>
    </form>
</body>
</html>
