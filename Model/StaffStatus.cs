using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Model
{
    public enum StaffStatus
    {
        WAIT,
        ASSIGN_MENU,
        SEND_ORDERS_TO_KITCHEN,
        ASSIGN_CLIENT_TO_TABLE,
        TAKE_ORDERS,
        SERVE_MEAL,
        CLEAN_TABLE,
        SERVE_BREAD,
        SERVE_WATER
    }
}