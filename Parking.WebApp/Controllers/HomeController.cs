using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Parking.Core.DTO;
using Parking.WebApp.Models;
using Parking.Core.Validators;
using Autofac;
using Parking.DI;
using Parking.Application.Application;
using System.Collections.Generic;


namespace Parking.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new InputViewModel());
        }


        [HttpPost]
        public IActionResult Index([FromForm] InputViewModel viewModel)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<MainModule>();
            IContainer container = builder.Build();
            
            var appService = container.Resolve<IApplicationService>();

            var timer = new TimerDto();
            var valid = new Validation();

            if (viewModel.CarEntryInput.HasValue && viewModel.CarExitInput.HasValue)
            {
                timer.Entry = viewModel.CarEntryInput.Value;
                timer.Exit = viewModel.CarExitInput.Value;
            }
            else
            {
                if (!viewModel.CarEntryInput.HasValue)
                    viewModel.Errors = "Car Entry Input is a required field";
                if (!viewModel.CarExitInput.HasValue)
                    viewModel.Errors = "Car Exit Input is a required field";
                return View(viewModel);
            }

            

            valid = appService.ValidateInput(timer);
            if (!valid.IsValid)
            {
                viewModel.Errors = valid.ErrorMessage;
                // System.Console.WriteLine(valid.ErrorMessage);
                return View(viewModel);
            }
            try
            {
                var response = appService.ProcessAsync(timer).Result;
                viewModel.Results = response;
            }
            catch (Exception ex)
            {
                viewModel.Errors = ex.Message + "\n";
            }
            if (!ModelState.IsValid)
            {
                viewModel.Errors = "Some errors were detected in your submission. Please correct any field errors and re-submit.";
                return View(viewModel);
            }
            return View(viewModel);
        }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
