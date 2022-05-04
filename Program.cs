using System;
using System.Collections;
using System.Threading;

namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("S = Segundo => 10s = 10 segundos");
            Console.WriteLine("M = Minuto => 1m = 1 minuto");
            Console.WriteLine("0 = Sair");
            Console.WriteLine("Quanto tempo deseja contar?");
            
            string data = Console.ReadLine().ToLower();

            if(data.Length == 1 && data=="0")
                System.Environment.Exit(0);
            

            char type = 's';
            int time = 0;

            try{
                time = int.Parse(data.Substring(0, data.Length - 1));
                type = char.Parse(data.Substring(data.Length - 1, 1));
            }catch(FormatException){
                Console.Clear();
                Console.WriteLine("Comando inválido, pressione qualquer tecla para continuar.");
                Console.ReadKey();
                Menu();
            }catch(ArgumentOutOfRangeException){
                Console.Clear();
                Console.WriteLine("Comando inválido, pressione qualquer tecla para continuar.");
                Console.ReadKey();
                Menu();
            }

            Console.WriteLine(type);

            switch(type)
            {
                case 'm': break;
                case 's': break;
                default: 
                Console.Clear();
                Console.WriteLine("Comando inválido, pressione qualquer tecla para continuar.");
                Console.ReadKey();
                Menu(); break;
            }

            int multiplier = 1;

            if(type == 'm')
                multiplier = 60;

            if(time==0)
                System.Environment.Exit(0);

            PreStart(time*multiplier);
        }

        static void PreStart(int time)
        {
            Console.Clear();
            Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            Console.WriteLine("Set...");
            Thread.Sleep(1000);
            Console.WriteLine("Go!");
            Thread.Sleep(1000);

            Start(time);
        }

        static void Start(int time)
        {
            int currentTime = time;

            while(currentTime!=0)
            {
                    Console.Clear();
                    Console.WriteLine(currentTime);
                    Console.WriteLine("P = pausar");
                    Console.WriteLine("X = finalizar");

                    if(Console.KeyAvailable)
                    {
                        ConsoleKeyInfo ki = Console.ReadKey(true);
                        
                        if(ki.Key == ConsoleKey.P)
                        {
                            Console.Clear();
                            Console.WriteLine(currentTime);
                            Console.WriteLine("Stopwatch pausado, pressione qualquer tecla para continuar.");
                            Console.ReadKey();
                            continue;
                        }
                        else
                        if(ki.Key == ConsoleKey.X)
                        {
                            Console.Clear();
                            Console.WriteLine(currentTime);
                            Console.WriteLine("Stopwatch finalizado, pressione qualquer tecla para continuar.");
                            Console.ReadKey();
                            Menu();
                            break;
                        }
                    } 
                    
                    Thread.Sleep(1000);
                    currentTime--;
            }

            Console.Clear();
            Console.WriteLine("Stopwatch finalizado, pressione qualquer tecla para continuar.");
            Console.ReadKey();
            Menu();
        }
    }
}
