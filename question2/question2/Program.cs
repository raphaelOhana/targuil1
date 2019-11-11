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
            bool[,] calandar = new bool[12, 31];
            // true = plein et  false =libre
            do
            {
                //ask the user to make a choice
                Console.WriteLine(" to reserve days typing 1 \n to see availability typing 2 \n to see year's data typing 3");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {

                    case 1:
                        if (AddDay(calandar))
                            Console.WriteLine("Your days are reserved");
                        else
                            Console.WriteLine("this days are already full");
                        break;

                    case 2:
                        PrintTab(calandar);
                        printAllBusyDate(calandar);
                        break;

                    case 3:
                        Console.WriteLine("{0} %, nb fully days: {1}",Pourcent(calandar),count(calandar,true,1,1,372));
                        break;
                    default:
                        Console.WriteLine("Wrong !");
                        break;
                }
            } while (choice != 0);
           
        }

        // fonction pour remplir un emploie du temps
        private static bool AddDay(bool[,] tab)
        {
            Console.WriteLine("Enter the number of the month : ");            /*demande le mois */
           int month = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date of the fist day : ");         /*demande a partir de quel jour*/
            int day = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter how many days : ");                    /*pour combien de temps*/
            int nbOfDays = int.Parse(Console.ReadLine());
            

            if (count(tab,false,month,day+1,nbOfDays-1) == nbOfDays-1) //si tout les jour demander sont libres(sans m interesser au premier jour)
            {
                for (int i = 0 ,j=month,k=day; i < nbOfDays ; i++,k++)
                {
                     if ( k > 31) 
                     {
                        j++;
                        k=1;
                     }
                    tab[j-1, k-1] = true; //ecrit quil sont occupé 
                }
                return true;
            }
            else
                return false;
        }
        enum Mounth {January=1,February,March,April,May,June,July,August,September,October,November ,December}
        //fonction for the case 2
        private static void PrintTab(bool[,] tab)
        {
            int compt = 0;

            foreach (bool item in tab)
            {
                if (compt++ > 30)           //jump a line all month 
                {
                    Console.WriteLine();
                    compt = 1;
                }
                Console.Write("{0,2} ", Convert.ToInt32( item));
            }
            Console.WriteLine();
        }
        private static int Pourcent(bool [,] tab)
        {
            int  max=372;
            int nbFullDays=count(tab,true,1,1,372);
            return (100*nbFullDays/max);
        }
        private static int count(bool [,]tab,bool flag,int month,int day,int nbOfDays)
         {
            int count=0;
             for (int i = 0 ,j=month,k=day; i < nbOfDays ; i++,k++)     
             {
                if (k > 31) 
                {
                    j++;
                    k=1;
                }    
                if (tab[j - 1, k-1] == flag) //false = jour libre 
                    count++;                 // verifie si tt les jours sont libre 
             }
             return count; 
         }
       private static void printAllBusyDate(bool[,] tab)       
       {
           bool busy=false;
           for (int i = 0 ,j=1,k=1; i < 372 ; i++,k++)     
           {
                if (k > 31) 
                {
                    j++;
                    k=1;
                }    
                if ((tab[j - 1, k-1] == true) && (busy==false)) //ca veut dire si c'est le premier d une liste de jour prit 
                { 
                    Console.Write("{0} {1} to ",k,(Mounth)j);
                    busy=true;
                }
                if ((tab[j - 1, k-1] == false) && (busy==true))//ca veut dire si c'est le dernier d une liste de jour prit
                { 
                    Console.WriteLine("{0} {1} ",k,(Mounth)j);
                    busy=false;
                }
           }
       }
    }
    
}