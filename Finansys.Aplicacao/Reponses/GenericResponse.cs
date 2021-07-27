using System;
using System.Collections.Generic;

namespace Finansys.Aplicacao.Reponses
{
    public class GenericResponse
    {
        public string Status { get; set; }

        public GenericResponse(string status)
        {
            Status = status;
        }

        public static GenericResponse Ok()
        {
            return new GenericResponse("OK");
        }

        public static ErrorResponse Error(List<String> errors)
        {
            return new ErrorResponse(errors);
        }

        public static ErrorResponse Error(String error)
        {
            return new ErrorResponse(new List<String> { error });
        }

        public static DataResponse<T> Ok<T>(T data)
        {
            return new DataResponse<T>("OK", data);
        }
    }

    public class ErrorResponse : GenericResponse
    {
        public List<String> Errors { get; set; }

        public ErrorResponse(List<String> errors) : base("Error")
        {
            Errors = errors;
        }
    }

    public class DataResponse<T> : GenericResponse
    {
        public T Data { get; set; }

        public DataResponse(String status, T data) : base(status)
        {
            Data = data;
        }
    }

}
