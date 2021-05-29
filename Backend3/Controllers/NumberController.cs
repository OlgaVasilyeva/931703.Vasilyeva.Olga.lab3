using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend3.Service;
using Backend3.Models;

namespace Backend3.Controllers
{
    public class NumberController : Controller
    {
        private readonly IArithmetService arithmetService;
        private readonly IRandomService randomService;

        public NumberController(IArithmetService arithmetService, IRandomService randomService)
        {
            this.arithmetService = arithmetService;
            this.randomService = randomService;

        }

        public IActionResult QuizNumber()
        {
            generet();
            var model = new NumberVievModel();
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult QuizNumber(int otvet, int fir, int sec, String opt, NumberAction action, NumberVievModel model, String primer, NumberResultViewModel m, NumberBul num)
        {
            this.ViewBag.Otvet = otvet;
            this.ViewBag.Prover = model.Prov;
            var otvet1 = 0;
            switch (action)
            {
                case NumberAction.Submit:
                    primer = primer + otvet;
                    m.First = primer;
                    model.Actions.Add(m);
                    model.NumberCount++;
                    if (opt == "/") {
                        otvet1 = arithmetService.del(fir, sec);
                    }
                    if (opt == "+")
                    {
                        otvet1 = arithmetService.plus(fir, sec);
                    }
                    if (opt == "-")
                    {
                        otvet1 = arithmetService.minus(fir, sec);
                    }
                    if (opt == "*")
                    {
                        otvet1 = arithmetService.sum(fir, sec);
                    }
                    if (otvet == otvet1)
                    {
                        num.Bul = 1;
                        model.Prov.Add(num);
                        model.NumberCountRight++;
                        this.ModelState.Remove("NumberCountRight");
                    }
                    else {
                        num.Bul = 0;
                        model.Prov.Add(num);
                    }
                    generet();
                    this.ModelState.Remove("NumberCount");
                    return this.View(model);
                case NumberAction.Finish:
                    //var m = new NumberResultViewModel();
                    primer = primer + otvet;
                    m.First = primer;
                    model.Actions.Add(m);
                    model.NumberCount++;
                    if (opt == "/")
                    {
                        otvet1 = arithmetService.del(fir, sec);
                    }
                    if (opt == "+")
                    {
                        otvet1 = arithmetService.plus(fir, sec);
                    }
                    if (opt == "-")
                    {
                        otvet1 = arithmetService.minus(fir, sec);
                    }
                    if (opt == "*")
                    {
                        otvet1 = arithmetService.sum(fir, sec);
                    }
                    if (otvet == otvet1)
                    {
                        num.Bul = 1;
                        model.Prov.Add(num);
                        model.NumberCountRight++;
                        this.ModelState.Remove("NumberCountRight");
                    }
                    else
                    {
                        num.Bul = 0;
                        model.Prov.Add(num);
                    }
                    return this.View("QuizNumberResult", model);
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);

            }
        }

        void generet()
        {
            Random rand = new Random();
            string[] lable = { "+", "-", "*", "/" };
            var i = rand.Next(0, 4);
            this.ViewBag.Opt = lable[i];
            var first1 = this.randomService.Rand(0, 10);
            this.ViewBag.Name = first1;
            int second1;
            do
            {
                second1 = this.randomService.Rand(0, 10);
            } while (second1 == 0);
                this.ViewBag.Name1 = second1;

        }
    }
}
