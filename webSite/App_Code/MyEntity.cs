using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///MyEntity 的摘要说明
/// </summary>
public class MyEntity
{
    public MyEntity()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }


}
public class QueryParams
{
    public int? OrderId { get; set; }
    public int? CustomId { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}
public class Order
{
    public int Id { get; set; }
    public DateTime OrderTime { get; set; }
    public OrderDetail OrderDetail { get; set; }
}
public class OrderDetail
{
    public int DetId { get; set; }
    public long Count { get; set; }
    public string ProductName { get; set; }
}