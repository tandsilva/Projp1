<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PedidoEncomenda.aspx.cs" Inherits="ProjP1.PedidoEncomenda" %>

<!DOCTYPE html>
<script type="text/javascript">
    function MostrarModal() {
        $("#modalMsg").modal('show');
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" type="text/css" href="CSS/bootstrap.min.css"/>
    <link rel="stylesheet" type="text/css" href="Styles/styles.css"/>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
  
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Pedido por Encomenda</title>
     <style type="text/css">
         .auto-style1 {
             position: relative;
             width: 100%;
             -ms-flex: 0 0 16.666667%;
             flex: 0 0 16.666667%;
             max-width: 16.666667%;
             left: 0px;
             top: 0px;
             padding-left: 15px;
             padding-right: 15px;
         
     </style>
</head>
<body>
    <div style="padding-top: 2%"></div>
    <div class="col-sm-8">
        <h2>Pedido por Encomenda</h2>
    </div>
    <form id="form1" runat="server">
        <div>
            <div class="col-sm-2">
                 <div class="form-group">
                <asp:Label ID="LblMSG" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
                <br />
                <br />
               <<asp:Label ID="lblId" runat="server" Text="Id" Visible="False"></asp:Label>
                    &nbsp;<asp:TextBox ID="TxtId" CssClass="form-control" runat="server" Width="206px" Enabled="False" Visible="False"></asp:TextBox>
                </div>
                   
                </div>NomeCliente<asp:TextBox ID="TxtNomeCliente" CssClass="form-control" runat="server" Width="322px"></asp:TextBox>
                PedidoE<div class="form-group">
                    <asp:TextBox ID="TxtPedidoE" CssClass="form-control" runat="server" Width="322px"></asp:TextBox>
                </div>
                <div class="form-group">
                    Valor_PedidoE<asp:TextBox ID="TxtValor_PedidoE" CssClass="form-control" runat="server" Width="322px"></asp:TextBox>
                    <br />
                    <br />
                </div>
           
            <div class="auto-style1">
                <div class="form-group">
                    <asp:Button ID="BtnSalvar" runat="server" CssClass="btn btn-success" Text="Salvar" OnClick="BtnSalvar_Click" Width="82px"  />
                    &nbsp;
                    <asp:Button ID="BtnVoltar" runat="server" CssClass="btn btn-primary" Text="Voltar" OnClick="BtnVoltar_Click" style="margin-left: 21" Width="81px" />
                    <br />
                    ]<br />
                </div>
            </div>
        </div>
    </form>
</body>
</html>