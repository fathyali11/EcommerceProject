namespace WebStore.ViewModels
{
    public class ApplicationUser  :IdentityUser
    {
        public string ?Role {  get; set; }
 
        public string ?City {  get; set; }

    }
}
