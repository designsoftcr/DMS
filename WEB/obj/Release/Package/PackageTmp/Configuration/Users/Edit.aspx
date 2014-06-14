<%@ Page Title="<%$ Resources:Language, LABEL_USER_EDIT %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="WEB.Configuration.Users.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageSpecificCSSStyles" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1><i class="icon-file-alt"></i><%: Title %></h1>
    <h4>
        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Language, LABEL_CONFIGURATION_DESCRIPTION %>" />
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
    <li>
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Configuration/Users/" Text="<%$ Resources:Language, LABEL_USERS %>"></asp:HyperLink>
        <span class="divider"><i class="icon-angle-right"></i></span>
    </li>
    <li class="active">
        <asp:Label ID="LEdit" runat="server" Text="<%$ Resources:Language, LABEL_EDIT %>"></asp:Label></li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Tiles" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
    <div class="row-fluid">
        <div class="span12">
            <div class="box">
                <div class="box-title">
                    <h3><i class="icon-edit"></i>
                        <asp:Label ID="LUserEdit" runat="server" Text="<%$ Resources:Language, LABEL_EDIT %>"></asp:Label></h3>
                </div>
                <div class="box-content">
                    <div class="form-horizontal">
                        <div class="form-wizard" id="form-wizard-2">
                            <ul class="row-fluid steps steps-fill">
                                <li class="span3">
                                    <a href="#tab2-1" data-toggle="tab" class="step active">
                                        <span class="number">1</span>
                                        <span class="desc"><i class="icon-ok"></i>
                                            <asp:Label ID="LUserInformation" runat="server" Text="<%$ Resources:Language, LABEL_USER_INFORMATION %>"></asp:Label>
                                        </span>
                                    </a>
                                </li>
                                <li class="span3">
                                    <a href="#tab2-2" data-toggle="tab" class="step">
                                        <span class="number">2</span>
                                        <span class="desc"><i class="icon-ok"></i>
                                            <asp:Label ID="LCompanies" runat="server" Text="<%$ Resources:Language, LABEL_COMPANIES %>"></asp:Label>
                                        </span>
                                    </a>
                                </li>
                                <li class="span3">
                                    <a href="#tab2-3" data-toggle="tab" class="step">
                                        <span class="number">3</span>
                                        <span class="desc"><i class="icon-ok"></i>
                                            <asp:Label ID="LWorkGroups" runat="server" Text="<%$ Resources:Language, LABEL_WORKGROUPS %>"></asp:Label>
                                        </span>
                                    </a>
                                </li>
                                <li class="span3">
                                    <a href="#tab2-4" data-toggle="tab" class="step">
                                        <span class="number">4</span>
                                        <span class="desc"><i class="icon-ok"></i>
                                            <asp:Label ID="LPasswordReset" runat="server" Text="<%$ Resources:Language, LABEL_PASSWORD_RESET %>"></asp:Label>
                                        </span>
                                    </a>
                                </li>
                            </ul>
                            <div class="progress progress-primary progress-striped">
                                <div class="bar"></div>
                            </div>
                            <div class="tab-content">
                                <div class="tab-pane active" id="tab2-1">
                                    <div class="control-group">
                                        <asp:Label ID="Label2" CssClass="control-label" runat="server" Text="<%$ Resources:Language, LABEL_DATABASE_USER%>"></asp:Label>
                                         <div>
                                            <asp:TextBox ID="txtUserName" runat="server" Enabled="false" required="false" CssClass="input-xlarge" style="margin-left:2px; margin-bottom: 2px"></asp:TextBox>
                                         </div>
                                        <asp:Label ID="LExternalId" CssClass="control-label" runat="server" Text="<%$ Resources:Language, LABEL_EXTERNAL_ID %>"></asp:Label>
                                         <div>
                                            <asp:TextBox ID="txtExternalID" runat="server" required="false" CssClass="input-xlarge" style="margin-left:3px; margin-bottom: 6px"></asp:TextBox>
                                         </div>
                                        <asp:Label ID="Label1" CssClass="control-label" runat="server" Text="Email address:" ClientIDMode="Predictable"></asp:Label>
                                        <div>
                                            <asp:TextBox runat="server" ID="txtEmail" required="true" CssClass="input-xlarge" style="margin-left:3px; margin-bottom: 6px" />
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane" id="tab2-2">
                                    <br />
                                    <asp:Label ID="lblCompany" runat="server" Text="Company:  "></asp:Label>
                                    <asp:CheckBoxList ID="lbxComapny" runat="server" RepeatColumns="1" CssClass="checkbox inline"></asp:CheckBoxList>
                                    <br />
                                </div>
                                <div class="tab-pane" id="tab2-3">
                                    <asp:Label ID="lblWorkGroup" runat="server" Text="Work Group:  "></asp:Label>
                                     <asp:CheckBoxList ID="lbxWworkGroup" runat="server" RepeatColumns="1" CssClass="checkbox inline"></asp:CheckBoxList>
                                </div>
                                <div class="tab-pane" id="tab2-4">
                                     <div class="control-group">
                                        <asp:Label runat="server" ID="NewPasswordLabel" CssClass="control-label" Text="<%$ Resources:Language, LABEL_NEW_PASSWORD %>"></asp:Label>
                                        <div class="controls">
                                            <div class="span12">
                                                <asp:TextBox runat="server" ID="txtNewPassword" CssClass="input-xlarge" TextMode="Password" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNewPassword"
                                                    CssClass="text-error" ErrorMessage="<%$ Resources:Language, ERROR_CHANGE_PASSWPORD_NEW_PASSWORD %>"
                                                    ValidationGroup="ChangePassword" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions clearfix">
                                <a href="javascript:;" class="btn button-previous">Back 
                                </a>
                                <a href="javascript:;" class="btn btn-primary button-next">Continue
                                </a>
                                <asp:Button ID="BTSave" runat="server" CssClass="btn btn-success button-submit" Text="Save" OnClick="BTSave_Click" />
                            </div>
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
    <script src="<%=ResolveClientUrl("~/Content/assets/bootstrap-wizard/jquery.bootstrap.wizard.min.js")%>"></script>
</asp:Content>
