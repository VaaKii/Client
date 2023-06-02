using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebApp.Helpers;

public class ConfigureModelBindingLocalization : IConfigureOptions<MvcOptions>
{
  public void Configure(MvcOptions options)
  {
    options.ModelBindingMessageProvider
      .SetValueIsInvalidAccessor(value => $"Value {value} is invalid");
  }
}