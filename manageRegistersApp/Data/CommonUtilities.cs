using HtmlAgilityPack;
using manageRegistersApp.Models;
using Microsoft.Extensions.Hosting.Internal;
using System.Net;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using manageRegistersApp.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using MailKit.Net.Smtp;
using MimeKit;
namespace manageRegistersApp.Data
{

    public class CommonUtilities
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly NavigationManager _navManager;
        private readonly ProtectedSessionStorage _sessionStorage;
        private ClaimsPrincipal _claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
        private readonly AuthenticationStateProvider _authenticationStateProvider;


        public CommonUtilities(IWebHostEnvironment hostingEnvironment, NavigationManager navigation, ProtectedSessionStorage sessionStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            _hostingEnvironment = hostingEnvironment;
            _navManager = navigation;
            _sessionStorage = sessionStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        //metodo para comprobar si el usuario tiene accesso a la pagina
        public Task IsUrlChangeAllowed(string clientName)
        {

            string url = _navManager.Uri; //url actual
            string page = url.Split("/")[4]; //pagina


            if (!url.Contains(clientName))
            {
                // Retonar al usuario a la pagina anterior
                _navManager.NavigateTo($"/{clientName}/{page}");

                Console.WriteLine("No tienes permiso para ver el contenido");
            }
            else
            {
                Console.WriteLine(" tienes permiso para ver el contenido");

            }

            return Task.CompletedTask;
        }

        //metodo para generr archivo html
        public Task GenerateIssueHtml(List<Issue> listIssues)
        {
            string reportsFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "Reports/report_issues_hotel.html"); //Ruta del html

            HtmlDocument reportHtml = new HtmlDocument();
            reportHtml.Load(reportsFolderPath); //carga los datos del html

            string newRowHtmlPending = "";
            string newRowHtmlResolve = "";

            foreach (var a in listIssues)
            {
                if (a.Status == "PENDING")
                {
                    newRowHtmlPending += $"<tr><td>{a.NumberPlate}</td><td>{a.Issue_Type}</td><td>{a.Open_Date}</td><td>{a.Description}</td></tr>";
                }
                else
                {
                    newRowHtmlResolve += $"<tr><td>{a.NumberPlate}</td><td>{a.Issue_Type}</td><td>{a.Open_Date}</td><td>{a.Description}</td><td>{a.Resolve_Date}</td></tr>";
                }

            }

            return Task.CompletedTask;
        }

        public async Task<string> GenerateHtmlArrivals(List<RegisterArrivals> arrivalsList)
        {

            string reportsFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "Reports/report_hotel.html"); //Ruta del html

            HtmlDocument reportHtml = new HtmlDocument();
            reportHtml.Load(reportsFolderPath); //carga los datos del html

            string newRowHtml = "";

            foreach (var a in arrivalsList)
            {

                newRowHtml += $"<tr><td>{a.NumberPlate}</td><td>{a.Room}</td><td>{a.Date}</td></tr>";

            }

            AddRow(reportHtml, newRowHtml, 1);
            string htmlGenerated = reportHtml.DocumentNode.OuterHtml; //genera el html completo

            using (StreamWriter file = new StreamWriter(reportsFolderPath))
            {
                try
                {
                    await file.WriteLineAsync(htmlGenerated);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }

            return reportsFolderPath;

        }

        //add rows to html document
        public void AddRow(HtmlDocument html, string DataRow, int repeat)
        {
            HtmlNode tableBody = html.DocumentNode.SelectSingleNode("//tbody");

            tableBody.InnerHtml = string.Empty; //limpia la tabla


            // Verificar si se encontró el elemento
            if (tableBody != null)
            {

                tableBody.InnerHtml = DataRow;
            }

            else
            {
                // El elemento no se encontró
                Console.WriteLine("El elemento no se encontró.");
            }

        }


        //metodo para enviar emails
        public async Task SendEmail(string rem, string dest, string dest_name, string attachFolder)
        {

        

            //datos del servidor
            string host = "mail.manicatogroup.com";
            int port = 465;
            string pass = "Manicato@26392801";

            //constructor del mensajr
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("PLACKAT", rem));
            message.To.Add(new MailboxAddress(dest_name, dest));
            message.Subject = "Reporte de Hotel";

            //agregar html al mensaje
            var builder = new BodyBuilder();
            builder.Attachments.Add(attachFolder); //attach html to email
            message.Body = builder.ToMessageBody();

            //envio del email
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(host, port, true);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(rem, pass);

                    await client.SendAsync(message);
                    client.Disconnect(true);
                    Console.WriteLine("Correo electrónico enviado correctamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al enviar el correo electrónico: " + ex.Message);
                    Console.WriteLine(ex.ToString());
                    return;
                }

            }

        }
    }
}
