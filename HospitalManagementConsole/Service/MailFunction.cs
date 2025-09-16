using HospitalManagementConsole.Menu;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace HospitalManagementConsole.Service
{
    // Function class for Sending Email
    internal static class Mailer
    {
        internal static async Task MailFunction(string name, string email, string doctorName, int appointmentId)
        {
            try
            {
                // Config about gmail Mail System
                string appPassword = Environment.GetEnvironmentVariable("GMAIL_APP_PASSWORD") ?? "jngbbcnpsyfmopsf";

                // Get direct data from appointment
                List<Appointment> apps = FileManager.LoadAppointmentsData();
                Appointment app = GenericHelper.FindById<Appointment>(apps, appointmentId);
                string appContent = "Doctor Name: " + doctorName;

                // Mail body
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress("Administrator", "admin@hospital.com"));
                message.To.Add(new MailboxAddress(name, email));
                message.Subject = "Notice Mail - Confirmation of booking Appointment with " + doctorName;
                message.Body = new TextPart("plain")
                {
                    // Mail content
                    Text = String.Format("Dear {0}\n\nThanks for your booking appointment with {1}\n" +
                                         "The appointment information is as below:\n\n{2}\n\n" +
                                         "Please make sure your detail information. Thanks.\n\n" +
                                         "Sincerely,\nHospital Management", name, doctorName, appContent)
                };

                // using smtp to send mail
                using (SmtpClient smtp = new SmtpClient())
                {
                    await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    await smtp.AuthenticateAsync("u100034017@gmail.com", appPassword); // By config
                    await smtp.SendAsync(message);
                    await smtp.DisconnectAsync(true);
                }
            }
            catch (Exception e)
            {
                // Mail function exception
                Console.WriteLine("Error Occurred in Mail Function: " + e.Message);
            }
        }
    }
} 
