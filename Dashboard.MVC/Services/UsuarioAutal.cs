using Microsoft.AspNetCore.Http;
using System;

namespace Dashboard.MVC.Services
{
    public class UsuarioAutal
    {
        public static int GetId(HttpContext context)
        {
            return Convert.ToInt32(context.Session.GetInt32("UsuarioId"));
        }

        public static int? GetClienteId(HttpContext context)
        {
            return context.Session.GetInt32("ClienteId");
        }

        public static int? GetFuncionarioId(HttpContext context)
        {
            return context.Session.GetInt32("FuncionarioId");
        }
    }
}
