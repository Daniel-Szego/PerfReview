using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Axalta.EMEA.PerformanceReview.TimerJobs.Jobs;

namespace Axalta.EMEA.PerformanceReview.TimerJobs.Features.Axalta.EMEA.PerformanceReview.Unprocessed
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("2019d116-52b2-4b75-b09f-2b00ab38b9bf")]
    public class AxaltaEMEAPerformanceReviewEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        //public override void FeatureActivated(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}

        const string JobName = "Unprocessed_Performance";
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SPWebApplication parentWebApp = (SPWebApplication)properties.Feature.Parent;
                    SPSite site = properties.Feature.Parent as SPSite;
                    DeleteExistingJob(JobName, parentWebApp);
                    CreateJob(parentWebApp);
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool CreateJob(SPWebApplication site)
        {
            bool jobCreated = false;
            try
            {

                Unprocessed_Performance job = new Unprocessed_Performance(JobName, site);
                SPMinuteSchedule schedule = new SPMinuteSchedule();
                schedule.BeginSecond = 0;
                schedule.EndSecond = 59;
                schedule.Interval = 15;
                job.Schedule = schedule;

                job.Update();
            }
            catch (Exception)
            {
                return jobCreated;
            }
            return jobCreated;
        }
        public bool DeleteExistingJob(string jobName, SPWebApplication site)
        {
            bool jobDeleted = false;
            try
            {
                foreach (SPJobDefinition job in site.JobDefinitions)
                {
                    if (job.Name == jobName)
                    {
                        job.Delete();
                        jobDeleted = true;
                    }
                }
            }
            catch (Exception)
            {
                return jobDeleted;
            }
            return jobDeleted;
        }
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {

            lock (this)
            {
                try
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        SPWebApplication parentWebApp = (SPWebApplication)properties.Feature.Parent;
                        DeleteExistingJob(JobName, parentWebApp);
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
