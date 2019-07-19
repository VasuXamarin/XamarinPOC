using System;
using System.Threading.Tasks;
using NativePocProject.iOS.Models;
using Refit;

namespace NativePocProject.iOS.Services.ApiDefinitions
{
    public interface IDropBoxContent
    {
        [Get("/s/2iodh4vg0eortkl/facts.json")]
        Task<DropBoxData> GetDropBoxContent();
    }
}
