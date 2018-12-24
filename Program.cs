using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace SPL
{
    class Automobile : IComparable<Automobile>
    {
        public class NameComparer : IComparer<Automobile>
        {
            public int Compare(Automobile x, Automobile y)
            {
                return x.Title.ToLower().CompareTo(y.Title.ToLower());
            }
        }
        public int Price { get; set; }
        public string Title { get; set; }

        public int CompareTo(Automobile other)
        {
            return other.Price.CompareTo(Price);
        }


    }



    public static class QSort
    {
        public static IEnumerable<T> QuickSort<T>(this IEnumerable<T> list, IComparer<T> cmp = null) where T : IComparable<T>
        {
            if (!list.Any())
                return Enumerable.Empty<T>();

            var pivot = list.First();
            var left = list.Skip(1).Where(item => cmp == null ? (item.CompareTo(pivot) <= 0) : cmp.Compare(item, pivot) <= 0).QuickSort();
            var right = list.Skip(1).Where(item => cmp == null ? (item.CompareTo(pivot) > 0) : cmp.Compare(item, pivot) > 0).QuickSort();

            return left.Concat(new[] { pivot }).Concat(right);
        }
    }

    class Program
    {
        class RequeridTasks
        {

            public async Task QSorting()
            {
                string raw_data = System.IO.File.ReadAllText(@"data_source.txt");

                var gamersList = JsonConvert.DeserializeObject<List<Automobile>>(raw_data);

                var sorted = gamersList.QuickSort();

                Console.WriteLine("QSorting TASK");
                Console.WriteLine(String.Join("", sorted.Select(i => $"\nName: {i.Title}\nScore: {i.Price}\n---")));
                Console.WriteLine();

            }


            enum SnakeDirrection
            {
                Left, Right, Up, Down
            }

            public void Snake(int n, int m)
            {
                Console.WriteLine("SNAKE");

                var matrix = new int[n, m];

                var dirrect = SnakeDirrection.Right;

                int i = 0, j = 0;

                int rl = m, ll = 0, ul = 0, dl = n;

                for (int k = 0; k < matrix.Length; k++)
                {
                    matrix[i, j] = k;
                    //  Console.Write($"{matrix[i, j]} ");

                    switch (dirrect)
                    {
                        case SnakeDirrection.Right:
                            if (j == rl - 1)
                            {
                                dirrect = SnakeDirrection.Down;
                                rl--;
                                i++;
                            }
                            else
                                j++;
                            break;
                        case SnakeDirrection.Left:
                            if (j == ll)
                            {
                                dirrect = SnakeDirrection.Up;
                                ll++;
                                i--;
                            }
                            else
                                j--;
                            break;
                        case SnakeDirrection.Up:
                            if (i == ul + 1)
                            {
                                dirrect = SnakeDirrection.Right;
                                ul++;
                                j++;
                            }
                            else
                                i--;
                            break;
                        case SnakeDirrection.Down:
                            if (i == dl - 1)
                            {
                                dirrect = SnakeDirrection.Left;
                                dl--;
                                j--;
                            }
                            else
                                i++;
                            break;
                    }
                }
                for (int l = 0; l < n; l++)
                {
                    for (int k = 0; k < m; k++)
                    {
                        Console.Write($"{matrix[l, k]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            public class Document : IComparable<Document>
            {
                public string Title { get; set; }
                public string Text { get; set; }
                public int? Rank { get; set; }

                public int CompareTo(Document other)
                {
                    if (Rank == null)
                    {
                        return Title.CompareTo(other.Title);
                    }
                    else
                    {
                        return ((int)other.Rank).CompareTo(((int)Rank));
                    }
                }
                public override string ToString()
                {
                    return $"\n{Title}\nRank: {Rank ?? -1}";
                }
            }

            public void RankingOfDocuments(string word)
            {
                string raw_data = System.IO.File.ReadAllText(@"data_source_docs.txt", System.Text.Encoding.UTF8);
                var w = word.ToLower();

                var docs = JsonConvert.DeserializeObject<List<Document>>(raw_data);

                Console.WriteLine($"RankingOfDocuments\nФраза ранжирования: {word}\n");

                var res = docs.Select(d =>
                {
                    d.Rank = d.Text.Split(new string[] { word.ToLower() }, StringSplitOptions.None).Count() - 1;
                    return d;
                }).QuickSort();


                foreach (var d in res)
                    Console.WriteLine(d);

            }


        }

        static void Main(string[] args)
        {

            var rt = new RequeridTasks();

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            rt.QSorting();

            rt.Snake(5, 5);

            rt.RankingOfDocuments("он не");

            Console.ReadKey();

        }
    }
}
