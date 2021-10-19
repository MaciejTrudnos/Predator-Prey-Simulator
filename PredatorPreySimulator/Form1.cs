using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PredatorPreySimulator.Data;
using PredatorPreySimulator.Enum;
using PredatorPreySimulator.Model;

namespace PredatorPreySimulator
{
    public partial class Form1 : Form
    {
        private bool start = false;
        private int initialFoxDataCount = 0;
        
        private readonly int _boundaryX = 620;
        private readonly int _boundaryY = 420;

        private List<Fox> _foxes { get; set; } 

        public Form1()
        {
            InitializeComponent();
            
            Text = "Symulacja zjawiska drapieżnik-ofiara dla dwóch populacji";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (!start)
                return;

            foreach (var fox in _foxes)
            {
                var solidBrush = new SolidBrush(Color.Red);
                e.Graphics.FillRectangle(solidBrush, fox.PositionX, fox.PositionY, 10, 10);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            start = true;
            _foxes = new FoxSeeder(initialFoxDataCount, _boundaryX, _boundaryY).InitFoxes();
        }


        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!start)
                return;

            Parallel.ForEach(_foxes, fox =>
            {
                fox.Move = SetRandomMove();
                
                if (fox.Move == Enum.Move.Right)
                {
                    if(fox.PositionX < _boundaryX)
                    {
                        fox.PositionX += 10;
                    }

                    if (fox.PositionX >= _boundaryX)
                    {
                        fox.PositionX -= 10;
                        fox.Move = Enum.Move.Left;
                    }
                    
                    if (fox.PositionX > _boundaryX)
                    {
                        fox.PositionX -= 10;
                        fox.Move = Enum.Move.Left;
                    }
                }

                if (fox.Move == Enum.Move.Left)
                {
                    if(fox.PositionX > 0)
                    {
                        fox.PositionX -= 10;
                    }

                    if (fox.PositionX == 0)
                    {
                        fox.Move = Enum.Move.Right;
                    }
                    
                    if (fox.PositionX < 0)
                    {
                        fox.PositionX = 0;
                        fox.Move = Enum.Move.Right;
                    }
                }

                if (fox.Move == Enum.Move.Up)
                {
                    if (fox.PositionY < _boundaryY)
                    {
                        fox.PositionY += 10;
                    }

                    if (fox.PositionY >= _boundaryY)
                    {
                        fox.PositionY -= 10;
                        fox.Move = Enum.Move.Down;
                    }
                    
                    if (fox.PositionY > _boundaryY)
                    {
                        fox.PositionY -= 10;
                        fox.Move = Enum.Move.Down;
                    }
                }

                if (fox.Move == Enum.Move.Down)
                {
                    if (fox.PositionY > 0)
                    {
                        fox.PositionY -= 10;
                    }

                    if (fox.PositionY == 0)
                    {
                        fox.Move = Enum.Move.Up;
                    }
                    
                    if (fox.PositionY < 0)
                    {
                        fox.PositionX = 0;
                        fox.Move = Enum.Move.Up;
                    }
                }
            });

            Invalidate(true);
        }

        private void panel1_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private Enum.Move SetRandomMove()
        {
            var values = Enum.Move.GetValues(typeof(Move));
            var random = new Random();
            return (Move)values.GetValue(random.Next(values.Length));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
            initialFoxDataCount = count;
        }
    }
}
