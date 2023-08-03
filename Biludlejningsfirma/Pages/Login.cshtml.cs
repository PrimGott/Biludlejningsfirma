using Biludlejningsfirma.Database;
using Biludlejningsfirma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Biludlejningsfirma.Pages
{
    public class LoginModel : PageModel
    {
        Database.Db db = new Db();
        List<AdminUser> users = new List<AdminUser>();
        public bool istrue;
        public void OnGet()
        {

        } 
        public void OnPostLoginSubmit()
        {
            //Login
            string Username = Request.Form["TextFieldUsername"].ToString();
            string Password = Request.Form["TextFieldPassword"].ToString();

            users = db.GetAllAdminUsers();

            istrue = false;
            foreach (AdminUser item in users)
            {
                if (Username == item.adminName)
                {
                    istrue = true;
                }
            }
           

        }
    }
}
