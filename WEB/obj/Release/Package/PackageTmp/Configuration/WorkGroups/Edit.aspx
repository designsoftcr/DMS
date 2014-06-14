<%@ Page Title="<%$ Resources:Language, LABEL_WORKGROUP_EDIT %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="WEB.Configuration.WorkGroups.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageSpecificCSSStyles" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1><i class="icon-file-alt"></i><%: Title %></h1>
    <h4>
        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Language, LABEL_WORKGROUP_EDIT_DESCRIPTION %>" />
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
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Configuration/WorkGroups/" Text="<%$ Resources:Language, LABEL_WORKGROUPS %>"></asp:HyperLink>
        <span class="divider"><i class="icon-angle-right"></i></span>
    </li>
    <li class="active">
        <asp:Label ID="LEdit" runat="server" Text="<%$ Resources:Language, LABEL_EDIT %>"></asp:Label></li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Tiles" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <div class="box">
                <div class="box-title">
                    <h3><i class="icon-edit"></i>
                        <asp:Label ID="LEditWorkGroup" runat="server" Text="<%$ Resources:Language, LABEL_EDIT %>"></asp:Label></h3>
                </div>
                <div class="box-content">
                    <div class="form-horizontal">
                        <div class="control-group">
                            <asp:Label ID="LWorkGroupName" CssClass="control-label" runat="server" Text="<%$ Resources:Language, LABEL_WORKGROUP_NAME %>"></asp:Label>
                            <div class="controls">
                                <asp:TextBox ID="TBWorkGroupName" runat="server" CssClass="input-xlarge" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-error" ErrorMessage="<%$ Resources:Language, ERROR_FIELD_GENERIC %>" ControlToValidate="TBWorkGroupName"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <hr />
                        <div class="control-group">
                            <asp:Label ID="LUsers" CssClass="control-label" runat="server" Text="<%$ Resources:Language, LABEL_USERS %>"></asp:Label>
                            <div class="controls">
                                <asp:CheckBoxList ID="CBLUsers" runat="server" RepeatColumns="1" CssClass="checkbox inline"></asp:CheckBoxList>
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
