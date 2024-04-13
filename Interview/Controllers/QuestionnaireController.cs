using Interview.Database.Configuration;
using Interview.Database.Entities.Base;
using Interview.Models;
using Interview.Utilities.FakeGenerators;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Interview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class QuestionnaireController : ControllerBase
    {


        private readonly ILogger<CityAndProvinceController> _logger;
        private readonly CommandCenterContext _context;
        private readonly QuestionnaireGenerator _questionnaireGenerator;

        public QuestionnaireController(ILogger<CityAndProvinceController> logger, CommandCenterContext context, QuestionnaireGenerator questionnaireGenerator)
        {
            _logger = logger;
            _context = context;
            _questionnaireGenerator = questionnaireGenerator;
        }

        [HttpGet("GetQuestionnaire")]
        [AllowAnonymous]
        public ActionResult<Questionnaire> GetQuestionnaire()
        {
            Questionnaire questionnaire = _questionnaireGenerator.CreateFakeQuestionnaire();
            return questionnaire;
        }

    }

}