using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class BusinessProblemDetails : ProblemDetails
{
    public override string ToString() => JsonConvert.SerializeObject(this);
}