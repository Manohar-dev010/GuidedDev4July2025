define("Cases_ListPage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "remove",
				"name": "DataImportButton"
			},
			{
				"operation": "remove",
				"name": "MenuItem_ImportFromExcel"
			},
			{
				"operation": "remove",
				"name": "OpenLandingDesigner"
			},
			{
				"operation": "merge",
				"name": "LeftFilterContainer",
				"values": {
					"wrap": "wrap",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "large"
					},
					"alignItems": "center",
					"visible": true
				}
			},
			{
				"operation": "remove",
				"name": "LeftFilterContainerInner"
			},
			{
				"operation": "move",
				"name": "FolderTreeActions",
				"parentName": "LeftFilterContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "merge",
				"name": "LookupQuickFilterByTag",
				"values": {
					"config": {
						"caption": "#ResourceString(LookupQuickFilterByTag_config_caption)#",
						"hint": "#ResourceString(LookupQuickFilterByTag_config_hint)#",
						"icon": "tag-icon",
						"iconPosition": "left-icon",
						"entitySchemaName": "CaseTag",
						"defaultValue": [],
						"recordsFilter": null
					},
					"_filterOptions": {
						"expose": [
							{
								"attribute": "LookupQuickFilterByTag_Items",
								"converters": [
									{
										"converter": "crt.QuickFilterAttributeConverter",
										"args": [
											{
												"target": {
													"viewAttributeName": "Items",
													"filterColumn": "[CaseInTag:Entity].Tag"
												},
												"quickFilterType": "lookup"
											}
										]
									}
								]
							}
						],
						"from": "LookupQuickFilterByTag_Value"
					}
				}
			},
			{
				"operation": "move",
				"name": "LookupQuickFilterByTag",
				"parentName": "LeftFilterContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "remove",
				"name": "SearchFilter",
				"properties": [
					"targetAttributes"
				]
			},
			{
				"operation": "move",
				"name": "SearchFilter",
				"parentName": "LeftFilterContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "merge",
				"name": "SearchFilter",
				"values": {
					"layoutConfig": {},
					"_filterOptions": {
						"expose": [
							{
								"attribute": "SearchFilter_Items",
								"converters": [
									{
										"converter": "crt.SearchFilterAttributeConverter",
										"args": [
											"Items"
										]
									}
								]
							}
						],
						"from": [
							"SearchFilter_SearchValue",
							"SearchFilter_FilteredColumnsGroups"
						]
					}
				}
			},
			{
				"operation": "merge",
				"name": "FolderTree",
				"values": {
					"_filterOptions": {
						"expose": [
							{
								"attribute": "FolderTree_active_folder_filter",
								"converters": [
									{
										"converter": "crt.FolderTreeActiveFilterAttributeConverter",
										"args": [
											"Case"
										]
									}
								]
							}
						],
						"from": [
							"FolderTree_items",
							"FolderTree_favoriteItems",
							"FolderTree_active_folder_id"
						]
					},
					"rootSchemaName": "Case"
				}
			},
			{
				"operation": "merge",
				"name": "SectionContentWrapper",
				"values": {
					"direction": "row",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap"
				}
			},
			{
				"operation": "merge",
				"name": "DataTable",
				"values": {
					"columns": [
						{
							"id": "f252f581-0ccf-44ac-b7c9-c00df2ad9919",
							"code": "PDS_Number",
							"caption": "#ResourceString(PDS_Number)#",
							"dataValueType": 1,
							"width": 122
						},
						{
							"id": "2485060d-d6c3-05cd-1491-3345258fa43d",
							"code": "PDS_Subject",
							"path": "Subject",
							"caption": "#ResourceString(PDS_Subject)#",
							"dataValueType": 30,
							"width": 375
						},
						{
							"id": "e0f22d25-7f56-25fb-3655-bc5e6c586728",
							"code": "PDS_Category",
							"path": "Category",
							"caption": "#ResourceString(PDS_Category)#",
							"dataValueType": 10,
							"referenceSchemaName": "CaseCategory",
							"width": 139
						},
						{
							"id": "d5c88212-396b-cc7c-be09-183455547eb0",
							"code": "PDS_Owner",
							"path": "Owner",
							"caption": "#ResourceString(PDS_Owner)#",
							"dataValueType": 10,
							"referenceSchemaName": "Contact",
							"width": 169
						},
						{
							"id": "88739f93-be63-c53c-0c92-0181444b6062",
							"code": "PDS_Status",
							"path": "Status",
							"caption": "#ResourceString(PDS_Status)#",
							"dataValueType": 10,
							"referenceSchemaName": "CaseStatus",
							"width": 185
						},
						{
							"id": "40c5d4a7-918d-b573-a1f9-50f5b7a4bab5",
							"code": "PDS_SolutionDate",
							"path": "SolutionDate",
							"caption": "#ResourceString(PDS_SolutionDate)#",
							"dataValueType": 7,
							"width": 169
						}
					],
					"layoutConfig": {
						"basis": "100%",
						"width": 300
					},
					"features": {
						"editable": false
					},
					"visible": true,
					"fitContent": true
				}
			},
			{
				"operation": "insert",
				"name": "MenuItem_ImportToExcel",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(MenuItem_ixsnk8a_caption)#",
					"visible": true,
					"clicked": {
						"request": "crt.ImportDataRequest",
						"params": {
							"entitySchemaName": "Case"
						}
					},
					"icon": "import-button-icon"
				},
				"parentName": "ActionButton",
				"propertyName": "menuItems",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ClosedCasesQuickFilter",
				"values": {
					"type": "crt.QuickFilter",
					"filterType": "custom",
					"config": {
						"defaultValue": false,
						"approachState": false,
						"caption": "#ResourceString(ClosedCasesQuickFilter_config_caption)#",
						"hint": "",
						"icon": "settings-button-icon",
						"iconPosition": "left-icon"
					},
					"visible": true,
					"_filterOptions": {
						"expose": [
							{
								"attribute": "ClosedCasesQuickFilter_Items",
								"converters": [
									{
										"converter": "crt.QuickFilterAttributeConverter",
										"args": [
											{
												"target": {
													"viewAttributeName": "Items",
													"customFilter": {
														"items": {
															"eb2678fc-ccfe-458f-91f4-47d6d2e32d30": {
																"filterType": 1,
																"comparisonType": 3,
																"isEnabled": true,
																"trimDateTimeParameterToDate": false,
																"leftExpression": {
																	"expressionType": 0,
																	"columnPath": "Status.IsFinal"
																},
																"isAggregative": false,
																"dataValueType": 12,
																"rightExpression": {
																	"expressionType": 2,
																	"parameter": {
																		"dataValueType": 12,
																		"value": false
																	}
																}
															}
														},
														"logicalOperation": 0,
														"isEnabled": true,
														"filterType": 6,
														"rootSchemaName": "Case"
													}
												},
												"quickFilterType": "custom",
												"config": {
													"defaultValue": false,
													"approachState": false,
													"caption": "#ResourceString(ClosedCasesQuickFilter_config_caption)#",
													"hint": ""
												}
											}
										]
									}
								]
							}
						],
						"from": "ClosedCasesQuickFilter_Value"
					}
				},
				"parentName": "LeftFilterContainer",
				"propertyName": "items",
				"index": 1
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"attributes",
					"Items",
					"viewModelConfig",
					"attributes"
				],
				"values": {
					"PDS_Number": {
						"modelConfig": {
							"path": "PDS.Number"
						}
					},
					"PDS_Subject": {
						"modelConfig": {
							"path": "PDS.Subject"
						}
					},
					"PDS_Category": {
						"modelConfig": {
							"path": "PDS.Category"
						}
					},
					"PDS_Owner": {
						"modelConfig": {
							"path": "PDS.Owner"
						}
					},
					"PDS_Status": {
						"modelConfig": {
							"path": "PDS.Status"
						}
					},
					"PDS_SolutionDate": {
						"modelConfig": {
							"path": "PDS.SolutionDate"
						}
					}
				}
			},
			{
				"operation": "merge",
				"path": [
					"attributes",
					"Items",
					"modelConfig"
				],
				"values": {
					"filterAttributes": [
						{
							"loadOnChange": true,
							"name": "FolderTree_active_folder_filter"
						},
						{
							"name": "Items_PredefinedFilter",
							"loadOnChange": true
						},
						{
							"name": "ClosedCasesQuickFilter_Items",
							"loadOnChange": true
						},
						{
							"name": "SearchFilter_Items",
							"loadOnChange": true
						},
						{
							"name": "LookupQuickFilterByTag_Items",
							"loadOnChange": true
						}
					]
				}
			},
			{
				"operation": "merge",
				"path": [
					"attributes",
					"Items",
					"modelConfig",
					"sortingConfig"
				],
				"values": {
					"default": [
						{
							"direction": "asc",
							"columnName": "SolutionDate"
						}
					]
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [],
				"values": {
					"primaryDataSourceName": "CaseDS"
				}
			},
			{
				"operation": "merge",
				"path": [
					"dataSources"
				],
				"values": {
					"CaseDS": {
						"type": "crt.EntityDataSource",
						"scope": "page",
						"config": {
							"entitySchemaName": "Case"
						}
					}
				}
			},
			{
				"operation": "merge",
				"path": [
					"dataSources",
					"PDS",
					"config"
				],
				"values": {
					"entitySchemaName": "Case",
					"attributes": {
						"Number": {
							"path": "Number"
						},
						"Subject": {
							"path": "Subject"
						},
						"Category": {
							"path": "Category"
						},
						"Owner": {
							"path": "Owner"
						},
						"Status": {
							"path": "Status"
						},
						"SolutionDate": {
							"path": "SolutionDate"
						}
					}
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});