﻿namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: EmailUtilsSchema

	/// <exclude/>
	public class EmailUtilsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailUtilsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailUtilsSchema(EmailUtilsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("16897125-c693-4777-9da7-082cb0569c67");
			Name = "EmailUtils";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ce224767-e889-460a-86ca-36a387a79bb0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,101,82,203,78,227,64,16,60,27,137,127,104,178,7,108,30,227,59,24,47,43,132,246,2,18,2,118,47,132,195,172,221,78,70,216,227,168,123,188,78,132,248,119,230,97,135,56,92,108,117,119,85,117,77,169,181,108,144,87,178,64,120,70,34,201,109,101,196,77,171,43,181,232,72,26,213,234,195,131,247,195,131,168,99,165,23,240,180,97,131,141,157,215,53,22,110,200,226,55,106,36,85,92,238,99,158,113,109,196,35,46,186,90,210,237,122,69,200,236,240,22,103,145,63,8,23,182,130,155,90,50,95,192,109,35,85,253,199,168,154,253,52,77,83,200,184,107,26,73,155,124,168,173,37,35,149,102,232,44,76,153,13,52,104,150,109,201,80,181,4,125,75,111,208,43,179,12,74,98,212,72,119,68,86,221,191,90,21,192,198,62,170,128,194,45,222,217,11,239,126,243,214,216,125,80,191,128,7,79,11,195,125,95,190,241,136,166,35,235,171,86,108,160,173,0,157,38,159,1,163,139,8,75,168,168,109,32,91,73,146,13,97,5,218,230,125,53,35,217,63,25,178,113,205,210,92,108,181,211,125,241,64,251,198,201,189,113,144,101,233,98,133,34,100,227,194,103,15,16,89,234,137,95,58,20,92,230,119,187,46,71,1,100,75,24,17,142,50,205,202,113,178,32,156,195,131,36,70,191,254,87,32,199,97,2,91,119,137,203,50,138,162,255,146,134,48,224,10,52,246,19,157,56,185,244,32,123,32,184,6,242,223,128,242,157,248,122,22,255,204,60,59,159,247,167,47,231,167,226,120,222,191,158,92,219,34,126,57,23,175,246,159,156,204,197,164,76,102,131,168,219,220,72,83,44,209,173,246,226,226,62,212,241,151,205,128,181,231,131,178,88,66,236,1,129,6,74,143,252,241,49,145,170,32,62,10,207,17,227,45,198,30,36,254,202,186,195,100,139,140,6,148,205,103,2,8,251,162,15,255,11,223,144,249,144,146,159,127,12,103,136,186,12,151,232,235,208,157,54,109,15,62,1,147,145,235,62,188,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("16897125-c693-4777-9da7-082cb0569c67"));
		}

		#endregion

	}

	#endregion

}

