<%@ Page Title="<%$ Resources:Language, LABEL_MODULES %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WEB.Module.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageSpecificCSSStyles" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1><i class="icon-file-alt"></i><%: Title %></h1>
    <h4>
        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Language, LABEL_MODULES_DESCRIPTION %>" />
    </h4>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Breadcrumb" runat="server">
    <li>
        <i class="icon-home"></i>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/" Text="<%$ Resources:Language, LABEL_DASHBOARD %>"></asp:HyperLink>
        <span class="divider"><i class="icon-angle-right"></i></span>
    </li>
    <li class="active"><%: Title %></li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Tiles" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <!-- BEGIN Simple Search Result -->
    <div class="row-fluid">
        <div class="span12">
            <div class="box">
                <div class="box-title">
                    <h3><i class="icon-puzzle-piece"></i>
                        <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Language, LABEL_LIST_MODULES %>"></asp:Literal></h3>
                    <div class="box-tool">
                        <a data-action="collapse" href="#"><i class="icon-chevron-up"></i></a>
                        <a data-action="close" href="#"><i class="icon-remove"></i></a>
                    </div>
                </div>
                <div class="box-content">
                    <div class="search-results search-results-simple">
                        <ul class="clearfix">
                            <li>
                                <div class="info">
                                    <a href="../../DMS/Module/DataLoad/">
                                        <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:Language, LABEL_DATALOAD %>"></asp:Literal></a>
                                    <p class="url">Module/DataLoad</p>
                                    <p>
                                        <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:Language, LABEL_DATALOAD_LONG_DESCRIPTION %>"></asp:Literal>
                                    </p>
                                </div>
                            </li>
                        </ul>
                    </div>
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
                    <!-- END Simple Search Result -->
                    <div class="pagination text-center">
                        <ul>
                            <li class="disabled"><a href="#"><i class="icon-double-angle-left"></i></a></li>
                            <li class="active"><a href="#">1</a></li>
                            <li><a href="#"><i class="icon-double-angle-right"></i></a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
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
