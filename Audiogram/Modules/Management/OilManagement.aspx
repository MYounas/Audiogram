<%@ Page Title="" Language="C#" MasterPageFile="~/Audiogram.Master" AutoEventWireup="true" CodeBehind="OilManagement.aspx.cs" Inherits="Audiogram.Modules.Managment.OilManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="SitePlaceHolder" runat="server">

    <style type="text/css">
        .highlight {
            background-color: yellow !important;
            text-decoration-color: yellow !important;
        }

        html, body {
            height: 100% !important;
            margin: 0 !important;
            padding: 0 !important;
        }
    </style>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script src='<%=ResolveUrl("OilManagement.js")%>' type="text/javascript"></script>

    <!-- Section start here -->
    <section class="section-content">



        <!-- Body Content start here -->
        <div class="content-wrap">
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12 padding-top">
                    <!-- Oil section start here -->
                    <div class="col-md-12 col-sm-12 col-xs-12  no-padding-left no-padding-right">
                        <div class="box panel-body no-padding border-top-blue">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <div class="form-group">
                                    <fieldset class="fset fset-item">

                                        <p style="float: right;">
                                            <abbr data-position="right" title="You can filter participants by typing complete or partial participant name or ID in participant grid filter box. You can also create a new participant and edit an already existing participant below.">
                                            <img src="../../../Styles/Images/Help.png" alt="Help" width="18" height="18" /></abbr>
                                        </p>

                                        <legend class="fset-title">Oil</legend>
                                        <div class="bg-blue-legend clearfix">
                                            <span title="Type at least 1 alphabet or number to initiate searching. Special characters allowed are: &/-.,*+\!@#$()|~:;">Oil &nbsp&nbsp</span>
                                            <span class="control full-width">
                                                <asp:TextBox ID="txtAutoCompleteoils" Style="width: 22%; min-width: 170px; height: 27px !important; padding-left: 0.4%;" runat="server" ClientIDMode="Static" MaxLength="35"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers, UppercaseLetters, LowercaseLetters,Custom" ValidChars=" .&/-,*+\!@#$()|~:;" TargetControlID="txtAutoCompleteoils" />
                                            </span>
                                            <div title="Click on this button to add a new participant" id="addrecord-oilTableContainer" class="btn btn-primary addrecord-btn margin-top-5">Add New Data</div>
                                        </div>

                                        <div class="jtable-wrap">
                                            <table id="OilTableContainer" class="oilTableContainer full-width" style="height: auto;">
                                            </table>
                                        </div>

                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Oil section close here -->
                </div>
            </div>
        </div>
    </section>
</asp:Content>
