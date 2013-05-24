using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    public class LinqTest
    {
        List<t_prd_categorybaseDM> modList = null;

        public LinqTest()
        {
            if (modList == null)
            {
                modList = new List<t_prd_categorybaseDM> { 
                    new t_prd_categorybaseDM{ Id=1,  CategoryName="N1", ParentId=0},
                    new t_prd_categorybaseDM{ Id=2, CategoryName="N2", ParentId=1},
                    new t_prd_categorybaseDM{ Id=3, CategoryName="N3", ParentId=1}
                };
            }
        }

        public List<ParentChildModel> get(long pid)
        {
            var o = from c in modList
                    let HasChild = modList.Count(p => p.ParentId == c.Id)>0?1:0
                    where c.ParentId == pid
                    select new { c.Id, c.CategoryName, HasChild };

            //这句返回null,匿名对象无法直接转成实际对象
            //return (o as List<ParentChildModel>);
            
            List<ParentChildModel> re= o.Select(r=>new ParentChildModel{ CID=r.Id, Name=r.CategoryName, HasChild=r.HasChild}).ToList();
            return re;

        }
    }


    public class ParentChildModel
    {
        /// <summary>
        /// 把 ID 重命名成 CID
        /// </summary>
        public long CID { get; set; }
        /// <summary>
        /// 把 ParentID 重命名成 PID
        /// </summary>
        public long PID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int HasChild { get; set; }
    }

    public class t_prd_categorybaseDM
    {
        public long Id
        {
            get;
            set;
        }

        public long ParentId
        {
            get;
            set;
        }
        public string CategoryName
        {
            get;
            set;
        } 
    }
}
