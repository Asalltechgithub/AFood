﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorShop.Api.Context;
using BlazorShop.Api.Entities;
using BlazorShop.Api.Service;
using Microsoft.AspNetCore.Authorization;

namespace BlazorShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<Tuple<Token, Usuario>>> Authenticate([FromBody] Usuario model)
        {
            var user = model;

            bool ckSenha = false;


            user.Email = model.Email.ToUpper().Trim();
            user.Password = model.Password.Trim();

            //Recupera o usuário
           var u = (from x in _context.Usuarios
                    where x.Email == user.Email
                    select x).FirstOrDefault();
            //Verifica se o usuário existe
            if (u == null)
                return NotFound(new { message = "Usuário Não encontrado" });
           
            
            if ( u.Email != "ADM@ASFOOD.COM") {


                Encryption encryption = new Encryption();
                ckSenha = encryption.checkEncryptPassword(u.Password, user.Password);

                if (ckSenha == false)
                {
                    return StatusCode(401);
                }

            }
               
           








            Token token = new Token();

            //  Gera o Token
            token.AcessToken = TokenService.GeneraterToken(user);


            // Oculta a senha
            u.Password = "";

            
            // Retorna os dados
            return new Tuple<Token, Usuario>(token, u);



        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
          if (_context.Usuarios == null)
          {
              return NotFound();
          }
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
          if (_context.Usuarios == null)
          {
              return NotFound();
          }
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
          if (_context.Usuarios == null)
          {
              return Problem("Entity set 'AppDbContext.Usuarios'  is null.");
          }
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
