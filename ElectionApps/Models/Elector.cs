using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionApps.Models
{
    public class Elector
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long CinNumber { get; set; }

        public string Address { get; set; }

        public string Fokontany { get; set; }

        public string VotePlaceName { get; set; }
    }
}
