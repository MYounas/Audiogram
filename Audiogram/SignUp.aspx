<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Audiogram.SignUp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>ML Audiogram - Sign up</title>
    <link rel="shortcut icon" href="/Styles/Images/GMS-favicon.png" />

    <!-- General style sheet start here -->
    <link href="/Styles/bootstrap-css.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/jquery.ui.1.10.3.ie.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/msgBoxLight.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/style.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <!-- General style sheet close here -->

    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css" />

    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />

    <!-- General script start here -->

    <script src='<%=ResolveUrl("~/CommonScripts/jquery-2.1.3.min.js")%>' type="text/javascript"></script>
    <script src='<%=ResolveUrl("~/CommonScripts/jquery-ui-1.10.3.custom.min.js")%>' type="text/javascript"></script>
    <script src='<%=ResolveUrl("~/CommonScripts/modernizr-2.8.3.min.js")%>' type="text/javascript"></script>
    <script src='<%=ResolveUrl("~/CommonScripts/common.js")%>' type="text/javascript"></script>
    <script src='<%=ResolveUrl("~/CommonScripts/bootstrap.min.js")%>'></script>

    <!-- General script close here -->

    <!-- A helper library for JSON serialization -->
    <script type="text/javascript" src="/CommonScripts/jtable/external/json2.js"></script>

    <!-- ASP.NET Web Forms extension for jTable start here -->
    <link href="/CommonScripts/validationEngine/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
    <!-- ASP.NET Web Forms extension for jTable close here -->

    <!-- Import Javascript files for validation engine (in Head section of HTML) start here -->
    <script type="text/javascript" src="/CommonScripts/validationEngine/jquery.validationEngine.js"></script>
    <script type="text/javascript" src="/CommonScripts/validationEngine/jquery.validationEngine-en.js"></script>

    <script type="text/javascript" src="/CommonScripts/jquery.msgBox.js"></script>
    <script type="text/javascript" src="/CommonScripts/BlockUI.js"></script>
    <!-- Import Javascript files for validation engine (in Head section of HTML) close here -->

    <!--script src="../../CommonScripts/page/_result.js"></!--script-->

    <style type="text/css">
.form-control.form-control-f {
    width: 31% !important;
    margin-right: 3.5%;
}
.navbar {
    background: #F7F7F7;
}
.form-group {
    margin-bottom: 0px;
}
.logo-wrap a {
    background: none;
    text-align:left;
}
    </style>

</head>

<body>

    <form id="form1" runat="server">

        <div id="main-wrapper" class="main-wrapper container-fluid">

            <!--div class="head">
                <span class="title">Audiogram Hearing Test System</span>
            </!--div-->


            <header id="header" class="header">
                <nav class="navbar col-xs-12 col-sm-10 col-md-8 col-sm-offset-1 col-md-offset-2 padding-top">
                    <div class="logo-wrap">
                        <a href="/Modules/Common/MainPage.aspx">
                            <img class="logo" src="/Styles/Images/audiogram-logo-transparent.png" />
                        </a>
                    </div>
                </nav>
            </header>


            <!-- Section start here -->
            <section class="section-content">

                <div class="row">

                    <div class="col-xs-12 col-sm-10 col-md-8 col-sm-offset-1 col-md-offset-2 padding-top">

                        <div class="col-md-12 col-sm-12 col-xs-12  no-padding-left no-padding-right">
                            <div class="box panel-body no-padding-top border-top-blue">


                                <div class="col-lg-12 col-md-12 col-sm-12">
                                    <div class="form-group">
                                        <fieldset class="fset-- fset-item--">
                                            <legend class="fset-title" style="margin-bottom:10px; border-bottom: 0px; font-size: 26px;">
                                                Sign up
                                            </legend>

                                            <h5><strong>Sign up details</strong></h5>

                                            <!---------------->
                                <div class="form-horizontal">

                                    <div class="form-group">

                                        <div class="col-xs-6 col-sm-2">
                                            <input type="radio" name="card" class="col-xs-2 col-sm-3 col-md-4 col-lg-5 text-left-f ui-autocomplete-input"> 
                                            <i class="fa fa-2x fa-cc-visa"></i>  
                                        </div>

                                        <div class="col-xs-6 col-sm-2">
                                            <input type="radio" name="card" class="col-xs-2 col-sm-3 col-md-4 col-lg-5 text-left-f ui-autocomplete-input"> 
                                            <i class="fa fa-2x fa-cc-paypal"></i>
                                        </div>

                                        <div class="col-xs-6 col-sm-2">
                                            <input type="radio" name="card" class="col-xs-2 col-sm-3 col-md-4 col-lg-5 text-left-f ui-autocomplete-input margin-top-5">
                                            <i class="fa fa-2x fa-cc-amex"></i>
                                        </div>

                                        <div class="col-xs-6 col-sm-2">
                                            <input type="radio" name="card" class="col-xs-2 col-sm-3 col-md-4 col-lg-5 text-left-f ui-autocomplete-input margin-top-5">
                                            <i class="fa fa-2x fa-cc-mastercard"></i>
                                        </div>

                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-xs-12 col-sm-12 col-md-2 col-lg-2 text-left-f" title="Type at least 1 alphabet or number to initiate searching. Special characters allowed are: &amp;/-.,*+\!@#$()|~:;" style="cursor: help;">Selected Plan</label>
                                        <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                                            <span role="status" aria-live="polite" class="ui-helper-hidden-accessible"></span><input name="ctl00$SitePlaceHolder$txtBoxAutoComplete" type="text" maxlength="35" id="txtBoxAutoComplete" class="form-control full-width col-xs-11 text-left-f ui-autocomplete-input" autocomplete="off">
                                    
                                        </div>

                                        <label class="control-label col-xs-12 col-sm-12 col-md-2 col-lg-2 text-left-f" title="" style="cursor: help;">Email</label>
                                        <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                                            <input type="text" class="form-control full-width col-xs-11 text-left-f ui-autocomplete-input">
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-xs-12 col-sm-12 col-md-2 col-lg-2 text-left-f" title="" style="cursor: help;">First Name</label>
                                        <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                                            <input type="text" class="form-control full-width col-xs-11 text-left-f ui-autocomplete-input">
                                        </div>
                                        <label class="control-label col-xs-12 col-sm-12 col-md-2 col-lg-2 text-left-f" title="" style="cursor: help;">Last Name</label>
                                        <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                                            <input type="text" class="form-control full-width col-xs-11 text-left-f ui-autocomplete-input">
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-xs-12 col-sm-12 col-md-2 col-lg-2 text-left-f" title="" style="cursor: help;">Password</label>
                                        <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                                            <input type="text" class="form-control full-width col-xs-11 text-left-f ui-autocomplete-input">
                                        </div>
                                        <label class="control-label col-xs-12 col-sm-12 col-md-2 col-lg-2 text-left-f" title="" style="cursor: help;">Retype Password</label>
                                        <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                                            <input type="text" class="form-control full-width col-xs-11 text-left-f ui-autocomplete-input">
                                        </div>
                                    </div>
                                </div>

                                <h5><strong>Select your payment method</strong></h5>


                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <label class="control-label col-xs-12 col-sm-12 col-md-2 col-lg-2 text-left-f" title="Type at least 1 alphabet or number to initiate searching. Special characters allowed are: &amp;/-.,*+\!@#$()|~:;" style="cursor: help;">First Name</label>
                                        <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                                            <span role="status" aria-live="polite" class="ui-helper-hidden-accessible"></span><input name="ctl00$SitePlaceHolder$txtBoxAutoComplete" type="text" maxlength="35" id="txtBoxAutoComplete" class="form-control full-width col-xs-11 text-left-f ui-autocomplete-input" autocomplete="off">
                                    
                                        </div>

                                        <label class="control-label col-xs-12 col-sm-12 col-md-2 col-lg-2 text-left-f" title="" style="cursor: help;">Last Name</label>
                                        <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                                            <input type="text" class="form-control full-width col-xs-11 text-left-f ui-autocomplete-input">
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-xs-12 col-sm-12 col-md-2 col-lg-2 text-left-f" title="" style="cursor: help;">Credit / Dedit Card No.</label>
                                        <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                                            <input type="text" class="form-control full-width col-xs-11 text-left-f ui-autocomplete-input">
                                        </div>
                                        <label class="control-label col-xs-12 col-sm-12 col-md-2 col-lg-2 text-left-f" title="" style="cursor: help;">Expiry Date</label>
                                        <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                                            <select class="form-control form-control-f col-xs-4 text-left-f">
                                                <option>Jan</option>
                                                <option>Feb</option>
                                                <option>Mar</option>
                                            </select>
                                            <select class="form-control form-control-f col-xs-4 text-left-f">
                                                <option>2016</option>
                                                <option>2017</option>
                                                <option>2018</option>
                                            </select>
                                            <input type="text" placeholder="Security Code" class="form-control form-control-f col-xs-4 text-left-f ui-autocomplete-input no-margin-right">
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-xs-12 col-sm-12 col-md-2 col-lg-2 text-left-f" title="" style="cursor: help;">Country</label>
                                        <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                                            <select class="form-control full-width col-xs-11 text-left-f">
                                                <option>Please Select</option>
                                                <option>USA</option>
                                            </select>
                                        </div>
                                        <label class="control-label col-xs-12 col-sm-12 col-md-2 col-lg-2 text-left-f" title="" style="cursor: help;">Postal Code</label>
                                        <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                                            <input type="text" class="form-control full-width col-xs-11 text-left-f ui-autocomplete-input">
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <div class="col-xs-12 text-right">
                                            <button class="btn btn-primary">Review Order</button>
                                        </div>
                                    </div>

                                </div>
                                            <!---------------->

                                        </fieldset>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

            </section>

            <footer id="footer" class="foot">

        <div class="logo-wrap-foot text-right">
            <img src="/Styles/Images/audiogram_small_logo.png" class="logo">
            <table class="links" cellpadding="0" cellspacing="0">
                <tbody>
                    <tr>
                        <td align="right">
                            <table cellpadding="0" cellspacing="0">
                                <tbody>
                                    <tr>
                                        <td style="text-align: right;"><span></span></td>
                                        <td class="footerspace" aria-hidden="true">&nbsp;</td>
                                        <td class="footerspace" aria-hidden="true">&nbsp;</td>
                                        <td style="text-align: right;"><a href="#" class="footerlink" id="ftrTerms">Terms and Conditions &nbsp;</a></td>
                                        <td class="footerspace" aria-hidden="true">&nbsp;</td>
                                        <td class="footerspace" aria-hidden="true">&nbsp;</td>
                                        <td style="text-align: right;"><a href="#" class="footerlink" id="ftrPrivacy">Privacy Policy  &nbsp;</a></td>
                                        <td class="footerspace" aria-hidden="true">&nbsp;</td>
                                        <td class="footerspace" aria-hidden="true">&nbsp;</td>
                                        <td style="text-align: right;"><span id="ftrCopy" class="secondary ltr"> © 2016 - ML Audiogram</span></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

            </footer>

        </div>
    </form>

</body>
</html>

