using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FilmesController : ControllerBase
    {
        [HttpGet, Authorize] // Authorize: Apenas será ezibido ser for autorizado
        public IEnumerable<Filme> Listar()
        {
            return new Filme[] {
                new Filme("Matrix", 1999,
                    new Diretor[]{
                        new Diretor("Irmão 1", "Wachowski"),
                        new Diretor("Irmão 2", "Wachowski")
                    }),
                new Filme("Lagoa Azul", 1980),
                new Filme("Os Incríveis 2", 2014)
            };
        }
    }

    public class Filme
    {
        public Filme(string titulo, int ano)
        {
            Titulo = titulo;
            Ano = ano;
            Diretores = new Diretor[] { };
        }
        public Filme(string titulo, int ano, Diretor[] diretores)
        {
            Titulo = titulo;
            Ano = ano;
            Diretores = diretores;
        }

        public string Titulo { get; private set; }
        public int Ano { get; private set; }
        public Diretor[] Diretores { get; private set; }
    }

    public class Diretor
    {
        public Diretor(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
    }
}