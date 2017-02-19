<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalculatorForm.aspx.cs" Inherits="CalculatorClient.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Example communication with service</title>
    <link href="css/style.css" rel="stylesheet" />
</head>
<body>
    <h1>Example communication with SOAP service</h1>

    <form id="calculatorForm" runat="server">
        <table id="calculator" border="2">
            <tr>
                <td>
                    <asp:Label ID="LabelFirstNumber" runat="server" Text="First Number"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextFirstNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelSecondNumber" runat="server" Text="Second Number"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextSecondNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="LabelResult" runat="server" Text="Result Number"></asp:Label>
                </td>

            </tr>
            <tr>
                <td id="arithmeticButtons" colspan="2">
                    <asp:Button ID="ButtonAdd" runat="server" Text="+" OnClick="ButtonAdd_Click" />
                    <asp:Button ID="ButtonSub" runat="server" Text="-" OnClick="ButtonSub_Click" />
                    <asp:Button ID="ButtonMul" runat="server" Text="*" OnClick="ButtonMul_Click" />
                    <asp:Button ID="ButtonDiv" runat="server" Text="/" OnClick="ButtonDiv_Click" />
                </td>
            </tr>
        </table>

        <asp:GridView ID="HistoryOperations" runat="server"></asp:GridView>
    </form>
</body>
</html>
