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
            font-size: small;
            font-weight: bold;
            color: #000066;
	font-family: Arial;
}
        #txtgeo
        {
            width: 345px;
        }
    .style5 {
	font-family: Arial;
}
.style6 {
	font-size: small;
}
.style7 {
	font-family: Arial;
	font-size: small;
}
.style9 {
	font-size: x-large;
	font-weight: bold;
	color: #000080;
	font-family: Arial;
}
.style10 {
	text-align: center;
	margin-left: 3px;
}
.style13 {
	font-family: Arial;
	font-size: small;
	color: #000000;
}
.style14 {
	margin-left: 32px;
}
.style15 {
	text-align: center;
}
.style16 {
	text-align: center;
	font-weight: normal;
	color: #000000;
}
.style17 {
	margin-left: 59px;
	margin-right: 0px;
	margin-top: 0px;
	margin-bottom: 0px;
}
.style18 {
	font-size: small;
	color: #000066;
	font-family: Arial;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="otherinfo" style="float: left; width: 865px; " class="style10">
        <div class="style15">
			<span class="style5"><span class="style6">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
        </asp:ScriptManager>
        	</span></span>
        <span class="style9">Create A Ride</span><br />
			<br />
			<br />
		</div>
		<table align="center" class="style14" style="width: 72%">
			<tr>
				<td style="height: 238px">
				<div class="style15">
					<span class="style13">1) Please select starting date:</span><span class="style2"></div>
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
                </td>
				<td class="style2" style="height: 238px">
				<div class="style16">
					2) Please select finishing date:</div>
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
                </td>
			</tr>
		</table>
		<div class="style15" style="width: 885px">
			<br />
        </span><span class="style13"><span class="style18">3) Please select 
			location:</span><span class="style2"><p class="style17" style="width: 413px">
            <input id="txtgeo" type="text" size="60" name="address" value="Palmerston North" class="style7" />
            <input id="btngeocode" type="button" value="Find" onclick="var address = document.getElementById('txtgeo'); showAddress(address.value); return false" class="style7" /><span class="style5"><span class="style6">
			</span></span>
        </span>
        </span></div>
		<span class="style2"><span class="style5">
            <div id="searchmap" style="width: 400px; height: 400px; margin-top: 30px;">
            </div>
    	</span><br />
        </span><span class="style5">
            <span class="style6">3) Please select number of seats available:&nbsp;<br />
		</span>
        </span>
        <span class="style1">
            <span class="style5"><span class="style6">
            <asp:DropDownList ID="drpSeats" runat="server" Height="43px" Width="32px">
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
		</span></span>
        </span>
        <br class="style7" />
        <span class="style5"><span class="style6">4) Please select starting 
		time:</span></span><br class="style7" />
        <span class="style5"><span class="style6">
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
            <asp:ListItem Value="00"></asp:ListItem>
            <asp:ListItem Value="05"></asp:ListItem>
            <asp:ListItem Value="10"></asp:ListItem>
            <asp:ListItem Value="15"></asp:ListItem>
            <asp:ListItem Value="20"></asp:ListItem>
            <asp:ListItem Value="25"></asp:ListItem>
            <asp:ListItem Value="30"></asp:ListItem>
            <asp:ListItem Value="35"></asp:ListItem>
            <asp:ListItem Value="40"></asp:ListItem>
            <asp:ListItem Value="45"></asp:ListItem>
            <asp:ListItem Value="50"></asp:ListItem>
            <asp:ListItem Value="55"></asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="drpdayhalf" runat="server">
            <asp:ListItem Value="a.m."></asp:ListItem>
            <asp:ListItem Value="p.m."></asp:ListItem>
        </asp:DropDownList>
        <br />
		<br />
		5) Please select the day(s):</span><br class="style6" />
        <span class="style6">
        <asp:CheckBox ID="chkmon" runat="server" Text="Monday" />
        </span>
        <br class="style6" />
        <span class="style6">
        <asp:CheckBox ID="chktue" runat="server" Text="Tuesday" />
        </span>
        <br class="style6" />
        <span class="style6">
        <asp:CheckBox ID="chkwed" runat="server" Text="Wednesday" />
        </span>
        <br class="style6" />
        <span class="style6">
        <asp:CheckBox ID="chkthurs" runat="server" Text="Thursday" />
        </span>
        <br class="style6" />
        <span class="style6">
        <asp:CheckBox ID="chkfri" runat="server" Text="Friday" />
        </span>
        <br class="style6" />
        <span class="style6">
        <asp:CheckBox ID="chksat" runat="server" Text="Saturday" />
        <br />
		<br />
        <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create Ride"
            Width="112px" />
        </span>
        <br class="style6" />
        <br class="style6" />
        <br class="style6" />
        <br class="style6" />
        <br class="style6" />
        <span class="style6">
        <asp:HiddenField ID="hfend" runat="server" />
        <asp:HiddenField ID="hfstart" runat="server" />
    	</span></span>
    </div>
	<span class="style5">
    <br class="style6" />
    </span>
</asp:Content>
