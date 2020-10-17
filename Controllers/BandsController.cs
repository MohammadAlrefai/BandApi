using BandWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandWebApi.Controllers
{
    [ApiController]
    [Route("api/Bands")]
    public class BandsController: ControllerBase
    {
        private readonly IBandAlbumRepository _bandAlbumRepository;
        public BandsController(IBandAlbumRepository bandAlbumRepository)
        {
            _bandAlbumRepository = bandAlbumRepository??throw new ArgumentNullException(nameof(bandAlbumRepository));
        }
        [HttpGet]
        public IActionResult GetBands()
        {
            var bandsFromRepo = _bandAlbumRepository.GetBands();
            return Ok(bandsFromRepo);
        }

        [HttpGet("{bandId}")]
        public IActionResult GetBand(Guid bandId)
        {
            //if (!_bandAlbumRepository.BandExists(bandId))
            //    return NotFound();
            //var bandFromRepo = _bandAlbumRepository.GetBand(bandId);
            //return new JsonResult(bandFromRepo);
            var bandFromRepo = _bandAlbumRepository.GetBand(bandId);
            if (bandFromRepo == null)
                return NotFound();
            return Ok(bandFromRepo);
        }

    }
}
