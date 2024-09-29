using System;

public class ConcertBaseViewModel
{
    public int ConcertId { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime ConcertDate { get; set; }

    public string Location { get; set; } = string.Empty;
}
