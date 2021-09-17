using Core.Utilities.Results;
using System.Linq;

namespace Core.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] results)
        {
            //foreach (var result in results)
            //{ if (!result.Success) return result; }
            //
            //return null;

            return results.FirstOrDefault(result => !result.Success);
        }
    }
}