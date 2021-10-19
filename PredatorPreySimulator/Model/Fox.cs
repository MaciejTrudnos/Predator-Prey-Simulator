using PredatorPreySimulator.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PredatorPreySimulator.Model
{
    public class Fox
    {
        public int Id { get; set; }
        public Move Move { get; set; }
        public Gender Gender { get; set; }
        public Generation Generation { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }
}
