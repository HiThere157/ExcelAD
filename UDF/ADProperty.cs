using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using ExcelDna.Integration;

namespace ExcelAD.UDF
{
    public class ADProperty
    {
        private static object _getProperty(string filter_type, string filter_value, string filter_property, string return_property, string domain)
        {
            DirectoryEntry directoryEntry = null;

            try
            {
                directoryEntry = new DirectoryEntry($"LDAP://{domain}", null, null, AuthenticationTypes.Secure | AuthenticationTypes.Sealing);

                DirectorySearcher searcher = new DirectorySearcher(directoryEntry);
                searcher.Filter = $"(&(objectClass={filter_type})({filter_property}={filter_value}))";

                SearchResultCollection searchResults = searcher.FindAll();
                switch (searchResults.Count)
                {
                    case 1:
                        ResultPropertyCollection properties = searchResults[0].Properties;
                        ResultPropertyValueCollection return_value = properties[return_property];

                        if (return_value == null) return ExcelError.ExcelErrorNull;
                        return return_value[0].ToString();

                    case 0:
                        return ExcelError.ExcelErrorNA;
                    default:
                        return ExcelError.ExcelErrorValue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occurred in ExcelAD.UDF.ADProperty: " + ex.Message);
                return ExcelError.ExcelErrorValue;
            }
            finally
            {
                directoryEntry.Close();
            }
        }

        [ExcelFunction(Description = "Get a Property from a User Object in an Active Directory Domain.")]
        public static object UserProperty(
            [ExcelArgument(Description = "The Search Value for the User Object")] string filter_value,
            [ExcelArgument(Description = "The Search Property on the User Object")] string filter_property,
            [ExcelArgument(Description = "The Property to Return from the user Object")] string return_property,
            [ExcelArgument(Description = "The Search Domain")] string domain
        )
        {
            return _getProperty("user", filter_value, filter_property, return_property, domain);
        }

        [ExcelFunction(Description = "Get a Property from a Group Object in an Active Directory Domain.")]
        public static object GroupProperty(
            [ExcelArgument(Description = "The Search Value for the Group Object")] string filter_value,
            [ExcelArgument(Description = "The Search Property on the Group Object")] string filter_property,
            [ExcelArgument(Description = "The Property to Return from the Group Object")] string return_property,
            [ExcelArgument(Description = "The Search Domain")] string domain
        )
        {
            return _getProperty("group", filter_value, filter_property, return_property, domain);
        }

        [ExcelFunction(Description = "Get a Property from a Computer Object in an Active Directory Domain.")]
        public static object ComputerProperty(
            [ExcelArgument(Description = "The Search Value for the Computer Object")] string filter_value,
            [ExcelArgument(Description = "The Search Property on the Computer Object")] string filter_property,
            [ExcelArgument(Description = "The Property to Return from the Computer Object")] string return_property,
            [ExcelArgument(Description = "The Search Domain")] string domain
        )
        {
            return _getProperty("computer", filter_value, filter_property, return_property, domain);
        }

    }
}
