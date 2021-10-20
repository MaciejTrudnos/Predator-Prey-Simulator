using PredatorPreySimulator.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PredatorPreySimulator.Data
{
    public abstract class Seeder
    {
        protected Enum.Move GenerateMove()
        {
            var values = Enum.Move.GetValues(typeof(Move));
            var random = new Random();
            return (Move)values.GetValue(random.Next(values.Length));
        }

        protected Enum.Gender GenerateGender()
        {
            var values = Enum.Move.GetValues(typeof(Gender));
            var random = new Random();
            return (Gender)values.GetValue(random.Next(values.Length));
        }

        protected int GeneratePositionX(int boundaryX)
        {
            var random = new Random();
            return random.Next(0, boundaryX);
        }

        protected int GeneratePositionY(int boundaryY)
        {
            var random = new Random();
            return random.Next(0, boundaryY);
        }
    }
}
