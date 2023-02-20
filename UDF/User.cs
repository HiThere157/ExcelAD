using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using ExcelDna.Integration;

namespace ExcelAD.UDF
{
    public class User
    {
        [ExcelFunction(Description = "Get a Property from a User Object in an Active Directory Domain.")]
        public static object UserProperty(
            [ExcelArgument(Description = "The Search Value for the User Object")] string filter_value,
            [ExcelArgument(Description = "The Search Property on the User Object")] string filter_property,
            [ExcelArgument(Description = "The Property to Return from the user Object")] string return_property,
            [ExcelArgument(Description = "The Search Domain")] string domain
        )
        {
            DirectoryEntry directoryEntry = null;
            try
            {
                IEnumerable<string> domainParts = domain.Split('.').Select(part => "dc=" + part);

                directoryEntry = new DirectoryEntry($"LDAP://{String.Join(",", domainParts)}");
                DirectorySearcher searcher = new DirectorySearcher(directoryEntry);
                searcher.Filter = $"(&(objectClass=user)({filter_property}={filter_value}))";

                SearchResultCollection searchResults = searcher.FindAll();

                switch (searchResults.Count)
                {
                    case 1:
                        ResultPropertyCollection properties = searchResults[0].Properties;
                        string return_value = (string)properties[return_property][0];

                        if (return_value == null) return ExcelError.ExcelErrorNA;
                        return return_value.ToString();

                    case 0:
                        return ExcelError.ExcelErrorNA;
                    default:
                        return ExcelError.ExcelErrorValue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occurred in ExcelAD.UDF.UserProperty: " + ex.Message);
                return ExcelError.ExcelErrorValue;
            }
            finally
            {
                directoryEntry?.Close();
            }
        }
    }
}
