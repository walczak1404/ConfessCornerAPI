using ConfessCorner.Core.DTO;
using ConfessCorner.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConfessCorner.API.Controllers
{
    /// <summary>
    /// Posting and getting confessions
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ConfessionsController : ControllerBase
    {
        private readonly IConfessionsService _confessionsService;

        public ConfessionsController(IConfessionsService confessionsService)
        {
            _confessionsService = confessionsService;
        }

        /// <summary>
        /// Gets nth 10 confessions from database based on pageNumber parameter
        /// </summary>
        /// <param name="pageNumber">Positive integer that decides which confessions should be retrieved.</param>
        /// <returns>List of retrieved confessions</returns>
        [HttpGet("{pageNumber:int}")]
        [ProducesResponseType(typeof(IEnumerable<ConfessionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ConfessionResponse>>> GetConfessions(int pageNumber)
        {
            if (pageNumber < 1) return Problem(detail: "Page number should be a positive integer", statusCode: 400);

            var confessions = await _confessionsService.GetConfessions(pageNumber);

            return Ok(confessions);
        }

        /// <summary>
        /// Gets single confession from database based on given id
        /// </summary>
        /// <param name="confessionId">Id of searched confession</param>
        /// <returns>Found confession or Bad Request if not found</returns>
        [HttpGet("single/{confessionId:guid}")]
        [ProducesResponseType(typeof(ConfessionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ConfessionResponse>> GetConfession(Guid? confessionId)
        {
            ConfessionResponse confession;
            try
            {
                confession = await _confessionsService.GetConfessionById(confessionId);
            } catch (ArgumentNullException)
            {
                return Problem(detail: "Post id is not given", statusCode: 400);
            } catch (ArgumentException)
            {
                return Problem(detail: "Cannot find post with given id", statusCode: 400);
            }

            return Ok(confession);
        }

        /// <summary>
        /// Posts new confession in database
        /// </summary>
        /// <param name="confessionAddRequest">Confession to post</param>
        /// <returns>Posted confession</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ConfessionResponse), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ConfessionResponse>> PostConfession(ConfessionAddRequest confessionAddRequest)
        {
            ConfessionResponse response;

            try
            {
                response = await _confessionsService.PostConfession(confessionAddRequest);
            } catch(DbUpdateException e)
            {
                return Problem(detail: e.Message, statusCode: 500);
            }

            return response;
        }
    }
}
