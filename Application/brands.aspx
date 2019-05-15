<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="brands.aspx.cs" Inherits="Application.brands" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col" style="background-color: darkgray; height: 4em;">
                <h1>Brands</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2" style="background-color: lightslategrey; height: 40em; border: solid; text-align: center;">
                <div>
                    <div style="margin-top:0.3em">
                        <asp:Button runat="server" ID="btnLoadBrands" Text="Load Brands" OnClick="btnLoadBrands_Click" Width="15em" />
                    </div>
                    <div style="border: solid; border-width: 1px; width: 17.5em;margin-top: 1em; padding-bottom: 0.5em; text-align: center;">
                        <asp:Label runat="server" Text="Brand Name: " />
                        <br />
                        <asp:Button runat="server" ID="btnAddBrand" Text="Add Brand" OnClick="btnAddBrand_Click" Width="15em" />
                    </div>
                </div>
                <div style="background-color: lightseagreen; height: 7em; border: solid; border-width: 1px; width: 17.5em; margin-top: 1em;">
                    <asp:Label runat="server" Text="Brand ID for editing: " />
                    <br />
                    <asp:TextBox runat="server" ID="txtBrandIDEdit" Width="5em" />
                    <asp:Button runat="server" ID="btnEditBrand" Text="Edit Brand" OnClick="btnEditBrand_Click" />
                </div>
            </div>
            <div class="col-md-10" style="overflow: scroll;">
                <div style="height: 40em; border: solid; border-width: 1px">
                    <asp:GridView runat="server" ID="grdBrandData" Width="100%" />
                </div>
            </div>
        </div>

    </div>
</asp:Content>
