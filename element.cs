using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HashSearch_BinarySearch_Comparisions
{
    // Element class with CompareTo() implementation from IComparable

    public class element : IComparable<element>
    {
        // private data
        private int atomicNumber;
        private string elementName;
        private string elementSymbol;

        // public properties
        public int AtomicNumber
        {
            get { return atomicNumber; }
            set { atomicNumber = value; }
        }
        public string ElementName
        {
            get { return elementName; }
            set { elementName = value; }
        }
        public string ElementSymbol
        {
            get { return elementSymbol; }
            set { elementSymbol = value; }
        }

        // Constructor method
        public element(int atomicNumber, string elementName, string elementSymbol)
        {
            AtomicNumber = atomicNumber;
            ElementName = elementName;
            ElementSymbol = elementSymbol;
        }

        // CompareTo() method implemented from the IComparable interface
        public int CompareTo (element otherElement)
        {
            return ElementName.CompareTo(otherElement.ElementName);
        }

        // Override ToString() method
        public override string ToString()
        {
            return "[" + AtomicNumber.ToString() + "] " + ElementName + " (" + ElementSymbol + ")";
        }










    } // end of class element
}
