using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1ndTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Indicar destinos disponibles (1-n):");
            int numDestinos = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Indicar distribución: 1 (Round Robin), 2 (Aleatorio)");
            int distribucion = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Indicar el número de cargas consecutivas con el mismo destino:");
            int cargasConsecutivas = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Indicar el porcentaje de fallos al desviar la carga:");
            double porcentFallosDefindo = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Indicar el número de cargas para las que se debe seleccionar un destino:");
            int numCargas = Convert.ToInt16(Console.ReadLine());

            int destinoSelec = 1;
            int contadorCargas = 0;
            Random random = new Random();
            int[] destinoContador = new int[numDestinos + 1];

            for (int i = 0; i < numCargas; i++)
            {
                if (distribucion == 1) // Round Robin
                {
                    if (contadorCargas >= cargasConsecutivas)
                    {
                        destinoSelec++;
                        contadorCargas = 0;
                    }
                    if (destinoSelec > numDestinos) destinoSelec = 1; //Si se supera el número máximo de destinos, se reinicia al primer destino.
                }
                else if (distribucion == 2) // Aleatorio
                {
                    if (contadorCargas >= cargasConsecutivas)
                    {
                        destinoSelec = random.Next(1, numDestinos + 1); //se selecciona un nuevo destino al azar.
                        contadorCargas = 0;
                    }
                }

                contadorCargas++;

                double porcentFallado = random.NextDouble() * 100;   // generar un número aleatorio entre 0 y 100 para simular la posibilidad de fallo
                if (porcentFallado < porcentFallosDefindo) destinoContador[0]++; //falla. A mayor porcentFallosDefindo, más se dará la condición
                else destinoContador[destinoSelec]++; //no falla
            }

            Console.WriteLine("Resultados:");
            for (int i = 0; i < destinoContador.Length; i++)
            {
                double porcentaje = (double)destinoContador[i] / numCargas * 100;
                Console.WriteLine($"El {porcentaje:F2}% de las cargas llegan a destino destino {i}");
            }
            Console.ReadKey();
        }
    }

}
