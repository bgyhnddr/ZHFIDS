using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace MYSQLTest
{
    /*
     CSV即Comma Separate Values，这种文件格式经常用来作为不同程序之间的数据交互的格式。
     最终文件可以用电子表格程序（如 Microsoft Excel）打开，也可以用作其他程序的导入格式。
     CSV文件格式

    ·每条记录占一行 （但字段中有换行符的情况，一行也会变成多行）
    ·以逗号为分隔符
    ·逗号前后的空格会被忽略
    ·字段中包含有逗号，该字段必须用双引号括起来
    ·字段中包含有换行符，该字段必须用双引号括起来
    ·字段前后包含有空格，该字段必须用双引号括起来
    ·字段中的双引号用两个双引号表示
    ·字段中如果有双引号，该字段必须用双引号括起来
    ·第一条记录，可以是字段名
     PS 在Excel中打开文件，字段已0开头的内容，会自动去掉前面的0。加上等号就能正常显示。（="00001"），但是记住只限于用excel看哦，数据导入的话是不能有等号的
    */
    /// <summary>
    /// CSV实用工具类
    /// </summary>
    public class CSVHelper
    {
        /// <summary>
        /// 读取CSV格式文件
        /// </summary>
        /// <param name="file">文件路径</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>结果列表</returns>
        public static List<List<string>> ReadCSV(string file, string encoding = "GB2312")
        {
            using (var sr = new StreamReader(new FileStream(file, FileMode.Open, FileAccess.Read),
                                         Encoding.GetEncoding(encoding)))
            {
                return ReadCSV(sr);
            }
        }

        public static List<List<string>> ReadCSV(string file, Encoding encoding)
        {
            using (var sr = new StreamReader(new FileStream(file, FileMode.Open, FileAccess.Read),
                                         encoding))
            {
                return ReadCSV(sr);
            }
        }
        /// <summary>
        /// 读取CSV格式文件
        /// </summary>
        /// <param name="file">文件路径</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>结果列表</returns>
        public static DataTable ReadCSVToTable(string file, string encoding = "GB2312", bool isEmpty = false)
        {
            var temp = ReadCSV(file, encoding);

            var table = ReadListToTable(temp, isEmpty);
            return table;
        }

        /// <summary>
        /// 读取CSV格式文件
        /// </summary>
        /// <param name="file">文件路径</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>结果列表</returns>
        public static DataTable ReadCSVToTable(string file, Encoding encoding, bool isEmpty = false)
        {
            var temp = ReadCSV(file, encoding);

            var table = ReadListToTable(temp, isEmpty);
            return table;
        }

        public static DataTable ReadListToTable(List<List<string>> list, bool isEmpty = false)
        {
            var table = new DataTable();
            for (var i = 0; i < list[0].Count; i++)
            {
                table.Columns.Add(list[0][i].ToString(), typeof(string));
            }

            if (isEmpty)
            {
                return table;
            }
            for (var i = 1; i < list.Count; i++)
            {
                var row = table.NewRow();

                for (var j = 0; j < table.Columns.Count; j++)
                {
                    row[j] = list[i][j];
                }
                table.Rows.Add(row);
            }
            return table;
        }

        /// <summary>
        /// 读取CSV格式文件
        /// </summary>
        /// <param name="streamReader">读取流对象</param>
        /// <returns>结果列表</returns>
        public static List<List<string>> ReadCSV(StreamReader streamReader)
        {
            string text = streamReader.ReadToEnd();

            var result = new List<List<string>>();
            var line = new List<string>();
            var field = new StringBuilder();

            //是否在双引号内
            bool inQuata = false;

            //字段是否开始
            bool fieldStart = true;

            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];

                if (inQuata)
                {
                    //如果已经处于双引号范围内
                    if (ch == '\"')
                    {
                        //如果是两个引号，则当成一个普通的引号处理
                        if (i < text.Length - 1 && text[i + 1] == '\"')
                        {
                            field.Append('\"');
                            i++;
                        }
                        else
                            //否则退出引号范围
                            inQuata = false;
                    }
                    else //双引号范围内的任何字符（除了双引号）都当成普通字符
                    {
                        field.Append(ch);
                    }
                }
                else
                {
                    switch (ch)
                    {
                        case ',': //新的字段开始
                            line.Add(field.ToString());
                            field.Remove(0, field.Length);
                            fieldStart = true;
                            break;
                        case '\"': //引号的处理
                            if (fieldStart)
                            {
                                inQuata = true;
                            }
                            else
                            {
                                field.Append(ch);
                            }
                            break;
                        case '\r': //新的记录行开始
                            if (field.Length > 0 || fieldStart)
                            {
                                line.Add(field.ToString());
                                field.Remove(0, field.Length);
                            }
                            result.Add(line);
                            line = new List<string>();
                            fieldStart = true;
                            //在 window 环境下，\r\n通常是成对出现，所以要跳过
                            if (i < text.Length - 1 && text[i + 1] == '\n')
                            {
                                i++;
                            }
                            break;
                        default:
                            fieldStart = false;
                            field.Append(ch);
                            break;
                    }
                }
            }
            //文件结束
            if (field.Length > 0 || fieldStart)
            {
                line.Add(field.ToString());
            }
            if (result.Count > 0)
            {
                //列数相等，
                if (line.Count == result[0].Count)
                {
                    result.Add(line);
                }
            }
            else
            {
                if (line.Count > 0)
                {
                    result.Add(line);
                }
            }
            return result;
        }

        /// <summary>
        /// 将字符串转成CSV列表
        /// </summary>
        /// <param name="text">字符串</param>
        /// <returns>table</returns>
        public static List<List<string>> ReadCSV(string text)
        {
            var result = new List<List<string>>();
            var line = new List<string>();
            var field = new StringBuilder();

            //是否在双引号内
            bool inQuata = false;

            //字段是否开始
            bool fieldStart = true;

            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];

                if (inQuata)
                {
                    //如果已经处于双引号范围内
                    if (ch == '\"')
                    {
                        //如果是两个引号，则当成一个普通的引号处理
                        if (i < text.Length - 1 && text[i + 1] == '\"')
                        {
                            field.Append('\"');
                            i++;
                        }
                        else
                            //否则退出引号范围
                            inQuata = false;
                    }
                    else //双引号范围内的任何字符（除了双引号）都当成普通字符
                    {
                        field.Append(ch);
                    }
                }
                else
                {
                    switch (ch)
                    {
                        case ',': //新的字段开始
                            line.Add(field.ToString());
                            field.Remove(0, field.Length);
                            fieldStart = true;
                            break;
                        case '\"': //引号的处理
                            if (fieldStart)
                            {
                                inQuata = true;
                            }
                            else
                            {
                                field.Append(ch);
                            }
                            break;
                        case '\r': //新的记录行开始
                            if (field.Length > 0 || fieldStart)
                            {
                                line.Add(field.ToString());
                                field.Remove(0, field.Length);
                            }
                            result.Add(line);
                            line = new List<string>();
                            fieldStart = true;
                            //在 window 环境下，\r\n通常是成对出现，所以要跳过
                            if (i < text.Length - 1 && text[i + 1] == '\n')
                            {
                                i++;
                            }
                            break;
                        default:
                            fieldStart = false;
                            field.Append(ch);
                            break;
                    }
                }
            }
            //文件结束
            if (field.Length > 0 || fieldStart)
            {
                line.Add(field.ToString());
            }
            if (result.Count > 0)
            {
                //列数相等，
                if (line.Count == result[0].Count)
                {
                    result.Add(line);
                }
            }
            else
            {
                if (line.Count > 0)
                {
                    result.Add(line);
                }
            }
            return result;
        }

        public static DataTable ReadTable(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                var list = ReadCSV(text);
                return ReadListToTable(list);
            }
            return new DataTable();

        }

        /// <summary>
        /// 读取CSV格式文件
        /// </summary>
        /// <param name="bytes">字节数据</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>结果列表</returns>
        public static List<List<string>> ReadCSV(byte[] bytes, string encoding = "GB2312")
        {
            return ReadCSV(new StreamReader(new MemoryStream(bytes), Encoding.GetEncoding(encoding)));
        }

        /// <summary>
        /// 将DataTable生成CSV格式字串
        /// </summary>
        /// <param name="dataTable">源数据表</param>
        /// <param name="needHead">需要标题</param>
        /// <returns>CSV格式字串</returns>
        public static string MakeCSV(DataTable dataTable,bool needHead=true)
        {
            var data = new StringBuilder();

            if (needHead)
            {
                #region 写出列名

                foreach (DataColumn column in dataTable.Columns)
                {
                    data.Append(ConvertHelper.WrapWithSpecificString(column.ColumnName, "\"")).Append(",");
                }

                //去掉多余的“,”
                data.Remove(data.Length - 1, 1);
                //换行
                data.Append("\r\n");

                #endregion
            }

            #region 写出数据

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    //一律使用“"”包裹住内容，
                    data.Append(ConvertHelper.WrapWithSpecificString(row[column].ToString().Replace("\"","\"\""), "\"")).Append(",");
                }
                //去掉多余的“,”
                data.Remove(data.Length - 1, 1);
                //换行
                data.Append("\r\n");
            }

            #endregion

            //OK
            return data.ToString().TrimEnd('\r','\n');
        }
    }
}
