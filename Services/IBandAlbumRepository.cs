using BandWebApi.Entity;
using BandWebApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandWebApi.Services
{
    public interface IBandAlbumRepository
    {
        IEnumerable<Album> GetAlbums(Guid bandId);
        Album GetAlbum(Guid bandId,Guid AlbumId);
        void AddAlbum(Guid AlbumId, Album album);
        void UpdateAlbum(Album album);
        void DeleteAlbum(Album album);
        IEnumerable<Band> GetBands();
        Band GetBand(Guid bandId);
        IEnumerable<Band> GetBands(IEnumerable<Guid> bandIds);
        IEnumerable<Band> GetBands(BandResourceParameter bandResourceParameter);
        void AddBand( Band band);
        void UpdateBand(Band band);
        void DeleteBand(Band band);
        bool BandExists(Guid bandId);
        bool AlbumExists(Guid albumId);
        bool Save();
    }
}
