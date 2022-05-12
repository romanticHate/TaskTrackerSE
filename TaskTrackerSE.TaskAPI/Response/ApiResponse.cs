using TaskTrackerSE.Core.CustomEntities;

namespace TaskTrackerSE.TaskAPI.Response
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public Metadata Meta { get; set; }
    }
}
