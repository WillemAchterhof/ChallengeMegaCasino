<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeMegaCasino.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Image ID="firstImage" runat="server" Height="150px" Width="150px" />
        	<asp:Image ID="secondImage" runat="server" Height="150px" Width="150px" />
        	<asp:Image ID="thirdImage" runat="server" Height="150px" Width="150px" />
            <br />
            <br />
            <p>
            Your bet: <asp:TextBox ID="placeBetTextBox" runat="server" />
            <br />
            <br />
            <asp:Button ID="okButton" runat="server" Text="Pull The Lever!" OnClick="OkButton_Click" />
            <br />
            <br />
            <asp:Label ID="resultLabel" runat="server" Text="" />
            <br />
            <br />
            <asp:Label ID="moneyLabel" runat="server" Text="" />
            <br />
            <br />
            1 Cherry   - X2 Your Bet<br />
            2 Cherries - X3 Your Bet<br />
            3 Cherries - X4 Your Bet<br />
            3 7's - Jackpot - X100 Your Bet<br />
            HOWEVER ... if there's even one BAR, you win nothing
            <br />
            <br />
	    You want to spend more money? How much: <asp:TextBox ID="spendMoreTextBox" runat="server" />
            &nbsp;<asp:Button ID="spendMoreButton" runat="server" Text="Spend More!" OnClick="SpendMoreButton_Click" />
            </p>

        </div>
    </form>
</body>
</html>
