using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ChineseT2S
{
    public static class T2SUtility
    {

        /// <summary>
        /// 查表去掉异体字
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private static string RemoveVariant(string source)
        {
            string res = source;

            try
            {
                string[] pairs = Properties.Resources.v2t.Split('|');
                Dictionary<string, string> changepairs = new Dictionary<string, string>();
                foreach (var p in pairs)
                {
                    string[] pair = p.Split(',');
                    if (!changepairs.ContainsKey(pair[1]))
                    {
                        changepairs[pair[1]] = pair[0];
                    }
                }
                StringBuilder tmp = new StringBuilder(res.Length);
                foreach (var c in res)
                {
                    if (changepairs.ContainsKey(c.ToString())) tmp.Append( changepairs[c.ToString()]);
                    else tmp.Append(c);
                }
                res = tmp.ToString();
            }
            catch(Exception e)
            {
                throw new Exception(string.Format("异体字转换繁体字时失败:{0}",e.Message));
            }

            return res;
        }

        /// <summary>
        /// 查表去掉繁体字
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private static string RemoveTraditional(string source)
        {
            string res = source;

            try
            {
                string[] pairs = Properties.Resources.s2t.Split('|');
                Dictionary<string, string> changepairs = new Dictionary<string, string>();
                foreach (var p in pairs)
                {
                    string[] pair = p.Split(',');
                    if (!changepairs.ContainsKey(pair[1]))
                    {
                        changepairs[pair[1]] = pair[0];
                    }
                }
                StringBuilder tmp = new StringBuilder(res.Length);
                foreach (var c in res)
                {
                    if (changepairs.ContainsKey(c.ToString())) tmp.Append( changepairs[c.ToString()]);
                    else tmp.Append( c);
                }
                res = tmp.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("查表转换繁体字时失败:{0}", e.Message));
            }

            return res;
        }

        /// <summary>
        /// 转为简体
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToSimplified(string source)
        {
            try
            {
                // 先用VB方法转成简体
                string res = Microsoft.VisualBasic.Strings.StrConv(source, VbStrConv.SimplifiedChinese, 0);

                // 将异体字转化为简体字
                res = RemoveVariant(res);

                // 再用查表的方法去除未被转化的繁体字
                res = RemoveTraditional(res);

                return res;
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("转换失败:{0}", e.Message));
            }       
        }

        /// <summary>
        /// 转为繁体
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToTraditional(string source)
        {
            string target = Microsoft.VisualBasic.Strings.StrConv(source, VbStrConv.TraditionalChinese, 0);
            return target;
        }
    }
}
