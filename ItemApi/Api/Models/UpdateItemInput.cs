namespace Api.Models;

public record UpdateItemInput(Guid Key, string Name, string Description, string Breed, string PhotoUrl);