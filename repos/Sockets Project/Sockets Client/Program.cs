using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;
using System.IO;

namespace Sockets_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            /*string basePath = AppDomain.CurrentDomain.BaseDirectory;
            TextReader tr = new StreamReader(basePath + "/" + "RequestFile.xml");
            string myText1 = tr.ReadToEnd();
            list.Add(myText1);
            tr = new StreamReader(basePath + "/" + "RequestFile2.xml");
            string myText2 = tr.ReadToEnd();
            list.Add(myText2);*/
            string units;
            string from;
            string to;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("UNITS(AMOUNT):");
                units = Console.ReadLine();
                Console.WriteLine("FROM:(EUR|USD)");
                from = Console.ReadLine();
                Console.WriteLine("TO(EUR|USD):");
                to = Console.ReadLine();
                list.Add(XmlConverter.GenerarPaqueteXmlConvertRequest(units, from, to));
            }

            list.ForEach(x =>
            Connect(ConfigurationManager.AppSettings["host"], x)
            );
        }
        static void Connect(String server, String message)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port =  Int32.Parse(ConfigurationManager.AppSettings["port"]);
                TcpClient client = new TcpClient(server, port);
                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                // Get a client stream for reading and writing
                NetworkStream stream = client.GetStream();
                // Send the message to the connected TcpServer.
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", message);
                // Receive the TcpServer.response.
                // Buffer to store the response bytes.
                data = new Byte[256];
                // String to store the response ASCII representation.
                String responseData = String.Empty;
                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);
                // Close everything.
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }
    }
    public class XmlConverter
    {
        public static string ProcesarXmlConvertRequest(string xmlData, out decimal resultado)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlData);
            var nodeUnits = doc.SelectSingleNode("//units");
            var fromUnits = doc.SelectSingleNode("//from");
            var toUnits = doc.SelectSingleNode("//to");
            resultado = Convert.ToDecimal(nodeUnits.InnerText);
            return String.Concat(fromUnits.InnerText.ToUpper().Trim(), "-",
             toUnits.InnerText.ToUpper().Trim());
        }
        public static string GenerarPaqueteXmlConvertResponse(string finalCurrency, string units)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);
            XmlNode responseNode = doc.CreateElement("ConvertResponse");
            doc.AppendChild(responseNode);
            XmlNode unitsNode = doc.CreateElement("units");
            unitsNode.InnerText = units;
            responseNode.AppendChild(unitsNode);
            XmlNode toNode = doc.CreateElement("to");
            toNode.InnerText = finalCurrency;
            responseNode.AppendChild(toNode);
            return doc.InnerXml;
        }

        public static string GenerarPaqueteXmlConvertRequest(string units, string from, string to)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);
            XmlNode requestNode = doc.CreateElement("ConvertRequest");
            doc.AppendChild(requestNode);
            XmlNode unitsNode = doc.CreateElement("units");
            unitsNode.InnerText = units;
            requestNode.AppendChild(unitsNode);
            XmlNode fromNode = doc.CreateElement("from");
            fromNode.InnerText = from;
            requestNode.AppendChild(fromNode);
            XmlNode toNode = doc.CreateElement("to");
            toNode.InnerText = to;
            requestNode.AppendChild(toNode);

            return doc.InnerXml;
        }

        public static string GenerarPaqueteXmlConvertResponseError(string message)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);
            XmlNode responseNode = doc.CreateElement("ConvertResponse");
            responseNode.InnerText = message;
            doc.AppendChild(responseNode);
            return doc.InnerXml;
        }
    }
}
