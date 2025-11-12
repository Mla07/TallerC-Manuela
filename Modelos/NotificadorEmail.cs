using System;
namespace TallerPOO.Modelos
{
    public class NotificadorEmail : INotificable
    {
        public void Enviar(string mensaje) => Console.WriteLine($"[EMAIL] {mensaje}");
    }
}
