using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;
using System.Threading;

namespace Sockets_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*TcpListener server = null;
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, port);
                // Start listening for client requests.
                server.Start();
                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String data = null;
                // Enter the listening loop.
                while (true)
                {
                    Console.Write("Waiting for a connection... ");
                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    data = null;
                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();
                    int i;
                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0,
                       i);
                        Console.WriteLine("Received: {0}", data);
                        // Process the data sent by the client.
                        data = data.ToUpper();
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}",
                       data);
                    }
                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }*/
            CurrencyServer server = new CurrencyServer();
            server.ArrancarMultiThread();
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

    public class Conversor
    {
        private TcpClient client = null;
        public Conversor(TcpClient client)
        {
            this.client = client;
        }
        public void ProcessRequest()
        {
            Byte[] bytes = new Byte[256];
            string data = null;
            NetworkStream stream = client.GetStream();
            Int32 i = stream.Read(bytes, 0, bytes.Length);
            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i).Trim();
            decimal numeroAConvertir;
            var tipoConversion =
            XmlConverter.ProcesarXmlConvertRequest(data, out numeroAConvertir);
            if (tipoConversion == "USD-EUR")
            {
                numeroAConvertir *= Convert.ToDecimal(0.97);

                data = XmlConverter.GenerarPaqueteXmlConvertResponse("EUR", numeroAConvertir.ToString());
            }
            else if (tipoConversion == "EUR-USD")
            {
                numeroAConvertir *= Convert.ToDecimal(1.03);
                data = XmlConverter.GenerarPaqueteXmlConvertResponse("USD", numeroAConvertir.ToString());
            }
            else
                data = XmlConverter.GenerarPaqueteXmlConvertResponseError(
                "ERROR: Divisa no reconocida " + tipoConversion);
            Byte[] msg =
            System.Text.Encoding.ASCII.GetBytes(data);
            stream.Write(msg, 0, msg.Length);
            client.Close();
        }
    }

    class CurrencyServer
    {
        private static readonly object lockObject = new object();
        public void ArrancarMultiThread()
        {
            var requestCounter = 0;
            try
            {
                // Hacemos que el TcpListener escuche en host:port.
                IPAddress localAddr =
                IPAddress.Parse(ConfigurationManager.AppSettings["host"]);
                TcpListener server = new TcpListener(localAddr,
                Int32.Parse(ConfigurationManager.AppSettings["port"]));
                server.Start();
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    lock (lockObject)
                    {
                        requestCounter += 1;
                        Console.WriteLine(requestCounter);
                    }
                    Conversor procesoConversion = new Conversor(client);
                    Thread hiloProcesador = new Thread(
                    new ThreadStart(procesoConversion.ProcessRequest));
                    hiloProcesador.Start();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
        public void Arrancar()
        {
            try
            {
                // Hacemos que el TcpListener escuche en host:port.
                IPAddress localAddr =
                IPAddress.Parse(ConfigurationManager.AppSettings["host"]);
                TcpListener server = new TcpListener(localAddr,
                Int32.Parse(ConfigurationManager.AppSettings["port"]));
                server.Start();
                Byte[] bytes = new Byte[256];
                String data = null;
                while (true)
                {
                    // Se bloquea aceptando una petición de un
                    //TcpClient.
                    TcpClient client = server.AcceptTcpClient();
                    data = null;
                    NetworkStream stream = client.GetStream();
                    Int32 i = stream.Read(bytes, 0,
                    bytes.Length);
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i).Trim();
                    decimal numeroAConvertir;
                    var tipoConversion =
                    XmlConverter.ProcesarXmlConvertRequest(data, out numeroAConvertir);
                    if (tipoConversion == "USD-EUR")
                    {
                        numeroAConvertir *= Convert.ToDecimal(0.97);

                        data = XmlConverter.GenerarPaqueteXmlConvertResponse("EUR", numeroAConvertir.ToString());
                    }
                    else if (tipoConversion == "EUR-USD")
                    {
                        numeroAConvertir *= Convert.ToDecimal(1.03);
                        data = XmlConverter.GenerarPaqueteXmlConvertResponse("USD", numeroAConvertir.ToString());
                    }
                    else
                        data = XmlConverter.GenerarPaqueteXmlConvertResponseError(
                        "ERROR: Divisa no reconocida " + tipoConversion);
                    Byte[] msg =
                    System.Text.Encoding.ASCII.GetBytes(data);
                    stream.Write(msg, 0, msg.Length);
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
    }

}
