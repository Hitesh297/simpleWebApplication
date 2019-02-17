using System;

    public class PartitionResolver : System.Web.IPartitionResolver
    {

        #region Private members

        private String[] partitions;

        #endregion

        #region IPartitionResolver Members

        public void Initialize()
        {
            // Create an array containing
            // all partition connection strings
            //
            // Note that this could also be an array
            // of SQL server connection strings!
            partitions = new string[] {
            "tcpip=127.0.0.1:42424",
            "tcpip=localhost:42424"
        };
        }

        public string ResolvePartition(object key)
        {
        string oHost = System.Web.HttpContext.Current.Request.Url.Host.ToLower().Trim();

        if (oHost.StartsWith("10.0.0") || oHost.Equals("localhost"))
            return "tcpip=127.0.0.1:42424";

        string sid = (string)key;
        // hash the incoming session ID into
        // one of the available partitions
        int partitionID = Math.Abs(sid.GetHashCode()) % partitions.Length;

        return ("tcpip=" + partitions[partitionID] + ":42424");
    }

    #endregion
}

