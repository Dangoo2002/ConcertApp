using System;
using System.ComponentModel.DataAnnotations;

public class ConcertEditViewModel
{
    public int ConcertId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;  // Ensure it's initialized with a default value

    [Required]
    public DateTime ConcertDate { get; set; }

    [Required]
    public string Location { get; set; } = string.Empty;  // Ensure it's initialized with a default value

    public string TicketSalePassword { get; set; } = string.Empty;  // Ensure it's initialized with a default value

    [RegularExpression(@"[A-Z]{3}[0-9]{3}", ErrorMessage = "Promo code must be in the format 'LLLNNN'")]
    public string PromoCode { get; set; } = string.Empty;  // Ensure it's initialized with a default value

    [Range(1, 150000)]
    public int Capacity { get; set; }
}
