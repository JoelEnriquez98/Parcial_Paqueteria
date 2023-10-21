<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Administrator.Master" AutoEventWireup="true" CodeBehind="CRUDTRucker.aspx.cs" Inherits="Parcial3.Administrator.AddEditTrucker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mt-5">
            <div class="col-lg-4 col-md-9">
                <div class="w-100 d-flex flex-column align-items-center justify-content-around">
                    <div class="text-align-center mb-4">
                        <h6 class="display-6">Registrar Camioneros</h6>
                    </div>
                    <div class="row mb-4">
                        <div class="form-floating">
                            <asp:TextBox required="" ID="TextBoxRegisterDPI" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                            <asp:Label CssClass="m-1" AssociatedControlID="TextBoxRegisterDPI" ID="LabelTextBoxRegisterDPI" runat="server" Text="DPI"></asp:Label>
                            <div class="invalid-feedback">
                                Porfavor ingresa un DPI Valido
                            </div>
                        </div>
                    </div>
                    <div class="row mb-4">
                        <div class="form-floating">
                            <asp:TextBox required="true" ID="TextBoxRegisterName" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                            <asp:Label CssClass="m-1" AssociatedControlID="TextBoxRegisterName" ID="LabelTextBoxRegisterName" runat="server" Text="Nombre"></asp:Label>
                        </div>
                    </div>
                    <div class="row mb-4">
                        <div class="form-floating">
                            <asp:TextBox required="true" ID="TextBoxRegisterPhone" CssClass="form-control" TextMode="Number" placeholder="" runat="server"></asp:TextBox>
                            <asp:Label CssClass="m-1" AssociatedControlID="TextBoxRegisterPhone" ID="LabelTextBoxRegisterPhone" runat="server" Text="Numero telefonico"></asp:Label>
                        </div>
                    </div>
                    <div class="row mb-4">
                        <div class="form-floating">
                            <asp:TextBox required="true" ID="TextBoxAddress" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                            <asp:Label CssClass="m-1" AssociatedControlID="TextBoxAddress" ID="LabelTextBoxAddress" runat="server" Text="Direccion"></asp:Label>
                        </div>
                    </div>
                    <div class="row mb-4">
                        <div class="form-floating col-sm-12">
                            <asp:TextBox required="true" TextMode="Number" ID="TextBoxSalary" CssClass="form-control" placeholder="Q" runat="server"></asp:TextBox>
                            <asp:Label CssClass="m-1" AssociatedControlID="TextBoxSalary" ID="LabelTextBoxSalary" runat="server" Text="Salario"></asp:Label>
                        </div>
                    </div>
                    <div class="row mb-4">
                        <div class="col-lg-6 col-sm-12">
                            <div class="form-outline form-floating">
                                <asp:DropDownList ID="DropDownDepartments" CssClass="form-control form-control-lg" runat="server" AutoPostBack="true" placeholder="" OnSelectedIndexChanged="DropDownDepartments_SelectedIndexChanged"></asp:DropDownList>
                                <asp:Label ID="LabelDepartment" AssociatedControlID="DropDownDepartments" CssClass="form-label" runat="server" Text="Departamento"></asp:Label>
                            </div>
                        </div>
                        <div class="col-lg-6 col-sm-12">
                            <div class="form-outline form-floating">
                                <asp:DropDownList ID="DropDownCity" CssClass="form-control form-control-lg" runat="server" AutoPostBack="true" placeholder="" OnSelectedIndexChanged="DropDownCity_SelectedIndexChanged"></asp:DropDownList>
                                <asp:Label ID="LabelTownCode" AssociatedControlID="DropDownCity" CssClass="form-label" runat="server" Text="Municipio"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-4">
                        <div class="col-lg-12 col-sm-12">
                            <div class="form-outline form-floating">
                                <asp:DropDownList ID="DropDownVillage" CssClass="form-control form-control-lg" runat="server" placeholder=""></asp:DropDownList>
                                <asp:Label ID="LabelDropDownVillage" AssociatedControlID="DropDownVillage" CssClass="form-label" runat="server" Text="Aldea"></asp:Label>
                            </div>
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
            <div class="col-lg-6 col-md-12 col-s-12">
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
                    <asp:GridView ID="GVTruckers" CssClass="table table-bordered table-condensed table-responsive table-hover" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnRowCommand="GVTruckers_RowCommand" OnSelectedIndexChanged="GVCostumers_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="dpi" HeaderText="DPI" SortExpression="dpi"></asp:BoundField>
                            <asp:BoundField DataField="nombre_camionero" HeaderText="Nombre" SortExpression="nombre_camionero"></asp:BoundField>
                            <asp:BoundField DataField="telefono_camionero" HeaderText="Telefono" SortExpression="telefono_camionero"></asp:BoundField>
                            <asp:BoundField DataField="direccion_camionero" HeaderText="Direccion" SortExpression="direccion_camionero"></asp:BoundField>
                            <asp:BoundField DataField="salario_camionero" HeaderText="Salario" SortExpression="salario_camionero"></asp:BoundField>
                            <asp:BoundField DataField="nombre_depto" HeaderText="Departamento" SortExpression="nombre_depto"></asp:BoundField>
                            <asp:BoundField DataField="nombre_municipio" HeaderText="Municipio" SortExpression="nombre_municipio"></asp:BoundField>
                            <asp:BoundField DataField="nombre_aldea" HeaderText="Aldea" SortExpression="nombre_aldea"></asp:BoundField>
                            <asp:ButtonField Text="Seleccionar" ControlStyle-CssClass="btn btn-info" ButtonType="Button"></asp:ButtonField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
