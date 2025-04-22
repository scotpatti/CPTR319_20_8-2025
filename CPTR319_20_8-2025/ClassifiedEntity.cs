using CPTR319_20_8_2025.Contracts;
using System.Text;

namespace CPTR319_20_8_2025
{
    /// <summary>
    /// This class is provided for your enjoyment. 
    /// DO NOT MODIFY IT!
    /// </summary>
    public class ClassifiedEntity : IClassified, IEquatable<IClassified>
    {
        /// <summary>
        /// Required by Interface
        /// </summary>
        public List<string> Attributes { get; set; }

        /// <summary>
        /// Required by Interface
        /// </summary>
        public string Class { get; set; } = string.Empty;

        /// <summary>
        /// Very simple constructor
        /// </summary>
        public ClassifiedEntity()
        {
            Attributes = new List<string>();
        }

        /// <summary>
        /// Provided for your enjoyment. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            for (int i = 0; i < Attributes.Count; i++)
                sb.Append(Attributes[i] + ",");
            sb.Append(Class);
            sb.Append(")");
            return sb.ToString();
        }

        /// <summary>
        /// Neccessary for Testing
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IClassified? other)
        {
            if (other is null) return false;
            else
            {
                if (this.Attributes.Count != other.Attributes.Count) return false;
                if (this.Attributes.Except(other.Attributes).Count() != 0) return false;
                if (this.Class != other.Class) return false;
                return true;
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            else
            {
                IClassified? objIClassified = obj as IClassified;
                if (objIClassified == null) return false;
                else return Equals(objIClassified);
            }
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
