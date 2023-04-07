﻿using System.ComponentModel.DataAnnotations;

namespace AWWW_lab2_gr5.Models.ViewModels
{
    public class PlayerPositionData
    {
        public IEnumerable<Player> Players { get; set; }
        public IEnumerable<Position> Positions { get; set; }
        public IEnumerable<PlayerPosition> PlayerPositions { get; set; }
    }
}
