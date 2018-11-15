using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXML
{
    class QueryLinqXML
    {

      
        private string _path;
        private IEnumerable<XElement> _Employees;
        private XElement _xElement;

        public string Path { get => _path; set => _path = value; }
        public IEnumerable<XElement> Employees { get => _Employees; set => _Employees = value; }
        public XElement XElement { get => _xElement; set => _xElement = value; }

        public QueryLinqXML(string path)
        {
            Path = path;
            XElement = XmlLoad(); // Load the xml file on xelement variable
            Employees = XElement.Elements("Employee"); // lister des élements du document
        }


        public XElement XmlLoad()
        {
            return XElement.Load(Path);
        }

        public void DisplayString(List<string> file)
        {
            foreach (string name in file)
            {
                Console.WriteLine(name);
            }
        }

        public void DisplayXelement()
        {
            // ici le foreach comme une itération
            //foreach (XElement xEl in xElements)
            //    Console.WriteLine(xEl);
            Console.WriteLine("*************************** Dispaly My XElement ****************** ");
            // ici le ForEach comme une méthode d'extention (lambda expresion)
            Employees.ToList().ForEach(xEl => Console.WriteLine(xEl)) ;
        }



        public List<XElement> QueryFemale()
        {
            //return (from fe in xElements
            //        where (string)fe.Element("Sex") == "Female"
            //        select fe).ToList();

            return Employees.Where(fe => fe.Element("Sex")?.Value == "Female").ToList()  ; // ? : pour éviter que le système prendre la valeur NULL.

        }

        // Autre methode : recuperation directement les nomes des femmes :  
        public List<string> QueryFemaleBis()
        {
            //return (from fe in xElements
            //        where (string)fe.Element("Sex") == "Female"
            //        select fe).ToList();

            return Employees.Where(fe => fe.Element("Sex")?.Value == "Female").Select(e => e.Element("Name").Value).ToList(); // ? : pour éviter que le système prendre la valeur NULL.

        }

        public void DisplayXelementFemale(List<XElement> xElements)
        {
            // ici le foreach comme une itération
            //foreach (XElement xEl in xElements)
            //    Console.WriteLine(xEl);
            // ici le ForEach comme une méthode d'extention (lambda expresion)
            Console.WriteLine("***************** The Females employees *************************");
            Console.WriteLine($"The count of female is: {xElements.Count}");
            xElements.ForEach(xEl => Console.WriteLine(xEl.Element("Name").Value));
        }

        public List<XElement> QueryAltaEmployees()
        {
            //return (from address in xElements
            //                    where (string)address.Element("Address").Element("City") == "Alta"
            //                    select address).ToList();

            return Employees.Where(AE => AE.Element("Address").Element("City").Value == "Alta").ToList();

        }

        public void DisplayAltaEmployees(List<XElement> xElements)
        {
            Console.WriteLine("***************** The list of employees lives in Alta ********************");
            xElements.ForEach(xEl => Console.WriteLine(xEl.Element("Name").Value));
        }

        public void AddxElement(Person P)
        {
            XElement.Add(new XElement("Employee",
			
    new XElement("EmpId", P.PersonID),
    new XElement("Name", P.Name),
    new XElement("Sex", P.Sex),
    new XElement("Phone", P.HomePhone, new XAttribute("Type", "Home")),
    new XElement("Phone", P.Workphone, new XAttribute("Type", "Work")),
    new XElement("Address",
        new XElement("Street", P.Address.Street),
		
        new XElement("City", P.Address.City),
		
        new XElement("State", P.Address.State),
		
        new XElement("Zip", P.Address.Zip),
		
        new XElement("Country", P.Address.Country))));

            XElement.Save(Path);
        }


    }
}
