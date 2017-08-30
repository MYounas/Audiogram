<%@ Page Title="" Language="C#" MasterPageFile="~/Audiogram.Master" AutoEventWireup="true" CodeBehind="TripManagement.aspx.cs" Inherits="Audiogram.Modules.Trips.TripManagement" %>

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
        <script src='<%=ResolveUrl("TripManagement.js")%>' type="text/javascript"></script>
    <!-- Section start here -->
    <section class="section-content">

         <div class="content-wrap">
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12 padding-top">
                    <!-- driver section start here -->
                    <div class="col-md-12 col-sm-12 col-xs-12  no-padding-left no-padding-right">
                        <div class="box panel-body no-padding border-top-blue">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <div class="form-group">
                                    <fieldset class="fset fset-item">

                                        <legend class="fset-title">Manage Trips</legend>
                                            <div class="bg-blue-legend clearfix">
                                                   <asp:Button ID="btnStart" runat="server"  class="btn btn-primary" Text="Start Trip" ClientIDMode="Static" Style="float: right;border-color:white; width: 10% !important; " OnClick="btnStart_Click" ></asp:Button>
                                                     <input id="Button1"  class="btn btn-primary" type="button" value="Add Lubricant Oil" onclick="LO('')" style="float: left;border-color:white; width: 10% !important; margin-left:5px; " />
                                                     <input id="Button2"  class="btn btn-primary" type="button" value="Add Diesal & Cash Loan" onclick="DACL('')" style="float: left;border-color:white; width: 10% !important; margin-left:5px; " />
                                                     <input id="Button3"  class="btn btn-primary" type="button" value="Add Cash Transaction Detail" onclick="CTD('')" style="float: left;border-color:white; width: 10% !important;margin-left:5px " />
                                                     <input id="Button4"  class="btn btn-primary" type="button" value="Print Report" onclick="report('')" style="float: left;border-color:white; width: 10% !important;margin-left:5px " />
                                         
                                        </div>
                                         
                                        <div class="jtable-wrap">
                                            <table id="TripTableContainer" class="driverTableContainer full-width" style="height: auto;">
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

        <asp:HiddenField ClientIDMode="static" ID="SelectedId" Value="" runat="server" />

    </section>
</asp:Content>
