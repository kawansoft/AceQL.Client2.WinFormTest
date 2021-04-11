
using AceQL.Client.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AceQL.Client.WinFormTest
{
    /// <summary>
    /// Class AceQLFormMain.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class AceQLFormMain : Form
    {
        /// <summary>
        /// The aceql test
        /// </summary>
        public const string ACEQL_TEST = "AceQL Test";
        /// <summary>
        /// The aceql PCL folder
        /// </summary>
        public const string ACEQL_PCL_FOLDER = "AceQLPclFolder";

        private const int CONNECTION_COLOR_YELLOW = 1;
        private const int CONNECTION_COLOR_GREEN = 2;

        private const string LOCALHOST = "http://localhost:9090/aceql";
        //private const string REMOTE = "http://localhost:9090/aceql";

        private String server = LOCALHOST;
        private String database = "sampledb";
        private String version = "v2.0";

        /// <summary>
        /// Connection to remote database
        /// </summary>
        private AceQLConnection connection = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="AceQLFormMain"/> class.
        /// </summary>
        public AceQLFormMain()
        {
            InitializeComponent();
            //this.textBoxServer.Text = server;
            this.labelVersion.Text = version;

            //ValidateUserEntry();
        }


        private void ValidateUserEntry()
        {
            // Initializes the variables to pass to the MessageBox.Show method.
            string message = "You did not enter a server name. Cancel this operation?";
            string caption = "Error Detected in Input";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                // Closes the parent form.
                this.Close();
            }

        }


        private async void buttonConnect_Click(object sender, EventArgs e)
        {
            if (connection != null)
            {
                PopMesssage.Show("You are already connected!", ACEQL_TEST);
                return;
            }

            SetConnectionStatusColor(CONNECTION_COLOR_YELLOW);

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //AceQLConnection.SetTraceOn(true);
                ConnectionBuilder connectionBuilder = new ConnectionBuilder(server, database, "username", "password".ToArray());
                connection = connectionBuilder.GetConnection();
                await connection.OpenAsync();
            }
            catch (Exception exeption)
            {
                Cursor.Current = Cursors.Default;
                PopMesssage.Show("Could not connect: \n" + exeption.ToString(), ACEQL_TEST);
                return;
            }
            SetConnectionStatusColor(CONNECTION_COLOR_GREEN);
            Cursor.Current = Cursors.Default;

        }

        /// <summary>
        /// Changes the connection status color
        /// </summary>
        /// <param name="connectionColor">The color to set</param>
        private void SetConnectionStatusColor(int connectionColor)
        {
            if (connectionColor == CONNECTION_COLOR_YELLOW)
            {
                labelConnectionStatus.Image = AceQL.Client2.WinFormTest.Properties.Resources.bullet_ball_yellow;
            }
            else if (connectionColor == CONNECTION_COLOR_GREEN)
            {
                labelConnectionStatus.Image = AceQL.Client2.WinFormTest.Properties.Resources.bullet_ball_green;
            }
            else
            {
                throw new ArgumentException("Invalid color: " + connectionColor);
            }

        }


        private async void buttonInsert_ClickAsync(object sender, EventArgs e)
        {
            if (connection == null)
            {
                PopMesssage.Show("Please connect to remote database before Insert!", ACEQL_TEST);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                // Delte all before to avoid duplicates
                RemoteStatement remoteStatement = new RemoteStatement(connection);
                await remoteStatement.DeleteAllCustomersAsync();

                await remoteStatement.InsertCustomersAsync();
                PopMesssage.Show("Data has been inserted in remote database!", ACEQL_TEST);

            }
            catch (Exception exeption)
            {
                Cursor.Current = Cursors.Default;
                PopMesssage.Show("Could not execute Insert statement: \n" + exeption.ToString(), ACEQL_TEST);
            }
            Cursor.Current = Cursors.Default;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (connection != null)
                {
                    connection.CloseAsync();
                }
            }
            catch (Exception)
            {
                // Don't care
            }
            this.Hide();
            Application.Exit();
        }

        private async void buttonSelect_ClickAsync(object sender, EventArgs e)
        {
            if (connection == null)
            {
                PopMesssage.Show("Please connect to remote database before Select!", ACEQL_TEST);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                // Delte all before to avoid duplicates
                RemoteStatement remoteStatement = new RemoteStatement(connection);
                int customerId = 1;
                String customerRow = await remoteStatement.SelectCustomerAsync(customerId);

                if (customerRow == null)
                {
                    PopMesssage.Show("Click \"Insert\" to populate the " +
                        "database before doing the Select.", ACEQL_TEST);
                    return;
                }

                PopMesssage.Show(customerRow, ACEQL_TEST);

            }
            catch (Exception exeption)
            {
                Cursor.Current = Cursors.Default;
                PopMesssage.Show("Could not execute Insert statement: \n" + exeption.ToString(), ACEQL_TEST);
            }
            Cursor.Current = Cursors.Default;
        }


        private async void buttonInsertBlob_ClickAsync(object sender, EventArgs e)
        {
            if (connection == null)
            {
                PopMesssage.Show("Please connect to remote database before Insert!", ACEQL_TEST);
                return;
            }

            // Test if koala.jpg is in ACEQL_PCL_FOLDER

            String folder = AceQLConnection.GetAceQLLocalFolder();
            String file = folder + "\\koala.jpg";

            if (!File.Exists(file))
            {
                PopMesssage.Show("Please copy a file named koala.jpg in this folder and try again: \n"
                    + folder
                    , ACEQL_TEST);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                // Delte all before to avoid duplicates
                RemoteStatement remoteStatement = new RemoteStatement(connection);
                await remoteStatement.DeleteAllProductsAsync();

                Stream stream = File.OpenRead(file);
                await remoteStatement.InsertIntoProductAsync(1, "koala.jpg", stream);

                PopMesssage.Show("Blob inserted in database!", ACEQL_TEST);

            }
            catch (Exception exeption)
            {
                Cursor.Current = Cursors.Default;
                PopMesssage.Show("Could not execute Insert statement: \n" + exeption.ToString(), ACEQL_TEST);
            }
            Cursor.Current = Cursors.Default;
        }


        private async void buttonSelectBlob_ClickAsync(object sender, EventArgs e)
        {
            if (connection == null)
            {
                PopMesssage.Show("Please connect to remote database before Select!", ACEQL_TEST);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string folder = AceQLConnection.GetAceQLLocalFolder();
                String file = folder + "\\koala_blob.jpg";

                RemoteStatement remoteStatement = new RemoteStatement(connection);

                using (Stream stream = await remoteStatement.SelectProductImageAsync(1))
                {

                    if (stream == null)
                    {
                        PopMesssage.Show("Click \"Insert\" to insert a Blob in remote database before doing the Select!", ACEQL_TEST);
                        return;
                    }

                    // Dump on koala_blob.jpg
                    using (var writeStream = File.OpenWrite(file))
                    {
                        stream.CopyTo(writeStream);
                    }
                }

                PopMesssage.Show("Blob successfully downloaded from database in file: \n"
                    + file, ACEQL_TEST);

            }
            catch (Exception exeption)
            {
                Cursor.Current = Cursors.Default;
                PopMesssage.Show("Could not execute Insert statement: \n" + exeption.ToString(), ACEQL_TEST);
            }
            Cursor.Current = Cursors.Default;
        }

    }


}
