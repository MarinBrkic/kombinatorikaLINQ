using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kombinatorikaLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Sve znamenke od 1 do 9
            var digits = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Generiraj sve permutacije i provjeri uvjete djeljivosti koristeći LINQ
            var result = GetPermutations(digits, digits.Count)
                .Select(perm => perm.ToArray())
                .FirstOrDefault(number => IsValidPandigital(number));

            if (result != null)
            {
                Console.WriteLine("Traženi broj je: " + string.Join("", result));
            }

            Console.ReadKey();
        }

        // Funkcija za provjeru uvjeta djeljivosti
        static bool IsValidPandigital(int[] number)
        {
            return Enumerable.Range(1, number.Length)
                             .All(i => int.Parse(string.Join("", number.Take(i))) % i == 0);
        }

        // Funkcija za generiranje permutacija
        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                            (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
