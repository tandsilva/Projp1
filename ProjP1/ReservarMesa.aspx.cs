using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjP1
{
    public partial class ReservarMesa : System.Web.UI.Page
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

            tb_reserva reservarMesa = new tb_reserva()
            {
                Qtd_cadeira = int.Parse(TxtQtd_cadeira.Text),
                Num_Mesa = int.Parse(TxtNum_Mesa.Text),
                Horario = TxtHorario.Text

            };

            if (String.IsNullOrEmpty(idItem))
            {

                context.tb_reserva.Add(reservarMesa);
                LblMSG.Text = "Registro Inserido!";
            }
            else
            {

                int idNew = int.Parse(idItem);
                tb_reserva r = context.tb_reserva.First(c => c.Id == idNew);
                r.Qtd_cadeira = int.Parse(TxtQtd_cadeira.Text);
                r.Num_Mesa = int.Parse(TxtNum_Mesa.Text);
                r.Horario = TxtHorario.Text;
                

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
                tb_reserva reservarMesa = context.tb_reserva.First(c => c.Id == idNew);

                lblId.Visible = true;
                TxtId.Visible = true;

                TxtQtd_cadeira.Text = reservarMesa.Qtd_cadeira.ToString();
                TxtId.Text = reservarMesa.Id.ToString();
                TxtNum_Mesa.Text = reservarMesa.Num_Mesa.ToString(); ;
                TxtHorario.Text = reservarMesa.Horario;
            }
        }
    }
}