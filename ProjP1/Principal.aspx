<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="ProjP1.Principal" %>

<!DOCTYPE html>

<script type="text/javascript">
    function MostrarModal() {
        $("#modalMsg").modal('show');
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="CSS/bootstrap.min.css" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" integrity="sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8shuf57BaghqFfPlYxofvL8/KUEfYiJOMMV+rV" crossorigin="anonymous"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Costelaria</title>
</head>
<body>
    <div style="padding-top: 2%"></div>
    <div class="col-sm-8">
        <h2>&nbsp;</h2>
        <h2>Costelaria</h2>
    </div>
    <form id="form1" runat="server">
        
            <div class="col-sm-8">
                <div class="form-group">
                    
                  
                <asp:Label ID="LblMSG" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
               <br />
                    <asp:Button ID="BtnCadastrarCliente" runat="server" CssClass="btn btn-primary" Text="CadastrarCliente" OnClick="BtnCadastrarCliente_Click" Width="179px"  />
            
                    <asp:Button ID="BtnPedidoEncomenda" runat="server" CssClass="btn btn-primary" Text="PedidoEncomenda" OnClick="BtnPedidoEncomenda_Click" Width="179px" />
             
                    <asp:Button ID="BtnPedidoBalcao" runat="server" CssClass="btn btn-primary" Text="PedidoBalcao" OnClick="BtnPedidoBalcao_Click" Width="179px" />
                  
                    <asp:Button ID="BtnReservarMesa" runat="server" CssClass="btn btn-primary" Text="ReservarMesa" OnClick="BtnReservarMesa_Click" Width="179px" />
                    <br />
                        <br />
                        Id<br>
                         <asp:TextBox ID="TxtId" runat="server" CssClass="auto-style1" Height="22px" Width="176px" OnTextChanged="TxtId_TextChanged"></asp:TextBox>
        <asp:Button ID="BtnBuscar" runat="server" CssClass="btn btn-success" Text="Buscar"  OnClick="btnBuscar_Click" Width="180px"/>
        <asp:Button ID="BtnListarTodos" runat="server" CssClass="btn btn-success" Text="ListarTodos"  OnClick="btnListarTodos_Click" Width="180px"/>
                    </br>
       
        
                    <br />
        
                <asp:GridView ID="GDVPedido" CssClass="table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCommand="GDVPedido_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" />
                        <asp:BoundField DataField="NomeCliente" HeaderText="NomeCliente" />
                        <asp:BoundField DataField="Endereco" HeaderText="Endereco" />
                        <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
                        <asp:BoundField DataField="Aniversario" HeaderText="Aniversario" />
                        <asp:ButtonField ButtonType="Image" Text="Alterar" CommandName="A" ImageUrl="~/img/DocumentEdit_40924.png">
                        </asp:ButtonField>
                        <asp:ButtonField ButtonType="Image" Text="Excluir" CommandName="E" ImageUrl="~/img/delete_4219.png">
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
            <br />
            </div>
        

        <div class="modal fade" id="modalMsg" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Confirmação</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="Label" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                        <asp:Button ID="btnConfirm" CssClass="btn btn-danger" runat="server" Text="Confirmar" OnClick="btnConfirm_Click" />
                        <asp:Label ID="lblExcluir" runat="server" Visible="False"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>