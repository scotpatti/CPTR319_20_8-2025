using CPTR319_20_8_2025.Contracts;
using System.Text;

namespace CPTR319_20_8_2025.Extensions
{
    /// <summary>
    /// This extension class is provided for your enjoyment.
    /// DO NOT MODIFY
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Adds functionality to List<IClassified> so that you can call List<IClassified>.ToString()
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Space separated elements of the training data in List<IClassified></returns>
        public static string ToSpacedString(this List<IClassified> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var i in list)
                sb.Append(i.ToString() + " ");
            return sb.ToString();
        }
    }
}
