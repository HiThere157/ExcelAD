using ExcelDna.Integration;

namespace ExcelAD.UDF
{
    public class Say
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
            [ExcelArgument(Description = "Name")] string name
        )
        {
            return "Bye " + name;
        }
    }
}
