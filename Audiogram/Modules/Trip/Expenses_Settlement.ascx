<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Expenses_Settlement.ascx.cs" Inherits="Audiogram.Modules.Trip.Expenses_Settlement" %>

<div class="row">
    <div class="col-sm-6 col-md-6">
        <h1>Expenses Trip</h1>
        <table border="1" width="100%">
            <tr>
                <th>Description</th>
                <td>Amount</td>
            </tr>
            <% for(int i=0;i<16;i++)
                  { %>
            <tr>
                <th><%= allKeys.ElementAt(i) %></th>
                <td style="text-align:center"><%= allValues.ElementAt(i) %></td>
            </tr>
            <% } %>
            <tr>
                <th>Total</th>
                <td style="text-align:center"><%= sumExpens %></td>
            </tr>
        </table>
    </div>
    
    <div class="col-sm-6 col-md-6">
        <h1>Settlement Trip</h1>
        <table border="1" width="100%">
            <tr>
                <th>A/c Head</th>
                <td>Dr</td>
            </tr>
            <% for(int i=16;i<26;i++)
                  { %>
            <tr>
                <th><%= allKeys.ElementAt(i) %></th>
                <td style="text-align:center"><%= allValues.ElementAt(i) %></td>
            </tr>
            <% } %>
            <tr>
                <th>Total</th>
                <td style="text-align:center"><%= sumSettl %></td>
            </tr>
        </table>
    </div>
    
</div>
