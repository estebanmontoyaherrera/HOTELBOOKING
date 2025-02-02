namespace HOTELBOOKING.Utilities.Constants
{
    public class SP
    {
        #region SP ROLES
        public const string SP_ROLE_LIST = "SP_ROLE_LIST";
        public const string SP_ROLE_BY_ID = "SP_ROLE_BY_ID";      
        #endregion

        #region SP USERS
        public const string SP_USER_LIST = "SP_USER_LIST";        
        public const string SP_USER_CREATE = "SP_USER_CREATE";
        public const string SP_USER_UPDATE = "SP_USER_UPDATE";
        public const string SP_USER_CHANGE_STATE = "SP_USER_CHANGE_STATE";
        public const string SP_USER_DELETE = "SP_USER_DELETE";
        public const string SP_USER_BY_EMAIL = "SP_USER_BY_EMAIL";
        #endregion

        #region SP CITIES
        public const string SP_CITY_LIST = "SP_CITY_LIST";        
        #endregion

        #region SP HOTELS
        public const string SP_HOTEL_LIST = "SP_HOTEL_LIST";        
        public const string SP_HOTEL_CREATE = "SP_HOTEL_CREATE";
        public const string SP_HOTEL_UPDATE = "SP_HOTEL_UPDATE";
        public const string SP_HOTEL_CHANGE_STATE = "SP_HOTEL_CHANGE_STATE";
        public const string SP_HOTEL_RESERVATIONS = "SP_HOTEL_RESERVATIONS";
        public const string SP_HOTEL_DELETE = "SP_HOTEL_DELETE";
        #endregion

        #region SP ROOMTYPES
        public const string SP_ROOMTYPE_LIST = "SP_ROOMTYPE_LIST";       
        #endregion

        #region SP ROOMS
        public const string SP_ROOM_LIST = "SP_ROOM_LIST";
        public const string SP_ROOM_LIST_BY_HOTELID = "SP_ROOM_LIST_BY_HOTELID";
        public const string SP_ROOM_CREATE = "SP_ROOM_CREATE";
        public const string SP_ROOM_UPDATE = "SP_ROOM_UPDATE";
        public const string SP_ROOM_CHANGE_STATE = "SP_ROOM_CHANGE_STATE";
        public const string SP_ROOM_DELETE = "SP_ROOM_DELETE";
        #endregion

        #region SP DOCUMENTTYPES
        public const string SP_DOCUMENTTYPE_LIST = "SP_DOCUMENTTYPE_LIST";
        public const string SP_DOCUMENTTYPE_BY_ID = "SP_DOCUMENTTYPE_BY_ID";
        public const string SP_DOCUMENTTYPE_CREATE = "SP_DOCUMENTTYPE_CREATE";
        public const string SP_DOCUMENTTYPE_UPDATE = "SP_DOCUMENTTYPE_UPDATE";
        public const string SP_DOCUMENTTYPE_DELETE = "SP_DOCUMENTTYPE_DELETE";
        #endregion

        #region SP GENDERS
        public const string SP_GENDER_LIST = "SP_GENDER_LIST";
        public const string SP_GENDER_BY_ID = "SP_GENDER_BY_ID";
        public const string SP_GENDER_CREATE = "SP_GENDER_CREATE";
        public const string SP_GENDER_UPDATE = "SP_GENDER_UPDATE";
        public const string SP_GENDER_DELETE = "SP_GENDER_DELETE";
        #endregion

        #region SP RESERVATIONS
        public const string SP_RESERVATION_LIST = "SP_RESERVATION_LIST";
        public const string SP_RESERVATION_BY_ID = "SP_RESERVATION_BY_ID";
        public const string SP_RESERVATION_CREATE = "SP_RESERVATION_CREATE";
        public const string SP_RESERVATION_CANCEL = "SP_RESERVATION_CANCEL";
        public const string SP_RESERVATION_UPDATE = "SP_RESERVATION_UPDATE";
        public const string SP_RESERVATION_DELETE = "SP_RESERVATION_DELETE";
        #endregion

        #region SP GUESTS
        public const string SP_GUEST_LIST = "SP_GUEST_LIST";
        public const string SP_GUEST_BY_ID = "SP_GUEST_BY_ID";
        public const string SP_GUEST_CREATE = "SP_GUEST_CREATE";
        public const string SP_GUEST_UPDATE = "SP_GUEST_UPDATE";
        public const string SP_GUEST_DELETE = "SP_GUEST_DELETE";
        #endregion
    }
}