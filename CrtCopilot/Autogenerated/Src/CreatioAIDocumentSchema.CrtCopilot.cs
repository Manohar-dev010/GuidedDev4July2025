namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: CreatioAIDocumentSchema

	/// <exclude/>
	public class CreatioAIDocumentSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CreatioAIDocumentSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CreatioAIDocumentSchema(CreatioAIDocumentSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("acf18860-6422-4915-b6e0-8cee95e572c3");
			Name = "CreatioAIDocument";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ed753793-30d5-4797-a3f9-3019dcc6e358");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,146,63,107,195,48,16,197,231,4,242,29,142,100,105,23,123,79,250,135,226,144,226,161,37,212,99,233,32,203,87,231,64,150,140,116,30,90,147,239,94,201,142,83,210,154,66,241,34,124,239,157,126,239,97,164,69,133,174,22,18,33,177,40,152,76,148,152,154,148,225,197,188,93,204,103,141,35,93,66,246,225,24,171,205,143,57,122,105,52,83,133,81,134,150,132,162,207,112,93,251,45,191,183,178,88,250,1,18,37,156,91,15,236,135,116,107,100,83,161,230,176,228,215,226,56,134,27,210,7,15,224,194,200,248,206,107,175,91,193,34,49,154,173,144,252,22,132,51,63,87,24,132,186,201,21,73,144,129,253,27,13,107,72,71,242,102,109,151,120,110,182,183,166,70,203,132,190,222,190,3,246,254,88,165,190,211,19,86,57,218,171,103,255,199,224,22,150,164,217,131,211,98,121,29,58,13,165,30,27,42,238,33,61,121,208,66,137,188,1,23,142,227,63,3,28,58,231,155,142,39,100,131,57,41,226,157,20,142,241,97,215,25,147,217,225,251,146,238,216,134,23,180,59,153,147,19,50,121,192,74,252,153,243,189,50,150,182,66,93,244,79,162,155,123,245,82,60,126,1,58,26,71,147,37,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("acf18860-6422-4915-b6e0-8cee95e572c3"));
		}

		#endregion

	}

	#endregion

}

