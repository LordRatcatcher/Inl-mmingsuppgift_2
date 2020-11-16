using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning_2_ra_kod
{
    class Person
    {
        /*CLASS: Person
         *PURPOSE: Creates a class with the properties of name, adress, phone and email and creates a construct for it´s properties*/
        public string name, adress, phone, email;
        public Person(string N, string A, string T, string E)
        {
            name = N; adress = A; phone = T; email = E;
        }
        /*Method: loadList
         *Purpose: a method which is used to load the file which the code is interacting with. The code then reads through the file
          and sets up each word with a Dict function, then writes the welcome message
          Parameters: it creats the list Dict from the object Person and reads the file, it is using StreamReader and creating a string called line from
          the file, it then creates a string list called word and splits it using hashtag, then a way to add the words 0 to 3 are made available to
          add to the list Dict
          Returns: it returns the list Dict, the split list word with index 0, 1, 2, 3 and adds them to the list Dict*/
        public static void LoadList()
        {
            List<Person> Dict = new List<Person>();
            Console.Write("Laddar adresslistan ... ");
            using (StreamReader fileStream = new StreamReader(@"C:\Users\ÄGARE\Desktop\Inlämmingsupgift_2\Inlamning_2_ra_kod-master\address.lis"))
            {
                while (fileStream.Peek() >= 0)
                {
                    string line = fileStream.ReadLine();                   
                    string[] word = line.Split('#');                    
                    Person P = new Person(word[0], word[1], word[2], word[3]);
                    Dict.Add(P);
                }
            }
            Console.WriteLine("klart!");

            Console.WriteLine("Hej och välkommen till adresslistan");
            Console.WriteLine("Skriv 'sluta' för att sluta!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {                        
            Person.LoadList();
            List<Person> Dict = new List<Person>();
            string command;
            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
                if (command == "sluta")
                {                    
                    Console.WriteLine("Hej då!");
                }
                else if (command == "ny")
                {
                    Console.WriteLine("Lägger till ny person"); Console.Write("  1. ange namn:    "); string name = Console.ReadLine();
                    Console.Write("  2. ange adress:  "); string adress = Console.ReadLine();
                    Console.Write("  3. ange telefon: "); string phone = Console.ReadLine();
                    Console.Write("  4. ange email:   "); string email = Console.ReadLine();
                    Dict.Add(new Person(name, adress, phone, email));
                }
                else if (command == "ta bort")
                {
                    Console.Write("Vem vill du ta bort (ange namn): "); string toRemove = Console.ReadLine(); int found = -1;
                    for (int i = 0; i < Dict.Count(); i++)
                    {
                        if (Dict[i].name == toRemove) found = i;
                    }
                    if (found == -1)
                    {
                        Console.WriteLine("Tyvärr: {0} fanns inte i telefonlistan", toRemove);
                    }
                    else
                    {
                        Dict.RemoveAt(found);
                    }
                }
                else if (command == "visa")
                {
                    for (int i = 0; i < Dict.Count(); i++)
                    {
                        Person P = Dict[i];
                        Console.WriteLine("{0}, {1}, {2}, {3}", P.name, P.adress, P.phone, P.email);
                    }
                }
                else if (command == "ändra")
                {
                    Console.Write("Vem vill du ändra (ange namn): "); string toChange = Console.ReadLine();
                    int found = -1;
                    for (int i = 0; i < Dict.Count(); i++)
                    {
                        if (Dict[i].name == toChange) found = i;
                    }
                    if (found == -1)
                    {
                        Console.WriteLine("Tyvärr: {0} fanns inte i telefonlistan", toChange);
                    }
                    else
                    {
                        Console.Write("Vad vill du ändra (namn, adress, telefon eller email): "); string fieldToChange = Console.ReadLine();
                        Console.Write("Vad vill du ändra {0} på {1} till: ", fieldToChange, toChange); string newValue = Console.ReadLine();
                        switch (fieldToChange)
                        {
                            case "namn": Dict[found].name = newValue; break;
                            case "adress": Dict[found].adress = newValue; break;
                            case "telefon": Dict[found].phone = newValue; break;
                            case "email": Dict[found].email = newValue; break;
                            default: break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Okänt kommando: {0}", command);
                }
            } while (command != "sluta");
            

        }
    }
}
