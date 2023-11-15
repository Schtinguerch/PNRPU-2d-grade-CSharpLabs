using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratoryWorkNo12;

namespace LaboratoryWork13
{
    public class Journal : MyOwnLinkedList<JournalEntry>
    {
        public string Name { get; set; } = "";
        public Journal(string name)
        {
            Name = name;
        }
        
        public void AddChanged(object changedObject, string collectionName)
        {
            Add(new JournalEntry(changedObject, collectionName, "Изменение объекта в коллекции"));
        }

        public void AddRemoved(object changedObject, string collectionName)
        {
            Add(new JournalEntry(changedObject, collectionName, "Удаление объекта из коллекции"));
        }

        public void AddAdded(object changedObject, string collectionName)
        {
            Add(new JournalEntry(changedObject, collectionName, "Добавление объекта в коллекцию"));
        }

        public override string ToString()
        {
            if (First == null)
            {
                return string.Empty;
            }

            return string.Join("\n", this);
        }

        public void CollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            if (args.EventType == "Remove")
            {
                AddRemoved(args.ChangedObject, args.CollectionName);
                return;
            }

            if (args.EventType == "Add")
            {
                AddAdded(args.ChangedObject, args.CollectionName);
                return;
            }
        }

        public void CollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            AddChanged(args.ChangedObject, args.CollectionName);
        }
    }
}
