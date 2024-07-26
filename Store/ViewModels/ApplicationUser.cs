namespace WebStore.ViewModels
{
    public class ApplicationUser  :IdentityUser
    {
        public string ?FirstName {  get; set; }
        public string ?LastName { get; set; }
        public string ?Role {  get; set; }
 
        public string ?City {  get; set; }
        public int ?CompanyId { get; set; }

    }
}
