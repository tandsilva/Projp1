using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjP1
{
    public partial class PedidoEncomenda : System.Web.UI.Page
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

            tb_pedidoEncomenda pedidoEncomenda = new tb_pedidoEncomenda()
            {
                NomeCliente = TxtNomeCliente.Text,
                PedidoE = TxtPedidoE.Text,
                Valor_PedidoE = int.Parse(TxtValor_PedidoE.Text)
            };



            if (String.IsNullOrEmpty(idItem))
            {

                context.tb_pedidoEncomenda.Add(pedidoEncomenda);
                LblMSG.Text = "Registro Inserido!";
            }
            else
            {

                int idNew = int.Parse(idItem);
                tb_pedidoEncomenda p = context.tb_pedidoEncomenda.First(c => c.Id == idNew);
                p.NomeCliente = TxtNomeCliente.Text;
                p.PedidoE = TxtPedidoE.Text;
                p.Valor_PedidoE = int.Parse(TxtValor_PedidoE.Text);

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
                tb_pedidoEncomenda pedidoEncomenda = context.tb_pedidoEncomenda.First(c => c.Id == idNew);

                lblId.Visible = true;
                TxtId.Visible = true;



                TxtNomeCliente.Text = pedidoEncomenda.NomeCliente;
                TxtId.Text = pedidoEncomenda.Id.ToString();
                TxtPedidoE.Text = pedidoEncomenda.PedidoE;
                TxtValor_PedidoE.Text = pedidoEncomenda.Valor_PedidoE.ToString();
            }
        }
    }
}