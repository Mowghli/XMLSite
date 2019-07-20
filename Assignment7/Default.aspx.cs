using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Reflection;

namespace Assignment7
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void XmlParserBtn_Click(object sender, EventArgs e)           // Button clicked will invoke parsing xml
        {
            ErrorLabel.Text = "";           // setting error label to empty string 
            StatusLabel.Text = "";          // setting status label to empty string
            HTMLContent.Text = "";          // setting HTMLContent label to empty string
            XMLData.Text = "";              // setting XMLData label to empty string
            string xmlName;                 // new string that will store xml address
            if (string.IsNullOrEmpty(XMLurl.Text))  // checking if user input is empty or not
            {
                xmlName = System.AppDomain.CurrentDomain.BaseDirectory; // getting current directory address
                xmlName = xmlName+"/Persons/Persons.xml";       // getting address of "Persons.xml"
            }
            else                    // if user input is not empty
            {
                xmlName = XMLurl.Text;      // setting the xmlName to XML url provided by user
            }
            try                     // try statement in case of errors
            {
                
                XmlDocument xd = new XmlDocument(); //create an object of XmlDocument class
                xd.Load(xmlName);           // loading the xml content using the url in xmlName
                OutputNode(xd);             // calling the OutputNode function
            }
            catch (Exception g)             // catch statement to catch errors
            {
                ErrorLabel.Text = g.Message;        // displaying the error message to user
            }
        }

        void OutputNode(XmlNode node)   // recursive function that does preorder traversal of xml tree
        {
            TableRow tempRow = new TableRow();                      // create new tablerow
            TableItemStyle tableStyle = new TableItemStyle();   // Creating a tablestyle  
            tableStyle.HorizontalAlign = HorizontalAlign.Center;    // setting the horizontal alignment to center
            tableStyle.VerticalAlign = VerticalAlign.Middle;        // setting the vertical alignment to middle
            tableStyle.BorderColor = System.Drawing.Color.Black;    // setting the border color to black
            tableStyle.BorderWidth = 1;                             // setting the border width to 1
            XmlAttributeCollection x;               // create new XmlAttributeCollection object
            string s;                           // create string s to store attributes
            if (node == null)                   // checking if current node is null or not
            {
                return;                         // return if current node is null
            }
            {
                TableCell tempCell1 = new TableCell();       // creating new table cell to store node name
                TableCell tempCell2 = new TableCell();       // creating new table cell to store node type
                TableCell tempCell3 = new TableCell();       // creating new table cell to store node attributes
                TableCell tempCell4 = new TableCell();       // creating new table cell to store node value
                tempCell1.Text = node.Name;                     // storing node name into tempCell1
                tempCell2.Text = node.NodeType.ToString();      // storing node type into tempCell2
                tempCell4.Text = node.Value;                        // storing node value into tempCell4
                x = node.Attributes;                        // x will contain the attributes collection
                s = "";                     // setting string s to empty
                if (x != null)              // checking if x is empty
                {
                    s = "";                 // setting string s to empty
                    foreach (XmlAttribute ss in x)          // traversing through each attribute in x
                    {
        
                            s = s +ss.Name+" = '"+ ss.Value + "'" + Environment.NewLine;    // storing the attribute name and value into "s"
                    }
                }
                tempCell3.Text = s;                     // storing the list of attributes into tableCell3
                tempCell1.ApplyStyle(tableStyle);       // applying style tableStyle to cell tempCell1
                tempCell2.ApplyStyle(tableStyle);       // applying style tableStyle to cell tempCell2
                tempCell3.ApplyStyle(tableStyle);       // applying style tableStyle to cell tempCell3
                tempCell4.ApplyStyle(tableStyle);       // applying style tableStyle to cell tempCell4
                tempRow.Cells.Add(tempCell1);           // adding cell tempCell1 to row tempRow
                tempRow.Cells.Add(tempCell2);           // adding cell tempCell2 to row tempRow
                tempRow.Cells.Add(tempCell3);           // adding cell tempCell3 to row tempRow
                tempRow.Cells.Add(tempCell4);           // adding cell tempCell4 to row tempRow
                myTable.Rows.Add(tempRow);              // adding row tempRow to myTable
            }
            if (node.HasChildNodes)                     // checking if the current node has child nodes
            {
                XmlNodeList children = node.ChildNodes; // getting a list of all child nodes of current node
                foreach (XmlNode child in children)     // traversing through each child node
                    OutputNode(child);                  // calling OutputNode() for each child
            }

        }

        protected void XmlValidatorBtn_Click(object sender, EventArgs e)    // Button method invoked on click; invokes validation
        {
            ErrorLabel.Text = "";           // setting error label to empty string 
            StatusLabel.Text = "";          // setting status label to empty string
            HTMLContent.Text = "";          // setting HTMLContent label to empty string
            XMLData.Text = "";              // setting XMLData label to empty string
            ValidatorService.Service1Client ValidService = new ValidatorService.Service1Client();       // Create a ServiceClient object to connect to the Validator Service
            string xmlName;            // new string that will store xml address
            string xsdName;             // new string that will store xsd address
            string[] output;                // string array that will store status of validation process
            string temp = "";               // temporary string set to be empty
            if (string.IsNullOrEmpty(XMLurl.Text) && string.IsNullOrEmpty(XSDurl.Text))     // checking if the user inputs are empty or not
            {
                xmlName = System.AppDomain.CurrentDomain.BaseDirectory;     // if user inputs are empty, getting the cuurent directory address
                xsdName= xmlName + "/Persons/Persons.xsd";          // getting the absolute address of default xsd file, "Persons.xsd" 
                xmlName = xmlName + "/Persons/Persons.xml";         // getting the absolute address of default xml file, "Persons.xml"
            }
            else                                                    // if the user gave nonempty inputs
            {
                xmlName = XMLurl.Text;              // getting the url of the XML file
                xsdName = XSDurl.Text;              // getting the url of the XSD file
            }
            try                         // try catch statement to catch errors 
            {

                output=ValidService.ValidateXML(xmlName, xsdName);          // calling the ValidateXML() function to validate the xml and xsd files
                if (output.Length == 1 && !output[0].Contains("No errors encountered"))       // checking if the ouput message is not an error message
                {
                    StatusLabel.Text = output[0];           // displaying the success message
                }
                else                    // if the output array contains error messages
                {
                    for(int i=0; i<output.Length; i++)      // for loop for storing all error messages into one string
                    {
                        temp = temp + output[i] + "\n";     // storing error messages into "temp"
                    }
                    StatusLabel.Text = temp;            // displaying temp/error messages
                }
            }
            catch (Exception g)                         // catch statement to catch errors
            {
                ErrorLabel.Text = g.Message;            // display the error message
            }
        }

        protected void XmlTransformerBtn_Click(object sender, EventArgs e)      // button function that invokes transformation when clicked
        {
            ErrorLabel.Text = "";           // setting error label to empty string 
            StatusLabel.Text = "";          // setting status label to empty string
            HTMLContent.Text = "";          // setting HTMLContent label to empty string
            XMLData.Text = "";              // setting XMLData label to empty string
            TransformerService.Service1Client TransformService = new TransformerService.Service1Client();        // Create a ServiceClient object to connect to the Transformer Service
            string xmlName;             // string to store xml url
            string xslName;             // string to store xsl url
            string Xpath="";            // string to store result html file address
            string output;              // string to store the html content
            string temp = "";           // temporary string variable
            if (string.IsNullOrEmpty(XMLurl.Text) && string.IsNullOrEmpty(XSLurl.Text))     // checking if user input is empty
            {
                xmlName = System.AppDomain.CurrentDomain.BaseDirectory;         // finding current directory address
                Xpath = xmlName;                                                // finding current directory address
                xslName = xmlName + "/Persons/Persons.xsl";                     // getting default xsl file "Person.xsl" address
                xmlName = xmlName + "/Persons/Persons.xml";                     // getting default xsl file "Person.xsl" address
                Xpath = Xpath + "/Persons/Persons.html";                        // setting default html file "Persons.html" address
            }
            else                                // if user input is nonempty
            {
                Xpath = System.AppDomain.CurrentDomain.BaseDirectory;       // getting the current directory address
                xmlName = XMLurl.Text;                                      // storing the user input (xml url address) into xmlName
                xslName = XSLurl.Text;                                      // storing the user input (xsl url address) into xslName
                Xpath = Xpath + "/Persons/Result.html";                     // setting the html file address
            }
            try                             // try-catch statement to catch errors
            {
                output = TransformService.TransformXML(xmlName, xslName);   // calling the "public string TransformXML(string XMLUrl, string XSLUrl)" function; storing result html contents into "output"
                HTMLContent.Text = output;                  // displaying the transformed html contents, or an error message returned by the function
                //Xpath = Xpath + "/Persons/Persons.html";
                using (StreamWriter sw = File.CreateText(Xpath))            // using StreamWriter to open "Result.html" and delete it's contents; or create a new file of the same name
                {
                    sw.WriteLine(output);                   // writing the output into the file (Either html contents or error message)
                }
                StatusLabel.Text = "Check the address at " + Xpath + " for the HTML file, you can also see it in this page";   // displaying success message to user, and referencing location of the result html file
            }
            catch (Exception g)             // catch statement to catch exceptions
            {
                HTMLContent.Text = g.Message;       // display error message to user
            }
        }
    }
}