using System;
using System.Web;
using System.Web.Mvc;

public class HomeController : Controller
{
    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(string username, string password)
    {
        // Simulate server-side validation (in a real scenario, validate against a database)
        if (username == "user" && password == "pass")
        {
            // Create a session token with a unique identifier (you may want to use a more secure method)
            var sessionToken = Guid.NewGuid().ToString();

            // Set the session token in a secure HttpOnly cookie
            var cookie = new HttpCookie("sessionToken", sessionToken)
            {
                HttpOnly = true,
                // You may want to set additional properties like Expires and Secure based on your security requirements
            };

            // If you are using a newer version of .NET, you can set SameSite property here
            // cookie.SameSite = SameSiteMode.None;

            Response.Cookies.Add(cookie);

            // Store the session token in the server's session state
            Session["sessionToken"] = sessionToken;

            return Content("User logged in");
        }
        else
        {
            return Content("Invalid credentials");
        }
    }

    public ActionResult CheckLogin()
    {
        // Check if the user is authenticated by validating the session token
        var cookieToken = Request.Cookies["sessionToken"]?.Value;
        var sessionToken = Session["sessionToken"] as string;

        if (!string.IsNullOrEmpty(cookieToken) && cookieToken == sessionToken)
        {
            return Content("User logged in");
        }
        else
        {
            return Content("User not logged in");
        }
    }
}
