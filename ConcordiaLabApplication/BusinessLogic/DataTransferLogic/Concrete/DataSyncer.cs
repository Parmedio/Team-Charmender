﻿using BusinessLogic.DataTransferLogic.Abstract;

using Microsoft.Extensions.Logging;

namespace BusinessLogic.DataTransferLogic.Concrete;

public class DataSyncer : IDataSyncer
{

    private readonly ILogger<DataSyncer> _logger;
    private readonly IExperimentDownloader _experimentDownloader;
    private readonly ICommentDownloader _commentDownloader;
    private readonly IUploader _uploader;

    public DataSyncer(ILogger<DataSyncer> logger, IExperimentDownloader experimentDownloader, ICommentDownloader commentDownloader, IUploader uploader)
    {
        _logger = logger;
        _experimentDownloader = experimentDownloader;
        _commentDownloader = commentDownloader;
        _uploader = uploader;
    }

    public async Task SynchronizeAsync()
    {
        try
        {
            _logger.LogInformation("Download experiments from Trello started...");
            var downloader = await _experimentDownloader.DownloadExperiments();
            if (downloader._errorCount > 0)
            {
                _logger.LogWarning(downloader.Message);
            }
            else
                _logger.LogInformation(downloader.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Un unexpected Exception was caught while downloading experiments: {ex.Message}\n{ex.InnerException?.Message ?? ""}");
        }

        try
        {
            _logger.LogInformation("Download comments from Trello started...");
            var commentsDownloader = await _commentDownloader.DownloadComments();
            if (commentsDownloader._errorCount > 0)
            {
                _logger.LogWarning(commentsDownloader.Message);
            }
            else
                _logger.LogInformation(commentsDownloader.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Un unexpected Exception was caught while downloading comments: {ex.Message}\n{ex.InnerException?.Message ?? ""}");
        }

        try
        {
            _logger.LogInformation("Upload to Trello started...");
            var uploadLog = await _uploader.Upload();
            if (uploadLog._errorCount > 0)
            {
                _logger.LogWarning(uploadLog.Message);
            }
            else
                _logger.LogInformation(uploadLog.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Un unexpected Exception was caught while uploading local data: {ex.Message}\n{ex.InnerException?.Message ?? ""}");
        }
    }
}
