using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Hospital_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            string ncita;
            Console.WriteLine("QUE NUMERO DE CITA QUIERES RESERVAR? (1-12)");
            ncita = Console.ReadLine();
            Console.WriteLine("CUAL ES SU NOMBRE?");
            name = Console.ReadLine(); 
            string req = XmlConverter.GenerarPaqueteXmlConvertRequest(name, ncita);
            Connect(ConfigurationManager.AppSettings["host"], req);
        }
        static void Connect(String server, String message)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = Int32.Parse(ConfigurationManager.AppSettings["port"]);
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
        public static (string name, int space) ProcesarXmlConvertRequest(string xmlData)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlData);
            var name = doc.SelectSingleNode("//name");
            var ncita = doc.SelectSingleNode("//ncita");
            (string name, int space) request = (name.InnerText, int.Parse(ncita.InnerText));
            return request;
        }
        public static string GenerarPaqueteXmlConvertResponse((string name ,int space) requestedApntmnt, List<( string name, int space)> apntmntList)
        {
            string conclusion;

            if (apntmntList.FindIndex(x => x.space == requestedApntmnt.space) != -1)
            {
                conclusion = "LA CITA " + requestedApntmnt.space + " YA ESTA RESERVADA, INTENTE RESERVAR OTRA";
            }
            else { 
                conclusion = "RESERVA COMPLETADA CORRECTAMENTE";
                apntmntList.Add(requestedApntmnt);
            }
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);
            XmlNode responseNode = doc.CreateElement("ConvertResponse");
            doc.AppendChild(responseNode);
            XmlNode conclusionNode = doc.CreateElement("conclusion");

            conclusionNode.InnerText = conclusion;
            responseNode.AppendChild(conclusionNode);
            return doc.InnerXml;
        }

        public static string GenerarPaqueteXmlConvertRequest(string name, string ncita)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);
            XmlNode requestNode = doc.CreateElement("ConvertRequest");
            doc.AppendChild(requestNode);
            XmlNode nameNode = doc.CreateElement("name");
            nameNode.InnerText = name;
            requestNode.AppendChild(nameNode);
            XmlNode citaNode = doc.CreateElement("ncita");
            citaNode.InnerText = ncita;
            requestNode.AppendChild(citaNode);

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
