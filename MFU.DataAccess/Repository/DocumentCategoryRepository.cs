using MFU.Models;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;

namespace MFU.DataAccess.Repository
{
    public class DocumentCategoryRepository : Repository<DocumentCategory>
    {
        public IEnumerable<DocumentCategory> GetAllWithSqlScript()
        {
            using (var conn = ConnectionFactory.Connection())
            {
                return conn.Query<DocumentCategory>(SqlText.DocumentCategory_Select).ToList();
            }
        }

        public IEnumerable<DocumentCategory> GetAllWithSqlScriptByLoadDetail()
        {
            using (var conn = ConnectionFactory.Connection())
            {
                var documentCategoryDictionary = new Dictionary<int, DocumentCategory>();
                return conn.Query<DocumentCategory, Document, DocumentCategory>(
                        SqlText.DocumentCategory_Select_WithDetail,
                        (documentCategory, document) =>
                        {
                            DocumentCategory documentCategoryEntry;

                            if (!documentCategoryDictionary.TryGetValue(documentCategory.Id, out documentCategoryEntry))
                            {
                                documentCategoryEntry = documentCategory;
                                documentCategoryEntry.Documents = new List<Document>();
                                documentCategoryDictionary.Add(documentCategoryEntry.Id, documentCategoryEntry);
                            }

                            if (document != null)
                                documentCategoryEntry.Documents.Add(document);

                            return documentCategoryEntry;
                        },
                        splitOn: "Id")
                    .Distinct()
                    .ToList();
            }
        }

        public DocumentCategory GetWithSqlScriptById(int id)
        {
            using (var conn = ConnectionFactory.Connection())
            {
                return conn.QuerySingle<DocumentCategory>(SqlText.DocumentCategory_Select_ByID,
                new { DocumentCategoryID = id });
            }
        }

        public void InsertAndRollback()
        {
            string wrongSql = "INSERT INTO DocumentCategorys (Name, Description) Values (@Name, @Description);";
            using (var conn = ConnectionFactory.Connection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        conn.Execute(wrongSql
                             , new DocumentCategory() { Name = "", Description = "xxxxxxx", Id = 1 }
                             , commandType: CommandType.Text
                             , transaction: transaction);

                        transaction.Commit();

                    }
                    catch (System.Exception)
                    {

                        transaction.Rollback();
                    }
                }
            }
           
        }

        public IEnumerable<DocumentCategory> GetAllWithPaged(int page = 1, string condition = "", string orderby = "")
        {
            using (var conn = ConnectionFactory.Connection())
            {
                return conn.GetListPaged<DocumentCategory>(page, DataAccessAppSetting.RecordPerPage, condition, orderby);
            }
        }
    }
}