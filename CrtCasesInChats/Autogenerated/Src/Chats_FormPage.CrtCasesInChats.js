define("Chats_FormPage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "RelatedChatsRefreshButton",
				"values": {
					"clicked": {
						"request": "crt.LoadDataRequest",
						"params": {
							"config": {
								"loadType": "reload",
								"useLastLoadParameters": true
							},
							"dataSourceName": "RelatedChatsListDS"
						}
					}
				}
			},
			{
				"operation": "merge",
				"name": "RelatedChatsList",
				"values": {
					"selectionState": "$RelatedChatsList_SelectionState",
					"_selectionOptions": {
						"attribute": "RelatedChatsList_SelectionState"
					}
				}
			},
			{
				"operation": "merge",
				"name": "RelatedChatsAddTagsBulkAction",
				"values": {
					"clicked": {
						"request": "crt.AddTagsInRecordsRequest",
						"params": {
							"dataSourceName": "RelatedChatsListDS",
							"filters": "$RelatedChatsList | crt.ToCollectionFilters : 'RelatedChatsList' : $RelatedChatsList_SelectionState | crt.SkipIfSelectionEmpty : $RelatedChatsList_SelectionState",
							"tagInRecordSourceSchemaName": "OmniChatInTag"
						}
					}
				}
			},
			{
				"operation": "merge",
				"name": "RelatedChatsRemoveTagsBulkAction",
				"values": {
					"clicked": {
						"request": "crt.RemoveTagsInRecordsRequest",
						"params": {
							"dataSourceName": "RelatedChatsListDS",
							"filters": "$RelatedChatsList | crt.ToCollectionFilters : 'RelatedChatsList' : $RelatedChatsList_SelectionState | crt.SkipIfSelectionEmpty : $RelatedChatsList_SelectionState",
							"tagInRecordSourceSchemaName": "OmniChatInTag"
						}
					}
				}
			},
			{
				"operation": "remove",
				"name": "RelatedChatsDeleteBulkAction"
			},
			{
				"operation": "insert",
				"name": "CasesExpansionPanel",
				"values": {
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(CasesExpansionPanel_title)#",
					"toggleType": "default",
					"togglePosition": "before",
					"expanded": true,
					"labelColor": "auto",
					"fullWidthHeader": false,
					"titleWidth": 20,
					"padding": {
						"top": "small",
						"bottom": "small",
						"left": "none",
						"right": "none"
					},
					"fitContent": true
				},
				"parentName": "RelatedInfoTabContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "CasesListToolsContainer",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 24px)",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "CasesExpansionPanel",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CasesListToolsFlexContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"gap": "none",
					"alignItems": "center",
					"items": [],
					"layoutConfig": {
						"colSpan": 1,
						"column": 1,
						"row": 1,
						"rowSpan": 1
					}
				},
				"parentName": "CasesListToolsContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CasesRefreshButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(CasesRefreshButton_caption)#",
					"icon": "reload-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.LoadDataRequest",
						"params": {
							"config": {
								"loadType": "reload",
								"useLastLoadParameters": true
							},
							"dataSourceName": "CasesListDS"
						}
					},
					"visible": true,
					"clickMode": "default"
				},
				"parentName": "CasesListToolsFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CasesSettingsButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(CasesSettingsButton_caption)#",
					"icon": "actions-button-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clickMode": "menu",
					"menuItems": [],
					"visible": true
				},
				"parentName": "CasesListToolsFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "CasesExportDataButton",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(CasesExportDataButton_caption)#",
					"icon": "export-button-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "CasesList"
						}
					},
					"visible": true
				},
				"parentName": "CasesSettingsButton",
				"propertyName": "menuItems",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CasesSearchFilter",
				"values": {
					"type": "crt.SearchFilter",
					"placeholder": "#ResourceString(CasesSearchFilter_placeholder)#",
					"iconOnly": true,
					"_filterOptions": {
						"expose": [
							{
								"attribute": "CasesSearchFilter_CasesList",
								"converters": [
									{
										"converter": "crt.SearchFilterAttributeConverter",
										"args": [
											"CasesList"
										]
									}
								]
							}
						],
						"from": [
							"CasesSearchFilter_SearchValue",
							"CasesSearchFilter_FilteredColumnsGroups"
						]
					}
				},
				"parentName": "CasesListToolsFlexContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "CasesListContainer",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 32px)",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "CasesExpansionPanel",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CasesList",
				"values": {
					"type": "crt.DataGrid",
					"layoutConfig": {
						"colSpan": 2,
						"column": 1,
						"row": 1,
						"rowSpan": 6
					},
					"features": {
						"rows": {
							"selection": {
								"enable": true,
								"multiple": true
							}
						},
						"editable": {
							"enable": false,
							"itemsCreation": false,
							"floatingEditPanel": false
						}
					},
					"items": "$CasesList",
					"selectionState": "$CasesList_SelectionState",
					"_selectionOptions": {
						"attribute": "CasesList_SelectionState"
					},
					"visible": true,
					"fitContent": true,
					"primaryColumnName": "CasesListDS_Id",
					"columns": [
						{
							"id": "b7671c6e-3892-6fbc-89ca-915f8364ef9d",
							"code": "CasesListDS_Case",
							"caption": "#ResourceString(CasesListDS_Case)#",
							"dataValueType": 10,
							"width": 113
						},
						{
							"id": "5d1addf7-4c1e-7bc9-27b5-49dbf4df4e96",
							"code": "CasesListDS_CaseSubject",
							"caption": "#ResourceString(CasesListDS_CaseSubject)#",
							"dataValueType": 30,
							"width": 338
						},
						{
							"id": "bb66e518-e01e-8d50-9125-910e52b85d05",
							"code": "CasesListDS_CaseOwner",
							"caption": "#ResourceString(CasesListDS_CaseOwner)#",
							"dataValueType": 10,
							"width": 199
						},
						{
							"id": "39c8883a-b5a6-6b5a-fd2a-ec1b67eea922",
							"code": "CasesListDS_CaseStatus",
							"caption": "#ResourceString(CasesListDS_CaseStatus)#",
							"dataValueType": 10
						},
						{
							"id": "17d7272e-f226-5c6e-f691-9ed1ec0b2880",
							"code": "CasesListDS_CaseSolutionDate",
							"caption": "#ResourceString(CasesListDS_CaseSolutionDate)#",
							"dataValueType": 7
						}
					],
					"placeholder": false,
					"bulkActions": []
				},
				"parentName": "CasesListContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CasesExportToExcelBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(CasesExportToExcelBulkAction_caption)#",
					"icon": "export-button-icon",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "CasesList",
							"filters": "$CasesList | crt.ToCollectionFilters : 'CasesList' : $CasesList_SelectionState"
						}
					},
					"visible": true
				},
				"parentName": "CasesList",
				"propertyName": "bulkActions",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CasesDeleteBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(CasesDeleteBulkAction_caption)#",
					"icon": "delete-button-icon",
					"clicked": {
						"request": "crt.DeleteRecordsRequest",
						"params": {
							"dataSourceName": "CasesListDS",
							"filters": "$CasesList | crt.ToCollectionFilters : 'CasesList' : $CasesList_SelectionState | crt.SkipIfSelectionEmpty : $CasesList_SelectionState"
						}
					},
					"visible": true
				},
				"parentName": "CasesList",
				"propertyName": "bulkActions",
				"index": 1
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"attributes"
				],
				"values": {
					"CasesList": {
						"isCollection": true,
						"modelConfig": {
							"path": "CasesListDS",
							"filterAttributes": [
								{
									"name": "CasesSearchFilter_CasesList",
									"loadOnChange": true
								}
							],
							"sortingConfig": {
								"default": [
									{
										"direction": "desc",
										"columnName": "CaseSolutionDate"
									}
								]
							}
						},
						"viewModelConfig": {
							"attributes": {
								"CasesListDS_Case": {
									"modelConfig": {
										"path": "CasesListDS.Case"
									}
								},
								"CasesListDS_CaseSubject": {
									"modelConfig": {
										"path": "CasesListDS.CaseSubject"
									}
								},
								"CasesListDS_CaseOwner": {
									"modelConfig": {
										"path": "CasesListDS.CaseOwner"
									}
								},
								"CasesListDS_CaseStatus": {
									"modelConfig": {
										"path": "CasesListDS.CaseStatus"
									}
								},
								"CasesListDS_CaseSolutionDate": {
									"modelConfig": {
										"path": "CasesListDS.CaseSolutionDate"
									}
								},
								"CasesListDS_Id": {
									"modelConfig": {
										"path": "CasesListDS.Id"
									}
								}
							}
						}
					}
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"dataSources"
				],
				"values": {
					"CasesListDS": {
						"type": "crt.EntityDataSource",
						"scope": "viewElement",
						"config": {
							"entitySchemaName": "CaseInChat",
							"attributes": {
								"Case": {
									"path": "Case"
								},
								"CaseSubject": {
									"type": "ForwardReference",
									"path": "Case.Subject"
								},
								"CaseOwner": {
									"type": "ForwardReference",
									"path": "Case.Owner"
								},
								"CaseStatus": {
									"type": "ForwardReference",
									"path": "Case.Status"
								},
								"CaseSolutionDate": {
									"type": "ForwardReference",
									"path": "Case.SolutionDate"
								}
							}
						}
					}
				}
			},
			{
				"operation": "merge",
				"path": [
					"dependencies"
				],
				"values": {
					"CasesListDS": [
						{
							"attributePath": "Chat",
							"relationPath": "PDS.Id"
						}
					]
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});