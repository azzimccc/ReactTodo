using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ReactTodo.Models
{
    public class Box : ReactiveObject
    {
        [Reactive] public int X { set; get; }
        [Reactive] public int Y { set; get; }

        public Box(int _X, int _Y)
        {
            this.X = _X;
            this.Y = _Y;
        }

        public bool CheckInBound(Box _Box)
        {
            if (this.X == _Box.X && this.Y == _Box.Y)
                return true;
            return false;
        }
    }
}
