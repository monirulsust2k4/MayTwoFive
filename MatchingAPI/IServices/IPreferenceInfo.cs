using MatchingAPI.DTO;
using MatchingAPI.Helper;

namespace MatchingAPI.IServices
{
    public interface IPreferenceInfo
    {

        public Task<CustomizeHelper> CreateUserPreferenceInfo(UserPreferenceDTO preference);

    }
}
