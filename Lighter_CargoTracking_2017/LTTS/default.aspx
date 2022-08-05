<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="LTTS._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transport tracking systems [V.1.0]</title>
    <style type="text/css">

        .style8
        {
            height: 2px;
        }
        .style7
        {
            color: #FFFFFF;
        }
        .style9
        {
            text-align: center;
        }
        .style3
        {
            height: 33px;
            text-align: center;
        }
        .style2
        {
            text-align: center;
            height: 522px;
        }
        .style10
        {
            text-align: center;
            color: #0099FF;
            height: 23px;
            font-size: small;
        }
        .style11
        {
            color: #FFFFFF;
            font-size: xx-large;
        }
        .style12
        {
            height: 61px;
        }
        .style13
        {
            color: #FFFFCC;
        }
    </style>
</head>
<body bgcolor="#000000">
    <form id="form1" runat="server">
    
    
        <table style="width:100%;">
            <tr>
                <td style="text-align: center" class="style8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: center" class="style12">
                    <asp:Image ID="Image1" runat="server" CssClass="style7" Height="41px" 
                        ImageAlign="Middle" ImageUrl="~/Images/ums.jpg" Width="36px" />
&nbsp;<span class="style11"><strong>&nbsp; Transport tracking systems</strong></span></td>
            </tr>
            <tr>
                <td class="style9">
                    <span class="style13">User Nam</span><span class="style7">e: </span>
                    <asp:TextBox ID="txtuid" runat="server" style="margin-bottom: 0px" 
                        Width="127px"></asp:TextBox>
                &nbsp; <span class="style7">Password:&nbsp;</span> 
                    <asp:TextBox ID="txtpwd"  TextMode="Password" runat="server" style="margin-bottom: 0px" 
                        Width="116px"></asp:TextBox>
                &nbsp;
                    <asp:Button ID="btnlogin" runat="server" Text="Login" 
                        Width="83px" onclick="btnlogin_Click" />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="lblmsg" runat="server" 
                        style="color: #FFFF00; text-align: center"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Image ID="Image2" runat="server" Height="500px" ImageAlign="Middle" 
                        ImageUrl="~/Images/bg_login.jpg" style="text-align: center" 
                        Width="1021px" />
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <strong>Power by IT dept.</strong></td>
            </tr>
        </table>
    
    
    </form>
</body>
</html>
