using Application.Services.Interface;
using Data.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Request;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        ///<summary>
        /// Inserta un nuevo Post
        /// </summary>
        /// <response code="401">Error de autenticación</response>
        /// <response code="200">Post creado correctamente</response>
        /// <response code="400">Error al crear Post</response>
        [HttpPost("WritePost")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> WritePost([FromBody] WritePostRequest writePostRequest)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst("id").Value;
            var post = writePostRequest.Adapt<Post>();
            var response = await postService.WritePost(post, userId);
            return StatusCode(response ? 200 : 400);
        }


        ///<summary>
        /// Inserta un nuevo comentario
        /// </summary>
        /// <response code="200">Comentario creado correctamente</response>
        /// <response code="400">Error al crear comentario</response>
        [HttpPost("WriteComment")]
        public async Task<IActionResult> WriteComment([FromBody] WriteCommentRequest writeCommentRequest)
        {
            var comment = writeCommentRequest.Adapt<Comment>();
            var response = await postService.WriteComment(comment);
            return StatusCode(response ? 200 : 400);
        }

        ///<summary>
        /// Obtener lista de Post que ya fueron aprobados
        /// </summary>
        /// <response code="200">Se obtiene lista correctamente (llena o vacía)</response>
        [HttpGet("GetPassedPost")]
        public async Task<IActionResult> GetPassedPost()
        {
            var response = await postService.GetPassedPost();
            return Ok(response);
        }

        ///<summary>
        /// Obtener lista de Post que no han sido aprobados de momento
        /// </summary>
        /// <response code="401">Error de autenticación</response>
        /// <response code="200">Se obtiene lista correctamente (llena o vacía)</response>
        [HttpGet("GetNotPassedPost")]
        [Authorize(Roles = "editor")]
        public async Task<IActionResult> GetNotPassedPost()
        {
            var response = await postService.GetNotPassedPost();
            return Ok(response);
        }

        ///<summary>
        /// Permite aprobar Post que están pendientes de aprobación
        /// </summary>
        /// <response code="401">Error de autenticación</response>
        /// <response code="200">Post aprobado correctamente</response>
        /// <response code="400">Error al aprobar Post</response>
        [HttpGet("ApprovePost/{postId}")]
        [Authorize(Roles = "editor")]
        public async Task<IActionResult> ApprovePost([FromRoute] int postId)
        {
            var response = await postService.ApprovePost(postId);
            return StatusCode(response ? 200 : 400);
        }

        ///<summary>
        /// Permite eliminar Post
        /// </summary>
        /// <response code="401">Error de autenticación</response>
        /// <response code="200">Post eliminado correctamente</response>
        /// <response code="400">Error al eliminar Post</response>
        [HttpGet("DeletePost/{postId}")]
        [Authorize(Roles = "editor")]
        public async Task<IActionResult> DeletePost([FromRoute] int postId)
        {
            var response = await postService.DeletePost(postId);
            return StatusCode(response ? 200 : 400);
        }

    }
}
