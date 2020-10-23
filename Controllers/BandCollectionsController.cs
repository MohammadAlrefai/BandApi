using AutoMapper;
using BandWebApi.Entity;
using BandWebApi.Models;
using BandWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BandWebApi.Controllers
{
    [ApiController]
    [Route("api/bandCollections")]
    public class BandCollectionsController: ControllerBase
    {
        private readonly IBandAlbumRepository _bandAlbumRepository ;
        private readonly IMapper _mapper;
        public BandCollectionsController(IBandAlbumRepository bandAlbumRepository,IMapper mapper)
        {
            _bandAlbumRepository= bandAlbumRepository ?? throw new ArgumentNullException(nameof(mapper));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); 
        }
        public ActionResult<IEnumerable<BandDto>> CreateColletion([FromBody] IEnumerable<BandForCreatingDto> _bands)
        {
            var BandEntity = _mapper.Map <IEnumerable<Band >>(_bands);
            foreach (var Band in BandEntity)
                _bandAlbumRepository.AddBand(Band);
            
            _bandAlbumRepository.Save();
            var bandsCreating = _mapper.Map<IEnumerable<BandDto>>(BandEntity);
            return Ok(bandsCreating);
        }


    }
}
