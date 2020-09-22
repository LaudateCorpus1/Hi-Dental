using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Enums.Appointment
{
    public enum AppointmentState
    {
        NotConfirmed,
        ConfirmedByPhone,
        Waiting,
        Attending,
        Attended,
        NotAssist,
        Canceled
    }
}
