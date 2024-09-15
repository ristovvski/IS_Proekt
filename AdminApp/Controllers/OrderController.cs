﻿using ClosedXML.Excel;
using AdminApp.Models;
using GemBox.Document;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AdminApp.Controllers
{
        public class OrderController : Controller
        {
            public OrderController()
            {
                ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            }
            public IActionResult Index()
            {
                HttpClient client = new HttpClient();
                string URL = "https://isproject2024.azurewebsites.net/api/Admin/GetAllOrders";

                HttpResponseMessage response = client.GetAsync(URL).Result;
                var data = response.Content.ReadAsAsync<List<Order>>().Result;
                return View(data);
            }

            public IActionResult Details(string id)
            {
                HttpClient client = new HttpClient();
                string URL = "https://isproject2024.azurewebsites.net/api/Admin/GetDetails";
                var model = new
                {
                    Id = id
                };

                HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(URL, content).Result;

                var result = response.Content.ReadAsAsync<Order>().Result;


                return View(result);

            }



            public FileContentResult CreateInvoice(string id)
            {
                HttpClient client = new HttpClient();

                string URL = "https://isproject2024.azurewebsites.net/api/Admin/GetDetails";
                var model = new
                {
                    Id = id
                };

                HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(URL, content).Result;

                var result = response.Content.ReadAsAsync<Order>().Result;

                var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Invoice.docx");
                var document = DocumentModel.Load(templatePath);

                document.Content.Replace("{{OrderNumber}}", result.Id.ToString());
                document.Content.Replace("{{UserName}}", result.Owner.FirstName+" "+result.Owner.LastName);

                StringBuilder sb = new StringBuilder();
                decimal total = 0;
                foreach (var item in result.BooksInOrder)
                {
                    sb.AppendLine("Book " + item.Book.Title + " has quantity " + item.Quantity + " with price " + item.Book.Price);
                    total += (item.Quantity * item.Book.Price);
                }
                document.Content.Replace("{{ProductList}}", sb.ToString());
                document.Content.Replace("{{TotalPrice}}", total.ToString() + "$");

                var stream = new MemoryStream();
                document.Save(stream, new PdfSaveOptions());
                return File(stream.ToArray(), new PdfSaveOptions().ContentType, "ExportInvoice.pdf");

            }

            [HttpGet]
            public FileContentResult ExportAllOrders()
            {
                string fileName = "Orders.xlsx";
                string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                using (var workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet = workbook.Worksheets.Add("Orders");
                    worksheet.Cell(1, 1).Value = "OrderID";
                    worksheet.Cell(1, 2).Value = "Customer Name";
                    worksheet.Cell(1, 3).Value = "Total Price";
                    HttpClient client = new HttpClient();
                    string URL = "https://isproject2024.azurewebsites.net/api/Admin/GetAllOrders";

                    HttpResponseMessage response = client.GetAsync(URL).Result;
                    var data = response.Content.ReadAsAsync<List<Order>>().Result;

                    for (int i = 0; i < data.Count(); i++)
                    {
                        var item = data[i];
                        worksheet.Cell(i + 2, 1).Value = item.Id.ToString();
                        worksheet.Cell(i + 2, 2).Value = item.Owner.FirstName + " " + item.Owner.LastName;
                        decimal total = 0;
                        for (int j = 0; j < item.BooksInOrder.Count(); j++)
                        {
                            worksheet.Cell(1, 4 + j).Value = "Book - " + (j + 1);
                            worksheet.Cell(i + 2, 4 + j).Value = item.BooksInOrder.ElementAt(j).Book.Title + ": " +item.BooksInOrder.ElementAt(j).Quantity;
                            total += (item.BooksInOrder.ElementAt(j).Quantity * item.BooksInOrder.ElementAt(j).Book.Price);
                        }
                        worksheet.Cell(i + 2, 3).Value = total;
                    }
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, contentType, fileName);
                    }
                }

            }
        }
}
