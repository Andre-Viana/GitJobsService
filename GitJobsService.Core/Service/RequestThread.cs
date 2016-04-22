using GitJobsService.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GitJobsService.Core.Service
{
    public class RequestThread
    {
        private ResponseListener listener;
        private string url;

        public RequestThread(ResponseListener listener, string url)
        {
            this.listener = listener;
            this.url = url;
        }

        public async void Run()
        { 
            string json = await DoRequest();
            List<Position> positions = JsonConvert.DeserializeObject<List<Position>>(json);
            if (listener != null)
            {
                listener.OnResult(positions); //O metodo em mainactivity
            }
        }

        private async Task<string> DoRequest() //aqui faz a requisicao web. Envia url pra  a api do github 
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(this.url));
            request.ContentType = "application/json";
            request.Method = "GET";
            string content = "";
            try
            {
                // Send the request to the server and wait for the response:
                WebResponse response = (HttpWebResponse) await request.GetResponseAsync();
                // Get a stream representation of the HTTP web response:
                StreamReader reader = new StreamReader(response.GetResponseStream());
                // Use this stream to get a String representation of the response:
                content = reader.ReadToEnd();
                
            }
            catch(WebException e) //classe de ecessao se tiver um erro de internet, pega ecessao e volta ensagem de erro.
            {
                throw new WebException("Something went wrong: " + e.Response);   
            }
            return content;
        }

    }
}
