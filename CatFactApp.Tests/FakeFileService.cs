using CatFactApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactApp.Tests
{
    public class FakeFileService : IFileService
    {
        public string? SavedText { get; private set; }

        public Task SaveAsync(string text)
        {
            SavedText = text;

            return Task.CompletedTask;
        }
    }
}
