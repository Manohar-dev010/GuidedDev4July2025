define("ContactsAnalyticsDashboard", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "NumberOfContactsWidget",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 3,
						"row": 1,
						"rowSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(NumberOfContactsWidget_title)#",
						"data": {
							"providing": {
								"attribute": "IndicatorWidget_2paavl5_Data",
								"schemaName": "Contact",
								"filters": {
									"filter": {
										"items": {},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "Contact"
									},
									"filterAttributes": []
								},
								"aggregation": {
									"column": {
										"orderDirection": 0,
										"orderPosition": -1,
										"isVisible": true,
										"expression": {
											"expressionType": 1,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Id"
											},
											"functionType": 2,
											"aggregationType": 1,
											"aggregationEvalType": 2
										}
									}
								},
								"dependencies": [
									{
										"attributePath": "Id",
										"relationPath": "DashboardDS.Id"
									}
								]
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"decimalPrecision": 0,
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(NumberOfContactsWidget_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium",
							"labelPosition": "above-under"
						},
						"layout": {
							"color": "steel-blue",
							"icon": {
								"iconName": "contact-group-icon"
							}
						},
						"theme": "without-fill"
					},
					"visible": true
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ContactsWithoutCommunicationOptionWidget",
				"values": {
					"layoutConfig": {
						"column": 4,
						"colSpan": 3,
						"row": 1,
						"rowSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(ContactsWithoutCommunicationOptionWidget_title)#",
						"data": {
							"providing": {
								"attribute": "IndicatorWidget_d05ju5a_Data",
								"schemaName": "Contact",
								"filters": {
									"filter": {
										"items": {
											"e5fda86f-45cb-4be8-9d55-0462d61f7615": {
												"filterType": 5,
												"comparisonType": 16,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "[ContactCommunication:Contact].Id"
												},
												"isAggregative": true,
												"dataValueType": 0,
												"subFilters": {
													"items": {},
													"logicalOperation": 0,
													"isEnabled": false,
													"filterType": 6,
													"rootSchemaName": "ContactCommunication",
													"key": "83619b21-5acc-47db-ad00-9c938f2985d1"
												}
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "Contact"
									},
									"filterAttributes": []
								},
								"aggregation": {
									"column": {
										"orderDirection": 0,
										"orderPosition": -1,
										"isVisible": true,
										"expression": {
											"expressionType": 1,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Id"
											},
											"functionType": 2,
											"aggregationType": 1,
											"aggregationEvalType": 2
										}
									}
								},
								"dependencies": [
									{
										"attributePath": "Id",
										"relationPath": "DashboardDS.Id"
									}
								]
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"decimalPrecision": 0,
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(ContactsWithoutCommunicationOptionWidget_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium",
							"labelPosition": "above-under"
						},
						"layout": {
							"color": "cadmium-red",
							"icon": {
								"iconName": "contact-call-center-icon"
							}
						},
						"theme": "without-fill"
					},
					"visible": true
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "NewContactsThisMonthWidget",
				"values": {
					"layoutConfig": {
						"column": 7,
						"colSpan": 3,
						"row": 1,
						"rowSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(NewContactsThisMonthWidget_title)#",
						"data": {
							"providing": {
								"attribute": "IndicatorWidget_jx2ovgn_Data",
								"schemaName": "Contact",
								"filters": {
									"filter": {
										"items": {
											"8df1f9df-189e-4301-b477-4f3a2d123b3a": {
												"filterType": 1,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": true,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "CreatedOn"
												},
												"isAggregative": false,
												"dataValueType": 7,
												"rightExpression": {
													"expressionType": 1,
													"functionType": 1,
													"macrosType": 10
												}
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "Contact"
									},
									"filterAttributes": []
								},
								"aggregation": {
									"column": {
										"orderDirection": 0,
										"orderPosition": -1,
										"isVisible": true,
										"expression": {
											"expressionType": 1,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Id"
											},
											"functionType": 2,
											"aggregationType": 1,
											"aggregationEvalType": 2
										}
									}
								},
								"dependencies": [
									{
										"attributePath": "Id",
										"relationPath": "DashboardDS.Id"
									}
								]
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"decimalPrecision": 0,
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(NewContactsThisMonthWidget_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium",
							"labelPosition": "above-under"
						},
						"layout": {
							"color": "dark-turquoise",
							"icon": {
								"iconName": "diagram-icon"
							}
						},
						"theme": "without-fill"
					},
					"visible": true
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ContactsWithoutAccountWidget",
				"values": {
					"layoutConfig": {
						"column": 10,
						"colSpan": 3,
						"row": 1,
						"rowSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(ContactsWithoutAccountWidget_title)#",
						"data": {
							"providing": {
								"attribute": "IndicatorWidget_e8icns9_Data",
								"schemaName": "Contact",
								"filters": {
									"filter": {
										"items": {
											"b48068d9-89ac-4cc8-8337-18efc08a290e": {
												"filterType": 2,
												"comparisonType": 1,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "Account"
												},
												"isAggregative": false,
												"dataValueType": 10,
												"referenceSchemaName": "Account",
												"isNull": true
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "Contact"
									},
									"filterAttributes": []
								},
								"aggregation": {
									"column": {
										"orderDirection": 0,
										"orderPosition": -1,
										"isVisible": true,
										"expression": {
											"expressionType": 1,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Id"
											},
											"functionType": 2,
											"aggregationType": 1,
											"aggregationEvalType": 2
										}
									}
								},
								"dependencies": [
									{
										"attributePath": "Id",
										"relationPath": "DashboardDS.Id"
									}
								]
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"decimalPrecision": 0,
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(ContactsWithoutAccountWidget_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium",
							"labelPosition": "above-under"
						},
						"layout": {
							"color": "cadmium-red",
							"icon": {
								"iconName": "work-icon"
							}
						},
						"theme": "without-fill"
					},
					"visible": true
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "ContactsByTypeWidget",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 6,
						"row": 4,
						"rowSpan": 8
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(ContactsByTypeWidget_title)#",
						"color": "dark-blue",
						"theme": "without-fill",
						"scales": {
							"stacked": false,
							"xAxis": {
								"name": "",
								"formatting": {
									"type": "string",
									"maxLinesCount": 2,
									"maxLineLength": 10
								}
							},
							"yAxis": {
								"name": "",
								"formatting": {
									"type": "number",
									"thousandAbbreviation": {
										"enabled": true
									}
								}
							}
						},
						"series": [
							{
								"type": "doughnut",
								"label": "#ResourceString(ContactsByTypeWidget_series_0)#",
								"legend": {
									"enabled": false
								},
								"data": {
									"providing": {
										"attribute": "ChartWidget_uuhu19f_SeriesData_gjiipy1",
										"schemaName": "Contact",
										"filters": {
											"filter": {
												"items": {
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "Type"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Contact"
											},
											"filterAttributes": []
										},
										"aggregation": {
											"column": {
												"orderDirection": 0,
												"orderPosition": -1,
												"isVisible": true,
												"expression": {
													"expressionType": 1,
													"functionArgument": {
														"expressionType": 0,
														"columnPath": "Id"
													},
													"functionType": 2,
													"aggregationType": 1,
													"aggregationEvalType": 2
												}
											}
										},
										"dependencies": [
											{
												"attributePath": "Id",
												"relationPath": "DashboardDS.Id"
											}
										],
										"rowCount": 50,
										"grouping": {
											"type": "by-value",
											"column": {
												"orderDirection": 0,
												"orderPosition": -1,
												"isVisible": true,
												"expression": {
													"expressionType": 0,
													"columnPath": "Type"
												}
											}
										}
									},
									"formatting": {
										"type": "number",
										"decimalSeparator": ".",
										"decimalPrecision": 0,
										"thousandSeparator": ","
									}
								},
								"dataLabel": {
									"display": false
								}
							}
						],
						"seriesOrder": {
							"type": "by-grouping-value",
							"direction": 1
						},
						"layout": {}
					},
					"sectionBindingColumnRecordId": "$Id"
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "ContactsByJobTitleWidget",
				"values": {
					"layoutConfig": {
						"column": 7,
						"colSpan": 6,
						"row": 4,
						"rowSpan": 8
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(ContactsByJobTitleWidget_title)#",
						"color": "dark-blue",
						"theme": "without-fill",
						"scales": {
							"stacked": false,
							"xAxis": {
								"name": "",
								"formatting": {
									"type": "string",
									"maxLinesCount": 2,
									"maxLineLength": 10
								}
							},
							"yAxis": {
								"name": "",
								"formatting": {
									"type": "number",
									"thousandAbbreviation": {
										"enabled": true
									}
								}
							}
						},
						"series": [
							{
								"color": "dark-turquoise",
								"type": "bar",
								"label": "#ResourceString(ContactsByJobTitleWidget_series_0)#",
								"legend": {
									"enabled": false
								},
								"data": {
									"providing": {
										"attribute": "ChartWidget_1klzs9i_SeriesData_bncdet9",
										"schemaName": "Contact",
										"filters": {
											"filter": {
												"items": {
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "Job"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Contact"
											},
											"filterAttributes": []
										},
										"aggregation": {
											"column": {
												"orderDirection": 0,
												"orderPosition": -1,
												"isVisible": true,
												"expression": {
													"expressionType": 1,
													"functionArgument": {
														"expressionType": 0,
														"columnPath": "Id"
													},
													"functionType": 2,
													"aggregationType": 1,
													"aggregationEvalType": 2
												}
											}
										},
										"dependencies": [
											{
												"attributePath": "Id",
												"relationPath": "DashboardDS.Id"
											}
										],
										"rowCount": 50,
										"grouping": {
											"type": "by-value",
											"column": {
												"orderDirection": 0,
												"orderPosition": -1,
												"isVisible": true,
												"expression": {
													"expressionType": 0,
													"columnPath": "Job"
												}
											}
										}
									},
									"formatting": {
										"type": "number",
										"decimalSeparator": ".",
										"decimalPrecision": 0,
										"thousandSeparator": ","
									}
								},
								"dataLabel": {
									"display": true
								}
							}
						],
						"seriesOrder": {
							"type": "by-aggregation-value",
							"direction": 2,
							"seriesIndex": 0
						},
						"layout": {}
					},
					"sectionBindingColumnRecordId": "$Id"
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "ContactsByPreferredLanguageWidget",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 12,
						"row": 12,
						"rowSpan": 8
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(ContactsByPreferredLanguageWidget_title)#",
						"color": "dark-blue",
						"theme": "without-fill",
						"scales": {
							"stacked": false,
							"xAxis": {
								"name": "",
								"formatting": {
									"type": "string",
									"maxLinesCount": 2,
									"maxLineLength": 10
								}
							},
							"yAxis": {
								"name": "",
								"formatting": {
									"type": "number",
									"thousandAbbreviation": {
										"enabled": true
									}
								}
							}
						},
						"series": [
							{
								"color": "burnt-coral",
								"type": "bar",
								"label": "#ResourceString(ContactsByPreferredLanguageWidget_series_0)#",
								"legend": {
									"enabled": false
								},
								"data": {
									"providing": {
										"attribute": "ChartWidget_eqyz262_SeriesData_ho9lj47",
										"schemaName": "Contact",
										"filters": {
											"filter": {
												"items": {
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "Language"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Contact"
											},
											"filterAttributes": []
										},
										"aggregation": {
											"column": {
												"orderDirection": 0,
												"orderPosition": -1,
												"isVisible": true,
												"expression": {
													"expressionType": 1,
													"functionArgument": {
														"expressionType": 0,
														"columnPath": "Id"
													},
													"functionType": 2,
													"aggregationType": 1,
													"aggregationEvalType": 2
												}
											}
										},
										"dependencies": [
											{
												"attributePath": "Id",
												"relationPath": "DashboardDS.Id"
											}
										],
										"rowCount": 50,
										"grouping": {
											"type": "by-value",
											"column": {
												"orderDirection": 0,
												"orderPosition": -1,
												"isVisible": true,
												"expression": {
													"expressionType": 0,
													"columnPath": "Language"
												}
											}
										}
									},
									"formatting": {
										"type": "number",
										"decimalSeparator": ".",
										"decimalPrecision": 0,
										"thousandSeparator": ","
									}
								},
								"dataLabel": {
									"display": true
								}
							}
						],
						"seriesOrder": {
							"type": "by-aggregation-value",
							"direction": 2,
							"seriesIndex": 0
						},
						"layout": {}
					},
					"sectionBindingColumnRecordId": "$Id"
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 6
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [],
				"values": {
					"attributes": {}
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [],
				"values": {
					"loadingConfig": {},
					"dataSources": {}
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});