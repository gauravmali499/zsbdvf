using Microsoft.EntityFrameworkCore;
using Practice.Data;
using System.Text.Json;

namespace Practice.DataSeeding
{
    public class SeedData
    {
        private readonly ColourContext colourContext;

        public SeedData(ColourContext colourContext)
        {
            this.colourContext = colourContext;
        }

        public async void seededData()
        {
            if (await colourContext.colours.AnyAsync())
            {
                return;
            }

            var col = await File.ReadAllTextAsync("C:/Users/gaura/source/repos/Practice/Practice/sample.json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var colours = JsonSerializer.Deserialize<List<colourDTO>>(col);

            foreach (var colour in colours)
            {
               await colourContext.colours.AddAsync(colour);
            }
            await colourContext.SaveChangesAsync();

        }
    }
}
