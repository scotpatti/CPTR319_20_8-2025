using CPTR319_20_8_2025.Contracts;

namespace CPTR319_20_8_2025
{
    public static class PurityMeasures
    {
        public static string PURITY_TYPE = "Gini";

        public static double Gini(List<IClassified> list)
        {
            Dictionary<string, double> set = new Dictionary<string, double>();

            for (int i = 0; i < list.Count; i++)
            {
                if (set.ContainsKey(list[i].Class))
                {
                    double s = set[list[i].Class];
                    set[list[i].Class] = s + 1;
                }
                else
                {
                    set.Add(list[i].Class, 1);
                }
            }
            double sum = 0;
            foreach (var key in set.Keys)
            {
                sum = sum + Math.Pow(set[key], 2) / Math.Pow(list.Count, 2);
            }
            return 1 - sum;
        }

        public static double Entropy(List<IClassified> list)
        {
            Dictionary<string, double> set = new Dictionary<string, double>();

            for (int i = 0; i < list.Count; i++)
            {
                if (set.ContainsKey(list[i].Class))
                {
                    double s = set[list[i].Class];
                    set[list[i].Class] = s + 1;
                }
                else
                {
                    set.Add(list[i].Class, 1);
                }
            }
            double sum = 0;
            foreach (var key in set.Keys)
            {
                double p = set[key] / list.Count;
                sum = sum + (p * Math.Log(p, 2));
            }
            return 1 - sum;
        }

        public static double Gini(List<IClassified> L1, List<IClassified> L2)
        {
            double C = L1.Count + L2.Count;
            return (L1.Count / C) * Gini(L1) + (L2.Count / C) * Gini(L2);
        }

        public static double Entropy(List<IClassified> L1, List<IClassified> L2)
        {
            int C = L1.Count + L2.Count;
            return (L1.Count / C) * Entropy(L1) + (L2.Count / C) * Entropy(L2);
        }

        /// <summary>
        /// Information gain based on the split of S in to S1 and S2.
        /// </summary>
        /// <param name="S"></param>
        /// <param name="S1"></param>
        /// <param name="S2"></param>
        /// <returns></returns>
        public static double InformationGain(List<IClassified> S, List<IClassified> S1, List<IClassified> S2)
        {
            double s = PurityMeasures.Gini(S);
            double s12 = PurityMeasures.Gini(S1, S2);
            return s - s12;
        }
    }
}
