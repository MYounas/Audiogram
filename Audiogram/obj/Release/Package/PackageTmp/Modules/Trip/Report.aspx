<%@ Page Title="" Language="C#" MasterPageFile="~/Audiogram.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Audiogram.Modules.Trip.Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Modules/Trip/BasicTrip.ascx" TagPrefix="uc1" TagName="BasicTrip" %>
<%@ Register Src="~/Modules/Trip/Expenses_Settlement.ascx" TagPrefix="uc1" TagName="Expenses_Settlement" %>



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

    <asp:ScriptManager ID="ScriptManager9" runat="server"></asp:ScriptManager>
    <script src="printReport.js"></script>


    <section class="section-content">

        <uc1:BasicTrip runat="server" id="BasicTrip1" />

        <div class="col-sm-6 col-md-6">
            <div id="LOSection">
            <h1>Lubricant Oil</h1>
            <div id="AddLubricantContainer"></div>
        </div>

        <div id="DACLSection">
            <h1>Deiesel And Cash Loan</h1>
            <div id="AddDACLContainer"></div>
        </div>

        <div id="CTDSection">
            <h1>Cash Transaction Details</h1>
            <div id="AddCTDContainer"></div>
        </div>
        </div>

        <div class="col-sm-6 col-md-6">
            <uc1:Expenses_Settlement runat="server" id="Expenses_Settlement" />
        </div>

        <%--<div id="BasicTripSection">
            <h1>Basic Trip</h1>
            <div id="BasicTrip"></div>
        </div>--%>

        <%--<div class="row">

            <div id="ExpensesTripSection" class="col-md-6 col-sm-6">
                <h1>Expenses Trip</h1>
                <div id="ExpensesTrip"></div>
            </div>

            <div id="SettlementTripSection" class="col-md-6 col-sm-6">
                <h1>Settlement Trip</h1>
                <div id="SettlementTrip"></div>
            </div>

        </div>--%>


    </section>


   <%-- <script>

        window.addEventListener("load", function () {

            console.log("table altered");
            var arr = ["ExpensesTripSection", "SettlementTripSection"];

            for (var i = 0; i < arr.length; i++) {

                var allTHs = $("#" + arr[i] + " thead tr").find("span");
                var allTDs = $("#" + arr[i] + " tbody tr").find("td");

                var allTHText = []; var allTDText = [];
                var allData = [];

                if (arr[i] === "ExpensesTripSection") {
                    allTHText.push("<th>Description</th>");
                    allTDText.push("<td><b>Amount</b></td>");
                }
                else if (arr[i] === "SettlementTripSection") {
                    allTHText.push("<th>A/C Head</th>");
                    allTDText.push("<td><b>Dr</b></td>");
                }

                allTHs.each(function () {
                    console.log($(this).text());
                    allTHText.push("<th>" + $(this).text() + "</th>")
                });

                console.log(allTHText);
                console.log("\n");

                allTDs.each(function () {
                    console.log($(this).text());
                    allTDText.push("<td>" + $(this).text() + "</td>");
                })

                for (var j = 0; j < allTDText.length; j++) {
                    allData.push("<tr>" + allTHText[j] + allTDText[j] + "</tr>");
                }

                $("#" + arr[i] + " table").html(allData);

                $("#" + arr[i]).removeClass("visibleY");

            }

        });

    </script>--%>

</asp:Content>


