<%@ Page Title="<%$ Resources:Language, LABEL_PEOPLE %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WEB.Module.People.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageSpecificCSSStyles" runat="server">
    <link rel="stylesheet" href="../../Content/assets/data-tables/DT_bootstrap.css">
    <link rel="stylesheet" href="../../Content/assets/gritter/css/jquery.gritter.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1><i class="icon-file-alt"></i><%: Title %></h1>
    <h4>
        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Language, LABEL_PEOPLE_DESCRIPTION %>" />
    </h4>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Breadcrumb" runat="server">
    <li>
        <i class="icon-home"></i>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/" Text="<%$ Resources:Language, LABEL_DASHBOARD %>"></asp:HyperLink>
        <span class="divider"><i class="icon-angle-right"></i></span>
    </li>
    <li>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Module/" Text="<%$ Resources:Language, LABEL_MODULE %>"></asp:HyperLink>
        <span class="divider"><i class="icon-angle-right"></i></span>
    </li>
    <li class="active"><%: Title %></li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Tiles" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <div class="box">
                <div class="box-title">
                    <h3><i class="icon-reorder"></i>
                        <asp:Literal ID="LTDetails" runat="server" Text="<%$ Resources:Language, LABEL_PEOPLE_DETAILS %>"></asp:Literal></h3>
                </div>
                <div class="box-content">
                    <div class="btn-toolbar pull-right clearfix">
                        <div class="btn-group">
                            <a id="A1" class="btn btn-circle show-tooltip" runat="server" title="<%$ Resources:Language, LABEL_ADD_NEW_RECORD %>" href="#"><i class="icon-plus"></i></a>
                            <a id="A2" data-original-title="<%$ Resources:Language, LABEL_REPORT %>" runat="server" class="btn btn-circle show-tooltip" title="" href="#" target="_blank"><i class="icon-file-text-alt"></i></a>
                        </div>
                        <div class="btn-group">
                            <a id="A3" class="btn btn-circle show-tooltip" runat="server" title="<%$ Resources:Language, LABEL_REFRESH %>" href="?Refresh"><i class="icon-repeat"></i></a>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <HeaderTemplate>
                            <table class="table table-advance" id="table1">
                                <thead>
                                    <tr>
                                        <th style="width: 18px">
                                            <input type="checkbox" /></th>
                                        <th>
                                            <asp:Label ID="LPersonId" runat="server" Text="<%$ Resources:Language, LABEL_PERSON_ID %>"></asp:Label></th>
                                        <th>
                                            <asp:Label ID="LPersonName" runat="server" Text="<%$ Resources:Language, LABEL_PERSON_NAME %>"></asp:Label></th>
                                        <th>
                                            <asp:Label ID="LPersonLastName" runat="server" Text="<%$ Resources:Language, LABEL_PERSON_LASTNAME %>"></asp:Label></th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <input type="checkbox" />
                                </td>
                                <td>
                                    <asp:Literal ID="LTPersonId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="LTPersonName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Name") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="LTPersonLastName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"LastName") %>'></asp:Literal>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr>
                                <td>
                                    <input type="checkbox" />
                                </td>
                                <td>
                                    <asp:Literal ID="LTPersonId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Id") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="LTPersonName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Name") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="LTPersonLastName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"LastName") %>'></asp:Literal>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Modals" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="PageSpecificPluginScripts" runat="server">
    <script src="<%=ResolveClientUrl("~/Content/assets/data-tables/jquery.dataTables.js")%>"></script>
    <script src="<%=ResolveClientUrl("~/Content/assets/data-tables/DT_bootstrap.js")%>"></script>
    <script src="<%=ResolveClientUrl("~/Content/assets/gritter/js/jquery.gritter.js")%>"></script>
</asp:Content>
