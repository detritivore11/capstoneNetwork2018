// ************************************************************************************************
// CAPSTONE G03, 2018-2019
//
// Repository:
//  https://github.com/rahmant3/capstoneROS2018
//
// Description:
//  View model for the about window.
//
// History:
//  2019-01-03 by Tamkin Rahman
//  - Created.
// ************************************************************************************************


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using VirtualVehicle.Models;
using VirtualVehicle.Version;

namespace VirtualVehicle.ViewModels
{
    public class AboutWindowViewModel: INotifyPropertyChanged
    {
        public string Description { get; set; } = "This application is to be used for testing and demonstrating the Augmented Reality Application by Capstone Group G03 (2018-2019). Unauthorized commercial use is strictly prohibited.\n\nIcon is by artist Iconshock, used under the agreement that it is not used for commercial purposes: http://www.iconarchive.com/artist/iconshock.html";
        public string Version
        {
            get
            {
                return Versions.version;
            }
        }
        public AboutWindowViewModel() { }

        public void CloseWindow(object obj)
        {
            System.Windows.Window window = obj as System.Windows.Window;
            window.Close();
        }

        private ICommand exitCommand;
        public ICommand ExitCommand
        {
            get
            {
                if (exitCommand == null)
                {
                    exitCommand = new RelayCommand(param => this.CloseWindow(param), null);
                }
                return exitCommand;
            }
        }

        #region INotifyPropertyChanged
        // See: https://docs.microsoft.com/en-us/dotnet/framework/winforms/how-to-implement-the-inotifypropertychanged-interface
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
