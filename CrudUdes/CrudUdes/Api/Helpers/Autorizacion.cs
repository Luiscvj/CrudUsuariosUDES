namespace CrudUdes.Api.Helpers
{
    public class Autorizacion
    {
        public enum Roles
        {
            Admin,
            Manager,
            Employee
        }
        public const Roles rol_predeterminado = Roles.Employee;
    }
}
