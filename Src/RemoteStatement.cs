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

// ***********************************************************************
// Assembly         : AceQLWindowsFormsApp
// Author           : Nicolas de Pomereu
// Created          : 11-04-2019
//
// Last Modified By : Nicolas de Pomereu
// Last Modified On : 11-04-2019
// ***********************************************************************
// <copyright file="RemoteStatement.cs" company="KawanSoft">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AceQL.Client.Api;
using System.IO;

using AceQL.Client.WinFormTest;

namespace AceQL.Client.WinFormTest
{

    /// <summary>
    /// Class RemoteStatement.
    /// Schema is available here: https://www.aceql.com/rest/soft/6.0/src/aceql_demo.txt 
    /// Class contains all SQL statements that call remote AceQL server.
    /// <para/>Class is portable without change with Xamarin for all targets (iOS, Android, etc.)
    /// </summary>
    public class RemoteStatement
    {
        /// <summary>
        /// The connection
        /// </summary>
        private AceQLConnection connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteStatement"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public RemoteStatement(AceQLConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// insert customers into customer as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task InsertCustomersAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                string sql = "insert into customer values " +
                            "(@customer_id, @customer_title, @fname, " +
                        "@lname, @addressline, @town, @zipcode, @phone)";

                AceQLCommand command = new AceQLCommand(sql, connection);

                int customerId = i;

                command.Parameters.AddWithValue("@customer_id", customerId);
                command.Parameters.AddWithValue("@customer_title", "Sir");
                command.Parameters.AddWithValue("@fname", "André_" + customerId);
                command.Parameters.AddWithValue("@lname", "Name_" + customerId);
                command.Parameters.AddWithValue("@addressline", customerId + ", road 66");
                command.Parameters.AddWithValue("@town", "Town_" + customerId);
                command.Parameters.AddWithValue("@zipcode", customerId + "1111"); ;
                command.Parameters.Add(new AceQLParameter("@phone", new AceQLNullValue(AceQLNullType.VARCHAR)));

                await command.ExecuteNonQueryAsync();
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Select all customer asynchronous.
        /// Builds a 2 dimensions string array: string[number of rows, number of colums]
        /// </summary>
        /// <returns>A 2 dimensions string array: string[number of rows, number of colums].</returns>
        /// <remarks>Nicolas De Pomereu, 24/05/2017.</remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<string[,]> SelectAllCutomersAsync()
        {
            int max_rows_number = 100000;
            int columns_number = 3;

            string[,] items = new string[max_rows_number, columns_number];
            int cpt = 0;

            String sql = "select * from customer";
            AceQLCommand command = new AceQLCommand(sql, connection);

            using (AceQLDataReader dataReader = await command.ExecuteReaderAsync())
            {
                while (dataReader.Read())
                {
                    int i = 0;
                    int j = 0;
                    items[cpt, j++] = (String)dataReader.GetValue(i++).ToString();
                    i++; // Skip customer_title
                    items[cpt, j++] = (String)dataReader.GetValue(i++);
                    items[cpt, j++] = (String)dataReader.GetValue(i++);

                    cpt++;
                }
            }

            // Copy items to itemsFinal, with a new fixed [GetLength(0), GetLength(1)]
            string[,] itemsFinal = new string[cpt, items.GetLength(1)];

            for (int i = 0; i < cpt; i++)
            {
                for (int j = 0; j < items.GetLength(1); j++)
                {
                    itemsFinal[i, j] = items[i, j];
                }
            }

            return itemsFinal;
        }

        /// <summary>
        /// select customer as an asynchronous operation.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<string> SelectCustomerAsync(int customerId)
        {
            String sql = "select * from customer where customer_id = @customer_id";
            AceQLCommand command = new AceQLCommand(sql, connection);
            command.Parameters.AddWithValue("@customer_id", 1);

            String resultString = null;
            using (AceQLDataReader dataReader = await command.ExecuteReaderAsync())
            {
                while (dataReader.Read())
                {
                    int i = 0;
                    resultString = dataReader.GetString(i++);
                    resultString += " / " + dataReader.GetString(i++);
                    resultString += " / " + dataReader.GetString(i++);
                    resultString += " / " + dataReader.GetString(i++);
                    resultString += " / " + dataReader.GetString(i++);
                    resultString += " / " + dataReader.GetString(i++);
                    resultString += " / " + dataReader.GetString(i++);
                    resultString += " / " + dataReader.GetString(i++);
                }
            }

            return resultString;

        }
        /// <summary>
        /// Inserts an image into a product_image using a stream.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="productName">Name of the product.</param>
        /// <param name="stream">The stream.</param>
        /// <returns>Task.</returns>
        public async Task InsertIntoProductAsync(int productId, string productName, Stream stream)
        {
            AceQLTransaction transaction = await connection.BeginTransactionAsync();

            try
            {
                String sql =
                "insert into product_image values (@product_id,  @name, @image)";

                AceQLCommand command = new AceQLCommand(sql, connection);
                command.Parameters.AddWithValue("@product_id", productId);
                command.Parameters.AddWithValue("@name", productName);
                command.Parameters.AddWithValue("@image", stream);

                await command.ExecuteNonQueryAsync();

            }
            finally
            {
                await transaction.CommitAsync();
            }

        }


        /// <summary>
        /// Returns a Stream on the blob in product_image table
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<Stream> SelectProductImageAsync(int productId)
        {
            AceQLTransaction transaction = await connection.BeginTransactionAsync();
            Stream stream = null;

            try
            {
                String sql = "select image from product_image where product_id = @product_id";
                AceQLCommand command = new AceQLCommand(sql, connection);
                command.Parameters.AddWithValue("@product_id", productId);

                using (AceQLDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (dataReader.Read())
                    {
                        stream = await dataReader.GetStreamAsync(0);
                    }

                    await transaction.CommitAsync();
                }
            }
            catch (Exception e)
            {
                try
                {
                    await transaction.RollbackAsync();
                }
                catch (Exception)
                {
                    // Don't care
                }

                throw e;
            }

            return stream;
        }
        /// <summary>
        /// delete all product_image rows as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task DeleteAllProductsAsync()
        {
            await DeleteAllAsync("delete from product_image");
        }

        /// <summary>
        /// delete all customer rows as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task DeleteAllCustomersAsync()
        {
            await DeleteAllAsync("delete from customer");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes all asynchronous described by SQL./ </summary>
        ///
        /// <remarks>   Nicolas De Pomereu, 25/05/2017. </remarks>
        ///
        /// <param name="sql">the SQL statement. </param>
        ///
        /// <returns>   The asynchronous result. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private async Task DeleteAllAsync(string sql)
        {
            AceQLCommand command = new AceQLCommand()
            {
                CommandText = sql,
                Connection = connection
            };
            command.Prepare();

            await command.ExecuteNonQueryAsync();
        }
    }
}
