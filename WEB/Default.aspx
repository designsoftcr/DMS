<%@ Page Title="<%$ Resources:Language, LABEL_DASHBOARD %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WEB.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageSpecificCSSStyles" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1><i class="icon-file-alt"></i><%: Title %></h1>
    <h4>
        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Language, LABEL_DASHBOARD_DESCRIPTION%>" /></h4>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Breadcrumb" runat="server">
    <li class="active"><i class="icon-home"></i><%: Title %></li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Tiles" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <div class="row-fluid">
                <div class="span3">
                    <div class="row-fluid tiles-group">
                        <div class="span12 tile-active">
                            <a class="tile-logo" href="#">
                                <img src="../../DMS/Content/img/logo.png" />
                            </a>
                        </div>
                    </div>
                </div>
                <div class="span3">
                    <div class="row-fluid tiles-group">
                        <div class="span12 tile-active">
                            <a class="tile tile-fs-a" href="#modal-0" data-toggle="modal" data-stop="3000">
                                <div class="img img-center">
                                    <i class="icon-desktop"></i>
                                </div>
                                <p class="title text-center">
                                    <asp:Literal ID="LTCompanyDashboard" runat="server" Text="<%$ Resources:Language, LABEL_COMPANY %>"></asp:Literal>
                                </p>
                            </a>

                            <a class="tile tile-fs-b" href="#modal-0" data-toggle="modal">
                                <p class="title">
                                    <asp:Literal ID="LTCompany" runat="server" Text="<%$ Resources:Language, LABEL_COMPANY %>"></asp:Literal>
                                </p>
                                <p>
                                    <asp:Literal ID="LTCompaniesDashboardDescription" runat="server" Text="<%$ Resources:Language, LABEL_COMPANY_DASHBOAR_DESCRIPTION %>"></asp:Literal>
                                </p>
                                <div class="img img-bottom">
                                    <i class="icon-desktop"></i>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="span6">
                    <div class="row-fluid tiles-group">
                        <div class="span12 tile-active">
                            <asp:HyperLink ID="HLAccountSettings" runat="server" NavigateUrl="~/Account/Settings" CssClass="tile tile-fs-c" data-stop="19000">
                                <p class="title">
                                    <asp:Literal ID="LTAccountSettings" runat="server" Text="<%$ Resources:Language, LABEL_ACCOUNT_SETTINGS %>"></asp:Literal>
                                </p>
                                <p>
                                    <asp:Literal ID="LTAccountRecomendation" runat="server" Text="<%$ Resources:Language, LABEL_ACCOUNT_RECOMENDATION %>"></asp:Literal>
                                </p>
                                <div class="img img-bottom"><i class="icon-user"></i></div>
                            </asp:HyperLink>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Account/Settings" CssClass="tile tile-fs-c" data-stop="19000">
                                <p class="title">
                                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Language, LABEL_ACCOUNT_SETTINGS %>"></asp:Literal>
                                </p>
                                <p>
                                    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:Language, LABEL_ACCOUNT_RECOMENDATION %>"></asp:Literal>
                                </p>
                                <div class="img img-bottom"><i class="icon-user"></i></div>
                            </asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Modals" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="PageSpecificPluginScripts" runat="server">
</asp:Content>
