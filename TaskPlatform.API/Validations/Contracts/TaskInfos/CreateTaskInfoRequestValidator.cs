using TaskPlatform.API.Contracts.Categories;
using TaskPlatform.API.Contracts.TaskInfos;

namespace TaskPlatform.API.Validations.Contracts.TaskInfos;

public class CreateTaskInfoRequestValidator : TaskRequestValidatorBase<CreateTaskInfoRequest>
{
    public CreateTaskInfoRequestValidator()
    {
        ValidateName(request => request.Name);
        ValidateDescription(request => request.Description);
    }
}
