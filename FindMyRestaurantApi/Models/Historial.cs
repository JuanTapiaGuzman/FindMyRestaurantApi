using NReco.CF.Taste.Impl.Model;
using NReco.CF.Taste.Impl.Model.File;
using NReco.CF.Taste.Impl.Neighborhood;
using NReco.CF.Taste.Impl.Recommender;
using NReco.CF.Taste.Impl.Similarity;
using NReco.CF.Taste.Model;
using NReco.Recommender.Examples.SqlDbSource;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FindMyRestaurantApi.Models
{
    public class Historial
    {
        public string Restaurante { get; set; }
        public string Usuario { get; set; }
        public string Puntuacion { get; set; }

        public List<Historial> SelectRecommendations(string userId)
        {
            Data.dsMantenimientoTableAdapters.HistorialTableAdapter adapter = new Data.dsMantenimientoTableAdapters.HistorialTableAdapter();
            Data.dsMantenimiento.HistorialDataTable dt = adapter.SelectHistorial();

            var Recomendaciones = new List<Historial>();
            if (dt.Rows.Count == 0)
                return Recomendaciones;

            foreach (Data.dsMantenimiento.HistorialRow data in dt)
            {
                var Historial = new Historial();

                Historial.Restaurante = data.Restaurante;
                Historial.Usuario = data.Usuario;
                Historial.Puntuacion = data.Puntuacion.ToString();

                Recomendaciones.Add(Historial);
            }

            //var model = new FileDataModel("data.csv");
            //var similarity = new TanimotoCoefficientSimilarity(model);
            //var neighborhood = new NearestNUserNeighborhood(3, similarity, model);
            //var recommender = new GenericUserBasedRecommender(model, neighborhood, similarity);
            //var recommendedItems = recommender.Recommend(Convert.ToInt64(userId), 5);

            var ordersDataModel = LoadOrdersDataModel();

            // lets assume that we have a new user interted in some product
            var currentProductID = 57; // Product Name: Ravioli Angelo

            var modelWithCurrentUser = GetDataModelForNewUser(ordersDataModel, currentProductID);

            var similarity = new TanimotoCoefficientSimilarity(modelWithCurrentUser);

            // in this example, we have no preference values (scores)   
            // to get correct results 'BooleanfPref' recommenders should be used

            var recommender = new GenericBooleanPrefItemBasedRecommender(modelWithCurrentUser, similarity);

            var recommendedItems = recommender.Recommend(PlusAnonymousUserDataModel.TEMP_USER_ID, 10, null);

            Console.WriteLine("Products similar to {0} ({1}):", currentProductID, GetProductName(currentProductID));
            foreach (var ri in recommendedItems)
            {
                Console.WriteLine("\tProductID={0}: {1}", ri.GetItemID(), GetProductName(ri.GetItemID()));
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            return Recomendaciones;
        }

        /// <summary>
		/// Load data model by SQL SELECT query.
		/// </summary>
		static IDataModel LoadOrdersDataModel()
        {
            var dbConnection = System.Data.SQLite.SQLiteFactory.Instance.CreateConnection();
            dbConnection.ConnectionString = "Data Source=JATG;Initial Catalog=FindMyRestaurant;Integrated Security=True";

            var selectCmd = dbConnection.CreateCommand();
            selectCmd.CommandText = "select OrderID, ProductID from [Order Details]";

            var dataModelLoader = new DataModelSqlLoader(selectCmd, "OrderID", "ProductID");
            IDataModel dataModel = null;

            dbConnection.Open();
            try
            {
                dataModel = dataModelLoader.Load();
            }
            finally
            {
                dbConnection.Close();
            }
            return dataModel;
        }

        /// <summary>
        /// Wrap specified data model with 'PlusAnonymousUserDataModel' (adds new user and its preferences).
        /// </summary>
        static IDataModel GetDataModelForNewUser(IDataModel baseModel, params long[] preferredItems)
        {
            var plusAnonymModel = new PlusAnonymousUserDataModel(baseModel);
            var prefArr = new BooleanUserPreferenceArray(preferredItems.Length);
            prefArr.SetUserID(0, PlusAnonymousUserDataModel.TEMP_USER_ID);
            for (int i = 0; i < preferredItems.Length; i++)
            {
                prefArr.SetItemID(i, preferredItems[i]);
            }
            plusAnonymModel.SetTempPrefs(prefArr);
            return plusAnonymModel;
        }

        static string GetProductName(long productID)
        {
            var dbConnection = System.Data.SQLite.SQLiteFactory.Instance.CreateConnection();
            dbConnection.ConnectionString = "Data Source=JATG;Initial Catalog=FindMyRestaurant;Integrated Security=True"; ;

            var selectCmd = dbConnection.CreateCommand();
            selectCmd.CommandText = "select ProductName from [Products] where ProductID=" + productID;
            dbConnection.Open();
            try
            {
                var rdr = selectCmd.ExecuteReader();
                while (rdr.Read())
                    return rdr["ProductName"].ToString();
            }
            finally
            {
                dbConnection.Close();
            }
            return null;
        }
    }
}