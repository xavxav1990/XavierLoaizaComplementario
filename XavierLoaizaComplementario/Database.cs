﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XavierLoaizaComplementario
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
