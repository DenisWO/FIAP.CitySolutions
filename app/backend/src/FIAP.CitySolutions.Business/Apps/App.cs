using AutoMapper;
using FIAP.CitySolutions.Business.Models.DTOs.Mapping;
using System.Net;

namespace FIAP.CitySolutions.Business.Apps
{
    public abstract class App
    {
        public IMapper Mapper { get; set; }
        public App()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
                cfg.AllowNullDestinationValues = true;
                cfg.AllowNullCollections = true;
            });

            Mapper = configurationProvider.CreateMapper();
        }
        protected AppResponse<T> Ok<T>(T data)
        {
            return new AppResponse<T>()
            {
                Data = data,
                ErrorMessage = null,
                StatusCode = HttpStatusCode.OK
            };
        }
        protected AppResponse<T> Ok<T>() where T : new()
        {
            return new AppResponse<T>()
            {
                Data = new T(),
                ErrorMessage = null,
                StatusCode = HttpStatusCode.OK
            };
        }
        protected AppResponse<T> Error<T>(Exception ex = null, AppResponse<T> data = null, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) where T : new()
        {
            string errorMessage = "";

            if (data != null)
                errorMessage = data.ErrorMessage;
            else if (ex != null)
                errorMessage = ex.Message;

            return new AppResponse<T>()
            {
                StatusCode = statusCode,
                ErrorMessage = errorMessage
            };
        }
        protected AppResponse<T> Error<T>(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) where T : new()
        {
            return new AppResponse<T>()
            {
                StatusCode = statusCode,
                ErrorMessage = errorMessage
            };
        }
    }
    public class AppResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
