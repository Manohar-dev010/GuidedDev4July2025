 namespace Terrasoft.Configuration
{
    using System;
    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;
    using Terrasoft.Core;
    using Terrasoft.Core.Entities;
    using Terrasoft.Web.Common;
    using System.Runtime.Serialization;
    using System.Collections.Generic;
    using OfficeOpenXml; // You will need to add a reference to the EPPlus library
    using System.Web.Script.Serialization; // For JSON serialization

    [DataContract]
    public class WFMFileRequest
    {
        [DataMember(Name = "fileName")]
        public string FileName { get; set; }

        [DataMember(Name = "fileContent")]
        public byte[] FileContent { get; set; }
    }

    [DataContract]
    public class ServiceResponse
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "wfmId", EmitDefaultValue = false)]
        public string WfmId { get; set; }

        [DataMember(Name = "details", EmitDefaultValue = false)]
        public string Details { get; set; }

        [DataMember(Name = "trace", EmitDefaultValue = false)]
        public List<string> Trace { get; set; }
    }
    
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class PclWFMFileAttachmentService : BaseService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AttachWFMFile", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public ServiceResponse AttachAndParseWFMFile(WFMFileRequest request)
        {
            var traceLog = new List<string>();
            try
            {
                traceLog.Add("Service execution started.");

                if (request == null || request.FileContent == null || string.IsNullOrEmpty(request.FileName))
                {
                    throw new ArgumentException("Invalid request data. FileName and FileContent are required.");
                }
                traceLog.Add("Request data validated.");

                // 1. Create a new PclWFM record and store file data
                traceLog.Add("Step 1: Creating PclWFM record and storing file data.");
                var wfmSchema = UserConnection.EntitySchemaManager.GetInstanceByName("PclWFM");
                var wfmEntity = wfmSchema.CreateEntity(UserConnection);
                wfmEntity.SetDefColumnValues();
                // PclName is an auto-number, so we don't set it.
                // Store file name and data directly in the PclWFM record.
                wfmEntity.SetColumnValue("PclFileName", request.FileName);
                wfmEntity.SetBytesValue("PclFileData", request.FileContent);
                wfmEntity.Save();
                var wfmId = wfmEntity.PrimaryColumnValue;
                traceLog.Add($"Step 1 Complete. PclWFM record created with ID: {wfmId}. File data stored.");

                // Step 2 (Attaching file separately) is no longer needed.

                // 3. Parse the Excel file and create PclWFMData records
                traceLog.Add("Step 2: Starting Excel file parsing.");
                using (var stream = new MemoryStream(request.FileContent))
                {
                    // Using EPPlus library for parsing Excel files.
                    using (var package = new ExcelPackage(stream))
                    {
                        if (package.Workbook.Worksheets.Count == 0)
                        {
                            throw new InvalidOperationException("The provided Excel file does not contain any worksheets.");
                        }
                        var worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;
                        traceLog.Add($"Found {rowCount} rows in the first worksheet.");

                        var wfmDataSchema = UserConnection.EntitySchemaManager.GetInstanceByName("PclWFMData");

                        // Assuming the first row is the header, start from the second row
                        for (int row = 2; row <= rowCount; row++)
                        {
                            var wfmDataEntity = wfmDataSchema.CreateEntity(UserConnection);
                            wfmDataEntity.SetDefColumnValues();
                            wfmDataEntity.SetColumnValue("PclWFMLK", wfmId); // Link to the parent PclWFM record

                            // Map columns from Excel to PclWFMData fields
                            wfmDataEntity.SetColumnValue("PclWorkType", worksheet.Cells[row, 1].Value?.ToString().Trim());
                            wfmDataEntity.SetColumnValue("PclSubmissionID", worksheet.Cells[row, 2].Value?.ToString().Trim());
                            
                            wfmDataEntity.Save();
                        }
                        traceLog.Add($"Step 2 Complete. Successfully parsed and saved data for {rowCount - 1} rows.");
                    }
                }

                return new ServiceResponse {
                    Status = "success",
                    Message = "File processed successfully.",
                    WfmId = wfmId.ToString()
                };
            }
            catch (Exception ex)
            {
                // Log the full exception server-side for detailed analysis
                // Terrasoft.Core.Logging.Log.Error("Error in AttachAndParseWFMFile", ex);

                if (WebOperationContext.Current != null)
                {
                    WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                }

                return new ServiceResponse {
                    Status = "error",
                    Message = ex.Message,
                    Details = ex.ToString(),
                    Trace = traceLog
                };
            }
        }
    }
}