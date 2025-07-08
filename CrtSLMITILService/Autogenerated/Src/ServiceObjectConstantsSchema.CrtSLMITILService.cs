namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: ServiceObjectConstantsSchema

	/// <exclude/>
	public class ServiceObjectConstantsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ServiceObjectConstantsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ServiceObjectConstantsSchema(ServiceObjectConstantsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("87b3bcc1-054b-4d22-b62d-b3d765973e0c");
			Name = "ServiceObjectConstants";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,173,147,203,74,195,64,20,134,215,22,250,14,131,110,116,49,54,247,164,245,2,162,32,174,20,234,11,204,45,37,98,210,146,153,40,69,4,47,59,93,184,113,229,210,39,168,138,82,212,234,43,76,222,200,147,196,106,21,93,8,66,194,112,254,243,207,201,255,49,147,76,70,73,7,181,251,82,137,120,161,94,171,215,18,18,11,217,35,76,160,109,145,166,68,118,67,53,191,218,77,194,168,147,165,68,69,221,164,94,59,168,215,166,102,82,209,129,2,173,238,18,41,91,168,45,210,189,136,137,77,186,35,152,2,187,84,36,81,18,124,240,52,26,13,180,40,179,56,38,105,127,249,189,214,87,250,69,143,242,227,252,68,15,96,61,201,207,17,8,55,249,153,190,215,143,32,190,232,219,74,56,214,79,249,169,126,208,67,125,91,56,245,48,191,24,143,108,76,204,236,101,116,55,98,8,62,171,96,97,69,168,223,51,21,249,63,1,198,141,22,218,42,135,20,205,226,253,30,187,202,125,13,73,94,191,102,29,252,154,180,53,230,44,40,193,250,49,118,50,250,183,236,235,89,196,139,80,138,48,181,221,239,137,13,142,150,80,34,246,203,198,236,52,181,8,225,46,15,49,9,93,134,29,203,165,152,48,139,97,43,52,109,30,4,166,65,124,115,122,174,60,201,127,70,200,143,64,187,131,13,163,63,128,172,48,214,205,146,159,64,108,215,224,94,200,125,204,2,7,64,108,102,96,42,152,135,29,195,52,61,70,105,147,91,244,159,65,46,193,244,170,7,249,81,121,30,207,127,68,89,19,61,146,170,88,252,72,67,61,42,76,219,10,112,232,135,28,59,1,115,113,211,240,109,236,248,14,177,221,192,247,154,134,93,210,84,119,107,70,36,188,186,127,80,29,86,191,201,164,6,210,27,89,228,224,90,153,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("87b3bcc1-054b-4d22-b62d-b3d765973e0c"));
		}

		#endregion

	}

	#endregion

}

