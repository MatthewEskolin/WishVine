using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WishVine.Shared;

namespace WishVine.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class WishListController : ControllerBase
{
    private readonly ILogger<WishListController> _logger;
    private WishListService WishListService { get; set; }

    public WishListController(ILogger<WishListController> logger, WishListService wishListService, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        WishListService = wishListService;
    }

    //WishList Storage (get from db later)
    //private readonly List<WishListDTO> _wishLists = new()
    //{


    //    new WishListDTO() { Name = "Matt's Wish List" },
    //    new WishListDTO() { Name = "Jerry's Wish List" },
    //    new WishListDTO() { Name = "Amanda's Wish List" },
    //};


    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly IMapper _mapper;


    [HttpGet]
    public IEnumerable<WishListDTO> Get()
    {
        var wishLists = WishListService.GetWishLists();

        var result = wishLists.Select(x => _mapper.Map<WishListDTO>(x));

        return result;
    }
}