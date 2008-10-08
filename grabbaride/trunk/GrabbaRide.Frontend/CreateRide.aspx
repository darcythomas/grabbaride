<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="CreateRide.aspx.cs" Inherits="GrabbaRide.Frontend.CreateRide" Title="Grabbaride: Create a new Ride" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">

    <style type="text/css">
        #txtgeo
        {
            width: 400px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="MainContentPlaceHolder">
	    <strong>Create A Ride<br />
			</strong><br />
			1) Please select <strong>start</strong> date:
	<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
	</asp:ScriptManager>
       <asp:UpdatePanel 
        ID="UpdatePanel1" runat="server" RenderMode="Inline">
        <ContentTemplate>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
					2) Please select <b>end </b> date:
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
			<br />
				3) Please select <strong>number</strong> of seats
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
				4) Please select <strong>time</strong> and <b>day(s)</b>:<br />
				<br />
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
    <asp:CheckBox ID="chkmon" runat="server" Text="Monday" Font-Names="Arial" />
    <br />
    <asp:CheckBox ID="chktue" runat="server" Text="Tuesday" Font-Names="Arial" />
    <br />
    <asp:CheckBox ID="chkwed" runat="server" Text="Wednesday" Font-Names="Arial" />
    <br />
    <asp:CheckBox ID="chkthurs" runat="server" Text="Thursday" Font-Names="Arial" />
    <br />
    <asp:CheckBox ID="chkfri" runat="server" Text="Friday" Font-Names="Arial" />
    <br />
    <asp:CheckBox ID="chksat" runat="server" Text="Saturday" Font-Names="Arial" />
    <br />
    <asp:CheckBox ID="chksun" runat="server" Text="Sunday" Font-Names="Arial" />
        <br />
    <br />
				5) Please select <strong>destination</strong>:
    <div id="geodiv">
            <input id="txtgeo" name="address" size="60" type="text" 
                value="Palmerston North"/><br />
            <input id="btnsetstart" type="button" value="Set Start" onclick="var address = document.getElementById('txtgeo'); setAddress(address.value, 'start'); return false" />
            <input id="btnsetend" type="button" value="Set End" onclick="var address = document.getElementById('txtgeo'); setAddress(address.value, 'end'); return false" />
        <div id="searchmap" style="width: 400px; height: 350px;">
        </div>
    </div>
				<br />
        Please enter any <b>extra information</b> in the box below, such as the ride cost and 
        special conditions on the ride:<br />
        <asp:TextBox ID="txtDescription" runat="server" Height="300px" Width="650px"></asp:TextBox>
        <br />
        <br />
    <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" 
        Text="Create Ride!" Width="112px" Font-Bold="True" />
    <asp:HiddenField ID="hfend" runat="server" />
    <asp:HiddenField ID="hfstart" runat="server" />
</asp:Content>

