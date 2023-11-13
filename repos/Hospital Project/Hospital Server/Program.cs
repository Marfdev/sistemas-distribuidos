using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using System.Xml;

namespace Hospital_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HospitalServer hospitalServer = new HospitalServer();
            hospitalServer.ArrancarMultiThread();
        }


        class HospitalServer
        {
            public static List<(string name, int space)> requestList = new List<(string name, int space)>();
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
                        ProcesadorCitas procesoCita = new ProcesadorCitas (client);
                        Thread hiloProcesador = new Thread(
                        new ThreadStart(procesoCita.procesarCita));
                        hiloProcesador.Start();
                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                }
            }
        }
        public class ProcesadorCitas
        {
            private TcpClient client = null;

            public ProcesadorCitas(TcpClient client)
            {
                this.client = client;
            }
            public void procesarCita()
            {
                Byte[] bytes = new Byte[256];
                string data = null;
                NetworkStream stream = client.GetStream();
                Int32 i = stream.Read(bytes, 0, bytes.Length);
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i).Trim();
                var cita = XmlConverter.ProcesarXmlConvertRequest(data);
                data = XmlConverter.GenerarPaqueteXmlConvertResponse(cita, HospitalServer.requestList);
                Byte[] msg =
            System.Text.Encoding.ASCII.GetBytes(data);
                stream.Write(msg, 0, msg.Length);
                client.Close();


            }
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
        public static string GenerarPaqueteXmlConvertResponse((string name, int space) requestedApntmnt, List<(string name, int space)> apntmntList)
        {
            string conclusion;

            if (apntmntList.FindIndex(x => x.space == requestedApntmnt.space) != -1)
            {
                conclusion = "LA CITA" + requestedApntmnt.space + " YA ESTÁ RESERVADA, INTENTE RESERVAR OTRA";
            }
            else
            {
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
