<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="CreateRide.aspx.cs" Inherits="GrabbaRide.Frontend.CreateRide" Title="Grabbaride: Create a new Ride" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">

    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;key=ABQIAAAAdzIHDEcQlKVK0ZsLXgw7AxT2yXp_ZAY8_ufC3CFXhHIE1NvwkxTe_yeQBDaUEW7-M67E9zLbOak5Xw"
        type="text/javascript"></script>

    <script type="text/javascript" src="GoogleMaps.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="gdiv" style="float: right;">
        <p>
            <input id="txtgeo" type="text" size="60" name="address" value="Palmerston North" />
            <input id="btngeocode" type="button" value="Find" onclick="var address = document.getElementById('txtgeo'); showAddress(address.value); return false" />
        </p>
        <div id="searchmap" style="width: 400px; height: 400px;">
        </div>
    </div>
    <br />
    <div id="otherinfo" style="float: left; width: 347px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering ="true">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
        </ContentTemplate>
        </asp:UpdatePanel>
        
        Create Ride:<br />
        <br />
        Start Date:<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Calendar ID="calstart" runat="server" BackColor="White" BorderColor="#999999"
                    CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                    ForeColor="Black" Height="16px" Width="16px">
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                </asp:Calendar>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        End Date:<asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Calendar ID="calEnd" runat="server" BackColor="White" BorderColor="#999999"
                    CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                    ForeColor="Black" Height="114px" Width="110px">
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                </asp:Calendar>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        Number of Seats Available:<br />
        <asp:DropDownList ID="drpSeats" runat="server">
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
            <asp:ListItem Value="13"></asp:ListItem>
            <asp:ListItem Value="14"></asp:ListItem>
            <asp:ListItem Value="15"></asp:ListItem>
            <asp:ListItem Value="16"></asp:ListItem>
            <asp:ListItem Value="17"></asp:ListItem>
            <asp:ListItem Value="18"></asp:ListItem>
            <asp:ListItem Value="19"></asp:ListItem>
            <asp:ListItem Value="20"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        On Days:<br />
        <asp:CheckBox ID="chkmon" runat="server" Text="Monday" />
        <br />
        <asp:CheckBox ID="chktue" runat="server" Text="Tuesday" />
        <br />
        <asp:CheckBox ID="chkwed" runat="server" Text="Wednesday" />
        <br />
        <asp:CheckBox ID="chkthurs" runat="server" Text="Thursday" />
        <br />
        <asp:CheckBox ID="chkfri" runat="server" Text="Friday" />
        <br />
        <asp:CheckBox ID="chksat" runat="server" Text="Saturday" />
        <br />
        <asp:CheckBox ID="chksun" runat="server" Text="Sunday" />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
        <br />
        <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create Ride" />
        <br />
        <asp:HiddenField ID="hfend" runat="server" />
        <asp:HiddenField ID="hfstart" runat="server" />
    </div>
</asp:Content>
