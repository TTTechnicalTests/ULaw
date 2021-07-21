namespace ULaw.ApplicationProcessor.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ULaw.ApplicationProcessor;
    using ULaw.ApplicationProcessor.Enums;
    using Ulaw.ApplicationProcessor.Models;

    [TestClass]
    public class ApplicationSubmissionTests
    {
        private const string OfferEmailForFirstLawDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p> Dear Test, </p><p/> Further to your recent application, we are delighted to offer you a place on our course reference: ABC123 starting on 22 September 2019.<br/> This offer will be subject to evidence of your qualifying Law degree at grade: 1st.<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £350.00 deposit fee to secure your place.<br/> We look forward to welcoming you to the University,<br/> Yours sincerely,<p/> The Admissions Team,</body></html>";
        private const string OfferEmailForTwoOneLawDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p> Dear Test, </p><p/> Further to your recent application, we are delighted to offer you a place on our course reference: ABC123 starting on 22 September 2019.<br/> This offer will be subject to evidence of your qualifying Law degree at grade: 2:1.<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £350.00 deposit fee to secure your place.<br/> We look forward to welcoming you to the University,<br/> Yours sincerely,<p/> The Admissions Team,</body></html>";
        private const string OfferEmailForFirstLawAndBusinessDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p> Dear Test, </p><p/> Further to your recent application, we are delighted to offer you a place on our course reference: ABC123 starting on 22 September 2019.<br/> This offer will be subject to evidence of your qualifying Law and Business degree at grade: 1st.<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £350.00 deposit fee to secure your place.<br/> We look forward to welcoming you to the University,<br/> Yours sincerely,<p/> The Admissions Team,</body></html>";
        private const string OfferEmailForTwoOneLawAndBusinessDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p> Dear Test, </p><p/> Further to your recent application, we are delighted to offer you a place on our course reference: ABC123 starting on 22 September 2019.<br/> This offer will be subject to evidence of your qualifying Law and Business degree at grade: 2:1.<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £350.00 deposit fee to secure your place.<br/> We look forward to welcoming you to the University,<br/> Yours sincerely,<p/> The Admissions Team,</body></html>";

        private const string FurtherInfoEmailResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p> Dear Test, </p><p/> Further to your recent application for our course reference: ABC123 starting on 22 September 2019, we are writing to inform you that we are currently assessing your information and will be in touch shortly.<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk.<br/> Yours sincerely,<p/> The Admissions Team,</body></html>";
        private const string RejectionEmailForAnyThirdDegreeResult = @"<html><body><h1>Your Recent Application from the University of Law</h1><p> Dear Test, </p><p/> Further to your recent application, we are sorry to inform you that you have not been successful on this occasion.<br/> If you wish to discuss the decision further, or discuss the possibility of applying for an alternative course with us, please contact us at AdmissionsTeam@Ulaw.co.uk.<br> Yours sincerely,<p/> The Admissions Team,</body></html>";

        [TestMethod]
        public void ApplicationSubmissionWithFirstLawDegree()
        {
            var thisSubmission = new ApplicationSubmission("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);
            var applicationService = new ApplicationSubmissionService();

            thisSubmission.DegreeGrade = DegreeGrade.First;
            thisSubmission.DegreeSubject = DegreeSubject.Law;

            var emailHtml = applicationService.CreateSubmissionResponseEmail(thisSubmission);

            Assert.AreEqual(emailHtml, OfferEmailForFirstLawDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithFirstLawAndBusinessDegree()
        {
            var thisSubmission = new ApplicationSubmission("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);
            var applicationService = new ApplicationSubmissionService();

            thisSubmission.DegreeGrade = DegreeGrade.First;
            thisSubmission.DegreeSubject = DegreeSubject.LawAndBusiness;

            var emailHtml = applicationService.CreateSubmissionResponseEmail(thisSubmission);

            Assert.AreEqual(emailHtml, OfferEmailForFirstLawAndBusinessDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithFirstEnglishDegree()
        {
            var thisSubmission = new ApplicationSubmission("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);
            var applicationService = new ApplicationSubmissionService();

            thisSubmission.DegreeGrade = DegreeGrade.First;
            thisSubmission.DegreeSubject = DegreeSubject.English;

            var emailHtml = applicationService.CreateSubmissionResponseEmail(thisSubmission);

            Assert.AreEqual(emailHtml, FurtherInfoEmailResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoOneLawDegree()
        {
            var thisSubmission = new ApplicationSubmission("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);
            var applicationService = new ApplicationSubmissionService();

            thisSubmission.DegreeGrade = DegreeGrade.TwoOne;
            thisSubmission.DegreeSubject = DegreeSubject.Law;

            var emailHtml = applicationService.CreateSubmissionResponseEmail(thisSubmission);

            Assert.AreEqual(emailHtml, OfferEmailForTwoOneLawDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoOneMathsDegree()
        {
            var thisSubmission = new ApplicationSubmission("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);
            var applicationService = new ApplicationSubmissionService();

            thisSubmission.DegreeGrade = DegreeGrade.TwoOne;
            thisSubmission.DegreeSubject = DegreeSubject.Maths;

            var emailHtml = applicationService.CreateSubmissionResponseEmail(thisSubmission);

            Assert.AreEqual(emailHtml, FurtherInfoEmailResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoOneLawAndBusinessDegree()
        {
            var thisSubmission = new ApplicationSubmission("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);
            var applicationService = new ApplicationSubmissionService();

            thisSubmission.DegreeGrade = DegreeGrade.TwoOne;
            thisSubmission.DegreeSubject = DegreeSubject.LawAndBusiness;

            var emailHtml = applicationService.CreateSubmissionResponseEmail(thisSubmission);

            Assert.AreEqual(emailHtml, OfferEmailForTwoOneLawAndBusinessDegreeResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoTwoEnglishDegree()
        {
            var thisSubmission = new ApplicationSubmission("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);
            var applicationService = new ApplicationSubmissionService();

            thisSubmission.DegreeGrade = DegreeGrade.TwoTwo;
            thisSubmission.DegreeSubject = DegreeSubject.English;

            var emailHtml = applicationService.CreateSubmissionResponseEmail(thisSubmission);

            Assert.AreEqual(emailHtml, FurtherInfoEmailResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithTwoTwoLawDegree()
        {
            var thisSubmission = new ApplicationSubmission("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);
            var applicationService = new ApplicationSubmissionService();

            thisSubmission.DegreeGrade = DegreeGrade.TwoTwo;
            thisSubmission.DegreeSubject = DegreeSubject.Law;

            var emailHtml = applicationService.CreateSubmissionResponseEmail(thisSubmission);

            Assert.AreEqual(emailHtml, FurtherInfoEmailResult);
        }

        [TestMethod]
        public void ApplicationSubmissionWithThirdDegree()
        {
            var thisSubmission = new ApplicationSubmission("Law", "ABC123", new DateTime(2019, 9, 22), "Mr", "Test", "Tester", new DateTime(1991, 08, 14), false);
            var applicationService = new ApplicationSubmissionService();

            thisSubmission.DegreeGrade = DegreeGrade.Third;
            thisSubmission.DegreeSubject = DegreeSubject.Maths;

            var emailHtml = applicationService.CreateSubmissionResponseEmail(thisSubmission);

            Assert.AreEqual(emailHtml, RejectionEmailForAnyThirdDegreeResult);
        }
    }
  
}
