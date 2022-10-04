using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/folha")]
    public class FolhaPagamentoController : ControllerBase
    {
        private readonly DataContext _context;
        public FolhaPagamentoController(DataContext context) =>
            _context = context;

        // GET: /api/folhapagamento/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar() => Ok(_context.Folhas.ToList());

        // POST: /api/folhapagamento/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] FolhaPagamento folhaPagamento)
        {
            folhaPagamento.Funcionario = _context.Funcionarios.Find(folhaPagamento.FuncionarioId);
            _context.Folhas.Add(folhaPagamento);
            _context.SaveChanges();
            return Created("", folhaPagamento);
        }

        // GET: /api/folhapagamento/buscar/{cpf}
        [HttpGet]
        [Route("buscar/{cpf}/{mes}/{ano}")]
        public IActionResult BuscarCpf([FromRoute] string cpf, string mes, string ano)
        {
            FolhaPagamento folhaPagamento = _context.Folhas.FirstOrDefault(f => f.Mes.Equals(mes) && f.Ano.Equals(ano));
            folhaPagamento.Funcionario = _context.Funcionarios.Find(folhaPagamento.FuncionarioId);
            Funcionario funcionario = _context.Funcionarios.
                FirstOrDefault(f => f.Cpf.Equals(cpf));
            return folhaPagamento != null ? Ok(folhaPagamento) : NotFound();
        }

        




    }
}