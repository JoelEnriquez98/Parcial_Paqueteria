using Parcial3.DataSetPaqueteriaTableAdapters;
using Parcial3.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial3.Administrator
{
    public partial class CRUDPackage : System.Web.UI.Page
    {
        private Paquete1TableAdapter paquete1Adapter = new Paquete1TableAdapter();
        private Historial_conduccionTableAdapter historialTableAdapter = new Historial_conduccionTableAdapter();
        private DataTable paqueteDataTable = new DataTable();
        private PaqueteTableAdapter paqueteTable = new PaqueteTableAdapter();
        private DestinatarioTableAdapter destinatarioTableAdapter = new DestinatarioTableAdapter();
        private DepartamentoTableAdapter departamentoTableAdapter = new DepartamentoTableAdapter();
        private MunicipioTableAdapter municipioTableAdapter = new MunicipioTableAdapter();
        private AldeaTableAdapter aldeaTableAdapter = new AldeaTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            paqueteDataTable = paqueteTable.GetInfoPackages();
            GVPackages.DataSource = paqueteTable.GetInfoPackages();
            GVPackages.DataBind();
        }
        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (!validateEmptyTextBoxes())
            {
                Package newPackage = new Package(TextBoxCodePackage.Text, TextBoxDescription.Text, TextBoxTypePackage.Text, Convert.ToDecimal(TextBoxWeight.Text), Convert.ToInt32(TextBoxCodeAddressee.Text), Convert.ToInt32(TextBoxCodeHistory.Text));
                writeData(newPackage);
                LoadData();
            }
        }

        private void writeData(Package package)
        {
            if (paqueteTable.CheckPackage(package.code) == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error', 'Este codigo ya se ha registrado', 'error')", true);
            }
            else if (historialTableAdapter.CheckCodigoHistorial(package.codeControl) == null || Convert.ToInt32(historialTableAdapter.CheckCodigoHistorial(package.codeControl)) == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Alerta', 'No existe dicho codigo de control', 'warning')", true);
            }
            else if ((destinatarioTableAdapter.CheckExistingAddresseeCode(package.codeAddressee)) == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Alerta', 'No existe dicho codigo de destinatario', 'warning')", true);
            }
            else
            {
                try
                {
                    paqueteTable.InsertPackage(package.code, package.description, package.type, package.weight, package.codeAddressee, package.codeControl);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Enhorabuena', 'Se ha ingresado el paquete de forma correcta', 'success')", true);
                    cleanData();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Warning', '" + ex.Message + "', 'warning')", true);
                }

            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (!validateEmptyTextBoxes())
            {
                Package existingPackage = new Package(TextBoxCodePackage.Text, TextBoxDescription.Text, TextBoxTypePackage.Text, Convert.ToDecimal(TextBoxWeight.Text), Convert.ToInt32(TextBoxCodeAddressee.Text), Convert.ToInt32(TextBoxCodeHistory.Text));
                editData(existingPackage);
            }
        }

        private void editData(Package package)
        {
            if (Session["code_package"].ToString().Equals(package.code))
            {
                try
                {
                    paqueteTable.UpdatePackage(package.code, package.description, package.type, package.weight, package.codeAddressee, package.codeControl, package.code);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Enhorabuena', 'Se ha actualizado el paquete de forma correcta', 'success')", true);
                    LoadData();
                    cleanData();
                }
                catch (Exception e)
                {

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error', '" + e.Message + "', 'error')", true); ;
                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Alerta', 'No es posible actualizar el codigo: " + package.code + " del paquete.', 'warning')", true);
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {

        }

        private bool validateEmptyTextBoxes()
        {
            TextBox[] textBoxes = { TextBoxCodePackage, TextBoxDescription, TextBoxTypePackage, TextBoxWeight, TextBoxCodeAddressee, TextBoxCodeHistory };
            foreach (TextBox textBox in textBoxes)
            {
                if (String.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Focus();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error', 'Ingrese el dato del: " + textBox.ID + "', 'warning')", true);
                    return true;
                }
            }
            return false;
        }

        private void cleanData()
        {
            TextBoxCodePackage.Text = "";
            TextBoxDescription.Text = "";
            TextBoxTypePackage.Text = "";
            TextBoxWeight.Text = "";
            TextBoxCodeAddressee.Text = "";
            TextBoxCodeHistory.Text = "";
        }

        protected void GVPackages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //GetRow
            int index;
            bool bIsConverted = int.TryParse(e.CommandArgument.ToString().Trim(), out index);
            GridViewRow selectedRow = GVPackages.Rows[index];
            String codePackage = selectedRow.Cells[0].Text;

            DataTable dataTablePackage = paquete1Adapter.GetPaqueteByCode(codePackage);
            Package tempPackage = new Package();
            foreach (DataRow row in dataTablePackage.Rows)
            {
                TextBoxCodePackage.Text = codePackage;
                TextBoxDescription.Text = row["descripcion_paquete"].ToString();
                TextBoxTypePackage.Text = row["tipo_paquete"].ToString();
                TextBoxWeight.Text = row["peso_paquete"].ToString();
                TextBoxCodeAddressee.Text = row["codigo_destinatario"].ToString();
                TextBoxCodeHistory.Text = row["codigo_control"].ToString();
            }

            //Poner el codigo Temporal a la sesion
            Session.Add("code_package", codePackage);

        }
    }
}