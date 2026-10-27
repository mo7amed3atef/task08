namespace searchTask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<int> numbers = new List<int>();

                Console.WriteLine("Enter 5 numbers:");

                for (int i = 0; i < 5; i++)
                {
                    int number;
                    number = Convert.ToInt32(Console.ReadLine());

                    if (numbers.Contains(number))
                    {
                        throw new Exception("Duplicate number found!");
                    }

                    numbers.Add(number);
                }

                Console.WriteLine("No duplicates found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
