using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NativePocProject.Droid.Models;
using Refit;

namespace NativePocProject.Droid.Services.ApiDefinitions
{
    public interface IDropBoxContentService
    {
        [Get("/s/2iodh4vg0eortkl/facts.json")]
        Task<DropBoxData> GetDropBoxContent();
    }
}
