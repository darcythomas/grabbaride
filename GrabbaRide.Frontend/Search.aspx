<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Search.aspx.cs" Inherits="GrabbaRide.Frontend.WebForm5" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="ListView1" runat="server" DataSourceID="GrabbaRideDataSource">
        <AlternatingItemTemplate>
            <tr style="background-color: #FFFFFF; color: #284775;">
                <td>
                    <asp:Label ID="ToLocationLabel" runat="server" Text='<%# Eval("ToLocation") %>' />
                </td>
                <td>
                    <asp:Label ID="FromLocationLabel" runat="server" Text='<%# Eval("FromLocation") %>' />
                </td>
                <td>
                    <asp:Label ID="DepartureTimeLabel" runat="server" Text='<%# Eval("DepartureTime") %>' />
                </td>
                <td>
                    <asp:Label ID="ArrivalTimeLabel" runat="server" Text='<%# Eval("ArrivalTime") %>' />
                </td>
                <td>
                    <asp:Label ID="UserLabel" runat="server" Text='<%# Eval("User") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;
                            border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;
                            font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="background-color: #E0FFFF; color: #333333;">
                                <th runat="server">
                                    ToLocation
                                </th>
                                <th runat="server">
                                    FromLocation
                                </th>
                                <th runat="server">
                                    DepartureTime
                                </th>
                                <th runat="server">
                                    ArrivalTime
                                </th>
                                <th runat="server">
                                    User
                                </th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif;
                        color: #FFFFFF">
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
                <td>
                    <asp:TextBox ID="ToLocationTextBox" runat="server" Text='<%# Bind("ToLocation") %>' />
                </td>
                <td>
                    <asp:TextBox ID="FromLocationTextBox" runat="server" Text='<%# Bind("FromLocation") %>' />
                </td>
                <td>
                    <asp:TextBox ID="DepartureTimeTextBox" runat="server" Text='<%# Bind("DepartureTime") %>' />
                </td>
                <td>
                    <asp:TextBox ID="ArrivalTimeTextBox" runat="server" Text='<%# Bind("ArrivalTime") %>' />
                </td>
                <td>
                    <asp:TextBox ID="UserTextBox" runat="server" Text='<%# Bind("User") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <SelectedItemTemplate>
            <tr style="background-color: #E2DED6; font-weight: bold; color: #333333;">
                <td>
                    <asp:Label ID="ToLocationLabel" runat="server" Text='<%# Eval("ToLocation") %>' />
                </td>
                <td>
                    <asp:Label ID="FromLocationLabel" runat="server" Text='<%# Eval("FromLocation") %>' />
                </td>
                <td>
                    <asp:Label ID="DepartureTimeLabel" runat="server" Text='<%# Eval("DepartureTime") %>' />
                </td>
                <td>
                    <asp:Label ID="ArrivalTimeLabel" runat="server" Text='<%# Eval("ArrivalTime") %>' />
                </td>
                <td>
                    <asp:Label ID="UserLabel" runat="server" Text='<%# Eval("User") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse;
                border-color: #999999; border-style: none; border-width: 1px;">
                <tr>
                    <td>
                        No data was returned.
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EditItemTemplate>
            <tr style="background-color: #999999;">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
                <td>
                    <asp:TextBox ID="ToLocationTextBox" runat="server" Text='<%# Bind("ToLocation") %>' />
                </td>
                <td>
                    <asp:TextBox ID="FromLocationTextBox" runat="server" Text='<%# Bind("FromLocation") %>' />
                </td>
                <td>
                    <asp:TextBox ID="DepartureTimeTextBox" runat="server" Text='<%# Bind("DepartureTime") %>' />
                </td>
                <td>
                    <asp:TextBox ID="ArrivalTimeTextBox" runat="server" Text='<%# Bind("ArrivalTime") %>' />
                </td>
                <td>
                    <asp:TextBox ID="UserTextBox" runat="server" Text='<%# Bind("User") %>' />
                </td>
            </tr>
        </EditItemTemplate>
        <ItemTemplate runat="server">
            <label>
            </label>
        </ItemTemplate>
    </asp:ListView>
    <asp:LinqDataSource ID="GrabbaRideDataSource" runat="server" ContextTypeName="GrabbaRide.Database.GrabbaRideDBDataContext"
        OrderBy="DepartureTime" Select="new (ToLocation, FromLocation, DepartureTime, ArrivalTime, User)"
        TableName="Rides">
    </asp:LinqDataSource>
</asp:Content>
