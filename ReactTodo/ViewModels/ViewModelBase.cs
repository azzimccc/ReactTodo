using ReactiveUI;
using Avalonia.Threading;
using Avalonia.ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive.Disposables;

namespace ReactTodo.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        protected DispatcherTimer Timer;
        public ViewModelBase()
        {
            Timer = new DispatcherTimer(priority: DispatcherPriority.Normal);
        }
    }
}
