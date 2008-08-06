<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="CreateRide.aspx.cs" Inherits="GrabbaRide.Frontend.CreateRide" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FormView ID="CreateRideFormView" runat="server" DataKeyNames="RideID" DataSourceID="RidesLinqDataSource"
        DefaultMode="Insert">
        <InsertItemTemplate>
            <asp:HiddenField ID="UserIDHiddenField" runat="server" Value='<%# Bind("UserID") %>' />
            DepartureTime:
            <asp:TextBox ID="DepartureTimeTextBox" runat="server" Text='<%# Bind("DepartureTime") %>' />
            <asp:Calendar ID="DepartureTimeCalendar" runat="server" />
            <br />
            <br />
            ArrivalTime:
            <asp:TextBox ID="ArrivalTimeTextBox" runat="server" Text='<%# Bind("ArrivalTime") %>' />
            <br />
            ReturnRideID:
            <asp:TextBox ID="ReturnRideIDTextBox" runat="server" Text='<%# Bind("ReturnRideID") %>' />
            <br />
            CreationDate:
            <asp:TextBox ID="CreationDateTextBox" runat="server" Text='<%# Bind("CreationDate") %>' />
            <br />
            RecurringRideID:
            <asp:TextBox ID="RecurringRideIDTextBox" runat="server" Text='<%# Bind("RecurringRideID") %>' />
            <br />
            FromLocation:
            <asp:DropDownList ID="DropDownList1" runat="server" 
                DataSourceID="LocationsLinqDataSource" DataTextField="Name" 
                DataValueField="LocationID" SelectedValue='<%# Bind("FromLocationID") %>' />
            <br />
            ToLocation:
            <asp:DropDownList ID="ToLocationDropDownList" runat="server" DataSourceID="LocationsLinqDataSource"
                DataTextField="Name" DataValueField="LocationID" SelectedValue='<%# Bind("ToLocationID") %>' />
            <asp:LinqDataSource ID="LocationsLinqDataSource" runat="server" ContextTypeName="GrabbaRide.Database.GrabbaRideDBDataContext"
                OrderBy="Name" TableName="Locations">
            </asp:LinqDataSource>
            <br />
            User:
            <asp:TextBox ID="UserTextBox" runat="server" Text='<%# Bind("User") %>' />
            <br />
            ReturnRide:
            <asp:TextBox ID="ReturnRideTextBox" runat="server" Text='<%# Bind("ReturnRide") %>' />
            <br />
            RecurringRideInfo:
            <asp:TextBox ID="RecurringRideInfoTextBox" runat="server" Text='<%# Bind("RecurringRideInfo") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False"
                CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
    </asp:FormView>
    <asp:LinqDataSource ID="RidesLinqDataSource" runat="server" ContextTypeName="GrabbaRide.Database.GrabbaRideDBDataContext"
        EnableInsert="True" TableName="Rides">
    </asp:LinqDataSource>
</asp:Content>
