using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private Stopwatch stopWatch;
        private bool start = false;
        private int initialFoxDataCount = 0;
        private int initialRabbitDataCount = 0;

        private readonly int _boundaryX = 620;
        private readonly int _boundaryY = 420;

        private List<Fox> _foxes { get; set; }
        private List<Rabbit> _rabbits { get; set; }

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

            var rabbits = _rabbits.Where(x => x.IsAlive == true)
                .ToList();
            
            foreach (var rabbit in rabbits)
            {
                var solidBrush = new SolidBrush(Color.Green);
                e.Graphics.FillRectangle(solidBrush, rabbit.PositionX, rabbit.PositionY, 10, 10);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stopWatch = new Stopwatch();
            listBox1.Items.Clear();

            start = true;

            stopWatch.Start();

            _foxes = new FoxSeeder(initialFoxDataCount, _boundaryX, _boundaryY)
                .Init();
            
            _rabbits = new RabbitSeeder(initialRabbitDataCount, _boundaryX, _boundaryY)
                .Init();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!start)
                return;

            var foxes = _foxes.Where(x => x.IsAlive == true)
                .ToList();

            var rabbits = _rabbits.Where(x => x.IsAlive == true)
                .ToList();

            label7.Text = $"{foxes.Count}";
            label8.Text = $"{rabbits.Count}";

            Parallel.ForEach(foxes, fox =>
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

            Parallel.ForEach(rabbits, rabbit =>
            {
                rabbit.Move = SetRandomMove();

                if (rabbit.Move == Enum.Move.Right)
                {
                    if (rabbit.PositionX < _boundaryX)
                    {
                        rabbit.PositionX += 10;
                    }

                    if (rabbit.PositionX >= _boundaryX)
                    {
                        rabbit.PositionX -= 10;
                        rabbit.Move = Enum.Move.Left;
                    }

                    if (rabbit.PositionX > _boundaryX)
                    {
                        rabbit.PositionX -= 10;
                        rabbit.Move = Enum.Move.Left;
                    }
                }

                if (rabbit.Move == Enum.Move.Left)
                {
                    if (rabbit.PositionX > 0)
                    {
                        rabbit.PositionX -= 10;
                    }

                    if (rabbit.PositionX == 0)
                    {
                        rabbit.Move = Enum.Move.Right;
                    }

                    if (rabbit.PositionX < 0)
                    {
                        rabbit.PositionX = 0;
                        rabbit.Move = Enum.Move.Right;
                    }
                }

                if (rabbit.Move == Enum.Move.Up)
                {
                    if (rabbit.PositionY < _boundaryY)
                    {
                        rabbit.PositionY += 10;
                    }

                    if (rabbit.PositionY >= _boundaryY)
                    {
                        rabbit.PositionY -= 10;
                        rabbit.Move = Enum.Move.Down;
                    }

                    if (rabbit.PositionY > _boundaryY)
                    {
                        rabbit.PositionY -= 10;
                        rabbit.Move = Enum.Move.Down;
                    }
                }

                if (rabbit.Move == Enum.Move.Down)
                {
                    if (rabbit.PositionY > 0)
                    {
                        rabbit.PositionY -= 10;
                    }

                    if (rabbit.PositionY == 0)
                    {
                        rabbit.Move = Enum.Move.Up;
                    }

                    if (rabbit.PositionY < 0)
                    {
                        rabbit.PositionX = 0;
                        rabbit.Move = Enum.Move.Up;
                    }
                }
            });

            KillRabbitInPlace();

            label10.Text = $"{stopWatch.Elapsed.Hours.ToString("00")}:{stopWatch.Elapsed.Minutes.ToString("00")}:{stopWatch.Elapsed.Seconds.ToString("00")}";

            Invalidate(true);
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

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(Math.Round(numericUpDown2.Value, 0));
            initialRabbitDataCount = count;
        }

        private void KillRabbitInPlace()
        {
            var rabbits = _rabbits.Where(x => x.IsAlive == true)
                .ToList();

            var foxes = _foxes.Where(x => x.IsAlive == true)
                .ToList();

            foreach (var fox in foxes)
            {
                foreach (var rabbit in rabbits)
                {
                    var x = fox.PositionX - rabbit.PositionX;
                    if (x < 0)
                        x = rabbit.PositionX - fox.PositionX;

                    if(Enumerable.Range(0, 10).Contains(x))
                    {
                        var y = fox.PositionY - rabbit.PositionY;
                        if (y < 0)
                            y = rabbit.PositionY - fox.PositionY;

                        if (Enumerable.Range(0, 10).Contains(y))
                        {
                            rabbit.IsAlive = false;
                            AppendTextToListBox($"{stopWatch.Elapsed.Hours.ToString("00")}:{stopWatch.Elapsed.Minutes.ToString("00")}:{stopWatch.Elapsed.Seconds.ToString("00")} | " + "Zginął królik");
                        }
                    }
                }
            }
        }

        private void AppendTextToListBox(string text)
        {
            listBox1.Items.Add(text);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            listBox1.SelectedIndex = -1;
        }

        #region UIMethod

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        #endregion
    }
}
