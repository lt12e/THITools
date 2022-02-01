namespace THITools_BlazorServ.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string User { get; set; }
        public bool Inactive { get; set; }
        public string PBIUsername { get; set; }
        public string GPUsername { get; set; }
        public string CreatedDate { get; set; }

    }
}
