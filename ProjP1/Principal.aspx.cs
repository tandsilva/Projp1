using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjP1
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void LoadTable()
        {
            BancoDadosEntities2 context = new BancoDadosEntities2();
            List<tb_principal> list = context.tb_principal.ToList<tb_principal>();

            GDVPedido.DataSource = list; 
            GDVPedido.DataBind();
        }

        protected void BtnInserir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cadastro.aspx");
        }

        protected void GDVPedido_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int line = int.Parse(e.CommandArgument.ToString());
            int id = int.Parse(GDVPedido.Rows[line].Cells[0].Text);//

         
            BancoDadosEntities2 context = new BancoDadosEntities2();
            tb_principal bprincipal = context.tb_principal.First(c => c.Id == id);

            if (e.CommandName == "A")
            {
                Response.Redirect("CadastrarCliente.aspx?idItem=" + id);
            }
            else if (e.CommandName == "E")
            {
                lblExcluir.Text = id.ToString();
                LblMSG.Text = "Tem certeza que deseja excluir este registro?";
                DisplayModal(this);
            }
        }

        private void DisplayModal(Page page)
        {
            ClientScript.RegisterStartupScript(typeof(Page),
                                               Guid.NewGuid().ToString(),
                                               "MostrarModal();",
                                               true);
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblExcluir.Text);

            BancoDadosEntities2 context = new BancoDadosEntities2();
            tb_principal principal = context.tb_principal.First(c => c.Id == id);
            context.tb_principal.Remove(principal);
            context.SaveChanges();

            LoadTable();
        }

        protected void BtnPedidoEncomenda_Click(object sender, EventArgs e)
        {
            Response.Redirect("PedidoEncomenda.aspx");

        }

        protected void BtnPedidoBalcao_Click(object sender, EventArgs e)
        {
            Response.Redirect("PedidoBalcao.aspx");
        }

        protected void BtnReservarMesa_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReservarMesa.aspx");
        }

        protected void TxtId_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BtnCadastrarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastrarCliente.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BancoDadosEntities2 context = new BancoDadosEntities2();
            List<Cliente_Costelaria> list = context.Cliente_Costelaria.ToList<Cliente_Costelaria>();

            GDVPedido.DataSource = list;
            GDVPedido.DataBind();
        }
        

        protected void btnListarTodos_Click(object sender, EventArgs e)
        {
            BancoDadosEntities2 context = new BancoDadosEntities2();
            List<Cliente_Costelaria> list = context.Cliente_Costelaria.ToList<Cliente_Costelaria>();

            GDVPedido.DataSource = list;
            GDVPedido.DataBind();

        }
    }
}       /*</ div >
        < asp:Button ID = "BtnCadastrarCliente" runat="server" Text="CadastrarCliente" />
        <asp:Button ID = "BtnPedidoEncomenda" runat="server" Text="PedidoEncomenda" Width="181px" />
        <asp:Button ID = "BtnPedidoBalcao" runat="server" CssClass="auto-style1" Text="PedidoBalcao" Width="169px" />
        <asp:Button ID = "BtnReservarMesa" runat="sersver" Text="ReservarMesa" />

         <br />
            
              <br />
                    Id<br />
                  </div>
        <asp:TextBox ID="TxtId" runat="server" CssClass="auto-style1" Height="22px" Width="176px" OnTextChanged="TxtId_TextChanged"></asp:TextBox>
        <asp:Button ID="BtnBuscar" runat="server" CssClass="btn btn-success" Text="Buscar"  OnClick="btnBuscar_Click" Width="180px"/>
        <asp:Button ID="BtnListarTodos" runat="server" CssClass="btn btn-success" Text="ListarTodos"  OnClick="btnListarTodos_Click" Width="180px" />
        
                <br />
        
                <br />  
<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" ></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
<asp:Button ID="BtnCadastrarCliente" runat="server" CssClass="btn btn-primary" Text="CadastrarCliente" OnClick="BtnCadastrarCliente_Click" Width="179px"  />
            
                    <asp:Button ID="BtnPedidoEncomenda" runat="server" CssClass="btn btn-primary" Text="PedidoEncomenda" OnClick="BtnPedidoEncomenda_Click" Width="179px" />
             
                    <asp:Button ID="BtnPedidoBalcao" runat="server" CssClass="btn btn-primary" Text="PedidoBalcao" OnClick="BtnPedidoBalcao_Click" Width="179px" />
                  
                    <asp:Button ID="BtnReservarMesa" runat="server" CssClass="btn btn-primary" Text="ReservarMesa" OnClick="BtnReservarMesa_Click" Width="179px" />
                     
        
                    <br />
                     
        
                <asp:GridView ID="GDVPedido" CssClass="table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCommand="GDVPedido_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" />
                        <asp:BoundField DataField="Nome" HeaderText="Nome" />
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
</html>*/