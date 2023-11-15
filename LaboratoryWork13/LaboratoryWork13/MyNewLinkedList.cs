using LaboratoryWorkNo12;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork13
{
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
    public class MyNewLinkedList<T> : MyOwnLinkedList<T> where T : ICloneable, IComparable
    {
        public MyNewLinkedList(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public override T this[int index]
        {
            get => base[index];
            set
            {
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs(Name, "Change", this[index]));
                base[index] = value;
            }
        }

        public event CollectionHandler CollectionCountChanged;
        public virtual void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args) => CollectionCountChanged?.Invoke(source, args);

        public event CollectionHandler CollectionReferenceChanged;
        public virtual void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args) => CollectionReferenceChanged?.Invoke(source, args);

        public override bool Remove(T item)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(this.Name, "Remove", item));
            return base.Remove(item);
        }

        public override void Add(T value)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(this.Name, "Add", value));
            base.Add(value);
        }
    }
}
