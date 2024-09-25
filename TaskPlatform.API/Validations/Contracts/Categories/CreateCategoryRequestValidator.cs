using TaskPlatform.API.Contracts.Categories;

namespace TaskPlatform.API.Validations.Contracts.Categories;

public class CreateCategoryRequestValidator : TaskRequestValidatorBase<CreateCategoryRequest>
{
    public CreateCategoryRequestValidator()
    {
        ValidateName(request => request.Name);
    }
}
