using Parcial3.DataSetPaqueteriaTableAdapters;
using Parcial3.Objects;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Parcial3.DataSetPaqueteria;

namespace Parcial3.Administrator
{
    public partial class DriveHistory : System.Web.UI.Page
    {
        private DataTable dataTableHistory = new DataTable();
        private Historial_Conduccion_EditarTableAdapter historial_Conduccion_ = new Historial_Conduccion_EditarTableAdapter();
        private CamionTableAdapter camionTableAdapter = new CamionTableAdapter();
        private CamioneroTableAdapter camioneroTableAdapter = new CamioneroTableAdapter();
        private Paquete1TableAdapter paquete1TableAdapter = new Paquete1TableAdapter();
        private PaqueteTableAdapter paqueteTableAdapter = new PaqueteTableAdapter();
        private DestinatarioTableAdapter destinatarioTableAdapter = new DestinatarioTableAdapter();
        private Historial_conduccionTableAdapter historial_ConduccionTA = new Historial_conduccionTableAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            dataTableHistory = historial_ConduccionTA.GetDataDriveHistory();
            GVDriveHistory.DataSource = historial_ConduccionTA.GetDataDriveHistory();
            GVDriveHistory.DataBind();
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (!validateEmptyTextBoxes())
            {
                DrivingHistory newDriveHistory = new DrivingHistory(Convert.ToDateTime(TextBoxDepartureDate.Text), Convert.ToDateTime(TextBoxReturnDate.Text), TextBoxInitialState.Text, TextBoxFinalState.Text, TextBoxCarRegistration.Text, Convert.ToInt32(TextBoxInitialMileage.Text), Convert.ToInt32(TextBoxFinalMileage.Text), Convert.ToBoolean(radioButtonVehicleAvailability.SelectedValue), TextBoxDPI.Text);
                writeData(newDriveHistory);
                LoadData();
            }
        }

        private void writeData(DrivingHistory newDriveHistory)
        {
            if (camioneroTableAdapter.CheckTrucker(newDriveHistory.DPI) == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Alerta', 'No existe el DPI: " + newDriveHistory.DPI + "', 'warning')", true);
                TextBoxDPI.Focus();
            }
            else if ((camionTableAdapter.CheckTruck(newDriveHistory.carRegistration)) == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Alerta', 'No existe la matricula: " + newDriveHistory.carRegistration + "', 'warning')", true);
                TextBoxCarRegistration.Focus();
            }
            else
            {
                try
                {
                    historial_ConduccionTA.InsertDriveHistory(newDriveHistory.departureDate, newDriveHistory.returnDate, newDriveHistory.vehicleInitialState, newDriveHistory.vehicleFinalState, newDriveHistory.carRegistration, newDriveHistory.initialMileage, newDriveHistory.finalMileage, newDriveHistory.vehicleAvailability, newDriveHistory.DPI);
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
                DrivingHistory editDriveHistory = new DrivingHistory(Convert.ToInt32(TextBoxCodeControl.Text), Convert.ToDateTime(TextBoxDepartureDate.Text), Convert.ToDateTime(TextBoxReturnDate.Text), TextBoxInitialState.Text, TextBoxFinalState.Text, TextBoxCarRegistration.Text, Convert.ToInt32(TextBoxInitialMileage.Text), Convert.ToInt32(TextBoxFinalMileage.Text), Convert.ToBoolean(radioButtonVehicleAvailability.SelectedValue), TextBoxDPI.Text);
                editData(editDriveHistory);
                LoadData();
            }
        }

        private void editData(DrivingHistory editDriveHistory)
        {
            if (Session["code_control"].ToString().Equals(editDriveHistory.codeControl.ToString()))
            {
                if (camioneroTableAdapter.CheckTrucker(editDriveHistory.DPI) == 0)
                {
                    TextBoxDPI.Focus();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Alerta', 'No existe el DPI: " + editDriveHistory.DPI + "', 'warning')", true);
                }
                else if ((camionTableAdapter.CheckTruck(editDriveHistory.carRegistration)) == 0)
                {
                    TextBoxCarRegistration.Focus();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Alerta', 'No existe la matricula: " + editDriveHistory.carRegistration + "', 'warning')", true);
                }
                else
                {
                    try
                    {
                        historial_ConduccionTA.UpdateDriveHistory(editDriveHistory.departureDate, editDriveHistory.returnDate, editDriveHistory.vehicleInitialState, editDriveHistory.vehicleFinalState, editDriveHistory.carRegistration, editDriveHistory.initialMileage, editDriveHistory.finalMileage, editDriveHistory.vehicleAvailability, editDriveHistory.DPI, editDriveHistory.codeControl);
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Enhorabuena', 'Se ha actualizado el paquete de forma correcta', 'success')", true);
                        LoadData();
                        cleanData();
                    }
                    catch (Exception e)
                    {

                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error', '" + e.Message + "', 'error')", true); ;
                    }
                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Alerta', 'No es posible actualizar el codigo: " + editDriveHistory.codeControl + "', 'warning')", true);
                TextBoxCodeControl.Text = editDriveHistory.codeControl.ToString();
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {

        }

        public string GetFormatStringFromCodeBehind(object obj)
        {
            return Convert.ToDateTime(obj).ToString("dd/MM/yyy");
        }

        public string GetFormatStringFromCodeBehindYear(object obj)
        {
            return Convert.ToDateTime(obj).ToString("yyyy/MM/dd");
        }

        private bool validateEmptyTextBoxes()
        {
            TextBox[] textBoxes = { TextBoxDepartureDate, TextBoxInitialState, TextBoxCarRegistration, TextBoxInitialMileage, TextBoxDPI };
            foreach (TextBox textBox in textBoxes)
            {
                if (String.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Focus();
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error', 'Ingrese el dato del: " + textBox.ID + "', 'warning')", true);
                    return true;
                }
            }
            if (radioButtonVehicleAvailability.SelectedValue == null)
            {
                radioButtonVehicleAvailability.Focus();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error', 'Ingrese el dato del: " + radioButtonVehicleAvailability.ID + "', 'warning')", true);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void cleanData()
        {
            TextBoxCodeControl.Text = "";
            TextBoxDepartureDate.Text = "";
            TextBoxReturnDate.Text = "";
            TextBoxInitialState.Text = "";
            TextBoxFinalState.Text = "";
            TextBoxCarRegistration.Text = "";
            TextBoxInitialMileage.Text = "";
            TextBoxFinalMileage.Text = "";
            TextBoxDPI.Text = "";

        }

        protected void GVDriveHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //GetRow
            int index;
            bool bIsConverted = int.TryParse(e.CommandArgument.ToString().Trim(), out index);
            GridViewRow selectedRow = GVDriveHistory.Rows[index];
            String codeControl = selectedRow.Cells[0].Text;

            DataTable dataTableHistoryDrive = historial_Conduccion_.GetDataEditDriveHistory(Convert.ToInt32(codeControl));
            try
            {
                foreach (DataRow row in dataTableHistoryDrive.Rows)
                {
                    String departureDateString2 = row["salida"].ToString();
                    String returnDateString2 = row["retorno"].ToString();
                    /*
                    string newFormatDateNow = DateTime.ParseExact(datenow, "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString();
                    string newFormat = DateTime.ParseExact(row["fecha_retorno"].ToString(), "dd'/'MM'/'yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                    String dateSQL = row["fecha_salida"].ToString();
                    
                    //string x = dt.ToString("yyyy-MM-dd");
                    //string x = dt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    DateTime departureDate = DateTime.Parse(row["fecha_salida"].ToString(), CultureInfo.CreateSpecificCulture("en-US"));
                    String departureDateString = departureDate.ToString("yyy-MM-yy");
                    TextBoxDepartureDate.Text = departureDateString;
                    DateTime returnDate = DateTime.Parse(row["fecha_retorno"].ToString(), CultureInfo.CreateSpecificCulture("en-US"));
                    String returnDateString = returnDate.ToString("yyy-MM-yy");
                    TextBoxReturnDate.Text = returnDateString;
                    */
                    TextBoxCodeControl.Text = codeControl;
                    TextBoxDepartureDate.Text = row["salida"].ToString();
                    TextBoxReturnDate.Text = row["retorno"].ToString();
                    TextBoxInitialState.Text = row["estado_inicial_vehiculo"].ToString();
                    TextBoxFinalState.Text = row["estado_final_vehiculo"].ToString();
                    TextBoxCarRegistration.Text = row["matricula"].ToString();
                    TextBoxInitialMileage.Text = row["kilometraje_inicial"].ToString();
                    TextBoxFinalMileage.Text = row["kilometraje_final"].ToString();
                    radioButtonVehicleAvailability.SelectedValue = row["disponibilidad_vehiculo"].ToString();
                    TextBoxDPI.Text = row["dpi"].ToString();
                }

                //Poner el codigo Temporal a la sesion
                Session.Add("code_control", codeControl);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Error', '" + ex.Message + "')", true);
            }


        }
    }
}