using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WhoWantsToBeAMillionaire
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string username { get; set; }
        public int score { get; set; }

        public Player() { }
    }
}
