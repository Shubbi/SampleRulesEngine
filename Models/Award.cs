using System.Collections.Generic;

namespace DemoArps_Models
{
    public class Award
    {
        public string AwardType { get; set; }
        public decimal CashAmount { get; set; }
        public string CurrentUserRole { get; set; }
        public List<string> TargetAudienceRolesList { get; set; }
        public string CurrentUserSso { get; set; }
        public List<string> TargetSsoList { get; set; }
        public bool IsEmailNeeded { get; set; }
        public List<string> EmailAddressList { get; set; }
    }
}