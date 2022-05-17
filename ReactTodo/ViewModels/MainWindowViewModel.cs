using Avalonia;
using Avalonia.Diagnostics;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Input;
using ReactiveUI;
using Avalonia.Data;
using Avalonia.Platform;
using Avalonia.ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace ReactTodo.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        /*
        enum ObjectCode : int
        {
            Al,
            Obs
        }
        */

        private readonly Random _Random = new Random();
        private int count;
        private bool pause = false;
        [Reactive] public int WIDTH { set; get; }
        [Reactive] public int HEIGHT { set; get; }
        // public string Greeting => "Welcome to Avalonia!";
        [Reactive] public string TestText {set; get;}
        [Reactive] public int MaxDimensionValue { set; get; }
        [Reactive] public int delay { set; get; }
        //[Reactive] public int[] X { set; get; }
        //[Reactive] public int[] Y { set; get; }
        [Reactive] public int X { set; get; }
        [Reactive] public int Y { set; get; }
        [Reactive] public int X2 { set; get; }
        [Reactive] public int Y2 { set; get; }
        [Reactive] public int X3 { set; get; }
        [Reactive] public int Y3 { set; get; }

        //public string AlImage = "avares://ReactTodo/Assets/al.png";

        //public Models.Box al;
        public MainWindowViewModel()
        {
            //this.X = new int[] { 0, 0 };
            //this.Y = new int[] { 0, 0 };

            this.Init();

            //ImageMap = new Bitmap(AvaloniaLocator.Current.GetService<IAssetLoader>().Open(new Uri("avares://ReactTodo/Assets/al.png")));

            Timer.Tick += (s, e) =>
            {
                this.Update();
                //Update Here
                //Timer.Stop();
            };
            Timer.Start();
        }

        public void Init()
        {
            this.WIDTH = 640;
            this.HEIGHT = 480;
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            this.delay = 0;
            this.count = -1;
            this.MaxDimensionValue = 9;
            this.X = 2;
            this.Y = 0;
            this.X2 = 6;
            this.Y2 = 6;
            this.UpdateSouMovement();
        }

        private void Update()
        {
            this.UpdateFactor();
            if (!this.pause)
            {
                this.UpdateAlMovement();
                if (this.delay > (10 - (this.count / 10)))
                {
                    this.UpdateObsMovement();
                    this.delay = 0;
                }
            }
        }
        
        private void UpdateAlMovement()
        {
            if (Models.Keyboard.Keys.Contains(Key.I))
            {
                //Y--;
                this.Y = CheckOutOfBoundMove(this.Y, -1);
            }
            else if (Models.Keyboard.Keys.Contains(Key.L))
            {
                //X++;
                this.X = CheckOutOfBoundMove(this.X, 1);
            }
            else if (Models.Keyboard.Keys.Contains(Key.J))
            {
                //X--;
                this.X = CheckOutOfBoundMove(this.X, -1);
            }
            else if (Models.Keyboard.Keys.Contains(Key.K))
            {
                //Y++;
                this.Y = CheckOutOfBoundMove(this.Y, 1);
            }

            if(InOutOfBoundMove(this.X, this.Y, this.X3, this.Y3))
            {
                this.UpdateSouMovement();
            }
        }
        private void UpdateObsMovement()
        {
            if (this.Y < this.Y2)
            {
                this.Y2 = CheckOutOfBoundMove(this.Y2, -1);
            }
            else if (this.X > this.X2)
            {
                this.X2 = CheckOutOfBoundMove(this.X2, 1);
            }
            else if (this.X < this.X2)
            {
                this.X2 = CheckOutOfBoundMove(this.X2, -1);
            }
            else if (this.Y > this.Y2)
            {
                this.Y2 = CheckOutOfBoundMove(this.Y2, 1);
            }
        }
        private void UpdateSouMovement()
        {
            this.X3 = this.CheckOutOfBoundMove(_Random.Next(this.MaxDimensionValue),0);
            this.Y3 = this.CheckOutOfBoundMove(_Random.Next(this.MaxDimensionValue),0);

            this.count++;
        }
        //*/
        private int CheckOutOfBoundMove(int xory, int xymove)
        {
            return MoveBound(xory, xymove, this.MaxDimensionValue, 0);
        }

        private int MoveBound(int xory, int xymove, int _maxDimensionValue, int _minDimensionValue)
        {
            if (xory + xymove >= _maxDimensionValue)
                return _maxDimensionValue;

            if (xory + xymove <= _minDimensionValue)
                return _minDimensionValue;

            return xory + xymove;
        }

        private bool InOutOfBoundMove(int _ix, int _iy, int _ox, int _oy)
        {
            if (_ix == _ox && _iy == _oy)
                return true;
            return false;
        }

        private void UpdateFactor()
        {
            if (!this.pause)
                this.TestText = "Score : " + this.count;
            else
                this.TestText = "Pause";

            this.delay ++;

            if (Models.Keyboard.Keys.Contains(Key.Enter)) 
                this.Pause();
        }

        private void Pause()
        {
            this.pause = !this.pause;
        }
    }
}
