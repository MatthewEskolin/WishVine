using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishVine.Shared
{
    public class WishListState    {

        public List<WishListDTO> WishLists = new();
        public WishListState() { }


    }

    /// <summary>
    /// DTO or Business Entity? don't know
    /// </summary>
    public class WishListDTO
    {
        public string Name { get; set; } = string.Empty;
        public string UserDisplayName { get; set; } = string.Empty;



    }

    public class WishListItemDTO
    {
        public string Description { get; set; }
        public string Link { get; set; }

        public string ImageLink { get; set; }
        //Image
    }

}
