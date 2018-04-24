using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SignalR.Service
{
    public class SqlWatcher
    {
        private string connectionString;
        private string sqlQueue;
        private string listenerQuery;
        private SqlDependency dependency;

        public SqlWatcher(string connectionString, string sqlQueue, string listenerQuery)
        {
            this.connectionString = connectionString;
            this.sqlQueue = sqlQueue;
            this.listenerQuery = listenerQuery;
            this.dependency = null;
        }

        public void Start()
        {
            SqlDependency.Start(connectionString, sqlQueue);
            ListenForChanges();
        }

        public void Stop()
        {
            SqlDependency.Stop(this.connectionString, sqlQueue);
        }

        private void ListenForChanges()
        {
            //Remove existing dependency, if necessary
            if (dependency != null)
            {
                dependency.OnChange -= onDependencyChange;
                dependency = null;
            }

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(listenerQuery, connection);

            dependency = new SqlDependency(command);

            // Subscribe to the SqlDependency event.
            dependency.OnChange += new OnChangeEventHandler(onDependencyChange);

            SqlDependency.Start(connectionString);

            command.ExecuteReader();

            //Perform this action when SQL notifies of a change
            performAction();

            connection.Close();
        }

        private void onDependencyChange(Object o, SqlNotificationEventArgs args)
        {
            if ((args.Source.ToString() == "Data") || (args.Source.ToString() == "Timeout"))
            {
                Console.WriteLine(System.Environment.NewLine + "Refreshing data due to {0}", args.Source);
                ListenForChanges();
            }
            else
            {
                Console.WriteLine(System.Environment.NewLine + "Data not refreshed due to unexpected SqlNotificationEventArgs: Source={0}, Info={1}, Type={2}", args.Source, args.Info, args.Type.ToString());
            }
        }

        private void performAction()
        {
            Console.WriteLine("Performing action");
        }
    }
}


//NotificationService

    //https://stackoverflow.com/questions/20503286/using-sqldependency-with-named-queues