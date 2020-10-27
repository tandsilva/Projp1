<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cozinha.aspx.cs" Inherits="ProjP1.Cozinha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="CSS/bootstrap.min.css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LblMSG" runat="server" Font-Bold="True" ForeColor="purple"></asp:Label>
            <br />
            <br />
            IdPedido<br />
            <asp:TextBox ID="TxtIdPedido" runat="server"></asp:TextBox>
            <br />
            <br />
        </div>
        <asp:GridView ID="GDVBilhete" CssClass="table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCommand="GDVBilhete_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="IdPedido" HeaderText="IdPedido" />
                        <asp:BoundField DataField="NomeCliente" HeaderText="NomeCliente" />
                        
                        <asp:ButtonField ButtonType="Image" Text="OK" CommandName="A" ImageUrl="~/img/DocumentEdit_40924.png">
                        </asp:ButtonField>
                        <asp:ButtonField ButtonType="Image" Text="NOTOK" CommandName="E" ImageUrl="~/img/delete_4219.png">
                        </asp:ButtonField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
        </div>
    </form>
</body>
</html>
