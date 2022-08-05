<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="GoogleMap.Map" %>

<%--A sample project by Ghaffar khan--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Your Data on Google Map </title>
    <%--Google API reference--%>
    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=false
                 &amp;key=abcdefg" type="text/javascript">
    </script>
</head>

<body onload="initialize()" onunload="GUnload()">
    <form id="form1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
                <%--Place holder to fill with javascript by server side code--%>
                <asp:Literal ID="js" runat="server"></asp:Literal>
                <%--Place for google to show your MAP--%>
                <div ID="map_canvas" style="width: 100%; height: 728px; margin-bottom:                      2px;">
                </div>
                <br />
            </asp:Panel>
        <br />
   </form>
   </body>

</html>

