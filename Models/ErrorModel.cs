namespace StudentAPI.Models;

public class ErrorModel
{
   public int StatusCode { get; set; }
   public string ErrorMessage { get; set; }

   public ErrorModel(int code, string message)
   {
       StatusCode = code;
       ErrorMessage = message;
   }
}

//public record ErrorModel(int StatusCode, string ErrorMessage);
