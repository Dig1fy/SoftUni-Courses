﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SULS.Data
{
    public class Submission
    {
        public Submission()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(800)]
        public string Code { get; set; }

        public int AchievedResult { get; set; }

        public DateTime CreatedOn{ get; set; }

        public int ProblemId { get; set; }
        public virtual Problem Problem { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
