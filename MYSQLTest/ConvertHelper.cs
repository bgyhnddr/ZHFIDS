using System;
using System.Data;

namespace MYSQLTest
{
    ///<summary>
    /// 转换实用类
    ///</summary>
    public class ConvertHelper
    {


        #region WrapWithSpecificString

        /// <summary>
        /// 用字符with包住source
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="with">要使用的字符</param>
        /// <returns></returns>
        public static string WrapWithSpecificString(string source, char with)
        {
            return WrapWithSpecificString(source, with.ToString());
        }

        /// <summary>
        /// 用字符串with包住source
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="with">要使用的字符串</param>
        /// <returns>with + source + with</returns>
        public static string WrapWithSpecificString(string source, string with)
        {
            return with + source + with;
        }

        #endregion

        #region Time period

        /// <summary>
        /// 时间段
        /// </summary>
        /// <returns></returns>
        public static string TimePeriod()
        {
            /*
            1：00—5：00凌晨
            5：00—8：00早上
            8：00—11：00上午
            11：00—13：00中午
            13：00—17：00下午
            17：00—19：00晚上
            19：00—20：00半夜
            20：00—24：00深夜
          */
            return string.Empty;
        }

        #endregion
    }
}