using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Configuration;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Windows.Forms;

namespace ZhinengChaoBiao
{
    public class NPOIExcelHelper
    {
        #region 私有方法
        private static DataTable GetData(DataGridView Dgv,bool forText)
        {
            DataTable dt = new DataTable();
            List<string> cols = Columns(Dgv);
            for (int i = 0; i < cols.Count; i++)
            {
                dt.Columns.Add(Dgv.Columns[cols[i]].HeaderText);
            }
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                if (row.Visible)
                {
                    DataRow dtRow = dt.NewRow();
                    for (int i = 0; i < cols.Count; i++)
                    {
                        dtRow[i] = forText ? row.Cells[cols[i]].FormattedValue : row.Cells[cols[i]].Value;
                    }
                    dt.Rows.Add(dtRow);
                }
            }
            return dt;
        }

        private static List<string> Columns(DataGridView view)
        {
            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in view.Columns)
            {
                if (col.Visible) cols.Add(col);
            }
            List<string> ret = (from col in cols
                                where col.Visible
                                orderby col.DisplayIndex ascending
                                select col.Name).ToList();
            return ret;
        }
        /// <summary>
        /// 获取单元格类型(xls)
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static object GetValue(ICell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.Blank: //BLANK:
                    return null;
                case CellType.Boolean: //BOOLEAN:
                    return cell.BooleanCellValue;
                case CellType.Numeric: //NUMERIC:
                    //NPOI中数字和日期都是NUMERIC类型的，这里对其进行判断是否是日期类型
                    if (HSSFDateUtil.IsCellDateFormatted(cell))
                    {
                        return cell.DateCellValue; //日期类型
                    }
                    return cell.NumericCellValue;
                case CellType.String: //STRING:
                    return cell.StringCellValue;
                case CellType.Error: //ERROR:
                    return cell.ErrorCellValue;
                case CellType.Formula: //FORMULA:
                default:
                    return "=" + cell.CellFormula;
            }
        }
        #endregion

        #region 公共方法
        /// <summary>读取excel
        /// 默认第一行为表头
        /// </summary>
        /// <param name="strFileName">excel文档路径</param>
        /// <returns></returns>
        public static DataTable Import(string strFileName)
        {
            DataTable dt = new DataTable();
            string fileType = Path.GetExtension(strFileName.ToLower()).Trim();
            using (FileStream fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                IWorkbook hssfworkbook = WorkbookFactory.Create(fs);
                ISheet sheet = hssfworkbook.GetSheetAt(0);
                //表头
                IRow header = sheet.GetRow(sheet.FirstRowNum);
                List<int> columns = new List<int>();
                for (int i = 0; i < header.LastCellNum; i++)
                {
                    object obj = GetValue(header.GetCell(i));
                    if (obj == null || obj.ToString() == string.Empty)
                    {
                        dt.Columns.Add(new DataColumn(i.ToString(), typeof(string)));
                        //continue;
                    }
                    else
                    {
                        dt.Columns.Add(new DataColumn(obj.ToString()));
                    }
                    columns.Add(i);
                }
                //数据
                for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                {
                    IRow r = sheet.GetRow(i);
                    try
                    {
                        if (r != null)
                        {
                            DataRow dr = dt.NewRow();
                            bool hasValue = false;
                            foreach (int j in columns)
                            {
                                dr[j] = GetValue(r.GetCell(j));
                                if (dr[j] != null && dr[j].ToString() != string.Empty)
                                {
                                    hasValue = true;
                                }
                            }
                            if (hasValue)
                            {
                                dt.Rows.Add(dr);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string err = string.Format("数据读出出错:{0} 行号:{1}", ex.Message, i + 1);
                        throw new Exception(err, ex);
                    }
                }
            }
            return dt;
        }
        /// <summary>
        /// 将数据从datatable导出到文件中
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fileName"></param>
        public static void Export(DataTable dt, string fileName)
        {
            string fileType = Path.GetExtension(fileName.ToLower()).Trim();
            IWorkbook wb = null;
            if (fileType == ".xls")
            {
                wb = new HSSFWorkbook();
            }
            else
            {
                wb = new XSSFWorkbook();
            }
            ISheet sheet = wb.CreateSheet("Sheet1");
            sheet.DefaultColumnWidth = 15;
            //表头
            IRow row = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = row.CreateCell(i);
                cell.SetCellValue(dt.Columns[i].ColumnName);
            }

            //数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row1 = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row1.CreateCell(j);
                    object obj = dt.Rows[i][j];
                    if (obj != null)
                    {
                        if ((obj is int) || (obj is decimal) || (obj is long) || (obj is short) || (obj is byte) || (obj is double) || (obj is Single))
                        {
                            cell.SetCellValue((double)obj);
                        }
                        else
                        {
                            cell.SetCellValue(obj.ToString());
                        }
                    }
                }
            }

            //转为字节数组
            MemoryStream stream = new MemoryStream();
            wb.Write(stream);
            var buf = stream.ToArray();
            //保存为Excel文件
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                fs.Write(buf, 0, buf.Length);
                fs.Flush();
            }
        }
        /// <summary>
        /// DataGridView导出到Excel文件
        /// </summary>
        /// <param name="dtSource">源DataTGridview</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="fileName">保存位置</param>
        /// <param name="forText">导出内容是网络控件的显示字符还是内部值，为真导出显示字符串，否则导出值</param>
        public static void Export(DataGridView myDgv, string fileName,bool forText=false)
        {
            DataTable dt = GetData(myDgv,forText );
            Export(dt, fileName);
        }
        #endregion
    }
}
