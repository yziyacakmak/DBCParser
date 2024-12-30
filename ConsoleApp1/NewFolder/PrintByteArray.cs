using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.NewFolder
{
    internal static class PrintByteArray
    {
        public static void Print(byte[] data)
        {

            int fancount = 3;
            int fandutycount = 2;
            int ledcount = 10;
            int outputcount = 12;
            int inputcount = 15;
            int i = 0;
            int anahtarcount = 12;

            if (i == 0) { Console.Write($"{"0x" + data[i++].ToString("x")}"); Console.WriteLine("  //MSG ID "); }
            if (i == 1) { Console.Write($"{"0x" + data[i++].ToString("x")}"); Console.WriteLine("  //BIRIM "); }
            for (int j = 0; j < fancount; j++) { Console.Write($"{"0x" + data[i++].ToString("x")}"); Console.WriteLine($"  //fan{j + 1} "); }
            for (int j = 0; j < fandutycount; j++) { Console.Write($"{"0x" + data[i++].ToString("x")}"); Console.WriteLine($"  //fan duty{j + 1} "); }

            Console.Write($"{"0x" + data[i++].ToString("x")}"); Console.WriteLine($"  //gyb ");
            Console.Write($"{"0x" + data[i++].ToString("x")}"); Console.WriteLine($"  //saeb ");
            Console.Write($"{"0x" + data[i++].ToString("x")}"); Console.WriteLine($"  //sab ");
            Console.Write($"{"0x" + data[i++].ToString("x")}"); Console.WriteLine($"  //ttl ");

            for (int j = 0; j < ledcount; j++) { Console.Write($"{"0x" + data[i++].ToString("x")}"); Console.WriteLine($"  //led{j + 1} "); }

            for (int j = 0; j < outputcount; j++) { Console.Write($"{"0x" + data[i++].ToString("x")}"); Console.WriteLine($"  //output{j + 1} "); }

            for (int j = 0; j < inputcount; j++) { Console.Write($"{"0x" + data[i++].ToString("x")}"); Console.WriteLine($"  //input{j + 1} "); }

            Console.Write($"{"0x" + data[i++].ToString("x")}"); Console.WriteLine($"  //reserved ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.WriteLine($"  //temperature1 ");

            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.WriteLine($"  //temperature2 ");


            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.WriteLine($"  //AC Voltage ");


            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.WriteLine($"  //AC Current ");


            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.WriteLine($"  //DC IN 1 ");


            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.WriteLine($"  //DC IN 2 ");


            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.WriteLine($"  //DC IN 3 ");


            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.WriteLine($"  //DC IN 4 ");


            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.WriteLine($"  //anahtar threshold ");


            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.WriteLine($"  //gyb threshold ");


            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.WriteLine($"  //sab threshold ");


            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.WriteLine($"  //saeb threshold ");


            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.WriteLine($"  //ui threshold ");

            for (int j = 0; j < anahtarcount; j++)
            {

                Console.Write($"{"0x" + data[i++].ToString("x")} ");
                Console.Write($"{"0x" + data[i++].ToString("x")} ");
                Console.Write($"{"0x" + data[i++].ToString("x")}");
                Console.WriteLine($"  //anahtar{j + 1} timestamp ");
            }

            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")}");
            Console.WriteLine($"  //gyb timestamp ");


            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")}");
            Console.WriteLine($"  //sab timestamp ");


            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")}");
            Console.WriteLine($"  //saeb timestamp ");

            for (int j = 0; j < anahtarcount; j++)
            {

                Console.Write($"{"0x" + data[i++].ToString("x")} ");
                Console.Write($"{"0x" + data[i++].ToString("x")}");
                Console.WriteLine($"  //anahtar{j + 1} value ");
            }

            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")}");
            Console.WriteLine($"  //gyb value ");


            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")}");
            Console.WriteLine($"  //sab value ");


            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")}");
            Console.WriteLine($"  //saeb value ");


            Console.Write($"{"0x" + data[i++].ToString("x")} ");
            Console.Write($"{"0x" + data[i++].ToString("x")}");
            Console.WriteLine($"  //ui value ");

            for (int j = 0; j < anahtarcount; j++)
            {
                Console.Write($"{"0x" + data[i++].ToString("x")}");
                Console.WriteLine($"  //anahtar{j + 1} flag ");
            }

            Console.Write($"{"0x" + data[i++].ToString("x")}");
            Console.WriteLine($"  //gyb flag ");

            Console.Write($"{"0x" + data[i++].ToString("x")}");
            Console.WriteLine($"  //sab flag ");

            Console.Write($"{"0x" + data[i++].ToString("x")}");
            Console.WriteLine($"  //saeb flag ");


            for (int j = 0; j < anahtarcount; j++)
            {
                Console.Write($"{"0x" + data[i++].ToString("x")}");
                Console.WriteLine($"  //anahtar{j + 1} response ");

                Console.Write($"{"0x" + data[i++].ToString("x")}");
                Console.Write($"{" 0x" + data[i++].ToString("x")}");
                Console.Write($"{" 0x" + data[i++].ToString("x")}");
                Console.Write($"{" 0x" + data[i++].ToString("x")}");
                Console.WriteLine($"  //anahtar{j + 1} mode response ");


                Console.Write($"{"0x" + data[i++].ToString("x")}");
                Console.Write($"{" 0x" + data[i++].ToString("x")}");
                Console.Write($"{" 0x" + data[i++].ToString("x")}");
                Console.Write($"{" 0x" + data[i++].ToString("x")}");
                Console.WriteLine($"  //anahtar{j + 1} current response1 ");

                Console.Write($"{"0x" + data[i++].ToString("x")}");
                Console.Write($"{" 0x" + data[i++].ToString("x")}");
                Console.Write($"{" 0x" + data[i++].ToString("x")}");
                Console.Write($"{" 0x" + data[i++].ToString("x")}");
                Console.WriteLine($"  //anahtar{j + 1} current response2 ");

                Console.Write($"{"0x" + data[i++].ToString("x")}");
                Console.Write($"{" 0x" + data[i++].ToString("x")}");
                Console.Write($"{" 0x" + data[i++].ToString("x")}");
                Console.Write($"{" 0x" + data[i++].ToString("x")}");
                Console.WriteLine($"  //anahtar{j + 1} current response3 ");

                Console.Write($"{"0x" + data[i++].ToString("x")}");
                Console.Write($"{" 0x" + data[i++].ToString("x")}");
                Console.Write($"{" 0x" + data[i++].ToString("x")}");
                Console.Write($"{" 0x" + data[i++].ToString("x")}");
                Console.WriteLine($"  //anahtar{j + 1} temperature response ");

                Console.Write($"{"0x" + data[i++].ToString("x")}");
                Console.Write($"{" 0x" + data[i++].ToString("x")}");
                Console.Write($"{" 0x" + data[i++].ToString("x")}");
                Console.Write($"{" 0x" + data[i++].ToString("x")}");
                Console.WriteLine($"  //anahtar{j + 1} error data response ");

                Console.Write($"{"0x" + data[i++].ToString("x")}");
                Console.Write($"{" 0x" + data[i++].ToString("x")}");
                Console.Write($"{"  0x" + data[i++].ToString("x")}");
                Console.Write($"{"  0x" + data[i++].ToString("x")}");
                Console.WriteLine($"  //anahtar{j + 1} config data response ");


                Console.Write($"{"0x" + data[i++].ToString("x")}");
                Console.Write($"{"  0x" + data[i++].ToString("x")}");
                Console.Write($"{"  0x" + data[i++].ToString("x")}");
                Console.Write($"{"  0x" + data[i++].ToString("x")}");
                Console.WriteLine($"  //anahtar{j + 1} enter bootloader command ");

                Console.Write($"{"0x" + data[i++].ToString("x")}");
                Console.Write($"{"  0x" + data[i++].ToString("x")}");
                Console.Write($"{"  0x" + data[i++].ToString("x")}");
                Console.Write($"{"  0x" + data[i++].ToString("x")}");
                Console.WriteLine($"  //anahtar{j + 1} channel fb");
            }
        }



        public static void GiveByteArray(string raw)
        {
            var chars = raw.Split(' ');
            StringBuilder sb = new StringBuilder();

            sb.Append("byte[] data = new byte[]{");
            for (int i = 0; i < chars.Length; i++)
            {
                sb.Append($"0x{chars[i]}");
                if (!(i == chars.Length - 1))
                {
                    sb.Append(',');
                }

            }
            sb.Append('}');
            sb.Append(';');
            Console.WriteLine(sb.ToString());

        }
    }
}
