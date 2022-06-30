namespace Atacado.Business.RH
{
    /// <summary>
    /// Regras genéricas para uso em qualquer unidade de regra.
    /// </summary>
    public static class RegraGenericas
    {/// <summary>
    /// Validar se campo NOME está vazio.
    /// </summary>
    /// <param name="nome">Campo que será validado</param>
    /// <param name="mensagem">Mensagem que sera exibida em caso de erro.</param>
    /// <returns>Retorna true se for bem sucedido. Do contrário, retorna false. </returns>
        public static bool NomeRegra(string nome, ref string mensagem)
        {
            if (string.IsNullOrEmpty(nome) == true)
            {
               mensagem = "Nome não pode ser vazio.";
                return false;
            }
            return true;
        }
        /// <summary>
        /// Validar se campo SOBRENOME está vazio.
        /// </summary>
        /// <param name="sobrenome">Campo que será validado</param>
        /// <param name="mensagem">Mensagem que sera exibida em caso de erro.</param>
        /// <returns>Retorna true se for bem sucedido. Do contrário, retorna false.</returns>
        public static bool SobrenomeRegra(string sobrenome, ref string mensagem)
        {
            if (string.IsNullOrEmpty(sobrenome) == true)
            {
                mensagem = "Sobrenome não pode ser vazio.";
                return false;
            }
            return true;
        }
        /// <summary>
        /// Validar se campo SEXO está vazio.
        /// </summary>
        /// <param name="sexo">Campo que será validado</param>
        /// <param name="mensagem">Mensagem que sera exibida em caso de erro.</param>
        /// <returns>Retorna true se for bem sucedido. Do contrário, retorna false.</returns>
        public static bool SexoRegra(string sexo, ref string mensagem)
        {
            if (string.IsNullOrEmpty(sexo) == true)
            {
                mensagem = "Sexo não pode ser vazio.";
                return false;
            }
            else if ((sexo.Contains("F") == false) && (sexo.Contains("M") == false))
            {
                mensagem = "Sexo deve conter a letra F ou M.";
                return false;
            }
            else
                return true;
        }
        /// <summary>
        /// Validar se campo EMAIL está vazio.
        /// - Regra para campo email vazio.
        /// - Regra de formato do email
        /// </summary>
        /// <param name="email">Campo que será validado </param>
        /// <param name="mensagem">Mensagem que sera exibida em caso de erro.</param>
        /// <returns>Retorna true se for bem sucedido. Do contrário, retorna false.</returns>
        public static bool EmailRegra (string email, ref string mensagem)
        {
            if (EmailVazioRegra(email, ref mensagem) == false)
            {
                return false;
            }
            else if (EmailFormatoRegra(email, ref mensagem) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        private static bool EmailVazioRegra(string email, ref string mensagem)
        {
            if (string.IsNullOrEmpty(email) == true)
                {
                    mensagem = "Email não pode ser vazio.";
                    return false;
                }
            return true;

        }
        
        private static bool EmailFormatoRegra(string email, ref string mensagem)
        {
            bool validEmail = false;
            int indexArr = email.IndexOf("@");

            if (indexArr > 0)
            {
                int indexDot = email.IndexOf(".", indexArr);
                if (indexDot - 1 > indexArr)
                {
                    if (indexDot + 1 < email.Length)
                    {
                        string indexDot2 = email.Substring(indexDot + 1, 1);
                        if (indexDot2 != ".")
                        {
                            validEmail = true;
                        }
                    }
                }
            }
            if (validEmail == false)
            {
                mensagem = "Email em formato ínvalido. ";
            }
            return validEmail;
        }
    }
}
