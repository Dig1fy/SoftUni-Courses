using System;

namespace SULS.ViewModels.Problems
{
    public class SubmissionViewModel
    {
        public string Username { get; set; }

        public string SubmissionId { get; set; }

        public string CreatedOn { get; set; }

        public int AchievedResult { get; set; }

        public int MaxPoints { get; set; }

        public int Percentage => (int)Math.Round(AchievedResult * 100.0M / MaxPoints);
    }
}