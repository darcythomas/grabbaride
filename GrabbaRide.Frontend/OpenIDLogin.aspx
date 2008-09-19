<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenIDLogin.aspx.cs" Inherits="GrabbaRide.Frontend.OpenIDLogin" %>

<%@ Register assembly="DotNetOpenId" namespace="DotNetOpenId.RelyingParty" tagprefix="RP" %>
<%@ Register assembly="DotNetOpenId" namespace="DotNetOpenId" tagprefix="openid" %>
<%@ Register assembly="DotNetOpenId" namespace="DotNetOpenId.Provider" tagprefix="OP" %>

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
    <div>
    
        <img alt="OpenID" src="Images/OpenIDSmall.jpeg" 
            style="width: 119px; height: 71px" /><RP:OpenIdLogin ID="OpenIdLogin1" 
            runat="server" />
    
    </div>
    </form>
</body>
</html>
