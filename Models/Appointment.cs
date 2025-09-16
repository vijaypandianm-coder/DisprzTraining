using System.ComponentModel.DataAnnotations;

namespace DisprzTraining.Models
{
    public enum RecurrenceType
    {
        None,
        Daily,
        Weekly
    }

    public enum AppointmentCategory
    {
        Meeting,
        Call,
        Reminder,
        Other
    }

    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        public TimeOnly Time { get; set; }

        [Required]
        public RecurrenceType Recurrence { get; set; }

        [Required]
        public AppointmentCategory Category { get; set; }

        public int TimeZoneOffsetMinutes { get; set; } = 0;

        public string? Color { get; set; }
    }
}
