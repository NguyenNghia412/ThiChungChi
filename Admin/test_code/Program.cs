using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_code
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] test = GenRandomPermutation(10);
            //foreach(int i in test)
            //{
            //    Console.Write(i);
            //}
            /*
            List<DapAn> ls1 = new List<DapAn>();
            DapAn DapAn1 = new DapAn() { CauHoiID = 1, Match = "a" };
            ls1.Add(DapAn1);
            DapAn DapAn2 = new DapAn() { CauHoiID = 1, Match = "b" };
            ls1.Add(DapAn2);
            DapAn DapAn3 = new DapAn() { CauHoiID = 1, Match = "c" };
            ls1.Add(DapAn3);

            List<DapAn> ls2 = new List<DapAn>();
            DapAn DapAn11 = new DapAn() { CauHoiID = 1, Match = "b" };
            ls2.Add(DapAn11);
            DapAn DapAn21 = new DapAn() { CauHoiID = 1, Match = "a" };
            ls2.Add(DapAn21);
            DapAn DapAn31 = new DapAn() { CauHoiID = 1, Match = "c" };
            ls2.Add(DapAn31);

            ls1.Sort(delegate (DapAn x, DapAn y)
            {
                if (x.Match == null && y.Match == null) return 0;
                else if (x.Match == null) return -1;
                else if (y.Match == null) return 1;
                else return x.Match.CompareTo(y.Match);
            });

            ls2.Sort(delegate (DapAn x, DapAn y)
            {
                if (x.Match == null && y.Match == null) return 0;
                else if (x.Match == null) return -1;
                else if (y.Match == null) return 1;
                else return x.Match.CompareTo(y.Match);
            });

            if (ls1.SequenceEqual(ls2))
                Console.WriteLine("OK");
            else
                Console.WriteLine("NotOK");*/

            /*
            DataTable dt = GetTable();

            DataRow dr = dt.Rows[10];
            DataRow dr1 = dt.Rows[11];

            dr.Delete();
            dr1.Delete();

            dt.AcceptChanges();

            Console.WriteLine("NotOK");
            */
            test2 t21 = new test2 { X1 = 1,X2=2,X3=3 };
            test2 t22 = new test2 { X1 = 1, X2 = 4, X3 = 5 };
            test2 t23 = new test2 { X1 = 6, X2 = 2, X3 = 8 };
            List<test2> lsTest2 = new List<test2>();
            lsTest2.Add(t21);
            lsTest2.Add(t22);
            lsTest2.Add(t23);

            test1 t11 = new test1 { A1=1, A2=2, A3=lsTest2 };
            test1 t12 = new test1 { A1 = 5, A2 = 6, A3 = lsTest2 };
            List<test1> lsTest1 = new List<test1>();
            lsTest1.Add(t11);
            lsTest1.Add(t12);


            string strTest= JsonConvert.SerializeObject(lsTest1);

            Console.WriteLine(strTest);

            Console.ReadLine();
        }
        static DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));

            // Here we add five DataRows.
            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);

            table.Rows.Add(125, "Indocin", "David", DateTime.Now);
            table.Rows.Add(150, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(110, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(121, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(1100, "Dilantin", "Melanie", DateTime.Now);

            table.Rows.Add(225, "Indocin", "David", DateTime.Now);
            table.Rows.Add(250, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(210, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(221, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(2100, "Dilantin", "Melanie", DateTime.Now);
            return table;
        }
        public static int[] GenRandomPermutation(int n)
        {
            Random r = new Random();
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = i;
            }
            for (int i = 0; i < n; i++)
            {
                int j = r.Next(n);
                int t = a[0];
                a[0] = a[j];
                a[j] = t;
            }
            return a;
        }
    }

    class test1
    {
        public int A1 { get; set; }
        public int A2 { get; set; }
        public List<test2> A3 { get; set; }
    }
    class test2
    {
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int X3 { get; set; }
    }
}

