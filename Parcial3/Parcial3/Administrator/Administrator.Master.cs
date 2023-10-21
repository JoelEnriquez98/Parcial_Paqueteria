using Parcial3.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial3.Admin
{
    public partial class Administrator : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin"] == null)
                {
                    Response.Redirect("../Login.aspx");
                }
                else
                {
                    Administrador admin = ((Administrador)Session["admin"]);
                    LabelNameAdmin.Text = "Bienvenido: " + admin.name;
                }
            }
        }
    }
}