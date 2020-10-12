using System;
using Hub.Storage.Dto;

namespace Admin.ViewModels
{
    public class BackgroundTaskConfigurationViewModel
    {
        public string Name { get; set; }
        public RunIntervalType RunIntervalType { get; set; }
        public DateTime LastRun { get; set; }
    }
}