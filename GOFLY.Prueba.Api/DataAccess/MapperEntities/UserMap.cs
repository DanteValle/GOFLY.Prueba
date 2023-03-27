using GOFLY.Prueba.Api.Model.Entities;

namespace GOFLY.Prueba.Api.DataAccess.MapperEntities
{
    public class UserMap
    {
        public static User Map(dynamic result)
        {
            if (result == null) return null;
            return new User
            {
                IdUser = result.id_user,
                LastName = result.last_name,
                Email = result.email,
                DateOfBirth = result.date_of_birth,
                PhoneNumber = result.phone_number,
                CountryOfResidence = result.country_of_residence,
                PermissionInformation = result.permission_information,
                Name = result.name
            };
        }
    }
}
