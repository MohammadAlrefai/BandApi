using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BandWebApi.Services;
using BandWebApi.Models;
using System.Collections.Generic;
using BandWebApi.Entity;

namespace BandWebApi.Controllers
{
    [ApiController]
    [Route("api/bands/{bandId}/albums")]
    public class AlbumsController: ControllerBase
    {
        private readonly IBandAlbumRepository _bandAlbumRepository;
        private readonly IMapper _mapper;
        public AlbumsController(IBandAlbumRepository bandAlbumRepository, IMapper mapper)
        {
             _bandAlbumRepository = bandAlbumRepository ?? throw new ArgumentNullException(nameof(bandAlbumRepository));
             _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); 
        }
        [HttpGet]
        public ActionResult<IEnumerable<AlbumDto>> GetAlbumsFromBand (Guid bandId)
        {
            IEnumerable<Entity.Album> AlbumFromPro = _bandAlbumRepository.GetAlbums(bandId);
            if (AlbumFromPro != null)
                return Ok(_mapper.Map<IEnumerable<AlbumDto>>(AlbumFromPro));
            return NotFound();
        }

        [HttpGet("{albumId}",Name = "GetAlbumForBand")]
        public ActionResult<AlbumDto> GetAlbumForBand(Guid bandId , Guid albumId)
        {
            if (!_bandAlbumRepository.BandExists(bandId))
            {
                var AlbumFromPro = _bandAlbumRepository.GetAlbum(bandId, albumId);
                if (AlbumFromPro != null)
                    return Ok(_mapper.Map<AlbumDto>(AlbumFromPro));
                return NotFound();
            }
            return NotFound();
        }


        [HttpPost]
        public ActionResult<AlbumDto> CreateForAlbumForBand(Guid bandId,[FromBody] AlbumForCreatingDto _album)
        {
            if (!_bandAlbumRepository.BandExists(bandId))
                return NotFound();
            var AlbumEntity = _mapper.Map<Album>(_album);
            _bandAlbumRepository.AddAlbum(bandId, AlbumEntity);
            _bandAlbumRepository.Save();
            var AlbumToReturn = _mapper.Map<AlbumDto>(AlbumEntity);
            return CreatedAtRoute("GetAlbumForBand", new { bandId= AlbumToReturn.BandId, albumId = AlbumToReturn.Id}, AlbumToReturn);
        }

    }
}
