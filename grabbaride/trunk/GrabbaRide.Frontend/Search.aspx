<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Search.aspx.cs" Inherits="GrabbaRide.Frontend.WebForm5" Title="GrabbaRide Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript"> 
    var startMkr = null;
    var endMkr = null;
    function SetStart(lat, lng)
    {
        var hfstart = document.getElementById("ctl00_ContentPlaceHolder1_hfstart");
        hfstart.value = lat + "," + lng;
        if (!startMkr) {
            startMkr = new GMarker(new GLatLng(lat, lng));
            map.addOverlay(startMkr);
        } else
            startMkr.setLatLng(new GLatLng(lat, lng));
        var Offset = 0.005;
       	var polygon = new GPolygon([
            new GLatLng(lat, lng - Offset),
            new GLatLng(lat + Offset, lng),
            new GLatLng(lat, lng + Offset),
            new GLatLng(lat - Offset, lng),
            new GLatLng(lat, lng - Offset)
		  ], "#f33f00", 5, 1, "#ff0000", 0.2);
	    map.addOverlay(polygon);
        
        //CallServer("setstart" + "," + lat + "," + lng, "");
        //return false;
    }
    
    function SetEnd(lat, lng)
    {
        var hfend = document.getElementById("ctl00_ContentPlaceHolder1_hfend");
        hfend.value = lat + "," + lng;
        if (!endMkr) {
            endMkr = new GMarker(new GLatLng(lat, lng));
            map.addOverlay(endMkr);
        } else
            endMkr.setLatLng(new GLatLng(lat, lng));
        var Offset = 0.005;
       	var polygon = new GPolygon([
            new GLatLng(lat, lng - Offset),
            new GLatLng(lat + Offset, lng),
            new GLatLng(lat, lng + Offset),
            new GLatLng(lat - Offset, lng),
            new GLatLng(lat, lng - Offset)
		  ], "#f33f00", 5, 1, "#ff0000", 0.2);
		map.addOverlay(polygon);

        
        //CallServer("setend" + "," + lat + "," + lng, "");
        //return false;
    }
    
    function MapHandler(overlay, latlng) {     
        if (latlng) { 
            var myHtml = "<a onclick='SetStart(" + latlng.lat() + ", " + latlng.lng() + ");'>Set Start</a><br><a onclick='SetEnd(" + latlng.lat() + ", " + latlng.lng() + ");'>Set End</a>";
            map.openInfoWindow(latlng, myHtml);
        }
    }
    
    function ReceiveServerData(response) {
        var args = new Array();
        args = response.split(",");
        if (args[0] == "setstart") {
            if (!startMkr) {
                startMkr = new GMarker(new GLatLng(args[1], args[2]));
                map.addOverlay(startMkr);
            } else
                startMkr.setLatLng(new GLatLng(args[1], args[2]));
        } else if (args[0] == "setend") {
            if (!endMkr) {
                endMkr = new GMarker(new GLatLng(args[1], args[2]));
                map.addOverlay(endMkr);
            } else
                endMkr.setLatLng(new GLatLng(args[1], args[2]));
        }
        return true;
    }
    
    //code pinched from http://code.google.com/apis/maps/documentation/examples/geocoding-simple.html
    function showAddress(address) {
      if (geocoder) {
        geocoder.getLatLng(
          address,
          function(point) {
            if (!point) {
              alert(address + " not found");
            } else {
              map.setCenter(point, 13);
              var marker = new GMarker(point);
              map.addOverlay(marker);
              marker.openInfoWindowHtml(address);
            }
          }
        );
      }
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <div id="gdiv" style="float: right;">
      <p>
        <input id="txtgeo" type="text" size="60" name="address" value="Palmerston North" />
        <input id="btngeocode" type="button" value="Find" onclick="var address = document.getElementById('txtgeo'); showAddress(address.value); return false" />
      </p>
    <div id="searchmap" style="width: 400px; height: 400px;">
    </div>
    </div>
    <br />
    Date:<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Calendar ID="calDate" runat="server"></asp:Calendar>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField id="hfstart" runat="server"/>
    <asp:HiddenField id="hfend" runat="server"/>
    <br />
            <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" 
        Text="Search Rides" />
    <br />
&nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="GrabbaRideDataSource" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:CheckBoxField DataField="RecurMon" HeaderText="RecurMon" ReadOnly="True" 
                SortExpression="RecurMon" />
            <asp:CheckBoxField DataField="RecurTue" HeaderText="RecurTue" ReadOnly="True" 
                SortExpression="RecurTue" />
            <asp:CheckBoxField DataField="RecurWed" HeaderText="RecurWed" ReadOnly="True" 
                SortExpression="RecurWed" />
            <asp:CheckBoxField DataField="RecurThu" HeaderText="RecurThu" ReadOnly="True" 
                SortExpression="RecurThu" />
            <asp:CheckBoxField DataField="RecurFri" HeaderText="RecurFri" ReadOnly="True" 
                SortExpression="RecurFri" />
            <asp:BoundField DataField="NumSeats" HeaderText="NumSeats" ReadOnly="True" 
                SortExpression="NumSeats" />
            <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True" 
                SortExpression="UserID" />
            <asp:BoundField DataField="RideID" HeaderText="RideID" ReadOnly="True" 
                SortExpression="RideID" />
            <asp:BoundField DataField="LocationFromLat" HeaderText="LocationFromLat" 
                ReadOnly="True" SortExpression="LocationFromLat" />
            <asp:BoundField DataField="LocationFromLong" HeaderText="LocationFromLong" 
                ReadOnly="True" SortExpression="LocationFromLong" />
            <asp:BoundField DataField="LocationToLat" HeaderText="LocationToLat" 
                ReadOnly="True" SortExpression="LocationToLat" />
            <asp:BoundField DataField="LocationToLong" HeaderText="LocationToLong" 
                ReadOnly="True" SortExpression="LocationToLong" />
            <asp:BoundField DataField="StartDate" HeaderText="StartDate" ReadOnly="True" 
                SortExpression="StartDate" />
            <asp:BoundField DataField="EndDate" HeaderText="EndDate" ReadOnly="True" 
                SortExpression="EndDate" />
        </Columns>
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:LinqDataSource ID="GrabbaRideDataSource" runat="server" 
        ContextTypeName="GrabbaRide.Database.GrabbaRideDBDataContext" 
        TableName="Rides" 
        Select="new (RecurMon, RecurTue, RecurWed, RecurThu, RecurFri, NumSeats, UserID, RideID, LocationFromLat, LocationFromLong, LocationToLat, LocationToLong, StartDate, EndDate)">
    </asp:LinqDataSource>
    </asp:Content>
