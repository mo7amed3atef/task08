namespace SearchTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter a word:");
                string s = Console.ReadLine();

                Check(s);

                Console.WriteLine("Vowels found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Check(string s)
        {
            if (!s.Contains("a") && !s.Contains("e") &&
                !s.Contains("i") && !s.Contains("o") &&
                !s.Contains("u"))
            {
                throw new Exception("No vowels");
            }
        }
    }
    
}
