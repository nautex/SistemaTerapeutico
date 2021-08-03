using AutoMapper;

namespace SistemaTerapeutico.API.Response
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }
        public ApiResponse(object list, IMapper mapper)
        {
            var listDto = mapper.Map<T>(list);
            Data = listDto;
        }
        public T Data { get; set; }

    }
}
