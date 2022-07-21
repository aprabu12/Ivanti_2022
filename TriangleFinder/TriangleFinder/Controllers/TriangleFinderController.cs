using Microsoft.AspNetCore.Mvc;

namespace TriangleFinder.Controllers;

/// <summary>
/// WebAPI to map triangles by label or coordinates in square of right angle triangles
/// 
/// </summary>

[ApiController]
[Route("[controller]")]
public class TriangleFinderController : ControllerBase
{
  

    private readonly ILogger<TriangleFinderController> _logger;

    public TriangleFinderController(ILogger<TriangleFinderController> logger)
    {
        _logger = logger;
    }



    /// <summary>
    /// webApi to return triangle label based on the coordinate.
    /// coordinates must be between 0 and 60 but multiple of 10. vertics can be given in any order
    /// </summary>
    /// <param name="v1x"></param>
    /// <param name="v1y"></param>
    /// <param name="v2x"></param>
    /// <param name="v2y"></param>
    /// <param name="v3x"></param>
    /// <param name="v3y"></param>
    /// <returns></returns>

    [HttpGet]
    [Route("getTriangleLabel")]
    public Triangle getTriangleLabel(int v1x, int v1y, int v2x, int v2y, int v3x, int v3y)
    {
        TriangleMapper mapper = new TriangleMapper(new Triangle(v1x, v1y, v2x, v2y, v3x, v3y));
        return mapper.mapbyCoordinates();
    }
    /// <summary>
    /// webApi to return triangle vertices based on the triangle label.
    /// valid labels are A thorugh F followed by 1 to 12
    /// </summary>
    /// <param name="triangleLabel"></param>
    /// <returns></returns>

    [HttpGet]
    [Route("getTriangleCoordinates")]
    public Triangle getTriangleCoordinates(string triangleLabel)
    {
        if (String.IsNullOrEmpty(triangleLabel))
        {
            throw new ArgumentException("Label cannot be empty or null");
        }
        Console.WriteLine(triangleLabel);
        TriangleMapper mapper = new TriangleMapper(new Triangle(triangleLabel));


        return mapper.mapbyLabel();
    }


}

