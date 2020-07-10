using AppMovies.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Net;
using AppMovies.Controllers;


namespace AppMovies.Services
{
    public static class SetVideosAndImages
    {
        public static Movie addVideoAndImage<T>( T movie) where T: Movie
        {
            /*////////////////////////propiedades subir imagenes////////////////////////////////*/
            string imageFileName = Path.GetFileNameWithoutExtension(movie.ImageFile.FileName);
            string extension = Path.GetExtension(movie.ImageFile.FileName);

            imageFileName = imageFileName + DateTime.Now.ToString("yymmssfff") + extension;
            movie.ImagePath = "~/Media/Imgs/" + imageFileName;

            var strPathImage = System.Web.HttpContext.Current.Server.MapPath("~/Media/Imgs/");
            imageFileName = Path.Combine(strPathImage, imageFileName);
            movie.ImageFile.SaveAs(imageFileName);
            /*///////////////////////////////////////////////////////////////////////////////*/


            /*////////////////////////Propiedades subir videos///////////////////////////////*/
            string videoFileName = Path.GetFileNameWithoutExtension(movie.VideoFile.FileName);
            string extension2 = Path.GetExtension(movie.VideoFile.FileName);

            videoFileName = videoFileName + DateTime.Now.ToString("yymmssfff") + extension2;
            movie.VideoPath = "~/Media/Videos/" + videoFileName;

            var strPathVideo = System.Web.HttpContext.Current.Server.MapPath("~/Media/Videos/");
            videoFileName = Path.Combine(strPathVideo, videoFileName);
            movie.VideoFile.SaveAs(videoFileName);
            /*//////////////////////////////////////////////////////////////////////////////*/

            return movie;
        }
    }
}