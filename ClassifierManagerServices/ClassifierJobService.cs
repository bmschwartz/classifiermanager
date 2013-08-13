using System;
using System.Collections.Generic;
using System.Text;

using ClassifierWebService;
using ClassifierServiceDatabase;

namespace ClassifierServices
{
    public class ClassifierJobService : IClassifierServiceInterface
    {
        public bool AddClassifierJob(string filePath, string classifier)
        {
            ClassifierJobDatabase cdb = new ClassifierJobDatabase();
            ClassifierJob job = new ClassifierJob();
            job.FilePath = filePath;
            job.ClassifierName = classifier;
            cdb.AddClassifierJob(job);

            return true;

        }

        public List<ClassifierJob> GetJobQueue()
        {
            ClassifierJobDatabase adb = new ClassifierJobDatabase();
            List<ClassifierJob> classifierQueue = adb.GetClassifierJobs();

            return classifierQueue;
        }

        public bool ClearQueue()
        {
            ClassifierJobDatabase adb = new ClassifierJobDatabase();
            adb.Erase();
            return true;
        }

        public List<ClassifierJob> GetLastClassifierJob()
        {
            return null;
        }

        public string[] GetClassifiers()
        {
            ClassifierJobDatabase cdb = new ClassifierJobDatabase();
            string[] classifierList = cdb.GetClassifiers();
            return classifierList;
        }
    }
}