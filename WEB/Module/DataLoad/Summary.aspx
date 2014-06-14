<%@ Page Title="<%$ Resources:Language, LABEL_DATALOAD_SUMMARY %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="WEB.Module.DataLoad.Summary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageSpecificCSSStyles" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1><i class="icon-file-alt"></i><%: Title %></h1>
    <h4>
        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Language, LABEL_DATALOAD_SUMMARY_DESCRIPTION %>" />
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
                    <h3><i class="icon-info"></i>
                        <asp:Literal ID="LTDetail" runat="server" Text="<%$ Resources:Language, LABEL_DETAIL %>"></asp:Literal></h3>
                </div>
                <div class="box-content">
                    <div class="form-horizontal">
                        <h4>
                            <asp:Literal ID="LTLoadedFile" runat="server" Text="<%$ Resources:Language, LABEL_LOADED_FILE %>"></asp:Literal>
                            <span class="green">
                                <asp:HyperLink ID="HLFile" runat="server"></asp:HyperLink></span></h4>
                        <dl class="dl-horizontal">
                            <dt id="DTProfileName" runat="server" visible="false"><asp:Label ID="LProfileName" runat="server" Text="<%$ Resources:Language, LABEL_PROFILE_NAME %>"></asp:Label></dt>
                            <dd id="DDProfileName" runat="server" visible="false">
                                <asp:Literal ID="LTProfileName" runat="server"></asp:Literal></dd>
                            <dt id="DTProfileDescription" runat="server" visible="false"><asp:Label ID="LProfileDescription" runat="server" Text="<%$ Resources:Language, LABEL_PROFILE_DESCRIPTION %>"></asp:Label></dt>
                            <dd id="DDProfileDescription" runat="server" visible="false">
                                <asp:Literal ID="LTProfileDescription" runat="server"></asp:Literal></dd>
                            <dt id="DTFileDescription" runat="server" visible="false"><asp:Label ID="LFileDescription" runat="server" Text="<%$ Resources:Language, LABEL_FILE_DESCRIPTION %>"></asp:Label></dt>
                            <dd id="DDFileDescription" runat="server" visible="false">
                                <asp:Literal ID="LTFileDescription" runat="server"></asp:Literal></dd>
                            <dt id="DTChanges" runat="server" visible="false"><asp:Label ID="LChanges" runat="server" Text="<%$ Resources:Language, LABEL_CHANGES %>"></asp:Label></dt>
                            <dd id="DDChanges" runat="server" visible="false">
                                <ul class="iconic">
                                    <li id="LIInserts" runat="server" visible="false">
                                        <i class="icon-ok green"></i>
                                        <asp:Label ID="LInserts" runat="server" Text="<%$ Resources:Language, LABEL_NEW_RECORDS %>"></asp:Label>
                                        <strong>
                                            <asp:Label ID="LInsertsR" runat="server"></asp:Label></strong>
                                    </li>
                                    <li id="LIUpdates" runat="server" visible="false">
                                        <i class="icon-refresh green"></i>
                                        <asp:Label ID="LUpdates" runat="server" Text="<%$ Resources:Language, LABEL_UPDATED_RECORDS %>"></asp:Label>
                                        <strong>
                                            <asp:Label ID="LUpdatesR" runat="server"></asp:Label></strong>
                                    </li>
                                    <li id="LIDeletes" runat="server" visible="false">
                                        <i class="icon-remove red"></i>
                                        <asp:Label ID="LDeletes" runat="server" Text="<%$ Resources:Language, LABEL_DELETED_RECORDS %>"></asp:Label>
                                        <strong>
                                            <asp:Label ID="LDeletesR" runat="server"></asp:Label></strong>
                                    </li>
                                    <li id="LIErrors" runat="server" visible="false">
                                        <i class="icon-ban-circle red"></i>
                                        <asp:Label ID="LErrors" runat="server" Text="<%$ Resources:Language, LABEL_ERRORS %>"></asp:Label>
                                        <strong>
                                            <asp:Label ID="LErrorsR" runat="server"></asp:Label></strong>
                                    </li>
                                </ul>
                            </dd>
                            <dt id="DTDuration" runat="server" visible="false"><asp:Label ID="LDuration" runat="server" Text="<%$ Resources:Language, LABEL_DURATION %>"></asp:Label></dt>
                            <dd id="DDDuration" runat="server" visible="false"><asp:Literal ID="LTDuration" runat="server"></asp:Literal></dd>
                        </dl>

                        <div class="alert alert-error" id="DIVError" visible="false" runat="server">
                            <button class="close" data-dismiss="alert">×</button>
                            <h4>Error!</h4>
                            <p>
                                <asp:Literal ID="LTErrorDescription" runat="server"></asp:Literal>
                            </p>
                        </div>
                        <div>
                            <asp:GridView ID="dtgErrorShow" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="dtgErrorShow_RowDataBound">
                                <AlternatingRowStyle BackColor="White" />
                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                <SortedDescendingHeaderStyle BackColor="#820000" />
                            </asp:GridView>
                        </div>
                        

                        <div class="form-actions">
                            <asp:HyperLink ID="LBBack" runat="server" NavigateUrl="javascript:history.back()" CssClass="btn" Text="<%$ Resources:Language, BUTTON_BACK %>"></asp:HyperLink>
                            <asp:HyperLink ID="LBAcept" runat="server" NavigateUrl="~/Module/DataLoad/" CssClass="btn btn-primary" Text="<%$ Resources:Language, BUTTON_ACCEPT %>"></asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Modals" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="PageSpecificPluginScripts" runat="server">
</asp:Content>
