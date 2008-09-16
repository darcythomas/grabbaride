<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Search.aspx.cs" Inherits="GrabbaRide.Frontend.WebForm5" Title="GrabbaRide Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">

    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;key=ABQIAAAAdzIHDEcQlKVK0ZsLXgw7AxT2yXp_ZAY8_ufC3CFXhHIE1NvwkxTe_yeQBDaUEW7-M67E9zLbOak5Xw"
        type="text/javascript"></script>

    <script type="text/javascript" src="GoogleMaps.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div id="gdiv" style="float: right;">
        <p>
            <input id="txtgeo" type="text" size="60" name="address" value="Palmerston North" />
            <input id="btngeocode" type="button" value="Find" onclick="var address = document.getElementById('txtgeo'); showAddress(address.value); return false" />
        </p>
        <div id="searchmap" style="width: 400px; height: 400px;">
        </div>
    </div>
    Time:<br />
    <asp:DropDownList ID="drphours" runat="server">
        <asp:ListItem Value="1"></asp:ListItem>
        <asp:ListItem Value="2"></asp:ListItem>
        <asp:ListItem Value="3"></asp:ListItem>
        <asp:ListItem Value="4"></asp:ListItem>
        <asp:ListItem Value="5"></asp:ListItem>
        <asp:ListItem Value="6"></asp:ListItem>
        <asp:ListItem Value="7"></asp:ListItem>
        <asp:ListItem Value="8"></asp:ListItem>
        <asp:ListItem Value="9"></asp:ListItem>
        <asp:ListItem Value="10"></asp:ListItem>
        <asp:ListItem Value="11"></asp:ListItem>
        <asp:ListItem Value="12"></asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="drpmins" runat="server">
        <asp:ListItem Value="0">00</asp:ListItem>
        <asp:ListItem Value="5">05</asp:ListItem>
        <asp:ListItem Value="10">10</asp:ListItem>
        <asp:ListItem Value="15">15</asp:ListItem>
        <asp:ListItem Value="20">20</asp:ListItem>
        <asp:ListItem Value="25">25</asp:ListItem>
        <asp:ListItem Value="30">30</asp:ListItem>
        <asp:ListItem Value="35">35</asp:ListItem>
        <asp:ListItem Value="40">40</asp:ListItem>
        <asp:ListItem Value="45">45</asp:ListItem>
        <asp:ListItem Value="50">50</asp:ListItem>
        <asp:ListItem Value="55">55</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="drpdayhalf" runat="server">
        <asp:ListItem Value="am">a.m.</asp:ListItem>
        <asp:ListItem Value="pm">p.m.</asp:ListItem>
    </asp:DropDownList>
    <br />
    On Days:<br />
    <asp:CheckBox ID="chkmon" runat="server" Text="Monday" />
    <br />
    <asp:CheckBox ID="chktue" runat="server" Text="Tuesday" />
    <br />
    <asp:CheckBox ID="chkwed" runat="server" Text="Wednesday" />
    <br />
    <asp:CheckBox ID="chkthu" runat="server" Text="Thursday" />
    <br />
    <asp:CheckBox ID="chkfri" runat="server" Text="Friday" />
    <br />
    <asp:CheckBox ID="chksat" runat="server" Text="Saturday" />
    <br />
    <asp:CheckBox ID="chksun" runat="server" Text="Sunday" />
    <br />
    <asp:HiddenField ID="hfstart" runat="server" />
    <asp:HiddenField ID="hfend" runat="server" />
    <br />
    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search Rides" />
    <br />
    &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        ForeColor="#333333" GridLines="None">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="RideID" HeaderText="Ride ID" />
            <asp:BoundField DataField="RecurMon" HeaderText="Monday" />
            <asp:BoundField DataField="RecurTue" HeaderText="Tuesday" />
            <asp:BoundField DataField="RecurWed" HeaderText="Wednesday" />
            <asp:BoundField DataField="RecurThu" HeaderText="Thursday" />
            <asp:BoundField DataField="RecurFri" HeaderText="Friday" />
            <asp:BoundField DataField="RecurSat" HeaderText="Saturday" />
            <asp:BoundField DataField="RecurSun" HeaderText="Sunday" />
            <asp:BoundField DataField="NumSeats" HeaderText="Seats" />
        </Columns>
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
</asp:Content>
