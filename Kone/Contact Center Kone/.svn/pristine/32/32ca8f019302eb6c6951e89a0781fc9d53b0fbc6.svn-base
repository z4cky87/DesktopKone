using Contact_Center_Kone.Utility;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
    public class ProductDao
    {
        public Paging myPaging = new Paging();
        private Utility.DbMyConnection myConn = new Utility.DbMyConnection();

        string orderBy = " order by productname asc";

        #region query
        public string SqlFilter(string productType, string productName, string technology)
        {
            var result = SqlSelect();
            NameValueCollection nvc = new NameValueCollection();

            if (!string.IsNullOrEmpty(productType)) { nvc.Add("pdt.name", productType); }
            if (!string.IsNullOrEmpty(productName)) { nvc.Add("pd.name", productName); }
            if (!string.IsNullOrEmpty(technology)) { nvc.Add("pd.technology", technology); }           

            for (int i = 0; i < nvc.Count; i++)
            {
                if (i == 0) 
                {
                    if (nvc.GetKey(i) == "pd.name")
                    { result +=  " where " + nvc.GetKey(i) + " like '%" + nvc[i] + "%'"; }
                    else
                    { result +=  " where " + nvc.GetKey(i) + "='" + nvc[i] + "'"; }
                }
                else if (nvc.GetKey(i) == "pd.name")
                { result +=  " and " + nvc.GetKey(i) + " like '%" + nvc[i] + "%'"; }
                else
                { result +=   " and " + nvc.GetKey(i) + "='" + nvc[i] + "'"; }            
            }                     
            return result;      
           
        }
        public string SqlFilterCount(string productType, string productName, string technology)
        {
            var result = SqlSelectCount();
            NameValueCollection nvc = new NameValueCollection();

            if (!string.IsNullOrEmpty(productType)) { nvc.Add("pdt.name", productType); }
            if (!string.IsNullOrEmpty(productName)) { nvc.Add("pd.name", productName); }
            if (!string.IsNullOrEmpty(technology)) { nvc.Add("pd.technology", technology); }

            for (int i = 0; i < nvc.Count; i++)
            {
                if (i == 0)
                {
                    if (nvc.GetKey(i) == "pd.name")
                    { result += " where " + nvc.GetKey(i) + " like '%" + nvc[i] + "%'"; }
                    else
                    { result += " where " + nvc.GetKey(i) + "='" + nvc[i] + "'"; }
                }
                else if (nvc.GetKey(i) == "pd.name")
                { result += " and " + nvc.GetKey(i) + " like '%" + nvc[i] + "%'"; }
                else
                { result += " and " + nvc.GetKey(i) + "='" + nvc[i] + "'"; }
            }
            return result;      
        }
        public string SqlSelect()
        {
            return "select 	 pd.id," +
                                        "pdt.name as 'producttypename'," +
                                        "pd.name as 'productname'," +
                                        "pd.technology as 'technology'," +
                                        "pd.price as 'price'," +
                                        "pd.warranty as 'warranty'," +
                                        "pd.qty as 'quantity'," +
                                        "pd.is_active as 'isactive'" +
                             " from cc_products as pd left join cc_product_types as pdt" +
                             " on pd.product_type_id=pdt.id";
        }
        public string SqlSelectCount()
        {
            return "select 	 count(*)"+
                             " from cc_products as pd left join cc_product_types as pdt" +
                             " on pd.product_type_id=pdt.id";
        }
        #endregion
        public bool Insert(Entity.Product myProduct)
        {
            lock (Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "insert into cc_products set " +
                                        "product_type_id=@producttype," +
                                        "name=@name," +
                                        "technology=@technology," +
                                        "price=@price," +
                                        "warranty=@warranty," +
                                        "qty=@qty," +
                                        "is_active=@isactive";

                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@producttype", myProduct.productType.id);
                        myConn.MyCommand.Parameters.AddWithValue("@name", myProduct.name);
                        myConn.MyCommand.Parameters.AddWithValue("@technology", myProduct.technology);
                        myConn.MyCommand.Parameters.AddWithValue("@price", myProduct.price);
                        myConn.MyCommand.Parameters.AddWithValue("@warranty", myProduct.warranty);
                        myConn.MyCommand.Parameters.AddWithValue("@qty", myProduct.qty);
                        myConn.MyCommand.Parameters.AddWithValue("@isactive", myProduct.isActive);
                        result = (myConn.MyCommand.ExecuteNonQuery() == 1);
                    };

                }
                catch (Exception ex) { Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
                finally
                {
                    myConn.MyConn.Close();
                }
                return result;
            }
        }
        public bool Update(Entity.Product myProduct)
        {
            lock (Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "update cc_products set " +
                                         "product_type_id=@producttype," +
                                         "name=@name," +
                                         "technology=@technology," +
                                         "price=@price," +
                                         "warranty=@warranty," +
                                         "qty=@qty," +
                                         "is_active=@isactive" +
                                         " where id=@id";

                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@producttype", myProduct.productType.id);
                        myConn.MyCommand.Parameters.AddWithValue("@name", myProduct.name);
                        myConn.MyCommand.Parameters.AddWithValue("@technology", myProduct.technology);
                        myConn.MyCommand.Parameters.AddWithValue("@price", myProduct.price);
                        myConn.MyCommand.Parameters.AddWithValue("@warranty", myProduct.warranty);
                        myConn.MyCommand.Parameters.AddWithValue("@qty", myProduct.qty);
                        myConn.MyCommand.Parameters.AddWithValue("@isactive", myProduct.isActive);
                        myConn.MyCommand.Parameters.AddWithValue("@id", myProduct.id);
                        result = (myConn.MyCommand.ExecuteNonQuery() == 1);
                    }

                }
                catch (Exception ex)
                { Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
                finally
                {
                    myConn.MyConn.Close();
                }
                return result;
            }
        }
        public bool Delete(Entity.Product myProduct)
        {
            lock (Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "delete from cc_products where id=@id";

                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@id", myProduct.id);
                    }
                    result = (myConn.MyCommand.ExecuteNonQuery() == 1);
                }
                catch (Exception ex)
                {
                    Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
                }
                finally
                {
                    myConn.MyConn.Close();
                }
                return result;
            }
        }
        public List<Entity.Product> GetAll()
        {
            lock (Global.ThreadLockDao)
            {
                var products = new List<Entity.Product>();
                try
                {

                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(myPaging.SqlLoaddata + orderBy + " LIMIT " + myPaging.Startindex + "," + myPaging.BatasData, myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {
                                products.Add(new Entity.Product()
                                {
                                    id = Convert.ToInt32(myConn.MyReader["id"]),
                                    productType = new Entity.ProductType() { name = myConn.MyReader["producttypename"].ToString() },
                                    name = myConn.MyReader["productname"].ToString(),
                                    technology = myConn.MyReader["technology"].ToString(),
                                    price = Convert.ToDouble(myConn.MyReader["price"]).ToString("N"),
                                    warranty = Convert.ToInt32(myConn.MyReader["warranty"].ToString()) == 1 ? myConn.MyReader["warranty"].ToString() + " year" : myConn.MyReader["warranty"].ToString() + " years",
                                    qty = myConn.MyReader["quantity"].ToString(),
                                    isActive = Convert.ToInt32(myConn.MyReader["isactive"]) == 1 ? "Yes" : "No"
                                });
                            };
                        };
                    }

                }
                catch (Exception ex)
                {
                    Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
                }
                finally { myConn.MyConn.Close(); }
                return products;
            }
        }  
        public Entity.Product GetById(string id)
        {
            lock (Global.ThreadLockDao)
            {
                var product = new Entity.Product();
                try
                {
                    var query = "select 	 pd.id," +
                                            "pdt.name as 'producttypename'," +
                                            "pd.name as 'productname'," +
                                            "pd.technology as 'technology'," +
                                            "pd.price as 'price'," +
                                            "pd.warranty as 'warranty'," +
                                            "pd.qty as 'quantity'," +
                                            "pd.is_active as 'isactive'" +
                                 " from cc_products as pd left join cc_product_types as pdt" +
                                 " on pd.product_type_id=pdt.id" +
                                 " where pd.id='" + id + "'";



                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query.ToString(), myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {

                                product.id = Convert.ToInt32(myConn.MyReader["id"]);
                                product.productType = new Entity.ProductType() { name = myConn.MyReader["producttypename"].ToString() };
                                product.name = myConn.MyReader["productname"].ToString();
                                product.technology = myConn.MyReader["technology"].ToString();
                                product.price = myConn.MyReader["price"].ToString();
                                product.warranty = myConn.MyReader["warranty"].ToString();
                                product.qty = myConn.MyReader["quantity"].ToString();
                                product.isActive = Convert.ToInt32(myConn.MyReader["isactive"]) == 1 ? "Yes" : "No";

                            };
                        };
                    }

                }
                catch (Exception ex)
                {
                    Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
                }
                finally { myConn.MyConn.Close(); }
                return product;
            }
        }
    }
}
