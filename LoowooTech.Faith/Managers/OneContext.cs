using System.Web;

namespace LoowooTech.Faith.Managers
{
    public static class OneContext
    {
        private static string _contextName { get; set; }
        public static FaithDbContext Current
        {
            get { return HttpContext.Current.Items[_contextName] as FaithDbContext; }
        }
        static OneContext()
        {
            _contextName = "_entityContext";
        }

        public static void Begin()
        {
            HttpContext.Current.Items[_contextName] = new FaithDbContext();
        }

        public static void End()
        {
            var entity = HttpContext.Current.Items[_contextName] as FaithDbContext;
            if (entity != null)
            {
                entity.Dispose();
            }
        }
    }
}