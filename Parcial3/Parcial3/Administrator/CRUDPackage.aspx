<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Administrator.Master" AutoEventWireup="true" CodeBehind="CRUDPackage.aspx.cs" Inherits="Parcial3.Administrator.CRUDPackage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mt-5">
            <div class="col-lg-3 col-md-9">
                <div class="w-100 d-flex flex-column align-items-center justify-content-around">
                    <div class="text-align-center mb-3">
                        <h6 class="display-6 text-center">Registrar/Editar Paquetes</h6>
                    </div>
                    <div class="row mb-2">
                        <div class="d-flex flex-lg-row justify-content-evenly">
                            <div class="form-floating  m-1">
                                <asp:TextBox required="" ID="TextBoxCodePackage" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                <asp:Label CssClass="m-1" AssociatedControlID="TextBoxCodePackage" ID="LabelTextBoxCodePackage" runat="server" Text="Codigo"></asp:Label>
                            </div>
                            <div class="form-floating  m-1">
                                <asp:TextBox TextMode="MultiLine" required="true" ID="TextBoxDescription" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                <asp:Label CssClass="m-1" AssociatedControlID="TextBoxDescription" ID="LabelTextBoxDescription" runat="server" Text="Descripcion"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-2">
                        <div class="d-flex flex-lg-row justify-content-evenly">
                            <div class="form-floating  m-1">
                                <asp:TextBox required="true" ID="TextBoxTypePackage" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                <asp:Label CssClass="m-1" AssociatedControlID="TextBoxTypePackage" ID="LabelTextBoxTypePackage" runat="server" Text="Tipo de Paquete"></asp:Label>
                            </div>
                            <div class="form-floating  m-1">
                                <asp:TextBox required="true" TextMode="Number" ID="TextBoxWeight" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                <asp:Label CssClass="m-1" AssociatedControlID="TextBoxWeight" ID="LabelTextBoxWeight" runat="server" Text="Peso"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row mb-2">
                        <div class="d-flex flex-lg-row justify-content-evenly">
                            <div class="form-floating  m-1">
                                <asp:TextBox required="true" TextMode="Number" ID="TextBoxCodeAddressee" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                <asp:Label CssClass="m-1 p-1" AssociatedControlID="TextBoxCodeAddressee" ID="LabelTextBoxCodeAddressee" runat="server" Text="Codigo Destinatario"></asp:Label>
                            </div>
                            <div class="form-floating m-1">
                                <asp:TextBox required="true" TextMode="Number" ID="TextBoxCodeHistory" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                <asp:Label CssClass="m-1 p-1" AssociatedControlID="TextBoxCodeHistory" ID="LabelTextBoxCodeHistory" runat="server" Text="Codigo Control"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-2 col-md-3 col-sm-12">
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
            <div class="col-lg-7 col-md-12 col-sm-12 col-">
                <div class="table-responsive overflow">
                    <asp:GridView ID="GVPackages" CssClass="table table-bordered table-condensed table-responsive table-hover" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnRowCommand="GVPackages_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="codigo_paquete" HeaderText="Codigo" SortExpression="codigo_paquete"></asp:BoundField>
                            <asp:BoundField DataField="descripcion_paquete" HeaderText="Descripcion" SortExpression="descripcion_paquete"></asp:BoundField>
                            <asp:BoundField DataField="tipo_paquete" HeaderText="Tipo Paquete" SortExpression="tipo_paquete"></asp:BoundField>
                            <asp:BoundField DataField="peso_paquete" HeaderText="Peso" SortExpression="peso_paquete"></asp:BoundField>
                            <asp:BoundField DataField="nombre_destinatario" HeaderText="Nombre Destinatario" SortExpression="nombre_destinatario"></asp:BoundField>
                            <asp:BoundField DataField="direccion_destinatario" HeaderText="Direccion" SortExpression="direccion_destinatario"></asp:BoundField>
                            <asp:BoundField DataField="referencia_destinario" HeaderText="Referencia" SortExpression="referencia_destinario"></asp:BoundField>
                            <asp:BoundField DataField="nombre_depto" HeaderText="Departamento" SortExpression="nombre_depto"></asp:BoundField>
                            <asp:BoundField DataField="nombre_municipio" HeaderText="Municipio" SortExpression="nombre_municipio"></asp:BoundField>
                            <asp:BoundField DataField="codigo_control" HeaderText="Codigo Control" SortExpression="codigo_control"></asp:BoundField>
                            <asp:ButtonField Text="Seleccionar" ControlStyle-CssClass="btn btn-info" ButtonType="Button"></asp:ButtonField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
