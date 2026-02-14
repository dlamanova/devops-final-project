using Microsoft.AspNetCore.Mvc;
using PlantsApi.Models;

namespace PlantsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlantsController : ControllerBase
{
    // In-memory data storage
    private static List<Plant> plants = new List<Plant>
    {
        new Plant { Id = 1, Name = "Monstera", Species = "Monstera deliciosa", WateringFrequencyDays = 7, PlantedDate = new DateTime(2024, 1, 15) },
        new Plant { Id = 2, Name = "Snake Plant", Species = "Sansevieria trifasciata", WateringFrequencyDays = 14, PlantedDate = new DateTime(2024, 2, 1) },
        new Plant { Id = 3, Name = "Pothos", Species = "Epipremnum aureum", WateringFrequencyDays = 5, PlantedDate = new DateTime(2024, 3, 10) }
    };

    /// <summary>
    /// Get all plants
    /// </summary>
    /// <returns>List of all plants</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Plant>> GetAllPlants()
    {
        return Ok(plants);
    }

    /// <summary>
    /// Get a specific plant by ID
    /// </summary>
    /// <param name="id">Plant ID</param>
    /// <returns>Plant object if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Plant> GetPlantById(int id)
    {
        var plant = plants.FirstOrDefault(p => p.Id == id);
        
        if (plant == null)
        {
            return NotFound(new { message = $"Plant with ID {id} not found" });
        }
        
        return Ok(plant);
    }
}