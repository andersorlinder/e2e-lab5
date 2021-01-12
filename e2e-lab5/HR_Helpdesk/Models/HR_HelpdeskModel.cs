using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HR_Helpdesk.Models
{
    public class HR_HelpdeskModel
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("employmentNumber")]
        public int EmploymentNumber { get; set; }

        [Required]
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("chief")]
        public string Chief { get; set; }

        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}