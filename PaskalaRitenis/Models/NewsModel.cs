﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaskalaRitenis.Models
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}