using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManager.BusinessLayer.AppointmentModels
{
    public interface IAppointmentService
    {
        List<AppointmentModel> GetAppointments();
        void SaveAppointment(AppointmentModel appointment);
        void SaveAppointments(List<AppointmentModel> appointmentsList);
    }
}
