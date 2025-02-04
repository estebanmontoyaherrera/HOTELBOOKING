namespace HOTELBOOKING.Infrastructure.Authentication
{
    public enum Permission
    {
        // Permisos para Ciudades
        ListCities = 1,

        // Permisos para Tipos de Documento
        ListDocumentTypes = 2,

        // Permisos para Géneros
        ListGenders = 3,

        // Permisos para Hoteles
        ListHotels = 4,
        GetHotelById = 5,
        CreateHotelRooms = 6,
        CreateHotel = 7,
        AssignRoom = 8,
        UpdateHotel = 9,
        ChangeStateHotel = 10,
        DeleteHotel = 11,

        // Permisos para Reservas
        ListReservations = 12,
        CreateReservation = 13,

        // Permisos para Roles
        ListRoles = 14,
        GetRoleById = 15,

        // Permisos para Habitaciones (Rooms)
        ListRooms = 16,
        CreateRoom = 17,
        UpdateRoom = 18,
        ChangeStateRoom = 19,
        DeleteRoom = 20,

        // Permisos para Tipos de Habitación (RoomType)
        ListRoomTypes = 21,

        // Permisos para Usuarios
        ListUsers = 22,
        CreateUsers = 23,
        UpdateUser = 24,
        ChangeStateUser = 25,
        DeleteUser = 26
    }

}
