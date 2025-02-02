namespace HOTELBOOKING.Infrastructure.Authentication
{
    public enum Permission
    {
        // Permisos para Usuarios
        ListUsers = 1,
        CreateUsers = 2,
        UpdateUser = 3,
        ChangeStateUser = 4,
        DeleteUser = 5,

        // Permisos para Hoteles
        ListHotels = 6,
        CreateHotel = 7,
        UpdateHotel = 8,
        ChangeStateHotel = 9,
        DeleteHotel = 10,

        // Permisos para Ciudades
        ListCities = 11,

        // Permisos para Roles
        ListRoles = 12,
        GetRoleById = 13,

        // Permisos para Salas (Rooms)
        ListRooms = 14,
        CreateRoom = 15,
        UpdateRoom = 16,
        ChangeStateRoom = 17,
        DeleteRoom = 18,

        // Permisos para Tipos de Sala (RoomType)
        ListRoomTypes = 19
    }
}
