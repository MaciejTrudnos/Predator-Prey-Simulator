using PredatorPreySimulator.Enum;
using PredatorPreySimulator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PredatorPreySimulator.Data
{
    public class FoxSeeder
    {
        private int _initialDataCount { get; set; }
        private int _boundaryX  { get; set; }
        private int _boundaryY { get; set; }

        public FoxSeeder(int initialDataCount, int boundaryX, int boundaryY)
        {
            _initialDataCount = initialDataCount;
            _boundaryX = boundaryX;
            _boundaryY = boundaryY;
        }

        public List<Fox> InitFoxes()
        {
            var foxes = new List<Fox>();
            
            for (int i = 0; i < _initialDataCount; i++)
            {
                var fox = new Fox
                {
                    Id = i,
                    Move = GenerateMove(),
                    Gender = GenerateGender(),
                    Generation = Generation.First,
                    PositionX = GeneratePositionX(),
                    PositionY = GeneratePositionY()
                };

                foxes.Add(fox);
            }

            return foxes;
        }

        private Enum.Move GenerateMove()
        {
            var values = Enum.Move.GetValues(typeof(Move));
            var random = new Random();
            return (Move)values.GetValue(random.Next(values.Length));
        }

        private Enum.Gender GenerateGender()
        {
            var values = Enum.Move.GetValues(typeof(Gender));
            var random = new Random();
            return (Gender)values.GetValue(random.Next(values.Length));
        }

        private int GeneratePositionX()
        {
            var random = new Random();
            return random.Next(0, _boundaryX);
        }

        private int GeneratePositionY()
        {
            var random = new Random();
            return random.Next(0, _boundaryY);
        }



    }
}
