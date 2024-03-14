<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoogleReCaptchaV3.aspx.cs" Inherits="Captcha.GoogleReCaptchaV3" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>reCAPTCHA v3 Example</title>
    <script src="https://www.google.com/recaptcha/api.js?render=6LdIHoApAAAAAPwCW5-GidmCeQlpc5ZjgN323rm-"></script>
    <script>
        grecaptcha.ready(function () {
            grecaptcha.execute('6LdIHoApAAAAAPwCW5-GidmCeQlpc5ZjgN323rm-', { action: 'submit' }).then(function (token) {
                document.getElementById("g-recaptcha-response").value = token;
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response" />
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click"/>
        </div>
        <asp:Label ID="Response" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>


