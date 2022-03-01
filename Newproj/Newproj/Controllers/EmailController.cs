using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newproj.Controllers
{
    public class EmailController : Controller
    {

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Email(IFormCollection form)
        {
            return await Task.Run(() =>
            {
                var email = form["email"];
                var message = form["name"] + " <br/>" + form["email"] + " <br/>" + form["message"];
                var isHtml = !string.IsNullOrEmpty(form["isHtml"]);
                var result = Newproj.Models.Email.Send("Email from Website", message, email, isHtml, null);
                if (string.IsNullOrEmpty(result))
                    result = "Your message was sucessfully sent.";
                return View(model: result);
            });

        }

        //public async Task<IActionResult> Email(string Status,string email)
        //{
        //    return await Task.Run(() =>
        //    {
        //        ////var email = form["email"];
        //        var message = Status;
        //        var isHtml = true;
        //        var result = Newproj.Models.Email.Send("Email from Website", message, email, isHtml, null);
        //        if (string.IsNullOrEmpty(result))
        //            result = "Your message was sucessfully sent.";

        //        return View("Home","Welcome",model:result);
        //    });

        //}
    }
}
