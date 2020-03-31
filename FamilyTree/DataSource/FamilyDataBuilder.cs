using System;
using System.Collections.Generic;
using System.Text;

namespace geektrust.DataSource
{
    public class FamilyDataBuilder
    {
        private List<string> commands;
        public FamilyDataBuilder()
        {
            commands = new List<string>();
        }

        public List<string> GenerateFamilyCommands()
        {
            commands.Add("ADD_CHILD Queen-Margret Bill Male");
            commands.Add("ADD_SPOUSE Bill Flora Female");
            commands.Add("ADD_CHILD Flora Victoire Female");
            commands.Add("ADD_SPOUSE Victoire Ted Male");
            commands.Add("ADD_CHILD Flora Dominique Female");
            commands.Add("ADD_CHILD Flora Louis Male");
            commands.Add("ADD_CHILD Queen-Margret Charlie Male");
            commands.Add("ADD_CHILD Queen-Margret Percy Male");
            commands.Add("ADD_SPOUSE Percy Audrey Female");
            commands.Add("ADD_CHILD Audrey Molly Female");
            commands.Add("ADD_CHILD Audrey Lucy Female");
            commands.Add("ADD_CHILD Queen-Margret Ronald Male");
            commands.Add("ADD_SPOUSE Ronald Helen Female");
            commands.Add("ADD_CHILD Helen Hugo Male");
            commands.Add("ADD_CHILD Helen Rose Female");
            commands.Add("ADD_SPOUSE Rose Malfoy Male");
            commands.Add("ADD_CHILD Rose Draco Male");
            commands.Add("ADD_CHILD Rose Aster Female");
            commands.Add("ADD_CHILD Queen-Margret Ginerva Female");
            commands.Add("ADD_SPOUSE Ginerva Harry Male");
            commands.Add("ADD_CHILD Ginerva Lily Female");
            commands.Add("ADD_CHILD Ginerva Albus Male");
            commands.Add("ADD_SPOUSE Albus Alice Female");
            commands.Add("ADD_CHILD Alice Ron Male");
            commands.Add("ADD_CHILD Alice Ginny Female");
            commands.Add("ADD_CHILD Ginerva James Male");
            commands.Add("ADD_SPOUSE James Darcy Female");
            commands.Add("ADD_CHILD Darcy William Male");
            return commands;
        }
    }
}
