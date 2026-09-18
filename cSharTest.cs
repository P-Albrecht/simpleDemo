[HttpPost("api/authenticate")]
[SwaggerOperation(
    Summary = "Authenticates a user",
    Description = "Authenticates a user",
    OperationId = "auth.authenticate",
    Tags = new[] { "AuthEndpoints" })
]
public override async Task<ActionResult<AuthenticateResponse>> HandleAsync(AuthenticateRequest request,
    CancellationToken cancellationToken = default)
{
    var response = new AuthenticateResponse(request.CorrelationId());
    return response;
}
