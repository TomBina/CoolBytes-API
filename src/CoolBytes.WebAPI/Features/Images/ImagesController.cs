﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoolBytes.WebAPI.Extensions;
using CoolBytes.WebAPI.Features.Images.CQ;
using CoolBytes.WebAPI.Features.Images.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoolBytes.WebAPI.Features.Images
{
    [ApiController]
    [Authorize("admin")]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ImagesController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<ImageViewModel>>> Get()
            => this.OkOrNotFound(await _mediator.Send(new GetImagesQuery()));

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<ImageViewModel>>> Upload([FromForm] UploadImagesCommand command)
            => (await _mediator.Send(command)).ToList();

        [HttpDelete]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteImageCommand() { Id = id };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
