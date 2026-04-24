using CPTR319_20_8_2025.Contracts;
using System.Text;

namespace CPTR319_20_8_2025
{
    public class Node : INode, IEquatable<INode?>
    {
        #region INode Implementation
        public List<IClassified> UnClassifiedList { get; set; } = new List<IClassified>();
        public int PartitionIndex { get; set; }
        public string PartitionValue { get; set; } = string.Empty;
        public double BestInfomationGain { get; set; }
        public INode? Left { get; set; } 
        public INode? Right { get; set; }


        /// <summary>
        /// Performs the partitioning of list recursively until purity or 
        /// minimum size set conditions are met.
        /// </summary>
        /// <param name="list"></param>
        public void Partition()
        {
            //TODO
        }

        /// <summary>
        /// Used to calculate purity (Gini or Entropy) based on PurityMeasures.PURITY_TYPE.
        /// </summary>
        /// <returns>double purity score in [0,1)</returns>
        public double Purity()
        {
            if (PurityMeasures.PURITY_TYPE == "Gini")
            {
                return PurityMeasures.Gini(UnClassifiedList);
            }
            else
            {
                return PurityMeasures.Entropy(UnClassifiedList);
            }
        }

        /// <summary>
        /// See INode documentation.
        /// </summary>
        /// <returns>True if leaf or false if not.</returns>
        public bool IsLeafNode()
        {
            return (Left is null) && (Right is null);
        }
        #endregion

        #region IEquatable<T> Implementation
        /// <summary>
        /// Used for testing
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool Equals(INode? node)
        {
            if (node is null) return false;
            else
            {
                if (this.PartitionIndex != node.PartitionIndex) return false;
                if (this.PartitionValue != node.PartitionValue) return false;
                if (!this.BestInfomationGain.ToString("0.####").Equals(node.BestInfomationGain.ToString("0.####"))) return false;
                if (this.UnClassifiedList.Count != node.UnClassifiedList.Count) return false;
                if (this.UnClassifiedList.Except<IClassified>(node.UnClassifiedList).Count() != 0) return false;
                if ((this.Left != null && node.Left != null) && (!this.Left.Equals(node.Left))) return false;
                if ((this.Right != null && node.Right != null) && (!this.Right.Equals(node.Right))) return false;
                return true;
            }
        }

        /// <summary>
        /// Used for testing
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            else
            {
                INode? objNode = obj as INode;
                if (objNode == null) return false;
                else return Equals(objNode);
            }
        }

        public override int GetHashCode()
        {
            List<string> hashList = new List<string>();
            foreach (var item in UnClassifiedList)
            {
                var val = item.ToString();
                if (val is not null) 
                    hashList.Add(val);
            }
            hashList.Sort();
            StringBuilder sb = new StringBuilder();
            foreach (var item in hashList)
                sb.Append(item);
            var h = sb.ToString()
                + PartitionValue
                + PartitionIndex.ToString()
                + BestInfomationGain.ToString("0.####");
            return h.GetHashCode();
        }

        #endregion
    }
}
