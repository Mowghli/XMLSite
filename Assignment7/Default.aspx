<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment7._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>TryIt page xml parser/Validator/Transformer</h1>
    <p>
        NOTE: To use the default Persons files in the provided services, leave the respective textboxes blank.
    </p>
    <p>This Web application, and the services it uses are deployed in localhost. This page performs Parsing, Validation and Transformation</p>
    <p>Parsing is done in the web application. Enter the url of the xml file into the respective textbox, and click &quot;Parse&quot;. The table will show up, and will display the Name, Type and Value for each tag, as well as a list of attributes for each tag. If you leave the textbox blank, the &quot;Persons.xml&quot; file will be parsed instead.</p>
    <p>Validation is done using the WCF Service &quot;Validator&quot;. Enter the urls of the XML and XSD files into the respective textboxes, and click on &quot;Validate&quot;. The result of validation will show up on the &quot;Status&quot;. Errors in validation will show up on the &quot;Status&quot;, while other errors will show up on &quot;Error&quot;. The method used for validation is &quot;public string[] ValidateXML(string XMLUrl, string XSDUrl)&quot;: this method will take in the Urls of the XML and XSD files as arguments, and will return a string array containing the status of validation operation. If you leave the textboxes blank, the files &quot;Persons.xml&quot; and &quot;Persons.xsd&quot; will be used instead for validation.</p>
    <p>Transformation is done using the WCF Service &quot;Transformer&quot;. Enter the urls of the XML and XSL files into the respective textboxes, and click on &quot;Transform&quot;. The resulting html content will be shown below &quot;HTML Content/Errors&quot;. And html file will also be created, at a location specified by the message at &quot;Status&quot;.&nbsp; The method used for validation is &quot;string TransformXML(string XMLUrl, string XSLUrl)&quot;: this method will taken in the urls of the XML and XSL files as arguments, and will send back a string containing the html content. This web application will then display the html content, and create the html file. If you leave the textboxes blank, then &quot;Persons.xml&quot; and &quot;Persons.xsl&quot; will be used for transformation.</p>
    <p>
        Enter the xml URL into the following textbox:
        <asp:TextBox ID="XMLurl" runat="server" Width="537px"></asp:TextBox>
    </p>
    <p>
        Enter the xsd URL into the following textbox:
        <asp:TextBox ID="XSDurl" runat="server" Width="532px"></asp:TextBox>
    </p>
    <p>
        Enter the xsl URL into the following textbox:
        <asp:TextBox ID="XSLurl" runat="server" Width="534px"></asp:TextBox>
    </p>
    <p>
        Click the button, to see the parsed text:

        <asp:Button ID="XmlParserBtn" runat="server" Text="Parse" OnClick="XmlParserBtn_Click" />

    </p>
        <p>
        Click the button, to validate the xml file:

        <asp:Button ID="XmlValidatorBtn" runat="server" Text="Validate" OnClick="XmlValidatorBtn_Click"/>

    </p>
    <p>
        Click the button, to convert the xml file to html:

        <asp:Button ID="XmlTransformerBtn" runat="server" Text="Transform" OnClick="XmlTransformerBtn_Click" />

    </p>
    <p>
        Error:
        <asp:Label ID="ErrorLabel" runat="server"></asp:Label>
    </p>
    <p>
        Status:
        <asp:Label ID="StatusLabel" runat="server"></asp:Label>
    </p>
    <p>
        HTML Content/Errors:
        <asp:Label ID="HTMLContent" runat="server"></asp:Label>
    </p>
    <p>
        Parsed Text:
    </p>
    <p>
        
        <asp:Label ID="XMLData" runat="server"></asp:Label>
        
    </p>
    <p>
        <asp:Table ID="myTable" runat="server" BorderColor="Black" BorderWidth="1" BorderStyle="Solid"> 
    <asp:TableHeaderRow ID="headertable" BorderColor="Black" BorderWidth="1" BorderStyle="Solid" VerticalAlign="Middle" HorizontalAlign="Center" BackColor="Yellow" Font-Bold="true">
        <asp:TableCell BorderColor="Black" BorderWidth="1" >Name</asp:TableCell>
        <asp:TableCell BorderColor="Black" BorderWidth="1" >Type</asp:TableCell>
        <asp:TableCell BorderColor="Black" BorderWidth="1" >Attributes</asp:TableCell>
        <asp:TableCell BorderColor="Black" BorderWidth="1" >Value</asp:TableCell>
    </asp:TableHeaderRow>
        
    </asp:Table>
    </p>
    
    

</asp:Content>
