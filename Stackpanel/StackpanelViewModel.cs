using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
                Thread.Sleep(5000);
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
                Thread.Sleep(2500);
                return people2;
            }
            set
            {
                people2 = value;
                OnPropertyChanged();
            }
        }

        public People? Default
        {
            get
            {
                Thread.Sleep(1000);
                return new People() { Name = "Olegs", Family = "Minienkovs" };
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
