<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BasicTrip.ascx.cs" Inherits="Audiogram.Modules.Trip.BasicTrip" %>

<h2>Basic Trip</h2>
<div class="row">
    <div class="col-md-3 col-sm-3">
        <p>First Driver:<asp:TextBox CssClass="form-control" ID="firstDriver" runat="server" readonly></asp:TextBox>
        </p>
    </div>
    <div class="col-md-3 col-sm-3">
        <p>Second Driver:<asp:TextBox CssClass="form-control" ID="secondDriver" runat="server" readonly></asp:TextBox>
        </p>
    </div>
    <div class="col-md-3 col-sm-3">
        <p>Start Date:<asp:TextBox CssClass="form-control" ID="startDate" runat="server" readonly></asp:TextBox>
        </p>
    </div>
    <div class="col-md-3 col-sm-3">
        <p>Vehicle Name:<asp:TextBox CssClass="form-control" ID="vehicle" runat="server" readonly></asp:TextBox>
        </p>
    </div>
</div>

<div class="row">
    <div class="col-md-12 col-sm-12">
        <p>Route Detail:<textarea class="form-control" style="text-align:left" id="routeDetail" runat="server" rows="4" readonly name="S1"></textarea></p>&nbsp;
    </div>
</div>
