﻿namespace InterceptorExample.web
{
    public class AppSettings
    {
        public SqlServerDbConnection SqlServerDbConnection { get; set; }
    }

    public class SqlServerDbConnection
    {
        public string ShortenLinkConnection { get; set; }
    }
}
