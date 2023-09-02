using Microsoft.AspNetCore.Mvc;
using WishVine.Server.DomainData;
using WishVine.Shared;

namespace WishVine.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class WishListController : ControllerBase
{
    private readonly ILogger<WishListController> _logger;
    private readonly IMapper _mapper;
    private WishListService WishListService { get; set; }

    public WishListController(ILogger<WishListController> logger, WishListService wishListService, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        WishListService = wishListService;
    }

    /// <summary>
    /// Get all Wish Lists
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IEnumerable<WishListDTO>> GetAsync()
    {
        var wishLists = await WishListService.GetWishLists();
        var result = wishLists.Select(x => _mapper.Map<WishListDTO>(x));
        return result;
    }

    /// <summary>
    /// Get Wish List by Guid
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")] 
    public async Task<WishListDTO> GetAsync(Guid id)
    {
        var wishList = await WishListService.GetWishList(id);

        var result = _mapper.Map<WishListDTO>(wishList);

        return result;
    }

    /// <summary>
    /// Create a new wish list 
    /// </summary>
    /// <param name="wishList"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<WishListDTO> PostAsync([FromBody] WishListDTO wishList)
    {
        var wishListEntity = _mapper.Map<WishList>(wishList);
        var result = await WishListService.SaveWishList(wishListEntity);
        return _mapper.Map<WishListDTO>(result);
    }

    /// <summary>
    /// Delete a wish list by Guid
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("DeleteWishList")]
    public async Task<IActionResult> DeleteWishList(GuidDTO guid)
    {
        var parse = Guid.TryParse(guid.ID.AsSpan(),out var result);
        if (!parse)
        {
            _logger.LogError("Invalid WishList ID in controller");
            return BadRequest("Invalid Id");

        }

        await WishListService.DeleteWishList(result);
        return Ok("List Deleted");
    }

}