using System;
using System.Collections.Generic;

namespace Dashboard.Domain.Entities
{
    public class Telefone : absValidationBase, IEquatable<Telefone>
    {
        public int TelefoneId { get; set; }

        public int DDD { get; set; }
        public const int DDDMaxLength = 2;

        public int Numero { get; set; }
        public const int NumeroMaxLength = 9;

        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int? FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

        public void Valid(Dictionary<string, string> telefoneDictionary)
        {
            isValid = true;

            if (String.IsNullOrEmpty(telefoneDictionary["DDD"]))
            {
                isValid = false;
                message = "DDD é obrigatório.";
            }
            if (!IsNumeric(telefoneDictionary["DDD"]))
            {
                isValid = false;
                message = "DDD só pode conter números.";
            }
            if (telefoneDictionary["DDD"].Length > DDDMaxLength)
            {
                isValid = false;
                message = "DDD pode conter no máximo " + DDDMaxLength + " caracteres.";
            }
            if (String.IsNullOrEmpty(telefoneDictionary["Numero"]))
            {
                isValid = false;
                message = "Número é obrigatório.";
            }
            if (!IsNumeric(telefoneDictionary["Numero"]))
            {
                isValid = false;
                message = "Número só pode conter números.";
            }
            if (telefoneDictionary["Numero"].Length > NumeroMaxLength)
            {
                isValid = false;
                message = "Número pode conter no máximo " + NumeroMaxLength + " caracteres.";
            }
        }

        public static Telefone Parse(Dictionary<string, string> telefoneDictionary)
        {
            Telefone telefone = new Telefone();

            if (!String.IsNullOrEmpty(telefoneDictionary["TelefoneId"]))
                telefone.TelefoneId = Convert.ToInt32(telefoneDictionary["TelefoneId"]);

            if (!String.IsNullOrEmpty(telefoneDictionary["DDD"]))
                telefone.DDD = Convert.ToInt32(telefoneDictionary["DDD"]);

            if (!String.IsNullOrEmpty(telefoneDictionary["Numero"]))
                telefone.Numero = Convert.ToInt32(telefoneDictionary["Numero"]);

            return telefone;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Telefone);
        }

        public bool Equals(Telefone other)
        {
            return other != null &&
                   TelefoneId == other.TelefoneId &&
                   DDD == other.DDD &&
                   Numero == other.Numero;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TelefoneId, DDD, Numero);
        }
    }
}
