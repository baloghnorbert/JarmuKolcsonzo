using JarmuKolcsonzo.Models;
using JarmuKolcsonzo.Repositories;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace JarmuKolcsonzo.ViewModels
{
    public class UgyfelViewModel : ObservableObject
    {
        private GenericRepository<ugyfel, JKContext> ugyfelRepo;

        private ObservableCollection<ugyfel> _ugyfelek;
        // Ezt jelenítjük meg a View rétegen
        public ObservableCollection<ugyfel> Ugyfelek
        {
            get { return _ugyfelek; }
            set { SetProperty(ref _ugyfelek, value); }
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

        public UgyfelViewModel()
        {
            var context = new JKContext();
            ugyfelRepo = new GenericRepository<ugyfel, JKContext>(context);
            Ugyfelek = new ObservableCollection<ugyfel>(ugyfelRepo.GetAll());
        }

    }
}