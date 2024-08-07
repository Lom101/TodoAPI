using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace TodoAPI;

public class RoleRequirementHandler : AuthorizationHandler<RoleRequirement>
{
    // custom authorization handler to handle role-based authorization
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
    {
        // Проверяем, содержит ли пользователь роль с нужным типом и значением
        if (context.User.IsInRole(requirement.Role)) 
        { 
            context.Succeed(requirement); 
        }
        return Task.CompletedTask;
    }
}

public  class  RoleRequirement : IAuthorizationRequirement
{ 
    public  string Role { get ; } 

    public  RoleRequirement ( string role )
    { 
        Role = role; 
    } 
}