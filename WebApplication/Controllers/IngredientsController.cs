using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class IngredientsController : Controller
    {
        private SqlConnection connect = null;
        public string connectionstring = "Data Source=DESKTOP-28KMSTV\\SQLEXPRESS;Initial Catalog=СУБД;Integrated Security=True";
        public Ingredients GetValuesofID(int? Id)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;   // создание объекта для выполнения хранимой процедуры
            cmd.CommandText = "SelectIngredients";                        // указание имени хранимой процедуры, которую нужно выполнить
            cmd.Parameters.Add(new SqlParameter("@ID", Id));             // добавление параметра хранимой процедуры
            connect.Open();
            SqlDataReader getvalues = cmd.ExecuteReader();
            Ingredients ingredients = new Ingredients();
            if (getvalues.HasRows)       // проверка, есть ли строки в результате выполнения хранимой процедуры
            {
                while (getvalues.Read())
                {  // присвоение свойств объекта Ingredients значениям из результатов выполнения хранимой процедуры
                    ingredients.Id = (short)(getvalues[0]);
                    ingredients.Product = (short)(getvalues[1]);
                    ingredients.RawMaterials = (short?)(getvalues[2]);
                    ingredients.Countingred = (float)(getvalues[3]);
                }
            }
            getvalues.Close();
            connect.Close();

            return ingredients;

        }

        public List<Finproducts> GetValuesofFinproducts()
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;  // устанавливает имя хранимой процедуры в качестве текста команды
            cmd2.CommandText = "SelectAllFinproducts";
            connect.Open();
            SqlDataReader getvalues = cmd2.ExecuteReader();
            List<Finproducts> finproducts = new List<Finproducts>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    finproducts.Add(new Finproducts()
                    {
                        Id = (short)getvalues[0],
                        Name = getvalues[1].ToString(),
                        Unit = (short)getvalues[2],
                        Sum = Convert.ToDecimal(getvalues[3]),
                        Countproducts = (float)getvalues[4],
                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return finproducts;
        }
        public List<Finproducts> GetValuesofFinproductsID(int ID)
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.CommandText = "SelectFinproducts";
            cmd2.Parameters.Add(new SqlParameter("@ID", ID));
            connect.Open();
            SqlDataReader getvalues = cmd2.ExecuteReader();
            List<Finproducts> finproducts = new List<Finproducts>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    finproducts.Add(new Finproducts()
                    {
                        Id = (short)getvalues[0],
                        Name = getvalues[1].ToString(),
                        Unit = (short)getvalues[2],
                        Sum = Convert.ToDecimal(getvalues[3]),
                        Countproducts = (float)getvalues[4],
                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return finproducts;
        }

        public List<Rawmaterials> GetValuesofRawmaterials()
        {
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.CommandText = "SelectAllRawmaterials";
            connect.Open();
            SqlDataReader getvalues = cmd2.ExecuteReader();
            List<Rawmaterials> rawmaterials = new List<Rawmaterials>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {

                    rawmaterials.Add(new Rawmaterials()
                    {

                        Id = (short)getvalues[0],
                        Name = getvalues[1].ToString(),
                        Unit = (short)getvalues[2],
                        Sum = Convert.ToDecimal(getvalues[3]),
                        CountRawm = (float)getvalues[4],

                    });
                }
            }
            getvalues.Close();
            connect.Close();
            return rawmaterials;
        }

        // GET: Ingredients
        public async Task<IActionResult> Index(int AllingrString) 
        {
            connect = new SqlConnection(connectionstring);
            Finproducts finproducts = new Finproducts();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.CommandText = "SelectAllFinproducts";
            connect.Open();
            SqlDataReader getvalues2 = cmd2.ExecuteReader();
            List<Finproducts> finproducts1 = new List<Finproducts>();
            if (getvalues2.HasRows)
            {
                while (getvalues2.Read())
                {
                    finproducts1.Add(new Finproducts()
                    {
                        Id = (short)getvalues2[0],
                        Name = getvalues2[1].ToString(),
                        Unit = (short)getvalues2[2],
                        Sum = Convert.ToDecimal(getvalues2[3]),
                        Countproducts = (float)getvalues2[4],
                    });
                }
            }
            getvalues2.Close();


            Rawmaterials rawmaterials = new Rawmaterials();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = connect;
            cmd3.CommandType = System.Data.CommandType.StoredProcedure;
            cmd3.CommandText = "SelectAllRawmaterials";

            SqlDataReader getvalues3 = cmd3.ExecuteReader();
            List<Rawmaterials> rawmaterials1 = new List<Rawmaterials>();
            if (getvalues3.HasRows)
            {
                while (getvalues3.Read())
                {
                    rawmaterials1.Add(new Rawmaterials()
                    {
                        Id = (short)getvalues3[0],
                        Name = getvalues3[1].ToString(),
                        Unit = (short)getvalues3[2],
                        Sum = Convert.ToDecimal(getvalues3[3]),
                        CountRawm = (float)getvalues3[4],
                    });
                }
            }
            getvalues3.Close();


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SelectAllIngredients";
            SqlDataReader getvalues = cmd.ExecuteReader();
            List<Ingredients> ingredients = new List<Ingredients>();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())
                {
                    foreach (Finproducts val in finproducts1)
                    {
                        foreach (Rawmaterials val2 in rawmaterials1)
                        {
                            if (val.Id == (short?)(getvalues[1]) && val2.Id == (short?)(getvalues[2]))
                            {
                                finproducts = val;
                                rawmaterials = val2;
                                ingredients.Add(new Ingredients()
                                {
                                    Id = (short)(getvalues[0]),
                                    Product = (short)(getvalues[1]),
                                    RawMaterials = (short)getvalues[2],
                                    Countingred = (float)(getvalues[3]),
                                    ProductNavigation = finproducts,
                                    RawMaterialsNavigation = rawmaterials,
                                });
                            }
                        }

                    }
                }
            }




            if (AllingrString == 0)
            {
                getvalues.Close();

                connect.Close();
                var FinproductsList = GetValuesofFinproducts();
                ViewData["Product"] = new SelectList(FinproductsList, "Id", "Name");

                return View(ingredients);
            }
            else
            {
                getvalues.Close();
                SqlCommand cmdf = new SqlCommand();
                cmdf.Connection = connect;
                cmdf.CommandType = System.Data.CommandType.StoredProcedure;
                cmdf.CommandText = "FilterOfingr";               //указание имени хранимой процедуры, которую нужно выполнить.
                cmdf.Parameters.Add(new SqlParameter("@Search", AllingrString));
                SqlDataReader getvalues4 = cmdf.ExecuteReader(); //выполнение хранимой процедуры и получение результата в виде объекта SqlDataReader
                List<Ingredients> ingredients1 = new List<Ingredients>();
                if (getvalues4.HasRows)               // Проверка на наличие строк в результате выполнения хранимой процедуры
                {
                    while (getvalues4.Read())
                    {
                        foreach (Finproducts val in finproducts1)   //перебор элементов списка
                        {
                            foreach (Rawmaterials val2 in rawmaterials1)
                            {   // Сравнение значений свойств объектов Finproducts и Rawmaterials с значениями, полученными из хранимой процедуры
                                if (val.Id == (short?)(getvalues4[1]) && val2.Id == (short?)(getvalues4[2]))
                                {
                                    finproducts = val;
                                    rawmaterials = val2;
                                    ingredients1.Add(new Ingredients()   // Добавление нового объекта Ingredients в список
                                    {
                                        Id = (short)(getvalues4[0]),
                                        Product = (short)(getvalues4[1]),
                                        RawMaterials = (short)getvalues4[2],
                                        Countingred = (float)(getvalues4[3]),
                                        ProductNavigation = finproducts,
                                        RawMaterialsNavigation = rawmaterials,
                                    });
                                }
                            }

                        }
                    }
                }
                getvalues4.Close();
                connect.Close();
                var FinproductsList = GetValuesofFinproducts();
                ViewData["Product"] = new SelectList(FinproductsList, "Id", "Name");

                return View(ingredients1);  // Возврат представления с передачей списка объектов Ingredients
            }

        }


        // GET: Ingredients/Create
        public IActionResult Create(int ID)
        {
            var Product = GetValuesofFinproducts();
            var ProductID = GetValuesofFinproductsID(ID);
            var Rawmaterial = GetValuesofRawmaterials();
            if (ID == 0)
            {
                ViewData["Product"] = new SelectList(Product, "Id", "Name");
                ViewData["RawMaterials"] = new SelectList(Rawmaterial, "Id", "Name");
            }
            else
            {
                ViewData["Product"] = new SelectList(Product.Where(e => e.Id == ID), "Id", "Name");
                ViewData["RawMaterials"] = new SelectList(Rawmaterial, "Id", "Name");
            }
            return View();
        }
        // POST: Ingredients/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,Product,RawMaterials,Countingred")] Ingredients ingredients)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        connect = new SqlConnection(connectionstring);
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = connect;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "InsertIngredients";
                        cmd.Parameters.Add(new SqlParameter("@Product", ingredients.Product));   // Добавляем параметры для вызова хранимой процедуры
                        cmd.Parameters.Add(new SqlParameter("@RawMaterials", ingredients.RawMaterials));
                        cmd.Parameters.Add(new SqlParameter("@Countingred", ingredients.Countingred));
                        connect.Open();
                        cmd.ExecuteNonQuery();   // Выполняем команду на добавление новой записи в таблицу Ingredients

                        connect.Close();
                        int ID = Convert.ToInt32(ingredients.Product);  // Получаем ID продукта для перенаправления пользователя на страницу со списком ингредиентов данного продукта
                    return RedirectToAction("Index", new { allingrString = ID }); 
                    }
            }
                catch (SqlException ex)    // внутри этого блока выполняется, если возникает исключение
            {
                    // Формирование текста ошибки с указанием значения ключа, вызвавшего ошибку
                    string errorMessage = $"Ошибка:Не может добавить";

            // Сохранение сообщения об ошибке в TempData
            TempData["ErrorMessage"] = errorMessage;
                }

                var Productlist = GetValuesofFinproducts();
                var result = GetValuesofID(ingredients.Id);
                var RawMaterialstlist = GetValuesofRawmaterials();
                ViewData["Product"] = new SelectList(Productlist, "Id", "Name", result.Product);
                ViewData["RawMaterials"] = new SelectList(RawMaterialstlist, "Id", "Name", result.RawMaterials);
                return View(result);
            }

        // GET: Ingredients/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Productlist = GetValuesofFinproducts();
            var result = GetValuesofID(id);
            int ProductID = (int)result.Product;
            var RawMaterialstlist = GetValuesofRawmaterials();
            if (result == null)
            {
                return NotFound();
            }

            var Product = GetValuesofFinproducts();

            ViewData["Product"] = new SelectList(Product.Where(e => e.Id == ProductID), "Id", "Name");
            ViewData["RawMaterials"] = new SelectList(RawMaterialstlist, "Id", "Name", result.RawMaterials);
            return View(result);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,Product,RawMaterials,Countingred")] Ingredients ingredients)
        {
            if (id != ingredients.Id)
            {
                return NotFound();
            }
            var result = GetValuesofID(id);
            if (ModelState.IsValid)
            {


                connect = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateIngredients";
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.Parameters.Add(new SqlParameter("@Product", ingredients.Product));
                cmd.Parameters.Add(new SqlParameter("@RawMaterials", ingredients.RawMaterials));
                cmd.Parameters.Add(new SqlParameter("@Countingred", ingredients.Countingred));
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                int ID = Convert.ToInt32(ingredients.Product);
                return RedirectToAction("Index", new { allingrString = ID });

            }
            var Productlist = GetValuesofFinproducts();

            var RawMaterialstlist = GetValuesofRawmaterials();
            ViewData["Product"] = new SelectList(Productlist, "Id", "Name", result.Product);
            ViewData["RawMaterials"] = new SelectList(RawMaterialstlist, "Id", "Name", result.RawMaterials);
            return View(result);
        }

        // GET: Ingredients/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Получаем запись, которую хотим удалить, из базы данных

            var result = GetValuesofID(id);
            connect = new SqlConnection(connectionstring);     // Устанавливаем соединение с базой данных
            SqlCommand cmd = new SqlCommand();               // Создаем объект SqlCommand для выполнения хранимой процедуры SelectFinproducts, которая возвращает информацию о конечном продукте по его ID
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SelectFinproducts";
            cmd.Parameters.Add(new SqlParameter("@ID", result.Product));
            connect.Open();      //// Открываем соединение с базой данных и выполняем запрос на получение информации о конечном продукте
            SqlDataReader getvalues = cmd.ExecuteReader();    // Создаем объект класса Finproducts для хранения информации о конечном продукте
            Finproducts finproducts = new Finproducts();
            if (getvalues.HasRows)
            {
                while (getvalues.Read())       // Если запрос вернул записи, то считываем информацию о конечном продукте и сохраняем ее в объект класса Finproducts
                {
                    finproducts.Id = (short)getvalues[0];
                    finproducts.Name = getvalues[1].ToString();
                    finproducts.Unit = (short)getvalues[2];
                    finproducts.Sum = Convert.ToDecimal(getvalues[3]);
                    finproducts.Countproducts = (float)getvalues[4];
                }
            }
            getvalues.Close();        // Создаем объект SqlCommand для выполнения хранимой процедуры SelectRawmaterials, которая возвращает информацию о сырье по его ID

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = connect;
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            cmd2.CommandText = "SelectRawmaterials";
            cmd2.Parameters.Add(new SqlParameter("@ID", result.RawMaterials));  // Выполняем запрос на получение информации о сырье

            SqlDataReader getvalues2 = cmd2.ExecuteReader();  
            Rawmaterials rawmaterials = new Rawmaterials();    // Создаем объект класса Rawmaterials для хранения информации о сырье
            if (getvalues2.HasRows)
            {                                      // Если запрос вернул записи, то считываем информацию о сырье и сохраняем ее в объект класса Rawmaterials
                while (getvalues2.Read())
                {
                    rawmaterials.Id = (short)getvalues2[0];
                    rawmaterials.Name = getvalues2[1].ToString();
                    rawmaterials.Unit = (short)getvalues2[2];
                    rawmaterials.Sum = Convert.ToDecimal(getvalues2[3]);
                    rawmaterials.CountRawm = (float)getvalues2[4];
                }
            }
            getvalues2.Close();
            connect.Close();
            if (result == null)
            {
                return NotFound();     // Если запись не найдена, возвращаем ошибку NotFound
            }
            result.ProductNavigation = finproducts;   // Связываем конечный продукт и сырье с записью, которую хотим удалить
            result.RawMaterialsNavigation = rawmaterials;
            return View(result);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var result = GetValuesofID(id);
            int ID = (int)result.Product;
            connect = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "DeleteIngredients";
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
            return RedirectToAction("Index", new { allingrString = ID });
        }
    }
}

