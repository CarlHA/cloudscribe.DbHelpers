﻿// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:					Joe Audette
// Created:					2015-08-07
// Last Modified:			2016-01-04
// 



namespace cloudscribe.DbHelpers.SqlCe
{
    public class SqlCeConnectionOptions
    {
        public string DbFileName { get; set; } = "cloudscribe.sdf";

        public string ConnectionString { get; set; } = string.Empty;

        public string PathSegment { get; set; } = "/cloudscribe_config/sqlcedb/";
    }
}
