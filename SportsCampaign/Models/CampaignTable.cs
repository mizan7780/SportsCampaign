//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SportsCampaign.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CampaignTable
    {
        public CampaignTable()
        {
            this.CampaignBookedInfoes = new HashSet<CampaignBookedInfo>();
        }
    
        public int id { get; set; }
        public string campaignName { get; set; }
        public string campaignDescription { get; set; }
        public string catagoryName { get; set; }
        public string Duration { get; set; }
        public string instructorName { get; set; }
    
        public virtual ICollection<CampaignBookedInfo> CampaignBookedInfoes { get; set; }
    }
}
