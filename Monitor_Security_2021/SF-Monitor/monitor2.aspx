<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="monitor2.aspx.cs" Inherits="SF_Monitor.monitor2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

     <script type="text/javascript" language="JavaScript">

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
                document.getElementById("lbltime").innerText = secs + " ";
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
            text-align: center;
        }
        .auto-style3 {
            font-size: x-large;
        }
        .auto-style6 {
            width: 479px;
        }
        .auto-style4 {
            text-align: right;
        }
        .auto-style5 {
            color: #FF0000;
            font-weight: bold;
            text-decoration: underline;
        }
        .auto-style7 {
            color: #FF0000;
            font-size: large;
        }
        .auto-style8 {
            text-align: center;
            font-size: small;
        }
        </style>
</head>
<body onload="InitializeTimer(30)" horizontal-align: middle; style="width: 1274px" >
    <form id="form2" runat="server">
         <asp:ScriptManager ID="ScriptManager2" runat="server" />  
        <asp:Timer ID="Timer2" runat="server" Interval="1000" Enabled="False" EnableViewState="False">
        </asp:Timer>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2"><span class="auto-style3"><strong>ระบบตรวจสอบ ติดตาม เฝ้าระวัง จำนวนผู้ปฏิบัติการในพื้นที่ป้อม
                    </strong></span><strong>
                    <asp:Label ID="lbl_area1" runat="server" CssClass="auto-style3"></asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td>
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style6">
                                <asp:Label ID="lbl_total0" runat="server" Text="ป้อม"></asp:Label>
                            &nbsp;<strong><asp:Label ID="lbl_area2" runat="server" CssClass="auto-style7"></asp:Label>
                                </strong>&nbsp;<asp:Label ID="lbl_total" runat="server" Text="จำนวน"></asp:Label>
                            </td>
                            <td class="auto-style4">
                                <div class="auto-style4">
                                <asp:Label ID="lbl_1" runat="server" Text="ประจำวัน:"></asp:Label>
                                <asp:Label ID="lbl_date" runat="server"></asp:Label>
                            &nbsp;<asp:Label ID="lbl_time" runat="server"></asp:Label>
                                    <strong>&nbsp;<asp:Button ID="btn_select" runat="server" CssClass="auto-style5" OnClick="btn_select_Click" Text="v" Width="31px" />
                                    </strong>
                                </div>
                                <asp:Calendar ID="calendar" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" OnSelectionChanged="calendar_SelectionChanged" Visible="False" Width="330px">
                                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                                    <DayStyle BackColor="#CCCCCC" />
                                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                    <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                                    <TodayDayStyle BackColor="#999999" ForeColor="White" />
                                </asp:Calendar>

                                  <div>
        <font>This page will be refreshed after
            <asp:Label ID="lbltime" runat="server" Style="font-weight: bold;"></asp:Label>seconds</font>
        </div>


                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gv_test0" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" Visible="False">

  <Columns>                                                             
                                  <asp:BoundField DataField="PersonCardID" HeaderText="รหัส" ItemStyle-HorizontalAlign="Center"  > <HeaderStyle Width="80px"></HeaderStyle>
                                </asp:BoundField>

        <asp:BoundField DataField="Date" HeaderText="วันที่" ItemStyle-HorizontalAlign="Center"  > <HeaderStyle Width="80px"></HeaderStyle>
                                </asp:BoundField>


                               <%-- <asp:BoundField DataField="Name" HeaderText="ชื่อผู้ติดต่อ" ><HeaderStyle Width="200px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Department" HeaderText="แผนก/หน่วยงาน" ><HeaderStyle Width="200px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Group_" HeaderText="ประเภทผู้ติดต่อ" ><HeaderStyle Width="250px"></HeaderStyle>
                                </asp:BoundField>--%>
                                
                             
                            </Columns>


                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />


                    </asp:GridView>
                    <asp:GridView ID="gv_test" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" Visible="False">

  <Columns>
                                                             
                                  <asp:BoundField DataField="PersonCardID" HeaderText="รหัส" ItemStyle-HorizontalAlign="Center"  > <HeaderStyle Width="80px"></HeaderStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="TimeIn" HeaderText="ขาเข้า" ><HeaderStyle Width="200px"></HeaderStyle>
                                </asp:BoundField>                                
                                <asp:BoundField DataField="TimeOuts" HeaderText="ขาออก" ><HeaderStyle Width="250px"></HeaderStyle>
                                </asp:BoundField>
                              
                             
                            </Columns>


                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />


                    </asp:GridView>
                    <asp:GridView ID="gv_result" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">

                        <AlternatingRowStyle BackColor="White" />

  <Columns>
                                                             
                                  <asp:BoundField DataField="NO" HeaderText="ลำดับ" ItemStyle-HorizontalAlign="Center"  > <HeaderStyle Width="80px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="PersonCardID" HeaderText="รหัสบัตร" ItemStyle-HorizontalAlign="Center" ><HeaderStyle Width="150px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>                                
                                <asp:BoundField DataField="Name" HeaderText="ชื่อ" ><HeaderStyle Width="250px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="SurName" HeaderText="นามสกุล" ><HeaderStyle Width="250px"></HeaderStyle>
                                </asp:BoundField>
       <asp:BoundField DataField="Department" HeaderText="ฝ่าย" ><HeaderStyle Width="450px"></HeaderStyle>
                                </asp:BoundField>
       <asp:BoundField DataField="Groups" HeaderText="แผนก" ><HeaderStyle Width="250px"></HeaderStyle>
                                </asp:BoundField>
       <asp:BoundField DataField="Positions" HeaderText="ประเภท" ItemStyle-HorizontalAlign="Center" ><HeaderStyle Width="250px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
       <asp:BoundField DataField="Unit" HeaderText="จำนวน"  ItemStyle-HorizontalAlign="Center"> <HeaderStyle Width="100px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
       <asp:BoundField DataField="TimeIn" HeaderText="เวลาเข้า"  ItemStyle-HorizontalAlign="Center"> <HeaderStyle Width="200px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
       <asp:BoundField DataField="UseTime" HeaderText="ใช้เวลาติดต่อ" ItemStyle-HorizontalAlign="Center" ><HeaderStyle Width="200px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                              
                             
                            </Columns>


                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />


                    </asp:GridView>
                </td>
            </tr>
        </table>
        <div class="auto-style8">
            <br />
            Version 2.05 @ IT Sapthip Dept</div>
    </form>
    <%-- <asp:BoundField DataField="Name" HeaderText="ชื่อผู้ติดต่อ" ><HeaderStyle Width="200px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Department" HeaderText="แผนก/หน่วยงาน" ><HeaderStyle Width="200px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Group_" HeaderText="ประเภทผู้ติดต่อ" ><HeaderStyle Width="250px"></HeaderStyle>
                                </asp:BoundField>--%>
</body>
</html>
