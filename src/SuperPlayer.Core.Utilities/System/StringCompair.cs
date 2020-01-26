namespace System.Linq
{
    static class StringCompair
    {
        public static string LCS(string s1, string s2)
        {
            if (s1 == s2)
                return s1;
            else if (String.IsNullOrEmpty(s1) || String.IsNullOrEmpty(s2))
                return null;

            var d = new int[s1.Length, s2.Length];

            var index = 0;
            var length = 0;

            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    // 左上角值
                    var n = i - 1 >= 0 && j - 1 >= 0 ? d[i - 1, j - 1] : 0;

                    // 当前节点值 = "1 + 左上角值" : "0"
                    d[i, j] = s1[i] == s2[j] ? 1 + n : 0;

                    // 如果是最大值，则记录该值和行号
                    if (d[i, j] > length)
                    {
                        length = d[i, j];
                        index = i;
                    }
                }
            }

            return s1.Substring(index - length + 1, length);
        }
        public static string LCS(params string[] strings)
        {
            if (strings.Length == 0)
            {
                return "";
            }
            if (strings.Length == 1)
            {
                return strings[0];
            }
            if (strings.Length >= 2)
            {
                string maxsub = strings[0];

                for (int i = 1; i < strings.Length; i++)
                {
                    maxsub = LCS(maxsub, strings[i]);
                }

                return maxsub;
            }

            return null;
        }

        public static int LevenshteinDistance(string source, string target)
        {
            if (string.IsNullOrEmpty(source))
            {
                if (string.IsNullOrEmpty(target))
                    return 0;
                return target.Length;
            }
            if (string.IsNullOrEmpty(target))
                return source.Length;

            if (source.Length > target.Length)
            {
                var temp = target;
                target = source;
                source = temp;
            }

            var m = target.Length;
            var n = source.Length;
            var distance = new int[2, m + 1];
            // Initialize the distance 'matrix'
            for (var j = 1; j <= m; j++)
                distance[0, j] = j;

            var currentRow = 0;
            for (var i = 1; i <= n; ++i)
            {
                currentRow = i & 1;
                distance[currentRow, 0] = i;
                var previousRow = currentRow ^ 1;
                for (var j = 1; j <= m; j++)
                {
                    var cost = (target[j - 1] == source[i - 1] ? 0 : 1);
                    distance[currentRow, j] = Math.Min
                            (
                                    Math.Min
                                    (
                                                    distance[previousRow, j] + 1,
                                                    distance[currentRow, j - 1] + 1
                                    ),
                                    distance[previousRow, j - 1] + cost
                            );
                }
            }
            return distance[currentRow, m];
        }
        public static decimal LevenshteinDistancePercent(string str1, string str2)
        {
            int maxLenth = Math.Max(str1.Length, str2.Length);
            int val = LevenshteinDistance(str1, str2);
            return 1 - (decimal)val / maxLenth;
        }
    }
}
