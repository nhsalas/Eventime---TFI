using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;

namespace SERVICIOS
{
    public class ApplicationSettings
    {
		#region Singleton
		private static readonly ApplicationSettings _instance = new ApplicationSettings();

		private ApplicationSettings()
		{
		}

		public static ApplicationSettings Current
		{
			get { return _instance; }
		}
		#endregion

		readonly public string ConexionSQL = "Data Source=DESKTOP-EDJTHOR;Initial Catalog=TFI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		readonly public string ConexionAzure = "Server=tcp:eventime.database.windows.net,1433;Initial Catalog=TFI;Persist Security Info=False;User ID=nhsalas16;Password=Nikitoo10;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

		public IFirebaseConfig ConexionFireBase = new FirebaseConfig()
		{
			AuthSecret = "2OYd83AUTtO93vvuwwmcL7hzXQHp3xDAZoCY1yoI",
			BasePath = "https://eventime-tfi-default-rtdb.firebaseio.com/"
		};

		readonly public string ConexionSomee = "workstation id=eventimedb.mssql.somee.com;packet size=4096;user id=eventimetfi_SQLLogin_1;pwd=gr8v3lbpc4;data source=eventimedb.mssql.somee.com;persist security info=False;initial catalog=eventimedb";

		// public string connMaster = ConfigurationManager.ConnectionStrings["MasterDB"].ToString();

		// public string connAplicacion = ConfigurationManager.ConnectionStrings["AplicacionDB"].ToString();

		// public string connSeguridad = ConfigurationManager.ConnectionStrings["SeguridadDB"].ToString();

		// Data Source=DESKTOP-EDJTHOR;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False   

	}
}

