namespace Terrasoft.Configuration.TermCalculationService
{

	using System;
	using System.Runtime.Serialization;

	#region Class: ServiceTermRequest

	//// <summary>
	/// Класс запроса плановых дат.
	/// </summary>
	[DataContract]
	public partial class ServiceTermRequestV2
	{

		#region Properties: Public

		/// <summary>
		/// Сервис.
		/// </summary>
		[DataMember]
		public Guid ServiceItemId { 
			get;
			set;
		}
		
		/// <summary>
		/// Приоритет.
		/// </summary>
		[DataMember]
		public Guid PriorityId { 
			get;
			set;
		}

		/// <summary>
		/// Дата регистрации.
		/// </summary>
		[DataMember]
		public string RegistrationTime { 
			get;
			set;
		}
		
		/// <summary>
		/// Service pact.
		/// </summary>
		[DataMember]
		public Guid ServicePactId { 
			get;
			set;
		}

		#endregion

	}

	#endregion
	
	#region Class : ServiceTermResponse

	/// <summary>
	/// A class-container for reaction time and solution time.
	/// </summary>
	[DataContract]
	public class ServiceTermResponse
	{

		#region Properties : Public

		/// <summary>
		/// Reaction time.
		/// </summary>
		[DataMember]
		public DateTime? ReactionTime { 
			get;
			set;
		}
		
		/// <summary>
		/// Solution time.
		/// </summary>
		[DataMember]
		public DateTime? SolutionTime { 
			get;
			set;
		}

		#endregion

	}

	#endregion
	
	#region Class: RemainsTicksRequest
	//// <summary>
	/// Класс запроса остатка времени до плановой даты.
	/// </summary>
	[DataContract]
	public class RemainsTicksRequest
	{
		#region Properties: Public
		/// <summary>
		/// Плановая дата.
		/// </summary>
		[DataMember]
		public string SourceDateTime { 
			get;
			set;
		}

		/// <summary>
		/// Остаток времени.
		/// </summary>
		[DataMember]
		public long RemainsTicks { 
			get;
			set;
		}

		/// <summary>
		/// Признак разрешения.
		/// </summary>
		[DataMember]
		public bool IsResolution { 
			get;
			set;
		}

		/// <summary>
		/// Обращение.
		/// </summary>
		[DataMember]
		public Guid CaseId { 
			get;
			set;
		}

		#endregion
	}

	#endregion
	
}

