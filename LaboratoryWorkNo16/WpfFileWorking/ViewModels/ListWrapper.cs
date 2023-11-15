using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace WpfFileWorking.ViewModels
{
    public class ListWrapper
    {
        private readonly List<string> _targetList;
        private readonly DeepObservableCollection<ObservableString> _observableList;

        public DeepObservableCollection<ObservableString> ObservableList => _observableList;

        public ListWrapper(List<string> targetList)
        {
            _targetList = targetList;
            _observableList = new DeepObservableCollection<ObservableString>();
            InitializeObservableStrings();
            
            _observableList.CollectionChanged += ObservableListOnCollectionChanged;
        }

        private void InitializeObservableStrings()
        {
            foreach (var stringValue in _targetList)
            {
                _observableList.Add(new ObservableString(stringValue));
            }
        }

        private void ObservableListOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var type = e.Action;
            switch (type)
            {
                case NotifyCollectionChangedAction.Add:
                    var index = e.NewStartingIndex;
                    _targetList.Insert(index, (e.NewItems[0] as ObservableString).Value);
                    break;
                
                case NotifyCollectionChangedAction.Remove:
                    var removeIndex = e.OldStartingIndex;
                    _targetList.RemoveAt(removeIndex);
                    break;
                
                case NotifyCollectionChangedAction.Replace:
                    var replaceIndex = e.NewStartingIndex;
                    _targetList[replaceIndex] = _observableList[replaceIndex].Value;
                    break;
            }
        }
    }
}