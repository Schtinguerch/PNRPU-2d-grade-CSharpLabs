using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Documents;

namespace WpfFileWorking.ViewModels
{
    public class DeepObservableCollection<T> : ObservableCollection<T>
    {
        public DeepObservableCollection() : base()
        {
            CollectionChanged += MainCollectionChanged;
        }
        
        public DeepObservableCollection(List<T> list)
        {
            CollectionChanged += MainCollectionChanged;
            if (list is null)
            {
                return;
            }
            
            foreach (var obj in list)
            {
                Add(obj);
            }
        }

        private void MainCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            SubscribeNewItemsToPropertyChanged(e.NewItems);
            UnsubscribeOldItemsFromPropertyChanged(e.OldItems);
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var eventArgs = new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Replace, 
                new List<object> { sender },
                new List<object> { sender }, 
                IndexOf((T)sender));
            
            OnCollectionChanged(eventArgs);
        }

        private void SubscribeNewItemsToPropertyChanged(IList newItems)
        {
            if (newItems is null)
            {
                return;
            }

            foreach (var item in newItems)
            {
                if (!(item is INotifyPropertyChanged notifiable)) continue;
                notifiable.PropertyChanged += ItemPropertyChanged;
            }
        }

        private void UnsubscribeOldItemsFromPropertyChanged(IList oldItems)
        {
            if (oldItems is null)
            {
                return;
            }
            
            foreach (var item in oldItems)
            {
                if (!(item is INotifyPropertyChanged notifiable)) continue;
                notifiable.PropertyChanged += ItemPropertyChanged;
            }
        }
    }
}