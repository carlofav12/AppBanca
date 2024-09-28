using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AppBanca.Data;
using AppBanca.Models;
using AppBanca.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppBanca.Controllers
{
    public class RClienteController : Controller
    {
        private readonly ILogger<RClienteController> _logger;
        private readonly ApplicationDbContext _context;

        public RClienteController(ILogger<RClienteController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(RClienteViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Cliente cliente = new Cliente
                {
                    Nombre = viewModel.FormCliente.Nombre,
                    TCuenta = viewModel.FormCliente.TCuenta,
                    SaldoI = viewModel.FormCliente.SaldoI,
                    Email = viewModel.FormCliente.Email
                };

                _context.Add(cliente);
                _context.SaveChanges();

                ViewData["Message"] = "Cliente registrado con éxito!";

                return View("Index", viewModel);
            }
            return View("Index", viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}