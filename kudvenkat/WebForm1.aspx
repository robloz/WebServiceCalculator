<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="kudvenkat.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="2">
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
                <td colspan="2">
                    <asp:Button ID="ButtonAdd" runat="server" Text="+" OnClick="ButtonAdd_Click" />
                    <asp:Button ID="ButtonSub" runat="server" Text="-" OnClick="ButtonSub_Click" style="width: 18px" />
                    <asp:Button ID="ButtonMul" runat="server" Text="*" OnClick="ButtonMul_Click" />
                    <asp:Button ID="ButtonDiv" runat="server" Text="/" OnClick="ButtonDiv_Click" />
                </td>
            </tr>
        </table>




    </div>
        <asp:GridView ID="GVCalculation" runat="server"></asp:GridView>
    </form>
</body>
</html>
