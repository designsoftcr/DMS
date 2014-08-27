<%@ Page Title="<%$ Resources:Language, LABEL_EDIT_FROFILE %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="WEB.Module.DataLoad.Profiles.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageSpecificCSSStyles" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1><i class="icon-file-alt"></i><%: Title %></h1>
    <h4>
        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Language, LABEL_DATALOAD_PROFILE_EDIT_DESCRIPTION %>" />
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
    <li>
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Module/DataLoad/Profiles/" Text="<%$ Resources:Language, LABEL_DATALOAD_PROFILES %>"></asp:HyperLink>
        <span class="divider"><i class="icon-angle-right"></i></span>
    </li>
    <li class="active"><asp:Label ID="LEdit" runat="server" Text="<%$ Resources:Language, LABEL_EDIT %>"></asp:Label></li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Tiles" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <div class="box">
                <div class="box-title">
                    <h3><i class="icon-edit"></i>
                        <asp:Label ID="LEditProfile" runat="server" Text="<%$ Resources:Language, LABEL_EDIT %>"></asp:Label></h3>
                </div>
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
                        <div class="control-group">
                            <asp:Label ID="LBPlantilla" runat="server" CssClass="control-label" Text="Nombre Plantilla"></asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="TBPlantilla" runat="server" CssClass="input-xlarge" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="BTCancel" runat="server" Text="<%$ Resources:Language, BUTTON_CANCEL %>" CssClass="btn" CausesValidation="False" OnClick="BTCancel_Click" />
                            <asp:Button ID="BTSave" runat="server" Text="<%$ Resources:Language, BUTTON_SAVE %>" CssClass="btn btn-primary" OnClick="BTSave_Click" />
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
