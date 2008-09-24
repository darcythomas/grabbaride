<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="GrabbaRide.Frontend.WebForm3" Title="Untitled Page" %>

<%@ Register Assembly="DotNetOpenId" Namespace="DotNetOpenId.RelyingParty" TagPrefix="RP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">

    <script type="text/javascript">
        function Hide(divId)
        {
            var control = document.getElementById(controlId);
            control.style.visibility = "hidden";
        }
        function Show(divId)
        {
            var control = document.getElementById(controlId);
            control.style.visibility = "visible";
        }


    function Radio_NormalLogIn_onclick() {
    
    }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <input id="Radio_NormalLogIn"  checked="checked" type="radio" onclick="return Radio_NormalLogIn_onclick()" /><input 
                ID="Radio_OpenID" type="radio" />
            <div id="NormalLogInDiv" style="visibility: visible">
                <asp:Login ID="GrabbaRideLogin" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE"
                    BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana"
                    Font-Size="0.8em" ForeColor="#333333" Style="text-align: center" Width="291px"
                    CreateUserText="Create Account" CreateUserUrl="Register.aspx">
                    <TextBoxStyle Font-Size="0.8em" />
                    <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px"
                        Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                    <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                </asp:Login>
            </div>
     
                <div id="openIDDiv" style="visibility: hidden">
                    <RP:OpenIdLogin ID="OpenIdLogin1" runat="server" />
                </div>
    
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
