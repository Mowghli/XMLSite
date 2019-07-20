using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Transformer
{
   
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string TransformXML(string XMLUrl, string XSLUrl);   // function to transform an xml file into an html file, using an xsl file; takes in the urls of both files as input
                                                            // returns a string containing tranformed html contents

    }


    
    
}
