using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.Entities
{
    
    public class ExamFile : FileModel
    {
        public byte[] DataFiles { get; set; }
        
    }
}
