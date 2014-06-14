<%@ Page Title="<%$ Resources:Language, LABEL_DATALOAD_HISTORY %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="WEB.Module.DataLoad.History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageSpecificCSSStyles" runat="server">
    <link rel="stylesheet" href="../../Content/assets/data-tables/DT_bootstrap.css">
    <link rel="stylesheet" href="../../Content/assets/gritter/css/jquery.gritter.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1><i class="icon-file-alt"></i><%: Title %></h1>
    <h4>
        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Language, LABEL_DATALOAD_HISTORY_DESCRIPTION %>" />
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
                    <h3><i class="icon-book"></i>
                        <asp:Literal ID="LTCompanyDetails" runat="server" Text="<%$ Resources:Language, LABEL_DETAIL %>"></asp:Literal></h3>
                    <ul class="nav nav-tabs">
                        <li class=""><a href="../../Module/DataLoad/">
                            <asp:Label ID="LUsers" runat="server" Text="<%$ Resources:Language, LABEL_LOADS %>"></asp:Label></a></li>
                        <li id="LiProfiles" runat="server" class=""><a href="../../Module/DataLoad/Profiles/">
                            <asp:Label ID="LProfiles" runat="server" Text="<%$ Resources:Language, LABEL_PROFILES %>"></asp:Label></a></li>
                        <li class="active"><a href="../../../Module/DataLoad/History">
                            <asp:Label ID="LHistory" runat="server" Text="<%$ Resources:Language, LABEL_HISTORY %>"></asp:Label></a></li>
                    </ul>
                </div>
                <div class="box-content">
                    <div class="btn-toolbar pull-right clearfix">
                        <div class="btn-group">
                            <a id="A1" class="btn btn-circle show-tooltip" runat="server" title="<%$ Resources:Language, LABEL_CLEAR_HISTORY %>" href="#modal-1" data-toggle="modal"><i class="icon-trash"></i></a>
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
                                            <asp:Label ID="LDate" runat="server" Text="<%$ Resources:Language, LABEL_DATE_GRID %>"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="LFileName" runat="server" Text="<%$ Resources:Language, LABEL_FILENAME_GRID %>"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="LInserts" runat="server" Text="<%$ Resources:Language, LABEL_INSERTS_GRID %>"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="Updates" runat="server" Text="<%$ Resources:Language, LABEL_UPDATES_GRID %>"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="LDeletes" runat="server" Text="<%$ Resources:Language, LABEL_DELETES_GRID %>"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="Errors" runat="server" Text="<%$ Resources:Language, LABEL_ERRORS_GRID %>"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="Duration" runat="server" Text="<%$ Resources:Language, LABEL_DURATION %>"></asp:Label>
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
                                    <asp:Literal ID="LTDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Date") %>'></asp:Literal>
                                </td>
                                <td>
                                    <a id="A3" runat="server" href='<%# DataBinder.Eval(Container.DataItem,"FileLink") %>'>
                                        <asp:Literal ID="LTFileName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"FileName") %>'></asp:Literal>
                                    </a>
                                </td>
                                <td>
                                    <asp:Literal ID="LTInserts" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Inserts") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="LTUpdates" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Updates") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="LTDeletes" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Deletes") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="LTErrors" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Errors") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="LTDuration" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Duration") + "s" %>'></asp:Literal>
                                </td>
                                <td>
                                    <div class="btn-group">
                                        <a id="A4" class="btn btn-small show-tooltip" runat="server" title="<%$ Resources:Language, LABEL_VIEW %>" href='<%# "Summary?FileId=" + DataBinder.Eval(Container.DataItem,"FileId") %>'><i class="icon-zoom-in"></i></a>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr>
                                <td>
                                    <input type="checkbox" /></td>
                                <td>
                                    <asp:Literal ID="LTDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Date") %>'></asp:Literal>
                                </td>
                                <td>
                                    <a runat="server" href='<%# DataBinder.Eval(Container.DataItem,"FileLink") %>'>
                                        <asp:Literal ID="LTFileName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"FileName") %>'></asp:Literal>
                                    </a>
                                </td>
                                <td>
                                    <asp:Literal ID="LTInserts" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Inserts") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="LTUpdates" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Updates") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="LTDeletes" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Deletes") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="LTErrors" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Errors") %>'></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="LTDuration" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Duration") + "s" %>'></asp:Literal>
                                </td>
                                <td>
                                    <div class="btn-group">
                                        <a id="A5" class="btn btn-small show-tooltip" runat="server" title="<%$ Resources:Language, LABEL_VIEW %>" href='<%# "Summary?FileId=" + DataBinder.Eval(Container.DataItem,"FileId") %>'><i class="icon-zoom-in"></i></a>
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
    <div id="modal-1" class="modal hide" tabindex="-1" role="dialog" aria-labelledby="modalClearHistory" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h3 id="modalClearHistory">
                <asp:Literal ID="LTClearHistory" runat="server" Text="<%$ Resources:Language, LABEL_CLEAR_HISTORY %>"></asp:Literal></h3>
        </div>
        <div class="modal-body">
            <p><asp:Literal ID="LTMessage" runat="server" Text="<%$ Resources:Language, LABEL_HISTORY_CLEAR_MESSAGE %>"></asp:Literal></p>
        </div>
        <div class="modal-footer">
            <button class="btn" data-dismiss="modal" aria-hidden="true">
                <asp:Label ID="LButtonNo" runat="server" Text="<%$ Resources:Language, BUTTON_NO %>"></asp:Label></button>
            <asp:Button ID="BTClearHistory" runat="server" CssClass="btn btn-danger" Text="<%$ Resources:Language, BUTTON_CLEAR %>" OnClick="BTClear_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="PageSpecificPluginScripts" runat="server">
    <script src="<%=ResolveClientUrl("~/Content/assets/data-tables/jquery.dataTables.js")%>"></script>
    <script src="<%=ResolveClientUrl("~/Content/assets/data-tables/DT_bootstrap.js")%>"></script>
    <script src="<%=ResolveClientUrl("~/Content/assets/gritter/js/jquery.gritter.js")%>"></script>
</asp:Content>
