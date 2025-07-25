﻿define("CopilotSelectExistingSkillForAgentPage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGridMain",
				"values": {
					"features": {
						"rows": {
							"toolbar": false
						},
						"editable": {
							"enable": false,
							"itemsCreation": false,
							"floatingEditPanel": false
						}
					}
				}
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"attributes"
				],
				"values": {
					"DataGridMain_PredefinedFilter": {
						"value": {
						  "filterType": 6,
						  "isEnabled": true,
						  "logicalOperation": 1,
						  "trimDateTimeParameterToDate": false,
						  "items": {
							"ChatModeIdFilter": {
							  "isEnabled": true,
							  "trimDateTimeParameterToDate": false,
							  "filterType": 1,
							  "comparisonType": 11,
							  "leftExpression": {
								"expressionType": 0,
								"columnPath": "Mode.Id"
							  },
							  "rightExpression": {
								"expressionType": 2,
								"parameter": {
								  "dataValueType": 0,
								  "value": "326bba59-302a-4a5e-857c-2576e1a38ab0"
								}
							  }
							}
						  }
						}
					}
				}
			},
			{
				"operation": "merge",
				"path": [
					"attributes",
					"DataGridMain",
					"modelConfig"
				],
				"values": {
					"filterAttributes": [
						{
							"name": "SearchFilterMain_DataGridMain",
							"loadOnChange": true
						},
						{
							"loadOnChange": true,
							"name": "DataGridMain_PredefinedFilter"
						}
					]
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});