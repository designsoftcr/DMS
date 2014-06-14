<%@ Page Title="<%$ Resources:Language, LABEL_DATALOAD %>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WEB.Module.DataLoad.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageSpecificCSSStyles" runat="server">
    <link rel="stylesheet" href="../../Content/assets/bootstrap-fileupload/bootstrap-fileupload.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    <h1><i class="icon-file-alt"></i><%: Title %></h1>
    <h4>
        <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Language, LABEL_DATALOAD_DESCRIPTION %>" />
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
                        <asp:Literal ID="LTWizard" runat="server" Text="<%$ Resources:Language, LABEL_WIZARD %>"></asp:Literal></h3>
                    <ul class="nav nav-tabs">
                        <li class="active"><a href="../../Module/DataLoad/">
                            <asp:Label ID="LUsers" runat="server" Text="<%$ Resources:Language, LABEL_LOADS %>"></asp:Label></a></li>
                        <li id="LiProfiles" runat="server" class=""><a href="../../Module/DataLoad/Profiles/">
                            <asp:Label ID="LProfiles" runat="server" Text="<%$ Resources:Language, LABEL_PROFILES %>"></asp:Label></a></li>
                        <li class=""><a href="../../Module/DataLoad/History">
                            <asp:Label ID="LHistory" runat="server" Text="<%$ Resources:Language, LABEL_HISTORY %>"></asp:Label></a></li>
                    </ul>
                </div>
                <div class="box-content">
                    <div class="alert alert-error" id="ErrorDiv" visible="false" runat="server">
                        <button class="close" data-dismiss="alert">×</button>
                        <strong>Error!</strong><pre><asp:Literal ID="LError" runat="server" Text=""></asp:Literal></pre>
                    </div>
                    <div class="form-horizontal">
                        <div class="form-horizontal">
                            <div class="form-wizard" id="form-wizard-1">
                                <ul class="row-fluid steps">
                                    <li class="span3">
                                        <a href="#tab1-1" data-toggle="tab" class="step active">
                                            <span class="number">1</span>
                                            <span class="desc"><i class="icon-ok"></i>
                                                <asp:Label ID="LFile" runat="server" Text="<%$ Resources:Language, LABEL_FILE %>"></asp:Label></span>
                                        </a>
                                    </li>
                                    <li class="span3">
                                        <a href="#tab1-2" data-toggle="tab" class="step">
                                            <span class="number">2</span>
                                            <span class="desc"><i class="icon-ok"></i>
                                                <asp:Label ID="LProfileW" runat="server" Text="<%$ Resources:Language, LABEL_PROFILE %>"></asp:Label></span>
                                        </a>
                                    </li>
                                </ul>
                                <div class="progress progress-primary progress-striped">
                                    <div class="bar"></div>
                                </div>
                                <div class="tab-content">
                                    <div class="tab-pane active" id="tab1-1">
                                        <div class="form-horizontal">
                                            <div class="control-group">
                                                <asp:Label ID="LSpreadSheet" runat="server" CssClass="control-label" Text="<%$ Resources:Language, LABEL_SPREADSHEET %>"></asp:Label>
                                                <div class="controls">
                                                    <div class="fileupload fileupload-new" data-provides="fileupload">
                                                        <div class="input-append">
                                                            <div class="uneditable-input">
                                                                <i class="icon-file fileupload-exists"></i>
                                                                <span class="fileupload-preview"></span>
                                                            </div>
                                                            <span class="btn btn-file">
                                                                <span class="fileupload-new">
                                                                    <asp:Label ID="LSelectFile" runat="server" Text="<%$ Resources:Language, LABEL_SELECT_FILE %>"></asp:Label></span>
                                                                <span class="fileupload-exists">
                                                                    <asp:Label ID="LChange" runat="server" Text="<%$ Resources:Language, LABEL_CHANGE %>"></asp:Label></span>
                                                                <input type="file" class="default" name='myFile' id='myFile' runat="server" />
                                                            </span>
                                                            <a href="#" class="btn fileupload-exists" data-dismiss="fileupload">
                                                                <asp:Label ID="LRemove" runat="server" Text="<%$ Resources:Language, LABEL_REMOVE %>"></asp:Label></a>
                                                        </div>
                                                    </div>
                                                    <span class="label label-important">
                                                        <asp:Label ID="LNOTE" runat="server" Text="<%$ Resources:Language, LABEL_NOTE %>"></asp:Label></span>
                                                    <span>
                                                        <asp:Label ID="LNoteMessage" runat="server" Text="<%$ Resources:Language, LABEL_NOTE_MESSAGE %>"></asp:Label></span>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="<%$ Resources:Language, ERROR_SPREADSHEET_REQUIRED %>" CssClass="text-error" ControlToValidate="myFile" ValidationGroup="DataLoad"></asp:RequiredFieldValidator>
                                                    <br />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="<%$ Resources:Language, ERROR_SPREADSHEET %>" CssClass="text-error" ValidationExpression="^.+(.xls|.xlsx)$" ControlToValidate="myFile" ValidationGroup="DataLoad"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane" id="tab1-2">

                                        <div class="control-group">
                                            <asp:Label ID="LProfile" CssClass="control-label" runat="server" Text="<%$ Resources:Language, LABEL_PROFILE %>"></asp:Label>
                                            <div class="controls">
                                                <asp:DropDownList ID="DDLProfiles" CssClass="input-xlarge" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <asp:Label ID="LBDescription" runat="server" CssClass="control-label" Text="<%$ Resources:Language, LABEL_DESCRIPTION %>"></asp:Label>
                                            <div class="controls">
                                                <asp:TextBox ID="TBDescription" runat="server" CssClass="input-xlarge" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <asp:Label ID="LDeleteCurrentData" runat="server" CssClass="control-label" Text="<%$ Resources:Language, LABEL_DELETE_CURRENT_DATA %>"></asp:Label>
                                            <div class="controls">
                                                <asp:CheckBox ID="CBDeleteCurrentData" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-actions clearfix">
                                    <a href="javascript:;" class="btn button-previous">
                                        <asp:Label ID="LBack" runat="server" Text="<%$ Resources:Language, BUTTON_BACK %>"></asp:Label></a>
                                    <a href="javascript:;" class="btn btn-primary button-next">
                                        <asp:Label ID="LContinue" runat="server" Text="<%$ Resources:Language, BUTTON_CONTINUE %>"></asp:Label></a>
                                    <asp:Button ID="BTLoad" CssClass="btn btn-success button-submit" runat="server" Text="<%$ Resources:Language, BUTTON_LOAD %>" OnClientClick="document.getElementById('ILoader').style.visibility = 'visible'" OnClick="BTLoad_Click" ValidationGroup="DataLoad" />
                                    <asp:Image ID="ILoader" runat="server" ImageUrl="~/Content/img/ajax-loader.gif" Style="visibility: hidden" />
                                </div>
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
    <script src="<%=ResolveClientUrl("~/Content/assets/bootstrap-fileupload/bootstrap-fileupload.min.js")%>"></script>
</asp:Content>
