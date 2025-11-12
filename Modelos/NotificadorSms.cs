using System;
namespace TallerPOO.Modelos
{
    // Se usa : para implementar una interfaz
    public class NotificadorSms : INotificable
    {
        public void Enviar(string mensaje) => Console.WriteLine($"[SMS] {mensaje}");
    }
}
