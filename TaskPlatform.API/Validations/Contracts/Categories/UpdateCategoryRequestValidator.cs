using TaskPlatform.API.Contracts.Categories;

namespace TaskPlatform.API.Validations.Contracts.Categories;

public class UpdateCategoryRequestValidator : TaskRequestValidatorBase<UpdateCategoryRequest>
{
    public UpdateCategoryRequestValidator()
    {
        ValidateName(request => request.Name);
    }
}
