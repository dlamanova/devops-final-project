using Microsoft.AspNetCore.Mvc;
using PlantsApi.Controllers;
using PlantsApi.Models;
using FluentAssertions;

namespace PlantsApi.Tests;

public class PlantsControllerTests
{
    private readonly PlantsController _controller;

    public PlantsControllerTests()
    {
        _controller = new PlantsController();
    }

    [Fact]
    public void GetAllPlants_ReturnsOkResult_WithListOfPlants()
    {
        // Act
        var result = _controller.GetAllPlants();

        // Assert
        result.Result.Should().BeOfType<OkObjectResult>();
        var okResult = result.Result as OkObjectResult;
        okResult?.Value.Should().BeAssignableTo<IEnumerable<Plant>>();
        
        var plants = okResult?.Value as IEnumerable<Plant>;
        plants.Should().NotBeNull();
        plants.Should().HaveCount(3);
    }

    [Fact]
    public void GetPlantById_WithValidId_ReturnsOkResult_WithPlant()
    {
        // Arrange
        int validId = 1;

        // Act
        var result = _controller.GetPlantById(validId);

        // Assert
        result.Result.Should().BeOfType<OkObjectResult>();
        var okResult = result.Result as OkObjectResult;
        okResult?.Value.Should().BeOfType<Plant>();
        
        var plant = okResult?.Value as Plant;
        plant.Should().NotBeNull();
        plant?.Id.Should().Be(validId);
        plant?.Name.Should().Be("Monstera");
    }

    [Fact]
    public void GetPlantById_WithInvalidId_ReturnsNotFoundResult()
    {
        // Arrange
        int invalidId = 999;

        // Act
        var result = _controller.GetPlantById(invalidId);

        // Assert
        result.Result.Should().BeOfType<NotFoundObjectResult>();
        var notFoundResult = result.Result as NotFoundObjectResult;
        notFoundResult.Should().NotBeNull();
    }

    [Theory]
    [InlineData(1, "Monstera")]
    [InlineData(2, "Snake Plant")]
    [InlineData(3, "Pothos")]
    public void GetPlantById_ReturnsCorrectPlant_ForEachId(int id, string expectedName)
    {
        // Act
        var result = _controller.GetPlantById(id);

        // Assert
        result.Result.Should().BeOfType<OkObjectResult>();
        var okResult = result.Result as OkObjectResult;
        var plant = okResult?.Value as Plant;
        
        plant.Should().NotBeNull();
        plant?.Name.Should().Be(expectedName);
    }
}