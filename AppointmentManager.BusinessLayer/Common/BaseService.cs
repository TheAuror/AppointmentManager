using  AppointmentManager.DataLayer;

namespace AppointmentManager.BusinessLayer.Common
{
    public class BaseService
    {
        protected readonly ISampleContext Context;

        public BaseService(ISampleContext context)
        {
            Context = context;
        }
    }
}
