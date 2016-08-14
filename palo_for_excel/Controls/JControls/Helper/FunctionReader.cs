 /* 
 *
 * Copyright (C) 2006-2011 Jedox AG
 *
 * This program is free software; you can redistribute it and/or modify it
 * under the terms of the GNU General Public License (Version 2) as published
 * by the Free Software Foundation at http://www.gnu.org/copyleft/gpl.html.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for
 * more details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 59 Temple
 * Place, Suite 330, Boston, MA 02111-1307 USA
 *
 * You may obtain a copy of the License at
 *
 * <a href="http://www.jedox.com/license_palo_bi_suite.txt">
 *   http://www.jedox.com/license_palo_bi_suite.txt
 * </a>
 *
 * If you are developing and distributing open source applications under the
 * GPL License, then you are free to use Palo under the GPL License.  For OEMs,
 * ISVs, and VARs who distribute Palo with their products, and do not license
 * and distribute their source code under the GPL, Jedox provides a flexible
 * OEM Commercial License.
 *
 * \author
 * 
 *
 */

////////////////////////////////////////////////////////////////////////////////
/// @brief  Procedures for reading XML function description
///
/// @file   FunctionReader.cs
///
/// Developed by Igor Timarac, Banja Luka on behalf of Jedox GmbH.
/// Copyright and exclusive worldwide exploitation right has
/// Jedox GmbH, Freiburg.
///
/// @author Igor Timarac, Banja Luka, Bosnia and Herzegovina
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace JControls
{
    public class Argument
    {
        public int number;
        public string type;
        public Dictionary<string,string> description;
        public bool optional;

        public Argument()
        {
            description = new Dictionary<string, string>();
        }

        public void Fill(int number, XmlNode rootNode)
        {
            this.number = number;
            this.description = new Dictionary<string, string>();
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                switch (node.Name)
                {
                    case "type":
                        this.type = node.ChildNodes[0].Value;
                        break;

                    case "description":
                        this.description.Add(node.Attributes[0].Value, node.ChildNodes[0].Value);
                        break;
                }
            }
        }
    }

    public class Function
    {
        public string name;
        public string category;
        public Dictionary<string, string> shortDescription;
        public Dictionary<string, string> longDescription;
        public int minimalArguments;
        public int maximalArguments;
        public List<Argument> arguments;

        public Function()
        {
            arguments = new List<Argument>();
            shortDescription = new Dictionary<string, string>();
            longDescription = new Dictionary<string, string>();
        }

        private string Adjust(string s)
        {
            int i, j;
            for (i = 0; (i < s.Length) && Char.IsWhiteSpace(s[i]); i++) ;
            for (j = s.Length-1; (j > 0) && Char.IsWhiteSpace(s[j]); j--) ;
            return s.Substring(i, j - i + 1);
        }

        public void Fill(XmlNode rootNode)
        {
            this.shortDescription = new Dictionary<string, string>();
            this.longDescription = new Dictionary<string, string>();
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                switch (node.Name) {
                    case "name":
                            this.name = node.ChildNodes[0].Value;
                            break;

                    case "category":
                            this.category = node.ChildNodes[0].Value;
                            break;

                    case "short-description":
                            this.shortDescription.Add(node.Attributes[0].Value, Adjust(node.ChildNodes[0].Value));
                            break;

                    case "long-description":
                            this.longDescription.Add(node.Attributes[0].Value, Adjust(node.ChildNodes[0].Value));
                            break;

                    case "minimal-arguments":
                            try
                            {
                                this.minimalArguments = Int32.Parse(node.ChildNodes[0].Value);
                            }
                            catch (Exception ex)
                            {
                                throw new FormatException(ex.Message);
                            }
                            break;

                    case "maximal-arguments":
                            try
                            {
                                this.maximalArguments = Int32.Parse(node.ChildNodes[0].Value);
                            }
                            catch (Exception ex)
                            {
                                throw new FormatException(ex.Message);
                            }
                            break;

                    case "argument":
                        try
                        {
                            int na = Int32.Parse(node.Attributes[0].Value);
                            if (arguments == null) arguments = new List<Argument>();
                            Argument arg = new Argument();
                            arg.Fill(na, node);
                            arg.optional = (arg.number >= minimalArguments);
                            arguments.Insert(na, arg);
                            break;
                        }
                        catch (Exception ex)
                        {
                            throw new FormatException(ex.Message);
                        }
                }
            }
        }
        public override string ToString()
        {
            return this.name;
        }
    }

    public class XMLDescription
    {
        private List<Function> funcList;
        private XmlTextReader reader;
        private static XMLDescription instance;
        private bool dirty = true;

        private XMLDescription() { } // Singleton
        public static XMLDescription Instance
        {
            get 
            { 
                if (instance == null) instance = new XMLDescription();
                return instance;
            }
        }

        public XmlTextReader Reader
        {
            get { return reader; }
            set { reader = value; dirty = true; }
        } 

        public List<Function> FuncList
        {
            get
            {
                if ((funcList == null) || dirty) // Read only first time. Later changes will not affect funcList.
                {
                    this.Read();
                }
                dirty = false;
                return funcList; 
            }
            set { funcList = value; }
        }

        protected void Read()
        {
            XmlDocument document = new XmlDocument();
            if (reader == null)
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] bytes = new byte[Properties.Resources.palooFunc.Length];
                bytes = encoding.GetBytes(Properties.Resources.palooFunc);
                MemoryStream stream = new MemoryStream(bytes);
                reader = new XmlTextReader(stream);
            }
            document.Load(reader);
            reader.WhitespaceHandling = WhitespaceHandling.None;
            XmlElement root = document.DocumentElement;
            funcList = new List<Function>();

            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Name != "function")
                {
                    throw new FormatException("Improper XML Format");
                }

                Function function = new Function();
                function.Fill(node);
                funcList.Add(function);
                if (function.name == null)
                {
                    System.Console.WriteLine("BUG0 (function.name == null): " + node.Name);
                }
                if (function.shortDescription.Values.Count < 2)
                {
                    System.Console.WriteLine("BUG1 (shortDescription.English or shortDescription.German == null): " + function.name);
                }
                if (function.longDescription.Values.Count < 2)
                {
                    System.Console.WriteLine("BUG2 (longDescription.English == null or longDescription.German == null): " + function.name);
                }
                if (function.arguments.Count != function.minimalArguments)
                {
                    System.Console.WriteLine("BUG3 (wrong number of arguments specified): " + function.name);
                }
                int ii = 0;
                foreach (Argument a in function.arguments)
                {
                    if (a.description.Values.Count < 2)
                    {
                        System.Console.WriteLine("BUG4 (argument without english or german description): " + function.name + ", ARGUMENT#: " + ii);
                    }
                    ii++;
                }
            }
        }
        public void FillCombo(ComboBox cb)
        {
            foreach (Function func in FuncList)
            {
                cb.Items.Add(func);
            }
        }
    }
}

