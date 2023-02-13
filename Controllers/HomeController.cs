using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Runtime.Serialization.Json;
using MyWebSite_Shop.Models;
using System.Collections.Generic;
using System.IO;
using RestSharp;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Hosting;

namespace MyWebSite_Shop.Controllers
{
   
    public class HomeController : Controller
    {
        
        public IActionResult TestMainPage()
        {
            string _command = "select top 10 Model.ModelName, Images.ImageName,ImagesPath.ImagesPath,Model.Cost,Model.Id from Model " +
                "inner join " +
                "Images on Images.Id=Model.ImageId " +
                "inner join ImagesPath on Images.PathId=ImagesPath.Id";
            var _connect = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=Multibrend;Trusted_Connection=True;");
            _connect.Open();
            var _commandSQL = new SqlCommand();
            _commandSQL.Connection = _connect;
            _commandSQL.CommandText = _command;
            var _reader = _commandSQL.ExecuteReader();
            var list = new List<Product>();

            
                for (int i = 0; i < 10; i++)
                {

                    _reader.Read();
                    list.Add(new Product()
                    {
                        ModelName = _reader.GetString(0),
                        ImageName = _reader.GetString(1),
                        ImagePath = _reader.GetString(2),
                        Cost = _reader.GetDecimal(3),
                        Id = _reader.GetInt32(4)

                    });
                }
                

            return View(list);

        }
        public IActionResult Autorisation()
        {
            return View();
        }
        public IActionResult Product_View(int id) 
        {

           
            var _connect = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=Multibrend;Trusted_Connection=True;");
            _connect.Open();
            var _commandSQL = new SqlCommand();
            var _parametr = new SqlParameter("product", id);
            _commandSQL.Connection = _connect;
            _commandSQL.Parameters.Add(_parametr);
            _commandSQL.CommandText = "select  Model.Id, Model.ModelName,Model.DescriptionModel, Images.ImageName,ImagesPath.ImagesPath,Model.Cost from Model " +
                "inner join " +
                "Images on Images.Id=Model.ImageId " +
                "inner join " +
                "ImagesPath on Images.PathId=ImagesPath.Id and Model.Id=@product";
            var _reader = _commandSQL.ExecuteReader();
            _reader.Read();
            
            var _choosedModel = new Product()
            {
                Id = _reader.GetInt32(0),
                ModelName = _reader.GetString(1),
                PathDescription = _reader.GetString(2),
                ImageName = _reader.GetString(3),
                ImagePath = _reader.GetString(4),
                Cost = _reader.GetDecimal(5),


            };
            
            var _reder = new FileStream(_choosedModel.PathDescription, FileMode.OpenOrCreate);
            var _seri = new DataContractJsonSerializer(typeof(ModelDescriptionJson[]));
            var _descriptionProduct = _seri.ReadObject(_reder) as ModelDescriptionJson[];
            ChoosedModel _model = new ChoosedModel {MetaDataProduct=_choosedModel, AboutProduct=_descriptionProduct };
            return View(_model);
        }
    }
}
