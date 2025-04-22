using CPTR319_20_8_2025;
using CPTR319_20_8_2025.Contracts;

namespace XUnitTestPrj
{
    public class NodeTest
    {
        [Fact]
        public void EquailtyOnTestData()
        {
            INode? studentNode = CPTR319_20_8_2025.Program.LoadNodeFromFile("Ch20.8.data.txt");
            INode? testNode = CreateTestData();
            if (studentNode != null && testNode != null)
            {
                studentNode.Partition();
                bool test = testNode.Equals(studentNode);
                Assert.True(test);
            }
            else
            {
                Assert.NotNull(studentNode);
                Assert.NotNull(testNode);
            }
        }
        /// <summary>
        /// In each one of the Get... functions, E.g. GetTop(), The order of 
        /// the new ClassifiedEntity objects does not matter.
        /// </summary>
        /// <returns></returns>
        INode? CreateTestData()
        {
            INode? x = new Node()
            {
                UnClassifiedList = GetTop(),
                PartitionIndex = 1,
                PartitionValue = "2",
                BestInfomationGain = 0.2751,
                Left = new Node
                {
                    UnClassifiedList = GetTopLeft() //No children so no split info
                },
                Right = new Node
                {
                    UnClassifiedList = GetTopRight(),
                    PartitionIndex = 0,
                    PartitionValue = "4",
                    BestInfomationGain = 0.2177,
                    Left = new Node()
                    {
                        UnClassifiedList = GetTopRightLeft() //No Children so no split info
                    },
                    Right = new Node()
                    {
                        UnClassifiedList = GetTopRightRight(),
                        PartitionIndex = 1,
                        PartitionValue = "3",
                        BestInfomationGain = 0.4444,
                        Left = new Node()
                        {
                            UnClassifiedList = GetTopRightRightLeft() //No Children so no split info
                        },
                        Right = new Node()
                        {
                            UnClassifiedList = GetTopRightRightRight() //No Children so no split info
                        }
                    }
                }
            };
            return x;
        }

        List<IClassified> GetTop()
        {
            return new List<IClassified>()
            {
                new ClassifiedEntity() { Attributes = new List<string>() { "2", "1" }, Class = "a" },
                new ClassifiedEntity() { Attributes = new List<string>() { "1", "2" }, Class = "a" },
                new ClassifiedEntity() { Attributes = new List<string>() { "3", "3" }, Class = "b" },
                new ClassifiedEntity() { Attributes = new List<string>() { "6", "3" }, Class = "b" },
                new ClassifiedEntity() { Attributes = new List<string>() { "2", "5" }, Class = "b" },
                new ClassifiedEntity() { Attributes = new List<string>() { "4", "5" }, Class = "b" },
                new ClassifiedEntity() { Attributes = new List<string>() { "5", "5" }, Class = "c" },
                new ClassifiedEntity() { Attributes = new List<string>() { "3", "6" }, Class = "b" },
                new ClassifiedEntity() { Attributes = new List<string>() { "6", "7" }, Class = "c" }
            };
        }

        List<IClassified> GetTopLeft()
        {
            return new List<IClassified>()
            {
                new ClassifiedEntity() { Attributes = new List<string>() { "2", "1" }, Class = "a" },
                new ClassifiedEntity() { Attributes = new List<string>() { "1", "2" }, Class = "a" }
            };
        }

        List<IClassified> GetTopRight()
        {
            return new List<IClassified>()
            {
                new ClassifiedEntity() { Attributes = new List<string>() { "3", "3" }, Class = "b" },
                new ClassifiedEntity() { Attributes = new List<string>() { "6", "3" }, Class = "b" },
                new ClassifiedEntity() { Attributes = new List<string>() { "2", "5" }, Class = "b" },
                new ClassifiedEntity() { Attributes = new List<string>() { "4", "5" }, Class = "b" },
                new ClassifiedEntity() { Attributes = new List<string>() { "5", "5" }, Class = "c" },
                new ClassifiedEntity() { Attributes = new List<string>() { "3", "6" }, Class = "b" },
                new ClassifiedEntity() { Attributes = new List<string>() { "6", "7" }, Class = "c" }
            };
        }

        List<IClassified> GetTopRightLeft()
        {
            return new List<IClassified>()
            {

                new ClassifiedEntity() { Attributes = new List<string>() { "2", "5" }, Class = "b" },
                new ClassifiedEntity() { Attributes = new List<string>() { "3", "3" }, Class = "b" },
                new ClassifiedEntity() { Attributes = new List<string>() { "3", "6" }, Class = "b" },
                new ClassifiedEntity() { Attributes = new List<string>() { "4", "5" }, Class = "b" },
            };
        }

        List<IClassified> GetTopRightRight()
        {
            return new List<IClassified>()
            {
                new ClassifiedEntity() { Attributes = new List<string>() { "6", "3" }, Class = "b" },
                new ClassifiedEntity() { Attributes = new List<string>() { "5", "5" }, Class = "c" },
                new ClassifiedEntity() { Attributes = new List<string>() { "6", "7" }, Class = "c" },
            };
        }

        List<IClassified> GetTopRightRightLeft()
        {
            return new List<IClassified>()
            {
                new ClassifiedEntity() { Attributes = new List<string>() { "6", "3" }, Class = "b" }
            };
        }

        List<IClassified> GetTopRightRightRight()
        {
            return new List<IClassified>()
            {
                new ClassifiedEntity() { Attributes = new List<string>() { "5", "5" }, Class = "c" },
                new ClassifiedEntity() { Attributes = new List<string>() { "6", "7" }, Class = "c" },
            };
        }
    }
}