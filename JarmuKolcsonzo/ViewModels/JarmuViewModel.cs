using JarmuKolcsonzo.Models;
using JarmuKolcsonzo.Repositories;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace JarmuKolcsonzo.ViewModels
{
    public class JarmuViewModel : ObservableObject
    {
        private GenericRepository<jarmu, JKContext> jarmuRepo;

        private ObservableCollection<jarmu> _jarmuvek;
        // Ezt jelenítjük meg a View rétegen
        public ObservableCollection<jarmu> Jarmuvek
        {
            get { return _jarmuvek; }
            set { SetProperty(ref _jarmuvek, value); }
        }

        private string _searchKey;
        public string SearchKey
        {
            get { return _searchKey; }
            set 
            {
                SetProperty(ref _searchKey, value);
            }
        }

        public JarmuViewModel()
        {
            var context = new JKContext();
            jarmuRepo = new GenericRepository<jarmu, JKContext>(context);
            Jarmuvek = new ObservableCollection<jarmu>(
                jarmuRepo.GetAll());
        }


    }
}