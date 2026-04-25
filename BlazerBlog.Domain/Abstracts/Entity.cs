using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBlog.Domain.Abstracts
{
    public abstract class Entity
    {

        public DateTime CreateAt { get; set; } = DateTime.Now;

        public DateTime? UpdateAt { get; set; }
    }
}
