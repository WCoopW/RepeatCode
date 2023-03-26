using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatCode
{
    internal class Program
    {
        static double[] Probality = new double[] { 0.06, 0.13, 0.2 };
        static void Main(string[] args)
        {
            var hamm = new Hamming();
            Console.WriteLine("Введите двоичный код из 5 битов");
            var plainText = CreateByte(5);
            Console.WriteLine("Введите двоичный код из 11 битов");
            var plainText2 = CreateByte(11);
            try
            {
                if (plainText == null || plainText2 == null)
                {
                    throw new Exception("Ошибка ввода.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Вероятность ошибки на сообщение в повторном коде при вероятности ошибки на бит:");
            for(int i = 0; i < Probality.Length; i++)
            {
                Console.WriteLine($"{Probality[i]}: {TripleErrorProbability(Probality[i])}");
            }
            Console.WriteLine("Вероятность ошибки на сообщение в коде Хэмминга при вероятности ошибки на бит: ");
            for(int i = 0; i < Probality.Length; i++)
            {
                Console.WriteLine($"{Probality[i]}: {hamm.HammingCodeError(15,11, Probality[i])}");
            }
            
            
         
            //Console.WriteLine(k.HammingCodeError(15, 11, 0.66));
            //Console.WriteLine(TripleErrorProbability(0.66));
            Console.ReadLine();
        }
        static string Thriple(string plaintext)
        {
            plaintext += plaintext + plaintext;
            return plaintext;
        }
        static double TripleErrorProbability(double p)
        {
            double errorProbability = 3 * Math.Pow(p, 2) * (1 - p) + Math.Pow(p, 3);
            return errorProbability;
        }
        public static string CreateByte(int n)
        {
            var hamm = new Hamming();
            byte[] HammCode = new byte[15];
            var text = Console.ReadLine();

            var chars = text.ToCharArray();
            if (text.Length == n)
            {
                
                foreach (char c in chars )
                {
                    var b = Char.GetNumericValue(c);
                    if (b != 0 && b != 1)
                    {
                        return null;
                    }      
                }
                if (n == 5)
                {
                    Console.WriteLine("Закодированное сообщение: " + Thriple(text));
                    return text;
                }
                var HammByte = hamm.Code(text);
                Console.WriteLine("Сообщение закодированное кодом Хэмминга: ");
                for (int i = 0; i < 15; i++)
                {
                    HammCode[i] = Convert.ToByte(HammByte[i]);
                    Console.Write(HammCode[i]);
                   
                }
                Console.WriteLine();
                return text;
            }
            return null;


        }


    }

}
