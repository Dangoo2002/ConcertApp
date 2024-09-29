using System;
using System.ComponentModel.DataAnnotations;

public class Concert
{
    public int ConcertId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;  

    [Required]
    public DateTime ConcertDate { get; set; }

    [Required]
    public string Location { get; set; } = string.Empty;  
}
