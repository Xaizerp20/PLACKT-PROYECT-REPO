using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using manageRegistersApp.Models;
using MudBlazor;
using manageRegistersApp.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Google.Protobuf.WellKnownTypes;
using MailKit.Net.Smtp;
using MimeKit;

namespace manageRegistersApp.Services
{
    public class TimerBackgroundService : IHostedService, IDisposable
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ShiftService _shiftService;
        private readonly EmailsService _emailsService;
        private Timer timer;

      

        public static List<Shifts> listShifts = new List<Shifts>();
        public static Dictionary<int, TimeSpan> horasDeEnvio = new Dictionary<int, TimeSpan>();



        public bool IsRunning { get; private set; }


        public TimerBackgroundService(IWebHostEnvironment hostingEnvironment, ShiftService shiftService, EmailsService emailsService)
        {
            _hostingEnvironment = hostingEnvironment;
            _shiftService = shiftService;
            _emailsService = emailsService;
        }


        public async Task StartAsync(CancellationToken cancellationToken)
        {

            // Obtener las horas específicas en las que deseas ejecutar el método
            await ObtenerHorasEspecificas();

            Dictionary<int, TimeSpan> horasEspecificas = horasDeEnvio;

            Console.WriteLine("Estamos aqui: " + horasEspecificas.Count());

            // Crear un temporizador para ejecutar el método en las horas específicas
            timer = new Timer(async state => await VerificarEjecucion(state), null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

            IsRunning = true;

            //return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Dispose();
            IsRunning = false;
            return Task.CompletedTask;
        }

        private async Task DoWorkAsync(object state, int client_id)
        {
            string reportsFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "Reports/report_hotel.html"); //Ruta del html

            List<Email> emails = new List<Email>();

            // Aquí puedes poner el código que deseas ejecutar en determinadas horas
            // Por ejemplo, puedes llamar a otro método o realizar alguna acción


            // Dirección de correo electrónico del remitente
            string remitente = "placa4@manicatoerp.com";


            // Dirección de correo electrónico del destinatario
            //string destinatario = "xavierjp1220@hotmail.com";

            //busqueda de los emails por id del cliente
            emails = await _emailsService.GetEmailsByIdAsync(client_id);

            emails.ForEach(async destinatario =>
            {

                try
                {
                    await SendEmail(remitente, destinatario.email, destinatario.email_name, reportsFolderPath);
                    Console.WriteLine("Reporte enviado Correctamente");

                }

                catch (Exception)
                {
                    Console.WriteLine("Error al enviar el report");
                    return;
                }
            });
            Console.WriteLine("Método ejecutado a la hora determinada");
        }


        private async Task VerificarEjecucion(object state)
        {
           


            DateTime now = DateTime.Now;
            TimeSpan timeSpanNow = now.TimeOfDay;
            TimeSpan horaActual = new TimeSpan(timeSpanNow.Hours, timeSpanNow.Minutes, timeSpanNow.Seconds);


            Console.WriteLine("Hora actual: " + horaActual);

            //buscamos todos los turnos que conciden con la hora actual
            var foundHours = horasDeEnvio.Where(kvp => kvp.Value == horaActual);

            Console.WriteLine(foundHours.Count());

            foreach (KeyValuePair<int, TimeSpan> kvp in foundHours)
            {
                await DoWorkAsync(state, kvp.Key); //ejecutamos el meotodo pasando el cliente como parametro
                Console.WriteLine(kvp.Value);
            }

            Console.WriteLine("Ejecutado");

        }


        private async Task ObtenerHorasEspecificas()
        {


            List<TimeSpan> horasEspecificas = new List<TimeSpan>();

            listShifts = await _shiftService.GetShiftsAsync();


            /*

            //agregamos todos los horarios a un diccionario junto con su cliente 
            foreach (Shifts shift in listShifts)
            {
                horasDeEnvio.Add(shift.id, shift.Shift_End);
                horasEspecificas.Add(shift.Shift_End);
                Console.WriteLine("SHIFT END:" + shift.Shift_End.ToString());
            }
            */
        }


        public void Dispose()
        {
            timer?.Dispose();
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
