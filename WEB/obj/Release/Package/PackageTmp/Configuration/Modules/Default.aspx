<%@ Page Title="<%$ Resources:Language, LABEL_MODULES %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WEB.Configuration.Modules.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageSpecificCSSStyles" runat="server">
    <link rel="stylesheet" href="../../Content/assets/data-tables/DT_bootstrap.css">
    <link rel="stylesheet" href="../../Content/assets/gritter/css/jquery.gritter.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1><i class="icon-file-alt"></i><%: Title %></h1>
    <h4>
        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Language, LABEL_MODULE_DESCRIPTION %>" />
    </h4>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Breadcrumb" runat="server">
    <li>
        <i class="icon-home"></i>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/" Text="<%$ Resources:Language, LABEL_DASHBOARD %>"></asp:HyperLink>
        <span class="divider"><i class="icon-angle-right"></i></span>
    </li>
    <li>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Configuration/" Text="<%$ Resources:Language, LABEL_CONFIGURATION %>"></asp:HyperLink>
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
                        <asp:Literal ID="LTModuleDetails" runat="server" Text="<%$ Resources:Language, LABEL_MODULE_DETAILS %>"></asp:Literal></h3>
                </div>
                <div class="box-content">
                    <div class="btn-toolbar pull-right clearfix">
                        <div class="btn-group">
                            <a id="A1" class="btn btn-circle show-tooltip" runat="server" title="<%$ Resources:Language, LABEL_ADD_NEW_RECORD %>" href="#modal-1" data-toggle="modal"><i class="icon-plus"></i></a>
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
                                            <input type="checkbox" />
                                        </th>
                                        <th>
                                            <asp:Label ID="LModuleName" runat="server" Text="<%$ Resources:Language, LABEL_MODULE_NAME %>"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="LModuleDescription" runat="server" Text="<%$ Resources:Language, LABEL_DESCRIPTION %>"></asp:Label>
                                        </th>
                                        <th style="width: 50px">
                                            <asp:Label ID="LAction" runat="server" Text="<%$ Resources:Language, LABEL_ACTION %>"></asp:Label>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <input type="checkbox" /></td>
                                <td>
                                    <asp:Literal ID="LTModuleName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ModuleName") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="LTModuleDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ModuleDescription") %>'></asp:Literal>
                                </td>
                                <td>
                                    <div class="btn-group">
                                        <a id="A1" class="btn btn-small show-tooltip" runat="server" title="<%$ Resources:Language, LABEL_EDIT %>" href='<%# "Edit?Id=" + DataBinder.Eval(Container.DataItem,"ModuleId") %>'><i class="icon-edit"></i></a>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr>
                                <td>
                                    <input type="checkbox" /></td>
                                <td>
                                    <asp:Literal ID="LTModuleName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ModuleName") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="LTModuleDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ModuleDescription") %>'></asp:Literal>
                                </td>
                                <td>
                                    <div class="btn-group">
                                        <a id="A2" class="btn btn-small show-tooltip" runat="server" title="<%$ Resources:Language, LABEL_EDIT %>" href='<%# "Edit?Id=" + DataBinder.Eval(Container.DataItem,"ModuleId") %>'><i class="icon-edit"></i></a>
                                    </div>
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
    <div id="modal-1" class="modal hide" tabindex="-1" role="dialog" aria-labelledby="modalNewModule" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h3 id="modalNewModule">
                <asp:Literal ID="LTAddNewModule" runat="server" Text="<%$ Resources:Language, LABEL_ADD_NEW_MODULE %>"></asp:Literal></h3>
        </div>
        <div class="modal-body">
            <div class="box-content">
                <div class="form-horizontal">
                    <div class="control-group">
                        <asp:Label ID="LModuleName" CssClass="control-label" runat="server" Text="<%$ Resources:Language, LABEL_NAME %>"></asp:Label>
                        <div class="controls">
                            <asp:TextBox ID="TBModuleName" runat="server" CssClass="input-xlarge" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-error" ErrorMessage="<%$ Resources:Language, ERROR_FIELD_GENERIC %>" ControlToValidate="TBModuleName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="control-group">
                        <asp:Label ID="LBDescription" runat="server" CssClass="control-label" Text="<%$ Resources:Language, LABEL_DESCRIPTION %>"></asp:Label>
                        <div class="controls">
                            <asp:TextBox ID="TBModuleDescription" runat="server" CssClass="input-xlarge" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <button class="btn" data-dismiss="modal" aria-hidden="true">
                <asp:Label ID="LButtonClose" runat="server" Text="<%$ Resources:Language, BUTTON_CLOSE %>"></asp:Label></button>
            <asp:Button ID="BTAdd" runat="server" CssClass="btn btn-primary" Text="<%$ Resources:Language, BUTTON_ADD %>" OnClick="BTAdd_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="PageSpecificPluginScripts" runat="server">
    <script src="<%=ResolveClientUrl("~/Content/assets/data-tables/jquery.dataTables.js")%>"></script>
    <script src="<%=ResolveClientUrl("~/Content/assets/data-tables/DT_bootstrap.js")%>"></script>
    <script src="<%=ResolveClientUrl("~/Content/assets/gritter/js/jquery.gritter.js")%>"></script>
</asp:Content>
