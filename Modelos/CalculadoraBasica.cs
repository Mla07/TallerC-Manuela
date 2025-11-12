using System;
namespace TallerPOO.Modelos
{
    public class CalculadoraBasica
    {   
        // Cuenta la cantidad de operaciones en la instancia de la clase
        // suma 1 operación por cada método llamado
        public static int ConteoOperaciones { get;  private set; }
        public double Sumar(double a,double b){ ConteoOperaciones++; return a+b; }
        public double Restar(double a,double b){ ConteoOperaciones++; return a-b; }
        public double Multiplicar(double a,double b){ ConteoOperaciones++; return a*b; }
        public double Dividir(double a,double b)
        {
            ConteoOperaciones++;
            if (b==0) throw new DivideByZeroException("División por cero");
            return a/b;
        }
    }
}
