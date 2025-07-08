define("ServiceObjectDetail", ["ServiceDeskConstants"], function(ServiceDeskConstants) {
			return {
				entitySchemaName: "ServiceObject",
				attributes: {
					MasterColumnName: {
						dataValueType: Terrasoft.DataValueType.TEXT
					},
					LookupTypeColumnName: {
						dataValueType: Terrasoft.DataValueType.TEXT
					}
				},
				messages: {},
				methods: {
					/**
					 * @inheritdoc Terrasoft.BaseGridDetailV2#getCopyRecordMenuItem
					 * @overridden
					 */
					getCopyRecordMenuItem: this.Terrasoft.emptyFn,

					/**
					 * @inheritdoc Terrasoft.BaseGridDetailV2#getEditRecordMenuItem
					 * @overridden
					 */
					getEditRecordMenuItem: this.Terrasoft.emptyFn,

					/**
					 * Returns the column, which is always selected by the query.
					 * @protected
					 * @override
					 * @return {Object} Returns an array of configurations of objects columns
					 */
					getGridDataColumns: function() {
						return {
							"Account": {
								path: "Account"
							}
						};
					},

					/**
					 * Initializes the initial values of the model
					 * @protected
					 * @override
					 */
					init: function() {
						this.set("MasterColumnName", "ServicePact");
						this.set("LookupTypeColumnName", "Type");
						this.callParent(arguments);
					},

					/**
					 * Возвращает значение активной записи реестра.
					 * @private
					 * @returns {*|Object} Возвращает активную запись реестра или null если их несколько/не выбрана ни одна
					 */
					getSelectedRecord: function() {
						var selectedItems = this.getSelectedItems();
						if (selectedItems && (selectedItems.length === 1)) {
							return this.getGridData().get(selectedItems[0]);
						}
					},

					isMasterRecordNew: function() {
						var cardState = this.sandbox.publish("GetCardState", null, [this.sandbox.id]);
						var isNew = (cardState.state === this.Terrasoft.ConfigurationEnums.CardOperation.ADD ||
						cardState.state === this.Terrasoft.ConfigurationEnums.CardOperation.COPY);
						return isNew;
					},

					/**
					 * Сохраняет родительскую запись если она новая либо скопированная.
					 * @private
					 */
					saveMasterRecord: function() {
						var args = {
							isSilent: true,
							messageTags: [this.sandbox.id]
						};
						this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
					},

					/**
					 * Обработчик нажатия на кнопку добавления контакта.
					 * Открывает реестр контактов.
					 * @protected
					 */
					addContact: function() {
						var addRecordConfig = {
							typeColumnValue: ServiceDeskConstants.ServiceObjectType.Contact,
							lookupSchemaName: "Contact",
							valueColumnName: "Contact"
						};
						this.addRecordLookup(addRecordConfig, this.selectContactCallback, this);
					},

					/**
					 * Обрабочик выбора контактов из реестра справочника при добавлении.
					 * Выполняет добавление контактов в объекты обслуживания.
					 * @protected
					 * @param {Object} config Конфигурация выбранных записей
					 */
					selectContactCallback: function(config) {
						config.getInsertQuery = this.getContactInsertQuery;
						this.selectCallback(config);
					},

					/**
					 * Генерирует запрос на добавление объектов обслуживания контактов.
					 * @param {Object} item Выбранный контакт
					 * @protected
					 * @returns {Terrasoft.InsertQuery} Запрос на добавление объектов обслуживания
					 */
					getContactInsertQuery: function(item) {
						var typeId = ServiceDeskConstants.ServiceObjectType.Contact;
						var valueColumnName = "Contact";
						return this.getInsertQuery(valueColumnName, item, typeId);
					},

					/**
					 * Обработчик нажатия на кнопку добавления контрагента.
					 * Открывает реестр контрагентов.
					 * @protected
					 */
					addAccount: function() {
						var addRecordConfig = {
							typeColumnValue: ServiceDeskConstants.ServiceObjectType.Account,
							lookupSchemaName: "Account",
							valueColumnName: "Account"
						};
						this.addRecordLookup(addRecordConfig, this.selectAccountCallback, this);
					},

					/**
					 * Обрабочик выбора контрагентов из реестра справочника при добавлении.
					 * Выполняет добавление контрагентов в объекты обслуживания.
					 * @protected
					 * @param {Object} args Конфигурация выбранных записей
					 */
					selectAccountCallback: function(args) {
						args.getInsertQuery = this.getAccountInsertQuery;
						args.scope = this;
						this.selectCallback(args);
					},

					/**
					 * Генерирует запрос на добавление объектов обслуживания контрагентов.
					 * @protected
					 * @param {Object} item Выбранный контрагент
					 * @returns {Terrasoft.InsertQuery} Запрос на добавление объектов обслуживания
					 */
					getAccountInsertQuery: function(item) {
						var typeId = ServiceDeskConstants.ServiceObjectType.Account;
						var valueColumnName = "Account";
						return this.getInsertQuery(valueColumnName, item, typeId);
					},

					/**
					 * Обработчик нажатия на кнопку создание департаментов.
					 * Открывает реестр департаментов выбранного контрагента.
					 * @protected
					 */
					createDepartments: function() {
						const lookupConfig = {
							entitySchemaName: "Department",
							multiSelect: true
						};
						this.openLookup(lookupConfig, this.selectDepartmentCallback, this);
					},

					/**
					 * Обрабочик выбора департаментов из реестра справочника при добавлении.
					 * Выполняет добавление департаментов в объекты обслуживания.
					 * @protected
					 * @param {Object} config Конфигурация выбранных записей
					 */
					selectDepartmentCallback: function(config) {
						config.getInsertQuery = this.getDepartmentInsertQuery;
						config.onRecordInsert = this.onDepartmentsInsert;
						this.selectCallback(config);
					},

					/**
					 * Генерирует запрос на добавление объектов обслуживания департаментов.
					 * @protected
					 * @param {Object} item Выбранные департаменты
					 * @returns {Terrasoft.InsertQuery} Запрос на добавление объектов обслуживания
					 */
					getDepartmentInsertQuery: function(item) {
						var typeId = ServiceDeskConstants.ServiceObjectType.Department;
						var valueColumnName = "Department";
						var insertQuery = this.getInsertQuery(valueColumnName, item, typeId);
						var selectedAccountId = this.getSelectedRecord().get("Account").value;
						insertQuery.setParameterValue("Account", selectedAccountId, this.Terrasoft.DataValueType.GUID);
						return insertQuery;
					},

					/**
					 * Обработчик добавления департаментов.
					 * Удаляет активную запись объекта обслуживания контрагента и обновляет реестр.
					 * @protected
					 * @param {Object} response Возвращаемый объект после добавления записей
					 */
					onDepartmentsInsert: function(response) {
						var departmentResponse = this.Terrasoft.deepClone(response);
						this.showBodyMask();
						this.callService({
							serviceName: "GridUtilitiesService",
							methodName: "DeleteRecords",
							data: {
								primaryColumnValues: this.getSelectedItems(),
								rootSchema: this.entitySchema.name
							}
						}, function(responseObject) {
							this.hideBodyMask();
							var result = this.Ext.decode(responseObject.DeleteRecordsResult);
							var success = result.Success;
							var deletedItems = result.DeletedItems;
							this.removeGridRecords(deletedItems);
							if (!success) {
								this.showDeleteExceptionMessage(result);
							}
							this.onRecordInsert(departmentResponse);
						}, this);
					},

					/**
					 * Возвращает признак доступности пункта меню создания департаментов.
					 * Доступен если выбрана запись контрагента без указания департамента.
					 * @protected
					 * @returns {boolean}
					 */
					getCreateDepartmentsMenuEnabled: function() {
						var selectedRecord = this.getSelectedRecord();
						return selectedRecord && selectedRecord.get("Account") &&
								!selectedRecord.get("Department");
					},

					/**
					 * Opens the selection page from the directory for adding records.
					 * @protected
					 * @param {Object} config Configuration of adding records.
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Context for callback function.
					 */
					addRecordLookup: function(config, callback, scope) {
						function addRecordLookupInner() {
							config.valueColumnName = config.valueColumnName || "Id";
							config.isLookupMultiSelect = true;
							var lookupConfig = {
								entitySchemaName: config.lookupSchemaName,
								multiSelect: config.isLookupMultiSelect
							};
							lookupConfig.filters = this.getExistingRecordsFilter(config);
							this.openLookup(lookupConfig, callback, scope);
						}
						if (this.isMasterRecordNew()) {
							this.set("onSavedMethod", addRecordLookupInner);
							this.saveMasterRecord();
						} else {
							addRecordLookupInner.call(this);
						}
					},

					/**
					 * Обработчик события сохранения карточки раздела.
					 * Если сохранение вызвано попыткой добавления записи на деталь, то открывается страница
					 * добавления записи на деталь (либо выбор из справочника).
					 * @protected
					 * @override
					 */
					onCardSaved: function() {
						var onSavedMethod = this.get("onSavedMethod");
						if (onSavedMethod) {
							onSavedMethod.call(this);
						}
					},

					/**
					 * Function - create filters with existed record.
					 * Open lookup page with elements wich not exist in this object.
					 * @protected
					 * @param {Object} result Result with exist record.
					 * @param {Object} config Configuration of adding records.
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Context for calback function.
					 * @obsolete
					 */
					onGetExistsRecords: function(result, config, callback, scope) {
						var lookupSchemaName = config.lookupSchemaName;
						var isMultiSelect = config.isLookupMultiSelect;
						var valueColumnName = config.valueColumnName;

						var existsItems = [];
						if (result.success) {
							result.collection.each(function(item) {
								var columnValue = item.get(valueColumnName);
								existsItems.push(Ext.isObject(columnValue) ? columnValue.value : columnValue);
							});
						}
						var lookupConfig = {
							entitySchemaName: lookupSchemaName,
							multiSelect: isMultiSelect
						};
						var existsFilter = this.Terrasoft.createColumnInFilterWithParameters("Id", existsItems);
						existsFilter.comparisonType = this.Terrasoft.ComparisonType.NOT_EQUAL;
						existsFilter.Name = "existsFilter";
						lookupConfig.filters = existsFilter;
						this.openLookup(lookupConfig, callback, scope);
					},

					/**
					 * Returns filter with existing records.
					 * @param {Object} config Configuration of adding records.
					 * @return {Terrasoft.FilterGroup} Filters which exclude existing records.
					 */
					getExistingRecordsFilter: function(config) {
						var valueColumnName = config.valueColumnName;
						var filters = Terrasoft.createFilterGroup();
						var notExistsFilter = Terrasoft.createNotExistsFilter(
							"[ServiceObject:" + valueColumnName +":Id].Id");
						notExistsFilter.Name = "notExistsFilter";
						var masterRecordFilter = Terrasoft.createColumnFilterWithParameter(
							Terrasoft.ComparisonType.EQUAL, "ServicePact", this.$MasterRecordId);
						masterRecordFilter.Name = "masterRecordFilter";
						notExistsFilter.subFilters.addItem(masterRecordFilter);
						filters.addItem(notExistsFilter);
						return filters;
					},

					/**
					 * Добавляет фильтры для реестра выбора из справочника при добавлении новой записи.
					 * @protected
					 * @param {Terrasoft.EntitySchemaQuery} esq �?значальный запрос
					 * @param {Object} config Конфигурация добавления записи
					 * @obsolete
					 */
					addRecordLookupFilters: function(esq, config) {
						var typeColumnValue = config.typeColumnValue;
						var additionalFilter = config.additionalFilter;
						var masterColumnName = this.get("MasterColumnName");
						var masterRecordId = this.get("MasterRecordId");
						var typeColumnName = this.get("LookupTypeColumnName");
						esq.filters.add("masterRecordFilter", this.Terrasoft.createColumnFilterWithParameter(
								this.Terrasoft.ComparisonType.EQUAL, masterColumnName, masterRecordId));
						if (typeColumnValue && typeColumnName) {
							esq.filters.add("typeFilter", this.Terrasoft.createColumnFilterWithParameter(
									this.Terrasoft.ComparisonType.EQUAL, typeColumnName, typeColumnValue));
						}
						if (additionalFilter) {
							esq.filters.add("additionalFilter", additionalFilter);
						}
					},

					/**
					 * Выпоняет добавление выбранных записей используя BatchQuery.
					 * @protected
					 * @param {Object} config Конфигурация выбранных записей
					 */
					selectCallback: function(config) {
						var getInsertQuery = config.getInsertQuery;
						var onRecordInsert = config.onRecordInsert || this.onRecordInsert;
						var bq = this.Ext.create("Terrasoft.BatchQuery");
						this.selectedRows = config.selectedRows.getItems();
						this.selectedItems = [];
						this.selectedRows.forEach(function(item) {
							bq.add(getInsertQuery.call(this, item));
							this.selectedItems.push(item.value);
						}, this);
						if (bq.queries.length) {
							this.showBodyMask.call(this);
							bq.execute(onRecordInsert, this);
						}
					},

					/**
					 * Генерирует запрос на добавление сущности.
					 * @protected
					 * @param {String} valueColumnName Название колонки, в которую проставляется выбранное значение
					 * @param {Object} valueItem Выбранное значение
					 * @param {String} typeId Значение колонки типа
					 * @returns {Terrasoft.InsertQuery} Запрос на добавление сущности
					 */
					getInsertQuery: function(valueColumnName, valueItem, typeId) {
						var typeColumnName = this.get("LookupTypeColumnName");
						var masterRecordId = this.get("MasterRecordId");
						var masterColumnName = this.get("MasterColumnName");
						var insert = Ext.create("Terrasoft.InsertQuery", {
							rootSchemaName: this.entitySchemaName
						});
						insert.setParameterValue(masterColumnName, masterRecordId, this.Terrasoft.DataValueType.GUID);
						insert.setParameterValue(valueColumnName, valueItem.value, this.Terrasoft.DataValueType.GUID);
						if (typeColumnName && typeId) {
							insert.setParameterValue(typeColumnName, typeId, this.Terrasoft.DataValueType.GUID);
						}
						return insert;
					},

					/**
					 ** Добавляет элемент "Определить департаменты обслуживания" в коллекцию выпадающего списка функциональной кнопки.
					 * @inheritdoc Terrasoft.BaseGridDetailV2#addRecordOperationsMenuItems
					 * @overridden
					 */
					addRecordOperationsMenuItems: function(toolsButtonMenu) {
						this.callParent(arguments);
						toolsButtonMenu.addItem(this.getButtonMenuSeparator());
						toolsButtonMenu.addItem(this.getButtonMenuItem({
							"Caption": {
								"bindTo": "Resources.Strings.CreateDepartmentsMenuCaption"
							},
							"Click": {
								"bindTo": "createDepartments"
							},
							"Enabled": {
								"bindTo": "getCreateDepartmentsMenuEnabled"
							}
						}));
					},
					/**
					 * Обновляет реестр после добавления записей на деталь.
					 * @protected
					 * @param {Object} response Содержит ответ с результатом добавления записей
					 */
					onRecordInsert: function(response) {
						this.hideBodyMask.call(this);
						this.beforeLoadGridData();
						var insertedIds = [];
						response.queryResults.forEach(function(item) {
							insertedIds.push(item.id);
						});
						var esq = Ext.create("Terrasoft.EntitySchemaQuery", {
							rootSchemaName: this.entitySchemaName
						});
						this.initQueryColumns(esq);
						esq.filters.add("idFilter", Terrasoft.createColumnInFilterWithParameters("Id", insertedIds));
						esq.getEntityCollection(function(response) {
							this.afterLoadGridData();
							if (response.success) {
								var responseCollection = response.collection;
								this.prepareResponseCollection(responseCollection);
								this.getGridData().loadAll(responseCollection);
							}
						}, this);
					},
					/**
					 * @inheritDoc Terrasoft.GridUtilitiesV2#getFilterDefaultColumnName
					 * @overridden
					 */
					getFilterDefaultColumnName: function() {
						return "Account";
					}
				},
				diff: [
					{
						"operation": "merge",
						"name": "AddRecordButton",
						"values": {
							"visible": false
						}
					},
					{
						"operation": "merge",
						"name": "AddTypedRecordButton",
						"parentName": "Detail",
						"propertyName": "tools",
						"index": 1,
						"values": {
							"visible": {
								"bindTo": "getToolsVisible"
							},
							"itemType": this.Terrasoft.ViewItemType.BUTTON,
							"menu": []
						}
					},
					{
						"operation": "insert",
						"name": "AddContactMenu",
						"parentName": "AddTypedRecordButton",
						"propertyName": "menu",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.AddContactMenuCaption"
							},
							"click": {
								"bindTo": "addContact"
							}
						}
					},
					{
						"operation": "insert",
						"name": "AddAccountMenu",
						"parentName": "AddTypedRecordButton",
						"propertyName": "menu",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.AddAccountMenuCaption"
							},
							"click": {
								"bindTo": "addAccount"
							}
						}
					},
					{
						"operation": "merge",
						"name": "EditRecordMenu",
						"values": {
							"visible": false
						}
					},
					{
						"operation": "merge",
						"name": "CopyRecordMenu",
						"values": {
							"visible": false
						}
					}
				]
			};
		}
);
