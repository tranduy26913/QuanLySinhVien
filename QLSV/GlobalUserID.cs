﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    class GlobalUserID
    {
        public static int GlobalUserId { get; private set; }
        public static void SetGlobalUserId(int userID)
        {
            GlobalUserId = userID;
        }
    }
}
