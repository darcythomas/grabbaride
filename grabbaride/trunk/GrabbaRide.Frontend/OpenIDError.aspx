<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableViewState="true" CodeBehind="OpenIDError.aspx.cs" Inherits="GrabbaRide.Frontend.OpenIDError"
    Title="GrabbaRide | OpenID Registration" %>

<%@ Register Assembly="DotNetOpenId" Namespace="DotNetOpenId.RelyingParty" TagPrefix="RP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>
        OpenID Registration</h2>
    <p>
        We notice that this is the first time visiting our site! Before you continue, please
        fill in the following details...</p>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="user-details-table">
                <tr>
                    <th>
                        GrabbaRide<br />
                        Username
                    </th>
                    <td>
                        <asp:TextBox ID="NewUserNameText" runat="server"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="UsernameRequiredFieldValidator" runat="server" ErrorMessage="You must choose a GrabbaRide username!"
                            ControlToValidate="NewUserNameText" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="UsernameValidator" runat="server" ErrorMessage="Username exists!"
                            ControlToValidate="NewUserNameText" OnServerValidate="UsernameValidator_ServerValidate"
                            Display="Dynamic" SetFocusOnError="True"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <th>
                        First Name
                    </th>
                    <td>
                        <asp:TextBox ID="TxtBox_First" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        Last Name
                    </th>
                    <td>
                        <asp:TextBox ID="TxtBox_Last" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        Email
                    </th>
                    <td>
                        <asp:TextBox ID="TxtBox_Email" runat="server" Columns="30"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator1" runat="server" ErrorMessage="You must enter an email address!"
                            ControlToValidate="TxtBox_Email" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator1" runat="server"
                            ErrorMessage="This email address is not valid!" ControlToValidate="TxtBox_Email"
                            ValidationExpression="^([^ ])+@([^ ])+$"></asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="EmailCustomValidator1" runat="server" ErrorMessage="This email is already in use!"
                            ControlToValidate="TxtBox_Email" OnServerValidate="EmailCustomValidator1_ServerValidate"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <th>
                    </th>
                    <td>
                        <asp:Button ID="SubmitBttn" runat="server" OnClick="SubmitBttn_Click" Text="Continue &#187;" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
