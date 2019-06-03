<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="rentals.aspx.cs" Inherits="Application.rentals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col" style="background-color: darkgray; height: 4em;">
                <a class="gap">Rentals</a>
                <div class="gap">
                    <asp:Button runat="server" ID="btnHelp" Text="Help" OnClick="btnHelp_Click" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2" style="background-color: lightslategrey; height: 40em; border: solid; text-align: center;">
                <div>
                    <div style="margin-top: 0.3em">
                        <asp:Button runat="server" ID="btnLoadRentals" Text="Load Rentals" OnClick="btnLoadRentals_Click" Width="15em" />
                    </div>
                    <div style="border: solid; border-width: 1px; width: 17.5em; margin-top: 1em; padding-bottom: 0.5em; text-align: center;">
                        <asp:Label runat="server" Text="Tool: " />
                        <br />
                        <asp:DropDownList runat="server" ID="ddlTool" Width="15em" />
                        <asp:Button runat="server" ID="btnSearchByToolID" Text="List Rentals by Tool" OnClick="btnSearchByToolID_Click" Width="15em" />
                        <br />
                        <asp:Label runat="server" Text="User Name: " />
                        <br />
                        <asp:DropDownList runat="server" ID="ddlUser" Width="12em" />
                        <asp:Button runat="server" ID="btnSearchUserName" Text="List Rentals by User" OnClick="btnSearchUserName_Click" Width="15em" />
                    </div>
                </div>
                <div style="background-color: dimgrey; border: solid; border-width: 1px; width: 17.5em; padding-bottom: 0.5em; margin-top: 1em; text-align: center; height: 17em;">
                    <asp:Label runat="server" Text="Tool for rent: " />
                    <asp:DropDownList runat="server" ID="ddlTools" Width="15em" />
                    <br />
                    <asp:Label runat="server" Text="Renter:" />
                    <asp:DropDownList runat="server" ID="ddlUsers" Width="15em" />
                    <asp:Button runat="server" ID="btnNewRental" Text="Add new rental" OnClick="btnNewRental_Click" />
                    <br />
                    <asp:Label runat="server" Font-Size="Smaller" Text="Date and time autofilled on button press" />
                    <div style="background-color: grey; border: solid; border-width: 1px; width: 17.5em; padding-bottom: 0.5em; margin-top: 1em; text-align: center;">
                        <asp:Label runat="server" Text="Return the Tool with Rental ID: " />
                        <asp:TextBox runat="server" ID="txtReturnID" TextMode="Number" />
                        <asp:Button runat="server" ID="btnRentalReturn" Text="Return Tool" OnClick="btnRentalReturn_Click" />
                        <br />
                        <asp:Label runat="server" Font-Size="Smaller" Text="Date and time autofilled on button press" />
                    </div>
                </div>
                <div style="background-color: lightseagreen; height: 7em; border: solid; border-width: 1px; width: 17.5em; margin-top: 1em;">
                    <asp:Label runat="server" Text="Rental ID for editing: " />
                    <br />
                    <asp:TextBox runat="server" ID="txtRentalIDEdit" TextMode="Number" Width="5em" />
                    <asp:Button runat="server" ID="btnEditRental" Text="Edit Brand" OnClick="btnEditRental_Click" />
                    <br />
                    <asp:Label runat="server" Text="Save Report based on data in the table" />
                    <asp:Button runat="server" ID="btnSaveRentalsReport" Text="Save Report" OnClick="btnSaveRentalsReport_Click" />
                </div>
            </div>
            <div class="col-md-10" style="overflow: scroll;">
                <div style="height: 40em; border: solid; border-width: 1px">
                    <asp:GridView runat="server" ID="grdRenterData" Width="100%" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
