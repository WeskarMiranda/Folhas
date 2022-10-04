using System;
using API.Models;
using System.Collections.Generic;

namespace API.Models
{
    public class FolhaPagamento
    {
        public int Id { get; set; }
        public double ValorHora { get; set; }
        public double QuantidadeHoras { get; set; }
        public string Cpf { get; set; }
        public string Mes { get; set; }
        public string Ano { get; set; }
        public double SalarioBruto { get; set; }
        public double ImpostoRenda { get; set; }
        public double ImpostoInss { get; set; }
        public double ImpostoFgts { get; set; }
        public double SalarioLiquido { get; set; }

        public virtual Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }
    }
}