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
        }
    }
}