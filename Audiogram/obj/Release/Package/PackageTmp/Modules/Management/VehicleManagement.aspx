<%@ Page Language="C#" MasterPageFile="~/Audiogram.Master" AutoEventWireup="true" CodeBehind="VehicleManagement.aspx.cs" Inherits="Audiogram.Modules.Management.VehicleManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <script src='<%=ResolveUrl("~/CommonScripts/page/_customerManagement.js")%>' type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="SitePlaceHolder" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script src="VehicleManagement.js"></script>

    <!-- Section start here -->
    <section class="section-content">

        <!-- Body Content start here -->
        <div class="content-wrap">
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12 padding-top">
                    <!-- Vehicle section start here -->
<%--                    <div class="col-md-12 col-sm-12 col-xs-12  no-padding-left no-padding-right">
                    </div>--%>
                    <!-- Vehicle section close here -->
                    <!-- Vehicle section start here -->
                    <div class="col-md-12 col-sm-12 col-xs-12  no-padding-left no-padding-right">
                        <div class="box panel-body no-padding border-top-blue">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <div class="form-group">
                                    <fieldset class="fset fset-item">
                                        <p class="help-container">
                                            <abbr data-position="right" title="You can filter Vehicles by typing complete or partial Vehicles name or ID in Vehicle grid filter box. You can also create a new Vehicle and edit an already existing Vehicle below.">
                                                <img src="../../../Styles/Images/Help.png" alt="Help" width="18" height="18" /></abbr></p>
                                        <legend class="fset-title">Vehicle</legend>
                                        <div class="bg-blue-legend clearfix">
                                            <span title="Type at least 1 alphabet or number to initiate searching. Special characters allowed are: &/-.,*+\!@#$()|~:;">Vehicle &nbsp&nbsp</span>
                                            <span class="control full-width">
                                                <asp:TextBox ID="txtAutoComplete" Style="width: 22%; min-width: 170px; height: 26px !important; padding-left: 0.4%;" runat="server" ClientIDMode="Static" MaxLength="35"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderAutoComplete" runat="server" FilterType="Numbers, UppercaseLetters, LowercaseLetters,Custom" ValidChars=" .&/-,*+\!@#$()|~:;" TargetControlID="txtAutoComplete" />
                                            </span>
                                            <div id="addrecord-VehicleTableContainer" class="btn btn-primary addrecord-btn margin-top-5" title="Click on this button to add a new Vehicle">Add New Vehicle</div>
                                        </div>

                                        <div class="jtable-wrap">
                                            <table id="VehicleTableContainer" class="VehicleTableContainer full-width jt-body" data-jtableindex="1">
                                            </table>
                                        </div>

                                    </fieldset>

                                </div>
                            </div>

                        </div>
                    </div>

                </div>
            </div>

        </div>

    </section>

</asp:Content>





