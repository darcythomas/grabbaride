<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Search.aspx.cs" Inherits="GrabbaRide.Frontend.WebForm5" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="RideID" DataSourceID="GrabbaRideDataSource">
        <Columns>
            <asp:BoundField DataField="SearchRank" HeaderText="SearchRank" 
                SortExpression="SearchRank" />
            <asp:BoundField DataField="RideID" HeaderText="RideID" InsertVisible="False" 
                ReadOnly="True" SortExpression="RideID" />
            <asp:BoundField DataField="UserID" HeaderText="UserID" 
                SortExpression="UserID" />
            <asp:BoundField DataField="FromLocationID" HeaderText="FromLocationID" 
                SortExpression="FromLocationID" />
            <asp:BoundField DataField="ToLocationID" HeaderText="ToLocationID" 
                SortExpression="ToLocationID" />
            <asp:BoundField DataField="DepartureTime" HeaderText="DepartureTime" 
                SortExpression="DepartureTime" />
            <asp:BoundField DataField="ArrivalTime" HeaderText="ArrivalTime" 
                SortExpression="ArrivalTime" />
            <asp:BoundField DataField="ReturnRideID" HeaderText="ReturnRideID" 
                SortExpression="ReturnRideID" />
            <asp:BoundField DataField="CreationDate" HeaderText="CreationDate" 
                SortExpression="CreationDate" />
            <asp:BoundField DataField="RecurringRideID" HeaderText="RecurringRideID" 
                SortExpression="RecurringRideID" />
        </Columns>
    </asp:GridView>
    <asp:LinqDataSource ID="GrabbaRideDataSource" runat="server" 
        ContextTypeName="GrabbaRide.Database.GrabbaRideDBDataContext" TableName="Rides">
    </asp:LinqDataSource>
    </asp:Content>
