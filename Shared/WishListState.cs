using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishVine.Shared
{
    public class WishListState    {

        public List<WishList> WishLists = new();
        public WishListState() { }


    }

    /// <summary>
    /// DTO or Business Entity? don't know
    /// </summary>
    public class WishList
    {
        public string Name { get; set; } = string.Empty;
        public string UserDisplayName { get; set; } = string.Empty;

    }



}
