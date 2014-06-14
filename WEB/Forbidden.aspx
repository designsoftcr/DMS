<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forbidden.aspx.cs" Inherits="WEB.Forbidden" %>

<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!-->
<html class="no-js">
<!--<![endif]-->
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title><%: System.Web.Configuration.WebConfigurationManager.AppSettings["CompanyName"] %></title>
    <meta name="viewport" content="width=device-width">

    <!-- Place favicon.ico and apple-touch-icon.png in the root directory -->
    <link href="~/Content/favicon.ico" rel="shortcut icon" type="image/x-icon" />

    <!--base css styles-->
    <link rel="stylesheet" href="~/Content/assets/bootstrap/bootstrap.min.css">
    <link rel="stylesheet" href="~/Content/assets/bootstrap/bootstrap-responsive.min.css">
    <link rel="stylesheet" href="~/Content/assets/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="~/Content/assets/normalize/normalize.css">

    <!--page specific css styles-->

    <!--flaty css styles-->
    <link rel="stylesheet" href="~/Content/css/flaty.css">
    <link rel="stylesheet" href="~/Content/css/flaty-responsive.css">

    <script src="<%=ResolveClientUrl("~/Content/assets/modernizr/modernizr-2.6.2.min.js")%>"></script>
</head>
<body class="error-page">
    <!--[if lt IE 7]>
            <p class="chromeframe">You are using an <strong>outdated</strong> browser. Please <a href="http://browsehappy.com/">upgrade your browser</a> or <a href="http://www.google.com/chromeframe/?redirect=true">activate Google Chrome Frame</a> to improve your experience.</p>
        <![endif]-->
    <form id="Form1" runat="server">
        <!-- BEGIN Main Content -->
        <div class="error-wrapper">
            <h5><asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Language, LABEL_403_TITLE %>"></asp:Literal><span>403</span></h5>
            <p>
                <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Language, LABEL_403_MESSAGE_1 %>"></asp:Literal><br />
                <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:Language, LABEL_403_MESSAGE_2 %>"></asp:Literal> <%: System.Web.Configuration.WebConfigurationManager.AppSettings["CompanyName"] %>
            </p>
            <hr />
            <p class="clearfix">
                <a href="javascript:history.back()" class="pull-left"><asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:Language, LABEL_BACK_PREVIUS_PAGE %>"></asp:Literal></a>
                <a href="../../DMS/" class="pull-right"><asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:Language, LABEL_GO_TO_DASHOARD %>"></asp:Literal></a>
            </p>
        </div>
        <!-- END Main Content -->
    </form>
    <!--basic scripts-->
    <!--<script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.min.js"></script>-->
    <script>window.jQuery || document.write('<script src="<%=ResolveClientUrl("~/assets/jquery/jquery-1.10.1.min.js")%>"><\/script>')</script>
    <script src="<%=ResolveClientUrl("~/Content/assets/bootstrap/bootstrap.min.js")%>"></script>
</body>
</html>
