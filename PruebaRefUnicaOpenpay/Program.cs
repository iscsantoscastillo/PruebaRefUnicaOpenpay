using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PruebaRefUnicaOpenpay
{
    class Program
    {
        static void Main(string[] args)
        {
            string API_KEY = "sk_8bb3937898db465e9c614958e2e4accb";
            string MERCHANT_ID = "mqg8qz3eglcfiqwviwnr";
            bool productivo = false;
            OpenpayAPI openpayAPI = new OpenpayAPI(API_KEY,MERCHANT_ID, productivo);
            string customer_id = "axeyb4lkq85b1xdvw1au";

            //Se crea el Cargo
            ChargeRequest charge = new ChargeRequest();
            charge.Method = "store";
            charge.Amount = 100;
            charge.Description = "Cargo a tienda";


            //Customer customer = new Customer();
            //customer.Name = "Net Client";
            //customer.LastName = "C#";
            //customer.Email = "net@c.com";
            //customer.Address = new Address();
            //customer.Address.Line1 = "line 1";
            //customer.Address.PostalCode = "12355";
            //customer.Address.City = "Queretaro";
            //customer.Address.CountryCode = "MX";
            //customer.Address.State = "Queretaro";

            //Customer customerCreated = openpayAPI.CustomerService.Create(customer); //customerCreated.Id	"axeyb4lkq85b1xdvw1au"	string

            //string customer_id = "axeyb4lkq85b1xdvw1au";
            //Customer customerObtenido = openpayAPI.CustomerService.Get(customer_id);//Sirve para obtener los datos del cliente.




            Charge ch = openpayAPI.ChargeService.Create(customer_id, charge);         
            
            Customer customerObtenido = openpayAPI.CustomerService.Get(customer_id);

            Console.WriteLine("HOLA");




            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://sandbox-api.openpay.mx/v1/9223372036854775808/customers"))
                {
                    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes("sk_8bb3937898db465e9c614958e2e4accb"));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                    request.Content = new StringContent("{\"name\":\"customer name\",\"email\": \"customer_email@me.com\",\"requires_account\": false}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = httpClient.SendAsync(request);

                    Console.ReadLine();
                }
            }

        }
    }
}
