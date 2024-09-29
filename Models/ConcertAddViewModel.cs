using System;
using System.ComponentModel.DataAnnotations;

public class ConcertAddViewModel
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Date)]
    public DateTime ConcertDate { get; set; }

    [Required]
    public string Location { get; set; } = string.Empty;
}
