using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Diagnostics;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using System;

namespace ReactTodo.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            /*
            base.OnKeyDown(e);

            var vm = DataContext as ViewModels.MainWindowViewModel;

            switch (e.Key)
            {
                case Key.A:
                    vm.Y = 2;
                    vm.Button_Text = "Clicked";

                    //Console.WriteLine("Clicked");
                    break;
            }
            //*/
            Models.Keyboard.Keys.Add(e.Key);
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            Models.Keyboard.Keys.Remove(e.Key);
            base.OnKeyUp(e);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
