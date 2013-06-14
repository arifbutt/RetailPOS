﻿using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RetailPOS.Core;
using RetailPOS.RetailPOSService;

namespace RetailPOS.ViewModel
{
    public class CategoryViewModel : ViewModelBase
    {
        #region Declare Public and private Data member
        private ObservableCollection<ProductCategoryDTO> _lstCategories;
        
        public ObservableCollection<ProductDTO> _lstProduct;        
        public RelayCommand<ProductCategoryDTO> SelectProductCommand { get; private set; }
        private bool _firstPopupIsOpen;
        public  RelayCommand OpenFirstPopupCommand { get; private set; }
        private bool _OpenLooseCatPopupIsOpen;
        public RelayCommand OpenLooseCatPopupCommand { get; private set; }
        public RelayCommand RefershListBoxCommand { get; private set; }
        public ObservableCollection<ProductCategoryDTO> lstLooseCategories { get; private set; }

        public ObservableCollection<ProductCategoryDTO> lstCategories
        {
            get { return _lstCategories; }
            set
            {
                _lstCategories = value;
                RaisePropertyChanged("lstCategories");
            }
        }
        
        public ObservableCollection<ProductDTO> lstProduct
        {
            get { return _lstProduct; }
            set
            {
                _lstProduct = value;
                RaisePropertyChanged("lstProduct");
            }
        }

        public bool OpenLooseCatPopupIsOpen
        {
            get { return _OpenLooseCatPopupIsOpen; }
            set
            {
                _OpenLooseCatPopupIsOpen = value;
                RaisePropertyChanged("OpenLooseCatPopupIsOpen");
            }
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

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryViewModel"/> class.
        /// </summary>
        public CategoryViewModel()
        {
            lstCategories = new ObservableCollection<ProductCategoryDTO>();
            lstLooseCategories = new ObservableCollection<ProductCategoryDTO>();
            AddCategories();
            AddLooseCategories();
            SelectProductCommand = new RelayCommand<ProductCategoryDTO>(FillProducts);
            OpenFirstPopupCommand = new RelayCommand(OpenFirstPopupClick);
            OpenLooseCatPopupCommand = new RelayCommand(OpenLooseCatPopupClick);
            RefershListBoxCommand = new RelayCommand(RefereshListBox);
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Adds the loose categories.
        /// </summary>
        private void AddLooseCategories()
        {
            lstLooseCategories = new ObservableCollection<ProductCategoryDTO>(from item in ServiceFactory.ServiceClient.GetCategories()
                                                                         select item);
        }

        /// <summary>
        /// Refereshes the list box.
        /// </summary>
        private void RefereshListBox()
        {
            lstCategories.Clear();
            AddCategories();

        }

        /// <summary>
        /// Fills the products.
        /// </summary>
        /// <param name="productCategory">The product category.</param>
        private void FillProducts(ProductCategoryDTO productCategory)
        {
            RetailPOSService.RetailPOSServiceContractClient serviceClient = new RetailPOSService.RetailPOSServiceContractClient();
            lstProduct = new ObservableCollection<ProductDTO>(from item in serviceClient.GetProductByCategory(productCategory.Id)
                                                                         select item);
        }

        /// <summary>
        /// Opens the first popup click.
        /// </summary>
        private void OpenFirstPopupClick()
        {
            FirstPopupIsOpen = true;
        }

        /// <summary>
        /// Opens the loose cat popup click.
        /// </summary>
        private void OpenLooseCatPopupClick()
        {
            OpenLooseCatPopupIsOpen = true;
        }

        /// <summary>
        /// Adds the categories.
        /// </summary>
        private void AddCategories()
        {
            try
            {
                lstCategories = new ObservableCollection<ProductCategoryDTO>(from item in ServiceFactory.ServiceClient.GetCategories()
                                                                             select item);
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}