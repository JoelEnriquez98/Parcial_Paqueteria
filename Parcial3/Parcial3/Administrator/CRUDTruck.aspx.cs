using Parcial3.DataSetPaqueteriaTableAdapters;
using Parcial3.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace Parcial3.Administrator
{
    public partial class CRUDTruck : System.Web.UI.Page
    {
        private DataTable camionDataTable = new DataTable();
        private CamionTableAdapter camionTableAdapter = new CamionTableAdapter();
        private LineaTableAdapter lineaTableAdapter = new LineaTableAdapter();
        private MarcaTableAdapter marcaTableAdapter = new MarcaTableAdapter();
        private ModeloTableAdapter modeloTableAdapter = new ModeloTableAdapter();
        private TipoTableAdapter tipoTableAdapter = new TipoTableAdapter();
        private Estado_CamionTableAdapter estadoCamionTableAdapter = new Estado_CamionTableAdapter();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                LoadBranches();
                LoadStates();
                LoadModels();
                LoadTypes();
            }
        }
        private void LoadData()
        {
            camionDataTable = camionTableAdapter.GetDataTrucks();
            GVTruck.DataSource = camionTableAdapter.GetDataTrucks();
            GVTruck.DataBind();
        }
        private void LoadBranches()
        {
            DropDownBranch.DataSource = marcaTableAdapter.GetMarcas();
            DropDownBranch.DataTextField = "nombre_marca";
            DropDownBranch.DataValueField = "cod_marca";
            DropDownBranch.DataBind();
            LoadLines();
        }

        private void LoadLines()
        {
            DropDownListLine.DataSource = lineaTableAdapter.GetLinesByBranch(DropDownBranch.SelectedValue);
            DropDownListLine.DataTextField = "nombre_linea";
            DropDownListLine.DataValueField = "cod_linea";
            DropDownListLine.DataBind();
        }

        private void LoadStates()
        {
            DropDownState.DataSource = estadoCamionTableAdapter.GetEstado();
            DropDownState.DataTextField = "nombre_estado";
            DropDownState.DataValueField = "codigo_estado";
            DropDownState.DataBind();
        }

        private void LoadModels()
        {
            DropDownModel.DataSource = modeloTableAdapter.GetModelos();
            DropDownModel.DataTextField = "nombre_modelo";
            DropDownModel.DataValueField = "cod_modelo";
            DropDownModel.DataBind();
        }

        private void LoadTypes()
        {
            DropDownType.DataSource = tipoTableAdapter.GetTipos();
            DropDownType.DataTextField = "nombre_tipo";
            DropDownType.DataValueField = "cod_tipo";
            DropDownType.DataBind();
        }
        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (!validateEmptyTextBoxes())
            {
                Truck newTruck = new Truck(TextBoxMatricula.Text, DropDownModel.SelectedValue, DropDownType.SelectedValue, DropDownListLine.SelectedValue, Convert.ToInt32(DropDownState.SelectedValue));
                writeData(newTruck);
                LoadData();
            }
        }

        private void writeData(Truck truck)
        {
            if (camionTableAdapter.CheckTruck(truck.matricula) == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error', 'Esta matricula ya se ha registrado', 'error')", true);
            }
            else
            {
                camionTableAdapter.InsertTruck(truck.matricula, truck.codeModel, truck.codeType, truck.codeLine, Convert.ToInt32(truck.codigoState));
                cleanData();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Enhorabuena', 'Se ha ingresado el camionero correctamente', 'success')", true);
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (!validateEmptyTextBoxes())
            {
                Truck newTruck = new Truck(TextBoxMatricula.Text, DropDownModel.SelectedValue, DropDownType.SelectedValue, DropDownListLine.SelectedValue, Convert.ToInt32(DropDownState.SelectedValue));
                editData(newTruck);
                LoadData();
            }
        }

        private void editData(Truck truck)
        {
            if (Session["Matricula"].ToString().Equals(truck.matricula))
            {
                try
                {
                    camionTableAdapter.UpdateTruck(truck.matricula, truck.codeModel, truck.codeType, truck.codeLine, Convert.ToInt32(truck.codigoState), truck.matricula);
                    Session.Remove("Matricula");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Enhorabuena', 'Se ha actualizado el camion correctamente', 'success')", true);
                    cleanData();
                }
                catch (Exception e)
                {

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error', '" + e.Message + "', 'error')", true); ;
                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error', 'No es posible actualizar la matricula del camion: " + truck.matricula + "', 'warning')", true);
                TextBoxMatricula.Text = Session["Matricula"].ToString();
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {

        }

        private bool validateEmptyTextBoxes()
        {
            TextBox[] textBoxes = { TextBoxMatricula };
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
            TextBoxMatricula.Text = "";
        }

        protected void GVTruck_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            //GetRow
            int index;
            bool bIsConverted = int.TryParse(e.CommandArgument.ToString().Trim(), out index);
            GridViewRow selectedRow = GVTruck.Rows[index];
            String matricula = selectedRow.Cells[0].Text;
            String codeModel = "";
            String codeType = "";
            String codeState = "";
            String codeBranch = "";
            String codeLine = "";
            DataTable dataTable = camionTableAdapter.GetDataByCodeTruck(matricula);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                codeState = dataRow["codigo_estado"].ToString();
                codeModel = dataRow["cod_modelo"].ToString();
                codeType = dataRow["cod_tipo"].ToString();
                codeLine = dataRow["cod_linea"].ToString();
            }

            DataTable dataLine = lineaTableAdapter.GetDataByCodeLine(codeLine);
            foreach (DataRow dataRow in dataLine.Rows)
            {
                codeBranch = dataRow["cod_marca"].ToString();
            }
            TextBoxMatricula.Text = matricula;
            DropDownState.SelectedValue = codeState;
            DropDownType.SelectedValue = codeType;
            DropDownBranch.SelectedValue = codeBranch;
            LoadLines();
            DropDownListLine.SelectedValue = codeLine;
            DropDownModel.SelectedValue = codeModel;

            Session.Add("Matricula", matricula);


        }



        protected void DropDownBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLines();
        }

        protected void DropDownType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change Label
        }
    }
}
