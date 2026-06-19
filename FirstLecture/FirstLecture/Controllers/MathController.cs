using Microsoft.AspNetCore.Mvc;

namespace FirstLecture.Controllers;

public class MathController : Controller
{
    public int Sum(int x, int y)
    {
        return (x + y);
    }
}