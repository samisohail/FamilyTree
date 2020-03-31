using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using FamilyTree2;
using geektrust;
using geektrust.DataSource;

namespace FamilyTree
{
    public class Program
    {
        static void Main(string[] args)
        {
            var commands = new string[] { };
            if (args.Any())
            {
                if (!File.Exists(args[0]))
                {
                    Console.WriteLine($"Invalid file path in args. {Environment.NewLine}Provide absolute path to file e.g. C:\\InputCommands.txt");
                    return;
                }
                else
                {
                    commands = File.ReadAllLines(args[0]);
                }
            }

            // Initialize family tree
            var family = new FamilyTreeHandler();
            family.addFamilyHead("Queen-Margret", "Female");
            family.AddSpouse("Queen-Margret", "King-Arthur", "Male");

            // Build family tree
            var familyMmembersData = new FamilyDataBuilder();
            var membersData = familyMmembersData.GenerateFamilyCommands();
            foreach (var data in membersData)
            {
                CommandsHandler.ProcessCommand(family, data);
            }

            
            // var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"DataSource\InputFamilyData.txt");
            foreach (var command in commands)
            {               
                if (string.IsNullOrEmpty(command)) continue;
                var outcome = CommandsHandler.ProcessCommand(family, command.Trim());
                Console.WriteLine(outcome);
            }
            
            Console.ReadLine();
        }
    }
}
