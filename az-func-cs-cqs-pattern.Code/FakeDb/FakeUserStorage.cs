using System.Collections.Generic;
using System.Threading.Tasks;
using az_func_cs_cqs_pattern.Code;
using az_func_cs_cqs_pattern.Code.Domain;

namespace az_func_cs_cqs_pattern.Code.FakeDb
{
    public class FakeUserStorage : IUserStorage
    {
        private static readonly Dictionary<string, User> Users = new()
        {
            {"120112+0123", new User("120112+0123", "Old Raymond Floyd", "Golf professional")},
            {"120112-0123", new User("120112-0123", "Tyko Brahe Junior", "Statue")},
            {"451209-1234", new User("451209-1234", "Nisse Hult", "Carpenter")},
            {"770111-0987", new User("770111-0987", "Karl Pedal", "Cyklist")},
        };

        public async Task<(bool success, User user)> GetUserBySsn(string ssn) => Users.TryGetValue(ssn, out var user) ? (true, user) : (false, default);
    }
}