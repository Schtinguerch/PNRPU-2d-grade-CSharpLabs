using System;

namespace LaboratoryWork13
{
    public class JournalEntry
    {
        public string CollectionName { get; }
        public string EventType { get; }
        public string ChangedObjectInformation { get; }
        public DateTime EventDateTime => _eventDateTime;

        private DateTime _eventDateTime = DateTime.Now;

        public JournalEntry(object changedObject, string collectionName, string eventType)
        {
            CollectionName = collectionName;
            EventType = eventType;
            ChangedObjectInformation = changedObject.ToString();
        }

        public override string ToString() =>
            $"Коллекция:   {CollectionName}\n" +
            $"Тип события: {EventType}\n" +
            $"Время:       {EventDateTime}\n" +
            $"Изменённый объект:\n" +
            $">>> {ChangedObjectInformation}";
    }
}
