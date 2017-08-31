using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiReCT_wpf.ScreenInterface
{
    public interface IRepresentationLayer : INotifyPropertyChanged
    {
        ScreenBase CurrentScreen { get; }

        ScreenBase ShowLoginScreen();
        ScreenBase ShowMenuScreen();
       

        void ShowNotificationWindow(string notifacation);
    }
}
