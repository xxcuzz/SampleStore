using Amazon.S3;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SampleStore.API.Controllers
{
    [Authorize]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IAmazonS3 _s3;
        private const string BucketName = "sample-store-pet-proj";

        [HttpPost("products/{id:guid}/image")]
        public async Task<IActionResult> Upload()
        {
            return View();
        }
    }
}
