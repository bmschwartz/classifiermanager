using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.ServiceModel;
using ClassifierWebService;
using ClassifierServices;

namespace ClassifierServiceClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitializeClassifierDropdown();
        }

        private void InitializeClassifierDropdown()
        {
            using (ChannelFactory<IClassifierServiceInterface> classifierServiceProxy =
            new ChannelFactory<IClassifierServiceInterface>("ClassifierServiceEndpoint"))
            {
                classifierServiceProxy.Open();
                IClassifierServiceInterface classifierService = classifierServiceProxy.CreateChannel();

                string[] classifiers = classifierService.GetClassifiers();
                foreach (string classifier in classifiers)
                {
                    classifierDropDown.Items.Add(classifier);
                }
                classifierServiceProxy.Close();
            }
        }


        private void addJobBtn_Click(object sender, RoutedEventArgs e)
        {
            if (newJobPath.Text == "") return;
            if (classifierDropDown.SelectedValue.ToString() == "") return;

            using (ChannelFactory<IClassifierServiceInterface> classifierServiceProxy =
            new ChannelFactory<IClassifierServiceInterface>("ClassifierServiceEndpoint"))
            {
                classifierServiceProxy.Open();
                IClassifierServiceInterface classifierService = classifierServiceProxy.CreateChannel();
                string filePath = newJobPath.Text;
                //string classifier = newJobClassifier.Text;
                string classifier = classifierDropDown.SelectedValue.ToString();
                classifierService.AddClassifierJob(filePath, classifier);

                classifierServiceProxy.Close();
            }

            newJobPath.Text = "";
        }

        private void getJobsBtn_Click(object sender, RoutedEventArgs e)
        {
            jobQueueWindow.Text = "";
            using (ChannelFactory<IClassifierServiceInterface> classifierServiceProxy =
            new ChannelFactory<IClassifierServiceInterface>("ClassifierServiceEndpoint"))
            {
                classifierServiceProxy.Open();
                IClassifierServiceInterface classifierService = classifierServiceProxy.CreateChannel();
                List<ClassifierJob> classifierQueue = classifierService.GetJobQueue();
                foreach (ClassifierJob j in classifierQueue)
                {
                    jobQueueWindow.AppendText(j.FilePath + " => " + j.ClassifierName + "\n");
                }
                classifierServiceProxy.Close();
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            using (ChannelFactory<IClassifierServiceInterface> classifierServiceProxy =
            new ChannelFactory<IClassifierServiceInterface>("ClassifierServiceEndpoint"))
            {
                classifierServiceProxy.Open();
                IClassifierServiceInterface classifierService = classifierServiceProxy.CreateChannel();

                classifierService.ClearQueue();

                jobQueueWindow.Text = "";

                classifierServiceProxy.Close();
            }
        }

        private void classifierDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}