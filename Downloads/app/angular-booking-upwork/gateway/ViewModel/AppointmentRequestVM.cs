using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gateway;

public class AppointmentRequestVM
{
    [JsonPropertyName("requestID")]
    public int RequestID { get; }

    [JsonPropertyName("childID")]
    [Required(ErrorMessage = "Child is required")]
    public int ChildID { get; set; }

    [JsonPropertyName("psychologistID")]
    [Required(ErrorMessage = "Psychologist is required")]
    public int PsychologistID { get; set; }

    [JsonPropertyName("preferredDateTime")]
    [Required(ErrorMessage = "Preferred Date and Time is required")]
    public DateTime PreferredDateTime { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("comments")]
    public string? Comments { get; set; }
}

public class ApprovalVM
{
    [JsonPropertyName("requestID")]
    public int RequestID { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
