<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WEB.Account.Login" %>

<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!-->
<html class="no-js">
<!--<![endif]-->
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title><%: System.Web.Configuration.WebConfigurationManager.AppSettings["CompanyName"] %></title>
    <meta name="viewport" content="width=device-width">

    <!-- Place favicon.ico and apple-touch-icon.png in the root directory -->

    <!--base css styles-->
    <link rel="stylesheet" href="../Content/assets/bootstrap/bootstrap.min.css">
    <link rel="stylesheet" href="../Content/assets/bootstrap/bootstrap-responsive.min.css">
    <link rel="stylesheet" href="../Content/assets/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="../Content/assets/normalize/normalize.css">

    <!--page specific css styles-->

    <!--flaty css styles-->
    <link rel="stylesheet" href="../Content/css/flaty.css">
    <link rel="stylesheet" href="../Content/css/flaty-responsive.css">

    <link href="~/Content/favicon.ico" rel="shortcut icon" type="image/x-icon" />

    <script src="<%=ResolveClientUrl("../Content/assets/modernizr/modernizr-2.6.2.min.js")%>"></script>
</head>
<body class="login-page">
    <!--[if lt IE 7]>
            <p class="chromeframe">You are using an <strong>outdated</strong> browser. Please <a href="http://browsehappy.com/">upgrade your browser</a> or <a href="http://www.google.com/chromeframe/?redirect=true">activate Google Chrome Frame</a> to improve your experience.</p>
        <![endif]-->

    <!-- BEGIN Main Content -->
    <div class="login-wrapper">
        <!-- BEGIN Login Form -->
        <form id="formLogin" runat="server">
            <div class="logo">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/img/logo.jpg" ImageAlign="Middle" AlternateText="FONT Sistemas" />
            </div>
            <hr />
            <asp:Login ID="Login1" runat="server" ViewStateMode="Disabled" RenderOuterTable="false" DestinationPageUrl="~/" OnAuthenticate="Login1_Authenticate">
                <LayoutTemplate>
                    <p class="text-error">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                    <div class="control-group">
                        <div class="controls">
                            <asp:TextBox runat="server" ID="UserName" CssClass="input-block-level" placeholder="<%$ Resources:Language, LABEL_USER %>" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName" CssClass="text-error" ErrorMessage="The user name field is required." />
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="input-block-level" placeholder="<%$ Resources:Language, LABEL_PASSWORD %>" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password" CssClass="text-error" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <asp:Label ID="Label1" runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" Text="<%$ Resources:Language, LABEL_REMEMBER %>" />
                            </asp:Label>
                        </div>
                    </div>
                    <br />
                    <div class="control-group">
                        <div class="controls">
                            <asp:Button ID="Button1" runat="server" CommandName="Login" Text="<%$ Resources:Language, BUTTON_LOGIN %>" Width="100%" Height="50px" BackColor="#241F3F" BorderColor="#19132F" BorderStyle="Solid" BorderWidth="1px" Font-Size="Medium" ForeColor="White"/>
                        </div>
                    </div>
                </LayoutTemplate>
            </asp:Login>
        </form>
        <!-- END Login Form -->
    </div>
    <!-- END Main Content -->

    <!--bottom of page scripts-->
    <script src="<%=ResolveClientUrl("~/Content/assets/jquery/jquery-1.10.1.min.js")%>"></script>
    <script src="<%=ResolveClientUrl("~/Content/assets/bootstrap/bootstrap.min.js")%>"></script>
    <script src="<%=ResolveClientUrl("~/Content/assets/nicescroll/jquery.nicescroll.min.js")%>"></script>
    <script src="<%=ResolveClientUrl("~/Content/assets/jquery-cookie/jquery.cookie.js")%>"></script>

    <!--page specific plugin scripts-->

    <!--flaty scripts-->
    <script src="<%=ResolveClientUrl("~/Content/js/flaty.js")%>"></script>
</body>
</html>

