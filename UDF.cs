using ExcelDna.Integration;

namespace ExcelAD
{
    public class UDF
    {
        [ExcelFunction(Description = "First Desc")]
        public static string SayHello(
            [ExcelArgument(Description = "Name")] string name
        )
        {
            return "Hello " + name;
        }

        [ExcelFunction(Description = "Second Desc")]
        public static string SayBye(
            [ExcelArgument(Description = "Name")]
            string name
        )
        {
            return "Hello " + name;
        }
    }
}