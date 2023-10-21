<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Administrator.Master" AutoEventWireup="true" CodeBehind="DriveHistory.aspx.cs" Inherits="Parcial3.Administrator.DriveHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mt-5">
            <div class="col-lg-3 col-md-9">
                <div class="w-100 d-flex flex-column align-items-center justify-content-around">
                    <div class="text-align-center mb-4">
                        <h6 class="display-6">Registar Historial Conduccion</h6>
                    </div>
                    <div class="row mb-2">
                        <div class="d-flex justify-content-evenly">
                            <div class="form-floating">
                                <asp:TextBox ReadOnly="true" required="" ID="TextBoxCodeControl" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                <asp:Label CssClass="m-1" AssociatedControlID="TextBoxCodeControl" ID="LabelTextBoxCodeControl" runat="server" Text="Codigo de Control"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-2">
                        <div class="d-flex justify-content-center">
                            <div class="form-floating m-1">
                                <asp:TextBox required="" ID="TextBoxDepartureDate" TextMode="Date" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                <asp:Label CssClass="m-1" AssociatedControlID="TextBoxDepartureDate" ID="LabelTextBoxDepartureDate" runat="server" Text="Fecha de Salida"></asp:Label>
                            </div>
                            <div class="form-floating m-1">
                                <asp:TextBox ID="TextBoxReturnDate" TextMode="Date" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                <asp:Label CssClass="m-1" AssociatedControlID="TextBoxReturnDate" ID="LabelTextBoxReturnDate" runat="server" Text="Fecha de Retorno"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-2">
                        <div class="d-flex justify-content-center">
                            <div class="form-floating m-1">
                                <asp:TextBox required="true" TextMode="MultiLine" ID="TextBoxInitialState" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                <asp:Label CssClass="m-1 p-1" AssociatedControlID="TextBoxInitialState" ID="LabelTextBoxInitialState" runat="server" Text="Estado Inicial"></asp:Label>
                            </div>
                            <div class="form-floating m-1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBoxFinalState" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                <asp:Label CssClass="m-1 p-1" AssociatedControlID="TextBoxFinalState" ID="LabelTextBoxFinalState" runat="server" Text="Estado Final"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-2">
                        <div class="form-floating">
                            <asp:TextBox required="true" ID="TextBoxCarRegistration" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                            <asp:Label CssClass="m-1" AssociatedControlID="TextBoxCarRegistration" ID="LabelTextBoxCarRegistration" runat="server" Text="Matricula"></asp:Label>
                        </div>
                    </div>
                    <div class="row mb-2">
                        <div class="d-flex justify-content-center">
                            <div class="form-floating m-1">
                                <asp:TextBox required="true" TextMode="Number" ID="TextBoxInitialMileage" CssClass="form-control m-1" placeholder="" runat="server"></asp:TextBox>
                                <asp:Label CssClass="m-1" AssociatedControlID="TextBoxInitialMileage" ID="LabelTextBoxInitialMileage" runat="server" Text="Kilometraje Inicial"></asp:Label>
                            </div>
                            <div class="form-floating m-1">
                                <asp:TextBox  TextMode="Number" ID="TextBoxFinalMileage" CssClass="form-control m-1" placeholder="" runat="server"></asp:TextBox>
                                <asp:Label CssClass="m-1" AssociatedControlID="TextBoxFinalMileage" ID="LabelTextBoxFinalMileage" runat="server" Text="Kilometraje Final"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-2">
                        <div class="d-flex parent">
                            <asp:Label CssClass="mr-auto m-1 left" AssociatedControlID="radioButtonVehicleAvailability" ID="LabelradioButtonVehicleAvailability" runat="server" Text="Disponiblidad: "></asp:Label>
                            <asp:RadioButtonList CssClass="p-2 mr-auto" CellPadding="5" ID="radioButtonVehicleAvailability" RepeatDirection="Vertical" required="true" runat="server">
                                <asp:ListItem Text="Disponible" Value="True"></asp:ListItem>
                                <asp:ListItem Text="No Disponible" Value="False"></asp:ListItem>
                            </asp:RadioButtonList>
                            <div class="right"></div>
                        </div>
                    </div>
                    <div class="row mb-2">
                        <div class="form-floating col-sm-12">
                            <asp:TextBox required="true" ID="TextBoxDPI" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                            <asp:Label CssClass="m-1" AssociatedControlID="TextBoxDPI" ID="LabelTextBoxDPI" runat="server" Text="DPI Conductor"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-2 col-md-3 col-s-12">
                <div class="row text-center">
                    <div class="col-lg-12 mb-2">
                        <asp:Button ID="ButtonRegister" CssClass="btn btn-success w-100" runat="server" Text="Registrar" OnClick="ButtonRegister_Click" />
                    </div>
                    <div class="col-lg-12 mb-2">
                        <asp:Button ID="ButtonEdit" CssClass="btn btn-warning w-100" runat="server" Text="Editar" OnClick="ButtonEdit_Click" />
                    </div>
                    <div class="col-lg-12 mb-2">
                        <asp:Button ID="ButtonDelete" CssClass="btn btn-danger w-100" runat="server" Text="Eliminar" OnClick="ButtonDelete_Click" />
                    </div>
                </div>
            </div>
            <div class="col-lg-7 col-md-12 col-s-12">
                <div class="table-responsive">
                    <div class="row mb-1">
                        <div class="d-flex justify-content-center">
                            <div class="p-2">
                                <asp:Label runat="server" Text="Filtrar:"></asp:Label>
                            </div>
                            <div class="p-2">
                                <asp:TextBox CssClass="form-control" ID="TextBoxFilter" runat="server"></asp:TextBox>
                            </div>
                            <div class="ml-auto p-2">
                                <asp:Button ID="ButtonFilter" CssClass="btn btn-outline-primary" runat="server" Text="Filtrar"></asp:Button>
                            </div>
                        </div>
                    </div>
                    <asp:GridView ID="GVDriveHistory" CssClass="table table-bordered table-condensed table-responsive table-hover center-grid" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnRowCommand="GVDriveHistory_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="codigo_control" HeaderText="Codigo de Control" SortExpression="codigo_control"></asp:BoundField>
                            <asp:TemplateField HeaderText="Fecha de Salida">
                                <EditItemTemplate>
                                    <asp:Label ID="LabelDepartureDate" runat="server" Text='<%# Bind("fecha_salida") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelShowLabelDepartureDate" runat="server" Text='<%# GetFormatStringFromCodeBehind(    Eval("fecha_salida")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha de Retorno">
                                <EditItemTemplate>
                                    <asp:Label ID="LabelReturnDate" runat="server" Text='<%# Bind("fecha_retorno") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="ShowLabelReturnDate" runat="server" Text='<%# GetFormatStringFromCodeBehind(    Eval("fecha_retorno")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="estado_inicial_vehiculo" HeaderText="Estado Inicial" SortExpression="estado_inicial_vehiculo"></asp:BoundField>
                            <asp:BoundField DataField="estado_final_vehiculo" HeaderText="Estado Final" SortExpression="estado_final_vehiculo"></asp:BoundField>
                            <asp:BoundField DataField="matricula" HeaderStyle-CssClass="justify-content-center" HeaderText="Matricula" SortExpression="matricula"></asp:BoundField>
                            <asp:BoundField DataField="kilometraje_inicial" HeaderText="Kilometraje Inicial" SortExpression="kilometraje_inicial"></asp:BoundField>
                            <asp:BoundField DataField="kilometraje_final" HeaderText="Kilometraje Final" SortExpression="kilometraje_final"></asp:BoundField>
                            <asp:TemplateField HeaderText="Disponibilidad Vehiculo">
                                <EditItemTemplate>
                                    <asp:Label ID="LabelAvalability" runat="server" Text='<%# Bind("disponibilidad_vehiculo") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelShowAvalability" runat="server" Text='<%# Eval("disponibilidad_vehiculo").ToString() == "True" ? "Disponible" : "No Disponible" %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="dpi" HeaderText="DPI" SortExpression="dpi"></asp:BoundField>
                            <asp:BoundField DataField="nombre_camionero" HeaderText="Nombre de Camionero" SortExpression="nombre_camionero"></asp:BoundField>
                            <asp:ButtonField Text="Seleccionar" ControlStyle-CssClass="btn btn-info" ButtonType="Button"></asp:ButtonField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
