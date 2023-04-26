namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary.Dictionary<int,string> dictionary = new Dictionary<int, string>();
            dictionary.Add( 1, "첫번째");
            dictionary.Add(2, "두번째");
            dictionary.Add(3, "세번째");
            dictionary.Remove(2);
            dictionary.Remove(3);
            Console.WriteLine(dictionary[2]);
            
        }
    }
}