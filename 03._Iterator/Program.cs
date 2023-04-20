using static System.Net.Mime.MediaTypeNames;

namespace _03._Iterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Iterator.List<int> list = new Iterator.List<int>();
            Iterator.LinkedList<int> llist = new Iterator.LinkedList<int>();
            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
                llist.AddLast(i);
            }

            foreach (int i in list)
            {
                Console.WriteLine(i);
            }

            foreach (int i in llist)
            {
                Console.WriteLine(i);
            }
        }
    }
}