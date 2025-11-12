using System;
namespace TallerPOO.Modelos
{   
    // Se usa : para implementar una interfaz
    public class NotificadorEmail : INotificable
    {
        public void Enviar(string mensaje) => Console.WriteLine($"[EMAIL] {mensaje}");
    }
}
