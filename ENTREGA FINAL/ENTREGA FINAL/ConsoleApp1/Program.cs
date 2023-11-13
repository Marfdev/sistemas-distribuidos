using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Xml;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.start();

        }

        public class Server
        {

            public async void start() {
                
            }

        }

        public class BlogService {
            private TcpClient newclient = null;

            public static Post currentPost;
            public static string base_url = ConfigurationSettings.AppSettings["REST_URI"];
            public HttpClient client = new HttpClient();
            
            public BlogService(TcpClient newclient)
            {
                this.newclient = newclient;
            }
            public async void GetPost( int postid)
            {
                client.BaseAddress = new Uri(base_url);
                string urlParameters = "/posts/"+ postid;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                List<Comment> comments;
                Post post;
                SuperPost sup = new SuperPost(1, 1, "psot", "body", new List<Comment>() );
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var dataObjectsPost = await response.Content.ReadAsStringAsync();  //Make sure to add a reference to System.Net.Http.Formatting.dll
                    post = JsonConvert.DeserializeObject<Post>(dataObjectsPost);
                    sup.Id= post.Id;
                    sup.userId = post.userId;
                    sup.title = post.title;
                    sup.body = post.body;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
                urlParameters = "/posts/" + postid + "/comments" ;
                HttpResponseMessage response2 = client.GetAsync(urlParameters).Result;
                if (response2.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var dataObjectsComments = await response2.Content.ReadAsStringAsync();  //Make sure to add a reference to System.Net.Http.Formatting.dll
                    comments = JsonConvert.DeserializeObject<List<Comment>>(dataObjectsComments);
                    sup.comments = comments;
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response2.StatusCode, response2.ReasonPhrase);
                }

                


                Byte[] bytes = new Byte[256];
                string data = null;
                NetworkStream stream = newclient.GetStream();
                Int32 i = stream.Read(bytes, 0, bytes.Length);
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i).Trim();
                
                data = XmlConverter.GenerarPaqueteXmlConvertResponse(sup);
                Byte[] msg =
            System.Text.Encoding.ASCII.GetBytes(data);
                stream.Write(msg, 0, msg.Length);
                newclient.Close();


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
        public static string GenerarPaqueteXmlConvertResponse(SuperPost superPost)
        {
            
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
