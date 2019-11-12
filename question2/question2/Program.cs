using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dotNet5780_01_6789_0947
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("choose the number of the question: \n  1- cheela 1 \n  2- cheela 2");
            switch(int.Parse (Console.ReadLine()))
            {
                case 1:
                    question1();
                    break;
                case 2: 
                    question2();
                    break;
               default:
                    Console.WriteLine("undifined");
                    break;
            }
        }
    

    private static void question1()
    {
        Random r = new Random(DateTime.Now.Millisecond);
        const int SIZE = 20;
            int[] A = new int[SIZE];
            int[] B = new int[SIZE];
            int[] C = new int[SIZE];
            //init the arrays to random values
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = r.Next(18, 122);
                B[i] = r.Next(18, 122);
                C[i] = Math.Abs(A[i] - B[i]);
            }
            foreach (int item in A)
                Console.Write("{0,3} ",item);

            Console.WriteLine();
            
            foreach (int item in B)
                Console.Write("{0,3} ", item);
            Console.WriteLine();
            
            foreach (int item in C)
                Console.Write("{0,3} ", item);
            Console.WriteLine();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        

    }
    private static void question2()
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
                        AddDay(calandar);
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
        public static bool AddDay(bool[,] tab)
        {
            Console.WriteLine("Enter the number of the month : ");            /*demande le mois */
           int month = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date of the fist day : ");         /*demande a partir de quel jour*/
            int day = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter how many days : ");                    /*pour combien de temps*/
            int nbOfDays = int.Parse(Console.ReadLine());
            if(!(month+((day+nbOfDays)/31)>12))
            {

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
                Console.WriteLine("Your days are reserved");
                return true;
            }
            else
            {
                Console.WriteLine("this days are already full");
                return false;
            }
            }
            else
                Console.WriteLine("too many days , finished years broo");
            return false;
        }
        enum Mounth {January=1,February,March,April,May,June,July,August,September,October,November ,December}
        enum busy {_,X}
        //fonction for the case 2
       public static void PrintTab(bool[,] tab)
        {
            int compt = 0;

            foreach (bool item in tab)
            {
                if (compt++ > 30)           //jump a line all month 
                {
                    Console.WriteLine();
                    compt = 1;
                }
                Console.Write("{0,2} ",(busy)Convert.ToInt32( item));
            }
            Console.WriteLine();
        }
        public static int Pourcent(bool [,] tab)
        {
            int  max=372;
            int nbFullDays=count(tab,true,1,1,372);
            return (100*nbFullDays/max);
        }
        public static int count(bool [,]tab,bool flag,int month,int day,int nbOfDays)
         {
            int count=0;
             for (int i = 0 ,j=month,k=day; (i < nbOfDays) ; i++,k++)     
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
      public static void printAllBusyDate(bool[,] tab)       
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
    

