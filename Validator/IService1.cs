using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Validator
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string[] ValidateXML(string XMLUrl, string XSDUrl);  // function to validate an xml file, based on the xsd schema. Takes in url of both files, and returns result of validation


    }


}
