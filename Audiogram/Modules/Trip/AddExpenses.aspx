<%@ Page Title="" Language="C#" MasterPageFile="~/Audiogram.Master" AutoEventWireup="true" CodeBehind="AddExpenses.aspx.cs" Inherits="Audiogram.Modules.Trip.AddExpenses" %>

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
    <script src='<%=ResolveUrl("AddExpenses.js")%>' type="text/javascript"></script>
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
                                            Add Expenses
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
                    <!-- Expenses section start here -->
                    <div class="col-md-12 col-sm-12 col-xs-12  no-padding-left no-padding-right">
                        <div class="box panel-body no-padding border-top-blue">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <div class="form-group">
                                    <fieldset class="fset fset-item">

                                        <%--<legend class="fset-title">Expenses Details List</legend>
                                        <div class="bg-blue-legend clearfix">
                                            <div id="addrecord-AddExpensesContainer" class="btn btn-primary addrecord-btn margin-top-5" title="Click on this button to add a new Record">Add New Expenses</div>
                                        </div>

                                        <div class="jtable-wrap">
                                            <table id="AddExpensesContainer" class="AddExpensesContainer full-width" style="height: auto;">
                                            </table>
                                        </div>--%>

                                        <div class="row">
                                            <div class="row">
                                                <div class="form-horizontal col-lg-12">

                                                    <div class="form-group col-xs-12">
                                                        <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Fix Expenses:</label>
                                                        <div class="col-xs-6 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                            <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtFix" value="0" />
                                                        </div>
                                                        <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Pallytaree:</label>
                                                        <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                            <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtPallytaree" value="0" />
                                                        </div>
                                                    </div>

                                                    <div class="form-group col-xs-12">
                                                        <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Tooltax:</label>
                                                        <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                            <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtToolTax" value="0" />
                                                        </div>
                                                        <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Cont/Port:</label>
                                                        <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                            <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtContPort" value="0" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group col-xs-12">
                                                        <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Munshiana:</label>
                                                        <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                            <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtMunshiana" value="0" />
                                                        </div>
                                                        <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Food/Days:</label>
                                                        <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                            <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtFood" value="0" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group col-xs-12">
                                                        <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Godown:</label>
                                                        <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                            <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtGodown" value="0" />
                                                        </div>
                                                        <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Tyre:</label>
                                                        <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                            <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtTyre" value="0" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group col-xs-12">
                                                        <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Accident:</label>
                                                        <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                            <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtAccident" value="0" />
                                                        </div>
                                                        <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Police:</label>
                                                        <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                            <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtPolice" value="0" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group col-xs-12">
                                                        <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Parts/Maintanence:</label>
                                                        <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                            <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtPartsMaint" value="0" />
                                                        </div>
                                                        <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Maintaience Labour:</label>
                                                        <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                            <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtLabourMaint" value="0" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group col-xs-12">
                                                        <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Salary:</label>
                                                        <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                            <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtSalary" value="0" />
                                                        </div>
                                                        <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Misc 1:</label>
                                                        <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                            <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtMisc1" value="0" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group col-xs-12">
                                                        <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Misc 2:</label>
                                                        <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                            <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtMisc2" value="0" />
                                                        </div>
                                                        <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Misc 3:</label>
                                                        <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                            <asp:TextBox type="text" data-step="1" onkeypress="return validateInt(event,this)" data-allowdecimal="false" class="form-control with-icon col-xs-10 text-left-f" runat="server" ID="txtMisc3" value="0" />
                                                        </div>
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
                    <!-- Expenses section close here -->
                </div>
            </div>
        </div>

        <!-- Body Content start here -->

    </section>
</asp:Content>
