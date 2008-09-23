<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="CreateRide.aspx.cs" Inherits="GrabbaRide.Frontend.CreateRide" Title="Grabbaride: Create a new Ride" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">

    <style type="text/css">
        .style1
        {
            font-family: Cambria;
        }
        .style2
        {
            font-size: xx-large;
            font-weight: bold;
            color: #000066;
        }
        .style3
        {
            color: #000000;
        }
        .style4
        {
            font-family: Cambria;
            font-size: medium;
        }
        #txtgeo
        {
            width: 345px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="gdiv" style="float: right; margin-top: 128px;">
        <p>
            <input id="txtgeo" type="text" size="60" name="address" value="Palmerston North" />
            <input id="btngeocode" type="button" value="Find" onclick="var address = document.getElementById('txtgeo'); showAddress(address.value); return false" />
            <div id="searchmap" style="width: 400px; height: 400px; margin-top: 30px;">
            </div>
    </div>
    <br />
    <div id="otherinfo" style="float: left; width: 275px; margin-left: 18px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
        </asp:ScriptManager>
        <span class="style2">Create A Ride<br />
            <br />
        </span><span class="style3"><span class="style4">1) Please select <b>start date</b>
            (the date that the ride will appear on the website):</span></span><asp:UpdatePanel
                ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Calendar ID="calstart" runat="server" BackColor="White" BorderColor="Black"
                        DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black"
                        Height="220px" Width="270px" NextPrevFormat="FullMonth" TitleFormat="Month">
                        <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
                            ForeColor="#333333" Width="1%" />
                        <TodayDayStyle BackColor="#CCCC99" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <DayStyle Width="14%" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333"
                            Height="10pt" />
                        <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White"
                            Height="14pt" />
                    </asp:Calendar>
                </ContentTemplate>
            </asp:UpdatePanel>
        <br />
        <span class="style1">2) Please select <b>end date</b> (the date the ride will be taken
            off the website):</span><asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Calendar ID="calEnd" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest"
                        Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px"
                        Width="271px" NextPrevFormat="FullMonth" TitleFormat="Month">
                        <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt"
                            ForeColor="#333333" Width="1%" />
                        <TodayDayStyle BackColor="#CCCC99" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <DayStyle Width="14%" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333"
                            Height="10pt" />
                        <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White"
                            Height="14pt" />
                    </asp:Calendar>
                </ContentTemplate>
            </asp:UpdatePanel>
        <span class="style1">
            <br />
            3) Please specific the total <b>number of seats</b> available:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="drpSeats" runat="server" Height="43px">
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
        </span>
        <br />
        <span class="style1">4) Please select the <b>day(s)</b> the ride is available for:</span><br />
    <asp:DropDownList ID="drphours" runat="server">
        <asp:ListItem Value="1" />
        <asp:ListItem Value="2" />
        <asp:ListItem Value="3" />
        <asp:ListItem Value="4" />
        <asp:ListItem Value="5" />
        <asp:ListItem Value="6" />
        <asp:ListItem Value="7" />
        <asp:ListItem Value="8" />
        <asp:ListItem Value="9" Selected="True" />
        <asp:ListItem Value="10" />
        <asp:ListItem Value="11" />
        <asp:ListItem Value="12" />
    </asp:DropDownList>
    <asp:DropDownList ID="drpmins" runat="server">
        <asp:ListItem Value="00" />
        <asp:ListItem Value="05" />
        <asp:ListItem Value="10" />
        <asp:ListItem Value="15" />
        <asp:ListItem Value="20" />
        <asp:ListItem Value="25" />
        <asp:ListItem Value="30" />
        <asp:ListItem Value="35" />
        <asp:ListItem Value="40" />
        <asp:ListItem Value="45" />
        <asp:ListItem Value="50" />
        <asp:ListItem Value="55" />
    </asp:DropDownList>
    <asp:DropDownList ID="drpdayhalf" runat="server">
        <asp:ListItem Value="am" Text="a.m." />
        <asp:ListItem Value="pm" Text="p.m." />
    </asp:DropDownList>
        <br />
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
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create Ride"
            Width="112px" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:HiddenField ID="hfend" runat="server" />
        <asp:HiddenField ID="hfstart" runat="server" />
    </div>
</asp:Content>
