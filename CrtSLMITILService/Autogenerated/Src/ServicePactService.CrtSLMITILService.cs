using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using Terrasoft.Core;
using Terrasoft.Core.Factories;
using Terrasoft.Web.Common;

namespace Terrasoft.Configuration.ServicePactService
{

	#region Class: ServicePactService

	/// <summary>
	/// Сервис сервисных договоров.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ServicePactService: BaseService
	{
		#region Methods: Public

		/// <summary>
		/// Возвращает список сервисных договоров, которые подходят для указанных Контакта и Контрагента.
		/// </summary>
		/// <param name="request">Запрос на определение сервисных договоров</param>
		/// <returns>Список подходящих сервисных договоров</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public IEnumerable<SuitableServicePact> GetSuitableServicePacts(SuitableServicePactsRequest request) {
			var userConnection = UserConnection;
			var utils = ClassFactory.Get<ServicePactDetermineUtilsV2>(new ConstructorArgument("userConnection", userConnection));
			return utils.GetSuitableServicePacts(request);
		}

		#endregion
	}

	#endregion

	#region Class: SuitableServicePactsRequest

	/// <summary>
	/// Запрос на определение сервисных договров.
	/// </summary>
	[DataContract]
	public class SuitableServicePactsRequest
	{
		#region Properties: Public

		/// <summary>
		/// Контакт.
		/// </summary>
		[DataMember]
		public Guid ContactId { 
			get;
			set;
		}

		/// <summary>
		/// Контрагент.
		/// </summary>
		[DataMember]
		public Guid AccountId { 
			get;
			set;
		}

		#endregion
	}

	#endregion

	#region Class: SuitableServicePact

	/// <summary>
	/// Объект подходящего сервисного договора.
	/// </summary>
	[DataContract]
	public class SuitableServicePact : IEquatable<SuitableServicePact>
	{
		#region Properties: Public

		/// <summary>
		/// Идентификатор сервисного договора.
		/// </summary>
		[DataMember]
		public Guid Id { 
			get;
			set;
		}

		/// <summary>
		/// Название сервисного договора.
		/// </summary>
		[DataMember]
		public string Name { 
			get;
			set;
		}

		/// <summary>
		/// Показатель наколько подходит данный сервисный договор.
		/// </summary>
		[DataMember]
		public int SuitableLevel { 
			get;
			set;
		}

		#endregion

		#region Constructors: Public

		public SuitableServicePact() {}

		public SuitableServicePact(Guid id, string name, int suitableLevel) {
			Id = id;
			Name = name;
			SuitableLevel = suitableLevel;
		}

		#endregion

		#region Methods: Public
		
		public bool Equals(SuitableServicePact suitableServicePact) {
			return suitableServicePact != null && Id.Equals(suitableServicePact.Id);
		}
		
		#endregion
	}

	#endregion
}
