<%@ Page Language="C#" MasterPageFile="~/Audiogram.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="StartTrip.aspx.cs" Inherits="Audiogram.Modules.Trip.StartTrip" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Modules/Trip/AddBuilty.ascx" TagPrefix="uc1" TagName="AddBuilty" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">

    <style>
        .mycenter {
            position: relative;
            left: 50%;
            margin-right: -50%;
            transform: translate(-50%, -50%);
        }

        .form-control.with-icon {
            /*width:100% !important;*/
            max-width: 90%;
        }

        .ui-autocomplete .ui-menu-item:first-child a {
            font-weight: bold !important;
        }
    </style>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="SitePlaceHolder" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    1
    <script src="Audio.js"></script>
    <link href="../../Styles/jqx.base.css" rel="stylesheet" />
    <script type="text/javascript" src="../../CommonScripts/jqxcore.js"></script>
    <script type="text/javascript" src="../../CommonScripts/jqxtabs.js"></script>
    <script type="text/javascript" src="../../CommonScripts/echarts-all.js"></script>
    <script type="text/javascript" src="../../CommonScripts/macarons.js"></script>
    <link href="StartTrip.css" rel="stylesheet" />
    <!-- Section start here -->
    <section class="section-content">


        <div class="content-wrap">
            <asp:Panel ID="pnlNewTest0" runat="server" Visible="true">
                <div class="col-md-12 col-sm-12 col-xs-12 padding-top">
                    <div class="col-md-12 col-sm-12 col-xs-12  no-padding-left no-padding-right">
                        <div class="box panel-body no-padding border-top-blue">
                            <!-- Customer section start here -->
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <div class="form-group">
                                    <fieldset class="fset fset-item">
                                        <legend class="fset-title">&nbsp;<i class="fa fa-lg fa-cogs"></i>&nbsp;
                                            Start Trip
                                        </legend>

                                        <div class="panel panel-default" style="width: 80%; padding: 10px; margin: 10px">
                                            <div id="Tabs" role="tabpanel">
                                                <!-- Nav tabs -->
                                                <ul class="nav nav-tabs" role="tablist">
                                                    <li class="active"><a href="#basic" aria-controls="basic" role="tab" data-toggle="tab">Basic</a></li>
                                                    <%--<li><a href="#expenses" aria-controls="expensis" role="tab" data-toggle="tab">Expenses</a></li>
                                                    <li><a href="#settlement" aria-controls="settlement" role="tab" data-toggle="tab">Settlement</a></li>--%>
                                                    <li><a href="#builty" aria-controls="builty" role="tab" data-toggle="tab">Builty</a></li>
                                                </ul>
                                                <!-- Tab panes -->
                                                <div class="tab-content" style="padding-top: 20px">

                                                    <div role="tabpanel" class="tab-pane active" id="basic">
                                                        <div class="row">
                                                            <div class="form-horizontal col-lg-12">
                                                                <div class="form-group col-xs-12">
                                                                    <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap-- padcol1--">Vehicle :</label>
                                                                    <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                                        <asp:DropDownList ID="drpVehicle" ClientIDMode="Static" DataTextField="" class="form-control with-icon col-xs-10 text-left-f" runat="server">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group col-xs-12">
                                                                    <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap-- padcol1--">First Driver :</label>
                                                                    <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                                        <asp:DropDownList ID="drpFirstDriver" ClientIDMode="Static" CssClass="form-control with-icon col-xs-11 text-left-f" runat="server">
                                                                        </asp:DropDownList>
                                                                    </div>

                                                                    <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Second Driver :</label>
                                                                    <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                                        <asp:DropDownList ID="drpSecondDriver" ClientIDMode="Static" CssClass="form-control with-icon col-xs-11 text-left-f" runat="server">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group col-xs-12">
                                                                    <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Start Date:</label>
                                                                    <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                                        <input type="date" id="startDate" runat="server" class="form-control" />
                                                                    </div>
                                                                </div>

                                                                <div class="form-group col-xs-12">
                                                                    <label class="control-label col-xs-12 col-sm-2 col-lg-2 text-left-f NoWrap--">Route Detail:</label>
                                                                    <div class="col-xs-12 col-sm-4 col-md-3 col-lg-4 newTestFormwidth--">
                                                                        <textarea class="form-control input-sm" id="txtRouteDetail" rows="3" runat="server"></textarea>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>

<%--                                                    <div role="tabpanel" class="tab-pane" id="expenses">
                                                        <asp:Panel ID="pnlexpenes" runat="server">

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

                                                            </div>

                                                        </asp:Panel>
                                                    </div>

                                                    <div role="tabpanel" class="tab-pane" id="settlement">
                                                        <asp:Panel ID="pnlsettlement" runat="server">

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
                                                            </div>
                                                        </asp:Panel>
                                                    </div>--%>

                                                    <div role="tabpanel" class="tab-pane" id="builty">
                                                        <uc1:AddBuilty runat="server" id="AddBuilty" />
                                                    </div>

                                                </div>
                                            </div>


                                        </div>

                                        <div class="form-group clear text-left inline-block">
                                            <asp:Button ID="btnStart" runat="server" type="submit" OnClientClick="return validateStart_Test()" class="btn btn-primary" Text="Start Trip" OnClick="btnStartTest_Click" ClientIDMode="Static" Style="width: 200px !important; margin-left: 10px;"></asp:Button>
                                        </div>


                                    </fieldset>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </section>


</asp:Content>



