using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToXML
{
    public class Address
    {
        private int _AddressID;
        private string _Street;
        private string _City;
        private string _State;
        private string _Zip;
        private string _Country;

        public Address(string Street, string City, string State, string Zip, string Country)
        {
            _AddressID = AddressID;
            _Street = Street;
            _City = City;
            _State = State;
            _Zip = Zip;
            _Country = Country;
        }

        public int AddressID { get => _AddressID; set => _AddressID = value; }
        public string Street { get => _Street; set => _Street = value; }
        public string City { get => _City; set => _City = value; }
        public string State { get => _State; set => _State = value; }
        public string Zip { get => _Zip; set => _Zip = value; }
        public string Country { get => _Country; set => _Country = value; }
    }
}
