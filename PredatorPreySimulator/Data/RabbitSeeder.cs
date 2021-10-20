using PredatorPreySimulator.Enum;
using PredatorPreySimulator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PredatorPreySimulator.Data
{
    public class RabbitSeeder : Seeder
    {
        private int _initialDataCount { get; set; }
        private int _boundaryX { get; set; }
        private int _boundaryY { get; set; }

        public RabbitSeeder(int initialDataCount, int boundaryX, int boundaryY)
        {
            _initialDataCount = initialDataCount;
            _boundaryX = boundaryX;
            _boundaryY = boundaryY;
        }

        public List<Rabbit> Init()
        {
            var foxes = new List<Rabbit>();

            for (int i = 0; i < _initialDataCount; i++)
            {
                var fox = new Rabbit
                {
                    Id = i,
                    Move = GenerateMove(),
                    Gender = GenerateGender(),
                    Generation = Generation.First,
                    PositionX = GeneratePositionX(_boundaryX),
                    PositionY = GeneratePositionY(_boundaryY),
                    IsAlive = true
                };

                foxes.Add(fox);
            }

            return foxes;
        }
    }
}
