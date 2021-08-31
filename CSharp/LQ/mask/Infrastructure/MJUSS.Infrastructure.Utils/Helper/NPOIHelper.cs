using MJUSS.Infrastructure.Core.CustomAttributes;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.Helper
{
    /// <summary>
    /// NPOIHelper助手类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NPOIHelper<T> where T : class, new()
    {
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="lists">数据</param        
        public async Task<byte[]> ExportExcel(List<T> lists)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            HSSFSheet sheet = workbook.CreateSheet() as HSSFSheet;
            HSSFRow headerRow = sheet.CreateRow(0) as HSSFRow;

            var headerCellStyle = workbook.CreateCellStyle();
            var font = workbook.CreateFont();
            font.Boldweight = (short)FontBoldWeight.Bold;
            headerCellStyle.SetFont(font);

            bool isHeader = false;
            int rowIndex = 1;
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            foreach (T item in lists)
            {
                HSSFRow dataRow = sheet.CreateRow(rowIndex) as HSSFRow;
                int colIndex = 0;
                foreach (PropertyInfo column in properties)
                {
                    var headerAttribute = column.GetCustomAttributes<ExcelHeaderNameAttribute>(false).FirstOrDefault();
                    if (headerAttribute == null)
                    {
                        throw new Exception("请设置导出对象属性上的ExcelHeaderNameAttribute特性。");
                    }
                    if (!isHeader)
                    {
                        var cellHeader = headerRow.CreateCell(colIndex);
                        cellHeader.SetCellValue(headerAttribute.ColumnHeaderName);
                        cellHeader.CellStyle = headerCellStyle;
                        //dataRow.CreateCell(colIndex).SetCellValue(column.GetValue(item, null) == null ? "" : column.GetValue(item, null).ToString());
                    }
                    var isNumbericType = column.GetCustomAttributes<ExcelCellIsNumbericTypeAttribute>(false).FirstOrDefault();
                    //if (column.PropertyType == typeof(int) || column.PropertyType == typeof(decimal))
                    if (isNumbericType != null) //如果是数字字段
                    {
                        double _cellValue = 0;
                        if (column.GetValue(item, null) != null)
                        {
                            double.TryParse(column.GetValue(item, null).ToString(), out _cellValue);
                        }
                        dataRow.CreateCell(colIndex).SetCellValue(_cellValue);
                    }
                    else
                    {
                        dataRow.CreateCell(colIndex).SetCellValue(column.GetValue(item, null) == null ? "" : column.GetValue(item, null).ToString());
                    }
                    colIndex++;
                }
                isHeader = true;
                rowIndex++;
            }
            workbook.Write(ms);
            await ms.FlushAsync();
            ms.Position = 0;
            sheet = null;
            headerRow = null;
            workbook = null;
            return ms.ToArray();
            //FileStream fs = new FileStream(saveFilePath, FileMode.Create, FileAccess.Write);
            //byte[] data = ms.ToArray();
            //await fs.WriteAsync(data, 0, data.Length);
            //fs.Flush();
            //fs.Close();
            //data = null;
            //ms = null;
            //fs = null;
        }
        /// <summary>
        /// 导入Excel
        /// </summary>
        /// <param name="lists">数据</param>
        /// <param name="filePath">Excel所在路径</param>
        /// <returns></returns>
        public List<T> ImportExcel(string filePath)
        {
            IWorkbook workbook = null;
            List<T> lists = new List<T>();
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                if (filePath.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(file);
                else if (filePath.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(file);
            }
            ISheet sheet = workbook.GetSheetAt(0);
            IEnumerator rows = sheet.GetRowEnumerator();
            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;
            Type type = typeof(T);
            PropertyInfo[] properties;
            T t = default(T);
            for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                t = Activator.CreateInstance<T>();
                properties = t.GetType().GetProperties();
                foreach (PropertyInfo column in properties)
                {
                    var headerAttribute = column.GetCustomAttributes<ExcelHeaderNameAttribute>(false).FirstOrDefault();
                    if (headerAttribute == null)
                    {
                        throw new Exception("请设置导出对象属性上的ExcelHeaderNameAttribute特性。");
                    }
                    int j = headerRow.Cells.FindIndex(delegate (ICell c)
                    {
                        return c.StringCellValue == headerAttribute.ColumnHeaderName;
                    });
                    if (j >= 0 && row.GetCell(j) != null)
                    {
                        object value = valueType(column.PropertyType, row.GetCell(j).ToString());
                        column.SetValue(t, value, null);
                    }
                }
                lists.Add(t);
            }
            return lists;
        }

        /// <summary>
        /// 导入Excel
        /// </summary>
        /// <param name="importData"></param>
        /// <returns></returns>
        public List<T> ImportExcel(byte[] importData)
        {
            IWorkbook workbook = null;
            ISheet sheet = null;
            var lists = new List<T>();
            var stream = new MemoryStream(importData);
            try
            {
                workbook = new HSSFWorkbook(stream);
            }
            catch
            {
                workbook = new XSSFWorkbook(stream);                
            }
            sheet = workbook.GetSheetAt(0);
            IEnumerator rows = sheet.GetRowEnumerator();
            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;
            Type type = typeof(T);
            PropertyInfo[] properties;
            T t = default(T);
            for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
            {
                try
                {
                    IRow row = sheet.GetRow(i);
                    t = Activator.CreateInstance<T>();
                    properties = t.GetType().GetProperties();
                    foreach (PropertyInfo column in properties)
                    {
                        var headerAttribute = column.GetCustomAttributes<ExcelHeaderNameAttribute>(false).FirstOrDefault();
                        if (headerAttribute == null)
                        {
                            throw new Exception("请设置导出对象属性上的ExcelHeaderNameAttribute特性。");
                        }
                        int j = headerRow.Cells.FindIndex(delegate (ICell c)
                        {
                            return c.StringCellValue == headerAttribute.ColumnHeaderName;
                        });
                        if (j >= 0 && row.GetCell(j) != null)
                        {
                            object value = valueType(column.PropertyType, row.GetCell(j).ToString());
                            column.SetValue(t, value, null);
                        }
                    }
                    lists.Add(t);
                }
                catch
                { }
            }
            return lists;
        }
        object valueType(Type t, string value)
        {
            object o = null;
            string strt = "String";
            if (t.Name == "Nullable`1")
            {
                strt = t.GetGenericArguments()[0].Name;
            }
            switch (strt)
            {
                case "Decimal":
                    o = decimal.Parse(value);
                    break;
                case "Int":
                    o = int.Parse(value);
                    break;
                case "Float":
                    o = float.Parse(value);
                    break;
                case "DateTime":
                    o = DateTime.Parse(value);
                    break;
                default:
                    o = value;
                    break;
            }
            return o;
        }

    }
}
