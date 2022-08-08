using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using MyFirstWpfApp;

namespace Stackpanel
{
    public class StackpanelViewModel : INotifyPropertyChanged
    {
      
        public People? FirstPeople
        {
            get
            {
                return people;
            }
            set
            {
                people = value;
                OnPropertyChanged();
            }
        }
       
        public People? SecondPeople
        {
            get
            {
                return people2;
            }
            set
            {
                people2 = value;
                OnPropertyChanged();
            }
        }

        #region MyRegion
        public event PropertyChangedEventHandler? PropertyChanged;



        private People? people;
        private People? people2;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        } 
        #endregion
    }
}
