using System;
using System.Diagnostics;

namespace MontecarloAlgoritmo
{
    class Program
    {

        public static void Main(string[] args)
        {
            double tam = 0;

            for (int i = 1; i <= 8; i++) // Cuanto más grande sea el círculo (más se incremente i), más preciso será pi
            {
                tam = Math.Pow(10, i);
                // USAMOS DOS OPCIONES CASI IGUALES PERO NO IGUALES PARA QUE SEA VISIBLE Y NOTORIO
                // QUE ES COMPLETAMENTE ALEATORIO Y QUE EN CADA EJECUCIÓN CAMBIA
                Console.WriteLine("\n\n=============== PI CON CIRCULO DE TAM " + i + " ===============");
                Console.WriteLine(" | Resultado 1: " + montePI(tam, 1));
                Console.WriteLine(" | Resultado 2: " + montePI(tam, 2));
            }
        }

        /*

        El algoritmo de montecarlo a grandes rasgos funciona de la siguiente manera:

        1. Dibuja un círculo unitario, y al cuadrado de lado 2 que lo inscribe.
        2. Lanza un número n de puntos aleatorios uniformes dentro del cuadrado.
        3. Cuenta el número de puntos dentro del círculo, (puntos distancia al origen < 1)
        4. El cociente de los puntos dentro del círculo dividido entre n es un estimado de pi
        5. Multiplica el resultado por 4 para estimar pi.

        */

        public static double montePI(double tam, int opc)
        {
            double i = 0; // Iterador bucle
            double dentro = 0; // Cuantos puntos están dentro del supuesto círculo
            double pi = 0; // PI estimado
            double x = 0; // Coordenada x
            double y = 0; // Coordenada y

            if (opc == 1)
            {
                Stopwatch timeMeasure = new Stopwatch();
                timeMeasure.Start();

                while (i < tam)
                {
                    // Generamos un punto aleatorio en (x,y)
                    x = generadorAleatorio();
                    y = generadorAleatorio();

                    if ((x * x) + (y * y) < 1)
                    { // Si el punto está dentro del círculo contador ++
                        dentro++;
                    }
                    i++;
                }
                timeMeasure.Stop();

                TimeSpan ts = timeMeasure.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10); // Medimos tiempo de ejcución
                Console.Write("Tiempo de ejecución de la opc 1: " + elapsedTime);
            }
            else // Mismo pero con for
            {
                Stopwatch timeMeasure = new Stopwatch();
                timeMeasure.Start();

                for (i = 0; i < tam; i++)
                {
                    x = generadorAleatorio();
                    y = generadorAleatorio();

                    if ((x * x) + (y * y) < 1)
                    {
                        dentro++;
                    }
                }
                timeMeasure.Stop();

                TimeSpan ts = timeMeasure.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                Console.Write("Tiempo de ejecución de la opc 2: " + elapsedTime);
            }


            // El cociente * 4 de los puntos dentro del círculo entre en es pi
            pi = 4 * (dentro / tam);
            return pi;
        }

        public static double generadorAleatorio() // Número aleatorio entre 0.0 - 1.0
        {
            Random random = new Random();
            return random.NextDouble();
        }
    }
}
