namespace _04._Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = "{([])}";
            string str2 = "{([)]}";
            bracket brack = new bracket();
            if(brack.brackets(str1))
            {
                Console.WriteLine("1번 정답");
            }

            if (brack.brackets(str2))
                Console.WriteLine("2번 정답");

        }
    }
}