using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Targil1_2Amiti
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = -1;
            bool[,] tab = new bool[12, 31];

            do
            {
                //ask the user to make a choice
                Console.WriteLine(" to reserve days typing 1 \n to see availability typing 2 \n to see year's data typing 3");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {

                    case 1:
                        if (AddDay(tab))
                            Console.WriteLine("Your days are reserved");
                        else
                            Console.WriteLine("this days are already full");
                        break;

                    case 2:
                        PrintTab(tab);
                        break;

                    case 3:
                        //LO
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            } while (choice != 0);
            //TO DO
        }

        // fonction pour remplir un emploie du temps
        private static bool AddDay(bool[,] tab)
        {
            int compteur = 0;//??????


            Console.WriteLine("Enter the number of the month : ");            /*demande le mois */
            int nbOfTheMonth = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date of the fist day : ");         /*demande a partir de quel jour*/
            int dateOfTheFirstDay = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter how many days : ");                    /*pour combien de temps*/
            int nbOfDays = int.Parse(Console.ReadLine());

            /*j ai modifier le i il va jusqua ex: de 12 au (12+2j)*/
            int dateButoir=dateOfTheFirstDay+nbOfDays;
            for (int i = dateOfTheFirstDay - 1; i < dateButoir-1 ; i++)     
            {
                if ((dateOfTheFirstDay > 31))
                        nbOfTheMonth++;
                if (tab[nbOfTheMonth - 1, i] == false) //false = jour libre 
                    compteur++;                                 // verifie si tt les jours sont libre 

            }

            if (compteur == nbOfDays) //if all the days are free
            {
                for (int i = dateOfTheFirstDay - 1; i < dateButoir-1; i++)
                {
                    if (dateOfTheFirstDay > 31) 
                    { nbOfTheMonth++;
                            for (int j = 0; j < dateButoir-1; j++)
			                {
                            tab[nbOfTheMonth - 1, j] = true;
			                }
                    }
                    tab[nbOfTheMonth - 1, i] = true; // put true(full) 

                }
                return false;
            }
            else
                return true;
        }

        //fonction for the case 2
        private static void PrintTab(bool[,] tab)
        {
            int compt = 0;

            foreach (bool item in tab)
            {
                if (compt++ > 30)  //jump a line all month 
                {
                    Console.WriteLine();
                    compt = 1;
                }
                Console.Write("{0,2} ", Convert.ToInt32( item));
            }
            Console.WriteLine();
        }
    }
}