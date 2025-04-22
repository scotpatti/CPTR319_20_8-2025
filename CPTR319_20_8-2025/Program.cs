using CPTR319_20_8_2025.Contracts;
using CPTR319_20_8_2025.Extensions;

namespace CPTR319_20_8_2025;

public class Program
{
    public List<IClassified> List = new List<IClassified>(); //Set of Entities to use for building a classification tree.
    public static double dp; //acceptable purity level 
    public static double ds; //Minimum size

    static void Main(string[] args)
    {
        #region setup

        if ((args.Length != 1) && (args.Length != 3))
        {
            Console.WriteLine("Usage: CPTR319_20_8 filename [purity_level smallest_size_set]");
            return;
        }
        Program prog = new Program();
        string filename = (string)args[0];
        if (args.Length == 3)
        {
            Program.dp = int.Parse(args[1]);
            Program.ds = int.Parse(args[2]);
        }
        else  //Defaults default purity = 0. default minimum set size = 1.
        {
            Program.dp = 0;
            Program.ds = 1;
        }

        #endregion

        INode? node = LoadNodeFromFile(filename);
        if (node != null)
        {
            node.Partition();
            PrintTree(node, "");
        }
    }

    public static void PrintTree(INode? node, string indent)
    {
        if (node is null) return;
        else
        {
            if (node.isLeafNode())
            {
                Console.WriteLine(indent + "+- " + node.UnClassifiedList.ToSpacedString());
                indent += "   ";
            }
            else
            {
                Console.WriteLine(indent + "+- " + node.UnClassifiedList.ToSpacedString());
                Console.WriteLine(indent +
                    "|  Part: Index=" + node.PartitionIndex +
                    " Value=" + node.PartitionValue +
                    "BestGain=" + node.BestInfomationGain.ToString("0.####"));
                indent += "|  ";
                PrintTree(node.Left, indent);
                PrintTree(node.Right, indent);
            }
        }
    }

    public static INode? LoadNodeFromFile(string filename)
    {
        try
        {
            List<IClassified> list = new List<IClassified>();
            string? line;
            StreamReader sr = new StreamReader(filename);
            while ((line = sr.ReadLine()) != null)
            {
                ClassifiedEntity obj = new ClassifiedEntity();
                string[] x = line.Split(',');
                for (int i = 0; i < x.Length; i++)
                {
                    if (i < x.Length - 1)
                        obj.Attributes.Add(x[i]);
                    else
                        obj.Class = x[i];
                }
                list.Add(obj);
            }
            INode node = new Node()
            {
                UnClassifiedList = list
            };
            return node;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error reading file!\r\n" + e.Message);
        }
        return null;
    }
}