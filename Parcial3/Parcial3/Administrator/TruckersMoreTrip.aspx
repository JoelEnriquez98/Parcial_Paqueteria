<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Administrator.Master" AutoEventWireup="true" CodeBehind="TruckersMoreTrip.aspx.cs" Inherits="Parcial3.Administrator.TruckersMoreTrip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container vh-100">
        <div class="row mt-5">
            <div class="col-lg-4 col-md-9">
                <div class="w-100 d-flex flex-column align-items-center justify-content-around">
                    <div class="text-align-center mb-4">
                        <h6 class="display-6">Registrar Camiones</h6>
                    </div>
                    <div class="row mb-4">
                        <div class="form-floating">
                            <asp:TextBox required="" ID="TextBoxMatricula" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                            <asp:Label CssClass="m-1" AssociatedControlID="TextBoxMatricula" ID="LabelTextBoxMatricula" runat="server" Text="Matricula"></asp:Label>
                            <div class="invalid-feedback">
                                Porfavor ingresa una Matricula Valida
                            </div>
                        </div>
                    </div>
                    <div class="row mb-4">
                        <div class="col-lg-6 col-sm-12">
                            <div class="form-outline form-floating">
                                <asp:DropDownList ID="DropDownModel" CssClass="form-control form-control-lg" runat="server" placeholder=""></asp:DropDownList>
                                <asp:Label ID="LabelDropDownModel" AssociatedControlID="DropDownModel" CssClass="form-label" runat="server" Text="Modelo"></asp:Label>
                            </div>
                        </div>
                        <div class="col-lg-6 col-sm-12">
                            <div class="form-outline form-floating">
                                <asp:DropDownList ID="DropDownType" CssClass="form-control form-control-lg" runat="server" placeholder="" OnSelectedIndexChanged="DropDownType_SelectedIndexChanged"></asp:DropDownList>
                                <asp:Label ID="LabelDropDownType" AssociatedControlID="DropDownType" CssClass="form-label" runat="server" Text="Tipo"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-4">
                        <div class="col-lg-6 col-sm-12">
                            <div class="form-outline form-floating">
                                <asp:DropDownList ID="DropDownBranch" CssClass="form-control form-control-lg" runat="server" AutoPostBack="true" placeholder="" OnSelectedIndexChanged="DropDownBranch_SelectedIndexChanged"></asp:DropDownList>
                                <asp:Label ID="LabelDropDownBranch" AssociatedControlID="DropDownBranch" CssClass="form-label" runat="server" Text="Marca"></asp:Label>
                            </div>
                        </div>
                        <div class="col-lg-6 col-sm-12">
                            <div class="form-outline form-floating">
                                <asp:DropDownList ID="DropDownListLine" CssClass="form-control form-control-lg" runat="server" placeholder=""></asp:DropDownList>
                                <asp:Label ID="LabelDropDownListLine" AssociatedControlID="DropDownListLine" CssClass="form-label" runat="server" Text="Linea"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-4">
                        <div class="col-lg-12 col-sm-12">
                            <div class="form-outline form-floating">
                                <asp:DropDownList ID="DropDownState" CssClass="form-control form-control-lg" runat="server" placeholder=""></asp:DropDownList>
                                <asp:Label ID="LabelDropDownState" AssociatedControlID="DropDownState" CssClass="form-label" runat="server" Text="Estado"></asp:Label>
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
                <div class="table-responsive overflow">
                    <asp:GridView ID="GVTruck" CssClass="table table-bordered table-condensed table-responsive table-hover" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnRowCommand="GVTruck_RowCommand">
                        <columns>
                            <asp:BoundField DataField="matricula" HeaderText="Matricula" SortExpression="matricula"></asp:BoundField>
                            <asp:BoundField DataField="nombre_modelo" HeaderText="Modelo" SortExpression="nombre_modelo"></asp:BoundField>
                            <asp:BoundField DataField="nombre_tipo" HeaderText="Tipo" SortExpression="nombre_tipo"></asp:BoundField>
                            <asp:BoundField DataField="detalle_tipo" HeaderText="Detalle" SortExpression="detalle_tipo"></asp:BoundField>
                            <asp:BoundField DataField="potencia_tipo" HeaderText="Potencia (HP)" SortExpression="potencia_tipo"></asp:BoundField>
                            <asp:BoundField DataField="nombre_linea" HeaderText="Linea" SortExpression="nombre_linea"></asp:BoundField>
                            <asp:BoundField DataField="nombre_marca" HeaderText="Marca" SortExpression="nombre_marca"></asp:BoundField>
                            <asp:BoundField DataField="nombre_estado" HeaderText="Estado" SortExpression="nombre_estado"></asp:BoundField>
                            <asp:ButtonField Text="Seleccionar" ControlStyle-CssClass="btn btn-info" ButtonType="Button"></asp:ButtonField>
                        </columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
