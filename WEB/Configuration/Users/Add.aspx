<%@ Page Title="<%$ Resources:Language, LABEL_ADD %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="WEB.Configuration.Users.Add" %>

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
                        <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Language, LABEL_ADD_USER %>" />
                    </h3>
                </div>
                <div class="box-content">
                    <div class="form-horizontal">
                        <asp:CreateUserWizard runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser">
                            <LayoutTemplate>
                                <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder" />
                                <asp:PlaceHolder runat="server" ID="navigationPlaceholder" />
                            </LayoutTemplate>
                            <WizardSteps>
                                <asp:CreateUserWizardStep runat="server" ID="RegisterUserWizardStep">
                                    <ContentTemplate>
                                        <div class="alert alert-info">
                                            <button class="close" data-dismiss="alert">×</button>
                                            <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:Language, LABEL_INFO_NEW_USER %>"></asp:Literal>
                                        </div>

                                        <p class="alert-error">
                                            <asp:Literal runat="server" ID="ErrorMessage" />
                                        </p>
                                        <div class="control-group">
                                            <asp:Label ID="Label1" CssClass="control-label" runat="server">User name</asp:Label>
                                            <div class="controls">
                                                <asp:TextBox runat="server" ID="UserName" CssClass="input-xlarge" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName"
                                                    CssClass="text-error" ErrorMessage="The user name field is required." />
                                            </div>
                                        </div>

                                        <div class="control-group">
                                            <asp:Label ID="Label2" CssClass="control-label" runat="server">Email address</asp:Label>
                                            <div class="controls">
                                                <asp:TextBox runat="server" ID="Email" CssClass="input-xlarge" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Email"
                                                    CssClass="text-error" ErrorMessage="The email address field is required." />
                                            </div>
                                        </div>


                                        <div class="control-group">
                                            <asp:Label ID="Label3" CssClass="control-label" runat="server">Password</asp:Label>
                                            <div class="controls">
                                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="input-xlarge" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Password"
                                                    CssClass="text-error" ErrorMessage="The password field is required." />
                                            </div>

                                        </div>

                                        <div class="control-group">
                                            <asp:Label ID="Label4" CssClass="control-label" runat="server">Confirm password</asp:Label>
                                            <div class="controls">
                                                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="input-xlarge" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ConfirmPassword"
                                                    CssClass="text-error" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                                    CssClass="text-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                                            </div>

                                        </div>
                                        <div class="form-actions">
                                            <asp:Button ID="BTRegister" runat="server" CommandName="MoveNext" Text="<%$ Resources:Language, BUTTON_REGISTER_NEW_USER %>" CssClass="btn btn-primary" />
                                        </div>
                                    </ContentTemplate>
                                    <CustomNavigationTemplate />
                                </asp:CreateUserWizardStep>
                            </WizardSteps>
                        </asp:CreateUserWizard>
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
