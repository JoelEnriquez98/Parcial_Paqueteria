<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Parcial3.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="Files/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Files/css/Styles.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/2b87f33b9b.js" crossorigin="anonymous"></script>
</head>
<body>
    <form id="formLogin" runat="server">
        <div class="container">
            <div class="vh-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                        <div class="card shadow-2-strong" style="border-radius: 1rem;">
                            <div class="card-body p-5 text-center">
                                <a href="#"><i class="fa-solid fa-truck fa-2xl size-logo"></i></a>
                                <div class="form-outline form-floating mb-4">
                                    <asp:TextBox required="true" ID="TBCode" CssClass="form-control form-control-lg" runat="server" placeholder=""></asp:TextBox>
                                    <asp:Label ID="LabelCode" AssociatedControlID="TBCode" CssClass="form-label" runat="server" Text="Codigo"></asp:Label>
                                </div>
                                <div class="form-outline form-floating mb-4">
                                    <asp:TextBox required="true" ID="TBPassword" TextMode="Password" placeholder="" CssClass="form-control  form-control-lg" runat="server"></asp:TextBox>
                                    <asp:Label ID="LabelPassword" AssociatedControlID="TBPassword" CssClass="form-label" runat="server" Text="Contraseña"></asp:Label>
                                </div>
                                <asp:Button ID="ButtonLogin" class="btn btn-primary btn-md btn-block" runat="server" Text="Login" OnClick="ButtonLogin_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="Files/js/bootstrap.bundle.min.js"></script>
</body>
</html>
