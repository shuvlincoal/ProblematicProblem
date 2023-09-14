
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
                Console.WriteLine($"\n\n\n---------------------------------");
                Console.WriteLine($"Hasta La Vista Baby\n\n\n");
                System.Environment.Exit(0);
        }

        public static void ItsCool()
        {
            Console.WriteLine($"\n\n\n---------------------------------");
            Console.WriteLine($"You Answered NO, ");
            Console.WriteLine($"You cut me real deep just now.....\n\n\n");
        }

        public static void Weird()
        {
            Console.WriteLine($"\n\n---------------------------------");
            Console.WriteLine($"Weird answer dude, have you been drinking?.....\n\n");
        }








        static void Main(string[] args)
{
          //-----------------------------------------
          Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
          string userInput = Console.ReadLine().Trim();
          //ZZZ
          if (userInput.Equals("yes", StringComparison.OrdinalIgnoreCase) || userInput.Equals("y", StringComparison.OrdinalIgnoreCase))
          {
              cont = true;
          }
          else
          {
              ItsCool();
          }
          Console.WriteLine($"DBUG1 cont:{cont}");

          //-----------------------------------------
          Console.Write("We are going to need your information first! What is your name? ");
          string userName = Console.ReadLine();
          Console.WriteLine();


          //-----------------------------------------
          Console.Write("What is your age? ");
          int.TryParse(Console.ReadLine(), out int userAge);
          Console.WriteLine();



          //-----------------------------------------
          Console.Write("Would you like to see the current list of activities? Yes/No thanks: ");
          userInput = Console.ReadLine().Trim();
          bool seeList = false;
          //ZZZ
          if (userInput.Equals("yes", StringComparison.OrdinalIgnoreCase) || userInput.Equals("y", StringComparison.OrdinalIgnoreCase))
          {
              seeList = true;
          }
          else
          {
              ItsCool();
          }


            seeList = userInput.Trim().Equals("yes", StringComparison.OrdinalIgnoreCase);


          if (seeList)
             {
                foreach (string activity in activities)
                  {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                  }//foreach
                bool addToList = true;
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                userInput = Console.ReadLine().Trim();
                //ZZZ
                if (userInput.Equals("yes", StringComparison.OrdinalIgnoreCase) || userInput.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    addToList = true;
                }
                else
                {
                    ItsCool();
                }
                //bool addToList = userInput.Trim().Equals("yes", StringComparison.OrdinalIgnoreCase);


                Console.WriteLine();
 
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
                    userInput = userInput.Trim();
                    if (userInput == "no"  || userInput == "No"  || userInput == "") { ItsCool(); }
                    if (userInput != "yes" || userInput != "Yes" || userInput != "Y" || userInput != "y" || userInput != "") { Weird(); }
                    addToList = bool.Parse(Console.ReadLine());
                  }//end While


                while (cont)
                {
                    Console.Write("Connecting to the database");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }//end for


                    Console.WriteLine();
                    Console.WriteLine("Choosing your random activity");
                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }//end For


                    Console.WriteLine();
                    Random rng = new Random(); //before using the Next() method.
                    int randomNumber = rng.Next(activities.Count);
                    string randomActivity = activities[randomNumber];

                    if (userAge > 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do  {randomActivity}");
                        Console.WriteLine("Pick something else!");
                        activities.Remove(randomActivity);
                        randomNumber = rng.Next(activities.Count);
                        randomActivity = activities[randomNumber];
                    }//end if

                    Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Yes/No: ");
                    //if (userInput == "no" || userInput == "No") { Hasta(); }
                    //userInput = Console.ReadLine();
                    //userInput = userInput.Trim();
                    //cont = userInput.Trim().Equals("yes", StringComparison.OrdinalIgnoreCase);

                    userInput = Console.ReadLine().Trim();
                    //ZZZ
                    if (userInput.Equals("yes", StringComparison.OrdinalIgnoreCase) || userInput.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        cont = true;
                    }
                    else
                    {
                        ItsCool();
                    }

                }//2nd While

          }//Main if
          else
            {
                Hasta();
            }

        }//Main Method

    }//class
}//namespace