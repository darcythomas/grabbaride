<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="CreateRide.aspx.cs" Inherits="GrabbaRide.Frontend.CreateRide" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FormView ID="CreateRideFormView" runat="server" DataKeyNames="RideID" DataSourceID="RidesLinqDataSource"
        DefaultMode="Insert">
        <InsertItemTemplate>
            <asp:HiddenField ID="UserIDHiddenField" runat="server" Value='<%# Bind("UserID") %>' />
            <asp:HiddenField ID="CreationDateHiddenField" runat="server" Value='<%# Bind("CreationDate") %>' />
            DepartureTime:
            <asp:TextBox ID="DepartureTimeTextBox" runat="server" Text='<%# Bind("DepartureTime") %>' />
            <asp:Calendar ID="DepartureTimeCalendar" runat="server" 
                OnSelectionChanged="DepartureTimeCalendar_SelectionChanged" BackColor="White" 
                BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                ForeColor="#003399" Height="200px" Width="220px" >
                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                <WeekendDayStyle BackColor="#CCCCFF" />
                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                    Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            </asp:Calendar>
            <br />
            ArrivalTime:
            <asp:TextBox ID="ArrivalTimeTextBox" runat="server" Text='<%# Bind("ArrivalTime") %>' />
            <asp:Calendar ID="ArrivalTimeCalendar" runat="server" 
                OnSelectionChanged="ArrivalTimeCalendar_SelectionChanged" BackColor="White" 
                BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                ForeColor="#003399" Height="200px" Width="220px" >
                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                <WeekendDayStyle BackColor="#CCCCFF" />
                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                    Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            </asp:Calendar>
            <br />
            <br />
            CreationDate:
            <asp:TextBox ID="CreationDateTextBox" runat="server" Text='<%# Bind("CreationDate") %>' />
            <br />
            RecurringRideID:
            FromLocation:
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="LocationsLinqDataSource"
                DataTextField="Name" DataValueField="LocationID" SelectedValue='<%# Bind("FromLocationID") %>' />
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
