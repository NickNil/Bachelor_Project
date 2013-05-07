using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prototype_Solution
{
    public class ListBoxItemEventArgs : EventArgs
    {
        private int index;
        public ListBoxItemEventArgs(int index)
        {
            this.index = index;
        }
        public int Index
        {
            get
            {
                return this.index;
            }
        }
    }

    /// <summary>  
    /// Represents a ListBox with events for when adding and removing items.   
    /// In order for this to work the AddItem, RemoveItem, InsertItem and ClearItems methods  
    /// of this class must be used rather than accessing the Items collection it self.  
    /// </summary>  
    public class ListBoxWithEvents : ListBox
    {
        public event EventHandler<ListBoxItemEventArgs> ItemAdded;
        public event EventHandler<ListBoxItemEventArgs> ItemRemoved;

        //public new ListBox.ObjectCollection Items
        //{
        //    get
        //    {
        //        throw (new InvalidOperationException(
        //            "Use the built in methods instead for manipulating the collection directly"));
        //    }
        //}

        public void AddItemRange(object[] items)
        {
            foreach (object item in items)
                this.AddItem(item);
        }

        public void AddItem(object item)
        {
            this.InsertItem(base.Items.Count, item);
        }

        public void InsertItem(int index, object item)
        {
            base.Items.Insert(index, item);
            this.OnItemAdded(index);
        }

        public void RemoveItem(object item)
        {
            int index = base.Items.IndexOf(item);
            if (index > -1)
                this.RemoveItemAt(index);
        }

        public void ClearItems()
        {
            for (int i = base.Items.Count - 1; i >= 0; i--)
                this.RemoveItemAt(i);
        }

        public void RemoveItemAt(int index)
        {
            base.Items.RemoveAt(index);
            this.OnItemRemoved(index);
        }

        protected virtual void OnItemAdded(int index)
        {
            if (this.ItemAdded != null)
                this.ItemAdded(this, new ListBoxItemEventArgs(index));
        }

        protected virtual void OnItemRemoved(int index)
        {
            if (this.ItemRemoved != null)
                this.ItemRemoved(this, new ListBoxItemEventArgs(index));
        }
    }
}