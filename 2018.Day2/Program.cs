using Shared;
using System;
using System.Diagnostics;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new[] { "kqzxdenujwcsthbzgvyioflcsp",
                                "vqwxdenujwcsthbmggyioflarp",
                                "kqzxienujwcsthbmglyioclarp",
                                "kuzxdetujwcsthbmgvyioflcrp",
                                "kqnxdenujwcsthbmgvlooflarp",
                                "kqzxdknpjwcsthwmgvyioflarp",
                                "kgzxdenujwcsthbfgvyicflarp",
                                "kqzxdenujrnsthbmgjyioflarp",
                                "lqzxdeeujwcsthbmrvyioflarp",
                                "iqfxdenujwcsthbmgvyiofyarp",
                                "kvzxbenujwcstabmgvyioflarp",
                                "kmzxdenujwcsthbmglyioolarp",
                                "kqzxdenujhcsthbmgbyioflanp",
                                "nqzxdenujwcsehbmgvsioflarp",
                                "kqzlgenujwcsthbmgvyiofjarp",
                                "kqzxdyfujwcsihbmgvyioflarp",
                                "kqzxdsnujwcqthbmgvyiorlarp",
                                "kqzxdenuywcsthbmgvyinflmrp",
                                "knzxderujwcsthbmgvyioflaop",
                                "kqxxdenujwczthbmgvyioflajp",
                                "kqzxdevujwcsthbmgvyqoxlarp",
                                "kqzxdenujwclmhbmgvyioslarp",
                                "kqzldenujwcsthbmgvnisflarp",
                                "kjtxdenujwcsthbmgvyfoflarp",
                                "kqzxwenujwcstxbmgvyihflarp",
                                "kqzxdenuhecsthbmgvyeoflarp",
                                "kqzxdenhjwesthbmgvyioklarp",
                                "kqkxdenujwcsthbcgvyiofgarp",
                                "kqyxmenujwcsthbmgvyioflara",
                                "kqzxdqnrjwcwthbmgvyioflarp",
                                "kqzxdenufwcgyhbmgvyioflarp",
                                "lqzxdenujwcsthbmtvyiofearp",
                                "kqzxdenujwcsthbvgvthoflarp",
                                "kqzxeenujwcsahbmgvyioflamp",
                                "pqzxdenujwcsshbmjvyioflarp",
                                "kqzxdesujwcstdbmgvyioflatp",
                                "kqzxpenujwcsthimgvyioflhrp",
                                "kqzxdmkujwcsthbmgvpioflarp",
                                "kszxdenujwcsthbybvyioflarp",
                                "kqzxdvnujwcsthbmgvyqoslarp",
                                "kkzxdetujwcsthbmgvyiofltrp",
                                "kqzxdenujwcsthomgvyiozlaro",
                                "cqzfdenubwcsthbmgvyioflarp",
                                "kqzxdenyjwcsthbmhvyiofldrp",
                                "kqzxdenujwcsthbmghfiofxarp",
                                "kmqxdebujwcsthbmgvyioflarp",
                                "kqzxdenufwcsthbmvvypoflarp",
                                "kqnxdenujwcsthbmgvtzoflarp",
                                "bqzxdenujwcithbmgvyiohlarp",
                                "kqzxdenurwrsthbmgvyioelarp",
                                "kqzxdenujwcsthbmgpyiodlarl",
                                "kqzxdengjwcxthbmgvjioflarp",
                                "kizxdenujwcsnhqmgvyioflarp",
                                "jqzxdenajwcsthbmnvyioflarp",
                                "kqzcdenujwcsphbigvyioflarp",
                                "kezxdenujwcsthbfgvyioflaqp",
                                "kqzxdenujwcstybmgvyivfyarp",
                                "kqzxdenujwcsthbmgvbiofsnrp",
                                "kqzxdenujwcsthbmgvyhxfnarp",
                                "kvzxdenqjfcsthbmgvyioflarp",
                                "kqzxywnljwcsthbmgvyioflarp",
                                "kqzxdenujwcsbhbzgvyioxlarp",
                                "kqkxdenufwcsthbmgvyiofxarp",
                                "dqzxddnujwcsthsmgvyioflarp",
                                "yqrxdenujwcsthbagvyioflarp",
                                "kqzxdenujwcsajbmgvyiovlarp",
                                "kqztdunujwcsthbmgvyioilarp",
                                "kqzxdequjwcsthbmgvyyoflarm",
                                "kqzxdlnujwksthbmgvkioflarp",
                                "tqvxdenujwcsthbmgveioflarp",
                                "kqzndezupwcsthbmgvyioflarp",
                                "kqzctsnujwcsthbmgvyioflarp",
                                "kqzxdenujwmstkbmgvyioflgrp",
                                "kqzxdenujwzsthdmgvyiofdarp",
                                "kqzxdynujwcsthcmgvyioflasp",
                                "kqzxdesujwcstybmgcyioflarp",
                                "kqzxdenujwcsthbvgvyiyglarp",
                                "kqzxpenujwcsthbogvyioflard",
                                "khzxdenujwcsthbmgvyikflaep",
                                "kqzxdedujwchthbmgvyeoflarp",
                                "kxzxsepujwcsthbmgvyioflarp",
                                "xqzxdenujwcsthbpgvyioelarp",
                                "jfzxdenujwcsthbmgvyiollarp",
                                "kqzxcenujwcethbmgvwioflarp",
                                "kqzxdenujwcithbmgvysoflarg",
                                "kqlxdenujwnsthbmgvyiotlarp",
                                "wqzydenujwcsthbmgvyioftarp",
                                "kqzxienuwwcsthbmgayioflarp",
                                "kqzxdetujwcsthbmgvyhoflawp",
                                "kqzxdqnujwrsthbmgvyxoflarp",
                                "kqzxdenujwcvthbmgjiioflarp",
                                "kqzxdenujwcjthbxgvaioflarp",
                                "kqzxpenujwcsthymgvyioklarp",
                                "kqzxdenujwcsthbmswygoflarp",
                                "kqzxdenujwcsthbmgvyiaxiarp",
                                "kqzxdenudkcsthbmgvyzoflarp",
                                "kqzxdvndjwcsthbmgvyioflaxp",
                                "kqzxdenujwcsthbmdvymoflvrp",
                                "kqzxvenujwcsihbmgvyiofllrp",
                                "kqzxdqnujwcsthbmgtyioflprp",
                                "kqzxdenuuwcathbmgvsioflarp",
                                "kqzrdenujwesthbjgvyioflarp",
                                "kqzxdexujwcstzbmgvyyoflarp",
                                "kqzxpenujwjstabmgvyioflarp",
                                "kozxdenejwcsthbmgvpioflarp",
                                "kbzxdenvjwcsthbmgvyiofsarp",
                                "kolxdenujwcjthbmgvyioflarp",
                                "kqzxdenujwcsthbmgvyiffsakp",
                                "kqzxdelujwcsthbmlvyioflxrp",
                                "kqzxdenugwcsthrmgvyioflprp",
                                "kqzxdelujwcsthqmgvyiozlarp",
                                "kqzxienujwosthbmgvykoflarp",
                                "kqzxdeuujwicthbmgvyioflarp",
                                "kqzxdenbjwcsthbmcvyaoflarp",
                                "krzxdqnujwcsthbmgvyioflerp",
                                "wqzxzenujwcsthbmgvyioclarp",
                                "kqzxyenujwcsthbmgejioflarp",
                                "kqzxdenujwcstsbmgvtidflarp",
                                "kqnxdenejwcsthbmgvyioflara",
                                "kqzsdmnujwcsthbmgvyioflaep",
                                "kqzxdedujwnsthymgvyioflarp",
                                "kqzxdenujwusthbmgnyioflarx",
                                "kqzxlenujwcsthbmgayvoflarp",
                                "kqzxdenujwcsthbmgvyiofngrh",
                                "zqzxdenujwcsthbmgvyiofvxrp",
                                "kqzydenujwmsthbmgvyiuflarp",
                                "kqzxdenujkrsthbmdvyioflarp",
                                "kqzxdlnujocsthbmgvyiofaarp",
                                "kqzxdenujwcstybmgvyiofrwrd",
                                "kqzxdenupwksthbmgvyiofbarp",
                                "khzxdentjwcsthbmbvyioflarp",
                                "kqzxdenujwcuphbmgvyihflarp",
                                "kqzxdenhjwcgthbmgvyioflrrp",
                                "kqzxdenujwcsthbmgvyiofakhp",
                                "kqzxdenujwcstfkmgvyioflamp",
                                "kqzxdenujqcsthbmgvkiorlarp",
                                "kqzxdenujwcstvbmgvyioilasp",
                                "kqzxdxnujwcsthbpgayioflarp",
                                "kqzxdenupwysthbmgvyiofljrp",
                                "kqzxdenujwcdthbmgvymoflarv",
                                "kqnxdenujwcstvbmgvyixflarp",
                                "kqjxdenujwcsthbmgvyikflurp",
                                "kqsxdenulwcsthxmgvyioflarp",
                                "bqzxbenujwcsahbmgvyioflarp",
                                "vqzxdenujwcsthbmgvjzoflarp",
                                "kqzhfenujwcsthimgvyioflarp",
                                "eqzxdenujwcshhbmgnyioflarp",
                                "kqzxdenujucstubmgvyicflarp",
                                "kuzxdenuewcsthbmgvyiofuarp",
                                "kqzxdenulwcsthbmgpyigflarp",
                                "kqzxdebujwcsthbmgoyioflaro",
                                "kqzxdenujwcuthbmgucioflarp",
                                "kqzxdenujwcschpmgvyioflhrp",
                                "kqzxfenujwcsthbmjvrioflarp",
                                "kqzxdenujqcsthbmgvyndflarp",
                                "kqzxdgnbjwcsthbmgvywoflarp",
                                "kqzxdenujwcsthrmgtbioflarp",
                                "yqzxdenyjwcsthbmgvyioflarg",
                                "kqzxdenuxwxsthbmsvyioflarp",
                                "kqzxdenujwcsthbugqyvoflarp",
                                "qqzxdenujwcsahbmgoyioflarp",
                                "kqsxdenudwcsthbmguyioflarp",
                                "kqzxdenujwcstublgvyioflamp",
                                "kqzxdemujwtstqbmgvyioflarp",
                                "kqzxqvnajwcsthbmgvyioflarp",
                                "kqzxoennjwcstbbmgvyioflarp",
                                "kqzxfenujwcsthbmlvyioflwrp",
                                "kqzjdunujwcsthhmgvyioflarp",
                                "kqzxdenujwcqthbmgvyirfxarp",
                                "kqzxdengjwcsthbmgvyiowlgrp",
                                "kqgxdenujwcswhbmglyioflarp",
                                "mqzxdekuuwcsthbmgvyioflarp",
                                "kqzxdenujwdsthbmgbyiovlarp",
                                "krzxdenlhwcsthbmgvyioflarp",
                                "kqzxdenmjwcstqbmgvyioflanp",
                                "kqzxdenujwcmthbmgvtioflyrp",
                                "kqzxdenujwcsthbmgvaijflprp",
                                "kqzxdenuywysqhbmgvyioflarp",
                                "kqzxdenujwfsthbmgvyhoflark",
                                "nqzcdefujwcsthbmgvyioflarp",
                                "kqzxdenujrcsthgmgyyioflarp",
                                "kqzxdqnujwzsthbmgvyioftarp",
                                "kqzxdenujwcsthimgvyioolapp",
                                "kqzxdenupwcsthbmggyioflyrp",
                                "kqzxdjnujwcsthbvgvyioflarf",
                                "kqzxdtnujwasthbmgvyiofuarp",
                                "kqzxbensjzcsthbmgvyioflarp",
                                "kqzxdenujwcsphbmwiyioflarp",
                                "kqzgdenuowcsthbmgvyioflarh",
                                "kmzxdenujwasthbmgvtioflarp",
                                "kqzxdenujwcstybmgvyiofrard",
                                "vqzxdenejwcsthbmglyioflarp",
                                "kqhxdenujwcsmhbmgvyioflprp",
                                "kqzxdnnujwcsthzsgvyioflarp",
                                "kczxdenujwcsthbmgvyeoflaop",
                                "kqzxdenujwcsxhbmgvaioflaap",
                                "kqzxdenujwcsthbmgayiofnprp",
                                "kqzxdvnujwcsthbmgvyipjlarp",
                                "kqzxdenubwcskhbmgvyiofkarp",
                                "kqzxdenujwcsthbgggyigflarp",
                                "kqzxdenujncstabvgvyioflarp",
                                "kqzxdenujwcstqimqvyioflarp",
                                "kqzxeenujwcsdhbmgvyqoflarp",
                                "kcpxdenujwcsthbmgvyioilarp",
                                "kqwxuenujwcsthbmgvyiyflarp",
                                "kqzxdwnujwcstgbmgvyioplarp",
                                "kqzxdenuswcstvbmglyioflarp",
                                "kqzxdenujwcsthabgvyiwflarp",
                                "kqzxdpnujwcsthbmwvyiomlarp",
                                "kqzxdenujwcdthbmgvcioffarp",
                                "kqzxdenajwcsthbmtvyiofldrp",
                                "kqzbnenujwcshhbmgvyioflarp",
                                "kqzbdequiwcsthbmgvyioflarp",
                                "kqzxdenuswcsohbmgzyioflarp",
                                "kvzxdenujwcstdbmjvyioflarp",
                                "kqzxoenujwcqthbmpvyioflarp",
                                "kqzxhenujwcsthbmgoyiofoarp",
                                "klzxdenujwczthbmgvyioflanp",
                                "kqpxdenujwcsthbmgvyioflafz",
                                "kqkxdenujwcstxbngvyioflarp",
                                "kqzepenuxwcsthbmgvyioflarp",
                                "bqzxdenujmcithbmgvyioflarp",
                                "kdzxdjnujwcstnbmgvyioflarp",
                                "kszxdenujwcsthbmgeyiofrarp",
                                "kqzxdenijwcsthbmgvhiaflarp",
                                "kqzadenujwcbtxbmgvyioflarp",
                                "kqkxwenujwcsthbmgvyiowlarp",
                                "pqzddenujwcsthbmgvyboflarp",
                                "kqzxxenujwcsthbwgvyioflmrp",
                                "kqzxdjnujwcsthbmgvyipilarp",
                                "pqzxdenujwcsthbmgvyieflark",
                                "sqzxdenujtcsthbmgiyioflarp",
                                "kqzxdznujwcsthbmgvzioflajp",
                                "kqzxdrnujqcsthbmgvyiofvarp",
                                "gqzxdenujwcsthemgvlioflarp",
                                "kqzxdenujjcsthbmgvuiofljrp",
                                "kqzsdenujmcsthbmggyioflarp",
                                "kqzxienujwcsthbmgvaioflaip",
                                "kqzxdwnujwcstfkmgvyioflarp",
                                "kqzqdenujwcithbmzvyioflarp",
                                "kqzxdedpjwcsthbmgvyiofbarp",
                                "kqzxdeaujwcbtdbmgvyioflarp",
                                "kqzewenyjwcsthbmgvyioflarp",
                                "kqzxddnujwcsthbmgyyiofrarp",
                                "kqzxdtnujwcsthbmgvyiodlard",
                                "kqzxdefujwcsthbmgvyiffwarp",
                                "xczxdenujwcsthbmgvyooflarp",
                                "kuzxdenujucsthbmgvykoflarp",
                                "kqzxtenujwcwthbmgvyioplarp",
                                "kqzxdencllcsthbmgvyioflarp",
            };

            var checksum = input.Count(i => Two(i)) * input.Count(i => Three(i));
            IO.WriteLine(checksum.ToString());

            foreach (var a in input)
            {
                foreach (var b in input)
                {
                    if (DiffersByOne(a, b))
                    {
                        IO.WriteLine(a);
                        IO.WriteLine(b);
                    }
                }
            }
        }

        private static bool DiffersByOne(string a, string b)
        {
            Debug.Assert(a.Length == b.Length);
            var aChars = a.ToCharArray();
            var bChars = b.ToCharArray();
            bool diff = false;
            for (var i = 0; i < aChars.Length; ++i)
            {
                if (aChars[i] != bChars[i])
                {
                    if (diff)
                    {
                        return false;
                    }
                    else
                    {
                        diff = true;
                    }
                }
            }
            return diff;
        }

        private static bool Two(string s)
        {
            var letters = s.ToCharArray().GroupBy(c => c);
            foreach (var g in letters)
            {
                if (g.Count() == 2)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool Three(string s)
        {
            var letters = s.ToCharArray().GroupBy(c => c);
            foreach (var g in letters)
            {
                if (g.Count() == 3)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
