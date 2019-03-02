// ************************************************************************************************
// CAPSTONE G03, 2018-2019
//
// Repository:
//  https://github.com/rahmant3/capstoneROS2018
//
// Description:
//  Object used to deserialize the JSON object containing vehicle parameters. Adapted from Web
//  Service capstone project.
//
// History:
//  2018-12-09 by Samuel Marriot
//  - Created.
//  2018-12-29 by Tamkin Rahman
//  - Add function for retrieving display data.
//  2019-01-03 by Tamkin Rahman
//  - Add functions for setting and getting display data. Also, implement INotifyPropertyChanged
//    in order to update the values when they're changed for databinding.
// ************************************************************************************************

using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VirtualVehicle.Models
{
    public class Param : INotifyPropertyChanged
    {

        private Type valueType = null;

        private string value;
        public string Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
                NotifyPropertyChanged("Value");
                NotifyPropertyChanged("DisplayValue");
            }
        }

        public string DisplayValue
        {
            get
            {
                return this.getDisplayText();
            }
        }

        public string Name { get; set; }
        public int ID { get; set; }
        public string Type { get; set; }
        public string Units { get; set; }
        public long Timestamp { get; set; }
        public string Message { get; set; }


        // Mapping from string to Type.
        private readonly static Dictionary<string, Type> typeMap = new Dictionary<string, Type>()
        {
            {"bool", typeof(bool) },
            {"double", typeof(double) },
            {"int", typeof(int) },
            {"string", typeof(string) }
        };

        public string getDisplayText()
        {
            string result = string.Empty;

            if (this.GetValueType() == typeof(bool))
            {
                result = this.GetBoolValue() ? "Active" : "Inactive";
            }
            else
            {
                result = this.Value;
            }

            if (!string.IsNullOrEmpty(this.Units))
            {
                result += " " + this.Units;
            }

            return result;
        }

        public bool setText(bool input)
        {
            bool rc = false;

            if (this.GetValueType() == typeof(bool))
            {
                rc = true;

                this.Value = input ? "True" : "False";
            }

            return rc;
        }
        public bool setText(string input)
        {
            bool rc = false;

            if (this.GetValueType() == typeof(string))
            {
                rc = true;

                this.Value = input;
            }

            return rc;
        }

        public bool setText(int input)
        {
            bool rc = false;

            if (this.GetValueType() == typeof(int))
            {
                rc = true;

                this.Value = string.Format("{0}", input);
            }

            return rc;
        }

        public bool setText(double input)
        {
            bool rc = false;

            if (this.GetValueType() == typeof(double))
            {
                rc = true;

                this.Value = string.Format("{0}", input);
            }

            return rc;
        }

        public Type GetValueType()
        {
            if (this.valueType == null)
            {
                string key = this.Type.ToLower();
                if (typeMap.ContainsKey(key))
                {
                    this.valueType = typeMap[key];
                }
            }

            return this.valueType;
        }

        /// <summary>
        /// Based on the value of this parameter, a boolean value is returned. Note that this function
        /// does not check whether this parameter's type is "bool".
        /// </summary>
        /// <returns>True if this paramter's value is "true", false otherwise.</returns>
        public bool GetBoolValue()
        {
            bool rc = false;

            rc = string.Equals(this.Value.ToLower(), "true");

            return rc;
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