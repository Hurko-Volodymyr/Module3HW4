using Delegates_with_LINQ.Core;

namespace Events_with_LINQ
{
    internal class Program
    {
        public event Func<int, int, int>? DoSum;
        public int Sum(int x, int y) => x + y;
        public void TryCatchMethod(int x, int y)
        {
            try
            {
                Console.WriteLine(DoSum?.Invoke(x, y));
            }
            catch (Exception)
            {
                throw new Exception(nameof(DoSum));
            }
        }

        private static void Main(string[] args)
        {
            var program = new Program();
            var x = 1;
            var y = 2;
            var a = 3;
            var b = 4;

            program.DoSum = program.Sum;
            program.DoSum += program.Sum;
            program.TryCatchMethod(program.DoSum(x, y), program.DoSum(a, b));

            var collection = new List<Contact>
            {
                new Contact { FirstName = "Сулейман", LastName = "Фамилия2", Number = 380123123122 },
                new Contact { FirstName = "89462-386=263", LastName = "7543747", Number = 387430123123122 },
                new Contact { FirstName = "Зита", LastName = "Фамилия4", Number = 380123123124 },
                new Contact { FirstName = "Sara", LastName = "Фамилия3", Number = 380123123123 },
                new Contact { FirstName = "Abdula", LastName = "Фамилия1", Number = 380123123121 },
                new Contact { FirstName = "gawegw", LastName = "awhr" }
            };

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            var sortedByDesNumberCollection = collection.OrderBy(x => x.Number).Reverse();
            var firstOrDefaultItem = sortedByDesNumberCollection.Skip(3).FirstOrDefault();
            var numberList = sortedByDesNumberCollection.Select(x => x.Number).Where(x => x.HasValue);

            foreach (var item in sortedByDesNumberCollection)
            {
                Console.WriteLine($" Sorted: {item}");
            }

            Console.WriteLine($"          False first: {firstOrDefaultItem}");
            foreach (var item in numberList)
            {
                Console.WriteLine($"               Number is: {item}");
            }
        }
    }
}