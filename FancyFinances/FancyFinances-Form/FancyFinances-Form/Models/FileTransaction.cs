using System;

namespace FancyFinances_Form.Models
{
    // Lightweight DTO used for file-based logging (no EF behavior)
    public class FileTransaction
    {
        public int UserID { get; set; }
        public DateTime Time { get; set; }
        public string Type { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
