namespace CPTR319_20_8_2025.Contracts
{
    /// THIS IS HERE TO MAKE SURE THE TESTS RUN DO NOT MODIFY
    public interface INode
    {
        /// /// List of training datum where each datum is tuple of the form:
        /// (val1, val2, ..., valn, class)
        List<IClassified> UnClassifiedList { get; set; }

        /// When you run Partition, set this to the final index of the element 
        /// your algorithm partitions on. I.e. the one with the most informaiton gain.
        int PartitionIndex { get; set; }

        /// The value at the partition index that you split on
        string PartitionValue { get; set; }

        /// A place to store your BestInformationGain while partitioning. At 
        /// the end of your partitioning, it should show the actual best 
        /// InformationGain
        double BestInfomationGain { get; set; }

        /// Assuming there is a partition, create left and right nodes.
        INode? Left { get; set; }

        /// Assuming there is a partition, create left and right nodes.
        INode? Right { get; set; }

        /// Your main contribution is to write a partition algorithm!
        void Partition();

        /// Calculates the purity of UnClassifiedList. Note this could be the 
        /// Gini score or the Entropy, see PurityMeasures.cs
        double Purity();

        /// True if Left and Right are null, False if Left and Right are not null, error otherwise. 
        bool isLeafNode();
    }
}
