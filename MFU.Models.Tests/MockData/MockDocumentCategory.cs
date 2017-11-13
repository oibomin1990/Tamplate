using MFU.Utils;
using System.Collections.Generic;

namespace MFU.Models.Tests.MockData
{
    public class MockDocumentCategory
    {
        public static DocumentCategory Get()
        {
            return Create(1);
        }

        public static IList<DocumentCategory> Gets(int maxsize = 1)
        {
            var list = new List<DocumentCategory>();
            for (int i = 0; i < maxsize; i++)
            {
                list.Add(Create(i+1));
            }

            return list;
        }

        private static DocumentCategory Create(int id)
        {
            return new DocumentCategory()
                    {
                        Id = id,
                        Name = MockGenerator.GetString(50),
                        Description = MockGenerator.GetString(255)
                    };
        }
    }
}