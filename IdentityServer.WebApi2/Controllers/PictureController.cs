using IdentityServer.WebApi2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.WebApi2.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class PictureController : ControllerBase
{
    [Authorize(Policy ="ReadPicture")]
    [HttpGet]
    public IActionResult GetPictures()
    {
        List<Picture> pictures = new List<Picture>() {
        new Picture { Id = 1,Name = "Doğa Manzarası",Uri="dogamanzara.jpg"},
        new Picture { Id = 2,Name = "Sevimli Kedi",Uri="sevimlikedi.jpg"},
        new Picture { Id = 3,Name = "Sevimli Köpek",Uri="sevimlikopek.jpg"},
        new Picture { Id = 4,Name = "Göl Manzarası",Uri="golmanzarasi.jpg"},
        new Picture { Id = 5,Name = "Deniz Manzarası",Uri="denizmanzarasi.jpg"}
        };

        return Ok(pictures);
    }

    [Authorize(Policy = "UpdateOrCreate")]
    [HttpPut("{id}")]
    public IActionResult UpdatePicture(int id)
    {
        return Ok($"{id} picture updated");
    }

    [Authorize(Policy = "UpdateOrCreate")]
    [HttpPost]
    public IActionResult CreatePicture()
    {
        return Ok("picture created");
    }
}