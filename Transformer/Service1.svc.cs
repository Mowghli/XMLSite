using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Transformer
{
    public class Service1 : IService1
    {
        public string TransformXML(string XMLUrl, string XSLUrl)        // function to transform an xml file into an html file, using an xsl file. Accepts urls of both files, returns a string containing tranformed html contents
        {
            var HTMLResult = new StringWriter() ;           // create a variable of StringWriter type
            try                                         // try catch statement to catch exceptions
            {
                XPathDocument doc = new XPathDocument(XMLUrl);          // create an XPathDocument object using the xml downloaded from the url in XMLUrl
                XslCompiledTransform xt = new XslCompiledTransform();   // create a XslCompiledTransform object xt for transforming xml to html
                xt.Load(XSLUrl);                    // downloading the xsl content from url in XSLUrl, and loading content into xt
                xt.Transform(doc, null, HTMLResult);        // tranforming the xml file into html, and storing the html content into HTMLResult variable
                return HTMLResult.ToString();               // convert the contents of HTMLResult into string, and returning that
            }
            catch (Exception e)                 // catch statement to catch errors
            {
                return e.Message;               // return error message
            }

        }


    }
}
