﻿using PredatorPreySimulator.Enum;
using PredatorPreySimulator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PredatorPreySimulator.Data
{
    public class FoxSeeder : Seeder
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

        public List<Fox> Init()
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
