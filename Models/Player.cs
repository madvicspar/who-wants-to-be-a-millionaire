﻿using System.ComponentModel.DataAnnotations;

namespace WhoWantsToBeAMillionaire.Models
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
