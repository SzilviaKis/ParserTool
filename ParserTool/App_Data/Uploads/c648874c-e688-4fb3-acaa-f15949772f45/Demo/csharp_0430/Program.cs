using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * "Készítsen függvényt, amely két kétdimenziós tömbből előállít egy harmadikat úgy, 
 * hogy az eredménytömb minden egyes cellájában a bemenő tömbök azonos indexen lévő 
 * celláin található értékek közül a nagyobb szerepeljen!""
+1: Egészítse ki a feladatot úgy, hogy a függvény egy hamis értéket adjon vissza, 
ha a két tömb nem azonos méretű!"
*/

namespace csharp_0430
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            

            int[,] array1 = new int[a, b];
            int[,] array2 = new int[c, d];
            int[,] array3;
            int filledTheThirdArray = array3.Length; 


            
        }
        static void RandomGenerator(int[] args)
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    array[i, j] = rnd.Next(10, 99);
                    
                }
                Console.WriteLine(" ");
            }
            Console.ReadLine();
        }
        static void SearchBigger(int[] args)
        {
            for (int i = 0; i < length; i++)
            {
                int[,] array3 = int
            }
            for (int k = 0; k < n; k++)
            { Console.Write(a[k] + ", "); }
            for (int j = 0; j < n - 1; j++)
            {
                if (a[j] > a[j + 1])
                {
                    tmp = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = tmp;
                }
            }
            Console.WriteLine();
            for (int k = 0; k < n; k++) { Console.Write(a[k] + ", "); }

        }
        static void SameSizeOrNot(int[] args)
        {
            if (a == b)
            {

            }
            else
            {
                Console.WriteLine();
            }
        }/**/
        static int Max(int[] array)
        {
            int maxValue = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if(array[i] > maxValue)
                {
                    maxValue = array[i];
                }
            }
            return maxValue;

            
        }
    }
}

