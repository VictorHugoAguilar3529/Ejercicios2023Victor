using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NEstatusAlumnos
    {
        private static readonly HttpClient cliente = new HttpClient();
        string UrlwebApi = ConfigurationManager.AppSettings["urlWebApi"];

        public NEstatusAlumnos()
        {

        }

        public List<EstatusAlumnos> Consultar()
        {
            var estatus = new List<EstatusAlumnos>();
            try
            {
                //inicio el objeto HTTP Client
                using (var client = new HttpClient())
                {
                    Task<HttpResponseMessage> responseTask = client.GetAsync(UrlwebApi);

                    responseTask.Wait();

                    HttpResponseMessage result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        Task<string> readTask = result.Content.ReadAsStringAsync();

                        readTask.Wait();

                        string json = readTask.Result;

                        estatus = JsonConvert.DeserializeObject<List<EstatusAlumnos>>(json);
                    }
                    else
                    {
                        throw new Exception($"WebAPI. Respondio con error.{result.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"WebAPI. Respondio con error.{ex.Message}");
            }
            return estatus;
        }




        public EstatusAlumnos Consultar(int id)
        {
            EstatusAlumnos estatus = null;
            try
            {
                //inicio el objeto HTTP Client
                using (var client = new HttpClient())
                {
                    var responseTask = client.GetAsync(UrlwebApi + $"/{id}");

                    responseTask.Wait();

                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        Task<string> readTask = result.Content.ReadAsStringAsync();

                        readTask.Wait();

                        string json = readTask.Result;

                        estatus = JsonConvert.DeserializeObject<EstatusAlumnos>(json);
                    }
                    else
                    {
                        throw new Exception($"WebAPI. Respondio con error.{result.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"WebAPI. Respondio con error.{ex.Message}");
            }
            return estatus;
        }





        public EstatusAlumnos Agregar(EstatusAlumnos estatusAlumnos)
        {
            try
            {
                //inicio el objeto HTTP Client
                using (var client = new HttpClient())
                {
                    HttpContent httpContent =new StringContent(JsonConvert.SerializeObject(estatusAlumnos), Encoding.UTF8);

                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    Task<HttpResponseMessage> postTask = client.PostAsync(UrlwebApi, httpContent );

                    postTask.Wait();

                    HttpResponseMessage result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        Task<string> readTask = result.Content.ReadAsStringAsync();

                        readTask.Wait();

                        string json = readTask.Result;

                        estatusAlumnos = JsonConvert.DeserializeObject<EstatusAlumnos>(json);
                    }
                    else
                    {
                        throw new Exception($"WebAPI. Respondio con error.{result.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"WebAPI. Respondio con error.{ex.Message}");
            }

            return estatusAlumnos;
        }



        public void Actualizar(EstatusAlumnos estatusAlumnos, int id)
        {
            try
            {
                //inicio el objeto HTTP Client
                using (var client = new HttpClient())
                {
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(estatusAlumnos), Encoding.UTF8);

                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    Task<HttpResponseMessage> postTask = client.PutAsync(UrlwebApi + $"/{id}", httpContent);

                    postTask.Wait();

                    HttpResponseMessage result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        Task<string> readTask = result.Content.ReadAsStringAsync();

                        readTask.Wait();

                        string json = readTask.Result;

                        estatusAlumnos = JsonConvert.DeserializeObject<EstatusAlumnos>(json);
                    }
                    else
                    {
                        throw new Exception($"WebAPI. Respondio con error.{result.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"WebAPI. Respondio con error.{ex.Message}");
            }

        }


        public void ELiminar(int id)
        {
            EstatusAlumnos estatus = null;
            try
            {
                //inicio el objeto HTTP Client
                using (var client = new HttpClient())
                {
                    var responseTask = client.DeleteAsync(UrlwebApi + $"/{id}");

                    responseTask.Wait();

                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        Task<string> readTask = result.Content.ReadAsStringAsync();

                        readTask.Wait();

                        string json = readTask.Result;

                        estatus = JsonConvert.DeserializeObject<EstatusAlumnos>(json);
                    }
                    else
                    {
                        throw new Exception($"WebAPI. Respondio con error.{result.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"WebAPI. Respondio con error.{ex.Message}");
            }

        }
    }
}