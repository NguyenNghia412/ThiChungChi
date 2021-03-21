using System;

namespace test_code
{
    public class DapAn: IEquatable<DapAn> , IComparable<DapAn>
    {
        public int CauHoiID { get; set; }
        public string Match { get; set; }
        public float Mark { get; set; }
        public string Type { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            DapAn objAsPart = obj as DapAn;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public int CompareTo(DapAn dapAn)
        {
            // A null value means that this object is greater.
            if (dapAn == null)
                return 1;

            else
                return this.CauHoiID.CompareTo(dapAn.CauHoiID);
        }
        public int SortByNameAscending(string name1, string name2)
        {
            return name1.CompareTo(name2);
        }
        public override int GetHashCode()
        {
            return CauHoiID;
        }

        public bool Equals(DapAn other)
        {
            if (other == null) return false;
            return (this.CauHoiID.Equals(other.CauHoiID)&& this.Match.Equals(other.Match));
        }
    }
}
