﻿using IS_Proekt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EmailMessage : BaseEntity
    {
        public string? MailTo { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public bool Status { get; set; }
    }
}
