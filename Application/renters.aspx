<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="renters.aspx.cs" Inherits="Application.renters" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col" style="background-color: darkgray; height: 4em;">
                <h1>Renters/Rentees/Users whatever</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2" style="background-color: lightslategrey; height: 40em; border: solid; text-align: center;">
                <div>
                    <div style="margin-top:0.3em">
                        <asp:Button runat="server" ID="btnLoadUsers" Text="Load Users" OnClick="btnLoadUsers_Click" Width="15em" />
                    </div>
                    <div style="border: solid; border-width: 1px; width: 17.5em;margin-top: 1em; padding-bottom: 0.5em; text-align: center;">
                        <asp:Label runat="server" Text="Name:" />
                        <asp:TextBox runat="server" ID="txtUsersName" />
                        <br />
                        <asp:Button runat="server" ID="btnAddUser" Text="Add Rentee" OnClick="btnAddUser_Click" Width="15em" />
                    </div>
                </div>
                <div style="background-color: lightseagreen; height: 7em; border: solid; border-width: 1px; width: 17.5em; margin-top: 1em;">
                    <asp:Label runat="server" Text="User ID for editing: " />
                    <br />
                    <asp:TextBox runat="server" ID="txtUserIDEdit" TextMode="Number" Width="5em" />
                    <asp:Button runat="server" ID="btnEditUser" Text="Edit Renter"  OnClick="btnEditUser_Click" />
                    <br />
                    <asp:Label runat="server" Text="Save Report based on data in the table" />
                    <asp:Button runat="server" ID="btnSaveRenteeReport" Text="Save Report" OnClick="btnSaveRenteeReport_Click" />
                </div>
            </div>
            <div class="col-md-10" style="overflow: scroll;">
                <div style="height: 40em; border: solid; border-width: 1px">
                    <asp:GridView runat="server" ID="grdUserData" Width="100%" />
                </div>
            </div>
        </div>

    </div>
</asp:Content>
