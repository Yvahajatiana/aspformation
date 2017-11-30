using ElectionApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionApps.Data
{
    public static class Dbinitializer
    {
        public static void Initialize(ElectionContext context)
        {
            context.Database.EnsureCreated();

            if (context.Electors.Any())
            {
                return;
            }

            IEnumerable<Elector> ElectorSeedData = new List<Elector>
            {
                new Elector {FirstName = "Elec 1 FName", LastName = "Elec 1 LName", Address = "Elec 1 Adress",  CinNumber = 216011456888, Fokontany = "Elec 1 Fokontany",VotePlaceName="Bureau de vote A"},
                new Elector {FirstName = "Elec 2 FName", LastName = "Elec 2 LName", Address = "Elec 2 Adress",  CinNumber = 216011456888, Fokontany = "Elec 2 Fokontany",VotePlaceName="Bureau de vote B"},
                new Elector {FirstName = "Elec 3 FName", LastName = "Elec 3 LName", Address = "Elec 3 Adress",  CinNumber = 216011456888, Fokontany = "Elec 3 Fokontany",VotePlaceName="Bureau de vote A"},
                new Elector {FirstName = "Elec 4 FName", LastName = "Elec 4 LName", Address = "Elec 4 Adress",  CinNumber = 216011456888, Fokontany = "Elec 4 Fokontany",VotePlaceName="Bureau de vote B"},
                new Elector {FirstName = "Elec 5 FName", LastName = "Elec 5 LName", Address = "Elec 5 Adress",  CinNumber = 216011456888, Fokontany = "Elec 5 Fokontany",VotePlaceName="Bureau de vote A"}
            };

            context.Electors.AddRange(ElectorSeedData);
            context.SaveChanges();
        }
    }
}
