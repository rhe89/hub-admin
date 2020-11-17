using System;
using Hub.Storage.Core.Dto;

namespace Admin.BlazorApp.ViewModel
{
    public class BackgroundTaskConfigurationViewModel
    {
        public string Name { get; set; }
        public RunIntervalType RunIntervalType { get; set; }
        public DateTime LastRun { get; set; }
    }
}