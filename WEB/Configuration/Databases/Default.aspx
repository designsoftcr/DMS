<%@ Page Title="<%$ Resources:Language, LABEL_DATABASES %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WEB.Configuration.Databases.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageSpecificCSSStyles" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1><i class="icon-file-alt"></i><%: Title %></h1>
    <h4>
        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Language, LABEL_DATABASES_DESCRIPTION %>" />
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
                        <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Language, LABEL_DATABASE_DETAILS %>"></asp:Literal></h3>
                </div>
                <div class="box-content">
                    <div class="form-horizontal">
                        <div class="control-group">
                            <asp:Label ID="LName" runat="server" CssClass="control-label" Text="<%$ Resources:Language, LABEL_NAME  %>"></asp:Label>
                            <div class="controls">
                                <div class="span12">
                                    <asp:TextBox ID="TBName" runat="server" CssClass="input-xlarge" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TBName" CssClass="text-error" Text="<%$ Resources:Language, ERROR_FIELD_GENERIC %>"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="control-group">
                            <asp:Label ID="LServerName" runat="server" CssClass="control-label" Text="<%$ Resources:Language, LABEL_DATABASE_SERVER %>"></asp:Label>
                            <div class="controls">
                                <div class="span12">
                                    <asp:TextBox ID="TBServerName" runat="server" CssClass="input-xlarge"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TBServerName" CssClass="text-error" Text="<%$ Resources:Language, ERROR_FIELD_GENERIC %>"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="control-group">
                            <asp:Label ID="LDBName" runat="server" CssClass="control-label" Text="<%$ Resources:Language, LABEL_DATABASE_NAME %>"></asp:Label>
                            <div class="controls">
                                <div class="span12">
                                    <asp:TextBox ID="TBDataBaseName" runat="server" CssClass="input-xlarge" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TBDataBaseName" CssClass="text-error" Text="<%$ Resources:Language, ERROR_FIELD_GENERIC %>"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="control-group">
                            <asp:Label ID="LDBUser" runat="server" CssClass="control-label" Text="<%$ Resources:Language, LABEL_DATABASE_USER %>"></asp:Label>
                            <div class="controls">
                                <div class="span12">
                                    <asp:TextBox ID="TBDataBaseUser" runat="server" CssClass="input-xlarge" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TBDataBaseUser" CssClass="text-error" Text="<%$ Resources:Language, ERROR_FIELD_GENERIC %>"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="control-group">
                            <asp:Label ID="LDBPassword" runat="server" CssClass="control-label" Text="<%$ Resources:Language, LABEL_DATABASE_PASSWORD %>"></asp:Label>
                            <div class="controls">
                                <div class="span12">
                                    <asp:TextBox ID="TBDataBasePassword" runat="server" CssClass="input-xlarge" TextMode="Password" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TBDataBasePassword" CssClass="text-error" Text="<%$ Resources:Language, ERROR_FIELD_GENERIC %>"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="control-group">
                            <asp:Label ID="LBDescription" runat="server" CssClass="control-label" Text="<%$ Resources:Language, LABEL_DATABASE_DESCRIPTION %>"></asp:Label>
                            <div class="controls">
                                <div class="span12">
                                    <asp:TextBox ID="TBDescription" runat="server" CssClass="input-xlarge" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <!--<asp:Button ID="BTAdd" runat="server" CssClass="btn btn-primary" Text="<%$ Resources:Language, BUTTON_ADD %>" OnClick="BTAdd_Click" />-->
                            <asp:Button ID="BTSave" runat="server" CssClass="btn btn-primary" Text="<%$ Resources:Language, BUTTON_SAVE %>" OnClick="BTSave_Click" />
                            <!--<asp:Button ID="BTCancel" runat="server" CssClass="btn" Text="<%$ Resources:Language, BUTTON_CANCEL %>" OnClick="BTCancel_Click" CausesValidation="False" />-->
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
