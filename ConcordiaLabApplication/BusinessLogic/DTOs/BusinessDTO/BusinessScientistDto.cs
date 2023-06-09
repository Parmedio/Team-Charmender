﻿namespace BusinessLogic.DTOs.BusinessDTO;

public record BusinessScientistDto
{
    public int Id { get; set; }
    public string TrelloToken { get; set; } = null!;
    public string Name { get; set; } = null!;
}
