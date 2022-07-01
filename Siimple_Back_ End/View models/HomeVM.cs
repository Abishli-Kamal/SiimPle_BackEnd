using Siimple_Back__End.DAL;
using Siimple_Back__End.Models;
using System.Collections.Generic;

namespace Siimple_Back__End.View_models
{
    public class HomeVM
    {


        public About Abouts { get; set; }
        public List<Servis> Services { get; set; } 
    }
}
