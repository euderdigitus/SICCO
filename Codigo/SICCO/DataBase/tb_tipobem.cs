//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SICCO.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_tipobem
    {
        public tb_tipobem()
        {
            this.tb_bem = new HashSet<tb_bem>();
        }
    
        public int id { get; set; }
        public string tipoBem { get; set; }
    
        public virtual ICollection<tb_bem> tb_bem { get; set; }
    }
}
