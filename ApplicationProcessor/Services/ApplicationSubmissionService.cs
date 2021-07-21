namespace ULaw.ApplicationProcessor.Services
{
    using System.Text;

    using ULaw.ApplicationProcessor.Models;
    using ULaw.ApplicationProcessor.Enums;

    public class ApplicationSubmissionService : IApplicationSubmissionService
    {
        public string CreateSubmissionResponseEmail(ApplicationSubmission application)
        {
            var submissionResponse = new StringBuilder("<html><body><h1>Your Recent Application from the University of Law</h1>");

            switch (application.DegreeGrade)
            {
                case DegreeGrade.TwoTwo:
                    FormatResponseForTwoTwo(application, submissionResponse);
                    break;
                case DegreeGrade.Third:
                    FormatResponseForThird(application, submissionResponse);
                    break;
                default:
                    FormatResponseForTwoOneOrBetter(application, submissionResponse);
                    break;
            }

             submissionResponse.Append(string.Format("</body></html>"));

            return submissionResponse.ToString();
        }

        private static void FormatResponseForTwoTwo(ApplicationSubmission application, StringBuilder submissionResponse)
        {
            submissionResponse.AppendFormat("<p> Dear {0}, </p>", application.FirstName);
            submissionResponse.AppendFormat("<p/> Further to your recent application for our course reference: {0} starting on {1}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.", application.CourseCode, application.StartDate.ToLongDateString());
            submissionResponse.Append("<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk.");
            submissionResponse.Append("<br/> Yours sincerely,");
            submissionResponse.Append("<p/> The Admissions Team,");
        }

        private static void FormatResponseForThird(ApplicationSubmission application, StringBuilder submissionResponse)
        {
            submissionResponse.AppendFormat("<p> Dear {0}, </p>", application.FirstName);
            submissionResponse.Append("<p/> Further to your recent application, we are sorry to inform you that you have not been successful on this occasion.");
            submissionResponse.Append("<br/> If you wish to discuss the decision further, or discuss the possibility of applying for an alternative course with us, please contact us at AdmissionsTeam@Ulaw.co.uk.");
            submissionResponse.Append("<br> Yours sincerely,");
            submissionResponse.Append("<p/> The Admissions Team,");
        }

        private static void FormatResponseForTwoOneOrBetter(ApplicationSubmission application, StringBuilder submissionResponse)
        {
            if (application.DegreeSubject == DegreeSubject.Law || application.DegreeSubject == DegreeSubject.LawAndBusiness)
            {
                submissionResponse.AppendFormat("<p> Dear {0}, </p>", application.FirstName);
                submissionResponse.AppendFormat("<p/> Further to your recent application, we are delighted to offer you a place on our course reference: {0} starting on {1}.", application.CourseCode, application.StartDate.ToLongDateString());
                submissionResponse.AppendFormat("<br/> This offer will be subject to evidence of your qualifying {0} degree at grade: {1}.", application.DegreeSubject.ToDescription(), application.DegreeGrade.ToDescription());
                submissionResponse.Append("<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £350.00 deposit fee to secure your place.");
                submissionResponse.Append("<br/> We look forward to welcoming you to the University,");
                submissionResponse.Append("<br/> Yours sincerely,");
                submissionResponse.Append("<p/> The Admissions Team,");
            }
            else
            {
                submissionResponse.AppendFormat("<p> Dear {0}, </p>", application.FirstName);
                submissionResponse.AppendFormat("<p/> Further to your recent application for our course reference: {0} starting on {1}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.", application.CourseCode, application.StartDate.ToLongDateString());
                submissionResponse.Append("<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk.");
                submissionResponse.Append("<br/> Yours sincerely,");
                submissionResponse.Append("<p/> The Admissions Team,");
            }
        }
    }
}

