using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Senai.LanHouse.Web.Razor.Contextos;
using Senai.LanHouse.Web.Razor.Dominios;

namespace Senai.LanHouse.Web.Razor.Controllers
{
    public class LoginController : Controller
    {
        private readonly LanHouseContext _context;

        public LoginController(LanHouseContext context)
        {
            _context = context;
        }

        // GET: Login/Create
        public IActionResult Create()
        {
            HttpContext.Session.Clear();
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Senha")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                Usuarios retorno = _context.Usuarios
                                    .FirstOrDefault(x => x.Email == usuarios.Email);

                if(retorno == null)
                {
                    ViewBag.Mensagem = "Email ou senha inválidos, tente novamente";
                    return View(usuarios);
                }

                HttpContext.Session.SetString("email", usuarios.Email);
                return RedirectToAction("Index", "RegistrosDefeitos");
            }
            return View(usuarios);
        }
    }
}
