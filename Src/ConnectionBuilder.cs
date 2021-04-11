/*
 * This filePath is part of AceQL C# Client SDK.
 * AceQL C# Client SDK: Remote SQL access over HTTP with AceQL HTTP.                                 
 * Copyright (C) 2021,  KawanSoft SAS
 * (http://www.kawansoft.com). All rights reserved.                                
 *                                                                               
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this filePath except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License. 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AceQL.Client.Api;

namespace AceQL.Client.WinFormTest
{

    /// <summary>
    /// Class ConnectionBuilder. 
    /// Gets a connection on remote database.
    /// <para/>Class is portable without change to Xamarin for all targets (iOS, Android, etc.)
    /// </summary>
    public class ConnectionBuilder
    {
        private string server;
        private string username
            ;
        private char[] password;
        private string database;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionBuilder"/> class.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="database">The database.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public ConnectionBuilder(string server, String database, string username, char[] password)
        {
            this.server = server;
            this.username = username;
            this.database = database;
            this.password = password;
        }

        /// <summary>
        /// Get connection as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;AceQLConnection&gt;.</returns>
        public AceQLConnection GetConnection()
        {
            // Port number is the port number used to start the Web Server:

            string connectionString = $"Server={server}; Database={database};";

            AceQLConnection connection = new AceQLConnection(connectionString)
            {
                Credential = new AceQLCredential(username, password)
            };
            return connection;
        }

    }
}
