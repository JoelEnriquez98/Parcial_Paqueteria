<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Administrator.Master" AutoEventWireup="true" CodeBehind="CRUDAddressee.aspx.cs" Inherits="Parcial3.Administrator.CRUDAddressee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mt-5">
            <div class="col-lg-3 col-md-9">
                <div class="w-100 d-flex flex-column align-items-center justify-content-around">
                    <div class="text-align-center mb-4">
                        <h6 class="display-6 text-center">Registar/Editar Destinatario</h6>
                    </div>
                    <div class="row mb-2">
                        <div class="d-flex flex-lg-row justify-content-evenly">
                            <div class="form-floating m-1">
                                <asp:TextBox ReadOnly="true" required="" ID="TextBoxCode" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                <asp:Label CssClass="m-1" AssociatedControlID="TextBoxCode" ID="LabelTextBoxCode" runat="server" Text="Codigo"></asp:Label>
                            </div>
                            <div class="form-floating m-1">
                                <asp:TextBox required="" ID="TextBoxName" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                <asp:Label CssClass="m-1" AssociatedControlID="TextBoxName" ID="LabelTextBoxName" runat="server" Text="Nombre"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-2">
                        <div class="d-flex flex-lg-row justify-content-center">
                            <div class="form-floating m-1">
                                <asp:TextBox ID="TextBoxAddress" TextMode="MultiLine" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                <asp:Label CssClass="m-1" AssociatedControlID="TextBoxAddress" ID="LabelTextBoxAddress" runat="server" Text="Direccion"></asp:Label>
                            </div>
                            <div class="form-floating m-1">
                                <asp:TextBox required="true" TextMode="MultiLine" ID="TextBoxReference" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                <asp:Label CssClass="m-1 p-1" AssociatedControlID="TextBoxReference" ID="LabelTextBoxReference" runat="server" Text="Referencia"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-2">
                        <div class="d-flex flex-lg-row justify-content-center">
                            <div class="form-outline form-floating m-1">
                                <asp:DropDownList ID="DropDownDepartments" CssClass="form-control" runat="server" AutoPostBack="true" placeholder="" OnSelectedIndexChanged="DropDownDepartments_SelectedIndexChanged"></asp:DropDownList>
                                <asp:Label ID="LabelDepartment" AssociatedControlID="DropDownDepartments" CssClass="form-label" runat="server" Text="Departamento"></asp:Label>
                            </div>
                            <div class="form-outline form-floating m-1">
                                <asp:DropDownList ID="DropDownCity" CssClass="form-control" runat="server" AutoPostBack="true" placeholder="" OnSelectedIndexChanged="DropDownCity_SelectedIndexChanged"></asp:DropDownList>
                                <asp:Label ID="LabelTownCode" AssociatedControlID="DropDownCity" CssClass="form-label" runat="server" Text="Municipio"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-2">
                        <div class="form-outline form-floating">
                            <asp:DropDownList ID="DropDownVillage" CssClass="form-control form-control" runat="server" placeholder=""></asp:DropDownList>
                            <asp:Label ID="LabelDropDownVillage" AssociatedControlID="DropDownVillage" CssClass="form-label m-1" runat="server" Text="Aldea"></asp:Label>
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
                <div class="table-responsive overflow">
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
                    <asp:GridView ID="GVAddressee" CssClass="table table-bordered table-condensed table-responsive table-hover center-grid" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnRowCommand="GVAddressee_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="codigo_destinatario" HeaderText="Codigo" SortExpression="codigo_destinatario"></asp:BoundField>
                            <asp:BoundField DataField="nombre_destinatario" HeaderText="Nombre" SortExpression="nombre_destinatario"></asp:BoundField>
                            <asp:BoundField DataField="direccion_destinatario" HeaderText="Direccion" SortExpression="direccion_destinatario"></asp:BoundField>
                            <asp:BoundField DataField="referencia_destinario" HeaderText="Referencia" SortExpression="referencia_destinatario"></asp:BoundField>
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
