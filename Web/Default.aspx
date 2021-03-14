<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.Default" %>

<%@ Register Src="~/EmployeeControl.ascx" TagName="EmployeeControl" TagPrefix="Custom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <Custom:EmployeeControl ID="EmployeeControl" runat="server" />
    </form>
</body>
</html>
