using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjP1
{
    public partial class CadastroCliente : System.Web.UI.Page
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

            Cliente_Costelaria cadastroCliente = new Cliente_Costelaria()
            {
                NomeCliente = TxtNomeCliente.Text,
                Endereco = TxtEndereco.Text,
                Telefone = TxtTelefone.Text,
                Aniversario = TxtAniversario.Text
            };



            if (String.IsNullOrEmpty(idItem))
            {

                context.Cliente_Costelaria.Add(cadastroCliente);
                LblMSG.Text = "Registro Inserido!";
            }
            else
            {

                int idNew = int.Parse(idItem);
                Cliente_Costelaria t = context.Cliente_Costelaria.First(c => c.Id == idNew);
                t.NomeCliente = TxtNomeCliente.Text;
                t.Endereco = TxtEndereco.Text;
                t.Telefone = TxtTelefone.Text;
                t.Aniversario = TxtAniversario.Text;

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
                Cliente_Costelaria cadastroCliente = context.Cliente_Costelaria.First(c => c.Id == idNew);

                lblId.Visible = true;
                TxtId.Visible = true;



                TxtNomeCliente.Text = cadastroCliente.NomeCliente;
                TxtEndereco.Text = cadastroCliente.Endereco;
                TxtTelefone.Text = cadastroCliente.Telefone;
                TxtAniversario.Text = cadastroCliente.Aniversario.ToString();
            }
        }
    }
}