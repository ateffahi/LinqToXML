using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToXML
{
    public class Person
    {
        private int _PersonID;
        private string _Name;
        private string _Sex;
        private string _HomePhone;
        private string _Workphone;
        private Address _Address;

        public Person(int PersonID, string Name, string Sex, string HomePhone, string Workphone, Address Address)
        {
            _PersonID = PersonID;
            _Name = Name;
            _Sex = Sex;
            _HomePhone = HomePhone;
            _Workphone = Workphone;
            _Address = Address;
        }

        public int PersonID { get => _PersonID; set => _PersonID = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Sex { get => _Sex; set => _Sex = value; }
        public string HomePhone { get => _HomePhone; set => _HomePhone = value; }
        public string Workphone { get => _Workphone; set => _Workphone = value; }
        public Address Address { get => _Address; set => _Address = value; }
    }
}
