<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="CreateRide.aspx.cs" Inherits="GrabbaRide.Frontend.CreateRide" Title="Grabbaride: Create a new Ride" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">

    <style type="text/css">
        #txtgeo
        {
            width: 345px;
        }
        #txtgeo0
        {
            width: 345px;
        }
        .style2
        {
	font-size: xx-large;
	font-weight: bold;
	color: #000066;
	float: none;
            text-align: left;
        }
        .style3
        {
            color: #000000;
        }
        .style5 {
		font-size: small;
	}
        .style6 {
	font-family: Arial;
}
.style7 {
	font-weight: bold;
}
.style8 {
	font-family: Arial;
	font-size: small;
}
.style9 {
	font-size: small;
	font-weight: bold;
	color: #000066;
}
.style10 {
	font-size: xx-large;
	font-weight: bold;
}
.style11 {
	font-size: small;
	font-weight: bold;
}
.style13 {
	font-size: small;
	font-weight: bold;
	color: #000000;
}
.style14 {
	font-size: xx-large;
	font-weight: bold;
	color: #000000;
}
.style15 {
	font-size: small;
	color: #000000;
}
.style16 {
	font-size: xx-large;
	color: #000080;
}
.style17 {
	text-align: center;
	float: none;
}
.style18 {
	font-size: small;
	font-weight: normal;
}
.style19 {
	font-size: xx-large;
	color: #000000;
}
.style20 {
	color: #000066;
	font-family: Arial;
}
.style21 {
	font-size: small;
	color: #000066;
}
.style22 {
	font-size: xx-large;
}
.style27 {
	text-align: left;
	float: none;
}
.style29 {
	font-family: Arial;
	font-size: small;
	text-align: left;
}
.style30 {
	text-align: left;
}
        .style25 {
	font-weight: normal;
}
.style24 {
	color: #008000;
	font-weight: normal;
}
.style31 {
	text-align: left;
	font-family: Arial;
}
        </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="MainContentPlaceHolder">
	    <div class="style17">
	    <div class="style27">
			<span class="style6"><span class="style16"><strong>Create A Ride<br />
			</strong></span><br class="style15" />
    		<span class="style5"><span class="style3">
    </span>
			1) Please select <strong>start</strong> date:</span></div>
    		</span>
	<span class="style2">
	<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
	</asp:ScriptManager>
    		<div class="style27">
	</span><span class="style6">
	<span class="style2">
       <asp:UpdatePanel 
        ID="UpdatePanel1" runat="server" RenderMode="Inline">
        <ContentTemplate>
            <span class="style6"><span class="style6">
	<span class="style2">
				<div class="style30">
				<asp:calendar ID="calstart" runat="server" BackColor="White" BorderColor="Black" CaptionAlign="Left" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px">
					<SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
					<SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
					<TodayDayStyle BackColor="#CCCC99" />
					<OtherMonthDayStyle ForeColor="#999999" />
					<DayStyle Width="14%" />
					<NextPrevStyle Font-Size="8pt" ForeColor="White" />
					<DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
					<TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
				</asp:calendar>
	</span></span></span></div>
        </ContentTemplate>
    </asp:UpdatePanel>
    			<div class="style30">
	</span>
	<span class="style7">
    <br class="style15" />
	</span>
	<span class="style14">
	<span class="style18">
					2) Please select <b>end </b> date</span></span><span class="style19"><span class="style5">:</span></span></span><span class="style2"><span class="style9">
				</div>
			</div>
			<div class="style27">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
        <ContentTemplate>
            <asp:Calendar ID="calEnd" runat="server" BackColor="White" BorderColor="Black" 
                DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" 
                ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" 
                Width="400px">
                <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                <TodayDayStyle BackColor="#CCCC99" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <DayStyle Width="14%" />
                <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" 
                    ForeColor="#333333" Height="10pt" />
                <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" 
                    ForeColor="White" Height="14pt" />
            </asp:Calendar>
        </ContentTemplate>
    </asp:UpdatePanel>
    		</div>
			<br />
	</span>
	</span>
			</span>
	<span class="style5">
	<span class="style6">
			<div class="style27">
				3) Please select <strong>number</strong> of seats</span></span><span class="style21"><span class="style20">:</div>
			<div class="style30">
	</span>
	</span><span class="style6">
    			<span class="style2">
				<span class="style9">
    <asp:DropDownList ID="drpSeats" runat="server" Height="20px">
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
	</span>
	</span>
    </span>
	<span class="style10">
	<span class="style13">
	<span class="style11">
    <br class="style6" />
	</span>
	</span>
	</span>
    <span class="style6">
	<span class="style22">
	<span class="style15">
	<span class="style5">
				4) Please select <strong>time</strong> and <b>day(s)</b>:</span></span></span><span class="style10"><span class="style13"><span class="style11"><br />
				<br />
	</span>
	</span>
	</span>
	<span class="style2">
	<span class="style9">
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
	</span>
				<br />
	<span class="style11">
					<span class="style3">
	<span class="style7">
				<span class="style25">
    <asp:CheckBox ID="chkmon" runat="server" Text="Monday" Font-Names="Arial" />
    				</span>
	</span>
	<span class="style10">
	<span class="style5">
	<span class="style25">
    <br />
	</span>
	</span>
	</span>
	<span class="style7">
				<span class="style25">
    <asp:CheckBox ID="chktue" runat="server" Text="Tuesday" Font-Names="Arial" />
    				</span>
	</span>
	<span class="style10">
	<span class="style5">
	<span class="style25">
    <br />
	</span>
	</span>
	</span>
	<span class="style7">
				<span class="style25">
    <asp:CheckBox ID="chkwed" runat="server" Text="Wednesday" Font-Names="Arial" />
    				</span>
	</span>
	<span class="style10">
	<span class="style5">
	<span class="style25">
    <br />
	</span>
	</span>
	</span>
				</span>
	<span class="style7">
				<span class="style24">
    <asp:CheckBox ID="chkthurs" runat="server" Text="Thursday" CssClass="style3" Font-Names="Arial" />
    				</span>
	</span>
				<span class="style3">
	<span class="style10">
	<span class="style5">
	<span class="style25">
    <br />
	</span>
	</span>
	</span>
	<span class="style7">
				<span class="style25">
    <asp:CheckBox ID="chkfri" runat="server" Text="Friday" Font-Names="Arial" />
    				</span>
	</span>
	<span class="style10">
	<span class="style5">
	<span class="style25">
    <br />
	</span>
	</span>
	</span>
	<span class="style7">
				<span class="style25">
    <asp:CheckBox ID="chksat" runat="server" Text="Saturday" Font-Names="Arial" />
    				</span>
	</span>
	<span class="style10">
	<span class="style5">
	<span class="style25">
    <br />
	</span>
	</span>
	<span class="style7">
				<span class="style25">
    <asp:CheckBox ID="chksun" runat="server" Text="Sunday" CssClass="style5" Font-Names="Arial" />
   
            
    				</span>
	</span>
	</span>
				</span>
	</span>
	</span><br />
				</span></div>
			<div class="style29">
				5) Please select <strong>destination</strong>:</div>
			<span class="style2">
   
            
    <div id="gdiv" class="style27">
            <input id="txtgeo" name="address" size="60" type="text" 
                value="Palmerston North"/><br />
            <input id="btnsetstart" type="button" value="Set Start" onclick="var address = document.getElementById('txtgeo'); setAddress(address.value, 'start'); return false" />
            <input id="btnsetend" type="button" value="Set End" onclick="var address = document.getElementById('txtgeo'); setAddress(address.value, 'end'); return false" />
        <div id="searchmap" style="width: 394px; height: 340px; margin-top: 30px; float: none;" class="style17">
        </div>
    </div>
    
    		<div class="style31">
				<br />
    <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" 
        Text="Create Ride!" Width="112px" Font-Bold="True" />
    <asp:HiddenField ID="hfend" runat="server" />
    <asp:HiddenField ID="hfstart" runat="server" />
				</span></span></div>
		</div>
</asp:Content>

