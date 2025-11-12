using System;
namespace TallerPOO.Modelos
{
    public class NotificadorSms : INotificable
    {
        public void Enviar(string mensaje) => Console.WriteLine($"[SMS] {mensaje}");
    }
}
