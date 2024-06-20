namespace BotafeMVC.Common
{
    public static class ServiceConstants
    {
        public static class Roles
        {
            public const string Admin = "Admin";
            public const string SuperUser = "SuperUser";
            public const string User = "User";
        }
        public static class Policies
        {
            public const string CanAddEvent = "CanAddEvent";
            public const string CanViewEvents = "CanViewEvents";
            public const string CanEditEvent = "CanEditEvent";
            public const string CanDeleteEvent = "CanDeleteEvent";
        }
        public static class Claims
        {
            public const string ViewEvents = "ViewEvents";
            public const string AddNewEvent = "AddNewEvent";
            public const string EditEvent = "EditEvent";
            public const string DeleteEvent = "DeleteEvent";
            public const string EnrollToEvent = "EnrollToEvent";
        }
    }
}
