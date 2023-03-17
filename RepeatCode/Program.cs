using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Thriple("str"));
            Console.ReadLine();
        }
        static string Thriple(string plaintext)
        {
            plaintext += " " + plaintext +" "+ plaintext;
            return plaintext;
        }
    }
   
}
