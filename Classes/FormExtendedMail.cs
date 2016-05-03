using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Logging;
using Telerik.Sitefinity.Configuration;

namespace Fenetre.Sitefinity.FormHandler
{


  public static class FormHandlerMail
  {
    #region SendFormHandlerEmailMessage
      /// <summary>
      /// Method that sends the given message
      /// </summary>
      /// <param name="fromAddresses">The adresses the message comes from</param>
      /// <param name="toAddresses">The adresses the message is sent to</param>
      /// <param name="ccAddresses">The adresses which recieve a cc of the message</param>
      /// <param name="subject">The subject of the message</param>
      /// <param name="body">The body of the message</param>
      /// <param name="bodyHTML">The body of the message using HTML markup to define the layout</param>
      /// <param name="attachments">The attachments of the message</param>
      /// <param name="currentFormName">The name of the form</param>
      /// <returns>Returns a boolean whether the email was successfully sent</returns>
	  public static bool SendFormHandlerEmailMessage(string fromAddresses, string toAddresses, string ccAddresses, string subject, string body, string bodyHTML, List<Attachment> attachments, string currentFormName)
	  {
		  if (!string.IsNullOrEmpty(fromAddresses) && !string.IsNullOrEmpty(toAddresses))
		  {
			  var mailServer = new SmtpClient();
			  var mailMessage = new MailMessage();

			  var smtpSettings = Config.Get<Telerik.Sitefinity.Services.SystemConfig>().SmtpSettings;

			  if (string.IsNullOrWhiteSpace(fromAddresses))
			  {
				  fromAddresses = smtpSettings.DefaultSenderEmailAddress;
			  }

			  if (!smtpSettings.Host.IsNullOrWhitespace())
			  {
				  mailServer.Host = smtpSettings.Host;
				  mailServer.Port = smtpSettings.Port;
				  mailServer.EnableSsl = smtpSettings.EnableSSL;
				  mailServer.Timeout = smtpSettings.Timeout;

				  if (!string.IsNullOrEmpty(smtpSettings.UserName))
				  {
					  mailServer.UseDefaultCredentials = false;
					  mailServer.Credentials = new System.Net.NetworkCredential(smtpSettings.UserName, smtpSettings.Password);
				  }
			  }

			  mailMessage.From = new MailAddress(fromAddresses);

			  string[] toAddressesArray = new string[0];
			  string[] ccAddressesArray = new string[0];

			  if (!string.IsNullOrWhiteSpace(toAddresses))
			  {
				  toAddressesArray = toAddresses.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
			  }

			  if (!string.IsNullOrWhiteSpace(ccAddresses))
			  {
				  ccAddressesArray = ccAddresses.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
			  }

			  foreach (var emailAddr in toAddressesArray.Select(s => s.Trim()))
			  {
				  mailMessage.To.Add(new MailAddress(emailAddr));
			  }

			  foreach (var emailAddr in ccAddressesArray.Select(s => s.Trim()))
			  {
				  mailMessage.CC.Add(new MailAddress(emailAddr));
			  }

			  if (attachments != null)
			  {
				  foreach (var attachment in attachments)
				  {
					  mailMessage.Attachments.Add(attachment);
				  }
			  }

			  mailMessage.Subject = subject;
			  //mailMessage.Body = body;

			  AlternateView plainView = AlternateView.CreateAlternateViewFromString(body, null, System.Net.Mime.MediaTypeNames.Text.Plain);
			  plainView.TransferEncoding = System.Net.Mime.TransferEncoding.QuotedPrintable;
			  mailMessage.AlternateViews.Add(plainView);

			  if (bodyHTML.Length > 0)
			  {
				  //ContentType mimeType = new System.Net.Mime.ContentType("text/html");
				  AlternateView htmlView = AlternateView.CreateAlternateViewFromString(bodyHTML, null, System.Net.Mime.MediaTypeNames.Text.Html);
				  htmlView.TransferEncoding = System.Net.Mime.TransferEncoding.QuotedPrintable;
				  mailMessage.AlternateViews.Add(htmlView);
			  }

			  try
			  {
				  mailServer.Send(mailMessage);
			  }
			  catch (Exception ex)
			  {
				  var logEntry = new LogEntry();
				  logEntry.Categories.Add("ErrorLog");
				  logEntry.Message = ex.ToString();
				  logEntry.Title = string.Format("[Fenetre.Sitefinity.FormHandler] - Email on form submission failed (FormName: {0}", currentFormName);
				  Logger.Writer.Write(logEntry);
				  return false;
			  }
		  }
		  return true;
	  }

    #endregion

    #region CreateFormHandlerMailAttachments
    /// <summary>
    /// Method that creates a list of attachments from the given files
    /// </summary>
    /// <param name="uploadedFiles"></param>
    /// <returns>Return a list of attachments</returns>
    public static List<Attachment> CreateFormHandlerMailAttachments(Telerik.Web.UI.UploadedFileCollection uploadedFiles)
    {
      List<Attachment> attachments = new List<Attachment>();
      if (uploadedFiles.Count > 0)
      {
        foreach (Telerik.Web.UI.UploadedFile uploadedFile in uploadedFiles)
        {
          Attachment attachment = new Attachment(uploadedFile.InputStream, uploadedFile.FileName);
          attachments.Add(attachment);
        }
      }
      return attachments;
    }

    #endregion
  }
}
