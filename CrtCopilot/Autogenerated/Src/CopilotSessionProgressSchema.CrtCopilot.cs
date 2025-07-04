namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: CopilotSessionProgressSchema

	/// <exclude/>
	public class CopilotSessionProgressSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CopilotSessionProgressSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CopilotSessionProgressSchema(CopilotSessionProgressSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b0e8ee9b-f8b6-433f-85d3-3a0027859450");
			Name = "CopilotSessionProgress";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,165,86,91,111,218,48,20,126,166,82,255,131,71,39,45,145,80,120,31,99,213,70,213,46,210,152,42,160,219,67,213,7,147,28,168,167,36,142,108,103,83,135,248,239,59,177,29,200,197,148,150,74,85,91,251,220,190,243,157,139,147,209,20,100,78,35,32,19,1,84,49,30,76,120,206,18,174,206,207,54,231,103,189,66,178,108,77,230,79,82,65,58,106,157,131,89,145,41,150,66,48,7,193,104,194,254,149,230,217,94,107,1,66,80,201,87,10,93,166,233,33,137,0,188,71,201,253,21,85,116,194,51,37,104,164,30,240,34,47,150,9,139,72,148,80,41,137,5,53,7,41,49,198,173,224,107,129,255,162,214,70,27,247,46,4,172,81,64,80,146,131,80,12,228,71,114,171,29,24,249,112,56,36,159,100,145,166,84,60,125,174,46,110,64,73,194,5,145,229,95,245,8,85,20,188,208,97,8,139,1,51,92,49,16,193,206,201,176,238,69,131,158,66,186,4,225,253,64,38,201,152,244,163,6,212,48,238,251,101,54,85,58,55,5,139,201,78,70,54,100,13,106,84,34,24,145,237,91,160,42,166,18,56,25,229,162,180,110,2,149,74,232,82,215,20,94,140,118,198,17,25,203,20,178,247,65,146,136,230,101,99,188,2,156,64,251,80,155,79,140,173,19,218,172,173,245,98,124,147,66,8,52,123,11,196,200,184,56,142,114,226,80,60,189,236,82,81,5,132,175,244,33,183,99,240,10,216,218,222,93,104,237,185,1,12,13,50,180,227,43,207,61,126,218,68,6,191,40,83,232,225,154,139,59,9,98,138,2,186,6,127,244,154,180,98,144,145,96,134,27,155,156,37,248,148,36,107,222,156,169,94,213,162,57,42,113,1,89,108,214,73,115,183,76,65,61,242,184,92,44,130,253,193,204,141,52,55,7,93,153,125,8,204,176,81,113,175,164,6,183,91,6,145,14,91,52,142,3,189,22,46,109,63,134,177,79,202,221,219,235,177,21,241,222,85,151,193,55,42,127,210,164,128,74,218,19,160,10,145,145,172,72,146,145,190,217,234,223,182,88,38,254,60,122,132,148,78,105,134,53,17,54,64,243,110,220,2,19,236,176,55,244,60,223,196,8,237,57,196,23,192,250,67,23,14,199,193,53,203,226,82,235,235,211,93,24,123,187,52,76,14,198,153,205,192,200,46,3,75,150,150,109,157,244,126,231,145,126,105,150,9,204,119,76,215,234,185,128,52,79,80,255,8,223,134,191,231,186,218,76,90,69,117,197,52,252,237,34,240,90,244,205,64,242,66,68,40,229,2,121,176,177,158,29,36,127,64,222,247,59,142,101,176,209,32,130,5,183,145,252,173,97,175,239,215,41,58,222,175,166,251,45,161,213,40,104,62,221,120,204,183,192,49,18,137,139,69,210,124,88,6,7,34,212,73,30,144,156,10,154,226,70,88,254,70,215,247,15,245,117,240,69,172,101,85,5,59,91,174,213,139,45,216,25,185,54,220,38,178,160,177,152,113,230,70,245,24,157,23,232,132,0,251,247,105,231,189,219,190,113,183,119,77,40,87,83,183,3,154,30,29,181,91,244,64,81,237,214,216,127,124,140,219,136,195,216,118,107,247,105,29,119,41,169,166,200,93,14,87,149,6,13,4,230,155,162,3,66,95,87,154,202,240,209,158,3,43,174,47,242,177,93,189,1,190,67,41,85,158,131,216,65,167,177,204,214,124,102,152,240,22,127,254,3,66,116,204,121,37,11,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateExecutingActionLocalizableString());
			LocalizableStrings.Add(CreateWaitingForAssistantMessageLocalizableString());
			LocalizableStrings.Add(CreateWaitingForUserMessageLocalizableString());
			LocalizableStrings.Add(CreateAgentSelectedLocalizableString());
			LocalizableStrings.Add(CreateSkillSelectedLocalizableString());
			LocalizableStrings.Add(CreateSessionStartedLocalizableString());
			LocalizableStrings.Add(CreateTitleUpdatedLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateExecutingActionLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("07f19ea2-e4a4-330b-afc6-63209cf7b939"),
				Name = "ExecutingAction",
				CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e"),
				CreatedInSchemaUId = new Guid("b0e8ee9b-f8b6-433f-85d3-3a0027859450"),
				ModifiedInSchemaUId = new Guid("b0e8ee9b-f8b6-433f-85d3-3a0027859450")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateWaitingForAssistantMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("6673cc57-96d6-8a62-a449-ecaf90a81acb"),
				Name = "WaitingForAssistantMessage",
				CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e"),
				CreatedInSchemaUId = new Guid("b0e8ee9b-f8b6-433f-85d3-3a0027859450"),
				ModifiedInSchemaUId = new Guid("b0e8ee9b-f8b6-433f-85d3-3a0027859450")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateWaitingForUserMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("2e0aa39a-7a19-f269-c454-5b4380e84bd2"),
				Name = "WaitingForUserMessage",
				CreatedInPackageId = new Guid("7a3a8162-4be1-46b5-bd50-b3efc2df6d2e"),
				CreatedInSchemaUId = new Guid("b0e8ee9b-f8b6-433f-85d3-3a0027859450"),
				ModifiedInSchemaUId = new Guid("b0e8ee9b-f8b6-433f-85d3-3a0027859450")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateAgentSelectedLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("7dd50df5-746e-82af-1114-5a4dc1d8fd71"),
				Name = "AgentSelected",
				CreatedInPackageId = new Guid("421a8d84-5f16-4efa-b563-3ab0d40eb264"),
				CreatedInSchemaUId = new Guid("b0e8ee9b-f8b6-433f-85d3-3a0027859450"),
				ModifiedInSchemaUId = new Guid("b0e8ee9b-f8b6-433f-85d3-3a0027859450")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateSkillSelectedLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("70deaa71-960f-65d8-a1ef-90a12e17c1d1"),
				Name = "SkillSelected",
				CreatedInPackageId = new Guid("421a8d84-5f16-4efa-b563-3ab0d40eb264"),
				CreatedInSchemaUId = new Guid("b0e8ee9b-f8b6-433f-85d3-3a0027859450"),
				ModifiedInSchemaUId = new Guid("b0e8ee9b-f8b6-433f-85d3-3a0027859450")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateSessionStartedLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("010d0b26-7b10-9243-e4fa-b9b88a8cc43e"),
				Name = "SessionStarted",
				CreatedInPackageId = new Guid("ed753793-30d5-4797-a3f9-3019dcc6e358"),
				CreatedInSchemaUId = new Guid("b0e8ee9b-f8b6-433f-85d3-3a0027859450"),
				ModifiedInSchemaUId = new Guid("b0e8ee9b-f8b6-433f-85d3-3a0027859450")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateTitleUpdatedLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("1bd7d953-a849-21f9-c0ae-681806e9b2ee"),
				Name = "TitleUpdated",
				CreatedInPackageId = new Guid("421a8d84-5f16-4efa-b563-3ab0d40eb264"),
				CreatedInSchemaUId = new Guid("b0e8ee9b-f8b6-433f-85d3-3a0027859450"),
				ModifiedInSchemaUId = new Guid("b0e8ee9b-f8b6-433f-85d3-3a0027859450")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b0e8ee9b-f8b6-433f-85d3-3a0027859450"));
		}

		#endregion

	}

	#endregion

}

