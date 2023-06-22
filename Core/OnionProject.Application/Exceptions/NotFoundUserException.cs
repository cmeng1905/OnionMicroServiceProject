﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Exceptions
{
    public class NotFoundUserException : Exception
    {
        public NotFoundUserException():base("Kullanıcı bulunamadı!")
        {
        }

        public NotFoundUserException(string? message) : base(message)
        {
        }
    }
}
