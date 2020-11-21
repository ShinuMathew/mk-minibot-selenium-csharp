using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Restful;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Json.NET;
using Json.NET.Web;
using System.Xml;
using System.IO;
using System.Collections;
using System.Linq.Expressions;
using System.Linq;


namespace TestFramework.CommonActions
{
    class APIResponses
    {
        public static void GetAllProductsOOPS()
        {
            List<String> validProduct = new List<string>();
            List<MarketSkus> wdAllProducts = new List<MarketSkus>();
            List<oosProducts> wdoutOfStock = new List<oosProducts>();

            System.DateTime OrderDate;
            //GetOrderDate service response
            RestClient client = new RestClient("http://wddceqcaapi01:18929");

            RestRequest getOrderDate = new RestRequest("/orders/orderdate");

            getOrderDate.Method = Method.GET;
            getOrderDate.AddParameter("languages", "en-CA");
            getOrderDate.AddParameter("SubsidiaryCode", "CA");

            IRestResponse getOrderDateResponse = client.Execute(getOrderDate);
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("GetOrderDate service requested");
            Console.WriteLine("*****************************************************************");

            dynamic d = JObject.Parse(getOrderDateResponse.Content);

            String Date = d.OrderDateLocal;
            OrderDate = Convert.ToDateTime(Date);

            //GetOutOfStock service response.
            RestClient client1 = new RestClient("http://wddceqcaapi01:18929");

            RestRequest getOutOfStockRequest = new RestRequest("/inventory/OutOfStock");

            getOutOfStockRequest.Method = Method.GET;
            getOutOfStockRequest.AddParameter("languages", "en-CA");
            getOutOfStockRequest.AddParameter("SubsidiaryCode", "CA");

            IRestResponse getOutOfStockResponse = client1.Execute(getOutOfStockRequest);
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("GetOutOfStockProduct service requested");
            Console.WriteLine("*****************************************************************");

            //Console.WriteLine(getOutOfStockResponse.StatusCode);
            //Console.WriteLine(getOutOfStockResponse.Content);
            dynamic d1 = JObject.Parse(getOutOfStockResponse.Content);
            int i = 1;
            try
            {
                while (true)
                {
                    wdoutOfStock.Add(new oosProducts() { skuID = d1.ProductsStatus[i].Sku.ToString() });
                    i++;
                }
            }
            catch (Exception e)
            {

            }

            //GetproductsByLanguage service response.
            RestClient client2 = new RestClient("http://wddceqglws21:18961");

            RestRequest getProductsByLanguageRequest = new RestRequest("/products/findbylanguage");

            getProductsByLanguageRequest.Method = Method.GET;
            getProductsByLanguageRequest.AddParameter("languages", "en-CA");
            getProductsByLanguageRequest.AddParameter("SubsidiaryCode", "CA");
            getProductsByLanguageRequest.AddParameter("PageSize", "1500");

            IRestResponse getProductsByLanguageResponse = client2.Execute(getProductsByLanguageRequest);
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("GetProductsByLanguage service requested");
            Console.WriteLine("*****************************************************************");

            dynamic d2 = JObject.Parse(getProductsByLanguageResponse.Content);

            Console.WriteLine("The GetProductsByLanguage service response is: {0}", getProductsByLanguageResponse.StatusCode);

            String NoOfProducts = d2.Total.ToString();

            int TotalProducts = Convert.ToInt32(NoOfProducts);
            int productsFound = 1;

            //Get all the required products and store it in its respective arraylists

            try
            {
                for (int count = 1; count < TotalProducts; count++)
                {
                    String SKUID = "";
                    String PRODUCTSECTIONCODE = "";
                    String ORDERENTRYSOURCE = "";
                    String ORDERTYPE = "";
                    String ACTIVITYSTATUS = "";
                    String CAREERLEVEL = "";
                    bool LIMITEDEDITION = false;
                    String PRODUCTCLASS = "";
                    String CHILDREN = "";
                    bool SKUISACTIVE = false;
                    bool INCLUDEINSEARCH = false;
                    bool PRODUCTISACTIVE = false;

                    DateTime discontinuedDateformat = DateTime.MinValue;
                    DateTime expiredDateformat = DateTime.MinValue;
                    DateTime startDateformat = DateTime.MinValue;
                    DateTime newstartDateformat = DateTime.MinValue;
                    //All products
                    try
                    {
                        SKUID = d2.Products[count].MarketSKU.ToString();
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("SKUID does not exist for the product");
                        SKUID = null;
                    }

                    //Section code
                    try
                    {
                        PRODUCTSECTIONCODE = d2.Products[count].ProductSectionCode.ToString();
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("PRODUCTSECTIONCODE does not exist for the product");
                        PRODUCTSECTIONCODE = null;
                    }

                    //Discontinued date
                    try
                    {
                        discontinuedDateformat = Convert.ToDateTime(d2.Products[count].ConsultantDiscontinuedDate.ToString());
                    }
                    catch (Exception ex)
                    {
                        discontinuedDateformat = DateTime.MinValue;
                    }

                    //Expired Date
                    try
                    {
                        expiredDateformat = Convert.ToDateTime(d2.Products[count].ConsultantProductExpirationDate.ToString());
                    }
                    catch (Exception ex)
                    {
                        expiredDateformat = DateTime.MinValue;
                    }

                    //OrderEntrysource
                    try
                    {
                        ORDERENTRYSOURCE = d2.Products[count].OrderEntrySourceExclude.ToString();
                    }
                    catch (Exception ex)
                    {
                        ORDERENTRYSOURCE = null;
                    }

                    //OrderType
                    try
                    {
                        ORDERTYPE = d2.Products[count].OrderTypeExclude.ToString();
                    }
                    catch (Exception ex)
                    {
                        ORDERTYPE = null;
                    }

                    //ActivityStatus
                    try
                    {
                        ACTIVITYSTATUS = d2.Products[count].ActivityStatusExclude.ToString();
                    }
                    catch (Exception ex)
                    {
                        ACTIVITYSTATUS = null;
                    }

                    //CareerLevel
                    try
                    {
                        CAREERLEVEL = d2.Products[count].CareerLevelExclude.ToString();
                    }
                    catch (Exception ex)
                    {
                        CAREERLEVEL = null;
                    }

                    //StartDate
                    try
                    {
                        startDateformat = Convert.ToDateTime(d2.Products[count].ConsultantProductStartDate.ToString());
                    }
                    catch (Exception ex)
                    {
                        startDateformat = DateTime.MinValue;
                    }

                    //NewStartDate
                    try
                    {
                        newstartDateformat = Convert.ToDateTime(d2.Products[count].ConsultantProductStartDate.ToString());
                    }
                    catch (Exception ex)
                    {
                        newstartDateformat = DateTime.MinValue;
                    }

                    //LimitedEdition
                    try
                    {
                        LIMITEDEDITION = d2.Products[count].LimitedEditionProduct;
                    }
                    catch (Exception ex)
                    {
                        LIMITEDEDITION = false;
                    }

                    //ProductClass
                    try
                    {
                        PRODUCTCLASS = d2.Products[count].ProductClass.ToString();
                    }
                    catch (Exception ex)
                    {
                        PRODUCTCLASS = null;
                    }

                    //Children
                    try
                    {
                        CHILDREN = d2.Products[count].Children[0].ChildrenID.ToString();
                    }
                    catch (Exception ex)
                    {
                        CHILDREN = null;
                    }

                    //SKUisActive
                    try
                    {
                        SKUISACTIVE = d2.Products[count].SKUIsActive;
                    }
                    catch (Exception ex)
                    {
                        SKUISACTIVE = false;
                    }

                    //IncludeInSearch
                    try
                    {
                        INCLUDEINSEARCH = d2.Products[count].IncludeInSearch;
                    }
                    catch (Exception ex)
                    {
                        INCLUDEINSEARCH = false;
                    }

                    //ProductIsActive
                    try
                    {
                        PRODUCTISACTIVE = d2.Products[count].ProductIsActive;
                    }
                    catch (Exception ex)
                    {
                        PRODUCTISACTIVE = false;
                    }
                    wdAllProducts.Add((new MarketSkus
                    {
                        skuID = SKUID,
                        ProductSectionCode = PRODUCTSECTIONCODE,
                        ConsultantDiscontinuedDate = discontinuedDateformat,
                        ConsultantProductExpirationDate = expiredDateformat,
                        OrderEntrySourceExclude = ORDERENTRYSOURCE,
                        OrderTypeExclude = ORDERTYPE,
                        ActivityStatusExclude = ACTIVITYSTATUS,
                        CareerLevelExclude = CAREERLEVEL,
                        ConsultantProductStartDate = startDateformat,
                        ConsultantNewProductEndDate = newstartDateformat,
                        LimitedEditionProduct = LIMITEDEDITION,
                        productClass = PRODUCTCLASS,
                        childProduct = CHILDREN,
                        skuIsActive = SKUISACTIVE,
                        includeInSearch = INCLUDEINSEARCH,
                        productIsActive = PRODUCTISACTIVE
                    }));

                    productsFound++;
                }
                Console.WriteLine("Total products executed: " + productsFound);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occured. GetAllProduct stopped at " + productsFound + "th product");
            }

            List<String> product = ((from sku1 in wdAllProducts
                                     where (sku1.ProductSectionCode == "1" || sku1.ProductSectionCode == "2") && sku1.ActivityStatusExclude == null
                                     && sku1.OrderEntrySourceExclude == null && sku1.CareerLevelExclude == null
                                     && sku1.OrderTypeExclude == null && (sku1.ConsultantDiscontinuedDate == DateTime.MinValue || sku1.ConsultantDiscontinuedDate > OrderDate)
                                     && (sku1.ConsultantProductExpirationDate == DateTime.MinValue || sku1.ConsultantProductExpirationDate > OrderDate) && sku1.productClass != "60e6f7c7612b44cd903f09567f5a978e"
                                     && sku1.ConsultantProductStartDate < OrderDate && sku1.childProduct == null
                                     && sku1.skuIsActive == true && sku1.productIsActive == true && sku1.includeInSearch == true
                                     select sku1.skuID).ToList());

            List<String> labledProduct = ((from sku1 in wdAllProducts
                                           where sku1.ProductSectionCode == "1" && sku1.ActivityStatusExclude == null
                               && sku1.OrderEntrySourceExclude == null && sku1.CareerLevelExclude == null
                               && sku1.OrderTypeExclude == null && (sku1.ConsultantDiscontinuedDate == DateTime.MinValue || sku1.ConsultantDiscontinuedDate > OrderDate)
                               && (sku1.ConsultantProductExpirationDate == DateTime.MinValue || sku1.ConsultantProductExpirationDate > OrderDate) && sku1.productClass != "60e6f7c7612b44cd903f09567f5a978e"
                               && sku1.ConsultantProductStartDate < OrderDate && (sku1.LimitedEditionProduct == true) //sku1.ConsultantNewProductEndDate > OrderDate || 
                               && sku1.skuIsActive == true && sku1.productIsActive == true && sku1.includeInSearch == true
                                           select sku1.skuID).ToList());


            List<String> oosProduct = (from sku2 in wdoutOfStock
                                       select sku2.skuID).ToList();

            Console.WriteLine("Total no. of OOS products: {0}", oosProduct.Count);

            foreach (String skuid in oosProduct)
            {
                labledProduct.Remove(skuid);
            }

            Console.WriteLine("Get all the valid product. Total no. of products: " + labledProduct.Count);

            Console.WriteLine("Labled products are: " + labledProduct.Count);
            foreach (String validSKUID in labledProduct)
            {
                Console.WriteLine(validSKUID);
            }

        }     

        public static void GetValidProducts()
        {
            Console.WriteLine("Getting all the Valid section 1 and 2 products");
            Console.WriteLine("************************************************************");
            RestClient client = new RestClient("http://wddceqglws21:18961");

            RestRequest request = new RestRequest("/products/findbylanguage");

            request.Method = Method.GET;
            request.AddParameter("languages", "en-CA");
            request.AddParameter("SubsidiaryCode", "CA");
            request.AddParameter("PageSize", "1500");
            Console.WriteLine("GetProducts service started");           

            IRestResponse response = client.Execute(request);

            dynamic d = JObject.Parse(response.Content);

            String NoOfProducts= d.Total.ToString();

            int TotalProducts=Convert.ToInt32(NoOfProducts);
            int productsFound=1;

            try
            {
                for (int count = 1; count < TotalProducts; count++)
                {
                    if (d.Products[count].OrderEntrySourceExclude == null && d.Products[count].OrderTypeExclude == null && d.Products[count].ActivityStatusExclude == null && d.Products[count].CareerLevelExclude == null)
                    {
                        if (d.Products[count].ProductClass != "60e6f7c7612b44cd903f09567f5a978e" && d.Products[count].SKUIsActive == true && d.Products[count].IncludeInSearch == true && d.Products[count].ProductIsActive == true)
                        {
                            if (d.Products[count].ConsultantProductStartDate < DateTime.Now && d.Products[count].ConsultantProductExpirationDate > DateTime.Now)
                            {
                                if (d.Products[count].ConsultantDiscontinuedDate == null || d.Products[count].ConsultantDiscontinuedDate > DateTime.Now)
                                {

                                    if (d.Products[count].ProductSectionCode == "1")
                                    {
                                        String sec1product = (d.Products[count].MarketSKU);
                                        Variables.Variables.ListOfSec1Products.Add(sec1product);
                                    }

                                    if (d.Products[count].ProductSectionCode == "2")
                                    {
                                        String sec2product = (d.Products[count].MarketSKU);
                                        Variables.Variables.ListOfSec2Products.Add(sec2product);
                                    }

                                }
                            }
                        }
                    }
                }
            }

            catch (NullReferenceException nre)
            {
                Console.WriteLine("there is no such parameter");
            }
            catch (Exception e)
            {
                Console.WriteLine("system encountered {0} exception", e.GetType());
            }
            Console.WriteLine("List of Valid Sec1 products. {0} products", Variables.Variables.ListOfSec1Products.Count);
            Console.WriteLine("======================");
            //foreach (String products in Variables.Variables.ListOfSec1Products)
            //{
            //    Console.WriteLine("{0}", products);
            //}

            Console.WriteLine("List of  Sec2 products. {0} products", Variables.Variables.ListOfSec1Products.Count);
            Console.WriteLine("======================");
            //foreach (String products in Variables.Variables.ListOfSec2Products)
            //{
            //    Console.WriteLine("{0}", products);
            //}
        }


        }
    public class MarketSkus
    {
        public String skuID;
        public String ProductSectionCode;
        public System.DateTime ConsultantDiscontinuedDate;
        public System.DateTime ConsultantProductExpirationDate;
        public String OrderEntrySourceExclude;
        public String OrderTypeExclude;
        public String ActivityStatusExclude;
        public String CareerLevelExclude;
        public System.DateTime ConsultantProductStartDate;
        public System.DateTime ConsultantNewProductEndDate;
        public bool LimitedEditionProduct;
        public String productClass;
        public String childProduct;
        public bool skuIsActive;
        public bool includeInSearch;
        public bool productIsActive;

    }
    public class oosProducts
    {
        public String skuID;
    }


    }

