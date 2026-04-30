using System;
using System.Collections.Generic;
using System.Text;

namespace FancyFinances_Form.Models
{
    public class Goals
    {
        public int GoalID { get; set; }
        public string GoalDescription { get; set; } = string.Empty;
        public decimal AllocatedAmount { get; set; }
        public decimal TargetAmount { get; set; }
        public int UserID { get; set; }

    }
}
