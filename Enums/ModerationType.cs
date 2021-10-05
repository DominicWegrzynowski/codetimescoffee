using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Enums
{
    public enum ModerationType
    {
        [Description("Political Propoganda")]
        Political,

        [Description("Offensive Language")]
        Language,

        [Description("Drug References")]
        Drugs,

        [Description("Threatening Content")]
        Threatening,

        [Description("Sexual Content")]
        Sexual,

        [Description("Hatefull Content")]
        Hateful,

        [Description("Targeted Shaming")]
        Shaming
    }
}
