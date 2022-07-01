using System.ComponentModel.DataAnnotations;

namespace Siimple_Back__End.View_models
{
    public class LoginVm
    {
        [Required,StringLength(maximumLength:20)]
        public string UserName  { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
