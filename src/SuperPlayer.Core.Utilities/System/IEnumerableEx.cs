using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class IEnumerableEx
    {
        private class _Temp<T>
        {
            public T Item
            {
                get;
            }
            public string CompareKey
            {
                get;
            }
            public string IdentityKey
            {
                get;
            }

            public _Temp(T item, string idkey, string comkey)
            {
                this.Item = item;
                this.IdentityKey = idkey;
                this.CompareKey = comkey;
            }
        }

        private class _TempGroup<T>
        {
            public _Temp<T> Temp1 { get; set; }
            public _Temp<T> Temp2 { get; set; }
            public decimal Percent { get; set; }
        }

        private static decimal GetDistancePercent(string str1, string str2)
        {
            decimal percent = Math.Round(StringCompair.LevenshteinDistancePercent(str1, str2), 6, MidpointRounding.AwayFromZero);
            return percent;
        }
        public static List<List<TSource>> FuzzyGrouping<TSource>(this IEnumerable<TSource> source, Func<TSource, string> keyselector, Func<TSource, string> groupkeyselector, decimal coefficient)
        {
            if (keyselector == null)
            {
                throw new ArgumentNullException(nameof(keyselector));
            }

            if (groupkeyselector == null)
            {
                throw new ArgumentNullException(nameof(groupkeyselector));
            }

            if (coefficient > 1
                || coefficient < 0)
            {
                throw new ArgumentException(nameof(coefficient));
            }


            ICollection<TSource> sourcecollection = source as ICollection<TSource>;
            List<_Temp<TSource>> sourcewrapper = null;

            if (sourcecollection != null)
            {
                sourcewrapper = new List<_Temp<TSource>>(sourcecollection.Count);

                foreach (var item in sourcecollection)
                {
                    sourcewrapper.Add(new _Temp<TSource>
                         (
                                 item,
                                 keyselector(item),
                                 groupkeyselector(item)
                         ));
                }
            }
            else
            {
                sourcewrapper = source
                    .Select(_p => new _Temp<TSource>(_p, keyselector(_p), groupkeyselector(_p)))
                     .ToList();
            }

            List<_Temp<TSource>> singleitems = new List<_Temp<TSource>>();

            //取符合条件的元组
            List<_TempGroup<TSource>> effectivegroup = new List<_TempGroup<TSource>>();
            Parallel.For(0, sourcewrapper.Count, index =>
            {
                var outer = sourcewrapper[index];

                bool flag = false;
                for (int j = 0; j < sourcewrapper.Count; j++)
                {
                    if (index == j)
                    {
                        continue;
                    }

                    var inner = sourcewrapper[j];

                    decimal percent = GetDistancePercent(outer.CompareKey, inner.CompareKey);
                    if (percent >= coefficient)
                    {
                        var groupitem = new _TempGroup<TSource>
                        {
                            Temp1 = outer,
                            Temp2 = inner,
                            Percent = percent
                        };

                        lock (effectivegroup)
                        {
                            effectivegroup.Add(groupitem);
                        }

                        flag = true;
                    }
                }

                if (!flag)
                {
                    lock (singleitems)
                    {
                        singleitems.Add(outer);
                    }
                }
            });

            //倒序排列元组，依次循环确保最相似的最先分组
            //若一项已被分组，则另一项带过去（或者判断与组的每一项满足条件）
            Dictionary<_Temp<TSource>, int> indexvalues = new Dictionary<_Temp<TSource>, int>();
            List<List<_Temp<TSource>>> groups = new List<List<_Temp<TSource>>>();
            var ordedeffectivegroup = effectivegroup.OrderByDescending(_p => _p.Percent).ToList();
            for (int i = 0; i < ordedeffectivegroup.Count; i++)
            {
                var item = ordedeffectivegroup[i];

                int index1 = 0, index2 = 0;

                if (!indexvalues.TryGetValue(item.Temp1, out index1)
                    && !indexvalues.TryGetValue(item.Temp2, out index2))
                {
                    List<_Temp<TSource>> newgroup = new List<_Temp<TSource>>()
                    {
                        item.Temp1,
                        item.Temp2
                    };

                    groups.Add(newgroup);

                    int index = groups.Count - 1;
                    indexvalues.Add(item.Temp1, index);
                    indexvalues.Add(item.Temp2, index);
                }
                else if (indexvalues.TryGetValue(item.Temp1, out index1)
                    && !indexvalues.TryGetValue(item.Temp2, out index2))
                {
                    List<_Temp<TSource>> exgroup = groups[index1];

                    exgroup.Add(item.Temp2);
                    indexvalues.Add(item.Temp2, index1);

                    ////若Temp2 和所有相似都满足
                    //if (exgroup.All(_p => GetDistancePercent(_p.CompareKey, item.Temp2.CompareKey) >= coefficient))
                    //{
                    //    exgroup.Add(item.Temp2);
                    //}
                    //else
                    //{
                    //    singleitems.Add(item.Temp2);
                    //}
                    //indexvalues.Add(item.Temp2, index1);
                }
                else if (!indexvalues.TryGetValue(item.Temp1, out index1)
                    && indexvalues.TryGetValue(item.Temp2, out index2))
                {
                    List<_Temp<TSource>> exgroup = groups[index2];

                    exgroup.Add(item.Temp1);
                    indexvalues.Add(item.Temp1, index2);

                    ////若Temp2 和所有相似都满足
                    //if (exgroup.All(_p => GetDistancePercent(_p.CompareKey, item.Temp1.CompareKey) >= coefficient))
                    //{
                    //    exgroup.Add(item.Temp1);
                    //}
                    //else
                    //{
                    //    singleitems.Add(item.Temp1);
                    //}
                    //indexvalues.Add(item.Temp1, index2);
                }
            }

            List<List<TSource>> finalgroups = groups
                .Select(_p => _p.Select(__p => __p.Item).ToList())
                .ToList();

            List<List<TSource>> singlegroups = singleitems
                .Select(_p => new List<TSource>(1) { _p.Item })
                .ToList();

            finalgroups.AddRange(singlegroups);

            //for (int i = 0; i < groups.Count; i++)
            //{
            //    var group = groups[i];

            //    for (int j = 0; j < group.Count; j++)
            //    {

            //        for (int k = 0; k < group.Count; k++)
            //        {
            //            if (j == k)
            //            {
            //                continue;
            //            }
            //            var outer = group[j];
            //            var inner = group[k];

            //            decimal value = GetDistancePercent(outer.CompareKey, inner.CompareKey);

            //            if (value < coefficient)
            //            {

            //            }
            //        }
            //    }
            //}

            return finalgroups;
        }

    }
}
