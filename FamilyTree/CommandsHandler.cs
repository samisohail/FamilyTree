using System;
using FamilyTree2.Constants;

namespace geektrust
{
    public static class CommandsHandler
    {
        public static string ProcessCommand(FamilyTreeHandler family, string command)
        {
            var outcome = string.Empty;

                var commandParams = command.Split(" ");
                switch (commandParams[0].Trim())
                {

                    case "ADD_FAMILY_HEAD":
                        family.addFamilyHead(commandParams[1], commandParams[2]);
                        break;

                    case "ADD_CHILD":
                        outcome =family.AddChild(commandParams[1], commandParams[2], commandParams[3]);
                        break;

                    case "ADD_SPOUSE":
                        family.AddSpouse(commandParams[1], commandParams[2], commandParams[3]);
                        break;

                    case "GET_RELATIONSHIP":
                        outcome = family.GetRelationship(commandParams[1], commandParams[2]);
                        break;                   
                }

            return outcome;
        }
    }
}
