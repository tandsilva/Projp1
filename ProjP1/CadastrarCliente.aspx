<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastrarCliente.aspx.cs" Inherits="ProjP1.CadastroCliente" %>

<!DOCTYPE html>
<script type="text/javascript">
    function MostrarModal() {
        $("#modalMsg").modal('show');
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" type="text/css" href="CSS/bootstrap.min.css" />
    

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cadastrar Cliente</title>
</head>
<body>
    <div class="col-sm-8">
        <h2>Cadastrar Cliente</h2>
    </div>
    <form id="form1" runat="server">
        <div>
            <div class="col-sm-2">
                <asp:Label ID="LblMSG" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
                <br />
                <br />
                <di<div class="form-group">
                     <asp:Label ID="lblId" runat="server" Text="Id" Visible="False"></asp:Label>
                    &nbsp;<asp:TextBox ID="TxtId" CssClass="form-control" runat="server" Width="206px" Enabled="False" Visible="False"></asp:TextBox>
                </div>
                NomeCliente<asp:TextBox ID="TxtNomeCliente" CssClass="form-control" runat="server" Width="322px"></asp:TextBox>
                <div class="form-group">
                    Telefone<asp:TextBox ID="TxtTelefone" CssClass="form-control" runat="server" Width="322px"></asp:TextBox>
                </div>
                <div class="form-group">
                    Endereco <asp:TextBox ID="TxtEndereco" CssClass="form-control" runat="server" Width="322px"></asp:TextBox>
                </div>
                <div class="form-group">
                    Aniversario <asp:TextBox ID="TxtAniversario" CssClass="form-control" runat="server" Width="322px"></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-2">
                <div class="form-group">
                    <asp:Button ID="BtnSalvar" runat="server" CssClass="btn btn-success" OnClick="BtnSalvar_Click" Text="Salvar" />
                    &nbsp;
                    <asp:Button ID="BtnVoltar" runat="server" CssClass="btn btn-primary" Text="Voltar" OnClick="BtnVoltar_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>