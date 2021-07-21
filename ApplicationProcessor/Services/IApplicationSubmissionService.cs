namespace ULaw.ApplicationProcessor.Services
{
    using ULaw.ApplicationProcessor.Models;

    public interface IApplicationSubmissionService
    {
        string CreateSubmissionResponseEmail(ApplicationSubmission application);
    }
}
