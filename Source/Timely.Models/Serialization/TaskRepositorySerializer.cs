namespace Timely.Models.Serialization
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml;

    public class TaskRepositorySerializer : ITaskRepositorySerializer
    {
        readonly NetDataContractSerializer serializer = new NetDataContractSerializer();

        public ITaskRepository Deserialize(string fileName)
        {
            using (XmlReader xmlReader = XmlReader.Create(fileName))
                return (ITaskRepository)serializer.ReadObject(xmlReader);
        }

        public void Serialize(ITaskRepository taskRepository, string fileName)
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(fileName, CreateWriterSettings()))
                serializer.WriteObject(xmlWriter, taskRepository);
        }

        XmlWriterSettings CreateWriterSettings()
        {
            return new XmlWriterSettings { Indent = true, IndentChars = "\t", NewLineChars = Environment.NewLine };
        }
    }
}