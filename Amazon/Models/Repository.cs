
using System.Collections.Generic;

namespace Amazon.Models
{
    public class Repository
    {
        public static List<BookResponse> responses = new List<BookResponse>();
        public static IEnumerable<BookResponse> Responses {
            get {
                return responses;
                }
        }
        public static void AddResponse(BookResponse response) {
            responses.Add(response);
        }
    }
}
