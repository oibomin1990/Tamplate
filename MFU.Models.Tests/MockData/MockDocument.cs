using MFU.Utils;
using System.Collections.Generic;

namespace MFU.Models.Tests.MockData
{
    public class MockDocument
    {
        public static Document Get()
        {
            return Create(1);
        }

        public static IList<Document> Gets(int maxsize = 1)
        {
            var list = new List<Document>();
            for (int i = 0; i < maxsize; i++)
            {
                list.Add(Create(i + 1));
            }

            return list;
        }

        private static Document Create(int id)
        {
            return new Document()
            {
                Id = id,
                Name = MockGenerator.GetString(50),
                Description = MockGenerator.GetString(255)
            };
        }
    }
}
