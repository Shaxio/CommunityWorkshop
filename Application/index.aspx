<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Application.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function allowDrop(ev) {
            ev.preventDefault();
        }

        function drag(ev) {
            ev.dataTransfer.setData("text", ev.target.id);
        }

        function drop(ev) {
            ev.preventDefault();
            var data = ev.dataTransfer.getData("text");
            ev.target.appendChild(document.getElementById(data));
        }
    </script>
    <style>
        .dropbox {
            width: 600px;
            height: 370px;
            border: 1px solid;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a style="font-size: x-large;">its working!
        <asp:button runat="server" id="btnHelp" text="Help" onclick="btnHelp_Click" />
        <br />
        Drag and drop the image below between the two boxes
    </a>
    <div class="col-md-8">
        <div class="dropbox" ondrop="drop(event)" ondragover="allowDrop(event)">
        </div>
    </div>
    <div class="dropbox" ondrop="drop(event)" ondragover="allowDrop(event)">
        <img id="drag1" src="Resources/tools.jpg" draggable="true" ondragstart="drag(event)">
    </div>
</asp:Content>
