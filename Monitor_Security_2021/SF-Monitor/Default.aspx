<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SF_Monitor.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 51px;
            width: 539px;
        }
        .auto-style7 {
            text-align: center;
            width: 552px;
        }
        .auto-style8 {
            height: 51px;
            text-align: center;
            width: 552px;
        }
        .auto-style9 {
            color: #00FF00;
        }
        .auto-style10 {
            font-size: xx-large;
        }
        .auto-style11 {
            text-align: center;
            height: 66px;
            color: #FFFFFF;
            font-size: xx-large;
        }
        .auto-style12 {
            color: #FFFFFF;
            font-size: xx-large;
            text-align: center;
            height: 70px;
        }
        .auto-style21 {
            width: 539px;
        }
        .auto-style22 {
            text-align: center;
            width: 539px;
            height: 260px;
        }
        .auto-style24 {
            width: 591px;
        }
        .auto-style25 {
            height: 51px;
            text-align: center;
            width: 591px;
        }
        .auto-style26 {
            text-align: center;
            width: 591px;
            height: 260px;
        }
        .auto-style27 {
            text-align: center;
            width: 552px;
            height: 260px;
        }
        .auto-style28 {
            color: #FFFF00;
        }
        .auto-style29 {
            color: #FF0066;
        }
        .auto-style30 {
            width: 591px;
            text-align: center;
            color: #FFFF00;
        }
    </style>
</head>
<body 
    style="background-image:url('images/bg2.jpg');"
    background-repeat:no-repeat;
    background-attachment:fixed;

     background-image:url('images/bg.jpg');
    background-repeat:no-repeat;
    background-attachment:fixed;

    >


    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style8"></td>
                    <td class="auto-style25">
                        <br />
                        <br />
                        <asp:Image ID="Image1" runat="server" Height="146px" ImageUrl="~/images/logo_sap.jpg" Width="311px" />
                    </td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td class="auto-style11" colspan="3">
                        <strong>Surveillance Agency Systems</strong></td>
                </tr>
                <tr>
                    <td class="auto-style12" colspan="3">
                    </td>
                </tr>
                <tr>
                    <td class="auto-style27" ><strong>
                        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="auto-style9" Height="149px" ImageUrl="~/images/user_monitor.png" Width="168px" OnClick="ImageButton1_Click" BorderColor="#FF3300" BorderStyle="Solid" BorderWidth="2px" />
                        <br />
                        <span class="auto-style9"><span class="auto-style10">Monitor 1</span></span></strong></td>
                    <td class="auto-style26"><strong>
                        <asp:ImageButton ID="ImageButton2" runat="server" CssClass="auto-style9" Height="149px" ImageUrl="~/images/user_monitor.png" Width="168px" OnClick="ImageButton2_Click" BorderColor="#FF3300" BorderStyle="Solid" BorderWidth="2px" />
                        <br />
                        <span class="auto-style28"><span class="auto-style10">Monitor 2</span></span></strong></td>
                    <td class="auto-style22"><strong>
                        <asp:ImageButton ID="ImageButton3" runat="server" CssClass="auto-style9" Height="149px" ImageUrl="~/images/user_monitor.png" Width="168px" OnClick="ImageButton3_Click" BorderColor="#FF3300" BorderStyle="Solid" BorderWidth="2px" />
                        <br />
                        <span class="auto-style29"><span class="auto-style10">Monitor 3</span></span></strong></td>
                </tr>
                <tr>
                    <td class="auto-style7"><strong>
                        <span class="auto-style9">&nbsp; </span></strong></td>
                    <td class="auto-style24">&nbsp;</td>
                    <td class="auto-style21">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7"><strong>
                        <span class="auto-style9">&nbsp; </span></strong></td>
                    <td class="auto-style30">Version 2.05 @ IT Sapthip Dept</td>
                    <td class="auto-style21">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
