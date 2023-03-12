using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSPlus.Domain.Entities
{
    public class CommentEntity:BaseEntity
    {
        public string FullName { get; set; }
        public string Comment { get; set; }
        public int TopicId { get; set; }
    }
}
