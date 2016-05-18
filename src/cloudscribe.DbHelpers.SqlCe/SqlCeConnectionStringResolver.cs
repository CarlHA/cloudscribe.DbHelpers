﻿// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:					Joe Audette
// Created:					2014-06-22
// Last Modified:			2016-05-18
// 

using Microsoft.Extensions.Options;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace cloudscribe.DbHelpers.SqlCe
{
    public class SqlCeConnectionStringResolver
    {
        public SqlCeConnectionStringResolver(
            IHostingEnvironment appEnv,
            IOptions<SqlCeConnectionOptions> configuration)
        {
            if (configuration == null) { throw new ArgumentNullException(nameof(configuration)); }
            if (appEnv == null) { throw new ArgumentNullException(nameof(appEnv)); }

            appBasePath = appEnv.ContentRootPath;
            options = configuration.Value;

        }

        private SqlCeConnectionOptions options;
        private string appBasePath;
        private string pathToDbFile()
        {
            return appBasePath + options.PathSegment.Replace("/", Path.DirectorySeparatorChar.ToString()) + options.DbFileName;
        }

        public string SqlCeFilePath
        {
            get {
                if(options.ConnectionString.Length > 0) { return string.Empty; }
                return pathToDbFile(); 
            }
        }

        public string Resolve()
        {

            if (options.ConnectionString.Length > 0) { return options.ConnectionString; }

            string connectionString = "Data Source=" + pathToDbFile() + ";Persist Security Info=False;";
            return connectionString;

            
        }
    }
}
