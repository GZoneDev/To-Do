using TaskPlatform.API.Contracts.TaskInfos;

namespace TaskPlatform.API.Validations.Contracts.TaskInfos;

public class UpdateTaskInfoRequestValidator : TaskRequestValidatorBase<UpdateTaskInfoRequest>
{
    public UpdateTaskInfoRequestValidator()
    {
        ValidateName(request => request.Name);
        ValidateDescription(request => request.Description);
    }
}
