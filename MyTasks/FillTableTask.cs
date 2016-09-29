﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace MyTasks
{
    public class FillTableTask : Task
    {
        public string ConnectionString { get; set; }
        public ITaskItem FillTableScript { get; set; }

        public override bool Execute()
        {
            string sql = SqlExecutor.ReadFile(FillTableScript.ItemSpec);
            bool result = SqlExecutor.ExecuteSql(sql, ConnectionString);
            if (!(result || BuildEngine.ContinueOnError))
            {
                result = false;
            }
            return result;
        }
    }
}