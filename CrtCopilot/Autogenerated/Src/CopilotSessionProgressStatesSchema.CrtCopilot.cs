namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: CopilotSessionProgressStatesSchema

	/// <exclude/>
	public class CopilotSessionProgressStatesSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CopilotSessionProgressStatesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CopilotSessionProgressStatesSchema(CopilotSessionProgressStatesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c97cec0c-44eb-481a-82a1-0e11ea2c192d");
			Name = "CopilotSessionProgressStates";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,85,79,75,138,194,64,20,92,27,200,29,222,1,196,92,64,6,130,232,78,24,140,50,235,182,83,198,102,58,221,77,191,23,152,65,188,187,47,49,130,46,235,75,85,48,61,56,25,11,218,100,24,113,113,181,137,201,249,40,101,113,43,139,69,85,85,180,230,161,239,77,254,255,154,241,1,41,131,17,132,73,174,32,22,35,160,120,153,192,28,38,6,179,139,129,82,142,157,154,121,245,234,170,222,202,210,112,246,206,18,194,208,191,130,205,51,247,61,199,154,177,155,213,58,110,89,252,24,39,46,116,187,152,79,140,188,87,221,116,88,126,42,181,230,117,81,144,119,121,251,7,59,140,134,218,234,195,48,113,205,175,243,190,129,135,21,180,19,83,119,250,233,131,57,58,241,56,165,86,71,180,138,239,101,113,167,7,20,144,224,243,49,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c97cec0c-44eb-481a-82a1-0e11ea2c192d"));
		}

		#endregion

	}

	#endregion

}

