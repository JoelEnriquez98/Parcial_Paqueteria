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
    public partial class CRUDAddressee : System.Web.UI.Page
    {
        private DataTable dataTableDestinatarios = new DataTable();
        private Destinatario_FullTableAdapter destinatarioFullAdapter = new Destinatario_FullTableAdapter();
        private DestinatarioTableAdapter destinatarioTableAdapter = new DestinatarioTableAdapter();
        private DepartamentoTableAdapter departamentoTableAdapter = new DepartamentoTableAdapter();
        private Paquete1TableAdapter paquete1TableAdapter = new Paquete1TableAdapter();
        private PaqueteTableAdapter paqueteTableAdapter = new PaqueteTableAdapter();
        private MunicipioTableAdapter municipioTableAdapter = new MunicipioTableAdapter();
        private AldeaTableAdapter aldeaTableAdapter = new AldeaTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                LoadDepartments();
                LoadCities();
                LoadVillages();
            }
        }

        private void LoadData()
        {
            dataTableDestinatarios = destinatarioFullAdapter.GetDataAddresseeFull();
            GVAddressee.DataSource = dataTableDestinatarios;
            GVAddressee.DataBind();
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (!validateEmptyTextBoxes())
            {
                Addressee newAddressee = new Addressee(TextBoxName.Text, TextBoxAddress.Text, TextBoxReference.Text, DropDownVillage.SelectedValue);
                writeData(newAddressee);
                LoadData();
            }
        }

        private void writeData(Addressee newAddressee)
        {
            try
            {
                destinatarioTableAdapter.InsertAddressee(newAddressee.name, newAddressee.address, newAddressee.reference, newAddressee.codeVillage);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Enhorabuena', 'Se ha ingresado el destinatario de forma correcta', 'success')", true);
                cleanData();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Warning', '" + ex.Message + "', 'warning')", true);
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (!validateEmptyTextBoxes())
            {
                if (String.IsNullOrEmpty(TextBoxCode.Text))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Alerta', 'No ha seleccionado ningun registro para editar', 'warning')", true);
                }
                else
                {
                    Addressee originalAddressee = new Addressee(Convert.ToInt32(TextBoxCode.Text), TextBoxName.Text, TextBoxAddress.Text, TextBoxReference.Text, DropDownVillage.SelectedValue);
                    editData(originalAddressee);
                    LoadData();
                }

            }
        }

        private void editData(Addressee originalAddressee)
        {
            if (Session["code"].ToString().Equals(originalAddressee.code.ToString()))
            {
                try
                {
                    destinatarioTableAdapter.UpdateAddressee(originalAddressee.name, originalAddressee.address, originalAddressee.reference, originalAddressee.codeVillage, originalAddressee.code);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Enhorabuena', 'Se ha actualizado el destinatario de forma correcta', 'success')", true);
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
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Alerta', 'No es posible actualizar el codigo: " + originalAddressee.code + "', 'warning')", true);
                TextBoxCode.Text = originalAddressee.code.ToString();
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {

        }

        private bool validateEmptyTextBoxes()
        {
            TextBox[] textBoxes = { TextBoxReference, TextBoxAddress, TextBoxName };
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
            TextBoxReference.Text = "";
            TextBoxAddress.Text = "";
            TextBoxName.Text = "";
            TextBoxCode.Text = "";
        }

        protected void GVAddressee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //GetRow
            int index;
            bool bIsConverted = int.TryParse(e.CommandArgument.ToString().Trim(), out index);
            GridViewRow selectedRow = GVAddressee.Rows[index];
            String code = selectedRow.Cells[0].Text;

            DataTable dataTableHistoryDrive = destinatarioTableAdapter.GetDataByCode(Convert.ToInt32(code));
            try
            {
                foreach (DataRow row in dataTableHistoryDrive.Rows)
                {
                    TextBoxCode.Text = code;
                    TextBoxName.Text = row["nombre_destinatario"].ToString();
                    TextBoxAddress.Text = row["direccion_destinatario"].ToString();
                    TextBoxReference.Text = row["referencia_destinario"].ToString();
                    DropDownDepartments.SelectedValue = row["cod_depto"].ToString();
                    LoadCities();
                    DropDownCity.SelectedValue = row["cod_municipio"].ToString();
                    LoadVillages();
                    DropDownVillage.SelectedValue = row["cod_aldea"].ToString();
                }

                //Poner el codigo Temporal a la sesion
                Session.Add("code", code);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error', '" + ex.Message + "')", true);
            }


        }

        protected void DropDownDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCities();
        }

        protected void DropDownCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadVillages();
        }

        private void LoadCities()
        {
            DropDownCity.DataSource = municipioTableAdapter.GetMunicipiosByCodeDep(DropDownDepartments.SelectedValue);
            DropDownCity.DataTextField = "nombre_municipio";
            DropDownCity.DataValueField = "cod_municipio";
            DropDownCity.DataBind();
            LoadVillages();
        }

        private void LoadDepartments()
        {
            DropDownDepartments.DataSource = departamentoTableAdapter.GetDepartments();
            DropDownDepartments.DataTextField = "nombre_depto";
            DropDownDepartments.DataValueField = "cod_depto";
            DropDownDepartments.DataBind();
        }

        private void LoadVillages()
        {
            DropDownVillage.DataSource = aldeaTableAdapter.GetVillagesByCodeMunicipio(DropDownCity.SelectedValue);
            DropDownVillage.DataTextField = "nombre_aldea";
            DropDownVillage.DataValueField = "cod_aldea";
            DropDownVillage.DataBind();
        }
    }
}