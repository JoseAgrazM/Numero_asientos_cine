namespace Numero_asientos_cine
{
    internal class Program
    {
        static char[,] asientos = new char[10, 10];

        static int numLibres = asientos.GetLength(0) * asientos.GetLength(1);

        static void Main(string[] args)
        {
            bool seguir = false;
            Asientos();

            do
            {
                int numFila = EligeFila();
                int numColumn = EligeColumna();

                Compra(asientos, numFila, numColumn);

                Asientos_Actualizados(asientos);

                Console.WriteLine($"\n Quedan {numLibres} asientos libres.");
                
                seguir = Seguir();


            } while (numLibres > 0 && !seguir);

            Console.ReadKey();
        }

        static void Asientos()
        {
            int posicionNum = 0;
            string linea = "";

            for (int i = 0; i < asientos.GetLength(1) * 2; i++)
            {
                linea += "-";
            }
            for (int i = 0; i < asientos.GetLength(1); i++)
            {
                posicionNum++;

            }

            Console.WriteLine($"\n Estos son los asientos Libres 'L' - Ocupados 'X' \n");
            Console.WriteLine($"Cual quieres comprar? \n");

            Console.WriteLine($"{linea}");

            for (int i = 0; i < asientos.GetLength(0); i++)
            {
                for (int j = 0; j < asientos.GetLength(1); j++)
                {
                    asientos[i, j] = 'L';

                    Console.Write(asientos[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static int EligeFila()
        {
            int numFila;
            do
            {
                Console.Write($"\n Elige el numero de Fila: ");
                string filaStr = Console.ReadLine();
                if (int.TryParse(filaStr, out numFila) && numFila <= asientos.GetLength(0))
                {
                    break;
                }
                else { Console.WriteLine($"\n Entrada invalida. Ingresa un valor entero, del 1 al {asientos.GetLength(0)}"); }
            } while (true);

            return numFila;
        }

        static int EligeColumna()
        {
            int numColumn;
            do
            {
                Console.Write($"\n Elige el numero de Columna: ");
                string columnStr = Console.ReadLine();

                if (int.TryParse(columnStr, out numColumn) && numColumn <= asientos.GetLength(1))
                {
                    break;
                }
                else { Console.WriteLine($"\n Entrada invalida. Ingresa un valor entero, del 1 al {asientos.GetLength(1)}"); }

            } while (true);

            return numColumn;
        }

        static void Compra(char[,] asientos, int fila, int columna)
        {
            Console.Clear();

            if (asientos[fila - 1, columna - 1] == 'L')
            {
                asientos[fila - 1, columna - 1] = 'X';
                numLibres--;
            }
            else if (asientos[fila - 1, columna - 1] == 'X')
            {
                Console.WriteLine("\n Lo siento, el asiento esta ocupado elige otro.");

            }
        }

        static char[,] Asientos_Actualizados(char[,] asientos)
        {
            Console.WriteLine($"\n Estos son los asientos Libres 'L' - Ocupados 'X' \n");
            Console.WriteLine($"Cual quieres comprar?\n");

            
            for (int i = 0; i < asientos.GetLength(0); i++)
            {
                for (int j = 0; j < asientos.GetLength(1); j++)
                {
                    Console.Write(asientos[i, j] + " ");
                }
                Console.WriteLine();
            }
            return asientos;
        }

        static bool Seguir()
        {
            string respuesta;
            do
            {
                if (numLibres == 0)
                {
                    Console.WriteLine("\n Lo siento se han agotado los asientos libres");

                    return true;
                }

                Console.WriteLine("\n Seguir comprando? \n");

                respuesta = Console.ReadLine().ToUpper();
                
                if (respuesta == "SI")
                {
                    return false;
                }
                else if (respuesta == "NO") 
                { 
                    return true; 
                }
                else
                {
                    Console.WriteLine("Entrada invalida. Responder 'SI' o 'NO'");
                }
            }while (respuesta != "SI" && respuesta != "NO");

            return true;
            
        }

    }
}