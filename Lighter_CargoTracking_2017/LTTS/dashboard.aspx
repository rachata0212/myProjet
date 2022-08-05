<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="LTTS.dashboard"   %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title>Transport tracking systems [V.1.0]</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
            color: #FFFFFF;
            height: 40px;
        }
        .style5
        {
            font-size: xx-small;
            text-align: right;
        }
        .style6
        {
            font-size: large;
            color: #FFFFFF;
            text-align: left;
        }
        .style13
        {
            height: 29px;
            text-align: center;
            color: #FFFFFF;
            font-size: xx-large;
        }
        .style15
        {
            height: 33px;
            text-align: center;
        }
        .style18
        {
            font-size: xx-small;
            text-align: left;
            width: 1037px;
        }
        .style19
        {
            height: 259px;
        }
        .style20
        {
            width: 1037px;
        }
        .style21
        {
            color: #FFFFFF;
            text-align: center;
        }
        .style23
        {
            width: 242px;
        }
        .style24
        {
            width: 394px;
        }
        .style25
        {
            color: #33CCFF;
            font-size: x-small;
        }
        .style26
        {
            color: #FFFFFF;
        }
        </style>
     
     

</head>
<body bgcolor="#000000" >
    <form id="form1" runat="server">
    <div>
       

        <table class="style1">
            <tr>
                <td class="style13" colspan="2">
                    

                    <strong style="text-align: center">&nbsp;Transport tracking systems </strong></td>
            </tr>
            <tr>
                <td class="style3" colspan="2">
                    

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <asp:Timer ID="tmrUpdate" runat="server" Interval="1000" ontick="tmrUpdate_Tick"> </asp:Timer> 
         <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick"></asp:Timer>                 
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="tmrUpdate" EventName="Tick" />   
        <asp:AsyncPostBackTrigger ControlID="timer1" EventName="Tick"/>
        </Triggers>              
                    
        <ContentTemplate>

            Up to date:<asp:Label ID="lbldate" runat="server"></asp:Label>&nbsp;time:
                <asp:Label ID="lblTimer1" runat="server"></asp:Label>
                &nbsp;<asp:Label ID="lblTimer2" runat="server" Text="Label" 
                style="font-size: large" Visible="False"></asp:Label>

            &nbsp;

        </ContentTemplate>
        </asp:UpdatePanel>        

                    </td>
                        </tr>
                <tr>
                <td class="style18">
                    v<span class="style6"> View order date:
                    </span>
                    <asp:DropDownList ID="ddl_dateplans" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddl_dateplans_SelectedIndexChanged" >

                    </asp:DropDownList>
&nbsp;
                    <asp:Button ID="btnrefresh" runat="server" onclick="btnrefresh_Click" 
                        Text="Refresh" />
                    </td>                
                      

                <td class="style5">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/bz01395.gif" />
                    R<span class="style6">Refresh every:
                    <asp:DropDownList ID="ddl_refresh" runat="server" 
                        onselectedindexchanged="ddl_refresh_SelectedIndexChanged" >
                        <asp:ListItem Value="20">20 S</asp:ListItem>
                        <asp:ListItem Value="10">10 S</asp:ListItem>
                        <asp:ListItem Value="15">15 S</asp:ListItem>
                        <asp:ListItem Value="30">30 S</asp:ListItem>
                        <asp:ListItem Value="45">45 S</asp:ListItem>
                        <asp:ListItem Value="60">1 M</asp:ListItem>
                        <asp:ListItem Value="180">3 M</asp:ListItem>
                        <asp:ListItem Value="300">5 M</asp:ListItem>
                        <asp:ListItem Value="600">10 M</asp:ListItem>

                    </asp:DropDownList>
                    </span>
                </td>


                 

            </tr>
            <tr>
            

                <td class="style19" colspan="2" >
                    <asp:GridView ID="dtgdashboard" AutoGenerateColumns="false" runat="server" 
                        onrowdatabound="dtgdashboard_RowDataBound" ForeColor="White" 
                        Visible="False">
                            
                    <Columns>
                    <asp:BoundField DataField="Order No_" HeaderText="Order No" ItemStyle-Width="50px" />
                    <asp:BoundField DataField="Customer Name" HeaderText="Customer Name"  ItemStyle-Width="50px" />
                    <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Width="80px" />
                    <asp:BoundField DataField="Confirm Truck No_" HeaderText="Confirm Truck No_" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="FG Comment" HeaderText="FG-Comment" ItemStyle-Width="50px" />
                    <asp:BoundField DataField="Truck Type" HeaderText="Truck Type" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center"  />
                    <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="50px" />
                    <asp:BoundField DataField="Weight Ticket No_" HeaderText="Weight Ticket No_" ItemStyle-Width="80px" />                     
                    <asp:BoundField DataField="Item No_" HeaderText="Item No" ItemStyle-Width="70px" />
                    </Columns>
                    </asp:GridView>                    
                    
                    <asp:GridView ID="dtgcreate_value" runat="server" ForeColor="White" 
                        onrowdatabound="GridView4_RowDataBound">
                    </asp:GridView> 

                </td>
            </tr>
            <tr>
                <td class="style15" colspan="2">
                    <span class="style26">:-: </span>
                    <asp:Label ID="lblitemscount" runat="server" style="color: #FFFFFF"></asp:Label>
                &nbsp;<span class="style26">:-:</span></td>
            </tr>
            <tr>
                <td class="style20">
                    <table class="style1">
                        <tr>
                            <td class="style24">
                    <asp:GridView ID="GridView2" runat="server" ForeColor="White" 
                                    onrowdatabound="GridView2_RowDataBound" >
                    </asp:GridView>
                            </td>
                            <td class="style23">
                    <asp:GridView ID="GridView3" runat="server" ForeColor="White" 
                                    onrowdatabound="GridView3_RowDataBound" style="margin-left: 0px" >
                    </asp:GridView>
                            </td>
                            <td>
                    <asp:GridView ID="GridView1" runat="server" ForeColor="White" Width="16px" 
                                    onrowdatabound="GridView1_RowDataBound" >
                    </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
               
            </tr>
        </table>

       
       
    
    </div>   
    </form>
    <p class="style25" style="text-align: center">
        <span class="style21">
        __________________________________________________________________________________________________________________________________________________________________________________________</span><strong><br />
        <br />
        <br />
        ------------------------<br />
        Power by IT UMS dept.</strong></p>
</body>
</html>
