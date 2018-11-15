using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            /************************** LINQ TO XML *****************************************************************/
            string path = @"C:\DossierXml\DossierXml\linqxml.xml";
            QueryLinqXML xmlfile = new QueryLinqXML(path);
            

            /***************** The Female employee *************************/
            #region OldMethod
            //var FemaleEmployee = (from fe in employees
            //           where (string)fe.Element("Sex") == "Female"
            //           select fe).ToList();

            //Console.WriteLine("Name of Female Employees:");
            //foreach (XElement xEle in FemaleEmployee)
            //          Console.WriteLine(xEle.Element("Name").Value);
            #endregion

            var FemaleEmployee = xmlfile.QueryFemale();
            xmlfile.DisplayXelementFemale(FemaleEmployee);

            Console.WriteLine("Ceci c'est un TEST : ");
            var test = xmlfile.QueryFemaleBis();
            xmlfile.DisplayString(test);


            /***************** The list of employees lives in Alta ******************** */
            #region OldMethod
            //var AltaEmployees = from address in employees
            //                where (string)address.Element("Address").Element("City") == "Alta"
            //                select address;

            //Console.WriteLine("details of employees living in alta city");
            //foreach (var xele in AltaEmployees)
            //            Console.WriteLine(xele);
            #endregion 

            var AltaEmployees = xmlfile.QueryAltaEmployees();
            xmlfile.DisplayAltaEmployees(AltaEmployees);

            /***************** Add a new Elemnt and save it *********************/

            Address A = new Address("Robert Kaskoreff", "CAEN", "Calvados", "14000", "France");
            Person P = new Person(5,"Amine", "Male", "09.45.36.98.75", "06.46.33.45.35", A);

            xmlfile.AddxElement(P);
           // xmlfile.DisplayXelement();

            








            Console.ReadKey();
        }
    }
}
