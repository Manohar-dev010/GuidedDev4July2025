define("Accounts_ListPage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "AddButton",
				"values": {
					"size": "large"
				}
			},
			{
				"operation": "remove",
				"name": "DataImportButton"
			},
			{
				"operation": "merge",
				"name": "MenuItem_ImportFromExcel",
				"values": {
					"clicked": {
						"request": "crt.ImportDataRequest",
						"params": {
							"entitySchemaName": "Account"
						}
					}
				}
			},
			{
				"operation": "move",
				"name": "MenuItem_ImportFromExcel",
				"parentName": "ActionButton",
				"propertyName": "menuItems",
				"index": 1
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
					}
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
						"entitySchemaName": "AccountTag"
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
													"filterColumn": "[AccountInTag:Entity].Tag"
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
				"index": 1
			},
			{
				"operation": "move",
				"name": "SearchFilter",
				"parentName": "LeftFilterContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "merge",
				"name": "RefreshButton",
				"values": {
					"caption": "#ResourceString(RefreshButton_caption)#",
					"clicked": {
						"request": "crt.LoadDataRequest",
						"params": {
							"config": {
								"loadType": "reload",
								"useLastLoadParameters": true
							},
							"refreshDataConfig": {
								"mode": "RefreshSpecific",
								"targetDataSourceNames": [
									"PDS"
								]
							}
						}
					},
					"visible": true
				}
			},
			{
				"operation": "merge",
				"name": "FolderTree",
				"values": {
					"sourceSchemaName": "AccountFolder",
					"_filterOptions": {
						"expose": [
							{
								"attribute": "FolderTree_active_folder_filter",
								"converters": [
									{
										"converter": "crt.FolderTreeActiveFilterAttributeConverter",
										"args": [
											"Account"
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
					"rootSchemaName": "Account",
					"borderRadius": "none"
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
							"id": "8a438b24-e88d-1e5c-93b7-d16e119ae24b",
							"code": "PDS_Name",
							"path": "Name",
							"caption": "#ResourceString(PDS_Name)#",
							"dataValueType": 28,
							"sticky": true
						},
						{
							"id": "dcfcc335-4e9b-39b4-33f2-49a953c68ab4",
							"code": "PDS_PrimaryContact",
							"path": "PrimaryContact",
							"caption": "#ResourceString(PDS_PrimaryContact)#",
							"dataValueType": 10,
							"referenceSchemaName": "Contact",
							"width": 224
						},
						{
							"id": "66f5baa6-0698-c4e5-1922-696fe8045ac1",
							"code": "PDS_Type",
							"path": "Type",
							"caption": "#ResourceString(PDS_Type)#",
							"dataValueType": 10,
							"referenceSchemaName": "AccountType",
							"width": 165
						},
						{
							"id": "f3cdea55-a23b-6ccf-8b28-af100a050ebe",
							"code": "PDS_AccountCategory",
							"path": "AccountCategory",
							"caption": "#ResourceString(PDS_AccountCategory)#",
							"dataValueType": 10,
							"referenceSchemaName": "AccountCategory",
							"width": 114
						},
						{
							"id": "38f3839b-174b-1712-e038-1ced6640b25a",
							"code": "PDS_Industry",
							"path": "Industry",
							"caption": "#ResourceString(PDS_Industry)#",
							"dataValueType": 10,
							"referenceSchemaName": "AccountIndustry"
						},
						{
							"id": "d48c4425-1677-6d87-9400-b6ee1c316105",
							"code": "PDS_Web",
							"path": "Web",
							"caption": "#ResourceString(PDS_Web)#",
							"dataValueType": 28,
							"width": 238
						},
						{
							"id": "ab2ff5af-56dd-cf88-a644-a77fdb9ebd73",
							"code": "PDS_Country",
							"path": "Country",
							"caption": "#ResourceString(PDS_Country)#",
							"dataValueType": 10,
							"referenceSchemaName": "Country",
							"width": 229
						},
						{
							"id": "987816a7-0e0f-d51f-e040-5374f3d2b8db",
							"code": "PDS_CreatedOn",
							"path": "CreatedOn",
							"caption": "#ResourceString(PDS_CreatedOn)#",
							"dataValueType": 7
						}
					],
					"layoutConfig": {
						"basis": "100%"
					},
					"selectionState": "$DataTable_SelectionState",
					"_selectionOptions": {
						"attribute": "DataTable_SelectionState"
					},
					"bulkActions": []
				}
			},
			{
				"operation": "merge",
				"name": "Dashboards",
				"values": {
					"_designOptions": {
						"entitySchemaName": "Account",
						"dependencies": [
							{
								"attributePath": "Id",
								"relationPath": "PDS.Id"
							}
						],
						"filters": []
					}
				}
			},
			{
				"operation": "insert",
				"name": "MenuItem_ShowDuplicateAccounts",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(MenuItem_ShowDuplicateAccounts_caption)#",
					"visible": true,
					"clicked": {
						"request": "crt.OpenDuplicatesPageRequest",
						"params": {
							"entityName": "Account"
						}
					},
					"icon": "copy-icon"
				},
				"parentName": "ActionButton",
				"propertyName": "menuItems",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "DataTable_AddTagsBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(DataTable_AddTagsBulkAction_caption)#",
					"icon": "tag-icon",
					"clicked": {
						"request": "crt.AddTagsInRecordsRequest",
						"params": {
							"dataSourceName": "PDS",
							"filters": "$Items | crt.ToCollectionFilters : 'Items' : $DataTable_SelectionState | crt.SkipIfSelectionEmpty : $DataTable_SelectionState",
							"tagInRecordSourceSchemaName": "AccountInTag"
						}
					},
					"items": [],
					"visible": true
				},
				"parentName": "DataTable",
				"propertyName": "bulkActions",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DataTable_RemoveTagsBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(DataTable_RemoveTagsBulkAction_caption)#",
					"icon": "delete-button-icon",
					"clicked": {
						"request": "crt.RemoveTagsInRecordsRequest",
						"params": {
							"dataSourceName": "PDS",
							"filters": "$Items | crt.ToCollectionFilters : 'Items' : $DataTable_SelectionState | crt.SkipIfSelectionEmpty : $DataTable_SelectionState",
							"tagInRecordSourceSchemaName": "AccountInTag"
						}
					},
					"visible": true
				},
				"parentName": "DataTable_AddTagsBulkAction",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DataTable_ExportToExcelBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(DataTable_ExportToExcelBulkAction_caption)#",
					"icon": "export-button-icon",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "DataTable",
							"filters": "$Items | crt.ToCollectionFilters : 'Items' : $DataTable_SelectionState | crt.SkipIfSelectionEmpty : $DataTable_SelectionState"
						}
					},
					"visible": true
				},
				"parentName": "DataTable",
				"propertyName": "bulkActions",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "DataTable_DeleteBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(DataTable_DeleteBulkAction_caption)#",
					"icon": "delete-button-icon",
					"clicked": {
						"request": "crt.DeleteRecordsRequest",
						"params": {
							"dataSourceName": "PDS",
							"filters": "$Items | crt.ToCollectionFilters : 'Items' : $DataTable_SelectionState | crt.SkipIfSelectionEmpty : $DataTable_SelectionState"
						}
					},
					"visible": true
				},
				"parentName": "DataTable",
				"propertyName": "bulkActions",
				"index": 2
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
					"PDS_Name": {
						"modelConfig": {
							"path": "PDS.Name"
						}
					},
					"PDS_PrimaryContact": {
						"modelConfig": {
							"path": "PDS.PrimaryContact"
						}
					},
					"PDS_Type": {
						"modelConfig": {
							"path": "PDS.Type"
						}
					},
					"PDS_AccountCategory": {
						"modelConfig": {
							"path": "PDS.AccountCategory"
						}
					},
					"PDS_Industry": {
						"modelConfig": {
							"path": "PDS.Industry"
						}
					},
					"PDS_Web": {
						"modelConfig": {
							"path": "PDS.Web"
						}
					},
					"PDS_Country": {
						"modelConfig": {
							"path": "PDS.Country"
						}
					},
					"PDS_CreatedOn": {
						"modelConfig": {
							"path": "PDS.CreatedOn"
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
							"columnName": "Type"
						}
					]
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"dataSources",
					"PDS",
					"config"
				],
				"values": {
					"entitySchemaName": "Account",
					"attributes": {
						"Name": {
							"path": "Name"
						},
						"PrimaryContact": {
							"path": "PrimaryContact"
						},
						"Type": {
							"path": "Type"
						},
						"AccountCategory": {
							"path": "AccountCategory"
						},
						"Industry": {
							"path": "Industry"
						},
						"Web": {
							"path": "Web"
						},
						"Country": {
							"path": "Country"
						},
						"CreatedOn": {
							"path": "CreatedOn"
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