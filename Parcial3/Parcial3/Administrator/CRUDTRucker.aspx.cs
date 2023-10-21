using Parcial3.DataSetPaqueteriaTableAdapters;
using Parcial3.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial3.Administrator
{
    public partial class AddEditTrucker : System.Web.UI.Page
    {
        private DeptoMuniAldeaTableAdapter deptoMuniAldeaTable = new DeptoMuniAldeaTableAdapter();
        private DataTableCamioneroAldeaTableAdapter camioneroAldeaTableAdapter = new DataTableCamioneroAldeaTableAdapter();
        private DataTableAldeaMuniDeparTableAdapter adapterAlMuDe = new DataTableAldeaMuniDeparTableAdapter();
        private CamionerosInfoTableAdapter adapterInfo = new CamionerosInfoTableAdapter();
        private DataTable truckersDataTable = new DataTable();
        private DepartamentoTableAdapter departamentoTableAdapter = new DepartamentoTableAdapter();
        private MunicipioTableAdapter municipioTableAdapter = new MunicipioTableAdapter();
        private AldeaTableAdapter aldeaTableAdapter = new AldeaTableAdapter();
        private CamioneroTableAdapter camioneroTableAdapter = new CamioneroTableAdapter();
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

        protected void GVCostumers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            truckersDataTable = adapterInfo.GetTruckersInfo();
            GVTruckers.DataSource = adapterInfo.GetTruckersInfo();
            GVTruckers.DataBind();
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
            openModal();
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

        private void openModal()
        {
            string script = "$('#registerModal').modal('show');";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (!validateEmptyTextBoxes())
            {
                Trucker newTrucker = new Trucker(TextBoxRegisterDPI.Text, TextBoxRegisterName.Text, TextBoxRegisterPhone.Text, TextBoxAddress.Text, Convert.ToDecimal(TextBoxSalary.Text), DropDownVillage.SelectedValue);
                writeData(newTrucker);
                LoadData();
            }
        }

        private void writeData(Trucker trucker)
        {
            if (camioneroTableAdapter.CheckTrucker(trucker.DPI) == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error', 'Este DPI ya se ha registrado', 'error')", true);
            }
            else
            {
                camioneroTableAdapter.InsertCamionero(trucker.DPI, trucker.name, trucker.phone, trucker.address, trucker.salary, trucker.villageCode);
                cleanData();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Enhorabuena', 'Se ha ingresado el camionero correctamente', 'success')", true);
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (!validateEmptyTextBoxes())
            {
                Trucker newTrucker = new Trucker(TextBoxRegisterDPI.Text, TextBoxRegisterName.Text, TextBoxRegisterPhone.Text, TextBoxAddress.Text, Convert.ToDecimal(TextBoxSalary.Text), DropDownVillage.SelectedValue);
                editData(newTrucker);
                LoadData();
            }
        }

        private void editData(Trucker trucker)
        {
            if (Session["DPI"].ToString().Equals(trucker.DPI))
            {
                try
                {
                    camioneroTableAdapter.UpdateTrucker(trucker.DPI, trucker.name, trucker.phone, trucker.address, trucker.salary, trucker.villageCode, trucker.DPI);
                    Session.Remove("DPI");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Enhorabuena', 'Se ha actualizado el camionero correctamente', 'success')", true);
                    cleanData();
                }
                catch (Exception e)
                {

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error', '" + e.Message + "', 'error')", true); ;
                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error', 'No es posible actualizar el DPI: " + trucker.DPI + "', 'warning')", true);
                TextBoxRegisterDPI.Text = Session["DPI"].ToString();
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {

        }

        private bool validateEmptyTextBoxes()
        {
            TextBox[] textBoxes = { TextBoxRegisterDPI, TextBoxRegisterName, TextBoxRegisterPhone, TextBoxAddress, TextBoxSalary };
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
            TextBoxRegisterDPI.Text = "";
            TextBoxRegisterName.Text = "";
            TextBoxRegisterPhone.Text = "";
            TextBoxAddress.Text = "";
            TextBoxSalary.Text = "";
        }

        protected void GVTruckers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //GetRow
            int index;
            bool bIsConverted = int.TryParse(e.CommandArgument.ToString().Trim(), out index);
            GridViewRow selectedRow = GVTruckers.Rows[index];
            String DPI = selectedRow.Cells[0].Text;
            TextBoxRegisterDPI.Text = DPI;
            TextBoxRegisterName.Text = selectedRow.Cells[1].Text;
            TextBoxRegisterPhone.Text = selectedRow.Cells[2].Text;
            TextBoxAddress.Text = selectedRow.Cells[3].Text;
            TextBoxSalary.Text = selectedRow.Cells[4].Text;
            String nameDepartment = selectedRow.Cells[5].Text;
            String nameCity = selectedRow.Cells[6].Text;
            String nameVillage = selectedRow.Cells[7].Text;

            //Select Correct Village in DropDowns
            DataTable dataTableCodeVillage = new DataTable();
            dataTableCodeVillage.Constraints.Clear();
            dataTableCodeVillage = camioneroAldeaTableAdapter.CodeVillageByDPITrucker(DPI);
            String codeVillage = "";
            String codeDepart = "";
            String codeMuni = "";

            foreach (DataRow row in dataTableCodeVillage.Rows)
            {
                codeVillage = row["cod_aldea"].ToString();
            }
            try
            {
                DataTable dataTableMuni = deptoMuniAldeaTable.GetLocation(codeVillage);
                foreach (DataRow row in dataTableMuni.Rows)
                {
                    codeVillage = row["cod_aldea"].ToString();
                    codeMuni = row["cod_municipio"].ToString();
                    codeDepart = row["cod_depto"].ToString();
                }

                DropDownDepartments.SelectedValue = codeDepart;
                LoadCities();
                DropDownCity.SelectedValue = codeMuni;
                LoadVillages();
                DropDownVillage.SelectedValue = codeVillage;


                //Poner el DPI Temporal a la sesion
                Session.Add("DPI", DPI);
            }
            catch (ConstraintException ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error', 'Ingrese el dato del: " + ex.Message + "', 'warning')", true); ;
            }

        }
    }
}