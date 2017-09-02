<%@ Page Title="" Language="C#" MasterPageFile="~/Audiogram.Master" AutoEventWireup="true" CodeBehind="AddCTD.aspx.cs" Inherits="Audiogram.Modules.Trip.AddCTD" %>

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

    <asp:ScriptManager ID="ScriptManager4" runat="server"></asp:ScriptManager>
    <script src='<%=ResolveUrl("AddCTD.js")%>' type="text/javascript"></script>
    <!-- Section start here -->
    <section class="section-content">

        <div class="content-wrap">
            <asp:Panel ID="pnlNewTest3" runat="server" Visible="true">
                <div class="col-md-12 col-sm-12 col-xs-12 padding-top">
                    <div class="col-md-12 col-sm-12 col-xs-12  no-padding-left no-padding-right">
                        <div class="box panel-body no-padding border-top-blue">
                            <!-- Customer section start here -->
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <div class="form-group">
                                    <fieldset class="fset fset-item">
                                        <legend class="fset-title">&nbsp;<i class="fa fa-lg fa-cogs"></i>&nbsp;
                                            Add Cash Transaction Details
                                        </legend>
                                        <div class="form-horizontal col-lg-8">


                                            <div class="form-group col-xs-12">
                                                <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Selected Trip:</label>
                                                <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                    <asp:DropDownList ID="drpTrip" ClientIDMode="Static" DataTextField="" class="form-control with-icon col-xs-10 text-left-f" runat="server" OnSelectedIndexChanged="drpTrip_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                        </div>

                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>

        <div class="content-wrap">
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12 padding-top">
                    <!-- driver section start here -->
                    <div class="col-md-12 col-sm-12 col-xs-12  no-padding-left no-padding-right">
                        <div class="box panel-body no-padding border-top-blue">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <div class="form-group">
                                    <fieldset class="fset fset-item">

                                        <legend class="fset-title">Cash Transaction Details List</legend>
                                        <div class="bg-blue-legend clearfix">
                                            <div id="addrecord-AddCTDContainer" class="btn btn-primary addrecord-btn margin-top-5" title="Click on this button to add a new Record">Add New Cash Transaction Details</div>
                                        </div>

                                        <div class="jtable-wrap">
                                            <table id="AddCTDContainer" class="AddCTDContainer full-width" style="height: auto;">
                                            </table>
                                        </div>

                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- driver section close here -->
                </div>
            </div>
        </div>

        <!-- Body Content start here -->

    </section>
</asp:Content>
