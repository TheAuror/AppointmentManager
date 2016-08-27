using  AppointmentManager.DataLayer;

namespace AppointmentManager.BusinessLayer.Common
{
    public class BaseService
    {
        protected readonly IContext Context;

        public BaseService(IContext context)
        {
            Context = context;
        }
    }
}
