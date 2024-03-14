<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoogleReCaptcha.aspx.cs" Inherits="Captcha.GoogleReCaptcha" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:label id="lblResult" runat="server"></asp:label>
        <recaptcha:recaptchacontrol id="RecaptchaControl2" runat="server" publickey="6LdIHoApAAAAAPwCW5-GidmCeQlpc5ZjgN323rm-" privatekey="6LdIHoApAAAAAJLoDlzKQIao0Lxc_zQpigWV7NQb" theme="blackglass"></recaptcha:recaptchacontrol>
        <asp:button id="btnSubmit" runat="server" text="Submit" onclick="btnSubmit_Click"></asp:button>
    </form>
</body>
</html>
