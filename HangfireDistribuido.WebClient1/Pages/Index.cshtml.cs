using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HangfireDistribuido.WebClient1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public IndexModel(ILogger<IndexModel> logger, IBackgroundJobClient backgroundJobClient)
        {
            _logger = logger;
            _backgroundJobClient = backgroundJobClient;
        }

        public void OnGet()
        {
            _backgroundJobClient.Enqueue(() => new Jobs.Jobs().Executar());
        }
    }
}