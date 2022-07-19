namespace WebUI.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet]
    public IActionResult Index()
    {
      return View();
    }
  }
}