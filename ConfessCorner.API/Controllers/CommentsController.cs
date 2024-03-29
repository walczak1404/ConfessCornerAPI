using ConfessCorner.Core.DTO;
using ConfessCorner.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConfessCorner.API.Controllers
{
    /// <summary>
    /// Posting and getting comments
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        /// <summary>
        /// Gets comments for confession with given id
        /// </summary>
        /// <param name="confessionId">Id of confession</param>
        /// <returns>List of comments for specified confession</returns>
        [HttpGet("{confessionId:guid}")]
        [ProducesResponseType(typeof(IEnumerable<CommentResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CommentResponse>>> GetCommentsForConfession(Guid confessionId)
        {
            IEnumerable<CommentResponse> comments;
            
            try
            {
                comments = await _commentsService.GetCommentsforConfession(confessionId);
            } catch(ArgumentNullException)
            {
                return Problem(detail: "Post id is not given", statusCode: 400);
            } catch(ArgumentException)
            {
                return Problem(detail: "Cannot find post with given id", statusCode: 400);
            }

            return Ok(comments);
        }

        /// <summary>
        /// Gets amount of comments for confession with given id from database
        /// </summary>
        /// <param name="confessionId">Id of confession</param>
        /// <returns>Amount of comments</returns>
        [HttpGet("Amount/{confessionId:guid}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> GetCommentsAmountForConfession(Guid confessionId)
        {
            int commentsAmount;

            try
            {
                commentsAmount = await _commentsService.GetCommentsAmountforConfession(confessionId);
            } catch (ArgumentNullException)
            {
                return Problem(detail: "Post id is not given", statusCode: 400);
            } catch (ArgumentException)
            {
                return Problem(detail: "Cannot find post with given id", statusCode: 400);
            }

            return commentsAmount;
        }

        /// <summary>
        /// Posts comment for confession with given confessionId in comment DTO
        /// </summary>
        /// <param name="commentAddRequest">Posted comment</param>
        /// <returns>Posted comment</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CommentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CommentResponse>> PostComment(CommentAddRequest commentAddRequest)
        {
            CommentResponse commentResponse;
            try
            {
                commentResponse = await _commentsService.PostComment(commentAddRequest);
            } catch(DbUpdateException e)
            {
                return Problem(detail: e.Message, statusCode: 500);
            }

            return commentResponse;
        } 
    }
}
