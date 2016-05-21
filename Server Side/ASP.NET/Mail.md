# ASP.NET.Mail

##Postal
[http://aboutcode.net/postal/](http://aboutcode.net/postal/)

Postal uses the ASP.​NET MVC view engine infrastructure to render you emails, allowing you to declare your email using a normal Razor view. At runtime Postal will automatically render the view, do the proper model binding if appropriate, and send out the email. Postal is able to render email views when running outside of an ASP.NET context (e.g. console app or windows service) using custom view engine RazorEngine. 

###Dynamic Email & ViewBag

```
dynamic email = new Email("Example");
email.To = "vincenthome@example.com";
email.FunnyLink = "http://www.funny.com";
email.Send();
```

Postal will find the email view at Views\Emails\ **Example**.cshtml:

The email view specifies the headers and body content.
The ViewBag contains any data you assigned to the `Email` object.
Postal can work with any ASP.NET MVC view engine.

```
To: @ViewBag.To
From: lolcats@website.com
Subject: Important Message

Hello,
You wanted important web links right?
Check out this: @ViewBag.FunnyLink
```

###Strongly-typed Email

```
public class ExampleEmail : Email
{
  public string To { get; set; }
  public string Message { get; set; }
}
```

```
var email = new ExampleEmail
{
  To = "vincenthome@example.com",
  Message = "Strong typed message"
};
email.Send();
```

Create a view that uses your model. The name of the view is based on the class name. So ExampleEmail requires a view called **Example.cshtml**

```
@model App.Models.ExampleEmail
To: @Model.To
From: postal@example.com
Subject: Example

Hello,
@Model.Message
Thanks!
```

###Embedding images into emails

Web.config
```
<configuration>
  <system.web.webPages.razor>
    <pages pageBaseType="System.Web.Mvc.WebViewPage">
      <namespaces>
        <add namespace="Postal" />
      </namespaces>
    </pages>
  </system.web.webPages.razor>
</configuration>
```

The EmbedImage method will embed the given image into the email and generate an <img/> tag to reference it.

```
To: john@example.org
From: app@example.org
Subject: Image

@Html.EmbedImage("~/content/postal.jpg")
```

###Samples

 - [https://github.com/andrewdavey/postal/tree/master/src/Samples](https://github.com/andrewdavey/postal/tree/master/src/Samples)

##SendGrid

[https://sendgrid.com/](https://sendgrid.com/)

###Setup SMTP in Web.Config

```
<system.net>
  <mailSettings>
    <smtp deliveryMethod="Network" from="test@domain.com">
      <network host="smtp.sendgrid.net" port="587" userName="username" password="password"/>
    </smtp>
  </mailSettings>
</system.net>
```

###Using SendGrid’s C# Library

[GitHub](https://github.com/sendgrid/sendgrid-csharp)

```
// using SendGrid's C# Library
using System;
using System.Net;
using System.Net.Mail;
using SendGridMail;
using SendGridMail.Transport;

SendGrid mail = SendGrid.GetInstance();
mail.From = new MailAddress("you@youremail.com");
mail.AddTo("test@sendgrid.com");
mail.Subject = "Sending with SendGrid is Fun";
mail.Text = "and easy to do anywhere, even with C#";

var credentials = new NetworkCredential(api_user, api_key);
var transportWeb = new Web(credentials);
transportWeb.DeliverAsync(mail);
// If developing a Console Application, use the following
// transportWeb.DeliverAsync(mail).Wait();
```

###Using .NET built-in SmtpClient 

```
static void Main()
{
 try
 {
   MailMessage mailMsg = new MailMessage();

   // To
   mailMsg.To.Add(new MailAddress("to@example.com", "To Name"));

   // From
   mailMsg.From = new MailAddress("from@example.com", "From Name");

   // Subject and multipart/alternative Body
   mailMsg.Subject = "subject";
   string text = "text body";
   string html = @"<p>html body</p>";
   mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
   mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

   // Init SmtpClient and send
   SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
   System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("username@domain.com", "yourpassword");
   smtpClient.Credentials = credentials;

   smtpClient.Send(mailMsg);
 }
 catch (Exception ex)
 {
   Console.WriteLine(ex.Message);
 }

}
```

###Using WebAPI

[https://sendgrid.com/docs/API_Reference/Web_API_v3/index.html](https://sendgrid.com/docs/API_Reference/Web_API_v3/index.html)


###Documentation

[https://sendgrid.com/docs/index.html](https://sendgrid.com/docs/index.html)
