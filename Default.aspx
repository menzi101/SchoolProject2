<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Concert Booking</title>
    <style type="text/css">
        .style1
        {
            font-size: xx-large;
            font-weight: bold;
        }
    </style>
</head>
<body bgcolor="#00ccff">
    <form id="form1" runat="server">
    <p class="style1">
        Concert</p>
    <p>
        &nbsp;</p>
    <p>
        Tickets Remaining:
        <asp:Label ID="lblTickets" runat="server" style="font-weight: 700"></asp:Label>
    </p>
    <p>
        Food Choice:<br />
        <asp:RadioButtonList ID="radFood" runat="server">
            <asp:ListItem Selected="True">Beef</asp:ListItem>
            <asp:ListItem>Chicken</asp:ListItem>
            <asp:ListItem>Vegeterian</asp:ListItem>
        </asp:RadioButtonList>
    </p>
    <p>
        Seat:         <asp:TextBox ID="txtSeat" runat="server"></asp:TextBox>
    </p>
    <p>
        Name:
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnBook" runat="server" Height="45px" Text="Book" 
            Width="103px" onclick="btnBook_Click" />
    </p>
    <asp:Label ID="lblMessage" runat="server" ForeColor="#006600"></asp:Label>
    </form>
</body>
</html>
