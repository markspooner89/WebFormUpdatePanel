<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeControl.ascx.cs" Inherits="Web.Control1" %>

<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" />
            </Columns>
        </asp:GridView>
        <asp:TextBox ID="txtEmployeeFilter" runat="server" Text="" />
        <asp:Button ID="btnemployeeFilter" runat="server" OnClick="btnemployeeFilter_Click" Text="Filter" />
        <asp:Button ID="btnEmployeeFilterReset" runat="server" OnClick="btnEmployeeFilterReset_Click" Text="Reset" />
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
    <ProgressTemplate>
        <div id="divLoading" class="loading-overlay">
            <div class="loading">Loading..</div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>

<style>
    body {
        margin: 0;
        padding: 0;
    }

    .loading-overlay {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background: #cccccc;
        opacity: 0.5;
        z-index: 1000;
    }

    .loading {
        font-size: 20px;
        text-align: center;
        color: #000;
        position: absolute;
        top: 50%;
        left: 0;
        width: 100%;
    }
</style>