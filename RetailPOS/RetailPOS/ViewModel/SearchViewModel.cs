﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

namespace RetailPOS.ViewModel
{
   public class SearchViewModel : ViewModelBase
    {
       #region Declare Public and private Data member

       public List<Search> lstSearch { get; private set; }
       private RelayCommand _openFirstPopupCommand;
       private bool _firstPopupIsOpen;
       public RelayCommand OpenFirstPopupCommand
       {
           get { return _openFirstPopupCommand ?? (_openFirstPopupCommand = new RelayCommand(OpenFirstPopupClick)); }
       }

       public bool FirstPopupIsOpen
       {
           get { return _firstPopupIsOpen; }
           set
           {
               _firstPopupIsOpen = value;
               RaisePropertyChanged("FirstPopupIsOpen");
           }
       }
       #endregion

       #region Deaclare Constructor
      
       /// <summary>
       /// Initializes a new instance of the <see cref="SearchViewModel"/> class.
       /// </summary>
       public SearchViewModel()
       {
           lstSearch = new List<Search>();
           FillListSearch();
       }

       /// <summary>
       /// Opens the first popup click.
       /// </summary>
       private void OpenFirstPopupClick()
       {
           FirstPopupIsOpen = true;
       }



       /// <summary>
       /// Fills the list search.
       /// </summary>       
       private void FillListSearch()
       {
           lstSearch.Add(new Search { CustomerName = "Anil" , Product = "test" });
           lstSearch.Add(new Search { CustomerName = "Bob", Product = "test1" });
           lstSearch.Add(new Search { CustomerName = "Cat", Product = "abc" });
       }
       #endregion
    }

   public class Search
   {
       public string Product { get; set; }
       public string CustomerName { get; set; }
   }
}
