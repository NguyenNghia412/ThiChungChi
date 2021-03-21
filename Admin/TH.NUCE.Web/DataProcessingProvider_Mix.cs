using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TH.NUCE.Web
{
    /// <summary>
    /// Lớp DataProcessingProvider cung cấp các hàm tương tác với dữ liệu thô.
    /// </summary>
    public sealed partial class DataProcessingProvider
    {

        /// <summary>
        /// Sắp xếp lại dữ liệu của bảng theo phân cấp.
        /// </summary>
        /// <param name="categoryTable">Bảng cần phân cấp</param>
        /// <param name="nameIndex">Cột tên</param>
        /// <param name="levelIndex">Cột cấp</param>
        /// <returns>Bảng đã được phân cấp.</returns>
        public static DataTable ProcessDataTable(DataTable categoryTable, int nameIndex, int levelIndex)
        {
            if (categoryTable.Rows.Count > 0)
            {
                foreach (DataRow objRow in categoryTable.Rows)
                {
                    int i;
                    int intLevel;
                    string strLevelName;
                    strLevelName = objRow.ItemArray[nameIndex].ToString();
                    intLevel = int.Parse(objRow.ItemArray[levelIndex].ToString());
                    for (i = 1; i <= intLevel; i++)
                    {
                        if (i == intLevel)
                        {
                            strLevelName = "|---" + strLevelName;
                        }
                        else if (i == 1)
                        {
                            strLevelName = "--- " + strLevelName;
                        }
                        else
                        {
                            strLevelName = "----" + strLevelName;
                        }
                    }
                    objRow.BeginEdit();
                    objRow[nameIndex] = strLevelName;
                    objRow.AcceptChanges();
                    objRow.EndEdit();
                }
            }
            return categoryTable;
        }
        public static DataRow[] ProcessDataTable(DataRow[] categoryTable, int nameIndex, int levelIndex)
        {
            if (categoryTable.Length > 0)
            {
                foreach (DataRow objRow in categoryTable)
                {
                    int i;
                    int intLevel;
                    string strLevelName;
                    strLevelName = objRow.ItemArray[nameIndex].ToString();
                    intLevel = int.Parse(objRow.ItemArray[levelIndex].ToString());
                    for (i = 1; i <= intLevel; i++)
                    {
                        if (i == intLevel)
                        {
                            strLevelName = "|---" + strLevelName;
                        }
                        else if (i == 1)
                        {
                            strLevelName = "--- " + strLevelName;
                        }
                        else
                        {
                            strLevelName = "----" + strLevelName;
                        }
                    }
                    objRow.BeginEdit();
                    objRow[nameIndex] = strLevelName;
                    objRow.AcceptChanges();
                    objRow.EndEdit();
                }
            }
            return categoryTable;
        }

        /// <summary>
        /// Trả về giá trị lớn nhất trong một chuỗi int.
        /// </summary>
        /// <param name="valueArray">Chuỗi int cần so sánh.</param>
        /// <returns>Giá trị lớn nhất.</returns>
        public static int GetMaxIntValue(int[] valueArray)
        {
            int maxValue = 0;
            int i;
            if (valueArray.Length < 1)
                return -1;

            for (i = 0; i < valueArray.Length; i++)
            {
                if (maxValue < valueArray[i])
                    maxValue = valueArray[i];
            }
            return maxValue;
        }

    }


}