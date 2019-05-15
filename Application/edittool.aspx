<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="edittool.aspx.cs" Inherits="Application.edittool" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
            <div class="row">
                <div class="col-md-5">
                </div>
                <div class="col-md-2">
                    <asp:Label runat="server" Text="Editing ID: " ID="lblID" /> <br />
                    <asp:Label runat="server" Text="Brand: " />
                    <asp:DropDownList runat="server" ID="ddlBrands" Width="15em" />
                    <br />
                    <asp:Label runat="server" Text="Name: " />
                    <asp:TextBox runat="server" ID="txtName" />
                    <asp:Label runat="server" Text="Description: " />
                    <asp:TextBox runat="server" ID="txtDescription" Width="14em" TextMode="MultiLine" Rows="4" Columns="30"/>
                    <br />
                    <asp:CheckBox runat="server" ID="chkActive" Text="Active: "/>
                    <br />
                    <asp:Button runat="server" ID="btnSave" Text="Save edit" OnClick="btnSave_Click" />
                </div>
                <div class="col-md-5">
                </div>
            </div>
        </div>
</asp:Content>
