<%@ Page Language="C#" MasterPageFile="~/Audiogram.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Audiogram.Modules.ContactUs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <%-- <script src="UserManagement.js"></script>--%>
</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="SitePlaceHolder" runat="server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script src='<%=ResolveUrl("ParticipantManagement.js")%>' type="text/javascript"></script>
    <link href="../Styles/contactus.css" rel="stylesheet" />
    <!-- Section start here -->
    <section class="section-content">

        <!-- Body Content start here -->

        <!------------------>

            <div class="row">

                <div class="col-md-12 col-sm-12 col-xs-12 padding-top">
                    
                    <div class="col-md-12 col-sm-12 col-xs-12  no-padding-left no-padding-right">
                        <div class="box panel-body no-padding border-top-blue">


                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <div class="form-group">


                                    <fieldset class="fset fset-item">
                                        <legend class="fset-title">
                                            <i class="fa fa-lg fa-envelope-o"></i>
                                        </legend>
                                        
                                        <div class="form-horizontal">
                                <div class="form-group">
                                    <label  class="control-label col-xs-4 col-sm-2 col-lg-2 text-left-f">Type of message</label>
                                    <div class="col-xs-6 col-sm-4 col-md-3">
                                        <%-- <asp:TextBox ID="txtName" class="form-control col-xs-11 text-left-f" runat="server"></asp:TextBox> --%>
                                        <select class="form-control col-xs-11 text-left-f">
                                            <option>Support</option>
                                            <option>Other</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-xs-4 col-sm-2 col-lg-2 text-left-f">Message</label>
                                    <div class="col-xs-6 col-sm-4 col-md-3">
                                        <asp:TextBox ID="txtEmail" class="form-control col-xs-11 text-left-f" TextMode="MultiLine" Rows="5" runat="server" placeholder="Type your message here"></asp:TextBox>
                                    </div>
                                </div>
                               <div class="form-group">
                                    <label class="control-label col-xs-4 col-sm-2 col-lg-2 text-left-f">Email Address</label>
                                    <div class="col-xs-6 col-sm-4 col-md-3">
                                       <asp:TextBox ID="txtRemarks" class="form-control col-xs-11 text-left-f" runat="server" placeholder="Please enter your real name"></asp:TextBox>
                                    </div>
                                </div>
                                
                                <div class="form-group">
                                    <label  class="control-label col-xs-4 col-sm-2 col-lg-2"></label>
                                    <div class="col-xs-6 col-sm-4 col-md-3">
                                       <asp:Button ID="btmSubmit" class="btn btn-primary col-xs-11 col-sm-5 col-md-5" runat="server" Text="Submit" />
                                    </div>
                                </div>
                        </div>

                                    </fieldset>

                                </div>
                            </div>

                        </div>
                    </div>

                </div>
            </div>

            <!------------------>


    </section>



</asp:Content>



