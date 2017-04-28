using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlatPlanetExam.Domain;
using FlatPlanetExam.Domain.Entity;
using FlatPlanetExam.Models;

namespace FlatPlanetExam.Controllers
{
    public class CounterController : Controller
    {
        // GET: Counter
        public ActionResult Index()
        {
            var lastvalue = 0;
            using (var counter = new CounterDbEntities())
            {
                var recCount = counter.Counters.Count();
                if (recCount > 0)
                {
                    var lastOrDefault = counter.Counters.Select(c => c.Counter);
                    if (lastOrDefault != null) lastvalue = lastOrDefault.First();
                }
            }
            var countermodel = new CounterModel { Counter = lastvalue };

            return View(countermodel);
        }

        [HttpPost]
        public ActionResult _getCount(int count)
        {
            var isCLickable = false;
            var newValue = count + 1;

            using (var _counter = new CounterDbEntities())
            {
                var recCount = _counter.Counters.Count();
                if (recCount == 0)
                {
                    var counter = new CounterEntity {Counter = newValue };
                    _counter.Counters.Add(counter);
                    isCLickable = true;
                    
                }
                else
                {
                    var currentValue = _counter.Counters.First();


                    if (currentValue.Counter <= 9)
                    {
                        currentValue.Counter = newValue;
                        isCLickable = true;
                        
                    }

                       
                }

                _counter.SaveChanges();



            }
            return Json(new { clickable = isCLickable, Counter = newValue });
        }
    }
}