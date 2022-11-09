using System;
using System.Xml;

namespace bntu.vsrpp.akutsak.core
{
    public class Class1
    {
        public int GetElementCount()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("D:\\VSRPP_labs\\_VSRPP\\lab1_example1");

            XmlElement xmlElement = xmlDoc.DocumentElement;

            return xmlElement.ChildNodes.Count;
        }        
    }
}
