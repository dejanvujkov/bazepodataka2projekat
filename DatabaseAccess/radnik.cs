//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class radnik
    {
        public int autobuska_stanica_idstanice { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string jmbg { get; set; }
    
        public virtual autobuska_stanica autobuska_stanica { get; set; }
        public virtual mehanicar mehanicar { get; set; }
        public virtual prodavac prodavac { get; set; }
        public virtual vozac vozac { get; set; }
    }
}
