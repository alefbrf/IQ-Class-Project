namespace IQ_Class.Data.Enums
{
    public class EnumarationRole
    {
        public int id {  get; private set; }
        public string name {  get; private set; }

        public enum Roles 
        {
            ADMIN = 1,
            MANAGER = 2,
            TEACHER = 3,
            STUDENT = 4
        }

        public static List<EnumarationRole> ConvertEnumRoleList<Roles>() where Roles : struct, IConvertible
        {
            var result = Enum.GetValues(typeof(Roles))
                .Cast<Roles>()
                .Select(t => new EnumarationRole
                {
                    id = Convert.ToInt32(t),
                    name = t.ToString()
                })
                .ToList();

            return result;
        }

        public static List<EnumarationRole> ListRole()
        {
            return ConvertEnumRoleList<Roles>();
        }
    }
}
