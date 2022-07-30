namespace Store.AdminWebUI.Common
{
    public class WebUtils
    {
        public static readonly string SUPER_ADMIN_ROLE_NAME;
        public static readonly string ADMIN_ROLE_NAME;

        static WebUtils()
        {
            SUPER_ADMIN_ROLE_NAME = "super admin";
            ADMIN_ROLE_NAME = "admin";
        }

    }
}
