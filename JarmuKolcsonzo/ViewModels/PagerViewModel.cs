using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarmuKolcsonzo.ViewModels
{
    public abstract class PagerViewModel : ObservableObject
    {
        private string _searchKey;

        public string SearchKey
        {
            get { return _searchKey; }
            //változás megjelenítése a nézten --> ezért kell az Observable --> olyan min Fx-ben
            set { SetProperty(ref _searchKey, value); }
        }

        public PagerViewModel()
        {
            LoadDataCmd = new RelayCommand(() => LoadData());
        }


        public RelayCommand LoadDataCmd {get; set;}

        protected abstract void LoadData();
    }
}
