using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Anima.Core;
using System.Windows.Forms;
using System.ComponentModel;

namespace Anima
{

    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Topmost = false;
            TraySystem TS = new TraySystem();

            

        }

        private void UpdateDisplay(object sender, AnimaEventArgs e)
        {
            this.Dispatcher.Invoke(() => {
                if (AnimaCentral.Pos != null) { AnimaCentral.Pos.SetWindowPosition(this); }

                if (AnimaCentral.Image != null) { this.AnimaDisplay.Source = AnimaCentral.Image; }

                if (e.form != null)
                {
                    e.form.InvokeIfRequired(() =>
                    {
                        e.form.Show();
                    });
                }
            });
            
        }


        private bool ShiftedLeft = false;
        private void AnimaDisplay_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var Pos = AnimaCentral.Pos;
            Pos.X = ShiftedLeft ? Pos.X + this.Width : Pos.X - this.Width;
            ShiftedLeft = !ShiftedLeft;

            AnimaCentral.Pos = Pos;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AnimaCentral.Initialise(this);
            AnimaCentral.AnimaUpdate += UpdateDisplay;
            AnimaCentral.Pos = AnimaCentral.BottomRightMainScreen(this.Width, this.Height);

            Command BringTop = new Command("Could you be visible please?", Utilities.GiveReply("Hello, here I am", delegate () {
                this.Dispatcher.Invoke(() =>
                {
                    this.Topmost = true;
                });
            }));
            Command AllowDropBack = new Command("You can hide now", Utilities.GiveReply("Okay, I'll just hang back", delegate () {
                this.Dispatcher.Invoke(() =>
                {
                    this.Topmost = false;
                });
            }));

            AnimaCentral.RegisterCommand(BringTop, AllowDropBack);
        }

        private void AnimaDisplay_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            AnimaDisplay.Opacity = 0.25;
        }

        private void AnimaDisplay_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            AnimaDisplay.Opacity = 1.0;
        }
    }
}
