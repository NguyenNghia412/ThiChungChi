using System;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace TH.NUCE.Web
{
    public sealed class XMLProvider
    {
        public static string GetHTMLFromXML(string strXML, string xslFilePath, XsltArgumentList objArgs)
        {
            XmlTextReader xmlReader = new XmlTextReader(new StringReader(strXML));
            XPathDocument xPathDocument = new XPathDocument(xmlReader);
            XslTransform xslTrans = new XslTransform();
            xslTrans.Load(xslFilePath);
            StringBuilder sb = new StringBuilder();
            TextWriter tw = new StringWriter(sb);
            xslTrans.Transform(xPathDocument, objArgs, tw);
            string result = sb.ToString();
            tw.Close();
            xmlReader.Close();
            return result;

        }

        /// <summary>
        /// A function that takes an XML string and converts it into a DataSet
        /// </summary>
        /// <param name="xmlString">The xml string to tranform into a DataSet</param>
        /// <returns>The DataSet representing the values and schema from our xml string</returns>
        public static DataSet XmlString2DataSet(string xmlString)
        {
            //create a new DataSet that will hold our values
            DataSet quoteDataSet = null;

            //check if the xmlString is not blank
            if (String.IsNullOrEmpty(xmlString))
                //stop the processing
                return quoteDataSet;

            try
            {
                //create a StringReader object to read our xml string
                using (StringReader stringReader = new StringReader(xmlString))
                {
                    //initialize our DataSet
                    quoteDataSet = new DataSet();

                    //load the StringReader to our DataSet
                    quoteDataSet.ReadXml(stringReader);
                }
            }
            catch
            {
                //return null
                quoteDataSet = null;
            }

            //return the DataSet containing the stock information
            return quoteDataSet;
        }

        /// <summary>
        /// A function that takes an XML string and converts it into a DataTable
        /// </summary>
        /// <param name="xmlString">The xml string to tranform into a DataTable</param>
        /// <returns>The DataSet representing the values and schema from our xml string</returns>
        public static DataTable XmlString2DataTable(string xmlString)
        {
            //create a new DataSet that will hold our values
            DataSet quoteDataSet = null;

            //get the dataset
            quoteDataSet = XmlString2DataSet(xmlString);

            if (quoteDataSet != null && quoteDataSet.Tables.Count > 0)
                return quoteDataSet.Tables[0];
            else
                return null;
        }
    }
}