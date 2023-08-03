using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Biludlejningsfirma.Models;
using Biludlejningsfirma.Database;
using System.Reflection;

namespace Biludlejningsfirma.Pages
{
    public class BestillingModel : PageModel
    {
        public List<Biltype> biltyperliste = new List<Biltype>();
        public List<Extra> extraliste = new List<Extra>();
        Database.Db db = new Db();
        public void OnGet()
        {

            biltyperliste = db.GetAllBiltype();
            extraliste = db.GetAllExtra();
        }
        public void OnPostSubmit()
        {
            //Biltype
            string BiltypeSelect = Request.Form["BiltypeSelect"].ToString();
            List<string> Biltypelist = BiltypeSelect.Split(",").ToList();
            Biltype biltype = new Biltype();
            biltype.Id = Convert.ToInt32(Biltypelist[0]);
            biltype.carSize = Biltypelist[1];
            biltype.price = Convert.ToInt32(Biltypelist[2]);

            //Datetime
            DateTime StartDate = Convert.ToDateTime(Request.Form["StartDate"].ToString());
            DateTime EndDate = Convert.ToDateTime(Request.Form["EndDate"].ToString());

            //Extra
            string ExtraSelect = Request.Form["ExtraSelect"].ToString();
            List<string> Extralist = ExtraSelect.Split(",").ToList();
            Extra extra = new Extra();
            extra.Id = Convert.ToInt32(Extralist[0]);
            extra.addons = Extralist[1];
            extra.price = Convert.ToInt32(Extralist[2]);

            //Bruger
            string TextFieldUserName = Request.Form["TextFieldUserName"].ToString();
            string TextFieldUserPassword = Request.Form["TextFieldUserPassword"].ToString();
            string TextFieldEmail = Request.Form["TextFieldEmail"].ToString();
            string TextFieldCity = Request.Form["TextFieldCity"].ToString();
            string TextFieldPhoneNumber = Request.Form["TextFieldPhoneNumber"].ToString();


            //tjek om bruger existerer hvis ja brug den
            Bruger bruger = new Bruger();
            bruger.Id = 1;
            bruger.userName = TextFieldUserName;
            bruger.userPassword = TextFieldUserPassword;
            bruger.email = TextFieldEmail;
            bruger.city = TextFieldCity;
            bruger.phoneNumber = Convert.ToInt32(TextFieldPhoneNumber);

            List<Bruger> brugers = db.GetAllBruger();

            bool iftrue = false;
            int countid = 1;
            foreach (Bruger item in brugers)
            {
                if (item.userName == bruger.userName)
                {
                    iftrue = true;
                    countid++;
                }
            }
            if (!iftrue)
            {
                db.CreateBruger(bruger.userName, bruger.userPassword, bruger.email, bruger.city, bruger.phoneNumber);
            }
            List<Bruger> brugersafter = db.GetAllBruger();
            //biltyperId,BrugerId,StartDate,EndDate,ExtraId
            if (bruger.userName == brugersafter.Last().userName)
            {
                db.CreateUdlejning(biltype, brugersafter.Last(), StartDate, EndDate, extra);
            }

        }
    }

}
