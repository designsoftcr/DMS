<%@ Page Title="<%$ Resources:Language, LABEL_ACCOUNT_SETTINGS %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="WEB.Account.Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageSpecificCSSStyles" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1><i class="icon-file-alt"></i><%: Title %></h1>
    <h4>
        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Language, LABEL_ACCOUNT_SETTINGS_DESCRIPTION%>" />
    </h4>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Breadcrumb" runat="server">
    <li>
        <i class="icon-home"></i>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/" Text="<%$ Resources:Language, LABEL_DASHBOARD %>"></asp:HyperLink>
        <span class="divider"><i class="icon-angle-right"></i></span>
    </li>
    <li>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="#" Text="<%$ Resources:Language, LABEL_ACCOUNT %>"></asp:HyperLink>
        <span class="divider"><i class="icon-angle-right"></i></span>
    </li>
    <li class="active">
        <asp:Label ID="LSettings" runat="server" Text="<%$ Resources:Language, LABEL_SETTINGS %>">"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Tiles" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <div class="box">
                <div class="box-title">
                    <h3><i class="icon-user"></i>
                        <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Language, LABEL_CHANGE_PASSWORD %>" />
                    </h3>
                </div>
                <div class="box-content">
                    <section id="passwordForm">
                        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
                            <p class="message-success"><%: SuccessMessage %></p>
                        </asp:PlaceHolder>

                        <asp:PlaceHolder runat="server" ID="changePassword" Visible="false">
                            <asp:ChangePassword ID="ChangePassword1" runat="server" CancelDestinationPageUrl="~/" ViewStateMode="Disabled" RenderOuterTable="false" SuccessPageUrl="Settings?m=ChangePwdSuccess">
                                <ChangePasswordTemplate>
                                    <p class="text-error">
                                        <asp:Literal runat="server" ID="FailureText" />
                                    </p>
                                    <div class="form-horizontal">
                                        <div class="control-group">
                                            <asp:Label runat="server" ID="CurrentPasswordLabel" CssClass="control-label"  Text="<%$ Resources:Language, LABEL_CURRENT_PASSWORD %>"></asp:Label>
                                            <div class="controls">
                                                <div class="span12">
                                                    <asp:TextBox runat="server" ID="CurrentPassword" CssClass="input-xlarge" TextMode="Password" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="CurrentPassword"
                                                        CssClass="text-error" ErrorMessage="<%$ Resources:Language, ERROR_CHANGE_PASSWPORD_CURRENT_PASSWORD %>"
                                                        ValidationGroup="ChangePassword" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <asp:Label runat="server" ID="NewPasswordLabel" CssClass="control-label" Text="<%$ Resources:Language, LABEL_NEW_PASSWORD %>"></asp:Label>
                                            <div class="controls">
                                                <div class="span12">
                                                    <asp:TextBox runat="server" ID="NewPassword" CssClass="input-xlarge" TextMode="Password" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="NewPassword"
                                                        CssClass="text-error" ErrorMessage="<%$ Resources:Language, ERROR_CHANGE_PASSWPORD_NEW_PASSWORD %>"
                                                        ValidationGroup="ChangePassword" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <asp:Label runat="server" ID="ConfirmNewPasswordLabel" CssClass="control-label" Text="<%$ Resources:Language, LABEL_CONFIRM_PASSWORD %>"></asp:Label>
                                            <div class="controls">
                                                <div class="span12">
                                                    <asp:TextBox runat="server" ID="ConfirmNewPassword" CssClass="input-xlarge" TextMode="Password" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ConfirmNewPassword"
                                                        CssClass="text-error" Display="Dynamic" ErrorMessage="<%$ Resources:Language, ERROR_CHANGE_PASSWPORD_CONFIRM_PASSWORD %>"
                                                        ValidationGroup="ChangePassword" />
                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                                        CssClass="text-error" Display="Dynamic" ErrorMessage="<%$ Resources:Language, ERROR_CHANGE_PASSWPORD_MATCH_PASSWORD %>"
                                                        ValidationGroup="ChangePassword" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-actions">
                                            <asp:Button ID="Button2" runat="server" CommandName="ChangePassword" Text="<%$ Resources:Language, BUTTON_CHANGE_PASSWORD %>" ValidationGroup="ChangePassword" CssClass="btn btn-primary" />
                                        </div>
                                    </div>
                                </ChangePasswordTemplate>
                            </asp:ChangePassword>
                        </asp:PlaceHolder>
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Modals" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="PageSpecificPluginScripts" runat="server">
</asp:Content>
