using BandWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using BandWebApi.Models;
using BandWebApi.Helpers;
using System.Collections.Generic;
using AutoMapper;
using BandWebApi.Entity;

namespace BandWebApi.Controllers
{
    [ApiController]
    [Route("api/Bands")]
    public class BandsController : ControllerBase
    {
        private readonly IBandAlbumRepository _bandAlbumRepository;
        private readonly IMapper _mapper;
        public BandsController(IBandAlbumRepository bandAlbumRepository, IMapper mapper)
        {
            _bandAlbumRepository = bandAlbumRepository ?? throw new ArgumentNullException(nameof(bandAlbumRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
 
        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<BandDto>> GetBands([FromQuery] BandResourceParameter bandResourceParameter)
        {
           
            var v = _bandAlbumRepository.GetBands(bandResourceParameter);
            return Ok(_mapper.Map<List<BandDto>>(v));
        }
              
        [HttpGet("{bandId}",Name = "GetBand")]
        public ActionResult<BandDto> GetBand(Guid bandId)
        {
            var bandFromRepo = _bandAlbumRepository.GetBand(bandId);
            return bandFromRepo == null ? NotFound() : (ActionResult<BandDto>)Ok(_mapper.Map<BandDto>(bandFromRepo));
        }

        [HttpPost]
        public ActionResult<BandDto> CreatBand([FromBody]BandForCreatingDto _band)
        {
            var bandEntity=_mapper.Map<Band>(_band);
            _bandAlbumRepository.AddBand(bandEntity);
            _bandAlbumRepository.Save();

            var BandToReturn = _mapper.Map<BandDto>(bandEntity);
            return CreatedAtRoute("GetBand",new { bandId= BandToReturn.Id }, BandToReturn);
        }


    }
}
