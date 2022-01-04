using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAgenda.Data;
using APIAgenda.Models;
using APIProdutos.Data;
using APIProdutos.Models;

namespace APIAgenda.Business
{
    public class UsuarioService
    {
        private ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Usuario Obter(string id)
        {
            return _context.Usuarios.Where(
                u => u.ID == id).FirstOrDefault();
        }

        public void Incluir(Usuario dadosUsuario)
        {
            _context.Usuarios.Add(dadosUsuario);
            _context.SaveChanges();
        }
    }
}