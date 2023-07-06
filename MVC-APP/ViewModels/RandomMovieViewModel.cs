using MVC_APP.Models;

namespace MVC_APP.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movies Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
