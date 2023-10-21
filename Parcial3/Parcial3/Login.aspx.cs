using Parcial3.DataSetPaqueteriaTableAdapters;
using Parcial3.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial3
{
    public partial class Login : System.Web.UI.Page
    {
        private AdministradorTableAdapter adminTableAdapter = new AdministradorTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            string codeUser = TBCode.Text;
            string password = TBPassword.Text;
            if (adminTableAdapter.CheckAdmin(codeUser, password) == 0)
            {
                invalidCredentials();
            }
            else
            {
                DataTable data = adminTableAdapter.GetAdminByCode(codeUser);
                String name = "";
                foreach (DataRow row in data.Rows)
                {
                    name = row["nombre"].ToString();
                }
                Administrador administrator = new Administrador(codeUser, password, name);
                Session.Add("admin", administrator);
                Response.Redirect("Administrator/MainAdmin.aspx");
            }
        }

        private void invalidCredentials()
        {
            Response.Write("<script>alert('Contraseña o codigo incorrecto');</script>");
        }
    }
}