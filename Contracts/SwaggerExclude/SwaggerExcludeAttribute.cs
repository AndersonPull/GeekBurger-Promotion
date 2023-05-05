using System;
namespace Contracts.SwaggerExclude
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SwaggerExcludeAttribute : Attribute
    {
    }
}