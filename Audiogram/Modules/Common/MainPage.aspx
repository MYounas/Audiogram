<%@ Page Title="" Language="C#" MasterPageFile="~/Audiogram.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="Audiogram.Modules.Common.MainPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        body {
            overflow: hidden; /* Unwanted Scrollbar fix */
            overflow-y:scroll;
        }

        .carousel-inner { padding: 0px 10%;}
        _:-ms-fullscreen, :root .carousel-inner { padding: 0px 0%; }


    </style>
    <script src='<%=ResolveUrl("~/CommonScripts/page/_mainPage.js")%>' type="text/javascript"></script>
    <link href="css/morris.css" rel="stylesheet" />
    <script src="//cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
      <script src='<%=ResolveUrl("~/CommonScripts/page/_mainPage.js")%>' type="text/javascript"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/morris.js/0.5.1/morris.min.js"></script>
    <link href="css/style.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="SitePlaceHolder" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

  

    
    <section class="section-content" style="min-height:460px;   ">

        <asp:HiddenField ID="hdnRoleType" runat="server" ClientIDMode="Static" Value=""/>
        <br />
           <div class="row" style="margin-bottom: 5px; ">

            <div class="col-md-3">
                <div class="sm-st clearfix">
                    <span class="sm-st-icon st-red"><i class="fa fa-check-square-o"></i></span>
                    <div class="sm-st-info">
                        <span>3200</span>
                        Total Vehicles
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="sm-st clearfix">
                    <span class="sm-st-icon st-violet"><i class="fa fa-envelope-o"></i></span>
                    <div class="sm-st-info">
                        <span>2200</span>
                        Total Drivers
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="sm-st clearfix">
                    <span class="sm-st-icon st-red"><i class="fa fa-check-square-o"></i></span>
                    <div class="sm-st-info">
                        <span>3200</span>
                        On Trip Vehicles
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="sm-st clearfix">
                    <span class="sm-st-icon st-violet"><i class="fa fa-envelope-o"></i></span>
                    <div class="sm-st-info">
                        <span>2200</span>
                        On Trip Drivers
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="sm-st clearfix">
                    <span class="sm-st-icon st-blue"><i class="fa fa-dollar"></i></span>
                    <div class="sm-st-info">
                        <span>100,320</span>
                        Total Profit
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="sm-st clearfix">
                    <span class="sm-st-icon st-blue"><i class="fa fa-dollar"></i></span>
                    <div class="sm-st-info">
                        <span>100,320</span>
                        Expense This Month
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="sm-st clearfix">
                    <span class="sm-st-icon st-blue"><i class="fa fa-dollar"></i></span>
                    <div class="sm-st-info">
                        <span>100,320</span>
                        Petrol Purchase
                    </div>
                </div>
            </div>
        </div>

        <!-- Main row -->
        <div class="row">

                       <div class="col-md-8">
            
                         <section class="panel">
                    <header class="panel-heading">
                        On Trip Vehicles
                    </header>
                    <div class="panel-body">
                      <div class="jtable-wrap">
                                            <table id="VehicleTableContainerOnTrip" class="VehicleTableContainer full-width jt-body" data-jtableindex="1">
                                            </table>
                                        </div>
                        </div>
                </section>

                      
                         <section class="panel">
                    <header class="panel-heading">
                        Available Vehicles
                    </header>
                    <div class="panel-body">
                      <div class="jtable-wrap">
                                            <table id="VehicleTableContainerIdle" class="VehicleTableContainer full-width jt-body" data-jtableindex="1">
                                            </table>
                                        </div>
                        </div>
                </section>
              </div>
                     <div class="col-md-4">
                       <section class="panel">
                    <header class="panel-heading">
                        Expenses
                    </header>
                     <div class="panel-body">
                       <div id="Div2" style="height: 250px;"></div>
                    </div>
                </section>  

<%--                            <section class="panel">
                    <header class="panel-heading">
                        Notifications
                    </header>
                    <div class="panel-body" id="noti-box">

                        <div class="alert alert-block alert-danger">
                            <button data-dismiss="alert" class="close close-sm" type="button">
                                <i class="fa fa-times"></i>
                            </button>
                            <strong>Oh snap!</strong> Change a few things up and try submitting again.
                        </div>
                        <div class="alert alert-success">
                            <button data-dismiss="alert" class="close close-sm" type="button">
                                <i class="fa fa-times"></i>
                            </button>
                            <strong>Well done!</strong> You successfully read this important alert message.
                        </div>
                        <div class="alert alert-info">
                            <button data-dismiss="alert" class="close close-sm" type="button">
                                <i class="fa fa-times"></i>
                            </button>
                            <strong>Heads up!</strong> This alert needs your attention, but it's not super important.
                        </div>
                        <div class="alert alert-warning">
                            <button data-dismiss="alert" class="close close-sm" type="button">
                                <i class="fa fa-times"></i>
                            </button>
                            <strong>Warning!</strong> Best check yo self, you're not looking too good.
                        </div>


                        <div class="alert alert-block alert-danger">
                            <button data-dismiss="alert" class="close close-sm" type="button">
                                <i class="fa fa-times"></i>
                            </button>
                            <strong>Oh snap!</strong> Change a few things up and try submitting again.
                        </div>
                        <div class="alert alert-success">
                            <button data-dismiss="alert" class="close close-sm" type="button">
                                <i class="fa fa-times"></i>
                            </button>
                            <strong>Well done!</strong> You successfully read this important alert message.
                        </div>
                        <div class="alert alert-info">
                            <button data-dismiss="alert" class="close close-sm" type="button">
                                <i class="fa fa-times"></i>
                            </button>
                            <strong>Heads up!</strong> This alert needs your attention, but it's not super important.
                        </div>
                        <div class="alert alert-warning">
                            <button data-dismiss="alert" class="close close-sm" type="button">
                                <i class="fa fa-times"></i>
                            </button>
                            <strong>Warning!</strong> Best check yo self, you're not looking too good.
                        </div>



                    </div>
                </section>--%>
            
            </div>
       
    <%--        <div class="col-md-8">
                <!--earning graph start-->
                <section class="panel">
                    <header class="panel-heading">
                        Earning Graph
                    </header>
                    <div class="panel-body">
                       <div id="myfirstchart" style="height: 250px;"></div>
                     
                    </div>
                </section>

            
                <!--earning graph end-->

            </div>--%>

   
       
     <%--               <div class="col-md-8">
                <!--earning graph start-->
                <section class="panel">
                    <header class="panel-heading">
                        Trips Graph
                    </header>
                    <div class="panel-body">
                       <div id="Div1" style="height: 250px;"></div>
                     
                    </div>
                </section>

            
                <!--earning graph end-->

            </div>--%>

       

                        <div class="col-lg-4">

                <!--chat start-->
             



            </div>


        </div>

    </section>

     <script>

         //new Morris.Line({
         //    // ID of the element in which to draw the chart.
         //    element: 'myfirstchart',
         //    // Chart data records -- each entry in this array corresponds to a point on
         //    // the chart.
         //    data: [
         //      { month: '2014', value: 2000 },
         //      { month: '2015', value: 3000 },
         //      { month: '2016', value:2500 },
         //      { month: '2017', value: 4000 },
         //      { month: '2018', value: 1000 }
         //    ],
         //    // The name of the data record attribute that contains x-values.
         //    xkey: 'month',
         //    // A list of names of data record attributes that contain y-values.
         //    ykeys: ['value'],
         //    // Labels for the ykeys -- will be displayed when you hover over the
         //    // chart.
         //    labels: ['Value']
         //});

         //new Morris.Line({
         //    // ID of the element in which to draw the chart.
         //    element: 'Div1',
         //    // Chart data records -- each entry in this array corresponds to a point on
         //    // the chart.
         //    data: [
         //      { year: '2008', value: 20 },
         //      { year: '2009', value: 10 },
         //      { year: '2010', value: 5 },
         //      { year: '2011', value: 5 },
         //      { year: '2012', value: 20 }
         //    ],
         //    // The name of the data record attribute that contains x-values.
         //    xkey: 'year',
         //    // A list of names of data record attributes that contain y-values.
         //    ykeys: ['value'],
         //    // Labels for the ykeys -- will be displayed when you hover over the
         //    // chart.
         //    labels: ['Value']
         //});

         Morris.Donut({
             element: 'Div2',
             data: [
               { label: "Expenses", value: 12000 },
               { label: "Petrol", value: 10000 },
               { label: "Driver Expense", value: 20000 }
             ]
         });

    </script>


</asp:Content>
