using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Juego de matriz binaria 

/* Condiciones 
 - Crear una matriz de 4 x 4 de ceros (matriz inicial).
 - El jugador tendrá 4 turnos para jugar
 - El jugador deberá indicar las coordenadas X Y del dígito que quiere cambiar de 0 a 1. Dicho dígito cambiará a 1 los ceros 
 que se encuentren en todas las direcciones posibles (arriba, abajo, izquierda, derecha)
 - Gana quien logre convertir todos los ceros de la matriz en unos*/

namespace ConJuego1
{
    class Program
    {
        //variable global, pública y estática que guarda matriz binaria 

        public static int[,] matriz = new int[4, 4]; //arreglo de tipo entero


        static void Main(string[] args)
        {
            int intentos = 4; //jugadas que tendrá disponible el jugador
            string num = string.Empty;  //variable que guarda la coordenada
            string[] intentosMatriz = new string[2];  //matriz que guarda las coordenadas ingresadas por el usuario. 

            while (intentos > 0)
            {
                verMatriz(matriz); //imprime la matriz 
                Console.WriteLine(); //salto de línea 
                Console.WriteLine("Escribe tu jugada (x , y) [Intento #" + intentos + "]");
                num = Console.ReadLine(); //lectura de la coordenada en este formato x, y
                Console.WriteLine(); //salto de línea 
                intentosMatriz = num.Split(','); //guarda cada posición que tenga una coma 
                setMatrizValue(Convert.ToInt32(intentosMatriz[0]), Convert.ToInt32(intentosMatriz[1])); //llama al método 

                intentos--; 
            }

            Console.WriteLine();
            Console.WriteLine("Juego terminado, el resultado es: ");
            Console.WriteLine();
            verMatriz(matriz);
            Console.ReadKey();
        }

        public static void setMatrizValue(int x, int y) //asigna a la matriz el valor de la jugada
        {
            if(x < 0 || x > 3 || y < 0 || y > 3) //valida que la coordenada va del 0 al 3
            {
                Console.WriteLine("Jugada inválida, ingrese valores válidos");
                return; //con este return se regresa al turno 
            }

            matriz[x, y] = 1; //en el eje donde el usuario haya ingresado la coordenada, el valor cambia a 1.

            int[] arriba = new int[2], izquierda = new int[2], derecha = new int[2], abajo = new int[2];

            arriba[0] = x - 1;
            arriba[1] = y;

            if((x - 1 ) >=0 && x - 1 <=3)
            {
                matriz[arriba[0], arriba[1]] = 1; 
            }

            izquierda[0] = x;
            izquierda[1] = y - 1;

            if ((y - 1) >= 0 && y - 1 <= 3)
            {
                matriz[izquierda[0], izquierda[1]] = 1;
            }

            derecha[0] = x;
            derecha[1] = y + 1;

            if ((y + 1) >= 0 && y + 1 <= 3)
            {
                matriz[derecha[0], derecha[1]] = 1;
            }

            abajo[0] = x + 1;
            abajo[1] = y;

            if ((x + 1) >= 0 && x + 1 <= 3)
            {
                matriz[abajo[0], abajo[1]] = 1;
            }

        }


        public static void verMatriz(int[,]matriz)
        {
            for(int i = 0; i<=3; i++)   //recorrer matriz de 4 x 4 y hacer la impresión. Del 0 al 3 son 4 posiciones 
            {
                for(int j = 0; j <=3; j++) //recorrer la dimensión del arreglo 
                {
                    Console.Write(matriz[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
