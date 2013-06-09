using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ConsoleApp
{
    public class AttributeTest
    {
        public static List<DataGridViewColumnAttribute> k()
        {
            List<DataGridViewColumnAttribute> columnList = new List<DataGridViewColumnAttribute>();

            Type tt = typeof(OrderBM);
            FieldInfo[] fis = tt.GetFields();
            foreach (var k in fis)
            {
                object[] objs = k.GetCustomAttributes(typeof(DataGridViewColumnAttribute), false);
                Console.Write(objs.ToString());
            }

            Type t = typeof(OrderBM);
            foreach (var item in t.GetProperties())
            {
                DataGridViewColumnAttribute col = Attribute.GetCustomAttribute(item, typeof(DataGridViewColumnAttribute)) as DataGridViewColumnAttribute;
                columnList.Add(new DataGridViewColumnAttribute(col.ColumnHeadText, col.ColumnName, col.ColumnVisible, col.ColumnWidth));

                //object[] obj = item.GetCustomAttributes(typeof(DataGridViewColumnAttribute), false);
                //if (obj != null && obj.Length > 0)
                //{
                //    DataGridViewColumnAttribute col = (obj[0] as DataGridViewColumnAttribute);
                //    columnList.Add(new DataGridViewColumnAttribute(col.ColumnHeadText, col.ColumnName, col.ColumnVisible, col.ColumnWidth));
                //}
            }

            return columnList;
        }
    }
}

public class OrderBM
{
    public int field;

    [DataGridViewColumn("订单编号")]
    [SecAttribute("dingdanbianhao")]
    public string OrderCode { get; set; }

    [DataGridViewColumn("订单价格")]
    public decimal CountPrice { get; set; }

    public string UnAttr { get; set; }
}

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public sealed class DataGridViewColumnAttribute : Attribute
{
    public string ColumnHeadText { get; set; }

    public string ColumnName { get; set; }

    public bool ColumnVisible { get; set; }

    public int ColumnWidth { get; set; }

    public DataGridViewColumnAttribute(string headTxt)
    {
        this.ColumnHeadText = headTxt;
        this.ColumnVisible = true;
        this.ColumnWidth = 100;
    }

    public DataGridViewColumnAttribute(string headTxt, string colName, bool vis, int width)
    {
        this.ColumnHeadText = headTxt;
        this.ColumnName = colName;
        this.ColumnVisible = vis;
        this.ColumnWidth = width;
    }
}

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
sealed class SecAttribute : Attribute
{
    readonly string kk;
    public SecAttribute(string k)
    {
        kk = k;
    }
}
