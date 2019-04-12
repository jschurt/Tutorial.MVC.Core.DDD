using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.ValueObjects
{
    public class VOEmail
    {
        public string EnderecoEmail { get; set; }

        public bool Validar(string email)
        {

            if(!string.IsNullOrEmpty(email))
            {
                return ValidarEmail(email);
            } //if

            return true;

        } //Validar

        private bool ValidarEmail(string email)
        {

            bool validEmail = false;
            int indexAt = email.IndexOf('@');
            if(indexAt > 0)
            {
                int indexDot = email.IndexOf('.', indexAt);
                if(indexDot-1 > indexAt)
                {
                    if(indexDot + 1 < email.Length)
                    {
                        string indexDot2 = email.Substring(indexDot + 1, 1);
                        if (indexDot2 != ".")
                            validEmail = true;
                    }
                }
            }

            return validEmail;

        } //ValidarEmail

    } //class
} //namespace
