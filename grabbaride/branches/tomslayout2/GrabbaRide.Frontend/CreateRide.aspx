<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="CreateRide.aspx.cs" Inherits="GrabbaRide.Frontend.CreateRide" Title="Grabbaride: Create a new Ride" %>

<asp:Content ID="Content1" ContentPlaceHolderID=HelpContentPlaceHolder runat="server">
          <img alt="" src="themes/blue/help.gif" />&nbsp;&nbsp;Select the approximate starting and ending points for your ride on the map.    
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContentPlaceHolder">
    <h3>
        Create A Ride</h3>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <table id="createridetable">
        <tr>
            <td>
                <img src="Images/1_off.gif" alt="1." />
            </td>
            <td>
                Please select your <strong>start</strong> and <strong>end locations</strong>:
            </td>
            <td>
                <div id="geodiv">
                    <input id="txtgeo" name="address" size="60" type="text" value="Palmerston North" /><br />
                    <input id="btnsetstart" type="button" value="Set Start" onclick="var address = document.getElementById('txtgeo'); setAddress(address.value, 'start'); return false" />
                    <input id="btnsetend" type="button" value="Set End" onclick="var address = document.getElementById('txtgeo'); setAddress(address.value, 'end'); return false" />
                    <div id="searchmap" style="width: 400px; height: 350px;">
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <img src="Images/2_off.gif" alt="2." />
            </td>
            <td>
                Please select <strong>number of seats</strong>
            </td>
            <td>
                <asp:DropDownList ID="drpSeats" runat="server">
                    <asp:ListItem Value="1" />
                    <asp:ListItem Value="2" />
                    <asp:ListItem Value="3" />
                    <asp:ListItem Value="4" />
                    <asp:ListItem Value="5" />
                    <asp:ListItem Value="6" />
                    <asp:ListItem Value="9" />
                    <asp:ListItem Value="12" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <img src="Images/3_off.gif" alt="4." />
            </td>
            <td>
                Please select the <strong>time</strong>
            </td>
            <td>
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
                    <asp:ListItem Value="a.m." />
                    <asp:ListItem Value="p.m." />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                and <strong>days of the week</strong>:
            </td>
            <td>
                <asp:CheckBox ID="chkmon" runat="server" Text="Monday" Font-Names="Arial" Checked="true" />
                <br />
                <asp:CheckBox ID="chktue" runat="server" Text="Tuesday" Font-Names="Arial" Checked="true" />
                <br />
                <asp:CheckBox ID="chkwed" runat="server" Text="Wednesday" Font-Names="Arial" Checked="true" />
                <br />
                <asp:CheckBox ID="chkthurs" runat="server" Text="Thursday" Font-Names="Arial" Checked="true" />
                <br />
                <asp:CheckBox ID="chkfri" runat="server" Text="Friday" Font-Names="Arial" Checked="true" />
                <br />
                <asp:CheckBox ID="chksat" runat="server" Text="Saturday" Font-Names="Arial" />
                <br />
                <asp:CheckBox ID="chksun" runat="server" Text="Sunday" Font-Names="Arial" />
            </td>
        </tr>
        <tr>
            <td>
                <img src="Images/4_off.gif" alt="4." />
            </td>
            <td>
                When should the listing to become available?
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="StartDateRadioList" runat="server" AutoPostBack="true" CellPadding="0"
                                        CellSpacing="0">
                                        <asp:ListItem Selected="True">Now</asp:ListItem>
                                        <asp:ListItem>Custom Date -&gt;</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:Calendar ID="calstart" runat="server" BackColor="White" BorderColor="Black"
                                        CaptionAlign="Right" DayNameFormat="Shortest" Font-Size="8pt" ForeColor="Black"
                                        NextPrevFormat="ShortMonth" TitleFormat="Month" Width="200px">
                                        <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                                        <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="8pt" ForeColor="#333333" />
                                        <TodayDayStyle BackColor="#CCCC99" />
                                        <OtherMonthDayStyle ForeColor="#999999" />
                                        <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333"
                                            Height="10pt" />
                                        <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White"
                                            Height="14pt" />
                                    </asp:Calendar>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                How long would you like to run the advertisment for?
            </td>
            <td>
                <asp:DropDownList ID="AdvLengthDropDown" runat="server">
                    <asp:ListItem Text="1 week" Value="7" />
                    <asp:ListItem Text="2 weeks" Value="14" />
                    <asp:ListItem Text="1 month" Value="30" Selected="True" />
                    <asp:ListItem Text="3 months" Value="90" />
                    <asp:ListItem Text="6 months" Value="180" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <img src="Images/5_off.gif" alt="5." />
            </td>
            <td>
                Please enter any <strong>extra information</strong> in the box 
                below, such as the ride cost and special conditions on the ride:</td>            
            
            <td>
                <asp:TextBox ID="txtDescription" runat="server" Rows="10" Width="400" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create Ride!"
                    Width="112px" Font-Bold="True" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hfend" runat="server" />
    <asp:HiddenField ID="hfstart" runat="server" />
</asp:Content>
