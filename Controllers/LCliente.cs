using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AppBanca.Data;
using AppBanca.Models;
using AppBanca.ViewModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppBanca.Controllers
{
    public class LCliente : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<LCliente> _logger;

        public LCliente(ILogger<LCliente> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var misClientes = _context.DataClientes.ToList();

            _logger.LogDebug("Clientes: {misClientes}", misClientes);

            var viewModel = new RClienteViewModel
            {
                ListCliente = misClientes
            };

            _logger.LogDebug("ViewModel: {viewModel}", viewModel);

            return View(viewModel);
        }
    }
}