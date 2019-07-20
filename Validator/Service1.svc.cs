using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using System.Xml.Schema;
using System.Xml;

namespace Validator
{    
    public class Service1 : IService1
    {
        static List<string> output;
        public string[] ValidateXML(string XMLUrl, string XSDUrl)           // function to validate an xml file, based on the xsd schema. Takes in url of both files, and returns result of validation
        {
            output = new List<string>();                // create a string list to store the resulting error messages/success message from validation
            try         // try catch statement to catch errors
            {
                XmlSchemaSet sc = new XmlSchemaSet();                   // create new XmlSchemaSet object
                sc.Add(null, XSDUrl);                                   // download and load xml schema/xsd from url in SXDurl
                XmlReaderSettings settings = new XmlReaderSettings();   // Define the validation settings.
                settings.ValidationType = ValidationType.Schema;        // Define the validation settings.
                settings.Schemas = sc;                                  // Association
                settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);      // event handler called during errors encountered during validation process
                XmlReader reader = XmlReader.Create(XMLUrl, settings);  // downloading and loading xml contents from url in XMLUrl
                while (reader.Read()) ;                                 // will call event handler if invalid
            }
            catch (Exception e)                 // catch statement to catch errors
            {
                output.Add(e.Message);          // storing error message into output list
            }
            if (output.Count==0)                // checking if any error messages were in the ouput string list, if not, then xml file is valid 
            {
                output.Add("The XML file validation has completed: No errors encountered");         // storing success message into ouput list
            }
            return output.ToArray();                // convert the ouput list to string array, and return string array
        }
        private static void ValidationCallBack(object sender, ValidationEventArgs e)            // function that is subscribed to the event, in case errors occur in validation process
        {
            //Console.WriteLine("Validation Error: {0}", e.Message);
            output.Add(e.Message);              // storing error message into output string list
        }

    }
}
