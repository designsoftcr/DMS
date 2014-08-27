<%@ Page Title="<%$ Resources:Language, LABEL_DATALOAD_PROFILES %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WEB.Module.DataLoad.Profiles.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageSpecificCSSStyles" runat="server">
    <link rel="stylesheet" href="../../../Content/assets/data-tables/DT_bootstrap.css">
    <link rel="stylesheet" href="../../../Content/assets/gritter/css/jquery.gritter.css">
    <link rel="stylesheet" href="../../../Content/assets/code-prettify/code-prettify.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1><i class="icon-file-alt"></i><%: Title %></h1>
    <h4>
        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Language, LABEL_DATALOAD_PROFILES_DESCRIPTION %>" />
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
    <li>
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Module/DataLoad/" Text="<%$ Resources:Language, LABEL_DATALOAD %>"></asp:HyperLink>
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
                        <asp:Literal ID="LTWizard" runat="server" Text="<%$ Resources:Language, LABEL_DATALOAD_PROFILE_DETAILS %>"></asp:Literal></h3>
                    <ul class="nav nav-tabs">
                        <li class=""><a href="../../../Module/DataLoad/">
                            <asp:Label ID="LUsers" runat="server" Text="<%$ Resources:Language, LABEL_LOADS %>"></asp:Label></a></li>
                        <li class="active"><a href="../../Module/DataLoad/Profiles/">
                            <asp:Label ID="LProfiles" runat="server" Text="<%$ Resources:Language, LABEL_PROFILES %>"></asp:Label></a></li>
                        <li class=""><a href="../../../Module/DataLoad/History">
                            <asp:Label ID="LHistory" runat="server" Text="<%$ Resources:Language, LABEL_HISTORY %>"></asp:Label></a></li>
                    </ul>
                </div>
                <div class="box-content">
                    <div class="btn-toolbar pull-right clearfix">
                        <div class="btn-group">
                            <a id="A1" class="btn btn-circle show-tooltip" runat="server" title="<%$ Resources:Language, LABEL_ADD_NEW_RECORD %>" href="#modal-1" data-toggle="modal"><i class="icon-plus"></i></a>
                        </div>
                        <div class="btn-group">
                            <a id="A2" class="btn btn-circle show-tooltip" runat="server" title="<%$ Resources:Language, LABEL_REFRESH %>" href="?Refresh"><i class="icon-repeat"></i></a>
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
                                            <asp:Label ID="LProfileName" runat="server" Text="<%$ Resources:Language, LABEL_PROFILE_NAME %>"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="LStoredProcedure" runat="server" Text="<%$ Resources:Language, LABEL_PROFILE_STOREPROCEDURE %>"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="LDescription" runat="server" Text="<%$ Resources:Language, LABEL_DESCRIPTION %>"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="LPlantilla" runat="server" Text="Plantilla"></asp:Label>
                                        </th>
                                        <th style="width: 70px">
                                            <asp:Label ID="LAction" runat="server" Text="<%$ Resources:Language, LABEL_ACTION %>"></asp:Label>
                                        </th>
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
                                    <asp:Literal ID="LTProfileName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Name") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="LTProfileStoreProcedure" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"StoreProcedure") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="LTProfileDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Description") %>'></asp:Literal>
                                </td>
                                <td>
                                    <a href='../../../Template/<%# DataBinder.Eval(Container.DataItem,"Plantilla") %>'><asp:Literal ID="LTPlantilla" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Plantilla") %>'></asp:Literal></a>
                                </td>
                                <td>
                                    <div class="btn-group">
                                        <a id="A3" class="btn btn-small show-tooltip" runat="server" title="<%$ Resources:Language, LABEL_EDIT %>" href='<%# "Edit?Id=" + DataBinder.Eval(Container.DataItem,"ProfileId") %>'><i class="icon-edit"></i></a>
                                        <a id="A4" class="btn btn-small btn-danger show-tooltip" runat="server" title="<%$ Resources:Language, LABEL_DELETE %>" href='<%# "?Delete=" + DataBinder.Eval(Container.DataItem,"ProfileId") %>'><i class="icon-trash"></i></a>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr>
                                <td>
                                    <input type="checkbox" />
                                </td>
                                <td>
                                    <asp:Literal ID="LTProfileName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Name") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="LTProfileStoreProcedure" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"StoreProcedure") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="LTProfileDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Description") %>'></asp:Literal>
                                </td>
                                <td>
                                    <a href='../../../Template/<%# DataBinder.Eval(Container.DataItem,"Plantilla") %>'><asp:Literal ID="LTPlantilla" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Plantilla") %>'></asp:Literal></a>
                                </td>
                                <td>
                                    <div class="btn-group">
                                        <a id="A5" class="btn btn-small show-tooltip" runat="server" title="<%$ Resources:Language, LABEL_EDIT %>" href='<%# "Edit?Id=" + DataBinder.Eval(Container.DataItem,"ProfileId") %>'><i class="icon-edit"></i></a>
                                        <a id="A6" class="btn btn-small btn-danger show-tooltip" runat="server" title="<%$ Resources:Language, LABEL_DELETE %>" href='<%# "?Delete=" + DataBinder.Eval(Container.DataItem,"ProfileId") %>'><i class="icon-trash"></i></a>
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
    <div id="modal-1" class="modal hide" tabindex="-1" role="dialog" aria-labelledby="modalNewDDLProfile" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h3 id="modalNewDDLProfile">
                <asp:Literal ID="LTAddNewProfile" runat="server" Text="<%$ Resources:Language, LABEL_ADD_NEW_DDL_PROFILE %>"></asp:Literal></h3>
        </div>
        <div class="modal-body">
            <div class="box-content">
                <div class="form-horizontal">
                    <div class="control-group">
                        <asp:Label ID="LProfileName" CssClass="control-label" runat="server" Text="<%$ Resources:Language, LABEL_NAME %>"></asp:Label>
                        <div class="controls">
                            <asp:TextBox ID="TBProfileName" runat="server" CssClass="input-xlarge" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-error" ErrorMessage="<%$ Resources:Language, ERROR_FIELD_GENERIC %>" ControlToValidate="TBProfileName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="control-group">
                        <asp:Label ID="LProfileStoreProcedures" CssClass="control-label" runat="server" Text="<%$ Resources:Language, LABEL_PROCEDURE %>"></asp:Label>
                        <div class="controls">
                            <asp:DropDownList ID="DDLStoreProcedures" CssClass="input-xlarge" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="control-group">
                        <asp:Label ID="LBDescription" runat="server" CssClass="control-label" Text="<%$ Resources:Language, LABEL_DESCRIPTION %>"></asp:Label>
                        <div class="controls">
                            <asp:TextBox ID="TBProfileDescription" runat="server" CssClass="input-xlarge" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
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
    <script src="<%=ResolveClientUrl("~/Content/assets/code-prettify/code-prettify.js")%>"></script>
</asp:Content>
