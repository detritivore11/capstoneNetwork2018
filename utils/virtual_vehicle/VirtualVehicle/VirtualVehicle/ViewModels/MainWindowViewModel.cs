// ************************************************************************************************
// CAPSTONE G03, 2018-2019
//
// Repository:
//  https://github.com/rahmant3/capstoneROS2018
//
// Description:
//  View model for the main window.
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

namespace VirtualVehicle.ViewModels
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {
        private VehicleDiagnostics virtualvehicle;

        private const int DEFAULT_ID = 7;
        private const string BASE_URL = "http://capstonewebservice-test.us-west-2.elasticbeanstalk.com/api/vehicle";
        private const string KEY = "asdf";
        private const string VERSION = "V0.01";

        private List<Param> atvParams = new List<Param>()
        {
            { new Param() { Name = "Active PCodes",                   ID = 0,  Value = "",       Type = "string", Units = "",    Timestamp = 0, Message = ""} },
            { new Param() { Name = "Speed",                           ID = 1,  Value = "0.0",    Type = "double", Units = "kph", Timestamp = 0, Message = ""} },
            { new Param() { Name = "Low Battery",                     ID = 2,  Value = "False",  Type = "bool",   Units = "",    Timestamp = 0, Message = ""} },
            { new Param() { Name = "High Battery",                    ID = 3,  Value = "False",  Type = "bool",   Units = "",    Timestamp = 0, Message = ""} },
            { new Param() { Name = "Low Oil",                         ID = 4,  Value = "False",  Type = "bool",   Units = "",    Timestamp = 0, Message = ""} },
            { new Param() { Name = "Air Pressure Sensor Fault",       ID = 5,  Value = "False",  Type = "bool",   Units = "",    Timestamp = 0, Message = ""} },
            { new Param() { Name = "Air Temperature Sensor Fault",    ID = 6,  Value = "False",  Type = "bool",   Units = "",    Timestamp = 0, Message = ""} },
            { new Param() { Name = "Engine Temperature Sensor Fault", ID = 7,  Value = "False",  Type = "bool",   Units = "",    Timestamp = 0, Message = ""} },
            { new Param() { Name = "Throttle Position Sensor Fault",  ID = 8,  Value = "False",  Type = "bool",   Units = "",    Timestamp = 0, Message = ""} },
            { new Param() { Name = "Fuel Pump Fault",                 ID = 9,  Value = "False",  Type = "bool",   Units = "",    Timestamp = 0, Message = ""} },
            { new Param() { Name = "Injector Fault",                  ID = 10, Value = "False",  Type = "bool",   Units = "",    Timestamp = 0, Message = ""} },
            { new Param() { Name = "Engine Fan Fault",                ID = 11, Value = "False",  Type = "bool",   Units = "",    Timestamp = 0, Message = ""} },
            { new Param() { Name = "ECM Fault",                       ID = 12, Value = "False",  Type = "bool",   Units = "",    Timestamp = 0, Message = ""} },
            { new Param() { Name = "CAN Fault",                       ID = 13, Value = "False",  Type = "bool",   Units = "",    Timestamp = 0, Message = ""} },
            { new Param() { Name = "Fault Active",                    ID = 14, Value = "False",  Type = "bool",   Units = "",    Timestamp = 0, Message = ""} }

        };

        private static readonly List<string> boolComboBoxValues = new List<string>()
        {
            "Inactive",
            "Active"
        };

        #region Properties
        public int VehicleID
        {
            get
            {
                return this.virtualvehicle.vehicle.ID;
            }
            set
            {
                if (this.virtualvehicle.vehicle.ID != value)
                {
                    this.virtualvehicle.vehicle.ID = value;
                    this.virtualvehicle.SetUrl(BASE_URL);
                    NotifyPropertyChanged("VehicleID");
                }
            }
        }

        public IList<Param> Parameters
        {
            get
            {
                return this.virtualvehicle.vehicle.Params;
            }
        }
        
        // Setter is dependent on Params.cs types.
        public string StringValue
        {
            get
            {
                string rc = string.Empty;
                if (this.SelectedParam != null)
                {
                    rc = this.SelectedParam.Value;
                }

                return rc;
            }
            set
            {
                bool success = false;
                if (this.selectedParam != null)
                {
                    Type paramType = selectedParam.GetValueType();
                    if (paramType == typeof(string))
                    {
                        success = selectedParam.setText(value);
                    }
                    else if (paramType == typeof(double))
                    {
                        try
                        {
                            double result = double.Parse(value);
                            success = selectedParam.setText(result);
                        }
                        catch (FormatException) { }
                        catch (OverflowException) { }
                    }
                    else if (paramType == typeof(int))
                    {
                        try
                        {
                            int result = int.Parse(value);
                            success = selectedParam.setText(result);
                        }
                        catch (FormatException) { }
                        catch (OverflowException) { }
                    }
                }
                if (success)
                {
                    NotifyPropertyChanged("StringValue");
                    NotifyPropertyChanged("SelectedParam");
                }
            }
        }
        public List<string> BoolComboBoxValues
        {
            get
            {
                return boolComboBoxValues;
            }
        }

        public int SelectedBoolComboBoxIndex
        {
            get
            {
                int result = 0;
                if ((this.selectedParam != null) && (this.selectedParam.GetValueType() == typeof(bool)))
                {
                    result = (this.selectedParam.GetBoolValue()) ? 1 : 0;
                }
                return result;
            }
            set
            {
                bool success = false;
                if ((this.selectedParam != null) && (this.selectedParam.GetValueType() == typeof(bool)))
                {
                    bool newValue = (value == 0) ? false : true;

                    success = this.selectedParam.setText(newValue);
                }

                if (success)
                {
                    NotifyPropertyChanged("SelectedBoolComboBoxIndex");
                    NotifyPropertyChanged("SelectedParam");
                }
            }
        }


        private Param selectedParam;
        public Param SelectedParam
        {
            get
            {
                return this.selectedParam;
            }
            set
            {
                this.selectedParam = value;
                NotifyPropertyChanged("StringValue");
                NotifyPropertyChanged("SelectedBoolComboBoxIndex");
                NotifyPropertyChanged("ShowBoolComboBox");
                NotifyPropertyChanged("ShowStringTextBox");
            }
        }

        public System.Windows.Visibility ShowStringTextBox
        {
            get
            {
                System.Windows.Visibility result = System.Windows.Visibility.Hidden;
                if ((this.selectedParam != null) && (this.selectedParam.GetValueType() != typeof(bool)))
                {
                    result = System.Windows.Visibility.Visible;
                }

                return result;
            }
        }
        public System.Windows.Visibility ShowBoolComboBox
        {
            get
            {
                System.Windows.Visibility result = System.Windows.Visibility.Hidden;
                if ((this.selectedParam != null) && (this.selectedParam.GetValueType() == typeof(bool)))
                {
                    result = System.Windows.Visibility.Visible;
                }

                return result;
            }
        }
        #endregion

        public MainWindowViewModel()
        {
            this.virtualvehicle = new VehicleDiagnostics(DEFAULT_ID, VERSION, KEY, BASE_URL);

            this.AppendAtvParams();
        }

        public void AppendAtvParams()
        {
            foreach (var parm in this.atvParams)
            {
                this.virtualvehicle.AddParam(parm);
            }
        }

        public void PostParamsCommand()
        {
            string error;

            // Reference: https://stackoverflow.com/questions/3354893
            long now = (long)DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;

            foreach (Param parm in this.virtualvehicle.vehicle.Params)
            {
                parm.Timestamp = now;
            }

            if (this.virtualvehicle.PostData(out error))
            {
                System.Windows.MessageBox.Show("Sent the parameters successfully!", "Success", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
            else
            {
                System.Windows.MessageBox.Show(string.Format("Failed to send the parameters, with the following error: {0}", error), "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        public void CloseWindow(object obj)
        {
            System.Windows.Window window = obj as System.Windows.Window;
            window.Close();
        }

        public void OpenAboutWindow()
        {
            VirtualVehicle.Windows.AboutWindow dash = new Windows.AboutWindow();
            dash.ShowInTaskbar = false;

            dash.ShowDialog();
        }

        public void CopyBaseUrl()
        {
            System.Windows.Clipboard.SetText(BASE_URL);
        }

        public void SetAllBools(bool active)
        {
            foreach(Param parm in this.virtualvehicle.vehicle.Params)
            {
                if (parm.GetValueType() == typeof(bool))
                {
                    parm.setText(active);
                }
            }

            NotifyPropertyChanged("SelectedBoolComboBoxIndex");
        }

        #region Commands

        private ICommand sendCommand;
        public ICommand SendCommand
        {
            get
            {
                if (sendCommand == null)
                {
                    sendCommand = new RelayCommand(param => this.PostParamsCommand(), null);
                }
                return sendCommand;
            }
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

        private ICommand aboutCommand;
        public ICommand AboutCommand
        {
            get
            {
                if (aboutCommand == null)
                {
                    aboutCommand = new RelayCommand(param => this.OpenAboutWindow(), null);
                }
                return aboutCommand;
            }
        }

        private ICommand copyUrlCommand;
        public ICommand CopyUrlCommand
        {
            get
            {
                if (copyUrlCommand == null)
                {
                    copyUrlCommand = new RelayCommand(param => this.CopyBaseUrl(), null);
                }
                return copyUrlCommand;
            }
        }


        private ICommand setAllActiveCommand;
        public ICommand SetAllActiveCommand
        {
            get
            {
                if (setAllActiveCommand == null)
                {
                    setAllActiveCommand = new RelayCommand(param => this.SetAllBools(true), null);
                }
                return setAllActiveCommand;
            }
        }

        private ICommand setAllInactiveCommand;
        public ICommand SetAllInactiveCommand
        {
            get
            {
                if (setAllInactiveCommand == null)
                {
                    setAllInactiveCommand = new RelayCommand(param => this.SetAllBools(false), null);
                }
                return setAllInactiveCommand;
            }
        }
        #endregion

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
