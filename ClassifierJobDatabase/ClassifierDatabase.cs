using System;
using System.Collections.Generic;
using System.Text;
using ClassifierWebService;

namespace ClassifierServiceDatabase
{
    public class ClassifierJobDatabase
    {
        private static List<ClassifierJob> classifierJobs = new List<ClassifierJob>();
        private static List<string> classifiers = new List<string>(new string[] { "UCI H&E", "TMA ABC" });

        public void AddClassifierJob(ClassifierJob job)
        {
            classifierJobs.Add(job);
        }

        public List<ClassifierJob> GetClassifierJobs()
        {
            return classifierJobs;
        }

        public void Erase()
        {
            classifierJobs.Clear();
        }

        public void AddClassifier(string classifier)
        {
            classifiers.Add(classifier);
        }

        public string[] GetClassifiers()
        {
            return classifiers.ToArray();
        }
    }
}