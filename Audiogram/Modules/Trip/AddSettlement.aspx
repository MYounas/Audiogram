<%@ Page Title="" Language="C#" MasterPageFile="~/Audiogram.Master" AutoEventWireup="true" CodeBehind="AddSettlement.aspx.cs" Inherits="Audiogram.Modules.Trip.AddSettlement" %>

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
    <script src='<%=ResolveUrl("AddSettlement.js")%>' type="text/javascript"></script>
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
                                            Add Settlement Details
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
                    <!-- Settlement section start here -->
                    <div class="col-md-12 col-sm-12 col-xs-12  no-padding-left no-padding-right">
                        <div class="box panel-body no-padding border-top-blue">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <div class="form-group">
                                    <fieldset class="fset fset-item">

                                        <legend class="fset-title">Settlement Details List</legend>
                                        <div class="bg-blue-legend clearfix">
                                            <div id="addrecord-AddSettlementContainer" class="btn btn-primary addrecord-btn margin-top-5" title="Click on this button to add a new Record">Add New Settlement</div>
                                        </div>

                                        <%--<div class="jtable-wrap">
                                            <table id="AddSettlementContainer" class="AddSettlementContainer full-width" style="height: auto;">
                                            </table>
                                        </div>--%>

                                        <div class="row">
                                            <div class="form-horizontal col-lg-12">

                                                <div class="form-group col-xs-12">
                                                    <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Previous Peshgi:</label>
                                                    <div class="col-xs-6 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                        <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtPreviousPeshgi" value="0" />
                                                    </div>
                                                    <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Cash Adv/Deposit:</label>
                                                    <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                        <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtCashAdvDeposit" value="0" />
                                                    </div>
                                                </div>

                                                <div class="form-group col-xs-12">
                                                    <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Purchoon Frieght Up:</label>
                                                    <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                        <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtPurchoonFrieghtUp" value="0" />
                                                    </div>
                                                    <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Purchoon Frieght Return:</label>
                                                    <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                        <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtPurchoonFrightReturn" value="0" />
                                                    </div>
                                                </div>
                                                <div class="form-group col-xs-12">
                                                    <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Pump Cash LOan:</label>
                                                    <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                        <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtPumpCashLoan" value="0" />
                                                    </div>
                                                    <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Misc Cash Loan:</label>
                                                    <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                        <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtMiscCashLoan" value="0" />
                                                    </div>
                                                </div>
                                                <div class="form-group col-xs-12">
                                                    <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Misc 1:</label>
                                                    <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                        <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtSetMisc1" value="0" />
                                                    </div>
                                                    <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Misc 2:</label>
                                                    <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                        <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtSetMisc2" value="0" />
                                                    </div>
                                                </div>
                                                <div class="form-group col-xs-12">
                                                    <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Misc 3:</label>
                                                    <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                        <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtSetMisc3" value="0" />
                                                    </div>
                                                    <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Misc 4:</label>
                                                    <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                        <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtSetMisc4" value="0" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group clear text-left inline-block">
                                                <asp:Button ID="btnStart" runat="server" type="submit" class="btn btn-primary" Text="Save" OnClick="btnStartTest_Click" ClientIDMode="Static" Style="width: 200px !important; margin-left: 10px;"></asp:Button>
                                            </div>
                                        </div>

                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Settlement section close here -->
                </div>
            </div>
        </div>

        <!-- Body Content start here -->

    </section>
</asp:Content>
