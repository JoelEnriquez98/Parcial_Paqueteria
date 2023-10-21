<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/Administrator.Master" AutoEventWireup="true" CodeBehind="MainAdmin.aspx.cs" Inherits="Parcial3.Admin.MainAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div id="demo" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#demo" data-bs-slide-to="0" class="active"></button>
                <button type="button" data-bs-target="#demo" data-bs-slide-to="1"></button>
                <button type="button" data-bs-target="#demo" data-bs-slide-to="2"></button>
                <button type="button" data-bs-target="#demo" data-bs-slide-to="3"></button>
                <button type="button" data-bs-target="#demo" data-bs-slide-to="4"></button>
            </div>

            <!-- The slideshow/carousel -->
            <div class="carousel-inner size">
                <div class="carousel-item active">
                    <img src="../Files/Images/img1.png"  alt="Los Angeles" class="d-block w-100">
                </div>
                <div class="carousel-item">
                    <img src="../Files/Images/img2.jpg" alt="Chicago" class="d-block w-100">
                </div>
                <div class="carousel-item">
                    <img src="../Files/Images/img3.jpg" alt="New York" class="d-block w-100">
                </div>
                <div class="carousel-item">
                    <img src="../Files/Images/img4.png"  alt="New York" class="d-block w-100">
                </div>
                <div class="carousel-item">
                    <img src="../Files/Images/img5.jpg"  alt="New York" class="d-block w-100">
                </div>
            </div>

            <button class="carousel-control-prev" type="button" data-bs-target="#demo" data-bs-slide="prev">
                <span class="carousel-control-prev-icon"></span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#demo" data-bs-slide="next">
                <span class="carousel-control-next-icon"></span>
            </button>
        </div>
    </div>
</asp:Content>
