namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ICopilotSessionResponseHandlerSchema

	/// <exclude/>
	public class ICopilotSessionResponseHandlerSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ICopilotSessionResponseHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ICopilotSessionResponseHandlerSchema(ICopilotSessionResponseHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ca6ba16c-f851-477a-baa5-430a2cb04d19");
			Name = "ICopilotSessionResponseHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c23dfaf0-0051-4966-86f8-cbe8197258d0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,181,142,193,10,130,64,16,134,207,10,190,195,28,11,194,23,176,130,240,146,215,244,5,214,117,172,197,117,70,156,245,32,209,187,183,139,69,84,116,12,6,6,254,111,254,127,126,82,61,202,160,52,66,62,162,114,134,211,156,7,99,217,37,241,53,137,163,73,12,157,161,156,197,97,159,86,23,127,210,120,33,251,73,210,74,73,39,47,254,17,234,129,71,195,84,91,163,193,144,195,177,13,175,139,7,46,81,196,48,157,124,35,38,193,163,162,198,226,232,29,161,74,20,162,183,53,179,221,67,174,104,129,7,153,73,175,222,237,32,203,222,132,51,141,214,134,6,84,113,135,4,250,75,217,65,131,173,154,172,91,103,207,39,240,159,236,91,18,251,185,3,54,163,210,112,113,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ca6ba16c-f851-477a-baa5-430a2cb04d19"));
		}

		#endregion

	}

	#endregion

}

