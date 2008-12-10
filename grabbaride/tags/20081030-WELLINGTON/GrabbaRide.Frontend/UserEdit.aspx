<%@ Page Title="GrabbaRide | Edit My Details" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="UserEdit.aspx.cs" Inherits="GrabbaRide.Frontend.UserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <img src="Images/system-users.png" alt="User" class="floatrightimg" />
    <h2>
        Edit My Details</h2>
    <h3>
        <asp:Label ID="UsernameLabel" runat="server" /></h3>
    <table class="user-details-table">
        <tr>
            <th>
                Email
            </th>
            <td>
                <asp:TextBox ID="EmailTextBox" runat="server" Columns="40"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                First Name
            </th>
            <td>
                <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                Last Name
            </th>
            <td>
                <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                Occupation
            </th>
            <td>
                <asp:TextBox ID="OccupationTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                Location
            </th>
            <td>
                <asp:TextBox ID="LocationTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                About Me
            </th>
            <td>
                <asp:TextBox ID="CommentTextBox" runat="server" TextMode="MultiLine" Columns="40"
                    Rows="5"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="SaveChangesButton" runat="server" Text="Update Details &#187;" OnClick="SaveChangesButton_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
