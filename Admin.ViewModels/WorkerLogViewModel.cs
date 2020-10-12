using System;

namespace Admin.ViewModels
{
    public class WorkerLogViewModel
    {
        public string Name { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}