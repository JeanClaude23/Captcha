<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Captcha.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Captcha Form</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="imgCaptcha" runat="server" alt="no image available"/>
            <br />
            <asp:TextBox ID="txtCaptcha" runat="server"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
