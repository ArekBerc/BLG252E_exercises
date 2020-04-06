using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {

            dLinkList deque = new dLinkList();

            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)); //path is in /bin/debug/netcoreapp3.1
            path = Directory.GetParent(Directory.GetParent(Directory.GetParent(path).FullName).FullName).FullName; // for finding the integer.txt nedd to look at paretn directory
            path = Path.Combine(path, "integers.txt");
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);

            foreach (string line in lines)
            {
                deque.Push(Int16.Parse(line)); //add to the tail of the D.L. list
            }


            foreach (var item in deque) {
                Console.WriteLine(item); // read them from head to tail
            }
        }
    }
}
