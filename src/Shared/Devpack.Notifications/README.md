# What does it do?

Library that implements the notification pattern.

# How to use it?

To use the library, just perform the following configuration in **startup.cs**:

```csharp
public void Configure(IServiceCollection services)
{
    ..
    services.AddSmartNotification();
}
```

# Facilities

### Notify

```csharp
public class ProductService
{
    private readonly INotifier _notifier;

    public ProductService(INotifier notifier)
    {
        _notifier = notifier;
    }

    public async Task CreateProduct(Product product)
    {
        ..

        await _notifier.Notify("Duplicated", "There is already a product registered with the name informed.");
    }

    // Or

    public async Task CreateProduct(Product product)
    {
        ..

        await _notifier.Notify("Duplicated", "There is already a product registered with the name informed.", HttpStatusCode.BadRequest);
    }

    // Or

    public async Task CreateProduct(Product product)
    {
        ..

        var validationResult = product.Validate();
        await _notifier.Notify(validationResult, HttpStatusCode.UnprocessableEntity);

        // Where validationResult use the FluentValidator library.
    }
}
```

### GetNotifications

```csharp
public class ProductService
{
    private readonly INotifier _notifier;

    public ProductService(INotifier notifier)
    {
        _notifier = notifier;
    }

    public async Task CreateProduct(Product product)
    {
        ..

        var notifications = _notifier.GetNotifications();

        ..
    }
}
```

### HasNotifications

```csharp
public class ProductService
{
    private readonly INotifier _notifier;

    public ProductService(INotifier notifier)
    {
        _notifier = notifier;
    }

    public void CreateProduct(Product product)
    {
        ..
        
        if(_notifier.HasNotifications)
            return;

        ..
    }
}
```

### ModelStateInterceptor

The library automatically validates the modelstate and notifies you of error messages in a return of type Badrequest (400).

Through model decorators it is possible to generate custom notifications:

```csharp
public class CreateProductModel
{
    [Required(ErrorMessage = "The Name is mandatory.")]
    public string Name { get; set; }
}
```