using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        const int NB_QUESTION = 5;
        const int MIN = 0;
        const int MAX = 10;
        static Random random = new Random();

        enum OPERATEUR
        {
            ADDITION,
            MULTIPLICATION,
            DIVISION
        }

        private static OPERATEUR GetOperator()
        {
            int operateur = random.Next(1, 4);
            if (operateur ==1)
            {
                return OPERATEUR.ADDITION;
            }
            else if (operateur == 2)
            {
                return OPERATEUR.MULTIPLICATION;
            }

            return OPERATEUR.DIVISION;

        }
        private static bool GetOperation()
        {
            
            
            int a = random.Next(MIN, MAX);
            int b = random.Next(MIN, MAX);
            OPERATEUR operateur = GetOperator();
            
            int s = 0;
            string signe = "";

            if (operateur == OPERATEUR.ADDITION)
            {
                s = a + b;
                signe = "+";
            }
            else if (operateur == OPERATEUR.MULTIPLICATION)
            {
                s = a * b;
                signe = "*";
            }
            else if (operateur == OPERATEUR.DIVISION)
            {
                s = a / b;
                signe = "/";
            }

            

            while (true)
            {
                Console.Write($"{a} {signe} {b} = ");
                String ansUser = Console.ReadLine();

                int ans = 0;
                if (int.TryParse(ansUser, out ans))
                {
                    if (ans == s)
                    {
                        Console.WriteLine("Félicitation mon poto");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Oups! game over");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("!!! Seul les nombres sont pris en charge !");
                }
            }
            
            
        }

        private static void AfficherResulta(int points)
        {
            Console.WriteLine($"Note : {points} / {NB_QUESTION} ");
            if (points == NB_QUESTION)
            {
                Console.WriteLine("Big deal man");
            } 
            else if (points == 0  )
            {
                Console.WriteLine("Faiblar");
            }
            else if (points <= (NB_QUESTION/2))
            {
                Console.WriteLine("Peu mieux faire");
            }
            else
            {
                Console.WriteLine("Pas mal");
            }
        }
        
        
        
        static void Main(string[] args)
        {
            
            int points = 0;
            
            for (int i = 0; i < NB_QUESTION; i++)
            {
                Console.WriteLine($"Question n° {i+1} / {NB_QUESTION}");
                if (GetOperation())
                {
                    points += 1;
                }
                
            }

            AfficherResulta(points);

        }
    }
}