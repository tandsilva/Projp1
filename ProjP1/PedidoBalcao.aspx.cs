using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjP1
{
    public partial class PedidoBalcao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDataPage();
            }
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {

            string idItem = Request.QueryString["idItem"];

            BancoDadosEntities2 context = new BancoDadosEntities2();

            tb_pedido_Balcao pedidoBalcao = new tb_pedido_Balcao()
            {
                NomeCliente = TxtNomeCliente.Text,
                PedidoB = TxtPedidoB.Text,
                ValorPedidoB = int.Parse(TxtValorPedidoB.Text)
            };



            if (String.IsNullOrEmpty(idItem))
            {

                context.tb_pedido_Balcao.Add(pedidoBalcao);
                LblMSG.Text = "Registro Inserido!";
            }
            else
            {

                int idNew = int.Parse(idItem);
                tb_pedido_Balcao p = context.tb_pedido_Balcao.First(c => c.Id == idNew);
                p.NomeCliente = TxtNomeCliente.Text;
                p.PedidoB = TxtPedidoB.Text;
                p.ValorPedidoB = int.Parse(TxtValorPedidoB.Text);

                LblMSG.Text = "Registro Atualizado!";
            }

            context.SaveChanges();
        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Principal.aspx");
        }

        private void LoadDataPage()
        {
            string idItem = Request.QueryString["idItem"];

            if (!String.IsNullOrEmpty(idItem))
            {
           
                BancoDadosEntities2 context = new BancoDadosEntities2();
                int idNew = int.Parse(idItem);
                tb_pedido_Balcao pedidoBalcao = context.tb_pedido_Balcao.First(c => c.Id == idNew);

                lblId.Visible = true;
                TxtId.Visible = true;

             
               
                TxtNomeCliente.Text = pedidoBalcao.NomeCliente;
                TxtId.Text = pedidoBalcao.Id.ToString();
                TxtPedidoB.Text = pedidoBalcao.PedidoB;
                TxtValorPedidoB.Text = pedidoBalcao.ValorPedidoB.ToString();
            }
        }
    }
}