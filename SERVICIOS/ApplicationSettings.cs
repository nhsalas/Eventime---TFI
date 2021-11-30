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

		//readonly public string ConexionAzure = "Server=tcp:eventime.database.windows.net,1433;Initial Catalog=TFI;Persist Security Info=False;User ID=nhsalas16;Password=Nikitoo10;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

		readonly public string ConexionAzure = "Data Source=eventime.database.windows.net;Initial Catalog = eventimedb; Persist Security Info=True;User ID = nhsalas16; Password=Nikitoo10";

		public IFirebaseConfig ConexionFireBase = new FirebaseConfig()
		{
			AuthSecret = "2OYd83AUTtO93vvuwwmcL7hzXQHp3xDAZoCY1yoI",
			BasePath = "https://eventime-tfi-default-rtdb.firebaseio.com/"
		};

		readonly public string ConexionSomee = "Data Source=eventimedb.mssql.somee.com;Initial Catalog=eventimedb;Persist Security Info=True;User ID=eventimetfi_SQLLogin_1;Password=gr8v3lbpc4";

		readonly public string AccessTokenMP = "TEST-6939989322121513-102519-46448ccf906dea5a33842359d1c042f3-191763611";

		readonly public string URLMp_Local = "https://localhost:44394/WebApi/Pago";

		readonly public string URLMp_Somee = "https://eventime.somee.com/WebApi/Pago";

		readonly public string URLMp_Azure = "https://apieventime.azurewebsites.net/WebApi/Pago";

		readonly public string URLCliente_Local = "https://localhost:44394/WebApi/Cliente";

		readonly public string URLCliente_Somee = "https://eventime.somee.com/WebApi/Cliente";

		readonly public string URLCliente_Azure = "https://apieventime.azurewebsites.net/WebApi/Cliente";

		readonly public string URLEvento_Local = "https://localhost:44394/WebApi/Evento";

		readonly public string URLEvento_Somee = "https://eventime.somee.com/WebApi/Evento";

		readonly public string URLEvento_Azure = "https://apieventime.azurewebsites.net/WebApi/Evento";

		readonly public string URLServicio_Local = "https://localhost:44394/WebApi/Servicio";

		readonly public string URLServicio_Somee = "https://eventime.somee.com/WebApi/Servicio";

		readonly public string URLServicio_Azure = "https://apieventime.azurewebsites.net/WebApi/Servicio";

		readonly public string URLInvitado_Local = "https://localhost:44394/WebApi/Invitado";

		readonly public string URLInvitado_Somee = "https://eventime.somee.com/WebApi/Invitado";

		readonly public string URLInvitado_Azure = "https://apieventime.azurewebsites.net/WebApi/Invitado";

		readonly public string URLBitacora_Local = "https://localhost:44394/WebApi/Bitacora";

		readonly public string URLBitacora_Somee = "https://eventime.somee.com/WebApi/Bitacora";

		readonly public string URLBitacora_Azure = "https://apieventime.azurewebsites.net/WebApi/Bitacora";

		readonly public string UsernameSMTP  = "eventime.tfi@gmail.com";
		readonly public string PasswordSMTP  = "Eventime123$";


	// public string connMaster = ConfigurationManager.ConnectionStrings["MasterDB"].ToString();

	// public string connAplicacion = ConfigurationManager.ConnectionStrings["AplicacionDB"].ToString();

	// public string connSeguridad = ConfigurationManager.ConnectionStrings["SeguridadDB"].ToString();

	// Data Source=DESKTOP-EDJTHOR;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False   

}
}

