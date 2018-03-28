using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Selenium.Utils;

namespace Application.Tests
{
    [Binding]
    public sealed class FeatureNameStepDefinition
    {
        private string _equation;
        private decimal _result;

        [Given("the equation of (.*)")]
        public void FillValue(string equation)
        {
            _equation = equation;
        }

        [When("I request the result of the operation")]
        public void ProcessCalculation()
        {
            FlowExecution(Browser.Chrome.ToString());
            FlowExecution(Browser.Edge.ToString());
            FlowExecution(Browser.InternetExplorer.ToString());
        }

        [Then("the result will be (.*)")]
        public void CheckResult(decimal result)
        {
            Assert.AreEqual(result, _result);
        }

        private void FlowExecution (string browser)
        {
            var page = new FeatureNamePage((Browser)Enum.Parse(typeof(Browser), browser));
            page.LoadPage();
            page.FillValue(_equation);
            page.ProcessCalculation();
            _result = page.GetResult();
            page.Close();
        }
    }
}
