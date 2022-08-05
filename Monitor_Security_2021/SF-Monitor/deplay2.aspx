<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deplay2.aspx.cs" Inherits="SF_Monitor.deplay2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript"
>
       var secs;
        var timerID = null;
        var timerRunning = false;
        var delay = 1000;

        function InitializeTimer(seconds) {
            // Set the length of the timer, in seconds
            secs = seconds;
            StopTheClock();
            StartTheTimer();
        }

        function StopTheClock() {
            if (timerRunning)
                clearTimeout(timerID);
            timerRunning = false;
        }

        function StartTheTimer() {
            if (secs == 0) {
                StopTheClock();
                // Here's where you put something useful that's
                // supposed to happen after the allotted time.
                // For example, you could display a message:
                window.location.href = window.location.href;
                //alert("Your page has been refreshed !!!!");
                //Response.redirect(Request.Url.AbsoluteUri);
               //Response.Redirect(Request.Url.AbsoluteUri);

            }
            else {
                //self.status = 'Remaining: ' + secs;
                document.getElementById("lbl_area1").innerText = secs + " ";
                secs = secs - 1;
                timerRunning = true;
                timerID = self.setTimeout("StartTheTimer()", delay);
               
            }
        }
</script>

    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: right;
        }
        .auto-style5 {
            text-align: center;
        }
        .auto-style6 {
            font-size: x-large;
            color: #FFFF66;
        }
        .auto-style8 {
            text-align: center;
            height: 355px;
        }
        .auto-style9 {
            font-size: 220pt;
            color: #FF66FF;
        }
        .auto-style11 {
            font-size: 220pt;
            color: #00FF00;
        }
        .auto-style12 {
            font-size: 80pt;
            color: #FFFFFF;
        }

         body {
         background-color:black;
        }

        .auto-style13 {
            font-size: 50pt;
            color: #FFFFFF;
        }

        .auto-style14 {
            text-align: center;
            height: 135px;
        }

    </style>
</head>
<body onload="InitializeTimer(30)" >
    <form id="form1" runat="server">
        <div>
             <asp:ScriptManager ID="ScriptManager4" runat="server" />  
        <asp:Timer ID="Timer1" runat="server" Interval="1000" Enabled="False" EnableViewState="False">
        </asp:Timer>

            <table class="auto-style1">
                <tr>
                    <td class="auto-style14">
                        <asp:Label ID="Label8" runat="server" CssClass="auto-style13"></asp:Label>
                        <%--<asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" EnableViewState="False">--%>                        <%--</asp:Timer>--%>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:Label ID="Label1" runat="server" CssClass="auto-style12" Text="Man IN"></asp:Label>
&nbsp;<strong><asp:Label ID="Label2" runat="server" CssClass="auto-style11" Text="175"></asp:Label>
                        </strong>&nbsp;<asp:Label ID="Label3" runat="server" CssClass="auto-style12" Text="Person"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label5" runat="server" CssClass="auto-style12" Text="Woman IN"></asp:Label>
                        <strong>
                        <asp:Label ID="Label6" runat="server" CssClass="auto-style9" Text="110"></asp:Label>
                        </strong>
                        <asp:Label ID="Label7" runat="server" CssClass="auto-style12" Text="Person"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label4" runat="server" CssClass="auto-style6" Text="Last up time:"></asp:Label>
                    &nbsp;<asp:Label ID="lbl_area1" runat="server" CssClass="auto-style6"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
