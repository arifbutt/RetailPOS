//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace RetailPOS.PersistenceLayer.Repository.Entities
{
    public partial class product : EntityBase
    {
        #region Primitive Properties
    
        public virtual short id
        {
            get;
            set;
        }
    
        public virtual string barcode
        {
            get;
            set;
        }
    
        public virtual string name
        {
            get;
            set;
        }
    
        public virtual string description
        {
            get;
            set;
        }
    
        public virtual short status_id
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> retail_price
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> wholesale_price
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> tax_rate
        {
            get;
            set;
        }
    
        public virtual Nullable<bool> has_waranty
        {
            get;
            set;
        }
    
        public virtual string image_path
        {
            get;
            set;
        }
    
        public virtual Nullable<short> category_id
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> size
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> weight
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual display_properties display_properties
        {
            get { return _display_properties; }
            set
            {
                if (!ReferenceEquals(_display_properties, value))
                {
                    var previousValue = _display_properties;
                    _display_properties = value;
                    Fixupdisplay_properties(previousValue);
                }
            }
        }
        private display_properties _display_properties;
    
        public virtual ICollection<orderchild> orderchilds
        {
            get
            {
                if (_orderchilds == null)
                {
                    var newCollection = new FixupCollection<orderchild>();
                    newCollection.CollectionChanged += Fixuporderchilds;
                    _orderchilds = newCollection;
                }
                return _orderchilds;
            }
            set
            {
                if (!ReferenceEquals(_orderchilds, value))
                {
                    var previousValue = _orderchilds as FixupCollection<orderchild>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixuporderchilds;
                    }
                    _orderchilds = value;
                    var newValue = value as FixupCollection<orderchild>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixuporderchilds;
                    }
                }
            }
        }
        private ICollection<orderchild> _orderchilds;
    
        public virtual ICollection<product_purchase_history_child> product_purchase_history_child
        {
            get
            {
                if (_product_purchase_history_child == null)
                {
                    var newCollection = new FixupCollection<product_purchase_history_child>();
                    newCollection.CollectionChanged += Fixupproduct_purchase_history_child;
                    _product_purchase_history_child = newCollection;
                }
                return _product_purchase_history_child;
            }
            set
            {
                if (!ReferenceEquals(_product_purchase_history_child, value))
                {
                    var previousValue = _product_purchase_history_child as FixupCollection<product_purchase_history_child>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupproduct_purchase_history_child;
                    }
                    _product_purchase_history_child = value;
                    var newValue = value as FixupCollection<product_purchase_history_child>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupproduct_purchase_history_child;
                    }
                }
            }
        }
        private ICollection<product_purchase_history_child> _product_purchase_history_child;
    
        public virtual ICollection<supplier> suppliers
        {
            get
            {
                if (_suppliers == null)
                {
                    var newCollection = new FixupCollection<supplier>();
                    newCollection.CollectionChanged += Fixupsuppliers;
                    _suppliers = newCollection;
                }
                return _suppliers;
            }
            set
            {
                if (!ReferenceEquals(_suppliers, value))
                {
                    var previousValue = _suppliers as FixupCollection<supplier>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupsuppliers;
                    }
                    _suppliers = value;
                    var newValue = value as FixupCollection<supplier>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupsuppliers;
                    }
                }
            }
        }
        private ICollection<supplier> _suppliers;

        #endregion
        #region Association Fixup
    
        private void Fixupdisplay_properties(display_properties previousValue)
        {
            if (previousValue != null && ReferenceEquals(previousValue.product, this))
            {
                previousValue.product = null;
            }
    
            if (display_properties != null)
            {
                display_properties.product = this;
            }
        }
    
        private void Fixuporderchilds(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (orderchild item in e.NewItems)
                {
                    item.product = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (orderchild item in e.OldItems)
                {
                    if (ReferenceEquals(item.product, this))
                    {
                        item.product = null;
                    }
                }
            }
        }
    
        private void Fixupproduct_purchase_history_child(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (product_purchase_history_child item in e.NewItems)
                {
                    item.product = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (product_purchase_history_child item in e.OldItems)
                {
                    if (ReferenceEquals(item.product, this))
                    {
                        item.product = null;
                    }
                }
            }
        }
    
        private void Fixupsuppliers(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (supplier item in e.NewItems)
                {
                    if (!item.products.Contains(this))
                    {
                        item.products.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (supplier item in e.OldItems)
                {
                    if (item.products.Contains(this))
                    {
                        item.products.Remove(this);
                    }
                }
            }
        }

        #endregion
    }
}