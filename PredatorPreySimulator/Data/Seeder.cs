using PredatorPreySimulator.Enum;
using PredatorPreySimulator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PredatorPreySimulator.Data
{
    public class Seeder
    {
        private static int _initialDataCount { get; set; }
        private static int _boundaryX { get; set; }
        private static int _boundaryY { get; set; }

        public Seeder(int boundaryX, int boundaryY)
        {
            _boundaryX = boundaryX;
            _boundaryY = boundaryY;
        }

        public Seeder(int initialDataCount, int boundaryX, int boundaryY)
        {
            _initialDataCount = initialDataCount;
            _boundaryX = boundaryX;
            _boundaryY = boundaryY;
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

        private int GeneratePositionX(int boundaryX)
        {
            var random = new Random();
            return random.Next(0, boundaryX);
        }

        private int GeneratePositionY(int boundaryY)
        {
            var random = new Random();
            return random.Next(0, boundaryY);
        }

        public List<Fox> InitFoxes()
        {
            var foxes = new List<Fox>();

            for (int i = 0; i < _initialDataCount; i++)
            {
                var fox = new Fox
                {
                    Id = Guid.NewGuid(),
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

        public Fox CreateFox()
        {
            return new Fox
            {
                Id = Guid.NewGuid(),
                Move = GenerateMove(),
                Gender = GenerateGender(),
                Generation = Generation.Second,
                PositionX = _boundaryX,
                PositionY = _boundaryY,
                IsAlive = true
            };
        }

        public List<Rabbit> InitRabbits()
        {
            var foxes = new List<Rabbit>();

            for (int i = 0; i < _initialDataCount; i++)
            {
                var fox = new Rabbit
                {
                    Id = Guid.NewGuid(),
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

        public Rabbit CreateRabbit()
        {
            return new Rabbit
            {
                Id = Guid.NewGuid(),
                Move = GenerateMove(),
                Gender = GenerateGender(),
                Generation = Generation.Second,
                PositionX = _boundaryX,
                PositionY = _boundaryY,
                IsAlive = true
            };
        }
    }
}
