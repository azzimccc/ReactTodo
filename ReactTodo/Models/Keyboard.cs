using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Input;

namespace ReactTodo.Models
{
    static class Keyboard
    {
        public static readonly HashSet<Key> Keys = new HashSet<Key>();
        public static bool IsKeyDown(Key key) => Keys.Contains(key);

    }
}
