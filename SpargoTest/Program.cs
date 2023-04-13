using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;
using static SpargoTest.Services.Authorization;
using static SpargoTest.Services.GettingGoods;
using static SpargoTest.Services.JSONConvert;
using Newtonsoft.Json.Converters;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using SpargoTest.Models;

namespace ConsoleClient
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Введите логин:");
            string userName = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            string password = Console.ReadLine();

            var registerResult = Authorize(userName, password);

            Console.WriteLine("Авторизация: {0}", registerResult);

            Console.WriteLine();
            Console.WriteLine("Введите идентификатор департамента:");
            string department = Console.ReadLine();
            GoodsModel[] goodsModels = FromJson(GetGoods(token, department));

            using (StreamWriter writer = new StreamWriter("Goods.txt", false))
            {
                foreach (var goodsModel in goodsModels)
                {
                    writer.WriteLine($"Уникальный идентификатор товара по единому справочнику F3bus: {goodsModel.RefId}");
                    writer.WriteLine($"Уникальный код товара по справочнику аптеки: {goodsModel.Code}");
                    writer.WriteLine($"Наименование товара: {goodsModel.Name}");
                    writer.WriteLine($"Производитель: {goodsModel.Producer}");
                    writer.WriteLine($"Страна происхождения: {goodsModel.Country}");
                    writer.WriteLine($"Штрихкод товара: {goodsModel.Barcodes} ");
                    writer.WriteLine($"goodsGroupCodes: {goodsModel.GoodsGroupCodes} ");
                    writer.WriteLine($"МНН (англ.): {goodsModel.MnnEn}");
                    writer.WriteLine($"МНН (рус.): {goodsModel.MnnRu}");
                    writer.WriteLine($"Версия объекта: {goodsModel.Rv}");
                    writer.WriteLine($"Дата создания записи: {goodsModel.Created}");
                    writer.WriteLine();
                }
            }

            Console.Write("Файл успешно сохранился");
            Console.Read();
        }
       




    }
}