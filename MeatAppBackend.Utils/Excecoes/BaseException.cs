using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace MeatAppBackend.Utils.Excecoes
{
    public class BaseException : Exception
    {
        #region Propriedades
        public HttpStatusCode HttpStatus { get; set; }
        public string Mensagem { get; set; }
        #endregion

        #region Construtores
        public BaseException(string mensagem, HttpStatusCode status)
        {
            this.Mensagem = mensagem;
            this.HttpStatus = status;
        }

        protected BaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        #endregion
    }
}
