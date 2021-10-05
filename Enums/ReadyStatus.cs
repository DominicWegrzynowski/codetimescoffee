using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Enums
{
    public enum ReadyStatus
    {
        
        Incomplete,
        [Display(Name = "Production Ready")]
        ProductionReady,
        Preview
    }
}