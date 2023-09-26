
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        Random rng;
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

        public static void Hasta()
        {
                Console.WriteLine($"\n---------------------------------");
                Console.WriteLine($"You're no Fun!  Hasta La Vista Baby\n");
                System.Environment.Exit(0);
        }

        public static void ItsCool()
        {
            Console.WriteLine($"\n---------------------------------");
            Console.WriteLine($"You Answered NO, You cut me real deep just now.....\n");
        }

        public static void HaveFun(string activity)
        {
            Console.WriteLine($"\n---------------------------------");
            Console.WriteLine($"Have a great time with: {activity}!!.......");
            Console.WriteLine($"---------------------------------\n\n\n\n");
            Console.ReadLine();
        }








        static void Main(string[] args)
        {
            //-----------------------------------------
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            string userInput = Console.ReadLine().Trim();

            if (userInput.Equals("yes", StringComparison.OrdinalIgnoreCase) || userInput.Equals("y", StringComparison.OrdinalIgnoreCase))
              {
                cont = true;
              }
            else
              {
                Hasta();
                cont = false;
              }


            //-----------------------------------------
            Console.WriteLine("\n\n");
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            if (string.IsNullOrEmpty(userName) )
            {
                userName = "Anonymous";
                Console.WriteLine("\n\nHello Anonymous, (Armoriss?, Miah? is that you?) we like risk takers, glad to have you back!");
            }



            //-----------------------------------------
            Console.WriteLine("\n\n");
            Console.Write("What is your age? ");
            string strAge = Console.ReadLine();
            if (string.IsNullOrEmpty(strAge))
            {
                strAge = "21";
                Console.WriteLine("Ok, so you are 21!");
            }

            int userAge = int.Parse(strAge);
            Console.WriteLine();



            //-----------------------------------------
            Console.Write("Would you like to see the current list of activities? Yes/No thanks: ");
            userInput = Console.ReadLine().Trim();
            bool seeList = false;

            if (userInput.Equals("yes", StringComparison.OrdinalIgnoreCase) || userInput.Equals("y", StringComparison.OrdinalIgnoreCase))
             {
              seeList = true;
             }
            else
             {
               ItsCool();
               seeList = false;
             }






            if (seeList)
              {
                //----Display List, prompt user for additions----------
                foreach (string activity in activities)
                  {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                  }//foreach

                bool addToList = true;
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                userInput = Console.ReadLine().Trim();

                if (userInput.Equals("yes", StringComparison.OrdinalIgnoreCase) || userInput.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    addToList = true;
                }
                else
                {
                    ItsCool();
                    addToList = false;
                }




                //-----If User Selected to ADD to list-------------
                while (addToList)
                  {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);

                    foreach (string activity in activities)
                      {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                      }//end foreach

                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    userInput = Console.ReadLine();


                    if (userInput.Equals("yes", StringComparison.OrdinalIgnoreCase) || userInput.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        addToList = true;
                    }
                    else
                    {
                        ItsCool();
                        addToList = false;
                    }
                 }//While addToList







                //-----Offer user random activity options, with option to decline-------------
                while (cont)
                {
                    Console.WriteLine("\n");
                    Console.Write("Connecting to the database");
                    for (int i = 0; i < 10; i++)
                    {

                        Console.Write(". ");
                        Thread.Sleep(10);
                    }//end for


                    Console.WriteLine("\n");
                    Console.WriteLine("Choosing your random activity");
                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(10);
                    }//end For



                    Random rng = new Random(); //before using the Next() method.
                    int randomNumber = rng.Next(activities.Count);
                    string randomActivity = activities[randomNumber];

                    if (userAge < 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do  {randomActivity}");
                        Console.WriteLine("Pick something else!");
                        activities.Remove(randomActivity);
                        randomNumber = rng.Next(activities.Count);
                        randomActivity = activities[randomNumber];
                    }//end if



                    Console.WriteLine("\n\n");
                    Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok [No] Pick another acitivty, [Yes] exit: ");
                    userInput = Console.ReadLine().Trim();


                    if (userInput.Equals("no", StringComparison.OrdinalIgnoreCase) || userInput.Equals("n", StringComparison.OrdinalIgnoreCase))
                      {
                        Console.Write("Ok, you want to pick another, Ok Let's Do it!");
                        cont = true;
                        Thread.Sleep(10);
                      }
                    else
                      {
                        Console.Write("You don't want to make any more selections?");
                        HaveFun(randomActivity);
                        cont = false;
                      }
                }//2nd While Activity selection






            }//if seelist
            else
                {
                Hasta();
                }

         }//Main Method



    }//class
}//namespace