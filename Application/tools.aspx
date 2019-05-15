<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="tools.aspx.cs" Inherits="Application.tools" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col" style="background-color: darkgray; height: 4em;">
                <h1>Tools</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2" style="background-color: lightslategrey; height: 41em; border: solid; text-align: center;">
                <div>
                    <div style="margin-top: 0.3em">
                        <asp:Button runat="server" ID="queryAllTools" Text="all tools" OnClick="queryAllTools_Click" Width="15em" />
                        <asp:Button runat="server" ID="queryAllCheckedOut" Text="currently checked out tools" OnClick="queryAllCheckedOut_Click" Width="15em" />
                        <asp:Button runat="server" ID="queryAllActive" Text="all active tools" OnClick="queryAllActive_Click" Width="15em" />
                        <asp:Button runat="server" ID="queryAllInActive" Text="all In-Active tools" OnClick="queryAllInActive_Click" Width="15em" />
                    </div>
                    <div style="border: solid; border-width: 1px; width: 17.5em; margin-top: 1em; padding-bottom: 0.5em; text-align: center;">
                        <asp:Label runat="server" Text="Brand: " />
                        <br />
                        <asp:DropDownList runat="server" ID="ddlBrands" Width="15em" />
                        <asp:Button runat="server" ID="btnActiveByBrand" Text="Active tools by Brand" OnClick="btnActiveByBrand_Click" Width="15em" />
                        <asp:Button runat="server" ID="btnInactiveByBrand" Text="Inactive Tools by Brand" OnClick="btnInactiveByBrand_Click" Width="15em" />
                    </div>
                    <div style="background-color: dimgrey; border: solid; border-width: 1px; width: 17.5em; padding-bottom: 0.5em; margin-top: 1em; text-align: center; height: 15em;">
                        <asp:Label runat="server" Text="Add New Tool Brand: " />
                        <asp:DropDownList runat="server" ID="ddlBrand" Width="15em" />
                        <br />
                        <asp:Label runat="server" Text="Tool Name:" />
                        <asp:TextBox runat="server" ID="txtName" />
                        <asp:Label runat="server" Text="Description: " />
                        <br />
                        <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Rows="2" Columns="25" />
                        <div style="display: inline-block">
                            <asp:Label runat="server" Text="Active: " /><asp:CheckBox runat="server" ID="chkActive" />
                            <asp:Button runat="server" ID="btnAddNewTool" Text="Add New Tool" OnClick="btnAddNewTool_Click" />
                        </div>
                    </div>
                </div>
                <div style="background-color: lightseagreen; height: 7em; border: solid; border-width: 1px; width: 17.5em; margin-top: 1em;">
                    <asp:Label runat="server" Text="Tool ID for editing: " />
                    <br />
                    <asp:TextBox runat="server" ID="txtToolIDEdit" TextMode="Number" Width="5em" />
                    <asp:Button runat="server" ID="btnEditTool" Text="Edit Comment" OnClick="btnEditTool_Click" />
                    <br />
                    <asp:Label runat="server" Text="Save Report based on data in the table" />
                    <asp:Button runat="server" ID="btnSaveToolReport" Text="Save Report" OnClick="btnSaveToolReport_Click" />
                </div>
            </div>
            <div class="col-md-10" style="overflow: scroll;">
                <div style="height: 40em; border: solid; border-width: 1px">
                    <asp:GridView runat="server" ID="grdToolData" Width="100%" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2" style="background-color: lightslategrey; height: 30em; border: solid; text-align: center;">
                <div>
                    <div style="margin-top: 1em">
                        <asp:Button runat="server" ID="btnAllComments" Text="List all comments" OnClick="btnAllComments_Click" Width="15em" />
                    </div>
                    <div style="border: solid; border-width: 1px; width: 17.5em; margin-top: 1em; padding-bottom: 0.5em; text-align: center;">
                        <asp:Label runat="server" Text="ToolID: " />
                        <br />
                        <asp:TextBox runat="server" ID="txtSearchToolID" TextMode="Number" />
                        <asp:Button runat="server" ID="btnCommentByTool" Text="Load Comments for Tool" OnClick="btnCommentByTool_Click" Width="15em" />
                    </div>
                    <div style="background-color: dimgrey; border: solid; border-width: 1px; width: 17.5em; padding-bottom: 0.5em; margin-top: 1em; text-align: center; height: 10em;">
                        <asp:Label runat="server" Text="Tool ID: " />
                        <asp:TextBox runat="server" ID="txtToolID" TextMode="Number" />
                        <br />
                        <asp:Label runat="server" Text="Comment: " />
                        <br />
                        <asp:TextBox runat="server" ID="txtComment" TextMode="MultiLine" Rows="2" Columns="25" />
                        <asp:Button runat="server" ID="btnAddComment" Text="Add new Comment" OnClick="btnAddComment_Click" />
                    </div>
                    <div style="background-color: lightseagreen; height: 7em; border: solid; border-width: 1px; width: 17.5em; margin-top: 1em;">
                        <asp:Label runat="server" Text="Comment ID for editing: " />
                        <br />
                        <asp:TextBox runat="server" ID="txtCommentIDEdit" TextMode="Number" Width="5em" />
                        <asp:Button runat="server" ID="btnEditComment" Text="Edit Tool" OnClick="btnEditComment_Click" />
                        <br />
                        <asp:Label runat="server" Text="Save Report based on data in the table" />
                        <asp:Button runat="server" ID="btnSaveCommentReport" Text="Save Report" OnClick="btnSaveCommentReport_Click" />
                    </div>
                </div>
            </div>
            <div class="col-md-10" style="overflow: scroll">
                <div style="height: 30em; border: solid; border-width: 1px">
                    <asp:GridView runat="server" ID="grdCommentData" Width="100%" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
