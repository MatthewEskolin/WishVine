using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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
    public async Task<IEnumerable<WishListDTO>> GetAsync()
    {
        var wishLists = await WishListService.GetWishLists();
        var result = wishLists.Select(x => _mapper.Map<WishListDTO>(x));
        return result;
    }

    //change 5 in main

    [HttpGet("{id}")] 
    public async Task<WishListDTO> GetAsync(Guid id)
    {
        var wishList = await WishListService.GetWishList(id);

        var result = _mapper.Map<WishListDTO>(wishList);

        return result;
    }

    //[HttpPost]
    //public async Task<WishListDTO> PostAsync([FromBody]WishListDTO wishList)
    //{
    //    var wishListEntity = _mapper.Map<WishList>(wishList);
    //    var result = await WishListService.SaveWishList(wishListEntity);
    //    return _mapper.Map<WishListDTO>(result);
    //}

    //[HttpPost]
    ////[Route("DeleteWishList")]
    //public async Task<IActionResult> DeleteWishList([FromBody] JObject id)
    //{
    //    var guidValue = id["id"]?.ToString();
    //    if (guidValue == null)
    //    {
    //        return BadRequest("Invalid Id");
    //    }

    //    await WishListService.DeleteWishList(Guid.Parse(guidValue));
    //    return Ok("List Deleted");
    //}

    //[HttpPost]
    //[Route("DeleteWishListhide")]
    //public async Task<IActionResult> DeleteWishList2([FromBody] JObject id)
    //{
    //    var guidValue = id["id"]?.ToString();
    //    if (guidValue == null)
    //    {
    //        return BadRequest("Invalid Id");
    //    }

    //    await WishListService.DeleteWishList(Guid.Parse(guidValue));
    //    return Ok("List Deleted");
    //}

    //[HttpPost]
    //public async Task<IActionResult> Post([FromBody] JObject id)
    //{
    //    var guidValue = id["id"]?.ToString();
    //    if (guidValue == null)
    //    {
    //        return BadRequest("Invalid Id");
    //    }

    //    await WishListService.DeleteWishList(Guid.Parse(guidValue));
    //    return Ok("List Deleted");
    //}

    
    [HttpPost]
    [Route("DeleteWishList")]
    public async Task<IActionResult> DeleteWishList3(GuidDTO guid)
    {


        var parse = Guid.TryParse(guid.ID.AsSpan(),out var result);
        if (!parse)
        {
            return BadRequest("Invalid Id");
        }

        await WishListService.DeleteWishList(result);
        return Ok("List Deleted");
    }

}