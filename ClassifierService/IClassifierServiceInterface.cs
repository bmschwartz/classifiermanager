using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace ClassifierWebService
{
    [ServiceContract]
    public interface IClassifierServiceInterface
    {
        [OperationContract]
        bool AddClassifierJob(string filePath, string classifier);

        [OperationContract]
        List<ClassifierJob> GetJobQueue();

        [OperationContract]
        bool ClearQueue();

        [OperationContract]
        string[] GetClassifiers();
    }

    [DataContract]
    public class ClassifierJob
    {
        private string filePath;
        private string classifierName;

        [DataMember]
        public string ClassifierName
        {
            set { this.classifierName = value; }
            get { return this.classifierName; }
        }

        [DataMember]
        public string FilePath
        {
            set { this.filePath = value; }
            get { return this.filePath; }
        }
    }
}